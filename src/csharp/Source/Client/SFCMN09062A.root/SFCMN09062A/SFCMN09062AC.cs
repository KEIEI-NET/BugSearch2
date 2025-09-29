// 2006.09.11 ueo ���[�U�[�K�C�h������������񂪂���΃���������擾����悤�ɕύX
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �擾�Ώۃf�[�^�萔
	/// </summary>
	/// <br>Note		: ���[�U�[�K�C�h�}�X�^�i�{�f�B�j�̎擾�Ώۃf�[�^�̗񋓌^�ł��B</br>
	/// <br>Programmer	: 21027�@�{��  ���u�Y</br>
	/// <br>Date		: 2005.04.18</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: Read�A�K�C�h��Search �̏��������[�J��DB����̓Ǎ��ɕύX</br>
    /// <br>Programmer	: 980023�@�ђJ �k��</br>
    /// <br>Date		: 2007.05.22</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: ���[�J��DB����߂āA�T�[�o�[�ǂݍ��݂ɕύX</br>
    /// <br>Programmer	: 20081�@�D�c �E�l</br>
    /// <br>Date		: 2008.06.16</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �Q�Ɛݒ�Đݒ�</br>
    /// <br>Programmer	: 20056�@���n ���</br>
    /// <br>Date		: 2008.07.11</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote	: �񋟂̓��[�J����ǂ݂ɕύX</br>
    /// <br>Programmer	: 20081�@�D�c �E�l</br>
    /// <br>Date		: 2008.09.05</br>
    /// -----------------------------------------------------------------------------------

    public enum UserGuideAcsData
	{
		/// <summary>
		/// �{�f�B�f�[�^(���[�U�[�ύX��)
		/// </summary>
		UserBodyData,
		/// <summary>
		/// �{�f�B�f�[�^(�񋟕�)
		/// </summary>
		OfferBodyData,
		/// <summary>
		/// �{�f�B�f�[�^(�}�[�W��)
		/// </summary>
		MergeBodyData,
		/// <summary>
		/// �{�f�B�f�[�^(�񋟋敪�}�[�W[�w�b�_�̒񋟋敪�ɒ����ɏ]�����}�[�W])
		/// </summary>
		OfferDivCodeMergeBodyData,
	}

	/// <summary>
	/// ���[�U�[�K�C�h�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���[�U�[�K�C�h�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 21027 �{��  ���u�Y</br>
	/// <br>Date		: 2005.04.18</br>
	/// <br>UpDate Note	: 2006.10.12 22033 �O��  �M�j</br>
	/// <br>			: �EGetGuideName���\�b�h�ɂāA�擾�Ώۂ̃��[�U�[�K�C�h�敪�̃f�[�^���ꌏ�������ꍇ�A</br>
	/// <br>			:   ���̋敪�ł͖��񃊃��[�g�������Ă��܂������C��</br>
	/// <br>			:   �istatic�L���b�V���̗L���̔��f��S�ċ敪���̃t���O���g�p����l�ɕύX�j</br>
	/// </remarks>
    public class UserGuideAcs : IGeneralGuideData
	{
		#region Private Members
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        // 2008.06.16 upd start -------------------------------->>
        // ----- iitani c ---------- start 2007.05.22
		//private IUserGdBdDB  _iUserGdBdDB  = null;
        private UserGdBdLcDB _userGdBdLcDB = null;
        private UserGdBdULcDB _userGdBdULcDB = null;
        // ----- iitani c ---------- end 2007.05.22
        private IUserGdBdDB _iUserGdBdDB = null;
        // 2008.06.16 upd end ----------------------------------<<
		private IUserGdBdUDB _iUserGdBdUDB = null;

		/// <summary>���[�U�[�K�C�h�i�{�f�B�j�N���XStatic</summary>
		private static Hashtable _userGdBdTable_Stc = null;
		private static ArrayList _userGdHdList = null;

		/// <summary>���[�U�[�K�C�h�N���XStatic(�G���g���Ŏg�p���郁����)</summary>
		private static ArrayList _userGdHdEntryList = null;
		private static Hashtable _userGdBdEntryTable = null;

///////////////////////////////////////////////////////////////////// 2005.12.03 AKIYAMA ADD STA //
		// �K�C�h�E���̎擾�p�L���b�V��
		private static Hashtable _guideBufUserGdBd = null;
// 2005.12.03 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
		/// <summary>static���擾�t���O�Ǘ�ArrayList</summary>
		private static ArrayList _staticReadMngList = null;
		#endregion

		#region Constructor
		/// <summary>
		/// ���[�U�[�K�C�h�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public UserGuideAcs()
		{
			UserGuideInitProc();
		}

		/// <summary>
		/// ���[�U�[�K�C�h�e�[�u���A�N�Z�X�N���X�R���X�g���N�^�i���������~�Łj
		/// </summary>
		/// <param name="userGdHdEntry">���[�U�[�K�C�h�w�b�_</param>
		/// <param name="userGdBdEntry">���[�U�[�K�C�h�{�f�B</param>
		public UserGuideAcs(UserGdHd[] userGdHdEntry, UserGdBd[] userGdBdEntry)
		{
			UserGuideInitProc();
			
			_userGdHdEntryList = new ArrayList();
			_userGdBdEntryTable = new Hashtable();

			// ���[�U�[�K�C�h�w�b�_�i�[
			if( userGdHdEntry != null )
			{
				foreach( UserGdHd ugh in userGdHdEntry )
					_userGdHdEntryList.Add( ugh );
			}

			if( userGdBdEntry != null )
			{
				// ���[�U�[�K�C�h�{�f�B�i�[
				foreach( UserGdBd ugb in userGdBdEntry )
				{
					string key = ugb.UserGuideDivCd.ToString() + "_" + ugb.GuideCode.ToString();
					_userGdBdEntryTable.Add( key, ugb );
				}
			}
		}

		private void UserGuideInitProc()
		{
			// ���[�U�[�K�C�h�i�{�f�B�j
			if( _userGdBdTable_Stc == null )
			{
				_userGdBdTable_Stc = new Hashtable();
			}
			if( _userGdHdList == null )
			{
				_userGdHdList = new ArrayList();
			}
			if (_staticReadMngList == null)
			{
				_staticReadMngList = new ArrayList();
			}

			// ���O�C�����i�ŒʐM��Ԃ��m�F
            // -- UPD 2010/05/25 ---------------------->>>
            //if( LoginInfoAcquisition.OnlineFlag )
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iUserGdBdDB = (IUserGdBdDB)MediationUserGdBdDB.GetUserGdBdDB();  // iitani d 2007.05.22 // 2008.06.16 upd
            //        this._iUserGdBdUDB = (IUserGdBdUDB)MediationUserGdBdUDB.GetUserGdBdUDB();
            //    }
            //    catch( Exception )
            //    {
            //        //�I�t���C������null���Z�b�g
            //        //this._iUserGdBdDB = null;  // iitani d 2007.05.22
            //        this._iUserGdBdUDB = null;
            //    }
            //}
            //else
            //{
            //    // �I�t���C�����̃f�[�^�ǂݍ���
            //    this.SearchOfflineData();
            //}

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iUserGdBdDB = (IUserGdBdDB)MediationUserGdBdDB.GetUserGdBdDB();  // iitani d 2007.05.22 // 2008.06.16 upd
                this._iUserGdBdUDB = (IUserGdBdUDB)MediationUserGdBdUDB.GetUserGdBdUDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUserGdBdUDB = null;
            }
            // -- UPD 2010/05/25 ----------------------<<<

            
            // ----- iitani a ---------- start 2007.05.22
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾 
            // �w�b�_
            if (this._userGdBdLcDB == null)
            {
                this._userGdBdLcDB = new UserGdBdLcDB();
            }

            // �{�f�B
            if (this._userGdBdULcDB == null)
            {
                this._userGdBdULcDB = new UserGdBdULcDB();
            }
            // ----- iitani a ---------- end 2007.05.22
            
        }
		#endregion

		#region Public Methods
		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int GetOnlineMode()
		{
            // ----- iitani c ---------- start 2007.05.22
			//if ((this._iUserGdBdDB == null) || (this._iUserGdBdUDB == null))
			if (this._iUserGdBdUDB == null)
            // ----- iitani c ---------- start 2007.05.22
            {
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�jStatic�������S���擾����
		/// </summary>
		/// <param name="retList">���[�U�[�K�C�h�i�{�f�B�jList</param>
		/// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�jStatic�������̑S�����擾���܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList)
		{
			retList = new ArrayList();
			retList.Clear();

			if (_userGdBdTable_Stc == null)
			{
				return -1;
			}
			else if (_userGdBdTable_Stc.Count == 0)
			{
				return 9;
			}

			retList.AddRange(_userGdBdTable_Stc.Values);

			return 0;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�jStatic�������擾����
		/// </summary>
		/// <param name="retList">���[�U�[�K�C�h�i�{�f�B�jList</param>
		/// <param name="userGuideDivCd">���[�U�[�K�C�h�敪�R�[�h</param>
		/// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�jStatic���������敪���w�肵�Ď擾���܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.26</br>
		/// </remarks>
		public int SearchDivCodeStaticMemory(out ArrayList retList, int userGuideDivCd)
		{
			retList = new ArrayList();
			retList.Clear();

			if (_userGdBdTable_Stc == null)
			{
				return -1;
			}
			else if (_userGdBdTable_Stc.Count == 0)
			{
				return 9;
			}
			else
			{
				SortedList sortedList = new SortedList();
				foreach (UserGdBd wkUserGdBd in _userGdBdTable_Stc.Values)
				{
					if (wkUserGdBd.UserGuideDivCd == userGuideDivCd)
					{
						sortedList.Add(wkUserGdBd.GuideCode, wkUserGdBd);
					}
				}

				retList.AddRange(sortedList.Values);
			}

			return 0;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�擾����
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>
		/// <param name="userGuideDivCd">���[�U�[�K�C�h�敪�R�[�h</param>
		/// <param name="guideCode">���[�U�[�K�C�h�R�[�h</param>
		/// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 4:�f�[�^����)</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���������������܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int ReadStaticMemory(out UserGdBd userGdBd, int userGuideDivCd, int guideCode)
		{
			userGdBd = new UserGdBd();

			if (_userGdBdTable_Stc == null)
			{
				return -1;
			}

			// Static���猟��
			//if (_userGdBdTable_Stc[userGuideDivCd.ToString() + "_" + guideCode.ToString().PadLeft(4, '0')] == null)
            if (_userGdBdTable_Stc[userGuideDivCd.ToString() + "_" + guideCode.ToString()] == null)
			{
				return 4;
			}
			else
			{
                userGdBd = (UserGdBd)_userGdBdTable_Stc[userGuideDivCd.ToString() + "_" + guideCode.ToString()];
                //userGdBd = (UserGdBd)_userGdBdTable_Stc[userGuideDivCd.ToString() + "_" + guideCode.ToString().PadLeft(4, '0')];
			}
			
			return 0;
		}

		/// <summary>
		/// ���[�U�[�K�C�hStatic���������I�t���C���������ݏ���
		/// </summary>
		/// <param name="sender">object�i�ďo���I�u�W�F�N�g�j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�hStatic�������̏������[�J���t�@�C���ɕۑ����܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			// �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status = 9;

			if (_userGdBdTable_Stc.Count != 0)
			{
				// KeyList�ݒ�
				string[] userGdBdKeys = new string[1];
				userGdBdKeys[0] = LoginInfoAcquisition.EnterpriseCode;

				ArrayList userGdBdUWorkList = new ArrayList();
				foreach (UserGdBd userGdBd in _userGdBdTable_Stc.Values)
				{
					// �N���X �� ���[�J�[�N���X
					userGdBdUWorkList.Add(CopyToUserGdBdUWorkFromUserGdBd(userGdBd));
				}
				
				status = offlineDataSerializer.Serialize("UserGuideAcs", userGdBdKeys, userGdBdUWorkList);
			}

			return status;
		}

		/// <summary>
		/// KEY�w�胆�[�U�[�K�C�h�i�{�f�B�j���ǂݍ��ݏ���
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h�i���[�U�[�̏ꍇ�̂݁j</param>
		/// <param name="guideDivCode">�K�C�h�敪</param>
		/// <param name="guideCode">�K�C�h�R�[�h</param>
		/// <param name="acsDataType">�擾�Ώۃf�[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int ReadBody(out UserGdBd userGdBd, string enterpriseCode, int guideDivCode, int guideCode, ref UserGuideAcsData acsDataType)
		{
			try
			{
				userGdBd = null;
				int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

				// �I�����C�����̓����[�g�擾
                // -- DEL 2010/05/25 --------------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // -- DEL 2010/05/25 ---------------------<<<
                    switch (acsDataType)
					{
						case UserGuideAcsData.OfferBodyData :
						{
							// �񋟕���ǂݍ���
							status = ReadBodyProc(out userGdBd, enterpriseCode, guideDivCode, guideCode, UserGuideAcsData.OfferBodyData);
							break;
						}
						case UserGuideAcsData.UserBodyData :
						{
							// ���[�U�[�ύX����ǂݍ���
							status = ReadBodyProc(out userGdBd, enterpriseCode, guideDivCode, guideCode, UserGuideAcsData.UserBodyData);
							break;
						}
						case UserGuideAcsData.MergeBodyData :
						{
							// ���[�U�[�ύX����ǂݍ���
							status = ReadBodyProc(out userGdBd, enterpriseCode, guideDivCode, guideCode, UserGuideAcsData.UserBodyData);
							switch (status)
							{
								case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
								{
									acsDataType = UserGuideAcsData.UserBodyData;
									break;
								}
								case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
								{
									// �񋟕���ǂݍ���
									status = ReadBodyProc(out userGdBd, enterpriseCode, guideDivCode, guideCode, UserGuideAcsData.OfferBodyData);
									switch (status)
									{
										case (int)ConstantManagement.DB_Status.ctDB_NORMAL :
										{
											acsDataType = UserGuideAcsData.OfferBodyData;
											break;
										}
										case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND :
										{
											break;
										}
										default :
										{
											break;
										}
									}
									break;
								}
								default :
								{
									break;
								}
							}
							break;
						}
						default :
						{
							break;
						}
					}

                // -- DEL 2010/05/25 --------------------->>>
                //}
                //else	// �I�t���C�����̓L���b�V������擾
                //{
                //    status = ReadStaticMemory(out userGdBd, guideDivCode, guideCode);
                //}
                // -- DEL 2010/05/25 ---------------------<<<

				return status;   
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				userGdBd = null;
				//�I�t���C������null���Z�b�g
				//this._iUserGdBdDB  = null;  // iitani d 2007.05.22
				this._iUserGdBdUDB = null;
				return -1;
			}
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�o�^�E�X�V����
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int Write(ref UserGdBd userGdBd)
		{
			// ���[�U�[�K�C�h�i�{�f�B�j�N���X���烆�[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j���[�J�[�N���X�Ƀ����o�R�s�[
			UserGdBdUWork userGdBdUWork = CopyToUserGdBdUWorkFromUserGdBd(userGdBd);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(userGdBdUWork);

			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// ���[�U�[�K�C�h�i�{�f�B�j��������
				status = this._iUserGdBdUDB.Write(ref parabyte);
				
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// �t�@�C������n���ă��[�U�[�K�C�h�i�{�f�B�j���[�N�N���X���f�V���A���C�Y����
					userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdUWork));
					// �N���X�������o�R�s�[
					userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
///////////////////////////////////////////////////////////////////// 2005.12.02 AKIYAMA ADD STA //
					// �K�C�h�p�L���b�V�����X�V
					if (ReadCheck(userGdBdUWork.UserGuideDivCd))
					{
						// �n�b�V���e�[�u���擾
						Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];

						// ���ɓo�^�ς݂̏ꍇ�͈�x�폜
						if( wkUserGdBdTable.ContainsKey( userGdBd.GuideCode ) == true ) {
							wkUserGdBdTable.Remove( userGdBd.GuideCode );
						}

						// �o�^
						wkUserGdBdTable.Add( userGdBd.GuideCode, userGdBd.Clone() );
					}
// 2005.12.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				}
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				//this._iUserGdBdDB = null;  // iitani d 2007.05.22
				// �ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�_���폜����
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�̘_���폜���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int LogicalDelete(ref UserGdBd userGdBd)
		{
			try
			{
				// ���[�U�[�K�C�h�i�{�f�B�j�N���X���烆�[�U�[�K�C�h�i�{�f�B�j���[�J�[�N���X�Ƀ����o�R�s�[
				UserGdBdUWork userGdBdUWork = CopyToUserGdBdUWorkFromUserGdBd(userGdBd);

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(userGdBdUWork);

				// ���[�U�[�K�C�h�i�{�f�B�j�_���폜
				int status = this._iUserGdBdUDB.LogicalDelete(ref parabyte);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// �t�@�C������n���ă��[�U�[�K�C�h�i�{�f�B�j���[�N�N���X���f�V���A���C�Y����
					userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdUWork));
					// �N���X�������o�R�s�[
					userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
///////////////////////////////////////////////////////////////////// 2005.12.02 AKIYAMA ADD STA //
					// �K�C�h�p�L���b�V�����X�V
					if (ReadCheck(userGdBdUWork.UserGuideDivCd))
					{
						// �n�b�V���e�[�u���擾
						Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];

						// ���ɓo�^�ς݂̏ꍇ�͈�x�폜
						if( wkUserGdBdTable.ContainsKey( userGdBd.GuideCode ) == true ) {
							wkUserGdBdTable.Remove( userGdBd.GuideCode );
						}

						// �o�^
						wkUserGdBdTable.Add( userGdBd.GuideCode, userGdBd.Clone() );
					}
// 2005.12.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				}

				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iUserGdBdUDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�����폜����
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�̕����폜���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int Delete(UserGdBd userGdBd)
		{
			try
			{
				// ���[�U�[�K�C�h�i�{�f�B�j�N���X���烆�[�U�[�K�C�h�i�{�f�B�j���[�J�[�N���X�Ƀ����o�R�s�[
				UserGdBdUWork userGdBdUWork = CopyToUserGdBdUWorkFromUserGdBd(userGdBd);

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(userGdBdUWork);

				// ���[�U�[�K�C�h�i�{�f�B�j�����폜
				int status = this._iUserGdBdUDB.Delete(parabyte);

///////////////////////////////////////////////////////////////////// 2005.12.02 AKIYAMA ADD STA //
				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// �K�C�h�p�L���b�V�����X�V
					if (ReadCheck(userGdBdUWork.UserGuideDivCd))
					{
						// �n�b�V���e�[�u���擾
						Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];

						// ���ɓo�^�ς݂̏ꍇ�͈�x�폜
						if( wkUserGdBdTable.ContainsKey( userGdBd.GuideCode ) == true ) {
							wkUserGdBdTable.Remove( userGdBd.GuideCode );
						}
					}
				}
// 2005.12.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iUserGdBdUDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�w�b�_�j���S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�w�b�_�j���̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchHeader(out ArrayList retList)
		{
			return SearchHeaderProc(out retList, ConstantManagement.LogicalMode.GetData0);
		}

        // ----- iitani a ---------- start 2007.05.22
        /// <summary>
        /// ���[�U�[�K�C�h�i�{�f�B�j���S���������i�_���폜�����j�i���[�J���j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="acsDataType">�擾�Ώۃf�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 21027 �{��  ���u�Y</br>
        /// <br>Date       : 2005.04.18</br>
        /// </remarks>
        public int SearchLocal(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType, int UserGuideDivCd )
        {
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData0, UserGuideDivCd, 0);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�i�{�f�B�j���S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="acsDataType">�擾�Ώۃf�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 21027 �{��  ���u�Y</br>
        /// <br>Date       : 2005.04.18</br>
        /// </remarks>
        public int SearchBody(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType, int UserGuideDivCd)
        {
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData0, UserGuideDivCd, 1);
        }
        // ----- iitani a ---------- end 2007.05.22

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j���S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="acsDataType">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchBody(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType)
		{
            // ----- iitani c ---------- start 2007.05.22
            //return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData0);
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData0, 0, 1);
            // ----- iitani c ---------- end 2007.05.22
		}

        // ----- iitani a ---------- start 2007.05.22
        /// <summary>
        /// ���[�U�[�K�C�h�i�{�f�B�j���S���������i�_���폜�܂ށj(���[�J��)
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="acsDataType">�擾�Ώۃf�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 21027 �{��  ���u�Y</br>
        /// <br>Date       : 2005.04.18</br>
        /// </remarks>
        public int SearchLocalAllBody(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType)
        {
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData01, 0, 0);
        }
        // ----- iitani a ---------- end 2007.05.22

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j���S���������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="acsDataType">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchAllBody(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType)
        {
            // ----- iitani c ---------- start 2007.05.22
            //return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData01);
            return SearchBodyProc(out retList, enterpriseCode, acsDataType, ConstantManagement.LogicalMode.GetData01, 0, 1);
            // ----- iitani c ---------- end 2007.05.22
        }

		/// <summary>
		/// �K�C�h�敪�w�胆�[�U�[�K�C�h�i�{�f�B�j��񌟍������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="acsDataType">�擾�Ώۃf�[�^</param>
		/// <param name="guideDivCode">�K�C�h�敪�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w��K�C�h�敪�̃��[�U�[�K�C�h�i�{�f�B�j���̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchDivCodeBody(out ArrayList retList, string enterpriseCode, int guideDivCode, UserGuideAcsData acsDataType)
		{
			return SearchDivCodeBodyProc(out retList, enterpriseCode, guideDivCode, acsDataType, ConstantManagement.LogicalMode.GetData0);
		}

		/// <summary>
		/// �K�C�h�敪�w�胆�[�U�[�K�C�h�i�{�f�B�j��񌟍������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="acsDataType">�擾�Ώۃf�[�^</param>
		/// <param name="guideDivCode">�K�C�h�敪�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w��K�C�h�敪�̃��[�U�[�K�C�h�i�{�f�B�j���̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchAllDivCodeBody(out ArrayList retList, string enterpriseCode, int guideDivCode, UserGuideAcsData acsDataType)
		{
			return SearchDivCodeBodyProc(out retList, enterpriseCode, guideDivCode, acsDataType, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�_���폜��������
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���̕������s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int Revival(ref UserGdBd userGdBd)
		{
			try
			{
				// ���[�U�[�K�C�h�i�{�f�B�j�N���X���烆�[�U�[�K�C�h�i�{�f�B�j���[�J�[�N���X�Ƀ����o�R�s�[
				UserGdBdUWork userGdBdUWork = CopyToUserGdBdUWorkFromUserGdBd(userGdBd);

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(userGdBdUWork);

				// ���[�U�[�K�C�h�i�{�f�B�j��������
				int status = this._iUserGdBdUDB.RevivalLogicalDelete(ref parabyte);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j���[�N�N���X���f�V���A���C�Y����
					userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(parabyte, typeof(UserGdBdUWork));
					// �N���X�������o�R�s�[
					userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
///////////////////////////////////////////////////////////////////// 2005.12.02 AKIYAMA ADD STA //
					// �K�C�h�p�L���b�V�����X�V
					if (ReadCheck(userGdBd.UserGuideDivCd))
					{
						// �n�b�V���e�[�u���擾
						Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];

						// ���ɓo�^�ς݂̏ꍇ�͈�x�폜
						if( wkUserGdBdTable.ContainsKey( userGdBd.GuideCode ) == true ) {
							wkUserGdBdTable.Remove( userGdBd.GuideCode );
						}

						// �o�^
						wkUserGdBdTable.Add( userGdBd.GuideCode, userGdBd.Clone() );
					}
// 2005.12.02 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				}

				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iUserGdBdUDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�w�b�_�j���������i���s���j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�w�b�_�j�̌����������s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private int SearchHeaderProc(out ArrayList retList, ConstantManagement.LogicalMode logicalMode)
        {
			UserGdHdWork userGdHdWork = new UserGdHdWork();

			retList = new ArrayList();
			retList.Clear();

			object paraObj = userGdHdWork as Object;
			object retObj;

			// ���[�U�[�K�C�h�i�w�b�_�j����
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 2008.06.16 upd start --------------------------->>
            // ----- iitani c ---------- start 2007.05.22
			//status = this._iUserGdBdDB.SearchHeader(out retObj, paraObj, 0, logicalMode);
            status = this._userGdBdLcDB.SearchHeader(out retObj, paraObj, 0, logicalMode);
            // ----- iitani c ---------- start 2007.05.22
            // 2008.06.16 upd end -----------------------------<<
            
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				ArrayList userGdHdWorkList = retObj as ArrayList;
				
				for(int i = 0; i < userGdHdWorkList.Count; i++)
				{
					// �N���X�������o�R�s�[
					retList.Add(CopyToUserGdHdFromUserGdHdWork((UserGdHdWork)userGdHdWorkList[i]));
				}
					
				// �L���b�V���ێ��iSearchProc OfferDivCodeMerge �p�j
				_userGdHdList = (ArrayList)retList.Clone();
			}
			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j���������i���s���j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="acsDataType">�擾�Ώۃf�[�^</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̌����������s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
        // ----- iitani c ---------- start 2007.05.22
		//private int SearchBodyProc(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType, ConstantManagement.LogicalMode logicalMode)
        private int SearchBodyProc(out ArrayList retList, string enterpriseCode, UserGuideAcsData acsDataType, ConstantManagement.LogicalMode logicalMode, int UserGuideDivCd, int searchMode)
        // ----- iitani c ---------- end 2007.05.22
        {
			UserGdBdWork userGdBdWork   = new UserGdBdWork();

			UserGdBdUWork userGdBdUWork  = new UserGdBdUWork();
			userGdBdUWork.EnterpriseCode = enterpriseCode;
	
			retList = new ArrayList();
			retList.Clear();

			object offerObj = userGdBdWork as Object;
			object userObj  = userGdBdUWork as Object;
			object retObj;

			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			
			// �I�t���C���̏ꍇ�L���b�V������擾
            // -- DEL 2010/05/25 ------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList);
            //}
            //else	// �I�����C���̏ꍇ�����[�g�擾
            //{
            // -- DEL 2010/05/25 -------------------------<<<
                //-- �񋟕����� --//
				if (acsDataType == UserGuideAcsData.OfferBodyData)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j����
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- start 2007.05.22

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						ArrayList userGdBdWorkList = retObj as ArrayList;

						for(int i = 0; i < userGdBdWorkList.Count; i++)
						{
							// �N���X�������o�R�s�[
							retList.Add(CopyToUserGdBdFromUserGdBdWork((UserGdBdWork)userGdBdWorkList[i]));
							// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
							CopyToStaticFromDataClass(CopyToUserGdBdFromUserGdBdWork((UserGdBdWork)userGdBdWorkList[i]));
						}
					}
				}
					//-- ���[�U�[������ --//
				else if (acsDataType == UserGuideAcsData.UserBodyData)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j����
                    // ----- iitani c ----- start 2007.05.22
					//status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                    if (searchMode == 1)
                    {
                        // �����[�g
                        status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                    }
                    else
                    {
                        // ���[�J��
                        status = this._userGdBdULcDB.Search(out retObj, userObj, 0, logicalMode);
                    }

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						ArrayList userGdBdUWorkList = retObj as ArrayList;
				
						for(int i = 0; i < userGdBdUWorkList.Count; i++)
						{
							// �N���X�������o�R�s�[
							retList.Add(CopyToUserGdBdFromUserGdBdUWork((UserGdBdUWork)userGdBdUWorkList[i]));
							// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
							CopyToStaticFromDataClass(CopyToUserGdBdFromUserGdBdUWork((UserGdBdUWork)userGdBdUWorkList[i]));
						}
					}
				}
					//-- �񋟕��E���[�U�[�ύX���}�[�W���� --//
				else if (acsDataType == UserGuideAcsData.MergeBodyData)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j����
                    // 2008.06.16 upd start ----------------------------->>
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- start 2007.05.22
                    // 2008.06.16 upd end -------------------------------<<

					// ����擾���́A0���̏ꍇ
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
					{
						Hashtable mergeTable = new Hashtable();
						string hashKey;

						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						if (userGdBdWorkList != null)
						{
							foreach (UserGdBdWork wkUserGdBdWork in userGdBdWorkList)
							{
								UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdWork(wkUserGdBdWork);
	
								// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
								CopyToStaticFromDataClass(wkUserGdBd);
							
								hashKey = wkUserGdBd.UserGuideDivCd.ToString() + "_" + wkUserGdBd.GuideCode.ToString();
								mergeTable.Add(hashKey, wkUserGdBd);
							}
						}
					
						// ���[�U�[�K�C�h�i�{�f�B�j����
                        // ----- iitani c ---------- start 2007.05.22
						//status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                        if (searchMode == 1)
                        {
                            // �����[�g
                            status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                        }
                        else
                        {
                            // ���[�J��
                            status = this._userGdBdULcDB.Search(out retObj, userObj, 0, logicalMode);
                        }
                        // ----- iitani c ---------- end 2007.05.22

						// ����擾���́A0���̏ꍇ
						if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							ArrayList userGdBdUWorkList = retObj as ArrayList;
				
							if (userGdBdUWorkList != null)
							{
								foreach (UserGdBdUWork wkUserGdBdUWork in userGdBdUWorkList)
								{
									UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdUWork(wkUserGdBdUWork);

									// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
									CopyToStaticFromDataClass(wkUserGdBd);

									hashKey = wkUserGdBd.UserGuideDivCd.ToString() + "_" + wkUserGdBd.GuideCode.ToString();

									// �}�[�W
									if (mergeTable.ContainsKey(hashKey))
									{
										mergeTable[hashKey] = wkUserGdBd;
									}
									else 
									{
										if (UserGuideDivCd != 0)
										{
											// DivCode����������
											if (wkUserGdBd.UserGuideDivCd == UserGuideDivCd)
											{
												mergeTable.Add(hashKey, wkUserGdBd);
											}
										}
										else
										{
											mergeTable.Add(hashKey, wkUserGdBd);
										}
									}					
								}
							
								if (mergeTable.Count > 0)
								{
									SortedList sortList = new SortedList();
									sortList.Add(mergeTable, mergeTable.Clone());

									retList = new ArrayList(mergeTable.Values);

                                    // �\�[�g����
                                    UserGdBdCompare userGdBdCompare = new UserGdBdCompare();
                                    retList.Sort(userGdBdCompare);
                                }
							}
						
							if (retList.Count != 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
						}
					}
				}
					//-- Header�񋟋敪�� �}�[�W���� --//   (�\�[�g���Ă܂���)
				else if	(acsDataType == UserGuideAcsData.OfferDivCodeMergeBodyData)
				{
					// �w�b�_�[�̃L���b�V���������ꍇ
					if (_userGdHdList.Count == 0)
					{
						ArrayList userGdHdListWk;

						// �w�b�_�[���擾
						SearchHeaderProc(out userGdHdListWk, 0);
					}

					// ���[�U�[�K�C�h�i�{�f�B�j����
                    // 2008.06.16 upd start ------------------------------------------->>
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchBody(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- end 2007.05.22
                    // 2008.06.16 upd end ---------------------------------------------<<

					// ����擾���́A0���̏ꍇ
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
					{
						// �}�[�W�pArrayList�i�񋟁j
						ArrayList mergeOfferList = new ArrayList();

						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						if (userGdBdWorkList != null)
						{
							foreach (UserGdBdWork wkUserGdBdWork in userGdBdWorkList)
							{
								UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdWork(wkUserGdBdWork);
	
								// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
								CopyToStaticFromDataClass(wkUserGdBd);

								mergeOfferList.Add(wkUserGdBd);
							}
						}
					
						// ���[�U�[�K�C�h�i�{�f�B�j����
                        // ----- iitani c ---------- start 2007.05.22
                        if (searchMode == 1)
                        {
                            status = this._iUserGdBdUDB.Search(out retObj, userObj, 0, logicalMode);
                        }
                        else
                        {
                            status = this._userGdBdULcDB.Search(out retObj, userObj, 0, logicalMode);
                        }
                        // ----- iitani c ---------- end 2007.05.22

						// ����擾���́A0���̏ꍇ
						if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							// �}�[�W�pArrayList�i���[�U�[�j
							ArrayList mergeUserList = new ArrayList();

							// �ŏI�}�[�W�pList
							ArrayList OfferDivCodeMergeList = new ArrayList();
								
							ArrayList userGdBdUWorkList = retObj as ArrayList;
				
							if (userGdBdUWorkList != null)
							{
								foreach (UserGdBdUWork wkUserGdBdUWork in userGdBdUWorkList)
								{
									UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdUWork(wkUserGdBdUWork);

									// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
									CopyToStaticFromDataClass(wkUserGdBd);

									mergeUserList.Add(wkUserGdBd);
								}

								// �w�b�_��DivCode���ɒ񋟋敪�ɏ]�����f�[�^���Z�b�g����
								foreach (UserGdHd userGdHdWk in _userGdHdList)
								{
									// �񋟂̏ꍇ
									if (userGdHdWk.MasterOfferCd == 0)
									{
										// �񋟃f�[�^List�S������
										foreach (UserGdBd userGdBdWk in mergeOfferList)
										{
											// DivCode����������
											if (userGdBdWk.UserGuideDivCd == userGdHdWk.UserGuideDivCd)
											{
												OfferDivCodeMergeList.Add(userGdBdWk);
											}
										}
									}
									else  // �����񋟂̏ꍇ
									{
										// ���[�U�[�f�[�^List�S������
										foreach (UserGdBd userGdBdWk in mergeUserList)
										{
											// DivCode����������
											if (userGdBdWk.UserGuideDivCd == userGdHdWk.UserGuideDivCd)
											{
												OfferDivCodeMergeList.Add(userGdBdWk);
											}
										}
									}
								}

								if (OfferDivCodeMergeList.Count > 0)
								{
									retList = OfferDivCodeMergeList;
								}
							}
						
							if (retList.Count != 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
						}
					}
				}
			//} // DEL 2010/05/25
			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j���������i���s���j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="acsDataType">�擾�Ώۃf�[�^</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="guideDivCode">�K�C�h�敪�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̌����������s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private int SearchDivCodeBodyProc(out ArrayList retList, string enterpriseCode, int guideDivCode, UserGuideAcsData acsDataType, ConstantManagement.LogicalMode logicalMode)
		{
			UserGdBdWork userGdBdWork   = new UserGdBdWork();
			userGdBdWork.UserGuideDivCd = guideDivCode;

			UserGdBdUWork userGdBdUWork  = new UserGdBdUWork();
			userGdBdUWork.EnterpriseCode = enterpriseCode;
			userGdBdUWork.UserGuideDivCd = guideDivCode;

			retList = new ArrayList();
			retList.Clear();
			int status = 0;

			object offerObj = userGdBdWork as Object;
			object userObj  = userGdBdUWork as Object;
			object retObj;

			// �I�t���C���̏ꍇ�L���b�V������擾
            // -- DEL 2010/05/25 ----------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    SearchDivCodeStaticMemory(out retList, guideDivCode);
            //}
            //else	 // �I�����C���̏ꍇ�̓����[�g�擾
            //{
            // -- DEL 2010/05/25 -----------------<<<
                //-- �񋟕����� --//
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			
				if (acsDataType == UserGuideAcsData.OfferBodyData)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j����
                    
                    // ----- iitani c ---------- start 2007.05.22
					//status = this._iUserGdBdDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- end 2007.05.22

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						for(int i = 0; i < userGdBdWorkList.Count; i++)
						{
							// �N���X�������o�R�s�[
							retList.Add(CopyToUserGdBdFromUserGdBdWork((UserGdBdWork)userGdBdWorkList[i]));
							// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
							CopyToStaticFromDataClass(CopyToUserGdBdFromUserGdBdWork((UserGdBdWork)userGdBdWorkList[i]));
						}
					}
				}
					//-- ���[�U�[������ --//
				else if (acsDataType == UserGuideAcsData.UserBodyData)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j����
					status = this._iUserGdBdUDB.SearchGuideDivCode(out retObj, userObj, 0, logicalMode);

					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						ArrayList userGdBdUWorkList = retObj as ArrayList;
				
						for(int i = 0; i < userGdBdUWorkList.Count; i++)
						{
							// �N���X�������o�R�s�[
							retList.Add(CopyToUserGdBdFromUserGdBdUWork((UserGdBdUWork)userGdBdUWorkList[i]));
							// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
							CopyToStaticFromDataClass(CopyToUserGdBdFromUserGdBdUWork((UserGdBdUWork)userGdBdUWorkList[i]));
						}
					}
				}
					//-- �񋟕��E���[�U�[�ύX���}�[�W���� --//
				else if (acsDataType == UserGuideAcsData.MergeBodyData)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j����
                    // 2008.06.16 upd start ---------------------------->>
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- end 2007.05.22
                    // 2008.06.16 upd end ------------------------------<<

					// ����擾���́A0���̏ꍇ
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
					{
						Hashtable mergeTable = new Hashtable();
						string hashKey;

						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						if (userGdBdWorkList != null)
						{
							foreach (UserGdBdWork wkUserGdBdWork in userGdBdWorkList)
							{
								UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdWork(wkUserGdBdWork);

								// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
								CopyToStaticFromDataClass(wkUserGdBd);
							
								hashKey = wkUserGdBd.UserGuideDivCd.ToString() + "_" + wkUserGdBd.GuideCode.ToString();
								mergeTable.Add(hashKey, wkUserGdBd);
							}
						}
					
						// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j����
						status = this._iUserGdBdUDB.SearchGuideDivCode(out retObj, userObj, 0, logicalMode);

						// ����擾���́A0���̏ꍇ
						if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							ArrayList userGdBdUWorkList = retObj as ArrayList;
				
							if (userGdBdUWorkList != null)
							{
								foreach (UserGdBdUWork wkUserGdBdUWork in userGdBdUWorkList)
								{
									UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdUWork(wkUserGdBdUWork);
								
									// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
									CopyToStaticFromDataClass(wkUserGdBd);

									hashKey = wkUserGdBd.UserGuideDivCd.ToString() + "_" + wkUserGdBd.GuideCode.ToString();

									// �}�[�W
									if (mergeTable.ContainsKey(hashKey))
									{
										mergeTable[hashKey] = wkUserGdBd;
									}
									else 
									{
										mergeTable.Add(hashKey, wkUserGdBd);
									}					
								}
							
								if (mergeTable.Count > 0)
								{
									SortedList sortList = new SortedList();
									foreach (UserGdBd userGdBd in mergeTable.Values)
									{
										sortList.Add(userGdBd.GuideCode, userGdBd.Clone());
									}
								
									retList = new ArrayList(sortList.Values);
								}
							}

							if (retList.Count != 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
						}
					}
				}
					//-- Header�񋟋敪�� �}�[�W���� --//   (�\�[�g���Ă܂���)
				else if	(acsDataType == UserGuideAcsData.OfferDivCodeMergeBodyData)
				{
					// �w�b�_�[�̃L���b�V���������ꍇ
					if (_userGdHdList.Count == 0)
					{
						ArrayList userGdHdListWk;

						// �w�b�_�[���擾
						SearchHeaderProc(out userGdHdListWk, 0);
					}

					// ���[�U�[�K�C�h�i�{�f�B�j����
                    // 2008.06.16 upd start --------------------------->>
                    // ----- iitani c ---------- start 2007.05.22
                    //status = this._iUserGdBdDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    status = this._userGdBdLcDB.SearchGuideDivCode(out retObj, offerObj, 0, logicalMode);
                    // ----- iitani c ---------- end 2007.05.22
                    // 2008.06.16 upd end -----------------------------<<

					// ����擾���́A0���̏ꍇ
					if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
						(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
					{
						// �}�[�W�pArrayList�i�񋟁j
						ArrayList mergeOfferList = new ArrayList();

						ArrayList userGdBdWorkList = retObj as ArrayList;
				
						if (userGdBdWorkList != null)
						{
							foreach (UserGdBdWork wkUserGdBdWork in userGdBdWorkList)
							{
								UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdWork(wkUserGdBdWork);
	
								// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
								CopyToStaticFromDataClass(wkUserGdBd);

								mergeOfferList.Add(wkUserGdBd);
							}
						}
					
						// ���[�U�[�K�C�h�i�{�f�B�j����
						status = this._iUserGdBdUDB.SearchGuideDivCode(out retObj, userObj, 0, logicalMode);

						// ����擾���́A0���̏ꍇ
						if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							// �}�[�W�pArrayList�i���[�U�[�j
							ArrayList mergeUserList = new ArrayList();

							// �ŏI�}�[�W�pList
							ArrayList OfferDivCodeMergeList = new ArrayList();
								
							ArrayList userGdBdUWorkList = retObj as ArrayList;
				
							if (userGdBdUWorkList != null)
							{
								foreach (UserGdBdUWork wkUserGdBdUWork in userGdBdUWorkList)
								{
									UserGdBd wkUserGdBd = CopyToUserGdBdFromUserGdBdUWork(wkUserGdBdUWork);

									// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
									CopyToStaticFromDataClass(wkUserGdBd);

									mergeUserList.Add(wkUserGdBd);
								}

								// �w�b�_��DivCode���ɒ񋟋敪�ɏ]�����f�[�^���Z�b�g����
								foreach (UserGdHd userGdHdWk in _userGdHdList)
								{
									if( userGdHdWk.UserGuideDivCd != guideDivCode ) {
										continue;
									}

									// �񋟂̏ꍇ
									if (userGdHdWk.MasterOfferCd == 0)
									{
										// �񋟃f�[�^List�S������
										foreach (UserGdBd userGdBdWk in mergeOfferList)
										{
											// DivCode����������
											if (userGdBdWk.UserGuideDivCd == userGdHdWk.UserGuideDivCd)
											{
												OfferDivCodeMergeList.Add(userGdBdWk);
											}
										}
									}
									else  // �����񋟂̏ꍇ
									{
										// ���[�U�[�f�[�^List�S������
										foreach (UserGdBd userGdBdWk in mergeUserList)
										{
											// DivCode����������
											if (userGdBdWk.UserGuideDivCd == userGdHdWk.UserGuideDivCd)
											{
												OfferDivCodeMergeList.Add(userGdBdWk);
											}
										}
									}
								}

								if (OfferDivCodeMergeList.Count > 0)
								{
									retList = OfferDivCodeMergeList;
								}
							}
						
							if (retList.Count != 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
							else {
								status = (int)ConstantManagement.DB_Status.ctDB_EOF;
							}
						}
					}
				}
			//}  // DEL 2010/05/25
			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�w�b�_�j���������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�w�b�_�j�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		public int SearchHeader(ref DataSet ds)
		{
			UserGdHdWork userGdHdWork = new UserGdHdWork();

			// �T�[�`�p���X�g������
			ArrayList paraList = new ArrayList();
			paraList.Clear();

			object paraObj = userGdHdWork;
			object retObj = null;

			// �Ԕ̃K�C�h�}�X�^�i�w�b�_�j����
            // 2008.06.16 upd start ------------------------------>>
            // ----- iitani c ---------- start 2007.05.22
            //int status = this._iUserGdBdDB.SearchHeader(out retObj, paraObj, 0, 0);
            int status = this._userGdBdLcDB.SearchHeader(out retObj, paraObj, 0, 0);
            //int status = this._uszzzerGdBdLcDB.SearchHeader(out retObj, paraObj, 0, 0);
            // ----- iitani c ---------- end 2007.05.22
            // 2008.06.16 upd end --------------------------------<<

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				paraList = retObj as ArrayList;
				UserGdHdWork[] byte_userGdHdWork = new UserGdHdWork[paraList.Count];
				
				for(int ix = 0; ix < paraList.Count; ix++)
				{
					byte_userGdHdWork[ix] = (UserGdHdWork)paraList[ix];
				}
								
				// XML�֕ϊ����A������̃o�C�i����
				byte[] retbyte = XmlByteSerializer.Serialize(byte_userGdHdWork);
				
				XmlByteSerializer.ReadXml(ref ds, retbyte);
			}
			return status;
		}

        // ----- iitani a ---------- start 2007.05.22
		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j���������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h�i���[�U�[�̏ꍇ�̂݁j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
        public int SearchLocalBody(ref DataSet ds, string enterpriseCode, int userGuideDivCd)
        {
            return SearchBody(ref ds, enterpriseCode, userGuideDivCd, 0);  // ���[�J��
        }

        /// <summary>
        /// ���[�U�[�K�C�h�i�{�f�B�j���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h�i���[�U�[�̏ꍇ�̂݁j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.06.16</br>
        /// </remarks>
        public int SearchGuidBody(ref DataSet ds, string enterpriseCode, int userGuideDivCd)
        {
            return SearchBody(ref ds, enterpriseCode, userGuideDivCd, 1);  // �T�[�o
        }
        
		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j���������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h�i���[�U�[�̏ꍇ�̂݁j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
        public int SearchBody(ref DataSet ds, string enterpriseCode)
        {
            return SearchBody(ref ds, enterpriseCode, 0, 1);  // �����[�g
        }
        // ----- iitani a ---------- end 2007.05.22

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j���������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h�i���[�U�[�̏ꍇ�̂݁j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
        // ----- iitani c ---------- start 2007.05.22  
		//public int SearchBody(ref DataSet ds, string enterpriseCode)
        public int SearchBody(ref DataSet ds, string enterpriseCode, int userGuideDivCd, int searchMode)
        // ----- iitani c ---------- start 2007.05.22  
        {
			ArrayList retList = new ArrayList();
			int status;
			
			// �I�����C���̏ꍇ�̓����[�g�擾
            // -- UPD 2010/05/25 --------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    // ���[�U�[�K�C�h�i�{�f�B�j��������
            //    status = SearchBodyProc(out retList, enterpriseCode, UserGuideAcsData.MergeBodyData, 0, userGuideDivCd, searchMode);
            //}
            //else	// �I�t���C���̏ꍇ�̓L���b�V������ǂ�
            //{
            //    status = SearchStaticMemory(out retList);
            //}

            // ���[�U�[�K�C�h�i�{�f�B�j��������
            status = SearchBodyProc(out retList, enterpriseCode, UserGuideAcsData.MergeBodyData, 0, userGuideDivCd, searchMode);
            // -- UPD 2010/05/25 ---------------------<<<
			
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �I�����C���̏ꍇ�̓L���b�V���ɕێ�
                // -- UPD 2010/05/25 ------------------->>>
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                //    foreach (UserGdBd wkUserGdBd in retList)
                //    {
                //        // ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
                //        CopyToStaticFromDataClass(wkUserGdBd);
                //    }
                //}

                foreach (UserGdBd wkUserGdBd in retList)
                {
                    // ���[�U�[�K�C�h�i�{�f�B�j�N���X �� Static�]�L����
                    CopyToStaticFromDataClass(wkUserGdBd);
                }
                // -- UPD 2010/05/25 -------------------<<<
					
				UserGdBd[] byte_userGdBdWork = new UserGdBd[retList.Count];
								
				for(int ix = 0; ix < retList.Count; ix++)
				{
					byte_userGdBdWork[ix] = (UserGdBd)retList[ix];
				}
								
				// XML�֕ϊ����A������̃o�C�i����
				byte[] retbyte = XmlByteSerializer.Serialize(byte_userGdBdWork);
				
				XmlByteSerializer.ReadXml(ref ds, retbyte);
			}
			return status;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// KEY�w�胆�[�U�[�K�C�h�i�{�f�B�j���ǂݍ��ݏ����i���s���j
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="guideDivCode">�K�C�h�敪</param>
		/// <param name="guideCode">�K�C�h�R�[�h</param>
		/// <param name="getDataType">�擾�Ώۃe�[�u���敪</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private int ReadBodyProc(out UserGdBd userGdBd, string enterpriseCode, int guideDivCode, int guideCode, UserGuideAcsData getDataType)
		{
			try
			{
				userGdBd = null;
				int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		
				UserGdBdWork userGdBdWork   = new UserGdBdWork();
				userGdBdWork.UserGuideDivCd = guideDivCode;
				userGdBdWork.GuideCode		= guideCode;

				UserGdBdUWork userGdBdUWork  = new UserGdBdUWork();
				userGdBdUWork.EnterpriseCode = enterpriseCode;
				userGdBdUWork.UserGuideDivCd = guideDivCode;
				userGdBdUWork.GuideCode		 = guideCode;

				// XML�֕ϊ����A������̃o�C�i����
				byte[] offerbyte = XmlByteSerializer.Serialize(userGdBdWork);
				byte[] userbyte  = XmlByteSerializer.Serialize(userGdBdUWork);

				switch (getDataType)
				{
					case (UserGuideAcsData.OfferBodyData) :
					{
						// ���[�U�[�K�C�h�i�{�f�B�j�ǂݍ���
                        
                        // ----- iitani c ---------- start 2007.05.22
                        //status = this._iUserGdBdDB.Read(ref offerbyte, 0);
                        status = this._userGdBdLcDB.Read(ref userGdBdWork, 0);
                        // ----- iitani c ---------- end 2007.05.22
                        
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// XML�̓ǂݍ���
							userGdBdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(offerbyte, typeof(UserGdBdWork));
							// �N���X�������o�R�s�[
							userGdBd = CopyToUserGdBdFromUserGdBdWork(userGdBdWork);
						}
						return status;
					}
					case (UserGuideAcsData.UserBodyData) :
					{
						// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�ǂݍ���
						status = this._iUserGdBdUDB.Read(ref userbyte, 0);

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// XML�̓ǂݍ���
							userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(userbyte, typeof(UserGdBdUWork));
							// �N���X�������o�R�s�[
							userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
						}
						return status;
					}
					case (UserGuideAcsData.MergeBodyData) :
					{
						// ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�ǂݍ���
						status = this._iUserGdBdUDB.Read(ref userbyte, 0);

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// XML�̓ǂݍ���
							userGdBdUWork = (UserGdBdUWork)XmlByteSerializer.Deserialize(userbyte, typeof(UserGdBdUWork));
							// �N���X�������o�R�s�[
							userGdBd = CopyToUserGdBdFromUserGdBdUWork(userGdBdUWork);
							break;
						}
						
						// ���[�U�[�K�C�h�i�{�f�B�j�ǂݍ���
                        // 2008.06.16 upd start ---------------------------------->>
                        // ----- iitani c ---------- start 2007.05.22
                        status = this._iUserGdBdDB.Read(ref offerbyte, 0);
                        //status = this._userGdBdLcDB.Read(ref userGdBdWork, 0);
                        // ----- iitani c ---------- end 2007.05.22
                        // 2008.06.16 upd end ------------------------------------<<

						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							// XML�̓ǂݍ���
							userGdBdWork = (UserGdBdWork)XmlByteSerializer.Deserialize(offerbyte, typeof(UserGdBdWork));
							// �N���X�������o�R�s�[
							userGdBd = CopyToUserGdBdFromUserGdBdWork(userGdBdWork);
							break;
						}
						
						if (userGdBd != null)
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}

						break;
					}
				}
				return status;
			}
			catch (Exception)
			{
				// �ʐM�G���[��-1��߂�
				userGdBd = null;
				// �I�t���C������null���Z�b�g
				//this._iUserGdBdDB  = null;  // iitani d 2007.05.22
				this._iUserGdBdUDB = null;
				return -1;
			}
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�U�[�K�C�h�i�w�b�_�j���[�N�N���X�˃��[�U�[�K�C�h�i�w�b�_�j�N���X�j
		/// </summary>
		/// <param name="userGdHdWork">���[�U�[�K�C�h�i�w�b�_�j���[�N�N���X</param>
		/// <returns>���[�U�[�K�C�h�i�{�f�B�j�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�w�b�_�j���[�N�N���X���烆�[�U�[�K�C�h�i�w�b�_�j�N���X�փ����o�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private UserGdHd CopyToUserGdHdFromUserGdHdWork(UserGdHdWork userGdHdWork)
		{
			UserGdHd userGdHd = new UserGdHd();

			userGdHd.CreateDateTime		= userGdHdWork.CreateDateTime;
			userGdHd.UpdateDateTime		= userGdHdWork.UpdateDateTime;
			userGdHd.LogicalDeleteCode	= userGdHdWork.LogicalDeleteCode;

			userGdHd.UserGuideDivCd		= userGdHdWork.UserGuideDivCd;
			userGdHd.UserGuideDivNm		= userGdHdWork.UserGuideDivNm;
			userGdHd.MasterOfferCd		= userGdHdWork.MasterOfferCd;

			return userGdHd;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�U�[�K�C�h�i�w�b�_�j�N���X�˃��[�U�[�K�C�h�i�w�b�_�j���[�N�N���X�j
		/// </summary>
		/// <param name="userGdHd">���[�U�[�K�C�h�i�w�b�_�j�N���X</param>
		/// <returns>���[�U�[�K�C�h�i�w�b�_�j�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�w�b�_�j���[�N�N���X���烆�[�U�[�K�C�h�i�w�b�_�j�N���X�փ����o�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private UserGdHdWork CopyToUserGdHdWorkFromUserGdHd(UserGdHd userGdHd)
		{
			UserGdHdWork userGdHdWork = new UserGdHdWork();

			userGdHdWork.CreateDateTime		= userGdHd.CreateDateTime;
			userGdHdWork.UpdateDateTime		= userGdHd.UpdateDateTime;
			userGdHdWork.LogicalDeleteCode	= userGdHd.LogicalDeleteCode;

			userGdHdWork.UserGuideDivCd		= userGdHd.UserGuideDivCd;
			userGdHdWork.UserGuideDivNm		= userGdHd.UserGuideDivNm;
			userGdHdWork.MasterOfferCd		= userGdHd.MasterOfferCd;

			return userGdHdWork;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�U�[�K�C�h�i�{�f�B�j���[�N�N���X�˃��[�U�[�K�C�h�i�{�f�B�j�N���X�j
		/// </summary>
		/// <param name="userGdBdWork">���[�U�[�K�C�h�i�{�f�B�j���[�N�N���X</param>
		/// <returns>���[�U�[�K�C�h�i�{�f�B�j�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���[�N�N���X���烆�[�U�[�K�C�h�i�{�f�B�j�N���X�փ����o�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private UserGdBd CopyToUserGdBdFromUserGdBdWork(UserGdBdWork userGdBdWork)
		{
			UserGdBd userGdBd = new UserGdBd();

			userGdBd.CreateDateTime		= userGdBdWork.CreateDateTime;
			userGdBd.UpdateDateTime		= userGdBdWork.UpdateDateTime;
			userGdBd.FileHeaderGuid		= Guid.NewGuid();
			userGdBd.LogicalDeleteCode	= userGdBdWork.LogicalDeleteCode;

			userGdBd.UserGuideDivCd		= userGdBdWork.UserGuideDivCd;
			userGdBd.GuideCode			= userGdBdWork.GuideCode;
			userGdBd.GuideName			= userGdBdWork.GuideName;
			userGdBd.GuideType			= userGdBdWork.GuideType;

			return userGdBd;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j���[�N�N���X�˃��[�U�[�K�C�h�i�{�f�B�j�N���X�j
		/// </summary>
		/// <param name="userGdBdUWork">���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j���[�N�N���X</param>
		/// <returns>���[�U�[�K�C�h�i�{�f�B�j�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j���[�N�N���X����
		///					 ���[�U�[�K�C�h�i�{�f�B�j�N���X�փ����o�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.12</br>
		/// </remarks>
		private UserGdBd CopyToUserGdBdFromUserGdBdUWork(UserGdBdUWork userGdBdUWork)
		{
			UserGdBd userGdBd = new UserGdBd();

			userGdBd.CreateDateTime		= userGdBdUWork.CreateDateTime;
			userGdBd.UpdateDateTime		= userGdBdUWork.UpdateDateTime;
			userGdBd.EnterpriseCode		= userGdBdUWork.EnterpriseCode;
			userGdBd.FileHeaderGuid		= userGdBdUWork.FileHeaderGuid;
			userGdBd.LogicalDeleteCode	= userGdBdUWork.LogicalDeleteCode;

			userGdBd.UserGuideDivCd		= userGdBdUWork.UserGuideDivCd;
			userGdBd.GuideCode			= userGdBdUWork.GuideCode;
			userGdBd.GuideName			= userGdBdUWork.GuideName;
			userGdBd.GuideType			= userGdBdUWork.GuideType;

			return userGdBd;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�U�[�K�C�h�i�{�f�B�j�N���X�˃��[�U�[�K�C�h�i�{�f�B�j���[�N�N���X�j
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>	 
		/// <returns>���[�U�[�K�C�h�i�{�f�B�j�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���[�N�N���X���烆�[�U�[�K�C�h�i�{�f�B�j�N���X�փ����o�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 21027 �{��  ���u�Y</br>
		/// <br>Date       : 2005.04.18</br>
		/// </remarks>
		private UserGdBdWork CopyToUserGdBdWorkFromUserGdBd(UserGdBd userGdBd)
		{
			UserGdBdWork userGdBdWork = new UserGdBdWork();

			userGdBdWork.CreateDateTime		= userGdBd.CreateDateTime;
			userGdBdWork.UpdateDateTime		= userGdBd.UpdateDateTime;
			userGdBdWork.LogicalDeleteCode	= userGdBd.LogicalDeleteCode;

			userGdBdWork.UserGuideDivCd		= userGdBd.UserGuideDivCd;
			userGdBdWork.GuideCode			= userGdBd.GuideCode;
			userGdBdWork.GuideName			= userGdBd.GuideName.TrimEnd();
			userGdBdWork.GuideType			= userGdBd.GuideType;

			return userGdBdWork;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���[�U�[�K�C�h�i�{�f�B�j�N���X�˃��[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j���[�N�N���X�j
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>	 
		/// <returns>���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j���[�N�N���X����
		///					 ���[�U�[�K�C�h�i�{�f�B�j�i���[�U�[�j�N���X�փ����o�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.12</br>
		/// </remarks>
		private UserGdBdUWork CopyToUserGdBdUWorkFromUserGdBd(UserGdBd userGdBd)
		{
			UserGdBdUWork userGdBdUWork = new UserGdBdUWork();

			userGdBdUWork.CreateDateTime	= userGdBd.CreateDateTime;
			userGdBdUWork.UpdateDateTime	= userGdBd.UpdateDateTime;
			userGdBdUWork.EnterpriseCode	= userGdBd.EnterpriseCode;
			userGdBdUWork.FileHeaderGuid	= userGdBd.FileHeaderGuid;
			userGdBdUWork.LogicalDeleteCode	= userGdBd.LogicalDeleteCode;

			userGdBdUWork.UserGuideDivCd	= userGdBd.UserGuideDivCd;
			userGdBdUWork.GuideCode			= userGdBd.GuideCode;
			userGdBdUWork.GuideName			= userGdBd.GuideName.TrimEnd();
			userGdBdUWork.GuideType			= userGdBd.GuideType;

			return userGdBdUWork;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�N���X �� UI�N���X�ϊ�����
		/// </summary>
		/// <param name="userGdBd">���[�U�[�K�C�h�i�{�f�B�j�N���X</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�N���X��Static�������ɕێ����܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void CopyToStaticFromDataClass(UserGdBd userGdBd)
		{
			// HashKey : �敪�R�[�h�{�K�C�h�R�[�h
			string hashKey = userGdBd.UserGuideDivCd + "_" + userGdBd.GuideCode;

			UserGdBd wkUserGdBd = new UserGdBd();

			wkUserGdBd.CreateDateTime		= userGdBd.CreateDateTime;
			wkUserGdBd.UpdateDateTime		= userGdBd.UpdateDateTime;
			wkUserGdBd.LogicalDeleteCode	= userGdBd.LogicalDeleteCode;

			wkUserGdBd.UserGuideDivCd		= userGdBd.UserGuideDivCd;
			wkUserGdBd.GuideCode			= userGdBd.GuideCode;
			wkUserGdBd.GuideName			= userGdBd.GuideName;
			wkUserGdBd.GuideType			= userGdBd.GuideType;
				
			_userGdBdTable_Stc[hashKey] = wkUserGdBd;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j���[�J�[�N���X �� UI�N���X�ϊ�����
		/// </summary>
		/// <param name="userGdBdUWork">���[�U�[�K�C�h�i�{�f�B�j���[�J�[�N���X</param>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�N���X��Static�������ɕێ����܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void CopyToStaticFromWork(UserGdBdUWork userGdBdUWork)
		{
			// HashKey : �敪�R�[�h�{�K�C�h�R�[�h
			string hashKey = userGdBdUWork.UserGuideDivCd + "_" + userGdBdUWork.GuideCode;

			UserGdBd wkUserGdBd = new UserGdBd();

			wkUserGdBd.CreateDateTime		= userGdBdUWork.CreateDateTime;
			wkUserGdBd.UpdateDateTime		= userGdBdUWork.UpdateDateTime;
			wkUserGdBd.FileHeaderGuid		= userGdBdUWork.FileHeaderGuid;
			wkUserGdBd.LogicalDeleteCode	= userGdBdUWork.LogicalDeleteCode;

			wkUserGdBd.UserGuideDivCd		= userGdBdUWork.UserGuideDivCd;
			wkUserGdBd.GuideCode			= userGdBdUWork.GuideCode;
			wkUserGdBd.GuideName			= userGdBdUWork.GuideName;
			wkUserGdBd.GuideType			= userGdBdUWork.GuideType;
				
			_userGdBdTable_Stc[hashKey] = wkUserGdBd;
		}

		/// <summary>
		/// ���[�J���t�@�C���Ǎ��ݏ���
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�J���t�@�C����Ǎ���ŁA����Static�ɕێ����܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void SearchOfflineData()
		{
			// �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

			// KeyList�ݒ�
			string[] userGdBdKeys = new string[1];
			userGdBdKeys[0] = LoginInfoAcquisition.EnterpriseCode;
			// ���[�J���t�@�C���Ǎ��ݏ���
			object wkObj = offlineDataSerializer.DeSerialize("UserGuideAcs", userGdBdKeys);
			// ArrayList�ɃZ�b�g
			ArrayList wkList = wkObj as ArrayList;

			if ((wkList != null ) &&
				(wkList.Count != 0))
			{
				foreach (UserGdBdUWork userGdBdUWork in wkList)
				{
					// ���[�U�[�K�C�h�i�{�f�B�j���[�J�[�N���X �� Static�ϊ�����
					CopyToStaticFromWork(userGdBdUWork);
				}
			}
		}

		/// <summary>
		/// ���ǔ���
		/// </summary>
		/// <param name="userGuideDivCd">�K�C�h�敪</param>
		/// <returns>���ǔ���[true:���ǋ敪, false:���ǋ敪]</returns>
		/// <remarks>�w��K�C�h�敪�ɂ��ă����[�g���s�������ǂ������肵�ĕԂ��܂��B</remarks>
		private bool ReadCheck(int userGuideDivCd)
		{
			foreach (int ix in _staticReadMngList)
			{
				if (ix == userGuideDivCd)
				{
					return true;
				}
			}

			return false;
		}
		#endregion

		#region SearchGuideBuf
///////////////////////////////////////////////////////////////////// 2005.12.03 AKIYAMA ADD STA //
		/// <summary>
		/// �K�C�h���̎擾�i�{�f�B�j
		/// </summary>
		/// <param name="guideName">�K�C�h����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="userGuideDiv">���[�U�[�K�C�h�敪</param>
		/// <param name="guideCode">�K�C�h�R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�敪�E�K�C�h�R�[�h����K�C�h���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.12.03</br>
		/// </remarks>
		public int GetGuideName( out string guideName, string enterpriseCode, int userGuideDiv, int guideCode )
		{
			int status = 0;
			guideName = "";

			try {
				// �G���g���p���[�U�[�o�b�t�@������ꍇ�͂����炩��ǂ����I
				if( ( _userGdBdEntryTable != null ) && ( _userGdBdEntryTable.Count > 0 ) )
				{
					string key = userGuideDiv.ToString() + "_" + guideCode.ToString();
					if( _userGdBdEntryTable[key] != null )
					{
						guideName = ( (UserGdBdU)_userGdBdEntryTable[key]).GuideName;
						return 0;
					}
					else
					{
						guideName = "���o�^";
						return 4;
					}
				}

				if (!ReadCheck(userGuideDiv))
				{
					status = GetUserGdBdBuffer(enterpriseCode, userGuideDiv);
					if( status != ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
						guideName = "���o�^";
						return status;
					}
				}

				// �L���b�V���p�n�b�V���e�[�u���擾
				Hashtable wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGuideDiv ];

				// ��ƁE���i�敪�����݂���
				if( wkUserGdBdTable.ContainsKey( guideCode ) == true ) {
					UserGdBd userGdBd = ( UserGdBd )wkUserGdBdTable[ guideCode ];
					
					// �_���폜����Ă��Ȃ�
					if( userGdBd.LogicalDeleteCode == 0 ) {
						guideName = userGdBd.GuideName;
					}
					// �_���폜����Ă���
					else {
						guideName = "�폜��";
					}
				}
				// ��ƁE���i�敪�����݂��Ȃ�
				else {
					guideName = "���o�^";
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
				}
			}
			catch( Exception ) {
				guideName = "���o�^";
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�K�C�h�p�L���b�V����������
		/// </summary>
		/// <param name="retList">�������ʃ��X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �K�C�h�p��Static�L���b�V�����烆�[�U�[�K�C�h�i�{�f�B�j�̌������s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.12.02</br>
		/// </remarks>
		public int SearchGuideBufStaticMemory( out ArrayList retList, string enterpriseCode, int userGuideDivCd )
		{
			return SearchGuideBufStaticMemoryProc( out retList, enterpriseCode, userGuideDivCd );
		}
		
		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�K�C�h�\���f�[�^�擾
		/// </summary>
		/// <param name="retList">�������ʃ��X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �K�C�h�ɕ\�����郆�[�U�[�K�C�h�i�{�f�B�j�f�[�^���擾����</br>
		/// <br>Programmer : 99032 �ɓ� ���I</br>
		/// <br>Date       : 2005.06.08</br>
		/// </remarks>
		private int SearchGuideBufStaticMemoryProc( out ArrayList retList, string enterpriseCode, int userGuideDivCd )
		{
			int status = 0;
			retList = new ArrayList();
		
			try 
			{
				if (!ReadCheck(userGuideDivCd))
				{
					status = GetUserGdBdBuffer(enterpriseCode, userGuideDivCd);

					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						return status;
					}
				}

				if (_guideBufUserGdBd.ContainsKey(userGuideDivCd) == false)
				{
					return (int)ConstantManagement.DB_Status.ctDB_EOF;
				}

				// �L���b�V���p�n�b�V���e�[�u���擾
				Hashtable wkUserGdBdTable = (Hashtable)_guideBufUserGdBd[userGuideDivCd];

				foreach (UserGdBd userGdBd in wkUserGdBdTable.Values) 
				{
					if (userGdBd.LogicalDeleteCode == 0)
					{
						retList.Add(userGdBd.Clone());
					}
				}
				retList.Sort(new UserGdBdCompare());

				if (retList.Count > 0)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
			}
			catch (Exception)
			{
				status = -1;
			}

			return status;
		}
		
		/// <summary>
		/// �K�C�h�p���[�U�[�K�C�h�i�{�f�B�j�o�b�t�@�擾
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="userGuideDivCd">���[�U�[�K�C�h�敪</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �K�C�h�p�o�b�t�@�G���A�Ƀ��[�U�[�K�C�h�i�{�f�B�j�����擾���܂�</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.12.03</br>
		/// </remarks>
		private int GetUserGdBdBuffer( string enterpriseCode, int userGuideDivCd )
		{
			int status = 0;

			try 
			{
				if (_guideBufUserGdBd == null)
				{
					_guideBufUserGdBd = new Hashtable();
				}

				ArrayList userGdBds = null;
				status = this.SearchAllDivCodeBody( out userGdBds, enterpriseCode, userGuideDivCd, UserGuideAcsData.OfferDivCodeMergeBodyData );

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					if( userGdBds.Count > 0 ) {
						foreach( UserGdBd userGdBd in userGdBds ) {
							Hashtable wkUserGdBdTable = null;
							// ��ƁE���i��ʂ��L���b�V���ɖ��o�^
							if( _guideBufUserGdBd.ContainsKey( userGdBd.UserGuideDivCd ) == false ) {
								// �C���X�^���X�𐶐����A�o�^
								wkUserGdBdTable = new Hashtable();
								_guideBufUserGdBd.Add( userGdBd.UserGuideDivCd, wkUserGdBdTable );
								wkUserGdBdTable.Clear();
							}
							// ��ƁE���i��ʂ��L���b�V���ɓo�^��
							else {
								wkUserGdBdTable = ( Hashtable )_guideBufUserGdBd[ userGdBd.UserGuideDivCd ];
							}
							wkUserGdBdTable.Add( userGdBd.GuideCode, userGdBd.Clone() );
						}
					}
					else {
						status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
					}
				}

				_staticReadMngList.Add(userGuideDivCd);
			}
			catch( Exception ) {
				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�i�{�f�B�j�I�u�W�F�N�g��r�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̔�r���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2005.12.03</br>
		/// </remarks>
		public class UserGdBdCompare : IComparer
		{
			#region IComparer �����o

			/// <summary>
			/// ���[�U�[�K�C�h�i�{�f�B�j�I�u�W�F�N�g��r���\�b�h
			/// </summary>
			/// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
			/// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
			/// <returns>��r����</returns>
			/// <remarks>
			/// <br>Note       : ���[�U�[�K�C�h�i�{�f�B�j�̔�r���s���܂��B</br>
			/// <br>Programmer : 23001 �H�R�@����</br>
			/// <br>Date       : 2005.12.03</br>
			/// </remarks>
			public int Compare(object x, object y)
			{
				UserGdBd userGdBd1 = ( UserGdBd )x;
				UserGdBd userGdBd2 = ( UserGdBd )y;

				if( userGdBd1.UserGuideDivCd != userGdBd2.UserGuideDivCd ) {
					return userGdBd1.UserGuideDivCd.CompareTo( userGdBd2.UserGuideDivCd );
				}

				return userGdBd1.GuideCode.CompareTo( userGdBd2.GuideCode );
			}

			#endregion

		}

// 2005.12.03 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
		#endregion

        // ----- iitani a start ---------- 2007.05.22
        #region ���K�C�h�N������
        /// <summary>
        /// ���i�啪�ރ}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="lgoodsganre">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: ���i�啪�ރ}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 980023 �ђJ  �k��</br>
        /// <br>Date		: 2006.12.04</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out UserGdHd userGdHd, out UserGdBd userGdBd, int userGuideDivCd)
        {
            int status = -1;
            userGdBd = new UserGdBd();
            userGdHd = new UserGdHd();
            string xmlName = "";

            if (userGuideDivCd == 0)
            {
                xmlName = "USERGUIDEKTNGUIDEPARENT.XML";
            }
            else
            {
                xmlName = "USERGUIDEGUIDEPARENT.XML";
            }

            TableGuideParent tableGuideParent = new TableGuideParent(xmlName);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("UserGuideDivCd", userGuideDivCd);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                if (userGuideDivCd == 0)
                {
                    // ���[�U�[�K�C�h(�w�b�_)
                    string strHdCode = retObj["UserGuideDivCd"].ToString();
                    userGdHd.UserGuideDivCd = int.Parse(strHdCode);
                    userGdHd.UserGuideDivNm = retObj["UserGuideDivNm"].ToString();
                }

                // ���[�U�[�K�C�h(�{�f�B)
                string strBdCode = retObj["GuideCode"].ToString();
                userGdBd.GuideCode = int.Parse(strBdCode);
                userGdBd.GuideName = retObj["GuideName"].ToString();

                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }
        # endregion


        #region ��IGeneralGuidData Method
        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: 980023 �ђJ  �k��</br>
        /// <br>Date		: 2006.12.04</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";
            int userGuideDivCd = 0;

            // ���[�U�[�K�C�h�敪�ݒ�L��(�w�b�_�A�{�f�B�̌Ăѕ����ɂ��g�p)
            if (inParm.ContainsKey("UserGuideDivCd"))
            {
                // ��ƃR�[�h�ݒ�L��
                if (inParm.ContainsKey("EnterpriseCode"))
                {
                    if (inParm["EnterpriseCode"].ToString() != "")
                    {
                        enterpriseCode = inParm["EnterpriseCode"].ToString();
                    }
                    else
                    {
                        // ����ƃR�[�h�������I�ɓ����
                        enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    }
                }
                // ��ƃR�[�h�ݒ薳��
                else
                {
                    // �L�蓾�Ȃ��̂ŃG���[
                    return status;
                }

                object userGuideDivCdObj = inParm["UserGuideDivCd"];
                userGuideDivCd = int.Parse(userGuideDivCdObj.ToString());

                // ���[�U�[�K�C�h�}�X�^(Body)�e�[�u���Ǎ���(���[�J��DB) 
                //status = SearchLocalBody(ref guideList, enterpriseCode, userGuideDivCd); // 2008.06.16 del
                status = SearchGuidBody(ref guideList, enterpriseCode, userGuideDivCd);    // 2008.06.16 add �T�[�o���Q�Ƃ���
            }
            else
            {
                // ���[�U�[�K�C�h�}�X�^(Header)�e�[�u���Ǎ���(���[�J��DB) 
                status = SearchHeader(ref guideList);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }
        #endregion
        // ----- iitani a end ---------- 2007.05.22

        /// <summary>
        /// ���[�U�[�K�C�h(�{�f�B)��r�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h(�{�f�B)��r�N���X</br>
        /// <br>Programmer : 980023 �ђJ �k��</br>
        /// <br>Date       : 2008.01.09</br>
        /// </remarks>
        public class UserGdBdUCompare : System.Collections.IComparer
        {
            /// <summary>
            /// ���[�U�[�K�C�h(�{�f�B)��r�N���X
            /// </summary>
            public int Compare(object x, object y)
            {
                int result = 0;

                UserGdBdUWork cx = (UserGdBdUWork)x;
                UserGdBdUWork cy = (UserGdBdUWork)y;

                //���[�U�[�K�C�h�敪�R�[�h
                if (result == 0)
                    result = cx.UserGuideDivCd - cy.UserGuideDivCd;

                //�K�C�h�R�[�h
                if (result == 0)
                    result = cx.GuideCode - cy.GuideCode;

                //���ʂ�Ԃ�
                return result;
            }
        }

    }
}