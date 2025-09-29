using System;
using System.Collections;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �����S�̐ݒ�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����S�̐ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2005.07.30</br>
	/// <br></br>
	/// <br>Update Note: 2006.06.01 23001 �H�R�@����</br>
    /// <br>                        1.�O����Z��敪��ǉ�</br>
    /// <br>Update Note: 2006.12.13 22022 �i�� �m�q</br>
    /// <br>					    1.SF�ł𗬗p���g�єł��쐬</br>
    /// <br>					    2.���g�p���ڂ��Œ�l�֕ύX(�}�C�i�X����p�c�������敪�E�O����Z��敪���폜)</br>
    /// <br>Programmer : 30415 �ēc �ύK</br>
    /// <br>Date       : 2008/06/16</br>	
    /// <br></br>
	/// </remarks>
	public class BillAllStAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IBillAllStDB _iBillAllStDB = null;

		/// <summary>
		/// �����S�̐ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public BillAllStAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iBillAllStDB = (IBillAllStDB)MediationBillAllStDB.GetBillAllStDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
 				this._iBillAllStDB = null; 
			}
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
		/// �I�����C�����[�h�擾
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>		
		public int GetOnlineMode()
		{
			if (this._iBillAllStDB == null)
			{
			return (int)OnlineMode.Offline;
			}
			else
			{
			return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// �����S�̐ݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="billallset">�����S�̐ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>   
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ��ǂݍ��݂܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public int Read(out BillAllSt billallset, string enterpriseCode, string sectionCode)

		{			
			try
			{
				billallset = null;
				BillAllStWork billallsetWork = new BillAllStWork();
				billallsetWork.EnterpriseCode = enterpriseCode;
                billallsetWork.SectionCode = sectionCode;

				// XML�֕ϊ����A������̃o�C�i����
				//byte[] parabyte = XmlByteSerializer.Serialize(billallsetWork);  // DEL 2008/06/16

                Object paraObj = (object)billallsetWork;  // ADD 2008/06/16

				//�����S�̐ݒ�ǂݍ���
				//int status = this._iBillAllStDB.Read(ref parabyte,0);  // DEL 2008/06/16
                int status = this._iBillAllStDB.Read(ref paraObj, 0);  // ADD 2008/06/16

				if (status == 0)
				{
					// XML�̓ǂݍ���
					//billallsetWork = (BillAllStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillAllStWork));
                    ArrayList wklist = (ArrayList)paraObj;
                    billallsetWork = wklist[0] as BillAllStWork;
                    // �N���X�������o�R�s�[
					billallset = CopyToAutoliasetFromBillAllStWork(billallsetWork);
				}
				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				billallset = null;
				//�I�t���C������null���Z�b�g
				this._iBillAllStDB = null;
				return -1;
			}
		}

        /// <summary>
        /// �����S�̐ݒ茟������(�_���폜�f�[�^�܂�)
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

		/// <summary>
		/// �����S�̐ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�����S�̐ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public BillAllSt Deserialize(string fileName)
		{
			BillAllSt billallset = null;

			// �t�@�C������n����>�����S�̐ݒ胏�[�N�N���X���f�V���A���C�Y����
			BillAllStWork billallsetWork = (BillAllStWork)XmlByteSerializer.Deserialize(fileName,typeof(BillAllStWork));
			//�f�V���A���C�Y���ʂ�>�����S�̐ݒ�N���X�փR�s�[
			if (billallsetWork != null) billallset = CopyToAutoliasetFromBillAllStWork(billallsetWork);
			return billallset;
		}
		
		/// <summary>
		/// �����S�̐ݒ�List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�����S�̐ݒ�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>		
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// �t�@�C������n���Đ����S�̐ݒ胏�[�N�N���X���f�V���A���C�Y����
			BillAllStWork[] billallsetWorks = (BillAllStWork[])XmlByteSerializer.Deserialize(fileName,typeof(BillAllStWork[]));

			//�f�V���A���C�Y���ʂ𐿋��S�̐ݒ�N���X�փR�s�[
			if (billallsetWorks != null) 
			{
				al.Capacity = billallsetWorks.Length;
				for(int i=0; i < billallsetWorks.Length; i++)
				{
					al.Add(CopyToAutoliasetFromBillAllStWork(billallsetWorks[i]));
				}
			}
			return al;
		}

		/// <summary>
		/// �����S�̐ݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="billallset">�����S�̐ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ�̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public int Write(ref BillAllSt billallset)
		{
            ArrayList wklist = new ArrayList();

			// �N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
			BillAllStWork billallsetWork = CopyToBillAllStWorkFromBillAllSt(billallset);

			// XML�֕ϊ����A������̃o�C�i����
			//byte[] parabyte = XmlByteSerializer.Serialize(billallsetWork);  // DEL 2008/06/16

            //Object paraObj = (object)billallsetWork;  // DEL 2008/06/16

            // --- ADD 2008/06/16 -------------------------------->>>>>
            wklist.Add(billallsetWork);
            Object paraObj = wklist;
            // --- ADD 2008/06/16 --------------------------------<<<<< 

			int status = 0;
			try
			{
				//��������
				//status = this._iBillAllStDB.Write(ref parabyte);
                status = this._iBillAllStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    //billallsetWork = (BillAllStWork)paraObj;  // DEL 2008/06/16

                    // --- ADD 2008/06/16 -------------------------------->>>>>
                    wklist = (ArrayList)paraObj;
                    billallsetWork = wklist[0] as BillAllStWork;
                    // --- ADD 2008/06/16 --------------------------------<<<<< 

                    // �N���X�������o�R�s�[
					billallset = CopyToAutoliasetFromBillAllStWork(billallsetWork);
				}
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iBillAllStDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}
			return status;
		}

        /// <summary>
        /// �����S�̐ݒ�_���폜����
        /// </summary>
        /// <param name="estimateDefSet">�����S�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        public int LogicalDelete(ref BillAllSt billAllSt)
        {
            int status = 0;
            ArrayList wklist = new ArrayList();  // ADD 2008/06/16

            try
            {
                // �����S�̐ݒ�N���X�𐿋��S�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                BillAllStWork billAllStWork = CopyToBillAllStWorkFromBillAllSt(billAllSt);

                //Object paraObj = (object)billAllStWork;  // DEL 2008/06/16

                // --- ADD 2008/06/16 -------------------------------->>>>>
                wklist.Add(billAllStWork);
                Object paraObj = wklist;
                // --- ADD 2008/06/16 --------------------------------<<<<< 

                // �����S�̐ݒ��_���폜
                status = this._iBillAllStDB.LogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �����S�̐ݒ胏�[�N�N���X�𐿋��S�̐ݒ�N���X�Ƀ����o�R�s�[
                    //billAllStWork = paraObj as BillAllStWork;  // DEL 2008/06/16

                    // --- ADD 2008/06/16 -------------------------------->>>>>
                    wklist = (ArrayList)paraObj;
                    billAllStWork = wklist[0] as BillAllStWork;
                    // --- ADD 2008/06/16 --------------------------------<<<<< 

                    billAllSt = CopyToAutoliasetFromBillAllStWork(billAllStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iBillAllStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
        /// �����S�̐ݒ蕨���폜����
        /// </summary>
        /// <param name="estimateDefSet">�����S�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�̕����폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        public int Delete(BillAllSt billAllSt)
        {
            int status = 0;
            ArrayList wklist = new ArrayList();

            try
            {
                // �����S�̐ݒ�N���X�𐿋��S�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                BillAllStWork billAllStWork = CopyToBillAllStWorkFromBillAllSt(billAllSt);

                // --- ADD 2008/06/16 -------------------------------->>>>>
                wklist.Add(billAllStWork);
                Object parabyte = wklist;
                // --- ADD 2008/06/16 --------------------------------<<<<< 

                // XML�ϊ����A��������o�C�i����
                //byte[] parabyte = XmlByteSerializer.Serialize(billAllStWork);  // DEL 2008/06/16

                // �����S�̐ݒ蕨���폜
                status = this._iBillAllStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null��ݒ�
                this._iBillAllStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
        /// �����S�̐ݒ�_���폜��������
        /// </summary>
        /// <param name="estimateDefSet">�����S�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        public int Revival(ref BillAllSt billAllSt)
        {
            int status = 0;
            ArrayList wklist = new ArrayList();

            try
            {
                // �����S�̐ݒ�N���X�𐿋��S�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                BillAllStWork billAllStWork = CopyToBillAllStWorkFromBillAllSt(billAllSt);

                // --- ADD 2008/06/16 -------------------------------->>>>>
                wklist.Add(billAllStWork);
                Object paraObj = wklist;
                // --- ADD 2008/06/16 --------------------------------<<<<< 

                // ����
                //Object paraObj = (object)billAllStWork;  // DEL 2008/06/16
                status = this._iBillAllStDB.RevivalLogicalDelete(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �����S�̐ݒ胏�[�N�N���X�𐿋��S�̐ݒ�N���X�Ƀ����o�R�s�[
                    //billAllStWork = paraObj as BillAllStWork;  // DEL 2008/06/16

                    // --- ADD 2008/06/16 -------------------------------->>>>>
                    wklist = (ArrayList)paraObj;
                    billAllStWork = wklist[0] as BillAllStWork;
                    // --- ADD 2008/06/16 --------------------------------<<<<< 

                    billAllSt = CopyToAutoliasetFromBillAllStWork(billAllStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iBillAllStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

		/// <summary>
		/// �����S�̐ݒ�V���A���C�Y����
		/// </summary>
		/// <param name="billallset">�V���A���C�Y�Ώې����S�̐ݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void Serialize(BillAllSt billallset,string fileName)
		{
		//�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
			BillAllStWork stockttlWork = CopyToBillAllStWorkFromBillAllSt(billallset);
			//�]���[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(stockttlWork,fileName);
		}

		/// <summary>
		/// �����S�̐ݒ�List�V���A���C�Y����
		/// </summary>
		/// <param name="billallsetList">�V���A���C�Y�Ώې����S�̐ݒ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		public void ListSerialize(ArrayList billallsetList,string fileName)
		{
			BillAllStWork[] billallsetWorks = new BillAllStWork[billallsetList.Count];
			for(int i= 0; i < billallsetList.Count; i++)
			{
				billallsetWorks[i] = CopyToBillAllStWorkFromBillAllSt((BillAllSt)billallsetList[i]);
			}
			//�����S�̐ݒ胏�[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(billallsetWorks,fileName);
		}

        /// <summary>
        /// �����S�̐ݒ茟������(���C��)
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�̌����������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/16</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            BillAllStWork billAllStWork = new BillAllStWork();
            billAllStWork.EnterpriseCode = enterpriseCode;		// ��ƃR�[�h

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = billAllStWork;
            object retobj = wkList;

            // �����S�̐ݒ�S������
            status = this._iBillAllStDB.Search(ref retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (BillAllStWork wkBillAllStWork in wkList)
                    {
                        retList.Add(CopyToAutoliasetFromBillAllStWork(wkBillAllStWork));
                    }
                }
            }

            return status;
        }

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�����S�̐ݒ胏�[�N�N���X�ː����S�̐ݒ�N���X�j
		/// </summary>
		/// <param name="billallsetWork">�����S�̐ݒ胏�[�N�N���X</param>
		/// <returns>�����S�̐ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ胏�[�N�N���X���琿���S�̐ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private BillAllSt CopyToAutoliasetFromBillAllStWork(BillAllStWork billallsetWork)
		{
			BillAllSt billallset = new BillAllSt();

			//�t�@�C���w�b�_����
			billallset.CreateDateTime       = billallsetWork.CreateDateTime;
			billallset.UpdateDateTime       = billallsetWork.UpdateDateTime;
			billallset.EnterpriseCode       = billallsetWork.EnterpriseCode;
			billallset.FileHeaderGuid       = billallsetWork.FileHeaderGuid;
			billallset.UpdEmployeeCode      = billallsetWork.UpdEmployeeCode;
			billallset.UpdAssemblyId1       = billallsetWork.UpdAssemblyId1;
			billallset.UpdAssemblyId2       = billallsetWork.UpdAssemblyId2;
			billallset.LogicalDeleteCode    = billallsetWork.LogicalDeleteCode;

            billallset.SectionCode          = billallsetWork.SectionCode;  // ADD 2008/06/16

			//�f�[�^����
            /* --- DEL 2008/06/16 -------------------------------->>>>>
			billallset.BillAllStCd          = billallsetWork.BillAllStCd;
			billallset.MinusVarCstBlAdjstCd = billallsetWork.MinusVarCstBlAdjstCd;
               --- DEL 2008/06/16 --------------------------------<<<<< */
            
            billallset.AllowanceProcCd      = billallsetWork.AllowanceProcCd;
			billallset.DepositSlipMntCd     = billallsetWork.DepositSlipMntCd;
            billallset.CollectPlnDiv        = billallsetWork.CollectPlnDiv;


            //billallset.BfRmonCalcDivCd      = billallsetWork.BfRmonCalcDivCd;  // DEL 2008/06/16

			//billallset.StockAllStMngCd     = billallsetWork.StockAllStMngCd;
			//billallset.ValidDtConsTaxRate1 = billallsetWork.ValidDtConsTaxRate1;
			//billallset.ConsTaxRate1        = billallsetWork.ConsTaxRate1;
			//billallset.ValidDtConsTaxRate2 = billallsetWork.ValidDtConsTaxRate2;
			//billallset.ConsTaxRate2        = billallsetWork.ConsTaxRate2;
			//billallset.ValidDtConsTaxRate3 = billallsetWork.ValidDtConsTaxRate3;
			//billallset.ConsTaxRate3        = billallsetWork.ConsTaxRate3;
			//billallset.ConsTaxFracProcDiv  = billallsetWork.ConsTaxFracProcDiv;
			//billallset.AutoEntryStockCd    = billallsetWork.AutoEntryStockCd;     
			//billallset.MinusVarCstBlAdjstCd     = billallsetWork.MinusVarCstBlAdjstCd;
			//billallset.AllowanceProcCd   = billallsetWork.AllowanceProcCd;
			//billallset.DepositSlipMntCd = billallsetWork.DepositSlipMntCd;

            // --- ADD 2008/06/16 -------------------------------->>>>>
            billallset.CustomerTotalDay1 = billallsetWork.CustomerTotalDay1;
            billallset.CustomerTotalDay2 = billallsetWork.CustomerTotalDay2;
            billallset.CustomerTotalDay3 = billallsetWork.CustomerTotalDay3;
            billallset.CustomerTotalDay4 = billallsetWork.CustomerTotalDay4;
            billallset.CustomerTotalDay5 = billallsetWork.CustomerTotalDay5;
            billallset.CustomerTotalDay6 = billallsetWork.CustomerTotalDay6;
            billallset.CustomerTotalDay7 = billallsetWork.CustomerTotalDay7;
            billallset.CustomerTotalDay8 = billallsetWork.CustomerTotalDay8;
            billallset.CustomerTotalDay9 = billallsetWork.CustomerTotalDay9;
            billallset.CustomerTotalDay10 = billallsetWork.CustomerTotalDay10;
            billallset.CustomerTotalDay11 = billallsetWork.CustomerTotalDay11;
            billallset.CustomerTotalDay12 = billallsetWork.CustomerTotalDay12;

            billallset.SupplierTotalDay1 = billallsetWork.SupplierTotalDay1;
            billallset.SupplierTotalDay2 = billallsetWork.SupplierTotalDay2;
            billallset.SupplierTotalDay3 = billallsetWork.SupplierTotalDay3;
            billallset.SupplierTotalDay4 = billallsetWork.SupplierTotalDay4;
            billallset.SupplierTotalDay5 = billallsetWork.SupplierTotalDay5;
            billallset.SupplierTotalDay6 = billallsetWork.SupplierTotalDay6;
            billallset.SupplierTotalDay7 = billallsetWork.SupplierTotalDay7;
            billallset.SupplierTotalDay8 = billallsetWork.SupplierTotalDay8;
            billallset.SupplierTotalDay9 = billallsetWork.SupplierTotalDay9;
            billallset.SupplierTotalDay10 = billallsetWork.SupplierTotalDay10;
            billallset.SupplierTotalDay11 = billallsetWork.SupplierTotalDay11;
            billallset.SupplierTotalDay12 = billallsetWork.SupplierTotalDay12;
            // --- ADD 2008/06/16 --------------------------------<<<<< 

			return billallset;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�����S�̐ݒ�N���X�ː����S�̐ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="billallset">�����S�̃N���X</param>
		/// <returns>�����S�̃��[�N�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����S�̐ݒ�N���X���琿���S�̐ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private BillAllStWork CopyToBillAllStWorkFromBillAllSt(BillAllSt billallset)
		{
 			BillAllStWork billallsetWork = new BillAllStWork();
			//�t�@�C���w�b�_����
			billallsetWork.CreateDateTime       = billallset.CreateDateTime;
			billallsetWork.UpdateDateTime       = billallset.UpdateDateTime;
			billallsetWork.EnterpriseCode       = billallset.EnterpriseCode;
			billallsetWork.FileHeaderGuid       = billallset.FileHeaderGuid;
			billallsetWork.UpdEmployeeCode      = billallset.UpdEmployeeCode;
			billallsetWork.UpdAssemblyId1       = billallset.UpdAssemblyId1;
			billallsetWork.UpdAssemblyId2       = billallset.UpdAssemblyId2;
			billallsetWork.LogicalDeleteCode    = billallset.LogicalDeleteCode;

            billallsetWork.SectionCode = billallset.SectionCode;  // ADD 2008/06/16

			//�f�[�^����
            /* --- DEL 2008/06/16 -------------------------------->>>>>
			billallsetWork.BillAllStCd          = billallset.BillAllStCd;
			billallsetWork.MinusVarCstBlAdjstCd = billallset.MinusVarCstBlAdjstCd;
               --- DEL 2008/06/16 --------------------------------<<<<< */
            billallsetWork.AllowanceProcCd      = billallset.AllowanceProcCd;
			billallsetWork.DepositSlipMntCd     = billallset.DepositSlipMntCd;
            billallsetWork.CollectPlnDiv        = billallset.CollectPlnDiv;

			//billallsetWork.BfRmonCalcDivCd      = billallset.BfRmonCalcDivCd;  // ADD 2008/06/16

            // --- ADD 2008/06/16 -------------------------------->>>>>
            billallsetWork.CustomerTotalDay1 = billallset.CustomerTotalDay1;
            billallsetWork.CustomerTotalDay2 = billallset.CustomerTotalDay2;
            billallsetWork.CustomerTotalDay3 = billallset.CustomerTotalDay3;
            billallsetWork.CustomerTotalDay4 = billallset.CustomerTotalDay4;
            billallsetWork.CustomerTotalDay5 = billallset.CustomerTotalDay5;
            billallsetWork.CustomerTotalDay6 = billallset.CustomerTotalDay6;
            billallsetWork.CustomerTotalDay7 = billallset.CustomerTotalDay7;
            billallsetWork.CustomerTotalDay8 = billallset.CustomerTotalDay8;
            billallsetWork.CustomerTotalDay9 = billallset.CustomerTotalDay9;
            billallsetWork.CustomerTotalDay10 = billallset.CustomerTotalDay10;
            billallsetWork.CustomerTotalDay11 = billallset.CustomerTotalDay11;
            billallsetWork.CustomerTotalDay12 = billallset.CustomerTotalDay12;

            billallsetWork.SupplierTotalDay1 = billallset.SupplierTotalDay1;
            billallsetWork.SupplierTotalDay2 = billallset.SupplierTotalDay2;
            billallsetWork.SupplierTotalDay3 = billallset.SupplierTotalDay3;
            billallsetWork.SupplierTotalDay4 = billallset.SupplierTotalDay4;
            billallsetWork.SupplierTotalDay5 = billallset.SupplierTotalDay5;
            billallsetWork.SupplierTotalDay6 = billallset.SupplierTotalDay6;
            billallsetWork.SupplierTotalDay7 = billallset.SupplierTotalDay7;
            billallsetWork.SupplierTotalDay8 = billallset.SupplierTotalDay8;
            billallsetWork.SupplierTotalDay9 = billallset.SupplierTotalDay9;
            billallsetWork.SupplierTotalDay10 = billallset.SupplierTotalDay10;
            billallsetWork.SupplierTotalDay11 = billallset.SupplierTotalDay11;
            billallsetWork.SupplierTotalDay12 = billallset.SupplierTotalDay12;
            // --- ADD 2008/06/16 --------------------------------<<<<< 

			return billallsetWork;
		}
		
		/// <summary>
		/// �Ώۃf�[�^�`�F�b�N
		/// </summary>
		/// <param name="billallset">�Ώۃf�[�^</param>
		/// <param name="billallsetPara">�p�����[�^</param>
		/// <returns>�`�F�b�N���ʁitrue:OK false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �Ώۃf�[�^�ƃp�����[�^���r���܂��B</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2005.07.30</br>
		/// </remarks>
		private bool checkTarGetData(BillAllSt billallset,BillAllSt billallsetPara)
		{
			// ��ƃR�[�h���r
			if (billallsetPara.EnterpriseCode != null)
			{
				if (!billallsetPara.EnterpriseCode.Equals(billallset.EnterpriseCode))
					return false;
			}
			return true;
		}
		
	}
}
