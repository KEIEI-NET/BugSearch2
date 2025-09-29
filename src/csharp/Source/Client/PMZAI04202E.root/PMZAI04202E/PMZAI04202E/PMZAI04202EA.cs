using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   InventoryDataDspParamWork
    /// <summary>
    ///                      �I���\�����o����
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���\�����o�����w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2014/03/05 �c����</br>
    /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class InventoryDataDspParam
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

        /// <summary>�\���敪1</summary>
        /// <remarks>0:�q�ɕ�,1:�S�Ќv</remarks>
        private Int32 _listDiv1;

        /// <summary>�\���敪2</summary>
        /// <remarks>0:�S��,1:���Ѝ݌�,2:����݌�</remarks>
        private Int32 _listDiv2;

        /// <summary>�\���^�C�v</summary>
        /// <remarks>0:�ʏ�,1:���ѐ�=0�Ͷ��Ă��Ȃ�,2:�ő�</remarks>
        private Int32 _listTypeDiv;

        //----- ADD 2014/03/05 �c���� Redmine#42247 ---------->>>>>
        /// <summary>���[�J�[����</summary>
        private string _goodsMakerName = "";
        //----- ADD 2014/03/05 �c���� Redmine#42247 ----------<<<<<


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

        /// public propaty name  :  ListDiv1
        /// <summary>�\���敪�v���p�e�B</summary>
        /// <value>0:�q�ɕ�.,1:�S�Ќv</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListDiv1
        {
            get { return _listDiv1; }
            set { _listDiv1 = value; }
        }

        /// public propaty name  :  ListDiv2
        /// <summary>�\���敪�v���p�e�B</summary>
        /// <value>0:�S��,1:���Ѝ݌�,2:����݌�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListDiv2
        {
            get { return _listDiv2; }
            set { _listDiv2 = value; }
        }

        /// public propaty name  :  ListTypeDiv
        /// <summary>�\���^�C�v�v���p�e�B</summary>
        /// <value>0:�q�ɕ�,1:�S�Ќv</value>
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

        //----- ADD 2014/03/05 �c���� Redmine#42247 ---------->>>>>
        /// public propaty name  :  GoodsMakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerName
        {
            get { return _goodsMakerName; }
            set { _goodsMakerName = value; }
        }
        //----- ADD 2014/03/05 �c���� Redmine#42247 ----------<<<<<


        /// <summary>
        /// �I���\�����o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>InventoryDataDspParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventoryDataDspParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventoryDataDspParam()
        {
        }

        /// <summary>
        /// �o�ו��i�\�������N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="sectionCode">���_�R�[�h(�W�v�̑ΏۂƂȂ��Ă��鋒�_�R�[�h)</param>
        /// <param name="stAddUpYearMonth">�v��N��(�J�n)(YYYYMM)</param>
        /// <param name="edAddUpYearMonth">�v��N��(�I��)(YYYYMM)</param>
        /// <param name="goodsMakerName">���[�J�[����</param>
        /// <returns>ShipmentPartsDspParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ShipmentPartsDspParam�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2014/03/05 �c����</br>
        /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        public InventoryDataDspParam(string enterpriseCode, Int32 GoodsMakerCd, Int32 WarehouseDiv, string StWarehousCode, string EdWarehouseCode,
            string WarehouseCd01, string WarehouseCd02, string WarehouseCd03, string WarehouseCd04, string WarehouseCd05, string WarehouseCd06,
            //string WarehouseCd07, string WarehouseCd08, string WarehouseCd09, string WarehouseCd10, Int32 ListDiv1, Int32 ListDiv2, Int32 ListTypeDiv) // DEL 2014/03/05 �c���� Redmine#42247
             string WarehouseCd07, string WarehouseCd08, string WarehouseCd09, string WarehouseCd10, Int32 ListDiv1, Int32 ListDiv2, Int32 ListTypeDiv, string goodsMakerName) // ADD 2014/03/05 �c���� Redmine#42247
        {
            this._enterpriseCode = enterpriseCode;
            this._goodsMakerCd = GoodsMakerCd;
            this._warehouseDiv = WarehouseDiv;
            this._listDiv1 = ListDiv1;
            this._listDiv2 = ListDiv2;
            this._stWarehouseCode = StWarehouseCode;
            this._edWarehouseCode = EdWarehouseCode;
            this._warehouseCd01 = WarehouseCd01;
            this._warehouseCd02 = WarehouseCd02;
            this._warehouseCd03 = WarehouseCd03;
            this._warehouseCd04 = WarehouseCd04;
            this._warehouseCd05 = WarehouseCd05;
            this._warehouseCd06 = WarehouseCd06;
            this._warehouseCd07 = WarehouseCd07;
            this._warehouseCd08 = WarehouseCd08;
            this._warehouseCd09 = WarehouseCd09;
            this._warehouseCd10 = WarehouseCd10;
            this._goodsMakerName = goodsMakerName; // ADD 2014/03/05 �c���� Redmine#42247
        }

        /// <summary>
        /// �o�ו��i�\�������N���X��������
        /// </summary>
        /// <returns>ShipmentPartsDspParam�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����ShipmentPartsDspParam�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2014/03/05 �c����</br>
        /// <br>                 :   Redmine#42247 ����@�\�̒ǉ�</br>
        /// </remarks>
        public InventoryDataDspParam Clone()
        {
            return new InventoryDataDspParam(this._enterpriseCode, this._goodsMakerCd, this._warehouseDiv, this._stWarehouseCode, this._edWarehouseCode,
                this._warehouseCd01, this._warehouseCd02, this._warehouseCd03, this._warehouseCd04, this._warehouseCd05, this._warehouseCd06,
                //this._warehouseCd07, this._warehouseCd08, this._warehouseCd09, this._warehouseCd10, this._listDiv1, this._listDiv2,this._listTypeDiv); // DEL 2014/03/05 �c���� Redmine#42247
                this._warehouseCd07, this._warehouseCd08, this._warehouseCd09, this._warehouseCd10, this._listDiv1, this._listDiv2, this._listTypeDiv, this._goodsMakerName); // ADD 2014/03/05 �c���� Redmine#42247
        }
    }
}