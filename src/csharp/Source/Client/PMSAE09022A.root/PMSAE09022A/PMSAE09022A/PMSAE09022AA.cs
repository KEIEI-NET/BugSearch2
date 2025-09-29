//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �I�[�g�o�b�N�X���i�R�[�h�ϊ��}�X�^�����e�i���X
// �v���O�����T�v   : ���i�R�[�h�ϊ��̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/05  �C�����e : �V�K�쐬
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
    /// ���i�R�[�h�ϊ��A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�R�[�h�ϊ��̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// </remarks>
    public class BLGoodsCodeSetAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private ISAndEGoodsCdChgSetDB _iSAndEGoodsCdChgSetDB = null;

        #endregion

        #region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// <br></br>
        /// </remarks>
        public BLGoodsCodeSetAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iSAndEGoodsCdChgSetDB = (ISAndEGoodsCdChgSetDB)MediationSAndEGoodsCdChgSetDB.GetSAndEGoodsCdChgSetDB();
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
        /// <param name="sAndEGoodsCdChg">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int Write(ref SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            // UI�f�[�^�N���X�����[�N
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(sAndEGoodsCdChg);

            object objectsAndEGoodsCdChgWork = sAndEGoodsCdChgWork;

            int status = 0;
            int writeMode = 0;

            // �������ݏ���
            status = this._iSAndEGoodsCdChgSetDB.Write(ref objectsAndEGoodsCdChgWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                sAndEGoodsCdChgWork = objectsAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // �N���X�������o�R�s�[
                sAndEGoodsCdChg = CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(sAndEGoodsCdChgWork);
            }

            return status;
        }

        #endregion

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="sAndEGoodsCdChg">���i�R�[�h�ϊ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��̘_���폜���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int LogicalDelete(ref SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(sAndEGoodsCdChg);

            object objectsAndEGoodsCdChgWork = sAndEGoodsCdChgWork;

            //  ���i�R�[�h�ϊ����_���폜
            int status = this._iSAndEGoodsCdChgSetDB.LogicalDelete(ref objectsAndEGoodsCdChgWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                sAndEGoodsCdChgWork = objectsAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // �N���X�������o�R�s�[
                sAndEGoodsCdChg = CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(sAndEGoodsCdChgWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="sAndEGoodsCdChg">���i�R�[�h�ϊ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��̕����폜���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int Delete(SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(sAndEGoodsCdChg);

            // XML�֕ϊ����A������̃o�C�i����
            object objectSAndEGoodsCdChgWork = sAndEGoodsCdChgWork;

            // ���i�R�[�h�ϊ���񕨗��폜
            int status = this._iSAndEGoodsCdChgSetDB.Delete(ref objectSAndEGoodsCdChgWork);

            return status;
        }

        #endregion

        #region -- ������������� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���i�R�[�h�ϊ����������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
        ///���i�R�[�h�ϊ����������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���i�R�[�h�ϊ���������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>  
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevSAndEGoodsCdChg">�O�񏤕i�R�[�h�ϊ��f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��̌����������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SAndEGoodsCdChg prevSAndEGoodsCdChg, SearchMode searchMode)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = new SAndEGoodsCdChgWork();

            if (prevSAndEGoodsCdChg != null)
            {
                sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(prevSAndEGoodsCdChg);
            }

            sAndEGoodsCdChgWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();

            ArrayList sAndEGoodsCdChgWorkList = new ArrayList();

            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            // ���f�[�^�L��������
            nextData = false;

            object paraobj = sAndEGoodsCdChgWork;
            object retobj = null;

            status = this._iSAndEGoodsCdChgSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sAndEGoodsCdChgWorkList = retobj as ArrayList;

                if (sAndEGoodsCdChgWorkList == null)
                {
                    return status;
                }

                foreach (SAndEGoodsCdChgWork wksAndEGoodsCdChgWork in sAndEGoodsCdChgWorkList)
                {
                    retList.Add(CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(wksAndEGoodsCdChgWork));
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
        /// ���i�R�[�h�ϊ��_���폜��������
        /// </summary>
        /// <param name="sAndEGoodsCdChg">���i�R�[�h�ϊ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��̕������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int Revival(ref SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(sAndEGoodsCdChg);

            // XML�֕ϊ����A������̃o�C�i����
            object objectsAndEGoodsCdChgWork = sAndEGoodsCdChgWork;

            // ��������
            int status = this._iSAndEGoodsCdChgSetDB.RevivalLogicalDelete(ref objectsAndEGoodsCdChgWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ď��i�R�[�h�ϊ����[�N�N���X���f�V���A���C�Y����
                sAndEGoodsCdChgWork = objectsAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // �N���X�������o�R�s�[
                sAndEGoodsCdChg = CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(sAndEGoodsCdChgWork);

            }

            return status;
        }

        # endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���i�R�[�h�ϊ����[�N�N���X�ˏ��i�R�[�h�ϊ��N���X�j
        /// </summary>
        /// <param name="sAndEGoodsCdChgWork">���i�R�[�h�ϊ����[�N�N���X</param>
        /// <returns>���i�R�[�h�ϊ��N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ����[�N�N���X���珤�i�R�[�h�ϊ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private SAndEGoodsCdChg CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(SAndEGoodsCdChgWork sAndEGoodsCdChgWork)
        {
            SAndEGoodsCdChg sAndEGoodsCdChg = new SAndEGoodsCdChg();
            sAndEGoodsCdChg.CreateDateTime = sAndEGoodsCdChgWork.CreateDateTime;
            sAndEGoodsCdChg.UpdateDateTime = sAndEGoodsCdChgWork.UpdateDateTime;
            sAndEGoodsCdChg.EnterpriseCode = sAndEGoodsCdChgWork.EnterpriseCode;
            sAndEGoodsCdChg.FileHeaderGuid = sAndEGoodsCdChgWork.FileHeaderGuid;
            sAndEGoodsCdChg.UpdEmployeeCode = sAndEGoodsCdChgWork.UpdEmployeeCode;
            sAndEGoodsCdChg.UpdAssemblyId1 = sAndEGoodsCdChgWork.UpdAssemblyId1;
            sAndEGoodsCdChg.UpdAssemblyId2 = sAndEGoodsCdChgWork.UpdAssemblyId2;
            sAndEGoodsCdChg.LogicalDeleteCode = sAndEGoodsCdChgWork.LogicalDeleteCode;
            sAndEGoodsCdChg.BLGoodsCode = sAndEGoodsCdChgWork.BLGoodsCode;
            sAndEGoodsCdChg.ABGoodsCode = sAndEGoodsCdChgWork.ABGoodsCode;
            sAndEGoodsCdChg.BLGoodsHalfName = sAndEGoodsCdChgWork.BLGoodsHalfName;

            return sAndEGoodsCdChg;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���i�R�[�h�ϊ��}�X�^�ˏ��i�R�[�h�ϊ����[�N�N���X�j
        /// </summary>
        /// <param name="sAndEGoodsCdChg">���i�R�[�h�ϊ��N���X</param>
        /// <returns>���i�R�[�h�ϊ��N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�ϊ��N���X���珤�i�R�[�h�ϊ����[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private SAndEGoodsCdChgWork CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = new SAndEGoodsCdChgWork();
            sAndEGoodsCdChgWork.CreateDateTime = sAndEGoodsCdChg.CreateDateTime;
            sAndEGoodsCdChgWork.UpdateDateTime = sAndEGoodsCdChg.UpdateDateTime;
            sAndEGoodsCdChgWork.EnterpriseCode = sAndEGoodsCdChg.EnterpriseCode;
            sAndEGoodsCdChgWork.FileHeaderGuid = sAndEGoodsCdChg.FileHeaderGuid;
            sAndEGoodsCdChgWork.UpdEmployeeCode = sAndEGoodsCdChg.UpdEmployeeCode;
            sAndEGoodsCdChgWork.UpdAssemblyId1 = sAndEGoodsCdChg.UpdAssemblyId1;
            sAndEGoodsCdChgWork.UpdAssemblyId2 = sAndEGoodsCdChg.UpdAssemblyId2;
            sAndEGoodsCdChgWork.LogicalDeleteCode = sAndEGoodsCdChg.LogicalDeleteCode;
            sAndEGoodsCdChgWork.BLGoodsCode = sAndEGoodsCdChg.BLGoodsCode;
            sAndEGoodsCdChgWork.ABGoodsCode = sAndEGoodsCdChg.ABGoodsCode;
            sAndEGoodsCdChgWork.BLGoodsHalfName = sAndEGoodsCdChg.BLGoodsHalfName;

            return sAndEGoodsCdChgWork;

        }

        # endregion
    }
}
