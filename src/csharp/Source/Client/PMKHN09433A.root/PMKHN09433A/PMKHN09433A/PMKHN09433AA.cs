//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꊇ�C��
// �v���O�����T�v   : �����ꊇ�C�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/04/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �C �� ��  2009/07/10  �C�����e : PVCS#322 ���o�����̕ύX  
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2009/08/28  �C�����e : PVCS#324 ���o�����̕ύX  
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �C �� ��  2009/11/30  �C�����e : ���Ӑ�|���O���[�v����  
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30514 �Ė� �x��
// �C �� ��  2010/06/21  �C�����e : Mantis.15304�t�B�[�h�o�b�N�@�G���[�Ή�
//                                  ���o������BL�R�[�h���󔒂̏ꍇ�A�SBL�R�[�h�𒊏o�ΏۂƂ���悤�ɏC���B  
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����ꊇ�C���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꊇ�C���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009/04/01</br>
    /// </remarks>
    public class SaleRateUpdateAcs
    {
        #region ��private�萔
        private const string CT_UnitRateSetDivCd = "14A"; // �P���|���ݒ�敪
        private const string CT_UnitPriceKind = "1"; // �P�����
        private const string CT_RateSettingDivide = "4A"; // �|���ݒ�敪

        private const string CT_UserUnitRateSetDivCd = "36A"; // �P���|���ݒ�敪
        private const string CT_UserUnitPriceKind = "3"; // �P�����
        private const string CT_UserRateSettingDivide = "6A"; // �|���ݒ�敪

        #endregion ��private�萔

        #region ��private�ϐ�
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���O�C�����_�R�[�h
        private string _loginSectionCode;

        // ���i�}�X�^�A�N�Z�X
        private GoodsAcs _goodsAcs;

        // �|���}�X�^�A�N�Z�X
        private RateAcs _rateAcs;

        private TaxRateSetAcs _taxRateSetAcs;           // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X

        private TaxRateSet _taxRateSet;

        private ArrayList goodsPriceUList = new ArrayList();

        private UnitPriceCalculation _unitPriceCalculation;

        #endregion ��private�ϐ�

        #region Private Members

        // �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private ISaleRateDB _iSaleRateDB = null;    // �ېݒ胊���[�g

        /// <summary>���i�}�X�^</summary>
        public ArrayList GoodsPriceUList
        {
            get { return this.goodsPriceUList; }
            set { this.goodsPriceUList = value; }
        }

        #endregion Private Members

        #region �� Construcstor
        /// <summary>
        /// �����ꊇ�C���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ꊇ�C���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public SaleRateUpdateAcs()
        {
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd();
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd();
            this._rateAcs = new RateAcs();
            this._goodsAcs = new GoodsAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            string msg;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);

            ReadTaxRate();

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSaleRateDB = (ISaleRateDB)MediationSaleRateDB.GetSaleRateDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iSaleRateDB = null;
            }
        }

        #endregion �� Construcstor

        #region �� Public Methods
        /// <summary>
        /// ���i�}�X�^��������
        /// </summary>
        /// <param name="goodsUnitDataList">���i�}�X�^�������ʃ��X�g</param>
        /// <param name="salesRateSearchParam">���i�}�X�^��������</param>
        /// <param name="errMsg">���i�}�X�^��������</param>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^���������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public int Search(out List<GoodsUnitData> goodsUnitDataList, SalesRateSearchParam salesRateSearchParam, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            errMsg = string.Empty;
            goodsUnitDataList = new List<GoodsUnitData>();

            List<GoodsUnitData> retList = new List<GoodsUnitData>(); // ADD 2009/07/10
            // ���o�����̍쐬
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.SectionCode = salesRateSearchParam.SectionCode;
            goodsCndtn.EnterpriseCode = salesRateSearchParam.EnterpriseCode;
            goodsCndtn.GoodsMakerCd = salesRateSearchParam.GoodsMakerCd;
            goodsCndtn.BLGoodsCode = salesRateSearchParam.BLGoodsCode;
            // ���i���� (0,1����)
            goodsCndtn.GoodsKindCode = 9;

            try
            {
                status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData0, out retList, out errMsg);

                // --- ADD 2009/07/10 ------------------------------->>>>>
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (GoodsUnitData goodsUnitData in retList)
                    {
                        // 2010/06/21 Add ���o������BL�R�[�h��0�Ȃ�SBL�R�[�h�Ώ� >>>
                        if (salesRateSearchParam.BLGoodsCode == 0)
                        {
                            goodsUnitDataList.Add(goodsUnitData);
                        }
                        else
                        {
                            // 2010/06/21 Add <<<
                            if (goodsUnitData.BLGoodsCode == salesRateSearchParam.BLGoodsCode)
                            {
                                goodsUnitDataList.Add(goodsUnitData);
                            }
                        }   // 2010/06/21 Add
                    }
                }
                // --- ADD 2009/07/10 ------------------------------<<<<<
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                goodsUnitDataList = new List<GoodsUnitData>();
            }

            return (status);
        }

        /// <summary>
        /// �|���}�X�^��������
        /// </summary>
        /// <param name="rateSearchResultLis">�|���}�X�^�������ʃ��X�g</param>
        /// <param name="userRateSearchResultLis">�|���}�X�^��������</param>
        /// <param name="goodsUnitDataList">�|���}�X�^��������</param>
        /// <param name="salesRateSearchParam">�|���}�X�^��������</param>
        /// <param name="errMsg">�|���}�X�^��������</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public int Search(out List<Rate> rateSearchResultLis, out List<Rate> userRateSearchResultLis, List<GoodsUnitData> goodsUnitDataList, SalesRateSearchParam salesRateSearchParam, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            errMsg = string.Empty;
            rateSearchResultLis = new List<Rate>();
            userRateSearchResultLis = new List<Rate>();

            // ���o�����̍쐬
            // �|���}�X�^���擾����
            ArrayList retList;
            List<Rate> userRetList;

            // �����ݒ�
            Rate rate = new Rate();
            rate.EnterpriseCode = this._enterpriseCode;
            // �P�����
            rate.UnitPriceKind = CT_UnitPriceKind;

            // �P���|���ݒ�敪
            // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            // TODO:rate.UnitRateSetDivCd = CT_UnitRateSetDivCd;
            // TODO:rate.RateSettingDivide = CT_RateSettingDivide;
            // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
            rate.UnitRateSetDivCd = ExistsAllCustRateGrpCode(salesRateSearchParam) ? string.Empty : CT_UnitRateSetDivCd;
            rate.RateSettingDivide = ExistsAllCustRateGrpCode(salesRateSearchParam) ? string.Empty : CT_RateSettingDivide;
            // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

            rate.LogicalDeleteCode = 0;
            rate.CustRateGrpCode = -1;// ADD 2009/08/28

            status = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retList != null
                && retList.Count != 0)
            {
                // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                // TODO:rateSearchResultLis = new List<Rate>((Rate[])retList.ToArray(typeof(Rate)));
                // DEL 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
                if (!ExistsAllCustRateGrpCode(salesRateSearchParam))
                {
                    rateSearchResultLis = new List<Rate>((Rate[])retList.ToArray(typeof(Rate)));
                }
                else
                {
                    foreach (Rate searchedRate in retList)
                    {
                        if (
                            searchedRate.UnitRateSetDivCd.Trim().Equals(CT_UnitRateSetDivCd)
                                ||
                            searchedRate.UnitRateSetDivCd.Trim().Equals(ALL_UNIT_RATE_SET_DIV_CD)
                        )
                        {
                            if (searchedRate.UnitRateSetDivCd.Trim().Equals(ALL_UNIT_RATE_SET_DIV_CD))
                            {
                                Debug.WriteLine(searchedRate.GoodsNo + " " + searchedRate.CustRateGrpCode.ToString());
                                searchedRate.CustRateGrpCode = ALL_CUST_RATE_GRP_CODE;
                            }
                            rateSearchResultLis.Add(searchedRate);
                        }
                    }
                }
                // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<
            }

            List<Rate> userrateList = new List<Rate>();
            Rate userrate = new Rate();
            userrate.EnterpriseCode = this._enterpriseCode;
            // �P�����
            userrate.UnitPriceKind = CT_UserUnitPriceKind;
            // �P���|���ݒ�敪
            userrate.UnitRateSetDivCd = CT_UserUnitRateSetDivCd;
            userrate.RateSettingDivide = CT_UserRateSettingDivide;
            userrate.LogicalDeleteCode = 0;
            userrate.CustRateGrpCode = -1;// ADD 2009/08/28
            userrateList.Add(userrate);

            status = this._rateAcs.Search(out userRetList, userrateList, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && userRetList != null
                && userRetList.Count != 0)
            {
                userRateSearchResultLis = userRetList;
            }

            return (status);
        }

        // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ---------->>>>>
        /// <summary>���Ӑ�|���O���[�v�R�[�h�w��Ȃ�</summary>
        public const int ALL_CUST_RATE_GRP_CODE = -1;

        /// <summary>���Ӑ�|���O���[�v�R�[�h�w��Ȃ�</summary>
        private const string ALL_UNIT_RATE_SET_DIV_CD = "16A";

        /// <summary>
        /// ���Ӑ�|���O���[�v�R�[�h�w��Ȃ������݂��邩���肵�܂��B
        /// </summary>
        /// <param name="salesRateSearchParam">�����ݒ茟������</param>
        /// <returns>
        /// <c>true</c> :���݂��܂��B<br/>
        /// <c>false</c>:���݂��܂���B
        /// </returns>
        private static bool ExistsAllCustRateGrpCode(SalesRateSearchParam salesRateSearchParam)
        {
            return Array.Exists<int>(salesRateSearchParam.CustRateGrpCode, delegate(int custRateGrpCode)
            {
                return custRateGrpCode < 0;
            });
        }
        // ADD 2009/11/30 3�����Ή� ���Ӑ�|���O���[�v���� ----------<<<<<

        #region Save �ۑ�����
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="delRateList">�폜�f�[�^���X�g</param>
        /// <param name="updRateList">�X�V�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public int Save(ref ArrayList delRateList, ref ArrayList updRateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                RateWork delRateWork = null;
                RateWork updRateWork = null;
                ArrayList delRateWorkList = new ArrayList();	// ���[�N�N���X�i�[�pArrayList
                ArrayList updRateWorkList = new ArrayList();	// ���[�N�N���X�i�[�pArrayList

                // ���[�N�N���X�i�[�pArrayList�֋l�ߑւ�
                for (int i = 0; i < delRateList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    delRateWork = CopyToRateWorkFromRate((Rate)delRateList[i]);
                    delRateWorkList.Add(delRateWork);
                }

                for (int i = 0; i < updRateList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    updRateWork = CopyToRateWorkFromRate((Rate)updRateList[i]);
                    updRateWorkList.Add(updRateWork);
                }

                object delparaObj = (object)delRateWorkList;
                object updparaObj = (object)updRateWorkList;

                // �ۑ�����
                status = this._iSaleRateDB.Save(delparaObj, updparaObj, ref message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�ۑ��Ɏ��s���܂����B";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._iSaleRateDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion Save �ۑ�����


        #endregion �� Public Methods

        #region �N���X�����o�R�s�[����
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ�N���X�ˊ|���ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="rate">�|���ݒ�N���X</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�N���X����|���ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            // �쐬����
            rateWork.CreateDateTime = rate.CreateDateTime;
            // �X�V����
            rateWork.UpdateDateTime = rate.UpdateDateTime;
            // ��ƃR�[�h
            rateWork.EnterpriseCode = rate.EnterpriseCode;
            // GUID
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
            // �_���폜�敪
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;
            // ���_�R�[�h
            rateWork.SectionCode = rate.SectionCode;
            // �P���|���ݒ�敪
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;
            // �P�����
            rateWork.UnitPriceKind = rate.UnitPriceKind;
            // �|���ݒ�敪
            rateWork.RateSettingDivide = rate.RateSettingDivide;
            // �|���ݒ�敪�i���i�j
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;
            // �|���ݒ薼�́i���i�j
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;
            // �|���ݒ�敪�i���Ӑ�j
            rateWork.RateMngCustCd = rate.RateMngCustCd;
            // �|���ݒ薼�́i���Ӑ�j
            rateWork.RateMngCustNm = rate.RateMngCustNm;
            // ���i���[�J�[�R�[�h
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;
            // ���i�ԍ�
            rateWork.GoodsNo = rate.GoodsNo;
            // ���i�|�������N
            rateWork.GoodsRateRank = rate.GoodsRateRank;
            // BL���i�R�[�h
            rateWork.BLGoodsCode = rate.BLGoodsCode;
            // ���Ӑ�R�[�h
            rateWork.CustomerCode = rate.CustomerCode;
            // ���Ӑ�|���O���[�v�R�[�h
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;
            // �d����R�[�h
            rateWork.SupplierCd = rate.SupplierCd;
            // ���b�g��
            rateWork.LotCount = rate.LotCount;
            // ���i
            rateWork.PriceFl = rate.PriceFl;
            // �|��
            rateWork.RateVal = rate.RateVal;
            // �P���[�������P��
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;
            // �P���[�������敪
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;
            // ���i�|���O���[�v�R�[�h
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;
            // BL�O���[�v�R�[�h
            rateWork.BLGroupCode = rate.BLGroupCode;
            // UP��
            rateWork.UpRate = rate.UpRate;
            // �e���m�ۗ�
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;

            return rateWork;
        }
        #endregion �N���X�����o�R�s�[����

        /// <summary>
        /// �ŗ��ݒ�}�X�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/01</br>
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
        /// ���i�}�X�^
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public void SearchGoodsPriceU(List<GoodsUnitData> goodsUnitDataList, string searchSectionCode)
        {
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // �P���Z�o�p�����[�^�ݒ�
                UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                unitPriceCalcParam.SectionCode = searchSectionCode;    // ���_�R�[�h
                unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // ���i���[�J�[�R�[�h
                unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // ���i�ԍ�
                unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // ���i�|�������N
                unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsMGroup;                            // ���i�|���O���[�v�R�[�h
                unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BL�O���[�v�R�[�h
                unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL���i�R�[�h
                unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // �d����R�[�h
                unitPriceCalcParam.PriceApplyDate = DateTime.Now;                                           // ���i�K�p��
                unitPriceCalcParam.CountFl = 1;                                                             // ����
                unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // �ېŋ敪
                unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(this._taxRateSet, DateTime.Now);      // �ŗ�
                unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // �d������Œ[�������R�[�h
                unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // �d���P���[�������R�[�h
                unitPriceCalcParam.TotalAmountDispWayCd = 0;                                                // ���z�\�����@�敪
                unitPriceCalcParam.TtlAmntDspRateDivCd = 1;                                                 // ���z�\���|���K�p�敪
                unitPriceCalcParam.ConsTaxLayMethod = this._taxRateSet.ConsTaxLayMethod;                    // ����œ]�ŕ���

                unitPriceCalcParamList.Add(unitPriceCalcParam);
            }

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    // ����ۑ�����
                    goodsPriceUList.Add(unitPriceCalcRetWk);
                }
            }

        }

        /// <summary>
        /// �d����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        public double GetStockUnitPrice(GoodsUnitData goodsUnitData)
        {
            double stockUnitPrice = 0;

            foreach (UnitPriceCalcRet unitPriceCalcRet in this.goodsPriceUList)
            {
                if (unitPriceCalcRet.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                    && unitPriceCalcRet.GoodsNo.Equals(goodsUnitData.GoodsNo))
                {
                    stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;
                }
            }

            return stockUnitPrice;
        }

    }
}
