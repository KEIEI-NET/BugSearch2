//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : ������
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �}�c�_�񓚃f�[�^�捞�����A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �}�c�_�񓚃f�[�^�捞�����̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class UOEOrderDtlMazdaAcs
    {
        # region -- �v���C�x�[�g�ϐ� --
        /*----------------------------------------------------------------------------------*/
        private MazdaWebUOEOrderDtlInfoBuilder _mazdaWebUOEOrderDtlInfoBuilder;
        # endregion

        # region -- �v���C�x�[�g�萔 --
        /*----------------------------------------------------------------------------------*/
        private const string COMMASSEMBLY_ID = "0403";
        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�t���C���Ή�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public UOEOrderDtlMazdaAcs()
        {
            this._mazdaWebUOEOrderDtlInfoBuilder = new MazdaWebUOEOrderDtlInfoBuilder();
        }
        # endregion

        # region -- �������� --
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="answerDateMazdaPara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : MLG�����擾��������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoSearch(AnswerDateMazdaPara answerDateMazdaPara, out string errMessage)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ��������
            status = this._mazdaWebUOEOrderDtlInfoBuilder.DoSearch(answerDateMazdaPara, out errMessage);

            return status;
        }
        # endregion

        # region -- �m�菈�� --
        /// <summary>
        /// �m�菈��
        /// </summary>
        /// <param name="answerDateMazdaPara">��ʏ��</param>
        /// <param name="errMessage">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁB�@0�F����G�@-1�F�ُ�</returns>
        /// <remarks>
        /// <br>Note       : �m�菈������B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>UpdateNote : </br>
        /// </remarks>
        public int DoConfirm(AnswerDateMazdaPara answerDateMazdaPara, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �m�菈��
            status = this._mazdaWebUOEOrderDtlInfoBuilder.DoConfirm(answerDateMazdaPara, out errMessage);

            // �m�菈����ɔ����񓚃t�@�C�����폜
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // �w�肵���t�@�C�����폜���܂��B�w�肵���t�@�C�������݂��Ȃ��ꍇ�A��O�̓X���[����܂���B
                File.Delete(answerDateMazdaPara.AnswerSaveFolder + "\\HATTU.MLG");
            }

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
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public int GetUOESupplier(out ArrayList outUOESupplierlilst, string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ������̎Z�o
            status = this._mazdaWebUOEOrderDtlInfoBuilder.GetUOESupplier(out outUOESupplierlilst, enterpriseCode, sectionCode, COMMASSEMBLY_ID);

            return status;
        }
        # endregion

        #region -- �i���\�� --
        /// <summary>�i���\���p�t�H�[�����擾�܂��͐ݒ肵�܂��B</summary>
        public SFCMN00299CA ProgressForm
        {
            get { return _mazdaWebUOEOrderDtlInfoBuilder.ProgressForm; }
            set { _mazdaWebUOEOrderDtlInfoBuilder.ProgressForm = value; }
        }
        #endregion

        # region -- DataTable�̏��� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��������
        /// </summary>
        /// <value>DetailDataTable</value>
        /// <remarks>
        /// <br>Note       : �������ʂ����擾�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public DataTable DetailDataTable
        {
            get { return this._mazdaWebUOEOrderDtlInfoBuilder.DetailDataTable; }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�N���A�������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public void DataTableClear()
        {
            this._mazdaWebUOEOrderDtlInfoBuilder.DataTableClear();
        }
        # endregion
    }
}
