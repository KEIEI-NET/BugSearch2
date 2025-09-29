//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�i����j
// �v���O�����T�v   : �\���敪�}�X�^�i����j�f�[�^�p�����[�^ 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �� �� ��  2012/06/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceSelectSetCndtnWork
    /// <summary>
    ///                      �\���敪�}�X�^�i����j�����������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �\���敪�}�X�^�i����j�����������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/06/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceSelectSetCndtnWork
    {
        # region �� private field

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�W�����i�I��ݒ�p�^�[��</summary>
        private Int32 _priceSelectPtn;

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _st_bLGoodsCode;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _ed_bLGoodsCode;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _st_customerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _ed_customerCode;

        /// <summary>�J�n���Ӑ�|���O���[�v�R�[�h</summary>
        private string _st_bLGroupCode;

        /// <summary>�I�����Ӑ�|���O���[�v�R�[�h</summary>
        private string _ed_bLGroupCode;

        /// <summary>�폜�w��敪</summary>
        /// <remarks>0:�L��,1:�_���폜</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�J�n�폜���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _deleteDateTimeSt;

        /// <summary>�I���폜���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _deleteDateTimeEd;

        # endregion  �� private field

        # region �� public propaty
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

        /// public propaty name  :  PriceSelectPtn
        /// <summary>�W�����i�I��ݒ�p�^�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I��ݒ�p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectPtn
        {
            get { return _priceSelectPtn; }
            set { _priceSelectPtn = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_BLGoodsCodeSt
        /// <summary>BL���i�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_bLGoodsCode; }
            set { _st_bLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCodeSt
        /// <summary>BL���i�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_bLGoodsCode; }
            set { _ed_bLGoodsCode = value; }
        }

        /// public propaty name  :  St_CustomerCodeSt
        /// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_customerCode; }
            set { _st_customerCode = value; }
        }

        /// public propaty name  :  St_CustomerCodeSt
        /// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_customerCode; }
            set { _ed_customerCode = value; }
        }

        /// public propaty name  :  St_BLGroupCodeSt
        /// <summary>���Ӑ�|���O���[�v�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_BLGroupCode
        {
            get { return _st_bLGroupCode; }
            set { _st_bLGroupCode = value; }
        }

        /// public propaty name  :  St_BLGroupCodeSt
        /// <summary>���Ӑ�|���O���[�v�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_BLGroupCode
        {
            get { return _ed_bLGroupCode; }
            set { _ed_bLGroupCode = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�폜�w��敪�v���p�e�B</summary>
        /// <value>0:�L��,1:�_���폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �폜�w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>�J�n�폜���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�폜���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>�I���폜���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���폜���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }

        # endregion �� public propaty

        # region �� Constructor
        /// <summary>
        /// �\���敪�}�X�^���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PriceSelectSetCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceSelectSetCndtnWork()
        {
        }
        # endregion �� Constructor
    }
}
