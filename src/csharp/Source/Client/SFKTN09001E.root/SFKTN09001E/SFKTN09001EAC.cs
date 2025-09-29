using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SecInfoSet
    /// <summary>
    ///                      ���_���ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���_���ݒ�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2005/3/18</br>
    /// <br>Genarated Date   :   2005/03/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006.12.13 22022 �i�� �m�q</br>
    /// <br>        					1.SF�ł𗬗p���g�єł��쐬</br>
    /// <br>        					2.���Ж���1��K�{���͂֕ύX</br>
    /// -----------------------------------------------------------------------
    /// <br>Update Note      : 2008/06/03 30414�@�E�@�K�j</br>
    /// <br>                 :�u���_���́v�u�����N�����v�ǉ��A�u�����_�`�[���Ж�����敪�v�u�\���Q�`�P�O�v�폜</br>
    /// </remarks>
    public class SecInfoSet
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

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// <summary>����PR��</summary>
        //		private string _companyPr = "";
        //
        //		/// <summary>���Ж���1</summary>
        //		private string _companyName1 = "";
        //
        //		/// <summary>���Ж���2</summary>
        //		private string _companyName2 = "";
        //
        //		/// <summary>�X�֔ԍ�</summary>
        //		private string _postNo = "";
        //
        //		/// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        //		private string _address1 = "";
        //
        //		/// <summary>�Z��2�i���ځj</summary>
        //		private Int32 _address2;
        //
        //		/// <summary>�Z��3�i�Ԓn�j</summary>
        //		private string _address3 = "";
        //
        //		/// <summary>�Z��4�i�A�p�[�g���́j</summary>
        //		private string _address4 = "";
        //
        //		/// <summary>���Гd�b�ԍ�1</summary>
        //		private string _companyTelNo1 = "";
        //
        //		/// <summary>���Гd�b�ԍ�2</summary>
        //		private string _companyTelNo2 = "";
        //
        //		/// <summary>���Гd�b�ԍ�3</summary>
        //		private string _companyTelNo3 = "";
        //
        //		/// <summary>���Гd�b�ԍ��^�C�g��1</summary>
        //		private string _companyTelTitle1 = "";
        //
        //		/// <summary>���Гd�b�ԍ��^�C�g��2</summary>
        //		private string _companyTelTitle2 = "";
        //
        //		/// <summary>���Гd�b�ԍ��^�C�g��3</summary>
        //		private string _companyTelTitle3 = "";
        //
        //		/// <summary>��s�U���ē���</summary>
        //		private string _transferGuidance = "";
        //
        //		/// <summary>��s����1</summary>
        //		private string _accountNoInfo1 = "";
        //
        //		/// <summary>��s����2</summary>
        //		private string _accountNoInfo2 = "";
        //
        //		/// <summary>��s����3</summary>
        //		private string _accountNoInfo3 = "";
        //
        //		/// <summary>���Аݒ�E�v1</summary>
        //		private string _companySetNote1 = "";
        //
        //		/// <summary>���Аݒ�E�v2</summary>
        //		private string _companySetNote2 = "";
        //
        //		/// <summary>�`�[���Ж�����敪</summary>
        //		/// <remarks>0:���_�ݒ�,1:���Аݒ�</remarks>
        //		private Int32 _slipCompanyNmCd;
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>�����_�`�[���Ј���敪</summary>
        /// <remarks>0:�����_���,1:�����_���@���P</remarks>
        private Int32 _othrSlipCompanyNmCd;
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>�{�Ћ@�\�t���O</summary>
        /// <remarks>0:���_ 1:�{��</remarks>
        private Int32 _mainOfficeFuncFlag;

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// <summary>���������Ж�����敪</summary>
        //		/// <remarks>0:���_�ݒ�,1:���Аݒ�</remarks>
        //		private Int32 _billCompanyNmPrtCd;
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>���_�R�[�h�i�ԍ��̔ԗp�j</summary>
        /// <remarks>�e��̊Ǘ��ԍ��ŋ��_�����ʂ���Q���̃��j�[�N�R�[�h</remarks>
        private string _secCdForNumbering = "";
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// <summary>���Ж��̃R�[�h1</summary>
        /// <remarks>�����V�X�e���Ŏg�p���鎩�Ж��̃R�[�h</remarks>
        private Int32 _companyNameCd1;

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>���Ж��̃R�[�h2</summary>
        /// <remarks>����V�X�e���Ŏg�p���鎩�Ж��̃R�[�h</remarks>
        private Int32 _companyNameCd2;

        /// <summary>���Ж��̃R�[�h3</summary>
        /// <remarks>�Ԕ̃V�X�e���Ŏg�p���鎩�Ж��̃R�[�h</remarks>
        private Int32 _companyNameCd3;

        /// <summary>���Ж��̃R�[�h4</summary>
        /// <remarks>�������֘A�Ŏg�p���鎩�Ж��̃R�[�h</remarks>
        private Int32 _companyNameCd4;

        /// <summary>���Ж��̃R�[�h5</summary>
        private Int32 _companyNameCd5;

        /// <summary>���Ж��̃R�[�h6</summary>
        private Int32 _companyNameCd6;

        /// <summary>���Ж��̃R�[�h7</summary>
        private Int32 _companyNameCd7;

        /// <summary>���Ж��̃R�[�h8</summary>
        private Int32 _companyNameCd8;

        /// <summary>���Ж��̃R�[�h9</summary>
        private Int32 _companyNameCd9;

        /// <summary>���Ж��̃R�[�h10</summary>
        private Int32 _companyNameCd10;
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// <summary>���Ж���1</summary>
        /// <remarks>�����V�X�e���Ŏg�p���鎩�Ж���</remarks>
        private string _companyName1 = "";

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>���Ж���2</summary>
        /// <remarks>����V�X�e���Ŏg�p���鎩�Ж���</remarks>
        private string _companyName2 = "";

        /// <summary>���Ж���3</summary>
        /// <remarks>�Ԕ̃V�X�e���Ŏg�p���鎩�Ж���</remarks>
        private string _companyName3 = "";

        /// <summary>���Ж���4</summary>
        /// <remarks>�������֘A�Ŏg�p���鎩�Ж���</remarks>
        private string _companyName4 = "";

        /// <summary>���Ж���5</summary>
        private string _companyName5 = "";

        /// <summary>���Ж���6</summary>
        private string _companyName6 = "";

        /// <summary>���Ж���7</summary>
        private string _companyName7 = "";

        /// <summary>���Ж���8</summary>
        private string _companyName8 = "";

        /// <summary>���Ж���9</summary>
        private string _companyName9 = "";

        /// <summary>���Ж���10</summary>
        private string _companyName10 = "";
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        //�� 2007.10.5 add/////////////////////////

        /// <summary>���_�q�ɃR�[�h1</summary>
        /// <remarks>���_���̑q�ɗD�揇��1</remarks>
        private string _sectWarehouseCd1 = "";

        /// <summary>���_�q�ɃR�[�h2</summary>
        /// <remarks>���_���̑q�ɗD�揇��2</remarks>
        private string _sectWarehouseCd2 = "";

        /// <summary>���_�q�ɃR�[�h3</summary>
        /// <remarks>���_���̑q�ɗD�揇��3</remarks>
        private string _sectWarehouseCd3 = "";

        /// <summary>���_�q�ɖ���1</summary>
        private string _sectWarehouseNm1 = "";

        /// <summary>���_�q�ɖ���2</summary>
        private string _sectWarehouseNm2 = "";

        /// <summary>���_�q�ɖ���3</summary>
        private string _sectWarehouseNm3 = "";

        //�� 2007.10.5 add/////////////////////////

        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// <summary>�`�[���Ж�����敪����</summary>
        //		private string _slipCompanyNm;
        //
        //		/// <summary>�����_�`�[���Ј���敪����</summary>
        //		private string _othrSlipCompanyNm;
        //
        //		/// <summary>�{�Ћ@�\�t���O����</summary>
        //		private string _mainOfficeFuncNm;
        //
        //		/// <summary>���������Ж�����敪����</summary>
        //		private string _billCompanyNmPrtNm;
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// <summary>���_����</summary>
        private string _sectionGuideSnm = "";

        /// <summary>�����N����</summary>
        private DateTime _introductionDate;
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

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
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
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
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
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
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
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
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// public propaty name  :  CompanyPr
        //		/// <summary>����PR���v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ����PR���v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyPr
        //		{
        //			get{return _companyPr;}
        //			set{_companyPr = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyName1
        //		/// <summary>���Ж���1�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Ж���1�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyName1
        //		{
        //			get{return _companyName1;}
        //			set{_companyName1 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyName2
        //		/// <summary>���Ж���2�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Ж���2�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyName2
        //		{
        //			get{return _companyName2;}
        //			set{_companyName2 = value;}
        //		}
        //
        //		/// public propaty name  :  PostNo
        //		/// <summary>�X�֔ԍ��v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string PostNo
        //		{
        //			get{return _postNo;}
        //			set{_postNo = value;}
        //		}
        //
        //		/// public propaty name  :  Address1
        //		/// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string Address1
        //		{
        //			get{return _address1;}
        //			set{_address1 = value;}
        //		}
        //
        //		/// public propaty name  :  Address2
        //		/// <summary>�Z��2�i���ځj�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �Z��2�i���ځj�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public Int32 Address2
        //		{
        //			get{return _address2;}
        //			set{_address2 = value;}
        //		}
        //
        //		/// public propaty name  :  Address3
        //		/// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string Address3
        //		{
        //			get{return _address3;}
        //			set{_address3 = value;}
        //		}
        //
        //		/// public propaty name  :  Address4
        //		/// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string Address4
        //		{
        //			get{return _address4;}
        //			set{_address4 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelNo1
        //		/// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyTelNo1
        //		{
        //			get{return _companyTelNo1;}
        //			set{_companyTelNo1 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelNo2
        //		/// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyTelNo2
        //		{
        //			get{return _companyTelNo2;}
        //			set{_companyTelNo2 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelNo3
        //		/// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyTelNo3
        //		{
        //			get{return _companyTelNo3;}
        //			set{_companyTelNo3 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelTitle1
        //		/// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyTelTitle1
        //		{
        //			get{return _companyTelTitle1;}
        //			set{_companyTelTitle1 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelTitle2
        //		/// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyTelTitle2
        //		{
        //			get{return _companyTelTitle2;}
        //			set{_companyTelTitle2 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanyTelTitle3
        //		/// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanyTelTitle3
        //		{
        //			get{return _companyTelTitle3;}
        //			set{_companyTelTitle3 = value;}
        //		}
        //
        //		/// public propaty name  :  TransferGuidance
        //		/// <summary>��s�U���ē����v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ��s�U���ē����v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string TransferGuidance
        //		{
        //			get{return _transferGuidance;}
        //			set{_transferGuidance = value;}
        //		}
        //
        //		/// public propaty name  :  AccountNoInfo1
        //		/// <summary>��s����1�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ��s����1�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string AccountNoInfo1
        //		{
        //			get{return _accountNoInfo1;}
        //			set{_accountNoInfo1 = value;}
        //		}
        //
        //		/// public propaty name  :  AccountNoInfo2
        //		/// <summary>��s����2�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ��s����2�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string AccountNoInfo2
        //		{
        //			get{return _accountNoInfo2;}
        //			set{_accountNoInfo2 = value;}
        //		}
        //
        //		/// public propaty name  :  AccountNoInfo3
        //		/// <summary>��s����3�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ��s����3�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string AccountNoInfo3
        //		{
        //			get{return _accountNoInfo3;}
        //			set{_accountNoInfo3 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanySetNote1
        //		/// <summary>���Аݒ�E�v1�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Аݒ�E�v1�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanySetNote1
        //		{
        //			get{return _companySetNote1;}
        //			set{_companySetNote1 = value;}
        //		}
        //
        //		/// public propaty name  :  CompanySetNote2
        //		/// <summary>���Аݒ�E�v2�v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���Аݒ�E�v2�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public string CompanySetNote2
        //		{
        //			get{return _companySetNote2;}
        //			set{_companySetNote2 = value;}
        //		}
        //
        //		/// public propaty name  :  SlipCompanyNmCd
        //		/// <summary>�`�[���Ж�����敪�v���p�e�B</summary>
        //		/// <value>0:���_�ݒ�,1:���Аݒ�</value>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �`�[���Ж�����敪�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public Int32 SlipCompanyNmCd
        //		{
        //			get{return _slipCompanyNmCd;}
        //			set{_slipCompanyNmCd = value;}
        //		}
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  OthrSlipCompanyNmCd
        /// <summary>�����_�`�[���Ј���敪�v���p�e�B</summary>
        /// <value>0:�����_���,1:�����_���@���P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����_�`�[���Ј���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OthrSlipCompanyNmCd
        {
            get { return _othrSlipCompanyNmCd; }
            set { _othrSlipCompanyNmCd = value; }
        }
         *    --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  MainOfficeFuncFlag
        /// <summary>�{�Ћ@�\�t���O�v���p�e�B</summary>
        /// <value>0:���_ 1:�{��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�Ћ@�\�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MainOfficeFuncFlag
        {
            get { return _mainOfficeFuncFlag; }
            set { _mainOfficeFuncFlag = value; }
        }

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// public propaty name  :  BillCompanyNmPrtCd
        //		/// <summary>���������Ж�����敪�v���p�e�B</summary>
        //		/// <value>0:���_�ݒ�,1:���Аݒ�</value>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���������Ж�����敪�v���p�e�B</br>
        //		/// <br>Programer        :   ��������</br>
        //		/// </remarks>
        //		public Int32 BillCompanyNmPrtCd
        //		{
        //			get{return _billCompanyNmPrtCd;}
        //			set{_billCompanyNmPrtCd = value;}
        //		}
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  SecCdForNumbering
        /// <summary>���_�R�[�h�i�ԍ��̔ԗp�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�i�ԍ��̔ԗp�j�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string SecCdForNumbering
        {
            get { return _secCdForNumbering; }
            set { _secCdForNumbering = value; }
        }
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// public propary name  :  CompanyNameCd1
        /// <summary>���Ж��̃R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h1�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd1
        {
            get { return _companyNameCd1; }
            set { _companyNameCd1 = value; }
        }

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propary name  :  CompanyNameCd2
        /// <summary>���Ж��̃R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h2�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd2
        {
            get { return _companyNameCd2; }
            set { _companyNameCd2 = value; }
        }

        /// public propary name  :  CompanyNameCd3
        /// <summary>���Ж��̃R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h3�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd3
        {
            get { return _companyNameCd3; }
            set { _companyNameCd3 = value; }
        }

        /// public propary name  :  CompanyNameCd4
        /// <summary>���Ж��̃R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h4�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd4
        {
            get { return _companyNameCd4; }
            set { _companyNameCd4 = value; }
        }

        /// public propary name  :  CompanyNameCd5
        /// <summary>���Ж��̃R�[�h5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h5�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd5
        {
            get { return _companyNameCd5; }
            set { _companyNameCd5 = value; }
        }

        /// public propary name  :  CompanyNameCd6
        /// <summary>���Ж��̃R�[�h6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h6�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd6
        {
            get { return _companyNameCd6; }
            set { _companyNameCd6 = value; }
        }

        /// public propary name  :  CompanyNameCd7
        /// <summary>���Ж��̃R�[�h7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h7�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd7
        {
            get { return _companyNameCd7; }
            set { _companyNameCd7 = value; }
        }

        /// public propary name  :  CompanyNameCd8
        /// <summary>���Ж��̃R�[�h8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h8�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd8
        {
            get { return _companyNameCd8; }
            set { _companyNameCd8 = value; }
        }

        /// public propary name  :  CompanyNameCd9
        /// <summary>���Ж��̃R�[�h9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h9�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd9
        {
            get { return _companyNameCd9; }
            set { _companyNameCd9 = value; }
        }

        /// public propary name  :  CompanyNameCd10
        /// <summary>���Ж��̃R�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж��̃R�[�h10�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public int CompanyNameCd10
        {
            get { return _companyNameCd10; }
            set { _companyNameCd10 = value; }
        }
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// public propary name  :  CompanyName1
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propary name  :  CompanyName2
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
        }

        /// public propary name  :  CompanyName3
        /// <summary>���Ж���3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���3�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName3
        {
            get { return _companyName3; }
            set { _companyName3 = value; }
        }

        /// public propary name  :  CompanyName4
        /// <summary>���Ж���4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���4�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName4
        {
            get { return _companyName4; }
            set { _companyName4 = value; }
        }

        /// public propary name  :  CompanyName5
        /// <summary>���Ж���5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���5�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName5
        {
            get { return _companyName5; }
            set { _companyName5 = value; }
        }

        /// public propary name  :  CompanyName6
        /// <summary>���Ж���6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���6�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName6
        {
            get { return _companyName6; }
            set { _companyName6 = value; }
        }

        /// public propary name  :  CompanyName7
        /// <summary>���Ж���7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���7�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName7
        {
            get { return _companyName7; }
            set { _companyName7 = value; }
        }

        /// public propary name  :  CompanyName8
        /// <summary>���Ж���8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���8�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName8
        {
            get { return _companyName8; }
            set { _companyName8 = value; }
        }

        /// public propary name  :  CompanyName9
        /// <summary>���Ж���9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���9�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName9
        {
            get { return _companyName9; }
            set { _companyName9 = value; }
        }

        /// public propary name  :  CompanyName10
        /// <summary>���Ж���10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���10�v���p�e�B</br>
        /// <br>Programmer       :   23001 �H�R�@����</br>
        /// <br>Date             :   2005.09.13</br>
        /// </remarks>
        public string CompanyName10
        {
            get { return _companyName10; }
            set { _companyName10 = value; }
        }
         *    --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        // �� 2007.10.5 add////////////////////////////////////////////////////////
        /// public propary name  :  SectWarehouseCd1
        /// <summary>���_�q�ɃR�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseCd1
        {
            get { return _sectWarehouseCd1; }
            set { _sectWarehouseCd1 = value; }
        }

        /// public propary name  :  SectWarehouseCd2
        /// <summary>���_�q�ɃR�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseCd2
        {
            get { return _sectWarehouseCd2; }
            set { _sectWarehouseCd2 = value; }
        }

        /// public propary name  :  SectWarehouseCd3
        /// <summary>���_�q�ɃR�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseCd3
        {
            get { return _sectWarehouseCd3; }
            set { _sectWarehouseCd3 = value; }
        }

        /// public propary name  :  SectWarehouseNm1
        /// <summary>���_�q�ɖ���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseNm1
        {
            get { return _sectWarehouseNm1; }
            set { _sectWarehouseNm1 = value; }
        }

        /// public propary name  :  SectWarehouseNm2
        /// <summary>���_�q�ɖ���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseNm2
        {
            get { return _sectWarehouseNm2; }
            set { _sectWarehouseNm2 = value; }
        }

        /// public propary name  :  SectWarehouseNm3
        /// <summary>���_�q�ɖ���3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        public string SectWarehouseNm3
        {
            get { return _sectWarehouseNm3; }
            set { _sectWarehouseNm3 = value; }
        }
        // �� 2007.10.5 add////////////////////////////////////////////////////////

        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  OthrSlipCompanyNm
        /// <summary>�����_�`�[���Ј���敪���̃v���p�e�B</summary>
        /// <value>0:�����_���,1:�����_���@���P</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����_�`�[���Ј���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OthrSlipCompanyNm
        {
            get { return GetOthrSlipCompanyNm(this._othrSlipCompanyNmCd); }
        }
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  MainOfficeFuncFlagName
        /// <summary>�{�Ћ@�\�t���O���̃v���p�e�B</summary>
        /// <value>0:���_ 1:�{��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �{�Ћ@�\�t���O���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainOfficeFuncFlagName
        {
            get { return GetMainOfficeFuncFlagName(this._mainOfficeFuncFlag); }
        }

        /// <summary>�����_�`�[���Ј���敪 0: �����_���</summary>
        public const int CONSTOTHRSLIPCOMPANYNMCD_OTHER = 0;
        /// <summary>�����_�`�[���Ј���敪 0: �����_���</summary>
        public const int CONSTOTHRSLIPCOMPANYNMCD_SELF = 1;
        /// <summary>
        /// �����_�`�[���Ј���敪���̎擾
        /// </summary>
        /// <param name="othrSlipCompanyNmCd">�����_�`�[���Ј���敪</param>
        /// <returns>�����_�`�[���Ј���敪����</returns>
        /// <remarks>
        /// <br>Note       : �����_�`�[���Ј���敪���瑼���_�`�[���Ј���敪���̂��擾���܂�</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public string GetOthrSlipCompanyNm(int othrSlipCompanyNmCd)
        {
            switch (othrSlipCompanyNmCd)
            {
                case CONSTOTHRSLIPCOMPANYNMCD_OTHER:
                    return "�����_���";
                case CONSTOTHRSLIPCOMPANYNMCD_SELF:
                    return "�����_���";
                default:
                    return "���ݒ�";
            }
        }

        /// <summary>�����_�`�[���Ј���敪�̎��</summary>
        static private int[] _othrSlipCompanyNmCds = { CONSTOTHRSLIPCOMPANYNMCD_OTHER, CONSTOTHRSLIPCOMPANYNMCD_SELF };
        /// <summary>�����_�`�[���Ј���敪�̎�ރv���p�e�B</summary>
        /// <remarks>
        /// <br>Note       : �����_�`�[���Ј���敪�̎�ރv���p�e�B</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        static public int[] OthrSlipCompanyNmCds
        {
            get
            {
                return _othrSlipCompanyNmCds;
            }
        }

        /// <summary>�{�Ћ@�\�t���O 0: ���_</summary>
        public const int CONSTMAINOFFICEFUNCFLAG_OTHER = 0;
        /// <summary>�{�Ћ@�\�t���O 1: �{��</summary>
        public const int CONSTMAINOFFICEFUNCFLAG_MAIN = 1;
        /// <summary>
        /// �{�Ћ@�\�t���O���̎擾
        /// </summary>
        /// <param name="mainOfficeFuncFlag">�{�Ћ@�\�t���O</param>
        /// <returns>�{�Ћ@�\�t���O����</returns>
        /// <remarks>
        /// <br>Note       : �{�Ћ@�\�t���O����{�Ћ@�\�t���O���̂��擾���܂�</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public string GetMainOfficeFuncFlagName(int mainOfficeFuncFlag)
        {
            switch (mainOfficeFuncFlag)
            {
                case CONSTMAINOFFICEFUNCFLAG_OTHER:
                    return "���_";
                case CONSTMAINOFFICEFUNCFLAG_MAIN:
                    return "�{��";
                default:
                    return "���ݒ�";
            }
        }

        /// <summary>�{�Ћ@�\�t���O�̎��</summary>
        static private int[] _mainOfficeFuncFlags = { CONSTMAINOFFICEFUNCFLAG_OTHER, CONSTMAINOFFICEFUNCFLAG_MAIN };
        /// <summary>�{�Ћ@�\�t���O�̎�ރv���p�e�B</summary>
        /// <remarks>
        /// <br>Note       : �{�Ћ@�\�t���O�̎�ރv���p�e�B</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        static public int[] MainOfficeFuncFlags
        {
            get
            {
                return _mainOfficeFuncFlags;
            }
        }

        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
        //		/// public propaty name  :  SlipCompanyNm
        //		/// <summary>�`�[���Ж�����敪���̃v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �`�[���Ж�����敪���̃v���p�e�B</br>
        //		/// <br>Programer        :   96219 �֌��@�`��</br>
        //		/// <br>Date             :   2005/3/31</br>
        //		/// </remarks>
        //		public string SlipCompanyNm
        //		{
        //			get{return _slipCompanyNm;}
        //			set{_slipCompanyNm = value;}
        //		}
        //
        //		/// public propaty name  :  OthrSlipCompanyNm
        //		/// <summary>�����_�`�[���Ј���敪���̃v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �����_�`�[���Ј���敪���̃v���p�e�B</br>
        //		/// <br>Programer        :   96219 �֌��@�`��</br>
        //		/// <br>Date             :   2005/3/31</br>
        //		/// </remarks>
        //		public string OthrSlipCompanyNm
        //		{
        //			get{return _othrSlipCompanyNm;}
        //			set{_othrSlipCompanyNm = value;}
        //		}
        //
        //		/// public propaty name  :  MainOfficeFuncNm
        //		/// <summary>�{�Ћ@�\�t���O���̃v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   �{�Ћ@�\�t���O���̃v���p�e�B</br>
        //		/// <br>Programer        :   96219 �֌��@�`��</br>
        //		/// <br>Date             :   2005/3/31</br>
        //		/// </remarks>
        //		public string MainOfficeFuncNm
        //		{
        //			get{return _mainOfficeFuncNm;}
        //			set{_mainOfficeFuncNm = value;}
        //		}
        //
        //		/// public propaty name  :  MainOfficeFuncNm
        //		/// <summary>���������Ж�����敪���̃v���p�e�B</summary>
        //		/// ----------------------------------------------------------------------
        //		/// <remarks>
        //		/// <br>note             :   ���������Ж�����敪���̃v���p�e�B</br>
        //		/// <br>Programer        :   96219 �֌��@�`��</br>
        //		/// <br>Date             :   2005/3/31</br>
        //		/// </remarks>
        //		public string BillCompanyNmPrtNm
        //		{
        //			get{return _billCompanyNmPrtNm;}
        //			set{_billCompanyNmPrtNm = value;}
        //		}
        // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

        // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
        /// public property name  :  SectionGuideSnm
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   �E�@�K�j</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
        }

        /// public property name  :  IntroductionDate
        /// <summary>�����N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����N�����v���p�e�B</br>
        /// <br>Programer        :   �E�@�K�j</br>
        /// </remarks>
        public DateTime IntroductionDate
        {
            get { return _introductionDate; }
            set { _introductionDate = value; }
        }
        // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// ���_���ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecInfoSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SecInfoSet()
        {
        }

        /// <summary>
        /// ���_���ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionGuideNm">���_�K�C�h����</param>
        /// <param name="mainOfficeFuncFlag">�{�Ћ@�\�t���O(0:���_ 1:�{��)</param>
        /// <param name="companyNameCd1">���Ж��̃R�[�h1(�����V�X�e���Ŏg�p���鎩�Ж��̃R�[�h)</param>
        /// <param name="companyName1">���Ж���1(�����V�X�e���Ŏg�p���鎩�Ж���)</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="sectWarehouseCd1">���_�q�ɃR�[�h1</param>
        /// <param name="sectWarehouseCd2">���_�q�ɃR�[�h2</param>
        /// <param name="sectWarehouseCd3">���_�q�ɃR�[�h3</param>        
        /// <param name="sectWarehouseNm1">���_�q�ɖ���1</param>
        /// <param name="sectWarehouseNm2">���_�q�ɖ���2</param>
        /// <param name="sectWarehouseNm3">���_�q�ɖ���3</param>
        /// <param name="sectionGuideSnm">���_����</param>
        /// <param name="introductionDate">�����N����</param>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecInfoSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
        //public SecInfoSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 othrSlipCompanyNmCd, string sectionGuideNm, Int32 mainOfficeFuncFlag, string secCdForNumbering, Int32 companyNameCd1, Int32 companyNameCd2, Int32 companyNameCd3, Int32 companyNameCd4, Int32 companyNameCd5, Int32 companyNameCd6, Int32 companyNameCd7, Int32 companyNameCd8, Int32 companyNameCd9, Int32 companyNameCd10, string companyName1, string companyName2, string companyName3, string companyName4, string companyName5, string companyName6, string companyName7, string companyName8, string companyName9, string companyName10, string sectWarehouseCd1, string sectWarehouseCd2, string sectWarehouseCd3, string sectWarehouseNm1, string sectWarehouseNm2, string sectWarehouseNm3, string updEmployeeName, string enterpriseName)
           --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
        public SecInfoSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string sectionGuideNm, Int32 mainOfficeFuncFlag, Int32 companyNameCd1, string companyName1, string sectWarehouseCd1, string sectWarehouseCd2, string sectWarehouseCd3, string sectWarehouseNm1, string sectWarehouseNm2, string sectWarehouseNm3, string updEmployeeName, string enterpriseName, string sectionGuideSnm, DateTime introductionDate)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			this._companyPr = companyPr;
            //			this._companyName1 = companyName1;
            //			this._companyName2 = companyName2;
            //			this._postNo = postNo;
            //			this._address1 = address1;
            //			this._address2 = address2;
            //			this._address3 = address3;
            //			this._address4 = address4;
            //			this._companyTelNo1 = companyTelNo1;
            //			this._companyTelNo2 = companyTelNo2;
            //			this._companyTelNo3 = companyTelNo3;
            //			this._companyTelTitle1 = companyTelTitle1;
            //			this._companyTelTitle2 = companyTelTitle2;
            //			this._companyTelTitle3 = companyTelTitle3;
            //			this._transferGuidance = transferGuidance;
            //			this._accountNoInfo1 = accountNoInfo1;
            //			this._accountNoInfo2 = accountNoInfo2;
            //			this._accountNoInfo3 = accountNoInfo3;
            //			this._companySetNote1 = companySetNote1;
            //			this._companySetNote2 = companySetNote2;
            //			this._slipCompanyNmCd = slipCompanyNmCd;
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            this._othrSlipCompanyNmCd = othrSlipCompanyNmCd;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            this._sectionGuideNm = sectionGuideNm;
            this._mainOfficeFuncFlag = mainOfficeFuncFlag;

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			this._billCompanyNmPrtCd = billCompanyNmPrtCd;
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //this._secCdForNumbering = secCdForNumbering;  // DEL 2008/06/03
            this._companyNameCd1 = companyNameCd1;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            this._companyNameCd2 = companyNameCd2;
            this._companyNameCd3 = companyNameCd3;
            this._companyNameCd4 = companyNameCd4;
            this._companyNameCd5 = companyNameCd5;
            this._companyNameCd6 = companyNameCd6;
            this._companyNameCd7 = companyNameCd7;
            this._companyNameCd8 = companyNameCd8;
            this._companyNameCd9 = companyNameCd9;
            this._companyNameCd10 = companyNameCd10;
             *    --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            this._companyName1 = companyName1;
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            this._companyName2 = companyName2;
            this._companyName3 = companyName3;
            this._companyName4 = companyName4;
            this._companyName5 = companyName5;
            this._companyName6 = companyName6;
            this._companyName7 = companyName7;
            this._companyName8 = companyName8;
            this._companyName9 = companyName9;
            this._companyName10 = companyName10;
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // �� 2007.10.5 add///////////////////////
            this._sectWarehouseCd1 = sectWarehouseCd1;
            this._sectWarehouseCd2 = sectWarehouseCd2;
            this._sectWarehouseCd3 = sectWarehouseCd3;
            this._sectWarehouseNm1 = sectWarehouseNm1;
            this._sectWarehouseNm2 = sectWarehouseNm2;
            this._sectWarehouseNm3 = sectWarehouseNm3;
            // �� 2007.10.5 add///////////////////////

            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            this._updEmployeeName = updEmployeeName;
            this._enterpriseName = enterpriseName;

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			this._slipCompanyNm = slipCompanyNm;
            //			this._othrSlipCompanyNm = othrSlipCompanyNm;
            //			this._mainOfficeFuncNm = mainOfficeFuncNm;
            //			this._billCompanyNmPrtNm = billCompanyNmPrtNm;
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            this._sectionGuideSnm = sectionGuideSnm;
            this._introductionDate = introductionDate;
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// ���_���ݒ�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SecInfoSet Clone()
        {
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            // �� 2007.10.5 add//
            return new SecInfoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._othrSlipCompanyNmCd, this._sectionGuideNm, this._mainOfficeFuncFlag, this._secCdForNumbering, this._companyNameCd1, this._companyNameCd2, this._companyNameCd3, this._companyNameCd4, this._companyNameCd5, this._companyNameCd6, this._companyNameCd7, this._companyNameCd8, this._companyNameCd9, this._companyNameCd10, this._companyName1, this._companyName2, this._companyName3, this._companyName4, this._companyName5, this._companyName6, this._companyName7, this._companyName8, this._companyName9, this._companyName10, this._sectWarehouseCd1, this._sectWarehouseCd2, this._sectWarehouseCd3, this._sectWarehouseNm1, this._sectWarehouseNm2, this._sectWarehouseNm3, this._updEmployeeName, this._enterpriseName);
            // �� 2007.10.5 add//
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            return new SecInfoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._sectionGuideNm, this._mainOfficeFuncFlag, this._companyNameCd1, this._companyName1, this._sectWarehouseCd1, this._sectWarehouseCd2, this._sectWarehouseCd3, this._sectWarehouseNm1, this._sectWarehouseNm2, this._sectWarehouseNm3, this._updEmployeeName, this._enterpriseName, this._sectionGuideSnm, this._introductionDate);
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            // �� 2007.9.26 delete
            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //          return new SecInfoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._othrSlipCompanyNmCd, this._sectionGuideNm, this._mainOfficeFuncFlag, this._secCdForNumbering, this._companyNameCd1, this._companyNameCd2, this._companyNameCd3, this._companyNameCd4, this._companyNameCd5, this._companyNameCd6, this._companyNameCd7, this._companyNameCd8, this._companyNameCd9, this._companyNameCd10, this._companyName1, this._companyName2, this._companyName3, this._companyName4, this._companyName5, this._companyName6, this._companyName7, this._companyName8, this._companyName9, this._companyName10, this._updEmployeeName, this._enterpriseName);
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
            // �� 2007.9.26 delete

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			return new SecInfoSet(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._companyPr,this._companyName1,this._companyName2,this._postNo,this._address1,this._address2,this._address3,this._address4,this._companyTelNo1,this._companyTelNo2,this._companyTelNo3,this._companyTelTitle1,this._companyTelTitle2,this._companyTelTitle3,this._transferGuidance,this._accountNoInfo1,this._accountNoInfo2,this._accountNoInfo3,this._companySetNote1,this._companySetNote2,this._slipCompanyNmCd,this._othrSlipCompanyNmCd,this._sectionGuideNm,this._mainOfficeFuncFlag,this._billCompanyNmPrtCd,this._updEmployeeName,this._enterpriseName,this._slipCompanyNm,this._othrSlipCompanyNm,this._mainOfficeFuncNm,this._billCompanyNmPrtNm);
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// ���_���ݒ�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SecInfoSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecInfoSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SecInfoSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //				 && (this.CompanyPr == target.CompanyPr)
                //				 && (this.CompanyName1 == target.CompanyName1)
                //				 && (this.CompanyName2 == target.CompanyName2)
                //				 && (this.PostNo == target.PostNo)
                //				 && (this.Address1 == target.Address1)
                //				 && (this.Address2 == target.Address2)
                //				 && (this.Address3 == target.Address3)
                //				 && (this.Address4 == target.Address4)
                //				 && (this.CompanyTelNo1 == target.CompanyTelNo1)
                //				 && (this.CompanyTelNo2 == target.CompanyTelNo2)
                //				 && (this.CompanyTelNo3 == target.CompanyTelNo3)
                //				 && (this.CompanyTelTitle1 == target.CompanyTelTitle1)
                //				 && (this.CompanyTelTitle2 == target.CompanyTelTitle2)
                //				 && (this.CompanyTelTitle3 == target.CompanyTelTitle3)
                //				 && (this.TransferGuidance == target.TransferGuidance)
                //				 && (this.AccountNoInfo1 == target.AccountNoInfo1)
                //				 && (this.AccountNoInfo2 == target.AccountNoInfo2)
                //				 && (this.AccountNoInfo3 == target.AccountNoInfo3)
                //				 && (this.CompanySetNote1 == target.CompanySetNote1)
                //				 && (this.CompanySetNote2 == target.CompanySetNote2)
                //				 && (this.SlipCompanyNmCd == target.SlipCompanyNmCd)
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

                 //&& (this.OthrSlipCompanyNmCd == target.OthrSlipCompanyNmCd)  // DEL 2008/06/03
                 && (this.SectionGuideNm == target.SectionGuideNm)
                 && (this.MainOfficeFuncFlag == target.MainOfficeFuncFlag)

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //				 && (this.BillCompanyNmPrtCd == target.BillCompanyNmPrtCd)
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
                //&& (this.SecCdForNumbering == target.SecCdForNumbering)  // DEL 2008/06/03
                 && (this.CompanyNameCd1 == target.CompanyNameCd1)
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                && (this.CompanyNameCd2 == target.CompanyNameCd2)
                && (this.CompanyNameCd3 == target.CompanyNameCd3)
                && (this.CompanyNameCd4 == target.CompanyNameCd4)
                && (this.CompanyNameCd5 == target.CompanyNameCd5)
                && (this.CompanyNameCd6 == target.CompanyNameCd6)
                && (this.CompanyNameCd7 == target.CompanyNameCd7)
                && (this.CompanyNameCd8 == target.CompanyNameCd8)
                && (this.CompanyNameCd9 == target.CompanyNameCd9)
                && (this.CompanyNameCd10 == target.CompanyNameCd10)
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                 && (this.CompanyName1 == target.CompanyName1)
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                && (this.CompanyName2 == target.CompanyName2)
                && (this.CompanyName3 == target.CompanyName3)
                && (this.CompanyName4 == target.CompanyName4)
                && (this.CompanyName5 == target.CompanyName5)
                && (this.CompanyName6 == target.CompanyName6)
                && (this.CompanyName7 == target.CompanyName7)
                && (this.CompanyName8 == target.CompanyName8)
                && (this.CompanyName9 == target.CompanyName9)
                && (this.CompanyName10 == target.CompanyName10)
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

                 // �� 2007.10.5 add///////////////////////////////////
                 && (this.SectWarehouseCd1 == target.SectWarehouseCd1)
                 && (this.SectWarehouseCd2 == target.SectWarehouseCd2)
                 && (this.SectWarehouseCd3 == target.SectWarehouseCd3)

                 && (this.SectWarehouseNm1 == target.SectWarehouseNm1)
                 && (this.SectWarehouseNm2 == target.SectWarehouseNm2)
                 && (this.SectWarehouseNm3 == target.SectWarehouseNm3)
                //  �� 2007.10.5 add//////////////////////////////////

                 && (this.UpdEmployeeName == target.UpdEmployeeName)

                 // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                 && (this.SectionGuideSnm == target.SectionGuideSnm)
                 && (this.IntroductionDate == target.IntroductionDate)
                 // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
                 && (this.EnterpriseName == target.EnterpriseName));
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //				 && (this.EnterpriseName == target.EnterpriseName)
            //				 && (this.SlipCompanyNm == target.SlipCompanyNm)
            //				 && (this.OthrSlipCompanyNm == target.OthrSlipCompanyNm)
            //				 && (this.MainOfficeFuncNm == target.MainOfficeFuncNm)
            //				 && (this.BillCompanyNmPrtNm == target.BillCompanyNmPrtNm));
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
        }

        /// <summary>
        /// ���_���ݒ�N���X��r����
        /// </summary>
        /// <param name="secinfoset1">
        ///                    ��r����SecInfoSet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="secinfoset2">��r����SecInfoSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecInfoSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SecInfoSet secinfoset1, SecInfoSet secinfoset2)
        {
            return ((secinfoset1.CreateDateTime == secinfoset2.CreateDateTime)
                 && (secinfoset1.UpdateDateTime == secinfoset2.UpdateDateTime)
                 && (secinfoset1.EnterpriseCode == secinfoset2.EnterpriseCode)
                 && (secinfoset1.FileHeaderGuid == secinfoset2.FileHeaderGuid)
                 && (secinfoset1.UpdEmployeeCode == secinfoset2.UpdEmployeeCode)
                 && (secinfoset1.UpdAssemblyId1 == secinfoset2.UpdAssemblyId1)
                 && (secinfoset1.UpdAssemblyId2 == secinfoset2.UpdAssemblyId2)
                 && (secinfoset1.LogicalDeleteCode == secinfoset2.LogicalDeleteCode)
                 && (secinfoset1.SectionCode == secinfoset2.SectionCode)
                ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //				 && (secinfoset1.CompanyPr == secinfoset2.CompanyPr)
                //				 && (secinfoset1.CompanyName1 == secinfoset2.CompanyName1)
                //				 && (secinfoset1.CompanyName2 == secinfoset2.CompanyName2)
                //				 && (secinfoset1.PostNo == secinfoset2.PostNo)
                //				 && (secinfoset1.Address1 == secinfoset2.Address1)
                //				 && (secinfoset1.Address2 == secinfoset2.Address2)
                //				 && (secinfoset1.Address3 == secinfoset2.Address3)
                //				 && (secinfoset1.Address4 == secinfoset2.Address4)
                //				 && (secinfoset1.CompanyTelNo1 == secinfoset2.CompanyTelNo1)
                //				 && (secinfoset1.CompanyTelNo2 == secinfoset2.CompanyTelNo2)
                //				 && (secinfoset1.CompanyTelNo3 == secinfoset2.CompanyTelNo3)
                //				 && (secinfoset1.CompanyTelTitle1 == secinfoset2.CompanyTelTitle1)
                //				 && (secinfoset1.CompanyTelTitle2 == secinfoset2.CompanyTelTitle2)
                //				 && (secinfoset1.CompanyTelTitle3 == secinfoset2.CompanyTelTitle3)
                //				 && (secinfoset1.TransferGuidance == secinfoset2.TransferGuidance)
                //				 && (secinfoset1.AccountNoInfo1 == secinfoset2.AccountNoInfo1)
                //				 && (secinfoset1.AccountNoInfo2 == secinfoset2.AccountNoInfo2)
                //				 && (secinfoset1.AccountNoInfo3 == secinfoset2.AccountNoInfo3)
                //				 && (secinfoset1.CompanySetNote1 == secinfoset2.CompanySetNote1)
                //				 && (secinfoset1.CompanySetNote2 == secinfoset2.CompanySetNote2)
                //				 && (secinfoset1.SlipCompanyNmCd == secinfoset2.SlipCompanyNmCd)
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

                 //&& (secinfoset1.OthrSlipCompanyNmCd == secinfoset2.OthrSlipCompanyNmCd)  // DEL 2008/06/03
                 && (secinfoset1.SectionGuideNm == secinfoset2.SectionGuideNm)
                 && (secinfoset1.MainOfficeFuncFlag == secinfoset2.MainOfficeFuncFlag)

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
                //				 && (secinfoset1.BillCompanyNmPrtCd == secinfoset2.BillCompanyNmPrtCd)
                // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
                //&& (secinfoset1.SecCdForNumbering == secinfoset2.SecCdForNumbering)  // DEL 2008/06/03
                 && (secinfoset1.CompanyNameCd1 == secinfoset2.CompanyNameCd1)
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                && (secinfoset1.CompanyNameCd2 == secinfoset2.CompanyNameCd2)
                && (secinfoset1.CompanyNameCd3 == secinfoset2.CompanyNameCd3)
                && (secinfoset1.CompanyNameCd4 == secinfoset2.CompanyNameCd4)
                && (secinfoset1.CompanyNameCd5 == secinfoset2.CompanyNameCd5)
                && (secinfoset1.CompanyNameCd6 == secinfoset2.CompanyNameCd6)
                && (secinfoset1.CompanyNameCd7 == secinfoset2.CompanyNameCd7)
                && (secinfoset1.CompanyNameCd8 == secinfoset2.CompanyNameCd8)
                && (secinfoset1.CompanyNameCd9 == secinfoset2.CompanyNameCd9)
                && (secinfoset1.CompanyNameCd10 == secinfoset2.CompanyNameCd10)
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                 && (secinfoset1.CompanyName1 == secinfoset2.CompanyName1)
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                && (secinfoset1.CompanyName2 == secinfoset2.CompanyName2)
                && (secinfoset1.CompanyName3 == secinfoset2.CompanyName3)
                && (secinfoset1.CompanyName4 == secinfoset2.CompanyName4)
                && (secinfoset1.CompanyName5 == secinfoset2.CompanyName5)
                && (secinfoset1.CompanyName6 == secinfoset2.CompanyName6)
                && (secinfoset1.CompanyName7 == secinfoset2.CompanyName7)
                && (secinfoset1.CompanyName8 == secinfoset2.CompanyName8)
                && (secinfoset1.CompanyName9 == secinfoset2.CompanyName9)
                && (secinfoset1.CompanyName10 == secinfoset2.CompanyName10)
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

                // �� 2007.10.5 add///////////////////////////////////////////////////
                 && (secinfoset1.SectWarehouseCd1 == secinfoset2.SectWarehouseCd1)
                 && (secinfoset1.SectWarehouseCd2 == secinfoset2.SectWarehouseCd2)
                 && (secinfoset1.SectWarehouseCd3 == secinfoset2.SectWarehouseCd3)
                 && (secinfoset1.SectWarehouseNm1 == secinfoset2.SectWarehouseNm1)
                 && (secinfoset1.SectWarehouseNm2 == secinfoset2.SectWarehouseNm2)
                 && (secinfoset1.SectWarehouseNm3 == secinfoset2.SectWarehouseNm3)
                // �� 2007.10.5 add///////////////////////////////////////////////////


                 && (secinfoset1.UpdEmployeeName == secinfoset2.UpdEmployeeName)

                 // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
                 && (secinfoset1.SectionGuideSnm == secinfoset2.SectionGuideSnm)
                 && (secinfoset1.IntroductionDate == secinfoset2.IntroductionDate)
                 // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
                 && (secinfoset1.EnterpriseName == secinfoset2.EnterpriseName));
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //				 && (secinfoset1.EnterpriseName == secinfoset2.EnterpriseName)
            //				 && (secinfoset1.SlipCompanyNm == secinfoset2.SlipCompanyNm)
            //				 && (secinfoset1.OthrSlipCompanyNm == secinfoset2.OthrSlipCompanyNm)
            //				 && (secinfoset1.MainOfficeFuncNm == secinfoset2.MainOfficeFuncNm)
            //				 && (secinfoset1.BillCompanyNmPrtNm == secinfoset2.BillCompanyNmPrtNm));
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
        }
        /// <summary>
        /// ���_���ݒ�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SecInfoSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecInfoSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SecInfoSet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(this.CompanyPr != target.CompanyPr)resList.Add("CompanyPr");
            //			if(this.CompanyName1 != target.CompanyName1)resList.Add("CompanyName1");
            //			if(this.CompanyName2 != target.CompanyName2)resList.Add("CompanyName2");
            //			if(this.PostNo != target.PostNo)resList.Add("PostNo");
            //			if(this.Address1 != target.Address1)resList.Add("Address1");
            //			if(this.Address2 != target.Address2)resList.Add("Address2");
            //			if(this.Address3 != target.Address3)resList.Add("Address3");
            //			if(this.Address4 != target.Address4)resList.Add("Address4");
            //			if(this.CompanyTelNo1 != target.CompanyTelNo1)resList.Add("CompanyTelNo1");
            //			if(this.CompanyTelNo2 != target.CompanyTelNo2)resList.Add("CompanyTelNo2");
            //			if(this.CompanyTelNo3 != target.CompanyTelNo3)resList.Add("CompanyTelNo3");
            //			if(this.CompanyTelTitle1 != target.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
            //			if(this.CompanyTelTitle2 != target.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
            //			if(this.CompanyTelTitle3 != target.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
            //			if(this.TransferGuidance != target.TransferGuidance)resList.Add("TransferGuidance");
            //			if(this.AccountNoInfo1 != target.AccountNoInfo1)resList.Add("AccountNoInfo1");
            //			if(this.AccountNoInfo2 != target.AccountNoInfo2)resList.Add("AccountNoInfo2");
            //			if(this.AccountNoInfo3 != target.AccountNoInfo3)resList.Add("AccountNoInfo3");
            //			if(this.CompanySetNote1 != target.CompanySetNote1)resList.Add("CompanySetNote1");
            //			if(this.CompanySetNote2 != target.CompanySetNote2)resList.Add("CompanySetNote2");
            //			if(this.SlipCompanyNmCd != target.SlipCompanyNmCd)resList.Add("SlipCompanyNmCd");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //if (this.OthrSlipCompanyNmCd != target.OthrSlipCompanyNmCd) resList.Add("OthrSlipCompanyNmCd");  // DEL 2008/06/03
            if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
            if (this.MainOfficeFuncFlag != target.MainOfficeFuncFlag) resList.Add("MainOfficeFuncFlag");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(this.BillCompanyNmPrtCd != target.BillCompanyNmPrtCd)resList.Add("BillCompanyNmPrtCd");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //if (this.SecCdForNumbering != target.SecCdForNumbering) resList.Add("SecCdForNumbering");  // DEL 2008/06/03
            if (this.CompanyNameCd1 != target.CompanyNameCd1) resList.Add("CompanyNameCd1");
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            if (this.CompanyNameCd2 != target.CompanyNameCd2) resList.Add("CompanyNameCd2");
            if (this.CompanyNameCd3 != target.CompanyNameCd3) resList.Add("CompanyNameCd3");
            if (this.CompanyNameCd4 != target.CompanyNameCd4) resList.Add("CompanyNameCd4");
            if (this.CompanyNameCd5 != target.CompanyNameCd5) resList.Add("CompanyNameCd5");
            if (this.CompanyNameCd6 != target.CompanyNameCd6) resList.Add("CompanyNameCd6");
            if (this.CompanyNameCd7 != target.CompanyNameCd7) resList.Add("CompanyNameCd7");
            if (this.CompanyNameCd8 != target.CompanyNameCd8) resList.Add("CompanyNameCd8");
            if (this.CompanyNameCd9 != target.CompanyNameCd9) resList.Add("CompanyNameCd9");
            if (this.CompanyNameCd10 != target.CompanyNameCd10) resList.Add("CompanyNameCd10");
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            if (this.CompanyName1 != target.CompanyName1) resList.Add("CompanyName1");
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            if (this.CompanyName2 != target.CompanyName2) resList.Add("CompanyName2");
            if (this.CompanyName3 != target.CompanyName3) resList.Add("CompanyName3");
            if (this.CompanyName4 != target.CompanyName4) resList.Add("CompanyName4");
            if (this.CompanyName5 != target.CompanyName5) resList.Add("CompanyName5");
            if (this.CompanyName6 != target.CompanyName6) resList.Add("CompanyName6");
            if (this.CompanyName7 != target.CompanyName7) resList.Add("CompanyName7");
            if (this.CompanyName8 != target.CompanyName8) resList.Add("CompanyName8");
            if (this.CompanyName9 != target.CompanyName9) resList.Add("CompanyName9");
            if (this.CompanyName10 != target.CompanyName10) resList.Add("CompanyName10");
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 add///////////////////////////////////////////////////////////////////
            if (this.SectWarehouseCd1 != target.SectWarehouseCd1) resList.Add("SectWarehouseCd1");
            if (this.SectWarehouseCd2 != target.SectWarehouseCd2) resList.Add("SectWarehouseCd2");
            if (this.SectWarehouseCd3 != target.SectWarehouseCd3) resList.Add("SectWarehouseCd3");
            if (this.SectWarehouseNm1 != target.SectWarehouseNm1) resList.Add("SectWarehouseNm1");
            if (this.SectWarehouseNm2 != target.SectWarehouseNm2) resList.Add("SectWarehouseNm2");
            if (this.SectWarehouseNm3 != target.SectWarehouseNm3) resList.Add("SectWarehouseNm3");
            // �� 2007.10.5 add//////////////////////////////////////////////////////////////////


            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(this.SlipCompanyNm != target.SlipCompanyNm)resList.Add("SlipCompanyNm");
            //			if(this.OthrSlipCompanyNm != target.OthrSlipCompanyNm)resList.Add("OthrSlipCompanyNm");
            //			if(this.MainOfficeFuncNm != target.MainOfficeFuncNm)resList.Add("MainOfficeFuncNm");
            //			if(this.BillCompanyNmPrtNm != target.BillCompanyNmPrtNm)resList.Add("BillCompanyNmPrtNm");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            if (this.SectionGuideSnm != target.SectionGuideSnm) resList.Add("SectionGuideSnm");
            if (this.IntroductionDate != target.IntroductionDate) resList.Add("IntroductionDate");
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            return resList;
        }

        /// <summary>
        /// ���_���ݒ�N���X��r����
        /// </summary>
        /// <param name="secinfoset1">��r����SecInfoSet�N���X�̃C���X�^���X</param>
        /// <param name="secinfoset2">��r����SecInfoSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SecInfoSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SecInfoSet secinfoset1, SecInfoSet secinfoset2)
        {
            ArrayList resList = new ArrayList();
            if (secinfoset1.CreateDateTime != secinfoset2.CreateDateTime) resList.Add("CreateDateTime");
            if (secinfoset1.UpdateDateTime != secinfoset2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (secinfoset1.EnterpriseCode != secinfoset2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (secinfoset1.FileHeaderGuid != secinfoset2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (secinfoset1.UpdEmployeeCode != secinfoset2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (secinfoset1.UpdAssemblyId1 != secinfoset2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (secinfoset1.UpdAssemblyId2 != secinfoset2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (secinfoset1.LogicalDeleteCode != secinfoset2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (secinfoset1.SectionCode != secinfoset2.SectionCode) resList.Add("SectionCode");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(secinfoset1.CompanyPr != secinfoset2.CompanyPr)resList.Add("CompanyPr");
            //			if(secinfoset1.CompanyName1 != secinfoset2.CompanyName1)resList.Add("CompanyName1");
            //			if(secinfoset1.CompanyName2 != secinfoset2.CompanyName2)resList.Add("CompanyName2");
            //			if(secinfoset1.PostNo != secinfoset2.PostNo)resList.Add("PostNo");
            //			if(secinfoset1.Address1 != secinfoset2.Address1)resList.Add("Address1");
            //			if(secinfoset1.Address2 != secinfoset2.Address2)resList.Add("Address2");
            //			if(secinfoset1.Address3 != secinfoset2.Address3)resList.Add("Address3");
            //			if(secinfoset1.Address4 != secinfoset2.Address4)resList.Add("Address4");
            //			if(secinfoset1.CompanyTelNo1 != secinfoset2.CompanyTelNo1)resList.Add("CompanyTelNo1");
            //			if(secinfoset1.CompanyTelNo2 != secinfoset2.CompanyTelNo2)resList.Add("CompanyTelNo2");
            //			if(secinfoset1.CompanyTelNo3 != secinfoset2.CompanyTelNo3)resList.Add("CompanyTelNo3");
            //			if(secinfoset1.CompanyTelTitle1 != secinfoset2.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
            //			if(secinfoset1.CompanyTelTitle2 != secinfoset2.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
            //			if(secinfoset1.CompanyTelTitle3 != secinfoset2.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
            //			if(secinfoset1.TransferGuidance != secinfoset2.TransferGuidance)resList.Add("TransferGuidance");
            //			if(secinfoset1.AccountNoInfo1 != secinfoset2.AccountNoInfo1)resList.Add("AccountNoInfo1");
            //			if(secinfoset1.AccountNoInfo2 != secinfoset2.AccountNoInfo2)resList.Add("AccountNoInfo2");
            //			if(secinfoset1.AccountNoInfo3 != secinfoset2.AccountNoInfo3)resList.Add("AccountNoInfo3");
            //			if(secinfoset1.CompanySetNote1 != secinfoset2.CompanySetNote1)resList.Add("CompanySetNote1");
            //			if(secinfoset1.CompanySetNote2 != secinfoset2.CompanySetNote2)resList.Add("CompanySetNote2");
            //			if(secinfoset1.SlipCompanyNmCd != secinfoset2.SlipCompanyNmCd)resList.Add("SlipCompanyNmCd");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            //if (secinfoset1.OthrSlipCompanyNmCd != secinfoset2.OthrSlipCompanyNmCd) resList.Add("OthrSlipCompanyNmCd");  // DEL 2008/06/03
            if (secinfoset1.SectionGuideNm != secinfoset2.SectionGuideNm) resList.Add("SectionGuideNm");
            if (secinfoset1.MainOfficeFuncFlag != secinfoset2.MainOfficeFuncFlag) resList.Add("MainOfficeFuncFlag");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(secinfoset1.BillCompanyNmPrtCd != secinfoset2.BillCompanyNmPrtCd)resList.Add("BillCompanyNmPrtCd");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
            //if (secinfoset1.SecCdForNumbering != secinfoset2.SecCdForNumbering) resList.Add("SecCdForNumbering");  // DEL 2008/06/03
            if (secinfoset1.CompanyNameCd1 != secinfoset2.CompanyNameCd1) resList.Add("CompanyNameCd1");
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            if (secinfoset1.CompanyNameCd2 != secinfoset2.CompanyNameCd2) resList.Add("CompanyNameCd2");
            if (secinfoset1.CompanyNameCd3 != secinfoset2.CompanyNameCd3) resList.Add("CompanyNameCd3");
            if (secinfoset1.CompanyNameCd4 != secinfoset2.CompanyNameCd4) resList.Add("CompanyNameCd4");
            if (secinfoset1.CompanyNameCd5 != secinfoset2.CompanyNameCd5) resList.Add("CompanyNameCd5");
            if (secinfoset1.CompanyNameCd6 != secinfoset2.CompanyNameCd6) resList.Add("CompanyNameCd6");
            if (secinfoset1.CompanyNameCd7 != secinfoset2.CompanyNameCd7) resList.Add("CompanyNameCd7");
            if (secinfoset1.CompanyNameCd8 != secinfoset2.CompanyNameCd8) resList.Add("CompanyNameCd8");
            if (secinfoset1.CompanyNameCd9 != secinfoset2.CompanyNameCd9) resList.Add("CompanyNameCd9");
            if (secinfoset1.CompanyNameCd10 != secinfoset2.CompanyNameCd10) resList.Add("CompanyNameCd10");
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            if (secinfoset1.CompanyName1 != secinfoset2.CompanyName1) resList.Add("CompanyName1");
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            if (secinfoset1.CompanyName2 != secinfoset2.CompanyName2) resList.Add("CompanyName2");
            if (secinfoset1.CompanyName3 != secinfoset2.CompanyName3) resList.Add("CompanyName3");
            if (secinfoset1.CompanyName4 != secinfoset2.CompanyName4) resList.Add("CompanyName4");
            if (secinfoset1.CompanyName5 != secinfoset2.CompanyName5) resList.Add("CompanyName5");
            if (secinfoset1.CompanyName6 != secinfoset2.CompanyName6) resList.Add("CompanyName6");
            if (secinfoset1.CompanyName7 != secinfoset2.CompanyName7) resList.Add("CompanyName7");
            if (secinfoset1.CompanyName8 != secinfoset2.CompanyName8) resList.Add("CompanyName8");
            if (secinfoset1.CompanyName9 != secinfoset2.CompanyName9) resList.Add("CompanyName9");
            if (secinfoset1.CompanyName10 != secinfoset2.CompanyName10) resList.Add("CompanyName10");
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
            // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �� 2007.10.5 add////////////////////////////////////////////////////////////////////////////////
            if (secinfoset1.SectWarehouseCd1 != secinfoset2.SectWarehouseCd1) resList.Add("SectWarehouseCd1");
            if (secinfoset1.SectWarehouseCd2 != secinfoset2.SectWarehouseCd2) resList.Add("SectWarehouseCd2");
            if (secinfoset1.SectWarehouseCd3 != secinfoset2.SectWarehouseCd3) resList.Add("SectWarehouseCd3");
            if (secinfoset1.SectWarehouseNm1 != secinfoset2.SectWarehouseNm1) resList.Add("SectWarehouseNm1");
            if (secinfoset1.SectWarehouseNm2 != secinfoset2.SectWarehouseNm2) resList.Add("SectWarehouseNm2");
            if (secinfoset1.SectWarehouseNm3 != secinfoset2.SectWarehouseNm3) resList.Add("SectWarehouseNm3");
            // �� 2007.10.5 add///////////////////////////////////////////////////////////////////////////////

            if (secinfoset1.UpdEmployeeName != secinfoset2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (secinfoset1.EnterpriseName != secinfoset2.EnterpriseName) resList.Add("EnterpriseName");

            ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA DEL STA //
            //			if(secinfoset1.SlipCompanyNm != secinfoset2.SlipCompanyNm)resList.Add("SlipCompanyNm");
            //			if(secinfoset1.OthrSlipCompanyNm != secinfoset2.OthrSlipCompanyNm)resList.Add("OthrSlipCompanyNm");
            //			if(secinfoset1.MainOfficeFuncNm != secinfoset2.MainOfficeFuncNm)resList.Add("MainOfficeFuncNm");
            //			if(secinfoset1.BillCompanyNmPrtNm != secinfoset2.BillCompanyNmPrtNm)resList.Add("BillCompanyNmPrtNm");
            // 2005.09.13 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////

            // --- ADD 2008/06/03 --------------------------------------------------------------------->>>>>
            if (secinfoset1.SectionGuideSnm != secinfoset2.SectionGuideSnm) resList.Add("SectionGuideSnm");
            if (secinfoset1.IntroductionDate != secinfoset2.IntroductionDate) resList.Add("IntroductionDate");
            // --- ADD 2008/06/03 ---------------------------------------------------------------------<<<<<

            return resList;
        }

        ///////////////////////////////////////////////////////////////////// 2005.09.13 AKIYAMA ADD STA //
        /// <summary>
        /// ���Ж��̃R�[�h�擾����
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>���Ж��̃R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����Ж��̃R�[�h���擾���܂�</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public int GetCompanyNameCd(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._companyNameCd1;
                    }
            /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
            case 1:
                {
                    return this._companyNameCd2;
                }
            case 2:
                {
                    return this._companyNameCd3;
                }
            case 3:
                {
                    return this._companyNameCd4;
                }
            case 4:
                {
                    return this._companyNameCd5;
                }
            case 5:
                {
                    return this._companyNameCd6;
                }
            case 6:
                {
                    return this._companyNameCd7;
                }
            case 7:
                {
                    return this._companyNameCd8;
                }
            case 8:
                {
                    return this._companyNameCd9;
                }
            case 9:
                {
                    return this._companyNameCd10;
                }
               --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                default:
                    {
                        return 0;
                    }
            }
        }

        /// <summary>
        /// ���Ж��̃R�[�h�ݒ菈��
        /// </summary>
        /// <param name="companyNameCd">���Ж��̃R�[�h</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����Ж��̃R�[�h��ݒ肵�܂�</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public void SetCompanyNameCd(int companyNameCd, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._companyNameCd1 = companyNameCd;
                        break;
                    }
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                case 1:
                    {
                        this._companyNameCd2 = companyNameCd;
                        break;
                    }
                case 2:
                    {
                        this._companyNameCd3 = companyNameCd;
                        break;
                    }
                case 3:
                    {
                        this._companyNameCd4 = companyNameCd;
                        break;
                    }
                case 4:
                    {
                        this._companyNameCd5 = companyNameCd;
                        break;
                    }
                case 5:
                    {
                        this._companyNameCd6 = companyNameCd;
                        break;
                    }
                case 6:
                    {
                        this._companyNameCd7 = companyNameCd;
                        break;
                    }
                case 7:
                    {
                        this._companyNameCd8 = companyNameCd;
                        break;
                    }
                case 8:
                    {
                        this._companyNameCd9 = companyNameCd;
                        break;
                    }
                case 9:
                    {
                        this._companyNameCd10 = companyNameCd;
                        break;
                    }
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// ���Ж��̎擾����
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>���Ж���</returns>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����Ж��̂��擾���܂�</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public string GetCompanyName(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._companyName1;
                    }
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                case 1:
                    {
                        return this._companyName2;
                    }
                case 2:
                    {
                        return this._companyName3;
                    }
                case 3:
                    {
                        return this._companyName4;
                    }
                case 4:
                    {
                        return this._companyName5;
                    }
                case 5:
                    {
                        return this._companyName6;
                    }
                case 6:
                    {
                        return this._companyName7;
                    }
                case 7:
                    {
                        return this._companyName8;
                    }
                case 8:
                    {
                        return this._companyName9;
                    }
                case 9:
                    {
                        return this._companyName10;
                    }
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// ���Ж��̐ݒ菈��
        /// </summary>
        /// <param name="companyName">���Ж���</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����Ж��̂�ݒ肵�܂�</br>
        /// <br>Programmer : 23001 �H�R�@����</br>
        /// <br>Date       : 2005.09.13</br>
        /// </remarks>
        public void SetCompanyName(string companyName, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._companyName1 = companyName;
                        break;
                    }
                /* --- DEL 2008/06/03 --------------------------------------------------------------------->>>>>
                case 1:
                    {
                        this._companyName2 = companyName;
                        break;
                    }
                case 2:
                    {
                        this._companyName3 = companyName;
                        break;
                    }
                case 3:
                    {
                        this._companyName4 = companyName;
                        break;
                    }
                case 4:
                    {
                        this._companyName5 = companyName;
                        break;
                    }
                case 5:
                    {
                        this._companyName6 = companyName;
                        break;
                    }
                case 6:
                    {
                        this._companyName7 = companyName;
                        break;
                    }
                case 7:
                    {
                        this._companyName8 = companyName;
                        break;
                    }
                case 8:
                    {
                        this._companyName9 = companyName;
                        break;
                    }
                case 9:
                    {
                        this._companyName10 = companyName;
                        break;
                    }
                   --- DEL 2008/06/03 ---------------------------------------------------------------------<<<<<*/
                default:
                    {
                        break;
                    }
            }
        }
        // 2005.09.13 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////


        // �� 2007.10.5 add///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// ���_�q�ɃR�[�h�擾����
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>���_�q�ɃR�[�h</returns>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����_�q�ɃR�[�h���擾���܂�</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public string GetSectWarehouseCd(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._sectWarehouseCd1;
                    }
                case 1:
                    {
                        return this._sectWarehouseCd2;
                    }
                case 2:
                    {
                        return this._sectWarehouseCd3;
                    }
                default:
                    {
                        return "";
                    }
            }
        }

        /// <summary>
        /// ���_�q�ɃR�[�h�ݒ菈��
        /// </summary>
        /// <param name="sectWarehouseCd">���_�q�ɃR�[�h</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����_�q�ɃR�[�h��ݒ肵�܂�</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public void SetSectWarehouseCd(string sectWarehouseCd, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._sectWarehouseCd1 = sectWarehouseCd;
                        break;
                    }
                case 1:
                    {
                        this._sectWarehouseCd2 = sectWarehouseCd;
                        break;
                    }
                case 2:
                    {
                        this._sectWarehouseCd3 = sectWarehouseCd;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// ���_�q�ɖ��̎擾����
        /// </summary>
        /// <param name="index">�C���f�b�N�X</param>
        /// <returns>���_�q�ɖ���</returns>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����Ж��̂��擾���܂�</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public string GetSectWarehouseNm(int index)
        {
            switch (index)
            {
                case 0:
                    {
                        return this._sectWarehouseNm1;
                    }
                case 1:
                    {
                        return this._sectWarehouseNm2;
                    }
                case 2:
                    {
                        return this._sectWarehouseNm3;
                    }
                default:
                    {
                        return "";
                    }

            }
        }

        /// <summary>
        /// ���_�q�ɖ��̐ݒ菈��
        /// </summary>
        /// <param name="sectWarehouseNm">���_�q�ɖ���</param>
        /// <param name="index">�C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �C���f�b�N�X�Ŏw�肵�����Ж��̂�ݒ肵�܂�</br>
        /// <br>Date       : 2007.10.5</br>
        /// </remarks>
        public void SetSectWarehouseNm(string sectWarehouseNm, int index)
        {
            switch (index)
            {
                case 0:
                    {
                        this._sectWarehouseNm1 = sectWarehouseNm;
                        break;
                    }
                case 1:
                    {
                        this._sectWarehouseNm2 = sectWarehouseNm;
                        break;
                    }
                case 2:
                    {
                        this._sectWarehouseNm3 = sectWarehouseNm;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        // �� 2007.10.5 add//////////////////////////////////////////////////////////////////////////////
    }
}