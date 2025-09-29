//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƕi�ԕϊ��ꊇ�����ϊ�����
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �i�N
// �� �� ��  2015/02/27   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsChangeAllCndWorkWork
    /// <summary>
    ///                      �i�ԕϊ��ꊇ�����ϊ��������[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �i�ԕϊ��ꊇ�����ϊ��������[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2015/01/26</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsChangeAllCndWorkWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���O�C�����[�U�[�̋��_</summary>
        private string _loginSectionCode = "";

        /// <summary>���O�C�����[�U�[�̋��_����</summary>
        private string _loginSectionNm = "";

        /// <summary>���O�C���S���҃R�[�h</summary>
        private string _loginEmpleeCode = "";

        /// <summary>���O�C���S���҂̖���</summary>
        private string _loginEmpleeName = "";

        /// <summary>�����敪</summary>
        private Int32 _changeDiv;

        /// <summary>�i�ԕϊ��}�X�^�`�F�b�N�敪</summary>
        private Int32 _goodsChangeMstDiv;

        /// <summary>���i�}�X�^�敪</summary>
        private Int32 _goodsMstDiv;

        /// <summary>���i�Ǘ����}�X�^�敪</summary>
        private Int32 _goodsMngMstDiv;

        /// <summary>�݌Ƀ}�X�^�敪</summary>
        private Int32 _stockMstDiv;

        /// <summary>�|���}�X�^�敪</summary>
        private Int32 _rateMstDiv;

        /// <summary>�����}�X�^�敪</summary>
        private Int32 _joinMstDiv;

        /// <summary>��փ}�X�^�敪</summary>
        private Int32 _partsMstDiv;

        /// <summary>�Z�b�g�}�X�^�敪</summary>
        private Int32 _setMstDiv;

        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        /// <summary>�D�ǐݒ�}�X�^�敪</summary>
        private Int32 _prmMstDiv;
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        /// <summary>���v��ݏo�f�[�^�敪</summary>
        private Int32 _shipmentDiv;


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

        /// public propaty name  :  LoginSectionNm
        /// <summary>���O�C�����[�U�[�̋��_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C�����[�U�[�̋��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginSectionNm
        {
            get { return _loginSectionNm; }
            set { _loginSectionNm = value; }
        }

        /// public propaty name  :  LoginSectionCode
        /// <summary>���O�C�����[�U�[�̋��_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C�����[�U�[�̋��_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginSectionCode
        {
            get { return _loginSectionCode; }
            set { _loginSectionCode = value; }
        }

        /// public propaty name  :  LoginEmpleeCode
        /// <summary>���O�C���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginEmpleeCode
        {
            get { return _loginEmpleeCode; }
            set { _loginEmpleeCode = value; }
        }

        /// public propaty name  :  LoginEmpleeName
        /// <summary>���O�C���S���҂̖��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���O�C���S���҂̖��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginEmpleeName
        {
            get { return _loginEmpleeName; }
            set { _loginEmpleeName = value; }
        }

        /// public propaty name  :  ChangeDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChangeDiv
        {
            get { return _changeDiv; }
            set { _changeDiv = value; }
        }

        /// public propaty name  :  GoodsChangeMstDiv
        /// <summary>�i�ԕϊ��}�X�^�`�F�b�N�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԕϊ��}�X�^�`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsChangeMstDiv
        {
            get { return _goodsChangeMstDiv; }
            set { _goodsChangeMstDiv = value; }
        }

        /// public propaty name  :  GoodsMstDiv
        /// <summary>���i�}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMstDiv
        {
            get { return _goodsMstDiv; }
            set { _goodsMstDiv = value; }
        }

        /// public propaty name  :  GoodsMngMstDiv
        /// <summary>���i�Ǘ����}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ����}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMngMstDiv
        {
            get { return _goodsMngMstDiv; }
            set { _goodsMngMstDiv = value; }
        }

        /// public propaty name  :  StockMstDiv
        /// <summary>�݌Ƀ}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ƀ}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMstDiv
        {
            get { return _stockMstDiv; }
            set { _stockMstDiv = value; }
        }

        /// public propaty name  :  RateMstDiv
        /// <summary>�|���}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �|���}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateMstDiv
        {
            get { return _rateMstDiv; }
            set { _rateMstDiv = value; }
        }

        /// public propaty name  :  JoinMstDiv
        /// <summary>�����}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 JoinMstDiv
        {
            get { return _joinMstDiv; }
            set { _joinMstDiv = value; }
        }

        /// public propaty name  :  PartsMstDiv
        /// <summary>��փ}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��փ}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsMstDiv
        {
            get { return _partsMstDiv; }
            set { _partsMstDiv = value; }
        }

        /// public propaty name  :  SetMstDiv
        /// <summary>�Z�b�g�}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z�b�g�}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetMstDiv
        {
            get { return _setMstDiv; }
            set { _setMstDiv = value; }
        }

        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        /// public propaty name  :  PrmMstDiv
        /// <summary>�D�ǐݒ�}�X�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �D�ǐݒ�}�X�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrmMstDiv
        {
            get { return _prmMstDiv; }
            set { _prmMstDiv = value; }
        }
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        /// public propaty name  :  ShipmentDiv
        /// <summary>���v��ݏo�f�[�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���v��ݏo�f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentDiv
        {
            get { return _shipmentDiv; }
            set { _shipmentDiv = value; }
        }


        /// <summary>
        /// �i�ԕϊ��ꊇ�����ϊ��������[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsChangeAllCndWorkWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsChangeAllCndWorkWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsChangeAllCndWorkWork()
        {
        }

    }
}
