//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : SCM�S�̐ݒ�}�X�^
// �v���O�����T�v   : SCM�S�̐ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2009/05/01  �C�����e : �ȉ��A���ڒǉ��B�u���W�ԍ��A��M�����N���Ԋu�v
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20073 �� �B
// �� �� ��  2012/04/20  �C�����e : ���ڒǉ��u�̔��敪�ݒ�A�̔��敪�R�[�h�v
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2012/08/31  �C�����e : 2012/10���z�M�\�� SCM��Q��76�̑Ή� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/11/09  �C�����e : SCM���Ǉ�10337,10338,10341�Ή�
//                                : ���ڒǉ��u�����񓚋敪�i�⍇���j�A�����񓚋敪�i�����j�A
//                                : ��t�]�ƈ��R�[�h�A�󂯏]�ƈ����́A�[�i�敪�A�[�i�敪���́v
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2013/02/13  �C�����e : SCM��Q�ǉ��A�Ή� 2013/03/06�z�M
//                                : ���ڒǉ��u�Y���������񓚋敪�v
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh
// �� �� ��  2013/02/27  �C�����e : �z�M���Ȃ��� Redmine#34752
//                                : ���ڒǉ��u�f�[�^�X�V�q�ɋ敪�v
//----------------------------------------------------------------------------//
//�Ǘ��ԍ�  10801804-00  �쐬�S�� : wangl2
//�� �� ��  2013/04/11   �C�����e : No.73 ���ώ����񓚃T�[�r�X
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SCMTtlSt
	/// <summary>
	///                      SCM�S�̐ݒ�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM�S�̐ݒ�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2009/4/13</br>
	/// <br>Genarated Date   :   2010/08/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/5/12  ����</br>
	/// <br>                 :   �����ڒǉ� </br>
	/// <br>                 :   ���V�X�e���A�g�t�H���_</br>
	/// <br>Update Note      :   2009/5/15  ����</br>
	/// <br>                 :   �����ڒǉ� </br>
	/// <br>                 :   �����񓚋敪</br>
	/// <br>Update Note      :   2009/5/28  ����</br>
	/// <br>                 :   ���⑫�C��</br>
	/// <br>                 :   0:���Ȃ� 1:����</br>
	/// <br>                 :   ��</br>
	/// <br>                 :   0:���Ȃ�,1:�ꕔ�ł��񓚉\�ȏꍇ����,2:�S�ĉ񓚉\�ȏꍇ�݂̂���</br>
	/// <br>Update Note      :   2009/7/7  ����</br>
	/// <br>                 :   �����ڒǉ� </br>
	/// <br>                 :   ���Ϗ����s�敪</br>
	/// <br>Update Note      :   2010/8/3  ����</br>
	/// <br>                 :   �����ڒǉ� </br>
	/// <br>                 :   ���W�ԍ�</br>
	/// <br>                 :   ��M�����N���Ԋu</br>
	/// </remarks>
	public class SCMTtlSt
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
		/// <remarks>00�͑S��</remarks>
		private string _sectionCode = "";

		/// <summary>����`�[���s�敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _salesSlipPrtDiv;

		/// <summary>�󒍓`�[���s�敪</summary>
		/// <remarks>0:���Ȃ��@1:����</remarks>
		private Int32 _acpOdrrSlipPrtDiv;

		/// <summary>���V�X�e���A�g�敪</summary>
		/// <remarks>0:���Ȃ�(PM.NS)�@1:����iPM7SP�j</remarks>
		private Int32 _oldSysCooperatDiv;

		/// <summary>���V�X�e���A�g�t�H���_</summary>
		/// <remarks>�f�t�H���g��"C:\SCMSHARE"</remarks>
		private string _oldSysCoopFolder = "";

		/// <summary>BL�R�[�h�ϊ��敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _bLCodeChgDiv;

		/// <summary>�����A�g�l��</summary>
		/// <remarks>�l������</remarks>
		private double _autoCooperatDis;

		/// <summary>�l���K�p�敪</summary>
		/// <remarks>0:���Ȃ� 1:�S�� 2:�O���i�ȊO 3:�d�_�i��</remarks>
		private Int32 _discountApplyCd;

		/// <summary>�����񓚋敪</summary>
		/// <remarks>0:���Ȃ�,1:�ꕔ�ł��񓚉\�ȏꍇ����,2:�S�ĉ񓚉\�ȏꍇ�݂̂���</remarks>
		private Int32 _autoAnswerDiv;

		/// <summary>���Ϗ����s�敪</summary>
		/// <remarks>0:����@1:���Ȃ�</remarks>
		private Int32 _estimatePrtDiv;

		/// <summary>���W�ԍ�</summary>
		/// <remarks>�}�V���ԍ�</remarks>
		private Int32 _cashRegisterNo;

		/// <summary>��M�����N���Ԋu</summary>
		private Int32 _rcvProcStInterval;

        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// <summary>�̔��敪�ݒ�(�����񓚎�)</summary>
        private Int32 _salesCdStAutoAns;

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

        /// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�����񓚎��\���敪</summary>
        /// <remarks>0:�g�p���Ȃ�,1:PM�ݒ�ɏ]��,2:�D��,3:����,4:������(1:N),5:������(1:1)</remarks>
        private Int32 _autoAnsHourDspDiv;
        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
        /// <summary>�����񓚋敪�i�⍇���j</summary>
        private Int32 _autoAnsInquiryDiv = 0;

        /// <summary>�����񓚋敪�i�����j</summary>
        private Int32 _autoAnsOrderDiv = 0;

        /// <summary>��t�]�ƈ��R�[�h</summary>
        /// <remarks>PM�󒍎҃R�[�h</remarks>
        private string _frontEmployeeCd = "";

        /// <summary>��t�]�ƈ�����</summary>
        private string _frontEmployeeNm = "";

        /// <summary>�[�i�敪</summary>
        /// <remarks>0:���Ȃ� 1:����</remarks>
        private Int32 _deliveredGoodsDiv;

        /// <summary>�[�i�敪����</summary>
        private string _deliveredGoodsNm = "";

        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
        /// <summary>�Y���������񓚋敪</summary>
        /// <remarks>0:���� 1:���Ȃ�</remarks>
        private Int32 _fuwioutAutoAnsDiv;
        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<

        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>�f�[�^�X�V�q�ɋ敪</summary>
        /// <remarks>0:�ϑ��q��,1:��Ǒq��</remarks>
        private Int32 _dataUpDateWareHDiv;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        /// <summary>������͎҃R�[�h </summary>
        private string _salesInputCode;        // ADD 2013.04.11 wangl2 FOR RedMine#35269

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

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// <value>00�͑S��</value>
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

		/// public propaty name  :  SalesSlipPrtDiv
		/// <summary>����`�[���s�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ����`�[���s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SalesSlipPrtDiv
		{
			get{return _salesSlipPrtDiv;}
			set{_salesSlipPrtDiv = value;}
		}

		/// public propaty name  :  AcpOdrrSlipPrtDiv
		/// <summary>�󒍓`�[���s�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ��@1:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󒍓`�[���s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AcpOdrrSlipPrtDiv
		{
			get{return _acpOdrrSlipPrtDiv;}
			set{_acpOdrrSlipPrtDiv = value;}
		}

		/// public propaty name  :  OldSysCooperatDiv
		/// <summary>���V�X�e���A�g�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ�(PM.NS)�@1:����iPM7SP�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���V�X�e���A�g�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OldSysCooperatDiv
		{
			get{return _oldSysCooperatDiv;}
			set{_oldSysCooperatDiv = value;}
		}

		/// public propaty name  :  OldSysCoopFolder
		/// <summary>���V�X�e���A�g�t�H���_�v���p�e�B</summary>
		/// <value>�f�t�H���g��"C:\SCMSHARE"</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���V�X�e���A�g�t�H���_�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OldSysCoopFolder
		{
			get{return _oldSysCoopFolder;}
			set{_oldSysCoopFolder = value;}
		}

		/// public propaty name  :  BLCodeChgDiv
		/// <summary>BL�R�[�h�ϊ��敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL�R�[�h�ϊ��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BLCodeChgDiv
		{
			get{return _bLCodeChgDiv;}
			set{_bLCodeChgDiv = value;}
		}

		/// public propaty name  :  AutoCooperatDis
		/// <summary>�����A�g�l���v���p�e�B</summary>
		/// <value>�l������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����A�g�l���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public double AutoCooperatDis
		{
			get{return _autoCooperatDis;}
			set{_autoCooperatDis = value;}
		}

		/// public propaty name  :  DiscountApplyCd
		/// <summary>�l���K�p�敪�v���p�e�B</summary>
		/// <value>0:���Ȃ� 1:�S�� 2:�O���i�ȊO 3:�d�_�i��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �l���K�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DiscountApplyCd
		{
			get{return _discountApplyCd;}
			set{_discountApplyCd = value;}
		}

		/// public propaty name  :  AutoAnswerDiv
		/// <summary>�����񓚋敪�v���p�e�B</summary>
		/// <value>0:���Ȃ�,1:�ꕔ�ł��񓚉\�ȏꍇ����,2:�S�ĉ񓚉\�ȏꍇ�݂̂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����񓚋敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 AutoAnswerDiv
		{
			get{return _autoAnswerDiv;}
			set{_autoAnswerDiv = value;}
		}

		/// public propaty name  :  EstimatePrtDiv
		/// <summary>���Ϗ����s�敪�v���p�e�B</summary>
		/// <value>0:����@1:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ϗ����s�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EstimatePrtDiv
		{
			get{return _estimatePrtDiv;}
			set{_estimatePrtDiv = value;}
		}

		/// public propaty name  :  CashRegisterNo
		/// <summary>���W�ԍ��v���p�e�B</summary>
		/// <value>�}�V���ԍ�</value>
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

		/// public propaty name  :  RcvProcStInterval
		/// <summary>��M�����N���Ԋu�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��M�����N���Ԋu�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RcvProcStInterval
		{
			get{return _rcvProcStInterval;}
			set{_rcvProcStInterval = value;}
		}
        //2012/04/20 ADD T.Nishi >>>>>>>>>>
        /// public propaty name  :  SalesCdStAutoAns
        /// <summary>�̔��敪�ݒ�(�����񓚎�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�ݒ�(�����񓚎�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCdStAutoAns
        {
            get { return _salesCdStAutoAns; }
            set { _salesCdStAutoAns = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }
        //2012/04/20 ADD T.Nishi <<<<<<<<<<

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

        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AutoAnsHourDspDiv
        /// <summary>�����񓚎��\���敪�v���p�e�B</summary>
        /// <value>0:�g�p���Ȃ�,1:PM�ݒ�ɏ]��,2:�D��,3:����,4:������(1:N),5:������(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚎��\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnsHourDspDiv
        {
            get { return _autoAnsHourDspDiv; }
            set { _autoAnsHourDspDiv = value; }
        }
        // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<


        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
        /// public propaty name  :  AutoAnsInquiryDiv
        /// <summary>�����񓚋敪�i�⍇���j�v���p�e�B</summary>
        /// <value>0:���Ȃ�(�蓮),1:����(�S�Ď�����),2:����(�i�荞�ݎ�������)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪�i�⍇���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnsInquiryDiv
        {
            get { return _autoAnsInquiryDiv; }
            set { _autoAnsInquiryDiv = value; }
        }


        /// public propaty name  : AutoAnsOrderDiv
        /// <summary>�����񓚋敪�i�����j�v���p�e�B</summary>
        /// <value>0:���Ȃ�(�蓮),1:����(�S�Ď�����),2:����(�ϑ��݌ɕ��̂ݎ�����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����񓚋敪�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AutoAnsOrderDiv
        {
            get { return _autoAnsOrderDiv; }
            set { _autoAnsOrderDiv = value; }
        }

        /// public propaty name  :  FrontEmployeeCd
        /// <summary>��t�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>PM�󒍎҃R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeCd
        {
            get { return _frontEmployeeCd; }
            set { _frontEmployeeCd = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  DeliveredGoodsDiv
        /// <summary>�[�i�敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeliveredGoodsDiv
        {
            get { return _deliveredGoodsDiv; }
            set { _deliveredGoodsDiv = value; }
        }

        /// public propaty name  :  DeliveredGoodsNm
        /// <summary>�[�i�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DeliveredGoodsNm
        {
            get { return _deliveredGoodsNm; }
            set { _deliveredGoodsNm = value; }
        }
        // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
        /// public propaty name  :  FuwioutAutoAnsDiv
        /// <summary>�Y���������񓚋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Y���������񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FuwioutAutoAnsDiv
        {
            get { return _fuwioutAutoAnsDiv; }
            set { _fuwioutAutoAnsDiv = value; }
        }
        // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// public propaty name  :  DataUpdWarehouseDiv
        /// <summary>�f�[�^�X�V�q�ɋ敪�v���p�e�B</summary>
        /// <value>0:�ϑ��q��,1:��Ǒq��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�X�V�q�ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataUpDateWareHDiv
        {
            get { return _dataUpDateWareHDiv; }
            set { _dataUpDateWareHDiv = value; }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // --------------- ADD START 2013.04.11 wangl2 FOR RedMine#35269------>>>> 
        /// public propaty name  :  SalesInputCode
        /// <summary>������͎҃R�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎҃R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputCode
        {
            get { return _salesInputCode; }
            set { _salesInputCode = value; }
        }
        // --------------- ADD END 2013.04.11 wangl2 FOR RedMine#35269------<<<<<

		/// <summary>
		/// SCM�S�̐ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>SCMTtlSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMTtlSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMTtlSt()
		{
		}

		/// <summary>
		/// SCM�S�̐ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
		/// <param name="salesSlipPrtDiv">����`�[���s�敪(0:���Ȃ��@1:����)</param>
		/// <param name="acpOdrrSlipPrtDiv">�󒍓`�[���s�敪(0:���Ȃ��@1:����)</param>
		/// <param name="oldSysCooperatDiv">���V�X�e���A�g�敪(0:���Ȃ�(PM.NS)�@1:����iPM7SP�j)</param>
		/// <param name="oldSysCoopFolder">���V�X�e���A�g�t�H���_(�f�t�H���g��"C:\SCMSHARE")</param>
		/// <param name="bLCodeChgDiv">BL�R�[�h�ϊ��敪(0:����@1:���Ȃ�)</param>
		/// <param name="autoCooperatDis">�����A�g�l��(�l������)</param>
		/// <param name="discountApplyCd">�l���K�p�敪(0:���Ȃ� 1:�S�� 2:�O���i�ȊO 3:�d�_�i��)</param>
		/// <param name="autoAnswerDiv">�����񓚋敪(0:���Ȃ�,1:�ꕔ�ł��񓚉\�ȏꍇ����,2:�S�ĉ񓚉\�ȏꍇ�݂̂���)</param>
		/// <param name="estimatePrtDiv">���Ϗ����s�敪(0:����@1:���Ȃ�)</param>
		/// <param name="cashRegisterNo">���W�ԍ�(�}�V���ԍ�)</param>
		/// <param name="rcvProcStInterval">��M�����N���Ԋu</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="answerPriceDiv">�����񓚎��\���敪</param>
		/// <returns>SCMTtlSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMTtlSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        //2012/04/20 UPD T.Nishi >>>>>>>>>>
		//public SCMTtlSt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 salesSlipPrtDiv,Int32 acpOdrrSlipPrtDiv,Int32 oldSysCooperatDiv,string oldSysCoopFolder,Int32 bLCodeChgDiv,double autoCooperatDis,Int32 discountApplyCd,Int32 autoAnswerDiv,Int32 estimatePrtDiv,Int32 cashRegisterNo,Int32 rcvProcStInterval,string enterpriseName,string updEmployeeName)
        // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode)
        // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv)
        // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv, Int32 autoAnsInquiryDiv, Int32 autoAnsOrderDiv, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm)
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv, Int32 autoAnsInquiryDiv, Int32 autoAnsOrderDiv, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm, Int32 fuwioutAutoAnsDiv)// DEL 2013/02/27 qijh #34752
        // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
        // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<
        // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        //2012/04/20 UPD T.Nishi <<<<<<<<<<
        //public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv, Int32 autoAnsInquiryDiv, Int32 autoAnsOrderDiv, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm, Int32 fuwioutAutoAnsDiv, Int32 dataUpDateWareHDiv)// ADD 2013/02/27 qijh #34752 //DEL 2013.04.11 wangl2 FOR RedMine#35269
        public SCMTtlSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 salesSlipPrtDiv, Int32 acpOdrrSlipPrtDiv, Int32 oldSysCooperatDiv, string oldSysCoopFolder, Int32 bLCodeChgDiv, double autoCooperatDis, Int32 discountApplyCd, Int32 autoAnswerDiv, Int32 estimatePrtDiv, Int32 cashRegisterNo, Int32 rcvProcStInterval, string enterpriseName, string updEmployeeName, Int32 salesCdStAutoAns, Int32 salesCode, Int32 autoAnsHourDspDiv, Int32 autoAnsInquiryDiv, Int32 autoAnsOrderDiv, string frontEmployeeCd, string frontEmployeeNm, Int32 deliveredGoodsDiv, string deliveredGoodsNm, Int32 fuwioutAutoAnsDiv, Int32 dataUpDateWareHDiv, string salesInputCode)//ADD 2013.04.11 wangl2 FOR RedMine#35269
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
			this._salesSlipPrtDiv = salesSlipPrtDiv;
			this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
			this._oldSysCooperatDiv = oldSysCooperatDiv;
			this._oldSysCoopFolder = oldSysCoopFolder;
			this._bLCodeChgDiv = bLCodeChgDiv;
			this._autoCooperatDis = autoCooperatDis;
			this._discountApplyCd = discountApplyCd;
			this._autoAnswerDiv = autoAnswerDiv;
			this._estimatePrtDiv = estimatePrtDiv;
			this._cashRegisterNo = cashRegisterNo;
			this._rcvProcStInterval = rcvProcStInterval;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            this._salesCdStAutoAns = salesCdStAutoAns;
            this._salesCode = salesCode;
            //2012/04/20 ADD T.Nishi <<<<<<<<<<
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this._autoAnsHourDspDiv = autoAnsHourDspDiv;
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            this._autoAnsInquiryDiv = autoAnsInquiryDiv;
            this._autoAnsOrderDiv = autoAnsOrderDiv;
            this._frontEmployeeCd = frontEmployeeCd;
            this._frontEmployeeNm = frontEmployeeNm;
            this._deliveredGoodsDiv = deliveredGoodsDiv;
            this._deliveredGoodsNm = deliveredGoodsNm;
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
            this._fuwioutAutoAnsDiv = fuwioutAutoAnsDiv;
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<

            this._dataUpDateWareHDiv = dataUpDateWareHDiv;// ADD 2013/02/27 qijh #34752
            this._salesInputCode = salesInputCode;//ADD 2013.04.11 wangl2 FOR RedMine#35269
        }

		/// <summary>
		/// SCM�S�̐ݒ�}�X�^��������
		/// </summary>
		/// <returns>SCMTtlSt�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMTtlSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SCMTtlSt Clone()
		{
            //2012/04/20 UPD T.Nishi >>>>>>>>>>
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName);
            // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode);
            // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv);
            // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv, this._autoAnsInquiryDiv, this._autoAnsOrderDiv, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm);
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv, this._autoAnsInquiryDiv, this._autoAnsOrderDiv, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm, this._fuwioutAutoAnsDiv);// DEL 2013/02/27 qijh #34752
            // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
            // UPD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<
            // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            //2012/04/20 UPD T.Nishi <<<<<<<<<<
            //return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv, this._autoAnsInquiryDiv, this._autoAnsOrderDiv, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm, this._fuwioutAutoAnsDiv, this._dataUpDateWareHDiv);// ADD 2013/02/27 qijh #34752  //DEL 2013.04.11 wangl2 FOR RedMine#35269
            return new SCMTtlSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._oldSysCooperatDiv, this._oldSysCoopFolder, this._bLCodeChgDiv, this._autoCooperatDis, this._discountApplyCd, this._autoAnswerDiv, this._estimatePrtDiv, this._cashRegisterNo, this._rcvProcStInterval, this._enterpriseName, this._updEmployeeName, this._salesCdStAutoAns, this._salesCode, this._autoAnsHourDspDiv, this._autoAnsInquiryDiv, this._autoAnsOrderDiv, this._frontEmployeeCd, this._frontEmployeeNm, this._deliveredGoodsDiv, this._deliveredGoodsNm, this._fuwioutAutoAnsDiv, this._dataUpDateWareHDiv, this._salesInputCode);//ADD 2013.04.11 wangl2 FOR RedMine#35269
        }

		/// <summary>
		/// SCM�S�̐ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMTtlSt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMTtlSt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SCMTtlSt target)
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
				 && (this.SalesSlipPrtDiv == target.SalesSlipPrtDiv)
				 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
				 && (this.OldSysCooperatDiv == target.OldSysCooperatDiv)
				 && (this.OldSysCoopFolder == target.OldSysCoopFolder)
				 && (this.BLCodeChgDiv == target.BLCodeChgDiv)
				 && (this.AutoCooperatDis == target.AutoCooperatDis)
				 && (this.DiscountApplyCd == target.DiscountApplyCd)
				 && (this.AutoAnswerDiv == target.AutoAnswerDiv)
				 && (this.EstimatePrtDiv == target.EstimatePrtDiv)
				 && (this.CashRegisterNo == target.CashRegisterNo)
				 && (this.RcvProcStInterval == target.RcvProcStInterval)
				 && (this.EnterpriseName == target.EnterpriseName)
                //2012/04/20 ADD T.Nishi >>>>>>>>>>
                 && (this.SalesCdStAutoAns == target.SalesCdStAutoAns)
                 && (this.SalesCode == target.SalesCode)
                //2012/04/20 ADD T.Nishi <<<<<<<<<<
                // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //&& (this.UpdEmployeeName == target.UpdEmployeeName));
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                 && (this.AutoAnsInquiryDiv == target.AutoAnsInquiryDiv)
                 && (this.AutoAnsOrderDiv == target.AutoAnsOrderDiv)
                 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
                 && (this.DeliveredGoodsNm == target.DeliveredGoodsNm)
                // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<
                // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
                //&& (this.AutoAnsHourDspDiv == target.AutoAnsHourDspDiv));
                 && (this.AutoAnsHourDspDiv == target.AutoAnsHourDspDiv)
                 && (this.FuwioutAutoAnsDiv == target.FuwioutAutoAnsDiv)
                 && (this.DataUpDateWareHDiv == target.DataUpDateWareHDiv) // ADD 2013/02/27 qijh #34752
                 && (this.SalesInputCode == target.SalesInputCode)//ADD 2013.04.11 wangl2 FOR RedMine#35269
                );
            // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
            // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

		/// <summary>
		/// SCM�S�̐ݒ�}�X�^��r����
		/// </summary>
		/// <param name="sCMTtlSt1">
		///                    ��r����SCMTtlSt�N���X�̃C���X�^���X
		/// </param>
		/// <param name="sCMTtlSt2">��r����SCMTtlSt�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMTtlSt�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SCMTtlSt sCMTtlSt1, SCMTtlSt sCMTtlSt2)
		{
			return ((sCMTtlSt1.CreateDateTime == sCMTtlSt2.CreateDateTime)
				 && (sCMTtlSt1.UpdateDateTime == sCMTtlSt2.UpdateDateTime)
				 && (sCMTtlSt1.EnterpriseCode == sCMTtlSt2.EnterpriseCode)
				 && (sCMTtlSt1.FileHeaderGuid == sCMTtlSt2.FileHeaderGuid)
				 && (sCMTtlSt1.UpdEmployeeCode == sCMTtlSt2.UpdEmployeeCode)
				 && (sCMTtlSt1.UpdAssemblyId1 == sCMTtlSt2.UpdAssemblyId1)
				 && (sCMTtlSt1.UpdAssemblyId2 == sCMTtlSt2.UpdAssemblyId2)
				 && (sCMTtlSt1.LogicalDeleteCode == sCMTtlSt2.LogicalDeleteCode)
				 && (sCMTtlSt1.SectionCode == sCMTtlSt2.SectionCode)
				 && (sCMTtlSt1.SalesSlipPrtDiv == sCMTtlSt2.SalesSlipPrtDiv)
				 && (sCMTtlSt1.AcpOdrrSlipPrtDiv == sCMTtlSt2.AcpOdrrSlipPrtDiv)
				 && (sCMTtlSt1.OldSysCooperatDiv == sCMTtlSt2.OldSysCooperatDiv)
				 && (sCMTtlSt1.OldSysCoopFolder == sCMTtlSt2.OldSysCoopFolder)
				 && (sCMTtlSt1.BLCodeChgDiv == sCMTtlSt2.BLCodeChgDiv)
				 && (sCMTtlSt1.AutoCooperatDis == sCMTtlSt2.AutoCooperatDis)
				 && (sCMTtlSt1.DiscountApplyCd == sCMTtlSt2.DiscountApplyCd)
				 && (sCMTtlSt1.AutoAnswerDiv == sCMTtlSt2.AutoAnswerDiv)
				 && (sCMTtlSt1.EstimatePrtDiv == sCMTtlSt2.EstimatePrtDiv)
				 && (sCMTtlSt1.CashRegisterNo == sCMTtlSt2.CashRegisterNo)
				 && (sCMTtlSt1.RcvProcStInterval == sCMTtlSt2.RcvProcStInterval)
				 && (sCMTtlSt1.EnterpriseName == sCMTtlSt2.EnterpriseName)
                //2012/04/20 ADD T.Nishi >>>>>>>>>>
                 && (sCMTtlSt1.SalesCdStAutoAns == sCMTtlSt2.SalesCdStAutoAns)
                 && (sCMTtlSt1.SalesCode == sCMTtlSt2.SalesCode)
                //2012/04/20 ADD T.Nishi <<<<<<<<<<
                // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //&& (sCMTtlSt1.UpdEmployeeName == sCMTtlSt2.UpdEmployeeName));
                 && (sCMTtlSt1.UpdEmployeeName == sCMTtlSt2.UpdEmployeeName)
                // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
                 && (sCMTtlSt1.AutoAnsInquiryDiv == sCMTtlSt2.AutoAnsInquiryDiv)
                 && (sCMTtlSt1.AutoAnsOrderDiv == sCMTtlSt2.AutoAnsOrderDiv)
                 && (sCMTtlSt1.FrontEmployeeCd == sCMTtlSt2.FrontEmployeeCd)
                 && (sCMTtlSt1.FrontEmployeeNm == sCMTtlSt2.FrontEmployeeNm)
                 && (sCMTtlSt1.DeliveredGoodsDiv == sCMTtlSt2.DeliveredGoodsDiv)
                 && (sCMTtlSt1.DeliveredGoodsNm == sCMTtlSt2.DeliveredGoodsNm)
                // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<
                // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
                //&& (sCMTtlSt1.AutoAnsHourDspDiv == sCMTtlSt2.AutoAnsHourDspDiv));
                 && (sCMTtlSt1.AutoAnsHourDspDiv == sCMTtlSt2.AutoAnsHourDspDiv)
                 && (sCMTtlSt1.FuwioutAutoAnsDiv == sCMTtlSt2.FuwioutAutoAnsDiv)
                 && (sCMTtlSt1.DataUpDateWareHDiv == sCMTtlSt2.DataUpDateWareHDiv) // ADD 2013/02/27 qijh #34752
                 && (sCMTtlSt1.SalesInputCode == sCMTtlSt2.SalesInputCode)//ADD 2013.04.11 wangl2 FOR RedMine#35269
                 );
            // UPD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
            // --- UPD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
		/// <summary>
		/// SCM�S�̐ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SCMTtlSt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMTtlSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SCMTtlSt target)
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
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SalesSlipPrtDiv != target.SalesSlipPrtDiv)resList.Add("SalesSlipPrtDiv");
			if(this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv)resList.Add("AcpOdrrSlipPrtDiv");
			if(this.OldSysCooperatDiv != target.OldSysCooperatDiv)resList.Add("OldSysCooperatDiv");
			if(this.OldSysCoopFolder != target.OldSysCoopFolder)resList.Add("OldSysCoopFolder");
			if(this.BLCodeChgDiv != target.BLCodeChgDiv)resList.Add("BLCodeChgDiv");
			if(this.AutoCooperatDis != target.AutoCooperatDis)resList.Add("AutoCooperatDis");
			if(this.DiscountApplyCd != target.DiscountApplyCd)resList.Add("DiscountApplyCd");
			if(this.AutoAnswerDiv != target.AutoAnswerDiv)resList.Add("AutoAnswerDiv");
			if(this.EstimatePrtDiv != target.EstimatePrtDiv)resList.Add("EstimatePrtDiv");
			if(this.CashRegisterNo != target.CashRegisterNo)resList.Add("CashRegisterNo");
			if(this.RcvProcStInterval != target.RcvProcStInterval)resList.Add("RcvProcStInterval");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            if (this.SalesCdStAutoAns != target.SalesCdStAutoAns) resList.Add("SalesCdStAutoAns");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this.AutoAnsHourDspDiv != target.AutoAnsHourDspDiv) resList.Add("AutoAnsHourDspDiv");
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            if (this.AutoAnsInquiryDiv != target.AutoAnsInquiryDiv) resList.Add("AutoAnsInquiryDiv");
            if (this.AutoAnsOrderDiv != target.AutoAnsOrderDiv) resList.Add("AutoAnsOrderDiv");
            if (this.FrontEmployeeCd != target.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (this.DeliveredGoodsDiv != target.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (this.DeliveredGoodsNm != target.DeliveredGoodsNm) resList.Add("DeliveredGoodsNm");
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
            if (this.FuwioutAutoAnsDiv != target.FuwioutAutoAnsDiv) resList.Add("FuwioutAutoAnsDiv");
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
            if (this.DataUpDateWareHDiv != target.DataUpDateWareHDiv) resList.Add("DataUpdWarehouseDiv"); // ADD 2013/02/27 qijh #34752
            if (this.SalesInputCode != target.SalesInputCode) resList.Add("SalesInputCode");//ADD 2013.04.11 wangl2 FOR RedMine#35269

			return resList;
		}

		/// <summary>
		/// SCM�S�̐ݒ�}�X�^��r����
		/// </summary>
		/// <param name="sCMTtlSt1">��r����SCMTtlSt�N���X�̃C���X�^���X</param>
		/// <param name="sCMTtlSt2">��r����SCMTtlSt�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SCMTtlSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SCMTtlSt sCMTtlSt1, SCMTtlSt sCMTtlSt2)
		{
			ArrayList resList = new ArrayList();
			if(sCMTtlSt1.CreateDateTime != sCMTtlSt2.CreateDateTime)resList.Add("CreateDateTime");
			if(sCMTtlSt1.UpdateDateTime != sCMTtlSt2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(sCMTtlSt1.EnterpriseCode != sCMTtlSt2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMTtlSt1.FileHeaderGuid != sCMTtlSt2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(sCMTtlSt1.UpdEmployeeCode != sCMTtlSt2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(sCMTtlSt1.UpdAssemblyId1 != sCMTtlSt2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(sCMTtlSt1.UpdAssemblyId2 != sCMTtlSt2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(sCMTtlSt1.LogicalDeleteCode != sCMTtlSt2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(sCMTtlSt1.SectionCode != sCMTtlSt2.SectionCode)resList.Add("SectionCode");
			if(sCMTtlSt1.SalesSlipPrtDiv != sCMTtlSt2.SalesSlipPrtDiv)resList.Add("SalesSlipPrtDiv");
			if(sCMTtlSt1.AcpOdrrSlipPrtDiv != sCMTtlSt2.AcpOdrrSlipPrtDiv)resList.Add("AcpOdrrSlipPrtDiv");
			if(sCMTtlSt1.OldSysCooperatDiv != sCMTtlSt2.OldSysCooperatDiv)resList.Add("OldSysCooperatDiv");
			if(sCMTtlSt1.OldSysCoopFolder != sCMTtlSt2.OldSysCoopFolder)resList.Add("OldSysCoopFolder");
			if(sCMTtlSt1.BLCodeChgDiv != sCMTtlSt2.BLCodeChgDiv)resList.Add("BLCodeChgDiv");
			if(sCMTtlSt1.AutoCooperatDis != sCMTtlSt2.AutoCooperatDis)resList.Add("AutoCooperatDis");
			if(sCMTtlSt1.DiscountApplyCd != sCMTtlSt2.DiscountApplyCd)resList.Add("DiscountApplyCd");
			if(sCMTtlSt1.AutoAnswerDiv != sCMTtlSt2.AutoAnswerDiv)resList.Add("AutoAnswerDiv");
			if(sCMTtlSt1.EstimatePrtDiv != sCMTtlSt2.EstimatePrtDiv)resList.Add("EstimatePrtDiv");
			if(sCMTtlSt1.CashRegisterNo != sCMTtlSt2.CashRegisterNo)resList.Add("CashRegisterNo");
			if(sCMTtlSt1.RcvProcStInterval != sCMTtlSt2.RcvProcStInterval)resList.Add("RcvProcStInterval");
			if(sCMTtlSt1.EnterpriseName != sCMTtlSt2.EnterpriseName)resList.Add("EnterpriseName");
			if(sCMTtlSt1.UpdEmployeeName != sCMTtlSt2.UpdEmployeeName)resList.Add("UpdEmployeeName");
            //2012/04/20 ADD T.Nishi >>>>>>>>>>
            if (sCMTtlSt1.SalesCdStAutoAns != sCMTtlSt2.SalesCdStAutoAns) resList.Add("SalesCdStAutoAns");
            if (sCMTtlSt1.SalesCode != sCMTtlSt2.SalesCode) resList.Add("SalesCode");
            //2012/04/20 ADD T.Nishi <<<<<<<<<<

            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (sCMTtlSt1.AutoAnsHourDspDiv != sCMTtlSt2.AutoAnsHourDspDiv) resList.Add("AutoAnsHourDspDiv");
            // --- ADD 2012/08/31 �O�� 2012/10���z�M�\�� SCM��Q��76 ---------<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ---------------------------------->>>>>
            if (sCMTtlSt1.AutoAnsInquiryDiv != sCMTtlSt2.AutoAnsInquiryDiv) resList.Add("AutoAnsInquiryDiv");
            if (sCMTtlSt1.AutoAnsOrderDiv != sCMTtlSt2.AutoAnsOrderDiv) resList.Add("AutoAnsOrderDiv");
            if (sCMTtlSt1.FrontEmployeeCd != sCMTtlSt2.FrontEmployeeCd) resList.Add("FrontEmployeeCd");
            if (sCMTtlSt1.FrontEmployeeNm != sCMTtlSt2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (sCMTtlSt1.DeliveredGoodsDiv != sCMTtlSt2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (sCMTtlSt1.DeliveredGoodsNm != sCMTtlSt2.DeliveredGoodsNm) resList.Add("DeliveredGoodsNm");
            // ADD 2012/11/09 2012/12/12�z�M�\�� SCM���Ǉ�10337,10338,10341�Ή� ----------------------------------<<<<<

            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� 2013/03/06�z�M-------------------------------------------->>>>>
            if (sCMTtlSt1.FuwioutAutoAnsDiv != sCMTtlSt2.FuwioutAutoAnsDiv) resList.Add("FuwioutAutoAnsDiv");
            // ADD 2013/02/13 SCM��Q�ǉ��A�Ή� --------------------------------------------<<<<<
            if (sCMTtlSt1.DataUpDateWareHDiv != sCMTtlSt2.DataUpDateWareHDiv) resList.Add("DataUpdWarehouseDiv"); // ADD 2013/02/27 qijh #34752
            if (sCMTtlSt1.SalesInputCode != sCMTtlSt2.SalesInputCode) resList.Add("SalesInputCode");//ADD 2013.04.11 wangl2 FOR RedMine#35269

			return resList;
		}
	}
}
