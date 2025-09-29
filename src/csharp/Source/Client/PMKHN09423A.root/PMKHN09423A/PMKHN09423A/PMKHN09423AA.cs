//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�U�[���i�E�����ꊇ�ݒ�
// �v���O�����T�v   : ���[�U�[���i�E�����𕡐����ꊇ�ŏC���E�o�^����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/05/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�U�[���i�E�����ꊇ�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[���i�E�����ꊇ�ݒ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.05.05</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.21 men �V�K�쐬(DC.NS���痬�p)</br>
    /// </remarks>
    public class UserPriceInputAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private UserPriceInputAcs()
        {
            this._userPriceData = new UserPriceData();
            this._userPriceSaveData = new UserPriceData();
            this._userPriceDataTable = new UserPriceDataSet.UserPriceDataTable();
            this._userPriceCopyDataTable = new UserPriceDataSet.UserPriceDataTable();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._unitPriceCalculation = new UnitPriceCalculation();
            this._rateAcs = new RateAcs();

            ReadTaxRate();

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._userPriceDB = (IUserPriceDB)MediationUserPriceDB.GetUserPriceDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._userPriceDB = null;
            }

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._goodsPriceUDB = (IGoodsPriceUDB)MediationGoodsPriceUDB.GetGoodsPriceUDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._goodsPriceUDB = null;
            }
        }

        /// <summary>
        /// ���̓A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>���̓A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public static UserPriceInputAcs GetInstance()
        {
            if (_userPriceInputAcs == null)
            {
                _userPriceInputAcs = new UserPriceInputAcs();
            }

            return _userPriceInputAcs;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�2
        // ===================================================================================== //
        # region ��Private Members
        private UserPriceData _userPriceData;
        private UserPriceData _userPriceSaveData;
        private static UserPriceInputAcs _userPriceInputAcs;
        private UserPriceDataSet.UserPriceDataTable _userPriceDataTable;
        private TaxRateSetAcs _taxRateSetAcs;           // �ŗ��ݒ�}�X�^�A�N�Z�X�N���X
        private TaxRateSet _taxRateSet;
        private UnitPriceCalculation _unitPriceCalculation;
        private ArrayList rateList = new ArrayList();
        private ArrayList goodsPriceUList = new ArrayList();
        private ArrayList delRateList = new ArrayList();
        private ArrayList delGoodsPriceUList = new ArrayList();
        private ArrayList delRateCopyList = new ArrayList();
        // �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private IUserPriceDB _userPriceDB = null;    // �ېݒ胊���[�g
        private IGoodsPriceUDB _goodsPriceUDB = null;

        private RateAcs _rateAcs = null;

        private UserPriceDataSet.UserPriceDataTable _userPriceCopyDataTable;

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>���i�}�X�^</summary>
        public ArrayList GoodsPriceUList
        {
            get { return this.goodsPriceUList; }
            set { this.goodsPriceUList = value; }
        }

        /// <summary>�|���}�X�^</summary>
        public ArrayList RateList
        {
            get { return this.rateList; }
            set { this.rateList = value; }
        }

        /// <summary>���̓f�[�^</summary>
        public UserPriceData UserPriceData
        {
            get { return this._userPriceData; }
        }

        /// <summary>���̓f�[�^</summary>
        public UserPriceData UserPriceSaveData
        {
            get { return this._userPriceSaveData; }
            set { this._userPriceSaveData = value; }
        }

        /// <summary>�f�[�^�Z�b�g</summary>
        public UserPriceDataSet.UserPriceDataTable UserPriceDataTable
        {
            get { return this._userPriceDataTable; }
        }

        /// <summary>�f�[�^�Z�b�g</summary>
        public UserPriceDataSet.UserPriceDataTable UserPriceCopyDataTable
        {
            get { return this._userPriceCopyDataTable; }
            set { this._userPriceCopyDataTable = value; }
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region ��Public Methods
        /// <summary>
        /// �����f�[�^�����C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public void CreateSalesSlipInitialData()
        {
            UserPriceData userPriceData = new UserPriceData();

            // ���_�����l
            userPriceData.SectionCode = "00";
            userPriceData.SectionName = "�S��";

            this.CacheUserPriceData(userPriceData);
        }

        /// <summary>
        /// �����f�[�^�L���b�V������
        /// </summary>
        /// <param name="source">����f�[�^�C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public void CacheUserPriceData(UserPriceData source)
        {
            this._userPriceData = source.Clone();
        }

        /// <summary>
        /// �|���}�X�^����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public int SearchRate()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // �폜���X�g
            this.delRateList = new ArrayList();
            // �� 2009.06.19 ���m add
            this.delRateCopyList = new ArrayList();
            // �� 2009.06.19 ���m add

            // ���o�����̍쐬
            // �|���}�X�^���擾����
            ArrayList retList = null;

            // �����ݒ�
            Rate rate = new Rate();
            string errMsg = null;
            rate.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �P���|���ݒ�敪
            rate.UnitRateSetDivCd = "36A";
            rate.RateSettingDivide = "6A";
            // �P�����
            rate.UnitPriceKind = "3";
            // �P���|���ݒ�敪
            // �_���폜�t���O�s�v
            // rate.LogicalDeleteCode = 0;

            status = _rateAcs.SearchAll(out retList, ref rate, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retList != null
                && retList.Count != 0)
            {
                // ���X�g��ǉ�����
                this.rateList.AddRange(retList);
            }

            return status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public double GetUserPrice(GoodsUnitData goodsUnitData)
        {
            double userPrice = 0;

            foreach (Rate rate in this.rateList)
            {
                if (rate.SectionCode.Equals(this._userPriceData.SectionCode)
                    && rate.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                    && rate.GoodsNo.Equals(goodsUnitData.GoodsNo))
                {
                    // �폜���X�g�쐬����
                    RateWork rateWork = new RateWork();
                    rateWork = this.CopyToRateWorkFromRate(rate);
                    delRateList.Add(rateWork);
                    // �� 2009.06.18 liuyang add
                    delRateCopyList.Add(rateWork);
                    // �� 2009.06.18 liuyang add

                    if (rate.LogicalDeleteCode == 0)
                    {
                        userPrice = rate.PriceFl;
                    }
                    else
                    {
                        // �_���폜�ꍇ
                        userPrice = 0;
                    }
                    break;
                }
            }

            return userPrice;
        }

        /// <summary>
        /// ���i�}�X�^
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public void SearchGoodsPriceU(List<GoodsUnitData> goodsUnitDataList)
        {
            // �폜���X�g
            // this.delGoodsPriceUList = new ArrayList();

            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // �P���Z�o�p�����[�^�ݒ�
                UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
                unitPriceCalcParam.SectionCode = this._userPriceSaveData.SectionCode;    // ���_�R�[�h
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
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public double GetStockUnitPrice(GoodsUnitData goodsUnitData, ref int starFlg)
        {
            double stockUnitPrice = 0;

            foreach (UnitPriceCalcRet unitPriceCalcRet in this.goodsPriceUList)
            {
                if (unitPriceCalcRet.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                    && unitPriceCalcRet.GoodsNo.Equals(goodsUnitData.GoodsNo))
                {
                    //stockUnitPrice = ((goodsUnitData.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)) ? unitPriceCalcRet.UnitPriceTaxIncFl : unitPriceCalcRet.UnitPriceTaxExcFl;
                    stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

                    if (!string.IsNullOrEmpty(unitPriceCalcRet.RateSettingDivide))
                    {
                        starFlg = 1;
                    }
                }
            }

            return stockUnitPrice;
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��Private Methods
        /// <summary>
        /// �P���Z�o���ʃI�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�P���Z�o���ʃI�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^���P���Z�o���ʃI�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009/05/05</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData)
        {
            // �P���Z�o�p�����[�^�ݒ�
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();    // ���_�R�[�h
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

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    // ����ۑ�����
                    goodsPriceUList.Add(unitPriceCalcRetWk);
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// �ŗ��ݒ�}�X�^�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
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
        /// �|���}�X�^
        /// </summary>
        /// <param name="rate">�|���}�X�^</param>
        /// <param name="BLGoodsNo">�i��</param>
        /// <param name="goodsMakerCd">���i�R�[�h</param>
        /// <param name="sectionCode">���_</param>
        /// <returns>�t���O</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private bool FindRateData(ref Rate rate, string BLGoodsNo, int goodsMakerCd, string sectionCode)
        {
            foreach (Rate rateData in this.rateList)
            {
                if (rateData.GoodsNo.Equals(BLGoodsNo) && rateData.GoodsMakerCd == goodsMakerCd
                    && rateData.SectionCode.Equals(sectionCode) && rateData.LogicalDeleteCode == 0)
                {
                    rate = rateData;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// �|���}�X�^
        /// </summary>
        /// <param name="BLGoodsNo">�i��</param>
        /// <param name="goodsMakerCd">���i�R�[�h</param>
        /// <param name="sectionCode">���_</param>
        /// <returns>�t���O</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public bool FindRateData(string BLGoodsNo, int goodsMakerCd, string sectionCode)
        {
            foreach (Rate rateData in this.rateList)
            {
                if (rateData.GoodsNo.Equals(BLGoodsNo) && rateData.GoodsMakerCd == goodsMakerCd
                    && rateData.SectionCode.Equals(sectionCode) && rateData.LogicalDeleteCode == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���i�}�X�^
        /// </summary>
        /// <param name="unitPriceCalcRet">���i�}�X�^</param>
        /// <param name="BLGoodsNo">�i��</param>
        /// <param name="goodsMakerCd">���i�R�[�h</param>
        /// <returns>�t���O</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private bool FindPriceCalcData(ref UnitPriceCalcRet unitPriceCalcRet, string BLGoodsNo, int goodsMakerCd)
        {
            foreach (UnitPriceCalcRet unitPriceCalcRetData in this.goodsPriceUList)
            {
                if (unitPriceCalcRetData.GoodsNo.Equals(BLGoodsNo) && unitPriceCalcRetData.GoodsMakerCd == goodsMakerCd)
                {
                    unitPriceCalcRet = unitPriceCalcRetData;
                    return true;
                }
            }
            return false;
        }
        #endregion

        // ===================================================================================== //
        // DB�f�[�^�A�N�Z�X����
        // ===================================================================================== //
        # region ��DataBase Access Methods
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public int SaveData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList updateRateData = new ArrayList();
            ArrayList updateGoodsPriceUData = new ArrayList();

            this.delGoodsPriceUList = new ArrayList();

            // �� 2009.06.19 ���m add
            delRateList = new ArrayList();
            delRateList.AddRange(delRateCopyList);
            // �� 2009.06.19 ���m add

            int i = 0;
            foreach (UserPriceDataSet.UserPriceRow row in this._userPriceDataTable)
            {
                // �� 2009.06.18 ���m modify PVCS.199
                UserPriceDataSet.UserPriceRow copyRow = (UserPriceDataSet.UserPriceRow)this._userPriceCopyDataTable.Rows[i];

                if (row.UserPrice != copyRow.UserPrice)
                {
                    RateWork rateWork = CreateRateSaveData(row);
                    updateRateData.Add(rateWork);

                    // �폜�f�[�^���N���A
                    if (rateWork.LogicalDeleteCode == 1)
                    {
                        foreach (RateWork rate in this.delRateList)
                        {
                            if (rateWork.GoodsNo.Equals(rate.GoodsNo) && rateWork.GoodsMakerCd == rate.GoodsMakerCd
                                && rateWork.SectionCode.Equals(rate.SectionCode))
                            {
                                delRateList.Remove(rate);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    // �폜�f�[�^�N���A
                    foreach (RateWork rate in this.delRateList)
                    {
                        if (row.BLGoodsNo.Equals(rate.GoodsNo) && this._userPriceSaveData.GoodsMakerCd == rate.GoodsMakerCd
                            && this._userPriceSaveData.SectionCode.Equals(rate.SectionCode))
                        {
                            delRateList.Remove(rate);
                            break;
                        }
                    }
                }

                if (row.StockPrice != copyRow.StockPrice)
                {
                    GoodsPriceUWork goodsPriceUWork = CreateGoodsPriceUData(row);
                    // �d���������[���ȊO�̏ꍇ
                    if (goodsPriceUWork.GoodsMakerCd != 0)
                    {
                        updateGoodsPriceUData.Add(goodsPriceUWork);
                    }
                }
                i++;
                // �� 2009.06.18 ���m modify
            }

            object paraRateDelObj = (object)delRateList;
            object paraGoodsPriceUDelObj = (object)delGoodsPriceUList;
            object paraRateObj = (object)updateRateData;
            object paraGoodsPriceObj = (object)updateGoodsPriceUData;

            // �� 2009.06.18 ���m modify
            if (updateRateData.Count == 0 && updateGoodsPriceUData.Count == 0
                && delRateList.Count == 0 && delGoodsPriceUList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                return status;
            }
            // �� 2009.06.18 ���m modify

            // ���o�^
            string msg = "";
            status = this._userPriceDB.Write(paraRateObj, paraGoodsPriceObj, paraRateDelObj,paraGoodsPriceUDelObj, ref msg);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            return status;
        }

        /// <summary>
        /// �|���}�X�^���쐬
        /// </summary>
        /// <returns>�|���}�X�^</returns>
        private RateWork CreateRateSaveData(UserPriceDataSet.UserPriceRow row)
        {
            // �|���}�X�^�o�^
            RateWork rateWork = new RateWork();

            Rate rate = new Rate();
            bool isExistFlg = FindRateData(ref rate, row.BLGoodsNo, this._userPriceSaveData.GoodsMakerCd, this._userPriceSaveData.SectionCode);
            // �X�V�̏ꍇ
            if (isExistFlg)
            {
                rateWork = this.CopyToRateWorkFromRate(rate);

                if (row.UserPrice == 0)
                {
                    if (rateWork.UpRate == 0)
                    {
                        rateWork.LogicalDeleteCode = 1;
                    }
                    else
                    {
                        // �X�V����
                        rateWork.UpdateDateTime = DateTime.MinValue;
                        rateWork.PriceFl = 0;
                    }
                }
                else
                {
                    // �X�V����
                    rateWork.UpdateDateTime = DateTime.MinValue;
                    rateWork.PriceFl = row.UserPrice;
                }
            }
            else
            {
                // �o�^�̏ꍇ
                rateWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                // ���_�R�[�h
                rateWork.SectionCode = this._userPriceSaveData.SectionCode;
                // �P���|���ݒ�敪
                rateWork.UnitRateSetDivCd = "36A";
                // �P�����
                rateWork.UnitPriceKind = "3";
                // �|���ݒ�敪
                rateWork.RateSettingDivide = "6A";
                // �|���ݒ�敪�i���i�j
                rateWork.RateMngGoodsCd = "A";
                // �|���ݒ薼�́i���i�j
                rateWork.RateMngGoodsNm = "Ұ��+�i��";
                // �|���ݒ�敪�i���Ӑ�j
                rateWork.RateMngCustCd = "6";
                // �|���ݒ薼�́i���Ӑ�j
                rateWork.RateMngCustNm = "�w��Ȃ�";
                // ���i���[�J�[�R�[�h
                rateWork.GoodsMakerCd = this.UserPriceData.GoodsMakerCd;
                // ���i�ԍ�
                rateWork.GoodsNo = row.BLGoodsNo;
                // ���i�|�������N
                rateWork.GoodsRateRank = string.Empty;
                // ���i�|���O���[�v�R�[�h
                rateWork.GoodsRateGrpCode = 0;
                // BL�O���[�v�R�[�h
                rateWork.BLGroupCode = 0;
                // BL���i�R�[�h
                rateWork.BLGoodsCode = 0;
                // ���Ӑ�R�[�h
                rateWork.CustomerCode = 0;
                // ���Ӑ�|���O���[�v�R�[�h
                rateWork.CustRateGrpCode = 0;
                // �d����R�[�h
                rateWork.SupplierCd = 0;
                // ���b�g��
                rateWork.LotCount = 9999999.99;
                // ���i�i�����j
                rateWork.PriceFl = row.UserPrice;
                // �|��
                rateWork.RateVal = 0;
                // UP��
                rateWork.UpRate = 0;
                // �e���m�ۗ�
                rateWork.GrsProfitSecureRate = 0;
                // �� 2009.06.18 ���m modify PVCS.207
                // �P���[�������P��
                // rateWork.UnPrcFracProcUnit = 0;
                rateWork.UnPrcFracProcUnit = 1.00;
                // �P���[�������敪
                // rateWork.UnPrcFracProcDiv = 0;
                rateWork.UnPrcFracProcDiv = 2;
                // �� 2009.06.18 ���m modify
            }

            return rateWork;
        }

        /// <summary>
        /// ���i�}�X�^���쐬
        /// </summary>
        /// <param name="row">���i�}�X�^</param>
        /// <returns>���i�}�X�^</returns>
        private GoodsPriceUWork CreateGoodsPriceUData(UserPriceDataSet.UserPriceRow row)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            UnitPriceCalcRet unitPriceCalcRet = new UnitPriceCalcRet();
            bool isExistFlg = FindPriceCalcData(ref unitPriceCalcRet, row.BLGoodsNo, this._userPriceSaveData.GoodsMakerCd);

            if (isExistFlg)
            {
                GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
                // �p�����[�^
                paraGoodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                paraGoodsPriceUWork.LogicalDeleteCode = 0;
                paraGoodsPriceUWork.GoodsMakerCd = unitPriceCalcRet.GoodsMakerCd;
                paraGoodsPriceUWork.GoodsNo = unitPriceCalcRet.GoodsNo;
                paraGoodsPriceUWork.PriceStartDate = unitPriceCalcRet.PriceStartDate;
                // ����
                object goodsPriceUDataList = null;
                int status = this._goodsPriceUDB.Search(out goodsPriceUDataList,
                    (object)paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList result = (ArrayList)goodsPriceUDataList;
                    goodsPriceUWork = (GoodsPriceUWork)result[0];
                    // �폜���X�g�쐬
                    GoodsPriceUWork goodsPriceUCopyWork = this.CopyTogoodsPriceUWork(goodsPriceUWork);
                    this.delGoodsPriceUList.Add(goodsPriceUCopyWork);
                    // ���i
                    goodsPriceUWork.SalesUnitCost = row.StockPrice;
                    goodsPriceUWork.UpdateDateTime = DateTime.MinValue;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // �d���������[���ȊO�̏ꍇ
                    if (row.StockPrice != 0)
                    {
                        goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                        goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                        goodsPriceUWork.PriceStartDate = DateTime.Now;
                        goodsPriceUWork.ListPrice = 0;
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.StockRate = 0;
                        goodsPriceUWork.OpenPriceDiv = 0;
                        goodsPriceUWork.OfferDate = DateTime.Now;
                        goodsPriceUWork.UpdateDate = DateTime.Now;
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // �d���������[���ȊO�̏ꍇ
                    if (row.StockPrice != 0)
                    {
                        goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                        goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                        goodsPriceUWork.PriceStartDate = DateTime.Now;
                        goodsPriceUWork.ListPrice = 0;
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.StockRate = 0;
                        goodsPriceUWork.OpenPriceDiv = 0;
                        goodsPriceUWork.OfferDate = DateTime.Now;
                        goodsPriceUWork.UpdateDate = DateTime.Now;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            else
            {
                GoodsPriceUWork paraGoodsPriceUWork = new GoodsPriceUWork();
                // �p�����[�^
                paraGoodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                paraGoodsPriceUWork.LogicalDeleteCode = 0;
                paraGoodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                paraGoodsPriceUWork.GoodsNo = row.BLGoodsNo;

                // ����
                object goodsPriceUDataList = null;
                int status = this._goodsPriceUDB.Search(out goodsPriceUDataList,
                    (object)paraGoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ŋߓ����f�[�^���擾����
                    ArrayList result = (ArrayList)goodsPriceUDataList;
                    int i = 0;
                    int j = -1;
                    DateTime value = DateTime.MinValue;
                    foreach (GoodsPriceUWork res in result)
                    {
                        if (res.PriceStartDate > value && res.PriceStartDate.Date <= DateTime.Now.Date)
                        {
                            value = res.PriceStartDate;
                            j = i;
                        }

                        i++;
                    }
                    // �� 2009.06.17 liuyang add PVCS.181
                    //goodsPriceUWork = (GoodsPriceUWork)result[j];
                    //// �폜���X�g�쐬
                    //GoodsPriceUWork goodsPriceUCopyWork = this.CopyTogoodsPriceUWork(goodsPriceUWork);
                    //this.delGoodsPriceUList.Add(goodsPriceUCopyWork);
                    //// ���i
                    //goodsPriceUWork.SalesUnitCost = row.StockPrice;
                    //goodsPriceUWork.UpdateDateTime = DateTime.MinValue;
                    if (j != -1)
                    {
                        goodsPriceUWork = (GoodsPriceUWork)result[j];
                        // �폜���X�g�쐬
                        GoodsPriceUWork goodsPriceUCopyWork = this.CopyTogoodsPriceUWork(goodsPriceUWork);
                        this.delGoodsPriceUList.Add(goodsPriceUCopyWork);
                        // ���i
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.UpdateDateTime = DateTime.MinValue;

                    }
                    else
                    {
                        // �d���������[���ȊO�̏ꍇ
                        if (row.StockPrice != 0)
                        {
                            goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                            goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                            goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                            goodsPriceUWork.PriceStartDate = DateTime.Now;
                            goodsPriceUWork.ListPrice = 0;
                            goodsPriceUWork.SalesUnitCost = row.StockPrice;
                            goodsPriceUWork.StockRate = 0;
                            goodsPriceUWork.OpenPriceDiv = 0;
                            goodsPriceUWork.OfferDate = DateTime.Now;
                            goodsPriceUWork.UpdateDate = DateTime.Now;
                        }
                    }
                    // �� 2009.06.17 liuyang modify
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // �d���������[���ȊO�̏ꍇ
                    if (row.StockPrice != 0)
                    {
                        goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                        goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                        goodsPriceUWork.PriceStartDate = DateTime.Now;
                        goodsPriceUWork.ListPrice = 0;
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.StockRate = 0;
                        goodsPriceUWork.OpenPriceDiv = 0;
                        goodsPriceUWork.OfferDate = DateTime.Now;
                        goodsPriceUWork.UpdateDate = DateTime.Now;
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    // �d���������[���ȊO�̏ꍇ
                    if (row.StockPrice != 0)
                    {
                        goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                        goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                        goodsPriceUWork.PriceStartDate = DateTime.Now;
                        goodsPriceUWork.ListPrice = 0;
                        goodsPriceUWork.SalesUnitCost = row.StockPrice;
                        goodsPriceUWork.StockRate = 0;
                        goodsPriceUWork.OpenPriceDiv = 0;
                        goodsPriceUWork.OfferDate = DateTime.Now;
                        goodsPriceUWork.UpdateDate = DateTime.Now;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                //// �d���������[���ȊO�̏ꍇ
                //if (row.StockPrice != 0)
                //{
                //    goodsPriceUWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                //    goodsPriceUWork.GoodsMakerCd = this._userPriceSaveData.GoodsMakerCd;
                //    goodsPriceUWork.GoodsNo = row.BLGoodsNo;
                //    goodsPriceUWork.PriceStartDate = DateTime.Now;
                //    goodsPriceUWork.ListPrice = 0;
                //    goodsPriceUWork.SalesUnitCost = row.StockPrice;
                //    goodsPriceUWork.StockRate = 0;
                //    goodsPriceUWork.OpenPriceDiv = 0;
                //    goodsPriceUWork.OfferDate = DateTime.Now;
                //    goodsPriceUWork.UpdateDate = DateTime.Now;
                //}
            }

            return goodsPriceUWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ�N���X�ˊ|���ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="rate">�|���ݒ�N���X</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�N���X����|���ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���m</br>
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

        /// <summary>
        /// ���i�}�X�^�R�s�[
        /// </summary>
        /// <param name="goodsPriceUWork">���i�}�X�^</param>
        /// <returns>���i�}�X�^</returns>
        private GoodsPriceUWork CopyTogoodsPriceUWork(GoodsPriceUWork goodsPriceUWork)
        {
            GoodsPriceUWork goodsPriceUWorkCopy = new GoodsPriceUWork();

            goodsPriceUWorkCopy.CreateDateTime = goodsPriceUWork.CreateDateTime;
            goodsPriceUWorkCopy.UpdateDateTime = goodsPriceUWork.UpdateDateTime;
            goodsPriceUWorkCopy.EnterpriseCode = goodsPriceUWork.EnterpriseCode;
            goodsPriceUWorkCopy.FileHeaderGuid = goodsPriceUWork.FileHeaderGuid;
            goodsPriceUWorkCopy.UpdEmployeeCode = goodsPriceUWork.UpdEmployeeCode;
            goodsPriceUWorkCopy.UpdAssemblyId1 = goodsPriceUWork.UpdAssemblyId1;
            goodsPriceUWorkCopy.UpdAssemblyId2 = goodsPriceUWork.UpdAssemblyId2;
            goodsPriceUWorkCopy.LogicalDeleteCode = goodsPriceUWork.LogicalDeleteCode;
            goodsPriceUWorkCopy.GoodsMakerCd = goodsPriceUWork.GoodsMakerCd;
            goodsPriceUWorkCopy.GoodsNo = goodsPriceUWork.GoodsNo;
            goodsPriceUWorkCopy.PriceStartDate = goodsPriceUWork.PriceStartDate;
            goodsPriceUWorkCopy.ListPrice = goodsPriceUWork.ListPrice;
            goodsPriceUWorkCopy.SalesUnitCost = goodsPriceUWork.SalesUnitCost;
            goodsPriceUWorkCopy.StockRate = goodsPriceUWork.StockRate;
            goodsPriceUWorkCopy.OpenPriceDiv = goodsPriceUWork.OpenPriceDiv;
            goodsPriceUWorkCopy.OfferDate = goodsPriceUWork.OfferDate;
            goodsPriceUWorkCopy.UpdateDate = goodsPriceUWork.UpdateDate;


            return goodsPriceUWorkCopy;
        }

        #endregion
    }
}
