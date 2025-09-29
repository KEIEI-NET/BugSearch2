//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���c�`�[
// �� �� ��  2020/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���c�`�[</br>
    /// <br>Date       : 2020.02.20</br>
    /// <br></br>
    /// </remarks>
    public class MakerGoodsCodeSetAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private ISAndEMkrGdsCdChgSetDB _iSAndEMkrGdsCdChgSetDB = null;

        #endregion

        #region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// <br></br>
        /// </remarks>
        public MakerGoodsCodeSetAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iSAndEMkrGdsCdChgSetDB = (ISAndEMkrGdsCdChgSetDB)MediationSAndEMkrGdsCdChgSetDB.GetSAndEMkrGdsCdChgSetDB();
        }

        #endregion

        #region [���[�J���A�N�Z�X�p]
        /// <summary> �������[�h </summary>
        public enum SearchMode
        {
            /// <summary> ���[�J���A�N�Z�X </summary>
            Local = 0,
            /// <summary> �����[�g�A�N�Z�X </summary>
            Remote = 1
        }
        #endregion

        #region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int Write(ref SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            // UI�f�[�^�N���X�����[�N
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(sAndEMkrGdsCdChg);

            object objectSAndEMkrGdsCdChgWork = sAndEMkrGdsCdChgWork;

            int status = 0;
            int writeMode = 0;

            // �������ݏ���
            status = this._iSAndEMkrGdsCdChgSetDB.Write(ref objectSAndEMkrGdsCdChgWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                sAndEMkrGdsCdChgWork = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // �N���X�������o�R�s�[
                sAndEMkrGdsCdChg = CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(sAndEMkrGdsCdChgWork);
            }

            return status;
        }

        #endregion

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int LogicalDelete(ref SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(sAndEMkrGdsCdChg);

            object objectSAndEMkrGdsCdChgWork = sAndEMkrGdsCdChgWork;

            //  ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���_���폜
            int status = this._iSAndEMkrGdsCdChgSetDB.LogicalDelete(ref objectSAndEMkrGdsCdChgWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                sAndEMkrGdsCdChgWork = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // �N���X�������o�R�s�[
                sAndEMkrGdsCdChg = CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(sAndEMkrGdsCdChgWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int Delete(SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(sAndEMkrGdsCdChg);

            // XML�֕ϊ����A������̃o�C�i����
            object objectSAndEMkrGdsCdChgWork = sAndEMkrGdsCdChgWork;

            // ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^��񕨗��폜
            int status = this._iSAndEMkrGdsCdChgSetDB.Delete(ref objectSAndEMkrGdsCdChgWork);

            return status;
        }

        #endregion

        #region -- ������������� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
        ///���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>  
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevSAndEMkrGdsCdChg">�O�񃁁[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SAndEMkrGdsCdChg prevSAndEMkrGdsCdChg, SearchMode searchMode)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = new SAndEMkrGdsCdChgWork();

            if (prevSAndEMkrGdsCdChg != null)
            {
                sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(prevSAndEMkrGdsCdChg);
            }

            sAndEMkrGdsCdChgWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();

            ArrayList sAndEMkrGdsCdChgWorkList = new ArrayList();

            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            // ���f�[�^�L��������
            nextData = false;

            object paraobj = sAndEMkrGdsCdChgWork;
            object retobj = null;

            status = this._iSAndEMkrGdsCdChgSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sAndEMkrGdsCdChgWorkList = retobj as ArrayList;

                if (sAndEMkrGdsCdChgWorkList == null)
                {
                    return status;
                }

                foreach (SAndEMkrGdsCdChgWork wkSAndEMkrGdsCdChgWork in sAndEMkrGdsCdChgWorkList)
                {
                    retList.Add(CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(wkSAndEMkrGdsCdChgWork));
                }

                // �Ǎ��Ώۃf�[�^��������ArrayList�̌���
                retTotalCnt = retList.Count;
            }

            // STATUS ��ݒ�
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0)
            {
                retTotalCnt = retList.Count;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�_���폜��������
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�̕������s���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int Revival(ref SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(sAndEMkrGdsCdChg);

            // XML�֕ϊ����A������̃o�C�i����
            object objectSAndEMkrGdsCdChgWork = sAndEMkrGdsCdChgWork;

            // ��������
            int status = this._iSAndEMkrGdsCdChgSetDB.RevivalLogicalDelete(ref objectSAndEMkrGdsCdChgWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ď��i�R�[�h�ϊ����[�N�N���X���f�V���A���C�Y����
                sAndEMkrGdsCdChgWork = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // �N���X�������o�R�s�[
                sAndEMkrGdsCdChg = CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(sAndEMkrGdsCdChgWork);

            }

            return status;
        }

        # endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���[�N�N���X�˃��[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X�j
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���[�N�N���X</param>
        /// <returns>���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���[�N�N���X���烁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private SAndEMkrGdsCdChg CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork)
        {
            SAndEMkrGdsCdChg sAndEMkrGdsCdChg = new SAndEMkrGdsCdChg();
            sAndEMkrGdsCdChg.CreateDateTime = sAndEMkrGdsCdChgWork.CreateDateTime;
            sAndEMkrGdsCdChg.UpdateDateTime = sAndEMkrGdsCdChgWork.UpdateDateTime;
            sAndEMkrGdsCdChg.EnterpriseCode = sAndEMkrGdsCdChgWork.EnterpriseCode;
            sAndEMkrGdsCdChg.FileHeaderGuid = sAndEMkrGdsCdChgWork.FileHeaderGuid;
            sAndEMkrGdsCdChg.UpdEmployeeCode = sAndEMkrGdsCdChgWork.UpdEmployeeCode;
            sAndEMkrGdsCdChg.UpdAssemblyId1 = sAndEMkrGdsCdChgWork.UpdAssemblyId1;
            sAndEMkrGdsCdChg.UpdAssemblyId2 = sAndEMkrGdsCdChgWork.UpdAssemblyId2;
            sAndEMkrGdsCdChg.LogicalDeleteCode = sAndEMkrGdsCdChgWork.LogicalDeleteCode;
            sAndEMkrGdsCdChg.GoodsMakerCd = sAndEMkrGdsCdChgWork.GoodsMakerCd;
            sAndEMkrGdsCdChg.GoodsNo = sAndEMkrGdsCdChgWork.GoodsNo;
            sAndEMkrGdsCdChg.ABGoodsCode = sAndEMkrGdsCdChgWork.ABGoodsCode;
            sAndEMkrGdsCdChg.MakerName = sAndEMkrGdsCdChgWork.MakerName;

            return sAndEMkrGdsCdChg;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�˃��[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X</param>
        /// <returns>���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^�N���X���烁�[�J�[�E�i��S��E���i�R�[�h�ϊ��}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���c�`�[</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private SAndEMkrGdsCdChgWork CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = new SAndEMkrGdsCdChgWork();
            sAndEMkrGdsCdChgWork.CreateDateTime = sAndEMkrGdsCdChg.CreateDateTime;
            sAndEMkrGdsCdChgWork.UpdateDateTime = sAndEMkrGdsCdChg.UpdateDateTime;
            sAndEMkrGdsCdChgWork.EnterpriseCode = sAndEMkrGdsCdChg.EnterpriseCode;
            sAndEMkrGdsCdChgWork.FileHeaderGuid = sAndEMkrGdsCdChg.FileHeaderGuid;
            sAndEMkrGdsCdChgWork.UpdEmployeeCode = sAndEMkrGdsCdChg.UpdEmployeeCode;
            sAndEMkrGdsCdChgWork.UpdAssemblyId1 = sAndEMkrGdsCdChg.UpdAssemblyId1;
            sAndEMkrGdsCdChgWork.UpdAssemblyId2 = sAndEMkrGdsCdChg.UpdAssemblyId2;
            sAndEMkrGdsCdChgWork.LogicalDeleteCode = sAndEMkrGdsCdChg.LogicalDeleteCode;
            sAndEMkrGdsCdChgWork.GoodsMakerCd = sAndEMkrGdsCdChg.GoodsMakerCd;
            sAndEMkrGdsCdChgWork.GoodsNo = sAndEMkrGdsCdChg.GoodsNo;
            sAndEMkrGdsCdChgWork.ABGoodsCode = sAndEMkrGdsCdChg.ABGoodsCode;
            sAndEMkrGdsCdChgWork.MakerName = sAndEMkrGdsCdChg.MakerName;

            return sAndEMkrGdsCdChgWork;

        }

        # endregion
    }
}
