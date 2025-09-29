using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   BillPrtSt
	/// <summary>
	///                      ��������ݒ�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ��������ݒ�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/06/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class BillPrtSt
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

		/// <summary>��������ݒ�Ǘ��R�[�h</summary>
		/// <remarks>��Ƀ[���Œ�</remarks>
		private Int32 _billPrtStMngCd;

		/// <summary>�����ꗗ�\�o�͋敪</summary>
		/// <remarks>0:�S�ďo��,1:0�ƃv���X���z����Â�����</remarks>
		private Int32 _billTableOutCd;

		/// <summary>���v�������o�͋敪</summary>
		/// <remarks>0:�S�ďo��,1:0�ƃv���X���z����Â�����(�������i�Ӂj�o�͋敪)</remarks>
		private Int32 _totalBillOutputDiv;

		/// <summary>���א������o�͋敪</summary>
		/// <remarks>0:�S�ďo��,1:0�ƃv���X���z����Â�����</remarks>
		private Int32 _detailBillOutputCode;

		/// <summary>�����������󎚋敪</summary>
		/// <remarks>0:���l��,1:28�`31���͖����ƈ�</remarks>
		private Int32 _billLastDayPrtDiv;

		/// <summary>���������Ж��󎚋敪</summary>
		/// <remarks>0:�󎚂���,1:�󎚂��Ȃ�</remarks>
		private Int32 _billCoNmPrintOutCd;

		/// <summary>��������s���󎚋敪</summary>
		/// <remarks>0:�󎚂���,1:�󎚂��Ȃ�</remarks>
		private Int32 _billBankNmPrintOut;

		/// <summary>���Ӑ�d�b�ԍ��󎚋敪</summary>
		/// <remarks>0:�󎚂��Ȃ�,1:�󎚂���</remarks>
		private Int32 _custTelNoPrtDivCd;

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>����������ꎞ���f����</summary>
		/// <remarks>1��̈���ɂďo�͂ł��閇��</remarks>
		private Int32 _billPrtSuspendCnt;
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
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

		/// public propaty name  :  BillPrtStMngCd
		/// <summary>��������ݒ�Ǘ��R�[�h�v���p�e�B</summary>
		/// <value>��Ƀ[���Œ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������ݒ�Ǘ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BillPrtStMngCd
		{
			get{return _billPrtStMngCd;}
			set{_billPrtStMngCd = value;}
		}

		/// public propaty name  :  BillTableOutCd
		/// <summary>�����ꗗ�\�o�͋敪�v���p�e�B</summary>
		/// <value>0:�S�ďo��,1:0�ƃv���X���z����Â�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����ꗗ�\�o�͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BillTableOutCd
		{
			get{return _billTableOutCd;}
			set{_billTableOutCd = value;}
		}

		/// public propaty name  :  TotalBillOutputDiv
		/// <summary>���v�������o�͋敪�v���p�e�B</summary>
		/// <value>0:�S�ďo��,1:0�ƃv���X���z����Â�����(�������i�Ӂj�o�͋敪)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���v�������o�͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TotalBillOutputDiv
		{
			get{return _totalBillOutputDiv;}
			set{_totalBillOutputDiv = value;}
		}

		/// public propaty name  :  DetailBillOutputCode
		/// <summary>���א������o�͋敪�v���p�e�B</summary>
		/// <value>0:�S�ďo��,1:0�ƃv���X���z����Â�����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���א������o�͋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DetailBillOutputCode
		{
			get{return _detailBillOutputCode;}
			set{_detailBillOutputCode = value;}
		}

		/// public propaty name  :  BillLastDayPrtDiv
		/// <summary>�����������󎚋敪�v���p�e�B</summary>
		/// <value>0:���l��,1:28�`31���͖����ƈ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����������󎚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BillLastDayPrtDiv
		{
			get{return _billLastDayPrtDiv;}
			set{_billLastDayPrtDiv = value;}
		}

		/// public propaty name  :  BillCoNmPrintOutCd
		/// <summary>���������Ж��󎚋敪�v���p�e�B</summary>
		/// <value>0:�󎚂���,1:�󎚂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���������Ж��󎚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BillCoNmPrintOutCd
		{
			get{return _billCoNmPrintOutCd;}
			set{_billCoNmPrintOutCd = value;}
		}

		/// public propaty name  :  BillBankNmPrintOut
		/// <summary>��������s���󎚋敪�v���p�e�B</summary>
		/// <value>0:�󎚂���,1:�󎚂��Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��������s���󎚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BillBankNmPrintOut
		{
			get{return _billBankNmPrintOut;}
			set{_billBankNmPrintOut = value;}
		}

		/// public propaty name  :  CustTelNoPrtDivCd
		/// <summary>���Ӑ�d�b�ԍ��󎚋敪�v���p�e�B</summary>
		/// <value>0:�󎚂��Ȃ�,1:�󎚂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�d�b�ԍ��󎚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CustTelNoPrtDivCd
		{
			get{return _custTelNoPrtDivCd;}
			set{_custTelNoPrtDivCd = value;}
		}

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// public propaty name  :  BillPrtSuspendCnt
		/// <summary>����������ꎞ���f�����v���p�e�B</summary>
		/// <value>1��̈���ɂďo�͂ł��閇��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����������ꎞ���f�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BillPrtSuspendCnt
		{
			get{return _billPrtSuspendCnt;}
			set{_billPrtSuspendCnt = value;}
		}
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
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
		/// ��������ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>BillPrtSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BillPrtSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public BillPrtSt()
		{
		}

		/// <summary>
		/// ��������ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="billPrtStMngCd">��������ݒ�Ǘ��R�[�h(��Ƀ[���Œ�)</param>
		/// <param name="billTableOutCd">�����ꗗ�\�o�͋敪(0:�S�ďo��,1:0�ƃv���X���z����Â�����)</param>
		/// <param name="totalBillOutputDiv">���v�������o�͋敪(0:�S�ďo��,1:0�ƃv���X���z����Â�����(�������i�Ӂj�o�͋敪))</param>
		/// <param name="detailBillOutputCode">���א������o�͋敪(0:�S�ďo��,1:0�ƃv���X���z����Â�����)</param>
		/// <param name="billLastDayPrtDiv">�����������󎚋敪(0:���l��,1:28�`31���͖����ƈ�)</param>
		/// <param name="billCoNmPrintOutCd">���������Ж��󎚋敪(0:�󎚂���,1:�󎚂��Ȃ�)</param>
		/// <param name="billBankNmPrintOut">��������s���󎚋敪(0:�󎚂���,1:�󎚂��Ȃ�)</param>
		/// <param name="custTelNoPrtDivCd">���Ӑ�d�b�ԍ��󎚋敪(0:�󎚂��Ȃ�,1:�󎚂���)</param>
		/// <param name="billPrtSuspendCnt">����������ꎞ���f����(1��̈���ɂďo�͂ł��閇��)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>BillPrtSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BillPrtSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		//public BillPrtSt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 billPrtStMngCd,Int32 billTableOutCd,Int32 totalBillOutputDiv,Int32 detailBillOutputCode,Int32 billLastDayPrtDiv,Int32 billCoNmPrintOutCd,Int32 billBankNmPrintOut,Int32 custTelNoPrtDivCd,Int32 billPrtSuspendCnt,string enterpriseName,string updEmployeeName)  // DEL 2008/06/13
        public BillPrtSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 billPrtStMngCd, Int32 billTableOutCd, Int32 totalBillOutputDiv, Int32 detailBillOutputCode, Int32 billLastDayPrtDiv, Int32 billCoNmPrintOutCd, Int32 billBankNmPrintOut, Int32 custTelNoPrtDivCd, string enterpriseName, string updEmployeeName)  // ADD 2008/06/13
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._billPrtStMngCd = billPrtStMngCd;
			this._billTableOutCd = billTableOutCd;
			this._totalBillOutputDiv = totalBillOutputDiv;
			this._detailBillOutputCode = detailBillOutputCode;
			this._billLastDayPrtDiv = billLastDayPrtDiv;
			this._billCoNmPrintOutCd = billCoNmPrintOutCd;
			this._billBankNmPrintOut = billBankNmPrintOut;
			this._custTelNoPrtDivCd = custTelNoPrtDivCd;
			//this._billPrtSuspendCnt = billPrtSuspendCnt;  // DEL 2008/06/13 
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// ��������ݒ�}�X�^��������
		/// </summary>
		/// <returns>BillPrtSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����BillPrtSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public BillPrtSt Clone()
		{
			//return new BillPrtSt(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._billPrtStMngCd,this._billTableOutCd,this._totalBillOutputDiv,this._detailBillOutputCode,this._billLastDayPrtDiv,this._billCoNmPrintOutCd,this._billBankNmPrintOut,this._custTelNoPrtDivCd,this._billPrtSuspendCnt,this._enterpriseName,this._updEmployeeName);  // DEL 2008/06/13
            return new BillPrtSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._billPrtStMngCd, this._billTableOutCd, this._totalBillOutputDiv, this._detailBillOutputCode, this._billLastDayPrtDiv, this._billCoNmPrintOutCd, this._billBankNmPrintOut, this._custTelNoPrtDivCd, this._enterpriseName, this._updEmployeeName);  // ADD 2008/06/13
        }

		/// <summary>
		/// ��������ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�BillPrtSt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BillPrtSt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(BillPrtSt target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.BillPrtStMngCd == target.BillPrtStMngCd)
				 && (this.BillTableOutCd == target.BillTableOutCd)
				 && (this.TotalBillOutputDiv == target.TotalBillOutputDiv)
				 && (this.DetailBillOutputCode == target.DetailBillOutputCode)
				 && (this.BillLastDayPrtDiv == target.BillLastDayPrtDiv)
				 && (this.BillCoNmPrintOutCd == target.BillCoNmPrintOutCd)
				 && (this.BillBankNmPrintOut == target.BillBankNmPrintOut)
				 && (this.CustTelNoPrtDivCd == target.CustTelNoPrtDivCd)
				 //&& (this.BillPrtSuspendCnt == target.BillPrtSuspendCnt)  // DEL 2008/06/13
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// ��������ݒ�}�X�^��r����
		/// </summary>
		/// <param name="billPrtSt1">
		///                    ��r����BillPrtSt�N���X�̃C���X�^���X
		/// </param>
		/// <param name="billPrtSt2">��r����BillPrtSt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BillPrtSt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(BillPrtSt billPrtSt1, BillPrtSt billPrtSt2)
		{
			return ((billPrtSt1.CreateDateTime == billPrtSt2.CreateDateTime)
				 && (billPrtSt1.UpdateDateTime == billPrtSt2.UpdateDateTime)
				 && (billPrtSt1.EnterpriseCode == billPrtSt2.EnterpriseCode)
				 && (billPrtSt1.FileHeaderGuid == billPrtSt2.FileHeaderGuid)
				 && (billPrtSt1.UpdEmployeeCode == billPrtSt2.UpdEmployeeCode)
				 && (billPrtSt1.UpdAssemblyId1 == billPrtSt2.UpdAssemblyId1)
				 && (billPrtSt1.UpdAssemblyId2 == billPrtSt2.UpdAssemblyId2)
				 && (billPrtSt1.LogicalDeleteCode == billPrtSt2.LogicalDeleteCode)
				 && (billPrtSt1.BillPrtStMngCd == billPrtSt2.BillPrtStMngCd)
				 && (billPrtSt1.BillTableOutCd == billPrtSt2.BillTableOutCd)
				 && (billPrtSt1.TotalBillOutputDiv == billPrtSt2.TotalBillOutputDiv)
				 && (billPrtSt1.DetailBillOutputCode == billPrtSt2.DetailBillOutputCode)
				 && (billPrtSt1.BillLastDayPrtDiv == billPrtSt2.BillLastDayPrtDiv)
				 && (billPrtSt1.BillCoNmPrintOutCd == billPrtSt2.BillCoNmPrintOutCd)
				 && (billPrtSt1.BillBankNmPrintOut == billPrtSt2.BillBankNmPrintOut)
				 && (billPrtSt1.CustTelNoPrtDivCd == billPrtSt2.CustTelNoPrtDivCd)
				 //&& (billPrtSt1.BillPrtSuspendCnt == billPrtSt2.BillPrtSuspendCnt)  // DEL 2008/06/13
				 && (billPrtSt1.EnterpriseName == billPrtSt2.EnterpriseName)
				 && (billPrtSt1.UpdEmployeeName == billPrtSt2.UpdEmployeeName));
		}
		/// <summary>
		/// ��������ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�BillPrtSt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BillPrtSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(BillPrtSt target)
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
			if(this.BillPrtStMngCd != target.BillPrtStMngCd)resList.Add("BillPrtStMngCd");
			if(this.BillTableOutCd != target.BillTableOutCd)resList.Add("BillTableOutCd");
			if(this.TotalBillOutputDiv != target.TotalBillOutputDiv)resList.Add("TotalBillOutputDiv");
			if(this.DetailBillOutputCode != target.DetailBillOutputCode)resList.Add("DetailBillOutputCode");
			if(this.BillLastDayPrtDiv != target.BillLastDayPrtDiv)resList.Add("BillLastDayPrtDiv");
			if(this.BillCoNmPrintOutCd != target.BillCoNmPrintOutCd)resList.Add("BillCoNmPrintOutCd");
			if(this.BillBankNmPrintOut != target.BillBankNmPrintOut)resList.Add("BillBankNmPrintOut");
			if(this.CustTelNoPrtDivCd != target.CustTelNoPrtDivCd)resList.Add("CustTelNoPrtDivCd");
			//if(this.BillPrtSuspendCnt != target.BillPrtSuspendCnt)resList.Add("BillPrtSuspendCnt");  // DEL 2008/06/13
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// ��������ݒ�}�X�^��r����
		/// </summary>
		/// <param name="billPrtSt1">��r����BillPrtSt�N���X�̃C���X�^���X</param>
		/// <param name="billPrtSt2">��r����BillPrtSt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   BillPrtSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(BillPrtSt billPrtSt1, BillPrtSt billPrtSt2)
		{
			ArrayList resList = new ArrayList();
			if(billPrtSt1.CreateDateTime != billPrtSt2.CreateDateTime)resList.Add("CreateDateTime");
			if(billPrtSt1.UpdateDateTime != billPrtSt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(billPrtSt1.EnterpriseCode != billPrtSt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(billPrtSt1.FileHeaderGuid != billPrtSt2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(billPrtSt1.UpdEmployeeCode != billPrtSt2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(billPrtSt1.UpdAssemblyId1 != billPrtSt2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(billPrtSt1.UpdAssemblyId2 != billPrtSt2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(billPrtSt1.LogicalDeleteCode != billPrtSt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(billPrtSt1.BillPrtStMngCd != billPrtSt2.BillPrtStMngCd)resList.Add("BillPrtStMngCd");
			if(billPrtSt1.BillTableOutCd != billPrtSt2.BillTableOutCd)resList.Add("BillTableOutCd");
			if(billPrtSt1.TotalBillOutputDiv != billPrtSt2.TotalBillOutputDiv)resList.Add("TotalBillOutputDiv");
			if(billPrtSt1.DetailBillOutputCode != billPrtSt2.DetailBillOutputCode)resList.Add("DetailBillOutputCode");
			if(billPrtSt1.BillLastDayPrtDiv != billPrtSt2.BillLastDayPrtDiv)resList.Add("BillLastDayPrtDiv");
			if(billPrtSt1.BillCoNmPrintOutCd != billPrtSt2.BillCoNmPrintOutCd)resList.Add("BillCoNmPrintOutCd");
			if(billPrtSt1.BillBankNmPrintOut != billPrtSt2.BillBankNmPrintOut)resList.Add("BillBankNmPrintOut");
			if(billPrtSt1.CustTelNoPrtDivCd != billPrtSt2.CustTelNoPrtDivCd)resList.Add("CustTelNoPrtDivCd");
			//if(billPrtSt1.BillPrtSuspendCnt != billPrtSt2.BillPrtSuspendCnt)resList.Add("BillPrtSuspendCnt");  // DEL 2008/06/13
			if(billPrtSt1.EnterpriseName != billPrtSt2.EnterpriseName)resList.Add("EnterpriseName");
			if(billPrtSt1.UpdEmployeeName != billPrtSt2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}
