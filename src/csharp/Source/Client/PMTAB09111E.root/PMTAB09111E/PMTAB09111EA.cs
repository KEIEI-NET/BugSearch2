using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PmTabTtlStSec
    /// <summary>
    ///                      �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)
    /// </summary>
    /// <remarks>
    /// <br>note             :   �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2013/05/31 (CSharp File Generated Date)</br>
    /// </remarks>
    public class PmTabTtlStCust
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

        /// <summary>���Ӑ�R�[�h</summary>
        private string _customerCode = "";

        /// <summary>���Ӑ�K�C�h����</summary>
        private string _customerNm = "";

        /// <summary>����i�ԑI���敪</summary>
        private Int32 _blpSendDiv;

        /// <summary>����i�ԑI���敪����</summary>
        private string _blpSendDivNm = "";

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
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerNm
        /// <summary>���Ӑ�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerNm
        {
            get { return _customerNm; }
            set { _customerNm = value; }
        }

        /// public propaty name  :  LiPriSelPrtGdsNoDiv
        /// <summary>����i�ԑI���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����i�ԑI���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlpSendDiv
        {
            get { return _blpSendDiv; }
            set { _blpSendDiv = value; }
        }

        /// public propaty name  :  LiPriSelPrtGdsNoDivNM
        /// <summary>����i�ԑI���敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����i�ԑI���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BlpSendDivNm
        {
            get { return _blpSendDivNm; }
            set { _blpSendDivNm = value; }
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
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�R���X�g���N�^
        /// </summary>
        /// <returns>PmTabTtlStSec�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmTabTtlStCust()
        {
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="customercode">���Ӑ�R�[�h</param>
        /// <param name="customerNm">���Ӑ於��</param>
        /// <param name="blpSendDiv">�敪</param>
        /// <param name="blpSendDivNm">�敪����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>PmTabTtlStSec�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmTabTtlStCust(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string customercode, string customerNm, Int32 blpSendDiv, string blpSendDivNm, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customercode;
            this._customerNm = customerNm;
            this._blpSendDiv = blpSendDiv;
            this._blpSendDivNm = blpSendDivNm;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)��������
        /// </summary>
        /// <returns>PmTabTtlStSec�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PmTabTtlStSec�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PmTabTtlStCust Clone()
        {
            return new PmTabTtlStCust(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerNm, this._blpSendDiv, this._blpSendDivNm, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PmTabTtlStCust target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.FileHeaderGuid == target.FileHeaderGuid )
                 && ( this.UpdEmployeeCode == target.UpdEmployeeCode )
                 && ( this.UpdAssemblyId1 == target.UpdAssemblyId1 )
                 && ( this.UpdAssemblyId2 == target.UpdAssemblyId2 )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.CustomerCode == target.CustomerCode)
                 && ( this.CustomerNm == target.CustomerNm)
                 && ( this.BlpSendDiv == target.BlpSendDiv)
                 && ( this.BlpSendDivNm == target.BlpSendDivNm)
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.UpdEmployeeName == target.UpdEmployeeName ) );
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)��r����
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
        public static bool Equals(PmTabTtlStCust tabTtlStSec1, PmTabTtlStCust tabTtlStSec2)
        {
            return ( ( tabTtlStSec1.CreateDateTime == tabTtlStSec2.CreateDateTime )
                 && ( tabTtlStSec1.UpdateDateTime == tabTtlStSec2.UpdateDateTime )
                 && ( tabTtlStSec1.EnterpriseCode == tabTtlStSec2.EnterpriseCode )
                 && ( tabTtlStSec1.FileHeaderGuid == tabTtlStSec2.FileHeaderGuid )
                 && ( tabTtlStSec1.UpdEmployeeCode == tabTtlStSec2.UpdEmployeeCode )
                 && ( tabTtlStSec1.UpdAssemblyId1 == tabTtlStSec2.UpdAssemblyId1 )
                 && ( tabTtlStSec1.UpdAssemblyId2 == tabTtlStSec2.UpdAssemblyId2 )
                 && ( tabTtlStSec1.LogicalDeleteCode == tabTtlStSec2.LogicalDeleteCode )
                 && ( tabTtlStSec1.CustomerCode == tabTtlStSec2.CustomerCode)
                 && ( tabTtlStSec1.CustomerNm == tabTtlStSec2.CustomerNm)
                 && ( tabTtlStSec1.BlpSendDiv == tabTtlStSec2.BlpSendDiv)
                 && ( tabTtlStSec1.BlpSendDivNm == tabTtlStSec2.BlpSendDivNm)
                 && ( tabTtlStSec1.EnterpriseName == tabTtlStSec2.EnterpriseName )
                 && ( tabTtlStSec1.UpdEmployeeName == tabTtlStSec2.UpdEmployeeName ) );
        }
        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PmTabTtlStCust target)
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
            if ( this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if ( this.CustomerNm != target.CustomerNm) resList.Add("CustomerNm");
            if ( this.BlpSendDiv != target.BlpSendDiv) resList.Add("BlpSendDiv");
            if ( this.BlpSendDivNm != target.BlpSendDivNm) resList.Add("BlpSendDivNm");
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add("EnterpriseName");
            if ( this.UpdEmployeeName != target.UpdEmployeeName ) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �^�u���b�g�S�̐ݒ�}�X�^(���Ӑ��)��r����
        /// </summary>
        /// <param name="tabTtlStSec1">��r����PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <param name="tabTtlStSec2">��r����PmTabTtlStSec�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PmTabTtlStSec�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PmTabTtlStCust tabTtlStSec1, PmTabTtlStCust tabTtlStSec2)
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
            if ( tabTtlStSec1.CustomerCode != tabTtlStSec2.CustomerCode) resList.Add("CustomerCode");
            if ( tabTtlStSec1.CustomerNm != tabTtlStSec2.CustomerNm) resList.Add("CustomerNm");
            if ( tabTtlStSec1.BlpSendDiv != tabTtlStSec2.BlpSendDiv) resList.Add("BlpSendDiv");
            if ( tabTtlStSec1.BlpSendDivNm != tabTtlStSec2.BlpSendDivNm) resList.Add("BlpSendDivNm");
            if ( tabTtlStSec1.EnterpriseName != tabTtlStSec2.EnterpriseName ) resList.Add("EnterpriseName");
            if ( tabTtlStSec1.UpdEmployeeName != tabTtlStSec2.UpdEmployeeName ) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
