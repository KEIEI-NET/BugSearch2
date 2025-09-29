//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ�}�X�^���X�g���o�����N���X
// �v���O�����T�v   : �����_�ݒ�}�X�^���X�g���o�����N���X�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OrderSetMasListPara
    /// <summary>
    ///                      �����_�ݒ�}�X�^���X�g���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����_�ݒ�}�X�^���X�g���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/04/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class OrderSetMasListPara
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���{""}</remarks>
        private string[] _sectionCodes;

        /// <summary>���_�K�C�h����</summary>
        /// <remarks>�t�h�p�i�����̃R���{�{�b�N�X���j</remarks>
        private string _sectionGuideNm = "";

        /// <summary>�J�n�ݒ�R�[�h</summary>
        private string _startSetCode = "";

        /// <summary>�I���ݒ�R�[�h</summary>
        private string _endSetCode = "";

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _startWarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _endWarehouseCode = "";

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _startSupplierCd;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _endSupplierCd;

        /// <summary>�J�n���[�J�[�R�[�h</summary>
        /// <remarks>�����X�O�O�ԑ� �D�ǂX�O�O�O�ԑ�</remarks>
        private Int32 _startGoodsMakerCd;

        /// <summary>�I�����[�J�[�R�[�h</summary>
        /// <remarks>�����X�O�O�ԑ� �D�ǂX�O�O�O�ԑ�</remarks>
        private Int32 _endGoodsMakerCd;

        /// <summary>�J�n�O���[�v�R�[�h</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _startBLGroupCode;

        /// <summary>�I���O���[�v�R�[�h</summary>
        /// <remarks>���i�敪�ڍ�</remarks>
        private Int32 _endBLGroupCode;

        /// <summary>�J�nBL���i�R�[�h</summary>
        /// <remarks>��:1�`9999 ���[�U�[:10000�`</remarks>
        private Int32 _startBLGoodsCode;

        /// <summary>�I��BL���i�R�[�h</summary>
        /// <remarks>��:1�`9999 ���[�U�[:10000�`</remarks>
        private Int32 _endBLGoodsCode;

        /// <summary>�J�n���i�����ރR�[�h</summary>
        private Int32 _startGoodsMGroup;

        /// <summary>�I�����i�����ރR�[�h</summary>
        private Int32 _endGoodsMGroup;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>���s�^�C�v</summary>
        private Int32 _printType;

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

        /// public propaty name  :  SectionCodes
        /// <summary>�v�㋒�_�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i���z��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>���_�K�C�h���̃v���p�e�B</summary>
        /// <value>�t�h�p�i�����̃R���{�{�b�N�X���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�K�C�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  StartSetCode
        /// <summary>�J�n�ݒ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�ݒ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartSetCode
        {
            get { return _startSetCode; }
            set { _startSetCode = value; }
        }

        /// public propaty name  :  EndSetCode
        /// <summary>�I���ݒ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���ݒ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndSetCode
        {
            get { return _endSetCode; }
            set { _endSetCode = value; }
        }

        /// public propaty name  :  StartWarehouseCode
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StartWarehouseCode
        {
            get { return _startWarehouseCode; }
            set { _startWarehouseCode = value; }
        }

        /// public propaty name  :  EndWarehouseCode
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EndWarehouseCode
        {
            get { return _endWarehouseCode; }
            set { _endWarehouseCode = value; }
        }

        /// public propaty name  :  StartSupplierCd
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartSupplierCd
        {
            get { return _startSupplierCd; }
            set { _startSupplierCd = value; }
        }

        /// public propaty name  :  EndSupplierCd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndSupplierCd
        {
            get { return _endSupplierCd; }
            set { _endSupplierCd = value; }
        }

        /// public propaty name  :  StartGoodsMakerCd
        /// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�����X�O�O�ԑ� �D�ǂX�O�O�O�ԑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartGoodsMakerCd
        {
            get { return _startGoodsMakerCd; }
            set { _startGoodsMakerCd = value; }
        }

        /// public propaty name  :  EndGoodsMakerCd
        /// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�����X�O�O�ԑ� �D�ǂX�O�O�O�ԑ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndGoodsMakerCd
        {
            get { return _endGoodsMakerCd; }
            set { _endGoodsMakerCd = value; }
        }

        /// public propaty name  :  StartBLGroupCode
        /// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���i�敪�ڍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartBLGroupCode
        {
            get { return _startBLGroupCode; }
            set { _startBLGroupCode = value; }
        }

        /// public propaty name  :  EndBLGroupCode
        /// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���i�敪�ڍ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndBLGroupCode
        {
            get { return _endBLGroupCode; }
            set { _endBLGroupCode = value; }
        }

        /// public propaty name  :  StartBLGoodsCode
        /// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
        /// <value>��:1�`9999 ���[�U�[:10000�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartBLGoodsCode
        {
            get { return _startBLGoodsCode; }
            set { _startBLGoodsCode = value; }
        }

        /// public propaty name  :  EndBLGoodsCode
        /// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
        /// <value>��:1�`9999 ���[�U�[:10000�`</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndBLGoodsCode
        {
            get { return _endBLGoodsCode; }
            set { _endBLGoodsCode = value; }
        }

        /// public propaty name  :  StartGoodsMGroup
        /// <summary>�J�n���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartGoodsMGroup
        {
            get { return _startGoodsMGroup; }
            set { _startGoodsMGroup = value; }
        }

        /// public propaty name  :  EndGoodsMGroup
        /// <summary>�I�����i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EndGoodsMGroup
        {
            get { return _endGoodsMGroup; }
            set { _endGoodsMGroup = value; }
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

        /// public propaty name  :  PrintType
        /// <summary>���s�^�C�v</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���s�^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }
    }
}