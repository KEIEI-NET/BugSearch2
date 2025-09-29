//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏�񌟍��������[�N
// �v���O�����T�v   : �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏�񌟍��������[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �� �� ��  2017/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyNonUOEStockParamWork
    /// <summary>
    ///                      �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏�񌟍��������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏�񌟍��������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyNonUOEStockParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�R���s���[�^��</summary>
        private string _machineName = "";

        /// <summary>�����敪</summary>
        /// <remarks>1:�݌Ɉꊇ�� 2:���̑�</remarks>
        private Int32 _opDiv;

        /// <summary>�`�[�ԍ�</summary>
        /// <remarks>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</remarks>
        private Int32 _slipNo;


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

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  MachineName
        /// <summary>�R���s���[�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �R���s���[�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }

        /// public propaty name  :  OpDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>1:�݌Ɉꊇ�� 2:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpDiv
        {
            get { return _opDiv; }
            set { _opDiv = value; }
        }

        /// public propaty name  :  SlipNo
        /// <summary>�`�[�ԍ��v���p�e�B</summary>
        /// <value>���ϓ`�[�ԍ�,�󒍓`�[�ԍ�,�o�ד`�[�ԍ�,����`�[�ԍ������˂�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
        }


        /// <summary>
        /// �݌Ɏd��(UOE�ȊO)���׏�񌟍��������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>HandyNonUOEStockParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyNonUOEStockParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public HandyNonUOEStockParamWork()
        {
        }

    }
}
