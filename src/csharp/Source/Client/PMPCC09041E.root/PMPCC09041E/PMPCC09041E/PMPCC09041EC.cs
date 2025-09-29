using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PccItemGrid
    /// <summary>
    ///                      �i�ڃO���b�h�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �i�ڃO���b�h�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2011/08/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/5/1  ����</br>
    /// <br>                 :   �d����|���O���[�v�R�[�h���폜</br>
    /// <br>Update Note      :   2008/9/12  ����</br>
    /// <br>                 :   �������C��</br>
    /// <br>                 :   �d����d�b�ԍ�1�̌������P�U�ɕύX</br>
    /// <br>                 :   �d����d�b�ԍ�2�̌������P�U�ɕύX</br>
    /// <br>Update Note      :   2009/1/28  ����</br>
    /// <br>                 :   �������ύX</br>
    /// <br>                 :   �x�����敪����</br>
    /// <br>                 :   nvarchar 3������4����</br>
    /// <br>Update Note      :   2009/2/6  ����</br>
    /// <br>                 :   ���⑫�C��</br>
    /// <br>                 :   �x������</br>
    /// <br>                 :   10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   51:����,52:�U��,53:���؎�,54:��`56:���E,58:���̑�</br>
    /// <br>Update Note      :   2013/05/30 30747 �O�� �L��</br>
    /// <br>                 :   2013/99/99�z�M SCM��Q��10541�Ή�</br>
    /// <br>                 :   �i�ڃO���[�v�摜�R�[�h�ǉ�</br>
    /// </remarks>
    public class PccItemGrid
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

        /// <summary>�⍇������ƃR�[�h</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>�⍇�������_�R�[�h</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>�⍇�����ƃR�[�h</summary>
        private string _inqOtherEpCd = "";

        /// <summary>�⍇���拒�_�R�[�h</summary>
        private string _inqOtherSecCd = "";

        /// <summary>�⍇������</summary>
        private string _inqCondition = "";

        /// <summary>PCC���ЃR�[�h</summary>
        /// <remarks>PM�̓��Ӑ�R�[�h</remarks>
        private Int32 _pccCompanyCode;

        /// <summary>PCC���Ж���</summary>
        private string _pccCompanyName = "";

        /// <summary>�i�ڃO���[�v�R�[�h1</summary>
        /// <remarks>1�`5�̎g�p��z��</remarks>
        private Int32 _itemGroupCode1;

        /// <summary>�i�ڃO���[�v����1</summary>
        private string _itemGroupName1 = "";

        /// <summary>�i�ڃO���[�v�\������1</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int32 _itemGrpDspOdr1;

        /// <summary>�i�ڃO���[�v�R�[�h2</summary>
        /// <remarks>1�`5�̎g�p��z��</remarks>
        private Int32 _itemGroupCode2;

        /// <summary>�i�ڃO���[�v����2</summary>
        private string _itemGroupName2 = "";

        /// <summary>�i�ڃO���[�v�\������2</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int32 _itemGrpDspOdr2;

        /// <summary>�i�ڃO���[�v�R�[�h3</summary>
        /// <remarks>1�`5�̎g�p��z��</remarks>
        private Int32 _itemGroupCode3;

        /// <summary>�i�ڃO���[�v����3</summary>
        private string _itemGroupName3 = "";

        /// <summary>�i�ڃO���[�v�\������3</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int32 _itemGrpDspOdr3;

        /// <summary>�i�ڃO���[�v�R�[�h4</summary>
        /// <remarks>1�`5�̎g�p��z��</remarks>
        private Int32 _itemGroupCode4;

        /// <summary>�i�ڃO���[�v����4</summary>
        private string _itemGroupName4 = "";

        /// <summary>�i�ڃO���[�v�\������4</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int32 _itemGrpDspOdr4;

        /// <summary>�i�ڃO���[�v�R�[�h5</summary>
        /// <remarks>1�`5�̎g�p��z��</remarks>
        private Int32 _itemGroupCode5;

        /// <summary>�i�ڃO���[�v����5</summary>
        private string _itemGroupName5 = "";

        /// <summary>�i�ڃO���[�v�\������5</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int32 _itemGrpDspOdr5;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>�i�ڃO���[�v�摜�R�[�h1</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int16 _itemGrpImgCode1;

        /// <summary>�i�ڃO���[�v�摜�R�[�h2</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int16 _itemGrpImgCode2;

        /// <summary>�i�ڃO���[�v�摜�R�[�h3</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int16 _itemGrpImgCode3;

        /// <summary>�i�ڃO���[�v�摜�R�[�h4</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int16 _itemGrpImgCode4;

        /// <summary>�i�ڃO���[�v�摜�R�[�h5</summary>
        /// <remarks>�����珇��1�`5</remarks>
        private Int16 _itemGrpImgCode5;
        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

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

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>�⍇������ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇������ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>�⍇�������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  InqOtherEpCd
        /// <summary>�⍇�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>�⍇���拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇���拒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

        /// public propaty name  :  InqCondition
        /// <summary>�⍇�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �⍇�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InqCondition
        {
            get { return _inqCondition; }
            set { _inqCondition = value; }
        }

        /// public propaty name  :  PccCompanyCode
        /// <summary>PCC���ЃR�[�h�v���p�e�B</summary>
        /// <value>PM�̓��Ӑ�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���ЃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PccCompanyCode
        {
            get { return _pccCompanyCode; }
            set { _pccCompanyCode = value; }
        }

        /// public propaty name  :  PccCompanyName
        /// <summary>PCC���Ж��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PCC���Ж��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PccCompanyName
        {
            get { return _pccCompanyName; }
            set { _pccCompanyName = value; }
        }

        /// public propaty name  :  ItemGroupCode1
        /// <summary>�i�ڃO���[�v�R�[�h1�v���p�e�B</summary>
        /// <value>1�`5�̎g�p��z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGroupCode1
        {
            get { return _itemGroupCode1; }
            set { _itemGroupCode1 = value; }
        }

        /// public propaty name  :  ItemGroupName1
        /// <summary>�i�ڃO���[�v����1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v����1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ItemGroupName1
        {
            get { return _itemGroupName1; }
            set { _itemGroupName1 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr1
        /// <summary>�i�ڃO���[�v�\������1�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�\������1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr1
        {
            get { return _itemGrpDspOdr1; }
            set { _itemGrpDspOdr1 = value; }
        }

        /// public propaty name  :  ItemGroupCode2
        /// <summary>�i�ڃO���[�v�R�[�h2�v���p�e�B</summary>
        /// <value>1�`5�̎g�p��z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGroupCode2
        {
            get { return _itemGroupCode2; }
            set { _itemGroupCode2 = value; }
        }

        /// public propaty name  :  ItemGroupName2
        /// <summary>�i�ڃO���[�v����2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ItemGroupName2
        {
            get { return _itemGroupName2; }
            set { _itemGroupName2 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr2
        /// <summary>�i�ڃO���[�v�\������2�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�\������2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr2
        {
            get { return _itemGrpDspOdr2; }
            set { _itemGrpDspOdr2 = value; }
        }

        /// public propaty name  :  ItemGroupCode3
        /// <summary>�i�ڃO���[�v�R�[�h3�v���p�e�B</summary>
        /// <value>1�`5�̎g�p��z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGroupCode3
        {
            get { return _itemGroupCode3; }
            set { _itemGroupCode3 = value; }
        }

        /// public propaty name  :  ItemGroupName3
        /// <summary>�i�ڃO���[�v����3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v����3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ItemGroupName3
        {
            get { return _itemGroupName3; }
            set { _itemGroupName3 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr3
        /// <summary>�i�ڃO���[�v�\������3�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�\������3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr3
        {
            get { return _itemGrpDspOdr3; }
            set { _itemGrpDspOdr3 = value; }
        }

        /// public propaty name  :  ItemGroupCode4
        /// <summary>�i�ڃO���[�v�R�[�h4�v���p�e�B</summary>
        /// <value>1�`5�̎g�p��z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGroupCode4
        {
            get { return _itemGroupCode4; }
            set { _itemGroupCode4 = value; }
        }

        /// public propaty name  :  ItemGroupName4
        /// <summary>�i�ڃO���[�v����4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v����4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ItemGroupName4
        {
            get { return _itemGroupName4; }
            set { _itemGroupName4 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr4
        /// <summary>�i�ڃO���[�v�\������4�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�\������4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr4
        {
            get { return _itemGrpDspOdr4; }
            set { _itemGrpDspOdr4 = value; }
        }

        /// public propaty name  :  ItemGroupCode5
        /// <summary>�i�ڃO���[�v�R�[�h5�v���p�e�B</summary>
        /// <value>1�`5�̎g�p��z��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGroupCode5
        {
            get { return _itemGroupCode5; }
            set { _itemGroupCode5 = value; }
        }

        /// public propaty name  :  ItemGroupName5
        /// <summary>�i�ڃO���[�v����5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v����5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ItemGroupName5
        {
            get { return _itemGroupName5; }
            set { _itemGroupName5 = value; }
        }

        /// public propaty name  :  ItemGrpDspOdr5
        /// <summary>�i�ڃO���[�v�\������5�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�\������5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ItemGrpDspOdr5
        {
            get { return _itemGrpDspOdr5; }
            set { _itemGrpDspOdr5 = value; }
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

        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>�i�ڃO���[�v�摜�R�[�h1�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�摜�R�[�h1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ItemGrpImgCode1
        {
            get { return _itemGrpImgCode1; }
            set { _itemGrpImgCode1 = value; }
        }

        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>�i�ڃO���[�v�摜�R�[�h2�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�摜�R�[�h2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ItemGrpImgCode2
        {
            get { return _itemGrpImgCode2; }
            set { _itemGrpImgCode2 = value; }
        }

        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>�i�ڃO���[�v�摜�R�[�h3�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�摜�R�[�h3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ItemGrpImgCode3
        {
            get { return _itemGrpImgCode3; }
            set { _itemGrpImgCode3 = value; }
        }

        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>�i�ڃO���[�v�摜�R�[�h4�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�摜�R�[�h4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ItemGrpImgCode4
        {
            get { return _itemGrpImgCode4; }
            set { _itemGrpImgCode4 = value; }
        }

        /// public propaty name  :  ItemGrpImgCode1
        /// <summary>�i�ڃO���[�v�摜�R�[�h5�v���p�e�B</summary>
        /// <value>�����珇��1�`5</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ڃO���[�v�摜�R�[�h5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 ItemGrpImgCode5
        {
            get { return _itemGrpImgCode5; }
            set { _itemGrpImgCode5 = value; }
        }
        // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �i�ڃO���b�h�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PccItemGrid�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrid�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccItemGrid()
        {
        }

        /// <summary>
        /// �i�ڃO���b�h�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <param name="inqCondition">�⍇������</param>
        /// <param name="pccCompanyCode">PCC���ЃR�[�h(PM�̓��Ӑ�R�[�h)</param>
        /// <param name="pccCompanyName">PCC���Ж���</param>
        /// <param name="itemGroupCode1">�i�ڃO���[�v�R�[�h1(1�`5�̎g�p��z��)</param>
        /// <param name="itemGroupName1">�i�ڃO���[�v����1</param>
        /// <param name="itemGrpDspOdr1">�i�ڃO���[�v�\������1(�����珇��1�`5)</param>
        /// <param name="itemGroupCode2">�i�ڃO���[�v�R�[�h2(1�`5�̎g�p��z��)</param>
        /// <param name="itemGroupName2">�i�ڃO���[�v����2</param>
        /// <param name="itemGrpDspOdr2">�i�ڃO���[�v�\������2(�����珇��1�`5)</param>
        /// <param name="itemGroupCode3">�i�ڃO���[�v�R�[�h3(1�`5�̎g�p��z��)</param>
        /// <param name="itemGroupName3">�i�ڃO���[�v����3</param>
        /// <param name="itemGrpDspOdr3">�i�ڃO���[�v�\������3(�����珇��1�`5)</param>
        /// <param name="itemGroupCode4">�i�ڃO���[�v�R�[�h4(1�`5�̎g�p��z��)</param>
        /// <param name="itemGroupName4">�i�ڃO���[�v����4</param>
        /// <param name="itemGrpDspOdr4">�i�ڃO���[�v�\������4(�����珇��1�`5)</param>
        /// <param name="itemGroupCode5">�i�ڃO���[�v�R�[�h5(1�`5�̎g�p��z��)</param>
        /// <param name="itemGroupName5">�i�ڃO���[�v����5</param>
        /// <param name="itemGrpDspOdr5">�i�ڃO���[�v�\������5(�����珇��1�`5)</param>
        /// <param name="itemGrpImgCode1">�i�ڃO���[�v�摜�R�[�h1</param>
        /// <param name="itemGrpImgCode2">�i�ڃO���[�v�摜�R�[�h2</param>
        /// <param name="itemGrpImgCode3">�i�ڃO���[�v�摜�R�[�h3</param>
        /// <param name="itemGrpImgCode4">�i�ڃO���[�v�摜�R�[�h4</param>
        /// <param name="itemGrpImgCode5">�i�ڃO���[�v�摜�R�[�h5</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>PccItemGrid�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrid�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
        //public PccItemGrid(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, string pccCompanyName, Int32 itemGroupCode1, string itemGroupName1, Int32 itemGrpDspOdr1, Int32 itemGroupCode2, string itemGroupName2, Int32 itemGrpDspOdr2, Int32 itemGroupCode3, string itemGroupName3, Int32 itemGrpDspOdr3, Int32 itemGroupCode4, string itemGroupName4, Int32 itemGrpDspOdr4, Int32 itemGroupCode5, string itemGroupName5, Int32 itemGrpDspOdr5, string enterpriseName, string updEmployeeName)
        public PccItemGrid(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, string inqCondition, Int32 pccCompanyCode, string pccCompanyName, Int32 itemGroupCode1, string itemGroupName1, Int32 itemGrpDspOdr1, Int32 itemGroupCode2, string itemGroupName2, Int32 itemGrpDspOdr2, Int32 itemGroupCode3, string itemGroupName3, Int32 itemGrpDspOdr3, Int32 itemGroupCode4, string itemGroupName4, Int32 itemGrpDspOdr4, Int32 itemGroupCode5, string itemGroupName5, Int32 itemGrpDspOdr5, string enterpriseName, string updEmployeeName, Int16 itemGrpImgCode1, Int16 itemGrpImgCode2, Int16 itemGrpImgCode3, Int16 itemGrpImgCode4, Int16 itemGrpImgCode5)
        // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._inqCondition = inqCondition;
            this._pccCompanyCode = pccCompanyCode;
            this._pccCompanyName = pccCompanyName;
            this._itemGroupCode1 = itemGroupCode1;
            this._itemGroupName1 = itemGroupName1;
            this._itemGrpDspOdr1 = itemGrpDspOdr1;
            this._itemGroupCode2 = itemGroupCode2;
            this._itemGroupName2 = itemGroupName2;
            this._itemGrpDspOdr2 = itemGrpDspOdr2;
            this._itemGroupCode3 = itemGroupCode3;
            this._itemGroupName3 = itemGroupName3;
            this._itemGrpDspOdr3 = itemGrpDspOdr3;
            this._itemGroupCode4 = itemGroupCode4;
            this._itemGroupName4 = itemGroupName4;
            this._itemGrpDspOdr4 = itemGrpDspOdr4;
            this._itemGroupCode5 = itemGroupCode5;
            this._itemGroupName5 = itemGroupName5;
            this._itemGrpDspOdr5 = itemGrpDspOdr5;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            this._itemGrpImgCode1 = itemGrpImgCode1;
            this._itemGrpImgCode2 = itemGrpImgCode2;
            this._itemGrpImgCode3 = itemGrpImgCode3;
            this._itemGrpImgCode4 = itemGrpImgCode4;
            this._itemGrpImgCode5 = itemGrpImgCode5;
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �i�ڃO���b�h�}�X�^��������
        /// </summary>
        /// <returns>PccItemGrid�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PccItemGrid�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PccItemGrid Clone()
        {
            // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            //return new PccItemGrid(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._pccCompanyName, this._itemGroupCode1, this._itemGroupName1, this._itemGrpDspOdr1, this._itemGroupCode2, this._itemGroupName2, this._itemGrpDspOdr2, this._itemGroupCode3, this._itemGroupName3, this._itemGrpDspOdr3, this._itemGroupCode4, this._itemGroupName4, this._itemGrpDspOdr4, this._itemGroupCode5, this._itemGroupName5, this._itemGrpDspOdr5, this._enterpriseName, this._updEmployeeName);
            return new PccItemGrid(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inqCondition, this._pccCompanyCode, this._pccCompanyName, this._itemGroupCode1, this._itemGroupName1, this._itemGrpDspOdr1, this._itemGroupCode2, this._itemGroupName2, this._itemGrpDspOdr2, this._itemGroupCode3, this._itemGroupName3, this._itemGrpDspOdr3, this._itemGroupCode4, this._itemGroupName4, this._itemGrpDspOdr4, this._itemGroupCode5, this._itemGroupName5, this._itemGrpDspOdr5, this._enterpriseName, this._updEmployeeName, this._itemGrpImgCode1, this._itemGrpImgCode2, this._itemGrpImgCode3, this._itemGrpImgCode4, this._itemGrpImgCode5);//@@@@20230303
            // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �i�ڃO���b�h�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccItemGrid�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrid�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PccItemGrid target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.InqCondition == target.InqCondition)
                 && (this.PccCompanyCode == target.PccCompanyCode)
                 && (this.PccCompanyName == target.PccCompanyName)
                 && (this.ItemGroupCode1 == target.ItemGroupCode1)
                 && (this.ItemGroupName1 == target.ItemGroupName1)
                 && (this.ItemGrpDspOdr1 == target.ItemGrpDspOdr1)
                 && (this.ItemGroupCode2 == target.ItemGroupCode2)
                 && (this.ItemGroupName2 == target.ItemGroupName2)
                 && (this.ItemGrpDspOdr2 == target.ItemGrpDspOdr2)
                 && (this.ItemGroupCode3 == target.ItemGroupCode3)
                 && (this.ItemGroupName3 == target.ItemGroupName3)
                 && (this.ItemGrpDspOdr3 == target.ItemGrpDspOdr3)
                 && (this.ItemGroupCode4 == target.ItemGroupCode4)
                 && (this.ItemGroupName4 == target.ItemGroupName4)
                 && (this.ItemGrpDspOdr4 == target.ItemGrpDspOdr4)
                 && (this.ItemGroupCode5 == target.ItemGroupCode5)
                 && (this.ItemGroupName5 == target.ItemGroupName5)
                 && (this.ItemGrpDspOdr5 == target.ItemGrpDspOdr5)
                 && (this.EnterpriseName == target.EnterpriseName)
                // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                 //&& (this.UpdEmployeeName == target.UpdEmployeeName));
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.ItemGrpImgCode1 == target.ItemGrpImgCode1)
                 && (this.ItemGrpImgCode2 == target.ItemGrpImgCode2)
                 && (this.ItemGrpImgCode3 == target.ItemGrpImgCode3)
                 && (this.ItemGrpImgCode4 == target.ItemGrpImgCode4)
                 && (this.ItemGrpImgCode5 == target.ItemGrpImgCode5)
                 );
                // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �i�ڃO���b�h�}�X�^��r����
        /// </summary>
        /// <param name="pccItemGrid1">
        ///                    ��r����PccItemGrid�N���X�̃C���X�^���X
        /// </param>
        /// <param name="pccItemGrid2">��r����PccItemGrid�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrid�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PccItemGrid pccItemGrid1, PccItemGrid pccItemGrid2)
        {
            return ((pccItemGrid1.CreateDateTime == pccItemGrid2.CreateDateTime)
                 && (pccItemGrid1.UpdateDateTime == pccItemGrid2.UpdateDateTime)
                 && (pccItemGrid1.EnterpriseCode == pccItemGrid2.EnterpriseCode)
                 && (pccItemGrid1.FileHeaderGuid == pccItemGrid2.FileHeaderGuid)
                 && (pccItemGrid1.UpdEmployeeCode == pccItemGrid2.UpdEmployeeCode)
                 && (pccItemGrid1.UpdAssemblyId1 == pccItemGrid2.UpdAssemblyId1)
                 && (pccItemGrid1.UpdAssemblyId2 == pccItemGrid2.UpdAssemblyId2)
                 && (pccItemGrid1.LogicalDeleteCode == pccItemGrid2.LogicalDeleteCode)
                 && (pccItemGrid1.InqOriginalEpCd.Trim() == pccItemGrid2.InqOriginalEpCd.Trim())//@@@@20230303
                 && (pccItemGrid1.InqOriginalSecCd == pccItemGrid2.InqOriginalSecCd)
                 && (pccItemGrid1.InqOtherEpCd == pccItemGrid2.InqOtherEpCd)
                 && (pccItemGrid1.InqOtherSecCd == pccItemGrid2.InqOtherSecCd)
                 && (pccItemGrid1.InqCondition == pccItemGrid2.InqCondition)
                 && (pccItemGrid1.PccCompanyCode == pccItemGrid2.PccCompanyCode)
                 && (pccItemGrid1.PccCompanyName == pccItemGrid2.PccCompanyName)
                 && (pccItemGrid1.ItemGroupCode1 == pccItemGrid2.ItemGroupCode1)
                 && (pccItemGrid1.ItemGroupName1 == pccItemGrid2.ItemGroupName1)
                 && (pccItemGrid1.ItemGrpDspOdr1 == pccItemGrid2.ItemGrpDspOdr1)
                 && (pccItemGrid1.ItemGroupCode2 == pccItemGrid2.ItemGroupCode2)
                 && (pccItemGrid1.ItemGroupName2 == pccItemGrid2.ItemGroupName2)
                 && (pccItemGrid1.ItemGrpDspOdr2 == pccItemGrid2.ItemGrpDspOdr2)
                 && (pccItemGrid1.ItemGroupCode3 == pccItemGrid2.ItemGroupCode3)
                 && (pccItemGrid1.ItemGroupName3 == pccItemGrid2.ItemGroupName3)
                 && (pccItemGrid1.ItemGrpDspOdr3 == pccItemGrid2.ItemGrpDspOdr3)
                 && (pccItemGrid1.ItemGroupCode4 == pccItemGrid2.ItemGroupCode4)
                 && (pccItemGrid1.ItemGroupName4 == pccItemGrid2.ItemGroupName4)
                 && (pccItemGrid1.ItemGrpDspOdr4 == pccItemGrid2.ItemGrpDspOdr4)
                 && (pccItemGrid1.ItemGroupCode5 == pccItemGrid2.ItemGroupCode5)
                 && (pccItemGrid1.ItemGroupName5 == pccItemGrid2.ItemGroupName5)
                 && (pccItemGrid1.ItemGrpDspOdr5 == pccItemGrid2.ItemGrpDspOdr5)
                 && (pccItemGrid1.EnterpriseName == pccItemGrid2.EnterpriseName)
                // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
                 //&& (pccItemGrid1.UpdEmployeeName == pccItemGrid2.UpdEmployeeName));
                 && (pccItemGrid1.UpdEmployeeName == pccItemGrid2.UpdEmployeeName)
                 && (pccItemGrid1.ItemGrpImgCode1 == pccItemGrid2.ItemGrpImgCode1)
                 && (pccItemGrid1.ItemGrpImgCode2 == pccItemGrid2.ItemGrpImgCode2)
                 && (pccItemGrid1.ItemGrpImgCode3 == pccItemGrid2.ItemGrpImgCode3)
                 && (pccItemGrid1.ItemGrpImgCode4 == pccItemGrid2.ItemGrpImgCode4)
                 && (pccItemGrid1.ItemGrpImgCode5 == pccItemGrid2.ItemGrpImgCode5)
                 );
                // --- UPD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        /// <summary>
        /// �i�ڃO���b�h�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PccItemGrid�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrid�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PccItemGrid target)
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
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.InqCondition != target.InqCondition) resList.Add("InqCondition");
            if (this.PccCompanyCode != target.PccCompanyCode) resList.Add("PccCompanyCode");
            if (this.PccCompanyName != target.PccCompanyName) resList.Add("PccCompanyName");
            if (this.ItemGroupCode1 != target.ItemGroupCode1) resList.Add("ItemGroupCode1");
            if (this.ItemGroupName1 != target.ItemGroupName1) resList.Add("ItemGroupName1");
            if (this.ItemGrpDspOdr1 != target.ItemGrpDspOdr1) resList.Add("ItemGrpDspOdr1");
            if (this.ItemGroupCode2 != target.ItemGroupCode2) resList.Add("ItemGroupCode2");
            if (this.ItemGroupName2 != target.ItemGroupName2) resList.Add("ItemGroupName2");
            if (this.ItemGrpDspOdr2 != target.ItemGrpDspOdr2) resList.Add("ItemGrpDspOdr2");
            if (this.ItemGroupCode3 != target.ItemGroupCode3) resList.Add("ItemGroupCode3");
            if (this.ItemGroupName3 != target.ItemGroupName3) resList.Add("ItemGroupName3");
            if (this.ItemGrpDspOdr3 != target.ItemGrpDspOdr3) resList.Add("ItemGrpDspOdr3");
            if (this.ItemGroupCode4 != target.ItemGroupCode4) resList.Add("ItemGroupCode4");
            if (this.ItemGroupName4 != target.ItemGroupName4) resList.Add("ItemGroupName4");
            if (this.ItemGrpDspOdr4 != target.ItemGrpDspOdr4) resList.Add("ItemGrpDspOdr4");
            if (this.ItemGroupCode5 != target.ItemGroupCode5) resList.Add("ItemGroupCode5");
            if (this.ItemGroupName5 != target.ItemGroupName5) resList.Add("ItemGroupName5");
            if (this.ItemGrpDspOdr5 != target.ItemGrpDspOdr5) resList.Add("ItemGrpDspOdr5");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (this.ItemGrpImgCode1 != target.ItemGrpImgCode1) resList.Add("ItemGrpImgCode1");
            if (this.ItemGrpImgCode2 != target.ItemGrpImgCode2) resList.Add("ItemGrpImgCode2");
            if (this.ItemGrpImgCode3 != target.ItemGrpImgCode3) resList.Add("ItemGrpImgCode3");
            if (this.ItemGrpImgCode4 != target.ItemGrpImgCode4) resList.Add("ItemGrpImgCode4");
            if (this.ItemGrpImgCode5 != target.ItemGrpImgCode5) resList.Add("ItemGrpImgCode5");
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }

        /// <summary>
        /// �i�ڃO���b�h�}�X�^��r����
        /// </summary>
        /// <param name="pccItemGrid1">��r����PccItemGrid�N���X�̃C���X�^���X</param>
        /// <param name="pccItemGrid2">��r����PccItemGrid�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PccItemGrid�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PccItemGrid pccItemGrid1, PccItemGrid pccItemGrid2)
        {
            ArrayList resList = new ArrayList();
            if (pccItemGrid1.CreateDateTime != pccItemGrid2.CreateDateTime) resList.Add("CreateDateTime");
            if (pccItemGrid1.UpdateDateTime != pccItemGrid2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (pccItemGrid1.EnterpriseCode != pccItemGrid2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (pccItemGrid1.FileHeaderGuid != pccItemGrid2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (pccItemGrid1.UpdEmployeeCode != pccItemGrid2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (pccItemGrid1.UpdAssemblyId1 != pccItemGrid2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (pccItemGrid1.UpdAssemblyId2 != pccItemGrid2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (pccItemGrid1.LogicalDeleteCode != pccItemGrid2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (pccItemGrid1.InqOriginalEpCd.Trim() != pccItemGrid2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");//@@@@20230303
            if (pccItemGrid1.InqOriginalSecCd != pccItemGrid2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (pccItemGrid1.InqOtherEpCd != pccItemGrid2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (pccItemGrid1.InqOtherSecCd != pccItemGrid2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (pccItemGrid1.InqCondition != pccItemGrid2.InqCondition) resList.Add("InqCondition");
            if (pccItemGrid1.PccCompanyCode != pccItemGrid2.PccCompanyCode) resList.Add("PccCompanyCode");
            if (pccItemGrid1.PccCompanyName != pccItemGrid2.PccCompanyName) resList.Add("PccCompanyName");
            if (pccItemGrid1.ItemGroupCode1 != pccItemGrid2.ItemGroupCode1) resList.Add("ItemGroupCode1");
            if (pccItemGrid1.ItemGroupName1 != pccItemGrid2.ItemGroupName1) resList.Add("ItemGroupName1");
            if (pccItemGrid1.ItemGrpDspOdr1 != pccItemGrid2.ItemGrpDspOdr1) resList.Add("ItemGrpDspOdr1");
            if (pccItemGrid1.ItemGroupCode2 != pccItemGrid2.ItemGroupCode2) resList.Add("ItemGroupCode2");
            if (pccItemGrid1.ItemGroupName2 != pccItemGrid2.ItemGroupName2) resList.Add("ItemGroupName2");
            if (pccItemGrid1.ItemGrpDspOdr2 != pccItemGrid2.ItemGrpDspOdr2) resList.Add("ItemGrpDspOdr2");
            if (pccItemGrid1.ItemGroupCode3 != pccItemGrid2.ItemGroupCode3) resList.Add("ItemGroupCode3");
            if (pccItemGrid1.ItemGroupName3 != pccItemGrid2.ItemGroupName3) resList.Add("ItemGroupName3");
            if (pccItemGrid1.ItemGrpDspOdr3 != pccItemGrid2.ItemGrpDspOdr3) resList.Add("ItemGrpDspOdr3");
            if (pccItemGrid1.ItemGroupCode4 != pccItemGrid2.ItemGroupCode4) resList.Add("ItemGroupCode4");
            if (pccItemGrid1.ItemGroupName4 != pccItemGrid2.ItemGroupName4) resList.Add("ItemGroupName4");
            if (pccItemGrid1.ItemGrpDspOdr4 != pccItemGrid2.ItemGrpDspOdr4) resList.Add("ItemGrpDspOdr4");
            if (pccItemGrid1.ItemGroupCode5 != pccItemGrid2.ItemGroupCode5) resList.Add("ItemGroupCode5");
            if (pccItemGrid1.ItemGroupName5 != pccItemGrid2.ItemGroupName5) resList.Add("ItemGroupName5");
            if (pccItemGrid1.ItemGrpDspOdr5 != pccItemGrid2.ItemGrpDspOdr5) resList.Add("ItemGrpDspOdr5");
            if (pccItemGrid1.EnterpriseName != pccItemGrid2.EnterpriseName) resList.Add("EnterpriseName");
            if (pccItemGrid1.UpdEmployeeName != pccItemGrid2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 --------->>>>>>>>>>>>>>>>>>>>>>>>
            if (pccItemGrid1.ItemGrpImgCode1 != pccItemGrid2.ItemGrpImgCode1) resList.Add("ItemGrpImgCode1");
            if (pccItemGrid1.ItemGrpImgCode2 != pccItemGrid2.ItemGrpImgCode2) resList.Add("ItemGrpImgCode2");
            if (pccItemGrid1.ItemGrpImgCode3 != pccItemGrid2.ItemGrpImgCode3) resList.Add("ItemGrpImgCode3");
            if (pccItemGrid1.ItemGrpImgCode4 != pccItemGrid2.ItemGrpImgCode4) resList.Add("ItemGrpImgCode4");
            if (pccItemGrid1.ItemGrpImgCode5 != pccItemGrid2.ItemGrpImgCode5) resList.Add("ItemGrpImgCode5");
            // --- ADD 2013/05/30 �O�� 2013/99/99�z�M�� SCM��Q��10541 ---------<<<<<<<<<<<<<<<<<<<<<<<<

            return resList;
        }
    }
}
