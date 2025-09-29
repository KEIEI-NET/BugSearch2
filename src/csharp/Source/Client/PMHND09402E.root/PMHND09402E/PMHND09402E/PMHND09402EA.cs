//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�Ǖ��i�o�[�R�[�h�X�V����
// �v���O�����T�v   : �D�Ǖ��i�o�[�R�[�h�X�V�����p�����[�^���[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00  �쐬�S�� : 30757 ���X�؋M�p
// �� �� ��  2017/09/20   �C�����e : �n���f�B�^�[�~�i���񎟑Ή��i�V�K�쐬�j
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PrmGoodsBrcdUpdateParamWork
    /// <summary>
    ///                      �D�Ǖ��i�o�[�R�[�h�X�V�����p�����[�^���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �D�Ǖ��i�o�[�R�[�h�X�V�����p�����[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/09/20</br>
    /// <br>Genarated Date   :   2017/09/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PrmGoodsBrcdUpdateParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���[�J�[�R�[�h�i�J�n�j</summary>
        private Int32 _makerCdST;

        /// <summary>���[�J�[�R�[�h�i�I���j</summary>
        private Int32 _makerCdED;

        /// <summary>���i�����ރR�[�h</summary>
        private Int32 _goodMGroup;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>���R�[�h����</summary>
        /// <remarks>���������Ŏg�p</remarks>
        private Int32 _recordCnt;

        /// <summary>�o�[�R�[�h�X�V�敪</summary>
        private Int32 _barcodeUpdateKndDiv;


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

        /// public propaty name  :  MakerCdST
        /// <summary>���[�J�[�R�[�h�i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCdST
        {
            get { return _makerCdST; }
            set { _makerCdST = value; }
        }

        /// public propaty name  :  MakerCdED
        /// <summary>���[�J�[�R�[�h�i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCdED
        {
            get { return _makerCdED; }
            set { _makerCdED = value; }
        }

        /// public propaty name  :  GoodMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodMGroup
        {
            get { return _goodMGroup; }
            set { _goodMGroup = value; }
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

        /// public propaty name  :  RecordCnt
        /// <summary>���R�[�h�����v���p�e�B</summary>
        /// <value>���������Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R�[�h�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RecordCnt
        {
            get { return _recordCnt; }
            set { _recordCnt = value; }
        }

        /// public propaty name  :  BarcodeUpdateKndDiv
        /// <summary>�o�[�R�[�h�X�V�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�[�R�[�h�X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BarcodeUpdateKndDiv
        {
            get { return _barcodeUpdateKndDiv; }
            set { _barcodeUpdateKndDiv = value; }
        }


        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h�X�V�����p�����[�^���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PrmGoodsBarCodeRevnUpdateParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PrmGoodsBarCodeRevnUpdateParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrmGoodsBrcdUpdateParamWork()
        {
        }

    }
}