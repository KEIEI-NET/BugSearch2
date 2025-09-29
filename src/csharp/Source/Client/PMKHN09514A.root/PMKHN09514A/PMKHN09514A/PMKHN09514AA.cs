//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n���o��
// �v���O�����T�v   : �s�a�n���o��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00  �쐬�S�� : ������
// �� �� �� : 2016/05/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00  �쐬�S�� : ���V��
// �� �� �� : 2016/07/04   �C�����e : Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗�
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

//--- ADD 2016/07/05 ���X�؁i�M�j --->>>
using Microsoft.Win32;
using System.IO;
//--- ADD 2016/07/05 ���X�؁i�M�j ---<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �s�a�n���o�� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �s�a�n���o�͂Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer  : ������</br>
    /// <br>Date        : 2016/05/20</br>
    /// <br>Programmer  : ���V��</br>
    /// <br>Date        : 2016/07/04</br>
    /// <br>Note        : </br>
    /// <br>Update Note : 2016/07/04 ���V��</br>
    /// <br>�Ǘ��ԍ�    : 11270029-00 </br>
    /// <br>              Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗�</br>
    /// <br>Update Note : 2016/07/05 30757���X�؁i�M�j</br>
    /// <br>�Ǘ��ԍ�    : 11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗����ؗp</br>
    /// <br>              ���O�N���X�̒ǉ�</br>
    /// </remarks>
    public class TBODataExportAcs
    {
        #region �� Constructor
        /// <summary>
        /// �s�a�n���o�̓A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �s�a�n���o�̓A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        public TBODataExportAcs()
        {
            this._iTBODataExportDB = (ITBODataExportDB)MediationTBODataExportDB.GetTBODataExportDB();
            this.goodsMGroupDic = new Dictionary<string, List<string>>();
            logFile = new LogFile( true ); //ADD 2016/07/05 ���X�؁i�M�j11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗�
        }
        #endregion �� Constructor

        #region �� Private Member
        private ITBODataExportDB _iTBODataExportDB;
        private Dictionary<string, List<string>> goodsMGroupDic = null;

        // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---->>>>>
        /// <summary>
        /// ����S�̐ݒ�}�X�^���X�g�L���b�V���̈�
        /// </summary>
        private List<SalesTtlSt> salesTtlStList;

        /// <summary>
        /// ����S�̐ݒ�}�X�^���L���b�V���̈�
        /// </summary>
        private SalesTtlSt salesTtlStCache;
        // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ----<<<<<

        //--- ADD 2016/07/05 ���X�؁i�M�j11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� --->>>
        /// <summary>���O�L�^�Ǘ��N���X</summary>
        private LogFile logFile = null;
        //--- ADD 2016/07/05 ���X�؁i�M�j11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---<<<
        #endregion �� Private Member

        #region �� Constant
        private const string FILE_NAME_TBOGOODSMCODELIST = "PMKHN09510U_TBOGoodsMCodeList.XML";
        private const string CATEGORY_TIRE = "1";
        private const string CATEGORY_BATTERY = "2";
        private const string CATEGORY_OIL = "3";

        // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---->>>>>
        /// <summary>
        /// ���i���o����->���i����
        /// </summary>
        /// <remarks>
        /// GoodsAcs.Search()���g�p����ꍇ�AGoodsKindCode�p�����[�^��9���Z�b�g���Ȃ��Ə����i�ȊO��
        /// ���i�����擾�ł��Ȃ��B
        /// </remarks>
        private const int GoodsSearchCondGoodsKindCode = 9;

        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
#if DEBUG
        private const bool LocalDBReadFlag = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        private const bool LocalDBReadFlag = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif

        /// <summary>���_�R�[�h(�S��)</summary>
        private const string DefaultSectionCode = "00";
        /// <summary>�������ݒ莞�敪:�[���\��</summary>
        private const int UnPrcNonSettingDivZero = 0;
        /// <summary>�������ݒ莞�敪:�艿�\��</summary>
        private const int UnPrcNonSettingDivSuggestPrice = 1;
        
        // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ----<<<<<
        #endregion

        #region �� Public Method
        /// <summary>
        /// �f�[�^���o����
        /// </summary>
        /// <param name="condition">���o����</param>
        /// <param name="proposeGoodsList">TBO��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : �e�L�X�g�o�̓f�[�^���擾����B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        public int SearchTBODataExportMain(TBODataExportCond condition, out List<Propose_Goods> proposeGoodsList, out string errMessage)
        {
            proposeGoodsList = new List<Propose_Goods>();

            // �f�[�^����
            ArrayList retTBODataList = null;
            int status = SearchTBODataExportProc(condition, out retTBODataList, out errMessage);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �f�[�^�ϊ�
                status = ConvertTBOData(condition, retTBODataList, out proposeGoodsList, out errMessage);
            }

            return status;
        }
        #endregion �� Public Method

        #region �� Private Method
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="condition">���o����</param>
        /// <param name="retTBODataList">�f�[�^��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : TBO�f�[�^���擾����B</br>
        /// <br>Programmer  : ������</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private int SearchTBODataExportProc(TBODataExportCond condition, out ArrayList retTBODataList, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retTBODataList = null; // TBO��������
            errMessage = String.Empty;

            // ���i�J�e�S���ϊ�XML�t�@�C���̓ǂݍ���
            DeserializeXMLFile();

            // ���i�J�e�S�����̒����ނ��Z�b�g
            condition.GoodsMGroup = new ArrayList();
            condition.GoodsMGroup.AddRange(this.goodsMGroupDic[condition.CategoryID.ToString()]);

            //-----------------------------------------------------------------------------
            // �f�[�^����
            //-----------------------------------------------------------------------------
            try
            {
                object result = null;
                status = this._iTBODataExportDB.SearchTBOData(out result, (object)condition, out errMessage);

                // ����̏ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retTBODataList = (ArrayList)result;
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�ϊ��̏���
        /// </summary>
        /// <param name="condition">���o����</param>
        /// <param name="resultTBODataList">�f�[�^��������</param>
        /// <param name="proposeGoodsList">�ϊ�����</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ϊ��̏������s���B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// <br>Update Note: 2016/07/04 ���V��</br>
        /// <br>�Ǘ��ԍ�   : 11270029-00 </br>
        /// <br>             Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗�</br>
        /// </remarks>
        private int ConvertTBOData(TBODataExportCond condition, ArrayList resultTBODataList, out List<Propose_Goods> proposeGoodsList, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            proposeGoodsList = new List<Propose_Goods>();
            errMessage = String.Empty;

            // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---->>>>>
            // ���i�A�N�Z�X
            GoodsAcs goodsAcs = new GoodsAcs();
            // �d����A�N�Z�X
            SupplierAcs supplierAcs = new SupplierAcs();

            DateTime priceStartDateDT = new DateTime();  // �K�p��
            if (condition.PriceStartDate.ToString().Length == 8)
            {
                int year = Int32.Parse(condition.PriceStartDate.ToString().Substring(0, 4));
                int month = Int32.Parse(condition.PriceStartDate.ToString().Substring(4, 2));
                int day = Int32.Parse(condition.PriceStartDate.ToString().Substring(6, 2));
                priceStartDateDT = new DateTime(year, month, day);
            }
            // �ŗ����
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSet taxRateSet = new TaxRateSet();
            taxRateSetAcs.Read(out taxRateSet, condition.EnterpriseCode, 0);

            //���i��������
            GoodsCndtn cndtn = new GoodsCndtn();
            // ���i�A�����
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            // �P���Z�o�N���X
            UnitPriceCalculation upc = new UnitPriceCalculation();
            // �P���v�Z�p�����[�^�I�u�W�F�N�g
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ----<<<<<
            try
            {
                // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---->>>>>

                //  ����S�̐ݒ�}�X�^����A�������ݒ莞�敪���擾
                SalesTtlSt salesTtlSt = null;
                this.GetSalesTtlSt( 
                      out salesTtlSt
                    , condition.EnterpriseCode
                    , condition.SectionCodeRF.Trim() );
                int unPrcNonSettingDiv = salesTtlSt != null ? salesTtlSt.UnPrcNonSettingDiv : 0;

                //���Ӑ�����e�p�����[�^���擾����
                List<CustRateGroup> custRateGroupList = null;�@//���Ӑ�|���O���[�v
                int salesCnsTaxFrcProcCd = 0;                  //�������Œ[�������R�[�h
                int salesUnPrcFrcProcCd = 0;                   // ����P���[�������R�[�h
                if (  condition.CustomerCode > 0 )
                {
                    //���Ӑ�|���O���[�v�̎擾
                    this.GetCustRateGroupList( out custRateGroupList, condition.EnterpriseCode, condition.CustomerCode );

                    // ���Ӑ�}�X�^�A�N�Z�T
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                    // �������Œ[�������R�[�h�̎擾
                    salesCnsTaxFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
                          condition.EnterpriseCode
                        , condition.CustomerCode
                        , CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd );
                    // ����P���[�������R�[�h�̎擾
                    salesUnPrcFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
                          condition.EnterpriseCode
                        , condition.CustomerCode
                        , CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd );
                }
                
                // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ----<<<<<

                foreach (TBODataExportResultWork result in resultTBODataList)
                {
                    // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---->>>>>
                    bool salesUnitPriceFlg = false;//�����Z�o�ς݃t���O
                    
                    cndtn.EnterpriseCode = condition.EnterpriseCode;
                    cndtn.SectionCode = condition.SectionCodeRF.Trim();
                    cndtn.GoodsMakerCd = result.GoodsMakerCdRF;
                    cndtn.GoodsNo = result.GoodsNoRF;
                    cndtn.GoodsKindCode = TBODataExportAcs.GoodsSearchCondGoodsKindCode;
                    //���i�A�����擾
                    status = goodsAcs.Search(cndtn, out goodsUnitDataList, out errMessage);
                    List<UnitPriceCalcRet> unitPriceCalcRetList = null;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsUnitDataList != null && goodsUnitDataList.Count > 0)
                    {
                        unitPriceCalcParam.BLGoodsCode = goodsUnitDataList[0].BLGoodsCode;  //BL�R�[�h
                        unitPriceCalcParam.BLGroupCode = goodsUnitDataList[0].BLGroupCode;  //BL�O���[�v�R�[�h
                        unitPriceCalcParam.CountFl = 1;  //����
                        unitPriceCalcParam.CustomerCode = condition.CustomerCode; //���Ӑ�R�[�h
                        unitPriceCalcParam.CustRateGrpCode =
                            this.GetCustRateGroupCode( goodsUnitDataList[0].GoodsMakerCd, custRateGroupList ); // ���Ӑ�|���O���[�v�R�[�h
                        unitPriceCalcParam.GoodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
                        unitPriceCalcParam.GoodsNo = goodsUnitDataList[0].GoodsNo;            // �i��
                        unitPriceCalcParam.GoodsRateGrpCode = goodsUnitDataList[0].GoodsRateGrpCode;   // ���i�|���O���[�v�R�[�h
                        unitPriceCalcParam.GoodsRateRank = goodsUnitDataList[0].GoodsRateRank;      // ���i�|�������N
                        unitPriceCalcParam.PriceApplyDate = priceStartDateDT;  // �K�p��
                        unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd; // �������Œ[�������R�[�h
                        unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd; // ����P���[�������R�[�h

                        unitPriceCalcParam.SectionCode = goodsUnitDataList[0].SectionCode;  // ���_�R�[�h

                        // �d������Œ[�������R�[�h
                        unitPriceCalcParam.StockCnsTaxFrcProcCd = supplierAcs.GetStockFractionProcCd(
                            goodsUnitDataList[0].EnterpriseCode,
                            goodsUnitDataList[0].SupplierCd,
                            SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd );
                        // �d���P���[�������R�[�h
                        unitPriceCalcParam.StockUnPrcFrcProcCd = supplierAcs.GetStockFractionProcCd(
                            goodsUnitDataList[0].EnterpriseCode,
                            goodsUnitDataList[0].SupplierCd,
                            SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd );

                        unitPriceCalcParam.SupplierCd = goodsUnitDataList[0].SupplierCd;     // �d����R�[�h
                        unitPriceCalcParam.TaxationDivCd = goodsUnitDataList[0].TaxationDivCd;  // �ېŋ敪
                        unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate( taxRateSet, priceStartDateDT );  // ����Őŗ��c�ŗ��ݒ�}�X�^
                        unitPriceCalcParam.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;  // ����œ]�ŕ���
                        unitPriceCalcParam.TotalAmountDispWayCd = 0;  // ���z�\�����@�敪
                        unitPriceCalcParam.TtlAmntDspRateDivCd = 0;  // ���z�\���|���K�p�敪

                        unitPriceCalcRetList = new List<UnitPriceCalcRet>();
                        upc.CalculateSalesRelevanceUnitPriceRateCache( unitPriceCalcParam, goodsUnitDataList[0], out unitPriceCalcRetList );
                    }
                    else if ( status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                    {
                        this.logFile.Write( string.Format(
                              "���i���̎擾�ŃG���[���������܂��� (���[�J�[�R�[�h�F{0}�A�i�ԁF{1}�A�G���[�R�[�h�F{2})"
                            , cndtn.GoodsMakerCd
                            , cndtn.GoodsNo
                            , status ) );
                    }
                    // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ----<<<<<

                    Propose_Goods proposeGoods = new Propose_Goods();

                    // ���_�R�[�h
                    proposeGoods.SectionCode = condition.SectionCodeRF.Trim();
                    // ���i�J�e�S��
                    proposeGoods.GoodsCategory = Convert.ToInt64(condition.CategoryID);
                    // ���i�ԍ�
                    proposeGoods.GoodsNo = result.GoodsNoRF;
                    // ���i����
                    proposeGoods.GoodsName = result.GoodsNameRF;
                    // ���i���[�J�[�R�[�h
                    proposeGoods.GoodsMakerCd = result.GoodsMakerCdRF;
                    // ���[�J�[����
                    proposeGoods.MakerName = result.MakerNameRF;
                    // �݌ɏ󋵋敪
                    if (result.ShipmentPosCntRF <= 0)
                    {
                        proposeGoods.StockStatusDiv = 0;
                    }
                    else if (result.ShipmentPosCntRF < result.MinimumStockCntRF)
                    {
                        proposeGoods.StockStatusDiv = 2;
                    }
                    else
                    {
                        proposeGoods.StockStatusDiv = 3;
                    }
                    // DEL by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---->>>>>
                    // ��]�������i
                    //proposeGoods.SuggestPrice = result.SuggestPriceRF;
                    // �d������
                    //proposeGoods.PurchaseCost = result.PurchaseCostRF;
                    // DEL by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ----<<<<<
                    // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---->>>>>
                    if (unitPriceCalcRetList != null && unitPriceCalcRetList.Count > 0)
                    {
                        foreach (UnitPriceCalcRet priceRet in unitPriceCalcRetList)
                        {
                            int unitPriceKind = 0;
                            try
                            {
                                unitPriceKind = string.IsNullOrEmpty( priceRet.UnitPriceKind ) ? 0 : Convert.ToInt32( priceRet.UnitPriceKind );
                            }
                            catch
                            {
                            }
                            switch (unitPriceKind)
                            {
                                case (int)Broadleaf.Application.Common.UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                                    // ����P�������l�ɃZ�b�g
                                    proposeGoods.TradePrice = priceRet.UnitPriceTaxExcFl;
                                    salesUnitPriceFlg = true;
                                    break;
                                case (int)Broadleaf.Application.Common.UnitPriceCalculation.UnitPriceKind.UnitCost:
                                    //�����P�����d�������ɃZ�b�g
                                    proposeGoods.PurchaseCost = priceRet.UnitPriceTaxExcFl;
                                    break;
                                case (int)Broadleaf.Application.Common.UnitPriceCalculation.UnitPriceKind.ListPrice:
                                    //�艿����]�������i�ɃZ�b�g
                                    proposeGoods.SuggestPrice = priceRet.UnitPriceTaxExcFl;
                                    break;
                                default:
                                    //����ɂ��Z�b�g���Ȃ�
                                    break;
                            }
                        }
                    }
                    else
                    {
                        // ��]�������i
                        proposeGoods.SuggestPrice = result.SuggestPriceRF;
                        // �d������
                        proposeGoods.PurchaseCost = result.PurchaseCostRF;
                    }

                    // �����Z�o����Ȃ������ꍇ�A�������ݒ莞�敪�ɉ����������ݒ���s��
                    if (!salesUnitPriceFlg)
                    {
                        switch (unPrcNonSettingDiv)
                        {
                            // �[���\��
                            case TBODataExportAcs.UnPrcNonSettingDivZero:
                                proposeGoods.TradePrice = 0;
                                break;
                            // �艿�\��
                            case TBODataExportAcs.UnPrcNonSettingDivSuggestPrice:
                                proposeGoods.TradePrice = proposeGoods.SuggestPrice;
                                break;
                            default:
                                proposeGoods.TradePrice = 0;
                                break;
                        }
                    }

                    // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ----<<<<<
                    // PM�X�V����
                    proposeGoods.PMUpdateTime = result.PMUpdateTimeRF;
                    // �����^�O1
                    proposeGoods.SearchTag1 = result.SearchTag1RF;
                    // �݌ɐ�
                    proposeGoods.StockCnt = result.ShipmentPosCntRF;
                    // BL���i�R�[�h
                    proposeGoods.BLGoodsCode = result.BLGoodsCodeRF;

                    proposeGoodsList.Add(proposeGoods);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���i�J�e�S���ϊ��pXML�t�@�C���̃f�V���A���C�Y
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�J�e�S���ϊ��p�̃f�[�^���f���𐶐�����</br>
        /// <br>Programmer : �͌��с@�ꐶ</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void DeserializeXMLFile()
        {
            if (this.goodsMGroupDic != null)
            {
                this.goodsMGroupDic.Clear();
            }

            string xmlFilePath = System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, FILE_NAME_TBOGOODSMCODELIST);
            List<TBOGoodsMGroup> goodsMGroupList = UserSettingController.DeserializeUserSetting<List<TBOGoodsMGroup>>(xmlFilePath);
            foreach (TBOGoodsMGroup group in goodsMGroupList)
            {
                if (!this.goodsMGroupDic.ContainsKey(group.Category))
                {
                    this.goodsMGroupDic.Add(group.Category, new List<string>());
                }
                this.goodsMGroupDic[group.Category].Add(group.GoodsMGroup);
            }
        }

        // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---->>>>>
        /// <summary>
        /// ���Ӑ�|���O���[�v�擾
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�|���O���[�v���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : �w�蓾�Ӑ�R�[�h�̓��Ӑ�|���O���[�v�����X�g�Ŏ擾����</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2016/07/04</br>
        /// <br>�Ǘ��ԍ�   : 11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗�</br>
        /// </remarks>
        private int GetCustRateGroupList( out List<CustRateGroup> custRateGroupList, string enterpriseCode, int customerCode )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //
            //���Ӑ�|���O���[�v�̎擾
            //
            custRateGroupList = null;
            if( customerCode > 0)
            {
                CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
                ArrayList resultList = null;
                status = custRateGroupAcs.Search(
                      out resultList
                    , enterpriseCode
                    , customerCode
                    , ConstantManagement.LogicalMode.GetData0 );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && resultList != null)
                {
                    custRateGroupList = new List<CustRateGroup>( (CustRateGroup[])resultList.ToArray( typeof( CustRateGroup ) ) );
                }
            }
            return status;
        }

        /// <summary>
        /// ���Ӑ�|���O���[�v�R�[�h�擾
        /// </summary>
        /// <param name="goodsMakerCode">���i���[�J�[�R�[�h</param>
        /// <param name="custRateGroupList">���Ӑ�|���O���[�v���X�g</param>
        /// <returns>���Ӑ�|���O���[�v�R�[�h�@���擾�ł��Ȃ������ꍇ-1��Ԃ�</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v���X�g���畔�i���[�J�[�R�[�h�ɕR�t�����Ӑ�|���O���[�v�R�[�h���擾</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2016/07/04</br>
        /// <br>�Ǘ��ԍ�   : 11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗�</br>
        /// </remarks>
        private int GetCustRateGroupCode( int goodsMakerCode, List<CustRateGroup> custRateGroupList )
        {
            int PureGoodsMakerCode = 999;                                    // �������[�J�[�ő�R�[�h
            int pureCode = ( goodsMakerCode <= PureGoodsMakerCode ) ? 0 : 1; // 0:���� 1:�D��

            if (custRateGroupList == null)
            {
                return -1;
            }

            // �P�ƃL�[
            CustRateGroup custRateGroup = custRateGroupList.Find(
                delegate( CustRateGroup custRate )
                {
                    if (( custRate.GoodsMakerCd == goodsMakerCode ) &&
                        ( custRate.PureCode == pureCode ))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup.CustRateGrpCode;

            // ���ʃL�[
            custRateGroup = custRateGroupList.Find(
                delegate( CustRateGroup custRate )
                {
                    if (( custRate.GoodsMakerCd == 0 ) &&
                        ( custRate.PureCode == pureCode ))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup.CustRateGrpCode;

            return -1;
        }

        # region ������S�̐ݒ�}�X�^���䏈��
        /// <summary>
        /// ����S�̐ݒ�}�X�^�擾
        /// </summary>
        /// <param name="salesTtlSt">����S�̐ݒ�}�X�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ����S�̐ݒ�}�X�^���擾</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2016/07/04</br>
        /// <br>�Ǘ��ԍ�   : 11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗�</br>
        /// </remarks>
        internal void GetSalesTtlSt( out SalesTtlSt salesTtlSt, string enterpriseCode, string sectionCode )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            salesTtlSt = null;
            if (salesTtlStCache != null
                 && this.salesTtlStCache.EnterpriseCode.Trim().Equals( enterpriseCode.Trim() )
                 && this.salesTtlStCache.SectionCode.Trim().Equals( sectionCode.Trim() ))
            {
                salesTtlSt = this.salesTtlStCache;
            }

            if (salesTtlSt == null)
            {
                // ����S�̐ݒ�}�X�^���X�g�����擾�̏ꍇ�A����S�̐ݒ�}�X�^���X�g���擾����
                if (salesTtlStList == null || salesTtlStList.Count <= 0)
                {
                    #region ������S�̐ݒ�}�X�^�擾 DCKHN09212A
                    this.logFile.Write( "����S�̐ݒ���擾" );
                    SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // ����S�̐ݒ�}�X�^�A�N�Z�T
                    salesTtlStAcs.IsLocalDBRead = LocalDBReadFlag;
                    ArrayList salesTtlStResList;
                    status = salesTtlStAcs.SearchOnlySalesTtlInfo( out salesTtlStResList, enterpriseCode );
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && salesTtlStResList != null)
                    {
                        this.salesTtlStList = new List<SalesTtlSt>( (SalesTtlSt[])salesTtlStResList.ToArray( typeof( SalesTtlSt ) ) );
                    }
                    #endregion //������S�̐ݒ�}�X�^�擾 DCKHN09212A
                }

                this.salesTtlStCache = null;
                if (this.salesTtlStList != null)
                {
                    this.salesTtlStCache = this.salesTtlStList.Find(
                        delegate( SalesTtlSt salesttl )
                        {
                            if (( salesttl.SectionCode.Trim() == sectionCode.Trim() ) &&
                                ( salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim() ))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                    if (this.salesTtlStCache == null)
                    {
                        this.salesTtlStCache = this.salesTtlStList.Find(
                            delegate( SalesTtlSt salesttl )
                            {
                                if (( salesttl.SectionCode.Trim() == DefaultSectionCode.Trim() ) &&
                                    ( salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim() ))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        );
                    }

                    salesTtlSt = this.salesTtlStCache;
                }
            }
        }
        # endregion //������S�̐ݒ�}�X�^���䏈��
        
        // ADD by ���V�� 016/07/04 FOR Redmine#48794 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ----<<<<<

        #endregion �� Private Method
    }

    //--- ADD 2016/07/05 ���X�؁i�M�j11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� --->>>
    #region Log
    /// <summary>
    /// ���O�L�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : [InstallDirectory]\Log\PMKHN09514A__yyyyMMdd_HHmmss.log �Ƀ��O�o�͂��s��</br>
    /// <br>Programmer : ���X�؁i�M�j</br>
    /// <br>Date       : 2016/07/05</br>
    /// <br>�Ǘ��ԍ�   : 11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗�</br>
    /// </remarks>
    public class LogFile
    {
        const string _logFileNameFormat = @"PMKHN09514A_{0:yyyyMMdd_HHmmss}.log";
        const int cMaxTextLength = 4000;

        private bool _errorFlg = false;
        private string _folderPath = string.Empty;
        private string _fileName = string.Empty;

        /// <summary>
        /// �G���[�t���O���擾���܂��B
        /// </summary>
        /// <remarks>
        /// �G���[���O���P��ł��L�^���ꂽ�ꍇ�� True ��Ԃ��B
        /// </remarks>
        public bool ErrorFlg
        {
            get { return this._errorFlg; }
        }

        /// <summary>
        /// ���O�t�@�C���̃t�@�C�������擾���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�t�@�C���̃t�@�C�������t���p�X�Ŏ擾���܂��B
        /// </remarks>
        public string FileName
        {
            get { return this._fileName; }
        }

        /// <summary>
        /// ���O�L�^�N���X �R���X�g���N�^
        /// </summary>
        /// <param name="clientMode">True: �N���C�A���g���[�h, False: �T�[�o�[���[�h</param>
        public LogFile( bool clientMode )
        {
            string keyPath = "";

            if (clientMode)
            {
                // �N���C���A���g
                keyPath = @String.Format( @"SOFTWARE\Broadleaf\Product\Partsman" );
            }

            else
            {
                // �T�[�o�[
                keyPath = @String.Format( @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP" );
            }

            RegistryKey key = Registry.LocalMachine.OpenSubKey( keyPath );

            try
            {
                if (key.GetValue( "InstallDirectory" ) != null)
                {
                    this._folderPath = (string)key.GetValue( "InstallDirectory" );
                }
                else
                {
                    // �擾�ł��Ȃ������ꍇ�́A�ی��Ƃ��ăA�Z���u�����z�u����Ă���t�H���_���̗p����
                    this._folderPath = System.AppDomain.CurrentDomain.BaseDirectory;
                }

                this._folderPath = Path.Combine( this._folderPath, "Log" );
            }
            finally
            {
                key.Close();
            }
        }

        /// <summary>
        /// ���O�L�^
        /// </summary>
        /// <param name="ex">��O�I�u�W�F�N�g</param>
        /// <param name="text">�L�^���b�Z�[�W</param>
        public void Write( Exception ex, string text )
        {
            this._errorFlg = true;

            if (string.IsNullOrEmpty( text ))
            {
                this.Write( ex.Message );

            }
            else
            {
                this.Write( string.Format( "{0} ({1})", ex.Message, text ) );
            }
        }

        /// <summary>
        /// ���O�L�^
        /// </summary>
        /// <param name="text">�L�^���b�Z�[�W</param>
        public void Write( string text )
        {
            string contents = string.Empty;

            if (string.IsNullOrEmpty( this._fileName ))
            {
                this._fileName = System.IO.Path.Combine( this._folderPath, string.Format( _logFileNameFormat, DateTime.Now ) );
            }

            contents = string.Format( "[{0:HH:mm:ss}] {1}" + Environment.NewLine, DateTime.Now, text );

            if (!System.IO.Directory.Exists( this._folderPath ))
            {
                // ���O�t�H���_�����݂��Ȃ��ꍇ�͍쐬����
                System.IO.Directory.CreateDirectory( this._folderPath );
            }

            // ���O�̒ǋL
            System.IO.File.AppendAllText( this._fileName, contents );
        }

    }
    #endregion
    //--- ADD 2016/07/05 ���X�؁i�M�j11270029-00 PKG���ǈČ�(TBO���o��)�̎d�l�ύX�˗� ---<<<

}
