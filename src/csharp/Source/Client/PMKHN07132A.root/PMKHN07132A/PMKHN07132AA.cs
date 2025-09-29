//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�}�X�^�i�G�N�X�|�[�g�j�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���[�J�[�}�X�^�i�G�N�X�|�[�g�j�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�J�[�}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br></br>
    /// </remarks>
    public class MakerSetExpAcs
    {

        private static bool _isLocalDBRead = false;

        private MakerAcs _makerAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public MakerSetExpAcs()
        {
        }

        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }

        /// <summary>
        /// ���[�J�[�}�X�^�^�S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>	
        /// <param name="makerExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�^�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, MakerExportWork makerExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, makerExportWork);
        }

        /// <summary>
        /// ���[�J�[�}�X�^�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>	
        /// <param name="makerExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, MakerExportWork makerExportWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, makerExportWork);
        }

        /// <summary>
        /// ���[�J�[�}�X�^�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="makerExportWork">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�^�̌����������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MakerExportWork makerExportWork)
        {

            this._makerAcs = new MakerAcs();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList makerUMnts = null;

            // ����
            status = this._makerAcs.SearchAll(
                                out makerUMnts,
                                enterpriseCode);

            // ����̏ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                foreach (MakerUMnt makerUMnt in makerUMnts)
                {
                    // ���o����
                    checkstatus = DataCheck(makerUMnt, makerExportWork);
                    if (checkstatus == 0)
                    {
                        //���[�J�[���N���X�փ����o�R�s�[
                        retList.Add(CopyToMakerSetFromSecInfoSetWork(makerUMnt, enterpriseCode));

                    }
                }
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�J�[�}�X�^�^���[�N�N���X�˃��[�J�[�}�X�^�^�N���X�j
        /// </summary>
        /// <param name="makerUMnt">���[�J�[�}�X�^�^���[�N�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���[�J�[�}�X�^�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^�^���[�N�N���X���烁�[�J�[�}�X�^�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private MakerSetExp CopyToMakerSetFromSecInfoSetWork(MakerUMnt makerUMnt, string enterpriseCode)
        {

            MakerSetExp makerSetExp = new MakerSetExp();

            makerSetExp.GoodsMakerCd = makerUMnt.GoodsMakerCd;
            makerSetExp.MakerName = makerUMnt.MakerName;
            makerSetExp.MakerShortName = makerUMnt.MakerShortName;
            makerSetExp.MakerKanaName = makerUMnt.MakerKanaName;
            makerSetExp.DisplayOrder = makerUMnt.DisplayOrder;

            return makerSetExp;
        }

        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="makerUMnt">��������</param>
        /// <param name="makerExportWork">���o����</param>
        /// <returns></returns>
        /// <br>Note       : ���o�������s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.13</br>
        private int DataCheck(MakerUMnt makerUMnt, MakerExportWork makerExportWork)
        {
            int status = 0;

            // �_���폜�敪
            if (makerUMnt.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // ���i���[�J�[�R�[�h
            if (makerExportWork.GoodsMakerCdSt != 0 &&
                makerExportWork.GoodsMakerCdEd != 0)
            {
                if (makerUMnt.GoodsMakerCd < makerExportWork.GoodsMakerCdSt ||
                   makerUMnt.GoodsMakerCd > makerExportWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerExportWork.GoodsMakerCdSt != 0)
            {
                if (makerUMnt.GoodsMakerCd < makerExportWork.GoodsMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerExportWork.GoodsMakerCdEd != 0)
            {
                if (makerUMnt.GoodsMakerCd > makerExportWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            // �񋟃f�[�^�敪

            return status;
        }
    }
}
