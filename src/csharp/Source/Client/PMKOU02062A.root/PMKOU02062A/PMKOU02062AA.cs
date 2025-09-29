//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d��������ѕ\
// �v���O�����T�v   : �d��������ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d��������ѕ\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d��������ѕ\�A�N�Z�X�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.05.13</br>
    /// </remarks>
    public class SalesStockResultInfoMainAcs
    {

        #region �� Constructor
        /// <summary>
        /// �d��������ѕ\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :�d��������ѕ\�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public SalesStockResultInfoMainAcs()
        {
            this._iStockSalesResultInfoTableDB = (IStockSalesResultInfoTableDB)Broadleaf.Application.Remoting.Adapter.MediationStockSalesInfoTableDB.GetStockSalesResultInfoTableDB();
        }

        /// <summary>
        /// �d��������ѕ\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d��������ѕ\�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static SalesStockResultInfoMainAcs()
        {
            stc_Employee = null;
            stc_PrtOutSet = null;// ���[�o�͐ݒ�f�[�^�N���X
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

        #region �� Const
        const string errFlgConst = "1";
        const string normalFlgConst = "0";
        const string sign = "�A";
        const int zeroFlgConst = -1;
        const string existMsg = "�d�����쐬����Ă��܂���";
        const string masterMsg = "���L�R�[�h���o�^����Ă��܂���";
        const string countMsg = "����Ǝd���Ő��ʂ����Ⴕ�Ă��܂�";
        const string priceMsg = "����Ǝd���Ō��������Ⴕ�Ă��܂�";
        const string ct_DateFormat = "YYYY/MM/DD";
        const string ct_DateFormatForDataField = "yyyy/MM/dd";
        #endregion

        #region �� Private Member
        IStockSalesResultInfoTableDB _iStockSalesResultInfoTableDB;  //�d��������ѕ\�A�N�Z�X
        private DataSet _custAccRecDs;				    // �d��������ѕ\�f�[�^�Z�b�g
        #endregion �� Private Member

        #region �� Public Property
        /// <summary>�J�E���g�ς݂̓`�[�L�[���X�g</summary>
        private readonly IList<string> _countedSlipKeyList = new List<string>();
        /// <summary>
        /// �J�E���g�ς݂̓`�[�L�[���X�g���擾���܂��B
        /// </summary>
        /// <value>�J�E���g�ς݂̓`�[�L�[���X�g</value>
        private IList<string> CountedSlipKeyList
        {
            get { return _countedSlipKeyList; }
        }
        /// <summary> �d��������ѕ\�f�[�^�Z�b�g(�ǂݎ���p)</summary>
        /// <value>CustAccRecDs</value>               
        /// <remarks>�d��������ѕ\�f�[�^�Z�b�g(�ǂݎ���p)�擾�v���p�e�B </remarks> 
        public DataSet CustAccRecDs
        {
            get { return this._custAccRecDs; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� ���[�o�̓f�[�^�擾
        /// <summary>
        /// ���[�o�̓f�[�^�擾
        /// </summary>
        /// <param name="_stockSalesResultInfoMainCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������钠�[�o�̓f�[�^���擾����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int SearchCustAccRecMainForPdf(StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn, out string errMsg)
        {
            return this.SearchCustAccRecMainProcForPdf(_stockSalesResultInfoMainCndtn, out errMsg);
        }
        #endregion



        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �d��������ѕ\�f�[�^�擾
        /// <summary>
        /// ���[�o�͐ݒ�f�[�^�擾
        /// </summary>
        /// <param name="_stockSalesResultInfoMainCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int SearchCustAccRecMainProcForPdf(StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKOU02065EA.CreateDataTableStockSalesResultInfoAccRecMain(ref this._custAccRecDs);
                SalesStockInfoResultMainCndtnWork _salesStockInfoResultMainCndtnWork = new SalesStockInfoResultMainCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevCustAccRecMainCndtn(_stockSalesResultInfoMainCndtn, out _salesStockInfoResultMainCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retCustAccRecMainList = null;
                status = this._iStockSalesResultInfoTableDB.Search(out retCustAccRecMainList, _salesStockInfoResultMainCndtnWork);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevSalesStockMainData(_stockSalesResultInfoMainCndtn, this._custAccRecDs.Tables[PMKOU02065EA.Tbl_StockSalesResultInfoAccRecMain], (ArrayList)retCustAccRecMainList);
                        if (this._custAccRecDs.Tables[PMKOU02065EA.Tbl_StockSalesResultInfoAccRecMain].Rows.Count < 1)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�d��������ѕ\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion



        #region �� �f�[�^�W�J����
        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="_stockSalesResultInfoMainCndtn">UI���o�����N���X</param>
        /// <param name="_salesStockInfoResultMainCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s���܂��B</br>		
        /// <br>Programmer : ���痈</br>		
        /// <br>Date       : 2009.05.13</br>		
        /// </remarks>		
        private int DevCustAccRecMainCndtn(StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn, out SalesStockInfoResultMainCndtnWork _salesStockInfoResultMainCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            _salesStockInfoResultMainCndtnWork = new SalesStockInfoResultMainCndtnWork();

            try
            {
                // ��ƃR�[�h
                _salesStockInfoResultMainCndtnWork.EnterpriseCode = _stockSalesResultInfoMainCndtn.EnterpriseCode;

                // ���o�����p�����[�^�Z�b�g
                if ((null != _stockSalesResultInfoMainCndtn.CollectAddupSecCodeList)
                    && (_stockSalesResultInfoMainCndtn.CollectAddupSecCodeList.Length != 0))
                {
                    if (_stockSalesResultInfoMainCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        _salesStockInfoResultMainCndtnWork.CollectAddupSecCodeList = null;
                    }
                    else
                    {
                        _salesStockInfoResultMainCndtnWork.CollectAddupSecCodeList = _stockSalesResultInfoMainCndtn.CollectAddupSecCodeList;
                    }
                }
                else
                {
                    _salesStockInfoResultMainCndtnWork.CollectAddupSecCodeList = null;
                }

                //�d����(�J�n)
                _salesStockInfoResultMainCndtnWork.StStockDate = _stockSalesResultInfoMainCndtn.StStockDate;
                //�d����(�I��)
                _salesStockInfoResultMainCndtnWork.EdStockDate = _stockSalesResultInfoMainCndtn.EdStockDate;
                //���͓�(�J�n)
                _salesStockInfoResultMainCndtnWork.StInputDay = _stockSalesResultInfoMainCndtn.StInputDay;
                //���͓�(�I��)
                _salesStockInfoResultMainCndtnWork.EdInputDay = _stockSalesResultInfoMainCndtn.EdInputDay;
                //����
                _salesStockInfoResultMainCndtnWork.NewPageType = _stockSalesResultInfoMainCndtn.NewPageType;
                //�d����(�J�n)
                _salesStockInfoResultMainCndtnWork.StSupplierCd = _stockSalesResultInfoMainCndtn.StSupplierCd;
                //�d����(�J�n)
                _salesStockInfoResultMainCndtnWork.EdSupplierCd = _stockSalesResultInfoMainCndtn.EdSupplierCd;
                //�o�͎w��
                _salesStockInfoResultMainCndtnWork.WayToOrderType = _stockSalesResultInfoMainCndtn.WayToOrderType;
                //�݌Ɏ��w��
                _salesStockInfoResultMainCndtnWork.StockOrderDivCdType = _stockSalesResultInfoMainCndtn.StockOrderDivCdType;
                //����`�[�w��
                _salesStockInfoResultMainCndtnWork.SalesType = _stockSalesResultInfoMainCndtn.SalesType;
                //�����w��
                _salesStockInfoResultMainCndtnWork.StockUnitChngDivType = _stockSalesResultInfoMainCndtn.StockUnitChngDivType;
                //�e���`�F�b�N����
                _salesStockInfoResultMainCndtnWork.GrsProfitCheckLower = _stockSalesResultInfoMainCndtn.GrsProfitCheckLower;

                //�e���`�F�b�N2
                _salesStockInfoResultMainCndtnWork.GrossMarginSt = _stockSalesResultInfoMainCndtn.GrossMarginSt;

                //�e���`�F�b�N3
                _salesStockInfoResultMainCndtnWork.GrossMargin2Ed = _stockSalesResultInfoMainCndtn.GrossMargin2Ed;

                //�e���`�F�b�N4
                _salesStockInfoResultMainCndtnWork.GrossMargin3Ed = _stockSalesResultInfoMainCndtn.GrossMargin3Ed;

                //�e���`�F�b�N�K��
                _salesStockInfoResultMainCndtnWork.GrsProfitCheckBest = _stockSalesResultInfoMainCndtn.GrsProfitCheckBest;

                //�e���`�F�b�N���
                _salesStockInfoResultMainCndtnWork.GrsProfitCheckUpper = _stockSalesResultInfoMainCndtn.GrsProfitCheckUpper;

                //�e���`�F�b�N1(�}�[�N)
                _salesStockInfoResultMainCndtnWork.GrossMargin1Mark = _stockSalesResultInfoMainCndtn.GrossMargin1Mark;

                //�e���`�F�b�N2(�}�[�N)
                _salesStockInfoResultMainCndtnWork.GrossMargin2Mark = _stockSalesResultInfoMainCndtn.GrossMargin2Mark;

                //�e���`�F�b�N3(�}�[�N)
                _salesStockInfoResultMainCndtnWork.GrossMargin3Mark = _stockSalesResultInfoMainCndtn.GrossMargin3Mark;

                //�e���`�F�b�N4(�}�[�N)
                _salesStockInfoResultMainCndtnWork.GrossMargin4Mark = _stockSalesResultInfoMainCndtn.GrossMargin4Mark;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion



        #region �� ���[�e�[�u���f�[�^�W�J����
        /// <summary>
        /// �d��������ѕ\���[�e�[�u���f�[�^�W�J����
        /// </summary>
        /// <param name="_stockSalesResultInfoMainCndtn">UI���o�����N���X</param>
        /// <param name="custAccRecMainDt">�W�J�Ώ�DataTable</param>
        /// <param name="custAccRecMainWork">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �d��������ѕ\���[�e�[�u���f�[�^��W�J����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private void DevSalesStockMainData(StockSalesResultInfoMainCndtn _stockSalesResultInfoMainCndtn, DataTable custAccRecMainDt, ArrayList custAccRecMainWork)
        {
            DataRow dr;
            bool existSalesFlg = false;
            StockSalesResultInfoWork disAccRecmainResWork = null;
            int count = custAccRecMainWork.Count;
            for (int i = 0; i < count; i++)
            {
                disAccRecmainResWork = (StockSalesResultInfoWork)custAccRecMainWork[i];

                existSalesFlg = !(string.IsNullOrEmpty(disAccRecmainResWork.SalesSlipNum));

                dr = custAccRecMainDt.NewRow();


                //�d���`�[�ԍ�
                dr[PMKOU02065EA.Col_SupplierSlipNo] = disAccRecmainResWork.SupplierSlipNo;
                //�d���s�ԍ�
                dr[PMKOU02065EA.Col_StockRowNo] = disAccRecmainResWork.StockRowNo;

                //���_�R�[�h
                dr[PMKOU02065EA.Col_SectionCode] = disAccRecmainResWork.SectionCode;

                // ���_��
                dr[PMKOU02065EA.Col_SectionGuideNm] = GetStringToByte(disAccRecmainResWork.SectionGuideNm, 20);

                if (existSalesFlg)
                {
                    // ���Ӑ�R�[�h
                    dr[PMKOU02065EA.Col_CustomerCode] = disAccRecmainResWork.CustomerCode;

                    // ���Ӑ於
                    dr[PMKOU02065EA.Col_CustomerName] = GetStringToByte(disAccRecmainResWork.CustomerName, 20);

                    // ������t
                    dr[PMKOU02065EA.Col_SalesDate] = TDateTime.LongDateToString(ct_DateFormat, disAccRecmainResWork.SalesDate);

                    // �`�[�ԍ�
                    dr[PMKOU02065EA.Col_SalesSlipNum] = disAccRecmainResWork.SalesSlipNum;
                }

                // �敪
                //�d���݂̂̓`�[�F�d���A���オ�֘A����Ă���`�[�F����
                if (existSalesFlg)
                {
                    if (disAccRecmainResWork.SupplierSlipCd == 10)
                    {
                        dr[PMKOU02065EA.Col_KuBec] = "����";
                    }
                    else if (disAccRecmainResWork.SupplierSlipCd == 20)
                    {
                        dr[PMKOU02065EA.Col_KuBec] = "�ԕi";
                    }
                }
                else
                {
                    //dr[PMKOU02065EA.Col_KuBec] = "�d��";
                    if (disAccRecmainResWork.SupplierSlipCd == 10)
                    {
                        dr[PMKOU02065EA.Col_KuBec] = "�d��";
                    }
                    else if (disAccRecmainResWork.SupplierSlipCd == 20)
                    {
                        dr[PMKOU02065EA.Col_KuBec] = "�ԕi";
                    }
                }

                // �S����
                dr[PMKOU02065EA.Col_StockAgentName] = GetStringToByte(disAccRecmainResWork.StockAgentName, 8);

                if (existSalesFlg)
                {
                    // �󒍎�
                    dr[PMKOU02065EA.Col_FrontEmployeeNm] = GetStringToByte(disAccRecmainResWork.FrontEmployeeNm, 8);

                    // ���s��
                    dr[PMKOU02065EA.Col_SalesInputName] = GetStringToByte(disAccRecmainResWork.SalesInputName, 8);

                    // ���}�[�N�P
                    dr[PMKOU02065EA.Col_UoeRemark1] = GetStringToByte(disAccRecmainResWork.UoeRemark1,40);

                    // ���}�[�N�Q
                    dr[PMKOU02065EA.Col_UoeRemark2] = GetStringToByte(disAccRecmainResWork.UoeRemark2, 20);

                    // ���l�P
                    dr[PMKOU02065EA.Col_SlipNote] = GetStringToByte(disAccRecmainResWork.SlipNote, 40);

                    // ���l�Q
                    dr[PMKOU02065EA.Col_SlipNote2] = GetStringToByte(disAccRecmainResWork.SlipNote2, 40);

                    // ���l�R
                    dr[PMKOU02065EA.Col_SlipNote3] = GetStringToByte(disAccRecmainResWork.SlipNote3, 40);
                }

                // �d�����l
                dr[PMKOU02065EA.Col_SupplierSlipNote1] = GetStringToByte(disAccRecmainResWork.SupplierSlipNote1, 40);

                // �i��
                dr[PMKOU02065EA.Col_GoodsNo] = disAccRecmainResWork.GoodsNo;

                // �ݎ�
                //0�F��񂹁A1�F�݌�
                if (0 == disAccRecmainResWork.StockOrderDivCd)
                {
                    dr[PMKOU02065EA.Col_StockOrderDivCd] = "���";
                }
                else if (1 == disAccRecmainResWork.StockOrderDivCd)
                {
                    dr[PMKOU02065EA.Col_StockOrderDivCd] = "�݌�";
                }

                // �i��
                dr[PMKOU02065EA.Col_GoodsName] = disAccRecmainResWork.GoodsName;

                // �W�����i
                //dr[PMKOU02065EA.Col_ListPriceTaxExcFl] = disAccRecmainResWork.ListPriceTaxExcFl;
                if (disAccRecmainResWork.ListPriceTaxExcFl == 0)
                {
                    dr[PMKOU02065EA.Col_ListPriceTaxExcFl] = DBNull.Value; 
                }
                else 
                {
                    //if (disAccRecmainResWork.StockGoodsCd == 0)
                    //{
                        dr[PMKOU02065EA.Col_ListPriceTaxExcFl] = disAccRecmainResWork.ListPriceTaxExcFl;
                    //}
                    //else
                    //{
                    //    dr[PMKOU02065EA.Col_ListPriceTaxExcFl] = DBNull.Value; 
                    //}
                }

                // ����
                //dr[PMKOU02065EA.Col_StockCount] = disAccRecmainResWork.StockCount;
                if (disAccRecmainResWork.StockCount == 0)
                {
                    dr[PMKOU02065EA.Col_StockCount] = DBNull.Value; 
                }
                else 
                {
                    if (disAccRecmainResWork.StockGoodsCd == 0)
                    {
                        dr[PMKOU02065EA.Col_StockCount] = disAccRecmainResWork.StockCount;
                    }
                    else
                    {
                        dr[PMKOU02065EA.Col_StockCount] = DBNull.Value; 
                    }
                }

                long grpMoney = disAccRecmainResWork.SalesMoneyTaxExc - disAccRecmainResWork.StockPriceTaxExc;
                if (existSalesFlg)
                {
                    // ���P��
                    dr[PMKOU02065EA.Col_SalesUnPrcTaxExcFl] = disAccRecmainResWork.SalesUnPrcTaxExcFl;

                    // ������z
                    dr[PMKOU02065EA.Col_SalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;

                    // �e�����z
                    dr[PMKOU02065EA.Col_GrpMoney] = grpMoney;

                    // �e����
                    decimal tmpPct = new decimal(0.0);

                    if (disAccRecmainResWork.SalesMoneyTaxExc != 0)
                    {
                        tmpPct = decimal.Round(((Convert.ToDecimal(grpMoney) / Convert.ToDecimal(disAccRecmainResWork.SalesMoneyTaxExc)) * 100), 2, MidpointRounding.AwayFromZero);
                        dr[PMKOU02065EA.Col_GrpPct] = tmpPct;
                    }
                    double pct = Convert.ToDouble(tmpPct);
                    // �}�[�N
                    if (pct < _stockSalesResultInfoMainCndtn.GrsProfitCheckLower)
                    {
                        dr[PMKOU02065EA.Col_Maku] = _stockSalesResultInfoMainCndtn.GrossMargin1Mark;
                    }
                    else if ((pct >= _stockSalesResultInfoMainCndtn.GrsProfitCheckLower)
                           && (pct < _stockSalesResultInfoMainCndtn.GrossMargin2Ed))
                    {
                        dr[PMKOU02065EA.Col_Maku] = _stockSalesResultInfoMainCndtn.GrossMargin2Mark;
                    }
                    else if ((pct >= _stockSalesResultInfoMainCndtn.GrsProfitCheckBest)
                            && (pct < _stockSalesResultInfoMainCndtn.GrossMargin3Ed))
                    {
                        dr[PMKOU02065EA.Col_Maku] = _stockSalesResultInfoMainCndtn.GrossMargin3Mark;
                    }
                    else if (pct >= _stockSalesResultInfoMainCndtn.GrsProfitCheckUpper)
                    {
                        dr[PMKOU02065EA.Col_Maku] = _stockSalesResultInfoMainCndtn.GrossMargin4Mark;
                    }
                }



                // ���P��
                //dr[PMKOU02065EA.Col_StockUnitPriceFl] = disAccRecmainResWork.StockUnitPriceFl;
                if (disAccRecmainResWork.StockUnitPriceFl == 0) 
                {
                    dr[PMKOU02065EA.Col_StockUnitPriceFl] = DBNull.Value; 
                } else 
                {
                    dr[PMKOU02065EA.Col_StockUnitPriceFl] = disAccRecmainResWork.StockUnitPriceFl;
                }

                // �d�����z
                dr[PMKOU02065EA.Col_StockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;

                // �d����
                dr[PMKOU02065EA.Col_SupplierCd] = disAccRecmainResWork.SupplierCd;

                // �`�[�ԍ�
                dr[PMKOU02065EA.Col_PartySaleSlipNum] = disAccRecmainResWork.PartySaleSlipNum;

                // �d�����t
                dr[PMKOU02065EA.Col_StockDate] = TDateTime.LongDateToString(ct_DateFormat, disAccRecmainResWork.StockDate);

                // �d���� for sort
                dr[PMKOU02065EA.Col_SupplierCdForSort] = disAccRecmainResWork.SupplierCd;

                // �`�[�ԍ� for sort
                dr[PMKOU02065EA.Col_PartySaleSlipNumForSort] = disAccRecmainResWork.PartySaleSlipNum;

                // �d�����t for sort
                dr[PMKOU02065EA.Col_StockDateForSort] = TDateTime.LongDateToString(ct_DateFormat, disAccRecmainResWork.StockDate);

                dr[PMKOU02065EA.CT_StockConf_DailyHeaderDataField] = disAccRecmainResWork.SectionCode
                                + disAccRecmainResWork.SupplierCd.ToString("d6")
                                + GetDateTimeString(TDateTime.LongDateToDateTime(disAccRecmainResWork.StockDate), ct_DateFormatForDataField)
                                + disAccRecmainResWork.SupplierSlipNo.ToString("d9");

                // �`�[�L�[
                string slipKey = (string)dr[PMKOU02065EA.CT_StockConf_DailyHeaderDataField];

                if (disAccRecmainResWork.StockSlipCdDtl == 0)
                {
                    //�d��
                    dr[PMKOU02065EA.Col_SalesSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;
                    dr[PMKOU02065EA.Col_SalesGrpMoney] = grpMoney;
                    dr[PMKOU02065EA.Col_SalesStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;

                    // ���ɐ������`�[�͐����Ȃ�
                    if (CountedSlipKeyList.Contains(slipKey))
                    {
                        // �`�[����(�d��)
                        dr[PMKOU02065EA.Col_SalesCountNumber] = 0;
                        // �`�[����(���v)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 0;
                    }
                    else
                    {
                        // �`�[����(�d��)
                        dr[PMKOU02065EA.Col_SalesCountNumber] = 1;
                        // �`�[����(���v)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 1;

                    }

                }
                else if (disAccRecmainResWork.StockSlipCdDtl == 1)
                {
                    //�ԕi
                    dr[PMKOU02065EA.Col_RetGdsSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;
                    dr[PMKOU02065EA.Col_RetGdsGrpMoney] = grpMoney;
                    dr[PMKOU02065EA.Col_RetGdsStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;

                    // ���ɐ������`�[�͐����Ȃ�
                    if (CountedSlipKeyList.Contains(slipKey))
                    {
                        // �`�[����(�ԕi)
                        dr[PMKOU02065EA.Col_ReturnCountNumber] = 0;
                        // �`�[����(���v)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 0;
                    }
                    else
                    {
                        // �`�[����(�ԕi)
                        dr[PMKOU02065EA.Col_ReturnCountNumber] = 1;
                        // �`�[����(���v)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 1;
                    }
                }
                else if (disAccRecmainResWork.StockSlipCdDtl == 2)
                {
                    //�l��
                    if (disAccRecmainResWork.StockCount != 0.00)
                    {
                        dr[PMKOU02065EA.Col_DistSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;

                        dr[PMKOU02065EA.Col_DistGrpMoney] = grpMoney;
                        dr[PMKOU02065EA.Col_DistStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;
                    }
                    else
                    {
                        dr[PMKOU02065EA.Col_DistSalesMoneyTaxExc] = 0.00;

                        if (disAccRecmainResWork.SupplierSlipCd == 10)
                        {
                            dr[PMKOU02065EA.Col_SalesSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;
                            dr[PMKOU02065EA.Col_SalesStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;
                        }
                        else if (disAccRecmainResWork.SupplierSlipCd == 20)
                        {
                            dr[PMKOU02065EA.Col_RetGdsSalesMoneyTaxExc] = disAccRecmainResWork.SalesMoneyTaxExc;
                            dr[PMKOU02065EA.Col_RetGdsStockPriceTaxExc] = disAccRecmainResWork.StockPriceTaxExc;
                        }
                    }
                    // ���ɐ������`�[�͐����Ȃ�
                    if (CountedSlipKeyList.Contains(slipKey))
                    {
                        // �`�[����(�d��)
                        dr[PMKOU02065EA.Col_SalesCountNumber] = 0;
                        // �`�[����(�ԕi)
                        dr[PMKOU02065EA.Col_ReturnCountNumber] = 0;
                        // �`�[����(���v)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 0;
                    }
                    else
                    {
                        if (disAccRecmainResWork.SupplierSlipCd == 10)
                        {
                            // �`�[����(�d��)
                            dr[PMKOU02065EA.Col_SalesCountNumber] = 1;
                        }
                        else if (disAccRecmainResWork.SupplierSlipCd == 20)
                        {
                            // �`�[����(�ԕi)
                            dr[PMKOU02065EA.Col_ReturnCountNumber] = 1;
                        }
                        // �`�[����(���v)
                        dr[PMKOU02065EA.Col_TotleCountNumber] = 1;
                    }
                }



                if (!CountedSlipKeyList.Contains(slipKey))
                {
                    CountedSlipKeyList.Add(slipKey);
                }
                else
                {
                    // �d����
                    dr[PMKOU02065EA.Col_SupplierCd] = string.Empty;

                    // �`�[�ԍ�
                    dr[PMKOU02065EA.Col_PartySaleSlipNum] = string.Empty;

                    // �d�����t
                    dr[PMKOU02065EA.Col_StockDate] = string.Empty;
                }

                custAccRecMainDt.Rows.Add(dr);
            }
        }


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
        /// �f�[�^�ʐ��𐧌�����
        /// </summary>
        /// <param name="useName"></param>
        /// <param name="byteLength"></param>
        /// <returns>�����㕶��</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�ʐ��𐧌��������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private string GetStringToByte(string useName, int byteLength)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(useName);
            int n = 0;  //  ���Y�̊���
            int i;  //  �\���̊���
            if (bytes.GetLength(0) < byteLength)
            {
                return useName;
            }
            for (i = 0; i < bytes.GetLength(0) && n < byteLength; i++)
            {
                if (i % 2 == 0)
                {
                    n++;
                }
                else
                {
                    if (bytes[i] > 0)
                    {
                        n++;
                    }
                }

            }
            if (i % 2 == 1)
            {
                if (bytes[i] > 0)
                    i = i - 1;
                else
                    i = i + 1;
            }
            return System.Text.Encoding.Unicode.GetString(bytes, 0, i);
        }
        #endregion

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
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            retPrtOutSet = new PrtOutSet();
            errMsg = "";

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
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
                        default:
                            errMsg = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂����B";
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
        #endregion �� ���[�f�[�^�擾
        #endregion �� Private Method

    }
}
