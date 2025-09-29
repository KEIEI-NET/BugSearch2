using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   DeleteCondition
    /// <summary>
    ///                      �폜�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �폜�f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2011/07/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2015/06/08 ���t</br>
    /// <br>�Ǘ��ԍ��@�@�@�@ :   11100068-00</br>
    /// <br>                     REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��</br>  
    /// </remarks>
    public class DeleteCondition
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

        /// <summary>�폜�敪</summary>
        private Int32 _deleteCode;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCode;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���_����</summary>
        private string _sectionName = "";

        /// <summary>�R�[�h1</summary>
        private Int32 _code1;

        /// <summary>�R�[�h2</summary>
        private Int32 _code2;

        /// <summary>�R�[�h3</summary>
        private Int32 _code3;

        /// <summary>�R�[�h4</summary>
        private Int32 _code4;

        /// <summary>���i�폜�敪</summary>
        private Int32 _goodsDeleteCode;

        /// <summary>�����폜�敪</summary>
        private Int32 _joinDeleteCode;

        /// <summary>�|���폜�敪</summary>
        private Int32 _rateDeleteCode; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� 

        /// <summary>���i�폜����</summary>
        private Int32 _goodsDeleteCnt;

        /// <summary>�����폜����</summary>
        private Int32 _joinDeleteCnt;

        /// <summary>�݌ɍ폜����</summary>
        private Int32 _stockDeleteCnt;

        /// <summary>�|���폜����</summary>
        private Int32 _rateDeleteCnt; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� 

        /// <summary>���i���폜����</summary>
        private Int32 _goodsNotDeleteCnt;

        /// <summary>�������폜����</summary>
        private Int32 _joinNotDeleteCnt; 

        /// <summary>�݌ɖ��폜����</summary>
        private Int32 _stockNotDeleteCnt;

        /// <summary>�|���폜����</summary>
        private Int32 _rateNotDeleteCnt; // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��

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

        /// public propaty name  :  DeleteCode
        /// <summary>�폜�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeleteCode
        {
            get { return _deleteCode; }
            set { _deleteCode = value; }
        }

        /// public propaty name  :  GoodsMakerCode
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCode
        {
            get { return _goodsMakerCode; }
            set { _goodsMakerCode = value; }
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

        /// public propaty name  :  SectionName
        /// <summary>���_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  Code1
        /// <summary>�R�[�h1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code1
        {
            get { return _code1; }
            set { _code1 = value; }
        }

        /// public propaty name  :  Code2
        /// <summary>�R�[�h2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code2
        {
            get { return _code2; }
            set { _code2 = value; }
        }

        /// public propaty name  :  Code3
        /// <summary>�R�[�h3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code3
        {
            get { return _code3; }
            set { _code3 = value; }
        }

        /// public propaty name  :  Code4
        /// <summary>�R�[�h4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Code4
        {
            get { return _code4; }
            set { _code4 = value; }
        }

        /// public propaty name  :  GoodsDeleteCode
        /// <summary>���i�폜�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsDeleteCode
        {
            get { return _goodsDeleteCode; }
            set { _goodsDeleteCode = value; }
        }

        /// public propaty name  :  JoinDeleteCode
        /// <summary>�����폜�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDeleteCode
        {
            get { return _joinDeleteCode; }
            set { _joinDeleteCode = value; }
        }

        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
        /// public propaty name  :  RateDeleteCode
        /// <value>�|���폜�敪�v���p�e�B�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateDeleteCode
        {
            get { return _rateDeleteCode; }
            set { _rateDeleteCode = value; }
        }
        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<

        /// public propaty name  :  GoodsDeleteCnt
        /// <summary>���i�폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsDeleteCnt
        {
            get { return _goodsDeleteCnt; }
            set { _goodsDeleteCnt = value; }
        }

        /// public propaty name  :  JoinDeleteCnt
        /// <summary>�����폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinDeleteCnt
        {
            get { return _joinDeleteCnt; }
            set { _joinDeleteCnt = value; }
        }

        /// public propaty name  :  StockDeleteCnt
        /// <summary>�݌ɍ폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɍ폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDeleteCnt
        {
            get { return _stockDeleteCnt; }
            set { _stockDeleteCnt = value; }
        }

        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
        /// public propaty name  :  RateDeleteCnt
        /// <summary>�|���폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateDeleteCnt
        {
            get { return _rateDeleteCnt; }
            set { _rateDeleteCnt = value; }
        }
        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<

        /// public propaty name  :  GoodsNotDeleteCnt
        /// <summary>���i���폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNotDeleteCnt
        {
            get { return _goodsNotDeleteCnt; }
            set { _goodsNotDeleteCnt = value; }
        }

        /// public propaty name  :  JoinNotDeleteCnt
        /// <summary>�������폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinNotDeleteCnt
        {
            get { return _joinNotDeleteCnt; }
            set { _joinNotDeleteCnt = value; }
        }

        /// public propaty name  :  StockNotDeleteCnt
        /// <summary>�݌ɖ��폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɖ��폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockNotDeleteCnt
        {
            get { return _stockNotDeleteCnt; }
            set { _stockNotDeleteCnt = value; }
        }

        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ---->>>>>
        /// public propaty name  :  RateNotDeleteCnt
        /// <summary>�|�����폜�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|�����폜�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateNotDeleteCnt
        {
            get { return _rateNotDeleteCnt; }
            set { _rateNotDeleteCnt = value; }
        }
        // ---- ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C�� ----<<<<<

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
        /// �폜�f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>DeleteCondition�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteCondition�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DeleteCondition()
        {
        }

        /// <summary>
        /// �폜�f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="deleteCode">�폜�敪</param>
        /// <param name="goodsMakerCode">���i���[�J�[�R�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="sectionName">���_����</param>
        /// <param name="code1">�R�[�h1</param>
        /// <param name="code2">�R�[�h2</param>
        /// <param name="code3">�R�[�h3</param>
        /// <param name="code4">�R�[�h4</param>
        /// <param name="goodsDeleteCode">���i�폜�敪</param>
        /// <param name="joinDeleteCode">�����폜�敪</param>
        /// <param name="rateDeleteCode">�|���폜�敪</param>
        /// <param name="goodsDeleteCnt">���i�폜����</param>
        /// <param name="joinDeleteCnt">�����폜����</param>
        /// <param name="stockDeleteCnt">�݌ɍ폜����</param>
        /// <param name="rateDeleteCnt">�|���폜����</param> 
        /// <param name="goodsNotDeleteCnt">���i���폜����</param>
        /// <param name="joinNotDeleteCnt">�������폜����</param>
        /// <param name="stockNotDeleteCnt">�݌ɖ��폜����</param>
        /// <param name="rateNotDeleteCnt">�|�����폜����</param>  
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>DeleteCondition�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteCondition�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        //public DeleteCondition(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 deleteCode, Int32 goodsMakerCode, string sectionCode, string sectionName, Int32 code1, Int32 code2, Int32 code3, Int32 code4, Int32 goodsDeleteCode, Int32 joinDeleteCode, Int32 goodsDeleteCnt, Int32 joinDeleteCnt, Int32 stockDeleteCnt, Int32 goodsNotDeleteCnt, Int32 joinNotDeleteCnt, Int32 stockNotDeleteCnt, string enterpriseName, string updEmployeeName) // DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
        public DeleteCondition(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 deleteCode, Int32 goodsMakerCode, string sectionCode, string sectionName, Int32 code1, Int32 code2, Int32 code3, Int32 code4, Int32 goodsDeleteCode, Int32 joinDeleteCode, Int32 rateDeleteCode, Int32 goodsDeleteCnt, Int32 joinDeleteCnt, Int32 stockDeleteCnt, Int32 rateDeleteCnt, Int32 goodsNotDeleteCnt, Int32 joinNotDeleteCnt, Int32 stockNotDeleteCnt, Int32 rateNotDeleteCnt, string enterpriseName, string updEmployeeName) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._deleteCode = deleteCode;
            this._goodsMakerCode = goodsMakerCode;
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._code1 = code1;
            this._code2 = code2;
            this._code3 = code3;
            this._code4 = code4;
            this._goodsDeleteCode = goodsDeleteCode;
            this._joinDeleteCode = joinDeleteCode;
            this._rateDeleteCode = rateDeleteCode;// ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            this._goodsDeleteCnt = goodsDeleteCnt;
            this._joinDeleteCnt = joinDeleteCnt;
            this._stockDeleteCnt = stockDeleteCnt;
            this._rateDeleteCnt = rateDeleteCnt;// ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            this._goodsNotDeleteCnt = goodsNotDeleteCnt;
            this._joinNotDeleteCnt = joinNotDeleteCnt;
            this._stockNotDeleteCnt = stockNotDeleteCnt;
            this._rateNotDeleteCnt = rateNotDeleteCnt;// ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �폜�f�[�^��������
        /// </summary>
        /// <returns>DeleteCondition�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����DeleteCondition�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DeleteCondition Clone()
        {
            //return new DeleteCondition(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._deleteCode, this._goodsMakerCode, this._sectionCode, this._sectionName, this._code1, this._code2, this._code3, this._code4, this._goodsDeleteCode, this._joinDeleteCode, this._goodsDeleteCnt, this._joinDeleteCnt, this._stockDeleteCnt, this._goodsNotDeleteCnt, this._joinNotDeleteCnt, this._stockNotDeleteCnt, this._enterpriseName, this._updEmployeeName); // DEL ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            return new DeleteCondition(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._deleteCode, this._goodsMakerCode, this._sectionCode, this._sectionName, this._code1, this._code2, this._code3, this._code4, this._goodsDeleteCode, this._joinDeleteCode, this._rateDeleteCode, this._goodsDeleteCnt, this._joinDeleteCnt, this._stockDeleteCnt, this._rateDeleteCnt, this._goodsNotDeleteCnt, this._joinNotDeleteCnt, this._stockNotDeleteCnt, this._rateNotDeleteCnt, this._enterpriseName, this._updEmployeeName); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
        }

        /// <summary>
        /// �폜�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�DeleteCondition�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteCondition�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(DeleteCondition target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.DeleteCode == target.DeleteCode)
                 && (this.GoodsMakerCode == target.GoodsMakerCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.Code1 == target.Code1)
                 && (this.Code2 == target.Code2)
                 && (this.Code3 == target.Code3)
                 && (this.Code4 == target.Code4)
                 && (this.GoodsDeleteCode == target.GoodsDeleteCode)
                 && (this.JoinDeleteCode == target.JoinDeleteCode)
                 && (this.RateDeleteCode == target.RateDeleteCode) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                 && (this.GoodsDeleteCnt == target.GoodsDeleteCnt)
                 && (this.JoinDeleteCnt == target.JoinDeleteCnt)
                 && (this.StockDeleteCnt == target.StockDeleteCnt)
                 && (this.RateDeleteCnt == target.RateDeleteCnt) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                 && (this.GoodsNotDeleteCnt == target.GoodsNotDeleteCnt)
                 && (this.JoinNotDeleteCnt == target.JoinNotDeleteCnt)
                 && (this.StockNotDeleteCnt == target.StockNotDeleteCnt)
                 && (this.RateNotDeleteCnt == target.RateNotDeleteCnt) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �폜�f�[�^��r����
        /// </summary>
        /// <param name="deleteCondition1">
        ///                    ��r����DeleteCondition�N���X�̃C���X�^���X
        /// </param>
        /// <param name="deleteCondition2">��r����DeleteCondition�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteCondition�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(DeleteCondition deleteCondition1, DeleteCondition deleteCondition2)
        {
            return ((deleteCondition1.CreateDateTime == deleteCondition2.CreateDateTime)
                 && (deleteCondition1.UpdateDateTime == deleteCondition2.UpdateDateTime)
                 && (deleteCondition1.EnterpriseCode == deleteCondition2.EnterpriseCode)
                 && (deleteCondition1.FileHeaderGuid == deleteCondition2.FileHeaderGuid)
                 && (deleteCondition1.UpdEmployeeCode == deleteCondition2.UpdEmployeeCode)
                 && (deleteCondition1.UpdAssemblyId1 == deleteCondition2.UpdAssemblyId1)
                 && (deleteCondition1.UpdAssemblyId2 == deleteCondition2.UpdAssemblyId2)
                 && (deleteCondition1.LogicalDeleteCode == deleteCondition2.LogicalDeleteCode)
                 && (deleteCondition1.DeleteCode == deleteCondition2.DeleteCode)
                 && (deleteCondition1.GoodsMakerCode == deleteCondition2.GoodsMakerCode)
                 && (deleteCondition1.SectionCode == deleteCondition2.SectionCode)
                 && (deleteCondition1.SectionName == deleteCondition2.SectionName)
                 && (deleteCondition1.Code1 == deleteCondition2.Code1)
                 && (deleteCondition1.Code2 == deleteCondition2.Code2)
                 && (deleteCondition1.Code3 == deleteCondition2.Code3)
                 && (deleteCondition1.Code4 == deleteCondition2.Code4)
                 && (deleteCondition1.GoodsDeleteCode == deleteCondition2.GoodsDeleteCode)
                 && (deleteCondition1.JoinDeleteCode == deleteCondition2.JoinDeleteCode)
                 && (deleteCondition1.RateDeleteCode == deleteCondition2.RateDeleteCode) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                 && (deleteCondition1.GoodsDeleteCnt == deleteCondition2.GoodsDeleteCnt)
                 && (deleteCondition1.JoinDeleteCnt == deleteCondition2.JoinDeleteCnt)
                 && (deleteCondition1.StockDeleteCnt == deleteCondition2.StockDeleteCnt)
                 && (deleteCondition1.RateDeleteCnt == deleteCondition2.RateDeleteCnt) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                 && (deleteCondition1.GoodsNotDeleteCnt == deleteCondition2.GoodsNotDeleteCnt)
                 && (deleteCondition1.JoinNotDeleteCnt == deleteCondition2.JoinNotDeleteCnt)
                 && (deleteCondition1.StockNotDeleteCnt == deleteCondition2.StockNotDeleteCnt)
                 && (deleteCondition1.RateNotDeleteCnt == deleteCondition2.RateNotDeleteCnt) // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
                 && (deleteCondition1.EnterpriseName == deleteCondition2.EnterpriseName)
                 && (deleteCondition1.UpdEmployeeName == deleteCondition2.UpdEmployeeName));
        }
        /// <summary>
        /// �폜�f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�DeleteCondition�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteCondition�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(DeleteCondition target)
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
            if (this.DeleteCode != target.DeleteCode) resList.Add("DeleteCode");
            if (this.GoodsMakerCode != target.GoodsMakerCode) resList.Add("GoodsMakerCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.Code1 != target.Code1) resList.Add("Code1");
            if (this.Code2 != target.Code2) resList.Add("Code2");
            if (this.Code3 != target.Code3) resList.Add("Code3");
            if (this.Code4 != target.Code4) resList.Add("Code4");
            if (this.GoodsDeleteCode != target.GoodsDeleteCode) resList.Add("GoodsDeleteCode");
            if (this.JoinDeleteCode != target.JoinDeleteCode) resList.Add("JoinDeleteCode");
            if (this.RateDeleteCode != target.RateDeleteCode) resList.Add("RateDeleteCode"); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            if (this.GoodsDeleteCnt != target.GoodsDeleteCnt) resList.Add("GoodsDeleteCnt");
            if (this.JoinDeleteCnt != target.JoinDeleteCnt) resList.Add("JoinDeleteCnt");
            if (this.StockDeleteCnt != target.StockDeleteCnt) resList.Add("StockDeleteCnt");
            if (this.RateDeleteCnt != target.RateDeleteCnt) resList.Add("RateDeleteCnt"); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            if (this.GoodsNotDeleteCnt != target.GoodsNotDeleteCnt) resList.Add("GoodsNotDeleteCnt");
            if (this.JoinNotDeleteCnt != target.JoinNotDeleteCnt) resList.Add("JoinNotDeleteCnt");
            if (this.StockNotDeleteCnt != target.StockNotDeleteCnt) resList.Add("StockNotDeleteCnt");
            if (this.RateNotDeleteCnt != target.RateNotDeleteCnt) resList.Add("RateNotDeleteCnt"); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �폜�f�[�^��r����
        /// </summary>
        /// <param name="deleteCondition1">��r����DeleteCondition�N���X�̃C���X�^���X</param>
        /// <param name="deleteCondition2">��r����DeleteCondition�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DeleteCondition�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(DeleteCondition deleteCondition1, DeleteCondition deleteCondition2)
        {
            ArrayList resList = new ArrayList();
            if (deleteCondition1.CreateDateTime != deleteCondition2.CreateDateTime) resList.Add("CreateDateTime");
            if (deleteCondition1.UpdateDateTime != deleteCondition2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (deleteCondition1.EnterpriseCode != deleteCondition2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (deleteCondition1.FileHeaderGuid != deleteCondition2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (deleteCondition1.UpdEmployeeCode != deleteCondition2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (deleteCondition1.UpdAssemblyId1 != deleteCondition2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (deleteCondition1.UpdAssemblyId2 != deleteCondition2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (deleteCondition1.LogicalDeleteCode != deleteCondition2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (deleteCondition1.DeleteCode != deleteCondition2.DeleteCode) resList.Add("DeleteCode");
            if (deleteCondition1.GoodsMakerCode != deleteCondition2.GoodsMakerCode) resList.Add("GoodsMakerCode");
            if (deleteCondition1.SectionCode != deleteCondition2.SectionCode) resList.Add("SectionCode");
            if (deleteCondition1.SectionName != deleteCondition2.SectionName) resList.Add("SectionName");
            if (deleteCondition1.Code1 != deleteCondition2.Code1) resList.Add("Code1");
            if (deleteCondition1.Code2 != deleteCondition2.Code2) resList.Add("Code2");
            if (deleteCondition1.Code3 != deleteCondition2.Code3) resList.Add("Code3");
            if (deleteCondition1.Code4 != deleteCondition2.Code4) resList.Add("Code4");
            if (deleteCondition1.GoodsDeleteCode != deleteCondition2.GoodsDeleteCode) resList.Add("GoodsDeleteCode");
            if (deleteCondition1.JoinDeleteCode != deleteCondition2.JoinDeleteCode) resList.Add("JoinDeleteCode");
            if (deleteCondition1.RateDeleteCode != deleteCondition2.RateDeleteCode) resList.Add("RateDeleteCode"); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            if (deleteCondition1.GoodsDeleteCnt != deleteCondition2.GoodsDeleteCnt) resList.Add("GoodsDeleteCnt");
            if (deleteCondition1.JoinDeleteCnt != deleteCondition2.JoinDeleteCnt) resList.Add("JoinDeleteCnt");
            if (deleteCondition1.StockDeleteCnt != deleteCondition2.StockDeleteCnt) resList.Add("StockDeleteCnt");
            if (deleteCondition1.RateDeleteCnt != deleteCondition2.RateDeleteCode) resList.Add("RateDeleteCnt"); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            if (deleteCondition1.GoodsNotDeleteCnt != deleteCondition2.GoodsNotDeleteCnt) resList.Add("GoodsNotDeleteCnt");
            if (deleteCondition1.JoinNotDeleteCnt != deleteCondition2.JoinNotDeleteCnt) resList.Add("JoinNotDeleteCnt");
            if (deleteCondition1.StockNotDeleteCnt != deleteCondition2.StockNotDeleteCnt) resList.Add("StockNotDeleteCnt");
            if (deleteCondition1.RateNotDeleteCnt != deleteCondition2.RateDeleteCode) resList.Add("RateNotDeleteCnt"); // ADD ���t 2015/06/08 for REDMINE#45792�|���}�X�^�폜�E�폜���Ȃ��̐���C��
            if (deleteCondition1.EnterpriseName != deleteCondition2.EnterpriseName) resList.Add("EnterpriseName");
            if (deleteCondition1.UpdEmployeeName != deleteCondition2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
