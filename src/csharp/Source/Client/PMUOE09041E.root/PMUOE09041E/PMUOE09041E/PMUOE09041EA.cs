using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UOESetting
    /// <summary>
    ///                      UOE���Аݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE���Аݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/12</br>
    /// <br>Genarated Date   :   2008/06/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UOESetting
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

        /// <summary>�`�[�o�͋敪</summary>
        /// <remarks>�`�[�o�͔��s�敪</remarks>
        private Int32 _slipOutputDivCd;

        /// <summary>�t�H���[�`�[�o�͋敪</summary>
        /// <remarks>�t�H���[�`�[�o�͌`��</remarks>
        private Int32 _followSlipOutputDiv;

        /// <summary>�v����t�敪</summary>
        /// <remarks>�`���U������t</remarks>
        private Int32 _addUpADateDiv;

        /// <summary>�݌Ɉꊇ�i�ԋ敪</summary>
        /// <remarks>�݌Ɉꊇ��֕i�ԋ敪</remarks>
        private Int32 _stockBlnktPrtNoDiv;

        /// <summary>���[�J�[�t�H���[�v��敪</summary>
        /// <remarks>���[�J�[�t�H���[�v��敪</remarks>
        private Int32 _makerFollowAddUpDiv;

        /// <summary>�������ɍX�V�敪</summary>
        /// <remarks>�������ɍX�V�敪</remarks>
        private Int32 _distEnterDiv;

        /// <summary>�������_�ݒ�敪</summary>
        /// <remarks>�����c�Ə��ݒ�敪</remarks>
        private Int32 _distSectionSetDiv;

        /// <summary>����͌������}�[�N</summary>
        /// <remarks>����͌������}�[�N</remarks>
        private string _inpSearchRemark = "";

        /// <summary>�݌Ɉꊇ��[���}�[�N</summary>
        /// <remarks>�݌Ɉꊇ��[���}�[�N</remarks>
        private string _stockBlnktRemark = "";

        /// <summary>�`�����}�[�N</summary>
        /// <remarks>�`���U���}�[�N</remarks>
        private string _slipOutputRemark = "";

        /// <summary>�`�����}�[�N�敪</summary>
        /// <remarks>�`���U���}�[�N�敪 ���\����1:�ϰ�(��)�𓝍�������</remarks>
        private Int32 _slipOutputRemarkDiv;

        /// <summary>UOE�`�[���s�敪</summary>
        /// <remarks>UOE�`�[���s�敪(0:���� 1:���Ȃ�)</remarks>
        private Int32 _uOESlipPrtDiv;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";


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

        /// public propaty name  :  SlipOutputDivCd
        /// <summary>�`�[�o�͋敪�v���p�e�B</summary>
        /// <value>�`�[�o�͔��s�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipOutputDivCd
        {
            get { return _slipOutputDivCd; }
            set { _slipOutputDivCd = value; }
        }

        /// public propaty name  :  FollowSlipOutputDiv
        /// <summary>�t�H���[�`�[�o�͋敪�v���p�e�B</summary>
        /// <value>�t�H���[�`�[�o�͌`��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�H���[�`�[�o�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FollowSlipOutputDiv
        {
            get { return _followSlipOutputDiv; }
            set { _followSlipOutputDiv = value; }
        }

        /// public propaty name  :  AddUpADateDiv
        /// <summary>�v����t�敪�v���p�e�B</summary>
        /// <value>�`���U������t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v����t�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddUpADateDiv
        {
            get { return _addUpADateDiv; }
            set { _addUpADateDiv = value; }
        }

        /// public propaty name  :  StockBlnktPrtNoDiv
        /// <summary>�݌Ɉꊇ�i�ԋ敪�v���p�e�B</summary>
        /// <value>�݌Ɉꊇ��֕i�ԋ敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉꊇ�i�ԋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockBlnktPrtNoDiv
        {
            get { return _stockBlnktPrtNoDiv; }
            set { _stockBlnktPrtNoDiv = value; }
        }

        /// public propaty name  :  MakerFollowAddUpDiv
        /// <summary>���[�J�[�t�H���[�v��敪�v���p�e�B</summary>
        /// <value>���[�J�[�t�H���[�v��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�t�H���[�v��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerFollowAddUpDiv
        {
            get { return _makerFollowAddUpDiv; }
            set { _makerFollowAddUpDiv = value; }
        }

        /// public propaty name  :  DistEnterDiv
        /// <summary>�������ɍX�V�敪�v���p�e�B</summary>
        /// <value>�������ɍX�V�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ɍX�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DistEnterDiv
        {
            get { return _distEnterDiv; }
            set { _distEnterDiv = value; }
        }

        /// public propaty name  :  DistSectionSetDiv
        /// <summary>�������_�ݒ�敪�v���p�e�B</summary>
        /// <value>�����c�Ə��ݒ�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������_�ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DistSectionSetDiv
        {
            get { return _distSectionSetDiv; }
            set { _distSectionSetDiv = value; }
        }

        /// public propaty name  :  InpSearchRemark
        /// <summary>����͌������}�[�N�v���p�e�B</summary>
        /// <value>����͌������}�[�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����͌������}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSearchRemark
        {
            get { return _inpSearchRemark; }
            set { _inpSearchRemark = value; }
        }

        /// public propaty name  :  StockBlnktRemark
        /// <summary>�݌Ɉꊇ��[���}�[�N�v���p�e�B</summary>
        /// <value>�݌Ɉꊇ��[���}�[�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɉꊇ��[���}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockBlnktRemark
        {
            get { return _stockBlnktRemark; }
            set { _stockBlnktRemark = value; }
        }

        /// public propaty name  :  SlipOutputRemark
        /// <summary>�`�����}�[�N�v���p�e�B</summary>
        /// <value>�`���U���}�[�N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�����}�[�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipOutputRemark
        {
            get { return _slipOutputRemark; }
            set { _slipOutputRemark = value; }
        }

        /// public propaty name  :  SlipOutputRemarkDiv
        /// <summary>�`�����}�[�N�敪�v���p�e�B</summary>
        /// <value>�`���U���}�[�N�敪 ���\����1:�ϰ�(��)�𓝍�������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�����}�[�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipOutputRemarkDiv
        {
            get { return _slipOutputRemarkDiv; }
            set { _slipOutputRemarkDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE�`�[���s�敪�v���p�e�B</summary>
        /// <value>UOE�`�[���s�敪(0:���� 1:���Ȃ�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�����}�[�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UOESlipPrtDiv
        {
            get { return _uOESlipPrtDiv; }
            set { _uOESlipPrtDiv = value; }
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

        /// <summary>
        /// UOE���Аݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>UOESetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESetting�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESetting()
        {
        }

        /// <summary>
        /// UOE���Аݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="slipOutputDivCd">�`�[�o�͋敪(�`�[�o�͔��s�敪)</param>
        /// <param name="followSlipOutputDiv">�t�H���[�`�[�o�͋敪(�t�H���[�`�[�o�͌`��)</param>
        /// <param name="addUpADateDiv">�v����t�敪(�`���U������t)</param>
        /// <param name="stockBlnktPrtNoDiv">�݌Ɉꊇ�i�ԋ敪(�݌Ɉꊇ��֕i�ԋ敪)</param>
        /// <param name="makerFollowAddUpDiv">���[�J�[�t�H���[�v��敪(���[�J�[�t�H���[�v��敪)</param>
        /// <param name="distEnterDiv">�������ɍX�V�敪(�������ɍX�V�敪)</param>
        /// <param name="distSectionSetDiv">�������_�ݒ�敪(�����c�Ə��ݒ�敪)</param>
        /// <param name="inpSearchRemark">����͌������}�[�N(����͌������}�[�N)</param>
        /// <param name="stockBlnktRemark">�݌Ɉꊇ��[���}�[�N(�݌Ɉꊇ��[���}�[�N)</param>
        /// <param name="slipOutputRemark">�`�����}�[�N(�`���U���}�[�N)</param>
        /// <param name="slipOutputRemarkDiv">�`�����}�[�N�敪(�`���U���}�[�N�敪 ���\����1:�ϰ�(��)�𓝍�������)</param>
        /// <param name="uOESlipPrtDiv">UOE�`�[���s�敪</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>UOESetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESetting�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESetting(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 slipOutputDivCd, Int32 followSlipOutputDiv, Int32 addUpADateDiv, Int32 stockBlnktPrtNoDiv, Int32 makerFollowAddUpDiv, Int32 distEnterDiv, Int32 distSectionSetDiv, string inpSearchRemark, string stockBlnktRemark, string slipOutputRemark, Int32 slipOutputRemarkDiv, Int32 uOESlipPrtDiv, string enterpriseName, string updEmployeeName, string sectionCode)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._slipOutputDivCd = slipOutputDivCd;
            this._followSlipOutputDiv = followSlipOutputDiv;
            this._addUpADateDiv = addUpADateDiv;
            this._stockBlnktPrtNoDiv = stockBlnktPrtNoDiv;
            this._makerFollowAddUpDiv = makerFollowAddUpDiv;
            this._distEnterDiv = distEnterDiv;
            this._distSectionSetDiv = distSectionSetDiv;
            this._inpSearchRemark = inpSearchRemark;
            this._stockBlnktRemark = stockBlnktRemark;
            this._slipOutputRemark = slipOutputRemark;
            this._slipOutputRemarkDiv = slipOutputRemarkDiv;
            this._uOESlipPrtDiv = uOESlipPrtDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._sectionCode = sectionCode;

        }

        /// <summary>
        /// UOE���Аݒ�}�X�^��������
        /// </summary>
        /// <returns>UOESetting�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����UOESetting�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public UOESetting Clone()
        {
            return new UOESetting(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._slipOutputDivCd, this._followSlipOutputDiv, this._addUpADateDiv, this._stockBlnktPrtNoDiv, this._makerFollowAddUpDiv, this._distEnterDiv, this._distSectionSetDiv, this._inpSearchRemark, this._stockBlnktRemark, this._slipOutputRemark, this._slipOutputRemarkDiv, this._uOESlipPrtDiv, this._enterpriseName, this._updEmployeeName, this._sectionCode);
        }

        /// <summary>
        /// UOE���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOESetting�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESetting�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(UOESetting target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SlipOutputDivCd == target.SlipOutputDivCd)
                 && (this.FollowSlipOutputDiv == target.FollowSlipOutputDiv)
                 && (this.AddUpADateDiv == target.AddUpADateDiv)
                 && (this.StockBlnktPrtNoDiv == target.StockBlnktPrtNoDiv)
                 && (this.MakerFollowAddUpDiv == target.MakerFollowAddUpDiv)
                 && (this.DistEnterDiv == target.DistEnterDiv)
                 && (this.DistSectionSetDiv == target.DistSectionSetDiv)
                 && (this.InpSearchRemark == target.InpSearchRemark)
                 && (this.StockBlnktRemark == target.StockBlnktRemark)
                 && (this.SlipOutputRemark == target.SlipOutputRemark)
                 && (this.SlipOutputRemarkDiv == target.SlipOutputRemarkDiv)
                 && (this.UOESlipPrtDiv == target.UOESlipPrtDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.SectionCode == target.SectionCode));
        }

        /// <summary>
        /// UOE���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="uOESetting1">
        ///                    ��r����UOESetting�N���X�̃C���X�^���X
        /// </param>
        /// <param name="uOESetting2">��r����UOESetting�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESetting�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(UOESetting uOESetting1, UOESetting uOESetting2)
        {
            return ((uOESetting1.CreateDateTime == uOESetting2.CreateDateTime)
                 && (uOESetting1.UpdateDateTime == uOESetting2.UpdateDateTime)
                 && (uOESetting1.EnterpriseCode == uOESetting2.EnterpriseCode)
                 && (uOESetting1.FileHeaderGuid == uOESetting2.FileHeaderGuid)
                 && (uOESetting1.UpdEmployeeCode == uOESetting2.UpdEmployeeCode)
                 && (uOESetting1.UpdAssemblyId1 == uOESetting2.UpdAssemblyId1)
                 && (uOESetting1.UpdAssemblyId2 == uOESetting2.UpdAssemblyId2)
                 && (uOESetting1.LogicalDeleteCode == uOESetting2.LogicalDeleteCode)
                 && (uOESetting1.SlipOutputDivCd == uOESetting2.SlipOutputDivCd)
                 && (uOESetting1.FollowSlipOutputDiv == uOESetting2.FollowSlipOutputDiv)
                 && (uOESetting1.AddUpADateDiv == uOESetting2.AddUpADateDiv)
                 && (uOESetting1.StockBlnktPrtNoDiv == uOESetting2.StockBlnktPrtNoDiv)
                 && (uOESetting1.MakerFollowAddUpDiv == uOESetting2.MakerFollowAddUpDiv)
                 && (uOESetting1.DistEnterDiv == uOESetting2.DistEnterDiv)
                 && (uOESetting1.DistSectionSetDiv == uOESetting2.DistSectionSetDiv)
                 && (uOESetting1.InpSearchRemark == uOESetting2.InpSearchRemark)
                 && (uOESetting1.StockBlnktRemark == uOESetting2.StockBlnktRemark)
                 && (uOESetting1.SlipOutputRemark == uOESetting2.SlipOutputRemark)
                 && (uOESetting1.SlipOutputRemarkDiv == uOESetting2.SlipOutputRemarkDiv)
                 && (uOESetting1.UOESlipPrtDiv == uOESetting2.UOESlipPrtDiv)
                 && (uOESetting1.EnterpriseName == uOESetting2.EnterpriseName)
                 && (uOESetting1.UpdEmployeeName == uOESetting2.UpdEmployeeName)
                 && (uOESetting1.SectionCode == uOESetting2.SectionCode));
        }
        /// <summary>
        /// UOE���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�UOESetting�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESetting�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(UOESetting target)
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
            if (this.SlipOutputDivCd != target.SlipOutputDivCd) resList.Add("SlipOutputDivCd");
            if (this.FollowSlipOutputDiv != target.FollowSlipOutputDiv) resList.Add("FollowSlipOutputDiv");
            if (this.AddUpADateDiv != target.AddUpADateDiv) resList.Add("AddUpADateDiv");
            if (this.StockBlnktPrtNoDiv != target.StockBlnktPrtNoDiv) resList.Add("StockBlnktPrtNoDiv");
            if (this.MakerFollowAddUpDiv != target.MakerFollowAddUpDiv) resList.Add("MakerFollowAddUpDiv");
            if (this.DistEnterDiv != target.DistEnterDiv) resList.Add("DistEnterDiv");
            if (this.DistSectionSetDiv != target.DistSectionSetDiv) resList.Add("DistSectionSetDiv");
            if (this.InpSearchRemark != target.InpSearchRemark) resList.Add("InpSearchRemark");
            if (this.StockBlnktRemark != target.StockBlnktRemark) resList.Add("StockBlnktRemark");
            if (this.SlipOutputRemark != target.SlipOutputRemark) resList.Add("SlipOutputRemark");
            if (this.SlipOutputRemarkDiv != target.SlipOutputRemarkDiv) resList.Add("SlipOutputRemarkDiv");
            if (this.UOESlipPrtDiv != target.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");

            return resList;
        }

        /// <summary>
        /// UOE���Аݒ�}�X�^��r����
        /// </summary>
        /// <param name="uOESetting1">��r����UOESetting�N���X�̃C���X�^���X</param>
        /// <param name="uOESetting2">��r����UOESetting�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   UOESetting�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(UOESetting uOESetting1, UOESetting uOESetting2)
        {
            ArrayList resList = new ArrayList();
            if (uOESetting1.CreateDateTime != uOESetting2.CreateDateTime) resList.Add("CreateDateTime");
            if (uOESetting1.UpdateDateTime != uOESetting2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (uOESetting1.EnterpriseCode != uOESetting2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (uOESetting1.FileHeaderGuid != uOESetting2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (uOESetting1.UpdEmployeeCode != uOESetting2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (uOESetting1.UpdAssemblyId1 != uOESetting2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (uOESetting1.UpdAssemblyId2 != uOESetting2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (uOESetting1.LogicalDeleteCode != uOESetting2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (uOESetting1.SlipOutputDivCd != uOESetting2.SlipOutputDivCd) resList.Add("SlipOutputDivCd");
            if (uOESetting1.FollowSlipOutputDiv != uOESetting2.FollowSlipOutputDiv) resList.Add("FollowSlipOutputDiv");
            if (uOESetting1.AddUpADateDiv != uOESetting2.AddUpADateDiv) resList.Add("AddUpADateDiv");
            if (uOESetting1.StockBlnktPrtNoDiv != uOESetting2.StockBlnktPrtNoDiv) resList.Add("StockBlnktPrtNoDiv");
            if (uOESetting1.MakerFollowAddUpDiv != uOESetting2.MakerFollowAddUpDiv) resList.Add("MakerFollowAddUpDiv");
            if (uOESetting1.DistEnterDiv != uOESetting2.DistEnterDiv) resList.Add("DistEnterDiv");
            if (uOESetting1.DistSectionSetDiv != uOESetting2.DistSectionSetDiv) resList.Add("DistSectionSetDiv");
            if (uOESetting1.InpSearchRemark != uOESetting2.InpSearchRemark) resList.Add("InpSearchRemark");
            if (uOESetting1.StockBlnktRemark != uOESetting2.StockBlnktRemark) resList.Add("StockBlnktRemark");
            if (uOESetting1.SlipOutputRemark != uOESetting2.SlipOutputRemark) resList.Add("SlipOutputRemark");
            if (uOESetting1.SlipOutputRemarkDiv != uOESetting2.SlipOutputRemarkDiv) resList.Add("SlipOutputRemarkDiv");
            if (uOESetting1.UOESlipPrtDiv != uOESetting2.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");
            if (uOESetting1.EnterpriseName != uOESetting2.EnterpriseName) resList.Add("EnterpriseName");
            if (uOESetting1.UpdEmployeeName != uOESetting2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (uOESetting1.SectionCode != uOESetting2.SectionCode) resList.Add("SectionCode");

            return resList;
        }
    }
}
