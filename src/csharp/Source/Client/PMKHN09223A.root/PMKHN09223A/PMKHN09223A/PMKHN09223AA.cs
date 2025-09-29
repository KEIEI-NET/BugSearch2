using System;
using System.Collections;
using System.Collections.Generic;
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
    /// ���i�����ݒ�}�X�^ �A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�����ݒ�}�X�^ �A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30290</br>
	/// <br>Date       : 2008.09.19</br>
    /// <br></br>
    /// <br>Update Note: BL�R�[�h�X�V�敪�̒ǉ�(MANTIS[0014774])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/12/11</br>    
	/// </remarks>
	public class PriceChgSetAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IPriceChgProcStDB _IPriceChgProcStDB = null;

		/// <summary>
		/// ���i�����ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public PriceChgSetAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
                this._IPriceChgProcStDB = (IPriceChgProcStDB)MediationPriceChgProcSt.GetPriceChgProcStDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._IPriceChgProcStDB = null;
			}
            
            //���[�J���A�N�Z�X�I�u�W�F�N�g�擾
            //_taxRateSetLcDB = new TaxRateSetLcDB();
		}

        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }

        /// <summary>�����A�N�Z�X�^�C�v</summary>
        public enum SearchMode
        {
            /// <summary>�����[�g</summary>
            Remote = 0,
            /// <summary>���[�J��</summary>
            Local = 1
        }

		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._IPriceChgProcStDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

        /// <summary>
        /// ���i�����ݒ�ǂݍ��ݏ���
        /// </summary>
        /// <param name="priceChkSet">���i�����ݒ�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���i�����ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ݒ��ǂݍ��݂܂��B�i�����[�g�j</br>
        /// <br>Programmer : 19026 ���R�@����</br>
        /// <br>Date       : 2007.05.19</br>
        /// </remarks>
        public int Read(out PriceChgSet priceChkSet, string enterpriseCode)
        {
            return Read(out priceChkSet, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
		/// ���i�����ݒ�ǂݍ��ݏ���
		/// </summary>
        /// <param name="priceChkSet">���i�����ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h(�����[�g or ���[�J��)</param>
		/// <returns>���i�����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ��ǂݍ��݂܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
        /// <br>Update Note: 2007.05.19 19026 ���R�@����</br>
        /// <br>           : ���[�J���A�N�Z�X�Ή��B�V�O�l�`���ύX�isearchMode�ǉ��j</br>
		/// </remarks>
		public int Read(out PriceChgSet priceChkSet, string enterpriseCode, SearchMode searchMode)
		{
			try
			{
				priceChkSet = null;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

				PriceChgProcStWork priceChgWork = new PriceChgProcStWork();
				priceChgWork.EnterpriseCode = enterpriseCode;

                if (searchMode == SearchMode.Remote)
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(priceChgWork);
                    status = this._IPriceChgProcStDB.Read(ref parabyte, 0);

                    if (status == 0)
                        // XML�̓ǂݍ���
                        priceChgWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));
                    else // ���i�����ݒ�擾���s��
                        priceChgWork = new PriceChgProcStWork();
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // ��������Ă��܂���B                    
                }

				//if (status == 0)
				// �N���X�������o�R�s�[
				priceChkSet = CopyToPriceChgProcStWorkFromPriceChgSet(priceChgWork);

				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				priceChkSet = null;
				//�I�t���C������null���Z�b�g
				this._IPriceChgProcStDB = null;

				return -1;
			}
		}

		/// <summary>
		/// ���i�����ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���i�����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public PriceChgSet Deserialize(string fileName)
		{
			PriceChgSet taxrateset = null;
			// �t�@�C������n���ăv�����^�Ǘ����[�N�N���X���f�V���A���C�Y����
			taxrateset = (PriceChgSet)XmlByteSerializer.Deserialize(fileName,typeof(PriceChgSet));

			// �t�@�C������n���ĉ��i�����ݒ胏�[�N�N���X���f�V���A���C�Y����
			PriceChgProcStWork PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(fileName,typeof(PriceChgProcStWork));

			//�f�V���A���C�Y���ʂ����i�����ݒ�N���X�փR�s�[
			if (PriceChgProcStWork != null) taxrateset = CopyToPriceChgProcStWorkFromPriceChgSet(PriceChgProcStWork);

			return taxrateset;
		}

		/// <summary>
		/// ���i�����ݒ�List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���i�����ݒ�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// �t�@�C������n���ĉ��i�����ݒ胏�[�N�N���X���f�V���A���C�Y����
			PriceChgProcStWork[] TaxRateSetWorks = (PriceChgProcStWork[])XmlByteSerializer.Deserialize(fileName,typeof(PriceChgProcStWork[]));

			//�f�V���A���C�Y���ʂ����i�����ݒ�N���X�փR�s�[
			if (TaxRateSetWorks != null) 
			{
				al.Capacity = TaxRateSetWorks.Length;
				for(int i=0; i < TaxRateSetWorks.Length; i++)
				{
					al.Add(CopyToPriceChgProcStWorkFromPriceChgSet(TaxRateSetWorks[i]));
				}
			}
			return al;

		}

		/// <summary>
		/// ���i�����ݒ�o�^�E�X�V����
		/// </summary>
        /// <param name="priceChgSet">���i�����ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Write(ref PriceChgSet priceChgSet)
		{

			// �L�^��Ǘ��N���X����L�^��Ǘ����[�J�[�N���X�Ƀ����o�R�s�[
			PriceChgProcStWork taxratesetWork = CopyToPriceChgSetFromPriceChgProcStWork(priceChgSet);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);

			
			int status = 0;
			try
			{
				// �L�^��Ǘ���������
				status = this._IPriceChgProcStDB.Write(ref parabyte);
				if ( status == 0 )
				{
					// �t�@�C������n���ċL�^��Ǘ����[�N�N���X���f�V���A���C�Y����
					taxratesetWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork) );
					// �N���X�������o�R�s�[
					priceChgSet = CopyToPriceChgProcStWorkFromPriceChgSet(taxratesetWork);
				}
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._IPriceChgProcStDB = null;
				
				// �ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// ���i�����ݒ�V���A���C�Y����
		/// </summary>
        /// <param name="priceChgSet">�V���A���C�Y�Ώۉ��i�����ݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public void Serialize(PriceChgSet priceChgSet, string fileName)
		{
			//���i�����ݒ�N���X���牿�i�����ݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
			PriceChgProcStWork PriceChgProcStWork = CopyToPriceChgSetFromPriceChgProcStWork(priceChgSet);
			//�ŗ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(PriceChgProcStWork,fileName);

		}

		/// <summary>
		/// ���i�����ݒ�List�V���A���C�Y����
		/// </summary>
        /// <param name="priceChgSetList">�V���A���C�Y�Ώۉ��i�����ݒ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public void ListSerialize(ArrayList priceChgSetList,string fileName)
		{
			PriceChgProcStWork[] TaxRateSetWorks = new PriceChgProcStWork[priceChgSetList.Count];
			for(int i= 0; i < priceChgSetList.Count; i++)
			{
				TaxRateSetWorks[i] = CopyToPriceChgSetFromPriceChgProcStWork((PriceChgSet)priceChgSetList[i]);
			}
			//���i�����ݒ胏�[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(TaxRateSetWorks,fileName);

		}

		/// <summary>
		/// ���i�����ݒ�_���폜����
		/// </summary>
        /// <param name="priceChgSet">���i�����ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̘_���폜���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int LogicalDelete(ref PriceChgSet priceChgSet)
		{
			try
			{
				PriceChgProcStWork taxratesetWork = CopyToPriceChgSetFromPriceChgProcStWork(priceChgSet);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
				// �_���폜
				int status = this._IPriceChgProcStDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ċL�^��Ǘ����[�N�N���X���f�V���A���C�Y����
					taxratesetWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize( parabyte, typeof(PriceChgProcStWork));
					// �N���X�������o�R�s�[
					priceChgSet = CopyToPriceChgProcStWorkFromPriceChgSet(taxratesetWork);
				}

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._IPriceChgProcStDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���i�����ݒ蕨���폜����
		/// </summary>
        /// <param name="priceChgSet">���i�����ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̕����폜���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Delete(PriceChgSet priceChgSet)
		{
			try
			{
				PriceChgProcStWork taxratesetWork = CopyToPriceChgSetFromPriceChgProcStWork(priceChgSet);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
				// �L�^��Ǘ������폜
				int status = this._IPriceChgProcStDB.Delete(parabyte);

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._IPriceChgProcStDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���i�����ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ茟���������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, 0);
		}

		/// <summary>
		/// ���i�����ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ茟���������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// ���i�����ݒ萔��������
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ萔�̌������s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			PriceChgProcStWork taxratesetWork = new PriceChgProcStWork();
			taxratesetWork.EnterpriseCode = enterpriseCode;
			
			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);

			// �L�^��Ǘ�����
			int status = this._IPriceChgProcStDB.SearchCnt(out retTotalCnt, parabyte, 0, logicalMode);

			if ( status != 0 )
			{
				retTotalCnt = 0;
			}
	
			return status;
		}

		/// <summary>
		/// ���i�����ݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Search(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;

			//----- ueno upd ---------- start 2008.01.31
			// �����Ȃ��̏ꍇ�����[�g�ݒ�
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ���i�����ݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
		{
			bool nextData;
			int retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// ���i�����ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;

			//----- ueno upd ---------- start 2008.01.31
			// �����Ȃ��̏ꍇ�����[�g�ݒ�
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ���i�����ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
		{
			bool nextData;
			int retTotalCnt;

			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// �����w�艿�i�����ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevTaxrateset">�O��ŏI���i�����ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ĉ��i�����ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,PriceChgSet prevTaxrateset)
		{
			//----- ueno upd ---------- start 2008.01.31
			// �����Ȃ��̏ꍇ�����[�g�ݒ�
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevTaxrateset, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// �����w�艿�i�����ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevTaxrateset">�O��ŏI���i�����ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ĉ��i�����ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, PriceChgSet prevTaxrateset, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevTaxrateset, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// �����w�艿�i�����ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevTaxrateset��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevTaxrateset">�O��ŏI���i�����ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ĉ��i�����ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,PriceChgSet prevTaxrateset)
		{
			//----- ueno upd ---------- start 2008.01.31
			// �����Ȃ��̏ꍇ�����[�g�ݒ�
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevTaxrateset, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}
		
		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// �����w�艿�i�����ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevTaxrateset��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevTaxrateset">�O��ŏI���i�����ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ĉ��i�����ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, PriceChgSet prevTaxrateset, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevTaxrateset, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// ���i�����ݒ�_���폜��������
		/// </summary>
		/// <param name="taxrateset">���i�����ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̕������s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Revival(ref PriceChgSet taxrateset)
		{
			try
			{
				PriceChgProcStWork PriceChgProcStWork = CopyToPriceChgSetFromPriceChgProcStWork(taxrateset);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(PriceChgProcStWork);
				// ��������
				int status = this._IPriceChgProcStDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
					PriceChgProcStWork = (PriceChgProcStWork)XmlByteSerializer.Deserialize(parabyte, typeof(PriceChgProcStWork));
					// �N���X�������o�R�s�[
					taxrateset = CopyToPriceChgProcStWorkFromPriceChgSet(PriceChgProcStWork);
				}

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._IPriceChgProcStDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}


		/// <summary>
		/// ���i�����ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
		/// <param name="prevTaxrateset">�O��ŏI���i�����ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̌����������s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// <br>UpdateNote : 2008.01.31�@30167�@���@�O�M</br>
		/// <br>             ���[�J���A�N�Z�X�Ή��B�V�O�l�`���ύX�isearchMode�ǉ��j</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PriceChgSet prevTaxrateset, SearchMode searchMode)
		{
			PriceChgProcStWork taxratesetWork = new PriceChgProcStWork();

			if ( prevTaxrateset != null )
			{
				taxratesetWork = CopyToPriceChgSetFromPriceChgProcStWork(prevTaxrateset);
			}
			taxratesetWork.EnterpriseCode = enterpriseCode;
			
			// ���f�[�^�L��������
			nextData = false;
			// 0�ŏ�����
			retTotalCnt = 0;

			PriceChgProcStWork[] al;
			retList = new ArrayList();
			retList.Clear();

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
			byte[] retbyte = null;

			// �L�^��Ǘ�����
			int status = 1;
			if (readCnt == 0)
			{				
				if (searchMode == SearchMode.Remote)
				{
					status = this._IPriceChgProcStDB.Search( out retbyte, parabyte, 0, logicalMode);
				}
				else
				{
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // ��������Ă��܂���B
				}				
			}
			else
			{
				status = this._IPriceChgProcStDB.SearchSpecification( out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt );
			}

			if (status == 0)
			{
				// XML�̓ǂݍ���
				al = (PriceChgProcStWork[])XmlByteSerializer.Deserialize(retbyte, typeof(PriceChgProcStWork[]));

				for ( int i = 0; i < al.Length; i++ )
				{
					// �T�[�`���ʎ擾
					PriceChgProcStWork wkTaxRateSetWork = (PriceChgProcStWork)al[i];
					// �L�^��Ǘ��N���X�փ����o�R�s�[
					retList.Add( CopyToPriceChgProcStWorkFromPriceChgSet(wkTaxRateSetWork));
				}
			}
			// �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if ( readCnt == 0 )
			{
				retTotalCnt = retList.Count;
			}
			
			return status;
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// ���i�����ݒ茟�������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds,string enterpriseCode)
		{
		   return SearchDS(ref ds, enterpriseCode, SearchMode.Remote);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// ���i�����ݒ茟�������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// <br>UpdateNote : 2008.01.31�@30167�@���@�O�M</br>
		/// <br>             ���[�J���A�N�Z�X�Ή��B�V�O�l�`���ύX�isearchMode�ǉ��j</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds, string enterpriseCode, SearchMode searchMode)
		{
			PriceChgProcStWork taxratesetWork = new PriceChgProcStWork();
			taxratesetWork.EnterpriseCode = enterpriseCode;

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
			byte[] retbyte = null;

			//----- ueno upd ---------- start 2008.01.31
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			if (searchMode == SearchMode.Remote)
			{
				// �L�^��Ǘ��T�[�`
				status = this._IPriceChgProcStDB.Search(out retbyte, parabyte, 0, 0);
			}
			else
			{
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; // ��������Ă��܂���B				
			}
			//----- ueno upd ---------- end 2008.01.31

			if ( status == 0 )
			{
				XmlByteSerializer.ReadXml(ref ds, retbyte);
			}
				
			return status;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���i�����ݒ胏�[�N�N���X�ˉ��i�����ݒ�N���X�j
		/// </summary>
		/// <param name="PriceChgProcStWork">���i�����ݒ胏�[�N�N���X</param>
		/// <returns>���i�����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ胏�[�N�N���X���牿�i�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private PriceChgSet CopyToPriceChgProcStWorkFromPriceChgSet(PriceChgProcStWork PriceChgProcStWork)
		{
			PriceChgSet priceChgSet = new PriceChgSet();

			//�t�@�C���w�b�_����
			priceChgSet.CreateDateTime			= PriceChgProcStWork.CreateDateTime;
			priceChgSet.UpdateDateTime			= PriceChgProcStWork.UpdateDateTime;
			priceChgSet.EnterpriseCode			= PriceChgProcStWork.EnterpriseCode;
			priceChgSet.FileHeaderGuid			= PriceChgProcStWork.FileHeaderGuid;
			priceChgSet.UpdEmployeeCode		    = PriceChgProcStWork.UpdEmployeeCode;
			priceChgSet.UpdAssemblyId1			= PriceChgProcStWork.UpdAssemblyId1;
			priceChgSet.UpdAssemblyId2			= PriceChgProcStWork.UpdAssemblyId2;
			priceChgSet.LogicalDeleteCode		= PriceChgProcStWork.LogicalDeleteCode;

            priceChgSet.NameUpdDiv               = PriceChgProcStWork.NameUpdDiv; // ���̍X�V�敪
            priceChgSet.PartsLayerUpdDiv         = PriceChgProcStWork.PartsLayerUpdDiv; // �w�ʍX�V�敪
            priceChgSet.PriceUpdDiv              = PriceChgProcStWork.PriceUpdDiv; // ���i�X�V�敪
            priceChgSet.OpenPriceDiv             = PriceChgProcStWork.OpenPriceDiv; // �I�[�v�����i�敪
            priceChgSet.PriceMngCnt              = PriceChgProcStWork.PriceMngCnt; // ���i�Ǘ�����
            priceChgSet.PriceChgProcDiv          = PriceChgProcStWork.PriceChgProcDiv; // ���i���������敪
            // 2009/12/11 Add >>>
            priceChgSet.BLGoodsCdUpdDiv = PriceChgProcStWork.BLGoodsCdUpdDiv;   // BL�R�[�h�X�V�敪
            // 2009/12/11 Add <<<
			return priceChgSet;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���i�����ݒ�N���X�ˉ��i�����ݒ胏�[�N�N���X�j
		/// </summary>
        /// <param name="priceChgSet">���i�����ݒ胏�[�N�N���X</param>
		/// <returns>���i�����ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���i�����ݒ�N���X���牿�i�����ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private PriceChgProcStWork CopyToPriceChgSetFromPriceChgProcStWork(PriceChgSet priceChgSet)
		{

 			PriceChgProcStWork PriceChgProcStWork = new PriceChgProcStWork();

			PriceChgProcStWork.CreateDateTime			= priceChgSet.CreateDateTime;
			PriceChgProcStWork.UpdateDateTime			= priceChgSet.UpdateDateTime;
			PriceChgProcStWork.EnterpriseCode			= priceChgSet.EnterpriseCode;
			PriceChgProcStWork.FileHeaderGuid			= priceChgSet.FileHeaderGuid;
			PriceChgProcStWork.UpdEmployeeCode		    = priceChgSet.UpdEmployeeCode;
			PriceChgProcStWork.UpdAssemblyId1			= priceChgSet.UpdAssemblyId1;
			PriceChgProcStWork.UpdAssemblyId2			= priceChgSet.UpdAssemblyId2;
			PriceChgProcStWork.LogicalDeleteCode		= priceChgSet.LogicalDeleteCode;

            PriceChgProcStWork.NameUpdDiv               = priceChgSet.NameUpdDiv; // ���̍X�V�敪
            PriceChgProcStWork.PartsLayerUpdDiv         = priceChgSet.PartsLayerUpdDiv; // �w�ʍX�V�敪
            PriceChgProcStWork.PriceUpdDiv              = priceChgSet.PriceUpdDiv; // ���i�X�V�敪
            PriceChgProcStWork.OpenPriceDiv             = priceChgSet.OpenPriceDiv; // �I�[�v�����i�敪
            PriceChgProcStWork.PriceMngCnt              = priceChgSet.PriceMngCnt; // ���i�Ǘ�����
            PriceChgProcStWork.PriceChgProcDiv          = priceChgSet.PriceChgProcDiv; // ���i���������敪
            // 2009/12/11 Add >>>
            PriceChgProcStWork.BLGoodsCdUpdDiv= priceChgSet.BLGoodsCdUpdDiv; // BL�R�[�h�X�V�敪
            // 2009/12/11 Add <<<

			return PriceChgProcStWork;
		}

    }
}
