using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SmplInqBas
    /// <summary>
    ///                      �ȒP�⍇��ID�t�����}�X�^(��{���)
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ȒP�⍇��ID�t�����}�X�^(��{���)�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   ���� �m</br>
    /// <br>Genarated Date   :   2010/04/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SmplInqBas
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�ȒP�⍇��ID�t�����Ǘ��ԍ�</summary>
        /// <remarks>���[�U�[�P�ʂ̘A��</remarks>
        private Int64 _simpleInqIdInfMngNo;

        /// <summary>����</summary>
        private string _name = "";

        /// <summary>����2</summary>
        private string _name2 = "";

        /// <summary>�J�i</summary>
        private string _kana = "";

        /// <summary>���ʃR�[�h</summary>
        /// <remarks>:�j,1:��,2:��</remarks>
        private Int32 _sexCode;

        /// <summary>���ʖ���</summary>
        /// <remarks>�S�p�ŊǗ�</remarks>
        private string _sexName = "";

        /// <summary>���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _birthday;

        /// <summary>�X�֔ԍ�</summary>
        private string _postNo = "";

        /// <summary>�s���{���R�[�h</summary>
        /// <remarks>�s���{���s��S���ނ̏�2��</remarks>
        private Int32 _addressCode1Upper;

        /// <summary>WEB�\���Z��(�s���{��)</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _webDspAddrADOJp = "";

        /// <summary>WEB�\���Z��(��s����)</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _webDspAddrCity = "";

        /// <summary>WEB�\���Z��(�r����}���V������)</summary>
        /// <remarks>(���p�S�p����)</remarks>
        private string _webDspAddrBuil = "";

        /// <summary>�E��R�[�h</summary>
        private Int32 _jobTypeCode;

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�d�b�ԍ��i����j</summary>
        /// <remarks>�n�C�t�����܂߂�16���̔ԍ�</remarks>
        private string _homeTelNo = "";

        /// <summary>�d�b�ԍ��i�Ζ���j</summary>
        private string _officeTelNo = "";

        /// <summary>�d�b�ԍ��i�g�сj</summary>
        private string _portableTelNo = "";

        /// <summary>FAX�ԍ��i����j</summary>
        private string _homeFaxNo = "";

        /// <summary>FAX�ԍ��i�Ζ���j</summary>
        private string _officeFaxNo = "";

        /// <summary>���[���A�h���X1</summary>
        private string _mailAddress1 = "";

        /// <summary>���[���A�h���X��ʃR�[�h1</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>���[���A�h���X2</summary>
        private string _mailAddress2 = "";

        /// <summary>���[���A�h���X��ʃR�[�h2</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>���[���A�h���X3</summary>
        private string _mailAddress3 = "";

        /// <summary>���[���A�h���X��ʃR�[�h3</summary>
        /// <remarks>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</remarks>
        private Int32 _mailAddrKindCode3;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�E�햼��</summary>
        private string _jobTypeName = "";

        /// <summary>�Ǝ햼��</summary>
        private string _businessTypeName = "";


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
            get { return _createDateTime; }
            set { _createDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SimpleInqIdInfMngNo
        /// <summary>�ȒP�⍇��ID�t�����Ǘ��ԍ��v���p�e�B</summary>
        /// <value>���[�U�[�P�ʂ̘A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ȒP�⍇��ID�t�����Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SimpleInqIdInfMngNo
        {
            get { return _simpleInqIdInfMngNo; }
            set { _simpleInqIdInfMngNo = value; }
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
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
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
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  SexCode
        /// <summary>���ʃR�[�h�v���p�e�B</summary>
        /// <value>:�j,1:��,2:��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SexCode
        {
            get { return _sexCode; }
            set { _sexCode = value; }
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
            get { return _sexName; }
            set { _sexName = value; }
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
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// public propaty name  :  BirthdayJpFormal
        /// <summary>���N���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BirthdayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _birthday); }
            set { }
        }

        /// public propaty name  :  BirthdayJpInFormal
        /// <summary>���N���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BirthdayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _birthday); }
            set { }
        }

        /// public propaty name  :  BirthdayAdFormal
        /// <summary>���N���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BirthdayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _birthday); }
            set { }
        }

        /// public propaty name  :  BirthdayAdInFormal
        /// <summary>���N���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BirthdayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _birthday); }
            set { }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  AddressCode1Upper
        /// <summary>�s���{���R�[�h�v���p�e�B</summary>
        /// <value>�s���{���s��S���ނ̏�2��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �s���{���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddressCode1Upper
        {
            get { return _addressCode1Upper; }
            set { _addressCode1Upper = value; }
        }

        /// public propaty name  :  WebDspAddrADOJp
        /// <summary>WEB�\���Z��(�s���{��)�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WEB�\���Z��(�s���{��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WebDspAddrADOJp
        {
            get { return _webDspAddrADOJp; }
            set { _webDspAddrADOJp = value; }
        }

        /// public propaty name  :  WebDspAddrCity
        /// <summary>WEB�\���Z��(��s����)�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WEB�\���Z��(��s����)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WebDspAddrCity
        {
            get { return _webDspAddrCity; }
            set { _webDspAddrCity = value; }
        }

        /// public propaty name  :  WebDspAddrBuil
        /// <summary>WEB�\���Z��(�r����}���V������)�v���p�e�B</summary>
        /// <value>(���p�S�p����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WEB�\���Z��(�r����}���V������)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WebDspAddrBuil
        {
            get { return _webDspAddrBuil; }
            set { _webDspAddrBuil = value; }
        }

        /// public propaty name  :  JobTypeCode
        /// <summary>�E��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �E��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JobTypeCode
        {
            get { return _jobTypeCode; }
            set { _jobTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>�d�b�ԍ��i����j�v���p�e�B</summary>
        /// <value>�n�C�t�����܂߂�16���̔ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>�d�b�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�b�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
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
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX�ԍ��i����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX�ԍ��i�Ζ���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX�ԍ��i�Ζ���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>���[���A�h���X1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>���[���A�h���X��ʃR�[�h1�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>���[���A�h���X2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>���[���A�h���X��ʃR�[�h2�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddress3
        /// <summary>���[���A�h���X3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MailAddress3
        {
            get { return _mailAddress3; }
            set { _mailAddress3 = value; }
        }

        /// public propaty name  :  MailAddrKindCode3
        /// <summary>���[���A�h���X��ʃR�[�h3�v���p�e�B</summary>
        /// <value>0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�h���X��ʃR�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MailAddrKindCode3
        {
            get { return _mailAddrKindCode3; }
            set { _mailAddrKindCode3 = value; }
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
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  JobTypeName
        /// <summary>�E�햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �E�햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JobTypeName
        {
            get { return _jobTypeName; }
            set { _jobTypeName = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }


        /// <summary>
        /// �ȒP�⍇��ID�t�����}�X�^(��{���)�R���X�g���N�^
        /// </summary>
        /// <returns>SmplInqBas�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqBas�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqBas()
        {
        }

        /// <summary>
        /// �ȒP�⍇��ID�t�����}�X�^(��{���)�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="simpleInqIdInfMngNo">�ȒP�⍇��ID�t�����Ǘ��ԍ�(���[�U�[�P�ʂ̘A��)</param>
        /// <param name="name">����</param>
        /// <param name="name2">����2</param>
        /// <param name="kana">�J�i</param>
        /// <param name="sexCode">���ʃR�[�h(:�j,1:��,2:��)</param>
        /// <param name="sexName">���ʖ���(�S�p�ŊǗ�)</param>
        /// <param name="birthday">���N����(YYYYMMDD)</param>
        /// <param name="postNo">�X�֔ԍ�</param>
        /// <param name="addressCode1Upper">�s���{���R�[�h(�s���{���s��S���ނ̏�2��)</param>
        /// <param name="webDspAddrADOJp">WEB�\���Z��(�s���{��)((���p�S�p����))</param>
        /// <param name="webDspAddrCity">WEB�\���Z��(��s����)((���p�S�p����))</param>
        /// <param name="webDspAddrBuil">WEB�\���Z��(�r����}���V������)((���p�S�p����))</param>
        /// <param name="jobTypeCode">�E��R�[�h</param>
        /// <param name="businessTypeCode">�Ǝ�R�[�h</param>
        /// <param name="homeTelNo">�d�b�ԍ��i����j(�n�C�t�����܂߂�16���̔ԍ�)</param>
        /// <param name="officeTelNo">�d�b�ԍ��i�Ζ���j</param>
        /// <param name="portableTelNo">�d�b�ԍ��i�g�сj</param>
        /// <param name="homeFaxNo">FAX�ԍ��i����j</param>
        /// <param name="officeFaxNo">FAX�ԍ��i�Ζ���j</param>
        /// <param name="mailAddress1">���[���A�h���X1</param>
        /// <param name="mailAddrKindCode1">���[���A�h���X��ʃR�[�h1(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddress2">���[���A�h���X2</param>
        /// <param name="mailAddrKindCode2">���[���A�h���X��ʃR�[�h2(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="mailAddress3">���[���A�h���X3</param>
        /// <param name="mailAddrKindCode3">���[���A�h���X��ʃR�[�h3(0:����,1:���,2:�g�ђ[��,3:�{�l�ȊO,99:���̑�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="jobTypeName">�E�햼��</param>
        /// <param name="businessTypeName">�Ǝ햼��</param>
        /// <returns>SmplInqBas�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqBas�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqBas(DateTime createDateTime, DateTime updateDateTime, Int32 logicalDeleteCode, Int64 simpleInqIdInfMngNo, string name, string name2, string kana, Int32 sexCode, string sexName, DateTime birthday, string postNo, Int32 addressCode1Upper, string webDspAddrADOJp, string webDspAddrCity, string webDspAddrBuil, Int32 jobTypeCode, Int32 businessTypeCode, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string mailAddress1, Int32 mailAddrKindCode1, string mailAddress2, Int32 mailAddrKindCode2, string mailAddress3, Int32 mailAddrKindCode3, string enterpriseCode, string enterpriseName, string jobTypeName, string businessTypeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._logicalDeleteCode = logicalDeleteCode;
            this._simpleInqIdInfMngNo = simpleInqIdInfMngNo;
            this._name = name;
            this._name2 = name2;
            this._kana = kana;
            this._sexCode = sexCode;
            this._sexName = sexName;
            this.Birthday = birthday;
            this._postNo = postNo;
            this._addressCode1Upper = addressCode1Upper;
            this._webDspAddrADOJp = webDspAddrADOJp;
            this._webDspAddrCity = webDspAddrCity;
            this._webDspAddrBuil = webDspAddrBuil;
            this._jobTypeCode = jobTypeCode;
            this._businessTypeCode = businessTypeCode;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = officeFaxNo;
            this._mailAddress1 = mailAddress1;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddress2 = mailAddress2;
            this._mailAddrKindCode2 = mailAddrKindCode2;
            this._mailAddress3 = mailAddress3;
            this._mailAddrKindCode3 = mailAddrKindCode3;
            this._enterpriseCode = enterpriseCode;
            this._enterpriseName = enterpriseName;
            this._jobTypeName = jobTypeName;
            this._businessTypeName = businessTypeName;

        }

        /// <summary>
        /// �ȒP�⍇��ID�t�����}�X�^(��{���)��������
        /// </summary>
        /// <returns>SmplInqBas�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SmplInqBas�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SmplInqBas Clone()
        {
            return new SmplInqBas(this._createDateTime, this._updateDateTime, this._logicalDeleteCode, this._simpleInqIdInfMngNo, this._name, this._name2, this._kana, this._sexCode, this._sexName, this._birthday, this._postNo, this._addressCode1Upper, this._webDspAddrADOJp, this._webDspAddrCity, this._webDspAddrBuil, this._jobTypeCode, this._businessTypeCode, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._mailAddress1, this._mailAddrKindCode1, this._mailAddress2, this._mailAddrKindCode2, this._mailAddress3, this._mailAddrKindCode3, this._enterpriseCode, this._enterpriseName, this._jobTypeName, this._businessTypeName);
        }

        /// <summary>
        /// �ȒP�⍇��ID�t�����}�X�^(��{���)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SmplInqBas�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqBas�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SmplInqBas target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.SimpleInqIdInfMngNo == target.SimpleInqIdInfMngNo )
                 && ( this.Name == target.Name )
                 && ( this.Name2 == target.Name2 )
                 && ( this.Kana == target.Kana )
                 && ( this.SexCode == target.SexCode )
                 && ( this.SexName == target.SexName )
                 && ( this.Birthday == target.Birthday )
                 && ( this.PostNo == target.PostNo )
                 && ( this.AddressCode1Upper == target.AddressCode1Upper )
                 && ( this.WebDspAddrADOJp == target.WebDspAddrADOJp )
                 && ( this.WebDspAddrCity == target.WebDspAddrCity )
                 && ( this.WebDspAddrBuil == target.WebDspAddrBuil )
                 && ( this.JobTypeCode == target.JobTypeCode )
                 && ( this.BusinessTypeCode == target.BusinessTypeCode )
                 && ( this.HomeTelNo == target.HomeTelNo )
                 && ( this.OfficeTelNo == target.OfficeTelNo )
                 && ( this.PortableTelNo == target.PortableTelNo )
                 && ( this.HomeFaxNo == target.HomeFaxNo )
                 && ( this.OfficeFaxNo == target.OfficeFaxNo )
                 && ( this.MailAddress1 == target.MailAddress1 )
                 && ( this.MailAddrKindCode1 == target.MailAddrKindCode1 )
                 && ( this.MailAddress2 == target.MailAddress2 )
                 && ( this.MailAddrKindCode2 == target.MailAddrKindCode2 )
                 && ( this.MailAddress3 == target.MailAddress3 )
                 && ( this.MailAddrKindCode3 == target.MailAddrKindCode3 )
                 && ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.JobTypeName == target.JobTypeName )
                 && ( this.BusinessTypeName == target.BusinessTypeName ) );
        }

        /// <summary>
        /// �ȒP�⍇��ID�t�����}�X�^(��{���)��r����
        /// </summary>
        /// <param name="smplInqBas1">
        ///                    ��r����SmplInqBas�N���X�̃C���X�^���X
        /// </param>
        /// <param name="smplInqBas2">��r����SmplInqBas�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqBas�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SmplInqBas smplInqBas1, SmplInqBas smplInqBas2)
        {
            return ( ( smplInqBas1.CreateDateTime == smplInqBas2.CreateDateTime )
                 && ( smplInqBas1.UpdateDateTime == smplInqBas2.UpdateDateTime )
                 && ( smplInqBas1.LogicalDeleteCode == smplInqBas2.LogicalDeleteCode )
                 && ( smplInqBas1.SimpleInqIdInfMngNo == smplInqBas2.SimpleInqIdInfMngNo )
                 && ( smplInqBas1.Name == smplInqBas2.Name )
                 && ( smplInqBas1.Name2 == smplInqBas2.Name2 )
                 && ( smplInqBas1.Kana == smplInqBas2.Kana )
                 && ( smplInqBas1.SexCode == smplInqBas2.SexCode )
                 && ( smplInqBas1.SexName == smplInqBas2.SexName )
                 && ( smplInqBas1.Birthday == smplInqBas2.Birthday )
                 && ( smplInqBas1.PostNo == smplInqBas2.PostNo )
                 && ( smplInqBas1.AddressCode1Upper == smplInqBas2.AddressCode1Upper )
                 && ( smplInqBas1.WebDspAddrADOJp == smplInqBas2.WebDspAddrADOJp )
                 && ( smplInqBas1.WebDspAddrCity == smplInqBas2.WebDspAddrCity )
                 && ( smplInqBas1.WebDspAddrBuil == smplInqBas2.WebDspAddrBuil )
                 && ( smplInqBas1.JobTypeCode == smplInqBas2.JobTypeCode )
                 && ( smplInqBas1.BusinessTypeCode == smplInqBas2.BusinessTypeCode )
                 && ( smplInqBas1.HomeTelNo == smplInqBas2.HomeTelNo )
                 && ( smplInqBas1.OfficeTelNo == smplInqBas2.OfficeTelNo )
                 && ( smplInqBas1.PortableTelNo == smplInqBas2.PortableTelNo )
                 && ( smplInqBas1.HomeFaxNo == smplInqBas2.HomeFaxNo )
                 && ( smplInqBas1.OfficeFaxNo == smplInqBas2.OfficeFaxNo )
                 && ( smplInqBas1.MailAddress1 == smplInqBas2.MailAddress1 )
                 && ( smplInqBas1.MailAddrKindCode1 == smplInqBas2.MailAddrKindCode1 )
                 && ( smplInqBas1.MailAddress2 == smplInqBas2.MailAddress2 )
                 && ( smplInqBas1.MailAddrKindCode2 == smplInqBas2.MailAddrKindCode2 )
                 && ( smplInqBas1.MailAddress3 == smplInqBas2.MailAddress3 )
                 && ( smplInqBas1.MailAddrKindCode3 == smplInqBas2.MailAddrKindCode3 )
                 && ( smplInqBas1.EnterpriseCode == smplInqBas2.EnterpriseCode )
                 && ( smplInqBas1.EnterpriseName == smplInqBas2.EnterpriseName )
                 && ( smplInqBas1.JobTypeName == smplInqBas2.JobTypeName )
                 && ( smplInqBas1.BusinessTypeName == smplInqBas2.BusinessTypeName ) );
        }
        /// <summary>
        /// �ȒP�⍇��ID�t�����}�X�^(��{���)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SmplInqBas�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqBas�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SmplInqBas target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SimpleInqIdInfMngNo != target.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (this.Name != target.Name) resList.Add("Name");
            if (this.Name2 != target.Name2) resList.Add("Name2");
            if (this.Kana != target.Kana) resList.Add("Kana");
            if (this.SexCode != target.SexCode) resList.Add("SexCode");
            if (this.SexName != target.SexName) resList.Add("SexName");
            if (this.Birthday != target.Birthday) resList.Add("Birthday");
            if (this.PostNo != target.PostNo) resList.Add("PostNo");
            if (this.AddressCode1Upper != target.AddressCode1Upper) resList.Add("AddressCode1Upper");
            if (this.WebDspAddrADOJp != target.WebDspAddrADOJp) resList.Add("WebDspAddrADOJp");
            if (this.WebDspAddrCity != target.WebDspAddrCity) resList.Add("WebDspAddrCity");
            if (this.WebDspAddrBuil != target.WebDspAddrBuil) resList.Add("WebDspAddrBuil");
            if (this.JobTypeCode != target.JobTypeCode) resList.Add("JobTypeCode");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.HomeTelNo != target.HomeTelNo) resList.Add("HomeTelNo");
            if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
            if (this.PortableTelNo != target.PortableTelNo) resList.Add("PortableTelNo");
            if (this.HomeFaxNo != target.HomeFaxNo) resList.Add("HomeFaxNo");
            if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (this.MailAddress1 != target.MailAddress1) resList.Add("MailAddress1");
            if (this.MailAddrKindCode1 != target.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (this.MailAddress2 != target.MailAddress2) resList.Add("MailAddress2");
            if (this.MailAddrKindCode2 != target.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (this.MailAddress3 != target.MailAddress3) resList.Add("MailAddress3");
            if (this.MailAddrKindCode3 != target.MailAddrKindCode3) resList.Add("MailAddrKindCode3");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.JobTypeName != target.JobTypeName) resList.Add("JobTypeName");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }

        /// <summary>
        /// �ȒP�⍇��ID�t�����}�X�^(��{���)��r����
        /// </summary>
        /// <param name="smplInqBas1">��r����SmplInqBas�N���X�̃C���X�^���X</param>
        /// <param name="smplInqBas2">��r����SmplInqBas�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SmplInqBas�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SmplInqBas smplInqBas1, SmplInqBas smplInqBas2)
        {
            ArrayList resList = new ArrayList();
            if (smplInqBas1.CreateDateTime != smplInqBas2.CreateDateTime) resList.Add("CreateDateTime");
            if (smplInqBas1.UpdateDateTime != smplInqBas2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (smplInqBas1.LogicalDeleteCode != smplInqBas2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (smplInqBas1.SimpleInqIdInfMngNo != smplInqBas2.SimpleInqIdInfMngNo) resList.Add("SimpleInqIdInfMngNo");
            if (smplInqBas1.Name != smplInqBas2.Name) resList.Add("Name");
            if (smplInqBas1.Name2 != smplInqBas2.Name2) resList.Add("Name2");
            if (smplInqBas1.Kana != smplInqBas2.Kana) resList.Add("Kana");
            if (smplInqBas1.SexCode != smplInqBas2.SexCode) resList.Add("SexCode");
            if (smplInqBas1.SexName != smplInqBas2.SexName) resList.Add("SexName");
            if (smplInqBas1.Birthday != smplInqBas2.Birthday) resList.Add("Birthday");
            if (smplInqBas1.PostNo != smplInqBas2.PostNo) resList.Add("PostNo");
            if (smplInqBas1.AddressCode1Upper != smplInqBas2.AddressCode1Upper) resList.Add("AddressCode1Upper");
            if (smplInqBas1.WebDspAddrADOJp != smplInqBas2.WebDspAddrADOJp) resList.Add("WebDspAddrADOJp");
            if (smplInqBas1.WebDspAddrCity != smplInqBas2.WebDspAddrCity) resList.Add("WebDspAddrCity");
            if (smplInqBas1.WebDspAddrBuil != smplInqBas2.WebDspAddrBuil) resList.Add("WebDspAddrBuil");
            if (smplInqBas1.JobTypeCode != smplInqBas2.JobTypeCode) resList.Add("JobTypeCode");
            if (smplInqBas1.BusinessTypeCode != smplInqBas2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (smplInqBas1.HomeTelNo != smplInqBas2.HomeTelNo) resList.Add("HomeTelNo");
            if (smplInqBas1.OfficeTelNo != smplInqBas2.OfficeTelNo) resList.Add("OfficeTelNo");
            if (smplInqBas1.PortableTelNo != smplInqBas2.PortableTelNo) resList.Add("PortableTelNo");
            if (smplInqBas1.HomeFaxNo != smplInqBas2.HomeFaxNo) resList.Add("HomeFaxNo");
            if (smplInqBas1.OfficeFaxNo != smplInqBas2.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (smplInqBas1.MailAddress1 != smplInqBas2.MailAddress1) resList.Add("MailAddress1");
            if (smplInqBas1.MailAddrKindCode1 != smplInqBas2.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (smplInqBas1.MailAddress2 != smplInqBas2.MailAddress2) resList.Add("MailAddress2");
            if (smplInqBas1.MailAddrKindCode2 != smplInqBas2.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (smplInqBas1.MailAddress3 != smplInqBas2.MailAddress3) resList.Add("MailAddress3");
            if (smplInqBas1.MailAddrKindCode3 != smplInqBas2.MailAddrKindCode3) resList.Add("MailAddrKindCode3");
            if (smplInqBas1.EnterpriseCode != smplInqBas2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (smplInqBas1.EnterpriseName != smplInqBas2.EnterpriseName) resList.Add("EnterpriseName");
            if (smplInqBas1.JobTypeName != smplInqBas2.JobTypeName) resList.Add("JobTypeName");
            if (smplInqBas1.BusinessTypeName != smplInqBas2.BusinessTypeName) resList.Add("BusinessTypeName");

            return resList;
        }
    }
}
