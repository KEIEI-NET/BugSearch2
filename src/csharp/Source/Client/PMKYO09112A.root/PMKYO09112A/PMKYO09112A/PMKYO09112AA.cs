//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���_�Ǘ���Ɛݒ�}�X�^�����e�i���X
// �v���O�����T�v   : ���_�Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/03/27  �C�����e : �V�K�쐬
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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ��ƃR�[�h�ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��ƃR�[�h�ݒ�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.03.26</br>
    /// <br></br>
    /// </remarks>
    public class EnterpriseSetAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private IEnterpriseSetDB _iEnterpriseSetDB = null;

        // ���[�J���c�a���[�h
        private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g

        // ���_���擾�p
        private SecInfoAcs _secInfoAcs;

        #endregion

        #region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// <br></br>
        /// </remarks>
        public EnterpriseSetAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iEnterpriseSetDB = (IEnterpriseSetDB)MediationEnterpriseSetDB.GetEnterpriseSetDB();
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
        /// <param name="allDefSet">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Write(ref EnterpriseSet enterpriseSet)
        {
            // UI�f�[�^�N���X�����[�N
            SecMngEpSetWork enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(enterpriseSet);

            // XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte = XmlByteSerializer.Serialize(enterpriseSetWork);
            object objenterpriseSetWork = enterpriseSetWork;

            int status = 0;
            int writeMode = 0;

            // �������ݏ���
            status = this._iEnterpriseSetDB.Write(ref objenterpriseSetWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                //enterpriseSetWork = (SecMngEpSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngEpSetWork));
                enterpriseSetWork = objenterpriseSetWork as SecMngEpSetWork;

                // �N���X�������o�R�s�[
                enterpriseSet = CopyToEnterpriseSetFromEnterpriseSetWork(enterpriseSetWork);
            }

            return status;
        }

        #endregion

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="allDefSet">��ƃR�[�h�ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ�̘_���폜���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int LogicalDelete(ref EnterpriseSet enterpriseSet)
        {
            SecMngEpSetWork enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(enterpriseSet);

            // XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte = XmlByteSerializer.Serialize(enterpriseSetWork);
            object objenterpriseSetWork = enterpriseSetWork;

            // ���_���_���폜
            int status = this._iEnterpriseSetDB.LogicalDelete(ref objenterpriseSetWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                //enterpriseSetWork = (SecMngEpSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngEpSetWork));
                enterpriseSetWork = objenterpriseSetWork as SecMngEpSetWork;

                // �N���X�������o�R�s�[
                enterpriseSet = CopyToEnterpriseSetFromEnterpriseSetWork(enterpriseSetWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="allDefSet">��ƃR�[�h�ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ�̕����폜���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Delete(EnterpriseSet enterpriseSet)
        {
            SecMngEpSetWork enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(enterpriseSet);

            // XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte = XmlByteSerializer.Serialize(enterpriseSetWork);
            object objEnterpriseSetWork = enterpriseSetWork;

            // ���_��񕨗��폜
            int status = this._iEnterpriseSetDB.Delete(ref objEnterpriseSetWork);

            return status;
        }

        #endregion

        #region -- ������������� --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ƃR�[�h�ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
        ///��ƃR�[�h�ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ��ƃR�[�h�ݒ茟������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>  
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevAllDefSet">�O��ŏI�Ԕ̏��ޑS�̐ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ�̌����������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, EnterpriseSet prevEnterpriseSet, SearchMode searchMode)
        {
            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            SecMngEpSetWork enterpriseSetWork = new SecMngEpSetWork();

            if (prevEnterpriseSet != null)
            {
                enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(prevEnterpriseSet);
            }

            enterpriseSetWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList enterpriseSetWorkList = new ArrayList();
            enterpriseSetWorkList.Clear();

            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            // ���f�[�^�L��������
            nextData = false;

            object paraobj = enterpriseSetWork;
            object retobj = null;

            status = this._iEnterpriseSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                enterpriseSetWorkList = retobj as ArrayList;

                if (enterpriseSetWorkList == null)
                {
                    return status;
                }

                foreach (SecMngEpSetWork wkenterpriseSetWork in enterpriseSetWorkList)
                {
                    retList.Add(CopyToEnterpriseSetFromEnterpriseSetWork(wkenterpriseSetWork));
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
        /// ��ƃR�[�h�ݒ�_���폜��������
        /// </summary>
        /// <param name="allDefSet">��ƃR�[�h�ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ�̕������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        public int Revival(ref EnterpriseSet enterpriseSet)
        {
            SecMngEpSetWork enterpriseSetWork = CopyToEnterpriseSetWorkFromEnterpriseSet(enterpriseSet);

            // XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte = XmlByteSerializer.Serialize(enterpriseSetWork);

            object objenterpriseSetWork = enterpriseSetWork;

            // ��������
            int status = this._iEnterpriseSetDB.RevivalLogicalDelete(ref objenterpriseSetWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �t�@�C������n���ċ��_��񃏁[�N�N���X���f�V���A���C�Y����
                //enterpriseSetWork = (SecMngEpSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(SecMngEpSetWork));
                enterpriseSetWork = objenterpriseSetWork as SecMngEpSetWork;

                // �N���X�������o�R�s�[
                enterpriseSet = CopyToEnterpriseSetFromEnterpriseSetWork(enterpriseSetWork);

            }

            return status;
        }

        # endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i��ƃR�[�h�ݒ胏�[�N�N���X�ˊ�ƃR�[�h�ݒ�N���X�j
        /// </summary>
        /// <param name="allDefSetWork">��ƃR�[�h�ݒ胏�[�N�N���X</param>
        /// <returns>��ƃR�[�h�ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ胏�[�N�N���X�����ƃR�[�h�ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private EnterpriseSet CopyToEnterpriseSetFromEnterpriseSetWork(SecMngEpSetWork enterpriseSetWork)
        {
            EnterpriseSet enterpriseSet = new EnterpriseSet();
            enterpriseSet.CreateDateTime = enterpriseSetWork.CreateDateTime;
            enterpriseSet.UpdateDateTime = enterpriseSetWork.UpdateDateTime;
            enterpriseSet.EnterpriseCode = enterpriseSetWork.EnterpriseCode;
            enterpriseSet.FileHeaderGuid = enterpriseSetWork.FileHeaderGuid;
            enterpriseSet.UpdEmployeeCode = enterpriseSetWork.UpdEmployeeCode;
            enterpriseSet.UpdAssemblyId1 = enterpriseSetWork.UpdAssemblyId1;
            enterpriseSet.UpdAssemblyId2 = enterpriseSetWork.UpdAssemblyId2;
            enterpriseSet.LogicalDeleteCode = enterpriseSetWork.LogicalDeleteCode;
            enterpriseSet.SectionCode = enterpriseSetWork.SectionCode;
            enterpriseSet.PmEnterpriseCode = enterpriseSetWork.PmEnterpriseCode;

            return enterpriseSet;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i��ƃR�[�h�ݒ胏�[�N�N���X�ˊ�ƃR�[�h�ݒ�N���X�j
        /// </summary>
        /// <param name="allDefSetWorkList">��ƃR�[�h�ݒ胏�[�N�N���X</param>
        /// <returns>��ƃR�[�h�ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ胏�[�N�N���X�����ƃR�[�h�ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private void CopyToEnterpriseSetFromEnterpriseSetWork(ArrayList enterpriseSetWorkList)
        {
            // HashTable��Key
            string keyOfHashTable = null;

            // ArrayList����̏ꍇ
            if (enterpriseSetWorkList == null)
                return;

            foreach (SecMngEpSetWork enterpriseSetWork in enterpriseSetWorkList)
            {
                EnterpriseSet enterpriseSet = new EnterpriseSet();

                keyOfHashTable = enterpriseSetWork.SectionCode;

                enterpriseSet.CreateDateTime = enterpriseSetWork.CreateDateTime;
                enterpriseSet.UpdateDateTime = enterpriseSetWork.UpdateDateTime;
                enterpriseSet.EnterpriseCode = enterpriseSetWork.EnterpriseCode;
                enterpriseSet.FileHeaderGuid = enterpriseSetWork.FileHeaderGuid;
                enterpriseSet.UpdEmployeeCode = enterpriseSetWork.UpdEmployeeCode;
                enterpriseSet.UpdAssemblyId1 = enterpriseSetWork.UpdAssemblyId1;
                enterpriseSet.UpdAssemblyId2 = enterpriseSetWork.UpdAssemblyId2;
                enterpriseSet.LogicalDeleteCode = enterpriseSetWork.LogicalDeleteCode;
                enterpriseSet.SectionCode = enterpriseSetWork.SectionCode;
                enterpriseSet.PmEnterpriseCode = enterpriseSetWork.PmEnterpriseCode;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i��ƃR�[�h�ݒ�N���X�ˊ�ƃR�[�h�ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="allDefSet">��ƃR�[�h�ݒ�N���X</param>
        /// <returns>��ƃR�[�h�ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ��ƃR�[�h�ݒ�N���X�����ƃR�[�h�ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private SecMngEpSetWork CopyToEnterpriseSetWorkFromEnterpriseSet(EnterpriseSet enterpriseSet)
        {
            SecMngEpSetWork enterpriseSetWork = new SecMngEpSetWork();
            enterpriseSetWork.CreateDateTime = enterpriseSet.CreateDateTime;
            enterpriseSetWork.UpdateDateTime = enterpriseSet.UpdateDateTime;
            enterpriseSetWork.EnterpriseCode = enterpriseSet.EnterpriseCode;
            enterpriseSetWork.FileHeaderGuid = enterpriseSet.FileHeaderGuid;
            enterpriseSetWork.UpdEmployeeCode = enterpriseSet.UpdEmployeeCode;
            enterpriseSetWork.UpdAssemblyId1 = enterpriseSet.UpdAssemblyId1;
            enterpriseSetWork.UpdAssemblyId2 = enterpriseSet.UpdAssemblyId2;
            enterpriseSetWork.LogicalDeleteCode = enterpriseSet.LogicalDeleteCode;
            enterpriseSetWork.SectionCode = enterpriseSet.SectionCode;
            enterpriseSetWork.PmEnterpriseCode = enterpriseSet.PmEnterpriseCode;

            return enterpriseSetWork;

        }

        # endregion

        #region -- �Ώۃf�[�^�`�F�b�N�A���̎擾 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���_���̎擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h���狒�_���̂��擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// <br></br>
        /// </remarks>
        public string GetSectionName(string enterpriseCode, string sectionCode)
        {
            // ���[�J���c�a���_�Ή�
            ConstructSecInfoAcs();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.SectionCode.TrimEnd() == "0")
                {
                    return "���o�^";
                }
                else if ((secInfoSet.SectionCode.TrimEnd() == sectionCode.TrimEnd()) &&
                    (secInfoSet.LogicalDeleteCode == 0))
                {
                    return secInfoSet.SectionGuideNm;
                }
            }
            return "���o�^";
        }

        /// <summary>
        /// ���[�J���c�a�Ή����_���N���X�쐬����
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note       : ���_���N���X�쐬�𖢍쐬���ɍ쐬���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.03.26</br>
        /// </remarks>
        private Boolean ConstructSecInfoAcs()
        {
            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
                if (this._secInfoAcs != null)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
