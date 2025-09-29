//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����`�f�[�^
// �v���O�����T�v   : ����`�f�[�^���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RcvDraftData
    /// <summary>
    ///                      ����`�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����`�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2010/04/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/10  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �J���[�R�[�h</br>
    /// <br>                 :   �J���[����1</br>
    /// <br>                 :   �g�����R�[�h</br>
    /// <br>                 :   �g��������</br>
    /// <br>Update Note      :   2008/6/30  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �����I�u�W�F�N�g�z��</br>
    /// <br>Update Note      :   2008/7/8  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   �����@�^���i�G���W���j</br>
    /// <br>Update Note      :   2008/9/19  ����</br>
    /// <br>                 :   ���ڒǉ�</br>
    /// <br>                 :   ���[�J�[���p����</br>
    /// <br>                 :   �Ԏ피�p����</br>
    /// <br>Update Note      :   2008/12/17  ����</br>
    /// <br>                 :   ���ڏC���i�m�t�k�k���ɕύX�j</br>
    /// <br>                 :   �^���i�ޕʋL���j�A�^���i�t���^�j</br>
    /// <br>Update Note      :   2009/9/1  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �@���q�ǉ����P</br>
    /// <br>                 :   �@���q�ǉ����Q</br>
    /// <br>                 :   �@���q���l</br>
    /// </remarks>
    public class RcvDraftData
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

        /// <summary>����`�ԍ�</summary>
        private string _rcvDraftNo = "";

        /// <summary>��`���</summary>
        /// <remarks>0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����</remarks>
        private Int32 _draftKindCd;

        /// <summary>��`�敪</summary>
        /// <remarks>0:���U 1:���U�@���������U�敪</remarks>
        private Int32 _draftDivide;

        /// <summary>�������z</summary>
        /// <remarks>�l���E�萔�����������z</remarks>
        private Int64 _deposit;

        /// <summary>��s�E�x�X�R�[�h</summary>
        /// <remarks>��4����s���ޤ��3���x�X����</remarks>
        private Int32 _bankAndBranchCd;

        /// <summary>��s�E�x�X����</summary>
        private string _bankAndBranchNm = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>���q�ł���`�ް����쐬�Ȃ̂ŕK�v</remarks>
        private string _addUpSecCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ於��</summary>
        private string _customerName = "";

        /// <summary>���Ӑ於��2</summary>
        private string _customerName2 = "";

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _procDate;

        /// <summary>��`�U�o��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _draftDrawingDate;

        /// <summary>�L������</summary>
        /// <remarks>YYYYMMDD�@�������A�������Ƃ��Ďg�p</remarks>
        private Int32 _validityTerm;

        /// <summary>��`���ϓ�</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _draftStmntDate;

        /// <summary>�`�[�E�v1</summary>
        private string _outline1 = "";

        /// <summary>�`�[�E�v2</summary>
        private string _outline2 = "";

        /// <summary>�󒍃X�e�[�^�X</summary>
        /// <remarks>10:����,20:��,30:����,40:�o��</remarks>
        private Int32 _acptAnOdrStatus;

        /// <summary>�����`�[�ԍ�</summary>
        private Int32 _depositSlipNo;

        /// <summary>�����s�ԍ�</summary>
        /// <remarks>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</remarks>
        private Int32 _depositRowNo;

        /// <summary>�������t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _depositDate;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";


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

        /// public propaty name  :  RcvDraftNo
        /// <summary>����`�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string RcvDraftNo
        {
            get { return _rcvDraftNo; }
            set { _rcvDraftNo = value; }
        }

        /// public propaty name  :  DraftKindCd
        /// <summary>��`��ʃv���p�e�B</summary>
        /// <value>0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftKindCd
        {
            get { return _draftKindCd; }
            set { _draftKindCd = value; }
        }

        /// public propaty name  :  DraftDivide
        /// <summary>��`�敪�v���p�e�B</summary>
        /// <value>0:���U 1:���U�@���������U�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  Deposit
        /// <summary>�������z�v���p�e�B</summary>
        /// <value>�l���E�萔�����������z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        /// public propaty name  :  BankAndBranchCd
        /// <summary>��s�E�x�X�R�[�h�v���p�e�B</summary>
        /// <value>��4����s���ޤ��3���x�X����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�E�x�X�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BankAndBranchCd
        {
            get { return _bankAndBranchCd; }
            set { _bankAndBranchCd = value; }
        }

        /// public propaty name  :  BankAndBranchNm
        /// <summary>��s�E�x�X���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��s�E�x�X���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BankAndBranchNm
        {
            get { return _bankAndBranchNm; }
            set { _bankAndBranchNm = value; }
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

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>���q�ł���`�ް����쐬�Ȃ̂ŕK�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
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
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerName
        /// <summary>���Ӑ於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        /// public propaty name  :  CustomerName2
        /// <summary>���Ӑ於��2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerName2
        {
            get { return _customerName2; }
            set { _customerName2 = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  ProcDate
        /// <summary>�������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDate
        {
            get { return _procDate; }
            set { _procDate = value; }
        }

        /// public propaty name  :  DraftDrawingDate
        /// <summary>��`�U�o���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DraftDrawingDate
        {
            get { return _draftDrawingDate; }
            set { _draftDrawingDate = value; }
        }

        /// public propaty name  :  DraftDrawingDateJpFormal
        /// <summary>��`�U�o�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDrawingDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateJpInFormal
        /// <summary>��`�U�o�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDrawingDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateAdFormal
        /// <summary>��`�U�o�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDrawingDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  DraftDrawingDateAdInFormal
        /// <summary>��`�U�o�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�U�o�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DraftDrawingDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _draftDrawingDate); }
            set { }
        }

        /// public propaty name  :  ValidityTerm
        /// <summary>�L�������v���p�e�B</summary>
        /// <value>YYYYMMDD�@�������A�������Ƃ��Ďg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ValidityTerm
        {
            get { return _validityTerm; }
            set { _validityTerm = value; }
        }

        /// public propaty name  :  DraftStmntDate
        /// <summary>��`���ϓ��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`���ϓ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftStmntDate
        {
            get { return _draftStmntDate; }
            set { _draftStmntDate = value; }
        }

        /// public propaty name  :  Outline1
        /// <summary>�`�[�E�v1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Outline1
        {
            get { return _outline1; }
            set { _outline1 = value; }
        }

        /// public propaty name  :  Outline2
        /// <summary>�`�[�E�v2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�E�v2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Outline2
        {
            get { return _outline2; }
            set { _outline2 = value; }
        }

        /// public propaty name  :  AcptAnOdrStatus
        /// <summary>�󒍃X�e�[�^�X�v���p�e�B</summary>
        /// <value>10:����,20:��,30:����,40:�o��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󒍃X�e�[�^�X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AcptAnOdrStatus
        {
            get { return _acptAnOdrStatus; }
            set { _acptAnOdrStatus = value; }
        }

        /// public propaty name  :  DepositSlipNo
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositSlipNo
        {
            get { return _depositSlipNo; }
            set { _depositSlipNo = value; }
        }

        /// public propaty name  :  DepositRowNo
        /// <summary>�����s�ԍ��v���p�e�B</summary>
        /// <value>�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositRowNo
        {
            get { return _depositRowNo; }
            set { _depositRowNo = value; }
        }

        /// public propaty name  :  DepositDate
        /// <summary>�������t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DepositDate
        {
            get { return _depositDate; }
            set { _depositDate = value; }
        }

        /// public propaty name  :  DepositDateJpFormal
        /// <summary>�������t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateJpInFormal
        /// <summary>�������t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateAdFormal
        /// <summary>�������t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _depositDate); }
            set { }
        }

        /// public propaty name  :  DepositDateAdInFormal
        /// <summary>�������t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DepositDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _depositDate); }
            set { }
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

        /// public propaty name  :  AddUpSecName
        /// <summary>�v�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }


        /// <summary>
        /// ����`�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>RcvDraftData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RcvDraftData()
        {
        }

        /// <summary>
        /// ����`�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="rcvDraftNo">����`�ԍ�</param>
        /// <param name="draftKindCd">��`���(0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����)</param>
        /// <param name="draftDivide">��`�敪(0:���U 1:���U�@���������U�敪)</param>
        /// <param name="deposit">�������z(�l���E�萔�����������z)</param>
        /// <param name="bankAndBranchCd">��s�E�x�X�R�[�h(��4����s���ޤ��3���x�X����)</param>
        /// <param name="bankAndBranchNm">��s�E�x�X����</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(���q�ł���`�ް����쐬�Ȃ̂ŕK�v)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerName">���Ӑ於��</param>
        /// <param name="customerName2">���Ӑ於��2</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="procDate">������(YYYYMMDD)</param>
        /// <param name="draftDrawingDate">��`�U�o��(YYYYMMDD)</param>
        /// <param name="validityTerm">�L������(YYYYMMDD�@�������A�������Ƃ��Ďg�p)</param>
        /// <param name="draftStmntDate">��`���ϓ�(YYYYMMDD)</param>
        /// <param name="outline1">�`�[�E�v1</param>
        /// <param name="outline2">�`�[�E�v2</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X(10:����,20:��,30:����,40:�o��)</param>
        /// <param name="depositSlipNo">�����`�[�ԍ�</param>
        /// <param name="depositRowNo">�����s�ԍ�(�������ݒ����R�[�h�̐ݒ�ԍ����Z�b�g)</param>
        /// <param name="depositDate">�������t(YYYYMMDD)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <returns>RcvDraftData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftData�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RcvDraftData(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string rcvDraftNo, Int32 draftKindCd, Int32 draftDivide, Int64 deposit, Int32 bankAndBranchCd, string bankAndBranchNm, string sectionCode, string addUpSecCode, Int32 customerCode, string customerName, string customerName2, string customerSnm, Int32 procDate, DateTime draftDrawingDate, Int32 validityTerm, Int32 draftStmntDate, string outline1, string outline2, Int32 acptAnOdrStatus, Int32 depositSlipNo, Int32 depositRowNo, DateTime depositDate, string enterpriseName, string updEmployeeName, string addUpSecName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._rcvDraftNo = rcvDraftNo;
            this._draftKindCd = draftKindCd;
            this._draftDivide = draftDivide;
            this._deposit = deposit;
            this._bankAndBranchCd = bankAndBranchCd;
            this._bankAndBranchNm = bankAndBranchNm;
            this._sectionCode = sectionCode;
            this._addUpSecCode = addUpSecCode;
            this._customerCode = customerCode;
            this._customerName = customerName;
            this._customerName2 = customerName2;
            this._customerSnm = customerSnm;
            this._procDate = procDate;
            this.DraftDrawingDate = draftDrawingDate;
            this._validityTerm = validityTerm;
            this._draftStmntDate = draftStmntDate;
            this._outline1 = outline1;
            this._outline2 = outline2;
            this._acptAnOdrStatus = acptAnOdrStatus;
            this._depositSlipNo = depositSlipNo;
            this._depositRowNo = depositRowNo;
            this.DepositDate = depositDate;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;

        }

        /// <summary>
        /// ����`�f�[�^��������
        /// </summary>
        /// <returns>RcvDraftData�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����RcvDraftData�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RcvDraftData Clone()
        {
            return new RcvDraftData(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._rcvDraftNo, this._draftKindCd, this._draftDivide, this._deposit, this._bankAndBranchCd, this._bankAndBranchNm, this._sectionCode, this._addUpSecCode, this._customerCode, this._customerName, this._customerName2, this._customerSnm, this._procDate, this._draftDrawingDate, this._validityTerm, this._draftStmntDate, this._outline1, this._outline2, this._acptAnOdrStatus, this._depositSlipNo, this._depositRowNo, this._depositDate, this._enterpriseName, this._updEmployeeName, this._addUpSecName);
        }

        /// <summary>
        /// ����`�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RcvDraftData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(RcvDraftData target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.RcvDraftNo == target.RcvDraftNo)
                 && (this.DraftKindCd == target.DraftKindCd)
                 && (this.DraftDivide == target.DraftDivide)
                 && (this.Deposit == target.Deposit)
                 && (this.BankAndBranchCd == target.BankAndBranchCd)
                 && (this.BankAndBranchNm == target.BankAndBranchNm)
                 && (this.SectionCode == target.SectionCode)
                 && (this.AddUpSecCode == target.AddUpSecCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerName == target.CustomerName)
                 && (this.CustomerName2 == target.CustomerName2)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.ProcDate == target.ProcDate)
                 && (this.DraftDrawingDate == target.DraftDrawingDate)
                 && (this.ValidityTerm == target.ValidityTerm)
                 && (this.DraftStmntDate == target.DraftStmntDate)
                 && (this.Outline1 == target.Outline1)
                 && (this.Outline2 == target.Outline2)
                 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
                 && (this.DepositSlipNo == target.DepositSlipNo)
                 && (this.DepositRowNo == target.DepositRowNo)
                 && (this.DepositDate == target.DepositDate)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.AddUpSecName == target.AddUpSecName));
        }

        /// <summary>
        /// ����`�f�[�^��r����
        /// </summary>
        /// <param name="rcvDraftData1">
        ///                    ��r����RcvDraftData�N���X�̃C���X�^���X
        /// </param>
        /// <param name="rcvDraftData2">��r����RcvDraftData�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftData�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(RcvDraftData rcvDraftData1, RcvDraftData rcvDraftData2)
        {
            return ((rcvDraftData1.CreateDateTime == rcvDraftData2.CreateDateTime)
                 && (rcvDraftData1.UpdateDateTime == rcvDraftData2.UpdateDateTime)
                 && (rcvDraftData1.EnterpriseCode == rcvDraftData2.EnterpriseCode)
                 && (rcvDraftData1.FileHeaderGuid == rcvDraftData2.FileHeaderGuid)
                 && (rcvDraftData1.UpdEmployeeCode == rcvDraftData2.UpdEmployeeCode)
                 && (rcvDraftData1.UpdAssemblyId1 == rcvDraftData2.UpdAssemblyId1)
                 && (rcvDraftData1.UpdAssemblyId2 == rcvDraftData2.UpdAssemblyId2)
                 && (rcvDraftData1.LogicalDeleteCode == rcvDraftData2.LogicalDeleteCode)
                 && (rcvDraftData1.RcvDraftNo == rcvDraftData2.RcvDraftNo)
                 && (rcvDraftData1.DraftKindCd == rcvDraftData2.DraftKindCd)
                 && (rcvDraftData1.DraftDivide == rcvDraftData2.DraftDivide)
                 && (rcvDraftData1.Deposit == rcvDraftData2.Deposit)
                 && (rcvDraftData1.BankAndBranchCd == rcvDraftData2.BankAndBranchCd)
                 && (rcvDraftData1.BankAndBranchNm == rcvDraftData2.BankAndBranchNm)
                 && (rcvDraftData1.SectionCode == rcvDraftData2.SectionCode)
                 && (rcvDraftData1.AddUpSecCode == rcvDraftData2.AddUpSecCode)
                 && (rcvDraftData1.CustomerCode == rcvDraftData2.CustomerCode)
                 && (rcvDraftData1.CustomerName == rcvDraftData2.CustomerName)
                 && (rcvDraftData1.CustomerName2 == rcvDraftData2.CustomerName2)
                 && (rcvDraftData1.CustomerSnm == rcvDraftData2.CustomerSnm)
                 && (rcvDraftData1.ProcDate == rcvDraftData2.ProcDate)
                 && (rcvDraftData1.DraftDrawingDate == rcvDraftData2.DraftDrawingDate)
                 && (rcvDraftData1.ValidityTerm == rcvDraftData2.ValidityTerm)
                 && (rcvDraftData1.DraftStmntDate == rcvDraftData2.DraftStmntDate)
                 && (rcvDraftData1.Outline1 == rcvDraftData2.Outline1)
                 && (rcvDraftData1.Outline2 == rcvDraftData2.Outline2)
                 && (rcvDraftData1.AcptAnOdrStatus == rcvDraftData2.AcptAnOdrStatus)
                 && (rcvDraftData1.DepositSlipNo == rcvDraftData2.DepositSlipNo)
                 && (rcvDraftData1.DepositRowNo == rcvDraftData2.DepositRowNo)
                 && (rcvDraftData1.DepositDate == rcvDraftData2.DepositDate)
                 && (rcvDraftData1.EnterpriseName == rcvDraftData2.EnterpriseName)
                 && (rcvDraftData1.UpdEmployeeName == rcvDraftData2.UpdEmployeeName)
                 && (rcvDraftData1.AddUpSecName == rcvDraftData2.AddUpSecName));
        }
        /// <summary>
        /// ����`�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RcvDraftData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftData�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(RcvDraftData target)
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
            if (this.RcvDraftNo != target.RcvDraftNo) resList.Add("RcvDraftNo");
            if (this.DraftKindCd != target.DraftKindCd) resList.Add("DraftKindCd");
            if (this.DraftDivide != target.DraftDivide) resList.Add("DraftDivide");
            if (this.Deposit != target.Deposit) resList.Add("Deposit");
            if (this.BankAndBranchCd != target.BankAndBranchCd) resList.Add("BankAndBranchCd");
            if (this.BankAndBranchNm != target.BankAndBranchNm) resList.Add("BankAndBranchNm");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerName != target.CustomerName) resList.Add("CustomerName");
            if (this.CustomerName2 != target.CustomerName2) resList.Add("CustomerName2");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.ProcDate != target.ProcDate) resList.Add("ProcDate");
            if (this.DraftDrawingDate != target.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (this.ValidityTerm != target.ValidityTerm) resList.Add("ValidityTerm");
            if (this.DraftStmntDate != target.DraftStmntDate) resList.Add("DraftStmntDate");
            if (this.Outline1 != target.Outline1) resList.Add("Outline1");
            if (this.Outline2 != target.Outline2) resList.Add("Outline2");
            if (this.AcptAnOdrStatus != target.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (this.DepositSlipNo != target.DepositSlipNo) resList.Add("DepositSlipNo");
            if (this.DepositRowNo != target.DepositRowNo) resList.Add("DepositRowNo");
            if (this.DepositDate != target.DepositDate) resList.Add("DepositDate");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }

        /// <summary>
        /// ����`�f�[�^��r����
        /// </summary>
        /// <param name="rcvDraftData1">��r����RcvDraftData�N���X�̃C���X�^���X</param>
        /// <param name="rcvDraftData2">��r����RcvDraftData�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftData�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(RcvDraftData rcvDraftData1, RcvDraftData rcvDraftData2)
        {
            ArrayList resList = new ArrayList();
            if (rcvDraftData1.CreateDateTime != rcvDraftData2.CreateDateTime) resList.Add("CreateDateTime");
            if (rcvDraftData1.UpdateDateTime != rcvDraftData2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (rcvDraftData1.EnterpriseCode != rcvDraftData2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (rcvDraftData1.FileHeaderGuid != rcvDraftData2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (rcvDraftData1.UpdEmployeeCode != rcvDraftData2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (rcvDraftData1.UpdAssemblyId1 != rcvDraftData2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (rcvDraftData1.UpdAssemblyId2 != rcvDraftData2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (rcvDraftData1.LogicalDeleteCode != rcvDraftData2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (rcvDraftData1.RcvDraftNo != rcvDraftData2.RcvDraftNo) resList.Add("RcvDraftNo");
            if (rcvDraftData1.DraftKindCd != rcvDraftData2.DraftKindCd) resList.Add("DraftKindCd");
            if (rcvDraftData1.DraftDivide != rcvDraftData2.DraftDivide) resList.Add("DraftDivide");
            if (rcvDraftData1.Deposit != rcvDraftData2.Deposit) resList.Add("Deposit");
            if (rcvDraftData1.BankAndBranchCd != rcvDraftData2.BankAndBranchCd) resList.Add("BankAndBranchCd");
            if (rcvDraftData1.BankAndBranchNm != rcvDraftData2.BankAndBranchNm) resList.Add("BankAndBranchNm");
            if (rcvDraftData1.SectionCode != rcvDraftData2.SectionCode) resList.Add("SectionCode");
            if (rcvDraftData1.AddUpSecCode != rcvDraftData2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (rcvDraftData1.CustomerCode != rcvDraftData2.CustomerCode) resList.Add("CustomerCode");
            if (rcvDraftData1.CustomerName != rcvDraftData2.CustomerName) resList.Add("CustomerName");
            if (rcvDraftData1.CustomerName2 != rcvDraftData2.CustomerName2) resList.Add("CustomerName2");
            if (rcvDraftData1.CustomerSnm != rcvDraftData2.CustomerSnm) resList.Add("CustomerSnm");
            if (rcvDraftData1.ProcDate != rcvDraftData2.ProcDate) resList.Add("ProcDate");
            if (rcvDraftData1.DraftDrawingDate != rcvDraftData2.DraftDrawingDate) resList.Add("DraftDrawingDate");
            if (rcvDraftData1.ValidityTerm != rcvDraftData2.ValidityTerm) resList.Add("ValidityTerm");
            if (rcvDraftData1.DraftStmntDate != rcvDraftData2.DraftStmntDate) resList.Add("DraftStmntDate");
            if (rcvDraftData1.Outline1 != rcvDraftData2.Outline1) resList.Add("Outline1");
            if (rcvDraftData1.Outline2 != rcvDraftData2.Outline2) resList.Add("Outline2");
            if (rcvDraftData1.AcptAnOdrStatus != rcvDraftData2.AcptAnOdrStatus) resList.Add("AcptAnOdrStatus");
            if (rcvDraftData1.DepositSlipNo != rcvDraftData2.DepositSlipNo) resList.Add("DepositSlipNo");
            if (rcvDraftData1.DepositRowNo != rcvDraftData2.DepositRowNo) resList.Add("DepositRowNo");
            if (rcvDraftData1.DepositDate != rcvDraftData2.DepositDate) resList.Add("DepositDate");
            if (rcvDraftData1.EnterpriseName != rcvDraftData2.EnterpriseName) resList.Add("EnterpriseName");
            if (rcvDraftData1.UpdEmployeeName != rcvDraftData2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (rcvDraftData1.AddUpSecName != rcvDraftData2.AddUpSecName) resList.Add("AddUpSecName");

            return resList;
        }
    }
}
