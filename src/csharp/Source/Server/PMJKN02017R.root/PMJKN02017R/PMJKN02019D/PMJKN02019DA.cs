//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�������i�}�X�^���o�����N���X���[�N
// �v���O�����T�v   : ���R�������i�}�X�^���o�����N���X���[�N�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���C��
// �� �� ��  2010/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   FreeSearchPartsParaWork
    /// <summary>
    ///                      ���R�������i�}�X�^���o�����N���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����Ԍ��ԗ��ꗗ�\���o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/04/21</br>
    /// <br>Genarated Date   :   2010/04/21  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class FreeSearchPartsParaWork
    {
        # region �� private field ��
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�Ԏ탁�[�J�[�R�[�h�i�J�n�j</summary>
        private Int32 _carMakerCodeSt;

        /// <summary>�Ԏ탁�[�J�[�R�[�h�i�I���j</summary>
        private Int32 _carMakerCodeEd;

        /// <summary>�Ԏ�R�[�h�i�J�n�j</summary>
        private Int32 _carModelCodeSt;

        /// <summary>�Ԏ�R�[�h�i�I���j</summary>
        private Int32 _carModelCodeEd;

        /// <summary>�Ԏ�T�u�R�[�h�i�J�n�j</summary>
        private Int32 _carModelSubCodeSt;

        /// <summary>�Ԏ�T�u�R�[�h�i�I���j</summary>
        private Int32 _carModelSubCodeEd;

        /// <summary>�^��</summary>
        private string _modelName;

        /// <summary>���[�J�[�J�n</summary>
        private Int32 _makerCodeSt;

        /// <summary>���[�J�[�I��</summary>
        private Int32 _makerCodeEd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�o�^��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _createDateTime;

        /// <summary>�o�^���i�����j</summary>
        /// <remarks>0:�ȑO,1:�ȍ~,2:����</remarks>
        private Int32 _createDateTimeCode;

        /// <summary>����</summary>
        /// <remarks>0:���Ȃ� 1:�Ԏ�</remarks>
        private Int32 _newPageDiv;

        /// <summary>�폜�w��敪</summary>
        /// <remarks>0:�L��,1:�_���폜</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�J�n�폜���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>�I���폜���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;

        # endregion  �� private field ��

        # region �� public propaty ��
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

        /// public propaty name  :  CarMakerCodeSt
        /// <summary>�Ԏ탁�[�J�[�R�[�h�i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ탁�[�J�[�R�[�h�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMakerCodeSt
        {
            get { return _carMakerCodeSt; }
            set { _carMakerCodeSt = value; }
        }

        /// public propaty name  :  CarMakerCodeEd
        /// <summary>�Ԏ탁�[�J�[�R�[�h�i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ탁�[�J�[�R�[�h�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMakerCodeEd
        {
            get { return _carMakerCodeEd; }
            set { _carMakerCodeEd = value; }
        }

        /// public propaty name  :  CarModelCodeSt
        /// <summary>�Ԏ�R�[�h�i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarModelCodeSt
        {
            get { return _carModelCodeSt; }
            set { _carModelCodeSt = value; }
        }

        /// public propaty name  :  CarModelCodeEd
        /// <summary>�Ԏ�R�[�h�i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarModelCodeEd
        {
            get { return _carModelCodeEd; }
            set { _carModelCodeEd = value; }
        }

        /// public propaty name  :  CarModelSubCodeSt
        /// <summary>�Ԏ�T�u�R�[�h�i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarModelSubCodeSt
        {
            get { return _carModelSubCodeSt; }
            set { _carModelSubCodeSt = value; }
        }

        /// public propaty name  :  CarModelSubCodeEd
        /// <summary>�Ԏ�T�u�R�[�h�i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarModelSubCodeEd
        {
            get { return _carModelSubCodeEd; }
            set { _carModelSubCodeEd = value; }
        }

        /// public propaty name  :  ModelName
        /// <summary>�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// public propaty name  :  MakerCodeSt
        /// <summary>���[�J�[�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCodeSt
        {
            get { return _makerCodeSt; }
            set { _makerCodeSt = value; }
        }

        /// public propaty name  :  MakerCodeEd
        /// <summary>���[�J�[�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCodeEd
        {
            get { return _makerCodeEd; }
            set { _makerCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>�J�nBL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
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
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  CreateDateTime
        /// <summary>�o�^���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeCode
        /// <summary>�o�^���i�����j�v���p�e�B</summary>
        /// <value>0:�ȑO,1:�ȍ~,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�^���i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CreateDateTimeCode
        {
            get { return _createDateTimeCode; }
            set { _createDateTimeCode = value; }
        }

        /// public propaty name  :  NewPageDiv
        /// <summary>���Ńv���p�e�B</summary>
        /// <value>0:�Ȃ� 1:���q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
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
        public Int32 DeleteDateTimeSt
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
        public Int32 DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }
        # endregion �� public propaty ��

        # region �� Constructor ��
        /// <summary>
        /// ���R�������i�}�X�^�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>FreeSearchPartsParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   FreeSearchPartsParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public FreeSearchPartsParaWork()
        {
        }
        # endregion �� Constructor ��
    }
}
