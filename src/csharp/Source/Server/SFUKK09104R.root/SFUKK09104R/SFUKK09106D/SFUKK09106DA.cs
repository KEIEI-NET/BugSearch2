//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����S�̐ݒ�}�X�^�f�[�^�p�����[�^
//                  :   SFUKK09106D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.06.05
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   BillAllStWork
    /// <summary>
    /// 
    ///                      �����S�̐ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����S�̐ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2008/06/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class BillAllStWork : IFileHeader
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
        /// <remarks>���_�R�[�h�i�ԍ��̔ԗp�j�O�͑S�Ћ���</remarks>
        private string _sectionCode = "";

        /// <summary>���_�K�C�h����</summary>
        private string _sectionGuideNm = "";

        /// <summary>���������敪</summary>
        /// <remarks>0:����,1:�K�{,2:�s��</remarks>
        private Int32 _allowanceProcCd;

        /// <summary>�����`�[�C���敪</summary>
        /// <remarks>0:�C����,1:�C���s��</remarks>
        private Int32 _depositSlipMntCd;

        /// <summary>����\��敪</summary>
        /// <remarks>0:�敪 1:���t</remarks>
        private Int32 _collectPlnDiv;

        /// <summary>���Ӑ�����P</summary>
        private Int32 _customerTotalDay1;

        /// <summary>���Ӑ�����Q</summary>
        private Int32 _customerTotalDay2;

        /// <summary>���Ӑ�����R</summary>
        private Int32 _customerTotalDay3;

        /// <summary>���Ӑ�����S</summary>
        private Int32 _customerTotalDay4;

        /// <summary>���Ӑ�����T</summary>
        private Int32 _customerTotalDay5;

        /// <summary>���Ӑ�����U</summary>
        private Int32 _customerTotalDay6;

        /// <summary>���Ӑ�����V</summary>
        private Int32 _customerTotalDay7;

        /// <summary>���Ӑ�����W</summary>
        private Int32 _customerTotalDay8;

        /// <summary>���Ӑ�����X</summary>
        private Int32 _customerTotalDay9;

        /// <summary>���Ӑ�����P�O</summary>
        private Int32 _customerTotalDay10;

        /// <summary>���Ӑ�����P�P</summary>
        private Int32 _customerTotalDay11;

        /// <summary>���Ӑ�����P�Q</summary>
        private Int32 _customerTotalDay12;

        /// <summary>�d��������P</summary>
        private Int32 _supplierTotalDay1;

        /// <summary>�d��������Q</summary>
        private Int32 _supplierTotalDay2;

        /// <summary>�d��������R</summary>
        private Int32 _supplierTotalDay3;

        /// <summary>�d��������S</summary>
        private Int32 _supplierTotalDay4;

        /// <summary>�d��������T</summary>
        private Int32 _supplierTotalDay5;

        /// <summary>�d��������U</summary>
        private Int32 _supplierTotalDay6;

        /// <summary>�d��������V</summary>
        private Int32 _supplierTotalDay7;

        /// <summary>�d��������W</summary>
        private Int32 _supplierTotalDay8;

        /// <summary>�d��������X</summary>
        private Int32 _supplierTotalDay9;

        /// <summary>�d��������P�O</summary>
        private Int32 _supplierTotalDay10;

        /// <summary>�d��������P�P</summary>
        private Int32 _supplierTotalDay11;

        /// <summary>�d��������P�Q</summary>
        private Int32 _supplierTotalDay12;


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>���_�R�[�h�i�ԍ��̔ԗp�j�O�͑S�Ћ���</value>
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

        /// public propaty name  :  AllowanceProcCd
        /// <summary>���������敪�v���p�e�B</summary>
        /// <value>0:����,1:�K�{,2:�s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AllowanceProcCd
        {
            get { return _allowanceProcCd; }
            set { _allowanceProcCd = value; }
        }

        /// public propaty name  :  DepositSlipMntCd
        /// <summary>�����`�[�C���敪�v���p�e�B</summary>
        /// <value>0:�C����,1:�C���s��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�C���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DepositSlipMntCd
        {
            get { return _depositSlipMntCd; }
            set { _depositSlipMntCd = value; }
        }

        /// public propaty name  :  CollectPlnDiv
        /// <summary>����\��敪�v���p�e�B</summary>
        /// <value>0:�敪 1:���t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����\��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CollectPlnDiv
        {
            get { return _collectPlnDiv; }
            set { _collectPlnDiv = value; }
        }

        /// public propaty name  :  CustomerTotalDay1
        /// <summary>���Ӑ�����P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay1
        {
            get { return _customerTotalDay1; }
            set { _customerTotalDay1 = value; }
        }

        /// public propaty name  :  CustomerTotalDay2
        /// <summary>���Ӑ�����Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay2
        {
            get { return _customerTotalDay2; }
            set { _customerTotalDay2 = value; }
        }

        /// public propaty name  :  CustomerTotalDay3
        /// <summary>���Ӑ�����R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay3
        {
            get { return _customerTotalDay3; }
            set { _customerTotalDay3 = value; }
        }

        /// public propaty name  :  CustomerTotalDay4
        /// <summary>���Ӑ�����S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay4
        {
            get { return _customerTotalDay4; }
            set { _customerTotalDay4 = value; }
        }

        /// public propaty name  :  CustomerTotalDay5
        /// <summary>���Ӑ�����T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay5
        {
            get { return _customerTotalDay5; }
            set { _customerTotalDay5 = value; }
        }

        /// public propaty name  :  CustomerTotalDay6
        /// <summary>���Ӑ�����U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay6
        {
            get { return _customerTotalDay6; }
            set { _customerTotalDay6 = value; }
        }

        /// public propaty name  :  CustomerTotalDay7
        /// <summary>���Ӑ�����V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay7
        {
            get { return _customerTotalDay7; }
            set { _customerTotalDay7 = value; }
        }

        /// public propaty name  :  CustomerTotalDay8
        /// <summary>���Ӑ�����W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay8
        {
            get { return _customerTotalDay8; }
            set { _customerTotalDay8 = value; }
        }

        /// public propaty name  :  CustomerTotalDay9
        /// <summary>���Ӑ�����X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay9
        {
            get { return _customerTotalDay9; }
            set { _customerTotalDay9 = value; }
        }

        /// public propaty name  :  CustomerTotalDay10
        /// <summary>���Ӑ�����P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay10
        {
            get { return _customerTotalDay10; }
            set { _customerTotalDay10 = value; }
        }

        /// public propaty name  :  CustomerTotalDay11
        /// <summary>���Ӑ�����P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay11
        {
            get { return _customerTotalDay11; }
            set { _customerTotalDay11 = value; }
        }

        /// public propaty name  :  CustomerTotalDay12
        /// <summary>���Ӑ�����P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�����P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerTotalDay12
        {
            get { return _customerTotalDay12; }
            set { _customerTotalDay12 = value; }
        }

        /// public propaty name  :  SupplierTotalDay1
        /// <summary>�d��������P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay1
        {
            get { return _supplierTotalDay1; }
            set { _supplierTotalDay1 = value; }
        }

        /// public propaty name  :  SupplierTotalDay2
        /// <summary>�d��������Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay2
        {
            get { return _supplierTotalDay2; }
            set { _supplierTotalDay2 = value; }
        }

        /// public propaty name  :  SupplierTotalDay3
        /// <summary>�d��������R�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay3
        {
            get { return _supplierTotalDay3; }
            set { _supplierTotalDay3 = value; }
        }

        /// public propaty name  :  SupplierTotalDay4
        /// <summary>�d��������S�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay4
        {
            get { return _supplierTotalDay4; }
            set { _supplierTotalDay4 = value; }
        }

        /// public propaty name  :  SupplierTotalDay5
        /// <summary>�d��������T�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay5
        {
            get { return _supplierTotalDay5; }
            set { _supplierTotalDay5 = value; }
        }

        /// public propaty name  :  SupplierTotalDay6
        /// <summary>�d��������U�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay6
        {
            get { return _supplierTotalDay6; }
            set { _supplierTotalDay6 = value; }
        }

        /// public propaty name  :  SupplierTotalDay7
        /// <summary>�d��������V�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������V�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay7
        {
            get { return _supplierTotalDay7; }
            set { _supplierTotalDay7 = value; }
        }

        /// public propaty name  :  SupplierTotalDay8
        /// <summary>�d��������W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay8
        {
            get { return _supplierTotalDay8; }
            set { _supplierTotalDay8 = value; }
        }

        /// public propaty name  :  SupplierTotalDay9
        /// <summary>�d��������X�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������X�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay9
        {
            get { return _supplierTotalDay9; }
            set { _supplierTotalDay9 = value; }
        }

        /// public propaty name  :  SupplierTotalDay10
        /// <summary>�d��������P�O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������P�O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay10
        {
            get { return _supplierTotalDay10; }
            set { _supplierTotalDay10 = value; }
        }

        /// public propaty name  :  SupplierTotalDay11
        /// <summary>�d��������P�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������P�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay11
        {
            get { return _supplierTotalDay11; }
            set { _supplierTotalDay11 = value; }
        }

        /// public propaty name  :  SupplierTotalDay12
        /// <summary>�d��������P�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d��������P�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierTotalDay12
        {
            get { return _supplierTotalDay12; }
            set { _supplierTotalDay12 = value; }
        }


        /// <summary>
        /// �����S�̐ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>BillAllStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BillAllStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BillAllStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>BillAllStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   BillAllStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class BillAllStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BillAllStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  BillAllStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is BillAllStWork || graph is ArrayList || graph is BillAllStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(BillAllStWork).FullName));

            if (graph != null && graph is BillAllStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.BillAllStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is BillAllStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((BillAllStWork[])graph).Length;
            }
            else if (graph is BillAllStWork)
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
            serInfo.MemberInfo.Add(typeof(byte[])); //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���_�K�C�h����
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //���������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //AllowanceProcCd
            //�����`�[�C���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DepositSlipMntCd
            //����\��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectPlnDiv
            //���Ӑ�����P
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay1
            //���Ӑ�����Q
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay2
            //���Ӑ�����R
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay3
            //���Ӑ�����S
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay4
            //���Ӑ�����T
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay5
            //���Ӑ�����U
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay6
            //���Ӑ�����V
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay7
            //���Ӑ�����W
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay8
            //���Ӑ�����X
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay9
            //���Ӑ�����P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay10
            //���Ӑ�����P�P
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay11
            //���Ӑ�����P�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTotalDay12
            //�d��������P
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay1
            //�d��������Q
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay2
            //�d��������R
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay3
            //�d��������S
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay4
            //�d��������T
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay5
            //�d��������U
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay6
            //�d��������V
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay7
            //�d��������W
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay8
            //�d��������X
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay9
            //�d��������P�O
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay10
            //�d��������P�P
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay11
            //�d��������P�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierTotalDay12


            serInfo.Serialize(writer, serInfo);
            if (graph is BillAllStWork)
            {
                BillAllStWork temp = (BillAllStWork)graph;

                SetBillAllStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is BillAllStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((BillAllStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (BillAllStWork temp in lst)
                {
                    SetBillAllStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// BillAllStWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 37;

        /// <summary>
        ///  BillAllStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BillAllStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetBillAllStWork(System.IO.BinaryWriter writer, BillAllStWork temp)
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
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //���������敪
            writer.Write(temp.AllowanceProcCd);
            //�����`�[�C���敪
            writer.Write(temp.DepositSlipMntCd);
            //����\��敪
            writer.Write(temp.CollectPlnDiv);
            //���Ӑ�����P
            writer.Write(temp.CustomerTotalDay1);
            //���Ӑ�����Q
            writer.Write(temp.CustomerTotalDay2);
            //���Ӑ�����R
            writer.Write(temp.CustomerTotalDay3);
            //���Ӑ�����S
            writer.Write(temp.CustomerTotalDay4);
            //���Ӑ�����T
            writer.Write(temp.CustomerTotalDay5);
            //���Ӑ�����U
            writer.Write(temp.CustomerTotalDay6);
            //���Ӑ�����V
            writer.Write(temp.CustomerTotalDay7);
            //���Ӑ�����W
            writer.Write(temp.CustomerTotalDay8);
            //���Ӑ�����X
            writer.Write(temp.CustomerTotalDay9);
            //���Ӑ�����P�O
            writer.Write(temp.CustomerTotalDay10);
            //���Ӑ�����P�P
            writer.Write(temp.CustomerTotalDay11);
            //���Ӑ�����P�Q
            writer.Write(temp.CustomerTotalDay12);
            //�d��������P
            writer.Write(temp.SupplierTotalDay1);
            //�d��������Q
            writer.Write(temp.SupplierTotalDay2);
            //�d��������R
            writer.Write(temp.SupplierTotalDay3);
            //�d��������S
            writer.Write(temp.SupplierTotalDay4);
            //�d��������T
            writer.Write(temp.SupplierTotalDay5);
            //�d��������U
            writer.Write(temp.SupplierTotalDay6);
            //�d��������V
            writer.Write(temp.SupplierTotalDay7);
            //�d��������W
            writer.Write(temp.SupplierTotalDay8);
            //�d��������X
            writer.Write(temp.SupplierTotalDay9);
            //�d��������P�O
            writer.Write(temp.SupplierTotalDay10);
            //�d��������P�P
            writer.Write(temp.SupplierTotalDay11);
            //�d��������P�Q
            writer.Write(temp.SupplierTotalDay12);

        }

        /// <summary>
        ///  BillAllStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>BillAllStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BillAllStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private BillAllStWork GetBillAllStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            BillAllStWork temp = new BillAllStWork();

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
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���_�K�C�h����
            temp.SectionGuideNm = reader.ReadString();
            //���������敪
            temp.AllowanceProcCd = reader.ReadInt32();
            //�����`�[�C���敪
            temp.DepositSlipMntCd = reader.ReadInt32();
            //����\��敪
            temp.CollectPlnDiv = reader.ReadInt32();
            //���Ӑ�����P
            temp.CustomerTotalDay1 = reader.ReadInt32();
            //���Ӑ�����Q
            temp.CustomerTotalDay2 = reader.ReadInt32();
            //���Ӑ�����R
            temp.CustomerTotalDay3 = reader.ReadInt32();
            //���Ӑ�����S
            temp.CustomerTotalDay4 = reader.ReadInt32();
            //���Ӑ�����T
            temp.CustomerTotalDay5 = reader.ReadInt32();
            //���Ӑ�����U
            temp.CustomerTotalDay6 = reader.ReadInt32();
            //���Ӑ�����V
            temp.CustomerTotalDay7 = reader.ReadInt32();
            //���Ӑ�����W
            temp.CustomerTotalDay8 = reader.ReadInt32();
            //���Ӑ�����X
            temp.CustomerTotalDay9 = reader.ReadInt32();
            //���Ӑ�����P�O
            temp.CustomerTotalDay10 = reader.ReadInt32();
            //���Ӑ�����P�P
            temp.CustomerTotalDay11 = reader.ReadInt32();
            //���Ӑ�����P�Q
            temp.CustomerTotalDay12 = reader.ReadInt32();
            //�d��������P
            temp.SupplierTotalDay1 = reader.ReadInt32();
            //�d��������Q
            temp.SupplierTotalDay2 = reader.ReadInt32();
            //�d��������R
            temp.SupplierTotalDay3 = reader.ReadInt32();
            //�d��������S
            temp.SupplierTotalDay4 = reader.ReadInt32();
            //�d��������T
            temp.SupplierTotalDay5 = reader.ReadInt32();
            //�d��������U
            temp.SupplierTotalDay6 = reader.ReadInt32();
            //�d��������V
            temp.SupplierTotalDay7 = reader.ReadInt32();
            //�d��������W
            temp.SupplierTotalDay8 = reader.ReadInt32();
            //�d��������X
            temp.SupplierTotalDay9 = reader.ReadInt32();
            //�d��������P�O
            temp.SupplierTotalDay10 = reader.ReadInt32();
            //�d��������P�P
            temp.SupplierTotalDay11 = reader.ReadInt32();
            //�d��������P�Q
            temp.SupplierTotalDay12 = reader.ReadInt32();


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
        /// <returns>BillAllStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BillAllStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                BillAllStWork temp = GetBillAllStWork(reader, serInfo);
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
                    retValue = (BillAllStWork[])lst.ToArray(typeof(BillAllStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}
