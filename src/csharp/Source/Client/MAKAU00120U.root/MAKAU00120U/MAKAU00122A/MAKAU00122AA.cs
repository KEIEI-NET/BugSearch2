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
	/// <br>Date		: 2007.04.03</br>
    /// <br>Update Note : 2008/08/08 30414 �E �K�j Partsman�p�ɕύX</br>
	/// </remarks>
	public class CustDmdPrcAcs
	{
		# region ��Private Member
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private ICustDmdPrcDB _iCustDmdPrcDB = null;
		/// <summary>���[�U�[�K�C�h�I�u�W�F�N�g�i�[�o�b�t�@(HashTable)</summary>
//		private Hashtable _CustDmdPrcGdBdTable;
		/// <summary>���[�U�[�K�C�h�I�u�W�F�N�g�i�[�o�b�t�@(ArrayList)</summary>
//		private ArrayList _CustDmdPrcGdBdList;
		/// <summary>�L�����A�}�X�^�N���XStatic</summary>
//		private static Hashtable _carrierTable = null;
		# endregion				    
		  
		# region ��Constracter
		/// <summary>
		/// ���Ӑ搿�����z�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : �n糋M�T</br>
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public CustDmdPrcAcs()
		{

    		try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iCustDmdPrcDB = (ICustDmdPrcDB)MediationCustDmdPrcDB.GetCustDmdPrcDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iCustDmdPrcDB = null;
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
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public CustDmdPrcUpdate Deserialize(string fileName)
		{
			CustDmdPrcUpdate carrier = null;

			// �t�@�C������n���ăL�����A���[�N�N���X���f�V���A���C�Y����
			CustDmdPrcWork carrierWork = (CustDmdPrcWork)XmlByteSerializer.Deserialize(fileName,typeof(CustDmdPrcWork));

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
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// �t�@�C������n���ăL�����A���[�N�N���X���f�V���A���C�Y����
			CustDmdPrcWork[] carrierWorks = (CustDmdPrcWork[])XmlByteSerializer.Deserialize(fileName,typeof(CustDmdPrcWork[]));

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
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public void Serialize(CustDmdPrcUpdate carrier ,string fileName)
		{
			//�L�����A�N���X����L�����A���[�J�[�N���X�Ƀ����o�R�s�[
//			CustDmdPrcWork carrierWork = CopyToCustDmdPrcWorkFromCustDmdPrc(carrier);
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
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		public void ListSerialize(ArrayList carrieres,string fileName)
		{
			CustDmdPrcWork[] carrierWorks = new CustDmdPrcWork[carrieres.Count];
			for(int i= 0; i < carrieres.Count; i++)
			{
//				carrierWorks[i] = CopyToCustDmdPrcWorkFromCustDmdPrc((CustDmdPrcUpdParam)carrieres[i]);
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
		/// <br>Date       : 2006.12.19</br>
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
		/// <br>Date       : 2006.12.19</br>
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
		/// <br>Date       : 2006.12.19</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			CustDmdPrcWork carrierWork = new CustDmdPrcWork();
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
        /// </remarks>
        public int RegistDmdData(string enterpriseCode,
                                 string sectionCode,
                                 DateTime addUpdate,
                                 int totalDay,
                                 out string msg)
        {   
            CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            custDmdPrcUpdateWork.EnterpriseCode = enterpriseCode;   //���
            custDmdPrcUpdateWork.AddUpSecCode = sectionCode;        //�v�㋒�_
            custDmdPrcUpdateWork.AddUpDate = addUpdate;             // �v����t
            custDmdPrcUpdateWork.AddUpYearMonth = addUpdate;
            custDmdPrcUpdateWork.CustomerTotalDay = totalDay;       //����                        
            custDmdPrcUpdateWork.ProcCntntsFlag = 1;                // 1 ��������X�V
            custDmdPrcUpdateWork.UpdObjectFlag = 1;                 // 1:�S���Ӑ� 2:�ʓ��Ӑ�w�� 3:�ʓ��Ӑ�Œ�
                        
            object paraObj = custDmdPrcUpdateWork;
            object retObj = (object)custDmdPrcUpdateWork;

            int status;
            msg = "";

            try
            {
                status = this._iCustDmdPrcDB.Write(ref paraObj, out retObj, out msg);
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
        /// <param name="addUpdate">�O���������</param>
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
            CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            custDmdPrcUpdateWork.EnterpriseCode = enterpriseCode;   // ���
            custDmdPrcUpdateWork.AddUpSecCode = sectionCode;        // ���_
            custDmdPrcUpdateWork.AddUpDate = addUpdate;             // �O���������
            custDmdPrcUpdateWork.ProcCntntsFlag = 2;                 

            object paraObj = custDmdPrcUpdateWork;
            object retObj = (object)custDmdPrcUpdateWork;

            int status;
            msg = "";

            try
            {
                status = this._iCustDmdPrcDB.Delete(ref paraObj, out msg);
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
        public int RegistDmdData(out int retTotalCnt, string enterpriseCode, string sectionCode, DateTime addUpdate, DateTime addUpYM, ArrayList setCustomer, ArrayList setTotalDay, int totalDay, int setOption, int mode, out string msg)
        {

            CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            custDmdPrcUpdateWork.EnterpriseCode = enterpriseCode; //���
            custDmdPrcUpdateWork.AddUpSecCode = sectionCode;      //�v�㋒�_
            custDmdPrcUpdateWork.AddUpDate = addUpdate;
            custDmdPrcUpdateWork.AddUpYearMonth = addUpYM;

            custDmdPrcUpdateWork.CustomerCode1 = (int)setCustomer[0];
            custDmdPrcUpdateWork.Customer1TotalDay = (int)setTotalDay[0];
            custDmdPrcUpdateWork.CustomerCode2 = (int)setCustomer[1];
            custDmdPrcUpdateWork.Customer2TotalDay = (int)setTotalDay[1];
            custDmdPrcUpdateWork.CustomerCode3 = (int)setCustomer[2];
            custDmdPrcUpdateWork.Customer3TotalDay = (int)setTotalDay[2];
            custDmdPrcUpdateWork.CustomerCode4 = (int)setCustomer[3];
            custDmdPrcUpdateWork.Customer4TotalDay = (int)setTotalDay[3];
            custDmdPrcUpdateWork.CustomerCode5 = (int)setCustomer[4];
            custDmdPrcUpdateWork.Customer5TotalDay = (int)setTotalDay[4];
            custDmdPrcUpdateWork.CustomerCode6 = (int)setCustomer[5];
            custDmdPrcUpdateWork.Customer6TotalDay = (int)setTotalDay[5];
            custDmdPrcUpdateWork.CustomerCode7 = (int)setCustomer[6];
            custDmdPrcUpdateWork.Customer7TotalDay = (int)setTotalDay[6];
            custDmdPrcUpdateWork.CustomerCode8 = (int)setCustomer[7];
            custDmdPrcUpdateWork.Customer8TotalDay = (int)setTotalDay[7];
            custDmdPrcUpdateWork.CustomerCode9 = (int)setCustomer[8];
            custDmdPrcUpdateWork.Customer9TotalDay = (int)setTotalDay[8];
            custDmdPrcUpdateWork.CustomerCode10 = (int)setCustomer[9];
            custDmdPrcUpdateWork.Customer10TotalDay = (int)setTotalDay[9];

            custDmdPrcUpdateWork.CustomerTotalDay = totalDay; //����                        

            custDmdPrcUpdateWork.ProcCntntsFlag = mode; // 1 ��������X�V 2 ������������
            custDmdPrcUpdateWork.UpdObjectFlag = setOption; // 1:�S���Ӑ� 2:�ʓ��Ӑ�w�� 3:�ʓ��Ӑ�Œ�

            //		    byte[] parabyte = XmlByteSerializer.Serialize(custDmdPrcUpdateWork);
            object paraObj = custDmdPrcUpdateWork;
            object retObj = (object)custDmdPrcUpdateWork;
            //            object retObj = new object();

            int status = this._iCustDmdPrcDB.Write(ref paraObj, out retObj, out msg);

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
        public int BanishDmdData(out int retTotalCnt, string enterpriseCode, string sectionCode, ArrayList setCustomer, ArrayList setTotalDay, int totalDay, int setOption, int mode, out string msg)
        {
            CustDmdPrcUpdateWork custDmdPrcUpdateWork = new CustDmdPrcUpdateWork();
            custDmdPrcUpdateWork.EnterpriseCode = enterpriseCode;  // ���
            custDmdPrcUpdateWork.AddUpSecCode = sectionCode;       // ���_

            custDmdPrcUpdateWork.CustomerCode1 = (int)setCustomer[0];
            custDmdPrcUpdateWork.Customer1TotalDay = (int)setTotalDay[0];
            custDmdPrcUpdateWork.CustomerCode2 = (int)setCustomer[1];
            custDmdPrcUpdateWork.Customer2TotalDay = (int)setTotalDay[1];
            custDmdPrcUpdateWork.CustomerCode3 = (int)setCustomer[2];
            custDmdPrcUpdateWork.Customer3TotalDay = (int)setTotalDay[2];
            custDmdPrcUpdateWork.CustomerCode4 = (int)setCustomer[3];
            custDmdPrcUpdateWork.Customer4TotalDay = (int)setTotalDay[3];
            custDmdPrcUpdateWork.CustomerCode5 = (int)setCustomer[4];
            custDmdPrcUpdateWork.Customer5TotalDay = (int)setTotalDay[4];
            custDmdPrcUpdateWork.CustomerCode6 = (int)setCustomer[5];
            custDmdPrcUpdateWork.Customer6TotalDay = (int)setTotalDay[5];
            custDmdPrcUpdateWork.CustomerCode7 = (int)setCustomer[6];
            custDmdPrcUpdateWork.Customer7TotalDay = (int)setTotalDay[6];
            custDmdPrcUpdateWork.CustomerCode8 = (int)setCustomer[7];
            custDmdPrcUpdateWork.Customer8TotalDay = (int)setTotalDay[7];
            custDmdPrcUpdateWork.CustomerCode9 = (int)setCustomer[8];
            custDmdPrcUpdateWork.Customer9TotalDay = (int)setTotalDay[8];
            custDmdPrcUpdateWork.CustomerCode10 = (int)setCustomer[9];
            custDmdPrcUpdateWork.Customer10TotalDay = (int)setTotalDay[9];
            custDmdPrcUpdateWork.CustomerTotalDay = totalDay; //����

            custDmdPrcUpdateWork.UpdObjectFlag = setOption;  // �S���Ӑ�w��L��(1 �S�� 2 �ʎw�� 3 �ʏ��O)
            custDmdPrcUpdateWork.ProcCntntsFlag = mode; // 1 �����X�V 2 ������������

            object paraObj = custDmdPrcUpdateWork;
            object retObj = (object)custDmdPrcUpdateWork;

            int status = this._iCustDmdPrcDB.Delete(ref paraObj, out msg);

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
        /// <br>Date       : 2006.12.19</br>
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
