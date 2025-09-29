using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   InventSearchCndtnUI
	/// <summary>
	///                      �I���֘A���[���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �I���֘A���[���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/09/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/02/20 ������</br>
    /// <br>			         �s��Ή�(PM1005)</br>
    /// <br>Update Note      :   2011/01/11 liyp</br>
    /// <br>			         �o�͏����ɐ��ʂƒI�ԂɊւ�������w���ǉ�����i�v�]�j</br>
    /// <br>Update Note      :   2012/11/14 ������</br>
    ///	<br>			         2013/01/16�z�M���ARedmine#33271 �󎚐���̋敪�̒ǉ�</br> 
    /// </remarks>
	public class InventSearchCndtnUI
	{
		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>���_�R�[�h</summary>
		private string _sectionCode = "";

		/// <summary>�݌ɍX�V���_����</summary>
		private string _inventorySectionName = "";

		/// <summary>���[�J�[�R�[�h�J�n</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _st_MakerCode;

		/// <summary>���[�J�[�R�[�h�I��</summary>
		/// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
		private Int32 _ed_MakerCode;

		/// <summary>���i�ԍ��J�n</summary>
		private string _st_GoodsNo = "";

		/// <summary>���i�ԍ��I��</summary>
		private string _ed_GoodsNo = "";

        ///// <summary>���i�敪�O���[�v�R�[�h�J�n</summary>
        //private string _st_LargeGoodsGanreCode = "";

        ///// <summary>���i�敪�O���[�v�R�[�h�I��</summary>
        //private string _ed_LargeGoodsGanreCode = "";

        ///// <summary>���i�敪�R�[�h�J�n</summary>
        //private string _st_MediumGoodsGanreCode = "";

        ///// <summary>���i�敪�R�[�h�I��</summary>
        //private string _ed_MediumGoodsGanreCode = "";

        ///// <summary>���i�敪�ڍ׃R�[�h�J�n</summary>
        //private string _st_DetailGoodsGanreCode = "";

        ///// <summary>���i�敪�ڍ׃R�[�h�I��</summary>
        //private string _ed_DetailGoodsGanreCode = "";

		/// <summary>�q�ɃR�[�h�J�n</summary>
		private string _st_WarehouseCode = "";

		/// <summary>�q�ɃR�[�h�I��</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>�I�ԊJ�n</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>�I�ԏI��</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>���Е��ރR�[�h�J�n</summary>
		private Int32 _st_EnterpriseGanreCode;

		/// <summary>���Е��ރR�[�h�I��</summary>
		private Int32 _ed_EnterpriseGanreCode;

		/// <summary>�a�k���i�R�[�h�J�n</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>�a�k���i�R�[�h�I��</summary>
		private Int32 _ed_BLGoodsCode;

        ///// <summary>���Ӑ�R�[�h�J�n</summary>
        //private Int32 _st_CustomerCode;

        ///// <summary>���Ӑ�R�[�h�I��</summary>
        //private Int32 _ed_CustomerCode;

        ///// <summary>�o�א擾�Ӑ�R�[�h�J�n</summary>
        //private Int32 _st_ShipCustomerCode;

        ///// <summary>�o�א擾�Ӑ�R�[�h�I��</summary>
        //private Int32 _ed_ShipCustomerCode;

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _st_SupplierCd;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _ed_SupplierCd;

		/// <summary>�J�n�I�������������t(Int)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InventoryPreprDay;

		/// <summary>�J�n�I�������������t(DateTime)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_InventoryPreprDayDateTime;

		/// <summary>�I���I�������������t(Int)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InventoryPreprDay;

		/// <summary>�I���I�������������t(DateTime)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ed_InventoryPreprDayDateTime;

		/// <summary>�J�n�I�����{��(Int)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InventoryDay;

		/// <summary>�J�n�I�����{��(DateTime)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_InventoryDayDateTime;

		/// <summary>�I���I�����{��(Int)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InventoryDay;

		/// <summary>�I���I�����{��(DateTime)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ed_InventoryDayDateTime;

        /// <summary>�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inventoryDate;


		/// <summary>�J�n�I���ʔ�</summary>
		private Int32 _st_InventorySeqNo;

		/// <summary>�I���I���ʔ�</summary>
		private Int32 _ed_InventorySeqNo;

        /// <summary>�J�n�O���[�v�R�[�h</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>�I���O���[�v�R�[�h</summary>
        private Int32 _ed_BLGroupCode;

		/// <summary>���ٕ����o�敪</summary>
		/// <remarks>0:�S��,1:�������͕��̂�,2:�����͕��̂�,3:���ٕ��̂�</remarks>
		private Int32 _difCntExtraDiv;

		/// <summary>�݌ɐ�0���o�敪</summary>
		/// <remarks>0:���o����,1:���o���Ȃ�</remarks>
		private Int32 _stockCntZeroExtraDiv;

		/// <summary>�I���݌ɐ�0���o�敪</summary>
		/// <remarks>0:���o����,1:���o���Ȃ�</remarks>
		private Int32 _ivtStkCntZeroExtraDiv;

		/// <summary>���[���</summary>
		/// <remarks>0:�I���L���\�A1:�I�����ٕ\�A2:�I���\</remarks>
		private Int32 _selectedPaperKind;

		/// <summary>�o�͎w��敪</summary>
		/// <remarks>0:�S��,1:�I�������͂̂�,2:���ٕ��̂�,3:�d���I�Ԃ���̂�</remarks>
		private Int32 _outputAppointDiv;

		/// <summary>���o�Ώۓ��t�敪</summary>
		/// <remarks>0:�I������������,1:�I�����{��,2:�I���X�V��</remarks>
		private Int32 _targetDateExtraDiv;

        /// <summary>�݌ɐ��Z�o�t���O</summary>
        /// <remarks>0:�݌ɐ��Z�o���Ȃ�, 1:�݌ɐ��Z�o����</remarks>
        private Int32 _calcStockAmountDiv;

        /// <summary>�݌ɐ��Z�o���t</summary>
        /// <remarks>�݌ɐ��Z�o�t���O=1�̂Ƃ��̍݌ɐ��Z�o���t</remarks>
        private DateTime _calcStockAmountDate;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:�S��,1:����,2:���</remarks>
        private Int32 _stockDiv;

        /// <summary>�ݏo���o�敪</summary>
        /// <remarks>0:������Ȃ�,1:�������</remarks>
        private Int32 _lendExtraDiv;

        /// <summary>�����v�㒊�o�敪</summary>
        /// <remarks>0:������Ȃ�,1:�������</remarks>
        private Int32 _delayPaymentDiv;

		/// <summary>�\�[�g��</summary>
		private Int32 _sortDiv;

        ///// <summary>����݌Ɉ󎚋敪</summary>
        ///// <remarks>0:�󎚂���A1:�󎚂��Ȃ�</remarks>
        //private Int32 _stockCntPrintDiv;

        ///// <summary>���Ӑ�󎚋敪</summary>
        ///// <remarks>0:�d����,1:�ϑ���</remarks>
        //private Int32 _customerPrintDiv;

        ///// <summary>�I�������͋敪</summary>
        ///// <remarks>0:�����͈���,1:���됔�Ɠ���</remarks>
        //private Int32 _inventoryInputDiv;

		/// <summary>���y�[�W�w��敪</summary>
		/// <remarks>0:�q��,1:�����,2:���Ȃ�</remarks>
		private Int32 _turnOoverThePagesDiv;

		/// <summary>�I�ԃu���C�N�敪</summary>
		private Int32 _shelfNoBreakDiv;

        /// <summary>�I�������͋敪</summary>
        private Int32 _inventoryNonInputDiv;

        /// <summary>���v�󎚋敪</summary>
        private Int32 _subtotalPrintDiv;

        // -----------ADD 2010/02/20----------->>>>>
        /// <summary>�v�󎚋敪</summary>
        private Int32 _subtotalPrintDivTemp;
        // -----------ADD 2010/02/20-----------<<<<<

        // -----------ADD 2011/01/11----------->>>>>
        /// <summary>���ʏo�͋敪</summary>
        private Int32 _numOutputDiv;

        /// <summary>�I�ԏo�͋敪</summary>
        private Int32 _warehouseShelfOutputDiv;
        // -----------ADD 2011/01/11-----------<<<<<
        // --- ADD ������ 2012/11/14 for Redmine#33271---------->>>>>
        /// <summary>�r���󎚋敪</summary>
        private Int32 _lineMaSqOfChDiv;
        // --- ADD ������ 2012/11/14 for Redmine#33271----------<<<<<

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

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
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

		/// public propaty name  :  InventorySectionName
		/// <summary>�݌ɍX�V���_���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɍX�V���_���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string InventorySectionName
		{
			get{return _inventorySectionName;}
			set{_inventorySectionName = value;}
		}

		/// public propaty name  :  St_MakerCode
		/// <summary>���[�J�[�R�[�h�J�n�v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_MakerCode
		{
			get{return _st_MakerCode;}
			set{_st_MakerCode = value;}
		}

		/// public propaty name  :  Ed_MakerCode
		/// <summary>���[�J�[�R�[�h�I���v���p�e�B</summary>
		/// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�J�[�R�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_MakerCode
		{
			get{return _ed_MakerCode;}
			set{_ed_MakerCode = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>���i�ԍ��J�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ��J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>���i�ԍ��I���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���i�ԍ��I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

        ///// public propaty name  :  St_LargeGoodsGanreCode
        ///// <summary>���i�敪�O���[�v�R�[�h�J�n�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���i�敪�O���[�v�R�[�h�J�n�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string St_LargeGoodsGanreCode
        //{
        //    get{return _st_LargeGoodsGanreCode;}
        //    set{_st_LargeGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  Ed_LargeGoodsGanreCode
        ///// <summary>���i�敪�O���[�v�R�[�h�I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���i�敪�O���[�v�R�[�h�I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string Ed_LargeGoodsGanreCode
        //{
        //    get{return _ed_LargeGoodsGanreCode;}
        //    set{_ed_LargeGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  St_MediumGoodsGanreCode
        ///// <summary>���i�敪�R�[�h�J�n�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���i�敪�R�[�h�J�n�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string St_MediumGoodsGanreCode
        //{
        //    get{return _st_MediumGoodsGanreCode;}
        //    set{_st_MediumGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  Ed_MediumGoodsGanreCode
        ///// <summary>���i�敪�R�[�h�I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���i�敪�R�[�h�I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string Ed_MediumGoodsGanreCode
        //{
        //    get{return _ed_MediumGoodsGanreCode;}
        //    set{_ed_MediumGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  St_DetailGoodsGanreCode
        ///// <summary>���i�敪�ڍ׃R�[�h�J�n�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���i�敪�ڍ׃R�[�h�J�n�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string St_DetailGoodsGanreCode
        //{
        //    get{return _st_DetailGoodsGanreCode;}
        //    set{_st_DetailGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  Ed_DetailGoodsGanreCode
        ///// <summary>���i�敪�ڍ׃R�[�h�I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���i�敪�ڍ׃R�[�h�I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string Ed_DetailGoodsGanreCode
        //{
        //    get{return _ed_DetailGoodsGanreCode;}
        //    set{_ed_DetailGoodsGanreCode = value;}
        //}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>�q�ɃR�[�h�J�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>�q�ɃR�[�h�I���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �q�ɃR�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>�I�ԊJ�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԊJ�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>�I�ԏI���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԏI���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  St_EnterpriseGanreCode
		/// <summary>���Е��ރR�[�h�J�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Е��ރR�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_EnterpriseGanreCode
		{
			get{return _st_EnterpriseGanreCode;}
			set{_st_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  Ed_EnterpriseGanreCode
		/// <summary>���Е��ރR�[�h�I���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���Е��ރR�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_EnterpriseGanreCode
		{
			get{return _ed_EnterpriseGanreCode;}
			set{_ed_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>�a�k���i�R�[�h�J�n�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �a�k���i�R�[�h�J�n�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>�a�k���i�R�[�h�I���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �a�k���i�R�[�h�I���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
		}

        ///// public propaty name  :  St_CustomerCode
        ///// <summary>���Ӑ�R�[�h�J�n�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�R�[�h�J�n�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 St_CustomerCode
        //{
        //    get{return _st_CustomerCode;}
        //    set{_st_CustomerCode = value;}
        //}

        ///// public propaty name  :  Ed_CustomerCode
        ///// <summary>���Ӑ�R�[�h�I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�R�[�h�I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 Ed_CustomerCode
        //{
        //    get{return _ed_CustomerCode;}
        //    set{_ed_CustomerCode = value;}
        //}

        ///// public propaty name  :  St_ShipCustomerCode
        ///// <summary>�o�א擾�Ӑ�R�[�h�J�n�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �o�א擾�Ӑ�R�[�h�J�n�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 St_ShipCustomerCode
        //{
        //    get{return _st_ShipCustomerCode;}
        //    set{_st_ShipCustomerCode = value;}
        //}

        ///// public propaty name  :  Ed_ShipCustomerCode
        ///// <summary>�o�א擾�Ӑ�R�[�h�I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �o�א擾�Ӑ�R�[�h�I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 Ed_ShipCustomerCode
        //{
        //    get{return _ed_ShipCustomerCode;}
        //    set{_ed_ShipCustomerCode = value;}
        //}

        /// public propaty name  :  St_SupplierCd
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_SupplierCd; }
            set { _st_SupplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_SupplierCd; }
            set { _ed_SupplierCd = value; }
        }

		/// public propaty name  :  St_InventoryPreprDay
		/// <summary>�J�n�I�������������t(Int)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�I�������������t(Int)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_InventoryPreprDay
		{
			get{return _st_InventoryPreprDay;}
			set{_st_InventoryPreprDay = value;}
		}

		/// public propaty name  :  St_InventoryPreprDayDateTime
		/// <summary>�J�n�I�������������t(DateTime)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�I�������������t(DateTime)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_InventoryPreprDayDateTime
		{
			get{return _st_InventoryPreprDayDateTime;}
			set{_st_InventoryPreprDayDateTime = value;}
		}

		/// public propaty name  :  Ed_InventoryPreprDay
		/// <summary>�I���I�������������t(Int)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���I�������������t(Int)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_InventoryPreprDay
		{
			get{return _ed_InventoryPreprDay;}
			set{_ed_InventoryPreprDay = value;}
		}

		/// public propaty name  :  Ed_InventoryPreprDayDateTime
		/// <summary>�I���I�������������t(DateTime)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���I�������������t(DateTime)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_InventoryPreprDayDateTime
		{
			get{return _ed_InventoryPreprDayDateTime;}
			set{_ed_InventoryPreprDayDateTime = value;}
		}

		/// public propaty name  :  St_InventoryDay
		/// <summary>�J�n�I�����{��(Int)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�I�����{��(Int)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_InventoryDay
		{
			get{return _st_InventoryDay;}
			set{_st_InventoryDay = value;}
		}

		/// public propaty name  :  St_InventoryDayDateTime
		/// <summary>�J�n�I�����{��(DateTime)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�I�����{��(DateTime)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime St_InventoryDayDateTime
		{
			get{return _st_InventoryDayDateTime;}
			set{_st_InventoryDayDateTime = value;}
		}

		/// public propaty name  :  Ed_InventoryDay
		/// <summary>�I���I�����{��(Int)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���I�����{��(Int)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_InventoryDay
		{
			get{return _ed_InventoryDay;}
			set{_ed_InventoryDay = value;}
		}

		/// public propaty name  :  Ed_InventoryDayDateTime
		/// <summary>�I���I�����{��(DateTime)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���I�����{��(DateTime)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime Ed_InventoryDayDateTime
		{
			get{return _ed_InventoryDayDateTime;}
			set{_ed_InventoryDayDateTime = value;}
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
            get { return _inventoryDate; }
            set { _inventoryDate = value; }
        }

		/// public propaty name  :  St_InventorySeqNo
		/// <summary>�J�n�I���ʔԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �J�n�I���ʔԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 St_InventorySeqNo
		{
			get{return _st_InventorySeqNo;}
			set{_st_InventorySeqNo = value;}
		}

		/// public propaty name  :  Ed_InventorySeqNo
		/// <summary>�I���I���ʔԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���I���ʔԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 Ed_InventorySeqNo
		{
			get{return _ed_InventorySeqNo;}
			set{_ed_InventorySeqNo = value;}
		}

        /// public propaty name  :  St_BLGroupCode
        /// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

		/// public propaty name  :  DifCntExtraDiv
		/// <summary>���ٕ����o�敪�v���p�e�B</summary>
		/// <value>0:�S��,1:�������͕��̂�,2:�����͕��̂�,3:���ٕ��̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ٕ����o�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DifCntExtraDiv
		{
			get{return _difCntExtraDiv;}
			set{_difCntExtraDiv = value;}
		}

		/// public propaty name  :  StockCntZeroExtraDiv
		/// <summary>�݌ɐ�0���o�敪�v���p�e�B</summary>
		/// <value>0:���o����,1:���o���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɐ�0���o�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockCntZeroExtraDiv
		{
			get{return _stockCntZeroExtraDiv;}
			set{_stockCntZeroExtraDiv = value;}
		}

		/// public propaty name  :  IvtStkCntZeroExtraDiv
		/// <summary>�I���݌ɐ�0���o�敪�v���p�e�B</summary>
		/// <value>0:���o����,1:���o���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I���݌ɐ�0���o�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 IvtStkCntZeroExtraDiv
		{
			get{return _ivtStkCntZeroExtraDiv;}
			set{_ivtStkCntZeroExtraDiv = value;}
		}

		/// public propaty name  :  SelectedPaperKind
		/// <summary>���[��ʃv���p�e�B</summary>
		/// <value>0:�I���L���\�A1:�I�����ٕ\�A2:�I���\</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[��ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SelectedPaperKind
		{
			get{return _selectedPaperKind;}
			set{_selectedPaperKind = value;}
		}

		/// public propaty name  :  OutputAppointDiv
		/// <summary>�o�͎w��敪�v���p�e�B</summary>
		/// <value>0:�S��,1:�I�������͂̂�,2:���ٕ��̂�,3:�d���I�Ԃ���̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͎w��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 OutputAppointDiv
		{
			get{return _outputAppointDiv;}
			set{_outputAppointDiv = value;}
		}

		/// public propaty name  :  TargetDateExtraDiv
		/// <summary>���o�Ώۓ��t�敪�v���p�e�B</summary>
		/// <value>0:�I������������,1:�I�����{��,2:�I���X�V��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�Ώۓ��t�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TargetDateExtraDiv
		{
			get{return _targetDateExtraDiv;}
			set{_targetDateExtraDiv = value;}
		}

        /// public propaty name  :  CalcStockAmountDiv
		/// <summary>�݌ɐ��Z�o�t���O�v���p�e�B</summary>
		/// <value>0:�݌ɐ��Z�o���Ȃ�, 1:�݌ɐ��Z�o����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɐ��Z�o�t���O�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CalcStockAmountDiv
		{
			get{return _calcStockAmountDiv;}
			set{_calcStockAmountDiv = value;}
		}

		/// public propaty name  :  CalcStockAmountDate
		/// <summary>�݌ɐ��Z�o���t�v���p�e�B</summary>
		/// <value>�݌ɐ��Z�o�t���O=1�̂Ƃ��̍݌ɐ��Z�o���t</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɐ��Z�o���t�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CalcStockAmountDate
		{
			get{return _calcStockAmountDate;}
			set{_calcStockAmountDate = value;}
		}

		/// public propaty name  :  StockDiv
		/// <summary>�݌ɋ敪�v���p�e�B</summary>
		/// <value>0:�S��,1:����,2:���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �݌ɋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
		}

        /// public propaty name  :  LendExtraDiv
		/// <summary>�ݏo���o�敪�v���p�e�B</summary>
		/// <value>0:������Ȃ�,1:�������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �ݏo���o�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LendExtraDiv
		{
			get{return _lendExtraDiv;}
			set{_lendExtraDiv = value;}
		}

		/// public propaty name  :  DelayPaymentDiv
		/// <summary>�����v�㒊�o�敪�v���p�e�B</summary>
		/// <value>0:������Ȃ�,1:�������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����v�㒊�o�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DelayPaymentDiv
		{
			get{return _delayPaymentDiv;}
			set{_delayPaymentDiv = value;}
		}

		/// public propaty name  :  SortDiv
		/// <summary>�\�[�g���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�[�g���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 SortDiv
		{
			get{return _sortDiv;}
			set{_sortDiv = value;}
		}

        ///// public propaty name  :  StockCntPrintDiv
        ///// <summary>����݌Ɉ󎚋敪�v���p�e�B</summary>
        ///// <value>0:�󎚂���A1:�󎚂��Ȃ�</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ����݌Ɉ󎚋敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 StockCntPrintDiv
        //{
        //    get{return _stockCntPrintDiv;}
        //    set{_stockCntPrintDiv = value;}
        //}

        ///// public propaty name  :  CustomerPrintDiv
        ///// <summary>���Ӑ�󎚋敪�v���p�e�B</summary>
        ///// <value>0:�d����,1:�ϑ���</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Ӑ�󎚋敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 CustomerPrintDiv
        //{
        //    get{return _customerPrintDiv;}
        //    set{_customerPrintDiv = value;}
        //}

        ///// public propaty name  :  InventoryInputDiv
        ///// <summary>�I�������͋敪�v���p�e�B</summary>
        ///// <value>0:�����͈���,1:���됔�Ɠ���</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I�������͋敪�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 InventoryInputDiv
        //{
        //    get{return _inventoryInputDiv;}
        //    set{_inventoryInputDiv = value;}
        //}

		/// public propaty name  :  TurnOoverThePagesDiv
		/// <summary>���y�[�W�w��敪�v���p�e�B</summary>
		/// <value>0:�q��,1:�����,2:���Ȃ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���y�[�W�w��敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 TurnOoverThePagesDiv
		{
			get{return _turnOoverThePagesDiv;}
			set{_turnOoverThePagesDiv = value;}
		}

		/// public propaty name  :  ShelfNoBreakDiv
		/// <summary>�I�ԃu���C�N�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�ԃu���C�N�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ShelfNoBreakDiv
		{
			get{return _shelfNoBreakDiv;}
			set{_shelfNoBreakDiv = value;}
		}

        /// public propaty name  :  InventoryNonInputDiv
        /// <summary>�I�������͋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventoryNonInputDiv
        {
            get { return _inventoryNonInputDiv; }
            set { _inventoryNonInputDiv = value; }
        }

        /// public propaty name  :  SubtotalPrintDiv
        /// <summary>���v�󎚋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ���v�󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubtotalPrintDiv
        {
            get { return _subtotalPrintDiv; }
            set { _subtotalPrintDiv = value; }
        }

        /// public propaty name  :  SubtotalPrintDivTemp
        /// <summary>�v�󎚋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �v�󎚋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SubtotalPrintDivTemp
        {
            get { return _subtotalPrintDivTemp; }
            set { _subtotalPrintDivTemp = value; }
        }
        
        //--------------ADD 2011/01/11 -------------->>>>>
        /// public propaty name  :  NumOutputDiv
        /// <summary>���ʏo�͋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  ���ʏo�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NumOutputDiv
        {
            get { return _numOutputDiv; }
            set { _numOutputDiv = value; }
        }

        /// public propaty name  :  WarehouseShelfOutputDiv
        /// <summary>�I�ԏo�͋敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �I�ԏo�͋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WarehouseShelfOutputDiv
        {
            get { return _warehouseShelfOutputDiv; }
            set { _warehouseShelfOutputDiv = value; }
        }
        //--------------ADD 2011/01/11 --------------<<<<<
        // --- ADD ������ 2012/11/14 for Redmine#33271---------->>>>>
        /// public propaty name  :  LineMaSqOfChDiv
        /// <summary>�r���󎚋敪�v���p�e�B����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �r���󎚋敪�v���p�e�B����</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int LineMaSqOfChDiv
        {
            get { return _lineMaSqOfChDiv; }
            set { _lineMaSqOfChDiv = value; }
        }
        // --- ADD ������ 2012/11/14 for Redmine#33271----------<<<<<


		/// <summary>
		/// �I���֘A���[���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>InventSearchCndtnUI�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   InventSearchCndtnUI�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public InventSearchCndtnUI()
		{
		}

        ///// <summary>
        ///// �I���֘A���[���o�����N���X�R���X�g���N�^
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        ///// <param name="enterpriseName">��Ɩ���</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="inventorySectionName">�݌ɍX�V���_����</param>
        ///// <param name="st_MakerCode">���[�J�[�R�[�h�J�n(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        ///// <param name="ed_MakerCode">���[�J�[�R�[�h�I��(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        ///// <param name="st_GoodsNo">���i�ԍ��J�n</param>
        ///// <param name="ed_GoodsNo">���i�ԍ��I��</param>
        ///// <param name="st_LargeGoodsGanreCode">���i�敪�O���[�v�R�[�h�J�n</param>
        ///// <param name="ed_LargeGoodsGanreCode">���i�敪�O���[�v�R�[�h�I��</param>
        ///// <param name="st_MediumGoodsGanreCode">���i�敪�R�[�h�J�n</param>
        ///// <param name="ed_MediumGoodsGanreCode">���i�敪�R�[�h�I��</param>
        ///// <param name="st_DetailGoodsGanreCode">���i�敪�ڍ׃R�[�h�J�n</param>
        ///// <param name="ed_DetailGoodsGanreCode">���i�敪�ڍ׃R�[�h�I��</param>
        ///// <param name="st_WarehouseCode">�q�ɃR�[�h�J�n</param>
        ///// <param name="ed_WarehouseCode">�q�ɃR�[�h�I��</param>
        ///// <param name="st_WarehouseShelfNo">�I�ԊJ�n</param>
        ///// <param name="ed_WarehouseShelfNo">�I�ԏI��</param>
        ///// <param name="st_EnterpriseGanreCode">���Е��ރR�[�h�J�n</param>
        ///// <param name="ed_EnterpriseGanreCode">���Е��ރR�[�h�I��</param>
        ///// <param name="st_BLGoodsCode">�a�k���i�R�[�h�J�n</param>
        ///// <param name="ed_BLGoodsCode">�a�k���i�R�[�h�I��</param>
        ///// <param name="st_CustomerCode">���Ӑ�R�[�h�J�n</param>
        ///// <param name="ed_CustomerCode">���Ӑ�R�[�h�I��</param>
        ///// <param name="st_ShipCustomerCode">�o�א擾�Ӑ�R�[�h�J�n</param>
        ///// <param name="ed_ShipCustomerCode">�o�א擾�Ӑ�R�[�h�I��</param>
        ///// <param name="st_InventoryPreprDay">�J�n�I�������������t(Int)(YYYYMMDD)</param>
        ///// <param name="st_InventoryPreprDayDateTime">�J�n�I�������������t(DateTime)(YYYYMMDD)</param>
        ///// <param name="ed_InventoryPreprDay">�I���I�������������t(Int)(YYYYMMDD)</param>
        ///// <param name="ed_InventoryPreprDayDateTime">�I���I�������������t(DateTime)(YYYYMMDD)</param>
        ///// <param name="st_InventoryDay">�J�n�I�����{��(Int)(YYYYMMDD)</param>
        ///// <param name="st_InventoryDayDateTime">�J�n�I�����{��(DateTime)(YYYYMMDD)</param>
        ///// <param name="ed_InventoryDay">�I���I�����{��(Int)(YYYYMMDD)</param>
        ///// <param name="ed_InventoryDayDateTime">�I���I�����{��(DateTime)(YYYYMMDD)</param>
        ///// <param name="st_InventorySeqNo">�J�n�I���ʔ�</param>
        ///// <param name="ed_InventorySeqNo">�I���I���ʔ�</param>
        ///// <param name="difCntExtraDiv">���ٕ����o�敪(0:�S��,1:�������͕��̂�,2:�����͕��̂�,3:���ٕ��̂�)</param>
        ///// <param name="stockCntZeroExtraDiv">�݌ɐ�0���o�敪(0:���o����,1:���o���Ȃ�)</param>
        ///// <param name="ivtStkCntZeroExtraDiv">�I���݌ɐ�0���o�敪(0:���o����,1:���o���Ȃ�)</param>
        ///// <param name="selectedPaperKind">���[���(0:�I���L���\�A1:�I�����ٕ\�A2:�I���\)</param>
        ///// <param name="outputAppointDiv">�o�͎w��敪(0:�S��,1:�I�������͂̂�,2:���ٕ��̂�,3:�d���I�Ԃ���̂�)</param>
        ///// <param name="targetDateExtraDiv">���o�Ώۓ��t�敪(0:�I������������,1:�I�����{��,2:�I���X�V��)</param>
        ///// <param name="sortDiv">�\�[�g��</param>
        ///// <param name="stockCntPrintDiv">����݌Ɉ󎚋敪(0:�󎚂���A1:�󎚂��Ȃ�)</param>
        ///// <param name="customerPrintDiv">���Ӑ�󎚋敪(0:�d����,1:�ϑ���)</param>
        ///// <param name="inventoryInputDiv">�I�������͋敪(0:�����͈���,1:���됔�Ɠ���)</param>
        ///// <param name="turnOoverThePagesDiv">���y�[�W�w��敪(0:�q��,1:�����,2:���Ȃ�)</param>
        ///// <param name="shelfNoBreakDiv">�I�ԃu���C�N�敪</param>
        ///// <returns>InventSearchCndtnUI�N���X�̃C���X�^���X</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   InventSearchCndtnUI�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public InventSearchCndtnUI(string enterpriseCode,string enterpriseName,string sectionCode,string inventorySectionName,Int32 st_MakerCode,Int32 ed_MakerCode,string st_GoodsNo,string ed_GoodsNo,string st_LargeGoodsGanreCode,string ed_LargeGoodsGanreCode,string st_MediumGoodsGanreCode,string ed_MediumGoodsGanreCode,string st_DetailGoodsGanreCode,string ed_DetailGoodsGanreCode,string st_WarehouseCode,string ed_WarehouseCode,string st_WarehouseShelfNo,string ed_WarehouseShelfNo,Int32 st_EnterpriseGanreCode,Int32 ed_EnterpriseGanreCode,Int32 st_BLGoodsCode,Int32 ed_BLGoodsCode,Int32 st_CustomerCode,Int32 ed_CustomerCode,Int32 st_ShipCustomerCode,Int32 ed_ShipCustomerCode,Int32 st_InventoryPreprDay,DateTime st_InventoryPreprDayDateTime,Int32 ed_InventoryPreprDay,DateTime ed_InventoryPreprDayDateTime,Int32 st_InventoryDay,DateTime st_InventoryDayDateTime,Int32 ed_InventoryDay,DateTime ed_InventoryDayDateTime,Int32 st_InventorySeqNo,Int32 ed_InventorySeqNo,Int32 difCntExtraDiv,Int32 stockCntZeroExtraDiv,Int32 ivtStkCntZeroExtraDiv,Int32 selectedPaperKind,Int32 outputAppointDiv,Int32 targetDateExtraDiv,Int32 sortDiv,Int32 stockCntPrintDiv,Int32 customerPrintDiv,Int32 inventoryInputDiv,Int32 turnOoverThePagesDiv,Int32 shelfNoBreakDiv)
        //{
        //    this._enterpriseCode = enterpriseCode;
        //    this._enterpriseName = enterpriseName;
        //    this._sectionCode = sectionCode;
        //    this._inventorySectionName = inventorySectionName;
        //    this._st_MakerCode = st_MakerCode;
        //    this._ed_MakerCode = ed_MakerCode;
        //    this._st_GoodsNo = st_GoodsNo;
        //    this._ed_GoodsNo = ed_GoodsNo;
        //    this._st_LargeGoodsGanreCode = st_LargeGoodsGanreCode;
        //    this._ed_LargeGoodsGanreCode = ed_LargeGoodsGanreCode;
        //    this._st_MediumGoodsGanreCode = st_MediumGoodsGanreCode;
        //    this._ed_MediumGoodsGanreCode = ed_MediumGoodsGanreCode;
        //    this._st_DetailGoodsGanreCode = st_DetailGoodsGanreCode;
        //    this._ed_DetailGoodsGanreCode = ed_DetailGoodsGanreCode;
        //    this._st_WarehouseCode = st_WarehouseCode;
        //    this._ed_WarehouseCode = ed_WarehouseCode;
        //    this._st_WarehouseShelfNo = st_WarehouseShelfNo;
        //    this._ed_WarehouseShelfNo = ed_WarehouseShelfNo;
        //    this._st_EnterpriseGanreCode = st_EnterpriseGanreCode;
        //    this._ed_EnterpriseGanreCode = ed_EnterpriseGanreCode;
        //    this._st_BLGoodsCode = st_BLGoodsCode;
        //    this._ed_BLGoodsCode = ed_BLGoodsCode;
        //    this._st_CustomerCode = st_CustomerCode;
        //    this._ed_CustomerCode = ed_CustomerCode;
        //    this._st_ShipCustomerCode = st_ShipCustomerCode;
        //    this._ed_ShipCustomerCode = ed_ShipCustomerCode;
        //    this._st_InventoryPreprDay = st_InventoryPreprDay;
        //    this._st_InventoryPreprDayDateTime = st_InventoryPreprDayDateTime;
        //    this._ed_InventoryPreprDay = ed_InventoryPreprDay;
        //    this._ed_InventoryPreprDayDateTime = ed_InventoryPreprDayDateTime;
        //    this._st_InventoryDay = st_InventoryDay;
        //    this._st_InventoryDayDateTime = st_InventoryDayDateTime;
        //    this._ed_InventoryDay = ed_InventoryDay;
        //    this._ed_InventoryDayDateTime = ed_InventoryDayDateTime;
        //    this._st_InventorySeqNo = st_InventorySeqNo;
        //    this._ed_InventorySeqNo = ed_InventorySeqNo;
        //    this._difCntExtraDiv = difCntExtraDiv;
        //    this._stockCntZeroExtraDiv = stockCntZeroExtraDiv;
        //    this._ivtStkCntZeroExtraDiv = ivtStkCntZeroExtraDiv;
        //    this._selectedPaperKind = selectedPaperKind;
        //    this._outputAppointDiv = outputAppointDiv;
        //    this._targetDateExtraDiv = targetDateExtraDiv;
        //    this._sortDiv = sortDiv;
        //    this._stockCntPrintDiv = stockCntPrintDiv;
        //    this._customerPrintDiv = customerPrintDiv;
        //    this._inventoryInputDiv = inventoryInputDiv;
        //    this._turnOoverThePagesDiv = turnOoverThePagesDiv;
        //    this._shelfNoBreakDiv = shelfNoBreakDiv;

        //}

        ///// <summary>
        ///// �I���֘A���[���o�����N���X��������
        ///// </summary>
        ///// <returns>InventSearchCndtnUI�N���X�̃C���X�^���X</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����InventSearchCndtnUI�N���X�̃C���X�^���X��Ԃ��܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public InventSearchCndtnUI Clone()
        //{
        //    return new InventSearchCndtnUI(this._enterpriseCode,this._enterpriseName,this._sectionCode,this._inventorySectionName,this._st_MakerCode,this._ed_MakerCode,this._st_GoodsNo,this._ed_GoodsNo,this._st_LargeGoodsGanreCode,this._ed_LargeGoodsGanreCode,this._st_MediumGoodsGanreCode,this._ed_MediumGoodsGanreCode,this._st_DetailGoodsGanreCode,this._ed_DetailGoodsGanreCode,this._st_WarehouseCode,this._ed_WarehouseCode,this._st_WarehouseShelfNo,this._ed_WarehouseShelfNo,this._st_EnterpriseGanreCode,this._ed_EnterpriseGanreCode,this._st_BLGoodsCode,this._ed_BLGoodsCode,this._st_CustomerCode,this._ed_CustomerCode,this._st_ShipCustomerCode,this._ed_ShipCustomerCode,this._st_InventoryPreprDay,this._st_InventoryPreprDayDateTime,this._ed_InventoryPreprDay,this._ed_InventoryPreprDayDateTime,this._st_InventoryDay,this._st_InventoryDayDateTime,this._ed_InventoryDay,this._ed_InventoryDayDateTime,this._st_InventorySeqNo,this._ed_InventorySeqNo,this._difCntExtraDiv,this._stockCntZeroExtraDiv,this._ivtStkCntZeroExtraDiv,this._selectedPaperKind,this._outputAppointDiv,this._targetDateExtraDiv,this._sortDiv,this._stockCntPrintDiv,this._customerPrintDiv,this._inventoryInputDiv,this._turnOoverThePagesDiv,this._shelfNoBreakDiv);
        //}

        ///// <summary>
        ///// �I���֘A���[���o�����N���X��r����
        ///// </summary>
        ///// <param name="target">��r�Ώۂ�InventSearchCndtnUI�N���X�̃C���X�^���X</param>
        ///// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   InventSearchCndtnUI�N���X�̓��e����v���邩��r���܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool Equals(InventSearchCndtnUI target)
        //{
        //    return ((this.EnterpriseCode == target.EnterpriseCode)
        //         && (this.EnterpriseName == target.EnterpriseName)
        //         && (this.SectionCode == target.SectionCode)
        //         && (this.InventorySectionName == target.InventorySectionName)
        //         && (this.St_MakerCode == target.St_MakerCode)
        //         && (this.Ed_MakerCode == target.Ed_MakerCode)
        //         && (this.St_GoodsNo == target.St_GoodsNo)
        //         && (this.Ed_GoodsNo == target.Ed_GoodsNo)
        //         && (this.St_LargeGoodsGanreCode == target.St_LargeGoodsGanreCode)
        //         && (this.Ed_LargeGoodsGanreCode == target.Ed_LargeGoodsGanreCode)
        //         && (this.St_MediumGoodsGanreCode == target.St_MediumGoodsGanreCode)
        //         && (this.Ed_MediumGoodsGanreCode == target.Ed_MediumGoodsGanreCode)
        //         && (this.St_DetailGoodsGanreCode == target.St_DetailGoodsGanreCode)
        //         && (this.Ed_DetailGoodsGanreCode == target.Ed_DetailGoodsGanreCode)
        //         && (this.St_WarehouseCode == target.St_WarehouseCode)
        //         && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
        //         && (this.St_WarehouseShelfNo == target.St_WarehouseShelfNo)
        //         && (this.Ed_WarehouseShelfNo == target.Ed_WarehouseShelfNo)
        //         && (this.St_EnterpriseGanreCode == target.St_EnterpriseGanreCode)
        //         && (this.Ed_EnterpriseGanreCode == target.Ed_EnterpriseGanreCode)
        //         && (this.St_BLGoodsCode == target.St_BLGoodsCode)
        //         && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
        //         && (this.St_CustomerCode == target.St_CustomerCode)
        //         && (this.Ed_CustomerCode == target.Ed_CustomerCode)
        //         && (this.St_ShipCustomerCode == target.St_ShipCustomerCode)
        //         && (this.Ed_ShipCustomerCode == target.Ed_ShipCustomerCode)
        //         && (this.St_InventoryPreprDay == target.St_InventoryPreprDay)
        //         && (this.St_InventoryPreprDayDateTime == target.St_InventoryPreprDayDateTime)
        //         && (this.Ed_InventoryPreprDay == target.Ed_InventoryPreprDay)
        //         && (this.Ed_InventoryPreprDayDateTime == target.Ed_InventoryPreprDayDateTime)
        //         && (this.St_InventoryDay == target.St_InventoryDay)
        //         && (this.St_InventoryDayDateTime == target.St_InventoryDayDateTime)
        //         && (this.Ed_InventoryDay == target.Ed_InventoryDay)
        //         && (this.Ed_InventoryDayDateTime == target.Ed_InventoryDayDateTime)
        //         && (this.St_InventorySeqNo == target.St_InventorySeqNo)
        //         && (this.Ed_InventorySeqNo == target.Ed_InventorySeqNo)
        //         && (this.DifCntExtraDiv == target.DifCntExtraDiv)
        //         && (this.StockCntZeroExtraDiv == target.StockCntZeroExtraDiv)
        //         && (this.IvtStkCntZeroExtraDiv == target.IvtStkCntZeroExtraDiv)
        //         && (this.SelectedPaperKind == target.SelectedPaperKind)
        //         && (this.OutputAppointDiv == target.OutputAppointDiv)
        //         && (this.TargetDateExtraDiv == target.TargetDateExtraDiv)
        //         && (this.SortDiv == target.SortDiv)
        //         && (this.StockCntPrintDiv == target.StockCntPrintDiv)
        //         && (this.CustomerPrintDiv == target.CustomerPrintDiv)
        //         && (this.InventoryInputDiv == target.InventoryInputDiv)
        //         && (this.TurnOoverThePagesDiv == target.TurnOoverThePagesDiv)
        //         && (this.ShelfNoBreakDiv == target.ShelfNoBreakDiv));
        //}

        ///// <summary>
        ///// �I���֘A���[���o�����N���X��r����
        ///// </summary>
        ///// <param name="inventSearchCndtnUI1">
        /////                    ��r����InventSearchCndtnUI�N���X�̃C���X�^���X
        ///// </param>
        ///// <param name="inventSearchCndtnUI2">��r����InventSearchCndtnUI�N���X�̃C���X�^���X</param>
        ///// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   InventSearchCndtnUI�N���X�̓��e����v���邩��r���܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public static bool Equals(InventSearchCndtnUI inventSearchCndtnUI1, InventSearchCndtnUI inventSearchCndtnUI2)
        //{
        //    return ((inventSearchCndtnUI1.EnterpriseCode == inventSearchCndtnUI2.EnterpriseCode)
        //         && (inventSearchCndtnUI1.EnterpriseName == inventSearchCndtnUI2.EnterpriseName)
        //         && (inventSearchCndtnUI1.SectionCode == inventSearchCndtnUI2.SectionCode)
        //         && (inventSearchCndtnUI1.InventorySectionName == inventSearchCndtnUI2.InventorySectionName)
        //         && (inventSearchCndtnUI1.St_MakerCode == inventSearchCndtnUI2.St_MakerCode)
        //         && (inventSearchCndtnUI1.Ed_MakerCode == inventSearchCndtnUI2.Ed_MakerCode)
        //         && (inventSearchCndtnUI1.St_GoodsNo == inventSearchCndtnUI2.St_GoodsNo)
        //         && (inventSearchCndtnUI1.Ed_GoodsNo == inventSearchCndtnUI2.Ed_GoodsNo)
        //         && (inventSearchCndtnUI1.St_LargeGoodsGanreCode == inventSearchCndtnUI2.St_LargeGoodsGanreCode)
        //         && (inventSearchCndtnUI1.Ed_LargeGoodsGanreCode == inventSearchCndtnUI2.Ed_LargeGoodsGanreCode)
        //         && (inventSearchCndtnUI1.St_MediumGoodsGanreCode == inventSearchCndtnUI2.St_MediumGoodsGanreCode)
        //         && (inventSearchCndtnUI1.Ed_MediumGoodsGanreCode == inventSearchCndtnUI2.Ed_MediumGoodsGanreCode)
        //         && (inventSearchCndtnUI1.St_DetailGoodsGanreCode == inventSearchCndtnUI2.St_DetailGoodsGanreCode)
        //         && (inventSearchCndtnUI1.Ed_DetailGoodsGanreCode == inventSearchCndtnUI2.Ed_DetailGoodsGanreCode)
        //         && (inventSearchCndtnUI1.St_WarehouseCode == inventSearchCndtnUI2.St_WarehouseCode)
        //         && (inventSearchCndtnUI1.Ed_WarehouseCode == inventSearchCndtnUI2.Ed_WarehouseCode)
        //         && (inventSearchCndtnUI1.St_WarehouseShelfNo == inventSearchCndtnUI2.St_WarehouseShelfNo)
        //         && (inventSearchCndtnUI1.Ed_WarehouseShelfNo == inventSearchCndtnUI2.Ed_WarehouseShelfNo)
        //         && (inventSearchCndtnUI1.St_EnterpriseGanreCode == inventSearchCndtnUI2.St_EnterpriseGanreCode)
        //         && (inventSearchCndtnUI1.Ed_EnterpriseGanreCode == inventSearchCndtnUI2.Ed_EnterpriseGanreCode)
        //         && (inventSearchCndtnUI1.St_BLGoodsCode == inventSearchCndtnUI2.St_BLGoodsCode)
        //         && (inventSearchCndtnUI1.Ed_BLGoodsCode == inventSearchCndtnUI2.Ed_BLGoodsCode)
        //         && (inventSearchCndtnUI1.St_CustomerCode == inventSearchCndtnUI2.St_CustomerCode)
        //         && (inventSearchCndtnUI1.Ed_CustomerCode == inventSearchCndtnUI2.Ed_CustomerCode)
        //         && (inventSearchCndtnUI1.St_ShipCustomerCode == inventSearchCndtnUI2.St_ShipCustomerCode)
        //         && (inventSearchCndtnUI1.Ed_ShipCustomerCode == inventSearchCndtnUI2.Ed_ShipCustomerCode)
        //         && (inventSearchCndtnUI1.St_InventoryPreprDay == inventSearchCndtnUI2.St_InventoryPreprDay)
        //         && (inventSearchCndtnUI1.St_InventoryPreprDayDateTime == inventSearchCndtnUI2.St_InventoryPreprDayDateTime)
        //         && (inventSearchCndtnUI1.Ed_InventoryPreprDay == inventSearchCndtnUI2.Ed_InventoryPreprDay)
        //         && (inventSearchCndtnUI1.Ed_InventoryPreprDayDateTime == inventSearchCndtnUI2.Ed_InventoryPreprDayDateTime)
        //         && (inventSearchCndtnUI1.St_InventoryDay == inventSearchCndtnUI2.St_InventoryDay)
        //         && (inventSearchCndtnUI1.St_InventoryDayDateTime == inventSearchCndtnUI2.St_InventoryDayDateTime)
        //         && (inventSearchCndtnUI1.Ed_InventoryDay == inventSearchCndtnUI2.Ed_InventoryDay)
        //         && (inventSearchCndtnUI1.Ed_InventoryDayDateTime == inventSearchCndtnUI2.Ed_InventoryDayDateTime)
        //         && (inventSearchCndtnUI1.St_InventorySeqNo == inventSearchCndtnUI2.St_InventorySeqNo)
        //         && (inventSearchCndtnUI1.Ed_InventorySeqNo == inventSearchCndtnUI2.Ed_InventorySeqNo)
        //         && (inventSearchCndtnUI1.DifCntExtraDiv == inventSearchCndtnUI2.DifCntExtraDiv)
        //         && (inventSearchCndtnUI1.StockCntZeroExtraDiv == inventSearchCndtnUI2.StockCntZeroExtraDiv)
        //         && (inventSearchCndtnUI1.IvtStkCntZeroExtraDiv == inventSearchCndtnUI2.IvtStkCntZeroExtraDiv)
        //         && (inventSearchCndtnUI1.SelectedPaperKind == inventSearchCndtnUI2.SelectedPaperKind)
        //         && (inventSearchCndtnUI1.OutputAppointDiv == inventSearchCndtnUI2.OutputAppointDiv)
        //         && (inventSearchCndtnUI1.TargetDateExtraDiv == inventSearchCndtnUI2.TargetDateExtraDiv)
        //         && (inventSearchCndtnUI1.SortDiv == inventSearchCndtnUI2.SortDiv)
        //         && (inventSearchCndtnUI1.StockCntPrintDiv == inventSearchCndtnUI2.StockCntPrintDiv)
        //         && (inventSearchCndtnUI1.CustomerPrintDiv == inventSearchCndtnUI2.CustomerPrintDiv)
        //         && (inventSearchCndtnUI1.InventoryInputDiv == inventSearchCndtnUI2.InventoryInputDiv)
        //         && (inventSearchCndtnUI1.TurnOoverThePagesDiv == inventSearchCndtnUI2.TurnOoverThePagesDiv)
        //         && (inventSearchCndtnUI1.ShelfNoBreakDiv == inventSearchCndtnUI2.ShelfNoBreakDiv));
        //}
        ///// <summary>
        ///// �I���֘A���[���o�����N���X��r����
        ///// </summary>
        ///// <param name="target">��r�Ώۂ�InventSearchCndtnUI�N���X�̃C���X�^���X</param>
        ///// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   InventSearchCndtnUI�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public ArrayList Compare(InventSearchCndtnUI target)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
        //    if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
        //    if(this.InventorySectionName != target.InventorySectionName)resList.Add("InventorySectionName");
        //    if(this.St_MakerCode != target.St_MakerCode)resList.Add("St_MakerCode");
        //    if(this.Ed_MakerCode != target.Ed_MakerCode)resList.Add("Ed_MakerCode");
        //    if(this.St_GoodsNo != target.St_GoodsNo)resList.Add("St_GoodsNo");
        //    if(this.Ed_GoodsNo != target.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
        //    if(this.St_LargeGoodsGanreCode != target.St_LargeGoodsGanreCode)resList.Add("St_LargeGoodsGanreCode");
        //    if(this.Ed_LargeGoodsGanreCode != target.Ed_LargeGoodsGanreCode)resList.Add("Ed_LargeGoodsGanreCode");
        //    if(this.St_MediumGoodsGanreCode != target.St_MediumGoodsGanreCode)resList.Add("St_MediumGoodsGanreCode");
        //    if(this.Ed_MediumGoodsGanreCode != target.Ed_MediumGoodsGanreCode)resList.Add("Ed_MediumGoodsGanreCode");
        //    if(this.St_DetailGoodsGanreCode != target.St_DetailGoodsGanreCode)resList.Add("St_DetailGoodsGanreCode");
        //    if(this.Ed_DetailGoodsGanreCode != target.Ed_DetailGoodsGanreCode)resList.Add("Ed_DetailGoodsGanreCode");
        //    if(this.St_WarehouseCode != target.St_WarehouseCode)resList.Add("St_WarehouseCode");
        //    if(this.Ed_WarehouseCode != target.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
        //    if(this.St_WarehouseShelfNo != target.St_WarehouseShelfNo)resList.Add("St_WarehouseShelfNo");
        //    if(this.Ed_WarehouseShelfNo != target.Ed_WarehouseShelfNo)resList.Add("Ed_WarehouseShelfNo");
        //    if(this.St_EnterpriseGanreCode != target.St_EnterpriseGanreCode)resList.Add("St_EnterpriseGanreCode");
        //    if(this.Ed_EnterpriseGanreCode != target.Ed_EnterpriseGanreCode)resList.Add("Ed_EnterpriseGanreCode");
        //    if(this.St_BLGoodsCode != target.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
        //    if(this.Ed_BLGoodsCode != target.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
        //    if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
        //    if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
        //    if(this.St_ShipCustomerCode != target.St_ShipCustomerCode)resList.Add("St_ShipCustomerCode");
        //    if(this.Ed_ShipCustomerCode != target.Ed_ShipCustomerCode)resList.Add("Ed_ShipCustomerCode");
        //    if(this.St_InventoryPreprDay != target.St_InventoryPreprDay)resList.Add("St_InventoryPreprDay");
        //    if(this.St_InventoryPreprDayDateTime != target.St_InventoryPreprDayDateTime)resList.Add("St_InventoryPreprDayDateTime");
        //    if(this.Ed_InventoryPreprDay != target.Ed_InventoryPreprDay)resList.Add("Ed_InventoryPreprDay");
        //    if(this.Ed_InventoryPreprDayDateTime != target.Ed_InventoryPreprDayDateTime)resList.Add("Ed_InventoryPreprDayDateTime");
        //    if(this.St_InventoryDay != target.St_InventoryDay)resList.Add("St_InventoryDay");
        //    if(this.St_InventoryDayDateTime != target.St_InventoryDayDateTime)resList.Add("St_InventoryDayDateTime");
        //    if(this.Ed_InventoryDay != target.Ed_InventoryDay)resList.Add("Ed_InventoryDay");
        //    if(this.Ed_InventoryDayDateTime != target.Ed_InventoryDayDateTime)resList.Add("Ed_InventoryDayDateTime");
        //    if(this.St_InventorySeqNo != target.St_InventorySeqNo)resList.Add("St_InventorySeqNo");
        //    if(this.Ed_InventorySeqNo != target.Ed_InventorySeqNo)resList.Add("Ed_InventorySeqNo");
        //    if(this.DifCntExtraDiv != target.DifCntExtraDiv)resList.Add("DifCntExtraDiv");
        //    if(this.StockCntZeroExtraDiv != target.StockCntZeroExtraDiv)resList.Add("StockCntZeroExtraDiv");
        //    if(this.IvtStkCntZeroExtraDiv != target.IvtStkCntZeroExtraDiv)resList.Add("IvtStkCntZeroExtraDiv");
        //    if(this.SelectedPaperKind != target.SelectedPaperKind)resList.Add("SelectedPaperKind");
        //    if(this.OutputAppointDiv != target.OutputAppointDiv)resList.Add("OutputAppointDiv");
        //    if(this.TargetDateExtraDiv != target.TargetDateExtraDiv)resList.Add("TargetDateExtraDiv");
        //    if(this.SortDiv != target.SortDiv)resList.Add("SortDiv");
        //    if(this.StockCntPrintDiv != target.StockCntPrintDiv)resList.Add("StockCntPrintDiv");
        //    if(this.CustomerPrintDiv != target.CustomerPrintDiv)resList.Add("CustomerPrintDiv");
        //    if(this.InventoryInputDiv != target.InventoryInputDiv)resList.Add("InventoryInputDiv");
        //    if(this.TurnOoverThePagesDiv != target.TurnOoverThePagesDiv)resList.Add("TurnOoverThePagesDiv");
        //    if(this.ShelfNoBreakDiv != target.ShelfNoBreakDiv)resList.Add("ShelfNoBreakDiv");

        //    return resList;
        //}

        ///// <summary>
        ///// �I���֘A���[���o�����N���X��r����
        ///// </summary>
        ///// <param name="inventSearchCndtnUI1">��r����InventSearchCndtnUI�N���X�̃C���X�^���X</param>
        ///// <param name="inventSearchCndtnUI2">��r����InventSearchCndtnUI�N���X�̃C���X�^���X</param>
        ///// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   InventSearchCndtnUI�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public static ArrayList Compare(InventSearchCndtnUI inventSearchCndtnUI1, InventSearchCndtnUI inventSearchCndtnUI2)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(inventSearchCndtnUI1.EnterpriseCode != inventSearchCndtnUI2.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(inventSearchCndtnUI1.EnterpriseName != inventSearchCndtnUI2.EnterpriseName)resList.Add("EnterpriseName");
        //    if(inventSearchCndtnUI1.SectionCode != inventSearchCndtnUI2.SectionCode)resList.Add("SectionCode");
        //    if(inventSearchCndtnUI1.InventorySectionName != inventSearchCndtnUI2.InventorySectionName)resList.Add("InventorySectionName");
        //    if(inventSearchCndtnUI1.St_MakerCode != inventSearchCndtnUI2.St_MakerCode)resList.Add("St_MakerCode");
        //    if(inventSearchCndtnUI1.Ed_MakerCode != inventSearchCndtnUI2.Ed_MakerCode)resList.Add("Ed_MakerCode");
        //    if(inventSearchCndtnUI1.St_GoodsNo != inventSearchCndtnUI2.St_GoodsNo)resList.Add("St_GoodsNo");
        //    if(inventSearchCndtnUI1.Ed_GoodsNo != inventSearchCndtnUI2.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
        //    if(inventSearchCndtnUI1.St_LargeGoodsGanreCode != inventSearchCndtnUI2.St_LargeGoodsGanreCode)resList.Add("St_LargeGoodsGanreCode");
        //    if(inventSearchCndtnUI1.Ed_LargeGoodsGanreCode != inventSearchCndtnUI2.Ed_LargeGoodsGanreCode)resList.Add("Ed_LargeGoodsGanreCode");
        //    if(inventSearchCndtnUI1.St_MediumGoodsGanreCode != inventSearchCndtnUI2.St_MediumGoodsGanreCode)resList.Add("St_MediumGoodsGanreCode");
        //    if(inventSearchCndtnUI1.Ed_MediumGoodsGanreCode != inventSearchCndtnUI2.Ed_MediumGoodsGanreCode)resList.Add("Ed_MediumGoodsGanreCode");
        //    if(inventSearchCndtnUI1.St_DetailGoodsGanreCode != inventSearchCndtnUI2.St_DetailGoodsGanreCode)resList.Add("St_DetailGoodsGanreCode");
        //    if(inventSearchCndtnUI1.Ed_DetailGoodsGanreCode != inventSearchCndtnUI2.Ed_DetailGoodsGanreCode)resList.Add("Ed_DetailGoodsGanreCode");
        //    if(inventSearchCndtnUI1.St_WarehouseCode != inventSearchCndtnUI2.St_WarehouseCode)resList.Add("St_WarehouseCode");
        //    if(inventSearchCndtnUI1.Ed_WarehouseCode != inventSearchCndtnUI2.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
        //    if(inventSearchCndtnUI1.St_WarehouseShelfNo != inventSearchCndtnUI2.St_WarehouseShelfNo)resList.Add("St_WarehouseShelfNo");
        //    if(inventSearchCndtnUI1.Ed_WarehouseShelfNo != inventSearchCndtnUI2.Ed_WarehouseShelfNo)resList.Add("Ed_WarehouseShelfNo");
        //    if(inventSearchCndtnUI1.St_EnterpriseGanreCode != inventSearchCndtnUI2.St_EnterpriseGanreCode)resList.Add("St_EnterpriseGanreCode");
        //    if(inventSearchCndtnUI1.Ed_EnterpriseGanreCode != inventSearchCndtnUI2.Ed_EnterpriseGanreCode)resList.Add("Ed_EnterpriseGanreCode");
        //    if(inventSearchCndtnUI1.St_BLGoodsCode != inventSearchCndtnUI2.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
        //    if(inventSearchCndtnUI1.Ed_BLGoodsCode != inventSearchCndtnUI2.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
        //    if(inventSearchCndtnUI1.St_CustomerCode != inventSearchCndtnUI2.St_CustomerCode)resList.Add("St_CustomerCode");
        //    if(inventSearchCndtnUI1.Ed_CustomerCode != inventSearchCndtnUI2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
        //    if(inventSearchCndtnUI1.St_ShipCustomerCode != inventSearchCndtnUI2.St_ShipCustomerCode)resList.Add("St_ShipCustomerCode");
        //    if(inventSearchCndtnUI1.Ed_ShipCustomerCode != inventSearchCndtnUI2.Ed_ShipCustomerCode)resList.Add("Ed_ShipCustomerCode");
        //    if(inventSearchCndtnUI1.St_InventoryPreprDay != inventSearchCndtnUI2.St_InventoryPreprDay)resList.Add("St_InventoryPreprDay");
        //    if(inventSearchCndtnUI1.St_InventoryPreprDayDateTime != inventSearchCndtnUI2.St_InventoryPreprDayDateTime)resList.Add("St_InventoryPreprDayDateTime");
        //    if(inventSearchCndtnUI1.Ed_InventoryPreprDay != inventSearchCndtnUI2.Ed_InventoryPreprDay)resList.Add("Ed_InventoryPreprDay");
        //    if(inventSearchCndtnUI1.Ed_InventoryPreprDayDateTime != inventSearchCndtnUI2.Ed_InventoryPreprDayDateTime)resList.Add("Ed_InventoryPreprDayDateTime");
        //    if(inventSearchCndtnUI1.St_InventoryDay != inventSearchCndtnUI2.St_InventoryDay)resList.Add("St_InventoryDay");
        //    if(inventSearchCndtnUI1.St_InventoryDayDateTime != inventSearchCndtnUI2.St_InventoryDayDateTime)resList.Add("St_InventoryDayDateTime");
        //    if(inventSearchCndtnUI1.Ed_InventoryDay != inventSearchCndtnUI2.Ed_InventoryDay)resList.Add("Ed_InventoryDay");
        //    if(inventSearchCndtnUI1.Ed_InventoryDayDateTime != inventSearchCndtnUI2.Ed_InventoryDayDateTime)resList.Add("Ed_InventoryDayDateTime");
        //    if(inventSearchCndtnUI1.St_InventorySeqNo != inventSearchCndtnUI2.St_InventorySeqNo)resList.Add("St_InventorySeqNo");
        //    if(inventSearchCndtnUI1.Ed_InventorySeqNo != inventSearchCndtnUI2.Ed_InventorySeqNo)resList.Add("Ed_InventorySeqNo");
        //    if(inventSearchCndtnUI1.DifCntExtraDiv != inventSearchCndtnUI2.DifCntExtraDiv)resList.Add("DifCntExtraDiv");
        //    if(inventSearchCndtnUI1.StockCntZeroExtraDiv != inventSearchCndtnUI2.StockCntZeroExtraDiv)resList.Add("StockCntZeroExtraDiv");
        //    if(inventSearchCndtnUI1.IvtStkCntZeroExtraDiv != inventSearchCndtnUI2.IvtStkCntZeroExtraDiv)resList.Add("IvtStkCntZeroExtraDiv");
        //    if(inventSearchCndtnUI1.SelectedPaperKind != inventSearchCndtnUI2.SelectedPaperKind)resList.Add("SelectedPaperKind");
        //    if(inventSearchCndtnUI1.OutputAppointDiv != inventSearchCndtnUI2.OutputAppointDiv)resList.Add("OutputAppointDiv");
        //    if(inventSearchCndtnUI1.TargetDateExtraDiv != inventSearchCndtnUI2.TargetDateExtraDiv)resList.Add("TargetDateExtraDiv");
        //    if(inventSearchCndtnUI1.SortDiv != inventSearchCndtnUI2.SortDiv)resList.Add("SortDiv");
        //    if(inventSearchCndtnUI1.StockCntPrintDiv != inventSearchCndtnUI2.StockCntPrintDiv)resList.Add("StockCntPrintDiv");
        //    if(inventSearchCndtnUI1.CustomerPrintDiv != inventSearchCndtnUI2.CustomerPrintDiv)resList.Add("CustomerPrintDiv");
        //    if(inventSearchCndtnUI1.InventoryInputDiv != inventSearchCndtnUI2.InventoryInputDiv)resList.Add("InventoryInputDiv");
        //    if(inventSearchCndtnUI1.TurnOoverThePagesDiv != inventSearchCndtnUI2.TurnOoverThePagesDiv)resList.Add("TurnOoverThePagesDiv");
        //    if(inventSearchCndtnUI1.ShelfNoBreakDiv != inventSearchCndtnUI2.ShelfNoBreakDiv)resList.Add("ShelfNoBreakDiv");

        //    return resList;
        //}


        #region �R�[�h�擾

        public enum SortOrder
        {
            // 2008.10.31 30413 ���� �\�[�g���̏C�� >>>>>>START
            // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
            ///// <summary>�q�Ɂ����i</summary>
            //Warehouce_Goods = 0,
            ///// <summary>�q�Ɂ��d���恨���i</summary>
            //Warehouce_Customer_Goods = 1,
            ///// <summary>�q�Ɂ��ϑ��恨���i</summary>
            //Warehouce_ShipCustomer_Goods = 2,
            ///// <summary>�q�Ɂ����Ǝҁ����i</summary>
            //Warehouce_CarrierEp_Goods = 3,
            ///// <summary>�ʔ�</summary>
            //SequenceNumber = 4
            // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
            ///// <summary>�q�Ɂ��I��</summary>
            //Warehouce_ShelfNo = 0,
            ///// <summary>�q�Ɂ��d����</summary>
            //Warehouce_Customer = 1,
            ///// <summary>�q�Ɂ��a�k�R�[�h</summary>
            //Warehouce_BLCode = 2,
            ///// <summary>�q�Ɂ����[�J�[</summary>
            //Warehouce_Maker = 3,
            ///// <summary>�q�Ɂ��d���恨�I��</summary>
            //Warehouce_Customer_ShelfNo = 4,
            ///// <summary>�q�Ɂ��d���恨���[�J�[</summary>
            //Warehouce_Customer_Maker = 5,
            ///// <summary>�q�Ɂ��I�ԁ����[�J�[�����i�敪�����i</summary>
            //Warehouce_ShelfNo_GoodsDiv = 0,
            ///// <summary>�q�Ɂ��I�ԁ����[�J�[�����i</summary>
            //Warehouce_ShelfNo = 1,
            ///// <summary>�q�Ɂ��d����</summary>
            //Warehouce_Customer = 2,
            ///// <summary>�q�Ɂ��a�k�R�[�h</summary>
            //Warehouce_BLCode = 3,
            ///// <summary>�q�Ɂ����[�J�[</summary>
            //Warehouce_Maker = 4,
            ///// <summary>�q�Ɂ��d���恨�I��</summary>
            //Warehouce_Customer_ShelfNo = 5,
            ///// <summary>�q�Ɂ��d���恨���[�J�[</summary>
            //Warehouce_Customer_Maker = 6,
            // 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
            // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<

            /// <summary>�I�ԏ�</summary>
            ShelfNo = 0,
            /// <summary>�d���揇</summary>
            Supplier = 1,
            /// <summary>�a�k�R�[�h</summary>
            BLCode = 2,
            /// <summary>�O���[�v�R�[�h��</summary>
            GroupCode = 3,
            /// <summary>���[�J�[��</summary>
            Maker = 4,
            /// <summary>�d����E�I�ԏ�</summary>
            Supplier_ShelfNo = 5,
            /// <summary>�d����E���[�J�[��</summary>
            Supplier_Maker = 6,
            // 2008.10.31 30413 ���� �\�[�g���̏C�� <<<<<<END
            
        }

        public enum StockStateDiv
        {
            /// <summary>����</summary>
            MyStock = 0,
            /// <summary>���</summary>
            TrustStock = 1,
        }

        public enum StockState
        {
            /// <summary>�݌�</summary>
            Stock = 0,
            /// <summary>�����</summary>
            Trust = 10,
            /// <summary>�ϑ���</summary>
            EnTrust = 20,
        }

        public enum StockUiDiv
        {
            /// <summary>����</summary>
            UiStock = 0,
            /// <summary>���</summary>
            UiTrust = 1,
            /// <summary>�ϑ�(����)</summary>
            UiEnTrustStock = 2,
            /// <summary>�ϑ�(���)</summary>
            UiEnTrustTrust = 3,
        }

        #endregion

        #region ���̎擾

        /// <summary>
		/// �\�[�g���̎擾����
		/// </summary>
		/// <param name="targetSortTitleState">�\�[�g���̃X�e�[�^�X</param>
		/// <returns>�\�[�g����</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2007.09.14 980035 ���� ��`</br>
        /// <br>			 �EDC.NS�Ή�</br>
        /// </remarks>
		public static string GetTargetSortTitle( int targetSortTitleState )
		{
			string SortTitle = "";
			switch( targetSortTitleState ) {
                // 2008.10.31 30413 ���� �\�[�g���̂̏C�� >>>>>>START
                // 2007.09.14 �C�� >>>>>>>>>>>>>>>>>>>>
				//case ( int )SortOrder.SequenceNumber:
				//{
				//	SortTitle = "�ʔ�";
				//	break;
				//}
                //case ( int )SortOrder.Warehouce_Goods:
                //{
                //	SortTitle = "�q�Ɂ����i";
                //	break;
                //}
                //case ( int )SortOrder.Warehouce_Customer_Goods:
                //{
                //	SortTitle = "�q�Ɂ��d���恨���i";
                //	break;
                //}
                //case ( int )SortOrder.Warehouce_ShipCustomer_Goods:
                //{
                //    SortTitle = "�q�Ɂ��ϑ��恨���i";
                //    break;
                //}
                //case ( int )SortOrder.Warehouce_CarrierEp_Goods:
                //{
                //    SortTitle = "�q�Ɂ����Ǝҁ����i";
                //    break;
                //}
                // 2008.02.13 �C�� >>>>>>>>>>>>>>>>>>>>
                //case (int)SortOrder.Warehouce_ShelfNo:
                //{
                //    SortTitle = "�q�Ɂ��I��";
                //    break;
                //}
                //case (int)SortOrder.ShelfNo:
                //{
                //    SortTitle = "�q�Ɂ��I�ԁ����[�J�[�����i�敪�����i";
                //    break;
                //}
                //case (int)SortOrder.Supplier:
                //{
                //    SortTitle = "�q�Ɂ��I�ԁ����[�J�[�����i";
                //    break;
                //}
                //// 2008.02.13 �C�� <<<<<<<<<<<<<<<<<<<<
                //case (int)SortOrder.BLCode:
                //{
                //    SortTitle = "�q�Ɂ��d����";
                //    break;
                //}
                //case (int)SortOrder.GroupCode:
                //{
                //    SortTitle = "�q�Ɂ��a�k�R�[�h";
                //    break;
                //}
                //case (int)SortOrder.Maker:
                //{
                //    SortTitle = "�q�Ɂ����[�J�[";
                //    break;
                //}
                //case (int)SortOrder.Supplier_ShelfNo:
                //{
                //    SortTitle = "�q�Ɂ��d���恨�I��";
                //    break;
                //}
                //case (int)SortOrder.Supplier_Maker:
                //{
                //    SortTitle = "�q�Ɂ��d���恨���[�J�[";
                //    break;
                //}
            // 2007.09.14 �C�� <<<<<<<<<<<<<<<<<<<<

            case (int)SortOrder.ShelfNo:
                {
                    SortTitle = "�I��";
                    break;
                }
            case (int)SortOrder.Supplier:
                {
                    SortTitle = "�d����";
                    break;
                }
            case (int)SortOrder.BLCode:
                {
                    SortTitle = "�a�k�R�[�h";
                    break;
                }
            case (int)SortOrder.GroupCode:
                {
                    SortTitle = "�O���[�v�R�[�h";
                    break;
                }
            case (int)SortOrder.Maker:
                {
                    SortTitle = "���[�J�[";
                    break;
                }
            case (int)SortOrder.Supplier_ShelfNo:
                {
                    SortTitle = "�d����E�I��";
                    break;
                }
            case (int)SortOrder.Supplier_Maker:
                {
                    SortTitle = "�d����E���[�J�[";
                    break;
                }
            // 2008.10.31 30413 ���� �\�[�g���̂̏C�� >>>>>>START
            }
			return SortTitle;
		}

        /// <summary>
		/// �݌ɋ敪���̎擾����
		/// </summary>
		/// <param name="targetStockDiv">�݌ɋ敪�X�e�[�^�X</param>
        /// <param name="targetStockState">�݌ɏ�ԃX�e�[�^�X</param>
		/// <returns>�݌ɋ敪����</returns>
		/// <remarks>
		/// <br>Note       : �݌ɋ敪���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.20</br>
		/// </remarks>
		public static string GetTargetStockDivName( int targetStockDiv,int targetStockState )
		{
			string stockDivName = "";

			 switch(targetStockDiv)
            {
                //����
                case (int)StockStateDiv.MyStock:
                {
                    switch(targetStockState)
                    {
                        //�݌�
                        case (int)StockState.Stock:
                        {
                            stockDivName = "����";
                            break;
                        }
                        //�ϑ���
                        case (int)StockState.EnTrust:
                        {
                            stockDivName = "�ϑ�(����)";
                            break;
                        }
                    }
                    break;
                }
                //���
                case (int)StockStateDiv.TrustStock:
                {
                    switch(targetStockState)
                    {
                        //�����
                        case (int)StockState.Trust:
                        {
                            stockDivName = "���";
                            break;
                        }
                        //�ϑ���
                        case (int)StockState.EnTrust:
                        {
                            stockDivName = "�ϑ�(���)";
                            break;
                        }
                    }
                    break;
                }
            }
			return stockDivName;
		}

        /// <summary>
		/// �݌ɋ敪UI�A�Ԏ擾����
		/// </summary>
		/// <param name="targetStockDiv">�݌ɋ敪�X�e�[�^�X</param>
        /// <param name="targetStockState">�݌ɏ�ԃX�e�[�^�X</param>
		/// <returns>�݌ɋ敪UI�A��</returns>
		/// <remarks>
		/// <br>Note       : UI���Ŏg�p���Ă���݌ɋ敪UI�A�Ԃ��擾���܂�</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.23</br>
		/// </remarks>
		public static int GetUiStockDiv( int targetStockDiv,int targetStockState )
		{
			int stockUiDiv = 0;

			 switch(targetStockDiv)
            {
                //����
                case (int)StockStateDiv.MyStock:
                {
                    switch(targetStockState)
                    {
                        //�݌�
                        case (int)StockState.Stock:
                        {
                            stockUiDiv = (int)StockUiDiv.UiStock;
                            break;
                        }
                        //�ϑ���
                        case (int)StockState.EnTrust:
                        {
                            stockUiDiv = (int)StockUiDiv.UiEnTrustStock;
                            break;
                        }
                    }
                    break;
                }
                //���
                case (int)StockStateDiv.TrustStock:
                {
                    switch(targetStockState)
                    {
                        //�����
                        case (int)StockState.Trust:
                        {
                            stockUiDiv = (int)StockUiDiv.UiTrust;
                            break;
                        }
                        //�ϑ���
                        case (int)StockState.EnTrust:
                        {
                            stockUiDiv = (int)StockUiDiv.UiEnTrustTrust;
                            break;
                        }
                    }
                    break;
                }
            }
			return stockUiDiv;
		}

        #endregion
    }
}
