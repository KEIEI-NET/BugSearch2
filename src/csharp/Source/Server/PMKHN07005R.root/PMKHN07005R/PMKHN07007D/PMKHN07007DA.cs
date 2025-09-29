using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PostcardEnvelopeDMWork
    /// <summary>
    ///                      �o�̓f�t�H���g�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�̓f�t�H���g�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/04/01</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PostcardEnvelopeDMWork
    {
        #region �� Private Member
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�I�v�V���������敪</summary>
        private bool _isOptSection;

        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        private bool _isMainOfficeFunc;

        /// <summary>���_�R�[�h�J�n</summary>
        private string _st_SectionCode;

        /// <summary>���_�R�[�h�I��</summary>
        private string _ed_SectionCode;

        /// <summary>�g�p�}�X�^</summary>
        private int _useMast;

        /// <summary>�o�͋敪</summary>
        private int _outShipDiv;

        /// <summary>����</summary>
        private DateTime _totalDay;

        /// <summary>�Ώۓ��t�J�n��</summary>
        private DateTime _st_AddUpDay;

        /// <summary>�Ώۓ��t�I����</summary>
        private DateTime _ed_AddUpDay;

        /// <summary>���Ӑ�R�[�h�J�n</summary>
        private Int32 _st_CustomerCode;

        /// <summary>���Ӑ�R�[�h�I��</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>�d����R�[�h�J�n</summary>
        private Int32 _st_SupplierCode;

        /// <summary>�d����R�[�h�I��</summary>
        private Int32 _ed_SupplierCode;

        #endregion �� Private Member

        #region �� Public Property
        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ��ƃR�[�h�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

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

        /// public propaty name  :  IsOptSection
        /// <summary>���_�I�v�V���������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�I�v�V���������敪�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>�{�Ћ@�\�v���p�e�B�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �{�Ћ@�\�v���p�e�B�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
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

        /// public propaty name  :  St_SectionCode
        /// <summary>���_�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�R�[�h�J�n�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_SectionCode
        {
            get { return _st_SectionCode; }
            set { _st_SectionCode = value; }
        }


        /// public propaty name  :  Ed_SectionCode
        /// <summary>���_�R�[�h�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�R�[�h�I���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_SectionCode
        {
            get { return _ed_SectionCode; }
            set { _ed_SectionCode = value; }
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

        /// public propaty name  :  UseMast
        /// <summary>�g�p�}�X�^</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �g�p�}�X�^�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int UseMast
        {
            get { return _useMast; }
            set { _useMast = value; }
        }

        /// public propaty name  :  OutShipDiv
        /// <summary>�o�͋敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �o�͋敪�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int OutShipDiv
        {
            get { return _outShipDiv; }
            set { _outShipDiv = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �����v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  St_AddUpDay
        /// <summary>�Ώۓ��t�J�n��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �Ώۓ��t�J�n���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_AddUpDay
        {
            get { return _st_AddUpDay; }
            set { _st_AddUpDay = value; }
        }

        /// public propaty name  :  Ed_AddUpDay
        /// <summary>�Ώۓ��t�I����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �Ώۓ��t�I�����v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_AddUpDay
        {
            get { return _ed_AddUpDay; }
            set { _ed_AddUpDay = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>���Ӑ�R�[�h�J�n</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���Ӑ�R�[�h�J�n�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  : Ed_CustomerCode
        /// <summary>���Ӑ�R�[�h�I��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���Ӑ�R�[�h�I���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  : St_SupplierCode
        /// <summary>�d����R�[�h�J�n</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �d����R�[�h�J�n�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SupplierCode
        {
            get { return _st_SupplierCode; }
            set { _st_SupplierCode = value; }
        }

        /// public propaty name  : Ed_SupplierCode
        /// <summary>�d����R�[�h�I��</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �d����R�[�h�I���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SupplierCode
        {
            get { return _ed_SupplierCode; }
            set { _ed_SupplierCode = value; }
        }
        #endregion �� Private Property

        #region �� Public Enum
        #region �� �o�͋敪�񋓑�
        /// <summary> �o�͋敪�񋓑� </summary>
        public enum OutShipDivState
        {
            /// <summary>�S��</summary>
            All = 0,
            /// <summary>�����L��</summary>
            Claim = 1,
            /// <summary>�`�[�L��</summary>
            Slip = 2,
        }
        #endregion ��

        #region �� �g�p�}�X�^�񋓑�
        /// <summary> �g�p�}�X�^�񋓑� </summary>
        public enum UseMastDivState
        {
            /// <summary>���Ӑ�}�X�^</summary>
            Customer = 0,
            /// <summary>�d����}�X�^</summary>
            Supplier = 1,
            /// <summary>���Ѓ}�X�^</summary>
            Company = 2,
            /// <summary>���_�}�X�^</summary>
            SecInfo = 3,
        }
        #endregion ��
        #endregion �� Public Enum

        /// <summary>
        /// �}�X�^�f�[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PostcardEnvelopeDMWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PostcardEnvelopeDMWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Date             :   2009/04/01</br>
        /// </remarks>
        public PostcardEnvelopeDMWork()
        {

        }
    }
}

