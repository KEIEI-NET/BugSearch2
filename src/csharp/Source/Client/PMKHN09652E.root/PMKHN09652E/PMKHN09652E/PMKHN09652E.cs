//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ڕW�ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ڕW�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignTarget
    /// <summary>
    ///                      �L�����y�[���ڕW�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���ڕW�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignTarget
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

        /// <summary>�L�����y�[���R�[�h</summary>
        /// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
        private Int32 _campaignCode;

        /// <summary>�ڕW�Δ�敪</summary>
        /// <remarks>10:���_,22:���_+�]�ƈ�,30:���_+���Ӑ�,32:���_+�̔��ر,44:���_+�̔��敪,50:���_+��ٰ�ߺ���,60:���_+BL����</remarks>
        private Int32 _targetContrastCd;

        /// <summary>�]�ƈ��敪</summary>
        /// <remarks>10:�̔��S���� 20:��t�S���� 30:���͒S����</remarks>
        private Int32 _employeeDivCd;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�̔��G���A�R�[�h</summary>
        /// <remarks>�n��R�[�h</remarks>
        private Int32 _salesAreaCode;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�̔��敪�R�[�h</summary>
        private Int32 _salesCode;

        /// <summary>����ڕW���z1</summary>
        /// <remarks>1��</remarks>
        private Int64 _salesTargetMoney1;

        /// <summary>����ڕW���z2</summary>
        /// <remarks>2��</remarks>
        private Int64 _salesTargetMoney2;

        /// <summary>����ڕW���z3</summary>
        /// <remarks>3��</remarks>
        private Int64 _salesTargetMoney3;

        /// <summary>����ڕW���z4</summary>
        /// <remarks>4��</remarks>
        private Int64 _salesTargetMoney4;

        /// <summary>����ڕW���z5</summary>
        /// <remarks>5��</remarks>
        private Int64 _salesTargetMoney5;

        /// <summary>����ڕW���z6</summary>
        /// <remarks>6��</remarks>
        private Int64 _salesTargetMoney6;

        /// <summary>����ڕW���z7</summary>
        /// <remarks>7��</remarks>
        private Int64 _salesTargetMoney7;

        /// <summary>����ڕW���z8</summary>
        /// <remarks>8��</remarks>
        private Int64 _salesTargetMoney8;

        /// <summary>����ڕW���z9</summary>
        /// <remarks>9��</remarks>
        private Int64 _salesTargetMoney9;

        /// <summary>����ڕW���z10</summary>
        /// <remarks>10��</remarks>
        private Int64 _salesTargetMoney10;

        /// <summary>����ڕW���z11</summary>
        /// <remarks>11��</remarks>
        private Int64 _salesTargetMoney11;

        /// <summary>����ڕW���z12</summary>
        /// <remarks>12��</remarks>
        private Int64 _salesTargetMoney12;

        /// <summary>���Ԕ���ڕW���z</summary>
        private Int64 _monthlySalesTarget;

        /// <summary>������ԖڕW���z</summary>
        private Int64 _termSalesTarget;

        /// <summary>����ڕW�e���z1</summary>
        /// <remarks>1��</remarks>
        private Int64 _salesTargetProfit1;

        /// <summary>����ڕW�e���z2</summary>
        /// <remarks>2��</remarks>
        private Int64 _salesTargetProfit2;

        /// <summary>����ڕW�e���z3</summary>
        /// <remarks>3��</remarks>
        private Int64 _salesTargetProfit3;

        /// <summary>����ڕW�e���z4</summary>
        /// <remarks>4��</remarks>
        private Int64 _salesTargetProfit4;

        /// <summary>����ڕW�e���z5</summary>
        /// <remarks>5��</remarks>
        private Int64 _salesTargetProfit5;

        /// <summary>����ڕW�e���z6</summary>
        /// <remarks>6��</remarks>
        private Int64 _salesTargetProfit6;

        /// <summary>����ڕW�e���z7</summary>
        /// <remarks>7��</remarks>
        private Int64 _salesTargetProfit7;

        /// <summary>����ڕW�e���z8</summary>
        /// <remarks>8��</remarks>
        private Int64 _salesTargetProfit8;

        /// <summary>����ڕW�e���z9</summary>
        /// <remarks>9��</remarks>
        private Int64 _salesTargetProfit9;

        /// <summary>����ڕW�e���z10</summary>
        /// <remarks>10��</remarks>
        private Int64 _salesTargetProfit10;

        /// <summary>����ڕW�e���z11</summary>
        /// <remarks>11��</remarks>
        private Int64 _salesTargetProfit11;

        /// <summary>����ڕW�e���z12</summary>
        /// <remarks>12��</remarks>
        private Int64 _salesTargetProfit12;

        /// <summary>���㌎�ԖڕW�e���z</summary>
        private Int64 _monthlySalesTargetProfit;

        /// <summary>������ԖڕW�e���z</summary>
        private Int64 _termSalesTargetProfit;

        /// <summary>����ڕW����1</summary>
        /// <remarks>1��</remarks>
        private Double _salesTargetCount1;

        /// <summary>����ڕW����2</summary>
        /// <remarks>2��</remarks>
        private Double _salesTargetCount2;

        /// <summary>����ڕW����3</summary>
        /// <remarks>3��</remarks>
        private Double _salesTargetCount3;

        /// <summary>����ڕW����4</summary>
        /// <remarks>4��</remarks>
        private Double _salesTargetCount4;

        /// <summary>����ڕW����5</summary>
        /// <remarks>5��</remarks>
        private Double _salesTargetCount5;

        /// <summary>����ڕW����6</summary>
        /// <remarks>6��</remarks>
        private Double _salesTargetCount6;

        /// <summary>����ڕW����7</summary>
        /// <remarks>7��</remarks>
        private Double _salesTargetCount7;

        /// <summary>����ڕW����8</summary>
        /// <remarks>8��</remarks>
        private Double _salesTargetCount8;

        /// <summary>����ڕW����9</summary>
        /// <remarks>9��</remarks>
        private Double _salesTargetCount9;

        /// <summary>����ڕW����10</summary>
        /// <remarks>10��</remarks>
        private Double _salesTargetCount10;

        /// <summary>����ڕW����11</summary>
        /// <remarks>11��</remarks>
        private Double _salesTargetCount11;

        /// <summary>����ڕW����12</summary>
        /// <remarks>12��</remarks>
        private Double _salesTargetCount12;

        /// <summary>���㌎�ԖڕW����</summary>
        private Double _monthlySalesTargetCount;

        /// <summary>������ԖڕW����</summary>
        private Double _termSalesTargetCount;

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

        /// public propaty name  :  CampaignCode
        /// <summary>�L�����y�[���R�[�h�v���p�e�B</summary>
        /// <value>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCode
        {
            get { return _campaignCode; }
            set { _campaignCode = value; }
        }

        /// public propaty name  :  TargetContrastCd
        /// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
        /// <value>10:���_,22:���_+�]�ƈ�,30:���_+���Ӑ�,32:���_+�̔��ر,44:���_+�̔��敪,50:���_+��ٰ�ߺ���,60:���_+BL����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ڕW�Δ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get { return _targetContrastCd; }
            set { _targetContrastCd = value; }
        }

        /// public propaty name  :  EmployeeDivCd
        /// <summary>�]�ƈ��敪�v���p�e�B</summary>
        /// <value>10:�̔��S���� 20:��t�S���� 30:���͒S����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EmployeeDivCd
        {
            get { return _employeeDivCd; }
            set { _employeeDivCd = value; }
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

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
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

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// <value>�n��R�[�h</value>
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

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
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

        /// public propaty name  :  SalesTargetMoney1
        /// <summary>����ڕW���z1�v���p�e�B</summary>
        /// <value>1��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney1
        {
            get { return _salesTargetMoney1; }
            set { _salesTargetMoney1 = value; }
        }

        /// public propaty name  :  SalesTargetMoney2
        /// <summary>����ڕW���z2�v���p�e�B</summary>
        /// <value>2��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney2
        {
            get { return _salesTargetMoney2; }
            set { _salesTargetMoney2 = value; }
        }

        /// public propaty name  :  SalesTargetMoney3
        /// <summary>����ڕW���z3�v���p�e�B</summary>
        /// <value>3��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney3
        {
            get { return _salesTargetMoney3; }
            set { _salesTargetMoney3 = value; }
        }

        /// public propaty name  :  SalesTargetMoney4
        /// <summary>����ڕW���z4�v���p�e�B</summary>
        /// <value>4��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney4
        {
            get { return _salesTargetMoney4; }
            set { _salesTargetMoney4 = value; }
        }

        /// public propaty name  :  SalesTargetMoney5
        /// <summary>����ڕW���z5�v���p�e�B</summary>
        /// <value>5��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney5
        {
            get { return _salesTargetMoney5; }
            set { _salesTargetMoney5 = value; }
        }

        /// public propaty name  :  SalesTargetMoney6
        /// <summary>����ڕW���z6�v���p�e�B</summary>
        /// <value>6��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney6
        {
            get { return _salesTargetMoney6; }
            set { _salesTargetMoney6 = value; }
        }

        /// public propaty name  :  SalesTargetMoney7
        /// <summary>����ڕW���z7�v���p�e�B</summary>
        /// <value>7��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney7
        {
            get { return _salesTargetMoney7; }
            set { _salesTargetMoney7 = value; }
        }

        /// public propaty name  :  SalesTargetMoney8
        /// <summary>����ڕW���z8�v���p�e�B</summary>
        /// <value>8��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney8
        {
            get { return _salesTargetMoney8; }
            set { _salesTargetMoney8 = value; }
        }

        /// public propaty name  :  SalesTargetMoney9
        /// <summary>����ڕW���z9�v���p�e�B</summary>
        /// <value>9��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney9
        {
            get { return _salesTargetMoney9; }
            set { _salesTargetMoney9 = value; }
        }

        /// public propaty name  :  SalesTargetMoney10
        /// <summary>����ڕW���z10�v���p�e�B</summary>
        /// <value>10��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney10
        {
            get { return _salesTargetMoney10; }
            set { _salesTargetMoney10 = value; }
        }

        /// public propaty name  :  SalesTargetMoney11
        /// <summary>����ڕW���z11�v���p�e�B</summary>
        /// <value>11��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney11
        {
            get { return _salesTargetMoney11; }
            set { _salesTargetMoney11 = value; }
        }

        /// public propaty name  :  SalesTargetMoney12
        /// <summary>����ڕW���z12�v���p�e�B</summary>
        /// <value>12��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney12
        {
            get { return _salesTargetMoney12; }
            set { _salesTargetMoney12 = value; }
        }

        /// public propaty name  :  MonthlySalesTarget
        /// <summary>���Ԕ���ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ԕ���ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTarget
        {
            get { return _monthlySalesTarget; }
            set { _monthlySalesTarget = value; }
        }

        /// public propaty name  :  TermSalesTarget
        /// <summary>������ԖڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTarget
        {
            get { return _termSalesTarget; }
            set { _termSalesTarget = value; }
        }

        /// public propaty name  :  SalesTargetProfit1
        /// <summary>����ڕW�e���z1�v���p�e�B</summary>
        /// <value>1��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit1
        {
            get { return _salesTargetProfit1; }
            set { _salesTargetProfit1 = value; }
        }

        /// public propaty name  :  SalesTargetProfit2
        /// <summary>����ڕW�e���z2�v���p�e�B</summary>
        /// <value>2��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit2
        {
            get { return _salesTargetProfit2; }
            set { _salesTargetProfit2 = value; }
        }

        /// public propaty name  :  SalesTargetProfit3
        /// <summary>����ڕW�e���z3�v���p�e�B</summary>
        /// <value>3��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit3
        {
            get { return _salesTargetProfit3; }
            set { _salesTargetProfit3 = value; }
        }

        /// public propaty name  :  SalesTargetProfit4
        /// <summary>����ڕW�e���z4�v���p�e�B</summary>
        /// <value>4��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit4
        {
            get { return _salesTargetProfit4; }
            set { _salesTargetProfit4 = value; }
        }

        /// public propaty name  :  SalesTargetProfit5
        /// <summary>����ڕW�e���z5�v���p�e�B</summary>
        /// <value>5��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit5
        {
            get { return _salesTargetProfit5; }
            set { _salesTargetProfit5 = value; }
        }

        /// public propaty name  :  SalesTargetProfit6
        /// <summary>����ڕW�e���z6�v���p�e�B</summary>
        /// <value>6��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit6
        {
            get { return _salesTargetProfit6; }
            set { _salesTargetProfit6 = value; }
        }

        /// public propaty name  :  SalesTargetProfit7
        /// <summary>����ڕW�e���z7�v���p�e�B</summary>
        /// <value>7��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit7
        {
            get { return _salesTargetProfit7; }
            set { _salesTargetProfit7 = value; }
        }

        /// public propaty name  :  SalesTargetProfit8
        /// <summary>����ڕW�e���z8�v���p�e�B</summary>
        /// <value>8��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit8
        {
            get { return _salesTargetProfit8; }
            set { _salesTargetProfit8 = value; }
        }

        /// public propaty name  :  SalesTargetProfit9
        /// <summary>����ڕW�e���z9�v���p�e�B</summary>
        /// <value>9��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit9
        {
            get { return _salesTargetProfit9; }
            set { _salesTargetProfit9 = value; }
        }

        /// public propaty name  :  SalesTargetProfit10
        /// <summary>����ڕW�e���z10�v���p�e�B</summary>
        /// <value>10��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit10
        {
            get { return _salesTargetProfit10; }
            set { _salesTargetProfit10 = value; }
        }

        /// public propaty name  :  SalesTargetProfit11
        /// <summary>����ڕW�e���z11�v���p�e�B</summary>
        /// <value>11��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit11
        {
            get { return _salesTargetProfit11; }
            set { _salesTargetProfit11 = value; }
        }

        /// public propaty name  :  SalesTargetProfit12
        /// <summary>����ڕW�e���z12�v���p�e�B</summary>
        /// <value>12��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit12
        {
            get { return _salesTargetProfit12; }
            set { _salesTargetProfit12 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetProfit
        /// <summary>���㌎�ԖڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MonthlySalesTargetProfit
        {
            get { return _monthlySalesTargetProfit; }
            set { _monthlySalesTargetProfit = value; }
        }

        /// public propaty name  :  TermSalesTargetProfit
        /// <summary>������ԖڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 TermSalesTargetProfit
        {
            get { return _termSalesTargetProfit; }
            set { _termSalesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount1
        /// <summary>����ڕW����1�v���p�e�B</summary>
        /// <value>1��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount1
        {
            get { return _salesTargetCount1; }
            set { _salesTargetCount1 = value; }
        }

        /// public propaty name  :  SalesTargetCount2
        /// <summary>����ڕW����2�v���p�e�B</summary>
        /// <value>2��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount2
        {
            get { return _salesTargetCount2; }
            set { _salesTargetCount2 = value; }
        }

        /// public propaty name  :  SalesTargetCount3
        /// <summary>����ڕW����3�v���p�e�B</summary>
        /// <value>3��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount3
        {
            get { return _salesTargetCount3; }
            set { _salesTargetCount3 = value; }
        }

        /// public propaty name  :  SalesTargetCount4
        /// <summary>����ڕW����4�v���p�e�B</summary>
        /// <value>4��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount4
        {
            get { return _salesTargetCount4; }
            set { _salesTargetCount4 = value; }
        }

        /// public propaty name  :  SalesTargetCount5
        /// <summary>����ڕW����5�v���p�e�B</summary>
        /// <value>5��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount5
        {
            get { return _salesTargetCount5; }
            set { _salesTargetCount5 = value; }
        }

        /// public propaty name  :  SalesTargetCount6
        /// <summary>����ڕW����6�v���p�e�B</summary>
        /// <value>6��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount6
        {
            get { return _salesTargetCount6; }
            set { _salesTargetCount6 = value; }
        }

        /// public propaty name  :  SalesTargetCount7
        /// <summary>����ڕW����7�v���p�e�B</summary>
        /// <value>7��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount7
        {
            get { return _salesTargetCount7; }
            set { _salesTargetCount7 = value; }
        }

        /// public propaty name  :  SalesTargetCount8
        /// <summary>����ڕW����8�v���p�e�B</summary>
        /// <value>8��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount8
        {
            get { return _salesTargetCount8; }
            set { _salesTargetCount8 = value; }
        }

        /// public propaty name  :  SalesTargetCount9
        /// <summary>����ڕW����9�v���p�e�B</summary>
        /// <value>9��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount9
        {
            get { return _salesTargetCount9; }
            set { _salesTargetCount9 = value; }
        }

        /// public propaty name  :  SalesTargetCount10
        /// <summary>����ڕW����10�v���p�e�B</summary>
        /// <value>10��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount10
        {
            get { return _salesTargetCount10; }
            set { _salesTargetCount10 = value; }
        }

        /// public propaty name  :  SalesTargetCount11
        /// <summary>����ڕW����11�v���p�e�B</summary>
        /// <value>11��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����11�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount11
        {
            get { return _salesTargetCount11; }
            set { _salesTargetCount11 = value; }
        }

        /// public propaty name  :  SalesTargetCount12
        /// <summary>����ڕW����12�v���p�e�B</summary>
        /// <value>12��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW����12�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount12
        {
            get { return _salesTargetCount12; }
            set { _salesTargetCount12 = value; }
        }

        /// public propaty name  :  MonthlySalesTargetCount
        /// <summary>���㌎�ԖڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���㌎�ԖڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MonthlySalesTargetCount
        {
            get { return _monthlySalesTargetCount; }
            set { _monthlySalesTargetCount = value; }
        }

        /// public propaty name  :  TermSalesTargetCount
        /// <summary>������ԖڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������ԖڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TermSalesTargetCount
        {
            get { return _termSalesTargetCount; }
            set { _termSalesTargetCount = value; }
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


        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignTarget()
        {
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="campaignCode">�L�����y�[���R�[�h(�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j)</param>
        /// <param name="targetContrastCd">�ڕW�Δ�敪(10:���_,22:���_+�]�ƈ�,30:���_+���Ӑ�,32:���_+�̔��ر,44:���_+�̔��敪,50:���_+��ٰ�ߺ���,60:���_+BL����)</param>
        /// <param name="employeeDivCd">�]�ƈ��敪(10:�̔��S���� 20:��t�S���� 30:���͒S����)</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="salesAreaCode">�̔��G���A�R�[�h(�n��R�[�h)</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h(���O���[�v�R�[�h)</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="salesCode">�̔��敪�R�[�h</param>
        /// <param name="salesTargetMoney1">����ڕW���z1(1��)</param>
        /// <param name="salesTargetMoney2">����ڕW���z2(2��)</param>
        /// <param name="salesTargetMoney3">����ڕW���z3(3��)</param>
        /// <param name="salesTargetMoney4">����ڕW���z4(4��)</param>
        /// <param name="salesTargetMoney5">����ڕW���z5(5��)</param>
        /// <param name="salesTargetMoney6">����ڕW���z6(6��)</param>
        /// <param name="salesTargetMoney7">����ڕW���z7(7��)</param>
        /// <param name="salesTargetMoney8">����ڕW���z8(8��)</param>
        /// <param name="salesTargetMoney9">����ڕW���z9(9��)</param>
        /// <param name="salesTargetMoney10">����ڕW���z10(10��)</param>
        /// <param name="salesTargetMoney11">����ڕW���z11(11��)</param>
        /// <param name="salesTargetMoney12">����ڕW���z12(12��)</param>
        /// <param name="monthlySalesTarget">���Ԕ���ڕW���z</param>
        /// <param name="termSalesTarget">������ԖڕW���z</param>
        /// <param name="salesTargetProfit1">����ڕW�e���z1(1��)</param>
        /// <param name="salesTargetProfit2">����ڕW�e���z2(2��)</param>
        /// <param name="salesTargetProfit3">����ڕW�e���z3(3��)</param>
        /// <param name="salesTargetProfit4">����ڕW�e���z4(4��)</param>
        /// <param name="salesTargetProfit5">����ڕW�e���z5(5��)</param>
        /// <param name="salesTargetProfit6">����ڕW�e���z6(6��)</param>
        /// <param name="salesTargetProfit7">����ڕW�e���z7(7��)</param>
        /// <param name="salesTargetProfit8">����ڕW�e���z8(8��)</param>
        /// <param name="salesTargetProfit9">����ڕW�e���z9(9��)</param>
        /// <param name="salesTargetProfit10">����ڕW�e���z10(10��)</param>
        /// <param name="salesTargetProfit11">����ڕW�e���z11(11��)</param>
        /// <param name="salesTargetProfit12">����ڕW�e���z12(12��)</param>
        /// <param name="monthlySalesTargetProfit">���㌎�ԖڕW�e���z</param>
        /// <param name="termSalesTargetProfit">������ԖڕW�e���z</param>
        /// <param name="salesTargetCount1">����ڕW����1(1��)</param>
        /// <param name="salesTargetCount2">����ڕW����2(2��)</param>
        /// <param name="salesTargetCount3">����ڕW����3(3��)</param>
        /// <param name="salesTargetCount4">����ڕW����4(4��)</param>
        /// <param name="salesTargetCount5">����ڕW����5(5��)</param>
        /// <param name="salesTargetCount6">����ڕW����6(6��)</param>
        /// <param name="salesTargetCount7">����ڕW����7(7��)</param>
        /// <param name="salesTargetCount8">����ڕW����8(8��)</param>
        /// <param name="salesTargetCount9">����ڕW����9(9��)</param>
        /// <param name="salesTargetCount10">����ڕW����10(10��)</param>
        /// <param name="salesTargetCount11">����ڕW����11(11��)</param>
        /// <param name="salesTargetCount12">����ڕW����12(12��)</param>
        /// <param name="monthlySalesTargetCount">���㌎�ԖڕW����</param>
        /// <param name="termSalesTargetCount">������ԖڕW����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>CampaignTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignTarget�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignTarget(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 campaignCode, Int32 targetContrastCd, Int32 employeeDivCd, string sectionCode, string employeeCode, Int32 customerCode, Int32 salesAreaCode, Int32 bLGroupCode, Int32 bLGoodsCode, Int32 salesCode, Int64 salesTargetMoney1, Int64 salesTargetMoney2, Int64 salesTargetMoney3, Int64 salesTargetMoney4, Int64 salesTargetMoney5, Int64 salesTargetMoney6, Int64 salesTargetMoney7, Int64 salesTargetMoney8, Int64 salesTargetMoney9, Int64 salesTargetMoney10, Int64 salesTargetMoney11, Int64 salesTargetMoney12, Int64 monthlySalesTarget, Int64 termSalesTarget, Int64 salesTargetProfit1, Int64 salesTargetProfit2, Int64 salesTargetProfit3, Int64 salesTargetProfit4, Int64 salesTargetProfit5, Int64 salesTargetProfit6, Int64 salesTargetProfit7, Int64 salesTargetProfit8, Int64 salesTargetProfit9, Int64 salesTargetProfit10, Int64 salesTargetProfit11, Int64 salesTargetProfit12, Int64 monthlySalesTargetProfit, Int64 termSalesTargetProfit, Double salesTargetCount1, Double salesTargetCount2, Double salesTargetCount3, Double salesTargetCount4, Double salesTargetCount5, Double salesTargetCount6, Double salesTargetCount7, Double salesTargetCount8, Double salesTargetCount9, Double salesTargetCount10, Double salesTargetCount11, Double salesTargetCount12, Double monthlySalesTargetCount, Double termSalesTargetCount, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._campaignCode = campaignCode;
            this._targetContrastCd = targetContrastCd;
            this._employeeDivCd = employeeDivCd;
            this._sectionCode = sectionCode;
            this._employeeCode = employeeCode;
            this._customerCode = customerCode;
            this._salesAreaCode = salesAreaCode;
            this._bLGroupCode = bLGroupCode;
            this._bLGoodsCode = bLGoodsCode;
            this._salesCode = salesCode;
            this._salesTargetMoney1 = salesTargetMoney1;
            this._salesTargetMoney2 = salesTargetMoney2;
            this._salesTargetMoney3 = salesTargetMoney3;
            this._salesTargetMoney4 = salesTargetMoney4;
            this._salesTargetMoney5 = salesTargetMoney5;
            this._salesTargetMoney6 = salesTargetMoney6;
            this._salesTargetMoney7 = salesTargetMoney7;
            this._salesTargetMoney8 = salesTargetMoney8;
            this._salesTargetMoney9 = salesTargetMoney9;
            this._salesTargetMoney10 = salesTargetMoney10;
            this._salesTargetMoney11 = salesTargetMoney11;
            this._salesTargetMoney12 = salesTargetMoney12;
            this._monthlySalesTarget = monthlySalesTarget;
            this._termSalesTarget = termSalesTarget;
            this._salesTargetProfit1 = salesTargetProfit1;
            this._salesTargetProfit2 = salesTargetProfit2;
            this._salesTargetProfit3 = salesTargetProfit3;
            this._salesTargetProfit4 = salesTargetProfit4;
            this._salesTargetProfit5 = salesTargetProfit5;
            this._salesTargetProfit6 = salesTargetProfit6;
            this._salesTargetProfit7 = salesTargetProfit7;
            this._salesTargetProfit8 = salesTargetProfit8;
            this._salesTargetProfit9 = salesTargetProfit9;
            this._salesTargetProfit10 = salesTargetProfit10;
            this._salesTargetProfit11 = salesTargetProfit11;
            this._salesTargetProfit12 = salesTargetProfit12;
            this._monthlySalesTargetProfit = monthlySalesTargetProfit;
            this._termSalesTargetProfit = termSalesTargetProfit;
            this._salesTargetCount1 = salesTargetCount1;
            this._salesTargetCount2 = salesTargetCount2;
            this._salesTargetCount3 = salesTargetCount3;
            this._salesTargetCount4 = salesTargetCount4;
            this._salesTargetCount5 = salesTargetCount5;
            this._salesTargetCount6 = salesTargetCount6;
            this._salesTargetCount7 = salesTargetCount7;
            this._salesTargetCount8 = salesTargetCount8;
            this._salesTargetCount9 = salesTargetCount9;
            this._salesTargetCount10 = salesTargetCount10;
            this._salesTargetCount11 = salesTargetCount11;
            this._salesTargetCount12 = salesTargetCount12;
            this._monthlySalesTargetCount = monthlySalesTargetCount;
            this._termSalesTargetCount = termSalesTargetCount;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^��������
        /// </summary>
        /// <returns>CampaignTarget�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CampaignTarget�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignTarget Clone()
        {
            return new CampaignTarget(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._campaignCode, this._targetContrastCd, this._employeeDivCd, this._sectionCode, this._employeeCode, this._customerCode, this._salesAreaCode, this._bLGroupCode, this._bLGoodsCode, this._salesCode, this._salesTargetMoney1, this._salesTargetMoney2, this._salesTargetMoney3, this._salesTargetMoney4, this._salesTargetMoney5, this._salesTargetMoney6, this._salesTargetMoney7, this._salesTargetMoney8, this._salesTargetMoney9, this._salesTargetMoney10, this._salesTargetMoney11, this._salesTargetMoney12, this._monthlySalesTarget, this._termSalesTarget, this._salesTargetProfit1, this._salesTargetProfit2, this._salesTargetProfit3, this._salesTargetProfit4, this._salesTargetProfit5, this._salesTargetProfit6, this._salesTargetProfit7, this._salesTargetProfit8, this._salesTargetProfit9, this._salesTargetProfit10, this._salesTargetProfit11, this._salesTargetProfit12, this._monthlySalesTargetProfit, this._termSalesTargetProfit, this._salesTargetCount1, this._salesTargetCount2, this._salesTargetCount3, this._salesTargetCount4, this._salesTargetCount5, this._salesTargetCount6, this._salesTargetCount7, this._salesTargetCount8, this._salesTargetCount9, this._salesTargetCount10, this._salesTargetCount11, this._salesTargetCount12, this._monthlySalesTargetCount, this._termSalesTargetCount, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CampaignTarget target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.EmployeeDivCd == target.EmployeeDivCd)
                 && (this.SectionCode == target.SectionCode)
                 && (this.EmployeeCode == target.EmployeeCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.SalesCode == target.SalesCode)
                 && (this.SalesTargetMoney1 == target.SalesTargetMoney1)
                 && (this.SalesTargetMoney2 == target.SalesTargetMoney2)
                 && (this.SalesTargetMoney3 == target.SalesTargetMoney3)
                 && (this.SalesTargetMoney4 == target.SalesTargetMoney4)
                 && (this.SalesTargetMoney5 == target.SalesTargetMoney5)
                 && (this.SalesTargetMoney6 == target.SalesTargetMoney6)
                 && (this.SalesTargetMoney7 == target.SalesTargetMoney7)
                 && (this.SalesTargetMoney8 == target.SalesTargetMoney8)
                 && (this.SalesTargetMoney9 == target.SalesTargetMoney9)
                 && (this.SalesTargetMoney10 == target.SalesTargetMoney10)
                 && (this.SalesTargetMoney11 == target.SalesTargetMoney11)
                 && (this.SalesTargetMoney12 == target.SalesTargetMoney12)
                 && (this.MonthlySalesTarget == target.MonthlySalesTarget)
                 && (this.TermSalesTarget == target.TermSalesTarget)
                 && (this.SalesTargetProfit1 == target.SalesTargetProfit1)
                 && (this.SalesTargetProfit2 == target.SalesTargetProfit2)
                 && (this.SalesTargetProfit3 == target.SalesTargetProfit3)
                 && (this.SalesTargetProfit4 == target.SalesTargetProfit4)
                 && (this.SalesTargetProfit5 == target.SalesTargetProfit5)
                 && (this.SalesTargetProfit6 == target.SalesTargetProfit6)
                 && (this.SalesTargetProfit7 == target.SalesTargetProfit7)
                 && (this.SalesTargetProfit8 == target.SalesTargetProfit8)
                 && (this.SalesTargetProfit9 == target.SalesTargetProfit9)
                 && (this.SalesTargetProfit10 == target.SalesTargetProfit10)
                 && (this.SalesTargetProfit11 == target.SalesTargetProfit11)
                 && (this.SalesTargetProfit12 == target.SalesTargetProfit12)
                 && (this.MonthlySalesTargetProfit == target.MonthlySalesTargetProfit)
                 && (this.TermSalesTargetProfit == target.TermSalesTargetProfit)
                 && (this.SalesTargetCount1 == target.SalesTargetCount1)
                 && (this.SalesTargetCount2 == target.SalesTargetCount2)
                 && (this.SalesTargetCount3 == target.SalesTargetCount3)
                 && (this.SalesTargetCount4 == target.SalesTargetCount4)
                 && (this.SalesTargetCount5 == target.SalesTargetCount5)
                 && (this.SalesTargetCount6 == target.SalesTargetCount6)
                 && (this.SalesTargetCount7 == target.SalesTargetCount7)
                 && (this.SalesTargetCount8 == target.SalesTargetCount8)
                 && (this.SalesTargetCount9 == target.SalesTargetCount9)
                 && (this.SalesTargetCount10 == target.SalesTargetCount10)
                 && (this.SalesTargetCount11 == target.SalesTargetCount11)
                 && (this.SalesTargetCount12 == target.SalesTargetCount12)
                 && (this.MonthlySalesTargetCount == target.MonthlySalesTargetCount)
                 && (this.TermSalesTargetCount == target.TermSalesTargetCount)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignTarget1">
        ///                    ��r����CampaignTarget�N���X�̃C���X�^���X
        /// </param>
        /// <param name="campaignTarget2">��r����CampaignTarget�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignTarget�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CampaignTarget campaignTarget1, CampaignTarget campaignTarget2)
        {
            return ((campaignTarget1.CreateDateTime == campaignTarget2.CreateDateTime)
                 && (campaignTarget1.UpdateDateTime == campaignTarget2.UpdateDateTime)
                 && (campaignTarget1.EnterpriseCode == campaignTarget2.EnterpriseCode)
                 && (campaignTarget1.FileHeaderGuid == campaignTarget2.FileHeaderGuid)
                 && (campaignTarget1.UpdEmployeeCode == campaignTarget2.UpdEmployeeCode)
                 && (campaignTarget1.UpdAssemblyId1 == campaignTarget2.UpdAssemblyId1)
                 && (campaignTarget1.UpdAssemblyId2 == campaignTarget2.UpdAssemblyId2)
                 && (campaignTarget1.LogicalDeleteCode == campaignTarget2.LogicalDeleteCode)
                 && (campaignTarget1.CampaignCode == campaignTarget2.CampaignCode)
                 && (campaignTarget1.TargetContrastCd == campaignTarget2.TargetContrastCd)
                 && (campaignTarget1.EmployeeDivCd == campaignTarget2.EmployeeDivCd)
                 && (campaignTarget1.SectionCode == campaignTarget2.SectionCode)
                 && (campaignTarget1.EmployeeCode == campaignTarget2.EmployeeCode)
                 && (campaignTarget1.CustomerCode == campaignTarget2.CustomerCode)
                 && (campaignTarget1.SalesAreaCode == campaignTarget2.SalesAreaCode)
                 && (campaignTarget1.BLGroupCode == campaignTarget2.BLGroupCode)
                 && (campaignTarget1.BLGoodsCode == campaignTarget2.BLGoodsCode)
                 && (campaignTarget1.SalesCode == campaignTarget2.SalesCode)
                 && (campaignTarget1.SalesTargetMoney1 == campaignTarget2.SalesTargetMoney1)
                 && (campaignTarget1.SalesTargetMoney2 == campaignTarget2.SalesTargetMoney2)
                 && (campaignTarget1.SalesTargetMoney3 == campaignTarget2.SalesTargetMoney3)
                 && (campaignTarget1.SalesTargetMoney4 == campaignTarget2.SalesTargetMoney4)
                 && (campaignTarget1.SalesTargetMoney5 == campaignTarget2.SalesTargetMoney5)
                 && (campaignTarget1.SalesTargetMoney6 == campaignTarget2.SalesTargetMoney6)
                 && (campaignTarget1.SalesTargetMoney7 == campaignTarget2.SalesTargetMoney7)
                 && (campaignTarget1.SalesTargetMoney8 == campaignTarget2.SalesTargetMoney8)
                 && (campaignTarget1.SalesTargetMoney9 == campaignTarget2.SalesTargetMoney9)
                 && (campaignTarget1.SalesTargetMoney10 == campaignTarget2.SalesTargetMoney10)
                 && (campaignTarget1.SalesTargetMoney11 == campaignTarget2.SalesTargetMoney11)
                 && (campaignTarget1.SalesTargetMoney12 == campaignTarget2.SalesTargetMoney12)
                 && (campaignTarget1.MonthlySalesTarget == campaignTarget2.MonthlySalesTarget)
                 && (campaignTarget1.TermSalesTarget == campaignTarget2.TermSalesTarget)
                 && (campaignTarget1.SalesTargetProfit1 == campaignTarget2.SalesTargetProfit1)
                 && (campaignTarget1.SalesTargetProfit2 == campaignTarget2.SalesTargetProfit2)
                 && (campaignTarget1.SalesTargetProfit3 == campaignTarget2.SalesTargetProfit3)
                 && (campaignTarget1.SalesTargetProfit4 == campaignTarget2.SalesTargetProfit4)
                 && (campaignTarget1.SalesTargetProfit5 == campaignTarget2.SalesTargetProfit5)
                 && (campaignTarget1.SalesTargetProfit6 == campaignTarget2.SalesTargetProfit6)
                 && (campaignTarget1.SalesTargetProfit7 == campaignTarget2.SalesTargetProfit7)
                 && (campaignTarget1.SalesTargetProfit8 == campaignTarget2.SalesTargetProfit8)
                 && (campaignTarget1.SalesTargetProfit9 == campaignTarget2.SalesTargetProfit9)
                 && (campaignTarget1.SalesTargetProfit10 == campaignTarget2.SalesTargetProfit10)
                 && (campaignTarget1.SalesTargetProfit11 == campaignTarget2.SalesTargetProfit11)
                 && (campaignTarget1.SalesTargetProfit12 == campaignTarget2.SalesTargetProfit12)
                 && (campaignTarget1.MonthlySalesTargetProfit == campaignTarget2.MonthlySalesTargetProfit)
                 && (campaignTarget1.TermSalesTargetProfit == campaignTarget2.TermSalesTargetProfit)
                 && (campaignTarget1.SalesTargetCount1 == campaignTarget2.SalesTargetCount1)
                 && (campaignTarget1.SalesTargetCount2 == campaignTarget2.SalesTargetCount2)
                 && (campaignTarget1.SalesTargetCount3 == campaignTarget2.SalesTargetCount3)
                 && (campaignTarget1.SalesTargetCount4 == campaignTarget2.SalesTargetCount4)
                 && (campaignTarget1.SalesTargetCount5 == campaignTarget2.SalesTargetCount5)
                 && (campaignTarget1.SalesTargetCount6 == campaignTarget2.SalesTargetCount6)
                 && (campaignTarget1.SalesTargetCount7 == campaignTarget2.SalesTargetCount7)
                 && (campaignTarget1.SalesTargetCount8 == campaignTarget2.SalesTargetCount8)
                 && (campaignTarget1.SalesTargetCount9 == campaignTarget2.SalesTargetCount9)
                 && (campaignTarget1.SalesTargetCount10 == campaignTarget2.SalesTargetCount10)
                 && (campaignTarget1.SalesTargetCount11 == campaignTarget2.SalesTargetCount11)
                 && (campaignTarget1.SalesTargetCount12 == campaignTarget2.SalesTargetCount12)
                 && (campaignTarget1.MonthlySalesTargetCount == campaignTarget2.MonthlySalesTargetCount)
                 && (campaignTarget1.TermSalesTargetCount == campaignTarget2.TermSalesTargetCount)
                 && (campaignTarget1.EnterpriseName == campaignTarget2.EnterpriseName)
                 && (campaignTarget1.UpdEmployeeName == campaignTarget2.UpdEmployeeName));
        }
        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignTarget�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CampaignTarget target)
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
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.TargetContrastCd != target.TargetContrastCd) resList.Add("TargetContrastCd");
            if (this.EmployeeDivCd != target.EmployeeDivCd) resList.Add("EmployeeDivCd");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.SalesTargetMoney1 != target.SalesTargetMoney1) resList.Add("SalesTargetMoney1");
            if (this.SalesTargetMoney2 != target.SalesTargetMoney2) resList.Add("SalesTargetMoney2");
            if (this.SalesTargetMoney3 != target.SalesTargetMoney3) resList.Add("SalesTargetMoney3");
            if (this.SalesTargetMoney4 != target.SalesTargetMoney4) resList.Add("SalesTargetMoney4");
            if (this.SalesTargetMoney5 != target.SalesTargetMoney5) resList.Add("SalesTargetMoney5");
            if (this.SalesTargetMoney6 != target.SalesTargetMoney6) resList.Add("SalesTargetMoney6");
            if (this.SalesTargetMoney7 != target.SalesTargetMoney7) resList.Add("SalesTargetMoney7");
            if (this.SalesTargetMoney8 != target.SalesTargetMoney8) resList.Add("SalesTargetMoney8");
            if (this.SalesTargetMoney9 != target.SalesTargetMoney9) resList.Add("SalesTargetMoney9");
            if (this.SalesTargetMoney10 != target.SalesTargetMoney10) resList.Add("SalesTargetMoney10");
            if (this.SalesTargetMoney11 != target.SalesTargetMoney11) resList.Add("SalesTargetMoney11");
            if (this.SalesTargetMoney12 != target.SalesTargetMoney12) resList.Add("SalesTargetMoney12");
            if (this.MonthlySalesTarget != target.MonthlySalesTarget) resList.Add("MonthlySalesTarget");
            if (this.TermSalesTarget != target.TermSalesTarget) resList.Add("TermSalesTarget");
            if (this.SalesTargetProfit1 != target.SalesTargetProfit1) resList.Add("SalesTargetProfit1");
            if (this.SalesTargetProfit2 != target.SalesTargetProfit2) resList.Add("SalesTargetProfit2");
            if (this.SalesTargetProfit3 != target.SalesTargetProfit3) resList.Add("SalesTargetProfit3");
            if (this.SalesTargetProfit4 != target.SalesTargetProfit4) resList.Add("SalesTargetProfit4");
            if (this.SalesTargetProfit5 != target.SalesTargetProfit5) resList.Add("SalesTargetProfit5");
            if (this.SalesTargetProfit6 != target.SalesTargetProfit6) resList.Add("SalesTargetProfit6");
            if (this.SalesTargetProfit7 != target.SalesTargetProfit7) resList.Add("SalesTargetProfit7");
            if (this.SalesTargetProfit8 != target.SalesTargetProfit8) resList.Add("SalesTargetProfit8");
            if (this.SalesTargetProfit9 != target.SalesTargetProfit9) resList.Add("SalesTargetProfit9");
            if (this.SalesTargetProfit10 != target.SalesTargetProfit10) resList.Add("SalesTargetProfit10");
            if (this.SalesTargetProfit11 != target.SalesTargetProfit11) resList.Add("SalesTargetProfit11");
            if (this.SalesTargetProfit12 != target.SalesTargetProfit12) resList.Add("SalesTargetProfit12");
            if (this.MonthlySalesTargetProfit != target.MonthlySalesTargetProfit) resList.Add("MonthlySalesTargetProfit");
            if (this.TermSalesTargetProfit != target.TermSalesTargetProfit) resList.Add("TermSalesTargetProfit");
            if (this.SalesTargetCount1 != target.SalesTargetCount1) resList.Add("SalesTargetCount1");
            if (this.SalesTargetCount2 != target.SalesTargetCount2) resList.Add("SalesTargetCount2");
            if (this.SalesTargetCount3 != target.SalesTargetCount3) resList.Add("SalesTargetCount3");
            if (this.SalesTargetCount4 != target.SalesTargetCount4) resList.Add("SalesTargetCount4");
            if (this.SalesTargetCount5 != target.SalesTargetCount5) resList.Add("SalesTargetCount5");
            if (this.SalesTargetCount6 != target.SalesTargetCount6) resList.Add("SalesTargetCount6");
            if (this.SalesTargetCount7 != target.SalesTargetCount7) resList.Add("SalesTargetCount7");
            if (this.SalesTargetCount8 != target.SalesTargetCount8) resList.Add("SalesTargetCount8");
            if (this.SalesTargetCount9 != target.SalesTargetCount9) resList.Add("SalesTargetCount9");
            if (this.SalesTargetCount10 != target.SalesTargetCount10) resList.Add("SalesTargetCount10");
            if (this.SalesTargetCount11 != target.SalesTargetCount11) resList.Add("SalesTargetCount11");
            if (this.SalesTargetCount12 != target.SalesTargetCount12) resList.Add("SalesTargetCount12");
            if (this.MonthlySalesTargetCount != target.MonthlySalesTargetCount) resList.Add("MonthlySalesTargetCount");
            if (this.TermSalesTargetCount != target.TermSalesTargetCount) resList.Add("TermSalesTargetCount");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �L�����y�[���ڕW�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignTarget1">��r����CampaignTarget�N���X�̃C���X�^���X</param>
        /// <param name="campaignTarget2">��r����CampaignTarget�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignTarget�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CampaignTarget campaignTarget1, CampaignTarget campaignTarget2)
        {
            ArrayList resList = new ArrayList();
            if (campaignTarget1.CreateDateTime != campaignTarget2.CreateDateTime) resList.Add("CreateDateTime");
            if (campaignTarget1.UpdateDateTime != campaignTarget2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (campaignTarget1.EnterpriseCode != campaignTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignTarget1.FileHeaderGuid != campaignTarget2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (campaignTarget1.UpdEmployeeCode != campaignTarget2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (campaignTarget1.UpdAssemblyId1 != campaignTarget2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (campaignTarget1.UpdAssemblyId2 != campaignTarget2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (campaignTarget1.LogicalDeleteCode != campaignTarget2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignTarget1.CampaignCode != campaignTarget2.CampaignCode) resList.Add("CampaignCode");
            if (campaignTarget1.TargetContrastCd != campaignTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (campaignTarget1.EmployeeDivCd != campaignTarget2.EmployeeDivCd) resList.Add("EmployeeDivCd");
            if (campaignTarget1.SectionCode != campaignTarget2.SectionCode) resList.Add("SectionCode");
            if (campaignTarget1.EmployeeCode != campaignTarget2.EmployeeCode) resList.Add("EmployeeCode");
            if (campaignTarget1.CustomerCode != campaignTarget2.CustomerCode) resList.Add("CustomerCode");
            if (campaignTarget1.SalesAreaCode != campaignTarget2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (campaignTarget1.BLGroupCode != campaignTarget2.BLGroupCode) resList.Add("BLGroupCode");
            if (campaignTarget1.BLGoodsCode != campaignTarget2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (campaignTarget1.SalesCode != campaignTarget2.SalesCode) resList.Add("SalesCode");
            if (campaignTarget1.SalesTargetMoney1 != campaignTarget2.SalesTargetMoney1) resList.Add("SalesTargetMoney1");
            if (campaignTarget1.SalesTargetMoney2 != campaignTarget2.SalesTargetMoney2) resList.Add("SalesTargetMoney2");
            if (campaignTarget1.SalesTargetMoney3 != campaignTarget2.SalesTargetMoney3) resList.Add("SalesTargetMoney3");
            if (campaignTarget1.SalesTargetMoney4 != campaignTarget2.SalesTargetMoney4) resList.Add("SalesTargetMoney4");
            if (campaignTarget1.SalesTargetMoney5 != campaignTarget2.SalesTargetMoney5) resList.Add("SalesTargetMoney5");
            if (campaignTarget1.SalesTargetMoney6 != campaignTarget2.SalesTargetMoney6) resList.Add("SalesTargetMoney6");
            if (campaignTarget1.SalesTargetMoney7 != campaignTarget2.SalesTargetMoney7) resList.Add("SalesTargetMoney7");
            if (campaignTarget1.SalesTargetMoney8 != campaignTarget2.SalesTargetMoney8) resList.Add("SalesTargetMoney8");
            if (campaignTarget1.SalesTargetMoney9 != campaignTarget2.SalesTargetMoney9) resList.Add("SalesTargetMoney9");
            if (campaignTarget1.SalesTargetMoney10 != campaignTarget2.SalesTargetMoney10) resList.Add("SalesTargetMoney10");
            if (campaignTarget1.SalesTargetMoney11 != campaignTarget2.SalesTargetMoney11) resList.Add("SalesTargetMoney11");
            if (campaignTarget1.SalesTargetMoney12 != campaignTarget2.SalesTargetMoney12) resList.Add("SalesTargetMoney12");
            if (campaignTarget1.MonthlySalesTarget != campaignTarget2.MonthlySalesTarget) resList.Add("MonthlySalesTarget");
            if (campaignTarget1.TermSalesTarget != campaignTarget2.TermSalesTarget) resList.Add("TermSalesTarget");
            if (campaignTarget1.SalesTargetProfit1 != campaignTarget2.SalesTargetProfit1) resList.Add("SalesTargetProfit1");
            if (campaignTarget1.SalesTargetProfit2 != campaignTarget2.SalesTargetProfit2) resList.Add("SalesTargetProfit2");
            if (campaignTarget1.SalesTargetProfit3 != campaignTarget2.SalesTargetProfit3) resList.Add("SalesTargetProfit3");
            if (campaignTarget1.SalesTargetProfit4 != campaignTarget2.SalesTargetProfit4) resList.Add("SalesTargetProfit4");
            if (campaignTarget1.SalesTargetProfit5 != campaignTarget2.SalesTargetProfit5) resList.Add("SalesTargetProfit5");
            if (campaignTarget1.SalesTargetProfit6 != campaignTarget2.SalesTargetProfit6) resList.Add("SalesTargetProfit6");
            if (campaignTarget1.SalesTargetProfit7 != campaignTarget2.SalesTargetProfit7) resList.Add("SalesTargetProfit7");
            if (campaignTarget1.SalesTargetProfit8 != campaignTarget2.SalesTargetProfit8) resList.Add("SalesTargetProfit8");
            if (campaignTarget1.SalesTargetProfit9 != campaignTarget2.SalesTargetProfit9) resList.Add("SalesTargetProfit9");
            if (campaignTarget1.SalesTargetProfit10 != campaignTarget2.SalesTargetProfit10) resList.Add("SalesTargetProfit10");
            if (campaignTarget1.SalesTargetProfit11 != campaignTarget2.SalesTargetProfit11) resList.Add("SalesTargetProfit11");
            if (campaignTarget1.SalesTargetProfit12 != campaignTarget2.SalesTargetProfit12) resList.Add("SalesTargetProfit12");
            if (campaignTarget1.MonthlySalesTargetProfit != campaignTarget2.MonthlySalesTargetProfit) resList.Add("MonthlySalesTargetProfit");
            if (campaignTarget1.TermSalesTargetProfit != campaignTarget2.TermSalesTargetProfit) resList.Add("TermSalesTargetProfit");
            if (campaignTarget1.SalesTargetCount1 != campaignTarget2.SalesTargetCount1) resList.Add("SalesTargetCount1");
            if (campaignTarget1.SalesTargetCount2 != campaignTarget2.SalesTargetCount2) resList.Add("SalesTargetCount2");
            if (campaignTarget1.SalesTargetCount3 != campaignTarget2.SalesTargetCount3) resList.Add("SalesTargetCount3");
            if (campaignTarget1.SalesTargetCount4 != campaignTarget2.SalesTargetCount4) resList.Add("SalesTargetCount4");
            if (campaignTarget1.SalesTargetCount5 != campaignTarget2.SalesTargetCount5) resList.Add("SalesTargetCount5");
            if (campaignTarget1.SalesTargetCount6 != campaignTarget2.SalesTargetCount6) resList.Add("SalesTargetCount6");
            if (campaignTarget1.SalesTargetCount7 != campaignTarget2.SalesTargetCount7) resList.Add("SalesTargetCount7");
            if (campaignTarget1.SalesTargetCount8 != campaignTarget2.SalesTargetCount8) resList.Add("SalesTargetCount8");
            if (campaignTarget1.SalesTargetCount9 != campaignTarget2.SalesTargetCount9) resList.Add("SalesTargetCount9");
            if (campaignTarget1.SalesTargetCount10 != campaignTarget2.SalesTargetCount10) resList.Add("SalesTargetCount10");
            if (campaignTarget1.SalesTargetCount11 != campaignTarget2.SalesTargetCount11) resList.Add("SalesTargetCount11");
            if (campaignTarget1.SalesTargetCount12 != campaignTarget2.SalesTargetCount12) resList.Add("SalesTargetCount12");
            if (campaignTarget1.MonthlySalesTargetCount != campaignTarget2.MonthlySalesTargetCount) resList.Add("MonthlySalesTargetCount");
            if (campaignTarget1.TermSalesTargetCount != campaignTarget2.TermSalesTargetCount) resList.Add("TermSalesTargetCount");
            if (campaignTarget1.EnterpriseName != campaignTarget2.EnterpriseName) resList.Add("EnterpriseName");
            if (campaignTarget1.UpdEmployeeName != campaignTarget2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
