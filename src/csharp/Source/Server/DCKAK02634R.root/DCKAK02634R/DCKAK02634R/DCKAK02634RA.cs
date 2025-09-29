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
// --- ADD 2012/11/20 ---------->>>>>
using Broadleaf.Application.Common;
// --- ADD 2012/11/20 ----------<<<<<

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���|�c���ꗗ�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|�c���ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.11.15</br>
    /// <br></br>
    /// <br>Note       : �o�l.�m�r�p�ɏC��</br>
    /// <br>Programmer : 23015  �X�{ ��P</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Note       : �s��C��</br>
    /// <br>Programmer : 23012  ���� �[���N</br>
    /// <br>Date       : 2008.10.18</br>
    /// <br></br>
    /// <br>Note       : �_���폜�Ή�</br>
    /// <br>Programmer : 22008  ���� ���n</br>
    /// <br>Date       : 2009.04.30</br>
    /// <br></br>
    /// <br>Note       : �s��C��</br>
    /// <br>Programmer : 23012  ���� �[���N</br>
    /// <br>Date       : 2009.06.02</br>
    /// <br></br>
    /// <br>Note       : �d���摍���Ή��ɔ����Ή�</br>
    /// <br>Programmer : 30755 FSI����(�f)</br>
    /// <br>Date       : 2012/10/01</br>   
    /// <br></br>
    /// <br>Note       : �萔���ƒl�����ȊO�̎x���`�[�̏ꍇ�A�󎚂���Ȃ��Ή�</br>
    /// <br>Programmer : 30755 FSI����(�f)</br>
    /// <br>Date       : 2012/11/07</br>
    /// <br></br>
    /// <br>Note       : �����x�����萔��������Ȃ��Ή�</br>
    /// <br>Programmer : 30755 FSI����(�f)</br>
    /// <br>Date       : 2012/11/13</br>
    /// <br></br>
    /// <br>Note       : �d�������I�v�V���������L�̑Ή�</br>
    /// <br>Programmer : 30755 FSI����(�f)</br>
    /// <br>Date       : 2012/11/14</br>
    /// <br></br>
    /// <br>Note       : ���񌎎�������+1�J�����������󎚂���Ȃ��Ή�</br>
    /// <br>Programmer : 30755 FSI����(�f)</br>
    /// <br>Date       : 2012/11/20</br>
    /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2020/03/02</br>
    /// <br>UpdateNote : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
    /// <br>Programmer : 3H ����</br>
    /// <br>Date       : 2022/10/09</br>
    /// </remarks>
    [Serializable]
    public class AccPaymentListWorkDB : RemoteDB, IAccPaymentListWorkDB
    {
        private int _timeOut = 3600;//ADD 2020/03/02 �΍�@�y���ŗ��Ή�
        /// <summary>
        /// ���|�c���ꗗ�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.15</br>
        /// </remarks>
        public AccPaymentListWorkDB()
            :
            base("DCKAK02636D", "Broadleaf.Application.Remoting.ParamData.AccPaymentListResultWork", "SUPLACCPAYRF")
        {
        }

        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        private MonthlyAddUpDB _monthlyAddUpDB;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔��|�c���ꗗ�\��߂��܂�
        /// </summary>
        /// <param name="accPaymentListResultWork">��������</param>
        /// <param name="accPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c���ꗗ�\��߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.15</br>
        public int Search(out object accPaymentListResultWork, object accPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            accPaymentListResultWork = null;

            ArrayList _accPaymentListCndtnWorkList = accPaymentListCndtnWork as ArrayList;
            AccPaymentListCndtnWork _accPaymentListCndtnWork = null;

            if (_accPaymentListCndtnWorkList == null)
            {
                _accPaymentListCndtnWork = accPaymentListCndtnWork as AccPaymentListCndtnWork;
            }
            else
            {
                if (_accPaymentListCndtnWorkList.Count > 0)
                    _accPaymentListCndtnWork = _accPaymentListCndtnWorkList[0] as AccPaymentListCndtnWork;
            }

            try
            {
                status = SearchProc(out accPaymentListResultWork, _accPaymentListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.Search Exception=" + ex.Message);
                accPaymentListResultWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion  //[Search]

        #region [SearchProc]
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔��|�c���ꗗ�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="accPaymentListResultWork">��������</param>
        /// <param name="_accPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔��|�c���ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.15</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.15 ���� DC.NS�p�ɏC��</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�p�ɏC��</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        /// <br></br>
        /// <br>Update Note: �s��C��</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.18</br>
        /// <br></br>
        /// <br>Update Note: �d���摍���Ή��ɔ����Ή�</br>
        /// <br>Programmer : FSI����(�f)</br>
        /// <br>Date       : 2012/10/01</br>
        /// <br></br>
        /// <br>Note       : �萔���ƒl�����ȊO�̎x���`�[�̏ꍇ�A�󎚂���Ȃ��Ή�</br>
        /// <br>Programmer : 30755 FSI����(�f)</br>
        /// <br>Date       : 2012/11/07</br>
        /// <br></br>
        /// <br>Note       : �����x�����萔��������Ȃ��Ή�</br>
        /// <br>Programmer : 30755 FSI����(�f)</br>
        /// <br>Date       : 2012/11/13</br>
        /// <br></br>
        /// <br>Note       : �d�������I�v�V���������L�̑Ή�</br>
        /// <br>Programmer : 30755 FSI����(�f)</br>
        /// <br>Date       : 2012/11/14</br>
        /// <br></br>
        /// <br>Note       : ���񌎎�������+1�J�����������󎚂���Ȃ��Ή�</br>
        /// <br>Programmer : 30755 FSI����(�f)</br>
        /// <br>Date       : 2012/11/20</br>
        /// <br>UpdateNote : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date	   : 2020/03/02</br>
        private int SearchProc(out object accPaymentListResultWork, AccPaymentListCndtnWork _accPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            accPaymentListResultWork = null;
            // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
            // �����t���b�O
            bool isCheckOut = true;
            // �x����O�񌎎��X�V�N����
            Dictionary<string, DateTime> payeeDateDic = new Dictionary<string, DateTime>();
            // --- ADD END 3H ������ 2020/03/02 ----------<<<<<
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
// �C�� 2009.01.27 >>>
                #region DEL 2009.01.27   
                /*
                para.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;  //��ƃR�[�h
                status = ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                //���t�ϊ�
                Int32 iAddUpDate = Int32.Parse(_accPaymentListCndtnWork.AddUpDate.ToString("yyyyMMdd"));

                // ADD 2008.10.18 >>>            
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    #region [������ -> ���|���E���|���W�v���W���[������擾]
                    ArrayList SupplierList = new ArrayList();

                    //�d����}�X�^���X�g�쐬
                    status = SearchSuppProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
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

                    //���|���E���|���W�v���W���[���ďo
                    for (int i = 0; i < SupplierList.Count; i++)
                    {
                        //���|���E���|���W�v���W���[���p�����[�^�Z�b�g
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
                        suplAccPayWork.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;                 //��ƃR�[�h
                        suplAccPayWork.AddUpDate = _accPaymentListCndtnWork.AddUpDate;                           //�v��N����
                        suplAccPayWork.AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth;                 //�v��N��
                        suplAccPayWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //�v�㋒�_�R�[�h ���d����}�X�^���X�g����
                        suplAccPayWork.SupplierCd = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;       //�d����R�[�h   ���d����}�X�^���X�g����
                        object paraObj2 = (object)suplAccPayWork;
                        string retMsg = null;

                        //���|���E���|���W�v���W���[���ďo
                        status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg);
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
                                switch (_accPaymentListCndtnWork.OutMoneyDiv)
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
                                AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                                //���_�R�[�h ���d����}�X�^����
                                ResultWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;
                                //���_���� �����_���ݒ�}�X�^����
                                ResultWork.SectionGuideSnm = ((AccPaymentListResultWork)SupplierList[i]).SectionGuideSnm;
                                //������R�[�h ���d����}�X�^����
                                ResultWork.PayeeCode = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;
                                //�����旪�� ���d����}�X�^����
                                ResultWork.PayeeSnm = ((AccPaymentListResultWork)SupplierList[i]).PayeeSnm;
                                //�O�����|�c
                                ResultWork.LastTimeAccPay = ((SuplAccPayWork)SuplAccRecResult[j]).LastTimeAccPay;
                                //�����x��
                                ResultWork.ThisTimePayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimePayNrml;
                                //�J�z�z
                                ResultWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeTtlBlcAcPay;
                                //�d���z
                                ResultWork.OfsThisTimeStock = ((SuplAccPayWork)SuplAccRecResult[j]).OfsThisTimeStock;
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

                                if (_accPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
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
                                    ResultWork.CashPayment = ((AccPaymentListResultWork)PaymentList[0]).CashPayment;
                                    //�U��
                                    ResultWork.TrfrPayment = ((AccPaymentListResultWork)PaymentList[0]).TrfrPayment;
                                    //���؎�
                                    ResultWork.CheckPayment = ((AccPaymentListResultWork)PaymentList[0]).CheckPayment;
                                    //��`
                                    ResultWork.DraftPayment = ((AccPaymentListResultWork)PaymentList[0]).DraftPayment;
                                    //���E
                                    ResultWork.OffsetPayment = ((AccPaymentListResultWork)PaymentList[0]).OffsetPayment;
                                    //�����U��
                                    ResultWork.FundTransferPayment = ((AccPaymentListResultWork)PaymentList[0]).FundTransferPayment;
                                    //���̑�
                                    ResultWork.OthsPayment = ((AccPaymentListResultWork)PaymentList[0]).OthsPayment;
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
                    }
                    #endregion  //[������ -> ���|���E���|���W�v���W���[������擾]
                }
                else
                // ADD 2008.10.18 <<<

                //���t��r
                if (retList[0].TotalDay < iAddUpDate)
                {
                    #region [������ -> ���|���E���|���W�v���W���[������擾]
                    ArrayList SupplierList = new ArrayList();

                    //�d����}�X�^���X�g�쐬
                    status = SearchSuppProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
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

                    //���|���E���|���W�v���W���[���ďo
                    for (int i = 0; i < SupplierList.Count; i++)
                    {
                        //���|���E���|���W�v���W���[���p�����[�^�Z�b�g
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
                        suplAccPayWork.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;                 //��ƃR�[�h
                        suplAccPayWork.AddUpDate = _accPaymentListCndtnWork.AddUpDate;                           //�v��N����
                        suplAccPayWork.AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth;                 //�v��N��
                        suplAccPayWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //�v�㋒�_�R�[�h ���d����}�X�^���X�g����
                        suplAccPayWork.SupplierCd = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;       //�d����R�[�h   ���d����}�X�^���X�g����
                        object paraObj2 = (object)suplAccPayWork;
                        string retMsg = null;

                        //���|���E���|���W�v���W���[���ďo
                        status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg);
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
                                switch (_accPaymentListCndtnWork.OutMoneyDiv)
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
                                AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                                //���_�R�[�h ���d����}�X�^����
                                ResultWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;
                                //���_���� �����_���ݒ�}�X�^����
                                ResultWork.SectionGuideSnm = ((AccPaymentListResultWork)SupplierList[i]).SectionGuideSnm;
                                //������R�[�h ���d����}�X�^����
                                ResultWork.PayeeCode = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;
                                //�����旪�� ���d����}�X�^����
                                ResultWork.PayeeSnm = ((AccPaymentListResultWork)SupplierList[i]).PayeeSnm;
                                //�O�����|�c
                                ResultWork.LastTimeAccPay = ((SuplAccPayWork)SuplAccRecResult[j]).LastTimeAccPay;
                                //�����x��
                                ResultWork.ThisTimePayNrml = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimePayNrml;
                                //�J�z�z
                                ResultWork.ThisTimeTtlBlcAcPay = ((SuplAccPayWork)SuplAccRecResult[j]).ThisTimeTtlBlcAcPay;
                                //�d���z
                                ResultWork.OfsThisTimeStock = ((SuplAccPayWork)SuplAccRecResult[j]).OfsThisTimeStock;
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

                                if (_accPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
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
                                    ResultWork.CashPayment = ((AccPaymentListResultWork)PaymentList[0]).CashPayment;
                                    //�U��
                                    ResultWork.TrfrPayment = ((AccPaymentListResultWork)PaymentList[0]).TrfrPayment;
                                    //���؎�
                                    ResultWork.CheckPayment = ((AccPaymentListResultWork)PaymentList[0]).CheckPayment;
                                    //��`
                                    ResultWork.DraftPayment = ((AccPaymentListResultWork)PaymentList[0]).DraftPayment;
                                    //���E
                                    ResultWork.OffsetPayment = ((AccPaymentListResultWork)PaymentList[0]).OffsetPayment;
                                    //�����U��
                                    ResultWork.FundTransferPayment = ((AccPaymentListResultWork)PaymentList[0]).FundTransferPayment;
                                    //���̑�
                                    ResultWork.OthsPayment = ((AccPaymentListResultWork)PaymentList[0]).OthsPayment;
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
                    }
                    #endregion  //[������ -> ���|���E���|���W�v���W���[������擾]
                }
                else
                {
                    //���ߍ� -> ���Ӑ攄�|���z�}�X�^����擾
                    //�������s
                    status = SearchAccPaymentProc(ref al, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
                }
                */
                #endregion
                ArrayList SupplierList = new ArrayList();
                AccPaymentListResultWork SupplierListWork = new AccPaymentListResultWork();

                //�d����}�X�^���X�g�쐬
                // --- DEL 2012/10/01 ---------->>>>>
                //status = SearchSuppProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
                // --- DEL 2012/10/01 ----------<<<<<
                // --- ADD 2012/10/01 ---------->>>>>
                //�d�������I�v�V�����������̏ꍇ
                if (_accPaymentListCndtnWork.OptSuppEnable == 1)
                {
                    status = SearchSuppProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
                }
                //�d�������I�v�V�������L���̏ꍇ
                else
                {
                    status = SearchSuppGeneralProc(ref SupplierList, _accPaymentListCndtnWork, ref sqlConnection, logicalMode);
                }
                // --- ADD 2012/10/01 ----------<<<<<
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

                // --- ADD 2012/11/14 ---------->>>>>
                //�d�������I�v�V�������L���̏ꍇ
                if (_accPaymentListCndtnWork.OptSuppEnable == 2)
                {
                    ArrayList MonAddUpCAddUpHisList = new ArrayList();

                    //�������X�V�����}�X�^���烊�X�g���擾����B
                    status = SearchMonAddUpProc(ref MonAddUpCAddUpHisList, _accPaymentListCndtnWork, ref sqlConnection);

                    //�Y���f�[�^�`�F�b�N
                    if (MonAddUpCAddUpHisList.Count != 0)
                    {
                        //����ԃ`�F�b�N
                        for (int k = 0; k < MonAddUpCAddUpHisList.Count; k++)
                        {
                            //���𐧌�敪���m��̏ꍇ
                            if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[k]).HistCtlCd == 0)
                            {
                                //���̌v�㋒�_���ēx�`�F�b�N����
                                for (int l = 0; l < MonAddUpCAddUpHisList.Count; l++)
                                {
                                    //���𐧌�敪�����m��̏ꍇ
                                    if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[l]).HistCtlCd == 1)
                                    {
                                        //�O���R�[�h�����擾
                                        int m = l;
                                        m--;

                                        //�e�͗��𐧌�敪0��1������̂ŁA�O���R�[�h�ƌ����R�[�h�̌v�㋒�_�R�[�h������B
                                        if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[m]).AddUpSecCode == ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[l]).AddUpSecCode)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            //�������X�V����UPDATE���W���[���p�����[�^�Z�b�g
                                            MonAddUpCAddUpHisResultWork monAddUpCAddUpHisWork = new MonAddUpCAddUpHisResultWork();
                                            monAddUpCAddUpHisWork.MonthlyAddUpDate = _accPaymentListCndtnWork.AddUpYearMonth;
                                            monAddUpCAddUpHisWork.AddUpSecCode = ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[l]).AddUpSecCode;
                                            _accPaymentListCndtnWork.AddUpSecCode = ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList[l]).AddUpSecCode;
                                            _accPaymentListCndtnWork.MonAddUpEnable = 1;

                                            ArrayList MonAddDataUpTimeList = new ArrayList();

                                            //�Ō�ɍX�V�����������X�V�����f�[�^�̗��𐧌�敪�����m��̃f�[�^�X�V������1���擾����B(�i�m�b)
                                            SearchMonAddDataUpTimeProc(ref MonAddDataUpTimeList, _accPaymentListCndtnWork, ref sqlConnection);

                                            monAddUpCAddUpHisWork.DataUpdateDateTime = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).DataUpdateDateTime;

                                            //���𐧌�敪���m��ɂ���
                                            SearchMonAddUpDateProc(ref monAddUpCAddUpHisWork, ref sqlConnection);

                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        //���𐧌�敪���m��Ȃ̂Ŏ��̃��R�[�h
                                        continue;
                                    }
                                }
                                k = MonAddUpCAddUpHisList.Count;
                            }
                            else
                            {
                                //���𐧌�敪�����m��̏ꍇ�͎��̃��R�[�h
                                continue;
                            }
                        }

                        int o = 0;
                        string iAddUpSecCode = null;
                        string jAddUpSecCode = null;

                        for (int n = 0; n < SupplierList.Count; n++)
                        {
                            //���X�g���Ď擾����B
                            ArrayList MonAddUpCAddUpHisList2 = new ArrayList();
                            SearchMonAddUpProc(ref MonAddUpCAddUpHisList2, _accPaymentListCndtnWork, ref sqlConnection);

                            //�������X�V�������X�g����d�����Ă���v�㋒�_���폜����B
                            for (int p = 0; p < MonAddUpCAddUpHisList2.Count; p++)
                            {
                                if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[p]).AddUpSecCode == ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[p]).AddUpSecCode)
                                {
                                    if (((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[p]).HistCtlCd == 1)
                                    {
                                        int i = p;
                                        i++;
                                        if (MonAddUpCAddUpHisList2.Count < i)
                                        {
                                            //�������Ȃ�
                                        }
                                        else
                                        {
                                            MonAddUpCAddUpHisList2.RemoveAt(p);
                                            p--;
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            if (MonAddUpCAddUpHisList2.Count != 0)
                            {
                                if (((AccPaymentListResultWork)SupplierList[n]).AddUpSecCode != ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[o]).AddUpSecCode)
                                {
                                    int g = o;
                                    g++;
                                    if (MonAddUpCAddUpHisList2.Count <= g)
                                    {
                                        //�������Ȃ�
                                    }
                                    else
                                    {
                                        o++;
                                    }

                                    if (((AccPaymentListResultWork)SupplierList[n]).AddUpSecCode != ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[o]).AddUpSecCode)
                                    {
                                        //�O��Ɠ������_�ԍ����`�F�b�N����B
                                        if (jAddUpSecCode != ((AccPaymentListResultWork)SupplierList[n]).AddUpSecCode)
                                        {
                                            iAddUpSecCode = ((MonAddUpCAddUpHisResultWork)MonAddUpCAddUpHisList2[o]).AddUpSecCode;
                                            jAddUpSecCode = ((AccPaymentListResultWork)SupplierList[n]).AddUpSecCode;

                                            //�������X�V����INSERT���W���[���p�����[�^�Z�b�g
                                            MonAddUpCAddUpHisResultWork monAddUpCAddUpHisWork = new MonAddUpCAddUpHisResultWork();
                                            monAddUpCAddUpHisWork.MonthlyAddUpDate = _accPaymentListCndtnWork.AddUpYearMonth;
                                            monAddUpCAddUpHisWork.AddUpSecCode = iAddUpSecCode;
                                            _accPaymentListCndtnWork.AddUpSecCode = iAddUpSecCode;
                                            _accPaymentListCndtnWork.MonAddUpEnable = 2;

                                            ArrayList MonAddDataUpTimeList = new ArrayList();

                                            //�Ō�ɍX�V�����������X�V�����f�[�^�̗��𐧌�敪�����m��̃f�[�^�X�V������1���擾����B(�i�m�b)
                                            SearchMonAddDataUpTimeProc(ref MonAddDataUpTimeList, _accPaymentListCndtnWork, ref sqlConnection);

                                            monAddUpCAddUpHisWork.CreateDateTime = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).CreateDateTime;
                                            monAddUpCAddUpHisWork.UpdateDateTime = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).UpdateDateTime;
                                            monAddUpCAddUpHisWork.EnterpriseCode = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).EnterpriseCode;
                                            monAddUpCAddUpHisWork.FileHeaderGuid = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).FileHeaderGuid;
                                            monAddUpCAddUpHisWork.UpdEmployeeCode = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).UpdEmployeeCode;
                                            monAddUpCAddUpHisWork.UpdAssemblyId1 = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).UpdAssemblyId1;
                                            monAddUpCAddUpHisWork.UpdAssemblyId2 = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).UpdAssemblyId2;
                                            monAddUpCAddUpHisWork.LogicalDeleteCode = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).LogicalDeleteCode;
                                            monAddUpCAddUpHisWork.AccRecAccPayDiv = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).AccRecAccPayDiv;
                                            monAddUpCAddUpHisWork.AddUpSecCode = jAddUpSecCode;
                                            monAddUpCAddUpHisWork.StMonCAddUpUpdDate = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).StMonCAddUpUpdDate;
                                            monAddUpCAddUpHisWork.MonthlyAddUpDate = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).MonthlyAddUpDate;
                                            monAddUpCAddUpHisWork.MonthAddUpYearMonth = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).MonthAddUpYearMonth;
                                            monAddUpCAddUpHisWork.MonthAddUpExpDate = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).MonthAddUpExpDate;
                                            monAddUpCAddUpHisWork.LaMonCAddUpUpdDate = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).LaMonCAddUpUpdDate;
                                            monAddUpCAddUpHisWork.DataUpdateDateTime = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).DataUpdateDateTime;
                                            monAddUpCAddUpHisWork.ProcDivCd = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).ProcDivCd;
                                            monAddUpCAddUpHisWork.ErrorStatus = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).ErrorStatus;
                                            monAddUpCAddUpHisWork.HistCtlCd = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).HistCtlCd;
                                            monAddUpCAddUpHisWork.ProcResult = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).ProcResult;
                                            monAddUpCAddUpHisWork.ConvertProcessDivCd = ((MonAddUpCAddUpHisResultWork)MonAddDataUpTimeList[0]).ConvertProcessDivCd;

                                            //���ς݃f�[�^�Ƃ��ă��R�[�h�ɒǉ�����
                                            SearchMonAddDataInsertProc(ref monAddUpCAddUpHisWork, ref sqlConnection);

                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
                // --- ADD 2012/11/14 ----------<<<<<

                for (int i = 0; i < SupplierList.Count; i++)
                {
                    // �����`�F�b�N
                    para.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;  //��ƃR�[�h
                    para.SectionCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode; // ���_�R�[�h
                    status = ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                    Int32 iAddUpDate = Int32.Parse(_accPaymentListCndtnWork.AddUpDate.ToString("yyyyMMdd"));
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)
                    {
                        #region ��������
                        // --- ADD 2012/11/20 ---------->>>>>
                        DateTime AddUpDate;

                        //���񌎎����������擾
                        if (status == 9)
                        {
                            AddUpDate = _accPaymentListCndtnWork.AddUpDate;
                        }
                        else
                        {
                            AddUpDate = DateTime.ParseExact(retList[0].TotalDay.ToString(), "yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                            AddUpDate = AddUpDate.AddDays(1);
                        }
                        //���|���E���|���W�v���W���[���p�����[�^�Z�b�g(���񌎎�������+1�J��)
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork2 = new SuplAccPayWork();
                        suplAccPayWork2.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;                 //��ƃR�[�h
                        // --- UPD START 3H ������ 2020/03/02 ---------->>>>>
                        //suplAccPayWork2.AddUpDate = _accPaymentListCndtnWork.AddUpDate.AddMonths(-1);             //�v��N����
                        // ����N�����̓�������̏ꍇ
                        if (_accPaymentListCndtnWork.AddUpDate.Day > 27)
                        {     
                            // �O���̖�����ݒ肷��
                            suplAccPayWork2.AddUpDate = _accPaymentListCndtnWork.AddUpDate.AddDays(1 - _accPaymentListCndtnWork.AddUpDate.Day).AddDays(-1);
                        }
                        // ��L�ȊO�̏ꍇ
                        else
                        {     
                            // �����̂܂܂őO����ݒ肷��
                            suplAccPayWork2.AddUpDate = _accPaymentListCndtnWork.AddUpDate.AddMonths(-1);
                        }
                        // --- UPD END 3H ������ 2020/03/02 ----------<<<<<
                        suplAccPayWork2.AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth.AddMonths(-1);   //�v��N��
                        suplAccPayWork2.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //�v�㋒�_�R�[�h ���d����}�X�^���X�g����
                        suplAccPayWork2.SupplierCd = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;       //�d����R�[�h   ���d����}�X�^���X�g����
                        object paraObj3 = (object)suplAccPayWork2;
                        string retMsg1 = null;

                        //�d�������I�v�V�����������̏ꍇ
                        if (_accPaymentListCndtnWork.OptSuppEnable == 1)
                        {
                            //���|���E���|���W�v���W���[���ďo
                            status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj3, out retMsg1);
                        }
                        //�d�������I�v�V�������L���̏ꍇ
                        else
                        {
                            //���|���E���|���W�v���W���[���ďo
                            status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj3, out retMsg1);
                        }

                        //�擾���ʃL���X�g
                        ArrayList SuplAccRecResult2 = new ArrayList();
                        SuplAccRecResult2.Add((SuplAccPayWork)paraObj3);
                        // --- ADD 2012/11/20 ----------<<<<<

                        //���|���E���|���W�v���W���[���p�����[�^�Z�b�g(���񌎎�������)
                        this._monthlyAddUpDB = new MonthlyAddUpDB();
                        SuplAccPayWork suplAccPayWork = new SuplAccPayWork();
                        suplAccPayWork.EnterpriseCode = _accPaymentListCndtnWork.EnterpriseCode;                 //��ƃR�[�h
                        suplAccPayWork.AddUpDate = _accPaymentListCndtnWork.AddUpDate;                           //�v��N����
                        suplAccPayWork.AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth;                 //�v��N��
                        suplAccPayWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;  //�v�㋒�_�R�[�h ���d����}�X�^���X�g����
                        suplAccPayWork.SupplierCd = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;       //�d����R�[�h   ���d����}�X�^���X�g����
                        // --- ADD 2012/11/20 ---------->>>>>
                        if (AddUpDate != _accPaymentListCndtnWork.AddUpYearMonth)
                        {
                            DateTime StMonthDate = DateTime.MinValue;
                            DateTime EdMonthDate = DateTime.MinValue;
                            DateTime AddUpYearMonth = _accPaymentListCndtnWork.AddUpYearMonth;
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
                        // --- ADD 2012/11/20 ----------<<<<<
                        object paraObj2 = (object)suplAccPayWork;
                        string retMsg = null;

                        // --- DEL 2012/10/01 ---------->>>>>
                        //���|���E���|���W�v���W���[���ďo
                        //status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg);
                        // --- DEL 2012/10/01 ----------<<<<<

                        // --- ADD 2012/10/01 ---------->>>>>
                        //�d�������I�v�V�����������̏ꍇ
                        if (_accPaymentListCndtnWork.OptSuppEnable == 1)
                        {
                            //���|���E���|���W�v���W���[���ďo
                            status = _monthlyAddUpDB.ReadSuplAccPay(ref paraObj2, out retMsg);
                        }
                        //�d�������I�v�V�������L���̏ꍇ
                        else
                        {
                            //���|���E���|���W�v���W���[���ďo
                            status = _monthlyAddUpDB.ReadSuplAccPayByAddUpSecCode(ref paraObj2, out retMsg);
                        }
                        // --- ADD 2012/10/01 ----------<<<<<
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
                                switch (_accPaymentListCndtnWork.OutMoneyDiv)
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
                                AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                                //���_�R�[�h ���d����}�X�^����
                                ResultWork.AddUpSecCode = ((AccPaymentListResultWork)SupplierList[i]).AddUpSecCode;
                                //���_���� �����_���ݒ�}�X�^����
                                ResultWork.SectionGuideSnm = ((AccPaymentListResultWork)SupplierList[i]).SectionGuideSnm;
                                //������R�[�h ���d����}�X�^����
                                ResultWork.PayeeCode = ((AccPaymentListResultWork)SupplierList[i]).PayeeCode;
                                //�����旪�� ���d����}�X�^����
                                ResultWork.PayeeSnm = ((AccPaymentListResultWork)SupplierList[i]).PayeeSnm;
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

                                // --- DEL 2012/11/07 ---------->>>>>
                                // 0���у`�F�b�N
                                //if (ResultWork.LastTimeAccPay == 0 && ResultWork.ThisTimeFeePayNrml ==0 &&
                                //    ResultWork.ThisTimeDisPayNrml == 0 && ResultWork.OfsThisTimeStock == 0 &&
                                //    ResultWork.OfsThisStockTax == 0 && ResultWork.StockSlipCount == 0)
                                // --- DEL 2012/11/07 ----------<<<<<
                                // --- ADD 2012/11/07 ---------->>>>>
                                // 0���у`�F�b�N
                                if (ResultWork.LastTimeAccPay == 0 && ResultWork.ThisTimeFeePayNrml ==0 &&
                                    ResultWork.ThisTimeDisPayNrml == 0 && ResultWork.OfsThisTimeStock == 0 &&
                                    ResultWork.OfsThisStockTax == 0 && ResultWork.StockSlipCount == 0 &&
                                    ResultWork.ThisTimePayNrml == 0)
                                // --- ADD 2012/11/07 ----------<<<<<
                                {
                                    continue;
                                }
                                // --- ADD 2012/11/20 ---------->>>>>
                                if (AddUpDate != _accPaymentListCndtnWork.AddUpYearMonth)
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
                                // --- ADD 2012/11/20 ----------<<<<<

                                // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
                                // ����ŕʓ���󎚂���
                                if (_accPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
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
                                // --- ADD END 3H ������ 2020/03/02 ----------<<<<<

                                if (_accPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
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
                                    ResultWork.CashPayment = ((AccPaymentListResultWork)PaymentList[0]).CashPayment;
                                    //�U��
                                    ResultWork.TrfrPayment = ((AccPaymentListResultWork)PaymentList[0]).TrfrPayment;
                                    //���؎�
                                    ResultWork.CheckPayment = ((AccPaymentListResultWork)PaymentList[0]).CheckPayment;
                                    //��`
                                    ResultWork.DraftPayment = ((AccPaymentListResultWork)PaymentList[0]).DraftPayment;
                                    //���E
                                    ResultWork.OffsetPayment = ((AccPaymentListResultWork)PaymentList[0]).OffsetPayment;
                                    //�����U��
                                    ResultWork.FundTransferPayment = ((AccPaymentListResultWork)PaymentList[0]).FundTransferPayment;
                                    //���̑�
                                    ResultWork.OthsPayment = ((AccPaymentListResultWork)PaymentList[0]).OthsPayment;

                                    // --- ADD 2012/11/13 ---------->>>>>
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
                                    // --- ADD 2012/11/13 ----------<<<<<
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
                        SupplierListWork = SupplierList[i] as AccPaymentListResultWork;
                        //���ߍ� -> ���Ӑ攄�|���z�}�X�^����擾
                        //�������s
                        status = SearchAccPaymentProc(ref al, _accPaymentListCndtnWork, SupplierListWork,  ref sqlConnection, logicalMode);
                    }
                }

                // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
                // ����ŕʓ���󎚂���
                if (_accPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalON)
                {
                    Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic = new Dictionary<string, SuplAccPayDateInfo>();
                    // �����X�V���s�����ꍇ
                    if (isCheckOut)
                    {
                        // �����X�V�������擾���s��
                        status = SearchSuplAccPayDate(_accPaymentListCndtnWork, ref suplAccPayDateDic, ref sqlConnection);

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
                        AccPaymentListResultWork accPaymentWork = (AccPaymentListResultWork)al[k];

                        // �O�񌎎��X�V�N����
                        DateTime laMonCAddUpUpdDate = DateTime.MinValue;

                        if (!isCheckOut)
                        {
                            // �O�񌎎��X�V�N�����擾
                            payeeDateDic.TryGetValue(accPaymentWork.AddUpSecCode.Trim() + "_" + accPaymentWork.PayeeCode.ToString("000000"), out laMonCAddUpUpdDate);
                        }

                        //�d���f�[�^�擾
                        status = SearchStockProc(ref accPaymentWork, ref sqlConnection, _accPaymentListCndtnWork, isCheckOut, laMonCAddUpUpdDate, suplAccPayDateDic);

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
                // --- ADD END 3H ������ 2020/03/02 ----------<<<<<
// �C�� 2009.01.27 <<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchProc Exception=" + ex.Message);
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

            // --- UPD START 3H ������ 2020/02/28 ---------->>>>>
            //if (al.Count > 0)
            //{
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            if (_accPaymentListCndtnWork.TaxPrintDiv == (int)TaxTotalDiv.TaxTotalOFF)
            {
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            // --- UPD END 3H ������ 2020/02/28 ----------<<<<<

            accPaymentListResultWork = al;

            return status;
        }
        #endregion  //[SearchProc]

        #region [SearchSuppProc]
        /// <summary>
        /// �d����}�X�^��������ɊY������d���惊�X�g�𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_accPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ惊�X�g��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchSuppProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // SUPPLIERRF        SUPLER �d����}�X�^
                // SECINFOSETRF      SCINST ���_���ݒ�}�X�^

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUPLER.PAYEECODERF" + Environment.NewLine;
                // �C�� 2009.01.27 >>>
                //selectTxt += " ,SUPLER.MNGSECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SUPLER.PAYMENTSECTIONCODERF" + Environment.NewLine;
                // �C�� 2009.01.27 <<<
                selectTxt += " ,SUPLER.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                //FROM
                selectTxt += " FROM SUPPLIERRF AS SUPLER" + Environment.NewLine;

                //JOIN
                //���_���ݒ�}�X�^
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SUPLER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=SUPLER.PAYMENTSECTIONCODERF" + Environment.NewLine;

                #region [WHERE��]
                selectTxt += " WHERE" + Environment.NewLine;

                //��ƃR�[�h
                selectTxt += " SUPLER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND SUPLER.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND SUPLER.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //���_�R�[�h
                if (_accPaymentListCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _accPaymentListCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        // �C�� 2009.01.27 >>>
                        //selectTxt += " AND SUPLER.MNGSECTIONCODERF IN (" + sectionCodestr + ") ";                        
                        selectTxt += " AND SUPLER.PAYMENTSECTIONCODERF IN (" + sectionCodestr + ") ";
                        // �C�� 2009.01.27 <<<
                    }
                    selectTxt += Environment.NewLine;
                }

                //�x����R�[�h
                if (_accPaymentListCndtnWork.St_PayeeCode != 0)
                {
                    selectTxt += " AND SUPLER.SUPPLIERCDRF>=@ST_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.St_PayeeCode);
                }
                if (_accPaymentListCndtnWork.St_PayeeCode != 999999)
                {
                    selectTxt += " AND SUPLER.SUPPLIERCDRF<=@ED_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.Ed_PayeeCode);
                }
                // ADD 2008.11.13 >>>
                selectTxt += " AND SUPLER.SUPPLIERCDRF IS NOT null" + Environment.NewLine;
                selectTxt += " AND SUPLER.SUPPLIERCDRF != 0" + Environment.NewLine;
                selectTxt += " AND SUPLER.SUPPLIERCDRF = SUPLER.PAYEECODERF" + Environment.NewLine;
                // ADD 2008.11.13 <<<
                #endregion  //[WHERE��]

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
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
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchSuppProc Exception=" + ex.Message);
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

        // --- ADD 2012/10/01 ---------->>>>>
        #region [SearchSuppGeneralProc]
        /// <summary>
        /// �d���f�[�^��������ɊY������d���惊�X�g�𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_accPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ惊�X�g��߂��܂�</br>
        /// <br>Programmer : FSI����(�f)</br>
        /// <br>Date       : 2012/10/01</br>
        private int SearchSuppGeneralProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // SUPPLIERRF        SUPPLIER  �d����}�X�^
                // SECINFOSETRF      SCINST    ���_���ݒ�}�X�^

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  SUPLER.PAYEECODERF" + Environment.NewLine;
                selectTxt += " ,SCINST.SECTIONCODERF AS PAYMENTSECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SUPLER.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                //FROM
                selectTxt += " FROM SUPPLIERRF AS SUPLER" + Environment.NewLine;

                //JOIN
                //���_���ݒ�}�X�^
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF = SUPLER.ENTERPRISECODERF" + Environment.NewLine;
                #region [WHERE��]
                selectTxt += " WHERE" + Environment.NewLine;

                //��ƃR�[�h
                selectTxt += " SUPLER.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

                //�_���폜�敪
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    selectTxt += " AND SUPLER.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    selectTxt += " AND SUPLER.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
                }

                //���_�R�[�h
                if (_accPaymentListCndtnWork.SectionCodes != null)
                {
                    string sectionCodestr = "";
                    foreach (string seccdstr in _accPaymentListCndtnWork.SectionCodes)
                    {
                        if (sectionCodestr != "")
                        {
                            sectionCodestr += ",";
                        }
                        sectionCodestr += "'" + seccdstr + "'";
                    }
                    if (sectionCodestr != "")
                    {
                        selectTxt += " AND SCINST.SECTIONCODERF IN (" + sectionCodestr + ") ";
                    }
                    selectTxt += Environment.NewLine;
                }

                //�x����R�[�h
                if (_accPaymentListCndtnWork.St_PayeeCode != 0)
                {
                    selectTxt += " AND SUPLER.SUPPLIERCDRF>=@ST_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_SUPPLIERCD", SqlDbType.Int);
                    paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.St_PayeeCode);
                }
                if (_accPaymentListCndtnWork.St_PayeeCode != 999999)
                {
                    selectTxt += " AND SUPLER.SUPPLIERCDRF<=@ED_SUPPLIERCD" + Environment.NewLine;
                    SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_SUPPLIERCD", SqlDbType.Int);
                    paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.Ed_PayeeCode);
                }
                selectTxt += " AND SUPLER.SUPPLIERCDRF IS NOT null" + Environment.NewLine;
                selectTxt += " AND SUPLER.SUPPLIERCDRF != 0" + Environment.NewLine;
                selectTxt += " AND SUPLER.SUPPLIERCDRF = SUPLER.PAYEECODERF" + Environment.NewLine;

                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += "PAYMENTSECTIONCODERF" + Environment.NewLine;

                #endregion  //[WHERE��]

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYMENTSECTIONCODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                    ResultWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
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
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchSuppGeneralProc Exception=" + ex.Message);
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
        #endregion  //[SearchSuppGeneralProc]
        // --- ADD 2012/10/01 ----------<<<<<

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
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
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
                selectTxt += " AND PAYDTL.LOGICALDELETECODERF=0" + Environment.NewLine;  // 2009/04/30
                //WHERE
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      PAYSLP.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.DEBITNOTEDIVRF=0" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.SUPPLIERCDRF=@FINDSUPPLIERCD" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.ADDUPSECCODERF=@FINDADDUPSECCODE" + Environment.NewLine;
                selectTxt += "  AND PAYSLP.LOGICALDELETECODERF=0" + Environment.NewLine;  // 2009/04/30
                selectTxt += "  AND (PAYSLP.ADDUPADATERF<=@FINDADDUPDATE AND PAYSLP.ADDUPADATERF>@FINDLASTTIMEADDUPDATE)" + Environment.NewLine;
                //GROU BY
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
                    AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

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
        /// �w�肳�ꂽ�����̔��|�c���ꗗ�\��߂��܂�
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_accPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|�c���ꗗ�\��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        private int SearchAccPaymentProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, AccPaymentListResultWork SupplierListWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // SUPLACCPAYRF      SUPPAY �d���攃�|���z�}�X�^
                // ACALCPAYTOTALRF   ACAPAY ���|�x���W�v�f�[�^
                // SECINFOSETRF      SCINST ���_���ݒ�}�X�^

                #region [Select���쐬]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   SUPPAY.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  ,SCINST.SECTIONGUIDESNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYEECODERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.PAYEESNMRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.LASTTIMEACCPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += "  ,(SUPPAY.THISSTCKPRICRGDSRF+SUPPAY.THISSTCKPRICDISRF)" + Environment.NewLine;
                selectTxt += "   AS THISRGDSDISPRIC" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.STOCKSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.CASHPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.OTHSPAYMENT" + Environment.NewLine;
                selectTxt += "  ,SUPPAY.THISTIMESTOCKPRICERF" + Environment.NewLine; // ADD 2009.02.09
                //FROM
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;

                #region [�f�[�^���o���C��Query]
                //�d���攃�|���z�}�X�^
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    SUPPAYSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.PAYEECODERF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.PAYEESNMRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.LASTTIMEACCPAYRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMETTLBLCACPAYRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.OFSTHISTIMESTOCKRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISSTCKPRICRGDSRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISSTCKPRICDISRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.OFSTHISSTOCKTAXRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.STCKTTLACCPAYBALANCERF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.STOCKSLIPCOUNTRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMEFEEPAYNRMLRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMEDISPAYNRMLRF" + Environment.NewLine;
                selectTxt += "   ,SUPPAYSUB.THISTIMESTOCKPRICERF" + Environment.NewLine; // ADD 2009.02.09
                selectTxt += "   ,ACAPAY.CASHPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "   ,ACAPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "   ,(ACAPAY.OTHSPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.CASHPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "    -ACAPAY.FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "    ) AS OTHSPAYMENT" + Environment.NewLine;
                selectTxt += " FROM SUPLACCPAYRF AS SUPPAYSUB" + Environment.NewLine;

                //���|�x���W�v�f�[�^
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     ACAPAYSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.PAYEECODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=51 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS CASHPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=52 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS TRFRPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=53 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS CHECKPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=54 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS DRAFTPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=56 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS OFFSETPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM((CASE WHEN ACAPAYSUB.MONEYKINDCODERF=59 THEN ACAPAYSUB.PAYMENTRF ELSE 0 END)) AS FUNDTRANSFERPAYMENT" + Environment.NewLine;
                selectTxt += "    ,SUM(ACAPAYSUB.PAYMENTRF) AS OTHSPAYMENT" + Environment.NewLine;
                selectTxt += "   FROM ACALCPAYTOTALRF AS ACAPAYSUB" + Environment.NewLine;                              
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     ACAPAYSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.PAYEECODERF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "    ,ACAPAYSUB.ADDUPDATERF" + Environment.NewLine;
                selectTxt += "  ) AS ACAPAY" + Environment.NewLine;
                selectTxt += "  ON  ACAPAY.ENTERPRISECODERF=SUPPAYSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND ACAPAY.ADDUPSECCODERF=SUPPAYSUB.ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += "  AND ACAPAY.PAYEECODERF=SUPPAYSUB.PAYEECODERF" + Environment.NewLine;
                //selectTxt += "  AND ACAPAY.SUPPLIERCDRF=SUPPAYSUB.SUPPLIERCDRF" + Environment.NewLine; // DEL 2009/06/02
                selectTxt += "  AND ACAPAY.ADDUPDATERF=SUPPAYSUB.ADDUPDATERF" + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _accPaymentListCndtnWork, SupplierListWork, logicalMode);
                #endregion  //[�f�[�^���o���C��Query]

                selectTxt += " ) AS SUPPAY" + Environment.NewLine;

                #region [JOIN]
                //���_���ݒ�}�X�^
                selectTxt += " LEFT JOIN SECINFOSETRF SCINST" + Environment.NewLine;
                selectTxt += " ON  SCINST.ENTERPRISECODERF=SUPPAY.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SCINST.SECTIONCODERF=SUPPAY.ADDUPSECCODERF" + Environment.NewLine;
                #endregion  //[JOIN]

                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToRsltWork(ref myReader, _accPaymentListCndtnWork));
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
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchAccPaymentProc Exception=" + ex.Message);
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
        /// <param name="_accPaymentListCndtnWork">���������i�[�N���X</param>
        /// <param name="SupplierListWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>���|�c���������o��SQL������</returns>
        /// <br>Note       : WHERE�吶������</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.11.09</br>
        /// <br></br>
        /// <br>Note       : �萔���ƒl�����ȊO�̎x���`�[�̏ꍇ�A�󎚂���Ȃ��Ή�</br>
        /// <br>Programmer : 30755 FSI����(�f)</br>
        /// <br>Date       : 2012/11/07</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AccPaymentListCndtnWork _accPaymentListCndtnWork, AccPaymentListResultWork SupplierListWork,  ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "";
            retstring += " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " SUPPAYSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

            //�_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND SUPPAYSUB.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND SUPPAYSUB.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //�e���R�[�h�݂̂�ΏۂƂ���(�d����R�[�h=0�̂ݑΏ�)
            retstring += " AND SUPPAYSUB.SUPPLIERCDRF=0" + Environment.NewLine;

            //���_�R�[�h
            // �C�� 2009.01.27 >>>
            //if (_accPaymentListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _accPaymentListCndtnWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }
            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND SUPPAYSUB.ADDUPSECCODERF IN (" + sectionCodestr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}
            if (SupplierListWork.AddUpSecCode != null)
            {
                retstring += " AND SUPPAYSUB.ADDUPSECCODERF = @ADDUPSECCODE";
                SqlParameter paraAddupsecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddupsecCode.Value = SqlDataMediator.SqlSetString(SupplierListWork.AddUpSecCode);
            }
            // �C�� 2009.01.27 <<<

            //�Ώ۔N��
            if (_accPaymentListCndtnWork.AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND SUPPAYSUB.ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraSt_AddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraSt_AddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_accPaymentListCndtnWork.AddUpYearMonth);
            }

            //�x����R�[�h
            // �C�� 2009.01.27 >>>
            //if (_accPaymentListCndtnWork.St_PayeeCode != 0)
            //{
            //    retstring += " AND SUPPAYSUB.PAYEECODERF>=@ST_PAYEECODE" + Environment.NewLine;
            //    SqlParameter paraSt_PayeeCode = sqlCommand.Parameters.Add("@ST_PAYEECODE", SqlDbType.Int);
            //    paraSt_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.St_PayeeCode);
            //}
            //if (_accPaymentListCndtnWork.St_PayeeCode != 999999999)
            //{
            //    retstring += " AND SUPPAYSUB.PAYEECODERF<=@ED_PAYEECODE" + Environment.NewLine;
            //    SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODE", SqlDbType.Int);
            //    paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(_accPaymentListCndtnWork.Ed_PayeeCode);
            //}
            if (SupplierListWork.PayeeCode != 0)
            {
                retstring += " AND SUPPAYSUB.PAYEECODERF=@PAYEECODE" + Environment.NewLine;
                SqlParameter paraPayeeCode = sqlCommand.Parameters.Add("@PAYEECODE", SqlDbType.Int);
                paraPayeeCode.Value = SqlDataMediator.SqlSetInt32(SupplierListWork.PayeeCode);

            }
            // �C�� 2009.01.27 <<<

            //0:�S�� 1:0����׽ 2:��׽�̂� 3:0�̂� 4:��׽��ϲŽ 5:0��ϲŽ 6:ϲŽ�̂�
            switch (_accPaymentListCndtnWork.OutMoneyDiv)
            {
                case 0:
                    break;
                case 1:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF>=0" + Environment.NewLine;
                    break;
                case 2:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF>0" + Environment.NewLine;
                    break;
                case 3:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF=0" + Environment.NewLine;
                    break;
                case 4:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF!=0" + Environment.NewLine;
                    break;
                case 5:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF<=0" + Environment.NewLine;
                    break;
                case 6:
                    retstring += " AND SUPPAYSUB.STCKTTLACCPAYBALANCERF<0" + Environment.NewLine;
                    break;
            }
            // ADD 2009.02.13 >>>
            retstring += "AND ( SUPPAYSUB.LASTTIMEACCPAYRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.THISTIMEFEEPAYNRMLRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.THISTIMEDISPAYNRMLRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.OFSTHISTIMESTOCKRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.OFSTHISSTOCKTAXRF != 0" + Environment.NewLine;
            // --- DEL 2012/11/07 ---------->>>>>
            //retstring += "      OR SUPPAYSUB.STOCKSLIPCOUNTRF != 0)" + Environment.NewLine;
            // --- DEL 2012/11/07 ----------<<<<<
            // --- ADD 2012/11/07 ---------->>>>>
            retstring += "      OR SUPPAYSUB.STOCKSLIPCOUNTRF != 0" + Environment.NewLine;
            retstring += "      OR SUPPAYSUB.THISTIMEPAYNRMLRF != 0)" + Environment.NewLine;
            // --- ADD 2012/11/07 ----------<<<<<
            // ADD 2009.02.13 <<<
            #endregion  //WHERE���쐬

            return retstring.ToString();
        }
        #endregion  //[WHERE�吶������]

        #region [���|�c���ꗗ�\���o���ʃN���X�i�[����]
        /// <summary>
        /// ���|�c���ꗗ�\���o���ʃN���X�i�[���� Reader �� AccPaymentListResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="_accPaymentListCndtnWork">AccPaymentListResultWork</param>
        /// <returns>AccPaymentListResultWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
        /// </remarks>
        private AccPaymentListResultWork CopyToRsltWork(ref SqlDataReader myReader, AccPaymentListCndtnWork _accPaymentListCndtnWork)
        {
            AccPaymentListResultWork ResultWork = new AccPaymentListResultWork();

            #region [���o����-�l�Z�b�g]
            ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
            ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
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
            if (_accPaymentListCndtnWork.PayDtlDiv == (int)PayDtlDiv.PayDtlON)
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
        #endregion  //[���|�c���ꗗ�\���o���ʃN���X�i�[����]

        // --- ADD 2012/11/14 ---------->>>>>
        #region [SearchMonAddUpProc]
        /// <summary>
        /// �������X�V�����}�X�^��������ɊY�����錎�����X�V�������X�g�𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_accPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌������X�V�������X�g��߂��܂�</br>
        /// <br>Programmer : FSI ���� �f��</br>
        /// <br>Date       : 2012/11/14</br>
        private int SearchMonAddUpProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // MONTHLYADDUPHISRF RES �������X�V�����}�X�^

                #region [Select���쐬]
                selectTxt += "SELECT DISTINCT" + Environment.NewLine;
                selectTxt += "  RES.ADDUPSECCODERF" + Environment.NewLine; // �v�㋒�_�R�[�h
                selectTxt += " ,RES.HISTCTLCDRF" + Environment.NewLine;    // ���𐧌�敪(0:�m�� 1:���m��(�������))
                //FROM
                selectTxt += "FROM(" + Environment.NewLine;
                selectTxt += " 	SELECT" + Environment.NewLine;
                selectTxt += " 	  ENTERPRISECODERF" + Environment.NewLine;      // ��ƃR�[�h
                selectTxt += " 	 ,ACCRECACCPAYDIVRF" + Environment.NewLine;     // ���|���|�敪(0:���| 1:���|)
                selectTxt += " 	 ,ADDUPSECCODERF" + Environment.NewLine;        // �v�㋒�_�R�[�h
                selectTxt += " 	 ,MONTHADDUPYEARMONTHRF" + Environment.NewLine; // �����X�V�N��
                selectTxt += " 	 ,HISTCTLCDRF" + Environment.NewLine;           // ���𐧌�敪(0:�m�� 1:���m��(�������))
                selectTxt += " 	FROM MONTHLYADDUPHISRF" + Environment.NewLine;
                #region [WHERE��]
                selectTxt += " 	WHERE" + Environment.NewLine;
                // ��ƃR�[�h
                selectTxt += " 	 ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

                // ���|���|�敪
                selectTxt += "   AND ACCRECACCPAYDIVRF = 1" + Environment.NewLine;

                // �_���폜�敪
                selectTxt += "   AND LOGICALDELETECODERF = 0" + Environment.NewLine;

                // �����X�V�N��
                selectTxt += "   AND MONTHADDUPYEARMONTHRF = @ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraMonthAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraMonthAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_accPaymentListCndtnWork.AddUpYearMonth);

                // �G���[�X�e�[�^�X
                selectTxt += "   AND ERRORSTATUSRF = 0" + Environment.NewLine;
                #endregion  //[WHERE��]

                selectTxt += " 	GROUP BY" + Environment.NewLine;
                selectTxt += "    ENTERPRISECODERF" + Environment.NewLine;      // ��ƃR�[�h
                selectTxt += "   ,ACCRECACCPAYDIVRF" + Environment.NewLine;     // ���|���|�敪(0:���| 1:���|))
                selectTxt += "   ,ADDUPSECCODERF" + Environment.NewLine;        // �v�㋒�_�R�[�h
                selectTxt += "   ,HISTCTLCDRF" + Environment.NewLine;           // ���𐧌�敪(0:�m�� 1:���m��(�������))
                selectTxt += "   ,MONTHADDUPYEARMONTHRF" + Environment.NewLine; // �����X�V�N��

                selectTxt += ") AS RES" + Environment.NewLine;
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += " RES.ADDUPSECCODERF" + Environment.NewLine;
                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    MonAddUpCAddUpHisResultWork ResultWork = new MonAddUpCAddUpHisResultWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    ResultWork.HistCtlCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTCTLCDRF"));
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
                base.WriteErrorLog(ex, "MonAddUpCAddUpHisResultWork.SearchMonAddUpProc Exception=" + ex.Message);
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
        #endregion  //[SearchMonAddUpProc]

        #region [SearchMonAddDataUpTimeProc]
        /// <summary>
        /// �������X�V�����}�X�^����Ō�ɍX�V�������𐧌�敪�����m��̃f�[�^�X�V������1���擾���������X�V�������X�g�𒊏o���܂��B
        /// </summary>
        /// <param name="al">��������</param>
        /// <param name="_accPaymentListCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ō�ɍX�V�������𐧌�敪�����m��̃f�[�^�X�V������1���擾���܂�</br>
        /// <br>Programmer : FSI ���� �f��</br>
        /// <br>Date       : 2012/11/14</br>
        private int SearchMonAddDataUpTimeProc(ref ArrayList al, AccPaymentListCndtnWork _accPaymentListCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // MONTHLYADDUPHISRF RES �������X�V�����}�X�^

                #region [Select���쐬]
                selectTxt += "SELECT TOP 1" + Environment.NewLine;
                selectTxt += "  RES.CREATEDATETIMERF" + Environment.NewLine;      // �쐬����
                selectTxt += " ,RES.UPDATEDATETIMERF" + Environment.NewLine;      // �X�V����
                selectTxt += " ,RES.ENTERPRISECODERF" + Environment.NewLine;      // ��ƃR�[�h
                selectTxt += " ,RES.FILEHEADERGUIDRF" + Environment.NewLine;      // GUID
                selectTxt += " ,RES.UPDEMPLOYEECODERF" + Environment.NewLine;     // �X�V�]�ƈ��R�[�h
                selectTxt += " ,RES.UPDASSEMBLYID1RF" + Environment.NewLine;      // �X�V�A�Z���u��ID1
                selectTxt += " ,RES.UPDASSEMBLYID2RF" + Environment.NewLine;      // �X�V�A�Z���u��ID2
                selectTxt += " ,RES.LOGICALDELETECODERF" + Environment.NewLine;   // �_���폜�敪
                selectTxt += " ,RES.ACCRECACCPAYDIVRF" + Environment.NewLine;     // ���|���|�敪
                selectTxt += " ,RES.ADDUPSECCODERF" + Environment.NewLine;        // �v�㋒�_�R�[�h
                selectTxt += " ,RES.STMONCADDUPUPDDATERF" + Environment.NewLine;  // �����X�V�J�n�N����
                selectTxt += " ,RES.MONTHLYADDUPDATERF" + Environment.NewLine;    // �����X�V�N����
                selectTxt += " ,RES.MONTHADDUPYEARMONTHRF" + Environment.NewLine; // �����X�V�N��
                selectTxt += " ,RES.MONTHADDUPEXPDATERF" + Environment.NewLine;   // �����X�V���s�N����
                selectTxt += " ,RES.LAMONCADDUPUPDDATERF" + Environment.NewLine;  // �O�񌎎��X�V�N����
                selectTxt += " ,RES.DATAUPDATEDATETIMERF" + Environment.NewLine;  // �f�[�^�X�V����
                selectTxt += " ,RES.PROCDIVCDRF" + Environment.NewLine;           // �����敪
                selectTxt += " ,RES.ERRORSTATUSRF" + Environment.NewLine;         // �G���[�X�e�[�^�X
                selectTxt += " ,RES.HISTCTLCDRF" + Environment.NewLine;           // ���𐧌�敪
                selectTxt += " ,RES.PROCRESULTRF" + Environment.NewLine;          // ��������
                selectTxt += " ,RES.CONVERTPROCESSDIVCDRF" + Environment.NewLine; // �R���o�[�g�����敪
                //FROM
                selectTxt += "FROM(" + Environment.NewLine;
                selectTxt += " 	SELECT" + Environment.NewLine;
                selectTxt += "    CREATEDATETIMERF" + Environment.NewLine;      // �쐬����
                selectTxt += " 	 ,UPDATEDATETIMERF" + Environment.NewLine;      // �X�V����
                selectTxt += "   ,ENTERPRISECODERF" + Environment.NewLine;      // ��ƃR�[�h
                selectTxt += "   ,FILEHEADERGUIDRF" + Environment.NewLine;      // GUID
                selectTxt += "   ,UPDEMPLOYEECODERF" + Environment.NewLine;     // �X�V�]�ƈ��R�[�h
                selectTxt += "   ,UPDASSEMBLYID1RF" + Environment.NewLine;      // �X�V�A�Z���u��ID1
                selectTxt += "   ,UPDASSEMBLYID2RF" + Environment.NewLine;      // �X�V�A�Z���u��ID2
                selectTxt += "   ,LOGICALDELETECODERF" + Environment.NewLine;   // �_���폜�敪
                selectTxt += "   ,ACCRECACCPAYDIVRF" + Environment.NewLine;     // ���|���|�敪
                selectTxt += "   ,ADDUPSECCODERF" + Environment.NewLine;        // �v�㋒�_�R�[�h
                selectTxt += "   ,STMONCADDUPUPDDATERF" + Environment.NewLine;  // �����X�V�J�n�N����
                selectTxt += "   ,MONTHLYADDUPDATERF" + Environment.NewLine;    // �����X�V�N����
                selectTxt += "   ,MONTHADDUPYEARMONTHRF" + Environment.NewLine; // �����X�V�N��
                selectTxt += "   ,MONTHADDUPEXPDATERF" + Environment.NewLine;   // �����X�V���s�N����
                selectTxt += "   ,LAMONCADDUPUPDDATERF" + Environment.NewLine;  // �O�񌎎��X�V�N����
                selectTxt += "   ,DATAUPDATEDATETIMERF" + Environment.NewLine;  // �f�[�^�X�V����
                selectTxt += "   ,PROCDIVCDRF" + Environment.NewLine;           // �����敪
                selectTxt += "   ,ERRORSTATUSRF" + Environment.NewLine;         // �G���[�X�e�[�^�X
                selectTxt += "   ,HISTCTLCDRF" + Environment.NewLine;           // ���𐧌�敪
                selectTxt += "   ,PROCRESULTRF" + Environment.NewLine;          // ��������
                selectTxt += "   ,CONVERTPROCESSDIVCDRF" + Environment.NewLine; // �R���o�[�g�����敪

                selectTxt += " 	FROM MONTHLYADDUPHISRF" + Environment.NewLine;
                #region [WHERE��]
                selectTxt += " 	WHERE" + Environment.NewLine;
                // ��ƃR�[�h
                selectTxt += " 	 ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.EnterpriseCode);

                // ���|���|�敪
                selectTxt += "   AND ACCRECACCPAYDIVRF = 1" + Environment.NewLine;

                // �_���폜�敪
                selectTxt += "   AND LOGICALDELETECODERF = 0" + Environment.NewLine;

                // �����X�V�N��
                selectTxt += "   AND MONTHADDUPYEARMONTHRF = @ADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraMonthAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                paraMonthAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_accPaymentListCndtnWork.AddUpYearMonth);

                // �G���[�X�e�[�^�X
                selectTxt += "   AND ERRORSTATUSRF = 0" + Environment.NewLine;

                // �v�㋒�_�R�[�h
                selectTxt += "   AND ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                SqlParameter paraAddupsecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddupsecCode.Value = SqlDataMediator.SqlSetString(_accPaymentListCndtnWork.AddUpSecCode);

                // �����敪(0:�X�V���� 1:��������)
                selectTxt += "   AND PROCDIVCDRF = 0" + Environment.NewLine;

                // ���𐧌�敪(0:�m�� 1:���m��(�������))
                if (_accPaymentListCndtnWork.MonAddUpEnable == 1)
                {
                    selectTxt += "   AND HISTCTLCDRF = 1" + Environment.NewLine;
                }
                else
                {
                    selectTxt += "   AND HISTCTLCDRF = 0" + Environment.NewLine;
                }

                #endregion  //[WHERE��]

                selectTxt += " 	GROUP BY" + Environment.NewLine;
                selectTxt += "    CREATEDATETIMERF" + Environment.NewLine;      // �쐬����
                selectTxt += " 	 ,UPDATEDATETIMERF" + Environment.NewLine;      // �X�V����
                selectTxt += "   ,ENTERPRISECODERF" + Environment.NewLine;      // ��ƃR�[�h
                selectTxt += "   ,FILEHEADERGUIDRF" + Environment.NewLine;      // GUID
                selectTxt += "   ,UPDEMPLOYEECODERF" + Environment.NewLine;     // �X�V�]�ƈ��R�[�h
                selectTxt += "   ,UPDASSEMBLYID1RF" + Environment.NewLine;      // �X�V�A�Z���u��ID1
                selectTxt += "   ,UPDASSEMBLYID2RF" + Environment.NewLine;      // �X�V�A�Z���u��ID2
                selectTxt += "   ,LOGICALDELETECODERF" + Environment.NewLine;   // �_���폜�敪
                selectTxt += "   ,ACCRECACCPAYDIVRF" + Environment.NewLine;     // ���|���|�敪
                selectTxt += "   ,ADDUPSECCODERF" + Environment.NewLine;        // �v�㋒�_�R�[�h
                selectTxt += "   ,STMONCADDUPUPDDATERF" + Environment.NewLine;  // �����X�V�J�n�N����
                selectTxt += "   ,MONTHLYADDUPDATERF" + Environment.NewLine;    // �����X�V�N����
                selectTxt += "   ,MONTHADDUPYEARMONTHRF" + Environment.NewLine; // �����X�V�N��
                selectTxt += "   ,MONTHADDUPEXPDATERF" + Environment.NewLine;   // �����X�V���s�N����
                selectTxt += "   ,LAMONCADDUPUPDDATERF" + Environment.NewLine;  // �O�񌎎��X�V�N����
                selectTxt += "   ,DATAUPDATEDATETIMERF" + Environment.NewLine;  // �f�[�^�X�V����
                selectTxt += "   ,PROCDIVCDRF" + Environment.NewLine;           // �����敪
                selectTxt += "   ,ERRORSTATUSRF" + Environment.NewLine;         // �G���[�X�e�[�^�X
                selectTxt += "   ,HISTCTLCDRF" + Environment.NewLine;           // ���𐧌�敪
                selectTxt += "   ,PROCRESULTRF" + Environment.NewLine;          // ��������
                selectTxt += "   ,CONVERTPROCESSDIVCDRF" + Environment.NewLine; // �R���o�[�g�����敪

                selectTxt += ") AS RES" + Environment.NewLine;
                selectTxt += "ORDER BY" + Environment.NewLine;
                selectTxt += " RES.DATAUPDATEDATETIMERF" + Environment.NewLine;
                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    MonAddUpCAddUpHisResultWork ResultWork = new MonAddUpCAddUpHisResultWork();

                    #region [���o����-�l�Z�b�g]
                    ResultWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                    ResultWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                    ResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    ResultWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                    ResultWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                    ResultWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                    ResultWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                    ResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                    ResultWork.AccRecAccPayDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECACCPAYDIVRF"));
                    ResultWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    ResultWork.StMonCAddUpUpdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STMONCADDUPUPDDATERF"));
                    ResultWork.MonthlyAddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("MONTHLYADDUPDATERF"));
                    ResultWork.MonthAddUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHADDUPYEARMONTHRF"));
                    ResultWork.MonthAddUpExpDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MONTHADDUPEXPDATERF"));
                    ResultWork.LaMonCAddUpUpdDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LAMONCADDUPUPDDATERF"));
                    ResultWork.DataUpdateDateTime = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DATAUPDATEDATETIMERF"));
                    ResultWork.ProcDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PROCDIVCDRF"));
                    ResultWork.ErrorStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERRORSTATUSRF"));
                    ResultWork.HistCtlCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HISTCTLCDRF"));
                    ResultWork.ProcResult = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PROCRESULTRF"));
                    ResultWork.ConvertProcessDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONVERTPROCESSDIVCDRF"));
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
                base.WriteErrorLog(ex, "MonAddUpCAddUpHisResultWork.SearchMonAddDataUpTimeProc Exception=" + ex.Message);
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
        #endregion  //[SearchMonAddDataUpTimeProc]

        #region [SearchMonAddUpDateProc]
        /// <summary>
        /// �������X�V�����}�X�^�̗��𐧌�敪���m��ɂ��܂��B
        /// </summary>
        /// <param name="_monAddUpCAddUpHisResultWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������X�V�����}�X�^�̗��𐧌�敪���m��ɂ��܂�</br>
        /// <br>Programmer : FSI����(�f)</br>
        /// <br>Date       : 2012/11/14</br>
        private int SearchMonAddUpDateProc(ref MonAddUpCAddUpHisResultWork _monAddUpCAddUpHisResultWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // MONTHLYADDUPHISRF  �������X�V�����f�[�^

                #region [Update���쐬]
                selectTxt += "UPDATE MONTHLYADDUPHISRF" + Environment.NewLine; //�������X�V�����f�[�^
                selectTxt += "SET HISTCTLCDRF = 0" + Environment.NewLine;      //���𐧌�敪(0:�m�� 1:���m��(�������))

                #region [WHERE��]
                selectTxt += " WHERE" + Environment.NewLine;

                //�����敪(0:�X�V���� 1:��������)
                selectTxt += "      PROCDIVCDRF = 0" + Environment.NewLine;

                //���𐧌�敪(0:�m�� 1:���m��(�������))
                selectTxt += "  AND HISTCTLCDRF = 1" + Environment.NewLine;

                //�����X�V�N��
                selectTxt += "  AND MONTHADDUPYEARMONTHRF = @MONTHADDUPYEARMONTH" + Environment.NewLine;
                SqlParameter paraMonthAddUpYearMonth = sqlCommand.Parameters.Add("@MONTHADDUPYEARMONTH", SqlDbType.Int);
                paraMonthAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_monAddUpCAddUpHisResultWork.MonthlyAddUpDate);

                //�v�㋒�_�R�[�h
                selectTxt += "  AND ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.AddUpSecCode);

                //���|���|�敪
                selectTxt += "  AND ACCRECACCPAYDIVRF = 1" + Environment.NewLine;

                //�_���폜�敪
                selectTxt += "  AND LOGICALDELETECODERF = 0" + Environment.NewLine;

                //�G���[�X�e�[�^�X
                selectTxt += "  AND ERRORSTATUSRF = 0" + Environment.NewLine;

                //�����X�V���s�N����
                selectTxt += "  AND DATAUPDATEDATETIMERF = @DATAUPDATEDATETIME" + Environment.NewLine;
                SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIME", SqlDbType.BigInt);
                paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetInt64(_monAddUpCAddUpHisResultWork.DataUpdateDateTime);

                #endregion  //[WHERE��]
                #endregion  //[Update���쐬]

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchMonAddUpDateProc Exception=" + ex.Message);
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
        #endregion  //[SearchMonAddUpDateProc]

        #region [SearchMonAddDataInsertProc]
        /// <summary>
        /// �������X�V�����}�X�^�Ƀ��R�[�h��ǉ����܂��B
        /// </summary>
        /// <param name="_monAddUpCAddUpHisResultWork">�����p�����[�^</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������X�V�����}�X�^�Ƀ��R�[�h��ǉ����܂�</br>
        /// <br>Programmer : FSI����(�f)</br>
        /// <br>Date       : 2012/11/14</br>
        private int SearchMonAddDataInsertProc(ref MonAddUpCAddUpHisResultWork _monAddUpCAddUpHisResultWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // MONTHLYADDUPHISRF  �������X�V�����f�[�^

                #region [Insert���쐬]
                selectTxt += "INSERT INTO MONTHLYADDUPHISRF" + Environment.NewLine;
                selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += " ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,ACCRECACCPAYDIVRF" + Environment.NewLine;
                selectTxt += " ,ADDUPSECCODERF" + Environment.NewLine;
                selectTxt += " ,STMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,MONTHLYADDUPDATERF" + Environment.NewLine;
                selectTxt += " ,MONTHADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,MONTHADDUPEXPDATERF" + Environment.NewLine;
                selectTxt += " ,LAMONCADDUPUPDDATERF" + Environment.NewLine;
                selectTxt += " ,DATAUPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += " ,PROCDIVCDRF" + Environment.NewLine;
                selectTxt += " ,ERRORSTATUSRF" + Environment.NewLine;
                selectTxt += " ,HISTCTLCDRF" + Environment.NewLine;
                selectTxt += " ,PROCRESULTRF" + Environment.NewLine;
                selectTxt += " ,CONVERTPROCESSDIVCDRF" + Environment.NewLine;
                selectTxt += " )" + Environment.NewLine;
                selectTxt += " VALUES" + Environment.NewLine;
                selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                selectTxt += " ,@UPDATEDATETIME" + Environment.NewLine;
                selectTxt += " ,@ENTERPRISECODE" + Environment.NewLine;
                selectTxt += " ,@FILEHEADERGUID" + Environment.NewLine;
                selectTxt += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                selectTxt += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                selectTxt += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                selectTxt += " ,@LOGICALDELETECODE" + Environment.NewLine;
                selectTxt += " ,@ACCRECACCPAYDIV" + Environment.NewLine;
                selectTxt += " ,@ADDUPSECCODE" + Environment.NewLine;
                selectTxt += " ,@STMONCADDUPUPDDATE" + Environment.NewLine;
                selectTxt += " ,@MONTHLYADDUPDATE" + Environment.NewLine;
                selectTxt += " ,@MONTHADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += " ,@MONTHADDUPEXPDATE" + Environment.NewLine;
                selectTxt += " ,@LAMONCADDUPUPDDATE" + Environment.NewLine;
                selectTxt += " ,@DATAUPDATEDATETIME" + Environment.NewLine;
                selectTxt += " ,@PROCDIVCD" + Environment.NewLine;
                selectTxt += " ,@ERRORSTATUS" + Environment.NewLine;
                selectTxt += " ,@HISTCTLCD" + Environment.NewLine;
                selectTxt += " ,@PROCRESULT" + Environment.NewLine;
                selectTxt += " ,@CONVERTPROCESSDIVCD" + Environment.NewLine;
                selectTxt += " )" + Environment.NewLine;
                #endregion  //[Insert���쐬]

                #region Parameter�I�u�W�F�N�g�쐬
                SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_monAddUpCAddUpHisResultWork.CreateDateTime);

                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_monAddUpCAddUpHisResultWork.UpdateDateTime);

                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.EnterpriseCode);

                SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(_monAddUpCAddUpHisResultWork.FileHeaderGuid);

                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.UpdEmployeeCode);

                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.UpdAssemblyId1);

                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.UpdAssemblyId2);

                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.LogicalDeleteCode);

                SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.AddUpSecCode);

                SqlParameter paraStMonCAddUpUpdDate = sqlCommand.Parameters.Add("@STMONCADDUPUPDDATE", SqlDbType.Int);
                paraStMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.StMonCAddUpUpdDate);

                SqlParameter paraMonthlyAddUpDate = sqlCommand.Parameters.Add("@MONTHLYADDUPDATE", SqlDbType.Int);
                paraMonthlyAddUpDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_monAddUpCAddUpHisResultWork.MonthlyAddUpDate);

                SqlParameter paraMonthAddUpYearMonth = sqlCommand.Parameters.Add("@MONTHADDUPYEARMONTH", SqlDbType.Int);
                paraMonthAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.MonthAddUpYearMonth);

                SqlParameter paraMonthAddUpExpDate = sqlCommand.Parameters.Add("@MONTHADDUPEXPDATE", SqlDbType.Int);
                paraMonthAddUpExpDate.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.MonthAddUpExpDate);

                SqlParameter paraDataUpdateDateTime = sqlCommand.Parameters.Add("@DATAUPDATEDATETIME", SqlDbType.BigInt);
                paraDataUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(_monAddUpCAddUpHisResultWork.CreateDateTime);

                SqlParameter paraLaMonCAddUpUpdDate = sqlCommand.Parameters.Add("@LAMONCADDUPUPDDATE", SqlDbType.Int);
                paraLaMonCAddUpUpdDate.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.LaMonCAddUpUpdDate);

                SqlParameter paraAccRecAccPayDiv = sqlCommand.Parameters.Add("@ACCRECACCPAYDIV", SqlDbType.Int);
                paraAccRecAccPayDiv.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.AccRecAccPayDiv);

                SqlParameter paraProcDivCd = sqlCommand.Parameters.Add("@PROCDIVCD", SqlDbType.Int);
                paraProcDivCd.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.ProcDivCd);

                SqlParameter paraErrorStatus = sqlCommand.Parameters.Add("@ERRORSTATUS", SqlDbType.Int);
                paraErrorStatus.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.ErrorStatus);

                SqlParameter paraHistCtlCd = sqlCommand.Parameters.Add("@HISTCTLCD", SqlDbType.Int);
                paraHistCtlCd.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.HistCtlCd);

                SqlParameter paraProcResult = sqlCommand.Parameters.Add("@PROCRESULT", SqlDbType.NVarChar);
                paraProcResult.Value = SqlDataMediator.SqlSetString(_monAddUpCAddUpHisResultWork.ProcResult);

                SqlParameter paraConvertProcessDivCd = sqlCommand.Parameters.Add("@CONVERTPROCESSDIVCD", SqlDbType.Int);
                paraConvertProcessDivCd.Value = SqlDataMediator.SqlSetInt32(_monAddUpCAddUpHisResultWork.ConvertProcessDivCd);
                #endregion
                  
                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccPaymentListWorkDB.SearchMonAddDataInsertProc Exception=" + ex.Message);
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
        #endregion  //[SearchMonAddDataInsertProc]
        // --- ADD 2012/11/14 ----------<<<<<

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.09.22</br>
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

        // --- ADD START 3H ������ 2020/03/02 ---------->>>>>
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
        /// <br>Date       : 2020/02/28</br>
        /// </remarks>
        private int SearchSuplAccPayDate(AccPaymentListCndtnWork accPaymentListCndtnWork, ref Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string sqlText = string.Empty;

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  ADDUPSECCODERF," + Environment.NewLine;
                    sqlText += "  PAYEECODERF," + Environment.NewLine;
                    sqlText += "  ADDUPDATERF," + Environment.NewLine;
                    sqlText += "  LAMONCADDUPUPDDATERF" + Environment.NewLine;
                    sqlText += " FROM SUPLACCPAYRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                    sqlText += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "    AND ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "    AND SUPPLIERCDRF=0" + Environment.NewLine;

                    //�x����R�[�h
                    if (accPaymentListCndtnWork.St_PayeeCode != 0)
                    {
                        sqlText += " AND PAYEECODERF>=@ST_PAYEECODECD" + Environment.NewLine;
                        SqlParameter paraSt_SupplierCd = sqlCommand.Parameters.Add("@ST_PAYEECODECD", SqlDbType.Int);
                        paraSt_SupplierCd.Value = SqlDataMediator.SqlSetInt32(accPaymentListCndtnWork.St_PayeeCode);
                    }
                    if (accPaymentListCndtnWork.Ed_PayeeCode != 999999)
                    {
                        sqlText += " AND PAYEECODERF<=@ED_PAYEECODECD" + Environment.NewLine;
                        SqlParameter paraEd_PayeeCode = sqlCommand.Parameters.Add("@ED_PAYEECODECD", SqlDbType.Int);
                        paraEd_PayeeCode.Value = SqlDataMediator.SqlSetInt32(accPaymentListCndtnWork.Ed_PayeeCode);
                    }
                    sqlText += " ORDER BY PAYEECODERF" + Environment.NewLine;

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
        /// <param name="accPaymentListCndtnWork">���|�c���ꗗ�\���o����</param>
        /// <param name="isCheckOut">�����t���b�O</param>
        /// <param name="laMonCAddUpUpdDate">�O�񌎎��X�V�N����</param>
        /// <param name="suplAccPayDateDic">�x���斈�̌����X�V�������f�B�N�V���i��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2020/03/02</br>
        /// <br>Note       : 11870141-00 �C���{�C�X�Ή��i�ŗ��ʍ��v���z�s��C���j</br>
        /// <br>Programmer : 3H ����</br>
        /// <br>Date       : 2022/10/09</br>
        /// </remarks>
        private int SearchStockProc(ref AccPaymentListResultWork accPaymentWork, ref SqlConnection sqlConnection, AccPaymentListCndtnWork accPaymentListCndtnWork, bool isCheckOut, DateTime laMonCAddUpUpdDate, Dictionary<string, SuplAccPayDateInfo> suplAccPayDateDic)
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
                    // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                    sqlText += " SUPLIERPAY.TAXATIONCODERF, --�ېŋ敪" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
                    // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                    sqlText += " STOCK.TAXATIONCODERF, --�ېŋ敪" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
                    // --- DEL START 3H ���� 2022/10/09 ----->>>>>
                    //sqlText += "    SUBSTOCK.STOCKNETPRICERF + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STOCKNETPRICERF," + Environment.NewLine;
                    //sqlText += "    SUBSTOCK.STCKDISTTLTAXEXCRF - SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    //sqlText += "    (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =0 ) THEN (SUBSTOCK.STOCKTTLPRICTAXINCRF - SUBSTOCK.STOCKTTLPRICTAXEXCRF) ELSE 0 END) AS SLIPSTOCKPRICECONSTAX," + Environment.NewLine;
                    // --- DEL END 3H ���� 2022/10/09 -----<<<<<
                    // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                    sqlText += "      (CASE WHEN (SUBSTOCKDTL.SUPPLIERSLIPCDRF =10) THEN SUBSTOCKDTL.STOCKPRICE + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO WHEN (SUBSTOCKDTL.SUPPLIERSLIPCDRF =20) THEN SUBSTOCKDTL.RETSTOCKPRICE + SUBSTOCKDTL.DISSTOCKPRICETAXEXCGYO ELSE 0 END) AS STOCKNETPRICERF," + Environment.NewLine;
                    sqlText += "      SUBSTOCKDTL.DISGOODSSTAXEXCGYO AS STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "      SUBSTOCKDTL.TAXATIONCODERF AS TAXATIONCODERF, --�ېŋ敪" + Environment.NewLine;
                    sqlText += "      (CASE WHEN (SUBSTOCK.SUPPCTAXLAYCDRF =0 AND SUBSTOCKDTL.TAXATIONCODERF = 0) THEN (SUBSTOCK.STOCKTTLPRICTAXINCRF - SUBSTOCK.STOCKTTLPRICTAXEXCRF) ELSE 0 END) AS SLIPSTOCKPRICECONSTAX," + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
                    // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                    sqlText += "       DTL.TAXATIONCODERF, --�ېŋ敪 " + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
                    //sqlText += "       STOCK.SUPPLIERSLIPNORF --�d���`�[�ԍ� " + Environment.NewLine; // DEL 3H ���� 2022/10/09
                    // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                    sqlText += "       STOCK.SUPPLIERSLIPNORF, --�d���`�[�ԍ� " + Environment.NewLine;
                    sqlText += "       DTL.TAXATIONCODERF --�ېŋ敪 " + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
                    // �d�������I�v�V�����������̏ꍇ
                    if (accPaymentListCndtnWork.OptSuppEnable == 1)
                    {
                        sqlText += "    AND  STOCK.PAYEECODERF =@FINDPAYEECODE" + Environment.NewLine;
                    }
                    // �d�������I�v�V�������L���̏ꍇ
                    else
                    {
                        sqlText += "    AND STOCK.SUPPLIERCDRF =@FINDPAYEECODE" + Environment.NewLine;
                        sqlText += "    AND STOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                    }
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
                    //sqlText += "    STOCK.SUPPLIERCONSTAXRATERF" + Environment.NewLine; // DEL 3H ���� 2022/10/09
                    // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                    sqlText += "    STOCK.SUPPLIERCONSTAXRATERF," + Environment.NewLine;
                    sqlText += "    STOCK.TAXATIONCODERF" + Environment.NewLine;
                    // --- ADD END 3H ���� 2022/10/09 -----<<<<<
                    sqlText += ") AS SUPLIERPAY" + Environment.NewLine;
                    #endregion

                    #endregion

                    sqlCommand.CommandText = sqlText;

                    #region  Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaPayeeCode = sqlCommand.Parameters.Add("@FINDPAYEECODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaLastTimeAddUpDate = sqlCommand.Parameters.Add("@FINDLASTTIMEADDUPDATE", SqlDbType.Int);
                    SqlParameter findParaAddUpSecCode = null;
                    // �d�������I�v�V�������L���̏ꍇ
                    if (accPaymentListCndtnWork.OptSuppEnable != 1)
                    {
                        findParaAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
                    }
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaPayeeCode.Value = SqlDataMediator.SqlSetInt32(accPaymentWork.PayeeCode);
                    findParaAddUpDate.Value = SqlDataMediator.SqlSetInt32(addUpDate);
                    // �d�������I�v�V�������L���̏ꍇ
                    if (accPaymentListCndtnWork.OptSuppEnable != 1)
                    {
                        findParaAddUpSecCode.Value = SqlDataMediator.SqlSetString(accPaymentWork.AddUpSecCode);
                    }

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

                        // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                        // �ېŋ敪
                        int taxAtionCodeRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                        // --- ADD END 3H ���� 2022/10/09 -----<<<<<

                        #endregion
                        
                        #region �ŕʓ����
                        //if (suplAccPayWork.SuppCTaxLayCd != 9 && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate1) // DEL 3H ���� 2022/10/09
                        if ((suplAccPayWork.SuppCTaxLayCd != 9 && taxAtionCodeRF != 1) && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate1) // ADD 3H ���� 2022/10/09
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
                        //else if (suplAccPayWork.SuppCTaxLayCd != 9 && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate2) // DEL 3H ���� 2022/10/09
                        else if ((suplAccPayWork.SuppCTaxLayCd != 9 && taxAtionCodeRF != 1) && suplAccPayWork.SupplierConsTaxRate == accPaymentListCndtnWork.TaxRate2)// ADD 3H ���� 2022/10/09
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
                        // --- ADD START 3H ���� 2022/10/09 ----->>>>>
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
                        // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
                                // sqlText += "	    SUBSTOCK.STOCKTTLPRICTAXEXCRF," + Environment.NewLine; // DEL 3H ���� 2022/10/09
                                // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                                sqlText += "	 (SELECT SUM(STOCKPRICETAXEXCRF) AS STOCKTTLPRICTAXEXCRF  FROM STOCKDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSTOCK.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERFORMALRF = DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERSLIPNORF  = DTL.SUPPLIERSLIPNORF " + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONCODERF = 0) AS STOCKTTLPRICTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
                                sqlText += "        AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                                sqlText += ") AS STOCK" + Environment.NewLine;
                                // �d�������I�v�V�����������̏ꍇ
                                if (accPaymentListCndtnWork.OptSuppEnable == 1)
                                {
                                    sqlText += "    WHERE  STOCK.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                                }
                                // �d�������I�v�V�������L���̏ꍇ
                                else
                                {
                                    sqlText += "    WHERE STOCK.SUPPLIERCDRF=@FINDPAYEECODE" + Environment.NewLine;
                                    sqlText += "    AND STOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                                }
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
                                // sqlText += "	    SUBSTOCK.STOCKTTLPRICTAXEXCRF," + Environment.NewLine; // DEL 3H ���� 2022/10/09
                                // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                                sqlText += "	 (SELECT SUM(STOCKPRICETAXEXCRF) AS STOCKTTLPRICTAXEXCRF  FROM STOCKDETAILRF AS DTL WITH (READUNCOMMITTED) WHERE " + Environment.NewLine;
                                sqlText += "       SUBSTOCK.ENTERPRISECODERF = DTL.ENTERPRISECODERF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERFORMALRF = DTL.SUPPLIERFORMALRF" + Environment.NewLine;
                                sqlText += "       AND SUBSTOCK.SUPPLIERSLIPNORF  = DTL.SUPPLIERSLIPNORF " + Environment.NewLine;
                                sqlText += "       AND DTL.TAXATIONCODERF = 0) AS STOCKTTLPRICTAXEXCRF, " + Environment.NewLine;
                                // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
                                sqlText += "        AND (SUBSTOCK.SUPPLIERSLIPCDRF = 10 OR SUBSTOCK.SUPPLIERSLIPCDRF = 20)" + Environment.NewLine;
                                sqlText += "        AND (SUBSTOCK.STOCKGOODSCDRF=0 OR SUBSTOCK.STOCKGOODSCDRF = 6)" + Environment.NewLine;
                                sqlText += ") AS STOCK" + Environment.NewLine;
                                // �d�������I�v�V�����������̏ꍇ
                                if (accPaymentListCndtnWork.OptSuppEnable == 1)
                                {
                                    sqlText += "    WHERE  STOCK.PAYEECODERF=@FINDPAYEECODE" + Environment.NewLine;
                                }
                                // �d�������I�v�V�������L���̏ꍇ
                                else
                                {
                                    sqlText += "    WHERE STOCK.SUPPLIERCDRF=@FINDPAYEECODE" + Environment.NewLine;
                                    sqlText += "    AND STOCK.STOCKSECTIONCDRF = @FINDADDUPSECCODE" + Environment.NewLine;
                                }
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
                    // --- ADD START 3H ���� 2022/10/09 ----->>>>>
                    // �������v(�v��ې�)
                    accPaymentWork.TotalStckTtlAccPayBalanceTaxFree = accPaymentWork.TotalPureStockTaxFree + accPaymentWork.TotalStockPricTaxTaxFree;
                    // --- ADD END 3H ���� 2022/10/09 -----<<<<<
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
        /// <br>Date       : 2020/03/02</br>
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
        // --- ADD END 3H ������ 2020/03/02 ----------<<<<<

        /// <summary>
        /// �x������敪��񋓂��܂��B
        /// </summary>
        enum PayDtlDiv
        {
            PayDtlON = 0,  //0:�󎚂���
            PayDtlOFF = 1  //1:�󎚂��Ȃ�
        }
    }

    // --- ADD START 3H ������ 2020/02/28 ---------->>>>>
    # region [�����X�V�E�������������]
    /// <summary>
    /// �������������
    /// </summary>
    /// <remarks>
    /// <br>Note       : 11570208-00 �y���ŗ��Ή�</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2020/02/28</br>
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
    // --- ADD END 3H ������ 2020/02/28 ----------<<<<<
}
