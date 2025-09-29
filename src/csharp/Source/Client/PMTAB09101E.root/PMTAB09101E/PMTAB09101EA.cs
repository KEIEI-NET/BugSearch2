using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PmTabTtlStSec
    /// <summary>
    ///                      �^�u���b�g�S�̐ݒ�}�X�^(���_��)
    /// </summary>
    /// <remarks>
    /// <br>note             :   �^�u���b�g�S�̐ݒ�}�X�^(���_��)�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/05/31 (CSharp File Generated Date)</br>
    /// </remarks>
    public class PmTabTtlStSec
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
        private string _sectionCode = "";

        /// <summary>��M�����N���[���ԍ��R�[�h</summary>
        private Int32 _cashRegisterNo;

        /// <summary>��M�����N���[���ԍ�����</summary>
        private string _cashRegisterNoNM = "";

        /// <summary>����i�ԑI���敪</summary>
        private Int32 _liPriSelPrtGdsNoDiv;

        /// <summary>����i�ԑI���敪����</summary>
        private string _liPriSelPrtGdsNoDivNM = "";

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

        /// public propaty name  :  CashRegisterNo
        /// <summary>��M�����N���[���ԍ����p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�����N���[���ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// public propaty name  :  CashRegisterNoNM
        /// <summary>��M�����N���[���ԍ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��M�����N���[���ԍ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CashRegisterNoNM
        {
            get { return _cashRegisterNoNM; }
            set { _cashRegisterNoNM = value; }
        }

        /// public propaty name  :  LiPriSelPrtGdsNoDiv
        /// <summary>����i�ԑI���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����i�ԑI���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LiPriSelPrtGdsNoDiv
        {
            get { return _liPriSelPrtGdsNoDiv; }
            set { _liPriSelPrtGdsNoDiv = value; }
        }

        /// public propaty name  :  LiPriSelPrtGdsNoDivNM
        /// <summary>����i�ԑI���敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����i�ԑI���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LiPriSelPrtGdsNoDivNM
        {
            get { return _liPriSelPrtGdsNoDivNM; }
            set { _liPriSelPrtGdsNoDivNM = value; }
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
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�R���X�g���N�^
        /// </summary>
        /// <returns>PmTabTtlStSec�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmTabTtlStSec ()
        {
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="cashRegisterNo">��M�����N���[���R�[�h</param>
        /// <param name="cashRegisterNoNM">��M�����N���[������</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="liPriSelPrtGdsNoDiv">����i�ԑI���敪</param>
        /// <param name="liPriSelPrtGdsNoDivNM">����i�ԑI���敪����</param>
        /// <returns>PmTabTtlStSec�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmTabTtlStSec(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 cashRegisterNo, string cashRegisterNoNM, Int32 liPriSelPrtGdsNoDiv, string liPriSelPrtGdsNoDivNM, string enterpriseName, string updEmployeeName)
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
            this._cashRegisterNo = cashRegisterNo;
            this._cashRegisterNoNM = cashRegisterNoNM;
            this._liPriSelPrtGdsNoDiv = liPriSelPrtGdsNoDiv;
            this._liPriSelPrtGdsNoDivNM = liPriSelPrtGdsNoDivNM;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)��������
        /// </summary>
        /// <returns>PmTabTtlStSec�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PmTabTtlStSec�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmTabTtlStSec Clone()
        {
            return new PmTabTtlStSec(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._cashRegisterNo, this._cashRegisterNoNM, this._liPriSelPrtGdsNoDiv, this._liPriSelPrtGdsNoDivNM, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PmTabTtlStSec target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.FileHeaderGuid == target.FileHeaderGuid )
                 && ( this.UpdEmployeeCode == target.UpdEmployeeCode )
                 && ( this.UpdAssemblyId1 == target.UpdAssemblyId1 )
                 && ( this.UpdAssemblyId2 == target.UpdAssemblyId2 )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.SectionCode == target.SectionCode )
                 && ( this.CashRegisterNo == target.CashRegisterNo)
                 && ( this.CashRegisterNoNM == target.CashRegisterNoNM)
                 && ( this.LiPriSelPrtGdsNoDiv == target.LiPriSelPrtGdsNoDiv)
                 && ( this.LiPriSelPrtGdsNoDivNM == target.LiPriSelPrtGdsNoDivNM)
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.UpdEmployeeName == target.UpdEmployeeName ) );
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)��r����
        /// </summary>
        /// <param name="tabTtlStSec1">
        ///                    ��r����PmTabTtlStSec�N���X�̃C���X�^���X
        /// </param>
        /// <param name="tabTtlStSec2">��r����PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PmTabTtlStSec tabTtlStSec1, PmTabTtlStSec tabTtlStSec2)
        {
            return ( ( tabTtlStSec1.CreateDateTime == tabTtlStSec2.CreateDateTime )
                 && ( tabTtlStSec1.UpdateDateTime == tabTtlStSec2.UpdateDateTime )
                 && ( tabTtlStSec1.EnterpriseCode == tabTtlStSec2.EnterpriseCode )
                 && ( tabTtlStSec1.FileHeaderGuid == tabTtlStSec2.FileHeaderGuid )
                 && ( tabTtlStSec1.UpdEmployeeCode == tabTtlStSec2.UpdEmployeeCode )
                 && ( tabTtlStSec1.UpdAssemblyId1 == tabTtlStSec2.UpdAssemblyId1 )
                 && ( tabTtlStSec1.UpdAssemblyId2 == tabTtlStSec2.UpdAssemblyId2 )
                 && ( tabTtlStSec1.LogicalDeleteCode == tabTtlStSec2.LogicalDeleteCode )
                 && ( tabTtlStSec1.SectionCode == tabTtlStSec2.SectionCode )
                 && ( tabTtlStSec1.CashRegisterNo == tabTtlStSec2.CashRegisterNo)
                 && ( tabTtlStSec1.CashRegisterNoNM == tabTtlStSec2.CashRegisterNoNM)
                 && ( tabTtlStSec1.LiPriSelPrtGdsNoDiv == tabTtlStSec2.LiPriSelPrtGdsNoDiv)
                 && ( tabTtlStSec1.LiPriSelPrtGdsNoDivNM == tabTtlStSec2.LiPriSelPrtGdsNoDivNM)
                 && ( tabTtlStSec1.EnterpriseName == tabTtlStSec2.EnterpriseName )
                 && ( tabTtlStSec1.UpdEmployeeName == tabTtlStSec2.UpdEmployeeName ) );
        }
        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PmTabTtlStSec target)
        {
            ArrayList resList = new ArrayList();
            if ( this.CreateDateTime != target.CreateDateTime ) resList.Add("CreateDateTime");
            if ( this.UpdateDateTime != target.UpdateDateTime ) resList.Add("UpdateDateTime");
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add("EnterpriseCode");
            if ( this.FileHeaderGuid != target.FileHeaderGuid ) resList.Add("FileHeaderGuid");
            if ( this.UpdEmployeeCode != target.UpdEmployeeCode ) resList.Add("UpdEmployeeCode");
            if ( this.UpdAssemblyId1 != target.UpdAssemblyId1 ) resList.Add("UpdAssemblyId1");
            if ( this.UpdAssemblyId2 != target.UpdAssemblyId2 ) resList.Add("UpdAssemblyId2");
            if ( this.LogicalDeleteCode != target.LogicalDeleteCode ) resList.Add("LogicalDeleteCode");
            if ( this.SectionCode != target.SectionCode ) resList.Add("SectionCode");
            if ( this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if ( this.CashRegisterNoNM != target.CashRegisterNoNM) resList.Add("CashRegisterNoNM");
            if ( this.LiPriSelPrtGdsNoDiv != target.LiPriSelPrtGdsNoDiv) resList.Add("LiPriSelPrtGdsNoDiv");
            if (this.LiPriSelPrtGdsNoDivNM != target.LiPriSelPrtGdsNoDivNM) resList.Add("LiPriSelPrtGdsNoDivNM");
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add("EnterpriseName");
            if ( this.UpdEmployeeName != target.UpdEmployeeName ) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���_��)��r����
        /// </summary>
        /// <param name="tabTtlStSec1">��r����PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <param name="tabTtlStSec2">��r����PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PmTabTtlStSec tabTtlStSec1, PmTabTtlStSec tabTtlStSec2)
        {
            ArrayList resList = new ArrayList();
            if ( tabTtlStSec1.CreateDateTime != tabTtlStSec2.CreateDateTime ) resList.Add("CreateDateTime");
            if ( tabTtlStSec1.UpdateDateTime != tabTtlStSec2.UpdateDateTime ) resList.Add("UpdateDateTime");
            if ( tabTtlStSec1.EnterpriseCode != tabTtlStSec2.EnterpriseCode ) resList.Add("EnterpriseCode");
            if ( tabTtlStSec1.FileHeaderGuid != tabTtlStSec2.FileHeaderGuid ) resList.Add("FileHeaderGuid");
            if ( tabTtlStSec1.UpdEmployeeCode != tabTtlStSec2.UpdEmployeeCode ) resList.Add("UpdEmployeeCode");
            if ( tabTtlStSec1.UpdAssemblyId1 != tabTtlStSec2.UpdAssemblyId1 ) resList.Add("UpdAssemblyId1");
            if ( tabTtlStSec1.UpdAssemblyId2 != tabTtlStSec2.UpdAssemblyId2 ) resList.Add("UpdAssemblyId2");
            if ( tabTtlStSec1.LogicalDeleteCode != tabTtlStSec2.LogicalDeleteCode ) resList.Add("LogicalDeleteCode");
            if ( tabTtlStSec1.SectionCode != tabTtlStSec2.SectionCode ) resList.Add("SectionCode");
            if ( tabTtlStSec1.CashRegisterNo != tabTtlStSec2.CashRegisterNo) resList.Add("CashRegisterNo");
            if ( tabTtlStSec1.CashRegisterNoNM != tabTtlStSec2.CashRegisterNoNM) resList.Add("CashRegisterNoNM");
            if ( tabTtlStSec1.LiPriSelPrtGdsNoDiv != tabTtlStSec2.LiPriSelPrtGdsNoDiv) resList.Add("LiPriSelPrtGdsNoDiv");
            if ( tabTtlStSec1.LiPriSelPrtGdsNoDivNM != tabTtlStSec2.LiPriSelPrtGdsNoDivNM) resList.Add("LiPriSelPrtGdsNoDivNM");
            if ( tabTtlStSec1.EnterpriseName != tabTtlStSec2.EnterpriseName ) resList.Add("EnterpriseName");
            if ( tabTtlStSec1.UpdEmployeeName != tabTtlStSec2.UpdEmployeeName ) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
