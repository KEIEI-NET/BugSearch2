//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 売上データ送信ログテーブルに対して検索処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2019/12/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller.Agent;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信ログ表示のアクセスクラスです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    /// </remarks>
    public class SalCprtSndLogListResultAcs
    {
        #region ■ Private Members ■
        // 売上データ送信ログデータセット
        private SalCprtSndLogListResultDataSet _salCprtSndLogListResultDataSet;
        // 売上データ送信ログデータテーブル
        private SalCprtSndLogListResultDataSet.SalCprtSndLogListResultDataTable _salCprtSndLogListResultDataTable;
        private ISalCprtSndLogDB _iSalCprtSndLogDB;
        private static SalCprtSndLogListResultAcs _salCprtSndLogListResultAcs;
        /// <summary>拠点マスタDB</summary>
        private SecInfoSetAcsAgent _sectionInfoDB;
        #endregion ■ Private Members ■

        #region ■ Properties ■

        /// <summary>
        /// 売上データ送信ログデータテーブルプロパティ
        /// </summary>
        public SalCprtSndLogListResultDataSet.SalCprtSndLogListResultDataTable SalCprtSndLogListResultDataTable
        {
            get { return _salCprtSndLogListResultDataTable; }
        }
        #endregion ■ Properties ■

        # region ■ Constructor ■
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private SalCprtSndLogListResultAcs()
        {
            // 変数初期化
            this._salCprtSndLogListResultDataSet = new SalCprtSndLogListResultDataSet();
            this._salCprtSndLogListResultDataTable = this._salCprtSndLogListResultDataSet.SalCprtSndLogListResult;
            this._iSalCprtSndLogDB = MediationSalCprtSndLogDB.GetSalCprtSndLogDB();
            this._sectionInfoDB = new SecInfoSetAcsAgent();
        }
        # endregion ■ Constructor ■

        /// <summary>
        /// 売上データ送信ログテーブルのログ情報処理を行う
        /// </summary>
        /// <param name="salCprtSndLogListResultSearchPara">売上データ送信ログ抽出条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上データ送信ログ取得処理を行う。</br>      
        /// <br>Programmer : 田建委</br>                                  
        /// <br>Date       : 2019/12/02</br> 
        /// <br>UpdateNote : 2013/08/12 田建委</br>
        /// <br>           : Redmine#39695 抽出結果無時のログ内容の変更対応</br>
        /// </remarks>
        public int SearchSalCprtSndLog(ref object salCprtSndLogListResultSearchPara, ConstantManagement.LogicalMode logicalMode)
        {
            ArrayList outSalCprtSndLogListResultList = new ArrayList();
            object outObj = outSalCprtSndLogListResultList as object;

            string errMessage = string.Empty;
            int status = this._iSalCprtSndLogDB.SearchSalCprtSndLog(out outObj, out errMessage, ref salCprtSndLogListResultSearchPara, logicalMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                outSalCprtSndLogListResultList = (ArrayList)outObj;
                Dictionary<string, string> sectionNameMap = new Dictionary<string, string>();

                this._salCprtSndLogListResultDataTable.Clear();
                this._salCprtSndLogListResultDataTable.BeginLoadData();
                try
                {
                    foreach (SalCprtSndLogListResultWork salCprtSndLogListResult in outSalCprtSndLogListResultList)
                    {
                        SalCprtSndLogListResultDataSet.SalCprtSndLogListResultRow salCprtSndLogListResultRow = this._salCprtSndLogListResultDataTable.NewSalCprtSndLogListResultRow();
                        salCprtSndLogListResultRow.SectionCode = salCprtSndLogListResult.SectionCode; // 拠点コード
                        // 拠点名称
                        if (!sectionNameMap.ContainsKey(salCprtSndLogListResult.SectionCode))
                        {
                            sectionNameMap.Add(salCprtSndLogListResult.SectionCode, _sectionInfoDB.GetSectionName(salCprtSndLogListResult.SectionCode));
                        }
                        salCprtSndLogListResultRow.SectionName = sectionNameMap[salCprtSndLogListResult.SectionCode];
                        salCprtSndLogListResultRow.SAndEAutoSendDiv = salCprtSndLogListResult.SAndEAutoSendDiv;
                        // 0:手動,1:自動
                        switch (salCprtSndLogListResult.SAndEAutoSendDiv)
                        {
                            case 0:
                                salCprtSndLogListResultRow.SAndEAutoSendDivName = "手動";
                                break;
                            case 1:
                                salCprtSndLogListResultRow.SAndEAutoSendDivName = "自動";
                                break;
                            default:
                                salCprtSndLogListResultRow.SAndEAutoSendDivName = string.Empty;
                                break;
                        }

                        DateTime sendDateTimeStart = DateTime.MinValue;
                        DateTime sendDateTimeEnd = DateTime.MinValue;
                        DateTime sendObjDateStart = DateTime.MinValue;
                        DateTime sendObjDateEnd = DateTime.MinValue;
                        if (DateTime.TryParseExact(salCprtSndLogListResult.SendDateTimeStart.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendDateTimeStart))
                        {
                            salCprtSndLogListResultRow.SendDateTimeStart = sendDateTimeStart.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            salCprtSndLogListResultRow.SendDateTimeStart = string.Empty;
                        }
                        if (DateTime.TryParseExact(salCprtSndLogListResult.SendDateTimeEnd.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendDateTimeEnd))
                        {
                            salCprtSndLogListResultRow.SendDateTimeEnd = sendDateTimeEnd.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            salCprtSndLogListResultRow.SendDateTimeEnd = string.Empty;
                        }
                        if (DateTime.TryParseExact(salCprtSndLogListResult.SendObjDateStart.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendObjDateStart))
                        {
                            salCprtSndLogListResultRow.SendObjDateStart = sendObjDateStart.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            salCprtSndLogListResultRow.SendObjDateStart = string.Empty;
                        }
                        if (DateTime.TryParseExact(salCprtSndLogListResult.SendObjDateEnd.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendObjDateEnd))
                        {
                            salCprtSndLogListResultRow.SendObjDateEnd = sendObjDateEnd.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            salCprtSndLogListResultRow.SendObjDateEnd = string.Empty;
                        }
                        salCprtSndLogListResultRow.SendObjCustStart = salCprtSndLogListResult.SendObjCustStart;
                        salCprtSndLogListResultRow.SendObjCustEnd = salCprtSndLogListResult.SendObjCustEnd;
                        salCprtSndLogListResultRow.SendObjDiv = salCprtSndLogListResult.SendObjDiv;
                        // 0:未送信,1:送信済,2：全て
                        switch (salCprtSndLogListResult.SendObjDiv)
                        {
                            case 0:
                                salCprtSndLogListResultRow.SendObjDivName = "未送信";
                                break;
                            case 1:
                                salCprtSndLogListResultRow.SendObjDivName = "送信済";
                                break;
                            case 2:
                                salCprtSndLogListResultRow.SendObjDivName = "全て";
                                break;
                            default:
                                salCprtSndLogListResultRow.SendObjDivName = string.Empty;
                                break;
                        }
                        salCprtSndLogListResultRow.SendResults = salCprtSndLogListResult.SendResults;
                        // 0:正常完了,1：失敗
                        switch (salCprtSndLogListResult.SendResults)
                        {
                            case 0:
                                salCprtSndLogListResultRow.SendResultsName = "正常完了";
                                break;
                            case 1:
                                salCprtSndLogListResultRow.SendResultsName = "失敗";
                                break;
                            //----- ADD 田建委 2013/08/12 Redmine#39695 ----->>>>>
                            case 2:
                                salCprtSndLogListResultRow.SendResultsName = "送信対象なし";
                                break;
                            //----- ADD 田建委 2013/08/12 Redmine#39695 -----<<<<<
                            default:
                                salCprtSndLogListResultRow.SendResultsName = string.Empty;
                                break;
                        }
                        salCprtSndLogListResultRow.SendSlipCount = salCprtSndLogListResult.SendSlipCount; // 送信伝票枚数
                        salCprtSndLogListResultRow.SendSlipDtlCnt = salCprtSndLogListResult.SendSlipDtlCnt; // 送信伝票明細数
                        salCprtSndLogListResultRow.SendSlipTotalMny = salCprtSndLogListResult.SendSlipTotalMny; // 送信伝票合計金額
                        salCprtSndLogListResultRow.SendErrorContents = salCprtSndLogListResult.SendErrorContents; // 送信エラー内容

                        this._salCprtSndLogListResultDataTable.Rows.Add(salCprtSndLogListResultRow);
                    }
                }
                finally
                {
                    this._salCprtSndLogListResultDataTable.EndLoadData();
                }
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this._salCprtSndLogListResultDataTable.Clear();
                return status;
            }
            else
            {
                return status;
            }
        }

        /// <summary>
        /// 売上データ送信ログテーブルのログ情報を削除する
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上データ送信ログテーブルのログ情報を削除処理を行う。</br>      
        /// <br>Programmer : 田建委</br>                                  
        /// <br>Date       : 2019/12/02</br> 
        /// </remarks>
        public int ResetSalCprtSndLog(out string errMessage, string enterpriseCode)
        {
            errMessage = string.Empty;

            int status = this._iSalCprtSndLogDB.ResetSalCprtSndLog(out errMessage, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._salCprtSndLogListResultDataTable.Clear();
            }

            return status;
        }

        # region ■ 売上データ送信ログアクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// 売上データ送信ログアクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データ送信ログ取得処理を行う。</br>      
        /// <br>Programmer : 田建委</br>                                  
        /// <br>Date       : 2019/12/02</br> 
        /// </remarks>
        public static SalCprtSndLogListResultAcs GetInstance()
        {
            if (_salCprtSndLogListResultAcs == null)
            {
                _salCprtSndLogListResultAcs = new SalCprtSndLogListResultAcs();
            }

            return _salCprtSndLogListResultAcs;
        }
        # endregion ■ 売上データ送信ログアクセスクラス インスタンス取得処理 ■
    }
}
