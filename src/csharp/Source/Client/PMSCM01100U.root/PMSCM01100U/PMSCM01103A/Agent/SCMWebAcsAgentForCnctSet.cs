//****************************************************************************//
// システム         :  PM.NS
// プログラム名称   ： 自動回答処理アクセス
// プログラム概要   ： 
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2011/05/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
#define _LOCAL_DEBUG_

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using System.Windows;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller.Agent
{
#if DEBUG
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;
#else
    using WebHeaderRecordType = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType = Broadleaf.Application.UIData.ScmOdDtAns;
#endif

    using RealAccesserType  = ScmCnctSetAcs2;
    using RecordType        = Broadleaf.Application.UIData.ScmOdrData;

    /// <summary>
    /// SCMWebAcsAgentForCnctSet
    /// </summary>
    public class SCMWebAcsAgentForCnctSet : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCMWebAcsAgent";    // ログ用

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMWebAcsAgentForCnctSet() : base() { }

        #endregion // </Constructor>

        #region <ログ>

        /// <summary>ロガー</summary>
        private ILogable _logger;
        /// <summary>ロガーを取得または設定します。</summary>
        public ILogable Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        /// <summary>
        /// ログを書込みます。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        private void WriteLog(string msg)
        {
            if (Logger == null) return;

            Logger.WriteLog(msg);
        }

        #endregion // </ログ>

        /// <summary>
        /// PM指示書番号取扱区分取得処理
        /// </summary>
        /// <param name="orgEpCd"></param>
        /// <param name="orgSecCd"></param>
        /// <param name="pmInstNoHdlDivCd"></param>
        /// <returns></returns>
        public int ReadScmCnctSet(string orgEpCd, string orgSecCd, out short pmInstNoHdlDivCd)
        {
            const string METHOD_NAME = "ReadScmCnctSet()"; // ログ用

            ScmCnctSet retScmCnctSet;
            bool msgDiv;
            string errMsg;
            pmInstNoHdlDivCd = 0;

            int status = RealAccesser.ReadScmCnctSet(orgEpCd, orgSecCd, out retScmCnctSet, out msgDiv, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (retScmCnctSet != null)
                {
                    pmInstNoHdlDivCd = retScmCnctSet.PMInstNoHdlDivCd;
                }
            }
            return status;
        }
    }
}
