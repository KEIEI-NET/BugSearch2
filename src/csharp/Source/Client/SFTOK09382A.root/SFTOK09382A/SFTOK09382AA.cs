# region ��using
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

using Broadleaf.Application.LocalAccess;
# endregion

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �]�ƈ��e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �]�ƈ��e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer	: 980076 �Ȓ��@����Y</br>
	/// <br>Date		: 2004.03.19</br>
	/// <br>Update Note	: 2005.11.16 23002 ���@�k��</br>
	/// <br>			  �E�Q�Ƃ���Ă���]�ƈ��̍폜�h�~</br>
	/// <br>Update Note	: 2005.11.17 22011 �����@���l</br>
	/// <br>			  �E�Q�Ƃ���Ă���]�ƈ��̍폜�h�~�̑Ή����R�����g�A�E�g</br>
	/// <br>Update Note	: 2006.06.20 23001 �H�R�@����</br>
	/// <br>              1.���o���[�g�����ނ�DD�̕ύX�Ή�</br>
    /// <br>Update Note	: 2006.12.11 20031 �É�@���S��</br>
    /// <br>              1.SF����Mobile�p�ɍ��ڕύX(�폜�̂�)</br>
	/// <br>Update Note	: 2007.03.29 980076 �Ȓ��@����Y</br>
	/// <br>              1.�K�C�h���Ƀf�[�^���\������Ȃ����ۂ�����</br>
	/// <br>Update Note	: 2007.05.21 18322 �ؑ� ����</br>
	/// <br>              1.���[�J��DB�Ή�(�ύX�_��"_employeeLcDB"�Ō���)</br>
    /// <br>Update Note : 2007.05.23 20008 �ɓ� �L</br>br>
    /// <br>              1.�o�^���ɐE��(�������x��1)�A�ٗp�`��(�������x��2)��ǉ�</br>
    /// <br>Update Note : 2007.05.26 980023 �ђJ �k��</br>
    /// <br>              1.�K�C�h�ɋ��_�̍i���@�\��ǉ�</br>
    /// <br>Update Note : 2007.05.29 980023 �ђJ �k��</br>
    /// <br>              1.���ʂ��\�[�g���ĕԂ��悤�ɏC��</br>
    /// <br>Update Note : 2007.08.14 980035 ���� ��`</br>
    /// <br>              1.�]�ƈ��ڍ׃}�X�^�̒ǉ���</br>
	/// <br>Update Note:  2008.01.31 30167 ���@�O�M</br>
	/// <br>			  1.���[�J���c�a�Ή�</br>
    /// <br>Update Note : 2008.02.08 980035 ���� ��`</br>
    /// <br>              1.�s�v�ȓǂݍ��ݏ������폜</br>
	/// <br>Update Note:  2008.02.12 30167 ���@�O�M</br>
	/// <br>			  1.���[�J���c�a�Ή��i���_�j</br>
	/// <br>			  2.�K�v�ȏ������R�����g����߂�</br>
    /// <br>Update Note : 2008/06/04 30414 �E�@�K�j</br>
    /// <br>              �E�u�����ہv�u���������ύX���v�u���������_�v�u����������v�u�������ہv�폜</br>
    /// <br>Update Note : 2008.11.10 30009 �a�J ���</br>
    /// <br>              �EUOE���̋敪�ǉ�</br>
    /// <br>Update Note : 2008.11.17 21024 ���X�� ��</br>
    /// <br>              �E�Ɩ��敪���̂̎擾�������폜</br>
    /// <br>Update Note : 2009.02.25 20056 ���n ���</br>
    /// <br>              �E�]�ƈ����̂ݎ擾����Search���\�b�h�ǉ�</br>
    /// <br>Update Note : 2009.03.02 20056 ���n ���</br>
    /// <br>              �E���[�����ڒǉ�</br>
    /// <br>Update Note : 2009.08.07 20056 ���n ���</br>
    /// <br>              �E�T�[�o�[�֔z�u����N���C�A���g�A�Z���u���Ή�</br>
    /// <br>                LoginInfoAcquisition.OnlineFlag���Q�Ƃ��Đ���ؑւ��s��Ȃ�(���Online)</br>
    /// <br>Update Note : 2010/02/18 30517 �Ė� �x��</br>
    /// <br>              �Efelica�Ή��E�f���p��felica�I�v�V�����`�F�b�N�i_optFeliCaAcs�j�ɂ�true���Z�b�g���Ă��܂�</br>
	/// <br>Update Note : 2012.05.29 30182 ���J�@����</br>
	/// <br>              �E�u����`�[���͋N�������v�u���Ӑ�d�q�����N�������v���ڒǉ�</br>
	/// </remarks>
	public class EmployeeAcs : IGeneralGuideData 
	{
		# region ��Private Member
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IEmployeeDB _iEmployeeDB = null;
        private IEmployeeDtlDB _iEmployeeDtlDB = null;

		/// <summary>���_��񕔕i</summary>
		private SecInfoAcs _secInfoAcs;

		//----- ueno rev ---------- start 2008.02.12
		/// <summary>���[�U�[�K�C�h�A�N�Z�X�N���X</summary>
        private UserGuideAcs _userGuideAcs;     
		//----- ueno rev ---------- end 2008.02.12
		// 2008.02.08 �폜 >>>>>>>>>>
        ///// <summary>���[�U�[�K�C�h�I�u�W�F�N�g�i�[�o�b�t�@(HashTable)</summary>
        //private Hashtable _userGdBdTable;
        ///// <summary>���[�U�[�K�C�h�I�u�W�F�N�g�i�[�o�b�t�@(ArrayList)</summary>
        //private ArrayList _userGdBdList;
        // 2008.02.08 �폜 <<<<<<<<<<
        /// <summary>�]�ƈ��}�X�^�N���XStatic</summary>
		private static Hashtable _employeeTable_Stc = null;
		/// <summary>�]�ƈ��}�X�^�N���XSearch�t���O</summary>
		private static bool _searchFlg;
		/// <summary>���_�I�v�V�����t���O</summary>
		private bool _optSection;

		/// <summary>�]�ƈ����[�J��DB�A�N�Z�X</summary>
		private EmployeeLcDB _employeeLcDB      = null;
		//----- ueno add ---------- start 2008.01.31
		/// <summary>�]�ƈ��ڍ׃��[�J��DB�A�N�Z�X</summary>
		private EmployeeDtlLcDB _employeeDtlLcDB = null;
		//----- ueno add ---------- end 2008.01.31

        /// <summary>�L���b�V��</summary>
        private static DataSet _localDataSet    =  null;

        private const string  LOCAL_EMPLOYEE_TABLE  = "localEmployeeTable";
        private const string  LOCAL_SECTIONCODE     = "���_�R�[�h";
        private const string  LOCAL_EMPLOYEECODE    = "�R�[�h";
        private const string  LOCAL_EMPLOYEE_RECORD = "record";

        /// <summary>���[�J���c�a���[�h</summary>
		//----- ueno upd ---------- start 2008.01.31
		private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g
		//----- ueno upd ---------- end 2008.01.31

        // 2010/02/18 Add >>>
        /// <summary>�t�F���J�Ǘ������[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IFeliCaMngDB _iFeliCaMngDB = null;
        /// <summary>�t�F���J�A�N�Z�X�I�v�V�����t���O</summary>
        private bool _optFeliCaAcs = false;
        /// <summary>�t�F���J�Ǘ��N���X���X�gStatic</summary>
        private static List<FeliCaMngWork> _felicaMngWkList_Stc = null;
        // 2010/02/18 Add <<<

		# endregion				    
		  
		# region ��Constracter
		/// <summary>
		/// �]�ƈ��e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �]�ƈ��e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 980076 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public EmployeeAcs()
		{
			// ��������������
			MemoryCreate();
			// ���_OP�̔���
			this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);

            // 2010/02/18 Add felica�I�v�V�����`�F�b�N >>>
            //this._optFeliCaAcs = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FelicaAccessService) > 0);
            this._optFeliCaAcs = true;
            // 2010/02/18 Add <<<

            // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ���O�C�����i�ŒʐM��Ԃ��m�F
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
            //        this._iEmployeeDtlDB = (IEmployeeDtlDB)MediationEmployeeDtlDB.GetEmployeeDtlDB();   // 2007.08.14 �ǉ�
            //    }
            //    catch (Exception)
            //    {				
            //        //�I�t���C������null���Z�b�g
            //        this._iEmployeeDB = null;
            //        this._iEmployeeDtlDB = null;    // 2007.08.14 �ǉ�
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
                this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
                this._iEmployeeDtlDB = (IEmployeeDtlDB)MediationEmployeeDtlDB.GetEmployeeDtlDB();   // 2007.08.14 �ǉ�
                this._iFeliCaMngDB = (IFeliCaMngDB)MediationFeliCaMngDB.GetFeliCaMngDB();   // 2010/02/18 Add
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iEmployeeDB = null;
                this._iEmployeeDtlDB = null;    // 2007.08.14 �ǉ�
            }
            // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g
            this._employeeLcDB = new EmployeeLcDB();

			//----- ueno add ---------- start 2008.01.31
			// �]�ƈ��ڍ׃��[�J��DB�A�N�Z�X�I�u�W�F�N�g
			this._employeeDtlLcDB = new EmployeeDtlLcDB();
			//----- ueno add ---------- end 2008.01.31

            if (_localDataSet == null)
            {
                _localDataSet = new DataSet();
                DataTable dt = new DataTable(LOCAL_EMPLOYEE_TABLE);
                dt.Columns.Add(LOCAL_SECTIONCODE    , typeof(string));
                dt.Columns.Add(LOCAL_EMPLOYEECODE   , typeof(string));
                dt.Columns.Add(LOCAL_EMPLOYEE_RECORD, typeof(EmployeeWork));
                _localDataSet.Tables.Add(dt);
            }
		}
		# endregion

        // ----- iitani a ---------- start 2007.05.26 
        //================================================================================
        //  �v���p�e�B
        //================================================================================
        #region Public Property

        /// <summary>
        /// ���[�J���c�aRead���[�h
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        #endregion
        // ----- iitani a ---------- end 2007.05.25 

		# region ��public int GetOnlineMode()
		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iEmployeeDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}
		# endregion

		#region ��Public Method
		/// <summary>
		/// �]�ƈ��}�X�^Static�������S���擾����
		/// </summary>
		/// <param name="retList">�]�ƈ��N���XList</param>
		/// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��}�X�^Static�������̑S�����擾���܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList)
		{
			retList = new ArrayList();
			retList.Clear();
			SortedList sortedList = new SortedList();

			if (_employeeTable_Stc == null)
			{
				return -1;
			}
			else if (_employeeTable_Stc.Count == 0)
			{
				return 9;
			}

			foreach (Employee employee in _employeeTable_Stc.Values)
			{
				sortedList.Add(employee.EmployeeCode, employee);
			}

			retList.AddRange(sortedList.Values);

			return 0;
		}

		/// <summary>
		/// �]�ƈ��}�X�^Static�������擾����
		/// </summary>
		/// <param name="employee">�]�ƈ��N���X</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 4:�f�[�^����)</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��}�X�^Static���������������܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int ReadStaticMemory(out Employee employee, string employeeCode)
		{
			employee = new Employee();

			if (_employeeTable_Stc == null)
			{
				return -1;
			}

			// Static���猟��
			if (_employeeTable_Stc[employeeCode.TrimEnd()] == null)
			{
				return 4;
			}
			else
			{
				employee = (Employee)_employeeTable_Stc[employeeCode.TrimEnd()];
			}
			
			return 0;
		}

		/// <summary>
		/// �]�ƈ��}�X�^Static���������I�t���C���������ݏ���
		/// </summary>
		/// <param name="sender">object�i�ďo���I�u�W�F�N�g�j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��}�X�^Static�������̏������[�J���t�@�C���ɕۑ����܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		public int WriteOfflineData(object sender)
		{
			// �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			int status;

			// KeyList�ݒ�
			string[] employeeKeys = new string[1];
			employeeKeys[0] = LoginInfoAcquisition.EnterpriseCode;

			SortedList sortedList = new SortedList();
			EmployeeWork employeeWork = new EmployeeWork();
			foreach (Employee employee in _employeeTable_Stc.Values)
			{
				// �N���X �� ���[�J�[�N���X
				employeeWork = CopyToEmployeeWorkFromEmployee(employee);

				// Sort
				sortedList.Add(employee.EmployeeCode, employeeWork);
			}

			ArrayList employeeWorkList = new ArrayList();  
			employeeWorkList.AddRange(sortedList.Values);
				
			status = offlineDataSerializer.Serialize("EmployeeAcs", employeeKeys, employeeWorkList);

            // 2010/02/18 Add >>>
            if ((status == 0) && (_optFeliCaAcs))
            {
                ArrayList felicaAL = new ArrayList();
                if (_felicaMngWkList_Stc == null)
                {
                    SearchAll_FeliCa(out _felicaMngWkList_Stc, LoginInfoAcquisition.EnterpriseCode);
                }

                if (_felicaMngWkList_Stc != null)
                {
                    foreach (FeliCaMngWork wk in _felicaMngWkList_Stc)
                    {
                        felicaAL.Add(wk);
                    }
                    employeeKeys[0] += "_felica";
                    status = offlineDataSerializer.Serialize("EmployeeAcs", employeeKeys, felicaAL);
                }
            }
            // 2010/02/18 Add <<<

			return status;
		}

		/// <summary>
		/// �]�ƈ��ǂݍ��ݏ���
		/// </summary>
		/// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <returns>�]�ƈ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ�����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Read(out Employee employee, string enterpriseCode, string employeeCode)
		{			
			try
			{
				int status;
				employee = null;
				EmployeeWork employeeWork = new EmployeeWork();
				employeeWork.EnterpriseCode = enterpriseCode;
				employeeWork.EmployeeCode = employeeCode;

                // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// �I�����C���̏ꍇ�����[�g�擾
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    // XML�֕ϊ����A������̃o�C�i����
					byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

					//�]�ƈ��ǂݍ���
					// ----- iitani c ---------- start 2007.05.26
                    //status = this._iEmployeeDB.Read(ref parabyte,0);
                    if (_isLocalDBRead == true)
                    {
                        // ���[�J��
                        status = this._employeeLcDB.Read(ref employeeWork, 0);
                    }
                    else
                    {
                        // �����[�g
                        status = this._iEmployeeDB.Read(ref parabyte, 0);
                    }
                    // ----- iitani c ---------- end 2007.05.26

					if (status == 0)
					{
    					// ----- iitani a ---------- start 2007.05.26
                        //employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
                        if (_isLocalDBRead == false)
                        {
                            // XML�̓ǂݍ���
                            employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
                        }
                        // ----- iitani c ---------- end 2007.05.26

                        // �N���X�������o�R�s�[
						employee = CopyToEmployeeFromEmployeeWork(employeeWork);
						// Read�pStatic�ɕێ�
						_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
					}
                // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //}
                //else	// �I�t���C���̏ꍇ�L���b�V������擾
                //{
                //    status = ReadStaticMemory(out employee, employeeCode);
                //}
                // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				employee = null;
				//�I�t���C������null���Z�b�g
				this._iEmployeeDB = null;
				return -1;
			}
		}

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// �]�ƈ��ǂݍ��ݏ���
        ///// </summary>
        ///// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
        ///// <param name="employeeDtl">�]�ƈ��ڍ׃I�u�W�F�N�g</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="employeeCode">�]�ƈ��R�[�h</param>
        ///// <returns>�]�ƈ��N���X</returns>
        ///// <remarks>
        ///// <br>Note       : �]�ƈ�����ǂݍ��݂܂��B</br>
        ///// <br>Programmer : 30414 �E �K�j</br>
        ///// <br>Date       : 2008/06/04</br>
        ///// </remarks>
        //public int Read(out Employee employee, out EmployeeDtl employeeDtl, string enterpriseCode, string employeeCode)
        //{
        //    try
        //    {
        //        int status;
        //        employee = null;
        //        employeeDtl = null;
        //        EmployeeWork employeeWork = new EmployeeWork();
        //        employeeWork.EnterpriseCode = enterpriseCode;
        //        employeeWork.EmployeeCode = employeeCode;

        //        EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();
        //        employeeDtlWork.EnterpriseCode = enterpriseCode;
        //        employeeDtlWork.EmployeeCode = employeeCode;

        //        // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //        //// �I�����C���̏ꍇ�����[�g�擾
        //        //if (LoginInfoAcquisition.OnlineFlag)
        //        //{
        //        // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //            // XML�֕ϊ����A������̃o�C�i����
        //            byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

        //            //�]�ƈ��ǂݍ���
        //            if (_isLocalDBRead == true)
        //            {
        //                // ���[�J��
        //                status = this._employeeLcDB.Read(ref employeeWork, 0);
        //            }
        //            else
        //            {
        //                // �����[�g
        //                status = this._iEmployeeDB.Read(ref parabyte, 0);
        //            }

        //            if (status == 0)
        //            {
        //                if (_isLocalDBRead == false)
        //                {
        //                    // XML�̓ǂݍ���
        //                    employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
        //                }

        //                // �N���X�������o�R�s�[
        //                employee = CopyToEmployeeFromEmployeeWork(employeeWork);
        //                // Read�pStatic�ɕێ�
        //                _employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
        //            }

        //            // �]�ƈ��ڍ׌���
        //            object objectEmployeeDtlWork = null;
        //            ArrayList paraList2;

        //            // ���[�J��
        //            if (_isLocalDBRead)
        //            {
        //                List<EmployeeDtlWork> employeeDtlWorkList = new List<EmployeeDtlWork>();
        //                status = this._employeeDtlLcDB.Search(out employeeDtlWorkList, employeeDtlWork, 0, 0);

        //                if (status == 0)
        //                {
        //                    ArrayList al = new ArrayList();
        //                    al.AddRange(employeeDtlWorkList);
        //                    objectEmployeeDtlWork = (object)al;
        //                }
        //            }
        //            // �����[�g
        //            else
        //            {
        //                status = this._iEmployeeDtlDB.Search(out objectEmployeeDtlWork, employeeDtlWork, 0, 0);
        //            }

        //            if (status == 0)
        //            {
        //                // �]�ƈ��ڍ׃��[�J�[�N���X��UI�N���XStatic�]�L����
        //                CopyToStaticFromWorker2(objectEmployeeDtlWork as ArrayList);
                        
        //                // �p�����[�^���n���ė��Ă��邩�m�F
        //                paraList2 = objectEmployeeDtlWork as ArrayList;
        //                EmployeeDtlWork[] wkEmployeeDtlWork = new EmployeeDtlWork[paraList2.Count];

        //                // �f�[�^�����ɖ߂�
        //                for (int i = 0; i < paraList2.Count; i++)
        //                {
        //                    employeeDtlWork = (EmployeeDtlWork)paraList2[i];
        //                    if ((employeeDtlWork.LogicalDeleteCode == 0) && (employeeDtlWork.EmployeeCode.Trim() == employeeCode.Trim()))
        //                    {
        //                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
        //                    }
        //                }
        //            }
        //        // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //        //}
        //        //else	// �I�t���C���̏ꍇ�L���b�V������擾
        //        //{
        //        //    status = ReadStaticMemory(out employee, employeeCode);
        //        //}
        //        // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        //        return status;
        //    }
        //    catch (Exception)
        //    {
        //        //�ʐM�G���[��-1��߂�
        //        employee = null;
        //        employeeDtl = null;
        //        //�I�t���C������null���Z�b�g
        //        this._iEmployeeDB = null;
        //        return -1;
        //    }
        //}


        /// <summary>
        /// �]�ƈ��ǂݍ��ݏ���
        /// </summary>
        /// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ��N���X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ�����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/06/04</br>
        /// </remarks>
        public int Read(out Employee employee, out EmployeeDtl employeeDtl, string enterpriseCode, string employeeCode)
        {
            try
            {
                int status;
                employee = null;
                employeeDtl = null;
                EmployeeWork employeeWork = new EmployeeWork();
                employeeWork.EnterpriseCode = enterpriseCode;
                employeeWork.EmployeeCode = employeeCode;

                EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();
                employeeDtlWork.EnterpriseCode = enterpriseCode;
                employeeDtlWork.EmployeeCode = employeeCode;

                // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// �I�����C���̏ꍇ�����[�g�擾
                //if (LoginInfoAcquisition.OnlineFlag)
                //{
                // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

                //�]�ƈ��ǂݍ���
                if (_isLocalDBRead == true)
                {
                    // ���[�J��
                    status = this._employeeLcDB.Read(ref employeeWork, 0);
                }
                else
                {
                    // �����[�g
                    status = this._iEmployeeDB.Read(ref parabyte, 0);
                }

                if (status == 0)
                {
                    if (_isLocalDBRead == false)
                    {
                        // XML�̓ǂݍ���
                        employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeWork));
                    }

                    // �N���X�������o�R�s�[
                    employee = CopyToEmployeeFromEmployeeWork(employeeWork);
                    // Read�pStatic�ɕێ�
                    _employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
                }

                // �]�ƈ��ڍ׌���
                object objectEmployeeDtlWork = null;
                ArrayList paraList2;

                // ���[�J��
                if (_isLocalDBRead)
                {
                    List<EmployeeDtlWork> employeeDtlWorkList = new List<EmployeeDtlWork>();
                    status = this._employeeDtlLcDB.Search(out employeeDtlWorkList, employeeDtlWork, 0, 0);

                    if (status == 0)
                    {
                        ArrayList al = new ArrayList();
                        al.AddRange(employeeDtlWorkList);
                        objectEmployeeDtlWork = (object)al;
                    }
                }
                // �����[�g
                else
                {
                    status = this._iEmployeeDtlDB.Search(out objectEmployeeDtlWork, employeeDtlWork, 0, 0);
                }

                if (status == 0)
                {
                    // �]�ƈ��ڍ׃��[�J�[�N���X��UI�N���XStatic�]�L����
                    CopyToStaticFromWorker2(objectEmployeeDtlWork as ArrayList);

                    // �p�����[�^���n���ė��Ă��邩�m�F
                    paraList2 = objectEmployeeDtlWork as ArrayList;
                    EmployeeDtlWork[] wkEmployeeDtlWork = new EmployeeDtlWork[paraList2.Count];

                    // �f�[�^�����ɖ߂�
                    for (int i = 0; i < paraList2.Count; i++)
                    {
                        employeeDtlWork = (EmployeeDtlWork)paraList2[i];
                        if ((employeeDtlWork.LogicalDeleteCode == 0) && (employeeDtlWork.EmployeeCode.Trim() == employeeCode.Trim()))
                        {
                            employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
                        }
                    }
                }
                // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //}
                //else	// �I�t���C���̏ꍇ�L���b�V������擾
                //{
                //    status = ReadStaticMemory(out employee, employeeCode);
                //}
                // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                employee = null;
                employeeDtl = null;
                //�I�t���C������null���Z�b�g
                this._iEmployeeDB = null;
                return -1;
            }
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// �]�ƈ��N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�]�ƈ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public Employee Deserialize(string fileName)
		{
			Employee employee = null;

			// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
			EmployeeWork employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(fileName,typeof(EmployeeWork));

			//�f�V���A���C�Y���ʂ��]�ƈ��N���X�փR�s�[
			if (employeeWork != null) employee = CopyToEmployeeFromEmployeeWork(employeeWork);

			return employee;
		}

        /// <summary>
		/// �]�ƈ�List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>�]�ƈ��N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();

			// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
			EmployeeWork[] employeeWorks = (EmployeeWork[])XmlByteSerializer.Deserialize(fileName,typeof(EmployeeWork[]));

			//�f�V���A���C�Y���ʂ��]�ƈ��N���X�փR�s�[
			if (employeeWorks != null) 
			{
				al.Capacity = employeeWorks.Length;
				for(int i=0; i < employeeWorks.Length; i++)
				{
					al.Add(CopyToEmployeeFromEmployeeWork(employeeWorks[i]));
				}
			}

			return al;
		}

		/// <summary>
		/// �]�ƈ��o�^�E�X�V����
		/// </summary>
		/// <param name="employee">�]�ƈ��N���X</param>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃N���X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
        //public int Write(ref Employee employee)
        public int Write(ref Employee employee, ref EmployeeDtl employeeDtl)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
			//�]�ƈ��N���X����]�ƈ����[�J�[�N���X�Ƀ����o�R�s�[
			EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
            EmployeeDtlWork employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(employeeDtl);

            // XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

			int status = 0;
			try
			{
				//�]�ƈ���������
				status = this._iEmployeeDB.Write(ref parabyte);
				if (status == 0)
				{
					// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
					employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
					// �N���X�������o�R�s�[
					employee = CopyToEmployeeFromEmployeeWork(employeeWork);
					// Static�f�[�^�X�V
					_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
                    
                    // 2007.08.14 �ǉ� >>>>>>>>>>
                    //�]�ƈ��ڍ׏�������
                    ArrayList wklist = new ArrayList();
                    wklist.Add(employeeDtlWork);
                    Object listobj = wklist;
                    status = this._iEmployeeDtlDB.Write(ref listobj);
                    if (status == 0)
                    {
                        // �N���X�������o�R�s�[
                        wklist = (ArrayList)listobj;
                        //employeeDtlWork = (EmployeeDtlWork)listobj;
                        employeeDtlWork = wklist[0] as EmployeeDtlWork;
                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
                        // Static�f�[�^�X�V
                        //_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employeeDtl;
                    }
                    // 2007.08.14 �ǉ� <<<<<<<<<<
                }
            }
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iEmployeeDB = null;
                //�ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �]�ƈ��V���A���C�Y����
		/// </summary>
		/// <param name="employee">�V���A���C�Y�Ώۏ]�ƈ��N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �]�ƈ����̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public void Serialize(Employee employee,string fileName)
		{
			//�]�ƈ��N���X����]�ƈ����[�J�[�N���X�Ƀ����o�R�s�[
			EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
			//�]�ƈ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(employeeWork,fileName);
		}

        /// <summary>
		/// �]�ƈ�List�V���A���C�Y����
		/// </summary>
		/// <param name="employees">�V���A���C�Y�Ώۏ]�ƈ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �]�ƈ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public void ListSerialize(ArrayList employees,string fileName)
		{
			EmployeeWork[] employeeWorks = new EmployeeWork[employees.Count];
			for(int i= 0; i < employees.Count; i++)
			{
				employeeWorks[i] = CopyToEmployeeWorkFromEmployee((Employee)employees[i]);
			}
			//�]�ƈ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(employeeWorks,fileName);
		}

		/// <summary>
		/// �]�ƈ��_���폜����
		/// </summary>
		/// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃N���X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����̘_���폜���s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
		//public int LogicalDelete(ref Employee employee)
        public int LogicalDelete(ref Employee employee, ref EmployeeDtl employeeDtl)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
			try
			{
				// 2005.11.16 ADD UENO////////////////////////////////////////////////////////////
                //// ���Ɛݒ�ɂăZ�b�g��Ƃ��g���Ă��Ȃ�������
                //ArrayList mainWorkList = null;
                //MainworkAcs mainworkAcs = new MainworkAcs();
                //mainworkAcs.SearchAllMainwork( out mainWorkList, employee.EnterpriseCode);
                //foreach(MainWork mainWork in mainWorkList)
                //{
                //    if (mainWork.EmployeeCode.TrimEnd() == employee.EmployeeCode.TrimEnd())
                //    {
                //        return -2;
                //    }
                //}
				// 2005.11.16 END UENO////////////////////////////////////////////////////////////

				EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);
				// �]�ƈ��_���폜
				int status = this._iEmployeeDB.LogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
					employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
					// �N���X�������o�R�s�[
					employee = CopyToEmployeeFromEmployeeWork(employeeWork);
					// Static�X�V
					_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee.Clone();


                    // 2007.08.14 �ǉ� >>>>>>>>>>
                    EmployeeDtlWork employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(employeeDtl);
                    ArrayList wklist = new ArrayList();
                    wklist.Add(employeeDtlWork);
                    Object listobj = wklist;
                    // �]�ƈ��_���폜
                    int status2 = this._iEmployeeDtlDB.LogicalDelete(ref listobj);

                    if (status2 == 0)
                    {
                        // �N���X�������o�R�s�[
                        wklist = (ArrayList)listobj;
                        //employeeDtlWork = (EmployeeDtlWork)listobj;
                        employeeDtlWork = wklist[0] as EmployeeDtlWork;
                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
                        // Static�X�V
                        //_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee.Clone();
                    }
                    // 2007.08.14 �ǉ� <<<<<<<<<<
                }

                return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iEmployeeDB = null;
                //�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �]�ƈ������폜����
		/// </summary>
		/// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃N���X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����̕����폜���s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
        //public int Delete(Employee employee)
        public int Delete(Employee employee, EmployeeDtl employeeDtl)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
			try
			{
				EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);
				// �]�ƈ������폜
				int status = this._iEmployeeDB.Delete(parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
					employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
					// �N���X�������o�R�s�[
					employee = CopyToEmployeeFromEmployeeWork(employeeWork);
					// Static�X�V
					_employeeTable_Stc.Remove(employee.EmployeeCode.TrimEnd());


                    // 2007.08.14 �ǉ� >>>>>>>>>>
                    EmployeeDtlWork employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(employeeDtl);
	    			// XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte2 = XmlByteSerializer.Serialize(employeeDtlWork);
                    // �]�ƈ������폜
                    int status2 = this._iEmployeeDtlDB.Delete(parabyte2);

    				if (status2 == 0)
	    			{
			    		// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
                        employeeDtlWork = (EmployeeDtlWork)XmlByteSerializer.Deserialize(parabyte2, typeof(EmployeeDtlWork));
                        // �N���X�������o�R�s�[
                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
    					// Static�X�V
	    				//_employeeTable_Stc.Remove(employee.EmployeeCode.TrimEnd());
                    }
                    // 2007.08.14 �ǉ� <<<<<<<<<<
                }

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iEmployeeDB = null;
                //�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �]�ƈ����������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ������������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,0);
		}

		/// <summary>
		/// �]�ƈ����������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ������������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// �]�ƈ�����������
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����̌������s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			EmployeeWork employeeWork = new EmployeeWork();
			employeeWork.EnterpriseCode = enterpriseCode;
			
			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);

			// �]�ƈ�����
            // ----- iitani c ---------- start 2007.05.26
			//int status = this._iEmployeeDB.SearchCnt(out retTotalCnt,parabyte,0,logicalMode);
            int status = 0;
            if (_isLocalDBRead)
            {
                status = this._employeeLcDB.SearchCnt(out retTotalCnt, employeeWork, 0, logicalMode);
            }
            else
            {
                status = this._iEmployeeDB.SearchCnt(out retTotalCnt,parabyte,0,logicalMode);
            }
            // ----- iitani c ---------- end 2007.05.26

			if (status != 0) retTotalCnt = 0;
				
			return status;
		}

		/// <summary>
		/// �]�ƈ��S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retList2">�Ǎ����ʃR���N�V����(�ڍ�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
        //public int Search(out ArrayList retList, string enterpriseCode)
        public int Search(out ArrayList retList, out ArrayList retList2, string enterpriseCode)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
			bool nextData;
			int  retTotalCnt;
            // 2007.08.14 �C�� >>>>>>>>>>
            //return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null);
            return SearchProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, 0, 0, null, null);
            // 2007.08.14 �C�� <<<<<<<<<<
        }

		/// <summary>
		/// �]�ƈ����������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retList2">�Ǎ����ʃR���N�V����(�ڍ�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
        //public int SearchAll(out ArrayList retList, string enterpriseCode)
        public int SearchAll(out ArrayList retList, out ArrayList retList2, string enterpriseCode)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
			bool nextData;
			int	 retTotalCnt;
            // 2007.08.14 �C�� >>>>>>>>>>
            //return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
            return SearchProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, null);
            // 2007.08.14 �C�� <<<<<<<<<<
        }

		/// <summary>
		/// �����w��]�ƈ����������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retList2">�Ǎ����ʃR���N�V����(�ڍ�)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevEmployee">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
        /// <param name="prevEmployeeDtl">�O��ŏI�S���ҏڍ׃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ď]�ƈ��̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
        //public int Search(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, Employee prevEmployee)
        public int Search(out ArrayList retList, out ArrayList retList2, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, Employee prevEmployee, EmployeeDtl prevEmployeeDtl)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
            // 2007.08.14 �C�� >>>>>>>>>>
            //return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevEmployee);
            return SearchProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, 0, readCnt, prevEmployee, prevEmployeeDtl);
            // 2007.08.14 �C�� <<<<<<<<<<
        }

		/// <summary>
		/// �����w��]�ƈ����������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retList2">�Ǎ����ʃR���N�V����(�ڍ�)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevEmployee">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
        /// <param name="prevEmployeeDtl">�O��ŏI�S���ҏڍ׃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ď]�ƈ��̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
        //public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, Employee prevEmployee)
        public int SearchAll(out ArrayList retList, out ArrayList retList2, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, Employee prevEmployee, EmployeeDtl prevEmployeeDtl)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
            // 2007.08.14 �C�� >>>>>>>>>>
            //return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevEmployee);
            return SearchProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevEmployee, prevEmployeeDtl);
            // 2007.08.14 �C�� <<<<<<<<<<
        }

		/// <summary>
		/// �]�ƈ��_���폜��������
		/// </summary>
		/// <param name="employee">�]�ƈ��I�u�W�F�N�g</param>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����̕������s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
        //public int Revival(ref Employee employee)
        public int Revival(ref Employee employee, ref EmployeeDtl employeeDtl)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
			try
			{
				EmployeeWork employeeWork = CopyToEmployeeWorkFromEmployee(employee);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(employeeWork);
				// ��������
				int status = this._iEmployeeDB.RevivalLogicalDelete(ref parabyte);

				if (status == 0)
				{
					// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
					employeeWork = (EmployeeWork)XmlByteSerializer.Deserialize(parabyte,typeof(EmployeeWork));
					// �N���X�������o�R�s�[
					employee = CopyToEmployeeFromEmployeeWork(employeeWork);
					// Static�X�V
					_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;


                    // 2007.08.14 �ǉ� >>>>>>>>>>
                    EmployeeDtlWork employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(employeeDtl);
	    			// XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte2 = XmlByteSerializer.Serialize(employeeDtlWork);
			    	// ��������
                    ArrayList wklist = new ArrayList();
                    wklist.Add(employeeDtlWork);
                    Object listobj = wklist;
                    int status2 = this._iEmployeeDtlDB.RevivalLogicalDelete(ref listobj);

    				if (status2 == 0)
	    			{
				    	// �N���X�������o�R�s�[
                        wklist = (ArrayList)listobj;
                        //employeeDtlWork = (EmployeeDtlWork)listobj;
                        employeeDtlWork = wklist[0] as EmployeeDtlWork;
                        employeeDtl = CopyToEmployeeDtlFromEmployeeDtlWork(employeeDtlWork);
    					// Static�X�V
	    				//_employeeTable_Stc[employee.EmployeeCode.TrimEnd()] = employee;
                        // 2007.08.14 �ǉ� <<<<<<<<<<
			    	}
                }

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iEmployeeDB = null;
                //�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �]�ƈ����������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="belongSectionCode">���_�R�[�h</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="frontMechaCode">��t�E���J�敪[-1:�S��,0:��t,1:���J,2:�c��]</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode, string belongSectionCode, int frontMechaCode)
		{
			EmployeeWork employeeWork = new EmployeeWork();
			employeeWork.EnterpriseCode = enterpriseCode;

			ArrayList ar = new ArrayList();

			int status = 0;
			object objectEmployeeWork;

            //// �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
            //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
            //{
            //    // �]�ƈ��T�[�`
            //    // ----- iitani c ---------- start 2007.05.26
            //    //status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, ConstantManagement.LogicalMode.GetData01);
            //    if (_isLocalDBRead)
            //    {
            //        List<EmployeeWork> employeeList;
            //        EmployeeWork paraEmp = new EmployeeWork();
            //        paraEmp.EnterpriseCode = enterpriseCode;
            //        paraEmp.BelongSectionCode = belongSectionCode;

            //        status = this._employeeLcDB.Search(out employeeList, paraEmp, 0, ConstantManagement.LogicalMode.GetData0);
            //        ArrayList convList = new ArrayList();
            //        convList.AddRange(employeeList);
            //        objectEmployeeWork = (object)convList;
            //    }
            //    else
            //    {
            //        status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, ConstantManagement.LogicalMode.GetData0);
            //    }
            //    // ----- iitani c ---------- end 2007.05.26
            //    if (status == 0)
            //    {
            //        // �]�ƈ����[�J�[�N���X��UI�N���XStatic�]�L����
            //        CopyToStaticFromWorker(objectEmployeeWork as ArrayList);
            //        // SearchFlg ON
            //        _searchFlg = true;
            //    }
            //    else
            //    {
            //        return status;
            //    }
            //}

            // �]�ƈ��T�[�`
            // ----- iitani c ---------- start 2007.05.26
            //status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, ConstantManagement.LogicalMode.GetData01);
            if (_isLocalDBRead)
            {
                List<EmployeeWork> employeeList;
                EmployeeWork paraEmp = new EmployeeWork();
                paraEmp.EnterpriseCode = enterpriseCode;
                paraEmp.BelongSectionCode = belongSectionCode;

                status = this._employeeLcDB.Search(out employeeList, paraEmp, 0, ConstantManagement.LogicalMode.GetData0);
                ArrayList convList = new ArrayList();
                convList.AddRange(employeeList);
                objectEmployeeWork = (object)convList;
            }
            else
            {
                status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, ConstantManagement.LogicalMode.GetData0);
            }
            ArrayList retWorkList; 
            // ----- iitani c ---------- end 2007.05.26
            if (status == 0)
            {
                retWorkList = objectEmployeeWork as ArrayList;
                // �]�ƈ����[�J�[�N���X��UI�N���XStatic�]�L����
                CopyToStaticFromWorker(retWorkList);
                // SearchFlg ON
                _searchFlg = true;
            }
            else
            {
                return status;
            }

            ArrayList retList = new ArrayList();
            foreach (EmployeeWork work in retWorkList)
            {
                // ���[�U�[�Ǘ��ҋ敪��0�̏]�ƈ����K�C�h�\��
                if (work.UserAdminFlag == 0)
                {
                    retList.Add(CopyToEmployeeFromEmployeeWork(work));
                }
            }
            foreach (EmployeeWork work in retWorkList)
            {
                // ���[�U�[�Ǘ��ҋ敪��0�̏]�ƈ����K�C�h�\��
                if (work.UserAdminFlag == 0)
                {
                    Employee employee = CopyToEmployeeFromEmployeeWork(work);
                    employee.BelongSectionCode = "00";
                    employee.BelongSectionName = "";
                    retList.Add(employee);
                }
            }

            SortedList sl = new SortedList();  // iitani a 2007.05.29

			// Static����K�C�h�\���i�I��/�I�t���ʁj	
            foreach (Employee employeeWk in retList)
			{
				// ArrayList�փ����o�R�s�[
				if (belongSectionCode.Trim() == "")
				{
					// �S�Е\��
                    // ----- iitani c ---------- start 2007.05.29
                    //ar.Add(employeeWk.Clone());
                    sl.Add(employeeWk.Clone().EmployeeCode, employeeWk.Clone());
                    // ----- iitani c ---------- end 2007.05.29
				}
				else if (belongSectionCode.TrimEnd().Equals(employeeWk.BelongSectionCode.TrimEnd()))
				{
					// �Y�����_�̒S����
                    // ----- iitani c ---------- start 2007.05.29
                    //ar.Add(employeeWk.Clone());
                    sl.Add(employeeWk.Clone().EmployeeCode, employeeWk.Clone());
                    // ----- iitani c ---------- end 2007.05.29
				}
			}

            ar.AddRange(sl.Values);  // iitani a 2007.05.29

			// --- 2007.03.29 men add sta ------------------------------------------- //
			Employee[] employees = new Employee[ar.Count];

			// �f�[�^�����ɖ߂�
			for (int i = 0; i < ar.Count; i++)
			{
				employees[i] = (Employee)ar[i];
			}

			byte[] retbyte = XmlByteSerializer.Serialize(employees);
			XmlByteSerializer.ReadXml(ref ds, retbyte);
			// --- 2007.03.29 men add end ------------------------------------------- //

			//ArrayList wkList = ar.Clone() as ArrayList;
			//SortedList wkSort = new SortedList();

			// --- ��������f�[�^�I�� --- //
			// ��t�E���J�敪[-1:�S��,0:��t,1:���J,2:�c��]����
			//switch (frontMechaCode)
			//{
			//    case 0:
			//    {
			//        // --- [��t]�̂� --- //
			//        foreach (Employee wkEmployee in wkList)
			//        {
			//            if ((wkEmployee.FrontMechaCode == 0) &&
			//                    (wkEmployee.LogicalDeleteCode == 0))
			//            {
			//                wkSort.Add(wkEmployee.EmployeeCode, wkEmployee);
			//            }
			//        }

			//        break;
			//    }
			//    case 1:
			//    {
			//        // --- [���J]�̂� --- //
			//        foreach (Employee wkEmployee in wkList)
			//        {
			//            if ((wkEmployee.FrontMechaCode == 1) &&
			//                    (wkEmployee.LogicalDeleteCode == 0))
			//            {
			//                wkSort.Add(wkEmployee.EmployeeCode, wkEmployee);
			//            }
			//        }

			//        break;
			//    }
			//    case 2:
			//    {
			//        // --- [�c��]�̂� --- //
			//        foreach (Employee wkEmployee in wkList)
			//        {
			//            if ((wkEmployee.FrontMechaCode == 2) &&
			//                    (wkEmployee.LogicalDeleteCode == 0))
			//            {
			//                wkSort.Add(wkEmployee.EmployeeCode, wkEmployee);
			//            }
			//        }

			//        break;
			//    }
			//    default:
			//    {
			//        // --- [�S��] --- //
			//        // ���̂܂ܑS���Ԃ�
			//        foreach (Employee wkEmployee in wkList)
			//        {
			//            if (wkEmployee.LogicalDeleteCode == 0)
			//            {
			//                wkSort.Add(wkEmployee.EmployeeCode, wkEmployee);
			//            }
			//        }

			//        break;
			//    }
			//}

			//Employee[] employees = new Employee[wkSort.Count];

			// �f�[�^�����ɖ߂�
			//for (int i=0; i < wkSort.Count; i++)
			//{
			//    employees[i] = (Employee)wkSort.GetByIndex(i);
			//}

			//byte[] retbyte = XmlByteSerializer.Serialize(employees);
			//XmlByteSerializer.ReadXml(ref ds, retbyte);

			return status;
		}

        // 2010/02/18 Add >>>
        /// <summary>
        /// �t�F���J�Ǘ��X�^�e�B�b�N�L���b�V���X�V
        /// </summary>
        /// <param name="item">�X�V����f�[�^</param>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ��X�^�e�B�b�N�L���b�V�����X�V���܂�</br>
        /// <br>Programer  : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private bool Remove_felicaMngWkList_Stc(FeliCaMngWork item)
        {
            FeliCaMngWork target;
            target = _felicaMngWkList_Stc.Find(delegate(FeliCaMngWork felicaMngWk)
            {
                return ((felicaMngWk.FeliCaMngKind == item.FeliCaMngKind) && (felicaMngWk.FeliCaIDm == item.FeliCaIDm));
            });
            if (target == null) return true;
            return _felicaMngWkList_Stc.Remove(target);
        }

        /// <summary>
        /// �t�F���J�Ǘ���������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ��̌����������s���܂��B</br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/02/18</br>
        /// </remarks>
        private int SearchProc_Felica(out List<FeliCaMngWork> retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            FeliCaMngWork feliCaMngWork = new FeliCaMngWork();
            feliCaMngWork.EnterpriseCode = enterpriseCode;  // ��ƃR�[�h
            feliCaMngWork.FeliCaMngKind = 1;                // �]�ƈ��̂�
            retList = new List<FeliCaMngWork>();

            int status;
            object paraobj = (object)feliCaMngWork;

            // �I�t���C���̏ꍇ�̓L���b�V������ǂ�
            if (!LoginInfoAcquisition.OnlineFlag)
            {
                status = SearchStaticMemory_FeliCa(out retList);
            }
            else
            {
                object objectFeliCaMngWork = null;

                // �t�F���J�Ǘ�����
                status = this._iFeliCaMngDB.Search(out objectFeliCaMngWork, paraobj, logicalMode);

                if (objectFeliCaMngWork == null) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                if (status == 0)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    _felicaMngWkList_Stc = new List<FeliCaMngWork>();
                    foreach (FeliCaMngWork felicaMngWk in (ArrayList)objectFeliCaMngWork)
                    {
                        retList.Add(felicaMngWk);
                    }
                }
            }
            return status;
        }
        // 2010/02/18 Add <<<

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�]�ƈ����[�N�N���X�ˏ]�ƈ��N���X�j
		/// </summary>
		/// <param name="employeeWork">�]�ƈ����[�N�N���X</param>
		/// <returns>�]�ƈ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����[�N�N���X����]�ƈ��N���X�փ����o�[�̃R�s�[���s���܂��B�i���C�A�E�g���̂݁j</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.15</br>
		/// </remarks>
		public static Employee CopyToEmployee(EmployeeWork employeeWork)
		{
			Employee employee = new Employee();

			employee.CreateDateTime			= employeeWork.CreateDateTime;
			employee.UpdateDateTime			= employeeWork.UpdateDateTime;
			employee.EnterpriseCode			= employeeWork.EnterpriseCode;
			employee.FileHeaderGuid			= employeeWork.FileHeaderGuid;
			employee.UpdEmployeeCode		= employeeWork.UpdEmployeeCode;
			employee.UpdAssemblyId1			= employeeWork.UpdAssemblyId1;
			employee.UpdAssemblyId2			= employeeWork.UpdAssemblyId2;
			employee.LogicalDeleteCode		= employeeWork.LogicalDeleteCode;

			employee.EmployeeCode			= employeeWork.EmployeeCode;
			employee.Name					= employeeWork.Name;
			employee.Kana					= employeeWork.Kana;
			employee.ShortName				= employeeWork.ShortName;
			employee.SexCode				= employeeWork.SexCode;
			employee.SexName				= employeeWork.SexName;
			employee.Birthday				= employeeWork.Birthday;
			employee.CompanyTelNo			= employeeWork.CompanyTelNo;
			employee.PortableTelNo			= employeeWork.PortableTelNo;
			employee.PostCode				= employeeWork.PostCode;
			employee.BusinessCode			= employeeWork.BusinessCode;
            //employee.FrontMechaCode			= employeeWork.FrontMechaCode;
			employee.InOutsideCompanyCode	= employeeWork.InOutsideCompanyCode;
			employee.BelongSectionCode		= employeeWork.BelongSectionCode;
            //employee.LvrRtCstGeneral		= employeeWork.LvrRtCstGeneral;
            //employee.LvrRtCstCarInspect		= employeeWork.LvrRtCstCarInspect;
            //employee.LvrRtCstBodyRepair		= employeeWork.LvrRtCstBodyRepair;
            //employee.LvrRtCstBodyPaint		= employeeWork.LvrRtCstBodyPaint;
			employee.LoginId				= employeeWork.LoginId;
			employee.LoginPassword			= employeeWork.LoginPassword;
			employee.UserAdminFlag			= employeeWork.UserAdminFlag;
			employee.EnterCompanyDate		= employeeWork.EnterCompanyDate;
			employee.RetirementDate			= employeeWork.RetirementDate;

            employee.AuthorityLevel1        = employeeWork.AuthorityLevel1;
            employee.AuthorityLevel2        = employeeWork.AuthorityLevel2;

			// -- Add St 2012.05.29 30182 R.Tachiya --
			employee.SalSlipInpBootCnt = employeeWork.SalSlipInpBootCnt;
			employee.CustLedgerBootCnt = employeeWork.CustLedgerBootCnt;
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

			return employee;
		}

        // 2007.08.14 �ǉ� >>>>>>>>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�]�ƈ��ڍ׃��[�N�N���X�ˏ]�ƈ��ڍ׃N���X�j
        /// </summary>
        /// <param name="employeeDtlWork">�]�ƈ��ڍ׃��[�N�N���X</param>
        /// <returns>�]�ƈ��ڍ׃N���X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ڍ׃��[�N�N���X����]�ƈ��ڍ׃N���X�փ����o�[�̃R�s�[���s���܂��B�i���C�A�E�g���̂݁j</br>
        /// <br>Programmer : 980035 ����  ��`</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        public static EmployeeDtl CopyToEmployeeDtl(EmployeeDtlWork employeeDtlWork)
        {
            EmployeeDtl employeeDtl = new EmployeeDtl();

            employeeDtl.CreateDateTime = employeeDtlWork.CreateDateTime;
            employeeDtl.UpdateDateTime = employeeDtlWork.UpdateDateTime;
            employeeDtl.EnterpriseCode = employeeDtlWork.EnterpriseCode;
            employeeDtl.FileHeaderGuid = employeeDtlWork.FileHeaderGuid;
            employeeDtl.UpdEmployeeCode = employeeDtlWork.UpdEmployeeCode;
            employeeDtl.UpdAssemblyId1 = employeeDtlWork.UpdAssemblyId1;
            employeeDtl.UpdAssemblyId2 = employeeDtlWork.UpdAssemblyId2;
            employeeDtl.LogicalDeleteCode = employeeDtlWork.LogicalDeleteCode;

            employeeDtl.EmployeeCode = employeeDtlWork.EmployeeCode;
            employeeDtl.BelongSubSectionCode = employeeDtlWork.BelongSubSectionCode;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            employeeDtl.BelongSubSectionName = employeeDtlWork.BelongSubSectionName;
            employeeDtl.BelongMinSectionCode = employeeDtlWork.BelongMinSectionCode;
            employeeDtl.BelongMinSectionName = employeeDtlWork.BelongMinSectionName;
            employeeDtl.BelongSalesAreaCode  = employeeDtlWork.BelongSalesAreaCode;
            employeeDtl.BelongSalesAreaName  = employeeDtlWork.BelongSalesAreaName;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            employeeDtl.EmployAnalysCode1 = employeeDtlWork.EmployAnalysCode1;
            employeeDtl.EmployAnalysCode2 = employeeDtlWork.EmployAnalysCode2;
            employeeDtl.EmployAnalysCode3 = employeeDtlWork.EmployAnalysCode3;
            employeeDtl.EmployAnalysCode4 = employeeDtlWork.EmployAnalysCode4;
            employeeDtl.EmployAnalysCode5 = employeeDtlWork.EmployAnalysCode5;
            employeeDtl.EmployAnalysCode6 = employeeDtlWork.EmployAnalysCode6;

            // 2008.11.10 add start --------------------------------------------->>
            employeeDtl.UOESnmDiv = employeeDtlWork.UOESnmDiv;
            // 2008.11.10 add end -----------------------------------------------<<
            
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            employeeDtl.OldBelongSectionCd = employeeDtlWork.OldBelongSectionCd;
            employeeDtl.OldBelongSectionNm = employeeDtlWork.OldBelongSectionNm;
            employeeDtl.OldBelongSubSecCd = employeeDtlWork.OldBelongSubSecCd;
            employeeDtl.OldBelongSubSecNm = employeeDtlWork.OldBelongSubSecNm;
            employeeDtl.OldBelongMinSecCd = employeeDtlWork.OldBelongMinSecCd;
            employeeDtl.OldBelongMinSecNm = employeeDtlWork.OldBelongMinSecNm;
            employeeDtl.SectionChgDate = employeeDtlWork.SectionChgDate;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            employeeDtl.MailAddrKindCode1 = employeeDtlWork.MailAddrKindCode1;
            employeeDtl.MailAddrKindName1 = employeeDtlWork.MailAddrKindName1;
            employeeDtl.MailAddress1 = employeeDtlWork.MailAddress1;
            employeeDtl.MailSendCode1 = employeeDtlWork.MailSendCode1;
            employeeDtl.MailAddrKindCode2 = employeeDtlWork.MailAddrKindCode2;
            employeeDtl.MailAddrKindName2 = employeeDtlWork.MailAddrKindName2;
            employeeDtl.MailAddress2 = employeeDtlWork.MailAddress2;
            employeeDtl.MailSendCode2 = employeeDtlWork.MailSendCode2;
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return employeeDtl;
        }
        // 2007.08.14 �ǉ� <<<<<<<<<<

		#region ���}�X����UI�N���X�p�Q�Ə���
		/// <summary>
		/// ���_���̎擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>���_����</returns>
		/// <remarks>
		/// <br>Note       : ���_���̂�Ԃ��܂��B</br>
		/// <br>Programmer : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.09.20</br>
		/// </remarks>
		public string GetSectionName(string enterpriseCode, string sectionCode)
		{
			//----- ueno add ---------- start 2008.02.12
			// ���[�J���c�a���_�Ή�
			ConstructSecInfoAcs();
			//----- ueno add ---------- end 2008.02.12

			foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
			{
				if (secInfoSet.SectionCode.TrimEnd() == "0")
				{
					return "���o�^";
				}
				else if ((secInfoSet.SectionCode.TrimEnd() == sectionCode.TrimEnd()) &&
					(secInfoSet.LogicalDeleteCode == 0))
				{
					return secInfoSet.SectionGuideNm;
				}
			}
			return "���o�^";
		}
		#endregion

		#region ���K�C�h�N������
        // ----- iitani a ---------- start 2007.05.26
        /// <summary>
		/// �]�ƈ��K�C�h�N������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="dispAllSecInfo">"�S��"�ݒ�L��[true:�ݒ�,false:���ݒ�]</param>
		/// <param name="employee">�擾�f�[�^</param>
		/// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
		/// <remarks>
		/// <br>Note		: �]�ƈ��}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
		/// <br>Programmer	: 980023 �ђJ �k��</br>
		/// <br>Date		: 2005.05.26</br>
		/// </remarks>
        public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, out Employee employee)
        {
            return this.ExecuteGuid(enterpriseCode, dispAllSecInfo, "", out employee);
        }
        // ----- iitani a ---------- end 2007.05.26
        
        /// <summary>
		/// �]�ƈ��K�C�h�N������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="dispAllSecInfo">"�S��"�ݒ�L��[true:�ݒ�,false:���ݒ�]</param>
		/// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="employee">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
		/// <remarks>
		/// <br>Note		: �]�ƈ��}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.05.06</br>
		/// </remarks>
        //public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, int frontMechaCode, out Employee employee)
        // ----- iitani c ---------- start 2007.05.26
        //public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, out Employee employee)
        public int ExecuteGuid(string enterpriseCode, bool dispAllSecInfo, string sectionCode, out Employee employee)
        // ----- iitani c ---------- end 2007.05.26
        {
			int status = -1;
			employee = new Employee();

            // ----- iitani c ---------- start 2007.05.26
            //TableGuideParent tableGuideParent = new TableGuideParent("EMPLOYEEKTNGUIDEPARENT.XML");
            string xmlName = "";
            if (sectionCode == "")
            {
                xmlName = "EMPLOYEEKTNGUIDEPARENT.XML";
            }
            else
            {
                xmlName = "EMPLOYEEGUIDEPARENT.XML";
            }
            TableGuideParent tableGuideParent = new TableGuideParent(xmlName);
            // ----- iitani c ---------- end 2007.05.26

			Hashtable inObj = new Hashtable();
			Hashtable retObj = new Hashtable();

			// ��ƃR�[�h
			inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("SectionCode", sectionCode);       // iitani a 2007.05.26
			// ��t�E���J�敪
            //inObj.Add("FrontMechaCode", frontMechaCode);
            // 2007.08.14 �C�� >>>>>>>>>>
            // "�S��"�ݒ萧��
			//if (_optSection)
			//	inObj.Add("DispAllSecInfo", dispAllSecInfo);
			//else
			//	inObj.Add("DispAllSecInfo", false);
            inObj.Add("DispAllSecInfo", dispAllSecInfo);
            // 2007.08.14 �C�� <<<<<<<<<<

			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				employee.EmployeeCode			= retObj["EmployeeCode"].ToString();
				employee.Name					= retObj["Name"].ToString();
				employee.Kana					= retObj["Kana"].ToString();
				employee.ShortName				= retObj["ShortName"].ToString();
				employee.SexCode				= Convert.ToInt32(retObj["SexCode"]);
				employee.SexName				= retObj["SexName"].ToString();
				employee.Birthday				= Convert.ToDateTime(retObj["Birthday"]);
				employee.CompanyTelNo			= retObj["CompanyTelNo"].ToString();
				employee.PortableTelNo			= retObj["PortableTelNo"].ToString();
				employee.PostCode				= Convert.ToInt32(retObj["PostCode"]);
				employee.BusinessCode			= Convert.ToInt32(retObj["BusinessCode"]);
                //employee.FrontMechaCode			= Convert.ToInt32(retObj["FrontMechaCode"]);
				employee.InOutsideCompanyCode	= Convert.ToInt32(retObj["InOutsideCompanyCode"]);
				
                Employee emp = (Employee)_employeeTable_Stc[employee.EmployeeCode.Trim()];
                
                //employee.BelongSectionCode		= retObj["BelongSectionCode"].ToString();
                employee.BelongSectionCode = emp.BelongSectionCode.Trim();
                //employee.LvrRtCstGeneral		= Convert.ToInt64(retObj["LvrRtCstGeneral"]);
                //employee.LvrRtCstCarInspect		= Convert.ToInt64(retObj["LvrRtCstCarInspect"]);
                //employee.LvrRtCstBodyRepair		= Convert.ToInt64(retObj["LvrRtCstBodyRepair"]);
                //employee.LvrRtCstBodyPaint		= Convert.ToInt64(retObj["LvrRtCstBodyPaint"]);
				employee.LoginId				= retObj["LoginId"].ToString();
				employee.LoginPassword			= retObj["LoginPassword"].ToString();
				employee.EnterCompanyDate		= Convert.ToDateTime(retObj["EnterCompanyDate"]);
				employee.RetirementDate			= Convert.ToDateTime(retObj["RetirementDate"]);
                //employee.FrontMechaName         = retObj["FrontMechaName"].ToString();
				employee.InOutsideCompanyName   = retObj["InOutsideCompanyName"].ToString();
				//                employee.PostName               = retObj["PostName"].ToString();
				//                employee.BusinessName           = retObj["BusinessName"].ToString();
				//                employee.BelongSectionName      = retObj["BelongSectionName"].ToString();

                employee.AuthorityLevel1 = Convert.ToInt32(retObj["AuthorityLevel1"]);
                employee.AuthorityLevel2 = Convert.ToInt32(retObj["AuthorityLevel2"]);

				// -- Add St 2012.05.29 30182 R.Tachiya --
				employee.SalSlipInpBootCnt = Convert.ToInt32(retObj["SalSlipInpBootCnt"]);
				employee.CustLedgerBootCnt = Convert.ToInt32(retObj["CustLedgerBootCnt"]);
				// -- Add Ed 2012.05.29 30182 R.Tachiya --

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
		/// <br>Programmer	: 18012 Y.Sasaki</br>
		/// <br>Date		: 2005.05.06</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status   = -1;
			string enterpriseCode = "";
			string sectionCode    = "";
			int frontMechaCode = -1;


			// ��ƃR�[�h�ݒ�L��
			if (inParm.ContainsKey("EnterpriseCode"))
			{
				enterpriseCode = inParm["EnterpriseCode"].ToString();
			}
			// ��ƃR�[�h�ݒ薳��
			else
			{
				// �L�蓾�Ȃ��̂ŃG���[
				return status;
			}

			// ���_�R�[�h
			if (inParm.ContainsKey("SectionCode"))
			{
				sectionCode = inParm["SectionCode"].ToString();
			}

			// ��t�E���J�敪[-1:�S��,0:��t,1:���J,2:�c��]
            //if (inParm.ContainsKey("FrontMechaCode"))
            //{
            //    frontMechaCode = (int)inParm["FrontMechaCode"];
            //}

			// �]�ƈ��e�[�u���Ǎ���
            // ----- iitani c ---------- start 2007.05.26
			//status = Search(ref guideList, enterpriseCode, sectionCode, frontMechaCode);
            // 2007.08.14 �C�� >>>>>>>>>>
            //status = SearchLocal(ref guideList, enterpriseCode, sectionCode, frontMechaCode);
            status = Search(ref guideList, enterpriseCode, sectionCode, frontMechaCode);
            // 2007.08.14 �C�� <<<<<<<<<<
            // ----- iitani c ---------- end 2007.05.26
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

        #region ���[�J���c�a�Ή�
        /// <summary>
        /// �w�肳�ꂽ���������ŏ]�ƈ����������܂��B�i���[�J���ǂ݁j
        /// </summary>
        /// <param name="retList">��������List</param>
        /// <param name="paraEmployee">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �w�肳�ꂽ���������ŏ]�ƈ��}�X�^���������܂��B</br>
        /// <br>Programmer	: 18322 �ؑ� ����</br>
        /// <br>Date		: 2007.05.21</br>
        /// </remarks>
        public int SearchLocal(out ArrayList retList, Employee paraEmployee)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            retList = new ArrayList();

            try
            {
                if (_localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].Rows.Count > 0)
                {
                    string where = LOCAL_SECTIONCODE + " = '" + paraEmployee.BelongSectionCode + "'";
                    if (paraEmployee.EmployeeCode != "")
                    {
                        where += " AND " + LOCAL_EMPLOYEECODE + " = '"+ paraEmployee.EmployeeCode +"'";
                    }
                    DataRow[] drList = _localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].Select(where, LOCAL_EMPLOYEECODE + " ASC");
                    int maxIndex2 = drList.Length;

                    if (maxIndex2 > 0)
                    {
                        for (int index = 0; maxIndex2 > index; index++)
                        {
                            Employee employee = this.CopyToEmployeeFromEmployeeWork((EmployeeWork)drList[index][LOCAL_EMPLOYEE_RECORD]);
                            retList.Add(employee);
                        }

                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                
                // �f�[�^�Ȃ� -> ���[�J���c�a���f�[�^���擾
                EmployeeWork paraEmp = new EmployeeWork();
                paraEmp.EnterpriseCode    = paraEmployee.EnterpriseCode;
                paraEmp.BelongSectionCode = paraEmployee.BelongSectionCode;

                List<EmployeeWork> employeeList;
                status = this._employeeLcDB.Search(out employeeList, paraEmp, 0, ConstantManagement.LogicalMode.GetData0);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �f�[�^���i�[
                retList.Clear();
                _localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].Rows.Clear();
                int maxIndex = employeeList.Count;
                for (int index = 0; maxIndex > index; index++)
                {
                    if ((paraEmployee.BelongSectionCode.TrimEnd() == "") ||
                        (paraEmployee.BelongSectionCode.TrimEnd() == employeeList[index].BelongSectionCode.TrimEnd())) 
                    {
                        DataRow dr = _localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].NewRow();
                        dr[LOCAL_SECTIONCODE] = employeeList[index].BelongSectionCode;
                        dr[LOCAL_EMPLOYEECODE] = employeeList[index].EmployeeCode;

                        dr[LOCAL_EMPLOYEE_RECORD] = employeeList[index];

                        _localDataSet.Tables[LOCAL_EMPLOYEE_TABLE].Rows.Add(dr);
                        retList.Add(this.CopyToEmployeeFromEmployeeWork(employeeList[index]));
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        // ----- iitani a ---------- start 2007.05.26
        /// <summary>
        /// �]�ƈ����������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="belongSectionCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="frontMechaCode">��t�E���J�敪[-1:�S��,0:��t,1:���J,2:�c��]</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : 980023 �ђJ �k��</br>
        /// <br>Date       : 2005.05.26</br>
        /// </remarks>
        public int SearchLocal(ref DataSet ds, string enterpriseCode, string belongSectionCode, int frontMechaCode)
        {
            EmployeeWork employeeWork = new EmployeeWork();
            employeeWork.EnterpriseCode = enterpriseCode;

            ArrayList ar = new ArrayList();

            int status = 0;
            List<EmployeeWork> employeeWorkList;

            // �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
            //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag)) // 2009.08.07
            if (!_searchFlg) // 2009.08.07
            {
                // �]�ƈ��T�[�`
                status = this._employeeLcDB.Search(out employeeWorkList, employeeWork, 0, ConstantManagement.LogicalMode.GetData0);

                if (status == 0)
                {
                    ArrayList al = new ArrayList();
                    al.AddRange(employeeWorkList);
                    // �]�ƈ����[�J�[�N���X��UI�N���XStatic�]�L����
                    CopyToStaticFromWorker(al);
                    // SearchFlg ON
                    _searchFlg = true;
                }
                else
                {
                    return status;
                }
            }

            SortedList sl = new SortedList();  // iitani a 2007.05.29

            // Static����K�C�h�\���i�I��/�I�t���ʁj	
            foreach (Employee employeeWk in _employeeTable_Stc.Values)
            {
                // ArrayList�փ����o�R�s�[
                if (belongSectionCode.Trim() == "")
                {
                    // �S�Е\��
                    // ----- iitani c ---------- start 2007.05.29
                    //ar.Add(employeeWk.Clone());
                    sl.Add(employeeWk.Clone().EmployeeCode, employeeWk.Clone());
                    // ----- iitani c ---------- end 2007.05.29
                }
                else if (belongSectionCode.TrimEnd().Equals(employeeWk.BelongSectionCode.TrimEnd()))
                {
                    // �Y�����_�̒S����
                    // ----- iitani c ---------- start 2007.05.29
                    //ar.Add(employeeWk.Clone());
                    sl.Add(employeeWk.Clone().EmployeeCode, employeeWk.Clone());
                    // ----- iitani c ---------- end 2007.05.29
                }
            }

            ar.AddRange(sl.Values);  // iitani a 2007.05.29

            Employee[] employees = new Employee[ar.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < ar.Count; i++)
            {
                employees[i] = (Employee)ar[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(employees);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
        // ----- iitani a ---------- end 2007.05.26
        #endregion

        // 2010/02/18 Add >>>
        #region FeliCaMng�A�N�Z�X��
        /// <summary>
        /// �t�F���J�Ǘ��}�X�^Static�������S���擾����
        /// </summary>
        /// <param name="retList">�t�F���J�Ǘ��N���XList</param>
        /// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ��}�X�^Static�������̑S�����擾���܂��B</br>
        /// <br>Programer  : 22011 �����@���l</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int SearchStaticMemory_FeliCa(out List<FeliCaMngWork> retList)
        {
            retList = new List<FeliCaMngWork>();
            retList.Clear();

            if (_felicaMngWkList_Stc == null)
            {
                SearchAll_FeliCa(out _felicaMngWkList_Stc, LoginInfoAcquisition.EnterpriseCode);
            }
            else if (_felicaMngWkList_Stc.Count == 0)
            {
                return 9;
            }

            retList = _felicaMngWkList_Stc;
            return 0;
        }

        /// <summary>
        /// �t�F���J�Ǘ��}�X�^Static�������擾����
        /// </summary>
        /// <param name="feliCaMng">�t�F���J�Ǘ��}�X�^</param>
        /// <param name="feliCaIdm">�t�F���JIDm</param>
        /// <param name="felicaMngKind">�t�F���J�Ǘ����</param>
        /// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 4:�f�[�^����)</returns>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ��}�X�^Static���������������܂��B</br>
        /// <br>Programer  : 22011 �����@���l</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int ReadStaticMemory_FeliCa(out FeliCaMngWork feliCaMng, string feliCaIdm, Int32 felicaMngKind)
        {
            feliCaMng = null;

            if (_felicaMngWkList_Stc == null)
            {
                SearchAll_FeliCa(out _felicaMngWkList_Stc, LoginInfoAcquisition.EnterpriseCode);
            }
            if (_felicaMngWkList_Stc.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            feliCaMng = _felicaMngWkList_Stc.Find(delegate(FeliCaMngWork target)
            {
                return ((target.FeliCaIDm == feliCaIdm) && (target.FeliCaMngKind == felicaMngKind));
            });

            // Static���猟��
            if (feliCaMng == null)
            {
                feliCaMng = null;
                return 4;
            }

            return 0;
        }

        /// <summary>
        /// �t�F���J�Ǘ����X�gStatic�Z�b�g����
        /// </summary>
        /// <param name="feliCaMngList">�Z�b�g����t�F���J�Ǘ���񃊃X�g</param>
        /// <remarks>
        /// <br>Note		: �t�F���J�Ǘ����X�g��Static�̈�ɃZ�b�g���܂��B</br>
        /// <br>Programmer	: 22011 �����@���l</br>
        /// <br>Date		: 2008.11.06</br>
        /// </remarks>
        public void SetStaticMemory_FeliCa(List<FeliCaMngWork> feliCaMngList)
        {
            // �I�t���C�����[�h�̏ꍇ �� ���Ɏ擾�ς݁i�R���X�g���N�^�ɂĎ擾�j�Ȃ̂ŁA�������Ȃ�
            if (!LoginInfoAcquisition.OnlineFlag) return;
            if (feliCaMngList == null) return;
            // �X�^�e�B�b�N�L���b�V�����㏑��
            _felicaMngWkList_Stc = feliCaMngList;
        }

        /// <summary>
        /// �t�F���J�Ǘ��o�^�E�X�V����
        /// </summary>
        /// <param name="feliCaMng">�t�F���J�Ǘ��N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ����̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int Write_Felica(ref FeliCaMngWork feliCaMng)
        {
            int status = 0;
            try
            {
                List<FeliCaMngWork> paraLst = new List<FeliCaMngWork>();
                paraLst.Add(feliCaMng);
                object paraObj = (object)paraLst;

                //�t�F���J�Ǘ���������
                status = this._iFeliCaMngDB.Write(ref paraObj);
                if ((status == 0) && (((List<FeliCaMngWork>)paraObj).Count > 0))
                {
                    feliCaMng = ((List<FeliCaMngWork>)paraObj)[0];
                    // Static�f�[�^�X�V
                    Update_felicaMngWkList_Stc(feliCaMng);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFeliCaMngDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �t�F���J�Ǘ��_���폜����
        /// </summary>
        /// <param name="feliCaMng">�t�F���J�Ǘ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ����̘_���폜���s���܂��B</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int LogicalDelete_FeliCa(ref FeliCaMngWork feliCaMng)
        {
            try
            {
                object paraObj = (object)feliCaMng;
                // �t�F���J�Ǘ��_���폜
                int status = this._iFeliCaMngDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    // Static�X�V
                    feliCaMng = paraObj as FeliCaMngWork;
                    Update_felicaMngWkList_Stc(feliCaMng);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFeliCaMngDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �t�F���J�Ǘ������폜����
        /// </summary>
        /// <param name="feliCaMng">�t�F���J�Ǘ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ����̕����폜���s���܂��B</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int Delete_FeliCa(FeliCaMngWork feliCaMng)
        {
            try
            {
                // �t�F���J�Ǘ������폜
                int status = this._iFeliCaMngDB.Delete(feliCaMng);

                if (status == 0)
                {
                    // Static�X�V
                    Remove_felicaMngWkList_Stc(feliCaMng);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFeliCaMngDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �t�F���J�Ǘ����������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ��̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int SearchAll_FeliCa(out List<FeliCaMngWork> retList, string enterpriseCode)
        {
            return SearchProc_Felica(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// �t�F���J�Ǘ��_���폜��������
        /// </summary>
        /// <param name="feliCaMng">�t�F���J�Ǘ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ����̕������s���܂��B</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public int Revival_FeliCa(ref FeliCaMngWork feliCaMng)
        {
            try
            {
                object paraObj = (object)feliCaMng;
                int status = this._iFeliCaMngDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    // Static�X�V
                    feliCaMng = paraObj as FeliCaMngWork;
                    Update_felicaMngWkList_Stc(feliCaMng);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iFeliCaMngDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �t�F���J�Ǘ��X�^�e�B�b�N�L���b�V���X�V
        /// </summary>
        /// <param name="item">�X�V����f�[�^</param>
        /// <remarks>
        /// <br>Note       : �t�F���J�Ǘ��X�^�e�B�b�N�L���b�V�����X�V���܂�</br>
        /// <br>Programer  : 22011 �����@���l</br>
        /// <br>Date       : 2008.11.06</br>
        /// </remarks>
        public void Update_felicaMngWkList_Stc(FeliCaMngWork item)
        {
            if (Remove_felicaMngWkList_Stc(item))
                _felicaMngWkList_Stc.Add(item);
        }
        #endregion
        // 2010/02/18 Add <<<

        #endregion

        #region ��Private Method
        /// <summary>
		/// �]�ƈ���������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retList2">�Ǎ����ʃR���N�V����(�ڍ�)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
		/// <param name="prevEmployee">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <param name="prevEmployeeDtl">�O��ŏI�S���ҏڍ׃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��̌����������s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
        // 2007.08.14 �C�� >>>>>>>>>>
        //private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, Employee prevEmployee)
        private int SearchProc(out ArrayList retList, out ArrayList retList2, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, Employee prevEmployee, EmployeeDtl prevEmployeeDtl)
        // 2007.08.14 �C�� <<<<<<<<<<
        {
			EmployeeWork employeeWork = new EmployeeWork();
            // 2007.08.14 �C�� >>>>>>>>>>
            //if (prevEmployee != null) employeeWork = CopyToEmployeeWorkFromEmployee(prevEmployee);
            EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();
            if (prevEmployee != null)
            {
                employeeWork = CopyToEmployeeWorkFromEmployee(prevEmployee);
                employeeDtlWork = CopyToEmployeeDtlWorkFromEmployeeDtl(prevEmployeeDtl);
            }
            // 2007.08.14 �C�� <<<<<<<<<<
            employeeWork.EnterpriseCode = enterpriseCode;
            employeeDtlWork.EnterpriseCode = enterpriseCode;    // 2007.08.14 �ǉ�
			
			int status;

			//���f�[�^�L��������
			nextData = false;
			//0�ŏ�����
			retTotalCnt = 0;

			retList = new ArrayList();
            retList2 = new ArrayList();             // 2007.08.14 �ǉ�
            retList.Clear();
            retList2.Clear();                       // 2007.08.14 �ǉ�
            ArrayList paraList = new ArrayList();
            ArrayList paraList2 = new ArrayList();  // 2007.08.14 �ǉ�

			// �I�t���C���̏ꍇ�̓L���b�V������ǂ�
            // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList);

            //}
            //else
            //{
            // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                object objectEmployeeWork = null; 
				
				// �]�ƈ�����
				if (readCnt == 0)
				{
					//----- ueno upd ---------- start 2008.01.31
					if (_isLocalDBRead)
					{
						List<EmployeeWork> employeeWorkList = new List<EmployeeWork>();
						status = this._employeeLcDB.Search(out employeeWorkList, employeeWork, 0, logicalMode);

						ArrayList convList = new ArrayList();
						convList.AddRange(employeeWorkList);
						objectEmployeeWork = (object)convList;
					}
					else
					{
						status = this._iEmployeeDB.Search(out objectEmployeeWork,employeeWork,0,logicalMode);
					}
					//----- ueno upd ---------- end 2008.01.31
				}
				else
				{
					//----- ueno upd ---------- start 2008.01.31
					if (_isLocalDBRead)
					{
						List<EmployeeWork> employeeWorkList = new List<EmployeeWork>();
						status = this._employeeLcDB.SearchSpecification(out employeeWorkList, out retTotalCnt, out nextData, employeeWork, 0, logicalMode, readCnt);

						ArrayList convList = new ArrayList();
						convList.AddRange(employeeWorkList);
						objectEmployeeWork = (object)convList;
					}
					else
					{
						status = this._iEmployeeDB.SearchSpecification(out objectEmployeeWork,out retTotalCnt,out nextData,employeeWork,0,logicalMode,readCnt);
					}
					//----- ueno upd ---------- end 2008.01.31
				}
				
				if (status == 0)
				{
					// �]�ƈ����[�J�[�N���X��UI�N���XStatic�]�L����
					CopyToStaticFromWorker(objectEmployeeWork as ArrayList);
					// �p�����[�^���n���ė��Ă��邩�m�F
					paraList = objectEmployeeWork as ArrayList;
					EmployeeWork[] wkEmployeeWork = new EmployeeWork[paraList.Count];

					// �f�[�^�����ɖ߂�
					for(int i=0; i < paraList.Count; i++)
					{
						wkEmployeeWork[i] = (EmployeeWork)paraList[i];
					}
					for(int i=0; i < wkEmployeeWork.Length; i++)
					{
						// �T�[�`���ʎ擾
						retList.Add(CopyToEmployeeFromEmployeeWork(wkEmployeeWork[i]));
					}

					// SearchFlg ON
					_searchFlg = true;
				}

                // 2007.08.14 �ǉ� >>>>>>>>>>
                // �]�ƈ��ڍ׌���
                object objectEmployeeDtlWork = null;
                paraList.Clear();

				//----- ueno upd ---------- start 2008.01.31
				// ���[�J��
				if (_isLocalDBRead)
				{
					List<EmployeeDtlWork> employeeDtlWorkList = new List<EmployeeDtlWork>();
					status = this._employeeDtlLcDB.Search(out employeeDtlWorkList, employeeDtlWork, 0, logicalMode);
					
					if(status == 0)
					{
						ArrayList al = new ArrayList();
						al.AddRange(employeeDtlWorkList);
						objectEmployeeDtlWork = (object)al;
					}
				}
				// �����[�g
				else
				{
	                status = this._iEmployeeDtlDB.Search(out objectEmployeeDtlWork, employeeDtlWork, 0, logicalMode);
				}
				//----- ueno upd ---------- end 2008.01.31

                if (status == 0)
                {
                    // �]�ƈ��ڍ׃��[�J�[�N���X��UI�N���XStatic�]�L����
                    CopyToStaticFromWorker2(objectEmployeeDtlWork as ArrayList);
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    paraList2 = objectEmployeeDtlWork as ArrayList;
                    EmployeeDtlWork[] wkEmployeeDtlWork = new EmployeeDtlWork[paraList2.Count];

                    // �f�[�^�����ɖ߂�
                    for (int i = 0; i < paraList2.Count; i++)
                    {
                        wkEmployeeDtlWork[i] = (EmployeeDtlWork)paraList2[i];
                    }
                    for (int i = 0; i < wkEmployeeDtlWork.Length; i++)
                    {
                        // �T�[�`���ʎ擾
                        retList2.Add(CopyToEmployeeDtlFromEmployeeDtlWork(wkEmployeeDtlWork[i]));
                    }

                    // SearchFlg ON
                    _searchFlg = true;
                }
                // 2007.08.14 �ǉ� <<<<<<<<<<

            //} // 2009.08.07
			//�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

        // 2009.02.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �]�ƈ��S���������i�_���폜�����A�]�ƈ����̂ݎ擾�j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retList2">�Ǎ����ʃR���N�V����(�ڍ�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>�]�ƈ����̎擾�݂̂��s���A�]�v�ȃZ�b�g���͍s��Ȃ�</remarks>
        public int SearchOnlyEmployeeInfo(out ArrayList retList, out ArrayList retList2, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchOnlyEmployeeInfoProc(out retList, out retList2, out retTotalCnt, out nextData, enterpriseCode, 0);
        }

        /// <summary>
        /// �]�ƈ����������i�]�ƈ����̂ݎ擾�j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retList2">�Ǎ����ʃR���N�V����(�ڍ�)</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <returns>STATUS</returns>
        /// <remarks>�]�ƈ����̎擾�݂̂��s���A�]�v�ȃZ�b�g���͍s��Ȃ�</remarks>
        private int SearchOnlyEmployeeInfoProc(out ArrayList retList, out ArrayList retList2, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            EmployeeWork employeeWork = new EmployeeWork();
            EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();
            employeeWork.EnterpriseCode = enterpriseCode;
            employeeDtlWork.EnterpriseCode = enterpriseCode;

            int status;

            //���f�[�^�L��������
            nextData = false;
            //0�ŏ�����
            retTotalCnt = 0;

            retList = new ArrayList();
            retList2 = new ArrayList();
            retList.Clear();
            retList2.Clear();
            ArrayList paraList = new ArrayList();
            ArrayList paraList2 = new ArrayList();

            // 2009.08.07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �I�t���C���̏ꍇ�̓L���b�V������ǂ�
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList);

            //}
            //else
            //{
            // 2009.08.07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                object objectEmployeeWork = null;

                #region �]�ƈ�����
                if (_isLocalDBRead)
                {
                    List<EmployeeWork> employeeWorkList = new List<EmployeeWork>();
                    status = this._employeeLcDB.Search(out employeeWorkList, employeeWork, 0, logicalMode);

                    ArrayList convList = new ArrayList();
                    convList.AddRange(employeeWorkList);
                    objectEmployeeWork = (object)convList;
                }
                else
                {
                    status = this._iEmployeeDB.Search(out objectEmployeeWork, employeeWork, 0, logicalMode);
                }

                if (status == 0)
                {
                    ArrayList al = (ArrayList)objectEmployeeWork;
                    for (int i = 0; i < al.Count; i++)
                    {
                        // �T�[�`���ʎ擾
                        retList.Add(CopyToEmployeeFromEmployeeWork((EmployeeWork)al[i]));
                    }

                    _searchFlg = true;
                }
                #endregion

                #region �]�ƈ��ڍ׌���
                object objectEmployeeDtlWork = null;
                paraList.Clear();

                // ���[�J��
                if (_isLocalDBRead)
                {
                    List<EmployeeDtlWork> employeeDtlWorkList = new List<EmployeeDtlWork>();
                    status = this._employeeDtlLcDB.Search(out employeeDtlWorkList, employeeDtlWork, 0, logicalMode);

                    if (status == 0)
                    {
                        ArrayList al = new ArrayList();
                        al.AddRange(employeeDtlWorkList);
                        objectEmployeeDtlWork = (object)al;
                    }
                }
                // �����[�g
                else
                {
                    status = this._iEmployeeDtlDB.Search(out objectEmployeeDtlWork, employeeDtlWork, 0, logicalMode);
                }

                if (status == 0)
                {
                    ArrayList al = (ArrayList)objectEmployeeDtlWork;
                    for (int i = 0; i < al.Count; i++)
                    {
                        // �T�[�`���ʎ擾
                        retList2.Add(CopyToEmployeeDtlFromEmployeeDtlWork((EmployeeDtlWork)al[i]));
                    }
                    _searchFlg = true;
                }
                #endregion
            //} // 2009.08.07
            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            retTotalCnt = retList.Count;

            return status;
        }
        // 2009.02.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�]�ƈ����[�N�N���X�ˏ]�ƈ��N���X�j
		/// </summary>
		/// <param name="employeeWork">�]�ƈ����[�N�N���X</param>
		/// <returns>�]�ƈ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ����[�N�N���X����]�ƈ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>		   : ���������ɒǉ������v���p�e�B�����Z�b�g���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private Employee CopyToEmployeeFromEmployeeWork(EmployeeWork employeeWork)
		{
			Employee employee = new Employee();
			//----- ueno rev ---------- start 2008.02.12
            //string wkString;        2008.11.17 Del 
			//----- ueno rev ---------- end 2008.02.12
			
			employee = (CopyToEmployee(employeeWork));

            //switch (employeeWork.FrontMechaCode)
            //{
            //    case 0:
            //    {
            //        employee.FrontMechaName = "��t";							
            //        break;
            //    }
            //    case 1:
            //    {
            //        employee.FrontMechaName = "���J";							
            //        break;
            //    }
            //    case 2:
            //    {
            //        employee.FrontMechaName = "�c��";
            //        break;
            //    }
            //    default:
            //    {
            //        employee.FrontMechaName = "";							
            //        break;
            //    }
            //}

			switch (employeeWork.InOutsideCompanyCode)
			{
				case 0:
				{
					employee.InOutsideCompanyName = "�Г�";
					break;
				}
				case 1:
				{
					employee.InOutsideCompanyName = "�ЊO";
					break;
				}
				default:
				{
					employee.InOutsideCompanyName = "";
					break;
				}
			}

			if (employee.UserAdminFlag == 0)
			{
				employee.UserAdminName = "���";
			}
			else
			{
				employee.UserAdminName = "���[�U�[�Ǘ���";
			}

            // DEL 2008/11/04 �s��Ή�[7289] ---------->>>>>
            ////----- ueno rev ---------- start 2008.02.12
            //this._userGuideAcs.GetGuideName(out wkString, employee.EnterpriseCode, (int)UserGdGuideDivCodeAcsData.PostCode, employeeWork.PostCode);
            //employee.PostName = wkString;
            // DEL 2008/11/04 �s��Ή�[7289] ----------<<<<<
            // 2008.11.17 Del >>>
            //this._userGuideAcs.GetGuideName(out wkString, employee.EnterpriseCode, (int)UserGdGuideDivCodeAcsData.BusinessCode, employeeWork.BusinessCode);
            //employee.BusinessName = wkString;
            //employee.BelongSectionName = GetSectionName(employeeWork.EnterpriseCode, employeeWork.BelongSectionCode);
            // 2008.11.17 Del <<<
            ////----- ueno rev ---------- end 2008.02.12
            
			return employee;
		}

        // 2007.08.14 �ǉ� >>>>>>>>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�]�ƈ��ڍ׃��[�N�N���X�ˏ]�ƈ��ڍ׃N���X�j
        /// </summary>
        /// <param name="employeeDtlWork">�]�ƈ��ڍ׃��[�N�N���X</param>
        /// <returns>�]�ƈ��ڍ׃N���X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ڍ׃��[�N�N���X����]�ƈ��ڍ׃N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 980035 ����  ��`</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private EmployeeDtl CopyToEmployeeDtlFromEmployeeDtlWork(EmployeeDtlWork employeeDtlWork)
        {
            EmployeeDtl employeeDtl = new EmployeeDtl();
            employeeDtl = (CopyToEmployeeDtl(employeeDtlWork));

            return employeeDtl;
        }
        // 2007.08.14 �ǉ� <<<<<<<<<<

        /// <summary>
		/// �N���X�����o�[�R�s�[�����i�]�ƈ��N���X�ˏ]�ƈ����[�N�N���X�j
		/// </summary>
		/// <param name="employee">�]�ƈ����[�N�N���X</param>
		/// <returns>�]�ƈ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �]�ƈ��N���X����]�ƈ����[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 980079 �Ȓ�  ����Y</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private EmployeeWork CopyToEmployeeWorkFromEmployee(Employee employee)
		{
			EmployeeWork employeeWork = new EmployeeWork();

			employeeWork.CreateDateTime			= employee.CreateDateTime;
			employeeWork.UpdateDateTime			= employee.UpdateDateTime;
			employeeWork.EnterpriseCode			= employee.EnterpriseCode;
			employeeWork.FileHeaderGuid			= employee.FileHeaderGuid;
			employeeWork.UpdEmployeeCode		= employee.UpdEmployeeCode;
			employeeWork.UpdAssemblyId1			= employee.UpdAssemblyId1;
			employeeWork.UpdAssemblyId2			= employee.UpdAssemblyId2;
			employeeWork.LogicalDeleteCode		= employee.LogicalDeleteCode;

			employeeWork.EmployeeCode			= employee.EmployeeCode.Trim();
			employeeWork.Name					= employee.Name.TrimEnd();
			employeeWork.Kana					= employee.Kana.TrimEnd();
			employeeWork.ShortName				= employee.ShortName.TrimEnd();
			employeeWork.SexCode				= employee.SexCode;
			employeeWork.SexName				= employee.SexName;
			employeeWork.Birthday				= employee.Birthday;
			employeeWork.CompanyTelNo			= employee.CompanyTelNo.Trim();
			employeeWork.PortableTelNo			= employee.PortableTelNo.Trim();
			employeeWork.PostCode				= employee.PostCode;
			employeeWork.BusinessCode			= employee.BusinessCode;
            //employeeWork.FrontMechaCode			= employee.FrontMechaCode;
			employeeWork.InOutsideCompanyCode	= employee.InOutsideCompanyCode;
			employeeWork.BelongSectionCode		= employee.BelongSectionCode.Trim();
            //employeeWork.LvrRtCstGeneral		= employee.LvrRtCstGeneral;
            //employeeWork.LvrRtCstCarInspect		= employee.LvrRtCstCarInspect;
            //employeeWork.LvrRtCstBodyRepair		= employee.LvrRtCstBodyRepair;
            //employeeWork.LvrRtCstBodyPaint		= employee.LvrRtCstBodyPaint;
			employeeWork.LoginId				= employee.LoginId.Trim();
			employeeWork.LoginPassword			= employee.LoginPassword.Trim();
			employeeWork.UserAdminFlag			= employee.UserAdminFlag;
			employeeWork.EnterCompanyDate		= employee.EnterCompanyDate;
			employeeWork.RetirementDate			= employee.RetirementDate;

            employeeWork.AuthorityLevel1        = employee.AuthorityLevel1;
            employeeWork.AuthorityLevel2        = employee.AuthorityLevel2;

			// -- Add St 2012.05.29 30182 R.Tachiya --
			employeeWork.SalSlipInpBootCnt		= employee.SalSlipInpBootCnt;
			employeeWork.CustLedgerBootCnt		= employee.CustLedgerBootCnt;
			// -- Add Ed 2012.05.29 30182 R.Tachiya --

			return employeeWork;
		}

        // 2007.08.14 �ǉ� >>>>>>>>>>
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�]�ƈ��ڍ׃N���X�ˏ]�ƈ��ڍ׃��[�N�N���X�j
        /// </summary>
        /// <param name="employeeDtl">�]�ƈ��ڍ׃��[�N�N���X</param>
        /// <returns>�]�ƈ��ڍ׃N���X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ڍ׃N���X����]�ƈ��ڍ׃��[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 980035 ����  ��`</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private EmployeeDtlWork CopyToEmployeeDtlWorkFromEmployeeDtl(EmployeeDtl employeeDtl)
        {
            EmployeeDtlWork employeeDtlWork = new EmployeeDtlWork();

            employeeDtlWork.CreateDateTime = employeeDtl.CreateDateTime;
            employeeDtlWork.UpdateDateTime = employeeDtl.UpdateDateTime;
            employeeDtlWork.EnterpriseCode = employeeDtl.EnterpriseCode;
            employeeDtlWork.FileHeaderGuid = employeeDtl.FileHeaderGuid;
            employeeDtlWork.UpdEmployeeCode = employeeDtl.UpdEmployeeCode;
            employeeDtlWork.UpdAssemblyId1 = employeeDtl.UpdAssemblyId1;
            employeeDtlWork.UpdAssemblyId2 = employeeDtl.UpdAssemblyId2;
            employeeDtlWork.LogicalDeleteCode = employeeDtl.LogicalDeleteCode;
            
            employeeDtlWork.EmployeeCode = employeeDtl.EmployeeCode.Trim();
            employeeDtlWork.BelongSubSectionCode = employeeDtl.BelongSubSectionCode;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            employeeDtlWork.BelongSubSectionName = employeeDtl.BelongSubSectionName;
            employeeDtlWork.BelongMinSectionCode = employeeDtl.BelongMinSectionCode;
            employeeDtlWork.BelongMinSectionName = employeeDtl.BelongMinSectionName;
            employeeDtlWork.BelongSalesAreaCode = employeeDtl.BelongSalesAreaCode;
            employeeDtlWork.BelongSalesAreaName = employeeDtl.BelongSalesAreaName;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            employeeDtlWork.EmployAnalysCode1 = employeeDtl.EmployAnalysCode1;
            employeeDtlWork.EmployAnalysCode2 = employeeDtl.EmployAnalysCode2;
            employeeDtlWork.EmployAnalysCode3 = employeeDtl.EmployAnalysCode3;
            employeeDtlWork.EmployAnalysCode4 = employeeDtl.EmployAnalysCode4;
            employeeDtlWork.EmployAnalysCode5 = employeeDtl.EmployAnalysCode5;
            employeeDtlWork.EmployAnalysCode6 = employeeDtl.EmployAnalysCode6;
            // 2008.11.10 add start --------------------------------------------->>
            employeeDtlWork.UOESnmDiv = employeeDtl.UOESnmDiv;
            // 2008.11.10 add end -----------------------------------------------<<
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            employeeDtlWork.OldBelongSectionCd = employeeDtl.OldBelongSectionCd;
            employeeDtlWork.OldBelongSectionNm = employeeDtl.OldBelongSectionNm;
            employeeDtlWork.OldBelongSubSecCd = employeeDtl.OldBelongSubSecCd;
            employeeDtlWork.OldBelongSubSecNm = employeeDtl.OldBelongSubSecNm;
            employeeDtlWork.OldBelongMinSecCd = employeeDtl.OldBelongMinSecCd;
            employeeDtlWork.OldBelongMinSecNm = employeeDtl.OldBelongMinSecNm;
            employeeDtlWork.SectionChgDate = employeeDtl.SectionChgDate;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            employeeDtlWork.MailAddrKindCode1 = employeeDtl.MailAddrKindCode1;
            employeeDtlWork.MailAddrKindName1 = employeeDtl.MailAddrKindName1;
            employeeDtlWork.MailAddress1 = employeeDtl.MailAddress1;
            employeeDtlWork.MailSendCode1 = employeeDtl.MailSendCode1;
            employeeDtlWork.MailAddrKindCode2 = employeeDtl.MailAddrKindCode2;
            employeeDtlWork.MailAddrKindName2 = employeeDtl.MailAddrKindName2;
            employeeDtlWork.MailAddress2 = employeeDtl.MailAddress2;
            employeeDtlWork.MailSendCode2 = employeeDtl.MailSendCode2;
            // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return employeeDtlWork;
        }
        // 2007.08.14 �ǉ� <<<<<<<<<<

        /// <summary>
		/// ��������������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �]�ƈ��ݒ�A�N�Z�X�N���X���ێ����郁�����𐶐����܂��B</br>
		/// <br>Programer  : 22033 �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void MemoryCreate()
		{
			// �I�����C���̏ꍇ
			if (LoginInfoAcquisition.OnlineFlag)
			{
				//----- ueno del ---------- start 2008.02.12				
				//---���_���擾���i�C���X�^���X��---//
				//this._secInfoAcs = new SecInfoAcs(1);
				//----- ueno del ---------- start 2008.02.12				
                
                // 2008.02.08 �폜 >>>>>>>>>>
                //// ���[�U�[�K�C�h�{�f�B�iHashTable�j
                //if (this._userGdBdTable == null)
                //{
                //    this._userGdBdTable = new Hashtable();
                //}
                //// ���[�U�[�K�C�h�{�f�B�iArrayList�j
                //if (this._userGdBdList == null)
                //{
                //    this._userGdBdList = new ArrayList();
                //}
                // 2008.02.08 �폜 <<<<<<<<<<
            }

			// �]�ƈ��}�X�^�N���XStatic
			if (_employeeTable_Stc == null)
			{
				_employeeTable_Stc = new Hashtable();
			}

            ////----- ueno rev ---------- start 2008.02.12
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            ////----- ueno rev ---------- end 2008.02.12

            // 2010/02/18 Add >>>
            if (_optFeliCaAcs)
            {
                if (_felicaMngWkList_Stc == null)
                {
                    _felicaMngWkList_Stc = new List<FeliCaMngWork>();
                }
            }
            // 2010/02/18 Add <<<
        }

		/// <summary>
		/// �]�ƈ��N���X���[�J�[�N���X�iArrayList�j �� UI�N���X�ϊ�����
		/// </summary>
		/// <param name="employeeWorkList">�]�ƈ����[�J�[�N���X��ArrayList</param>
		/// <remarks>
		/// <br>Note       : �]�ƈ����[�J�[�N���X��UI�̕��ʕ��i�N���X�ɕϊ����āA
		///					 Search�pStatic�������ɕێ����܂��B</br>
		/// <br>Programer  : 22033  �O��  �M�j</br>
		/// <br>Date       : 2005.10.25</br>
		/// </remarks>
		private void CopyToStaticFromWorker(ArrayList employeeWorkList)
		{
			string hashKey;
			foreach (EmployeeWork wkEmployeeWork in employeeWorkList)
			{
				Employee wkEmployee = new Employee();

				// HashKey:�]�ƈ��R�[�h
				hashKey = wkEmployeeWork.EmployeeCode.TrimEnd();

				wkEmployee.CreateDateTime		= wkEmployeeWork.CreateDateTime;
				wkEmployee.UpdateDateTime		= wkEmployeeWork.UpdateDateTime;
				wkEmployee.EnterpriseCode		= wkEmployeeWork.EnterpriseCode;
				wkEmployee.FileHeaderGuid		= wkEmployeeWork.FileHeaderGuid;
				wkEmployee.UpdEmployeeCode		= wkEmployeeWork.UpdEmployeeCode;
				wkEmployee.UpdAssemblyId1		= wkEmployeeWork.UpdAssemblyId1;
				wkEmployee.UpdAssemblyId2		= wkEmployeeWork.UpdAssemblyId2;
				wkEmployee.LogicalDeleteCode	= wkEmployeeWork.LogicalDeleteCode;

				wkEmployee.EmployeeCode			= wkEmployeeWork.EmployeeCode;		
				wkEmployee.Name					= wkEmployeeWork.Name;				
				wkEmployee.Kana					= wkEmployeeWork.Kana;				
				wkEmployee.ShortName			= wkEmployeeWork.ShortName;			
				wkEmployee.SexCode				= wkEmployeeWork.SexCode;				
				wkEmployee.SexName				= wkEmployeeWork.SexName;				
				wkEmployee.Birthday				= wkEmployeeWork.Birthday;			
				wkEmployee.CompanyTelNo			= wkEmployeeWork.CompanyTelNo;		
				wkEmployee.PortableTelNo		= wkEmployeeWork.PortableTelNo;		
				wkEmployee.PostCode				= wkEmployeeWork.PostCode;			
				wkEmployee.BusinessCode			= wkEmployeeWork.BusinessCode;		
                //wkEmployee.FrontMechaCode		= wkEmployeeWork.FrontMechaCode;		
				wkEmployee.InOutsideCompanyCode	= wkEmployeeWork.InOutsideCompanyCode;
				wkEmployee.BelongSectionCode	= wkEmployeeWork.BelongSectionCode;	
                //wkEmployee.LvrRtCstGeneral		= wkEmployeeWork.LvrRtCstGeneral;		
                //wkEmployee.LvrRtCstCarInspect		= wkEmployeeWork.LvrRtCstCarInspect;		
                //wkEmployee.LvrRtCstBodyRepair		= wkEmployeeWork.LvrRtCstBodyRepair;		
                //wkEmployee.LvrRtCstBodyPaint		= wkEmployeeWork.LvrRtCstBodyPaint;		
				wkEmployee.LoginId				= wkEmployeeWork.LoginId;				
				wkEmployee.LoginPassword		= wkEmployeeWork.LoginPassword;		
				wkEmployee.UserAdminFlag		= wkEmployeeWork.UserAdminFlag;		
				wkEmployee.EnterCompanyDate		= wkEmployeeWork.EnterCompanyDate;	
				wkEmployee.RetirementDate		= wkEmployeeWork.RetirementDate;		
				
                wkEmployee.AuthorityLevel1      = wkEmployeeWork.AuthorityLevel1;
                wkEmployee.AuthorityLevel2      = wkEmployeeWork.AuthorityLevel2;

				// -- Add St 2012.05.29 30182 R.Tachiya --
				wkEmployee.SalSlipInpBootCnt	= wkEmployeeWork.SalSlipInpBootCnt;
				wkEmployee.CustLedgerBootCnt	= wkEmployeeWork.CustLedgerBootCnt;
				// -- Add Ed 2012.05.29 30182 R.Tachiya --

                //switch (wkEmployeeWork.FrontMechaCode)
                //{
                //    case 0:
                //    {
                //        wkEmployee.FrontMechaName = "��t";							
                //        break;
                //    }
                //    case 1:
                //    {
                //        wkEmployee.FrontMechaName = "���J";							
                //        break;
                //    }
                //    case 2:
                //    {
                //        wkEmployee.FrontMechaName = "�c��";
                //        break;
                //    }
                //    default:
                //    {
                //        wkEmployee.FrontMechaName = "";							
                //        break;
                //    }
                //}

				switch (wkEmployeeWork.InOutsideCompanyCode)
				{
					case 0:
					{
						wkEmployee.InOutsideCompanyName = "�Г�";							
						break;
					}
					case 1:
					{
						wkEmployee.InOutsideCompanyName = "�ЊO";							
						break;
					}
					default:
					{
						wkEmployee.InOutsideCompanyName = "";							
						break;
					}
				}

				_employeeTable_Stc[hashKey] = wkEmployee;
			}
		}

        // 2007.08.14 �ǉ� >>>>>>>>>>
        /// <summary>
        /// �]�ƈ��ڍ׃N���X���[�J�[�N���X�iArrayList�j �� UI�N���X�ϊ�����
        /// </summary>
        /// <param name="employeeDtlWorkList">�]�ƈ��ڍ׃��[�J�[�N���X��ArrayList</param>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ڍ׃��[�J�[�N���X��UI�̕��ʕ��i�N���X�ɕϊ����āA
        ///					 Search�pStatic�������ɕێ����܂��B</br>
        /// <br>Programer  : 980035  ����  ��`</br>
        /// <br>Date       : 2007.08.14</br>
        /// </remarks>
        private void CopyToStaticFromWorker2(ArrayList employeeDtlWorkList)
        {
            string hashKey;
            foreach (EmployeeDtlWork wkEmployeeDtlWork in employeeDtlWorkList)
            {
                EmployeeDtl wkEmployeeDtl = new EmployeeDtl();

                // HashKey:�]�ƈ��R�[�h
                hashKey = wkEmployeeDtlWork.EmployeeCode.TrimEnd();

                wkEmployeeDtl.CreateDateTime = wkEmployeeDtlWork.CreateDateTime;
                wkEmployeeDtl.UpdateDateTime = wkEmployeeDtlWork.UpdateDateTime;
                wkEmployeeDtl.EnterpriseCode = wkEmployeeDtlWork.EnterpriseCode;
                wkEmployeeDtl.FileHeaderGuid = wkEmployeeDtlWork.FileHeaderGuid;
                wkEmployeeDtl.UpdEmployeeCode = wkEmployeeDtlWork.UpdEmployeeCode;
                wkEmployeeDtl.UpdAssemblyId1 = wkEmployeeDtlWork.UpdAssemblyId1;
                wkEmployeeDtl.UpdAssemblyId2 = wkEmployeeDtlWork.UpdAssemblyId2;
                wkEmployeeDtl.LogicalDeleteCode = wkEmployeeDtlWork.LogicalDeleteCode;

                wkEmployeeDtl.EmployeeCode = wkEmployeeDtlWork.EmployeeCode;
                wkEmployeeDtl.BelongSubSectionCode = wkEmployeeDtlWork.BelongSubSectionCode;
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                wkEmployeeDtl.BelongSubSectionName = wkEmployeeDtlWork.BelongSubSectionName;
                wkEmployeeDtl.BelongMinSectionCode = wkEmployeeDtlWork.BelongMinSectionCode;
                wkEmployeeDtl.BelongMinSectionName = wkEmployeeDtlWork.BelongMinSectionName;
                wkEmployeeDtl.BelongSalesAreaCode  = wkEmployeeDtlWork.BelongSalesAreaCode;
                wkEmployeeDtl.BelongSalesAreaName  = wkEmployeeDtlWork.BelongSalesAreaName;
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                wkEmployeeDtl.EmployAnalysCode1 = wkEmployeeDtlWork.EmployAnalysCode1;
                wkEmployeeDtl.EmployAnalysCode2 = wkEmployeeDtlWork.EmployAnalysCode2;
                wkEmployeeDtl.EmployAnalysCode3 = wkEmployeeDtlWork.EmployAnalysCode3;
                wkEmployeeDtl.EmployAnalysCode4 = wkEmployeeDtlWork.EmployAnalysCode4;
                wkEmployeeDtl.EmployAnalysCode5 = wkEmployeeDtlWork.EmployAnalysCode5;
                wkEmployeeDtl.EmployAnalysCode6 = wkEmployeeDtlWork.EmployAnalysCode6;
                // 2008.11.10 add start --------------------------------------------->>
                wkEmployeeDtl.UOESnmDiv = wkEmployeeDtlWork.UOESnmDiv;
                // 2008.11.10 add end -----------------------------------------------<<

                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                wkEmployeeDtl.OldBelongSectionCd = wkEmployeeDtlWork.OldBelongSectionCd;
                wkEmployeeDtl.OldBelongSectionNm = wkEmployeeDtlWork.OldBelongSectionNm;
                wkEmployeeDtl.OldBelongSubSecCd = wkEmployeeDtlWork.OldBelongSubSecCd;
                wkEmployeeDtl.OldBelongSubSecNm = wkEmployeeDtlWork.OldBelongSubSecNm;
                wkEmployeeDtl.OldBelongMinSecCd = wkEmployeeDtlWork.OldBelongMinSecCd;
                wkEmployeeDtl.OldBelongMinSecNm = wkEmployeeDtlWork.OldBelongMinSecNm;
                wkEmployeeDtl.SectionChgDate = wkEmployeeDtlWork.SectionChgDate;
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

                // 2009.03.02 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                wkEmployeeDtl.MailAddrKindCode1 = wkEmployeeDtlWork.MailAddrKindCode1;
                wkEmployeeDtl.MailAddrKindName1 = wkEmployeeDtlWork.MailAddrKindName1;
                wkEmployeeDtl.MailAddress1 = wkEmployeeDtlWork.MailAddress1;
                wkEmployeeDtl.MailSendCode1 = wkEmployeeDtlWork.MailSendCode1;
                wkEmployeeDtl.MailAddrKindCode2 = wkEmployeeDtlWork.MailAddrKindCode2;
                wkEmployeeDtl.MailAddrKindName2 = wkEmployeeDtlWork.MailAddrKindName2;
                wkEmployeeDtl.MailAddress2 = wkEmployeeDtlWork.MailAddress2;
                wkEmployeeDtl.MailSendCode2 = wkEmployeeDtlWork.MailSendCode2;
                // 2009.03.02 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //_employeeDtlTable_Stc[hashKey] = wkEmployeeDtl;
            }
        }
        // 2007.08.14 �ǉ� <<<<<<<<<<

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

			// --- Search�p --- //
			// KeyList�ݒ�
			string[] employeeKeys = new string[1];
			employeeKeys[0] = LoginInfoAcquisition.EnterpriseCode;
			// ���[�J���t�@�C���Ǎ��ݏ���
			object wkObj = offlineDataSerializer.DeSerialize("EmployeeAcs", employeeKeys);
			// ArrayList�ɃZ�b�g
			ArrayList wkList = wkObj as ArrayList;
			
			if ((wkList != null) &&
				(wkList.Count != 0))
			{
				// �]�ƈ��N���X���[�J�[�N���X�iArrayList�j �� UI�N���X�iStatic�j�ϊ�����
				CopyToStaticFromWorker(wkList);
			}

            // 2010/02/18 Add >>>
            if (!_optFeliCaAcs) return;
            // ���[�J���t�@�C���ǂݍ���
            employeeKeys[0] += "_felica";
            object wkObj2 = offlineDataSerializer.DeSerialize("EmployeeAcs", employeeKeys);
            if (wkObj2 == null) return;

            ArrayList wkList2 = wkObj2 as ArrayList;
            _felicaMngWkList_Stc = new List<FeliCaMngWork>();
            foreach (FeliCaMngWork wk in wkList2)
                _felicaMngWkList_Stc.Add(wk);
            // 2010/02/18 Add <<<
		}

		//----- ueno add ---------- start 2008.02.12
		/// <summary>
		/// ���[�J���c�a�Ή����_���N���X�쐬����
		/// </summary>
		/// <returns>Boolean</returns>
		/// <remarks>
		/// <br>Note       : ���_���N���X�쐬�𖢍쐬���ɍ쐬���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
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
		//----- ueno add ---------- end 2008.02.12
		
		#endregion
    }
}
