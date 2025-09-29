using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   RecoveryDataOrderCndtn
	/// <summary>
	///                      �����f�[�^�ꗗ�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �����f�[�^�ꗗ�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/12/02  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class RecoveryDataOrderCndtn
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>�V�X�e���敪</summary>
		/// <remarks>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[ 9:�S��</remarks>
        private SystemDivState _systemDivCd;

		/// <summary>���_�R�[�h�i�����w��j</summary>
		private string[] _sectionCodes;

		/// <summary>�J�nUOE������R�[�h</summary>
		private Int32 _st_UOESupplierCd;

		/// <summary>�I��UOE������R�[�h</summary>
		private Int32 _ed_UOESupplierCd;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

        // ���������ȊO
        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;

        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>���ŋ敪</summary>
        /// <remarks>0:�V�X�e���敪 1:���Ȃ�</remarks>
        private NewPageDivState _newPageDiv;


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

		/// public propaty name  :  SystemDivCd
		/// <summary>�V�X�e���敪�v���p�e�B</summary>
		/// <value>0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �V�X�e���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SystemDivState SystemDivCd
		{
			get{return _systemDivCd;}
			set{_systemDivCd = value;}
		}

		/// public propaty name  :  SectionCodes
		/// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_UOESupplierCd
		/// <summary>�J�nUOE������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�nUOE������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_UOESupplierCd
		{
			get{return _st_UOESupplierCd;}
			set{_st_UOESupplierCd = value;}
		}

		/// public propaty name  :  Ed_UOESupplierCd
		/// <summary>�I��UOE������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I��UOE������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_UOESupplierCd
		{
			get{return _ed_UOESupplierCd;}
			set{_ed_UOESupplierCd = value;}
		}

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

        /// <summary>
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }

        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

        /// <summary>
        /// ���y�[�W�敪�@�v���p�e�B
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }

		/// <summary>
		/// �����f�[�^�ꗗ�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>RecoveryDataOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RecoveryDataOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public RecoveryDataOrderCndtn()
		{
		}

		/// <summary>
		/// �����f�[�^�ꗗ�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="systemDivCd">�V�X�e���敪(0:����� 1:�`�� 2:���� 3�F�ꊇ 4�F��[)</param>
		/// <param name="sectionCodes">���_�R�[�h�i�����w��j</param>
		/// <param name="st_UOESupplierCd">�J�nUOE������R�[�h</param>
		/// <param name="ed_UOESupplierCd">�I��UOE������R�[�h</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <returns>RecoveryDataOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RecoveryDataOrderCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public RecoveryDataOrderCndtn(string enterpriseCode, SystemDivState systemDivCd, string[] sectionCodes, Int32 st_UOESupplierCd, Int32 ed_UOESupplierCd, string enterpriseName,
            bool isOptSection, bool isSelectAllSection, NewPageDivState newPageDiv)
		{
			this._enterpriseCode = enterpriseCode;
			this._systemDivCd = systemDivCd;
			this._sectionCodes = sectionCodes;
			this._st_UOESupplierCd = st_UOESupplierCd;
			this._ed_UOESupplierCd = ed_UOESupplierCd;
			this._enterpriseName = enterpriseName;
            this._isOptSection = isOptSection;
            this._isSelectAllSection = isSelectAllSection;
            this._newPageDiv = newPageDiv;

		}

		/// <summary>
		/// �����f�[�^�ꗗ�\���o�����N���X��������
		/// </summary>
		/// <returns>RecoveryDataOrderCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����RecoveryDataOrderCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public RecoveryDataOrderCndtn Clone()
		{
			return new RecoveryDataOrderCndtn(this._enterpriseCode,this._systemDivCd,this._sectionCodes,this._st_UOESupplierCd,this._ed_UOESupplierCd,this._enterpriseName, this._isOptSection, this._isSelectAllSection, this._newPageDiv);
		}

		/// <summary>
		/// �����f�[�^�ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�RecoveryDataOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RecoveryDataOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(RecoveryDataOrderCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SystemDivCd == target.SystemDivCd)
				 && (this.SectionCodes == target.SectionCodes)
				 && (this.St_UOESupplierCd == target.St_UOESupplierCd)
				 && (this.Ed_UOESupplierCd == target.Ed_UOESupplierCd)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.IsOptSection == target.IsOptSection)
                 && (this.IsSelectAllSection == target.IsSelectAllSection)
                 && (this.NewPageDiv == target.NewPageDiv)
                 );
		}

		/// <summary>
		/// �����f�[�^�ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="recoveryDataOrderCndtn1">
		///                    ��r����RecoveryDataOrderCndtn�N���X�̃C���X�^���X
		/// </param>
		/// <param name="recoveryDataOrderCndtn2">��r����RecoveryDataOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RecoveryDataOrderCndtn�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(RecoveryDataOrderCndtn recoveryDataOrderCndtn1, RecoveryDataOrderCndtn recoveryDataOrderCndtn2)
		{
			return ((recoveryDataOrderCndtn1.EnterpriseCode == recoveryDataOrderCndtn2.EnterpriseCode)
				 && (recoveryDataOrderCndtn1.SystemDivCd == recoveryDataOrderCndtn2.SystemDivCd)
				 && (recoveryDataOrderCndtn1.SectionCodes == recoveryDataOrderCndtn2.SectionCodes)
				 && (recoveryDataOrderCndtn1.St_UOESupplierCd == recoveryDataOrderCndtn2.St_UOESupplierCd)
				 && (recoveryDataOrderCndtn1.Ed_UOESupplierCd == recoveryDataOrderCndtn2.Ed_UOESupplierCd)
				 && (recoveryDataOrderCndtn1.EnterpriseName == recoveryDataOrderCndtn2.EnterpriseName)
                 && (recoveryDataOrderCndtn1.IsOptSection == recoveryDataOrderCndtn2.IsOptSection)
                 && (recoveryDataOrderCndtn1.IsSelectAllSection == recoveryDataOrderCndtn2.IsSelectAllSection)
                 && (recoveryDataOrderCndtn1.NewPageDiv == recoveryDataOrderCndtn2.NewPageDiv)
                 );
		}
		/// <summary>
		/// �����f�[�^�ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�RecoveryDataOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RecoveryDataOrderCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(RecoveryDataOrderCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SystemDivCd != target.SystemDivCd)resList.Add("SystemDivCd");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
			if(this.St_UOESupplierCd != target.St_UOESupplierCd)resList.Add("St_UOESupplierCd");
			if(this.Ed_UOESupplierCd != target.Ed_UOESupplierCd)resList.Add("Ed_UOESupplierCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
            if (this.IsOptSection != target.IsOptSection) resList.Add("IsOptSection");
            if (this.IsSelectAllSection != target.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");



			return resList;
		}

		/// <summary>
		/// �����f�[�^�ꗗ�\���o�����N���X��r����
		/// </summary>
		/// <param name="recoveryDataOrderCndtn1">��r����RecoveryDataOrderCndtn�N���X�̃C���X�^���X</param>
		/// <param name="recoveryDataOrderCndtn2">��r����RecoveryDataOrderCndtn�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   RecoveryDataOrderCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(RecoveryDataOrderCndtn recoveryDataOrderCndtn1, RecoveryDataOrderCndtn recoveryDataOrderCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(recoveryDataOrderCndtn1.EnterpriseCode != recoveryDataOrderCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(recoveryDataOrderCndtn1.SystemDivCd != recoveryDataOrderCndtn2.SystemDivCd)resList.Add("SystemDivCd");
			if(recoveryDataOrderCndtn1.SectionCodes != recoveryDataOrderCndtn2.SectionCodes)resList.Add("SectionCodes");
			if(recoveryDataOrderCndtn1.St_UOESupplierCd != recoveryDataOrderCndtn2.St_UOESupplierCd)resList.Add("St_UOESupplierCd");
			if(recoveryDataOrderCndtn1.Ed_UOESupplierCd != recoveryDataOrderCndtn2.Ed_UOESupplierCd)resList.Add("Ed_UOESupplierCd");
			if(recoveryDataOrderCndtn1.EnterpriseName != recoveryDataOrderCndtn2.EnterpriseName)resList.Add("EnterpriseName");
            if (recoveryDataOrderCndtn1.IsOptSection != recoveryDataOrderCndtn2.IsOptSection) resList.Add("IsOptSection");
            if (recoveryDataOrderCndtn1.IsSelectAllSection != recoveryDataOrderCndtn2.IsSelectAllSection) resList.Add("IsSelectAllSection");
            if (recoveryDataOrderCndtn1.NewPageDiv != recoveryDataOrderCndtn2.NewPageDiv) resList.Add("NewPageDiv");
			return resList;
		}

        #region �����ږ��̃v���p�e�B
        /// <summary>
        /// �V�X�e���敪�^�C�g���@�v���p�e�B
        /// </summary>
        public string SystemDivStateTitle
        {
            get
            {
                switch (this._systemDivCd)
                {
                    case SystemDivState.Manual: return ct_SystemDivState_Manual;
                    case SystemDivState.Slip: return ct_SystemDivState_Slip;
                    case SystemDivState.Search: return ct_SystemDivState_Search;
                    case SystemDivState.Lump: return ct_SystemDivState_Lump;
                    case SystemDivState.All: return ct_SystemDivState_All;
                    default: return "";
                }
            }
        }

        #endregion

        #region ���񋓑�
        /// <summary>
        /// ���y�[�W�敪�@�񋓑�
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>�V�X�e���敪��</summary>
            System = 0,
            /// <summary>���Ȃ�</summary>
            None = 1,
        }

        /// <summary>
        /// ���s�^�C�v�񋓑�
        /// </summary>
        public enum SystemDivState
        {
            /// <summary>�����</summary>
            Manual = 0,
            /// <summary>�`��</summary>
            Slip = 1,
            /// <summary>����</summary>
            Search = 2,
            /// <summary>�ꊇ</summary>
            Lump = 3,
            /// <summary>�S��</summary>
            All = 9,

        }

        /// <summary>
        /// �f�[�^���M�敪�񋓑�
        /// </summary>
        public enum DataSendCodeState
        {
            /// <summary>���M�G���[</summary>
            SendErr = 2,
            /// <summary>��M�G���[</summary>
            ReceiveErr = 3,
            /// <summary>�ُ�I��</summary>
            AbnormalErr = 4,
        }
        #endregion

        #region �����ږ���

        /// <summary>�V�X�e���敪</summary>
        public const string ct_SystemDivState_Manual = "�����";
        public const string ct_SystemDivState_Slip = "�`��";
        public const string ct_SystemDivState_Search = "����";
        public const string ct_SystemDivState_Lump = "�ꊇ";
        public const string ct_SystemDivState_All = "�S��";

        public const string ct_DataSendCode_SendErr = "���M�װ";
        public const string ct_DataSendCode_ReceiveErr = "��M�װ";
        public const string ct_DataSendCode_AbnormalErr = "�ُ�I��";
        #endregion
	}
}
