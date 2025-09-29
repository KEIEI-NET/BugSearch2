using System;
using System.Collections;
using System.Data;
using System.Reflection;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
using System.Collections.Generic;
using System.Text;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
using Broadleaf.Application.LocalAccess;
// 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���Ж��̃e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���Ж��̃e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 23001 �H�R�@����</br>
	/// <br>Date       : 2005.09.09</br>
    /// -----------------------------------------------------------------------
    /// <br>Date       : 2007.05.17</br>
    /// <br>Programmer : 20031 �É�@���S��</br>
    /// <br>UpdateNote : ���ڒǉ�</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008.02.12 96012�@���F �]</br>
    /// <br>           : ���[�J���c�a�Q�ƑΉ�(���_���)</br>
    /// -----------------------------------------------------------------------
    /// <br>UpdateNote : 2008/06/04 30414�@�E�@�K�j</br>
    /// <br>           : �Z��2�폜</br>
    /// </remarks>
	public class CompanyNmAcs
	{
		// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		private ICompanyNmDB	_iCompanyNmDB = null;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        private CompanyNmLcDB _companyNmLcDB = null;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

		// ���_���擾���i
		private SecInfoAcs      _secInfoAcs   = null;

        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

        /// <summary>
		/// ���Ж��̃e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ж��̃e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		public CompanyNmAcs()
		{
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
            //this._secInfoAcs = new SecInfoAcs(1);
            // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end
            try
            {
				// �����[�g�I�u�W�F�N�g�擾
				this._iCompanyNmDB = ( ICompanyNmDB )MediationCompanyNmDB.GetCompanyNmDB();
			}
			catch(Exception) {
				// �I�t���C������null���Z�b�g
				this._iCompanyNmDB = null;
			}
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._companyNmLcDB = new CompanyNmLcDB();
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
        }

        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
        /// <summary>
        /// ���[�J���c�a�Ή����_���N���X�쐬����
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note       : ���_���N���X�쐬�𖢍쐬���ɍ쐬���܂��B</br>
        /// <br>Programmer : 96012 ���F�@�]</br>
        /// <br>Date       : 2008.02.12</br>
        /// </remarks>
        private Boolean ConstructSecInfoAcs()
        {
            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
                if (this._secInfoAcs != null)
                {
                    return true;
                }
            }
            return false;
        }
        // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end

        /// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			// �I�����C�����[�h���擾���܂�
			if( this._iCompanyNmDB == null ) {
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
		/// ���Ж��̓Ǎ�����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="companyNameCd">���Ж��̃R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̓ǂݍ��݂��s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		public int Read( out CompanyNm companyNm, string enterpriseCode, int companyNameCd )
		{
			int status = 0;

			try {
				companyNm = null;

				// �p�����[�^��ݒ�
				CompanyNmWork companyNmWork		= new CompanyNmWork();
				companyNmWork.EnterpriseCode	= enterpriseCode;		// ��ƃR�[�h
				companyNmWork.CompanyNameCd		= companyNameCd;		// ���Ж��̃R�[�h

                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� Begin
                //// XML�֕ϊ����A������̃o�C�i����
				//byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );
                //
				//// ���Ж��̓ǂݍ���
				//status = this._iCompanyNmDB.Read( ref parabyte, 0 );
                //
				//if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
				//	// ���Ж��̃��[�N�N���X���f�V���A���C�Y
				//	companyNmWork = ( CompanyNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( CompanyNmWork ) );
				//	// ���Ж��̃��[�N�N���X���玩�Ж��̃N���X�փ����o�R�s�[
				//	companyNm = CopyToCompanyNmFromCompanyNmWork( companyNmWork );
				//}
                if (_isLocalDBRead)
                {
                    // ���Ж��̓ǂݍ���
                    status = this._companyNmLcDB.Read(ref companyNmWork, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���Ж��̃��[�N�N���X���玩�Ж��̃N���X�փ����o�R�s�[
                        companyNm = CopyToCompanyNmFromCompanyNmWork(companyNmWork);
                    }
                }
                else
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(companyNmWork);
                    // ���Ж��̓ǂݍ���
                    status = this._iCompanyNmDB.Read(ref parabyte, 0);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ���Ж��̃��[�N�N���X���f�V���A���C�Y
                        companyNmWork = (CompanyNmWork)XmlByteSerializer.Deserialize(parabyte, typeof(CompanyNmWork));
                        // ���Ж��̃��[�N�N���X���玩�Ж��̃N���X�փ����o�R�s�[
                        companyNm = CopyToCompanyNmFromCompanyNmWork(companyNmWork);
                    }
                }
                // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
                return status;
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				companyNm = null;
				this._iCompanyNmDB = null;

				// �ʐM�G���[��-1��Ԃ��B
				return -1;
			}
		}

		/// <summary>
		/// ���Ж��̓o�^�E�X�V����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Write( ref CompanyNm companyNm )
		{
			int status = 0;

			try {
				// ���Ж��̃N���X�����Ж��̃��[�N�N���X�փ����o�R�s�[
				CompanyNmWork companyNmWork = CopyToCompanyNmWorkFromCompanyNm( companyNm );

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );

                // ���Ж��̂�ۑ�
				status = this._iCompanyNmDB.Write( ref parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// ���Ж��̃��[�N�N���X���f�V���A���C�Y
					companyNmWork = ( CompanyNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( CompanyNmWork ) );
					// ���Ж��̃��[�N�N���X���玩�Ж��̃N���X�փ����o�R�s�[
					companyNm = CopyToCompanyNmFromCompanyNmWork( companyNmWork );

                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end
                    // ���_���擾���i�X�^�e�B�b�N�f�[�^���Z�b�g
					this._secInfoAcs.ResetSectionInfo();
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCompanyNmDB = null;

				// �ʐM�G���[��-1��Ԃ�
				return -1;
			}
		}

		/// <summary>
		/// ���Ж��̘_���폜����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̘̂_���폜���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int LogicalDelete( ref CompanyNm companyNm )
		{
			int status = 0;

			try {
				#region 2006.09.12 R.AKIYAMA DEL
//				// ���_�ݒ���`�F�b�N
//				SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
//				ArrayList secInfoSetList = null;
//				status = secInfoSetAcs.SearchAll( out secInfoSetList, companyNm.EnterpriseCode );
//				// ��ƂŌ����������R�[�h�����݂���Ƃ�
//				if( status == 0 ) {
//					foreach( SecInfoSet secInfoSet in secInfoSetList ) {
//						for( int ix = 0; ix < 10; ix++ ) {
//							if( secInfoSet.GetCompanyNameCd( ix ) == companyNm.CompanyNameCd ) {
//								// �Q�Ƃ���Ă���ꍇ�͈ȉ��̏������L�����Z���i-2��Ԃ��j
//								return -2;
//							}
//						}
//					}
//				}
				#endregion

				// ���Ж��̃N���X�����Ж��̃��[�N�N���X�փ����o�R�s�[
				CompanyNmWork companyNmWork = CopyToCompanyNmWorkFromCompanyNm( companyNm );
				// XML�ϊ����A��������o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );

				// ���Ж��̂�_���폜
				status = this._iCompanyNmDB.LogicalDelete( ref parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// ���Ж��̃��[�N�N���X���f�V���A���C�Y
					companyNmWork = ( CompanyNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( CompanyNmWork ) );
					// ���Ж��̃��[�N�N���X�����Ж��̃N���X�Ƀ����o�R�s�[
					companyNm = CopyToCompanyNmFromCompanyNmWork( companyNmWork );

                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end
                    // ���_���擾���i�X�^�e�B�b�N�f�[�^���Z�b�g
					this._secInfoAcs.ResetSectionInfo();
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCompanyNmDB = null;

				// �ʐM�G���[��-1��Ԃ�
				return -1;
			}
		}

		/// <summary>
		/// ���Ж��̘_���폜��������
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̘̂_���폜�������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Revival( ref CompanyNm companyNm )
		{
			int status = 0;

			try {
				// ���Ж��̃N���X�����Ж��̃��[�N�N���X�փ����o�R�s�[
				CompanyNmWork companyNmWork = CopyToCompanyNmWorkFromCompanyNm( companyNm );
				// XML�ϊ����A��������o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );

				// ���Ж��̂𕜊�
				status = this._iCompanyNmDB.RevivalLogicalDelete( ref parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// ���Ж��̃��[�N�N���X���f�V���A���C�Y
					companyNmWork = ( CompanyNmWork )XmlByteSerializer.Deserialize( parabyte, typeof( CompanyNmWork ) );
					// ���Ж��̃��[�N�N���X�����Ж��̃N���X�Ƀ����o�R�s�[
					companyNm = CopyToCompanyNmFromCompanyNmWork( companyNmWork );

                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end
                    // ���_���擾���i�X�^�e�B�b�N�f�[�^���Z�b�g
					this._secInfoAcs.ResetSectionInfo();
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
				this._iCompanyNmDB = null;

				// �ʐM�G���[��-1��Ԃ�
				return -1;
			}
		}

		/// <summary>
		/// ���Ж��̕����폜����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̕����폜���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Delete( CompanyNm companyNm )
		{
			int status = 0;
			try {
				// ���Ж��̃N���X�����Ж��̃��[�N�N���X�փ����o�R�s�[
				CompanyNmWork companyNmWork = CopyToCompanyNmWorkFromCompanyNm( companyNm );
				// XML�ϊ����A��������o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize( companyNmWork );

				// ���Ж��̕����폜
				status = this._iCompanyNmDB.Delete( parabyte );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) Begin
                    ConstructSecInfoAcs();
                    // 2008.02.12 96012 ���[�J���c�a�Q�ƑΉ�(���_���) end
                    // ���_���擾���i�X�^�e�B�b�N�f�[�^���Z�b�g
					this._secInfoAcs.ResetSectionInfo();
				}
				return status;
			}
			catch( Exception ) {
				// �I�t���C������null��ݒ�
				this._iCompanyNmDB = null;

				// �ʐM�G���[��-1��Ԃ�
				return -1;
			}
		}

		/// <summary>
		/// ���Ж��̌�������(�_���폜�f�[�^����)
		/// </summary>
		/// <param name="retList">�������ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ł��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Search( out ArrayList retList, string enterpriseCode )
		{
			return SearchProc( out retList, enterpriseCode, 0 );
		}

		/// <summary>
		/// ���Ж��̌�������(�_���폜�f�[�^�܂�)
		/// </summary>
		/// <param name="retList">�������ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂɊ܂݂܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int SearchAll( out ArrayList retList, string enterpriseCode )
		{
			return SearchProc( out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01 );
		}

		/// <summary>
		/// ���Ж��̌�������(���C��)
		/// </summary>
		/// <param name="retList">�������ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̌����������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
        /// -----------------------------------------------------------------------
        /// <br>UpdateNote : 2008.02.08 96012�@���F �]</br>
        /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
        /// </remarks>
		private int SearchProc( out ArrayList retList, string enterpriseCode, 
			ConstantManagement.LogicalMode logicalMode )
		{
			int status = 0;
			
			retList = new ArrayList();
			retList.Clear();

			CompanyNmWork companyNmWork		= new CompanyNmWork();
			companyNmWork.EnterpriseCode	= enterpriseCode;		// ��ƃR�[�h

			ArrayList wkList = new ArrayList();
			wkList.Clear();

			object paraobj	= companyNmWork;
			object retobj	= null;

            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end
            //// ���Ж��̑S������
			//status = this._iCompanyNmDB.Search( out retobj, paraobj, 0, logicalMode );
            //
			//if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
			//	wkList = retobj as ArrayList;
			//	if( wkList != null ) {
			//		foreach( CompanyNmWork wkCompanyNmWork in wkList ) {
			//			retList.Add( CopyToCompanyNmFromCompanyNmWork( wkCompanyNmWork ) );
			//		}
			//	}
			//}
            if (_isLocalDBRead)
            {
                List<CompanyNmWork> workList = new List<CompanyNmWork>();
                // ���Ж��̑S������
                status = this._companyNmLcDB.Search(out workList, companyNmWork, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CompanyNmWork wkCompanyNmWork in workList)
                    {
                        retList.Add(CopyToCompanyNmFromCompanyNmWork(wkCompanyNmWork));
                    }
                }
            }
            else
            {
                // ���Ж��̑S������
                status = this._iCompanyNmDB.Search(out retobj, paraobj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    wkList = retobj as ArrayList;
                    if (wkList != null)
                    {
                        foreach (CompanyNmWork wkCompanyNmWork in wkList)
                        {
                            retList.Add(CopyToCompanyNmFromCompanyNmWork(wkCompanyNmWork));
                        }
                    }
                }
            }
            // 2008.02.08 96012 ���[�J���c�a�Q�ƑΉ� end

			return status;
		}

		/// <summary>
		/// �N���X�����o�R�s�[����(���Ж��̃��[�N�N���X�����Ж��̃N���X)
		/// </summary>
		/// <param name="companyNmWork">���Ж��̃��[�N�N���X</param>
		/// <returns>���Ж��̃N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̃��[�N�N���X���玩�Ж��̃N���X�փ����o�R�s�[���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private CompanyNm CopyToCompanyNmFromCompanyNmWork( CompanyNmWork companyNmWork )
		{
			CompanyNm companyNm = new CompanyNm();

			// ���ʃw�b�_
			companyNm.CreateDateTime		= companyNmWork.CreateDateTime;
			companyNm.UpdateDateTime		= companyNmWork.UpdateDateTime;
			companyNm.EnterpriseCode		= companyNmWork.EnterpriseCode;
			companyNm.FileHeaderGuid		= companyNmWork.FileHeaderGuid;
			companyNm.UpdEmployeeCode		= companyNmWork.UpdEmployeeCode;
			companyNm.UpdAssemblyId1		= companyNmWork.UpdAssemblyId1;
			companyNm.UpdAssemblyId2		= companyNmWork.UpdAssemblyId2;
			companyNm.LogicalDeleteCode		= companyNmWork.LogicalDeleteCode;

			companyNm.CompanyNameCd			= companyNmWork.CompanyNameCd;				// ���Ж��̃R�[�h
			companyNm.CompanyPr				= companyNmWork.CompanyPr;					// ����PR��
			companyNm.CompanyName1			= companyNmWork.CompanyName1;				// ���Ж���1
			companyNm.CompanyName2			= companyNmWork.CompanyName2;				// ���Ж���2
			companyNm.PostNo				= companyNmWork.PostNo;						// �X�֔ԍ�
			companyNm.Address1				= companyNmWork.Address1;					// �Z��1�i�s���{���s��S�E�����E���j
            //companyNm.Address2				= companyNmWork.Address2;					// �Z��2�i���ځj  // DEL 2008/06/04
			companyNm.Address3				= companyNmWork.Address3;					// �Z��3�i�Ԓn�j
			companyNm.Address4				= companyNmWork.Address4;					// �Z��4�i�A�p�[�g���́j
			companyNm.CompanyTelNo1			= companyNmWork.CompanyTelNo1;				// ���Гd�b�ԍ�1
			companyNm.CompanyTelNo2			= companyNmWork.CompanyTelNo2;				// ���Гd�b�ԍ�2
			companyNm.CompanyTelNo3			= companyNmWork.CompanyTelNo3;				// ���Гd�b�ԍ�3
			companyNm.CompanyTelTitle1		= companyNmWork.CompanyTelTitle1;			// ���Гd�b�ԍ��^�C�g��1
			companyNm.CompanyTelTitle2		= companyNmWork.CompanyTelTitle2;			// ���Гd�b�ԍ��^�C�g��2
			companyNm.CompanyTelTitle3		= companyNmWork.CompanyTelTitle3;			// ���Гd�b�ԍ��^�C�g��3
			companyNm.TransferGuidance		= companyNmWork.TransferGuidance;			// ��s�U���ē���
			companyNm.AccountNoInfo1		= companyNmWork.AccountNoInfo1;				// ��s����1
			companyNm.AccountNoInfo2		= companyNmWork.AccountNoInfo2;				// ��s����2
			companyNm.AccountNoInfo3		= companyNmWork.AccountNoInfo3;				// ��s����3
			companyNm.CompanySetNote1		= companyNmWork.CompanySetNote1;			// ���Аݒ�E�v1
			companyNm.CompanySetNote2		= companyNmWork.CompanySetNote2;			// ���Аݒ�E�v2

            # region 2007.05.17  S.Koga  DEL
            ///////////////////////////////////////////////////////////////////// 2005.10.04 AKIYAMA ADD STA //
            //companyNm.TakeInImageGroupCd	= companyNmWork.TakeInImageGroupCd;			// �捞�摜�O���[�v�R�[�h
            // 2005.10.04 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
            # endregion

            // 2007.05.17  S.Koga  add ----------------------------------------
            companyNm.ImageInfoDiv = companyNmWork.ImageInfoDiv;
            companyNm.ImageInfoCode = companyNmWork.ImageInfoCode;
            // ----------------------------------------------------------------

///////////////////////////////////////////////////////////////////// 2006.01.13 NAKAMURA ADD END ADD STA //
			companyNm.CompanyUrl			= companyNmWork.CompanyUrl;			// ���Ђt�q�k
// 2006.01.13 NAKAMURA ADD END /////////////////////////////////////////////////////////////////////

			companyNm.CompanyPrSentence2    = companyNmWork.CompanyPrSentence2;		//����PR���Q
			companyNm.ImageCommentForPrt1   = companyNmWork.ImageCommentForPrt1;	//�摜�󎚗p�R�����g�P
			companyNm.ImageCommentForPrt2   = companyNmWork.ImageCommentForPrt2;	//�摜�󎚗p�R�����g�Q


			return companyNm;
		}

		/// <summary>
		/// �N���X�����o�R�s�[����(���Ж��̃N���X�����Ж��̃��[�N�N���X)
		/// </summary>
		/// <param name="companyNm">���Ж��̃N���X</param>
		/// <returns>���Ж��̃��[�N�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̃N���X���玩�Ж��̃��[�N�N���X�փ����o�R�s�[���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private CompanyNmWork CopyToCompanyNmWorkFromCompanyNm( CompanyNm companyNm )
		{
			CompanyNmWork companyNmWork = new CompanyNmWork();

			// ���ʃw�b�_
			companyNmWork.CreateDateTime		= companyNm.CreateDateTime;
			companyNmWork.UpdateDateTime		= companyNm.UpdateDateTime;
			companyNmWork.EnterpriseCode		= companyNm.EnterpriseCode;
			companyNmWork.FileHeaderGuid		= companyNm.FileHeaderGuid;
			companyNmWork.UpdEmployeeCode		= companyNm.UpdEmployeeCode;
			companyNmWork.UpdAssemblyId1		= companyNm.UpdAssemblyId1.TrimEnd();
			companyNmWork.UpdAssemblyId2		= companyNm.UpdAssemblyId2.TrimEnd();
			companyNmWork.LogicalDeleteCode		= companyNm.LogicalDeleteCode;
			
			companyNmWork.CompanyNameCd			= companyNm.CompanyNameCd;				// ���Ж��̃R�[�h
			companyNmWork.CompanyPr				= companyNm.CompanyPr.TrimEnd();		// ����PR��
			companyNmWork.CompanyName1			= companyNm.CompanyName1.TrimEnd();		// ���Ж���1
			companyNmWork.CompanyName2			= companyNm.CompanyName2.TrimEnd();		// ���Ж���2
			companyNmWork.PostNo				= companyNm.PostNo.TrimEnd();			// �X�֔ԍ�
			companyNmWork.Address1				= companyNm.Address1.TrimEnd();			// �Z��1�i�s���{���s��S�E�����E���j
            //companyNmWork.Address2				= companyNm.Address2;					// �Z��2�i���ځj  // DEL 2008/06/04
			companyNmWork.Address3				= companyNm.Address3.TrimEnd();			// �Z��3�i�Ԓn�j
			companyNmWork.Address4				= companyNm.Address4.TrimEnd();			// �Z��4�i�A�p�[�g���́j
			companyNmWork.CompanyTelNo1			= companyNm.CompanyTelNo1.TrimEnd();	// ���Гd�b�ԍ�1
			companyNmWork.CompanyTelNo2			= companyNm.CompanyTelNo2.TrimEnd();	// ���Гd�b�ԍ�2
			companyNmWork.CompanyTelNo3			= companyNm.CompanyTelNo3.TrimEnd();	// ���Гd�b�ԍ�3
			companyNmWork.CompanyTelTitle1		= companyNm.CompanyTelTitle1.TrimEnd();	// ���Гd�b�ԍ��^�C�g��1
			companyNmWork.CompanyTelTitle2		= companyNm.CompanyTelTitle2.TrimEnd();	// ���Гd�b�ԍ��^�C�g��2
			companyNmWork.CompanyTelTitle3		= companyNm.CompanyTelTitle3.TrimEnd();	// ���Гd�b�ԍ��^�C�g��3
			companyNmWork.TransferGuidance		= companyNm.TransferGuidance.TrimEnd();	// ��s�U���ē���
			companyNmWork.AccountNoInfo1		= companyNm.AccountNoInfo1.TrimEnd();	// ��s����1
			companyNmWork.AccountNoInfo2		= companyNm.AccountNoInfo2.TrimEnd();	// ��s����2
			companyNmWork.AccountNoInfo3		= companyNm.AccountNoInfo3.TrimEnd();	// ��s����3
			companyNmWork.CompanySetNote1		= companyNm.CompanySetNote1.TrimEnd();	// ���Аݒ�E�v1
			companyNmWork.CompanySetNote2		= companyNm.CompanySetNote2.TrimEnd();	// ���Аݒ�E�v2

            # region 2007.05.17  S.Koga  DEL
            ///////////////////////////////////////////////////////////////////// 2005.10.04 AKIYAMA ADD STA //
			//companyNmWork.TakeInImageGroupCd	= companyNm.TakeInImageGroupCd;			// �捞�摜�O���[�v�R�[�h
            // 2005.10.04 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
            # endregion

            // 2007.05.17  S.Koga  add ----------------------------------------
            companyNmWork.ImageInfoDiv = companyNm.ImageInfoDiv;
            companyNmWork.ImageInfoCode = companyNm.ImageInfoCode;
            // ----------------------------------------------------------------

///////////////////////////////////////////////////////////////////// 2006.01.13 NAKAMURA ADD END ADD STA //
			companyNmWork.CompanyUrl			= companyNm.CompanyUrl.TrimEnd();			// ���Ђt�q�k
// 2006.01.13 NAKAMURA ADD END /////////////////////////////////////////////////////////////////////
			companyNmWork.CompanyPrSentence2    = companyNm.CompanyPrSentence2.TrimEnd(); //����PR���Q
			companyNmWork.ImageCommentForPrt1   = companyNm.ImageCommentForPrt1.TrimEnd(); //�摜�󎚗p�R�����g�P
			companyNmWork.ImageCommentForPrt2   = companyNm.ImageCommentForPrt2.TrimEnd(); //�摜�󎚗p�R�����g�Q




			return companyNmWork;
		}
	}
}
