//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ菈��
// �v���O�����T�v   : �����_�ݒ菈���A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100937-00 �쐬�S�� : ����g  
// �C �� ��  2015/06/03  �C�����e : Redmine#45978 �C�X�R�W���p�� ����q�ɓ��œ���i�Ԃ������󎚂����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100937-00 �쐬�S�� : ���c��
// �C �� ��  2015/07/13  �C�����e : Redmine#45978 ���C�����ԉۑ�Ή��Č�No.3:���i�}�X�^�̏��i�������A0�F�����̏��i�����ΏۂƂȂ炸�A
//                                                1:���̑���ݒ肵�Ă���D�Ǖi�Ԃ����o�ΏۊO�ƂȂ��Ă��܂��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100937-00 �쐬�S�� : ����g
// �C �� ��  2015/08/13  �C�����e : Redmine#45978��#93��#94 �d����擾�A���P���Z�o�̏�Q�Ή��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11100937-00 �쐬�S�� : ����g
// �C �� ��  2015/08/26  �C�����e : Redmine#45978  ���Аݒ�̊|���D�揇�ʋ敪���Q�Ƃ��Ă��Ȃ���Q�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����_�ݒ菈���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ菈���Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// </remarks>
    public class OrderPointStSimulationAcs
    {
        #region �� Constructor
		/// <summary>
        /// �����_�ݒ菈���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �����_�ݒ菈���A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : ���w�q</br>
	    /// <br>Date       : 2009.04.13</br>
        /// <br>UpdateNote : Redmine#45978 ���Аݒ�̊|���D�揇�ʋ敪���Q�Ƃ��Ă��Ȃ���Q�Ή�</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2015/08/26</br>
		/// </remarks>
		public OrderPointStSimulationAcs()
		{
            this._iOrderPointStSimulationDB = (IOrderPointStSimulationDB)MediationOrderPointStSimulationDB.GetOrderPointStSimulationDB();
            this._goodsAcs = new GoodsAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._taxRateSet = new TaxRateSet();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._stockMngTtlStAcs = new StockMngTtlStAcs();
            this._stockMngTtlSt = new StockMngTtlSt();
            // ---- ADD ����g 2015/08/26 FOR Redmine45978 ���Аݒ�̊|���D�揇�ʋ敪���Q�Ƃ��Ă��Ȃ���Q�Ή� ---->>>>
            this._companyInfAcs = new CompanyInfAcs(); 
            SetUnitPriceCalculation();  // ���Аݒ�|���D�揇�ʋ敪(���P���Z�o�p)�@
            // ---- ADD ����g 2015/08/26 FOR Redmine45978 ���Аݒ�̊|���D�揇�ʋ敪���Q�Ƃ��Ă��Ȃ���Q�Ή� ----<<<<

        }

		/// <summary>
        /// �����_�ݒ菈���\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : �����_�ݒ菈���\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        static OrderPointStSimulationAcs()
		{
			stc_Employee = null;
            stc_PrtOutSet = null;					// ���[�o�͐ݒ�f�[�^�N���X
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X
			// ���O�C�����_�擾
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion �� Constructor

        #region �� Static Member
        private static Employee stc_Employee;
        private static PrtOutSet stc_PrtOutSet;			// ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	// ���[�o�͐ݒ�A�N�Z�X�N���X
        #endregion �� Static Member

        #region �� Private Member
        IOrderPointStSimulationDB _iOrderPointStSimulationDB;           // �����_�ݒ菈�������[�g
        private DataSet _dataSet;  // ���DataSet
        private TaxRateSetAcs _taxRateSetAcs;           // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
        private TaxRateSet _taxRateSet;
        // ���i�A���f�[�^���[�J���L���b�V��
        private Dictionary<string, GoodsUnitData> _goodsUnitDataDic;
        // ���i�A�N�Z�X
        private GoodsAcs _goodsAcs;
        // ���i�A�N�Z�X�N���X�̒��o����
        private List<GoodsCndtn> _goodsCndtnList;
        private UnitPriceCalculation _unitPriceCalculation;
        // �݌ɊǗ��S�̐ݒ�}�X�^�A�N�Z�X
        private StockMngTtlStAcs _stockMngTtlStAcs;
        // ���Аݒ�}�X�^�A�N�Z�X
        CompanyInfAcs _companyInfAcs; // ADD ����g 2015/08/26 FOR Redmine45978 ���Аݒ�̊|���D�揇�ʋ敪���Q�Ƃ��Ă��Ȃ���Q�Ή�
        private StockMngTtlSt _stockMngTtlSt;
        #endregion �� Private Member

        #region �� Const Member
        private const string ct_septation = "^";
        #endregion �� Const Member

        #region [public �v���p�e�B]
        /// <summary>
        /// �f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
            set { this._dataSet = value; }
        }
        #endregion

        #region �� Public Method
        #region �� �f�[�^�擾
        /// <summary>
        /// �����_�ݒ菈���f�[�^�擾
        /// </summary>
        /// <param name="cndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������锭���_�ݒ菈���f�[�^���擾����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public int Search(ExtrInfo_OrderPointStSimulationWorkTbl cndtn, out string errMsg)
        {
            return this.SearchProc(cndtn, out errMsg);
        }
        #endregion
        #endregion �� Public Method

        #region �� Private Method
        #region �� �����_�ݒ菈���f�[�^�擾
        /// <summary>
        /// �����_�ݒ菈���f�[�^�擾
        /// </summary>
        /// <param name="cndtn"></param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������锭���_�ݒ菈���f�[�^���擾����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int SearchProc(ExtrInfo_OrderPointStSimulationWorkTbl cndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;

            try
            {
                // DataTable Create ----------------------------------------------------------
                OrderPointStSimulationTbl.CreateDataTableOrderPointStSimulationTbl(ref this._dataSet);

                ExtrInfo_OrderPointStSimulationWork paramWork = new ExtrInfo_OrderPointStSimulationWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevOrderPointStSimulationWorkTbl(cndtn, out paramWork, out errMsg);
                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object retStockList = null;
                status = this._iOrderPointStSimulationDB.Search(out retList, out retStockList, paramWork);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        status = DevOrderPointStSimulationWorkListData(cndtn, this._dataSet.Tables[OrderPointStSimulationTbl.Col_Tbl_Result_OrderPointStSimulation], (ArrayList)retList, (ArrayList)retStockList);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�����_�ݒ菈���f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion

        #region �� �f�[�^�W�J����
        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="workTbl">UI���o�����N���X</param>
        /// <param name="work">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevOrderPointStSimulationWorkTbl(ExtrInfo_OrderPointStSimulationWorkTbl workTbl, out ExtrInfo_OrderPointStSimulationWork work, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            errMsg = string.Empty;
            work = new ExtrInfo_OrderPointStSimulationWork();

            try
            {
                work.EnterpriseCode = workTbl.EnterpriseCode;               // ��ƃR�[�h
                work.SettingCode = workTbl.SettingCode;                     // �ݒ�R�[�h
                work.St_WarehouseCode = workTbl.St_WarehouseCode;           // �J�n�q�ɃR�[�h
                work.Ed_WarehouseCode = workTbl.Ed_WarehouseCode;           // �I���q�ɃR�[�h
                work.St_SupplierCd = workTbl.St_SupplierCd;	                // �J�n�d����R�[�h
                work.Ed_SupplierCd = workTbl.Ed_SupplierCd;                 // �I���d����R�[�h
                work.St_GoodsMakerCd = workTbl.St_GoodsMakerCd;	            // �J�n���[�J�[�R�[�h
                work.Ed_GoodsMakerCd = workTbl.Ed_GoodsMakerCd;	            // �I�����[�J�[�R�[�h
                work.St_GoodsMGroup = workTbl.St_GoodsMGroup;	            // �J�n���i������
                work.Ed_GoodsMGroup = workTbl.Ed_GoodsMGroup;	            // �I�����i������
                work.St_BLGroupCode = workTbl.St_BLGroupCode;	            // �J�n�O���[�v�R�[�h
                work.Ed_BLGroupCode = workTbl.Ed_BLGroupCode;	            // �I���O���[�v�R�[�h
                work.St_BLGoodsCode = workTbl.St_BLGoodsCode;	            // �J�nBL�R�[�h
                work.Ed_BLGoodsCode = workTbl.Ed_BLGoodsCode;	            // �I��BL�R�[�h
                work.SumMethod = workTbl.SumMethodCd;	                    // �W�v���@
                work.OutPutDiv = workTbl.OutPutDiv;	                        // �o�͏�
                work.StckShipMonthSt = workTbl.StckShipMonthSt;             // �݌ɏo�בΏۊJ�n��
                work.StckShipMonthEd = workTbl.StckShipMonthEd;             // �݌ɏo�בΏۏI����
                work.ManagementDivide1 = workTbl.ManagementDivide1;         // �Ǘ��敪�P
                work.ManagementDivide2 = workTbl.ManagementDivide2;         // �Ǘ��敪�Q
                // ADD 2009/07/14
                work.OrderApplyDiv = workTbl.OrderApplyDiv;                 // �����K�p�敪 
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
                #endregion

        #region �� �����_�ݒ菈���f�[�^�W�J����
        /// <summary>
        /// �����_�ݒ菈���f�[�^�W�J����
        /// </summary>
        /// <param name="paramWork">���o�����N���X</param>
        /// <param name="orderPointStDt">�W�J�Ώ�DataTable</param>
        /// <param name="orderPointStWorkList">�擾�f�[�^</param>
        /// <param name="stockList">�݌Ƀf�[�^���X�g</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �����_�ݒ菈���f�[�^��W�J����B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int DevOrderPointStSimulationWorkListData(ExtrInfo_OrderPointStSimulationWorkTbl paramWork, DataTable orderPointStDt, ArrayList orderPointStWorkList, ArrayList stockList)
        {
            _goodsCndtnList = new List<GoodsCndtn>();
            foreach (OrderPointStSimulationWork orderPointStSimulationWork in orderPointStWorkList)
            {
                // ���i�A�N�Z�X�N���X�̒��o������ݒ�
                GoodsCndtn workGoodsCndtn = new GoodsCndtn();
                workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                workGoodsCndtn.SectionCode = orderPointStSimulationWork.SectionCode;
                workGoodsCndtn.MakerName = orderPointStSimulationWork.GoodsMakerNm;
                workGoodsCndtn.GoodsNoSrchTyp = 0;
                workGoodsCndtn.GoodsMakerCd = orderPointStSimulationWork.GoodsMakerCd;
                workGoodsCndtn.GoodsNo = orderPointStSimulationWork.GoodsNo;
                workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                // ------------------ ADD BY ���c�� 2015/07/13 FOR ���C�����ԉۑ�Ή��Č�No.3------------------------>>>>>
                // ���i����:0 ���� 1:���̑� �̏��i�擾
                workGoodsCndtn.GoodsKindCode = 9;
                // ------------------ ADD BY ���c�� 2015/07/13 FOR ���C�����ԉۑ�Ή��Č�No.3------------------------<<<<<
                this._goodsCndtnList.Add(workGoodsCndtn);
            }
            this.GoodsRead(this._goodsCndtnList);

            // �ŗ����擾����
            this.ReadTaxRate();

            // �݌ɊǗ��S�̐ݒ�}�X�^���擾����
            this.ReadStockMngTtlSt();

            // �[���敪�̐ݒ�
            paramWork.FractionProcCd = this._stockMngTtlSt.FractionProcCd;

            for (int i = 0; i < orderPointStWorkList.Count; i++)
            {
                OrderPointStSimulationWork orderPointStSimulationWork = (OrderPointStSimulationWork)orderPointStWorkList[i];
                StockWork stockWork = (StockWork)stockList[i];

                DataSetOrderPointStSimulation(paramWork, orderPointStDt, orderPointStSimulationWork, stockWork);
            }

            if (orderPointStDt.Rows.Count == 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        #endregion

        /// <summary>
        /// �擾�f�[�^�ݒ菈��
        /// </summary>
        /// <param name="paramWork">���o�����N���X</param>
        /// <param name="orderPointStDt">�W�J�Ώ�DataTable</param>
        /// <param name="work">�擾�f�[�^</param>
        /// <param name="stockWork">�݌Ƀf�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��ݒ肷��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br>Note       : Redmine#45978��#93��#94 �d����擾�A���P���Z�o�̏�Q�Ή��B</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2015/08/13</br>
        /// </remarks>
        private void DataSetOrderPointStSimulation(ExtrInfo_OrderPointStSimulationWorkTbl paramWork, DataTable orderPointStDt, OrderPointStSimulationWork work, StockWork stockWork)
        {
            string key = string.Empty;
            if (work.GoodsMakerCd == 0)
            {
                key = work.GoodsNo;
            }
            else
            {
                key = work.GoodsMakerCd.ToString("d04") + ct_septation + work.GoodsNo;
            }
            if (!this._goodsUnitDataDic.ContainsKey(key))
            {
                return;
            }
            GoodsUnitData goodsUnitData = this._goodsUnitDataDic[key];
            
            // ------------------ ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------>>>>>
            // �݌ɊǗ����_���d������擾����
            goodsUnitData.SectionCode = work.SectionCode;  // ADD ����g 2015/08/13 �d����擾�A���P���Z�o�̏�Q�Ή�
            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);  // ADD ����g 2015/08/13 �d����擾�A���P���Z�o�̏�Q�Ή�
            // ��L���i�A�N�Z�X���i���ɂ͋��_�����Z�b�g�����̂ŁA�Đݒ肷��
            goodsUnitData.SectionCode = work.SectionCode;  // ADD ����g 2015/08/13 �d����擾�A���P���Z�o�̏�Q�Ή�
            // �擾�����d����R�[�h�����͔͈͈ȊO�̏ꍇ�A�󎚑ΏۊO�Ƃ���
            if (paramWork.St_SupplierCd != 0 && goodsUnitData.SupplierCd < paramWork.St_SupplierCd)
            {
                return;
            }
            if (paramWork.Ed_SupplierCd != 0 && goodsUnitData.SupplierCd > paramWork.Ed_SupplierCd)
            {
                return;
            }
            // ------------------ ADD ����g 2015/06/03 ����q�ɓ��œ���i�Ԃ������󎚂����C�� ------------------------<<<<<
            DataRow dr;
            dr = orderPointStDt.NewRow();

            #region �����_�ݒ菈���f�[�^�W�J
            dr[OrderPointStSimulationTbl.Col_UpdateDateTime] = work.UpdateDateTime;
            dr[OrderPointStSimulationTbl.Col_EnterpriseCode] = work.EnterpriseCode;
            dr[OrderPointStSimulationTbl.Col_SectionCode] = work.SectionCode;
            dr[OrderPointStSimulationTbl.Col_SectionName] = work.SectionName;
            dr[OrderPointStSimulationTbl.Col_PatterNo] = work.PatterNo;
            dr[OrderPointStSimulationTbl.Col_PatternNoDerivedNo] = work.PatternNoDerivedNo;
            dr[OrderPointStSimulationTbl.Col_SettingCode] = work.PatterNo;
            dr[OrderPointStSimulationTbl.Col_WarehouseCode] = work.WarehouseCode;
            dr[OrderPointStSimulationTbl.Col_WarehouseName] = work.WarehouseName;
            dr[OrderPointStSimulationTbl.Col_SupplierCd] = goodsUnitData.SupplierCd;
            if (goodsUnitData.SupplierCd == 0)
            {
                dr[OrderPointStSimulationTbl.Col_SupplierName] = "���o�^";
            }
            else
            {
                dr[OrderPointStSimulationTbl.Col_SupplierName] = goodsUnitData.SupplierSnm;
            }
            dr[OrderPointStSimulationTbl.Col_GoodsMakerCd] = work.GoodsMakerCd;
            dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd] = work.GoodsMakerCd.ToString("d04");
            dr[OrderPointStSimulationTbl.Col_GoodsMakerName] = work.GoodsMakerNm;
            dr[OrderPointStSimulationTbl.Col_GoodsMGroup] = goodsUnitData.GoodsMGroup;
            dr[OrderPointStSimulationTbl.Col_BLGroupCode] = goodsUnitData.BLGroupCode;
            dr[OrderPointStSimulationTbl.Col_BLGoodsCode] = goodsUnitData.BLGoodsCode;
            dr[OrderPointStSimulationTbl.Col_StckShipMonthSt] = work.StckShipMonthSt;
            dr[OrderPointStSimulationTbl.Col_StckShipMonthEd] = work.StckShipMonthEd;
            dr[OrderPointStSimulationTbl.Col_OrderApplyDiv] = work.OrderApplyDiv;
            dr[OrderPointStSimulationTbl.Col_ShipScopeMore] = work.ShipScopeMore;
            dr[OrderPointStSimulationTbl.Col_ShipScopeLess] = work.ShipScopeLess;
            dr[OrderPointStSimulationTbl.Col_MinimumStockCnt] = work.MinimumStockCnt;
            dr[OrderPointStSimulationTbl.Col_MaximumStockCnt] = work.MaximumStockCnt;
            dr[OrderPointStSimulationTbl.Col_SalesOrderUnit] = work.SalesOrderUnit;
            dr[OrderPointStSimulationTbl.Col_OrderPProcUpdFlg] = work.OrderPProcUpdFlg;
            dr[OrderPointStSimulationTbl.Col_GoodsNo] = work.GoodsNo;
            dr[OrderPointStSimulationTbl.Col_GoodsName] = work.GoodsName;
            dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo] = work.WarehouseShelfNo;
            // �݌Ƀ}�X�^���̐ݒ�
            dr[OrderPointStSimulationTbl.Col_Stock_CreateDateTime] = stockWork.CreateDateTime;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdateDateTime] = stockWork.UpdateDateTime;
            dr[OrderPointStSimulationTbl.Col_Stock_EnterpriseCode] = stockWork.EnterpriseCode;
            dr[OrderPointStSimulationTbl.Col_Stock_FileHeaderGuid] = stockWork.FileHeaderGuid;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdEmployeeCode] = stockWork.UpdEmployeeCode;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdAssemblyId1] = stockWork.UpdAssemblyId1;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdAssemblyId2] = stockWork.UpdAssemblyId2;
            dr[OrderPointStSimulationTbl.Col_Stock_LogicalDeleteCode] = stockWork.LogicalDeleteCode;
            dr[OrderPointStSimulationTbl.Col_Stock_SectionCode] = stockWork.SectionCode;
            dr[OrderPointStSimulationTbl.Col_Stock_WarehouseCode] = stockWork.WarehouseCode;
            dr[OrderPointStSimulationTbl.Col_Stock_GoodsMakerCd] = stockWork.GoodsMakerCd;
            dr[OrderPointStSimulationTbl.Col_Stock_GoodsNo] = stockWork.GoodsNo;
            dr[OrderPointStSimulationTbl.Col_Stock_StockUnitPriceFl] = stockWork.StockUnitPriceFl;
            dr[OrderPointStSimulationTbl.Col_Stock_SupplierStock] = stockWork.SupplierStock;
            dr[OrderPointStSimulationTbl.Col_Stock_AcpOdrCount] = stockWork.AcpOdrCount;
            dr[OrderPointStSimulationTbl.Col_Stock_MonthOrderCount] = stockWork.MonthOrderCount;
            dr[OrderPointStSimulationTbl.Col_Stock_SalesOrderCount] = stockWork.SalesOrderCount;
            dr[OrderPointStSimulationTbl.Col_Stock_StockDiv] = stockWork.StockDiv;
            dr[OrderPointStSimulationTbl.Col_Stock_MovingSupliStock] = stockWork.MovingSupliStock;
            dr[OrderPointStSimulationTbl.Col_Stock_ShipmentPosCnt] = stockWork.ShipmentPosCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_StockTotalPrice] = stockWork.StockTotalPrice;
            dr[OrderPointStSimulationTbl.Col_Stock_LastStockDate] = stockWork.LastStockDate;
            dr[OrderPointStSimulationTbl.Col_Stock_LastSalesDate] = stockWork.LastSalesDate;
            dr[OrderPointStSimulationTbl.Col_Stock_LastInventoryUpdate] = stockWork.LastInventoryUpdate;
            dr[OrderPointStSimulationTbl.Col_Stock_MinimumStockCnt] = stockWork.MinimumStockCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_MaximumStockCnt] = stockWork.MaximumStockCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_NmlSalOdrCount] = stockWork.NmlSalOdrCount;
            dr[OrderPointStSimulationTbl.Col_Stock_SalesOrderUnit] = stockWork.SalesOrderUnit;
            dr[OrderPointStSimulationTbl.Col_Stock_StockSupplierCode] = stockWork.StockSupplierCode;
            dr[OrderPointStSimulationTbl.Col_Stock_GoodsNoNoneHyphen] = stockWork.GoodsNoNoneHyphen;
            dr[OrderPointStSimulationTbl.Col_Stock_WarehouseShelfNo] = stockWork.WarehouseShelfNo;
            dr[OrderPointStSimulationTbl.Col_Stock_DuplicationShelfNo1] = stockWork.DuplicationShelfNo1;
            dr[OrderPointStSimulationTbl.Col_Stock_DuplicationShelfNo2] = stockWork.DuplicationShelfNo2;
            dr[OrderPointStSimulationTbl.Col_Stock_PartsManagementDivide1] = stockWork.PartsManagementDivide1;
            dr[OrderPointStSimulationTbl.Col_Stock_PartsManagementDivide2] = stockWork.PartsManagementDivide2;
            dr[OrderPointStSimulationTbl.Col_Stock_StockNote1] = stockWork.StockNote1;
            dr[OrderPointStSimulationTbl.Col_Stock_StockNote2] = stockWork.StockNote2;
            dr[OrderPointStSimulationTbl.Col_Stock_ShipmentCnt] = stockWork.ShipmentCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_ArrivalCnt] = stockWork.ArrivalCnt;
            dr[OrderPointStSimulationTbl.Col_Stock_StockCreateDate] = stockWork.StockCreateDate;
            dr[OrderPointStSimulationTbl.Col_Stock_UpdateDate] = stockWork.UpdateDate;
            // �����P��
            double oldPrice = GetStockUnitPrice(goodsUnitData);
            dr[OrderPointStSimulationTbl.Col_OldPrice] = oldPrice;
            double nowStock = work.NowPrice;
            dr[OrderPointStSimulationTbl.Col_NowPrice] = work.NowPrice;
            double oldMinCnt = work.OldMinCnt;
            dr[OrderPointStSimulationTbl.Col_OldMinCnt] = work.OldMinCnt;
            double oldMaxCnt = work.OldMaxCnt;
            dr[OrderPointStSimulationTbl.Col_OldMaxCnt] = work.OldMaxCnt;
            double newMinCnt = work.NewMinCnt;
            dr[OrderPointStSimulationTbl.Col_NewMinCnt] = work.NewMinCnt;
            double newMaxCnt = work.NewMaxCnt;
            dr[OrderPointStSimulationTbl.Col_NewMaxCnt] = work.NewMaxCnt;

            double nowStockPrice = oldPrice * nowStock;
            double oldMinPrice = oldPrice * oldMinCnt;
            double oldMaxPrice = oldPrice * oldMaxCnt;
            double newMinPrice = oldPrice * newMinCnt;
            double newMaxPrice = oldPrice * newMaxCnt;
            switch (this._stockMngTtlSt.FractionProcCd)
            {
                case 1: // �؎̂�
                    nowStockPrice = CalculateConsTax.Floor(nowStockPrice);
                    oldMinPrice = CalculateConsTax.Floor(oldMinPrice);
                    oldMaxPrice = CalculateConsTax.Floor(oldMaxPrice);
                    newMinPrice = CalculateConsTax.Floor(newMinPrice);
                    newMaxPrice = CalculateConsTax.Floor(newMaxPrice);
                    break;
                case 2: // �l�̌ܓ�
                    nowStockPrice = CalculateConsTax.Round(nowStockPrice);
                    oldMinPrice = CalculateConsTax.Round(oldMinPrice);
                    oldMaxPrice = CalculateConsTax.Round(oldMaxPrice);
                    newMinPrice = CalculateConsTax.Round(newMinPrice);
                    newMaxPrice = CalculateConsTax.Round(newMaxPrice);
                    break;
                case 3: // �؏グ
                    nowStockPrice = CalculateConsTax.Ceiling(nowStockPrice);
                    oldMinPrice = CalculateConsTax.Ceiling(oldMinPrice);
                    oldMaxPrice = CalculateConsTax.Ceiling(oldMaxPrice);
                    newMinPrice = CalculateConsTax.Ceiling(newMinPrice);
                    newMaxPrice = CalculateConsTax.Ceiling(newMaxPrice);
                    break;
            }
            dr[OrderPointStSimulationTbl.Col_NowStockPrice] = nowStockPrice;
            dr[OrderPointStSimulationTbl.Col_OldMinPrice] = oldMinPrice;
            dr[OrderPointStSimulationTbl.Col_OldMaxPrice] = oldMaxPrice;
            dr[OrderPointStSimulationTbl.Col_NewMinPrice] = newMinPrice;
            dr[OrderPointStSimulationTbl.Col_NewMaxPrice] = newMaxPrice;
            #endregion

            // Table��Add
            orderPointStDt.Rows.Add(dr);
        }

        /// <summary>
        /// �f�[�^�̃t�B���^����
        /// </summary>
        /// <param name="outPutDiv">�o�͋敪</param>
        /// <param name="fractionProcCd">�[���敪</param>
        /// <param name="dr">�Y���s</param>
        /// <param name="lastDr">�O��s</param>
        /// <param name="isSame">�������ǂ���</param>
        /// <param name="lastWarehouseCode">�O��q�ɃR�[�h</param>
        /// <param name="lastSupplierCd">�O��d����R�[�h</param>
        /// <param name="lastGoodsMakerCd">�O�񃁁[�J�[�R�[�h</param>
        /// <param name="lastWarehouseShelfNo">�O��I��</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�̃t�B���^�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.04</br>
        /// </remarks>
        public void DataFilter(Int32 outPutDiv, Int32 fractionProcCd, ref DataRow dr, ref DataRow lastDr, out bool isSame, ref string lastWarehouseCode, ref string lastSupplierCd, ref string lastWarehouseShelfNo, ref string lastGoodsMakerCd)
        {
            isSame = false;
            if (dr[OrderPointStSimulationTbl.Col_WarehouseCode].Equals(lastDr[OrderPointStSimulationTbl.Col_WarehouseCode]) &&
                dr[OrderPointStSimulationTbl.Col_SupplierCd].Equals(lastDr[OrderPointStSimulationTbl.Col_SupplierCd]) &&
                dr[OrderPointStSimulationTbl.Col_GoodsMakerCd].Equals(lastDr[OrderPointStSimulationTbl.Col_GoodsMakerCd]) &&
                dr[OrderPointStSimulationTbl.Col_GoodsMGroup].Equals(lastDr[OrderPointStSimulationTbl.Col_GoodsMGroup]) &&
                dr[OrderPointStSimulationTbl.Col_BLGroupCode].Equals(lastDr[OrderPointStSimulationTbl.Col_BLGroupCode]) &&
                dr[OrderPointStSimulationTbl.Col_BLGoodsCode].Equals(lastDr[OrderPointStSimulationTbl.Col_BLGoodsCode]) &&
                dr[OrderPointStSimulationTbl.Col_GoodsNo].Equals(lastDr[OrderPointStSimulationTbl.Col_GoodsNo]))
            {
                isSame = true;
            }

            string nowWarehouseCode = dr[OrderPointStSimulationTbl.Col_WarehouseCode].ToString().TrimEnd();
            switch (outPutDiv)
            {
                case 0:
                    // �i�ԏ�
                    if (nowWarehouseCode.Equals(lastWarehouseCode) && 
                        dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString().Equals(lastSupplierCd) &&
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                    {
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd] = string.Empty;
                    }
                    else
                    {
                        if (!nowWarehouseCode.Equals(lastWarehouseCode))
                        {
                            lastWarehouseCode = nowWarehouseCode;
                            lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString().Equals(lastSupplierCd))
                        {
                            lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                        {
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                    }
                    break;
                case 1:
                    // �I�ԏ�
                    if (nowWarehouseCode.Equals(lastWarehouseCode) &&
                        dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].Equals(lastWarehouseShelfNo))
                    {
                        dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo] = string.Empty;
                    }
                    else
                    {
                        if (!nowWarehouseCode.Equals(lastWarehouseCode))
                        {
                            lastWarehouseCode = nowWarehouseCode;
                            lastWarehouseShelfNo = dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].Equals(lastWarehouseShelfNo))
                        {
                            lastWarehouseShelfNo = dr[OrderPointStSimulationTbl.Col_WarehouseShelfNo].ToString();
                        }
                    }
                    break;
                case 2:
                    // ���[�J�[�E�i�ԏ�
                    if (nowWarehouseCode.Equals(lastWarehouseCode) && 
                        dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString().Equals(lastSupplierCd) &&
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                    {
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd] = string.Empty;
                    }
                    else
                    {
                        if (!nowWarehouseCode.Equals(lastWarehouseCode))
                        {
                            lastWarehouseCode = nowWarehouseCode;
                            lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString().Equals(lastSupplierCd))
                        {
                            lastSupplierCd = dr[OrderPointStSimulationTbl.Col_SupplierCd].ToString();
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                        {
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                    }
                    break;
                case 3:
                    // ���[�J�[�E�I�ԏ�
                    if (nowWarehouseCode.Equals(lastWarehouseCode) &&
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                    {
                        dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd] = string.Empty;
                    }
                    else
                    {
                        if (!nowWarehouseCode.Equals(lastWarehouseCode))
                        {
                            lastWarehouseCode = nowWarehouseCode;
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                        if (!dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString().Equals(lastGoodsMakerCd))
                        {
                            lastGoodsMakerCd = dr[OrderPointStSimulationTbl.Col_Detail_GoodsMakerCd].ToString();
                        }
                    }
                    break;
            }
        }

        #region ���i�A�N�Z�X�N���X(���������������S��v)
        /// <summary>
        /// ���i�A�N�Z�X�N���X(���������������S��v)
        /// </summary>
        /// <param name="goodsCndtnList">���i���o�����N���X���X�g</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ���������������S��v�ŏ��i��񃊃X�g���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.04</br>
        /// </remarks>
        private int GoodsRead(List<GoodsCndtn> goodsCndtnList)
        {
            int status = -1;
            string msg;
            List<List<GoodsUnitData>> goodsUnitDataListList = new List<List<GoodsUnitData>>();

            // ���i�A���f�[�^���[�J���L���b�V�����N���A
            _goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();

            // ���������������S��v�ŏ��i�����擾
            // ���i�}�X�^�̌���
            foreach (GoodsCndtn goodsCndtn in goodsCndtnList)
            {
                List<GoodsUnitData> outGoodsUnitDataListList;
                status = this._goodsAcs.Search(goodsCndtn, out outGoodsUnitDataListList, out msg);
                if (outGoodsUnitDataListList != null && outGoodsUnitDataListList.Count > 0)
                {
                    goodsUnitDataListList.Add(outGoodsUnitDataListList);
                }
            }
            if ((goodsUnitDataListList != null) && (goodsUnitDataListList.Count != 0))
            {
                for (int i = 0; i < goodsUnitDataListList.Count; i++)
                {
                    List<GoodsUnitData> goodsUnitDataList = goodsUnitDataListList[i];

                    for (int j = 0; j < goodsUnitDataList.Count; j++)
                    {
                        GoodsUnitData goodsUnitData = goodsUnitDataList[j];
                        string key = goodsUnitData.GoodsMakerCd.ToString("d04") + ct_septation + goodsUnitData.GoodsNo;
                        if (_goodsUnitDataDic.ContainsKey(key))
                        {
                            // ���ꏤ�i�����݂��Ă���ꍇ�͍폜
                            _goodsUnitDataDic.Remove(key);
                        }
                        _goodsUnitDataDic.Add(key, goodsUnitData);

                        key = goodsUnitData.GoodsNo;
                        if (_goodsUnitDataDic.ContainsKey(key))
                        {
                            // ���ꏤ�i�����݂��Ă���ꍇ�͍폜
                            _goodsUnitDataDic.Remove(key);
                        }
                        _goodsUnitDataDic.Add(key, goodsUnitData);
                    }
                }
            }

            return status;
        }
        #endregion

        /// <summary>
        /// �ŗ��ݒ�}�X�^�擾����
        /// </summary>
        /// <remarks>
        /// Note       : �ŗ��ݒ�}�X�^���擾���܂��B<br />
        /// Programer  : ���w�q<br />
        /// Date       : 2009.05.04<br/>
        /// </remarks>
        private void ReadTaxRate()
        {
            int status;

            try
            {
                // �ŗ��ݒ�}�X�^�擾(�ŗ��R�[�h=0�Œ�)
                status = this._taxRateSetAcs.Read(out this._taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            }
            catch
            {
                this._taxRateSet = new TaxRateSet();
            }
        }

        /// <summary>
        /// �݌ɊǗ��S�̐ݒ�}�X�^�擾����
        /// </summary>
        /// <remarks>
        /// Note       : �݌ɊǗ��S�̐ݒ�}�X�^���擾���܂��B<br />
        /// Programer  : ���w�q<br />
        /// Date       : 2009.05.04<br/>
        /// </remarks>
        private void ReadStockMngTtlSt()
        {
            int status;

            ArrayList stockMngTtlStList;
            try
            {
                // �݌ɊǗ��S�̐ݒ�}�X�^�擾
                status = this._stockMngTtlStAcs.Search(out stockMngTtlStList, LoginInfoAcquisition.EnterpriseCode);
                if (stockMngTtlStList != null && stockMngTtlStList.Count > 0)
                {
                    foreach (StockMngTtlSt work in stockMngTtlStList)
                    {
                        if (work.SectionCode.Trim() == "00")
                        {
                            this._stockMngTtlSt = work;
                            break;
                        }
                    }
                }
            }
            catch
            {
                this._stockMngTtlStAcs = new StockMngTtlStAcs();
            }
        }

        /// <summary>
        /// ���P���擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>���P��</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�A���i�A���f�[�^��茴�P�����擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.04</br>
        /// </remarks>
        private Double GetStockUnitPrice(GoodsUnitData goodsUnitData)
        {
            Double stockUnitPrice = 0;

            // ���i�A���f�[�^����P���Z�o���ʃI�u�W�F�N�g���擾
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData);

            // �P���Z�o���ʃI�u�W�F�N�g��茴�P���擾
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// �P���Z�o���ʃI�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�P���Z�o���ʃI�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^���P���Z�o���ʃI�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.04</br>
        /// <br>Note       : Redmine#45978��#93��#94 �d����擾�A���P���Z�o�̏�Q�Ή��B</br>
        /// <br>Programmer : ����g</br>
        /// <br>Date       : 2015/08/13</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // �P���Z�o�p�����[�^�ݒ�
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            //unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // ���_�R�[�h  // DEL ����g 2015/08/13 �ǉ���Q
            unitPriceCalcParam.SectionCode = goodsUnitData.SectionCode;    // ADD ����g 2015/08/13 �d����擾�A���P���Z�o�̏�Q�Ή�
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // ���i���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // ���i�ԍ�
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // ���i�|�������N
            //unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // ���i�|���O���[�v�R�[�h  // DEL ����g 2015/08/13 �ǉ���Q
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;    // ADD ����g 2015/08/13 �d����擾�A���P���Z�o�̏�Q�Ή�
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL���i�R�[�h
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // �d����R�[�h
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                         // ���i�K�p��
            unitPriceCalcParam.CountFl = 1;                                                             // ����
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // �ېŋ敪
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Today);    // �ŗ�
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // �d������Œ[�������R�[�h
            unitPriceCalcParam.TotalAmountDispWayCd = 0;                                                // ���z�\�����@�敪
            unitPriceCalcParam.TtlAmntDspRateDivCd = 1;                                                 // ���z�\���|���K�p�敪
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // �d���P���[�������R�[�h
            unitPriceCalcParam.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;                    // ����œ]�ŕ���

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// ----ADD ����g 2015/08/26 FOR Redmine45978 ���Аݒ�̊|���D�揇�ʋ敪���Q�Ƃ��Ă��Ȃ���Q�Ή� ---->>>>
        /// <summary>
        /// �|���D��敪���Z�b�g���܂��B
        /// </summary>
        /// <remarks>�|���D��敪���Z�b�g���܂��B</remarks>
        private void SetUnitPriceCalculation()
        {
            CompanyInf companyInf = null;                 // ���Џ��
            this._companyInfAcs.Read(out companyInf, LoginInfoAcquisition.EnterpriseCode);

            if (companyInf != null)
            {
                this._unitPriceCalculation.RatePriorityDiv = companyInf.RatePriorityDiv;
            }
        }
        // ----ADD ����g 2015/08/26 FOR Redmine45978 ���Аݒ�̊|���D�揇�ʋ敪���Q�Ƃ��Ă��Ȃ���Q�Ή� ----<<<<

        #endregion �� �f�[�^�W�J����

        #region �� ���[�ݒ�f�[�^�擾

        #region �� ���[�o�͐ݒ�擾����
        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="retPrtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = string.Empty;

            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (stc_PrtOutSet != null)
                {
                    retPrtOutSet = stc_PrtOutSet.Clone();
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            retPrtOutSet = stc_PrtOutSet.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂���";
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                retPrtOutSet = new PrtOutSet();
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
        #endregion �� ���[�ݒ�f�[�^�擾

        #region �� �݌Ƀ}�X�^�X�V����
        /// <summary>
        /// �݌Ƀ}�X�^�X�V����
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <param name="orderPointStList">�����_�ݒ�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note		: �݌Ƀ}�X�^�X�V�������s���܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009.04.13</br>
        /// </remarks>
        public int StockUpdate(DataSet ds, List<OrderPointSt> orderPointStList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            ArrayList stockWorkAl = new ArrayList();
            ArrayList orderPointStWorkList = new ArrayList();
            object objStockWorkAl;
            object objOrderPointStWorkAl;
            // �݌ɊǗ��S�̐ݒ�}�X�^�̎擾
            this.ReadStockMngTtlSt();

            try
            {
                foreach (DataRow dr in ds.Tables[OrderPointStSimulationTbl.Col_Tbl_Result_OrderPointStSimulation].Rows)
                {
                    StockWork stockWork = new StockWork();
                    stockWork.CreateDateTime = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_CreateDateTime]);
                    stockWork.UpdateDateTime = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_UpdateDateTime]);
                    stockWork.EnterpriseCode = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_EnterpriseCode]);
                    stockWork.FileHeaderGuid = (Guid)dr[OrderPointStSimulationTbl.Col_Stock_FileHeaderGuid];
                    stockWork.UpdEmployeeCode = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_UpdEmployeeCode]);
                    stockWork.UpdAssemblyId1 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_UpdAssemblyId1]);
                    stockWork.UpdAssemblyId2 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_UpdAssemblyId2]);
                    stockWork.LogicalDeleteCode = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_LogicalDeleteCode]);
                    stockWork.SectionCode = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_SectionCode]);
                    stockWork.WarehouseCode = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_WarehouseCode]);
                    stockWork.GoodsMakerCd = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_GoodsMakerCd]);
                    stockWork.GoodsNo = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_GoodsNo]);
                    stockWork.StockUnitPriceFl = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_StockUnitPriceFl]);
                    stockWork.SupplierStock = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_SupplierStock]);
                    stockWork.AcpOdrCount = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_AcpOdrCount]);
                    stockWork.MonthOrderCount = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_MonthOrderCount]);
                    stockWork.SalesOrderCount = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_SalesOrderCount]);
                    stockWork.StockDiv = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_StockDiv]);
                    stockWork.MovingSupliStock = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_MovingSupliStock]);
                    stockWork.ShipmentPosCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_ShipmentPosCnt]);
                    stockWork.StockTotalPrice = Convert.ToInt64(dr[OrderPointStSimulationTbl.Col_Stock_StockTotalPrice]);
                    stockWork.LastStockDate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_LastStockDate]);
                    stockWork.LastSalesDate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_LastSalesDate]);
                    stockWork.LastInventoryUpdate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_LastInventoryUpdate]);
                    stockWork.MinimumStockCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_MinimumStockCnt]);
                    stockWork.MaximumStockCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_MaximumStockCnt]);
                    stockWork.NmlSalOdrCount = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_NmlSalOdrCount]);
                    if (this._stockMngTtlSt.LotUseDivCd == 0)
                    {
                        // �����}�X�^�̔����P��
                        stockWork.SalesOrderUnit = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_SalesOrderUnit]);
                    }
                    else
                    {
                        // �݌Ƀ}�X�^�̔����P��
                        stockWork.SalesOrderUnit = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_SalesOrderUnit]);
                    }
                    stockWork.StockSupplierCode = Convert.ToInt32(dr[OrderPointStSimulationTbl.Col_Stock_StockSupplierCode]);
                    stockWork.GoodsNoNoneHyphen = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_GoodsNoNoneHyphen]);
                    stockWork.WarehouseShelfNo = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_WarehouseShelfNo]);
                    stockWork.DuplicationShelfNo1 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_DuplicationShelfNo1]);
                    stockWork.DuplicationShelfNo2 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_DuplicationShelfNo2]);
                    stockWork.PartsManagementDivide1 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_PartsManagementDivide1]);
                    stockWork.PartsManagementDivide2 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_PartsManagementDivide2]);
                    stockWork.StockNote1 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_StockNote1]);
                    stockWork.StockNote2 = Convert.ToString(dr[OrderPointStSimulationTbl.Col_Stock_StockNote2]);
                    stockWork.ShipmentCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_ShipmentCnt]);
                    stockWork.ArrivalCnt = Convert.ToDouble(dr[OrderPointStSimulationTbl.Col_Stock_ArrivalCnt]);
                    stockWork.StockCreateDate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_StockCreateDate]);
                    stockWork.UpdateDate = Convert.ToDateTime(dr[OrderPointStSimulationTbl.Col_Stock_UpdateDate]);
                    stockWorkAl.Add(stockWork);
                }
                
                foreach (OrderPointSt orderPointSt in orderPointStList)
                {
                    OrderPointStWork orderPointStWork = new OrderPointStWork();
                    orderPointStWork.CreateDateTime = orderPointSt.CreateDateTime;
                    orderPointStWork.UpdateDateTime = orderPointSt.UpdateDateTime;
                    orderPointStWork.EnterpriseCode = orderPointSt.EnterpriseCode;
                    orderPointStWork.FileHeaderGuid = orderPointSt.FileHeaderGuid;
                    orderPointStWork.UpdEmployeeCode = orderPointSt.UpdEmployeeCode;
                    orderPointStWork.UpdAssemblyId1 = orderPointSt.UpdAssemblyId1;
                    orderPointStWork.UpdAssemblyId2 = orderPointSt.UpdAssemblyId2;
                    orderPointStWork.LogicalDeleteCode = orderPointSt.LogicalDeleteCode;
                    orderPointStWork.PatterNo = orderPointSt.PatterNo;
                    orderPointStWork.PatternNoDerivedNo = orderPointSt.PatternNoDerivedNo;
                    orderPointStWork.WarehouseCode = orderPointSt.WarehouseCode;
                    orderPointStWork.SupplierCd = orderPointSt.SupplierCd;
                    orderPointStWork.GoodsMakerCd = orderPointSt.GoodsMakerCd;
                    orderPointStWork.GoodsMGroup = orderPointSt.GoodsMGroup;
                    orderPointStWork.BLGroupCode = orderPointSt.BLGroupCode;
                    orderPointStWork.BLGoodsCode = orderPointSt.BLGoodsCode;
                    orderPointStWork.StckShipMonthSt = orderPointSt.StckShipMonthSt;
                    orderPointStWork.StckShipMonthEd = orderPointSt.StckShipMonthEd;
                    orderPointStWork.OrderApplyDiv = orderPointSt.OrderApplyDiv;
                    orderPointStWork.StockCreateDate = orderPointSt.StockCreateDate;
                    orderPointStWork.ShipScopeMore = orderPointSt.ShipScopeMore;
                    orderPointStWork.ShipScopeLess = orderPointSt.ShipScopeLess;
                    orderPointStWork.MinimumStockCnt = orderPointSt.MinimumStockCnt;
                    orderPointStWork.MaximumStockCnt = orderPointSt.MaximumStockCnt;
                    orderPointStWork.SalesOrderUnit = orderPointSt.SalesOrderUnit;
                    orderPointStWork.OrderPProcUpdFlg = 1;
                    orderPointStWorkList.Add(orderPointStWork);
                }
                objStockWorkAl = stockWorkAl;
                objOrderPointStWorkAl = orderPointStWorkList;
                status = this._iOrderPointStSimulationDB.Write(ref objStockWorkAl, ref objOrderPointStWorkAl, out errMsg);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� �݌Ƀ}�X�^�X�V����
        #endregion �� Private Method
    }
}
