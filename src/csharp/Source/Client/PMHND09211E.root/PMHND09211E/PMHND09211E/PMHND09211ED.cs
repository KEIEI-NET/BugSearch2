//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�t�@�C���N���X���[�N
// �v���O�����T�v   : ���i�o�[�R�[�h�t�@�C���f�[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsBarCodeRevnFileWork
    /// <summary>
    ///                      ���i�o�[�R�[�h�t�@�C���N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�o�[�R�[�h�t�@�C���N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2017/06/12  (CSharp File Generated Date)</br>
    /// </remarks>
    public class GoodsBarCodeRevnFileWork
    {
        /// <summary>���i���[�J�[�R�[�h</summary>
        private string _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i�o�[�R�[�h</summary>
        private string _goodsBarCode;

        /// <summary>���i�o�[�R�[�h���</summary>
        private string _goodsBarCodeKind;

        /// <summary>�G���[���b�Z�[�W</summary>
        private string _errMessage;


        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsBarCode
        /// <summary>���i�o�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�o�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsBarCode
        {
            get { return _goodsBarCode; }
            set { _goodsBarCode = value; }
        }

        /// public propaty name  :  GoodsBarCodeKind
        /// <summary>���i�o�[�R�[�h��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�o�[�R�[�h��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsBarCodeKind
        {
            get { return _goodsBarCodeKind; }
            set { _goodsBarCodeKind = value; }
        }

        /// public propaty name  :  ErrMessage
        /// <summary>�G���[���b�Z�[�W�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ErrMessage
        {
            get { return _errMessage; }
            set { _errMessage = value; }
        }

        /// <summary>
        /// ���i�o�[�R�[�h�G���[���O�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsBarCodeRevnFileWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsBarCodeRevnFileWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsBarCodeRevnFileWork()
        {
        }
    }
}
