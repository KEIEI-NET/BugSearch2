using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   FrePprGrTr
    /// <summary>
    ///                      ���R���[�O���[�v�U�փ}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[�O���[�v�U�փ}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/3/19</br>
    /// <br>Genarated Date   :   2007/03/27  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   22011 �����@���l</br>
    /// <br>                 :   2007.06.27 ���[���[�U�[�}�ԃR�����g��ǉ�</br>
    /// </remarks>
    public class FrePprGrTr
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

        /// <summary>���R���[�O���[�v�R�[�h</summary>
        /// <remarks>0:�S��,1�`:���[�U�[�o�^</remarks>
        private Int32 _freePrtPprGroupCd;

        /// <summary>�U�փR�[�h</summary>
        private Int32 _transferCode;

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>�o�͖���</summary>
        /// <remarks>�K�C�h���ɕ\�����閼��</remarks>
        private string _displayName = "";

        /// <summary>�o�̓t�@�C����</summary>
        /// <remarks>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</remarks>
        private string _outputFormFileName = "";

        /// <summary>���[�U�[���[ID�}�ԍ�</summary>
        private Int32 _userPrtPprIdDerivNo;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>���R���[�O���[�v����</summary>
        private string _freePrtPprGroupNm = "";

        /// <summary>���[���[�U�[�}�ԃR�����g</summary>
        private string _prtPprUserDerivNoCmt;


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

        /// public propaty name  :  FreePrtPprGroupCd
        /// <summary>���R���[�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>0:�S��,1�`:���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R���[�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FreePrtPprGroupCd
        {
            get { return _freePrtPprGroupCd; }
            set { _freePrtPprGroupCd = value; }
        }

        /// public propaty name  :  TransferCode
        /// <summary>�U�փR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �U�փR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransferCode
        {
            get { return _transferCode; }
            set { _transferCode = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  DisplayName
        /// <summary>�o�͖��̃v���p�e�B</summary>
        /// <value>�K�C�h���ɕ\�����閼��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͖��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        /// public propaty name  :  OutputFormFileName
        /// <summary>�o�̓t�@�C�����v���p�e�B</summary>
        /// <value>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�̓t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OutputFormFileName
        {
            get { return _outputFormFileName; }
            set { _outputFormFileName = value; }
        }

        /// public propaty name  :  UserPrtPprIdDerivNo
        /// <summary>���[�U�[���[ID�}�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�U�[���[ID�}�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UserPrtPprIdDerivNo
        {
            get { return _userPrtPprIdDerivNo; }
            set { _userPrtPprIdDerivNo = value; }
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

        /// public propaty name  :  FreePrtPprGroupNm
        /// <summary>���R���[�O���[�v���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R���[�O���[�v���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FreePrtPprGroupNm
        {
            get { return _freePrtPprGroupNm; }
            set { _freePrtPprGroupNm = value; }
        }

        /// public propaty name  :  PrtPprUserDerivNoCmt
        /// <summary>���[���[�U�[�}�ԃR�����g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���[�U�[�}�ԃR�����g�v���p�e�B</br>
        /// <br>Programer        :   22011 �����@���l</br>
        /// </remarks>
        public string PrtPprUserDerivNoCmt
        {
            get { return _prtPprUserDerivNoCmt; }
            set { _prtPprUserDerivNoCmt = value; }
        }

        /// <summary>
        /// ���R���[�O���[�v�U�փ}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>FrePprGrTr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePprGrTr�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePprGrTr()
        {   
        }

        /// <summary>
        /// ���R���[�O���[�v�U�փ}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h(0:�S��,1�`:���[�U�[�o�^)</param>
        /// <param name="transferCode">�U�փR�[�h</param>
        /// <param name="displayOrder">�\������</param>
        /// <param name="displayName">�o�͖���(�K�C�h���ɕ\�����閼��)</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����(�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID)</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="freePrtPprGroupNm">���R���[�O���[�v����</param>
        /// <param name="prtPprUserDerivNoCmt">���[���[�U�[�}�ԃR�����g</param>
        /// <returns>FrePprGrTr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePprGrTr�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePprGrTr(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 freePrtPprGroupCd, Int32 transferCode, Int32 displayOrder, string displayName, string outputFormFileName, Int32 userPrtPprIdDerivNo, string enterpriseName, string updEmployeeName, string freePrtPprGroupNm, string prtPprUserDerivNoCmt)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._freePrtPprGroupCd = freePrtPprGroupCd;
            this._transferCode = transferCode;
            this._displayOrder = displayOrder;
            this._displayName = displayName;
            this._outputFormFileName = outputFormFileName;
            this._userPrtPprIdDerivNo = userPrtPprIdDerivNo;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._freePrtPprGroupNm = freePrtPprGroupNm;
            this._prtPprUserDerivNoCmt = prtPprUserDerivNoCmt;
        }

        /// <summary>
        /// ���R���[�O���[�v�U�փ}�X�^��������
        /// </summary>
        /// <returns>FrePprGrTr�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����FrePprGrTr�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FrePprGrTr Clone()
        {
            return new FrePprGrTr(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._freePrtPprGroupCd, this._transferCode, this._displayOrder, this._displayName, this._outputFormFileName, this._userPrtPprIdDerivNo, this._enterpriseName, this._updEmployeeName, this._freePrtPprGroupNm, this._prtPprUserDerivNoCmt);
        }

        /// <summary>
        /// ���R���[�O���[�v�U�փ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�FrePprGrTr�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePprGrTr�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(FrePprGrTr target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.FreePrtPprGroupCd == target.FreePrtPprGroupCd)
                 && (this.TransferCode == target.TransferCode)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.DisplayName == target.DisplayName)
                 && (this.OutputFormFileName == target.OutputFormFileName)
                 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.FreePrtPprGroupNm == target.FreePrtPprGroupNm)
                 && (this.PrtPprUserDerivNoCmt == target.PrtPprUserDerivNoCmt)
                 );
        }

        /// <summary>
        /// ���R���[�O���[�v�U�փ}�X�^��r����
        /// </summary>
        /// <param name="frePprGrTr1">
        ///                    ��r����FrePprGrTr�N���X�̃C���X�^���X
        /// </param>
        /// <param name="frePprGrTr2">��r����FrePprGrTr�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePprGrTr�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(FrePprGrTr frePprGrTr1, FrePprGrTr frePprGrTr2)
        {
            return ((frePprGrTr1.CreateDateTime == frePprGrTr2.CreateDateTime)
                 && (frePprGrTr1.UpdateDateTime == frePprGrTr2.UpdateDateTime)
                 && (frePprGrTr1.EnterpriseCode == frePprGrTr2.EnterpriseCode)
                 && (frePprGrTr1.FileHeaderGuid == frePprGrTr2.FileHeaderGuid)
                 && (frePprGrTr1.UpdEmployeeCode == frePprGrTr2.UpdEmployeeCode)
                 && (frePprGrTr1.UpdAssemblyId1 == frePprGrTr2.UpdAssemblyId1)
                 && (frePprGrTr1.UpdAssemblyId2 == frePprGrTr2.UpdAssemblyId2)
                 && (frePprGrTr1.LogicalDeleteCode == frePprGrTr2.LogicalDeleteCode)
                 && (frePprGrTr1.FreePrtPprGroupCd == frePprGrTr2.FreePrtPprGroupCd)
                 && (frePprGrTr1.TransferCode == frePprGrTr2.TransferCode)
                 && (frePprGrTr1.DisplayOrder == frePprGrTr2.DisplayOrder)
                 && (frePprGrTr1.DisplayName == frePprGrTr2.DisplayName)
                 && (frePprGrTr1.OutputFormFileName == frePprGrTr2.OutputFormFileName)
                 && (frePprGrTr1.UserPrtPprIdDerivNo == frePprGrTr2.UserPrtPprIdDerivNo)
                 && (frePprGrTr1.EnterpriseName == frePprGrTr2.EnterpriseName)
                 && (frePprGrTr1.UpdEmployeeName == frePprGrTr2.UpdEmployeeName)
                 && (frePprGrTr1.FreePrtPprGroupNm == frePprGrTr2.FreePrtPprGroupNm)
                 && (frePprGrTr1.PrtPprUserDerivNoCmt == frePprGrTr2.PrtPprUserDerivNoCmt)
                 );
        }
        /// <summary>
        /// ���R���[�O���[�v�U�փ}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�FrePprGrTr�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePprGrTr�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(FrePprGrTr target)
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
            if (this.FreePrtPprGroupCd != target.FreePrtPprGroupCd) resList.Add("FreePrtPprGroupCd");
            if (this.TransferCode != target.TransferCode) resList.Add("TransferCode");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.DisplayName != target.DisplayName) resList.Add("DisplayName");
            if (this.OutputFormFileName != target.OutputFormFileName) resList.Add("OutputFormFileName");
            if (this.UserPrtPprIdDerivNo != target.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.FreePrtPprGroupNm != target.FreePrtPprGroupNm) resList.Add("FreePrtPprGroupNm");
            if (this.PrtPprUserDerivNoCmt != target.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");


            return resList;
        }

        /// <summary>
        /// ���R���[�O���[�v�U�փ}�X�^��r����
        /// </summary>
        /// <param name="frePprGrTr1">��r����FrePprGrTr�N���X�̃C���X�^���X</param>
        /// <param name="frePprGrTr2">��r����FrePprGrTr�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FrePprGrTr�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(FrePprGrTr frePprGrTr1, FrePprGrTr frePprGrTr2)
        {
            ArrayList resList = new ArrayList();
            if (frePprGrTr1.CreateDateTime != frePprGrTr2.CreateDateTime) resList.Add("CreateDateTime");
            if (frePprGrTr1.UpdateDateTime != frePprGrTr2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (frePprGrTr1.EnterpriseCode != frePprGrTr2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (frePprGrTr1.FileHeaderGuid != frePprGrTr2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (frePprGrTr1.UpdEmployeeCode != frePprGrTr2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (frePprGrTr1.UpdAssemblyId1 != frePprGrTr2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (frePprGrTr1.UpdAssemblyId2 != frePprGrTr2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (frePprGrTr1.LogicalDeleteCode != frePprGrTr2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (frePprGrTr1.FreePrtPprGroupCd != frePprGrTr2.FreePrtPprGroupCd) resList.Add("FreePrtPprGroupCd");
            if (frePprGrTr1.TransferCode != frePprGrTr2.TransferCode) resList.Add("TransferCode");
            if (frePprGrTr1.DisplayOrder != frePprGrTr2.DisplayOrder) resList.Add("DisplayOrder");
            if (frePprGrTr1.DisplayName != frePprGrTr2.DisplayName) resList.Add("DisplayName");
            if (frePprGrTr1.OutputFormFileName != frePprGrTr2.OutputFormFileName) resList.Add("OutputFormFileName");
            if (frePprGrTr1.UserPrtPprIdDerivNo != frePprGrTr2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
            if (frePprGrTr1.EnterpriseName != frePprGrTr2.EnterpriseName) resList.Add("EnterpriseName");
            if (frePprGrTr1.UpdEmployeeName != frePprGrTr2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (frePprGrTr1.FreePrtPprGroupNm != frePprGrTr2.FreePrtPprGroupNm) resList.Add("FreePrtPprGroupNm");
            if (frePprGrTr1.PrtPprUserDerivNoCmt != frePprGrTr2.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");

            return resList;
        }
    }
}
