using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecPrintSet
    /// <summary>
    ///                      �]�ƈ��}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �]�ƈ��}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class EmployeeSet 
    {
        /// <summary>�]�ƈ��R�[�h</summary>
		private string _employeeCode = "";

		/// <summary>����</summary>
		private string _name = "";

		/// <summary>�J�i</summary>
		private string _kana = "";

		/// <summary>�Z�k����</summary>
		private string _shortName = "";

		/// <summary>���ʖ���</summary>
		/// <remarks>�S�p�ŊǗ�</remarks>
		private string _sexName = "";

		/// <summary>���N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _birthday;

		/// <summary>�d�b�ԍ��i��Ёj</summary>
		private string _companyTelNo = "";

		/// <summary>�d�b�ԍ��i�g�сj</summary>
		private string _portableTelNo = "";

		/// <summary>�E��</summary>
		/// <remarks>80:�X�� 70:�X���̔���(���Ј�) 60:�X���̔���(�A���o�C�g) 40:�o�b�N���[�h�S���� 20:����</remarks>
		private Int32 _authorityLevel1;

		/// <summary>�E�햼��</summary>
		private string _authorityLevelNm1 = "";

		/// <summary>�ٗp�`��</summary>
		/// <remarks>50:���Ј� 10:�A���o�C�g</remarks>
		private Int32 _authorityLevel2;

		/// <summary>�ٗp�`�Ԗ���</summary>
		private string _authorityLevelNm2 = "";

		/// <summary>�������_�R�[�h</summary>
		private string _belongSectionCode = "";

		/// <summary>���_�K�C�h����</summary>
		private string _sectionGuideNm = "";

		/// <summary>��������R�[�h</summary>
		private Int32 _belongSubSectionCode;

		/// <summary>���喼��</summary>
		private string _subSectionName = "";

		/// <summary>���Г�</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _enterCompanyDate;

		/// <summary>�ސE��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _retirementDate;

		/// <summary>�]�ƈ����̓R�[�h�P</summary>
		private Int32 _employAnalysCode1;

		/// <summary>�]�ƈ����̓R�[�h�Q</summary>
		private Int32 _employAnalysCode2;

		/// <summary>�]�ƈ����̓R�[�h�R</summary>
		private Int32 _employAnalysCode3;

		/// <summary>�]�ƈ����̓R�[�h�S</summary>
		private Int32 _employAnalysCode4;

		/// <summary>�]�ƈ����̓R�[�h�T</summary>
		private Int32 _employAnalysCode5;

		/// <summary>�]�ƈ����̓R�[�h�U</summary>
		private Int32 _employAnalysCode6;


        /// public propaty name  :  EmployeeCode
		/// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EmployeeCode
		{
			get{return _employeeCode;}
			set{_employeeCode = value;}
		}

		/// public propaty name  :  Name
		/// <summary>���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  Kana
		/// <summary>�J�i�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�i�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Kana
		{
			get{return _kana;}
			set{_kana = value;}
		}

		/// public propaty name  :  ShortName
		/// <summary>�Z�k���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z�k���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ShortName
		{
			get{return _shortName;}
			set{_shortName = value;}
		}

		/// public propaty name  :  SexName
		/// <summary>���ʖ��̃v���p�e�B</summary>
		/// <value>�S�p�ŊǗ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ʖ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SexName
		{
			get{return _sexName;}
			set{_sexName = value;}
		}

		/// public propaty name  :  Birthday
		/// <summary>���N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Birthday
		{
			get{return _birthday;}
			set{_birthday = value;}
		}

		/// public propaty name  :  CompanyTelNo
		/// <summary>�d�b�ԍ��i��Ёj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i��Ёj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelNo
		{
			get{return _companyTelNo;}
			set{_companyTelNo = value;}
		}

		/// public propaty name  :  PortableTelNo
		/// <summary>�d�b�ԍ��i�g�сj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �d�b�ԍ��i�g�сj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PortableTelNo
		{
			get{return _portableTelNo;}
			set{_portableTelNo = value;}
		}

		/// public propaty name  :  AuthorityLevel1
		/// <summary>�E��v���p�e�B</summary>
		/// <value>80:�X�� 70:�X���̔���(���Ј�) 60:�X���̔���(�A���o�C�g) 40:�o�b�N���[�h�S���� 20:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �E��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AuthorityLevel1
		{
			get{return _authorityLevel1;}
			set{_authorityLevel1 = value;}
		}

		/// public propaty name  :  AuthorityLevelNm1
		/// <summary>�E�햼�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �E�햼�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AuthorityLevelNm1
		{
			get{return _authorityLevelNm1;}
			set{_authorityLevelNm1 = value;}
		}

		/// public propaty name  :  AuthorityLevel2
		/// <summary>�ٗp�`�ԃv���p�e�B</summary>
		/// <value>50:���Ј� 10:�A���o�C�g</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ٗp�`�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AuthorityLevel2
		{
			get{return _authorityLevel2;}
			set{_authorityLevel2 = value;}
		}

		/// public propaty name  :  AuthorityLevelNm2
		/// <summary>�ٗp�`�Ԗ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ٗp�`�Ԗ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AuthorityLevelNm2
		{
			get{return _authorityLevelNm2;}
			set{_authorityLevelNm2 = value;}
		}

		/// public propaty name  :  BelongSectionCode
		/// <summary>�������_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string BelongSectionCode
		{
			get{return _belongSectionCode;}
			set{_belongSectionCode = value;}
		}

		/// public propaty name  :  SectionGuideNm
		/// <summary>���_�K�C�h���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
		}

		/// public propaty name  :  BelongSubSectionCode
		/// <summary>��������R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BelongSubSectionCode
		{
			get{return _belongSubSectionCode;}
			set{_belongSubSectionCode = value;}
		}

		/// public propaty name  :  SubSectionName
		/// <summary>���喼�̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���喼�̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SubSectionName
		{
			get{return _subSectionName;}
			set{_subSectionName = value;}
		}

		/// public propaty name  :  EnterCompanyDate
		/// <summary>���Г��v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Г��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime EnterCompanyDate
		{
			get{return _enterCompanyDate;}
			set{_enterCompanyDate = value;}
		}

		/// public propaty name  :  RetirementDate
		/// <summary>�ސE���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ސE���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime RetirementDate
		{
			get{return _retirementDate;}
			set{_retirementDate = value;}
		}

		/// public propaty name  :  EmployAnalysCode1
		/// <summary>�]�ƈ����̓R�[�h�P�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ����̓R�[�h�P�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployAnalysCode1
		{
			get{return _employAnalysCode1;}
			set{_employAnalysCode1 = value;}
		}

		/// public propaty name  :  EmployAnalysCode2
		/// <summary>�]�ƈ����̓R�[�h�Q�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ����̓R�[�h�Q�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployAnalysCode2
		{
			get{return _employAnalysCode2;}
			set{_employAnalysCode2 = value;}
		}

		/// public propaty name  :  EmployAnalysCode3
		/// <summary>�]�ƈ����̓R�[�h�R�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ����̓R�[�h�R�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployAnalysCode3
		{
			get{return _employAnalysCode3;}
			set{_employAnalysCode3 = value;}
		}

		/// public propaty name  :  EmployAnalysCode4
		/// <summary>�]�ƈ����̓R�[�h�S�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ����̓R�[�h�S�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployAnalysCode4
		{
			get{return _employAnalysCode4;}
			set{_employAnalysCode4 = value;}
		}

		/// public propaty name  :  EmployAnalysCode5
		/// <summary>�]�ƈ����̓R�[�h�T�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ����̓R�[�h�T�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployAnalysCode5
		{
			get{return _employAnalysCode5;}
			set{_employAnalysCode5 = value;}
		}

		/// public propaty name  :  EmployAnalysCode6
		/// <summary>�]�ƈ����̓R�[�h�U�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �]�ƈ����̓R�[�h�U�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EmployAnalysCode6
		{
			get{return _employAnalysCode6;}
			set{_employAnalysCode6 = value;}
		}

        /// <summary>
        /// �]�ƈ��i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public EmployeeSet Clone()
        {
            return new EmployeeSet(this._employeeCode, this._name, this._kana, this._shortName, this._sexName, this._birthday, this._companyTelNo, this._portableTelNo, this._authorityLevel1, this._authorityLevelNm1, this._authorityLevel2, this._authorityLevelNm2, this._belongSectionCode, this._sectionGuideNm, this._belongSubSectionCode, this._subSectionName, this._enterCompanyDate, this._retirementDate, this._employAnalysCode1, this._employAnalysCode2, this._employAnalysCode3, this._employAnalysCode4, this._employAnalysCode5, this._employAnalysCode6);

        }

        /// <summary>
		/// �]�ƈ��i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public EmployeeSet()
		{
		}

        /// <summary>
        /// �]�ƈ��i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="EmployeeCode"></param>
        /// <param name="Name"></param>
        /// <param name="Kana"></param>
        /// <param name="ShortName"></param>
        /// <param name="SexName"></param>
        /// <param name="Birthday"></param>
        /// <param name="CompanyTelNo"></param>
        /// <param name="PortableTelNo"></param>
        /// <param name="AuthorityLevel1"></param>
        /// <param name="AuthorityLevelNm1"></param>
        /// <param name="AuthorityLevel2"></param>
        /// <param name="AuthorityLevelNm2"></param>
        /// <param name="BelongSectionCode"></param>
        /// <param name="SectionGuideNm"></param>
        /// <param name="BelongSubSectionCode"></param>
        /// <param name="SubSectionName"></param>
        /// <param name="EnterCompanyDate"></param>
        /// <param name="RetirementDate"></param>
        /// <param name="EmployAnalysCode1"></param>
        /// <param name="EmployAnalysCode2"></param>
        /// <param name="EmployAnalysCode3"></param>
        /// <param name="EmployAnalysCode4"></param>
        /// <param name="EmployAnalysCode5"></param>
        /// <param name="EmployAnalysCode6"></param>
        public EmployeeSet(string EmployeeCode, string Name, string Kana, string ShortName, string SexName, DateTime Birthday, string CompanyTelNo, string PortableTelNo, Int32 AuthorityLevel1, string AuthorityLevelNm1, Int32 AuthorityLevel2, string AuthorityLevelNm2, string BelongSectionCode, string SectionGuideNm, Int32 BelongSubSectionCode, string SubSectionName, DateTime EnterCompanyDate, DateTime RetirementDate, Int32 EmployAnalysCode1, Int32 EmployAnalysCode2, Int32 EmployAnalysCode3, Int32 EmployAnalysCode4, Int32 EmployAnalysCode5, Int32 EmployAnalysCode6)
        {
            this._employeeCode = EmployeeCode;
            this._name = Name;
            this._kana = Kana;
            this._shortName = ShortName;
            this._sexName = SexName;
            this._birthday = Birthday;
            this._companyTelNo = CompanyTelNo;
            this._portableTelNo = PortableTelNo;
            this._authorityLevel1 = AuthorityLevel1;
            this._authorityLevelNm1 = AuthorityLevelNm1;
            this._authorityLevel2 = AuthorityLevel2;
            this._authorityLevelNm2 = AuthorityLevelNm2;
            this._belongSectionCode = BelongSectionCode;
            this._sectionGuideNm = SectionGuideNm;
            this._belongSubSectionCode = BelongSubSectionCode;
            this._subSectionName = SubSectionName;
            this._enterCompanyDate = EnterCompanyDate;
            this._retirementDate = RetirementDate;
            this._employAnalysCode1 = EmployAnalysCode1;
            this._employAnalysCode2 = EmployAnalysCode2;
            this._employAnalysCode3 = EmployAnalysCode3;
            this._employAnalysCode4 = EmployAnalysCode4;
            this._employAnalysCode5 = EmployAnalysCode5;
            this._employAnalysCode6 = EmployAnalysCode6;

        }
    }
}
