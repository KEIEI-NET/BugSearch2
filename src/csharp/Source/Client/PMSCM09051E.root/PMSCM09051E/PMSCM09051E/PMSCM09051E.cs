//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : SCM���ꉿ�i�ݒ�}�X�^
// �v���O�����T�v   : SCM���ꉿ�i�ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/04/12  �C�����e : ���ꉿ�i�i���R�[�h�Q�A���ꉿ�i�i���R�[�h�R�̒ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SCMMrktPriSt
    /// <summary>
    ///                      SCM���ꉿ�i�ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM���ꉿ�i�ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/5/11  ����</br>
    /// </remarks>
    public class SCMMrktPriSt
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

        /// <summary>���ꉿ�i�n��R�[�h</summary>
        /// <remarks>RC�̃}�X�^</remarks>
        private Int32 _marketPriceAreaCd;

        /// <summary>���ꉿ�i�i���R�[�h</summary>
        /// <remarks>0:�ɏ� 1:�� �cRC�̃}�X�^</remarks>
        private Int32 _marketPriceQualityCd;

        /// <summary>���ꉿ�i��ʃR�[�h�P</summary>
        /// <remarks>0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^</remarks>
        private Int32 _marketPriceKindCd1;

        /// <summary>���ꉿ�i��ʃR�[�h�Q</summary>
        /// <remarks>-1:�Ȃ� 0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^</remarks>
        private Int32 _marketPriceKindCd2;

        /// <summary>���ꉿ�i��ʃR�[�h�R</summary>
        /// <remarks>-1:�Ȃ� 0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^</remarks>
        private Int32 _marketPriceKindCd3;

        /// <summary>���ꉿ�i�񓚋敪</summary>
        /// <remarks>0:���Ȃ� 1:����(������) 1:����(���Z�e�[�u��)</remarks>
        private Int32 _marketPriceAnswerDiv;

        /// <summary>���ꉿ�i������</summary>
        /// <remarks>�|��</remarks>
        private Double _marketPriceSalesRate;

        /// <summary>���Z�z�͈�1</summary>
        /// <remarks>�P�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit1;

        /// <summary>���Z�z�͈�2</summary>
        /// <remarks>���Z�e�[�u���P�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit2;

        /// <summary>���Z�z�͈�3</summary>
        /// <remarks>���Z�e�[�u���Q�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit3;

        /// <summary>���Z�z�͈�4</summary>
        /// <remarks>���Z�e�[�u���R�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit4;

        /// <summary>���Z�z�͈�5</summary>
        /// <remarks>���Z�e�[�u���S�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit5;

        /// <summary>���Z�z�͈�6</summary>
        /// <remarks>���Z�e�[�u���T�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit6;

        /// <summary>���Z�z�͈�7</summary>
        /// <remarks>���Z�e�[�u���U�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit7;

        /// <summary>���Z�z�͈�8</summary>
        /// <remarks>���Z�e�[�u���V�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit8;

        /// <summary>���Z�z�͈�9</summary>
        /// <remarks>���Z�e�[�u���W�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit9;

        /// <summary>���Z�z�͈�10</summary>
        /// <remarks>���Z�e�[�u���X�ȏ�`�����~����</remarks>
        private Int32 _addPaymntAmbit10;

        /// <summary>���Z�z1</summary>
        /// <remarks>���Z�e�[�u���P�̉��Z�z</remarks>
        private Int32 _addPaymnt1;

        /// <summary>���Z�z2</summary>
        /// <remarks>���Z�e�[�u���Q�̉��Z�z</remarks>
        private Int32 _addPaymnt2;

        /// <summary>���Z�z3</summary>
        /// <remarks>���Z�e�[�u���R�̉��Z�z</remarks>
        private Int32 _addPaymnt3;

        /// <summary>���Z�z4</summary>
        /// <remarks>���Z�e�[�u���S�̉��Z�z</remarks>
        private Int32 _addPaymnt4;

        /// <summary>���Z�z5</summary>
        /// <remarks>���Z�e�[�u���T�̉��Z�z</remarks>
        private Int32 _addPaymnt5;

        /// <summary>���Z�z6</summary>
        /// <remarks>���Z�e�[�u���U�̉��Z�z</remarks>
        private Int32 _addPaymnt6;

        /// <summary>���Z�z7</summary>
        /// <remarks>���Z�e�[�u���V�̉��Z�z</remarks>
        private Int32 _addPaymnt7;

        /// <summary>���Z�z8</summary>
        /// <remarks>���Z�e�[�u���W�̉��Z�z</remarks>
        private Int32 _addPaymnt8;

        /// <summary>���Z�z9</summary>
        /// <remarks>���Z�e�[�u���X�̉��Z�z</remarks>
        private Int32 _addPaymnt9;

        /// <summary>���Z�z10</summary>
        /// <remarks>���Z�e�[�u���P�O�̉��Z�z</remarks>
        private Int32 _addPaymnt10;

        /// <summary>�[�������敪</summary>
        /// <remarks>0:�P�O�~�P��(�l�̌ܓ�) 1:�P�O�O�~�P��(�l�̌ܓ�)</remarks>
        private Int32 _fractionProcCd;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        // 2010/04/12 Add >>>
        /// <summary>���ꉿ�i�i���R�[�h�Q</summary>
        /// <remarks>0:�ɏ� 1:�� �cRC�̃}�X�^</remarks>
        private Int32 _marketPriceQualityCd2;

        /// <summary>���ꉿ�i�i���R�[�h�R</summary>
        /// <remarks>0:�ɏ� 1:�� �cRC�̃}�X�^</remarks>
        private Int32 _marketPriceQualityCd3;
        // 2010/04/12 Add <<<

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

        /// public propaty name  :  MarketPriceAreaCd
        /// <summary>���ꉿ�i�n��R�[�h�v���p�e�B</summary>
        /// <value>RC�̃}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�n��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceAreaCd
        {
            get { return _marketPriceAreaCd; }
            set { _marketPriceAreaCd = value; }
        }

        /// public propaty name  :  MarketPriceQualityCd
        /// <summary>���ꉿ�i�i���R�[�h�v���p�e�B</summary>
        /// <value>0:�ɏ� 1:�� �cRC�̃}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�i���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd
        {
            get { return _marketPriceQualityCd; }
            set { _marketPriceQualityCd = value; }
        }

        /// public propaty name  :  MarketPriceKindCd1
        /// <summary>���ꉿ�i��ʃR�[�h�P�v���p�e�B</summary>
        /// <value>0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i��ʃR�[�h�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceKindCd1
        {
            get { return _marketPriceKindCd1; }
            set { _marketPriceKindCd1 = value; }
        }

        /// public propaty name  :  MarketPriceKindCd2
        /// <summary>���ꉿ�i��ʃR�[�h�Q�v���p�e�B</summary>
        /// <value>-1:�Ȃ� 0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i��ʃR�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceKindCd2
        {
            get { return _marketPriceKindCd2; }
            set { _marketPriceKindCd2 = value; }
        }

        /// public propaty name  :  MarketPriceKindCd3
        /// <summary>���ꉿ�i��ʃR�[�h�R�v���p�e�B</summary>
        /// <value>-1:�Ȃ� 0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i��ʃR�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceKindCd3
        {
            get { return _marketPriceKindCd3; }
            set { _marketPriceKindCd3 = value; }
        }

        /// public propaty name  :  MarketPriceAnswerDiv
        /// <summary>���ꉿ�i�񓚋敪�v���p�e�B</summary>
        /// <value>0:���Ȃ� 1:����(������) 1:����(���Z�e�[�u��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�񓚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceAnswerDiv
        {
            get { return _marketPriceAnswerDiv; }
            set { _marketPriceAnswerDiv = value; }
        }

        /// public propaty name  :  MarketPriceSalesRate
        /// <summary>���ꉿ�i�������v���p�e�B</summary>
        /// <value>�|��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MarketPriceSalesRate
        {
            get { return _marketPriceSalesRate; }
            set { _marketPriceSalesRate = value; }
        }

        /// public propaty name  :  AddPaymntAmbit1
        /// <summary>���Z�z�͈�1�v���p�e�B</summary>
        /// <value>�P�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit1
        {
            get { return _addPaymntAmbit1; }
            set { _addPaymntAmbit1 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit2
        /// <summary>���Z�z�͈�2�v���p�e�B</summary>
        /// <value>���Z�e�[�u���P�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit2
        {
            get { return _addPaymntAmbit2; }
            set { _addPaymntAmbit2 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit3
        /// <summary>���Z�z�͈�3�v���p�e�B</summary>
        /// <value>���Z�e�[�u���Q�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit3
        {
            get { return _addPaymntAmbit3; }
            set { _addPaymntAmbit3 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit4
        /// <summary>���Z�z�͈�4�v���p�e�B</summary>
        /// <value>���Z�e�[�u���R�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit4
        {
            get { return _addPaymntAmbit4; }
            set { _addPaymntAmbit4 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit5
        /// <summary>���Z�z�͈�5�v���p�e�B</summary>
        /// <value>���Z�e�[�u���S�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit5
        {
            get { return _addPaymntAmbit5; }
            set { _addPaymntAmbit5 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit6
        /// <summary>���Z�z�͈�6�v���p�e�B</summary>
        /// <value>���Z�e�[�u���T�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit6
        {
            get { return _addPaymntAmbit6; }
            set { _addPaymntAmbit6 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit7
        /// <summary>���Z�z�͈�7�v���p�e�B</summary>
        /// <value>���Z�e�[�u���U�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit7
        {
            get { return _addPaymntAmbit7; }
            set { _addPaymntAmbit7 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit8
        /// <summary>���Z�z�͈�8�v���p�e�B</summary>
        /// <value>���Z�e�[�u���V�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit8
        {
            get { return _addPaymntAmbit8; }
            set { _addPaymntAmbit8 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit9
        /// <summary>���Z�z�͈�9�v���p�e�B</summary>
        /// <value>���Z�e�[�u���W�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit9
        {
            get { return _addPaymntAmbit9; }
            set { _addPaymntAmbit9 = value; }
        }

        /// public propaty name  :  AddPaymntAmbit10
        /// <summary>���Z�z�͈�10�v���p�e�B</summary>
        /// <value>���Z�e�[�u���X�ȏ�`�����~����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z�͈�10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymntAmbit10
        {
            get { return _addPaymntAmbit10; }
            set { _addPaymntAmbit10 = value; }
        }

        /// public propaty name  :  AddPaymnt1
        /// <summary>���Z�z1�v���p�e�B</summary>
        /// <value>���Z�e�[�u���P�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt1
        {
            get { return _addPaymnt1; }
            set { _addPaymnt1 = value; }
        }

        /// public propaty name  :  AddPaymnt2
        /// <summary>���Z�z2�v���p�e�B</summary>
        /// <value>���Z�e�[�u���Q�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt2
        {
            get { return _addPaymnt2; }
            set { _addPaymnt2 = value; }
        }

        /// public propaty name  :  AddPaymnt3
        /// <summary>���Z�z3�v���p�e�B</summary>
        /// <value>���Z�e�[�u���R�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt3
        {
            get { return _addPaymnt3; }
            set { _addPaymnt3 = value; }
        }

        /// public propaty name  :  AddPaymnt4
        /// <summary>���Z�z4�v���p�e�B</summary>
        /// <value>���Z�e�[�u���S�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt4
        {
            get { return _addPaymnt4; }
            set { _addPaymnt4 = value; }
        }

        /// public propaty name  :  AddPaymnt5
        /// <summary>���Z�z5�v���p�e�B</summary>
        /// <value>���Z�e�[�u���T�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt5
        {
            get { return _addPaymnt5; }
            set { _addPaymnt5 = value; }
        }

        /// public propaty name  :  AddPaymnt6
        /// <summary>���Z�z6�v���p�e�B</summary>
        /// <value>���Z�e�[�u���U�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt6
        {
            get { return _addPaymnt6; }
            set { _addPaymnt6 = value; }
        }

        /// public propaty name  :  AddPaymnt7
        /// <summary>���Z�z7�v���p�e�B</summary>
        /// <value>���Z�e�[�u���V�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt7
        {
            get { return _addPaymnt7; }
            set { _addPaymnt7 = value; }
        }

        /// public propaty name  :  AddPaymnt8
        /// <summary>���Z�z8�v���p�e�B</summary>
        /// <value>���Z�e�[�u���W�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt8
        {
            get { return _addPaymnt8; }
            set { _addPaymnt8 = value; }
        }

        /// public propaty name  :  AddPaymnt9
        /// <summary>���Z�z9�v���p�e�B</summary>
        /// <value>���Z�e�[�u���X�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt9
        {
            get { return _addPaymnt9; }
            set { _addPaymnt9 = value; }
        }

        /// public propaty name  :  AddPaymnt10
        /// <summary>���Z�z10�v���p�e�B</summary>
        /// <value>���Z�e�[�u���P�O�̉��Z�z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Z�z10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddPaymnt10
        {
            get { return _addPaymnt10; }
            set { _addPaymnt10 = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>�[�������敪�v���p�e�B</summary>
        /// <value>0:�P�O�~�P��(�l�̌ܓ�) 1:�P�O�O�~�P��(�l�̌ܓ�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
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

        // 2010/04/12 Add >>>
        /// public propaty name  :  MarketPriceQualityCd2
        /// <summary>���ꉿ�i�i���R�[�h�Q�v���p�e�B</summary>
        /// <value>0:�ɏ� 1:�� �cRC�̃}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�i���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd2
        {
            get { return _marketPriceQualityCd2; }
            set { _marketPriceQualityCd2 = value; }
        }

        /// public propaty name  :  MarketPriceQualityCd3
        /// <summary>���ꉿ�i�i���R�[�h�R�v���p�e�B</summary>
        /// <value>0:�ɏ� 1:�� �cRC�̃}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�i���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd3
        {
            get { return _marketPriceQualityCd3; }
            set { _marketPriceQualityCd3 = value; }
        }
        // 2010/04/12 Add <<<

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>SCMMrktPriSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMMrktPriSt()
        {
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^�R���X�g���N�^
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
        /// <param name="marketPriceAreaCd">���ꉿ�i�n��R�[�h(RC�̃}�X�^)</param>
        /// <param name="marketPriceQualityCd">���ꉿ�i�i���R�[�h(0:�ɏ� 1:�� �cRC�̃}�X�^)</param>
        /// <param name="marketPriceKindCd1">���ꉿ�i��ʃR�[�h�P(0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^)</param>
        /// <param name="marketPriceKindCd2">���ꉿ�i��ʃR�[�h�Q(-1:�Ȃ� 0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^)</param>
        /// <param name="marketPriceKindCd3">���ꉿ�i��ʃR�[�h�R(-1:�Ȃ� 0:�V�i 1:���r���g 2:���� �cRC�̃}�X�^)</param>
        /// <param name="marketPriceAnswerDiv">���ꉿ�i�񓚋敪(0:���Ȃ� 1:����(������) 1:����(���Z�e�[�u��))</param>
        /// <param name="marketPriceSalesRate">���ꉿ�i������(�|��)</param>
        /// <param name="addPaymntAmbit1">���Z�z�͈�1(�P�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit2">���Z�z�͈�2(���Z�e�[�u���P�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit3">���Z�z�͈�3(���Z�e�[�u���Q�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit4">���Z�z�͈�4(���Z�e�[�u���R�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit5">���Z�z�͈�5(���Z�e�[�u���S�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit6">���Z�z�͈�6(���Z�e�[�u���T�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit7">���Z�z�͈�7(���Z�e�[�u���U�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit8">���Z�z�͈�8(���Z�e�[�u���V�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit9">���Z�z�͈�9(���Z�e�[�u���W�ȏ�`�����~����)</param>
        /// <param name="addPaymntAmbit10">���Z�z�͈�10(���Z�e�[�u���X�ȏ�`�����~����)</param>
        /// <param name="addPaymnt1">���Z�z1(���Z�e�[�u���P�̉��Z�z)</param>
        /// <param name="addPaymnt2">���Z�z2(���Z�e�[�u���Q�̉��Z�z)</param>
        /// <param name="addPaymnt3">���Z�z3(���Z�e�[�u���R�̉��Z�z)</param>
        /// <param name="addPaymnt4">���Z�z4(���Z�e�[�u���S�̉��Z�z)</param>
        /// <param name="addPaymnt5">���Z�z5(���Z�e�[�u���T�̉��Z�z)</param>
        /// <param name="addPaymnt6">���Z�z6(���Z�e�[�u���U�̉��Z�z)</param>
        /// <param name="addPaymnt7">���Z�z7(���Z�e�[�u���V�̉��Z�z)</param>
        /// <param name="addPaymnt8">���Z�z8(���Z�e�[�u���W�̉��Z�z)</param>
        /// <param name="addPaymnt9">���Z�z9(���Z�e�[�u���X�̉��Z�z)</param>
        /// <param name="addPaymnt10">���Z�z10(���Z�e�[�u���P�O�̉��Z�z)</param>
        /// <param name="fractionProcCd">�[�������敪(0:�P�O�~�P��(�l�̌ܓ�) 1:�P�O�O�~�P��(�l�̌ܓ�))</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="marketPriceQualityCd2">���ꉿ�i�i���R�[�h�Q(0:�ɏ� 1:�� �cRC�̃}�X�^)</param>
        /// <param name="marketPriceQualityCd3">���ꉿ�i�i���R�[�h�R(0:�ɏ� 1:�� �cRC�̃}�X�^)</param>
        /// <returns>SCMMrktPriSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriSt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        // 2010/04/12 >>>
        //public SCMMrktPriSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 marketPriceAreaCd, Int32 marketPriceQualityCd, Int32 marketPriceKindCd1, Int32 marketPriceKindCd2, Int32 marketPriceKindCd3, Int32 marketPriceAnswerDiv, Double marketPriceSalesRate, Int32 addPaymntAmbit1, Int32 addPaymntAmbit2, Int32 addPaymntAmbit3, Int32 addPaymntAmbit4, Int32 addPaymntAmbit5, Int32 addPaymntAmbit6, Int32 addPaymntAmbit7, Int32 addPaymntAmbit8, Int32 addPaymntAmbit9, Int32 addPaymntAmbit10, Int32 addPaymnt1, Int32 addPaymnt2, Int32 addPaymnt3, Int32 addPaymnt4, Int32 addPaymnt5, Int32 addPaymnt6, Int32 addPaymnt7, Int32 addPaymnt8, Int32 addPaymnt9, Int32 addPaymnt10, Int32 fractionProcCd, string enterpriseName, string updEmployeeName)
        public SCMMrktPriSt(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 marketPriceAreaCd, Int32 marketPriceQualityCd, Int32 marketPriceKindCd1, Int32 marketPriceKindCd2, Int32 marketPriceKindCd3, Int32 marketPriceAnswerDiv, Double marketPriceSalesRate, Int32 addPaymntAmbit1, Int32 addPaymntAmbit2, Int32 addPaymntAmbit3, Int32 addPaymntAmbit4, Int32 addPaymntAmbit5, Int32 addPaymntAmbit6, Int32 addPaymntAmbit7, Int32 addPaymntAmbit8, Int32 addPaymntAmbit9, Int32 addPaymntAmbit10, Int32 addPaymnt1, Int32 addPaymnt2, Int32 addPaymnt3, Int32 addPaymnt4, Int32 addPaymnt5, Int32 addPaymnt6, Int32 addPaymnt7, Int32 addPaymnt8, Int32 addPaymnt9, Int32 addPaymnt10, Int32 fractionProcCd, string enterpriseName, string updEmployeeName
            , Int32 marketPriceQualityCd2
            , Int32 marketPriceQualityCd3
            )
        // 2010/04/12 <<<
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
            this._marketPriceAreaCd = marketPriceAreaCd;
            this._marketPriceQualityCd = marketPriceQualityCd;
            this._marketPriceKindCd1 = marketPriceKindCd1;
            this._marketPriceKindCd2 = marketPriceKindCd2;
            this._marketPriceKindCd3 = marketPriceKindCd3;
            this._marketPriceAnswerDiv = marketPriceAnswerDiv;
            this._marketPriceSalesRate = marketPriceSalesRate;
            this._addPaymntAmbit1 = addPaymntAmbit1;
            this._addPaymntAmbit2 = addPaymntAmbit2;
            this._addPaymntAmbit3 = addPaymntAmbit3;
            this._addPaymntAmbit4 = addPaymntAmbit4;
            this._addPaymntAmbit5 = addPaymntAmbit5;
            this._addPaymntAmbit6 = addPaymntAmbit6;
            this._addPaymntAmbit7 = addPaymntAmbit7;
            this._addPaymntAmbit8 = addPaymntAmbit8;
            this._addPaymntAmbit9 = addPaymntAmbit9;
            this._addPaymntAmbit10 = addPaymntAmbit10;
            this._addPaymnt1 = addPaymnt1;
            this._addPaymnt2 = addPaymnt2;
            this._addPaymnt3 = addPaymnt3;
            this._addPaymnt4 = addPaymnt4;
            this._addPaymnt5 = addPaymnt5;
            this._addPaymnt6 = addPaymnt6;
            this._addPaymnt7 = addPaymnt7;
            this._addPaymnt8 = addPaymnt8;
            this._addPaymnt9 = addPaymnt9;
            this._addPaymnt10 = addPaymnt10;
            this._fractionProcCd = fractionProcCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // 2010/04/12 Add >>>
            this._marketPriceQualityCd2 = marketPriceQualityCd2;
            this._marketPriceQualityCd3 = marketPriceQualityCd3;
            // 2010/04/12 Add <<<
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^��������
        /// </summary>
        /// <returns>SCMMrktPriSt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SCMMrktPriSt�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMMrktPriSt Clone()
        {
            // 2010/04/12 >>>
            //return new SCMMrktPriSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._marketPriceAreaCd, this._marketPriceQualityCd, this._marketPriceKindCd1, this._marketPriceKindCd2, this._marketPriceKindCd3, this._marketPriceAnswerDiv, this._marketPriceSalesRate, this._addPaymntAmbit1, this._addPaymntAmbit2, this._addPaymntAmbit3, this._addPaymntAmbit4, this._addPaymntAmbit5, this._addPaymntAmbit6, this._addPaymntAmbit7, this._addPaymntAmbit8, this._addPaymntAmbit9, this._addPaymntAmbit10, this._addPaymnt1, this._addPaymnt2, this._addPaymnt3, this._addPaymnt4, this._addPaymnt5, this._addPaymnt6, this._addPaymnt7, this._addPaymnt8, this._addPaymnt9, this._addPaymnt10, this._fractionProcCd, this._enterpriseName, this._updEmployeeName);
            return new SCMMrktPriSt(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._marketPriceAreaCd, this._marketPriceQualityCd, this._marketPriceKindCd1, this._marketPriceKindCd2, this._marketPriceKindCd3, this._marketPriceAnswerDiv, this._marketPriceSalesRate, this._addPaymntAmbit1, this._addPaymntAmbit2, this._addPaymntAmbit3, this._addPaymntAmbit4, this._addPaymntAmbit5, this._addPaymntAmbit6, this._addPaymntAmbit7, this._addPaymntAmbit8, this._addPaymntAmbit9, this._addPaymntAmbit10, this._addPaymnt1, this._addPaymnt2, this._addPaymnt3, this._addPaymnt4, this._addPaymnt5, this._addPaymnt6, this._addPaymnt7, this._addPaymnt8, this._addPaymnt9, this._addPaymnt10, this._fractionProcCd, this._enterpriseName, this._updEmployeeName
                ,this._marketPriceQualityCd2
                , this._marketPriceQualityCd3
                );
            // 2010/04/12 <<<
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SCMMrktPriSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SCMMrktPriSt target)
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
                 && (this.MarketPriceAreaCd == target.MarketPriceAreaCd)
                 && (this.MarketPriceQualityCd == target.MarketPriceQualityCd)
                 && (this.MarketPriceKindCd1 == target.MarketPriceKindCd1)
                 && (this.MarketPriceKindCd2 == target.MarketPriceKindCd2)
                 && (this.MarketPriceKindCd3 == target.MarketPriceKindCd3)
                 && (this.MarketPriceAnswerDiv == target.MarketPriceAnswerDiv)
                 && (this.MarketPriceSalesRate == target.MarketPriceSalesRate)
                 && (this.AddPaymntAmbit1 == target.AddPaymntAmbit1)
                 && (this.AddPaymntAmbit2 == target.AddPaymntAmbit2)
                 && (this.AddPaymntAmbit3 == target.AddPaymntAmbit3)
                 && (this.AddPaymntAmbit4 == target.AddPaymntAmbit4)
                 && (this.AddPaymntAmbit5 == target.AddPaymntAmbit5)
                 && (this.AddPaymntAmbit6 == target.AddPaymntAmbit6)
                 && (this.AddPaymntAmbit7 == target.AddPaymntAmbit7)
                 && (this.AddPaymntAmbit8 == target.AddPaymntAmbit8)
                 && (this.AddPaymntAmbit9 == target.AddPaymntAmbit9)
                 && (this.AddPaymntAmbit10 == target.AddPaymntAmbit10)
                 && (this.AddPaymnt1 == target.AddPaymnt1)
                 && (this.AddPaymnt2 == target.AddPaymnt2)
                 && (this.AddPaymnt3 == target.AddPaymnt3)
                 && (this.AddPaymnt4 == target.AddPaymnt4)
                 && (this.AddPaymnt5 == target.AddPaymnt5)
                 && (this.AddPaymnt6 == target.AddPaymnt6)
                 && (this.AddPaymnt7 == target.AddPaymnt7)
                 && (this.AddPaymnt8 == target.AddPaymnt8)
                 && (this.AddPaymnt9 == target.AddPaymnt9)
                 && (this.AddPaymnt10 == target.AddPaymnt10)
                 && (this.FractionProcCd == target.FractionProcCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 // 2010/04/12 Add >>>
                 && ( this.MarketPriceQualityCd2 == target.MarketPriceQualityCd2 )
                 && ( this.MarketPriceQualityCd3 == target.MarketPriceQualityCd3 )
                 // 2010/04/12 Add <<<
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="sCMMrktPriSt1">
        ///                    ��r����SCMMrktPriSt�N���X�̃C���X�^���X
        /// </param>
        /// <param name="sCMMrktPriSt2">��r����SCMMrktPriSt�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriSt�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SCMMrktPriSt sCMMrktPriSt1, SCMMrktPriSt sCMMrktPriSt2)
        {
            return ((sCMMrktPriSt1.CreateDateTime == sCMMrktPriSt2.CreateDateTime)
                 && (sCMMrktPriSt1.UpdateDateTime == sCMMrktPriSt2.UpdateDateTime)
                 && (sCMMrktPriSt1.EnterpriseCode == sCMMrktPriSt2.EnterpriseCode)
                 && (sCMMrktPriSt1.FileHeaderGuid == sCMMrktPriSt2.FileHeaderGuid)
                 && (sCMMrktPriSt1.UpdEmployeeCode == sCMMrktPriSt2.UpdEmployeeCode)
                 && (sCMMrktPriSt1.UpdAssemblyId1 == sCMMrktPriSt2.UpdAssemblyId1)
                 && (sCMMrktPriSt1.UpdAssemblyId2 == sCMMrktPriSt2.UpdAssemblyId2)
                 && (sCMMrktPriSt1.LogicalDeleteCode == sCMMrktPriSt2.LogicalDeleteCode)
                 && (sCMMrktPriSt1.SectionCode == sCMMrktPriSt2.SectionCode)
                 && (sCMMrktPriSt1.MarketPriceAreaCd == sCMMrktPriSt2.MarketPriceAreaCd)
                 && (sCMMrktPriSt1.MarketPriceQualityCd == sCMMrktPriSt2.MarketPriceQualityCd)
                 && (sCMMrktPriSt1.MarketPriceKindCd1 == sCMMrktPriSt2.MarketPriceKindCd1)
                 && (sCMMrktPriSt1.MarketPriceKindCd2 == sCMMrktPriSt2.MarketPriceKindCd2)
                 && (sCMMrktPriSt1.MarketPriceKindCd3 == sCMMrktPriSt2.MarketPriceKindCd3)
                 && (sCMMrktPriSt1.MarketPriceAnswerDiv == sCMMrktPriSt2.MarketPriceAnswerDiv)
                 && (sCMMrktPriSt1.MarketPriceSalesRate == sCMMrktPriSt2.MarketPriceSalesRate)
                 && (sCMMrktPriSt1.AddPaymntAmbit1 == sCMMrktPriSt2.AddPaymntAmbit1)
                 && (sCMMrktPriSt1.AddPaymntAmbit2 == sCMMrktPriSt2.AddPaymntAmbit2)
                 && (sCMMrktPriSt1.AddPaymntAmbit3 == sCMMrktPriSt2.AddPaymntAmbit3)
                 && (sCMMrktPriSt1.AddPaymntAmbit4 == sCMMrktPriSt2.AddPaymntAmbit4)
                 && (sCMMrktPriSt1.AddPaymntAmbit5 == sCMMrktPriSt2.AddPaymntAmbit5)
                 && (sCMMrktPriSt1.AddPaymntAmbit6 == sCMMrktPriSt2.AddPaymntAmbit6)
                 && (sCMMrktPriSt1.AddPaymntAmbit7 == sCMMrktPriSt2.AddPaymntAmbit7)
                 && (sCMMrktPriSt1.AddPaymntAmbit8 == sCMMrktPriSt2.AddPaymntAmbit8)
                 && (sCMMrktPriSt1.AddPaymntAmbit9 == sCMMrktPriSt2.AddPaymntAmbit9)
                 && (sCMMrktPriSt1.AddPaymntAmbit10 == sCMMrktPriSt2.AddPaymntAmbit10)
                 && (sCMMrktPriSt1.AddPaymnt1 == sCMMrktPriSt2.AddPaymnt1)
                 && (sCMMrktPriSt1.AddPaymnt2 == sCMMrktPriSt2.AddPaymnt2)
                 && (sCMMrktPriSt1.AddPaymnt3 == sCMMrktPriSt2.AddPaymnt3)
                 && (sCMMrktPriSt1.AddPaymnt4 == sCMMrktPriSt2.AddPaymnt4)
                 && (sCMMrktPriSt1.AddPaymnt5 == sCMMrktPriSt2.AddPaymnt5)
                 && (sCMMrktPriSt1.AddPaymnt6 == sCMMrktPriSt2.AddPaymnt6)
                 && (sCMMrktPriSt1.AddPaymnt7 == sCMMrktPriSt2.AddPaymnt7)
                 && (sCMMrktPriSt1.AddPaymnt8 == sCMMrktPriSt2.AddPaymnt8)
                 && (sCMMrktPriSt1.AddPaymnt9 == sCMMrktPriSt2.AddPaymnt9)
                 && (sCMMrktPriSt1.AddPaymnt10 == sCMMrktPriSt2.AddPaymnt10)
                 && (sCMMrktPriSt1.FractionProcCd == sCMMrktPriSt2.FractionProcCd)
                 && (sCMMrktPriSt1.EnterpriseName == sCMMrktPriSt2.EnterpriseName)
                // 2010/04/12 Add >>>
                && ( sCMMrktPriSt1.MarketPriceQualityCd2 == sCMMrktPriSt2.MarketPriceQualityCd2 )
                && ( sCMMrktPriSt1.MarketPriceQualityCd3 == sCMMrktPriSt2.MarketPriceQualityCd3 )
                // 2010/04/12 Add <<<
                 && (sCMMrktPriSt1.UpdEmployeeName == sCMMrktPriSt2.UpdEmployeeName));
        }
        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SCMMrktPriSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriSt�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SCMMrktPriSt target)
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
            if (this.MarketPriceAreaCd != target.MarketPriceAreaCd) resList.Add("MarketPriceAreaCd");
            if (this.MarketPriceQualityCd != target.MarketPriceQualityCd) resList.Add("MarketPriceQualityCd");
            if (this.MarketPriceKindCd1 != target.MarketPriceKindCd1) resList.Add("MarketPriceKindCd1");
            if (this.MarketPriceKindCd2 != target.MarketPriceKindCd2) resList.Add("MarketPriceKindCd2");
            if (this.MarketPriceKindCd3 != target.MarketPriceKindCd3) resList.Add("MarketPriceKindCd3");
            if (this.MarketPriceAnswerDiv != target.MarketPriceAnswerDiv) resList.Add("MarketPriceAnswerDiv");
            if (this.MarketPriceSalesRate != target.MarketPriceSalesRate) resList.Add("MarketPriceSalesRate");
            if (this.AddPaymntAmbit1 != target.AddPaymntAmbit1) resList.Add("AddPaymntAmbit1");
            if (this.AddPaymntAmbit2 != target.AddPaymntAmbit2) resList.Add("AddPaymntAmbit2");
            if (this.AddPaymntAmbit3 != target.AddPaymntAmbit3) resList.Add("AddPaymntAmbit3");
            if (this.AddPaymntAmbit4 != target.AddPaymntAmbit4) resList.Add("AddPaymntAmbit4");
            if (this.AddPaymntAmbit5 != target.AddPaymntAmbit5) resList.Add("AddPaymntAmbit5");
            if (this.AddPaymntAmbit6 != target.AddPaymntAmbit6) resList.Add("AddPaymntAmbit6");
            if (this.AddPaymntAmbit7 != target.AddPaymntAmbit7) resList.Add("AddPaymntAmbit7");
            if (this.AddPaymntAmbit8 != target.AddPaymntAmbit8) resList.Add("AddPaymntAmbit8");
            if (this.AddPaymntAmbit9 != target.AddPaymntAmbit9) resList.Add("AddPaymntAmbit9");
            if (this.AddPaymntAmbit10 != target.AddPaymntAmbit10) resList.Add("AddPaymntAmbit10");
            if (this.AddPaymnt1 != target.AddPaymnt1) resList.Add("AddPaymnt1");
            if (this.AddPaymnt2 != target.AddPaymnt2) resList.Add("AddPaymnt2");
            if (this.AddPaymnt3 != target.AddPaymnt3) resList.Add("AddPaymnt3");
            if (this.AddPaymnt4 != target.AddPaymnt4) resList.Add("AddPaymnt4");
            if (this.AddPaymnt5 != target.AddPaymnt5) resList.Add("AddPaymnt5");
            if (this.AddPaymnt6 != target.AddPaymnt6) resList.Add("AddPaymnt6");
            if (this.AddPaymnt7 != target.AddPaymnt7) resList.Add("AddPaymnt7");
            if (this.AddPaymnt8 != target.AddPaymnt8) resList.Add("AddPaymnt8");
            if (this.AddPaymnt9 != target.AddPaymnt9) resList.Add("AddPaymnt9");
            if (this.AddPaymnt10 != target.AddPaymnt10) resList.Add("AddPaymnt10");
            if (this.FractionProcCd != target.FractionProcCd) resList.Add("FractionProcCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // 2010/04/12 Add >>>
            if (this.MarketPriceQualityCd2 != target.MarketPriceQualityCd2) resList.Add("MarketPriceQualityCd2");
            if (this.MarketPriceQualityCd3 != target.MarketPriceQualityCd3) resList.Add("MarketPriceQualityCd3");
            // 2010/04/12 Add <<<
            return resList;
        }

        /// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^��r����
        /// </summary>
        /// <param name="sCMMrktPriSt1">��r����SCMMrktPriSt�N���X�̃C���X�^���X</param>
        /// <param name="sCMMrktPriSt2">��r����SCMMrktPriSt�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriSt�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SCMMrktPriSt sCMMrktPriSt1, SCMMrktPriSt sCMMrktPriSt2)
        {
            ArrayList resList = new ArrayList();
            if (sCMMrktPriSt1.CreateDateTime != sCMMrktPriSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (sCMMrktPriSt1.UpdateDateTime != sCMMrktPriSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sCMMrktPriSt1.EnterpriseCode != sCMMrktPriSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sCMMrktPriSt1.FileHeaderGuid != sCMMrktPriSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sCMMrktPriSt1.UpdEmployeeCode != sCMMrktPriSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sCMMrktPriSt1.UpdAssemblyId1 != sCMMrktPriSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sCMMrktPriSt1.UpdAssemblyId2 != sCMMrktPriSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sCMMrktPriSt1.LogicalDeleteCode != sCMMrktPriSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sCMMrktPriSt1.SectionCode != sCMMrktPriSt2.SectionCode) resList.Add("SectionCode");
            if (sCMMrktPriSt1.MarketPriceAreaCd != sCMMrktPriSt2.MarketPriceAreaCd) resList.Add("MarketPriceAreaCd");
            if (sCMMrktPriSt1.MarketPriceQualityCd != sCMMrktPriSt2.MarketPriceQualityCd) resList.Add("MarketPriceQualityCd");
            if (sCMMrktPriSt1.MarketPriceKindCd1 != sCMMrktPriSt2.MarketPriceKindCd1) resList.Add("MarketPriceKindCd1");
            if (sCMMrktPriSt1.MarketPriceKindCd2 != sCMMrktPriSt2.MarketPriceKindCd2) resList.Add("MarketPriceKindCd2");
            if (sCMMrktPriSt1.MarketPriceKindCd3 != sCMMrktPriSt2.MarketPriceKindCd3) resList.Add("MarketPriceKindCd3");
            if (sCMMrktPriSt1.MarketPriceAnswerDiv != sCMMrktPriSt2.MarketPriceAnswerDiv) resList.Add("MarketPriceAnswerDiv");
            if (sCMMrktPriSt1.MarketPriceSalesRate != sCMMrktPriSt2.MarketPriceSalesRate) resList.Add("MarketPriceSalesRate");
            if (sCMMrktPriSt1.AddPaymntAmbit1 != sCMMrktPriSt2.AddPaymntAmbit1) resList.Add("AddPaymntAmbit1");
            if (sCMMrktPriSt1.AddPaymntAmbit2 != sCMMrktPriSt2.AddPaymntAmbit2) resList.Add("AddPaymntAmbit2");
            if (sCMMrktPriSt1.AddPaymntAmbit3 != sCMMrktPriSt2.AddPaymntAmbit3) resList.Add("AddPaymntAmbit3");
            if (sCMMrktPriSt1.AddPaymntAmbit4 != sCMMrktPriSt2.AddPaymntAmbit4) resList.Add("AddPaymntAmbit4");
            if (sCMMrktPriSt1.AddPaymntAmbit5 != sCMMrktPriSt2.AddPaymntAmbit5) resList.Add("AddPaymntAmbit5");
            if (sCMMrktPriSt1.AddPaymntAmbit6 != sCMMrktPriSt2.AddPaymntAmbit6) resList.Add("AddPaymntAmbit6");
            if (sCMMrktPriSt1.AddPaymntAmbit7 != sCMMrktPriSt2.AddPaymntAmbit7) resList.Add("AddPaymntAmbit7");
            if (sCMMrktPriSt1.AddPaymntAmbit8 != sCMMrktPriSt2.AddPaymntAmbit8) resList.Add("AddPaymntAmbit8");
            if (sCMMrktPriSt1.AddPaymntAmbit9 != sCMMrktPriSt2.AddPaymntAmbit9) resList.Add("AddPaymntAmbit9");
            if (sCMMrktPriSt1.AddPaymntAmbit10 != sCMMrktPriSt2.AddPaymntAmbit10) resList.Add("AddPaymntAmbit10");
            if (sCMMrktPriSt1.AddPaymnt1 != sCMMrktPriSt2.AddPaymnt1) resList.Add("AddPaymnt1");
            if (sCMMrktPriSt1.AddPaymnt2 != sCMMrktPriSt2.AddPaymnt2) resList.Add("AddPaymnt2");
            if (sCMMrktPriSt1.AddPaymnt3 != sCMMrktPriSt2.AddPaymnt3) resList.Add("AddPaymnt3");
            if (sCMMrktPriSt1.AddPaymnt4 != sCMMrktPriSt2.AddPaymnt4) resList.Add("AddPaymnt4");
            if (sCMMrktPriSt1.AddPaymnt5 != sCMMrktPriSt2.AddPaymnt5) resList.Add("AddPaymnt5");
            if (sCMMrktPriSt1.AddPaymnt6 != sCMMrktPriSt2.AddPaymnt6) resList.Add("AddPaymnt6");
            if (sCMMrktPriSt1.AddPaymnt7 != sCMMrktPriSt2.AddPaymnt7) resList.Add("AddPaymnt7");
            if (sCMMrktPriSt1.AddPaymnt8 != sCMMrktPriSt2.AddPaymnt8) resList.Add("AddPaymnt8");
            if (sCMMrktPriSt1.AddPaymnt9 != sCMMrktPriSt2.AddPaymnt9) resList.Add("AddPaymnt9");
            if (sCMMrktPriSt1.AddPaymnt10 != sCMMrktPriSt2.AddPaymnt10) resList.Add("AddPaymnt10");
            if (sCMMrktPriSt1.FractionProcCd != sCMMrktPriSt2.FractionProcCd) resList.Add("FractionProcCd");
            if (sCMMrktPriSt1.EnterpriseName != sCMMrktPriSt2.EnterpriseName) resList.Add("EnterpriseName");
            if (sCMMrktPriSt1.UpdEmployeeName != sCMMrktPriSt2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // 2010/04/12 Add >>>
            if (sCMMrktPriSt1.MarketPriceQualityCd2 != sCMMrktPriSt2.MarketPriceQualityCd2) resList.Add("MarketPriceQualityCd2");
            if (sCMMrktPriSt1.MarketPriceQualityCd3 != sCMMrktPriSt2.MarketPriceQualityCd3) resList.Add("MarketPriceQualityCd3");
            // 2010/04/12 Add <<<
            return resList;
        }
    }
}
