//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�i����j
// �v���O�����T�v   : �\���敪�}�X�^�i����j�����N���X
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

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �\���敪�}�X�^������ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^������ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer : �L�w��</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>�Ǘ��ԍ�   : 10801614-00</br>
    /// </remarks>
    public class PriceSelectSet
    {
        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>���Ӑ�R�[�h</summary> 
        private Int32 _customerCode;

        /// <summary>���Ӑ於</summary>
        private string _customerSnm = "";

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[��</summary>
        private string _goodsMakerSnm;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>�\���敪</summary>
        private Int32 _priceSelectDiv;

        /// <summary>�W�����i�I��ݒ�p�^�[��</summary>
        private Int32 _priceSelectPtn;

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

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ於�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ於�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMakerSnm
        /// <summary>���[�J�[���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerSnm
        {
            get { return _goodsMakerSnm; }
            set { _goodsMakerSnm = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  PRICESELECTDIV
        /// <summary>�\���敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }

        /// public propaty name  :  PriceSelectPtn
        /// <summary>�W�����i�I��ݒ�p�^�[��</summary>
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
        /// <summary>
        /// �\���敪�}�X�^�f�[�^�N���X��������
        /// </summary>
        /// <returns>PriceSelectSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@       :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programmer       :   �L�w��</br>
        /// <br>Date             :   2012/06/11</br>
        /// <br>�Ǘ��ԍ�         :   10801614-00</br>
        /// </remarks>
        public PriceSelectSet Clone()
        {
            return new PriceSelectSet(this._customerCode, this._customerSnm, this._bLGroupCode, this._goodsMakerCd, this._goodsMakerSnm, this._bLGoodsCode, this._bLGoodsHalfName, this._priceSelectDiv, this._priceSelectPtn);
        }

        /// <summary>
        /// �\���敪�}�X�^�f�[�^�N���X��������
        /// </summary>
        /// <returns>PriceSelectSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   �V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programmer       :   �L�w��</br>
        /// <br>Date             :   2012/06/11</br>
        /// <br>�Ǘ��ԍ�         :   10801614-00</br>
        /// </remarks>
        public PriceSelectSet()
        {
        }

        /// <summary>
        /// �\���敪�}�X�^����f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="BLGroupCode"></param>
        /// <param name="GoodsMakerCd"></param>
        /// <param name="GoodsMakerSnm"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="BLGoodsHalfName"></param>
        /// <param name="PriceSelectDiv"></param>
        /// <param name="PriceSelectPtn"></param>
        public PriceSelectSet(Int32 CustomerCode, string CustomerSnm, Int32 BLGroupCode, Int32 GoodsMakerCd, string GoodsMakerSnm, Int32 BLGoodsCode, string BLGoodsHalfName, Int32 PriceSelectDiv, Int32 PriceSelectPtn)
        {
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._bLGroupCode = BLGroupCode;
            this._goodsMakerCd = GoodsMakerCd;
            this._goodsMakerSnm = GoodsMakerSnm;
            this._bLGoodsCode = BLGoodsCode;
            this._bLGoodsHalfName = BLGoodsHalfName;
            this._priceSelectDiv = PriceSelectDiv;
            this._priceSelectPtn = PriceSelectPtn;
        }

    }
}
