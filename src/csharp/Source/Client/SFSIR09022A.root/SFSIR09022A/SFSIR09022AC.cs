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
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �x���ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x���ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 21027 �{��  ���u�Y</br>
	/// <br>Date       : 2005.04.12</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.22  23006 ���� ���q</br>
	/// <br>				    �E����R�[�h�Q�ƑΉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.20  23006 ���� ���q</br>
	/// <br>				�E�e�}�X�^���f�����Ή�</br>
    /// <br>Update Note : 2006.06.09  22029 ���R �b��</br>
    /// <br>				�E�V���C�A�E�g�Ή�</br>
    /// <br>Update Note : 2008.06.18  ���i �r��</br>
    /// <br>	�@      �E���ځu�x���`�[�ďo�����v�폜</br>
    /// 
    /// </remarks>
	public class PaymentSetAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IPaymentSetDB _iPaymentSetDB = null;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.22 TAKAHASHI ADD START
		// ���z��ʓo�^�C���}�X�^���̎擾�p
		private Hashtable _getDepositKindBuff;
		private MoneyKind _moneyKind;
		private MoneyKindAcs _moneyKindAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.22 TAKAHASHI ADD END

		/// <summary>
		/// �x���ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �x���ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public PaymentSetAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iPaymentSetDB = (IPaymentSetDB)MediationPaymentSetDB.GetPaymentSetDB();
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iPaymentSetDB = null;
			}

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.22 TAKAHASHI ADD START
			// ���z��ʓo�^�C���}�X�^���̎擾�p
			this._getDepositKindBuff = new Hashtable();
			this._moneyKind = new MoneyKind();
			this._moneyKindAcs = new MoneyKindAcs();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.22 TAKAHASHI ADD END
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
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iPaymentSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// KEY�w��x���ݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="paymentSet">�x���ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="payStMngNo">�x���ݒ�Ǘ�No</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �x���ݒ����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public int Read(out PaymentSet paymentSet, string enterpriseCode, int payStMngNo)
		{
			try
			{
				paymentSet = null;
				PaymentSetWork paymentSetWork = new PaymentSetWork();
				paymentSetWork.EnterpriseCode = enterpriseCode;
				paymentSetWork.PayStMngNo = payStMngNo;

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(paymentSetWork);

				// �x���ݒ�ǂݍ���
				int status = this._iPaymentSetDB.Read(ref parabyte, 0);

				if (status == 0)
				{
					// XML�̓ǂݍ���
					paymentSetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentSetWork));
					// �N���X�������o�R�s�[
					paymentSet = CopyToPaymentSetFromPaymentSetWork(paymentSetWork);
				}
				return status;
			}
			catch (Exception)
			{
				//�ʐM�G���[��-1��߂�
				paymentSet = null;
				//�I�t���C������null���Z�b�g
				this._iPaymentSetDB = null;

				return -1;
			}
		}

		/// <summary>
		/// �x���ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�x���ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �x���ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public PaymentSet Deserialize(string fileName)
		{
			PaymentSet paymentSet = null;
			// �t�@�C������n���Ďx���ݒ胏�[�N�N���X���f�V���A���C�Y����
			PaymentSetWork paymentSetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(fileName, typeof(PaymentSetWork));

			//�f�V���A���C�Y���ʂ��x���ݒ�N���X�փR�s�[
			if (paymentSetWork != null)
			{
				paymentSet = CopyToPaymentSetFromPaymentSetWork(paymentSetWork);
			}

			return paymentSet;
		}

		/// <summary>
		/// �x���ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�x���ݒ�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : �x���ݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// �t�@�C������n���Ďx���ݒ胏�[�N�N���X���f�V���A���C�Y����
			PaymentSetWork[] paymentSetWorks = (PaymentSetWork[])XmlByteSerializer.Deserialize(fileName, typeof(PaymentSetWork[]));

			// �f�V���A���C�Y���ʂ��x���ݒ�N���X�փR�s�[
			if (paymentSetWorks != null)
			{
				al.Capacity = paymentSetWorks.Length;
				for( int i = 0; i < paymentSetWorks.Length; i++ )
				{
					al.Add(CopyToPaymentSetFromPaymentSetWork(paymentSetWorks[i]));
				}
			}

			return al;
		}

		/// <summary>
		/// �x���ݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="paymentSet">�x���ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �x���ݒ���̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public int Write(ref PaymentSet paymentSet)
		{
			// �x���ݒ�N���X����x���ݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
			PaymentSetWork paymentSetWork = CopyToPaymentSetWorkFromPaymentSet(paymentSet);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(paymentSetWork);

			int status = 0;
			try
			{
				// �x���ݒ胏�[�N��������
				status = this._iPaymentSetDB.Write(ref parabyte);
				if (status == 0)
				{
					// �t�@�C������n���Ďx���ݒ胏�[�N�N���X���f�V���A���C�Y����
					paymentSetWork = (PaymentSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(PaymentSetWork));
					// �N���X�������o�R�s�[
					paymentSet = CopyToPaymentSetFromPaymentSetWork(paymentSetWork);
				}
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iPaymentSetDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �x���ݒ�V���A���C�Y����
		/// </summary>
		/// <param name="paymentSet">�V���A���C�Y�Ώێx���ݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �x���ݒ���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public void Serialize(PaymentSet paymentSet, string fileName)
		{
			// �x���ݒ�N���X����x���ݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
			PaymentSetWork paymentSetWork = CopyToPaymentSetWorkFromPaymentSet(paymentSet);
			// �x���ݒ胏�[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(paymentSetWork, fileName);
		}

		/// <summary>
		/// �x���ݒ�List�V���A���C�Y����
		/// </summary>
		/// <param name="paymentSetList">�V���A���C�Y�Ώێx���ݒ�N���XList</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �x���ݒ�N���XList�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		public void ListSerialize(ArrayList paymentSetList, string fileName)
		{
			PaymentSetWork[] paymentSetWorks = new PaymentSetWork[paymentSetList.Count];
			for(int i= 0; i < paymentSetList.Count; i++)
			{
				paymentSetWorks[i] = CopyToPaymentSetWorkFromPaymentSet((PaymentSet)paymentSetList[i]);
			}
			// �x���ݒ胏�[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(paymentSetWorks, fileName);
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�x���ݒ胏�[�N�N���X�ˎx���ݒ�N���X�j
		/// </summary>
		/// <param name="paymentSetWork">�x���ݒ胏�[�N�N���X</param>
		/// <returns>�x���ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �x���ݒ胏�[�N�N���X����x���ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private PaymentSet CopyToPaymentSetFromPaymentSetWork(PaymentSetWork paymentSetWork)
		{
			PaymentSet paymentSet = new PaymentSet();

			paymentSet.CreateDateTime	 = paymentSetWork.CreateDateTime;
			paymentSet.UpdateDateTime	 = paymentSetWork.UpdateDateTime;
			paymentSet.EnterpriseCode	 = paymentSetWork.EnterpriseCode;
			paymentSet.FileHeaderGuid	 = paymentSetWork.FileHeaderGuid;
			paymentSet.UpdEmployeeCode	 = paymentSetWork.UpdEmployeeCode;
			paymentSet.UpdAssemblyId1	 = paymentSetWork.UpdAssemblyId1;
			paymentSet.UpdAssemblyId2	 = paymentSetWork.UpdAssemblyId2;
			paymentSet.LogicalDeleteCode = paymentSetWork.LogicalDeleteCode;

			paymentSet.PayStMngNo		   = paymentSetWork.PayStMngNo;
	�@�@�@�@//2006.06.09  EMI Del		paymentSet.PayInitDspScrNumber = paymentSetWork.PayInitDspScrNumber;
            //2006.06.09  EMI Del		paymentSet.PayInitSystemDiv	   = paymentSetWork.PayInitSystemDiv;
            //2006.06.09  EMI Del		paymentSet.DspOrderOfPaySt	   = paymentSetWork.DspOrderOfPaySt;
            //2006.06.09  EMI Del		paymentSet.LumpSumMoneyKindCd  = paymentSetWork.LumpSumMoneyKindCd;
			paymentSet.PayStMoneyKindCd1   = paymentSetWork.PayStMoneyKindCd1;
			paymentSet.PayStMoneyKindCd2   = paymentSetWork.PayStMoneyKindCd2;
			paymentSet.PayStMoneyKindCd3   = paymentSetWork.PayStMoneyKindCd3;
			paymentSet.PayStMoneyKindCd4   = paymentSetWork.PayStMoneyKindCd4;
			paymentSet.PayStMoneyKindCd5   = paymentSetWork.PayStMoneyKindCd5;
			paymentSet.PayStMoneyKindCd6   = paymentSetWork.PayStMoneyKindCd6;
			paymentSet.PayStMoneyKindCd7   = paymentSetWork.PayStMoneyKindCd7;
			paymentSet.PayStMoneyKindCd8   = paymentSetWork.PayStMoneyKindCd8;
			paymentSet.PayStMoneyKindCd9   = paymentSetWork.PayStMoneyKindCd9;
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            paymentSet.PayStMoneyKindCd10 = paymentSetWork.PayStMoneyKindCd10;
            //paymentSet.InitSelMoneyKindCd = paymentSetWork.InitSelMoneyKindCd;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //paymentSet.PaySlipCallMonths = paymentSetWork.PaySlipCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.22 TAKAHASHI ADD START
			paymentSet.PayStMoneyKindNm1 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd1);
			paymentSet.PayStMoneyKindNm2 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd2);
			paymentSet.PayStMoneyKindNm3 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd3);
			paymentSet.PayStMoneyKindNm4 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd4);
			paymentSet.PayStMoneyKindNm5 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd5);
			paymentSet.PayStMoneyKindNm6 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd6);
			paymentSet.PayStMoneyKindNm7 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd7);
			paymentSet.PayStMoneyKindNm8 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd8);
			paymentSet.PayStMoneyKindNm9 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd9);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.22 TAKAHASHI ADD END
