//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �[���Ǘ��ݒ�}�X�^
// �v���O�����T�v   : �[���Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/05  �C�����e : SCM�I�v�V�����Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   PosTerminalMg
	/// <summary>
	///                      �[���Ǘ��}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   �[���Ǘ��}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/06/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class PosTerminalMg
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private string _updEmployeeCode = "";

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

        /* --- DEL 2008/06/18 --------->>>>>
		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";
           --- DEL 2008/06/18 ---------<<<<<*/

		/// <summary>���W�ԍ�</summary>
        /// <remarks>�}�V���ԍ�</remarks>
        private Int32 _cashRegisterNo;

		/// <summary>POS/PC�[���敪</summary>
		/// <remarks>1�FPOS�[���g�p�A2�FPC�[���g�p</remarks>
		private Int32 _posPCTermCd;

        // --- ADD 2008/06/18 ---------->>>>>
        /// <summary>�g�p����敪</summary>
        private string _useLanguageDivCd = "";

        /// <summary>�g�p�J���`���[�敪</summary>
        private string _useCultureDivCd = "";
        // --- ADD 2008/06/18 ----------<<<<<

        // ADD 2009/06/05 ------>>>
        /// <summary>�[��IP�A�h���X</summary>
        private string _machineIpAddr = "";

        /// <summary>�[������</summary>
        private string _machineName = "";
        // ADD 2009/06/05 ------<<<

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";


		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>�쐬���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>�쐬���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>�쐬���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>�X�V���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>�X�V���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>�X�V���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUID�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

        /* --- DEL 2008/06/18 ---------->>>>>
		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}
           --- DEL 2008/06/18 ----------<<<<<*/

		/// public propaty name  :  CashRegisterNo
		/// <summary>���W�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���W�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CashRegisterNo
		{
			get{return _cashRegisterNo;}
			set{_cashRegisterNo = value;}
		}

        // --- ADD 2008/06/17 ---------->>>>>
		/// public propaty name  :  PosPCTermCd
		/// <summary>POS/PC�[���敪�v���p�e�B</summary>
		/// <value>1�FPOS�[���g�p�A2�FPC�[���g�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   POS/PC�[���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PosPCTermCd
		{
			get{return _posPCTermCd;}
			set{_posPCTermCd = value;}
		}

        // --- ADD 2008/06/18 ---------->>>>>
        /// public propaty name  :  UseLanguageDivCd
        /// <summary>�g�p����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�p����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UseLanguageDivCd
        {
            get { return _useLanguageDivCd; }
            set { _useLanguageDivCd = value; }
        }

        /// public propaty name  :  UseCultureDivCd
        /// <summary>�g�p�J���`���[�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�p�J���`���[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UseCultureDivCd
        {
            get { return _useCultureDivCd; }
            set { _useCultureDivCd = value; }
        }
        // --- ADD 2008/06/18 ----------<<<<<

        // ADD 2009/06/05 ------>>>
        /// public propaty name  :  MachineIpAddr
        /// <summary>�[��IP�A�h���X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[��IP�A�h���X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MachineIpAddr
        {
            get { return _machineIpAddr; }
            set { _machineIpAddr = value; }
        }

        /// public propaty name  :  MachineIpAddr
        /// <summary>�[�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }
        // ADD 2009/06/05 ------<<<
        
		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}


		/// <summary>
		/// �[���Ǘ��}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>PosTerminalMg�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PosTerminalMg�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PosTerminalMg()
		{
		}

		/// <summary>
		/// �[���Ǘ��}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="cashRegisterNo">���W�ԍ�(�}�V���ԍ�)</param>
        /// <param name="posPCTermCd">POS/PC�[���敪(1�FPOS�[���g�p�A2�FPC�[���g�p)</param>
        /// <param name="useLanguageDivCd">�g�p����敪</param>
        /// <param name="useCultureDivCd">�g�p�J���`���[�敪</param>
        /// <param name="machineIpAddr">�[��IP�A�h���X</param>
        /// <param name="machineName">�[������</param>
        /// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>PosTerminalMg�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PosTerminalMg�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        //public PosTerminalMg(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 cashRegisterNo, Int32 posPCTermCd, string useLanguageDivCd, string useCultureDivCd, string enterpriseName, string updEmployeeName)
        public PosTerminalMg(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 cashRegisterNo, Int32 posPCTermCd, string useLanguageDivCd, string useCultureDivCd, string machineIpAddr, string machineName, string enterpriseName, string updEmployeeName)
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			//this._sectionCode = sectionCode;                  // DEL 2008/06/18
			this._cashRegisterNo = cashRegisterNo;
			this._posPCTermCd = posPCTermCd;
            this._useLanguageDivCd = useLanguageDivCd;
            this._useCultureDivCd = useCultureDivCd;
            this._machineIpAddr = machineIpAddr;    // ADD 2009/06/05
            this._machineName = machineName;        // ADD 2009/06/05
            this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// �[���Ǘ��}�X�^��������
		/// </summary>
		/// <returns>PosTerminalMg�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PosTerminalMg�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PosTerminalMg Clone()
		{
            //return new PosTerminalMg(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._cashRegisterNo, this._posPCTermCd, this._useLanguageDivCd, this._useCultureDivCd, this._enterpriseName, this._updEmployeeName);
            return new PosTerminalMg(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._cashRegisterNo, this._posPCTermCd, this._useLanguageDivCd, this._useCultureDivCd, this._machineIpAddr, this._machineName, this._enterpriseName, this._updEmployeeName);
        }

		/// <summary>
		/// �[���Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�PosTerminalMg�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PosTerminalMg�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(PosTerminalMg target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 //&& (this.SectionCode == target.SectionCode)              // DEL 2008/06/18
				 && (this.CashRegisterNo == target.CashRegisterNo)
				 && (this.PosPCTermCd == target.PosPCTermCd)
                 && (this.UseLanguageDivCd == target.UseLanguageDivCd)
                 && (this.UseCultureDivCd == target.UseCultureDivCd)
                 && (this.MachineIpAddr == target.MachineIpAddr)    // ADD 2009/06/05
                 && (this.MachineName == target.MachineName)        // ADD 2009/06/05
                 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// �[���Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="posTerminalMg1">
		///                    ��r����PosTerminalMg�N���X�̃C���X�^���X
		/// </param>
		/// <param name="posTerminalMg2">��r����PosTerminalMg�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PosTerminalMg�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(PosTerminalMg posTerminalMg1, PosTerminalMg posTerminalMg2)
		{
			return ((posTerminalMg1.CreateDateTime == posTerminalMg2.CreateDateTime)
				 && (posTerminalMg1.UpdateDateTime == posTerminalMg2.UpdateDateTime)
				 && (posTerminalMg1.EnterpriseCode == posTerminalMg2.EnterpriseCode)
				 && (posTerminalMg1.FileHeaderGuid == posTerminalMg2.FileHeaderGuid)
				 && (posTerminalMg1.UpdEmployeeCode == posTerminalMg2.UpdEmployeeCode)
				 && (posTerminalMg1.UpdAssemblyId1 == posTerminalMg2.UpdAssemblyId1)
				 && (posTerminalMg1.UpdAssemblyId2 == posTerminalMg2.UpdAssemblyId2)
				 && (posTerminalMg1.LogicalDeleteCode == posTerminalMg2.LogicalDeleteCode)
				 //&& (posTerminalMg1.SectionCode == posTerminalMg2.SectionCode)            // DEL 2008/06/18
				 && (posTerminalMg1.CashRegisterNo == posTerminalMg2.CashRegisterNo)
				 && (posTerminalMg1.PosPCTermCd == posTerminalMg2.PosPCTermCd)
                 && (posTerminalMg1.UseLanguageDivCd == posTerminalMg2.UseLanguageDivCd)
                 && (posTerminalMg1.UseCultureDivCd == posTerminalMg2.UseCultureDivCd)
                 && (posTerminalMg1.MachineIpAddr == posTerminalMg2.MachineIpAddr)    // ADD 2009/06/05
                 && (posTerminalMg1.MachineName == posTerminalMg2.MachineName)        // ADD 2009/06/05
                 && (posTerminalMg1.EnterpriseName == posTerminalMg2.EnterpriseName)
				 && (posTerminalMg1.UpdEmployeeName == posTerminalMg2.UpdEmployeeName));
		}
		/// <summary>
		/// �[���Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�PosTerminalMg�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PosTerminalMg�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(PosTerminalMg target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			//if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");                     // DEL 2008/06/18
			if(this.CashRegisterNo != target.CashRegisterNo)resList.Add("CashRegisterNo");
			if(this.PosPCTermCd != target.PosPCTermCd)resList.Add("PosPCTermCd");
            if(this.UseLanguageDivCd != target.UseLanguageDivCd) resList.Add("UseLanguageDivCd");
            if(this.UseCultureDivCd != target.UseCultureDivCd) resList.Add("UseCultureDivCd");
            if (this.MachineIpAddr != target.MachineIpAddr) resList.Add("MachineIpAddr");   // ADD 2009/06/05
            if (this.MachineName != target.MachineName) resList.Add("MachineName");         // ADD 2009/06/05
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// �[���Ǘ��}�X�^��r����
		/// </summary>
		/// <param name="posTerminalMg1">��r����PosTerminalMg�N���X�̃C���X�^���X</param>
		/// <param name="posTerminalMg2">��r����PosTerminalMg�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PosTerminalMg�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(PosTerminalMg posTerminalMg1, PosTerminalMg posTerminalMg2)
		{
			ArrayList resList = new ArrayList();
			if(posTerminalMg1.CreateDateTime != posTerminalMg2.CreateDateTime)resList.Add("CreateDateTime");
			if(posTerminalMg1.UpdateDateTime != posTerminalMg2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(posTerminalMg1.EnterpriseCode != posTerminalMg2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(posTerminalMg1.FileHeaderGuid != posTerminalMg2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(posTerminalMg1.UpdEmployeeCode != posTerminalMg2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(posTerminalMg1.UpdAssemblyId1 != posTerminalMg2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(posTerminalMg1.UpdAssemblyId2 != posTerminalMg2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(posTerminalMg1.LogicalDeleteCode != posTerminalMg2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
            //if(posTerminalMg1.SectionCode != posTerminalMg2.SectionCode)resList.Add("SectionCode");                   // DEL 2008/06/18
			if(posTerminalMg1.CashRegisterNo != posTerminalMg2.CashRegisterNo)resList.Add("CashRegisterNo");
			if(posTerminalMg1.PosPCTermCd != posTerminalMg2.PosPCTermCd)resList.Add("PosPCTermCd");
            if(posTerminalMg1.UseLanguageDivCd != posTerminalMg2.UseLanguageDivCd) resList.Add("UseLanguageDivCd");
            if(posTerminalMg1.UseCultureDivCd != posTerminalMg2.UseCultureDivCd) resList.Add("UseCultureDivCd");
            if (posTerminalMg1.MachineIpAddr != posTerminalMg2.MachineIpAddr) resList.Add("MachineIpAddr");     // ADD 2009/06/05
            if (posTerminalMg1.MachineName != posTerminalMg2.MachineName) resList.Add("MachineName");           // ADD 2009/06/05
            if (posTerminalMg1.EnterpriseName != posTerminalMg2.EnterpriseName) resList.Add("EnterpriseName");
			if(posTerminalMg1.UpdEmployeeName != posTerminalMg2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
