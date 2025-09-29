using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AccRecDepoTotal
    /// <summary>
    ///                      ���|�����W�v�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���|�����W�v�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/4/23</br>
    /// <br>Genarated Date   :   2009/01/08  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class AccRecDepoTotal
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

        /// <summary>�v�㋒�_�R�[�h</summary>
        /// <remarks>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</remarks>
        private string _addUpSecCode = "";

        /// <summary>������R�[�h</summary>
        /// <remarks>������e�R�[�h</remarks>
        private Int32 _claimCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�v��N����</summary>
        /// <remarks>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</remarks>
        private DateTime _addUpDate;

        /// <summary>����R�[�h</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode;

        /// <summary>���햼��</summary>
        private string _moneyKindName = "";

        /// <summary>����敪</summary>
        private Int32 _moneyKindDiv;

        /// <summary>�������z</summary>
        /// <remarks>�l���E�萔�����������z</remarks>
        private Int64 _deposit;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�v�㋒�_����</summary>
        private string _addUpSecName = "";

        /// <summary>����敪����</summary>
        private string _moneyKindDivName = "";


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>�v�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h</value>
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

        /// public propaty name  :  ClaimCode
        /// <summary>������R�[�h�v���p�e�B</summary>
        /// <value>������e�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
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

        /// public propaty name  :  AddUpDate
        /// <summary>�v��N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  AddUpDateJpFormal
        /// <summary>�v��N���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateJpInFormal
        /// <summary>�v��N���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateAdFormal
        /// <summary>�v��N���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  AddUpDateAdInFormal
        /// <summary>�v��N���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v��N���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _addUpDate); }
            set { }
        }

        /// public propaty name  :  MoneyKindCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode
        {
            get { return _moneyKindCode; }
            set { _moneyKindCode = value; }
        }

        /// public propaty name  :  MoneyKindName
        /// <summary>���햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName
        {
            get { return _moneyKindName; }
            set { _moneyKindName = value; }
        }

        /// public propaty name  :  MoneyKindDiv
        /// <summary>����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv
        {
            get { return _moneyKindDiv; }
            set { _moneyKindDiv = value; }
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

        /// public propaty name  :  AddUpSecName
        /// <summary>�v�㋒�_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSecName
        {
            get { return _addUpSecName; }
            set { _addUpSecName = value; }
        }

        /// public propaty name  :  MoneyKindDivName
        /// <summary>����敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindDivName
        {
            get { return _moneyKindDivName; }
            set { _moneyKindDivName = value; }
        }


        /// <summary>
        /// ���|�����W�v�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>AccRecDepoTotal�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccRecDepoTotal�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AccRecDepoTotal()
        {
        }

        /// <summary>
        /// ���|�����W�v�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="addUpSecCode">�v�㋒�_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="claimCode">������R�[�h(������e�R�[�h)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="addUpDate">�v��N����(YYYYMMDD ���В����s�Ȃ������i���В��ߊ�j)</param>
        /// <param name="moneyKindCode">����R�[�h(1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����)</param>
        /// <param name="moneyKindName">���햼��</param>
        /// <param name="moneyKindDiv">����敪</param>
        /// <param name="deposit">�������z(�l���E�萔�����������z)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="addUpSecName">�v�㋒�_����</param>
        /// <param name="moneyKindDivName">����敪����</param>
        /// <returns>AccRecDepoTotal�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccRecDepoTotal�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AccRecDepoTotal(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string addUpSecCode, Int32 claimCode, Int32 customerCode, DateTime addUpDate, Int32 moneyKindCode, string moneyKindName, Int32 moneyKindDiv, Int64 deposit, string enterpriseName, string updEmployeeName, string addUpSecName, string moneyKindDivName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._addUpSecCode = addUpSecCode;
            this._claimCode = claimCode;
            this._customerCode = customerCode;
            this.AddUpDate = addUpDate;
            this._moneyKindCode = moneyKindCode;
            this._moneyKindName = moneyKindName;
            this._moneyKindDiv = moneyKindDiv;
            this._deposit = deposit;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._addUpSecName = addUpSecName;
            this._moneyKindDivName = moneyKindDivName;

        }

        /// <summary>
        /// ���|�����W�v�f�[�^��������
        /// </summary>
        /// <returns>AccRecDepoTotal�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����AccRecDepoTotal�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public AccRecDepoTotal Clone()
        {
            return new AccRecDepoTotal(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._addUpSecCode, this._claimCode, this._customerCode, this._addUpDate, this._moneyKindCode, this._moneyKindName, this._moneyKindDiv, this._deposit, this._enterpriseName, this._updEmployeeName, this._addUpSecName, this._moneyKindDivName);
        }

        /// <summary>
        /// ���|�����W�v�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AccRecDepoTotal�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccRecDepoTotal�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(AccRecDepoTotal target)
        {
            return ( ( this.CreateDateTime == target.CreateDateTime )
                 && ( this.UpdateDateTime == target.UpdateDateTime )
                 && ( this.EnterpriseCode == target.EnterpriseCode )
                 && ( this.FileHeaderGuid == target.FileHeaderGuid )
                 && ( this.UpdEmployeeCode == target.UpdEmployeeCode )
                 && ( this.UpdAssemblyId1 == target.UpdAssemblyId1 )
                 && ( this.UpdAssemblyId2 == target.UpdAssemblyId2 )
                 && ( this.LogicalDeleteCode == target.LogicalDeleteCode )
                 && ( this.AddUpSecCode == target.AddUpSecCode )
                 && ( this.ClaimCode == target.ClaimCode )
                 && ( this.CustomerCode == target.CustomerCode )
                 && ( this.AddUpDate == target.AddUpDate )
                 && ( this.MoneyKindCode == target.MoneyKindCode )
                 && ( this.MoneyKindName == target.MoneyKindName )
                 && ( this.MoneyKindDiv == target.MoneyKindDiv )
                 && ( this.Deposit == target.Deposit )
                 && ( this.EnterpriseName == target.EnterpriseName )
                 && ( this.UpdEmployeeName == target.UpdEmployeeName )
                 && ( this.AddUpSecName == target.AddUpSecName )
                 && ( this.MoneyKindDivName == target.MoneyKindDivName ) );
        }

        /// <summary>
        /// ���|�����W�v�f�[�^��r����
        /// </summary>
        /// <param name="accRecDepoTotal1">
        ///                    ��r����AccRecDepoTotal�N���X�̃C���X�^���X
        /// </param>
        /// <param name="accRecDepoTotal2">��r����AccRecDepoTotal�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccRecDepoTotal�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(AccRecDepoTotal accRecDepoTotal1, AccRecDepoTotal accRecDepoTotal2)
        {
            return ( ( accRecDepoTotal1.CreateDateTime == accRecDepoTotal2.CreateDateTime )
                 && ( accRecDepoTotal1.UpdateDateTime == accRecDepoTotal2.UpdateDateTime )
                 && ( accRecDepoTotal1.EnterpriseCode == accRecDepoTotal2.EnterpriseCode )
                 && ( accRecDepoTotal1.FileHeaderGuid == accRecDepoTotal2.FileHeaderGuid )
                 && ( accRecDepoTotal1.UpdEmployeeCode == accRecDepoTotal2.UpdEmployeeCode )
                 && ( accRecDepoTotal1.UpdAssemblyId1 == accRecDepoTotal2.UpdAssemblyId1 )
                 && ( accRecDepoTotal1.UpdAssemblyId2 == accRecDepoTotal2.UpdAssemblyId2 )
                 && ( accRecDepoTotal1.LogicalDeleteCode == accRecDepoTotal2.LogicalDeleteCode )
                 && ( accRecDepoTotal1.AddUpSecCode == accRecDepoTotal2.AddUpSecCode )
                 && ( accRecDepoTotal1.ClaimCode == accRecDepoTotal2.ClaimCode )
                 && ( accRecDepoTotal1.CustomerCode == accRecDepoTotal2.CustomerCode )
                 && ( accRecDepoTotal1.AddUpDate == accRecDepoTotal2.AddUpDate )
                 && ( accRecDepoTotal1.MoneyKindCode == accRecDepoTotal2.MoneyKindCode )
                 && ( accRecDepoTotal1.MoneyKindName == accRecDepoTotal2.MoneyKindName )
                 && ( accRecDepoTotal1.MoneyKindDiv == accRecDepoTotal2.MoneyKindDiv )
                 && ( accRecDepoTotal1.Deposit == accRecDepoTotal2.Deposit )
                 && ( accRecDepoTotal1.EnterpriseName == accRecDepoTotal2.EnterpriseName )
                 && ( accRecDepoTotal1.UpdEmployeeName == accRecDepoTotal2.UpdEmployeeName )
                 && ( accRecDepoTotal1.AddUpSecName == accRecDepoTotal2.AddUpSecName )
                 && ( accRecDepoTotal1.MoneyKindDivName == accRecDepoTotal2.MoneyKindDivName ) );
        }
        /// <summary>
        /// ���|�����W�v�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�AccRecDepoTotal�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccRecDepoTotal�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(AccRecDepoTotal target)
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
            if (this.AddUpSecCode != target.AddUpSecCode) resList.Add("AddUpSecCode");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.AddUpDate != target.AddUpDate) resList.Add("AddUpDate");
            if (this.MoneyKindCode != target.MoneyKindCode) resList.Add("MoneyKindCode");
            if (this.MoneyKindName != target.MoneyKindName) resList.Add("MoneyKindName");
            if (this.MoneyKindDiv != target.MoneyKindDiv) resList.Add("MoneyKindDiv");
            if (this.Deposit != target.Deposit) resList.Add("Deposit");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.AddUpSecName != target.AddUpSecName) resList.Add("AddUpSecName");
            if (this.MoneyKindDivName != target.MoneyKindDivName) resList.Add("MoneyKindDivName");

            return resList;
        }

        /// <summary>
        /// ���|�����W�v�f�[�^��r����
        /// </summary>
        /// <param name="accRecDepoTotal1">��r����AccRecDepoTotal�N���X�̃C���X�^���X</param>
        /// <param name="accRecDepoTotal2">��r����AccRecDepoTotal�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   AccRecDepoTotal�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(AccRecDepoTotal accRecDepoTotal1, AccRecDepoTotal accRecDepoTotal2)
        {
            ArrayList resList = new ArrayList();
            if (accRecDepoTotal1.CreateDateTime != accRecDepoTotal2.CreateDateTime) resList.Add("CreateDateTime");
            if (accRecDepoTotal1.UpdateDateTime != accRecDepoTotal2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (accRecDepoTotal1.EnterpriseCode != accRecDepoTotal2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (accRecDepoTotal1.FileHeaderGuid != accRecDepoTotal2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (accRecDepoTotal1.UpdEmployeeCode != accRecDepoTotal2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (accRecDepoTotal1.UpdAssemblyId1 != accRecDepoTotal2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (accRecDepoTotal1.UpdAssemblyId2 != accRecDepoTotal2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (accRecDepoTotal1.LogicalDeleteCode != accRecDepoTotal2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (accRecDepoTotal1.AddUpSecCode != accRecDepoTotal2.AddUpSecCode) resList.Add("AddUpSecCode");
            if (accRecDepoTotal1.ClaimCode != accRecDepoTotal2.ClaimCode) resList.Add("ClaimCode");
            if (accRecDepoTotal1.CustomerCode != accRecDepoTotal2.CustomerCode) resList.Add("CustomerCode");
            if (accRecDepoTotal1.AddUpDate != accRecDepoTotal2.AddUpDate) resList.Add("AddUpDate");
            if (accRecDepoTotal1.MoneyKindCode != accRecDepoTotal2.MoneyKindCode) resList.Add("MoneyKindCode");
            if (accRecDepoTotal1.MoneyKindName != accRecDepoTotal2.MoneyKindName) resList.Add("MoneyKindName");
            if (accRecDepoTotal1.MoneyKindDiv != accRecDepoTotal2.MoneyKindDiv) resList.Add("MoneyKindDiv");
            if (accRecDepoTotal1.Deposit != accRecDepoTotal2.Deposit) resList.Add("Deposit");
            if (accRecDepoTotal1.EnterpriseName != accRecDepoTotal2.EnterpriseName) resList.Add("EnterpriseName");
            if (accRecDepoTotal1.UpdEmployeeName != accRecDepoTotal2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (accRecDepoTotal1.AddUpSecName != accRecDepoTotal2.AddUpSecName) resList.Add("AddUpSecName");
            if (accRecDepoTotal1.MoneyKindDivName != accRecDepoTotal2.MoneyKindDivName) resList.Add("MoneyKindDivName");

            return resList;
        }
    }
}
