//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/17  修正内容 : PVCS票#161 抽出対象データが存在しない場合のログについて 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/06  修正内容 : マスタ送受信処理のＡＰＰロックについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2011/07/25  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/27  修正内容 : #23922 受信処理で対象外の項目も受信されてしまいます。
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/30  修正内容 : #24191 マスタ送信（条件送信）の送信実行日について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/31  修正内容 : Redmine #24278 データ自動受信処理が起動しません
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 孫東響
// 修 正 日  2011/09/05  修正内容 : #24047 送信失敗時の対処について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/09/06  修正内容 : #24364 送信タイムアウト問題の修正
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : 馮文雄
// 修 正 日  2011/09/15  修正内容 : #23934 送信終了日付について
//----------------------------------------------------------------------------//
// 管理番号              修正担当 : FSI菅原 庸平
// 修 正 日  2012/07/26  修正内容 : 抽出条件区分に従業員、ユーザーガイド(販売区分)、結合を追加
//----------------------------------------------------------------------------//
// 管理番号  11770021-00 作成担当 : 陳艶丹
// 作 成 日  2021/04/12  修正内容 : 得意先メモ情報の追加
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// マスタ送受信処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : マスタ送受信処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.04.02<br />
    /// <br>Update Note: 2021/04/12 陳艶丹</br>
    /// <br>管理番号   : 11770021-00</br>
    /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
    /// </remarks>
    public class MstUpdCountAcs
    {
        #region ■ Const Memebers ■
        private const string ZERO_0 = "0";
        private const string MARK_1 = ":";
        private const string MARK_2 = "、";
        private const string MARK_3 = " ";
        private const string MARK_4 = ",";
        private const string PROGRAM_ID = "PMKYO01201UA";
        private const string PROGRAM_NAME = "マスタ送受信処理";
        private const string MST_SECINFOSET = "拠点設定マスタ";
        private const string MST_SUBSECTION = "部門設定マスタ";
        private const string MST_WAREHOUSE = "倉庫設定マスタ";
        private const string MST_EMPLOYEE = "従業員設定マスタ";
        private const string MST_USERGDAREADIVU = "ユーザーガイドマスタ(販売エリア区分）";
        private const string MST_USERGDBUSDIVU = "ユーザーガイドマスタ（業務区分）";
        private const string MST_USERGDCATEU = "ユーザーガイドマスタ（業種）";
        private const string MST_USERGDBUSU = "ユーザーガイドマスタ（職種）";
        private const string MST_USERGDGOODSDIVU = "ユーザーガイドマスタ（商品区分）";
        private const string MST_USERGDCUSGROUPU = "ユーザーガイドマスタ（得意先掛率グループ）";
        private const string MST_USERGDBANKU = "ユーザーガイドマスタ（銀行）";
        private const string MST_USERGDPRIDIVU = "ユーザーガイドマスタ（価格区分）";
        private const string MST_USERGDDELIDIVU = "ユーザーガイドマスタ（納品区分）";
        private const string MST_USERGDGOODSBIGU = "ユーザーガイドマスタ（商品大分類）";
        private const string MST_USERGDBUYDIVU = "ユーザーガイドマスタ（販売区分）";
        private const string MST_USERGDSTOCKDIVOU = "ユーザーガイドマスタ（在庫管理区分１）";
        private const string MST_USERGDSTOCKDIVTU = "ユーザーガイドマスタ（在庫管理区分２）";
        private const string MST_USERGDRETURNREAU = "ユーザーガイドマスタ（返品理由）";
        private const string MST_RATEPROTYMNG = "掛率優先管理マスタ";
        private const string MST_RATE = "掛率マスタ";
        private const string MST_SALESTARGET = "売上目標設定マスタ";
        private const string MST_CUSTOME = "得意先マスタ";
        private const string MST_SUPPLIER = "仕入先マスタ";
        private const string MST_JOINPARTSU = "結合マスタ";
        private const string MST_GOODSSET = "セットマスタ";
        private const string MST_TBOSEARCHU = "ＴＢＯマスタ";
        private const string MST_MODELNAMEU = "車種マスタ";
        private const string MST_BLGOODSCDU = "ＢＬコードマスタ";
        private const string MST_MAKERU = "メーカーマスタ";
        private const string MST_GOODSMGROUPU = "商品中分類マスタ";
        private const string MST_BLGROUPU = "グループコードマスタ";
        private const string MST_BLCODEGUIDE = "BLコードガイドマスタ";
        private const string MST_GOODSU = "商品マスタ";
        private const string MST_STOCK = "在庫マスタ";
        private const string MST_PARTSSUBSTU = "代替マスタ";
        private const string MST_PARTSPOSCODEU = "部位マスタ";

        private const string COUNTNAME = "件";

        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        private const string FILEID_CUSTOMER = "CustomerRF";
        private const string FILEID_GOODS = "GoodsURF";
        private const string FILEID_STOCK = "StockRF";
        private const string FILEID_SUPPLIER = "SupplierRF";
        private const string FILEID_RATE = "RateRF";
        // --- ADD 2012/07/26 ------------------------->>>>>
        private const string FILEID_EMPLOYEE = "EmployeeDtlRF";
        private const string FILEID_JOINPARTSU = "JoinPartsURF";
        private const string FILEID_USERGDU = "UserGdBdURF";
        // --- ADD 2012/07/26 -------------------------<<<<<
        private const int MAX_CNT = 20000;
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

        private const int INT_ZERO = 0; //ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136
        #endregion ■ Const Memebers ■

        # region ■ Constructor ■
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private MstUpdCountAcs()
        {
            // 変数初期化
            this._dataSet = new UpdateResultDataSet();
            this._extractionConditionDataSet = new ExtractionConditionDataSet();
            this._receiveInfoDataSet = new ReceiveInfoDataSet();
            this._receiveConditionDataSet = new ReceiveConditionDataSet();

            this._updateResultDataTable = this._dataSet.UpdateResult;
            this._extractionConditionDataTable = this._extractionConditionDataSet.ExtractionCondition;
            this._receiveInfoDataTable = this._receiveInfoDataSet.ReceiveInfo;
            this._receiveConditionDataTable = this._receiveConditionDataSet.ReceiveCondition;
            this._secMngConnectStAcs = new SecMngConnectStAcs();
        }
        # endregion ■ Constructor ■

        # region ■ Properties ■

        /// <summary>
        /// データ送信処理データテーブルプロパティ
        /// </summary>
        public UpdateResultDataSet.UpdateResultDataTable UpdateResultDataTable
        {
            get { return _updateResultDataTable; }
        }

        /// <summary>
        /// データ送信処理データテーブルプロパティ
        /// </summary>
        public ExtractionConditionDataSet.ExtractionConditionDataTable ExtractionConditionDataTable
        {
            get { return _extractionConditionDataTable; }
        }

        /// <summary>
        /// データ送信処理データテーブルプロパティ
        /// </summary>
        public ReceiveInfoDataSet.ReceiveInfoDataTable ReceiveInfoDataTable
        {
            get { return _receiveInfoDataTable; }
        }

        /// <summary>
        /// データ送信処理データテーブルプロパティ
        /// </summary>
        public ReceiveConditionDataSet.ReceiveConditionDataTable ReceiveConditionDataTable
        {
            get { return _receiveConditionDataTable; }
        }
        //ADD 2011/08/31 Redmine #24278-------------->>>>>
        /// <summary>
        /// 自動手動区分
        /// </summary>
        public Boolean AutoSendRecvDiv
        {
            get { return _autoSendRecvDiv; }
            set { _autoSendRecvDiv = value; }
        }
        //ADD 2011/08/31 Redmine #24278--------------<<<<<
        # endregion ■ Properties ■

        # region ■ Private Members ■
        // 送信情報データセット
        private UpdateResultDataSet _dataSet;
        // 送信条件データセット
        private ExtractionConditionDataSet _extractionConditionDataSet;
        // 受信情報データセット
        private ReceiveInfoDataSet _receiveInfoDataSet;
        // 受信条件データセット
        private ReceiveConditionDataSet _receiveConditionDataSet;
        // 送信情報データテーブル
        private UpdateResultDataSet.UpdateResultDataTable _updateResultDataTable;
        // 送信条件データテーブル
        private ExtractionConditionDataSet.ExtractionConditionDataTable _extractionConditionDataTable;
        // 受信情報データテーブル
        private ReceiveInfoDataSet.ReceiveInfoDataTable _receiveInfoDataTable;
        // 受信条件データテーブル
        private ReceiveConditionDataSet.ReceiveConditionDataTable _receiveConditionDataTable;
        // 拠点管理接続先設定アクセス
        private SecMngConnectStAcs _secMngConnectStAcs;
        private static MstUpdCountAcs _mstUpdCountAcs;
        private IMstDCControlDB _iMstDCControlDB;
        private IMstTotalMachControlDB _iMstTotalMachControlDB;
        private IAPMSTControlDB _iAPMSTControlDB;
        private ISndRcvHisDB _iSndRcvHisRFDB; //ADD 2011/07/25
        private bool _autoSendRecvDiv = false;//ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません


        # endregion ■ Private Members ■

        # region ■ データ送信処理アクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// データ送信処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>データ送信処理アクセスクラス インスタンス</returns>
        public static MstUpdCountAcs GetInstance()
        {
            if (_mstUpdCountAcs == null)
            {
                _mstUpdCountAcs = new MstUpdCountAcs();
            }

            return _mstUpdCountAcs;
        }
        # endregion ■ データ送信処理アクセスクラス インスタンス取得処理 ■

        # region ■ マスタ送受信処理 ■
        /// <summary>
        /// 送信情報マスタ名称取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信情報マスタ名称の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        public int LoadMstName(string enterpriseCode, out ArrayList masterNameList)
        {
            masterNameList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchMstName(enterpriseCode, out masterNameList);
            return status;
        }

        /// <summary>
        /// 送信情報区分取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ区分リスト</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信情報区分の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        public int LoadMstDoDiv(string enterpriseCode, out ArrayList masterDivList)
        {
            masterDivList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchMstDoDiv(enterpriseCode, out masterDivList);
            return status;
        }

        /// <summary>
        /// 受信情報区分取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ区分リスト</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受信情報区分の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        public int LoadReceMstDoDiv(string enterpriseCode, out ArrayList masterDivList)
        {
            masterDivList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchReceMstDoDiv(enterpriseCode, out masterDivList);
            return status;
        }

        /// <summary>
        /// 受信情報明細区分取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDtlDivList">マスタ区分リスト</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受信情報明細区分の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        public int LoadReceMstDtlDoDiv(string enterpriseCode, out ArrayList masterDtlDivList)
        {
            masterDtlDivList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchReceMstDtlDoDiv(enterpriseCode, out masterDtlDivList);
            return status;
        }

        /// <summary>
        /// 受信情報マスタ名称取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受信情報マスタ名称の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        public int LoadReceMstName(string enterpriseCode, out ArrayList masterNameList)
        {
            masterNameList = new ArrayList();
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchReceMstName(enterpriseCode, out masterNameList);
            return status;
        }

        /// <summary>
        /// 受信情報PMコード取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="pmCode">PMコード</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受信情報PMコードの取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        public int SeachPmCode(string enterpriseCode, string baseCode, out string pmCode)
        {
            pmCode = string.Empty;
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SeachPmCode(enterpriseCode, baseCode, out pmCode);
            return status;
        }

        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        /// <summary>
        /// 送信先情報リロード
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCodeList">拠点リスト</param>
        /// <returns>読込結果ステータス</returns>
        public int ReloadSecMngSetInfo(string enterpriseCode, out ArrayList baseCodeList)
        {
            baseCodeList = new ArrayList();
            ArrayList secMngSetArrList = new ArrayList();
            // 拠点管理設定情報を取得して、初期化設定を行う
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchSyncExecDate(enterpriseCode, out secMngSetArrList);
            // 検索0件の場合、或いはDBエラーの場合、
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            foreach (APMSTSecMngSetWork secMngSetWork in secMngSetArrList)
            {
                baseCodeList.Add(secMngSetWork.SendDestSecCode);
            }
            return status;
        }
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

        /// <summary>
        /// 送信情報シンク日時取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="startDt">シンク日時</param>
        /// <param name="baseCodeNameList">拠点リスト</param>
        /// <param name="sendDivFlg">送信区分フラグ 0:自動送信 1:手動送信</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信情報シンク日時の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        //public int LoadSyncExecDate(string enterpriseCode, out DateTime startDt, out ArrayList baseCodeNameList)//DEL 2011/07/25
        public int LoadSyncExecDate(string enterpriseCode, out DateTime startDt, out ArrayList baseCodeNameList, int sendDivFlg)
        {
            startDt = new DateTime();
            ExtractionConditionDataSet.ExtractionConditionRow row = null;
            baseCodeNameList = new ArrayList();
            BaseCodeNameWork baseCodeNameWork = null;
            ArrayList secMngSetArrList = new ArrayList();
            // 拠点管理設定情報を取得して、初期化設定を行う
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchSyncExecDate(enterpriseCode, out secMngSetArrList);
            // 検索0件の場合、或いはDBエラーの場合、
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            DateTime syncExecDate = new DateTime();
            String syncExecDateHour = string.Empty;
            String syncExecDateMinute = string.Empty;
            String syncExecDateSecond = string.Empty;
            DateTime endDate = new DateTime();
            String endDateHour = string.Empty;
            String endDateMinute = string.Empty;
            String endDateSecond = string.Empty;

            // 送信の場合、
            foreach (APMSTSecMngSetWork secMngSetWork in secMngSetArrList)
            {
                // 検索結果を設定を行う
                row = _extractionConditionDataTable.NewExtractionConditionRow();
                // 拠点コード
                //row.BaseCode = secMngSetWork.SectionCode;//DEL 2011/07/26
                row.BaseCode = secMngSetWork.SendDestSecCode;//ADD 2011/07/26
                // 拠点名称
                row.BaseName = secMngSetWork.SectionGuideNm;

                baseCodeNameWork = new BaseCodeNameWork();
                //baseCodeNameWork.SectionCode = secMngSetWork.SectionCode;//DEL 2011/07/26
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                baseCodeNameWork.SectionCode = secMngSetWork.SendDestSecCode;
                baseCodeNameWork.SyncExecDate = secMngSetWork.SyncExecDate;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                baseCodeNameWork.SectionGuideNm = secMngSetWork.SectionGuideNm;
                //baseCodeNameList.Add(baseCodeNameWork);//DEL 2011/07/26
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //自動送信の場合
                if (sendDivFlg == 0)
                {
                    //自動送信区分が｢0：自動送信する｣の拠点を送信先対象とする
                    if (secMngSetWork.AutoSendDiv == 0)
                    {
                        baseCodeNameList.Add(baseCodeNameWork);
                    }
                }
                else
                {
                    baseCodeNameList.Add(baseCodeNameWork);
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

                syncExecDate = secMngSetWork.SyncExecDate;
                // 時、分、秒、2桁補足
                syncExecDateHour = syncExecDate.Hour.ToString();
                syncExecDateMinute = syncExecDate.Minute.ToString();
                syncExecDateSecond = syncExecDate.Second.ToString();
                // 時2桁補足
                if (syncExecDateHour.Length == 1)
                {
                    syncExecDateHour = ZERO_0 + syncExecDateHour;
                }
                // 分2桁補足
                if (syncExecDateMinute.Length == 1)
                {
                    syncExecDateMinute = ZERO_0 + syncExecDateMinute;
                }
                // 秒2桁補足
                if (syncExecDateSecond.Length == 1)
                {
                    syncExecDateSecond = ZERO_0 + syncExecDateSecond;
                }
                // 開始日付
                row.BeginningDate = syncExecDate;
                startDt = syncExecDate;
                // 開始時間
                row.BeginningTime = syncExecDateHour + MARK_1 + syncExecDateMinute + MARK_1 + syncExecDateSecond;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //初期開始日付(Hidden)
                row.InitBeginningDate = syncExecDate;
                //初期開始時間(Hidden)
                row.InitBeginningTime = syncExecDateHour + MARK_1 + syncExecDateMinute + MARK_1 + syncExecDateSecond;
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

                // システム時間
                endDate = System.DateTime.Now;
                endDateHour = endDate.Hour.ToString();
                endDateMinute = endDate.Minute.ToString();
                endDateSecond = endDate.Second.ToString();
                // 時2桁補足
                if (endDateHour.Length == 1)
                {
                    endDateHour = ZERO_0 + endDateHour;
                }
                // 分2桁補足
                if (endDateMinute.Length == 1)
                {
                    endDateMinute = ZERO_0 + endDateMinute;
                }
                // 秒2桁補足
                if (endDateSecond.Length == 1)
                {
                    endDateSecond = ZERO_0 + endDateSecond;
                }
                // 終了日付
                row.EndDate = endDate;
                // 終了時間
                row.EndTime = endDateHour + MARK_1 + endDateMinute + MARK_1 + endDateSecond;

                _extractionConditionDataTable.Rows.Add(row);
            }

            return status;
        }

        /// <summary>
        /// 受信情報シンク日時取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngSetArrList">シンク日時リスト</param>
        /// <param name="baseCodeNameList">拠点リスト</param>
        /// <param name="sndRcvHisList">送受信履歴ログデータリスト</param>
        /// <param name="sndRcvEtrList">送受信抽出条件履歴ログデータリスト</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 受信情報シンク日時の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        //public int LoadReceSyncExecDate(string enterpriseCode, out ArrayList secMngSetArrList, out ArrayList baseCodeNameList)//DEL 2011/07/25
        public int LoadReceSyncExecDate(string enterpriseCode, out ArrayList secMngSetArrList, out ArrayList baseCodeNameList, out ArrayList sndRcvHisList, out ArrayList sndRcvEtrList)
        {
            //ReceiveConditionDataSet.ReceiveConditionRow ReceiveRow = null;//DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
            baseCodeNameList = new ArrayList();
            BaseCodeNameWork baseCodeNameWork = null;
            secMngSetArrList = new ArrayList();
            //string sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
            #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
            //// 拠点管理設定情報を取得して、初期化設定を行う
            //this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            //int status = _iAPMSTControlDB.SearchReceSyncExecDate(enterpriseCode, out secMngSetArrList);
            //// 検索0件の場合、或いはDBエラーの場合、
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return status;
            //}

            //DateTime syncExecDate = new DateTime();
            //String syncExecDateHour = string.Empty;
            //String syncExecDateMinute = string.Empty;
            //String syncExecDateSecond = string.Empty;
            //DateTime endDate = new DateTime();
            //String endDateHour = string.Empty;
            //String endDateMinute = string.Empty;
            //String endDateSecond = string.Empty;

            //foreach (APMSTSecMngSetWork secMngSetWork in secMngSetArrList)
            //{
            //    // 検索結果を設定を行う
            //    ReceiveRow = _receiveConditionDataTable.NewReceiveConditionRow();
            //    // 拠点コード
            //    ReceiveRow.BaseCode = secMngSetWork.SectionCode;
            //    // 拠点名称
            //    ReceiveRow.BaseName = secMngSetWork.SectionGuideNm;

            //    baseCodeNameWork = new BaseCodeNameWork();
            //    baseCodeNameWork.SectionCode = secMngSetWork.SectionCode;
            //    baseCodeNameWork.SectionGuideNm = secMngSetWork.SectionGuideNm;
            //    baseCodeNameList.Add(baseCodeNameWork);

            //    syncExecDate = secMngSetWork.SyncExecDate;
            //    // 時、分、秒、2桁補足
            //    syncExecDateHour = syncExecDate.Hour.ToString();
            //    syncExecDateMinute = syncExecDate.Minute.ToString();
            //    syncExecDateSecond = syncExecDate.Second.ToString();
            //    // 時2桁補足
            //    if (syncExecDateHour.Length == 1)
            //    {
            //        syncExecDateHour = ZERO_0 + syncExecDateHour;
            //    }
            //    // 分2桁補足
            //    if (syncExecDateMinute.Length == 1)
            //    {
            //        syncExecDateMinute = ZERO_0 + syncExecDateMinute;
            //    }
            //    // 秒2桁補足
            //    if (syncExecDateSecond.Length == 1)
            //    {
            //        syncExecDateSecond = ZERO_0 + syncExecDateSecond;
            //    }
            //    // 開始日付
            //    ReceiveRow.BeginningDate = syncExecDate;
            //    // 開始時間
            //    ReceiveRow.BeginningTime = syncExecDateHour + MARK_1 + syncExecDateMinute + MARK_1 + syncExecDateSecond;

            //    // システム時間
            //    endDate = System.DateTime.Now;
            //    endDateHour = endDate.Hour.ToString();
            //    endDateMinute = endDate.Minute.ToString();
            //    endDateSecond = endDate.Second.ToString();
            //    // 時2桁補足
            //    if (endDateHour.Length == 1)
            //    {
            //        endDateHour = ZERO_0 + endDateHour;
            //    }
            //    // 分2桁補足
            //    if (endDateMinute.Length == 1)
            //    {
            //        endDateMinute = ZERO_0 + endDateMinute;
            //    }
            //    // 秒2桁補足
            //    if (endDateSecond.Length == 1)
            //    {
            //        endDateSecond = ZERO_0 + endDateSecond;
            //    }
            //    // 終了日付
            //    ReceiveRow.EndDate = endDate;
            //    // 終了時間
            //    ReceiveRow.EndTime = endDateHour + MARK_1 + endDateMinute + MARK_1 + endDateSecond;

            //    _receiveConditionDataTable.Rows.Add(ReceiveRow);
            //}
            #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            sndRcvHisList = new ArrayList();
            sndRcvEtrList = new ArrayList();
            this._iSndRcvHisRFDB = MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
            SndRcvHisCondWork _sndRcvHisCondWork = new SndRcvHisCondWork();
            _sndRcvHisCondWork.EnterpriseCode = enterpriseCode;
            //_sndRcvHisCondWork.SectionCode = sectionCode;//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません ---------->>>>>
            string belongSectionCode = string.Empty;
            if (_autoSendRecvDiv)
            {
                int ret = GetBelongSectionCodeFormXml(ref belongSectionCode);
                if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return ret;
                }
                _sndRcvHisCondWork.SectionCode = belongSectionCode;
            }
            else
            {
                _sndRcvHisCondWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません ----------<<<<<
            _sndRcvHisCondWork.SendOrReceiveDivCd = 0;
            _sndRcvHisCondWork.Kind = 1;
            object objList = null;
            int status = _iSndRcvHisRFDB.Search(_sndRcvHisCondWork, out objList);
            // 検索0件の場合、或いはDBエラーの場合、
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            ArrayList retList = (ArrayList)objList;
            if (retList != null)
            {
                for (int i = 0; i < retList.Count; i++)
                {
                    Type wktype = retList[i].GetType();
                    if (wktype.Equals(typeof(SndRcvHisWork)))
                    {
                        sndRcvHisList.Add(retList[i]);
                    }
                    else if (wktype.Equals(typeof(ArrayList)))
                    {
                        ArrayList subResultList = (ArrayList)retList[i];
                        sndRcvEtrList.AddRange((ArrayList)retList[i]);
                    }
                }
            }
            
            ReceiveConditionDataSet.ReceiveConditionRow ReceiveRow = null;
            DateTime beginDateTime = new DateTime();
            String beginDateHour = string.Empty;
            String beginDateMinute = string.Empty;
            String beginDateSecond = string.Empty;
            DateTime endDateTime = new DateTime();
            String endDateHour = string.Empty;
            String endDateMinute = string.Empty;
            String endDateSecond = string.Empty;
            foreach (SndRcvHisWork sndRcvHisWork in sndRcvHisList)
            {
                // 検索結果を設定を行う
                ReceiveRow = _receiveConditionDataTable.NewReceiveConditionRow();
                ReceiveRow.EnterpriseCode = sndRcvHisWork.EnterpriseCode;
                ReceiveRow.BaseCode = sndRcvHisWork.SectionCode;
                #region DEL
                //DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません-------------->>>>>>
                //SecInfoAcs secInfoAcs = new SecInfoAcs();
                //string secName = string.Empty;
                //try
                //{
                //    foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                //    {
                //        if (secInfoSet.SectionCode.Trim() == ReceiveRow.BaseCode.Trim().PadLeft(2, '0'))
                //        {
                //            ReceiveRow.BaseName = secInfoSet.SectionGuideNm.Trim();
                //            secName = secInfoSet.SectionGuideNm.Trim();
                //            break;
                //        }
                //    }
                //}
                //catch
                //{
                //    ReceiveRow.BaseName = string.Empty;
                //    secName = string.Empty;
                //}
                //DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません-------------->>>>>>
                #endregion
                //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません-------------->>>>>>                
                string secName = string.Empty;
                if (_autoSendRecvDiv == false)
                {
                    SecInfoAcs secInfoAcs = new SecInfoAcs();
                    try
                    {
                        foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
                        {
                            if (secInfoSet.SectionCode.Trim() == ReceiveRow.BaseCode.Trim().PadLeft(2, '0'))
                            {
                                ReceiveRow.BaseName = secInfoSet.SectionGuideNm.Trim();
                                secName = secInfoSet.SectionGuideNm.Trim();
                                break;
                            }
                        }
                    }
                    catch
                    {
                        ReceiveRow.BaseName = string.Empty;
                        secName = string.Empty;
                    }
                }
                //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません-------------->>>>>>
                baseCodeNameWork = new BaseCodeNameWork();
                baseCodeNameWork.SectionCode = sndRcvHisWork.SectionCode;
                baseCodeNameWork.SectionGuideNm = secName;
                baseCodeNameList.Add(baseCodeNameWork);

                ReceiveRow.ExtraCondDiv = sndRcvHisWork.SndLogExtraCondDiv;
                if (ReceiveRow.ExtraCondDiv == 0)
                {
                    ReceiveRow.ExtraCondDivNm = "差分";
                }
                else
                {
                    ReceiveRow.ExtraCondDivNm = "条件";
                }
                ReceiveRow.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                // 時、分、秒、2桁補足
                beginDateTime = sndRcvHisWork.SndObjStartDate;
                beginDateHour = beginDateTime.Hour.ToString();
                beginDateMinute = beginDateTime.Minute.ToString();
                beginDateSecond = beginDateTime.Second.ToString();
                // 時2桁補足
                if (beginDateHour.Length == 1)
                {
                    beginDateHour = ZERO_0 + beginDateHour;
                }
                // 分2桁補足
                if (beginDateMinute.Length == 1)
                {
                    beginDateMinute = ZERO_0 + beginDateMinute;
                }
                // 秒2桁補足
                if (beginDateSecond.Length == 1)
                {
                    beginDateSecond = ZERO_0 + beginDateSecond;
                }
                // 開始日付
                ReceiveRow.BeginningDate = beginDateTime;
                // 開始時間
                if (beginDateTime != DateTime.MinValue)
                {
                    ReceiveRow.BeginningTime = beginDateHour + MARK_1 + beginDateMinute + MARK_1 + beginDateSecond;
                }
                else
                {
                    ReceiveRow.BeginningTime = "";
                }

                // 時、分、秒、2桁補足
                endDateTime = sndRcvHisWork.SndObjEndDate;
                endDateHour = endDateTime.Hour.ToString();
                endDateMinute = endDateTime.Minute.ToString();
                endDateSecond = endDateTime.Second.ToString();
                // 時2桁補足
                if (endDateHour.Length == 1)
                {
                    endDateHour = ZERO_0 + endDateHour;
                }
                // 分2桁補足
                if (endDateMinute.Length == 1)
                {
                    endDateMinute = ZERO_0 + endDateMinute;
                }
                // 秒2桁補足
                if (endDateSecond.Length == 1)
                {
                    endDateSecond = ZERO_0 + endDateSecond;
                }
                // 開始日付
                ReceiveRow.EndDate = endDateTime;
                // 開始時間
                if (endDateTime != DateTime.MinValue)
                {
                    ReceiveRow.EndTime = endDateHour + MARK_1 + endDateMinute + MARK_1 + endDateSecond;
                }
                else
                {
                    ReceiveRow.EndTime = "";
                }

                _receiveConditionDataTable.Rows.Add(ReceiveRow);
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            return status;
        }
        /// <summary>
        /// 自拠点コードを取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>		
        /// <br>Note		: 自拠点コード取得処理を行う。</br>
        /// <br>Programmer	: 孫東響</br>	
        /// <br>Date		: 2011.09.01</br>
        /// </remarks>
        private int GetBelongSectionCodeFormXml(ref string belongSectionCode)
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ServiceFilesInputAcs sfInputAcs = ServiceFilesInputAcs.GetInstance();
            string msg = string.Empty;
            int flg = 0;
            stauts = sfInputAcs.SearchForAutoSendRecv(ref msg, ref flg);
            if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                belongSectionCode = sfInputAcs.SecInfo.SecInfo.Rows[0][0].ToString();
            }
            return stauts;
        }
        /// <summary>
        /// 拠点管理設定情報を取得して、送信時チェックを行う。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCodeNameList">拠点コードリスト</param>
        /// <param name="startDt">シンク時間</param>
        /// <returns>読込結果</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、送信時チェックを行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        public bool SendUpdateProc(string enterpriseCode, ArrayList baseCodeNameList, out DateTime startDt)
        {
            string retMessage = string.Empty;
            bool isUpdate = true;
            startDt = new DateTime();
            ArrayList secMngSetArrList = new ArrayList();
            // 拠点管理設定情報を取得して、初期化設定を行う
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchSyncExecDate(enterpriseCode, out secMngSetArrList);

            // 検索0件の場合、或いはDBエラーの場合、
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isUpdate = false;
                return isUpdate;
            }
            ArrayList baseCodeNameArr = new ArrayList();

            // 拠点コードリスト
            foreach (BaseCodeNameWork baseCodeNameWork in baseCodeNameList)
            {
                baseCodeNameArr.Add(baseCodeNameWork.SectionCode);
            }

            // 拠点コードNULLの場合と変更したの場合、
            foreach (APMSTSecMngSetWork work in secMngSetArrList) 
            {
                if (string.IsNullOrEmpty(work.SectionCode)
                    || !baseCodeNameArr.Contains(work.SectionCode))
                {
                    isUpdate = false;
                    return isUpdate;
                }

                startDt = work.SyncExecDate;
            }

            return isUpdate;

        }

        /// <summary>
        /// 拠点管理設定情報を取得して、受信時チェックを行う。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCodeNameList">拠点コードリスト</param>
        /// <param name="secMngSetArrList">シンク時間リスト</param>
        /// <param name="isTimeOut">時間</param>
        /// <returns>読込結果</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、受信時チェックを行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        public bool ReceUpdateProc(string enterpriseCode, ArrayList baseCodeNameList, out ArrayList secMngSetArrList, out bool isTimeOut)
        {
            string retMessage = string.Empty;
            bool isUpdate = true;
            isTimeOut = false;
            secMngSetArrList = new ArrayList();
            // 拠点管理設定情報を取得して、初期化設定を行う
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            int status = _iAPMSTControlDB.SearchReceSyncExecDate(enterpriseCode, out secMngSetArrList);
            // ADD 2009/07/06 --->>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                isTimeOut = true;
                return isUpdate;
            }
            // ADD 2009/07/06 ---<<<
            // 検索0件の場合、或いはDBエラーの場合、
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                isUpdate = false;
                return isUpdate;
            }
            ArrayList baseCodeNameOneArr = new ArrayList();
            ArrayList baseCodeNameTwoArr = new ArrayList();

            // 拠点コードリスト
            foreach (BaseCodeNameWork baseCodeNameWork in baseCodeNameList)
            {
                baseCodeNameOneArr.Add(baseCodeNameWork.SectionCode);
            }

            foreach (APMSTSecMngSetWork work in secMngSetArrList)
            {
                baseCodeNameTwoArr.Add(work.SectionCode);
            }

            // 拠点コードNULLの場合と変更したの場合、
            foreach (string baseCode in baseCodeNameOneArr)
            {
                if (!baseCodeNameTwoArr.Contains(baseCode)) 
                {
                    isUpdate = false;
                    return isUpdate;
                }
            }


            return isUpdate;

        }

        /// <summary>
        /// 検索件数フォーマット設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 検索件数フォーマット設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            // 三桁の場合、
            if (searchCountLen <= 3)
            {
                searchCountStr = searchCountStr + COUNTNAME;
            }
            // 六桁の場合、
            else if (3 < searchCountLen && searchCountLen <= 6)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + MARK_4 + searchCountStr.Substring(searchCountLen - 3) + COUNTNAME;
            }
            // 九桁の場合、
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + MARK_4
                    + searchCountStr.Substring(searchCountLen - 6, 3) + MARK_4
                    + searchCountStr.Substring(searchCountLen - 3) + COUNTNAME;
            }
            return searchCountStr;
        }

        /// <summary>
        /// 全て受信更新結果存在しない場合ログ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全て受信更新結果存在しない場合ログ処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        public void ReceLogOutProc()
        {
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();
            // 受信抽出結果CustomSerializeArrayListの内容が存在しない場合、
            // MOD 2009/06/17 --->>>
            //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "抽出対象のデータが存在しません。");
            operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
            // MOD 2009/06/17 ---<<<
        }

        /// <summary>
        /// マスタ抽出条件があるかどうか判断
        /// </summary>
        /// <param name="objWork">マスタ抽出条件対象</param>
        /// <returns>true:抽出条件あり false:抽出条件なし</returns>
        private bool isInput(object objWork)
        {
            bool isInput = false;
            if (objWork == null) return isInput;
            Type wkType = objWork.GetType();
            //得意先マスタ抽出条件
            if (wkType.Equals(typeof(APCustomerProcParamWork)))
            {
                APCustomerProcParamWork custParam = (APCustomerProcParamWork)objWork;
                if (custParam.BusinessTypeCodeBeginRF != 0
                    || custParam.BusinessTypeCodeEndRF != 0
                    || custParam.CustomerAgentCdBeginRF != ""
                    || custParam.CustomerAgentCdEndRF != ""
                    || custParam.CustomerCodeBeginRF != 0
                    || custParam.CustomerCodeEndRF != 0
                    || custParam.KanaBeginRF != ""
                    || custParam.KanaEndRF != ""
                    || custParam.MngSectionCodeBeginRF != ""
                    || custParam.MngSectionCodeEndRF != ""
                    || custParam.SalesAreaCodeBeginRF != 0
                    || custParam.SalesAreaCodeEndRF != 0
                    || custParam.UpdateDateTimeBegin != 0
                    || custParam.UpdateDateTimeEnd != 0
                )
                {
                    isInput = true;
                }
            }
            //商品マスタ抽出条件
            else if (wkType.Equals(typeof(APGoodsProcParamWork)))
            {
                APGoodsProcParamWork goodsParam = (APGoodsProcParamWork)objWork;
                if (goodsParam.BLGoodsCodeBeginRF != 0
                    || goodsParam.BLGoodsCodeEndRF != 0
                    || goodsParam.GoodsMakerCdBeginRF != 0
                    || goodsParam.GoodsMakerCdEndRF != 0
                    || goodsParam.GoodsNoBeginRF != ""
                    || goodsParam.GoodsNoEndRF != ""
                    || goodsParam.SupplierCdBeginRF != 0
                    || goodsParam.SupplierCdEndRF != 0
                    || goodsParam.UpdateDateTimeBegin != 0
                    || goodsParam.UpdateDateTimeEnd != 0
                )
                {
                    isInput = true;
                }
            }
            //在庫マスタ抽出条件
            else if (wkType.Equals(typeof(APStockProcParamWork)))
            {
                APStockProcParamWork stockParam = (APStockProcParamWork)objWork;
                if (stockParam.BLGloupCodeBeginRF != 0
                    || stockParam.BLGloupCodeEndRF != 0
                    || stockParam.GoodsMakerCdBeginRF != 0
                    || stockParam.GoodsMakerCdEndRF != 0
                    || stockParam.GoodsNoBeginRF != ""
                    || stockParam.GoodsNoEndRF != ""
                    || stockParam.SupplierCdBeginRF != 0
                    || stockParam.SupplierCdEndRF != 0
                    || stockParam.UpdateDateTimeBegin != 0
                    || stockParam.UpdateDateTimeEnd != 0
                    || stockParam.WarehouseCodeBeginRF != ""
                    || stockParam.WarehouseCodeEndRF != ""
                    || stockParam.WarehouseShelfNoBeginRF != ""
                    || stockParam.WarehouseShelfNoEndRF != ""
                )
                {
                    isInput = true;
                }
            }
            //仕入先マスタ抽出条件
            else if (wkType.Equals(typeof(APSupplierProcParamWork)))
            {
                APSupplierProcParamWork suppParam = (APSupplierProcParamWork)objWork;
                if (suppParam.SupplierCdBeginRF != 0
                    || suppParam.SupplierCdEndRF != 0
                    || suppParam.UpdateDateTimeBegin != 0
                    || suppParam.UpdateDateTimeEnd != 0
                )
                {
                    isInput = true;
                }
            }
            //掛率マスタ抽出条件
            else if (wkType.Equals(typeof(APRateProcParamWork)))
            {
                APRateProcParamWork rateParam = (APRateProcParamWork)objWork;
                if (rateParam.BLGoodsCodeBeginRF != 0
                    || rateParam.BLGoodsCodeEndRF != 0
                    || rateParam.CustomerCodeBeginRF != 0
                    || rateParam.CustomerCodeEndRF != 0
                    || rateParam.CustRateGrpCodeBeginRF != 0
                    || rateParam.CustRateGrpCodeEndRF != 0
                    || rateParam.GoodsMakerCdBeginRF != 0
                    || rateParam.GoodsMakerCdEndRF != 0
                    || rateParam.GoodsNoBeginRF != ""
                    || rateParam.GoodsNoEndRF != ""
                    || rateParam.GoodsRateGrpCodeBeginRF != 0
                    || rateParam.GoodsRateGrpCodeEndRF != 0
                    || rateParam.GoodsRateRankBeginRF != ""
                    || rateParam.GoodsRateRankEndRF != ""
                    || rateParam.RateSettingDivideRF != ""
                    || rateParam.SetFunRF != ""
                    || rateParam.SupplierCdBeginRF != 0
                    || rateParam.SupplierCdEndRF != 0
                    || rateParam.UnitPriceKindRF != ""
                    || rateParam.UpdateDateTimeBegin != 0
                    || rateParam.UpdateDateTimeEnd != 0
                    // --- ADD 2012/07/26 ------------------------->>>>>
                    || rateParam.SectionCodeBeginRF != ""
                    || rateParam.SectionCodeEndRF != ""
                    // --- ADD 2012/07/26 -------------------------<<<<<
                )
                {
                    isInput = true;
                }
            }
            // --- ADD 2012/07/26 ------------------------->>>>>
            //従業員設定マスタ抽出条件
            else if (wkType.Equals(typeof(APEmployeeProcParamWork)))
            {
                APEmployeeProcParamWork employeeParam = (APEmployeeProcParamWork)objWork;
                if (employeeParam.UpdateDateTimeBegin != 0
                    || employeeParam.UpdateDateTimeEnd != 0
                    || employeeParam.BelongSectionCdBeginRF != ""
                    || employeeParam.BelongSectionCdEndRF != ""
                    || employeeParam.EmployeeCdBeginRF != ""
                    || employeeParam.EmployeeCdEndRF != ""
                )
                {
                    isInput = true;
                }
            }
            //結合マスタ抽出条件
            else if (wkType.Equals(typeof(APJoinPartsUProcParamWork)))
            {
                APJoinPartsUProcParamWork joinPartsUParam = (APJoinPartsUProcParamWork)objWork;
                if (joinPartsUParam.UpdateDateTimeBegin != 0
                    || joinPartsUParam.UpdateDateTimeEnd != 0
                    || joinPartsUParam.JoinSourPartsNoWithHBeginRF != ""
                    || joinPartsUParam.JoinSourPartsNoWithHEndRF != ""
                    || joinPartsUParam.JoinSourceMakerCodeBeginRF != 0
                    || joinPartsUParam.JoinSourceMakerCodeEndRF != 0
                    || joinPartsUParam.JoinDispOrderBeginRF != 0
                    || joinPartsUParam.JoinDispOrderEndRF != 0
                    || joinPartsUParam.JoinDestMakerCodeBeginRF != 0
                    || joinPartsUParam.JoinDestMakerCodeEndRF != 0
                )
                {
                    isInput = true;
                }
            }
            //ユーザーガイドマスタ(販売区分)
            else if (wkType.Equals(typeof(APUserGdBuyDivUProcParamWork)))
            {
                APUserGdBuyDivUProcParamWork userGdBuyDivUParam = (APUserGdBuyDivUProcParamWork)objWork;
                if (userGdBuyDivUParam.UpdateDateTimeBegin != 0
                    || userGdBuyDivUParam.UpdateDateTimeEnd != 0
                    || userGdBuyDivUParam.GuideCodeBeginRF != 0
                    || userGdBuyDivUParam.GuideCodeEndRF != 0
                )
                {
                    isInput = true;
                }
            }
            // --- ADD 2012/07/26 -------------------------<<<<<
            return isInput;
        }

        /// <summary>
        /// 拠点管理設定情報を取得して、送信処理を行う
        /// </summary>
        /// <param name="extractCondDiv">抽出条件区分</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="paramList">送受信抽出条件履歴ログデータリスト</param>
        /// <param name="pmEnterpriseCode">送信先企業コード</param>
        /// <param name="masterDivList">マスタ区分リスト</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <param name="beginningTime">開始時間</param>
        /// <param name="endingTime">終了時間</param>
        /// <param name="startTime">シンク時間</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updSectionCode">ログインユーザー拠点コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="searchCountWork">検索計数</param>
        /// <param name="isEmpty">空の判断</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、送信処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        //public int SendProc(Int32 connectPointDiv, ArrayList masterDivList, ArrayList masterNameList, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, 
        //                       string updEmployeeCode, string baseCode, out MstSearchCountWorkWork searchCountWork, out bool isEmpty)
        //-----DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        public int SendProc(Int32 extractCondDiv, Int32 connectPointDiv, ArrayList paramList, string pmEnterpriseCode, ArrayList masterDivList, ArrayList masterNameList, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, 
                               string updSectionCode, string updEmployeeCode, string baseCode, out MstSearchCountWorkWork searchCountWork, out bool isEmpty)
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        {
            string retMessage;
            isEmpty = false;
            searchCountWork = new MstSearchCountWorkWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            DateTime syncExecDt = new DateTime();
            DateTime minSyncExecDt = new DateTime(); //ADD 2011/07/25
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            // 抽出・更新コントロール処理リモートを呼び出して抽出データを取得し、抽出結果クラスを返します。
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            //int status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);//DEL 2011/07/25
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            int status = 0;
            int no = 0;
            if (extractCondDiv == 0)
            {
                //差分送信の場合、
                status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, updSectionCode, beginningTime, endingTime, ref retCSAList, out no, out retMessage);
            }
            else
            {
                //-----ADD 2011.0906 #24364----->>>>>
                status = _iAPMSTControlDB.GetObjCount(masterDivList, enterpriseCode, paramList, out searchCountWork, out retMessage);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (searchCountWork.ErrorKubun == -3 || searchCountWork.ErrorKubun == -4))
                {
                    return status;
                }
                //-----ADD 2011.0906 #24364-----<<<<<
                status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, updSectionCode, paramList, ref retCSAList, out no, out retMessage);
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            // 抽出結果正常の場合、データ変換処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

                // データ変換処理
                //syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList); //DEL 2011/07/25
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out syncExecDt, out minSyncExecDt, out isEmpty, retCSAList);
                //ADD 2011/09/15 fengwx #23934----->>>>>
                int updListCount = 0;
                foreach (ArrayList childList in updCSAList)
                {
                    updListCount += childList.Count;
                }
                if (updListCount > 0 && updListCount - searchCountWork.RateProtyMngCount - searchCountWork.PartsPosCodeUCount - searchCountWork.BLCodeGuideCount == 0)
                {
                    //掛率優先管理マスタ、部位コードマスタ（ユーザー登録）、BLコードガイドマスタ
                    //三つのテーブルだけを送信する場合、
                    //送信対象開始日時＝画面.開始日付+開始時間
                    //送信対象終了日時＝画面.終了日付+終了時間
                    minSyncExecDt = new DateTime(beginningTime).AddTicks(1);
                    syncExecDt = new DateTime(endingTime);
                }
                //ADD 2011/09/15 fengwx #23934-----<<<<<
                if (extractCondDiv == 1)
                {
                    //条件送信の場合、在庫マスタと商品マスタの件数をチェックを行う
                    if (searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount + searchCountWork.IsolIslandPrcCount > MAX_CNT)
                    {
                        searchCountWork.ErrorKubun = -3;
                        return status;
                    }
                    else if (searchCountWork.StockCount > MAX_CNT)
                    {
                        searchCountWork.ErrorKubun = -4;
                        return status;
                    }
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                if (isEmpty)
                {
                    // MOD 2009/06/17 ---->>>
                    // 抽出結果CustomSerializeArrayListの内容が存在しない場合、
                    //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "抽出対象のデータが存在しません。");
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
                    // MOD 2009/06/17 ----<<<
                    return status;
                }
                else
                {
                    // データ更新処理
                    if (connectPointDiv == 0)
                    {
                        this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();
                        // データ更新処理
                        //status = _iMstDCControlDB.Update(ref updCSAList, enterpriseCode, out retMessage); //DEL 2011/07/25
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        ArrayList objList = new ArrayList();

                        //**********************送受信履歴ログデータの設定**********************//
                        SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();
                        //企業コード:ログインユーザーの企業コード
                        sndRcvHisWork.EnterpriseCode = enterpriseCode;
                        //論理削除区分
                        sndRcvHisWork.LogicalDeleteCode = 0;
                        //拠点コード:ログインユーザーの拠点コード
                        sndRcvHisWork.SectionCode = updSectionCode;
                        //送受信履歴ログ送信番号
                        sndRcvHisWork.SndRcvHisConsNo = no;
                        //送信日時:システム日付
                        sndRcvHisWork.SendDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                        //送受信ログ利用区分:｢0:拠点管理｣
                        sndRcvHisWork.SndLogUseDiv = 0;
                        //送受信区分:｢0:送信｣
                        sndRcvHisWork.SendOrReceiveDivCd = 0;
                        //種別:｢1:マスタ｣
                        sndRcvHisWork.Kind = 1;
                        //送受信ログ抽出条件区分
                        sndRcvHisWork.SndLogExtraCondDiv = extractCondDiv;
                        //送信対象拠点コード
                        sndRcvHisWork.ExtraObjSecCode = "";
                        //送信対象開始日時、送信対象終了日時
                        if (extractCondDiv == 0)
                        {
                            sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                            sndRcvHisWork.SndObjEndDate = syncExecDt;
                        }
                        else
                        {
                            if (beginningTime != 0 && endingTime != 0)
                            {
                                sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvHisWork.SndObjEndDate = syncExecDt;
                            }
                            else
                            {
                                sndRcvHisWork.SndObjStartDate = DateTime.MinValue;
                                sndRcvHisWork.SndObjEndDate = DateTime.MinValue;
                            }
                        }
                        //送信先企業コード
                        sndRcvHisWork.SendDestEpCode = pmEnterpriseCode;
                        //送信先拠点コード
                        sndRcvHisWork.SendDestSecCode = baseCode;
                        objList.Add(sndRcvHisWork);
                        //**********************送受信履歴ログデータの設定**********************//

                        //******************送受信抽出条件履歴ログデータの設定******************//
                        ArrayList sndRcvCondHisList = new ArrayList();
                        //抽出条件区分が｢条件｣の場合のみ、送受信抽出条件履歴ログデータを登録可能
                        if (extractCondDiv == 1)
                        {
                            APCustomerProcParamWork customerProcParam = null;
                            APGoodsProcParamWork goodsProcParam = null;
                            APStockProcParamWork stockProcParam = null;
                            APSupplierProcParamWork supplierProcParam = null;
                            APRateProcParamWork rateProcParam = null;
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            APEmployeeProcParamWork employeeProcParam = null;
                            APJoinPartsUProcParamWork joinPartsUProcParam = null;
                            APUserGdBuyDivUProcParamWork userGdBuyDivUProcParam = null;
                            // --- ADD 2012/07/26 -------------------------<<<<<

                            for (int i = 0; i < paramList.Count; i++)
                            {
                                Type paramType = paramList[i].GetType();
                                if (paramType.Equals(typeof(APCustomerProcParamWork)))
                                {
                                    customerProcParam = (APCustomerProcParamWork)paramList[i];
                                }
                                if (paramType.Equals(typeof(APGoodsProcParamWork)))
                                {
                                    goodsProcParam = (APGoodsProcParamWork)paramList[i];
                                }
                                if (paramType.Equals(typeof(APStockProcParamWork)))
                                {
                                    stockProcParam = (APStockProcParamWork)paramList[i];
                                }
                                if (paramType.Equals(typeof(APSupplierProcParamWork)))
                                {
                                    supplierProcParam = (APSupplierProcParamWork)paramList[i];
                                }
                                if (paramType.Equals(typeof(APRateProcParamWork)))
                                {
                                    rateProcParam = (APRateProcParamWork)paramList[i];
                                }
                                // --- ADD 2012/07/26 ------------------------->>>>>
                                if (paramType.Equals(typeof(APEmployeeProcParamWork)))
                                {
                                    employeeProcParam = (APEmployeeProcParamWork)paramList[i];
                                }
                                if (paramType.Equals(typeof(APJoinPartsUProcParamWork)))
                                {
                                    joinPartsUProcParam = (APJoinPartsUProcParamWork)paramList[i];
                                }
                                if (paramType.Equals(typeof(APUserGdBuyDivUProcParamWork)))
                                {
                                    userGdBuyDivUProcParam = (APUserGdBuyDivUProcParamWork)paramList[i];
                                }
                                // --- ADD 2012/07/26 -------------------------<<<<<
                            }
                            int derivNo = 1;
                            //得意先マスタ抽出条件
                            if (customerProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APCustomerProcParamToSndRcvEtrWork(customerProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_CUSTOMER;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //商品マスタ抽出条件
                            if (goodsProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APGoodsProcParamToSndRcvEtrWork(goodsProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_GOODS;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //在庫マスタ抽出条件
                            if (stockProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APStockProcParamToSndRcvEtrWork(stockProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_STOCK;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //仕入先マスタ抽出条件
                            if (supplierProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APSupplierProcParamToSndRcvEtrWork(supplierProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_SUPPLIER;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //掛率マスタ抽出条件
                            if (rateProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APRateProcParamToSndRcvEtrWork(rateProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_RATE;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            // --- ADD 2012/07/26 ------------------------->>>>>
                            //従業員マスタ抽出条件
                            if (employeeProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APEmployeeProcParamToSndRcvEtrWork(employeeProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_EMPLOYEE;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //結合マスタ抽出条件
                            if (joinPartsUProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APJoinPartsUProcParamToSndRcvEtrWork(joinPartsUProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_JOINPARTSU;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            //ユーザーガイドマスタ(販売区分)抽出条件
                            if (userGdBuyDivUProcParam != null)
                            {
                                SndRcvEtrWork sndRcvEtrWork = APUserGdBuyDivUProcParamToSndRcvEtrWork(userGdBuyDivUProcParam);
                                sndRcvEtrWork.EnterpriseCode = enterpriseCode;
                                sndRcvEtrWork.SectionCode = updSectionCode;
                                sndRcvEtrWork.LogicalDeleteCode = 0;
                                sndRcvEtrWork.SndRcvHisConsNo = sndRcvHisWork.SndRcvHisConsNo;
                                sndRcvEtrWork.SndRcvHisConsDerivNo = derivNo;
                                sndRcvEtrWork.Kind = 1;
                                sndRcvEtrWork.FileId = FILEID_USERGDU;
                                sndRcvEtrWork.ExtraStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvEtrWork.ExtraEndDate = syncExecDt;
                                sndRcvCondHisList.Add(sndRcvEtrWork);
                                derivNo++;
                            }
                            // --- ADD 2012/07/26 -------------------------<<<<<
                        }
                        objList.Add(sndRcvCondHisList);
                        //******************送受信抽出条件履歴ログデータの設定******************//

                        ArrayList paraList = new ArrayList();
                        paraList.Add(objList);
                        status = _iMstDCControlDB.Update(ref updCSAList, enterpriseCode, paraList, out retMessage);
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                    }
                    else
                    {
                        this._iMstTotalMachControlDB = MstTotalMachControlDB.GetMstTotalMachControlDB();
                        // データ更新処理
                        status = _iMstTotalMachControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);
                    }

                }

            }
            // 抽出処理がエラーの場合、「4　操作履歴ログデータへの書き込み」へ続ける。
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "抽出エラー(拠点：" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + baseCode + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                searchCountWork.ErrorKubun = -1;
                return status;
            }

            // status＝0正常の場合、「4　操作履歴ログデータへの書き込み」
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string logStr = string.Empty;
                foreach (SecMngSndRcvWork work in masterNameList)
                {
                    logStr = logStr + MARK_3 + work.MasterName + MARK_3;
                    // 拠点設定マスタ
                    if (MST_SECINFOSET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SecInfoSetCount) + MARK_2;
                    }
                    // 部門設定マスタ
                    else if (MST_SUBSECTION.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SubSectionCount) + MARK_2;
                    }
                    // 倉庫設定マスタ
                    else if (MST_WAREHOUSE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.WarehouseCount) + MARK_2;
                    }
                    // 従業員設定マスタ
                    else if (MST_EMPLOYEE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ(販売エリア区分）
                    else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdAreaDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（業務区分）
                    else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBusDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（業種）
                    else if (MST_USERGDCATEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdCateUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（職種）
                    else if (MST_USERGDBUSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBusUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（商品区分）
                    else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（得意先掛率グループ）
                    else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（銀行）
                    else if (MST_USERGDBANKU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBankUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（価格区分）
                    else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdPriDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（納品区分）
                    else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdDeliDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（商品大分類）
                    else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsBigUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（販売区分）
                    else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBuyDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（在庫管理区分１）
                    else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivOUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（在庫管理区分２）
                    else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivTUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（返品理由）
                    else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdReturnReaUCount) + MARK_2;
                    }
                    // 掛率優先管理マスタ
                    else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.RateProtyMngCount) + MARK_2;
                    }
                    // 掛率マスタ
                    else if (MST_RATE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.RateCount) + MARK_2;
                    }
                    // 売上目標設定マスタ
                    else if (MST_SALESTARGET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount) + MARK_2;
                    }
                    // 得意先マスタ
                    else if (MST_CUSTOME.Equals(work.MasterName))
                    {
                        // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                        //logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                        //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount) + MARK_2;
                        logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                            + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount) + MARK_2;
                        // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                    }
                    // 仕入先マスタ
                    else if (MST_SUPPLIER.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SupplierCount) + MARK_2;
                    }
                    // 結合マスタ
                    else if (MST_JOINPARTSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.JoinPartsUCount) + MARK_2;
                    }
                    // セットマスタ
                    else if (MST_GOODSSET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsSetCount) + MARK_2;
                    }
                    // ＴＢＯマスタ
                    else if (MST_TBOSEARCHU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.TBOSearchUCount) + MARK_2;
                    }
                    // 車種マスタ
                    else if (MST_MODELNAMEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.ModelNameUCount) + MARK_2;
                    }
                    // ＢＬコードマスタ
                    else if (MST_BLGOODSCDU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLGoodsCdUCount) + MARK_2;
                    }
                    // メーカーマスタ
                    else if (MST_MAKERU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.MakerUCount) + MARK_2;
                    }
                    // 商品中分類マスタ
                    else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsMGroupUCount) + MARK_2;
                    }
                    // グループコードマスタ
                    else if (MST_BLGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLGroupUCount) + MARK_2;
                    }
                    // BLコードガイドマスタ
                    else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLCodeGuideCount) + MARK_2;
                    }
                    // 商品マスタ
                    else if (MST_GOODSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                            + searchCountWork.IsolIslandPrcCount) + MARK_2;
                    }
                    // 在庫マスタ
                    else if (MST_STOCK.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.StockCount) + MARK_2;
                    }
                    // 代替マスタ
                    else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.PartsSubstUCount) + MARK_2;
                    }
                    // 部位マスタ
                    else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.PartsPosCodeUCount) + MARK_2;
                    }
                }

                logStr = logStr.Trim();
                logStr = logStr.Substring(0, logStr.Length - 1);
                string logStrTemp = string.Empty;

                Encoding myEncoding = Encoding.GetEncoding("shift-jis");
                byte[] SourceStr_Bytes;
                byte[] CutStr_Bytes = new byte[500];


                SourceStr_Bytes = myEncoding.GetBytes(logStr);
                Int32 logStrLen = SourceStr_Bytes.Length;

                for (; 0 < logStrLen; )
                {
                    if (logStrLen > 500)
                    {
                        Array.Copy(SourceStr_Bytes, 0, CutStr_Bytes, 0, 500);
                        logStrTemp = myEncoding.GetString(CutStr_Bytes);
                        logStrTemp = logStrTemp.Substring(0, logStrTemp.LastIndexOf(COUNTNAME));
                        logStrTemp = logStrTemp + COUNTNAME;
                        logStrTemp = logStrTemp.Trim();
                        operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                            logStrTemp, "正常(拠点：" + baseCode + ")");
                        logStr = logStr.Substring(logStrTemp.LastIndexOf(COUNTNAME) + 2);
                        logStr = logStr.Trim();

                        SourceStr_Bytes = myEncoding.GetBytes(logStr);
                        logStrLen = logStrLen - 500;
                    }
                    else
                    {
                        logStr = logStr.Trim();
                        if (!string.IsNullOrEmpty(logStr))
                        {
                            if (logStr.Substring(0, 1).Equals("、"))
                            {
                                logStr = logStr.Substring(2);
                            }
                            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                                logStr, "正常(拠点：" + baseCode + ")");
                        }
                        break;
                    }
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                searchCountWork.ErrorKubun = -2;
                return status;
            }
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + baseCode + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                //searchCountWork.ErrorKubun = -1;//DEL 2011/09/05 #24047
                searchCountWork.ErrorKubun = -5;//ADD 2011/09/05 #24047
                return status;
            }
            // 拠点管理設定マスタの更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 上記抽出した拠点コードに対して全データの更新日付参照し、取得レコードの最新レコード日付を算出します。
                //if (startTime < syncExecDt)//DEL 2011/08/30 #24191 マスタ送信（条件送信）の送信実行日について
                if (startTime < syncExecDt && extractCondDiv != 1)//ADD 2011/08/30 #24191 マスタ送信（条件送信）の送信実行日について
                {
                    // 拠点管理設定マスタの更新
                    this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                    status = _iAPMSTControlDB.UpdateSecMngSet(enterpriseCode, baseCode, updEmployeeCode, syncExecDt, out retMessage);
                }
            }
            return status;

        }

        /// <summary>
        /// 拠点管理送受信対象データPramData→UIData移項処理
        /// </summary>
        /// <param name="secMngSndRcvWork">D拠点管理送受信対象データ</param>
        /// <returns>AP拠点管理送受信対象データ</returns>
        public DCSecMngSndRcvWork SearchDataFromUpdData(SecMngSndRcvWork secMngSndRcvWork)
        {
            if (secMngSndRcvWork == null)
            {
                return null;
            }

            DCSecMngSndRcvWork dcSecInfoSetWork = new DCSecMngSndRcvWork();
            // 拠点情報設定データ変換
            dcSecInfoSetWork.CreateDateTime = secMngSndRcvWork.CreateDateTime;
            dcSecInfoSetWork.UpdateDateTime = secMngSndRcvWork.UpdateDateTime;
            dcSecInfoSetWork.EnterpriseCode = secMngSndRcvWork.EnterpriseCode;
            dcSecInfoSetWork.FileHeaderGuid = secMngSndRcvWork.FileHeaderGuid;
            dcSecInfoSetWork.UpdEmployeeCode = secMngSndRcvWork.UpdEmployeeCode;
            dcSecInfoSetWork.UpdAssemblyId1 = secMngSndRcvWork.UpdAssemblyId1;
            dcSecInfoSetWork.UpdAssemblyId2 = secMngSndRcvWork.UpdAssemblyId2;
            dcSecInfoSetWork.LogicalDeleteCode = secMngSndRcvWork.LogicalDeleteCode;
            dcSecInfoSetWork.DisplayOrder = secMngSndRcvWork.DisplayOrder;
            dcSecInfoSetWork.MasterName = secMngSndRcvWork.MasterName;
            dcSecInfoSetWork.FileId = secMngSndRcvWork.FileId;
            dcSecInfoSetWork.FileNm = secMngSndRcvWork.FileNm;
            dcSecInfoSetWork.UserGuideDivCd = secMngSndRcvWork.UserGuideDivCd;
            dcSecInfoSetWork.SecMngSendDiv = secMngSndRcvWork.SecMngSendDiv;
            dcSecInfoSetWork.SecMngRecvDiv = secMngSndRcvWork.SecMngRecvDiv;

            return dcSecInfoSetWork;
        }

        /// <summary>
        /// 拠点管理設定情報を取得して、受信処理を行う
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="masterDivList">マスタ区分リスト</param>
        /// <param name="masterDtlDivList">マスタ明細区分リスト</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <param name="beginningTime">開始時間</param>
        /// <param name="endingTime">終了時間</param>
        /// <param name="secMngSetArrList">シンク時間リスト</param>
        /// <param name="paramList">マスタ抽出条件リスト</param>
        /// <param name="sndRcvHisWork">送受信履歴ログデータワーク</param>
        /// <param name="pmEnterpriseCode">PM企業コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="baseCode">拠点コート</param>
        /// <param name="searchCountWork">検索計数</param>
        /// <param name="isEmpty">空の判断</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、受信処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        //public int ReceProc(string enterpriseCode, Int32 connectPointDiv, ArrayList masterDivList, ArrayList masterDtlDivList, ArrayList masterNameList, Int64 beginningTime, Int64 endingTime, ArrayList secMngSetArrList, string pmEnterpriseCode,//DEL 2011/07/25
                       //string updEmployeeCode, string baseCode, out MstSearchCountWorkWork searchCountWork, out bool isEmpty)//DEL 2011/07/25
        public int ReceProc(string enterpriseCode, Int32 connectPointDiv, ArrayList masterDivList, ArrayList masterDtlDivList, ArrayList masterNameList, Int64 beginningTime, Int64 endingTime, ArrayList secMngSetArrList, ArrayList paramList, //ADD 2011/07/25
                        SndRcvHisWork sndRcvHisWork, string pmEnterpriseCode, string updEmployeeCode, string baseCode, out MstSearchCountWorkWork searchCountWork, out bool isEmpty)
        {
            string retMessage;
            isEmpty = false;
            DateTime syncExecDt = new DateTime();
            searchCountWork = new MstSearchCountWorkWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string updBaseCode = baseCode;
            baseCode = baseCode.Trim();

            ArrayList masterDivTempList = new ArrayList();
            DCSecMngSndRcvWork dcSecMngSndRcvWork = null;
            foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
            {
                dcSecMngSndRcvWork = this.SearchDataFromUpdData(secMngSndRcvWork);
                masterDivTempList.Add(dcSecMngSndRcvWork);
            }

            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            ArrayList condParamList = new ArrayList();
            foreach(SndRcvEtrWork sndRcvEtrWork in paramList)
            {
                if (sndRcvEtrWork.FileId.Equals(FILEID_CUSTOMER))
                {
                    CustomerProcParamWork customerProcParamWork = SndRcvEtrWorkToCustomerProcParamWork(sndRcvEtrWork);
                    customerProcParamWork.UpdateDateTimeBegin = beginningTime;
                    customerProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(customerProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_GOODS))
                {
                    GoodsProcParamWork goodsProcParamWork = SndRcvEtrWorkToGoodsProcParamWork(sndRcvEtrWork);
                    goodsProcParamWork.UpdateDateTimeBegin = beginningTime;
                    goodsProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(goodsProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_STOCK))
                {
                    StockProcParamWork stockProcParamWork = SndRcvEtrWorkToStockProcParamWork(sndRcvEtrWork);
                    stockProcParamWork.UpdateDateTimeBegin = beginningTime;
                    stockProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(stockProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_SUPPLIER))
                {
                    SupplierProcParamWork supplierProcParamWork = SndRcvEtrWorkToSupplierProcParamWork(sndRcvEtrWork);
                    supplierProcParamWork.UpdateDateTimeBegin = beginningTime;
                    supplierProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(supplierProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_RATE))
                {
                    RateProcParamWork rateProcParamWork = SndRcvEtrWorkToRateProcParamWork(sndRcvEtrWork);
                    rateProcParamWork.UpdateDateTimeBegin = beginningTime;
                    rateProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(rateProcParamWork);
                }
                // --- ADD 2012/07/26 ------------------------->>>>>
                else if (sndRcvEtrWork.FileId.Equals(FILEID_EMPLOYEE))
                {
                    EmployeeProcParamWork employeeProcParamWork = SndRcvEtrWorkToEmployeeProcParamWork(sndRcvEtrWork);
                    employeeProcParamWork.UpdateDateTimeBegin = beginningTime;
                    employeeProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(employeeProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_JOINPARTSU))
                {
                    JoinPartsUProcParamWork joinPartsUProcParamWork = SndRcvEtrWorkToJoinPartsUProcParamWork(sndRcvEtrWork);
                    joinPartsUProcParamWork.UpdateDateTimeBegin = beginningTime;
                    joinPartsUProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(joinPartsUProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_USERGDU))
                {
                    UserGdBuyDivUProcParamWork userGdBuyDivUProcParamWork = SndRcvEtrWorkToUserGdBuyDivUProcParamWork(sndRcvEtrWork);
                    userGdBuyDivUProcParamWork.UpdateDateTimeBegin = beginningTime;
                    userGdBuyDivUProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(userGdBuyDivUProcParamWork);
                }
                // --- ADD 2012/07/26 -------------------------<<<<<
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

            // 抽出・更新コントロール処理リモートを呼び出して抽出データを取得し、抽出結果クラスを返します。
            // データ更新処理
            if (connectPointDiv == 0)
            {
                this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();
                // データ抽出処理
                //status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);//DEL 2011/07/25
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                if (sndRcvHisWork.SndLogExtraCondDiv == 0)
                {
                    status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);
                }
                else
                {
                    status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, condParamList, ref retCSAList, out retMessage);
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
            else
            {
                this._iMstTotalMachControlDB = MstTotalMachControlDB.GetMstTotalMachControlDB();
                // データ抽出処理
                status = _iMstTotalMachControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);
            }

            // 抽出結果正常の場合、データ変換処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

                // データ変換処理
                syncExecDt = this.ReceDivisionCustomSerializeArrayList(out updCSAList, retCSAList);
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                if (updCSAList == null || updCSAList.Count <= 0)
                {
                    isEmpty = true;
                    return status;
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                // データ更新処理
                this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                status = _iAPMSTControlDB.Update(enterpriseCode, masterDivList, masterDtlDivList, ref updCSAList, pmEnterpriseCode, out isEmpty, out searchCountWork, out retMessage);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (isEmpty)
                    {
                        // 抽出結果CustomSerializeArrayListの内容が存在しない場合、
                        return status;
                    }
                    else
                    {
                        string logStr = string.Empty;
                        foreach (SecMngSndRcvWork work in masterNameList)
                        {
                            logStr = logStr + MARK_3 + work.MasterName + MARK_3;
                            // 拠点設定マスタ
                            if (MST_SECINFOSET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SecInfoSetCount) + MARK_2;
                            }
                            // 部門設定マスタ
                            else if (MST_SUBSECTION.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SubSectionCount) + MARK_2;
                            }
                            // 倉庫設定マスタ
                            else if (MST_WAREHOUSE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.WarehouseCount) + MARK_2;
                            }
                            // 従業員設定マスタ
                            else if (MST_EMPLOYEE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ(販売エリア区分）
                            else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdAreaDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（業務区分）
                            else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBusDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（業種）
                            else if (MST_USERGDCATEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCateUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（職種）
                            else if (MST_USERGDBUSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBusUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（商品区分）
                            else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（得意先掛率グループ）
                            else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（銀行）
                            else if (MST_USERGDBANKU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBankUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（価格区分）
                            else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdPriDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（納品区分）
                            else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdDeliDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（商品大分類）
                            else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBuyDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（販売区分）
                            else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivOUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（在庫管理区分１）
                            else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivTUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（在庫管理区分２）
                            else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdReturnReaUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（返品理由）
                            else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                            }
                            // 掛率優先管理マスタ
                            else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.RateProtyMngCount) + MARK_2;
                            }
                            // 掛率マスタ
                            else if (MST_RATE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.RateCount) + MARK_2;
                            }
                            // 売上目標設定マスタ
                            else if (MST_SALESTARGET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount) + MARK_2;
                            }
                            // 得意先マスタ
                            else if (MST_CUSTOME.Equals(work.MasterName))
                            {
                                // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                                //logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount) + MARK_2;
                                logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount) + MARK_2;
                                // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                            }
                            // 仕入先マスタ
                            else if (MST_SUPPLIER.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SupplierCount) + MARK_2;
                            }
                            // 結合マスタ
                            else if (MST_JOINPARTSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.JoinPartsUCount) + MARK_2;
                            }
                            // セットマスタ
                            else if (MST_GOODSSET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsSetCount) + MARK_2;
                            }
                            // ＴＢＯマスタ
                            else if (MST_TBOSEARCHU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.TBOSearchUCount) + MARK_2;
                            }
                            // 車種マスタ
                            else if (MST_MODELNAMEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.ModelNameUCount) + MARK_2;
                            }
                            // ＢＬコードマスタ
                            else if (MST_BLGOODSCDU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLGoodsCdUCount) + MARK_2;
                            }
                            // メーカーマスタ
                            else if (MST_MAKERU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.MakerUCount) + MARK_2;
                            }
                            // 商品中分類マスタ
                            else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsMGroupUCount) + MARK_2;
                            }
                            // グループコードマスタ
                            else if (MST_BLGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLGroupUCount) + MARK_2;
                            }
                            // BLコードガイドマスタ
                            else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLCodeGuideCount) + MARK_2;
                            }
                            // 商品マスタ
                            else if (MST_GOODSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                                    + searchCountWork.IsolIslandPrcCount) + MARK_2;
                            }
                            // 在庫マスタ
                            else if (MST_STOCK.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.StockCount) + MARK_2;
                            }
                            // 代替マスタ
                            else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.PartsSubstUCount) + MARK_2;
                            }
                            // 部位マスタ
                            else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.PartsPosCodeUCount) + MARK_2;
                            }
                        }

                        logStr = logStr.Trim();
                        logStr = logStr.Substring(0, logStr.Length - 1);
                        string logStrTemp = string.Empty;

                        Encoding myEncoding = Encoding.GetEncoding("shift-jis");
                        byte[] SourceStr_Bytes;
                        byte[] CutStr_Bytes = new byte[500];


                        SourceStr_Bytes = myEncoding.GetBytes(logStr);
                        Int32 logStrLen = SourceStr_Bytes.Length;

                        for (; 0 < logStrLen; )
                        {
                            if (logStrLen > 500)
                            {
                                Array.Copy(SourceStr_Bytes, 0, CutStr_Bytes, 0, 500);
                                logStrTemp = myEncoding.GetString(CutStr_Bytes);
                                logStrTemp = logStrTemp.Substring(0, logStrTemp.LastIndexOf(COUNTNAME));
                                logStrTemp = logStrTemp + COUNTNAME;
                                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                                    logStrTemp, "正常(拠点：" + baseCode + ")");
                                logStr = logStr.Substring(logStrTemp.LastIndexOf(COUNTNAME) + 2);
                                logStr = logStr.Trim();

                                SourceStr_Bytes = myEncoding.GetBytes(logStr);
                                logStrLen = logStrLen - 500;
                            }
                            else
                            {
                                logStr = logStr.Trim();
                                if (!string.IsNullOrEmpty(logStr))
                                {
                                    if (logStr.Substring(0, 1).Equals("、"))
                                    {
                                        logStr = logStr.Substring(2);
                                    }
                                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                    logStr, "正常(拠点：" + baseCode + ")");
                                }
                                break;
                            }
                        }
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    searchCountWork.ErrorKubun = -2;
                    return status;
                }
                else
                {
                    // MOD 2009/06/17 ---->>>
                    //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCode + ")");
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + baseCode + ")", string.Empty);
                    // MOD 2009/06/17 ----<<<
                    searchCountWork.ErrorKubun = -1;
                    return status;
                }
            }
            // 抽出処理がエラーの場合、「4　操作履歴ログデータへの書き込み」へ続ける。
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "抽出エラー(拠点：" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + baseCode + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                searchCountWork.ErrorKubun = -1;
                return status;
            }

            // 拠点管理設定マスタの更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
                //DateTime startTime = new DateTime();
                //// 上記抽出した拠点コードに対して全データの更新日付参照し、取得レコードの最新レコード日付を算出します。
                //foreach (APMSTSecMngSetWork work in secMngSetArrList)
                //{
                //    if (updBaseCode.Equals(work.SectionCode))
                //    {
                //        startTime = work.SyncExecDate;
                //        break;
                //    }
                //}
                //if (startTime < syncExecDt)
                //{
                //    // 拠点管理設定マスタの更新
                //    this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                //    status = _iAPMSTControlDB.UpdateReceSecMngSet(enterpriseCode, updBaseCode, updEmployeeCode, syncExecDt, out retMessage);
                //}
                #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //送信履歴ログデータの更新
                ArrayList updList = new ArrayList();
                //送受信区分は｢1:受信｣に更新
                sndRcvHisWork.SendOrReceiveDivCd = 1;
                updList.Add(sndRcvHisWork);
                status = _iSndRcvHisRFDB.WriteRcvHisWork(ref updList);
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
            return status;

        }

        /// <summary>
        /// 拠点管理設定情報を取得して、自動送信処理を行う
        /// </summary>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <param name="masterDivList">マスタ区分リスト</param>
        /// <param name="beginningTime">開始時間</param>
        /// <param name="endingTime">終了時間</param>
        /// <param name="startTime">シンク時間</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、自動送信処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        public int AutoServersSendProc(Int32 connectPointDiv, ArrayList masterNameList, ArrayList masterDivList, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode,
                       string updEmployeeCode, string baseCode)
        {
            string retMessage;
            bool isEmpty = false;
            MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            DateTime syncExecDt = new DateTime();
            DateTime minSyncExecDt = new DateTime(); //ADD 2011/07/25
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();
            string baseCodeLog = baseCode.Trim();

            // 抽出・更新コントロール処理リモートを呼び出して抽出データを取得し、抽出結果クラスを返します。
            this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
            //int status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);//DEL 2011/07/25
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            int no;
            string pmEnterpriseCode = string.Empty;
            //string updSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません ---------->>>>>
            string updSectionCode = string.Empty;            
            int ret = GetBelongSectionCodeFormXml(ref updSectionCode);
            if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return ret;
            }            
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません ----------<<<<<
            this.SeachPmCode(enterpriseCode, baseCode, out pmEnterpriseCode);
            
            int status = _iAPMSTControlDB.SearchCustomSerializeArrayList(masterDivList, enterpriseCode, updSectionCode, beginningTime, endingTime, ref retCSAList, out no, out retMessage);
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            // 抽出結果正常の場合、データ変換処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

                // データ変換処理
                //syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList); //DEL 2011/07/25
                this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out syncExecDt, out minSyncExecDt, out isEmpty, retCSAList); //ADD 2011/07/25
                //ADD 2011/09/15 fengwx #23934----->>>>>
                int updListCount = 0;
                foreach (ArrayList childList in updCSAList)
                {
                    updListCount += childList.Count;
                }
                if (updListCount > 0 && updListCount - searchCountWork.RateProtyMngCount - searchCountWork.PartsPosCodeUCount - searchCountWork.BLCodeGuideCount == 0)
                {
                    //掛率優先管理マスタ、部位コードマスタ（ユーザー登録）、BLコードガイドマスタ
                    //三つのテーブルだけを送信する場合、
                    //送信対象開始日時:画面.開始日付+開始時間
                    //送信対象終了日時:画面.終了日付+終了時間
                    minSyncExecDt = new DateTime(beginningTime).AddTicks(1);
                    syncExecDt = new DateTime(endingTime);
                }
                //ADD 2011/09/15 fengwx #23934-----<<<<<
                if (isEmpty)
                {
                    // 抽出結果CustomSerializeArrayListの内容が存在しない場合、
                    // MOD 2009/06/17 ---->>>
                    //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "抽出対象のデータが存在しません。");
                    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
                    // MOD 2009/06/17 ----<<<
                    return status;
                }
                else
                {
                    // データ更新処理
                    if (connectPointDiv == 0)
                    {
                        this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();
                        // データ更新処理
                        //status = _iMstDCControlDB.Update(ref updCSAList, enterpriseCode, out retMessage); //DEL 2011/07/25
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        ArrayList objList = new ArrayList();

                        //**********************送受信履歴ログデータの設定**********************//
                        SndRcvHisWork sndRcvHisWork = new SndRcvHisWork();
                        //企業コード:ログインユーザーの企業コード
                        sndRcvHisWork.EnterpriseCode = enterpriseCode;
                        //論理削除区分
                        sndRcvHisWork.LogicalDeleteCode = 0;
                        //拠点コード:ログインユーザーの拠点コード
                        sndRcvHisWork.SectionCode = updSectionCode;
                        //送受信履歴ログ送信番号
                        sndRcvHisWork.SndRcvHisConsNo = no;
                        //送信日時:システム日付
                        sndRcvHisWork.SendDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));
                        //送受信ログ利用区分:｢0:拠点管理｣
                        sndRcvHisWork.SndLogUseDiv = 0;
                        //送受信区分:｢0:送信｣
                        sndRcvHisWork.SendOrReceiveDivCd = 0;
                        //種別:｢1:マスタ｣
                        sndRcvHisWork.Kind = 1;
                        //送受信ログ抽出条件区分｢0:自動｣
                        sndRcvHisWork.SndLogExtraCondDiv = 0;
                        //送信対象拠点コード
                        sndRcvHisWork.ExtraObjSecCode = "";
                        //送信対象開始日時、送信対象終了日時
                        sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                        sndRcvHisWork.SndObjEndDate = syncExecDt;
                        //送信先企業コード
                        sndRcvHisWork.SendDestEpCode = pmEnterpriseCode;
                        //送信先拠点コード
                        sndRcvHisWork.SendDestSecCode = baseCode;
                        objList.Add(sndRcvHisWork);
                        //**********************送受信履歴ログデータの設定**********************//

                        //******************送受信抽出条件履歴ログデータの設定******************//
                        //自動送信の場合は登録しないため、空リストを設定する
                        ArrayList sndRcvCondHisList = new ArrayList();
                        objList.Add(sndRcvCondHisList);
                        //******************送受信抽出条件履歴ログデータの設定******************//

                        ArrayList paraList = new ArrayList();
                        paraList.Add(objList);
                        status = _iMstDCControlDB.Update(ref updCSAList, enterpriseCode, paraList, out retMessage);
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                    }
                    else
                    {
                        this._iMstTotalMachControlDB = MstTotalMachControlDB.GetMstTotalMachControlDB();
                        // データ更新処理
                        status = _iMstTotalMachControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);
                    }

                }

            }
            // 抽出処理がエラーの場合、「4　操作履歴ログデータへの書き込み」へ続ける。
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "抽出エラー(拠点：" + baseCodeLog + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + baseCodeLog + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                return status;
            }

            // status＝0正常の場合、「4　操作履歴ログデータへの書き込み」
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string logStr = string.Empty;
                foreach (SecMngSndRcvWork work in masterNameList)
                {
                    logStr = logStr + MARK_3 + work.MasterName + MARK_3;
                    // 拠点設定マスタ
                    if (MST_SECINFOSET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SecInfoSetCount) + MARK_2;
                    }
                    // 部門設定マスタ
                    else if (MST_SUBSECTION.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SubSectionCount) + MARK_2;
                    }
                    // 倉庫設定マスタ
                    else if (MST_WAREHOUSE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.WarehouseCount) + MARK_2;
                    }
                    // 従業員設定マスタ
                    else if (MST_EMPLOYEE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ(販売エリア区分）
                    else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdAreaDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（業務区分）
                    else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBusDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（業種）
                    else if (MST_USERGDCATEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdCateUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（職種）
                    else if (MST_USERGDBUSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBusUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（商品区分）
                    else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（得意先掛率グループ）
                    else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（銀行）
                    else if (MST_USERGDBANKU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBankUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（価格区分）
                    else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdPriDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（納品区分）
                    else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdDeliDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（商品大分類）
                    else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsBigUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（販売区分）
                    else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdBuyDivUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（在庫管理区分１）
                    else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivOUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（在庫管理区分２）
                    else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivTUCount) + MARK_2;
                    }
                    // ユーザーガイドマスタ（返品理由）
                    else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.UserGdReturnReaUCount) + MARK_2;
                    }
                    // 掛率優先管理マスタ
                    else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.RateProtyMngCount) + MARK_2;
                    }
                    // 掛率マスタ
                    else if (MST_RATE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.RateCount) + MARK_2;
                    }
                    // 売上目標設定マスタ
                    else if (MST_SALESTARGET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount) + MARK_2;
                    }
                    // 得意先マスタ
                    else if (MST_CUSTOME.Equals(work.MasterName))
                    {
                        // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                        //logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                        //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount) + MARK_2;
                        logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                            + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount) + MARK_2;
                        // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                    }
                    // 仕入先マスタ
                    else if (MST_SUPPLIER.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.SupplierCount) + MARK_2;
                    }
                    // 結合マスタ
                    else if (MST_JOINPARTSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.JoinPartsUCount) + MARK_2;
                    }
                    // セットマスタ
                    else if (MST_GOODSSET.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsSetCount) + MARK_2;
                    }
                    // ＴＢＯマスタ
                    else if (MST_TBOSEARCHU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.TBOSearchUCount) + MARK_2;
                    }
                    // 車種マスタ
                    else if (MST_MODELNAMEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.ModelNameUCount) + MARK_2;
                    }
                    // ＢＬコードマスタ
                    else if (MST_BLGOODSCDU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLGoodsCdUCount) + MARK_2;
                    }
                    // メーカーマスタ
                    else if (MST_MAKERU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.MakerUCount) + MARK_2;
                    }
                    // 商品中分類マスタ
                    else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsMGroupUCount) + MARK_2;
                    }
                    // グループコードマスタ
                    else if (MST_BLGROUPU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLGroupUCount) + MARK_2;
                    }
                    // BLコードガイドマスタ
                    else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.BLCodeGuideCount) + MARK_2;
                    }
                    // 商品マスタ
                    else if (MST_GOODSU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                            + searchCountWork.IsolIslandPrcCount) + MARK_2;
                    }
                    // 在庫マスタ
                    else if (MST_STOCK.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.StockCount) + MARK_2;
                    }
                    // 代替マスタ
                    else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.PartsSubstUCount) + MARK_2;
                    }
                    // 部位マスタ
                    else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                    {
                        logStr = logStr + this.IntConvert(searchCountWork.PartsPosCodeUCount) + MARK_2;
                    }
                }

                logStr = logStr.Trim();
                logStr = logStr.Substring(0, logStr.Length - 1);
                string logStrTemp = string.Empty;

                Encoding myEncoding = Encoding.GetEncoding("shift-jis");
                byte[] SourceStr_Bytes;
                byte[] CutStr_Bytes = new byte[500];


                SourceStr_Bytes = myEncoding.GetBytes(logStr);
                Int32 logStrLen = SourceStr_Bytes.Length;

                for (; 0 < logStrLen; )
                {
                    if (logStrLen > 500)
                    {
                        Array.Copy(SourceStr_Bytes, 0, CutStr_Bytes, 0, 500);
                        logStrTemp = myEncoding.GetString(CutStr_Bytes);
                        logStrTemp = logStrTemp.Substring(0, logStrTemp.LastIndexOf(COUNTNAME));
                        logStrTemp = logStrTemp + COUNTNAME;
                        operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                            logStrTemp, "正常(拠点：" + baseCodeLog + ")");
                        logStr = logStr.Substring(logStrTemp.LastIndexOf(COUNTNAME) + 2);
                        logStr = logStr.Trim();

                        SourceStr_Bytes = myEncoding.GetBytes(logStr);
                        logStrLen = logStrLen - 500;
                    }
                    else
                    {
                        logStr = logStr.Trim();
                        if (!string.IsNullOrEmpty(logStr))
                        {
                            if (logStr.Substring(0, 1).Equals("、"))
                            {
                                logStr = logStr.Substring(2);
                            }
                            operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                            logStr, "正常(拠点：" + baseCodeLog + ")");
                        }

                        break;
                    }
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
            {
                return status;
            }
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCodeLog + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + baseCodeLog + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                return status;
            }

            // 拠点管理設定マスタの更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 上記抽出した拠点コードに対して全データの更新日付参照し、取得レコードの最新レコード日付を算出します。
                if (startTime < syncExecDt)
                {
                    // 拠点管理設定マスタの更新
                    this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                    status = _iAPMSTControlDB.UpdateSecMngSet(enterpriseCode, baseCode, updEmployeeCode, syncExecDt, out retMessage);
                }
            }
            return status;

        }

        /// <summary>
        /// 拠点管理設定情報を取得して、自動受信処理を行う
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterDivList">マスタ区分リスト</param>
        /// <param name="masterDtlDivList">マスタ明細区分リスト</param>
        /// <param name="masterNameList">マスタ名称リスト</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="beginningTime">開始時間</param>
        /// <param name="endingTime">終了時間</param>
        /// <param name="secMngSetArrList">シンク時間リスト</param>
        /// <param name="paramList">送受信抽出条件履歴ログデータリスト</param>
        /// <param name="recSndRcvHisWork">送受信履歴ログデータワーク</param>
        /// <param name="pmEnterpriseCode">PM企業コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="baseCode">拠点コート</param>
        /// <param name="isEmpty">空判断</param>
        /// <returns>読込結果ステータス</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、自動受信処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        //public int AutoServersReceProc(string enterpriseCode, ArrayList masterNameList, ArrayList masterDivList, ArrayList masterDtlDivList, Int32 connectPointDiv, Int64 beginningTime, Int64 endingTime, ArrayList secMngSetArrList, string pmEnterpriseCode,
        //       string updEmployeeCode, string baseCode, out bool isEmpty)//DEL 2011/07/25
        public int AutoServersReceProc(string enterpriseCode, ArrayList masterNameList, ArrayList masterDivList, ArrayList masterDtlDivList, Int32 connectPointDiv, Int64 beginningTime, Int64 endingTime, ArrayList secMngSetArrList, ArrayList paramList, 
            SndRcvHisWork recSndRcvHisWork, string pmEnterpriseCode, string updEmployeeCode, string baseCode, out bool isEmpty)//ADD 2011/07/25
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string retMessage;
            string baseCodeLog = baseCode.Trim();
            isEmpty = false;
            DateTime syncExecDt = new DateTime();
            MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();

            // ↓ 2009.06.22 劉洋 add PVCS.231
            ArrayList masterDivTempList = new ArrayList();
            DCSecMngSndRcvWork dcSecMngSndRcvWork = null;
            foreach (SecMngSndRcvWork secMngSndRcvWork in masterDivList)
            {
                dcSecMngSndRcvWork = this.SearchDataFromUpdData(secMngSndRcvWork);
                masterDivTempList.Add(dcSecMngSndRcvWork);
            }
            // ↑ 2009.06.22 劉洋 add

            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            ArrayList condParamList = new ArrayList();
            foreach (SndRcvEtrWork sndRcvEtrWork in paramList)
            {
                if (sndRcvEtrWork.FileId.Equals(FILEID_CUSTOMER))
                {
                    CustomerProcParamWork customerProcParamWork = SndRcvEtrWorkToCustomerProcParamWork(sndRcvEtrWork);
                    customerProcParamWork.UpdateDateTimeBegin = beginningTime;
                    customerProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(customerProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_GOODS))
                {
                    GoodsProcParamWork goodsProcParamWork = SndRcvEtrWorkToGoodsProcParamWork(sndRcvEtrWork);
                    goodsProcParamWork.UpdateDateTimeBegin = beginningTime;
                    goodsProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(goodsProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_STOCK))
                {
                    StockProcParamWork stockProcParamWork = SndRcvEtrWorkToStockProcParamWork(sndRcvEtrWork);
                    stockProcParamWork.UpdateDateTimeBegin = beginningTime;
                    stockProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(stockProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_SUPPLIER))
                {
                    SupplierProcParamWork supplierProcParamWork = SndRcvEtrWorkToSupplierProcParamWork(sndRcvEtrWork);
                    supplierProcParamWork.UpdateDateTimeBegin = beginningTime;
                    supplierProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(supplierProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_RATE))
                {
                    RateProcParamWork rateProcParamWork = SndRcvEtrWorkToRateProcParamWork(sndRcvEtrWork);
                    rateProcParamWork.UpdateDateTimeBegin = beginningTime;
                    rateProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(rateProcParamWork);
                }
                // --- ADD 2012/07/26 ------------------------->>>>>
                else if (sndRcvEtrWork.FileId.Equals(FILEID_EMPLOYEE))
                {
                    EmployeeProcParamWork employeeProcParamWork = SndRcvEtrWorkToEmployeeProcParamWork(sndRcvEtrWork);
                    employeeProcParamWork.UpdateDateTimeBegin = beginningTime;
                    employeeProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(employeeProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_JOINPARTSU))
                {
                    JoinPartsUProcParamWork joinPartsUProcParamWork = SndRcvEtrWorkToJoinPartsUProcParamWork(sndRcvEtrWork);
                    joinPartsUProcParamWork.UpdateDateTimeBegin = beginningTime;
                    joinPartsUProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(joinPartsUProcParamWork);
                }
                else if (sndRcvEtrWork.FileId.Equals(FILEID_USERGDU))
                {
                    UserGdBuyDivUProcParamWork userGdBuyDivUProcParamWork = SndRcvEtrWorkToUserGdBuyDivUProcParamWork(sndRcvEtrWork);
                    userGdBuyDivUProcParamWork.UpdateDateTimeBegin = beginningTime;
                    userGdBuyDivUProcParamWork.UpdateDateTimeEnd = endingTime;
                    condParamList.Add(userGdBuyDivUProcParamWork);
                }
                // --- ADD 2012/07/26 -------------------------<<<<<
            }
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            // 抽出・更新コントロール処理リモートを呼び出して抽出データを取得し、抽出結果クラスを返します。
            if (connectPointDiv == 0)
            {
                this._iMstDCControlDB = MediationMstDCControlDB.GetMstDCControlDB();
                // データ抽出処理
                //status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);//DEL 2011/07/25
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                if (recSndRcvHisWork.SndLogExtraCondDiv == 0)
                {
                    status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);
                }
                else
                {
                    status = _iMstDCControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, condParamList, ref retCSAList, out retMessage);
                }
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
            else
            {
                this._iMstTotalMachControlDB = MstTotalMachControlDB.GetMstTotalMachControlDB();
                // データ抽出処理
                status = _iMstTotalMachControlDB.SearchCustomSerializeArrayList(masterDivTempList, pmEnterpriseCode, beginningTime, endingTime, ref retCSAList, out retMessage);
            }

            // 抽出結果正常の場合、データ変換処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

                // データ変換処理
                syncExecDt = this.ReceDivisionCustomSerializeArrayList(out updCSAList, retCSAList);


                // データ更新処理
                this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                status = _iAPMSTControlDB.Update(enterpriseCode, masterDivList, masterDtlDivList, ref updCSAList, pmEnterpriseCode, out isEmpty, out searchCountWork, out retMessage);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (isEmpty)
                    {
                        // 抽出結果CustomSerializeArrayListの内容が存在しない場合、
                        return status;
                    }
                    else
                    {
                        string logStr = string.Empty;
                        foreach (SecMngSndRcvWork work in masterNameList)
                        {
                            logStr = logStr + MARK_3 + work.MasterName + MARK_3;
                            // 拠点設定マスタ
                            if (MST_SECINFOSET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SecInfoSetCount) + MARK_2;
                            }
                            // 部門設定マスタ
                            else if (MST_SUBSECTION.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SubSectionCount) + MARK_2;
                            }
                            // 倉庫設定マスタ
                            else if (MST_WAREHOUSE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.WarehouseCount) + MARK_2;
                            }
                            // 従業員設定マスタ
                            else if (MST_EMPLOYEE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.EmployeeCount + searchCountWork.EmployeeDtlCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ(販売エリア区分）
                            else if (MST_USERGDAREADIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdAreaDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（業務区分）
                            else if (MST_USERGDBUSDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBusDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（業種）
                            else if (MST_USERGDCATEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCateUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（職種）
                            else if (MST_USERGDBUSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBusUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（商品区分）
                            else if (MST_USERGDGOODSDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdGoodsDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（得意先掛率グループ）
                            else if (MST_USERGDCUSGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（銀行）
                            else if (MST_USERGDBANKU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBankUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（価格区分）
                            else if (MST_USERGDPRIDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdPriDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（納品区分）
                            else if (MST_USERGDDELIDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdDeliDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（商品大分類）
                            else if (MST_USERGDGOODSBIGU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdBuyDivUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（販売区分）
                            else if (MST_USERGDBUYDIVU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivOUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（在庫管理区分１）
                            else if (MST_USERGDSTOCKDIVOU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdStockDivTUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（在庫管理区分２）
                            else if (MST_USERGDSTOCKDIVTU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdReturnReaUCount) + MARK_2;
                            }
                            // ユーザーガイドマスタ（返品理由）
                            else if (MST_USERGDRETURNREAU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.UserGdCusGrouPUCount) + MARK_2;
                            }
                            // 掛率優先管理マスタ
                            else if (MST_RATEPROTYMNG.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.RateProtyMngCount) + MARK_2;
                            }
                            // 掛率マスタ
                            else if (MST_RATE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.RateCount) + MARK_2;
                            }
                            // 売上目標設定マスタ
                            else if (MST_SALESTARGET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.EmpSalesTargetCount + searchCountWork.CustSalesTargetCount + searchCountWork.GcdSalesTargetCount) + MARK_2;
                            }
                            // 得意先マスタ
                            else if (MST_CUSTOME.Equals(work.MasterName))
                            {
                                // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                                //logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                //    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount) + MARK_2;
                                logStr = logStr + this.IntConvert(searchCountWork.CustomerCount + searchCountWork.CustomerChangeCount + searchCountWork.CustRateGroupCount
                                    + searchCountWork.CustSlipMngCount + searchCountWork.CustSlipNoSetCount + searchCountWork.CustomerMemoCount) + MARK_2;
                                // ------ UPD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                            }
                            // 仕入先マスタ
                            else if (MST_SUPPLIER.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.SupplierCount) + MARK_2;
                            }
                            // 結合マスタ
                            else if (MST_JOINPARTSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.JoinPartsUCount) + MARK_2;
                            }
                            // セットマスタ
                            else if (MST_GOODSSET.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsSetCount) + MARK_2;
                            }
                            // ＴＢＯマスタ
                            else if (MST_TBOSEARCHU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.TBOSearchUCount) + MARK_2;
                            }
                            // 車種マスタ
                            else if (MST_MODELNAMEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.ModelNameUCount) + MARK_2;
                            }
                            // ＢＬコードマスタ
                            else if (MST_BLGOODSCDU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLGoodsCdUCount) + MARK_2;
                            }
                            // メーカーマスタ
                            else if (MST_MAKERU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.MakerUCount) + MARK_2;
                            }
                            // 商品中分類マスタ
                            else if (MST_GOODSMGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsMGroupUCount) + MARK_2;
                            }
                            // グループコードマスタ
                            else if (MST_BLGROUPU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLGroupUCount) + MARK_2;
                            }
                            // BLコードガイドマスタ
                            else if (MST_BLCODEGUIDE.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.BLCodeGuideCount) + MARK_2;
                            }
                            // 商品マスタ
                            else if (MST_GOODSU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.GoodsMngCount + searchCountWork.GoodsPriceCount + searchCountWork.GoodsUCount
                                    + searchCountWork.IsolIslandPrcCount) + MARK_2;
                            }
                            // 在庫マスタ
                            else if (MST_STOCK.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.StockCount) + MARK_2;
                            }
                            // 代替マスタ
                            else if (MST_PARTSSUBSTU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.PartsSubstUCount) + MARK_2;
                            }
                            // 部位マスタ
                            else if (MST_PARTSPOSCODEU.Equals(work.MasterName))
                            {
                                logStr = logStr + this.IntConvert(searchCountWork.PartsPosCodeUCount) + MARK_2;
                            }
                        }

                        logStr = logStr.Trim();
                        logStr = logStr.Substring(0, logStr.Length - 1);
                        string logStrTemp = string.Empty;

                        Encoding myEncoding = Encoding.GetEncoding("shift-jis");
                        byte[] SourceStr_Bytes;
                        byte[] CutStr_Bytes = new byte[500];


                        SourceStr_Bytes = myEncoding.GetBytes(logStr);
                        Int32 logStrLen = SourceStr_Bytes.Length;

                        for (; 0 < logStrLen; )
                        {
                            if (logStrLen > 500)
                            {
                                Array.Copy(SourceStr_Bytes, 0, CutStr_Bytes, 0, 500);
                                logStrTemp = myEncoding.GetString(CutStr_Bytes);
                                logStrTemp = logStrTemp.Substring(0, logStrTemp.LastIndexOf(COUNTNAME));
                                logStrTemp = logStrTemp + COUNTNAME;
                                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                                    logStrTemp, "正常(拠点：" + baseCodeLog + ")");
                                logStr = logStr.Substring(logStrTemp.LastIndexOf(COUNTNAME) + 2);
                                logStr = logStr.Trim();

                                SourceStr_Bytes = myEncoding.GetBytes(logStr);
                                logStrLen = logStrLen - 500;
                            }
                            else
                            {
                                logStr = logStr.Trim();
                                if (!string.IsNullOrEmpty(logStr))
                                {
                                    if (logStr.Substring(0, 1).Equals("、"))
                                    {
                                        logStr = logStr.Substring(2);
                                    }
                                    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                                            logStr, "正常(拠点：" + baseCodeLog + ")");
                                }
                                break;
                            }
                        }
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    return status;
                }
                else
                {
                    // MOD 2009/06/17 ---->>>
                    //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCodeLog + ")");
                    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + baseCodeLog + ")", string.Empty);
                    // MOD 2009/06/17 ----<<<
                    return status;
                }


            }
            // 抽出処理がエラーの場合、「4　操作履歴ログデータへの書き込み」へ続ける。
            else
            {
                // MOD 2009/06/17 ---->>>
                //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "抽出エラー(拠点：" + baseCodeLog + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + baseCodeLog + ")", string.Empty);
                // MOD 2009/06/17 ----<<<
                return status;
            }

            // status＝0正常の場合、「4　操作履歴ログデータへの書き込み」
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return status;
            //}
            //else
            //{
            //    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCodeLog + ")");
            //}

            // 拠点管理設定マスタの更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
                //DateTime startTime = new DateTime();
                //// 上記抽出した拠点コードに対して全データの更新日付参照し、取得レコードの最新レコード日付を算出します。
                //foreach (APMSTSecMngSetWork work in secMngSetArrList)
                //{
                //    if (baseCode.Equals(work.SectionCode))
                //    {
                //        startTime = work.SyncExecDate;
                //        break;
                //    }
                //}

                //if (startTime < syncExecDt)
                //{
                //    // 拠点管理設定マスタの更新
                //    this._iAPMSTControlDB = MediationAPMstControlDB.GetAPMSTControlDB();
                //    status = _iAPMSTControlDB.UpdateReceSecMngSet(enterpriseCode, baseCode, updEmployeeCode, syncExecDt, out retMessage);
                //}
                #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //送信履歴ログデータの更新
                ArrayList updList = new ArrayList();
                //送受信区分は｢1:受信｣に更新
                recSndRcvHisWork.SendOrReceiveDivCd = 1;
                updList.Add(recSndRcvHisWork);
                status = _iSndRcvHisRFDB.WriteRcvHisWork(ref updList);
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            }
            return status;

        }

        # endregion ■ マスタ送受信処理 ■

        # region ■ データ変換処理 ■
        /// <summary>
        /// 送信データ変換処理
        /// </summary>
        /// <param name="updCSAList">抽出データ</param>
        /// <param name="searchCountWork">更新データ</param>
        /// <param name="syncExecDt">最大シンク時間</param>
        /// <param name="minSyncExecDt">最小シンク時間</param>
        /// <param name="isEmpty">空判断</param>
        /// <param name="retCSAList">結果リスト</param>
        /// <remarks>
        /// <br>Note       : 送信データ変換処理行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2021/04/12 陳艶丹</br>
        /// <br>管理番号   : 11770021-00</br>
        /// <br>           : PMKOBETSU-4136 得意先メモ情報の追加</br>
        /// </remarks>
        //private DateTime DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out MstSearchCountWorkWork searchCountWork, out bool isEmpty, CustomSerializeArrayList retCSAList) //DEL 2011/07/25
        private void DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out MstSearchCountWorkWork searchCountWork, out DateTime syncExecDt, out DateTime minSyncExecDt, out bool isEmpty, CustomSerializeArrayList retCSAList) //ADD 2011/07/25
        {
            // 拠点情報設定データ
            Int32 secInfoSetCount = 0;
            ArrayList dcSecInfoSetList = new ArrayList();
            // 部門マスタ
            Int32 subSectionCount = 0;
            ArrayList dcSubSectionList = new ArrayList();
            // 従業員マスタ
            Int32 employeeCount = 0;
            ArrayList dcEmployeeList = new ArrayList();
            // 従業員詳細マスタ
            Int32 employeeDtlCount = 0;
            ArrayList dcEmployeeDtlList = new ArrayList();
            // 倉庫マスタ
            Int32 warehouseCount = 0;
            ArrayList dcWarehouseList = new ArrayList();
            // 得意先マスタ
            Int32 customerCount = 0;
            ArrayList dcCustomerList = new ArrayList();
            // 得意先マスタ(変動情報)
            Int32 customerChangeCount = 0;
            ArrayList dcCustomerChangeList = new ArrayList();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            // 得意先マスタ(変動情報)
            Int32 customerMemoCount = INT_ZERO;
            ArrayList dcCustomerMemoList = new ArrayList();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            // 得意先マスタ（伝票管理）
            Int32 custSlipMngCount = 0;
            ArrayList dcCustSlipMngList = new ArrayList();
            // 得意先マスタ（掛率グループ）
            Int32 custRateGroupCount = 0;
            ArrayList dcCustRateGroupList = new ArrayList();
            // 得意先マスタ(伝票番号)
            Int32 custSlipNoSetCount = 0;
            ArrayList dcCustSlipNoSetList = new ArrayList();
            // 仕入先マスタ
            Int32 supplierCount = 0;
            ArrayList dcSupplierList = new ArrayList();
            // メーカーマスタ（ユーザー登録分）
            Int32 makerUCount = 0;
            ArrayList dcMakerUList = new ArrayList();
            // BL商品コードマスタ（ユーザー登録分）
            Int32 bLGoodsCdUCount = 0;
            ArrayList dcBLGoodsCdUList = new ArrayList();
            // 商品マスタ（ユーザー登録分）
            Int32 goodsUCount = 0;
            ArrayList dcGoodsUList = new ArrayList();
            // 価格マスタ（ユーザー登録）
            Int32 goodsPriceCount = 0;
            ArrayList dcGoodsPriceList = new ArrayList();
            // 商品管理情報マスタ
            Int32 goodsMngCount = 0;
            ArrayList dcGoodsMngList = new ArrayList();
            // 離島価格マスタ
            Int32 isolIslandPrcCount = 0;
            ArrayList dcIsolIslandPrcList = new ArrayList();
            // 在庫マスタ
            Int32 stockCount = 0;
            ArrayList dcStockList = new ArrayList();
            // ユーザーガイドマスタ(販売エリア区分）
            Int32 userGdAreaDivUCount = 0;
            // ユーザーガイドマスタ（業務区分）
            Int32 userGdBusDivUCount = 0;
            // ユーザーガイドマスタ（業種）
            Int32 userGdCateUCount = 0;
            // ユーザーガイドマスタ（職種）
            Int32 userGdBusUCount = 0;
            // ユーザーガイドマスタ（商品区分）
            Int32 userGdGoodsDivUCount = 0;
            // ユーザーガイドマスタ（得意先掛率グループ）
            Int32 userGdCusGrouPUCount = 0;
            // ユーザーガイドマスタ（銀行）
            Int32 userGdBankUCount = 0;
            // ユーザーガイドマスタ（価格区分）
            Int32 userGdPriDivUCount = 0;
            // ユーザーガイドマスタ（納品区分）
            Int32 userGdDeliDivUCount = 0;
            // ユーザーガイドマスタ（商品大分類）
            Int32 userGdGoodsBigUCount = 0;
            // ユーザーガイドマスタ（販売区分）
            Int32 userGdBuyDivUCount = 0;
            // ユーザーガイドマスタ（在庫管理区分１）
            Int32 userGdStockDivOUCount = 0;
            // ユーザーガイドマスタ（在庫管理区分２）
            Int32 userGdStockDivTUCount = 0;
            // ユーザーガイドマスタ（返品理由）
            Int32 userGdReturnReaUCount = 0;
            ArrayList dcUserGdBdUList = new ArrayList();
            // 掛率優先管理マスタ
            Int32 rateProtyMngCount = 0;
            ArrayList dcRateProtyMngList = new ArrayList();
            // 掛率マスタ
            Int32 rateCount = 0;
            ArrayList dcRateList = new ArrayList();
            // 商品セットマスタ
            Int32 goodsSetCount = 0;
            ArrayList dcGoodsSetList = new ArrayList();
            // 部品代替マスタ（ユーザー登録分）
            Int32 partsSubstUCount = 0;
            ArrayList dcPartsSubstUList = new ArrayList();
            // 従業員別売上目標設定マスタ
            Int32 empSalesTargetCount = 0;
            ArrayList dcEmpSalesTargetList = new ArrayList();
            // 得意先別売上目標設定マスタ
            Int32 custSalesTargetCount = 0;
            ArrayList dcCustSalesTargetList = new ArrayList();
            // 商品別売上目標設定マスタ
            Int32 gcdSalesTargetCount = 0;
            ArrayList dcGcdSalesTargetList = new ArrayList();
            // 商品中分類マスタ（ユーザー登録分）
            Int32 goodsMGroupUCount = 0;
            ArrayList dcGoodsMGroupUList = new ArrayList();
            // BLグループマスタ（ユーザー登録分）
            Int32 bLGroupUCount = 0;
            ArrayList dcBLGroupUList = new ArrayList();
            // 結合マスタ（ユーザー登録分）
            Int32 joinPartsUCount = 0;
            ArrayList dcJoinPartsUList = new ArrayList();
            // TBO検索マスタ（ユーザー登録）
            Int32 tBOSearchUCount = 0;
            ArrayList dcTBOSearchUList = new ArrayList();
            // 部位コードマスタ（ユーザー登録）
            Int32 partsPosCodeUCount = 0;
            ArrayList dcPartsPosCodeUList = new ArrayList();
            // BLコードガイドマスタ
            Int32 bLCodeGuideCount = 0;
            ArrayList dcBLCodeGuideList = new ArrayList();
            // 車種名称マスタ
            Int32 modelNameUCount = 0;
            ArrayList dcModelNameUList = new ArrayList();

            updCSAList = new CustomSerializeArrayList();
            searchCountWork = new MstSearchCountWorkWork();
            //DateTime syncExecDt = new DateTime(); //DEL 2011/07/25
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
            syncExecDt = new DateTime();
            minSyncExecDt = System.DateTime.Now;
            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
            isEmpty = true;

            //●パラメータチェック
            if (retCSAList == null || retCSAList.Count <= 0)
            {
                //return syncExecDt; //DEL 2011/07/25
                return; //ADD 2011/07/25
            }

            for (int i = 0; i < retCSAList.Count; i++)
            {
                ArrayList retCSATemList = (ArrayList)retCSAList[i];
                for (int j = 0; j < retCSATemList.Count; j++)
                {
                    isEmpty = false;

                    Type wktype = retCSATemList[j].GetType();

                    // DC拠点情報設定データ変換処理
                    if (wktype.Equals(typeof(APSecInfoSetWork)))
                    {
                        APSecInfoSetWork secInfoSetWork = (APSecInfoSetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (secInfoSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = secInfoSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (secInfoSetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = secInfoSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCSecInfoSetWork dcSecInfoSetWork = MstConvertReceive.SearchDataFromUpdateData(secInfoSetWork);
                        dcSecInfoSetList.Add(dcSecInfoSetWork);
                        secInfoSetCount++;

                    }
                    // DC部門データ更新処理
                    else if (wktype.Equals(typeof(APSubSectionWork)))
                    {
                        APSubSectionWork subSectionWork = (APSubSectionWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (subSectionWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = subSectionWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        // 最新レコード日付　=＜　最小拠点管理設定マスタ.シンク実行日付の場合、
                        if (subSectionWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = subSectionWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCSubSectionWork dcSubSectionWork = MstConvertReceive.SearchDataFromUpdateData(subSectionWork);
                        dcSubSectionList.Add(dcSubSectionWork);
                        subSectionCount++;
                    }
                    // DC従業員マスタデータ更新処理
                    else if (wktype.Equals(typeof(APEmployeeWork)))
                    {
                        APEmployeeWork employeeWork = (APEmployeeWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (employeeWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = employeeWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        // 最新レコード日付　=＜　最小拠点管理設定マスタ.シンク実行日付の場合、
                        if (employeeWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = employeeWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCEmployeeWork dcEmployeeWork = MstConvertReceive.SearchDataFromUpdateData(employeeWork);
                        dcEmployeeList.Add(dcEmployeeWork);
                        employeeCount++;
                    }
                    // DC従業員詳細マスタデータ更新処理
                    else if (wktype.Equals(typeof(APEmployeeDtlWork)))
                    {
                        APEmployeeDtlWork employeeDtlWork = (APEmployeeDtlWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (employeeDtlWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = employeeDtlWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (employeeDtlWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = employeeDtlWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCEmployeeDtlWork dcEmployeeDtlWork = MstConvertReceive.SearchDataFromUpdateData(employeeDtlWork);
                        dcEmployeeDtlList.Add(dcEmployeeDtlWork);
                        employeeDtlCount++;
                    }
                    // DC倉庫マスタデータ更新処理
                    else if (wktype.Equals(typeof(APWarehouseWork)))
                    {
                        APWarehouseWork warehouseWork = (APWarehouseWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (warehouseWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = warehouseWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (warehouseWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = warehouseWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCWarehouseWork dcWarehouseWork = MstConvertReceive.SearchDataFromUpdateData(warehouseWork);
                        dcWarehouseList.Add(dcWarehouseWork);
                        warehouseCount++;
                    }
                    // DC得意先マスタデータ更新処理
                    else if (wktype.Equals(typeof(APCustomerWork)))
                    {
                        APCustomerWork customerWork = (APCustomerWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (customerWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (customerWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = customerWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCCustomerWork dcCustomerWork = MstConvertReceive.SearchDataFromUpdateData(customerWork);
                        dcCustomerList.Add(dcCustomerWork);
                        customerCount++;
                    }
                    // DC得意先マスタ(変動情報)データ更新処理
                    else if (wktype.Equals(typeof(APCustomerChangeWork)))
                    {
                        APCustomerChangeWork customerChangeWork = (APCustomerChangeWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (customerChangeWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerChangeWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (customerChangeWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = customerChangeWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCCustomerChangeWork dcCustomerChangeWork = MstConvertReceive.SearchDataFromUpdateData(customerChangeWork);
                        dcCustomerChangeList.Add(dcCustomerChangeWork);
                        customerChangeCount++;
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                    // DC得意先マスタ(メモ情報)データ更新処理
                    else if (wktype.Equals(typeof(APCustomerMemoWork)))
                    {
                        APCustomerMemoWork customerMemoWork = (APCustomerMemoWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (customerMemoWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerMemoWork.UpdateDateTime;
                        }
                        if (customerMemoWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = customerMemoWork.UpdateDateTime;
                        }
                        DCCustomerMemoWork dcCustomerMemoWork = MstConvertReceive.SearchDataFromUpdateData(customerMemoWork);
                        dcCustomerMemoList.Add(dcCustomerMemoWork);
                        customerMemoCount++;
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                    // DC得意先マスタ（伝票管理）データ更新処理
                    else if (wktype.Equals(typeof(APCustSlipMngWork)))
                    {
                        APCustSlipMngWork custSlipMngWork = (APCustSlipMngWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (custSlipMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSlipMngWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (custSlipMngWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = custSlipMngWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCCustSlipMngWork dcCustSlipMngWork = MstConvertReceive.SearchDataFromUpdateData(custSlipMngWork);
                        dcCustSlipMngList.Add(dcCustSlipMngWork);
                        custSlipMngCount++;
                    }
                    // DC得意先マスタ（掛率グループ）データ更新処理
                    else if (wktype.Equals(typeof(APCustRateGroupWork)))
                    {
                        APCustRateGroupWork custRateGroupWork = (APCustRateGroupWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (custRateGroupWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custRateGroupWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (custRateGroupWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = custRateGroupWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCCustRateGroupWork dcCustRateGroupWork = MstConvertReceive.SearchDataFromUpdateData(custRateGroupWork);
                        dcCustRateGroupList.Add(dcCustRateGroupWork);
                        custRateGroupCount++;
                    }
                    // DC得意先（伝票番号）データ更新処理
                    else if (wktype.Equals(typeof(APCustSlipNoSetWork)))
                    {
                        APCustSlipNoSetWork custSlipNoSetWork = (APCustSlipNoSetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (custSlipNoSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSlipNoSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (custSlipNoSetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = custSlipNoSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCCustSlipNoSetWork dcCustSlipNoSetWork = MstConvertReceive.SearchDataFromUpdateData(custSlipNoSetWork);
                        dcCustSlipNoSetList.Add(dcCustSlipNoSetWork);
                        custSlipNoSetCount++;
                    }
                    // DC仕入先マスタ更新処理
                    else if (wktype.Equals(typeof(APSupplierWork)))
                    {
                        APSupplierWork supplierWork = (APSupplierWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (supplierWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = supplierWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (supplierWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = supplierWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCSupplierWork dcSupplierWork = MstConvertReceive.SearchDataFromUpdateData(supplierWork);
                        dcSupplierList.Add(dcSupplierWork);
                        supplierCount++;
                    }
                    // DCメーカーマスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(APMakerUWork)))
                    {
                        APMakerUWork makerUWork = (APMakerUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (makerUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = makerUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (makerUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = makerUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCMakerUWork dcMakerUWork = MstConvertReceive.SearchDataFromUpdateData(makerUWork);
                        dcMakerUList.Add(dcMakerUWork);
                        makerUCount++;
                    }
                    // DCBL商品コードマスタ（ユーザー登録分）更新処理
                    else if (wktype.Equals(typeof(APBLGoodsCdUWork)))
                    {
                        APBLGoodsCdUWork bLGoodsCdUWork = (APBLGoodsCdUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (bLGoodsCdUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLGoodsCdUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (bLGoodsCdUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = bLGoodsCdUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCBLGoodsCdUWork dcBLGoodsCdUWork = MstConvertReceive.SearchDataFromUpdateData(bLGoodsCdUWork);
                        dcBLGoodsCdUList.Add(dcBLGoodsCdUWork);
                        bLGoodsCdUCount++;
                    }
                    // DC商品マスタ（ユーザー登録分）更新処理
                    else if (wktype.Equals(typeof(APGoodsUWork)))
                    {
                        APGoodsUWork goodsUWork = (APGoodsUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (goodsUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCGoodsUWork dcGoodsUWork = MstConvertReceive.SearchDataFromUpdateData(goodsUWork);
                        dcGoodsUList.Add(dcGoodsUWork);
                        goodsUCount++;
                    }
                    // DC価格マスタ（ユーザー登録）データ更新処理
                    else if (wktype.Equals(typeof(APGoodsPriceUWork)))
                    {
                        APGoodsPriceUWork goodsPriceUWork = (APGoodsPriceUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsPriceUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsPriceUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (goodsPriceUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsPriceUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCGoodsPriceUWork dcGoodsPriceUWork = MstConvertReceive.SearchDataFromUpdateData(goodsPriceUWork);
                        dcGoodsPriceList.Add(dcGoodsPriceUWork);
                        goodsPriceCount++;
                    }
                    // DC商品管理情報マスタデータ更新処理
                    else if (wktype.Equals(typeof(APGoodsMngWork)))
                    {
                        APGoodsMngWork goodsMngWork = (APGoodsMngWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsMngWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (goodsMngWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsMngWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCGoodsMngWork dcGoodsMngWork = MstConvertReceive.SearchDataFromUpdateData(goodsMngWork);
                        dcGoodsMngList.Add(dcGoodsMngWork);
                        goodsMngCount++;
                    }
                    // DC離島価格マスタデータ更新処理
                    else if (wktype.Equals(typeof(APIsolIslandPrcWork)))
                    {
                        APIsolIslandPrcWork isolIslandPrcWork = (APIsolIslandPrcWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (isolIslandPrcWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = isolIslandPrcWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (isolIslandPrcWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = isolIslandPrcWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCIsolIslandPrcWork dcIsolIslandPrcWork = MstConvertReceive.SearchDataFromUpdateData(isolIslandPrcWork);
                        dcIsolIslandPrcList.Add(dcIsolIslandPrcWork);
                        isolIslandPrcCount++;
                    }
                    // DC在庫マスタデータ更新処理
                    else if (wktype.Equals(typeof(APStockWork)))
                    {
                        APStockWork stockWork = (APStockWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (stockWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = stockWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (stockWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = stockWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCStockWork dcStockWork = MstConvertReceive.SearchDataFromUpdateData(stockWork);
                        dcStockList.Add(dcStockWork);
                        stockCount++;
                    }
                    // DCユーザーガイドマスタデータ更新処理
                    else if (wktype.Equals(typeof(APUserGdBdUWork)))
                    {
                        APUserGdBdUWork userGdBdUWork = (APUserGdBdUWork)retCSATemList[j];
                        // ユーザーガイドマスタ(販売エリア区分）
                        if (userGdBdUWork.UserGuideDivCd == 21)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdAreaDivUCount++;
                        }
                        // ユーザーガイドマスタ（業務区分）
                        else if (userGdBdUWork.UserGuideDivCd == 31)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdBusDivUCount++;
                        }
                        // ユーザーガイドマスタ（業種）
                        else if (userGdBdUWork.UserGuideDivCd == 33)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdCateUCount++;
                        }
                        // ユーザーガイドマスタ（職種）
                        else if (userGdBdUWork.UserGuideDivCd == 34)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdBusUCount++;
                        }
                        // ユーザーガイドマスタ（商品区分）
                        else if (userGdBdUWork.UserGuideDivCd == 41)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdGoodsDivUCount++;
                        }
                        // ユーザーガイドマスタ（得意先掛率グループ）
                        else if (userGdBdUWork.UserGuideDivCd == 43)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdCusGrouPUCount++;
                        }
                        // ユーザーガイドマスタ（銀行）
                        else if (userGdBdUWork.UserGuideDivCd == 46)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdBankUCount++;
                        }
                        // ユーザーガイドマスタ（価格区分）
                        else if (userGdBdUWork.UserGuideDivCd == 47)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdPriDivUCount++;
                        }
                        // ユーザーガイドマスタ（納品区分）
                        else if (userGdBdUWork.UserGuideDivCd == 48)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdDeliDivUCount++;
                        }
                        // ユーザーガイドマスタ（商品大分類）
                        else if (userGdBdUWork.UserGuideDivCd == 70)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdGoodsBigUCount++;
                        }
                        // ユーザーガイドマスタ（販売区分）
                        else if (userGdBdUWork.UserGuideDivCd == 71)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdBuyDivUCount++;
                        }
                        // ユーザーガイドマスタ（在庫管理区分１）
                        else if (userGdBdUWork.UserGuideDivCd == 72)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdStockDivOUCount++;
                        }
                        // ユーザーガイドマスタ（在庫管理区分２）
                        else if (userGdBdUWork.UserGuideDivCd == 73)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdStockDivTUCount++;
                        }
                        // ユーザーガイドマスタ（返品理由）
                        else if (userGdBdUWork.UserGuideDivCd == 91)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                            if (userGdBdUWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                            DCUserGdBdUWork dcUserGdBdUWork = MstConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            dcUserGdBdUList.Add(dcUserGdBdUWork);
                            userGdReturnReaUCount++;
                        }
                    }
                    // DC掛率優先管理マスタデータ更新処理
                    else if (wktype.Equals(typeof(APRateProtyMngWork)))
                    {
                        APRateProtyMngWork rateProtyMngWork = (APRateProtyMngWork)retCSATemList[j];
                        //DEL 2011/08/27 #23922 受信処理でシンク時間と関係がありません----->>>>>
                        //// 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        //if (rateProtyMngWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = rateProtyMngWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (rateProtyMngWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = rateProtyMngWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        //DEL 2011/08/27 #23922 受信処理でシンク時間と関係がありません-----<<<<<
                        DCRateProtyMngWork dcRateProtyMngWork = MstConvertReceive.SearchDataFromUpdateData(rateProtyMngWork);
                        dcRateProtyMngList.Add(dcRateProtyMngWork);
                        rateProtyMngCount++;
                    }
                    // DC掛率マスタデータ更新処理
                    else if (wktype.Equals(typeof(APRateWork)))
                    {
                        APRateWork rateWork = (APRateWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (rateWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = rateWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (rateWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = rateWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCRateWork dcRateWork = MstConvertReceive.SearchDataFromUpdateData(rateWork);
                        dcRateList.Add(dcRateWork);
                        rateCount++;
                    }
                    // DC商品セットマスタデータ更新処理
                    else if (wktype.Equals(typeof(APGoodsSetWork)))
                    {
                        APGoodsSetWork goodsSetWork = (APGoodsSetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (goodsSetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsSetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCGoodsSetWork dcGoodsSetWork = MstConvertReceive.SearchDataFromUpdateData(goodsSetWork);
                        dcGoodsSetList.Add(dcGoodsSetWork);
                        goodsSetCount++;
                    }
                    // DC部品代替マスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(APPartsSubstUWork)))
                    {
                        APPartsSubstUWork partsSubstUWork = (APPartsSubstUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (partsSubstUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = partsSubstUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (partsSubstUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = partsSubstUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCPartsSubstUWork dcPartsSubstUWork = MstConvertReceive.SearchDataFromUpdateData(partsSubstUWork);
                        dcPartsSubstUList.Add(dcPartsSubstUWork);
                        partsSubstUCount++;
                    }
                    // DC従業員別売上目標設定マスタデータ更新処理
                    else if (wktype.Equals(typeof(APEmpSalesTargetWork)))
                    {
                        APEmpSalesTargetWork empSalesTargetWork = (APEmpSalesTargetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (empSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = empSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (empSalesTargetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = empSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCEmpSalesTargetWork dcEmpSalesTargetWork = MstConvertReceive.SearchDataFromUpdateData(empSalesTargetWork);
                        dcEmpSalesTargetList.Add(dcEmpSalesTargetWork);
                        empSalesTargetCount++;
                    }
                    // DC得意先別売上目標設定マスタデータ更新処理
                    else if (wktype.Equals(typeof(APCustSalesTargetWork)))
                    {
                        APCustSalesTargetWork custSalesTargetWork = (APCustSalesTargetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (custSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (custSalesTargetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = custSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCCustSalesTargetWork dcCustSalesTargetWork = MstConvertReceive.SearchDataFromUpdateData(custSalesTargetWork);
                        dcCustSalesTargetList.Add(dcCustSalesTargetWork);
                        custSalesTargetCount++;
                    }
                    // DC商品別売上目標設定マスタデータ更新処理
                    else if (wktype.Equals(typeof(APGcdSalesTargetWork)))
                    {
                        APGcdSalesTargetWork gcdSalesTargetWork = (APGcdSalesTargetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (gcdSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = gcdSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (gcdSalesTargetWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = gcdSalesTargetWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCGcdSalesTargetWork dcGcdSalesTargetWork = MstConvertReceive.SearchDataFromUpdateData(gcdSalesTargetWork);
                        dcGcdSalesTargetList.Add(dcGcdSalesTargetWork);
                        gcdSalesTargetCount++;
                    }
                    // DC商品中分類マスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(APGoodsGroupUWork)))
                    {
                        APGoodsGroupUWork goodsGroupUWork = (APGoodsGroupUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsGroupUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsGroupUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (goodsGroupUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = goodsGroupUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCGoodsGroupUWork dcGoodsGroupUWork = MstConvertReceive.SearchDataFromUpdateData(goodsGroupUWork);
                        dcGoodsMGroupUList.Add(dcGoodsGroupUWork);
                        goodsMGroupUCount++;
                    }
                    // DCBLグループマスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(APBLGroupUWork)))
                    {
                        APBLGroupUWork bLGroupUWork = (APBLGroupUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (bLGroupUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLGroupUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (bLGroupUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = bLGroupUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCBLGroupUWork dcBLGroupUWork = MstConvertReceive.SearchDataFromUpdateData(bLGroupUWork);
                        dcBLGroupUList.Add(dcBLGroupUWork);
                        bLGroupUCount++;
                    }
                    // DC結合マスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(APJoinPartsUWork)))
                    {
                        APJoinPartsUWork joinPartsUWork = (APJoinPartsUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (joinPartsUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = joinPartsUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (joinPartsUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = joinPartsUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCJoinPartsUWork dcJoinPartsUWork = MstConvertReceive.SearchDataFromUpdateData(joinPartsUWork);
                        dcJoinPartsUList.Add(dcJoinPartsUWork);
                        joinPartsUCount++;
                    }
                    // DCTBO検索マスタ（ユーザー登録）データ更新処理
                    else if (wktype.Equals(typeof(APTBOSearchUWork)))
                    {
                        APTBOSearchUWork tBOSearchUWork = (APTBOSearchUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (tBOSearchUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = tBOSearchUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (tBOSearchUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = tBOSearchUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCTBOSearchUWork dcTBOSearchUWork = MstConvertReceive.SearchDataFromUpdateData(tBOSearchUWork);
                        dcTBOSearchUList.Add(dcTBOSearchUWork);
                        tBOSearchUCount++;
                    }
                    // DC部位コードマスタ（ユーザー登録）データ更新処理
                    else if (wktype.Equals(typeof(APPartsPosCodeUWork)))
                    {
                        APPartsPosCodeUWork partsPosCodeUWork = (APPartsPosCodeUWork)retCSATemList[j];
                        //DEL 2011/08/27 #23922 受信処理でシンク時間と関係がありません----->>>>>
                        //// 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        //if (partsPosCodeUWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = partsPosCodeUWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (partsPosCodeUWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = partsPosCodeUWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        //DEL 2011/08/27 #23922 受信処理でシンク時間と関係がありません-----<<<<<
                        DCPartsPosCodeUWork dcPartsPosCodeUWork = MstConvertReceive.SearchDataFromUpdateData(partsPosCodeUWork);
                        dcPartsPosCodeUList.Add(dcPartsPosCodeUWork);
                        partsPosCodeUCount++;
                    }
                    // DCBLコードガイドマスタデータ更新処理
                    else if (wktype.Equals(typeof(APBLCodeGuideWork)))
                    {
                        APBLCodeGuideWork bLCodeGuideWork = (APBLCodeGuideWork)retCSATemList[j];
                        //DEL 2011/08/27 #23922 受信処理でシンク時間と関係がありません----->>>>>
                        //// 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        //if (bLCodeGuideWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = bLCodeGuideWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (bLCodeGuideWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = bLCodeGuideWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        //DEL 2011/08/27 #23922 受信処理でシンク時間と関係がありません-----<<<<<
                        DCBLCodeGuideWork dcBLCodeGuideWork = MstConvertReceive.SearchDataFromUpdateData(bLCodeGuideWork);
                        dcBLCodeGuideList.Add(dcBLCodeGuideWork);
                        bLCodeGuideCount++;
                    }
                    // DC車種名称マスタデータ更新処理
                    else if (wktype.Equals(typeof(APModelNameUWork)))
                    {
                        APModelNameUWork modelNameUWork = (APModelNameUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (modelNameUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = modelNameUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        if (modelNameUWork.UpdateDateTime < minSyncExecDt)
                        {
                            minSyncExecDt = modelNameUWork.UpdateDateTime;
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                        DCModelNameUWork dcModelNameUWork = MstConvertReceive.SearchDataFromUpdateData(modelNameUWork);
                        dcModelNameUList.Add(dcModelNameUWork);
                        modelNameUCount++;
                    }
                    else
                    {
                        // 
                    }
                }
            }

            // 拠点情報設定データデータ
            updCSAList.Add(dcSecInfoSetList);
            searchCountWork.SecInfoSetCount = secInfoSetCount;
            // 部門マスタデータ
            updCSAList.Add(dcSubSectionList);
            searchCountWork.SubSectionCount = subSectionCount;
            // 従業員マスタデータ
            updCSAList.Add(dcEmployeeList);
            searchCountWork.EmployeeCount = employeeCount;
            // 従業員詳細マスタデータ
            updCSAList.Add(dcEmployeeDtlList);
            searchCountWork.EmployeeDtlCount = employeeDtlCount;
            // 倉庫マスタ
            updCSAList.Add(dcWarehouseList);
            searchCountWork.WarehouseCount = warehouseCount;
            // 得意先マスタデータ
            updCSAList.Add(dcCustomerList);
            searchCountWork.CustomerCount = customerCount;
            // 得意先マスタ(変動情報)データ
            updCSAList.Add(dcCustomerChangeList);
            searchCountWork.CustomerChangeCount = customerChangeCount;
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            // 得意先マスタ(メモ情報)データ
            updCSAList.Add(dcCustomerMemoList);
            searchCountWork.CustomerMemoCount = customerMemoCount;
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            // 得意先マスタ（伝票管理）データ
            updCSAList.Add(dcCustSlipMngList);
            searchCountWork.CustSlipMngCount = custSlipMngCount;
            // 得意先マスタ（掛率グループ）データ
            updCSAList.Add(dcCustRateGroupList);
            searchCountWork.CustRateGroupCount = custRateGroupCount;
            // 得意先マスタ(伝票番号)データ
            updCSAList.Add(dcCustSlipNoSetList);
            searchCountWork.CustSlipNoSetCount = custSlipNoSetCount;
            // 仕入先マスタ
            updCSAList.Add(dcSupplierList);
            searchCountWork.SupplierCount = supplierCount;
            // メーカーマスタ（ユーザー登録分）データ
            updCSAList.Add(dcMakerUList);
            searchCountWork.MakerUCount = makerUCount;
            // BL商品コードマスタ（ユーザー登録分）
            updCSAList.Add(dcBLGoodsCdUList);
            searchCountWork.BLGoodsCdUCount = bLGoodsCdUCount;
            // 商品マスタ（ユーザー登録分）
            updCSAList.Add(dcGoodsUList);
            searchCountWork.GoodsUCount = goodsUCount;
            // 価格マスタ（ユーザー登録）データ
            updCSAList.Add(dcGoodsPriceList);
            searchCountWork.GoodsPriceCount = goodsPriceCount;
            // 商品管理情報マスタデータ
            updCSAList.Add(dcGoodsMngList);
            searchCountWork.GoodsMngCount = goodsMngCount;
            // 離島価格マスタデータ
            updCSAList.Add(dcIsolIslandPrcList);
            searchCountWork.IsolIslandPrcCount = isolIslandPrcCount;
            // 在庫マスタデータ
            updCSAList.Add(dcStockList);
            searchCountWork.StockCount = stockCount;
            // ユーザーガイドマスタデータ
            updCSAList.Add(dcUserGdBdUList);
            // ユーザーガイドマスタ(販売エリア区分）
            searchCountWork.UserGdAreaDivUCount = userGdAreaDivUCount;
            // ユーザーガイドマスタ（業務区分）
            searchCountWork.UserGdBusDivUCount = userGdBusDivUCount;
            // ユーザーガイドマスタ（業種）
            searchCountWork.UserGdCateUCount = userGdCateUCount;
            // ユーザーガイドマスタ（職種）
            searchCountWork.UserGdBusUCount = userGdBusUCount;
            // ユーザーガイドマスタ（商品区分）
            searchCountWork.UserGdGoodsDivUCount = userGdGoodsDivUCount;
            // ユーザーガイドマスタ（得意先掛率グループ）
            searchCountWork.UserGdCusGrouPUCount = userGdCusGrouPUCount;
            // ユーザーガイドマスタ（銀行）
            searchCountWork.UserGdBankUCount = userGdBankUCount;
            // ユーザーガイドマスタ（価格区分）
            searchCountWork.UserGdPriDivUCount = userGdPriDivUCount;
            // ユーザーガイドマスタ（納品区分）
            searchCountWork.UserGdDeliDivUCount = userGdDeliDivUCount;
            // ユーザーガイドマスタ（商品大分類）
            searchCountWork.UserGdGoodsBigUCount = userGdGoodsBigUCount;
            // ユーザーガイドマスタ（販売区分）
            searchCountWork.UserGdBuyDivUCount = userGdBuyDivUCount;
            // ユーザーガイドマスタ（在庫管理区分１）
            searchCountWork.UserGdStockDivOUCount = userGdStockDivOUCount;
            // ユーザーガイドマスタ（在庫管理区分２）
            searchCountWork.UserGdStockDivTUCount = userGdStockDivTUCount;
            // ユーザーガイドマスタ（返品理由）
            searchCountWork.UserGdReturnReaUCount = userGdReturnReaUCount;
            // 掛率優先管理マスタデータ
            updCSAList.Add(dcRateProtyMngList);
            searchCountWork.RateProtyMngCount = rateProtyMngCount;
            // 掛率マスタデータ
            updCSAList.Add(dcRateList);
            searchCountWork.RateCount = rateCount;
            // 商品セットマスタデータ
            updCSAList.Add(dcGoodsSetList);
            searchCountWork.GoodsSetCount = goodsSetCount;
            // 部品代替マスタ（ユーザー登録分）データ
            updCSAList.Add(dcPartsSubstUList);
            searchCountWork.PartsSubstUCount = partsSubstUCount;
            // 従業員別売上目標設定マスタデータ
            updCSAList.Add(dcEmpSalesTargetList);
            searchCountWork.EmpSalesTargetCount = empSalesTargetCount;
            // 得意先別売上目標設定マスタデータ
            updCSAList.Add(dcCustSalesTargetList);
            searchCountWork.CustSalesTargetCount = custSalesTargetCount;
            // 商品別売上目標設定マスタデータ
            updCSAList.Add(dcGcdSalesTargetList);
            searchCountWork.GcdSalesTargetCount = gcdSalesTargetCount;
            // 商品中分類マスタ（ユーザー登録分）データ
            updCSAList.Add(dcGoodsMGroupUList);
            searchCountWork.GoodsMGroupUCount = goodsMGroupUCount;
            // BLグループマスタ（ユーザー登録分）データ
            updCSAList.Add(dcBLGroupUList);
            searchCountWork.BLGroupUCount = bLGroupUCount;
            // 結合マスタ（ユーザー登録分）データ
            updCSAList.Add(dcJoinPartsUList);
            searchCountWork.JoinPartsUCount = joinPartsUCount;
            // TBO検索マスタ（ユーザー登録）データ
            updCSAList.Add(dcTBOSearchUList);
            searchCountWork.TBOSearchUCount = tBOSearchUCount;
            // 部位コードマスタ（ユーザー登録）データ
            updCSAList.Add(dcPartsPosCodeUList);
            searchCountWork.PartsPosCodeUCount = partsPosCodeUCount;
            // BLコードガイドマスタデータ
            updCSAList.Add(dcBLCodeGuideList);
            searchCountWork.BLCodeGuideCount = bLCodeGuideCount;
            // 車種名称マスタデータ
            updCSAList.Add(dcModelNameUList);
            searchCountWork.ModelNameUCount = modelNameUCount;

            //return syncExecDt; //DEL 2011/07/25
        }

        /// <summary>
        /// 受信データ変換処理
        /// </summary>
        /// <param name="updCSAList">抽出データ</param>
        /// <param name="retCSAList">更新データ</param>
        /// <returns>シンク時間</returns>
        /// <remarks>
        /// <br>Note       : 受信データ変換処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        private DateTime ReceDivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, CustomSerializeArrayList retCSAList)
        {
            // 拠点情報設定データ
            Int32 secInfoSetCount = 0;
            ArrayList apSecInfoSetList = new ArrayList();
            // 部門マスタ
            Int32 subSectionCount = 0;
            ArrayList apSubSectionList = new ArrayList();
            // 従業員マスタ
            Int32 employeeCount = 0;
            ArrayList apEmployeeList = new ArrayList();
            // 従業員詳細マスタ
            Int32 employeeDtlCount = 0;
            ArrayList apEmployeeDtlList = new ArrayList();
            // 倉庫マスタ
            Int32 warehouseCount = 0;
            ArrayList apWarehouseList = new ArrayList();
            // 得意先マスタ
            Int32 customerCount = 0;
            ArrayList apCustomerList = new ArrayList();
            // 得意先マスタ(変動情報)
            Int32 customerChangeCount = 0;
            ArrayList apCustomerChangeList = new ArrayList();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            // 得意先マスタ(変動情報)
            Int32 customerMemoCount = INT_ZERO;
            ArrayList apCustomerMemoList = new ArrayList();
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            // 得意先マスタ（伝票管理）
            Int32 custSlipMngCount = 0;
            ArrayList apCustSlipMngList = new ArrayList();
            // 得意先マスタ（掛率グループ）
            Int32 custRateGroupCount = 0;
            ArrayList apCustRateGroupList = new ArrayList();
            // 得意先マスタ(伝票番号)
            Int32 custSlipNoSetCount = 0;
            ArrayList apCustSlipNoSetList = new ArrayList();
            // 仕入先マスタ
            Int32 supplierCount = 0;
            ArrayList apSupplierList = new ArrayList();
            // メーカーマスタ（ユーザー登録分）
            Int32 makerUCount = 0;
            ArrayList apMakerUList = new ArrayList();
            // BL商品コードマスタ（ユーザー登録分）
            Int32 bLGoodsCdUCount = 0;
            ArrayList apBLGoodsCdUList = new ArrayList();
            // 商品マスタ（ユーザー登録分）
            Int32 goodsUCount = 0;
            ArrayList apGoodsUList = new ArrayList();
            // 価格マスタ（ユーザー登録）
            Int32 goodsPriceCount = 0;
            ArrayList apGoodsPriceList = new ArrayList();
            // 商品管理情報マスタ
            Int32 goodsMngCount = 0;
            ArrayList apGoodsMngList = new ArrayList();
            // 離島価格マスタ
            Int32 isolIslandPrcCount = 0;
            ArrayList apIsolIslandPrcList = new ArrayList();
            // 在庫マスタ
            Int32 stockCount = 0;
            ArrayList apStockList = new ArrayList();
            // ユーザーガイドマスタ(販売エリア区分）
            Int32 userGdAreaDivUCount = 0;
            // ユーザーガイドマスタ（業務区分）
            Int32 userGdBusDivUCount = 0;
            // ユーザーガイドマスタ（業種）
            Int32 userGdCateUCount = 0;
            // ユーザーガイドマスタ（職種）
            Int32 userGdBusUCount = 0;
            // ユーザーガイドマスタ（商品区分）
            Int32 userGdGoodsDivUCount = 0;
            // ユーザーガイドマスタ（得意先掛率グループ）
            Int32 userGdCusGrouPUCount = 0;
            // ユーザーガイドマスタ（銀行）
            Int32 userGdBankUCount = 0;
            // ユーザーガイドマスタ（価格区分）
            Int32 userGdPriDivUCount = 0;
            // ユーザーガイドマスタ（納品区分）
            Int32 userGdDeliDivUCount = 0;
            // ユーザーガイドマスタ（商品大分類）
            Int32 userGdGoodsBigUCount = 0;
            // ユーザーガイドマスタ（販売区分）
            Int32 userGdBuyDivUCount = 0;
            // ユーザーガイドマスタ（在庫管理区分１）
            Int32 userGdStockDivOUCount = 0;
            // ユーザーガイドマスタ（在庫管理区分２）
            Int32 userGdStockDivTUCount = 0;
            // ユーザーガイドマスタ（返品理由）
            Int32 userGdReturnReaUCount = 0;
            ArrayList apUserGdBdUList = new ArrayList();
            // 掛率優先管理マスタ
            Int32 rateProtyMngCount = 0;
            ArrayList apRateProtyMngList = new ArrayList();
            // 掛率マスタ
            Int32 rateCount = 0;
            ArrayList apRateList = new ArrayList();
            // 商品セットマスタ
            Int32 goodsSetCount = 0;
            ArrayList apGoodsSetList = new ArrayList();
            // 部品代替マスタ（ユーザー登録分）
            Int32 partsSubstUCount = 0;
            ArrayList apPartsSubstUList = new ArrayList();
            // 従業員別売上目標設定マスタ
            Int32 empSalesTargetCount = 0;
            ArrayList apEmpSalesTargetList = new ArrayList();
            // 得意先別売上目標設定マスタ
            Int32 custSalesTargetCount = 0;
            ArrayList apCustSalesTargetList = new ArrayList();
            // 商品別売上目標設定マスタ
            Int32 gcdSalesTargetCount = 0;
            ArrayList apGcdSalesTargetList = new ArrayList();
            // 商品中分類マスタ（ユーザー登録分）
            Int32 goodsMGroupUCount = 0;
            ArrayList apGoodsMGroupUList = new ArrayList();
            // BLグループマスタ（ユーザー登録分）
            Int32 bLGroupUCount = 0;
            ArrayList apBLGroupUList = new ArrayList();
            // 結合マスタ（ユーザー登録分）
            Int32 joinPartsUCount = 0;
            ArrayList apJoinPartsUList = new ArrayList();
            // TBO検索マスタ（ユーザー登録）
            Int32 tBOSearchUCount = 0;
            ArrayList apTBOSearchUList = new ArrayList();
            // 部位コードマスタ（ユーザー登録）
            Int32 partsPosCodeUCount = 0;
            ArrayList apPartsPosCodeUList = new ArrayList();
            // BLコードガイドマスタ
            Int32 bLCodeGuideCount = 0;
            ArrayList apBLCodeGuideList = new ArrayList();
            // 車種名称マスタ
            Int32 modelNameUCount = 0;
            ArrayList apModelNameUList = new ArrayList();

            updCSAList = new CustomSerializeArrayList();
            MstSearchCountWorkWork searchCountWork = new MstSearchCountWorkWork();
            DateTime syncExecDt = new DateTime();


            //●パラメータチェック
            if (retCSAList == null || retCSAList.Count <= 0)
            {
                return syncExecDt;
            }

            for (int i = 0; i < retCSAList.Count; i++)
            {
                ArrayList retCSATemList = (ArrayList)retCSAList[i];
                for (int j = 0; j < retCSATemList.Count; j++)
                {
                    Type wktype = retCSATemList[j].GetType();

                    // AP拠点情報設定データ変換処理
                    if (wktype.Equals(typeof(DCSecInfoSetWork)))
                    {
                        DCSecInfoSetWork secInfoSetWork = (DCSecInfoSetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (secInfoSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = secInfoSetWork.UpdateDateTime;
                        }
                        APSecInfoSetWork apSecInfoSetWork = MstRecConvertReceive.SearchDataFromUpdateData(secInfoSetWork);
                        apSecInfoSetList.Add(apSecInfoSetWork);
                        secInfoSetCount++;

                    }
                    // AP部門データ更新処理
                    else if (wktype.Equals(typeof(DCSubSectionWork)))
                    {
                        DCSubSectionWork subSectionWork = (DCSubSectionWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (subSectionWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = subSectionWork.UpdateDateTime;
                        }
                        APSubSectionWork apSubSectionWork = MstRecConvertReceive.SearchDataFromUpdateData(subSectionWork);
                        apSubSectionList.Add(apSubSectionWork);
                        subSectionCount++;
                    }
                    // AP従業員マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCEmployeeWork)))
                    {
                        DCEmployeeWork employeeWork = (DCEmployeeWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (employeeWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = employeeWork.UpdateDateTime;
                        }
                        APEmployeeWork apEmployeeWork = MstRecConvertReceive.SearchDataFromUpdateData(employeeWork);
                        apEmployeeList.Add(apEmployeeWork);
                        employeeCount++;
                    }
                    // AP従業員詳細マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCEmployeeDtlWork)))
                    {
                        DCEmployeeDtlWork employeeDtlWork = (DCEmployeeDtlWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (employeeDtlWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = employeeDtlWork.UpdateDateTime;
                        }
                        APEmployeeDtlWork apEmployeeDtlWork = MstRecConvertReceive.SearchDataFromUpdateData(employeeDtlWork);
                        apEmployeeDtlList.Add(apEmployeeDtlWork);
                        employeeDtlCount++;
                    }
                    // AP倉庫マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCWarehouseWork)))
                    {
                        DCWarehouseWork warehouseWork = (DCWarehouseWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (warehouseWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = warehouseWork.UpdateDateTime;
                        }
                        APWarehouseWork apWarehouseWork = MstRecConvertReceive.SearchDataFromUpdateData(warehouseWork);
                        apWarehouseList.Add(apWarehouseWork);
                        warehouseCount++;
                    }
                    // AP得意先マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCCustomerWork)))
                    {
                        DCCustomerWork customerWork = (DCCustomerWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (customerWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerWork.UpdateDateTime;
                        }
                        APCustomerWork apCustomerWork = MstRecConvertReceive.SearchDataFromUpdateData(customerWork);
                        apCustomerList.Add(apCustomerWork);
                        customerCount++;
                    }
                    // AP得意先マスタ(変動情報)データ更新処理
                    else if (wktype.Equals(typeof(DCCustomerChangeWork)))
                    {
                        DCCustomerChangeWork customerChangeWork = (DCCustomerChangeWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (customerChangeWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerChangeWork.UpdateDateTime;
                        }
                        APCustomerChangeWork apCustomerChangeWork = MstRecConvertReceive.SearchDataFromUpdateData(customerChangeWork);
                        apCustomerChangeList.Add(apCustomerChangeWork);
                        customerChangeCount++;
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
                    // AP得意先マスタ(メモ情報)データ更新処理
                    else if (wktype.Equals(typeof(DCCustomerMemoWork)))
                    {
                        DCCustomerMemoWork customerMemoWork = (DCCustomerMemoWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (customerMemoWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = customerMemoWork.UpdateDateTime;
                        }
                        APCustomerMemoWork apCustomerMemoWork = MstRecConvertReceive.SearchDataFromUpdateData(customerMemoWork);
                        apCustomerMemoList.Add(apCustomerMemoWork);
                        customerMemoCount++;
                    }
                    // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
                    // AP得意先マスタ（伝票管理）データ更新処理
                    else if (wktype.Equals(typeof(DCCustSlipMngWork)))
                    {
                        DCCustSlipMngWork custSlipMngWork = (DCCustSlipMngWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (custSlipMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSlipMngWork.UpdateDateTime;
                        }
                        APCustSlipMngWork apCustSlipMngWork = MstRecConvertReceive.SearchDataFromUpdateData(custSlipMngWork);
                        apCustSlipMngList.Add(apCustSlipMngWork);
                        custSlipMngCount++;
                    }
                    // AP得意先マスタ（掛率グループ）データ更新処理
                    else if (wktype.Equals(typeof(DCCustRateGroupWork)))
                    {
                        DCCustRateGroupWork custRateGroupWork = (DCCustRateGroupWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (custRateGroupWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custRateGroupWork.UpdateDateTime;
                        }
                        APCustRateGroupWork apCustRateGroupWork = MstRecConvertReceive.SearchDataFromUpdateData(custRateGroupWork);
                        apCustRateGroupList.Add(apCustRateGroupWork);
                        custRateGroupCount++;
                    }
                    // AP得意先（伝票番号）データ更新処理
                    else if (wktype.Equals(typeof(DCCustSlipNoSetWork)))
                    {
                        DCCustSlipNoSetWork custSlipNoSetWork = (DCCustSlipNoSetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (custSlipNoSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSlipNoSetWork.UpdateDateTime;
                        }
                        APCustSlipNoSetWork apCustSlipNoSetWork = MstRecConvertReceive.SearchDataFromUpdateData(custSlipNoSetWork);
                        apCustSlipNoSetList.Add(apCustSlipNoSetWork);
                        custSlipNoSetCount++;
                    }
                    // AP仕入先マスタ更新処理
                    else if (wktype.Equals(typeof(DCSupplierWork)))
                    {
                        DCSupplierWork supplierWork = (DCSupplierWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (supplierWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = supplierWork.UpdateDateTime;
                        }
                        APSupplierWork apSupplierWork = MstRecConvertReceive.SearchDataFromUpdateData(supplierWork);
                        apSupplierList.Add(apSupplierWork);
                        supplierCount++;
                    }
                    // APメーカーマスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(DCMakerUWork)))
                    {
                        DCMakerUWork makerUWork = (DCMakerUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (makerUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = makerUWork.UpdateDateTime;
                        }
                        APMakerUWork apMakerUWork = MstRecConvertReceive.SearchDataFromUpdateData(makerUWork);
                        apMakerUList.Add(apMakerUWork);
                        makerUCount++;
                    }
                    // APBL商品コードマスタ（ユーザー登録分）更新処理
                    else if (wktype.Equals(typeof(DCBLGoodsCdUWork)))
                    {
                        DCBLGoodsCdUWork bLGoodsCdUWork = (DCBLGoodsCdUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (bLGoodsCdUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLGoodsCdUWork.UpdateDateTime;
                        }
                        APBLGoodsCdUWork apBLGoodsCdUWork = MstRecConvertReceive.SearchDataFromUpdateData(bLGoodsCdUWork);
                        apBLGoodsCdUList.Add(apBLGoodsCdUWork);
                        bLGoodsCdUCount++;
                    }
                    // AP商品マスタ（ユーザー登録分）更新処理
                    else if (wktype.Equals(typeof(DCGoodsUWork)))
                    {
                        DCGoodsUWork goodsUWork = (DCGoodsUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsUWork.UpdateDateTime;
                        }
                        APGoodsUWork apGoodsUWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsUWork);
                        apGoodsUList.Add(apGoodsUWork);
                        goodsUCount++;
                    }
                    // AP価格マスタ（ユーザー登録）データ更新処理
                    else if (wktype.Equals(typeof(DCGoodsPriceUWork)))
                    {
                        DCGoodsPriceUWork goodsPriceUWork = (DCGoodsPriceUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsPriceUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsPriceUWork.UpdateDateTime;
                        }
                        APGoodsPriceUWork apGoodsPriceUWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsPriceUWork);
                        apGoodsPriceList.Add(apGoodsPriceUWork);
                        goodsPriceCount++;
                    }
                    // AP商品管理情報マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCGoodsMngWork)))
                    {
                        DCGoodsMngWork goodsMngWork = (DCGoodsMngWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsMngWork.UpdateDateTime;
                        }
                        APGoodsMngWork apGoodsMngWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsMngWork);
                        apGoodsMngList.Add(apGoodsMngWork);
                        goodsMngCount++;
                    }
                    // AP離島価格マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCIsolIslandPrcWork)))
                    {
                        DCIsolIslandPrcWork isolIslandPrcWork = (DCIsolIslandPrcWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (isolIslandPrcWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = isolIslandPrcWork.UpdateDateTime;
                        }
                        APIsolIslandPrcWork apIsolIslandPrcWork = MstRecConvertReceive.SearchDataFromUpdateData(isolIslandPrcWork);
                        apIsolIslandPrcList.Add(apIsolIslandPrcWork);
                        isolIslandPrcCount++;
                    }
                    // AP在庫マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCStockWork)))
                    {
                        DCStockWork stockWork = (DCStockWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (stockWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = stockWork.UpdateDateTime;
                        }
                        APStockWork apStockWork = MstRecConvertReceive.SearchDataFromUpdateData(stockWork);
                        apStockList.Add(apStockWork);
                        stockCount++;
                    }
                    // APユーザーガイドマスタデータ更新処理
                    else if (wktype.Equals(typeof(DCUserGdBdUWork)))
                    {
                        DCUserGdBdUWork userGdBdUWork = (DCUserGdBdUWork)retCSATemList[j];
                        // ユーザーガイドマスタ(販売エリア区分）
                        if (userGdBdUWork.UserGuideDivCd == 21)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdAreaDivUCount++;
                        }
                        // ユーザーガイドマスタ（業務区分）
                        else if (userGdBdUWork.UserGuideDivCd == 31)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdBusDivUCount++;
                        }
                        // ユーザーガイドマスタ（業種）
                        else if (userGdBdUWork.UserGuideDivCd == 33)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdCateUCount++;
                        }
                        // ユーザーガイドマスタ（職種）
                        else if (userGdBdUWork.UserGuideDivCd == 34)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdBusUCount++;
                        }
                        // ユーザーガイドマスタ（商品区分）
                        else if (userGdBdUWork.UserGuideDivCd == 41)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdGoodsDivUCount++;
                        }
                        // ユーザーガイドマスタ（得意先掛率グループ）
                        else if (userGdBdUWork.UserGuideDivCd == 43)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdCusGrouPUCount++;
                        }
                        // ユーザーガイドマスタ（銀行）
                        else if (userGdBdUWork.UserGuideDivCd == 46)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdBankUCount++;
                        }
                        // ユーザーガイドマスタ（価格区分）
                        else if (userGdBdUWork.UserGuideDivCd == 47)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdPriDivUCount++;
                        }
                        // ユーザーガイドマスタ（納品区分）
                        else if (userGdBdUWork.UserGuideDivCd == 48)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdDeliDivUCount++;
                        }
                        // ユーザーガイドマスタ（商品大分類）
                        else if (userGdBdUWork.UserGuideDivCd == 70)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdGoodsBigUCount++;
                        }
                        // ユーザーガイドマスタ（販売区分）
                        else if (userGdBdUWork.UserGuideDivCd == 71)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdBuyDivUCount++;
                        }
                        // ユーザーガイドマスタ（在庫管理区分１）
                        else if (userGdBdUWork.UserGuideDivCd == 72)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdStockDivOUCount++;
                        }
                        // ユーザーガイドマスタ（在庫管理区分２）
                        else if (userGdBdUWork.UserGuideDivCd == 73)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdStockDivTUCount++;
                        }
                        // ユーザーガイドマスタ（返品理由）
                        else if (userGdBdUWork.UserGuideDivCd == 91)
                        {
                            // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                            if (userGdBdUWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = userGdBdUWork.UpdateDateTime;
                            }
                            APUserGdBdUWork apUserGdBdUWork = MstRecConvertReceive.SearchDataFromUpdateData(userGdBdUWork);
                            apUserGdBdUList.Add(apUserGdBdUWork);
                            userGdReturnReaUCount++;
                        }
                    }
                    // AP掛率優先管理マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCRateProtyMngWork)))
                    {
                        DCRateProtyMngWork rateProtyMngWork = (DCRateProtyMngWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (rateProtyMngWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = rateProtyMngWork.UpdateDateTime;
                        }
                        APRateProtyMngWork apRateProtyMngWork = MstRecConvertReceive.SearchDataFromUpdateData(rateProtyMngWork);
                        apRateProtyMngList.Add(apRateProtyMngWork);
                        rateProtyMngCount++;
                    }
                    // AP掛率マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCRateWork)))
                    {
                        DCRateWork rateWork = (DCRateWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (rateWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = rateWork.UpdateDateTime;
                        }
                        APRateWork apRateWork = MstRecConvertReceive.SearchDataFromUpdateData(rateWork);
                        apRateList.Add(apRateWork);
                        rateCount++;
                    }
                    // AP商品セットマスタデータ更新処理
                    else if (wktype.Equals(typeof(DCGoodsSetWork)))
                    {
                        DCGoodsSetWork goodsSetWork = (DCGoodsSetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsSetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsSetWork.UpdateDateTime;
                        }
                        APGoodsSetWork apGoodsSetWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsSetWork);
                        apGoodsSetList.Add(apGoodsSetWork);
                        goodsSetCount++;
                    }
                    // AP部品代替マスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(DCPartsSubstUWork)))
                    {
                        DCPartsSubstUWork partsSubstUWork = (DCPartsSubstUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (partsSubstUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = partsSubstUWork.UpdateDateTime;
                        }
                        APPartsSubstUWork apPartsSubstUWork = MstRecConvertReceive.SearchDataFromUpdateData(partsSubstUWork);
                        apPartsSubstUList.Add(apPartsSubstUWork);
                        partsSubstUCount++;
                    }
                    // AP従業員別売上目標設定マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCEmpSalesTargetWork)))
                    {
                        DCEmpSalesTargetWork empSalesTargetWork = (DCEmpSalesTargetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (empSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = empSalesTargetWork.UpdateDateTime;
                        }
                        APEmpSalesTargetWork apEmpSalesTargetWork = MstRecConvertReceive.SearchDataFromUpdateData(empSalesTargetWork);
                        apEmpSalesTargetList.Add(apEmpSalesTargetWork);
                        empSalesTargetCount++;
                    }
                    // AP得意先別売上目標設定マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCCustSalesTargetWork)))
                    {
                        DCCustSalesTargetWork custSalesTargetWork = (DCCustSalesTargetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (custSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = custSalesTargetWork.UpdateDateTime;
                        }
                        APCustSalesTargetWork apCustSalesTargetWork = MstRecConvertReceive.SearchDataFromUpdateData(custSalesTargetWork);
                        apCustSalesTargetList.Add(apCustSalesTargetWork);
                        custSalesTargetCount++;
                    }
                    // AP商品別売上目標設定マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCGcdSalesTargetWork)))
                    {
                        DCGcdSalesTargetWork gcdSalesTargetWork = (DCGcdSalesTargetWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (gcdSalesTargetWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = gcdSalesTargetWork.UpdateDateTime;
                        }
                        APGcdSalesTargetWork apGcdSalesTargetWork = MstRecConvertReceive.SearchDataFromUpdateData(gcdSalesTargetWork);
                        apGcdSalesTargetList.Add(apGcdSalesTargetWork);
                        gcdSalesTargetCount++;
                    }
                    // AP商品中分類マスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(DCGoodsGroupUWork)))
                    {
                        DCGoodsGroupUWork goodsGroupUWork = (DCGoodsGroupUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (goodsGroupUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = goodsGroupUWork.UpdateDateTime;
                        }
                        APGoodsGroupUWork apGoodsGroupUWork = MstRecConvertReceive.SearchDataFromUpdateData(goodsGroupUWork);
                        apGoodsMGroupUList.Add(apGoodsGroupUWork);
                        goodsMGroupUCount++;
                    }
                    // APBLグループマスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(DCBLGroupUWork)))
                    {
                        DCBLGroupUWork bLGroupUWork = (DCBLGroupUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (bLGroupUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLGroupUWork.UpdateDateTime;
                        }
                        APBLGroupUWork apBLGroupUWork = MstRecConvertReceive.SearchDataFromUpdateData(bLGroupUWork);
                        apBLGroupUList.Add(apBLGroupUWork);
                        bLGroupUCount++;
                    }
                    // AP結合マスタ（ユーザー登録分）データ更新処理
                    else if (wktype.Equals(typeof(DCJoinPartsUWork)))
                    {
                        DCJoinPartsUWork joinPartsUWork = (DCJoinPartsUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (joinPartsUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = joinPartsUWork.UpdateDateTime;
                        }
                        APJoinPartsUWork apJoinPartsUWork = MstRecConvertReceive.SearchDataFromUpdateData(joinPartsUWork);
                        apJoinPartsUList.Add(apJoinPartsUWork);
                        joinPartsUCount++;
                    }
                    // APTBO検索マスタ（ユーザー登録）データ更新処理
                    else if (wktype.Equals(typeof(DCTBOSearchUWork)))
                    {
                        DCTBOSearchUWork tBOSearchUWork = (DCTBOSearchUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (tBOSearchUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = tBOSearchUWork.UpdateDateTime;
                        }
                        APTBOSearchUWork apTBOSearchUWork = MstRecConvertReceive.SearchDataFromUpdateData(tBOSearchUWork);
                        apTBOSearchUList.Add(apTBOSearchUWork);
                        tBOSearchUCount++;
                    }
                    // AP部位コードマスタ（ユーザー登録）データ更新処理
                    else if (wktype.Equals(typeof(DCPartsPosCodeUWork)))
                    {
                        DCPartsPosCodeUWork partsPosCodeUWork = (DCPartsPosCodeUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (partsPosCodeUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = partsPosCodeUWork.UpdateDateTime;
                        }
                        APPartsPosCodeUWork apPartsPosCodeUWork = MstRecConvertReceive.SearchDataFromUpdateData(partsPosCodeUWork);
                        apPartsPosCodeUList.Add(apPartsPosCodeUWork);
                        partsPosCodeUCount++;
                    }
                    // APBLコードガイドマスタデータ更新処理
                    else if (wktype.Equals(typeof(DCBLCodeGuideWork)))
                    {
                        DCBLCodeGuideWork bLCodeGuideWork = (DCBLCodeGuideWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (bLCodeGuideWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = bLCodeGuideWork.UpdateDateTime;
                        }
                        APBLCodeGuideWork apBLCodeGuideWork = MstRecConvertReceive.SearchDataFromUpdateData(bLCodeGuideWork);
                        apBLCodeGuideList.Add(apBLCodeGuideWork);
                        bLCodeGuideCount++;
                    }
                    // AP車種名称マスタデータ更新処理
                    else if (wktype.Equals(typeof(DCModelNameUWork)))
                    {
                        DCModelNameUWork modelNameUWork = (DCModelNameUWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        if (modelNameUWork.UpdateDateTime > syncExecDt)
                        {
                            syncExecDt = modelNameUWork.UpdateDateTime;
                        }
                        APModelNameUWork apModelNameUWork = MstRecConvertReceive.SearchDataFromUpdateData(modelNameUWork);
                        apModelNameUList.Add(apModelNameUWork);
                        modelNameUCount++;
                    }
                    else
                    {
                        // 
                    }
                }
            }

            // 拠点情報設定データデータ
            updCSAList.Add(apSecInfoSetList);
            searchCountWork.SecInfoSetCount = secInfoSetCount;
            // 部門マスタデータ
            updCSAList.Add(apSubSectionList);
            searchCountWork.SubSectionCount = subSectionCount;
            // 従業員マスタデータ
            updCSAList.Add(apEmployeeList);
            searchCountWork.EmployeeCount = employeeCount;
            // 従業員詳細マスタデータ
            updCSAList.Add(apEmployeeDtlList);
            searchCountWork.EmployeeDtlCount = employeeDtlCount;
            // 倉庫マスタ
            updCSAList.Add(apWarehouseList);
            searchCountWork.WarehouseCount = warehouseCount;
            // 得意先マスタデータ
            updCSAList.Add(apCustomerList);
            searchCountWork.CustomerCount = customerCount;
            // 得意先マスタ(変動情報)データ
            updCSAList.Add(apCustomerChangeList);
            searchCountWork.CustomerChangeCount = customerChangeCount;
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136-------->>>>>
            // 得意先マスタ(メモ情報)データ
            updCSAList.Add(apCustomerMemoList);
            searchCountWork.CustomerMemoCount = customerMemoCount;
            // ------ ADD 2021/04/12 陳艶丹 FOR PMKOBETSU-4136--------<<<<<
            // 得意先マスタ（伝票管理）データ
            updCSAList.Add(apCustSlipMngList);
            searchCountWork.CustSlipMngCount = custSlipMngCount;
            // 得意先マスタ（掛率グループ）データ
            updCSAList.Add(apCustRateGroupList);
            searchCountWork.CustRateGroupCount = custRateGroupCount;
            // 得意先マスタ(伝票番号)データ
            updCSAList.Add(apCustSlipNoSetList);
            searchCountWork.CustSlipNoSetCount = custSlipNoSetCount;
            // 仕入先マスタ
            updCSAList.Add(apSupplierList);
            searchCountWork.SupplierCount = supplierCount;
            // メーカーマスタ（ユーザー登録分）データ
            updCSAList.Add(apMakerUList);
            searchCountWork.MakerUCount = makerUCount;
            // BL商品コードマスタ（ユーザー登録分）
            updCSAList.Add(apBLGoodsCdUList);
            searchCountWork.BLGoodsCdUCount = bLGoodsCdUCount;
            // 商品マスタ（ユーザー登録分）
            updCSAList.Add(apGoodsUList);
            searchCountWork.GoodsUCount = goodsUCount;
            // 価格マスタ（ユーザー登録）データ
            updCSAList.Add(apGoodsPriceList);
            searchCountWork.GoodsPriceCount = goodsPriceCount;
            // 商品管理情報マスタデータ
            updCSAList.Add(apGoodsMngList);
            searchCountWork.GoodsMngCount = goodsMngCount;
            // 離島価格マスタデータ
            updCSAList.Add(apIsolIslandPrcList);
            searchCountWork.IsolIslandPrcCount = isolIslandPrcCount;
            // 在庫マスタデータ
            updCSAList.Add(apStockList);
            searchCountWork.StockCount = stockCount;
            // ユーザーガイドマスタデータ
            updCSAList.Add(apUserGdBdUList);
            // ユーザーガイドマスタ(販売エリア区分）
            searchCountWork.UserGdAreaDivUCount = userGdAreaDivUCount;
            // ユーザーガイドマスタ（業務区分）
            searchCountWork.UserGdBusDivUCount = userGdBusDivUCount;
            // ユーザーガイドマスタ（業種）
            searchCountWork.UserGdCateUCount = userGdCateUCount;
            // ユーザーガイドマスタ（職種）
            searchCountWork.UserGdBusUCount = userGdBusUCount;
            // ユーザーガイドマスタ（商品区分）
            searchCountWork.UserGdGoodsDivUCount = userGdGoodsDivUCount;
            // ユーザーガイドマスタ（得意先掛率グループ）
            searchCountWork.UserGdCusGrouPUCount = userGdCusGrouPUCount;
            // ユーザーガイドマスタ（銀行）
            searchCountWork.UserGdBankUCount = userGdBankUCount;
            // ユーザーガイドマスタ（価格区分）
            searchCountWork.UserGdPriDivUCount = userGdPriDivUCount;
            // ユーザーガイドマスタ（納品区分）
            searchCountWork.UserGdDeliDivUCount = userGdDeliDivUCount;
            // ユーザーガイドマスタ（商品大分類）
            searchCountWork.UserGdGoodsBigUCount = userGdGoodsBigUCount;
            // ユーザーガイドマスタ（販売区分）
            searchCountWork.UserGdBuyDivUCount = userGdBuyDivUCount;
            // ユーザーガイドマスタ（在庫管理区分１）
            searchCountWork.UserGdStockDivOUCount = userGdStockDivOUCount;
            // ユーザーガイドマスタ（在庫管理区分２）
            searchCountWork.UserGdStockDivTUCount = userGdStockDivTUCount;
            // ユーザーガイドマスタ（返品理由）
            searchCountWork.UserGdReturnReaUCount = userGdReturnReaUCount;
            // 掛率優先管理マスタデータ
            updCSAList.Add(apRateProtyMngList);
            searchCountWork.RateProtyMngCount = rateProtyMngCount;
            // 掛率マスタデータ
            updCSAList.Add(apRateList);
            searchCountWork.RateCount = rateCount;
            // 商品セットマスタデータ
            updCSAList.Add(apGoodsSetList);
            searchCountWork.GoodsSetCount = goodsSetCount;
            // 部品代替マスタ（ユーザー登録分）データ
            updCSAList.Add(apPartsSubstUList);
            searchCountWork.PartsSubstUCount = partsSubstUCount;
            // 従業員別売上目標設定マスタデータ
            updCSAList.Add(apEmpSalesTargetList);
            searchCountWork.EmpSalesTargetCount = empSalesTargetCount;
            // 得意先別売上目標設定マスタデータ
            updCSAList.Add(apCustSalesTargetList);
            searchCountWork.CustSalesTargetCount = custSalesTargetCount;
            // 商品別売上目標設定マスタデータ
            updCSAList.Add(apGcdSalesTargetList);
            searchCountWork.GcdSalesTargetCount = gcdSalesTargetCount;
            // 商品中分類マスタ（ユーザー登録分）データ
            updCSAList.Add(apGoodsMGroupUList);
            searchCountWork.GoodsMGroupUCount = goodsMGroupUCount;
            // BLグループマスタ（ユーザー登録分）データ
            updCSAList.Add(apBLGroupUList);
            searchCountWork.BLGroupUCount = bLGroupUCount;
            // 結合マスタ（ユーザー登録分）データ
            updCSAList.Add(apJoinPartsUList);
            searchCountWork.JoinPartsUCount = joinPartsUCount;
            // TBO検索マスタ（ユーザー登録）データ
            updCSAList.Add(apTBOSearchUList);
            searchCountWork.TBOSearchUCount = tBOSearchUCount;
            // 部位コードマスタ（ユーザー登録）データ
            updCSAList.Add(apPartsPosCodeUList);
            searchCountWork.PartsPosCodeUCount = partsPosCodeUCount;
            // BLコードガイドマスタデータ
            updCSAList.Add(apBLCodeGuideList);
            searchCountWork.BLCodeGuideCount = bLCodeGuideCount;
            // 車種名称マスタデータ
            updCSAList.Add(apModelNameUList);
            searchCountWork.ModelNameUCount = modelNameUCount;

            return syncExecDt;
        }

        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
        /// <summary>
        /// 送受信抽出条件履歴ログデータ
        /// </summary>
        /// <param name="customerProcParam">得意先マスタ抽出条件</param>
        /// <returns></returns>
        public SndRcvEtrWork APCustomerProcParamToSndRcvEtrWork(APCustomerProcParamWork customerProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = customerProcParam.CustomerCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = customerProcParam.CustomerCodeEndRF.ToString();
            sndRcvEtrWork.StartCond2 = customerProcParam.KanaBeginRF;
            sndRcvEtrWork.EndCond2 = customerProcParam.KanaEndRF;
            sndRcvEtrWork.StartCond3 = customerProcParam.MngSectionCodeBeginRF;
            sndRcvEtrWork.EndCond3 = customerProcParam.MngSectionCodeEndRF;
            sndRcvEtrWork.StartCond4 = customerProcParam.CustomerAgentCdBeginRF;
            sndRcvEtrWork.EndCond4 = customerProcParam.CustomerAgentCdEndRF;
            sndRcvEtrWork.StartCond5 = customerProcParam.SalesAreaCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond5 = customerProcParam.SalesAreaCodeEndRF.ToString();
            sndRcvEtrWork.StartCond6 = customerProcParam.BusinessTypeCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond6 = customerProcParam.BusinessTypeCodeEndRF.ToString();
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// 送受信抽出条件履歴ログデータ
        /// </summary>
        /// <param name="goodsProcParam">商品マスタ抽出条件</param>
        /// <returns></returns>
        public SndRcvEtrWork APGoodsProcParamToSndRcvEtrWork(APGoodsProcParamWork goodsProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = goodsProcParam.SupplierCdBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = goodsProcParam.SupplierCdEndRF.ToString();
            sndRcvEtrWork.StartCond2 = goodsProcParam.GoodsMakerCdBeginRF.ToString();
            sndRcvEtrWork.EndCond2 = goodsProcParam.GoodsMakerCdEndRF.ToString();
            sndRcvEtrWork.StartCond3 = goodsProcParam.BLGoodsCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond3 = goodsProcParam.BLGoodsCodeEndRF.ToString();
            sndRcvEtrWork.StartCond4 = goodsProcParam.GoodsNoBeginRF;
            sndRcvEtrWork.EndCond4 = goodsProcParam.GoodsNoEndRF;
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// 送受信抽出条件履歴ログデータ
        /// </summary>
        /// <param name="stockProcParam">在庫マスタ抽出条件</param>
        /// <returns></returns>
        public SndRcvEtrWork APStockProcParamToSndRcvEtrWork(APStockProcParamWork stockProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = stockProcParam.WarehouseCodeBeginRF;
            sndRcvEtrWork.EndCond1 = stockProcParam.WarehouseCodeEndRF;
            sndRcvEtrWork.StartCond2 = stockProcParam.WarehouseShelfNoBeginRF;
            sndRcvEtrWork.EndCond2 = stockProcParam.WarehouseShelfNoEndRF;
            sndRcvEtrWork.StartCond3 = stockProcParam.SupplierCdBeginRF.ToString();
            sndRcvEtrWork.EndCond3 = stockProcParam.SupplierCdEndRF.ToString();
            sndRcvEtrWork.StartCond4 = stockProcParam.GoodsMakerCdBeginRF.ToString();
            sndRcvEtrWork.EndCond4 = stockProcParam.GoodsMakerCdEndRF.ToString();
            sndRcvEtrWork.StartCond5 = stockProcParam.BLGloupCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond5 = stockProcParam.BLGloupCodeEndRF.ToString();
            sndRcvEtrWork.StartCond6 = stockProcParam.GoodsNoBeginRF;
            sndRcvEtrWork.EndCond6 = stockProcParam.GoodsNoEndRF;
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// 送受信抽出条件履歴ログデータ
        /// </summary>
        /// <param name="supplierProcParam">仕入先マスタ抽出条件</param>
        /// <returns></returns>
        public SndRcvEtrWork APSupplierProcParamToSndRcvEtrWork(APSupplierProcParamWork supplierProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = supplierProcParam.SupplierCdBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = supplierProcParam.SupplierCdEndRF.ToString();
            sndRcvEtrWork.StartCond2 = "";
            sndRcvEtrWork.EndCond2 = "";
            sndRcvEtrWork.StartCond3 = "";
            sndRcvEtrWork.EndCond3 = "";
            sndRcvEtrWork.StartCond4 = "";
            sndRcvEtrWork.EndCond4 = "";
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// 送受信抽出条件履歴ログデータ
        /// </summary>
        /// <param name="rateProcParam">掛率マスタ抽出条件</param>
        /// <returns></returns>
        public SndRcvEtrWork APRateProcParamToSndRcvEtrWork(APRateProcParamWork rateProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = rateProcParam.UnitPriceKindRF;
            sndRcvEtrWork.EndCond1 = rateProcParam.SetFunRF;
            // --- DEL 2012/07/26 ------------------------->>>>>
            //sndRcvEtrWork.StartCond2 = rateProcParam.RateSettingDivideRF;
            //sndRcvEtrWork.EndCond2 = "";
            // --- DEL 2012/07/26 -------------------------<<<<<
            // --- ADD 2012/07/26 ------------------------->>>>>
            sndRcvEtrWork.StartCond2 = rateProcParam.SectionCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond2 = rateProcParam.SectionCodeEndRF.ToString();
            // --- ADD 2012/07/26 -------------------------<<<<<
            sndRcvEtrWork.StartCond3 = rateProcParam.CustRateGrpCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond3 = rateProcParam.CustRateGrpCodeEndRF.ToString();
            sndRcvEtrWork.StartCond4 = rateProcParam.CustomerCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond4 = rateProcParam.CustomerCodeEndRF.ToString();
            sndRcvEtrWork.StartCond5 = rateProcParam.SupplierCdBeginRF.ToString();
            sndRcvEtrWork.EndCond5 = rateProcParam.SupplierCdEndRF.ToString();
            sndRcvEtrWork.StartCond6 = rateProcParam.GoodsMakerCdBeginRF.ToString();
            sndRcvEtrWork.EndCond6 = rateProcParam.GoodsMakerCdEndRF.ToString();
            sndRcvEtrWork.StartCond7 = rateProcParam.GoodsRateRankBeginRF;
            sndRcvEtrWork.EndCond7 = rateProcParam.GoodsRateRankEndRF;
            sndRcvEtrWork.StartCond8 = rateProcParam.GoodsRateGrpCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond8 = rateProcParam.GoodsRateGrpCodeEndRF.ToString();
            sndRcvEtrWork.StartCond9 = rateProcParam.BLGoodsCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond9 = rateProcParam.BLGoodsCodeEndRF.ToString();
            sndRcvEtrWork.StartCond10 = rateProcParam.GoodsNoBeginRF;
            sndRcvEtrWork.EndCond10 = rateProcParam.GoodsNoEndRF;

            return sndRcvEtrWork;
        }
        // --- ADD 2012/07/26 ------------------------->>>>>
        /// <summary>
        /// 送受信抽出条件履歴ログデータ
        /// </summary>
        /// <param name="employeeProcParam">従業員設定マスタ抽出条件</param>
        /// <returns></returns>
        public SndRcvEtrWork APEmployeeProcParamToSndRcvEtrWork(APEmployeeProcParamWork employeeProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = employeeProcParam.BelongSectionCdBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = employeeProcParam.BelongSectionCdEndRF.ToString();
            sndRcvEtrWork.StartCond2 = employeeProcParam.EmployeeCdBeginRF.ToString();
            sndRcvEtrWork.EndCond2 = employeeProcParam.EmployeeCdEndRF.ToString();
            sndRcvEtrWork.StartCond3 = "";
            sndRcvEtrWork.EndCond3 = "";
            sndRcvEtrWork.StartCond4 = "";
            sndRcvEtrWork.EndCond4 = "";
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// 送受信抽出条件履歴ログデータ
        /// </summary>
        /// <param name="joinPartsUProcParam">結合マスタ抽出条件</param>
        /// <returns></returns>
        public SndRcvEtrWork APJoinPartsUProcParamToSndRcvEtrWork(APJoinPartsUProcParamWork joinPartsUProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = joinPartsUProcParam.JoinSourPartsNoWithHBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = joinPartsUProcParam.JoinSourPartsNoWithHEndRF.ToString();
            sndRcvEtrWork.StartCond2 = joinPartsUProcParam.JoinSourceMakerCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond2 = joinPartsUProcParam.JoinSourceMakerCodeEndRF.ToString();
            sndRcvEtrWork.StartCond3 = joinPartsUProcParam.JoinDispOrderBeginRF.ToString();
            sndRcvEtrWork.EndCond3 = joinPartsUProcParam.JoinDispOrderEndRF.ToString();
            sndRcvEtrWork.StartCond4 = joinPartsUProcParam.JoinDestMakerCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond4 = joinPartsUProcParam.JoinDestMakerCodeEndRF.ToString();
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }

        /// <summary>
        /// 送受信抽出条件履歴ログデータ
        /// </summary>
        /// <param name="userGdBuyDivUProcParam">ユーザーガイドマスタ(販売区分)抽出条件</param>
        /// <returns></returns>
        public SndRcvEtrWork APUserGdBuyDivUProcParamToSndRcvEtrWork(APUserGdBuyDivUProcParamWork userGdBuyDivUProcParam)
        {
            SndRcvEtrWork sndRcvEtrWork = new SndRcvEtrWork();

            sndRcvEtrWork.StartCond1 = userGdBuyDivUProcParam.GuideCodeBeginRF.ToString();
            sndRcvEtrWork.EndCond1 = userGdBuyDivUProcParam.GuideCodeEndRF.ToString();
            sndRcvEtrWork.StartCond2 = "";
            sndRcvEtrWork.EndCond2 = "";
            sndRcvEtrWork.StartCond3 = "";
            sndRcvEtrWork.EndCond3 = "";
            sndRcvEtrWork.StartCond4 = "";
            sndRcvEtrWork.EndCond4 = "";
            sndRcvEtrWork.StartCond5 = "";
            sndRcvEtrWork.EndCond5 = "";
            sndRcvEtrWork.StartCond6 = "";
            sndRcvEtrWork.EndCond6 = "";
            sndRcvEtrWork.StartCond7 = "";
            sndRcvEtrWork.EndCond7 = "";
            sndRcvEtrWork.StartCond8 = "";
            sndRcvEtrWork.EndCond8 = "";
            sndRcvEtrWork.StartCond9 = "";
            sndRcvEtrWork.EndCond9 = "";
            sndRcvEtrWork.StartCond10 = "";
            sndRcvEtrWork.EndCond10 = "";

            return sndRcvEtrWork;
        }
        // --- ADD 2012/07/26 -------------------------<<<<<

        /// <summary>
        /// 得意先マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns></returns>
        public CustomerProcParamWork SndRcvEtrWorkToCustomerProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            CustomerProcParamWork customerProcParam = new CustomerProcParamWork();

            customerProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            customerProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
            customerProcParam.KanaBeginRF = sndRcvEtrWork.StartCond2;
            customerProcParam.KanaEndRF = sndRcvEtrWork.EndCond2;
            customerProcParam.MngSectionCodeBeginRF = sndRcvEtrWork.StartCond3;
            customerProcParam.MngSectionCodeEndRF = sndRcvEtrWork.EndCond3;
            customerProcParam.CustomerAgentCdBeginRF = sndRcvEtrWork.StartCond4;
            customerProcParam.CustomerAgentCdEndRF = sndRcvEtrWork.EndCond4;
            customerProcParam.SalesAreaCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            customerProcParam.SalesAreaCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            customerProcParam.BusinessTypeCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
            customerProcParam.BusinessTypeCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);

            return customerProcParam;
        }

        /// <summary>
        /// 商品マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns></returns>
        public GoodsProcParamWork SndRcvEtrWorkToGoodsProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            GoodsProcParamWork goodsProcParam = new GoodsProcParamWork();

            goodsProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            goodsProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);
            goodsProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
            goodsProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
            goodsProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            goodsProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            goodsProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond4;
            goodsProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond4;

            return goodsProcParam;
        }

        /// <summary>
        /// 在庫マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns></returns>
        public StockProcParamWork SndRcvEtrWorkToStockProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            StockProcParamWork stockProcParam = new StockProcParamWork();

            stockProcParam.WarehouseCodeBeginRF = sndRcvEtrWork.StartCond1;
            stockProcParam.WarehouseCodeEndRF = sndRcvEtrWork.EndCond1;
            stockProcParam.WarehouseShelfNoBeginRF = sndRcvEtrWork.StartCond2;
            stockProcParam.WarehouseShelfNoEndRF = sndRcvEtrWork.EndCond2;
            stockProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            stockProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            stockProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            stockProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
            stockProcParam.BLGloupCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            stockProcParam.BLGloupCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            stockProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond6;
            stockProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond6;

            return stockProcParam;
        }

        /// <summary>
        /// 仕入先マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns></returns>
        public SupplierProcParamWork SndRcvEtrWorkToSupplierProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            SupplierProcParamWork supplierProcParam = new SupplierProcParamWork();

            supplierProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            supplierProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);

            return supplierProcParam;
        }

        /// <summary>
        /// 掛率マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns></returns>
        public RateProcParamWork SndRcvEtrWorkToRateProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            RateProcParamWork rateProcParam = new RateProcParamWork();

            rateProcParam.UnitPriceKindRF = sndRcvEtrWork.StartCond1;
            rateProcParam.SetFunRF = sndRcvEtrWork.EndCond1;
            // --- ADD 2012/07/26 ------------------------->>>>>
            rateProcParam.SectionCodeBeginRF = sndRcvEtrWork.StartCond2;
            rateProcParam.SectionCodeEndRF = sndRcvEtrWork.EndCond2;
            // --- ADD 2012/07/26 -------------------------<<<<<
            rateProcParam.CustRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            rateProcParam.CustRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            rateProcParam.CustomerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            rateProcParam.CustomerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);
            rateProcParam.SupplierCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond5);
            rateProcParam.SupplierCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond5);
            rateProcParam.GoodsMakerCdBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond6);
            rateProcParam.GoodsMakerCdEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond6);
            rateProcParam.GoodsRateRankBeginRF = sndRcvEtrWork.StartCond7;
            rateProcParam.GoodsRateRankEndRF = sndRcvEtrWork.EndCond7;
            rateProcParam.GoodsRateGrpCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond8);
            rateProcParam.GoodsRateGrpCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond8);
            rateProcParam.BLGoodsCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond9);
            rateProcParam.BLGoodsCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond9);
            rateProcParam.GoodsNoBeginRF = sndRcvEtrWork.StartCond10;
            rateProcParam.GoodsNoEndRF = sndRcvEtrWork.EndCond10;

            return rateProcParam;
        }
        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
        // --- ADD 2012/07/26 ------------------------->>>>>
        /// <summary>
        /// 従業員設定マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns></returns>
        public EmployeeProcParamWork SndRcvEtrWorkToEmployeeProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            EmployeeProcParamWork employeeProcParam = new EmployeeProcParamWork();

            employeeProcParam.BelongSectionCdBeginRF = sndRcvEtrWork.StartCond1;
            employeeProcParam.BelongSectionCdEndRF = sndRcvEtrWork.EndCond1;
            employeeProcParam.EmployeeCdBeginRF = sndRcvEtrWork.StartCond2;
            employeeProcParam.EmployeeCdEndRF = sndRcvEtrWork.EndCond2;

            return employeeProcParam;
        }

        /// <summary>
        /// 結合マスタ抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns></returns>
        public JoinPartsUProcParamWork SndRcvEtrWorkToJoinPartsUProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            JoinPartsUProcParamWork joinPartsUProcParam = new JoinPartsUProcParamWork();

            joinPartsUProcParam.JoinSourPartsNoWithHBeginRF = sndRcvEtrWork.StartCond1;
            joinPartsUProcParam.JoinSourPartsNoWithHEndRF = sndRcvEtrWork.EndCond1;
            joinPartsUProcParam.JoinSourceMakerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond2);
            joinPartsUProcParam.JoinSourceMakerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond2);
            joinPartsUProcParam.JoinDispOrderBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond3);
            joinPartsUProcParam.JoinDispOrderEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond3);
            joinPartsUProcParam.JoinDestMakerCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond4);
            joinPartsUProcParam.JoinDestMakerCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond4);

            return joinPartsUProcParam;
        }

        /// <summary>
        /// ユーザーガイドマスタ(販売区分)抽出条件
        /// </summary>
        /// <param name="sndRcvEtrWork">送受信抽出条件履歴ログデータ</param>
        /// <returns></returns>
        public UserGdBuyDivUProcParamWork SndRcvEtrWorkToUserGdBuyDivUProcParamWork(SndRcvEtrWork sndRcvEtrWork)
        {
            UserGdBuyDivUProcParamWork userGdBuyDivUProcParam = new UserGdBuyDivUProcParamWork();

            userGdBuyDivUProcParam.GuideCodeBeginRF = Convert.ToInt32(sndRcvEtrWork.StartCond1);
            userGdBuyDivUProcParam.GuideCodeEndRF = Convert.ToInt32(sndRcvEtrWork.EndCond1);

            return userGdBuyDivUProcParam;
        }
        // --- ADD 2012/07/26 -------------------------<<<<<
        # endregion ■ データ変換処理 ■

        #region ■ オフライン状態チェック処理 ■

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        public bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        /// <remarks>
        /// <br>Note       : リモート接続可能判定処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion ■ オフライン状態チェック処理 ■

        #region ■ 接続先チェック処理 ■
        /// <summary>
        /// 接続先チェック処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>判定結果</returns>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 接続先チェック処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>チェック処理結果</returns>
        public bool CheckConnect(string enterpriseCode, out int connectPointDiv, out string errMsg)
        {
            bool retResult = false;
            SecMngConnectSt secMngConnectSt = null;
            errMsg = null;
            connectPointDiv = 0;

            int status = this._secMngConnectStAcs.Search(out secMngConnectSt, enterpriseCode);
            if (status == 0)
            {
                connectPointDiv = secMngConnectSt.ConnectPointDiv;
                if (connectPointDiv == 0)
                {
                    // 接続先が「データセンター」の場合、正常として戻る。
                    retResult = true;
                }
                else
                {
                    // 接続先が「集計機」の場合
                    retResult = CheckRegistryKey(secMngConnectSt);
                    if (retResult == false)
                    {
                        errMsg = "接続先の設定が不正です。";
                    }
                }
            }
            else
            {
                errMsg = "接続先情報の取得処理に失敗しました。";
                retResult = false;
            }

            return retResult;
        }

        /// <summary>
        /// マスタ名称チェック処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="masterNameList">接続先区分</param>
        /// <returns>判定結果</returns>
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタ名称チェック処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        public bool CheckMasterDiv(string enterpriseCode, ArrayList masterNameList)
        {
            bool isContains = true;
            ArrayList masterNameCompareList = new ArrayList();
            ArrayList compareOneList = new ArrayList();
            ArrayList compareTwoList = new ArrayList();
            int status = this.LoadMstName(enterpriseCode, out masterNameCompareList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (SecMngSndRcvWork work in masterNameCompareList)
                {
                    compareOneList.Add(work.MasterName);
                }
            }

            foreach (SecMngSndRcvWork work in masterNameList)
            {
                compareTwoList.Add(work.MasterName);
            }


            foreach (string mastName in compareOneList)
            {
                if (!compareTwoList.Contains(mastName))
                {
                    isContains = false;
                    return isContains;
                }
            }

            foreach (string mastName in compareTwoList)
            {
                if (!compareOneList.Contains(mastName))
                {
                    isContains = false;
                    return isContains;
                }
            }

            return isContains;
        }

        /// <summary>
        /// 自動起動接続先チェック処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>判定結果</returns>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 自動起動接続先チェック処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>チェック処理結果</returns>
        public bool AutoServersCheckConnect(string enterpriseCode, out int connectPointDiv, out string errMsg)
        {
            bool retResult = false;
            SecMngConnectSt secMngConnectSt = null;
            errMsg = null;
            connectPointDiv = 0;

            int status = this._secMngConnectStAcs.Search(out secMngConnectSt, enterpriseCode);
            if (status == 0)
            {
                connectPointDiv = secMngConnectSt.ConnectPointDiv;
                if (connectPointDiv == 0 || connectPointDiv == 1)
                {
                    // 接続先が「データセンター」の場合、正常として戻る。
                    retResult = true;
                }
            }
            else
            {
                errMsg = "接続先情報の取得処理に失敗しました。";
                retResult = false;
            }

            return retResult;
        }

        /// <summary>レジストリからチェック処理
        /// <param name="secMngConnectSt">拠点管理接続先設定マスタオブジェクト</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : レジストリからチェック処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        private bool CheckRegistryKey(SecMngConnectSt secMngConnectSt)
        {
            bool retResult = false;
            try
            {
                string rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
                RegistryKey rKey1 = Registry.LocalMachine.OpenSubKey(rKeyName1, true);
                RegistryKey rKey2 = Registry.LocalMachine.OpenSubKey(rKeyName2, true);

                if (rKey1 != null && rKey2 != null)
                {
                    // レジストリ取込
                    string apServerIpAddress = rKey1.GetValue("%Domain%").ToString();
                    string dbServerIpAddress = rKey2.GetValue("%DataSource%").ToString();

                    if (String.IsNullOrEmpty(apServerIpAddress) || String.IsNullOrEmpty(dbServerIpAddress))
                    {
                        retResult = false;
                    }
                    else
                    {
                        retResult = (secMngConnectSt.ApServerIpAddress == apServerIpAddress) && (secMngConnectSt.DbServerIpAddress == dbServerIpAddress);
                    }
                }
                else
                {
                    // レジストリ情報が未設定の場合
                    retResult = false;
                }
            }
            catch (Exception)
            {
                retResult = false;
            }

            return retResult;
        }

        #endregion ■ 接続先チェック処理 ■

    }
}
