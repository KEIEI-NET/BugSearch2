//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌ɗ������݌ɐ��ݒ�
// �v���O�����T�v   : �݌Ƀ}�X�^�̌��݌ɐ������ɁA�݌ɗ����f�[�^�̐��������݌ɐ����Čv�Z���X�V����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� :
// �C �� ��              �C�����e :
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �݌ɗ������݌ɐ��ݒ�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɗ������݌ɐ��ݒ�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    public class StockHistoryUpdateAcs
    {
        # region �� Constructor ��
        /// <summary>
        /// �݌ɗ������݌ɐ��ݒ�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌ɗ������݌ɐ��ݒ�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public StockHistoryUpdateAcs()
        {
            // �f�[�^�N���A�����C���^�t�F�[�X
            this._iStockHistoryUpdateDB = (IStockHistoryUpdateDB)MediationStockHistoryUpdateDB.GetStockHistoryUpdateDB();
        }
        # endregion �� Constructor ��

        #region �� Const Memebers ��
        // ��ʋ@�\ID
        private const string PROGRAM_ID = "PMZAI09152A";
        // ��ʋ@�\����
        private const string PROGRAM_NAME = "�݌ɗ������݌ɐ��ݒ�";
        #endregion �� Const Memebers ��

        # region �� Private Members ��

        // �݌ɗ������݌ɐ��ݒ�DB�C���^�[�t�F�[�X
        private IStockHistoryUpdateDB _iStockHistoryUpdateDB;

        # endregion �� Private Members ��

        #region �� Private Method
        #region �� �݌ɗ����X�V����
        #region �� �X�V����
        /// <summary>
        /// �݌ɗ����X�V����
        /// </summary>
        /// <param name="stockHistoryExtractInfo">�݌ɗ������݌ɐ��ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �݌ɗ����X�V�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public int Update(StockHistoryExtractInfo stockHistoryExtractInfo, out string errMsg)
        {
            return this.UpdateProc(stockHistoryExtractInfo, out errMsg);
        }

        /// <summary>
        ///�݌ɗ����X�V����
        /// </summary>
        /// <param name="stockHistoryExtractInfo">�݌ɗ������݌ɐ��ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �݌ɗ����X�V�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private int UpdateProc(StockHistoryExtractInfo stockHistoryExtractInfo, out string errMsg)
        {
            // �S�ăe�[�u��������̏��
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ���엚�����O��`
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            // StockHistoryExtractInfo-->StockHistoryUpdateWork����
            StockHistoryUpdateWork paraWork = this.CopyToWorkFromExtractInfo(stockHistoryExtractInfo);

            errMsg = string.Empty;
            // Remote�폜����
            // �����R�[�h��0�F�������N���A
            try
            {
                status = this._iStockHistoryUpdateDB.ReCount(paraWork);

                // ���엚�����O�̏�������
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                    operationHistoryLog.WriteOperationLog(
                        this,
                        System.DateTime.Now,
                        LogDataKind.SystemLog,
                        PROGRAM_ID,
                        PROGRAM_NAME,
                        string.Empty,
                        0,
                        0,
                        "����I�����܂����B",
                        string.Empty);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                else
                {
                    errMsg = "�������ɃG���[���������܂����B(" + status.ToString() + ")";

                    operationHistoryLog.WriteOperationLog
                        (this,
                        System.DateTime.Now,
                        LogDataKind.SystemLog,
                        PROGRAM_ID,
                        PROGRAM_NAME,
                        string.Empty,
                        0,
                        0,
                        "�G���[���������܂����B(" + status.ToString() + ")",
                        string.Empty);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
        #endregion �� �݌ɗ����X�V����

        /// <summary>
        ///StockHistoryExtractInfo-->StockHistoryUpdateWork����
        /// </summary>
        /// <param name="stockHistoryExtractInfo">�݌ɗ������݌ɐ��ݒ�f�[�^�N���X</param>
        /// <returns>StockHistoryUpdateWork</returns>
        /// <remarks>
        /// <br>Note       : StockHistoryExtractInfo-->StockHistoryUpdateWork�������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private StockHistoryUpdateWork CopyToWorkFromExtractInfo(StockHistoryExtractInfo stockHistoryExtractInfo)
        {
            StockHistoryUpdateWork work = new StockHistoryUpdateWork();

            work.EnterpriseCode = stockHistoryExtractInfo.EnterpriseCode;
            work.AddUpYearMonth = stockHistoryExtractInfo.AddUpYearMonthSt;

            return work;
        }
        #endregion �� Private Method
    }
}
