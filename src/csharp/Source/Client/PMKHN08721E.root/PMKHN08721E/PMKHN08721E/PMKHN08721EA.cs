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
    /// �\���敪�}�X�^���
    /// </summary>
    /// <remarks>
    /// <br>Note       : �\���敪�}�X�^��������N���X</br>
    /// <br>Programmer : �L�w��</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// </remarks>
    public class PriceSelectSetPrint
    {
        # region �� private field

        /// <summary>���s�^�C�v</summary>
        private Int32 _printType;

        /// <summary>�J�n���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>�I�����[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _customerCodeSt;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _customerCodeEd;

        /// <summary>�J�n���Ӑ�|���O���[�v�R�[�h</summary>
        private string _bLGroupCodeSt;

        /// <summary>�I�����Ӑ�|���O���[�v�R�[�h</summary>
        private string _bLGroupCodeEd;

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
        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>���s�^�C�v�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>�J�nBL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>�I��BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>�J�nBL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�a�k�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>�I��BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���a�k�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
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
        /// �\���敪�}�X�^�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PriceSelectSetPrint�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSetPrint�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceSelectSetPrint()
        {
        }
        # endregion �� Constructor
    }
}
