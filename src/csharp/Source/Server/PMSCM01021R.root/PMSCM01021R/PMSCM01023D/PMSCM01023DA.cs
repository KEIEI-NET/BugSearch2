//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�֘A�f�[�^�f�[�^�p�����[�^
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :   �����ڒǉ�
//                        �L�����Z���敪 
//                        CMT�A�g�敪
// Programmer       :   21024 ���X�� ��
// Date             :   2010/05/26
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{

    # region delete
    /*                                
	/// public class name:   SCMAcOdrDataWork
    ///
	/// <summary>
	///                      SCM�󒍃f�[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󒍃f�[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/04/30</br>
	/// <br>Genarated Date   :   2009/05/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/18  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �󒍃X�e�[�^�X</br>
	/// <br>                 :   ����`�[�ԍ�</br>
	/// <br>                 :   ����`�[���v�i�ō��݁j</br>
	/// <br>                 :   ���㏬�v�i�Łj</br>
	/// <br>Update Note      :   2009/05/26  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   ������</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �⍇���E�������</br>
	/// <br>                 :   �┭�E�񓚎��</br>
	/// <br>                 :   ��M����</br>
	/// <br>Update Note      :   2009/05/29  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �񓚍쐬�敪</br>
    /// <br></br>
    /// <br>Update Note      :   2010/05/26  21024 ���X��</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �L�����Z���敪</br>
    /// <br>                 :   CMT�A�g�敪</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDataWork : IFileHeader
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

		/// <summary>�⍇������ƃR�[�h</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>�⍇�������_�R�[�h</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>�⍇�����ƃR�[�h</summary>
		private string _inqOtherEpCd = "";

		/// <summary>�⍇���拒�_�R�[�h</summary>
		private string _inqOtherSecCd = "";

		/// <summary>�⍇���ԍ�</summary>
		private Int64 _inquiryNumber;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V����</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�񓚋敪</summary>
		/// <remarks>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
		private Int32 _answerDivCd;

		/// <summary>�m���</summary>
		/// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
		private DateTime _judgementDate;

		/// <summary>�⍇���E�������l</summary>
		private string _inqOrdNote = "";

		/// <summary>�Y�t�t�@�C��</summary>
		private Byte[] _appendingFile = new Byte[0];

		/// <summary>�Y�t�t�@�C����</summary>
		private string _appendingFileNm = "";

		/// <summary>�⍇���]�ƈ��R�[�h</summary>
		/// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>�⍇���]�ƈ�����</summary>
		/// <remarks>�⍇�������]�ƈ�����</remarks>
		private string _inqEmployeeNm = "";

		/// <summary>�񓚏]�ƈ��R�[�h</summary>
		private string _ansEmployeeCd = "";

		/// <summary>�񓚏]�ƈ�����</summary>
		private string _ansEmployeeNm = "";

		/// <summary>�⍇����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _inquiryDate;

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _salesSlipNum = "";

		/// <summary>����`�[���v�i�ō��݁j</summary>
		/// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>���㏬�v�i�Łj</summary>
		/// <remarks>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</remarks>
		private Int64 _salesSubtotalTax;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�┭�E�񓚎��</summary>
		/// <remarks>1:�⍇���E���� 2:��</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>��M����</summary>
		/// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _receiveDateTime;

		/// <summary>�񓚍쐬�敪</summary>
		/// <remarks>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</remarks>
		private Int32 _answerCreateDiv;

        // 2010/05/26 Add >>>
        /// <summary>�L�����Z���敪</summary>
        /// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
        private Int16 _cancelDiv;

        /// <summary>CMT�A�g�敪</summary>
        /// <remarks>0:�A�g�Ȃ� 1:�A�g����</remarks>
        private Int16 _cMTCooprtDiv;
        // 2010/05/26 Add <<<

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

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  InqOtherEpCd
		/// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  InquiryNumber
		/// <summary>�⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>�X�V�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>�X�V���ԃv���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>�񓚋敪�v���p�e�B</summary>
		/// <value>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerDivCd
		{
			get{return _answerDivCd;}
			set{_answerDivCd = value;}
		}

		/// public propaty name  :  JudgementDate
		/// <summary>�m����v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime JudgementDate
		{
			get{return _judgementDate;}
			set{_judgementDate = value;}
		}

		/// public propaty name  :  InqOrdNote
		/// <summary>�⍇���E�������l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E�������l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOrdNote
		{
			get{return _inqOrdNote;}
			set{_inqOrdNote = value;}
		}

		/// public propaty name  :  AppendingFile
		/// <summary>�Y�t�t�@�C���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Byte[] AppendingFile
		{
			get{return _appendingFile;}
			set{_appendingFile = value;}
		}

		/// public propaty name  :  AppendingFileNm
		/// <summary>�Y�t�t�@�C�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AppendingFileNm
		{
			get{return _appendingFileNm;}
			set{_appendingFileNm = value;}
		}

		/// public propaty name  :  InqEmployeeCd
		/// <summary>�⍇���]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>�⍇�������]�ƈ��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqEmployeeCd
		{
			get{return _inqEmployeeCd;}
			set{_inqEmployeeCd = value;}
		}

		/// public propaty name  :  InqEmployeeNm
		/// <summary>�⍇���]�ƈ����̃v���p�e�B</summary>
		/// <value>�⍇�������]�ƈ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqEmployeeNm
		{
			get{return _inqEmployeeNm;}
			set{_inqEmployeeNm = value;}
		}

		/// public propaty name  :  AnsEmployeeCd
		/// <summary>�񓚏]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeCd
		{
			get{return _ansEmployeeCd;}
			set{_ansEmployeeCd = value;}
		}

		/// public propaty name  :  AnsEmployeeNm
		/// <summary>�񓚏]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeNm
		{
			get{return _ansEmployeeNm;}
			set{_ansEmployeeNm = value;}
		}

		/// public propaty name  :  InquiryDate
		/// <summary>�⍇�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InquiryDate
		{
			get{return _inquiryDate;}
			set{_inquiryDate = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
		/// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
		}

		/// public propaty name  :  SalesSubtotalTax
		/// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
		/// <value>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesSubtotalTax
		{
			get{return _salesSubtotalTax;}
			set{_salesSubtotalTax = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>�⍇���E������ʃv���p�e�B</summary>
		/// <value>1:�⍇�� 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>�┭�E�񓚎�ʃv���p�e�B</summary>
		/// <value>1:�⍇���E���� 2:��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�E�񓚎�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get{return _inqOrdAnsDivCd;}
			set{_inqOrdAnsDivCd = value;}
		}

		/// public propaty name  :  ReceiveDateTime
		/// <summary>��M�����v���p�e�B</summary>
		/// <value>�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime ReceiveDateTime
		{
			get{return _receiveDateTime;}
			set{_receiveDateTime = value;}
		}

		/// public propaty name  :  AnswerCreateDiv
		/// <summary>�񓚍쐬�敪�v���p�e�B</summary>
		/// <value>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚍쐬�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerCreateDiv
		{
			get{return _answerCreateDiv;}
			set{_answerCreateDiv = value;}
		}

        // 2010/05/26 Add >>>
        /// public propaty name  :  CancelDiv
        /// <summary>�L�����Z���敪�v���p�e�B</summary>
        /// <value>0:�L�����Z���Ȃ� 1:�L�����Z������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����Z���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 CancelDiv
        {
            get { return _cancelDiv; }
            set { _cancelDiv = value; }
        }

        /// public propaty name  :  CMTCooprtDiv
        /// <summary>CMT�A�g�敪�v���p�e�B</summary>
        /// <value>0:�A�g�Ȃ� 1:�A�g����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   CMT�A�g�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 CMTCooprtDiv
        {
            get { return _cMTCooprtDiv; }
            set { _cMTCooprtDiv = value; }
        }
        // 2010/05/26 Add <<<

		/// <summary>
		/// SCM�󒍃f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAcOdrDataWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrDataWork()
		{
		}

	}
*/

    # endregion

	/// public class name:   SCMAcOdrDataWork
	/// <summary>
	///                      SCM�󒍃f�[�^���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�󒍃f�[�^���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/04/30</br>
	/// <br>Genarated Date   :   2011/05/20  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/18  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �󒍃X�e�[�^�X</br>
	/// <br>                 :   ����`�[�ԍ�</br>
	/// <br>                 :   ����`�[���v�i�ō��݁j</br>
	/// <br>                 :   ���㏬�v�i�Łj</br>
	/// <br>Update Note      :   2009/05/26  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   ������</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �⍇���E�������</br>
	/// <br>                 :   �┭�E�񓚎��</br>
	/// <br>                 :   ��M����</br>
	/// <br>Update Note      :   2009/05/29  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �񓚍쐬�敪</br>
	/// <br>Update Note      :   2009/06/15  ����</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,11,13,14,15,17,18��3,9,11,13,14,15,17,18,29,30</br>
	/// <br>Update Note      :   2009/06/16  ����</br>
	/// <br>                 :   �����ڍ폜</br>
	/// <br>                 :   �⍇������Ɩ���</br>
	/// <br>                 :   �⍇�������_����</br>
	/// <br>                 :   �������ύX</br>
	/// <br>                 :   �⍇�������_�R�[�h�@16��6</br>
	/// <br>                 :   ���L�[�ύX</br>
	/// <br>                 :   3,9,11,13,14,15,17,18,29,30��3,9,10,11,12,13,15,16,27,28</br>
	/// <br>Update Note      :   2010/05/25  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   �L�����Z���敪</br>
	/// <br>                 :   CMT�A�g�敪</br>
	/// <br>Update Note      :   2011/2/17  ����</br>
	/// <br>                 :   ��CMT�A�g�敪�⑫ �C��</br>
	/// <br>                 :   11:�⍇�������� 12:���������񓚂�ǉ�</br>
	/// <br>Update Note      :   2011/5/19  ����</br>
	/// <br>                 :   �����ڒǉ�</br>
	/// <br>                 :   SF-PM�A�g�w�����ԍ�</br>
    /// <br>Update Note      :   2011/08/10 ����</br>
    /// <br>			     :   PCCUOE�����񓚑Ή�</br>
    /// <br>Update Note      :   2012/04/12 30745 �g�� �F��</br>
    /// <br>			     :   ��QNo170 PS�Ǘ��ԍ����ڒǉ�</br>
    /// <br>Update Note      :   2013/05/24  30747 �O�� �L��</br>
    /// <br>                 :   2013/06/18�z�M�� SCM��Q��10536�Ή�</br>
    /// <br>                 :   �^�u���b�g�g�p�敪�ǉ�</br>
    /// <br>Update Note      :   2012/05/24 30744 ���� ����q</br>
    /// <br>			     :   SCM��QNo10537�Ή� �ԗ��Ǘ��R�[�h�ǉ�</br>
    /// <br>Update Note      :   2014/12/19 30744 ���� ����q</br>
    /// <br>                 :   �Ǘ��ԍ� 11070266-00</br>
    /// <br>			     :   SCM������ PMNS�Ή� �����񓚕����̒ǉ�</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDataWork : IFileHeader
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

		/// <summary>�⍇������ƃR�[�h</summary>
		private string _inqOriginalEpCd = "";

		/// <summary>�⍇�������_�R�[�h</summary>
		private string _inqOriginalSecCd = "";

		/// <summary>�⍇�����ƃR�[�h</summary>
		private string _inqOtherEpCd = "";

		/// <summary>�⍇���拒�_�R�[�h</summary>
		private string _inqOtherSecCd = "";

		/// <summary>�⍇���ԍ�</summary>
		private Int64 _inquiryNumber;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>�X�V�N����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _updateDate;

		/// <summary>�X�V����</summary>
		/// <remarks>HHMMSSXXX</remarks>
		private Int32 _updateTime;

		/// <summary>�񓚋敪</summary>
		/// <remarks>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</remarks>
		private Int32 _answerDivCd;

		/// <summary>�m���</summary>
		/// <remarks>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</remarks>
		private DateTime _judgementDate;

		/// <summary>�⍇���E�������l</summary>
		private string _inqOrdNote = "";

		/// <summary>�Y�t�t�@�C��</summary>
        private Byte[] _appendingFile = new Byte[0];

		/// <summary>�Y�t�t�@�C����</summary>
		private string _appendingFileNm = "";

		/// <summary>�⍇���]�ƈ��R�[�h</summary>
		/// <remarks>�⍇�������]�ƈ��R�[�h</remarks>
		private string _inqEmployeeCd = "";

		/// <summary>�⍇���]�ƈ�����</summary>
		/// <remarks>�⍇�������]�ƈ�����</remarks>
		private string _inqEmployeeNm = "";

		/// <summary>�񓚏]�ƈ��R�[�h</summary>
		private string _ansEmployeeCd = "";

		/// <summary>�񓚏]�ƈ�����</summary>
		private string _ansEmployeeNm = "";

		/// <summary>�⍇����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _inquiryDate;

		/// <summary>�󒍃X�e�[�^�X</summary>
		/// <remarks>10:����,20:��,30:����</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>����`�[�ԍ�</summary>
		/// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
		private string _salesSlipNum = "";

		/// <summary>����`�[���v�i�ō��݁j</summary>
		/// <remarks>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</remarks>
		private Int64 _salesTotalTaxInc;

		/// <summary>���㏬�v�i�Łj</summary>
		/// <remarks>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</remarks>
		private Int64 _salesSubtotalTax;

		/// <summary>�⍇���E�������</summary>
		/// <remarks>1:�⍇�� 2:����</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>�┭�E�񓚎��</summary>
		/// <remarks>1:�⍇���E���� 2:��</remarks>
		private Int32 _inqOrdAnsDivCd;

		/// <summary>��M����</summary>
		/// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _receiveDateTime;

		/// <summary>�񓚍쐬�敪</summary>
		/// <remarks>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</remarks>
		private Int32 _answerCreateDiv;

		/// <summary>�L�����Z���敪</summary>
		/// <remarks>0:�L�����Z���Ȃ� 1:�L�����Z������</remarks>
		private Int16 _cancelDiv;

		/// <summary>CMT�A�g�敪</summary>
		/// <remarks>0:�A�g�Ȃ� 1:�A�g���� 11:�⍇�������� 12:����������</remarks>
		private Int16 _cMTCooprtDiv;

		/// <summary>SF-PM�A�g�w�����ԍ�</summary>
		/// <remarks>���Ӑ撍��</remarks>
		private string _sfPmCprtInstSlipNo = "";

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>PM���݌ɐ�</summary>
        /// <remarks>PM���݌ɐ�</remarks>
        private double _pmPrsntCount;

        /// <summary>�Z�b�g���i���[�J�[�R�[�h</summary>
        /// <remarks>�Z�b�g���i���[�J�[�R�[�h</remarks>
        private Int32 _setPartsMkrCd;

        /// <summary>�Z�b�g���i�ԍ�</summary>
        /// <remarks>�Z�b�g���i�ԍ�</remarks>
        private String _setPartsNumber;

        /// <summary>�Z�b�g���i�e�q�ԍ�</summary>
        /// <remarks>�Z�b�g���i�e�q�ԍ�</remarks>
        private Int32 _setPartsMainSubNo;
        // -- ADD 2011/08/10   ------ <<<<<<

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>�󔭒����</summary>
        /// <remarks>0:�ʏ�,1:PCC-UOE</remarks>
        private Int16 _acceptOrOrderKind;
        // -- ADD 2011/08/10   ------ <<<<<<
        // 2012/04/12 Add >>> 
        /// <summary>PS�Ǘ��ԍ�</summary>
        private Int32 _psMngNo;
        // 2012/04/12 Add <<<

        // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�^�u���b�g�g�p�敪</summary>
        /// <remarks>0�F�g�p���Ȃ�,1�F�g�p����</remarks>
        private Int32 _tabUseDiv;
        // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
        /// <summary>�ԗ��Ǘ��R�[�h</summary>
        private string _carMngCode = "";
        // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// <summary>�����񓚕���</summary>
        private Int16 _autoAnsMthd;
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<

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

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
		}

		/// public propaty name  :  InqOriginalSecCd
		/// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOriginalSecCd
		{
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
		}

		/// public propaty name  :  InqOtherEpCd
		/// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherEpCd
		{
			get{return _inqOtherEpCd;}
			set{_inqOtherEpCd = value;}
		}

		/// public propaty name  :  InqOtherSecCd
		/// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOtherSecCd
		{
			get{return _inqOtherSecCd;}
			set{_inqOtherSecCd = value;}
		}

		/// public propaty name  :  InquiryNumber
		/// <summary>�⍇���ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 InquiryNumber
		{
			get{return _inquiryNumber;}
			set{_inquiryNumber = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _customerCode;}
			set{_customerCode = value;}
		}

		/// public propaty name  :  UpdateDate
		/// <summary>�X�V�N�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�N�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDate
		{
			get{return _updateDate;}
			set{_updateDate = value;}
		}

		/// public propaty name  :  UpdateTime
		/// <summary>�X�V���ԃv���p�e�B</summary>
		/// <value>HHMMSSXXX</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UpdateTime
		{
			get{return _updateTime;}
			set{_updateTime = value;}
		}

		/// public propaty name  :  AnswerDivCd
		/// <summary>�񓚋敪�v���p�e�B</summary>
		/// <value>0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerDivCd
		{
			get{return _answerDivCd;}
			set{_answerDivCd = value;}
		}

		/// public propaty name  :  JudgementDate
		/// <summary>�m����v���p�e�B</summary>
		/// <value>YYYYMMDD     �o�r�e�ɂĎg�p����B������I���������B�`�[���b�N�ɂ��g�p����B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �m����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime JudgementDate
		{
			get{return _judgementDate;}
			set{_judgementDate = value;}
		}

		/// public propaty name  :  InqOrdNote
		/// <summary>�⍇���E�������l�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E�������l�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqOrdNote
		{
			get{return _inqOrdNote;}
			set{_inqOrdNote = value;}
		}

		/// public propaty name  :  AppendingFile
		/// <summary>�Y�t�t�@�C���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public Byte[] AppendingFile
		{
			get{return _appendingFile;}
			set{_appendingFile = value;}
		}

		/// public propaty name  :  AppendingFileNm
		/// <summary>�Y�t�t�@�C�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �Y�t�t�@�C�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AppendingFileNm
		{
			get{return _appendingFileNm;}
			set{_appendingFileNm = value;}
		}

		/// public propaty name  :  InqEmployeeCd
		/// <summary>�⍇���]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>�⍇�������]�ƈ��R�[�h</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqEmployeeCd
		{
			get{return _inqEmployeeCd;}
			set{_inqEmployeeCd = value;}
		}

		/// public propaty name  :  InqEmployeeNm
		/// <summary>�⍇���]�ƈ����̃v���p�e�B</summary>
		/// <value>�⍇�������]�ƈ�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InqEmployeeNm
		{
			get{return _inqEmployeeNm;}
			set{_inqEmployeeNm = value;}
		}

		/// public propaty name  :  AnsEmployeeCd
		/// <summary>�񓚏]�ƈ��R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeCd
		{
			get{return _ansEmployeeCd;}
			set{_ansEmployeeCd = value;}
		}

		/// public propaty name  :  AnsEmployeeNm
		/// <summary>�񓚏]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚏]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string AnsEmployeeNm
		{
			get{return _ansEmployeeNm;}
			set{_ansEmployeeNm = value;}
		}

		/// public propaty name  :  InquiryDate
		/// <summary>�⍇�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InquiryDate
		{
			get{return _inquiryDate;}
			set{_inquiryDate = value;}
		}

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
		/// <value>10:����,20:��,30:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcptAnOdrStatus
		{
			get{return _acptAnOdrStatus;}
			set{_acptAnOdrStatus = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>����`�[�ԍ��v���p�e�B</summary>
		/// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  SalesTotalTaxInc
		/// <summary>����`�[���v�i�ō��݁j�v���p�e�B</summary>
		/// <value>���㐳�����z�{����l�����z�v�i�Ŕ����j�{������z����Ŋz</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���v�i�ō��݁j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesTotalTaxInc
		{
			get{return _salesTotalTaxInc;}
			set{_salesTotalTaxInc = value;}
		}

		/// public propaty name  :  SalesSubtotalTax
		/// <summary>���㏬�v�i�Łj�v���p�e�B</summary>
		/// <value>�l����̐Ŋz�i�O�ŕ��A���ŕ��̍��v�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���㏬�v�i�Łj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 SalesSubtotalTax
		{
			get{return _salesSubtotalTax;}
			set{_salesSubtotalTax = value;}
		}

		/// public propaty name  :  InqOrdDivCd
		/// <summary>�⍇���E������ʃv���p�e�B</summary>
		/// <value>1:�⍇�� 2:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �⍇���E������ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdDivCd
		{
			get{return _inqOrdDivCd;}
			set{_inqOrdDivCd = value;}
		}

		/// public propaty name  :  InqOrdAnsDivCd
		/// <summary>�┭�E�񓚎�ʃv���p�e�B</summary>
		/// <value>1:�⍇���E���� 2:��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �┭�E�񓚎�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InqOrdAnsDivCd
		{
			get{return _inqOrdAnsDivCd;}
			set{_inqOrdAnsDivCd = value;}
		}

		/// public propaty name  :  ReceiveDateTime
		/// <summary>��M�����v���p�e�B</summary>
		/// <value>�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime ReceiveDateTime
		{
			get{return _receiveDateTime;}
			set{_receiveDateTime = value;}
		}

		/// public propaty name  :  AnswerCreateDiv
		/// <summary>�񓚍쐬�敪�v���p�e�B</summary>
		/// <value>0:����, 1:�蓮�iWeb�j, 2:�蓮�i���̑��j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �񓚍쐬�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AnswerCreateDiv
		{
			get{return _answerCreateDiv;}
			set{_answerCreateDiv = value;}
		}

		/// public propaty name  :  CancelDiv
		/// <summary>�L�����Z���敪�v���p�e�B</summary>
		/// <value>0:�L�����Z���Ȃ� 1:�L�����Z������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �L�����Z���敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 CancelDiv
		{
			get{return _cancelDiv;}
			set{_cancelDiv = value;}
		}

		/// public propaty name  :  CMTCooprtDiv
		/// <summary>CMT�A�g�敪�v���p�e�B</summary>
		/// <value>0:�A�g�Ȃ� 1:�A�g���� 11:�⍇�������� 12:����������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   CMT�A�g�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int16 CMTCooprtDiv
		{
			get{return _cMTCooprtDiv;}
			set{_cMTCooprtDiv = value;}
		}

		/// public propaty name  :  SfPmCprtInstSlipNo
		/// <summary>SF-PM�A�g�w�����ԍ��v���p�e�B</summary>
		/// <value>���Ӑ撍��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   SF-PM�A�g�w�����ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SfPmCprtInstSlipNo
		{
			get{return _sfPmCprtInstSlipNo;}
			set{_sfPmCprtInstSlipNo = value;}
		}

        // -- ADD 2011/08/10   ------ >>>>>>
        /// public propaty name  :  PmPrsntCount
        /// <summary>PM���݌ɐ��v���p�e�B</summary>
        /// <value>PM���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM���݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double PmPrsntCount
        {
            get { return _pmPrsntCount; }
            set { _pmPrsntCount = value; }
        }

        /// public propaty name  :  SetPartsMkrCd
        /// <summary>�Z�b�g���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�Z�b�g���i���[�J�[�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetPartsMkrCd
        {
            get { return _setPartsMkrCd; }
            set { _setPartsMkrCd = value; }
        }

        /// public propaty name  :  SetPartsNumber
        /// <summary>�Z�b�g���i�ԍ��v���p�e�B</summary>
        /// <value>�Z�b�g���i�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public String SetPartsNumber
        {
            get { return _setPartsNumber; }
            set { _setPartsNumber = value; }
        }

        /// public propaty name  :  AcceptOrOrderKind
        /// <summary>�Z�b�g���i�e�q�ԍ��v���p�e�B</summary>
        /// <value>�Z�b�g���i�e�q�ԍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g���i�e�q�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetPartsMainSubNo
        {
            get { return _setPartsMainSubNo; }
            set { _setPartsMainSubNo = value; }
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        // -- ADD 2011/08/10   ------ >>>>>>
        /// public propaty name  :  AcceptOrOrderKind
        /// <summary>�󔭒���ʃv���p�e�B</summary>
        /// <value>0:�ʏ�,1:PCC-UOE</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󔭒���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        // 2012/04/12 Add >>> 
        /// public propaty name  :  PSMngNo
        /// <summary>PS�Ǘ��ԍ�</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PS�Ǘ��ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PSMngNo
        {
            get { return _psMngNo; }
            set { _psMngNo = value; }
        }
        // 2012/04/12 Add <<<

        // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  TabUseDiv
        /// <summary>�^�u���b�g�g�p�敪</summary>
        /// <value>0�F�g�p���Ȃ�,1�F�g�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�u���b�g�g�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TabUseDiv
        {
            get { return _tabUseDiv; }
            set { _tabUseDiv = value; }
        }
        // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
        /// public propaty name  :  CarMngCode
        /// <summary>�ԗ��Ǘ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ��Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCode
        {
            get { return _carMngCode; }
            set { _carMngCode = value; }
        }
        // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<

        // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        /// public propaty name  :  AutoAnsMthd
        /// <summary>�����񓚕����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚕����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 AutoAnsMthd
        {
            get { return _autoAnsMthd; }
            set { _autoAnsMthd = value; }
        }
        // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<


		/// <summary>
		/// SCM�󒍃f�[�^���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>SCMAcOdrDataWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMAcOdrDataWork()
		{
		}

	}

# region delete
/*
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMAcOdrDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMAcOdrDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMAcOdrDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMAcOdrDataWork || graph is ArrayList || graph is SCMAcOdrDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMAcOdrDataWork).FullName));

            if (graph != null && graph is SCMAcOdrDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMAcOdrDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMAcOdrDataWork[])graph).Length;
            }
            else if (graph is SCMAcOdrDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //�⍇������ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //�⍇�������_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //�⍇�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //�⍇���拒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //�⍇���ԍ�
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //�񓚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerDivCd
            //�m���
            serInfo.MemberInfo.Add(typeof(Int32)); //JudgementDate
            //�⍇���E�������l
            serInfo.MemberInfo.Add(typeof(string)); //InqOrdNote
            //�Y�t�t�@�C��
            serInfo.MemberInfo.Add(typeof(Byte[])); //AppendingFile
            //�Y�t�t�@�C����
            serInfo.MemberInfo.Add(typeof(string)); //AppendingFileNm
            //�⍇���]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeCd
            //�⍇���]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //InqEmployeeNm
            //�񓚏]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeCd
            //�񓚏]�ƈ�����
            serInfo.MemberInfo.Add(typeof(string)); //AnsEmployeeNm
            //�⍇����
            serInfo.MemberInfo.Add(typeof(Int32)); //InquiryDate
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //����`�[���v�i�ō��݁j
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesTotalTaxInc
            //���㏬�v�i�Łj
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSubtotalTax
            //�⍇���E�������
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //�┭�E�񓚎��
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdAnsDivCd
            //��M����
            serInfo.MemberInfo.Add(typeof(Int64)); //ReceiveDateTime
            //�񓚍쐬�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AnswerCreateDiv
            // 2010/05/26 Add >>>
            //�L�����Z���敪
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelDiv
            //CMT�A�g�敪
            serInfo.MemberInfo.Add(typeof(Int16)); //CMTCooprtDiv
            // 2010/05/26 Add <<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMAcOdrDataWork)
            {
                SCMAcOdrDataWork temp = (SCMAcOdrDataWork)graph;

                SetSCMAcOdrDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMAcOdrDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMAcOdrDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMAcOdrDataWork temp in lst)
                {
                    SetSCMAcOdrDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMAcOdrDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        // 2010/05/26 >>>
        //private const int currentMemberCount = 34;
        private const int currentMemberCount = 36;
        // 2010/05/16 <<<

        /// <summary>
        ///  SCMAcOdrDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMAcOdrDataWork(System.IO.BinaryWriter writer, SCMAcOdrDataWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd);
            //�⍇�������_�R�[�h
            writer.Write(temp.InqOriginalSecCd);
            //�⍇�����ƃR�[�h
            writer.Write(temp.InqOtherEpCd);
            //�⍇���拒�_�R�[�h
            writer.Write(temp.InqOtherSecCd);
            //�⍇���ԍ�
            writer.Write(temp.InquiryNumber);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //�X�V����
            writer.Write(temp.UpdateTime);
            //�񓚋敪
            writer.Write(temp.AnswerDivCd);
            //�m���
            writer.Write((Int64)temp.JudgementDate.Ticks);
            //�⍇���E�������l
            writer.Write(temp.InqOrdNote);
            //�Y�t�t�@�C��
            writer.Write(temp.AppendingFile.Length);
            writer.Write(temp.AppendingFile);
            //�Y�t�t�@�C����
            writer.Write(temp.AppendingFileNm);
            //�⍇���]�ƈ��R�[�h
            writer.Write(temp.InqEmployeeCd);
            //�⍇���]�ƈ�����
            writer.Write(temp.InqEmployeeNm);
            //�񓚏]�ƈ��R�[�h
            writer.Write(temp.AnsEmployeeCd);
            //�񓚏]�ƈ�����
            writer.Write(temp.AnsEmployeeNm);
            //�⍇����
            writer.Write((Int64)temp.InquiryDate.Ticks);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //����`�[�ԍ�
            writer.Write(temp.SalesSlipNum);
            //����`�[���v�i�ō��݁j
            writer.Write(temp.SalesTotalTaxInc);
            //���㏬�v�i�Łj
            writer.Write(temp.SalesSubtotalTax);
            //�⍇���E�������
            writer.Write(temp.InqOrdDivCd);
            //�┭�E�񓚎��
            writer.Write(temp.InqOrdAnsDivCd);
            //��M����
            writer.Write((Int64)temp.ReceiveDateTime.Ticks);
            //�񓚍쐬�敪
            writer.Write(temp.AnswerCreateDiv);
            // 2010/05/26 Add >>>
            //�L�����Z���敪
            writer.Write(temp.CancelDiv);
            //CMT�A�g�敪
            writer.Write(temp.CMTCooprtDiv);
            // 2010/05/26 Add <<<
        }

        /// <summary>
        ///  SCMAcOdrDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMAcOdrDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMAcOdrDataWork GetSCMAcOdrDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMAcOdrDataWork temp = new SCMAcOdrDataWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString();
            //�⍇�������_�R�[�h
            temp.InqOriginalSecCd = reader.ReadString();
            //�⍇�����ƃR�[�h
            temp.InqOtherEpCd = reader.ReadString();
            //�⍇���拒�_�R�[�h
            temp.InqOtherSecCd = reader.ReadString();
            //�⍇���ԍ�
            temp.InquiryNumber = reader.ReadInt64();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateTime = reader.ReadInt32();
            //�񓚋敪
            temp.AnswerDivCd = reader.ReadInt32();
            //�m���
            temp.JudgementDate = new DateTime(reader.ReadInt64());
            //�⍇���E�������l
            temp.InqOrdNote = reader.ReadString();
            //�Y�t�t�@�C��
            int appendingFileLength = reader.ReadInt32();
            temp.AppendingFile = reader.ReadBytes(appendingFileLength);
            //�Y�t�t�@�C����
            temp.AppendingFileNm = reader.ReadString();
            //�⍇���]�ƈ��R�[�h
            temp.InqEmployeeCd = reader.ReadString();
            //�⍇���]�ƈ�����
            temp.InqEmployeeNm = reader.ReadString();
            //�񓚏]�ƈ��R�[�h
            temp.AnsEmployeeCd = reader.ReadString();
            //�񓚏]�ƈ�����
            temp.AnsEmployeeNm = reader.ReadString();
            //�⍇����
            temp.InquiryDate = new DateTime(reader.ReadInt64());
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //����`�[�ԍ�
            temp.SalesSlipNum = reader.ReadString();
            //����`�[���v�i�ō��݁j
            temp.SalesTotalTaxInc = reader.ReadInt64();
            //���㏬�v�i�Łj
            temp.SalesSubtotalTax = reader.ReadInt64();
            //�⍇���E�������
            temp.InqOrdDivCd = reader.ReadInt32();
            //�┭�E�񓚎��
            temp.InqOrdAnsDivCd = reader.ReadInt32();
            //��M����
            temp.ReceiveDateTime = new DateTime(reader.ReadInt64());
            //�񓚍쐬�敪
            temp.AnswerCreateDiv = reader.ReadInt32();
            // 2010/05/26 Add >>>
            //�L�����Z���敪
            temp.CancelDiv = reader.ReadInt16();
            //CMT�A�g�敪
            temp.CMTCooprtDiv = reader.ReadInt16();
            // 2010/05/26 Add <<<


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SCMAcOdrDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMAcOdrDataWork temp = GetSCMAcOdrDataWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SCMAcOdrDataWork[])lst.ToArray(typeof(SCMAcOdrDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
*/
# endregion

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMAcOdrDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMAcOdrDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate �����o
    	
	    /// <summary>
	    ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  SCMAcOdrDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is SCMAcOdrDataWork || graph is ArrayList || graph is SCMAcOdrDataWork[]) )
			    throw new ArgumentException( string.Format( "graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMAcOdrDataWork).FullName ) );

		    if( graph != null && graph is SCMAcOdrDataWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork" );

		    //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
		    int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is SCMAcOdrDataWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((SCMAcOdrDataWork[])graph).Length;
		    }
		    else if( graph is SCMAcOdrDataWork )
		    {
			    serInfo.RetTypeInfo = 1;
			    occurrence = 1;
		    }

		    serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

		    //�쐬����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
		    //�X�V����
		    serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
		    //��ƃR�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		    //GUID
		    serInfo.MemberInfo.Add( typeof(byte[]) );  //FileHeaderGuid
		    //�X�V�]�ƈ��R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdEmployeeCode
		    //�X�V�A�Z���u��ID1
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId1
		    //�X�V�A�Z���u��ID2
		    serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId2
		    //�_���폜�敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
		    //�⍇������ƃR�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOriginalEpCd
		    //�⍇�������_�R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOriginalSecCd
		    //�⍇�����ƃR�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOtherEpCd
		    //�⍇���拒�_�R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOtherSecCd
		    //�⍇���ԍ�
		    serInfo.MemberInfo.Add( typeof(Int64) ); //InquiryNumber
		    //���Ӑ�R�[�h
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CustomerCode
		    //�X�V�N����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateDate
		    //�X�V����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateTime
		    //�񓚋敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AnswerDivCd
		    //�m���
		    serInfo.MemberInfo.Add( typeof(Int32) ); //JudgementDate
		    //�⍇���E�������l
		    serInfo.MemberInfo.Add( typeof(string) ); //InqOrdNote
		    //�Y�t�t�@�C��
            serInfo.MemberInfo.Add(typeof(Byte[])); //AppendingFile
		    //�Y�t�t�@�C����
		    serInfo.MemberInfo.Add( typeof(string) ); //AppendingFileNm
		    //�⍇���]�ƈ��R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //InqEmployeeCd
		    //�⍇���]�ƈ�����
		    serInfo.MemberInfo.Add( typeof(string) ); //InqEmployeeNm
		    //�񓚏]�ƈ��R�[�h
		    serInfo.MemberInfo.Add( typeof(string) ); //AnsEmployeeCd
		    //�񓚏]�ƈ�����
		    serInfo.MemberInfo.Add( typeof(string) ); //AnsEmployeeNm
		    //�⍇����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InquiryDate
		    //�󒍃X�e�[�^�X
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AcptAnOdrStatus
		    //����`�[�ԍ�
		    serInfo.MemberInfo.Add( typeof(string) ); //SalesSlipNum
		    //����`�[���v�i�ō��݁j
		    serInfo.MemberInfo.Add( typeof(Int64) ); //SalesTotalTaxInc
		    //���㏬�v�i�Łj
		    serInfo.MemberInfo.Add( typeof(Int64) ); //SalesSubtotalTax
		    //�⍇���E�������
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqOrdDivCd
		    //�┭�E�񓚎��
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqOrdAnsDivCd
		    //��M����
		    serInfo.MemberInfo.Add( typeof(Int32) ); //ReceiveDateTime
		    //�񓚍쐬�敪
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AnswerCreateDiv
		    //�L�����Z���敪
		    serInfo.MemberInfo.Add( typeof(Int16) ); //CancelDiv
		    //CMT�A�g�敪
		    serInfo.MemberInfo.Add( typeof(Int16) ); //CMTCooprtDiv
		    //SF-PM�A�g�w�����ԍ�
		    serInfo.MemberInfo.Add( typeof(string) ); //SfPmCprtInstSlipNo
            // -- ADD 2011/08/10   ------ >>>>>>
            //�󔭒����
            serInfo.MemberInfo.Add(typeof(Int16)); //AcceptOrOrderKind
            // -- ADD 2011/08/10   ------ <<<<<<
            // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�^�u���b�g�g�p�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TabUseDiv
            // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
            //�ԗ��Ǘ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //CarMngCode
            // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<

            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            // �����񓚕���
            serInfo.MemberInfo.Add(typeof(Int16));  // AutoAnsMthd
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
	
		    serInfo.Serialize( writer, serInfo );
		    if( graph is SCMAcOdrDataWork )
		    {
			    SCMAcOdrDataWork temp = (SCMAcOdrDataWork)graph;

			    SetSCMAcOdrDataWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is SCMAcOdrDataWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((SCMAcOdrDataWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(SCMAcOdrDataWork temp in lst)
			    {
				    SetSCMAcOdrDataWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// SCMAcOdrDataWork�����o��(public�v���p�e�B��)
	    /// </summary>
        //private const int currentMemberCount = 37; // DEL 2011/08/10
        // --- UPD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //private const int currentMemberCount = 38; // ADD 2011/08/10
        // UPD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
        //private const int currentMemberCount = 39;
        // UPD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
        //private const int currentMemberCount = 40;
        private const int currentMemberCount = 41;
        // UPD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
        // UPD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<
        // --- UPD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<
    		
	    /// <summary>
	    ///  SCMAcOdrDataWork�C���X�^���X��������
	    /// </summary>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�̃C���X�^���X����������</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    private void SetSCMAcOdrDataWork( System.IO.BinaryWriter writer, SCMAcOdrDataWork temp )
	    {
		    //�쐬����
		    writer.Write( (Int64)temp.CreateDateTime.Ticks );
		    //�X�V����
		    writer.Write( (Int64)temp.UpdateDateTime.Ticks );
		    //��ƃR�[�h
		    writer.Write( temp.EnterpriseCode );
		    //GUID
		    byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
		    writer.Write( fileHeaderGuidArray.Length );
		    writer.Write( temp.FileHeaderGuid.ToByteArray() );
		    //�X�V�]�ƈ��R�[�h
		    writer.Write( temp.UpdEmployeeCode );
		    //�X�V�A�Z���u��ID1
		    writer.Write( temp.UpdAssemblyId1 );
		    //�X�V�A�Z���u��ID2
		    writer.Write( temp.UpdAssemblyId2 );
		    //�_���폜�敪
		    writer.Write( temp.LogicalDeleteCode );
		    //�⍇������ƃR�[�h
            writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
		    //�⍇�������_�R�[�h
		    writer.Write( temp.InqOriginalSecCd );
		    //�⍇�����ƃR�[�h
		    writer.Write( temp.InqOtherEpCd );
		    //�⍇���拒�_�R�[�h
		    writer.Write( temp.InqOtherSecCd );
		    //�⍇���ԍ�
		    writer.Write( temp.InquiryNumber );
		    //���Ӑ�R�[�h
		    writer.Write( temp.CustomerCode );
		    //�X�V�N����
		    writer.Write( (Int64)temp.UpdateDate.Ticks );
		    //�X�V����
		    writer.Write( temp.UpdateTime );
		    //�񓚋敪
		    writer.Write( temp.AnswerDivCd );
		    //�m���
		    writer.Write( (Int64)temp.JudgementDate.Ticks );
		    //�⍇���E�������l
		    writer.Write( temp.InqOrdNote );
		    //�Y�t�t�@�C��
            writer.Write( temp.AppendingFile.Length );
            writer.Write( temp.AppendingFile );
		    //�Y�t�t�@�C����
		    writer.Write( temp.AppendingFileNm );
		    //�⍇���]�ƈ��R�[�h
		    writer.Write( temp.InqEmployeeCd );
		    //�⍇���]�ƈ�����
		    writer.Write( temp.InqEmployeeNm );
		    //�񓚏]�ƈ��R�[�h
		    writer.Write( temp.AnsEmployeeCd );
		    //�񓚏]�ƈ�����
		    writer.Write( temp.AnsEmployeeNm );
		    //�⍇����
		    writer.Write( (Int64)temp.InquiryDate.Ticks );
		    //�󒍃X�e�[�^�X
		    writer.Write( temp.AcptAnOdrStatus );
		    //����`�[�ԍ�
		    writer.Write( temp.SalesSlipNum );
		    //����`�[���v�i�ō��݁j
		    writer.Write( temp.SalesTotalTaxInc );
		    //���㏬�v�i�Łj
		    writer.Write( temp.SalesSubtotalTax );
		    //�⍇���E�������
		    writer.Write( temp.InqOrdDivCd );
		    //�┭�E�񓚎��
		    writer.Write( temp.InqOrdAnsDivCd );
		    //��M����
		    writer.Write( (Int64)temp.ReceiveDateTime.Ticks );
		    //�񓚍쐬�敪
		    writer.Write( temp.AnswerCreateDiv );
		    //�L�����Z���敪
		    writer.Write( temp.CancelDiv );
		    //CMT�A�g�敪
		    writer.Write( temp.CMTCooprtDiv );
		    //SF-PM�A�g�w�����ԍ�
		    writer.Write( temp.SfPmCprtInstSlipNo );
            // -- ADD 2011/08/10   ------ >>>>>>
            //�󔭒����
            writer.Write(temp.AcceptOrOrderKind);
            // -- ADD 2011/08/10   ------ <<<<<<
            // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
            writer.Write(temp.TabUseDiv);
            // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
            //�ԗ��Ǘ��R�[�h
            writer.Write(temp.CarMngCode);
            // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<
            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            // �����񓚕���
            writer.Write(temp.AutoAnsMthd);
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
        }

	    /// <summary>
	    ///  SCMAcOdrDataWork�C���X�^���X�擾
	    /// </summary>
	    /// <returns>SCMAcOdrDataWork�N���X�̃C���X�^���X</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�̃C���X�^���X���擾���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    private SCMAcOdrDataWork GetSCMAcOdrDataWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

		    SCMAcOdrDataWork temp = new SCMAcOdrDataWork();

		    //�쐬����
		    temp.CreateDateTime = new DateTime(reader.ReadInt64());
		    //�X�V����
		    temp.UpdateDateTime = new DateTime(reader.ReadInt64());
		    //��ƃR�[�h
		    temp.EnterpriseCode = reader.ReadString();
		    //GUID
		    int lenOfFileHeaderGuidArray = reader.ReadInt32();
		    byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
		    temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
		    //�X�V�]�ƈ��R�[�h
		    temp.UpdEmployeeCode = reader.ReadString();
		    //�X�V�A�Z���u��ID1
		    temp.UpdAssemblyId1 = reader.ReadString();
		    //�X�V�A�Z���u��ID2
		    temp.UpdAssemblyId2 = reader.ReadString();
		    //�_���폜�敪
		    temp.LogicalDeleteCode = reader.ReadInt32();
		    //�⍇������ƃR�[�h
            temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
		    //�⍇�������_�R�[�h
		    temp.InqOriginalSecCd = reader.ReadString();
		    //�⍇�����ƃR�[�h
		    temp.InqOtherEpCd = reader.ReadString();
		    //�⍇���拒�_�R�[�h
		    temp.InqOtherSecCd = reader.ReadString();
		    //�⍇���ԍ�
		    temp.InquiryNumber = reader.ReadInt64();
		    //���Ӑ�R�[�h
		    temp.CustomerCode = reader.ReadInt32();
		    //�X�V�N����
		    temp.UpdateDate = new DateTime(reader.ReadInt64());
		    //�X�V����
		    temp.UpdateTime = reader.ReadInt32();
		    //�񓚋敪
		    temp.AnswerDivCd = reader.ReadInt32();
		    //�m���
		    temp.JudgementDate = new DateTime(reader.ReadInt64());
		    //�⍇���E�������l
		    temp.InqOrdNote = reader.ReadString();
		    //�Y�t�t�@�C��
            int appendingFileLength = reader.ReadInt32();
            temp.AppendingFile = reader.ReadBytes(appendingFileLength);
            //�Y�t�t�@�C����
            temp.AppendingFileNm = reader.ReadString();
            //�⍇���]�ƈ��R�[�h
		    temp.InqEmployeeCd = reader.ReadString();
		    //�⍇���]�ƈ�����
		    temp.InqEmployeeNm = reader.ReadString();
		    //�񓚏]�ƈ��R�[�h
		    temp.AnsEmployeeCd = reader.ReadString();
		    //�񓚏]�ƈ�����
		    temp.AnsEmployeeNm = reader.ReadString();
		    //�⍇����
		    temp.InquiryDate = new DateTime(reader.ReadInt64());
		    //�󒍃X�e�[�^�X
		    temp.AcptAnOdrStatus = reader.ReadInt32();
		    //����`�[�ԍ�
		    temp.SalesSlipNum = reader.ReadString();
		    //����`�[���v�i�ō��݁j
		    temp.SalesTotalTaxInc = reader.ReadInt64();
		    //���㏬�v�i�Łj
		    temp.SalesSubtotalTax = reader.ReadInt64();
		    //�⍇���E�������
		    temp.InqOrdDivCd = reader.ReadInt32();
		    //�┭�E�񓚎��
		    temp.InqOrdAnsDivCd = reader.ReadInt32();
		    //��M����
		    temp.ReceiveDateTime = new DateTime(reader.ReadInt64());
		    //�񓚍쐬�敪
		    temp.AnswerCreateDiv = reader.ReadInt32();
		    //�L�����Z���敪
		    temp.CancelDiv = reader.ReadInt16();
		    //CMT�A�g�敪
		    temp.CMTCooprtDiv = reader.ReadInt16();
		    //SF-PM�A�g�w�����ԍ�
		    temp.SfPmCprtInstSlipNo = reader.ReadString();
            // -- ADD 2011/08/10   ------ >>>>>>
            //�󔭒����
            temp.AcceptOrOrderKind = reader.ReadInt16();
            // -- ADD 2011/08/10   ------ <<<<<<
            // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //�^�u���b�g�g�p�敪
            temp.TabUseDiv = reader.ReadInt32();
            // --- ADD 2013/05/24 �O�� 2013/06/18�z�M�� SCM��Q��10536 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/24 SCM��Q��10537�Ή� ---------------------------------->>>>>
            //�ԗ��Ǘ��R�[�h
            temp.CarMngCode = reader.ReadString();
            // ADD 2013/05/24 SCM��Q��10537�Ή� ----------------------------------<<<<<

            // ADD 2014/12/19 SCM������ PMNS�Ή� --------------------------------->>>>>
            // �����񓚕���
            temp.AutoAnsMthd = reader.ReadInt16();
            // ADD 2014/12/19 SCM������ PMNS�Ή� ---------------------------------<<<<<
                			
		    //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
		    //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
		    //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
		    //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
		    for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		    {
			    //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
			    //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
			    //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
			    //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
			    int optCount = 0;   
			    object oMemberType = serInfo.MemberInfo[k];
			    if( oMemberType is Type )
			    {
				    Type t = (Type)oMemberType;
				    object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				    if( t.Equals( typeof(int) ) )
				    {
					    optCount = Convert.ToInt32(oData);
				    }
				    else
				    {
					    optCount = 0;
				    }
			    }
			    else if( oMemberType is string )
			    {
				    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				    object userData = formatter.Deserialize( reader );  //�ǂݔ�΂�
			    }
		    }
		    return temp;
	    }

	    /// <summary>
	    ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
	    /// </summary>
	    /// <returns>SCMAcOdrDataWork�N���X�̃C���X�^���X(object)</returns>
	    /// <remarks>
	    /// <br>Note�@�@�@�@�@�@ :   SCMAcOdrDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
	    /// <br>Programer        :   ��������</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    SCMAcOdrDataWork temp = GetSCMAcOdrDataWork( reader, serInfo );
			    lst.Add( temp );
		    }
		    switch(serInfo.RetTypeInfo)
		    {
			    case 0:
				    retValue = lst;
				    break;
			    case 1:
				    retValue = lst[0];
				    break;
			    case 2:
				    retValue = (SCMAcOdrDataWork[])lst.ToArray(typeof(SCMAcOdrDataWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }

}
