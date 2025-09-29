//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ώ�`��������
// �v���O�����T�v   : �I�v�V�����t���O�i��`�j���u����v�̏ꍇ�ɖ��������߂�����`�f�[�^�ɑ΂��ăf�[�^�̏������ݏ������s���B
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
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PayDraftDataWork
    /// <summary>
    ///                      �x����`�f�[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x����`�f�[�^���[�N�w�b�_�t�@�C��</br>
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
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PayDraftDataWork : IFileHeader
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

        /// <summary>�x����`�ԍ�</summary>
        private string _payDraftNo = "";

        /// <summary>��`���</summary>
        /// <remarks>0:�莝 1:�旧 2:���� 3:���n 4:�S�� 5:�s�n 6:�x�� 7:��t 9:����</remarks>
        private Int32 _draftKindCd;

        /// <summary>��`�敪</summary>
        /// <remarks>0:���U 1:���U�@���������U�敪</remarks>
        private Int32 _draftDivide;

        /// <summary>�x�����z</summary>
        private Int64 _payment;

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

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        private string _supplierNm2 = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

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

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�x���`�[�ԍ�</summary>
        private Int32 _paymentSlipNo;

        /// <summary>�x���s�ԍ�</summary>
        /// <remarks>���x���ݒ�����ޢ��`��̐ݒ�ԍ����</remarks>
        private Int32 _paymentRowNo;

        /// <summary>�x�����t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _paymentDate;


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

        /// public propaty name  :  PayDraftNo
        /// <summary>�x����`�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����`�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayDraftNo
        {
            get { return _payDraftNo; }
            set { _payDraftNo = value; }
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

        /// public propaty name  :  Payment
        /// <summary>�x�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>�d���於2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
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

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d��,1:����,2:�����@�i�󒍃X�e�[�^�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  PaymentSlipNo
        /// <summary>�x���`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentSlipNo
        {
            get { return _paymentSlipNo; }
            set { _paymentSlipNo = value; }
        }

        /// public propaty name  :  PaymentRowNo
        /// <summary>�x���s�ԍ��v���p�e�B</summary>
        /// <value>���x���ݒ�����ޢ��`��̐ݒ�ԍ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���s�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentRowNo
        {
            get { return _paymentRowNo; }
            set { _paymentRowNo = value; }
        }

        /// public propaty name  :  PaymentDate
        /// <summary>�x�����t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; }
        }


        /// <summary>
        /// �x����`�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PayDraftDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PayDraftDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PayDraftDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PayDraftDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PayDraftDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PayDraftDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PayDraftDataWork || graph is ArrayList || graph is PayDraftDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PayDraftDataWork).FullName));

            if (graph != null && graph is PayDraftDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PayDraftDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PayDraftDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PayDraftDataWork[])graph).Length;
            }
            else if (graph is PayDraftDataWork)
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
            //�x����`�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PayDraftNo
            //��`���
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftKindCd
            //��`�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DraftDivide
            //�x�����z
            serInfo.MemberInfo.Add(typeof(Int64)); //Payment
            //��s�E�x�X�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BankAndBranchCd
            //��s�E�x�X����
            serInfo.MemberInfo.Add(typeof(string)); //BankAndBranchNm
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //�v�㋒�_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�d���於1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
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
            //�d���`��
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //�x���`�[�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSlipNo
            //�x���s�ԍ�
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentRowNo
            //�x�����t
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDate


            serInfo.Serialize(writer, serInfo);
            if (graph is PayDraftDataWork)
            {
                PayDraftDataWork temp = (PayDraftDataWork)graph;

                SetPayDraftDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PayDraftDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PayDraftDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PayDraftDataWork temp in lst)
                {
                    SetPayDraftDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PayDraftDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 30;

        /// <summary>
        ///  PayDraftDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPayDraftDataWork(System.IO.BinaryWriter writer, PayDraftDataWork temp)
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
            //�x����`�ԍ�
            writer.Write(temp.PayDraftNo);
            //��`���
            writer.Write(temp.DraftKindCd);
            //��`�敪
            writer.Write(temp.DraftDivide);
            //�x�����z
            writer.Write(temp.Payment);
            //��s�E�x�X�R�[�h
            writer.Write(temp.BankAndBranchCd);
            //��s�E�x�X����
            writer.Write(temp.BankAndBranchNm);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //�v�㋒�_�R�[�h
            writer.Write(temp.AddUpSecCode);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�d���於1
            writer.Write(temp.SupplierNm1);
            //�d���於2
            writer.Write(temp.SupplierNm2);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
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
            //�d���`��
            writer.Write(temp.SupplierFormal);
            //�x���`�[�ԍ�
            writer.Write(temp.PaymentSlipNo);
            //�x���s�ԍ�
            writer.Write(temp.PaymentRowNo);
            //�x�����t
            writer.Write((Int64)temp.PaymentDate.Ticks);

        }

        /// <summary>
        ///  PayDraftDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PayDraftDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PayDraftDataWork GetPayDraftDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PayDraftDataWork temp = new PayDraftDataWork();

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
            //�x����`�ԍ�
            temp.PayDraftNo = reader.ReadString();
            //��`���
            temp.DraftKindCd = reader.ReadInt32();
            //��`�敪
            temp.DraftDivide = reader.ReadInt32();
            //�x�����z
            temp.Payment = reader.ReadInt64();
            //��s�E�x�X�R�[�h
            temp.BankAndBranchCd = reader.ReadInt32();
            //��s�E�x�X����
            temp.BankAndBranchNm = reader.ReadString();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //�v�㋒�_�R�[�h
            temp.AddUpSecCode = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�d���於1
            temp.SupplierNm1 = reader.ReadString();
            //�d���於2
            temp.SupplierNm2 = reader.ReadString();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
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
            //�d���`��
            temp.SupplierFormal = reader.ReadInt32();
            //�x���`�[�ԍ�
            temp.PaymentSlipNo = reader.ReadInt32();
            //�x���s�ԍ�
            temp.PaymentRowNo = reader.ReadInt32();
            //�x�����t
            temp.PaymentDate = new DateTime(reader.ReadInt64());


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
        /// <returns>PayDraftDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PayDraftDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PayDraftDataWork temp = GetPayDraftDataWork(reader, serInfo);
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
                    retValue = (PayDraftDataWork[])lst.ToArray(typeof(PayDraftDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
