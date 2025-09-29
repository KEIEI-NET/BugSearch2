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
    /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���|��</br>
    /// <br>Date       : 2013/05/31</br>
    /// </remarks>
    public class PmTabTtlStCustAcs 
    {
        # region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        IPmTabTtlStCustDB _ipmTabTtlStCustDB = null;

        // �K�C�h�ݒ�t�@�C����
        private const string GUIDE_XML_FILENAME = "PMTABTTLSTCUSTGUIDEPARENT.XML";   // XML�t�@�C����

        // �K�C�h�p�����[�^
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";             // ��ƃR�[�h

        // �K�C�h���ڃ^�C�v
        private const string GUIDE_TYPE_STR = "System.String";              // String�^

        // �K�C�h���ږ�
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode";                // ���Ӑ�R�[�h
        private const string GUIDE_CUSTOMERCODENM_TITLE = "CustomerGuideNm";                // ���Ӑ於��

        # endregion

        # region Constructor

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public PmTabTtlStCustAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._ipmTabTtlStCustDB = (IPmTabTtlStCustDB)MediationPmTabTtlStCustDB.GetPmTabTtlStCustDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._ipmTabTtlStCustDB = null;
            }
            
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
            if (this._ipmTabTtlStCustDB == null)
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
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�o�^�E�X�V����
        /// </summary>
        /// <param name="pmTabTtlStCust">�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Write(ref PmTabTtlStCust pmTabTtlStCust)
        {
            // �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�N���X����^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���[�J�[�N���X�Ƀ����o�R�s�[
            PmTabTtlStCustWork pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStCust);

            ArrayList paraList = new ArrayList();

            paraList.Add(pmTabTtlStCustWork);

            object paraObj = paraList;
            int status = 0;
            try
            {
                //�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)��������
                status = this._ipmTabTtlStCustDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    pmTabTtlStCustWork = (PmTabTtlStCustWork)paraList[0];

                    // �N���X�������o�R�s�[
                    pmTabTtlStCust = CopyToSubSectionFromSubSectionWork(pmTabTtlStCustWork);

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
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�_���폜����
        /// </summary>
        /// <param name="pmTabTtlStCust">�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���̘_���폜���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int LogicalDelete(ref PmTabTtlStCust pmTabTtlStCust)
        {
            int status = 0;

            try
            {
                // �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�ϊ�
                ArrayList paraLst = new ArrayList();
                PmTabTtlStCustWork pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStCust);
                paraLst.Add(pmTabTtlStCustWork);
                object paraObj = paraLst;

                // �_���폜
                status = this._ipmTabTtlStCustDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    pmTabTtlStCustWork = (PmTabTtlStCustWork)paraLst[0];
                    // �N���X�������o�R�s�[
                    pmTabTtlStCust = CopyToSubSectionFromSubSectionWork(pmTabTtlStCustWork);

                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._ipmTabTtlStCustDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�_���폜��������
        /// </summary>
        /// <param name="pmTabTtlStCust">�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���̕������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Revival(ref PmTabTtlStCust pmTabTtlStCust)
        {
            try
            {
                PmTabTtlStCustWork pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStCust);
                ArrayList paraLst = new ArrayList();

                paraLst.Add(pmTabTtlStCustWork);

                object paraObj = paraLst;

                // ��������
                int status = this._ipmTabTtlStCustDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    pmTabTtlStCustWork = (PmTabTtlStCustWork)paraLst[0];
                    // �N���X�������o�R�s�[
                    pmTabTtlStCust = CopyToSubSectionFromSubSectionWork(pmTabTtlStCustWork);

                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._ipmTabTtlStCustDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�����폜����
        /// </summary>
        /// <param name="pmTabTtlStCust">�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���̕����폜���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Delete(PmTabTtlStCust pmTabTtlStCust)
        {
            try
            {
                PmTabTtlStCustWork pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(pmTabTtlStCust);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(pmTabTtlStCustWork);

                // �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�����폜
                int status = this._ipmTabTtlStCustDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._ipmTabTtlStCustDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", 0, null);
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�S��������(���Ӑ�i����)�i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="customercode">���Ӑ�R�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Y�����Ӑ�ł̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string customercode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, customercode, 0, null);
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)��������(���Ӑ�i����)
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSubSection��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customercode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="prevSubSection">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�̌����������s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string customercode, ConstantManagement.LogicalMode logicalMode, PmTabTtlStCust prevSubSection)
        {
            // ������
            retList = new ArrayList();
            retTotalCnt = 0;

            // �߂�l���X�g
            ArrayList wkList = new ArrayList();
            
            // ���������Z�b�g
            PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();
            if (prevSubSection != null) pmTabTtlStCustWork = CopyToSubSectionWorkFromSubSection(prevSubSection);

            pmTabTtlStCustWork.EnterpriseCode = enterpriseCode;
            pmTabTtlStCustWork.CustomerCode = ToInt(customercode);

            // Search�p�����[�^
            ArrayList paraList = new ArrayList();
            paraList.Add( pmTabTtlStCustWork );
            object paraobj = paraList;

            // ����
            object retobj = null;

			int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			// �����[�g
            status_o = this._ipmTabTtlStCustDB.Search(out retobj, paraobj, 0, logicalMode);

            // �������ʔ���
            switch (status_o) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL: 
                    wkList = retobj as ArrayList;

                    if (wkList != null) {
                        foreach (PmTabTtlStCustWork wkLineupWork in wkList) {
                            if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((customercode.TrimEnd() == "") || (wkLineupWork.CustomerCode.ToString().TrimEnd() == customercode.TrimEnd()) || (wkLineupWork.CustomerCode == 0) ))
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

        #region MemberCopy Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���[�N�N���X�˃^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�j
        /// </summary>
        /// <param name="pmTabTtlStCustWork">�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���[�N�N���X</param>
        /// <returns>�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���[�N�N���X����^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStCust CopyToSubSectionFromSubSectionWork(PmTabTtlStCustWork pmTabTtlStCustWork)
        {
            PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();

            pmTabTtlStCust.CreateDateTime = pmTabTtlStCustWork.CreateDateTime;
            pmTabTtlStCust.UpdateDateTime = pmTabTtlStCustWork.UpdateDateTime;
            pmTabTtlStCust.FileHeaderGuid = pmTabTtlStCustWork.FileHeaderGuid;
            pmTabTtlStCust.LogicalDeleteCode = pmTabTtlStCustWork.LogicalDeleteCode;
            pmTabTtlStCust.EnterpriseCode = pmTabTtlStCustWork.EnterpriseCode;

            pmTabTtlStCust.LogicalDeleteCode = pmTabTtlStCustWork.LogicalDeleteCode;
            pmTabTtlStCust.CustomerCode = pmTabTtlStCustWork.CustomerCode.ToString();
            pmTabTtlStCust.CustomerNm = pmTabTtlStCustWork.CustomerNm;
            pmTabTtlStCust.BlpSendDiv = pmTabTtlStCustWork.BlpSendDiv;

            return pmTabTtlStCust;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�˃^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���[�N�N���X�j
        /// </summary>
        /// <param name="pmTabTtlStCust">�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�N���X</param>
        /// <returns>�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���[�N</returns>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)����^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private PmTabTtlStCustWork CopyToSubSectionWorkFromSubSection(PmTabTtlStCust pmTabTtlStCust)
        {
            PmTabTtlStCustWork pmTabTtlStCustWork = new PmTabTtlStCustWork();

            pmTabTtlStCustWork.CreateDateTime = pmTabTtlStCust.CreateDateTime;
            pmTabTtlStCustWork.UpdateDateTime = pmTabTtlStCust.UpdateDateTime;
            pmTabTtlStCustWork.EnterpriseCode = pmTabTtlStCust.EnterpriseCode;
            pmTabTtlStCustWork.FileHeaderGuid = pmTabTtlStCust.FileHeaderGuid;

            pmTabTtlStCustWork.LogicalDeleteCode = pmTabTtlStCust.LogicalDeleteCode;
            pmTabTtlStCustWork.CustomerCode = this.ToInt(pmTabTtlStCust.CustomerCode);
            pmTabTtlStCustWork.BlpSendDiv = pmTabTtlStCust.BlpSendDiv;

            return pmTabTtlStCustWork;
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
        private PmTabTtlStCust CopyToSubSectionFromGuideData(Hashtable guideData)
        {
            PmTabTtlStCust pmTabTtlStCust = new PmTabTtlStCust();

            pmTabTtlStCust.CustomerCode = (string)guideData[GUIDE_CUSTOMERCODE_TITLE];                     // ���Ӑ�R�[�h

            return pmTabTtlStCust;
        }

        /// <summary>
        /// DataRow�R�s�[�����i�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�N���X�˃K�C�h�pDataRow�j
        /// </summary>
        /// <param name="guideRow">�K�C�h�pDataRow</param>
        /// <param name="pmTabTtlStCust">�^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�N���X</param>
        /// <remarks>
        /// <br>Note       : �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�N���X����K�C�h�pDataRow�փR�s�[���s���܂��B</br>
        /// <br>Programmer : ���|��</br>
        /// <br>Date       : 2013/05/31</br>
        /// </remarks>
        private void CopyToGuideRowFromSubSection(ref DataRow guideRow, PmTabTtlStCust pmTabTtlStCust)
        {
            guideRow[GUIDE_CUSTOMERCODE_TITLE] = pmTabTtlStCust.CustomerCode;            // ���Ӑ�R�[�h
            guideRow[GUIDE_CUSTOMERCODENM_TITLE] = pmTabTtlStCust.CustomerNm;
        }

        #endregion

        #region[ToInt]
        /// <summary>
        /// �����񁨐��l�@�ϊ�
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt(string text)
        {
            try
            {
                return Convert.ToInt32(text);
            }
            catch
            {
                return 0;
            }
        }
        #endregion 
    }
}
