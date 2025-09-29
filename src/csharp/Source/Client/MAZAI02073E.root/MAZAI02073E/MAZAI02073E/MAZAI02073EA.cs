using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockListCndtn
	/// <summary>
	///                      �݌Ɉꗗ�\���o�����N���X
	/// </summary>
	/// <remarks>
	/// <br>note             :   �݌Ɉꗗ�\���o�����N���X�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/10/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockListCndtn
	{
        #region enum

        /// <summary>
        /// �\�[�g��
        /// </summary>
        public enum PageChangeDiv
        {
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            /////<summary>���[�J�[�R�[�h��</summary>
            //Sort_MakerCode = 0,
            /////<summary>�L�����A��</summary>
            //Sort_CarrierCode = 1,
            /////<summary>�ŏI�d������</summary>
            //Sort_StockDate = 2,
            /////<summary>���i�敪�O���[�v�E�敪��</summary>
            //Sort_LargeGoodsGanreCode = 3,
            /////<summary>�@�폇</summary>
            //Sort_CellPhoneModeleCode = 4,
            /////<summary>�o�׉\��</summary>
            //Sort_ShipmentPosCnt = 5

            //--- DEL 2008/08/01 ---------->>>>>
            /////<summary>�q�ɃR�[�h��</summary>
            //Sort_WarehouseCode = 0,
            /////<summary>���[�J�[�R�[�h��</summary>
            //Sort_MakerCode = 1,
            /////<summary>�ŏI�d������</summary>
            //Sort_StockDate = 2,
            /////<summary>�o�׉\����</summary>
            //Sort_ShipmentPosCnt = 3,
            /////<summary>���i�敪�O���[�v�E�敪�E�ڍ׋敪��</summary>
            //Sort_LargeGoodsGanreCode = 4,
            /////<summary>���Е��ޏ�</summary>
            //Sort_EnterpriseGanreCode = 5,
            /////<summary>�a�k���i�R�[�h��</summary>
            //Sort_BLGoodsCode = 6
            //--- DEL 2008/08/01 ----------<<<<<
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<

            //--- ADD 2008/08/01 ---------->>>>>
            /////<summary>�d���揇</summary>
            Sort_SupplierCode = 0,
            /////<summary>�I�ԏ�</summary>
            Sort_WarehouseCode = 1
            //--- ADD 2008/08/01 ----------<<<<<
        }

        /// <summary>
        /// �\�[�g�v
        /// </summary>
        public enum PageChangeDivTitle
        {
            // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
            /////<summary>���[�J�[�R�[�h��</summary>
            //Sort_MakerTitle = 0,
            /////<summary>�L�����A��</summary>
            //Sort_CarrierTitle = 1,
            /////<summary>�ŏI�d�����v</summary>
            //Sort_StockDateTitle = 2,
            /////<summary>���i�敪�O���[�v�v</summary>
            //Sort_LargeGoodsGanreTitle = 3,
            /////<summary>�@�폇�v</summary>
            //Sort_CellPhoneModeleCodeTitle = 4,
            /////<summary>�o�׉\��</summary>
            //Sort_ShipmentPosCntTitle = 5,
            /////<summary>���i�敪�v</summary>
            //Sort_MediumGoodsGanreTitle = 6

            ///<summary>�q�ɃR�[�h��</summary>
            Sort_WarehouseTitle = 0,
            ///<summary>���[�J�[�R�[�h��</summary>
            Sort_MakerTitle = 1,
            ///<summary>�ŏI�d������</summary>
            Sort_StockDateTitle = 2,
            ///<summary>�o�׉\����</summary>
            Sort_ShipmentPosCntTitle = 3,
            ///<summary>���i�敪�O���[�v�E�敪�E�ڍ׋敪��</summary>
            Sort_LargeGoodsGanreTitle = 4,
            ///<summary>���Е��ޏ�</summary>
            Sort_EnterpriseGanreTitle = 5,
            ///<summary>�a�k���i�R�[�h��</summary>
            Sort_BLGoodsTitle = 6,
            ///<summary>���i�敪�v</summary>
            Sort_MediumGoodsGanreTitle = 7,
            ///<summary>���i�敪�ڍ׌v</summary>
            Sort_DetailGoodsGanreTitle = 8
            // 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �݌ɋ敪
        /// </summary>
        public enum StockDivStatus
        {
            ///<summary>�d���݌ɕ�</summary>
            StockDiv_MyStock = 0,
            ///<summary>����݌ɕ�</summary>
            StockDiv_TrustStock = 1,
            ///<summary>�S��</summary>
            StockDiv_ALLStock = 2
        }

        #endregion

        #region Private Member
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�I���݌Ɍv�㋒�_�R�[�h</summary>
        /// <remarks>�i�z��j</remarks>
        private string[] _depositStockSecCodeList;

        /// <summary>�J�n���[�J�[�R�[�h</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>�I�����[�J�[�R�[�h</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>�J�n���i�ԍ�</summary>
        private string _st_GoodsNo = "";

        /// <summary>�I�����i�ԍ�</summary>
        private string _ed_GoodsNo = "";

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _st_WarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _ed_WarehouseCode = "";

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>�J�n�d���݌ɐ�</summary>
        //private Double _st_SupplierStock;

        ///// <summary>�I���d���݌ɐ�</summary>
        //private Double _ed_SupplierStock;

        ///// <summary>�J�n�����</summary>
        //private Double _st_TrustCount;

        ///// <summary>�I�������</summary>
        //private Double _ed_TrustCount;
        //--- DEL 2008.08.01 ----------<<<<<

        /// <summary>�J�n�o�׉\��</summary>
        private Double _st_ShipmentPosCnt;

        /// <summary>�I���o�׉\��</summary>
        private Double _ed_ShipmentPosCnt;

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>�J�n���i�敪�O���[�v�R�[�h</summary>
        //private string _st_LargeGoodsGanreCode = "";

        ///// <summary>�I�����i�敪�O���[�v�R�[�h</summary>
        //private string _ed_LargeGoodsGanreCode = "";

        ///// <summary>�J�n���i�敪�R�[�h</summary>
        //private string _st_MediumGoodsGanreCode = "";

        ///// <summary>�I�����i�敪�R�[�h</summary>
        //private string _ed_MediumGoodsGanreCode = "";

        ///// <summary>�J�n���i�敪�ڍ׃R�[�h</summary>
        //private string _st_DetailGoodsGanreCode = "";

        ///// <summary>�I�����i�敪�ڍ׃R�[�h</summary>
        //private string _ed_DetailGoodsGanreCode = "";

        ///// <summary>���Е��ރR�[�h�J�n</summary>
        //private Int32 _st_EnterpriseGanreCode;

        ///// <summary>���Е��ރR�[�h�I��</summary>
        //private Int32 _ed_EnterpriseGanreCode;
        //--- DEL 2008.08.01 ----------<<<<<

        /// <summary>�a�k���i�R�[�h�J�n</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>�a�k���i�R�[�h�I��</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>�J�n�ŏI�d���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_LastStockDate;

        /// <summary>�I���ŏI�d���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_LastStockDate;

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>�J�n�ŏI�����</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _st_LastSalesDate;

        ///// <summary>�I���ŏI�����</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _ed_LastSalesDate;

        ///// <summary>�J�n�ŏI�I���X�V��</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _st_LastInventoryUpdate;

        ///// <summary>�I���ŏI�I���X�V��</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _ed_LastInventoryUpdate;

        ///// <summary>�J�n�݌ɓo�^��</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _st_StockCreateDate;

        ///// <summary>�I���݌ɓo�^��</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _ed_StockCreateDate;
        //--- DEL 2008.08.01 ----------<<<<<

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:�S��,1:�d���݌ɕ�(����),2����݌ɕ�(���)</remarks>
        private Int32 _stockDiv;

        /// <summary>�o�͏�</summary>
        private Int32 _changePageDiv;

        /// <summary>�o�͏�����</summary>
        private string _changePageDivName = "";

        /// <summary>�݌ɕ]�����@</summary>
        /// <remarks>1:�ŏI�d�������@,2:�ړ����ϖ@,3:�ʒP���@</remarks>
        private Int32 _stockPointWay;

        //--- ADD 2008/08/01 ---------->>>>>
        /// <summary>�݌ɓo�^��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;
        /// <summary>�݌ɓo�^�������t���O</summary>
        /// <remarks>YYYYMMDD</remarks>
        private StockCreateDateDivState _stockCreateDateFlg;

        /// <summary>���i�Ǘ��敪�P</summary>
        private string[] _partsManagementDivide1;
        /// <summary>���i�Ǘ��敪�Q</summary>
        private string[] _partsManagementDivide2;

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _st_StockSupplierCode;
        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _ed_StockSupplierCode;

        /// <summary>�J�n�q�ɒI��</summary>
        private string _st_WarehouseShelfNo = "";
        /// <summary>�I���q�ɒI��</summary>
        private string _ed_WarehouseShelfNo = "";
        //--- ADD 2008/08/01 ----------<<<<<
        #endregion

        #region public propaty
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

        /// public propaty name  :  DepositStockSecCodeList
        /// <summary>�I���݌Ɍv�㋒�_�R�[�h�v���p�e�B</summary>
        /// <value>�i�z��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���݌Ɍv�㋒�_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] DepositStockSecCodeList
        {
            get { return _depositStockSecCodeList; }
            set { _depositStockSecCodeList = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>�I�����i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  St_WarehouseCode
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
        }

        //--- DEL 2008.08.01 ---------->>>>>
        ///// public propaty name  :  St_SupplierStock
        ///// <summary>�J�n�d���݌ɐ��v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n�d���݌ɐ��v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Double St_SupplierStock
        //{
        //    get { return _st_SupplierStock; }
        //    set { _st_SupplierStock = value; }
        //}

        ///// public propaty name  :  Ed_SupplierStock
        ///// <summary>�I���d���݌ɐ��v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I���d���݌ɐ��v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Double Ed_SupplierStock
        //{
        //    get { return _ed_SupplierStock; }
        //    set { _ed_SupplierStock = value; }
        //}

        ///// public propaty name  :  St_TrustCount
        ///// <summary>�J�n������v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n������v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Double St_TrustCount
        //{
        //    get { return _st_TrustCount; }
        //    set { _st_TrustCount = value; }
        //}

        ///// public propaty name  :  Ed_TrustCount
        ///// <summary>�I��������v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I��������v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Double Ed_TrustCount
        //{
        //    get { return _ed_TrustCount; }
        //    set { _ed_TrustCount = value; }
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        /// public propaty name  :  St_ShipmentPosCnt
        /// <summary>�J�n�o�׉\���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double St_ShipmentPosCnt
        {
            get { return _st_ShipmentPosCnt; }
            set { _st_ShipmentPosCnt = value; }
        }

        /// public propaty name  :  Ed_ShipmentPosCnt
        /// <summary>�I���o�׉\���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Ed_ShipmentPosCnt
        {
            get { return _ed_ShipmentPosCnt; }
            set { _ed_ShipmentPosCnt = value; }
        }

        //--- DEL 2008.08.01 ---------->>>>>
        ///// public propaty name  :  St_LargeGoodsGanreCode
        ///// <summary>�J�n���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n���i�敪�O���[�v�R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string St_LargeGoodsGanreCode
        //{
        //    get { return _st_LargeGoodsGanreCode; }
        //    set { _st_LargeGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_LargeGoodsGanreCode
        ///// <summary>�I�����i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I�����i�敪�O���[�v�R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string Ed_LargeGoodsGanreCode
        //{
        //    get { return _ed_LargeGoodsGanreCode; }
        //    set { _ed_LargeGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  St_MediumGoodsGanreCode
        ///// <summary>�J�n���i�敪�R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n���i�敪�R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string St_MediumGoodsGanreCode
        //{
        //    get { return _st_MediumGoodsGanreCode; }
        //    set { _st_MediumGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_MediumGoodsGanreCode
        ///// <summary>�I�����i�敪�R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I�����i�敪�R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string Ed_MediumGoodsGanreCode
        //{
        //    get { return _ed_MediumGoodsGanreCode; }
        //    set { _ed_MediumGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  St_DetailGoodsGanreCode
        ///// <summary>�J�n���i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n���i�敪�ڍ׃R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string St_DetailGoodsGanreCode
        //{
        //    get { return _st_DetailGoodsGanreCode; }
        //    set { _st_DetailGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_DetailGoodsGanreCode
        ///// <summary>�I�����i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I�����i�敪�ڍ׃R�[�h�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public string Ed_DetailGoodsGanreCode
        //{
        //    get { return _ed_DetailGoodsGanreCode; }
        //    set { _ed_DetailGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  St_EnterpriseGanreCode
        ///// <summary>���Е��ރR�[�h�J�n�v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Е��ރR�[�h�J�n�v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 St_EnterpriseGanreCode
        //{
        //    get { return _st_EnterpriseGanreCode; }
        //    set { _st_EnterpriseGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_EnterpriseGanreCode
        ///// <summary>���Е��ރR�[�h�I���v���p�e�B</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   ���Е��ރR�[�h�I���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public Int32 Ed_EnterpriseGanreCode
        //{
        //    get { return _ed_EnterpriseGanreCode; }
        //    set { _ed_EnterpriseGanreCode = value; }
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>�a�k���i�R�[�h�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �a�k���i�R�[�h�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
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
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_LastStockDate
        /// <summary>�J�n�ŏI�d���N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�ŏI�d���N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_LastStockDate
        {
            get { return _st_LastStockDate; }
            set { _st_LastStockDate = value; }
        }

        /// public propaty name  :  Ed_LastStockDate
        /// <summary>�I���ŏI�d���N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���ŏI�d���N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_LastStockDate
        {
            get { return _ed_LastStockDate; }
            set { _ed_LastStockDate = value; }
        }

        //--- DEL 2008.08.01 ---------->>>>>
        ///// public propaty name  :  St_LastSalesDate
        ///// <summary>�J�n�ŏI������v���p�e�B</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n�ŏI������v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public DateTime St_LastSalesDate
        //{
        //    get { return _st_LastSalesDate; }
        //    set { _st_LastSalesDate = value; }
        //}

        ///// public propaty name  :  Ed_LastSalesDate
        ///// <summary>�I���ŏI������v���p�e�B</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I���ŏI������v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public DateTime Ed_LastSalesDate
        //{
        //    get { return _ed_LastSalesDate; }
        //    set { _ed_LastSalesDate = value; }
        //}

        ///// public propaty name  :  St_LastInventoryUpdate
        ///// <summary>�J�n�ŏI�I���X�V���v���p�e�B</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n�ŏI�I���X�V���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public DateTime St_LastInventoryUpdate
        //{
        //    get { return _st_LastInventoryUpdate; }
        //    set { _st_LastInventoryUpdate = value; }
        //}

        ///// public propaty name  :  Ed_LastInventoryUpdate
        ///// <summary>�I���ŏI�I���X�V���v���p�e�B</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I���ŏI�I���X�V���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public DateTime Ed_LastInventoryUpdate
        //{
        //    get { return _ed_LastInventoryUpdate; }
        //    set { _ed_LastInventoryUpdate = value; }
        //}

        ///// public propaty name  :  St_StockCreateDate
        ///// <summary>�J�n�݌ɓo�^���v���p�e�B</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �J�n�݌ɓo�^���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public DateTime St_StockCreateDate
        //{
        //    get { return _st_StockCreateDate; }
        //    set { _st_StockCreateDate = value; }
        //}

        ///// public propaty name  :  Ed_StockCreateDate
        ///// <summary>�I���݌ɓo�^���v���p�e�B</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   �I���݌ɓo�^���v���p�e�B</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public DateTime Ed_StockCreateDate
        //{
        //    get { return _ed_StockCreateDate; }
        //    set { _ed_StockCreateDate = value; }
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:�S��,1:�d���݌ɕ�(����),2����݌ɕ�(���)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>�o�͏��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͏��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// public propaty name  :  ChangePageDivName
        /// <summary>�o�͏����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͏����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ChangePageDivName
        {
            get { return _changePageDivName; }
            set { _changePageDivName = value; }
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
            get { return _stockPointWay; }
            set { _stockPointWay = value; }
        }

        //--- ADD 2008/08/01 ---------->>>>>

        /// public propaty name  :  StockCreateDate
        /// <summary>�݌ɓo�^���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockCreateDate
        {
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>�݌ɓo�^�������t���O�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɓo�^�������t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockCreateDateDivState StockCreateDateFlg
        {
            get { return _stockCreateDateFlg; }
            set { _stockCreateDateFlg = value; }
        }

        /// public propaty name  :  PartsManagementDivide1
        /// <summary>���i�Ǘ��敪�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] PartsManagementDivide1
        {
            get { return _partsManagementDivide1; }
            set { _partsManagementDivide1 = value; }
        }

        /// public propaty name  :  PartsManagementDivide2
        /// <summary>���i�Ǘ��敪�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�Ǘ��敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] PartsManagementDivide2
        {
            get { return _partsManagementDivide2; }
            set { _partsManagementDivide2 = value; }
        }

        /// public propaty name  :  St_StockSupplierCode
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�݌ɔ�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_StockSupplierCode
        {
            get { return _st_StockSupplierCode; }
            set { _st_StockSupplierCode = value; }
        }

        /// public propaty name  :  Ed_StockSupplierCode
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���݌ɔ�����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_StockSupplierCode
        {
            get { return _ed_StockSupplierCode; }
            set { _ed_StockSupplierCode = value; }
        }

        /// public propaty name  :  St_WarehouseShelfNo
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_WarehouseShelfNo
        {
            get { return _st_WarehouseShelfNo; }
            set { _st_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  Ed_WarehouseShelfNo
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_WarehouseShelfNo
        {
            get { return _ed_WarehouseShelfNo; }
            set { _ed_WarehouseShelfNo = value; }
        }

        //--- ADD 2008/08/01 ----------<<<<<

        #endregion

        //--- ADD 2008/08/01 ---------->>>>>
        # region �� private field (���������ȊO) ��
        /// <summary>
        /// �I�ԃu���C�N�敪
        /// </summary>
        private WarehouseShelfNoBreakDivState _warehouseShelfNoBreakDiv;
        /// <summary>
        /// ���ŋ敪
        /// </summary>
        private NewPageDivState _newPageDiv;
        /// <summary>
        /// ���s�^�C�v�敪
        /// </summary>
        private PublicationTypeState _publicationType;
        # endregion �� private field (���������ȊO) ��
        //--- ADD 2008/08/01 ----------<<<<<

        //--- ADD 2008/08/01 ---------->>>>>
        # region �� public propaty (���������ȊO) ��
        /// <summary>
        /// <summary>
        /// �I�ԃu���C�N�敪�v���p�e�B
        /// </summary>
        public WarehouseShelfNoBreakDivState WarehouseShelfNoBreakDiv
        {
            get { return this._warehouseShelfNoBreakDiv; }
            set { this._warehouseShelfNoBreakDiv = value; }
        }
        /// <summary>
        /// �I�ԃu���C�N����
        /// </summary>
        public Int32 WarehouseShelfNoBreakLength
        {
            // ReadOnly
            get
            {
                return ((int)this._warehouseShelfNoBreakDiv + 1);
            }
        }
        /// <summary>
        /// ���y�[�W�敪�@�v���p�e�B
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }
        /// <summary>
        /// ���s�^�C�v�敪�@�v���p�e�B
        /// </summary>
        public PublicationTypeState PublicationType
        {
            get { return this._publicationType; }
            set { this._publicationType = value; }
        }
        /// <summary>
        /// �݌ɓo�^���w��敪�@���̎擾�v���p�e�B
        /// </summary>
        public string StockCreateDateDivStateTitle
        {
            get
            {
                switch (this._stockCreateDateFlg)
                {
                    case StockCreateDateDivState.Before: return ct_StockCreateDateDivState_Before;
                    case StockCreateDateDivState.After: return ct_StockCreateDateDivState_After;
                    default: return string.Empty;
                }
            }
        }
        /// <summary>
        /// �I�ԃu���C�N�敪�@���̎擾�v���p�e�B
        /// </summary>
        public string WarehouseShelfNoBreakDivStateTitle
        {
            get
            {
                switch (this._warehouseShelfNoBreakDiv)
                {
                    case WarehouseShelfNoBreakDivState.Length1: return ct_WarehouseShelfNoBreakDivState_Length1;
                    case WarehouseShelfNoBreakDivState.Length2: return ct_WarehouseShelfNoBreakDivState_Length2;
                    case WarehouseShelfNoBreakDivState.Length3: return ct_WarehouseShelfNoBreakDivState_Length3;
                    case WarehouseShelfNoBreakDivState.Length4: return ct_WarehouseShelfNoBreakDivState_Length4;
                    case WarehouseShelfNoBreakDivState.Length5: return ct_WarehouseShelfNoBreakDivState_Length5;
                    case WarehouseShelfNoBreakDivState.Length6: return ct_WarehouseShelfNoBreakDivState_Length6;
                    case WarehouseShelfNoBreakDivState.Length7: return ct_WarehouseShelfNoBreakDivState_Length7;
                    case WarehouseShelfNoBreakDivState.Length8: return ct_WarehouseShelfNoBreakDivState_Length8;
                    default: return string.Empty;
                }
            }
        }
        # endregion �� public propaty (���������ȊO) ��
        //--- ADD 2008/08/01 ----------<<<<<

        //--- ADD 2008/08/01 ---------->>>>>
        # region �� public Enum (���������ȊO) ��
        /// <summary>
        /// �I�ԃu���C�N�敪�@�񋓑�
        /// </summary>
        public enum WarehouseShelfNoBreakDivState
        {
            /// <summary>�P��</summary>
            Length1 = 0,
            /// <summary>�Q��</summary>
            Length2 = 1,
            /// <summary>�R��</summary>
            Length3 = 2,
            /// <summary>�S��</summary>
            Length4 = 3,
            /// <summary>�T��</summary>
            Length5 = 4,
            /// <summary>�U��</summary>
            Length6 = 5,
            /// <summary>�V��</summary>
            Length7 = 6,
            /// <summary>�W��</summary>
            Length8 = 7,
        }
        /// <summary>
        /// ���y�[�W�敪�@�񋓑�
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>���v��</summary>
            EachSummaly = 0,
            /// <summary>���Ȃ�</summary>
            None = 1,
        }
        /// <summary>
        /// �݌ɓo�^���w��敪�@�񋓑�
        /// </summary>
        public enum StockCreateDateDivState
        {
            /// <summary>�ȑO</summary>
            Before = 0,
            /// <summary>�Ȍ�</summary>
            After = 1,
        }
        /// <summary>
        /// �o�͏��敪
        /// </summary>
        public enum PrintSortDivState
        {
            /// <summary>�d���揇</summary>
            ByCustomer = 0,
            /// <summary>�q�ɒI�ԏ�</summary>
            ByWarehouseShelfNo = 1,
        }
        /// <summary>
        /// ���s�^�C�v�敪
        /// </summary>
        public enum PublicationTypeState
        {
            /// <summary>����</summary>
            ByShipmentCnt = 0,
            /// <summary>���z</summary>
            ByShipmentPrice = 1,
        }
        # endregion �� public Enum (���������ȊO) ��
        //--- ADD 2008/08/01 ----------<<<<<

        //--- ADD 2008/08/01 ---------->>>>>
        #region �� public const (���������ȊO) ��
        /// <summary>���� ���t�t�H�[�}�b�g</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>���� �S�� �R�[�h</summary>
        public const int ct_All_Code = -1;
        /// <summary>���� �S�� ����</summary>
        public const string ct_All_Name = "�S��";

        /// <summary>�I�ԃu���C�N�敪�@�P��</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length1 = "�P��";
        /// <summary>�I�ԃu���C�N�敪�@�Q��</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length2 = "�Q��";
        /// <summary>�I�ԃu���C�N�敪�@�R��</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length3 = "�R��";
        /// <summary>�I�ԃu���C�N�敪�@�S��</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length4 = "�S��";
        /// <summary>�I�ԃu���C�N�敪�@�T��</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length5 = "�T��";
        /// <summary>�I�ԃu���C�N�敪�@�U��</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length6 = "�U��";
        /// <summary>�I�ԃu���C�N�敪�@�V��</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length7 = "�V��";
        /// <summary>�I�ԃu���C�N�敪�@�W��</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length8 = "�W��";

        /// <summary>���y�[�W�敪�@���v��</summary>
        public const string ct_NewPageDivState_EachSummaly = "���v��";
        /// <summary>���y�[�W�敪�@������Ȃ�</summary>
        public const string ct_NewPageDivState_None = "������Ȃ�";

        /// <summary>�݌ɓo�^���w��敪�@�ȑO</summary>
        public const string ct_StockCreateDateDivState_Before = "�ȑO";
        /// <summary>�݌ɓo�^���w��敪�@�Ȍ�</summary>
        public const string ct_StockCreateDateDivState_After = "�Ȍ�";

        /// <summary>�o�͏��敪�@�d���揇</summary>
        public const string ct_PrintSortDivState_ByCustomer = "�d���揇";
        /// <summary>�o�͏��敪�@�I�ԏ�</summary>
        public const string ct_PrintSortDivState_ByWarehouseShelfNo = "�I�ԏ�";

        #endregion
        //--- ADD 2008/08/01 ----------<<<<<

        #region Constructor
		/// <summary>
		/// �݌Ɉꗗ�\���o�����N���X�R���X�g���N�^
		/// </summary>
		/// <returns>StockListCndtn�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   StockListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public StockListCndtn()
		{
		}

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// �݌Ɉꗗ�\���o�����N���X�R���X�g���N�^
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        ///// <param name="depositStockSecCodeList">�I���݌Ɍv�㋒�_�R�[�h(�i�z��j)</param>
        ///// <param name="st_GoodsMakerCd">�J�n���[�J�[�R�[�h</param>
        ///// <param name="ed_GoodsMakerCd">�I�����[�J�[�R�[�h</param>
        ///// <param name="st_GoodsNo">�J�n���i�ԍ�</param>
        ///// <param name="ed_GoodsNo">�I�����i�ԍ�</param>
        ///// <param name="st_WarehouseCode">�J�n�q�ɃR�[�h</param>
        ///// <param name="ed_WarehouseCode">�I���q�ɃR�[�h</param>
        ///// <param name="st_SupplierStock">�J�n�d���݌ɐ�</param>
        ///// <param name="ed_SupplierStock">�I���d���݌ɐ�</param>
        ///// <param name="st_TrustCount">�J�n�����</param>
        ///// <param name="ed_TrustCount">�I�������</param>
        ///// <param name="st_ShipmentPosCnt">�J�n�o�׉\��</param>
        ///// <param name="ed_ShipmentPosCnt">�I���o�׉\��</param>
        ///// <param name="st_LargeGoodsGanreCode">�J�n���i�敪�O���[�v�R�[�h</param>
        ///// <param name="ed_LargeGoodsGanreCode">�I�����i�敪�O���[�v�R�[�h</param>
        ///// <param name="st_MediumGoodsGanreCode">�J�n���i�敪�R�[�h</param>
        ///// <param name="ed_MediumGoodsGanreCode">�I�����i�敪�R�[�h</param>
        ///// <param name="st_DetailGoodsGanreCode">�J�n���i�敪�ڍ׃R�[�h</param>
        ///// <param name="ed_DetailGoodsGanreCode">�I�����i�敪�ڍ׃R�[�h</param>
        ///// <param name="st_EnterpriseGanreCode">���Е��ރR�[�h�J�n</param>
        ///// <param name="ed_EnterpriseGanreCode">���Е��ރR�[�h�I��</param>
        ///// <param name="st_BLGoodsCode">�a�k���i�R�[�h�J�n</param>
        ///// <param name="ed_BLGoodsCode">�a�k���i�R�[�h�I��</param>
        ///// <param name="st_LastStockDate">�J�n�ŏI�d���N����(YYYYMMDD)</param>
        ///// <param name="ed_LastStockDate">�I���ŏI�d���N����(YYYYMMDD)</param>
        ///// <param name="st_LastSalesDate">�J�n�ŏI�����(YYYYMMDD)</param>
        ///// <param name="ed_LastSalesDate">�I���ŏI�����(YYYYMMDD)</param>
        ///// <param name="st_LastInventoryUpdate">�J�n�ŏI�I���X�V��(YYYYMMDD)</param>
        ///// <param name="ed_LastInventoryUpdate">�I���ŏI�I���X�V��(YYYYMMDD)</param>
        ///// <param name="st_StockCreateDate">�J�n�݌ɓo�^��(YYYYMMDD)</param>
        ///// <param name="ed_StockCreateDate">�I���݌ɓo�^��(YYYYMMDD)</param>
        ///// <param name="stockDiv">�݌ɋ敪(0:�S��,1:�d���݌ɕ�(����),2����݌ɕ�(���))</param>
        ///// <param name="changePageDiv">�o�͏�</param>
        ///// <param name="changePageDivName">�o�͏�����</param>
        ///// <param name="stockPointWay">�݌ɕ]�����@(1:�ŏI�d�������@,2:�ړ����ϖ@,3:�ʒP���@)</param>
        ///// <returns>StockListCndtn�N���X�̃C���X�^���X</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   StockListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public StockListCndtn(string enterpriseCode,string[] depositStockSecCodeList,Int32 st_GoodsMakerCd,Int32 ed_GoodsMakerCd,string st_GoodsNo,string ed_GoodsNo,string st_WarehouseCode,string ed_WarehouseCode,Double st_SupplierStock,Double ed_SupplierStock,Double st_TrustCount,Double ed_TrustCount,Double st_ShipmentPosCnt,Double ed_ShipmentPosCnt,string st_LargeGoodsGanreCode,string ed_LargeGoodsGanreCode,string st_MediumGoodsGanreCode,string ed_MediumGoodsGanreCode,string st_DetailGoodsGanreCode,string ed_DetailGoodsGanreCode,Int32 st_EnterpriseGanreCode,Int32 ed_EnterpriseGanreCode,Int32 st_BLGoodsCode,Int32 ed_BLGoodsCode,DateTime st_LastStockDate,DateTime ed_LastStockDate,DateTime st_LastSalesDate,DateTime ed_LastSalesDate,DateTime st_LastInventoryUpdate,DateTime ed_LastInventoryUpdate,DateTime st_StockCreateDate,DateTime ed_StockCreateDate,Int32 stockDiv,Int32 changePageDiv,string changePageDivName,Int32 stockPointWay)
        //{
        //    this._enterpriseCode = enterpriseCode;
        //    this._depositStockSecCodeList = depositStockSecCodeList;
        //    this._st_GoodsMakerCd = st_GoodsMakerCd;
        //    this._ed_GoodsMakerCd = ed_GoodsMakerCd;
        //    this._st_GoodsNo = st_GoodsNo;
        //    this._ed_GoodsNo = ed_GoodsNo;
        //    this._st_WarehouseCode = st_WarehouseCode;
        //    this._ed_WarehouseCode = ed_WarehouseCode;
        //    this._st_SupplierStock = st_SupplierStock;
        //    this._ed_SupplierStock = ed_SupplierStock;
        //    this._st_TrustCount = st_TrustCount;
        //    this._ed_TrustCount = ed_TrustCount;
        //    this._st_ShipmentPosCnt = st_ShipmentPosCnt;
        //    this._ed_ShipmentPosCnt = ed_ShipmentPosCnt;
        //    this._st_LargeGoodsGanreCode = st_LargeGoodsGanreCode;
        //    this._ed_LargeGoodsGanreCode = ed_LargeGoodsGanreCode;
        //    this._st_MediumGoodsGanreCode = st_MediumGoodsGanreCode;
        //    this._ed_MediumGoodsGanreCode = ed_MediumGoodsGanreCode;
        //    this._st_DetailGoodsGanreCode = st_DetailGoodsGanreCode;
        //    this._ed_DetailGoodsGanreCode = ed_DetailGoodsGanreCode;
        //    this._st_EnterpriseGanreCode = st_EnterpriseGanreCode;
        //    this._ed_EnterpriseGanreCode = ed_EnterpriseGanreCode;
        //    this._st_BLGoodsCode = st_BLGoodsCode;
        //    this._ed_BLGoodsCode = ed_BLGoodsCode;
        //    this._st_LastStockDate = st_LastStockDate;
        //    this._ed_LastStockDate = ed_LastStockDate;
        //    this._st_LastSalesDate = st_LastSalesDate;
        //    this._ed_LastSalesDate = ed_LastSalesDate;
        //    this._st_LastInventoryUpdate = st_LastInventoryUpdate;
        //    this._ed_LastInventoryUpdate = ed_LastInventoryUpdate;
        //    this._st_StockCreateDate = st_StockCreateDate;
        //    this._ed_StockCreateDate = ed_StockCreateDate;
        //    this._stockDiv = stockDiv;
        //    this._changePageDiv = changePageDiv;
        //    this._changePageDivName = changePageDivName;
        //    this._stockPointWay = stockPointWay;

        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// �݌Ɉꗗ�\���o�����N���X��������
        ///// </summary>
        ///// <returns>StockListCndtn�N���X�̃C���X�^���X</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockListCndtn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public StockListCndtn Clone()
        //{
        //    return new StockListCndtn(this._enterpriseCode,this._depositStockSecCodeList,this._st_GoodsMakerCd,this._ed_GoodsMakerCd,this._st_GoodsNo,this._ed_GoodsNo,this._st_WarehouseCode,this._ed_WarehouseCode,this._st_SupplierStock,this._ed_SupplierStock,this._st_TrustCount,this._ed_TrustCount,this._st_ShipmentPosCnt,this._ed_ShipmentPosCnt,this._st_LargeGoodsGanreCode,this._ed_LargeGoodsGanreCode,this._st_MediumGoodsGanreCode,this._ed_MediumGoodsGanreCode,this._st_DetailGoodsGanreCode,this._ed_DetailGoodsGanreCode,this._st_EnterpriseGanreCode,this._ed_EnterpriseGanreCode,this._st_BLGoodsCode,this._ed_BLGoodsCode,this._st_LastStockDate,this._ed_LastStockDate,this._st_LastSalesDate,this._ed_LastSalesDate,this._st_LastInventoryUpdate,this._ed_LastInventoryUpdate,this._st_StockCreateDate,this._ed_StockCreateDate,this._stockDiv,this._changePageDiv,this._changePageDivName,this._stockPointWay);
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// �݌Ɉꗗ�\���o�����N���X��r����
        ///// </summary>
        ///// <param name="target">��r�Ώۂ�StockListCndtn�N���X�̃C���X�^���X</param>
        ///// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   StockListCndtn�N���X�̓��e����v���邩��r���܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public bool Equals(StockListCndtn target)
        //{
        //    return ((this.EnterpriseCode == target.EnterpriseCode)
        //         && (this.DepositStockSecCodeList == target.DepositStockSecCodeList)
        //         && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
        //         && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
        //         && (this.St_GoodsNo == target.St_GoodsNo)
        //         && (this.Ed_GoodsNo == target.Ed_GoodsNo)
        //         && (this.St_WarehouseCode == target.St_WarehouseCode)
        //         && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
        //         && (this.St_SupplierStock == target.St_SupplierStock)
        //         && (this.Ed_SupplierStock == target.Ed_SupplierStock)
        //         && (this.St_TrustCount == target.St_TrustCount)
        //         && (this.Ed_TrustCount == target.Ed_TrustCount)
        //         && (this.St_ShipmentPosCnt == target.St_ShipmentPosCnt)
        //         && (this.Ed_ShipmentPosCnt == target.Ed_ShipmentPosCnt)
        //         && (this.St_LargeGoodsGanreCode == target.St_LargeGoodsGanreCode)
        //         && (this.Ed_LargeGoodsGanreCode == target.Ed_LargeGoodsGanreCode)
        //         && (this.St_MediumGoodsGanreCode == target.St_MediumGoodsGanreCode)
        //         && (this.Ed_MediumGoodsGanreCode == target.Ed_MediumGoodsGanreCode)
        //         && (this.St_DetailGoodsGanreCode == target.St_DetailGoodsGanreCode)
        //         && (this.Ed_DetailGoodsGanreCode == target.Ed_DetailGoodsGanreCode)
        //         && (this.St_EnterpriseGanreCode == target.St_EnterpriseGanreCode)
        //         && (this.Ed_EnterpriseGanreCode == target.Ed_EnterpriseGanreCode)
        //         && (this.St_BLGoodsCode == target.St_BLGoodsCode)
        //         && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
        //         && (this.St_LastStockDate == target.St_LastStockDate)
        //         && (this.Ed_LastStockDate == target.Ed_LastStockDate)
        //         && (this.St_LastSalesDate == target.St_LastSalesDate)
        //         && (this.Ed_LastSalesDate == target.Ed_LastSalesDate)
        //         && (this.St_LastInventoryUpdate == target.St_LastInventoryUpdate)
        //         && (this.Ed_LastInventoryUpdate == target.Ed_LastInventoryUpdate)
        //         && (this.St_StockCreateDate == target.St_StockCreateDate)
        //         && (this.Ed_StockCreateDate == target.Ed_StockCreateDate)
        //         && (this.StockDiv == target.StockDiv)
        //         && (this.ChangePageDiv == target.ChangePageDiv)
        //         && (this.ChangePageDivName == target.ChangePageDivName)
        //         && (this.StockPointWay == target.StockPointWay));
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// �݌Ɉꗗ�\���o�����N���X��r����
        ///// </summary>
        ///// <param name="stockListCndtn1">
        /////                    ��r����StockListCndtn�N���X�̃C���X�^���X
        ///// </param>
        ///// <param name="stockListCndtn2">��r����StockListCndtn�N���X�̃C���X�^���X</param>
        ///// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   StockListCndtn�N���X�̓��e����v���邩��r���܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public static bool Equals(StockListCndtn stockListCndtn1, StockListCndtn stockListCndtn2)
        //{
        //    return ((stockListCndtn1.EnterpriseCode == stockListCndtn2.EnterpriseCode)
        //         && (stockListCndtn1.DepositStockSecCodeList == stockListCndtn2.DepositStockSecCodeList)
        //         && (stockListCndtn1.St_GoodsMakerCd == stockListCndtn2.St_GoodsMakerCd)
        //         && (stockListCndtn1.Ed_GoodsMakerCd == stockListCndtn2.Ed_GoodsMakerCd)
        //         && (stockListCndtn1.St_GoodsNo == stockListCndtn2.St_GoodsNo)
        //         && (stockListCndtn1.Ed_GoodsNo == stockListCndtn2.Ed_GoodsNo)
        //         && (stockListCndtn1.St_WarehouseCode == stockListCndtn2.St_WarehouseCode)
        //         && (stockListCndtn1.Ed_WarehouseCode == stockListCndtn2.Ed_WarehouseCode)
        //         && (stockListCndtn1.St_SupplierStock == stockListCndtn2.St_SupplierStock)
        //         && (stockListCndtn1.Ed_SupplierStock == stockListCndtn2.Ed_SupplierStock)
        //         && (stockListCndtn1.St_TrustCount == stockListCndtn2.St_TrustCount)
        //         && (stockListCndtn1.Ed_TrustCount == stockListCndtn2.Ed_TrustCount)
        //         && (stockListCndtn1.St_ShipmentPosCnt == stockListCndtn2.St_ShipmentPosCnt)
        //         && (stockListCndtn1.Ed_ShipmentPosCnt == stockListCndtn2.Ed_ShipmentPosCnt)
        //         && (stockListCndtn1.St_LargeGoodsGanreCode == stockListCndtn2.St_LargeGoodsGanreCode)
        //         && (stockListCndtn1.Ed_LargeGoodsGanreCode == stockListCndtn2.Ed_LargeGoodsGanreCode)
        //         && (stockListCndtn1.St_MediumGoodsGanreCode == stockListCndtn2.St_MediumGoodsGanreCode)
        //         && (stockListCndtn1.Ed_MediumGoodsGanreCode == stockListCndtn2.Ed_MediumGoodsGanreCode)
        //         && (stockListCndtn1.St_DetailGoodsGanreCode == stockListCndtn2.St_DetailGoodsGanreCode)
        //         && (stockListCndtn1.Ed_DetailGoodsGanreCode == stockListCndtn2.Ed_DetailGoodsGanreCode)
        //         && (stockListCndtn1.St_EnterpriseGanreCode == stockListCndtn2.St_EnterpriseGanreCode)
        //         && (stockListCndtn1.Ed_EnterpriseGanreCode == stockListCndtn2.Ed_EnterpriseGanreCode)
        //         && (stockListCndtn1.St_BLGoodsCode == stockListCndtn2.St_BLGoodsCode)
        //         && (stockListCndtn1.Ed_BLGoodsCode == stockListCndtn2.Ed_BLGoodsCode)
        //         && (stockListCndtn1.St_LastStockDate == stockListCndtn2.St_LastStockDate)
        //         && (stockListCndtn1.Ed_LastStockDate == stockListCndtn2.Ed_LastStockDate)
        //         && (stockListCndtn1.St_LastSalesDate == stockListCndtn2.St_LastSalesDate)
        //         && (stockListCndtn1.Ed_LastSalesDate == stockListCndtn2.Ed_LastSalesDate)
        //         && (stockListCndtn1.St_LastInventoryUpdate == stockListCndtn2.St_LastInventoryUpdate)
        //         && (stockListCndtn1.Ed_LastInventoryUpdate == stockListCndtn2.Ed_LastInventoryUpdate)
        //         && (stockListCndtn1.St_StockCreateDate == stockListCndtn2.St_StockCreateDate)
        //         && (stockListCndtn1.Ed_StockCreateDate == stockListCndtn2.Ed_StockCreateDate)
        //         && (stockListCndtn1.StockDiv == stockListCndtn2.StockDiv)
        //         && (stockListCndtn1.ChangePageDiv == stockListCndtn2.ChangePageDiv)
        //         && (stockListCndtn1.ChangePageDivName == stockListCndtn2.ChangePageDivName)
        //         && (stockListCndtn1.StockPointWay == stockListCndtn2.StockPointWay));
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// �݌Ɉꗗ�\���o�����N���X��r����
        ///// </summary>
        ///// <param name="target">��r�Ώۂ�StockListCndtn�N���X�̃C���X�^���X</param>
        ///// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   StockListCndtn�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public ArrayList Compare(StockListCndtn target)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(this.DepositStockSecCodeList != target.DepositStockSecCodeList)resList.Add("DepositStockSecCodeList");
        //    if(this.St_GoodsMakerCd != target.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
        //    if(this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
        //    if(this.St_GoodsNo != target.St_GoodsNo)resList.Add("St_GoodsNo");
        //    if(this.Ed_GoodsNo != target.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
        //    if(this.St_WarehouseCode != target.St_WarehouseCode)resList.Add("St_WarehouseCode");
        //    if(this.Ed_WarehouseCode != target.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
        //    if(this.St_SupplierStock != target.St_SupplierStock)resList.Add("St_SupplierStock");
        //    if(this.Ed_SupplierStock != target.Ed_SupplierStock)resList.Add("Ed_SupplierStock");
        //    if(this.St_TrustCount != target.St_TrustCount)resList.Add("St_TrustCount");
        //    if(this.Ed_TrustCount != target.Ed_TrustCount)resList.Add("Ed_TrustCount");
        //    if(this.St_ShipmentPosCnt != target.St_ShipmentPosCnt)resList.Add("St_ShipmentPosCnt");
        //    if(this.Ed_ShipmentPosCnt != target.Ed_ShipmentPosCnt)resList.Add("Ed_ShipmentPosCnt");
        //    if(this.St_LargeGoodsGanreCode != target.St_LargeGoodsGanreCode)resList.Add("St_LargeGoodsGanreCode");
        //    if(this.Ed_LargeGoodsGanreCode != target.Ed_LargeGoodsGanreCode)resList.Add("Ed_LargeGoodsGanreCode");
        //    if(this.St_MediumGoodsGanreCode != target.St_MediumGoodsGanreCode)resList.Add("St_MediumGoodsGanreCode");
        //    if(this.Ed_MediumGoodsGanreCode != target.Ed_MediumGoodsGanreCode)resList.Add("Ed_MediumGoodsGanreCode");
        //    if(this.St_DetailGoodsGanreCode != target.St_DetailGoodsGanreCode)resList.Add("St_DetailGoodsGanreCode");
        //    if(this.Ed_DetailGoodsGanreCode != target.Ed_DetailGoodsGanreCode)resList.Add("Ed_DetailGoodsGanreCode");
        //    if(this.St_EnterpriseGanreCode != target.St_EnterpriseGanreCode)resList.Add("St_EnterpriseGanreCode");
        //    if(this.Ed_EnterpriseGanreCode != target.Ed_EnterpriseGanreCode)resList.Add("Ed_EnterpriseGanreCode");
        //    if(this.St_BLGoodsCode != target.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
        //    if(this.Ed_BLGoodsCode != target.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
        //    if(this.St_LastStockDate != target.St_LastStockDate)resList.Add("St_LastStockDate");
        //    if(this.Ed_LastStockDate != target.Ed_LastStockDate)resList.Add("Ed_LastStockDate");
        //    if(this.St_LastSalesDate != target.St_LastSalesDate)resList.Add("St_LastSalesDate");
        //    if(this.Ed_LastSalesDate != target.Ed_LastSalesDate)resList.Add("Ed_LastSalesDate");
        //    if(this.St_LastInventoryUpdate != target.St_LastInventoryUpdate)resList.Add("St_LastInventoryUpdate");
        //    if(this.Ed_LastInventoryUpdate != target.Ed_LastInventoryUpdate)resList.Add("Ed_LastInventoryUpdate");
        //    if(this.St_StockCreateDate != target.St_StockCreateDate)resList.Add("St_StockCreateDate");
        //    if(this.Ed_StockCreateDate != target.Ed_StockCreateDate)resList.Add("Ed_StockCreateDate");
        //    if(this.StockDiv != target.StockDiv)resList.Add("StockDiv");
        //    if(this.ChangePageDiv != target.ChangePageDiv)resList.Add("ChangePageDiv");
        //    if(this.ChangePageDivName != target.ChangePageDivName)resList.Add("ChangePageDivName");
        //    if(this.StockPointWay != target.StockPointWay)resList.Add("StockPointWay");

        //    return resList;
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// �݌Ɉꗗ�\���o�����N���X��r����
        ///// </summary>
        ///// <param name="stockListCndtn1">��r����StockListCndtn�N���X�̃C���X�^���X</param>
        ///// <param name="stockListCndtn2">��r����StockListCndtn�N���X�̃C���X�^���X</param>
        ///// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        ///// <remarks>
        ///// <br>Note�@�@�@�@�@�@ :   StockListCndtn�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        ///// <br>Programer        :   ��������</br>
        ///// </remarks>
        //public static ArrayList Compare(StockListCndtn stockListCndtn1, StockListCndtn stockListCndtn2)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(stockListCndtn1.EnterpriseCode != stockListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(stockListCndtn1.DepositStockSecCodeList != stockListCndtn2.DepositStockSecCodeList)resList.Add("DepositStockSecCodeList");
        //    if(stockListCndtn1.St_GoodsMakerCd != stockListCndtn2.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
        //    if(stockListCndtn1.Ed_GoodsMakerCd != stockListCndtn2.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
        //    if(stockListCndtn1.St_GoodsNo != stockListCndtn2.St_GoodsNo)resList.Add("St_GoodsNo");
        //    if(stockListCndtn1.Ed_GoodsNo != stockListCndtn2.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
        //    if(stockListCndtn1.St_WarehouseCode != stockListCndtn2.St_WarehouseCode)resList.Add("St_WarehouseCode");
        //    if(stockListCndtn1.Ed_WarehouseCode != stockListCndtn2.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
        //    if(stockListCndtn1.St_SupplierStock != stockListCndtn2.St_SupplierStock)resList.Add("St_SupplierStock");
        //    if(stockListCndtn1.Ed_SupplierStock != stockListCndtn2.Ed_SupplierStock)resList.Add("Ed_SupplierStock");
        //    if(stockListCndtn1.St_TrustCount != stockListCndtn2.St_TrustCount)resList.Add("St_TrustCount");
        //    if(stockListCndtn1.Ed_TrustCount != stockListCndtn2.Ed_TrustCount)resList.Add("Ed_TrustCount");
        //    if(stockListCndtn1.St_ShipmentPosCnt != stockListCndtn2.St_ShipmentPosCnt)resList.Add("St_ShipmentPosCnt");
        //    if(stockListCndtn1.Ed_ShipmentPosCnt != stockListCndtn2.Ed_ShipmentPosCnt)resList.Add("Ed_ShipmentPosCnt");
        //    if(stockListCndtn1.St_LargeGoodsGanreCode != stockListCndtn2.St_LargeGoodsGanreCode)resList.Add("St_LargeGoodsGanreCode");
        //    if(stockListCndtn1.Ed_LargeGoodsGanreCode != stockListCndtn2.Ed_LargeGoodsGanreCode)resList.Add("Ed_LargeGoodsGanreCode");
        //    if(stockListCndtn1.St_MediumGoodsGanreCode != stockListCndtn2.St_MediumGoodsGanreCode)resList.Add("St_MediumGoodsGanreCode");
        //    if(stockListCndtn1.Ed_MediumGoodsGanreCode != stockListCndtn2.Ed_MediumGoodsGanreCode)resList.Add("Ed_MediumGoodsGanreCode");
        //    if(stockListCndtn1.St_DetailGoodsGanreCode != stockListCndtn2.St_DetailGoodsGanreCode)resList.Add("St_DetailGoodsGanreCode");
        //    if(stockListCndtn1.Ed_DetailGoodsGanreCode != stockListCndtn2.Ed_DetailGoodsGanreCode)resList.Add("Ed_DetailGoodsGanreCode");
        //    if(stockListCndtn1.St_EnterpriseGanreCode != stockListCndtn2.St_EnterpriseGanreCode)resList.Add("St_EnterpriseGanreCode");
        //    if(stockListCndtn1.Ed_EnterpriseGanreCode != stockListCndtn2.Ed_EnterpriseGanreCode)resList.Add("Ed_EnterpriseGanreCode");
        //    if(stockListCndtn1.St_BLGoodsCode != stockListCndtn2.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
        //    if(stockListCndtn1.Ed_BLGoodsCode != stockListCndtn2.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
        //    if(stockListCndtn1.St_LastStockDate != stockListCndtn2.St_LastStockDate)resList.Add("St_LastStockDate");
        //    if(stockListCndtn1.Ed_LastStockDate != stockListCndtn2.Ed_LastStockDate)resList.Add("Ed_LastStockDate");
        //    if(stockListCndtn1.St_LastSalesDate != stockListCndtn2.St_LastSalesDate)resList.Add("St_LastSalesDate");
        //    if(stockListCndtn1.Ed_LastSalesDate != stockListCndtn2.Ed_LastSalesDate)resList.Add("Ed_LastSalesDate");
        //    if(stockListCndtn1.St_LastInventoryUpdate != stockListCndtn2.St_LastInventoryUpdate)resList.Add("St_LastInventoryUpdate");
        //    if(stockListCndtn1.Ed_LastInventoryUpdate != stockListCndtn2.Ed_LastInventoryUpdate)resList.Add("Ed_LastInventoryUpdate");
        //    if(stockListCndtn1.St_StockCreateDate != stockListCndtn2.St_StockCreateDate)resList.Add("St_StockCreateDate");
        //    if(stockListCndtn1.Ed_StockCreateDate != stockListCndtn2.Ed_StockCreateDate)resList.Add("Ed_StockCreateDate");
        //    if(stockListCndtn1.StockDiv != stockListCndtn2.StockDiv)resList.Add("StockDiv");
        //    if(stockListCndtn1.ChangePageDiv != stockListCndtn2.ChangePageDiv)resList.Add("ChangePageDiv");
        //    if(stockListCndtn1.ChangePageDivName != stockListCndtn2.ChangePageDivName)resList.Add("ChangePageDivName");
        //    if(stockListCndtn1.StockPointWay != stockListCndtn2.StockPointWay)resList.Add("StockPointWay");

        //    return resList;
        //}
        //--- DEL 2008.08.01 ----------<<<<<


        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ���ԊǗ��L�����̎擾����
        ///// </summary>
        ///// <param name="targetDateState">���ԊǗ��L�����̃X�e�[�^�X</param>
        ///// <returns>���ԊǗ��L������</returns>
        ///// <remarks>
        ///// <br>Note       : ���ԊǗ��L�����̂̎擾���s���܂��B</br>
        ///// <br>Programmer : 23010 �����@�m</br>
        ///// <br>Date       : 2007.03.20</br>
        ///// </remarks>
        //public static string GetPrdNumMngDivName( int targetDateState )
        //{
        //    string targetDateName = "";
        //    switch( targetDateState ) {
        //        case 0:
        //        {
        //            targetDateName = "��";
        //            break;
        //        }
        //        case 1:
        //        {
        //            targetDateName = "�L";
        //            break;
        //        }
        //    }
        //    return targetDateName;
        //}
        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// �\�[�g���̎擾����
		/// </summary>
		/// <param name="targetDateState">�\�[�g���̃X�e�[�^�X</param>
		/// <returns>�\�[�g����</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public static string GetSortName( int targetDateState )
		{
			string targetDateName = "";
			switch( targetDateState ) {
                //--- DEL 2008/08/01 ---------->>>>>
                //case ( int )PageChangeDiv.Sort_StockDate:
                //{
                //    targetDateName = "�ŏI�d������";
                //    break;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 �C�� >>>>>>>>>>>>>>>>>>>>
				//case ( int )PageChangeDiv.Sort_CarrierCode:
				//{
				//	targetDateName = "�L�����A��";
				//	break;
				//}
                //case ( int )PageChangeDiv.Sort_LargeMediumGoodsGanreCode:
				//{
				//	targetDateName = "���i�敪�O���[�v�E�敪��";
				//	break;
				//}
                //--- DEL 2008/08/01 ---------->>>>>
                //case (int)PageChangeDiv.Sort_LargeGoodsGanreCode:
                //{
                //    targetDateName = "���i�敪�O���[�v�E�敪�E�ڍ׋敪��";
                //    break;
                //}
                //case (int)PageChangeDiv.Sort_WarehouseCode:
                //{
                //    targetDateName = "�q�ɏ�";
                //    break;
                //}
                //case ( int )PageChangeDiv.Sort_EnterpriseGanreCode:
                //{
                //    targetDateName = "���Е��ޏ�";
                //    break;
                //}
                //case ( int )PageChangeDiv.Sort_BLGoodsCode:
                //{
                //    targetDateName = "�a�k�R�[�h��";
                //    break;
                //}
                //// 2007.10.05 �C�� <<<<<<<<<<<<<<<<<<<<
                //case ( int )PageChangeDiv.Sort_MakerCode:
                //{
                //    targetDateName = "���[�J�[��";
                //    break;
                //}
                //case ( int )PageChangeDiv.Sort_ShipmentPosCnt:
                //{
                //    targetDateName = "�o�׉\����";
                //    break;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                //case ( int )PageChangeDiv.Sort_CellPhoneModeleCode:
				//{
				//	targetDateName = "�@�폇";
				//	break;
				//}
                // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                //--- ADD 2008/08/01 ---------->>>>>
                case (int)PageChangeDiv.Sort_SupplierCode:
                {
                    targetDateName = "�d���揇";
                    break;
                }
                case (int)PageChangeDiv.Sort_WarehouseCode:
                {
                    targetDateName = "�I�ԏ�";
                    break;
                }
                //--- ADD 2008/08/01 ----------<<<<<

			}
			return targetDateName;
		}
                                   
        /// <summary>
		/// �\�[�g�v���̎擾����
		/// </summary>
		/// <param name="targetDateState">�\�[�g���̃X�e�[�^�X</param>
		/// <returns>�\�[�g�v����</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g�v���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public static string GetSortTotalName( int targetDateState )
		{
			string targetDateName = "";
			switch( targetDateState ) {
				case ( int )PageChangeDivTitle.Sort_StockDateTitle:
				{
					targetDateName = "�ŏI�d�����v";
					break;
				}
                // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                //case (int)PageChangeDivTitle.Sort_CarrierTitle:
                //{
                //	targetDateName = "�L�����A�v";
                //	break;
                //}
                // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                case (int)PageChangeDivTitle.Sort_LargeGoodsGanreTitle:
				{
					targetDateName = "���i�敪�O���[�v�v";
					break;
				}
                case ( int )PageChangeDivTitle.Sort_MakerTitle:
				{
					targetDateName = "���[�J�[�v";
					break;
				}
                // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
                //case (int)PageChangeDivTitle.Sort_CellPhoneModeleCodeTitle:
                //{
                //	targetDateName = "�@��v";
                //	break;
                //}
                // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<
                case (int)PageChangeDivTitle.Sort_ShipmentPosCntTitle:
				{
					targetDateName = "�o�׉\���v";
					break;
				}
                case ( int )PageChangeDivTitle.Sort_MediumGoodsGanreTitle:
				{
					targetDateName = "���i�敪�v";
					break;
				}
                // 2007.10.05 �ǉ� >>>>>>>>>>>>>>>>>>>>
                case (int)PageChangeDivTitle.Sort_DetailGoodsGanreTitle:
                {
                    targetDateName = "���i�敪�ڍ׌v";
                    break;
                }
                case (int)PageChangeDivTitle.Sort_EnterpriseGanreTitle:
                {
                    targetDateName = "���Е��ތv";
                    break;
                }
                case (int)PageChangeDivTitle.Sort_BLGoodsTitle:
                {
                    targetDateName = "�a�k�R�[�h�v";
                    break;
                }
                case (int)PageChangeDivTitle.Sort_WarehouseTitle:
                {
                    targetDateName = "�q�Ɍv";
                    break;
                }
                // 2007.10.05 �ǉ� <<<<<<<<<<<<<<<<<<<<
        }
			return targetDateName;
		}


        // 2007.10.05 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
		///// �݌ɏ�Ԏ擾����
		///// </summary>
		///// <param name="targetDateState">�݌ɏ�ԃX�e�[�^�X</param>
		///// <returns>�݌ɏ��</returns>
		///// <remarks>
		///// <br>Note       : �݌ɏ�Ԃ̎擾���s���܂��B</br>
		///// <br>Programmer : 23010 �����@�m</br>
		///// <br>Date       : 2007.03.16</br>
		///// </remarks>
		//public static int GetStockDiv( int targetDateState )
		//{
		//	int targetStockDiv = -1;
		//	switch( targetDateState ) {
		//		case 0:
		//		{
        //            //�S��
		//			targetStockDiv = (int)StockDivStatus.StockDiv_ALLStock;
		//			break;
		//		}
		//		case 1:
		//		{
        //            //�d���݌ɕ�
		//			targetStockDiv = (int)StockDivStatus.StockDiv_MyStock;
		//			break;
		//		}
        //        case 2:
		//		{
        //            //����݌ɕ�
        //			targetStockDiv = (int)StockDivStatus.StockDiv_TrustStock;
        //			break;
        //		}               
        //	}
        //	return targetStockDiv;
        //}
        // 2007.10.05 �폜 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// �݌ɋ敪���̎擾����
		/// </summary>
		/// <param name="targetDateState">�݌ɋ敪���̃X�e�[�^�X</param>
		/// <returns>�݌ɋ敪����</returns>
		/// <remarks>
		/// <br>Note       : �݌ɋ敪���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23010 �����@�m</br>
		/// <br>Date       : 2007.03.16</br>
		/// </remarks>
		public static string GetStockDivName( int targetDateState )
		{
			string targetDateName = "";
			switch( targetDateState ) {
				case ( int )StockDivStatus.StockDiv_ALLStock:
				{
					targetDateName = "�S��";
					break;
				}
				case ( int )StockDivStatus.StockDiv_MyStock:
				{
					targetDateName = "�d���݌ɕ�";
					break;
				}
                case ( int )StockDivStatus.StockDiv_TrustStock:
				{
					targetDateName = "����݌ɕ�";
					break;
				}              
			}
			return targetDateName;
		}

        #endregion
    }
}
