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
// 修 正 日  2009/06/16  修正内容 : PVCS票＃158の動作ディレクトリ設定の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/06/25  修正内容 : PVCS票＃282の動作ディレクトリ設定の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/25  修正内容 : SCM対応‐拠点管理（10704767-00）
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
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 送信処理自起動
    /// </summary>
    public partial class PMKYO01050UA : Form
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region [ Private Member ]
        private UpdateCountInputAcs _updateCountInputAcs;
        //private string _loginEmplooyCode = LoginInfoAcquisition.Employee.EmployeeCode;
        // 企業コード
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        // 接続先区分
        private int _connectPointDiv = 0;

        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructors
        /// <summary>
        /// 送信データフォームクラス デフォルトコンストラクタ
        /// </summary>
        public PMKYO01050UA()
        {
            // 初期化処理
            InitializeComponent();
            this._updateCountInputAcs = UpdateCountInputAcs.GetInstance();
            _connectPointDiv = 0;
        }
        #endregion

        #region [ 配信連動自動マージ処理 ]
        internal void MergeOfferToUser()
        {
            try
            {
                //DateTime _startTime = new DateTime(); //Del 2011/09/06 zhujc
                string baseCode = string.Empty;
                bool isEmpty = false;
				ArrayList secMngSetWorkList = new ArrayList();
                // 拠点情報を検索する
				//_startTime = _updateCountInputAcs.LoadProc(_enterpriseCode, out baseCode, out secMngSetWorkList); //Del 2011/09/06 zhujc
                // Add 2011/09/06 zhujc -------------->>>>>>
                int status = _updateCountInputAcs.LoadProcAuto(_enterpriseCode, out secMngSetWorkList);
                
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return;
                }
                // Add 2011/09/06 zhujc --------------<<<<<<
                //DEL 2011/09/06 zhujc --------------->>>>>>
                //if (string.IsNullOrEmpty(baseCode))
                //{
                //    return;
                //}
                //DEL 2011/09/06 zhujc ---------------<<<<<<

                // 接続先チェック処理
                string errMsg = null;
                if (!_updateCountInputAcs.CheckConnect(_enterpriseCode, true, out _connectPointDiv, out errMsg))
                {
                    // return;
                }

                //long beginDtLong = _startTime.Ticks; //Del 2011/09/06 zhujc
                long endDtLong = System.DateTime.Now.Ticks;

                // 更新処理
				// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
				//int status = _updateCountInputAcs.ServsUpdateProc(beginDtLong, endDtLong, _startTime, _enterpriseCode, string.Empty, baseCode, out isEmpty, _connectPointDiv);
				// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
				// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
                //int status = 0; //Del 2011/09/06 zhujc
				foreach (APSecMngSetWork secMngSetWork in secMngSetWorkList)
				{
					//自動データ送信の場合
                    //if (secMngSetWork.AutoSendFlg == 0) //Del 2011/09/06 zhujc
                    if (secMngSetWork.AutoSendFlg == 0 && secMngSetWork.Kind == 0) //Add 2011/09/06 zhujc
					{
                        //status = _updateCountInputAcs.ServsUpdateProc(secMngSetWork.SyncExecDate.Ticks, endDtLong, _startTime, _enterpriseCode, string.Empty, secMngSetWork.SectionCode.Trim(), secMngSetWork.SendDestSecCode.Trim(), out isEmpty, _connectPointDiv); //Del 2011/09/06 zhujc
                        status = _updateCountInputAcs.ServsUpdateProc(secMngSetWork.SyncExecDate.Ticks, endDtLong, secMngSetWork.SyncExecDate, _enterpriseCode, string.Empty, secMngSetWork.SectionCode.Trim(), secMngSetWork.SendDestSecCode.Trim(), out isEmpty, _connectPointDiv); // Add 2011/09/06 zhujc
					}
				}
                // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
                
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
    }
}