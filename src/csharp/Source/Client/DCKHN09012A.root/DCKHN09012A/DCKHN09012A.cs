using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.08.09</br>
	/// <br>Update Note: 2008.01.31 30167 ���@�O�M</br>
	/// <br>			 ���[�J���c�a�Ή�</br>
    /// <br>Update Note: 2008/06/04 30414 �E�@�K�j</br>
    /// <br>			 ���_�e�[�u���폜</br>
    /// <br>Update Note: 2008/09/16 30452 ���@�r��</br>
    /// <br>			 ���_���̎擾�����ǉ�</br>
    /// <br>			 ����K�C�h�̕���R�[�h��0���ߏ�����ǉ�</br>
    /// </remarks>
    public class SubSectionAcs : IGeneralGuideData
    {
        # region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        ISubSectionDB _isubsectionDB = null;

		//----- ueno add ---------- start 2008.01.31
		private SubSectionLcDB _subSectionLcDB = null;
		//----- ueno add ---------- end 2008.01.31

        // �L���b�V���p�n�b�V���e�[�u��
        static private Hashtable _SubSectionTable = null;

        // �K�C�h�ݒ�t�@�C����
        private const string GUIDE_XML_FILENAME = "SUBSECTIONGUIDEPARENT.XML";   // XML�t�@�C����

        // �K�C�h�p�����[�^
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";             // ��ƃR�[�h

        // �K�C�h���ڃ^�C�v
        private const string GUIDE_TYPE_STR = "System.String";              // String�^

        // �K�C�h���ږ�
        private const string GUIDE_SECTIONCODE_TITLE = "SectionCode";                // ���_�R�[�h
        private const string GUIDE_SECTIONNM_TITLE = "SectionGuideNm";                // ���_����
        private const string GUIDE_SUBSECTIONCODE_TITLE = "SubSectionCode";              // ����R�[�h
        private const string GUIDE_SUBSECTIONNAME_TITLE = "SubSectionName";              // ���喼��

		//----- ueno add ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g
		//----- ueno add ---------- end 2008.01.31

        // --- ADD 2008/09/16 -------------------------------->>>>>
        private SecInfoAcs   _secInfoAcs; // ���_���A�N�Z�X�N���X
        // --- ADD 2008/09/16 --------------------------------<<<<<
        
        # endregion

        # region Constructor

        /// <summary>
        /// ����e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public SubSectionAcs()
        {
            _SubSectionTable = null;
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._isubsectionDB = (ISubSectionDB)MediationSubSectionDB.GetSubSectionDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._isubsectionDB = null;
            }
            
			//----- ueno add ---------- start 2008.01.31
			// ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
			this._subSectionLcDB = new SubSectionLcDB();
			//----- ueno add ---------- end 2008.01.31

            // --- ADD 2008/09/16 -------------------------------->>>>>
            this._secInfoAcs = new SecInfoAcs(1); // �����[�g
            this._secInfoAcs.ResetSectionInfo();
            // --- ADD 2008/09/16 --------------------------------<<<<<
        }

        # endregion

		//----- ueno add ---------- start 2008.01.31
		#region Public Property

		//================================================================================
		//  �v���p�e�B
		//================================================================================
		/// <summary>
		/// ���[�J���c�aRead���[�h
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		#endregion
		//----- ueno add ---------- end 2008.01.31

        #region GetOnlineMode

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._isubsectionDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        #region Read Methods

        /// <summary>
        /// ����ǂݍ��ݏ���
        /// </summary>
        /// <param name="subsection">����I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="subsectionCode">����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������ǂݍ��݂܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Read(out SubSection subsection, string enterpriseCode, string sectionCode, int subsectionCode)
        {
            try
            {
                subsection = null;
                int status = 0;
                SubSectionWork subsectionWork = new SubSectionWork();
                subsectionWork.EnterpriseCode = enterpriseCode;
                subsectionWork.SectionCode = sectionCode;
                subsectionWork.SubSectionCode = subsectionCode;

				//----- ueno upd ---------- start 2008.01.31
				if (_isLocalDBRead)
				{
					status = this._subSectionLcDB.Read(ref subsectionWork, 0);
				}
				else
				{
					// XML�֕ϊ����A������̃o�C�i����
					byte[] parabyte = XmlByteSerializer.Serialize(subsectionWork);
					status = this._isubsectionDB.Read(ref parabyte, 0);

					if (status == 0)
					{
						// XML�̓ǂݍ���
						subsectionWork = ( SubSectionWork ) XmlByteSerializer.Deserialize(parabyte, typeof(SubSectionWork));
						//// �N���X�������o�R�s�[
						//subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);
					}
				}
				
				if (status == 0)
				{
					// �N���X�������o�R�s�[
					subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);
				}
				//----- ueno upd ---------- end 2008.01.31

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                subsection = null;
                //�I�t���C������null���Z�b�g
                this._isubsectionDB = null;
                return -1;
            }
        }

        #endregion

        #region Write Methods

        /// <summary>
        /// ����o�^�E�X�V����
        /// </summary>
        /// <param name="subsection">����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Write(ref SubSection subsection)
        {
            // ����N���X���畔�像�[�J�[�N���X�Ƀ����o�R�s�[
            SubSectionWork subsectionWork = CopyToSubSectionWorkFromSubSection(subsection);

            ArrayList paraList = new ArrayList();

            paraList.Add(subsectionWork);

            object paraObj = paraList;
            int status = 0;
            try
            {
                //���发������
                status = this._isubsectionDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    subsectionWork = (SubSectionWork)paraList[0];

                    // �N���X�������o�R�s�[
                    subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);

                    // �L���b�V���X�V
                    UpdateCache(subsection);

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
        /// ����_���폜����
        /// </summary>
        /// <param name="subsection">����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������̘_���폜���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int LogicalDelete(ref SubSection subsection)
        {
            int status = 0;

            try
            {
                // ����ϊ�
                ArrayList paraLst = new ArrayList();
                SubSectionWork subsectionWork = CopyToSubSectionWorkFromSubSection(subsection);
                paraLst.Add(subsectionWork);
                object paraObj = paraLst;

                // �_���폜
                status = this._isubsectionDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    subsectionWork = (SubSectionWork)paraLst[0];
                    // �N���X�������o�R�s�[
                    subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);

                    // �L���b�V���X�V
                    UpdateCache(subsection);

                    //SubSection deleteLineup = new SubSection();
                    //deleteLineup.EnterpriseCode = subsection.EnterpriseCode;
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._isubsectionDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// ����_���폜��������
        /// </summary>
        /// <param name="subsection">����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������̕������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Revival(ref SubSection subsection)
        {
            try
            {
                SubSectionWork subsectionWork = CopyToSubSectionWorkFromSubSection(subsection);
                ArrayList paraLst = new ArrayList();

                paraLst.Add(subsectionWork);

                object paraObj = paraLst;

                // ��������
                int status = this._isubsectionDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraLst = (ArrayList)paraObj;
                    subsectionWork = (SubSectionWork)paraLst[0];
                    // �N���X�������o�R�s�[
                    subsection = CopyToSubSectionFromSubSectionWork(subsectionWork);

                    UpdateCache(subsection);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._isubsectionDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// ���啨���폜����
        /// </summary>
        /// <param name="subsection">����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������̕����폜���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Delete(SubSection subsection)
        {
            try
            {
                SubSectionWork subsectionWork = CopyToSubSectionWorkFromSubSection(subsection);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(subsectionWork);

                // ���啨���폜
                int status = this._isubsectionDB.Delete(parabyte);

                if (status == 0)
                {
                    RemoveCache(subsection);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._isubsectionDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// ����S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", 0, null);
        }

        /// <summary>
        /// ����S��������(���_�i����)�i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="sectionCode">���_�R�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�ł̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, 0, null);
        }

        /// <summary>
        /// ���匟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// ���匟������(���_�i�荞��)�i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="sectionCode">����R�[�h</param>		        
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�ł̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, null);
        }

        /// <summary>
        /// ���匟������(���_�i����)
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSubSection��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="prevSubSection">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����̌����������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, SubSection prevSubSection)
        {
            // ������
            retList = new ArrayList();
            retTotalCnt = 0;

            // �߂�l���X�g
            ArrayList wkList = new ArrayList();
            
            // ���������Z�b�g
            SubSectionWork subsectionWork = new SubSectionWork();
            if (prevSubSection != null) subsectionWork = CopyToSubSectionWorkFromSubSection(prevSubSection);

            subsectionWork.EnterpriseCode = enterpriseCode;
            subsectionWork.SectionCode = sectionCode;

            // Search�p�����[�^
            ArrayList paraList = new ArrayList();
            paraList.Add( subsectionWork );
            object paraobj = paraList;

            // ����
            object retobj = null;

			//----- ueno upd ---------- start 2008.01.31
			int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			if (_isLocalDBRead)
			{
				// ���[�J��
				List<SubSectionWork> subSectionWorkList = new List<SubSectionWork>();
				status_o = this._subSectionLcDB.Search(out subSectionWorkList, subsectionWork, 0, logicalMode);
				
				if(status_o == 0)
				{
					ArrayList al = new ArrayList();
					al.AddRange(subSectionWorkList);
					retobj = (object)al;
				}
			}
			else
			{
				// �����[�g
	            status_o = this._isubsectionDB.Search(out retobj, paraobj, 0, logicalMode);
			}
			//----- ueno upd ---------- end 2008.01.31

            // �������ʔ���
            switch (status_o) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL: 
                    wkList = retobj as ArrayList;

                    if (wkList != null) {
                        foreach (SubSectionWork wkLineupWork in wkList) {
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


        /// <summary>
        /// ����}�X�^���������i���[�J��DB(�K�C�h)�p�j
        /// </summary>
        /// <param name="retList">�擾���ʊi�[�pArrayList</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����}�X�^�̃��[�J��DB�����������s���A�擾���ʂ�ArryList�ŕԂ��܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int SearchLocalDB(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            SubSectionWork subsectionWork = new SubSectionWork();
            subsectionWork.EnterpriseCode = enterpriseCode;
            subsectionWork.SectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            int status = 0;

            List<SubSectionWork> subsectionWorkList = null;

            status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if (subsectionWorkList != null) {
                        foreach (SubSectionWork wkLineupWork in subsectionWorkList) {
                            if ((wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.SectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.SectionCode.TrimEnd() == "")))
                            {
                                //�����o�R�s�[
                                retList.Add(CopyToSubSectionFromSubSectionWork(wkLineupWork));
                            }
                        }
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }

            return status;
        }


        #endregion

        // --- ADD 2008/09/16 -------------------------------->>>>>
        #region ���_���̎擾 Methods
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30452 ��� �r��</br>
        /// <br>Date       : 2008/09/16</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            ArrayList retList = new ArrayList();

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
        // --- ADD 2008/09/16 --------------------------------<<<<<

        #region Cache Methods

        /// <summary>
        /// �L���b�V�����f�[�^�o�^�X�V����
        /// </summary>
        /// <param name="subsection">����I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �L���b�V�����̃f�[�^�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void UpdateCache(SubSection subsection)
        {
            if (_SubSectionTable == null) {
                _SubSectionTable = new Hashtable();
            }

            Hashtable subsectionTable = null;		// ����R�[�h�ʃn�b�V���e�[�u��

            // �n�b�V���e�[�u���ɋ��_���o�^����Ă���
            if (_SubSectionTable.ContainsKey(subsection.SectionCode) == true) {
                // ����R�[�h�ʃn�b�V���e�[�u���擾
                subsectionTable = (Hashtable)_SubSectionTable[subsection.SectionCode];
            }
            // �n�b�V���e�[�u���ɋ��_���o�^����Ă��Ȃ�
            else {
                // ����R�[�h�ʃn�b�V���e�[�u���𐶐�
                subsectionTable = new Hashtable();
                // ���_�ʃn�b�V���e�[�u���ɒǉ�
                _SubSectionTable.Add(subsection.SectionCode, subsectionTable);
            }
        }

        /// <summary>
        /// �L���b�V�����f�[�^�폜����
        /// </summary>
        /// <param name="SubSection">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �L���b�V�����f�[�^����w�肳�ꂽ����I�u�W�F�N�g���폜���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void RemoveCache(SubSection SubSection)
        {
            if (_SubSectionTable == null) {
                // �f�[�^�����݂��Ă��Ȃ�
                return;
            }

            Hashtable subsectionTable = null;		// ����R�[�h�ʃn�b�V���e�[�u��

            // �n�b�V���e�[�u���ɋ��_���o�^����Ă���
            if (_SubSectionTable.ContainsKey(SubSection.SectionCode) == false) {
                // �f�[�^�����݂��Ă��Ȃ�
                return;
            }
            // ����R�[�h�ʃn�b�V���e�[�u���擾
            subsectionTable = (Hashtable)_SubSectionTable[SubSection.SectionCode];
        }

        # endregion

        #region MemberCopy Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���像�[�N�N���X�˕���j
        /// </summary>
        /// <param name="subsectionWork">���像�[�N�N���X</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : ���像�[�N�N���X���畔��փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private SubSection CopyToSubSectionFromSubSectionWork(SubSectionWork subsectionWork)
        {
            SubSection subsection = new SubSection();

            subsection.CreateDateTime = subsectionWork.CreateDateTime;
            subsection.UpdateDateTime = subsectionWork.UpdateDateTime;
            subsection.FileHeaderGuid = subsectionWork.FileHeaderGuid;
            subsection.LogicalDeleteCode = subsectionWork.LogicalDeleteCode;
            subsection.EnterpriseCode = subsectionWork.EnterpriseCode;

            subsection.LogicalDeleteCode = subsectionWork.LogicalDeleteCode;
            subsection.SectionCode = subsectionWork.SectionCode;
            //subsection.SectionGuideNm = subsectionWork.SectionGuideNm;  // DEL 2008/06/04
            subsection.SubSectionCode = subsectionWork.SubSectionCode;
            subsection.SubSectionName = subsectionWork.SubSectionName;

            return subsection;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i����˕��像�[�N�N���X�j
        /// </summary>
        /// <param name="subsection">����N���X</param>
        /// <returns>���像�[�N</returns>
        /// <remarks>
        /// <br>Note       : ���傩�畔�像�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private SubSectionWork CopyToSubSectionWorkFromSubSection(SubSection subsection)
        {
            SubSectionWork subsectionWork = new SubSectionWork();

            subsectionWork.CreateDateTime = subsection.CreateDateTime;
            subsectionWork.UpdateDateTime = subsection.UpdateDateTime;
            subsectionWork.EnterpriseCode = subsection.EnterpriseCode;
            subsectionWork.FileHeaderGuid = subsection.FileHeaderGuid;

            subsectionWork.LogicalDeleteCode = subsection.LogicalDeleteCode;
            subsectionWork.SectionCode = subsection.SectionCode;
            //subsectionWork.SectionGuideNm = subsection.SectionGuideNm;  // DEL 2008/06/04
            subsectionWork.SubSectionCode = subsection.SubSectionCode;
            subsectionWork.SubSectionName = subsection.SubSectionName;

            return subsectionWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[���� (�K�C�h�I���f�[�^�ˎd��Ȗڐݒ�}�X�^�N���X)
        /// </summary>
        /// <param name="guideData">�K�C�h�I���f�[�^</param>
        /// <returns>�d��Ȗڐݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�I���f�[�^����d��Ȗڐݒ�}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private SubSection CopyToSubSectionFromGuideData(Hashtable guideData)
        {
            SubSection subsection = new SubSection();

            subsection.SectionCode = (string)guideData[GUIDE_SECTIONCODE_TITLE];                     // ���_�R�[�h
            //subsection.SectionGuideNm = ( string ) guideData[GUIDE_SECTIONNM_TITLE];                      // ���_����  // DEL 2008/06/04
            subsection.SubSectionCode = ToInt(guideData[GUIDE_SUBSECTIONCODE_TITLE].ToString());     // ����R�[�h
            subsection.SubSectionName = (string) guideData[GUIDE_SUBSECTIONNAME_TITLE];              // ���喼��

            return subsection;
        }

        /// <summary>
        /// DataRow�R�s�[�����i����N���X�˃K�C�h�pDataRow�j
        /// </summary>
        /// <param name="guideRow">�K�C�h�pDataRow</param>
        /// <param name="subsection">����N���X</param>
        /// <remarks>
        /// <br>Note       : ����N���X����K�C�h�pDataRow�փR�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void CopyToGuideRowFromSubSection(ref DataRow guideRow, SubSection subsection)
        {
            guideRow[GUIDE_SECTIONCODE_TITLE] = subsection.SectionCode;            // ���_�R�[�h
            //guideRow[GUIDE_SECTIONNM_TITLE] = subsection.SectionGuideNm;                // ���_����  // DEL 2008/06/04
            // --- ADD 2008/09/16 -------------------------------->>>>>
            guideRow[GUIDE_SECTIONNM_TITLE] = this.GetSectionName(subsection.SectionCode);
            // --- ADD 2008/09/16 --------------------------------<<<<<
            // --- DEL 2008/09/16 -------------------------------->>>>>
            //guideRow[GUIDE_SUBSECTIONCODE_TITLE] = subsection.SubSectionCode.ToString();
            // --- DEL 2008/09/16 --------------------------------<<<<< 
            // --- ADD 2008/09/16 -------------------------------->>>>>
            guideRow[GUIDE_SUBSECTIONCODE_TITLE] = subsection.SubSectionCode.ToString("00");      // ����R�[�h
            // --- ADD 2008/09/16 --------------------------------<<<<<
            guideRow[GUIDE_SUBSECTIONNAME_TITLE] = subsection.SubSectionName;      // ���喼��
        }

        #endregion

        #region Guide Methods

        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
		/// <param name="subsection">�擾�f�[�^</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int ExecuteGuid(out SubSection subsection, string enterpriseCode, string sectionCode)
        {
            int status = -1;
            subsection = new SubSection();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);   // ��ƃR�[�h
            //inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);        // ���_�R�[�h  // DEL 2008/06/04

            // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
            if (sectionCode != "")
            {
                inObj.Add(GUIDE_SECTIONCODE_TITLE, sectionCode);
            }
            // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

            // �K�C�h�N��
            if (tableGuideParent.Execute(0, inObj, ref retObj)) {
                // �I���f�[�^�̎擾
                subsection = CopyToSubSectionFromGuideData(retObj);
                status = 0;
            }
            else {
                // �L�����Z��
                status = 1;
            }

            return status;
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="subsection">�擾�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int ExecuteGuid(out SubSection subsection, string enterpriseCode)
        {
            int status = -1;
            status = ExecuteGuid(out subsection, enterpriseCode, "");

            return status;
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note	   : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            string sectionCode = "";

            if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_PARA)) {
                // ��ƃR�[�h�ݒ�L��
                enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
            }
            else {
                // ��ƃR�[�h�ݒ薳��
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // ���_�R�[�h�ݒ�L��
            if (inParm.ContainsKey(GUIDE_SECTIONCODE_TITLE)) {
                sectionCode = inParm[GUIDE_SECTIONCODE_TITLE].ToString();
            }

            // �}�X�^�e�[�u���Ǎ���(���[�J��DB�ɕύX)
            ArrayList retList;
            status = this.SearchAll( out retList, enterpriseCode, sectionCode );

            switch (status) {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    List<SubSection> subSectionList = new List<SubSection>();
                    foreach (SubSection subSection in retList)
                    {
                        if (subSection.LogicalDeleteCode == 0)
                        {
                            subSectionList.Add(subSection.Clone());
                        }
                    }

                    subSectionList.Sort(delegate(SubSection x, SubSection y)
                    {
                        if (x.SectionCode.Trim().CompareTo(y.SectionCode.Trim()) == 0)
                        {
                            return x.SubSectionCode - y.SubSectionCode;
                        }
                        else
                        {
                            return x.SectionCode.Trim().CompareTo(y.SectionCode.Trim());
                        }

                    });

                    retList = new ArrayList();
                    foreach (SubSection subSection in subSectionList)
                    {
                        retList.Add(subSection.Clone());
                    }

                    // �K�C�h�����N����
                    if (guideList.Tables.Count == 0) {
                        // �K�C�h�p�f�[�^�Z�b�g����\�z
                        this.GuideDataSetColumnConstruction(ref guideList);
                    }

                    // �K�C�h�p�f�[�^�Z�b�g�̍쐬
                    this.GetGuideDataSet(ref guideList, retList, inParm);

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    status = 4;
                    break;
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g�쐬����
        /// </summary>
        /// <param name="retDataSet">���ʎ擾�f�[�^�Z�b�g</param>>
		/// <param name="retList">���ʎ擾�A���C���X�g</param>>
		/// <param name="inParm">�i������</param>>
        /// <remarks>
        /// <br>Note	   : �K�C�h�p�f�[�^�Z�b�g�������s�Ȃ�</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, ArrayList retList, Hashtable inParm)
        {
            SubSection subsection = null;
            DataRow guideRow = null;

            // �s�����������ĐV�����f�[�^��ǉ�
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while (dataCnt < retList.Count)
            {
                subsection = (SubSection)retList[dataCnt];
                guideRow = retDataSet.Tables[0].NewRow();
                // �f�[�^�R�s�[����
                CopyToGuideRowFromSubSection(ref guideRow, subsection);
                // �f�[�^�ǉ�
                retDataSet.Tables[0].Rows.Add(guideRow);

                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="guideList">�K�C�h�p�f�[�^�Z�b�g</param>>
        /// <remarks>
        /// <br>Note       : �K�C�h�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.08.09</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction(ref DataSet guideList)
        {
            DataTable table = new DataTable();
            DataColumn column;

            // ���_�R�[�h
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = GUIDE_SECTIONCODE_TITLE;
            table.Columns.Add(column);

            // ���_�R�[�h
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = GUIDE_SECTIONNM_TITLE;
            table.Columns.Add(column);
            
            // ����R�[�h
            column = new DataColumn();
            // --- DEL 2008/09/16 -------------------------------->>>>>
            //column.DataType = typeof(int);
            // --- DEL 2008/09/16 --------------------------------<<<<<
            // --- ADD 2008/09/16 -------------------------------->>>>>
            column.DataType = typeof(string);
            // --- ADD 2008/09/16 --------------------------------<<<<<
            column.ColumnName = GUIDE_SUBSECTIONCODE_TITLE;
            table.Columns.Add(column);

            // ���喼��
            column = new DataColumn();
            column.DataType = typeof(string);
            column.ColumnName = GUIDE_SUBSECTIONNAME_TITLE;
            table.Columns.Add(column);


            // �e�[�u���R�s�[
            guideList.Tables.Add(table.Clone());
        }

        #endregion

        /// <summary>
        /// �����񁨐��l�@�ϊ�
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt( string text ) 
        {
            try {
                return Convert.ToInt32( text );
            }
            catch {
                return 0;
            }
        }
    }
}
