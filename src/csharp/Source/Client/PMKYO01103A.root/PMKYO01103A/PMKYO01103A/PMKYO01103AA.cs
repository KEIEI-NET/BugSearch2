//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内 数馬 
// 修 正 日  2011/02/01  修正内容 : 更新日時取得条件の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/07/29  修正内容 : SCM対応 拠点管理(10704767-00)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/24  修正内容 : Redmine #23808ソースレビュー結果の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/29  修正内容 : Redmine #24050ソースレビュー結果の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/31  修正内容 : Redmine #24278: データ自動受信処理が起動しません
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/09 修正内容 :  Redmine#246331伝票6明細のエラー詳細が表示されるを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2011/09/29 修正内容 :  エラーチェック時、締日チェックを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : dingjx
// 修 正 日  2011/11/01 修正内容 :  Redmine#26228拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/01  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : x_chenjm
// 修 正 日  2011/11/01  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/29  修正内容 : Redmine #8136 拠点管理／受信処理の締チェック処理変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/30  修正内容 : Redmine #8293 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 譚洪
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;
using System.Data;
using Microsoft.Win32;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 受信データアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入入力のアクセスクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>UpDate     : 劉洋　2009.04.28 データ追加</br>
    /// </remarks>
    public class DataReceiveInputAcs
    {
        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region ■Constructor
		/// <summary>
		/// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
		/// </summary>
        private DataReceiveInputAcs()
        {
            this._secMngConnectStAcs = new SecMngConnectStAcs();
            this._sendSetAcs = new SendSetAcs();
        }

        /// <summary>
        /// 仕入入力アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>仕入入力アクセスクラス インスタンス</returns>
        public static DataReceiveInputAcs GetInstance()
        {
            if (_dataReceiveInputAcs == null)
            {
                _dataReceiveInputAcs = new DataReceiveInputAcs();
            }

            return _dataReceiveInputAcs;
        }

        # endregion

        // ===================================================================================== //
        // プライベート変数2
        // ===================================================================================== //
        # region ■Private Members
        private static DataReceiveInputAcs _dataReceiveInputAcs;
        private DataReceive _dataReceive;
        private DataTable _resultDataTable;
        private DataReceive.DataReceiveConditionDataTable _conditionDataTable;
        private IDCControlDB _dCControlDB = null;
        private IAPSendMessageDB _extraAddUpdControlDB = null;
        private ISndRcvHisDB _extraRcvHisDB = null;//ADD 2011/07/30 SCM対応 拠点管理(10704767-00)
        private ISKControlDB _skControlDB = null;
        private ArrayList _secMngSetWorkList = new ArrayList();
        //ADD 2011/08/31 Redmine #24278 ------------------>>>>>
        private ISectionInfo _iSecInfo = null;
        private Hashtable secInfoSetWorkHash = new Hashtable();
        //ADD 2011/08/31 Redmine #24278 ------------------<<<<<
        // 拠点管理接続先設定アクセス
        private SecMngConnectStAcs _secMngConnectStAcs;
        // 送受信対象設定のアクセス
        SendSetAcs _sendSetAcs;
        ArrayList _sendDataList = new ArrayList();
        // 更新結果
        private int salesSlipCount = 0;
        private int salesDetailCount = 0;
        private int salesHistoryCount = 0;
        private int salesDtlHistCount = 0;
        private int depsitMainCount = 0;
        private int depsitDtlCount = 0;
        private int stockSlipCount = 0;
        private int stockDetailCount = 0;
        private int stockHistoryCount = 0;
        private int stockDtlHistCount = 0;
        private int paymentSlpCount = 0;
        private int paymentDtlCount = 0;
        private int acceptOdrCount = 0;
        private int acceptOdrCarCount = 0;
        //DEL 2011/08/29  #24050 ------->>>>>
        //private int mTtlSalesSlipCount = 0;
        //private int goodsSalesSlipCount = 0;
        //private int mTtlStockSlipCount = 0;
        //DEL 2011/08/29  #24050 -------<<<<<
        // ↓ 2009.04.28 liuyang add
        private int stockAdjustCount = 0;
        private int stockAdjustDtlCount = 0;
        private int stockMoveCount = 0;
        private int stockAcPayHistCount = 0;        
        // ↑ 2009.04.28 liuyang add
        //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------>>>>>
        private int depositAlwCount = 0;            //入金引当
        private int rcvDraftDataCount = 0;          //受取手形データ
        private int payDraftDataRF = 0;             //支払手形データ
        private bool _doSalesSlipFlg = false;       //売上要否フラグ
        private bool _doSalesDetailFlg = false;     //売上明細要否フラグ
        private bool _doAcceptOdrCarFlg = false;    //受注マスタ（車両）要否フラグ
        private bool _doAcceptOdrFlg = false;       //受注マスタ要否フラグ
        private bool _doSalesHistoryFlg = false;    //売上履歴要否フラグ
        private bool _doSalesHistDtlFlg = false;    //売上履歴明細要否フラグ
        private bool _doDepsitMainFlg = false;      //入金要否フラグ
        private bool _doDepsitDtlFlg = false;       //入金明細要否フラグ
        private bool _doStockSlipFlg = false;       //仕入要否フラグ
        private bool _doStockDetailFlg = false;     //仕入明細要否フラグ
        private bool _doStockSlipHistFlg = false;   //仕入履歴要否フラグ
        private bool _doStockSlHistDtlFlg = false;  //仕入履歴明細要否フラグ
        private bool _doPaymentSlpFlg = false;      //支払伝票要否フラグ
        private bool _doPaymentDtlFlg = false;      //支払明細要否フラグ
        //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------<<<<<
        private bool _autoSendRecvDiv = false;//true:自動,false:手動//ADD 2011/08/31 Redmine #24278: データ自動受信処理が起動しません

        private string[] updateData = new string[] { "売上データ", "売上明細データ", "売上履歴データ", "売上履歴明細データ",
            "入金データ", "入金明細データ", "仕入データ", "仕入明細データ", "仕入履歴データ", "仕入履歴明細データ", "支払データ", "支払明細データ",
            "受注マスタ", "車輌情報データ", "売上月次集計データ", "商品別売上月次集計データ", "仕入月次集計データ", "在庫仕入データ",
            "在庫仕入明細データ", "在庫移動データ", "在庫受払履歴データ"};

        # endregion

        // ===================================================================================== //
        // 外部に提供する定数群
        // ===================================================================================== //
        # region ■Public Readonly Members
        // private static readonly int defaultRowCount = 21;
        private static readonly string ctTableName_DataReceiveResult = "DataReceiveResult";
        private static readonly string ZERO_0 = "0";
        private static readonly string PROGRAM_ID = "PMKYO01103A";
        private static readonly string PROGRAM_NAME = "データ受信処理";
        //private static readonly string TABLENAME_SALESSLIP = "売上データ";
        //private static readonly string TABLENAME_SALESDETAIL = "売上明細データ";
        //private static readonly string TABLENAME_SALESHISTORY = "売上履歴データ";
        //private static readonly string TABLENAME_SALESHISTDTL = "売上履歴明細データ";
        //private static readonly string TABLENAME_DEPSITMAIN = "入金データ";
        //private static readonly string TABLENAME_DEPSITDTL = "入金明細データ";
        //private static readonly string TABLENAME_STOCKSLIP = "仕入データ";
        //private static readonly string TABLENAME_STOCKDETAIL = "仕入明細データ";
        //private static readonly string TABLENAME_STOCKSLIPHIST = "仕入履歴データ";
        //private static readonly string TABLENAME_STOCKSLHISTDTL = "仕入履歴明細データ";
        //private static readonly string TABLENAME_PAYMENTSLP = "支払データ";
        //private static readonly string TABLENAME_PAYMENTDTL = "支払明細データ";
        //private static readonly string TABLENAME_ACCEPTODR = "受注マスタ";
        //private static readonly string TABLENAME_ACCEPTODRCAR = "車輌情報データ";
        //private static readonly string TABLENAME_MTTLSALESSLIP = "売上月次集計データ";
        //private static readonly string TABLENAME_GOODSMTTLSASLIP = "商品別売上月次集計データ";
        //private static readonly string TABLENAME_MTTLSTOCKSLIP = "仕入月次集計データ";
        // ↓ 2009.04.28 liuyang add
        // private static readonly string TABLENAME_STOCKADJUST = "在庫仕入データ";
        // private static readonly string TABLENAME_STOCKADJUSTDTL = "在庫仕入明細データ";
        // private static readonly string TABLENAME_STOCKMOVE = "在庫移動データ";
        // private static readonly string TABLENAME_STOCKACPAYHIST = "在庫受払履歴データ";
        // ↑ 2009.04.28 liuyang add
        private static readonly string COUNTNAME = "件";
        //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------>>>>>
        private static readonly string ERRORMSG001 = "前回月次更新日以前です";
        private static readonly string ERRORMSG002 = "前回請求日以前です";
        private static readonly string ERRORMSG003 = "前回支払日以前です";
        private static readonly string ERRORMSG004 = "締月次受信エラー";
        private static readonly string ERRORMSGSPACE = "　";
        private const string ALL_SECTIONCODE = "00";
        private const string PROGRAMID = "PMKYO01100U";
        private const string PROGRAMNAME = "自動受信";        
        //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------<<<<<

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties

        /// <summary>
        /// データ受信結果テーブルオブジェクトを取得します。
        /// </summary>
        public ArrayList SecMngSetWorkList
        {
            get { return _secMngSetWorkList; }
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
        #endregion


        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region ■Public Methods
        /// <summary>
        /// 操作権限設定のUI用データセットを取得します。
        /// </summary>
        /// <value>操作権限設定のUI用データセット</value>
        /// <exception cref="ObjectDisposedException">処分済みです。</exception>
        public DataReceive DataReceive
        {
            get
            {
                if (_dataReceive == null)
                {
                    // 更新テーブル設定
                    _dataReceive = new DataReceive();
                    _dataReceive.Tables.Add(new DataTable(ctTableName_DataReceiveResult));
                    this._resultDataTable = _dataReceive.Tables[ctTableName_DataReceiveResult];
                    this._conditionDataTable = _dataReceive.DataReceiveCondition;
                    InitializeSettingDataSet();
                }
                return _dataReceive;
            }
        }

        /// <summary>
        /// 更新用データセットを初期化します。
        /// </summary>
        private void InitializeSettingDataSet()
        {
            this._resultDataTable.BeginLoadData();
            try
            {
                // 更新グリッドを設定する
                // 番号
                this._resultDataTable.Columns.Add(this._dataReceive.Setting.ResultRowNoColumn.ColumnName, typeof(int));
                this._resultDataTable.Columns[this._dataReceive.Setting.ResultRowNoColumn.ColumnName].DefaultValue = 0;
                this._resultDataTable.Columns[this._dataReceive.Setting.ResultRowNoColumn.ColumnName].Caption = this._dataReceive.Setting.ResultRowNoColumn.Caption;
                // 更新データ
                this._resultDataTable.Columns.Add(this._dataReceive.Setting.ResultNameColumn.ColumnName, typeof(string));
                this._resultDataTable.Columns[this._dataReceive.Setting.ResultNameColumn.ColumnName].DefaultValue = string.Empty;
                this._resultDataTable.Columns[this._dataReceive.Setting.ResultNameColumn.ColumnName].Caption = this._dataReceive.Setting.ResultNameColumn.Caption;
                // 更新結果
                for (int i = 0; i < _secMngSetWorkList.Count; i++)
                {
                    //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------------------------------------->>>>>
                    //APSecMngSetWork secMngSetWork = (APSecMngSetWork)this._secMngSetWorkList[i];
                    //this._resultDataTable.Columns.Add(secMngSetWork.SectionCode, typeof(string));
                    //this._resultDataTable.Columns[secMngSetWork.SectionCode].DefaultValue = string.Empty;
                    //this._resultDataTable.Columns[secMngSetWork.SectionCode].Caption = secMngSetWork.SectionGuideNm;
                    //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) -------------------------------------------------<<<<<
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------------------------------------->>>>>
                    SndRcvHisWork sndRcvHisWork = (SndRcvHisWork)this._secMngSetWorkList[i];
                    this._resultDataTable.Columns.Add(sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode + sndRcvHisWork.SndRcvHisConsNo.ToString(), typeof(string));
					this._resultDataTable.Columns[sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode + sndRcvHisWork.SndRcvHisConsNo.ToString()].DefaultValue = string.Empty;
					//this._resultDataTable.Columns[sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode + sndRcvHisWork.SndRcvHisConsNo.ToString()].Caption = GetSectionName(sndRcvHisWork.SectionCode);
					this._resultDataTable.Columns[sndRcvHisWork.EnterpriseCode + sndRcvHisWork.SectionCode + sndRcvHisWork.SndRcvHisConsNo.ToString()].Caption = GetSectionName(sndRcvHisWork.SectionCode) + "(" + GetSectionName(sndRcvHisWork.ExtraObjSecCode)+")";
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) -------------------------------------------------<<<<<
                }
            }
            finally
            {
                this._resultDataTable.EndLoadData();
            }
        }

        /// <summary>
        /// データ再設定
        /// </summary>
        public void DataSetAgain()
        {
            // 更新テーブル設定
            _dataReceive = new DataReceive();
            _dataReceive.Tables.Add(new DataTable(ctTableName_DataReceiveResult));
            this._resultDataTable = _dataReceive.Tables[ctTableName_DataReceiveResult];
            this._conditionDataTable = _dataReceive.DataReceiveCondition;
            InitializeSettingDataSet();
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■Private Methods
        /// <summary>
        /// データ受信結果テーブルの初期設定を行います。
        /// </summary>
        public void DataReceiveResultRowInitialSetting()
        {
            this._resultDataTable.BeginLoadData();
            // グリッド内容をクリアする
            this._resultDataTable.Rows.Clear();

            // 行数を設定する
            for (int i = 1; i <= this._sendDataList.Count; i++)
            {
                DataRow row = this._resultDataTable.NewRow();
                row[this._dataReceive.Setting.ResultRowNoColumn.ColumnName] = i;
                row[this._dataReceive.Setting.ResultNameColumn.ColumnName] = updateData[i - 1];

                this._resultDataTable.Rows.Add(row);
            }
            this._resultDataTable.EndLoadData();
        }

        /// <summary>
        /// データ受信結果テーブルの初期設定を行います。
        /// </summary>
        public void DataReceiveConditionRowInitialSetting()
        {
            this._conditionDataTable.BeginLoadData();
            // グリッド内容をクリアする
            this._conditionDataTable.Rows.Clear();

            // 行数を設定する
            for (int i = 1; i <= _secMngSetWorkList.Count; i++)
            {
                #region DEL
                //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                //APSecMngSetWork secMngSetWork = (APSecMngSetWork)_secMngSetWorkList[i - 1];

                //DataReceive.DataReceiveConditionRow row = this._conditionDataTable.NewDataReceiveConditionRow();
                //row.ConditionSectionCd = secMngSetWork.SectionCode;
                //row.ConditionSectionNm = secMngSetWork.SectionGuideNm;
                //// 開始時間
                //string startDateTime = Convert.ToString(secMngSetWork.SyncExecDate);
                //row.ConditionStartDate = secMngSetWork.SyncExecDate.Date;
                //row.ConditionStartTime = secMngSetWork.SyncExecDate.TimeOfDay.ToString().Substring(0, 8);
                //// 終了時間
                //string endDateTime = Convert.ToString(DateTime.Now);
                //row.ConditionEndDate = DateTime.Now.Date;
                //row.ConditionEndTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                #endregion
                //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                SndRcvHisWork sndRcvEtrWork = (SndRcvHisWork)_secMngSetWorkList[i - 1];
                DataReceive.DataReceiveConditionRow row = this._conditionDataTable.NewDataReceiveConditionRow();
                row.ConditionSectionCd = sndRcvEtrWork.SectionCode;
                row.ConditionSectionNm = GetSectionName(sndRcvEtrWork.SectionCode);
                row.ConditionDestSectionCd = sndRcvEtrWork.ExtraObjSecCode;
                row.ConditionDestSectionNm = GetSectionName(sndRcvEtrWork.ExtraObjSecCode);
                // ----- ADD xupz 2011/11/01 ---------->>>>>
                if (sndRcvEtrWork.SndLogExtraCondDiv == 0)
                {
                    row.ConditionExtraConDiv = "差分";
                }
                else if (sndRcvEtrWork.SndLogExtraCondDiv == 1)
                {
                    row.ConditionExtraConDiv = "伝票日付";
                }
                // ----- ADD xupz 2011/11/01 ----------<<<<<
                row.ConditionDestSectionNm = GetSectionName(sndRcvEtrWork.ExtraObjSecCode);


                // 開始時間
                DateTime startDateTime = sndRcvEtrWork.SndObjStartDate;
                row.ConditionStartDate = startDateTime.Date;
                row.ConditionStartTime = startDateTime.TimeOfDay.ToString().Substring(0, 8);
                // 終了時間
                DateTime endDateTime = sndRcvEtrWork.SndObjEndDate;
                row.ConditionEndDate = endDateTime.Date;
                row.ConditionEndTime = endDateTime.TimeOfDay.ToString().Substring(0, 8);
                //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<

                this._conditionDataTable.AddDataReceiveConditionRow(row);
            }

            this._conditionDataTable.EndLoadData();
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note        : 拠点名称を取得します。</br>
        /// <br>Programmer  : 孫東響</br>
        /// <br>Date        : 2011/07/30</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = string.Empty;
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません-------------->>>>>
            if (String.IsNullOrEmpty(sectionCode))
            {
                return sectionName;
            }
            else
            {
                sectionCode = sectionCode.Trim();
            }
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません--------------<<<<<
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "全社";
                return sectionName;
            }
            #region DEL
            //DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません-------------->>>>>
            //ArrayList retList = new ArrayList();
            //SecInfoAcs secInfoAcs = new SecInfoAcs();

            //try
            //{
            //    foreach(SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
            //    {
            //        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
            //        {
            //            sectionName = secInfoSet.SectionGuideNm.Trim();
            //            return sectionName;
            //        }
            //    }
            //}
            //catch
            //{
            //    sectionName = string.Empty;
            //}
            //DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません--------------<<<<<
            #endregion
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません-------------->>>>>
            if (secInfoSetWorkHash == null || secInfoSetWorkHash.Count == 0)
            {
                GetSecInfoSetWork(sectionCode);
            }
            if(secInfoSetWorkHash.Contains(sectionCode))
            {
                sectionName = secInfoSetWorkHash[sectionCode].ToString();
            }
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません--------------<<<<<
            
            return sectionName;
        }
        /// <summary>
        /// 拠点設定マスタ取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note        : 拠点設定マスタを取得します。</br>
        /// <br>Programmer  : 孫東響</br>
        /// <br>Date        : 2011/08/31</br>
        /// </remarks>
        private int GetSecInfoSetWork(string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            secInfoSetWorkHash = new Hashtable();
            if (_iSecInfo == null)
            {
                _iSecInfo = (ISectionInfo)MediationSectionInfo.GetSectionInfo();
            }
            SecInfoSetWork secInfoSetWork = new SecInfoSetWork();

            //キーの設定
            secInfoSetWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            secInfoSetWork.SectionCode = sectionCode;

            object paraobj = secInfoSetWork;
            object retobj = null;

            int errorLevel;
            string errorCode;
            string errorMessage;

            ArrayList wkSecInfoSetWorkList = null;
            status = _iSecInfo.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0, out errorLevel, out errorCode, out errorMessage);
  
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList AList = retobj as ArrayList;
                foreach (object obj in AList)
                {
                    ArrayList wkal = obj as ArrayList;
                    if (wkal.Count > 0)
                    {
                        if (wkal[0] is SecInfoSetWork) wkSecInfoSetWorkList = wkal;
                    }
                }
                //拠点名称をHashTableに格納
                foreach (SecInfoSetWork sec in wkSecInfoSetWorkList)
                {
                    //secInfoSetWorkHash.Add(sec.SectionCode, sec.SectionGuideNm);//DEL 2011/08/31 Redmine #24278
                    secInfoSetWorkHash.Add(sec.SectionCode.Trim(), sec.SectionGuideNm);//ADD 2011/08/31 Redmine #24278
                }
            }
            return status;
        }

        /// <summary>
        /// 初期化検索
        /// </summary>
        /// <returns>ステータス</returns>
        public int ReadInitData()
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            #region DEL
            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
            //ArrayList secMngSetWork = null;
            //string msg = "";            
            
            //// 拠点コントロール
            //if (this._extraAddUpdControlDB == null)
            //{
            //    this._extraAddUpdControlDB = (IAPSendMessageDB)APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
            //}

            //// 画面初期化検索            
            //stauts = this._extraAddUpdControlDB.SearchSecMngSetData(LoginInfoAcquisition.EnterpriseCode, out secMngSetWork, out msg);
            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
            #endregion

            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
            object secMngSetWork = new object();
            SndRcvHisCondWork sndRcvHisWork = new SndRcvHisCondWork();
            // 拠点コントロール
            if (this._extraRcvHisDB == null)
            {
                this._extraRcvHisDB = (ISndRcvHisDB)MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
            }

            sndRcvHisWork.Kind = 0;                 //0:データ　1:マスタ
            sndRcvHisWork.SendOrReceiveDivCd = 0;   //0:送信（出力）,1:受信（取込）
            sndRcvHisWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //sndRcvHisWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;//DEL 2011/08/31 Redmine #24278: データ自動受信処理が起動しません
            //ADD 2011/08/31 Redmine #24278: データ自動受信処理が起動しません ---------->>>>>
            string belongSectionCode = string.Empty;
            if (_autoSendRecvDiv)
            {
                stauts = GetBelongSectionCodeFormXml(ref belongSectionCode);
                if(stauts != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return stauts;
                }
                sndRcvHisWork.SectionCode = belongSectionCode;
            }
            else
            {
                sndRcvHisWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            }            
            //ADD 2011/08/31 Redmine #24278: データ自動受信処理が起動しません ----------<<<<<
            // 画面初期化検索
            stauts = this._extraRcvHisDB.Search(sndRcvHisWork, out secMngSetWork);
            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<

            //if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
            if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL || stauts == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
            {
                _secMngSetWorkList = new ArrayList();
                // 結果を保存する
                if (((ArrayList)secMngSetWork).Count > 0)
                {
                    //_secMngSetWorkList.AddRange((ArrayList)secMngSetWork);
                    for (int k = 0; k < ((ArrayList)secMngSetWork).Count; k++)
                    {
                        if (((ArrayList)secMngSetWork)[k] is ArrayList)
                        {
                        }
                        else
                        {
                            _secMngSetWorkList.Add(((ArrayList)secMngSetWork)[k]);
                        }
                    }
                    
                }
            }

            return stauts;
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
        /// 締次・月次のチェック
        /// </summary>
        /// <param name="errMsgList">戻りエラーメッセージリスト</param>
        /// <param name="errMsg">戻りエラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>		
        /// <br>Note		: 締次・月次のチェック処理を行う。</br>
        /// <br>Programmer	: 孫東響</br>	
        /// <br>Date		: 2011.07.29</br>
        /// </remarks>
        public bool CheckData(out ArrayList errMsgList,ref string errMsg)
        {
            errMsgList = new ArrayList();
            ArrayList errInfoList = new ArrayList();
            errMsg = "";

            try
            {
                ArrayList paramWorkList = new ArrayList();
                DateTime prevTotalDay;          //売上前回締次更新日付
                DateTime prevTotalDayMonthly;   //売上前回月次更新日付
                DateTime prevTotalDayPayment;          //仕入前回締次更新日付
                DateTime prevTotalDayPaymentMonthly;   //仕入前回月次更新日付
                DateTime hisTotalDay;       //売上起点日付
                DateTime hisTotalDayPayment;//仕入起点日付
                DateTime hisTotalDayMin;       //売上Min
                DateTime hisTotalDayPaymentMin;//仕入Min
                string errorInfo = "";
                string errorMsgMin = "";
                string errorMsgPayment = "";
                string errorMsgPaymentMin = "";
                bool saleCheckFlg = false;      //売上チェックフラグ
                bool depsitCheckFlg = false;    //入金チェックフラグ
                bool stockCheckFlg = false;     //仕入チェックフラグ
                bool paymentCheckFlg = false;   //支払いチェックフラグ

                //1.締・月次チェック起点日付の取得
                TotalDayCalculator toalDayCalculator = TotalDayCalculator.GetInstance();
                //売上締・月次日付の取得
                toalDayCalculator.GetHisTotalDayDmdC(string.Empty, out prevTotalDay);                //前回締次更新日付の取得                
                toalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDayMonthly);
                if (prevTotalDay.CompareTo(prevTotalDayMonthly) > 0)
                {
                    hisTotalDay = prevTotalDay;
                    hisTotalDayMin = prevTotalDayMonthly;
                    errorInfo = ERRORMSG002;
                    errorMsgMin = ERRORMSG001;
                }
                else
                {
                    hisTotalDay = prevTotalDayMonthly;
                    hisTotalDayMin = prevTotalDay;
                    errorInfo = ERRORMSG001;
                    errorMsgMin = ERRORMSG002;
                }

                //仕入締・月次日付の取得                
                toalDayCalculator.GetHisTotalDayPayment(string.Empty, out prevTotalDayPayment);             //前回締次更新日付の取得
                toalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDayPaymentMonthly);   //前回月次更新日付の取得
                if (prevTotalDayPayment.CompareTo(prevTotalDayPaymentMonthly) > 0)
                {
                    hisTotalDayPayment = prevTotalDayPayment;
                    hisTotalDayPaymentMin = prevTotalDayPaymentMonthly;
                    errorMsgPayment = ERRORMSG003;
                    errorMsgPaymentMin = ERRORMSG001;
                }
                else
                {
                    hisTotalDayPayment = prevTotalDayPaymentMonthly;
                    hisTotalDayPaymentMin = prevTotalDayPayment;
                    errorMsgPayment = ERRORMSG001;
                    errorMsgPaymentMin = ERRORMSG003;
                }                

                //2.DCから締・月次チェック起点日付以前のデータ取得
                for(int j =0; j<_sendDataList.Count;j++)
                {
                    SecMngSndRcv secMngSndRcv = (SecMngSndRcv)_sendDataList[j];
                    switch (secMngSndRcv.FileId)
                    {
                        // 売上データ
                        case "SalesSlipRF":
                            saleCheckFlg = true;
                            _doSalesSlipFlg = true;
                            break;
                        // 売上明細データ
                        case "SalesDetailRF":
                            _doSalesDetailFlg = true;
                            break;
                        // 売上履歴データ
                        case "SalesHistoryRF":
                            _doSalesHistoryFlg = true;
                            break;
                        // 売上履歴明細データ
                        case "SalesHistDtlRF":
                            _doSalesHistDtlFlg = true;
                            break;
                        // 入金データ
                        case "DepsitMainRF":
                            depsitCheckFlg = true;
                            _doDepsitMainFlg = true;
                            break;
                        // 入金明細データ
                        case "DepsitDtlRF":
                            _doDepsitDtlFlg = true;
                            break;
                        // 仕入データ
                        case "StockSlipRF":
                            stockCheckFlg = true;
                            _doStockSlipFlg = true;
                            break;
                        // 仕入明細データ
                        case "StockDetailRF":
                            _doStockDetailFlg = true;
                            break;
                        // 仕入履歴データ
                        case "StockSlipHistRF":
                            _doStockSlipHistFlg = true;
                            break;
                        // 仕入履歴明細データ
                        case "StockSlHistDtlRF":
                            _doStockSlHistDtlFlg = true;
                            break;
                        // 支払伝票マスタ
                        case "PaymentSlpRF":
                            paymentCheckFlg = true;
                            _doPaymentSlpFlg = true;
                            break;
                        // 支払明細データ
                        case "PaymentDtlRF":
                            _doPaymentDtlFlg = true;
                            break;
                        // 受注マスタ
                        case "AcceptOdrRF":
                            _doAcceptOdrFlg = true;
                            break;
                        // 受注マスタ（車両）
                        case "AcceptOdrCarRF":
                            _doAcceptOdrCarFlg = true;
                            break;
                        default:
                            break;
                    }
                }
                //売上締・月次日付なし、仕入締・月次日付なし
                if (hisTotalDay.CompareTo(hisTotalDayPayment) == 0 && hisTotalDay.CompareTo(DateTime.MinValue) == 0)
                {
                    return true;
                }
                for (int i = 0; i < _secMngSetWorkList.Count; i++)
                {
                    SndRcvHisWork sndRcvEtrWork = (SndRcvHisWork)_secMngSetWorkList[i];
                    DCReceiveDataWork paraWork = new DCReceiveDataWork();
                    paraWork.PmSectionCode = sndRcvEtrWork.ExtraObjSecCode;
                    paraWork.StartDateTime = sndRcvEtrWork.SndObjStartDate.Ticks;
                    paraWork.EndDateTime = sndRcvEtrWork.SndObjEndDate.Ticks;
                    paraWork.PmEnterpriseCode = sndRcvEtrWork.EnterpriseCode;//ADD by Liangsd   2011/09/06 Redmine #24633

                    paraWork.DoSalesSlipFlg = _doSalesSlipFlg;          //売上要否フラグ
                    paraWork.DoSalesDetailFlg = _doSalesDetailFlg;      //売上明細要否フラグ
                    paraWork.DoAcceptOdrCarFlg = _doAcceptOdrCarFlg;    //受注マスタ（車両）要否フラグ
                    paraWork.DoAcceptOdrFlg = _doAcceptOdrFlg;          //受注マスタ要否フラグ
                    paraWork.DoSalesHistoryFlg = _doSalesHistoryFlg;    //売上履歴要否フラグ
                    paraWork.DoSalesHistDtlFlg = _doSalesHistDtlFlg;    //売上履歴明細要否フラグ
                    paraWork.DoDepsitMainFlg = _doDepsitMainFlg;        //入金要否フラグ
                    paraWork.DoDepsitDtlFlg = _doDepsitDtlFlg;          //入金明細要否フラグ
                    paraWork.DoStockSlipFlg = _doStockSlipFlg;          //仕入要否フラグ
                    paraWork.DoStockDetailFlg = _doStockDetailFlg;      //仕入明細要否フラグ
                    paraWork.DoStockSlipHistFlg = _doStockSlipHistFlg;  //仕入履歴要否フラグ
                    paraWork.DoStockSlHistDtlFlg = _doStockSlHistDtlFlg;//仕入履歴明細要否フラグ
                    paraWork.DoPaymentSlpFlg = _doPaymentSlpFlg;        //支払伝票要否フラグ
                    paraWork.DoPaymentDtlFlg = _doPaymentDtlFlg;        //支払明細要否フラグ
                    paraWork.EndDateTimeTicks = sndRcvEtrWork.SyncExecDate.Ticks; // ADD 2011/12/07
                    paraWork.SndLogExtraCondDiv = sndRcvEtrWork.SndLogExtraCondDiv; //送受信ログ抽出条件区分  // ADD 2011/11/29
                        
                    paramWorkList.Add(paraWork);
                }
                // データセンター
                if (this._dCControlDB == null)
                {
                    this._dCControlDB = (IDCControlDB)MediationDCControlDB.GetDCControlDB();
                }

                _dCControlDB.SimeCheckSCM(out errMsgList, paramWorkList, long.Parse(hisTotalDay.ToString("yyyyMMdd")), long.Parse(hisTotalDayPayment.ToString("yyyyMMdd")), saleCheckFlg, depsitCheckFlg, stockCheckFlg, paymentCheckFlg);
      

                if (errMsgList.Count == 0)
                {
                    return true;
                }
                //ErrorList処理
                int hisDayMin = Convert.ToInt32(hisTotalDayMin.ToString("yyyyMMdd"));
                int hisDayPaymentMin = Convert.ToInt32(hisTotalDayPaymentMin.ToString("yyyyMMdd"));
                foreach (object err in errMsgList)
                {
                    ERInfoDataWork errWork = (ERInfoDataWork)err;
                    PMKYO01901EA errInfo = new PMKYO01901EA();
                    //①売上データ・入金マスタの場合
                    if (errWork.ErSlipNm == "売上" || errWork.ErSlipNm == "入金")
                    {
                        
                        // 2011/09/29 Add >>>
                        int yyyy = errWork.ErDateTime / 10000;
                        int mm = errWork.ErDateTime / 100 % 100;
                        int dd = errWork.ErDateTime % 100;
                        DateTime checkDay = new DateTime(yyyy, mm, dd);
                        // 売上締次チェック
                        if (!toalDayCalculator.CheckDmdC(errWork.ErSectionCode, errWork.ErCustCode, checkDay))
                        {
                            // 売上月次チェック
                            if (!toalDayCalculator.CheckMonthlyAccRec(errWork.ErSectionCode, errWork.ErCustCode, checkDay))
                            {
                                continue;
                            }
                            else
                            {
                                // 売上月次チェックでエラー
                                errWork.ErInfo = ERRORMSG001;
                            }
                        }
                        else
                        {
                            // 売上締次チェックでエラー
                            errWork.ErInfo = ERRORMSG002;
                        }
                        // 2011/09/29 Add <<<
                        // 2011/09/29 Del >>>
                        //if (hisDayMin >= errWork.ErDateTime)
                        //{
                        //    errWork.ErInfo = errorMsgMin;
                        //}
                        //else
                        //{
                        //    errWork.ErInfo = errorInfo;
                        //}
                        // 2011/09/29 Del <<<
                    }
                    //仕入データ・支払伝票マスタの場合
                    if (errWork.ErSlipNm == "仕入" || errWork.ErSlipNm == "支払")
                    {
                        // 2011/09/29 Add >>>
                        int yyyy = errWork.ErDateTime / 10000;
                        int mm = errWork.ErDateTime / 100 % 100;
                        int dd = errWork.ErDateTime % 100;
                        DateTime checkDay = new DateTime(yyyy, mm, dd);
                        // 仕入締次チェック
                        if (!toalDayCalculator.CheckPayment(errWork.ErSectionCode, errWork.ErCustCode, checkDay))
                        {
                            // 仕入月次チェック
                            if (!toalDayCalculator.CheckMonthlyAccPay(errWork.ErSectionCode, errWork.ErCustCode, checkDay))
                            {
                                continue;
                            }
                            else
                            {
                                // 仕入月次チェックでエラー
                                errWork.ErInfo = ERRORMSG001;
                            }
                        }
                        else
                        {
                            // 仕入締次チェックでエラー
                            errWork.ErInfo = ERRORMSG003;
                        }
                        // 2011/09/29 Add <<<
                        // 2011/09/29 Del >>>
                        //if (hisDayPaymentMin >= errWork.ErDateTime)
                        //{
                        //    errWork.ErInfo = errorMsgPaymentMin;
                        //}
                        //else
                        //{
                        //    errWork.ErInfo = errorMsgPayment;
                        //}
                        // 2011/09/29 Del <<<
                    }

                    errInfo.NoFlg = errWork.ErSlipNm;
                    errInfo.No = errWork.ErSalesSlipNum;
					errInfo.Date = TDateTime.LongDateToString("YYYY/MM/DD", errWork.ErDateTime);
                    errInfo.SectionCode = errWork.ErSectionCode.Trim();
					errInfo.SectionNm = GetSectionName(errWork.ErSectionCode.Trim());
                    errInfo.CustomerCode = errWork.ErCustCode.ToString();
                    errInfo.CustomerNm = errWork.ErCustName;
                    errInfo.Error = errWork.ErInfo;
                    errInfoList.Add(errInfo);
                    
                }
                errMsgList = errInfoList;

                // 2011/09/29 Add >>>
                if (errMsgList.Count == 0)
                    return true;
                // 2011/09/29 Add <<<

                return false;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 保存前チェック
        /// </summary>
        //public int SaveData(int connectPointDiv)  // DEL 2011/11/29
        public int SaveData(ArrayList errMsgList, int connectPointDiv)  // ADD 2011/11/29
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            try
            {
                // 保存処理
                if (this._extraAddUpdControlDB == null)
                {
                    this._extraAddUpdControlDB = (IAPSendMessageDB)APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
                }

                if (connectPointDiv == 0)
                {
                    // データセンター
                    if (this._dCControlDB == null)
                    {
                        this._dCControlDB = (IDCControlDB)MediationDCControlDB.GetDCControlDB();
                    }
                }
                else
                {
                    // 集計機
                    if (this._skControlDB == null)
                    {
                        this._skControlDB = (ISKControlDB)MediationSKControlDB.GetSKControlDB();
                    }
                }

                // 抽出結果なし
                bool _dataFlg = false;
                bool _errorFlg = false;

                // 拠点更新
                int i = 0;
                //foreach (DataReceive.DataReceiveConditionRow row in this._conditionDataTable)//DEL 2011/07/29 SCM対応-拠点管理
                foreach (SndRcvHisWork secMngSetWork in _secMngSetWorkList)//ADD 2011/07/29 SCM対応-拠点管理
                {
                    // 拠点リスト
                    ArrayList sectionCodeList = new ArrayList();
                    //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ----------------------------------------->>>>>
                    //foreach (DataReceive.DataReceiveConditionRow code in this._conditionDataTable)
                    //{
                    //    sectionCodeList.Add(code.ConditionSectionCd);
                    //}
                    //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) -----------------------------------------<<<<<
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ----------------------------------------->>>>>
                    foreach (SndRcvHisWork secMngSetWorkCopy in _secMngSetWorkList)
                    {
                        sectionCodeList.Add(secMngSetWorkCopy.SectionCode);
                    }
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) -----------------------------------------<<<<<


                    object outreceiveList = null;
                    DCReceiveDataWork parareceiveWork = new DCReceiveDataWork();
                    #region DEL
                    //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ----------------------------------------->>>>>
                    //APSecMngSetWork secMngSetWork = new APSecMngSetWork();                    
                    //// 情報を取得
                    //foreach (APSecMngSetWork secMngSet in this._secMngSetWorkList)                 
                    //{
                    //    if (secMngSet.SectionCode == row.ConditionSectionCd)
                    //    {
                    //        secMngSetWork = secMngSet;
                    //        break;
                    //    }
                    //}
                    
                    //// 企業コード
                    //parareceiveWork.PmEnterpriseCode = secMngSetWork.PmEnterpriseCode;
                    //// 開始時間
                    //if (secMngSetWork.SyncExecDate.Year == row.ConditionStartDate.Year
                    //    && secMngSetWork.SyncExecDate.Month == row.ConditionStartDate.Month
                    //    && secMngSetWork.SyncExecDate.Day == row.ConditionStartDate.Day
                    //    && secMngSetWork.SyncExecDate.Hour == Convert.ToInt32(row.ConditionStartTime.Substring(0, 2))
                    //    && secMngSetWork.SyncExecDate.Minute == Convert.ToInt32(row.ConditionStartTime.Substring(3, 2))
                    //    && secMngSetWork.SyncExecDate.Second == Convert.ToInt32(row.ConditionStartTime.Substring(6, 2)))
                    //{
                    //    parareceiveWork.StartDateTime = secMngSetWork.SyncExecDate.Ticks;
                    //}
                    //else
                    //{
                    //    parareceiveWork.StartDateTime = new DateTime(row.ConditionStartDate.Year, row.ConditionStartDate.Month, row.ConditionStartDate.Day,
                    //            Convert.ToInt32(row.ConditionStartTime.Substring(0, 2)), Convert.ToInt32(row.ConditionStartTime.Substring(3, 2)), Convert.ToInt32(row.ConditionStartTime.Substring(6, 2))).Ticks;
                    //}                    
                    //// 終了時間
                    //parareceiveWork.EndDateTime = new DateTime(row.ConditionEndDate.Year, row.ConditionEndDate.Month, row.ConditionEndDate.Day,
                    //        Convert.ToInt32(row.ConditionEndTime.Substring(0, 2)), Convert.ToInt32(row.ConditionEndTime.Substring(3, 2)), Convert.ToInt32(row.ConditionEndTime.Substring(6, 2))).Ticks;
                    //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) -----------------------------------------<<<<<
                    #endregion
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ----------------------------------------->>>>>
                    parareceiveWork.PmEnterpriseCode = secMngSetWork.EnterpriseCode;
                    //  ADD x_chenjm  2011/11/01  --------------->>>>>>
                    if (secMngSetWork.Kind == 0 && secMngSetWork.SndLogExtraCondDiv==1)
                    {
                        parareceiveWork.StartDateTime =
                            Convert.ToInt32(secMngSetWork.SndObjStartDate.ToString("yyyyMMdd"));
                        parareceiveWork.EndDateTime = Convert.ToInt32(secMngSetWork.SndObjEndDate.ToString("yyyyMMdd"));

                        parareceiveWork.EndDateTimeTicks = secMngSetWork.SndObjEndDate.Ticks; //  ADD tanh  2011/11/30
                    }
                    else
                    {
                    //  ADD x_chenjm  2011/11/01  ---------------<<<<<<
                    parareceiveWork.StartDateTime = secMngSetWork.SndObjStartDate.Ticks;
                    parareceiveWork.EndDateTime = secMngSetWork.SndObjEndDate.Ticks;
                    }//  ADD x_chenjm  2011/11/01
                    parareceiveWork.PmSectionCode = secMngSetWork.ExtraObjSecCode;
                    //  ADD dingjx  2011/11/01  --------------->>>>>>
                    parareceiveWork.Kind = secMngSetWork.Kind;
                    parareceiveWork.SndLogExtraCondDiv = secMngSetWork.SndLogExtraCondDiv;
                    //  ADD dingjx  2011/11/01  ---------------<<<<<<

                    parareceiveWork.SyncExecDate = secMngSetWork.SyncExecDate.Ticks; //  ADD tanh  2011/11/30

                    parareceiveWork.DoSalesSlipFlg = _doSalesSlipFlg;          //売上要否フラグ
                    parareceiveWork.DoSalesDetailFlg = _doSalesDetailFlg;      //売上明細要否フラグ
                    parareceiveWork.DoAcceptOdrCarFlg = _doAcceptOdrCarFlg;    //受注マスタ（車両）要否フラグ
                    parareceiveWork.DoAcceptOdrFlg = _doAcceptOdrFlg;          //受注マスタ要否フラグ
                    parareceiveWork.DoSalesHistoryFlg = _doSalesHistoryFlg;    //売上履歴要否フラグ
                    parareceiveWork.DoSalesHistDtlFlg = _doSalesHistDtlFlg;    //売上履歴明細要否フラグ
                    parareceiveWork.DoDepsitMainFlg = _doDepsitMainFlg;        //入金要否フラグ
                    parareceiveWork.DoDepsitDtlFlg = _doDepsitDtlFlg;          //入金明細要否フラグ
                    parareceiveWork.DoStockSlipFlg = _doStockSlipFlg;          //仕入要否フラグ
                    parareceiveWork.DoStockDetailFlg = _doStockDetailFlg;      //仕入明細要否フラグ
                    parareceiveWork.DoStockSlipHistFlg = _doStockSlipHistFlg;  //仕入履歴要否フラグ
                    parareceiveWork.DoStockSlHistDtlFlg = _doStockSlHistDtlFlg;//仕入履歴明細要否フラグ
                    parareceiveWork.DoPaymentSlpFlg = _doPaymentSlpFlg;        //支払伝票要否フラグ
                    parareceiveWork.DoPaymentDtlFlg = _doPaymentDtlFlg;        //支払明細要否フラグ
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) -----------------------------------------<<<<<
                    // ファイルID配列
                    string[] fileIds = new string[this._sendDataList.Count];
                    for (int j = 0; j < this._sendDataList.Count; j++)
                    {
                        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
                        fileIds[j] = secMngSndRcv.FileId;
                        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                        if (fileIds[j].Equals("SalesSlipRF"))
                        {
                            //受注データ受信区分
                            parareceiveWork.AcptAnOdrRecvDiv = secMngSndRcv.AcptAnOdrRecvDiv;
                            //貸出データ受信区分
                            parareceiveWork.ShipmentRecvDiv = secMngSndRcv.ShipmentRecvDiv;
                            //見積データ受信区分
                            parareceiveWork.EstimateRecvDiv = secMngSndRcv.EstimateRecvDiv;
                        }
                        // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
                    }

                    if (connectPointDiv == 0)
                    {
                        //stauts = this._dCControlDB.Search(out outreceiveList, parareceiveWork, row.ConditionSectionCd, fileIds);//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                        stauts = this._dCControlDB.SearchSCM(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)

                        // -- ADD 2011/11/29 --- >>>
                        if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            this.ConvertreceiveList(errMsgList, ref outreceiveList); 
                        }
                        // -- ADD 2011/11/29 --- <<<
                    }
                    else
                    {
                        //stauts = this._skControlDB.Search(out outreceiveList, parareceiveWork, row.ConditionSectionCd, fileIds);//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                        stauts = this._skControlDB.Search(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                    }

                    // 抽出結果
                    if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {

                        // データ変換
                        object receiveList = null;
                        // -- UPD 2011/02/01 ------------------------------------>>>
                        //long updateTime = this.DivisionCustomSerializeArrayList(out receiveList, outreceiveList);
                        long updateTime = this.DivisionCustomSerializeArrayList(out receiveList, outreceiveList, parareceiveWork);
                        // -- UPD 2011/02/01 ------------------------------------<<<

                        _dataFlg = true;

                        // 変更処理
                        stauts = this._extraAddUpdControlDB.UpdateCustomSerializeArrayList(
                            LoginInfoAcquisition.EnterpriseCode, receiveList, sectionCodeList, ref stockAcPayHistCount);

                        // 正常の場合、シック時間を更新する
                        if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            #region DEL
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------------->>>>>
                            //if (secMngSetWork.SyncExecDate.Ticks < updateTime)
                            //{
                            //    secMngSetWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                            //    secMngSetWork.UpdateDateTime = DateTime.Now;
                            //    secMngSetWork.SectionCode = row.ConditionSectionCd;
                            //    secMngSetWork.Kind = 0;
                            //    secMngSetWork.ReceiveCondition = 1;
                            //    secMngSetWork.UpdEmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
                            //    // 更新処理
                            //    this._extraAddUpdControlDB.UpdateSecMngSetData(secMngSetWork, updateTime);
                            //}                            
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) -------------------------<<<<<
                            #endregion

                            string logStr = string.Empty;

                            for (int m = 0; m < this._sendDataList.Count; m++)
                            {
                                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[m];
                                if (logStr == string.Empty)
                                {
                                    logStr += secMngSndRcv.FileNm + " ";
                                }
                                else
                                {
                                    logStr += "、" + secMngSndRcv.FileNm + " ";
                                }
                                switch (secMngSndRcv.FileId)
                                {
                                    // 売上データ
                                    case "SalesSlipRF":
                                        logStr += IntConvert(salesSlipCount, false);
                                        break;
                                    // 売上明細データ
                                    case "SalesDetailRF":
                                        logStr += IntConvert(salesDetailCount, false);
                                        break;
                                    // 売上履歴データ
                                    case "SalesHistoryRF":
                                        logStr += IntConvert(salesHistoryCount, false);
                                        break;
                                    // 売上履歴明細データ
                                    case "SalesHistDtlRF":
                                        logStr += IntConvert(salesDtlHistCount, false);
                                        break;
                                    // 入金データ
                                    case "DepsitMainRF":
                                        logStr += IntConvert(depsitMainCount, false);
                                        break;
                                    // 入金明細データ
                                    case "DepsitDtlRF":
                                        logStr += IntConvert(depsitDtlCount, false);
                                        break;
                                    // 仕入データ
                                    case "StockSlipRF":
                                        logStr += IntConvert(stockSlipCount, false);
                                        break;
                                    // 仕入明細データ
                                    case "StockDetailRF":
                                        logStr += IntConvert(stockDetailCount, false);
                                        break;
                                    // 仕入履歴データ
                                    case "StockSlipHistRF":
                                        logStr += IntConvert(stockHistoryCount, false);
                                        break;
                                    // 仕入履歴明細データ
                                    case "StockSlHistDtlRF":
                                        logStr += IntConvert(stockDtlHistCount, false);
                                        break;
                                    // 支払伝票マスタ
                                    case "PaymentSlpRF":
                                        logStr += IntConvert(paymentSlpCount, false);
                                        break;
                                    // 支払明細データ
                                    case "PaymentDtlRF":
                                        logStr += IntConvert(paymentDtlCount, false);
                                        break;
                                    // 受注マスタ
                                    case "AcceptOdrRF":
                                        logStr += IntConvert(acceptOdrCount, false);
                                        break;
                                    // 受注マスタ（車両）
                                    case "AcceptOdrCarRF":
                                        logStr += IntConvert(acceptOdrCarCount, false);
                                        break;
                                    //DEL 2011/08/29  #24050 --------------------------->>>>>
                                    //// 売上月次集計データ
                                    //case "MTtlSalesSlipRF":
                                    //    logStr += IntConvert(mTtlSalesSlipCount, false);
                                    //    break;
                                    //// 商品別売上月次集計データ
                                    //case "GoodsMTtlSaSlipRF":
                                    //    logStr += IntConvert(goodsSalesSlipCount, false);
                                    //    break;
                                    //// 仕入月次集計データ
                                    //case "MTtlStockSlipRF":
                                    //    logStr += IntConvert(mTtlStockSlipCount, false);
                                    //    break;
                                    //DEL 2011/08/29  #24050 ---------------------------<<<<<
                                    // 在庫調整データ
                                    case "StockAdjustRF":
                                        logStr += IntConvert(stockAdjustCount, false);
                                        break;
                                    // 在庫調整明細データ
                                    case "StockAdjustDtlRF":
                                        logStr += IntConvert(stockAdjustDtlCount, false);
                                        break;
                                    // 在庫移動データ
                                    case "StockMoveRF":
                                        logStr += IntConvert(stockMoveCount, false);
                                        break;
                                    //DEL 2011/08/29  #24050 --------------------------->>>>>
                                    //// 在庫受払履歴データ
                                    //case "StockAcPayHistRF":
                                    //    logStr += IntConvert(stockAcPayHistCount, false);
                                    //    break;
                                    //DEL 2011/08/29  #24050 ---------------------------<<<<<
                                    // 入金引当データ
                                    case "DepositAlwRF":
                                        logStr += IntConvert(depositAlwCount, false);
                                        break;
                                    // 受取手形データ
                                    case "RcvDraftDataRF":
                                        logStr += IntConvert(rcvDraftDataCount, false);
                                        break;
                                    // 支払手形データ
                                    case "PayDraftDataRF":
                                        logStr += IntConvert(payDraftDataRF, false);
                                        break;
                                }
                            }

                            // ログ書き
                            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                //logStr, "正常(拠点：" + row.ConditionSectionCd.Trim() + ")");//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                                    logStr, "正常(拠点：" + secMngSetWork.SectionCode.Trim() + ")");//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                            
                            for (int k = 0; k < this._sendDataList.Count; k++)
                            {
                                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[k];
                                // 画面表示
                                //this._resultDataTable.Rows[k][row.ConditionSectionCd] = GetCount(secMngSndRcv.FileId);//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                                this._resultDataTable.Rows[k][secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()] = GetCount(secMngSndRcv.FileId);//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                            }

                            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                            if (this._extraRcvHisDB == null)
                            {
                                this._extraRcvHisDB = (ISndRcvHisDB)MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
                            }

                            ArrayList logObj = new ArrayList();
                            secMngSetWork.SendOrReceiveDivCd = 1;
                            logObj.Add(secMngSetWork);

                            // 送信履歴ログデータの更新
                            stauts = this._extraRcvHisDB.WriteRcvHisWork(ref logObj);
                            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                        }
                        else if (stauts == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            for (int k = 0; k < this._sendDataList.Count; k++)
                            {
                                // 画面表示
                                //this._resultDataTable.Rows[k][row.ConditionSectionCd] = "×";//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                                this._resultDataTable.Rows[k][secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()] = "×";//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                            }
                            // ログ書き
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                            //// ↓ 2009.06.17 劉洋 modify PVCS.160
                            //// operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + row.ConditionSectionCd.Trim() + ")");
                            //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + row.ConditionSectionCd.Trim() + ")", string.Empty);
                            //// ↑ 2009.06.17 劉洋 modify
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                            operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);
                            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                            _errorFlg = true;
                        }
                        else
                        {
                            return stauts;
                        }
                    }
                    else if (stauts == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        for (int k = 0; k < this._sendDataList.Count; k++)
                        {
                            //this._resultDataTable.Rows[k][row.ConditionSectionCd] = ZERO_0 + " " + COUNTNAME;//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                            this._resultDataTable.Rows[k][secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()] = ZERO_0 + " " + COUNTNAME;//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                        }
                    }
                    else if (stauts == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        for (int k = 0; k < this._sendDataList.Count; k++)
                        {
                            // 画面表示
                            //this._resultDataTable.Rows[k][row.ConditionSectionCd] = "×";//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                            this._resultDataTable.Rows[k][secMngSetWork.EnterpriseCode + secMngSetWork.SectionCode + secMngSetWork.SndRcvHisConsNo.ToString()] = "×";//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                        }
                        // ログ書き
                        //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                        //// ↓ 2009.06.17 劉洋 modify PVCS.160
                        //// operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "抽出エラー(拠点：" + row.ConditionSectionCd.Trim() + ")");
                        //operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + row.ConditionSectionCd.Trim() + ")", string.Empty);
                        //// ↑ 2009.06.17 劉洋 modify
                        //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                        //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                        operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);
                        //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                        _errorFlg = true;
                    }

                    i++;
                }

                // ステータス判断
                if (!_errorFlg)
                {
                    if (_dataFlg)
                    {
                        // ステータスを戻す
                        stauts = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // ログ書き
                        // ↓ 2009.06.17 liuyang modify PVCS.160
                        // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "抽出対象のデータが存在しません。");
                        operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
                        // ↑ 2009.06.17 liuyang modify
                        stauts = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    // ステータス
                    stauts = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return stauts;
        }

        #region DEL 2011/08/29  #24050
        ///// <summary>
        ///// 自動受信
        ///// </summary>
        ///// <returns>ステータス</returns>
        ///// <remarks>		
        ///// <br>Note		: 自動受信処理を行う。</br>
        ///// <br>Programmer	: 孫東響</br>	
        ///// <br>Date		: 2011.07.29</br>
        ///// </remarks>
        //public int AutoReceiveData(int connectPointDiv)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //    try
        //    {                
        //        StringBuilder errInfo = new StringBuilder();                
        //        ArrayList errMsgList;
        //        bool result = false;
        //        string errMsg = "";

        //        //初期化検索条件
        //        ReadInitData();

        //        // 受信対象を取得する
        //        status = this.GetSecMngSendData(LoginInfoAcquisition.EnterpriseCode);
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            return status;
        //        }

        //        result = CheckData(out errMsgList, ref errMsg);
        //        if (!result)
        //        {

        //            OperationLogSvrDB logSvr = new OperationLogSvrDB();
        //            DateTime now = DateTime.Now;
        //            string methodName = "AutoReceiveData()";
        //            string data = "";
        //            status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

        //            for (int i = 0; i < errMsgList.Count; i++)
        //            {
        //                //”締月次受信エラー”＋全角スペース＋戻りエラーリストの伝票＋全角スペース＋伝票番号＋全角スペース
        //                //＋日付＋全角スペース＋拠点コード＋全角スペース＋拠点名称＋全角スペース＋得意先/仕入先コード
        //                //＋全角スペース＋得意先/仕入先名称＋全角スペース＋エラー詳細内容
        //                PMKYO01901EA errInfoWork = (PMKYO01901EA)errMsgList[i];
        //                errInfo.Remove(0, errInfo.Length);
        //                errInfo.Append(ERRORMSG004);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.NoFlg);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.No);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.Date);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.SectionCode);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.SectionNm);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.CustomerCode);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.CustomerNm);
        //                errInfo.Append(ERRORMSGSPACE);
        //                errInfo.Append(errInfoWork.Error);

        //                logSvr.WriteOperationLogSvr(this, now, LogDataKind.ErrorLog, PROGRAMID, PROGRAMNAME, methodName, 12, status, errInfo.ToString(), data);
        //            }
        //        }
        //        else
        //        {
        //            status = SaveData(connectPointDiv);
        //        }
        //    }
        //    catch
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;                
        //    }
        //    return status;
        //}
        #endregion

        /// <summary>
        /// 更新結果を取得する
        /// </summary>
        /// <param name="fileId">ファイルID</param>
        /// <returns>件数</returns>
        private string GetCount(string fileId)
        {
            string count = string.Empty;

            switch (fileId)
            {
                // 売上データ
                case "SalesSlipRF":
                    count = IntConvert(salesSlipCount, true);
                    break;
                // 売上明細データ
                case "SalesDetailRF":
                    count = IntConvert(salesDetailCount, true);
                    break;
                // 売上履歴データ
                case "SalesHistoryRF":
                    count = IntConvert(salesHistoryCount, true);
                    break;
                // 売上履歴明細データ
                case "SalesHistDtlRF":
                    count = IntConvert(salesDtlHistCount, true);
                    break;
                // 入金データ
                case "DepsitMainRF":
                    count = IntConvert(depsitMainCount, true);
                    break;
                // 入金明細データ
                case "DepsitDtlRF":
                    count = IntConvert(depsitDtlCount, true);
                    break;
                // 仕入データ
                case "StockSlipRF":
                    count = IntConvert(stockSlipCount, true);
                    break;
                // 仕入明細データ
                case "StockDetailRF":
                    count = IntConvert(stockDetailCount, true);
                    break;
                // 仕入履歴データ
                case "StockSlipHistRF":
                    count = IntConvert(stockHistoryCount, true);
                    break;
                // 仕入履歴明細データ
                case "StockSlHistDtlRF":
                    count = IntConvert(stockDtlHistCount, true);
                    break;
                // 支払伝票マスタ
                case "PaymentSlpRF":
                    count = IntConvert(paymentSlpCount, true);
                    break;
                // 支払明細データ
                case "PaymentDtlRF":
                    count = IntConvert(paymentDtlCount, true);
                    break;
                // 受注マスタ
                case "AcceptOdrRF":
                    count = IntConvert(acceptOdrCount, true);
                    break;
                // 受注マスタ（車両）
                case "AcceptOdrCarRF":
                    count = IntConvert(acceptOdrCarCount, true);
                    break;
                //DEL 2011/08/29  #24050 --------------------------->>>>>
                //// 売上月次集計データ
                //case "MTtlSalesSlipRF":
                //    count = IntConvert(mTtlSalesSlipCount, true);
                //    break;
                //// 商品別売上月次集計データ
                //case "GoodsMTtlSaSlipRF":
                //    count = IntConvert(goodsSalesSlipCount, true);
                //    break;
                //// 仕入月次集計データ
                //case "MTtlStockSlipRF":
                //    count = IntConvert(mTtlStockSlipCount, true);
                //    break;
                //DEL 2011/08/29  #24050 ---------------------------<<<<<
                // 在庫調整データ
                case "StockAdjustRF":
                    count = IntConvert(stockAdjustCount, true);
                    break;
                // 在庫調整明細データ
                case "StockAdjustDtlRF":
                    count = IntConvert(stockAdjustDtlCount, true);
                    break;
                // 在庫移動データ
                case "StockMoveRF":
                    count = IntConvert(stockMoveCount, true);
                    break;
                //DEL 2011/08/29  #24050 --------------------------->>>>>
                //// 在庫受払履歴データ
                //case "StockAcPayHistRF":
                //    count = IntConvert(stockAcPayHistCount, true);
                //    break;
                //DEL 2011/08/29  #24050 ---------------------------<<<<<
                // 入金引当データ
                case "DepositAlwRF":
                    count = IntConvert(depositAlwCount, true);
                    break;
                // 受取手形データ
                case "RcvDraftDataRF":
                    count = IntConvert(rcvDraftDataCount, true);
                    break;
                // 支払手形データ
                case "PayDraftDataRF":
                    count = IntConvert(payDraftDataRF, true);
                    break;
                default :
                    break;
            }

            return count;
        }

        /// <summary>
        /// データ変換
        /// </summary>
        /// <param name="receiveList">抽出データ</param>
        /// <param name="outreceiveList">更新データ</param>
        /// <param name="parareceiveWork">条件クラス</param>
        /// <returns>更新時間</returns>
        // -- UPD 2011/02/01 ----------------------------------->>>
        //private long DivisionCustomSerializeArrayList(out object receiveList, object outreceiveList)
        private long DivisionCustomSerializeArrayList(out object receiveList, object outreceiveList, DCReceiveDataWork parareceiveWork)
        // -- UPD 2011/02/01 -----------------------------------<<<
        {
            // 更新時間
            long updateTime = 0;
            // 件数クリア
            this.salesSlipCount = 0;
            this.salesDetailCount = 0;
            this.salesHistoryCount = 0;
            this.salesDtlHistCount = 0;
            this.depsitMainCount = 0;
            this.depsitDtlCount = 0;
            this.stockSlipCount = 0;
            this.stockDetailCount = 0;
            this.stockHistoryCount = 0;
            this.stockDtlHistCount = 0;
            this.paymentSlpCount = 0;
            this.paymentDtlCount = 0;
            this.acceptOdrCount = 0;
            this.acceptOdrCarCount = 0;
            //DEL 2011/08/29  #24050------------>>>>>
            //this.mTtlSalesSlipCount = 0;
            //this.goodsSalesSlipCount = 0;
            //this.mTtlStockSlipCount = 0;
            //DEL 2011/08/29  #24050------------<<<<<
            // ↓ 2009.04.28 liuyang add
            this.stockAdjustCount = 0;
            this.stockAdjustDtlCount = 0;
            this.stockMoveCount = 0;
            //this.stockAcPayHistCount = 0;//DEL 2011/08/29  #24050
            // ↑ 2009.01.28 liuyang add
            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------------------------->>>>>
            this.depositAlwCount = 0;    //入金引当
            this.rcvDraftDataCount = 0;  //受取手形データ
            this.payDraftDataRF = 0;     //支払手形データ
            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------<<<<<

            ArrayList _salesSlipList = new ArrayList();                       // 売上データ
            ArrayList _salesDetailList = new ArrayList();                     // 売上明細データ
            ArrayList _salesHistoryList = new ArrayList();                    // 売上履歴データ
            ArrayList _salesHistDtlList = new ArrayList();                    // 売上履歴明細データ
            ArrayList _depsitMainList = new ArrayList();                      // 入金データ
            ArrayList _depsitDtlList = new ArrayList();                       // 入金明細データ
            ArrayList _stockSlipList = new ArrayList();                       // 仕入データ
            ArrayList _stockDetailList = new ArrayList();                     // 仕入明細データ
            ArrayList _stockSlipHistList = new ArrayList();                   // 仕入履歴データ
            ArrayList _stockSlHistDtlList = new ArrayList();                  // 仕入履歴明細データ
            ArrayList _paymentSlpList = new ArrayList();                      // 支払伝票マスタ
            ArrayList _paymentDtlList = new ArrayList();                      // 支払明細データ
            ArrayList _acceptOdrList = new ArrayList();                       // 受注マスタ
            ArrayList _acceptOdrCarList = new ArrayList();                    // 受注マスタ（車両）
            //DEL 2011/08/29  #24050 -------------------------------------------------------------->>>>>
            //ArrayList _mTtlSalesSlipList = new ArrayList();                   // 売上月次集計データ
            //ArrayList _goodsMTtlSaSlipList = new ArrayList();                 // 商品別売上月次集計データ
            //ArrayList _mTtlStockSlipList = new ArrayList();                   // 仕入月次集計データ
            //DEL 2011/08/29  #24050 --------------------------------------------------------------<<<<<
            // ↓ 2009.04.28 liuyang add
            ArrayList _stockAdjustList = new ArrayList();                     // 在庫調整データ
            ArrayList _stockAdjustDtlList = new ArrayList();                  // 在庫調整明細データ
            ArrayList _stockMoveList = new ArrayList();                       // 在庫移動データ
            //ArrayList _stockAcPayHistList = new ArrayList();                  // 在庫受払履歴データ//DEL 2011/08/29  #24050
            // ↑ 2009.04.28 liuyang add
            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------------------------->>>>>
            ArrayList _dcDepositAlwList = new ArrayList();                    // 入金引当データ
            ArrayList _dcRcvDraftDataList = new ArrayList();                  // 受取手形データ
            ArrayList _dcPayDraftDataList = new ArrayList();                  // 支払手形データ
            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------<<<<<

            CustomSerializeArrayList outreceiveDataList = (CustomSerializeArrayList)outreceiveList;
            CustomSerializeArrayList receiveDataList = new CustomSerializeArrayList();

            // 変更処理
            for (int i = 0; i < outreceiveDataList.Count; i++)
            {
                if (outreceiveDataList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)outreceiveDataList[i];

                    if (list.Count == 0) continue;

                    if (list[0] is DCSalesSlipWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCSalesSlipWork dcSalesSlipWork = (DCSalesSlipWork)list[j];
                            APSalesSlipWork salesSlipWork = ConvertReceive.SearchDataFromUpdateData(dcSalesSlipWork);
                            // 売上データ
                            _salesSlipList.Add(salesSlipWork);
                            // 更新時間
                            if (salesSlipWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = salesSlipWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_salesSlipList != null)
                        {
                            receiveDataList.Add(_salesSlipList);
                            // 変更結果
                            this.salesSlipCount = _salesSlipList.Count;
                        }
                    }
                    else if (list[0] is DCSalesDetailWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCSalesDetailWork dcSalesDetailWork = (DCSalesDetailWork)list[j];
                            // 売上明細データ
                            _salesDetailList.Add(ConvertReceive.SearchDataFromUpdateData(dcSalesDetailWork));

                            // 更新時間
                            // -- UPD 2011/02/01 ------------------------------------>>>
                            //if (dcSalesDetailWork.UpdateDateTime.Ticks > updateTime)
                            if ((dcSalesDetailWork.UpdateDateTime.Ticks > updateTime) && (dcSalesDetailWork.UpdateDateTime.Ticks > parareceiveWork.StartDateTime && dcSalesDetailWork.UpdateDateTime.Ticks <= parareceiveWork.EndDateTime))
                            // -- UPD 2011/02/01 ------------------------------------<<<
                            {
                                updateTime = dcSalesDetailWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_salesDetailList != null)
                        {
                            receiveDataList.Add(_salesDetailList);
                            // 変更結果
                            this.salesDetailCount = _salesDetailList.Count;
                        }
                    }
                    else if (list[0] is DCSalesHistoryWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCSalesHistoryWork dcSalesHistoryWork = (DCSalesHistoryWork)list[j];
                            // 売上履歴データ
                            _salesHistoryList.Add(ConvertReceive.SearchDataFromUpdateData(dcSalesHistoryWork));

                            // 更新時間
                            if (dcSalesHistoryWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcSalesHistoryWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_salesHistoryList != null)
                        {
                            receiveDataList.Add(_salesHistoryList);
                            // 変更結果
                            this.salesHistoryCount = _salesHistoryList.Count;
                        }
                    }
                    else if (list[0] is DCSalesHistDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCSalesHistDtlWork dcSalesHistDtlWork = (DCSalesHistDtlWork)list[j];
                            // 売上履歴明細データ
                            _salesHistDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcSalesHistDtlWork));

                            // 更新時間
                            if (dcSalesHistDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcSalesHistDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_salesHistDtlList != null)
                        {
                            receiveDataList.Add(_salesHistDtlList);
                            // 変更結果
                            this.salesDtlHistCount = _salesHistDtlList.Count;
                        }
                    }
                    else if (list[0] is DCDepsitMainWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCDepsitMainWork dcDepsitMainWork = (DCDepsitMainWork)list[j];
                            // 入金データ
                            _depsitMainList.Add(ConvertReceive.SearchDataFromUpdateData(dcDepsitMainWork));

                            // 更新時間
                            if (dcDepsitMainWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcDepsitMainWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_depsitMainList != null)
                        {
                            receiveDataList.Add(_depsitMainList);
                            // 変更結果
                            this.depsitMainCount = _depsitMainList.Count;
                        }
                    }
                    else if (list[0] is DCDepsitDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCDepsitDtlWork dcDepsitDtlWork = (DCDepsitDtlWork)list[j];
                            // 入金明細データ
                            _depsitDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcDepsitDtlWork));

                            // 更新時間
                            if (dcDepsitDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcDepsitDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_depsitDtlList != null)
                        {
                            receiveDataList.Add(_depsitDtlList);
                            // 変更結果
                            this.depsitDtlCount = _depsitDtlList.Count;
                        }
                    }
                    else if (list[0] is DCStockSlipWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockSlipWork dcStockSlipWork = (DCStockSlipWork)list[j];
                            // 仕入データ
                            _stockSlipList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockSlipWork));

                            // 更新時間
                            if (dcStockSlipWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockSlipWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_stockSlipList != null)
                        {
                            receiveDataList.Add(_stockSlipList);
                            // 変更結果
                            this.stockSlipCount = _stockSlipList.Count;
                        }
                    }
                    else if (list[0] is DCStockDetailWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockDetailWork dcStockDetailWork = (DCStockDetailWork)list[j];
                            // 仕入明細データ
                            _stockDetailList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockDetailWork));

                            // 更新時間
                            if (dcStockDetailWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockDetailWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_stockDetailList != null)
                        {
                            receiveDataList.Add(_stockDetailList);
                            // 変更結果
                            this.stockDetailCount = _stockDetailList.Count;
                        }
                    }
                    else if (list[0] is DCStockSlipHistWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockSlipHistWork dcStockSlipHistWork = (DCStockSlipHistWork)list[j];
                            // 仕入履歴データ
                            _stockSlipHistList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockSlipHistWork));

                            // 更新時間
                            if (dcStockSlipHistWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockSlipHistWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_stockSlipHistList != null)
                        {
                            receiveDataList.Add(_stockSlipHistList);
                            // 変更結果
                            this.stockHistoryCount = _stockSlipHistList.Count;
                        }
                    }
                    else if (list[0] is DCStockSlHistDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockSlHistDtlWork dcStockSlHistDtlWork = (DCStockSlHistDtlWork)list[j];
                            // 仕入履歴明細データ
                            _stockSlHistDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockSlHistDtlWork));

                            // 更新時間
                            if (dcStockSlHistDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockSlHistDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_stockSlHistDtlList != null)
                        {
                            receiveDataList.Add(_stockSlHistDtlList);
                            // 変更結果
                            this.stockDtlHistCount = _stockSlHistDtlList.Count;
                        }
                    }
                    else if (list[0] is DCPaymentSlpWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCPaymentSlpWork dcPaymentSlpWork = (DCPaymentSlpWork)list[j];
                            // 支払伝票マスタ
                            _paymentSlpList.Add(ConvertReceive.SearchDataFromUpdateData(dcPaymentSlpWork));

                            // 更新時間
                            if (dcPaymentSlpWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcPaymentSlpWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_paymentSlpList != null)
                        {
                            receiveDataList.Add(_paymentSlpList);
                            // 変更結果
                            this.paymentSlpCount = _paymentSlpList.Count;
                        }
                    }
                    else if (list[0] is DCPaymentDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCPaymentDtlWork dcPaymentDtlWork = (DCPaymentDtlWork)list[j];
                            // 支払明細データ
                            _paymentDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcPaymentDtlWork));

                            // 更新時間
                            if (dcPaymentDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcPaymentDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_paymentDtlList != null)
                        {
                            receiveDataList.Add(_paymentDtlList);
                            // 変更結果
                            this.paymentDtlCount = _paymentDtlList.Count;
                        }
                    }
                    else if (list[0] is DCAcceptOdrWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCAcceptOdrWork dcAcceptOdrWork = (DCAcceptOdrWork)list[j];
                            // 受注マスタ
                            _acceptOdrList.Add(ConvertReceive.SearchDataFromUpdateData(dcAcceptOdrWork));

                            // 更新時間
                            if (dcAcceptOdrWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcAcceptOdrWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_acceptOdrList != null)
                        {
                            receiveDataList.Add(_acceptOdrList);
                            // 変更結果
                            this.acceptOdrCount = _acceptOdrList.Count;
                        }
                    }
                    else if (list[0] is DCAcceptOdrCarWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCAcceptOdrCarWork dcAcceptOdrCarWork = (DCAcceptOdrCarWork)list[j];
                            // 受注マスタ（車両）
                            _acceptOdrCarList.Add(ConvertReceive.SearchDataFromUpdateData(dcAcceptOdrCarWork));

                            // 更新時間
                            if (dcAcceptOdrCarWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcAcceptOdrCarWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_acceptOdrCarList != null)
                        {
                            receiveDataList.Add(_acceptOdrCarList);
                            // 変更結果
                            this.acceptOdrCarCount = _acceptOdrCarList.Count;
                        }
                    }
                    #region DEL 2011/08/29  #24050
                    //DEL 2011/08/29  #24050----------------------------------------------------------------->>>>>
                    //else if (list[0] is DCMTtlSalesSlipWork)
                    //{
                    //    for (int j = 0; j < list.Count; j++)
                    //    {
                    //        DCMTtlSalesSlipWork dcMTtlSalesSlipWork = (DCMTtlSalesSlipWork)list[j];
                    //        // 売上月次別伝票データ
                    //        _mTtlSalesSlipList.Add(ConvertReceive.SearchDataFromUpdateData(dcMTtlSalesSlipWork));

                    //        // 更新時間
                    //        if (dcMTtlSalesSlipWork.UpdateDateTime.Ticks > updateTime)
                    //        {
                    //            updateTime = dcMTtlSalesSlipWork.UpdateDateTime.Ticks;
                    //        }
                    //    }

                    //    // 情報を追加
                    //    if (_mTtlSalesSlipList != null)
                    //    {
                    //        receiveDataList.Add(_mTtlSalesSlipList);
                    //        // 変更結果
                    //        this.mTtlSalesSlipCount = _mTtlSalesSlipList.Count;
                    //    }
                    //}
                    //else if (list[0] is DCGoodsMTtlSaSlipWork)
                    //{
                    //    for (int j = 0; j < list.Count; j++)
                    //    {
                    //        DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork = (DCGoodsMTtlSaSlipWork)list[j];
                    //        // 商品月次別伝票データ
                    //        _goodsMTtlSaSlipList.Add(ConvertReceive.SearchDataFromUpdateData(dcGoodsMTtlSaSlipWork));

                    //        // 更新時間
                    //        if (dcGoodsMTtlSaSlipWork.UpdateDateTime.Ticks > updateTime)
                    //        {
                    //            updateTime = dcGoodsMTtlSaSlipWork.UpdateDateTime.Ticks;
                    //        }
                    //    }

                    //    // 情報を追加
                    //    if (_goodsMTtlSaSlipList != null)
                    //    {
                    //        receiveDataList.Add(_goodsMTtlSaSlipList);
                    //        // 変更結果
                    //        this.goodsSalesSlipCount = _goodsMTtlSaSlipList.Count;
                    //    }
                    //}
                    //else if (list[0] is DCMTtlStockSlipWork)
                    //{
                    //    for (int j = 0; j < list.Count; j++)
                    //    {
                    //        DCMTtlStockSlipWork dcMTtlStockSlipWork = (DCMTtlStockSlipWork)list[j];
                    //        // 仕入月次別伝票データ
                    //        _mTtlStockSlipList.Add(ConvertReceive.SearchDataFromUpdateData(dcMTtlStockSlipWork));

                    //        // 更新時間
                    //        if (dcMTtlStockSlipWork.UpdateDateTime.Ticks > updateTime)
                    //        {
                    //            updateTime = dcMTtlStockSlipWork.UpdateDateTime.Ticks;
                    //        }
                    //    }

                    //    // 情報を追加
                    //    if (_mTtlStockSlipList != null)
                    //    {
                    //        receiveDataList.Add(_mTtlStockSlipList);
                    //        // 変更結果
                    //        this.mTtlStockSlipCount = _mTtlStockSlipList.Count;
                    //    }
                    //}
                    //DEL 2011/08/29  #24050-----------------------------------------------------------------<<<<<
                    #endregion
                    // ↓ 2009.04.28 liuyang add
                    else if (list[0] is DCStockAdjustWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockAdjustWork dcStockAdjustWork = (DCStockAdjustWork)list[j];
                            // 在庫調整データ
                            _stockAdjustList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockAdjustWork));

                            // 更新時間
                            if (dcStockAdjustWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockAdjustWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_stockAdjustList != null)
                        {
                            receiveDataList.Add(_stockAdjustList);
                            // 変更結果
                            this.stockAdjustCount = _stockAdjustList.Count;
                        }
                    }
                    else if (list[0] is DCStockAdjustDtlWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockAdjustDtlWork dcStockAdjustDtlWork = (DCStockAdjustDtlWork)list[j];
                            // 在庫調整明細データ
                            _stockAdjustDtlList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockAdjustDtlWork));

                            // 更新時間
                            if (dcStockAdjustDtlWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockAdjustDtlWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_stockAdjustDtlList != null)
                        {
                            receiveDataList.Add(_stockAdjustDtlList);
                            // 変更結果
                            this.stockAdjustDtlCount = _stockAdjustDtlList.Count;
                        }
                    }
                    else if (list[0] is DCStockMoveWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCStockMoveWork dcStockMoveWork = (DCStockMoveWork)list[j];
                            // 在庫移動データ
                            _stockMoveList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockMoveWork));

                            // 更新時間
                            if (dcStockMoveWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcStockMoveWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_stockMoveList != null)
                        {
                            receiveDataList.Add(_stockMoveList);
                            // 変更結果
                            this.stockMoveCount = _stockMoveList.Count;
                        }
                    }
                    #region DEL 2011/08/29  #24050
                    //DEL 2011/08/29  #24050----------------------------------------------------------------->>>>>
                    //else if (list[0] is DCStockAcPayHistWork)
                    //{
                    //    for (int j = 0; j < list.Count; j++)
                    //    {
                    //        DCStockAcPayHistWork dcStockAcPayHistWork = (DCStockAcPayHistWork)list[j];
                    //        // 仕入月次別伝票データ
                    //        _stockAcPayHistList.Add(ConvertReceive.SearchDataFromUpdateData(dcStockAcPayHistWork));

                    //        // 更新時間
                    //        if (dcStockAcPayHistWork.UpdateDateTime.Ticks > updateTime)
                    //        {
                    //            updateTime = dcStockAcPayHistWork.UpdateDateTime.Ticks;
                    //        }
                    //    }

                    //    // 情報を追加
                    //    if (_stockAcPayHistList != null)
                    //    {
                    //        receiveDataList.Add(_stockAcPayHistList);
                    //        // 変更結果
                    //        this.stockAcPayHistCount = _stockAcPayHistList.Count;
                    //    }
                    //}
                    //DEL 2011/08/29  #24050-----------------------------------------------------------------<<<<<
                    #endregion
                    // ↑ 2009.04.28 liuyang add
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------->>>>>
                    else if (list[0] is DCDepositAlwWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCDepositAlwWork dcDepositAlwWork = (DCDepositAlwWork)list[j];
                            // 入金引当データ
                            _dcDepositAlwList.Add(ConvertReceive.SearchDataFromUpdateData(dcDepositAlwWork));

                            // 更新時間
                            if (dcDepositAlwWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcDepositAlwWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_dcDepositAlwList != null)
                        {
                            receiveDataList.Add(_dcDepositAlwList);
                            // 変更結果
                            this.depositAlwCount = _dcDepositAlwList.Count;
                        }
                    }
                    else if (list[0] is DCRcvDraftDataWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCRcvDraftDataWork dcRcvDraftDataWork = (DCRcvDraftDataWork)list[j];
                            // 受取手形データ
                            _dcRcvDraftDataList.Add(ConvertReceive.SearchDataFromUpdateData(dcRcvDraftDataWork));

                            // 更新時間
                            if (dcRcvDraftDataWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcRcvDraftDataWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_dcRcvDraftDataList != null)
                        {
                            receiveDataList.Add(_dcRcvDraftDataList);
                            // 変更結果
                            this.rcvDraftDataCount = _dcRcvDraftDataList.Count;
                        }
                    }
                    else if (list[0] is DCPayDraftDataWork)
                    {
                        for (int j = 0; j < list.Count; j++)
                        {
                            DCPayDraftDataWork dcPayDraftDataWork = (DCPayDraftDataWork)list[j];
                            // 支払手形データ
                            _dcPayDraftDataList.Add(ConvertReceive.SearchDataFromUpdateData(dcPayDraftDataWork));

                            // 更新時間
                            if (dcPayDraftDataWork.UpdateDateTime.Ticks > updateTime)
                            {
                                updateTime = dcPayDraftDataWork.UpdateDateTime.Ticks;
                            }
                        }

                        // 情報を追加
                        if (_dcPayDraftDataList != null)
                        {
                            receiveDataList.Add(_dcPayDraftDataList);
                            // 変更結果
                            this.payDraftDataRF = _dcPayDraftDataList.Count;
                        }
                    }
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------<<<<<
                }
            }

            receiveList = (object)receiveDataList;

            return updateTime;
        }

        /// <summary>
        /// 検索件数フォーマット設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 検索件数フォーマット設定処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount, bool spaceFlg)
        {
            String searchCountStr = Convert.ToString(searchCount);
            Int32 searchCountLen = searchCountStr.Length;
            if (searchCountLen <= 3)
            {
                if (spaceFlg)
                {
                    searchCountStr = searchCountStr + " 件";
                }
                else
                {
                    searchCountStr = searchCountStr + "件";
                }
            }
            else if (3 < searchCountLen && searchCountLen <= 6)
            {
                if (spaceFlg)
                {
                    searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + " 件";
                }
                else
                {
                    searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + "件";
                }
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                if (spaceFlg)
                {
                    searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                        + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                        + searchCountStr.Substring(searchCountLen - 3) + " 件";
                }
                else
                {
                    searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                        + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                        + searchCountStr.Substring(searchCountLen - 3) + "件";
                }
            }
            return searchCountStr;
        }
        
        #endregion

        // ===================================================================================== //
        // DBデータアクセス処理
        // ===================================================================================== //
        # region ■DataBase Access Methods
        /// <summary>
        /// 自起動処理
        /// </summary>
        /// <param name="secMngSetList">拠点リスト</param>
        /// <param name="connectPointDiv">接続先</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        public int MergeOfferToUserUpdate(ArrayList secMngSetList, int connectPointDiv, string enterpriseCode)
        {
            int stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
            //OperationHistoryLog operationHistoryLog = new OperationHistoryLog();//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();//ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません

            try
            {
                //初期化検索条件
                ReadInitData();

                // 受信対象を取得する
                stauts = this.GetSecMngSendData(enterpriseCode);
                if (stauts != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return stauts;
                }

                // ファイルID配列
                string[] fileIds = new string[this._sendDataList.Count];
                for (int j = 0; j < this._sendDataList.Count; j++)
                {
                    SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[j];
                    fileIds[j] = secMngSndRcv.FileId;
                }
                //ADD 2011/07/29 SCM対応 拠点管理(10704767-00)-------------------------->>>>>
                ArrayList errMsgList;
                string errMsg = "";
                StringBuilder errInfo = new StringBuilder();
                bool result = CheckData(out errMsgList, ref errMsg);
                if (!result)
                {
                    DateTime now = DateTime.Now;
                    string methodName = "MergeOfferToUserUpdate()";
                    string data = "";
                    stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                    for (int i = 0; i < errMsgList.Count; i++)
                    {
                        //”締月次受信エラー”＋全角スペース＋戻りエラーリストの伝票＋全角スペース＋伝票番号＋全角スペース
                        //＋日付＋全角スペース＋拠点コード＋全角スペース＋拠点名称＋全角スペース＋得意先/仕入先コード
                        //＋全角スペース＋得意先/仕入先名称＋全角スペース＋エラー詳細内容
                        PMKYO01901EA errInfoWork = (PMKYO01901EA)errMsgList[i];
                        errInfo.Remove(0, errInfo.Length);
                        errInfo.Append(ERRORMSG004);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.NoFlg);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.No);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.Date);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.SectionCode);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.SectionNm);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.CustomerCode);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.CustomerNm);
                        errInfo.Append(ERRORMSGSPACE);
                        errInfo.Append(errInfoWork.Error);
                        //operationHistoryLog.WriteOperationLog(this, LogDataKind.ErrorLog, PROGRAMID, PROGRAMNAME, methodName, 12, stauts, errInfo.ToString(), data);//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                        operationLogSvrDB.WriteOperationLogSvr(this, DateTime.Now, LogDataKind.ErrorLog, PROGRAMID, PROGRAMNAME, methodName, 12, stauts, errInfo.ToString(), data);//ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                    }
                    return stauts;
                }
                //ADD 2011/07/29 SCM対応 拠点管理(10704767-00)--------------------------<<<<<

                // 保存処理
                if (this._extraAddUpdControlDB == null)
                {
                    this._extraAddUpdControlDB = (IAPSendMessageDB)APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
                }

                if (connectPointDiv == 0)
                {
                    // セーターコントロール
                    if (this._dCControlDB == null)
                    {
                        this._dCControlDB = (IDCControlDB)MediationDCControlDB.GetDCControlDB();
                    }
                }
                else
                {
                    // 集計機
                    if (this._skControlDB == null)
                    {
                        this._skControlDB = (ISKControlDB)MediationSKControlDB.GetSKControlDB();
                    }
                }

                // 抽出結果なし
                bool _dataFlg = false;
                bool _errorFlg = false;

                // 拠点更新
                //foreach (APSecMngSetWork secMngSetWork in secMngSetList)//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                foreach (SndRcvHisWork secMngSetWork in _secMngSetWorkList)//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                {
                    // 拠点リスト
                    ArrayList sectionCodeList = new ArrayList();
                    //foreach (APSecMngSetWork secMngSetWorkCopy in secMngSetList)//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                    foreach (SndRcvHisWork secMngSetWorkCopy in _secMngSetWorkList)//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                    {
                        sectionCodeList.Add(secMngSetWorkCopy.SectionCode);
                    }

                    object outreceiveList = null;
                    DCReceiveDataWork parareceiveWork = new DCReceiveDataWork();

                    // 企業コード
                    //parareceiveWork.PmEnterpriseCode = secMngSetWork.PmEnterpriseCode;//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                    parareceiveWork.PmEnterpriseCode = secMngSetWork.EnterpriseCode;//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                    // 開始時間
                    //parareceiveWork.StartDateTime = secMngSetWork.SyncExecDate.Ticks;//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                    parareceiveWork.StartDateTime = secMngSetWork.SndObjStartDate.Ticks;//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                    // 終了時間
                    //parareceiveWork.EndDateTime = DateTime.Now.Ticks;//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                    parareceiveWork.EndDateTime = secMngSetWork.SndObjEndDate.Ticks;//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------->>>>>
                    parareceiveWork.PmSectionCode = secMngSetWork.ExtraObjSecCode;

                    parareceiveWork.DoSalesSlipFlg = _doSalesSlipFlg;          //売上要否フラグ
                    parareceiveWork.DoSalesDetailFlg = _doSalesDetailFlg;      //売上明細要否フラグ
                    parareceiveWork.DoAcceptOdrCarFlg = _doAcceptOdrCarFlg;    //受注マスタ（車両）要否フラグ
                    parareceiveWork.DoAcceptOdrFlg = _doAcceptOdrFlg;          //受注マスタ要否フラグ
                    parareceiveWork.DoSalesHistoryFlg = _doSalesHistoryFlg;    //売上履歴要否フラグ
                    parareceiveWork.DoSalesHistDtlFlg = _doSalesHistDtlFlg;    //売上履歴明細要否フラグ
                    parareceiveWork.DoDepsitMainFlg = _doDepsitMainFlg;        //入金要否フラグ
                    parareceiveWork.DoDepsitDtlFlg = _doDepsitDtlFlg;          //入金明細要否フラグ
                    parareceiveWork.DoStockSlipFlg = _doStockSlipFlg;          //仕入要否フラグ
                    parareceiveWork.DoStockDetailFlg = _doStockDetailFlg;      //仕入明細要否フラグ
                    parareceiveWork.DoStockSlipHistFlg = _doStockSlipHistFlg;  //仕入履歴要否フラグ
                    parareceiveWork.DoStockSlHistDtlFlg = _doStockSlHistDtlFlg;//仕入履歴明細要否フラグ
                    parareceiveWork.DoPaymentSlpFlg = _doPaymentSlpFlg;        //支払伝票要否フラグ
                    parareceiveWork.DoPaymentDtlFlg = _doPaymentDtlFlg;        //支払明細要否フラグ
                    //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------<<<<<

                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                    // 受信区分取得
                    for (int i = 0; i < _sendDataList.Count; i++)
                    {
                        SecMngSndRcv secMngSndRcv = (SecMngSndRcv)_sendDataList[i];
                        if (secMngSndRcv.FileId.Equals("SalesSlipRF"))
                        {
                            //受注データ受信区分
                            parareceiveWork.AcptAnOdrRecvDiv = secMngSndRcv.AcptAnOdrRecvDiv;
                            //貸出データ受信区分
                            parareceiveWork.ShipmentRecvDiv = secMngSndRcv.ShipmentRecvDiv;
                            //見積データ受信区分
                            parareceiveWork.EstimateRecvDiv = secMngSndRcv.EstimateRecvDiv;
                        }
                    }
                    // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
                    if (connectPointDiv == 0)
                    {
                        //stauts = this._dCControlDB.Search(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                        stauts = this._dCControlDB.SearchSCM(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                    }
                    else
                    {
                        stauts = this._skControlDB.Search(out outreceiveList, parareceiveWork, secMngSetWork.SectionCode, fileIds);
                    }

                    // 抽出結果
                    if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // データ変換
                        object receiveList = null;
                        // -- UPD 2011/02/01 -------------------------------->>>
                        //long updateTime = this.DivisionCustomSerializeArrayList(out receiveList, outreceiveList);
                        long updateTime = this.DivisionCustomSerializeArrayList(out receiveList, outreceiveList, parareceiveWork);
                        // -- UPD 2011/02/01 --------------------------------<<<

                        _dataFlg = true;

                        // 変更処理
                        stauts = this._extraAddUpdControlDB.UpdateCustomSerializeArrayList(
                            LoginInfoAcquisition.EnterpriseCode, receiveList, sectionCodeList, ref stockAcPayHistCount);

                        // 正常の場合、シック時間を更新する
                        if (stauts == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            #region DEL
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ------------------------->>>>>
                            //if (secMngSetWork.SyncExecDate.Ticks < updateTime)
                            //{
                            //    secMngSetWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                            //    secMngSetWork.UpdateDateTime = DateTime.Now;
                            //    secMngSetWork.Kind = 0;
                            //    secMngSetWork.ReceiveCondition = 1;
                            //    secMngSetWork.UpdEmployeeCode = secMngSetWork.UpdEmployeeCode;
                            //    // 更新処理
                            //    this._extraAddUpdControlDB.UpdateSecMngSetData(secMngSetWork, updateTime);
                            //}
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) -------------------------<<<<<
                            #endregion

                            string logStr = string.Empty;

                            for (int m = 0; m < this._sendDataList.Count; m++)
                            {
                                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)this._sendDataList[m];
                                if (logStr == string.Empty)
                                {
                                    logStr += secMngSndRcv.FileNm + " ";
                                }
                                else
                                {
                                    logStr += "、" + secMngSndRcv.FileNm + " ";
                                }
                                switch (secMngSndRcv.FileId)
                                {
                                    // 売上データ
                                    case "SalesSlipRF":
                                        logStr += IntConvert(salesSlipCount, false);
                                        break;
                                    // 売上明細データ
                                    case "SalesDetailRF":
                                        logStr += IntConvert(salesDetailCount, false);
                                        break;
                                    // 売上履歴データ
                                    case "SalesHistoryRF":
                                        logStr += IntConvert(salesHistoryCount, false);
                                        break;
                                    // 売上履歴明細データ
                                    case "SalesHistDtlRF":
                                        logStr += IntConvert(salesDtlHistCount, false);
                                        break;
                                    // 入金データ
                                    case "DepsitMainRF":
                                        logStr += IntConvert(depsitMainCount, false);
                                        break;
                                    // 入金明細データ
                                    case "DepsitDtlRF":
                                        logStr += IntConvert(depsitDtlCount, false);
                                        break;
                                    // 仕入データ
                                    case "StockSlipRF":
                                        logStr += IntConvert(stockSlipCount, false);
                                        break;
                                    // 仕入明細データ
                                    case "StockDetailRF":
                                        logStr += IntConvert(stockDetailCount, false);
                                        break;
                                    // 仕入履歴データ
                                    case "StockSlipHistRF":
                                        logStr += IntConvert(stockHistoryCount, false);
                                        break;
                                    // 仕入履歴明細データ
                                    case "StockSlHistDtlRF":
                                        logStr += IntConvert(stockDtlHistCount, false);
                                        break;
                                    // 支払伝票マスタ
                                    case "PaymentSlpRF":
                                        logStr += IntConvert(paymentSlpCount, false);
                                        break;
                                    // 支払明細データ
                                    case "PaymentDtlRF":
                                        logStr += IntConvert(paymentDtlCount, false);
                                        break;
                                    // 受注マスタ
                                    case "AcceptOdrRF":
                                        logStr += IntConvert(acceptOdrCount, false);
                                        break;
                                    // 受注マスタ（車両）
                                    case "AcceptOdrCarRF":
                                        logStr += IntConvert(acceptOdrCarCount, false);
                                        break;                                        
                                    //DEL 2011/08/29  #24050----------------------------------------------------------------->>>>>
                                    //// 売上月次集計データ
                                    //case "MTtlSalesSlipRF":
                                    //    logStr += IntConvert(mTtlSalesSlipCount, false);
                                    //    break;
                                    //// 商品別売上月次集計データ
                                    //case "GoodsMTtlSaSlipRF":
                                    //    logStr += IntConvert(goodsSalesSlipCount, false);
                                    //    break;
                                    //// 仕入月次集計データ
                                    //case "MTtlStockSlipRF":
                                    //    logStr += IntConvert(mTtlStockSlipCount, false);
                                    //    break;
                                    //DEL 2011/08/29  #24050-----------------------------------------------------------------<<<<<
                                    // 在庫調整データ
                                    case "StockAdjustRF":
                                        logStr += IntConvert(stockAdjustCount, false);
                                        break;
                                    // 在庫調整明細データ
                                    case "StockAdjustDtlRF":
                                        logStr += IntConvert(stockAdjustDtlCount, false);
                                        break;
                                    // 在庫移動データ
                                    case "StockMoveRF":
                                        logStr += IntConvert(stockMoveCount, false);
                                        break;
                                    //DEL 2011/08/29  #24050----------------------------------------------------------------->>>>>
                                    //// 在庫受払履歴データ
                                    //case "StockAcPayHistRF":
                                    //    logStr += IntConvert(stockAcPayHistCount, false);
                                    //    break;
                                    //DEL 2011/08/29  #24050-----------------------------------------------------------------<<<<<
                                    // 入金引当データ
                                    case "DepositAlwRF":
                                        logStr += IntConvert(depositAlwCount, false);
                                        break;
                                    // 受取手形データ
                                    case "RcvDraftDataRF":
                                        logStr += IntConvert(rcvDraftDataCount, false);
                                        break;
                                    // 支払手形データ
                                    case "PayDraftDataRF":
                                        logStr += IntConvert(payDraftDataRF, false);
                                        break;
                                }
                            }

                            // ログ書き
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                            //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                            //    logStr, "正常(拠点：" + secMngSetWork.SectionCode.Trim() + ")");
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                            //DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません--------------------------------------------------->>>>>
                            //operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                            //    logStr, "正常(拠点：" + secMngSetWork.SectionCode.Trim() + ")");
                            //DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません---------------------------------------------------<<<<<
                            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません--------------------------------------------------->>>>>
                            operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                                logStr, "正常(拠点：" + secMngSetWork.SectionCode.Trim() + ")");
                            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません---------------------------------------------------<<<<<
                            if (this._extraRcvHisDB == null)
                            {
                                this._extraRcvHisDB = (ISndRcvHisDB)MediationSndRcvHisRFDB.GetSndRcvHisRFDB();
                            }

                            ArrayList logObj = new ArrayList();
                            secMngSetWork.SendOrReceiveDivCd = 1;
                            logObj.Add(secMngSetWork);

                            // 送信履歴ログデータの更新
                            stauts = this._extraRcvHisDB.WriteRcvHisWork(ref logObj);
                            //ADD 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                        }
                        else if (stauts == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            _errorFlg = true;
                            // ログ書き
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                            //// ↓ 2009.06.17 liuyang modify PVCS.160
                            //// operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")");
                            //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);
                            //// ↑ 2009.06.17 liuyang modify
                            //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                            //operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                            operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);//ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                        }
                    }
                    else if (stauts == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                    }
                    else if (stauts == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        _errorFlg = true;
                        // ログ書き
                        //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                        //// ↓ 2009.06.17 liuyang modify PVCS.160
                        //// operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "抽出エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")");
                        //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);
                        //// ↑ 2009.06.17 liuyang modify
                        //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                        //operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                        operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + secMngSetWork.SectionCode.Trim() + ")", string.Empty);//ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                    }
                }

                // ステータス判断
                if (!_errorFlg)
                {
                    if (_dataFlg)
                    {
                        // ステータスを戻す
                        stauts = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // ログ書き
                        //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) --------------------------------------------------------------------->>>>>
                        //// ↓ 2009.06.17 liuyang modify PVCS.160
                        //// operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "抽出対象のデータが存在しません。");
                        //operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
                        //// ↑ 2009.06.17 liuyang modify
                        //DEL 2011/07/29 SCM対応 拠点管理(10704767-00) ---------------------------------------------------------------------<<<<<
                        //operationHistoryLog.WriteOperationLog(this, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                        operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);//ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
                        stauts = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    // ステータス
                    stauts = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                stauts = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return stauts;
        }
        #endregion

        // ↓ 2009.04.30 liuyang add
        #region ■ 接続先チェック処理 ■
        /// <summary>
        /// 接続先チェック処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="regeditFlg">フラグ</param>
        /// </summary>
        /// <returns>チェック処理結果</returns>
        public bool CheckConnect(string enterpriseCode, out int connectPointDiv, out string errMsg, int regeditFlg)
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
                    if (regeditFlg == 1)
                    {
                        retResult = true;
                    }
                    else
                    {
                        retResult = CheckRegistryKey(secMngConnectSt);
                        if (retResult == false)
                        {
                            errMsg = "接続先の設定が不正です。";
                        }
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

        /// <summary>レジストリからチェック処理
        /// <param name="secMngConnectSt">拠点管理接続先設定マスタオブジェクト</param>
        /// </summary>
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
        // ↑ 2009.04.30 liuyang add

        // ↓ 2009.05.25 liuyang add
        #region ■ 送信対象データの取得処理 ■
        /// <summary>
        /// 送信対象データの取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信対象データの取得処理を行う。</br>      
        /// <br>Programmer : 劉洋</br>                                  
        /// <br>Date       : 2009.05.25</br> 
        /// </remarks>
        /// <returns>チェック処理結果</returns>
        public int GetSecMngSendData(string enterpriseCode)
        {
            _sendDataList = new ArrayList();
            List<SecMngSndRcv> sendList = new List<SecMngSndRcv>();
            List<SecMngSndRcvDtl> sendDtlList = new List<SecMngSndRcvDtl>();
            // 全件検索
            int status = this._sendSetAcs.SearchAll(out sendList, out sendDtlList, enterpriseCode);

            // 送信データの取得
            foreach (SecMngSndRcv secMngSndRcv in sendList)
            {
                //if (secMngSndRcv.DisplayOrder <= 99 && secMngSndRcv.SecMngRecvDiv == 1)//DEL 2011/07/29 SCM対応 拠点管理(10704767-00)
                if (secMngSndRcv.DisplayOrder <= 99 && secMngSndRcv.SecMngRecvDiv >= 1)//ADD 2011/07/29 SCM対応 拠点管理(10704767-00)
                {
                    _sendDataList.Add(secMngSndRcv);
                }
            }

            // 画面表示設定
            this.updateData = new string[_sendDataList.Count];
            int i = 0;
            foreach (SecMngSndRcv secMngSndRcv in _sendDataList)
            {
                this.updateData[i] = secMngSndRcv.MasterName;
                i++;
            }

            return status;
        }
        #endregion
        // ↑ 2009.05.25 liuyang add

        // -- ADD 2011/11/29 --- >>>
        private void ConvertreceiveList(ArrayList errMsgList, ref object outreceiveList)
        {
            CustomSerializeArrayList outreceiveDataList = (CustomSerializeArrayList)outreceiveList;
            CustomSerializeArrayList outreceiveDataTempList = new CustomSerializeArrayList();
            bool addFlg = true;

            for (int i = 0; i < outreceiveDataList.Count; i++)
            {
                addFlg = true;

                if (outreceiveDataList[i] is ArrayList)
                {
                    ArrayList list = (ArrayList)outreceiveDataList[i];

                    if (list.Count == 0) continue;

                    ArrayList listTemp;

                    // 売上データ
                    if (list[0] is DCSalesSlipWork)
                    {
                        listTemp = new ArrayList();
                        
                        DCSalesSlipWork dcSalesSlipWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcSalesSlipWork = (DCSalesSlipWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("売上".Equals(errInfo.NoFlg))
                                {
                                    if (dcSalesSlipWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcSalesSlipWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 売上明細データ
                    else if (list[0] is DCSalesDetailWork)
                    {
                        listTemp = new ArrayList();

                        DCSalesDetailWork dcSalesDetailWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcSalesDetailWork = (DCSalesDetailWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("売上".Equals(errInfo.NoFlg))
                                {
                                    if (dcSalesDetailWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcSalesDetailWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 売上履歴データ
                    else if (list[0] is DCSalesHistoryWork)
                    {
                        listTemp = new ArrayList();

                        DCSalesHistoryWork dcSalesHistoryWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcSalesHistoryWork = (DCSalesHistoryWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("売上".Equals(errInfo.NoFlg))
                                {
                                    if (dcSalesHistoryWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcSalesHistoryWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 売上履歴明細データ
                    else if (list[0] is DCSalesHistDtlWork)
                    {
                        listTemp = new ArrayList();

                        DCSalesHistDtlWork dcSalesHistDtlWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcSalesHistDtlWork = (DCSalesHistDtlWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("売上".Equals(errInfo.NoFlg))
                                {
                                    if (dcSalesHistDtlWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcSalesHistDtlWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 受注マスタ
                    else if (list[0] is DCAcceptOdrWork)
                    {
                        listTemp = new ArrayList();

                        DCAcceptOdrWork dcAcceptOdrWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcAcceptOdrWork = (DCAcceptOdrWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("売上".Equals(errInfo.NoFlg))
                                {
                                    if (dcAcceptOdrWork.SalesSlipNum.Equals(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcAcceptOdrWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 受注マスタ（車両）
                    else if (list[0] is DCAcceptOdrCarWork)
                    {
                        listTemp = new ArrayList();

                        DCAcceptOdrCarWork dcAcceptOdrCarWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcAcceptOdrCarWork = (DCAcceptOdrCarWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("売上".Equals(errInfo.NoFlg))
                                {
                                    if (dcAcceptOdrCarWork.AcceptAnOrderNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcAcceptOdrCarWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 入金マスタ
                    else if (list[0] is DCDepsitMainWork)
                    {
                        listTemp = new ArrayList();

                        DCDepsitMainWork dcDepsitMainWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcDepsitMainWork = (DCDepsitMainWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("入金".Equals(errInfo.NoFlg))
                                {
                                    if (dcDepsitMainWork.DepositSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcDepsitMainWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 入金明細データ
                    else if (list[0] is DCDepsitDtlWork)
                    {
                        listTemp = new ArrayList();

                        DCDepsitDtlWork dcDepsitDtlWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcDepsitDtlWork = (DCDepsitDtlWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("入金".Equals(errInfo.NoFlg))
                                {
                                    if (dcDepsitDtlWork.DepositSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcDepsitDtlWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 仕入データ
                    else if (list[0] is DCStockSlipWork)
                    {
                        listTemp = new ArrayList();

                        DCStockSlipWork dcStockSlipWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcStockSlipWork = (DCStockSlipWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("仕入".Equals(errInfo.NoFlg))
                                {
                                    if (dcStockSlipWork.SupplierSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcStockSlipWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 仕入明細データ
                    else if (list[0] is DCStockDetailWork)
                    {
                        listTemp = new ArrayList();

                        DCStockDetailWork dcStockDetailWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcStockDetailWork = (DCStockDetailWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("仕入".Equals(errInfo.NoFlg))
                                {
                                    if (dcStockDetailWork.SupplierSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcStockDetailWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 仕入履歴データ
                    else if (list[0] is DCStockSlipHistWork)
                    {
                        listTemp = new ArrayList();

                        DCStockSlipHistWork dcStockSlipHistWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcStockSlipHistWork = (DCStockSlipHistWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("仕入".Equals(errInfo.NoFlg))
                                {
                                    if (dcStockSlipHistWork.SupplierSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcStockSlipHistWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 仕入履歴明細データ
                    else if (list[0] is DCStockSlHistDtlWork)
                    {
                        listTemp = new ArrayList();

                        DCStockSlHistDtlWork dcStockSlHistDtlWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcStockSlHistDtlWork = (DCStockSlHistDtlWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("仕入".Equals(errInfo.NoFlg))
                                {
                                    if (dcStockSlHistDtlWork.SupplierSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcStockSlHistDtlWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 支払伝票マスタ
                    else if (list[0] is DCPaymentSlpWork)
                    {
                        listTemp = new ArrayList();

                        DCPaymentSlpWork dcPaymentSlpWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcPaymentSlpWork = (DCPaymentSlpWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("支払".Equals(errInfo.NoFlg))
                                {
                                    if (dcPaymentSlpWork.PaymentSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcPaymentSlpWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    // 支払明細データ
                    else if (list[0] is DCPaymentDtlWork)
                    {
                        listTemp = new ArrayList();

                        DCPaymentDtlWork dcPaymentDtlWork;

                        for (int j = 0; j < list.Count; j++)
                        {
                            dcPaymentDtlWork = (DCPaymentDtlWork)list[j];
                            addFlg = true;
                            foreach (PMKYO01901EA errInfo in errMsgList)
                            {
                                if ("支払".Equals(errInfo.NoFlg))
                                {
                                    if (dcPaymentDtlWork.PaymentSlipNo == int.Parse(errInfo.No))
                                    {
                                        addFlg = false;
                                        break;
                                    }
                                }
                            }

                            if (addFlg)
                            {
                                listTemp.Add(dcPaymentDtlWork);
                            }
                        }
                        outreceiveDataTempList.Add(listTemp);
                    }
                    else
                    {
                        outreceiveDataTempList.Add(list);
                    }
                }
            }

            outreceiveList = (object)outreceiveDataTempList;
        }
        // -- ADD 2011/11/29 --- <<<
    }
}
