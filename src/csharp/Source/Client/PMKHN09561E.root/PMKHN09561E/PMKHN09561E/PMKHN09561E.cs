//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �L�����y�[���ݒ�}�X�^
// �v���O�����T�v   : �L�����y�[���ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignSt
    /// <summary>
    ///                      �L�����y�[���ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/04/13</br>
    /// <br>Genarated Date   :   2009/05/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :    2009/5/13  ����</br>
    /// <br>                 :   ���^�ύX</br>
    /// <br>                 :   �L�����y�[���R�[�h</br>
    /// <br>                 :   nvarchar �� Int32</br>
    /// <br>                 :   ���⑫�ύX</br>
    /// <br>                 :   �L�����y�[���Ώۋ敪</br>
    /// <br>                 :   0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:���~</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:�Ǘ����Ӑ� 9:���~</br>
    /// </remarks>
    public class CampaignSt
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

        /// <summary>�L�����y�[���R�[�h</summary>
        /// <remarks>�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j</remarks>
        private Int32 _campaignCode;

        /// <summary>�L�����y�[������</summary>
        private string _campaignName = "";

        /// <summary>�L�����y�[���Ώۋ敪</summary>
        /// <remarks>0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:���~</remarks>
        private Int32 _campaignObjDiv;

        /// <summary>�K�p�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyStaDate;

        /// <summary>�K�p�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _applyEndDate;

        /// <summary>����ڕW���z</summary>
        private Int64 _salesTargetMoney;

        /// <summary>����ڕW�e���z</summary>
        private Int64 _salesTargetProfit;

        /// <summary>����ڕW����</summary>
        private Double _salesTargetCount;

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
            get { return _sectionCode; }
            set { _sectionCode = value; }
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

        /// public propaty name  :  CampaignName
        /// <summary>�L�����y�[�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CampaignName
        {
            get { return _campaignName; }
            set { _campaignName = value; }
        }

        /// public propaty name  :  CampaignObjDiv
        /// <summary>�L�����y�[���Ώۋ敪�v���p�e�B</summary>
        /// <value>0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:���~</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�����y�[���Ώۋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignObjDiv
        {
            get { return _campaignObjDiv; }
            set { _campaignObjDiv = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>�K�p�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyStaDateJpFormal
        /// <summary>�K�p�J�n�� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n�� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyStaDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateJpInFormal
        /// <summary>�K�p�J�n�� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n�� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyStaDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateAdFormal
        /// <summary>�K�p�J�n�� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n�� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyStaDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyStaDateAdInFormal
        /// <summary>�K�p�J�n�� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�J�n�� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyStaDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _applyStaDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>�K�p�I�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// public propaty name  :  ApplyEndDateJpFormal
        /// <summary>�K�p�I���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyEndDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateJpInFormal
        /// <summary>�K�p�I���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyEndDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateAdFormal
        /// <summary>�K�p�I���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyEndDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  ApplyEndDateAdInFormal
        /// <summary>�K�p�I���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�I���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ApplyEndDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _applyEndDate); }
            set { }
        }

        /// public propaty name  :  SalesTargetMoney
        /// <summary>����ڕW���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetMoney
        {
            get { return _salesTargetMoney; }
            set { _salesTargetMoney = value; }
        }

        /// public propaty name  :  SalesTargetProfit
        /// <summary>����ڕW�e���z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW�e���z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesTargetProfit
        {
            get { return _salesTargetProfit; }
            set { _salesTargetProfit = value; }
        }

        /// public propaty name  :  SalesTargetCount
        /// <summary>����ڕW���ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����ڕW���ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesTargetCount
        {
            get { return _salesTargetCount; }
            set { _salesTargetCount = value; }
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
        /// �L�����y�[���ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignSt()
        {
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^�R���X�g���N�^
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
        /// <param name="campaignCode">�L�����y�[���R�[�h(�C�ӂ̖��d���R�[�h�Ƃ���i�����t�Ԃ͂��Ȃ��j)</param>
        /// <param name="campaignName">�L�����y�[������</param>
        /// <param name="campaignObjDiv">�L�����y�[���Ώۋ敪(0:�S���Ӑ� 1:�Ώۓ��Ӑ� 2:���~)</param>
        /// <param name="applyStaDate">�K�p�J�n��(YYYYMMDD)</param>
        /// <param name="applyEndDate">�K�p�I����(YYYYMMDD)</param>
        /// <param name="salesTargetMoney">����ڕW���z</param>
        /// <param name="salesTargetProfit">����ڕW�e���z</param>
        /// <param name="salesTargetCount">����ڕW����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>CampaignSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 campaignCode, string campaignName, Int32 campaignObjDiv, DateTime applyStaDate, DateTime applyEndDate, Int64 salesTargetMoney, Int64 salesTargetProfit, Double salesTargetCount, string enterpriseName, string updEmployeeName)
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
            this._campaignCode = campaignCode;
            this._campaignName = campaignName;
            this._campaignObjDiv = campaignObjDiv;
            this.ApplyStaDate = applyStaDate;
            this.ApplyEndDate = applyEndDate;
            this._salesTargetMoney = salesTargetMoney;
            this._salesTargetProfit = salesTargetProfit;
            this._salesTargetCount = salesTargetCount;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^��������
        /// </summary>
        /// <returns>CampaignSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CampaignSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignSt Clone()
        {
            return new CampaignSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._campaignCode, this._campaignName, this._campaignObjDiv, this._applyStaDate, this._applyEndDate, this._salesTargetMoney, this._salesTargetProfit, this._salesTargetCount, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CampaignSt target)
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
                 && (this.CampaignCode == target.CampaignCode)
                 && (this.CampaignName == target.CampaignName)
                 && (this.CampaignObjDiv == target.CampaignObjDiv)
                 && (this.ApplyStaDate == target.ApplyStaDate)
                 && (this.ApplyEndDate == target.ApplyEndDate)
                 && (this.SalesTargetMoney == target.SalesTargetMoney)
                 && (this.SalesTargetProfit == target.SalesTargetProfit)
                 && (this.SalesTargetCount == target.SalesTargetCount)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignSt1">
        ///                    ��r����CampaignSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="campaignSt2">��r����CampaignSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CampaignSt campaignSt1, CampaignSt campaignSt2)
        {
            return ((campaignSt1.CreateDateTime == campaignSt2.CreateDateTime)
                 && (campaignSt1.UpdateDateTime == campaignSt2.UpdateDateTime)
                 && (campaignSt1.EnterpriseCode == campaignSt2.EnterpriseCode)
                 && (campaignSt1.FileHeaderGuid == campaignSt2.FileHeaderGuid)
                 && (campaignSt1.UpdEmployeeCode == campaignSt2.UpdEmployeeCode)
                 && (campaignSt1.UpdAssemblyId1 == campaignSt2.UpdAssemblyId1)
                 && (campaignSt1.UpdAssemblyId2 == campaignSt2.UpdAssemblyId2)
                 && (campaignSt1.LogicalDeleteCode == campaignSt2.LogicalDeleteCode)
                 && (campaignSt1.SectionCode == campaignSt2.SectionCode)
                 && (campaignSt1.CampaignCode == campaignSt2.CampaignCode)
                 && (campaignSt1.CampaignName == campaignSt2.CampaignName)
                 && (campaignSt1.CampaignObjDiv == campaignSt2.CampaignObjDiv)
                 && (campaignSt1.ApplyStaDate == campaignSt2.ApplyStaDate)
                 && (campaignSt1.ApplyEndDate == campaignSt2.ApplyEndDate)
                 && (campaignSt1.SalesTargetMoney == campaignSt2.SalesTargetMoney)
                 && (campaignSt1.SalesTargetProfit == campaignSt2.SalesTargetProfit)
                 && (campaignSt1.SalesTargetCount == campaignSt2.SalesTargetCount)
                 && (campaignSt1.EnterpriseName == campaignSt2.EnterpriseName)
                 && (campaignSt1.UpdEmployeeName == campaignSt2.UpdEmployeeName));
        }
        /// <summary>
        /// �L�����y�[���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CampaignSt target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.CampaignCode != target.CampaignCode) resList.Add("CampaignCode");
            if (this.CampaignName != target.CampaignName) resList.Add("CampaignName");
            if (this.CampaignObjDiv != target.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (this.ApplyStaDate != target.ApplyStaDate) resList.Add("ApplyStaDate");
            if (this.ApplyEndDate != target.ApplyEndDate) resList.Add("ApplyEndDate");
            if (this.SalesTargetMoney != target.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (this.SalesTargetProfit != target.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (this.SalesTargetCount != target.SalesTargetCount) resList.Add("SalesTargetCount");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �L�����y�[���ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignSt1">��r����CampaignSt�N���X�̃C���X�^���X</param>
        /// <param name="campaignSt2">��r����CampaignSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CampaignSt campaignSt1, CampaignSt campaignSt2)
        {
            ArrayList resList = new ArrayList();
            if (campaignSt1.CreateDateTime != campaignSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (campaignSt1.UpdateDateTime != campaignSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (campaignSt1.EnterpriseCode != campaignSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignSt1.FileHeaderGuid != campaignSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (campaignSt1.UpdEmployeeCode != campaignSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (campaignSt1.UpdAssemblyId1 != campaignSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (campaignSt1.UpdAssemblyId2 != campaignSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (campaignSt1.LogicalDeleteCode != campaignSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignSt1.SectionCode != campaignSt2.SectionCode) resList.Add("SectionCode");
            if (campaignSt1.CampaignCode != campaignSt2.CampaignCode) resList.Add("CampaignCode");
            if (campaignSt1.CampaignName != campaignSt2.CampaignName) resList.Add("CampaignName");
            if (campaignSt1.CampaignObjDiv != campaignSt2.CampaignObjDiv) resList.Add("CampaignObjDiv");
            if (campaignSt1.ApplyStaDate != campaignSt2.ApplyStaDate) resList.Add("ApplyStaDate");
            if (campaignSt1.ApplyEndDate != campaignSt2.ApplyEndDate) resList.Add("ApplyEndDate");
            if (campaignSt1.SalesTargetMoney != campaignSt2.SalesTargetMoney) resList.Add("SalesTargetMoney");
            if (campaignSt1.SalesTargetProfit != campaignSt2.SalesTargetProfit) resList.Add("SalesTargetProfit");
            if (campaignSt1.SalesTargetCount != campaignSt2.SalesTargetCount) resList.Add("SalesTargetCount");
            if (campaignSt1.EnterpriseName != campaignSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (campaignSt1.UpdEmployeeName != campaignSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
