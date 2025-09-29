using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGroupU
    /// <summary>
    ///                      BL�O���[�v�}�X�^�i���[�U�[�o�^���j
    /// </summary>
    /// <remarks>
    /// <br>note             :   BL�O���[�v�}�X�^�i���[�U�[�o�^���j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2008/09/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/6/5  ����</br>
    /// <br>                 :   �L�[�ύX</br>
    /// <br>                 :   3,10��3,11</br>
    /// <br>Update Note      :   2008/9/2  ����</br>
    /// <br>                 :   ������</br>
    /// <br>                 :   �@�񋟓��t</br>
    /// <br>                 :   �@�񋟃f�[�^�敪</br>
    /// <br>Update Note      :   2008/9/10  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   BL�O���[�v�R�[�h�J�i����</br>
    /// </remarks>
    public class BLGroupU
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

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ށi�}�X�^�L�j</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

        /// <summary>BL�O���[�v�R�[�h�J�i����</summary>
        /// <remarks>���p�J�i</remarks>
        private string _bLGroupKanaName = "";

        /// <summary>�̔��敪�R�[�h</summary>
        /// <remarks>���[�U�[�K�C�h</remarks>
        private Int32 _salesCode;

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>�񋟃f�[�^�敪</summary>
        /// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
        private Int32 _offerDataDiv;

        /// <summary>�񋟃f�[�^�敪����</summary>
        /// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
        private string _offerDataDivName;

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

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ށi�}�X�^�L�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
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

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BL�O���[�v�R�[�h�J�i���̃v���p�e�B</summary>
        /// <value>���p�J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h</value>
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

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  OfferDateJpFormal
        /// <summary>�񋟓��t �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfferDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _offerDate); }
            set { }
        }

        /// public propaty name  :  OfferDateJpInFormal
        /// <summary>�񋟓��t �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfferDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _offerDate); }
            set { }
        }

        /// public propaty name  :  OfferDateAdFormal
        /// <summary>�񋟓��t ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfferDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _offerDate); }
            set { }
        }

        /// public propaty name  :  OfferDateAdInFormal
        /// <summary>�񋟓��t ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfferDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _offerDate); }
            set { }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
        /// <value>0:���[�U�f�[�^,1:�񋟃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟃f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        /// public propaty name  :  OfferDataDivName
        /// <summary>�񋟃f�[�^�敪���̃v���p�e�B</summary>
        /// <value>0:���[�U�f�[�^,1:�񋟃f�[�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟃f�[�^�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OfferDataDivName
        {
            get { return _offerDataDivName; }
            set { _offerDataDivName = value; }
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
        /// BL�O���[�v�}�X�^�i���[�U�[�o�^���j�R���X�g���N�^
        /// </summary>
        /// <returns>BLGroupU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGroupU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGroupU()
        {
        }

        /// <summary>
        /// BL�O���[�v�}�X�^�i���[�U�[�o�^���j�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="goodsLGroup">���i�啪�ރR�[�h(���啪�ށi���[�U�[�K�C�h�j)</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h(�������ށi�}�X�^�L�j)</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h(���O���[�v�R�[�h)</param>
        /// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
        /// <param name="bLGroupKanaName">BL�O���[�v�R�[�h�J�i����(���p�J�i)</param>
        /// <param name="salesCode">�̔��敪�R�[�h(���[�U�[�K�C�h)</param>
        /// <param name="offerDate">�񋟓��t(YYYYMMDD)</param>
        /// <param name="offerDataDiv">�񋟃f�[�^�敪(0:���[�U�f�[�^,1:�񋟃f�[�^)</param>
        /// <param name="offerDataDivName">�񋟃f�[�^�敪����(0:���[�U�f�[�^,1:�񋟃f�[�^)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>BLGroupU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGroupU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGroupU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsLGroup, Int32 goodsMGroup, Int32 bLGroupCode, string bLGroupName, string bLGroupKanaName, Int32 salesCode, DateTime offerDate, Int32 offerDataDiv, string offerDataDivName, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsLGroup = goodsLGroup;
            this._goodsMGroup = goodsMGroup;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._bLGroupKanaName = bLGroupKanaName;
            this._salesCode = salesCode;
            this._offerDate = offerDate;
            this._offerDataDiv = offerDataDiv;
            this._offerDataDivName = offerDataDivName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// BL�O���[�v�}�X�^�i���[�U�[�o�^���j��������
        /// </summary>
        /// <returns>BLGroupU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����BLGroupU�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGroupU Clone()
        {
            return new BLGroupU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsLGroup, this._goodsMGroup, this._bLGroupCode, this._bLGroupName, this._bLGroupKanaName, this._salesCode, this._offerDate, this._offerDataDiv, this._offerDataDivName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// BL�O���[�v�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�BLGroupU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGroupU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(BLGroupU target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsLGroup == target.GoodsLGroup)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLGroupKanaName == target.BLGroupKanaName)
                 && (this.SalesCode == target.SalesCode)
                 && (this.OfferDate == target.OfferDate)
                 && (this.OfferDataDiv == target.OfferDataDiv)
                 && (this.OfferDataDivName == target.OfferDataDivName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// BL�O���[�v�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="bLGroupU1">
        ///                    ��r����BLGroupU�N���X�̃C���X�^���X
        /// </param>
        /// <param name="bLGroupU2">��r����BLGroupU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGroupU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(BLGroupU bLGroupU1, BLGroupU bLGroupU2)
        {
            return ((bLGroupU1.CreateDateTime == bLGroupU2.CreateDateTime)
                 && (bLGroupU1.UpdateDateTime == bLGroupU2.UpdateDateTime)
                 && (bLGroupU1.EnterpriseCode == bLGroupU2.EnterpriseCode)
                 && (bLGroupU1.FileHeaderGuid == bLGroupU2.FileHeaderGuid)
                 && (bLGroupU1.UpdEmployeeCode == bLGroupU2.UpdEmployeeCode)
                 && (bLGroupU1.UpdAssemblyId1 == bLGroupU2.UpdAssemblyId1)
                 && (bLGroupU1.UpdAssemblyId2 == bLGroupU2.UpdAssemblyId2)
                 && (bLGroupU1.LogicalDeleteCode == bLGroupU2.LogicalDeleteCode)
                 && (bLGroupU1.GoodsLGroup == bLGroupU2.GoodsLGroup)
                 && (bLGroupU1.GoodsMGroup == bLGroupU2.GoodsMGroup)
                 && (bLGroupU1.BLGroupCode == bLGroupU2.BLGroupCode)
                 && (bLGroupU1.BLGroupName == bLGroupU2.BLGroupName)
                 && (bLGroupU1.BLGroupKanaName == bLGroupU2.BLGroupKanaName)
                 && (bLGroupU1.SalesCode == bLGroupU2.SalesCode)
                 && (bLGroupU1.OfferDate == bLGroupU2.OfferDate)
                 && (bLGroupU1.OfferDataDiv == bLGroupU2.OfferDataDiv)
                 && (bLGroupU1.OfferDataDivName == bLGroupU2.OfferDataDivName)
                 && (bLGroupU1.EnterpriseName == bLGroupU2.EnterpriseName)
                 && (bLGroupU1.UpdEmployeeName == bLGroupU2.UpdEmployeeName));
        }
        /// <summary>
        /// BL�O���[�v�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�BLGroupU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGroupU�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(BLGroupU target)
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
            if (this.GoodsLGroup != target.GoodsLGroup) resList.Add("GoodsLGroup");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGroupKanaName != target.BLGroupKanaName) resList.Add("BLGroupKanaName");
            if (this.SalesCode != target.SalesCode) resList.Add("SalesCode");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");
            if (this.OfferDataDivName != target.OfferDataDivName) resList.Add("OfferDataDivName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// BL�O���[�v�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="bLGroupU1">��r����BLGroupU�N���X�̃C���X�^���X</param>
        /// <param name="bLGroupU2">��r����BLGroupU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGroupU�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(BLGroupU bLGroupU1, BLGroupU bLGroupU2)
        {
            ArrayList resList = new ArrayList();
            if (bLGroupU1.CreateDateTime != bLGroupU2.CreateDateTime) resList.Add("CreateDateTime");
            if (bLGroupU1.UpdateDateTime != bLGroupU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (bLGroupU1.EnterpriseCode != bLGroupU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (bLGroupU1.FileHeaderGuid != bLGroupU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (bLGroupU1.UpdEmployeeCode != bLGroupU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (bLGroupU1.UpdAssemblyId1 != bLGroupU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (bLGroupU1.UpdAssemblyId2 != bLGroupU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (bLGroupU1.LogicalDeleteCode != bLGroupU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (bLGroupU1.GoodsLGroup != bLGroupU2.GoodsLGroup) resList.Add("GoodsLGroup");
            if (bLGroupU1.GoodsMGroup != bLGroupU2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (bLGroupU1.BLGroupCode != bLGroupU2.BLGroupCode) resList.Add("BLGroupCode");
            if (bLGroupU1.BLGroupName != bLGroupU2.BLGroupName) resList.Add("BLGroupName");
            if (bLGroupU1.BLGroupKanaName != bLGroupU2.BLGroupKanaName) resList.Add("BLGroupKanaName");
            if (bLGroupU1.SalesCode != bLGroupU2.SalesCode) resList.Add("SalesCode");
            if (bLGroupU1.OfferDate != bLGroupU2.OfferDate) resList.Add("OfferDate");
            if (bLGroupU1.OfferDataDiv != bLGroupU2.OfferDataDiv) resList.Add("OfferDataDiv");
            if (bLGroupU1.OfferDataDivName != bLGroupU2.OfferDataDivName) resList.Add("OfferDataDivName");
            if (bLGroupU1.EnterpriseName != bLGroupU2.EnterpriseName) resList.Add("EnterpriseName");
            if (bLGroupU1.UpdEmployeeName != bLGroupU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
