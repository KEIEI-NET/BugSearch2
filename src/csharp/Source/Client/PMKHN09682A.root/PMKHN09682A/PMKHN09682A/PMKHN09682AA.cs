//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�R���o�[�g
// �v���O�����T�v   : �݌ɊǗ��S�̐ݒ�̌��݌ɕ\���敪���A�o�׉\�����X�V����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2011/08/26  �C�����e : �A��No.1016 �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌Ƀ}�X�^�R���o�[�g����
    /// </summary>
    /// <remarks>
    /// Note       : �݌Ƀ}�X�^�R���o�[�g�����ł��B<br />
    /// Programmer : �����<br />
    /// Date       : 2011/08/26<br />
    /// </remarks>
    public class StockConvertAcs
    {
        #region �� Const Memebers
        private const string PROGRAM_ID = "PMKHN01300U";
        private const string PROGRAM_NAME = "�݌Ƀ}�X�^�R���o�[�g�c�[��";
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private StockConvertAcs()
        {
            // �ϐ�������
            this._iStockConvertDB = MediationStockConvertDB.GetStockConvertDB();
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>
        /// �݌Ƀ}�X�^�R���o�[�g�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�݌Ƀ}�X�^�R���o�[�g�ݒ�A�N�Z�X�N���X �C���X�^���X</returns>
        public static StockConvertAcs GetInstance()
        {
            if (_stockConvertAcsAcs == null)
            {
                _stockConvertAcsAcs = new StockConvertAcs();
            }

            return _stockConvertAcsAcs;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static StockConvertAcs _stockConvertAcsAcs;
        IStockConvertDB _iStockConvertDB;
        # endregion

        // ===================================================================================== //
        // �p�u���b�N�C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��public Methods
        /// <summary>
        /// �݌Ƀ}�X�^�R���o�[�g����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="preStckCntDspDiv">���݌ɕ\���敪</param>
        /// <param name="stockCount">�݌Ƀ}�X�^�@��������</param>
        /// <param name="stockAcPayHistCount">�݌Ɏ󕥗����f�[�^�@��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: �݌Ƀ}�X�^�R���o�[�g�������s���B</br>
        /// <br>Programmer	: �����</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        public int StockConvertProc(string enterpriseCode, int preStckCntDspDiv, out int stockCount, out int stockAcPayHistCount)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;

            stockCount = 0;
            stockAcPayHistCount = 0;

            try
            {
                StockConvertWork stockConvertWork = new StockConvertWork();
                stockConvertWork.EnterpriseCode = enterpriseCode;
                stockConvertWork.PreStckCntDspDiv = preStckCntDspDiv;

                object stockConvertWorkObj = (object)stockConvertWork;

                status = this._iStockConvertDB.ConvertShipmentPosCnt(stockConvertWorkObj, out stockCount, out stockAcPayHistCount);
                // ����I���̏ꍇ�F����I�����܂����B ���o�����F�����[�g����̒��o���� �폜�����F�����[�g����̍폜����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    logStr = "����I�����܂����B �݌Ƀ}�X�^�@���������F" + this.IntConvert(stockCount) + " �݌Ɏ󕥗����f�[�^�@���������F" + this.IntConvert(stockAcPayHistCount);
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
                }
                // �G���[�̏ꍇ�F�G���[���������܂����B
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    logStr = "�G���[���������܂����B";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// �����t�H�[�}�b�g�ݒ�
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �����t�H�[�}�b�g�ݒ菈�����s���B</br>
        /// <br>Programmer	: �����</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            return searchCount.ToString("N0");
        }
        # endregion

    }
}
