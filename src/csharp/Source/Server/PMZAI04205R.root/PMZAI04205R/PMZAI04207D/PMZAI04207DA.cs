using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventoryDataDspParamWork
    /// <summary>
    ///                      �I���\�����o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���\�����o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventoryDataDspParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�q�Ɏw��敪</summary>
        /// <remarks>0:�͈�,1:�P��</remarks>
        private Int32 _warehouseDiv;

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _stWarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _edWarehouseCode = "";

        /// <summary>�q�ɃR�[�h01</summary>
        private string _warehouseCd01 = "";

        /// <summary>�q�ɃR�[�h02</summary>
        private string _warehouseCd02 = "";

        /// <summary>�q�ɃR�[�h03</summary>
        private string _warehouseCd03 = "";

        /// <summary>�q�ɃR�[�h04</summary>
        private string _warehouseCd04 = "";

        /// <summary>�q�ɃR�[�h05</summary>
        private string _warehouseCd05 = "";

        /// <summary>�q�ɃR�[�h06</summary>
        private string _warehouseCd06 = "";

        /// <summary>�q�ɃR�[�h07</summary>
        private string _warehouseCd07 = "";

        /// <summary>�q�ɃR�[�h08</summary>
        private string _warehouseCd08 = "";

        /// <summary>�q�ɃR�[�h09</summary>
        private string _warehouseCd09 = "";

        /// <summary>�q�ɃR�[�h10</summary>
        private string _warehouseCd10 = "";

        /// <summary>�\���敪</summary>
        /// <remarks>0:�S��,1:���Ѝ݌�,2:����݌�</remarks>
        private Int32 _listDiv;

        /// <summary>�\���^�C�v</summary>
        /// <remarks>0:�ʏ�,1:���ѐ�=0�Ͷ��Ă��Ȃ�,2:�ő�</remarks>
        private Int32 _listTypeDiv;


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

        /// public propaty name  :  WarehouseDiv
        /// <summary>�q�Ɏw��敪�v���p�e�B</summary>
        /// <value>0:�͈�,1:�P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�Ɏw��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehouseDiv
        {
            get { return _warehouseDiv; }
            set { _warehouseDiv = value; }
        }

        /// public propaty name  :  StWarehouseCode
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StWarehouseCode
        {
            get { return _stWarehouseCode; }
            set { _stWarehouseCode = value; }
        }

        /// public propaty name  :  EdWarehouseCode
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdWarehouseCode
        {
            get { return _edWarehouseCode; }
            set { _edWarehouseCode = value; }
        }

        /// public propaty name  :  WarehouseCd01
        /// <summary>�q�ɃR�[�h01�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h01�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd01
        {
            get { return _warehouseCd01; }
            set { _warehouseCd01 = value; }
        }

        /// public propaty name  :  WarehouseCd02
        /// <summary>�q�ɃR�[�h02�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h02�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd02
        {
            get { return _warehouseCd02; }
            set { _warehouseCd02 = value; }
        }

        /// public propaty name  :  WarehouseCd03
        /// <summary>�q�ɃR�[�h03�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h03�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd03
        {
            get { return _warehouseCd03; }
            set { _warehouseCd03 = value; }
        }

        /// public propaty name  :  WarehouseCd04
        /// <summary>�q�ɃR�[�h04�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h04�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd04
        {
            get { return _warehouseCd04; }
            set { _warehouseCd04 = value; }
        }

        /// public propaty name  :  WarehouseCd05
        /// <summary>�q�ɃR�[�h05�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h05�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd05
        {
            get { return _warehouseCd05; }
            set { _warehouseCd05 = value; }
        }

        /// public propaty name  :  WarehouseCd06
        /// <summary>�q�ɃR�[�h06�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h06�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd06
        {
            get { return _warehouseCd06; }
            set { _warehouseCd06 = value; }
        }

        /// public propaty name  :  WarehouseCd07
        /// <summary>�q�ɃR�[�h07�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h07�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd07
        {
            get { return _warehouseCd07; }
            set { _warehouseCd07 = value; }
        }

        /// public propaty name  :  WarehouseCd08
        /// <summary>�q�ɃR�[�h08�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h08�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd08
        {
            get { return _warehouseCd08; }
            set { _warehouseCd08 = value; }
        }

        /// public propaty name  :  WarehouseCd09
        /// <summary>�q�ɃR�[�h09�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h09�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd09
        {
            get { return _warehouseCd09; }
            set { _warehouseCd09 = value; }
        }

        /// public propaty name  :  WarehouseCd10
        /// <summary>�q�ɃR�[�h10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCd10
        {
            get { return _warehouseCd10; }
            set { _warehouseCd10 = value; }
        }

        /// public propaty name  :  ListDiv
        /// <summary>�\���敪�v���p�e�B</summary>
        /// <value>0:�S��,1:���Ѝ݌�,2:����݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListDiv
        {
            get { return _listDiv; }
            set { _listDiv = value; }
        }

        /// public propaty name  :  ListTypeDiv
        /// <summary>�\���^�C�v�v���p�e�B</summary>
        /// <value>0:�ʏ�,1:���ѐ�=0�Ͷ��Ă��Ȃ�,2:�ő�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListTypeDiv
        {
            get { return _listTypeDiv; }
            set { _listTypeDiv = value; }
        }


        /// <summary>
        /// �I���\�����o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>InventoryDataDspParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataDspParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventoryDataDspParamWork()
        {
        }

	}
}
