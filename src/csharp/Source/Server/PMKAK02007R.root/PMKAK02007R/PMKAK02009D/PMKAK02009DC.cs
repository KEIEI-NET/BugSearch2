//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���ꗗ�\�i�����j
// �v���O�����T�v   : �x���ꗗ�\�i�����j�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���@���j
// �� �� ��  2012/09/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RsltInfo_DepsitTotalWork
    /// <summary>
    ///                      �x�����o���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �x�����o���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/09/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RsltInfo_SumAccPayTotalWork
    {
        /// <summary>����R�[�h</summary>
        /// <remarks>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</remarks>
        private Int32 _moneyKindCode;

        /// <summary>���햼��</summary>
        private string _moneyKindName = "";

        /// <summary>����敪</summary>
        private Int32 _moneyKindDiv;

        /// <summary>�x�����z</summary>
        private Int64 _payment;

        /// public propaty name  :  MoneyKindCode
        /// <summary>����R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�,900�`���[�U�[�o�^�@��8:�l�� 9:�a�����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindCode
        {
            get { return _moneyKindCode; }
            set { _moneyKindCode = value; }
        }

        /// public propaty name  :  MoneyKindName
        /// <summary>���햼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MoneyKindName
        {
            get { return _moneyKindName; }
            set { _moneyKindName = value; }
        }

        /// public propaty name  :  MoneyKindDiv
        /// <summary>����敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoneyKindDiv
        {
            get { return _moneyKindDiv; }
            set { _moneyKindDiv = value; }
        }

        /// public propaty name  :  Deposit
        /// <summary>�x�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }


        /// <summary>
        /// �x�����o���ʃN���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>RsltInfo_SumAccPayTotalWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note             :   RsltInfo_SumAccPayTotalWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltInfo_SumAccPayTotalWork()
        {
        }

    }
}
