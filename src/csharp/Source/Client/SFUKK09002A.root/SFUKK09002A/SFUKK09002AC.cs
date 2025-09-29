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
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �ŗ��ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ŗ��ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 21041 �����@��</br>
	/// <br>Date       : 2005.04.01</br>
	/// <br>Update Note: 2005.06.21 96138 ����  ����</br>
	/// <br>           : �����񍀖ڌ���̃X�y�[�X�J�b�g�B</br>
    /// <br>Update Note: 2007.05.19 19026 ���R�@����</br>
    /// <br>           : ���[�J���A�N�Z�X�Ή�(Read�̂�)</br>
    /// <br>Update Note: 2007.08.16 980035 ���� ��`</br>
    /// <br>			 �[�������敪���폜���ď���œ]�ŕ�����ǉ�</br>
	/// <br>Update Note: 2008.01.31 30167 ���@�O�M</br>
	/// <br>			 ���[�J���c�a�Ή�</br>
    /// <br>Update Note: 2008.07.31 21024 ���X�؁@��</br>
    /// <br>			 �ŗ��擾�p���\�b�h�ǉ�</br>
    /// <br>Update Note: 2008.12.01 21024 ���X�؁@��</br>
    /// <br>			 Search�̃����[�g�C���Ή�</br>
    /// <br>Update Note: 2013/12/16 杍^</br>
    /// <br>			 Redmine#41551�̑Ή� �����8%���łɔ����āA�������ꂽ��Q�̑Ή�</br>
    /// <br></br>
	/// </remarks>
	public class TaxRateSetAcs
	{
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private ITaxRateSetDB _iTaxratesetDB = null;
        /// <summary>���[�J��DB�A�N�Z�X�N���X</summary>
        private TaxRateSetLcDB _taxRateSetLcDB = null;

		/// <summary>
		/// �ŗ��ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public TaxRateSetAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iTaxratesetDB = (ITaxRateSetDB)MediationTaxRateSetDB.GetTaxRateSetDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iTaxratesetDB = null;
			}
            
            //���[�J���A�N�Z�X�I�u�W�F�N�g�擾
            _taxRateSetLcDB = new TaxRateSetLcDB();
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
			if (this._iTaxratesetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

        /// <summary>
        /// �ŗ��ݒ�ǂݍ��ݏ���
        /// </summary>
        /// <param name="taxrateset">�ŗ��ݒ�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="taxRateCode">�ŗ��R�[�h</param>
        /// <returns>�ŗ��ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �ŗ��ݒ��ǂݍ��݂܂��B�i�����[�g�j</br>
        /// <br>Programmer : 19026 ���R�@����</br>
        /// <br>Date       : 2007.05.19</br>
        /// </remarks>
        public int Read(out TaxRateSet taxrateset, string enterpriseCode, int taxRateCode)
        {
            return Read(out taxrateset, enterpriseCode, taxRateCode, SearchMode.Remote);
        }

        /// <summary>
		/// �ŗ��ݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="taxrateset">�ŗ��ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="taxRateCode">�ŗ��R�[�h</param>
        /// <param name="searchMode">�������[�h(�����[�g or ���[�J��)</param>
		/// <returns>�ŗ��ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ��ǂݍ��݂܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
        /// <br>Update Note: 2007.05.19 19026 ���R�@����</br>
        /// <br>           : ���[�J���A�N�Z�X�Ή��B�V�O�l�`���ύX�isearchMode�ǉ��j</br>
		/// </remarks>
		public int Read(out TaxRateSet taxrateset, string enterpriseCode, int taxRateCode, SearchMode searchMode)
		{
			try
			{
				taxrateset = null;
                int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

				TaxRateSetWork taxratesetWork = new TaxRateSetWork();
				taxratesetWork.EnterpriseCode = enterpriseCode;
				taxratesetWork.TaxRateCode = taxRateCode;

                if (searchMode == SearchMode.Remote)
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
                    status = this._iTaxratesetDB.Read(ref parabyte, 0);

                    if (status == 0)
                        // XML�̓ǂݍ���
                        taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(TaxRateSetWork));
                }
                else
                {
                    status = this._taxRateSetLcDB.Read(ref taxratesetWork, 0);
                }

				if (status == 0)
					// �N���X�������o�R�s�[
					taxrateset = CopyToTaxratesetFromTaxRateSetWork(taxratesetWork);

				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				taxrateset = null;
				//�I�t���C������null���Z�b�g
				this._iTaxratesetDB = null;

				return -1;
			}
		}

		/// <summary>
		/// �ŗ��ݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�ŗ��ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public TaxRateSet Deserialize(string fileName)
		{
			TaxRateSet taxrateset = null;
			// �t�@�C������n���ăv�����^�Ǘ����[�N�N���X���f�V���A���C�Y����
			taxrateset = (TaxRateSet)XmlByteSerializer.Deserialize(fileName,typeof(TaxRateSet));

			// �t�@�C������n���Đŗ��ݒ胏�[�N�N���X���f�V���A���C�Y����
			TaxRateSetWork TaxRateSetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(fileName,typeof(TaxRateSetWork));

			//�f�V���A���C�Y���ʂ�ŗ��ݒ�N���X�փR�s�[
			if (TaxRateSetWork != null) taxrateset = CopyToTaxratesetFromTaxRateSetWork(TaxRateSetWork);

			return taxrateset;
		}

		/// <summary>
		/// �ŗ��ݒ�List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�ŗ��ݒ�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// �t�@�C������n���Đŗ��ݒ胏�[�N�N���X���f�V���A���C�Y����
			TaxRateSetWork[] TaxRateSetWorks = (TaxRateSetWork[])XmlByteSerializer.Deserialize(fileName,typeof(TaxRateSetWork[]));

			//�f�V���A���C�Y���ʂ�ŗ��ݒ�N���X�փR�s�[
			if (TaxRateSetWorks != null) 
			{
				al.Capacity = TaxRateSetWorks.Length;
				for(int i=0; i < TaxRateSetWorks.Length; i++)
				{
					al.Add(CopyToTaxratesetFromTaxRateSetWork(TaxRateSetWorks[i]));
				}
			}
			return al;

		}

		/// <summary>
		/// �ŗ��ݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="taxrateset">�ŗ��ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Write(ref TaxRateSet taxrateset)
		{

			// �L�^��Ǘ��N���X����L�^��Ǘ����[�J�[�N���X�Ƀ����o�R�s�[
			TaxRateSetWork taxratesetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);

			
			int status = 0;
			try
			{
				// �L�^��Ǘ���������
				status = this._iTaxratesetDB.Write(ref parabyte);
				if ( status == 0 )
				{
					// �t�@�C������n���ċL�^��Ǘ����[�N�N���X���f�V���A���C�Y����
					taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(TaxRateSetWork) );
					// �N���X�������o�R�s�[
					taxrateset = CopyToTaxratesetFromTaxRateSetWork(taxratesetWork);
				}
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iTaxratesetDB = null;
				
				// �ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �ŗ��ݒ�List��r�p�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : IComparable �C���^�[�t�F�C�X�̎����B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public class TaxratesetKey : IComparer  
		{
			/// <summary>
			/// List��r���\�b�h
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <remarks>
			/// <br>Note       : x��y���r���A�������Ƃ��̓}�C�i�X�A</br>
			/// <br>           : �傫���Ƃ��̓v���X�A�����Ƃ��̓[����Ԃ��܂��B</br>
			/// <br>Programmer : 21041 �����@��</br>
			/// <br>Date       : 2005.04.01</br>
			/// </remarks>
			public int Compare(object x, object y)
			{
				TaxRateSet taxratesetX = (TaxRateSet)x;
				TaxRateSet taxratesetY = (TaxRateSet)y;
				return (taxratesetX.TaxRateCode - taxratesetY.TaxRateCode);
			}
		}

		/// <summary>
		/// �ŗ��ݒ�V���A���C�Y����
		/// </summary>
		/// <param name="taxrateset">�V���A���C�Y�Ώېŗ��ݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public void Serialize(TaxRateSet taxrateset, string fileName)
		{
			//�ŗ��ݒ�N���X����ŗ��ݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
			TaxRateSetWork TaxRateSetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);
			//�ŗ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(TaxRateSetWork,fileName);

		}

		/// <summary>
		/// �ŗ��ݒ�List�V���A���C�Y����
		/// </summary>
		/// <param name="taxratesetList">�V���A���C�Y�Ώېŗ��ݒ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public void ListSerialize(ArrayList taxratesetList,string fileName)
		{
			TaxRateSetWork[] TaxRateSetWorks = new TaxRateSetWork[taxratesetList.Count];
			for(int i= 0; i < taxratesetList.Count; i++)
			{
				TaxRateSetWorks[i] = CopyToTaxRateSetWorkFromTaxrateset((TaxRateSet)taxratesetList[i]);
			}
			//�ŗ��ݒ胏�[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(TaxRateSetWorks,fileName);

		}

		/// <summary>
		/// �ŗ��ݒ�_���폜����
		/// </summary>
		/// <param name="taxrateset">�ŗ��ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̘_���폜���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int LogicalDelete(ref TaxRateSet taxrateset)
		{
			try
			{
				TaxRateSetWork taxratesetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
				// �_���폜
				int status = this._iTaxratesetDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ċL�^��Ǘ����[�N�N���X���f�V���A���C�Y����
					taxratesetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize( parabyte, typeof(TaxRateSetWork));
					// �N���X�������o�R�s�[
					taxrateset = CopyToTaxratesetFromTaxRateSetWork(taxratesetWork);
				}

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iTaxratesetDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �ŗ��ݒ蕨���폜����
		/// </summary>
		/// <param name="taxrateset">�ŗ��ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̕����폜���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Delete(TaxRateSet taxrateset)
		{
			try
			{
				TaxRateSetWork taxratesetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
				// �L�^��Ǘ������폜
				int status = this._iTaxratesetDB.Delete(parabyte);

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iTaxratesetDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �ŗ��ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ茟���������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, 0);
		}

		/// <summary>
		/// �ŗ��ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ茟���������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// �ŗ��ݒ萔��������
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ萔�̌������s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			TaxRateSetWork taxratesetWork = new TaxRateSetWork();
			taxratesetWork.EnterpriseCode = enterpriseCode;
			
			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);

			// �L�^��Ǘ�����
			int status = this._iTaxratesetDB.SearchCnt(out retTotalCnt, parabyte, 0, logicalMode);

			if ( status != 0 )
			{
				retTotalCnt = 0;
			}
	
			return status;
		}

		/// <summary>
		/// �ŗ��ݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
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
		/// �ŗ��ݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
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
		/// �ŗ��ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
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
		/// �ŗ��ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
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
		/// �����w��ŗ��ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevTaxrateset">�O��ŏI�ŗ��ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�Đŗ��ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,TaxRateSet prevTaxrateset)
		{
			//----- ueno upd ---------- start 2008.01.31
			// �����Ȃ��̏ꍇ�����[�g�ݒ�
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevTaxrateset, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// �����w��ŗ��ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevTaxrateset">�O��ŏI�ŗ��ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�Đŗ��ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, TaxRateSet prevTaxrateset, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevTaxrateset, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// �����w��ŗ��ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevTaxrateset��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevTaxrateset">�O��ŏI�ŗ��ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�Đŗ��ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,TaxRateSet prevTaxrateset)
		{
			//----- ueno upd ---------- start 2008.01.31
			// �����Ȃ��̏ꍇ�����[�g�ݒ�
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevTaxrateset, SearchMode.Remote);
			//----- ueno upd ---------- end 2008.01.31
		}
		
		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// �����w��ŗ��ݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevTaxrateset��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevTaxrateset">�O��ŏI�ŗ��ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�Đŗ��ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>             �������[�h�Ń��[�J���ǂݍ��݂������[�e�B���O����؂�ւ��܂��B</br>
		/// <br>Programmer : 30167�@���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, TaxRateSet prevTaxrateset, SearchMode searchMode)
		{
			return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, readCnt, prevTaxrateset, searchMode);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// �ŗ��ݒ�_���폜��������
		/// </summary>
		/// <param name="taxrateset">�ŗ��ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̕������s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		public int Revival(ref TaxRateSet taxrateset)
		{
			try
			{
				TaxRateSetWork TaxRateSetWork = CopyToTaxRateSetWorkFromTaxrateset(taxrateset);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(TaxRateSetWork);
				// ��������
				int status = this._iTaxratesetDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
					TaxRateSetWork = (TaxRateSetWork)XmlByteSerializer.Deserialize(parabyte, typeof(TaxRateSetWork));
					// �N���X�������o�R�s�[
					taxrateset = CopyToTaxratesetFromTaxRateSetWork(TaxRateSetWork);
				}

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iTaxratesetDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}


		/// <summary>
		/// �ŗ��ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
		/// <param name="prevTaxrateset">�O��ŏI�ŗ��ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̌����������s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// <br>UpdateNote : 2008.01.31�@30167�@���@�O�M</br>
		/// <br>             ���[�J���A�N�Z�X�Ή��B�V�O�l�`���ύX�isearchMode�ǉ��j</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, TaxRateSet prevTaxrateset, SearchMode searchMode)
		{
			TaxRateSetWork taxratesetWork = new TaxRateSetWork();

			if ( prevTaxrateset != null )
			{
				taxratesetWork = CopyToTaxRateSetWorkFromTaxrateset(prevTaxrateset);
			}
			taxratesetWork.EnterpriseCode = enterpriseCode;
			
			// ���f�[�^�L��������
			nextData = false;
			// 0�ŏ�����
			retTotalCnt = 0;

			TaxRateSetWork[] al;
			retList = new ArrayList();
			retList.Clear();

            // 2008.12.01 Update >>>
            //// XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
            //byte[] retbyte = null;

            //// �L�^��Ǘ�����
            //int status = 1;
            //if (readCnt == 0)
            //{
            //    //----- ueno upd ---------- start 2008.01.31
            //    if (searchMode == SearchMode.Remote)
            //    {
            //        status = this._iTaxratesetDB.Search( out retbyte, parabyte, 0, logicalMode);
            //    }
            //    else
            //    {
            //        List<TaxRateSetWork> taxRateSetWorkList = new List<TaxRateSetWork>();
            //        status = this._taxRateSetLcDB.Search(out taxRateSetWorkList, taxratesetWork, 0, logicalMode);

            //        if (status == 0)
            //        {
            //            ArrayList wkAl = new ArrayList();
            //            wkAl.AddRange(taxRateSetWorkList);

            //            byte[] wkByte = XmlByteSerializer.Serialize(taxRateSetWorkList);
            //            retbyte = wkByte;
            //        }
            //    }
            //    //----- ueno upd ---------- end 2008.01.31
            //}
            //else
            //{
            //    status = this._iTaxratesetDB.SearchSpecification( out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt );
            //}

            //if (status == 0)
            //{
            //    // XML�̓ǂݍ���
            //    al = (TaxRateSetWork[])XmlByteSerializer.Deserialize(retbyte, typeof(TaxRateSetWork[]));

            //    for ( int i = 0; i < al.Length; i++ )
            //    {
            //        // �T�[�`���ʎ擾
            //        TaxRateSetWork wkTaxRateSetWork = (TaxRateSetWork)al[i];
            //        // �L�^��Ǘ��N���X�փ����o�R�s�[
            //        retList.Add( CopyToTaxratesetFromTaxRateSetWork(wkTaxRateSetWork));
            //    }
            //}
            //// �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            //if ( readCnt == 0 )
            //{
            //    retTotalCnt = retList.Count;
            //}

            int status = 1;

            if (readCnt == 0)
            {
                ArrayList retArrayList = new ArrayList();
                if (searchMode == SearchMode.Remote)
                {
                    object retObj;
                    object paraObj = taxratesetWork;
                    status = this._iTaxratesetDB.Search(out retObj, paraObj, 0, logicalMode);
                    if (retObj is ArrayList)
                    {
                        retArrayList = (ArrayList)retObj;
                    }
                }
                else
                {
                    List<TaxRateSetWork> taxRateSetWorkList = new List<TaxRateSetWork>();
                    status = this._taxRateSetLcDB.Search(out taxRateSetWorkList, taxratesetWork, 0, logicalMode);

                    if (status == 0)
                    {
                        retArrayList.AddRange(taxRateSetWorkList);
                    }
                }

                if (status == 0)
                {
                    foreach (TaxRateSetWork wkTaxRateSetWork in retArrayList)
                    {
                        // �L�^��Ǘ��N���X�փ����o�R�s�[
                        retList.Add(CopyToTaxratesetFromTaxRateSetWork(wkTaxRateSetWork));
                    }
                }
                retTotalCnt = retList.Count;
            }
            else
            {
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
                byte[] retbyte = null;

                status = this._iTaxratesetDB.SearchSpecification(out retbyte, out retTotalCnt, out nextData, parabyte, 0, logicalMode, readCnt);

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    al = (TaxRateSetWork[])XmlByteSerializer.Deserialize(retbyte, typeof(TaxRateSetWork[]));

                    for (int i = 0; i < al.Length; i++)
                    {
                        // �T�[�`���ʎ擾
                        TaxRateSetWork wkTaxRateSetWork = (TaxRateSetWork)al[i];
                        // �L�^��Ǘ��N���X�փ����o�R�s�[
                        retList.Add(CopyToTaxratesetFromTaxRateSetWork(wkTaxRateSetWork));
                    }
                }
            }
            // 2008.12.01 Update <<<
			
			return status;
		}

		//----- ueno add ---------- start 2008.01.31
		/// <summary>
		/// �ŗ��ݒ茟�������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.31</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds,string enterpriseCode)
		{
		   return SearchDS(ref ds, enterpriseCode, SearchMode.Remote);
		}
		//----- ueno add ---------- end 2008.01.31

		/// <summary>
		/// �ŗ��ݒ茟�������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="searchMode">�������[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// <br>UpdateNote : 2008.01.31�@30167�@���@�O�M</br>
		/// <br>             ���[�J���A�N�Z�X�Ή��B�V�O�l�`���ύX�isearchMode�ǉ��j</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds, string enterpriseCode, SearchMode searchMode)
		{
			TaxRateSetWork taxratesetWork = new TaxRateSetWork();
			taxratesetWork.EnterpriseCode = enterpriseCode;

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(taxratesetWork);
			byte[] retbyte = null;

			//----- ueno upd ---------- start 2008.01.31
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			if (searchMode == SearchMode.Remote)
			{
				// �L�^��Ǘ��T�[�`
				status = this._iTaxratesetDB.Search(out retbyte, parabyte, 0, 0);
			}
			else
			{
				// �L�^��Ǘ��T�[�`
				List<TaxRateSetWork> taxRateSetWorkList = new List<TaxRateSetWork>();
				status = this._taxRateSetLcDB.Search(out taxRateSetWorkList, taxratesetWork, 0, 0);

				if (status == 0)
				{
					ArrayList wkAl = new ArrayList();
					wkAl.AddRange(taxRateSetWorkList);

					byte[] wkByte = XmlByteSerializer.Serialize(taxRateSetWorkList);
					retbyte = wkByte;
				}
			}
			//----- ueno upd ---------- end 2008.01.31

			if ( status == 0 )
			{
				XmlByteSerializer.ReadXml(ref ds, retbyte);
			}
				
			return status;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ŗ��ݒ胏�[�N�N���X�ːŗ��ݒ�N���X�j
		/// </summary>
		/// <param name="TaxRateSetWork">�ŗ��ݒ胏�[�N�N���X</param>
		/// <returns>�ŗ��ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ胏�[�N�N���X����ŗ��ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>

		private TaxRateSet CopyToTaxratesetFromTaxRateSetWork(TaxRateSetWork TaxRateSetWork)
		{
			TaxRateSet taxrateset = new TaxRateSet();

			//�t�@�C���w�b�_����
			taxrateset.CreateDateTime			= TaxRateSetWork.CreateDateTime;
			taxrateset.UpdateDateTime			= TaxRateSetWork.UpdateDateTime;
			taxrateset.EnterpriseCode			= TaxRateSetWork.EnterpriseCode;
			taxrateset.FileHeaderGuid			= TaxRateSetWork.FileHeaderGuid;
			taxrateset.UpdEmployeeCode		    = TaxRateSetWork.UpdEmployeeCode;
			taxrateset.UpdAssemblyId1			= TaxRateSetWork.UpdAssemblyId1;
			taxrateset.UpdAssemblyId2			= TaxRateSetWork.UpdAssemblyId2;
			taxrateset.LogicalDeleteCode			= TaxRateSetWork.LogicalDeleteCode;

			taxrateset.TaxRateCode				= TaxRateSetWork.TaxRateCode;
			taxrateset.TaxRateProperNounNm		= TaxRateSetWork.TaxRateProperNounNm;
			taxrateset.TaxRateName				= TaxRateSetWork.TaxRateName;
            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            //taxrateset.FractionProcCd         = TaxRateSetWork.FractionProcCd;
            taxrateset.ConsTaxLayMethod         = TaxRateSetWork.ConsTaxLayMethod;
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
            taxrateset.TaxRateStartDate = TaxRateSetWork.TaxRateStartDate;
			taxrateset.TaxRateEndDate			= TaxRateSetWork.TaxRateEndDate;
			taxrateset.TaxRate					= TaxRateSetWork.TaxRate;
			taxrateset.TaxRateStartDate2		= TaxRateSetWork.TaxRateStartDate2;
			taxrateset.TaxRateEndDate2			= TaxRateSetWork.TaxRateEndDate2;
			taxrateset.TaxRate2					= TaxRateSetWork.TaxRate2;
			taxrateset.TaxRateStartDate3		= TaxRateSetWork.TaxRateStartDate3;
			taxrateset.TaxRateEndDate3			= TaxRateSetWork.TaxRateEndDate3;
			taxrateset.TaxRate3					= TaxRateSetWork.TaxRate3;
			return taxrateset;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�ŗ��ݒ�N���X�ːŗ��ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="taxrateset">�ŗ��ݒ胏�[�N�N���X</param>
		/// <returns>�ŗ��ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �ŗ��ݒ�N���X����ŗ��ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private TaxRateSetWork CopyToTaxRateSetWorkFromTaxrateset(TaxRateSet taxrateset)
		{

 			TaxRateSetWork TaxRateSetWork = new TaxRateSetWork();

			TaxRateSetWork.CreateDateTime			= taxrateset.CreateDateTime;
			TaxRateSetWork.UpdateDateTime			= taxrateset.UpdateDateTime;
			TaxRateSetWork.EnterpriseCode			= taxrateset.EnterpriseCode;
			TaxRateSetWork.FileHeaderGuid			= taxrateset.FileHeaderGuid;
			TaxRateSetWork.UpdEmployeeCode		    = taxrateset.UpdEmployeeCode;
			TaxRateSetWork.UpdAssemblyId1			= taxrateset.UpdAssemblyId1;
			TaxRateSetWork.UpdAssemblyId2			= taxrateset.UpdAssemblyId2;
			TaxRateSetWork.LogicalDeleteCode		= taxrateset.LogicalDeleteCode;

			TaxRateSetWork.TaxRateCode				= taxrateset.TaxRateCode;
			// 2005.06.21 �����񍀖ڂ̃X�y�[�X�J�b�g�B >>>> START
			/*
			TaxRateSetWork.TaxRateProperNounNm		= taxrateset.TaxRateProperNounNm;
			TaxRateSetWork.TaxRateName				= taxrateset.TaxRateName;
			*/
			TaxRateSetWork.TaxRateProperNounNm		= taxrateset.TaxRateProperNounNm.TrimEnd();
			TaxRateSetWork.TaxRateName				= taxrateset.TaxRateName.TrimEnd();
			// 2005.06.21 �����񍀖ڂ̃X�y�[�X�J�b�g�B >>>> END

            // 2007.08.16 �C�� >>>>>>>>>>>>>>>>>>>>
            //TaxRateSetWork.FractionProcCd         = taxrateset.FractionProcCd;
            TaxRateSetWork.ConsTaxLayMethod         = taxrateset.ConsTaxLayMethod;
            // 2007.08.16 �C�� <<<<<<<<<<<<<<<<<<<<
            TaxRateSetWork.TaxRateStartDate         = taxrateset.TaxRateStartDate;
			TaxRateSetWork.TaxRateEndDate			= taxrateset.TaxRateEndDate;
			TaxRateSetWork.TaxRate					= taxrateset.TaxRate;
			TaxRateSetWork.TaxRateStartDate2		= taxrateset.TaxRateStartDate2;
			TaxRateSetWork.TaxRateEndDate2			= taxrateset.TaxRateEndDate2;
			TaxRateSetWork.TaxRate2					= taxrateset.TaxRate2;
			TaxRateSetWork.TaxRateStartDate3		= taxrateset.TaxRateStartDate3;
			TaxRateSetWork.TaxRateEndDate3			= taxrateset.TaxRateEndDate3;
			TaxRateSetWork.TaxRate3					= taxrateset.TaxRate3;

			return TaxRateSetWork;
		}
		/// <summary>
		/// �Ώۃf�[�^�`�F�b�N
		/// </summary>
		/// <param name="taxrateset">�Ώۃf�[�^</param>
		/// <param name="taxratesetPara">�p�����[�^</param>
		/// <returns>�`�F�b�N���ʁitrue:OK false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �Ώۃf�[�^�ƃp�����[�^���r���܂��B</br>
		/// <br>Programmer : 21041 �����@��</br>
		/// <br>Date       : 2005.04.01</br>
		/// </remarks>
		private bool checkTarGetData(
			TaxRateSet taxrateset,
			TaxRateSet taxratesetPara)
		{
			// ��ƃR�[�h���r
			if (taxratesetPara.EnterpriseCode != null)
				if (!taxratesetPara.EnterpriseCode.Equals(taxrateset.EnterpriseCode))
					return false;

			// �R�[�h��r
			if (taxratesetPara.TaxRateCode > 0)
				if (!taxratesetPara.TaxRateCode.Equals(taxrateset.TaxRateCode))
					return false;

			return true;
		}

        // 2008.07.31 Add >>>
        /// <summary>
        /// �ŗ��ݒ�}�X�^���A�Ώۓ��̐ŗ����擾���܂��B
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ�N���X�I�u�W�F�N�g</param>
        /// <param name="targetDate">�Ώۓ�</param>
        /// <returns>�ŗ�</returns>
        public static double GetTaxRate( TaxRateSet taxRateSet, DateTime targetDate )
        {
            double taxRate = 0;

            //if (taxRateSet == null) return taxRate; // DEL 杍^ 2013/12/16

            // --------- ADD 杍^ 2013/12/16 -------------- >>>>>>>
            if (taxRateSet == null || targetDate == null) return taxRate;

            taxRateSet.TaxRateStartDate = new DateTime(taxRateSet.TaxRateStartDate.Year, taxRateSet.TaxRateStartDate.Month, taxRateSet.TaxRateStartDate.Day);

            taxRateSet.TaxRateEndDate = new DateTime(taxRateSet.TaxRateEndDate.Year, taxRateSet.TaxRateEndDate.Month, taxRateSet.TaxRateEndDate.Day);

            taxRateSet.TaxRateStartDate2 = new DateTime(taxRateSet.TaxRateStartDate2.Year, taxRateSet.TaxRateStartDate2.Month, taxRateSet.TaxRateStartDate2.Day);

            taxRateSet.TaxRateEndDate2 = new DateTime(taxRateSet.TaxRateEndDate2.Year, taxRateSet.TaxRateEndDate2.Month, taxRateSet.TaxRateEndDate2.Day);

            taxRateSet.TaxRateStartDate3 = new DateTime(taxRateSet.TaxRateStartDate3.Year, taxRateSet.TaxRateStartDate3.Month, taxRateSet.TaxRateStartDate3.Day);

            taxRateSet.TaxRateEndDate3 = new DateTime(taxRateSet.TaxRateEndDate3.Year, taxRateSet.TaxRateEndDate3.Month, taxRateSet.TaxRateEndDate3.Day);

            targetDate = new DateTime(targetDate.Year, targetDate.Month, targetDate.Day);
            // --------- ADD 杍^ 2013/12/16 -------------- <<<<<<<

            //
            if (( targetDate >= taxRateSet.TaxRateStartDate ) && ( targetDate <= taxRateSet.TaxRateEndDate ))
            {
                taxRate = taxRateSet.TaxRate;                
            }
            else if (( targetDate >= taxRateSet.TaxRateStartDate2 ) && ( targetDate <= taxRateSet.TaxRateEndDate2 ))
            {
                taxRate = taxRateSet.TaxRate2;
            }
            else if ((targetDate >= taxRateSet.TaxRateStartDate3) && (targetDate <= taxRateSet.TaxRateEndDate3))
            {
                taxRate = taxRateSet.TaxRate3;
            }

            return taxRate;
        }
        // 2008.07.31 Add <<<

    }
}
