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
// 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Аݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Аݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : �������</br>
	/// <br>Date       : 2004.04.11</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.21 22025 �c�� �L</br>
	/// <br>					�E�ۑ����ɃX�y�[�X�J�b�g(TrimEnd)�Ή�</br>
    /// <br>Update Note: 2007.04.10 20031 �É�@���S��</br>
    /// <br>					�E�g��.NS�J���̂��ߍ��ځw���їp���񌎁x��ǉ�</br>
    /// <br>Update Note: 2007.04.13 20031 �É�@���S��</br>
    /// <br>					�E���ږ��y�сA����ID�ύX</br>
    /// <br>Update Note: 2007.05.16 20031 �É�@���S��</br>
    /// <br>					�E���ڒǉ�</br>
    /// <br>Update Note:   2007.09.26 980035 ����@��`</br>
    /// <br>		            �E���ڒǉ��iDC.NS�Ή��j</br>
    /// <br>Update Note:   2008.01.11 980035 ����@��`</br>
    /// <br>		            �E���ڒǉ��i�����Ǘ��敪�j</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    /// <br>UpdateNote  : 2008/09/05 30414�@�E �K�j</br>
    /// <br>           : �t�@�C�����C�A�E�g�ύX�Ή�</br>
    /// <br>UpdateNote  : 2008.12.01 21024�@���X�� ��</br>
    /// <br>           : �����[�g�ύX�Ή�</br>
    /// <br>UpdateNote : �A�� 42 zhouyu </br>
    /// <br>             2011/07/12 �����X�V�ŁA�Â��f�[�^���폜s�̑Ή�</br>
    /// <br>UpdateNote : 2011/07/14 LDNS wangqx</br>
    /// <br>           : ���Аݒ�e�[�u���Ƀf�[�^�N���A���Ԃ��Z�b�g</br>
    /// </remarks>
	public class CompanyInfAcs
	{

		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private ICompanyInfDB _iCompanyInfDB = null;

//		private string fileName;//kokot

        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
        private CompanyInfLcDB _companyInfLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end

        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end

		/// <summary>
		/// ���Аݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Аݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		public CompanyInfAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iCompanyInfDB = (ICompanyInfDB)MediationCompanyInfDB.GetCompanyInfDB();
				// XML�t�@�C������ݒ�
//				this.fileName = "CompanyInf.xml";
			}
			catch (Exception ex)
			{
				if(ex.Message=="")
					this._iCompanyInfDB = null;
				
				//�I�t���C������null���Z�b�g
 				this._iCompanyInfDB = null;
			}
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._companyInfLcDB = new CompanyInfLcDB();
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end
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
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int GetOnlineMode()
		{
 			if (this._iCompanyInfDB == null)
 			{
				return (int)OnlineMode.Offline;
 			}
 			else
 			{
				return (int)OnlineMode.Online;
 			}
		}

		/// <summary>
		/// ���Аݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="companyInf">���Аݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>���Аݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ��ǂݍ��݂܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		public int Read(out CompanyInf companyInf, string enterpriseCode)
		{			
			try
			{
				companyInf = null;
				CompanyInfWork companyInfWork	= new CompanyInfWork();
				companyInfWork.EnterpriseCode	= enterpriseCode;
				companyInfWork.CompanyCode		= 0;	//����肠�����O�Œ�ǂ�

                // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� Begin
                //// XML�֕ϊ����A������̃o�C�i����
				//byte[] parabyte = XmlByteSerializer.Serialize(companyInfWork);
                //
				////�����Ӑݒ�ǂݍ���
				//int status = this._iCompanyInfDB.Read(ref parabyte,0);
                //
				//if (status == 0)
				//{
				//	// XML�̓ǂݍ���
				//	companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));
				//	// �N���X�������o�R�s�[
				//	companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
				//}
                int status;
                if (_isLocalDBRead)
                {
                    status = this._companyInfLcDB.Read(ref companyInfWork, 0);
                    if (status == 0)
                    {
                        // �N���X�������o�R�s�[
                        companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
                    }
                }
                else
                {
                    // 2008.12.01 Update >>>
                    //// XML�֕ϊ����A������̃o�C�i����
                    //byte[] parabyte = XmlByteSerializer.Serialize(companyInfWork);
                    ////�����Ӑݒ�ǂݍ���
                    //status = this._iCompanyInfDB.Read(ref parabyte, 0);

                    //if (status == 0)
                    //{
                    //    // XML�̓ǂݍ���
                    //    companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte, typeof(CompanyInfWork));
                    //    // �N���X�������o�R�s�[
                    //    companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
                    //}

                    object paraObj = companyInfWork;
                    status = this._iCompanyInfDB.Read(ref paraObj, 0);
                    if (status == 0)
                    {
                        companyInfWork = (CompanyInfWork)paraObj;
                        companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
                    }
                    // 2008.12.01 Update <<<
                }
                // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ� end
				
				return status;
			}
			catch (Exception)
			{
				//�ʐM�G���[��-1��߂�
				companyInf = null;
				//�I�t���C������null���Z�b�g
				this._iCompanyInfDB = null;
				return -1;
			}
		}
