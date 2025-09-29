//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ꊇ���A���X�V
// �v���O�����T�v   : �ꊇ���A���X�V�A�N�Z�X�N���X�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
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
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ꊇ���A���X�V����
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ꊇ���A���X�V�����ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    public class AllRealUpdToolAcs
    {
        #region �� Const Memebers
        private const string PROGRAM_ID = "PMKHN09270U";
        private const string PROGRAM_NAME = "�ꊇ���A���X�V";
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private AllRealUpdToolAcs()
        {
            // �ϐ�������
            this._iAllRealUpdToolDB = AllRealUpdToolDB.GetAllRealUpdToolDB();
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>
        /// �ꊇ���A���X�V�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�ꊇ���A���X�V�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>		
        /// <br>Note		: �ꊇ���A���X�V�A�N�Z�X�N���X �C���X�^���X�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        public static AllRealUpdToolAcs GetInstance()
        {
            if (_allRealUpdToolAcs == null)
            {
                _allRealUpdToolAcs = new AllRealUpdToolAcs();
            }

            return _allRealUpdToolAcs;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static AllRealUpdToolAcs _allRealUpdToolAcs;
        IAllRealUpdToolDB _iAllRealUpdToolDB;
        # endregion

        // ===================================================================================== //
        // �p�u���b�N�C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��public Methods
        /// <summary>
        /// �ꊇ���A���X�V����
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">���ハ�[�N</param>
        /// <param name="mTtlStockUpdParaWork">�d�����[�N</param>
        /// <param name="procDiv">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: �ꊇ���A���X�V�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009/12/24</br>
        /// </remarks>
        public int AllRealUpdToolProc(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, MTtlStockUpdParaWork mTtlStockUpdParaWork, int procDiv)
        {
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;
            string procDivStr = string.Empty;
            string sectionSt = string.Empty;
            string sectionEd = string.Empty;
            int status = this._iAllRealUpdToolDB.AllRealUpdProc(mTtlSalesUpdParaWork, mTtlStockUpdParaWork, procDiv);

            // �����敪
            if (procDiv == 0)
            {
                procDivStr = "����";
            }
            else if (procDiv == 1)
            {
                procDivStr = "�d��";
            }
            else if (procDiv == 2)
            {
                procDivStr = "����A�d��";
            }
            else
            {
                // �����敪�s��
            }
            // ���_
            if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt))
            {
                sectionSt = mTtlSalesUpdParaWork.AddUpSecCodeSt;
            }
            else
            {
                sectionSt = "00";
            }

            // ���_
            if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
            {
                sectionEd = mTtlSalesUpdParaWork.AddUpSecCodeEd;
            }
            else
            {
                sectionEd = "99";
            }

            // ����I���̏ꍇ�F����I�����܂����B
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                logStr = "����I�����܂����B �敪�F" + procDivStr + " ���_�F" + sectionSt + "�`" + sectionEd + " �Ώ۔N���F"
                    + mTtlSalesUpdParaWork.AddUpYearMonthSt.ToString() + "�`" + mTtlSalesUpdParaWork.AddUpYearMonthEd.ToString();

                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
            }
            // �G���[�̏ꍇ�F�G���[���������܂����B
            else
            {
                logStr = "�G���[���������܂����B�i" + status.ToString() + "�j  �敪�F" + procDivStr + " ���_�F" + sectionSt + "�`" + sectionEd + " �Ώ۔N���F"
                    + mTtlSalesUpdParaWork.AddUpYearMonthSt.ToString() + "�`" + mTtlSalesUpdParaWork.AddUpYearMonthEd.ToString();
                operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
            }

            return status;
        }
        # endregion
    }
}
