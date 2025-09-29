//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �O�H�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601191-00 �쐬�S�� : �я���
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//                                 �y�v��No.6�zUOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �O�H�񓚃f�[�^�捞�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O�H�񓚃f�[�^�捞�����̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �я���</br>
    /// <br>Date       : 2010/04/21</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class UOEOrderDtlMitsubishiAcs
    {
        # region -- �v���C�x�[�g�ϐ� --
        private MitsubishiWebUOEOrderDtlInfoBuilder _mitsubishiWebUOEOrderDtlInfoBuilder;
        # endregion

        # region -- �v���C�x�[�g�萔 --
        private const string COMMASSEMBLY_ID = "0302";
        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public UOEOrderDtlMitsubishiAcs()
        {
            this._mitsubishiWebUOEOrderDtlInfoBuilder = new MitsubishiWebUOEOrderDtlInfoBuilder();
        }
        # endregion

        # region -- �������� --
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="answerDateMitsubishiPara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : RCV�����擾��������B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoSearch(AnswerDateMitsubishiPara answerDateMitsubishiPara, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ��������
            status = this._mitsubishiWebUOEOrderDtlInfoBuilder.DoSearch(answerDateMitsubishiPara, out errMessage);

            return status;
        }
        # endregion

        # region -- �m�菈�� --
        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <param name="answerDateMitsubishiPara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : �m�菈������B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoConfirm(AnswerDateMitsubishiPara answerDateMitsubishiPara, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �m�菈��
            status = this._mitsubishiWebUOEOrderDtlInfoBuilder.DoConfirm(answerDateMitsubishiPara, out errMessage);

            return status;
        }
        # endregion �m�菈��

        # region -- �L���b�V������ --
        /// <summary>
        /// ������̎Z�o
        /// </summary>
        /// <param name="outUOESupplierlilst">UOE������}�X�^Info</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���O�C�����_</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������̎Z�o�������s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ������̎Z�o
            status = this._mitsubishiWebUOEOrderDtlInfoBuilder.GetUOESupplier(out outUOESupplierlilst, enterpriseCode, sectionCode, COMMASSEMBLY_ID);

            return status;
        }
        # endregion

        #region -- �i���\�� --
        /// <summary>�i���\���p�t�H�[�����擾�܂��͐ݒ肵�܂��B</summary>
        public SFCMN00299CA ProgressForm
        {
            get { return _mitsubishiWebUOEOrderDtlInfoBuilder.ProgressForm; }
            set { _mitsubishiWebUOEOrderDtlInfoBuilder.ProgressForm = value; }
        }
        #endregion

        # region -- DataTable�̏��� --
        /// <summary>
        /// ��������
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>
        /// <br>Note       : �������ʂ����擾�B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        public DataTable DetailDataTable
        {
            get { return this._mitsubishiWebUOEOrderDtlInfoBuilder.DetailDataTable; }
        }

        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�N���A�������s���܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        public void DataTableClear()
        {
            this._mitsubishiWebUOEOrderDtlInfoBuilder.DataTableClear();
        }
        # endregion
    }
}
