# region ��using
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Ӑ搿�����z�}�X�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���Ӑ搿�����z�}�X�^�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: �n糋M�T</br>
	/// <br>Date		: 2007.05.18</br>
    /// <br>Update Note : 2008/08/08 30414 �E �K�j Partsman�p�ɕύX</br>
    /// <br></br>
    /// <br>Update Note : 2012/09/11 FSI���X�� �M�p</br>
    /// <br>            : �d�����������Ή� �d�������I�v�V�������̋����Ή�</br>
    /// </remarks>
	public class SuplierPayAcs
	{
		# region ��Private Member
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private ISuplierPayDB _iSuplierPayDB = null;
		# endregion				    
		  
		# region ��Constracter
		/// <summary>
		/// ���Ӑ搿�����z�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public SuplierPayAcs()
		{

    		try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iSuplierPayDB = (ISuplierPayDB)MediationSuplierPayDB.GetSuplierPayDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iSuplierPayDB = null;
			}
		}
		# endregion

		#region ��Public Method

		/// <summary>
		/// �L�����A�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�L�����A�N���X</returns>
		/// <remarks>
		/// <br>Note       : �L�����A�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public SuplierPay Deserialize(string fileName)
		{
			SuplierPay carrier = null;

			// �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
			SuplierPayWork suplierPayWork = (SuplierPayWork)XmlByteSerializer.Deserialize(fileName,typeof(SuplierPayWork));

			return carrier;
		}

		/// <summary>
		/// �L�����AList�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�L�����A�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : �L�����A���X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// �t�@�C������n���ăL�����A���[�N�N���X���f�V���A���C�Y����
			SuplierPayWork[] carrierWorks = (SuplierPayWork[])XmlByteSerializer.Deserialize(fileName,typeof(SuplierPayWork[]));

			//�f�V���A���C�Y���ʂ��L�����A�N���X�փR�s�[
			if (carrierWorks != null) 
			{
				al.Capacity = carrierWorks.Length;
				for(int i=0; i < carrierWorks.Length; i++)
				{
//					al.Add(CopyToCustDmdPrc(carrierWorks[i]));
				}
			}

			return al;
		}

		/// <summary>
		/// �L�����A�V���A���C�Y����
		/// </summary>
		/// <param name="carrier">�V���A���C�Y�ΏۃL�����A�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �L�����A���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public void Serialize(SuplierPay carrier ,string fileName)
		{
			//�L�����A�N���X����L�����A���[�J�[�N���X�Ƀ����o�R�s�[
//			SuplierPayWork carrierWork = CopyToSuplierPayWorkFromCustDmdPrc(carrier);
			//�L�����A���[�J�[�N���X���V���A���C�Y
//			XmlByteSerializer.Serialize(carrierWork,fileName);
		}

		/// <summary>
		/// �L�����AList�V���A���C�Y����
		/// </summary>
		/// <param name="carrieres">�V���A���C�Y�ΏۃL�����AList�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �L�����AList���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public void ListSerialize(ArrayList carrieres,string fileName)
		{
			SuplierPayWork[] carrierWorks = new SuplierPayWork[carrieres.Count];
			for(int i= 0; i < carrieres.Count; i++)
			{
//				carrierWorks[i] = CopyToSuplierPayWorkFromCustDmdPrc((CustDmdPrcUpdParam)carrieres[i]);
			}
			//�L�����A���[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(carrierWorks,fileName);
		}


		/// <summary>
		/// �L�����A���������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �L�����A�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,0);
		}

		/// <summary>
		/// �L�����A���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �L�����A�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// �L�����A����������
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �L�����A���̌������s���܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2007.05.18</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			SuplierPayWork carrierWork = new SuplierPayWork();
			carrierWork.EnterpriseCode = enterpriseCode;
			
			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(carrierWork);

			// �L�����A����
            int status = 0;
            retTotalCnt = 1;
			if (status != 0) retTotalCnt = 0;
				
			return status;
		}

        // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�^����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="addUpdate">�v����t</param>
        /// <param name="totalDay">�Ώے���</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�^���s���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// <br></br>
        /// <br>Update Note: �I�v�V�����R�[�h����ŌĂяo���x�����X�V������U�蕪����悤�ύX</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : 2012/09/11</br>
        /// </remarks>
        public int RegistDmdData(string enterpriseCode, 
                                 string sectionCode,
                                 DateTime addUpdate,
                                 int totalDay,
                                 out string msg)
        {
            SuplierPayUpdateWork suplierPayUpdateWork = new SuplierPayUpdateWork();
            suplierPayUpdateWork.EnterpriseCode = enterpriseCode;   //���
            suplierPayUpdateWork.AddUpSecCode = sectionCode;        //�v�㋒�_
            suplierPayUpdateWork.AddUpDate = addUpdate;
            suplierPayUpdateWork.AddUpYearMonth = addUpdate;                      
            suplierPayUpdateWork.ProcCntntsFlag = 1;                // 1 �x���������� 2 �x���X�V����
            suplierPayUpdateWork.UpdObjectFlag = 1;                 // 1:�S���Ӑ� 2:�ʓ��Ӑ�w�� 3:�ʓ��Ӑ�Œ�
            suplierPayUpdateWork.SupplierTotalDay = totalDay;

            object paraObj = suplierPayUpdateWork;
            object retObj = (object)suplierPayUpdateWork;

            int status;
            msg = "";

            try
            {
                // --- DEL 2012/09/11 ----------->>>>>
                //status = this._iSuplierPayDB.Write(ref paraObj, out retObj, out msg);
                // --- DEL 2012/09/11 -----------<<<<<
                // --- ADD 2012/09/11 ----------->>>>>
                #region �d�������@�\�i�ʁj
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                    ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SuppSumFunc);
                if (PurchaseStatus.Contract == ps)
                {
                    // �d�������I�v�V�������L���̏ꍇ�A
                    // �����`���̎x�����X�V���������s����
                    status = this._iSuplierPayDB.WriteByAddUpSecCode(ref paraObj, out retObj, out msg);
                }
                else
                {
                    // �����`���̎x�����X�V���������s����
                    status = this._iSuplierPayDB.Write(ref paraObj, out retObj, out msg);
                }
                #endregion �d�������@�\�i�ʁj
                // --- ADD 2012/09/11 -----------<<<<<
            }
            catch
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="addUpdate">�v����t</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        public int BanishDmdData(string enterpriseCode, 
                                 string sectionCode,
                                 DateTime addUpdate,
                                 out string msg)
        {
            SuplierPayUpdateWork suplierPayUpdateWork = new SuplierPayUpdateWork();
            suplierPayUpdateWork.EnterpriseCode = enterpriseCode;   // ���
            suplierPayUpdateWork.AddUpSecCode = sectionCode;        // ���_
            suplierPayUpdateWork.AddUpDate = addUpdate;
            suplierPayUpdateWork.ProcCntntsFlag = 2;                // 1 �x������ 2 �d�������X�V

            object paraObj = suplierPayUpdateWork;
            object retObj = (object)suplierPayUpdateWork;

            int status;
            msg = "";

            try
            {
                status = this._iSuplierPayDB.Delete(ref paraObj, out msg);
            }
            catch
            {
                status = -1;
            }

            return status;

        }
        // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/08 Partsman�p�ɕύX
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �o�^����
        /// </summary>
        /// <param name="retTotalCnt"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="setCustomer"></param>
        /// <param name="setTotalDay"></param>
        /// <param name="totalDay"></param>
        /// <returns></returns>
        public int RegistDmdData(out int retTotalCnt,string enterpriseCode,string sectionCode,DateTime addUpdate,DateTime addUpYM,ArrayList setCustomer, ArrayList setTotalDay ,int totalDay,int setOption,int mode,out string msg)
        {   

            SuplierPayUpdateWork suplierPayUpdateWork = new SuplierPayUpdateWork();
            suplierPayUpdateWork.EnterpriseCode = enterpriseCode; //���
            suplierPayUpdateWork.AddUpSecCode = sectionCode;      //�v�㋒�_
            suplierPayUpdateWork.AddUpDate = addUpdate;
            suplierPayUpdateWork.AddUpYearMonth = addUpYM;

            suplierPayUpdateWork.CustomerCode1 = (int)setCustomer[0];            
            suplierPayUpdateWork.Customer1TotalDay = (int)setTotalDay[0];
            suplierPayUpdateWork.CustomerCode2 = (int)setCustomer[1];
            suplierPayUpdateWork.Customer2TotalDay = (int)setTotalDay[1];
            suplierPayUpdateWork.CustomerCode3 = (int)setCustomer[2];
            suplierPayUpdateWork.Customer3TotalDay = (int)setTotalDay[2];
            suplierPayUpdateWork.CustomerCode4 = (int)setCustomer[3];
            suplierPayUpdateWork.Customer4TotalDay = (int)setTotalDay[3];
            suplierPayUpdateWork.CustomerCode5 = (int)setCustomer[4];
            suplierPayUpdateWork.Customer5TotalDay = (int)setTotalDay[4];
            suplierPayUpdateWork.CustomerCode6 = (int)setCustomer[5];
            suplierPayUpdateWork.Customer6TotalDay = (int)setTotalDay[5];
            suplierPayUpdateWork.CustomerCode7 = (int)setCustomer[6];
            suplierPayUpdateWork.Customer7TotalDay = (int)setTotalDay[6];
            suplierPayUpdateWork.CustomerCode8 = (int)setCustomer[7];
            suplierPayUpdateWork.Customer8TotalDay = (int)setTotalDay[7];
            suplierPayUpdateWork.CustomerCode9 = (int)setCustomer[8];
            suplierPayUpdateWork.Customer9TotalDay = (int)setTotalDay[8];
            suplierPayUpdateWork.CustomerCode10 = (int)setCustomer[9];
            suplierPayUpdateWork.Customer10TotalDay = (int)setTotalDay[9];
            
            suplierPayUpdateWork.CustomerTotalDay = totalDay; //����                        
                        
            suplierPayUpdateWork.ProcCntntsFlag = mode; // 1 �x���������� 2 �x���X�V����
            suplierPayUpdateWork.UpdObjectFlag = setOption; // 1:�S���Ӑ� 2:�ʓ��Ӑ�w�� 3:�ʓ��Ӑ�Œ�
                        
//		    byte[] parabyte = XmlByteSerializer.Serialize(suplierPayUpdateWork);
            object paraObj = suplierPayUpdateWork;
            object retObj = (object)suplierPayUpdateWork;            
//            object retObj = new object();

            int status = this._iSuplierPayDB.Write(ref paraObj,out retObj,out msg);

            retTotalCnt = 0;            
            
            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retTotalCnt"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="setCustomer"></param>
        /// <param name="setTotalDay"></param>
        /// <param name="totalDay"></param>
        /// <param name="setOption"></param>
        /// <param name="target"></param>
        /// <param name="mode"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public int BanishDmdData(out int retTotalCnt, string enterpriseCode, string sectionCode, ArrayList setCustomer, ArrayList setTotalDay, int totalDay, int setOption,int mode,out string msg)
        {
            SuplierPayUpdateWork suplierPayUpdateWork = new SuplierPayUpdateWork();
            suplierPayUpdateWork.EnterpriseCode = enterpriseCode;  // ���
            suplierPayUpdateWork.AddUpSecCode = sectionCode;       // ���_
            
            
            suplierPayUpdateWork.CustomerCode1 = (int)setCustomer[0];
            suplierPayUpdateWork.Customer1TotalDay = (int)setTotalDay[0];
            suplierPayUpdateWork.CustomerCode2 = (int)setCustomer[1];
            suplierPayUpdateWork.Customer2TotalDay = (int)setTotalDay[1];
            suplierPayUpdateWork.CustomerCode3 = (int)setCustomer[2];
            suplierPayUpdateWork.Customer3TotalDay = (int)setTotalDay[2];
            suplierPayUpdateWork.CustomerCode4 = (int)setCustomer[3];
            suplierPayUpdateWork.Customer4TotalDay = (int)setTotalDay[3];
            suplierPayUpdateWork.CustomerCode5 = (int)setCustomer[4];
            suplierPayUpdateWork.Customer5TotalDay = (int)setTotalDay[4];
            suplierPayUpdateWork.CustomerCode6 = (int)setCustomer[5];
            suplierPayUpdateWork.Customer6TotalDay = (int)setTotalDay[5];
            suplierPayUpdateWork.CustomerCode7 = (int)setCustomer[6];
            suplierPayUpdateWork.Customer7TotalDay = (int)setTotalDay[6];
            suplierPayUpdateWork.CustomerCode8 = (int)setCustomer[7];
            suplierPayUpdateWork.Customer8TotalDay = (int)setTotalDay[7];
            suplierPayUpdateWork.CustomerCode9 = (int)setCustomer[8];
            suplierPayUpdateWork.Customer9TotalDay = (int)setTotalDay[8];
            suplierPayUpdateWork.CustomerCode10 = (int)setCustomer[9];
            suplierPayUpdateWork.Customer10TotalDay = (int)setTotalDay[9];
            suplierPayUpdateWork.CustomerTotalDay = totalDay; //����

            suplierPayUpdateWork.UpdObjectFlag = setOption;  // �S���Ӑ�w��L��(1 �S�� 2 �ʎw�� 3 �ʏ��O)
            suplierPayUpdateWork.ProcCntntsFlag = mode; // 1 �x������ 2 �d�������X�V

            object paraObj = suplierPayUpdateWork;
            object retObj = (object)suplierPayUpdateWork;

            int status = this._iSuplierPayDB.Delete(ref paraObj,out msg);

            retTotalCnt = 0;

            return status;

        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 Partsman�p�ɕύX

        #endregion

        #region ��Private Method


        /// <summary>
        /// ���[�J���t�@�C���Ǎ��ݏ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J���t�@�C����Ǎ���ŁA����Static�ɕێ����܂��B</br>
        /// <br>Programer  : �n糋M�T</br>
        /// <br>Date       : 2007.05.18</br>
        /// </remarks>
        private void SearchOfflineData()
        {
            // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            // --- Search�p --- //
            // KeyList�ݒ�
            string[] carrierKeys = new string[1];
            carrierKeys[0] = LoginInfoAcquisition.EnterpriseCode;
            // ���[�J���t�@�C���Ǎ��ݏ���
            object wkObj = offlineDataSerializer.DeSerialize("CustDmdPrcAcs", carrierKeys);
            // ArrayList�ɃZ�b�g
            ArrayList wkList = wkObj as ArrayList;

            if ((wkList != null) &&
                (wkList.Count != 0))
            {
                // �L�����A�N���X���[�J�[�N���X�iArrayList�j �� UI�N���X�iStatic�j�ϊ�����
                //				CopyToStaticFromWorker(wkList);
            }
        }
        #endregion
    }
}
