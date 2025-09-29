using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SCMMrktPriStWork
    /// <summary>
    ///                      SCM���ꉿ�i�ݒ胏�[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM���ꉿ�i�ݒ胏�[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/5/11  ����</br>
    /// <br>                 :   �����ڕύX</br>
    /// <br>                 :   ���Z�z1�`9�̌^�ύX</br>
    /// <br>                 :   �@Dobule��Int32</br>
    /// <br>                 :   ���Z�z1�`9�̕⑫�ύX</br>
    /// <br>                 :   �@�����ȉ��ˁ�������</br>
    /// <br>Update Note      :   2009/5/15  ����</br>
    /// <br>                 :   �����ڒǉ�</br>
    /// <br>                 :   �[�������敪</br>
    /// <br>Update Note      :   2009/5/15  ����</br>
    /// <br>                 :   ���⑫�ύX</br>
    /// <br>                 :   ���Z�z�͈�</br>
    /// <br>                 :   �����ȏ� �` ��������</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   �����𒴂� �` �����ȉ�</br>
    /// <br></br>
    /// <br>Update Note      :   2010/04/12  21024 ���X��</br>
    /// <br>                 :   ���ꉿ�i�i���R�[�h�Q�A���ꉿ�i�i���R�[�h�R�̒ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SCMMrktPriStWork : IFileHeader
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
        /// <remarks>���Z�z�͈�1�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit2;

        /// <summary>���Z�z�͈�3</summary>
        /// <remarks>���Z�z�͈�2�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit3;

        /// <summary>���Z�z�͈�4</summary>
        /// <remarks>���Z�z�͈�3�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit4;

        /// <summary>���Z�z�͈�5</summary>
        /// <remarks>���Z�z�͈�4�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit5;

        /// <summary>���Z�z�͈�6</summary>
        /// <remarks>���Z�z�͈�5�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit6;

        /// <summary>���Z�z�͈�7</summary>
        /// <remarks>���Z�z�͈�6�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit7;

        /// <summary>���Z�z�͈�8</summary>
        /// <remarks>���Z�z�͈�7�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit8;

        /// <summary>���Z�z�͈�9</summary>
        /// <remarks>���Z�z�͈�8�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit9;

        /// <summary>���Z�z�͈�10</summary>
        /// <remarks>���Z�z�͈�9�𒴂��`�����~�ȉ�</remarks>
        private Int32 _addPaymntAmbit10;

        /// <summary>���Z�z1</summary>
        /// <remarks>���Z�z�͈�1�̉��Z�z</remarks>
        private Int32 _addPaymnt1;

        /// <summary>���Z�z2</summary>
        /// <remarks>���Z�z�͈�2�̉��Z�z</remarks>
        private Int32 _addPaymnt2;

        /// <summary>���Z�z3</summary>
        /// <remarks>���Z�z�͈�3�̉��Z�z</remarks>
        private Int32 _addPaymnt3;

        /// <summary>���Z�z4</summary>
        /// <remarks>���Z�z�͈�4�̉��Z�z</remarks>
        private Int32 _addPaymnt4;

        /// <summary>���Z�z5</summary>
        /// <remarks>���Z�z�͈�5�̉��Z�z</remarks>
        private Int32 _addPaymnt5;

        /// <summary>���Z�z6</summary>
        /// <remarks>���Z�z�͈�6�̉��Z�z</remarks>
        private Int32 _addPaymnt6;

        /// <summary>���Z�z7</summary>
        /// <remarks>���Z�z�͈�7�̉��Z�z</remarks>
        private Int32 _addPaymnt7;

        /// <summary>���Z�z8</summary>
        /// <remarks>���Z�z�͈�8�̉��Z�z</remarks>
        private Int32 _addPaymnt8;

        /// <summary>���Z�z9</summary>
        /// <remarks>���Z�z�͈�9�̉��Z�z</remarks>
        private Int32 _addPaymnt9;

        /// <summary>���Z�z10</summary>
        /// <remarks>���Z�z�͈�10�̉��Z�z</remarks>
        private Int32 _addPaymnt10;

        /// <summary>�[�������敪</summary>
        /// <remarks>0:�P�O�~�P��(�l�̌ܓ�) 1:�P�O�O�~�P��(�l�̌ܓ�)</remarks>
        private Int32 _fractionProcCd;

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
        /// <value>���Z�z�͈�1�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�2�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�3�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�4�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�5�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�6�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�7�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�8�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�9�𒴂��`�����~�ȉ�</value>
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
        /// <value>���Z�z�͈�1�̉��Z�z</value>
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
        /// <value>���Z�z�͈�2�̉��Z�z</value>
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
        /// <value>���Z�z�͈�3�̉��Z�z</value>
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
        /// <value>���Z�z�͈�4�̉��Z�z</value>
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
        /// <value>���Z�z�͈�5�̉��Z�z</value>
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
        /// <value>���Z�z�͈�6�̉��Z�z</value>
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
        /// <value>���Z�z�͈�7�̉��Z�z</value>
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
        /// <value>���Z�z�͈�8�̉��Z�z</value>
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
        /// <value>���Z�z�͈�9�̉��Z�z</value>
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
        /// <value>���Z�z�͈�10�̉��Z�z</value>
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

        // 2010/04/12 Add >>>
        /// public propaty name  :  MarketPriceQualityCd2
        /// <summary>���ꉿ�i�i���R�[�h�Q�v���p�e�B</summary>
        /// <value>0:�ɏ� 1:�� �cRC�̃}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�i���R�[�h�Q�v���p�e�B</br>
        /// <br>Programer        :   21024 ���X��</br>
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
        /// <br>note             :   ���ꉿ�i�i���R�[�h�R�v���p�e�B</br>
        /// <br>Programer        :   21024 ���X��</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd3
        {
            get { return _marketPriceQualityCd3; }
            set { _marketPriceQualityCd3 = value; }
        }
        // 2010/04/12 Add <<<

        /// <summary>
        /// SCM���ꉿ�i�ݒ胏�[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SCMMrktPriStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriStWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SCMMrktPriStWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>SCMMrktPriStWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class SCMMrktPriStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriStWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMMrktPriStWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMMrktPriStWork || graph is ArrayList || graph is SCMMrktPriStWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(SCMMrktPriStWork).FullName));

            if (graph != null && graph is SCMMrktPriStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMMrktPriStWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMMrktPriStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMMrktPriStWork[])graph).Length;
            }
            else if (graph is SCMMrktPriStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���_�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //���ꉿ�i�n��R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceAreaCd
            //���ꉿ�i�i���R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceQualityCd
            //���ꉿ�i��ʃR�[�h�P
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceKindCd1
            //���ꉿ�i��ʃR�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceKindCd2
            //���ꉿ�i��ʃR�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceKindCd3
            //���ꉿ�i�񓚋敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceAnswerDiv
            //���ꉿ�i������
            serInfo.MemberInfo.Add(typeof(Double)); //MarketPriceSalesRate
            //���Z�z�͈�1
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit1
            //���Z�z�͈�2
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit2
            //���Z�z�͈�3
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit3
            //���Z�z�͈�4
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit4
            //���Z�z�͈�5
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit5
            //���Z�z�͈�6
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit6
            //���Z�z�͈�7
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit7
            //���Z�z�͈�8
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit8
            //���Z�z�͈�9
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit9
            //���Z�z�͈�10
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymntAmbit10
            //���Z�z1
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt1
            //���Z�z2
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt2
            //���Z�z3
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt3
            //���Z�z4
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt4
            //���Z�z5
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt5
            //���Z�z6
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt6
            //���Z�z7
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt7
            //���Z�z8
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt8
            //���Z�z9
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt9
            //���Z�z10
            serInfo.MemberInfo.Add(typeof(Int32)); //AddPaymnt10
            //�[�������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd

            // 2010/04/12 Add >>>
            //���ꉿ�i�i���R�[�h�Q
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceQualityCd2
            //���ꉿ�i�i���R�[�h�R
            serInfo.MemberInfo.Add(typeof(Int32)); //MarketPriceQualityCd3
            // 2010/04/12 Add <<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMMrktPriStWork)
            {
                SCMMrktPriStWork temp = (SCMMrktPriStWork)graph;

                SetSCMMrktPriStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMMrktPriStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMMrktPriStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMMrktPriStWork temp in lst)
                {
                    SetSCMMrktPriStWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMMrktPriStWork�����o��(public�v���p�e�B��)
        /// </summary>
        // 2010/04/12 >>>
        //private const int currentMemberCount = 37;
        private const int currentMemberCount = 39;
        // 2010/04/12 <<<
        
        /// <summary>
        ///  SCMMrktPriStWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriStWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetSCMMrktPriStWork(System.IO.BinaryWriter writer, SCMMrktPriStWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���ꉿ�i�n��R�[�h
            writer.Write(temp.MarketPriceAreaCd);
            //���ꉿ�i�i���R�[�h
            writer.Write(temp.MarketPriceQualityCd);
            //���ꉿ�i��ʃR�[�h�P
            writer.Write(temp.MarketPriceKindCd1);
            //���ꉿ�i��ʃR�[�h�Q
            writer.Write(temp.MarketPriceKindCd2);
            //���ꉿ�i��ʃR�[�h�R
            writer.Write(temp.MarketPriceKindCd3);
            //���ꉿ�i�񓚋敪
            writer.Write(temp.MarketPriceAnswerDiv);
            //���ꉿ�i������
            writer.Write(temp.MarketPriceSalesRate);
            //���Z�z�͈�1
            writer.Write(temp.AddPaymntAmbit1);
            //���Z�z�͈�2
            writer.Write(temp.AddPaymntAmbit2);
            //���Z�z�͈�3
            writer.Write(temp.AddPaymntAmbit3);
            //���Z�z�͈�4
            writer.Write(temp.AddPaymntAmbit4);
            //���Z�z�͈�5
            writer.Write(temp.AddPaymntAmbit5);
            //���Z�z�͈�6
            writer.Write(temp.AddPaymntAmbit6);
            //���Z�z�͈�7
            writer.Write(temp.AddPaymntAmbit7);
            //���Z�z�͈�8
            writer.Write(temp.AddPaymntAmbit8);
            //���Z�z�͈�9
            writer.Write(temp.AddPaymntAmbit9);
            //���Z�z�͈�10
            writer.Write(temp.AddPaymntAmbit10);
            //���Z�z1
            writer.Write(temp.AddPaymnt1);
            //���Z�z2
            writer.Write(temp.AddPaymnt2);
            //���Z�z3
            writer.Write(temp.AddPaymnt3);
            //���Z�z4
            writer.Write(temp.AddPaymnt4);
            //���Z�z5
            writer.Write(temp.AddPaymnt5);
            //���Z�z6
            writer.Write(temp.AddPaymnt6);
            //���Z�z7
            writer.Write(temp.AddPaymnt7);
            //���Z�z8
            writer.Write(temp.AddPaymnt8);
            //���Z�z9
            writer.Write(temp.AddPaymnt9);
            //���Z�z10
            writer.Write(temp.AddPaymnt10);
            //�[�������敪
            writer.Write(temp.FractionProcCd);
            // 2010/04/12 Add >>>
            //���ꉿ�i�i���R�[�h�Q
            writer.Write(temp.MarketPriceQualityCd2);
            //���ꉿ�i�i���R�[�h�R
            writer.Write(temp.MarketPriceQualityCd3);
            // 2010/04/12 Add <<<
        }

        /// <summary>
        ///  SCMMrktPriStWork�C���X�^���X�擾
        /// </summary>
        /// <returns>SCMMrktPriStWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriStWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private SCMMrktPriStWork GetSCMMrktPriStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            SCMMrktPriStWork temp = new SCMMrktPriStWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���_�R�[�h
            temp.SectionCode = reader.ReadString();
            //���ꉿ�i�n��R�[�h
            temp.MarketPriceAreaCd = reader.ReadInt32();
            //���ꉿ�i�i���R�[�h
            temp.MarketPriceQualityCd = reader.ReadInt32();
            //���ꉿ�i��ʃR�[�h�P
            temp.MarketPriceKindCd1 = reader.ReadInt32();
            //���ꉿ�i��ʃR�[�h�Q
            temp.MarketPriceKindCd2 = reader.ReadInt32();
            //���ꉿ�i��ʃR�[�h�R
            temp.MarketPriceKindCd3 = reader.ReadInt32();
            //���ꉿ�i�񓚋敪
            temp.MarketPriceAnswerDiv = reader.ReadInt32();
            //���ꉿ�i������
            temp.MarketPriceSalesRate = reader.ReadDouble();
            //���Z�z�͈�1
            temp.AddPaymntAmbit1 = reader.ReadInt32();
            //���Z�z�͈�2
            temp.AddPaymntAmbit2 = reader.ReadInt32();
            //���Z�z�͈�3
            temp.AddPaymntAmbit3 = reader.ReadInt32();
            //���Z�z�͈�4
            temp.AddPaymntAmbit4 = reader.ReadInt32();
            //���Z�z�͈�5
            temp.AddPaymntAmbit5 = reader.ReadInt32();
            //���Z�z�͈�6
            temp.AddPaymntAmbit6 = reader.ReadInt32();
            //���Z�z�͈�7
            temp.AddPaymntAmbit7 = reader.ReadInt32();
            //���Z�z�͈�8
            temp.AddPaymntAmbit8 = reader.ReadInt32();
            //���Z�z�͈�9
            temp.AddPaymntAmbit9 = reader.ReadInt32();
            //���Z�z�͈�10
            temp.AddPaymntAmbit10 = reader.ReadInt32();
            //���Z�z1
            temp.AddPaymnt1 = reader.ReadInt32();
            //���Z�z2
            temp.AddPaymnt2 = reader.ReadInt32();
            //���Z�z3
            temp.AddPaymnt3 = reader.ReadInt32();
            //���Z�z4
            temp.AddPaymnt4 = reader.ReadInt32();
            //���Z�z5
            temp.AddPaymnt5 = reader.ReadInt32();
            //���Z�z6
            temp.AddPaymnt6 = reader.ReadInt32();
            //���Z�z7
            temp.AddPaymnt7 = reader.ReadInt32();
            //���Z�z8
            temp.AddPaymnt8 = reader.ReadInt32();
            //���Z�z9
            temp.AddPaymnt9 = reader.ReadInt32();
            //���Z�z10
            temp.AddPaymnt10 = reader.ReadInt32();
            //�[�������敪
            temp.FractionProcCd = reader.ReadInt32();
            // 2010/04/12 Add >>>
            //���ꉿ�i�i���R�[�h�Q
            temp.MarketPriceQualityCd2 = reader.ReadInt32();
            //���ꉿ�i�i���R�[�h�R
            temp.MarketPriceQualityCd3 = reader.ReadInt32();
            // 2010/04/12 Add <<<

            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>SCMMrktPriStWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SCMMrktPriStWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMMrktPriStWork temp = GetSCMMrktPriStWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (SCMMrktPriStWork[])lst.ToArray(typeof(SCMMrktPriStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}