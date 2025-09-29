using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   CompanyNm
	/// <summary>
	///                      ���Ж��̃}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���Ж��̃}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/05/16  (CSharp File Generated Date)</br>
    /// -----------------------------------------------------------------------
    /// <br>Update Note      : 2008/06/04 30414�@�E�@�K�j</br>
    /// <br>                 :�u�Z��2�v�폜</br>
    /// </remarks>
	/// </remarks>
	public class CompanyNm
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

		/// <summary>���Ж��̃R�[�h</summary>
		private Int32 _companyNameCd;

		/// <summary>����PR��</summary>
		private string _companyPr = "";

		/// <summary>���Ж���1</summary>
		private string _companyName1 = "";

		/// <summary>���Ж���2</summary>
		private string _companyName2 = "";

		/// <summary>�X�֔ԍ�</summary>
		private string _postNo = "";

		/// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
		private string _address1 = "";

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// <summary>�Z��2�i���ځj</summary>
		private Int32 _address2;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>�Z��3�i�Ԓn�j</summary>
		private string _address3 = "";

		/// <summary>�Z��4�i�A�p�[�g���́j</summary>
		private string _address4 = "";

		/// <summary>���Гd�b�ԍ�1</summary>
		private string _companyTelNo1 = "";

		/// <summary>���Гd�b�ԍ�2</summary>
		private string _companyTelNo2 = "";

		/// <summary>���Гd�b�ԍ�3</summary>
		private string _companyTelNo3 = "";

		/// <summary>���Гd�b�ԍ��^�C�g��1</summary>
		private string _companyTelTitle1 = "";

		/// <summary>���Гd�b�ԍ��^�C�g��2</summary>
		private string _companyTelTitle2 = "";

		/// <summary>���Гd�b�ԍ��^�C�g��3</summary>
		private string _companyTelTitle3 = "";

		/// <summary>��s�U���ē���</summary>
		private string _transferGuidance = "";

		/// <summary>��s����1</summary>
		private string _accountNoInfo1 = "";

		/// <summary>��s����2</summary>
		private string _accountNoInfo2 = "";

		/// <summary>��s����3</summary>
		private string _accountNoInfo3 = "";

		/// <summary>���Аݒ�E�v1</summary>
		private string _companySetNote1 = "";

		/// <summary>���Аݒ�E�v2</summary>
		private string _companySetNote2 = "";

		/// <summary>�摜���敪</summary>
		/// <remarks>10:���Љ摜,20:POS�Ŏg�p����摜</remarks>
		private Int32 _imageInfoDiv;

		/// <summary>�摜���R�[�h</summary>
		private Int32 _imageInfoCode;

		/// <summary>����URL</summary>
		private string _companyUrl = "";

		/// <summary>����PR��2</summary>
		/// <remarks>��\����𓙂̏������</remarks>
		private string _companyPrSentence2 = "";

		/// <summary>�摜�󎚗p�R�����g1</summary>
		/// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
		private string _imageCommentForPrt1 = "";

		/// <summary>�摜�󎚗p�R�����g2</summary>
		/// <remarks>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</remarks>
		private string _imageCommentForPrt2 = "";

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

		/// public propaty name  :  CompanyNameCd
		/// <summary>���Ж��̃R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ж��̃R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CompanyNameCd
		{
			get{return _companyNameCd;}
			set{_companyNameCd = value;}
		}

		/// public propaty name  :  CompanyPr
		/// <summary>����PR���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����PR���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyPr
		{
			get{return _companyPr;}
			set{_companyPr = value;}
		}

		/// public propaty name  :  CompanyName1
		/// <summary>���Ж���1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ж���1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyName1
		{
			get{return _companyName1;}
			set{_companyName1 = value;}
		}

		/// public propaty name  :  CompanyName2
		/// <summary>���Ж���2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ж���2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyName2
		{
			get{return _companyName2;}
			set{_companyName2 = value;}
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
			get{return _postNo;}
			set{_postNo = value;}
		}

		/// public propaty name  :  Address1
		/// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address1
		{
			get{return _address1;}
			set{_address1 = value;}
		}

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// public propaty name  :  Address2
		/// <summary>�Z��2�i���ځj�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��2�i���ځj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Address2
		{
			get{return _address2;}
			set{_address2 = value;}
		}
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  Address3
		/// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address3
		{
			get{return _address3;}
			set{_address3 = value;}
		}

		/// public propaty name  :  Address4
		/// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Address4
		{
			get{return _address4;}
			set{_address4 = value;}
		}

		/// public propaty name  :  CompanyTelNo1
		/// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelNo1
		{
			get{return _companyTelNo1;}
			set{_companyTelNo1 = value;}
		}

		/// public propaty name  :  CompanyTelNo2
		/// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelNo2
		{
			get{return _companyTelNo2;}
			set{_companyTelNo2 = value;}
		}

		/// public propaty name  :  CompanyTelNo3
		/// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelNo3
		{
			get{return _companyTelNo3;}
			set{_companyTelNo3 = value;}
		}

		/// public propaty name  :  CompanyTelTitle1
		/// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelTitle1
		{
			get{return _companyTelTitle1;}
			set{_companyTelTitle1 = value;}
		}

		/// public propaty name  :  CompanyTelTitle2
		/// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelTitle2
		{
			get{return _companyTelTitle2;}
			set{_companyTelTitle2 = value;}
		}

		/// public propaty name  :  CompanyTelTitle3
		/// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyTelTitle3
		{
			get{return _companyTelTitle3;}
			set{_companyTelTitle3 = value;}
		}

		/// public propaty name  :  TransferGuidance
		/// <summary>��s�U���ē����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s�U���ē����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string TransferGuidance
		{
			get{return _transferGuidance;}
			set{_transferGuidance = value;}
		}

		/// public propaty name  :  AccountNoInfo1
		/// <summary>��s����1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s����1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AccountNoInfo1
		{
			get{return _accountNoInfo1;}
			set{_accountNoInfo1 = value;}
		}

		/// public propaty name  :  AccountNoInfo2
		/// <summary>��s����2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s����2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AccountNoInfo2
		{
			get{return _accountNoInfo2;}
			set{_accountNoInfo2 = value;}
		}

		/// public propaty name  :  AccountNoInfo3
		/// <summary>��s����3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��s����3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AccountNoInfo3
		{
			get{return _accountNoInfo3;}
			set{_accountNoInfo3 = value;}
		}

		/// public propaty name  :  CompanySetNote1
		/// <summary>���Аݒ�E�v1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Аݒ�E�v1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanySetNote1
		{
			get{return _companySetNote1;}
			set{_companySetNote1 = value;}
		}

		/// public propaty name  :  CompanySetNote2
		/// <summary>���Аݒ�E�v2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Аݒ�E�v2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanySetNote2
		{
			get{return _companySetNote2;}
			set{_companySetNote2 = value;}
		}

		/// public propaty name  :  ImageInfoDiv
		/// <summary>�摜���敪�v���p�e�B</summary>
		/// <value>10:���Љ摜,20:POS�Ŏg�p����摜</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �摜���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ImageInfoDiv
		{
			get{return _imageInfoDiv;}
			set{_imageInfoDiv = value;}
		}

		/// public propaty name  :  ImageInfoCode
		/// <summary>�摜���R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �摜���R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ImageInfoCode
		{
			get{return _imageInfoCode;}
			set{_imageInfoCode = value;}
		}

		/// public propaty name  :  CompanyUrl
		/// <summary>����URL�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����URL�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyUrl
		{
			get{return _companyUrl;}
			set{_companyUrl = value;}
		}

		/// public propaty name  :  CompanyPrSentence2
		/// <summary>����PR��2�v���p�e�B</summary>
		/// <value>��\����𓙂̏������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����PR��2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CompanyPrSentence2
		{
			get{return _companyPrSentence2;}
			set{_companyPrSentence2 = value;}
		}

		/// public propaty name  :  ImageCommentForPrt1
		/// <summary>�摜�󎚗p�R�����g1�v���p�e�B</summary>
		/// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �摜�󎚗p�R�����g1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ImageCommentForPrt1
		{
			get{return _imageCommentForPrt1;}
			set{_imageCommentForPrt1 = value;}
		}

		/// public propaty name  :  ImageCommentForPrt2
		/// <summary>�摜�󎚗p�R�����g2�v���p�e�B</summary>
		/// <value>�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �摜�󎚗p�R�����g2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ImageCommentForPrt2
		{
			get{return _imageCommentForPrt2;}
			set{_imageCommentForPrt2 = value;}
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
		/// ���Ж��̃}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>CompanyNm�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyNm�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CompanyNm()
		{
		}

		/// <summary>
		/// ���Ж��̃}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="companyNameCd">���Ж��̃R�[�h</param>
		/// <param name="companyPr">����PR��</param>
		/// <param name="companyName1">���Ж���1</param>
		/// <param name="companyName2">���Ж���2</param>
		/// <param name="postNo">�X�֔ԍ�</param>
		/// <param name="address1">�Z��1�i�s���{���s��S�E�����E���j</param>
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		/// <param name="address2">�Z��2�i���ځj</param>
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        /// <param name="address3">�Z��3�i�Ԓn�j</param>
		/// <param name="address4">�Z��4�i�A�p�[�g���́j</param>
		/// <param name="companyTelNo1">���Гd�b�ԍ�1</param>
		/// <param name="companyTelNo2">���Гd�b�ԍ�2</param>
		/// <param name="companyTelNo3">���Гd�b�ԍ�3</param>
		/// <param name="companyTelTitle1">���Гd�b�ԍ��^�C�g��1</param>
		/// <param name="companyTelTitle2">���Гd�b�ԍ��^�C�g��2</param>
		/// <param name="companyTelTitle3">���Гd�b�ԍ��^�C�g��3</param>
		/// <param name="transferGuidance">��s�U���ē���</param>
		/// <param name="accountNoInfo1">��s����1</param>
		/// <param name="accountNoInfo2">��s����2</param>
		/// <param name="accountNoInfo3">��s����3</param>
		/// <param name="companySetNote1">���Аݒ�E�v1</param>
		/// <param name="companySetNote2">���Аݒ�E�v2</param>
		/// <param name="imageInfoDiv">�摜���敪(10:���Љ摜,20:POS�Ŏg�p����摜)</param>
		/// <param name="imageInfoCode">�摜���R�[�h</param>
		/// <param name="companyUrl">����URL</param>
		/// <param name="companyPrSentence2">����PR��2(��\����𓙂̏������)</param>
		/// <param name="imageCommentForPrt1">�摜�󎚗p�R�����g1(�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j)</param>
		/// <param name="imageCommentForPrt2">�摜�󎚗p�R�����g2(�摜�󎚂���ꍇ�A�摜�̉��Ɉ󎚂���i���_�����j)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>CompanyNm�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyNm�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
		public CompanyNm(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 companyNameCd,string companyPr,string companyName1,string companyName2,string postNo,string address1,Int32 address2,string address3,string address4,string companyTelNo1,string companyTelNo2,string companyTelNo3,string companyTelTitle1,string companyTelTitle2,string companyTelTitle3,string transferGuidance,string accountNoInfo1,string accountNoInfo2,string accountNoInfo3,string companySetNote1,string companySetNote2,Int32 imageInfoDiv,Int32 imageInfoCode,string companyUrl,string companyPrSentence2,string imageCommentForPrt1,string imageCommentForPrt2,string enterpriseName,string updEmployeeName)
		   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        public CompanyNm(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 companyNameCd,string companyPr,string companyName1,string companyName2,string postNo,string address1,string address3,string address4,string companyTelNo1,string companyTelNo2,string companyTelNo3,string companyTelTitle1,string companyTelTitle2,string companyTelTitle3,string transferGuidance,string accountNoInfo1,string accountNoInfo2,string accountNoInfo3,string companySetNote1,string companySetNote2,Int32 imageInfoDiv,Int32 imageInfoCode,string companyUrl,string companyPrSentence2,string imageCommentForPrt1,string imageCommentForPrt2,string enterpriseName,string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._companyNameCd = companyNameCd;
			this._companyPr = companyPr;
			this._companyName1 = companyName1;
			this._companyName2 = companyName2;
			this._postNo = postNo;
			this._address1 = address1;
            //this._address2 = address2;  // DEL 2008/06/04
			this._address3 = address3;
			this._address4 = address4;
			this._companyTelNo1 = companyTelNo1;
			this._companyTelNo2 = companyTelNo2;
			this._companyTelNo3 = companyTelNo3;
			this._companyTelTitle1 = companyTelTitle1;
			this._companyTelTitle2 = companyTelTitle2;
			this._companyTelTitle3 = companyTelTitle3;
			this._transferGuidance = transferGuidance;
			this._accountNoInfo1 = accountNoInfo1;
			this._accountNoInfo2 = accountNoInfo2;
			this._accountNoInfo3 = accountNoInfo3;
			this._companySetNote1 = companySetNote1;
			this._companySetNote2 = companySetNote2;
			this._imageInfoDiv = imageInfoDiv;
			this._imageInfoCode = imageInfoCode;
			this._companyUrl = companyUrl;
			this._companyPrSentence2 = companyPrSentence2;
			this._imageCommentForPrt1 = imageCommentForPrt1;
			this._imageCommentForPrt2 = imageCommentForPrt2;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// ���Ж��̃}�X�^��������
		/// </summary>
		/// <returns>CompanyNm�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CompanyNm�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public CompanyNm Clone()
		{
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            return new CompanyNm(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._companyNameCd, this._companyPr, this._companyName1, this._companyName2, this._postNo, this._address1, this._address2, this._address3, this._address4, this._companyTelNo1, this._companyTelNo2, this._companyTelNo3, this._companyTelTitle1, this._companyTelTitle2, this._companyTelTitle3, this._transferGuidance, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._companySetNote1, this._companySetNote2, this._imageInfoDiv, this._imageInfoCode, this._companyUrl, this._companyPrSentence2, this._imageCommentForPrt1, this._imageCommentForPrt2, this._enterpriseName, this._updEmployeeName);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            return new CompanyNm(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._companyNameCd, this._companyPr, this._companyName1, this._companyName2, this._postNo, this._address1, this._address3, this._address4, this._companyTelNo1, this._companyTelNo2, this._companyTelNo3, this._companyTelTitle1, this._companyTelTitle2, this._companyTelTitle3, this._transferGuidance, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._companySetNote1, this._companySetNote2, this._imageInfoDiv, this._imageInfoCode, this._companyUrl, this._companyPrSentence2, this._imageCommentForPrt1, this._imageCommentForPrt2, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// ���Ж��̃}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CompanyNm�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyNm�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(CompanyNm target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.CompanyNameCd == target.CompanyNameCd)
				 && (this.CompanyPr == target.CompanyPr)
				 && (this.CompanyName1 == target.CompanyName1)
				 && (this.CompanyName2 == target.CompanyName2)
				 && (this.PostNo == target.PostNo)
				 && (this.Address1 == target.Address1)
                //&& (this.Address2 == target.Address2)  // DEL 2008/06/04
				 && (this.Address3 == target.Address3)
				 && (this.Address4 == target.Address4)
				 && (this.CompanyTelNo1 == target.CompanyTelNo1)
				 && (this.CompanyTelNo2 == target.CompanyTelNo2)
				 && (this.CompanyTelNo3 == target.CompanyTelNo3)
				 && (this.CompanyTelTitle1 == target.CompanyTelTitle1)
				 && (this.CompanyTelTitle2 == target.CompanyTelTitle2)
				 && (this.CompanyTelTitle3 == target.CompanyTelTitle3)
				 && (this.TransferGuidance == target.TransferGuidance)
				 && (this.AccountNoInfo1 == target.AccountNoInfo1)
				 && (this.AccountNoInfo2 == target.AccountNoInfo2)
				 && (this.AccountNoInfo3 == target.AccountNoInfo3)
				 && (this.CompanySetNote1 == target.CompanySetNote1)
				 && (this.CompanySetNote2 == target.CompanySetNote2)
				 && (this.ImageInfoDiv == target.ImageInfoDiv)
				 && (this.ImageInfoCode == target.ImageInfoCode)
				 && (this.CompanyUrl == target.CompanyUrl)
				 && (this.CompanyPrSentence2 == target.CompanyPrSentence2)
				 && (this.ImageCommentForPrt1 == target.ImageCommentForPrt1)
				 && (this.ImageCommentForPrt2 == target.ImageCommentForPrt2)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// ���Ж��̃}�X�^��r����
		/// </summary>
		/// <param name="companyNm1">
		///                    ��r����CompanyNm�N���X�̃C���X�^���X
		/// </param>
		/// <param name="companyNm2">��r����CompanyNm�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyNm�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(CompanyNm companyNm1, CompanyNm companyNm2)
		{
			return ((companyNm1.CreateDateTime == companyNm2.CreateDateTime)
				 && (companyNm1.UpdateDateTime == companyNm2.UpdateDateTime)
				 && (companyNm1.EnterpriseCode == companyNm2.EnterpriseCode)
				 && (companyNm1.FileHeaderGuid == companyNm2.FileHeaderGuid)
				 && (companyNm1.UpdEmployeeCode == companyNm2.UpdEmployeeCode)
				 && (companyNm1.UpdAssemblyId1 == companyNm2.UpdAssemblyId1)
				 && (companyNm1.UpdAssemblyId2 == companyNm2.UpdAssemblyId2)
				 && (companyNm1.LogicalDeleteCode == companyNm2.LogicalDeleteCode)
				 && (companyNm1.CompanyNameCd == companyNm2.CompanyNameCd)
				 && (companyNm1.CompanyPr == companyNm2.CompanyPr)
				 && (companyNm1.CompanyName1 == companyNm2.CompanyName1)
				 && (companyNm1.CompanyName2 == companyNm2.CompanyName2)
				 && (companyNm1.PostNo == companyNm2.PostNo)
				 && (companyNm1.Address1 == companyNm2.Address1)
                //&& (companyNm1.Address2 == companyNm2.Address2)  // DEL 2008/06/04
				 && (companyNm1.Address3 == companyNm2.Address3)
				 && (companyNm1.Address4 == companyNm2.Address4)
				 && (companyNm1.CompanyTelNo1 == companyNm2.CompanyTelNo1)
				 && (companyNm1.CompanyTelNo2 == companyNm2.CompanyTelNo2)
				 && (companyNm1.CompanyTelNo3 == companyNm2.CompanyTelNo3)
				 && (companyNm1.CompanyTelTitle1 == companyNm2.CompanyTelTitle1)
				 && (companyNm1.CompanyTelTitle2 == companyNm2.CompanyTelTitle2)
				 && (companyNm1.CompanyTelTitle3 == companyNm2.CompanyTelTitle3)
				 && (companyNm1.TransferGuidance == companyNm2.TransferGuidance)
				 && (companyNm1.AccountNoInfo1 == companyNm2.AccountNoInfo1)
				 && (companyNm1.AccountNoInfo2 == companyNm2.AccountNoInfo2)
				 && (companyNm1.AccountNoInfo3 == companyNm2.AccountNoInfo3)
				 && (companyNm1.CompanySetNote1 == companyNm2.CompanySetNote1)
				 && (companyNm1.CompanySetNote2 == companyNm2.CompanySetNote2)
				 && (companyNm1.ImageInfoDiv == companyNm2.ImageInfoDiv)
				 && (companyNm1.ImageInfoCode == companyNm2.ImageInfoCode)
				 && (companyNm1.CompanyUrl == companyNm2.CompanyUrl)
				 && (companyNm1.CompanyPrSentence2 == companyNm2.CompanyPrSentence2)
				 && (companyNm1.ImageCommentForPrt1 == companyNm2.ImageCommentForPrt1)
				 && (companyNm1.ImageCommentForPrt2 == companyNm2.ImageCommentForPrt2)
				 && (companyNm1.EnterpriseName == companyNm2.EnterpriseName)
				 && (companyNm1.UpdEmployeeName == companyNm2.UpdEmployeeName));
		}
		/// <summary>
		/// ���Ж��̃}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�CompanyNm�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyNm�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(CompanyNm target)
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
			if(this.CompanyNameCd != target.CompanyNameCd)resList.Add("CompanyNameCd");
			if(this.CompanyPr != target.CompanyPr)resList.Add("CompanyPr");
			if(this.CompanyName1 != target.CompanyName1)resList.Add("CompanyName1");
			if(this.CompanyName2 != target.CompanyName2)resList.Add("CompanyName2");
			if(this.PostNo != target.PostNo)resList.Add("PostNo");
			if(this.Address1 != target.Address1)resList.Add("Address1");
            //if(this.Address2 != target.Address2)resList.Add("Address2");  // DEL 2008/06/04
			if(this.Address3 != target.Address3)resList.Add("Address3");
			if(this.Address4 != target.Address4)resList.Add("Address4");
			if(this.CompanyTelNo1 != target.CompanyTelNo1)resList.Add("CompanyTelNo1");
			if(this.CompanyTelNo2 != target.CompanyTelNo2)resList.Add("CompanyTelNo2");
			if(this.CompanyTelNo3 != target.CompanyTelNo3)resList.Add("CompanyTelNo3");
			if(this.CompanyTelTitle1 != target.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
			if(this.CompanyTelTitle2 != target.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
			if(this.CompanyTelTitle3 != target.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
			if(this.TransferGuidance != target.TransferGuidance)resList.Add("TransferGuidance");
			if(this.AccountNoInfo1 != target.AccountNoInfo1)resList.Add("AccountNoInfo1");
			if(this.AccountNoInfo2 != target.AccountNoInfo2)resList.Add("AccountNoInfo2");
			if(this.AccountNoInfo3 != target.AccountNoInfo3)resList.Add("AccountNoInfo3");
			if(this.CompanySetNote1 != target.CompanySetNote1)resList.Add("CompanySetNote1");
			if(this.CompanySetNote2 != target.CompanySetNote2)resList.Add("CompanySetNote2");
			if(this.ImageInfoDiv != target.ImageInfoDiv)resList.Add("ImageInfoDiv");
			if(this.ImageInfoCode != target.ImageInfoCode)resList.Add("ImageInfoCode");
			if(this.CompanyUrl != target.CompanyUrl)resList.Add("CompanyUrl");
			if(this.CompanyPrSentence2 != target.CompanyPrSentence2)resList.Add("CompanyPrSentence2");
			if(this.ImageCommentForPrt1 != target.ImageCommentForPrt1)resList.Add("ImageCommentForPrt1");
			if(this.ImageCommentForPrt2 != target.ImageCommentForPrt2)resList.Add("ImageCommentForPrt2");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// ���Ж��̃}�X�^��r����
		/// </summary>
		/// <param name="companyNm1">��r����CompanyNm�N���X�̃C���X�^���X</param>
		/// <param name="companyNm2">��r����CompanyNm�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   CompanyNm�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(CompanyNm companyNm1, CompanyNm companyNm2)
		{
			ArrayList resList = new ArrayList();
			if(companyNm1.CreateDateTime != companyNm2.CreateDateTime)resList.Add("CreateDateTime");
			if(companyNm1.UpdateDateTime != companyNm2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(companyNm1.EnterpriseCode != companyNm2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(companyNm1.FileHeaderGuid != companyNm2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(companyNm1.UpdEmployeeCode != companyNm2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(companyNm1.UpdAssemblyId1 != companyNm2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(companyNm1.UpdAssemblyId2 != companyNm2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(companyNm1.LogicalDeleteCode != companyNm2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(companyNm1.CompanyNameCd != companyNm2.CompanyNameCd)resList.Add("CompanyNameCd");
			if(companyNm1.CompanyPr != companyNm2.CompanyPr)resList.Add("CompanyPr");
			if(companyNm1.CompanyName1 != companyNm2.CompanyName1)resList.Add("CompanyName1");
			if(companyNm1.CompanyName2 != companyNm2.CompanyName2)resList.Add("CompanyName2");
			if(companyNm1.PostNo != companyNm2.PostNo)resList.Add("PostNo");
			if(companyNm1.Address1 != companyNm2.Address1)resList.Add("Address1");
            //if(companyNm1.Address2 != companyNm2.Address2)resList.Add("Address2");  // DEL 2008/06/04
			if(companyNm1.Address3 != companyNm2.Address3)resList.Add("Address3");
			if(companyNm1.Address4 != companyNm2.Address4)resList.Add("Address4");
			if(companyNm1.CompanyTelNo1 != companyNm2.CompanyTelNo1)resList.Add("CompanyTelNo1");
			if(companyNm1.CompanyTelNo2 != companyNm2.CompanyTelNo2)resList.Add("CompanyTelNo2");
			if(companyNm1.CompanyTelNo3 != companyNm2.CompanyTelNo3)resList.Add("CompanyTelNo3");
			if(companyNm1.CompanyTelTitle1 != companyNm2.CompanyTelTitle1)resList.Add("CompanyTelTitle1");
			if(companyNm1.CompanyTelTitle2 != companyNm2.CompanyTelTitle2)resList.Add("CompanyTelTitle2");
			if(companyNm1.CompanyTelTitle3 != companyNm2.CompanyTelTitle3)resList.Add("CompanyTelTitle3");
			if(companyNm1.TransferGuidance != companyNm2.TransferGuidance)resList.Add("TransferGuidance");
			if(companyNm1.AccountNoInfo1 != companyNm2.AccountNoInfo1)resList.Add("AccountNoInfo1");
			if(companyNm1.AccountNoInfo2 != companyNm2.AccountNoInfo2)resList.Add("AccountNoInfo2");
			if(companyNm1.AccountNoInfo3 != companyNm2.AccountNoInfo3)resList.Add("AccountNoInfo3");
			if(companyNm1.CompanySetNote1 != companyNm2.CompanySetNote1)resList.Add("CompanySetNote1");
			if(companyNm1.CompanySetNote2 != companyNm2.CompanySetNote2)resList.Add("CompanySetNote2");
			if(companyNm1.ImageInfoDiv != companyNm2.ImageInfoDiv)resList.Add("ImageInfoDiv");
			if(companyNm1.ImageInfoCode != companyNm2.ImageInfoCode)resList.Add("ImageInfoCode");
			if(companyNm1.CompanyUrl != companyNm2.CompanyUrl)resList.Add("CompanyUrl");
			if(companyNm1.CompanyPrSentence2 != companyNm2.CompanyPrSentence2)resList.Add("CompanyPrSentence2");
			if(companyNm1.ImageCommentForPrt1 != companyNm2.ImageCommentForPrt1)resList.Add("ImageCommentForPrt1");
			if(companyNm1.ImageCommentForPrt2 != companyNm2.ImageCommentForPrt2)resList.Add("ImageCommentForPrt2");
			if(companyNm1.EnterpriseName != companyNm2.EnterpriseName)resList.Add("EnterpriseName");
			if(companyNm1.UpdEmployeeName != companyNm2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
