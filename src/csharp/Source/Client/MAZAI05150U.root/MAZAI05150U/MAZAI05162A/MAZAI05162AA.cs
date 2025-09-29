//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �I���ߕs���X�V
// �v���O�����T�v   : �I���ߕs���X�V�Ŏg�p����f�[�^�̎擾�E�X�V���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ȓ��@����Y
// �� �� ��  2007/07/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/02/26  �C�����e : �d�l�ύX�Ή��iDC.NS�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/03/26  �C�����e : NetAdvantage�o�[�W�����A�b�v�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2008/09/10  �C�����e : �d�l�ύX�Ή��iPartsman�Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/04/28  �C�����e : �s��Ή�[13091]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/05/22  �C�����e : �s��Ή�[13243][13263]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���n
// �C �� ��  2009/09/14  �C�����e : �s��Ή�[13921]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/12/03  �C�����e : PM.NS�@�ێ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/01/28  �C�����e : Mantis:14949 ���ꋒ�_����ʔԂŒI�ԈႢ�̃f�[�^������ƕs����N���錏�ɂ��Ă̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : �k���r
// �� �� ��  2010/02/23  �C�����e : PM1005�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS
// �� �� ��  2011/01/11  �C�����e : �I����Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : yangyi
// �C �� ��  2012/07/19  �C�����e : redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00 �쐬�S�� : yangyi
// �C �� ��  2013/10/09  �C�����e : redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : ��
// �C �� ��  K2015/08/21  �C�����e : redmine#46790  �I���ߕs���X�V�@�������A�E�g�̏C��
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
//using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �I���ߕs���X�V�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I���ߕs���X�V�̃A�N�Z�X�N���X�ł��B</br>
	/// <br>Programmer : 980076 �Ȓ��@����Y</br>
	/// <br>Date       : 2007.07.10</br>
    /// <br>Update Note: 2008.02.26 980035 ���� ��`</br>
    /// <br>			 �E�d�l�ύX�Ή��iDC.NS�Ή��j</br>
    /// <br>Update Note: 2008.03.26 980035 ���� ��`</br>
    /// <br>			 �ENetAdvantage�o�[�W�����A�b�v�Ή�</br>
    /// <br>Update Note: 2008/09/10 30414 �E �K�j</br>
    /// <br>			 �E�d�l�ύX�Ή��iPartsman�Ή��j</br>
    /// <br>           : 2009/04/28       �Ɠc �M�u�@�s��Ή�[13091]</br>
    /// <br>           : 2009/05/22       �Ɠc �M�u�@�s��Ή�[13243][13263]</br>
    /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
    /// <br>UpdateNote : 2010/02/23 �k���r PM1005</br>
    /// <br>Update Note: 2012/07/19 yangyi</br>
    /// <br>             redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���</br>
    /// <br>Update Note: K2015/08/21 ��</br>
    /// <br>             redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C��</br>
    /// </remarks>
	public partial class InventoryUpdateAcs
	{
		public InventoryUpdateAcs()
		{
			this._iInventInputSearchDB = MediationInventInputSearchDB.GetInventInputSearchDB();
			this._iStockAdjustDB = MediationStockAdjustDB.GetStockAdjustDB();
			this._dataSet = new InventoryUpdateDataSet();
			this._inventoryDataDictionary = new Dictionary<string, InventoryDataUpdateWork>();

            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			this._searchStochAch = new SearchStockAcs();
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            this._warehouseAcs = new WarehouseAcs();
            this._goodsAcs = new GoodsAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            // ----- ADD 2012/07/19 ---------->>>>>
            this._totalDayDic = new Dictionary<string, DateTime>();
            this._goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
            // ----- ADD 2012/07/19 ----------<<<<<

            // �}�X�^�Ǎ�
            LoadSecInfoSet();
            LoadWarehouse();
            LoadMakerUMnt();
            LoadBLGoodsCdUMnt();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisMonthly();
            // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

            // ---ADD 2009/05/22 �s��Ή�[13263] -------------------------------------->>>>>
            this._stockMngTtlStAcs = new StockMngTtlStAcs();        //�݌ɑS�̐ݒ�}�X�^�A�N�Z�X

            // �݌ɑS�̐ݒ���擾
            this.ReadStockMngTtlSt();
            // ---ADD 2009/05/22 �s��Ή�[13263] --------------------------------------<<<<<
        }

		IInventInputSearchDB _iInventInputSearchDB;
		IStockAdjustDB _iStockAdjustDB;
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private static StockMngTtlSt _stockMngTtlSt;
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        private InventoryUpdateDataSet _dataSet;
		private Dictionary<string, InventoryDataUpdateWork> _inventoryDataDictionary;

        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private SearchStockAcs _searchStochAch;
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        
        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        private WarehouseAcs _warehouseAcs;
        private GoodsAcs _goodsAcs;
        private SecInfoAcs _secInfoAcs;
        private MakerAcs _makerAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        // ----- ADD 2012/07/19 ---------->>>>>
        private Dictionary<string, DateTime> _totalDayDic;
        private Dictionary<string, GoodsUnitData> _goodsUnitDataDic;
        // ----- ADD 2012/07/19 ----------<<<<<

        /// <summary>�����Z�o���W���[��</summary>
        private TotalDayCalculator _totalDayCalculator = null;
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        // ---ADD 2009/05/22 �s��Ή�[13263] -------------------------------------->>>>>
        private StockMngTtlStAcs _stockMngTtlStAcs = null;              //�݌ɑS�̐ݒ�}�X�^�A�N�Z�X
        private StockMngTtlSt _stockMngTtlSt = null;                    //�݌ɊǗ��S�̐ݒ�
        // ---ADD 2009/05/22 �s��Ή�[13263] -------------------------------------->>>>>

        private Dictionary<string, List<GoodsPriceUWork>> _dicPriceList;  //ADD yangyi 2013/10/09 Redmine#31106 

        public InventoryUpdateDataSet DataSet
		{
			get { return _dataSet; }
		}

		public DataView DataView
		{
			get
			{
				return this._dataSet.Inventory.DefaultView; 
			}
		}

		public DataView ErrorDataView
		{
			get
			{
				return this._dataSet.ErrorData.DefaultView;
			}
        }

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �I���f�[�^���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="inventoryDay">���{��</param>
		/// <param name="difCntExtraDiv">0:�S�ĕ\�� 1:�ߕs���������̂ݕ\��</param>
		/// <returns>STATUS</returns>
        // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
        //public int Search(string sectionCode, DateTime inventoryDaySta, DateTime inventoryDayEnd, int difCntExtraDiv)
        public int Search(string sectionCode, DateTime inventoryDaySta, DateTime inventoryDayEnd, int difCntExtraDiv, 
                          string warehouseCdSta, string warehouseCdEnd, string shelfNoSta, string shelfNoEnd)
        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
		{
			this._dataSet.Inventory.DefaultView.RowFilter = "";
			this._dataSet.Inventory.Rows.Clear();
			
			this._dataSet.ErrorData.Rows.Clear();
			this._dataSet.ErrorData.DefaultView.RowFilter = "";

			this._dataSet.InventoryNumberInfo.Rows.Clear();

			this._inventoryDataDictionary.Clear();

			InventInputSearchCndtnWork para = new InventInputSearchCndtnWork();
			para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
            //para.St_InventoryDay = inventoryDaySta;
            para.InventoryDate = inventoryDaySta;
            // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2008.02.26 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (para.St_InventoryDay == DateTime.MinValue)
            //{
            //    para.St_InventoryDay = para.St_InventoryDay.AddDays(1);
            //}

            //para.Ed_InventoryDay = inventoryDayEnd;
            // 2008.02.26 �폜 <<<<<<<<<<<<<<<<<<<<
            para.SectionCode = sectionCode;
			para.DifCntExtraDiv = 0;
			para.St_InventorySeqNo = 0;
			para.Ed_InventorySeqNo = 999999;
            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //para.CompanyStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;
			//para.TrustStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;
			//para.EntrustCmpStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;
			//para.EntrustTrtStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //para.Ed_CarrierCode = Int32.MaxValue;
			//para.Ed_CarrierEpCode = Int32.MaxValue;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            para.Ed_MakerCode = Int32.MaxValue;
			para.Ed_CustomerCode = Int32.MaxValue;
			para.Ed_ShipCustomerCode = Int32.MaxValue;

			para.Ed_LargeGoodsGanreCode = "";
			para.Ed_MediumGoodsGanreCode = "";
			para.St_LargeGoodsGanreCode = "";
			para.St_MediumGoodsGanreCode = "";

			para.StockCntZeroExtraDiv = 0;
			para.St_InventoryPreprDay = DateTime.MinValue;
			para.Ed_InventoryPreprDay = DateTime.MinValue;
			para.IvtStkCntZeroExtraDiv = 0;	// �S��
            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //para.GrossPrintDiv = 0;			// ���ԒP��
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            para.SelectedPaperKind = -1;	// �I���L���\
			para.TargetDateExtraDiv = -1;	// �I�������������t

            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            para.St_WarehouseCode = warehouseCdSta;
			para.Ed_WarehouseCode = warehouseCdEnd;
			para.St_WarehouseShelfNo = shelfNoSta;
			para.Ed_WarehouseShelfNo = shelfNoEnd;
            para.St_DetailGoodsGanreCode = "";
            para.Ed_DetailGoodsGanreCode = "";

            para.Ed_EnterpriseGanreCode = Int32.MaxValue;
            para.Ed_BLGoodsCode = Int32.MaxValue;
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2008.02.26 �ǉ� >>>>>>>>>>>>>>>>>>>>
            para.CalcStockAmountDiv  = 1;                   // �݌ɐ��Z�o�t���O
            para.CalcStockAmountDate = DateTime.MinValue;   // �݌ɐ��Z�o���t
            // 2008.02.26 �ǉ� <<<<<<<<<<<<<<<<<<<<

			object retObj;
            int status = this._iInventInputSearchDB.Search(out retObj, (object)para, 0, ConstantManagement.LogicalMode.GetData0);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (ArrayList retArray in (ArrayList)retObj)
				{
					// �߂胊�X�g�̗v�f�̌^��InventoryDataUpdateWork�Ȃ�΃f�[�^�W�J
					if ((retArray.Count > 0) && (retArray[0] is InventoryDataUpdateWork))
					{
						foreach (InventoryDataUpdateWork data in retArray)
						{
							this.Cache(data);
						}
					}
				}

				this.Filtering(difCntExtraDiv);
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //this._dataSet.Inventory.DefaultView.Sort = this._dataSet.Inventory.WarehouseCodeColumn.ColumnName + " , " + this._dataSet.Inventory.GoodsCodeColumn.ColumnName + " , " + this._dataSet.Inventory.ProductNumberColumn.ColumnName;
                this._dataSet.Inventory.DefaultView.Sort = this._dataSet.Inventory.WarehouseCodeColumn.ColumnName + " , " + this._dataSet.Inventory.GoodsNoColumn.ColumnName + " , " + this._dataSet.Inventory.InventorySeqNoColumn.ColumnName;
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            }
			return status;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���_�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void LoadSecInfoSet()
        {
            try
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

                foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// �q�Ƀ}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �q�Ƀ}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void LoadWarehouse()
        {
            try
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();

                ArrayList retList;

                int status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J�[�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            try
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();

                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// BL�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void LoadBLGoodsCdUMnt()
        {
            try
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.PadLeft(2, '0')))
            {
                sectionName = this._secInfoSetDic[sectionCode.PadLeft(2, '0')].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// �q�ɖ��̎擾����
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <returns>�q�ɖ���</returns>
        /// <remarks>
        /// <br>Note       : �q�ɖ��̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        public string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseDic.ContainsKey(warehouseCode))
            {
                warehouseName = this._warehouseDic[warehouseCode].WarehouseName.Trim();
            }

            return warehouseName;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>BK�R�[�h����</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsFullName.Trim();
            }

            return blGoodsName;
        }

        /// <summary>
        /// �i���擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>�i��</returns>
        /// <remarks>
        /// <br>Note       : �i�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2012/07/19 yangyi</br>
        /// <br>             redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���</br>
        /// </remarks>
        private string GetGoodsName(int makerCode, string goodsNo)
        {
            // ----- ADD 2012/07/19 ---------->>>>>
            string goodsName = "";
            string key = LoginInfoAcquisition.EnterpriseCode + "_" + makerCode.ToString() + "_" + goodsNo;
            if (this._goodsUnitDataDic.ContainsKey(key))
            {
                goodsName = this._goodsUnitDataDic[key].GoodsName.Trim();
            }
            else
            {
            // ----- ADD 2012/07/19 ----------<<<<<
                try
                {
                    GoodsUnitData goodsUnitData;

                    int status = this._goodsAcs.Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);
                    if (status == 0)
                    {
                        goodsName = goodsUnitData.GoodsName.Trim();
                        _goodsUnitDataDic.Add(key, goodsUnitData); // ADD 2012/07/19
                    }
                }
                catch
                {
                    goodsName = "";
                }
            }   // ADD 2012/07/19

            return goodsName;
        }

        private double GetListPriceFl(int makerCode, string goodsNo, DateTime targetDate)
        {
            double listPriceFl = 0;
            // ----- ADD 2012/07/19 ---------->>>>>
            string key = LoginInfoAcquisition.EnterpriseCode + "_" + makerCode.ToString() + "_" + goodsNo;
            if (this._goodsUnitDataDic.ContainsKey(key))
            {
                GoodsUnitData goodsUnitData = null;
                goodsUnitData = this._goodsUnitDataDic[key];
                GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
                listPriceFl = goodsPrice.ListPrice;
            }
            else
            {
            // ----- ADD 2012/07/19 ----------<<<<<
                try
                {
                    GoodsUnitData goodsUnitData;

                    int status = this._goodsAcs.Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);
                    if (status == 0)
                    {
                        GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
                        listPriceFl = goodsPrice.ListPrice;
                        _goodsUnitDataDic.Add(key, goodsUnitData); // ADD 2012/07/19
                    }
                }
                catch
                {
                    listPriceFl = 0;
                }
            }       // ADD 2012/07/19

            return listPriceFl;
        }

        // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
        private double GetListPriceFl2(int makerCode, string goodsNo, DateTime targetDate)
        {
            double listPriceFl = 0;

            string keyStr = goodsNo + "," + makerCode.ToString();

            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (this._dicPriceList.ContainsKey(keyStr))
            {
                foreach (GoodsPriceUWork work in _dicPriceList[keyStr])
                {
                    GoodsPrice goodsPrice = new GoodsPrice();
                    goodsPrice.ListPrice = work.ListPrice;
                    goodsPrice.PriceStartDate = work.PriceStartDate;
                    goodsPriceList.Add(goodsPrice);
                }
                GoodsPrice retGoodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsPriceList);
                if (retGoodsPrice !=null)
                {
                    listPriceFl = retGoodsPrice.ListPrice;
                }
            }
            else
            {
                listPriceFl = 0;
            }

            return listPriceFl;
        }
        // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<

        /// <summary>
        /// �I���f�[�^��������
        /// </summary>
        /// <param name="inventInputSearchCndtn">�I���f�[�^���������N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>UpdateNote : 2010/02/23 �k���r �f�[�^���o���ɁA���i�}�X�^�̑��݃`�F�b�N���s�������ΏۊO�Ƃ���悤�ɕύX����</br>
        /// <br>Update Note: 2013/10/09 yangyi</br>
        /// <br>�Ǘ��ԍ�   : 10904597-00 PM1301E(���x�����j</br>
        /// <br>           : Redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���
        /// </remarks>
        public int Search(InventInputSearchCndtn inventInputSearchCndtn)
        {
            this._dataSet.Inventory.DefaultView.RowFilter = "";
            this._dataSet.Inventory.Rows.Clear();

            this._dataSet.ErrorData.Rows.Clear();
            this._dataSet.ErrorData.DefaultView.RowFilter = "";

            this._dataSet.InventoryNumberInfo.Rows.Clear();

            this._inventoryDataDictionary.Clear();

            // �N���X�����o�R�s�[����
            InventInputSearchCndtnWork para = CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(inventInputSearchCndtn);

            object retObj;
            //int status = this._iInventInputSearchDB.Search(out retObj, (object)para, 0, ConstantManagement.LogicalMode.GetData0); //DEL yangyi 2013/10/09 Redmine#31106

            // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
            object retObjDic;
            int status = this._iInventInputSearchDB.SearchInvent(out retObj, (object)para, 0, ConstantManagement.LogicalMode.GetData0, out retObjDic);

            this._dicPriceList = new Dictionary<string,List<GoodsPriceUWork>>();
            if (retObjDic != null)
            {
                this._dicPriceList = retObjDic as Dictionary<string, List<GoodsPriceUWork>>;
            }
            // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (ArrayList retArray in (ArrayList)retObj)
                {
                    // �߂胊�X�g�̗v�f�̌^��InventoryDataUpdateWork�Ȃ�΃f�[�^�W�J
                    if ((retArray.Count > 0) && (retArray[0] is InventoryDataUpdateWork))
                    {
                        foreach (InventoryDataUpdateWork data in retArray)
                        {
                            //Cache(data); // DEL 2009/12/03

                            // --- ADD 2009/12/03 ---------->>>>>
                            // --- UPD 2010/02/23 ----------<<<<<
                            // �ߕs���X�V�敪=0:���X�V�ꍇ
                            // ���i�}�X�^�����o�^���́A�_���폜�̏ꍇ
                            //if (data.ToleranceUpdateCd == 0)
                            //if (data.ToleranceUpdateCd == 0 && data.GoodsDiv == 0) // DEL 2011/01/11
                            // --- UPD 2010/02/23 ----------<<<<<
                            if (data.ToleranceUpdateCd == 0 && data.GoodsDiv == 0 && !"���޼".Equals(data.WarehouseShelfNo) && !"���޼".Equals(data.WarehouseShelfNo)) // ADD 2011/01/11
                            {
                                // �f�[�^�e�[�u���L���b�V��
                                Cache(data);
                            }
                            // --- ADD 2009/12/03 ----------<<<<<
                        }
                    }
                }

                // �t�B���^�����O
                Filtering(inventInputSearchCndtn.DifCntExtraDiv);
                this._dataSet.Inventory.DefaultView.Sort = this._dataSet.Inventory.WarehouseCodeColumn.ColumnName + " , " + 
                                                           this._dataSet.Inventory.GoodsNoColumn.ColumnName + " , " + 
                                                           this._dataSet.Inventory.InventorySeqNoColumn.ColumnName;
            }
            return status;
        }
        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
        /// <summary>
        /// �I���f�[�^�����Ɖߕs���X�V����
        /// </summary>
        /// <param name="inventInputSearchCndtn">�I���f�[�^���������N���X</param>
        /// <param name="shelfNoDiv">�I�ԍX�V�敪</param>
        /// <param name="isSaved">�ۑ��t���O</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        public int SearchAndUpdate(InventInputSearchCndtn inventInputSearchCndtn, int shelfNoDiv, out bool isSaved, out string message)
        {
            isSaved = false;
            message = string.Empty;
            // �N���X�����o�쐬����
            InventInputUpdateCndtnWork inventInputUpdateCndtnWork = CreateInventInputUpdateCndtnWork(shelfNoDiv);
            int status = -1;
            // �N���X�����o�R�s�[����
            InventInputSearchCndtnWork para = CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(inventInputSearchCndtn);

            Dictionary<string, string> secDic = new Dictionary<string,string>();
            Dictionary<string, string> wareDic = new Dictionary<string, string>();
            Dictionary<int, string> makerDic = new Dictionary<int, string>();
            Dictionary<int, string> blGoodsDic = new Dictionary<int, string>();
            //���_���̂��擾
            foreach (string key in _secInfoSetDic.Keys)
            {
                secDic.Add(key, _secInfoSetDic[key].SectionGuideNm.Trim());
            }
            //�q�ɖ��̂��擾
            foreach (string key in _warehouseDic.Keys)
            {
                wareDic.Add(key, _warehouseDic[key].WarehouseName.Trim());
            }

            //���[�J���̂��擾
            foreach (int key in _makerUMntDic.Keys)
            {
                makerDic.Add(key, _makerUMntDic[key].MakerName.Trim());
            }

            //BL���i���̂��擾
            foreach (int key in _blGoodsCdUMntDic.Keys)
            {
                blGoodsDic.Add(key, _blGoodsCdUMntDic[key].BLGoodsFullName.Trim());
            }
            // �I���f�[�^�����Ɖߕs���X�V����
            status = this._iStockAdjustDB.SearchInventAndUpdate((object)para, (object)inventInputUpdateCndtnWork, out isSaved, (object)secDic, (object)wareDic, (object)makerDic, (object)blGoodsDic, out message);           
            return status;            
        }

        /// <summary>
        /// �ߕs���X�V�����N���X�����o�쐬����
        /// </summary>
        /// <returns>inventUpdateWork</returns>
        /// <remarks>
        /// <br>Note       : �ߕs���X�V�����N���X�����o�쐬</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private InventInputUpdateCndtnWork CreateInventInputUpdateCndtnWork(int shelfNoDiv)
        {
            InventInputUpdateCndtnWork inventUpdateWork = new InventInputUpdateCndtnWork();
            // �I���^�p�敪
            inventUpdateWork.InventoryMngDiv = _stockMngTtlSt.InventoryMngDiv;
            // �[�������敪
            inventUpdateWork.FractionProcCd = _stockMngTtlSt.FractionProcCd;
            // ��ƃR�[�h
            inventUpdateWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �]�ƈ�����
            inventUpdateWork.EmployeeName = LoginInfoAcquisition.Employee.Name;
            // ���_�R�[�h
            inventUpdateWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // �]�ƈ��R�[�h
            inventUpdateWork.EmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
            // �I�ԍX�V�敪
            inventUpdateWork.ShelfNoDiv = shelfNoDiv;

            return inventUpdateWork;
        }
        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<

        /// <summary>
        /// �N���X�����o�R�s�[����(E��D)
        /// </summary>
        /// <param name="extrInfo">�I���f�[�^���������N���X</param>
        /// <returns>�I���f�[�^�����������[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^���������N���X��I���f�[�^�����������[�N�N���X�ɃR�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private InventInputSearchCndtnWork CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(InventInputSearchCndtn extrInfo)
        {
            InventInputSearchCndtnWork inventInputSearchCndtnWork = new InventInputSearchCndtnWork();
            // ��ƃR�[�h
            inventInputSearchCndtnWork.EnterpriseCode = extrInfo.EnterpriseCode;
            // ���ٕ����o�敪        
            inventInputSearchCndtnWork.DifCntExtraDiv = 2;
            // ���_�R�[�h
            inventInputSearchCndtnWork.St_SectionCode = extrInfo.St_SectionCode;
            inventInputSearchCndtnWork.Ed_SectionCode = extrInfo.Ed_SectionCode;
            // �q�ɃR�[�h
            inventInputSearchCndtnWork.St_WarehouseCode = extrInfo.St_WarehouseCode;
            inventInputSearchCndtnWork.Ed_WarehouseCode = extrInfo.Ed_WarehouseCode;
            // �I��
            inventInputSearchCndtnWork.St_WarehouseShelfNo = extrInfo.St_WarehouseShelfNo;
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = extrInfo.Ed_WarehouseShelfNo;
            // �d����R�[�h
            inventInputSearchCndtnWork.St_SupplierCd = extrInfo.St_SupplierCd;
            inventInputSearchCndtnWork.Ed_SupplierCd = extrInfo.Ed_SupplierCd;
            // BL�R�[�h
            inventInputSearchCndtnWork.St_BLGoodsCode = extrInfo.St_BLGoodsCode;
            inventInputSearchCndtnWork.Ed_BLGoodsCode = extrInfo.Ed_BLGoodsCode;
            // �O���[�v�R�[�h
            inventInputSearchCndtnWork.St_BLGroupCode = extrInfo.St_BLGroupCode;
            inventInputSearchCndtnWork.Ed_BLGroupCode = extrInfo.Ed_BLGroupCode;
            // ���[�J�[�R�[�h
            inventInputSearchCndtnWork.St_MakerCode = extrInfo.St_MakerCode;
            inventInputSearchCndtnWork.Ed_MakerCode = extrInfo.Ed_MakerCode;
            // �ʔ�
            inventInputSearchCndtnWork.St_InventorySeqNo = extrInfo.St_InventorySeqNo;
            inventInputSearchCndtnWork.Ed_InventorySeqNo = extrInfo.Ed_InventorySeqNo;
            // �I����
            inventInputSearchCndtnWork.InventoryDate = extrInfo.InventoryDate;
            // �݌ɐ��Z�o�t���O
            inventInputSearchCndtnWork.CalcStockAmountDiv = 1;
            //
            // �Œ荀�� (�����[�g�ł͖��������) ------------------------------------------------------------
            //
            // ���됔�[�����o�敪
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = 0;
            // �����������t
            inventInputSearchCndtnWork.St_InventoryPreprDay = DateTime.MinValue;
            inventInputSearchCndtnWork.Ed_InventoryPreprDay = DateTime.MinValue;
            // �I�������o�敪(�S��)
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = 0;
            // ���[���(�I���L���\)
            //inventInputSearchCndtnWork.SelectedPaperKind = -1;        //DEL 2009/05/22 �s��Ή�[13263]
            inventInputSearchCndtnWork.SelectedPaperKind = 0;           //ADD 2009/05/22 �s��Ή�[13263]
            // ���o�Ώۓ��t�敪(�I�������������t)
            inventInputSearchCndtnWork.TargetDateExtraDiv = -1;

            return inventInputSearchCndtnWork;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// �I���f�[�^��ۑ����܂��B
		/// </summary>
		/// <returns>STATUS</returns>
		public int Save(out bool isSaved, out string message, int shelfNoDiv)
		{
			isSaved = false;
			int status = -1;
			message = "";

			CustomSerializeArrayList saveData = this.CreateSaveData();
			object objSaveData = (object)saveData;

			if (saveData.Count == 0)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else
			{
                //status = this._iStockAdjustDB.WriteInventory(ref objSaveData, out message, shelfNoDiv); // �� DEL
                // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
                try
                {
                    status = this._iStockAdjustDB.WriteInventory(objSaveData, out message, shelfNoDiv);
                }
                catch (OutOfMemoryException)
                {
                    status = -100; // OutOfMemoryException
                }
                // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    isSaved = true;
                }

                // --- DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                //{
                //    foreach (Object data in (CustomSerializeArrayList)objSaveData)
                //    {
                //        if ((data is ArrayList) && ((ArrayList)data).Count > 0)
                //        {
                //            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //            //if (((ArrayList)data)[0] is ProductStockCommonPara)
                //            if (((ArrayList)data)[0] is InventoryUpdateDataSet.InventoryRow)
                //            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                //            {
                //                ArrayList productStockCommonParaList = (ArrayList)data;
                //                this.Cache(productStockCommonParaList);
                //            }
                //        }
                //    }

                //    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                //}
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                // --- DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<
            }

			return status;
        }

               #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �ߕs���X�V�̃G���[�`�F�b�N���s���܂��B
		/// </summary>
		/// <returns>STATUS</returns>
		public int ErrorCheck()
		{
			int status = -1;
			string message;

			CustomSerializeArrayList saveData = this.CreateSaveData();
			object objSaveData = (object)saveData;

			if (saveData.Count == 0)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else
			{
                //status = this._iStockAdjustDB.CheckInventory(ref objSaveData, out message);

				if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
				{
					foreach (Object data in (CustomSerializeArrayList)objSaveData)
					{
						if ((data is ArrayList) && ((ArrayList)data).Count > 0)
						{
                            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                            //if (((ArrayList)data)[0] is ProductStockCommonPara)
                            if (((ArrayList)data)[0] is InventoryUpdateDataSet.InventoryRow)
                            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                            {
								ArrayList productStockCommonParaList = (ArrayList)data;
								this.Cache(productStockCommonParaList);
							}
						}
					}
				}
				else
				{
					ArrayList productStockCommonParaList = new ArrayList();
					this.Cache(productStockCommonParaList);

					if (this._dataSet.ErrorData.Rows.Count > 0)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
					}
				}
			}

			return status;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �I�����f�[�^�e�[�u���̍s�����������܂��B
		/// </summary>
		public void Clear()
		{
			this._dataSet.Inventory.Rows.Clear();
			this._dataSet.ErrorData.Rows.Clear();
		}

		/// <summary>
		/// �t�B���^�����O����
		/// </summary>
		/// <param name="difCntExtraDiv">0:�S�ĕ\�� 1:�ߕs���������̂ݕ\��</param>
		public void Filtering(int difCntExtraDiv)
		{
			if (difCntExtraDiv == 0)
			{
				this._dataSet.Inventory.DefaultView.RowFilter = "";
			}
			else
			{
				this._dataSet.Inventory.DefaultView.RowFilter = this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName + " <> 0";
			}
		}

		/// <summary>
		/// �\���s�����擾���܂��B
		/// </summary>
		/// <returns>�\���s��</returns>
		public int GetViewRowCount()
		{
			return this._dataSet.Inventory.DefaultView.Count;
		}

		/// <summary>
		/// �s�����擾���܂��B
		/// </summary>
		/// <returns>�\���s��</returns>
		public int GetRowCount()
		{
			return this._dataSet.Inventory.Rows.Count;
        }

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �I���f�[�^�������ʃI�u�W�F�N�g���f�[�^�e�[�u���ɃL���b�V�����܂��B
		/// </summary>
		/// <param name="data">�I���f�[�^�������ʃI�u�W�F�N�g</param>
		private void Cache(InventoryDataUpdateWork data)
		{
            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //this._inventoryDataDictionary.Add(data.ProductStockGuid.ToString(), data);
            this._inventoryDataDictionary.Add(data.InventorySeqNo.ToString(), data);
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

			bool isNew = false;
			InventoryUpdateDataSet.InventoryRow row = this.RowFromUIData(data, out isNew);

			if (isNew)
			{
				_dataSet.Inventory.AddInventoryRow(row);
			}

            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //if (data.ProductNumber.Trim() != "")
            if (data.InventorySeqNo != 0)
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            {
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //InventoryUpdateDataSet.ProductNumberInfoRow productNumberInfoRow = this._dataSet.ProductNumberInfo.FindByMakerCodeGoodsCodeProductNumber(data.GoodsMakerCd, data.GoodsNo, data.ProductNumber);
                InventoryUpdateDataSet.InventoryNumberInfoRow inventoryNumberInfoRow = this._dataSet.InventoryNumberInfo.FindByGoodsMakerCdGoodsNoInventorySeqNo(data.GoodsMakerCd, data.GoodsNo, data.InventorySeqNo);
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

				if (inventoryNumberInfoRow == null)
				{
                    // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                    //InventoryUpdateDataSet.ProductNumberInfoRow newRow = this._dataSet.ProductNumberInfo.NewProductNumberInfoRow();
                    InventoryUpdateDataSet.InventoryNumberInfoRow newRow = this._dataSet.InventoryNumberInfo.NewInventoryNumberInfoRow();
                    // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                    newRow.GoodsMakerCd = data.GoodsMakerCd;
					newRow.GoodsNo = data.GoodsNo;
					newRow.GoodsName = data.GoodsName;
                    // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                    //newRow.ProductNumber = data.ProductNumber;
                    newRow.InventorySeqNo = data.InventorySeqNo;
                    // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                    newRow.WarehouseCode = data.WarehouseCode;
					newRow.WarehouseName = data.WarehouseName;
                    // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
                    //newRow.ProductStockGuid = data.ProductStockGuid.ToString();
                    newRow.WarehouseShelfNo = data.WarehouseShelfNo;
                    // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
                    newRow.ProcResultState = 1;
					newRow.SectionCode = data.SectionCode;
//					newRow.SectionName = data.SectionGuideNm;

					string inventoryDayString = "";
					if (data.InventoryDay != DateTime.MinValue)
					{
						inventoryDayString = data.InventoryDay.ToString("yyyy/MM/dd");
					}
					newRow.InventoryDayString = inventoryDayString;

                    // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                    //this._dataSet.ProductNumberInfo.AddProductNumberInfoRow(newRow);
                    this._dataSet.InventoryNumberInfo.AddInventoryNumberInfoRow(newRow);
                    // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                }
				else
				{
					inventoryNumberInfoRow.IsOverlap = true;
				}
			}
		}

		private void Cache(ArrayList productStockCommonParaList)
		{
			this._dataSet.ErrorData.Rows.Clear();
			this._dataSet.ErrorData.DefaultView.Sort = "";

			if (productStockCommonParaList != null)
			{
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //foreach (ProductStockCommonPara para in productStockCommonParaList)
                foreach (InventoryUpdateDataSet.InventoryRow para in productStockCommonParaList)
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                {
					string warehouseCode = "";
					string warehouseName = "";
					string goodsName = "";
                    // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
					//if (this._inventoryDataDictionary.ContainsKey(para.ProductStockGuid.ToString()))
                    //{
                    //    warehouseCode = this._inventoryDataDictionary[para.ProductStockGuid.ToString()].WarehouseCode;
                    //    warehouseName = this._inventoryDataDictionary[para.ProductStockGuid.ToString()].WarehouseName;
                    //    goodsName = this._inventoryDataDictionary[para.ProductStockGuid.ToString()].GoodsName;
                    //}
                    if (this._inventoryDataDictionary.ContainsKey(para.InventorySeqNo.ToString()))
					{
                        warehouseCode = this._inventoryDataDictionary[para.InventorySeqNo.ToString()].WarehouseCode;
                        warehouseName = this._inventoryDataDictionary[para.InventorySeqNo.ToString()].WarehouseName;
                        goodsName = this._inventoryDataDictionary[para.InventorySeqNo.ToString()].GoodsName;
					}
                    // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

					bool isNew = false;
                    // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                    //InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByMakerCodeGoodsCodeProductNumberWarehouseCodeProcResultState(
					//	para.GoodsMakerCd, para.GoodsNo, para.ProductNumber, warehouseCode, para.ProcResultState);
                    InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByGoodsMakerCdGoodsNoInventorySeqNoWarehouseCodeProcResultState(
                        para.GoodsMakerCd, para.GoodsNo, para.InventorySeqNo, warehouseCode, para.ProcResultState);
                    // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

					if (row == null)
					{
						row = this._dataSet.ErrorData.NewErrorDataRow();
						isNew = true;
					}

					if (isNew)
					{
						InventoryUpdateDataSet.InventoryRow inventoryRow = null;
                        // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                        //DataRow[] rows = this._dataSet.Inventory.Select(
						//	this._dataSet.Inventory.MakerCodeColumn.ColumnName + " = " + para.GoodsMakerCd.ToString() + " and " +
						//	this._dataSet.Inventory.GoodsCodeColumn.ColumnName + " = " + "'" + para.GoodsNo + "'");
                        DataRow[] rows = this._dataSet.Inventory.Select(
                            this._dataSet.Inventory.GoodsMakerCdColumn.ColumnName + " = " + para.GoodsMakerCd.ToString() + " and " +
                            this._dataSet.Inventory.GoodsNoColumn.ColumnName + " = " + "'" + para.GoodsNo + "'");
                        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

						if ((rows != null) && (rows.Length > 0))
						{
							inventoryRow = (InventoryUpdateDataSet.InventoryRow)rows[0];
						}

						row.GoodsMakerCd = para.GoodsMakerCd;
						row.GoodsNo = para.GoodsNo;
                        // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                        //row.ProductNumber = para.ProductNumber;
						//row.ProductStockGuid = para.ProductStockGuid.ToString();
                        row.InventorySeqNo = para.InventorySeqNo;
                        row.WarehouseShelfNo = para.WarehouseShelfNo;
                        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
						row.Error = this.CreateErrorMessage(para);
						row.ProcResultState = para.ProcResultState;
						//row.SectionCode = sectionCode;					// ����������s�O�ɐݒ�
						//row.SectionName = sectionName;					// ����������s�O�ɐݒ�
						//row.InventoryDayString = inventoryDayString;		// ����������s�O�ɐݒ�
						row.WarehouseCode = warehouseCode;
						row.WarehouseName = warehouseName;
						row.GoodsName = goodsName;
						this._dataSet.ErrorData.AddErrorDataRow(row);
					}
				}
			}

            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //DataRow[] checkRows = this._dataSet.ProductNumberInfo.Select(this._dataSet.ProductNumberInfo.IsOverlapColumn.ColumnName + " = " + Boolean.TrueString);
            DataRow[] checkRows = this._dataSet.InventoryNumberInfo.Select(this._dataSet.InventoryNumberInfo.IsOverlapColumn.ColumnName + " = " + Boolean.TrueString);
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            if ((checkRows != null) && (checkRows.Length > 0))
			{
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //InventoryUpdateDataSet.ProductNumberInfoRow[] inventoryNumberInfoRows = (InventoryUpdateDataSet.ProductNumberInfoRow[])checkRows;
				//foreach (InventoryUpdateDataSet.ProductNumberInfoRow inventoryNumberInfoRow in inventoryNumberInfoRows)
                InventoryUpdateDataSet.InventoryNumberInfoRow[] inventoryNumberInfoRows = (InventoryUpdateDataSet.InventoryNumberInfoRow[])checkRows;
				foreach (InventoryUpdateDataSet.InventoryNumberInfoRow inventoryNumberInfoRow in inventoryNumberInfoRows)
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                {
					bool isNew = false;
                    // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                    //InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByMakerCodeGoodsCodeProductNumberWarehouseCodeProcResultState(
					//	inventoryNumberInfoRow.MakerCode, inventoryNumberInfoRow.GoodsCode, inventoryNumberInfoRow.ProductNumber, inventoryNumberInfoRow.WarehouseCode, inventoryNumberInfoRow.ProcResultState);
                    InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByGoodsMakerCdGoodsNoInventorySeqNoWarehouseCodeProcResultState(
                        inventoryNumberInfoRow.GoodsMakerCd, inventoryNumberInfoRow.GoodsNo, inventoryNumberInfoRow.InventorySeqNo, inventoryNumberInfoRow.WarehouseCode, inventoryNumberInfoRow.ProcResultState);
                    // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

					if (row == null)
					{
						row = this._dataSet.ErrorData.NewErrorDataRow();
						isNew = true;
					}

					if (isNew)
					{
						row.GoodsMakerCd = inventoryNumberInfoRow.GoodsMakerCd;
						row.GoodsNo = inventoryNumberInfoRow.GoodsNo;
                        // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                        //row.ProductNumber = inventoryNumberInfoRow.ProductNumber;
						//row.ProductStockGuid = inventoryNumberInfoRow.ProductStockGuid.ToString();
						//row.Error = "�����ԍ����d�����Ă��܂��B";
						//row.ProcResultState = inventoryNumberInfoRow.ProcResultState;
                        row.InventorySeqNo = inventoryNumberInfoRow.InventorySeqNo;
                        row.WarehouseShelfNo = inventoryNumberInfoRow.WarehouseShelfNo;
                        row.Error = "�I���ʔԂ��d�����Ă��܂��B";
                        row.ProcResultState = inventoryNumberInfoRow.ProcResultState;
                        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                        //row.SectionCode = sectionCode;					// ����������s�O�ɐݒ�
						//row.SectionName = sectionName;					// ����������s�O�ɐݒ�
						//row.InventoryDayString = inventoryDayString;		// ����������s�O�ɐݒ�
						row.WarehouseCode = inventoryNumberInfoRow.WarehouseCode;
						row.WarehouseName = inventoryNumberInfoRow.WarehouseName;
						row.GoodsName = inventoryNumberInfoRow.GoodsName;
						this._dataSet.ErrorData.AddErrorDataRow(row);
					}
				}
			}

            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //this._dataSet.ErrorData.DefaultView.Sort = this._dataSet.Inventory.GoodsCodeColumn.ColumnName + " , " + this._dataSet.Inventory.ProductNumberColumn.ColumnName;
            this._dataSet.ErrorData.DefaultView.Sort = this._dataSet.Inventory.GoodsNoColumn.ColumnName + " , " + this._dataSet.Inventory.InventorySeqNoColumn.ColumnName;
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �f�[�^�e�[�u���L���b�V������
        /// </summary>
        /// <param name="inventoryDataUpdateWork">�I���f�[�^�������ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I���f�[�^�������ʃI�u�W�F�N�g���f�[�^�e�[�u���ɃL���b�V�����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2010/02/23 �k���r �o�l�V�����ȏ�̏������x�։��ǂ���B</br>
        /// </remarks>
        private void Cache(InventoryDataUpdateWork inventoryDataUpdateWork)
        {
            //this._inventoryDataDictionary.Add(inventoryDataUpdateWork.InventorySeqNo.ToString(), inventoryDataUpdateWork);
            this._inventoryDataDictionary.Add(CreatKey(inventoryDataUpdateWork), inventoryDataUpdateWork);

            InventoryUpdateDataSet.InventoryRow row = RowFromUIData(inventoryDataUpdateWork);

            _dataSet.Inventory.AddInventoryRow(row);

            if (inventoryDataUpdateWork.InventorySeqNo != 0)
            {
                InventoryUpdateDataSet.InventoryNumberInfoRow inventoryNumberInfoRow = this._dataSet.InventoryNumberInfo.FindByGoodsMakerCdGoodsNoInventorySeqNo(inventoryDataUpdateWork.GoodsMakerCd, inventoryDataUpdateWork.GoodsNo, inventoryDataUpdateWork.InventorySeqNo);

                if (inventoryNumberInfoRow == null)
                {
                    InventoryUpdateDataSet.InventoryNumberInfoRow newRow = this._dataSet.InventoryNumberInfo.NewInventoryNumberInfoRow();
                    // ���[�J�[�R�[�h
                    newRow.GoodsMakerCd = inventoryDataUpdateWork.GoodsMakerCd;
                    // �i��
                    newRow.GoodsNo = inventoryDataUpdateWork.GoodsNo;
                    // �i��
                    // --- UPD 2010/02/23 ----------<<<<<
                    //newRow.GoodsName = GetGoodsName(inventoryDataUpdateWork.GoodsMakerCd, inventoryDataUpdateWork.GoodsNo.Trim());
                    newRow.GoodsName = inventoryDataUpdateWork.GoodsName;
                    // --- UPD 2010/02/23 ---------->>>>>
                    // �I���ʔ�
                    newRow.InventorySeqNo = inventoryDataUpdateWork.InventorySeqNo;
                    // �q�ɃR�[�h
                    newRow.WarehouseCode = inventoryDataUpdateWork.WarehouseCode;
                    // �q�ɖ�
                    newRow.WarehouseName = GetWarehouseName(inventoryDataUpdateWork.WarehouseCode.Trim());
                    // �q�ɒI��
                    newRow.WarehouseShelfNo = inventoryDataUpdateWork.WarehouseShelfNo;
                    // 
                    newRow.ProcResultState = 1;
                    // ���_�R�[�h
                    newRow.SectionCode = inventoryDataUpdateWork.SectionCode;

                    string inventoryDayString = "";
                    if (inventoryDataUpdateWork.InventoryDay != DateTime.MinValue)
                    {
                        inventoryDayString = inventoryDataUpdateWork.InventoryDay.ToString("yyyy/MM/dd");
                    }
                    // �I�����{��
                    newRow.InventoryDayString = inventoryDayString;

                    this._dataSet.InventoryNumberInfo.AddInventoryNumberInfoRow(newRow);
                }
                else
                {
                    inventoryNumberInfoRow.IsOverlap = true;
                }
            }
        }
        /// <summary>
        /// �f�[�^�e�[�u���L���b�V������
        /// </summary>
        /// <param name="productStockCommonParaList">�I���f�[�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �I���f�[�^���f�[�^�e�[�u���ɃL���b�V�����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void Cache(ArrayList productStockCommonParaList)
        {
            this._dataSet.ErrorData.Rows.Clear();
            this._dataSet.ErrorData.DefaultView.Sort = "";

            if (productStockCommonParaList != null)
            {
                foreach (InventoryUpdateDataSet.InventoryRow para in productStockCommonParaList)
                {
                    string warehouseCode = "";
                    string warehouseName = "";
                    string goodsName = "";
                    //if (this._inventoryDataDictionary.ContainsKey(para.InventorySeqNo.ToString())
                    if (this._inventoryDataDictionary.ContainsKey(CreatKey(para)))
                    {
                        //warehouseCode = this._inventoryDataDictionary[para.InventorySeqNo.ToString()].WarehouseCode;
                        warehouseCode = this._inventoryDataDictionary[CreatKey(para)].WarehouseCode;
                        warehouseName = GetWarehouseName(warehouseCode.Trim());
                        //goodsName = GetGoodsName(this._inventoryDataDictionary[para.InventorySeqNo.ToString()].GoodsMakerCd,
                        //                         this._inventoryDataDictionary[para.InventorySeqNo.ToString()].GoodsNo.Trim());
                        goodsName = GetGoodsName(this._inventoryDataDictionary[CreatKey(para)].GoodsMakerCd,
                         this._inventoryDataDictionary[CreatKey(para)].GoodsNo.Trim());
                    }

                    bool isNew = false;
                    InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByGoodsMakerCdGoodsNoInventorySeqNoWarehouseCodeProcResultState(
                        para.GoodsMakerCd, para.GoodsNo, para.InventorySeqNo, warehouseCode, para.ProcResultState);

                    if (row == null)
                    {
                        row = this._dataSet.ErrorData.NewErrorDataRow();
                        isNew = true;
                    }

                    if (isNew)
                    {
                        InventoryUpdateDataSet.InventoryRow inventoryRow = null;
                        DataRow[] rows = this._dataSet.Inventory.Select(
                            this._dataSet.Inventory.GoodsMakerCdColumn.ColumnName + " = " + para.GoodsMakerCd.ToString() + " and " +
                            this._dataSet.Inventory.GoodsNoColumn.ColumnName + " = " + "'" + para.GoodsNo + "'");

                        if ((rows != null) && (rows.Length > 0))
                        {
                            inventoryRow = (InventoryUpdateDataSet.InventoryRow)rows[0];
                        }

                        row.GoodsMakerCd = para.GoodsMakerCd;
                        row.GoodsNo = para.GoodsNo;
                        row.InventorySeqNo = para.InventorySeqNo;
                        row.WarehouseShelfNo = para.WarehouseShelfNo;
                        row.Error = this.CreateErrorMessage(para);
                        row.ProcResultState = para.ProcResultState;
                        row.WarehouseCode = warehouseCode;
                        row.WarehouseName = warehouseName;
                        row.GoodsName = goodsName;
                        this._dataSet.ErrorData.AddErrorDataRow(row);
                    }
                }
            }

            DataRow[] checkRows = this._dataSet.InventoryNumberInfo.Select(this._dataSet.InventoryNumberInfo.IsOverlapColumn.ColumnName + " = " + Boolean.TrueString);
            if ((checkRows != null) && (checkRows.Length > 0))
            {
                InventoryUpdateDataSet.InventoryNumberInfoRow[] inventoryNumberInfoRows = (InventoryUpdateDataSet.InventoryNumberInfoRow[])checkRows;
                foreach (InventoryUpdateDataSet.InventoryNumberInfoRow inventoryNumberInfoRow in inventoryNumberInfoRows)
                {
                    bool isNew = false;
                    InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByGoodsMakerCdGoodsNoInventorySeqNoWarehouseCodeProcResultState(
                        inventoryNumberInfoRow.GoodsMakerCd, inventoryNumberInfoRow.GoodsNo, inventoryNumberInfoRow.InventorySeqNo, inventoryNumberInfoRow.WarehouseCode, inventoryNumberInfoRow.ProcResultState);

                    if (row == null)
                    {
                        row = this._dataSet.ErrorData.NewErrorDataRow();
                        isNew = true;
                    }

                    if (isNew)
                    {
                        row.GoodsMakerCd = inventoryNumberInfoRow.GoodsMakerCd;
                        row.GoodsNo = inventoryNumberInfoRow.GoodsNo;
                        row.InventorySeqNo = inventoryNumberInfoRow.InventorySeqNo;
                        row.WarehouseShelfNo = inventoryNumberInfoRow.WarehouseShelfNo;
                        row.Error = "�I���ʔԂ��d�����Ă��܂��B";
                        row.ProcResultState = inventoryNumberInfoRow.ProcResultState;
                        row.WarehouseCode = inventoryNumberInfoRow.WarehouseCode;
                        row.WarehouseName = inventoryNumberInfoRow.WarehouseName;
                        row.GoodsName = inventoryNumberInfoRow.GoodsName;
                        this._dataSet.ErrorData.AddErrorDataRow(row);
                    }
                }
            }

            this._dataSet.ErrorData.DefaultView.Sort = this._dataSet.Inventory.GoodsNoColumn.ColumnName + " , " + this._dataSet.Inventory.InventorySeqNoColumn.ColumnName;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		public void SettingErrorDataHeaderInfo(string sectionCode, string sectionName, DateTime inventoryDaySta, DateTime inventoryDayEnd)
		{
			foreach (InventoryUpdateDataSet.ErrorDataRow row in this.DataSet.ErrorData.Rows)
			{
				row.SectionCode = sectionCode;
				row.SectionName = sectionName;

				string inventoryDayString = "";
				if (inventoryDaySta != DateTime.MinValue)
				{
					inventoryDayString = inventoryDayString + inventoryDaySta.ToString("yyyy/MM/dd");
				}

				inventoryDayString = inventoryDayString + " �` ";
				inventoryDayString = inventoryDayString + inventoryDayEnd.ToString("yyyy/MM/dd"); ;

				row.InventoryDayString = inventoryDayString;
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �G���[���b�Z�[�W�𐶐����܂��B
		/// </summary>
		/// <param name="para">���ԍ݌ɋ��ʃp�����[�^�I�u�W�F�N�g</param>
		/// <returns>�G���[���b�Z�[�W</returns>
        // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
		//private string CreateErrorMessage(ProductStockCommonPara para)
        private string CreateErrorMessage(InventoryUpdateDataSet.InventoryRow para)
        // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
		{
            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //// 0:����,1:���ԏd��,2:�v���,10:�݌ɋ敪�ύX��,11:�݌ɏ�ԕύX��,12:�ړ���ԕύX��,13:���i��ԕύX��,20:���ԍ݌Ƀf�[�^�폜��
            // 0:����,1:�I���ʔԏd��,2:�v���,10:�݌ɋ敪�ύX��,11:�݌ɏ�ԕύX��,12:�ړ���ԕύX��,13:���i��ԕύX��
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

            string message = "";

			switch (para.ProcResultState)
			{
				case 0:
				{
					break;
				}
				case 1:
				{
                    // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                    //message = "�����ԍ����d�����Ă��܂��B";
                    message = "�I���ʔԂ��d�����Ă��܂��B";
                    // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
                    break;
				}
				case 2:
				{
					message = "�v��ς݂ł��B";
					break;
				}
				case 10:
				{
					message = "�݌ɋ敪�i���Ё^����j���ύX����Ă��܂��B";
					break;
				}
				case 11:
				{
					message = "�݌ɏ�Ԃ��ύX����Ă��܂��B";
					break;
				}
				case 12:
				{
					message = "�݌ɂ̈ړ���Ԃ��ύX����Ă��܂��B";
					break;
				}
				case 13:
				{
					message = "�݌ɂ̏��i��ԁi����^�s�Ǖi�j���ύX����Ă��܂��B";
					break;
				}
				case 20:
				{
					message = "���ɍ폜����Ă��܂��B";
					break;
				}
			}

			return message;
		}

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �ۑ��p�f�[�^��������
		/// </summary>
		/// <returns>�ۑ��p�f�[�^(CustomSerializeArrayList)</returns>
		private CustomSerializeArrayList CreateSaveData()
		{
			CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
			ArrayList stockAdjustWorkList = new ArrayList();
			ArrayList eachWarehouseStockAdjustDtlWorkList = new ArrayList();
			ArrayList stockWorkList = new ArrayList();
            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //ArrayList productStockWorkList = new ArrayList();
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            ArrayList inventoryDataList = new ArrayList();
			Dictionary<string, StockWork> stockDictionary = new Dictionary<string, StockWork>();

			DataRow[] rows = this._dataSet.Inventory.Select(this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName + " <> 0");

			if ((rows == null) || (rows.Length == 0))
			{
				if (this._dataSet.Inventory.Count > 0)
				{
					InventoryUpdateDataSet.InventoryRow[] inventoryRows = (InventoryUpdateDataSet.InventoryRow[])rows;

					Dictionary<DateTime, InventoryDataUpdateWork> inventoryDayDictionary = new Dictionary<DateTime, InventoryDataUpdateWork>();

					// �I���f�[�^�I�u�W�F�N�g���X�g�𐶐�����i�I�����ɂ��P�����j
					foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
					{
						if (!inventoryDayDictionary.ContainsKey(workData.InventoryDay))
						{
							inventoryDayDictionary.Add(workData.InventoryDay, workData);
						}
					}

					foreach (InventoryDataUpdateWork workData in inventoryDayDictionary.Values)
					{
						workData.LastInventoryUpdate = DateTime.Today;
						inventoryDataList.Add(workData);
					}

					if (inventoryDataList.Count > 0)
					{
						saveDataList.Add(inventoryDataList);
					}
				}
			}
			else
			{
				InventoryUpdateDataSet.InventoryRow[] inventoryRows = (InventoryUpdateDataSet.InventoryRow[])rows;

				Dictionary<DateTime, InventoryDataUpdateWork> inventoryDayDictionary = new Dictionary<DateTime, InventoryDataUpdateWork>();

				// �I���f�[�^�I�u�W�F�N�g���X�g�𐶐�����i�I�����ɂ��P�����j
				foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
				{
					if (!inventoryDayDictionary.ContainsKey(workData.InventoryDay))
					{
						inventoryDayDictionary.Add(workData.InventoryDay, workData);
					}
				}

				foreach (InventoryDataUpdateWork workData in inventoryDayDictionary.Values)
				{
					workData.LastInventoryUpdate = DateTime.Today;
					inventoryDataList.Add(workData);
				}

				// �݌ɒ������׃f�[�^���[�N�I�u�W�F�N�g�𐶐�����B
				if (((ArrayList)inventoryRows[0].InventoryDataUpdateWork).Count > 0)
				{
					// �݌ɒ����f�[�^�𐶐�����
					stockAdjustWorkList.Add(this.CreateStockAdjust((InventoryDataUpdateWork)((ArrayList)inventoryRows[0].InventoryDataUpdateWork)[0]));
				}

				foreach (InventoryUpdateDataSet.InventoryRow row in inventoryRows)
				{
					ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;

					if (inventoryDataUpdateWorkList.Count > 0)
					{
						InventoryDataUpdateWork inventoryDataUpdateWork = (InventoryDataUpdateWork)inventoryDataUpdateWorkList[0];
						inventoryDataUpdateWork.InventoryTolerancCnt = row.InventoryTolerancCnt;

						// �݌Ƀ}�X�^�I�u�W�F�N�g�𐶐�����B
						this.CreateStock(inventoryDataUpdateWork, ref stockDictionary);

						foreach (InventoryDataUpdateWork data in inventoryDataUpdateWorkList)
						{
                            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
                            //// ���ԍ݌Ƀ}�X�^���[�N�I�u�W�F�N�g���i�[����ArrayList�𐶐�����B
							//this.CreateProductStockList(data, ref productStockWorkList);
                            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<

							// �݌ɒ������׃f�[�^�𐶐�����B
							this.CreateStockAdjustDtl(data, ref eachWarehouseStockAdjustDtlWorkList);
						}

                        // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
                        //if (((InventoryDataUpdateWork)inventoryDataUpdateWorkList[0]).ProductNumber != "")
						//{
						//	InventoryDataUpdateWork data = (InventoryDataUpdateWork)inventoryDataUpdateWorkList[0];
						//}
                        //else
                        //{
                        //	// ���Ԃ����͂���Ă��Ȃ��ꍇ�i�O���X�j
                        //}
                        // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
                    }
				}

				if (inventoryDataList.Count > 0)
				{
					saveDataList.Add(inventoryDataList);
				}

				if (stockAdjustWorkList.Count > 0)
				{
					saveDataList.Add(stockAdjustWorkList);
				}

				if (eachWarehouseStockAdjustDtlWorkList.Count > 0)
				{
					saveDataList.Add(eachWarehouseStockAdjustDtlWorkList);
				}

				if (stockDictionary.Values.Count > 0)
				{
					foreach (StockWork stockWork in stockDictionary.Values)
					{
						stockWorkList.Add(stockWork);
					}

					saveDataList.Add(stockWorkList);
				}

                // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
                //if (productStockWorkList.Count > 0)
				//{
				//	saveDataList.Add(productStockWorkList);
				//}
                // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            }

			return saveDataList;
		}

		/// <summary>
		/// �I���f�[�^�������ʃI�u�W�F�N�g����I���f�[�^�������ʍs�N���X���擾���܂��B
		/// </summary>
		/// <param name="data">�I���f�[�^�������ʃI�u�W�F�N�g</param>
		/// <returns>�I���f�[�^�������ʍs�N���X</returns>
		private InventoryUpdateDataSet.InventoryRow RowFromUIData(InventoryDataUpdateWork data, out bool isNew)
		{
			InventoryUpdateDataSet.InventoryRow row = null;
			isNew = false;

            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //bool createGrossData = false;
			//if (data.ProductNumber.Trim() != "")
			//{
			//	createGrossData = false;
			//}
			//else
			//{
			//	createGrossData = true;
			//}
            //
			//if (createGrossData)
			//{
			//	row = this._dataSet.Inventory.FindByEnterpriseCodeMakerCodeGoodsCodeProductNumberStockUnitPriceSectionCodeWarehouseCodeCarrierEpCodeCustomerCodeShipCustomerCodeStockDivStockStateInventoryNewDivProductStockGuid(
			//		data.EnterpriseCode,
			//		data.GoodsMakerCd,
			//		data.GoodsNo,
			//		"",
			//		data.StockUnitPriceFl,
			//		data.SectionCode,
			//		data.WarehouseCode,
			//		data.CarrierEpCode,
			//		data.CustomerCode,
			//		data.ShipCustomerCode,
			//		data.StockDiv,
			//		data.StockState,
			//		data.InventoryNewDiv,
			//		Guid.Empty.ToString());
            //
			//	if (row == null)
			//	{
			//		row = _dataSet.Inventory.NewInventoryRow();
			//		isNew = true;
			//	}
            //
			//	this.SetRowFromUIData(ref row, data, true);
			//}
			//else
			//{
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
                row = _dataSet.Inventory.NewInventoryRow();
				isNew = true;
				this.SetRowFromUIData(ref row, data, false);
			//}

			return row;
        }

		/// <summary>
		/// �I���f�[�^�������ʃ��[�N���I���f�[�^�s�N���X�ݒ菈��
		/// </summary>
		/// <param name="row">�I���f�[�^�s�N���X</param>
		/// <param name="data">�I���f�[�^�������ʃ��[�N�I�u�W�F�N�g</param>
		private void SetRowFromUIData(ref InventoryUpdateDataSet.InventoryRow row, InventoryDataUpdateWork data, bool isGrossData)
		{
			if (row.InventoryDataUpdateWork is System.DBNull)
			{
				ArrayList list = new ArrayList();
				row.InventoryDataUpdateWork = list;
			}

			//row.RowNo             = data.RowNo;
			row.EnterpriseCode      = data.EnterpriseCode;
			row.GoodsMakerCd        = data.GoodsMakerCd;
			row.GoodsName           = data.GoodsName;
			row.GoodsNo             = data.GoodsNo;
            // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
            //row.ProductNumber     = data.ProductNumber;
            row.InventorySeqNo      = data.InventorySeqNo;
            row.WarehouseShelfNo    = data.WarehouseShelfNo;
            // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            row.StockUnitPrice      = data.StockUnitPriceFl;
            // 2008.02.26 �C�� >>>>>>>>>>>>>>>>>>>>
            row.InventoryStockTotal = data.StockAmount;
            // 2008.02.26 �C�� <<<<<<<<<<<<<<<<<<<<

            // ���됔�^���ِ�
            // 2008.02.26 �폜 >>>>>>>>>>>>>>>>>>>>
            //if (isGrossData)
            //{
            //    row.StockTotal = row.StockTotal + data.StockTotal;
            //    row.InventoryStockCnt = row.InventoryStockCnt + data.InventoryStockCnt;
            //    row.InventoryTolerancCnt = row.InventoryTolerancCnt + data.InventoryTolerancCnt;
            //    // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //    //row.ProductStockGuid = Guid.Empty.ToString();
            //    // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<

            //    if (data.InventoryTolerancCnt != 0)
            //    {
            //        ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;
            //        inventoryDataUpdateWorkList.Add(data);
            //    }
            //}
            //else
            //{
            // 2008.02.26 �폜 <<<<<<<<<<<<<<<<<<<<
				row.StockTotal              = data.StockTotal;
				row.InventoryStockCnt       = data.InventoryStockCnt;
				row.InventoryTolerancCnt    = data.InventoryTolerancCnt;
                // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
                //row.ProductStockGuid      = data.ProductStockGuid.ToString();
                // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<

				ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;
				inventoryDataUpdateWorkList.Add(data);
            // 2008.02.26 �폜 >>>>>>>>>>>>>>>>>>>>
			//}
            // 2008.02.26 �폜 <<<<<<<<<<<<<<<<<<<<

			row.SectionCode = data.SectionCode;
			row.WarehouseCode = data.WarehouseCode;
            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //row.CarrierEpCode = data.CarrierEpCode;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            row.CustomerCode = data.CustomerCode;
			row.ShipCustomerCode = data.ShipCustomerCode;
			row.StockDiv = data.StockDiv;
			if (data.StockDiv == 0)
			{
				row.StockDivName = "����";
			}
			else
			{
				row.StockDivName = "���";
			}

            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //row.StockState = data.StockState;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            row.InventoryNewDiv = data.InventoryNewDiv;
			row.WarehouseName = data.WarehouseName;
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        #region DEL 2009/05/22 �s��Ή�[13243]
        //// --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// �ۑ��p�f�[�^��������
        ///// </summary>
        ///// <returns>�ۑ��p�f�[�^(CustomSerializeArrayList)</returns>
        ///// <remarks>
        ///// <br>Note       : �ۑ��p�f�[�^���쐬���܂��B</br>
        ///// <br>Programmer : 30414 �E �K�j</br>
        ///// <br>Date       : 2008/09/10</br>
        ///// </remarks>
        //private CustomSerializeArrayList CreateSaveData()
        //{
        //    CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
        //    ArrayList stockAdjustWorkList = new ArrayList();
        //    ArrayList stockAdjustDtlWorkList = new ArrayList();
        //    ArrayList stockWorkList = new ArrayList();
        //    ArrayList inventoryDataList = new ArrayList();
        //    Dictionary<string, StockWork> stockDictionary = new Dictionary<string, StockWork>();

        //    DataRow[] rows = this._dataSet.Inventory.Select(this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName + " <> 0");

        //    if ((rows == null) || (rows.Length == 0))
        //    {
        //        if (this._dataSet.Inventory.Count > 0)
        //        {
        //            InventoryUpdateDataSet.InventoryRow[] inventoryRows = (InventoryUpdateDataSet.InventoryRow[])rows;

        //            Dictionary<DateTime, InventoryDataUpdateWork> inventoryDayDictionary = new Dictionary<DateTime, InventoryDataUpdateWork>();

        //            // �I���f�[�^�I�u�W�F�N�g���X�g�𐶐�����i�I�����ɂ��P�����j
        //            foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
        //            {
        //                if (!inventoryDayDictionary.ContainsKey(workData.InventoryDay))
        //                {
        //                    inventoryDayDictionary.Add(workData.InventoryDay, workData);
        //                }
        //            }

        //            foreach (InventoryDataUpdateWork workData in inventoryDayDictionary.Values)
        //            {
        //                // �ŏI�I���X�V��
        //                workData.LastInventoryUpdate = DateTime.Today;
        //                // �ߕs����(�I�����|���{�����됔)
        //                workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;

        //                inventoryDataList.Add(workData);
        //            }

        //            if (inventoryDataList.Count > 0)
        //            {
        //                saveDataList.Add(inventoryDataList);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        InventoryUpdateDataSet.InventoryRow[] inventoryRows = (InventoryUpdateDataSet.InventoryRow[])rows;

        //        //Dictionary<DateTime, InventoryDataUpdateWork> inventoryDayDictionary = new Dictionary<DateTime, InventoryDataUpdateWork>();

        //        //// �I���f�[�^�I�u�W�F�N�g���X�g�𐶐�����i�I�����ɂ��P�����j
        //        //foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
        //        //{
        //        //    if (!inventoryDayDictionary.ContainsKey(workData.InventoryDay))
        //        //    {
        //        //        inventoryDayDictionary.Add(workData.InventoryDay, workData);
        //        //    }
        //        //}

        //        //foreach (InventoryDataUpdateWork workData in inventoryDayDictionary.Values)
        //        foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
        //        {
        //            // �ŏI�I���X�V��
        //            workData.LastInventoryUpdate = DateTime.Today;
        //            // �ߕs����(�I�����|���{�����됔)
        //            workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;

        //            inventoryDataList.Add(workData);
        //        }

        //        // �݌ɒ������׃f�[�^���[�N�I�u�W�F�N�g�𐶐�����B
        //        if (((ArrayList)inventoryRows[0].InventoryDataUpdateWork).Count > 0)
        //        {
        //            // �݌ɒ����f�[�^�𐶐�����
        //            stockAdjustWorkList.Add(CreateStockAdjust((InventoryDataUpdateWork)((ArrayList)inventoryRows[0].InventoryDataUpdateWork)[0]));
        //        }

        //        foreach (InventoryUpdateDataSet.InventoryRow row in inventoryRows)
        //        {
        //            ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;

        //            if (inventoryDataUpdateWorkList.Count > 0)
        //            {
        //                InventoryDataUpdateWork inventoryDataUpdateWork = (InventoryDataUpdateWork)inventoryDataUpdateWorkList[0];

        //                // �ߕs����(�I�����|���{�����됔)
        //                inventoryDataUpdateWork.InventoryTolerancCnt = row.InventoryStockCnt - row.InventoryStockTotal;

        //                // �݌Ƀ}�X�^�I�u�W�F�N�g�𐶐�����B
        //                CreateStock(inventoryDataUpdateWork, ref stockDictionary);

        //                foreach (InventoryDataUpdateWork data in inventoryDataUpdateWorkList)
        //                {
        //                    // �݌ɒ������׃f�[�^�𐶐�����B
        //                    CreateStockAdjustDtl(data, ref stockAdjustDtlWorkList);
        //                }
        //            }
        //        }

        //        if (stockAdjustDtlWorkList.Count > 0)
        //        {
        //            long stockPriceTaxExec = 0;

        //            foreach (StockAdjustDtlWork work in stockAdjustDtlWorkList)
        //            {
        //                stockPriceTaxExec += work.StockPriceTaxExc;
        //            }

        //            foreach (StockAdjustWork work in stockAdjustWorkList)
        //            {
        //                work.StockSubttlPrice = stockPriceTaxExec;
        //            }
        //        }
                
        //        if (inventoryDataList.Count > 0)
        //        {
        //            // �I���f�[�^�X�V�N���X�ǉ�
        //            saveDataList.Add(inventoryDataList);
        //        }

        //        if (stockAdjustWorkList.Count > 0)
        //        {
        //            // �݌ɒ����f�[�^�ǉ�
        //            saveDataList.Add(stockAdjustWorkList);
        //        }

        //        if (stockAdjustDtlWorkList.Count > 0)
        //        {
        //            // �݌ɒ������׃f�[�^�ǉ�
        //            saveDataList.Add(stockAdjustDtlWorkList);
        //        }

        //        if (stockDictionary.Values.Count > 0)
        //        {
        //            foreach (StockWork stockWork in stockDictionary.Values)
        //            {
        //                // �݌Ƀ}�X�^�ǉ�
        //                stockWorkList.Add(stockWork);
        //            }

        //            saveDataList.Add(stockWorkList);
        //        }
        //    }

        //    return saveDataList;
        //}
        #endregion

        // --- ADD 2009/05/22 �s��Ή�[13243] ---------------->>>>>
        #region �ۑ��p�f�[�^��������
        /// <summary>
        /// �ۑ��p�f�[�^��������
        /// </summary>
        /// <returns>�ۑ��p�f�[�^(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��p�f�[�^���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             ���{�����됔�̎Z�o���@��ύX����悤�ɕύX</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData()
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList stockWorkList = new ArrayList();
            ArrayList inventoryDataList = new ArrayList();
            Dictionary<string, StockWork> stockDictionary = new Dictionary<string, StockWork>();

            // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
            Dictionary<string, List<DataRow>> dataTableDic= new Dictionary<string, List<DataRow>>();

            foreach (DataRow dr in this._dataSet.Inventory)
            {
                string strKey = dr["EnterpriseCode"].ToString() + "," +dr["SectionCode"].ToString() + ","+
                                dr["InventorySeqNo"].ToString() + "," +dr["WarehouseCode"].ToString() ;

                if (dataTableDic.ContainsKey(strKey))
                {
                    dataTableDic[strKey].Add(dr);
                }
                else
                {
                    List<DataRow> list = new List<DataRow>();
                    list.Add(dr);
                    dataTableDic.Add(strKey, list);

                }
            }
            // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<

            // �O���b�h�̖��ׂ������ꍇ�A�����𔲂���
            if (this._dataSet.Inventory.Count <= 0)
            {
                return saveDataList;
            }

            foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
            {
                CustomSerializeArrayList csArrayList = new CustomSerializeArrayList();


                // �I���f�[�^�쐬
                inventoryDataList.Clear();

                // --- DEL 2009/12/03 ---------->>>>>
                //workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;          //�I���ߕs����(�I�����|���{�����됔)
                //workData.InventoryTlrncPrice
                //    = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl);   //�I���ߕs�����z(�I���ߕs�����~�d���P��(����))
                //workData.LastInventoryUpdate = DateTime.Today;                                              //�I���ŏI�X�V��
                //workData.StockTotalExec = workData.StockAmount;                                             //�݌ɑ���(���{��)
                //workData.ToleranceUpdateCd = 1;                                                             //�ߕs���X�V�敪�@1:�X�V
                // --- DEL 2009/12/03 ----------<<<<<

                // --- ADD 2009/12/03 ---------->>>>>
                // �I���^�p�敪���o�l�D�m�r
                if (this._stockMngTtlSt.InventoryMngDiv == 0)
                {
                    workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;          //�I���ߕs����(�I�����|���{�����됔)
                    workData.InventoryTlrncPrice
                        = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl);   //�I���ߕs�����z(�I���ߕs�����~�d���P��(����))
                    workData.LastInventoryUpdate = DateTime.Today;                                              //�I���ŏI�X�V��
                    workData.StockTotalExec = workData.StockAmount;                                             //�݌ɑ���(���{��)
                    workData.ToleranceUpdateCd = 1;                                                             //�ߕs���X�V�敪�@1:�X�V
                }
                // �I���^�p�敪���o�l�V
                else
                {
                    workData.LastInventoryUpdate = DateTime.Today;                                              //�I���ŏI�X�V��
                    workData.StockTotalExec = workData.StockTotal;                                              //�݌ɑ���(���{��) = �݌ɑ���
                    workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockTotalExec;       //�I���ߕs����(�I�����|�݌ɑ����i���{���j)
                    workData.InventoryTlrncPrice
                        = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl);   //�I���ߕs�����z(�I���ߕs�����~�d���P��(����))
                    workData.ToleranceUpdateCd = 1;                                                             //�ߕs���X�V�敪�@1:�X�V
                }
                // --- ADD 2009/12/03 ----------<<<<<

                inventoryDataList.Add(workData);
                csArrayList.Add(inventoryDataList.Clone());

                // �݌ɒ����֘A�f�[�^�쐬
                // 2010/01/28 >>>
                //string filter = this._dataSet.Inventory.EnterpriseCodeColumn.ColumnName + " = " + workData.EnterpriseCode + " AND " +
                //                this._dataSet.Inventory.SectionCodeColumn.ColumnName + " = " + workData.SectionCode + " AND " +
                //                this._dataSet.Inventory.InventorySeqNoColumn.ColumnName + " = " + workData.InventorySeqNo;
                // 2010/01/28 <<<
                // --- DEL yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
                //string filter = this._dataSet.Inventory.EnterpriseCodeColumn.ColumnName + " = " + workData.EnterpriseCode + " AND " +
                //this._dataSet.Inventory.SectionCodeColumn.ColumnName + " = " + workData.SectionCode + " AND " +
                //this._dataSet.Inventory.InventorySeqNoColumn.ColumnName + " = " + workData.InventorySeqNo + " AND " +
                //this._dataSet.Inventory.WarehouseCodeColumn.ColumnName + " = " + workData.WarehouseCode;
                // --- DEL yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<
                // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
                //string strKey = workData.EnterpriseCode + "," + workData.SectionCode + "," + workData.InventorySeqNo.ToString() + "," + workData.WarehouseCode;

                //�s���f�[�^�̑Ή�
                string wareHouseCodeStr = workData.WarehouseCode;
                if (wareHouseCodeStr.Trim().Length <4)
                {
                    wareHouseCodeStr = wareHouseCodeStr.Trim().PadLeft(4,'0').PadRight(6,' ');
                }
                string strKey = workData.EnterpriseCode + "," + workData.SectionCode + "," + workData.InventorySeqNo.ToString() + "," + wareHouseCodeStr;

                List<DataRow> rows = new List<DataRow>();

                if (dataTableDic.ContainsKey(strKey))
                {
                    rows = dataTableDic[strKey];
                }
                // --- ADD yangyi 2013/08/02 for Redmine#31106 -------<<<<<<<<<<<

                // DataRow[] rows = this._dataSet.Inventory.Select(filter);  //DEL yangyi 2013/10/09 Redmine#31106
                //if (rows.Length == 0) //DEL yangyi 2013/10/09 Redmine#31106
                if (rows.Count == 0)    //ADD yangyi 2013/10/09 Redmine#31106 
                {
                    saveDataList.Add(csArrayList);      //�I���f�[�^�̂�
                    continue;
                }

                InventoryUpdateDataSet.InventoryRow row = (InventoryUpdateDataSet.InventoryRow)rows[0];

                ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;
                if (inventoryDataUpdateWorkList.Count > 0)
                {
                    InventoryDataUpdateWork inventoryDataUpdateWork = (InventoryDataUpdateWork)inventoryDataUpdateWorkList[0];

                    // ������
                    stockAdjustWorkList.Clear();            //�݌ɒ���
                    stockAdjustDtlWorkList.Clear();         //�݌ɒ�������
                    stockDictionary.Clear();                //�݌�1
                    stockWorkList.Clear();                  //�݌�2

                    // �ߕs�����`�F�b�N
                    if (row.InventoryTolerancCnt != 0)
                    {
                        // �݌ɒ������׃f�[�^�쐬
                        this.CreateStockAdjustDtl(inventoryDataUpdateWork, ref stockAdjustDtlWorkList);


                        // �݌ɒ����f�[�^�쐬
                        StockAdjustWork stockAdjustWork = this.CreateStockAdjust(inventoryDataUpdateWork);

                        // --[�݌ɒ����f�[�^]�d�����z���v�����߂�
                        long stockPriceTaxExec = 0;
                        foreach (StockAdjustDtlWork work in stockAdjustDtlWorkList)
                        {
                            stockPriceTaxExec += work.StockPriceTaxExc;
                        }
                        stockAdjustWork.StockSubttlPrice = stockPriceTaxExec;

                        stockAdjustWorkList.Add(stockAdjustWork);


                        // �쐬�����f�[�^��ǉ�
                        csArrayList.Add(stockAdjustWorkList.Clone());       //�݌ɒ���
                        csArrayList.Add(stockAdjustDtlWorkList.Clone());    //�݌ɒ�������                        
                    }

                    // �݌Ƀf�[�^�쐬
                    inventoryDataUpdateWork.InventoryTolerancCnt = row.InventoryStockCnt - row.InventoryStockTotal;     //�d���݌ɐ�(�I���ߕs�����F�I�����|���{�����됔)
                    this.CreateStock(inventoryDataUpdateWork, ref stockDictionary);

                    foreach (StockWork stockWork in stockDictionary.Values)
                    {
                        stockWorkList.Add(stockWork);
                    }

                    // �쐬�����f�[�^��ǉ�
                    csArrayList.Add(stockWorkList.Clone());             //�݌�
                }

                saveDataList.Add(csArrayList);
            }

            return saveDataList;
        }
        #endregion
        // --- ADD 2009/05/22 �s��Ή�[13243] ----------------<<<<<

        /// <summary>
        /// �I���f�[�^�������ʍs�N���X�擾����
        /// </summary>
        /// <param name="data">�I���f�[�^�X�V���[�N�N���X</param>
        /// <returns>�I���f�[�^�������ʍs�N���X</returns>
        /// <remarks>
        /// <br>Note       : �I���f�[�^�X�V�N���X����I���f�[�^�������ʍs�N���X���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private InventoryUpdateDataSet.InventoryRow RowFromUIData(InventoryDataUpdateWork data)
        {
            InventoryUpdateDataSet.InventoryRow row = null;

            row = _dataSet.Inventory.NewInventoryRow();

            // �I���f�[�^�s�N���X�ݒ菈��
            SetRowFromUIData(ref row, data);

            return row;
        }

        /// <summary>
        /// �I���f�[�^�s�N���X�ݒ菈��
        /// </summary>
        /// <param name="row">�I���f�[�^�s�N���X</param>
        /// <param name="data">�I���f�[�^�X�V���[�N�N���X</param>
        /// <remarks>
        /// <br>Note       : �I���f�[�^�s�N���X�ɒI���f�[�^�X�V���[�N�N���X��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2010/02/23 �k���r �o�l�V�����ȏ�̏������x�։��ǂ���B</br>
        /// </remarks>
        private void SetRowFromUIData(ref InventoryUpdateDataSet.InventoryRow row, InventoryDataUpdateWork data)
        {
            if (row.InventoryDataUpdateWork is System.DBNull)
            {
                ArrayList list = new ArrayList();
                row.InventoryDataUpdateWork = list;
            }

            // ��ƃR�[�h
            row.EnterpriseCode = data.EnterpriseCode;
            // ���[�J�[�R�[�h
            row.GoodsMakerCd = data.GoodsMakerCd;
            // �i��
            // --- UPD 2010/02/23 ----------<<<<<
            //row.GoodsName = GetGoodsName(data.GoodsMakerCd, data.GoodsNo.Trim());
            row.GoodsName = data.GoodsName;
            // --- UPD 2010/02/23 ---------->>>>>
            // �i��
            row.GoodsNo = data.GoodsNo;
            // �I���ʔ�
            row.InventorySeqNo = data.InventorySeqNo;
            // �q�ɒI��
            row.WarehouseShelfNo = data.WarehouseShelfNo;
            // �d���P��
            row.StockUnitPrice = data.StockUnitPriceFl;
            // ���{�����됔
            //row.InventoryStockTotal = data.StockAmount; // DEL 2009/12/03
            // --- ADD 2009/12/03 ---------->>>>>
            // �I���^�p�敪���o�l�D�m�r
            if (this._stockMngTtlSt.InventoryMngDiv == 0)
            {
                row.InventoryStockTotal = data.StockAmount;
                // �ߕs����
                row.InventoryTolerancCnt = data.InventoryStockCnt - data.StockAmount;
            }
            else
            {
                row.InventoryStockTotal = data.StockTotal;
                // �ߕs����
                row.InventoryTolerancCnt = data.InventoryStockCnt - data.StockTotal;
            }
            // --- ADD 2009/12/03 ----------<<<<<
            // ���됔
            row.StockTotal = data.StockTotal;
            // �I����
            row.InventoryStockCnt = data.InventoryStockCnt;
            // �ߕs����
            //row.InventoryTolerancCnt = data.InventoryStockCnt - data.StockTotal;
            //row.InventoryTolerancCnt = data.InventoryStockCnt - data.StockAmount; // DEL 2009/12/03

            ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;
            inventoryDataUpdateWorkList.Add(data);

            // ���_�R�[�h
            row.SectionCode = data.SectionCode;
            // �q�ɃR�[�h
            row.WarehouseCode = data.WarehouseCode;
            // �d����R�[�h
            row.CustomerCode = data.SupplierCd;
            // �ϑ���R�[�h
            row.ShipCustomerCode = data.ShipCustomerCode;
            // �݌ɋ敪
            row.StockDiv = data.StockDiv;
            if (data.StockDiv == 0)
            {
                row.StockDivName = "����";
            }
            else
            {
                row.StockDivName = "���";
            }
            // �I���V�K�ǉ��敪
            row.InventoryNewDiv = data.InventoryNewDiv;
            // �q�ɖ�
            row.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim());
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2007.09.20 �폜
        // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
		///// ���ԍ݌Ƀ}�X�^���[�N�I�u�W�F�N�g���i�[����ArrayList�𐶐����܂��B
		///// </summary>
		///// <param name="data"></param>
		///// <param name="retList">���ԍ݌Ƀ}�X�^���[�N�I�u�W�F�N�g���i�[����ArrayList</param>
		//private void CreateProductStockList(InventoryDataUpdateWork data, ref ArrayList retList)
		//{
		//	ProductStockWork workData = new ProductStockWork();
        //    //workData.CreateDateTime = 
		//	//workData.UpdateDateTime = 
		//	workData.EnterpriseCode = data.EnterpriseCode;
		//	//workData.FileHeaderGuid = 
		//	//workData.UpdEmployeeCode = 
		//	//workData.UpdAssemblyId1 = 
		//	//workData.UpdAssemblyId2 = 
		//	workData.LogicalDeleteCode = 0;
		//	workData.SectionCode = data.SectionCode;
		//	workData.MakerCode = data.GoodsMakerCd;
		//	workData.GoodsCode = data.GoodsNo;
		//	workData.GoodsName = data.GoodsName;
        //    // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
        //    //workData.ProductNumber = data.ProductNumber;
        //    //workData.ProductStockGuid = data.ProductStockGuid;
        //    //workData.StockState = data.StockState;
        //    // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
        //    workData.StockDiv = data.StockDiv;
		//	workData.WarehouseCode = data.WarehouseCode;
		//	workData.WarehouseName = data.WarehouseName;
        //    // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
        //    //workData.CarrierEpCode = data.CarrierEpCode;
		//	//workData.CarrierEpName = data.CarrierEpName;
        //    // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
        //    workData.CustomerCode = data.CustomerCode;
		//	workData.CustomerName = data.CustomerName;
		//	workData.CustomerName2 = data.CustomerName2;
        //    // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
        //    //workData.StockDate = data.StockDate;
		//	//workData.ArrivalGoodsDay = data.ArrivalGoodsDay;
        //    // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
        //    workData.StockUnitPrice = data.StockUnitPriceFl;
        //    workData.TaxationCode = 0;
        //    // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
        //    //workData.MoveStatus = data.MoveStatus;
        //    //workData.GoodsCodeStatus = data.GoodsCodeStatus;
        //    //workData.StockTelNo1 = data.StockTelNo1;
        //    //workData.StockTelNo2 = data.StockTelNo2;
		//	//if (String.IsNullOrEmpty(data.StockTelNo1))
		//	//{
		//	//	workData.RomDiv = 1;
		//	//}
        //    //else
        //    //{
        //    //	workData.RomDiv = 2;
        //    //}
        //    //workData.CellphoneModelCode = data.CellphoneModelCode;
        //    //workData.CellphoneModelName = data.CellphoneModelName;
        //    //workData.CarrierCode = data.CarrierCode;
        //    //workData.CarrierName = data.CarrierName;
        //    // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
        //    workData.MakerName = data.MakerName;
        //    // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
        //    //workData.SystematicColorCd = data.SystematicColorCd;
        //    //workData.SystematicColorNm = data.SystematicColorNm;
        //    // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
        //    workData.LargeGoodsGanreCode = data.LargeGoodsGanreCode;
        //    workData.MediumGoodsGanreCode = data.MediumGoodsGanreCode;
        //    workData.ShipCustomerCode = data.ShipCustomerCode;
        //	workData.ShipCustomerName = data.ShipCustomerName;
        //	workData.ShipCustomerName2 = data.ShipCustomerName2;
        //
        //	retList.Add(workData);
        //}
        // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2007.09.20 �폜

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// �݌Ƀ}�X�^�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="workData"></param>
		/// <returns>�݌Ƀ}�X�^���[�N�I�u�W�F�N�g</returns>
		private void CreateStock(InventoryDataUpdateWork data, ref Dictionary<string, StockWork> stockDictionary)
		{
			string stockKey = CreateStockKey(data);

			bool isNew = false;
			StockWork workData = null;
			if (stockDictionary.ContainsKey(stockKey))
			{
				workData = stockDictionary[stockKey];
			}
			else
			{
				workData = new StockWork();
				isNew = true;
			}

			//workData.CreateDateTime = 
			//workData.UpdateDateTime = 
			workData.EnterpriseCode = data.EnterpriseCode;
			//workData.FileHeaderGuid = 
			//workData.UpdEmployeeCode = 
			//workData.UpdAssemblyId1 = 
			//workData.UpdAssemblyId2 = 
			workData.LogicalDeleteCode = 0;
			workData.SectionCode = data.SectionCode;
			workData.GoodsMakerCd = data.GoodsMakerCd;
            workData.GoodsNo = data.GoodsNo;
			workData.GoodsName = data.GoodsName;

			if (data.StockDiv == 0)
			{
				workData.StockUnitPriceFl = data.StockUnitPriceFl;
				workData.SupplierStock = workData.SupplierStock + data.InventoryTolerancCnt;
				workData.TrustCount = 0;
			}
			else
			{
				workData.StockUnitPriceFl = 0;
				workData.SupplierStock = 0;
				workData.TrustCount = workData.TrustCount + data.InventoryTolerancCnt;
			}

            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //workData.ReservedCount = 0;
			//workData.AllowStockCnt = 0;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            workData.AcpOdrCount = 0;
			workData.SalesOrderCount = 0;
			workData.EntrustCnt = 0;
            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //workData.TrustEntrustCnt = 0;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            workData.SoldCnt = 0;
			workData.MovingSupliStock = 0;
			workData.MovingTrustStock = 0;
			workData.ShipmentPosCnt = workData.SupplierStock + workData.TrustCount;

			if (data.InventoryTolerancCnt < 0)
			{
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //workData.StockTotalPrice = workData.StockTotalPrice - data.StockUnitPrice;
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                workData.StockTotalPrice = workData.StockTotalPrice - longint;
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            }
			else if (data.InventoryTolerancCnt > 0)
			{
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //workData.StockTotalPrice = workData.StockTotalPrice + data.StockUnitPrice;
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                workData.StockTotalPrice = workData.StockTotalPrice + longint;
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<
            }

            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //workData.PrdNumMngDiv = data.PrdNumMngDiv;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            if (data.InventoryNewDiv == 1)
			{
                // 2007.09.20 �C�� >>>>>>>>>>>>>>>>>>>>
                //if (workData.LastStockDate < data.StockDate)
				//{
				//	workData.LastStockDate = data.StockDate;
				//}
                if (workData.LastStockDate < data.LastStockDate)
                {
                    workData.LastStockDate = data.LastStockDate;
                }
                // 2007.09.20 �C�� <<<<<<<<<<<<<<<<<<<<

			}
			else
			{
				if (workData.LastStockDate < data.LastStockDate)
				{
					workData.LastStockDate = data.LastStockDate;
				}
			}
			//workData.LastSalesDate = ;
			workData.LastInventoryUpdate = DateTime.Today;
            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //workData.CellphoneModelCode = data.CellphoneModelCode;
			//workData.CellphoneModelName = data.CellphoneModelName;
			//workData.CarrierCode = data.CarrierCode;
			//workData.CarrierName = data.CarrierName;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            workData.MakerName = data.MakerName;
			//workData.SystematicColorCd = data.SystematicColorCd;
            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //workData.SystematicColorNm = data.SystematicColorNm;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
//            workData.LargeGoodsGanreCode = data.LargeGoodsGanreCode;
//			workData.MediumGoodsGanreCode = data.MediumGoodsGanreCode;
            workData.LargeGoodsGanreCode = data.LargeGoodsGanreCode.TrimEnd();
            workData.MediumGoodsGanreCode = data.MediumGoodsGanreCode.TrimEnd();
            workData.MinimumStockCnt = 0;
			workData.MaximumStockCnt = 0;
			workData.NmlSalOdrCount = 0;
            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //workData.SalOdrLot = 0;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.20 �ǉ� >>>>>>>>>>>>>>>>>>>>
            workData.SalesOrderUnit = 0;
//            workData.WarehouseCode = data.WarehouseCode;
            workData.WarehouseCode = data.WarehouseCode.TrimEnd();
            workData.WarehouseName = data.WarehouseName;
            workData.GoodsNoNoneHyphen = "";
            workData.StockAssessmentRate = 0;
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            workData.DuplicationShelfNo1 = data.DuplicationShelfNo1;
            workData.DuplicationShelfNo2 = data.DuplicationShelfNo2;
            workData.PartsManagementDivide1 = "";
            workData.PartsManagementDivide2 = "";
            workData.StockNote1 = "";
            workData.StockNote2 = "";
            workData.ShipmentCnt = 0;
            workData.ArrivalCnt = 0;
            workData.StockCreateDate = DateTime.Today;
            workData.LargeGoodsGanreName = data.LargeGoodsGanreName;
            workData.MediumGoodsGanreName = data.MediumGoodsGanreName;
//            workData.DetailGoodsGanreCode = data.DetailGoodsGanreCode;
            workData.DetailGoodsGanreCode = data.DetailGoodsGanreCode.TrimEnd();
            workData.DetailGoodsGanreName = data.DetailGoodsGanreName;
            workData.BLGoodsCode = data.BLGoodsCode;
            workData.BLGoodsFullName = data.BLGoodsName;
            workData.GoodsShortName = "";
            workData.GoodsNameKana = "";
            workData.EnterpriseGanreCode = data.EnterpriseGanreCode;
            workData.EnterpriseGanreName = data.EnterpriseGanreName;
            workData.Jan = data.Jan;
            // 2007.09.20 �ǉ� <<<<<<<<<<<<<<<<<<<<
            
            if (isNew)
			{
				stockDictionary.Add(stockKey, workData);
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌Ƀ}�X�^�N���X��������
        /// </summary>
        /// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
        /// <param name="stockDictionary">�݌Ƀ}�X�^Dictionary</param>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�N���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void CreateStock(InventoryDataUpdateWork data, ref Dictionary<string, StockWork> stockDictionary)
        {
            string stockKey = CreateStockKey(data);

            bool isNew = false;
            StockWork workData = null;
            if (stockDictionary.ContainsKey(stockKey))
            {
                workData = stockDictionary[stockKey];
            }
            else
            {
                workData = new StockWork();
                isNew = true;
            }

            // ��ƃR�[�h
            workData.EnterpriseCode = data.EnterpriseCode;
            // �_���폜�敪
            workData.LogicalDeleteCode = 0;
            // ���_�R�[�h
            workData.SectionCode = data.SectionCode;
            // ���[�J�[�R�[�h
            workData.GoodsMakerCd = data.GoodsMakerCd;
            // �i��
            workData.GoodsNo = data.GoodsNo;

            //if (data.StockDiv == 0)
            //{
            //    // �d���P��
            //    workData.StockUnitPriceFl = data.StockUnitPriceFl;
            //    // �d���݌ɐ�
            //    workData.SupplierStock = workData.SupplierStock + data.InventoryTolerancCnt;
            //}
            //else
            //{
            //    // �d���P��
            //    workData.StockUnitPriceFl = 0;
            //    // �d���݌ɐ�
            //    workData.SupplierStock = 0;
            //}
            // �d���P��
            workData.StockUnitPriceFl = data.StockUnitPriceFl;
            // �d���݌ɐ�
            workData.SupplierStock = data.InventoryTolerancCnt;
            // �o�׉\��
            workData.ShipmentPosCnt = workData.SupplierStock;

            if (data.InventoryTolerancCnt < 0)
            {
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                // �o�ɕۗL���z
                workData.StockTotalPrice = workData.StockTotalPrice - longint;
            }
            else if (data.InventoryTolerancCnt > 0)
            {
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                // �o�ɕۗL���z
                workData.StockTotalPrice = workData.StockTotalPrice + longint;
            }
            if (data.InventoryNewDiv == 1)
            {
                if (workData.LastStockDate < data.LastStockDate)
                {
                    // �ŏI�d���N����
                    workData.LastStockDate = data.LastStockDate;
                }
            }
            else
            {
                if (workData.LastStockDate < data.LastStockDate)
                {
                    // �ŏI�d���N����
                    workData.LastStockDate = data.LastStockDate;
                }
            }
            // �ŏI�I���X�V��
            workData.LastInventoryUpdate = data.InventoryDay;
            // �q�ɃR�[�h
            workData.WarehouseCode = data.WarehouseCode.TrimEnd();
            // �q�ɖ�
            workData.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim());
            // �n�C�t�������i�ԍ�
            workData.GoodsNoNoneHyphen = "";
            // �q�ɒI��
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // �d���I��1
            workData.DuplicationShelfNo1 = data.DuplicationShelfNo1;
            // �d���I��2
            workData.DuplicationShelfNo2 = data.DuplicationShelfNo2;
            // �݌ɓo�^��
            workData.StockCreateDate = DateTime.Today;
            // �X�V�N����
            workData.UpdateDate = DateTime.Today;
            if (isNew)
            {
                stockDictionary.Add(stockKey, workData);
            }
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// �݌ɏ��L�[�����񐶐�����
		/// </summary>
		/// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
		/// <returns>�݌ɏ��L�[������</returns>
        /// <remarks>
        /// <br>Note       : �݌ɏ��L�[������𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
		private string CreateStockKey(InventoryDataUpdateWork data)
		{
			return data.SectionCode.Trim() + data.GoodsMakerCd + "-" + data.GoodsNo.Trim();
        }

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �݌ɒ����f�[�^���[�N�I�u�W�F�N�g�𐶐����܂��B
		/// </summary>
		/// <param name="data"></param>
		/// <returns>�݌ɒ����f�[�^���[�N�I�u�W�F�N�g</returns>
		private StockAdjustWork CreateStockAdjust(InventoryDataUpdateWork data)
		{
			StockAdjustWork workData = new StockAdjustWork();

			workData.EnterpriseCode = data.EnterpriseCode;
			workData.SectionCode = data.SectionCode;
			workData.AcPaySlipCd = 50;		// 50:�I��
			workData.AcPayTransCd = 40;		// 40:�ߕs���X�V
			workData.AdjustDate = data.InventoryDay;
            workData.InputAgenCd = LoginInfoAcquisition.Employee.EmployeeCode;
            workData.InputAgenNm = LoginInfoAcquisition.Employee.Name;

			return workData;
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �ŏI�����X�V���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�ŏI�����X�V��</returns>
        /// <remarks>
        /// <br>Note       : �ŏI�����X�V�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/16 ����� �o�l�D�m�r�ێ�˗��B</br>
        /// <br>             �O�񌎎��X�V���t�̎擾��ύX����</br>
        /// <br>Update Note: 2012/07/19 yangyi</br>
        /// <br>             redmine#31106 �u�I���ߕs���X�V�v�̕��׌y���Ə������ԒZ�k�̒���</br>
        /// </remarks>
        private DateTime GetPrevTotalDay(string sectionCode)
        {
            DateTime prevTotalDay = new DateTime();

            int status = 0;
            // ----- ADD 2012/07/19 ---------->>>>>
            if (this._totalDayDic.ContainsKey(sectionCode))
            {
                prevTotalDay = _totalDayDic[sectionCode];
            }
            else
            {
            // ----- ADD 2012/07/19 ----------<<<<<
                try
                {
                    status = this._totalDayCalculator.GetHisTotalDayMonthly(sectionCode, out prevTotalDay);

                    // --- ADD 2009/12/03 ---------->>>>>
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        status = this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                    }
                    // --- ADD 2009/12/03 ----------<<<<<

                    if (status != 0)
                    {
                        prevTotalDay = new DateTime();
                    }
                    this._totalDayDic.Add(sectionCode, prevTotalDay);  //ADD 2012/07/19 
                }
                catch
                {
                    prevTotalDay = new DateTime();
                }
            }   //ADD 2012/07/19
            return prevTotalDay;
        }

        /// <summary>
        /// �݌ɒ����f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
        /// <returns>�݌ɒ����f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �݌ɒ����f�[�^�쐬���̏�Q�̏C��</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(InventoryDataUpdateWork data)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // ��ƃR�[�h
            workData.EnterpriseCode = data.EnterpriseCode;
            // ���_�R�[�h
            //workData.SectionCode = data.SectionCode;                                  //DEL 2009/04/28 �s��Ή�[13091]
            workData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;     //ADD 2009/04/28 �s��Ή�[13091]
            // ���_��
            //workData.SectionGuideNm = GetSectionName(data.SectionCode.Trim());        //DEL 2009/04/28 �s��Ή�[13091]
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim());      //ADD 2009/04/28 �s��Ή�[13091]
            // �󕥌��`�[�敪(50�F�I��)
            workData.AcPaySlipCd = 50;
            // �󕥌�����敪(40�F�ߕs���X�V)
            workData.AcPayTransCd = 40;
            // �������t
            // �O����������擾
            DateTime prevTotalDay = GetPrevTotalDay(data.SectionCode);
            if (data.InventoryDate <= prevTotalDay)
            {
                // �I�����{�����Z�b�g
                //workData.AdjustDate = data.InventoryDay; // DEL 2009/12/03
                workData.AdjustDate = prevTotalDay.AddDays(1); // ADD 2009/12/03
            }
            else
            {
                // �I�������Z�b�g
                workData.AdjustDate = data.InventoryDate;
            }
            // ���͓��t
            //workData.InputDay = data.InventoryDay; // DEL 2009/12/03
            workData.InputDay = DateTime.Now; // ADD 2009/12/03
            // �d�����_�R�[�h
            workData.StockSectionCd = data.SectionCode;
            // �d�����_����
            workData.StockSectionGuideNm = GetSectionName(data.SectionCode.Trim());
            // �d�����͎҃R�[�h
            workData.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;
            // �d�����͎Җ���
            workData.StockInputName = LoginInfoAcquisition.Employee.Name;
            // �d���S���҃R�[�h
            workData.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
            // �d���S���Җ���
            workData.StockAgentName = LoginInfoAcquisition.Employee.Name;

            return workData;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/10 Partsman�p�ɕύX
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌ɒ������׃f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="workData"></param>
        /// <returns>�݌ɒ������׃f�[�^�I�u�W�F�N�g</returns>
        private void CreateStockAdjustDtl(InventoryDataUpdateWork data, ref ArrayList retList)
        {
            EachWarehouseStockAdjustDtlWork workData = new EachWarehouseStockAdjustDtlWork();

            // �쐬����
            workData.CreateDateTime = DateTime.MinValue;

            // �X�V����
            workData.UpdateDateTime = DateTime.MinValue;
			
            // ��ƃR�[�h
            workData.EnterpriseCode = data.EnterpriseCode;

            // GUID
            workData.FileHeaderGuid = Guid.Empty;

            // �X�V�]�ƈ��R�[�h
            workData.UpdEmployeeCode = "";
			
            // �X�V�A�Z���u��ID1
            workData.UpdAssemblyId1 = "";
			
            // �X�V�A�Z���u��ID2
            workData.UpdAssemblyId2 = "";
			
            // �_���폜�敪
            workData.LogicalDeleteCode = 0;
			
            // ���_�R�[�h
            workData.SectionCode = data.SectionCode;
			
            // �݌ɒ����`�[�ԍ�
            workData.StockAdjustSlipNo = 0;
			
            // �݌ɒ����s�ԍ�
            workData.StockAdjustRowNo = retList.Count + 1;
			
            // �󕥌��`�[�敪
            workData.AcPaySlipCd = 50;		// 50:�I����
			
            // �󕥌�����敪
            workData.AcPayTransCd = 40;		// 40:�ߕs���X�V

            // �������t
            workData.AdjustDate = data.InventoryDay;

            // ���[�J�[�R�[�h
            workData.GoodsMakerCd = data.GoodsMakerCd;
			
            // ���[�J�[����
            workData.MakerName = data.MakerName;
			
            // ���i�R�[�h
            workData.GoodsNo = data.GoodsNo;
			
            // ���i����
            workData.GoodsName = data.GoodsName;

            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���ԊǗ��敪                        
            //workData.PrdNumMngDiv = data.PrdNumMngDiv;
            //
            //// �����ԍ�
            //workData.ProductNumber = data.ProductNumber;
            //
            //// �ύX�O�����ԍ�            
            //workData.BfProductNumber = data.ProductNumber;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<
            
            // �d���P��
            workData.StockUnitPriceFl = data.StockUnitPriceFl;
            
            // �ύX�O�d���P��
            workData.BfStockUnitPriceFl = data.BfStockUnitPriceFl;

            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���i�d�b�ԍ�1
            //workData.StockTelNo1 = data.StockTelNo1;
            //
            //// �ύX�O���i�d�b�ԍ�1 �ύX�Ȃ�
            //
            //// ���i�d�b�ԍ�2
            //workData.StockTelNo2 = data.StockTelNo2;
            //
            //// �ύX�O���i�`�[�ԍ�2 �ύX�Ȃ�
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<

            // �d���݌ɐ�
            if (data.StockDiv == 0)			// �݌ɋ敪 0:����
            {
                workData.SupplierStock = data.InventoryStockCnt;
                workData.TrustCount = 0;
            }
            else if (data.StockDiv == 1)	// �݌ɋ敪 1:���
            {
                workData.SupplierStock = 0;
                workData.TrustCount = data.InventoryStockCnt;
            }

            // 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //// �݌ɏ��
            //workData.StockState = data.StockState;
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<

            // �݌ɋ敪
            workData.StockDiv = data.StockDiv;

            // ������
            workData.AdjustCount = data.InventoryTolerancCnt;

            // �ύX�O�݌ɏ��
            workData.BfStockState = data.StockDiv;
            
            //// 2007.09.20 �폜 >>>>>>>>>>>>>>>>>>>>
            //// ���i���
            //workData.GoodsCodeStatus = data.GoodsCodeStatus;
            //
            //// �����ԍ��}�X�^GUID
            //workData.ProductStockGuid = data.ProductStockGuid;
            //
            //// �����������ċ敪
            //workData.AutoProductStockDrawingDiv = 0;			// �����������Ă��Ȃ�
            // 2007.09.20 �폜 <<<<<<<<<<<<<<<<<<<<

            // �q�ɃR�[�h
            workData.WarehouseCode = data.WarehouseCode;
			
            // �q�ɖ���
            workData.WarehouseName = data.WarehouseName;

            // 2007.09.20 �ǉ� >>>>>>>>>>>>>>>>>>>>
            // ���ה��l
            workData.DtlNote = "";

            // �a�k���i�R�[�h
            workData.BLGoodsCode = data.BLGoodsCode;

            // �a�k���i�R�[�h�}��
            workData.BLGoodsCdDerivedNo = data.BLGoodsCdDerivedNo;

            // �q�ɒI��
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // 2007.09.20 �ǉ� <<<<<<<<<<<<<<<<<<<<

            retList.Add(workData);
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman�p�ɕύX

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �݌ɒ������׃f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
        /// <param name="retList">�݌ɒ������׃f�[�^���X�g</param>
        /// <returns>�݌ɒ������׃f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ������׃f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/03 ����� PM.NS�@�ێ�Ή�</br>
        /// <br>             �݌ɒ������׃f�[�^�̎d�����z�i�Ŕ����j�́u���P���~�d�����v�ƂȂ�悤�ɕύX����@</br>
        /// <br>UpdateNote : 2010/02/23 �k���r �o�l�V�����ȏ�̏������x�։��ǂ���B</br>
        /// </remarks>
        private void CreateStockAdjustDtl(InventoryDataUpdateWork data, ref ArrayList retList)
        {
            StockAdjustDtlWork workData = new StockAdjustDtlWork();

            // ��ƃR�[�h
            workData.EnterpriseCode = data.EnterpriseCode;
            // ���_�R�[�h
            //workData.SectionCode = data.SectionCode;                                  //DEL 2009/04/28 �s��Ή�[13091]
            workData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;     //ADD 2009/04/28 �s��Ή�[13091]
            // ���_��
            //workData.SectionGuideNm = GetSectionName(data.SectionCode.Trim());        //DEL 2009/04/28 �s��Ή�[13091]
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim());      //ADD 2009/04/28 �s��Ή�[13091]
            // �݌ɒ����`�[�ԍ�
            workData.StockAdjustSlipNo = 0;
            // �݌ɒ����s�ԍ�
            workData.StockAdjustRowNo = retList.Count + 1;
            // �󕥌��`�[�敪(50:�I��)
            workData.AcPaySlipCd = 50;
            // �󕥌�����敪(40:�ߕs���X�V)
            workData.AcPayTransCd = 40;
            // �������t
            // �O����������擾
            DateTime prevTotalDay = GetPrevTotalDay(data.SectionCode);
            if (data.InventoryDate <= prevTotalDay)
            {
                // �I�����{�����Z�b�g
                //workData.AdjustDate = data.InventoryDay; // DEL 2009/12/03
                workData.AdjustDate = prevTotalDay.AddDays(1); // ADD 2009/12/03
            }
            else
            {
                // �I�������Z�b�g
                workData.AdjustDate = data.InventoryDate;
            }
            // ���͓��t
            //workData.InputDay = data.InventoryDay; // DEL 2009/12/03
            workData.InputDay = DateTime.Now; // ADD 2009/12/03
            // ���[�J�[�R�[�h
            workData.GoodsMakerCd = data.GoodsMakerCd;
            // ���[�J�[����
            workData.MakerName = GetMakerName(data.GoodsMakerCd);
            // ���i�R�[�h
            workData.GoodsNo = data.GoodsNo;
            // ���i����
            // --- UPD 2010/02/23 ----------<<<<<
            //workData.GoodsName = GetGoodsName(data.GoodsMakerCd, data.GoodsNo.Trim());
            workData.GoodsName = data.GoodsName;
            // --- UPD 2010/02/23 ---------->>>>>
            // �d���P��
            //workData.StockUnitPriceFl = data.StockUnitPriceFl;                                        //DEL 2009/05/22 �s��Ή�[13263]
            workData.StockUnitPriceFl = data.AdjstCalcCost;                                             //ADD 2009/05/22 �s��Ή�[13263]
            // �ύX�O�d���P��
            //workData.BfStockUnitPriceFl = data.BfStockUnitPriceFl; // DEL 2009/12/03
            workData.BfStockUnitPriceFl = workData.StockUnitPriceFl; // ADD 2009/12/03
            // ������
            workData.AdjustCount = data.InventoryTolerancCnt;
            // ���ה��l
            workData.DtlNote = "";
            // �q�ɃR�[�h
            workData.WarehouseCode = data.WarehouseCode;
            // �q�ɖ���
            workData.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim());
            // BL�R�[�h
            workData.BLGoodsCode = data.BLGoodsCode;
            // BL�R�[�h����
            workData.BLGoodsFullName = GetBLGoodsName(data.BLGoodsCode);
            // �q�ɒI��
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // �d�����z
            //workData.StockPriceTaxExc = (long)(data.InventoryTolerancCnt * data.StockUnitPriceFl);    //DEL 2009/05/22 �s��Ή�[13263]
            //workData.StockPriceTaxExc = (long)(data.InventoryTolerancCnt * data.AdjstCalcCost);         //ADD 2009/05/22 �s��Ή�[13263] DEL 2009/09/14
            // -- ADD 2009/09/14 --------------------------->>>
            //�݌ɊǗ��S�̐ݒ�̒[�������敪���g�p����悤�ɏC��
            long retMoney;
            //FractionCalculate.FracCalcMoney(data.InventoryTolerancCnt * data.StockUnitPriceFl, 1.00, this._stockMngTtlSt.FractionProcCd, out retMoney); // DEL 2009/12/03
            FractionCalculate.FracCalcMoney(data.InventoryTolerancCnt * data.AdjstCalcCost, 1.00, this._stockMngTtlSt.FractionProcCd, out retMoney); // ADD 2009/12/03
            workData.StockPriceTaxExc = retMoney;
            // -- ADD 2009/09/14 ---------------------------<<<

            // �艿
            if (data.InventoryDate <= prevTotalDay)
            {
                // �I�����{�����Z�b�g
                //workData.ListPriceFl = GetListPriceFl(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate); //DEL yangyi 2013/10/09 Redmine#31106 
                workData.ListPriceFl = GetListPriceFl2(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate);  //ADD yangyi 2013/10/09 Redmine#31106 
            }
            else
            {
                // �I�������Z�b�g
                //workData.ListPriceFl = GetListPriceFl(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate); //DEL yangyi 2013/10/09 Redmine#31106 
                workData.ListPriceFl = GetListPriceFl2(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate);  //ADD yangyi 2013/10/09 Redmine#31106 
            }

            retList.Add(workData);
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ���t��������擾���܂��B
		/// </summary>
		/// <param name="date">���t</param>
		/// <param name="format">�t�H�[�}�b�g������</param>
		/// <returns>���t������</returns>
		public static string GetDateTimeString(DateTime date, string format)
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
		}
        
        /// <summary>
		/// ������E������
		/// </summary>
		/// <param name="sjisEnc">�G���R�[�h</param>
		/// <param name="totalLength">�ő僌���O�X</param>
		/// <param name="sourceString">��������</param>
		/// <param name="paddingChar">�ǉ�����</param>
		/// <returns>�ҏW�㕶����</returns>
		private string PadRight(Encoding sjisEnc, int totalLength, string sourceString, char paddingChar)
		{
			int currentLength = sjisEnc.GetByteCount(sourceString.Trim());

			StringBuilder builder = new StringBuilder(sourceString);

			for (int i = currentLength; i < totalLength; i++)
			{
				builder.Append(paddingChar);
			}

			return builder.ToString();
		}
        
        /// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^�����[�h���A�I�u�W�F�N�g���ɃL���b�V�����܂��B
		/// </summary>
		private void ReadStockMngTtlSt()
		{
			if (_stockMngTtlSt == null)
			{
				// �d���S�̐ݒ�}�X�^
				StockMngTtlSt stockMngTtlSt;
				StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
				int status = stockMngTtlStAcs.Read(out stockMngTtlSt, LoginInfoAcquisition.EnterpriseCode, 0);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this.CacheStockMngTtlSt(stockMngTtlSt);
				}
			}
		}
        
        /// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^�I�u�W�F�N�g���L���b�V�����܂��B
		/// </summary>
		/// <param name="stockMngTtlSt">�݌ɊǗ��S�̐ݒ�}�X�^�N���X</param>
		private void CacheStockMngTtlSt(StockMngTtlSt stockMngTtlSt)
		{
			_stockMngTtlSt = stockMngTtlSt;
		}
        
        /// <summary>
		/// ���O�o��(DEBUG)����
		/// </summary>
		/// <param name="pMsg">���b�Z�[�W</param>
		public static void LogWrite(string pMsg)
		{
#if DEBUG
			System.IO.FileStream _fs;										// �t�@�C���X�g���[��
			System.IO.StreamWriter _sw;										// �X�g���[��writer
			_fs = new System.IO.FileStream("MAZAI09992A.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
			if (_sw != null)
				_sw.Close();
			if (_fs != null)
				_fs.Close();
#endif
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �݌ɊǗ��S�̐ݒ� ADD 2009/05/22 �s��Ή�[13263]
        // ---ADD 2009/05/22 �s��Ή�[13263] ---------------------------------->>>>>
        #region ReadStockMngTtlSt(�݌ɑS�̊Ǘ��ݒ�ǂݍ���)
        /// <summary>
        /// �݌ɑS�̊Ǘ��ݒ�ǂݍ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌ɊǗ��S�̐ݒ�����擾���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private void ReadStockMngTtlSt()
        {
            ArrayList retList;

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        this._stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                this._stockMngTtlSt = new StockMngTtlSt();
            }
        }
        #endregion

        #region StockTotalPriceToLong(�݌ɋ��z�Z�o)
        /// <summary>
        /// ���z�Z�o(Long�^�ŕԂ�)
        /// </summary>
        /// <param name="unitCount">����</param>
        /// <param name="unitCost">����</param>
        /// <returns>���v���z</returns>
        /// <remarks>
        /// <br>Note       : ���z���Z�o���A�݌ɊǗ��S�̐ݒ�̒[�������敪�ɏ]���Ē[���������s���܂��B</br>
        /// <br>Programmer : �Ɠc �M�u</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public long GetTotalPriceToLong(double unitCount, double unitCost)
        {
            long longStockTotalPrice = 0;
            double doubleStockTotalPrice = unitCost * unitCount;       // ���P���~����

            // �݌ɑS�̊Ǘ��ݒ�̒[�������敪�ɏ]��
            switch (this._stockMngTtlSt.FractionProcCd)
            {
                case 1:
                    {
                        // �؂�̂�
                        longStockTotalPrice = (long)(doubleStockTotalPrice / 1);
                        break;
                    }
                case 2:
                    {
                        // �l�̌ܓ�
                        if (doubleStockTotalPrice >= 0)
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);
                        }
                        else
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice - 0.5) / 1);
                        }
                        break;
                    }
                case 3:
                    {
                        // �؂�グ
                        if (doubleStockTotalPrice % 1 == 0)
                        {
                            longStockTotalPrice = (long)(doubleStockTotalPrice);
                        }
                        else
                        {
                            if (doubleStockTotalPrice >= 0)
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);
                            }
                            else
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice - 1) / 1);
                            }
                        }
                        break;
                    }
                default:
                    {
                        longStockTotalPrice = (long)(doubleStockTotalPrice);
                        break;
                    }
            }

            return longStockTotalPrice;
        }
        #endregion
        // ---ADD 2009/05/22 �s��Ή�[13263] ----------------------------------<<<<<

        // --- ADD 2009/12/03 ---------->>>>>
        #region key�̐ݒ�
        /// <summary>
        /// key�̐ݒ�
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : key�̐ݒ���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        private string CreatKey(InventoryUpdateDataSet.InventoryRow row)
        {
            StringBuilder key = new StringBuilder();

            if (row != null)
            {
                // ���_�R�[�h
                key.Append(row.SectionCode);
                // �I���ʔ�
                key.Append(row.InventorySeqNo.ToString());
                // �q�ɃR�[�h
                key.Append(row.WarehouseCode);
            }

            return key.ToString();
        }

        /// <summary>
        /// key�̐ݒ�
        /// </summary>
        /// <param name="work">work</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : key�̐ݒ���s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        private string CreatKey(InventoryDataUpdateWork work)
        {
            StringBuilder key = new StringBuilder();

            if (work != null)
            {
                // ���_�R�[�h
                key.Append(work.SectionCode);
                // �I���ʔ�
                key.Append(work.InventorySeqNo.ToString());
                // �q�ɃR�[�h
                key.Append(work.WarehouseCode);
            }

            return key.ToString();
        }
        #endregion key�̐ݒ�
        // --- ADD 2009/12/03 ----------<<<<<
        #endregion
    }
}
