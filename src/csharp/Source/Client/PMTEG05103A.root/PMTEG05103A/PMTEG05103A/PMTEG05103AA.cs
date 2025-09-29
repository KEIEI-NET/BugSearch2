//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ώ�`��������
// �v���O�����T�v   : ���ώ�`���������A�N�Z�X�N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
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
    /// ���ώ�`��������
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ώ�`�����̏������s���B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    public class SettlementBillDelAcs
    {
        #region �� Const Memebers
        private const string PROGRAM_ID = "PMTEG05103A";
        private const string PROGRAM_NAME = "���ώ�`��������";
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private SettlementBillDelAcs()
        {
            // �ϐ�������
            this._isettlementBillDelDB = MediationSettlementBillDelDB.GetSettlementBillDelDB();
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>
        /// ���ώ�`���������A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>���ώ�`���������A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>		
        /// <br>Note		: ���ώ�`���������A�N�Z�X�N���X �C���X�^���X�������s���B</br>
        /// <br>Programmer	: ���`</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        public static SettlementBillDelAcs GetInstance()
        {
            if (_settlementBillDelAcs == null)
            {
                _settlementBillDelAcs = new SettlementBillDelAcs();
            }

            return _settlementBillDelAcs;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static SettlementBillDelAcs _settlementBillDelAcs;
        ISettlementBillDelDB _isettlementBillDelDB;
        # endregion

        // ===================================================================================== //
        // �p�u���b�N�C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��public Methods

        /// <summary>
        /// ���ώ�`��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="processDate">������</param>
        /// <param name="prevTotalMonth">�O���������</param>
        /// <param name="billDiv">��`�敪0:����`;1:�x����`</param>
        /// <param name="pieceDelete">�폜����</param>
        /// <param name="totalpiece">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: ���ώ�`�����������s���B</br>
        /// <br>Programmer	: ���`</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        public int SettlementBillDelProc(string enterpriseCode, int processDate, int prevTotalMonth, int billDiv, out int pieceDelete, out int totalpiece)
        {
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;
            int status = this._isettlementBillDelDB.SettlementBillDelProc(enterpriseCode, processDate, prevTotalMonth, billDiv, out pieceDelete, out totalpiece);

            // ����I���̏ꍇ�F����I�����܂����B
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                // �����̃t�H�[�}�b�g��ZZZ,ZZZ,ZZ9
                string totalpieceStr = string.Format("{0:N}", totalpiece);
                string pieceDeleteStr = string.Format("{0:N}", pieceDelete);
                logStr = "����I�����܂����A���o�����F" + totalpieceStr.Substring(0, totalpieceStr.Length - 3) + " �폜�����F" + pieceDeleteStr.Substring(0, pieceDeleteStr.Length - 3);
            }
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
