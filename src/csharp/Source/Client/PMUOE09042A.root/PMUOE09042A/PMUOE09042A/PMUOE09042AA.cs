using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE���Ѓ}�X�^ �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE���Ѓ}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.06.25</br>
    /// <br></br>
    /// </remarks>
    public class UOESettingAcs
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        // UOE���Ѓ}�X�^
        private IUOESettingDB _iUOESettingDB = null;
        
        #endregion

        #region Constructor

        /// <summary>
        /// UOE���Ѓ}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE���Ѓ}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public UOESettingAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iUOESettingDB = (IUOESettingDB)MediationUOESettingDB.GetUOESettingDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESettingDB = null;
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
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iUOESettingDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// UOE���Ѓ}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="uoeSetting">UOE���ЃI�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : UOE���Џ���ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Read(out UOESetting uoeSetting, string enterpriseCode, string sectionCode)
        {
            try
            {
                // �L�[���̐ݒ�
                uoeSetting = null;
                UOESettingWork uoeSettingWork = new UOESettingWork();
                uoeSettingWork.EnterpriseCode = enterpriseCode;
                uoeSettingWork.SectionCode = sectionCode;
                // UOE���Ѓ��[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)uoeSettingWork;
                
                //UOE���Ѓ}�X�^�ǂݍ���
                int status = this._iUOESettingDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // �ǂݍ��݌��ʂ�UOE���Ѓ��[�J�[�N���X�ɐݒ�
                    UOESettingWork wkUOESettingWork = (UOESettingWork)paraObj;
                    // UOE���Ѓ��[�J�[�N���X����UOE���ЃN���X�ɃR�s�[
                    uoeSetting = CopyToUOESettingFromUOESettingWork(wkUOESettingWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESettingDB = null;
                //�ʐM�G���[��-1��߂�
                uoeSetting = null;
                return -1;
            }
        }

        /// <summary>
        /// UOE���ЃV���A���C�Y����
        /// </summary>
        /// <param name="uoeSetting">�V���A���C�Y�Ώ�UOE���ЃN���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : UOE���Ђ̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public void Serialize(UOESetting uoeSetting, string fileName)
        {
            // UOE���ЃN���X����UOE���Ѓ��[�J�[�N���X�Ƀ����o�R�s�[
            UOESettingWork uoeSettingWork = CopyToUOESettingWorkFromUOESetting(uoeSetting);

            // UOE���Ѓ��[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(uoeSettingWork, fileName);
        }

        /// <summary>
        /// UOE����List�V���A���C�Y����
        /// </summary>
        /// <param name="arrUOESetting">�V���A���C�Y�Ώ�UOE����List�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : UOE����List���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public void ListSerialize(ArrayList uoeSettingList, string fileName)
        {
            UOESettingWork[] uoeSettingWorks = new UOESettingWork[uoeSettingList.Count];

            for (int i = 0; i < uoeSettingList.Count; i++)
            {
                uoeSettingWorks[i] = CopyToUOESettingWorkFromUOESetting((UOESetting)uoeSettingList[i]);
            }

            // UOE���Ѓ��[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(uoeSettingWorks, fileName);
        }

        /// <summary>
        /// UOE���ЃN���X�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        /// <returns>UOE���ЃN���X</returns>
        /// <remarks>
        /// <br>Note       : UOE���ЃN���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public UOESetting Deserialize(string fileName)
        {
            UOESetting uoeSetting = null;

            // �t�@�C������n����UOE���Ѓ��[�N�N���X���f�V���A���C�Y����
            UOESettingWork uoeSettingWork = (UOESettingWork)XmlByteSerializer.Deserialize(fileName, typeof(UOESettingWork));

            // �f�V���A���C�Y���ʂ�UOE���ЃN���X�փR�s�[
            if (uoeSettingWork != null) uoeSetting = CopyToUOESettingFromUOESettingWork(uoeSettingWork);

            return uoeSetting;
        }

        /// <summary>
        /// UOE���Гo�^�E�X�V����
        /// </summary>
        /// <param name="uoeSetting">UOE���ЃN���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE���Ђ̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Write(ref UOESetting uoeSetting)
        {
            UOESettingWork uoeSettingWork = new UOESettingWork();
            ArrayList paraList = new ArrayList();

            // UOE���ЃN���X����UOE���Ѓ��[�N�N���X�Ƀ����o�R�s�[
            uoeSettingWork = CopyToUOESettingWorkFromUOESetting(uoeSetting);

            // UOE���Ђ̓o�^�E�X�V����ݒ�
            paraList.Add(uoeSettingWork);
            
            object paraObj = paraList;

            int status = 0;
            try
            {
                // UOE���Џ�������
                status = this._iUOESettingDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;

                    uoeSetting = new UOESetting();

                    // UOE���Ѓ��[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                    uoeSetting = this.CopyToUOESettingFromUOESettingWork((UOESettingWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iUOESettingDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// UOE���И_���폜����
        /// </summary>
        /// <param name="uoeSettingList">UOE���ЃI�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE���Џ��̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList uoeSettingList)
        {
            int status = 0;

            try
            {
                UOESettingWork uoeSettingWork = new UOESettingWork();
                ArrayList paraList = new ArrayList();

                foreach (UOESetting wkUOESetting in uoeSettingList)
                {
                    // UOE���ЃN���X����UOE���Ѓ��[�N�N���X�Ƀ����o�R�s�[
                    uoeSettingWork = CopyToUOESettingWorkFromUOESetting(wkUOESetting);
                    // UOE���Ђ̘_���폜����ݒ�
                    paraList.Add(uoeSettingWork);
                }

                object paraObj = paraList;

                // UOE���ЃN���X�_���폜
                status = this._iUOESettingDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    uoeSettingList.Clear();

                    foreach (UOESettingWork wkUOESettingWork in paraList)
                    {
                        UOESetting uoeSetting = new UOESetting();
                        // UOE���Ѓ��[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                        uoeSetting = this.CopyToUOESettingFromUOESettingWork((UOESettingWork)wkUOESettingWork);
                        uoeSettingList.Add(uoeSetting);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESettingDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE���Е����폜����
        /// </summary>
        /// <param name="uoeSettingList">UOE���ЃI�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE���Џ��̕����폜���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Delete(ArrayList uoeSettingList)
        {
            try
            {
                UOESettingWork uoeSettingWork = new UOESettingWork();
                ArrayList paraList = new ArrayList();

                foreach (UOESetting wkUOESetting in uoeSettingList)
                {
                    // UOE���ЃN���X����UOE���Ѓ��[�N�N���X�Ƀ����o�R�s�[
                    uoeSettingWork = CopyToUOESettingWorkFromUOESetting(wkUOESetting);

                    // UOE���Ђ̓o�^�E�X�V����ݒ�
                    paraList.Add(uoeSettingWork);
                }

                object paraObj = paraList;

                // UOE���Е����폜
                int status = this._iUOESettingDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESettingDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE���И_���폜��������
        /// </summary>
        /// <param name="uoeSettingList">UOE���Ж��̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE���Џ��̕������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Revival(ref ArrayList uoeSettingList)
        {
            try
            {
                UOESettingWork uoeSettingWork = new UOESettingWork();
                ArrayList paraList = new ArrayList();

                foreach (UOESetting wkUOESetting in uoeSettingList)
                {
                    // UOE���ЃN���X����UOE���Ѓ��[�N�N���X�Ƀ����o�R�s�[
                    uoeSettingWork = CopyToUOESettingWorkFromUOESetting(wkUOESetting);
                    // UOE���Ђ̕�������ݒ�
                    paraList.Add(uoeSettingWork);
                }

                object paraobj = paraList;

                // ��������
                int status = this._iUOESettingDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    uoeSettingList.Clear();

                    foreach (UOESettingWork wkUOESettingWork in paraList)
                    {
                        UOESetting uoeSetting = new UOESetting();
                        // UOE���Ѓ��[�N�N���X����UOE���ЃN���X�Ƀ����o�R�s�[
                        uoeSetting = this.CopyToUOESettingFromUOESettingWork((UOESettingWork)wkUOESettingWork);
                        uoeSettingList.Add(uoeSetting);
                    }
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOESettingDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE���Ѓ}�X�^���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : UOE���Ђ̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.25</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            int retTotalCnt;
            bool nextData;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            status = SearchUOESetting(ref list, out retTotalCnt, out nextData, enterpriseCode, sectionCode, 0, 0);

            retList = list;

            return status;
        }

        /// <summary>
        /// UOE���Ќ��������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE���Ђ̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, string sectionCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retTotalCnt = 0;

            // UOE���Ѓ}�X�^
            status = SearchUOESetting(ref list, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetDataAll, 0);

            retList = list;

            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE���Ѓ��[�N�N���X��UOE���ЃN���X�j
        /// </summary>
        /// <param name="partsPosCodeUWork">UOE���Ѓ��[�N�N���X</param>
        /// <returns>UOE���ЃN���X</returns>
        /// <remarks>
        /// <br>Note       : UOE���Ѓ��[�N�N���X����UOE���ЃN���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private UOESetting CopyToUOESettingFromUOESettingWork(UOESettingWork uoeSettingWork)
        {
            UOESetting uoeSetting = new UOESetting();

            uoeSetting.CreateDateTime = uoeSettingWork.CreateDateTime;
            uoeSetting.UpdateDateTime = uoeSettingWork.UpdateDateTime;
            uoeSetting.EnterpriseCode = uoeSettingWork.EnterpriseCode;
            uoeSetting.FileHeaderGuid = uoeSettingWork.FileHeaderGuid;
            uoeSetting.UpdEmployeeCode = uoeSettingWork.UpdEmployeeCode;
            uoeSetting.UpdAssemblyId1 = uoeSettingWork.UpdAssemblyId1;
            uoeSetting.UpdAssemblyId2 = uoeSettingWork.UpdAssemblyId2;
            uoeSetting.LogicalDeleteCode = uoeSettingWork.LogicalDeleteCode;
            uoeSetting.SectionCode = uoeSettingWork.SectionCode;

            uoeSetting.SlipOutputDivCd = uoeSettingWork.SlipOutputDivCd;                // �`�[�o�͋敪
            uoeSetting.FollowSlipOutputDiv = uoeSettingWork.FollowSlipOutputDiv;        // �t�H���[�`�[�o�͋敪
            uoeSetting.AddUpADateDiv = uoeSettingWork.AddUpADateDiv;                    // �v����t�敪
            uoeSetting.StockBlnktPrtNoDiv = uoeSettingWork.StockBlnktPrtNoDiv;          // �݌Ɉꊇ�i�ԋ敪
            uoeSetting.MakerFollowAddUpDiv = uoeSettingWork.MakerFollowAddUpDiv;        // ���[�J�[�t�H���[�v��敪
            uoeSetting.DistEnterDiv = uoeSettingWork.DistEnterDiv;                      // �������ɍX�V�敪
            uoeSetting.DistSectionSetDiv = uoeSettingWork.DistSectionSetDiv;            // �������_�ݒ�敪
            uoeSetting.InpSearchRemark = uoeSettingWork.InpSearchRemark;                // ����͌������}�[�N
            uoeSetting.StockBlnktRemark = uoeSettingWork.StockBlnktRemark;              // �݌Ɉꊇ��[���}�[�N
            uoeSetting.SlipOutputRemark = uoeSettingWork.SlipOutputRemark;              // �`�����}�[�N
            uoeSetting.SlipOutputRemarkDiv = uoeSettingWork.SlipOutputRemarkDiv;        // �`�����}�[�N�敪

            // 2008.12.24 30413 ���� UOE�`�[���s�敪��ǉ� >>>>>>START
            uoeSetting.UOESlipPrtDiv = uoeSettingWork.UOESlipPrtDiv;                    // UOE�`�[���s�敪
            // 2008.12.24 30413 ���� UOE�`�[���s�敪��ǉ� <<<<<<END

            return uoeSetting;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUOE���ЃN���X��UOE���Ѓ��[�N�N���X�j
        /// </summary>
        /// <param name="partsPosCodeU">UOE���Ѓ��[�N�N���X</param>
        /// <returns>UOE���ЃN���X</returns>
        /// <remarks>
        /// <br>Note       : UOE���ЃN���X����UOE���Ѓ��[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private UOESettingWork CopyToUOESettingWorkFromUOESetting(UOESetting uoeSetting)
        {
            UOESettingWork uoeSettingWork = new UOESettingWork();

            uoeSettingWork.CreateDateTime = uoeSetting.CreateDateTime;
            uoeSettingWork.UpdateDateTime = uoeSetting.UpdateDateTime;
            uoeSettingWork.EnterpriseCode = uoeSetting.EnterpriseCode;
            uoeSettingWork.FileHeaderGuid = uoeSetting.FileHeaderGuid;
            uoeSettingWork.UpdEmployeeCode = uoeSetting.UpdEmployeeCode;
            uoeSettingWork.UpdAssemblyId1 = uoeSetting.UpdAssemblyId1;
            uoeSettingWork.UpdAssemblyId2 = uoeSetting.UpdAssemblyId2;
            uoeSettingWork.LogicalDeleteCode = uoeSetting.LogicalDeleteCode;
            uoeSettingWork.SectionCode = uoeSetting.SectionCode;

            uoeSettingWork.SlipOutputDivCd = uoeSetting.SlipOutputDivCd;                // �`�[�o�͋敪
            uoeSettingWork.FollowSlipOutputDiv = uoeSetting.FollowSlipOutputDiv;        // �t�H���[�`�[�o�͋敪
            uoeSettingWork.AddUpADateDiv = uoeSetting.AddUpADateDiv;                    // �v����t�敪
            uoeSettingWork.StockBlnktPrtNoDiv = uoeSetting.StockBlnktPrtNoDiv;          // �݌Ɉꊇ�i�ԋ敪
            uoeSettingWork.MakerFollowAddUpDiv = uoeSetting.MakerFollowAddUpDiv;        // ���[�J�[�t�H���[�v��敪
            uoeSettingWork.DistEnterDiv = uoeSetting.DistEnterDiv;                      // �������ɍX�V�敪
            uoeSettingWork.DistSectionSetDiv = uoeSetting.DistSectionSetDiv;            // �������_�ݒ�敪
            uoeSettingWork.InpSearchRemark = uoeSetting.InpSearchRemark;                // ����͌������}�[�N
            uoeSettingWork.StockBlnktRemark = uoeSetting.StockBlnktRemark;              // �݌Ɉꊇ��[���}�[�N
            uoeSettingWork.SlipOutputRemark = uoeSetting.SlipOutputRemark;              // �`�����}�[�N
            uoeSettingWork.SlipOutputRemarkDiv = uoeSetting.SlipOutputRemarkDiv;        // �`�����}�[�N�敪

            // 2008.12.24 30413 ���� UOE�`�[���s�敪��ǉ� >>>>>>START
            uoeSettingWork.UOESlipPrtDiv = uoeSetting.UOESlipPrtDiv;                    // UOE�`�[���s�敪
            // 2008.12.24 30413 ���� UOE�`�[���s�敪��ǉ� <<<<<<END

            return uoeSettingWork;
        }

        /// <summary>
        /// UOE���Ќ�������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE���Ђ̌����������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private int SearchUOESetting(ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            UOESettingWork uoeSettingWork = new UOESettingWork();

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
                uoeSettingWork.EnterpriseCode = enterpriseCode;
                uoeSettingWork.SectionCode = sectionCode;

                // UOE���Ѓ��[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                ArrayList list = new ArrayList();
                list.Add(uoeSettingWork);
                //object paraObj = (object)uoeSettingWork;
                object paraObj = list;

                // �S���Ǎ�
                status = this._iUOESettingDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (UOESettingWork wkUOESettingWork in workList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                UOESetting wkUOESetting = CopyToUOESettingFromUOESettingWork(wkUOESettingWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                retList.Add(wkUOESetting);
                            }
                        }
                        break;
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
    }
}
