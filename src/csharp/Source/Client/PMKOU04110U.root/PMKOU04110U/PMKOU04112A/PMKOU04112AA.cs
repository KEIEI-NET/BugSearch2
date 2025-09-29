//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d���N�Ԏ��яƉ�
// �v���O�����T�v   : �d���N�Ԏ��яƉ�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30418 ���i
// �� �� ��  2008/12/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �C �� ��  2009/01/30  �C�����e : ��Q�Ή�10714�i�����������A�c���Ɖ�̑O�񌟍��f�[�^���N���A���鏈����ǉ��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �C �� ��  2009/02/02  �C�����e : ��Q�Ή�10701�i�ԕi�z�A�l���z�̓v���X�\������悤�ɏC���j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �E �K�j
// �C �� ��  2009/02/12  �C�����e : ��Q�Ή�11087
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/06/17  �C�����e : MANTIS�y13397�z�V�X�e�����t�ɂ���đΏ۔N�x�̎��т��قȂ�̂��C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �m�u��
// �C �� ��  2010/07/20  �C�����e : �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �C �� ��  2011/03/23  �C�����e : �e�L�X�g�o�͑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���� ���T
// �� �� ��  2012/09/18  �C�����e : �d���摍���Ή�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using System.Collections.Generic;
// --- ADD 2012/09/18 ---------->>>>>
using Broadleaf.Application.Resources;
// --- ADD 2012/09/18 ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d����N�Ԏ��яƉ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����N�Ԏ��яƉ�̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30418 ���i</br>
    /// <br>Date       : 2008.12.11</br>
    /// <br>Update Note: 2009.01.30 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10714�i�����������A�c���Ɖ�̑O�񌟍��f�[�^���N���A���鏈����ǉ��j</br>
    /// <br>Update Note: 2009.02.02 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�10701�i�ԕi�z�A�l���z�̓v���X�\������悤�ɏC���j</br>
    /// <br>Update Note: 2009.02.12 30414 �E �K�j</br>
    /// <br>            �E��Q�Ή�11087</br>
    /// <br>Update Note: 2010.07.20 30414 �m�u��</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2011/03/23 liyp</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2012/09/18 FSI���� ���T</br>
    /// <br>             �d���摍���Ή�</br>
    /// </remarks>
    public partial class SuppYearResultAcs
    {

        #region �v���C�x�[�g�ϐ�

        /// <summary>�d����N�Ԏ��яƉ� �����[�gDB�擾�pMediate�N���X</summary>
        ISuppYearResultDB _iSuppYearResultDB;

        /// <summary>�d����N�Ԏ��яƉ� �f�[�^�Z�b�g</summary>
        private InventoryUpdateDataSet _dataSet;

        /// <summary>���Аݒ�擾 �A�N�Z�X�N���X</summary>
        private CompanyInfAcs _companyInfAcs;

        /// <summary>���Аݒ�擾 �f�[�^�N���X</summary>
        private CompanyInf _companyInf;

        /// <summary>���t�擾 �A�N�Z�X�N���X</summary>
        private DateGetAcs _dateGetAcs;

        /// <summary>SFUKK09042A)����f�[�^�擾 �A�N�Z�X�N���X</summary>
        private MoneyKindAcs _moneyKindAcs;

        ///// <summary>SFUKK09041E)����f�[�^�擾 �f�[�^�N���X</summary>
        //private MoneyKind _moneyKind; // DEL 2009/01/30

        /// <summary>DCKHN01060C)�d�����z�v�Z�N���X</summary>
        private StockPriceCalculate _stockCalculator;

        /// <summary>����N����</summary>
        private DateTime _companyBeginDate;

        /// <summary>�����J�n�N��</summary>
        private DateTime _this_YearMonth;

        /// <summary>���ݏ����N��</summary>
        private DateTime _addUpYearMonth;

        //private DateTime _companyEndDate;

        /// <summary>���ݏ����N��</summary>
        //private DateTime _companyNowDate;

        /// <summary>���ςŎg�p���錎��</summary>
        private int _monthCount = 0;

        /// <summary>�d�����z�[�������R�[�h�i���z�̊ۂ߂ɕK�v�jUI����n�����</summary>
        private int _stockPriceFrcProcCd = 0;

        /// <summary>DCKON09102A)�d�����z�����敪�}�X�^ �A�N�Z�X�N���X</summary>
        StockProcMoneyAcs _stockProcMoneyAcs;

        private bool _excOrtxtDiv = false;                      // �e�L�X�g�o��orExcel�o�͋敪  // ADD 2011/03/23

        ///// <summary>DCKON09101E)�d�����z�����敪�}�X�^ �f�[�^�N���X</summary>
        //StockProcMoney _stockProcMoney; // DEL 2009/01/30

        // ADD 2009/06/17 ------>>>
        // �����Z�o���W���[��
        TotalDayCalculator _totalDayCalculator;
        // ADD 2009/06/17 ------<<<

        // --- ADD 2012/09/18 ---------->>>>>
        // �d���摍���̃I�v�V�����R�[�h���p�ېݒ�p�t���O
        // true �� �d���摍���g�p����B false �� �d���摍���g�p���Ȃ��B
        private bool _optSuppSumEnable = false;
        // --- ADD 2012/09/18 ----------<<<<<
        
        #endregion // �v���C�x�[�g�ϐ�

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public SuppYearResultAcs()
        {
            this._iSuppYearResultDB = MediationSuppYearResultDB.GetSuppYearResultDB();

            this._dataSet = new InventoryUpdateDataSet();
            this._companyInfAcs = new CompanyInfAcs();

            this._moneyKindAcs = new MoneyKindAcs();
            this._stockProcMoneyAcs = new StockProcMoneyAcs();

            // ���t�擾���i
            _dateGetAcs = DateGetAcs.GetInstance();

            _totalDayCalculator = TotalDayCalculator.GetInstance(); // ADD 2009/06/17

            // --- ADD 2012/09/18 ---------->>>>>
            #region ���I�v�V�������
            this.CacheOptionInfo();
            #endregion
            // --- ADD 2012/09/18 ----------<<<<<
        }

        #endregion // �R���X�g���N�^

        #region �v���p�e�B

        /// <summary>
        /// �f�[�^�Z�b�g
        /// </summary>
        public InventoryUpdateDataSet DataSet
        {
            get { return _dataSet; }
        }

        /// <summary>
        /// �f�[�^�r���[
        /// </summary>
        public DataView DataView
        {
            get
            {
                return this._dataSet.MonthResult.DefaultView;
            }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// �f�[�^�r���[
        /// </summary>
        public DataView OutPutDataView
        {
            get
            {
                return this._dataSet.OutPutResult.DefaultView;
            }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<

        /// <summary>���ݏ����N��(�����Ώ۔N���O�N�x�̎��͔N�x�I����)</summary>
        public DateTime AddUpYearMonth
        {
            get { return this._addUpYearMonth; }
            set { this._addUpYearMonth = value; }
        }

        /// <summary>�����Ώ۔N�J�n��</summary>
        public DateTime CompanyBeginDate
        {
            get { return this._companyBeginDate; }
            set { this._companyBeginDate = value; }
        }

        /// <summary>�����Ώ۔N�J�n��</summary>
        public DateTime This_YearMonth
        {
            get { return this._this_YearMonth; }
            set { this._this_YearMonth = value; }
        }

        // ---------------ADD 2011/03/23 ------------------->>>>>
        // �e�L�X�g�o��orExcel�o�͋敪
        public bool ExcOrtxtDiv
        {
            get { return this._excOrtxtDiv; }
            set { _excOrtxtDiv = value; }
        }
        // ---------------ADD 2011/03/23 -------------------<<<<<

        /// <summary>�d�����z�[�������R�[�h</summary>
        public int StockPriceFrcProcCd
        {
            get { return this._stockPriceFrcProcCd; }
            set { this._stockPriceFrcProcCd = value; }
        }

        #endregion // �v���p�e�B

        #region ���J�֐�

        /// <summary>
        /// ���Џ��擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="financialYear">(out)��v�N�x</param>
        /// <param name="companyBeginMonth">(out)��v�N�x�J�n��</param>
        public void GetCompanyInf(string enterpriseCode, out int financialYear, out int companyBeginMonth)
        {
            financialYear = System.DateTime.Now.Year;
            companyBeginMonth = 0;

            // ���Џ��ǂݍ���
            int status = this._companyInfAcs.Read(out this._companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                financialYear = this._companyInf.FinancialYear;
                companyBeginMonth = this._companyInf.CompanyBiginMonth;
            }
        }

        /// <summary>
        /// ��v�N�x����ъ�ƃR�[�h�����v�N�x�J�n����Ԃ��܂�
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="financialYear"></param>
        /// <param name="companyBeginDate"></param>
        public bool GetCompanyBeginDate(string enterpriseCode, int financialYear, out DateTime companyBeginDate)
        {
            companyBeginDate = DateTime.MinValue;

            // ���Џ��ǂݍ���
            CompanyInf companyInf;
            int status = this._companyInfAcs.Read(out companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int year = companyInf.FinancialYear;
                int date = companyInf.CompanyBiginDate;

                if (year == financialYear)
                {
                    companyBeginDate = TDateTime.LongDateToDateTime(date);
                    return true;
                }
                else
                {
                    companyBeginDate = TDateTime.LongDateToDateTime(date).AddYears(-1);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ����R�[�h������햼���擾
        /// </summary>
        /// <param name="MoneyKindCode">����R�[�h</param>
        /// <param name="MoneyKindName">���햼</param>
        /// <param name="enterpriseCd">��ƃR�[�h</param>
        /// <returns></returns>
        public int GetMoneyKindName(int MoneyKindCode, out string MoneyKindName, string enterpriseCd)
        {
            MoneyKindName = string.Empty;

            ArrayList retList;
            int status = this._moneyKindAcs.Search(out retList, enterpriseCd);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (MoneyKind mk in retList)
                {
                    if (mk.MoneyKindCode == MoneyKindCode)
                    {
                        MoneyKindName = mk.MoneyKindName.Trim();
                        break;
                    }
                }
                
            }
            return status;
        }

        /// <summary>
        /// �N�����n���擾
        /// </summary>
        /// <param name="financialYear">�ΏۂƂȂ��v�N�x(��ʏ�̐��l)</param>
        /// <param name="baseDate">��ƂȂ�N����(��ʏ�Ŏw�肳�ꂽ���t)</param>
        public void GetDateParams(int financialYear, DateTime baseDate, string enterpriseCode)
        {
            if (baseDate == DateTime.MinValue) return;

            
            //int currentFinancialYear = this._companyInf.FinancialYear;
            //List<DateTime> startMonthTable;
            //List<DateTime> endMonthTable;
            //List<DateTime> monthList;
            //DateTime startYearDate; // DEL 2009/01/30
            //DateTime endYearDate; // DEL 2009/01/30

            // �K�v�ƂȂ����
            // �v��N��         [this._addUpYearMonth]  ���ݏ������N��
            // �����J�n�N���x   [this._this_YearMonth]
            // ����N����       [this._companyBeginDate]

            // ���ݏ����N�����擾(yyyy/MM/01)
            // DEL 2009/06/17 ------>>>
            //this._dateGetAcs.GetThisYearMonth(out this._addUpYearMonth);
            //this._addUpYearMonth = DateTime.Parse(this._addUpYearMonth.ToString("yyyy/MM") + "/01 00:00:00");
            // DEL 2009/06/17 ------<<<
            
            // ADD 2009/06/17 ------>>>
            // ���ݏ����N�������񌎎��X�V�N���Ƃ���
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            _totalDayCalculator.InitializeHisMonthly();
            _totalDayCalculator.GetHisTotalDayMonthly("", out prevTotalDay, out currentTotalDay, out prevTotalMonth, out currentTotalMonth);
            if (currentTotalMonth != DateTime.MinValue)
            {
                this._addUpYearMonth = DateTime.Parse(currentTotalMonth.ToString("yyyy/MM") + "/01 00:00:00");
            }
            else
            {
                this._dateGetAcs.GetThisYearMonth(out this._addUpYearMonth);
                this._addUpYearMonth = DateTime.Parse(this._addUpYearMonth.ToString("yyyy/MM") + "/01 00:00:00");
            }
            // ADD 2009/06/17 ------<<<
            
            // �����J�n�N���x(yyyy/MM/01)���擾
            GetCompanyBeginDate(enterpriseCode, financialYear, out this._this_YearMonth);
            this._this_YearMonth = DateTime.Parse(this._this_YearMonth.ToString("yyyy/MM") + "/01 00:00:00");

            // �N�x�̊J�n��(yyyy/MM/dd)���擾
            GetCompanyBeginDate(enterpriseCode, financialYear, out this._companyBeginDate);

            //int year;
            //int addYears;
            //DateTime startYearMonth;
            //DateTime endYearMonth;
            //// �w�肳�ꂽ�N�x�̊J�n�����擾(����͉�ʏ�̓��͓�)
            //this._dateGetAcs.GetYearMonth(baseDate, out startYearDate, out year, out startYearMonth, out endYearMonth, out this._this_YearMonth, out endYearDate);
            //this._this_YearMonth = DateTime.Parse(this._this_YearMonth.ToString("yyyy/MM") + "/01 00:00:00");

            //// �w�肳�ꂽ�N�x�̔N�x�J�n�����擾
            //this._dateGetAcs.GetYearFromMonth(baseDate, out year, out addYears, out startYearMonth, out endYearMonth);

            //// �N���x�̊J�n���E�I�������擾
            //DateTime startMonthDate;
            //DateTime endMonthDate;
            //this._dateGetAcs.GetDaysFromMonth(startYearMonth, out startMonthDate, out endMonthDate);
            //this._companyBeginDate = startMonthDate; // ����N����(�N�x�̊J�n���̊J�n��)

        }

        // --- ADD 2012/11/08 ---------->>>>>
        /// <summary>
        /// �����擾�����i���z�E�������|�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">(�o��)�O���������</param>
        /// <returns>STATUS</returns>
        public int GetTotalDayMonthlyAccPay(string enterpriseCode, string sectionCode, int supplierCd, out DateTime prevTotalDay)
        {
            sectionCode = sectionCode.Trim();

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            prevTotalDay = DateTime.MinValue;

            // �����[�g�Ăяo��
            DateTime date;
            status = _iSuppYearResultDB.SearchMonthlyAccPay(enterpriseCode, sectionCode, supplierCd, out date);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                return status;
            }

            //--------------------------------------------
            // �Z�o���ʂ��Z�b�g
            //--------------------------------------------
            prevTotalDay = date;

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }
        // --- ADD 2012/11/08 ----------<<<<<
        #endregion // ���J�֐�

        #region �f�[�^�Z�b�g��ݒ�

        /// <summary>
        /// �O���b�h�Ɏg�p����f�[�^�Z�b�g��ݒ�
        /// </summary>
        public void SetDataSetBase()
        {
            int companyBeginMonth = this._companyInf.CompanyBiginMonth;

            // ��v�N�x�e�[�u�����擾(�J�n�� - �I����[12�s])
            //this._dateGetAcs.GetFinancialYearTable((currentFinancialYear - financialYear) * -1, out startMonthTable, out endMonthTable, out monthList, out year);

            // �����̗��ݒ�
            for (int ix = 0; ix < 14; ix++)
            {
                // �����ƂɐV�K�s���쐬[12�s] + �Œ�s2�s(���v/����)
                // �����Ƃ̍s�͔N�x�J�n���`�N�x�I�����ŏ��ɍ쐬
                InventoryUpdateDataSet.MonthResultRow row = _dataSet.MonthResult.NewMonthResultRow();
                if (ix < 12)
                {
                    int iMonth = companyBeginMonth + ix;
                    if (iMonth > 12) { iMonth = iMonth - 12; }
                    row.RowTitle = iMonth.ToString() + "��";
                    row.RowMonth = iMonth;
                }
                if (ix == 12) { row.RowTitle = "���v"; }
                if (ix == 13) { row.RowTitle = "����"; }

                row.RowNo = ix;
                row.RowSetFlg = 0;
                _dataSet.MonthResult.AddMonthResultRow(row);
            }
        }

        #endregion // �f�[�^�Z�b�g��ݒ�

        #region ����

        /// <summary>
        /// �d�����яƉ�f�[�^���������A�������ʂ��f�[�^�e�[�u���ɃL���b�V�����܂��B
        /// </summary>
        /// <param name="suppYearResultCndtn">���������f�[�^�N���X</param>
        /// <returns>status</returns>
        /// <br>Update Note : 2010/09/08 �k���r</br>
        /// <br>            �E��QID:14443 �e�L�X�g�o�͑Ή�</br>
        public int Search(SuppYearResultCndtn suppYearResultCndtn)
        {
            int status = 0;

            // �f�[�^�Z�b�g�̋��z�����[���N���A
            if(!"SubMain".Equals(suppYearResultCndtn.MainDiv)) // ADD 2010/07/20
                this.ClearMonthResult2Zero();
            // �c���Ɖ�̑O�񌟍����f�[�^���N���A
            this._dataSet.AccPayResult.Clear(); // ADD 2009/01/30

            this._dataSet.OutPutResult.Rows.Clear(); // ADD 2010/07/20

            // �d�����z�����敪���X�g���擾
            ArrayList returnStockProcMoney;
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();

            status = this._stockProcMoneyAcs.Search(out returnStockProcMoney, suppYearResultCndtn.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                {
                    foreach (StockProcMoney stockProcMoney in (ArrayList)returnStockProcMoney)
                    {
                        stockProcMoneyList.Add(stockProcMoney.Clone());
                    }
                }

                this._stockCalculator = new StockPriceCalculate(stockProcMoneyList);
            }

            SuppYearResultCndtnWork suppYearResultCndtnWork = new SuppYearResultCndtnWork();
            suppYearResultCndtnWork.EnterpriseCode = suppYearResultCndtn.EnterpriseCode;        // ��ƃR�[�h
            suppYearResultCndtnWork.SectionCode = suppYearResultCndtn.SectionCode;              // ���_�R�[�h
            suppYearResultCndtnWork.SupplierCd = suppYearResultCndtn.SupplierCd;                // �d����R�[�h
            suppYearResultCndtnWork.AccDiv = suppYearResultCndtn.AccDiv;                        // ���Z��敪
            suppYearResultCndtnWork.SuppTotalDay = suppYearResultCndtn.SuppTotalDay;            // �d����̍ŏI���N����
            suppYearResultCndtnWork.CompanyBiginDate = suppYearResultCndtn.CompanyBiginDate;    // ����N����
            suppYearResultCndtnWork.This_YearMonth = suppYearResultCndtn.This_YearMonth;        // �����v��N���x
            suppYearResultCndtnWork.AddUpYearMonth = suppYearResultCndtn.AddUpYearMonth;        // ���ݏ������N��
            suppYearResultCndtnWork.SecTotalDay = suppYearResultCndtn.SecTotalDay;              // ���В���

            // --- ADD 2010/07/20-------------------------------->>>>>
            if (!String.IsNullOrEmpty(suppYearResultCndtn.MainDiv) && "SubMain".Equals(suppYearResultCndtn.MainDiv))
            {
                // ���_�R�[�hFrom�`To
                suppYearResultCndtnWork.SectionCodeSt = suppYearResultCndtn.SectionCodeSt;
                suppYearResultCndtnWork.SectionCodeEnd = suppYearResultCndtn.SectionCodeEnd;
                // �d����R�[�hFrom�`To
                suppYearResultCndtnWork.SupplierCdSt = suppYearResultCndtn.SupplierCdSt;
                suppYearResultCndtnWork.SupplierCdEnd = suppYearResultCndtn.SupplierCdEnd;
            }
            // ��ʋ敪
            suppYearResultCndtnWork.MainDiv = suppYearResultCndtn.MainDiv;
            // --- ADD 2010/07/20--------------------------------<<<<<

            object paraObj = (object)suppYearResultCndtnWork;
            object retObjResult; // �N�Ԏ���
            object retObjAccPay; // �c���Ɖ�

            // --- DEL 2012/09/18 ---------------------------->>>>>
            //status = this._iSuppYearResultDB.Search(out retObjAccPay, out retObjResult, paraObj);
            // --- DEL 2012/09/18 ----------------------------<<<<<
            // --- ADD 2012/09/18 ---------------------------->>>>>
            if (this._optSuppSumEnable)
            {
                // �d���摍���L�����̃����[�g�N���X�̃��\�b�h���R�[��
                status = this._iSuppYearResultDB.SearchSuppSum(out retObjAccPay, out retObjResult, paraObj);
            }
            else
            {
                // �������\�b�h���R�[��
                status = this._iSuppYearResultDB.Search(out retObjAccPay, out retObjResult, paraObj);
            }
            // --- ADD 2012/09/18 ----------------------------<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ���яƉ���f�[�^�Z�b�g
                ArrayList retListResult = (ArrayList)retObjResult;
                // --- ADD 2010/07/20-------------------------------->>>>>
                if (!String.IsNullOrEmpty(suppYearResultCndtn.MainDiv) && "SubMain".Equals(suppYearResultCndtn.MainDiv))
                {
                    List<SuppYearResultSuppResultWork> retTempListResult = new List<SuppYearResultSuppResultWork>();
                    foreach (SuppYearResultSuppResultWork data in retListResult)
                    {
                        // --- ADD 2010/09/08-------------------------------->>>>>
                        data.StockSectionCd = data.StockSectionCd.Trim();
                        // --- ADD 2010/09/08--------------------------------<<<<<
                        retTempListResult.Add(data);
                    }
                    Dictionary<string, List<SuppYearResultSuppResultWork>> result = ResultWorkSet(retTempListResult);

                    _dataSet.OutPutResult.Rows.Clear();
                    foreach (String key in result.Keys)
                    {
                        InventoryUpdateDataSet.OutPutResultRow row = _dataSet.OutPutResult.NewOutPutResultRow();
                        _dataSet.OutPutResult.AddOutPutResultRow(row);
                    }
                    int index = 0;
                    foreach (String key in result.Keys)
                    {
                        List<SuppYearResultSuppResultWork> tempList = (List<SuppYearResultSuppResultWork>)result[key];
                        if ((tempList.Count > 0) && (retListResult[0] is SuppYearResultSuppResultWork))
                        {
                            foreach (SuppYearResultSuppResultWork data in tempList)
                            {
                                // --- ADD 2010/09/08-------------------------------->>>>>
                                data.StockSectionCd = data.StockSectionCd.Trim();
                                // --- ADD 2010/09/08--------------------------------<<<<<
                                this.ResultWork2DataSetBuMonth(data, index);
                            }
                            index += 1;
                        }
                    }
                }
                else
                {
                // --- ADD 2010/07/20--------------------------------<<<<<
                    if ((retListResult.Count > 0) && (retListResult[0] is SuppYearResultSuppResultWork))
                    {
                        this._monthCount = 0;
                        int count = 0;
                        foreach (SuppYearResultSuppResultWork data in retListResult)
                        {
                            // --- ADD 2010/09/08-------------------------------->>>>>
                            data.StockSectionCd = data.StockSectionCd.Trim();
                            // --- ADD 2010/09/08--------------------------------<<<<<
                            this.ResultWork2DataSet(data);
                            count++;
                        }

                        // ��s��ǉ�
                        if (count < 12)
                        {
                            for (int ix = 0; ix < 12 - count; ix++)
                            {
                                this.ResultWork2DataSet(ix);
                            }
                        }
                    }

                    // �c���Ɖ���f�[�^�Z�b�g��
                    if (retObjAccPay != null)
                    {
                        SuppYearResultAccPayWork dataAccPay = (SuppYearResultAccPayWork)retObjAccPay;
                        this.AccPayWork2DataSet(dataAccPay);
                    }

                    // ���v�l�E���ϒl���Z�b�g
                    SetTotalAverage();
                    this._dataSet.MonthResult.DefaultView.Sort = this._dataSet.MonthResult.RowNoColumn.ColumnName;
                }

            }
            return status;
        }

        #endregion // ����

        // --- ADD 2010/07/20-------------------------------->>>>>
        #region Group By ����

        /// <summary>
        /// �d�����яƉ�f�[�^�e�[�u���̍s��ݒ肷��
        /// </summary>
        /// <param name="retListResult">���ʃ��X�g</param>
        /// <returns>�L�[�ƒl�̃R���N�V����</returns>
        private Dictionary<string, List<SuppYearResultSuppResultWork>> ResultWorkSet(List<SuppYearResultSuppResultWork> retListResult)
        {
            //Dictionary<string, List<SuppYearResultSuppResultWork>> result = null; // DEL 2010/10/27
            Dictionary<string, List<SuppYearResultSuppResultWork>> result = new Dictionary<string, List<SuppYearResultSuppResultWork>>();//ADD 2010/10/27
            List<SuppYearResultSuppResultWork> tempList = null;

            String tKey = "-1";
            String tempKey = "";
            if (null != retListResult && retListResult.Count > 0)
            {
                result = new Dictionary<string, List<SuppYearResultSuppResultWork>>();
                tempList = new List<SuppYearResultSuppResultWork>();
                retListResult.Sort(delegate(SuppYearResultSuppResultWork a, SuppYearResultSuppResultWork b)
                        {
                            int st = Convert.ToInt16(a.StockSectionCd.Trim()).CompareTo(Convert.ToInt16(b.StockSectionCd.Trim()));
                            if (st == 0) st = a.SupplierCd.CompareTo(b.SupplierCd);
                            return st;
                        });
            }

            foreach (SuppYearResultSuppResultWork data in retListResult)
            {
                tempKey = data.StockSectionCd.Trim() + "/" + data.SupplierCd.ToString();
                if (!tKey.Equals(tempKey))
                {
                    if (null != tempList)
                    {
                        tempList.Sort(delegate(SuppYearResultSuppResultWork a, SuppYearResultSuppResultWork b)
                        {
                            return a.AddUpYearMonth.CompareTo(b.AddUpYearMonth);
                        });
                    }
                    tempList = new List<SuppYearResultSuppResultWork>();
                    result.Add(tempKey, tempList);
                    tempList.Add(data);
                    tKey = tempKey;
                }
                else
                {
                    tempList.Add(data);
                }
            }
            if (null != tempList)
            {
                tempList.Sort(delegate(SuppYearResultSuppResultWork a, SuppYearResultSuppResultWork b)
                        {
                            return a.AddUpYearMonth.CompareTo(b.AddUpYearMonth);
                        });
            }
            return result;
        }

        #endregion
        // --- ADD 2010/07/20--------------------------------<<<<<

        #region �f�[�^�Z�b�g����

        /// <summary>
        /// �d�����яƉ�f�[�^�e�[�u���̍s���N���A���܂��B
        /// </summary>
        public void ClearDataset()
        {
            this._dataSet.MonthResult.Rows.Clear();
            this._dataSet.AccPayResult.Rows.Clear();
        }

        /// <summary>
        /// �d�����яƉ�i���яƉ�j�f�[�^�s�N���X�[���N���A�����i�����j
        /// </summary>
        private void ClearMonthResult2Zero()
        {
            for (int ix = 0; ix < _dataSet.MonthResult.Count; ix++)
            {
                // �d�����z��
                _dataSet.MonthResult[ix].St_StockPriceTaxExc = 0;
                _dataSet.MonthResult[ix].St_StockRetGoodsPrice = 0;
                _dataSet.MonthResult[ix].St_StockTotalDiscount = 0;
                _dataSet.MonthResult[ix].St_StockPriceConsTax = 0;
                _dataSet.MonthResult[ix].St_StockPriceSum = 0;

                // �����z��
                _dataSet.MonthResult[ix].Or_StockPriceTaxExc = 0;
                _dataSet.MonthResult[ix].Or_StockRetGoodsPrice = 0;
                _dataSet.MonthResult[ix].Or_StockTotalDiscount = 0;
                _dataSet.MonthResult[ix].Or_StockPriceConsTax = 0;
                _dataSet.MonthResult[ix].Or_StockPriceSum = 0;

                // ���v���z��
                _dataSet.MonthResult[ix].To_StockPriceTaxExc = 0;
                _dataSet.MonthResult[ix].To_StockRetGoodsPrice = 0;
                _dataSet.MonthResult[ix].To_StockTotalDiscount = 0;
                _dataSet.MonthResult[ix].To_StockPriceConsTax = 0;
                _dataSet.MonthResult[ix].To_StockPriceSum = 0;
            }
        }

        #endregion // �f�[�^�Z�b�g����

        #region �������ʂ��f�[�^�Z�b�g��

        /// <summary>
        /// �d�����яƉ�i���яƉ�j�������ʂ���f�[�^�e�[�u���s���쐬
        /// </summary>
        /// <param name="data">�d�����яƉ�i���яƉ�j��������</param>
        /// <br>Update Note :2011/03/23 liyp</br>
        /// <br>             �e�L�X�g�o�͏C��</br>
        private void ResultWork2DataSet(SuppYearResultSuppResultWork data)
        {
            //// ���P��
            for (int ix = 0; ix < this._dataSet.MonthResult.Count; ix++)
            {
                // ������v����s�փZ�b�g
                if (data.AddUpYearMonth.Month == _dataSet.MonthResult[ix].RowMonth)
                {
                    // ���ݏ����N��������̏ꍇ�͋�
                    if (data.AddUpYearMonth > this._addUpYearMonth)
                    {
                        // --- ADD 2010/07/20-------------------------------->>>>>
                        _dataSet.MonthResult[ix].StockSectionCd = String.Empty;    // ���_�R�[�h
                        _dataSet.MonthResult[ix].SectionGuideNm = String.Empty;    // ���_����
                        _dataSet.MonthResult[ix].SupplierCd = String.Empty;    // �d����R�[�h
                        _dataSet.MonthResult[ix].SupplierNm = String.Empty;    // �d���於��
                        // --- ADD 2010/07/20--------------------------------<<<<<

                        // --- DEL 2010/07/20-------------------------------->>>>>
                        //_dataSet.MonthResult[ix].SetSt_StockPriceTaxExcNull();
                        //_dataSet.MonthResult[ix].SetSt_StockRetGoodsPriceNull();
                        //_dataSet.MonthResult[ix].SetSt_StockTotalDiscountNull();
                        //_dataSet.MonthResult[ix].SetSt_StockPriceConsTaxNull();
                        //_dataSet.MonthResult[ix].SetSt_StockPriceSumNull();
                        //_dataSet.MonthResult[ix].SetOr_StockPriceTaxExcNull();
                        //_dataSet.MonthResult[ix].SetOr_StockRetGoodsPriceNull();
                        //_dataSet.MonthResult[ix].SetOr_StockTotalDiscountNull();
                        //_dataSet.MonthResult[ix].SetOr_StockPriceConsTaxNull();
                        //_dataSet.MonthResult[ix].SetOr_StockPriceSumNull();
                        //_dataSet.MonthResult[ix].SetTo_StockPriceTaxExcNull();
                        //_dataSet.MonthResult[ix].SetTo_StockRetGoodsPriceNull();
                        //_dataSet.MonthResult[ix].SetTo_StockTotalDiscountNull();
                        //_dataSet.MonthResult[ix].SetTo_StockPriceConsTaxNull();
                        //_dataSet.MonthResult[ix].SetTo_StockPriceSumNull();
                        // --- DEL 2010/07/20--------------------------------<<<<<

                        // --- ADD 2010/07/20-------------------------------->>>>>
                        _dataSet.MonthResult[ix].St_StockPriceConsTax = 0;
                        _dataSet.MonthResult[ix].St_StockRetGoodsPrice = 0;
                        _dataSet.MonthResult[ix].St_StockTotalDiscount = 0;
                        _dataSet.MonthResult[ix].St_StockPriceConsTax = 0;
                        _dataSet.MonthResult[ix].St_StockPriceSum = 0;
                        _dataSet.MonthResult[ix].Or_StockPriceTaxExc = 0;
                        _dataSet.MonthResult[ix].Or_StockRetGoodsPrice = 0;
                        _dataSet.MonthResult[ix].Or_StockTotalDiscount = 0;
                        _dataSet.MonthResult[ix].Or_StockPriceConsTax = 0;
                        _dataSet.MonthResult[ix].Or_StockPriceSum = 0;
                        _dataSet.MonthResult[ix].To_StockPriceTaxExc = 0;
                        _dataSet.MonthResult[ix].To_StockRetGoodsPrice = 0;
                        _dataSet.MonthResult[ix].To_StockTotalDiscount = 0;
                        _dataSet.MonthResult[ix].To_StockPriceConsTax = 0;
                        _dataSet.MonthResult[ix].To_StockPriceSum = 0;
                        // --- ADD 2010/07/20--------------------------------<<<<<
                    }
                    else
                    {
                        // ��v�N�x�J�n���`�F�b�N
                        if (data.AddUpYearMonth >= _companyBeginDate.AddDays(_companyBeginDate.Day * -1))
                        {
                            _dataSet.MonthResult[ix].RowSetFlg = TDateTime.DateTimeToLongDate(data.AddUpYearMonth);   // TODO ?

                            // �d�����z
                            _dataSet.MonthResult[ix].St_StockPriceTaxExc = _dataSet.MonthResult[ix].St_StockPriceTaxExc + data.St_StockPriceTaxExc;
                            //_dataSet.MonthResult[ix].St_StockRetGoodsPrice = _dataSet.MonthResult[ix].St_StockRetGoodsPrice + data.St_StockRetGoodsPrice; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].St_StockRetGoodsPrice = _dataSet.MonthResult[ix].St_StockRetGoodsPrice - data.St_StockRetGoodsPrice; // ADD 2009/02/02
                            //_dataSet.MonthResult[ix].St_StockTotalDiscount = _dataSet.MonthResult[ix].St_StockTotalDiscount + data.St_StockTotalDiscount; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].St_StockTotalDiscount = _dataSet.MonthResult[ix].St_StockTotalDiscount - data.St_StockTotalDiscount; // ADD 2009/02/02
                            _dataSet.MonthResult[ix].St_StockPriceConsTax = _dataSet.MonthResult[ix].St_StockPriceConsTax + data.St_StockPriceConsTax;
                            _dataSet.MonthResult[ix].St_StockPriceSum = _dataSet.MonthResult[ix].St_StockPriceSum + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.MonthResult[ix].Or_StockPriceTaxExc = _dataSet.MonthResult[ix].Or_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            //_dataSet.MonthResult[ix].Or_StockRetGoodsPrice = _dataSet.MonthResult[ix].Or_StockRetGoodsPrice + data.Or_StockRetGoodsPrice; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].Or_StockRetGoodsPrice = _dataSet.MonthResult[ix].Or_StockRetGoodsPrice - data.Or_StockRetGoodsPrice; // ADD 2009/02/02
                            //_dataSet.MonthResult[ix].Or_StockTotalDiscount = _dataSet.MonthResult[ix].Or_StockTotalDiscount + data.Or_StockTotalDiscount; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].Or_StockTotalDiscount = _dataSet.MonthResult[ix].Or_StockTotalDiscount - data.Or_StockTotalDiscount; // ADD 2009/02/02
                            _dataSet.MonthResult[ix].Or_StockPriceConsTax = _dataSet.MonthResult[ix].Or_StockPriceConsTax + data.Or_StockPriceConsTax;
                            _dataSet.MonthResult[ix].Or_StockPriceSum = _dataSet.MonthResult[ix].Or_StockPriceSum + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.MonthResult[ix].To_StockPriceTaxExc = _dataSet.MonthResult[ix].To_StockPriceTaxExc + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            //_dataSet.MonthResult[ix].To_StockRetGoodsPrice = _dataSet.MonthResult[ix].To_StockRetGoodsPrice + data.St_StockRetGoodsPrice + data.Or_StockRetGoodsPrice; // DEL 2009/02/02
                            _dataSet.MonthResult[ix].To_StockRetGoodsPrice = _dataSet.MonthResult[ix].To_StockRetGoodsPrice - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice; // ADD 2009/02/02
                            //_dataSet.MonthResult[ix].To_StockTotalDiscount = _dataSet.MonthResult[ix].To_StockTotalDiscount + data.St_StockTotalDiscount + data.Or_StockTotalDiscount; // DEL 2009/02/02
                            // 2009.03.02 30413 ���� �l���̕����𔽓]������ >>>>>>START
                            // --- CHG 2009/02/12 ��QID:11087�Ή�------------------------------------------------------>>>>>
                            //_dataSet.MonthResult[ix].To_StockTotalDiscount = _dataSet.MonthResult[ix].To_StockTotalDiscount + data.St_StockTotalDiscount - data.Or_StockTotalDiscount; // ADD 2009/02/02
                            //_dataSet.MonthResult[ix].To_StockTotalDiscount = _dataSet.MonthResult[ix].To_StockTotalDiscount + data.St_StockTotalDiscount - data.Or_StockTotalDiscount; // ADD 2009/02/02
                            _dataSet.MonthResult[ix].To_StockTotalDiscount = _dataSet.MonthResult[ix].To_StockTotalDiscount - data.St_StockTotalDiscount - data.Or_StockTotalDiscount; // ADD 2009/02/02
                            // --- CHG 2009/02/12 ��QID:11087�Ή�------------------------------------------------------<<<<<
                            // 2009.03.02 30413 ���� �l���̕����𔽓]������ <<<<<<END
                            _dataSet.MonthResult[ix].To_StockPriceConsTax = _dataSet.MonthResult[ix].To_StockPriceConsTax + data.St_StockPriceConsTax + data.Or_StockPriceConsTax;
                            _dataSet.MonthResult[ix].To_StockPriceSum = _dataSet.MonthResult[ix].To_StockPriceSum + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount 
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

        // --- ADD 2010/07/20-------------------------------->>>>>
                            _dataSet.MonthResult[ix].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.MonthResult[ix].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.MonthResult[ix].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h // DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.MonthResult[ix].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.MonthResult[ix].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.MonthResult[ix].SupplierNm = data.SupplierNm;   // �d���於��
        // --- ADD 2010/07/20--------------------------------<<<<<

                            // ���ςŎg�p���錎��
                            _monthCount++;
                        }
                    }
                }
            }
        }

        // --- ADD 2010/07/20-------------------------------->>>>>
        /// <summary>
        /// �d�����яƉ�i���яƉ�j�������ʂ���f�[�^�e�[�u���s���쐬
        /// </summary>
        /// <param name="data">�d�����яƉ�i���яƉ�j��������</param>
        /// <param name="beginMonth">index</param>
        /// <param name="index">���P��</param>
        /// <br>Update Note :2011/03/23 liyp</br>
        /// <br>             �e�L�X�g�o�͏C��</br>
        private void ResultWork2DataSetBuMonth(SuppYearResultSuppResultWork data, int index)
        {
            string month = data.AddUpYearMonth.Month.ToString();

            // ���ݏ����N��������̏ꍇ�͋�
            if (data.AddUpYearMonth > this._addUpYearMonth)
            {
                _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                // --------------------ADD 2011/03/23 ------------->>>>>
                if (_excOrtxtDiv)
                {
                    _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                }
                else
                {
                    _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                }
                // --------------------ADD 2011/03/23 -------------<<<<<
                _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                return;
            }

            // ��v�N�x�J�n���`�F�b�N
            if (data.AddUpYearMonth >= _companyBeginDate.AddDays(_companyBeginDate.Day * -1))
            {
                // ���P��
                int indexBetweenMonth = 0;
                int companyBiginMonth = this._companyInf.CompanyBiginMonth;
                if ((data.AddUpYearMonth.Month - companyBiginMonth) >= 0)
                {
                    indexBetweenMonth = data.AddUpYearMonth.Month - companyBiginMonth;
                }
                else
                {
                    indexBetweenMonth = (data.AddUpYearMonth.Month - companyBiginMonth) + 12;
                }
                switch (indexBetweenMonth)
                {
                    case 0:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_1_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_1_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_1_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_1_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_1_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_1_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_1_Month = _dataSet.OutPutResult[index].St_StockPriceSum_1_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_1_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_1_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_1_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_1_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_1_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_1_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_1_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_1_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_1_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_1_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_1_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_1_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_1_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_1_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_1_Month = _dataSet.OutPutResult[index].To_StockPriceSum_1_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 1:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_2_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_2_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_2_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_2_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_2_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_2_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_2_Month = _dataSet.OutPutResult[index].St_StockPriceSum_2_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_2_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_2_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_2_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_2_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_2_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_2_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_2_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_2_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_2_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_2_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_2_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_2_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_2_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_2_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_2_Month = _dataSet.OutPutResult[index].To_StockPriceSum_2_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 2:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_3_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_3_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_3_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_3_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_3_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_3_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_3_Month = _dataSet.OutPutResult[index].St_StockPriceSum_3_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_3_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_3_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_3_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_3_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_3_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_3_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_3_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_3_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_3_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_3_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_3_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_3_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_3_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_3_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_3_Month = _dataSet.OutPutResult[index].To_StockPriceSum_3_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 3:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_4_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_4_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_4_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_4_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_4_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_4_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_4_Month = _dataSet.OutPutResult[index].St_StockPriceSum_4_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_4_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_4_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_4_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_4_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_4_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_4_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_4_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_4_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_4_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_4_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_4_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_4_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_4_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_4_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_4_Month = _dataSet.OutPutResult[index].To_StockPriceSum_4_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 4:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_5_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_5_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_5_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_5_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_5_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_5_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_5_Month = _dataSet.OutPutResult[index].St_StockPriceSum_5_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_5_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_5_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_5_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_5_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_5_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_5_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_5_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_5_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_5_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_5_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_5_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_5_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_5_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_5_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_5_Month = _dataSet.OutPutResult[index].To_StockPriceSum_5_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 5:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_6_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_6_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_6_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_6_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_6_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_6_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_6_Month = _dataSet.OutPutResult[index].St_StockPriceSum_6_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_6_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_6_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_6_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_6_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_6_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_6_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_6_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_6_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_6_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_6_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_6_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_6_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_6_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_6_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_6_Month = _dataSet.OutPutResult[index].To_StockPriceSum_6_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 6:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_7_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_7_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_7_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_7_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_7_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_7_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_7_Month = _dataSet.OutPutResult[index].St_StockPriceSum_7_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_7_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_7_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_7_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_7_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_7_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_7_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_7_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_7_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_7_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_7_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_7_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_7_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_7_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_7_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_7_Month = _dataSet.OutPutResult[index].To_StockPriceSum_7_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 7:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_8_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_8_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_8_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_8_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_8_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_8_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_8_Month = _dataSet.OutPutResult[index].St_StockPriceSum_8_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_8_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_8_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_8_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_8_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_8_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_8_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_8_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_8_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_8_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_8_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_8_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_8_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_8_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_8_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_8_Month = _dataSet.OutPutResult[index].To_StockPriceSum_8_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 8:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_9_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_9_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_9_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_9_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_9_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_9_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_9_Month = _dataSet.OutPutResult[index].St_StockPriceSum_9_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_9_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_9_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_9_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_9_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_9_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_9_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_9_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_9_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_9_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_9_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_9_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_9_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_9_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_9_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_9_Month = _dataSet.OutPutResult[index].To_StockPriceSum_9_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 9:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_10_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_10_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_10_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_10_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_10_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_10_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_10_Month = _dataSet.OutPutResult[index].St_StockPriceSum_10_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_10_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_10_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_10_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_10_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_10_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_10_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_10_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_10_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_10_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_10_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_10_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_10_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_10_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_10_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_10_Month = _dataSet.OutPutResult[index].To_StockPriceSum_10_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 10:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_11_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_11_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_11_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_11_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_11_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_11_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_11_Month = _dataSet.OutPutResult[index].St_StockPriceSum_11_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_11_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_11_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_11_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_11_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_11_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_11_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_11_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_11_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_11_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_11_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_11_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_11_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_11_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_11_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_11_Month = _dataSet.OutPutResult[index].To_StockPriceSum_11_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }
                    case 11:
                        {
                            // �d�����z
                            _dataSet.OutPutResult[index].St_StockPriceTaxExc_12_Month = _dataSet.OutPutResult[index].St_StockPriceTaxExc_12_Month + data.St_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].St_StockRetGoodsPrice_12_Month = _dataSet.OutPutResult[index].St_StockRetGoodsPrice_12_Month - data.St_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].St_StockTotalDiscount_12_Month = _dataSet.OutPutResult[index].St_StockTotalDiscount_12_Month - data.St_StockTotalDiscount;
                            _dataSet.OutPutResult[index].St_StockPriceSum_12_Month = _dataSet.OutPutResult[index].St_StockPriceSum_12_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount;

                            // �����z
                            _dataSet.OutPutResult[index].Or_StockPriceTaxExc_12_Month = _dataSet.OutPutResult[index].Or_StockPriceTaxExc_12_Month + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_12_Month = _dataSet.OutPutResult[index].Or_StockRetGoodsPrice_12_Month - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].Or_StockTotalDiscount_12_Month = _dataSet.OutPutResult[index].Or_StockTotalDiscount_12_Month - data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].Or_StockPriceSum_12_Month = _dataSet.OutPutResult[index].Or_StockPriceSum_12_Month + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;

                            // ���v���z
                            _dataSet.OutPutResult[index].To_StockPriceTaxExc_12_Month = _dataSet.OutPutResult[index].To_StockPriceTaxExc_12_Month + data.St_StockPriceTaxExc + data.Or_StockPriceTaxExc;
                            _dataSet.OutPutResult[index].To_StockRetGoodsPrice_12_Month = _dataSet.OutPutResult[index].To_StockRetGoodsPrice_12_Month - data.St_StockRetGoodsPrice - data.Or_StockRetGoodsPrice;
                            _dataSet.OutPutResult[index].To_StockTotalDiscount_12_Month = _dataSet.OutPutResult[index].To_StockTotalDiscount_12_Month - data.St_StockTotalDiscount - data.Or_StockTotalDiscount;

                            _dataSet.OutPutResult[index].To_StockPriceSum_12_Month = _dataSet.OutPutResult[index].To_StockPriceSum_12_Month + data.St_StockPriceTaxExc + data.St_StockRetGoodsPrice + data.St_StockTotalDiscount
                                                                                                                  + data.Or_StockPriceTaxExc + data.Or_StockRetGoodsPrice + data.Or_StockTotalDiscount;
                            _dataSet.OutPutResult[index].StockSectionCd = data.StockSectionCd.ToString();   // ���_�R�[�h
                            _dataSet.OutPutResult[index].SectionGuideNm = data.SectionGuideNm.ToString();   // ���_����
                            //_dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h //DEL 2011/03/23
                            // --------------------ADD 2011/03/23 ------------->>>>>
                            if (_excOrtxtDiv)
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString().PadLeft(6, '0');   // �d����R�[�h
                            }
                            else
                            {
                                _dataSet.OutPutResult[index].SupplierCd = data.SupplierCd.ToString();   // �d����R�[�h
                            }
                            // --------------------ADD 2011/03/23 -------------<<<<<
                            _dataSet.OutPutResult[index].SupplierNm = data.SupplierNm;   // �d���於��
                            break;
                        }

                }
            }
        }
        // --- ADD 2010/07/20--------------------------------<<<<<
        
        /// <summary>
        /// �d�����яƉ�i���яƉ�j�������ʂ���f�[�^�e�[�u���s���쐬
        /// </summary>
        /// <param name="data">�d�����яƉ�i���яƉ�j��������</param>
        private void ResultWork2DataSet(int ix)
        {
            // --- ADD 2010/07/20-------------------------------->>>>>
            _dataSet.MonthResult[11 - ix].StockSectionCd = String.Empty;   // ���_�R�[�h
            _dataSet.MonthResult[11 - ix].SectionGuideNm = String.Empty;   // ���_����
            _dataSet.MonthResult[11 - ix].SupplierCd = String.Empty;    // �d����R�[�h
            _dataSet.MonthResult[11 - ix].SupplierNm = String.Empty;    // �d���於��
            // --- ADD 2010/07/20--------------------------------<<<<<

            // --- DEL 2010/07/20-------------------------------->>>>>
            //_dataSet.MonthResult[11 - ix].SetSt_StockPriceTaxExcNull();
            //_dataSet.MonthResult[11 - ix].SetSt_StockRetGoodsPriceNull();
            //_dataSet.MonthResult[11 - ix].SetSt_StockTotalDiscountNull();
            //_dataSet.MonthResult[11 - ix].SetSt_StockPriceConsTaxNull();
            //_dataSet.MonthResult[11 - ix].SetSt_StockPriceSumNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockPriceTaxExcNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockRetGoodsPriceNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockTotalDiscountNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockPriceConsTaxNull();
            //_dataSet.MonthResult[11 - ix].SetOr_StockPriceSumNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockPriceTaxExcNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockRetGoodsPriceNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockTotalDiscountNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockPriceConsTaxNull();
            //_dataSet.MonthResult[11 - ix].SetTo_StockPriceSumNull();
            // --- DEL 2010/07/20--------------------------------<<<<<

            // --- ADD 2010/07/20-------------------------------->>>>>
            _dataSet.MonthResult[11 - ix].St_StockPriceTaxExc = 0;
            _dataSet.MonthResult[11 - ix].St_StockRetGoodsPrice = 0;
            _dataSet.MonthResult[11 - ix].St_StockTotalDiscount = 0;
            _dataSet.MonthResult[11 - ix].St_StockPriceConsTax = 0;
            _dataSet.MonthResult[11 - ix].St_StockPriceSum = 0;
            _dataSet.MonthResult[11 - ix].Or_StockPriceTaxExc = 0;
            _dataSet.MonthResult[11 - ix].Or_StockRetGoodsPrice = 0;
            _dataSet.MonthResult[11 - ix].Or_StockTotalDiscount = 0;
            _dataSet.MonthResult[11 - ix].Or_StockPriceConsTax = 0;
            _dataSet.MonthResult[11 - ix].Or_StockPriceSum = 0;
            _dataSet.MonthResult[11 - ix].To_StockPriceTaxExc = 0;
            _dataSet.MonthResult[11 - ix].To_StockRetGoodsPrice = 0;
            _dataSet.MonthResult[11 - ix].To_StockTotalDiscount = 0;
            _dataSet.MonthResult[11 - ix].To_StockPriceConsTax = 0;
            _dataSet.MonthResult[11 - ix].To_StockPriceSum = 0;
            // --- ADD 2010/07/20--------------------------------<<<<<
        }

        /// <summary>
        /// �d�����яƉ�i�c���Ɖ�j�������ʂ���f�[�^�e�[�u���s���쐬
        /// </summary>
        /// <param name="data">�d�����яƉ�i�c���Ɖ�j��������</param>
        private void AccPayWork2DataSet(SuppYearResultAccPayWork data)
        {
            // �c���f�[�^��1���̂�
            DataRow row = this._dataSet.AccPayResult.NewRow();
            row[this._dataSet.AccPayResult.StockTtl3TmBfBlPayColumn.ColumnName] = data.StockTtl3TmBfBlPay;
            row[this._dataSet.AccPayResult.StockTtl2TmBfBlPayColumn.ColumnName] = data.StockTtl2TmBfBlPay;
            row[this._dataSet.AccPayResult.LastTimePaymenColumn.ColumnName] = data.LastTimePayment;
            row[this._dataSet.AccPayResult.CashePaymenColumn.ColumnName] = data.CashePayment;
            row[this._dataSet.AccPayResult.TrfrPaymentColumn.ColumnName] = data.TrfrPayment;
            row[this._dataSet.AccPayResult.CheckKPaymentColumn.ColumnName] = data.CheckKPayment;
            row[this._dataSet.AccPayResult.DraftPaymentColumn.ColumnName] = data.DraftPayment;
            row[this._dataSet.AccPayResult.OffsetPaymentColumn.ColumnName] = data.OffsetPayment;
            row[this._dataSet.AccPayResult.FundtransferPaymentColumn.ColumnName] = data.FundtransferPayment;
            row[this._dataSet.AccPayResult.EmoneyPaymentColumn.ColumnName] = data.EmoneyPayment;
            row[this._dataSet.AccPayResult.OtherPaymentColumn.ColumnName] = data.OtherPayment;
            row[this._dataSet.AccPayResult.ThisTimeFeePayNrmlColumn.ColumnName] = data.ThisTimeFeePayNrml;
            row[this._dataSet.AccPayResult.ThisTimeDisPayNrmlColumn.ColumnName] = data.ThisTimeDisPayNrml;
            row[this._dataSet.AccPayResult.StockSlipCountColumn.ColumnName] = data.StockSlipCount;
            row[this._dataSet.AccPayResult.ThisTimeStockPriceColumn.ColumnName] = data.ThisTimeStockPrice;
            // 2009.03.09 30413 ���� �ԕi�E�l���̕����𔽓] >>>>>>START
            //row[this._dataSet.AccPayResult.ThisStckPricRgdsColumn.ColumnName] = data.ThisStckPricRgds;
            //row[this._dataSet.AccPayResult.ThisStckPricDisColumn.ColumnName] = data.ThisStckPricDis;
            row[this._dataSet.AccPayResult.ThisStckPricRgdsColumn.ColumnName] = -data.ThisStckPricRgds;
            row[this._dataSet.AccPayResult.ThisStckPricDisColumn.ColumnName] = -data.ThisStckPricDis;
            // 2009.03.09 30413 ���� �ԕi�E�l���̕����𔽓] <<<<<<END
            row[this._dataSet.AccPayResult.OfsThisTimeStockColumn.ColumnName] = data.OfsThisTimeStock;
            row[this._dataSet.AccPayResult.OfsThisStockTaxColumn.ColumnName] = data.OfsThisStockTax;
            row[this._dataSet.AccPayResult.StockTotalPayBalanceColumn.ColumnName] = data.StockTotalPayBalance;
            row[this._dataSet.AccPayResult.MonthLastTimeAccPayColumn.ColumnName] = data.MonthLastTimeAccPay;
            row[this._dataSet.AccPayResult.MonthCashePaymentColumn.ColumnName] = data.MonthCashePayment;
            row[this._dataSet.AccPayResult.MonthTrfrPaymentColumn.ColumnName] = data.MonthTrfrPayment;
            row[this._dataSet.AccPayResult.MonthCheckKPaymentColumn.ColumnName] = data.MonthCheckKPayment;
            row[this._dataSet.AccPayResult.MonthDraftPaymentColumn.ColumnName] = data.MonthDraftPayment;
            row[this._dataSet.AccPayResult.MonthOffsetPaymentColumn.ColumnName] = data.MonthOffsetPayment;
            row[this._dataSet.AccPayResult.MonthFundtransferPaymentColumn.ColumnName] = data.MonthFundtransferPayment;
            row[this._dataSet.AccPayResult.MonthEmoneyPaymentColumn.ColumnName] = data.MonthEmoneyPayment;
            row[this._dataSet.AccPayResult.MonthOtherPaymentColumn.ColumnName] = data.MonthOtherPayment;
            row[this._dataSet.AccPayResult.MonthThisTimeFeePayNrmlColumn.ColumnName] = data.MonthThisTimeFeePayNrml;
            row[this._dataSet.AccPayResult.MonthThisTimeDisPayNrmlColumn.ColumnName] = data.MonthThisTimeDisPayNrml;
            row[this._dataSet.AccPayResult.MonthStockSlipCountColumn.ColumnName] = data.MonthStockSlipCount;
            row[this._dataSet.AccPayResult.MonthThisTimeStockPriceColumn.ColumnName] = data.MonthThisTimeStockPrice;
            // 2009.03.09 30413 ���� �ԕi�E�l���̕����𔽓] >>>>>>START
            //row[this._dataSet.AccPayResult.MonthThisStckPricRgdsColumn.ColumnName] = data.MonthThisStckPricRgds;
            //row[this._dataSet.AccPayResult.MonthThisStckPricDisColumn.ColumnName] = data.MonthThisStckPricDis;
            row[this._dataSet.AccPayResult.MonthThisStckPricRgdsColumn.ColumnName] = -data.MonthThisStckPricRgds;
            row[this._dataSet.AccPayResult.MonthThisStckPricDisColumn.ColumnName] = -data.MonthThisStckPricDis;
            // 2009.03.09 30413 ���� �ԕi�E�l���̕����𔽓] <<<<<<END
            row[this._dataSet.AccPayResult.MonthOfsThisTimeStockColumn.ColumnName] = data.MonthOfsThisTimeStock;
            row[this._dataSet.AccPayResult.MonthOfsThisStockTaxColumn.ColumnName] = data.MonthOfsThisStockTax;
            row[this._dataSet.AccPayResult.MonthStckTtlAccPayBalanceColumn.ColumnName] = data.MonthStckTtlAccPayBalance;
            row[this._dataSet.AccPayResult.YearStockSlipCountColumn.ColumnName] = data.YearStockSlipCount;
            row[this._dataSet.AccPayResult.YearThisTimeStockPriceColumn.ColumnName] = data.YearThisTimeStockPrice;
            // 2009.03.09 30413 ���� �ԕi�E�l���̕����𔽓] >>>>>>START
            //row[this._dataSet.AccPayResult.YearThisStckPricRgdsColumn.ColumnName] = data.YearThisStckPricRgds;
            //row[this._dataSet.AccPayResult.YearThisStckPricDisColumn.ColumnName] = data.YearThisStckPricDis;
            row[this._dataSet.AccPayResult.YearThisStckPricRgdsColumn.ColumnName] = -data.YearThisStckPricRgds;
            row[this._dataSet.AccPayResult.YearThisStckPricDisColumn.ColumnName] = -data.YearThisStckPricDis;
            // 2009.03.09 30413 ���� �ԕi�E�l���̕����𔽓] <<<<<<END
            row[this._dataSet.AccPayResult.YearOfsThisTimeStockColumn.ColumnName] = data.YearOfsThisTimeStock;
            row[this._dataSet.AccPayResult.YearOfsThisStockTaxColumn.ColumnName] = data.YearOfsThisStockTax;

            // --- ADD 2009/02/13 -------------------------------->>>>>
            // ���v�l�̎擾
            row[this._dataSet.AccPayResult.PaymentInfoSumColumn.ColumnName] = data.CashePayment
                                                                            + data.TrfrPayment
                                                                            + data.CheckKPayment
                                                                            + data.DraftPayment
                                                                            + data.OffsetPayment
                                                                            + data.FundtransferPayment
                                                                            + data.EmoneyPayment
                                                                            + data.OtherPayment
                                                                            + data.ThisTimeFeePayNrml
                                                                            + data.ThisTimeDisPayNrml;

            row[this._dataSet.AccPayResult.MonthPaymentInfoSumColumn.ColumnName] = data.MonthCashePayment
                                                                                + data.MonthTrfrPayment
                                                                                + data.MonthCheckKPayment
                                                                                + data.MonthDraftPayment
                                                                                + data.MonthOffsetPayment
                                                                                + data.MonthFundtransferPayment
                                                                                + data.MonthEmoneyPayment
                                                                                + data.MonthOtherPayment
                                                                                + data.MonthThisTimeFeePayNrml
                                                                                + data.MonthThisTimeDisPayNrml;
            // --- ADD 2009/02/13 --------------------------------<<<<<

            this._dataSet.AccPayResult.Rows.Add(row);
        }

        #endregion // �������ʂ��f�[�^�Z�b�g��

        #region ���σZ�b�g

        /// <summary>
        /// �d�����яƉ�i���яƉ�j���v�l�E���ϒl�Z�b�g����
        /// </summary>
        /// <param name="ix">������яƉ�f�[�^���v�s�ԍ�</param>
        /// <param name="target">������яƉ�f�[�^���ύs�ԍ�</param>
        /// <param name="data">�Ώۍs����</param>
        private void SetTotalAverage()
        {
            Int64 totalAmt01 = 0;
            Int64 totalAmt02 = 0;
            Int64 totalAmt03 = 0;
            Int64 totalAmt04 = 0;
            Int64 totalAmt05 = 0;
            Int64 totalAmt06 = 0;
            Int64 totalAmt07 = 0;
            Int64 totalAmt08 = 0;
            Int64 totalAmt09 = 0;
            Int64 totalAmt10 = 0;
            Int64 totalAmt11 = 0;
            Int64 totalAmt12 = 0;
            Int64 totalAmt13 = 0;
            Int64 totalAmt14 = 0;
            Int64 totalAmt15 = 0;
            //Double averageAmount = 0; // DEL 2009/01/30
            
            // --- ADD 2010/07/20-------------------------------->>>>>
            if (this._monthCount > 14)
            {
                this._monthCount = 14;
            }
            // --- ADD 2010/07/20--------------------------------<<<<<
            // �e��̍��v�l���Z�o
            for (int ix = 0; ix < this._monthCount; ix++)
            {
                totalAmt01 += _dataSet.MonthResult[ix].St_StockPriceTaxExc;
                totalAmt02 += _dataSet.MonthResult[ix].St_StockRetGoodsPrice;
                totalAmt03 += _dataSet.MonthResult[ix].St_StockTotalDiscount;
                totalAmt04 += _dataSet.MonthResult[ix].St_StockPriceConsTax;
                totalAmt05 += _dataSet.MonthResult[ix].Or_StockPriceTaxExc;
                totalAmt06 += _dataSet.MonthResult[ix].Or_StockRetGoodsPrice;
                totalAmt07 += _dataSet.MonthResult[ix].Or_StockTotalDiscount;
                totalAmt08 += _dataSet.MonthResult[ix].Or_StockPriceConsTax;
                totalAmt09 += _dataSet.MonthResult[ix].To_StockPriceTaxExc;
                totalAmt10 += _dataSet.MonthResult[ix].To_StockRetGoodsPrice;
                totalAmt11 += _dataSet.MonthResult[ix].To_StockTotalDiscount;
                totalAmt12 += _dataSet.MonthResult[ix].To_StockPriceConsTax;
                totalAmt13 += _dataSet.MonthResult[ix].St_StockPriceSum;
                totalAmt14 += _dataSet.MonthResult[ix].Or_StockPriceSum;
                totalAmt15 += _dataSet.MonthResult[ix].To_StockPriceSum;
            }
            // --- ADD 2010/07/20-------------------------------->>>>>
            _dataSet.MonthResult[12].StockSectionCd = String.Empty;   // ���_�R�[�h
            _dataSet.MonthResult[12].SectionGuideNm = String.Empty;   // ���_����
            _dataSet.MonthResult[12].SupplierCd = String.Empty;   // �d����R�[�h
            _dataSet.MonthResult[12].SupplierNm = String.Empty;   // �d���於��
            // --- ADD 2010/07/20--------------------------------<<<<<

            _dataSet.MonthResult[12].St_StockPriceTaxExc    = totalAmt01;
            _dataSet.MonthResult[12].St_StockRetGoodsPrice  = totalAmt02;
            _dataSet.MonthResult[12].St_StockTotalDiscount  = totalAmt03;
            _dataSet.MonthResult[12].St_StockPriceConsTax   = totalAmt04;
            _dataSet.MonthResult[12].St_StockPriceSum       = totalAmt13;
            _dataSet.MonthResult[12].Or_StockPriceTaxExc    = totalAmt05;
            _dataSet.MonthResult[12].Or_StockRetGoodsPrice  = totalAmt06;
            _dataSet.MonthResult[12].Or_StockTotalDiscount  = totalAmt07;
            _dataSet.MonthResult[12].Or_StockPriceConsTax   = totalAmt08;
            _dataSet.MonthResult[12].Or_StockPriceSum       = totalAmt14;
            _dataSet.MonthResult[12].To_StockPriceTaxExc    = totalAmt09;
            _dataSet.MonthResult[12].To_StockRetGoodsPrice  = totalAmt10;
            _dataSet.MonthResult[12].To_StockTotalDiscount  = totalAmt11;
            _dataSet.MonthResult[12].To_StockPriceConsTax   = totalAmt12;
            _dataSet.MonthResult[12].To_StockPriceSum       = totalAmt15;


            if (this._monthCount > 0)
            {
                //this._monthCount++;
            // --- ADD 2010/07/20-------------------------------->>>>>
                _dataSet.MonthResult[13].StockSectionCd = String.Empty;   // ���_�R�[�h
                _dataSet.MonthResult[13].SectionGuideNm = String.Empty;   // ���_����
                _dataSet.MonthResult[13].SupplierCd = String.Empty;   // �d����R�[�h
                _dataSet.MonthResult[13].SupplierNm = String.Empty;   // �d���於��
            // --- ADD 2010/07/20--------------------------------<<<<<

                // �ۂ߂͎d�����z�v�Z�敪�ɂ��i�����v�Z�j                
                _dataSet.MonthResult[13].St_StockPriceTaxExc    = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt01 / this._monthCount);
                _dataSet.MonthResult[13].St_StockRetGoodsPrice  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt02 / this._monthCount);
                _dataSet.MonthResult[13].St_StockTotalDiscount  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt03 / this._monthCount);
                _dataSet.MonthResult[13].St_StockPriceConsTax   = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt04 / this._monthCount);
                _dataSet.MonthResult[13].St_StockPriceSum       = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt13 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockPriceTaxExc    = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt05 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockRetGoodsPrice  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt06 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockTotalDiscount  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt07 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockPriceConsTax   = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt08 / this._monthCount);
                _dataSet.MonthResult[13].Or_StockPriceSum       = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt14 / this._monthCount);
                _dataSet.MonthResult[13].To_StockPriceTaxExc    = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt09 / this._monthCount);
                _dataSet.MonthResult[13].To_StockRetGoodsPrice  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt10 / this._monthCount);
                _dataSet.MonthResult[13].To_StockTotalDiscount  = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt11 / this._monthCount);
                _dataSet.MonthResult[13].To_StockPriceConsTax   = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt12 / this._monthCount);
                _dataSet.MonthResult[13].To_StockPriceSum       = this._stockCalculator.RoundStockPrice(this._stockPriceFrcProcCd, totalAmt15 / this._monthCount);
            }
        }

        #endregion // ���σZ�b�g

        // --- ADD 2012/09/18 ---------->>>>>
        #region ���I�v�V������񐧌䏈��

        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : FSI ����</br>
        /// <br>Date       : 2012/09/18</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���d�������@�\�i�ʁj�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_TextOutput);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._optSuppSumEnable = true;
            }
            else
            {
                this._optSuppSumEnable = false;
            }
            #endregion
        }
        #endregion ���I�v�V������񐧌䏈��
        // --- ADD 2012/09/18 ----------<<<<<
    }
}
