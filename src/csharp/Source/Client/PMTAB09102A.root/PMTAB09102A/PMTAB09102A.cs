//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y                                       //
// �v���O��������   �FPMTAB�S�̐ݒ�i���_�ʁj�}�X�^                     //
// �v���O�����T�v   �FPMTAB�S�̐ݒ�i���_�ʁj�̓o�^�E�C���E�폜���s��   //
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// �Ǘ��ԍ�  10902622-01     �쐬�S���F���|��
// �C����    2013/05/31�@    �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���|��</br>
    /// <br>Date       : 2013/05/31</br>
    /// </remarks>
    public class PmTabTtlStSecAcs
    {
        # region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        IPmTabTtlStSecDB _ipmTabTtlStSecDB = null;

        // �K�C�h�ݒ�t�@�C����
        private const string GUIDE_XML_FILENAME = "PMTABTTLSTSECGUIDEPARENT.XML";   // XML�t�@�C����

        // �K�C�h�p�����[�^
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";             // ��ƃR�[�h

        // �K�C�h���ڃ^�C�v
        private const string GUIDE_TYPE_STR = "System.String";              // String�^

        // �K�C�h���ږ�
        private const string GUIDE_SECTIONCODE_TITLE = "SectionCode";                // ���_�R�[�h
        private const string GUIDE_SECTIONNM_TITLE = "SectionGuideNm";                // ���_����

        private SecInfoAcs   _secInfoAcs; // ���_���A�N�Z�X�N���X
        
        # endregion

        # region Constructor

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PmTabTtlStSecAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._ipmTabTtlStSecDB = (IPmTabTtlStSecDB)MediationPmTabTtlStSecDB.GetPmTabTtlStSecDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._ipmTabTtlStSecDB = null;
            }
            
            this._secInfoAcs = new SecInfoAcs(1); // �����[�g
            this._secInfoAcs.ResetSectionInfo();
        }

        # endregion

        #region GetOnlineMode

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._ipmTabTtlStSecDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        #region Write Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�o�^�E�X�V����
        /// </summary>
        /// <param name="pmTabTtlStSec">�^�u���b�g�S�̐ݒ�}�X�^(���_��)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Write(ref PmTabTtlStSec pmTabTtlStSec)
        {
            // �^�u���b�g�S�̐ݒ�}�X�^(���_��)�N���X����^�u���b�g�S�̐ݒ�}�X�^(���_��)���[�J�[�N���X�Ƀ����o�R�s�[
            PmTabTtlStSecWork pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStSec);

            ArrayList paraList = new ArrayList();

            paraList.Add(pmTabTtlStSecWork);

            object paraObj = paraList;
            int status = 0;
            try
            {
                //�^�u���b�g�S�̐ݒ�}�X�^(���_��)��������
                status = this._ipmTabTtlStSecDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    pmTabTtlStSecWork = (PmTabTtlStSecWork)paraList[0];

                    // �N���X�������o�R�s�[
                    pmTabTtlStSec = CopyToSubSectionFromSubSectionWork(pmTabTtlStSecWork);

                }
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }

        #endregion

        #region LogicalDelete Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�_���폜����
        /// </summary>
        /// <param name="pmTabTtlStSec">�^�u���b�g�S�̐ݒ�}�X�^(���_��)�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)���̘_���폜���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int LogicalDelete(ref PmTabTtlStSec pmTabTtlStSec)
        {
            int status = 0;

            try
            {
                // �^�u���b�g�S�̐ݒ�}�X�^(���_��)�ϊ�
                ArrayList paraLst = new ArrayList();
                PmTabTtlStSecWork pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStSec);
                paraLst.Add(pmTabTtlStSecWork);
                object paraObj = paraLst;

                // �_���폜
                status = this._ipmTabTtlStSecDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    pmTabTtlStSecWork = (PmTabTtlStSecWork)paraLst[0];
                    // �N���X�������o�R�s�[
                    pmTabTtlStSec = CopyToSubSectionFromSubSectionWork(pmTabTtlStSecWork);

                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._ipmTabTtlStSecDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�_���폜��������
        /// </summary>
        /// <param name="pmTabTtlStSec">�^�u���b�g�S�̐ݒ�}�X�^(���_��)�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)���̕������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Revival(ref PmTabTtlStSec pmTabTtlStSec)
        {
            try
            {
                PmTabTtlStSecWork pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStSec);
                ArrayList paraLst = new ArrayList();

                paraLst.Add(pmTabTtlStSecWork);

                object paraObj = paraLst;

                // ��������
                int status = this._ipmTabTtlStSecDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    pmTabTtlStSecWork = (PmTabTtlStSecWork)paraLst[0];
                    // �N���X�������o�R�s�[
                    pmTabTtlStSec = CopyToSubSectionFromSubSectionWork(pmTabTtlStSecWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._ipmTabTtlStSecDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�����폜����
        /// </summary>
        /// <param name="pmTabTtlStSec">�^�u���b�g�S�̐ݒ�}�X�^(���_��)�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)���̕����폜���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Delete(PmTabTtlStSec pmTabTtlStSec)
        {
            try
            {
                PmTabTtlStSecWork pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStSec);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(pmTabTtlStSecWork);

                // �^�u���b�g�S�̐ݒ�}�X�^(���_��)�����폜
                int status = this._ipmTabTtlStSecDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._ipmTabTtlStSecDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�S��������(���_�i����)�i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="sectionCode">���_�R�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�ł̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, 0, null);
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)��������(���_�i����)
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSubSection��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="prevSubSection">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)�̌����������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, PmTabTtlStSec prevSubSection)
        {
            // ������
            retList = new ArrayList();
            retTotalCnt = 0;

            // �߂�l���X�g
            ArrayList wkList = new ArrayList();
            
            // ���������Z�b�g
            PmTabTtlStSecWork pmTabTtlStSecWork = new PmTabTtlStSecWork();
            if (prevSubSection != null) pmTabTtlStSecWork = CopyToSubSectionWorkFromSubSection(prevSubSection);

            pmTabTtlStSecWork.EnterpriseCode = enterpriseCode;
            pmTabTtlStSecWork.SectionCode = sectionCode;

            // Search�p�����[�^
            ArrayList paraList = new ArrayList();
            paraList.Add( pmTabTtlStSecWork );
            object paraobj = paraList;

            // ����
            object retobj = null;

			int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			// �����[�g
            status_o = this._ipmTabTtlStSecDB.Search(out retobj, paraobj, 0, logicalMode);

            // �������ʔ���
            switch (status_o) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL: 
                    wkList = retobj as ArrayList;

                    if (wkList != null) {
                        foreach (PmTabTtlStSecWork wkLineupWork in wkList) {
                            if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == ""))) 
                            {
                                //�����o�R�s�[
                                retList.Add(CopyToSubSectionFromSubSectionWork(wkLineupWork));
                            }
                        }

                        retTotalCnt = retList.Count;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF: 
                    break;
                default: 
                    return status_o;
            }

            return status_o;
        }

        #endregion

        #region ���_���̎擾 Methods
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (sectionCode.Trim().PadLeft(2, '0') == "00")
            {
                sectionName = "�S�Ћ���";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                        {
                            sectionName = secInfoSet.SectionGuideNm.Trim();
                            return sectionName;
                        }
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        #endregion

        #region ���_�����݂��邩���`�F�b�N Methods
        /// <summary>
        /// ���_�����݂��邩���`�F�b�N
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>flag</returns>
        /// <remarks>
        /// <br>Note       : ���_�����݂��邩���`�F�b�N</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public bool SectionExistCheck(string sectionCode)
        {
            bool sectionExist = false;

            if (sectionCode.Trim().PadLeft(2, '0') == "00")
            {
                sectionExist = true;
                return sectionExist;
            }
            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                        {
                            sectionExist = true;
                        }
                    }
                }
            }
            catch
            {
                sectionExist = false;
            }

            return sectionExist;
        }
        #endregion

        #region MemberCopy Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�^�u���b�g�S�̐ݒ�}�X�^(���_��)���[�N�N���X�˃^�u���b�g�S�̐ݒ�}�X�^(���_��)�j
        /// </summary>
        /// <param name="pmTabTtlStSecWork">�^�u���b�g�S�̐ݒ�}�X�^(���_��)���[�N�N���X</param>
        /// <returns>�^�u���b�g�S�̐ݒ�}�X�^(���_��)</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)���[�N�N���X����^�u���b�g�S�̐ݒ�}�X�^(���_��)�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStSec CopyToSubSectionFromSubSectionWork(PmTabTtlStSecWork pmTabTtlStSecWork)
        {
            PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();

            pmTabTtlStSec.CreateDateTime = pmTabTtlStSecWork.CreateDateTime;
            pmTabTtlStSec.UpdateDateTime = pmTabTtlStSecWork.UpdateDateTime;
            pmTabTtlStSec.FileHeaderGuid = pmTabTtlStSecWork.FileHeaderGuid;
            pmTabTtlStSec.LogicalDeleteCode = pmTabTtlStSecWork.LogicalDeleteCode;
            pmTabTtlStSec.EnterpriseCode = pmTabTtlStSecWork.EnterpriseCode;

            pmTabTtlStSec.LogicalDeleteCode = pmTabTtlStSecWork.LogicalDeleteCode;
            pmTabTtlStSec.SectionCode = pmTabTtlStSecWork.SectionCode;
            pmTabTtlStSec.CashRegisterNo = pmTabTtlStSecWork.CashRegisterNo;
            pmTabTtlStSec.LiPriSelPrtGdsNoDiv = pmTabTtlStSecWork.LiPriSelPrtGdsNoDiv;

            return pmTabTtlStSec;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�^�u���b�g�S�̐ݒ�}�X�^(���_��)�˃^�u���b�g�S�̐ݒ�}�X�^(���_��)���[�N�N���X�j
        /// </summary>
        /// <param name="pmTabTtlStSec">�^�u���b�g�S�̐ݒ�}�X�^(���_��)�N���X</param>
        /// <returns>�^�u���b�g�S�̐ݒ�}�X�^(���_��)���[�N</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)����^�u���b�g�S�̐ݒ�}�X�^(���_��)���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStSecWork CopyToSubSectionWorkFromSubSection(PmTabTtlStSec pmTabTtlStSec)
        {
            PmTabTtlStSecWork pmTabTtlStSecWork = new PmTabTtlStSecWork();

            pmTabTtlStSecWork.CreateDateTime = pmTabTtlStSec.CreateDateTime;
            pmTabTtlStSecWork.UpdateDateTime = pmTabTtlStSec.UpdateDateTime;
            pmTabTtlStSecWork.EnterpriseCode = pmTabTtlStSec.EnterpriseCode;
            pmTabTtlStSecWork.FileHeaderGuid = pmTabTtlStSec.FileHeaderGuid;

            pmTabTtlStSecWork.LogicalDeleteCode = pmTabTtlStSec.LogicalDeleteCode;
            pmTabTtlStSecWork.SectionCode = pmTabTtlStSec.SectionCode;
            pmTabTtlStSecWork.CashRegisterNo = pmTabTtlStSec.CashRegisterNo;
            pmTabTtlStSecWork.LiPriSelPrtGdsNoDiv = pmTabTtlStSec.LiPriSelPrtGdsNoDiv;

            return pmTabTtlStSecWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[���� (�K�C�h�I���f�[�^)
        /// </summary>
        /// <param name="guideData">�K�C�h�I���f�[�^</param>
        /// <returns>�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�I���f�[�^����}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStSec CopyToSubSectionFromGuideData(Hashtable guideData)
        {
            PmTabTtlStSec pmTabTtlStSec = new PmTabTtlStSec();

            pmTabTtlStSec.SectionCode = (string)guideData[GUIDE_SECTIONCODE_TITLE];                     // ���_�R�[�h

            return pmTabTtlStSec;
        }

        /// <summary>
        /// DataRow�R�s�[�����i�^�u���b�g�S�̐ݒ�}�X�^(���_��)�N���X�˃K�C�h�pDataRow�j
        /// </summary>
        /// <param name="guideRow">�K�C�h�pDataRow</param>
        /// <param name="pmTabTtlStSec">�^�u���b�g�S�̐ݒ�}�X�^(���_��)�N���X</param>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���_��)�N���X����K�C�h�pDataRow�փR�s�[���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void CopyToGuideRowFromSubSection(ref DataRow guideRow, PmTabTtlStSec pmTabTtlStSec)
        {
            guideRow[GUIDE_SECTIONCODE_TITLE] = pmTabTtlStSec.SectionCode;            // ���_�R�[�h
            guideRow[GUIDE_SECTIONNM_TITLE] = this.GetSectionName(pmTabTtlStSec.SectionCode);
        }

        #endregion
      
    }
}
