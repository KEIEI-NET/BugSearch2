//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���s�����m�F�\
// �v���O�����T�v   : �d���s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/10  �C�����e : �V�K�쐬
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d���s�����m�F�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���s�����m�F�\�A�N�Z�X�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.13</br>
    /// </remarks>
    public class StockSalesInfoMainAcs
    {

        #region �� Constructor
        /// <summary>
        /// �d���s�����m�F�\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :�d���s�����m�F�\�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public StockSalesInfoMainAcs()
        {
            this._iStockSalesInfoTableDB = (IStockSalesInfoTableDB)Broadleaf.Application.Remoting.Adapter.MediationStockSalesInfoTableDB.GetStockSalesInfoTableDB();
        }

        /// <summary>
        /// �d���s�����m�F�\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���s�����m�F�\�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        static StockSalesInfoMainAcs()
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

        #region �� Const
        const string errFlgConst = "1";
        const string stockOnleFlgConst = "2";
        const int zeroFlgConst = -1;
        const string normalFlgConst = "0";
        const string existMsg = "���オ�쐬����Ă��܂���";
        const string masterMsg = "���L�R�[�h���o�^����Ă��܂���";
        const string countMsg = "�d���Ɣ���Ő��ʂ����Ⴕ�Ă��܂�";
        const string priceMsg = "�d���Ɣ���Ō��������Ⴕ�Ă��܂�";
        #endregion

        #region �� Private Member

        IStockSalesInfoTableDB _iStockSalesInfoTableDB;//�d���s�����m�F�\�A�N�Z�X

        private DataSet _custAccRecDs;				    // �d���s�����m�F�\�f�[�^�Z�b�g

        #endregion �� Private Member

        #region �� Public Property
        /// <summary> �d���s�����m�F�\�f�[�^�Z�b�g(�ǂݎ���p)</summary>
        /// <value>CustAccRecDs</value>               
        /// <remarks>�d���s�����m�F�\�f�[�^�Z�b�g(�ǂݎ���p)�擾�v���p�e�B </remarks> 
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
        /// <param name="StockSalesInfoMainCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������钠�[�o�̓f�[�^���擾����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public int SearchCustAccRecMainForPdf(StockSalesInfoMainCndtn StockSalesInfoMainCndtn, out string errMsg)
        {
            return this.SearchCustAccRecMainProcForPdf(StockSalesInfoMainCndtn, out errMsg);
        }
        #endregion



        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �d���s�����m�F�\�f�[�^�擾
        /// <summary>
        /// ���[�o�͐ݒ�f�[�^�擾
        /// </summary>
        /// <param name="StockSalesInfoMainCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int SearchCustAccRecMainProcForPdf(StockSalesInfoMainCndtn StockSalesInfoMainCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKOU02045EA.CreateDataTableStockSalesInfoAccRecMain(ref this._custAccRecDs);
                StockSalesInfoMainCndtnWork stockSalesInfoMainCndtnWork = new StockSalesInfoMainCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevCustAccRecMainCndtn(StockSalesInfoMainCndtn, out stockSalesInfoMainCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retCustAccRecMainList = null;
                status = this._iStockSalesInfoTableDB.Search(out retCustAccRecMainList, stockSalesInfoMainCndtnWork);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevStockSalesMainData(StockSalesInfoMainCndtn, this._custAccRecDs.Tables[PMKOU02045EA.Tbl_StockSalesInfoAccRecMain], (ArrayList)retCustAccRecMainList);
                        if (this._custAccRecDs.Tables[PMKOU02045EA.Tbl_StockSalesInfoAccRecMain].Rows.Count < 1)
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
                        errMsg = "�d���s�����m�F�\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <param name="StockSalesInfoMainCndtn">UI���o�����N���X</param>
        /// <param name="stockSalesInfoMainCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s���܂��B</br>		
        /// <br>Programmer : ���痈</br>		
        /// <br>Date       : 2009.04.13</br>		
        /// </remarks>		
        private int DevCustAccRecMainCndtn(StockSalesInfoMainCndtn StockSalesInfoMainCndtn, out StockSalesInfoMainCndtnWork stockSalesInfoMainCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            stockSalesInfoMainCndtnWork = new StockSalesInfoMainCndtnWork();

            try
            {
                // ��ƃR�[�h
                stockSalesInfoMainCndtnWork.EnterpriseCode = StockSalesInfoMainCndtn.EnterpriseCode;

                // ���o�����p�����[�^�Z�b�g
                if ((null != StockSalesInfoMainCndtn.CollectAddupSecCodeList)
                    && (StockSalesInfoMainCndtn.CollectAddupSecCodeList.Length != 0))
                {
                    if (StockSalesInfoMainCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = null;
                    }
                    else
                    {
                        stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = StockSalesInfoMainCndtn.CollectAddupSecCodeList;
                    }
                }
                else
                {
                    stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = null;
                }


                //�Ώ۔N��
                stockSalesInfoMainCndtnWork.YearMonth = StockSalesInfoMainCndtn.YearMonth;

                //�O���������
                stockSalesInfoMainCndtnWork.PrevTotalDay = StockSalesInfoMainCndtn.PrevTotalDay;

                //�����������
                stockSalesInfoMainCndtnWork.CurrentTotalDay = StockSalesInfoMainCndtn.CurrentTotalDay;
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
        /// �d���s�����m�F�\���[�e�[�u���f�[�^�W�J����
        /// </summary>
        /// <param name="StockSalesInfoMainCndtn">UI���o�����N���X</param>
        /// <param name="custAccRecMainDt">�W�J�Ώ�DataTable</param>
        /// <param name="custAccRecMainWork">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �d���s�����m�F�\���[�e�[�u���f�[�^��W�J����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private void DevStockSalesMainData(StockSalesInfoMainCndtn StockSalesInfoMainCndtn, DataTable custAccRecMainDt, ArrayList custAccRecMainWork)
        {
            DataRow dr;
            StockSalesInfoWork disAccRecmainResWork = null;
            int count = custAccRecMainWork.Count;
            StringBuilder checkMsg = null;
            bool saveFlg = false;
            for (int i = 0; i < count; i++)
            {
                checkMsg = new StringBuilder(string.Empty);

                disAccRecmainResWork = (StockSalesInfoWork)custAccRecMainWork[i];

                dr = custAccRecMainDt.NewRow();

                saveFlg = false;

                //���_�R�[�h
                dr[PMKOU02045EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                //���_����
                dr[PMKOU02045EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;

                //�d����R�[�h
                dr[PMKOU02045EA.Col_SupplierCdHeader] = disAccRecmainResWork.SupplierCdHeader;

                //�d���旪��
                dr[PMKOU02045EA.Col_SupplierSnm] = GetStringToByte(disAccRecmainResWork.SupplierSnm, 20);

                //���t
                dr[PMKOU02045EA.Col_StockDate] = disAccRecmainResWork.StockDate;

                //���͓��t
                dr[PMKOU02045EA.Col_InputDay] = DateTime.ParseExact(disAccRecmainResWork.InputDay.ToString(), StockSalesInfoMainCndtn.ct_DateFomat, null).ToString(StockSalesInfoMainCndtn.ct_DateFomatWithLine);

                //�`�[�ԍ�
                dr[PMKOU02045EA.Col_PartySlipNumDtl] = disAccRecmainResWork.PartySlipNumDtl;

                //�d��SEQ�ԍ�-�s
                dr[PMKOU02045EA.Col_SeqNo] = disAccRecmainResWork.SupplierSlipNo + "-" + disAccRecmainResWork.StockRowNo;

                //���_�R�[�h
                dr[PMKOU02045EA.Col_SectionCode] = disAccRecmainResWork.SectionCode;

                //�S����
                dr[PMKOU02045EA.Col_StockAgentCode] = disAccRecmainResWork.StockAgentCode;

                //�d����R�[�h
                if (zeroFlgConst == disAccRecmainResWork.SupplierCd)
                {
                    dr[PMKOU02045EA.Col_SupplierCd] = string.Empty;
                }
                else
                {
                    dr[PMKOU02045EA.Col_SupplierCd] = disAccRecmainResWork.SupplierCd;
                }

                //BL�R�[�h
                if (zeroFlgConst == disAccRecmainResWork.BLGoodsCode)
                {
                    dr[PMKOU02045EA.Col_BLGoodsCode] = string.Empty;
                }
                else
                {
                    dr[PMKOU02045EA.Col_BLGoodsCode] = disAccRecmainResWork.BLGoodsCode;
                }

                //�O���[�v
                if (zeroFlgConst == disAccRecmainResWork.BLGroupCode)
                {
                    dr[PMKOU02045EA.Col_BLGroupCode] = string.Empty;
                }
                else
                {
                    dr[PMKOU02045EA.Col_BLGroupCode] = disAccRecmainResWork.BLGroupCode;
                }

                //�q��
                dr[PMKOU02045EA.Col_WarehouseCode] = disAccRecmainResWork.WarehouseCode;

                if ((normalFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                {
                    //���Ӑ�
                    if (zeroFlgConst == disAccRecmainResWork.CustomerCode)
                    {
                        dr[PMKOU02045EA.Col_CustomerCode] = string.Empty;
                    }
                    else
                    {
                        dr[PMKOU02045EA.Col_CustomerCode] = disAccRecmainResWork.CustomerCode;
                    }

                    //����`�[�ԍ�
                    dr[PMKOU02045EA.Col_SalesSlipNum] = disAccRecmainResWork.SalesSlipNum;
                }

                //�s�������e���쐬
                //�}�X�^�`�F�b�N
                if ((!string.IsNullOrEmpty(disAccRecmainResWork.SectionCode))
                    || (!string.IsNullOrEmpty(disAccRecmainResWork.StockAgentCode))
                    || (disAccRecmainResWork.BLGoodsCode >= 0)
                    || (disAccRecmainResWork.BLGroupCode >= 0)
                    || (!string.IsNullOrEmpty(disAccRecmainResWork.WarehouseCode))
                    || (disAccRecmainResWork.SupplierCd >= 0))
                {
                    dr[PMKOU02045EA.Col_NayiYou] = masterMsg;
                    if ((stockOnleFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                    {
                        //lineflag
                        dr[PMKOU02045EA.Col_LineFlag] = true;
                    }
                    else if ((normalFlgConst.Equals(disAccRecmainResWork.ExistFlg))
                            && (normalFlgConst.Equals(disAccRecmainResWork.CountFlg))
                            && (normalFlgConst.Equals(disAccRecmainResWork.PriceFlg)))
                    {
                        //lineflag
                        dr[PMKOU02045EA.Col_LineFlag] = true;
                    }
                    else
                    {
                        //lineflag
                        dr[PMKOU02045EA.Col_LineFlag] = false;
                    }

                    // Table��Add
                    custAccRecMainDt.Rows.Add(dr);

                    saveFlg = true;
                }

                if (!(stockOnleFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                {
                    //����`�[�`�F�b�N
                    if (errFlgConst.Equals(disAccRecmainResWork.ExistFlg))
                    {
                        if (saveFlg)
                        {
                            dr = custAccRecMainDt.NewRow();

                            //���_�R�[�hHeader
                            dr[PMKOU02045EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                            //���_����
                            dr[PMKOU02045EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;

                        }

                        //�s�������e
                        dr[PMKOU02045EA.Col_NayiYou] = existMsg;

                        //lineflag
                        dr[PMKOU02045EA.Col_LineFlag] = true;

                        // Table��Add
                        custAccRecMainDt.Rows.Add(dr);

                        saveFlg = true;

                    }
                    else
                    {
                        //���ʃ`�F�b�N
                        if (errFlgConst.Equals(disAccRecmainResWork.CountFlg))
                        {
                            if (saveFlg)
                            {
                                dr = custAccRecMainDt.NewRow();

                                //���_�R�[�hHeader
                                dr[PMKOU02045EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                                //���_����
                                dr[PMKOU02045EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;
                            }

                            //�s�������e
                            dr[PMKOU02045EA.Col_NayiYou] = countMsg;

                            if ((normalFlgConst.Equals(disAccRecmainResWork.PriceFlg)))
                            {
                                //lineflag
                                dr[PMKOU02045EA.Col_LineFlag] = true;
                            }
                            else
                            {
                                //lineflag
                                dr[PMKOU02045EA.Col_LineFlag] = false;
                            }

                            // Table��Add
                            custAccRecMainDt.Rows.Add(dr);

                            saveFlg = true;
                        }

                        //�����`�F�b�N
                        if (errFlgConst.Equals(disAccRecmainResWork.PriceFlg))
                        {
                            if (saveFlg)
                            {
                                dr = custAccRecMainDt.NewRow();

                                //���_�R�[�hHeader
                                dr[PMKOU02045EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                                //���_����
                                dr[PMKOU02045EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;
                            }

                            //�s�������e
                            dr[PMKOU02045EA.Col_NayiYou] = priceMsg;

                            //lineflag
                            dr[PMKOU02045EA.Col_LineFlag] = true;

                            // Table��Add
                            custAccRecMainDt.Rows.Add(dr);

                            saveFlg = true;
                        }
                    }
                }
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
        /// <br>Date       : 2009.04.13</br>
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
        /// <br>Date       : 2009.04.13</br>
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
        #endregion �� ���[�f�[�^�擾
        #endregion �� Private Method

    }
}
