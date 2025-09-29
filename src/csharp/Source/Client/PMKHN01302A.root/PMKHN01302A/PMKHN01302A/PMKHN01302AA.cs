//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d����ϊ��c�[��
// �v���O�����T�v   : ���i�Ǘ����}�X�^�̍œK���ׁ̈A�s�v�ȃ��R�[�h���폜����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/07/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
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
    /// �d����ϊ�����
    /// </summary>
    /// <remarks>
    /// Note       : �d����ϊ������ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009/07/13<br />
    /// </remarks>
    public class SupplierChangeAcs
    {
        #region �� Const Memebers
        private const string PROGRAM_ID = "PMKHN01300U";
        private const string PROGRAM_NAME = "�d����ϊ��c�[��";
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private SupplierChangeAcs()
        {
            // �ϐ�������
            this.supplierChangeProcDB = SupplierChangeToolDB.GetSupplierChangeProcDB();
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>
        /// �d����ϊ��A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�d����ϊ��ݒ�A�N�Z�X�N���X �C���X�^���X</returns>
        public static SupplierChangeAcs GetInstance()
        {
            if (_supplierChangeAcs == null)
            {
                _supplierChangeAcs = new SupplierChangeAcs();
            }

            return _supplierChangeAcs;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static SupplierChangeAcs _supplierChangeAcs;
        ISupplierChangeProcDB supplierChangeProcDB;
        # endregion

        // ===================================================================================== //
        // �p�u���b�N�C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��public Methods
        /// <summary>
        /// �d����ϊ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="readCount">��������</param>
        /// <param name="delCount">�폜����</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: �d����ϊ��������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.07.13</br>
        /// </remarks>
        public int SupplierChangeProc(string enterpriseCode, out int readCount, out int delCount)
        {
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;
            int status = this.supplierChangeProcDB.DeleteGoodsMng(enterpriseCode, out readCount, out delCount);
            // ����I���̏ꍇ�F����I�����܂����B ���o�����F�����[�g����̒��o���� �폜�����F�����[�g����̍폜����
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                logStr = "����I�����܂����B ���o�����F" + this.IntConvert(readCount) + " �폜�����F" + this.IntConvert(delCount);
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
            }
            // �G���[�̏ꍇ�F�G���[���������܂����B
            else
            {
                logStr = "�G���[���������܂����B";
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
            }

            return status;
        }

        /// <summary>
        /// �����t�H�[�}�b�g�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �����t�H�[�}�b�g�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.07.13</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            return searchCount.ToString("N0");
        }
        # endregion

    }
}