#if xml			
			try
			{
				companyInf = null;
				//���Аݒ�ǂݍ���
				int status = 0;

				if (System.IO.File.Exists(fileName))
				{
					// XML�̓ǂݍ��݁i���Аݒ�List�N���X�f�V���A���C�Y�����j
					//					ArrayList CompanyInfList = this.CompanyInfListDeserialize(this.fileName);
					CompanyInf company = this.CompanyInfDeserialize(this.fileName);
					companyInf = company;
					// �Ώۃf�[�^�`�F�b�N�p�p�����[�^
					//					CompanyInf clCompanyInfPara = new CompanyInf();
					//					clCompanyInfPara.EnterpriseCode = enterpriseCode;
					//					foreach (CompanyInf clCompanyInf in CompanyInfList)
					//					{
					//						if (!checkTarGetData(clCompanyInf,clCompanyInfPara))
					//						{
					//							CompanyInf = clCompanyInf.Clone();
					//							break;
					//						}
					//						else
					//						{
					//							CompanyInf = clCompanyInf;
					//							break;
					//						}
					//					}
				}
				else
				{
					status = 9;
				}

				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				companyInf = null;
				//�I�t���C������null���Z�b�g
//koko 				this._iCompanyInfDB = null;
				return -1;
			}
#endif
#if xml
		/// <summary>
		/// ���Аݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���Аݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public CompanyInf CompanyInfDeserialize(string fileName)
		{
			CompanyInf companyInf = null;
			try
			{
				// �t�@�C������n���ăv�����^�Ǘ����[�N�N���X���f�V���A���C�Y����
				companyInf = (CompanyInf)XmlByteSerializer.Deserialize(fileName,typeof(CompanyInf));

/*
				// �t�@�C������n���Ď��Аݒ胏�[�N�N���X���f�V���A���C�Y����
				CompanyInfWork CompanyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(fileName,typeof(CompanyInfWork));
				//�f�V���A���C�Y���ʂ����Аݒ�N���X�փR�s�[
				if (CompanyInfWork != null) CompanyInf = CopyToCompanyInfFromCompanyInfWork(CompanyInfWork);
*/
				return companyInf;
			}
			catch(Exception ex)
			{
				string msg =ex.Message.ToString();
				if(msg=="")
					return companyInf;
				return companyInf;

			}

			}
