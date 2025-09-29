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
	/// �����ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 23013 �q�@���l</br>
	/// <br>Date       : 2005.08.04</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.21  23006 ���� ���q</br>
	/// <br>				    �E����R�[�h�Q�ƑΉ�</br>
	/// <br></br>
	/// <br>Update Note : 2005.12.20  23006 ���� ���q</br>
	/// <br>				�E�e�}�X�^���f�����Ή�</br>
	/// </remarks>
	public class DepositStAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IDepositStDB _iDepositStDB = null;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
		// ���z��ʓo�^�C���}�X�^���̎擾�p
		private Hashtable _getDepositKindBuff;
		private MoneyKind _moneyKind;
		private MoneyKindAcs _moneyKindAcs;
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END

		/// <summary>
		/// �����ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public DepositStAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iDepositStDB = (IDepositStDB)MediationDepositStDB.GetDepositStDB();
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iDepositStDB = null;
			}

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
			// ���z��ʓo�^�C���}�X�^���̎擾�p
			this._getDepositKindBuff = new Hashtable();
			this._moneyKind = new MoneyKind();
			this._moneyKindAcs = new MoneyKindAcs();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END
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
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iDepositStDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// KEY�w������ݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="depositSt">�����ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="depositStMngCd">�����ݒ�Ǘ�No</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public int Read(out DepositSt depositSt, string enterpriseCode, int depositStMngCd)
		{
			try
			{
				depositSt = null;
				DepositStWork depositStWork = new DepositStWork();
				depositStWork.EnterpriseCode = enterpriseCode;
				depositStWork.DepositStMngCd = depositStMngCd;

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(depositStWork);

				// �����ݒ�ǂݍ���
				int status = this._iDepositStDB.Read(ref parabyte, 0);

				if (status == 0)
				{
					// XML�̓ǂݍ���
					depositStWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte, typeof(DepositStWork));
					// �N���X�������o�R�s�[
					depositSt = CopyToDepositStFromDepositStWork(depositStWork);
				}
				return status;
			}
			catch (Exception)
			{
				//�ʐM�G���[��-1��߂�
				depositSt = null;
				//�I�t���C������null���Z�b�g
				this._iDepositStDB = null;

				return -1;
			}
		}
		/// <summary>
		/// �����ݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="depositSt">�����ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ���̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public int Write(ref DepositSt depositSt)
		{
			// �����ݒ�N���X��������ݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
			DepositStWork depositStWork = CopyToDepositStWorkFromDepositSt(depositSt);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(depositStWork);

			int status = 0;
			try
			{
				// �����ݒ胏�[�N��������
				status = this._iDepositStDB.Write(ref parabyte);
				if (status == 0)
				{
					// �t�@�C������n���ē����ݒ胏�[�N�N���X���f�V���A���C�Y����
					depositStWork = (DepositStWork)XmlByteSerializer.Deserialize(parabyte, typeof(DepositStWork));
					// �N���X�������o�R�s�[
					depositSt = CopyToDepositStFromDepositStWork(depositStWork);
				}
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iDepositStDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�����ݒ胏�[�N�N���X�˓����ݒ�N���X�j
		/// </summary>
		/// <param name="depositStWork">�����ݒ胏�[�N�N���X</param>
		/// <returns>�����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ胏�[�N�N���X��������ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		private DepositSt CopyToDepositStFromDepositStWork(DepositStWork depositStWork)
		{
			DepositSt depositSt = new DepositSt();

			depositSt.CreateDateTime		= depositStWork.CreateDateTime;
			depositSt.UpdateDateTime		= depositStWork.UpdateDateTime;
			depositSt.EnterpriseCode		= depositStWork.EnterpriseCode;
			depositSt.FileHeaderGuid		= depositStWork.FileHeaderGuid;
			depositSt.UpdEmployeeCode		= depositStWork.UpdEmployeeCode;
			depositSt.UpdAssemblyId1		= depositStWork.UpdAssemblyId1;
			depositSt.UpdAssemblyId2		= depositStWork.UpdAssemblyId2;
			depositSt.LogicalDeleteCode		= depositStWork.LogicalDeleteCode;

			depositSt.DepositStMngCd		= depositStWork.DepositStMngCd;
			depositSt.DepositInitDspNo		= depositStWork.DepositInitDspNo;
			//depositSt.InitSelMoneyKindCd	= depositStWork.InitSelMoneyKindCd;
			depositSt.DepositStKindCd1		= depositStWork.DepositStKindCd1;
			depositSt.DepositStKindCd2		= depositStWork.DepositStKindCd2;
			depositSt.DepositStKindCd3		= depositStWork.DepositStKindCd3;
			depositSt.DepositStKindCd4		= depositStWork.DepositStKindCd4;
			depositSt.DepositStKindCd5		= depositStWork.DepositStKindCd5;
			depositSt.DepositStKindCd6		= depositStWork.DepositStKindCd6;
			depositSt.DepositStKindCd7		= depositStWork.DepositStKindCd7;
			depositSt.DepositStKindCd8		= depositStWork.DepositStKindCd8;
			depositSt.DepositStKindCd9		= depositStWork.DepositStKindCd9;
			depositSt.DepositStKindCd10		= depositStWork.DepositStKindCd10;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //depositSt.DepositCallMonths		= depositStWork.DepositCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
			depositSt.AlwcDepoCallMonthsCd	= depositStWork.AlwcDepoCallMonthsCd;

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
			//���z��ʓo�^�C���}�X�^���擾�������̂��g�p
			depositSt.DepositStKindCdNm1   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd1);
			depositSt.DepositStKindCdNm2   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd2);
			depositSt.DepositStKindCdNm3   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd3);
			depositSt.DepositStKindCdNm4   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd4);
			depositSt.DepositStKindCdNm5   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd5);
			depositSt.DepositStKindCdNm6   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd6);
			depositSt.DepositStKindCdNm7   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd7);
			depositSt.DepositStKindCdNm8   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd8);
			depositSt.DepositStKindCdNm9   = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd9);
			depositSt.DepositStKindCdNm10  = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.DepositStKindCd10);
			//depositSt.InitSelMoneyKindCdNm = GetDepsitStKindNm(depositStWork.EnterpriseCode, depositStWork.InitSelMoneyKindCd);
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END

			return depositSt;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�����ݒ�N���X�˓����ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="depositSt">�����ݒ胏�[�N�N���X</param>
		/// <returns>�����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �����ݒ�N���X��������ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 23013 �q�@���l</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		private DepositStWork CopyToDepositStWorkFromDepositSt(DepositSt depositSt)
		{
			DepositStWork depositStWork = new DepositStWork();

			depositStWork.CreateDateTime		= depositSt.CreateDateTime;
			depositStWork.UpdateDateTime		= depositSt.UpdateDateTime;
			depositStWork.EnterpriseCode		= depositSt.EnterpriseCode;
			depositStWork.FileHeaderGuid		= depositSt.FileHeaderGuid;
			depositStWork.UpdEmployeeCode		= depositSt.UpdEmployeeCode;
			depositStWork.UpdAssemblyId1		= depositSt.UpdAssemblyId1;
			depositStWork.UpdAssemblyId2		= depositSt.UpdAssemblyId2;
			depositStWork.LogicalDeleteCode		= depositSt.LogicalDeleteCode;

			depositStWork.DepositStMngCd		= depositSt.DepositStMngCd;
			depositStWork.DepositInitDspNo		= depositSt.DepositInitDspNo;	
			//depositStWork.InitSelMoneyKindCd	= depositSt.InitSelMoneyKindCd;
			depositStWork.DepositStKindCd1		= depositSt.DepositStKindCd1;
			depositStWork.DepositStKindCd2		= depositSt.DepositStKindCd2;
			depositStWork.DepositStKindCd3		= depositSt.DepositStKindCd3;
			depositStWork.DepositStKindCd4		= depositSt.DepositStKindCd4;
			depositStWork.DepositStKindCd5		= depositSt.DepositStKindCd5;
			depositStWork.DepositStKindCd6		= depositSt.DepositStKindCd6;
			depositStWork.DepositStKindCd7		= depositSt.DepositStKindCd7;
			depositStWork.DepositStKindCd8		= depositSt.DepositStKindCd8;
			depositStWork.DepositStKindCd9		= depositSt.DepositStKindCd9;
			depositStWork.DepositStKindCd10		= depositSt.DepositStKindCd10;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.17 TOKUNAGA DEL START
            //depositStWork.DepositCallMonths		= depositSt.DepositCallMonths;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.17 TOKUNAGA DEL END
			depositStWork.AlwcDepoCallMonthsCd	= depositSt.AlwcDepoCallMonthsCd;

			return depositStWork;
		}

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.21 TAKAHASHI ADD START
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���햼�̎擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="depositStKindCd">����R�[�h</param>   
		/// <remarks>
		/// <br>Note       : ���햼�̂��擾���܂��B</br>
		/// <br>Programmer : 23006  ���� ���q</br>
		/// <br>Date       : 2005.09.21</br>
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
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.21 TAKAHASHI ADD END

	}
}
