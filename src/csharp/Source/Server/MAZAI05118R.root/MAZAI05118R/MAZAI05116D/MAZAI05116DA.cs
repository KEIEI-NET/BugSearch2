using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventoryExtCndtnWork
    /// <summary>
    ///                      �I���f�[�^(������������)�����������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���f�[�^(������������)�����������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/11/30 ���M �ێ�˗��B�Ή�</br>
    /// <br>                     �I������������ݒ�敪�A�I���^�p�敪��ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventoryExtCndtnWork
    {
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

        //-----ADD 2011/01/11----->>>>>
        /// <summary>�J�n�Ǘ����_�R�[�h</summary>
        private string _sectionCodeSt = "";

        /// <summary>�I���Ǘ����_�R�[�h</summary>
        private string _sectionCodeEd = "";
        //-----ADD 2011/01/11-----<<<<<

		/// <summary>�I�������������t</summary>
		private DateTime _inventoryPreprDay;

		/// <summary>�I��������������</summary>
		private Int32 _inventoryPreprTim;

		/// <summary>�I�������敪</summary>
		private Int32 _inventoryProcDiv;

		/// <summary>�I����</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _inventoryDate;

		/// <summary>�q�Ɏw��敪</summary>
		/// <remarks>0:�͈�,1:�P��</remarks>
		private Int32 _warehouseDiv;

		/// <summary>�q�ɃR�[�h�J�n</summary>
		private string _stWarehouseCd = "";

		/// <summary>�q�ɃR�[�h�I��</summary>
		private string _edWarehouseCd = "";

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

		/// <summary>�I�ԊJ�n</summary>
		private string _stWarehouseShelfNo = "";

		/// <summary>�I�ԏI��</summary>
		private string _edWarehouseShelfNo = "";

		/// <summary>���[�J�[�R�[�h�J�n</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _stMakerCd;

		/// <summary>���[�J�[�R�[�h�I��</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _edMakerCd;

		/// <summary>�a�k���i�R�[�h�J�n</summary>
		private Int32 _stBLGoodsCd;

		/// <summary>�a�k���i�R�[�h�I��</summary>
		private Int32 _edBLGoodsCd;

		/// <summary>�O���[�v�R�[�h�J�n</summary>
		private Int32 _stBLGroupCode;

		/// <summary>�O���[�v�R�[�h�I��</summary>
		private Int32 _edBLGroupCode;

		/// <summary>���Ӑ�R�[�h�J�n</summary>
		/// <remarks>���d����R�[�h�Ƃ��Ďg�p</remarks>
		private Int32 _stCustomerCd;

		/// <summary>���Ӑ�R�[�h�I��</summary>
		/// <remarks>���d����R�[�h�Ƃ��Ďg�p</remarks>
		private Int32 _edCustomerCd;

		/// <summary>�ŏI�I���X�V���J�n</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stLtInventoryUpdate;

		/// <summary>�ŏI�I���X�V���I��</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _edLtInventoryUpdate;

		/// <summary>�݌ɕ]�����@</summary>
		/// <remarks>1:�ŏI�d�������@,2:�ړ����ϖ@,3:�ʒP���@</remarks>
		private Int32 _stockPointWay;

        // --- ADD 2009/11/30 ---------->>>>>
        /// <summary>�I������������ݒ�敪</summary>
        /// <remarks>0:�I�ԏ�,1:�d���揇,2:BL���ޏ�,3:��ٰ�ߺ��ޏ�,4:Ұ����,5:�d���楒I�ԏ�,6:�d����Ұ����</remarks>
        private Int32 _invntryPrtOdrIniDiv;

        /// <summary>�I���^�p�敪</summary>
        /// <remarks>0�F�o�l�D�m�r�@1�F�o�l�V</remarks>
        private Int32 _inventoryMngDiv;
        // --- ADD 2009/11/30 ----------<<<<<


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>���_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���_�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

        //-----ADD 2011/01/11----->>>>>
        /// public propaty name  :  SectionCodeSt
        /// <summary>�J�n�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>�I���Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }
        //-----ADD 2011/01/11-----<<<<<

		/// public propaty name  :  InventoryPreprDay
		/// <summary>�I�������������t�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������������t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InventoryPreprDay
		{
			get{return _inventoryPreprDay;}
			set{_inventoryPreprDay = value;}
		}

		/// public propaty name  :  InventoryPreprTim
		/// <summary>�I�������������ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������������ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InventoryPreprTim
		{
			get{return _inventoryPreprTim;}
			set{_inventoryPreprTim = value;}
		}

		/// public propaty name  :  InventoryProcDiv
		/// <summary>�I�������敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InventoryProcDiv
		{
			get{return _inventoryProcDiv;}
			set{_inventoryProcDiv = value;}
		}

		/// public propaty name  :  InventoryDate
		/// <summary>�I�����v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime InventoryDate
		{
			get{return _inventoryDate;}
			set{_inventoryDate = value;}
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
			get{return _warehouseDiv;}
			set{_warehouseDiv = value;}
		}

		/// public propaty name  :  StWarehouseCd
		/// <summary>�q�ɃR�[�h�J�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StWarehouseCd
		{
			get{return _stWarehouseCd;}
			set{_stWarehouseCd = value;}
		}

		/// public propaty name  :  EdWarehouseCd
		/// <summary>�q�ɃR�[�h�I���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EdWarehouseCd
		{
			get{return _edWarehouseCd;}
			set{_edWarehouseCd = value;}
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
			get{return _warehouseCd01;}
			set{_warehouseCd01 = value;}
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
			get{return _warehouseCd02;}
			set{_warehouseCd02 = value;}
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
			get{return _warehouseCd03;}
			set{_warehouseCd03 = value;}
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
			get{return _warehouseCd04;}
			set{_warehouseCd04 = value;}
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
			get{return _warehouseCd05;}
			set{_warehouseCd05 = value;}
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
			get{return _warehouseCd06;}
			set{_warehouseCd06 = value;}
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
			get{return _warehouseCd07;}
			set{_warehouseCd07 = value;}
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
			get{return _warehouseCd08;}
			set{_warehouseCd08 = value;}
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
			get{return _warehouseCd09;}
			set{_warehouseCd09 = value;}
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
			get{return _warehouseCd10;}
			set{_warehouseCd10 = value;}
		}

		/// public propaty name  :  StWarehouseShelfNo
		/// <summary>�I�ԊJ�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԊJ�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StWarehouseShelfNo
		{
			get{return _stWarehouseShelfNo;}
			set{_stWarehouseShelfNo = value;}
		}

		/// public propaty name  :  EdWarehouseShelfNo
		/// <summary>�I�ԏI���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԏI���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EdWarehouseShelfNo
		{
			get{return _edWarehouseShelfNo;}
			set{_edWarehouseShelfNo = value;}
		}

		/// public propaty name  :  StMakerCd
		/// <summary>���[�J�[�R�[�h�J�n�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StMakerCd
		{
			get{return _stMakerCd;}
			set{_stMakerCd = value;}
		}

		/// public propaty name  :  EdMakerCd
		/// <summary>���[�J�[�R�[�h�I���v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdMakerCd
		{
			get{return _edMakerCd;}
			set{_edMakerCd = value;}
		}

		/// public propaty name  :  StBLGoodsCd
		/// <summary>�a�k���i�R�[�h�J�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �a�k���i�R�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StBLGoodsCd
		{
			get{return _stBLGoodsCd;}
			set{_stBLGoodsCd = value;}
		}

		/// public propaty name  :  EdBLGoodsCd
		/// <summary>�a�k���i�R�[�h�I���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �a�k���i�R�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdBLGoodsCd
		{
			get{return _edBLGoodsCd;}
			set{_edBLGoodsCd = value;}
		}

		/// public propaty name  :  StBLGroupCode
		/// <summary>�O���[�v�R�[�h�J�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O���[�v�R�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StBLGroupCode
		{
			get{return _stBLGroupCode;}
			set{_stBLGroupCode = value;}
		}

		/// public propaty name  :  EdBLGroupCode
		/// <summary>�O���[�v�R�[�h�I���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �O���[�v�R�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdBLGroupCode
		{
			get{return _edBLGroupCode;}
			set{_edBLGroupCode = value;}
		}

		/// public propaty name  :  StCustomerCd
		/// <summary>���Ӑ�R�[�h�J�n�v���p�e�B</summary>
		/// <value>���d����R�[�h�Ƃ��Ďg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StCustomerCd
		{
			get{return _stCustomerCd;}
			set{_stCustomerCd = value;}
		}

		/// public propaty name  :  EdCustomerCd
		/// <summary>���Ӑ�R�[�h�I���v���p�e�B</summary>
		/// <value>���d����R�[�h�Ƃ��Ďg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Ӑ�R�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdCustomerCd
		{
			get{return _edCustomerCd;}
			set{_edCustomerCd = value;}
		}

		/// public propaty name  :  StLtInventoryUpdate
		/// <summary>�ŏI�I���X�V���J�n�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�I���X�V���J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime StLtInventoryUpdate
		{
			get{return _stLtInventoryUpdate;}
			set{_stLtInventoryUpdate = value;}
		}

		/// public propaty name  :  EdLtInventoryUpdate
		/// <summary>�ŏI�I���X�V���I���v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ŏI�I���X�V���I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime EdLtInventoryUpdate
		{
			get{return _edLtInventoryUpdate;}
			set{_edLtInventoryUpdate = value;}
		}

		/// public propaty name  :  StockPointWay
		/// <summary>�݌ɕ]�����@�v���p�e�B</summary>
		/// <value>1:�ŏI�d�������@,2:�ړ����ϖ@,3:�ʒP���@</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɕ]�����@�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockPointWay
		{
			get{return _stockPointWay;}
			set{_stockPointWay = value;}
		}

        // --- ADD 2009/11/30 ---------->>>>>
        /// public propaty name  :  InvntryPrtOdrIniDiv
        /// <summary>�I������������ݒ�敪�v���p�e�B</summary>
        /// <value>0:�I�ԏ�,1:�d���揇,2:BL���ޏ�,3:��ٰ�ߺ��ޏ�,4:Ұ����,5:�d���楒I�ԏ�,6:�d����Ұ����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������������ݒ�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InvntryPrtOdrIniDiv
        {
            get { return _invntryPrtOdrIniDiv; }
            set { _invntryPrtOdrIniDiv = value; }
        }

        /// public propaty name  :  InventoryMngDiv
        /// <summary>�I���^�p�敪�v���p�e�B</summary>
        /// <value>0�F�o�l�D�m�r�@1�F�o�l�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���^�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventoryMngDiv
        {
            get { return _inventoryMngDiv; }
            set { _inventoryMngDiv = value; }
        }
        // --- ADD 2009/11/30 ----------<<<<<

		/// <summary>
		/// �I���f�[�^(������������)�����������[�N�R���X�g���N�^
		/// </summary>
		/// <returns>InventoryExtCndtnWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   InventoryExtCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public InventoryExtCndtnWork()
		{
		}
    }
}
