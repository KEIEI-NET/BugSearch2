using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE�K�C�h���̃}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE�K�C�h���̃}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.06.30</br>
    /// <br></br>
    /// </remarks>
    public class UOEGuideNameAcs : IGeneralGuideData
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        // UOE�K�C�h���̃}�X�^
        private IUOEGuideNameDB _iUOEGuideNameDB = null;

        #endregion

        #region Constructor

        /// <summary>
        /// UOE�K�C�h���̃}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public UOEGuideNameAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iUOEGuideNameDB = (IUOEGuideNameDB)MediationUOEGuideNameDB.GetUOEGuideNameDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEGuideNameDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iUOEGuideNameDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// UOE�K�C�h���̃}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="uoeGuideDivCd">UOE�K�C�h�敪</param>
        /// <param name="uoeSupplierCd">UOE������R�[�h</param>
        /// <param name="uoeGuideCode">UOE�K�C�h�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̏���ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Read(out UOEGuideName uoeGuideName, string enterpriseCode, int uoeGuideDivCd, int uoeSupplierCd, string uoeGuideCode, string sectionCode)
        {
            try
            {
                // �L�[���̐ݒ�
                uoeGuideName = null;
                UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
                uoeGuideNameWork.EnterpriseCode = enterpriseCode;
                uoeGuideNameWork.UOEGuideDivCd = uoeGuideDivCd;
                uoeGuideNameWork.UOESupplierCd = uoeSupplierCd;
                uoeGuideNameWork.UOEGuideCode = uoeGuideCode;
                uoeGuideNameWork.SectionCode = sectionCode;
                // UOE�K�C�h���̃��[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)uoeGuideNameWork;

                //UOE�K�C�h���̃}�X�^�ǂݍ���
                int status = this._iUOEGuideNameDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // �ǂݍ��݌��ʂ�UOE�K�C�h���̃��[�J�[�N���X�ɐݒ�
                    UOEGuideNameWork wkUOEGuideNameWork = (UOEGuideNameWork)paraObj;
                    // UOE�K�C�h���̃��[�J�[�N���X����UOE�K�C�h���̃N���X�ɃR�s�[
                    uoeGuideName = CopyToUOEGuideNameFromUOEGuideNameWork(wkUOEGuideNameWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEGuideNameDB = null;
                //�ʐM�G���[��-1��߂�
                uoeGuideName = null;
                return -1;
            }
        }

        /// <summary>
        /// UOE�K�C�h���̃V���A���C�Y����
        /// </summary>
        /// <param name="uoeGuideName">�V���A���C�Y�Ώ�UOE�K�C�h���̃N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̂̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public void Serialize(UOEGuideName uoeGuideName, string fileName)
        {
            // UOE�K�C�h���̃N���X����UOE�K�C�h���̃��[�J�[�N���X�Ƀ����o�R�s�[
            UOEGuideNameWork uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);

            // UOE�K�C�h���̃��[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(uoeGuideNameWork, fileName);
        }

        /// <summary>
        /// UOE�K�C�h����List�V���A���C�Y����
        /// </summary>
        /// <param name="uoeGuideNameList">�V���A���C�Y�Ώ�UOE�K�C�h����List�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h����List���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public void ListSerialize(ArrayList uoeGuideNameList, string fileName)
        {
            UOEGuideNameWork[] uoeGuideNameWorks = new UOEGuideNameWork[uoeGuideNameList.Count];

            for (int i = 0; i < uoeGuideNameList.Count; i++)
            {
                uoeGuideNameWorks[i] = CopyToUOEGuideNameWorkFromUOEGuideName((UOEGuideName)uoeGuideNameList[i]);
            }

            // UOE�K�C�h���̃��[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(uoeGuideNameWorks, fileName);
        }

        /// <summary>
        /// UOE�K�C�h���̃N���X�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        /// <returns>UOE�K�C�h���̃N���X</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public UOEGuideName Deserialize(string fileName)
        {
            UOEGuideName uoeGuideName = null;

            // �t�@�C������n����UOE�K�C�h���̃��[�N�N���X���f�V���A���C�Y����
            UOEGuideNameWork uoeGuideNameWork = (UOEGuideNameWork)XmlByteSerializer.Deserialize(fileName, typeof(UOEGuideNameWork));

            // �f�V���A���C�Y���ʂ�UOE�K�C�h���̃N���X�փR�s�[
            if (uoeGuideNameWork != null) uoeGuideName = CopyToUOEGuideNameFromUOEGuideNameWork(uoeGuideNameWork);

            return uoeGuideName;
        }

        /// <summary>
        /// UOE�K�C�h���̓o�^�E�X�V����
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̂̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Write(ref UOEGuideName uoeGuideName)
        {
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
            ArrayList paraList = new ArrayList();

            // UOE�K�C�h���̃N���X����UOE�K�C�h���̃��[�N�N���X�Ƀ����o�R�s�[
            uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);

            // UOE�K�C�h���̂̓o�^�E�X�V����ݒ�
            paraList.Add(uoeGuideNameWork);

            object paraObj = paraList;

            int status = 0;
            try
            {
                // UOE�K�C�h���̏�������
                status = this._iUOEGuideNameDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;

                    uoeGuideName = new UOEGuideName();

                    // UOE�K�C�h���̃��[�N�N���X����UOE�K�C�h���̃N���X�Ƀ����o�R�s�[
                    uoeGuideName = this.CopyToUOEGuideNameFromUOEGuideNameWork((UOEGuideNameWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iUOEGuideNameDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// UOE�K�C�h���̘_���폜����
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̏��̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.26</br>
        /// </remarks>
        public int LogicalDelete(ref UOEGuideName uoeGuideName)
        {
            int status = 0;

            try
            {
                UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
                ArrayList paraList = new ArrayList();

                // UOE�K�C�h���̃N���X����UOE�K�C�h���̃��[�N�N���X�Ƀ����o�R�s�[
                uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);
                // UOE�K�C�h���̘̂_���폜����ݒ�
                paraList.Add(uoeGuideNameWork);

                object paraObj = paraList;

                // UOE�K�C�h���̃N���X�_���폜
                status = this._iUOEGuideNameDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;

                    uoeGuideName = new UOEGuideName();
                    // UOE�K�C�h���̃��[�N�N���X����UOE�K�C�h���̃N���X�Ƀ����o�R�s�[
                    uoeGuideName = this.CopyToUOEGuideNameFromUOEGuideNameWork((UOEGuideNameWork)paraList[0]);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEGuideNameDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE�K�C�h���̕����폜����
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̏��̕����폜���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Delete(UOEGuideName uoeGuideName)
        {
            try
            {
                UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
                ArrayList paraList = new ArrayList();

                // UOE�K�C�h���̃N���X����UOE�K�C�h���̃��[�N�N���X�Ƀ����o�R�s�[
                uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);
                // UOE�K�C�h���̂̕����폜����ݒ�
                paraList.Add(uoeGuideNameWork);

                object paraObj = paraList;

                // UOE�K�C�h���̕����폜
                int status = this._iUOEGuideNameDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEGuideNameDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE�K�C�h���̘_���폜��������
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̖��̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̏��̕������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int Revival(ref UOEGuideName uoeGuideName)
        {
            try
            {
                UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();
                ArrayList paraList = new ArrayList();

                // UOE�K�C�h���̃N���X����UOE�K�C�h���̃��[�N�N���X�Ƀ����o�R�s�[
                uoeGuideNameWork = CopyToUOEGuideNameWorkFromUOEGuideName(uoeGuideName);
                // UOE�K�C�h���̂̕�������ݒ�
                paraList.Add(uoeGuideNameWork);

                object paraobj = paraList;

                // ��������
                int status = this._iUOEGuideNameDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;

                    uoeGuideName = new UOEGuideName();
                    // UOE�K�C�h���̃��[�N�N���X����UOE�K�C�h���̃N���X�Ƀ����o�R�s�[
                    uoeGuideName = this.CopyToUOEGuideNameFromUOEGuideNameWork((UOEGuideNameWork)paraList[0]);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEGuideNameDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE�K�C�h���̃}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="inUOEGuideName">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int Search(ref DataSet ds, UOEGuideName inUOEGuideName)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // UOE�K�C�h���̃}�X�^�T�[�`
            status = SearchAll(out retList, inUOEGuideName);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (UOEGuideName wkUOEGuideName in wkList)
            {
                if (wkUOEGuideName.LogicalDeleteCode == 0)
                {
                    string key = wkUOEGuideName.SectionCode.Trim() +wkUOEGuideName.UOESupplierCd.ToString("d06") + wkUOEGuideName.UOEGuideDivCd.ToString("d02") + wkUOEGuideName.UOEGuideCode;
                    wkSort.Add(key, wkUOEGuideName);
                }
            }

            UOEGuideName[] uoeGuideNames = new UOEGuideName[wkSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkSort.Count; i++)
            {
                uoeGuideNames[i] = (UOEGuideName)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(uoeGuideNames);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// UOE�K�C�h���̌��������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="inUOEGuideName">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : UOE�K�C�h���̂̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۂɊ܂܂�܂���B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.07.17</br>
        /// </remarks>
        public int Search(out ArrayList retList, UOEGuideName inUOEGuideName)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOE�K�C�h���̃}�X�^�i�_���폜�܂܂Ȃ��j
            status = SearchUOEGuideName(ref list, out retTotalCnt, out nextData, inUOEGuideName, ConstantManagement.LogicalMode.GetData0, 0);

            retList = list;

            return status;
        }

        /// <summary>
        /// UOE�K�C�h���̌��������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="inUOEGuideName">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̂̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, UOEGuideName inUOEGuideName)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOE�K�C�h���̃}�X�^
            status = SearchUOEGuideName(ref list, out retTotalCnt, out nextData, inUOEGuideName, ConstantManagement.LogicalMode.GetDataAll, 0);

            retList = list;

            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE�K�C�h���̃��[�N�N���X��UOE�K�C�h���̃N���X�j
        /// </summary>
        /// <param name="uoeGuideNameWork">UOE�K�C�h���̃��[�N�N���X</param>
        /// <returns>UOE�K�C�h���̃N���X</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃��[�N�N���X����UOE�K�C�h���̃N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private UOEGuideName CopyToUOEGuideNameFromUOEGuideNameWork(UOEGuideNameWork uoeGuideNameWork)
        {
            UOEGuideName uoeGuideName = new UOEGuideName();

            uoeGuideName.CreateDateTime = uoeGuideNameWork.CreateDateTime;
            uoeGuideName.UpdateDateTime = uoeGuideNameWork.UpdateDateTime;
            uoeGuideName.EnterpriseCode = uoeGuideNameWork.EnterpriseCode;
            uoeGuideName.FileHeaderGuid = uoeGuideNameWork.FileHeaderGuid;
            uoeGuideName.UpdEmployeeCode = uoeGuideNameWork.UpdEmployeeCode;
            uoeGuideName.UpdAssemblyId1 = uoeGuideNameWork.UpdAssemblyId1;
            uoeGuideName.UpdAssemblyId2 = uoeGuideNameWork.UpdAssemblyId2;
            uoeGuideName.LogicalDeleteCode = uoeGuideNameWork.LogicalDeleteCode;

            uoeGuideName.UOEGuideDivCd = uoeGuideNameWork.UOEGuideDivCd;                    // UOE�K�C�h�敪
            uoeGuideName.UOESupplierCd = uoeGuideNameWork.UOESupplierCd;                    // UOE������R�[�h
            uoeGuideName.UOEGuideCode = uoeGuideNameWork.UOEGuideCode;                      // UOE�K�C�h�R�[�h
            uoeGuideName.UOEGuideNm = uoeGuideNameWork.UOEGuideName;                        // UOE�K�C�h����
            uoeGuideName.SectionCode = uoeGuideNameWork.SectionCode;
            
            return uoeGuideName;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE�K�C�h���̃N���X��UOE�K�C�h���̃��[�N�N���X�j
        /// </summary>
        /// <param name="uoeGuideName">UOE�K�C�h���̃��[�N�N���X</param>
        /// <returns>UOE�K�C�h���̃N���X</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̃N���X����UOE�K�C�h���̃��[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private UOEGuideNameWork CopyToUOEGuideNameWorkFromUOEGuideName(UOEGuideName uoeGuideName)
        {
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();

            uoeGuideNameWork.CreateDateTime = uoeGuideName.CreateDateTime;
            uoeGuideNameWork.UpdateDateTime = uoeGuideName.UpdateDateTime;
            uoeGuideNameWork.EnterpriseCode = uoeGuideName.EnterpriseCode;
            uoeGuideNameWork.FileHeaderGuid = uoeGuideName.FileHeaderGuid;
            uoeGuideNameWork.UpdEmployeeCode = uoeGuideName.UpdEmployeeCode;
            uoeGuideNameWork.UpdAssemblyId1 = uoeGuideName.UpdAssemblyId1;
            uoeGuideNameWork.UpdAssemblyId2 = uoeGuideName.UpdAssemblyId2;
            uoeGuideNameWork.LogicalDeleteCode = uoeGuideName.LogicalDeleteCode;

            uoeGuideNameWork.UOEGuideDivCd = uoeGuideName.UOEGuideDivCd;                    // UOE�K�C�h�敪
            uoeGuideNameWork.UOESupplierCd = uoeGuideName.UOESupplierCd;                    // UOE������R�[�h
            uoeGuideNameWork.UOEGuideCode = uoeGuideName.UOEGuideCode;                      // UOE�K�C�h�R�[�h
            uoeGuideNameWork.UOEGuideName = uoeGuideName.UOEGuideNm;                        // UOE�K�C�h����
            uoeGuideNameWork.SectionCode = uoeGuideName.SectionCode;

            return uoeGuideNameWork;
        }

        /// <summary>
        /// UOE�K�C�h���̌�������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�K�C�h���̂̌����������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.30</br>
        /// </remarks>
        private int SearchUOEGuideName(ref ArrayList retList, out int retTotalCnt, out bool nextData, UOEGuideName inUOEGuideName, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            UOEGuideNameWork uoeGuideNameWork = new UOEGuideNameWork();

            // ���f�[�^�L��������
            nextData = false;
            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // �Z�L�����e�B���x���L�[�w��
                uoeGuideNameWork.EnterpriseCode = inUOEGuideName.EnterpriseCode;
                uoeGuideNameWork.SectionCode = inUOEGuideName.SectionCode;
                uoeGuideNameWork.UOEGuideDivCd = inUOEGuideName.UOEGuideDivCd;
                uoeGuideNameWork.UOESupplierCd = inUOEGuideName.UOESupplierCd;


                // UOE�K�C�h���̃��[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)uoeGuideNameWork;
                
                // �S���Ǎ�
                status = this._iUOEGuideNameDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            workList = retObj as ArrayList;
                            if (workList != null)
                            {
                                foreach (UOEGuideNameWork wkUOESupplierWork in workList)
                                {
                                    // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                    UOEGuideName wkUOEGuideName = CopyToUOEGuideNameFromUOEGuideNameWork(wkUOESupplierWork);
                                    // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                    retList.Add(wkUOEGuideName);
                                }
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        #endregion

        #region Guid Methods

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            UOEGuideName uoeGuideName = new UOEGuideName();

            // ��ƃR�[�h�^�K�C�h�敪�^������R�[�h�ݒ�L��
            if ((inParm.ContainsKey("EnterpriseCode")) && (inParm.ContainsKey("UOEGuideDivCd")) && (inParm.ContainsKey("UOESupplierCd")) && (inParm.ContainsKey("SectionCode")))
            {
                uoeGuideName.EnterpriseCode = inParm["EnterpriseCode"].ToString();
                uoeGuideName.UOEGuideDivCd = int.Parse(inParm["UOEGuideDivCd"].ToString());
                uoeGuideName.UOESupplierCd = int.Parse(inParm["UOESupplierCd"].ToString());
                uoeGuideName.SectionCode = inParm["SectionCode"].ToString();
            }
            // ��ƃR�[�h�^�K�C�h�敪�^������R�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // UOE�K�C�h���̃}�X�^�e�[�u���Ǎ���
            status = Search(ref guideList, uoeGuideName);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// UOE�K�C�h���̃}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="uoeGuideName">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: UOE�K�C�h���̃}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.30</br>
        /// </remarks>
        public int ExecuteGuid(UOEGuideName inUOEGuideName, out UOEGuideName uoeGuideName)
        {
            int status = -1;
            uoeGuideName = new UOEGuideName();

            TableGuideParent tableGuideParent = new TableGuideParent("UOEGUIDENAMEGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", inUOEGuideName.EnterpriseCode);
            // UOE�K�C�h�敪
            inObj.Add("UOEGuideDivCd", inUOEGuideName.UOEGuideDivCd);
            // UOE������R�[�h
            inObj.Add("UOESupplierCd", inUOEGuideName.UOESupplierCd);
            // ���_�R�[�h
            inObj.Add("SectionCode", inUOEGuideName.SectionCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // ���_�R�[�h
                uoeGuideName.SectionCode = retObj["SectionCode"].ToString();
                // UOE�K�C�h�敪
                string strCode = retObj["UOEGuideDivCd"].ToString();
                uoeGuideName.UOEGuideDivCd = int.Parse(strCode);
                // UOE������R�[�h
                strCode = retObj["UOESupplierCd"].ToString();
                uoeGuideName.UOESupplierCd = int.Parse(strCode);
                // UOE�K�C�h�R�[�h
                uoeGuideName.UOEGuideCode = retObj["UOEGuideCode"].ToString();
                // UOE�K�C�h����
                uoeGuideName.UOEGuideNm = retObj["UOEGuideNm"].ToString();

                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        #endregion
    }
}
