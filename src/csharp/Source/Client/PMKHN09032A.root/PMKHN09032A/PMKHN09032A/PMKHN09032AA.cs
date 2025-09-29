
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �Ԏ햼�̃}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԏ햼�̃}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.06.12</br>
    /// <br></br>
    /// <br>Update Note : 2009/12/08 ���M �ێ�˗��B�Ή�</br>
    /// <br>             �Ԏ�I���K�C�h�Ń��[�J�[�݂̂̎w����\�ɂ���</br>
    /// <br></br>
    /// <br>Update Note : 2010/06/29 30517 �Ė� �x��</br>
    /// <br>             Mantis.15676�@�J�[���[�J�[�̂ݑI�����A���C����ʂɃ��[�J�[�R�[�h���\������Ȃ��s��̏C��</br>
    /// </remarks>
    public class ModelNameUAcs : IGeneralGuideData
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        // �Ԏ햼�̃}�X�^�i���[�U�[�j
        private IModelNameUDB _iModelNameUDB = null;
        // �Ԏ햼�̃}�X�^�i�񋟁j
        private IModelNameDB _iModelNameDB = null;
        
        #endregion

        #region Constructor

        /// <summary>
        /// �Ԏ햼�̃}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �Ԏ햼�̃}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30413 ����</br>
		/// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public ModelNameUAcs()
		{

            // ���[�J�[OP�̔���
            //this._optMaker = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

			try
			{
				// �����[�g�I�u�W�F�N�g�擾
                this._iModelNameUDB = (IModelNameUDB)MediationModelNameUDB.GetModelNameUDB();
                this._iModelNameDB = (IModelNameDB)MediationModelNameDB.GetModelNameDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
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
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iModelNameUDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// �Ԏ햼�̓ǂݍ��ݏ���
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h�j</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̏���ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Read(out ModelNameU modelNameU, string enterpriseCode, Int32 makerCode, Int32 modelCode, Int32 modelSubCode)
        {
            try
            {
                // �L�[���̐ݒ�
                modelNameU = null;
                ModelNameUWork modelNameUWork = new ModelNameUWork();
                modelNameUWork.EnterpriseCode = enterpriseCode;
                modelNameUWork.MakerCode = makerCode;
                modelNameUWork.ModelCode = modelCode;
                modelNameUWork.ModelSubCode = modelSubCode;
                
                // �Ԏ햼�̃��[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)modelNameUWork;

                //�Ԏ햼�̓ǂݍ���
                int status = this._iModelNameUDB.Read(ref paraObj, 0);
                
                if (status == 0)
                {
                    // �ǂݍ��݌��ʂ��Ԏ햼�̃��[�J�[�N���X�ɐݒ�
                    ModelNameUWork wkModelNameUWork = (ModelNameUWork)paraObj;
                    // �Ԏ햼�̃��[�J�[�N���X����Ԏ햼�̃N���X�ɃR�s�[
                    modelNameU = CopyToModelNameUFromModelNameUWork(wkModelNameUWork);
                }
                
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                //�ʐM�G���[��-1��߂�
                modelNameU = null;
                return -1;
            }
        }

        /// <summary>
        /// �Ԏ햼�̃V���A���C�Y����
        /// </summary>
        /// <param name="modelNameU">�V���A���C�Y�ΏێԎ햼�̃N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̂̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void Serialize(ModelNameU modelNameU, string fileName)
        {
            // �Ԏ햼�̃N���X����Ԏ햼�̃��[�J�[�N���X�Ƀ����o�R�s�[
            ModelNameUWork modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);

            // �Ԏ햼�̃��[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(modelNameUWork, fileName);
        }

        /// <summary>
        /// �Ԏ햼��List�V���A���C�Y����
        /// </summary>
        /// <param name="arrModelNameU">�V���A���C�Y�ΏێԎ햼��List�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �Ԏ햼��List���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public void ListSerialize(ArrayList arrModelNameU, string fileName)
        {
            ModelNameUWork[] modelNameUWorks = new ModelNameUWork[arrModelNameU.Count];

            for (int i = 0; i < arrModelNameU.Count; i++)
            {
                modelNameUWorks[i] = CopyToModelNameUWorkFromModelNameU((ModelNameU)arrModelNameU[i]);
            }

            // �Ԏ햼�̃��[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(modelNameUWorks, fileName);
        }

        /// <summary>
        /// �Ԏ햼�̃N���X�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        /// <returns>�Ԏ햼�̃N���X</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̃N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public ModelNameU Deserialize(string fileName)
        {
            ModelNameU modelNameU = null;

            // �t�@�C������n���ĎԎ햼�̃��[�N�N���X���f�V���A���C�Y����
            ModelNameUWork modelNameUWork = (ModelNameUWork)XmlByteSerializer.Deserialize(fileName, typeof(ModelNameUWork));

            // �f�V���A���C�Y���ʂ��Ԏ햼�̃N���X�փR�s�[
            if (modelNameUWork != null) modelNameU = CopyToModelNameUFromModelNameUWork(modelNameUWork);

            return modelNameU;
        }

        /// <summary>
        /// �Ԏ햼�̓o�^�E�X�V����
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̂̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int Write(ref ModelNameU modelNameU)
        {
            ModelNameUWork modelNameUWork = new ModelNameUWork();

            // �Ԏ햼�̃N���X����Ԏ햼�̃��[�N�N���X�Ƀ����o�R�s�[
            modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);
            
            // �Ԏ햼�̂̓o�^�E�X�V����ݒ�
            ArrayList paraList = new ArrayList();
            paraList.Add(modelNameUWork);
            object paraObj = paraList;

            int status = 0;
            try
            {
                // �Ԏ햼�̏�������
                status = this._iModelNameUDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // �Ԏ햼�̃N���X����Ԏ햼�̃��[�N�N���X�Ƀ����o�R�s�[
                    modelNameU = this.CopyToModelNameUFromModelNameUWork((ModelNameUWork)paraList[0]);                    
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �Ԏ햼�̘_���폜����
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : �Ԏ햼�̏��̘_���폜���s���܂��B<br />
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        public int LogicalDelete(ref ModelNameU modelNameU)
        {
            int status = 0;

            try
            {
                ModelNameUWork modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);

                ArrayList paraList = new ArrayList();
                paraList.Add(modelNameUWork);
                object paraObj = paraList;

                // �Ԏ햼�̃N���X�_���폜
                status = this._iModelNameUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // �N���X�������o�R�s�[
                    modelNameU = CopyToModelNameUFromModelNameUWork((ModelNameUWork)paraList[0]);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �Ԏ햼�̕����폜����
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : �Ԏ햼�̏��̕����폜���s���܂��B<br />
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        public int Delete(ModelNameU modelNameU)
        {
            try
            {
                ModelNameUWork modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);

                ArrayList paraList = new ArrayList();
                paraList.Add(modelNameUWork);
                object paraObj = paraList;

                // �Ԏ햼�̕����폜
                int status = this._iModelNameUDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �Ԏ햼�̘_���폜��������
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̖��̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : �Ԏ햼�̏��̕������s���܂��B<br />
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.13</br>
        /// </remarks>
        public int Revival(ref ModelNameU modelNameU)
        {
            try
            {
                ModelNameUWork modelNameUWork = CopyToModelNameUWorkFromModelNameU(modelNameU);
                ArrayList paraList = new ArrayList();
                paraList.Add(modelNameUWork);
                object paraobj = paraList;

                // ��������
                int status = this._iModelNameUDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    // �N���X�������o�R�s�[
                    modelNameU = CopyToModelNameUFromModelNameUWork((ModelNameUWork)paraList[0]);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iModelNameUDB = null;
                this._iModelNameDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �Ԏ햼�̃}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="belongMakerCode">���[�J�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.12</br>
        /// </remarks>
        public int Search(ref DataSet ds, int belongMakerCode, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // �Ԏ햼�̃}�X�^�T�[�`
            status = SearchAll(belongMakerCode, out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();
            ArrayList ar = new ArrayList();


            foreach (ModelNameU wkModelNameU in wkList)
            {
                if (wkModelNameU.LogicalDeleteCode == 0)
                {
                    if (belongMakerCode == 0)
                    {
                        wkSort.Add(wkModelNameU.Clone().ModelUniqueCode, wkModelNameU.Clone());
                    }
                    else if (belongMakerCode.Equals(wkModelNameU.MakerCode))
                    {
                        wkSort.Add(wkModelNameU.Clone().ModelUniqueCode, wkModelNameU.Clone());

                    }
                }
            }
            ar.AddRange(wkSort.Values);  // iitani a 2007.05.29


            //// --- [�S��] --- //
            //// ���̂܂ܑS���Ԃ�
            //foreach (ModelNameU wkModelNameU in wkList)
            //{
            //    if (wkModelNameU.LogicalDeleteCode == 0)
            //    {
            //        wkSort.Add(wkModelNameU.ModelUniqueCode, wkModelNameU);
            //    }
            //}

            ModelNameU[] modelNameUs = new ModelNameU[ar.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < ar.Count; i++)
            {
                //modelNameUs[i] = (ModelNameU)wkSort.GetByIndex(i);
                modelNameUs[i] = (ModelNameU)ar[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(modelNameUs);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// �Ԏ햼�̃}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="belongMakerCode">���[�J�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note		: �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.12.08</br>
        /// </remarks>
        public int Search2(ref DataSet ds, int belongMakerCode, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // �Ԏ햼�̃}�X�^�T�[�`
            status = SearchAll(belongMakerCode, out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();
            ArrayList ar = new ArrayList();

            if (wkList.Count > 0)
            {
                ModelNameU modelNameU = new ModelNameU();
                ModelNameU modelNameUnew = (ModelNameU)wkList[0];
                modelNameU.ModelUniqueCode = modelNameUnew.MakerCode * 1000000;
                modelNameU.MakerCode = modelNameUnew.MakerCode;
                wkSort.Add(modelNameU.ModelUniqueCode, modelNameU.Clone());
            }

            foreach (ModelNameU wkModelNameU in wkList)
            {
                if (wkModelNameU.LogicalDeleteCode == 0)
                {
                    if (belongMakerCode == 0)
                    {
                        wkSort.Add(wkModelNameU.Clone().ModelUniqueCode, wkModelNameU.Clone());
                    }
                    else if (belongMakerCode.Equals(wkModelNameU.MakerCode))
                    {
                        wkSort.Add(wkModelNameU.Clone().ModelUniqueCode, wkModelNameU.Clone());

                    }
                }
            }
            ar.AddRange(wkSort.Values);

            ModelNameU[] modelNameUs = new ModelNameU[ar.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < ar.Count; i++)
            {
                modelNameUs[i] = (ModelNameU)ar[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(modelNameUs);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// ���[�J�[�R�[�h�w�� �Ԏ햼�̌��������i�_���폜�܂ށj
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̂̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        public int SearchAll(Int32 makerCode, out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

            // ���[�U�[
            status = SearchModelNameUProc(makerCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:

                    return status;
            }

            // ��
            //status = SearchModelNameOfrProc(makerCode, ref list, out retTotalCnt, out nextData,enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            // �������ʌ�����0���ȊO�ł���΃X�e�[�^�X��0(����)�ɐݒ�
            if (retTotalCnt != 0)
            {
                status = 0;
            }
            
            retList = list;
            
            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�Ԏ햼�̃��[�N�N���X�ˎԎ햼�̃N���X�j
        /// </summary>
        /// <param name="modelNameUWork">�Ԏ햼�̃��[�N�N���X</param>
        /// <returns>�Ԏ햼�̃N���X</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̃��[�N�N���X����Ԏ햼�̃N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private ModelNameU CopyToModelNameUFromModelNameUWork(ModelNameUWork modelNameUWork)
        {
            ModelNameU modelNameU = new ModelNameU();

            modelNameU.CreateDateTime = modelNameUWork.CreateDateTime;
            modelNameU.UpdateDateTime = modelNameUWork.UpdateDateTime;
            modelNameU.EnterpriseCode = modelNameUWork.EnterpriseCode;
            modelNameU.FileHeaderGuid = modelNameUWork.FileHeaderGuid;
            modelNameU.UpdEmployeeCode = modelNameUWork.UpdEmployeeCode;
            modelNameU.UpdAssemblyId1 = modelNameUWork.UpdAssemblyId1;
            modelNameU.UpdAssemblyId2 = modelNameUWork.UpdAssemblyId2;
            modelNameU.LogicalDeleteCode = modelNameUWork.LogicalDeleteCode;

            modelNameU.ModelUniqueCode = modelNameUWork.ModelUniqueCode;        // �Ԏ�R�[�h�i���j�[�N�j
            modelNameU.MakerCode = modelNameUWork.MakerCode;                    // ���[�J�[�R�[�h
            modelNameU.ModelCode = modelNameUWork.ModelCode;                    // �Ԏ�R�[�h
            modelNameU.ModelSubCode = modelNameUWork.ModelSubCode;              // �ď̃R�[�h
            modelNameU.ModelFullName = modelNameUWork.ModelFullName;            // �Ԏ햼��
            modelNameU.ModelHalfName = modelNameUWork.ModelHalfName;            // �Ԏ햼�́i�J�i�j
            modelNameU.ModelAliasName = modelNameUWork.ModelAliasName;          // �ď�
            modelNameU.OfferDate = modelNameUWork.OfferDate;                    // �񋟓��t
            modelNameU.OfferDataDiv = modelNameUWork.OfferDataDiv;              // �񋟃f�[�^�敪
            if (modelNameU.OfferDate == DateTime.MinValue)
            {
                modelNameU.Division = 0;
                modelNameU.DivisionName = "���[�U�[";
            }
            else
            {
                modelNameU.Division = 1;
                modelNameU.DivisionName = "��";
            }
            return modelNameU;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�Ԏ햼�̃N���X�ˎԎ햼�̃��[�N�N���X�j
        /// </summary>
        /// <param name="modelNameU">�Ԏ햼�̃��[�N�N���X</param>
        /// <returns>�Ԏ햼�̃N���X</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̃N���X����Ԏ햼�̃��[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private ModelNameUWork CopyToModelNameUWorkFromModelNameU(ModelNameU modelNameU)
        {
            ModelNameUWork modelNameUWork = new ModelNameUWork();

            modelNameUWork.CreateDateTime = modelNameU.CreateDateTime;
            modelNameUWork.UpdateDateTime = modelNameU.UpdateDateTime;
            modelNameUWork.EnterpriseCode = modelNameU.EnterpriseCode;
            modelNameUWork.FileHeaderGuid = modelNameU.FileHeaderGuid;
            modelNameUWork.UpdEmployeeCode = modelNameU.UpdEmployeeCode;
            modelNameUWork.UpdAssemblyId1 = modelNameU.UpdAssemblyId1;
            modelNameUWork.UpdAssemblyId2 = modelNameU.UpdAssemblyId2;
            modelNameUWork.LogicalDeleteCode = modelNameU.LogicalDeleteCode;

            modelNameUWork.ModelUniqueCode = modelNameU.ModelUniqueCode;        // �Ԏ�R�[�h�i���j�[�N�j
            modelNameUWork.MakerCode = modelNameU.MakerCode;                    // ���[�J�[�R�[�h
            modelNameUWork.ModelCode = modelNameU.ModelCode;                    // �Ԏ�R�[�h
            modelNameUWork.ModelSubCode = modelNameU.ModelSubCode;              // �ď̃R�[�h
            modelNameUWork.ModelFullName = modelNameU.ModelFullName;            // �Ԏ햼��
            modelNameUWork.ModelHalfName = modelNameU.ModelHalfName;            // �Ԏ햼�́i�J�i�j
            modelNameUWork.ModelAliasName = modelNameU.ModelAliasName;          // �ď�
            modelNameUWork.OfferDate = modelNameU.OfferDate;                    // �񋟓��t
            modelNameUWork.OfferDataDiv = modelNameU.OfferDataDiv;              // �񋟃f�[�^��

            return modelNameUWork;
        }

        ///// <summary>
        ///// �N���X�����o�[�R�s�[�����i�Ԏ햼�́i�񋟁j���[�N�N���X�ˎԎ햼�̃N���X�j
        ///// </summary>
        ///// <param name="modelNameWork">�Ԏ햼�́i�񋟁j���[�N�N���X</param>
        ///// <returns>�Ԏ햼�̃N���X</returns>
        ///// <remarks>
        ///// <br>Note       : �Ԏ햼�́i�񋟁j���[�N�N���X����Ԏ햼�̃N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.16</br>
        ///// </remarks>
        //private ModelNameU CopyToModelNameUFromModelNameWork(ModelNameWork modelNameWork)
        //{
        //    ModelNameU modelNameU = new ModelNameU();

        //    modelNameU.ModelUniqueCode = modelNameWork.ModelUniqueCode;         // �Ԏ�R�[�h�i���j�[�N�j
        //    modelNameU.MakerCode = modelNameWork.MakerCode;                     // ���[�J�[�R�[�h
        //    modelNameU.ModelCode = modelNameWork.ModelCode;                     // �Ԏ�R�[�h
        //    modelNameU.ModelSubCode = modelNameWork.ModelSubCode;               // �ď̃R�[�h
        //    modelNameU.ModelFullName = modelNameWork.ModelFullName;             // �Ԏ햼��
        //    modelNameU.ModelHalfName = modelNameWork.ModelHalfName;             // �Ԏ햼�́i�J�i�j
        //    modelNameU.ModelAliasName = modelNameWork.ModelAliasName;           // �ď�
        //    modelNameU.Division = 1;
        //    modelNameU.DivisionName = "��";

        //    return modelNameU;
        //}

        ///// <summary>
        ///// �N���X�����o�[�R�s�[�����i�Ԏ햼�̃N���X�ˎԎ햼�́i�񋟁j���[�N�N���X�j
        ///// </summary>
        ///// <param name="modelNameU">�Ԏ햼�̃��[�N�N���X</param>
        ///// <returns>�Ԏ햼�́i�񋟁j�N���X</returns>
        ///// <remarks>
        ///// <br>Note       : �Ԏ햼�̃N���X����Ԏ햼�́i�񋟁j���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.16</br>
        ///// </remarks>
        //private ModelNameWork CopyToModelNameWorkFromModelNameU(ModelNameU modelNameU)
        //{
        //    ModelNameWork modelNameWork = new ModelNameWork();

        //    modelNameWork.ModelUniqueCode = modelNameU.ModelUniqueCode;         // �Ԏ�R�[�h�i���j�[�N�j
        //    modelNameWork.MakerCode = modelNameU.MakerCode;                     // ���[�J�[�R�[�h
        //    modelNameWork.ModelCode = modelNameU.ModelCode;                     // �Ԏ�R�[�h
        //    modelNameWork.ModelSubCode = modelNameU.ModelSubCode;               // �ď̃R�[�h
        //    modelNameWork.ModelFullName = modelNameU.ModelFullName;             // �Ԏ햼��
        //    modelNameWork.ModelHalfName = modelNameU.ModelHalfName;             // �Ԏ햼�́i�J�i�j
        //    modelNameWork.ModelAliasName = modelNameU.ModelAliasName;           // �ď�

        //    return modelNameWork;
        //}

        /// <summary>
        /// �Ԏ햼�̌�������
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevModelNameU">�O��ŏI�Ԏ햼�̃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̂̌����������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.12</br>
        /// </remarks>
        private int SearchModelNameUProc(Int32 makerCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, ModelNameU prevModelNameU)
        {
            ModelNameUWork modelNameUWork = new ModelNameUWork();

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
                modelNameUWork.MakerCode = makerCode;
                modelNameUWork.EnterpriseCode = enterpriseCode;

                // �Ԏ햼�̃��[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)modelNameUWork;

                // ���[�J�[�R�[�h�w��S���Ǎ�
                status = this._iModelNameUDB.Search(ref retObj, paraObj, 0, logicalMode);
                
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (ModelNameUWork wkModelNameUWork in workList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                ModelNameU wkModelNameU = CopyToModelNameUFromModelNameUWork(wkModelNameUWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                retList.Add(wkModelNameU);
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

        ///// <summary>
        ///// �Ԏ햼�̃}�X�^�i�񋟁j��������
        ///// </summary>
        ///// <param name="makerCode">���[�J�[�R�[�h</param>
        ///// <param name="retList">�Ǎ����ʃR���N�V����</param>
        ///// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        ///// <param name="nextData">���f�[�^�L��</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        ///// <param name="readCnt">�Ǎ�����</param>
        ///// <param name="prevModelNameU">�O��ŏI�Ԏ햼�̃}�X�^�i�񋟁j�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �Ԏ햼�̃}�X�^�i�񋟁j�̌����������s���܂��B</br>
        ///// <br>Programmer : 30413 ����</br>
        ///// <br>Date       : 2008.06.16</br>
        ///// </remarks>
        //private int SearchModelNameOfrProc(Int32 makerCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode,  ConstantManagement.LogicalMode logicalMode, int readCnt, ModelNameU prevModelNameU)
        //{
        //    ModelNameWork modelNameWork = new ModelNameWork();

        //    // ���f�[�^�L��������
        //    nextData = false;
        //    // �Ǎ��Ώۃf�[�^������0�ŏ�����
        //    retTotalCnt = 0;

        //    int status = 0;

        //    ArrayList workList = new ArrayList();
        //    object retObj = workList;
        //    SortedList sortWk = new SortedList();

        //    // �Z�L�����e�B���x���L�[�w��
        //    modelNameWork.MakerCode = makerCode;

        //    // �Ԏ햼�́i�񋟁j���[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
        //    object paraObj = (object)modelNameWork;

        //    // ���[�J�[�R�[�h�w��S���Ǎ�
        //    status = this._iModelNameDB.Search(ref retObj, paraObj);

        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            workList = retObj as ArrayList;
        //            if (workList != null)
        //            {
        //                foreach (ModelNameWork wkModelNameWork in workList)
        //                {
        //                    // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
        //                    ModelNameU wkModelNameU = CopyToModelNameUFromModelNameWork(wkModelNameWork);
        //                    // �f�[�^�N���X��Ǎ����ʂփR�s�[
        //                    retList.Add(wkModelNameU);
        //                }
        //            }
        //            break;
        //        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //        case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //            break;
        //        default:
        //            return status;
        //    }

        //    // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
        //    if (readCnt == 0) retTotalCnt = retList.Count;

        //    return status;
        //}
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
        /// <br>Date		: 2008.06.12</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            int makerCode = 0;

            //��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey("EnterpriseCode") )
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            //��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }
            //���[�J�[�R�[�h
            if (inParm.ContainsKey("GoodsMakerCd"))
            {
                makerCode = Int32.Parse((inParm["GoodsMakerCd"] as string));
            }
            else if (inParm.ContainsKey("MakerCode"))
            {
                makerCode = Int32.Parse((inParm["MakerCode"].ToString()));
            }                        
            // �Ԏ햼�̃}�X�^�e�[�u���Ǎ���
            // -------UPD 2009/12/08------->>>>>
            //status = Search(ref guideList, makerCode, enterpriseCode);
            status = Search2(ref guideList, makerCode, enterpriseCode);
            // -------UPD 2009/12/08------->>>>>
            
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
        /// �Ԏ햼�̃}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="maker">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: �Ԏ햼�̃}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.13</br>
        /// </remarks>
        public int ExecuteGuid(Int32 makerCode, string enterpriseCode, out ModelNameU modelNameU)
        {
            int status = -1;
            modelNameU = new ModelNameU();

            string xmlName = "";
            if (makerCode == 0)
            {
                xmlName = "MODELNAMEKTNGUIDEPARENT.XML";
            }
            else
            {
                xmlName = "MODELNAMEGUIDEPARENT.XML";
            }

            TableGuideParent tableGuideParent = new TableGuideParent(xmlName);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();


            // ���[�J�[�R�[�h
            inObj.Add("MakerCode",makerCode);
            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);
            // ���i���[�J�[���o�t���O
            inObj.Add("MakerCdExtraFlg", 1);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = string.Empty;
                // ���[�J�[�R�[�h
                if (xmlName == "MODELNAMEKTNGUIDEPARENT.XML")
                {
                    strCode = retObj["GoodsMakerCd"].ToString();
                }
                else
                {
                    strCode = retObj["MakerCode"].ToString();
                }

                modelNameU.MakerCode = int.Parse(strCode);

                // �Ԏ�R�[�h
                strCode = retObj["ModelCode"].ToString();
                modelNameU.ModelCode = int.Parse(strCode);

                // �ď̃R�[�h
                strCode = retObj["ModelSubCode"].ToString();
                modelNameU.ModelSubCode = int.Parse(strCode);

                // �Ԏ햼��
                modelNameU.ModelFullName = retObj["ModelFullName"].ToString();
                // �Ԏ햼�́i�J�i�j
                modelNameU.ModelHalfName = retObj["ModelHalfName"].ToString();
                // �ď�
                modelNameU.ModelAliasName = retObj["ModelAliasName"].ToString();
                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �Ԏ햼�̃}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�ď̃R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="maker">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: �Ԏ햼�̃}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: ���M</br>
        /// <br>Date		: 2009.12.08</br>
        /// </remarks>
        public int ExecuteGuid2(Int32 makerCode, Int32 modelCode,Int32 modelSubCode,string enterpriseCode, out ModelNameU modelNameU)
        {
            int status = -1;
            modelNameU = new ModelNameU();

            string xmlName = "";
            xmlName = "MODELNAMEKTNGUIDEPARENT.XML";
            TableGuideParent tableGuideParent = new TableGuideParent(xmlName);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();


            // ���[�J�[�R�[�h
            inObj.Add("MakerCode", makerCode);
            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);
            // ���i���[�J�[���o�t���O
            inObj.Add("MakerCdExtraFlg", 1);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = string.Empty;
                // ���[�J�[�R�[�h
                if (xmlName == "MODELNAMEKTNGUIDEPARENT.XML")
                {
                    strCode = retObj["GoodsMakerCd"].ToString();
                }
                else
                {
                    strCode = retObj["MakerCode"].ToString();
                }

                modelNameU.MakerCode = int.Parse(strCode);

                // �Ԏ�R�[�h
                strCode = retObj["ModelCode"].ToString();
                modelNameU.ModelCode = int.Parse(strCode);

                // �ď̃R�[�h
                strCode = retObj["ModelSubCode"].ToString();
                modelNameU.ModelSubCode = int.Parse(strCode);

                // �Ԏ햼��
                modelNameU.ModelFullName = retObj["ModelFullName"].ToString();
                // �Ԏ햼�́i�J�i�j
                modelNameU.ModelHalfName = retObj["ModelHalfName"].ToString();
                // �ď�
                modelNameU.ModelAliasName = retObj["ModelAliasName"].ToString();
                status = 0;
            }
            // �L�����Z��
            else
            {
                // 2010/06/29 Add >>>
                if (retObj != null && retObj.Count != 0)
                {
                    string strCode = string.Empty;
                    // ���[�J�[�R�[�h
                    if (xmlName == "MODELNAMEKTNGUIDEPARENT.XML")
                    {
                        strCode = retObj["GoodsMakerCd"].ToString();
                    }
                    else
                    {
                        strCode = retObj["MakerCode"].ToString();
                    }

                    if (!string.IsNullOrEmpty(strCode))
                    {
                        modelNameU.MakerCode = int.Parse(strCode);
                        status = 0;
                    }
                    else
                        status = 1;
                }
                else
                // 2010/06/29 Add <<<
                status = 1;
            }

            return status;
        }

        #endregion
    }
}
