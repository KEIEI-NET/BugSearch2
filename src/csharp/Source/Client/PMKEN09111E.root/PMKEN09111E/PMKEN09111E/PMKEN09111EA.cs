using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TBOSearchU
    /// <summary>
    ///                      TBO�����}�X�^�i���[�U�[�o�^�j
    /// </summary>
    /// <remarks>
    /// <br>note             :   TBO�����}�X�^�i���[�U�[�o�^�j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2006/12/6</br>
    /// <br>Genarated Date   :   2008/11/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  ����</br>
    /// <br>                 :   ���Ł�PM.NS�Ή�</br>
    /// <br>Update Note      :   2008/10/17  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   BL���i�R�[�h</br>
    /// </remarks>
    public class TBOSearchU
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

        /// <summary>No.</summary>
        /// <remarks>�K�C�h�p</remarks>
        private int _no;

        /// <summary>BL���i�R�[�h</summary>
        /// <remarks>��:1�`9999 ���[�U�[:10000�`</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>��������</summary>
        /// <remarks>��j1001�F�o�b�e��</remarks>
        private Int32 _equipGenreCode;

        /// <summary>��������</summary>
        /// <remarks>��j100D26L�i�o�b�e���K�i�j</remarks>
        private string _equipName = "";

        /// <summary>�ԗ������\������</summary>
        /// <remarks>4,5,6,7,8������̌������������݂���ꍇ�̘A��</remarks>
        private Int32 _carInfoJoinDispOrder;

        /// <summary>�����惁�[�J�[�R�[�h</summary>
        private Int32 _joinDestMakerCd;

        /// <summary>������i��(�|�t���i��)</summary>
        /// <remarks>�n�C�t���t��</remarks>
        private string _joinDestPartsNo = "";

        /// <summary>�����p�s�x</summary>
        private Double _joinQty;

        /// <summary>�����K�i�E���L����</summary>
        private string _equipSpecialNote = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        /// <summary>�����惁�[�J�[����</summary>
        private string _joinDestMakerName = "";

        /// <summary>������i��</summary>
        private string _joinDestGoodsName = "";
 

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

        /// public propaty name  :  No
        /// <summary>No�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   No�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int No
        {
            get { return _no; }
            set { _no = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// <value>��:1�`9999 ���[�U�[:10000�`</value>
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

        /// public propaty name  :  EquipGenreCode
        /// <summary>�������ރv���p�e�B</summary>
        /// <value>��j1001�F�o�b�e��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EquipGenreCode
        {
            get { return _equipGenreCode; }
            set { _equipGenreCode = value; }
        }

        /// public propaty name  :  EquipName
        /// <summary>�������̃v���p�e�B</summary>
        /// <value>��j100D26L�i�o�b�e���K�i�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }

        /// public propaty name  :  CarInfoJoinDispOrder
        /// <summary>�ԗ������\�����ʃv���p�e�B</summary>
        /// <value>4,5,6,7,8������̌������������݂���ꍇ�̘A��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԗ������\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarInfoJoinDispOrder
        {
            get { return _carInfoJoinDispOrder; }
            set { _carInfoJoinDispOrder = value; }
        }

        /// public propaty name  :  JoinDestMakerCd
        /// <summary>�����惁�[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����惁�[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDestMakerCd
        {
            get { return _joinDestMakerCd; }
            set { _joinDestMakerCd = value; }
        }

        /// public propaty name  :  JoinDestPartsNo
        /// <summary>������i��(�|�t���i��)�v���p�e�B</summary>
        /// <value>�n�C�t���t��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������i��(�|�t���i��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinDestPartsNo
        {
            get { return _joinDestPartsNo; }
            set { _joinDestPartsNo = value; }
        }

        /// public propaty name  :  JoinQty
        /// <summary>�����p�s�x�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����p�s�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double JoinQty
        {
            get { return _joinQty; }
            set { _joinQty = value; }
        }

        /// public propaty name  :  EquipSpecialNote
        /// <summary>�����K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EquipSpecialNote
        {
            get { return _equipSpecialNote; }
            set { _equipSpecialNote = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        /// public propaty name  :  JoinDestMakerName
        /// <summary>�����惁�[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����惁�[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinDestMakerName
        {
            get { return _joinDestMakerName; }
            set { _joinDestMakerName = value; }
        }

        /// public propaty name  :  JoinDestGoodsName
        /// <summary>������i���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������i���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string JoinDestGoodsName
        {
            get { return _joinDestGoodsName; }
            set { _joinDestGoodsName = value; }
        }

        /// <summary>
        /// TBO�����}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
        /// </summary>
        /// <returns>TBOSearchU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBOSearchU()
        {
        }

        /// <summary>
        /// TBO�����}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h(��:1�`9999 ���[�U�[:10000�`)</param>
        /// <param name="equipGenreCode">��������(��j1001�F�o�b�e��)</param>
        /// <param name="equipName">��������(��j100D26L�i�o�b�e���K�i�j)</param>
        /// <param name="carInfoJoinDispOrder">�ԗ������\������(4,5,6,7,8������̌������������݂���ꍇ�̘A��)</param>
        /// <param name="joinDestMakerCd">�����惁�[�J�[�R�[�h</param>
        /// <param name="joinDestPartsNo">������i��(�|�t���i��)(�n�C�t���t��)</param>
        /// <param name="joinQty">�����p�s�x</param>
        /// <param name="equipSpecialNote">�����K�i�E���L����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <param name="no">No</param>
        /// <param name="makerName">���[�J�[��</param>
        /// <param name="goodsName">�i��</param>
        /// <returns>TBOSearchU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBOSearchU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 bLGoodsCode, Int32 equipGenreCode, string equipName, Int32 carInfoJoinDispOrder, Int32 joinDestMakerCd, string joinDestPartsNo, Double joinQty, string equipSpecialNote, string enterpriseName, string updEmployeeName, string bLGoodsName, int no, string makerName, string goodsName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._bLGoodsCode = bLGoodsCode;
            this._equipGenreCode = equipGenreCode;
            this._equipName = equipName;
            this._carInfoJoinDispOrder = carInfoJoinDispOrder;
            this._joinDestMakerCd = joinDestMakerCd;
            this._joinDestPartsNo = joinDestPartsNo;
            this._joinQty = joinQty;
            this._equipSpecialNote = equipSpecialNote;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;
            this._no = no;
            this._joinDestMakerName = makerName;
            this._joinDestGoodsName = goodsName;
        }

        /// <summary>
        /// TBO�����}�X�^�i���[�U�[�o�^�j��������
        /// </summary>
        /// <returns>TBOSearchU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����TBOSearchU�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TBOSearchU Clone()
        {
            return new TBOSearchU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._bLGoodsCode, this._equipGenreCode, this._equipName, this._carInfoJoinDispOrder, this._joinDestMakerCd, this._joinDestPartsNo, this._joinQty, this._equipSpecialNote, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._no, this._joinDestMakerName, this._joinDestGoodsName);
        }

        /// <summary>
        /// TBO�����}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TBOSearchU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(TBOSearchU target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.EquipGenreCode == target.EquipGenreCode)
                 && (this.EquipName == target.EquipName)
                 && (this.CarInfoJoinDispOrder == target.CarInfoJoinDispOrder)
                 && (this.JoinDestMakerCd == target.JoinDestMakerCd)
                 && (this.JoinDestPartsNo == target.JoinDestPartsNo)
                 && (this.JoinQty == target.JoinQty)
                 && (this.EquipSpecialNote == target.EquipSpecialNote)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.JoinDestMakerName == target.JoinDestMakerName)
                 && (this.JoinDestGoodsName == target.JoinDestGoodsName)
                 );
        }

        /// <summary>
        /// TBO�����}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="tBOSearchU1">
        ///                    ��r����TBOSearchU�N���X�̃C���X�^���X
        /// </param>
        /// <param name="tBOSearchU2">��r����TBOSearchU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(TBOSearchU tBOSearchU1, TBOSearchU tBOSearchU2)
        {
            return ((tBOSearchU1.CreateDateTime == tBOSearchU2.CreateDateTime)
                 && (tBOSearchU1.UpdateDateTime == tBOSearchU2.UpdateDateTime)
                 && (tBOSearchU1.EnterpriseCode == tBOSearchU2.EnterpriseCode)
                 && (tBOSearchU1.FileHeaderGuid == tBOSearchU2.FileHeaderGuid)
                 && (tBOSearchU1.UpdEmployeeCode == tBOSearchU2.UpdEmployeeCode)
                 && (tBOSearchU1.UpdAssemblyId1 == tBOSearchU2.UpdAssemblyId1)
                 && (tBOSearchU1.UpdAssemblyId2 == tBOSearchU2.UpdAssemblyId2)
                 && (tBOSearchU1.LogicalDeleteCode == tBOSearchU2.LogicalDeleteCode)
                 && (tBOSearchU1.BLGoodsCode == tBOSearchU2.BLGoodsCode)
                 && (tBOSearchU1.EquipGenreCode == tBOSearchU2.EquipGenreCode)
                 && (tBOSearchU1.EquipName == tBOSearchU2.EquipName)
                 && (tBOSearchU1.CarInfoJoinDispOrder == tBOSearchU2.CarInfoJoinDispOrder)
                 && (tBOSearchU1.JoinDestMakerCd == tBOSearchU2.JoinDestMakerCd)
                 && (tBOSearchU1.JoinDestPartsNo == tBOSearchU2.JoinDestPartsNo)
                 && (tBOSearchU1.JoinQty == tBOSearchU2.JoinQty)
                 && (tBOSearchU1.EquipSpecialNote == tBOSearchU2.EquipSpecialNote)
                 && (tBOSearchU1.EnterpriseName == tBOSearchU2.EnterpriseName)
                 && (tBOSearchU1.UpdEmployeeName == tBOSearchU2.UpdEmployeeName)
                 && (tBOSearchU1.BLGoodsName == tBOSearchU2.BLGoodsName)
                 && (tBOSearchU1.JoinDestMakerName == tBOSearchU2.JoinDestMakerName)
                 && (tBOSearchU1.JoinDestGoodsName == tBOSearchU2.JoinDestGoodsName)
                 );
        }
        /// <summary>
        /// TBO�����}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TBOSearchU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchU�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(TBOSearchU target)
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
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.EquipGenreCode != target.EquipGenreCode) resList.Add("EquipGenreCode");
            if (this.EquipName != target.EquipName) resList.Add("EquipName");
            if (this.CarInfoJoinDispOrder != target.CarInfoJoinDispOrder) resList.Add("CarInfoJoinDispOrder");
            if (this.JoinDestMakerCd != target.JoinDestMakerCd) resList.Add("JoinDestMakerCd");
            if (this.JoinDestPartsNo != target.JoinDestPartsNo) resList.Add("JoinDestPartsNo");
            if (this.JoinQty != target.JoinQty) resList.Add("JoinQty");
            if (this.EquipSpecialNote != target.EquipSpecialNote) resList.Add("EquipSpecialNote");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.JoinDestMakerName != target.JoinDestMakerName) resList.Add("JoinDestMakerName");
            if (this.JoinDestGoodsName != target.JoinDestGoodsName) resList.Add("JoinDestGoodsName");

            return resList;
        }

        /// <summary>
        /// TBO�����}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="tBOSearchU1">��r����TBOSearchU�N���X�̃C���X�^���X</param>
        /// <param name="tBOSearchU2">��r����TBOSearchU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TBOSearchU�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(TBOSearchU tBOSearchU1, TBOSearchU tBOSearchU2)
        {
            ArrayList resList = new ArrayList();
            if (tBOSearchU1.CreateDateTime != tBOSearchU2.CreateDateTime) resList.Add("CreateDateTime");
            if (tBOSearchU1.UpdateDateTime != tBOSearchU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (tBOSearchU1.EnterpriseCode != tBOSearchU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (tBOSearchU1.FileHeaderGuid != tBOSearchU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (tBOSearchU1.UpdEmployeeCode != tBOSearchU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (tBOSearchU1.UpdAssemblyId1 != tBOSearchU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (tBOSearchU1.UpdAssemblyId2 != tBOSearchU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (tBOSearchU1.LogicalDeleteCode != tBOSearchU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (tBOSearchU1.BLGoodsCode != tBOSearchU2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (tBOSearchU1.EquipGenreCode != tBOSearchU2.EquipGenreCode) resList.Add("EquipGenreCode");
            if (tBOSearchU1.EquipName != tBOSearchU2.EquipName) resList.Add("EquipName");
            if (tBOSearchU1.CarInfoJoinDispOrder != tBOSearchU2.CarInfoJoinDispOrder) resList.Add("CarInfoJoinDispOrder");
            if (tBOSearchU1.JoinDestMakerCd != tBOSearchU2.JoinDestMakerCd) resList.Add("JoinDestMakerCd");
            if (tBOSearchU1.JoinDestPartsNo != tBOSearchU2.JoinDestPartsNo) resList.Add("JoinDestPartsNo");
            if (tBOSearchU1.JoinQty != tBOSearchU2.JoinQty) resList.Add("JoinQty");
            if (tBOSearchU1.EquipSpecialNote != tBOSearchU2.EquipSpecialNote) resList.Add("EquipSpecialNote");
            if (tBOSearchU1.EnterpriseName != tBOSearchU2.EnterpriseName) resList.Add("EnterpriseName");
            if (tBOSearchU1.UpdEmployeeName != tBOSearchU2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (tBOSearchU1.BLGoodsName != tBOSearchU2.BLGoodsName) resList.Add("BLGoodsName");
            if (tBOSearchU1.JoinDestMakerName != tBOSearchU2.JoinDestMakerName) resList.Add("JoinDestMakerName");
            if (tBOSearchU1.JoinDestGoodsName != tBOSearchU2.JoinDestGoodsName) resList.Add("JoinDestGoodsName");

            return resList;
        }
    }
}
