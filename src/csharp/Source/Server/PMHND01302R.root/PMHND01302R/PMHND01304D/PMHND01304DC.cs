//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�̌��i���擾�������[�N
// �v���O�����T�v   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�̌��i���擾�������[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �� �� ��  2017/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370104-00 �쐬�S�� : �e�c�@���V
// �C �� ��  2017/12/14  �C�����e :�n���f�B�^�[�~�i���O���Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ConsStockRepInspectParamWork
    /// <summary>
    ///                      �ϑ��݌ɕ�[�̌��i���擾�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ϑ��݌ɕ�[�̌��i���擾�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>Genarated Date   :   2017/08/11  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ConsStockRepInspectParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�R���s���[�^��</summary>
        private string _machineName = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode = "";

        /// <summary>�ϑ��q�ɃR�[�h</summary>
        private string _consignWarehouseCode = "";

        /// <summary>�o�ד��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shipmentDay;

        // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
        /// <summary>��Ǒq�ɃR�[�h</summary>
        private string _mainMngWarehouseCode = "";
        // --- ADD 2017/12/14 Y.Wakita ----------<<<<<

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

        /// public propaty name  :  ConsignWarehouseCode
        /// <summary>�ϑ��q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ��q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ConsignWarehouseCode
        {
            get { return _consignWarehouseCode; }
            set { _consignWarehouseCode = value; }
        }

        /// public propaty name  :  ShipmentDay
        /// <summary>�o�ד��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShipmentDay
        {
            get { return _shipmentDay; }
            set { _shipmentDay = value; }
        }

        // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
        /// public propaty name  :  MainMngWarehouseCode
        /// <summary>��Ǒq�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ǒq�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MainMngWarehouseCode
        {
            get { return _mainMngWarehouseCode; }
            set { _mainMngWarehouseCode = value; }
        }
        // --- ADD 2017/12/14 Y.Wakita ----------<<<<

        /// <summary>
        /// �ϑ��݌ɕ�[�̌��i���擾�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ConsStockRepInspectParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ConsStockRepInspectParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ConsStockRepInspectParamWork()
        {
        }

    }
}
