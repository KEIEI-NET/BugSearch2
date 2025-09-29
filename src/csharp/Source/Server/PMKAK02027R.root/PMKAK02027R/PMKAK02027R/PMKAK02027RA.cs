//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���|�c���ꗗ�\�i�����jDB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ���|�c���ꗗ�\�i�����j�̎��f�[�^������s���N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� �@�@�@�@�@   �쐬�S�� : FSI�y�~ �їR��
// �� �� ��  2012/09/14  �C�����e : �V�K�쐬�A�d�������@�\�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570208-00 �쐬�S�� : 3H ������
// �C �� ��  2020/04/10  �C�����e : �y���ŗ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870141-00 �쐬�S�� : 3H ����
// �C �� ��  2022/10/20  �C�����e : �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using System.Collections.Generic;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���|�c���ꗗ�\�i�����jDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|�c���ꗗ�\�i�����j�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : FSI�y�~ �їR��</br>
    /// <br>Date       : 2012/09/14</br>
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date	   : 2020/04/10</br>
    /// <br>UpdateNote : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer : 3H ����</br>
    /// <br>Date       : 2022/10/20</br>
    /// </remarks>
    [Serializable]
    public class SumAccPaymentListWorkDB : RemoteDB, ISumAccPaymentListWorkDB
    {
        private int _timeOut = 3600;//ADD 2020/04/10 �΍�@�y���ŗ��Ή�
        /// <summary>
        /// ���|�c���ꗗ�\�i�����jDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        public SumAccPaymentListWorkDB()
            :
            base("PMKAK02029D", "Broadleaf.Application.Remoting.ParamData.SumAccPaymentListResultWork", "SUPLACCPAYRF")
        {
        }

        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c���ꗗ�\�i�����j��߂��܂�
        /// </summary>
        /// <param name="sumAccPaymentListResultWork">��������</param>
        /// <param name="sumAccPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c���ꗗ�\�i�����j��߂��܂�</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        public int Search(out object sumAccPaymentListResultWork, object sumAccPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            sumAccPaymentListResultWork = null;

            ArrayList _sumAccPaymentListCndtnWorkList = sumAccPaymentListCndtnWork as ArrayList;
            SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork = null;

            if (_sumAccPaymentListCndtnWorkList == null)
            {
                _sumAccPaymentListCndtnWork = sumAccPaymentListCndtnWork as SumAccPaymentListCndtnWork;
            }
            else
            {
                if (_sumAccPaymentListCndtnWorkList.Count > 0)
                    _sumAccPaymentListCndtnWork = _sumAccPaymentListCndtnWorkList[0] as SumAccPaymentListCndtnWork;
            }

            try
            {
                status = SearchProc(out sumAccPaymentListResultWork, _sumAccPaymentListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SumAccPaymentListWorkDB.Search Exception=" + ex.Message);
                sumAccPaymentListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion  //[Search]

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔��|�c���ꗗ�\�i�����jLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="sumAccPaymentListResultWork">��������</param>
        /// <param name="_sumAccPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��|�c���ꗗ�\�i�����jLIST��S�Ė߂��܂�</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date	   : 2020/04/10</br>
        private int SearchProc(out object sumAccPaymentListResultWork, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            sumAccPaymentListResultWork = null;
            // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
            // �����t���b�O
            bool isCheckOut = true;
            // �x����O�񌎎��X�V�N����
            Dictionary<string, DateTime> payeeDateDic = new Dictionary<string, DateTime>();
            // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
            ArrayList al = new ArrayList();   //���o����

            try
            {
                //SQL������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                
                //��������
                TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();
                List<TtlDayCalcRetWork> retList = new List<TtlDayCalcRetWork>();
                TtlDayCalcParaWork para = new TtlDayCalcParaWork();
                ArrayList SupplierList = new ArrayList();
                SumAccPaymentListResultWork SupplierListWork = new SumAccPaymentListResultWork();

                //�����d����}�X�^���X�g�쐬
                status = this.SearchSuppProc(ref SupplierList, _sumAccPaymentListCndtnWork, ref sqlConnection, logicalMode);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    //�Y���f�[�^�Ȃ�
                    return status;
                }
                else if (status != 0)
                {
                    //�擾���s
                    throw new Exception("�d����}�X�^�Ǎ����s�B");
                }

                if (SupplierList.Count == 0)
                {
                    //�Y���f�[�^�Ȃ�
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                for (int i = 0; i < SupplierList.Count; i++)
                {
                    // �����`�F�b�N
                    para.EnterpriseCode = _sumAccPaymentListCndtnWork.EnterpriseCode;  //��ƃR�[�h
                    para.SectionCode = ((SumAccPaymentListResultWork)SupplierList[i]).AddUpSecCode; // (�q)���_�R�[�h
                    status = ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                    Int32 iAddUpDate = Int32.Parse(_sumAccPaymentListCndtnWork.AddUpDate.ToString("yyyyMMdd"));
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)
                    {
                        #region ��������

                        DateTime AddUpDate;

                        //���񌎎����������擾
                        if (status == 9)
                        {
                            AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate;
                        }
                        else
                        {
                            AddUpDate = DateTime.ParseExact(retList[0].TotalDay.ToString(), "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            AddUpDate = AddUpDate.AddDays(1);
                        }
                        //���|���E���|���W�v���W���[���p�����[�^�Z�b�g(���񌎎�������+1�J��)
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork2 = new SuplAccPayWork();
                        suplAccPayWork2.EnterpriseCode = _sumAccPaymentListCndtnWork.EnterpriseCode;                //��ƃR�[�h
                        // --- UPD START 3H ������ 2020/03/02 ---------->>>>>
                        //suplAccPayWork2.AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate.AddMonths(-1);            //�v��N����
                        // ����N�����̓�������̏ꍇ
                        if (_sumAccPaymentListCndtnWork.AddUpDate.Day > 27)
                        {
                            // �O���̖�����ݒ肷��
                            suplAccPayWork2.AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate.AddDays(1 - _sumAccPaymentListCndtnWork.AddUpDate.Day).AddDays(-1);
                        }
                        // ��L�ȊO�̏ꍇ
                        else
                        {
                            // �����̂܂܂őO����ݒ肷��
                            suplAccPayWork2.AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate.AddMonths(-1);
                        }
                        // --- UPD END 3H ������ 2020/03/02 ----------<<<<<
                        suplAccPayWork2.AddUpYearMonth = _sumAccPaymentListCndtnWork.AddUpYearMonth.AddMonths(-1);  //�v��N��
                        suplAccPayWork2.AddUpSecCode = ((SumAccPaymentListResultWork)SupplierList[i]).AddUpSecCode; //�v�㋒�_�R�[�h ���d����}�X�^(�����ݒ�)���X�g����
                        suplAccPayWork2.SupplierCd = ((SumAccPaymentListResultWork)SupplierList[i]).PayeeCode;      //�d����R�[�h   ���d����}�X�^(�����ݒ�)���X�g����
                        object paraObj3 = (object)suplAccPayWork2;
                        string retMsg1 = null;

                        //���|���E���|���W�v���W���[���ďo
                        status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj3, out retMsg1);

                        //�擾���ʃL���X�g
                        ArrayList SuplAccRecResult2 = new ArrayList();
                        SuplAccRecResult2.Add((SuplAccPayWork)paraObj3);

                        //���|���E���|���W�v���W���[���p�����[�^�Z�b�g
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
                        suplAccPayWork.EnterpriseCode = _sumAccPaymentListCndtnWork.EnterpriseCode;                 //��ƃR�[�h
                        suplAccPayWork.AddUpDate = _sumAccPaymentListCndtnWork.AddUpDate;                           //�v��N����
                        suplAccPayWork.AddUpYearMonth = _sumAccPaymentListCndtnWork.AddUpYearMonth;                 //�v��N��
                        suplAccPayWork.AddUpSecCode = ((SumAccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //�v�㋒�_�R�[�h ���d����}�X�^(�����ݒ�)���X�g����
                        suplAccPayWork.SupplierCd = ((SumAccPaymentListResultWork)SupplierList[i]).PayeeCode;       //�d����R�[�h   ���d����}�X�^(�����ݒ�)���X�g����

                        if (AddUpDate != _sumAccPaymentListCndtnWork.AddUpYearMonth)
                        {
                            DateTime StMonthDate = DateTime.MinValue;
                            DateTime EdMonthDate = DateTime.MinValue;
                            DateTime AddUpYearMonth = _sumAccPaymentListCndtnWork.AddUpYearMonth;
                            //���W�v�Ώۊ��Ԏ擾
                            //���Џ��擾
                            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
                            CompanyInfDB companyInfDB = new CompanyInfDB();
                            ArrayList arrayList;

                            paraCompanyInfWork.EnterpriseCode = para.EnterpriseCode;
                            companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);
                            paraCompanyInfWork = (CompanyInfWork)arrayList[0];
                            FinYearTableGenerator parafinYearTableGenerator = new FinYearTableGenerator(paraCompanyInfWork);

                            parafinYearTableGenerator.GetDaysFromMonth(AddUpYearMonth, out StMonthDate, out EdMonthDate);

                            suplAccPayWork.StMonCAddUpUpdDate = StMonthDate;             // �v��N����(�J�n)
                            suplAccPayWork.LaMonCAddUpUpdDate = StMonthDate.AddDays(-1); // �v��N����(�O�����)
                        }

                        object paraObj2 = (object)suplAccPayWork;
                        string retMsg = null;

                        //���|���E���|���W�v���W���[���ďo
                        status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj2, out retMsg);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //�擾����
                            //�擾���ʃL���X�g
                            ArrayList SuplAccRecResult = new ArrayList();
                            SuplAccRecResult.Add((SuplAccPayWork)paraObj2);

                            //�擾���ʃZ�b�g
                            for (int j = 0; j < SuplAccRecResult.Count; j++)
                            {
                                //0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:��׽��ϲŽ 5:0��ϲŽ 6:ϲŽ�̂�
                                switch (_sumAccPaymentListCndtnWork.OutMoneyDiv)
                                {
                                    case 0:  //0:�S��
                                        break;
                                    case 1:  //1:0����׽ -> 0�ȉ��̏ꍇ��continue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance < 0) continue;
                                        break;
                                    case 2:  //2:��׽�̂� -> 0�����̏ꍇ��continue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance <= 0) continue;
                                        break;
                                    case 3:  //3:0�̂� -> 0�ȊO�̏ꍇ��continue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance != 0) continue;
                                        break;
                                    case 4:  //4:��׽��ϲŽ -> 0�̏ꍇ��continue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance == 0) continue;
                                        break;
                                    case 5:  //0��ϲŽ -> 1�ȏ�̏ꍇ��continue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance > 0) continue;
                                        break;
                                    case 6:  //6:ϲŽ�̂� -> 0�ȏ�̏ꍇ��continue
                                        if (((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance >= 0) continue;
                                        break;
                                }

                                #region [���o����-�l�Z�b�g]
                                SumAccPaymentListResultWork ResultWork = new SumAccPaymentListResultWork();


                                //���_�R�[�h(�e) ���d����(����)�}�X�^����
                                ResultWork.SumAddUpSecCode = ((SumAccPaymentListResultWork)SupplierList[i]).SumAddUpSecCode;
                                //���_����(�e) �����_���ݒ�}�X�^����
                                ResultWork.SumSectionGuideSnm = ((SumAccPaymentListResultWork)SupplierList[i]).SumSectionGuideSnm;
                                //������R�[�h(�e) ���d����(����)�}�X�^����
                                ResultWork.SumPayeeCode = ((SumAccPaymentListResultWork)SupplierList[i]).SumPayeeCode;
                                //�����旪��(�e) ���d����(����)�}�X�^����
                                ResultWork.SumPayeeSnm = ((SumAccPaymentListResultWork)SupplierList[i]).SumPayeeSnm;

                                //���_�R�[�h(�q) ���d����(����)�}�X�^����
                                ResultWork.AddUpSecCode = ((SumAccPaymentListResultWork)SupplierList[i]).AddUpSecCode;
                                //���_����(�q) �����_���ݒ�}�X�^����
                                ResultWork.SectionGuideSnm = ((SumAccPaymentListResultWork)SupplierList[i]).SectionGuideSnm;
                                //������R�[�h(�q) ���d����(����)�}�X�^����
                                ResultWork.PayeeCode = ((SumAccPaymentListResultWork)SupplierList[i]).PayeeCode;
                                //�����旪��(�q) ���d����(����)�}�X�^����
                                ResultWork.PayeeSnm = ((SumAccPaymentListResultWork)SupplierList[i]).PayeeSnm;

                                //�O�����|�c
                                ResultWork.LastTimeAccPay = ((SuplAccPayWork)SuplAccRecResult[j]).LastTimeAccPay;
                                //�����x��
                                ResultWork.ThisTimePayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimePayNrml;
                                //�J�z�z
                                ResultWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeTtlBlcAcPay;
                                //�d���z
                                ResultWork.OfsThisTimeStock = ((SuplAccPayWork)SuplAccRecResult[j]).OfsThisTimeStock;
                                ResultWork.ThisTimeStockPrice = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeStockPrice;
                                //�ԕi�l��
                                ResultWork.ThisRgdsDisPric = ((SuplAccPayWork)SuplAccRecResult[j]).ThisStckPricRgds + ((SuplAccPayWork)SuplAccRecResult[j]).ThisStckPricDis;
                                //�����
                                ResultWork.OfsThisStockTax = ((SuplAccPayWork)SuplAccRecResult[j]).OfsThisStockTax;
                                //�������c��
                                ResultWork.StckTtlAccPayBalance = ((SuplAccPayWork)SuplAccRecResult[j]).StckTtlAccPayBalance;
                                //����
                                ResultWork.StockSlipCount = ((SuplAccPayWork)SuplAccRecResult[j]).StockSlipCount;
                                //�萔��
                                ResultWork.ThisTimeFeePayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeFeePayNrml;
                                //�l��
                                ResultWork.ThisTimeDisPayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeDisPayNrml;

                                // 0���у`�F�b�N
                                if (ResultWork.LastTimeAccPay == 0 && ResultWork.ThisTimeFeePayNrml ==0 &&
                                    ResultWork.ThisTimeDisPayNrml == 0 && ResultWork.OfsThisTimeStock == 0 &&
                                    ResultWork.OfsThisStockTax == 0 && ResultWork.StockSlipCount == 0 &&
                                    ResultWork.ThisTimePayNrml == 0)
                                {
                                    continue;
                                }

                                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                                // ����ŕʓ���󎚂���
                                if (_sumAccPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                                {
                                    // �����t���b�O
                                    isCheckOut = false;

                                    // �O�񌎎��X�V�N����
                                    DateTime laMonCAddUpUpdDate = ((SuplAccPayWork)SuplAccRecResult[j]).LaMonCAddUpUpdDate;

                                    // �v�㋒�_�R�[�h
                                    string addUpSecCode = ((SuplAccPayWork)SuplAccRecResult[j]).AddUpSecCode.Trim();

                                    // �x����R�[�h
                                    int payeeCode = ResultWork.PayeeCode;

                                    string payeeKey = addUpSecCode + "_" + payeeCode.ToString("000000");

                                    // �x����O�񌎎��X�V�N����
                                    if (!payeeDateDic.ContainsKey(payeeKey))
                                    {
                                        payeeDateDic.Add(payeeKey, laMonCAddUpUpdDate);
                                    }
                                }
                                // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

                                if (AddUpDate != _sumAccPaymentListCndtnWork.AddUpYearMonth)
                                {
                                    //�����������񌎎�������+1�J���̏ꍇ�́A���񌎎����������瓖���c�����擾���čČv�Z����
                                    if ((((SuplAccPayWork)SuplAccRecResult2[0]).AddUpSecCode == ResultWork.AddUpSecCode) &&
                                        (((SuplAccPayWork)SuplAccRecResult2[0]).PayeeCode == ResultWork.PayeeCode))
                                    {
                                        ResultWork.LastTimeAccPay = ((SuplAccPayWork)SuplAccRecResult2[0]).StckTtlAccPayBalance; // �O���c��

                                        // �J�z�z = �O��c�� - ����x�����z
                                        ResultWork.ThisTimeTtlBlcAcPay = (ResultWork.LastTimeAccPay) - ResultWork.ThisTimePayNrml; // �J�z�z

                                        // �������c�� = ����J�z�c�� + (���E�㍡��d�����z + ���E�㍡��d�������)
                                        ResultWork.StckTtlAccPayBalance = ResultWork.ThisTimeTtlBlcAcPay + (ResultWork.OfsThisTimeStock + ResultWork.OfsThisStockTax); // �������c��
                                    }
                                }

                                if (_sumAccPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
                                {
                                    //�x���f�[�^�擾
                                    ArrayList PaymentList = new ArrayList();
                                    status = SearchPaymentProc(ref PaymentList, SuplAccRecResult, ref sqlConnection, logicalMode);
                                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                    {
                                        //�Y���f�[�^�Ȃ� status���N���A������
                                        al.Add(ResultWork);
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                        continue;
                                    }
                                    else if (status != 0)
                                    {
                                        //�擾���s
                                        throw new Exception("�x���f�[�^�擾���s�B");
                                    }
                                    if (PaymentList.Count == 0)
                                    {
                                        //�Y���f�[�^�Ȃ� status���N���A������
                                        al.Add(ResultWork);
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                        continue;
                                    }
                                    //����
                                    ResultWork.CashPayment = ((SumAccPaymentListResultWork)PaymentList[0]).CashPayment;
                                    //�U��
                                    ResultWork.TrfrPayment = ((SumAccPaymentListResultWork)PaymentList[0]).TrfrPayment;
                                    //���؎�
                                    ResultWork.CheckPayment = ((SumAccPaymentListResultWork)PaymentList[0]).CheckPayment;
                                    //��`
                                    ResultWork.DraftPayment = ((SumAccPaymentListResultWork)PaymentList[0]).DraftPayment;
                                    //���E
                                    ResultWork.OffsetPayment = ((SumAccPaymentListResultWork)PaymentList[0]).OffsetPayment;
                                    //�����U��
                                    ResultWork.FundTransferPayment = ((SumAccPaymentListResultWork)PaymentList[0]).FundTransferPayment;
                                    //���̑�
                                    ResultWork.OthsPayment = ((SumAccPaymentListResultWork)PaymentList[0]).OthsPayment;

                                    //���A���W�v����u�����x���v���擾����Ǝ萔���������������邱�Ƃ�����̂ōă`�F�b�N���s��
                                    long ThisTimePayNrmlchek;

                                    ThisTimePayNrmlchek = ResultWork.CashPayment + ResultWork.TrfrPayment + ResultWork.CheckPayment
                                                          + ResultWork.DraftPayment + ResultWork.OffsetPayment + ResultWork.FundTransferPayment
                                                          + ResultWork.OthsPayment + ResultWork.ThisTimeFeePayNrml + ResultWork.ThisTimeDisPayNrml;

                                    if (ThisTimePayNrmlchek != ResultWork.ThisTimePayNrml)
                                    {
                                        //�����x�����ăZ�b�g
                                        ResultWork.ThisTimePayNrml = ThisTimePayNrmlchek;

                                        //�J�z�z���ăZ�b�g
                                        ResultWork.ThisTimeTtlBlcAcPay = ResultWork.LastTimeAccPay - ResultWork.ThisTimePayNrml;

                                        //�������c�����ăZ�b�g
                                        ResultWork.StckTtlAccPayBalance = ResultWork.ThisTimeTtlBlcAcPay + ResultWork.OfsThisTimeStock + ResultWork.OfsThisStockTax;
                                    }
                                }
                                #endregion  //[���o����-�l�Z�b�g]

                                al.Add(ResultWork);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                        else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                 (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            //NOT_FOUND,EOF�̏ꍇ�͎���
                        }
                        else
                        {
                            //�擾���s
                            throw new Exception("���|���E���|���W�v���W���[������̎擾�Ɏ��s�B");
                        }

                        #endregion
                    }
                    else
                    {
                        SupplierListWork = SupplierList[i] as SumAccPaymentListResultWork;
                        //���ߍ� -> �d���攃�|���z�}�X�^����擾
                        //�������s
                        status = this.SearchAccPaymentProc(ref al, _sumAccPaymentListCndtnWork, SupplierListWork,  ref sqlConnection, logicalMode);
                    }
                }

                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                if (_sumAccPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                {
                    Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic = new Dictionary<string, SuplAccPayDateInfo>();
                    // �����X�V���s�����ꍇ
                    if (isCheckOut)
                    {
                        // �����X�V�������擾���s��
                        status = SearchSuplAccPayDate(_sumAccPaymentListCndtnWork, ref suplAccPayDateDic, ref sqlConnection);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            // �Y���f�[�^�Ȃ�
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                        else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �擾���s
                            throw new Exception("�����X�V�������擾���s�B");
                        }
                    }

                    for (int k = 0; k < al.Count; k++)
                    {
                        SumAccPaymentListResultWork sumAccPaymentWork = (SumAccPaymentListResultWork)al[k];

                        // �O�񌎎��X�V�N����
                        DateTime laMonCAddUpUpdDate = DateTime.MinValue;

                        if (!isCheckOut)
                        {
                            // �O�񌎎��X�V�N�����擾
                            payeeDateDic.TryGetValue(sumAccPaymentWork.AddUpSecCode.Trim() + "_" + sumAccPaymentWork.PayeeCode.ToString("000000"), out laMonCAddUpUpdDate);
                        }

                        //�d���f�[�^�擾
                        status = SearchStockProc(ref sumAccPaymentWork, ref sqlConnection, _sumAccPaymentListCndtnWork, isCheckOut, laMonCAddUpUpdDate, suplAccPayDateDic);

                        if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                            (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                        {
                            //�Y���f�[�^�Ȃ� status���N���A������
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            continue;
                        }
                        else if (status != 0)
                        {
                            //�擾���s
                            throw new Exception("�d���f�[�^�擾���s�B");
                        }

                    }
                }
                // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SumAccPaymentListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            // --- UPD START 3H ������ 2020/04/10 ---------->>>>>
            //if (al.Count > 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            if (_sumAccPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalOFF)
            {
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // --- UPD END 3H ������ 2020/04/10 ----------<<<<<

            sumAccPaymentListResultWork = al;

            return status;
        }
        #endregion  //[SearchProc]

        #region [SearchSuppProc]
        /// <summary>
        /// �d����}�X�^(�����ݒ�)��������ɊY�����鑍���d����(�e)���������A�d����(�q)�𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_sumAccPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑����d���惊�X�g��߂��܂�</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        private int SearchSuppProc(ref ArrayList al, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlStr = new StringBuilder();
                sqlCommand = new SqlCommand("", sqlConnection);

                // �Ώۃe�[�u��
                // SUMSUPPSTRF       SUM_SUP �d����}�X�^(�����ݒ�)
                // SUPPLIERRF        SUPLER �d����}�X�^
                // SECINFOSETRF      SCINST ���_���ݒ�}�X�^

                #region [Select���쐬]
                sqlStr.Append("SELECT" + Environment.NewLine);
                sqlStr.Append("  SUM_LIST.SUMSECTIONCDRF AS SUMSECTIONCDRF" + Environment.NewLine);          //(����)���_�R�[�h
                sqlStr.Append(" ,SUM_LIST.SECTIONGUIDESNMRF AS SUMSECTIONGUIDESNMRF" + Environment.NewLine); //(����)���_����
                sqlStr.Append(" ,SUM_LIST.SUMSUPPLIERCDRF AS SUMPAYEECODERF" + Environment.NewLine);         //(����)�d����R�[�h
                sqlStr.Append(" ,SUM_LIST.SUPPLIERSNMRF AS SUMPAYEESNMRF" + Environment.NewLine);            //(����)�d���旪��
                sqlStr.Append(" ,SUM_LIST.SECTIONCODERF AS SECTIONCODERF" + Environment.NewLine);            //(�q)���_�R�[�h
                sqlStr.Append(" ,SUM_LIST.SUPPLIERCDRF AS PAYEECODERF" + Environment.NewLine);               //(�q)�d����R�[�h
                sqlStr.Append(" ,SECINFOSET.SECTIONGUIDESNMRF AS SECTIONGUIDESNMRF" + Environment.NewLine);  //(�q)���_����
                sqlStr.Append(" ,SUPPLIER.SUPPLIERSNMRF AS PAYEESNMRF" + Environment.NewLine);               //(�q)�d���旪��
                //FROM
                sqlStr.Append(" FROM" + Environment.NewLine);
                sqlStr.Append(" (" + Environment.NewLine);
                sqlStr.Append("     SELECT" + Environment.NewLine);
                sqlStr.Append("          SUM_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("         ,SUM_SUP.SUMSECTIONCDRF" + Environment.NewLine);
                sqlStr.Append("         ,SECINFOSET.SECTIONGUIDESNMRF" + Environment.NewLine);
                sqlStr.Append("         ,SUM_SUP.SUMSUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("         ,SUM_SUP.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append("         ,SUM_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("         ,SUPPLIER.SUPPLIERSNMRF" + Environment.NewLine);
                sqlStr.Append("         FROM" + Environment.NewLine);
                sqlStr.Append("             SUMSUPPSTRF AS SUM_SUP" + Environment.NewLine);
                sqlStr.Append("             LEFT JOIN" + Environment.NewLine);
                sqlStr.Append("             (" + Environment.NewLine);
                sqlStr.Append("                 SELECT" + Environment.NewLine);
                sqlStr.Append("                      SCINST.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("                     ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                sqlStr.Append("                     ,SCINST.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append("                 FROM" + Environment.NewLine);
                sqlStr.Append("                     SECINFOSETRF AS SCINST" + Environment.NewLine);
                sqlStr.Append("                 GROUP BY" + Environment.NewLine);
                sqlStr.Append("                      SCINST.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("                     ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                sqlStr.Append("                     ,SCINST.SECTIONCODERF" + Environment.NewLine);
                sqlStr.Append("             ) AS SECINFOSET" + Environment.NewLine);
                sqlStr.Append("             ON   SECINFOSET.ENTERPRISECODERF = SUM_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("             AND  SECINFOSET.SECTIONCODERF = SUM_SUP.SUMSECTIONCDRF" + Environment.NewLine);
                sqlStr.Append("             LEFT JOIN" + Environment.NewLine);
                sqlStr.Append("             (" + Environment.NewLine);
                sqlStr.Append("                 SELECT" + Environment.NewLine);
                sqlStr.Append("                      PARENT_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("                     ,PARENT_SUP.SUPPLIERSNMRF" + Environment.NewLine);
                sqlStr.Append("                     ,PARENT_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("                 FROM" + Environment.NewLine);
                sqlStr.Append("                     SUPPLIERRF AS PARENT_SUP" + Environment.NewLine);
                sqlStr.Append("                 GROUP BY" + Environment.NewLine);
                sqlStr.Append("                      PARENT_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("                     ,PARENT_SUP.SUPPLIERSNMRF" + Environment.NewLine);
                sqlStr.Append("                     ,PARENT_SUP.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("             ) AS SUPPLIER" + Environment.NewLine);
                sqlStr.Append("             ON	SUPPLIER.ENTERPRISECODERF = SUM_SUP.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("             AND	SUPPLIER.SUPPLIERCDRF = SUM_SUP.SUMSUPPLIERCDRF" + Environment.NewLine);

                #region [WHERE��]
                sqlStr.Append(" WHERE" + Environment.NewLine);

                //��ƃR�[�h
                sqlStr.Append(" SUM_SUP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sumAccPaymentListCndtnWork.EnterpriseCode);

                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    sqlStr.Append(" AND SUM_SUP.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    sqlStr.Append(" AND SUM_SUP.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //�������_�R�[�h
                if (_sumAccPaymentListCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _sumAccPaymentListCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        sqlStr.Append(" AND SUM_SUP.SUMSECTIONCDRF IN (" + sectionCodestr + ") ");
                    }
                    sqlStr.Append(Environment.NewLine);
                }

                //�����d����R�[�h
                if (_sumAccPaymentListCndtnWork.St_PayeeCode != 0)
                {
                    sqlStr.Append(" AND SUM_SUP.SUMSUPPLIERCDRF>=@ST_SUPPLIERCD" + Environment.NewLine);
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(_sumAccPaymentListCndtnWork.St_PayeeCode);
                }
                if (_sumAccPaymentListCndtnWork.St_PayeeCode != 999999)
                {
                    sqlStr.Append(" AND SUM_SUP.SUMSUPPLIERCDRF<=@ED_SUPPLIERCD" + Environment.NewLine);
                    SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_sumAccPaymentListCndtnWork.Ed_PayeeCode);
                }
                #endregion  //[WHERE��]

                sqlStr.Append(" ) AS SUM_LIST" + Environment.NewLine);

                //JOIN
                // �d����}�X�^(�����p)
                sqlStr.Append(" LEFT JOIN SUPPLIERRF AS SUPPLIER" + Environment.NewLine);
                sqlStr.Append(" ON  SUPPLIER.ENTERPRISECODERF = SUM_LIST.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(" AND SUPPLIER.SUPPLIERCDRF = SUM_LIST.SUPPLIERCDRF" + Environment.NewLine);

                //���_���ݒ�}�X�^(�����p)
                sqlStr.Append(" LEFT JOIN SECINFOSETRF SECINFOSET" + Environment.NewLine);
                sqlStr.Append(" ON  SECINFOSET.ENTERPRISECODERF = SUM_LIST.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append(" AND SECINFOSET.SECTIONCODERF = SUM_LIST.SECTIONCODERF" + Environment.NewLine);

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = sqlStr.ToString();

                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    SumAccPaymentListResultWork ResultWork = new SumAccPaymentListResultWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.SumAddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECTIONCDRF"));
                    ResultWork.SumSectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECTIONGUIDESNMRF"));
                    ResultWork.SumPayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMPAYEECODERF"));
                    ResultWork.SumPayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMPAYEESNMRF"));
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                    #endregion

                    al.Add(ResultWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SumAccPaymentListWorkDB.SearchSuppProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[SearchSuppProc]

        #region [SearchPaymentProc]
        /// <summary>
        /// �����߂̎x���f�[�^���擾���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="suplAccPayWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����߂̎x���f�[�^���擾���܂�</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2012/11/07</br>
        private int SearchPaymentProc(ref ArrayList al, ArrayList suplAccPayWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // PAYMENTSLPRF      PAYSLP �x���`�[�}�X�^
                // PAYMENTDTLRF      PAYDTL �x�����׃f�[�^

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=51 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS CASHPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=52 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=53 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=54 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=56 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=59 THEN PAYDTL.PAYMENTRF ELSE 0 END)) AS FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "  ,(SUM(PAYDTL.PAYMENTRF)" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=51 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=52 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=53 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=54 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=56 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN PAYDTL.MONEYKINDCODERF=59 THEN PAYDTL.PAYMENTRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   ) AS OTHSPAYMENT" + Environment.NewLine;
                //FROM
                selectTxt += " FROM PAYMENTSLPRF AS PAYSLP" + Environment.NewLine;
                //JOIN
                selectTxt += " INNER JOIN PAYMENTDTLRF AS PAYDTL" + Environment.NewLine;
                selectTxt += " ON  PAYDTL.ENTERPRISECODERF=PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND PAYDTL.SUPPLIERFORMALRF=PAYSLP.SUPPLIERFORMALRF" + Environment.NewLine;
                selectTxt += " AND PAYDTL.PAYMENTSLIPNORF=PAYSLP.PAYMENTSLIPNORF" + Environment.NewLine;
                selectTxt += " AND PAYDTL.LOGICALDELETECODERF=0" + Environment.NewLine;
                //WHERE
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      PAYSLP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.DEBITNOTEDIVRF=0" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.LOGICALDELETECODERF=0" + Environment.NewLine;
                selectTxt += "  AND (PAYSLP.ADDUPADATERF<=@FINDADDUPDATE AND PAYSLP.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                //GROUP BY
                selectTxt += " GROUP BY" + Environment.NewLine;
                selectTxt += "   PAYSLP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,PAYSLP.PAYEECODERF" + Environment.NewLine;
                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSupplierCd = sqlCommand.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);
                SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(((SuplAccPayWork)suplAccPayWork[0]).EnterpriseCode);
                findParaSupplierCd.Value = SqlDataMediator.SqlSetInt32(((SuplAccPayWork)suplAccPayWork[0]).SupplierCd);
                findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(((SuplAccPayWork)suplAccPayWork[0]).PayeeCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(((SuplAccPayWork)suplAccPayWork[0]).AddUpSecCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(((SuplAccPayWork)suplAccPayWork[0]).AddUpDate);
                if (((SuplAccPayWork)suplAccPayWork[0]).LaMonCAddUpUpdDate == DateTime.MinValue)
                    findParaLastTimeAddUpDate.Value = 20000101;
                else
                    findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(((SuplAccPayWork)suplAccPayWork[0]).LaMonCAddUpUpdDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    SumAccPaymentListResultWork ResultWork = new SumAccPaymentListResultWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.CashPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHPAYMENT"));
                    ResultWork.TrfrPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRPAYMENT"));
                    ResultWork.CheckPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKPAYMENT"));
                    ResultWork.DraftPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTPAYMENT"));
                    ResultWork.OffsetPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETPAYMENT"));
                    ResultWork.FundTransferPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERPAYMENT"));
                    ResultWork.OthsPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHSPAYMENT"));
                    #endregion

                    al.Add(ResultWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchPaymentProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[SearchPaymentProc]

        #region [SearchAccPaymentProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c���ꗗ�\�i�����j��߂��܂�
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_sumAccPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="SupplierListWork">SupplierListWork</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c���ꗗ�\��߂��܂�</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        private int SearchAccPaymentProc(ref ArrayList al, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, SumAccPaymentListResultWork SupplierListWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                StringBuilder sqlStr = new StringBuilder();
                sqlCommand = new SqlCommand("", sqlConnection);

                // �Ώۃe�[�u��
                // SUPLACCPAYRF      SUPPAY �d���攃�|���z�}�X�^
                // ACALCPAYTOTALRF   ACAPAY ���|�x���W�v�f�[�^
                // SECINFOSETRF      SCINST ���_���ݒ�}�X�^

                #region [Select���쐬]
                sqlStr.Append("SELECT" + Environment.NewLine);
                sqlStr.Append("   SUPPAY.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("  ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.PAYEESNMRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.LASTTIMEACCPAYRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMETTLBLCACPAYRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.OFSTHISTIMESTOCKRF" + Environment.NewLine);
                sqlStr.Append("  ,(SUPPAY.THISSTCKPRICRGDSRF+SUPPAY.THISSTCKPRICDISRF)" + Environment.NewLine);
                sqlStr.Append("   AS THISRGDSDISPRIC" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.OFSTHISSTOCKTAXRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.STCKTTLACCPAYBALANCERF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.STOCKSLIPCOUNTRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMEFEEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMEDISPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.CASHPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.TRFRPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.CHECKPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.DRAFTPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.OFFSETPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.OTHSPAYMENT" + Environment.NewLine);
                sqlStr.Append("  ,SUPPAY.THISTIMESTOCKPRICERF" + Environment.NewLine);
                //FROM
                sqlStr.Append(" FROM" + Environment.NewLine);
                sqlStr.Append(" (" + Environment.NewLine);

                #region [�f�[�^���o���C��Query]
                //�d���攃�|���z�}�X�^
                sqlStr.Append("  SELECT" + Environment.NewLine);
                sqlStr.Append("    SUPPAYSUB.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.PAYEESNMRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.LASTTIMEACCPAYRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMETTLBLCACPAYRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.OFSTHISTIMESTOCKRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISSTCKPRICRGDSRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISSTCKPRICDISRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.OFSTHISSTOCKTAXRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.STCKTTLACCPAYBALANCERF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.STOCKSLIPCOUNTRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMEFEEPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMEDISPAYNRMLRF" + Environment.NewLine);
                sqlStr.Append("   ,SUPPAYSUB.THISTIMESTOCKPRICERF" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.CASHPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.TRFRPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.CHECKPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.DRAFTPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.OFFSETPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,ACAPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine);
                sqlStr.Append("   ,(ACAPAY.OTHSPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.CASHPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.TRFRPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.CHECKPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.DRAFTPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.OFFSETPAYMENT" + Environment.NewLine);
                sqlStr.Append("    -ACAPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ) AS OTHSPAYMENT" + Environment.NewLine);
                sqlStr.Append(" FROM SUPLACCPAYRF AS SUPPAYSUB" + Environment.NewLine);

                //���|�x���W�v�f�[�^
                sqlStr.Append("  LEFT JOIN" + Environment.NewLine);
                sqlStr.Append("  (" + Environment.NewLine);
                sqlStr.Append("   SELECT" + Environment.NewLine);
                sqlStr.Append("     ACAPAYSUB.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.ADDUPDATERF" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=51 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS CASHPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=52 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS TRFRPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=53 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS CHECKPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=54 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS DRAFTPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=56 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS OFFSETPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=59 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS FUNDTRANSFERPAYMENT" + Environment.NewLine);
                sqlStr.Append("    ,SUM(ACAPAYSUB.PAYMENTRF) AS OTHSPAYMENT" + Environment.NewLine);
                sqlStr.Append("   FROM ACALCPAYTOTALRF AS ACAPAYSUB" + Environment.NewLine);
                sqlStr.Append("   GROUP BY" + Environment.NewLine);
                sqlStr.Append("     ACAPAYSUB.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.SUPPLIERCDRF" + Environment.NewLine);
                sqlStr.Append("    ,ACAPAYSUB.ADDUPDATERF" + Environment.NewLine);
                sqlStr.Append("  ) AS ACAPAY" + Environment.NewLine);
                sqlStr.Append("  ON  ACAPAY.ENTERPRISECODERF=SUPPAYSUB.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("  AND ACAPAY.ADDUPSECCODERF=SUPPAYSUB.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append("  AND ACAPAY.PAYEECODERF=SUPPAYSUB.PAYEECODERF" + Environment.NewLine);
                sqlStr.Append("  AND ACAPAY.ADDUPDATERF=SUPPAYSUB.ADDUPDATERF" + Environment.NewLine);

                //WHERE���̍쐬
                sqlStr.Append(MakeWhereString(ref sqlCommand, _sumAccPaymentListCndtnWork, SupplierListWork, logicalMode));
                #endregion  //[�f�[�^���o���C��Query]

                sqlStr.Append(" ) AS SUPPAY" + Environment.NewLine);

                #region [JOIN]
                //���_���ݒ�}�X�^(�q)
                sqlStr.Append(" LEFT JOIN SECINFOSETRF SCINST ON" + Environment.NewLine);
                sqlStr.Append(" (SCINST.ENTERPRISECODERF=SUPPAY.ENTERPRISECODERF" + Environment.NewLine);
                sqlStr.Append("    AND SCINST.SECTIONCODERF=SUPPAY.ADDUPSECCODERF" + Environment.NewLine);
                sqlStr.Append(" )" + Environment.NewLine);
                #endregion  //[JOIN]

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = sqlStr.ToString();

                sqlCommand.CommandTimeout = 600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRsltWork(ref myReader, _sumAccPaymentListCndtnWork, SupplierListWork));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SumAccPaymentListWorkDB.SearchAccPaymentProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            return status;
        }
        #endregion  //[SearchAccPaymentProc]

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_sumAccPaymentListCndtnWork">���������i�[�N���X</param>
        /// <param name="SupplierListWork">SupplierListWork</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>���|�c���������o��SQL������</returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, SumAccPaymentListResultWork SupplierListWork,  ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            StringBuilder retString = new StringBuilder();
            retString.Append(" WHERE" + Environment.NewLine);

            //��ƃR�[�h
            retString.Append(" SUPPAYSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine);
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sumAccPaymentListCndtnWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retString.Append(" AND SUPPAYSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retString.Append(" AND SUPPAYSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //�W�v���R�[�h�݂̂�ΏۂƂ���(�d����R�[�h=0�̂ݑΏ�)
            retString.Append(" AND SUPPAYSUB.SUPPLIERCDRF=0" + Environment.NewLine);

            //���_�R�[�h
           if (SupplierListWork.AddUpSecCode != null)
            {
                retString.Append(" AND SUPPAYSUB.ADDUPSECCODERF = @ADDUPSECCODE");
                SqlParameter paraAddupsecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddupsecCode.Value = SqlDataMediator.SqlSetString(SupplierListWork.AddUpSecCode);
            }

            //�Ώ۔N��
            if (_sumAccPaymentListCndtnWork.AddUpYearMonth != DateTime.MinValue)
            {
                retString.Append(" AND SUPPAYSUB.ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine);
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_sumAccPaymentListCndtnWork.AddUpYearMonth);
            }

            //�x����R�[�h
           if (SupplierListWork.PayeeCode != 0)
            {
                retString.Append(" AND SUPPAYSUB.PAYEECODERF=@PAYEECODE" + Environment.NewLine);
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(SupplierListWork.PayeeCode);
            }

            //0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:��׽��ϲŽ 5:0��ϲŽ 6:ϲŽ�̂�
            switch (_sumAccPaymentListCndtnWork.OutMoneyDiv)
            {
                case 0:
                    break;
                case 1:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF>=0" + Environment.NewLine);
                    break;
                case 2:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF>0" + Environment.NewLine);
                    break;
                case 3:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF=0" + Environment.NewLine);
                    break;
                case 4:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF!=0" + Environment.NewLine);
                    break;
                case 5:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF<=0" + Environment.NewLine);
                    break;
                case 6:
                    retString.Append(" AND SUPPAYSUB.STCKTTLACCPAYBALANCERF<0" + Environment.NewLine);
                    break;
            }
            retString.Append("AND ( SUPPAYSUB.LASTTIMEACCPAYRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.THISTIMEFEEPAYNRMLRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.THISTIMEDISPAYNRMLRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.OFSTHISTIMESTOCKRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.OFSTHISSTOCKTAXRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.STOCKSLIPCOUNTRF != 0" + Environment.NewLine);
            retString.Append("      OR SUPPAYSUB.THISTIMEPAYNRMLRF != 0)" + Environment.NewLine);
            #endregion  //WHERE���쐬

            return retString.ToString();
        }
        #endregion  //[WHERE�吶������]

        #region [���|�c���ꗗ�\�i�����j���o���ʃN���X�i�[����]
        /// <summary>
        /// ���|�c���ꗗ�\�i�����j���o���ʃN���X�i�[���� Reader �� SumAccPaymentListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="_sumAccPaymentListCndtnWork">SumAccPaymentListResultWork</param>
        /// <param name="SupplierListWork">SupplierListWork</param>
        /// <returns>SumAccPaymentListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private SumAccPaymentListResultWork CopyToRsltWork(ref SqlDataReader myReader, SumAccPaymentListCndtnWork _sumAccPaymentListCndtnWork, SumAccPaymentListResultWork SupplierListWork)
        {
            SumAccPaymentListResultWork ResultWork = new SumAccPaymentListResultWork();

            #region [���o����-�l�Z�b�g]
            //�������_�E�����x����͑����d����}�X�^�i�荞�ݎ��Ɍ��������l���Z�b�g
            ResultWork.SumAddUpSecCode = SupplierListWork.SumAddUpSecCode;
            ResultWork.SumSectionGuideSnm = SupplierListWork.SumSectionGuideSnm;
            ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.SumPayeeCode = SupplierListWork.SumPayeeCode;
            ResultWork.SumPayeeSnm = SupplierListWork.SumPayeeSnm;
            ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
            ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
            ResultWork.LastTimeAccPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCPAYRF"));
            ResultWork.ThisTimePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEPAYNRMLRF"));
            ResultWork.ThisTimeTtlBlcAcPay = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACPAYRF"));
            ResultWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));
            ResultWork.ThisRgdsDisPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISRGDSDISPRIC"));
            ResultWork.OfsThisStockTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSTOCKTAXRF"));
            ResultWork.StckTtlAccPayBalance = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKTTLACCPAYBALANCERF"));
            ResultWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNTRF"));
            ResultWork.ThisTimeFeePayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEPAYNRMLRF"));
            ResultWork.ThisTimeDisPayNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISPAYNRMLRF"));
            ResultWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));
            if (_sumAccPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
            {
                ResultWork.CashPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHPAYMENT"));
                ResultWork.TrfrPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRPAYMENT"));
                ResultWork.CheckPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKPAYMENT"));
                ResultWork.DraftPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTPAYMENT"));
                ResultWork.OffsetPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETPAYMENT"));
                ResultWork.FundTransferPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERPAYMENT"));
                ResultWork.OthsPayment = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHSPAYMENT"));
            }
            #endregion  //[���o����-�l�Z�b�g]

            return ResultWork;
        }
        #endregion  //[���|�c���ꗗ�\�i�����j���o���ʃN���X�i�[����]

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : FSI�y�~ �їR��</br>
        /// <br>Date       : 2012/09/14</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        #region [SearchSuplAccPayDate]
        /// <summary>
        /// �v��N�����擾
        /// </summary>
        /// <param name="accPaymentListCndtnWork">���|�c���ꗗ�\���o����</param>
        /// <param name="suplAccPayDateDic">�x���斈�̌����X�V�������f�B�N�V���i��</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/04/10</br>
        /// </remarks>
        private int SearchSuplAccPayDate(SumAccPaymentListCndtnWork accPaymentListCndtnWork, ref Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  ACCPAY.ADDUPSECCODERF," + Environment.NewLine;
                    sqlText += "  ACCPAY.PAYEECODERF," + Environment.NewLine;
                    sqlText += "  ACCPAY.ADDUPDATERF," + Environment.NewLine;
                    sqlText += "  ACCPAY.LAMONCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " FROM SUPLACCPAYRF AS ACCPAY WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " LEFT JOIN SUMSUPPSTRF AS SUMSUPP WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON ACCPAY.PAYEECODERF = SUMSUPP.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " AND ACCPAY.ENTERPRISECODERF = SUMSUPP.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " WHERE ACCPAY.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND ACCPAY.ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "    AND ACCPAY.SUPPLIERCDRF=0" + Environment.NewLine;

                    //�x����R�[�h
                    if (accPaymentListCndtnWork.St_PayeeCode != 0)
                    {
                        sqlText += " AND SUMSUPP.SUMSUPPLIERCDRF>=@ST_PAYEECODECD" + Environment.NewLine;
                        SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_PAYEECODECD", SqlDbType.Int);
                        paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(accPaymentListCndtnWork.St_PayeeCode);
                    }
                    if (accPaymentListCndtnWork.Ed_PayeeCode != 999999)
                    {
                        sqlText += " AND SUMSUPP.SUMSUPPLIERCDRF<=@ED_PAYEECODECD" + Environment.NewLine;
                        SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODECD", SqlDbType.Int);
                        paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(accPaymentListCndtnWork.Ed_PayeeCode);
                    }
                    sqlText += " ORDER BY ACCPAY.PAYEECODERF" + Environment.NewLine;

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(accPaymentListCndtnWork.EnterpriseCode);
                    findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(accPaymentListCndtnWork.AddUpYearMonth);

                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    // ���_�R�[�h
                    string addUpSecCd;
                    // �x����R�[�h
                    int payeeCode;

                    while (myReader.Read())
                    {
                        SuplAccPayDateInfo suplAccPayDateInfo = new SuplAccPayDateInfo();
                        // ���_�R�[�h
                        addUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF")).Trim();
                        // �x����R�[�h
                        payeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                        // �O�񌎎��X�V�N����
                        suplAccPayDateInfo.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
                        // ���񌎎��X�V�N����
                        suplAccPayDateInfo.AddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATERF"));

                        if (!suplAccPayDateDic.ContainsKey(addUpSecCd + "-" + payeeCode.ToString("000000")))
                        {
                            suplAccPayDateDic.Add(addUpSecCd + "-" + payeeCode.ToString("000000"), suplAccPayDateInfo);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchSuplAccPayDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [SearchStockProc]
        /// <summary>
        /// �d���f�[�^���擾���܂��B
        /// </summary>
        /// <param name="accPaymentWork">��������</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="accPaymentListCndtnWork">���|�c���ꗗ�\�i�����j���o����</param>
        /// <param name="isCheckOut">�����t���b�O</param>
        /// <param name="laMonCAddUpUpdDate">�O�񌎎��X�V�N����</param>
        /// <param name="suplAccPayDateDic">�x���斈�̌����X�V�������f�B�N�V���i��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/04/10</br>
        /// <br>Note       : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2022/10/20</br>
        private int SearchStockProc(ref SumAccPaymentListResultWork accPaymentWork, ref SqlConnection sqlConnection, SumAccPaymentListCndtnWork accPaymentListCndtnWork, bool isCheckOut, DateTime laMonCAddUpUpdDate, Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlDataReader myReader = null;

            SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

            // ��ƃR�[�h
            string enterpriseCode = accPaymentListCndtnWork.EnterpriseCode;

            // �v��N����
            int addUpDate = Convert.ToInt32(accPaymentListCndtnWork.AddUpDate.ToString("yyyyMMdd"));

            // �ŗ�2
            int laMonCAddUpDate = 0;

            // ����œ]�ŕ������X�g
            List<int> consTaxLayMethodList = new List<int>();

            #region ���Џ��.����N�����擾
            bool getFirstDateFlag = false;
            int per2yearAddUpdate = 0;

            //���Џ��擾
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList = new ArrayList();

            paraCompanyInfWork.EnterpriseCode = enterpriseCode;

            status = companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // �Y���f�[�^�Ȃ� status���N���A������
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                throw new Exception("���Џ��擾���s�B");
            }

            paraCompanyInfWork = (CompanyInfWork)arrayList[0];

            //���Џ��.����N������1�N�O�̓��̐ݒ�
            if (paraCompanyInfWork.CompanyBiginDate != 0)
            {
                DateTime dt = DateTime.ParseExact(paraCompanyInfWork.CompanyBiginDate.ToString(), "yyyyMMdd", null);
                DateTime dt1YearBefore = dt.AddYears(-1);
                DateTime dt1DayBefore = dt1YearBefore.AddDays(-1);
                getFirstDateFlag = Int32.TryParse(dt1DayBefore.ToString("yyyyMMdd"), out per2yearAddUpdate);
            }
            #endregion

            string sqlText = string.Empty;
            string suplAccPayDateKey = string.Empty;

            if (isCheckOut)
            {
                suplAccPayDateKey = accPaymentWork.AddUpSecCode.Trim() + "-" + accPaymentWork.PayeeCode.ToString("000000");
                if (suplAccPayDateDic.ContainsKey(suplAccPayDateKey))
                {
                    laMonCAddUpDate = suplAccPayDateDic[suplAccPayDateKey].LaMonCAddUpUpdDate;
                    addUpDate = suplAccPayDateDic[suplAccPayDateKey].AddUpDate;
                }
            }
            else
            {
                laMonCAddUpDate = Convert.ToInt32(laMonCAddUpUpdDate.ToString("yyyyMMdd"));
            }

            try
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = _timeOut;
                    sqlText = string.Empty;

                    #region [���W�v���R�[�h�쐬����]

                    #region SELECT���쐬
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.FRACTIONPROCCDRF,  " + Environment.NewLine;
                    sqlText += " SUPLIERPAY.STOCKSLIPCOUNT," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF + SUPLIERPAY.THISSTCKPRICRGDSRF + SUPLIERPAY.THISSTCKPRICDISRF AS OFSTHISTIMESTOCKRF," + Environment.NewLine;
                    // �d��
                    sqlText += " SUPLIERPAY.THISTIMESTOCKPRICERF AS THISTIMESTOCKPRICERF," + Environment.NewLine;
                    // �ԕi
                    sqlText += " SUPLIERPAY.THISSTCKPRICRGDSRF AS THISSTCKPRICRGDSRF," + Environment.NewLine;
                    // �l��
                    sqlText += " SUPLIERPAY.THISSTCKPRICDISRF AS THISSTCKPRICDISRF," + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SLIPSTOCKPRICECONSTAX AS SLIPSTOCKPRICECONSTAX, --�`�[�]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.DTLSTOCKPRICECONSTAX AS DTLSTOCKPRICECONSTAX,   --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += " SUPLIERPAY.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                    sqlText += " SUPLIERPAY.TAXATIONCODERF, --�ېŋ敪" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                    sqlText += " SUPLIERPAY.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                    sqlText += " FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    #region [SUB�N�G��]
                    sqlText += " SELECT" + Environment.NewLine;
                    sqlText += "  SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "  PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "  PROCMONEY.FRACTIONPROCCDRF, " + Environment.NewLine;
                    sqlText += "  COUNT(STOCK.SUPPLIERSLIPNORF) STOCKSLIPCOUNT, --�`�[����" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =10 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISTIMESTOCKPRICERF,       --�d���������z" + Environment.NewLine;
                    sqlText += "  SUM((CASE WHEN STOCK.SUPPLIERSLIPCDRF =20 THEN STOCK.STOCKNETPRICERF ELSE 0 END)) AS THISSTCKPRICRGDSRF,       --�ԕi�������z" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.STCKDISTTLTAXEXCRF) AS THISSTCKPRICDISRF,         --�l�����z�v�i�Ŕ����j" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.SLIPSTOCKPRICECONSTAX) AS SLIPSTOCKPRICECONSTAX,  --�`�[�]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "  SUM(STOCK.DTLSTOCKPRICECONSTAX) AS DTLSTOCKPRICECONSTAX,    --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "  STOCK.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                    sqlText += " STOCK.TAXATIONCODERF, --�ېŋ敪" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                    sqlText += "  STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    #region SUBSUB�N�G��
                    sqlText += "   SELECT" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPCTAXLAYCDRF, --����œ]�ŕ���(�d���f�[�^) " + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERFORMALRF,--�d���`��" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.DEBITNOTEDIVRF,  --�ԓ`�敪" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERSLIPCDRF,--�d���`�[�敪" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKGOODSCDRF,  --�d�����i�敪" + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERSLIPNORF," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.STOCKADDUPADATERF," + Environment.NewLine;
                    sqlText += "   (CASE WHEN (SEARCHSUPPLIER.SUPPLIERCDRF IS NOT NULL) THEN SEARCHSUPPLIER.SUPPLIERCDRF ELSE SUBSTOCK.SUPPLIERCDRF END)  AS SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "    (CASE WHEN (SEARCHSUPPLIER.PAYEECODERF IS NOT NULL) THEN SEARCHSUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;
                    // --- DEL START 3H ���� 2022/10/20 ----->>>>>
                    //sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "    (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =0 ) THEN (SUBSTOCK.STOCKTTLPRICTAXINCRF - SUBSTOCK.STOCKTTLPRICTAXEXCRF) ELSE 0 END) AS SLIPSTOCKPRICECONSTAX," + Environment.NewLine;
                    // --- DEL END 3H ���� 2022/10/20 -----<<<<<
                    // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                    sqlText += "      (CASE WHEN (SUBSTOCKDTL.SUPPLIERSLIPCDRF =10) THEN SUBSTOCKDTL.STOCKPRICE + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO WHEN (SUBSTOCKDTL.SUPPLIERSLIPCDRF =20) THEN SUBSTOCKDTL.RETSTOCKPRICE + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO ELSE 0 END) AS STOCKNETPRICERF," + Environment.NewLine;
                    sqlText += "      SUBSTOCKDTL.DISGOODSSTAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SUBSTOCKDTL.TAXATIONCODERF AS TAXATIONCODERF, --�ېŋ敪" + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =0 AND SUBSTOCKDTL.TAXATIONCODERF = 0) THEN (SUBSTOCK.STOCKTTLPRICTAXINCRF - SUBSTOCK.STOCKTTLPRICTAXEXCRF) ELSE 0 END) AS SLIPSTOCKPRICECONSTAX," + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                    sqlText += "    (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =1 ) THEN DTLSTOCKPRICECONSTAX ELSE 0 END) AS DTLSTOCKPRICECONSTAX," + Environment.NewLine;
                    sqlText += "    SUBSTOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                    sqlText += "   FROM" + Environment.NewLine;
                    sqlText += "    STOCKSLIPRF AS SUBSTOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    LEFT JOIN SUPPLIERRF AS SEARCHSUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "     ON SUBSTOCK.ENTERPRISECODERF = SEARCHSUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSTOCK.SUPPLIERCDRF = SEARCHSUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += "    LEFT JOIN" + Environment.NewLine;
                    sqlText += "    ( " + Environment.NewLine;
                    sqlText += "      SELECT" + Environment.NewLine;
                    sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERFORMALRF, --�󒍃X�e�[�^�X" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPCDRF, --�d���`�[�敪" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPNORF, --�d���`�[�ԍ� " + Environment.NewLine;
                    // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                    sqlText += "       DTL.TAXATIONCODERF, --�ېŋ敪 " + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                    sqlText += "       --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "       SUM(DTL.STOCKPRICECONSTAXRF) AS DTLSTOCKPRICECONSTAX,-- ���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "       -- �s�l��" + Environment.NewLine;
                    //sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO" + Environment.NewLine; // DEL 3H ���� 2022/10/09
                    // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF =0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISSTOCKPRICETAXEXCGYO,-- �Ŕ��l�����z(�s�l��)" + Environment.NewLine;
                    sqlText += "       --���i�l�����z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 2 AND DTL.STOCKCOUNTRF <>0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS DISGOODSSTAXEXCGYO,-- �Ŕ��l�����z(���i�l��)" + Environment.NewLine;
                    sqlText += "       --�d�����z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 0 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS STOCKPRICE,-- �d�����z" + Environment.NewLine;
                    sqlText += "       --�ԕi���z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.STOCKSLIPCDDTLRF = 1 ) THEN DTL.STOCKPRICETAXEXCRF ELSE 0 END) AS RETSTOCKPRICE-- �ԕi���z" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/09 -----<<<<<
                    sqlText += "      FROM" + Environment.NewLine;
                    sqlText += "       STOCKDETAILRF AS DTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "      LEFT JOIN STOCKSLIPRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "       ON DTL.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "       AND DTL.SUPPLIERFORMALRF = STOCK.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "       AND DTL.SUPPLIERSLIPNORF = STOCK.SUPPLIERSLIPNORF" + Environment.NewLine;
                    sqlText += "      GROUP BY" + Environment.NewLine;
                    sqlText += "       STOCK.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERFORMALRF, --�󒍃X�e�[�^�X" + Environment.NewLine;
                    sqlText += "       STOCK.SUPPLIERSLIPCDRF, --�d���`�[�敪" + Environment.NewLine;
                    //sqlText += "       STOCK.SUPPLIERSLIPNORF --�d���`�[�ԍ� " + Environment.NewLine; // DEL 3H ���� 2022/10/20
                    // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                    sqlText += "       STOCK.SUPPLIERSLIPNORF, --�d���`�[�ԍ� " + Environment.NewLine;
                    sqlText += "       DTL.TAXATIONCODERF --�ېŋ敪 " + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                    sqlText += "    ) AS SUBSTOCKDTL" + Environment.NewLine;
                    sqlText += "    ON  SUBSTOCK.ENTERPRISECODERF = SUBSTOCKDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND SUBSTOCK.SUPPLIERFORMALRF = SUBSTOCKDTL.SUPPLIERFORMALRF" + Environment.NewLine;
                    sqlText += "    AND SUBSTOCK.SUPPLIERSLIPNORF = SUBSTOCKDTL.SUPPLIERSLIPNORF" + Environment.NewLine;
                    #endregion

                    #region [ JOIN ]
                    sqlText += "   ) AS STOCK" + Environment.NewLine;
                    sqlText += "   INNER JOIN SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    ON SUPPLIER.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND SUPPLIER.SUPPLIERCDRF = STOCK.PAYEECODERF" + Environment.NewLine;
                    sqlText += "   LEFT JOIN STOCKPROCMONEYRF AS PROCMONEY WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    ON PROCMONEY.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "    AND PROCMONEY.FRACPROCMONEYDIVRF = 1" + Environment.NewLine;
                    sqlText += "    AND PROCMONEY.FRACTIONPROCCODERF = SUPPLIER.STOCKCNSTAXFRCPROCCDRF" + Environment.NewLine;
                    #endregion

                    #region [ WHERE ]
                    sqlText += "   WHERE STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND STOCK.SUPPLIERCDRF =@FINDPAYEECODE" + Environment.NewLine;
                    sqlText += "    AND STOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "    AND (STOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND STOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                    sqlText += "    AND  STOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "    AND  STOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
                    sqlText += "    AND  STOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
                    sqlText += "    AND (STOCK.SUPPLIERSLIPCDRF = 10 OR STOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                    sqlText += "    AND (STOCK.STOCKGOODSCDRF=0 OR STOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                    #endregion 

                    #region [ GROUP BY ]
                    sqlText += "   GROUP BY" + Environment.NewLine;
                    sqlText += "    SUPPLIER.STOCKCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "    PROCMONEY.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "    PROCMONEY.FRACTIONPROCCDRF, " + Environment.NewLine;
                    sqlText += "    STOCK.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    //sqlText += "    STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;// DEL 3H ���� 2022/10/20
                    // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                    sqlText += "    STOCK.SUPPLIERCONSTAXRATERF," + Environment.NewLine;
                    sqlText += "    STOCK.TAXATIONCODERF" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                    sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
                    #endregion

                    #endregion

                    sqlCommand.CommandText = sqlText;

                    #region  Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(accPaymentWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetInt32(addUpDate);
                    findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(accPaymentWork.AddUpSecCode);

                    if (getFirstDateFlag && (per2yearAddUpdate > 20000101))
                    {
                        if (laMonCAddUpDate < per2yearAddUpdate)
                        {
                            findParaLastTimeAddUpDate.Value = per2yearAddUpdate;
                        }
                        else
                        {
                            findParaLastTimeAddUpDate.Value = laMonCAddUpDate;
                        }
                    }
                    else
                    {
                        if (laMonCAddUpDate < 20000101)
                        {
                            findParaLastTimeAddUpDate.Value = per2yearAddUpdate;
                        }
                        else
                        {
                            findParaLastTimeAddUpDate.Value = laMonCAddUpDate;
                        }
                    }
                    #endregion

                    myReader = sqlCommand.ExecuteReader();
                    // �[�������P��
                    double fractionProcUnit = 0;
                    // �`�[�]�ŁE���ד]�ŏ����
                    long totalStockPricTax = 0;

                    while (myReader.Read())
                    {
                        #region ���ʃZ�b�g
                        suplAccPayWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //�[�������敪
                        fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF"));           // �[�������P��

                        suplAccPayWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                        suplAccPayWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));

                        // ������Ŋz
                        if (suplAccPayWork.SuppCTaxLayCd == 0)
                        {
                            totalStockPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPSTOCKPRICECONSTAX"));
                        }
                        else if (suplAccPayWork.SuppCTaxLayCd == 1)
                        {
                            totalStockPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSTOCKPRICECONSTAX"));
                        }
                        else
                        {
                            totalStockPricTax = 0;
                        }

                        //�����E
                        suplAccPayWork.OfsThisTimeStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESTOCKRF"));

                        // ���d��
                        suplAccPayWork.ThisTimeStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESTOCKPRICERF"));

                        // ���ԕi
                        suplAccPayWork.ThisStckPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICRGDSRF"));

                        // ���l��
                        suplAccPayWork.ThisStckPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSTCKPRICDISRF"));

                        // �`�[����
                        suplAccPayWork.StockSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCOUNT"));

                        // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                        // �ېŋ敪
                        int taxAtionCodeRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                        // --- ADD END 3H ���� 2022/10/20 -----<<<<<

                        #endregion

                        #region �ŕʓ����
                        //if (suplAccPayWork.SuppCTaxLayCd != 9 && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate1) // DEL 3H ���� 2022/10/20
                        if ((suplAccPayWork.SuppCTaxLayCd != 9 && taxAtionCodeRF != 1) && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate1) // ADD 3H ���� 2022/10/20
                        {
                            // �d���z(�v�ŗ�1)
                            accPaymentWork.TotalThisTimeStockPriceTaxRate1 += suplAccPayWork.ThisTimeStockPrice;
                            // �ԕi�l��(�v�ŗ�1)
                            accPaymentWork.TotalThisRgdsDisPricTaxRate1 -= suplAccPayWork.ThisStckPricRgds + suplAccPayWork.ThisStckPricDis;
                            // ���d���z(�v�ŗ�1)
                            accPaymentWork.TotalPureStockTaxRate1 += suplAccPayWork.OfsThisTimeStock;
                            // �����(�v�ŗ�1)
                            if (suplAccPayWork.SuppCTaxLayCd == 0 || suplAccPayWork.SuppCTaxLayCd == 1)
                            {
                                accPaymentWork.TotalStockPricTaxTaxRate1 += totalStockPricTax;
                            }
                            // ����(�v�ŗ�1)
                            accPaymentWork.TotalStockSlipCountTaxRate1 += suplAccPayWork.StockSlipCount;
                        }
                        //else if (suplAccPayWork.SuppCTaxLayCd != 9 && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate2)// DEL 3H ���� 2022/10/20
                        else if ((suplAccPayWork.SuppCTaxLayCd != 9 && taxAtionCodeRF != 1) && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate2)// ADD 3H ���� 2022/10/20
                        {
                            // �d���z(�v�ŗ�2)
                            accPaymentWork.TotalThisTimeStockPriceTaxRate2 += suplAccPayWork.ThisTimeStockPrice;
                            // �ԕi�l��(�v�ŗ�2)
                            accPaymentWork.TotalThisRgdsDisPricTaxRate2 -= suplAccPayWork.ThisStckPricRgds + suplAccPayWork.ThisStckPricDis;
                            // ���d���z(�v�ŗ�2)
                            accPaymentWork.TotalPureStockTaxRate2 += suplAccPayWork.OfsThisTimeStock;
                            // �����(�v�ŗ�2)
                            if (suplAccPayWork.SuppCTaxLayCd == 0 || suplAccPayWork.SuppCTaxLayCd == 1)
                            {
                                accPaymentWork.TotalStockPricTaxTaxRate2 += totalStockPricTax;
                            }
                            // ����(�v�ŗ�2)
                            accPaymentWork.TotalStockSlipCountTaxRate2 += suplAccPayWork.StockSlipCount;
                        }
                        // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                        // ��ې�
                        else if (suplAccPayWork.SuppCTaxLayCd == 9 || taxAtionCodeRF == 1)
                        {
                            // �d���z(�v��ې�)
                            accPaymentWork.TotalThisTimeStockPriceTaxFree += suplAccPayWork.ThisTimeStockPrice;
                            // �ԕi�l��(�v��ې�)
                            accPaymentWork.TotalThisRgdsDisPricTaxFree -= suplAccPayWork.ThisStckPricRgds + suplAccPayWork.ThisStckPricDis;
                            // ���d���z(�v��ې�)
                            accPaymentWork.TotalPureStockTaxFree += suplAccPayWork.OfsThisTimeStock;
                            // �����(�v��ې�)
                            accPaymentWork.TotalStockPricTaxTaxFree = 0;
                            // ����(�v��ې�)
                            accPaymentWork.TotalStockSlipCountTaxFree += suplAccPayWork.StockSlipCount;
                        }
                        // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                        else
                        {
                            // �d���z(�v���̑�)
                            accPaymentWork.TotalThisTimeStockPriceOther += suplAccPayWork.ThisTimeStockPrice;
                            // �ԕi�l��(�v���̑�)
                            accPaymentWork.TotalThisRgdsDisPricOther -= suplAccPayWork.ThisStckPricRgds + suplAccPayWork.ThisStckPricDis;
                            // ���d���z(�v���̑�)
                            accPaymentWork.TotalPureStockOther += suplAccPayWork.OfsThisTimeStock;
                            // �����(�v���̑�)
                            if (suplAccPayWork.SuppCTaxLayCd == 0 || suplAccPayWork.SuppCTaxLayCd == 1)
                            {
                                accPaymentWork.TotalStockPricTaxOther += totalStockPricTax;
                            }
                            // ����(�v���̑�)
                            accPaymentWork.TotalStockSlipCountOther += suplAccPayWork.StockSlipCount;
                        }

                        if (!consTaxLayMethodList.Contains(suplAccPayWork.SuppCTaxLayCd))
                        {
                            consTaxLayMethodList.Add(suplAccPayWork.SuppCTaxLayCd);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        #endregion
                    }
                    #endregion

                    // ������
                    if (!myReader.IsClosed) myReader.Close();
                    sqlCommand.CommandText = string.Empty;
                    sqlText = string.Empty;

                    #region ����łƓ������v�Z�o
                    foreach (int suppCTaxLayCd in consTaxLayMethodList)
                    {
                        // �`�[�]�ŁE���ד]�ŁE��ې�
                        if (suppCTaxLayCd == 0 || suppCTaxLayCd == 1 || suppCTaxLayCd == 9)
                        {
                            continue;
                        }

                        switch (suppCTaxLayCd)
                        {
                            // �����e
                            case 2:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(STOCK.STOCKTTLPRICTAXEXCRF) AS STOCKTTLPRICTAXEXCRF," + Environment.NewLine;
                                sqlText += "  STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                //sqlText += "	    SUBSTOCK.STOCKTTLPRICTAXEXCRF," + Environment.NewLine; // DEL 3H ���� 2022/10/20
                                // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                                sqlText += "	 (SELECT SUM(STOCKPRICETAXEXCRF) AS STOCKTTLPRICTAXEXCRF  FROM STOCKDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSTOCK.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERFORMALRF = DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERSLIPNORF  = DTL.SUPPLIERSLIPNORF " + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONCODERF = 0) AS STOCKTTLPRICTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                                sqlText += "	    SUBSTOCK.SUPPLIERCDRF," + Environment.NewLine;
                                sqlText += "	    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                                sqlText += "	    (CASE WHEN (SUPPLIER.PAYEECODERF IS NOT NULL) THEN SUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM STOCKSLIPRF AS SUBSTOCK WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSTOCK.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSTOCK.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSTOCK.SUPPLIERCDRF = SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.SUPPCTAXLAYCDRF=2" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                                sqlText += ") AS STOCK" + Environment.NewLine;
                                sqlText += "WHERE STOCK.SUPPLIERCDRF=@FINDPAYEECODE" + Environment.NewLine;
                                sqlText += "  AND STOCK.STOCKSECTIONCDRF=@FINDADDUPSECCODE" + Environment.NewLine;
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                break;
                            // �����q
                            case 3:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(STOCK.STOCKTTLPRICTAXEXCRF) AS STOCKTTLPRICTAXEXCRF," + Environment.NewLine;
                                sqlText += "  STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                                sqlText += "  STOCK.SUPPLIERCDRF," + Environment.NewLine;
                                sqlText += "  STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                sqlText += "	    SUBSTOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                                //sqlText += "	    SUBSTOCK.STOCKTTLPRICTAXEXCRF," + Environment.NewLine; // DEL 3H ���� 2022/10/20
                                // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                                sqlText += "	 (SELECT SUM(STOCKPRICETAXEXCRF) AS STOCKTTLPRICTAXEXCRF  FROM STOCKDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSTOCK.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERFORMALRF = DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERSLIPNORF  = DTL.SUPPLIERSLIPNORF " + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONCODERF = 0) AS STOCKTTLPRICTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                                sqlText += "	    SUBSTOCK.SUPPLIERCDRF," + Environment.NewLine;
                                sqlText += "	    (CASE WHEN (SUPPLIER.PAYEECODERF IS NOT NULL) THEN SUPPLIER.PAYEECODERF ELSE SUBSTOCK.PAYEECODERF END) AS PAYEECODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSTOCK.STOCKADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSTOCK.STOCKADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM STOCKSLIPRF AS SUBSTOCK WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSTOCK.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN SUPPLIERRF AS SUPPLIER WITH (READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSTOCK.ENTERPRISECODERF = SUPPLIER.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSTOCK.SUPPLIERCDRF = SUPPLIER.SUPPLIERCDRF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSTOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKADDUPADATERF<=@FINDADDUPDATE AND SUBSTOCK.STOCKADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.SUPPLIERFORMALRF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.SUPPCTAXLAYCDRF=3" + Environment.NewLine;
                                sqlText += "        AND  SUBSTOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                                sqlText += ") AS STOCK" + Environment.NewLine;
                                sqlText += "WHERE STOCK.SUPPLIERCDRF=@FINDPAYEECODE" + Environment.NewLine;
                                sqlText += "  AND STOCK.STOCKSECTIONCDRF=@FINDADDUPSECCODE" + Environment.NewLine;
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   STOCK.STOCKSECTIONCDRF," + Environment.NewLine;
                                sqlText += "   STOCK.SUPPLIERCDRF," + Environment.NewLine;
                                sqlText += "   STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
                                break;
                        }

                        // �����]�ł݂̂̏ꍇ�A����Ŏq�������s��
                        if (!string.IsNullOrEmpty(sqlText))
                        {
                            sqlCommand.CommandText = sqlText;
                            myReader = sqlCommand.ExecuteReader();
                        }

                        // �d���`�[���v�i�Ŕ����j
                        long stockTotal = 0;
                        // ����Őŗ�
                        double supplierConsTaxRate = 0.0;
                        // �����(�[��������)
                        long tempTax = 0;

                        while (myReader.Read())
                        {
                            switch (suppCTaxLayCd)
                            {
                                // �����e
                                case 2:
                                // �����q
                                case 3:
                                    stockTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                                    supplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));

                                    if (supplierConsTaxRate == accPaymentListCndtnWork.TaxRate1)
                                    {
                                        FracCalc(stockTotal * supplierConsTaxRate, fractionProcUnit, suplAccPayWork.FractionProcCd, out tempTax);
                                        accPaymentWork.TotalStockPricTaxTaxRate1 += tempTax;
                                    }
                                    else if (supplierConsTaxRate == accPaymentListCndtnWork.TaxRate2)
                                    {
                                        FracCalc(stockTotal * supplierConsTaxRate, fractionProcUnit, suplAccPayWork.FractionProcCd, out tempTax);
                                        accPaymentWork.TotalStockPricTaxTaxRate2 += tempTax;
                                    }
                                    else
                                    {
                                        FracCalc(stockTotal * supplierConsTaxRate, fractionProcUnit, suplAccPayWork.FractionProcCd, out tempTax);
                                        accPaymentWork.TotalStockPricTaxOther += tempTax;
                                    }
                                    break;
                            }
                        }

                        sqlText = string.Empty;
                        if (!myReader.IsClosed) myReader.Close();
                    }

                    accPaymentWork.TotalStckTtlAccPayBalanceTaxRate1 = accPaymentWork.TotalPureStockTaxRate1 + accPaymentWork.TotalStockPricTaxTaxRate1;
                    accPaymentWork.TotalStckTtlAccPayBalanceTaxRate2 = accPaymentWork.TotalPureStockTaxRate2 + accPaymentWork.TotalStockPricTaxTaxRate2;
                    // --- ADD START 3H ���� 2022/10/20 ----->>>>>
                    // �������v(�v��ې�)
                    accPaymentWork.TotalStckTtlAccPayBalanceTaxFree = accPaymentWork.TotalPureStockTaxFree + accPaymentWork.TotalStockPricTaxTaxFree;
                    // --- ADD END 3H ���� 2022/10/20 -----<<<<<
                    accPaymentWork.TotalStckTtlAccPayBalanceOther = accPaymentWork.TotalPureStockOther + accPaymentWork.TotalStockPricTaxOther;
                    #endregion

                    #endregion
                }

                accPaymentWork.TitleTaxRate1 = Convert.ToInt32(accPaymentListCndtnWork.TaxRate1 * 100) + "%";
                accPaymentWork.TitleTaxRate2 = Convert.ToInt32(accPaymentListCndtnWork.TaxRate2 * 100) + "%";
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchStockProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [FracCalc ����Œ[������]
        /// <summary>
        /// �[������
        /// </summary>
        /// <param name="inputNumerical">���l</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultNumerical">�Z�o���z</param>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/04/10</br>
        private void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out Int64 resultNumerical)
        {
            // �����l�Z�b�g
            resultNumerical = (Int64)inputNumerical;

            inputNumerical = (double)((decimal)inputNumerical - ((decimal)inputNumerical % (decimal)0.000001));	// �����_6���ȉ��؎�
            fractionUnit = (double)((decimal)fractionUnit - ((decimal)fractionUnit % (decimal)0.000001));		// �����_6���ȉ��؎�

            // �[�����Z�h�~
            if (((decimal)fractionUnit) == 0)
            {
                fractionUnit = 1;
            }
            // �[���P�ʂŏ��Z
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // �}�C�i�X�␳
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // ������1���擾
            decimal tmpDecimal = (tmpKin - (decimal)((long)tmpKin)) * 10;

            // tmpKin �[���w��
            bool wRoundFlg = true; // �؎�
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:�؎�
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // �؎�
                        break;
                    }
                //--------------------------------------
                // 2:�l�̌ܓ�
                //--------------------------------------
                case 2: // �l�̌ܓ�
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
                //--------------------------------------
                // 3:�؏�
                //--------------------------------------
                case 3: // �؏�
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
            }

            // �[������
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // �������؎�
            tmpKin = (decimal)(long)tmpKin;

            // �}�C�i�X�␳
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = tmpKin * (decimal)fractionUnit;

            // �Z�o�l�Z�b�g
            resultNumerical = (Int64)((decimal)tmpKin * (decimal)fractionUnit);

        }
        #endregion

        /// <summary>
        /// ����ŕʓ���敪��񋓂��܂��B
        /// </summary>
        enum TaxTotalDiv
        {
            TaxTotalON = 0,  //0:�󎚂���
            TaxTotalOFF = 1  //1:�󎚂��Ȃ�
        }
        // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

        /// <summary>
        /// �x������敪��񋓂��܂��B
        /// </summary>
        enum PayDtlDiv
        {
            PayDtlON = 0,  //0:�󎚂���
            PayDtlOFF = 1  //1:�󎚂��Ȃ�
        }
    }

    // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
    # region [�����X�V�E�������������]
    /// <summary>
    /// �������������
    /// </summary>
    /// <remarks>
    /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2020/04/10</br>
    /// </remarks>
    public class SuplAccPayDateInfo
    {
        /// <summary>���񌎎��X�V�N����</summary>
        private int _addUpDate;

        /// <summary>�O�񌎎��X�V�N����</summary>
        private int _laMonCAddUpUpdDate;

        /// <summary>���񌎎��X�V�N����</summary>
        public int AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// <summary>�O�񌎎��X�V�N����</summary>
        public int LaMonCAddUpUpdDate
        {
            get { return _laMonCAddUpUpdDate; }
            set { _laMonCAddUpUpdDate = value; }
        }
    }
    #endregion
    // --- ADD END 3H ������ 2020/04/10 ----------<<<<<
}
