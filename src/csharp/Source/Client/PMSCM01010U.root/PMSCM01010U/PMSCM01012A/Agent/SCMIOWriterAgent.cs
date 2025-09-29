//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/07/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� ��
// �� �� ��  2011/02/09  �C�����e : �E�ǂݍ��ݏ����̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
// 2011/02/09 Add >>>
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
// 2011/02/09 Add <<<

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// SCM I/O Writer�̑㗝�l�N���X
    /// </summary>
    public static class SCMIOWriterAgent
    {
        /// <summary>IOWriter��writemode 0:Insert(�X�V����R�ݒ�) 1:�ʏ탂�[�h(�X�V����UI�ݒ�BUpdate����)</summary>
        private const int WRITE_MODE = 1;

        /// <summary>
        /// �����݂܂��B
        /// </summary>
        /// <param name="writingList">������SCM�󒍌n�f�[�^</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        public static KeyValuePair<int, object> Write(CustomSerializeArrayList writingList)
        {
            #region <Guard Phrase>

            if (ListUtil.IsNullOrEmpty(writingList))
            {
                return new KeyValuePair<int, object>((int)ResultUtil.ResultCode.Normal, writingList);
            }

            #endregion // <Guard Phrase>

            // 1�p����
            object retScmCsObj = writingList;

            IIOWriteScmDB scmIOWriter = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
            {
                int status = scmIOWriter.ScmWrite(ref retScmCsObj, WRITE_MODE);
                {
                }
                return new KeyValuePair<int, object>(status, retScmCsObj);
            }
        }

        // 2011/02/09 Add >>>

        // ----- UPD 2011/08/10 ----- >>>>>
        //public static int Read(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList)
        //{
        //    return ReadProc(scmReadWork,out scmHeaderWork,out scmCarWork,out scmDetailWorkList,out scmAnswerWorkList);
        //}

        /// <summary>
        /// SCM�����擾���܂��B
        /// </summary>
        /// <param name="scmReadWork">SCMRead�f�[�^</param>
        /// <param name="scmHeaderWork">SCM�󒍃f�[�^</param>
        /// <param name="scmCarWork">SCM�󒍃f�[�^(�ԗ����)�f�[�^</param>
        /// <param name="scmDetailWorkList">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��X�g</param>
        /// <param name="scmAnswerWorkList">SCM�󒍖��׃f�[�^(��)�̃��X�g</param>
        /// <param name="scmAcOdSetDtWorkList">SCM�Z�b�g���i�f�[�^�̃��X�g</param>
        /// <returns></returns>
        public static int Read(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList, out List<SCMAcOdSetDtWork> scmAcOdSetDtWorkList)
        {
            return ReadProc(scmReadWork, out scmHeaderWork, out scmCarWork, out scmDetailWorkList, out scmAnswerWorkList, out scmAcOdSetDtWorkList);
        }
        // ----- UPD 2011/08/10 ----- <<<<<

        /// <summary>
        /// SCM�����擾���܂��B
        /// </summary>
        /// <param name="scmReadWork">SCMRead�f�[�^</param>
        /// <param name="scmHeaderWork">SCM�󒍃f�[�^</param>
        /// <param name="scmCarWork">SCM�󒍃f�[�^(�ԗ����)�f�[�^</param>
        /// <param name="scmDetailWorkList">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��X�g</param>
        /// <param name="scmAnswerWorkList">SCM�󒍖��׃f�[�^(��)�̃��X�g</param>
        /// <param name="scmAcOdSetDtWorkList">SCM�Z�b�g���i�f�[�^�̃��X�g</param>
        /// <returns></returns>
        // ----- UPD 2011/08/10 ----- >>>>>
        //private static int ReadProc(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList)
        private static int ReadProc(IOWriteSCMReadWork scmReadWork, out SCMAcOdrDataWork scmHeaderWork, out SCMAcOdrDtCarWork scmCarWork, out List<SCMAcOdrDtlIqWork> scmDetailWorkList, out List<SCMAcOdrDtlAsWork> scmAnswerWorkList, out List<SCMAcOdSetDtWork> scmAcOdSetDtWorkList)
        // ----- UPD 2011/08/10 ----- <<<<<
        {
            scmHeaderWork = null;
            scmCarWork = null;
            scmDetailWorkList = null;
            scmAnswerWorkList = null;
            scmAcOdSetDtWorkList = null; // ADD 2011/08/10
            object retSCMScObj = new CustomSerializeArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            IIOWriteScmDB scmIOWriter = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
            {

                status = scmIOWriter.ScmRead(ref retSCMScObj, (object)scmReadWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ----- UPD 2011/08/10 ----- >>>>>
                    //IOWriterUtil.ExpandSCMReadRet(retSCMScObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmCarWork);
                    IOWriterUtil.ExpandSCMReadRet(retSCMScObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmAcOdSetDtWorkList, out scmCarWork);
                    // ----- UPD 2011/08/10 ----- <<<<<
                }
            }
            return status;
        }
        // 2011/02/09 Add <<<
    }
}
