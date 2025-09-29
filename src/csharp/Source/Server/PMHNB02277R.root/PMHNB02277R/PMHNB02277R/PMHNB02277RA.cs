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
using Broadleaf.Library.Globarization;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���|�c���ꗗ�\(����)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|�c���ꗗ�\(����)�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30350 �N�� ����</br>
    /// <br>Date       : 2009/04/20</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : Maintis.15088 �������_�ł͂Ȃ��Ǘ����_�ŏW�v����Ă��錏�̏C��</br>
    /// <br>UpdateNote : Maintis.15090 �W���S���Œ��o���悤�Ƃ���ƃG���[�ɂȂ錏�̏C��</br>
    /// <br>Programmer : 30517 �Ė� �x��</br>
    /// <br>Date	   : 2010/03/10</br>
    /// <br></br>
    /// <br>UpdateNote : �s��C��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date	   : 2010/06/06</br>
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date	   : 2020/04/10</br>
    /// <br>UpdateNote : 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2022/10/13</br>
    /// </remarks>
    [Serializable]
    public class SumBillBalanceTableDB : RemoteDB, ISumBillBalanceTableDB
    {
        private int _timeOut = 3600;//ADD 2020/02/28 �΍�@�y���ŗ��Ή�
        /// <summary>
        /// ���|�c���ꗗ�\(����)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009/04/20</br>
        /// </remarks>
        public SumBillBalanceTableDB()
            :
            base("PMHNB02279D", "Broadleaf.Application.Remoting.ParamData.SumRsltInfo_BillBalanceWork", "CUSTACCRECRF")
        {
        }

        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c���ꗗ�\(����)��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c���ꗗ�\��߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009/04/20</br>
        public int Search(out object sumrsltInfo_BillBalanceWork, object sumextrInfo_BillBalanceWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            sumrsltInfo_BillBalanceWork = null;

            ArrayList _extrInfo_BillBalanceWorkList = sumextrInfo_BillBalanceWork as ArrayList;
            SumExtrInfo_BillBalanceWork _extrInfo_BillBalanceWork = null;

            if (_extrInfo_BillBalanceWorkList == null)
            {
                _extrInfo_BillBalanceWork = sumextrInfo_BillBalanceWork as SumExtrInfo_BillBalanceWork;
            }
            else
            {
                if (_extrInfo_BillBalanceWorkList.Count > 0)
                    _extrInfo_BillBalanceWork = _extrInfo_BillBalanceWorkList[0] as SumExtrInfo_BillBalanceWork;
            }

            try
            {
                status = SearchProc(out sumrsltInfo_BillBalanceWork, _extrInfo_BillBalanceWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillBalanceTableDB.Search Exception=" + ex.Message);
                sumrsltInfo_BillBalanceWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion  //[Search]

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔��|�c���ꗗ�\(����)LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="accPaymentListResultWork">��������</param>
        /// <param name="_extrInfo_BillBalanceWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��|�c���ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2009/04/20</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date	   : 2020/04/10</br>
        private int SearchProc(out object sumrsltInfo_BillBalanceWork, SumExtrInfo_BillBalanceWork _sumextrInfo_BillBalanceWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            sumrsltInfo_BillBalanceWork = null;
            // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
            // �����t���b�O
            bool isCheckOut = true;
            // ������O�񌎎��X�V�N����
            Dictionary<int, DateTime> claimDateDic = new Dictionary<int, DateTime>();
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

                ArrayList customerList = new ArrayList();
                SumRsltInfo_BillBalanceWork customerListWork = new SumRsltInfo_BillBalanceWork();

                //���Ӑ�}�X�^���X�g�쐬
                status = SearchCustProc(ref customerList, _sumextrInfo_BillBalanceWork, ref sqlConnection, logicalMode);
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    //�Y���f�[�^�Ȃ�
                    return status;
                }
                else if (status != 0)
                {
                    //�擾���s
                    throw new Exception("���Ӑ�}�X�^�Ǎ����s�B");
                }
                if (customerList.Count == 0)
                {
                    //�Y���f�[�^�Ȃ�
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                    
                for (int i = 0; i < customerList.Count; i++)
                {
                    #region [�������`�F�b�N]
                    retList = new List<TtlDayCalcRetWork>();
                    para = new TtlDayCalcParaWork();
                    para.EnterpriseCode = _sumextrInfo_BillBalanceWork.EnterpriseCode.Trim();               // ��ƃR�[�h
                    para.SectionCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).AddUpSecCode.Trim();  // ���_�R�[�h
                    status = ttlDayCalcDB.SearchHisMonthlyAccRec(out retList, para, ref sqlConnection);
                    
                    // ������Max�l�ɂ��鏈���K�v
                    int MaxTotalDay = 0;
                    foreach (TtlDayCalcRetWork _ttlDayCalcRetWork in retList)
                    {
                        if (MaxTotalDay < _ttlDayCalcRetWork.TotalDay)
                        {
                            MaxTotalDay = _ttlDayCalcRetWork.TotalDay;
                        }
                    }
                    #endregion

                    //���t�ϊ�
                    Int32 iAddUpDate = Int32.Parse(_sumextrInfo_BillBalanceWork.AddUpDate.ToString("yyyyMMdd"));
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || MaxTotalDay < iAddUpDate)
                    {
                        #region �����擾����
                        //���|���E���|���W�v���W���[���p�����[�^�Z�b�g
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        CustAccRecWork custAccRecWork = new CustAccRecWork();
                        custAccRecWork.EnterpriseCode = _sumextrInfo_BillBalanceWork.EnterpriseCode;                //��ƃR�[�h
                        custAccRecWork.AddUpDate = _sumextrInfo_BillBalanceWork.AddUpDate;                          //�v��N����
                        custAccRecWork.AddUpYearMonth = _sumextrInfo_BillBalanceWork.AddUpYearMonth;                //�v��N��
                        custAccRecWork.AddUpSecCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).AddUpSecCode;  //�v�㋒�_�R�[�h �����Ӑ�}�X�^���X�g����
                        custAccRecWork.CustomerCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).CustomerCode;     //���Ӑ�R�[�h   �����Ӑ�}�X�^���X�g����
                        object paraObj2 = (object)custAccRecWork;
                        string retMsg = null;

                        //���|���E���|���W�v���W���[���ďo
                        status = _monthlyAddUpDB.ReadCustAccRec(ref paraObj2, out retMsg);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //�擾����
                            //�擾���ʃL���X�g
                            ArrayList custAccRecResult = new ArrayList();
                            custAccRecResult.Add((CustAccRecWork)paraObj2);

                            //�擾���ʃZ�b�g
                            for (int j = 0; j < custAccRecResult.Count; j++)
                            {
                                #region [���o����-�l�Z�b�g]
                                SumRsltInfo_BillBalanceWork ResultWork = new SumRsltInfo_BillBalanceWork();

                                //���_�R�[�h �����Ӑ�}�X�^����
                                // -- UPD 2010/06/06 ------------------------------------------->>>
                                //ResultWork.AddUpSecCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).AddUpSecCode;
                                ResultWork.AddUpSecCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).SumSecCode;  //�������Ӑ�̐������_�ŏ㏑��
                                // -- UPD 2010/06/06 -------------------------------------------<<<
                                //���_���� �����_���ݒ�}�X�^����
                                ResultWork.SectionGuideSnm = ((SumRsltInfo_BillBalanceWork)customerList[i]).SectionGuideSnm;
                                //����������R�[�h �����Ӑ�}�X�^����
                                ResultWork.ClaimCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).ClaimCode;
                                //���������旪�� �����Ӑ�}�X�^����
                                ResultWork.ClaimSnm = ((SumRsltInfo_BillBalanceWork)customerList[i]).ClaimSnm;
                                //�������Ӑ�R�[�h
                                ResultWork.CustomerCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).CustomerCode;
                                //�������Ӑ於��
                                ResultWork.Customersnm = ((SumRsltInfo_BillBalanceWork)customerList[i]).Customersnm;
                                //�S���҃R�[�h �����Ӑ�}�X�^����
                                ResultWork.AgentCd = ((SumRsltInfo_BillBalanceWork)customerList[i]).AgentCd;
                                //�S���Җ� ���]�ƈ��}�X�^����
                                ResultWork.Name = ((SumRsltInfo_BillBalanceWork)customerList[i]).Name;
                                //�n��R�[�h �����Ӑ�}�X�^����
                                ResultWork.SalesAreaCode = ((SumRsltInfo_BillBalanceWork)customerList[i]).SalesAreaCode;
                                //�n�於 �����[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)����
                                ResultWork.SalesAreaName = ((SumRsltInfo_BillBalanceWork)customerList[i]).SalesAreaName;
                                //�O�����c��
                                ResultWork.LastTimeAccRec = ((CustAccRecWork)custAccRecResult[j]).LastTimeAccRec;
                                //��������
                                ResultWork.ThisTimeDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeDmdNrml;
                                //�J�z�z
                                ResultWork.ThisTimeTtlBlcAcc = ((CustAccRecWork)custAccRecResult[j]).ThisTimeTtlBlcAcc;
                                //����z
                                ResultWork.OfsThisTimeSales = ((CustAccRecWork)custAccRecResult[j]).OfsThisTimeSales;
                                ResultWork.ThisTimeSales = ((CustAccRecWork)custAccRecResult[j]).ThisTimeSales;
                                //�ԕi�l��
                                ResultWork.ThisRgdsDisPric = ((CustAccRecWork)custAccRecResult[j]).ThisSalesPricRgds + ((CustAccRecWork)custAccRecResult[j]).ThisSalesPricDis;
                                //�����
                                ResultWork.OfsThisSalesTax = ((CustAccRecWork)custAccRecResult[j]).OfsThisSalesTax;
                                //�������c��
                                ResultWork.AfCalTMonthAccRec = ((CustAccRecWork)custAccRecResult[j]).AfCalTMonthAccRec;
                                //����
                                ResultWork.SalesSlipCount = ((CustAccRecWork)custAccRecResult[j]).SalesSlipCount;
                                //�萔��
                                ResultWork.ThisTimeFeeDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeFeeDmdNrml;
                                //�l��
                                ResultWork.ThisTimeDisDmdNrml = ((CustAccRecWork)custAccRecResult[j]).ThisTimeDisDmdNrml;

                                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                                if (_sumextrInfo_BillBalanceWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                                {
                                    // �����t���b�O
                                    isCheckOut = false;

                                    // ������R�[�h
                                    int claimCode = ((CustAccRecWork)custAccRecResult[j]).ClaimCode;

                                    // �O�񌎎��X�V�N����
                                    DateTime laMonCAddUpUpdDate = ((CustAccRecWork)custAccRecResult[j]).LaMonCAddUpUpdDate;

                                    // ������O�񌎎��X�V�N����
                                    if (!claimDateDic.ContainsKey(claimCode))
                                    {
                                        claimDateDic.Add(claimCode, laMonCAddUpUpdDate);
                                    }
                                }
                                // --- ADD END 3H ������ 2020/04/10 ----------<<<<<

                                // 0���у`�F�b�N
                                if (ResultWork.LastTimeAccRec == 0 && ResultWork.ThisTimeFeeDmdNrml == 0 &&
                                    ResultWork.ThisTimeDisDmdNrml == 0 && ResultWork.ThisTimeDmdNrml == 0 &&
                                    ResultWork.OfsThisTimeSales == 0 && ResultWork.OfsThisSalesTax == 0 &&
                                    ResultWork.SalesSlipCount == 0)
                                {
                                    continue;
                                }

                                if (_sumextrInfo_BillBalanceWork.DepoDtlDiv == (int)DepoDtlDiv.DepoDtlON)
                                {
                                    //�����f�[�^�擾
                                    ArrayList DepsitList = new ArrayList();
                                    status = SearchDepsitProc(ref DepsitList, custAccRecResult, ref sqlConnection, logicalMode);
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
                                        throw new Exception("�����f�[�^�擾���s�B");
                                    }
                                    if (DepsitList.Count == 0)
                                    {
                                        //�Y���f�[�^�Ȃ� status���N���A������
                                        al.Add(ResultWork);
                                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                        continue;
                                    }

                                    //����
                                    ResultWork.CashDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).CashDeposit;
                                    //�U��
                                    ResultWork.TrfrDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).TrfrDeposit;
                                    //���؎�
                                    ResultWork.CheckDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).CheckDeposit;
                                    //��`
                                    ResultWork.DraftDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).DraftDeposit;
                                    //���E
                                    ResultWork.OffsetDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).OffsetDeposit;
                                    //�����U��
                                    ResultWork.FundTransferDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).FundTransferDeposit;
                                    //���̑�
                                    ResultWork.OthsDeposit = ((SumRsltInfo_BillBalanceWork)DepsitList[0]).OthsDeposit;

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
                        customerListWork = customerList[i] as SumRsltInfo_BillBalanceWork;
                        //���ߍ� -> ���Ӑ攄�|���z�}�X�^����擾
                        //�������s
                        status = SearchBillBalanceTableProc(ref al, _sumextrInfo_BillBalanceWork, customerListWork, ref sqlConnection, logicalMode);
                    }
                }

                // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
                // ����ŕʓ���󎚂���
                if (_sumextrInfo_BillBalanceWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                {
                    Dictionary<int, CustAccRecDateInfo> custAccRecDateDic = new Dictionary<int, CustAccRecDateInfo>();
                    // �����X�V���s�����ꍇ
                    if (isCheckOut)
                    {
                        // �����X�V�������擾���s��
                        status = SearchCustAccRecDate(_sumextrInfo_BillBalanceWork, ref custAccRecDateDic, ref sqlConnection);

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

                    for (int i = 0; i < al.Count; i++)
                    {

                        SumRsltInfo_BillBalanceWork billBalanceWork = (SumRsltInfo_BillBalanceWork)al[i];

                        // �O�񌎎��X�V�N����
                        DateTime laMonCAddUpUpdDate = DateTime.MinValue;

                        if (!isCheckOut)
                        {
                            // �O�񌎎��X�V�N�����擾
                            claimDateDic.TryGetValue(billBalanceWork.ClaimCode, out laMonCAddUpUpdDate);
                        }

                        // ����f�[�^�擾
                        status = SearchSalesProc(ref billBalanceWork, ref sqlConnection, _sumextrInfo_BillBalanceWork, isCheckOut, laMonCAddUpUpdDate, custAccRecDateDic);

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
                            throw new Exception("����f�[�^�擾���s�B");
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchProc Exception=" + ex.Message);
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

            sumrsltInfo_BillBalanceWork = al;
            // --- UPD START 3H ������ 2020/04/10 ---------->>>>>
            //if (al.Count > 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            if (_sumextrInfo_BillBalanceWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalOFF)
            {
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // --- UPD END 3H ������ 2020/04/10 ----------<<<<<
            return status;
        }
        #endregion  //[SearchProc]

        #region [SearchCustProc]
        /// <summary>
        /// ���Ӑ�}�X�^��������ɊY�����链�Ӑ惊�X�g�𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_extrInfo_BillBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ惊�X�g��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchCustProc(ref ArrayList al, SumExtrInfo_BillBalanceWork _extrInfo_BillBalanceWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // CUSTOMERRF        CSTMER ���Ӑ�}�X�^
                // EMPLOYEERF        EMPLYE �]�ƈ��}�X�^
                // USERGDBDURF       USGDBD ���[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)
                // SECINFOSETRF      SCINST ���_���ݒ�}�X�^

                // ���T�g�����Ӑ摍������

                #region SELECT��
                selectTxt += "  SELECT  " + Environment.NewLine;
                selectTxt += "   SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "  ,SUMCST.CUSTOMERCODERF " + Environment.NewLine;
                selectTxt += "  ,CUSTOM.CUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "  ,SUMCST.SUMCLAIMCUSTCODERF " + Environment.NewLine;
                selectTxt += "  ,CUSTCL.CUSTOMERSNMRF AS SUMCUSTOMERSNMRF " + Environment.NewLine;
                selectTxt += "  ,CUSTCL.MNGSECTIONCODERF " + Environment.NewLine;
                // -- UPD 2010/06/06 --------------------------->>>
                //// 2010/03/10 Add >>>
                //selectTxt += "  ,CUSTCL.CLAIMSECTIONCODERF " + Environment.NewLine;
                //// 2010/03/10 Add <<<
                selectTxt += "  ,CUSTCL.CLAIMSECTIONCODERF AS SUMSECCODERF" + Environment.NewLine;   //�������Ӑ�̐������_
                selectTxt += "  ,CUSTOM.CLAIMSECTIONCODERF" + Environment.NewLine;                   //������̐������_��ǉ�
                // -- UPD 2010/06/06 ---------------------------<<<
                selectTxt += "  ,SECINF.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += "  ,CUSTCL.SALESAREACODERF  " + Environment.NewLine;
                selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                             "  ,CUSTCL.CUSTOMERAGENTCDRF AS AGENTCD  ");
                selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                             "  ,CUSTCL.BILLCOLLECTERCDRF AS AGENTCD" + Environment.NewLine);
                selectTxt += "  ,USERGD.GUIDENAMERF AS SALESAREANAME  " + Environment.NewLine;
                selectTxt += "  ,EMPLOY.NAMERF  " + Environment.NewLine;
                selectTxt += "  FROM SUMCUSTSTRF AS SUMCST  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUSTOM   " + Environment.NewLine;
                selectTxt += "   ON  CUSTOM.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF   " + Environment.NewLine;
                selectTxt += "   AND CUSTOM.CUSTOMERCODERF = SUMCST.CUSTOMERCODERF   " + Environment.NewLine;
                //selectTxt += "   AND CUSTOM.MNGSECTIONCODERF = SUMCST.DEMANDADDUPSECCDRF   " + Environment.NewLine;
                selectTxt += "  LEFT JOIN CUSTOMERRF AS CUSTCL  " + Environment.NewLine;
                selectTxt += "   ON  CUSTCL.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND CUSTCL.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF  " + Environment.NewLine;
                //selectTxt += "   AND CUSTCL.MNGSECTIONCODERF = SUMCST.DEMANDADDUPSECCDRF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN SECINFOSETRF AS SECINF  " + Environment.NewLine;
                selectTxt += "   ON  SECINF.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                // 2010/03/10 >>>
                //selectTxt += "   AND SECINF.SECTIONCODERF = CUSTCL.MNGSECTIONCODERF  " + Environment.NewLine;
                selectTxt += "   AND SECINF.SECTIONCODERF = CUSTCL.CLAIMSECTIONCODERF  " + Environment.NewLine;
                // 2010/03/10 <<<
                selectTxt += "  LEFT JOIN USERGDBDURF AS USERGD  " + Environment.NewLine;
                selectTxt += "   ON  USERGD.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += "   AND USERGD.GUIDECODERF=CUSTCL.SALESAREACODERF  " + Environment.NewLine;
                selectTxt += "   AND USERGD.USERGUIDEDIVCDRF=21  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN EMPLOYEERF AS EMPLOY  " + Environment.NewLine;
                selectTxt += "   ON  EMPLOY.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF  " + Environment.NewLine;
                selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                             "   AND EMPLOY.EMPLOYEECODERF = CUSTCL.CUSTOMERAGENTCDRF" + Environment.NewLine);
                // 2010/03/10 >>>
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                //             "   AND EMPLYE.EMPLOYEECODERF=CUSTCL.BILLCOLLECTERCDRF" + Environment.NewLine);
                selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                             "   AND EMPLOY.EMPLOYEECODERF=CUSTCL.BILLCOLLECTERCDRF" + Environment.NewLine);
                // 2010/03/10 <<<
                #endregion



                #region [Select���쐬]
                //selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  CSTMER.CLAIMCODERF" + Environment.NewLine;
                //selectTxt += " ,CSTMER.CLAIMSECTIONCODERF" + Environment.NewLine;
                //selectTxt += " ,CSTMER.CUSTOMERSNMRF" + Environment.NewLine;
                //selectTxt += " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                //             " ,CSTMER.CUSTOMERAGENTCDRF AS AGENTCD" + Environment.NewLine);
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                //             " ,CSTMER.BILLCOLLECTERCDRF AS AGENTCD" + Environment.NewLine);
                //selectTxt += " ,EMPLYE.NAMERF" + Environment.NewLine;
                //selectTxt += " ,CSTMER.SALESAREACODERF" + Environment.NewLine;
                //selectTxt += " ,USGDBD.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                ////FROM
                //selectTxt += " FROM CUSTOMERRF AS CSTMER" + Environment.NewLine;

                #region [JOIN]
                ////�]�ƈ��}�X�^
                //selectTxt += " LEFT JOIN EMPLOYEERF EMPLYE" + Environment.NewLine;
                //selectTxt += " ON  EMPLYE.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                //             " AND EMPLYE.EMPLOYEECODERF=CSTMER.CUSTOMERAGENTCDRF" + Environment.NewLine);
                //selectTxt += IFBy(_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                //             " AND EMPLYE.EMPLOYEECODERF=CSTMER.BILLCOLLECTERCDRF" + Environment.NewLine);

                ////���[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)
                //selectTxt += " LEFT JOIN USERGDBDURF USGDBD" + Environment.NewLine;
                //selectTxt += " ON  USGDBD.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND USGDBD.GUIDECODERF=CSTMER.SALESAREACODERF" + Environment.NewLine;
                //selectTxt += " AND USGDBD.USERGUIDEDIVCDRF=21" + Environment.NewLine;

                ////���_���ݒ�}�X�^
                //selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                //selectTxt += " ON  SCINST.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SCINST.SECTIONCODERF=CSTMER.CLAIMSECTIONCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #region [WHERE��]
                selectTxt += " WHERE" + Environment.NewLine;

                //��ƃR�[�h
                selectTxt += " SUMCST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_extrInfo_BillBalanceWork.EnterpriseCode);

                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND SUMCST.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND SUMCST.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //���_�R�[�h
                if (_extrInfo_BillBalanceWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _extrInfo_BillBalanceWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        // 2010/03/10 >>>
                        //selectTxt += " AND CUSTCL.MNGSECTIONCODERF IN (" + sectionCodestr + ") ";
                        selectTxt += " AND CUSTCL.CLAIMSECTIONCODERF IN (" + sectionCodestr + ") ";
                        // 2010/03/10 <<<
                    }
                    selectTxt += Environment.NewLine;
                }

                //���Ӑ�R�[�h
                if (_extrInfo_BillBalanceWork.St_ClaimCode != 0)
                {
                    // -- UPD 20101/06/06 ---------------------------------------->>>
                    //selectTxt += " AND SUMCST.CUSTOMERCODERF>=@ST_CUSTOMERCOD" + Environment.NewLine;
                    selectTxt += " AND SUMCST.SUMCLAIMCUSTCODERF>=@ST_CUSTOMERCOD" + Environment.NewLine;
                    // -- UPD 20101/06/06 ----------------------------------------<<<
                    SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCOD", SqlDbType.Int);
                    paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.St_ClaimCode);
                }

                if (_extrInfo_BillBalanceWork.Ed_ClaimCode != 999999999)
                {
                    // -- UPD 20101/06/06 ---------------------------------------->>>
                    //selectTxt += " AND SUMCST.CUSTOMERCODERF<=@ED_CUSTOMERCOD" + Environment.NewLine;
                    selectTxt += " AND SUMCST.SUMCLAIMCUSTCODERF<=@ED_CUSTOMERCOD" + Environment.NewLine;
                    // -- UPD 20101/06/06 ----------------------------------------<<<
                    SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCOD", SqlDbType.Int);
                    paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.Ed_ClaimCode);
                }

                //�̔��G���A�R�[�h
                if (_extrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                {
                    selectTxt += " AND CUSTCL.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                    SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE", SqlDbType.Int);
                    paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.St_SalesAreaCode);
                }

                // -- UPD 20101/06/06 ---------------------------------------->>>
                //if (_extrInfo_BillBalanceWork.Ed_SalesAreaCode != 99)
                if (_extrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                // -- UPD 20101/06/06 ----------------------------------------<<<
                {
                    selectTxt += " AND CUSTCL.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                    SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE", SqlDbType.Int);
                    paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.Ed_SalesAreaCode);
                }

                //�S���҃R�[�h
                if (_extrInfo_BillBalanceWork.St_EmployeeCode != "")
                {
                    if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                        selectTxt += " AND CUSTCL.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                    else if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                        selectTxt += " AND CUSTCL.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                    SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_AGENTCD", SqlDbType.NChar);
                    paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(_extrInfo_BillBalanceWork.St_EmployeeCode);
                }
                if (_extrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                {
                    if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                        selectTxt += " AND ( CUSTCL.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CUSTCL.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                    else if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                        selectTxt += " AND ( CUSTCL.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CUSTCL.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                    SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_AGENTCD", SqlDbType.NChar);
                    paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(_extrInfo_BillBalanceWork.Ed_EmployeeCode);
                }
                // ADD 2008.11.13 >>>
                //selectTxt += "AND CUSTCL.CUSTOMERCODERF IS NOT Null" + Environment.NewLine;
                //selectTxt += "AND CUSTCL.CUSTOMERCODERF !=0" + Environment.NewLine;
                //selectTxt += "AND CUSTCL.CUSTOMERCODERF =CUSTCL.CLAIMCODERF" + Environment.NewLine;
                // ADD 2008.11.13 <<<

                #endregion  //[WHERE��]

                #region [ORDER BY]
                //�o�͏� 0:���Ӑ揇 1:�S���ҏ� 2:�n�揇
                switch (_extrInfo_BillBalanceWork.SortOrderDiv)
                {
                    // -- UPD 2010/06/06 ------------------------->>>
                    //case 0:  //0:���Ӑ揇 -> ���_�|���Ӑ揇
                    //    selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, SUMCST.SUMCLAIMCUSTCODERF, SUMCST.CUSTOMERCODERF ";
                    //    break;
                    //case 1:  //1:�S���ҏ� -> ���_�|�S���ҁ|���Ӑ揇
                    //    if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                    //        selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CUSTCL.CUSTOMERAGENTCDRF, CUSTCL.CUSTOMERCODERF";
                    //    else if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                    //        selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CUSTCL.BILLCOLLECTERCDRF, CUSTCL.CUSTOMERCODERF";
                    //    break;
                    //case 2:  //2:�n�揇 -> ���_�|�n��|���Ӑ揇
                    //    selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CUSTCL.SALESAREACODERF, CUSTCL.CUSTOMERCODERF";
                    //    break;

                    case 1:  //1:���Ӑ揇 -> ���_�|���Ӑ揇
                        selectTxt += " ORDER BY CUSTCL.CLAIMSECTIONCODERF, SUMCST.SUMCLAIMCUSTCODERF, SUMCST.CUSTOMERCODERF ";
                        break;
                    case 2:  //2:�S���ҏ� -> ���_�|�S���ҁ|���Ӑ揇
                        if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                            selectTxt += " ORDER BY CUSTCL.CLAIMSECTIONCODERF, CUSTCL.CUSTOMERAGENTCDRF, CUSTCL.CUSTOMERCODERF";
                        else if (_extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                            selectTxt += " ORDER BY CUSTCL.CLAIMSECTIONCODERF, CUSTCL.BILLCOLLECTERCDRF, CUSTCL.CUSTOMERCODERF";
                        break;
                    case 3:  //3:�n�揇 -> ���_�|�n��|���Ӑ揇
                        selectTxt += " ORDER BY CUSTCL.CLAIMSECTIONCODERF, CUSTCL.SALESAREACODERF, CUSTCL.CUSTOMERCODERF";
                        break;
                    // -- UPD 2010/06/06 -------------------------<<<
                }
                #endregion  //[ORDER BY]

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    SumRsltInfo_BillBalanceWork ResultWork = new SumRsltInfo_BillBalanceWork();

                    #region [���o����-�l�Z�b�g]

                    // 2010/03/10 >>>
                    //ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MNGSECTIONCODERF"));�@ // �����������_
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSECTIONCODERF"));�@ // �����搿�����_
                    // 2010/03/10 <<<
                    ResultWork.SumSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMSECCODERF"));�@         // �����������_  // ADD 2010/06/06
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF")); // �����������_����
                    ResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCLAIMCUSTCODERF")); �@�@�@// ����������R�[�h
                    ResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUMCUSTOMERSNMRF"));         // ���������於��
                    ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));           // �������Ӑ�R�[�h
                    ResultWork.Customersnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));            // �������Ӑ於��
                    ResultWork.AgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGENTCD"));                   // �]�ƈ��敪
                    ResultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));                       // ����
                    ResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));      // �n��敪
                    ResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));       // �n�於��
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchCustProc Exception=" + ex.Message);
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
        #endregion  //[SearchCustProc]

        #region [SearchDepsitProc]
        /// <summary>
        /// �����߂̓����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="custAccRecWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����߂̓����f�[�^���擾���܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchDepsitProc(ref ArrayList al, ArrayList custAccRecWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // DEPSITMAINRF      DEPMIN �����}�X�^
                // DEPSITDTLRF       DEPDTL �������׃f�[�^

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=51 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=52 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=53 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=54 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=56 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=59 THEN DEPDTL.DEPOSITRF ELSE 0 END)) AS FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,(SUM(DEPDTL.DEPOSITRF)" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=51 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=52 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=53 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=54 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=56 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   -SUM((CASE WHEN DEPDTL.MONEYKINDCODERF=59 THEN DEPDTL.DEPOSITRF ELSE 0 END))" + Environment.NewLine;
                selectTxt += "   ) AS OTHSDEPOSIT" + Environment.NewLine;
                //FROM
                selectTxt += " FROM DEPSITMAINRF AS DEPMIN" + Environment.NewLine;
                //JOIN
                selectTxt += " INNER JOIN DEPSITDTLRF DEPDTL" + Environment.NewLine;
                selectTxt += " ON  DEPDTL.ENTERPRISECODERF=DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND DEPDTL.ACPTANODRSTATUSRF=DEPMIN.ACPTANODRSTATUSRF" + Environment.NewLine;
                selectTxt += " AND DEPDTL.DEPOSITSLIPNORF=DEPMIN.DEPOSITSLIPNORF" + Environment.NewLine;
                //WHERE
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      DEPMIN.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND DEPMIN.DEPOSITDEBITNOTECDRF = 0" + Environment.NewLine;
                selectTxt += "  AND DEPMIN.CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                selectTxt += "  AND DEPMIN.CLAIMCODERF=@FINDCLAIMCODE" + Environment.NewLine;
                selectTxt += "  AND DEPMIN.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND (DEPMIN.ADDUPADATERF<=@FINDADDUPDATE AND DEPMIN.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                //GROU BY
                selectTxt += " GROUP BY" + Environment.NewLine;
                selectTxt += "   DEPMIN.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "  ,DEPMIN.CLAIMCODERF" + Environment.NewLine;
                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add("@FINDCLAIMCODE", SqlDbType.Int);
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(((CustAccRecWork)custAccRecWork[0]).EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(((CustAccRecWork)custAccRecWork[0]).CustomerCode);
                findParaClaimCode.Value = SqlDataMediator.SqlSetInt32(((CustAccRecWork)custAccRecWork[0]).ClaimCode);
                findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(((CustAccRecWork)custAccRecWork[0]).AddUpSecCode);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(((CustAccRecWork)custAccRecWork[0]).AddUpDate);
                if (((CustAccRecWork)custAccRecWork[0]).LaMonCAddUpUpdDate == DateTime.MinValue)
                    findParaLastTimeAddUpDate.Value = 20000101;
                else
                    findParaLastTimeAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(((CustAccRecWork)custAccRecWork[0]).LaMonCAddUpUpdDate);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    SumRsltInfo_BillBalanceWork ResultWork = new SumRsltInfo_BillBalanceWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.CashDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));
                    ResultWork.TrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));
                    ResultWork.CheckDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));
                    ResultWork.DraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));
                    ResultWork.OffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));
                    ResultWork.FundTransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));
                    ResultWork.OthsDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHSDEPOSIT"));
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchDepsitProc Exception=" + ex.Message);
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
        #endregion  //[SearchDepsitProc]

        #region [SearchBillBalanceTableProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c���ꗗ�\��߂��܂�
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_extrInfo_BillBalanceWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c���ꗗ�\��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        //private int SearchBillBalanceTableProc(ref ArrayList al, ExtrInfo_BillBalanceWork _extrInfo_BillBalanceWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        private int SearchBillBalanceTableProc(ref ArrayList al, SumExtrInfo_BillBalanceWork _sumextrInfo_BillBalanceWork, SumRsltInfo_BillBalanceWork customerListWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // CUSTACCRECRF      CSTREC ���Ӑ攄�|���z�}�X�^
                // ACCRECDEPOTOTALRF ACCDEP ���|�����W�v�f�[�^
                // CUSTOMERRF        CSTMER ���Ӑ�}�X�^
                // EMPLOYEERF        EMPLYE �]�ƈ��}�X�^
                // USERGDBDURF       USGDBD ���[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)
                // SECINFOSETRF      SCINST ���_���ݒ�}�X�^

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CSTREC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += "  ,(CSTREC.THISSALESPRICRGDSRF+CSTREC.THISSALESPRICDISRF)" + Environment.NewLine;
                selectTxt += "   AS THISRGDSDISPRIC" + Environment.NewLine;
                selectTxt += "  ,CSTREC.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += IFBy(_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                             "  ,CSTMER.CUSTOMERAGENTCDRF AS AGENTCD" + Environment.NewLine);
                selectTxt += IFBy(_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                             "  ,CSTMER.BILLCOLLECTERCDRF AS AGENTCD" + Environment.NewLine);
                selectTxt += "  ,EMPLYE.NAMERF" + Environment.NewLine;
                selectTxt += "  ,CSTMER.SALESAREACODERF" + Environment.NewLine;
                selectTxt += "  ,USGDBD.GUIDENAMERF AS SALESAREANAME" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += "  ,CSTREC.CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.OTHSDEPOSIT" + Environment.NewLine;
                selectTxt += "  ,CSTREC.FUNDTRANSFERDEPOSIT" + Environment.NewLine;

                selectTxt += "  ,SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;
                selectTxt += "  ,CUSTSU.CUSTOMERSNMRF" + Environment.NewLine;
                // -- UPD 2010/06/06 -------------------------------->>>
                //selectTxt += "  ,SUMCST.DEMANDADDUPSECCDRF" + Environment.NewLine;
                selectTxt += "  ,CUSTSU.CLAIMSECTIONCODERF AS DEMANDADDUPSECCDRF" + Environment.NewLine;
                // -- UPD 2010/06/06 --------------------------------<<<

                //FROM
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;

                #region [�f�[�^���o���C��Query]
                //���Ӑ攄�|���z�}�X�^
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    CSTRECSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.CLAIMSNMRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.LASTTIMEACCRECRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMETTLBLCACCRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.OFSTHISTIMESALESRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMESALESRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISSALESPRICRGDSRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISSALESPRICDISRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.OFSTHISSALESTAXRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.AFCALTMONTHACCRECRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.SALESSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMEFEEDMDNRMLRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.THISTIMEDISDMDNRMLRF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.ADDUPYEARMONTHRF  " + Environment.NewLine;
                selectTxt += "   ,CSTRECSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,ACCDEP.FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                selectTxt += "   ,(ACCDEP.OTHSDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "    -ACCDEP.FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                selectTxt += "    ) AS OTHSDEPOSIT" + Environment.NewLine;
                selectTxt += "  FROM CUSTACCRECRF AS CSTRECSUB" + Environment.NewLine;
                
                //���|�����W�v�f�[�^
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     ACCDEPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=51 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS CASHDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=52 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS TRFRDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=53 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS CHECKDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=54 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS DRAFTDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=56 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS OFFSETDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACCDEPSUB.MONEYKINDCODERF=59 THEN ACCDEPSUB.DEPOSITRF ELSE 0 END)) AS FUNDTRANSFERDEPOSIT" + Environment.NewLine;
                selectTxt += "    ,SUM(ACCDEPSUB.DEPOSITRF) AS OTHSDEPOSIT" + Environment.NewLine;
                selectTxt += "   FROM ACCRECDEPOTOTALRF AS ACCDEPSUB" + Environment.NewLine;
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     ACCDEPSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.CUSTOMERCODERF" + Environment.NewLine;
                selectTxt += "    ,ACCDEPSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ) AS ACCDEP" + Environment.NewLine;
                selectTxt += "  ON  ACCDEP.ENTERPRISECODERF=CSTRECSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND ACCDEP.ADDUPSECCODERF=CSTRECSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND ACCDEP.CLAIMCODERF=CSTRECSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  AND ACCDEP.CUSTOMERCODERF=CSTRECSUB.CLAIMCODERF" + Environment.NewLine;
                selectTxt += "  AND ACCDEP.ADDUPDATERF=CSTRECSUB.ADDUPDATERF" + Environment.NewLine;

                //WHERE���̍쐬
                //selectTxt += MakeWhereString(ref sqlCommand, _extrInfo_BillBalanceWork, logicalMode);
                selectTxt += MakeWhereString(ref sqlCommand, _sumextrInfo_BillBalanceWork, customerListWork, logicalMode);
                #endregion  //[�f�[�^���o���C��Query]

                selectTxt += " ) AS CSTREC" + Environment.NewLine;

                #region [JOIN]
                //���Ӑ�}�X�^
                selectTxt += " LEFT JOIN CUSTOMERRF CSTMER" + Environment.NewLine;
                selectTxt += " ON  CSTMER.ENTERPRISECODERF=CSTREC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CSTMER.CUSTOMERCODERF=CSTREC.CLAIMCODERF" + Environment.NewLine;

                //�]�ƈ��}�X�^
                selectTxt += " LEFT JOIN EMPLOYEERF EMPLYE" + Environment.NewLine;
                selectTxt += " ON  EMPLYE.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += IFBy(_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd,
                             " AND EMPLYE.EMPLOYEECODERF=CSTMER.CUSTOMERAGENTCDRF" + Environment.NewLine);
                selectTxt += IFBy(_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd,
                             " AND EMPLYE.EMPLOYEECODERF=CSTMER.BILLCOLLECTERCDRF" + Environment.NewLine);

                //���[�U�[�K�C�h�}�X�^(�{�f�B)(���[�U�ύX��)
                selectTxt += " LEFT JOIN USERGDBDURF USGDBD" + Environment.NewLine;
                selectTxt += " ON  USGDBD.ENTERPRISECODERF=CSTMER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND USGDBD.GUIDECODERF=CSTMER.SALESAREACODERF" + Environment.NewLine;
                selectTxt += " AND USGDBD.USERGUIDEDIVCDRF=21" + Environment.NewLine;
                
                //�������Ӑ�}�X�^
                selectTxt += " RIGHT JOIN SUMCUSTSTRF SUMCST" + Environment.NewLine;
                selectTxt += " ON  SUMCST.ENTERPRISECODERF = CSTREC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUMCST.CUSTOMERCODERF = CSTREC.CLAIMCODERF" + Environment.NewLine;
                //selectTxt += " AND SUMCST.DEMANDADDUPSECCDRF= CSTREC.ADDUPSECCODERF" + Environment.NewLine;  //DEL 2010/06/06

                //���Ӑ�}�X�^(�������Ӑ�p)
                selectTxt += " LEFT JOIN CUSTOMERRF CUSTSU" + Environment.NewLine;
                selectTxt += " ON  CUSTSU.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND CUSTSU.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;

                //���_���ݒ�}�X�^
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF=CSTREC.ENTERPRISECODERF" + Environment.NewLine;
                // -- UPD 2010/06/06 ------------------------------------>>>
                //selectTxt += " AND SCINST.SECTIONCODERF=CSTREC.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=SUMCST.DEMANDADDUPSECCDRF" + Environment.NewLine;
                // -- UPD 2010/06/06 ------------------------------------<<<

                #endregion  //[JOIN]

                #region [WHERE��]
                selectTxt += " WHERE" + Environment.NewLine;

                //��ƃR�[�h
                selectTxt += " SUMCST.ENTERPRISECODERF=@CSTRECENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@CSTRECENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sumextrInfo_BillBalanceWork.EnterpriseCode);

                //�̔��G���A�R�[�h
                if (_sumextrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                {
                    selectTxt += " AND CSTMER.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                    SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE", SqlDbType.Int);
                    paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_sumextrInfo_BillBalanceWork.St_SalesAreaCode);
                }

                // -- UPD 2010/06/06 ---------------------------------------->>>
                //if (_sumextrInfo_BillBalanceWork.Ed_SalesAreaCode != 99)
                if (_sumextrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                // -- UPD 2010/06/06 ----------------------------------------<<<
                {
                    selectTxt += " AND CSTMER.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                    SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE", SqlDbType.Int);
                    paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(_sumextrInfo_BillBalanceWork.Ed_SalesAreaCode);
                }

                //�S���҃R�[�h
                if (_sumextrInfo_BillBalanceWork.St_EmployeeCode != "")
                {
                    if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                        selectTxt += " AND CSTMER.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                    else if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                        selectTxt += " AND CSTMER.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                    SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_AGENTCD", SqlDbType.NChar);
                    paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(_sumextrInfo_BillBalanceWork.St_EmployeeCode);
                }
                if (_sumextrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                {
                    if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                        selectTxt += " AND ( CSTMER.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CSTMER.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                    else if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                        selectTxt += " AND ( CSTMER.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CSTMER.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                    SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_AGENTCD", SqlDbType.NChar);
                    paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(_sumextrInfo_BillBalanceWork.Ed_EmployeeCode);
                }
                // DEL UI���ŏ�������悤�ɏC��
                ////0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:��׽��ϲŽ 5:0��ϲŽ 6:ϲŽ�̂�
                //switch (_extrInfo_BillBalanceWork.OutMoneyDiv)
                //{
                //    case 0:
                //        break;
                //    case 1:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF>=0" + Environment.NewLine;
                //        break;
                //    case 2:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF>0" + Environment.NewLine;
                //        break;
                //    case 3:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF=0" + Environment.NewLine;
                //        break;
                //    case 4:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF!=0" + Environment.NewLine;
                //        break;
                //    case 5:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF<=0" + Environment.NewLine;
                //        break;
                //    case 6:
                //        selectTxt += " AND CSTREC.AFCALTMONTHACCRECRF<0" + Environment.NewLine;
                //        break;
                //}

                // ADD 2009.02.10 >>>
                selectTxt += " AND (CSTREC.LASTTIMEACCRECRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.THISTIMEFEEDMDNRMLRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.THISTIMEDISDMDNRMLRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.THISTIMEDMDNRMLRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.OFSTHISTIMESALESRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.OFSTHISSALESTAXRF!=0" + Environment.NewLine;
                selectTxt += "      OR CSTREC.SALESSLIPCOUNTRF!=0)" + Environment.NewLine;
                // ADD 2009.02.10 <<<
                #endregion  //[WHERE��]

                #region [ORDER BY]
                //�o�͏� 0:���Ӑ揇 1:�S���ҏ� 2:�n�揇
                switch (_sumextrInfo_BillBalanceWork.SortOrderDiv)
                {
                    case 0:  //0:���Ӑ揇 -> ���_�|���Ӑ揇
                        selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, SUMCST.SUMCLAIMCUSTCODERF";
                        break;
                    case 1:  //1:�S���ҏ� -> ���_�|�S���ҁ|���Ӑ揇
                        if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                            selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CSTMER.CUSTOMERAGENTCDRF, SUMCST.SUMCLAIMCUSTCODERF";
                        else if (_sumextrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                            selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CSTMER.BILLCOLLECTERCDRF, SUMCST.SUMCLAIMCUSTCODERF";
                        break;
                    case 2:  //2:�n�揇 -> ���_�|�n��|���Ӑ揇
                        selectTxt += " ORDER BY SUMCST.DEMANDADDUPSECCDRF, CSTMER.SALESAREACODERF, SUMCST.SUMCLAIMCUSTCODERF";
                        break;
                }
                #endregion  //[ORDER BY]

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRsltWork(ref myReader, _sumextrInfo_BillBalanceWork));
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchBillBalanceTableProc Exception=" + ex.Message);
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
        #endregion  //[SearchBillBalanceTableProc]

        #region [WHERE�吶������]
        /// <summary>
        /// WHERE�吶������
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_extrInfo_BillBalanceWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns></returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SumExtrInfo_BillBalanceWork _sumextrInfo_BillBalanceWork, SumRsltInfo_BillBalanceWork customerListWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " CSTRECSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_sumextrInfo_BillBalanceWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND CSTRECSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND CSTRECSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //�e���R�[�h�݂̂�ΏۂƂ���(���Ӑ�R�[�h=0�̂ݑΏ�)
            retstring += " AND CSTRECSUB.CUSTOMERCODERF=0" + Environment.NewLine;
            // �C�� 2009.01.27 >>>
            ////���_�R�[�h
            //if (_extrInfo_BillBalanceWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _extrInfo_BillBalanceWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }
            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND CSTRECSUB.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}

            // -- UPD 2010/06/06 ----------------------------------->>>
            //�������Ӑ�̔��|���o���ɉ�ʂ̋��_�R�[�h�������ɂ��Ȃ�

            //if (customerListWork.AddUpSecCode != null)
            //{
            //    retstring += " AND CSTRECSUB.ADDUPSECCODERF=@ADDUPSECCODE" + Environment.NewLine;
            //    SqlParameter paraAddupsecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
            //    paraAddupsecCode.Value = SqlDataMediator.SqlSetString(customerListWork.AddUpSecCode);

            //}
            // -- UPD 2010/06/06 -----------------------------------<<<

            // �C�� 2009.01.27 <<<
            //�Ώ۔N��
            if (_sumextrInfo_BillBalanceWork.AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND CSTRECSUB.ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_sumextrInfo_BillBalanceWork.AddUpYearMonth);
            }

            //������R�[�h
            //if (_extrInfo_BillBalanceWork.St_ClaimCode != 0)
            //{
            //    retstring += " AND CSTRECSUB.CLAIMCODERF>=@ST_CLAIMCODE" + Environment.NewLine;
            //    SqlParameter paraSt_ClaimCode = sqlCommand.Parameters.Add("@ST_CLAIMCODE", SqlDbType.Int);
            //    paraSt_ClaimCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.St_ClaimCode);
            //}
            //if (_extrInfo_BillBalanceWork.Ed_ClaimCode != 999999999)
            //{
            //    retstring += " AND CSTRECSUB.CLAIMCODERF<=@ED_CLAIMCODE" + Environment.NewLine;
            //    SqlParameter paraEd_ClaimCode = sqlCommand.Parameters.Add("@ED_CLAIMCODE", SqlDbType.Int);
            //    paraEd_ClaimCode.Value = SqlDataMediator.SqlSetInt32(_extrInfo_BillBalanceWork.Ed_ClaimCode);
            //}
            if (customerListWork.ClaimCode != 0)
            {
                retstring += " AND CSTRECSUB.CLAIMCODERF=@CLAIMCODE" + Environment.NewLine;
                SqlParameter paraClaimCode = sqlCommand.Parameters.Add("@CLAIMCODE", SqlDbType.Int);
                paraClaimCode.Value = SqlDataMediator.SqlSetInt32(customerListWork.CustomerCode);
            }
            #endregion  //WHERE���쐬

            return retstring.ToString();
        }
        #endregion  //[WHERE�吶������]

        #region [���|�c���ꗗ�\���o���ʃN���X�i�[����]
        /// <summary>
        /// ���|�c���ꗗ�\���o���ʃN���X�i�[���� Reader �� RsltInfo_BillBalanceWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="extrInfo_BillBalanceWork">extrInfo_BillBalanceWork</param>
        /// <returns>RsltInfo_BillBalanceWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private SumRsltInfo_BillBalanceWork CopyToRsltWork(ref SqlDataReader myReader, SumExtrInfo_BillBalanceWork _sumextrInfo_BillBalanceWork)
        {
            SumRsltInfo_BillBalanceWork ResultWork = new SumRsltInfo_BillBalanceWork();

            #region [���o����-�l�Z�b�g]
            ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            ResultWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUMCLAIMCUSTCODERF"));
            ResultWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            ResultWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            ResultWork.Customersnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            ResultWork.LastTimeAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEACCRECRF"));
            ResultWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
            ResultWork.ThisTimeTtlBlcAcc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCACCRF"));
            ResultWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
            ResultWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
            ResultWork.ThisRgdsDisPric = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISRGDSDISPRIC"));
            ResultWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
            ResultWork.AfCalTMonthAccRec = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALTMONTHACCRECRF"));
            ResultWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
            ResultWork.AgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AGENTCD"));
            ResultWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
            ResultWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
            ResultWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAME"));
            ResultWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
            ResultWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));


            if (_sumextrInfo_BillBalanceWork.DepoDtlDiv == (int)DepoDtlDiv.DepoDtlON)
            {
                ResultWork.CashDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CASHDEPOSIT"));
                ResultWork.TrfrDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TRFRDEPOSIT"));
                ResultWork.CheckDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CHECKDEPOSIT"));
                ResultWork.DraftDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DRAFTDEPOSIT"));
                ResultWork.OffsetDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETDEPOSIT"));
                ResultWork.FundTransferDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("FUNDTRANSFERDEPOSIT"));
                ResultWork.OthsDeposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OTHSDEPOSIT"));
            }
            #endregion  //[���o����-�l�Z�b�g]

            return ResultWork;
        }
        #endregion  //[���|�c���ꗗ�\���o���ʃN���X�i�[����]

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.15</br>
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
        #endregion  //[�R�l�N�V������������]

        // --- ADD START 3H ������ 2020/04/10 ---------->>>>>
        #region [SearchCustAccRecDate]
        /// <summary>
        /// �v��N�����擾
        /// </summary>
        /// <param name="extrInfo_BillBalanceWork">���|�c���ꗗ�\���o����</param>
        /// <param name="custAccRecDateDic">�����斈�̌����X�V�������f�B�N�V���i��</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/04/10</br>
        /// </remarks>
        private int SearchCustAccRecDate(SumExtrInfo_BillBalanceWork extrInfo_BillBalanceWork, ref Dictionary<int, CustAccRecDateInfo> custAccRecDateDic, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  CLAIMCODERF," + Environment.NewLine;
                    sqlText += "  ADDUPDATERF," + Environment.NewLine;
                    sqlText += "  LAMONCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " FROM CUSTACCRECRF AS ACCREC WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " RIGHT JOIN SUMCUSTSTRF SUMCST" + Environment.NewLine;
                    sqlText += " ON  SUMCST.ENTERPRISECODERF = ACCREC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SUMCST.CUSTOMERCODERF = ACCREC.CLAIMCODERF" + Environment.NewLine;
                    sqlText += " WHERE ACCREC.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND ACCREC.ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "    AND ACCREC.CUSTOMERCODERF=0" + Environment.NewLine;
                    // ������R�[�h(�J�n)
                    if (extrInfo_BillBalanceWork.St_ClaimCode != 0)
                    {
                        sqlText += " AND SUMCST.SUMCLAIMCUSTCODERF>=@ST_CUSTOMERCOD" + Environment.NewLine;
                        SqlParameter paraSt_CustomerCode = sqlCommand.Parameters.Add("@ST_CUSTOMERCOD", SqlDbType.Int);
                        paraSt_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_BillBalanceWork.St_ClaimCode);
                    }
                    // ������R�[�h(�I��)
                    if (extrInfo_BillBalanceWork.Ed_ClaimCode != 999999999)
                    {
                        sqlText += " AND SUMCST.SUMCLAIMCUSTCODERF<=@ED_CUSTOMERCOD" + Environment.NewLine;
                        SqlParameter paraEd_CustomerCode = sqlCommand.Parameters.Add("@ED_CUSTOMERCOD", SqlDbType.Int);
                        paraEd_CustomerCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_BillBalanceWork.Ed_ClaimCode);
                    }
                    sqlText += " ORDER BY CLAIMCODERF" + Environment.NewLine;

                    // Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(extrInfo_BillBalanceWork.EnterpriseCode);
                    findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(extrInfo_BillBalanceWork.AddUpYearMonth);

                    sqlCommand.CommandText = sqlText;
                    myReader = sqlCommand.ExecuteReader();
                    int claimCd;

                    while (myReader.Read())
                    {
                        CustAccRecDateInfo custAccRecDateInfo = new CustAccRecDateInfo();
                        // ������R�[�h
                        claimCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                        // �O�񌎎��X�V�N����
                        custAccRecDateInfo.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
                        // ���񌎎��X�V�N����
                        custAccRecDateInfo.AddUpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPDATERF"));
                        
                        if (!custAccRecDateDic.ContainsKey(claimCd))
                        {
                            custAccRecDateDic.Add(claimCd, custAccRecDateInfo);
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
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchCustAccRecDate Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region [SearchSalesProc]
        /// <summary>
        /// ����f�[�^���擾���܂��B
        /// </summary>
        /// <param name="billBalanceWork">��������</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="extrInfo_BillBalanceWork">���|�c���ꗗ�\(����)���o����</param>
        /// <param name="isCheckOut">�����t���b�O</param>
        /// <param name="laMonCAddUpUpdDate">�O�񌎎��X�V�N����</param>
        /// <param name="custAccRecDateDic">�����斈�̌����X�V�������f�B�N�V���i��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/04/10</br>
        private int SearchSalesProc(ref SumRsltInfo_BillBalanceWork billBalanceWork, ref SqlConnection sqlConnection, SumExtrInfo_BillBalanceWork extrInfo_BillBalanceWork, bool isCheckOut, DateTime laMonCAddUpUpdDate, Dictionary<int, CustAccRecDateInfo> custAccRecDateDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            CustAccRecWork custAccRecWork = new CustAccRecWork();

            // ��ƃR�[�h
            string enterpriseCode = extrInfo_BillBalanceWork.EnterpriseCode;

            // �ŗ�1
            double taxRate1 = extrInfo_BillBalanceWork.TaxRate1;

            // �ŗ�2
            double taxRate2 = extrInfo_BillBalanceWork.TaxRate2;

            // �v��N����
            int addUpDate = Convert.ToInt32(extrInfo_BillBalanceWork.AddUpDate.ToString("yyyyMMdd"));

            // �O�񌎎��X�V�N����
            int laMonCAddUpDate = 0;

            // ����N�����擾�t���O
            bool getFirstDateFlag = false;

            // ���Џ��.����N����
            int per2yearAddUpdate = 0;

            // ����œ]�ŕ������X�g
            List<int> consTaxLayMethodList = new List<int>();

            #region ���Џ��.����N�����擾
            // ���Џ��擾
            CompanyInfWork paraCompanyInfWork = new CompanyInfWork();
            CompanyInfDB companyInfDB = new CompanyInfDB();
            ArrayList arrayList = new ArrayList();

            paraCompanyInfWork.EnterpriseCode = enterpriseCode;

            status = companyInfDB.Search(out arrayList, paraCompanyInfWork, ref sqlConnection);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                //�Y���f�[�^�Ȃ� status���N���A������
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                throw new Exception("���Џ��擾���s�B");
            }

            paraCompanyInfWork = (CompanyInfWork)arrayList[0];

            // ���Џ��.����N������1�N�O�̓��̐ݒ�
            if (paraCompanyInfWork.CompanyBiginDate != 0)
            {
                DateTime dt = DateTime.ParseExact(paraCompanyInfWork.CompanyBiginDate.ToString(), "yyyyMMdd", null);
                DateTime dt1YearBefore = dt.AddYears(-1);
                DateTime dt1DayBefore = dt1YearBefore.AddDays(-1);
                getFirstDateFlag = Int32.TryParse(dt1DayBefore.ToString("yyyyMMdd"), out per2yearAddUpdate);
            }
            #endregion

            string sqlText = string.Empty;

            // �����X�V���s�����ꍇ
            if (isCheckOut)
            {
                if (custAccRecDateDic.ContainsKey(billBalanceWork.CustomerCode))
                {
                    laMonCAddUpDate = custAccRecDateDic[billBalanceWork.CustomerCode].LaMonCAddUpUpdDate;
                    addUpDate = custAccRecDateDic[billBalanceWork.CustomerCode].AddUpDate;
                }
            }
            // �����X�V���s��Ȃ��ꍇ
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
                    #region �� �W�v���R�[�h�W�v����
                    sqlText = string.Empty;
                    #region SELECT���쐬
                    #region SELECT
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "ACCREC.FRACTIONPROCCDRF,--�[�������敪" + Environment.NewLine;
                    sqlText += "ACCREC.FRACTIONPROCUNITRF,--�[�������P��" + Environment.NewLine;
                    sqlText += "ACCREC.SALESNETPRICERF + ACCREC.RETSALESNETPRICERF + ACCREC.SALESDISTTLTAXEXCRF AS OFSTHISTIMESALESRF,    -- ���E�㍡�񔄏���z" + Environment.NewLine;
                    sqlText += "-- �� �� ����" + Environment.NewLine;
                    sqlText += "ACCREC.SALESNETPRICERF AS THISTIMESALESRF," + Environment.NewLine;
                    sqlText += "-- �� �� �ԕi" + Environment.NewLine;
                    sqlText += "ACCREC.RETSALESNETPRICERF AS THISSALESPRICRGDSRF," + Environment.NewLine;
                    sqlText += "-- �� �� �l��" + Environment.NewLine;
                    sqlText += "ACCREC.SALESDISTTLTAXEXCRF AS THISSALESPRICDISRF," + Environment.NewLine;
                    sqlText += "ACCREC.SALESSLIPCOUNT AS SALESSLIPCOUNTRF,             --����`�[����" + Environment.NewLine;
                    sqlText += "ACCREC.SALESCNSTAXFRCPROCCDRF AS FRACTIONPROCCDRF,     --�[�������敪" + Environment.NewLine;
                    sqlText += "ACCREC.SLIPSALESPRICECONSTAX AS SLIPSALESPRICECONSTAX, --�`�[�]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "ACCREC.DTLSALESPRICECONSTAX AS DTLSALESPRICECONSTAX,   --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "ACCREC.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    //sqlText += "ACCREC.CONSTAXRATERF" + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    sqlText += "ACCREC.CONSTAXRATERF," + Environment.NewLine;
                    sqlText += "ACCREC.TAXATIONDIVCDRF --�ېŋ敪" + Environment.NewLine;
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "(" + Environment.NewLine;
                    #endregion

                    #region SUB�N�G��
                    sqlText += "  SELECT" + Environment.NewLine;
                    sqlText += "   CLAIM.SALESCNSTAXFRCPROCCDRF AS SALESCNSTAXFRCPROCCDRF," + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCCDRF," + Environment.NewLine;
                    sqlText += "   SALESPROC.FRACTIONPROCUNITRF," + Environment.NewLine;
                    sqlText += "   COUNT(SALE.SALESSLIPNUMRF) SALESSLIPCOUNT," + Environment.NewLine;
                    sqlText += "   -- �� �� ����" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =0 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS SALESNETPRICERF," + Environment.NewLine;
                    sqlText += "   -- �� �� �ԕi" + Environment.NewLine;
                    sqlText += "   SUM((CASE WHEN SALE.SALESSLIPCDRF =1 THEN SALE.SALESNETPRICERF ELSE 0 END)) AS RETSALESNETPRICERF,              --�ԕi�������z" + Environment.NewLine;
                    sqlText += "   -- �� �� �l��" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SALESDISTTLTAXEXCRF) AS SALESDISTTLTAXEXCRF,      --�l�����z�v�i�Ŕ����j" + Environment.NewLine;
                    sqlText += "   SUM(SALE.SLIPSALESPRICECONSTAX) AS SLIPSALESPRICECONSTAX,  --�`�[�]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "   SUM(SALE.DTLSALESPRICECONSTAX) AS DTLSALESPRICECONSTAX,    --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "   SALE.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    // sqlText += "   SALE.CONSTAXRATERF" + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    sqlText += "   SALE.CONSTAXRATERF," + Environment.NewLine;
                    sqlText += "   SALE.TAXATIONDIVCDRF --�ېŋ敪" + Environment.NewLine;
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    sqlText += "  FROM" + Environment.NewLine;
                    sqlText += "  (" + Environment.NewLine;
                    sqlText += "     SELECT" + Environment.NewLine;
                    sqlText += "      SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SEARCHCUST.CLAIMCODERF IS NOT NULL) THEN SEARCHCUST.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ADDUPADATERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "      SUBSALE.CONSTAXLAYMETHODRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.DEBITNOTEDIVRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPCDRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                    sqlText += "      SUBSALE.DEMANDADDUPSECCDRF," + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    //sqlText += "      SUBSALE.SALESNETPRICERF + SALESDTL.DISSALESTAXEXCGYO AS SALESNETPRICERF," + Environment.NewLine;
                    //sqlText += "      SUBSALE.SALESDISTTLTAXEXCRF -  SALESDTL.DISSALESTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =0 ) THEN (SUBSALE.SALESTOTALTAXINCRF - SUBSALE.SALESTOTALTAXEXCRF) ELSE 0 END) AS SLIPSALESPRICECONSTAX," + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    sqlText += "      (CASE WHEN (SALESDTL.SALESSLIPCDRF =0) THEN SALESDTL.SALESMONEY + SALESDTL.DISSALESTAXEXCGYO WHEN (SALESDTL.SALESSLIPCDRF =1) THEN SALESDTL.RETSALESMONEY + SALESDTL.DISSALESTAXEXCGYO ELSE 0 END) AS SALESNETPRICERF," + Environment.NewLine;
                    sqlText += "      SALESDTL.DISGOODSSTAXEXCGYO AS SALESDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SALESDTL.TAXATIONDIVCDRF AS TAXATIONDIVCDRF, --�ېŋ敪" + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =0 AND SALESDTL.TAXATIONDIVCDRF = 0) THEN (SUBSALE.SALESTOTALTAXINCRF - SUBSALE.SALESTOTALTAXEXCRF) ELSE 0 END) AS SLIPSALESPRICECONSTAX," + Environment.NewLine;
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    sqlText += "      (CASE WHEN (SUBSALE.CONSTAXLAYMETHODRF =1 ) THEN DTLSALESPRICECONSTAX ELSE 0 END) AS DTLSALESPRICECONSTAX," + Environment.NewLine;
                    sqlText += "      SUBSALE.CONSTAXRATERF" + Environment.NewLine;
                    sqlText += "     FROM" + Environment.NewLine;
                    sqlText += "      SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "    LEFT JOIN CUSTOMERRF AS SEARCHCUST WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SEARCHCUST.ENTERPRISECODERF " + Environment.NewLine;
                    sqlText += "     AND SUBSALE.CUSTOMERCODERF = SEARCHCUST.CUSTOMERCODERF " + Environment.NewLine;
                    sqlText += "    LEFT JOIN" + Environment.NewLine;
                    sqlText += "    (" + Environment.NewLine;
                    sqlText += "      SELECT" + Environment.NewLine;
                    sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    sqlText += "       DTL.TAXATIONDIVCDRF,--�ېŋ敪" + Environment.NewLine;
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    sqlText += "       --���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "       SUM(DTL.SALESPRICECONSTAXRF) AS DTLSALESPRICECONSTAX,-- ���ד]�ŏ���Ŋz" + Environment.NewLine;
                    sqlText += "       --�s�l��" + Environment.NewLine;

                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    //sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO-- �Ŕ��l�����z(�s�l��)" + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF =0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISSALESTAXEXCGYO,-- �Ŕ��l�����z(�s�l��)" + Environment.NewLine;
                    sqlText += "       --���i�l�����z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 2 AND DTL.SHIPMENTCNTRF <>0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS DISGOODSSTAXEXCGYO,-- �Ŕ��l�����z(���i�l��)" + Environment.NewLine;
                    sqlText += "       --������z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 0 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS SALESMONEY,-- ������z" + Environment.NewLine;
                    sqlText += "       --�ԕi���z" + Environment.NewLine;
                    sqlText += "       SUM(CASE WHEN (DTL.SALESSLIPCDDTLRF = 1 ) THEN DTL.SALESMONEYTAXEXCRF ELSE 0 END) AS RETSALESMONEY-- �ԕi���z" + Environment.NewLine;
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    sqlText += "      FROM" + Environment.NewLine;
                    sqlText += "       SALESDETAILRF AS DTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "      LEFT JOIN SALESSLIPRF AS SALES WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += "       ON  SALES.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "       AND SALES.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "       AND SALES.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "      GROUP BY" + Environment.NewLine;
                    sqlText += "       SALES.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "       SALES.ACPTANODRSTATUSRF," + Environment.NewLine;
                    sqlText += "       SALES.SALESSLIPNUMRF," + Environment.NewLine;

                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    // sqlText += "       SALES.SALESSLIPCDRF" + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    sqlText += "       SALES.SALESSLIPCDRF," + Environment.NewLine;
                    sqlText += "       DTL.TAXATIONDIVCDRF --�ېŋ敪" + Environment.NewLine;
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    sqlText += "    ) AS SALESDTL" + Environment.NewLine;
                    sqlText += "     ON  SUBSALE.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                    sqlText += "     AND SUBSALE.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                    sqlText += "  ) AS SALE" + Environment.NewLine;
                    #endregion

                    #region JOIN��
                    sqlText += "LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON SALE.ENTERPRISECODERF = CUST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALE.CUSTOMERCODERF = CUST.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON SALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALE.CLAIMCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN SALESPROCMONEYRF AS SALESPROC WITH(READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " ON  CLAIM.ENTERPRISECODERF=SALESPROC.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SALESPROC.FRACPROCMONEYDIVRF=1" + Environment.NewLine;
                    sqlText += " AND CLAIM.SALESCNSTAXFRCPROCCDRF=SALESPROC.FRACTIONPROCCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN SUMCUSTSTRF AS SUMCST" + Environment.NewLine;
                    sqlText += " ON  SUMCST.ENTERPRISECODERF = SALE.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND SUMCST.CUSTOMERCODERF = SALE.CLAIMCODERF" + Environment.NewLine;
                    sqlText += "LEFT JOIN CUSTOMERRF AS CUSTSU" + Environment.NewLine;
                    sqlText += " ON  CUSTSU.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " AND CUSTSU.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;
                    #endregion

                    #region WHERE��
                    sqlText += "WHERE SALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "   AND SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "   AND(SALE.ADDUPADATERF<=@FINDADDUPDATE AND SALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                    sqlText += "   AND SALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                    sqlText += "   AND SALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                    sqlText += "   AND SALE.DEBITNOTEDIVRF=0" + Environment.NewLine;

                    #region �̔��G���A�R�[�h
                    if (extrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                    {
                        sqlText += "   AND CUSTSU.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                        SqlParameter paraSt_SalesAreaCode = sqlCommand.Parameters.Add("@ST_SALESAREACODE", SqlDbType.Int);
                        paraSt_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_BillBalanceWork.St_SalesAreaCode);
                    }
                    if (extrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                    {
                        sqlText += "   AND CUSTSU.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                        SqlParameter paraEd_SalesAreaCode = sqlCommand.Parameters.Add("@ED_SALESAREACODE", SqlDbType.Int);
                        paraEd_SalesAreaCode.Value = SqlDataMediator.SqlSetInt32(extrInfo_BillBalanceWork.Ed_SalesAreaCode);
                    }
                    #endregion

                    #region �S���҃R�[�h
                    if (extrInfo_BillBalanceWork.St_EmployeeCode != "")
                    {
                        if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                            sqlText += "   AND CUSTSU.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                        else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                            sqlText += "   AND CUSTSU.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                        SqlParameter paraSt_EmployeeCode = sqlCommand.Parameters.Add("@ST_AGENTCD", SqlDbType.NChar);
                        paraSt_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_BillBalanceWork.St_EmployeeCode);
                    }

                    if (extrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                    {
                        if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                            sqlText += "   AND ( CUSTSU.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CUSTSU.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                        else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                            sqlText += "   AND ( CUSTSU.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CUSTSU.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                        SqlParameter paraEd_EmployeeCode = sqlCommand.Parameters.Add("@ED_AGENTCD", SqlDbType.NChar);
                        paraEd_EmployeeCode.Value = SqlDataMediator.SqlSetString(extrInfo_BillBalanceWork.Ed_EmployeeCode);
                    }
                    #endregion
                    #endregion

                    #region GROUP BY��
                    sqlText += "GROUP BY" + Environment.NewLine;
                    sqlText += " CLAIM.SALESCNSTAXFRCPROCCDRF,--�������Œ[�������R�[�h" + Environment.NewLine;
                    sqlText += " SALESPROC.FRACTIONPROCUNITRF,--�[�������P��" + Environment.NewLine;
                    sqlText += " SALESPROC.FRACTIONPROCCDRF,  --�[�������敪" + Environment.NewLine;
                    sqlText += " SALE.CONSTAXLAYMETHODRF," + Environment.NewLine;

                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                    // sqlText += " SALE.CONSTAXRATERF" + Environment.NewLine;
                    //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    sqlText += " SALE.CONSTAXRATERF," + Environment.NewLine;
                    sqlText += " SALE.TAXATIONDIVCDRF" + Environment.NewLine;
                    //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                    sqlText += ") AS ACCREC" + Environment.NewLine;
                    #endregion
                    #endregion

                    sqlCommand.CommandText = sqlText;

                    #region Prameter�I�u�W�F�N�g�̍쐬
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastCAddUpUpdDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(billBalanceWork.CustomerCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetInt32(addUpDate);

                    if (getFirstDateFlag && (per2yearAddUpdate > 20000101))
                    {
                        if (laMonCAddUpDate < per2yearAddUpdate)
                        {
                            findParaLastCAddUpUpdDate.Value = per2yearAddUpdate;
                        }
                        else
                        {
                            findParaLastCAddUpUpdDate.Value = laMonCAddUpDate;
                        }
                    }
                    else
                    {
                        if (laMonCAddUpDate < 20000101)
                        {
                            findParaLastCAddUpUpdDate.Value = per2yearAddUpdate;
                        }
                        else
                        {
                            findParaLastCAddUpUpdDate.Value = laMonCAddUpDate;
                        }
                    }
                    #endregion

                    myReader = sqlCommand.ExecuteReader();
                    // �[�������P��
                    double fractionProcUnit = 0;
                    // �`�[�]�ŁE���ד]�ŏ����
                    long totalSalesPricTax = 0;

                    while (myReader.Read())
                    {
                        #region �W�v���R�[�h�Z�b�g
                        custAccRecWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); //�[�������敪
                        fractionProcUnit = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACTIONPROCUNITRF")); // �[�������P��
                        custAccRecWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));// ����œ]�ŕ���
                        custAccRecWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));         // �ŗ�

                        // ������Ŋz
                        if (custAccRecWork.ConsTaxLayMethod == 0)
                        {
                            totalSalesPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SLIPSALESPRICECONSTAX"));
                        }
                        else if (custAccRecWork.ConsTaxLayMethod == 1)
                        {
                            totalSalesPricTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DTLSALESPRICECONSTAX"));
                        }
                        else
                        {
                            totalSalesPricTax = 0;
                        }
                        // �����E
                        custAccRecWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));     // ���E�㍡�񔄏���z

                        // ������
                        custAccRecWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));            // ���񔄏���z 

                        // ���ԕi
                        custAccRecWork.ThisSalesPricRgds = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICRGDSRF"));    // ����ԕi���z

                        // ���l��
                        custAccRecWork.ThisSalesPricDis = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESPRICDISRF"));      // ���񔄏�l�����z

                        // ����`�[����
                        custAccRecWork.SalesSlipCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCOUNTRF"));
                        //---ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j--->>>>>
                        // �ېŋ敪
                        int taxationDivCdRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                        //---ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j---<<<<<
                        #endregion

                        #region �ŕʓ����
                        // �ŗ�1
                        //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                        //if (custAccRecWork.ConsTaxLayMethod != 9 && custAccRecWork.ConsTaxRate == taxRate1)
                        //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                        //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                        if ((custAccRecWork.ConsTaxLayMethod != 9 && taxationDivCdRF != 1) && custAccRecWork.ConsTaxRate == taxRate1)
                        //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                        {
                            // ����z(�v�ŗ�1)
                            billBalanceWork.TotalThisTimeSalesTaxRate1 += custAccRecWork.ThisTimeSales;
                            // �ԕi�l��(�v�ŗ�1)
                            billBalanceWork.TotalThisRgdsDisPricTaxRate1 -= custAccRecWork.ThisSalesPricRgds + custAccRecWork.ThisSalesPricDis;
                            // ������z(�v�ŗ�1)
                            billBalanceWork.TotalPureSalesTaxRate1 += custAccRecWork.OfsThisTimeSales;
                            // �����(�v�ŗ�1)
                            if (custAccRecWork.ConsTaxLayMethod == 0 || custAccRecWork.ConsTaxLayMethod == 1)
                            {
                                billBalanceWork.TotalSalesPricTaxTaxRate1 += totalSalesPricTax;
                            }
                            // ����(�v�ŗ�1)
                            billBalanceWork.TotalSalesSlipCountTaxRate1 += custAccRecWork.SalesSlipCount;
                        }
                        // �ŗ�2
                        //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                        //else if (custAccRecWork.ConsTaxLayMethod != 9 && custAccRecWork.ConsTaxRate == taxRate2)
                        //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                        //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                        else if ((custAccRecWork.ConsTaxLayMethod != 9 && taxationDivCdRF != 1) && custAccRecWork.ConsTaxRate == taxRate2)
                        //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                        {
                            // ����z(�v�ŗ�2)
                            billBalanceWork.TotalThisTimeSalesTaxRate2 += custAccRecWork.ThisTimeSales;
                            // �ԕi�l��(�v�ŗ�2)
                            billBalanceWork.TotalThisRgdsDisPricTaxRate2 -= custAccRecWork.ThisSalesPricRgds + custAccRecWork.ThisSalesPricDis;
                            // ������z(�v�ŗ�2)
                            billBalanceWork.TotalPureSalesTaxRate2 += custAccRecWork.OfsThisTimeSales;
                            // �����(�v�ŗ�2)
                            if (custAccRecWork.ConsTaxLayMethod == 0 || custAccRecWork.ConsTaxLayMethod == 1)
                            {
                                billBalanceWork.TotalSalesPricTaxTaxRate2 += totalSalesPricTax;
                            }
                            // ����(�v�ŗ�2)
                            billBalanceWork.TotalSalesSlipCountTaxRate2 += custAccRecWork.SalesSlipCount;
                        }
                        //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                        else if (custAccRecWork.ConsTaxLayMethod == 9 || taxationDivCdRF == 1)
                        {
                            // ����z(�v��ې�)
                            billBalanceWork.TotalThisTimeSalesTaxFree += custAccRecWork.ThisTimeSales;
                            // �ԕi�l��(�v��ې�)
                            billBalanceWork.TotalThisRgdsDisPricTaxFree -= custAccRecWork.ThisSalesPricRgds + custAccRecWork.ThisSalesPricDis;
                            // ������z(�v��ې�)
                            billBalanceWork.TotalPureSalesTaxFree += custAccRecWork.OfsThisTimeSales;
                            // �����(�v��ې�)
                            billBalanceWork.TotalSalesPricTaxTaxFree = 0;
                            // ����(�v��ې�)
                            billBalanceWork.TotalSalesSlipCountTaxFree += custAccRecWork.SalesSlipCount;
                        }
                        //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                        // ���̑�
                        else
                        {
                            // ����z(�v���̑�)
                            billBalanceWork.TotalThisTimeSalesOther += custAccRecWork.ThisTimeSales;
                            // �ԕi�l��(�v���̑�)
                            billBalanceWork.TotalThisRgdsDisPricOther -= custAccRecWork.ThisSalesPricRgds + custAccRecWork.ThisSalesPricDis;
                            // ������z(�v���̑�)
                            billBalanceWork.TotalPureSalesOther += custAccRecWork.OfsThisTimeSales;
                            // �����(�v���̑�)
                            if (custAccRecWork.ConsTaxLayMethod == 0 || custAccRecWork.ConsTaxLayMethod == 1)
                            {
                                billBalanceWork.TotalSalesPricTaxOther += totalSalesPricTax;
                            }
                            // ����(�v���̑�)
                            billBalanceWork.TotalSalesSlipCountOther += custAccRecWork.SalesSlipCount;
                        }
                        #endregion

                        if (!consTaxLayMethodList.Contains(custAccRecWork.ConsTaxLayMethod))
                        {
                            consTaxLayMethodList.Add(custAccRecWork.ConsTaxLayMethod);
                        }

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }

                    if (!myReader.IsClosed) myReader.Close();
                    sqlCommand.CommandText = string.Empty;
                    sqlText = string.Empty;

                    #region ����łƓ������v�Z�o
                    foreach (int consTaxLayMethod in consTaxLayMethodList)
                    {
                        // �`�[�]�ŁE���ד]�ŁE��ې�
                        if (consTaxLayMethod == 0 || consTaxLayMethod == 1 || consTaxLayMethod == 9)
                        {
                            continue;
                        }

                        switch (consTaxLayMethod)
                        {
                            // �����e
                            case 2:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(SALESTOTALTAXEXCRF) AS SALESTOTALTAXEXCRF," + Environment.NewLine;
                                sqlText += "  CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                sqlText += "		SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                                //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                sqlText += "	 (SELECT SUM(SALESMONEYTAXEXCRF) AS SALESTOTALTAXEXCRF FROM SALESDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSALE.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONDIVCDRF = 0) AS SALESTOTALTAXEXCRF, " + Environment.NewLine;
                                //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                //sqlText += "	    SUBSALE.SALESTOTALTAXEXCRF," + Environment.NewLine;
                                //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                
                                sqlText += "	    (CASE WHEN (CLAIM.CLAIMCODERF IS NOT NULL) THEN CLAIM.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSALE.CUSTOMERCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND(SUBSALE.ADDUPADATERF<=@FINDADDUPDATE AND SUBSALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.CONSTAXLAYMETHODRF=2" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += ") AS SALE" + Environment.NewLine;
                                sqlText += " LEFT JOIN SUMCUSTSTRF AS SUMCST" + Environment.NewLine;
                                sqlText += "  ON  SUMCST.ENTERPRISECODERF = SALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND SUMCST.CUSTOMERCODERF = SALE.CLAIMCODERF" + Environment.NewLine;
                                sqlText += " LEFT JOIN CUSTOMERRF AS CUSTSU" + Environment.NewLine;
                                sqlText += "  ON  CUSTSU.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND CUSTSU.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;
                                sqlText += "WHERE SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                #region �̔��G���A�R�[�h
                                if (extrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                                {
                                    sqlText += "  AND CUSTSU.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                                }
                                if (extrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                                {
                                    sqlText += "  AND CUSTSU.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                                }
                                #endregion

                                #region �S���҃R�[�h
                                if (extrInfo_BillBalanceWork.St_EmployeeCode != "")
                                {
                                    if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                                        sqlText += "  AND CUSTSU.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                                    else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                                        sqlText += "  AND CUSTSU.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                                }

                                if (extrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                                {
                                    if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                                        sqlText += "  AND ( CUSTSU.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CUSTSU.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                                    else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                                        sqlText += "  AND ( CUSTSU.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CUSTSU.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                                }
                                #endregion
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   CONSTAXRATERF" + Environment.NewLine;
                                break;
                            // �����q
                            case 3:
                                sqlText += "SELECT" + Environment.NewLine;
                                sqlText += "  SUM(SALE.SALESTOTALTAXEXCRF) AS SALESTOTALTAXEXCRF," + Environment.NewLine;
                                sqlText += "  SALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                sqlText += "  SALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "  SALE.CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "FROM (" + Environment.NewLine;
                                sqlText += "	SELECT" + Environment.NewLine;
                                //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                sqlText += "	 (SELECT SUM(SALESMONEYTAXEXCRF) AS SALESTOTALTAXEXCRF FROM SALESDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSALE.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.ACPTANODRSTATUSRF = DTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                                sqlText += "       AND SUBSALE.SALESSLIPNUMRF = DTL.SALESSLIPNUMRF" + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONDIVCDRF = 0) AS SALESTOTALTAXEXCRF, " + Environment.NewLine;
                                //--- ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                sqlText += "		SUBSALE.ENTERPRISECODERF," + Environment.NewLine;
                                sqlText += "		SUBSALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j --->>>>>
                                //sqlText += "		SUBSALE.SALESTOTALTAXEXCRF," + Environment.NewLine;
                                //--- DEL 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j ---<<<<<
                                
                                sqlText += "		SUBSALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "	    (CASE WHEN (CLAIM.CLAIMCODERF IS NOT NULL) THEN CLAIM.CLAIMCODERF ELSE SUBSALE.CLAIMCODERF END) AS CLAIMCODERF," + Environment.NewLine;
                                sqlText += "	    CASE WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATERF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATERF) THEN TAX.TAXRATERF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE2RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE2RF) THEN TAX.TAXRATE2RF" + Environment.NewLine;
                                sqlText += "	    WHEN (SUBSALE.ADDUPADATERF >= TAX.TAXRATESTARTDATE3RF) AND (SUBSALE.ADDUPADATERF <= TAX.TAXRATEENDDATE3RF) THEN TAX.TAXRATE3RF ELSE 0 END AS CONSTAXRATERF" + Environment.NewLine;
                                sqlText += "	FROM SALESSLIPRF AS SUBSALE WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	LEFT JOIN TAXRATESETRF AS TAX WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "	ON TAX.ENTERPRISECODERF = SUBSALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    LEFT JOIN CUSTOMERRF AS CLAIM WITH(READUNCOMMITTED)" + Environment.NewLine;
                                sqlText += "    ON SUBSALE.ENTERPRISECODERF = CLAIM.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "    AND SUBSALE.CUSTOMERCODERF = CLAIM.CUSTOMERCODERF" + Environment.NewLine;
                                sqlText += "    WHERE SUBSALE.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                                sqlText += "        AND(SUBSALE.ADDUPADATERF<=@FINDADDUPDATE AND SUBSALE.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.LOGICALDELETECODERF=0" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.ACPTANODRSTATUSRF=30" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.CONSTAXLAYMETHODRF=3" + Environment.NewLine;
                                sqlText += "        AND SUBSALE.DEBITNOTEDIVRF=0" + Environment.NewLine;
                                sqlText += ") AS SALE" + Environment.NewLine;
                                sqlText += " LEFT JOIN SUMCUSTSTRF AS SUMCST" + Environment.NewLine;
                                sqlText += "  ON  SUMCST.ENTERPRISECODERF = SALE.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND SUMCST.CUSTOMERCODERF = SALE.CLAIMCODERF" + Environment.NewLine;
                                sqlText += " LEFT JOIN CUSTOMERRF AS CUSTSU" + Environment.NewLine;
                                sqlText += "  ON  CUSTSU.ENTERPRISECODERF = SUMCST.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "  AND CUSTSU.CUSTOMERCODERF = SUMCST.SUMCLAIMCUSTCODERF" + Environment.NewLine;
                                sqlText += "WHERE SALE.CLAIMCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                                #region �̔��G���A�R�[�h
                                if (extrInfo_BillBalanceWork.St_SalesAreaCode != 0)
                                {
                                    sqlText += "  AND CUSTSU.SALESAREACODERF>=@ST_SALESAREACODE" + Environment.NewLine;
                                }
                                if (extrInfo_BillBalanceWork.Ed_SalesAreaCode != 9999)
                                {
                                    sqlText += "  AND CUSTSU.SALESAREACODERF<=@ED_SALESAREACODE" + Environment.NewLine;
                                }
                                #endregion

                                #region �S���҃R�[�h
                                if (extrInfo_BillBalanceWork.St_EmployeeCode != "")
                                {
                                    if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                                        sqlText += "  AND CUSTSU.CUSTOMERAGENTCDRF>=@ST_AGENTCD" + Environment.NewLine;
                                    else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                                        sqlText += "  AND CUSTSU.BILLCOLLECTERCDRF>=@ST_AGENTCD" + Environment.NewLine;
                                }

                                if (extrInfo_BillBalanceWork.Ed_EmployeeCode != "")
                                {
                                    if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.CustomerAgentCd)
                                        sqlText += "  AND ( CUSTSU.CUSTOMERAGENTCDRF<=@ED_AGENTCD OR CUSTSU.CUSTOMERAGENTCDRF IS NULL )" + Environment.NewLine;
                                    else if (extrInfo_BillBalanceWork.EmployeeKindDiv == (int)EmployeeKindDiv.BillCollecterCd)
                                        sqlText += "  AND ( CUSTSU.BILLCOLLECTERCDRF<=@ED_AGENTCD OR CUSTSU.BILLCOLLECTERCDRF IS NULL )" + Environment.NewLine;
                                }
                                #endregion
                                sqlText += "GROUP BY" + Environment.NewLine;
                                sqlText += "   SALE.RESULTSADDUPSECCDRF," + Environment.NewLine;
                                sqlText += "   SALE.CUSTOMERCODERF," + Environment.NewLine;
                                sqlText += "   SALE.CONSTAXRATERF" + Environment.NewLine;
                                break;
                        }

                        // �����]�ł݂̂̏ꍇ�A����Ŏq�������s��
                        if (!string.IsNullOrEmpty(sqlText))
                        {
                            sqlCommand.CommandText = sqlText;
                            myReader = sqlCommand.ExecuteReader();
                        }

                        // ����`�[���v�i�Ŕ����j
                        long salesTotal = 0;
                        // ����Őŗ�
                        double consTaxRate = 0.0;
                        // �����(�[��������)
                        long tempTax = 0;

                        while (myReader.Read())
                        {
                            switch (consTaxLayMethod)
                            {
                                // �����e
                                case 2:
                                // �����q
                                case 3:
                                    salesTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                                    consTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                                    // �ŗ�1
                                    if (consTaxRate == taxRate1)
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custAccRecWork.FractionProcCd, out tempTax);
                                        billBalanceWork.TotalSalesPricTaxTaxRate1 += tempTax;
                                    }
                                    // �ŗ�2
                                    else if (consTaxRate == taxRate2)
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custAccRecWork.FractionProcCd, out tempTax);
                                        billBalanceWork.TotalSalesPricTaxTaxRate2 += tempTax;
                                    }
                                    // ���̑�
                                    else
                                    {
                                        FracCalc(salesTotal * consTaxRate, fractionProcUnit, custAccRecWork.FractionProcCd, out tempTax);
                                        billBalanceWork.TotalSalesPricTaxOther += tempTax;
                                    }
                                    break;
                            }
                        }

                        // �N�G��������
                        sqlText = string.Empty;
                        if (!myReader.IsClosed) myReader.Close();
                    }

                    billBalanceWork.TotalAfCalTMonthAccRecTaxRate1 = billBalanceWork.TotalPureSalesTaxRate1 + billBalanceWork.TotalSalesPricTaxTaxRate1;
                    billBalanceWork.TotalAfCalTMonthAccRecTaxRate2 = billBalanceWork.TotalPureSalesTaxRate2 + billBalanceWork.TotalSalesPricTaxTaxRate2;
                    billBalanceWork.TotalAfCalTMonthAccRecTaxFree = billBalanceWork.TotalPureSalesTaxFree + billBalanceWork.TotalSalesPricTaxTaxFree;// ADD 2022/10/13 ���O 11800255-00�@�C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j
                    billBalanceWork.TotalAfCalTMonthAccRecOther = billBalanceWork.TotalPureSalesOther + billBalanceWork.TotalSalesPricTaxOther;
                    #endregion

                    #endregion
                }

                billBalanceWork.TitleTaxRate1 = Convert.ToInt32(taxRate1 * 100) + "%";
                billBalanceWork.TitleTaxRate2 = Convert.ToInt32(taxRate2 * 100) + "%";
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BillBalanceTableDB.SearchSalesProc Exception=" + ex.Message);
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
        /// ����������̕\��/��\���𔻒肵�܂��B
        /// </summary>
        /// <param name="bCondition">������</param>
        /// <param name="Text">������</param>
        /// <returns></returns>
        private string IFBy(Boolean bCondition, string Text)
        {
            if (bCondition) return Text;
            else return "";
        }

        /// <summary>
        /// �S���ҋ敪��񋓂��܂��B
        /// </summary>
        enum EmployeeKindDiv
        {
            CustomerAgentCd = 0,  //0:�ڋq�S���]�ƈ��R�[�h
            BillCollecterCd = 1   //1:�W���S���]�ƈ��R�[�h
        }

        /// <summary>
        /// ��������敪��񋓂��܂��B
        /// </summary>
        enum DepoDtlDiv
        {
            DepoDtlON = 0,  //0:�󎚂���
            DepoDtlOFF = 1  //1:�󎚂��Ȃ�
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
    public class CustAccRecDateInfo
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
