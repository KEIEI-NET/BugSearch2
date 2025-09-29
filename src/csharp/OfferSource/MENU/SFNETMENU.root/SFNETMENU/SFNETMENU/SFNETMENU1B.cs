using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Management;
using System.Collections;
using Microsoft.Win32;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Threading;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using UBAU.Remoting;
using UBAU.Data;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���j���[�T�[�o�[���N���X
    /// <br></br>
    /// <br>Update Note: ���i�R�[�h�ǉ�</br>
    /// <br>Programmer : 23002 ��� �k��</br>
    /// <br>Date       : 2008.04.04</br>
    /// <br></br>
    /// <br>Update Note: Felica�Ή��i�]�ƈ����O�C���j</br>
    /// <br>Programmer : 23002 ��� �k��</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br></br>
    /// <br>Update Note: �w���v�y�[�W�t�q�k�擾���@�ύX�i�F�؂���擾�j</br>
    /// <br>Programmer : 23002 ��� �k��</br>
    /// <br>Date       : 2008.12.09</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή� FeliCa���O�C���I�v�V�����̑g�ݍ���</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/04/06</br>
    /// </summary>
	public class SfNetMenuServerInfo
	{
		#region �R���X�g��`(�ײ��Ļ��ްKEY)
		private const string _const_LocalAccessToken		= "LocalAccessToken";
		private const string _const_CompanyAuthInfoWork		= "CompanyAuthInfoWork";
		private const string _const_EmployeeAuthInfoWork	= "EmployeeAuthInfoWork";
		private const string _const_ClientAuthInfoWork		= "ClientAuthInfoWork";
		private const string _const_OnlineFlag				= "OnlineFlag";
        private const string _const_RequiredServerVersion   = "RequiredServerVersion";
		#endregion

		#region �R���X�g��`(���̑�)
		/// <summary>�I�t���C��html�i�[�t�H���_</summary>
		private const string _const_MenuOfflineDir			= "html";
		/// <summary>�I�t���C��Index�t�@�C��</summary>
		private const string _const_MenuOfflineIndex		= "SFNETMENUOFFLINEINDEX.html";
		#endregion

		#region �v���C�x�[�g�����o�@�T�[�o�[���
		/// <summary>���[�J���T�[�o�[�f�t�H���g�|�[�g</summary>
		private Int32 _pMCPortNo = 0;
		/// <summary>���[�J���T�[�o�[�h���C��</summary>
		private string _pMCDomain = "tcp://localhost:";
		#endregion

		#region �v���C�x�[�g�����o�@���O�C�����
		private CompanyAuthInfoWork _companyAuthInfoWork		= null;		//��Ə��
		private EmployeeAuthInfoWork _employeeAuthInfoWork		= null;		//�]�ƈ����
		private ClientAuthInfoWork _clientAuthInfoWork			= null;		//�N���C�A���g���
        //private EmployeeLoginFormAF _employeeLoginForm			= null;		//�]�ƈ����O�C�����
        private EmployeeLoginFormEx _employeeLoginForm = null;		//�]�ƈ����O�C�����
		private string _version									= null;		//���i�o�[�W����
		private string _versionPMC								= null;		//PMC�o�[�W����
		private bool _onlineFlag								= false;	//�I�����C���t���O
		private string _serverDomain							= null;		//�]�ƈ����O�C���T�[�o�[�ڑ��p�h���C��
		private string _topPage									= null;		//�g�b�v���j���[�A�h���X
		private string _companyLoginMutexKey					= null;		//��ƃ��O�C��Mutex�L�[
		private IRemoteService _remoteService					= null;		//���i�Ǘ��N���C�A���g�T�[�o�[		
		private ExclusionService _exclusionService				= null;		//��ƃ��O�C��Mutex�`�F�b�N�p		
		private event System.EventHandler _applicationReleased	= null;		//Menu�j���Ăяo���p
        private Int32 _requiredServerVersion                    = -1;       //�T�[�o�[�o�[�W������r�p

        // --- DEL m.suzuki 2010/04/06 ---------->>>>>
        //// 2008.12.09 UENO ADD STA
        //private string _helpPage                                = null;		//�w���v�y�[�W�A�h���X
        //// 2008.12.09 UENO ADD END
        // --- DEL m.suzuki 2010/04/06 ----------<<<<<
        // --- ADD m.suzuki 2009/00/00 ---------->>>>>
        private static Dictionary<string, object> _ServerVersionTable = null;
        // --- ADD m.suzuki 2009/00/00 ----------<<<<<

		#endregion

        #region �v���C�x�[�g�����o �A�h�I�����
        //�������������� 2007.03.23 ADD ��� ����������������
        private SfNetMenuAddOnInfo _sfNetMenuAddOnInfo = null;
        //�������������� 2007.03.23 ADD ��� ����������������
        #endregion

        #region �v���p�e�B
        /// <summary>
		/// ���[�J���T�[�o�[�f�t�H���g�|�[�g �v���p�e�B
		/// </summary>
		public Int32 PMCPortNo
		{
			set{_pMCPortNo = value;}
			get{return _pMCPortNo ;}
		}
		
		/// <summary>
		/// ���[�J���T�[�o�[�h���C�� �v���p�e�B
		/// </summary>
		public string PMCDomain
		{
			get{return _pMCDomain ;}
		}

		/// <summary>
		/// ���i�o�[�W���� �v���p�e�B
		/// </summary>
		public string Version
		{
			get{return _version;}
		}

		/// <summary>
		/// �I�����C���t���O �v���p�e�B
		/// </summary>
		public bool OnlineFlag
		{
			get{return _onlineFlag ;}
		}

		/// <summary>
		/// �I�����C��Text �v���p�e�B
		/// </summary>
		public string OnlineText
		{
			get{ if(_onlineFlag) return "Online";
				 else			 return "Offline";}
		}


		/// <summary>
		/// ���O�C���t���O
		/// </summary>
		public bool LoginFlag
		{
			//�~���[�e�b�N�X�̗L���Ń��O�C����Ԃ�߂�
			get{if (_employeeAuthInfoWork != null)	return true;
				else								return false;}
		}

		/// <summary>
		/// �g�b�v�y�[�W�A�h���X
		/// </summary>
		public string TopPage
		{
			get{return _topPage;}
		}

		/// <summary>
		/// �A�N�Z�X�`�P�b�g
		/// </summary>
		public string AccessTicket
		{
			get{if (_companyAuthInfoWork != null)	return _companyAuthInfoWork.AccessTicket;
				else								return "";}
		}

		/// <summary>
		/// ��ƃ��O�C�����
		/// </summary>
		public CompanyAuthInfoWork CompanyAuthInfoWork
		{
			get{return _companyAuthInfoWork;}
		}

		/// <summary>
		/// ���O�C���]�ƈ�����
		/// </summary>
		public string EmployeeName
		{
			get
			{
				if (_employeeAuthInfoWork == null ||
					_employeeAuthInfoWork.EmployeeWork == null) return "�����O�C��";
				else											return _employeeAuthInfoWork.EmployeeWork.Name;
			}
		}
        // 2008.04.04 UENO ADD STA
        /// <summary>
        /// ���i�R�[�h
        /// </summary>
        public string ProductCode
        {
            get
            {
                if( _companyAuthInfoWork != null && _companyAuthInfoWork.ProductInfoWork != null )
                    return _companyAuthInfoWork.ProductInfoWork.ProductCode;
                else
                    // --- UPD m.suzuki 2010/04/06 ---------->>>>>
                    //return "Superfrontman";
                    return "Partsman";
                    // --- UPD m.suzuki 2010/04/06 ----------<<<<<
            }
        }
        // 2008.04.04 UENO ADD END
		/// <summary>
		/// ���i����
		/// </summary>
		public string ProductName
		{
			get
			{
				if (_companyAuthInfoWork != null && _companyAuthInfoWork.ProductInfoWork != null)	return _companyAuthInfoWork.ProductInfoWork.ProductName;
                // --- UPD m.suzuki 2010/04/06 ---------->>>>>
                //else																				return "Superfrontman";
				else																				return "Partsman";
                // --- UPD m.suzuki 2010/04/06 ----------<<<<<
			}
		}
		/// <summary>
		/// ���O�C���]�ƈ��R�[�h
		/// </summary>
		public string EmployeeCode
		{
			get
			{
				if (_employeeAuthInfoWork == null ||
					_employeeAuthInfoWork.EmployeeWork == null) return "";
				else											return _employeeAuthInfoWork.EmployeeWork.EmployeeCode;
			}
		}

        /// <summary>
        /// RequiredServerVersion
        /// </summary>
        public Int32 RequiredServerVersion
        {
            get { return _requiredServerVersion; }
        }

        // --- DEL m.suzuki 2010/04/06 ---------->>>>>
        //// 2008.12.09 UENO ADD STA
        ///// <summary>
        ///// �w���v�y�[�W�A�h���X
        ///// </summary>
        //public string HelpPage
        //{
        //    get { return _helpPage; }
        //    set { _helpPage = value; }
        //}
        //// 2008.12.09 UENO ADD END
        // --- DEL m.suzuki 2010/04/06 ----------<<<<<
		#endregion


		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SfNetMenuServerInfo()
		{
			//���i�Ǘ��N���C�A���g�����[�e�B���O�ڑ��p�|�[�g�ԍ��擾
			_pMCPortNo	= GetPMCPorNo();
			//�v���_�N�g�z�M�o�[�W�������擾
			_version	= GetProductVersion(ConstantManagement_SF_PRO.ProductCode);
			_versionPMC	= GetProductVersion("PMC");
			//���i�Ǘ��N���C�A���g�Ɋ�ƃ��O�C�������擾���ɂ���
			_remoteService = (IRemoteService)Activator.GetObject(typeof(IRemoteService),string.Format("{0}{1}/{2}",_pMCDomain,_pMCPortNo,UBAU.Remoting.ServiceName.Name));
        }

        #region �p�u���b�N���\�b�h�i���j���[���j
        /// <summary>
		/// ��ƃ��O�C����������
		/// </summary>
		/// <remarks>���i�Ǘ��N���C�A���g�����ƃ��O�C�������擾���܂�</remarks>
		/// <param rKeyName="ProcessId">�v���Z�XID</param>
		/// <param rKeyName="retMsg">���^�[�����b�Z�[�W</param>
		/// <param rKeyName="eventHandler">��ƃ��O�I�t�C�x���g�n���h��</param>
		/// <returns>STATUS 0:��Ə]�ƈ����O�C���ς�  4:��ƃ��O�C���ς�  9:����ƃ��O�C��</returns>
		public Int32 CompanyLoginInitial(Int32 ProcessId,out string retMsg,EventHandler eventHandler)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retMsg = "";

            string[] keyData = { _const_LocalAccessToken, _const_CompanyAuthInfoWork, _const_EmployeeAuthInfoWork, _const_ClientAuthInfoWork, _const_RequiredServerVersion};
			Hashtable hash;
			string[] param;
			int remoteStatus = -1;
			try
			{
				remoteStatus = _remoteService.GetLoginInfo(ConstantManagement_SF_PRO.ProductCode,ProcessId,keyData,out param,out hash);
			}
			catch(Exception)
			{
				retMsg = "���i�Ǘ��N���C�A���g���N������ƃ��O�C�����s���Ă��������B";
				return status;
			}

			if (remoteStatus == 0)
			{
				//����Ƀ��O�C����񂪎擾�o���Ȃ������ꍇ��
				if (param == null || param.Length == 0)
				{
					retMsg = "���i�Ǘ��N���C�A���g�ɂĊ�ƃ��O�C�����s���Ă��������B";
					return status;
				}
				//�p�����[�^�����N���X�ɓW�J
				try
				{
					GetPara(param);
				}
				catch(Exception ex)
				{
					retMsg = ex.Message;
					return status;
				}

				//��Ə��AccessToken���������Ă��Ȃ��ꍇ�ɂ͊�Ə���SF�p�N���X�ɃR�s�[���ۑ�
				//��ƃ��O�C�������擾
				LocalAccessToken	token					= null;
				byte[]				bCompanyAuthInfoWork	= null;
				byte[]				bEmployeeAuthInfoWork	= null;
				byte[]				bClientAuthInfoWork		= null;
                Int32               requiredServerVersion   = -1;
				if (hash.ContainsKey(_const_LocalAccessToken))		token					= hash[_const_LocalAccessToken]		as LocalAccessToken;
				if (hash.ContainsKey(_const_CompanyAuthInfoWork))	bCompanyAuthInfoWork	= hash[_const_CompanyAuthInfoWork]	as byte[];
				if (hash.ContainsKey(_const_EmployeeAuthInfoWork))	bEmployeeAuthInfoWork	= hash[_const_EmployeeAuthInfoWork]	as byte[];
				if (hash.ContainsKey(_const_ClientAuthInfoWork))	bClientAuthInfoWork		= hash[_const_ClientAuthInfoWork]	as byte[];
                if (hash.ContainsKey(_const_RequiredServerVersion)) requiredServerVersion   = (Int32)hash[_const_RequiredServerVersion];

				//����Ƀg�[�N�����擾�o�����ꍇ
				if (token != null)
				{
					ArrayList setDataKey	= new ArrayList();
					ArrayList setDataValue	= new ArrayList();
					//�g�[�N�����擾�o�����Ƃ������Ƃ͍Œ����ƔF�؂͏I�����Ă���iSTATUS=4���Z�b�g�j
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					//��Ə�񂪊��Ɋi�[����Ă���ꍇ
					if (bCompanyAuthInfoWork != null)
					{
						//�i�[��Ə����R�s�[
						_companyAuthInfoWork = CustomFormatterDeSerialize(bCompanyAuthInfoWork,typeof(CompanyAuthInfoWork)) as CompanyAuthInfoWork;
						if (_companyAuthInfoWork == null)
						{
							throw new Exception( "��ƃ��O�C�����\���ɃG���[���o�܂����B�N���C�A���g�����s���ł��B",null);
						}
					}
					else 
					{
						//��ƃ��O�C������TOKEN����ݒ�
						_companyAuthInfoWork = MakeCompanyAuthInfoWork(token);
						setDataKey.Add(_const_CompanyAuthInfoWork);
						object oCompanyAuthInfoWork = CustomFormatterSerialize(_companyAuthInfoWork);
						if (oCompanyAuthInfoWork != null) setDataValue.Add(oCompanyAuthInfoWork);
						else
						{
							throw new Exception( "��ƃ��O�C�����\���ɃG���[���o�܂����B�N���C�A���g�����s���ł��B",null);
						}
					}
					//�]�ƈ����O�C���ڑ��h���C���擾
                    // --- UPD m.suzuki 2010/04/06 ---------->>>>>
                    //// 2008.12.09 UENO ADD STA
                    ////if (MakeServerDomain(_companyAuthInfoWork,_onlineFlag,out _serverDomain,out _topPage) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //if( MakeServerDomain(_companyAuthInfoWork, _onlineFlag, out _serverDomain, out _topPage, out _helpPage) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    //// 2008.12.09 UENO ADD END
                    if (MakeServerDomain(_companyAuthInfoWork,_onlineFlag,out _serverDomain,out _topPage) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // --- UPD m.suzuki 2010/04/06 ----------<<<<<
					{
						retMsg = "��ƔF�؏�񂩂�T�[�o�[�ڑ���񂪎擾�o���܂���ł����B";
						return status;
					}

					//�]�ƈ����O�C����񂪎擾�o�����ꍇ
					//�]�ƈ����O�C������ݒ�
					if (bEmployeeAuthInfoWork != null)
					{
						_employeeAuthInfoWork = CustomFormatterDeSerialize(bEmployeeAuthInfoWork,typeof(EmployeeAuthInfoWork)) as EmployeeAuthInfoWork;
						if (_employeeAuthInfoWork == null)
						{
							throw new Exception( "�]�ƈ����O�C�����\���ɃG���[���o�܂����B�N���C�A���g�����s���ł��B",null);
						}
						//�]�ƈ���񂪃��O�C����񂩂�擾�o����ꍇ�ɂ͏]�ƈ����O�C���ς�
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

						//�]�ƈ����O�C����񂪎擾�o�����ꍇ�̂݃N���C�A���g�����擾
						if (bClientAuthInfoWork != null) 
						{
							_clientAuthInfoWork = CustomFormatterDeSerialize(bClientAuthInfoWork,typeof(ClientAuthInfoWork)) as ClientAuthInfoWork;
							if (_clientAuthInfoWork == null)
							{
								//�擾�o���Ȃ��ꍇ�i���肦�Ȃ����Ď擾�j
								_clientAuthInfoWork = MakeClientAuthInfoWork();
								setDataKey.Add(_const_ClientAuthInfoWork);
								object oClientAuthInfoWork = CustomFormatterSerialize(_clientAuthInfoWork);
								setDataValue.Add(oClientAuthInfoWork);
							}
						}
							//�擾�o���Ȃ��ꍇ�i���肦�Ȃ����Ď擾�j
						else
						{
							_clientAuthInfoWork = MakeClientAuthInfoWork();
							setDataKey.Add(_const_ClientAuthInfoWork);
							object oClientAuthInfoWork = CustomFormatterSerialize(_clientAuthInfoWork);
							setDataValue.Add(oClientAuthInfoWork);
						}
					}
                    //�����[�g�T�[�o�[�o�[�W�������擾�o���Ȃ��ꍇ�擾
                    if (requiredServerVersion == -1)
                    {
                        _requiredServerVersion = GetRequiredServerVersion();
                        //�擾�o���Ȃ��ꍇ�G���[
                        if (_requiredServerVersion == -1)
                        {
                            throw new Exception("�N���C�A���g���������C���X�g�[������Ă��܂���B�N���C�A���g���̊m�F���s���Ă��������B", null);
                        }
                        else
                        {
                            setDataKey.Add(_const_RequiredServerVersion);
                            setDataValue.Add(_requiredServerVersion);
                        }
                    }
                    else _requiredServerVersion = requiredServerVersion;
                    //�����[�e�B���O����M�p�o�[�W�����Ƃ��ăZ�b�g
                    if (_requiredServerVersion != -1) LoginInfoAcquisition.SetRequiredServerVersion(_requiredServerVersion);

					//����擾������ƃ��O�C���������[�N�N���X�Ƃ��ăT�[�o�[�o�^
					if (setDataKey.Count > 0)
					{
						try
						{
							//�I�����C���t���O�����킹�ăZ�b�g����
							setDataKey.Add(_const_OnlineFlag);
							setDataValue.Add(_onlineFlag);

							//�����[�g�T�[�o�[�֏�������
							_remoteService.SetData(_companyAuthInfoWork.AccessTicket,(string[])setDataKey.ToArray(typeof(string)),(object[])setDataValue.ToArray(typeof(object)));
						}
						catch(Exception ex)
						{
							retMsg = ex.Message;
							status = (int)ConstantManagement.DB_Status.ctDB_EOF;
							return status;
						}
					}
				}
				else
				{
					retMsg = "���i�Ǘ��N���C�A���g�ɂĊ�ƃ��O�C�����s���Ă��������B";
				}
			}

			//��ƃ��O�C���ς݂̏ꍇ
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				//�~���[�e�b�N�X�`�F�b�NWait��������Ȃ������ꍇ�͊�ƃ��O�C�����ĂȂ����̂Ƃ݂Ȃ�
				if (MutexStartCheck(out retMsg,_companyLoginMutexKey,eventHandler) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					_companyAuthInfoWork	= null;
					_employeeAuthInfoWork	= null;
					_clientAuthInfoWork		= null;
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
			}

			return status;
		}

		/// <summary>
		/// �]�ƈ����O�C��
		/// </summary>
		/// <param rKeyName="owner">�_�C�A���OForm�I�[�i�[</param>
		/// <param rKeyName="retMsg">���^�[�����b�Z�[�W</param>
		/// <returns>����</returns>
		public bool EmployeeLogin(System.Windows.Forms.IWin32Window owner,out string retMsg)
		{
			retMsg = "";

            // 2008.11.14 UENO ADD STA
			//�]�ƈ����O�C����ʐ���
            //if (_employeeLoginForm == null) _employeeLoginForm = new EmployeeLoginFormAF();
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            //if( _employeeLoginForm == null && (int)Program._sfNetMenuServerInfo.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FelicaAccessService) > 0 )
            if ( _employeeLoginForm == null && (int)Program._sfNetMenuServerInfo.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_Felica ) > 0 )
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<
            {
                _employeeLoginForm = new EmployeeLoginFormEx(true);
            }
            else if( _employeeLoginForm == null)
            {
                _employeeLoginForm = new EmployeeLoginFormEx(false);
            }
            // 2008.11.14 UENO ADD END

			//�I�t���C���]�ƈ����O�C�����擾
			EmployeeAuthInfoWork wkEmployeeAuthInfoWork = MakeLoginEmployeeAuthInfoWork(_onlineFlag,_companyAuthInfoWork);
			if (!_onlineFlag && wkEmployeeAuthInfoWork == null)
			{
				retMsg = "�I�����C�����Ɉ�x�]�ƈ����O�C�����Ă��������B\r\n�]�ƈ����O�C�����т̖�����ԂŁA�I�t���C���]�ƈ����O�C���͏o���܂���B";
				return false;
			}

			//�]�ƈ����O�C����ʕ\��
			if (_employeeLoginForm.ShowDialog(owner,_companyAuthInfoWork.AccessTicket,_serverDomain, _companyAuthInfoWork, ref wkEmployeeAuthInfoWork) != 0) return false;

			//�I�����C�����̃��O�C���ł̓N���C�A���g�Ƀ��O�C���������[�J���ۑ�����
			if (_onlineFlag) MakeLoginDataEmployeeAuthInfoWork(_companyAuthInfoWork,wkEmployeeAuthInfoWork);

			//�擾�f�[�^�T�[�o�[�o�^�p
			ArrayList setDataKey	= new ArrayList();
			ArrayList setDataValue	= new ArrayList();

			//�]�ƈ����O�C������ݒ�
			_employeeAuthInfoWork = wkEmployeeAuthInfoWork;
			setDataKey.Add(_const_EmployeeAuthInfoWork);
			object oEmployeeAuthInfoWork = CustomFormatterSerialize(_employeeAuthInfoWork);
			if (oEmployeeAuthInfoWork != null) setDataValue.Add(oEmployeeAuthInfoWork);

			//�N���C�A���g�����擾
			_clientAuthInfoWork = MakeClientAuthInfoWork();
			setDataKey.Add(_const_ClientAuthInfoWork);
			object oClientAuthInfoWork = CustomFormatterSerialize(_clientAuthInfoWork);
			if (oClientAuthInfoWork != null) setDataValue.Add(oClientAuthInfoWork);

			//�ǂ��炩��null�̏ꍇ�ɂ͏]�ƈ����O�C���s��
			if (oEmployeeAuthInfoWork == null || oClientAuthInfoWork == null)
			{
				return false;
			}

			//�����i�Ǘ��N���C�A���g�փ��O�C�������Z�b�g
			//�擾�����]�ƈ����O�C���������[�N�N���X�Ƃ��ăT�[�o�[�o�^
			if (setDataKey.Count > 0)
			{
				_remoteService.SetData(_companyAuthInfoWork.AccessTicket,(string[])setDataKey.ToArray(typeof(string)),(object[])setDataValue.ToArray(typeof(object)));
				// --- UPD m.suzuki 2010/04/06 ---------->>>>>
                //string[] mutexSetKey = {"EmployeeLoginMutex"};
                string[] mutexSetKey = { @"Global\EmployeeLoginMutex" };
                // --- UPD m.suzuki 2010/04/06 ----------<<<<<
				_remoteService.SetMutex(_companyAuthInfoWork.AccessTicket,mutexSetKey);
			}


			return true;
		}

		/// <summary>
		/// �]�ƈ����O�I�t
		/// </summary>
		/// <returns>����</returns>
		public void EmployeeLogoff()
		{
			//�����O�C�����j��
			_employeeAuthInfoWork = null;
			_clientAuthInfoWork = null;
			//�����i�Ǘ��N���C�A���g���烍�O�C�����������[�X
			//�f�[�^�T�[�o�[�����[�X�p
			ArrayList setDataKey	= new ArrayList();
			setDataKey.Add(_const_EmployeeAuthInfoWork);
			setDataKey.Add(_const_ClientAuthInfoWork);
			if (_remoteService != null)
			{
				_remoteService.ReleaseData(_companyAuthInfoWork.AccessTicket,(string[])setDataKey.ToArray(typeof(string)));
				// --- UPD m.suzuki 2010/04/06 ---------->>>>>
                //string[] mutexSetKey = {"EmployeeLoginMutex"};
                string[] mutexSetKey ={ @"Global\EmployeeLoginMutex" };
                // --- UPD m.suzuki 2010/04/06 ----------<<<<<
				_remoteService.ReleaseMutex(_companyAuthInfoWork.AccessTicket,mutexSetKey);
			}
        }

        #endregion

        #region �v���C�x�[�g���\�b�h�i���j���[���j
        /// <summary>
		/// �I�t���C���]�ƈ����O�C�����擾
		/// </summary>
		/// <param rKeyName="onlineFlag">�I�t���C���t���O</param>
		/// <param rKeyName="companyAuthInfoWork">��ƃ��O�C�����</param>
		/// <returns>�]�ƈ����O�C�����</returns>
		private EmployeeAuthInfoWork MakeLoginEmployeeAuthInfoWork(bool onlineFlag, CompanyAuthInfoWork companyAuthInfoWork)
		{
			EmployeeAuthInfoWork result = null;
			if (!onlineFlag)
			{
				//�I�t���C���̏ꍇ�ɂ̓N���C�A���g�̃I�t���C���]�ƈ����O�C�������擾���ɂ���
				OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
				string className = this.GetType().ToString();
				string[] keyList = {companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode};
				result = offlineDataSerializer.DeSerialize(className,keyList) as EmployeeAuthInfoWork;
			}
			return result;
		}

		/// <summary>
		/// �]�ƈ����O�C�����L���b�V���ۑ�
		/// </summary>
		/// <param rKeyName="companyAuthInfoWork">��ƃ��O�C�����</param>
		/// <param rKeyName="employeeAuthInfoWork">�]�ƈ����O�C�����</param>
		private void MakeLoginDataEmployeeAuthInfoWork(CompanyAuthInfoWork companyAuthInfoWork,EmployeeAuthInfoWork employeeAuthInfoWork)
		{
			//�I�����C���̏]�ƈ����O�C�����ɂ͏]�ƈ����O�C�������N���C�A���g�փL���b�V������
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			string className = this.GetType().ToString();
			string[] keyList = {companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode};
			offlineDataSerializer.Serialize(className,keyList,employeeAuthInfoWork);
		}

        /// <summary>
        /// �N���C�A���g�o�[�W�����擾
        /// </summary>
        /// <returns>�N���C�A���g�o�[�W����</returns>
        private Int32 GetRequiredServerVersion()
        {
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            //Int32 requiredServerVersion = -1;

            //// ���삷�郌�W�X�g���E�L�[�̖��O
            //string rKeyName = @String.Format("SOFTWARE\\Broadleaf\\Product\\{0}", ConstantManagement_SF_PRO.ProductCode);
            //// �擾�������s���ΏۂƂȂ郌�W�X�g���̒l�̖��O
            //string rGetValueName = "RequiredServerVersion";

            //// ���W�X�g���̎擾
            //try
            //{
            //    // ���W�X�g���E�L�[�̃p�X���w�肵�ă��W�X�g�����J��
            //    RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

            //    // ���W�X�g���̒l���擾
            //    requiredServerVersion = (Int32)rKey.GetValue(rGetValueName);

            //    // �J�������W�X�g���E�L�[�����
            //    rKey.Close();
            //}
            //catch (NullReferenceException)
            //{
            //    requiredServerVersion = -1;
            //}
            //return requiredServerVersion;

            int requiredServerVersion = -1;
            try
            {
                string registryValue = this.GetRegistryValue( ConstantManagement_SF_PRO.ProductCode, "RequiredServerVersion" );
                switch ( registryValue )
                {
                    case null:
                    case "":
                        return -1;
                }
                requiredServerVersion = Convert.ToInt32( registryValue );
            }
            catch ( Exception )
            {
                string name = string.Format( @"SOFTWARE\Broadleaf\Product\{0}", ConstantManagement_SF_PRO.ProductCode );
                string rGetValueName = "RequiredServerVersion";
                try
                {
                    RegistryKey rKey = Registry.LocalMachine.OpenSubKey( name );
                    requiredServerVersion = (int)rKey.GetValue( rGetValueName );
                    rKey.Close();
                }
                catch ( NullReferenceException )
                {
                    requiredServerVersion = -1;
                }
                return requiredServerVersion;
            }
            return requiredServerVersion;
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<
        }

		/// <summary>
		/// �}�V��ID�擾
		/// </summary>
		/// <returns></returns>
		private string GetMachineUserId()
		{
			//DNS�z�X�g�����擾
			string workstationID = Dns.GetHostName();
			//�擾�o���Ȃ��ꍇ�ɂ�NetBios�����擾
			if (workstationID == null || workstationID == "") workstationID = Environment.MachineName;
			return workstationID;
		}

        // --- ADD m.suzuki 2010/04/06 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int GetRequiredServerVersion( string target )
        {
            int num;
            try
            {
                string str = _ServerVersionTable[target].ToString();
                if ( str != null )
                {
                    return Convert.ToInt32( str );
                }
            }
            catch ( Exception )
            {
            }
            try
            {
                string registryValue = this.GetRegistryValue( string.Format( @"{0}\{1}", ConstantManagement_SF_PRO.ProductCode, target ), "RequiredServerVersion" );
                switch ( registryValue )
                {
                    case null:
                    case "":
                        return -1;
                }
                return Convert.ToInt32( registryValue );
            }
            catch ( Exception )
            {
                string name = string.Format( @"SOFTWARE\Broadleaf\Product\{0}\{1}", ConstantManagement_SF_PRO.ProductCode, target );
                string str4 = "RequiredServerVersion";
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey( name );
                    num = (int)key.GetValue( str4 );
                    key.Close();
                }
                catch ( NullReferenceException )
                {
                    num = -1;
                }
                return num;
            }
            return num;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private ArrayList MakeRequestAllChildCompanyRelationWork( LocalAccessToken token )
        {
            ArrayList list = new ArrayList();
            if ( token == null )
            {
                return null;
            }
            CRWebService service = new CRWebService();
            AuthorizeIdentity authorizeIdentity = new AuthorizeIdentity();
            authorizeIdentity.AccessTicket = token.AccessTicket;
            authorizeIdentity.CompanyCode = token.Company.CompanyCode;
            authorizeIdentity.ProductCode = token.Product.ProductCode;
            foreach ( ChildCompanyIdentity identity2 in service.RequestAllChildCompanyRelationList( authorizeIdentity ) )
            {
                AllChildCompanyWork work = new AllChildCompanyWork();
                work.companyCode = identity2.CompanyIdentity.CompanyCode;
                work.companyName = identity2.CompanyIdentity.CompanyName;
                work.emailAddress = identity2.CompanyIdentity.EmailAddress;
                list.Add( work );
            }
            return list;
        }
        // --- ADD m.suzuki 2010/04/06 ----------<<<<<

	
		/// <summary>
		/// MAC�A�h���X�擾
		/// </summary>
		/// <returns>MAC�A�h���X������</returns>
		private string GetMachineMacId()
		{
			try
			{
				//NIC��MAC�A�h���X�̎擾
				//WMI�c���[����NIC�̏����擾����N�G���[�𐶐�
				ManagementObjectSearcher nicQuery = new ManagementObjectSearcher("SELECT MacAddress FROM Win32_NetworkAdapterConfiguration WHERE MACAddress is not null");
				//�N�G���[���NIC�̃R���N�V�������擾
				ManagementObjectCollection nicCollection = nicQuery.Get();

				StringBuilder mac = new StringBuilder((int)(nicCollection.Count * 18));
				int counter = nicCollection.Count;
				foreach(ManagementObject mo in nicCollection)
				{				
					mac.Append(mo["MacAddress"].ToString());
					counter--;
					if (counter > 0) mac.Append(",");
				}
				if (mac.ToString().Length == 0) return "";
				else							return mac.ToString();
			}
			catch(Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// ���i�Ǘ��N���C�A���g�|�[�g�ԍ��擾
		/// </summary>
		/// <returns></returns>
		private Int32 GetPMCPorNo()
		{
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            //// ���삷�郌�W�X�g���E�L�[�̖��O
            //string rKeyName = @"SOFTWARE\Broadleaf\Product\PMC";
            //// �擾�������s���ΏۂƂȂ郌�W�X�g���̒l�̖��O
            //string rGetValueName = "PortID";

            //// ���W�X�g���̎擾
            //try
            //{
            //    // ���W�X�g���E�L�[�̃p�X���w�肵�ă��W�X�g�����J��
            //    RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

            //    // ���W�X�g���̒l���擾
            //    Int32 pMCPortNo2 = (Int32)rKey.GetValue(rGetValueName);

            //    // �J�������W�X�g���E�L�[�����
            //    rKey.Close();

            //    // �擾�������W�X�g���̒l��߂�
            //    return pMCPortNo2;
            //}
            //catch (NullReferenceException)
            //{
            //    return 0;
            //}

            int pMCPortNo;
            try
            {
                string registryValue = this.GetRegistryValue( "PMC", "PortID" );
                switch ( registryValue )
                {
                    case null:
                    case "":
                        return 0;
                }
                pMCPortNo = Convert.ToInt32( registryValue );
            }
            catch ( Exception )
            {
                string rKeyName = @"SOFTWARE\Broadleaf\Product\PMC";
                string rGetValueName = "PortID";
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey( rKeyName );
                    int pMCPortNo2 = (int)key.GetValue( rGetValueName );
                    key.Close();
                    pMCPortNo = pMCPortNo2;
                }
                catch ( NullReferenceException )
                {
                    pMCPortNo = 0;
                }
            }
            return pMCPortNo;
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<
		}
        // --- ADD m.suzuki 2010/04/06 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param rKeyName="productCode"></param>
        /// <param rKeyName="paraKey"></param>
        /// <returns></returns>
        private string GetRegistryValue( string productCode, string paraKey )
        {
            RegistryTargetProductInfo targetProductInfo = new RegistryTargetProductInfo();
            targetProductInfo.ProductCode = productCode;
            targetProductInfo.ApplicationType = ApplicationType.Client;
            targetProductInfo.TargetServiceName = string.Empty;
            Dictionary<string, object> registryInfo = ServiceFactory.GetInstance().GetRemoteService().GetRegistryInfo( targetProductInfo );
            if ( registryInfo.Count == 0 )
            {
                throw new Exception( "�C���X�g�[�����̎擾�Ɏ��s���܂����B�������C���X�g�[�����s���Ă��邩�ǂ����m�F���Ă�������" );
            }
            string str = registryInfo[paraKey].ToString();
            if ( str == null )
            {
                throw new Exception( "�C���X�g�[�����̎擾�Ɏ��s���܂����B�������C���X�g�[�����s���Ă��邩�ǂ����m�F���Ă�������" );
            }
            return str;
        }
        // --- ADD m.suzuki 2010/04/06 ----------<<<<<

		/// <summary>
		/// ���i�o�[�W�����擾
		/// </summary>
		/// <param rKeyName="productCode">�v���_�N�g�R�[�h</param>
		/// <returns>�o�[�W����</returns>
		private string GetProductVersion(string productCode)
		{
			// ���삷�郌�W�X�g���E�L�[�̖��O
			string rKeyName = @"SOFTWARE\Broadleaf\Product\"+productCode;
			// �擾�������s���ΏۂƂȂ郌�W�X�g���̒l�̖��O
			string rGetValueName = "CurrentVersion";

			// ���W�X�g���̎擾
			try
			{
				// ���W�X�g���E�L�[�̃p�X���w�肵�ă��W�X�g�����J��
				RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

				// ���W�X�g���̒l���擾
				string version = (string)rKey.GetValue(rGetValueName);

				// �J�������W�X�g���E�L�[�����
				rKey.Close();

				// �擾�������W�X�g���̒l��߂�
				if (version == null)	return "";
				else					return version;
			}
			catch (NullReferenceException)
			{
				return "";
			}
		}

		/// <summary>
		/// �N���C�A���g��񐶐�
		/// </summary>
		/// <returns></returns>
		private ClientAuthInfoWork MakeClientAuthInfoWork()
		{
			ClientAuthInfoWork clientAuthInfoWork = new ClientAuthInfoWork();
			clientAuthInfoWork.MachineUserId = GetMachineUserId();//���[�U�[ID
			clientAuthInfoWork.MachineMacAdd = GetMachineMacId(); //MAC�A�h���X
			clientAuthInfoWork.SuperFrontmanVersion = _version;		//SuperFrontmanVersion
			clientAuthInfoWork.PMCVersion			= _versionPMC;	//ProductVersion
			return clientAuthInfoWork;
		}

		/// <summary>
		/// ��ƔF�؏��擾
		/// </summary>
		/// <param rKeyName="token">�擾�F�؏��</param>
		/// <returns>��ƔF�؏��</returns>
		private CompanyAuthInfoWork MakeCompanyAuthInfoWork(LocalAccessToken token)
		{
			//��Ə�񂪖����ꍇ�ɂ�null��߂�
			if (token == null) return null;

			//��Ə�񂪂���ꍇ�ɂ͊�ƃ��O�C�����𐶐�
			CompanyAuthInfoWork companyAuthInfoWork = new CompanyAuthInfoWork();
			companyAuthInfoWork.AccessTicket = token.AccessTicket;
			companyAuthInfoWork.LoginFlag = token.LoginFlag;
			companyAuthInfoWork.OnlineMode = true;
			//���O�C����Ə����擾
			companyAuthInfoWork.EnterpriseInfoWork = new EnterpriseInfoWork();
			companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode = token.Company.CompanyCode;
			companyAuthInfoWork.EnterpriseInfoWork.EnterpriseName = token.Company.CompanyName;
			companyAuthInfoWork.EnterpriseInfoWork.EnterpriseDescription = token.Company.CompanyDescription;
			//���O�C����ƌ_��\�t�g�E�F�A�����擾
			companyAuthInfoWork.ProductInfoWork = new ProductInfoWork();
			companyAuthInfoWork.ProductInfoWork.ProductCode = token.Product.ProductCode;
			companyAuthInfoWork.ProductInfoWork.ProductName = token.Product.ProductName;
			companyAuthInfoWork.ProductInfoWork.ProductDescription = token.Product.ProductDescription;
			//�T�[�r�X�R�l�N�V�������
			if (token.Product.RemoteServiceInfoArray == null || token.Product.RemoteServiceInfoArray.Length == 0)
			{
				companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray = new RemoteServiceInfoWork[0];
			}
			else
			{
				companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray = new RemoteServiceInfoWork[token.Product.RemoteServiceInfoArray.Length];
				for(int i=0;i<token.Product.RemoteServiceInfoArray.Length;i++)
				{
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i] = new RemoteServiceInfoWork();
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceCode		= token.Product.RemoteServiceInfoArray[i].ServiceCode;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceName		= token.Product.RemoteServiceInfoArray[i].ServiceName;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceTargetName	= token.Product.RemoteServiceInfoArray[i].ServiceTargetName;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Protocol			= token.Product.RemoteServiceInfoArray[i].Protocol;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Domain			= token.Product.RemoteServiceInfoArray[i].Domain;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Port				= token.Product.RemoteServiceInfoArray[i].Port;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].IsLoginService	= token.Product.RemoteServiceInfoArray[i].IsLoginService;
					//�R�l�N�V�������
					if (token.Product.RemoteServiceInfoArray[i].ConnectionInfo == null || token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length == 0)
					{
						companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray = new ConnectionInfoWork[0];
					}
					else
					{
						companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray = new ConnectionInfoWork[token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length];
						for (int ii=0;ii<token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length;ii++)
						{
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii] = new ConnectionInfoWork();
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].IndexCode			= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].IndexCode;
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].IndexName			= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].IndexName;
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].TypeCode			= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].TypeCode;
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].ConnectionText	= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].ConnectionText;
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].ConnectionName	= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].ConnectionName;
                            //�Í������
                            if (token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo == null || token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo.Length == 0)
                            {
                                companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray = new DBEncryptionInfoWork[0];
                            }
                            else
                            {
                                companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray = new DBEncryptionInfoWork[token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo.Length];
                                for (int iii = 0; iii < token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo.Length; iii++)
                                {
                                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray[iii] = new DBEncryptionInfoWork();
                                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray[iii].TableName = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo[iii].TableName;
                                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray[iii].KeyName = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo[iii].KeyName;
                                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray[iii].KeyPWD = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo[iii].KeyPWD;
                                }
                            }
						}
					}
				}
			}

			//�\�t�g�E�F�A���
			if (token.Product.SoftwareInfoArray == null || token.Product.SoftwareInfoArray.Length == 0)
			{
				companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray = new SoftwareInfoWork[0];
			}
			else
			{
				companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray = new SoftwareInfoWork[token.Product.SoftwareInfoArray.Length];
				for(int i=0;i<token.Product.SoftwareInfoArray.Length;i++)
				{
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i] = new SoftwareInfoWork();
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareCode = token.Product.SoftwareInfoArray[i].SoftwareCode;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareName = token.Product.SoftwareInfoArray[i].SoftwareName;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareType = token.Product.SoftwareInfoArray[i].SoftwareType;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareDescription = token.Product.SoftwareInfoArray[i].SoftwareDescription;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].ProductCode = token.Product.SoftwareInfoArray[i].ProductCode;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].RemainingDays = token.Product.SoftwareInfoArray[i].RemainingDays;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].PurchaseStatus = (Int32)token.Product.SoftwareInfoArray[i].PurchaseStatus;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].IsUSBAccessPermitted = token.Product.SoftwareInfoArray[i].IsUSBAccessPermitted;
				}
			}
			//���[�����
			if (token.Product.RoleInfoArray == null || token.Product.RoleInfoArray.Length == 0)
			{
				companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray = new RoleInfoWork[0];
			}
			else
			{
				companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray = new RoleInfoWork[token.Product.RoleInfoArray.Length];
				for(int i=0;i<token.Product.RoleInfoArray.Length;i++)
				{
					companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i] = new RoleInfoWork();
					companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleCode = token.Product.RoleInfoArray[i].RoleCode;
					companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleName = token.Product.RoleInfoArray[i].RoleName;
					companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleDescription = token.Product.RoleInfoArray[i].RoleDescription;
					if (token.Product.RoleInfoArray[i].FunctionInfoArray == null || token.Product.RoleInfoArray[i].FunctionInfoArray.Length == 0)
					{
						companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray = new FunctionInfoWork[0];
					}
					else
					{
						companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray = new FunctionInfoWork[token.Product.RoleInfoArray[i].FunctionInfoArray.Length];
						for(int ii=0;ii<token.Product.RoleInfoArray[i].FunctionInfoArray.Length;ii++)
						{
							companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii] = new FunctionInfoWork();
							companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionCode = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionCode;
							companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionName = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionName;
							companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionDescription = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionDescription;
						}
					}
				}
			}

			return companyAuthInfoWork;
		}

		/// <summary>
		/// �]�ƈ����O�C��/�g�b�v�y�[�W�p�T�[�o�[�h���C�����擾
		/// </summary>
		/// <param rKeyName="companyAuthInfoWork">��ƃ��O�C�����</param>
		/// <param rKeyName="onlineFlag">�I�����C���t���O</param>
		/// <param rKeyName="domain">�]�ƈ����O�C�����h���C��</param>
		/// <param rKeyName="toppage">�g�b�v�y�[�W�A�h���X</param>
        /// <param rKeyName="helppage">�w���v�y�[�W�A�h���X</param>
		/// <returns>status</returns>
        // --- UPD m.suzuki 2010/04/06 ---------->>>>>
        ////private int MakeServerDomain(CompanyAuthInfoWork companyAuthInfoWork,bool onlineFlag,out string domain,out string toppage)
        //private int MakeServerDomain(CompanyAuthInfoWork companyAuthInfoWork, bool onlineFlag, out string domain, out string toppage, out string helppage)
        private int MakeServerDomain( CompanyAuthInfoWork companyAuthInfoWork, bool onlineFlag, out string domain, out string toppage )
        // --- UPD m.suzuki 2010/04/06 ----------<<<<<
        {
			domain  = null;
			toppage = null;
            // --- DEL m.suzuki 2010/04/06 ---------->>>>>
            //// 2008.12.09 UENO ADD STA
            //helppage = null;
            //// 2008.12.09 UENO ADD END
            // --- DEL m.suzuki 2010/04/06 ----------<<<<<
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			if (companyAuthInfoWork == null ||
				companyAuthInfoWork.ProductInfoWork == null ||
				companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray == null ||
				companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray.Length == 0) return status;

			foreach(RemoteServiceInfoWork remoteServiceInfoWork in companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray)
			{
				if (remoteServiceInfoWork.ConnectionInfoWorkArray == null || remoteServiceInfoWork.ConnectionInfoWorkArray.Length == 0) continue;

				//���O�C���T�[�r�X�t���O�������Ă���ꍇ�]�ƈ����O�C���ڑ�AP�T�[�o�[�Ƃ��ăh���C����߂�
				//���]�ƈ����O�C���̃h���C��������΃X�e�[�^�X����
				if (remoteServiceInfoWork.IsLoginService)
				{
					domain = string.Format("{0}://{1}:{2}",remoteServiceInfoWork.Protocol,remoteServiceInfoWork.Domain,remoteServiceInfoWork.Port);
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				//�g�b�v�y�[�WWEB�̃A�h���X���擾�o������
				else if (remoteServiceInfoWork.ServiceCode.Equals("TOPPAGE_WEB") )
				{
					toppage = string.Format("{0}://{1}:{2}",remoteServiceInfoWork.Protocol,remoteServiceInfoWork.Domain,remoteServiceInfoWork.Port);
					//�p�����[�^������擾
					if (remoteServiceInfoWork.ConnectionInfoWorkArray != null && remoteServiceInfoWork.ConnectionInfoWorkArray.Length > 0)
					{
						foreach(ConnectionInfoWork connectionInfoWork in remoteServiceInfoWork.ConnectionInfoWorkArray)
						{
                            if (connectionInfoWork.TypeCode.Equals("201")) toppage += LoginInfoAcquisition.Decrypt(connectionInfoWork.ConnectionText, companyAuthInfoWork);
						}
					}
				}
                // --- DEL m.suzuki 2010/04/06 ---------->>>>>
                //// 2008.12.09 UENO ADD STA
                ////�w���v�y�[�WWEB�̃A�h���X���擾�o������
                //else if( remoteServiceInfoWork.ServiceCode.Equals("HELP_WEB") )
                //{
                //    helppage = string.Format("{0}://{1}:{2}", remoteServiceInfoWork.Protocol, remoteServiceInfoWork.Domain, remoteServiceInfoWork.Port);
                //    //�p�����[�^������擾
                //    if( remoteServiceInfoWork.ConnectionInfoWorkArray != null && remoteServiceInfoWork.ConnectionInfoWorkArray.Length > 0 )
                //    {
                //        foreach( ConnectionInfoWork connectionInfoWork in remoteServiceInfoWork.ConnectionInfoWorkArray )
                //        {
                //            if( connectionInfoWork.TypeCode.Equals("201") ) helppage += LoginInfoAcquisition.Decrypt(connectionInfoWork.ConnectionText, companyAuthInfoWork);
                //        }
                //    }
                //}
                //// 2008.12.09 UENO ADD END
                // --- DEL m.suzuki 2010/04/06 ----------<<<<<
			}
			//�����I�t���C���̏ꍇ�ɂ̓g�b�v�y�[�W�A�h���X�͉��L�̕����t�@�C���Ƃ���
			if (!onlineFlag)
			{
				toppage = Path.Combine(Directory.GetCurrentDirectory()	,_const_MenuOfflineDir);
				toppage = Path.Combine(toppage							,_const_MenuOfflineIndex);
                
                // --- DEL m.suzuki 2010/04/06 ---------->>>>>
                //// 2008.12.09 UENO ADD STA
                //helppage = Path.Combine(Directory.GetCurrentDirectory(), _const_MenuOfflineDir);
                //helppage = Path.Combine(helppage                       , _const_MenuOfflineIndex);
                //// 2008.12.09 UENO ADD END
                // --- DEL m.suzuki 2010/04/06 ----------<<<<<
			}
			return status;
		}

		/// <summary>
		/// �p�����[�^�擾
		/// </summary>
		/// <param rKeyName="param">�p�����[�^�����z��</param>
		private void GetPara(string[] param)
		{
			const int _paramCount = 2;

			//���p�����[�^�`�F�b�N
			bool paramErrorFlag = true;
			//�p�����[�^���`�F�b�N
			if (param.Length != _paramCount)					paramErrorFlag = false;
				//���p�����[�^�`�F�b�N
			else if (!param[0].Trim().Equals(bool.FalseString) 
				&& !param[0].Trim().Equals(bool.TrueString))	paramErrorFlag = false;
				//���p�����[�^�`�F�b�N
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
			//else if (param[1] == null || param[1].Length != 36) paramErrorFlag = false;
            else if ( param[1] == null || (param[1].Length != 36 && param[1].Length != 43) ) paramErrorFlag = false;
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<

            // --- DEL m.suzuki 2010/04/06 ---------->>>>>
            ////���p�����[�^��Guid�ϊ��`�F�b�N
            //try
            //{
            //    Guid guid = new Guid( param[1] );
            //}
            //catch ( Exception ex )
            //{
            //    paramErrorFlag = false;
            //}
            // --- DEL m.suzuki 2010/04/06 ----------<<<<<


			//������C���X�^���X���`�F�b�N
			if(!paramErrorFlag)	throw new Exception("�s���N���ł��B���i�Ǘ��N���C�A���g����N�����Ă��������B",null);


			//�������o�W�J
			//����p�����[�^�̏ꍇ�ɂ̓N���X�����o�𐶐�
			//�@�I�����C���t���O
			if (param[0].Trim().Equals(bool.FalseString)) _onlineFlag = false;
			else										  _onlineFlag = true ;
			//�A�@
			_companyLoginMutexKey	= param[1];
		}	

		/// <summary>
		/// �J�X�^���V���A���C�Y
		/// </summary>
		/// <param rKeyName="data">�V���A���C�Y�f�[�^</param>
		/// <returns>�V���A���C�Y����</returns>
		private byte[] CustomFormatterSerialize(object data)
		{
			byte[] result = null;

			MemoryStream mem = new MemoryStream();
			BinaryWriter writer = new BinaryWriter( mem, Encoding.UTF8 );								
			try
			{
				if (data is CompanyAuthInfoWork)
				{
					//��Ə��
                    ICustomSerializationSurrogate formatterCompanyAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.CompanyAuthInfoWork, SFCMN00654D");
					formatterCompanyAuthInfoWork.Serialize( writer, data );
				}
				else if (data is EmployeeAuthInfoWork)
				{
					//�]�ƈ����
                    ICustomSerializationSurrogate formatterEmployeeAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.EmployeeAuthInfoWork, SFCMN00664D");
					formatterEmployeeAuthInfoWork.Serialize( writer, data );
				}
				else if (data is ClientAuthInfoWork)
				{
					//�N���C�A���g���
                    ICustomSerializationSurrogate formatterClientAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.ClientAuthInfoWork, SFCMN00694D");
					formatterClientAuthInfoWork.Serialize( writer, data );
				}
				else
				{
					result = null;
					data = null;
				}

				//�ΏۃI�u�W�F�N�g�̏ꍇ
				if (data != null)
				{
					mem.Seek( 0, SeekOrigin.Begin );
					result = new byte[mem.Length];
					mem.Read( result, 0, result.Length );
				}
			}
			catch(Exception)
			{
				result = null;
			}
			finally
			{				
				writer.Close();
				mem.Close();
			}
			return result;
		}

		/// <summary>
		/// �J�X�^���f�V���A���C�U
		/// </summary>
		/// <param rKeyName="data">�ΏۃI�u�W�F�N�g</param>
		/// <param rKeyName="type">�f�V���A���C�Y�^�C�v</param>
		/// <returns>�f�V���A���C�Y����</returns>
		private object CustomFormatterDeSerialize(byte[] data, Type type)
		{	
			object result = null;
			MemoryStream mem = new MemoryStream();
			mem.Write( data, 0, data.Length );
			mem.Seek( 0, SeekOrigin.Begin );
			BinaryReader reader = new BinaryReader( mem, System.Text.Encoding.UTF8 );
			try
			{
				if (type == typeof(CompanyAuthInfoWork))
				{
					//��Ə��
                    ICustomSerializationSurrogate formatterCompanyAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.CompanyAuthInfoWork, SFCMN00654D");
					result = formatterCompanyAuthInfoWork.Deserialize( reader );
				}
				else if (type == typeof(EmployeeAuthInfoWork))
				{
					//�]�ƈ����
                    ICustomSerializationSurrogate formatterEmployeeAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.EmployeeAuthInfoWork, SFCMN00664D");
					result = formatterEmployeeAuthInfoWork.Deserialize( reader );
				}
				else if (type == typeof(ClientAuthInfoWork))
				{
					//�N���C�A���g���
                    ICustomSerializationSurrogate formatterClientAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.ClientAuthInfoWork, SFCMN00694D");
					result = formatterClientAuthInfoWork.Deserialize( reader );
				}
				else
				{
					result = null;
				}
			}
			catch(Exception)
			{
				result = null;
			}
			finally
			{
				reader.Close();
				mem.Close();
			}
			return result;
		}

		/// <summary>
		/// ���C�����j���[���sMutex�`�F�b�N
		/// </summary>
		/// <param rKeyName="returnMsg">�N���s���b�Z�[�W</param>
		/// <param rKeyName="rKey">Mutex�L�[</param>
		/// <param rKeyName="eventHandler">�ʒm�C�x���g</param>
		/// <returns>STATUS</returns>
		private int MutexStartCheck(out string returnMsg, string key, EventHandler eventHandler)
		{
			//�߂�l������
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			returnMsg = "";

			//���p�����[�^�`�F�b�N
			//�N���p�����[�^������`�F�b�N
			if ((key == null)||(key == ""))
			{
				returnMsg = "���i�Ǘ��N���C�A���g�ɂĊ�ƃ��O�C�����s���Ă��������B";
				return status;
			}		

			//��Mutex�`�F�b�N
			try
			{
				_exclusionService = new ExclusionService(key);
			}
			catch(Exception)
			{
				returnMsg = "�ʂ�Windows���[�U�[�Ńv���O�������N�����ł��B\r\n\r\n����Windows���[�U�[���N�����Ă���v���O������S�ďI�������Ă��������B";
				return status;
			}

			//���C�����j���[���N�����Ă��Ȃ��ꍇ
			if(_exclusionService.ApplicationState == ExclusionService.State.NotRunning)
			{
				returnMsg = "���i�Ǘ��N���C�A���g�ɂĊ�ƃ��O�C�����s���Ă��������B";
			}
				//���C�����j���[���N�����̏ꍇ(������Mutex���N����)
			else 
			{
				//ApplicationRelease�C�x���g�ڑ�
				_applicationReleased += eventHandler;

				//�ʃX���b�h��Mutex�Ď�
				_exclusionService.MutexReleased += new EventHandler(exclusionService_MutexReleased);
				_exclusionService.StartWaitMutexReleaseThread();
				//����N��OK�̖߂�l���Z�b�g
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}

			//�߂�l�̐ݒ�
			return status;
		}

		/// <summary>
		/// Mutex�J���������C�x���g
		/// </summary>
		/// <param rKeyName="sender"></param>
		/// <param rKeyName="e"></param>
		private void exclusionService_MutexReleased(object sender, EventArgs e)
		{
			//�]�ƈ����O�I�t����
			_exclusionService.Dispose();
			_exclusionService = null;

			//Application�ɒʒm
			_applicationReleased(sender, e);
		}

		/// <summary>
		/// Mutex�j������
		/// </summary>
		private void MutexEndCheck()
		{
			if (_exclusionService != null) 
			{
				_exclusionService.Dispose();
				_exclusionService = null;
			}
			if (_applicationReleased != null) _applicationReleased = null;
    }

        #endregion

        #region �\�t�g�E�F�A�_��m�F(USB/��Ɓj
        /// <summary>
        /// �\�t�g�E�F�A�_��m�F(USB�P��)
        /// </summary>
        /// <param rKeyName="softwareCode">�\�t�g�E�F�A�R�[�h</param>
        /// <returns>�\�t�g�E�F�A�_����</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode)
        {
            int SoftwareType;
            return SoftwarePurchasedCheckForUSB(softwareCode, out SoftwareType);
        }

        /// <summary>
        /// �\�t�g�E�F�A�_��m�F(USB�P��)
        /// </summary>
        /// <param rKeyName="softwareCode">�\�t�g�E�F�A�R�[�h</param>
        /// <param rKeyName="SoftwareType">�\�t�g�E�F�A�^�C�v</param>
        /// <returns>�\�t�g�E�F�A�_����</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode, out int SoftwareType)
        {
            return SoftwarePurchasedCheckForUSB(softwareCode, out SoftwareType, _companyAuthInfoWork);
        }

        /// <summary>
        /// �\�t�g�E�F�A�_��m�F(USB�P��)
        /// </summary>
        /// <param rKeyName="softwareCode">�\�t�g�E�F�A�R�[�h</param>
        /// <param rKeyName="SoftwareType">�\�t�g�E�F�A�^�C�v</param>
        /// <param rKeyName="company">��ƃ��O�C�����</param>
        /// <returns>�\�t�g�E�F�A�_����</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode, out int SoftwareType, object company)
        {
            SoftwareType = 0;

            //�ߋ��_�񖳂��ŏ�����
            int status = (int)Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Uncontract;

            if( !( company is CompanyAuthInfoWork ) )
                return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;

            //��ƃ��O�C�����擾
            CompanyAuthInfoWork companyAuthInfoWork = company as CompanyAuthInfoWork;

            if( companyAuthInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray == null )
                return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;

            foreach( SoftwareInfoWork softwareInfoWork in companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray )
            {
                //�\�t�g�E�F�A�R�[�h�`�F�b�N
                if( softwareCode == softwareInfoWork.SoftwareCode )
                {
                    //�_�񒆂�USB�����p�s�̏ꍇ�͌_�񖳂��Ƃ���
                    if( softwareInfoWork.PurchaseStatus > 0 && !softwareInfoWork.IsUSBAccessPermitted )
                        status = (int)Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Uncontract;
                    else
                        status = softwareInfoWork.PurchaseStatus;
                    SoftwareType = softwareInfoWork.SoftwareType;
                    break;
                }
            }
            //�߂�l��߂�
            return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;
        }

        /// <summary>
        /// �\�t�g�E�F�A�_��m�F(��ƒP��)
        /// </summary>
        /// <param rKeyName="softwareCode">�\�t�g�E�F�A�R�[�h</param>
        /// <returns>�\�t�g�E�F�A�_����</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode)
        {
            int SoftwareType;
            return SoftwarePurchasedCheckForCompany(softwareCode, out SoftwareType);
        }

        /// <summary>
        /// �\�t�g�E�F�A�_��m�F(��ƒP��)
        /// </summary>
        /// <param rKeyName="softwareCode">�\�t�g�E�F�A�R�[�h</param>
        /// <param rKeyName="SoftwareType">�\�t�g�E�F�A�^�C�v</param>
        /// <returns>�\�t�g�E�F�A�_����</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode, out int SoftwareType)
        {
            return SoftwarePurchasedCheckForCompany(softwareCode, out SoftwareType, _companyAuthInfoWork);
        }

        /// <summary>
        /// �\�t�g�E�F�A�_��m�F(��ƒP��)
        /// </summary>
        /// <param rKeyName="softwareCode">�\�t�g�E�F�A�R�[�h</param>
        /// <param rKeyName="SoftwareType">�\�t�g�E�F�A�^�C�v</param>
        /// <param rKeyName="company">��ƃ��O�C�����</param>
        /// <returns>�\�t�g�E�F�A�_����</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode, out int SoftwareType, object company)
        {
            SoftwareType = 0;
            //�ߋ��_�񖳂��ŏ�����
            int status = (int)Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Uncontract;

            if( !( company is CompanyAuthInfoWork ) )
                return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;

            //��ƃ��O�C�����擾
            CompanyAuthInfoWork companyAuthInfoWork = company as CompanyAuthInfoWork;

            if( companyAuthInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray == null )
                return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;

            foreach( SoftwareInfoWork softwareInfoWork in companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray )
            {
                //�\�t�g�E�F�A�R�[�h�`�F�b�N
                if( softwareCode == softwareInfoWork.SoftwareCode )
                {
                    //USB�̌_���Ԃ͖������Ă��̂܂܂̌_���ԁi��Ђ̌_���ԁj��߂�
                    status = softwareInfoWork.PurchaseStatus;
                    SoftwareType = softwareInfoWork.SoftwareType;
                    break;
                }
            }
            //�߂�l��߂�
            return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;
        }

        #endregion

        #region �p�u���b�N���\�b�h�i�A�h�I�����j
        /// <summary>
        /// TOP���j���[�A�h�I�����擾
        /// </summary>
        /// <param rKeyName="fileName"></param>
        /// <param rKeyName="rKey"></param>
        /// <returns></returns>
        public SfNetMenuAddOnInfo GetSfNetMenuAddOnInfo(string fileName, string[] key)
        {
            if( _sfNetMenuAddOnInfo == null )
            {
               _sfNetMenuAddOnInfo = LoadAddonConfig(fileName, key);
            }
            return _sfNetMenuAddOnInfo;
        }
        #endregion

        #region �v���C�x�[�g���\�b�h�i�A�h�I�����j
        /// <summary>
        /// TOP���j���[�A�h�I�����擾�i���s���j
        /// </summary>
        /// <param rKeyName="fileName"></param>
        /// <param rKeyName="rKey"></param>
        /// <returns></returns>
        private SfNetMenuAddOnInfo LoadAddonConfig(string fileName, string[] key)
        {
            SfNetMenuAddOnInfo sfNetMenuAddOnInfo = null;

            if( File.Exists(fileName) )
            {
                try
                {
                    sfNetMenuAddOnInfo = Broadleaf.Application.Common.UserSettingController.DecryptionDeserializeUserSetting<SfNetMenuAddOnInfo>(fileName, key);
                }
                catch( Exception )
                {
                }
            }

            if( sfNetMenuAddOnInfo == null )
            {
                sfNetMenuAddOnInfo = new SfNetMenuAddOnInfo();
            }
            return sfNetMenuAddOnInfo;
        }
        #endregion
    }
}
