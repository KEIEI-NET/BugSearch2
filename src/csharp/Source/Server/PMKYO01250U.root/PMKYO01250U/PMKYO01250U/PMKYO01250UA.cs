//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : マスタ送受信自動起動処理
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
// 修 正 日  2009/06/16  修正内容 : PVCS票＃158の動作ディレクトリ設定の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/25  修正内容 : PVCS票＃284の動作ディレクトリ設定の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 馮文雄
// 修 正 日  2011/07/25  修正内容 : SCM対応-拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/31  修正内容 : Redmine #24278: データ自動受信処理が起動しません
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Broadleaf.Application.Controller;
using System.IO;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 受信処理自起動
    /// </summary>
    public partial class PMKYO01250UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region [ Private Member ]
        private MstUpdCountAcs _mstUpdCountAcs;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 受信データフォームクラス デフォルトコンストラクタ
        /// </summary>
        public PMKYO01250UA()
        {
            // 初期化処理
            InitializeComponent();
            this._mstUpdCountAcs = MstUpdCountAcs.GetInstance();
        }
        #endregion

        #region [ 配信連動自動マージ処理 ]
        internal void MergeOfferToUser(string parameter)
        {
            try
            {
                // 企業コード
                string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // 送信シンク日時
                DateTime _startTime = new DateTime();
                // 送信拠点コードリスト
                ArrayList baseCodeNameList = new ArrayList();
                // マスタ名称区分リスト
                ArrayList masterDivList = new ArrayList();
                // 拠点コード
                string baseCode = string.Empty;
                // 受信シンク日時
                //DateTime _recStartTime = new DateTime();//DEL 2011/07/25 馮文雄
                // 受信拠点コードリスト
                ArrayList recBaseCodeNameList = new ArrayList();
                // 送信マスタ名称リスト
                ArrayList masterNameList = new ArrayList();
                // 受信マスタ名称リスト
                ArrayList recMasterNameList = new ArrayList();
                // 受信マスタ名称区分リスト
                ArrayList recMasterDivList = new ArrayList();
                // 受信拠点情報リスト
                ArrayList secMngSetArrList = new ArrayList();
                // 受信マスタ名称明細区分リスト
                ArrayList masterDtlDivList = new ArrayList();
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                //送受信履歴ログデータリスト
                ArrayList sndRcvHisList = new ArrayList();
                //送受信抽出条件履歴ログデータリスト
                ArrayList sndRcvEtrList = new ArrayList();
                //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                // 受信拠点コード
                string recBaseCode = string.Empty;
                // PM企業コード
                string pmCode = string.Empty;
                // エラーメッセージ
                string errMsg = string.Empty;
                // 接続先区分
                Int32 _connectPointDiv = 0;

                // ↓ 2009.06.22 劉洋 add PVCS.231
                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // ↑ 2009.06.22 劉洋 add PVCS.231

                if ("0".Equals(parameter))
                {
                    // 送信情報マスタ名称取得
                    status = _mstUpdCountAcs.LoadMstName(_enterpriseCode, out masterNameList);
                    // 拠点情報を検索する
                    //status = _mstUpdCountAcs.LoadSyncExecDate(_enterpriseCode, out _startTime, out baseCodeNameList);//DEL 2011/07/25
                    status = _mstUpdCountAcs.LoadSyncExecDate(_enterpriseCode, out _startTime, out baseCodeNameList, 0);//ADD 2011/07/25
                    // 送信拠点コードを取得する。
                    foreach (BaseCodeNameWork baseCodeNameWork in baseCodeNameList)
                    {
                        baseCode = baseCodeNameWork.SectionCode;
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                        _startTime = baseCodeNameWork.SyncExecDate;
                        // 拠点コード空の以外の場合、送信処理始まります。
                        if (!string.IsNullOrEmpty(baseCode))
                        {
                            // 送信マスタ区分を取得する。
                            status = _mstUpdCountAcs.LoadMstDoDiv(_enterpriseCode, out masterDivList);
                            if (masterDivList.Count != 0)
                            {
                                // 接続先チェック処理
                                if (_mstUpdCountAcs.AutoServersCheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
                                {
                                    long beginDtLong = _startTime.Ticks;
                                    long endDtLong = System.DateTime.Now.Ticks;                                   

                                    // 送信処理
                                    status = _mstUpdCountAcs.AutoServersSendProc(_connectPointDiv, masterNameList, masterDivList, beginDtLong, endDtLong, _startTime, _enterpriseCode, string.Empty, baseCode);
                                }
                            }
                        }
                        //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                    }
                    #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
                    //// 拠点コード空の以外の場合、送信処理始まります。
                    //if (!string.IsNullOrEmpty(baseCode))
                    //{
                    //    // 送信マスタ区分を取得する。
                    //    status = _mstUpdCountAcs.LoadMstDoDiv(_enterpriseCode, out masterDivList);
                    //    if (masterDivList.Count != 0)
                    //    {
                    //        // 接続先チェック処理
                    //        if (_mstUpdCountAcs.AutoServersCheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
                    //        {
                    //            long beginDtLong = _startTime.Ticks;
                    //            long endDtLong = System.DateTime.Now.Ticks;

                    //            // 送信処理
                    //            status = _mstUpdCountAcs.AutoServersSendProc(_connectPointDiv, masterNameList, masterDivList, beginDtLong, endDtLong, _startTime, _enterpriseCode, string.Empty, baseCode);
                    //        }
                    //    }
                    //}
                    #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
                }
                else if ("1".Equals(parameter))
                {
                    // 拠点コード空の場合、受信処理始まります。
                    // 拠点情報を検索する
                    _mstUpdCountAcs.AutoSendRecvDiv = true;//ADD 2011/08/31 Redmine #24278: データ自動受信処理が起動しません
                    //status = _mstUpdCountAcs.LoadReceSyncExecDate(_enterpriseCode, out secMngSetArrList, out recBaseCodeNameList);//DEL 2011/07/25
                    //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                    status = _mstUpdCountAcs.LoadReceSyncExecDate(_enterpriseCode, out secMngSetArrList, out recBaseCodeNameList, out sndRcvHisList, out sndRcvEtrList);
                    //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<

                    //if (recBaseCodeNameList.Count == 0)//DEL 2011/07/25
                    if (sndRcvHisList.Count == 0)//ADD 2011/07/25
                    {
                        return;
                    }

                    // 接続先チェック処理
                    if (!_mstUpdCountAcs.AutoServersCheckConnect(_enterpriseCode, out _connectPointDiv, out errMsg))
                    {
                        return;
                    }

                    status = _mstUpdCountAcs.LoadReceMstName(_enterpriseCode, out recMasterNameList);
                    // 受信マスタ区分を取得する。
                    status = _mstUpdCountAcs.LoadReceMstDoDiv(_enterpriseCode, out masterDivList);
                    // 受信マスタ明細区分を取得する。
                    status = _mstUpdCountAcs.LoadReceMstDtlDoDiv(_enterpriseCode, out masterDtlDivList);
                    // 空の判断
                    bool isEmpty = false;
                    bool isNotLogOut = true;
                    // 拠点より受信処理
                    #region DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
                    //foreach (BaseCodeNameWork recBaseCodeNameWork in recBaseCodeNameList)
                    //{
                    //    recBaseCode = recBaseCodeNameWork.SectionCode;
                    //    // PM企業コードを取得する。
                    //    status = _mstUpdCountAcs.SeachPmCode(_enterpriseCode, recBaseCode, out pmCode);

                    //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        break;
                    //    }

                    //    foreach (APMSTSecMngSetWork apMSTSecMngSetWork in secMngSetArrList)
                    //    {
                    //        if (recBaseCode.Equals(apMSTSecMngSetWork.SectionCode))
                    //        {
                    //            _recStartTime = apMSTSecMngSetWork.SyncExecDate;
                    //            break;
                    //        }
                    //    }

                    //    long recBeginDtLong = _recStartTime.Ticks;
                    //    long recEndDtLong = System.DateTime.Now.Ticks;

                    //    // 自動受信処理始まります。
                    //    status = _mstUpdCountAcs.AutoServersReceProc(_enterpriseCode, recMasterNameList, masterDivList, masterDtlDivList, _connectPointDiv, recBeginDtLong, recEndDtLong, secMngSetArrList, pmCode, string.Empty, recBaseCode, out isEmpty);

                    //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        isNotLogOut = false;
                    //    }
                    //    else
                    //    {
                    //        if (!isEmpty)
                    //        {
                    //            isNotLogOut = false;
                    //        }
                    //    }
                    //}
                    #endregion DEL 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）
                    //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）----->>>>>
                    foreach (SndRcvHisWork recSndRcvHisWork in sndRcvHisList)
                    {
                        //送信元拠点コード
                        recBaseCode = recSndRcvHisWork.SectionCode;
                        //送信元企業コード
                        pmCode = recSndRcvHisWork.EnterpriseCode;
                        //送受信抽出条件履歴ログデータを取得
                        ArrayList paramList = new ArrayList();
                        foreach (SndRcvEtrWork recSndRcvEtrWork in sndRcvEtrList)
                        {
                            if (recSndRcvEtrWork.EnterpriseCode.Equals(pmCode) && recSndRcvEtrWork.SectionCode.Equals(recBaseCode)
                                && recSndRcvEtrWork.SndRcvHisConsNo == recSndRcvHisWork.SndRcvHisConsNo)
                            {
                                paramList.Add(recSndRcvEtrWork);
                            }
                        }

                        long recBeginDtLong = recSndRcvHisWork.SndObjStartDate.Ticks;
                        long recEndDtLong = recSndRcvHisWork.SndObjEndDate.Ticks;

                        // 自動受信処理始まります。
                        status = _mstUpdCountAcs.AutoServersReceProc(_enterpriseCode, recMasterNameList, masterDivList, masterDtlDivList, _connectPointDiv, recBeginDtLong, recEndDtLong, secMngSetArrList, paramList, recSndRcvHisWork, pmCode, string.Empty, recBaseCode, out isEmpty);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            isNotLogOut = false;
                        }
                        else
                        {
                            if (!isEmpty)
                            {
                                isNotLogOut = false;
                            }
                        }
                    }
                    //-----ADD 2011/07/25 馮文雄 SCM対応-拠点管理（10704767-00）-----<<<<<
                    // 全てデータを検索しない、ログを出力する。
                    if (isNotLogOut)
                    {
                        _mstUpdCountAcs.ReceLogOutProc();
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception:" + e.Message);
            }
        }
        #endregion
    }
}