//2006.06.09  EMI Add>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            paymentSet.PayStMoneyKindNm10 = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.PayStMoneyKindCd10);
            //paymentSet.InitSelMoneyKindNm = GetDepsitStKindNm(paymentSetWork.EnterpriseCode, paymentSetWork.InitSelMoneyKindCd); 
//2006.06.09  EMI Add<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return paymentSet; 
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�x���ݒ�N���X�ˎx���ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="paymentSet">�x���ݒ胏�[�N�N���X</param>
		/// <returns>�x���ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �x���ݒ�N���X����x���ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.12</br>
		/// </remarks>
		private PaymentSetWork CopyToPaymentSetWorkFromPaymentSet(PaymentSet paymentSet)
		{
			PaymentSetWork paymentSetWork = new PaymentSetWork();

			paymentSetWork.CreateDateTime		= paymentSet.CreateDateTime;
			paymentSetWork.UpdateDateTime		= paymentSet.UpdateDateTime;
			paymentSetWork.EnterpriseCode		= paymentSet.EnterpriseCode;
			paymentSetWork.FileHeaderGuid		= paymentSet.FileHeaderGuid;
			paymentSetWork.UpdEmployeeCode		= paymentSet.UpdEmployeeCode;
			paymentSetWork.UpdAssemblyId1		= paymentSet.UpdAssemblyId1;
			paymentSetWork.UpdAssemblyId2		= paymentSet.UpdAssemblyId2;
			paymentSetWork.LogicalDeleteCode	= paymentSet.LogicalDeleteCode;

			paymentSetWork.PayStMngNo			= paymentSet.PayStMngNo;
            //2006.06.09  EMI Del		paymentSetWork.PayInitDspScrNumber	= paymentSet.PayInitDspScrNumber;
            //2006.06.09  EMI Del		paymentSetWork.PayInitSystemDiv		= paymentSet.PayInitSystemDiv;
            //2006.06.09  EMI Del		paymentSetWork.DspOrderOfPaySt		= paymentSet.DspOrderOfPaySt;
            //2006.06.09  EMI Del		paymentSetWork.LumpSumMoneyKindCd	= paymentSet.LumpSumMoneyKindCd;
			paymentSetWork.PayStMoneyKindCd1	= paymentSet.PayStMoneyKindCd1;
			paymentSetWork.PayStMoneyKindCd2	= paymentSet.PayStMoneyKindCd2;
			paymentSetWork.PayStMoneyKindCd3	= paymentSet.PayStMoneyKindCd3;
			paymentSetWork.PayStMoneyKindCd4	= paymentSet.PayStMoneyKindCd4;
			paymentSetWork.PayStMoneyKindCd5	= paymentSet.PayStMoneyKindCd5;
			paymentSetWork.PayStMoneyKindCd6	= paymentSet.PayStMoneyKindCd6;
			paymentSetWork.PayStMoneyKindCd7	= paymentSet.PayStMoneyKindCd7;
			paymentSetWork.PayStMoneyKindCd8	= paymentSet.PayStMoneyKindCd8;
			paymentSetWork.PayStMoneyKindCd9	= paymentSet.PayStMoneyKindCd9;
//2006.06.09  EMI Del>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            paymentSetWork.PayStMoneyKindCd10   = paymentSet.PayStMoneyKindCd10;
            //paymentSetWork.InitSelMoneyKindCd = paymentSet.InitSelMoneyKindCd;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //paymentSetWork.PaySlipCallMonths = paymentSet.PaySlipCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END

//2006.06.09  EMI Del<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return paymentSetWork;
		} 

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.22 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���햼�̎擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="depositStKindCd">����R�[�h</param>   
		/// <remarks>
		/// <br>Note        : ���햼�̂��擾���܂��B</br>
		/// <br>Programmer  : 23006  ���� ���q</br>
		/// <br>Date        : 2005.09.22</br>
		/// <br></br>
		/// <br>Update Note : ���햼�̂��擾���܂��B</br>
		/// <br>Programmer  : 23006  ���� ���q</br>
		/// <br>Date        : 2005.12.20</br>
		/// </remarks>
		public string GetDepsitStKindNm(string enterpriseCode, int depositStKindCd)
		{		
			int status = 0;
			int moneyKindMode = 1;

			ArrayList allMoneyKindList = new ArrayList();
			Hashtable moneyKindTable = new Hashtable();

			// ���z��ʃ}�X�^���A�_���폜�����܂ރf�[�^���擾
			status = this._moneyKindAcs.GetBuff(out allMoneyKindList, enterpriseCode, moneyKindMode);

			if (status == 0)
			{
				foreach (MoneyKind moneyKindInfo in allMoneyKindList)
				{
					// ���z�ݒ�敪���u0:�����v�̏ꍇ�A��r
					if ((moneyKindInfo.PriceStCode == 0) && (moneyKindInfo.MoneyKindCode == depositStKindCd))
					{
						if (moneyKindInfo.LogicalDeleteCode == 0)
						{
							return moneyKindInfo.MoneyKindName;
						}
						else
						{
							return "�폜��";
						}
					}
				}

				return "���o�^";
			}
			else
			{
				return "";
			}
		}
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.22 TAKAHASHI ADD END
	}
}
