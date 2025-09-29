//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�f�[�^�����e�i���X
// �v���O�����T�v   : ��`�f�[�^�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/04/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RcvDraftDataWork
    /// <summary>
    ///                      ����`�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����`�f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/4/24</br>
    /// <br>Genarated Date   :   2010/04/26  (CSharp File Generated Date)</br>
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
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RcvDraftDataWork : IFileHeader
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


        /// <summary>
        /// ����`�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RcvDraftDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RcvDraftDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>RcvDraftDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   RcvDraftDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class RcvDraftDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RcvDraftDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RcvDraftDataWork || graph is ArrayList || graph is RcvDraftDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(RcvDraftDataWork).FullName));

            if (graph != null && graph is RcvDraftDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RcvDraftDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RcvDraftDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RcvDraftDataWork[])graph).Length;
            }
            else if (graph is RcvDraftDataWork)
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
            //����`�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //RcvDraftNo
            //��`���
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftKindCd
            //��`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
            //�������z
            serInfo.MemberInfo.Add(typeof(Int64)); //Deposit
            //��s�E�x�X�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BankAndBranchCd
            //��s�E�x�X����
            serInfo.MemberInfo.Add(typeof(string)); //BankAndBranchNm
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //���Ӑ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //���Ӑ於��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName
            //���Ӑ於��2
            serInfo.MemberInfo.Add(typeof(string)); //CustomerName2
            //���Ӑ旪��
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //������
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcDate
            //��`�U�o��
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDrawingDate
            //�L������
            serInfo.MemberInfo.Add(typeof(Int32)); //ValidityTerm
            //��`���ϓ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftStmntDate
            //�`�[�E�v1
            serInfo.MemberInfo.Add(typeof(string)); //Outline1
            //�`�[�E�v2
            serInfo.MemberInfo.Add(typeof(string)); //Outline2
            //�󒍃X�e�[�^�X
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //�����`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositSlipNo
            //�����s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositRowNo
            //�������t
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositDate


            serInfo.Serialize(writer, serInfo);
            if (graph is RcvDraftDataWork)
            {
                RcvDraftDataWork temp = (RcvDraftDataWork)graph;

                SetRcvDraftDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RcvDraftDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RcvDraftDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RcvDraftDataWork temp in lst)
                {
                    SetRcvDraftDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RcvDraftDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 30;

        /// <summary>
        ///  RcvDraftDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetRcvDraftDataWork(System.IO.BinaryWriter writer, RcvDraftDataWork temp)
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
            //����`�ԍ�
            writer.Write(temp.RcvDraftNo);
            //��`���
            writer.Write(temp.DraftKindCd);
            //��`�敪
            writer.Write(temp.DraftDivide);
            //�������z
            writer.Write(temp.Deposit);
            //��s�E�x�X�R�[�h
            writer.Write(temp.BankAndBranchCd);
            //��s�E�x�X����
            writer.Write(temp.BankAndBranchNm);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //���Ӑ�R�[�h
            writer.Write(temp.CustomerCode);
            //���Ӑ於��
            writer.Write(temp.CustomerName);
            //���Ӑ於��2
            writer.Write(temp.CustomerName2);
            //���Ӑ旪��
            writer.Write(temp.CustomerSnm);
            //������
            writer.Write(temp.ProcDate);
            //��`�U�o��
            writer.Write((Int64)temp.DraftDrawingDate.Ticks);
            //�L������
            writer.Write(temp.ValidityTerm);
            //��`���ϓ�
            writer.Write(temp.DraftStmntDate);
            //�`�[�E�v1
            writer.Write(temp.Outline1);
            //�`�[�E�v2
            writer.Write(temp.Outline2);
            //�󒍃X�e�[�^�X
            writer.Write(temp.AcptAnOdrStatus);
            //�����`�[�ԍ�
            writer.Write(temp.DepositSlipNo);
            //�����s�ԍ�
            writer.Write(temp.DepositRowNo);
            //�������t
            writer.Write((Int64)temp.DepositDate.Ticks);

        }

        /// <summary>
        ///  RcvDraftDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>RcvDraftDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private RcvDraftDataWork GetRcvDraftDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            RcvDraftDataWork temp = new RcvDraftDataWork();

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
            //����`�ԍ�
            temp.RcvDraftNo = reader.ReadString();
            //��`���
            temp.DraftKindCd = reader.ReadInt32();
            //��`�敪
            temp.DraftDivide = reader.ReadInt32();
            //�������z
            temp.Deposit = reader.ReadInt64();
            //��s�E�x�X�R�[�h
            temp.BankAndBranchCd = reader.ReadInt32();
            //��s�E�x�X����
            temp.BankAndBranchNm = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //���Ӑ�R�[�h
            temp.CustomerCode = reader.ReadInt32();
            //���Ӑ於��
            temp.CustomerName = reader.ReadString();
            //���Ӑ於��2
            temp.CustomerName2 = reader.ReadString();
            //���Ӑ旪��
            temp.CustomerSnm = reader.ReadString();
            //������
            temp.ProcDate = reader.ReadInt32();
            //��`�U�o��
            temp.DraftDrawingDate = new DateTime(reader.ReadInt64());
            //�L������
            temp.ValidityTerm = reader.ReadInt32();
            //��`���ϓ�
            temp.DraftStmntDate = reader.ReadInt32();
            //�`�[�E�v1
            temp.Outline1 = reader.ReadString();
            //�`�[�E�v2
            temp.Outline2 = reader.ReadString();
            //�󒍃X�e�[�^�X
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //�����`�[�ԍ�
            temp.DepositSlipNo = reader.ReadInt32();
            //�����s�ԍ�
            temp.DepositRowNo = reader.ReadInt32();
            //�������t
            temp.DepositDate = new DateTime(reader.ReadInt64());


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
        /// <returns>RcvDraftDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   RcvDraftDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RcvDraftDataWork temp = GetRcvDraftDataWork(reader, serInfo);
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
                    retValue = (RcvDraftDataWork[])lst.ToArray(typeof(RcvDraftDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }




}
