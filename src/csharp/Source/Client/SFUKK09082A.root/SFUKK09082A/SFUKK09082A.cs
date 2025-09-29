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
	/// <summary>
	/// ��������ݒ�}�X�^�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ��������ݒ�}�X�^�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 23010 �����@�m</br>
	/// <br>Date       : 2005.08.03</br>
	/// <br></br>
	/// <br>Update Note: 2005.09.20 22021 �J���@�͍K</br>
	/// <br>			�E���Ӑ�d�b�ԍ��󎚋敪�̒ǉ�</br>
	/// <br>Update Note: 2006.01.27 22021 �J���@�͍K</br>
	/// <br>			�E����������ꎞ���f�����̒ǉ�</br>
	/// <br>Update Note:   2006.06.01 23001 �H�R�@����</br>
	/// <br>                          1.�W���\��\�o�͋敪��ǉ�</br>
	/// <br>                          2.�W���\��\�W���\��z�i����p�j��ǉ�</br>
	/// <br>                          3.�W���\��\�o�̓^�C�v��ǉ�</br>
	/// <br>Update Note: 2007.06.27 20031 �É�@���S��</br>
    /// <br>			�E�e�[�u���C���ɂ�鍀�ڍ폜</br>
    /// <br>                1.�����O��t�o�͋敪���폜</br>
    /// <br>                2.����������ŏo�͋敪���폜</br>
    /// <br>                3.���������Ѓv���e�N�g������̂P�`�S���폜</br>
    /// <br>                4.�������E�v�P�A�Q���폜</br>
    /// <br>                5.�W���\��\�o�͋敪���폜</br>
    /// <br>                6.�W���\��\�W���\��z�i����p�j���폜</br>
    /// <br>                7.�W���\��\�o�̓^�C�v���폜</br>
    /// </remarks>
	/// </summary>
	public class BillPrtStAcs
	{	
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IBillPrtStDB _iBillPrtStDB = null;

		/// <summary>
		/// ��������ݒ�}�X�^�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ��������ݒ�}�X�^�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		public BillPrtStAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iBillPrtStDB = (IBillPrtStDB)MediationBillPrtStDB.GetBillPrtStDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iBillPrtStDB = null;
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
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iBillPrtStDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// �����Ӑݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="billPrtSt">�����Ӑݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�����Ӑݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����Ӑݒ��ǂݍ��݂܂��B</br>
		/// <br>Programmer : 92041 ��{�@���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Read(out BillPrtSt billPrtSt, string enterpriseCode)
		{			
			try
			{
				billPrtSt = null;
				BillPrtStWork billPrtStWork = new BillPrtStWork();
				billPrtStWork.EnterpriseCode = enterpriseCode;

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(billPrtStWork);

				//�����Ӑݒ�ǂݍ���
				int status = this._iBillPrtStDB.Read(ref parabyte,0);

				if (status == 0)
				{
					// XML�̓ǂݍ���
					billPrtStWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));
					// �N���X�������o�R�s�[
					billPrtSt = CopyToBillPrtStFromBillPrtStWork(billPrtStWork);
				}
				
				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				billPrtSt = null;
				//�I�t���C������null���Z�b�g
				this._iBillPrtStDB = null;
				return -1;
			}
		}

		/// <summary>
		/// �����Ӑݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�����Ӑݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����Ӑݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 92041 ��{�@���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public BillPrtSt Deserialize(string fileName)
		{
			BillPrtSt billPrtSt = null;
			// �t�@�C������n���Ď����Ӑݒ胏�[�N�N���X���f�V���A���C�Y����
			BillPrtStWork billPrtStWork = (BillPrtStWork)XmlByteSerializer.Deserialize(fileName,typeof(BillPrtStWork));

			//�f�V���A���C�Y���ʂ������Ӑݒ�N���X�փR�s�[
			if (billPrtStWork != null) billPrtSt = CopyToBillPrtStFromBillPrtStWork(billPrtStWork);

			return billPrtSt;
		}

		/// <summary>
		/// �����Ӑݒ�List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�����Ӑݒ�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : �����Ӑݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 92041 ��{�@���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList billPrtStList = new ArrayList();
			// �t�@�C������n���Ď����Ӑݒ胏�[�N�N���X���f�V���A���C�Y����
			BillPrtStWork[] billPrtStWorks = (BillPrtStWork[])XmlByteSerializer.Deserialize(fileName,typeof(BillPrtStWork[]));

			//�f�V���A���C�Y���ʂ������Ӑݒ�N���X�փR�s�[
			if (billPrtStWorks != null) 
			{
				billPrtStList.Capacity = billPrtStWorks.Length;
				for(int i=0; i < billPrtStWorks.Length; i++)
				{
					billPrtStList.Add(CopyToBillPrtStFromBillPrtStWork(billPrtStWorks[i]));
				}
			}
			return billPrtStList;
		}

		/// <summary>
		/// �����Ӑݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="billPrtSt">�����Ӑݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����Ӑݒ�̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 92041 ��{�@���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Write(ref BillPrtSt billPrtSt)
		{
			//�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
			BillPrtStWork billPrtStWork = CopyToBillPrtStWorkFromBillPrtSt(billPrtSt);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(billPrtStWork);

			int status = 0;
			try
			{
				//��������
				status = this._iBillPrtStDB.Write(ref parabyte);
				if (status == 0)
				{
					// �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
					billPrtStWork = (BillPrtStWork)XmlByteSerializer.Deserialize(parabyte,typeof(BillPrtStWork));
					// �N���X�������o�R�s�[
					billPrtSt = CopyToBillPrtStFromBillPrtStWork(billPrtStWork);
				}

			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iBillPrtStDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �����Ӑݒ�V���A���C�Y����
		/// </summary>
		/// <param name="billPrtSt">�V���A���C�Y�Ώێ����Ӑݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �����Ӑݒ�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 92041 ��{�@���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void Serialize(BillPrtSt billPrtSt,string fileName)
		{
			//�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
			BillPrtStWork billPrtStWork = CopyToBillPrtStWorkFromBillPrtSt(billPrtSt);
			//���[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(billPrtStWork,fileName);
		}

		/// <summary>
		/// �����Ӑݒ�List�V���A���C�Y����
		/// </summary>
		/// <param name="billPrtStList">�V���A���C�Y�Ώێ����Ӑݒ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �����Ӑݒ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 92041 ��{�@���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void ListSerialize(ArrayList billPrtStList,string fileName)
		{
			BillPrtStWork[] billPrtStWorks = new BillPrtStWork[billPrtStList.Count];
			for(int i= 0; i < billPrtStList.Count; i++)
			{
				billPrtStWorks[i] = CopyToBillPrtStWorkFromBillPrtSt((BillPrtSt)billPrtStList[i]);
			}
			//�����Ӑݒ胏�[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(billPrtStWorks,fileName);
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�����Ӑݒ胏�[�N�N���X�ˎ����Ӑݒ�N���X�j
		/// </summary>
		/// <returns>�����Ӑݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����Ӑݒ胏�[�N�N���X���玩���Ӑݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 92041 ��{�@���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		// <param name="billPrtStWork">�����Ӑݒ胏�[�N�N���X</param>
		private BillPrtSt CopyToBillPrtStFromBillPrtStWork(BillPrtStWork billPrtStWork)
		{
			BillPrtSt billPrtSt = new BillPrtSt();

			//�t�@�C���w�b�_����
			billPrtSt.CreateDateTime			= billPrtStWork.CreateDateTime;
			billPrtSt.UpdateDateTime			= billPrtStWork.UpdateDateTime;
			billPrtSt.EnterpriseCode			= billPrtStWork.EnterpriseCode;
			billPrtSt.FileHeaderGuid			= billPrtStWork.FileHeaderGuid;
			billPrtSt.UpdEmployeeCode		    = billPrtStWork.UpdEmployeeCode;
			billPrtSt.UpdAssemblyId1			= billPrtStWork.UpdAssemblyId1;
			billPrtSt.UpdAssemblyId2			= billPrtStWork.UpdAssemblyId2;
			billPrtSt.LogicalDeleteCode		    = billPrtStWork.LogicalDeleteCode;

			//��������ݒ�Ǘ��R�[�h
			billPrtSt.BillPrtStMngCd            = billPrtStWork.BillPrtStMngCd;//TODO �K�v���H

			//���z�o�͋敪
			billPrtSt.BillTableOutCd			= billPrtStWork.BillTableOutCd;
			billPrtSt.TotalBillOutputDiv		= billPrtStWork.TotalBillOutputDiv;
			billPrtSt.DetailBillOutputCode      = billPrtStWork.DetailBillOutputCode;

            # region 2007.06.27  S.Koga  DEL
            //// �����O��t�o�͋敪
            //billPrtSt.BillBfRmonOutItem			= billPrtStWork.BillBfRmonOutItem;
			
            ////����������ŏo�͋敪
            //billPrtSt.BillConsTaxOutPutCd	    = billPrtStWork.BillConsTaxOutPutCd;
            # endregion

            //���������󎚋敪
			billPrtSt.BillLastDayPrtDiv			= billPrtStWork.BillLastDayPrtDiv;

            # region 2007.06.27  S.Koga  DEL
            ////���������Ѓv���e�N�g�������
            //billPrtSt.BillEpProtectPrtNm1			= billPrtStWork.BillEpProtectPrtNm1;
            //billPrtSt.BillEpProtectPrtNm2			= billPrtStWork.BillEpProtectPrtNm2;
            //billPrtSt.BillEpProtectPrtNm3			= billPrtStWork.BillEpProtectPrtNm3;
            //billPrtSt.BillEpProtectPrtNm4			= billPrtStWork.BillEpProtectPrtNm4;
            # endregion

			//���������Ж��󎚋敪
			billPrtSt.BillCoNmPrintOutCd			= billPrtStWork.BillCoNmPrintOutCd;
			
			//��������s���󎚋敪 
			billPrtSt.BillBankNmPrintOut			= billPrtStWork.BillBankNmPrintOut;

            # region 2007.06.27  S.Koga  DEL
            ////�������E�v
            //billPrtSt.BillOutline1					= billPrtStWork.BillOutline1;
            //billPrtSt.BillOutline2					= billPrtStWork.BillOutline2;
            # endregion

            // 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//���Ӑ�d�b�ԍ��󎚋敪 
			billPrtSt.CustTelNoPrtDivCd				= billPrtStWork.CustTelNoPrtDivCd;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            /* --- DEL 2008/06/13 -------------------------------->>>>>
            // 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //�������ꎞ���f����
            billPrtSt.BillPrtSuspendCnt				= billPrtStWork.BillPrtSuspendCnt;
            // 2005.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
               --- DEL 2008/06/13 --------------------------------<<<<< */

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// �W���\��\�o�͋敪
            //billPrtSt.ClctMnyPlnDocOutCd            = billPrtStWork.ClctMnyPlnDocOutCd;
            //// �W���\��\�W���\��z�i����p�j
            //billPrtSt.ClctMnyPlnDocVarCst           = billPrtStWork.ClctMnyPlnDocVarCst;
            //// �W���\��\�o�̓^�C�v
            //billPrtSt.ClctMnyPlnDocOutType          = billPrtStWork.ClctMnyPlnDocOutType;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

            return billPrtSt;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�����Ӑݒ�N���X�ˎ����Ӑݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="billPrtSt">�����Ӑݒ胏�[�N�N���X</param>
		/// <returns>�����Ӑݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����Ӑݒ�N���X���玩���Ӑݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 92041 ��{�@���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private BillPrtStWork CopyToBillPrtStWorkFromBillPrtSt(BillPrtSt billPrtSt)
		{
			BillPrtStWork billPrtStWork = new BillPrtStWork();

			billPrtStWork.CreateDateTime			= billPrtSt.CreateDateTime;
			billPrtStWork.UpdateDateTime			= billPrtSt.UpdateDateTime;
			billPrtStWork.EnterpriseCode			= billPrtSt.EnterpriseCode;
			billPrtStWork.FileHeaderGuid			= billPrtSt.FileHeaderGuid;
			billPrtStWork.UpdEmployeeCode		    = billPrtSt.UpdEmployeeCode;
			billPrtStWork.UpdAssemblyId1			= billPrtSt.UpdAssemblyId1;
			billPrtStWork.UpdAssemblyId2			= billPrtSt.UpdAssemblyId2;
			billPrtStWork.LogicalDeleteCode		    = billPrtSt.LogicalDeleteCode;
			
			//��������ݒ�Ǘ��R�[�h
			billPrtStWork.BillPrtStMngCd            = billPrtSt.BillPrtStMngCd;//TODO �K�v���H

			//���z�o�͋敪
			billPrtStWork.BillTableOutCd			= billPrtSt.BillTableOutCd;
			billPrtStWork.TotalBillOutputDiv		= billPrtSt.TotalBillOutputDiv;
			billPrtStWork.DetailBillOutputCode      = billPrtSt.DetailBillOutputCode;

            # region 2007.06.27  S.Koga  DEL
            //// �����O��t�o�͋敪
            //billPrtStWork.BillBfRmonOutItem			= billPrtSt.BillBfRmonOutItem;

            ////����������ŏo�͋敪
            //billPrtStWork.BillConsTaxOutPutCd	    = billPrtSt.BillConsTaxOutPutCd;
            # endregion

            //���������󎚋敪
			billPrtStWork.BillLastDayPrtDiv			= billPrtSt.BillLastDayPrtDiv;

            # region 2007.06.27  S.Koga  DEL
            ////���������Ѓv���e�N�g�������
            //billPrtStWork.BillEpProtectPrtNm1			= billPrtSt.BillEpProtectPrtNm1;
            //billPrtStWork.BillEpProtectPrtNm2			= billPrtSt.BillEpProtectPrtNm2;
            //billPrtStWork.BillEpProtectPrtNm3			= billPrtSt.BillEpProtectPrtNm3;
            //billPrtStWork.BillEpProtectPrtNm4			= billPrtSt.BillEpProtectPrtNm4;
            # endregion

            //���������Ж��󎚋敪
			billPrtStWork.BillCoNmPrintOutCd			= billPrtSt.BillCoNmPrintOutCd;
			
			//��������s���󎚋敪 
			billPrtStWork.BillBankNmPrintOut			= billPrtSt.BillBankNmPrintOut;

            # region 2007.06.27  S.Koga DEL
            ////�������E�v
            //billPrtStWork.BillOutline1					= billPrtSt.BillOutline1;
            //billPrtStWork.BillOutline2					= billPrtSt.BillOutline2;
            # endregion

            // 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//���Ӑ�d�b�ԍ��󎚋敪 
			billPrtStWork.CustTelNoPrtDivCd				= billPrtSt.CustTelNoPrtDivCd;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			// 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//����������ꎞ���f���� 
			billPrtStWork.BillPrtSuspendCnt				= billPrtSt.BillPrtSuspendCnt;
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
               --- DEL 2008/06/13 --------------------------------<<<<< */

            # region 2007.06.27  S.Koga DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// �W���\��\�o�͋敪
            //billPrtStWork.ClctMnyPlnDocOutCd            = billPrtSt.ClctMnyPlnDocOutCd;
            //// �W���\��\�W���\��z�i����p�j
            //billPrtStWork.ClctMnyPlnDocVarCst           = billPrtSt.ClctMnyPlnDocVarCst;
            //// �W���\��\�o�̓^�C�v
            //billPrtStWork.ClctMnyPlnDocOutType          = billPrtSt.ClctMnyPlnDocOutType;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

            return billPrtStWork;
		}
	}
}
