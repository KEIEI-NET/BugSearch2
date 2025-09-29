//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 売上データ送信ログテーブルに対して検索処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhaimm
// 作 成 日  2013/06/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 10901034-00  作成担当 : 田建委  
// 修 正 日  2013/08/12  修正内容 : Redmine#39695 抽出結果無時のログ内容の変更対応
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
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013/06/26</br>
    /// <br>UpdateNote : 2013/08/12 田建委</br>
    /// <br>           : Redmine#39695 抽出結果無時のログ内容の変更対応</br>
    /// </remarks>
    public class SAndESalSndLogListResultAcs
    {
        #region ■ Private Members ■
        // 売上データ送信ログデータセット
        private SAndESalSndLogListResultDataSet _sAndESalSndLogListResultDataSet;
        // 売上データ送信ログデータテーブル
        private SAndESalSndLogListResultDataSet.SAndESalSndLogListResultDataTable _sAndESalSndLogListResultDataTable;
        private ISAndESalSndLogDB _iSAndESalSndLogDB;
        private static SAndESalSndLogListResultAcs _sAndESalSndLogListResultAcs;
        /// <summary>拠点マスタDB</summary>
        private SecInfoSetAcsAgent _sectionInfoDB;
        #endregion ■ Private Members ■

        #region ■ Properties ■

        /// <summary>
        /// 売上データ送信ログデータテーブルプロパティ
        /// </summary>
        public SAndESalSndLogListResultDataSet.SAndESalSndLogListResultDataTable SAndESalSndLogListResultDataTable
        {
            get { return _sAndESalSndLogListResultDataTable; }
        }
        #endregion ■ Properties ■

        # region ■ Constructor ■
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private SAndESalSndLogListResultAcs()
        {
            // 変数初期化
            this._sAndESalSndLogListResultDataSet = new SAndESalSndLogListResultDataSet();
            this._sAndESalSndLogListResultDataTable = this._sAndESalSndLogListResultDataSet.SAndESalSndLogListResult;
            this._iSAndESalSndLogDB = MediationSAndESalSndLogDB.GetSAndESalSndLogDB();
            this._sectionInfoDB = new SecInfoSetAcsAgent();
        }
        # endregion ■ Constructor ■

        /// <summary>
        /// 売上データ送信ログテーブルのログ情報処理を行う
        /// </summary>
        /// <param name="sAndESalSndLogListResultSearchPara">売上データ送信ログ抽出条件</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上データ送信ログ取得処理を行う。</br>      
        /// <br>Programmer : zhaimm</br>                                  
        /// <br>Date       : 2013/06/26</br> 
        /// <br>UpdateNote : 2013/08/12 田建委</br>
        /// <br>           : Redmine#39695 抽出結果無時のログ内容の変更対応</br>
        /// </remarks>
        public int SearchSAndESalSndLog(ref object sAndESalSndLogListResultSearchPara, ConstantManagement.LogicalMode logicalMode)
        {
            ArrayList outSAndESalSndLogListResultList = new ArrayList();
            object outObj = outSAndESalSndLogListResultList as object;

            string errMessage = string.Empty;
            int status = this._iSAndESalSndLogDB.SearchSAndESalSndLog(out outObj, out errMessage, ref sAndESalSndLogListResultSearchPara, logicalMode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                outSAndESalSndLogListResultList = (ArrayList)outObj;
                Dictionary<string, string> sectionNameMap = new Dictionary<string, string>();

                this._sAndESalSndLogListResultDataTable.Clear();
                this._sAndESalSndLogListResultDataTable.BeginLoadData();
                try
                {
                    foreach (SAndESalSndLogListResultWork sAndESalSndLogListResult in outSAndESalSndLogListResultList)
                    {
                        SAndESalSndLogListResultDataSet.SAndESalSndLogListResultRow sAndESalSndLogListResultRow = this._sAndESalSndLogListResultDataTable.NewSAndESalSndLogListResultRow();
                        sAndESalSndLogListResultRow.SectionCode = sAndESalSndLogListResult.SectionCode; // 拠点コード
                        // 拠点名称
                        if (!sectionNameMap.ContainsKey(sAndESalSndLogListResult.SectionCode))
                        {
                            sectionNameMap.Add(sAndESalSndLogListResult.SectionCode, _sectionInfoDB.GetSectionName(sAndESalSndLogListResult.SectionCode));
                        }
                        sAndESalSndLogListResultRow.SectionName = sectionNameMap[sAndESalSndLogListResult.SectionCode];
                        sAndESalSndLogListResultRow.SAndEAutoSendDiv = sAndESalSndLogListResult.SAndEAutoSendDiv;
                        // 0:手動,1:自動
                        switch (sAndESalSndLogListResult.SAndEAutoSendDiv)
                        {
                            case 0:
                                sAndESalSndLogListResultRow.SAndEAutoSendDivName = "手動";
                                break;
                            case 1:
                                sAndESalSndLogListResultRow.SAndEAutoSendDivName = "自動";
                                break;
                            default:
                                sAndESalSndLogListResultRow.SAndEAutoSendDivName = string.Empty;
                                break;
                        }

                        DateTime sendDateTimeStart = DateTime.MinValue;
                        DateTime sendDateTimeEnd = DateTime.MinValue;
                        DateTime sendObjDateStart = DateTime.MinValue;
                        DateTime sendObjDateEnd = DateTime.MinValue;
                        if (DateTime.TryParseExact(sAndESalSndLogListResult.SendDateTimeStart.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendDateTimeStart))
                        {
                            sAndESalSndLogListResultRow.SendDateTimeStart = sendDateTimeStart.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            sAndESalSndLogListResultRow.SendDateTimeStart = string.Empty;
                        }
                        if (DateTime.TryParseExact(sAndESalSndLogListResult.SendDateTimeEnd.ToString(), "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out sendDateTimeEnd))
                        {
                            sAndESalSndLogListResultRow.SendDateTimeEnd = sendDateTimeEnd.ToString("yyyy/MM/dd HH:mm:ss");
                        }
                        else
                        {
                            sAndESalSndLogListResultRow.SendDateTimeEnd = string.Empty;
                        }
                        if (DateTime.TryParseExact(sAndESalSndLogListResult.SendObjDateStart.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sendObjDateStart))
                        {
                            sAndESalSndLogListResultRow.SendObjDateStart = sendObjDateStart.ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            sAndESalSndLogListResultRow.SendObjDateStart = string.Empty;
                        }
                        if (DateTime.TryParseExact(sAndESalSndLogListResult.SendObjDateEnd.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out sendObjDateEnd))
                        {
                            sAndESalSndLogListResultRow.SendObjDateEnd = sendObjDateEnd.ToString("yyyy/MM/dd");
                        }
                        else
                        {
                            sAndESalSndLogListResultRow.SendObjDateEnd = string.Empty;
                        }
                        sAndESalSndLogListResultRow.SendObjCustStart = sAndESalSndLogListResult.SendObjCustStart;
                        sAndESalSndLogListResultRow.SendObjCustEnd = sAndESalSndLogListResult.SendObjCustEnd;
                        sAndESalSndLogListResultRow.SendObjDiv = sAndESalSndLogListResult.SendObjDiv;
                        // 0:全て,1:未送信,2：送信済
                        switch (sAndESalSndLogListResult.SendObjDiv)
                        {
                            case 0:
                                sAndESalSndLogListResultRow.SendObjDivName = "全て";
                                break;
                            case 1:
                                sAndESalSndLogListResultRow.SendObjDivName = "未送信";
                                break;
                            case 2:
                                sAndESalSndLogListResultRow.SendObjDivName = "送信済";
                                break;
                            default:
                                sAndESalSndLogListResultRow.SendObjDivName = string.Empty;
                                break;
                        }
                        sAndESalSndLogListResultRow.SendResults = sAndESalSndLogListResult.SendResults;
                        // 0:正常完了,1：失敗
                        switch (sAndESalSndLogListResult.SendResults)
                        {
                            case 0:
                                sAndESalSndLogListResultRow.SendResultsName = "正常完了";
                                break;
                            case 1:
                                sAndESalSndLogListResultRow.SendResultsName = "失敗";
                                break;
                            //----- ADD 田建委 2013/08/12 Redmine#39695 ----->>>>>
                            case 2:
                                sAndESalSndLogListResultRow.SendResultsName = "送信対象なし";
                                break;
                            //----- ADD 田建委 2013/08/12 Redmine#39695 -----<<<<<
                            default:
                                sAndESalSndLogListResultRow.SendResultsName = string.Empty;
                                break;
                        }
                        sAndESalSndLogListResultRow.SendSlipCount = sAndESalSndLogListResult.SendSlipCount; // 送信伝票枚数
                        sAndESalSndLogListResultRow.SendSlipDtlCnt = sAndESalSndLogListResult.SendSlipDtlCnt; // 送信伝票明細数
                        sAndESalSndLogListResultRow.SendSlipTotalMny = sAndESalSndLogListResult.SendSlipTotalMny; // 送信伝票合計金額
                        sAndESalSndLogListResultRow.SendErrorContents = sAndESalSndLogListResult.SendErrorContents; // 送信エラー内容

                        this._sAndESalSndLogListResultDataTable.Rows.Add(sAndESalSndLogListResultRow);
                    }
                }
                finally
                {
                    this._sAndESalSndLogListResultDataTable.EndLoadData();
                }
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this._sAndESalSndLogListResultDataTable.Clear();
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
        /// <br>Programmer : zhaimm</br>                                  
        /// <br>Date       : 2013/06/26</br> 
        /// </remarks>
        public int ResetSAndESalSndLog(out string errMessage, string enterpriseCode)
        {
            errMessage = string.Empty;

            int status = this._iSAndESalSndLogDB.ResetSAndESalSndLog(out errMessage, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._sAndESalSndLogListResultDataTable.Clear();
            }

            return status;
        }

        # region ■ 売上データ送信ログアクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// 売上データ送信ログアクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上データ送信ログ取得処理を行う。</br>      
        /// <br>Programmer : zhaimm</br>                                  
        /// <br>Date       : 2013/06/26</br> 
        /// </remarks>
        public static SAndESalSndLogListResultAcs GetInstance()
        {
            if (_sAndESalSndLogListResultAcs == null)
            {
                _sAndESalSndLogListResultAcs = new SAndESalSndLogListResultAcs();
            }

            return _sAndESalSndLogListResultAcs;
        }
        # endregion ■ 売上データ送信ログアクセスクラス インスタンス取得処理 ■
    }
}
