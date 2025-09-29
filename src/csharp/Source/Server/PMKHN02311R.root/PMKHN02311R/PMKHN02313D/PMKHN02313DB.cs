//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
       /// public class name:   TrustStockOrderCndtnWork
    /// <summary>
    ///                      �������i���i�������o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �������i���i�������o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsInfoCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�t�@�C������</summary>
        private string _fileName;

        /// <summary>�X�V�敪</summary>
        private Int32 _updateType;

        /// <summary>���͌���</summary>
        private Int32 _insertNum;

        /// <summary>�X�V����</summary>
        private Int32 _updateNum;

        /// <summary>�ǉ�����</summary>
        private Int32 _addNum;

        /// <summary>�x������</summary>
        private Int32 _warnNum;

        /// <summary>�G���[����</summary>
        private Int32 _errorNum;


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


        /// public propaty name  :  FileName
        /// <summary>�t�@�C�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        /// public propaty name  :  UpdateType
        /// <summary>�X�V�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateType
        {
            get { return _updateType; }
            set { _updateType = value; }
        }




        /// public propaty name  :  InsertNum
        /// <summary>���͌����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͌����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InsertNum
        {
            get { return _insertNum; }
            set { _insertNum = value; }
        }


        /// public propaty name  :  UpdateNum
        /// <summary>�X�V�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateNum
        {
            get { return _updateNum; }
            set { _updateNum = value; }
        }

        /// public propaty name  :  AddNum
        /// <summary>�ǉ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ǉ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 AddNum
        {
            get { return _addNum; }
            set { _addNum = value; }
        }


        /// public propaty name  :  WarnNum
        /// <summary>�x�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarnNum
        {
            get { return _warnNum; }
            set { _warnNum = value; }
        }



        /// public propaty name  :  ErrorNum
        /// <summary>�G���[�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �G���[�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ErrorNum
        {
            get { return _errorNum; }
            set { _errorNum = value; }
        }

        /// <summary>
        /// �����e�L�X�g�o�͒��o�����N���X
        /// </summary>
        /// <returns>DispatchInsts�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   �����e�L�X�g�o�͒��o�����N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsInfoCndtnWork()
        {
        }

    }
}
