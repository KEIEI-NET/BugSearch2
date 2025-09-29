using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustSlipNoSet
    /// <summary>
    ///                      ���Ӑ�}�X�^�i�`�[�ԍ��j
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�}�X�^�i�`�[�ԍ��j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/6/13</br>
    /// <br>Genarated Date   :   2008/06/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      : 2008.09.22 30452 ��� �r��</br>
    /// <br>                   PM.NS�Ή�</br>
    /// <br>                   �E���Ӑ�`�[�ԍ��w�b�_�A���Ӑ�`�[�ԍ��t�b�^���폜</br>
    /// </remarks>
    public class CustSlipNoSet
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
        private Int32 _customerCode;

        /// <summary>�v��N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _addUpYearMonth;

        /// <summary>���ݓ��Ӑ�`�[�ԍ�</summary>
        private Int64 _presentCustSlipNo;

        /// <summary>�J�n���Ӑ�`�[�ԍ�</summary>
        private Int64 _startCustSlipNo;

        /// <summary>�I�����Ӑ�`�[�ԍ�</summary>
        private Int64 _endCustSlipNo;

        // --- DEL 2008/09/22 -------------------------------->>>>>
        ///// <summary>���Ӑ�`�[�ԍ��w�b�_</summary>
        //private string _custSlipNoHeader = "";

        ///// <summary>���Ӑ�`�[�ԍ��t�b�^</summary>
        //private string _custSlipNoFooter = "";
        // --- DEL 2008/09/22 --------------------------------<<<<<

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

        /// public propaty name  :  AddUpYearMonth
        /// <summary>�v��N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  PresentCustSlipNo
        /// <summary>���ݓ��Ӑ�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ݓ��Ӑ�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PresentCustSlipNo
        {
            get { return _presentCustSlipNo; }
            set { _presentCustSlipNo = value; }
        }

        /// public propaty name  :  StartCustSlipNo
        /// <summary>�J�n���Ӑ�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StartCustSlipNo
        {
            get { return _startCustSlipNo; }
            set { _startCustSlipNo = value; }
        }

        /// public propaty name  :  EndCustSlipNo
        /// <summary>�I�����Ӑ�`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 EndCustSlipNo
        {
            get { return _endCustSlipNo; }
            set { _endCustSlipNo = value; }
        }

        // --- DEL 2008/09/22 -------------------------------->>>>>
        ///// public propaty name  :  CustSlipNoHeader
        ///// <summary>���Ӑ�`�[�ԍ��w�b�_�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�`�[�ԍ��w�b�_�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string CustSlipNoHeader
        //{
        //    get { return _custSlipNoHeader; }
        //    set { _custSlipNoHeader = value; }
        //}

        ///// public propaty name  :  CustSlipNoFooter
        ///// <summary>���Ӑ�`�[�ԍ��t�b�^�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�`�[�ԍ��t�b�^�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string CustSlipNoFooter
        //{
        //    get { return _custSlipNoFooter; }
        //    set { _custSlipNoFooter = value; }
        //}
        // --- DEL 2008/09/22 --------------------------------<<<<<

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
        /// ���Ӑ�}�X�^�i�`�[�ԍ��j�R���X�g���N�^
        /// </summary>
        /// <returns>CustSlipNoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipNoSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSlipNoSet()
        {
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�ԍ��j�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="addUpYearMonth">�v��N��(YYYYMM)</param>
        /// <param name="presentCustSlipNo">���ݓ��Ӑ�`�[�ԍ�</param>
        /// <param name="startCustSlipNo">�J�n���Ӑ�`�[�ԍ�</param>
        /// <param name="endCustSlipNo">�I�����Ӑ�`�[�ԍ�</param>
        /// <param name="custSlipNoHeader">���Ӑ�`�[�ԍ��w�b�_</param>
        /// <param name="custSlipNoFooter">���Ӑ�`�[�ԍ��t�b�^</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>CustSlipNoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipNoSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSlipNoSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, Int32 addUpYearMonth, Int64 presentCustSlipNo, Int64 startCustSlipNo, Int64 endCustSlipNo, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this.AddUpYearMonth = addUpYearMonth;
            this._presentCustSlipNo = presentCustSlipNo;
            this._startCustSlipNo = startCustSlipNo;
            this._endCustSlipNo = endCustSlipNo;
            //this._custSlipNoHeader = custSlipNoHeader; //DEL 2008/09/22
            //this._custSlipNoFooter = custSlipNoFooter; //DEL 2008/09/22
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�ԍ��j��������
        /// </summary>
        /// <returns>CustSlipNoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CustSlipNoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustSlipNoSet Clone()
        {
            //return new CustSlipNoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._addUpYearMonth, this._presentCustSlipNo, this._startCustSlipNo, this._endCustSlipNo, this._custSlipNoHeader, this._custSlipNoFooter, this._enterpriseName, this._updEmployeeName); //DEL 2008/09/22
            return new CustSlipNoSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._addUpYearMonth, this._presentCustSlipNo, this._startCustSlipNo, this._endCustSlipNo, this._enterpriseName, this._updEmployeeName); //ADD 2008/09/22
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�ԍ��j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustSlipNoSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipNoSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CustSlipNoSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.AddUpYearMonth == target.AddUpYearMonth)
                 && (this.PresentCustSlipNo == target.PresentCustSlipNo)
                 && (this.StartCustSlipNo == target.StartCustSlipNo)
                 && (this.EndCustSlipNo == target.EndCustSlipNo)
                 //&& (this.CustSlipNoHeader == target.CustSlipNoHeader) //DEL 2008/09/22
                 //&& (this.CustSlipNoFooter == target.CustSlipNoFooter) //DEL 2008/09/22
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�ԍ��j��r����
        /// </summary>
        /// <param name="custSlipNoSet1">
        ///                    ��r����CustSlipNoSet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="custSlipNoSet2">��r����CustSlipNoSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipNoSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CustSlipNoSet custSlipNoSet1, CustSlipNoSet custSlipNoSet2)
        {
            return ((custSlipNoSet1.CreateDateTime == custSlipNoSet2.CreateDateTime)
                 && (custSlipNoSet1.UpdateDateTime == custSlipNoSet2.UpdateDateTime)
                 && (custSlipNoSet1.EnterpriseCode == custSlipNoSet2.EnterpriseCode)
                 && (custSlipNoSet1.FileHeaderGuid == custSlipNoSet2.FileHeaderGuid)
                 && (custSlipNoSet1.UpdEmployeeCode == custSlipNoSet2.UpdEmployeeCode)
                 && (custSlipNoSet1.UpdAssemblyId1 == custSlipNoSet2.UpdAssemblyId1)
                 && (custSlipNoSet1.UpdAssemblyId2 == custSlipNoSet2.UpdAssemblyId2)
                 && (custSlipNoSet1.LogicalDeleteCode == custSlipNoSet2.LogicalDeleteCode)
                 && (custSlipNoSet1.CustomerCode == custSlipNoSet2.CustomerCode)
                 && (custSlipNoSet1.AddUpYearMonth == custSlipNoSet2.AddUpYearMonth)
                 && (custSlipNoSet1.PresentCustSlipNo == custSlipNoSet2.PresentCustSlipNo)
                 && (custSlipNoSet1.StartCustSlipNo == custSlipNoSet2.StartCustSlipNo)
                 && (custSlipNoSet1.EndCustSlipNo == custSlipNoSet2.EndCustSlipNo)
                 //&& (custSlipNoSet1.CustSlipNoHeader == custSlipNoSet2.CustSlipNoHeader) //DEL 2008/09/22
                 //&& (custSlipNoSet1.CustSlipNoFooter == custSlipNoSet2.CustSlipNoFooter) //DEL 2008/09/22
                 && (custSlipNoSet1.EnterpriseName == custSlipNoSet2.EnterpriseName)
                 && (custSlipNoSet1.UpdEmployeeName == custSlipNoSet2.UpdEmployeeName));
        }
        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�ԍ��j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CustSlipNoSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipNoSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CustSlipNoSet target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.AddUpYearMonth != target.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (this.PresentCustSlipNo != target.PresentCustSlipNo) resList.Add("PresentCustSlipNo");
            if (this.StartCustSlipNo != target.StartCustSlipNo) resList.Add("StartCustSlipNo");
            if (this.EndCustSlipNo != target.EndCustSlipNo) resList.Add("EndCustSlipNo");
            //if (this.CustSlipNoHeader != target.CustSlipNoHeader) resList.Add("CustSlipNoHeader"); //DEL 2008/09/22
            //if (this.CustSlipNoFooter != target.CustSlipNoFooter) resList.Add("CustSlipNoFooter"); //DEL 2008/09/22
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// ���Ӑ�}�X�^�i�`�[�ԍ��j��r����
        /// </summary>
        /// <param name="custSlipNoSet1">��r����CustSlipNoSet�N���X�̃C���X�^���X</param>
        /// <param name="custSlipNoSet2">��r����CustSlipNoSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustSlipNoSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CustSlipNoSet custSlipNoSet1, CustSlipNoSet custSlipNoSet2)
        {
            ArrayList resList = new ArrayList();
            if (custSlipNoSet1.CreateDateTime != custSlipNoSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (custSlipNoSet1.UpdateDateTime != custSlipNoSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (custSlipNoSet1.EnterpriseCode != custSlipNoSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (custSlipNoSet1.FileHeaderGuid != custSlipNoSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (custSlipNoSet1.UpdEmployeeCode != custSlipNoSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (custSlipNoSet1.UpdAssemblyId1 != custSlipNoSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (custSlipNoSet1.UpdAssemblyId2 != custSlipNoSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (custSlipNoSet1.LogicalDeleteCode != custSlipNoSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (custSlipNoSet1.CustomerCode != custSlipNoSet2.CustomerCode) resList.Add("CustomerCode");
            if (custSlipNoSet1.AddUpYearMonth != custSlipNoSet2.AddUpYearMonth) resList.Add("AddUpYearMonth");
            if (custSlipNoSet1.PresentCustSlipNo != custSlipNoSet2.PresentCustSlipNo) resList.Add("PresentCustSlipNo");
            if (custSlipNoSet1.StartCustSlipNo != custSlipNoSet2.StartCustSlipNo) resList.Add("StartCustSlipNo");
            if (custSlipNoSet1.EndCustSlipNo != custSlipNoSet2.EndCustSlipNo) resList.Add("EndCustSlipNo");
            //if (custSlipNoSet1.CustSlipNoHeader != custSlipNoSet2.CustSlipNoHeader) resList.Add("CustSlipNoHeader"); //DEL 2008/09/22
            //if (custSlipNoSet1.CustSlipNoFooter != custSlipNoSet2.CustSlipNoFooter) resList.Add("CustSlipNoFooter"); //DEL 2008/09/22
            if (custSlipNoSet1.EnterpriseName != custSlipNoSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (custSlipNoSet1.UpdEmployeeName != custSlipNoSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
