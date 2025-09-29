//****************************************************************************//
// �V�X�e��         :  PM.NS
// �v���O��������   �F �����񓚏����A�N�Z�X
// �v���O�����T�v   �F 
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �� �� ��  2011/05/25  �C�����e : �V�K�쐬
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
        private const string MY_NAME = "SCMWebAcsAgent";    // ���O�p

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMWebAcsAgentForCnctSet() : base() { }

        #endregion // </Constructor>

        #region <���O>

        /// <summary>���K�[</summary>
        private ILogable _logger;
        /// <summary>���K�[���擾�܂��͐ݒ肵�܂��B</summary>
        public ILogable Logger
        {
            get { return _logger; }
            set { _logger = value; }
        }

        /// <summary>
        /// ���O�������݂܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        private void WriteLog(string msg)
        {
            if (Logger == null) return;

            Logger.WriteLog(msg);
        }

        #endregion // </���O>

        /// <summary>
        /// PM�w�����ԍ��戵�敪�擾����
        /// </summary>
        /// <param name="orgEpCd"></param>
        /// <param name="orgSecCd"></param>
        /// <param name="pmInstNoHdlDivCd"></param>
        /// <returns></returns>
        public int ReadScmCnctSet(string orgEpCd, string orgSecCd, out short pmInstNoHdlDivCd)
        {
            const string METHOD_NAME = "ReadScmCnctSet()"; // ���O�p

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
