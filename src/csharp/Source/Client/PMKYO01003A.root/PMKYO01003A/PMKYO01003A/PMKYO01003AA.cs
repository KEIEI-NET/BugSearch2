//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ送信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智 
// 修 正 日  2009/04/28  修正内容 : 在庫系データの処理と集計機対応の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智 
// 修 正 日  2009/06/17  修正内容 : PVCS票#161 抽出対象データが存在しない場合のログについて 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内 数馬 
// 修 正 日  2011/02/01  修正内容 : 更新日時取得条件の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉 
// 修 正 日  2011/07/25  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉 
// 修 正 日  2011/08/19  修正内容 : redmine #23692,#23807の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/25  修正内容 : Redmine #23980送信結果件数不正についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/31  修正内容 : Redmine #24278 データ自動受信処理が起動しません
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/14  修正内容 : Redmine #25009 送信時よりも受信時の方が開始日付が早くなる
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : dingjx
// 修 正 日  2011/11/01  修正内容 : Redmine #26228 拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/01  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/11/10  修正内容 : Redmine#26228　拠点管理改良／伝票日付による抽出対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/12/06  修正内容 : Redmine#8293 画面の終了日付＋システム時刻仕様の変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/12/07  修正内容 : Redmine#8293 画面の終了日付仕様の変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許培珠
// 修 正 日  2011/12/22  修正内容 : Redmine#27395 拠点管理/送信データの漏れ
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : zhlj
// 修 正 日  2013/02/07  修正内容 : 10900690-00 2013/3/13配信分の緊急対応
//                                  Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応
//----------------------------------------------------------------------------//
// 管理番号  11600006-00 作成担当 : 譚洪
// 修 正 日  2020/09/25  修正内容 : PMKOBETSU-3877の対応
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
    /// データ送信処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : データ送信処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.04.02<br />
    /// Update     : dingjx</br>
    /// Note       : Redmine #26228</br>
    /// Update Note: 2020/09/25 譚洪<br />
    /// 管理番号   : 11600006-00<br />
    ///            : PMKOBETSU-3877の対応<br />
    /// </remarks>
    public class UpdateCountInputAcs
    {
        # region ■ Constructor ■

        #region ■ Const Memebers ■
        private const int MAXCOUNT_16 = 16;
        private const string ZERO_0 = "0";
        private const string MARK_1 = ":";
        private const string MARK_2 = "、";
        private const string MARK_3 = " ";
        private const string PROGRAM_ID = "PMKYO01001UA";
        private const string PROGRAM_NAME = "データ送信処理";
        private const string COUNTNAME = "件";
        #endregion ■ Const Memebers ■

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private UpdateCountInputAcs()
        {
            // 変数初期化
            this._dataSet = new UpdateResultDataSet();
            this._extractionConditionDataSet = new ExtractionConditionDataSet();
            this._updateResultDataTable = this._dataSet.UpdateResult;
            this._extractionConditionDataTable = this._extractionConditionDataSet.ExtractionCondition;
            this._baseDataExtraDefSetDB = APBaseDataExtraDefSetDB.GetExtraAndUpdControlDB();
            this._secMngConnectStAcs = new SecMngConnectStAcs();
            this._sendSetAcs = new SendSetAcs();
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
        # endregion ■ Properties ■

        # region ■ Private Members ■
        // 更新結果データセット
        private UpdateResultDataSet _dataSet;
        // 抽出条件データセット
        private ExtractionConditionDataSet _extractionConditionDataSet;
        // 更新結果データテーブル
        private UpdateResultDataSet.UpdateResultDataTable _updateResultDataTable;
        // 抽出条件データテーブル
        private ExtractionConditionDataSet.ExtractionConditionDataTable _extractionConditionDataTable;
        private static UpdateCountInputAcs _updateCountInsts;
        private IAPSendMessageDB _baseDataExtraDefSetDB;
        private IDCControlDB _idcControlDB;
        private ISKControlDB _iskControlDB;
        // 拠点管理接続先設定アクセス
        private SecMngConnectStAcs _secMngConnectStAcs;
        // 送受信対象設定のアクセス
        SendSetAcs _sendSetAcs;

        private int _extractCondDiv; //ADD 2011/11/01 xupz

        # endregion ■ Private Members ■

        # region ■ データ送信処理アクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// データ送信処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>データ送信処理アクセスクラス インスタンス</returns>
        public static UpdateCountInputAcs GetInstance()
        {
            if (_updateCountInsts == null)
            {
                _updateCountInsts = new UpdateCountInputAcs();
            }

            return _updateCountInsts;
        }
        # endregion ■ データ送信処理アクセスクラス インスタンス取得処理 ■

        # region ■ データ送信処理 ■
        /// <summary>
        /// データ送信処理
        /// </summary>
        /// <param name="beginningTime">開始時間</param>
        /// <param name="endingTime">終了時間</param>
        /// <param name="startTime">開始時間</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="updSectionCode">upd企業コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
		/// <param name="baseCode">拠点コード</param>
		/// <param name="sendCode">send拠点コード</param>
        /// <param name="isEmpty">データがあるかどうか</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="fileIds">ファイルID配列</param>
		/// <param name="fileNms">ファイル名称配列</param>
		/// <param name="sendDestEpCodeList">sendDestEpCodeList</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : パラメータにより、データ送信処理する。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        //public SearchCountWork UpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updEmployeeCode, string baseCode, out bool isEmpty, int connectPointDiv, string[] fileIds)
		//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
		//public SearchCountWork UpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updEmployeeCode, string baseCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms)
		//{
		//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
        //  DEL dingjx  2011/11/01  ------------------------------------->>>>>>
        //-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
        //public SearchCountWork UpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updSectionCode, string updEmployeeCode,
        //    string baseCode,string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList)
        //{
		//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
        //  DEL dingjx  2011/11/01  -------------------------------------<<<<<<<

        //  ADD dingjx  2011/11/01  ------------------------------------->>>>>>
        public SearchCountWork UpdateProc(int extractCondDiv, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updSectionCode, string updEmployeeCode,
            // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            //string baseCode, string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList)
            string baseCode, string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList, int acptAnOdrSendDiv, int shipmentSendDiv, int estimateSendDiv)
        // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
        {
        //  ADD dingjx  2011/11/01  -------------------------------------<<<<<<
            string retMessage;
            isEmpty = false;
            SearchCountWork searchCountWork = new SearchCountWork();
			CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            DateTime syncExecDt = new DateTime();
            DateTime syncExecDtTemp = new DateTime(); // ADD 2011/12/06
            DateTime syncExecDtLogTemp = new DateTime(); // ADD 2011/12/06
            bool updateFlg = true; // ADD 2011/12/07
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
			
			DateTime minSyncExecDt = new DateTime();//ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）

            // データ更新処理
            if (connectPointDiv == 0)
            {
                if (this._idcControlDB == null)
                {
                    this._idcControlDB = MediationDCControlDB.GetDCControlDB();
                }
            }
            else
            {
                if (this._iskControlDB == null)
                {
                    this._iskControlDB = MediationSKControlDB.GetSKControlDB();
                }
            }

            // 抽出・更新コントロール処理リモートを呼び出して抽出データを取得し、抽出結果クラスを返します。
			//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			//int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayList(enterpriseCode, beginningTime, endingTime, ref retCSAList, fileIds, out retMessage);
			//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
			//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			APSendDataWork paraSendDataWork = new APSendDataWork();
			paraSendDataWork.EndDateTime = endingTime;
			paraSendDataWork.StartDateTime = beginningTime;
			paraSendDataWork.PmEnterpriseCode = enterpriseCode;
			paraSendDataWork.PmSectionCode = baseCode;
            paraSendDataWork.SndMesExtraCondDiv = extractCondDiv;   //  ADD dingjx  2011/11/01                  
            paraSendDataWork.SyncExecDate = startTime.Ticks;
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            paraSendDataWork.AcptAnOdrSendDiv = acptAnOdrSendDiv;
            paraSendDataWork.ShipmentSendDiv = shipmentSendDiv;
            paraSendDataWork.EstimateSendDiv = estimateSendDiv;
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

            // ADD 2011/12/06 ----------->>>>>>
            // ADD 2011/12/07 ----------->>>>>>
            if (extractCondDiv == 1)
            {
                // システム日付
                long endTimeTemp = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));

                // 画面終了日付が過去日付の場合：
                if (endTimeTemp > endingTime)
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    23, 59, 59);
                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTime;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
                // 画面終了日がシステム日付の場合：
                else if (endTimeTemp == endingTime)
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        DateTime endTimeLog = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                            int.Parse(endTimeStr.Substring(4, 2)),
                            int.Parse(endTimeStr.Substring(6, 2)),
                            23, 59, 59);

                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTimeLog;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
                // 画面終了日が未来日付の場合：
                else
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    23, 59, 59);
                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTime;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }

                    updateFlg = false;
                }



            }
            // ADD 2011/12/06 -----------<<<<<<
            // ADD 2011/12/07 -----------<<<<<<
            
            this._extractCondDiv = extractCondDiv; // ADD 2011/11/01 xupz
			int no = 0;
			int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayListSCM(out retCSAList, paraSendDataWork, baseCode, fileIds, out retMessage, out no, updSectionCode);
			//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

            // 抽出結果正常の場合、データ変換処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();
                
                // データ変換処理
				//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				//// -- UPD 2011/02/01 ---------------------------------------->>>
				////syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds);
				//syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);
				//// -- UPD 2011/02/01 ----------------------------------------<<<
				//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
				//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);
				//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

                if (isEmpty)
                {
                    // 抽出結果CustomSerializeArrayListの内容が存在しない場合、
                    // MOD 2009/06/23 ---->>>
                    // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "抽出対象のデータが存在しません。");
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
                    // MOD 2009/06/23 ----<<<
                    return searchCountWork;
                }
                else
                {
                    try
                    {
                        // データ更新処理
                        if (connectPointDiv == 0)
                        {
                            // DC更新
							//status = _idcControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);//DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）

							//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
							//送受信履歴ログデータの設定
							ArrayList objList = new ArrayList();
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
							// del by 張莉莉 2011.08.19  redmine #23692 の対応 ----------->>>>>>>
							//string sdate = DateTime.Now.ToShortDateString().Replace("/", "");
							//string stime = DateTime.Now.ToShortTimeString().Replace(":", "");
							//sndRcvHisWork.SendDateTime = long.Parse(sdate) * 10000 + long.Parse(stime);
							// del by 張莉莉 2011.08.19  redmine #23692 の対応 -----------<<<<<<<
							sndRcvHisWork.SendDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));// ADD by 張莉莉 2011.08.19 redmine #23692 の対応
							//送受信ログ利用区分:｢0:拠点管理｣
							sndRcvHisWork.SndLogUseDiv = 0;
							//送受信区分:｢0:送信｣
							sndRcvHisWork.SendOrReceiveDivCd = 0;
							//種別:｢0:データ｣
							sndRcvHisWork.Kind = 0;
							//送受信ログ抽出条件区分「0:自動(差分)」
                            //sndRcvHisWork.SndLogExtraCondDiv = 0;   //  DEL dingjx  2011/11/01
                            sndRcvHisWork.SndLogExtraCondDiv = extractCondDiv;  //  ADD dingjx  2011/11/01
							//送信対象拠点コード
							sndRcvHisWork.ExtraObjSecCode = baseCode;

                            sndRcvHisWork.SyncExecDate = startTime;  // ADD 2011/11/30
							//送信対象開始日時、送信対象終了日時
                            // ----- DEL 2011/11/01 xupz---------->>>>>
                            //sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                            //sndRcvHisWork.SndObjEndDate = syncExecDt;
                            // ----- DEL 2011/11/01 xupz----------<<<<<
                            // ----- ADD 2011/11/01 xupz---------->>>>>
                             if (extractCondDiv == 0)
                            {
                                sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
                                sndRcvHisWork.SndObjEndDate = syncExecDt;
                            }
                            else
                            {
                               sndRcvHisWork.SndObjStartDate = minSyncExecDt;
                               //sndRcvHisWork.SndObjEndDate = syncExecDt.AddDays(1).AddTicks(-1); // DEL 2011/12/06
                               //sndRcvHisWork.SndObjEndDate = syncExecDtTemp; // ADD 2011/12/06 // DEL 2011/12/07
                               sndRcvHisWork.SndObjEndDate = syncExecDtLogTemp;  // ADD 2011/12/07
                            }
                            // ----- ADD 2011/11/01 xupz----------<<<<<
							//送信先企業コード
							for (int i = 0; i < sendDestEpCodeList.Count; i++)
							{
								if (((EnterpriseSet)sendDestEpCodeList[i]).SectionCode.Trim().Equals(sendCode.Trim()))
								{
									sndRcvHisWork.SendDestEpCode = ((EnterpriseSet)sendDestEpCodeList[i]).PmEnterpriseCode;
									break;
								}
							}
							//送信先拠点コード
							sndRcvHisWork.SendDestSecCode = sendCode;
							objList.Add(sndRcvHisWork);
							ArrayList paraList = new ArrayList();
							paraList.Add(objList);
							status = _idcControlDB.UpdateSCM(ref updCSAList, enterpriseCode, paraList, out retMessage);

							//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        }
                        else
                        {
                            // 集計機更新
                            status = _iskControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);
                        }
                    }
                    catch (Exception e)
                    {
                        retMessage = e.Message;
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }
            }
            // 抽出処理がエラーの場合、「4　操作履歴ログデータへの書き込み」へ続ける。
            else
            {
                // MOD 2009/06/23 ---->>>
                // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "抽出エラー(拠点：" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + baseCode + ")", string.Empty);
                // MOD 2009/06/23 ----<<<
                searchCountWork.Status = -1;
                return searchCountWork;
            }

            // status＝0正常の場合、「4　操作履歴ログデータへの書き込み」
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string logStr = string.Empty;
                // MOD 2009/06/23 ---->>>
                //foreach (string fileId in fileIds)
                for (int i = 0; i < fileIds.Length; i++)
                // MOD 2009/06/23 ----<<<
                {
                    // MOD 2009/06/23 ---->>>
                    /*
                    if (logStr == string.Empty)
                    {
                        logStr += fileId + MARK_3;
                    }
                    else
                    {
                        logStr += MARK_2 + fileId + MARK_3;
                    }
                    */
                    string fileId = fileIds[i];
                    if (!string.IsNullOrEmpty(logStr))
                    {
                        logStr += MARK_2;
                    }
                    // MOD 2009/06/23 ----<<<
                    switch (fileId)
                    {
                        // 売上データ
                        case "SalesSlipRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesSlipCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesSlipCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 売上明細データ
                        case "SalesDetailRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesDetailCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesDetailCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 売上履歴データ
                        case "SalesHistoryRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesHistoryCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesHistoryCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 売上履歴明細データ
                        case "SalesHistDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesHistDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesHistDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 入金データ
                        case "DepsitMainRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.DepsitMainCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepsitMainCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 入金明細データ
                        case "DepsitDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.DepsitDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepsitDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 仕入データ
                        case "StockSlipRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlipCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlipCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 仕入明細データ
                        case "StockDetailRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockDetailCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockDetailCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 仕入履歴データ
                        case "StockSlipHistRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlipHistCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlipHistCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 仕入履歴明細データ
                        case "StockSlHistDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlHistDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlHistDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 支払伝票マスタ
                        case "PaymentSlpRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.PaymentSlpCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PaymentSlpCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 支払明細データ
                        case "PaymentDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.PaymentDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PaymentDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 受注マスタ
                        case "AcceptOdrRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.AcceptOdrCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.AcceptOdrCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 受注マスタ（車両）
                        case "AcceptOdrCarRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.AcceptOdrCarCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.AcceptOdrCarCount);
                            // MOD 2009/06/23 ----<<<
                            break;
						// DEL 2011.08.19 ------->>>>>
						//// 売上月次集計データ
						//case "MTtlSalesSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						//// 商品別売上月次集計データ
						//case "GoodsMTtlSaSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						//// 仕入月次集計データ
						//case "MTtlStockSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						// DEL 2011.08.19 -------<<<<<
                        // 在庫調整データ
                        case "StockAdjustRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockAdjustCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAdjustCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 在庫調整明細データ
                        case "StockAdjustDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockAdjustDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAdjustDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 在庫移動データ
                        case "StockMoveRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockMoveCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockMoveCount);
                            // MOD 2009/06/23 ----<<<
							break;
						// DEL 2011.08.19 ------->>>>>
						//// 在庫受払履歴データ
						//case "StockAcPayHistRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						// DEL 2011.08.19 -------<<<<<
						//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
						// 入金引当マスタ
						case "DepositAlwRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepositAlwCount);
							break;
						// 受取手形マスタ
						case "RcvDraftDataRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.RcvDraftDataCount);
							break;
						// 受取手形マスタ
						case "PayDraftDataRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PayDraftDataCount);
							break;
						//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                    }
                }

                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                    logStr, "正常(拠点：" + baseCode + ")");
                searchCountWork.Status = 0;
            }
            // APロックのタイムアウトの場合、
            else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT) 
            {
                // MOD 2009/06/23 ---->>>
                // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + baseCode + ")", string.Empty);
                // MOD 2009/06/23 ----<<<
                searchCountWork.Status = -2;
                return searchCountWork;
            }
            // DBのSQLエラーの場合、
            else if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                // MOD 2009/06/23 ---->>>
                // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + baseCode + ")", string.Empty);
                // MOD 2009/06/23 ----<<<
                searchCountWork.Status = -3;
                return searchCountWork;
            }
            // システムとその他エラーの場合、
            else 
            {
                // MOD 2009/06/23 ---->>>
                // operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCode + ")");
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + baseCode + ")", string.Empty);
                // MOD 2009/06/23 ----<<<
                searchCountWork.Status = status;
                return searchCountWork;
            }
            // 拠点管理設定マスタの更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ------ DEL 2011/11/01 ------>>>>>>
                //// 上記抽出した拠点コードに対して全データの更新日付参照し、取得レコードの最新レコード日付を算出します。
                //if (startTime < syncExecDt)
                //{
                //    // 拠点管理設定マスタの更新
                //    status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecDt, out retMessage, baseCode, sendCode);
                //}
                //------ DEL 2011/11/01 ------<<<<<<
                //------ ADD 2011/11/01 ------>>>>>>
                //抽出条件区分が「差分」の場合
                if (extractCondDiv == 0)
                {
                    // 上記抽出した拠点コードに対して全データの更新日付参照し、取得レコードの最新レコード日付を算出します。
                    if (startTime < syncExecDt)
                    {
                        // 拠点管理設定マスタの更新
                        status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecDt, out retMessage, baseCode, sendCode);
                    }
                }
                // ----- ADD 2011/11/10 xupz---------->>>>>
                //抽出条件区分が「伝票日付」の場合
                if (extractCondDiv == 1)
                {
                    //DateTime syncExecReplDt = syncExecDt.AddDays(1).AddTicks(-1);  // DEL 2011/11/30
                    //DateTime syncExecReplDt = new DateTime(syncExecDt.Year, syncExecDt.Month, syncExecDt.Day, 23, 59, 59); // ADD 2011/11/30  // DEL 2011/12/06
                    if (updateFlg) // ADD 2011/12/07
                    {
                        if (startTime < syncExecDtTemp) // ADD 2011/12/06
                        {
                    // 拠点管理設定マスタの更新
                            //status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecReplDt, out retMessage, baseCode, sendCode); // DEL 2011/12/06
                            status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecDtTemp, out retMessage, baseCode, sendCode);// ADD 2011/12/06
                        }
                    }
                }
                // ----- ADD 2011/11/10 xupz----------<<<<<
                //------ ADD 2011/11/01 ------<<<<<<
            }
            return searchCountWork;

        }

        /// <summary>
        /// データ送信処理自起動用
        /// </summary>
        /// <param name="beginningTime">開始時間</param>
        /// <param name="endingTime">終了時間</param>
        /// <param name="startTime">開始時間</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
		/// <param name="baseCode">拠点コード</param>
		/// <param name="sendCode">拠点コード</param>
        /// <param name="isEmpty">データがあるかどうか</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : パラメータにより、データ送信処理する。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// <br>Update Note: 2020/09/25 譚洪</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
        /// </remarks>
		//public int ServsUpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updEmployeeCode, string baseCode, out bool isEmpty, int connectPointDiv)
        public int ServsUpdateProc(Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updEmployeeCode, string baseCode,string sendCode, out bool isEmpty, int connectPointDiv)
        {
            string retMessage;
            isEmpty = false;
            SearchCountWork searchCountWork = new SearchCountWork();
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            DateTime syncExecDt = new DateTime();
            OperationLogSvrDB operationLogSvrDB = new OperationLogSvrDB();
			//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
            //string updSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;//DEL 2011/08/31 Redmine #24278 データ自動受信処理が起動しません
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません ---------->>>>>
            string updSectionCode = string.Empty;
            int ret = GetBelongSectionCodeFormXml(ref updSectionCode);
            if (ret != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return ret;
            }            
            //ADD 2011/08/31 Redmine #24278 データ自動受信処理が起動しません ----------<<<<<
			ArrayList sendDestEpCodeList = new ArrayList();
			EnterpriseSetAcs _enterpriseSetAcs = new EnterpriseSetAcs();
			_enterpriseSetAcs.SearchAll(out sendDestEpCodeList, enterpriseCode);
			int no;
			DateTime minSyncExecDt = new DateTime();
			//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

            // データ更新処理
            if (connectPointDiv == 0)
            {
                if (this._idcControlDB == null)
                {
                    this._idcControlDB = MediationDCControlDB.GetDCControlDB();
                }
            }
            else
            {
                if (this._iskControlDB == null)
                {
                    this._iskControlDB = MediationSKControlDB.GetSKControlDB();
                }
            }

            // 送信対象データの取得処理
            ArrayList sendDataList = new ArrayList();
            this.GetSecMngSendData(enterpriseCode, out sendDataList);
            if (sendDataList.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }
            // ファイルID配列
            string[] fileIds = new string[sendDataList.Count];
            // ADD 2009/06/23 ---->>>
            string[] fileNms = new string[sendDataList.Count];
            // ADD 2009/06/23 ----<<<
            for (int i = 0; i < sendDataList.Count; i++)
            {
                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)sendDataList[i];
                fileIds[i] = secMngSndRcv.FileId;
                // ADD 2009/06/23 ---->>>
                fileNms[i] = secMngSndRcv.FileNm;
                // ADD 2009/06/23 ----<<<
            }

            // 抽出・更新コントロール処理リモートを呼び出して抽出データを取得し、抽出結果クラスを返します。
			//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			//int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayList(enterpriseCode, beginningTime, endingTime, ref retCSAList, fileIds, out retMessage);
			//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
			//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			APSendDataWork paraSendDataWork = new APSendDataWork();
			paraSendDataWork.EndDateTime = endingTime;
			paraSendDataWork.StartDateTime = beginningTime;
			paraSendDataWork.PmEnterpriseCode = enterpriseCode;
			paraSendDataWork.PmSectionCode = baseCode;
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            // 送信区分取得
            for (int i = 0; i < sendDataList.Count; i++)
            {
                SecMngSndRcv secMngSndRcv = (SecMngSndRcv)sendDataList[i];
                fileIds[i] = secMngSndRcv.FileId;
                if (fileIds[i].Equals("SalesSlipRF"))
                {
                    //受注データ送信区分
                    paraSendDataWork.AcptAnOdrSendDiv = secMngSndRcv.AcptAnOdrSendDiv;
                    //貸出データ送信区分
                    paraSendDataWork.ShipmentSendDiv = secMngSndRcv.ShipmentSendDiv;
                    //見積データ送信区分
                    paraSendDataWork.EstimateSendDiv = secMngSndRcv.EstimateSendDiv;
                }
            }
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<
			int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayListSCM(out retCSAList, paraSendDataWork, baseCode, fileIds, out retMessage, out no, updSectionCode);
			//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
            // 抽出結果正常の場合、データ変換処理
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();

				//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				//// -- UPD 2011/02/01 ---------------------------------------->>>
				////syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds);
				//syncExecDt = this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);
				//// -- UPD 2011/02/01 ----------------------------------------<<<
				//-----DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
				//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
				this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);
				//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

                if (isEmpty)
                {
                    // 抽出結果CustomSerializeArrayListの内容が存在しない場合、
                    // MOD 2009/06/17 ---->>>
                    // operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, string.Empty, "抽出対象のデータが存在しません。");
                    operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
                    // MOD 2009/06/17 ----<<<

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    // 抽出結果CustomSerializeArrayListの内容が存在しない場合、
                    return status;
                }
                else
                {
                    // データ更新処理
                    if (connectPointDiv == 0)
                    {
						// DC更新
						//status = _idcControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);//DEL 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）

						//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
						//送受信履歴ログデータの設定
						ArrayList objList = new ArrayList();
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
						// del by 張莉莉 2011.08.19  redmine #23692 の対応 ----------->>>>>>>
						//string sdate = DateTime.Now.ToShortDateString().Replace("/", "");
						//string stime = DateTime.Now.ToShortTimeString().Replace(":", "");
						//sndRcvHisWork.SendDateTime = long.Parse(sdate) * 10000 + long.Parse(stime);
						// del by 張莉莉 2011.08.19  redmine #23692 の対応 -----------<<<<<<<
						sndRcvHisWork.SendDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));// ADD by 張莉莉 2011.08.19 redmine #23692 の対応
						//送受信ログ利用区分:｢0:拠点管理｣
						sndRcvHisWork.SndLogUseDiv = 0;
						//送受信区分:｢0:送信｣
						sndRcvHisWork.SendOrReceiveDivCd = 0;
						//種別:｢0:データ｣
						sndRcvHisWork.Kind = 0;
						//送受信ログ抽出条件区分「0:自動(差分)」
						sndRcvHisWork.SndLogExtraCondDiv = 0;
						//送信対象拠点コード
						sndRcvHisWork.ExtraObjSecCode = baseCode;
						//送信対象開始日時、送信対象終了日時
						sndRcvHisWork.SndObjStartDate = minSyncExecDt.AddTicks(-1);
						sndRcvHisWork.SndObjEndDate = syncExecDt;
						//送信先企業コード
						for (int i = 0; i < sendDestEpCodeList.Count; i++)
						{
							if (((EnterpriseSet)sendDestEpCodeList[i]).SectionCode.Trim().Equals(sendCode.Trim()))
							{
								sndRcvHisWork.SendDestEpCode = ((EnterpriseSet)sendDestEpCodeList[i]).PmEnterpriseCode;
								break;
							}
						}
						//送信先拠点コード
						sndRcvHisWork.SendDestSecCode = sendCode;
						objList.Add(sndRcvHisWork);
						ArrayList paraList = new ArrayList();
						paraList.Add(objList);
						status = _idcControlDB.UpdateSCM(ref updCSAList, enterpriseCode, paraList, out retMessage);

						//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                    }
                    else
                    {
                        // 集計機更新
                        status = _iskControlDB.Update(ref updCSAList, enterpriseCode, out retMessage);
                    }
                }
            }
            // 抽出処理がエラーの場合、「4　操作履歴ログデータへの書き込み」へ続ける。
            else
            {
                // MOD 2009/06/17 ---->>>
                // operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "抽出エラー(拠点：" + baseCode.Trim() + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + baseCode.Trim() + ")", string.Empty);
                // MOD 2009/06/17 ----<<<

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }

            // status＝0正常の場合、「4　操作履歴ログデータへの書き込み」
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                string logStr = string.Empty;
                // MOD 2009/06/23 ---->>>
                //foreach (string fileId in fileIds)
                for (int i = 0; i < fileIds.Length; i++)
                // MOD 2009/06/23 ----<<<
                {
                    // MOD 2009/06/23 ---->>>
                    /*
                    if (logStr == string.Empty)
                    {
                        logStr += fileId + MARK_3;
                    }
                    else
                    {
                        logStr += MARK_2 + fileId + MARK_3;
                    }
                    */
                    string fileId = fileIds[i];
                    if (!string.IsNullOrEmpty(logStr))
                    {
                        logStr += MARK_2;
                    }
                    // MOD 2009/06/23 ----<<<
                    switch (fileId)
                    {
                        // 売上データ
                        case "SalesSlipRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesSlipCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesSlipCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 売上明細データ
                        case "SalesDetailRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesDetailCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesDetailCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 売上履歴データ
                        case "SalesHistoryRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesHistoryCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesHistoryCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 売上履歴明細データ
                        case "SalesHistDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.SalesHistDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.SalesHistDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 入金データ
                        case "DepsitMainRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.DepsitMainCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepsitMainCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 入金明細データ
                        case "DepsitDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.DepsitDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepsitDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 仕入データ
                        case "StockSlipRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlipCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlipCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 仕入明細データ
                        case "StockDetailRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockDetailCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockDetailCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 仕入履歴データ
                        case "StockSlipHistRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlipHistCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlipHistCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 仕入履歴明細データ
                        case "StockSlHistDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockSlHistDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockSlHistDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 支払伝票マスタ
                        case "PaymentSlpRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.PaymentSlpCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PaymentSlpCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 支払明細データ
                        case "PaymentDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.PaymentDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PaymentDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 受注マスタ
                        case "AcceptOdrRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.AcceptOdrCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.AcceptOdrCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 受注マスタ（車両）
                        case "AcceptOdrCarRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.AcceptOdrCarCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.AcceptOdrCarCount);
                            // MOD 2009/06/23 ----<<<
							break;
						// DEL 2011.08.19 ------->>>>>
						//// 売上月次集計データ
						//case "MTtlSalesSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.MTtlSalesSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						//// 商品別売上月次集計データ
						//case "GoodsMTtlSaSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.GoodsMTtlSaSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						//// 仕入月次集計データ
						//case "MTtlStockSlipRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.MTtlStockSlipCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						// DEL 2011.08.19 -------<<<<<
                        // 在庫調整データ
                        case "StockAdjustRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockAdjustCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAdjustCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 在庫調整明細データ
                        case "StockAdjustDtlRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockAdjustDtlCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAdjustDtlCount);
                            // MOD 2009/06/23 ----<<<
                            break;
                        // 在庫移動データ
                        case "StockMoveRF":
                            // MOD 2009/06/23 ---->>>
                            //logStr += this.IntConvert(searchCountWork.StockMoveCount);
                            logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockMoveCount);
                            // MOD 2009/06/23 ----<<<
							break;
						// DEL 2011.08.19 ------->>>>>
						//// 在庫受払履歴データ
						//case "StockAcPayHistRF":
						//    // MOD 2009/06/23 ---->>>
						//    //logStr += this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.StockAcPayHistCount);
						//    // MOD 2009/06/23 ----<<<
						//    break;
						// DEL 2011.08.19 -------<<<<<
						//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
						// 入金引当マスタ
						case "DepositAlwRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.DepositAlwCount);
							break;
						// 受取手形マスタ
						case "RcvDraftDataRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.RcvDraftDataCount);
							break;
						// 受取手形マスタ
						case "PayDraftDataRF":
							logStr += fileNms[i] + MARK_3 + this.IntConvert(searchCountWork.PayDraftDataCount);
							break;
						//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                    }
                }

                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0,
                   logStr, "正常(拠点：" + baseCode.Trim() + ")");

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                // MOD 2009/06/17 ---->>>
                // operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, string.Empty, "更新エラー(拠点：" + baseCode.Trim() + ")");
                operationLogSvrDB.WriteOperationLogSvr(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "更新エラー(拠点：" + baseCode.Trim() + ")", string.Empty);
                // MOD 2009/06/17 ----<<<

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                return status;
            }
            // 拠点管理設定マスタの更新
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 上記抽出した拠点コードに対して全データの更新日付参照し、取得レコードの最新レコード日付を算出します。
                if (startTime < syncExecDt)
                {
                    // 拠点管理設定マスタの更新
                    status = _baseDataExtraDefSetDB.UpdateSecMngSet(enterpriseCode, updEmployeeCode, syncExecDt, out retMessage, baseCode, sendCode);
                }
            }
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
            if (searchCountLen <= 3)
            {
                searchCountStr = searchCountStr + COUNTNAME;
            }
            else if (3 < searchCountLen && searchCountLen <= 6)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 3) + "," + searchCountStr.Substring(searchCountLen - 3) + COUNTNAME;
            }
            else if (6 < searchCountLen && searchCountLen <= 9)
            {
                searchCountStr = searchCountStr.Substring(0, searchCountLen - 6) + ","
                    + searchCountStr.Substring(searchCountLen - 6, 3) + ","
                    + searchCountStr.Substring(searchCountLen - 3) + COUNTNAME;
            }
            return searchCountStr;
        }

        # endregion ■ データ送信処理 ■

        # region ■ データ変換処理 ■
        /// <summary>
        /// データ変換処理
        /// </summary>
        /// <param name="updCSAList">更新データ</param>
        /// <param name="searchCountWork">更新件数オブジェクト</param>
        /// <param name="isEmpty">データがあるかどうか</param>
        /// <param name="retCSAList">抽出データ</param>
		/// <param name="fileIds">ファイルID配列</param>
		/// <param name="beginningTime">beginningTime</param>
		/// <param name="endingTime">endingTime</param>
		/// <param name="syncExecDt">syncExecDt</param>
		/// <param name="minSyncExecDt">minSyncExecDt</param>
        /// <remarks>		
        /// <br>Note		: データ変換処理を行う。</br>
        /// <br>Programmer	: 譚洪</br>	
        /// <br>Date		: 2009.04.02</br>
        /// </remarks>
        // -- UPD 2011/02/01 ------------------------------------------------>>>
        //private DateTime DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out SearchCountWork searchCountWork, out bool isEmpty, CustomSerializeArrayList retCSAList, string[] fileIds)
		//private DateTime DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out SearchCountWork searchCountWork, out bool isEmpty, CustomSerializeArrayList retCSAList, string[] fileIds, Int64 beginningTime, Int64 endingTime)
        // -- UPD 2011/02/01 ------------------------------------------------<<<
		private void DivisionCustomSerializeArrayList(out CustomSerializeArrayList updCSAList, out SearchCountWork searchCountWork, out bool isEmpty, CustomSerializeArrayList retCSAList, string[] fileIds, Int64 beginningTime, Int64 endingTime, out DateTime syncExecDt, out DateTime minSyncExecDt)
        {
            // 売上データ
            ArrayList dcSalesSlipList = new ArrayList();                       
            Int32 salesSlipCount = 0;
            // 売上明細データ
            ArrayList dcSalesDetailList = new ArrayList();
            Int32 salesDetailCount = 0;
            // 売上履歴データ
            ArrayList dcSalesHistoryList = new ArrayList();
            Int32 salesHistoryCount = 0;
            // 売上履歴明細データ
            ArrayList dcSalesHistDtlList = new ArrayList();
            Int32 salesHistDtlCount = 0;
            // 入金データ   
            ArrayList dcDepsitMainList = new ArrayList();
            Int32 depsitMainCount = 0;
            // 入金明細データ         
            ArrayList dcDepsitDtlList = new ArrayList();
            Int32 depsitDtlCount = 0;
            // 仕入データ           
            ArrayList dcStockSlipList = new ArrayList();
            Int32 stockSlipCount = 0;
            // 仕入明細データ           
            ArrayList dcStockDetailList = new ArrayList();
            Int32 stockDetailCount = 0;
            // 仕入履歴データ        
            ArrayList dcStockSlipHistList = new ArrayList();
            Int32 stockSlipHistCount = 0;
            // 仕入履歴明細データ      
            ArrayList dcStockSlHistDtlList = new ArrayList();
            Int32 stockSlHistDtlCount = 0;
            // 支払伝票マスタ     
            ArrayList dcPaymentSlpList = new ArrayList();
            Int32 paymentSlpCount = 0;
            // 支払明細データ          
            ArrayList dcPaymentDtlList = new ArrayList();
            Int32 paymentDtlCount = 0;
            // 受注マスタ         
            ArrayList dcAcceptOdrList = new ArrayList();
            Int32 acceptOdrCount = 0;
            // 受注マスタ（車両）          
            ArrayList dcAcceptOdrCarList = new ArrayList();
			Int32 acceptOdrCarCount = 0;
			// DEL 2011.08.19 ------->>>>>
			//// 売上月次集計データ        
			//ArrayList dcMTtlSalesSlipList = new ArrayList();
			//Int32 mTtlSalesSlipCount = 0;
			//// 商品別売上月次集計データ       
			//ArrayList dcGoodsMTtlSaSlipList = new ArrayList();
			//Int32 goodsMTtlSaSlipCount = 0;
			//// 仕入月次集計データ
			//ArrayList dcMTtlStockSlipList = new ArrayList();
			//Int32 mTtlStockSlipCount = 0;
			// DEL 2011.08.19 -------<<<<<
            // 在庫調整データ
            ArrayList dcStockAdjustList = new ArrayList();
            Int32 stockAdjustCount = 0;
            // 在庫調整明細データ
            ArrayList dcStockAdjustDtlList = new ArrayList();
            Int32 stockAdjustDtlCount = 0;
            // 在庫移動データ
            ArrayList dcStockMoveList = new ArrayList();
            Int32 stockMoveCount = 0;
			// DEL 2011.08.19 ------->>>>>
			//// 在庫受払履歴データ
			//ArrayList dcStockAcPayHistList = new ArrayList();
			//Int32 stockAcPayHistCount = 0;
			// DEL 2011.08.19 -------<<<<<

			//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
			// 入金引当マスタ
			ArrayList dcDepositAlwList = new ArrayList();
			Int32 depositAlwCount = 0;
			// 受取手形データ
			ArrayList dcRcvDraftDataList = new ArrayList();
			Int32 rcvDraftDataCount = 0;
			// 支払手形データ
			ArrayList dcPayDraftDataList = new ArrayList();
			Int32 payDraftDataCount = 0;

			syncExecDt = new DateTime();
            minSyncExecDt = System.DateTime.Now;
			//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
            updCSAList = new CustomSerializeArrayList();
            searchCountWork = new SearchCountWork();
			//DateTime syncExecDt = new DateTime(); //DEL 2011/07/25
			
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

                    // DC売上データ変換処理
                    if (wktype.Equals(typeof(APSalesSlipWork)))
                    {
                        APSalesSlipWork salesSlipWork = (APSalesSlipWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (salesSlipWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = salesSlipWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (salesSlipWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = salesSlipWork.UpdateDateTime;
                        //}
						//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (salesSlipWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = salesSlipWork.UpdateDateTime;
                            }
                            if (salesSlipWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = salesSlipWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (salesSlipWork.SalesDate > syncExecDt)
                        //    {
                        //        syncExecDt = salesSlipWork.SalesDate;
                        //    }
                        //    if (salesSlipWork.SalesDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = salesSlipWork.SalesDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCSalesSlipWork dcSalesSlipWork = ConvertReceive.SearchDataFromUpdateData(salesSlipWork);
                        dcSalesSlipList.Add(dcSalesSlipWork);
                        salesSlipCount++;

                    }
                    // DC売上明細データ更新処理
                    else if (wktype.Equals(typeof(APSalesDetailWork)))
                    {
                        APSalesDetailWork salesDetailWork = (APSalesDetailWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //// -- UPD 2011/02/01 -------------------------------->>>
                        ////if (salesDetailWork.UpdateDateTime > syncExecDt)
                        //if ((salesDetailWork.UpdateDateTime > syncExecDt) && (salesDetailWork.UpdateDateTime.Ticks > beginningTime && salesDetailWork.UpdateDateTime.Ticks <= endingTime))
                        //// -- UPD 2011/02/01 --------------------------------<<<
                        //{
                        //    syncExecDt = salesDetailWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (salesDetailWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = salesDetailWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if ((salesDetailWork.UpdateDateTime > syncExecDt) && (salesDetailWork.UpdateDateTime.Ticks > beginningTime && salesDetailWork.UpdateDateTime.Ticks <= endingTime))
                            {
                                syncExecDt = salesDetailWork.UpdateDateTime;
                            }
                            if (salesDetailWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = salesDetailWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if ((salesDetailWork.SalesDate > syncExecDt))
                        //    {
                        //        syncExecDt = salesDetailWork.SalesDate;
                        //    }
                        //    if (salesDetailWork.SalesDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = salesDetailWork.SalesDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCSalesDetailWork dcSalesDetailWork = ConvertReceive.SearchDataFromUpdateData(salesDetailWork);
                        dcSalesDetailList.Add(dcSalesDetailWork);
                        salesDetailCount++;
                    }
                    // DC売上履歴データ更新処理
                    else if (wktype.Equals(typeof(APSalesHistoryWork)))
                    {
                        APSalesHistoryWork salesHistoryWork = (APSalesHistoryWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、

                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (salesHistoryWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = salesHistoryWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (salesHistoryWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = salesHistoryWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                       
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (salesHistoryWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = salesHistoryWork.UpdateDateTime;
                            }
                            if (salesHistoryWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = salesHistoryWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (salesHistoryWork.SalesDate > syncExecDt)
                        //    {
                        //        syncExecDt = salesHistoryWork.SalesDate;
                        //    }
                        //    if (salesHistoryWork.SalesDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = salesHistoryWork.SalesDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCSalesHistoryWork dcSalesHistoryWork = ConvertReceive.SearchDataFromUpdateData(salesHistoryWork);
                        dcSalesHistoryList.Add(dcSalesHistoryWork);
                        salesHistoryCount++;
                    }
                    // DC売上履歴明細データ更新処理
                    else if (wktype.Equals(typeof(APSalesHistDtlWork)))
                    {
                        APSalesHistDtlWork salesHistDtlWork = (APSalesHistDtlWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (salesHistDtlWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = salesHistDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (salesHistDtlWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = salesHistDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (salesHistDtlWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = salesHistDtlWork.UpdateDateTime;
                            }
                            if (salesHistDtlWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = salesHistDtlWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (salesHistDtlWork.SalesDate > syncExecDt)
                        //    {
                        //        syncExecDt = salesHistDtlWork.SalesDate;
                        //    }
                        //    if (salesHistDtlWork.SalesDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = salesHistDtlWork.SalesDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCSalesHistDtlWork dcSalesHistDtlWork = ConvertReceive.SearchDataFromUpdateData(salesHistDtlWork);
                        dcSalesHistDtlList.Add(dcSalesHistDtlWork);
                        salesHistDtlCount++;
                    }
                    // DC入金データ更新処理
                    else if (wktype.Equals(typeof(APDepsitMainWork)))
                    {
                        APDepsitMainWork depsitMainWork = (APDepsitMainWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (depsitMainWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = depsitMainWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (depsitMainWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = depsitMainWork.UpdateDateTime;
                        //}
                        //-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (depsitMainWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = depsitMainWork.UpdateDateTime;
                            }
                            if (depsitMainWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = depsitMainWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (depsitMainWork.DepositDate > syncExecDt)
                        //    {
                        //        syncExecDt = depsitMainWork.DepositDate;
                        //    }
                        //    if (depsitMainWork.DepositDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = depsitMainWork.DepositDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCDepsitMainWork dcDepsitMainWork = ConvertReceive.SearchDataFromUpdateData(depsitMainWork);
                        dcDepsitMainList.Add(dcDepsitMainWork);
                        depsitMainCount++;
                    }
                    // DC入金明細データ更新処理
                    else if (wktype.Equals(typeof(APDepsitDtlWork)))
                    {
                        APDepsitDtlWork depsitDtlWork = (APDepsitDtlWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (depsitDtlWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = depsitDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (depsitDtlWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = depsitDtlWork.UpdateDateTime;
                        //}
                        //-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (depsitDtlWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = depsitDtlWork.UpdateDateTime;
                            }
                            if (depsitDtlWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = depsitDtlWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCDepsitDtlWork dcDepsitDtlWork = ConvertReceive.SearchDataFromUpdateData(depsitDtlWork);
                        dcDepsitDtlList.Add(dcDepsitDtlWork);
                        depsitDtlCount++;
                    }
                    // DC仕入データ更新処理
                    else if (wktype.Equals(typeof(APStockSlipWork)))
                    {
                        APStockSlipWork stockSlipWork = (APStockSlipWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockSlipWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockSlipWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (stockSlipWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockSlipWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockSlipWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockSlipWork.UpdateDateTime;
                            }
                            if (stockSlipWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockSlipWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (stockSlipWork.StockDate > syncExecDt)
                        //    {
                        //        syncExecDt = stockSlipWork.StockDate;
                        //    }
                        //    if (stockSlipWork.StockDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = stockSlipWork.StockDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCStockSlipWork dcStockSlipWork = ConvertReceive.SearchDataFromUpdateData(stockSlipWork);
                        dcStockSlipList.Add(dcStockSlipWork);
                        stockSlipCount++;
                    }
                    // DC仕入明細データ更新処理
                    else if (wktype.Equals(typeof(APStockDetailWork)))
                    {
                        APStockDetailWork stockDetailWork = (APStockDetailWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockDetailWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockDetailWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (stockDetailWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockDetailWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockDetailWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockDetailWork.UpdateDateTime;
                            }
                            if (stockDetailWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockDetailWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCStockDetailWork dcStockDetailWork = ConvertReceive.SearchDataFromUpdateData(stockDetailWork);
                        dcStockDetailList.Add(dcStockDetailWork);
                        stockDetailCount++;
                    }
                    // DC仕入履歴データ更新処理
                    else if (wktype.Equals(typeof(APStockSlipHistWork)))
                    {
                        APStockSlipHistWork stockSlipHistWork = (APStockSlipHistWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockSlipHistWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockSlipHistWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (stockSlipHistWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockSlipHistWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockSlipHistWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockSlipHistWork.UpdateDateTime;
                            }
                            if (stockSlipHistWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockSlipHistWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (stockSlipHistWork.StockDate > syncExecDt)
                        //    {
                        //        syncExecDt = stockSlipHistWork.StockDate;
                        //    }
                        //    if (stockSlipHistWork.StockDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = stockSlipHistWork.StockDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCStockSlipHistWork dcStockSlipHistWork = ConvertReceive.SearchDataFromUpdateData(stockSlipHistWork);
                        dcStockSlipHistList.Add(dcStockSlipHistWork);
                        stockSlipHistCount++;
                    }
                    // DC仕入履歴明細データ更新処理
                    else if (wktype.Equals(typeof(APStockSlHistDtlWork)))
                    {
                        APStockSlHistDtlWork stockSlHistDtlWork = (APStockSlHistDtlWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockSlHistDtlWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockSlHistDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (stockSlHistDtlWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockSlHistDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockSlHistDtlWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockSlHistDtlWork.UpdateDateTime;
                            }
                            if (stockSlHistDtlWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockSlHistDtlWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCStockSlHistDtlWork dcStockSlHistDtlWork = ConvertReceive.SearchDataFromUpdateData(stockSlHistDtlWork);
                        dcStockSlHistDtlList.Add(dcStockSlHistDtlWork);
                        stockSlHistDtlCount++;
                    }
                    // DC支払伝票マスタ更新処理
                    else if (wktype.Equals(typeof(APPaymentSlpWork)))
                    {
                        APPaymentSlpWork paymentSlpWork = (APPaymentSlpWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (paymentSlpWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = paymentSlpWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (paymentSlpWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = paymentSlpWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (paymentSlpWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = paymentSlpWork.UpdateDateTime;
                            }
                            if (paymentSlpWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = paymentSlpWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    if (paymentSlpWork.PaymentDate > syncExecDt)
                        //    {
                        //        syncExecDt = paymentSlpWork.PaymentDate;
                        //    }
                        //    if (paymentSlpWork.PaymentDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = paymentSlpWork.PaymentDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        
                        DCPaymentSlpWork dcPaymentSlpWork = ConvertReceive.SearchDataFromUpdateData(paymentSlpWork);
                        dcPaymentSlpList.Add(dcPaymentSlpWork);
                        paymentSlpCount++;
                    }
                    // DC支払明細データ更新処理
                    else if (wktype.Equals(typeof(APPaymentDtlWork)))
                    {
                        APPaymentDtlWork paymentDtlWork = (APPaymentDtlWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (paymentDtlWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = paymentDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (paymentDtlWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = paymentDtlWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (paymentDtlWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = paymentDtlWork.UpdateDateTime;
                            }
                            if (paymentDtlWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = paymentDtlWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCPaymentDtlWork dcPaymentDtlWork = ConvertReceive.SearchDataFromUpdateData(paymentDtlWork);
                        dcPaymentDtlList.Add(dcPaymentDtlWork);
                        paymentDtlCount++;
                    }
                    // DC受注マスタ更新処理
                    else if (wktype.Equals(typeof(APAcceptOdrWork)))
                    {
                        APAcceptOdrWork acceptOdrWork = (APAcceptOdrWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (acceptOdrWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = acceptOdrWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (acceptOdrWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = acceptOdrWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (acceptOdrWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = acceptOdrWork.UpdateDateTime;
                            }
                            if (acceptOdrWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = acceptOdrWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                     
                        DCAcceptOdrWork dcAcceptOdrWork = ConvertReceive.SearchDataFromUpdateData(acceptOdrWork);
                        dcAcceptOdrList.Add(dcAcceptOdrWork);
                        acceptOdrCount++;
                    }
                    // DC受注マスタ（車両）更新処理
                    else if (wktype.Equals(typeof(APAcceptOdrCarWork)))
                    {
                        APAcceptOdrCarWork acceptOdrCarWork = (APAcceptOdrCarWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (acceptOdrCarWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = acceptOdrCarWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (acceptOdrCarWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = acceptOdrCarWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                         if (this._extractCondDiv == 0)
                        {
                            if (acceptOdrCarWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = acceptOdrCarWork.UpdateDateTime;
                            }
                            if (acceptOdrCarWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = acceptOdrCarWork.UpdateDateTime;
                            }
                        }
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCAcceptOdrCarWork dcAcceptOdrCarWork = ConvertReceive.SearchDataFromUpdateData(acceptOdrCarWork);
                        dcAcceptOdrCarList.Add(dcAcceptOdrCarWork);
                        acceptOdrCarCount++;
					}
					// DEL 2011.08.19 ------->>>>>
					//// DC売上月次集計データ更新処理
					//else if (wktype.Equals(typeof(APMTtlSalesSlipWork)))
					//{
					//    APMTtlSalesSlipWork mTtlSalesSlipWork = (APMTtlSalesSlipWork)retCSATemList[j];
					//    // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
					//    if (mTtlSalesSlipWork.UpdateDateTime > syncExecDt)
					//    {
					//        syncExecDt = mTtlSalesSlipWork.UpdateDateTime;
					//    }
					//    DCMTtlSalesSlipWork dcMTtlSalesSlipWork = ConvertReceive.SearchDataFromUpdateData(mTtlSalesSlipWork);
					//    dcMTtlSalesSlipList.Add(dcMTtlSalesSlipWork);
					//    mTtlSalesSlipCount++;
					//}
					//// DC商品別売上月次集計データ更新処理
					//else if (wktype.Equals(typeof(APGoodsMTtlSaSlipWork)))
					//{
					//    APGoodsMTtlSaSlipWork goodsMTtlSaSlipWork = (APGoodsMTtlSaSlipWork)retCSATemList[j];
					//    // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
					//    if (goodsMTtlSaSlipWork.UpdateDateTime > syncExecDt)
					//    {
					//        syncExecDt = goodsMTtlSaSlipWork.UpdateDateTime;
					//    }
					//    DCGoodsMTtlSaSlipWork dcGoodsMTtlSaSlipWork = ConvertReceive.SearchDataFromUpdateData(goodsMTtlSaSlipWork);
					//    dcGoodsMTtlSaSlipList.Add(dcGoodsMTtlSaSlipWork);
					//    goodsMTtlSaSlipCount++;
					//}
					//// DC仕入月次集計データ更新処理
					//else if (wktype.Equals(typeof(APMTtlStockSlipWork)))
					//{
					//    APMTtlStockSlipWork mTtlStockSlipWork = (APMTtlStockSlipWork)retCSATemList[j];
					//    // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
					//    if (mTtlStockSlipWork.UpdateDateTime > syncExecDt)
					//    {
					//        syncExecDt = mTtlStockSlipWork.UpdateDateTime;
					//    }
					//    DCMTtlStockSlipWork dcMTtlStockSlipWork = ConvertReceive.SearchDataFromUpdateData(mTtlStockSlipWork);
					//    dcMTtlStockSlipList.Add(dcMTtlStockSlipWork);
					//    mTtlStockSlipCount++;
					//}
					// DEL 2011.08.19 -------<<<<<
                    // DC在庫調整データ更新処理
                    else if (wktype.Equals(typeof(APStockAdjustWork)))
                    {
                        APStockAdjustWork stockAdjustWork = (APStockAdjustWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>  
                        //if (stockAdjustWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockAdjustWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (stockAdjustWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockAdjustWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockAdjustWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockAdjustWork.UpdateDateTime;
                            }
                            if (stockAdjustWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockAdjustWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime adjustDate = new DateTime(int.Parse(stockAdjustWork.AdjustDate.ToString().Substring(0, 4)), int.Parse(stockAdjustWork.AdjustDate.ToString().Substring(4, 2)), int.Parse(stockAdjustWork.AdjustDate.ToString().Substring(6, 2)));
                        //    if (adjustDate > syncExecDt)
                        //    {
                        //        syncExecDt = adjustDate;
                        //    }
                        //    if (adjustDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = adjustDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                        DCStockAdjustWork dcStockAdjustWork = ConvertReceive.SearchDataFromUpdateData(stockAdjustWork);
                        dcStockAdjustList.Add(dcStockAdjustWork);
                        stockAdjustCount++;
                    }
                    // DC在庫調整明細データ更新処理
                    else if (wktype.Equals(typeof(APStockAdjustDtlWork)))
                    {
                        APStockAdjustDtlWork stockAdjustDtl = (APStockAdjustDtlWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockAdjustDtl.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockAdjustDtl.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (stockAdjustDtl.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockAdjustDtl.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockAdjustDtl.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockAdjustDtl.UpdateDateTime;
                            }
                            if (stockAdjustDtl.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockAdjustDtl.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime adjustDate = new DateTime(int.Parse(stockAdjustDtl.AdjustDate.ToString().Substring(0, 4)), int.Parse(stockAdjustDtl.AdjustDate.ToString().Substring(4, 2)), int.Parse(stockAdjustDtl.AdjustDate.ToString().Substring(6, 2)));
                        //    if (adjustDate > syncExecDt)
                        //    {
                        //        syncExecDt = adjustDate;
                        //    }
                        //    if (adjustDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = adjustDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCStockAdjustDtlWork dcStockAdjustDtlWork = ConvertReceive.SearchDataFromUpdateData(stockAdjustDtl);
                        dcStockAdjustDtlList.Add(dcStockAdjustDtlWork);
                        stockAdjustDtlCount++;
                    }
                    // DC在庫移動データ更新処理
                    else if (wktype.Equals(typeof(APStockMoveWork)))
                    {
                        APStockMoveWork stockMoveWork = (APStockMoveWork)retCSATemList[j];
                        // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (stockMoveWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = stockMoveWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
                        //if (stockMoveWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = stockMoveWork.UpdateDateTime;
                        //}
                        ////-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (stockMoveWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = stockMoveWork.UpdateDateTime;
                            }
                            if (stockMoveWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = stockMoveWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime arrivalGoodsDay = new DateTime(int.Parse(stockMoveWork.ArrivalGoodsDay.ToString().Substring(0, 4)), int.Parse(stockMoveWork.ArrivalGoodsDay.ToString().Substring(4, 2)), int.Parse(stockMoveWork.ArrivalGoodsDay.ToString().Substring(6, 2)));
                        //    if (arrivalGoodsDay > syncExecDt)
                        //    {
                        //        syncExecDt = arrivalGoodsDay;
                        //    }
                        //    if (arrivalGoodsDay < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = arrivalGoodsDay;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
                      
                        DCStockMoveWork dcStockMoveWork = ConvertReceive.SearchDataFromUpdateData(stockMoveWork);
                        dcStockMoveList.Add(dcStockMoveWork);
                        stockMoveCount++;
					}
					// DEL 2011.08.19 ------->>>>>
					//// DC在庫受払履歴データ更新処理
					//else if (wktype.Equals(typeof(APStockAcPayHistWork)))
					//{
					//    APStockAcPayHistWork stockAcPayHisWork = (APStockAcPayHistWork)retCSATemList[j];
					//    // 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
					//    if (stockAcPayHisWork.UpdateDateTime > syncExecDt)
					//    {
					//        syncExecDt = stockAcPayHisWork.UpdateDateTime;
					//    }
					//    //-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
					//    if (stockAcPayHisWork.UpdateDateTime < minSyncExecDt)
					//    {
					//        minSyncExecDt = stockAcPayHisWork.UpdateDateTime;
					//    }
					//    //-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
					//    DCStockAcPayHistWork dcStockAcPayHisWork = ConvertReceive.SearchDataFromUpdateData(stockAcPayHisWork);
					//    dcStockAcPayHistList.Add(dcStockAcPayHisWork);
					//    stockAcPayHistCount++;
					//}
					// DEL 2011.08.19 -------<<<<<
					//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
					// 入金引当マスタ
					else if (wktype.Equals(typeof(APDepositAlwWork)))
                    {
						APDepositAlwWork depositAlwWork = (APDepositAlwWork)retCSATemList[j];
						// 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (depositAlwWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = depositAlwWork.UpdateDateTime;
                        //}
                        //if (depositAlwWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = depositAlwWork.UpdateDateTime;
                        //}
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (depositAlwWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = depositAlwWork.UpdateDateTime;
                            }
                            if (depositAlwWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = depositAlwWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime reconcileDate = new DateTime(int.Parse(depositAlwWork.ReconcileDate.ToString().Substring(0, 4)), int.Parse(depositAlwWork.ReconcileDate.ToString().Substring(4, 2)), int.Parse(depositAlwWork.ReconcileDate.ToString().Substring(6, 2)));
                        //    if (reconcileDate > syncExecDt)
                        //    {
                        //        syncExecDt = reconcileDate;
                        //    }
                        //    if (reconcileDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = reconcileDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
					
						DCDepositAlwWork dcDepositAlwWork = ConvertReceive.SearchDataFromUpdateData(depositAlwWork);
						dcDepositAlwList.Add(dcDepositAlwWork);
						depositAlwCount++;
                    }
					// 受取手形データ
					else if (wktype.Equals(typeof(APRcvDraftDataWork)))
					{
						APRcvDraftDataWork rcvDraftDataWork = (APRcvDraftDataWork)retCSATemList[j];
						// 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (rcvDraftDataWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = rcvDraftDataWork.UpdateDateTime;
                        //}
                        //if (rcvDraftDataWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = rcvDraftDataWork.UpdateDateTime;
                        //}
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (rcvDraftDataWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = rcvDraftDataWork.UpdateDateTime;
                            }
                            if (rcvDraftDataWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = rcvDraftDataWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime depositDate = new DateTime(int.Parse(rcvDraftDataWork.DepositDate.ToString().Substring(0, 4)), int.Parse(rcvDraftDataWork.DepositDate.ToString().Substring(4, 2)), int.Parse(rcvDraftDataWork.DepositDate.ToString().Substring(6, 2)));
                        //    if (depositDate > syncExecDt)
                        //    {
                        //        syncExecDt = depositDate;
                        //    }
                        //    if (depositDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = depositDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
					
						DCRcvDraftDataWork dcRcvDraftDataWork = ConvertReceive.SearchDataFromUpdateData(rcvDraftDataWork);
						dcRcvDraftDataList.Add(dcRcvDraftDataWork);
						rcvDraftDataCount++;
					}
					// 支払手形データ
					else if (wktype.Equals(typeof(APPayDraftDataWork)))
					{
						APPayDraftDataWork payDraftDataWork = (APPayDraftDataWork)retCSATemList[j];
						// 最新レコード日付　=＜　拠点管理設定マスタ.シンク実行日付の場合、
                        // ----- DEL 2011/11/01 xupz---------->>>>>
                        //if (payDraftDataWork.UpdateDateTime > syncExecDt)
                        //{
                        //    syncExecDt = payDraftDataWork.UpdateDateTime;
                        //}
                        //if (payDraftDataWork.UpdateDateTime < minSyncExecDt)
                        //{
                        //    minSyncExecDt = payDraftDataWork.UpdateDateTime;
                        //}
                        // ----- DEL 2011/11/01 xupz----------<<<<<

                        // ----- ADD 2011/11/01 xupz---------->>>>>
                        if (this._extractCondDiv == 0)
                        {
                            if (payDraftDataWork.UpdateDateTime > syncExecDt)
                            {
                                syncExecDt = payDraftDataWork.UpdateDateTime;
                            }
                            if (payDraftDataWork.UpdateDateTime < minSyncExecDt)
                            {
                                minSyncExecDt = payDraftDataWork.UpdateDateTime;
                            }
                        }
                        // ----- DEL 2011/11/10 xupz---------->>>>>
                        //else
                        //{
                        //    DateTime paymentDate = new DateTime(int.Parse(payDraftDataWork.PaymentDate.ToString().Substring(0, 4)), int.Parse(payDraftDataWork.PaymentDate.ToString().Substring(4, 2)), int.Parse(payDraftDataWork.PaymentDate.ToString().Substring(6, 2)));
                        //    if (paymentDate > syncExecDt)
                        //    {
                        //        syncExecDt = paymentDate;
                        //    }
                        //    if (paymentDate < minSyncExecDt)
                        //    {
                        //        minSyncExecDt = paymentDate;
                        //    }
                        //}
                        // ----- DEL 2011/11/10 xupz----------<<<<<
                        // ----- ADD 2011/11/01 xupz----------<<<<<
						
						DCPayDraftDataWork dcPayDraftDataWork = ConvertReceive.SearchDataFromUpdateData(payDraftDataWork);
						dcPayDraftDataList.Add(dcPayDraftDataWork);
						payDraftDataCount++;
					}
					//-----ADD 2011/07/25 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                }
            }
            // ----- DEL 2011/11/01 xupz---------->>>>>
            //// ADD 2011.09.14 ---------->>>>>
            //if (syncExecDt.Ticks > endingTime)
            //{
            //    syncExecDt = new DateTime(endingTime);
            //}

            //if (minSyncExecDt.Ticks < beginningTime)
            //{
            //    minSyncExecDt = new DateTime(beginningTime).AddTicks(1);
            //}
            //// ADD 2011.09.14 ----------<<<<<
            // ----- DEL 2011/11/01 xupz----------<<<<<
            // ----- ADD 2011/11/01 xupz---------->>>>>
            if (this._extractCondDiv == 0)
            {
                if (syncExecDt.Ticks > endingTime)
                {
                    syncExecDt = new DateTime(endingTime);
                }
                if (minSyncExecDt.Ticks < beginningTime)
                {
                    minSyncExecDt = new DateTime(beginningTime).AddTicks(1);
                }
            }
            // ----- ADD 2011/11/10 xupz---------->>>>>
            if (this._extractCondDiv == 1)
            {
                DateTime startTime = new DateTime(int.Parse(beginningTime.ToString().Substring(0, 4)), int.Parse(beginningTime.ToString().Substring(4, 2)), int.Parse(beginningTime.ToString().Substring(6, 2)));
                DateTime endTime = new DateTime(int.Parse(endingTime.ToString().Substring(0, 4)), int.Parse(endingTime.ToString().Substring(4, 2)), int.Parse(endingTime.ToString().Substring(6, 2)));

                syncExecDt = endTime;
                minSyncExecDt = startTime;
            }
            // ----- ADD 2011/11/10 xupz----------<<<<<
            // ----- ADD 2011/11/01 xupz----------<<<<<

            foreach (string fileId in fileIds)
            {
                switch (fileId)
				{
					# region [DEL]
					//// 売上データ
					//case "SalesSlipRF":
					//    // 売上データ
					//    updCSAList.Add(dcSalesSlipList);
					//    searchCountWork.SalesSlipCount = salesSlipCount;
					//    break;
					//// 売上明細データ
					//case "SalesDetailRF":
					//    // 売上明細データ
					//    updCSAList.Add(dcSalesDetailList);
					//    searchCountWork.SalesDetailCount = salesDetailCount;
					//    break;
					//// 売上履歴データ
					//case "SalesHistoryRF":
					//    // 売上履歴データ
					//    updCSAList.Add(dcSalesHistoryList);
					//    searchCountWork.SalesHistoryCount = salesHistoryCount;
					//    break;
					//// 売上履歴明細データ
					//case "SalesHistDtlRF":
					//    // 売上履歴明細データ
					//    updCSAList.Add(dcSalesHistDtlList);
					//    searchCountWork.SalesHistDtlCount = salesHistDtlCount;
					//    break;
					//// 入金データ
					//case "DepsitMainRF":
					//    // 入金データ
					//    updCSAList.Add(dcDepsitMainList);
					//    searchCountWork.DepsitMainCount = depsitMainCount;
					//    break;
					//// 入金明細データ
					//case "DepsitDtlRF":
					//    // 入金明細データ
					//    updCSAList.Add(dcDepsitDtlList);
					//    searchCountWork.DepsitDtlCount = depsitDtlCount;
					//    break;
					//// 仕入データ
					//case "StockSlipRF":
					//    // 仕入データ
					//    updCSAList.Add(dcStockSlipList);
					//    searchCountWork.StockSlipCount = stockSlipCount;
					//    break;
					//// 仕入明細データ
					//case "StockDetailRF":
					//    // 仕入明細データ
					//    updCSAList.Add(dcStockDetailList);
					//    searchCountWork.StockDetailCount = stockDetailCount;
					//    break;
					//// 仕入履歴データ
					//case "StockSlipHistRF":
					//    // 仕入履歴データ
					//    updCSAList.Add(dcStockSlipHistList);
					//    searchCountWork.StockSlipHistCount = stockSlipHistCount;
					//    break;
					//// 仕入履歴明細データ
					//case "StockSlHistDtlRF":
					//    // 仕入履歴明細データ
					//    updCSAList.Add(dcStockSlHistDtlList);
					//    searchCountWork.StockSlHistDtlCount = stockSlHistDtlCount;
					//    break;
					//// 支払伝票マスタ
					//case "PaymentSlpRF":
					//    // 支払伝票マスタ
					//    updCSAList.Add(dcPaymentSlpList);
					//    searchCountWork.PaymentSlpCount = paymentSlpCount;
					//    break;
					//// 支払明細データ
					//case "PaymentDtlRF":
					//    // 支払明細データ
					//    updCSAList.Add(dcPaymentDtlList);
					//    searchCountWork.PaymentDtlCount = paymentDtlCount;
					//    break;
					//// 受注マスタ
					//case "AcceptOdrRF":
					//    // 受注マスタ
					//    updCSAList.Add(dcAcceptOdrList);
					//    searchCountWork.AcceptOdrCount = acceptOdrCount;
					//    break;
					//// 受注マスタ（車両）
					//case "AcceptOdrCarRF":
					//    // 受注マスタ（車両）
					//    updCSAList.Add(dcAcceptOdrCarList);
					//    searchCountWork.AcceptOdrCarCount = acceptOdrCarCount;
					//    break;
					//// 売上月次集計データ
					//case "MTtlSalesSlipRF":
					//    // 売上月次集計データ
					//    updCSAList.Add(dcMTtlSalesSlipList);
					//    searchCountWork.MTtlSalesSlipCount = mTtlSalesSlipCount;
					//    break;
					//// 商品別売上月次集計データ
					//case "GoodsMTtlSaSlipRF":
					//    // 商品別売上月次集計データ
					//    updCSAList.Add(dcGoodsMTtlSaSlipList);
					//    searchCountWork.GoodsMTtlSaSlipCount = goodsMTtlSaSlipCount;
					//    break;
					//// 仕入月次集計データ
					//case "MTtlStockSlipRF":
					//    // 仕入月次集計データ
					//    updCSAList.Add(dcMTtlStockSlipList);
					//    searchCountWork.MTtlStockSlipCount = mTtlStockSlipCount;
					//    break;
					//// 在庫調整データ
					//case "StockAdjustRF":
					//    // 在庫調整データ
					//    updCSAList.Add(dcStockAdjustList);
					//    searchCountWork.StockAdjustCount = stockAdjustCount;
					//    break;
					//// 在庫調整明細データ
					//case "StockAdjustDtlRF":
					//    // 在庫調整明細データ
					//    updCSAList.Add(dcStockAdjustDtlList);
					//    searchCountWork.StockAdjustDtlCount = stockAdjustDtlCount;
					//    break;
					//// 在庫移動データ
					//case "StockMoveRF":
					//    // 在庫移動データ
					//    updCSAList.Add(dcStockMoveList);
					//    searchCountWork.StockMoveCount = stockMoveCount;
					//    break;
					//// 在庫受払履歴データ
					//case "StockAcPayHistRF":
					//    // 在庫受払履歴データ
					//    updCSAList.Add(dcStockAcPayHistList);
					//    searchCountWork.StockAcPayHistCount = stockAcPayHistCount;
					//    break;
					# endregion
					// 売上データ
					case "SalesSlipRF":
						// 売上データ
						updCSAList.Add(dcSalesSlipList);
						searchCountWork.SalesSlipCount = salesSlipCount;
						// 売上明細データ
						updCSAList.Add(dcSalesDetailList);
						searchCountWork.SalesDetailCount = salesDetailCount;
						// 受注マスタ
						updCSAList.Add(dcAcceptOdrList);
						searchCountWork.AcceptOdrCount = acceptOdrCount;
						// 受注マスタ（車両）
						updCSAList.Add(dcAcceptOdrCarList);
						searchCountWork.AcceptOdrCarCount = acceptOdrCarCount;
						break;
					// 売上履歴データ
					case "SalesHistoryRF":
						// 売上履歴データ
						updCSAList.Add(dcSalesHistoryList);
						searchCountWork.SalesHistoryCount = salesHistoryCount;
						// 売上履歴明細データ
						updCSAList.Add(dcSalesHistDtlList);
						searchCountWork.SalesHistDtlCount = salesHistDtlCount;
						break;
					// 入金データ
					case "DepsitMainRF":
						// 入金データ
						updCSAList.Add(dcDepsitMainList);
						searchCountWork.DepsitMainCount = depsitMainCount;
						// 入金明細データ
						updCSAList.Add(dcDepsitDtlList);
						searchCountWork.DepsitDtlCount = depsitDtlCount;
						break;
					// 仕入データ
					case "StockSlipRF":
						// 仕入データ
						updCSAList.Add(dcStockSlipList);
						searchCountWork.StockSlipCount = stockSlipCount;
						// 仕入明細データ
						updCSAList.Add(dcStockDetailList);
						searchCountWork.StockDetailCount = stockDetailCount;
						break;
					// 仕入履歴データ
					case "StockSlipHistRF":
						// 仕入履歴データ
						updCSAList.Add(dcStockSlipHistList);
						searchCountWork.StockSlipHistCount = stockSlipHistCount;
						// 仕入履歴明細データ
						updCSAList.Add(dcStockSlHistDtlList);
						searchCountWork.StockSlHistDtlCount = stockSlHistDtlCount;
						break;
					// 支払伝票マスタ
					case "PaymentSlpRF":
						// 支払伝票マスタ
						updCSAList.Add(dcPaymentSlpList);
						searchCountWork.PaymentSlpCount = paymentSlpCount;
						// 支払明細データ
						updCSAList.Add(dcPaymentDtlList);
						searchCountWork.PaymentDtlCount = paymentDtlCount;
						break;
					// 在庫調整データ
					case "StockAdjustRF":
						// 在庫調整データ
						updCSAList.Add(dcStockAdjustList);
						searchCountWork.StockAdjustCount = stockAdjustCount;
						break;
					// 在庫調整明細データ
					case "StockAdjustDtlRF":
						// 在庫調整明細データ
						updCSAList.Add(dcStockAdjustDtlList);
						searchCountWork.StockAdjustDtlCount = stockAdjustDtlCount;
						break;
					// 在庫移動データ
					case "StockMoveRF":
						// 在庫移動データ
						updCSAList.Add(dcStockMoveList);
						searchCountWork.StockMoveCount = stockMoveCount;
						break;
					// DEL 2011.08.19---------->>>>>
					//// 在庫受払履歴データ
					//case "StockAcPayHistRF":
					//    // 在庫受払履歴データ
					//    updCSAList.Add(dcStockAcPayHistList);
					//    searchCountWork.StockAcPayHistCount = stockAcPayHistCount;
					//    break;
					// DEL 2011.08.19----------<<<<<
					//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
					// 入金引当マスタ
					case "DepositAlwRF":
						// 入金引当マスタ
						updCSAList.Add(dcDepositAlwList);
						searchCountWork.DepositAlwCount = depositAlwCount;
						break;
					// 受取手形データ
					case "RcvDraftDataRF":
						// 受取手形データ
						updCSAList.Add(dcRcvDraftDataList);
						searchCountWork.RcvDraftDataCount = rcvDraftDataCount;
						break;
					// 支払手形データ
					case "PayDraftDataRF":
						// 支払手形データ
						updCSAList.Add(dcPayDraftDataList);
						searchCountWork.PayDraftDataCount = payDraftDataCount;
						break;
					//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<
                }
            }
			//return syncExecDt; 
        }
        # endregion ■ データ変換処理 ■

        # region ■ 更新時チェック ■
        /// <summary>
        /// 拠点管理設定情報を取得して、更新時チェックを行う。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
		/// <param name="baseCode">送信対象拠点コード</param>
		/// <param name="sendCode">送信先拠点コード</param>
        /// <param name="startDt">開始時間</param>
        /// <returns>シック時間</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、更新時チェックを行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
		//public bool UpdateOverProc(string enterpriseCode, string baseCode, out DateTime startDt) // DEL 2011.08.25
		public bool UpdateOverProc(string enterpriseCode, string baseCode,string sendCode, out DateTime startDt)// ADD 2011.08.25
        {
            string retMessage = string.Empty;
			//bool isUpdate = true;
			bool isUpdate = false;
			startDt = new DateTime();

			// DEL 2011.08.25 ---------->>>>>>
			//APSecMngSetWork secMngSetWork = new APSecMngSetWork();
			// 拠点管理設定情報を取得して、初期化設定を行う
			//int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWork, out retMessage);
			//// 検索0件の場合、或いはDBエラーの場合、
			//if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || string.IsNullOrEmpty(secMngSetWork.SectionCode)
			//    || !secMngSetWork.SectionCode.Equals(baseCode))
			//{
			//    isUpdate = false;
			//    return isUpdate;
			//}
			//startDt = secMngSetWork.SyncExecDate;
			// DEL 2011.08.25 ----------<<<<<<

			ArrayList secMngSetWorkList = new ArrayList();
			// 拠点管理設定情報を取得して、初期化設定を行う
			int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWorkList, out retMessage);

			// 検索0件の場合、或いはDBエラーの場合、
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (APSecMngSetWork secMngSetWork in secMngSetWorkList)
				{
					if (baseCode.Trim().Equals(secMngSetWork.SectionCode.Trim())
						&& sendCode.Trim().Equals(secMngSetWork.SendDestSecCode.Trim()))
					{
						isUpdate = true;
						startDt = secMngSetWork.SyncExecDate;
						return isUpdate;
					}
				}
			}
			else
			{
				return isUpdate;
			}

            return isUpdate;

        }
        # endregion ■ 更新時チェック ■

        # region ■ 初期化検索 ■
        /// <summary>
        /// 拠点管理設定情報を取得して、初期化処理を行う。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
		/// <param name="baseCode">拠点コード</param>
		/// <param name="secMngSetWorkList">secMngSetWorkList</param>
        /// <returns>シック時間</returns>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、初期化処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
		public DateTime LoadProc(string enterpriseCode, out string baseCode, out ArrayList secMngSetWorkList)
        {
            string retMessage = string.Empty;
            baseCode = string.Empty;
            DateTime startDt = new DateTime();
			//APSecMngSetWork secMngSetWork = new APSecMngSetWork();
			secMngSetWorkList = new ArrayList();
            // 拠点管理設定情報を取得して、初期化設定を行う
			//int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWork, out retMessage);
			int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWorkList, out retMessage);
            // 検索0件の場合、或いはDBエラーの場合、
			//if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || string.IsNullOrEmpty(secMngSetWork.SectionCode))
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return startDt;
            }
			foreach (APSecMngSetWork secMngSetWork in secMngSetWorkList)
			{
				// 検索結果を設定を行う
				ExtractionConditionDataSet.ExtractionConditionRow row = _extractionConditionDataTable.NewExtractionConditionRow();
				// 拠点コード
				row.BaseCode = secMngSetWork.SectionCode;
				baseCode = secMngSetWork.SectionCode;
				// 拠点名称
				
				//row.BaseName = secMngSetWork.SectionGuideNm;
				row.BaseName = GetSectionName(baseCode);
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				row.SendCode = secMngSetWork.SendDestSecCode;
				row.SendName = GetSectionName(secMngSetWork.SendDestSecCode);
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<


				DateTime syncExecDate = secMngSetWork.SyncExecDate;
				// 時、分、秒、2桁補足
				String syncExecDateHour = syncExecDate.Hour.ToString();
				String syncExecDateMinute = syncExecDate.Minute.ToString();
				String syncExecDateSecond = syncExecDate.Second.ToString();
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

				// システム時間
                //DateTime endDate = System.DateTime.Now; // DEL 2011/12/22 xupz for redmine#27395
                // ----- ADD 2011/12/22 xupz for redmine#27395---------->>>>>
                DateTime systemDate = System.DateTime.Now;
                DateTime endDate = systemDate.AddMinutes(-5); 
                // ----- ADD 2011/12/22 xupz for redmine#27395----------<<<<<
				String endDateHour = endDate.Hour.ToString();
				String endDateMinute = endDate.Minute.ToString();
				String endDateSecond = endDate.Second.ToString();
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
           

            return startDt;

        }

        // Add 2011/09/06 zhujc ------------>>>>>>
        /// <summary>
        /// 拠点管理設定情報を取得して、初期化処理を行う。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="secMngSetWorkList">secMngSetWorkList</param>
        /// <remarks>
        /// <br>Note       : 拠点管理設定情報を取得して、初期化処理を行う。</br>      
        /// <br>Programmer : 朱俊成</br>                                  
        /// <br>Date       : 2011.09.06</br> 
        /// </remarks>
        public int LoadProcAuto(string enterpriseCode, out ArrayList secMngSetWorkList)
        {
            string retMessage = string.Empty;
            secMngSetWorkList = new ArrayList();
            // 拠点管理設定情報を取得して、初期化設定を行う
            int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngSetWorkList, out retMessage);

            return status;
        }
        // Add 2011/09/06 zhujc ------------<<<<<<

        # endregion ■ 初期化検索 ■

        #region ■ オフライン状態チェック処理 ■

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ログオン時オンライン状態チェック処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        /// <returns>チェック処理結果</returns>
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
        /// <remarks>
        /// <br>Note       : リモート接続可能判定を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.02</br> 
        /// </remarks>
        /// <returns>判定結果</returns>
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
        /// <param name="isAutoRun">自起動かどうか</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 接続先チェック処理を行う。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>チェック処理結果</returns>
        public bool CheckConnect(string enterpriseCode, bool isAutoRun, out int connectPointDiv, out string errMsg)
        {
            bool retResult = false;
            SecMngConnectSt secMngConnectSt = null;
            errMsg = null;
            connectPointDiv = 0;

            int status = this._secMngConnectStAcs.Search(out secMngConnectSt, enterpriseCode);
            if (status == 0)
            {
                connectPointDiv = secMngConnectSt.ConnectPointDiv;

                // 自起動の場合、レジストリチェック処理を行わない
                if (isAutoRun)
                {
                    return true;
                }
                else
                {
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
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>読込結果ステータス</returns>
        private bool CheckRegistryKey(SecMngConnectSt secMngConnectSt)
        {
            bool retResult = false;
            try
            {
                string rKeyName1 = rKeyName1 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP");
                string rKeyName2 = rKeyName2 = @String.Format("SOFTWARE\\Broadleaf\\Product\\Partsman\\SUMMARY_AP\\SUMMARY_DB");
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

        #region ■ 送信対象データの取得処理 ■
        /// <summary>
        /// 送信対象データの取得処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sendDataList">送信対象データリスト</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 送信対象データの取得処理を行う。</br>      
        /// <br>Programmer : 劉学智</br>                                  
        /// <br>Date       : 2009.05.25</br> 
        /// </remarks>
        /// <returns>チェック処理結果</returns>
        public int GetSecMngSendData(string enterpriseCode, out ArrayList sendDataList)
        {
            sendDataList = new ArrayList();
            List<SecMngSndRcv> sendList = new List<SecMngSndRcv>();
            List<SecMngSndRcvDtl> sendDtlList = new List<SecMngSndRcvDtl>();
            // 全件検索
            int status = this._sendSetAcs.SearchAll(out sendList, out sendDtlList, enterpriseCode);

            // 送信データの取得
            foreach (SecMngSndRcv secMngSndRcv in sendList)
            {
                if (secMngSndRcv.DisplayOrder <= 99 && secMngSndRcv.SecMngSendDiv == 1)
                {
                    sendDataList.Add(secMngSndRcv);
                }
            }

            return status;
        }
        #endregion

		/// <summary>
		/// 拠点名称取得処理
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>拠点名称</returns>
		/// <remarks>
		/// </remarks>
		private string GetSectionName(string sectionCode)
		{
			string sectionName = string.Empty;

			if (sectionCode.Trim().PadLeft(2, '0') == "00")
			{
				sectionName = "全社共通";
				return sectionName;
			}

			ArrayList retList = new ArrayList();
			SecInfoAcs secInfoAcs = new SecInfoAcs();

			try
			{
				foreach (SecInfoSet secInfoSet in secInfoAcs.SecInfoSetList)
				{
					if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
					{
						sectionName = secInfoSet.SectionGuideNm.Trim();
						return sectionName;
					}
				}
			}
			catch
			{
				sectionName = string.Empty;
			}

			return sectionName;
		}

		//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）----->>>>>
		/// <summary>
		/// 送信先情報リロード
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sendDataList">拠点リスト</param>
		/// <returns>読込結果ステータス</returns>
		public int ReloadSecMngSetInfo(string enterpriseCode, out ArrayList sendDataList)
		{
			sendDataList = new ArrayList();
			string retMessage = string.Empty;
			ArrayList secMngInfoList = new ArrayList();
			// 拠点管理設定情報を取得して、初期化設定を行う
			int status = _baseDataExtraDefSetDB.SearchLoadData(enterpriseCode, out secMngInfoList, out retMessage);
			// 検索0件の場合、或いはDBエラーの場合、
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				return status;
			}
			foreach (APSecMngSetWork secMngSetWork in secMngInfoList)
			{
				if (!sendDataList.Contains(secMngSetWork.SendDestSecCode.Trim()))
				{
					sendDataList.Add(secMngSetWork.SendDestSecCode.Trim());
				}
			}
			return status;

		}
		//-----ADD 2011/07/28 張莉莉 SCM対応-拠点管理（10704767-00）-----<<<<<

        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ---------->>>>>
        #region ■ 送信対象データ件数の取得処理 ■
        /// <summary>
        /// 送信対象データ件数の取得処理
        /// </summary>
        /// <param name="extractCondDiv">抽出条件区分</param>
        /// <param name="beginningTime">開始時間</param>
        /// <param name="endingTime">終了時間</param>
        /// <param name="startTime">開始時間</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updSectionCode">upd企業コード</param>
        /// <param name="updEmployeeCode">従業員コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="sendCode">send拠点コード</param>
        /// <param name="isEmpty">データがあるかどうか</param>
        /// <param name="connectPointDiv">接続先区分</param>
        /// <param name="fileIds">ファイルID配列</param>
        /// <param name="fileNms">ファイル名称配列</param>
        /// <param name="sendDestEpCodeList">送信先拠点リスト</param>
        /// <returns>送信件数ワーク</returns>
        /// <remarks>
        /// <br>Note       : パラメータにより、送信データの件数を取得する。</br> 
        /// <br>           : 10900690-00 2013/3/13配信分の緊急対応</br>
        /// <br>           : Redmine#34588 拠点管理改良／送信確認画面の追加仕様の変更対応</br>
        /// <br>Programmer : zhlj</br>                                  
        /// <br>Date       : 2013/02/07</br>
        /// <br>Update Note: 2020/09/25 譚洪</br>
        /// <br>管理番号   : 11600006-00</br>
        /// <br>           : PMKOBETSU-3877の対応</br>
        /// </remarks>
        public SearchCountWork SearchDataProc(int extractCondDiv, Int64 beginningTime, Int64 endingTime, DateTime startTime, string enterpriseCode, string updSectionCode, string updEmployeeCode,
                    // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
                    //string baseCode, string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList)
                    string baseCode, string sendCode, out bool isEmpty, int connectPointDiv, string[] fileIds, string[] fileNms, ArrayList sendDestEpCodeList, int acptAnOdrSendDiv, int shipmentSendDiv, int estimateSendDiv)
                    // --- UPD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
        {
            string retMessage;
            isEmpty = false;
            // 送信件数ワーク
            SearchCountWork searchCountWork = new SearchCountWork();
            // 送信データの抽出結果
            CustomSerializeArrayList retCSAList = new CustomSerializeArrayList();
            CustomSerializeArrayList updCSAList = new CustomSerializeArrayList();
            // シンク時
            DateTime syncExecDt = new DateTime();
            DateTime syncExecDtTemp = new DateTime();
            DateTime syncExecDtLogTemp = new DateTime(); 
            // 操作履歴ログデータ
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            DateTime minSyncExecDt = new DateTime();
            // 送信データワーク
            APSendDataWork paraSendDataWork = new APSendDataWork();
            paraSendDataWork.EndDateTime = endingTime;
            paraSendDataWork.StartDateTime = beginningTime;
            paraSendDataWork.PmEnterpriseCode = enterpriseCode;
            paraSendDataWork.PmSectionCode = baseCode;
            paraSendDataWork.SndMesExtraCondDiv = extractCondDiv;                  
            paraSendDataWork.SyncExecDate = startTime.Ticks;
            // 送受信履歴ログ送信番号(SndNoCreateDiv==1:送信番号を生成しない)
            paraSendDataWork.SndNoCreateDiv = 1;

            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------>>>>>
            paraSendDataWork.AcptAnOdrSendDiv = acptAnOdrSendDiv;
            paraSendDataWork.ShipmentSendDiv = shipmentSendDiv;
            paraSendDataWork.EstimateSendDiv = estimateSendDiv;
            // --- ADD 2020/09/25 譚洪 PMKOBETSU-3877の対応 ------<<<<<

            // 抽出条件区分＝「伝票日付」の場合
            if (extractCondDiv == 1)
            {
                // システム日付
                long endTimeTemp = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));

                // 画面終了日付が過去日付の場合
                if (endTimeTemp > endingTime)
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    23, 59, 59);
                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTime;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
                // 画面終了日がシステム日付の場合
                else if (endTimeTemp == endingTime)
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        DateTime endTimeLog = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                            int.Parse(endTimeStr.Substring(4, 2)),
                            int.Parse(endTimeStr.Substring(6, 2)),
                            23, 59, 59);

                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTimeLog;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
                // 画面終了日が未来日付の場合
                else
                {
                    string endTimeStr = endingTime.ToString();
                    if (endTimeStr.Length == 8)
                    {
                        DateTime endTime = new DateTime(int.Parse(endTimeStr.Substring(0, 4)),
                                                    int.Parse(endTimeStr.Substring(4, 2)),
                                                    int.Parse(endTimeStr.Substring(6, 2)),
                                                    23, 59, 59);
                        syncExecDt = endTime;
                        syncExecDtTemp = endTime;
                        syncExecDtLogTemp = endTime;
                        paraSendDataWork.EndDateTimeTicks = endTime.Ticks;
                    }
                }
            }

            this._extractCondDiv = extractCondDiv;
            // 送信番号
            int no = 0;
            // 送信データの抽出処理
            int status = _baseDataExtraDefSetDB.SearchCustomSerializeArrayListSCM(out retCSAList, paraSendDataWork, baseCode, fileIds, out retMessage, out no, updSectionCode);

            // 抽出処理が正常の場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.DivisionCustomSerializeArrayList(out updCSAList, out searchCountWork, out isEmpty, retCSAList, fileIds, beginningTime, endingTime, out syncExecDt, out minSyncExecDt);

                if (isEmpty)
                {
                    // 抽出結果CustomSerializeArrayListの内容が存在しない場合
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, "抽出対象のデータが存在しません。", string.Empty);
                }
            }
            // 抽出処理がエラーの場合、「4　操作履歴ログデータへの書き込み」へ続ける。
            else
            {
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, -1, "抽出エラー(拠点：" + baseCode + ")", string.Empty);
                searchCountWork.Status = -1;
            }

            return searchCountWork;
        }

        #endregion
        // ----- ADD 2013/02/07 zhlj For Redmine#34588 ----------<<<<<

    }
}
