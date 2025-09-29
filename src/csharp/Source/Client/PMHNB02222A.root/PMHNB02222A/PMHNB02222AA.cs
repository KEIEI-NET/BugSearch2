//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����s�����m�F�\
// �v���O�����T�v   : ����s�����m�F�\���[���s��
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
    /// ����s�����m�F�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����s�����m�F�\�A�N�Z�X�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.13</br>
    /// </remarks>
    public class SalesStockInfoMainAcs
    {

        #region �� Constructor
        /// <summary>
        /// ����s�����m�F�\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       :����s�����m�F�\�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public SalesStockInfoMainAcs()
        {
            this._iSalesStockInfoTableDB = (ISalesStockInfoTableDB)Broadleaf.Application.Remoting.Adapter.MediationSalesStockInfoTableDB.GetSalesStockInfoTableDB();
        }

        /// <summary>
        /// ����s�����m�F�\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����s�����m�F�\�ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        static SalesStockInfoMainAcs()
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
        const string normalFlgConst = "0";
        const string saleOnleFlgConst = "2";
        const string sign = "�A";
        const int zeroFlgConst = -1;
        const string existMsg = "�d�����쐬����Ă��܂���";
        const string masterMsg = "���L�R�[�h���o�^����Ă��܂���";
        const string countMsg = "����Ǝd���Ő��ʂ����Ⴕ�Ă��܂�";
        const string priceMsg = "����Ǝd���Ō��������Ⴕ�Ă��܂�";
        #endregion

        #region �� Private Member
        ISalesStockInfoTableDB _iSalesStockInfoTableDB;  //����s�����m�F�\�A�N�Z�X
        private DataSet _custAccRecDs;				    // ����s�����m�F�\�f�[�^�Z�b�g
        #endregion �� Private Member

        #region �� Public Property
        /// <summary> ����s�����m�F�\�f�[�^�Z�b�g(�ǂݎ���p)</summary>
        /// <value>CustAccRecDs</value>               
        /// <remarks>����s�����m�F�\�f�[�^�Z�b�g(�ǂݎ���p)�擾�v���p�e�B </remarks> 
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
        /// <param name="SalesStockInfoMainCndtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������钠�[�o�̓f�[�^���擾����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        public int SearchCustAccRecMainForPdf(SalesStockInfoMainCndtn SalesStockInfoMainCndtn, out string errMsg)
        {
            return this.SearchCustAccRecMainProcForPdf(SalesStockInfoMainCndtn, out errMsg);
        }
        #endregion



        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� ����s�����m�F�\�f�[�^�擾
        /// <summary>
        /// ���[�o�͐ݒ�f�[�^�擾
        /// </summary>
        /// <param name="SalesStockInfoMainCndtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������f�[�^���擾����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private int SearchCustAccRecMainProcForPdf(SalesStockInfoMainCndtn SalesStockInfoMainCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMHNB02225EA.CreateDataTableSalesStockInfoAccRecMain(ref this._custAccRecDs);
                SalesStockInfoMainCndtnWork stockSalesInfoMainCndtnWork = new SalesStockInfoMainCndtnWork();
                // ���o�����W�J  --------------------------------------------------------------
                status = this.DevCustAccRecMainCndtn(SalesStockInfoMainCndtn, out stockSalesInfoMainCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retCustAccRecMainList = null;
                status = this._iSalesStockInfoTableDB.Search(out retCustAccRecMainList, stockSalesInfoMainCndtnWork);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        DevSalesStockMainData(SalesStockInfoMainCndtn, this._custAccRecDs.Tables[PMHNB02225EA.Tbl_SalesStockInfoAccRecMain], (ArrayList)retCustAccRecMainList);
                        if (this._custAccRecDs.Tables[PMHNB02225EA.Tbl_SalesStockInfoAccRecMain].Rows.Count < 1)
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
                        errMsg = "����s�����m�F�\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <param name="SalesStockInfoMainCndtn">UI���o�����N���X</param>
        /// <param name="stockSalesInfoMainCndtnWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s���܂��B</br>		
        /// <br>Programmer : ���痈</br>		
        /// <br>Date       : 2009.04.13</br>		
        /// </remarks>		
        private int DevCustAccRecMainCndtn(SalesStockInfoMainCndtn SalesStockInfoMainCndtn, out SalesStockInfoMainCndtnWork stockSalesInfoMainCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            stockSalesInfoMainCndtnWork = new SalesStockInfoMainCndtnWork();

            try
            {
                // ��ƃR�[�h
                stockSalesInfoMainCndtnWork.EnterpriseCode = SalesStockInfoMainCndtn.EnterpriseCode;

                // ���o�����p�����[�^�Z�b�g
                if ((null != SalesStockInfoMainCndtn.CollectAddupSecCodeList)
                    && (SalesStockInfoMainCndtn.CollectAddupSecCodeList.Length != 0))
                {
                    if (SalesStockInfoMainCndtn.IsSelectAllSection)
                    {
                        // �S�Ђ̎�
                        stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = null;
                    }
                    else
                    {
                        stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = SalesStockInfoMainCndtn.CollectAddupSecCodeList;
                    }
                }
                else
                {
                    stockSalesInfoMainCndtnWork.CollectAddupSecCodeList = null;
                }


                //�Ώ۔N��
                stockSalesInfoMainCndtnWork.YearMonth = SalesStockInfoMainCndtn.YearMonth;

                //�O���������
                stockSalesInfoMainCndtnWork.PrevTotalDay = SalesStockInfoMainCndtn.PrevTotalDay;

                //�����������
                stockSalesInfoMainCndtnWork.CurrentTotalDay = SalesStockInfoMainCndtn.CurrentTotalDay;

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
        /// ����s�����m�F�\���[�e�[�u���f�[�^�W�J����
        /// </summary>
        /// <param name="SalesStockInfoMainCndtn">UI���o�����N���X</param>
        /// <param name="custAccRecMainDt">�W�J�Ώ�DataTable</param>
        /// <param name="custAccRecMainWork">�擾�f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ����s�����m�F�\���[�e�[�u���f�[�^��W�J����B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.13</br>
        /// </remarks>
        private void DevSalesStockMainData(SalesStockInfoMainCndtn SalesStockInfoMainCndtn, DataTable custAccRecMainDt, ArrayList custAccRecMainWork)
        {
            DataRow dr;
            SalesStockInfoWork disAccRecmainResWork = null;
            int count = custAccRecMainWork.Count;
            bool saveFlg = false;
            for (int i = 0; i < count; i++)
            {
                disAccRecmainResWork = (SalesStockInfoWork)custAccRecMainWork[i];

                saveFlg = false;

                dr = custAccRecMainDt.NewRow();

                //���_�R�[�hHeader
                dr[PMHNB02225EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                //���_����
                dr[PMHNB02225EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;

                //���Ӑ�Header
                dr[PMHNB02225EA.Col_CustomerCodeHeader] = disAccRecmainResWork.CustomerCodeHeader;

                //���Ӑ旪��
                dr[PMHNB02225EA.Col_CustomerSnm] = GetStringToByte(disAccRecmainResWork.CustomerSnm, 20);


                //���t
                dr[PMHNB02225EA.Col_SalesDate] = DateTime.ParseExact(disAccRecmainResWork.SalesDate.ToString(), SalesStockInfoMainCndtn.ct_DateFomat, null).ToString(SalesStockInfoMainCndtn.ct_DateFomatWithLine);

                //���͓��t
                dr[PMHNB02225EA.Col_SearchSlipDate] = disAccRecmainResWork.SearchSlipDate;

                //�`�[�ԍ�-�s
                //dr[PMHNB02225EA.Col_PartySlipNumDtl] = disAccRecmainResWork.PartySlipNumDtl;
                dr[PMHNB02225EA.Col_SeqNo] = disAccRecmainResWork.SalesSlipNum + "-" + disAccRecmainResWork.SalesRowNo;


                //���_�R�[�h
                dr[PMHNB02225EA.Col_SectionCode] = disAccRecmainResWork.SectionCode;

                //����
                dr[PMHNB02225EA.Col_InputAgenCd] = disAccRecmainResWork.InputAgenCd;

                //����
                dr[PMHNB02225EA.Col_SalesInputCode] = disAccRecmainResWork.SalesInputCode;

                //��t
                dr[PMHNB02225EA.Col_FrontEmployeeCd] = disAccRecmainResWork.FrontEmployeeCd;

                //�̔�
                dr[PMHNB02225EA.Col_SalesEmployeeCd] = disAccRecmainResWork.SalesEmployeeCd;

                //���Ӑ�
                if (zeroFlgConst == disAccRecmainResWork.CustomerCode)
                {
                    dr[PMHNB02225EA.Col_CustomerCode] = string.Empty;
                }
                else
                {
                    dr[PMHNB02225EA.Col_CustomerCode] = disAccRecmainResWork.CustomerCode;
                }

                //BL�R�[�h
                if (zeroFlgConst == disAccRecmainResWork.BLGoodsCode)
                {
                    dr[PMHNB02225EA.Col_BLGoodsCode] = string.Empty;
                }
                else
                {
                    dr[PMHNB02225EA.Col_BLGoodsCode] = disAccRecmainResWork.BLGoodsCode;
                }

                //�O���[�v
                if (zeroFlgConst == disAccRecmainResWork.BLGroupCode)
                {
                    dr[PMHNB02225EA.Col_BLGroupCode] = string.Empty;
                }
                else
                {
                    dr[PMHNB02225EA.Col_BLGroupCode] = disAccRecmainResWork.BLGroupCode;
                }

                //�q��
                dr[PMHNB02225EA.Col_WarehouseCode] = disAccRecmainResWork.WarehouseCode;

                //�G���A    ����f�[�^�@�̔��G���A�R�[�h
                if (zeroFlgConst == disAccRecmainResWork.SalesAreaCode)
                {
                    dr[PMHNB02225EA.Col_SalesAreaCode] = string.Empty;
                }
                else
                {
                    dr[PMHNB02225EA.Col_SalesAreaCode] = disAccRecmainResWork.SalesAreaCode;
                }

                //�Ǝ�  ����f�[�^�@�Ǝ�R�[�h
                if (zeroFlgConst == disAccRecmainResWork.BusinessTypeCode)
                {
                    dr[PMHNB02225EA.Col_BusinessTypeCode] = string.Empty;
                }
                else
                {
                    dr[PMHNB02225EA.Col_BusinessTypeCode] = disAccRecmainResWork.BusinessTypeCode;
                }

                //�d����R�[�h
                if (normalFlgConst.Equals(disAccRecmainResWork.ExistFlg))
                {
                    if (zeroFlgConst == disAccRecmainResWork.SupplierCd)
                    {
                        dr[PMHNB02225EA.Col_SupplierCd] = string.Empty;
                    }
                    else
                    {
                        dr[PMHNB02225EA.Col_SupplierCd] = disAccRecmainResWork.SupplierCd;
                    }
                }
                else
                {
                    dr[PMHNB02225EA.Col_SupplierCd] = string.Empty;
                }

                if ((normalFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                {
                    //�d���`�[�ԍ�
                    //dr[PMHNB02225EA.Col_SalesSlipNum] = disAccRecmainResWork.SalesSlipNum;
                    dr[PMHNB02225EA.Col_PartySlipNumDtl] = disAccRecmainResWork.PartySlipNumDtl;

                    //�d��SEQ�ԍ�   SupplierSlipNo
                    dr[PMHNB02225EA.Col_SupplierSlipNo] = disAccRecmainResWork.SupplierSlipNo;
                }

                //�s�������e���쐬
                //�}�X�^�`�F�b�N
                if ((!string.IsNullOrEmpty(disAccRecmainResWork.SectionCode))
                    || (!string.IsNullOrEmpty(disAccRecmainResWork.SalesInputCode))
                    || (!string.IsNullOrEmpty(disAccRecmainResWork.FrontEmployeeCd))
                    || (!string.IsNullOrEmpty(disAccRecmainResWork.SalesEmployeeCd))
                    || (disAccRecmainResWork.CustomerCode >= 0)
                    || (disAccRecmainResWork.BLGoodsCode >= 0)
                    || (disAccRecmainResWork.BLGroupCode >= 0)
                    || (!string.IsNullOrEmpty(disAccRecmainResWork.WarehouseCode))
                    || (disAccRecmainResWork.SalesAreaCode >= 0)
                    || (disAccRecmainResWork.BusinessTypeCode >= 0)
                    || (disAccRecmainResWork.SupplierCd >= 0))
                {
                    dr[PMHNB02225EA.Col_NayiYou] = masterMsg;

                    if ((saleOnleFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                    {
                        //lineflag
                        dr[PMHNB02225EA.Col_LineFlag] = true;
                    }
                    else if ((normalFlgConst.Equals(disAccRecmainResWork.ExistFlg))
                        && (normalFlgConst.Equals(disAccRecmainResWork.CountFlg))
                        && (normalFlgConst.Equals(disAccRecmainResWork.PriceFlg)))
                    {
                        //lineflag
                        dr[PMHNB02225EA.Col_LineFlag] = true;
                    }
                    else
                    {
                        //lineflag
                        dr[PMHNB02225EA.Col_LineFlag] = false;
                    }

                    // Table��Add
                    custAccRecMainDt.Rows.Add(dr);

                    saveFlg = true;
                }


                //�d���`�[�`�F�b�N
                if (!(saleOnleFlgConst.Equals(disAccRecmainResWork.ExistFlg)))
                {
                    if (errFlgConst.Equals(disAccRecmainResWork.ExistFlg))
                    {
                        if (saveFlg)
                        {
                            dr = custAccRecMainDt.NewRow();

                            //���_�R�[�hHeader
                            dr[PMHNB02225EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                            //���_����
                            dr[PMHNB02225EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;
                        }

                        //�s�������e
                        dr[PMHNB02225EA.Col_NayiYou] = existMsg;

                        //lineflag
                        dr[PMHNB02225EA.Col_LineFlag] = true;

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
                                dr[PMHNB02225EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                                //���_����
                                dr[PMHNB02225EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;
                            }

                            //�s�������e
                            dr[PMHNB02225EA.Col_NayiYou] = countMsg;

                            if ((normalFlgConst.Equals(disAccRecmainResWork.PriceFlg)))
                            {
                                //lineflag
                                dr[PMHNB02225EA.Col_LineFlag] = true;
                            }
                            else
                            {
                                //lineflag
                                dr[PMHNB02225EA.Col_LineFlag] = false;
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
                                dr[PMHNB02225EA.Col_SectionCodeHeader] = disAccRecmainResWork.SectionCodeHeader;

                                //���_����
                                dr[PMHNB02225EA.Col_SectionName] = disAccRecmainResWork.SectionGuideNm;
                            }

                            //�s�������e
                            dr[PMHNB02225EA.Col_NayiYou] = priceMsg;

                            //lineflag
                            dr[PMHNB02225EA.Col_LineFlag] = true;

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
