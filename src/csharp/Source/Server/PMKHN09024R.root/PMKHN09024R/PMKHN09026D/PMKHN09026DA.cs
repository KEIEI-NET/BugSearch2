//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �d����}�X�^�f�[�^�p�����[�^
//                  :   PMKHN09026D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc�@��
// Date             :   2008.4.24
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
    /// public class name:   SupplierWork
    /// <summary>
    ///                      �d���惏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���惏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2008/05/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SupplierWork : IFileHeader
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

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";

        /// <summary>���͋��_�R�[�h</summary>
        private string _inpSectionCode = "";

        /// <summary>�x�����_�R�[�h</summary>
        /// <remarks>�������s�����_</remarks>
        private string _paymentSectionCode = "";

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        private string _supplierNm2 = "";

        /// <summary>�d����h��</summary>
        private string _suppHonorificTitle = "";

        /// <summary>�d����J�i</summary>
        private string _supplierKana = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�������h��</summary>
        private string _orderHonorificTtl = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>�d����X�֔ԍ�</summary>
        private string _supplierPostNo = "";

        /// <summary>�d����Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _supplierAddr1 = "";

        /// <summary>�d����Z��3�i�Ԓn�j</summary>
        private string _supplierAddr3 = "";

        /// <summary>�d����Z��4�i�A�p�[�g���́j</summary>
        private string _supplierAddr4 = "";

        /// <summary>�d����d�b�ԍ�</summary>
        private string _supplierTelNo = "";

        /// <summary>�d����d�b�ԍ�1</summary>
        private string _supplierTelNo1 = "";

        /// <summary>�d����d�b�ԍ�2</summary>
        /// <remarks>FAX�Ŏg�p</remarks>
        private string _supplierTelNo2 = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�����A1:�D��</remarks>
        private Int32 _pureCode;

        /// <summary>�x�����敪�R�[�h</summary>
        /// <remarks>0:���� 1:���� 2:���X��</remarks>
        private Int32 _paymentMonthCode;

        /// <summary>�x�����敪����</summary>
        /// <remarks>�����A�����A���X��</remarks>
        private string _paymentMonthName = "";

        /// <summary>�x����</summary>
        /// <remarks>DD</remarks>
        private Int32 _paymentDay;

        /// <summary>�d�������œ]�ŕ����Q�Ƌ敪</summary>
        /// <remarks>0:�d���݌ɑS�̐ݒ�}�X�^�Q�Ɓ@1:���Ӑ�d�����}�X�^�Q��</remarks>
        private Int32 _suppCTaxLayRefCd;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�d����ېŕ����R�[�h</summary>
        /// <remarks>0:�ې� 1:��ې�</remarks>
        private Int32 _suppCTaxationCd;

        /// <summary>�d�����ƃR�[�h</summary>
        private string _suppEnterpriseCd = "";

        /// <summary>�x����R�[�h</summary>
        private Int32 _payeeCode;

        /// <summary>�d���摮���敪</summary>
        /// <remarks>0:���������,8:�Г������,9:��������</remarks>
        private Int32 _supplierAttributeDiv;

        /// <summary>�d���摍�z�\�����@�敪</summary>
        /// <remarks>�O���z�\�����Ȃ��i�Ŕ����j 1:���z�\������i�ō��݁j</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>�d�������z�\�����@�Q�Ƌ敪</summary>
        /// <remarks>0:�S�̐ݒ�Q�� 1:�d����Q��</remarks>
        private Int32 _stckTtlAmntDspWayRef;

        /// <summary>�x������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _paymentCond;

        /// <summary>�x������</summary>
        private Int32 _paymentTotalDay;

        /// <summary>�x���T�C�g</summary>
        /// <remarks>��`�T�C�g�@180��</remarks>
        private Int32 _paymentSight;

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�d���P���[�������R�[�h</summary>
        private Int32 _stockUnPrcFrcProcCd;

        /// <summary>�d�����z�[�������R�[�h</summary>
        private Int32 _stockMoneyFrcProcCd;

        /// <summary>�d������Œ[�������R�[�h</summary>
        private Int32 _stockCnsTaxFrcProcCd;

        /// <summary>���񊨒�J�n��</summary>
        /// <remarks>01�`31�܂Łi�ȗ��\�j</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>�d������l1</summary>
        private string _supplierNote1 = "";

        /// <summary>�d������l2</summary>
        private string _supplierNote2 = "";

        /// <summary>�d������l3</summary>
        private string _supplierNote3 = "";

        /// <summary>�d������l4</summary>
        private string _supplierNote4 = "";

        /// <summary>�d���S���Җ���</summary>
        /// <remarks>�]�ƈ��}�X�^</remarks>
        private string _stockAgentName = "";

        /// <summary>�Ǘ����_����</summary>
        /// <remarks>���_�}�X�^</remarks>
        private string _mngSectionName = "";

        /// <summary>���͋��_����</summary>
        /// <remarks>���_�}�X�^</remarks>
        private string _inpSectionName = "";

        /// <summary>�x�����_����</summary>
        /// <remarks>���_�}�X�^</remarks>
        private string _paymentSectionName = "";

        /// <summary>�Ǝ햼��</summary>
        /// <remarks>���[�U�[�K�C�h�}�X�^ (���[�U�[�K�C�h�敪=33)</remarks>
        private string _businessTypeName = "";

        /// <summary>�̔��G���A����</summary>
        /// <remarks>���[�U�[�K�C�h�}�X�^ (���[�U�[�K�C�h�敪=21)</remarks>
        private string _salesAreaName = "";

        /// <summary>�x���於��</summary>
        /// <remarks>���Ӑ�R�[�h=�x����R�[�h�ɂ�鎩�Ȍ���</remarks>
        private string _payeeName = "";

        /// <summary>�x���於�̂Q</summary>
        /// <remarks>���Ӑ�R�[�h=�x����R�[�h�ɂ�鎩�Ȍ���</remarks>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        /// <remarks>���Ӑ�R�[�h=�x����R�[�h�ɂ�鎩�Ȍ���</remarks>
        private string _payeeSnm = "";


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

        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  InpSectionCode
        /// <summary>���͋��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSectionCode
        {
            get { return _inpSectionCode; }
            set { _inpSectionCode = value; }
        }

        /// public propaty name  :  PaymentSectionCode
        /// <summary>�x�����_�R�[�h�v���p�e�B</summary>
        /// <value>�������s�����_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentSectionCode
        {
            get { return _paymentSectionCode; }
            set { _paymentSectionCode = value; }
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

        /// public propaty name  :  SuppHonorificTitle
        /// <summary>�d����h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppHonorificTitle
        {
            get { return _suppHonorificTitle; }
            set { _suppHonorificTitle = value; }
        }

        /// public propaty name  :  SupplierKana
        /// <summary>�d����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
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

        /// public propaty name  :  OrderHonorificTtl
        /// <summary>�������h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderHonorificTtl
        {
            get { return _orderHonorificTtl; }
            set { _orderHonorificTtl = value; }
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SupplierPostNo
        /// <summary>�d����X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierPostNo
        {
            get { return _supplierPostNo; }
            set { _supplierPostNo = value; }
        }

        /// public propaty name  :  SupplierAddr1
        /// <summary>�d����Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr1
        {
            get { return _supplierAddr1; }
            set { _supplierAddr1 = value; }
        }

        /// public propaty name  :  SupplierAddr3
        /// <summary>�d����Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr3
        {
            get { return _supplierAddr3; }
            set { _supplierAddr3 = value; }
        }

        /// public propaty name  :  SupplierAddr4
        /// <summary>�d����Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr4
        {
            get { return _supplierAddr4; }
            set { _supplierAddr4 = value; }
        }

        /// public propaty name  :  SupplierTelNo
        /// <summary>�d����d�b�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo
        {
            get { return _supplierTelNo; }
            set { _supplierTelNo = value; }
        }

        /// public propaty name  :  SupplierTelNo1
        /// <summary>�d����d�b�ԍ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����d�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo1
        {
            get { return _supplierTelNo1; }
            set { _supplierTelNo1 = value; }
        }

        /// public propaty name  :  SupplierTelNo2
        /// <summary>�d����d�b�ԍ�2�v���p�e�B</summary>
        /// <value>FAX�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����d�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo2
        {
            get { return _supplierTelNo2; }
            set { _supplierTelNo2 = value; }
        }

        /// public propaty name  :  PureCode
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����A1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  PaymentMonthCode
        /// <summary>�x�����敪�R�[�h�v���p�e�B</summary>
        /// <value>0:���� 1:���� 2:���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentMonthCode
        {
            get { return _paymentMonthCode; }
            set { _paymentMonthCode = value; }
        }

        /// public propaty name  :  PaymentMonthName
        /// <summary>�x�����敪���̃v���p�e�B</summary>
        /// <value>�����A�����A���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentMonthName
        {
            get { return _paymentMonthName; }
            set { _paymentMonthName = value; }
        }

        /// public propaty name  :  PaymentDay
        /// <summary>�x�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentDay
        {
            get { return _paymentDay; }
            set { _paymentDay = value; }
        }

        /// public propaty name  :  SuppCTaxLayRefCd
        /// <summary>�d�������œ]�ŕ����Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�d���݌ɑS�̐ݒ�}�X�^�Q�Ɓ@1:���Ӑ�d�����}�X�^�Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayRefCd
        {
            get { return _suppCTaxLayRefCd; }
            set { _suppCTaxLayRefCd = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SuppCTaxationCd
        /// <summary>�d����ېŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�ې� 1:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����ېŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxationCd
        {
            get { return _suppCTaxationCd; }
            set { _suppCTaxationCd = value; }
        }

        /// public propaty name  :  SuppEnterpriseCd
        /// <summary>�d�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppEnterpriseCd
        {
            get { return _suppEnterpriseCd; }
            set { _suppEnterpriseCd = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  SupplierAttributeDiv
        /// <summary>�d���摮���敪�v���p�e�B</summary>
        /// <value>0:���������,8:�Г������,9:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摮���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierAttributeDiv
        {
            get { return _supplierAttributeDiv; }
            set { _supplierAttributeDiv = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
        /// <value>�O���z�\�����Ȃ��i�Ŕ����j 1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  StckTtlAmntDspWayRef
        /// <summary>�d�������z�\�����@�Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�S�̐ݒ�Q�� 1:�d����Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������z�\�����@�Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StckTtlAmntDspWayRef
        {
            get { return _stckTtlAmntDspWayRef; }
            set { _stckTtlAmntDspWayRef = value; }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>�x�������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
        }

        /// public propaty name  :  PaymentTotalDay
        /// <summary>�x�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentTotalDay
        {
            get { return _paymentTotalDay; }
            set { _paymentTotalDay = value; }
        }

        /// public propaty name  :  PaymentSight
        /// <summary>�x���T�C�g�v���p�e�B</summary>
        /// <value>��`�T�C�g�@180��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���T�C�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentSight
        {
            get { return _paymentSight; }
            set { _paymentSight = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockUnPrcFrcProcCd
        /// <summary>�d���P���[�������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUnPrcFrcProcCd
        {
            get { return _stockUnPrcFrcProcCd; }
            set { _stockUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  StockMoneyFrcProcCd
        /// <summary>�d�����z�[�������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoneyFrcProcCd
        {
            get { return _stockMoneyFrcProcCd; }
            set { _stockMoneyFrcProcCd = value; }
        }

        /// public propaty name  :  StockCnsTaxFrcProcCd
        /// <summary>�d������Œ[�������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCnsTaxFrcProcCd
        {
            get { return _stockCnsTaxFrcProcCd; }
            set { _stockCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>���񊨒�J�n���v���p�e�B</summary>
        /// <value>01�`31�܂Łi�ȗ��\�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񊨒�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  SupplierNote1
        /// <summary>�d������l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNote1
        {
            get { return _supplierNote1; }
            set { _supplierNote1 = value; }
        }

        /// public propaty name  :  SupplierNote2
        /// <summary>�d������l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNote2
        {
            get { return _supplierNote2; }
            set { _supplierNote2 = value; }
        }

        /// public propaty name  :  SupplierNote3
        /// <summary>�d������l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNote3
        {
            get { return _supplierNote3; }
            set { _supplierNote3 = value; }
        }

        /// public propaty name  :  SupplierNote4
        /// <summary>�d������l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNote4
        {
            get { return _supplierNote4; }
            set { _supplierNote4 = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// <value>�]�ƈ��}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  MngSectionName
        /// <summary>�Ǘ����_���̃v���p�e�B</summary>
        /// <value>���_�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }

        /// public propaty name  :  InpSectionName
        /// <summary>���͋��_���̃v���p�e�B</summary>
        /// <value>���_�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSectionName
        {
            get { return _inpSectionName; }
            set { _inpSectionName = value; }
        }

        /// public propaty name  :  PaymentSectionName
        /// <summary>�x�����_���̃v���p�e�B</summary>
        /// <value>���_�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentSectionName
        {
            get { return _paymentSectionName; }
            set { _paymentSectionName = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h�}�X�^ (���[�U�[�K�C�h�敪=33)</value>
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

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h�}�X�^ (���[�U�[�K�C�h�敪=21)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// <value>���Ӑ�R�[�h=�x����R�[�h�ɂ�鎩�Ȍ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於�̂Q�v���p�e�B</summary>
        /// <value>���Ӑ�R�[�h=�x����R�[�h�ɂ�鎩�Ȍ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// <value>���Ӑ�R�[�h=�x����R�[�h�ɂ�鎩�Ȍ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }


        /// <summary>
        /// �d���惏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SupplierWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SupplierWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SupplierWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SupplierWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SupplierWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SupplierWork || graph is ArrayList || graph is SupplierWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SupplierWork).FullName));

            if (graph != null && graph is SupplierWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SupplierWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SupplierWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SupplierWork[])graph).Length;
            }
            else if (graph is SupplierWork)
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
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //�Ǘ����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            //���͋��_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //InpSectionCode
            //�x�����_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PaymentSectionCode
            //�d���於1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm1
            //�d���於2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNm2
            //�d����h��
            serInfo.MemberInfo.Add(typeof(string)); //SuppHonorificTitle
            //�d����J�i
            serInfo.MemberInfo.Add(typeof(string)); //SupplierKana
            //�d���旪��
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //�������h��
            serInfo.MemberInfo.Add(typeof(string)); //OrderHonorificTtl
            //�Ǝ�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //�̔��G���A�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //�d����X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SupplierPostNo
            //�d����Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr1
            //�d����Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr3
            //�d����Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //SupplierAddr4
            //�d����d�b�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo
            //�d����d�b�ԍ�1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo1
            //�d����d�b�ԍ�2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierTelNo2
            //�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PureCode
            //�x�����敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentMonthCode
            //�x�����敪����
            serInfo.MemberInfo.Add(typeof(string)); //PaymentMonthName
            //�x����
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentDay
            //�d�������œ]�ŕ����Q�Ƌ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayRefCd
            //�d�������œ]�ŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxLayCd
            //�d����ېŕ����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppCTaxationCd
            //�d�����ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SuppEnterpriseCd
            //�x����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PayeeCode
            //�d���摮���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierAttributeDiv
            //�d���摍�z�\�����@�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SuppTtlAmntDspWayCd
            //�d�������z�\�����@�Q�Ƌ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StckTtlAmntDspWayRef
            //�x������
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentCond
            //�x������
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentTotalDay
            //�x���T�C�g
            serInfo.MemberInfo.Add(typeof(Int32)); //PaymentSight
            //�d���S���҃R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //�d���P���[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUnPrcFrcProcCd
            //�d�����z�[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoneyFrcProcCd
            //�d������Œ[�������R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //StockCnsTaxFrcProcCd
            //���񊨒�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //NTimeCalcStDate
            //�d������l1
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNote1
            //�d������l2
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNote2
            //�d������l3
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNote3
            //�d������l4
            serInfo.MemberInfo.Add(typeof(string)); //SupplierNote4
            //�d���S���Җ���
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            //�Ǘ����_����
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionName
            //���͋��_����
            serInfo.MemberInfo.Add(typeof(string)); //InpSectionName
            //�x�����_����
            serInfo.MemberInfo.Add(typeof(string)); //PaymentSectionName
            //�Ǝ햼��
            serInfo.MemberInfo.Add(typeof(string)); //BusinessTypeName
            //�̔��G���A����
            serInfo.MemberInfo.Add(typeof(string)); //SalesAreaName
            //�x���於��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName
            //�x���於�̂Q
            serInfo.MemberInfo.Add(typeof(string)); //PayeeName2
            //�x���旪��
            serInfo.MemberInfo.Add(typeof(string)); //PayeeSnm


            serInfo.Serialize(writer, serInfo);
            if (graph is SupplierWork)
            {
                SupplierWork temp = (SupplierWork)graph;

                SetSupplierWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SupplierWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SupplierWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SupplierWork temp in lst)
                {
                    SetSupplierWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SupplierWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 60;

        /// <summary>
        ///  SupplierWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSupplierWork(System.IO.BinaryWriter writer, SupplierWork temp)
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
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //�Ǘ����_�R�[�h
            writer.Write(temp.MngSectionCode);
            //���͋��_�R�[�h
            writer.Write(temp.InpSectionCode);
            //�x�����_�R�[�h
            writer.Write(temp.PaymentSectionCode);
            //�d���於1
            writer.Write(temp.SupplierNm1);
            //�d���於2
            writer.Write(temp.SupplierNm2);
            //�d����h��
            writer.Write(temp.SuppHonorificTitle);
            //�d����J�i
            writer.Write(temp.SupplierKana);
            //�d���旪��
            writer.Write(temp.SupplierSnm);
            //�������h��
            writer.Write(temp.OrderHonorificTtl);
            //�Ǝ�R�[�h
            writer.Write(temp.BusinessTypeCode);
            //�̔��G���A�R�[�h
            writer.Write(temp.SalesAreaCode);
            //�d����X�֔ԍ�
            writer.Write(temp.SupplierPostNo);
            //�d����Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.SupplierAddr1);
            //�d����Z��3�i�Ԓn�j
            writer.Write(temp.SupplierAddr3);
            //�d����Z��4�i�A�p�[�g���́j
            writer.Write(temp.SupplierAddr4);
            //�d����d�b�ԍ�
            writer.Write(temp.SupplierTelNo);
            //�d����d�b�ԍ�1
            writer.Write(temp.SupplierTelNo1);
            //�d����d�b�ԍ�2
            writer.Write(temp.SupplierTelNo2);
            //�����敪
            writer.Write(temp.PureCode);
            //�x�����敪�R�[�h
            writer.Write(temp.PaymentMonthCode);
            //�x�����敪����
            writer.Write(temp.PaymentMonthName);
            //�x����
            writer.Write(temp.PaymentDay);
            //�d�������œ]�ŕ����Q�Ƌ敪
            writer.Write(temp.SuppCTaxLayRefCd);
            //�d�������œ]�ŕ����R�[�h
            writer.Write(temp.SuppCTaxLayCd);
            //�d����ېŕ����R�[�h
            writer.Write(temp.SuppCTaxationCd);
            //�d�����ƃR�[�h
            writer.Write(temp.SuppEnterpriseCd);
            //�x����R�[�h
            writer.Write(temp.PayeeCode);
            //�d���摮���敪
            writer.Write(temp.SupplierAttributeDiv);
            //�d���摍�z�\�����@�敪
            writer.Write(temp.SuppTtlAmntDspWayCd);
            //�d�������z�\�����@�Q�Ƌ敪
            writer.Write(temp.StckTtlAmntDspWayRef);
            //�x������
            writer.Write(temp.PaymentCond);
            //�x������
            writer.Write(temp.PaymentTotalDay);
            //�x���T�C�g
            writer.Write(temp.PaymentSight);
            //�d���S���҃R�[�h
            writer.Write(temp.StockAgentCode);
            //�d���P���[�������R�[�h
            writer.Write(temp.StockUnPrcFrcProcCd);
            //�d�����z�[�������R�[�h
            writer.Write(temp.StockMoneyFrcProcCd);
            //�d������Œ[�������R�[�h
            writer.Write(temp.StockCnsTaxFrcProcCd);
            //���񊨒�J�n��
            writer.Write(temp.NTimeCalcStDate);
            //�d������l1
            writer.Write(temp.SupplierNote1);
            //�d������l2
            writer.Write(temp.SupplierNote2);
            //�d������l3
            writer.Write(temp.SupplierNote3);
            //�d������l4
            writer.Write(temp.SupplierNote4);
            //�d���S���Җ���
            writer.Write(temp.StockAgentName);
            //�Ǘ����_����
            writer.Write(temp.MngSectionName);
            //���͋��_����
            writer.Write(temp.InpSectionName);
            //�x�����_����
            writer.Write(temp.PaymentSectionName);
            //�Ǝ햼��
            writer.Write(temp.BusinessTypeName);
            //�̔��G���A����
            writer.Write(temp.SalesAreaName);
            //�x���於��
            writer.Write(temp.PayeeName);
            //�x���於�̂Q
            writer.Write(temp.PayeeName2);
            //�x���旪��
            writer.Write(temp.PayeeSnm);

        }

        /// <summary>
        ///  SupplierWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SupplierWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SupplierWork GetSupplierWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SupplierWork temp = new SupplierWork();

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
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //�Ǘ����_�R�[�h
            temp.MngSectionCode = reader.ReadString();
            //���͋��_�R�[�h
            temp.InpSectionCode = reader.ReadString();
            //�x�����_�R�[�h
            temp.PaymentSectionCode = reader.ReadString();
            //�d���於1
            temp.SupplierNm1 = reader.ReadString();
            //�d���於2
            temp.SupplierNm2 = reader.ReadString();
            //�d����h��
            temp.SuppHonorificTitle = reader.ReadString();
            //�d����J�i
            temp.SupplierKana = reader.ReadString();
            //�d���旪��
            temp.SupplierSnm = reader.ReadString();
            //�������h��
            temp.OrderHonorificTtl = reader.ReadString();
            //�Ǝ�R�[�h
            temp.BusinessTypeCode = reader.ReadInt32();
            //�̔��G���A�R�[�h
            temp.SalesAreaCode = reader.ReadInt32();
            //�d����X�֔ԍ�
            temp.SupplierPostNo = reader.ReadString();
            //�d����Z��1�i�s���{���s��S�E�����E���j
            temp.SupplierAddr1 = reader.ReadString();
            //�d����Z��3�i�Ԓn�j
            temp.SupplierAddr3 = reader.ReadString();
            //�d����Z��4�i�A�p�[�g���́j
            temp.SupplierAddr4 = reader.ReadString();
            //�d����d�b�ԍ�
            temp.SupplierTelNo = reader.ReadString();
            //�d����d�b�ԍ�1
            temp.SupplierTelNo1 = reader.ReadString();
            //�d����d�b�ԍ�2
            temp.SupplierTelNo2 = reader.ReadString();
            //�����敪
            temp.PureCode = reader.ReadInt32();
            //�x�����敪�R�[�h
            temp.PaymentMonthCode = reader.ReadInt32();
            //�x�����敪����
            temp.PaymentMonthName = reader.ReadString();
            //�x����
            temp.PaymentDay = reader.ReadInt32();
            //�d�������œ]�ŕ����Q�Ƌ敪
            temp.SuppCTaxLayRefCd = reader.ReadInt32();
            //�d�������œ]�ŕ����R�[�h
            temp.SuppCTaxLayCd = reader.ReadInt32();
            //�d����ېŕ����R�[�h
            temp.SuppCTaxationCd = reader.ReadInt32();
            //�d�����ƃR�[�h
            temp.SuppEnterpriseCd = reader.ReadString();
            //�x����R�[�h
            temp.PayeeCode = reader.ReadInt32();
            //�d���摮���敪
            temp.SupplierAttributeDiv = reader.ReadInt32();
            //�d���摍�z�\�����@�敪
            temp.SuppTtlAmntDspWayCd = reader.ReadInt32();
            //�d�������z�\�����@�Q�Ƌ敪
            temp.StckTtlAmntDspWayRef = reader.ReadInt32();
            //�x������
            temp.PaymentCond = reader.ReadInt32();
            //�x������
            temp.PaymentTotalDay = reader.ReadInt32();
            //�x���T�C�g
            temp.PaymentSight = reader.ReadInt32();
            //�d���S���҃R�[�h
            temp.StockAgentCode = reader.ReadString();
            //�d���P���[�������R�[�h
            temp.StockUnPrcFrcProcCd = reader.ReadInt32();
            //�d�����z�[�������R�[�h
            temp.StockMoneyFrcProcCd = reader.ReadInt32();
            //�d������Œ[�������R�[�h
            temp.StockCnsTaxFrcProcCd = reader.ReadInt32();
            //���񊨒�J�n��
            temp.NTimeCalcStDate = reader.ReadInt32();
            //�d������l1
            temp.SupplierNote1 = reader.ReadString();
            //�d������l2
            temp.SupplierNote2 = reader.ReadString();
            //�d������l3
            temp.SupplierNote3 = reader.ReadString();
            //�d������l4
            temp.SupplierNote4 = reader.ReadString();
            //�d���S���Җ���
            temp.StockAgentName = reader.ReadString();
            //�Ǘ����_����
            temp.MngSectionName = reader.ReadString();
            //���͋��_����
            temp.InpSectionName = reader.ReadString();
            //�x�����_����
            temp.PaymentSectionName = reader.ReadString();
            //�Ǝ햼��
            temp.BusinessTypeName = reader.ReadString();
            //�̔��G���A����
            temp.SalesAreaName = reader.ReadString();
            //�x���於��
            temp.PayeeName = reader.ReadString();
            //�x���於�̂Q
            temp.PayeeName2 = reader.ReadString();
            //�x���旪��
            temp.PayeeSnm = reader.ReadString();


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
        /// <returns>SupplierWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SupplierWork temp = GetSupplierWork(reader, serInfo);
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
                    retValue = (SupplierWork[])lst.ToArray(typeof(SupplierWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
