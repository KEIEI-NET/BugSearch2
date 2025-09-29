//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�i�ԃp�^�[�����������f�[�^�������[�N
// �v���O�����T�v   : ���[�J�[�i�ԃp�^�[�����������������[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00   �쐬�S�� : ���O
// �� �� ��  2020/03/09    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyMakerGoodsPtrnHisCondWork
    /// <summary>
    ///                      ���[�J�[�i�ԃp�^�[�����������������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[�J�[�i�ԃp�^�[�����������������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2020/03/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyMakerGoodsPtrnHisCondWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�������t�J�n</summary>
        private Int32 _searchDateSt;

        /// <summary>�������t�I��</summary>
        private Int32 _searchDateEd;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�o�[�R�[�h�f�[�^</summary>
        private string _barCodeData = "";


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

        /// public propaty name  :  SearchDateSt
        /// <summary>�������t�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDateSt
        {
            get { return _searchDateSt; }
            set { _searchDateSt = value; }
        }

        /// public propaty name  :  SearchDateEd
        /// <summary>�������t�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDateEd
        {
            get { return _searchDateEd; }
            set { _searchDateEd = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  BarCodeData
        /// <summary>�o�[�R�[�h�f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�[�R�[�h�f�[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BarCodeData
        {
            get { return _barCodeData; }
            set { _barCodeData = value; }
        }


        /// <summary>
        /// ���[�J�[�i�ԃp�^�[�����������������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>HandyMakerGoodsPtrnHisCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyMakerGoodsPtrnHisCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public HandyMakerGoodsPtrnHisCondWork()
        {
        }

    }
}
