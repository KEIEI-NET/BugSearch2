//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM�f�[�^��M�����N���A�N�Z�X�N���X
// �v���O�����T�v   : SCM�f�[�^��M�����N�������[�g�ɃA�N�Z�X����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/05/20  �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �� �� ��  2010/07/30  �C�����e : �N���C�A���g�A�Z���u���̎�M�������N������悤�ɕύX
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

using System.Diagnostics; // 2010/07/30

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM�f�[�^��M�����N���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/05/20</br>
    /// <br>----------------------------------------------------------------------------</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class SCMDtRcveExecAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2010/05/20</br>
        /// </remarks>
        public SCMDtRcveExecAcs()
        {
        }
        #endregion

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //
        # region Const Members

        #region delegate
        //>>>2010/07/30
        /// <summary>
        /// �N���p�����[�^�擾�f���Q�[�g
        /// </summary>
        /// <param name="param"></param>
        public delegate void GetStartParameterEventHandler(out string param);
        //<<<2010/07/30
        #endregion

        #region Events
        //>>>2010/07/30
        public GetStartParameterEventHandler GetStartParameterEvent;
        //<<<2010/07/30
        #endregion

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region �� Private Member

        private ISCMDtRcveExecDB _iSCMDtRcveExecDB =null;

        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region �� Public Method

        /// <summary>
        /// �f�[�^��M����
        /// </summary>
        /// <param name="wait">True:��M�����̏I����҂�</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        public int DataReceive(bool wait, out string errMsg)
        {
            errMsg = string.Empty;

            //>>>2010/07/30
            //if (_iSCMDtRcveExecDB == null) _iSCMDtRcveExecDB = (ISCMDtRcveExecDB)MediationSCMDtRcveExecDB.GetSCMDtRcveExecDB();

            //int status = _iSCMDtRcveExecDB.ExecuteDataReceive(wait);

            int status = this.ExecuteDataReceive(wait);
            //<<<2010/07/30

            if (status != 0) errMsg = "��M�ŃG���[���������܂���";

            return status;
        }

        //>>>2010/07/30
        /// <summary>
        /// �f�[�^��M���������s���܂�
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : SCM�f�[�^��M���������s���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/05/19</br>
        /// </remarks>
        public int ExecuteDataReceive(bool wait)
        {
            return this.ExecuteDataReceiveProc(wait);
        }
        //<<<2010/07/30

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region �� Private Method

        //>>>2010/07/30
        /// <summary>
        /// �f�[�^��M���������s���܂�
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        private int ExecuteDataReceiveProc(bool wait)
        {
            try
            {
                string dir = this.GetTargetDir();
                if (string.IsNullOrEmpty(dir) || !System.IO.Directory.Exists(dir))
                {
                    return -1;
                }

                string path = System.IO.Path.Combine(dir, "PMSCM01000U.exe");

                if (!System.IO.File.Exists(path)) return -2;

                string param;
                this.GetStartParameterDelegateCall(out param);

                if (!string.IsNullOrEmpty(param))
                {
                    Process pr = Process.Start(path, param);

                    if (wait) pr.WaitForExit();
                }
                else
                {
                    return -1;
                }

                return 0;
            }
            catch (Exception ex)
            {
                return -999;
            }
        }

        /// <summary>
        /// �Ώۃf�B���N�g���̂��擾���܂�
        /// </summary>
        /// <returns>�J�����g�f�B���N�g��</returns>
        private string GetTargetDir()
        {
            string dir = string.Empty;

            dir = System.IO.Directory.GetCurrentDirectory();

            return dir;
        }

        /// <summary>
        /// �N���p�����[�^�擾�f���Q�[�g�R�[��
        /// </summary>
        /// <param name="param"></param>
        private void GetStartParameterDelegateCall(out string param)
        {
            param = string.Empty;
            if (this.GetStartParameterEvent != null)
            {
                this.GetStartParameterEvent(out param);
            }
        }
        //<<<2010/07/30

        #endregion

    }
}