#endif

		/// <summary>
		/// ���Аݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="companyInf">���Аݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Write(ref CompanyInf companyInf)
		{
			//�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
			CompanyInfWork companyInfWork = CopyToCompanyInfWorkFromCompanyInf(companyInf);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(companyInfWork);

			int status = 0;
			try
			{
				//��������
				status = this._iCompanyInfDB.Write(ref parabyte);
				if (status == 0)
				{
					// �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
					companyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(parabyte,typeof(CompanyInfWork));
					// �N���X�������o�R�s�[
					companyInf = CopyToCompanyInfFromCompanyInfWork(companyInfWork);
				}

			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iCompanyInfDB = null;
				//�ʐM�G���[��-1��߂�
				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ���Аݒ�V���A���C�Y����
		/// </summary>
		/// <param name="CompanyInf">�V���A���C�Y�Ώێ��Аݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void CompanyInfSerialize(CompanyInf CompanyInf,string fileName)
		{
			//�v�����^�Ǘ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(CompanyInf,fileName);
		}

		/// <summary>
		/// ���Аݒ�List�V���A���C�Y����
		/// </summary>
		/// <param name="CompanyInfList">�V���A���C�Y�Ώێ��Аݒ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���Аݒ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void CompanyInfListSerialize(ArrayList CompanyInfList,string fileName)
		{
			// ArrayList����z��𐶐�
			CompanyInf[] CompanyInfs = (CompanyInf[])CompanyInfList.ToArray(typeof(CompanyInf));
			// �v�����^�Ǘ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(CompanyInfs,fileName);

		}
#if false   //���Ѓ}�X�����͂P���R�[�h�ׁ̈A�폜�E�T�[�`�͕s�v
		/// <summary>
		/// ���Аݒ�_���폜����
		/// </summary>
		/// <param name="CompanyInf">���Аݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̘_���폜���s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int LogicalDeleteCompanyInf(ref CompanyInf CompanyInf)
		{
			try
			{
				int status = 0;

				CompanyInf[] CompanyInfs;
				ArrayList CompanyInfList = new ArrayList();
				CompanyInfList.Clear();

				// XML�̓ǂݍ���
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				for (int ix=0; ix<CompanyInfs.Length; ix++)
				{
					// �폜�Ώۃf�[�^�Ȃ�_���폜�敪�𗧂ĂăR���N�V�����ɒǉ�
					if (CompanyInfs[ix].Equals(CompanyInf))
					{
						CompanyInf.LogicalDeleteCode = 1;
						CompanyInfList.Add(CompanyInf);
					} 
					else
					{
						CompanyInfList.Add(CompanyInfs[ix]);
					}
				}
				// XML�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
				this.CompanyInfListSerialize(CompanyInfList, this.fileName);

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
//koko			this._iCompanyInfDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}


		/// <summary>
		/// ���Аݒ蕨���폜����
		/// </summary>
		/// <param name="CompanyInf">���Аݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̕����폜���s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int DeleteCompanyInf(CompanyInf CompanyInf)
		{
			try
			{
				int status = 0;

				CompanyInf[] CompanyInfs;
				ArrayList CompanyInfList = new ArrayList();
				CompanyInfList.Clear();

				// XML�̓ǂݍ���
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				for (int ix=0; ix<CompanyInfs.Length; ix++)
				{
					// �폜�Ώۃf�[�^�łȂ�������R���N�V�����ɒǉ�
					if (!CompanyInfs[ix].Equals(CompanyInf))
						CompanyInfList.Add(CompanyInfs[ix]);
				}
				this.CompanyInfListSerialize(CompanyInfList, this.fileName);

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
//koko				this._iCompanyInfDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}


		/// <summary>
		/// ���Аݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ茟���������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchCntCompanyInf(out int retTotalCnt,string enterpriseCode)
		{
			return SearchCntCompanyInfProc(out retTotalCnt,enterpriseCode,0);
		}

		/// <summary>
		/// ���Аݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ茟���������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAllCntCompanyInf(out int retTotalCnt,string enterpriseCode)
		{
			return SearchCntCompanyInfProc(out retTotalCnt,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// ���Аݒ萔��������
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ萔�̌������s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private int SearchCntCompanyInfProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			retTotalCnt = 0;

			// XML�̓ǂݍ���
//			ArrayList CompanyInfList = this.CompanyInfListDeserialize(this.fileName);
//			CompanyInf company = this.CompanyInfDeserialize(this.fileName);
						
			// �Ώۃf�[�^�`�F�b�N�p�p�����[�^
//			CompanyInf CompanyInfPara = new CompanyInf();
//			CompanyInfPara.EnterpriseCode = enterpriseCode;
//			foreach (CompanyInf CompanyInf in CompanyInfList)
//			{
//				if (checkTarGetData(CompanyInf,CompanyInfPara))
//					retTotalCnt++;
//			}

			retTotalCnt=1;
			int status = 0;
				
			return status;
		}

		/// <summary>
		/// ���Аݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchCompanyInf(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;
			return SearchCompanyInfProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,0,null);			
		}

		/// <summary>
		/// ���Аݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchAllCompanyInf(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchCompanyInfProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,0,null);
		}

		/// <summary>
		/// �����w�莩�Аݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevCompanyInf">�O��ŏI���Аݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�Ď��Аݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchSpecificationCompanyInf(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,CompanyInf prevCompanyInf)
		{			
			return SearchCompanyInfProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevCompanyInf);			
		}

		/// <summary>
		/// �����w�莩�Аݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevCompanyInf��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevCompanyInf">�O��ŏI���Аݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�Ď��Аݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchSpecificationAllCompanyInf(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,CompanyInf prevCompanyInf)
		{			
			return SearchCompanyInfProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData0,readCnt,prevCompanyInf);

			
		}

		/// <summary>
		/// ���Аݒ�_���폜��������
		/// </summary>
		/// <param name="CompanyInf">���Аݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̕������s���܂��B</br>
		/// <br>Programmer : ��{���v</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int RevivalCompanyInf(ref CompanyInf CompanyInf)
		{
			try
			{
				int status = 0;

				CompanyInf[] CompanyInfs;
				ArrayList CompanyInfList = new ArrayList();
				CompanyInfList.Clear();

				// XML�̓ǂݍ���
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				for (int ix=0; ix<CompanyInfs.Length; ix++)
				{
					// �폜�Ώۃf�[�^�Ȃ�_���폜�敪�𐳏�ɖ߂��ăR���N�V�����ɒǉ�
					if (CompanyInfs[ix].Equals(CompanyInf))
					{
						CompanyInf.LogicalDeleteCode = 0;
						CompanyInfList.Add(CompanyInf);
					} 
					else
					{
						CompanyInfList.Add(CompanyInfs[ix]);
					}
				}
				// XML�̏������݁i�v�����^�Ǘ�List�V���A���C�Y�����j
				this.CompanyInfListSerialize(CompanyInfList, this.fileName);

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
//koko				this._iCompanyInfDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}


		/// <summary>
		/// ���Аݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
		/// <param name="prevCompanyInf">�O��ŏI���Аݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̌����������s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private int SearchCompanyInfProc(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,ConstantManagement.LogicalMode logicalMode,int readCnt,CompanyInf prevCompanyInf)
		{
			// ���f�[�^�L��������
			nextData = false;
			// �Ǎ��Ώۃf�[�^������0�ŏ�����
			retTotalCnt = 0;

			CompanyInf[] CompanyInfs;
			retList = new ArrayList();
			retList.Clear();

			// �Ώۃf�[�^�`�F�b�N�p�p�����[�^
			CompanyInf CompanyInfPara = new CompanyInf();
			CompanyInfPara.EnterpriseCode = enterpriseCode;

			try
			{
				// XML�̓ǂݍ���
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				// �S�����[�h�H
				if (readCnt == 0) 
				{
					for (int ix=0; ix<CompanyInfs.Length; ix++)
					{
						// �Ǎ����ʃR���N�V�����ɒǉ�
						if (checkTarGetData(CompanyInfs[ix],CompanyInfPara))
							retList.Add(CompanyInfs[ix]);
					}
					// �Ǎ��Ώۃf�[�^��������ArrayList�̌���
					retTotalCnt = retList.Count;
				}
				else
				{	// �Ǎ������w�胊�[�h
					
					// �Ǎ��Ώۃf�[�^���������z��v�f��
					retTotalCnt = CompanyInfs.Length;
					// �O��f�[�^���Ȃ��H
					if (prevCompanyInf == null)	 
					{
						for (int ix=0; ix<CompanyInfs.Length; ix++)
						{
							// �Ǎ������ɒB�����甲����
							if (retList.Count >= readCnt)
							{
								nextData = true;	// ����v��񂩂�
								break;
							}
							// �Ǎ����ʃR���N�V�����ɒǉ�
							if (checkTarGetData(CompanyInfs[ix],CompanyInfPara))
								retList.Add(CompanyInfs[ix]);
						}
					}
					else
					{	// �O��f�[�^���Ȃ�

						// �O��f�[�^�̃C���f�b�N�X��������
						int dataIndex = -1;
						
						for (int ix=0; ix<CompanyInfs.Length; ix++)
						{
							// �Ǎ������ɒB�����甲����
							if (retList.Count >= readCnt)
							{
								nextData = true;	// ����v��񂩂�
								break;
							}
							// �O��f�[�^������������C���f�b�N�X��ޔ����Ă���
							if (CompanyInfs[ix].Equals(prevCompanyInf) == true)
								dataIndex = ix;
							// �O��f�[�^�̎��̃f�[�^�ȍ~��Ǎ����ʃR���N�V�����ɒǉ�
							if ((dataIndex >= 0) && (ix > dataIndex))
								if (checkTarGetData(CompanyInfs[ix],CompanyInfPara))
									retList.Add(CompanyInfs[ix]);
						}
					}
				}

				int status = 0;
				// �Ǎ����ʂȂ��̏ꍇ��EOF��Ԃ�
				if (retList.Count <= 0)
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;

				return status;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{
				return -1;
			}
		}

		/// <summary>
		/// ���Аݒ茟�������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchCompanyInfDS(ref DataSet ds,string enterpriseCode)
		{
			CompanyInf[] CompanyInfs;
			ArrayList CompanyInfList = new ArrayList();
			CompanyInfList.Clear();

			// �Ώۃf�[�^�`�F�b�N�p�p�����[�^
			CompanyInf CompanyInfPara = new CompanyInf();
			CompanyInfPara.EnterpriseCode = enterpriseCode;

			try
			{
				// XML�̓ǂݍ���
				CompanyInfs = (CompanyInf[])XmlByteSerializer.Deserialize(this.fileName, typeof(CompanyInf[]));
				
				// �Ώۃf�[�^���R���N�V�����ɒǉ�
				for (int ix=0; ix<CompanyInfs.Length; ix++)
				{
					if (checkTarGetData(CompanyInfs[ix],CompanyInfPara))
						CompanyInfList.Add(CompanyInfs[ix]);
				}
				// ArrayList����z��𐶐�
				CompanyInfs = (CompanyInf[])CompanyInfList.ToArray(typeof(CompanyInf));
				// �N���X��XML�o�C�g��֕ϊ�
				byte[] buffer = XmlByteSerializer.Serialize(CompanyInfs);
				// DataSet XML�ǂݍ���
				XmlByteSerializer.ReadXml(ref ds, buffer);

				return 0;
			}
			catch (System.IO.FileNotFoundException)
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			catch (Exception)
			{
				return -1;
			}
		}
#endif

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���Аݒ胏�[�N�N���X�ˎ��Аݒ�N���X�j
		/// </summary>
		/// <param name="CompanyInfWork">���Аݒ胏�[�N�N���X</param>
		/// <returns>���Аݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ胏�[�N�N���X���玩�Аݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.04.14</br>
		/// </remarks>
		private CompanyInf CopyToCompanyInfFromCompanyInfWork(CompanyInfWork CompanyInfWork)
		{
			CompanyInf CompanyInf = new CompanyInf();

			//�t�@�C���w�b�_����
			CompanyInf.CreateDateTime			= CompanyInfWork.CreateDateTime;
			CompanyInf.UpdateDateTime			= CompanyInfWork.UpdateDateTime;
			CompanyInf.EnterpriseCode			= CompanyInfWork.EnterpriseCode;
			CompanyInf.FileHeaderGuid			= CompanyInfWork.FileHeaderGuid;
			CompanyInf.UpdEmployeeCode		    = CompanyInfWork.UpdEmployeeCode;
			CompanyInf.UpdAssemblyId1			= CompanyInfWork.UpdAssemblyId1;
			CompanyInf.UpdAssemblyId2			= CompanyInfWork.UpdAssemblyId2;
			CompanyInf.LogicalDeleteCode		= CompanyInfWork.LogicalDeleteCode;

			CompanyInf.CompanyCode				= CompanyInfWork.CompanyCode;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			CompanyInf.CompanyPr				= CompanyInfWork.CompanyPr;
//			CompanyInf.CompanyName1				= CompanyInfWork.CompanyName1;
//			CompanyInf.CompanyName2				= CompanyInfWork.CompanyName2;
//			CompanyInf.PostNo					= CompanyInfWork.PostNo;
//			CompanyInf.Address1					= CompanyInfWork.Address1;
//			CompanyInf.Address2					= CompanyInfWork.Address2;
//			CompanyInf.Address3					= CompanyInfWork.Address3;
//			CompanyInf.Address4					= CompanyInfWork.Address4;
//			CompanyInf.CompanyTelNo1			= CompanyInfWork.CompanyTelNo1;
//			CompanyInf.CompanyTelNo2			= CompanyInfWork.CompanyTelNo2;
//			CompanyInf.CompanyTelNo3			= CompanyInfWork.CompanyTelNo3;
//			CompanyInf.CompanyTelTitle1			= CompanyInfWork.CompanyTelTitle1;
//			CompanyInf.CompanyTelTitle2			= CompanyInfWork.CompanyTelTitle2;
//			CompanyInf.CompanyTelTitle3			= CompanyInfWork.CompanyTelTitle3;
//			CompanyInf.TransferGuidance			= CompanyInfWork.TransferGuidance;
//			CompanyInf.AccountNoInfo1			= CompanyInfWork.AccountNoInfo1;
//			CompanyInf.AccountNoInfo2			= CompanyInfWork.AccountNoInfo2;
//			CompanyInf.AccountNoInfo3			= CompanyInfWork.AccountNoInfo3;
//			CompanyInf.CompanySetNote1			= CompanyInfWork.CompanySetNote1;
//			CompanyInf.CompanySetNote2			= CompanyInfWork.CompanySetNote2;
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			CompanyInf.CompanyTotalDay			= CompanyInfWork.CompanyTotalDay;
            CompanyInf.CompanyBiginMonth        = CompanyInfWork.CompanyBiginMonth;
            
            // 2007.04.13  S.Koga  amend --------------------------------------
            // 2007.04.10  S.Koga  add ----------------------------------------
            //CompanyInf.CompRestBiginMonth     = CompanyInfWork.CompRestBiginMonth;
            // ----------------------------------------------------------------
            CompanyInf.CompanyBiginMonth2       = CompanyInfWork.CompanyBiginMonth2;
            // ----------------------------------------------------------------

            // 2007.09.26 �C�� >>>>>>>>>>>>>>>>>>>>
            CompanyInf.FinancialYear            = CompanyInfWork.FinancialYear;
            CompanyInf.CompanyBiginDate         = CompanyInfWork.CompanyBiginDate;
            CompanyInf.StartYearDiv             = CompanyInfWork.StartYearDiv;
            CompanyInf.StartMonthDiv            = CompanyInfWork.StartMonthDiv;
            // 2007.09.26 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2008.01.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            CompanyInf.SecMngDiv                = CompanyInfWork.SecMngDiv;
            // 2008.01.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2007.05.16  S.Koga  add ----------------------------------------
            CompanyInf.CompanyName1 = CompanyInfWork.CompanyName1;
            CompanyInf.CompanyName2 = CompanyInfWork.CompanyName2;
            // ----------------------------------------------------------------

            // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
            CompanyInf.PostNo = CompanyInfWork.PostNo;
            CompanyInf.Address1 = CompanyInfWork.Address1;
            CompanyInf.Address3 = CompanyInfWork.Address3;
            CompanyInf.Address4 = CompanyInfWork.Address4;
            CompanyInf.CompanyTelTitle1 = CompanyInfWork.CompanyTelTitle1;
            CompanyInf.CompanyTelTitle2 = CompanyInfWork.CompanyTelTitle2;
            CompanyInf.CompanyTelTitle3 = CompanyInfWork.CompanyTelTitle3;
            CompanyInf.CompanyTelNo1 = CompanyInfWork.CompanyTelNo1;
            CompanyInf.CompanyTelNo2 = CompanyInfWork.CompanyTelNo2;
            CompanyInf.CompanyTelNo3 = CompanyInfWork.CompanyTelNo3;
            // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
            //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
            CompanyInf.DataSaveMonths = CompanyInfWork.DataSaveMonths;
            CompanyInf.DataCompressDt = CompanyInfWork.DataCompressDt;
            CompanyInf.ResultDtSaveMonths = CompanyInfWork.ResultDtSaveMonths;
            CompanyInf.ResultDtCompressDt = CompanyInfWork.ResultDtCompressDt;
            CompanyInf.CaPrtsDtSaveMonths = CompanyInfWork.CaPrtsDtSaveMonths;
            CompanyInf.CaPrtsDtCompressDt = CompanyInfWork.CaPrtsDtCompressDt;
            CompanyInf.MasterSaveMonths = CompanyInfWork.MasterSaveMonths;
            CompanyInf.MasterCompressDt = CompanyInfWork.MasterCompressDt;
            CompanyInf.RatePriorityDiv = CompanyInfWork.RatePriorityDiv;
            //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
            // -- ADD 2011/07/14 ------------------------------------------->>>
            CompanyInf.DataClrExecDate = CompanyInfWork.DataClrExecDate;
            CompanyInf.DataClrExecTime = CompanyInfWork.DataClrExecTime;
            // -- ADD 2011/07/14 -------------------------------------------<<<
			// ���Ж��̓ǂݍ���
			return CompanyInf;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���Аݒ�N���X�ˎ��Аݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="CompanyInf">���Аݒ胏�[�N�N���X</param>
		/// <returns>���Аݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Аݒ�N���X���玩�Аݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private CompanyInfWork CopyToCompanyInfWorkFromCompanyInf(CompanyInf CompanyInf)
		{
			CompanyInfWork CompanyInfWork = new CompanyInfWork();

			CompanyInfWork.CreateDateTime			= CompanyInf.CreateDateTime;
			CompanyInfWork.UpdateDateTime			= CompanyInf.UpdateDateTime;
			CompanyInfWork.EnterpriseCode			= CompanyInf.EnterpriseCode.Trim();
			CompanyInfWork.FileHeaderGuid			= CompanyInf.FileHeaderGuid;
			CompanyInfWork.UpdEmployeeCode		    = CompanyInf.UpdEmployeeCode;
			CompanyInfWork.UpdAssemblyId1			= CompanyInf.UpdAssemblyId1;
			CompanyInfWork.UpdAssemblyId2			= CompanyInf.UpdAssemblyId2;
			CompanyInfWork.LogicalDeleteCode		= CompanyInf.LogicalDeleteCode;

			CompanyInfWork.CompanyCode				= CompanyInf.CompanyCode;

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
//			CompanyInfWork.CompanyPr				= CompanyInf.CompanyPr.TrimEnd();
//			CompanyInfWork.CompanyName1				= CompanyInf.CompanyName1.TrimEnd();
//			CompanyInfWork.CompanyName2				= CompanyInf.CompanyName2.TrimEnd();
//			CompanyInfWork.PostNo					= CompanyInf.PostNo;
//			CompanyInfWork.Address1					= CompanyInf.Address1.TrimEnd();
//			CompanyInfWork.Address2					= CompanyInf.Address2;
//			CompanyInfWork.Address3					= CompanyInf.Address3.TrimEnd();
//			CompanyInfWork.Address4					= CompanyInf.Address4.TrimEnd();
//			CompanyInfWork.CompanyTelNo1			= CompanyInf.CompanyTelNo1.Trim();
//			CompanyInfWork.CompanyTelNo2			= CompanyInf.CompanyTelNo2.Trim();
//			CompanyInfWork.CompanyTelNo3			= CompanyInf.CompanyTelNo3.Trim();
//			CompanyInfWork.CompanyTelTitle1			= CompanyInf.CompanyTelTitle1.TrimEnd();
//			CompanyInfWork.CompanyTelTitle2			= CompanyInf.CompanyTelTitle2.TrimEnd();
//			CompanyInfWork.CompanyTelTitle3			= CompanyInf.CompanyTelTitle3.TrimEnd();
//			CompanyInfWork.TransferGuidance			= CompanyInf.TransferGuidance.TrimEnd();
//			CompanyInfWork.AccountNoInfo1			= CompanyInf.AccountNoInfo1.TrimEnd();
//			CompanyInfWork.AccountNoInfo2			= CompanyInf.AccountNoInfo2.TrimEnd();
//			CompanyInfWork.AccountNoInfo3			= CompanyInf.AccountNoInfo3.TrimEnd();
//			CompanyInfWork.CompanySetNote1			= CompanyInf.CompanySetNote1.TrimEnd();
//			CompanyInfWork.CompanySetNote2			= CompanyInf.CompanySetNote2.TrimEnd();
// 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

			CompanyInfWork.CompanyTotalDay			= CompanyInf.CompanyTotalDay;
            CompanyInfWork.CompanyBiginMonth        = CompanyInf.CompanyBiginMonth;
            
            // 2007.04.13  S.Koga  amend --------------------------------------
            // 2007.04.10  S.Koga  add ----------------------------------------
            //CompanyInfWork.CompRestBiginMonth     = CompanyInf.CompRestBiginMonth;
            // ----------------------------------------------------------------
            CompanyInfWork.CompanyBiginMonth2       = CompanyInf.CompanyBiginMonth2;
            // ----------------------------------------------------------------

            // 2007.09.26 �C�� >>>>>>>>>>>>>>>>>>>>
            CompanyInfWork.FinancialYear            = CompanyInf.FinancialYear;
            CompanyInfWork.CompanyBiginDate         = CompanyInf.CompanyBiginDate;
            CompanyInfWork.StartYearDiv             = CompanyInf.StartYearDiv;
            CompanyInfWork.StartMonthDiv            = CompanyInf.StartMonthDiv;
            // 2007.09.26 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2008.01.11 �ǉ� >>>>>>>>>>>>>>>>>>>>
            CompanyInfWork.SecMngDiv                = CompanyInf.SecMngDiv;
            // 2008.01.11 �ǉ� <<<<<<<<<<<<<<<<<<<<

            // 2007.05.16  S.Koga  add ----------------------------------------
            CompanyInfWork.CompanyName1 = CompanyInf.CompanyName1;
            CompanyInfWork.CompanyName2 = CompanyInf.CompanyName2;
            // ----------------------------------------------------------------

            // --- ADD 2008/09/05 --------------------------------------------------------------------->>>>>
            CompanyInfWork.PostNo = CompanyInf.PostNo;
            CompanyInfWork.Address1 = CompanyInf.Address1;
            CompanyInfWork.Address3 = CompanyInf.Address3;
            CompanyInfWork.Address4 = CompanyInf.Address4;
            CompanyInfWork.CompanyTelTitle1 = CompanyInf.CompanyTelTitle1;
            CompanyInfWork.CompanyTelTitle2 = CompanyInf.CompanyTelTitle2;
            CompanyInfWork.CompanyTelTitle3 = CompanyInf.CompanyTelTitle3;
            CompanyInfWork.CompanyTelNo1 = CompanyInf.CompanyTelNo1;
            CompanyInfWork.CompanyTelNo2 = CompanyInf.CompanyTelNo2;
            CompanyInfWork.CompanyTelNo3 = CompanyInf.CompanyTelNo3;
            // --- ADD 2008/09/05 ---------------------------------------------------------------------<<<<<
            //ADD START 2011/07/12 zhouyu FOR �A�� 42 ------------------->>>>>>
            CompanyInfWork.DataSaveMonths = CompanyInf.DataSaveMonths;
            CompanyInfWork.DataCompressDt = CompanyInf.DataCompressDt;
            CompanyInfWork.ResultDtSaveMonths = CompanyInf.ResultDtSaveMonths;
            CompanyInfWork.ResultDtCompressDt = CompanyInf.ResultDtCompressDt;
            CompanyInfWork.CaPrtsDtSaveMonths = CompanyInf.CaPrtsDtSaveMonths;
            CompanyInfWork.CaPrtsDtCompressDt = CompanyInf.CaPrtsDtCompressDt;
            CompanyInfWork.MasterSaveMonths = CompanyInf.MasterSaveMonths;
            CompanyInfWork.MasterCompressDt = CompanyInf.MasterCompressDt;
            CompanyInfWork.RatePriorityDiv = CompanyInf.RatePriorityDiv;
            //ADD END 2011/07/12 zhouyu FOR �A�� 42 ---------------------<<<<<<
            // -- ADD 2011/07/14 ------------------------------------------->>>
            CompanyInfWork.DataClrExecDate = CompanyInf.DataClrExecDate;
            CompanyInfWork.DataClrExecTime = CompanyInf.DataClrExecTime;
            // -- ADD 2011/07/14 -------------------------------------------<<<

            return CompanyInfWork;
		}
#if false
		/// <summary>
		/// �Ώۃf�[�^�`�F�b�N
		/// </summary>
		/// <param name="CompanyInf">�Ώۃf�[�^</param>
		/// <param name="CompanyInfPara">�p�����[�^</param>
		/// <returns>�`�F�b�N���ʁitrue:OK false:NG�j</returns>
		/// <remarks>
		/// <br>Note       : �Ώۃf�[�^�ƃp�����[�^���r���܂��B</br>
		/// <br>Programmer : �������</br>
		/// <br>Date       : 2005.03.24</br>
		/// </remarks>
		private bool checkTarGetData(
			CompanyInf CompanyInf,
			CompanyInf CompanyInfPara)
		{
			// ��ƃR�[�h���r
			if (CompanyInfPara.EnterpriseCode != null)
			{
				if (!CompanyInfPara.EnterpriseCode.Equals(CompanyInf.EnterpriseCode))
					return false;
			}
			return true;
		}
#endif

        // -- ADD 2011/07/14 ------------------------------------------->>>
        /// <summary>
        /// ���Џ��}�X�^�Ƀf�[�^�N���A���ԍX�V����
        /// </summary>
        /// <param name="companyInf">���Џ��</param>
        /// <param name="DelYMD">�f�[�^�N���A�N����</param>
        /// <param name="DelHMSXXX">�f�[�^�N���A�����b�~���b</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�N���A���ԍX�V���s���܂��B</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        /// </remarks>
        public int WriteClearTime(CompanyInf companyInf, String DelYMD, String DelHMSXXX, out string errMsg)
        {
            int status = 0;

            //�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
            CompanyInfWork companyInfWork = CopyToCompanyInfWorkFromCompanyInf(companyInf);
            errMsg = string.Empty;
            object paraObj = companyInfWork;

            try
            {
                //��������
                status = this._iCompanyInfDB.WriteClearTime(paraObj, DelYMD, DelHMSXXX, out errMsg);
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iCompanyInfDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̃f�[�^�N���A���Ԃ�߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="DelYMD">�f�[�^�N���A�N����</param>
        /// <param name="DelHMSXXX">�f�[�^�N���A�����b�~���b</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̃f�[�^�N���A���Ԃ�߂��܂�</br>
        /// <br>Programmer : LDNS wangqx</br>
        /// <br>Date       : 2011.07.14</br>
        public int ReadClearTime(string enterpriseCode, out Int32 DelYMD, out Int32 DelHMSXXX)
        {
            DelYMD = 0;
            DelHMSXXX = 0;
            try
			{   
                int status;
                status = this._iCompanyInfDB.ReadClearTime(enterpriseCode, out DelYMD, out DelHMSXXX);
				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iCompanyInfDB = null;
				return -1;
			}
        }
        // -- ADD 2011/07/14 -------------------------------------------<<<
	}
}
