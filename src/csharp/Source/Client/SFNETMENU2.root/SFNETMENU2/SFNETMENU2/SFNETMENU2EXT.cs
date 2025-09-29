using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;
using System.Globalization;
using System.Data;

using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	

	/// <summary>
	///	�A�v���P�[�V������d�N���Ǘ��N���X                                              
	/// </summary>
	/// <remarks> 
	/// <br>Note             :   ��d�N�����`�F�b�N���܂�</br>
	/// <br>Programmer       :   ���� �K��</br>                           
	/// <br>Date             :   2005.07.08</br>                           
	/// <br>Update Note      :   2007.02.23</br>           
	/// </remarks>
	public class ExclusionService :IDisposable
	{
		/// <summary>�~���[�e�b�N�X�I�u�W�F�N�g</summary>
		/// <remarks>�A�v���P�[�V�����Ǘ��i�r������j�Ɏg�p����܂�</remarks>
		private System.Threading.Mutex mutex;

		/// <summary>�N���Ǘ�</summary>
		private State _ApplicationState;

		/// <summary>
		/// ExclusionService�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="MutexName">Mutex���ʂɎg�p�����A�v���P�[�V�������̖���</param>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �����ݒ���s���܂�</br>
		/// <br>Programmer       :   ���� �K��</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public ExclusionService(string MutexName)
		{
			bool _NotRunning;

			//�~���[�e�b�N�X�I�u�W�F�N�g�̐���
			mutex = new Mutex(true ,MutexName, out _NotRunning);

			//�~���[�e�b�N�X�̏�Ԃ��Ǘ�
			if(_NotRunning)
			{
				this._ApplicationState = State.NotRunning;
			}
			else
			{
				this._ApplicationState = State.Running;
			}
		}

		/// <summary>
		/// �A�v���P�[�V�����N����ԃv���p�e�B
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �A�v���P�[�V�����N����Ԃ��擾���܂�</br>
		/// <br>Programmer       :   ���� �K��</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public State ApplicationState
		{
			get{return this._ApplicationState;}
		}

		/// <summary>
		/// �~���[�e�b�N�X�J���C�x���g�n���h���[
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �J�����̃C�x���g�Ɏg�p</br>
		/// <br>Programmer       :   ���� �K��</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public event System.EventHandler MutexReleased;

		/// <summary>
		/// �~���[�e�b�N�X�ҋ@�p�X���b�h
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �~���[�e�b�N�X�J����ҋ@����X���b�h�쐬�{�N��</br>
		/// <br>Programmer       :   ���� �K��</br>                           
		/// <br>Date             :   2005.07.04</br>
		/// </remarks>
		public void StartWaitMutexReleaseThread()
		{
			Thread hThread = new Thread(new ThreadStart(WaitForMutexRelease));
			hThread.IsBackground = true;
			hThread.Start();
		}

		/// <summary>
		/// �g�p���̃~���[�e�b�N�X�̊J���܂őҋ@
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �~���[�e�b�N�X�̊J����҂��A�����ɃC�x���g�𓊂��܂�</br>
		/// <br>Programmer       :   ���� �K��</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		private void WaitForMutexRelease()
		{
            try
            {
                mutex.WaitOne();
            }
            catch (Exception)
            {
            }

			MutexReleased(true, null);
		}

		#region enum�����o�[

		/// <summary>
		/// �A�v���P�[�V�����N�����
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Running = �N����</br>
		/// <br>                 :   NotRunning = �N���Ȃ�</br>
		/// <br>Programmer       :   ���� �K��</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public enum State
		{
			/// <summary>�N����</summary>
			Running,
			/// <summary>�N���Ȃ�</summary>
			NotRunning
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// �~���[�e�N�X�I�u�W�F�N�g�I������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �~���[�e�b�N�X�I�u�W�F�N�g����������Ă���ꍇ�͊J�����܂�</br>
		/// <br>                 :   ���̌�A�~���[�e�b�N�X�I�u�W�F�N�g����܂�</br>
		/// <br>Programmer       :   ���� �K��</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public void Dispose()
		{
			//���̃~���[�e�b�N�X�ɂ��A�v���P�[�V�������N�����ꂽ�ꍇ�i�~���[�e�b�N�X�������j
			if(this._ApplicationState == State.NotRunning)
			{
				mutex.ReleaseMutex();//�~���[�e�N�X�J��
			}

			mutex.Close();//�~���[�e�N�X�I��
		}

		#endregion
	}

    /// <summary>���O�C�����N���X</summary>
    /// <summary>
    /// AddRegsiterMenuApp
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O���ďo��(���j���[�Ăяo��)�p�F�؃`�F�b�N�EApp�o�^�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class LoginInfoFromExt
    {
        private string _EnterpriseCode;
        private string _EnterpriseName;
        private string _EmployeeCode;
        private string _EmployeeName;
        private string _ProductCode;
        private bool   _OnlineMode;

        public LoginInfoFromExt()
        {
            _EnterpriseCode = "";
            _EnterpriseName = "";
            _EmployeeCode = "";
            _EmployeeName = "";
            _ProductCode = "";
            _OnlineMode = false;
        }

        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>��ƃR�[�h</value>
        /// <remarks></remarks>
        public string EnterpriseCode
        {
            get { return _EnterpriseCode; }
            set { _EnterpriseCode = value; }
        }
        /// <summary>��Ə��v���p�e�B</summary>
        /// <value>��Ə��</value>
        /// <remarks></remarks>
        public string EnterpriseName
        {
            get { return _EnterpriseName; }
            set { _EnterpriseName = value; }
        }
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>�]�ƈ��R�[�h</value>
        /// <remarks></remarks>
        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }
        /// <summary>�]�ƈ����̃v���p�e�B</summary>
        /// <value>�]�ƈ�����</value>
        /// <remarks></remarks>
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        /// <summary>���i�R�[�h�v���p�e�B</summary>
        /// <value>���i�R�[�h</value>
        /// <remarks></remarks>
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        /// <summary>�I�����C�����[�h�v���p�e�B</summary>
        /// <value>�I�����C�����[�h</value>
        /// <remarks></remarks>
        public bool OnlienMode
        {
            get { return _OnlineMode; }
            set { _OnlineMode = value; }
        }


    }

    /// <summary>
    /// DirSettiing�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ݒ�t�@�C���i�[�f�B���N�g���擾</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class DirSettiing
    {
        public enum DirType
        {
            AppSettingDataDir,
            NavigationDataDir
        }
        
        private static Assembly SFCMN00505MOD;
        private static Type SFCMN00505MOD_ConstantManagement_ClientDirectory;
        private static string AppSettingDataDir = "";
        private static string NavigationDataDir = "";

        /// <summary>
        /// �ݒ�t�@�C���i�[�f�B���N�g���擾����
        /// </summary>
        /// <param name="GetDirType">�擾�f�B���N�g���^�C�v</param>
        /// <returns>�擾������</returns>
        /// <remarks>
        /// <br>Note       :�ݒ�t�@�C���i�[�f�B���N�g���擾</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static string GetDirectory(DirType GetDirType)
        {
            try
            {
                //  SFCMN00505�̃N���X���C���X�^���X��
                if (AppSettingDataDir.Length == 0)
                {
                    SFCMN00505MOD = Assembly.LoadFrom("SFCMN00505C.dll");
                    SFCMN00505MOD_ConstantManagement_ClientDirectory = SFCMN00505MOD.GetType("Broadleaf.Application.Resources.ConstantManagement_ClientDirectory");
                    if (SFCMN00505MOD_ConstantManagement_ClientDirectory != null)
                    {
                        AppSettingDataDir = (string)SFCMN00505MOD_ConstantManagement_ClientDirectory.InvokeMember("MenuSettings_AppSettingData", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty, null, null, null);
                        NavigationDataDir = (string)SFCMN00505MOD_ConstantManagement_ClientDirectory.InvokeMember("MenuSettings_NavigationData", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty, null, null, null);
                    }
                }

                if (GetDirType == DirType.AppSettingDataDir)
                {
                    return AppSettingDataDir;
                }
                else
                {
                    return NavigationDataDir;
                }
            }
            catch (Exception)
            {
                return "";
            }

        }


    }


    /// <summary>
    /// AddRegsiterMenuApp
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O���ďo��(���j���[�Ăяo��)�p�F�؃`�F�b�N�EApp�o�^�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2009.09.14  21024 ���X�؁@�ڑ�����擾�����̒ǉ�</br>
    /// </remarks>
    public class AddRegsiterMenuApp
    {
        private Assembly SFCMN00607MOD;
        private Type SFCMN00607MOD_ApplicationStartControl;
        private object Asc;
        private MethodInfo SFCMN00607MOD_StartApplication;
        private MethodInfo SFCMN00607MOD_EndApplication;

        private static Assembly SFCMN00651MOD;
        private Type SFCMN00651MOD_LoginInfoAcquisition;
        private object lia;
        private MethodInfo SFCMN00651MOD_GetConnectionInfo;
        private MethodInfo SFCMN00651MOD_SoftwarePurchasedCheckForCompany;
        private MethodInfo SFCMN00651MOD_SoftwarePurchasedCheckForUSB;
        // 2008.09.28 sugi -<<
        private MethodInfo SFCMN00651MOD_GetAPServiceTargetDomain;              //  2007.06.06  �ǉ�
        // 2008.09.28 sugi -<<
        // 2009.09.14 Add >>>
        //private MethodInfo SFCMN00651MOD_GetGetConnectionInfo;
        // 2009.09.14 Add <<<
        private PropertyInfo SFCMN00651MOD_OnlineFlag;
        private PropertyInfo SFCMN00651MOD_Employee;
        private PropertyInfo SFCMN00651MOD_EnterpriseCode;
        private PropertyInfo SFCMN00651MOD_EnterpriseName;
        private PropertyInfo SFCMN00651MOD_ProductCode;

        private Assembly SFTOK09381MOD;
        private Type SFTOK09381MOD_Employee;
        private object emp;
        private PropertyInfo SFTOK09381MOD_EmployeeCode;
        private PropertyInfo SFTOK09381MOD_EmployeeName;


        /// <summary>
        /// AddRegsiterMenuApp�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���ďo��(���j���[�Ăяo��)�p�F�؃`�F�b�N�EApp�o�^�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public AddRegsiterMenuApp()
        {

            try
            {
                // Get the type of MySimpleClass.
                SFCMN00607MOD = Assembly.LoadFrom("SFCMN00607C.dll");
                SFCMN00607MOD_ApplicationStartControl = SFCMN00607MOD.GetType("Broadleaf.Application.Common.ApplicationStartControl");
                if (SFCMN00607MOD_ApplicationStartControl != null)
                {
                    //  SFCMN00607�̃N���X���C���X�^���X��
                    Asc = (object)Activator.CreateInstance(SFCMN00607MOD_ApplicationStartControl);
                    SFCMN00607MOD_StartApplication = SFCMN00607MOD_ApplicationStartControl.GetMethod("StartApplication", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00607MOD_EndApplication = SFCMN00607MOD_ApplicationStartControl.GetMethod("EndApplication", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                }
                //  SFCMN00651�̃N���X���C���X�^���X��
                SFCMN00651MOD = Assembly.LoadFrom("SFCMN00651C.dll");
                SFCMN00651MOD_LoginInfoAcquisition = SFCMN00651MOD.GetType("Broadleaf.Application.Common.LoginInfoAcquisition");
                if (SFCMN00651MOD_LoginInfoAcquisition != null)
                {
                    lia = (object)Activator.CreateInstance(SFCMN00651MOD_LoginInfoAcquisition);
                    SFCMN00651MOD_OnlineFlag = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("OnlineFlag", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_Employee = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("Employee", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_EnterpriseCode = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("EnterpriseCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_EnterpriseName = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("EnterpriseName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_ProductCode = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("ProductCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_GetConnectionInfo = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("GetConnectionInfo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_SoftwarePurchasedCheckForCompany = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("SoftwarePurchasedCheckForCompany", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string)}, null);
                    SFCMN00651MOD_SoftwarePurchasedCheckForUSB = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("SoftwarePurchasedCheckForUSB", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string)}, null);
                    //2008.09.26 sugi --<<
                    SFCMN00651MOD_GetAPServiceTargetDomain = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("GetAPServiceTargetDomain", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string) }, null);              //  2007.06.06  �ǉ�
                    //2008.09.26 sugi --<<
                    // 2009.09.14 Add >>>
                    SFCMN00651MOD_GetConnectionInfo = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("GetConnectionInfo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string), typeof(string) }, null);
                    // 2009.09.14 Add <<<

                    //        public string GetConnectionInfo(string serviceCode, string indexCode);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode, out int SoftwareType);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode, out int SoftwareType, object company);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode, out int SoftwareType);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode, out int SoftwareType, object company);
               
                }
                //  SFTOK09381�̃N���X���C���X�^���X��
                SFTOK09381MOD = Assembly.LoadFrom("SFTOK09381E.dll");
                SFTOK09381MOD_Employee = SFTOK09381MOD.GetType("Broadleaf.Application.UIData.Employee");
                if (SFTOK09381MOD_Employee != null)
                {
                    emp = (object)Activator.CreateInstance(SFTOK09381MOD_Employee);
                    SFTOK09381MOD_EmployeeCode = SFTOK09381MOD_Employee.GetProperty("EmployeeCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFTOK09381MOD_EmployeeName = SFTOK09381MOD_Employee.GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                }
            }
            catch (Exception er)
            {
                //  �����G���[�ŃA�v���P�[�V�����I��
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Init", "���W���[���G���[", er.Message, "-991");
                System.Windows.Forms.Application.Exit();
            }

        }

        /// <summary>
        /// �N������
        /// </summary>
        /// <param name="sArgs">�R�}���h���C������</param>
        /// <param name="errMsg">�G���[���������b�Z�[�W������</param>
        /// <param name="eventHandler">�G���[�������N���C�x���g</param>
        /// <returns>���t�H�[���ړ�����</returns>
        /// <remarks>
        /// <br>Note       :�O���ďo��(��Ƀ��j���[)���Ɏg�p�����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public int Startup(ref string[] sArgs, out string errMsg, out LoginInfoFromExt loginInfo, EventHandler eventHandler)
        {
            errMsg = "";
            string AppName = "Partsman";  //  2008.04.22  �ύX sugi
            int status;

            loginInfo = new LoginInfoFromExt();

            try
            {
                status = (int)SFCMN00607MOD_StartApplication.Invoke(Asc, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)errMsg, (object)sArgs, (object)AppName, (object)eventHandler }, null);
                if (status == 0)
                {
                    bool st = (bool)SFCMN00651MOD_OnlineFlag.GetValue(lia, null);
                    if (!st)
                    {
                        //  �I�t���C�����[�h
                        status = 1;
                    }
                    try
                    {
                        //  ���O�C������ۑ�
                        emp = (object)SFCMN00651MOD_Employee.GetValue(lia, null);
                        loginInfo.EnterpriseCode = (string)SFCMN00651MOD_EnterpriseCode.GetValue(lia, null);
                        loginInfo.EnterpriseName = (string)SFCMN00651MOD_EnterpriseName.GetValue(lia, null);
                        loginInfo.ProductCode = (string)SFCMN00651MOD_ProductCode.GetValue(lia, null);
                        loginInfo.EmployeeCode = (string)SFTOK09381MOD_EmployeeCode.GetValue(emp, null);
                        loginInfo.EmployeeName = (string)SFTOK09381MOD_EmployeeName.GetValue(emp, null);
                        loginInfo.OnlienMode = (bool)SFCMN00651MOD_OnlineFlag.GetValue(lia, null);
                    }
                    catch (Exception ex)
                    {
                        errMsg = "�G���[���������܂����B�{�@�\�͂��g�p�ł��܂���B\n" + ex.Message;
                        status = -999;
                    }
                }
                 else
                 {
                     // �G���[�\��
                     if (errMsg.ToString().Length == 0)
                    {
                        errMsg = "�G���[���������܂����B�{�@�\�͂��g�p�ł��܂���B\n\n���O�C������܂������H";
                    }
                 }
            }
            catch (Exception er)
            {
                errMsg = "�G���[���������܂����B�{�@�\�͂��g�p�ł��܂���B\n" + er.Message;
                status = -999;
            }

            return status;

        }


        public int SoftwarePurchasedCheckForCompany(string SoftwareCode)
        {
            return (int)SFCMN00651MOD_SoftwarePurchasedCheckForCompany.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)SoftwareCode }, null);
        }
        public int SoftwarePurchasedCheckForUSB(string SoftwareCode)
        {
            return (int)SFCMN00651MOD_SoftwarePurchasedCheckForUSB.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)SoftwareCode }, null);
        }
        //2008.09.26 sugi --<<
        public string GetAPServiceTargetDomain(string ServiceCode)
        {
            return (string)SFCMN00651MOD_GetAPServiceTargetDomain.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)ServiceCode }, null);
        }
        //2008.09.26 sugi --<<
        // 2009.09.14 Add >>>
        public string GetConnectionInfo(string ServiceCode, string IndexCode)
        {
            return (string)SFCMN00651MOD_GetConnectionInfo.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)ServiceCode, (object)IndexCode }, null);
        }
        // 2009.09.14 Add <<<

        /// <summary>
        /// �N������
        /// </summary>
        /// <param name="sArgs">�R�}���h���C������</param>
        /// <param name="errMsg">�G���[���������b�Z�[�W������</param>
        /// <param name="eventHandler">�G���[�������N���C�x���g</param>
        /// <returns>���t�H�[���ړ�����</returns>
        /// <remarks>
        /// <br>Note       :�O���ďo��(��Ƀ��j���[)���Ɏg�p�����</br>
        /// <br>Programmer  : 96203 ����@�K��</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public void Fihisher()
        {
            try
            {
                SFCMN00607MOD_EndApplication.Invoke(Asc, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, null, null);
            }
            catch
            {
                
            }

        }

    }


    //  �ȉ��̓��e�̓Z�L�����e�B�ׁ̈A�킴�ƃR�����g�������Ȃ�
    public class SystemCheck
    {

        private static ArrayList _arSystemCode = new ArrayList();

        public static int ClearSystemCode()
        {
            try
            {
                _arSystemCode.Clear();
                return (0);
            }
            catch
            {
                return (5);
            }

        }

        public static int AddSystemCode(string SystemCode)
        {
            try
            {
                _arSystemCode.AddRange(SystemCode.Split(','));
                return (0);
            }
            catch
            {
                return (5);
            }

        }

        // 0:�P�Ƃœ����Ă���A1:���̃V�X�e���Ƌ��ɓ����Ă���A-1or-3�F�����ĂȂ�
        private static int CheckInstallSystem(string SystemCode)
        {
            try
            {
                bool bHit = false;
                //string TargetSystem;
                for (int i = 0; i < _arSystemCode.Count; i++)
                {
                    if (SystemCode == _arSystemCode[i].ToString())
                    {
                        //  �V�X�e���������ĂȂ��Ȃ�NG
                        //if (Program.arm.SoftwarePurchasedCheckForUSB(SystemCode) == 0)  // DEL 2013/12/19
                        if (Program.arm.SoftwarePurchasedCheckForUSB(SystemCode) <= 0)  // ADD 2013/12/19
                        {
                            return (-1);
                        }
                        bHit = true;
                        break;
                    }
                }
                //  ������Ȃ���΂��̎��_��NG
                if (bHit == false)
                {
                    return (-3);
                }
                //  �V�X�e���������Ă���Ȃ�A�P�̂��ǂ����𒲂ׂ�
                for (int i = 0; i < _arSystemCode.Count; i++)
                {
                    if (SystemCode != _arSystemCode[i].ToString())
                    {
                        //if (Program.arm.SoftwarePurchasedCheckForUSB(_arSystemCode[i].ToString()) != 0)  // DEL 2013/12/19
                        if (Program.arm.SoftwarePurchasedCheckForUSB(_arSystemCode[i].ToString()) > 0)  // ADD 2013/12/19
                        {
                            //  ���̑��̃V�X�e���������Ă���΁A1
                            return (1);
                        }
                    }
                }
                //  �P�̂Ȃ�[��
                return (0);
            }
            catch (Exception)
            {
                return (-9); 
            }
        }

        public static int CheckSystemPermissionFunction(DataRow chkRow)
        {
            try
            {
                //                                                          //  2006.09.29  �폜
                /*
                string SoftwareCode = "";
                if (chkRow["SystemCode"].ToString().Length != 0)
                {
                    SoftwareCode = chkRow["SystemCode"].ToString();
                }

                string OptionCode = "";
                if (chkRow["OptionCode"].ToString().Length != 0)
                {
                    OptionCode = chkRow["OptionCode"].ToString();
                }
                else if (SoftwareCode.Length == 0)
                {
                    return 1;
                }

                string[] ChkCode;
                if (OptionCode.Length != 0)
                {
                    ChkCode = OptionCode.Split(new Char[] { ',' });
                }
                else if (SoftwareCode.Length != 0)
                {
                    ChkCode = SoftwareCode.Split(new Char[] { ',' });
                }
                else
                {
                    ChkCode = new string[] { "" };
                }

                int nRtnCd = 0;
                bool bAndEnable = false;                                     //  ���������L��
                bool bPreConditionEnable = false;                            //  �������L��ŁA�ŐV�̃`�F�b�N����
                bool bLessEnable = false;                                    //  ���X�I�v�V�����L��
                int i = 0;
                while (i < ChkCode.Length)
                {

                    //  ���X�I�v�V�����𔻒�
                    if (ChkCode[i].Substring(0, 1) == "-")
                    {
                        bLessEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bLessEnable = false;
                    }
                    //  �������̃I�v�V�����𔻒�
                    if (ChkCode[i].Substring(0, 1) == "+")
                    {
                        bAndEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bAndEnable = false;
                    }

                    if ((nRtnCd = Program.arm.SoftwarePurchasedCheckForUSB(ChkCode[i])) != 0)
                    {

                        //  ���X�I�v�V�����Ȃ�A�I�v�V�����L���NG(�ŗD��`�F�b�N)
                        if (bLessEnable == true)
                        {
                            nRtnCd = 0;
                            break;

                        }

                        //  ���I�v�V���������Ȃ�A��P�ʂŔ��f
                        if ((bAndEnable == false) && (bPreConditionEnable == false))
                        {
                            break;
                        }
                        else
                        {
                            //  ���݂̃I�v�V�������������Ȃ�A���ʂ��N���A���čX�Ɍp��
                            if (bAndEnable == true)
                            {
                                nRtnCd = 0;
                                bPreConditionEnable = true;
                            }
                            else
                            {
                                //  ���݂̃I�v�V�������������Ŗ����Ȃ�AOK�Ƃ��Ă����ŏI��
                                bPreConditionEnable = false;
                                break;
                            }

                        }
                    }
                    else
                    {
                        //  ���X�I�v�V�����Ȃ�A
                        if (bLessEnable == true)
                        {
                            //  ���̃I�v�V�����`�F�b�N�Ώۂ��L��΁A���f�͂�����̐��ۂɂ䂾�˂�B�����łȂ���΃`�F�b�NOK�Ƃ���
                            nRtnCd = 1;

                        }

                        //  �������I�v�V�����L��Ȃ�
                        if (bAndEnable == true)
                        {
                            //  ��O���������I�v�V�����ŁA���I�v�V�������莸�s�Ȃ炱�̃Z�b�g�̏����͕s�����Ƃ��āA���̏����Ńg���C����

                            //  ������������Ȃ�A���̎��̃I�v�V�����͍ŏ�����s�������ƕ������Ă���̂ŁA��΂�
                            for (int j = i+1; j < ChkCode.Length;j++)
                            {
                                if (ChkCode[j].Substring(0, 1) != "+")
                                {
                                    i = j;              //�{�ȊO�̂����ꂽ���̍��ڂ���ăX�^�[�g
                                    break;
                                }
                                if (j >= (ChkCode.Length - 1))
                                {
                                    i = ChkCode.Length;
                                }
                            }
                            //  �t���O�����Z�b�g
                            bAndEnable = false;
                        }
                    }

                    i++;

                }
                return nRtnCd;
                */
                //                                                          //  2006.09.29  �ǉ� VV
                string[] ChkCode;
                if (chkRow["SysOpCode"].ToString().Length != 0)
                {
                    ChkCode = chkRow["SysOpCode"].ToString().Split(new Char[] { ',' });
                }
                else
                {
                    return 1;
                }
                return (CheckSystemPermissionFunctionBody(ChkCode));
                //                                                          //  2006.09.29  �ǉ� AA
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //public static int CheckSystemPermissionFunction(string iSoftwareCode, string iOptionCode)         //  2006.09.29  �ύX
        public static int CheckSystemPermissionFunction(string iSysOpCode)
        {
            try
            {
                //                                                      //  2006.09.29  �폜 
                /*                                          
                string SoftwareCode = "";
                if (iSoftwareCode.Trim().Length != 0)
                {
                    SoftwareCode = iSoftwareCode.Trim();
                }

                string OptionCode = "";
                if (iOptionCode.Trim().Length != 0)
                {
                    OptionCode = iOptionCode.Trim().ToString();
                }
                else if (SoftwareCode.Length == 0)
                {
                    return 1;
                }
                string[] ChkCode;
                if (OptionCode.Length != 0)
                {
                    ChkCode = OptionCode.Split(new Char[] { ',' });
                }
                else if (SoftwareCode.Length != 0)
                {
                    ChkCode = SoftwareCode.Split(new Char[] { ',' });
                }
                else
                {
                    ChkCode = new string[] { "" };
                }
                
                int nRtnCd = 0;
                bool bAndEnable = false;                                     //  ���������L��
                bool bPreConditionEnable = false;                            //  �������L��ŁA�ŐV�̃`�F�b�N����
                bool bLessEnable = false;                                    //  ���X�I�v�V�����L��
                int i = 0;
                while (i < ChkCode.Length)
                {

                    //  ���X�I�v�V�����𔻒�
                    if (ChkCode[i].Substring(0, 1) == "-")
                    {
                        bLessEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bLessEnable = false;
                    }
                    //  �������̃I�v�V�����𔻒�
                    if (ChkCode[i].Substring(0, 1) == "+")
                    {
                        bAndEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bAndEnable = false;
                    }

                    if ((nRtnCd = Program.arm.SoftwarePurchasedCheckForUSB(ChkCode[i])) != 0)
                    {
                        //  ���X�I�v�V�����Ȃ�A�I�v�V�����L���NG(�ŗD��`�F�b�N)
                        if (bLessEnable == true)
                        {
                            nRtnCd = 0;
                            break;

                        }

                        //  ���I�v�V���������Ȃ�A��P�ʂŔ��f
                        if ((bAndEnable == false) && (bPreConditionEnable == false))
                        {
                            break;
                        }
                        else
                        {
                            //  ���݂̃I�v�V�������������Ȃ�A���ʂ��N���A���čX�Ɍp��
                            if (bAndEnable == true)
                            {
                                nRtnCd = 0;
                                bPreConditionEnable = true;
                            }
                            else
                            {
                                //  ���݂̃I�v�V�������������Ŗ����Ȃ�AOK�Ƃ��Ă����ŏI��
                                bPreConditionEnable = false;
                                break;
                            }

                        }
                    }
                    else
                    {
                        //  ���X�I�v�V�����Ȃ�A
                        if (bLessEnable == true)
                        {
                            //  ���̃I�v�V�����`�F�b�N�Ώۂ��L��΁A���f�͂�����̐��ۂɂ䂾�˂�B�����łȂ���΃`�F�b�NOK�Ƃ���
                            nRtnCd = 1;

                        }

                        //  �������I�v�V�����L��Ȃ�
                        if (bAndEnable == true)
                        {
                            //  ��O���������I�v�V�����ŁA���I�v�V�������莸�s�Ȃ炱�̃Z�b�g�̏����͕s�����Ƃ��āA���̏����Ńg���C����

                            //  ������������Ȃ�A���̎��̃I�v�V�����͍ŏ�����s�������ƕ������Ă���̂ŁA��΂�
                            for (int j = i + 1; j < ChkCode.Length; j++)
                            {
                                if (ChkCode[j].Substring(0, 1) != "+")
                                {
                                    i = j;              //�{�ȊO�̂����ꂽ���̍��ڂ���ăX�^�[�g
                                    break;
                                }
                                if (j >= (ChkCode.Length - 1))
                                {
                                    i = ChkCode.Length;
                                }
                            }
                            //  �t���O�����Z�b�g
                            bAndEnable = false;
                        }
                    }

                    i++;

                }
                return nRtnCd;
                */
                //                                                          //  2006.09.29  �ǉ� VV
                string[] ChkCode;
                if (iSysOpCode.Length != 0)
                {
                    ChkCode = iSysOpCode.Split(new Char[] { ',' });
                }
                else
                {
                    return 1;
                }
                return (CheckSystemPermissionFunctionBody(ChkCode));
                //                                                          //  2006.09.29  �ǉ� AA

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int CheckSystemPermissionFunctionBody(string[] ChkCode)
        {
            try
            {

                int nRtnCd = 0;
                bool bLessEnable = false;                                    //  ���X�I�v�V�����L��

                int i = 0;
                while (i < ChkCode.Length)
                {
                    //	���������L�邩���`�F�b�N���āA�L��ꍇ�͕������čċA����
					if (ChkCode[i].IndexOf("&") > -1)
					{
                        bool bPermit = true;
                        string[] wkCheckCode = ChkCode[i].Split('&');
                        for (int j=0;j<wkCheckCode.Length;j++)
                        {
                            //  �P�̃`�F�b�N���J��Ԃ��āA���̊Ԃɏ����s�����������NG
                            if (CheckSystemPermissionFunctionBody(new string [] {wkCheckCode[j]}) == 0)
                            {
                                bPermit = false;
                                break;
                            }
                        }
                        //  �S������OK�Ȃ�\���\
                        if (bPermit == true)
                        {
                            return (1);
                        }
                        else
                        {
                            i++;
                            continue;
                        }
			
					}

                    //  �V�X�e���P�̎��ɕ\��NG
                    if (ChkCode[i].Substring(0, 1) == "=")
                    {
                        if (CheckInstallSystem(ChkCode[i].Substring(1)) == 0)
                        {
                            return (0);
                        }
                        i++;
                        if (i >= ChkCode.Length)
                        {
                            return (1);
                        }
                        continue;
                    }

                    //  ���X�I�v�V�����𔻒�
                    if (ChkCode[i].Substring(0, 1) == "-")
                    {
                        bLessEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bLessEnable = false;
                    }

                    //  �V�X�e���P�̎��ɕ\��OK
                    if (ChkCode[i].Substring(0, 1) == "*")
                    {
                        if (CheckInstallSystem(ChkCode[i].Substring(1)) == 0)
                            {
                            return (1);
                        }
                        i++;
                        if (i >= ChkCode.Length)
                        {
                            //return (1);                                       //  2007.02.23  �ύX
                            return (0);
                        }
                        continue;
                    }

                    //if ((nRtnCd = Program.arm.SoftwarePurchasedCheckForUSB(ChkCode[i])) != 0) // DEL 2013/12/19
                    if ((nRtnCd = Program.arm.SoftwarePurchasedCheckForUSB(ChkCode[i])) > 0)  // ADD 2013/12/19
                    {
                        //  ���X�I�v�V�����Ȃ�A�I�v�V�����L���NG(�ŗD��`�F�b�N)
                        if (bLessEnable == true)
                        {
                            nRtnCd = 0;
                        }

                        break;
                    }
                    else
                    {
                        //�I�v�V�����̎󒍊��Ԋ����؂�̏ꍇ,�}�C�i�X�̃X�e�[�^�X�ƂȂ�̂Ŗ߂�l��u��
                        nRtnCd = 0; // ADD 2013/12/19

                        //  ���X�I�v�V�����Ȃ�A
                        if (bLessEnable == true)
                        {
                            //  ���̃I�v�V�����`�F�b�N�Ώۂ��L��΁A���f�͂�����̐��ۂɂ䂾�˂�B�����łȂ���΃`�F�b�NOK�Ƃ���
                            nRtnCd = 1;

                        }

                    }

                    i++;

                }
                return nRtnCd;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// ���[���̊m�F
        /// </summary>
        /// <param name="targetString">����</param>
        /// <param name="roleLevel">�������x��</param>
        /// <returns>0:�������� 1:�����L��</returns>
        public static int CheckUseEnable(string targetString, int roleLevel)
        {
            // �ݒ�l�Ɠ��������ݒ�l���傫���ꍇ
            if (targetString.IndexOf("<=") != -1)
            {
                targetString = targetString.Replace("<=", "");

                if (roleLevel <= Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // �ݒ�l�Ɠ��������ݒ�l��菬�����ꍇ
            else if (targetString.IndexOf(">=") != -1)
            {
                targetString = targetString.Replace(">=", "");

                if (roleLevel >= Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // �ݒ�l�Ɠ������Ȃ��ꍇ
            else if (targetString.IndexOf("!=") != -1)
            {
                targetString = targetString.Replace("!=", "");

                if (roleLevel != Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // �ݒ�l���傫������
            else if (targetString.IndexOf("<") != -1)
            {
                targetString = targetString.Replace("<", "");

                if (roleLevel < Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // �ݒ�l��菬��������
            else if (targetString.IndexOf(">") != -1)
            {
                targetString = targetString.Replace(">", "");

                if (roleLevel > Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // �ݒ�l�Ɠ���������
            else if (targetString.IndexOf("=") != -1)
            {
                targetString = targetString.Replace("=", "");

                if (roleLevel == Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // �������w�肳��Ă��Ȃ��Ɣ��f
            else
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// �J�e�S�����p�����`�F�b�N
        /// </summary>
        /// <param name="row">�`�F�b�N�Ώۃ��R�[�h</param>
        /// <returns>true: ���p�\ false: ���p�s�\</returns>
        public static bool CheckAuthority(DataRow row)
        {
            int checkResults1 = -1;
            int checkResults2 = -1;
            int checkResults3 = -1;
            int checkResults4 = -1;
            int checkResults5 = -1;
            int checkResults6 = -1;

            if (row["UseEnableDiv1"].ToString().Trim() != "")
            {
                checkResults1 = CheckUseEnable(row["UseEnableDiv1"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel1);
            }

            if (row["UseEnableDiv2"].ToString().Trim() != "")
            {
                checkResults2 = CheckUseEnable(row["UseEnableDiv2"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel1);
            }

            if (row["UseEnableDiv3"].ToString().Trim() != "")
            {
                checkResults3 = CheckUseEnable(row["UseEnableDiv3"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel1);
            }

            if (row["UseEnableDiv4"].ToString().Trim() != "")
            {
                checkResults4 = CheckUseEnable(row["UseEnableDiv4"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel2);
            }

            if (row["UseEnableDiv5"].ToString().Trim() != "")
            {
                checkResults5 = CheckUseEnable(row["UseEnableDiv5"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel2);
            }

            if (row["UseEnableDiv6"].ToString().Trim() != "")
            {
                checkResults6 = CheckUseEnable(row["UseEnableDiv6"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel2);
            }

            // �`�F�b�N���ʂ��m�F

            // ���������������ꍇ�������͏������P�ł��ʂ�ꍇ
            if ((checkResults1 == -1 && checkResults2 == -1 && checkResults3 == -1 &&
                checkResults4 == -1 && checkResults5 == -1 && checkResults6 == -1) ||
                (checkResults1 == 1 || checkResults2 == 1 || checkResults3 == 1 ||
                 checkResults4 == 1 || checkResults5 == 1 || checkResults6 == 1))
            {
                return true;
            }
            
            return false;
        }
    }


    /// <summary>
    /// SystemReportList
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O���ďo��(���j���[�Ăяo��)�V�X�e�����|�[�g�N���X</br>
    /// <br>Programmer : 96203 ����@�K��</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx �w�w  �w�w</br>
    /// </remarks>
    public class SystemReportList
    {
        private Assembly SFMNUKN00201MOD;
        private Type SFMNUKN00201C_SystemReport;
        private string sPass = "gFeua";
        private object ssr;
        private MethodInfo SFMNUKN00201C_ReportSoftware;
        string errMsg = "";

        /// <summary>
        /// SystemReportList�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���ďo��(���j���[�Ăяo��)�V�X�e�����|�[�g�N���X</br>
        /// <br>Programmer : 96203 ����@�K��</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SystemReportList()
        {

            try
            {
                // Get the type of MySimpleClass.
                SFMNUKN00201MOD = Assembly.LoadFrom("SFUKN00201C.dll");
                SFMNUKN00201C_SystemReport = SFMNUKN00201MOD.GetType("Broadleaf.Application.Common.SystemReport");
                if (SFMNUKN00201C_SystemReport != null)
                {
                    //  SFCMN00607�̃N���X���C���X�^���X��
                    ssr = (object)Activator.CreateInstance(SFMNUKN00201C_SystemReport);
                    SFMNUKN00201C_ReportSoftware = SFMNUKN00201C_SystemReport.GetMethod("ReportSoftware", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                }
            }
            catch (Exception er)
            {
                //  �����G���[�ŃA�v���P�[�V�����I��
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "SystemReport", "�V�X�e�����|�[�g�E���W���[���G���[", er.Message, "-991");
            }

        }

        //public int ReportSoftware()                                   //  2006.09.29  �ύX
        public int ReportSoftware(string[] prodcuts)
        {
            errMsg = "";
            //string AppName = "SuperFrontman";                         //  2006.09.29  �ύX
            int status;

            try
            {
                status = (int)SFMNUKN00201C_ReportSoftware.Invoke(ssr, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] {(object)sPass }, null);
                if (status == 0)
                {

                }
                else
                {
                    // �G���[�\��
                    if (errMsg.ToString().Length == 0)
                    {
                        errMsg = "�G���[���������܂����B";
                    }
                }
            }
            catch (Exception er)
            {
                errMsg = "�G���[���������܂����B\n" + er.Message;
                status = -999;
            }

            return status;

        }
    }
}