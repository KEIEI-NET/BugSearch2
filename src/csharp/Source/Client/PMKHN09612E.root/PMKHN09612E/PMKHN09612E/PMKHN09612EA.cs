using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignPrcPrSt
    /// <summary>
    ///                      �L�����y�[�������D��ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[�������D��ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignPrcPrSt
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
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>�D��ݒ�R�[�h�P</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd1;

        /// <summary>�D��ݒ�R�[�h�Q</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd2;

        /// <summary>�D��ݒ�R�[�h�R</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd3;

        /// <summary>�D��ݒ�R�[�h�S</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd4;

        /// <summary>�D��ݒ�R�[�h�T</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd5;

        /// <summary>�D��ݒ�R�[�h�U</summary>
        /// <remarks>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</remarks>
        private Int32 _prioritySettingCd6;

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
        /// <value>00�͑S��</value>
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

        /// public propaty name  :  PrioritySettingCd1
        /// <summary>�D��ݒ�R�[�h�P�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd1
        {
            get { return _prioritySettingCd1; }
            set { _prioritySettingCd1 = value; }
        }

        /// public propaty name  :  PrioritySettingCd2
        /// <summary>�D��ݒ�R�[�h�Q�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd2
        {
            get { return _prioritySettingCd2; }
            set { _prioritySettingCd2 = value; }
        }

        /// public propaty name  :  PrioritySettingCd3
        /// <summary>�D��ݒ�R�[�h�R�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd3
        {
            get { return _prioritySettingCd3; }
            set { _prioritySettingCd3 = value; }
        }

        /// public propaty name  :  PrioritySettingCd4
        /// <summary>�D��ݒ�R�[�h�S�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�S�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd4
        {
            get { return _prioritySettingCd4; }
            set { _prioritySettingCd4 = value; }
        }

        /// public propaty name  :  PrioritySettingCd5
        /// <summary>�D��ݒ�R�[�h�T�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�T�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd5
        {
            get { return _prioritySettingCd5; }
            set { _prioritySettingCd5 = value; }
        }

        /// public propaty name  :  PrioritySettingCd6
        /// <summary>�D��ݒ�R�[�h�U�v���p�e�B</summary>
        /// <value>0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D��ݒ�R�[�h�U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrioritySettingCd6
        {
            get { return _prioritySettingCd6; }
            set { _prioritySettingCd6 = value; }
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
        /// �L�����y�[�������D��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignPrcPrSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignPrcPrSt()
        {
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="prioritySettingCd1">�D��ݒ�R�[�h�P(0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪)</param>
        /// <param name="prioritySettingCd2">�D��ݒ�R�[�h�Q(0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪)</param>
        /// <param name="prioritySettingCd3">�D��ݒ�R�[�h�R(0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪)</param>
        /// <param name="prioritySettingCd4">�D��ݒ�R�[�h�S(0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪)</param>
        /// <param name="prioritySettingCd5">�D��ݒ�R�[�h�T(0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪)</param>
        /// <param name="prioritySettingCd6">�D��ݒ�R�[�h�U(0�F�Ȃ�,1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>CampaignPrcPrSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignPrcPrSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 prioritySettingCd1, Int32 prioritySettingCd2, Int32 prioritySettingCd3, Int32 prioritySettingCd4, Int32 prioritySettingCd5, Int32 prioritySettingCd6, string enterpriseName, string updEmployeeName)
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
            this._prioritySettingCd1 = prioritySettingCd1;
            this._prioritySettingCd2 = prioritySettingCd2;
            this._prioritySettingCd3 = prioritySettingCd3;
            this._prioritySettingCd4 = prioritySettingCd4;
            this._prioritySettingCd5 = prioritySettingCd5;
            this._prioritySettingCd6 = prioritySettingCd6;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^��������
        /// </summary>
        /// <returns>CampaignPrcPrSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����CampaignPrcPrSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignPrcPrSt Clone()
        {
            return new CampaignPrcPrSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._prioritySettingCd1, this._prioritySettingCd2, this._prioritySettingCd3, this._prioritySettingCd4, this._prioritySettingCd5, this._prioritySettingCd6, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignPrcPrSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(CampaignPrcPrSt target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.PrioritySettingCd1 == target.PrioritySettingCd1)
                 && (this.PrioritySettingCd2 == target.PrioritySettingCd2)
                 && (this.PrioritySettingCd3 == target.PrioritySettingCd3)
                 && (this.PrioritySettingCd4 == target.PrioritySettingCd4)
                 && (this.PrioritySettingCd5 == target.PrioritySettingCd5)
                 && (this.PrioritySettingCd6 == target.PrioritySettingCd6)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignPrcPrSt1">
        ///                    ��r����CampaignPrcPrSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="campaignPrcPrSt2">��r����CampaignPrcPrSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(CampaignPrcPrSt campaignPrcPrSt1, CampaignPrcPrSt campaignPrcPrSt2)
        {
            return ((campaignPrcPrSt1.CreateDateTime == campaignPrcPrSt2.CreateDateTime)
                 && (campaignPrcPrSt1.UpdateDateTime == campaignPrcPrSt2.UpdateDateTime)
                 && (campaignPrcPrSt1.EnterpriseCode == campaignPrcPrSt2.EnterpriseCode)
                 && (campaignPrcPrSt1.FileHeaderGuid == campaignPrcPrSt2.FileHeaderGuid)
                 && (campaignPrcPrSt1.UpdEmployeeCode == campaignPrcPrSt2.UpdEmployeeCode)
                 && (campaignPrcPrSt1.UpdAssemblyId1 == campaignPrcPrSt2.UpdAssemblyId1)
                 && (campaignPrcPrSt1.UpdAssemblyId2 == campaignPrcPrSt2.UpdAssemblyId2)
                 && (campaignPrcPrSt1.LogicalDeleteCode == campaignPrcPrSt2.LogicalDeleteCode)
                 && (campaignPrcPrSt1.SectionCode == campaignPrcPrSt2.SectionCode)
                 && (campaignPrcPrSt1.PrioritySettingCd1 == campaignPrcPrSt2.PrioritySettingCd1)
                 && (campaignPrcPrSt1.PrioritySettingCd2 == campaignPrcPrSt2.PrioritySettingCd2)
                 && (campaignPrcPrSt1.PrioritySettingCd3 == campaignPrcPrSt2.PrioritySettingCd3)
                 && (campaignPrcPrSt1.PrioritySettingCd4 == campaignPrcPrSt2.PrioritySettingCd4)
                 && (campaignPrcPrSt1.PrioritySettingCd5 == campaignPrcPrSt2.PrioritySettingCd5)
                 && (campaignPrcPrSt1.PrioritySettingCd6 == campaignPrcPrSt2.PrioritySettingCd6)
                 && (campaignPrcPrSt1.EnterpriseName == campaignPrcPrSt2.EnterpriseName)
                 && (campaignPrcPrSt1.UpdEmployeeName == campaignPrcPrSt2.UpdEmployeeName));
        }
        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�CampaignPrcPrSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(CampaignPrcPrSt target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.PrioritySettingCd1 != target.PrioritySettingCd1) resList.Add("PrioritySettingCd1");
            if (this.PrioritySettingCd2 != target.PrioritySettingCd2) resList.Add("PrioritySettingCd2");
            if (this.PrioritySettingCd3 != target.PrioritySettingCd3) resList.Add("PrioritySettingCd3");
            if (this.PrioritySettingCd4 != target.PrioritySettingCd4) resList.Add("PrioritySettingCd4");
            if (this.PrioritySettingCd5 != target.PrioritySettingCd5) resList.Add("PrioritySettingCd5");
            if (this.PrioritySettingCd6 != target.PrioritySettingCd6) resList.Add("PrioritySettingCd6");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="campaignPrcPrSt1">��r����CampaignPrcPrSt�N���X�̃C���X�^���X</param>
        /// <param name="campaignPrcPrSt2">��r����CampaignPrcPrSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignPrcPrSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(CampaignPrcPrSt campaignPrcPrSt1, CampaignPrcPrSt campaignPrcPrSt2)
        {
            ArrayList resList = new ArrayList();
            if (campaignPrcPrSt1.CreateDateTime != campaignPrcPrSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (campaignPrcPrSt1.UpdateDateTime != campaignPrcPrSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (campaignPrcPrSt1.EnterpriseCode != campaignPrcPrSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (campaignPrcPrSt1.FileHeaderGuid != campaignPrcPrSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (campaignPrcPrSt1.UpdEmployeeCode != campaignPrcPrSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (campaignPrcPrSt1.UpdAssemblyId1 != campaignPrcPrSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (campaignPrcPrSt1.UpdAssemblyId2 != campaignPrcPrSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (campaignPrcPrSt1.LogicalDeleteCode != campaignPrcPrSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (campaignPrcPrSt1.SectionCode != campaignPrcPrSt2.SectionCode) resList.Add("SectionCode");
            if (campaignPrcPrSt1.PrioritySettingCd1 != campaignPrcPrSt2.PrioritySettingCd1) resList.Add("PrioritySettingCd1");
            if (campaignPrcPrSt1.PrioritySettingCd2 != campaignPrcPrSt2.PrioritySettingCd2) resList.Add("PrioritySettingCd2");
            if (campaignPrcPrSt1.PrioritySettingCd3 != campaignPrcPrSt2.PrioritySettingCd3) resList.Add("PrioritySettingCd3");
            if (campaignPrcPrSt1.PrioritySettingCd4 != campaignPrcPrSt2.PrioritySettingCd4) resList.Add("PrioritySettingCd4");
            if (campaignPrcPrSt1.PrioritySettingCd5 != campaignPrcPrSt2.PrioritySettingCd5) resList.Add("PrioritySettingCd5");
            if (campaignPrcPrSt1.PrioritySettingCd6 != campaignPrcPrSt2.PrioritySettingCd6) resList.Add("PrioritySettingCd6");
            if (campaignPrcPrSt1.EnterpriseName != campaignPrcPrSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (campaignPrcPrSt1.UpdEmployeeName != campaignPrcPrSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
