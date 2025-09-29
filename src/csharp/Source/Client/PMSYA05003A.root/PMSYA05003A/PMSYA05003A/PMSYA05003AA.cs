//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �Ԍ������X�V
// �v���O�����T�v   : �Ԍ������X�V�A�N�Z�X�N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
/// Update Note : 2010.05.18 zhangsf Redmine #7772�̑Ή�
///             : �E�Ԍ������X�V�^���엚���f�[�^�̍X�V�p�^�[���̒ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �Ԍ������X�V����
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԍ������X�V�����ł��B</br>
    /// <br>Programmer : ���C��</br>
    /// <br>Date       : 2010/04/21</br>
    /// </remarks>
    public class InspectDateUpdAcs
    {
        #region �� Const Memebers
        private const string PROGRAM_ID = "PMSYA05000U";
        private const string PROGRAM_NAME = "�Ԍ������X�V";
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private InspectDateUpdAcs()
        {
            // �ϐ�������
            this._iinspectDateUpdDB = MediationInspectDateUpdDB.GetInspectDateUpdDB();
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>
        /// �Ԍ������X�V�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�Ԍ������X�V�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>		
        /// <br>Note		: �Ԍ������X�V�A�N�Z�X�N���X �C���X�^���X�������s���B</br>
        /// <br>Programmer	: ���C��</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        public static InspectDateUpdAcs GetInstance()
        {
            if (_inspectDateUpdAcs == null)
            {
                _inspectDateUpdAcs = new InspectDateUpdAcs();
            }

            return _inspectDateUpdAcs;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static InspectDateUpdAcs _inspectDateUpdAcs;
        IInspectDateUpdDB _iinspectDateUpdDB;
        # endregion

        // ===================================================================================== //
        // �p�u���b�N�C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��public Methods
        /// <summary>
        /// �Ԍ������X�V����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="updateDate">�X�V�N��</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: �Ԍ������X�V�������s���B</br>
        /// <br>Programmer	: ���C��</br>	
        /// <br>Date		: 2010/04/21</br>
        /// </remarks>
        public int InspectDateUpdProc(string enterpriseCode, int updateDate)
        {
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;
            int searchNum;
            int updNum;
            int status = this._iinspectDateUpdDB.InspectDateUpdProc(enterpriseCode, updateDate, out searchNum, out updNum);

            // ����I���̏ꍇ�F����I�����܂����B
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                // �����̃t�H�[�}�b�g��ZZZ,ZZZ,ZZ9
                string searchNumStr = string.Format("{0:N}", searchNum);
                string updNumStr = string.Format("{0:N}", updNum);
                logStr = "����I�����܂����B ���o�����F" + searchNumStr.Substring(0, searchNumStr.Length - 3) + " �X�V�����F" + updNumStr.Substring(0, updNumStr.Length - 3);
            }
            // ADD 2010.05.18 zhangsf FOR Redmine #7772 *-------------------->>>
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                logStr = "�Y���f�[�^������܂���B";
            }
            // ADD 2010.05.18 zhangsf FOR Redmine #7772 <<<--------------------*
            // �G���[�̏ꍇ�F�G���[���������܂����B
            else
            {
                logStr = "�G���[���������܂����B";
            }

            operationHistoryLog.WriteOperationLog(
                    this,
                    System.DateTime.Now,
                    LogDataKind.SystemLog,
                    PROGRAM_ID,
                    PROGRAM_NAME,
                    string.Empty,
                    0,
                    0,
                    logStr,
                    string.Empty);

            return status;
        }
        # endregion
    }
}
