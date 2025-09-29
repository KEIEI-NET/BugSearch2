//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：前年対比表
// プログラム概要   ：前年対比表を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30462 行澤 仁美
// 修正日    2008/11/25     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：照田 貴志
// 修正日    2009/01/29     修正内容：不具合対応[9849][9835]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：忍 幸史
// 修正日    2009/02/02     修正内容：不具合対応[10881]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/16     修正内容：Mantis【13129】残案件No.19 端数処理
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：高峰
// 修正日    2012/05/18     修正内容：前年対比表(グループ別)と前年対比表(BLコード別)の金額が合わせないの対応
// ---------------------------------------------------------------------//
// 管理番号  11170129-00    作成担当：cheq
// 修正日    2015/08/17     修正内容：Redmine#47029 前年対比表比率算出不正とエラーが出るの対応
// ---------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 前年対比表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Programer  : 30462 行澤 仁美</br>
    /// <br>Date       : 2008.11.25</br>
    /// <br>UpdateNote : 2009/01/29 照田 貴志　不具合対応[9849][9835]</br>
    /// <br>UpdateNote : 2009/02/02 忍 幸史　不具合対応[10881]</br>
    /// </remarks>
    public class PrevYearComparison
    {
        // ===================================================================================== //
        //  外部提供定数
        // ===================================================================================== //
        #region public constant
        /// <summary>全拠点レコード用拠点コード</summary>
        public const string CT_AllSectionCode = "000000";
        #endregion

        // ===================================================================================== //
        //  スタティック変数
        // ===================================================================================== //
        #region static variable

        /// <summary>自拠点コード</summary>
        private static string mySectionCode = "";
        /// <summary>帳票出力設定データクラス</summary>
        private static PrtOutSet prtOutSetData = null;

        #endregion

        // ===================================================================================== //
        //  内部使用変数
        // ===================================================================================== //
        #region private member

        private static SecInfoAcs _secInfoAcs;

        /// <summary>帳票出力設定アクセスクラス</summary>
        private static PrtOutSetAcs prtOutSetAcs = null;
        /// <summary>印刷用DataSet</summary>
        public DataSet _printDataSet;
        /// <summary>バッファDataSet</summary>
        public static DataSet _printBuffDataSet;

        /// <summary>前年対比表データテーブル名</summary>
        private string _PrevYearCpDataTable;

        //　前回値保存用
        private string _beforAddUpSecCode = "";
        private string _beforSectionGuideSnmRF = "";
        private int    _beforCustomerCode = 0;
        private string _beforCustomerSnmRF = "";
        private string _beforEmployeeCode = "";
        private string _beforNameRF = "";
        private int    _beforBLGoodsCode = 0;
        private string _beforBLGoodsHalfNameRF = "";
        private int    _beforGoodsLGroup = 0;
        private string _beforGoodsLGroupName = "";
        private int    _beforGoodsMGroup = 0;
        private string _beforGoodsMGroupNameRF = "";
        private int    _beforBLGroupCode = 0;
        private string _beforBLGroupKanaNameRF = "";
        private int    _beforSalesAreaCode = 0;
        private string _beforSalesAreaName = "";
        private int    _beforBusinessTypeCode = 0;
        private string _beforBusinessTypeName = "";

        // 年月位置判定用
        private int[] _monthArray = null;

        // 金額単位　ADD 2009/01/30 不具合対応[9844]
        private int _moneyUnit = 0;

        #endregion

        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant

        ///// <summary>前年対比表バッファデータテーブル名</summary>
        private const string MESSAGE_NONOWNSECTION = "自拠点情報が取得できませんでした。拠点設定を行ってから起動してください。";

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region コンストラクター

        /// <summary>
        /// 前年対比表アクセスクラスコンストラクター
        /// </summary>
        public PrevYearComparison()
        {
            this.SettingDataTable();

            // 印刷用DataSet
            this._printDataSet = new DataSet();
            DataSetColumnConstruction(ref this._printDataSet);
            // バッファテーブルデータセット
            if (_printBuffDataSet == null)
            {
                _printBuffDataSet = new DataSet();
                DataSetColumnConstruction(ref _printBuffDataSet);
            }

            // 拠点情報取得
            this.CreateSecInfoAcs();
        }

        #endregion

        // ===================================================================================== //
        // 静的コンストラクタ
        // ===================================================================================== //
        #region 静的コンストラクター

        /// <summary>
        /// 前年対比表アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        static PrevYearComparison()
        {
            // 帳票出力設定アクセスクラスインスタンス化
            prtOutSetAcs = new PrtOutSetAcs();

            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                mySectionCode = loginEmployee.BelongSectionCode;
            }

        }

        #endregion

        // ===================================================================================== //
        // 外部提供関数
        // ===================================================================================== //
        #region public method

        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="prtOutSet">帳票出力設定データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
        /// <br>Programer  : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        // public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        static public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            try
            {
                // データは読込済みか？
                if (prtOutSetData != null)
                {
                    prtOutSet = prtOutSetData.Clone();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = prtOutSetData.Clone();
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            prtOutSet = new PrtOutSet();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        default:
                            prtOutSet = new PrtOutSet();
                            message = "帳票出力設定の読込に失敗しました。";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// 前年対比表データ初期化処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Static情報を初期化します。</br>
        /// <br>Programer  : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
        /// </remarks>
        public void InitializeCustomerLedger()
        {
            // --テーブル行初期化-----------------------
            // 抽出結果データテーブルをクリア
            if (this._printDataSet.Tables[_PrevYearCpDataTable] != null)
            {
                this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Clear();
            }
            // 抽出結果バッファデータテーブルをクリア
            if (_printBuffDataSet.Tables[_PrevYearCpDataTable] != null)
            {
                _printBuffDataSet.Tables[_PrevYearCpDataTable].Rows.Clear();
            }
        }

        /// <summary>
        /// 前年対比表データ取得処理
        /// </summary>
        /// <param name="PrYearCpListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="mode">サーチモード(0:remote only,1:static→remote,2:static only)</param>
        /// <returns></returns>
        public int Search(ExtrInfo_DCTOK02093E PrYearCpListCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(PrYearCpListCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(PrYearCpListCndtn, out message);
                        }
                        break;
                    }
                case 2:
                    {
                        // static only の場合はリモーティングに行かない
                        status = this.SearchStatic(out message);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// 前年対比表スタティックデータ取得処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Clear();

            if (_printBuffDataSet.Tables[_PrevYearCpDataTable].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_PrevYearCpDataTable].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_PrevYearCpDataTable].NewRow();
                        buffDr = _printBuffDataSet.Tables[_PrevYearCpDataTable].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Add(dr);
                    }
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.Message;
                }
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }

        /// <summary>
        /// 前年対比表データ取得処理
        /// </summary>
        /// <param name="PrYearCpListCndtn"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 対象範囲の前年対比表データを取得します。</br>
        /// <br>Programer  : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.11.25</br>
        /// <br>UpdateNote : 前年対比表(グループ別)と前年対比表(BLコード別)の金額が合わせないの対応</br>
        /// <br>Programmer : 高峰</br>
        /// <br>Date       : 2012/05/18</br>
        /// </remarks>
        private int Search(ExtrInfo_DCTOK02093E PrYearCpListCndtn, out string message)
        {
            object retObj;
            bool addflg = false;
            int rowIndex = -1;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            try
            {
                // StaticMemory　初期化
                InitializeCustomerLedger();

                // リモートからデータの取得
                ExtrInfo_PrevYearComparisonWork PrYearCpShWork = new ExtrInfo_PrevYearComparisonWork();
                // 抽出条件パラメータセット
                this.SearchParaSet(PrYearCpListCndtn, ref PrYearCpShWork);

                #region 月配列
                // 月の配列作成
                if (PrYearCpListCndtn.St_AddUpYearMonth == PrYearCpListCndtn.Ed_AddUpYearMonth)
                {
                    this._monthArray = new int[] { PrYearCpListCndtn.St_AddUpYearMonth };
                }
                else
                {
                    int st_nextyear = (Int32.Parse(PrYearCpListCndtn.St_AddUpYearMonth.ToString().Substring(0, 4)) + 1) * 100;
                    int st_yearmonth = PrYearCpListCndtn.St_AddUpYearMonth;
                    int ed_yearmonth = PrYearCpListCndtn.Ed_AddUpYearMonth;
                    this._monthArray = new int[12];

                    this._monthArray[0] = st_yearmonth;
                    for (int i = 1; i < 12; i++)
                    {
                        st_yearmonth++;
                        if (st_yearmonth.ToString().Substring(4, 2).Equals("13"))
                        {
                            st_yearmonth = st_nextyear + 1;
                        }

                        if (st_yearmonth <= ed_yearmonth)
                        {
                            this._monthArray[i] = st_yearmonth;
                        }
                    }
                }
                #endregion

                status = this.SearchByMode(out retObj, PrYearCpShWork);

                ArrayList retList = new ArrayList();
                retList = (ArrayList)retObj;

                if ((status == 0) && (retList.Count != 0))
                {
                    // --- ADD 2009/02/02 障害ID:10881対応------------------------------------------------------>>>>>
                    // ソート用にリスト作成
                    List<RsltInfo_PrevYearComparisonWork> retWorkList = new List<RsltInfo_PrevYearComparisonWork>();
                    for (int i = 0; i < retList.Count; i++)
                    {
                        RsltInfo_PrevYearComparisonWork retWork = (RsltInfo_PrevYearComparisonWork)retList[i];
                        retWorkList.Add(retWork);
                    }

                    // ソート
                    retWorkList.Sort(delegate(RsltInfo_PrevYearComparisonWork x, RsltInfo_PrevYearComparisonWork y)
                    {
                        switch (PrYearCpShWork.ListType)
                        {
                            case 0:
                                {
                                    //前年対比表（得意先別）
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        return (x.CustomerCode - y.CustomerCode);
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 1:
                            case 2:
                                {
                                    //前年対比表（担当者別）
                                    //前年対比表（受注者別）
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (String.Compare(x.EmployeeCode, y.EmployeeCode));
                                        //得意先別
                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            if (String.Compare(x.EmployeeCode, y.EmployeeCode) == 0)
                                            {
                                                return (x.CustomerCode - y.CustomerCode);
                                            }
                                            else
                                            {
                                                return (String.Compare(x.EmployeeCode, y.EmployeeCode));
                                            }

                                        }
                                        else
                                        {
                                          return (String.Compare(x.EmployeeCode, y.EmployeeCode));
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<

                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 3:
                                {
                                    //前年対比表（地区別）
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (x.SalesAreaCode - y.SalesAreaCode);
                                        //得意先別
                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            if ((x.SalesAreaCode - y.SalesAreaCode) == 0)
                                            {
                                                return (x.CustomerCode - y.CustomerCode);
                                            }
                                            else
                                            {
                                                return (x.SalesAreaCode - y.SalesAreaCode);
                                            }

                                        }
                                        else
                                        {
                                            return (x.SalesAreaCode - y.SalesAreaCode);
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<

                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 4:
                                {
                                    //前年対比表（業種別）
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (x.BusinessTypeCode - y.BusinessTypeCode);
                                        //得意先別
                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            if ((x.BusinessTypeCode - y.BusinessTypeCode) == 0)
                                            {
                                                return (x.CustomerCode - y.CustomerCode);
                                            }
                                            else
                                            {
                                                return (x.BusinessTypeCode - y.BusinessTypeCode);
                                            }

                                        }
                                        else
                                        {
                                            return (x.BusinessTypeCode - y.BusinessTypeCode);
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 5:
                                {
                                    //前年対比表（グループコード別）
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (x.BLGroupCode - y.BLGroupCode);

                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            //商品中分類別
                                            if ((x.BLGroupCode - y.BLGroupCode) == 0)
                                            {
                                                return (x.GoodsMGroup - y.GoodsMGroup);
                                            }
                                            else
                                            {
                                                return (x.BLGroupCode - y.BLGroupCode);
                                            }
                                        }
                                        else if (PrYearCpShWork.printType == 2)
                                        {
                                            //商品大分類別
                                            if ((x.BLGroupCode - y.BLGroupCode) == 0)
                                            {
                                                return (x.GoodsLGroup - y.GoodsLGroup);
                                            }
                                            else
                                            {
                                                return (x.BLGroupCode - y.BLGroupCode);
                                            }
                                        }
                                        else
                                        {
                                            return (x.BLGroupCode - y.BLGroupCode);
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            case 6:
                                {
                                    //前年対比表（ＢＬコード別）
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        // -- UPD 2011/01/28 --------------------------->>>
                                        //return (x.BLGoodsCode - y.BLGoodsCode);

                                        if (PrYearCpShWork.printType == 1)
                                        {
                                            //ＢＬコード別得意先別
                                            if ((x.BLGoodsCode - y.BLGoodsCode) == 0)
                                            {
                                                return (x.CustomerCode - y.CustomerCode);
                                            }
                                            else
                                            {
                                                return (x.BLGoodsCode - y.BLGoodsCode);
                                            }
                                        }
                                        else if (PrYearCpShWork.printType == 2)
                                        {
                                            //ＢＬコード別担当者別
                                            if ((x.BLGoodsCode - y.BLGoodsCode) == 0)
                                            {
                                                return (String.Compare(x.EmployeeCode, y.EmployeeCode));
                                            }
                                            else
                                            {
                                                return (x.BLGoodsCode - y.BLGoodsCode);
                                            }
                                        }
                                        else
                                        {
                                            return (x.BLGoodsCode - y.BLGoodsCode);
                                        }
                                        // -- UPD 2011/01/28 ---------------------------<<<
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                            default:
                                {
                                    if (String.Compare(x.AddUpSecCode, y.AddUpSecCode) == 0)
                                    {
                                        return (x.CustomerCode - y.CustomerCode);
                                    }
                                    else
                                    {
                                        return (String.Compare(x.AddUpSecCode, y.AddUpSecCode));
                                    }
                                }
                        }
                    });
                    // --- ADD 2009/02/02 障害ID:10881対応------------------------------------------------------<<<<<

                    // 情報取得
                    // --- CHG 2009/02/02 障害ID:10881対応------------------------------------------------------>>>>>
                    //for (int i = 0; i < retList.Count; i++)
                    for (int i = 0; i < retWorkList.Count; i++)
                    // --- CHG 2009/02/02 障害ID:10881対応------------------------------------------------------<<<<<
                    {
                        DataRow dr;
                        addflg = false;

                        #region 新規行かを判定
                        // --- CHG 2009/02/02 障害ID:10881対応------------------------------------------------------>>>>>
                        //RsltInfo_PrevYearComparisonWork prevYearCpWork = (RsltInfo_PrevYearComparisonWork)retList[i];
                        RsltInfo_PrevYearComparisonWork prevYearCpWork = (RsltInfo_PrevYearComparisonWork)retWorkList[i];
                        // --- CHG 2009/02/02 障害ID:10881対応------------------------------------------------------<<<<<

                        if (this._beforAddUpSecCode != prevYearCpWork.AddUpSecCode ||
                            this._beforSectionGuideSnmRF != prevYearCpWork.SectionGuideSnm ||
                            this._beforCustomerCode != prevYearCpWork.CustomerCode ||
                            this._beforCustomerSnmRF != prevYearCpWork.CustomerSnm ||
                            this._beforEmployeeCode != prevYearCpWork.EmployeeCode ||
                            this._beforNameRF != prevYearCpWork.Name ||
                            this._beforBLGoodsCode != prevYearCpWork.BLGoodsCode ||
                            this._beforBLGoodsHalfNameRF != prevYearCpWork.BLGoodsHalfName ||
                            this._beforGoodsLGroup != prevYearCpWork.GoodsLGroup ||
                            this._beforGoodsLGroupName != prevYearCpWork.GoodsLGroupName ||
                            this._beforGoodsMGroup != prevYearCpWork.GoodsMGroup ||
                            this._beforGoodsMGroupNameRF != prevYearCpWork.GoodsMGroupName ||
                            this._beforBLGroupCode != prevYearCpWork.BLGroupCode ||
                            this._beforBLGroupKanaNameRF != prevYearCpWork.BLGroupKanaName ||
                            this._beforSalesAreaCode != prevYearCpWork.SalesAreaCode ||
                            this._beforSalesAreaName != prevYearCpWork.SalesAreaName ||
                            this._beforBusinessTypeCode != prevYearCpWork.BusinessTypeCode ||
                            this._beforBusinessTypeName != prevYearCpWork.BusinessTypeName)
                        {
                            addflg = true;
                            dr = this._printDataSet.Tables[_PrevYearCpDataTable].NewRow();
                            rowIndex++;

                            this._beforAddUpSecCode = prevYearCpWork.AddUpSecCode;
                            this._beforSectionGuideSnmRF = prevYearCpWork.SectionGuideSnm;
                            this._beforCustomerCode = prevYearCpWork.CustomerCode;
                            this._beforCustomerSnmRF = prevYearCpWork.CustomerSnm;
                            this._beforEmployeeCode = prevYearCpWork.EmployeeCode;
                            this._beforNameRF = prevYearCpWork.Name;
                            this._beforBLGoodsCode = prevYearCpWork.BLGoodsCode;
                            this._beforBLGoodsHalfNameRF = prevYearCpWork.BLGoodsHalfName;
                            this._beforGoodsLGroup = prevYearCpWork.GoodsLGroup;
                            this._beforGoodsLGroupName = prevYearCpWork.GoodsLGroupName;
                            this._beforGoodsMGroup = prevYearCpWork.GoodsMGroup;
                            this._beforGoodsMGroupNameRF = prevYearCpWork.GoodsMGroupName;
                            this._beforBLGroupCode = prevYearCpWork.BLGroupCode;
                            this._beforBLGroupKanaNameRF = prevYearCpWork.BLGroupKanaName;
                            this._beforSalesAreaCode = prevYearCpWork.SalesAreaCode;
                            this._beforSalesAreaName = prevYearCpWork.SalesAreaName;
                            this._beforBusinessTypeCode = prevYearCpWork.BusinessTypeCode;
                            this._beforBusinessTypeName = prevYearCpWork.BusinessTypeName;

                        }
                        else
                        {
                            //// ----- ADD 高峰 2012/05/18 前年対比表(グループ別)と前年対比表(BLコード別)の金額が合わせないの対応 ----->>>>>
                            // 障害：中分類が設定していなく、BLコード=０の伝票が同時に存在する場合、一部の伝票の金額が集計されない。
                            if (prevYearCpWork.GoodsMGroup == 0)
                            {
                                for (int j = i - 1; j >= 0; j--)
                                {
                                    RsltInfo_PrevYearComparisonWork prevWork = (RsltInfo_PrevYearComparisonWork)retWorkList[j];

                                    if (prevWork.AddUpSecCode == prevYearCpWork.AddUpSecCode &&
                                        prevWork.SectionGuideSnm == prevYearCpWork.SectionGuideSnm &&
                                        prevWork.CustomerCode == prevYearCpWork.CustomerCode &&
                                        prevWork.CustomerSnm == prevYearCpWork.CustomerSnm &&
                                        prevWork.EmployeeCode == prevYearCpWork.EmployeeCode &&
                                        prevWork.Name == prevYearCpWork.Name &&
                                        prevWork.BLGoodsCode == prevYearCpWork.BLGoodsCode &&
                                        prevWork.BLGoodsHalfName == prevYearCpWork.BLGoodsHalfName &&
                                        prevWork.GoodsLGroup == prevYearCpWork.GoodsLGroup &&
                                        prevWork.GoodsLGroupName == prevYearCpWork.GoodsLGroupName &&
                                        prevWork.GoodsMGroup == prevYearCpWork.GoodsMGroup &&
                                        prevWork.GoodsMGroupName == prevYearCpWork.GoodsMGroupName &&
                                        prevWork.BLGroupCode == prevYearCpWork.BLGroupCode &&
                                        prevWork.BLGroupKanaName == prevYearCpWork.BLGroupKanaName &&
                                        prevWork.SalesAreaCode == prevYearCpWork.SalesAreaCode &&
                                        prevWork.SalesAreaName == prevYearCpWork.SalesAreaName &&
                                        prevWork.BusinessTypeCode == prevYearCpWork.BusinessTypeCode &&
                                        prevWork.BusinessTypeName == prevYearCpWork.BusinessTypeName &&
                                        prevWork.AddUpMonth == prevYearCpWork.AddUpMonth)  // 期間が１ケ月以上の場合、月の比較が必要
                                    {
                                        prevYearCpWork.ThisTermSales += prevWork.ThisTermSales;     // 売上額(Int64)
                                        prevYearCpWork.FirstTermSales += prevWork.FirstTermSales;     // 売上額(Int64)
                                        prevYearCpWork.ThisTermGross += prevWork.ThisTermGross; // 粗利額(Int64)
                                        prevYearCpWork.FirstTermGross += prevWork.FirstTermGross;  // 粗利額(Int64)

                                        break;
                                    }
                                }
                            }
                            //// ----- ADD 高峰 2012/05/18 前年対比表(グループ別)と前年対比表(BLコード別)の金額が合わせないの対応 -----<<<<< 

                            dr = this._printDataSet.Tables[_PrevYearCpDataTable].Rows[rowIndex];
                        }
                        #endregion

                        // --- CHG 2009/02/02 障害ID:10881対応------------------------------------------------------>>>>>
                        //SetTebleRowFromRetList(ref dr, retList, i);
                        SetTebleRowFromRetList(ref dr, retWorkList, i);
                        // --- CHG 2009/02/02 障害ID:10881対応------------------------------------------------------<<<<<

                        if (addflg == true)
                        {
                            this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Add(dr);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                // 合計値＆比率を算出
                for (int i = 0; i < this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Count; i++)
                {
                    DataRow dr;

                    dr = this._printDataSet.Tables[_PrevYearCpDataTable].Rows[i];

                    SetTebleRowFromRetListSum(ref dr);
                }

                // 画面抽出条件と一致するかを判定
                if (PrYearCpListCndtn.St_MonthSalesRatio_ck == true ||
                    PrYearCpListCndtn.Ed_MonthSalesRatio_ck == true ||
                    PrYearCpListCndtn.St_YearSalesRatio_ck == true ||
                    PrYearCpListCndtn.Ed_YearSalesRatio_ck == true ||
                    PrYearCpListCndtn.St_MonthGrossRatio_ck == true ||
                    PrYearCpListCndtn.Ed_MonthGrossRatio_ck == true ||
                    PrYearCpListCndtn.St_YearGrossRatio_ck == true ||
                    PrYearCpListCndtn.Ed_YearGrossRatio_ck == true)
                {
                    // どれか一つでも手入力してたら条件チェックをする
                    this.CheckVal(PrYearCpListCndtn);
                }

                // ---ADD 2009/01/29 不具合対応[9835] ----------------------------------------->>>>>
                if (this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                // ---ADD 2009/01/29 不具合対応[9835] -----------------------------------------<<<<<

                // バッファテーブルへの格納
                _printBuffDataSet = this._printDataSet.Copy();

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }

        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// 検索パラメータ設定処理
        /// </summary>
        private void SearchParaSet(ExtrInfo_DCTOK02093E prYearCpListCndtn, ref ExtrInfo_PrevYearComparisonWork prYearCpShWork)
        {
            prYearCpShWork.EnterpriseCode = prYearCpListCndtn.EnterpriseCode;			// 企業コード

            prYearCpShWork.secCodeList = prYearCpListCndtn.SecCodeList;					//出力対象拠点（null:全社）

            prYearCpShWork.TotalWay = prYearCpListCndtn.TotalWay;                       // 集計方法

            prYearCpShWork.ListType = prYearCpListCndtn.ListType;                       // 出力方法（帳票タイプ）

            prYearCpShWork.MoneyUnit = prYearCpListCndtn.MoneyUnit;						// 金額単位
            this._moneyUnit = prYearCpListCndtn.MoneyUnit;                  //ADD 2009/01/30 不具合対応[9844]

            prYearCpShWork.printType = prYearCpListCndtn.IssueType;						// 発行タイプ

            prYearCpShWork.St_AddUpYearMonth = prYearCpListCndtn.St_AddUpYearMonth;     // 開始 対象年月
            prYearCpShWork.Ed_AddUpYearMonth = prYearCpListCndtn.Ed_AddUpYearMonth;     // 終了 対象年月

            prYearCpShWork.St_MonthSalesRatio = prYearCpListCndtn.St_MonthSalesRatio;   // 開始 当月純売上
            prYearCpShWork.Ed_MonthSalesRatio = prYearCpListCndtn.Ed_MonthSalesRatio;   // 終了 当月純売上

            prYearCpShWork.St_YearSalesRatio = prYearCpListCndtn.St_YearSalesRatio;     // 開始 当年純売上
            prYearCpShWork.Ed_YearSalesRatio = prYearCpListCndtn.Ed_YearSalesRatio;	    // 終了 当年純売上

            prYearCpShWork.St_MonthGrossRatio = prYearCpListCndtn.St_MonthGrossRatio;   // 開始 当月粗利
            prYearCpShWork.Ed_MonthGrossRatio = prYearCpListCndtn.Ed_MonthGrossRatio;   // 終了 当月粗利

            prYearCpShWork.St_YearGrossRatio = prYearCpListCndtn.St_YearGrossRatio;     // 開始 当年粗利
            prYearCpShWork.Ed_YearGrossRatio = prYearCpListCndtn.Ed_YearGrossRatio;	    // 終了 当年粗利

            prYearCpShWork.St_EmployeeCode = prYearCpListCndtn.St_EmployeeCode;         // 開始 担当者
            if (prYearCpListCndtn.Ed_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
            {
                prYearCpShWork.Ed_EmployeeCode = "9999";                                // 終了 担当者
            }
            else
            {
                prYearCpShWork.Ed_EmployeeCode = prYearCpListCndtn.Ed_EmployeeCode;     // 終了 担当者
            }
            prYearCpShWork.St_CustomerCode = prYearCpListCndtn.St_CustomerCode;         // 開始 得意先
            if (prYearCpListCndtn.Ed_CustomerCode == 0)
            {
                prYearCpShWork.Ed_CustomerCode = 99999999;                              // 終了 得意先
            }
            else
            {
                prYearCpShWork.Ed_CustomerCode = prYearCpListCndtn.Ed_CustomerCode;     // 終了 得意先
            }

            prYearCpShWork.St_SalesAreaCode = prYearCpListCndtn.St_SalesAreaCode;       // 開始 地区
            if (prYearCpListCndtn.Ed_SalesAreaCode == 0)
            {
                prYearCpShWork.Ed_SalesAreaCode = 9999;                                 // 終了 地区
            }
            else
            {
                prYearCpShWork.Ed_SalesAreaCode = prYearCpListCndtn.Ed_SalesAreaCode;   // 終了 地区
            }

            prYearCpShWork.St_BusinessTypeCode = prYearCpListCndtn.St_BusinessTypeCode; // 開始 業種
            if (prYearCpListCndtn.Ed_BusinessTypeCode == 0)
            {
                prYearCpShWork.Ed_BusinessTypeCode = 9999;                              // 終了 業種
            }
            else
            {
                prYearCpShWork.Ed_BusinessTypeCode = prYearCpListCndtn.Ed_BusinessTypeCode; // 終了 業種
            }

            prYearCpShWork.St_BLGoodsCode = prYearCpListCndtn.St_BLGoodsCode;           // 開始 BLコード
            if (prYearCpListCndtn.Ed_BLGoodsCode == 0)
            {
                prYearCpShWork.Ed_BLGoodsCode = 99999;                                  // 終了 BLコード
            }
            else
            {
                prYearCpShWork.Ed_BLGoodsCode = prYearCpListCndtn.Ed_BLGoodsCode;       // 終了 BLコード
            }

            prYearCpShWork.St_GoodsLGroup = prYearCpListCndtn.St_GoodsLGroup;           // 開始 商品大分類
            if (prYearCpListCndtn.Ed_GoodsLGroup == 0)
            {
                prYearCpShWork.Ed_GoodsLGroup = 9999;                                   // 終了 商品大分類
            }
            else
            {
                prYearCpShWork.Ed_GoodsLGroup = prYearCpListCndtn.Ed_GoodsLGroup;       // 終了 商品大分類
            }

            prYearCpShWork.St_GoodsMGroup = prYearCpListCndtn.St_GoodsMGroup;           // 開始 商品中分類
            if (prYearCpListCndtn.Ed_GoodsMGroup == 0)
            {
                prYearCpShWork.Ed_GoodsMGroup = 9999;                                   // 終了 商品中分類
            }
            else
            {
                prYearCpShWork.Ed_GoodsMGroup = prYearCpListCndtn.Ed_GoodsMGroup;       // 終了 商品中分類
            }

            prYearCpShWork.St_BLGroupCode = prYearCpListCndtn.St_BLGroupCode;           // 開始 グループコード
            if (prYearCpListCndtn.Ed_BLGroupCode == 0)
            {
                prYearCpShWork.Ed_BLGroupCode = 99999;                                  // 終了 グループコード
            }
            else
            {
                prYearCpShWork.Ed_BLGroupCode = prYearCpListCndtn.Ed_BLGroupCode;       // 終了 グループコード
            }
        }

        /// <summary>
        /// データスキーマ構成処理
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            // 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.DCTOK02094EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// モード毎のSearch呼出処理
        /// </summary>
        /// <param name="retObj">取得データオブジェクト</param>
        /// <param name="prYearCpShWork">リモート検索条件クラス</param>
        /// <returns>ステータス</returns>
        private int SearchByMode(out object retObj, ExtrInfo_PrevYearComparisonWork prYearCpShWork)
        {
            int status = 0;

            retObj = null;

            IPrevYearComparisonDB _iSalesConfDB = (IPrevYearComparisonDB)MediationPrevYearComparisonDB.GetPrevYearComparisonDB();

            status = _iSalesConfDB.SearchPrevYearComparison(out retObj, prYearCpShWork);

            return status;
        }
        
        /// <summary>
        /// 起動モード毎データテーブル設定
        /// </summary>
        private void SettingDataTable()
        {
            this._PrevYearCpDataTable = Broadleaf.Application.UIData.DCTOK02094EA.CT_PrevYearCpDataTable;
        }

        /// <summary>
        /// データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="retList">データ取得元リスト</param>
        /// <param name="setCnt">リストのデータ取得Index</param>
        // --- CHG 2009/02/02 障害ID:10881対応------------------------------------------------------>>>>>
        //private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
        private void SetTebleRowFromRetList(ref DataRow dr, List<RsltInfo_PrevYearComparisonWork> retList, int setCnt)
        // --- CHG 2009/02/02 障害ID:10881対応------------------------------------------------------<<<<<
        {
            int index = 0;

            RsltInfo_PrevYearComparisonWork prevYearCpWork = (RsltInfo_PrevYearComparisonWork)retList[setCnt];

            dr[DCTOK02094EA.CT_PrevYear_AddUpSecCode] = prevYearCpWork.AddUpSecCode;		 // 計上拠点コード(string)
            dr[DCTOK02094EA.CT_PrevYear_SectionGuidNm] = prevYearCpWork.SectionGuideSnm;	 // 拠点ガイド名称 (string)
            dr[DCTOK02094EA.CT_PrevYear_EmployeeCode] = prevYearCpWork.EmployeeCode;         // 従業員コード  (string)
            dr[DCTOK02094EA.CT_PrevYear_EmployeeName] = prevYearCpWork.Name;                 // 従業員名称    (string)
            dr[DCTOK02094EA.CT_PrevYear_CustomerCode] = prevYearCpWork.CustomerCode;         // 得意先コード  (Int32)
            dr[DCTOK02094EA.CT_PrevYear_CustomerSnm] = prevYearCpWork.CustomerSnm;           // 得意先略称    (string)
            dr[DCTOK02094EA.CT_PrevYear_BusinessTypeCode] = prevYearCpWork.BusinessTypeCode; // 業種コード    (Int32)
            dr[DCTOK02094EA.CT_PrevYear_BusinessTypeName] = prevYearCpWork.BusinessTypeName; // 業種名称		(string)
            dr[DCTOK02094EA.CT_PrevYear_SalesAreaCode] = prevYearCpWork.SalesAreaCode;       // 販売エリアコード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_SalesAreaName] = prevYearCpWork.SalesAreaName;		 // 販売エリア名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_BLGoodsCode] = prevYearCpWork.BLGoodsCode;           // BLコード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] = prevYearCpWork.BLGoodsHalfName;	 // BL名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_GoodsLGroup] = prevYearCpWork.GoodsLGroup;           // 商品大分類コード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_GoodsLGroupName] = prevYearCpWork.GoodsLGroupName;	 // 商品大分類名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_GoodsMGroup] = prevYearCpWork.GoodsMGroup;           // 商品中分類コード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_GoodsMGroupName] = prevYearCpWork.GoodsMGroupName;	 // 商品中分類名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_BLGroupCode] = prevYearCpWork.BLGroupCode;           // グループコード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] = prevYearCpWork.BLGroupKanaName;	 // グループ名称  (string)

            // 項目設定場所を判定
            for (int i = 0; i < 12; i++)
            {
                if (Int32.Parse(this._monthArray[i].ToString().Substring(4, 2)) == prevYearCpWork.AddUpMonth)
                {
                    index = i + 1;
                    break;
                }
            }

            switch (index)
            {
                case 1:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1] = prevYearCpWork.ThisTermSales;     // 売上額(当期1ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1] = prevYearCpWork.FirstTermSales;   // 売上額(前期1ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio1] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(1ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1] = prevYearCpWork.ThisTermGross;     // 粗利額(当期1ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1] = prevYearCpWork.FirstTermGross;   // 粗利額(前期1ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio1] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(1ヶ月目)    (Double)
                    break;
                case 2:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2] = prevYearCpWork.ThisTermSales;     // 売上額(当期2ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2] = prevYearCpWork.FirstTermSales;   // 売上額(前期2ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio2] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(2ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2] = prevYearCpWork.ThisTermGross;     // 粗利額(当期2ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2] = prevYearCpWork.FirstTermGross;   // 粗利額(前期2ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio2] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(2ヶ月目)    (Double)
                    break;
                case 3:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3] = prevYearCpWork.ThisTermSales;     // 売上額(当期3ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3] = prevYearCpWork.FirstTermSales;   // 売上額(前期3ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio3] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(3ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3] = prevYearCpWork.ThisTermGross;     // 粗利額(当期3ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3] = prevYearCpWork.FirstTermGross;   // 粗利額(前期3ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio3] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(3ヶ月目)    (Double)
                    break;
                case 4:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4] = prevYearCpWork.ThisTermSales;     // 売上額(当期4ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4] = prevYearCpWork.FirstTermSales;   // 売上額(前期4ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio4] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(4ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4] = prevYearCpWork.ThisTermGross;     // 粗利額(当期4ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4] = prevYearCpWork.FirstTermGross;   // 粗利額(前期4ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio4] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(4ヶ月目)    (Double)
                    break;
                case 5:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5] = prevYearCpWork.ThisTermSales;     // 売上額(当期5ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5] = prevYearCpWork.FirstTermSales;   // 売上額(前期5ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio5] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(5ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5] = prevYearCpWork.ThisTermGross;     // 粗利額(当期5ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5] = prevYearCpWork.FirstTermGross;   // 粗利額(前期5ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio5] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(5ヶ月目)    (Double)
                    break;
                case 6:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6] = prevYearCpWork.ThisTermSales;     // 売上額(当期6ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6] = prevYearCpWork.FirstTermSales;   // 売上額(前期6ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio6] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(6ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6] = prevYearCpWork.ThisTermGross;     // 粗利額(当期6ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6] = prevYearCpWork.FirstTermGross;   // 粗利額(前期6ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio6] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(6ヶ月目)    (Double)
                    break;
                case 7:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7] = prevYearCpWork.ThisTermSales;     // 売上額(当期7ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7] = prevYearCpWork.FirstTermSales;   // 売上額(前期7ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio7] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(7ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7] = prevYearCpWork.ThisTermGross;     // 粗利額(当期7ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7] = prevYearCpWork.FirstTermGross;   // 粗利額(前期7ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio7] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(7ヶ月目)    (Double)
                    break;
                case 8:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8] = prevYearCpWork.ThisTermSales;     // 売上額(当期8ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8] = prevYearCpWork.FirstTermSales;   // 売上額(前期8ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio8] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(8ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8] = prevYearCpWork.ThisTermGross;     // 粗利額(当期8ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8] = prevYearCpWork.FirstTermGross;   // 粗利額(前期8ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio8] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(8ヶ月目)    (Double)
                    break;
                case 9:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9] = prevYearCpWork.ThisTermSales;     // 売上額(当期9ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9] = prevYearCpWork.FirstTermSales;   // 売上額(前期9ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio9] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(9ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9] = prevYearCpWork.ThisTermGross;     // 粗利額(当期9ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9] = prevYearCpWork.FirstTermGross;   // 粗利額(前期9ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio9] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(9ヶ月目)    (Double)
                    break;
                case 10:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10] = prevYearCpWork.ThisTermSales;     // 売上額(当期10ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10] = prevYearCpWork.FirstTermSales;   // 売上額(前期10ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio10] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(10ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10] = prevYearCpWork.ThisTermGross;     // 粗利額(当期10ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10] = prevYearCpWork.FirstTermGross;   // 粗利額(前期10ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio10] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(10ヶ月目)    (Double)
                    break;
                case 11:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11] = prevYearCpWork.ThisTermSales;     // 売上額(当期11ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11] = prevYearCpWork.FirstTermSales;   // 売上額(前期11ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio11] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(11ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11] = prevYearCpWork.ThisTermGross;     // 粗利額(当期11ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11] = prevYearCpWork.FirstTermGross;   // 粗利額(前期11ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio11] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(11ヶ月目)    (Double)
                    break;
                case 12:
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12] = prevYearCpWork.ThisTermSales;     // 売上額(当期12ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12] = prevYearCpWork.FirstTermSales;   // 売上額(前期12ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_SalesRatio12] = GetRatio(prevYearCpWork.ThisTermSales, prevYearCpWork.FirstTermSales);   // 売上比(12ヶ月目)    (Double)
                    dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12] = prevYearCpWork.ThisTermGross;     // 粗利額(当期12ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12] = prevYearCpWork.FirstTermGross;   // 粗利額(前期12ヶ月目)(Int64)
                    dr[DCTOK02094EA.CT_PrevYear_GrossRatio12] = GetRatio(prevYearCpWork.ThisTermGross, prevYearCpWork.FirstTermGross);   // 粗利比(12ヶ月目)    (Double)
                    break;
            }
            /*
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1] = prevYearCpWork.ThisTermSales1;     // 売上額(当期1ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1] = prevYearCpWork.FirstTermSales1;   // 売上額(前期1ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio1] = prevYearCpWork.SalesRatio1;           // 売上比(1ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1] = prevYearCpWork.ThisTermGross1;     // 粗利額(当期1ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1] = prevYearCpWork.FirstTermGross1;   // 粗利額(前期1ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio1] = prevYearCpWork.GrossRatio1;           // 粗利比(1ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2] = prevYearCpWork.ThisTermSales2;     // 売上額(当期2ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2] = prevYearCpWork.FirstTermSales2;   // 売上額(前期2ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio2] = prevYearCpWork.SalesRatio2;           // 売上比(2ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2] = prevYearCpWork.ThisTermGross2;     // 粗利額(当期2ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2] = prevYearCpWork.FirstTermGross2;   // 粗利額(前期2ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio2] = prevYearCpWork.GrossRatio2;           // 粗利比(2ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3] = prevYearCpWork.ThisTermSales3;     // 売上額(当期3ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3] = prevYearCpWork.FirstTermSales3;   // 売上額(前期3ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio3] = prevYearCpWork.SalesRatio3;           // 売上比(3ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3] = prevYearCpWork.ThisTermGross3;     // 粗利額(当期3ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3] = prevYearCpWork.FirstTermGross3;   // 粗利額(前期3ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio3] = prevYearCpWork.GrossRatio3;           // 粗利比(3ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4] = prevYearCpWork.ThisTermSales4;     // 売上額(当期4ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4] = prevYearCpWork.FirstTermSales4;   // 売上額(前期4ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio4] = prevYearCpWork.SalesRatio4;           // 売上比(4ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4] = prevYearCpWork.ThisTermGross4;     // 粗利額(当期4ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4] = prevYearCpWork.FirstTermGross4;   // 粗利額(前期4ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio4] = prevYearCpWork.GrossRatio4;           // 粗利比(4ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5] = prevYearCpWork.ThisTermSales5;     // 売上額(当期5ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5] = prevYearCpWork.FirstTermSales5;   // 売上額(前期5ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio5] = prevYearCpWork.SalesRatio5;           // 売上比(5ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5] = prevYearCpWork.ThisTermGross5;     // 粗利額(当期5ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5] = prevYearCpWork.FirstTermGross5;   // 粗利額(前期5ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio5] = prevYearCpWork.GrossRatio5;           // 粗利比(5ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6] = prevYearCpWork.ThisTermSales6;     // 売上額(当期6ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6] = prevYearCpWork.FirstTermSales6;   // 売上額(前期6ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio6] = prevYearCpWork.SalesRatio6;           // 売上比(6ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6] = prevYearCpWork.ThisTermGross6;     // 粗利額(当期6ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6] = prevYearCpWork.FirstTermGross6;   // 粗利額(前期6ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio6] = prevYearCpWork.GrossRatio6;           // 粗利比(6ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7] = prevYearCpWork.ThisTermSales7;     // 売上額(当期7ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7] = prevYearCpWork.FirstTermSales7;   // 売上額(前期7ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio7] = prevYearCpWork.SalesRatio7;           // 売上比(7ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7] = prevYearCpWork.ThisTermGross7;     // 粗利額(当期7ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7] = prevYearCpWork.FirstTermGross7;   // 粗利額(前期7ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio7] = prevYearCpWork.GrossRatio7;           // 粗利比(7ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8] = prevYearCpWork.ThisTermSales8;     // 売上額(当期8ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8] = prevYearCpWork.FirstTermSales8;   // 売上額(前期8ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio8] = prevYearCpWork.SalesRatio8;           // 売上比(8ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8] = prevYearCpWork.ThisTermGross8;     // 粗利額(当期8ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8] = prevYearCpWork.FirstTermGross8;   // 粗利額(前期8ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio8] = prevYearCpWork.GrossRatio8;           // 粗利比(8ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9] = prevYearCpWork.ThisTermSales9;     // 売上額(当期9ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9] = prevYearCpWork.FirstTermSales9;   // 売上額(前期9ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio9] = prevYearCpWork.SalesRatio9;           // 売上比(9ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9] = prevYearCpWork.ThisTermGross9;     // 粗利額(当期9ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9] = prevYearCpWork.FirstTermGross9;   // 粗利額(前期9ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio9] = prevYearCpWork.GrossRatio9;           // 粗利比(9ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10] = prevYearCpWork.ThisTermSales10;     // 売上額(当期10ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10] = prevYearCpWork.FirstTermSales10;   // 売上額(前期10ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio10] = prevYearCpWork.SalesRatio10;           // 売上比(10ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10] = prevYearCpWork.ThisTermGross10;     // 粗利額(当期10ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10] = prevYearCpWork.FirstTermGross10;   // 粗利額(前期10ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio10] = prevYearCpWork.GrossRatio10;           // 粗利比(10ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11] = prevYearCpWork.ThisTermSales11;     // 売上額(当期11ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11] = prevYearCpWork.FirstTermSales11;   // 売上額(前期11ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio11] = prevYearCpWork.SalesRatio11;           // 売上比(11ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11] = prevYearCpWork.ThisTermGross11;     // 粗利額(当期11ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11] = prevYearCpWork.FirstTermGross11;   // 粗利額(前期11ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio11] = prevYearCpWork.GrossRatio11;           // 粗利比(11ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12] = prevYearCpWork.ThisTermSales12;     // 売上額(当期12ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12] = prevYearCpWork.FirstTermSales12;   // 売上額(前期12ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio12] = prevYearCpWork.SalesRatio12;           // 売上比(12ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12] = prevYearCpWork.ThisTermGross12;     // 粗利額(当期12ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12] = prevYearCpWork.FirstTermGross12;   // 粗利額(前期12ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio12] = prevYearCpWork.GrossRatio12;           // 粗利比(12ヶ月目)    (Double)
            //TODO 以下自分で設定する項目
            // 当期合計売上額    (Int64)
            long _thisTermTotalSales = prevYearCpWork.ThisTermSales1 + prevYearCpWork.ThisTermSales2 + prevYearCpWork.ThisTermSales3 + prevYearCpWork.ThisTermSales4
                                        + prevYearCpWork.ThisTermSales5 + prevYearCpWork.ThisTermSales6 + prevYearCpWork.ThisTermSales7 + prevYearCpWork.ThisTermSales8
                                        + prevYearCpWork.ThisTermSales9 + prevYearCpWork.ThisTermSales10 + prevYearCpWork.ThisTermSales11 + prevYearCpWork.ThisTermSales12;
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = _thisTermTotalSales;

            // 前期合計売上額    (Int64)
            long _firstTermTotalSales = prevYearCpWork.FirstTermSales1 + prevYearCpWork.FirstTermSales2 + prevYearCpWork.FirstTermSales3 + prevYearCpWork.FirstTermSales4
                                                            + prevYearCpWork.FirstTermSales5 + prevYearCpWork.FirstTermSales6 + prevYearCpWork.FirstTermSales7 + prevYearCpWork.FirstTermSales8
                                                            + prevYearCpWork.FirstTermSales9 + prevYearCpWork.FirstTermSales10 + prevYearCpWork.FirstTermSales11 + prevYearCpWork.FirstTermSales12;
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = _firstTermTotalSales;

            // 年計売上比    (Double)
            if (_firstTermTotalSales != 0)
            {
                Double d_thisTermTotalSales = Convert.ToDouble(_thisTermTotalSales) * 100;
                Double d_firstTermTotalSales = Convert.ToDouble(_firstTermTotalSales);

                Double _totalSalesRatio = Math.Round((d_thisTermTotalSales / d_firstTermTotalSales), 4);	//小数点第五位を丸め
                dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = Math.Round(_totalSalesRatio, 2, MidpointRounding.AwayFromZero);//小数点第三位を四捨五入
            }
            else
            {
                dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = 0;
            }
            // 当期合計粗利額    (Int64)
            long _thisTermTotalGross = prevYearCpWork.ThisTermGross1 + prevYearCpWork.ThisTermGross2 + prevYearCpWork.ThisTermGross3 + prevYearCpWork.ThisTermGross4
                                        + prevYearCpWork.ThisTermGross5 + prevYearCpWork.ThisTermGross6 + prevYearCpWork.ThisTermGross7 + prevYearCpWork.ThisTermGross8
                                        + prevYearCpWork.ThisTermGross9 + prevYearCpWork.ThisTermGross10 + prevYearCpWork.ThisTermGross11 + prevYearCpWork.ThisTermGross12;
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalGross] = _thisTermTotalGross;

            // 前期合計粗利額    (Int64)
            long _firstTermTotalGross = prevYearCpWork.FirstTermGross1 + prevYearCpWork.FirstTermGross2 + prevYearCpWork.FirstTermGross3 + prevYearCpWork.FirstTermGross4
                                        + prevYearCpWork.FirstTermGross5 + prevYearCpWork.FirstTermGross6 + prevYearCpWork.FirstTermGross7 + prevYearCpWork.FirstTermGross8
                                        + prevYearCpWork.FirstTermGross9 + prevYearCpWork.FirstTermGross10 + prevYearCpWork.FirstTermGross11 + prevYearCpWork.FirstTermGross12;
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = _firstTermTotalGross;

            // 年計粗利比    (Double)
            if (_firstTermTotalGross != 0)
            {
                Double d_thisTermTotalGross = Convert.ToDouble(_thisTermTotalGross * 100);
                Double d_firstTermTotalGross = Convert.ToDouble(_firstTermTotalGross);

                Double _totalGrossRatio = Math.Round((d_thisTermTotalGross / _firstTermTotalGross), 4);		//小数点第五位を丸め
                dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = Math.Round(_totalGrossRatio, 2, MidpointRounding.AwayFromZero); //小数点第三位を四捨五入
            }
            else
            {
                dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = 0;
            }
          */
        }

        /// <summary>
        /// データRow作成（合計値算出)
        /// </summary>
        /// <param name="dr"></param>
        /// <remarks>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47029 比率算出不正の障害対応</br>
        /// </remarks> 
        private void SetTebleRowFromRetListSum(ref DataRow dr)
        {
            //TODO 以下自分で設定する項目
            // 当期合計売上額    (Int64)
            long _thisTermTotalSales = Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12].ToString());
            //dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = _thisTermTotalSales;                        //DEL 2009/01/30 不具合対応[9844]
            //dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = this.SetMoneyUnit(_thisTermTotalSales);       //ADD 2009/01/30 不具合対応[9844]     // DEL 2009/04/16
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = _thisTermTotalSales;          // ADD 2009/04/16         
            
            // 前期合計売上額    (Int64)
            long _firstTermTotalSales = Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12].ToString());
            //dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = _firstTermTotalSales;                      //DEL 2009/01/30 不具合対応[9844]
            //dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = this.SetMoneyUnit(_firstTermTotalSales);     //ADD 2009/01/30 不具合対応[9844]     // DEL 2009/04/16
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = _firstTermTotalSales;        // ADD 2009/04/16

            // 年計売上比    (Double)
            //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の障害対応---------->>>>>
            //if (_firstTermTotalSales != 0)
            //{
            //    Double d_thisTermTotalSales = Convert.ToDouble(_thisTermTotalSales) * 100;
            //    Double d_firstTermTotalSales = Convert.ToDouble(_firstTermTotalSales);

            //    Double _totalSalesRatio = Math.Round((d_thisTermTotalSales / d_firstTermTotalSales), 4);	//小数点第五位を丸め 
            //    dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = Math.Round(_totalSalesRatio, 2, MidpointRounding.AwayFromZero);//小数点第三位を四捨五入

            //}
            //else
            //{
            //    dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = 0;
            //}
            //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の障害対応----------<<<<<
            dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = GetRatio(_thisTermTotalSales, _firstTermTotalSales); // ADD cheq 2015/08/17 RedMine#47029 比率算出不正の障害対応

            // 当期合計粗利額    (Int64)
            long _thisTermTotalGross = Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12].ToString());
            //dr[DCTOK02094EA.CT_PrevYear_thisTermTotalGross] = _thisTermTotalGross;                        //DEL 2009/01/30 不具合対応[9844]
            //dr[DCTOK02094EA.CT_PrevYear_thisTermTotalGross] = this.SetMoneyUnit(_thisTermTotalGross);       //ADD 2009/01/30 不具合対応[9844]     // DEL 2009/04/16
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalGross] = _thisTermTotalGross;          // ADD 2009/04/16

            // 前期合計粗利額    (Int64)
            long _firstTermTotalGross = Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11].ToString()) +
                                        Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12].ToString());
            //dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = _firstTermTotalGross;                      //DEL 2009/01/30 不具合対応[9844]
            //dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = this.SetMoneyUnit(_firstTermTotalGross);     //ADD 2009/01/30 不具合対応[9844]     // DEL 2009/04/16
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = _firstTermTotalGross;        // ADD 2009/04/16

            // 年計粗利比    (Double)
            //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の障害対応---------->>>>>
            //if (_firstTermTotalGross != 0)
            //{
            //    Double d_thisTermTotalGross = Convert.ToDouble(_thisTermTotalGross * 100);
            //    Double d_firstTermTotalGross = Convert.ToDouble(_firstTermTotalGross);

            //    Double _totalGrossRatio = Math.Round((d_thisTermTotalGross / _firstTermTotalGross), 4);		//小数点第五位を丸め
            //    dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = Math.Round(_totalGrossRatio, 2, MidpointRounding.AwayFromZero); //小数点第三位を四捨五入
            //}
            //else
            //{
            //    dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = 0;
            //}
            //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の障害対応----------<<<<<
            dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = GetRatio(_thisTermTotalGross, _firstTermTotalGross); // ADD cheq 2015/08/17 RedMine#47029 比率算出不正の障害対応

            // DEL 2009/04/16 ------>>>
            //// ---ADD 2009/01/30 不具合対応[9844] ---------------------------------------------------------------------------------------->>>>>
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1]);     // 売上額(当期1ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1]);   // 売上額(前期1ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1]);     // 粗利額(当期1ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1]);   // 粗利額(前期1ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2]);     // 売上額(当期2ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2]);   // 売上額(前期2ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2]);     // 粗利額(当期2ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2]);   // 粗利額(前期2ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3]);     // 売上額(当期3ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3]);   // 売上額(前期3ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3]);     // 粗利額(当期3ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3]);   // 粗利額(前期3ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4]);     // 売上額(当期4ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4]);   // 売上額(前期4ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4]);     // 粗利額(当期4ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4]);   // 粗利額(前期4ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5]);     // 売上額(当期5ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5]);   // 売上額(前期5ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5]);     // 粗利額(当期5ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5]);   // 粗利額(前期5ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6]);     // 売上額(当期6ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6]);   // 売上額(前期6ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6]);     // 粗利額(当期6ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6]);   // 粗利額(前期6ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7]);     // 売上額(当期7ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7]);   // 売上額(前期7ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7]);     // 粗利額(当期7ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7]);   // 粗利額(前期7ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8]);     // 売上額(当期8ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8]);   // 売上額(前期8ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8]);     // 粗利額(当期8ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8]);   // 粗利額(前期8ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9]);     // 売上額(当期9ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9]);   // 売上額(前期9ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9]);     // 粗利額(当期9ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9]);   // 粗利額(前期9ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10]);     // 売上額(当期10ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10]);   // 売上額(前期10ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10]);     // 粗利額(当期10ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10]);   // 粗利額(前期10ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11]);     // 売上額(当期11ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11]);   // 売上額(前期11ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11]);     // 粗利額(当期11ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11]);   // 粗利額(前期11ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12]);     // 売上額(当期12ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12]);   // 売上額(前期12ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12]);     // 粗利額(当期12ヶ月目)(Int64)
            //dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12] = this.SetMoneyUnit(dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12]);   // 粗利額(前期12ヶ月目)(Int64)
            //// ---ADD 2009/01/30 不具合対応[9844] ----------------------------------------------------------------------------------------<<<<<
            // DEL 2009/04/16 ------<<<
        }
        // ---ADD 2009/01/30 不具合対応[9844] --------------------------------->>>>>
        private Int64 SetMoneyUnit(object value)
        {
            Int64 result = 0;
            try
            {
                result = Int64.Parse(value.ToString());
            }
            catch
            {
                return 0;
            }

            return SetMoneyUnit(result);
        }
        private Int64 SetMoneyUnit(Int64 value)
        {
            Int64 result = 0;
            int moneyUnitValue = 0;
            if (this._moneyUnit == 0)
            {
                moneyUnitValue = 1;
            }
            else
            {
                moneyUnitValue = 1000;
            }

            try
            {
                result = (Int64)Math.Floor((Double)(value / moneyUnitValue));
            }
            catch
            {
                return 0;
            }

            return result;
        }
        // ---ADD 2009/01/30 不具合対応[9844] ---------------------------------<<<<<

        /// <summary>
        /// データRow作成
        /// </summary>
        /// <param name="dr">セット対象DataRow</param>
        /// <param name="sourceDataRow">セット元DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            dr[DCTOK02094EA.CT_PrevYear_AddUpSecCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_AddUpSecCode];		  // 計上拠点コード(string)
            dr[DCTOK02094EA.CT_PrevYear_SectionGuidNm] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SectionGuidNm];		  // 拠点ガイド名称     (string)
            dr[DCTOK02094EA.CT_PrevYear_EmployeeCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_EmployeeCode];         // 従業員コード  (string)
            dr[DCTOK02094EA.CT_PrevYear_EmployeeName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_EmployeeName];         // 従業員名称    (string)
            dr[DCTOK02094EA.CT_PrevYear_CustomerCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_CustomerCode];         // 得意先コード  (Int32)
            dr[DCTOK02094EA.CT_PrevYear_CustomerSnm] = sourceDataRow[DCTOK02094EA.CT_PrevYear_CustomerSnm];           // 得意先略称    (string)
            dr[DCTOK02094EA.CT_PrevYear_BusinessTypeCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BusinessTypeCode]; // 業種コード    (Int32)
            dr[DCTOK02094EA.CT_PrevYear_BusinessTypeName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BusinessTypeName]; // 業種名称		(string)
            dr[DCTOK02094EA.CT_PrevYear_SalesAreaCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesAreaCode];       // 販売エリアコード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_SalesAreaName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesAreaName];		  // 販売エリア名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_BLGoodsCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BLGoodsCode];           // BLコード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BLGoodsHalfName];	　// BL名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_GoodsLGroup] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GoodsLGroup];           // 商品大分類コード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_GoodsLGroupName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GoodsLGroupName];	　// 商品大分類名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_GoodsMGroup] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GoodsMGroup];           // 商品中分類コード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_GoodsMGroupName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GoodsMGroupName];	　// 商品中分類名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_BLGroupCode] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BLGroupCode];           // グループコード(Int32)
            dr[DCTOK02094EA.CT_PrevYear_BLGroupKanaName] = sourceDataRow[DCTOK02094EA.CT_PrevYear_BLGroupKanaName];	　// グループ名称  (string)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales1];     // 売上額(当期1ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales1];   // 売上額(前期1ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio1];           // 売上比(1ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross1];     // 粗利額(当期1ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross1];   // 粗利額(前期1ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio1] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio1];           // 粗利比(1ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales2];     // 売上額(当期2ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales2];   // 売上額(前期2ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio2];           // 売上比(2ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross2];     // 粗利額(当期2ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross2];   // 粗利額(前期2ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio2] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio2];           // 粗利比(2ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales3];     // 売上額(当期3ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales3];   // 売上額(前期3ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio3];           // 売上比(3ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross3];     // 粗利額(当期3ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross3];   // 粗利額(前期3ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio3] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio3];           // 粗利比(3ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales4];     // 売上額(当期4ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales4];   // 売上額(前期4ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio4];           // 売上比(4ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross4];     // 粗利額(当期4ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross4];   // 粗利額(前期4ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio4] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio4];           // 粗利比(4ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales5];     // 売上額(当期5ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales5];   // 売上額(前期5ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio5];           // 売上比(5ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross5];     // 粗利額(当期5ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross5];   // 粗利額(前期5ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio5] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio5];           // 粗利比(5ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales6];     // 売上額(当期6ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales6];   // 売上額(前期6ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio6];           // 売上比(6ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross6];     // 粗利額(当期6ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross6];   // 粗利額(前期6ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio6] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio6];           // 粗利比(6ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales7];     // 売上額(当期7ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales7];   // 売上額(前期7ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio7];           // 売上比(7ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross7];     // 粗利額(当期7ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross7];   // 粗利額(前期7ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio7] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio7];           // 粗利比(7ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales8];     // 売上額(当期8ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales8];   // 売上額(前期8ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio8];           // 売上比(8ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross8];     // 粗利額(当期8ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross8];   // 粗利額(前期8ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio8] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio8];           // 粗利比(8ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales9];     // 売上額(当期9ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales9];   // 売上額(前期9ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio9];           // 売上比(9ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross9];     // 粗利額(当期9ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross9];   // 粗利額(前期9ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio9] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio9];           // 粗利比(9ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales10];     // 売上額(当期10ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales10];   // 売上額(前期10ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio10];           // 売上比(10ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross10];     // 粗利額(当期10ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross10];   // 粗利額(前期10ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio10] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio10];           // 粗利比(10ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales11];     // 売上額(当期11ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales11];   // 売上額(前期11ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio11];           // 売上比(11ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross11];     // 粗利額(当期11ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross11];   // 粗利額(前期11ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio11] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio11];           // 粗利比(11ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermSales12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermSales12];     // 売上額(当期12ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermSales12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermSales12];   // 売上額(前期12ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_SalesRatio12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_SalesRatio12];           // 売上比(12ヶ月目)    (Double)
            dr[DCTOK02094EA.CT_PrevYear_ThisTermGross12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_ThisTermGross12];     // 粗利額(当期12ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_FirstTermGross12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_FirstTermGross12];   // 粗利額(前期12ヶ月目)(Int64)
            dr[DCTOK02094EA.CT_PrevYear_GrossRatio12] = sourceDataRow[DCTOK02094EA.CT_PrevYear_GrossRatio12];           // 粗利比(12ヶ月目)    (Double)
            //TODO 以下自分で計算する項目
            dr[DCTOK02094EA.CT_PrevYear_thisTermTotalSales] = sourceDataRow[DCTOK02094EA.CT_PrevYear_thisTermTotalSales];	// 当期合計売上額    (Int64)
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalSales] = sourceDataRow[DCTOK02094EA.CT_PrevYear_firstTermTotalSales];	// 前期合計売上額    (Int64)
            dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = sourceDataRow[DCTOK02094EA.CT_PrevYear_totalSalesRatio];			// 年計売上比    (Double)
            dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio] = sourceDataRow[DCTOK02094EA.CT_PrevYear_totalSalesRatio];			// 当期合計粗利額    (Int64)
            dr[DCTOK02094EA.CT_PrevYear_firstTermTotalGross] = sourceDataRow[DCTOK02094EA.CT_PrevYear_firstTermTotalGross];	// 前期合計粗利額    (Int64)
            dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio] = sourceDataRow[DCTOK02094EA.CT_PrevYear_totalGrossRatio];			// 年計粗利比    (Double)
        }

        /// <summary>
        /// 拠点制御アクセスクラスインスタンス化処理
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ログイン担当拠点情報の取得
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// 率算出
        /// </summary>
        /// <param name="ThisVal"></param>
        /// <param name="FirstVal"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47029 比率算出不正の障害対応</br>
        /// </remarks>
        private Double GetRatio(long ThisVal, long FirstVal)
        {
            Double rtnval = 0;

            if (FirstVal == 0)
            {
                return rtnval;
            }

            //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の障害対応---------->>>>>
            //Double d_thisTermTotalSales = Convert.ToDouble(ThisVal) * 100;
            //Double d_firstTermTotalSales = Convert.ToDouble(FirstVal);

            //Double _totalSalesRatio = Math.Round((d_thisTermTotalSales / d_firstTermTotalSales), 4);	//小数点第五位を丸め
            //rtnval = Math.Round(_totalSalesRatio, 2, MidpointRounding.AwayFromZero);//小数点第三位を四捨五入
            //-----DEL cheq 2015/08/17 for Redmine#47029 比率算出不正の障害対応----------<<<<<

            //---ADD cheq 2015/08/17 RedMine#47029 比率算出不正の障害対応---------->>>>>
            decimal d_thisTermTotalSales = ThisVal * 100;
            decimal d_firstTermTotalSales = FirstVal;

            decimal _totalSalesRatio = d_thisTermTotalSales / d_firstTermTotalSales;
            decimal d_rtnval = Math.Round(_totalSalesRatio, 2, MidpointRounding.AwayFromZero);//小数点第三位を四捨五入
            rtnval = Convert.ToDouble(d_rtnval);
            //---ADD cheq 2015/08/17 RedMine#47029 比率算出不正の障害対応----------<<<<<

            return rtnval;
        }

        /// <summary>
        /// 比率条件チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Update Note : 2015/08/17 cheq </br>
        /// <br>管理番号    : 11170129-00</br>
        /// <br>            : redmine#47029 前年対対表エラーが発生する障害対応</br>
        /// </remarks>
        private void CheckVal(ExtrInfo_DCTOK02093E PrYearCpListCndtn)
        {            
            int index = 0;
            bool ckflg = false;
            string SalesFild = "";
            string GrossFild = "";

            #region 対象フィールド設定
            // -----DEL cheq 2015/08/17 for Redmine#47029 前年対対表エラーが発生するの対応---------->>>>>
            //for (int i = 0; i < 12; i++)
            //{
            //    if (Int32.Parse(this._monthArray[i].ToString()) == 0)
            //    {
            //        index = i;
            //        break;
            //    }
            //}
            // -----DEL cheq 2015/08/17 for Redmine#47029 前年対対表エラーが発生するの対応----------<<<<<
            // -----ADD cheq 2015/08/17 for Redmine#47029 前年対対表エラーが発生するの対応---------->>>>>
            for (int i = 0; i < this._monthArray.Length; i++)
            {
                if (Int32.Parse(this._monthArray[i].ToString()) != 0)
                {
                    index++;
                }
            }
            // -----ADD cheq 2015/08/17 for Redmine#47029 前年対対表エラーが発生するの対応----------<<<<<
            switch (index)
            {
                case 1:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio1;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio1;
                    break;
                case 2:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio2;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio2;
                    break;
                case 3:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio3;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio3;
                    break;
                case 4:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio4;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio4;
                    break;
                case 5:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio5;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio5;
                    break;
                case 6:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio6;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio6;
                    break;
                case 7:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio7;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio7;
                    break;
                case 8:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio8;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio8;
                    break;
                case 9:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio9;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio9;
                    break;
                case 10:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio10;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio10;
                    break;
                case 11:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio11;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio11;
                    break;
                case 12:
                    SalesFild = DCTOK02094EA.CT_PrevYear_SalesRatio12;
                    GrossFild = DCTOK02094EA.CT_PrevYear_GrossRatio12;
                    break;
            }
            #endregion

            for (int i = 0; i < this._printDataSet.Tables[_PrevYearCpDataTable].Rows.Count; i++)
            {
                DataRow dr;

                dr = this._printDataSet.Tables[_PrevYearCpDataTable].Rows[i];
                ckflg = false;
                //当月純売上(開始)
                if (PrYearCpListCndtn.St_MonthSalesRatio_ck == true)
                {
                    //if (Int64.Parse(dr[SalesFild].ToString()) < PrYearCpListCndtn.St_MonthSalesRatio)         //DEL 2009/01/29 不具合対応[9849]
                    if (Double.Parse(dr[SalesFild].ToString()) < PrYearCpListCndtn.St_MonthSalesRatio)          //ADD 2009/01/29 不具合対応[9849]
                    {
                        ckflg = true;
                    }
                }
                //当月純売上(終了)
                if (PrYearCpListCndtn.Ed_MonthSalesRatio_ck == true)
                {
                    //if (Int64.Parse(dr[SalesFild].ToString()) > PrYearCpListCndtn.Ed_MonthSalesRatio)         //DEL 2009/01/29 不具合対応[9849]
                    if (Double.Parse(dr[SalesFild].ToString()) > PrYearCpListCndtn.Ed_MonthSalesRatio)          //ADD 2009/01/29 不具合対応[9849]
                    {
                        ckflg = true;
                    }
                }
                //当年純売上(開始)
                if (PrYearCpListCndtn.St_YearSalesRatio_ck == true)
                {
                    //if (Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio].ToString()) < PrYearCpListCndtn.St_YearSalesRatio)   //DEL 2009/01/29 不具合対応[9849]
                    if (Double.Parse(dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio].ToString()) < PrYearCpListCndtn.St_YearSalesRatio)    //ADD 2009/01/29 不具合対応[9849]
                    {
                        ckflg = true;
                    }
                }
                //当年純売上(終了)
                if (PrYearCpListCndtn.Ed_YearSalesRatio_ck == true)
                {
                    //if (Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio].ToString()) > PrYearCpListCndtn.Ed_YearSalesRatio)   //DEL 2009/01/29 不具合対応[9849]
                    if (Double.Parse(dr[DCTOK02094EA.CT_PrevYear_totalSalesRatio].ToString()) > PrYearCpListCndtn.Ed_YearSalesRatio)    //ADD 2009/01/29 不具合対応[9849]
                    {
                        ckflg = true;
                    }
                }
                //当月粗利(開始)
                if (PrYearCpListCndtn.St_MonthGrossRatio_ck == true)
                {
                    //if (Int64.Parse(dr[GrossFild].ToString()) < PrYearCpListCndtn.St_MonthGrossRatio)         //DEL 2009/01/29 不具合対応[9849]
                    if (Double.Parse(dr[GrossFild].ToString()) < PrYearCpListCndtn.St_MonthGrossRatio)          //ADD 2009/01/29 不具合対応[9849]
                    {
                        ckflg = true;
                    }
                }
                //当月粗利(終了)
                if (PrYearCpListCndtn.Ed_MonthGrossRatio_ck == true)
                {
                    //if (Int64.Parse(dr[GrossFild].ToString()) > PrYearCpListCndtn.Ed_MonthGrossRatio)         //DEL 2009/01/29 不具合対応[9849]
                    if (Double.Parse(dr[GrossFild].ToString()) > PrYearCpListCndtn.Ed_MonthGrossRatio)          //ADD 2009/01/29 不具合対応[9849]
                    {
                        ckflg = true;
                    }
                }
                //当年粗利(開始)
                if (PrYearCpListCndtn.St_YearGrossRatio_ck == true)
                {
                    //if (Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio].ToString()) < PrYearCpListCndtn.St_YearGrossRatio)   //DEL 2009/01/29 不具合対応[9849]
                    if (Double.Parse(dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio].ToString()) < PrYearCpListCndtn.St_YearGrossRatio)    //ADD 2009/01/29 不具合対応[9849]
                    {
                        ckflg = true;
                    }
                }
                //当年粗利(終了)
                if (PrYearCpListCndtn.Ed_YearGrossRatio_ck == true)
                {
                    //if (Int64.Parse(dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio].ToString()) > PrYearCpListCndtn.St_YearGrossRatio)   //DEL 2009/01/29 不具合対応[9849]
                    if (Double.Parse(dr[DCTOK02094EA.CT_PrevYear_totalGrossRatio].ToString()) > PrYearCpListCndtn.Ed_YearGrossRatio)    //ADD 2009/01/29 不具合対応[9849]
                    {
                        ckflg = true;
                    }
                }

                // 対象外データの場合、削除
                if (ckflg == true)
                {
                    dr.Delete();
                    i = i - 1;
                }

            }
        }
        #endregion
    }
}
