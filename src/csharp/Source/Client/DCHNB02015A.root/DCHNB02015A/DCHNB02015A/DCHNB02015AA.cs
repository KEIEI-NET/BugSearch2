using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �󒍑ݏo�m�F�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>�󒍑ݏo�m�F�\�Ŏg�p����f�[�^���擾����B</br>
    /// <br>UpdateNote :2008/10/31 �Ɠc �M�u�@����ň󎚕��@�ύX</br>
    /// <br>UpdateNote :2009/01/30 ��� �r���@���s�^�C�v�̎d�l�ύX�B�󒍐��A�󒍎c���ǉ��B</br>
    /// <br>UpdateNote :2011/07/21 ����R�@�A��No.946 ���v�㕪�݂̂̈�����ł��Ȃ��̑Ή�</br>
    /// <br>UpdateNote :2011/08/11 ����R�@Redmine23472 �ꕔ�v��̓`�[�́u�ݏo�v�u�v��ρv�̗����őΏۂƂ��Ă��������B</br>
    /// <br>UpdateNote :2011/08/11 caohh�@Redmine#23472�Ή�</br>
    /// <br>UpdateNote :2011/09/30 yangyi�@Redmine#25724�Ή�</br>
    /// <br>UpdateNote :2011/10/09 ���N�n���@Redmine#25724�Ή�</br>
    /// <br>UpdateNote :2011/10/10 ���N�n���@Redmine#25724�Ή�</br>
    /// <br>UpdateNote :2011/12/02 �����@��Q�� #8316�Ή� �ݏo�m�F�\/���z�̎Z�o���@�̕ύX</br>
    /// <br>UpdateNote :2011/12/18 �����@��Q�� #8316�Ή� �ݏo�m�F�\/���z�̎Z�o���@�̕ύX</br>
    /// <br>UpdateNote :2011/12/19 �����@��Q�� #8316�Ή� �ݏo�m�F�\/���z�̎Z�o���@�̕ύX</br>
    /// </remarks>
    public class SaleConfAcs
    {
        // ===================================================================================== //
        //  �O���񋟒萔
        // ===================================================================================== //
        #region public constant
        /// <summary>�S���_���R�[�h�p���_�R�[�h</summary>
        public const string CT_AllSectionCode = "000000";
        #endregion

        // ===================================================================================== //
        //  �X�^�e�B�b�N�ϐ�
        // ===================================================================================== //
        #region static variable

        /// <summary>�����_�R�[�h</summary>
        private static string mySectionCode = "";
        // <summary>���[�o�͐ݒ�f�[�^�N���X</summary>
        private static PrtOutSet prtOutSetData = null;

        #endregion

        // ===================================================================================== //
        //  �����g�p�ϐ�
        // ===================================================================================== //
        #region private member

        private static SecInfoAcs _secInfoAcs;
        /// <summary>���[�o�͐ݒ�A�N�Z�X�N���X</summary>
        private static PrtOutSetAcs prtOutSetAcs = null;
        /// <summary>����pDataSet</summary>
        public DataSet _printDataSet;
        /// <summary>�o�b�t�@DataSet</summary>
        public static DataSet _printBuffDataSet;

        /// <summary>�󒍏o�׊m�F�\�f�[�^�e�[�u����</summary>
        private string _SalesConfDataTable;

        // ���[�^�C�v�i���v or ���ה���p�j
        private int _printDiv;      //ADD 2008/10/31

        // ------ ADD caohh 2011/08/11 ------->>>>>
        // ���s�^�C�v�i����p�j
        private int _publicationType;
        // ------ ADD caohh 2011/08/11 -------<<<<<

        /// <summary>�\������</summary>

        private string CT_Sort1_Odr01 = "SectionCode, SalesDate, SalesSlipNum, SalesRowNo ";	    //�i���_�j�{�󒍓��{�`�[�ԍ��{�s�ԍ�
        private string CT_Sort1_Odr02 = "SectionCode, ShipmentDay, SalesSlipNum, SalesRowNo ";	//�i���_�j�{�o�ד��{�`�[�ԍ��{�s�ԍ�
        private string CT_Sort2_Odr = "SectionCode,SalesSlipNum";									//�i���_�j�{�`�[�ԍ�
        private string CT_Sort3_Odr = "SectionCode,CustomerCode, SalesSlipNum";					//�i���_�j�{���Ӑ�{�`�[�ԍ�
        private string CT_Sort4_Odr = "SectionCode,SalesEmployeeCd, SalesSlipNum";				//�i���_�j�{�̔��]�ƈ�(�S����)�R�[�h�{�`�[�ԍ�

        private string CT_UpperOrder = " ASC";   // �����o��
        //private string CT_DownOrder  = " DESC";  // �~���o��

        #endregion

        // ===================================================================================== //
        //  �����g�p�萔
        // ===================================================================================== //
        #region private constant

        ///// <summary>�󒍏o�׊m�F�\�o�b�t�@�f�[�^�e�[�u����</summary>
        //public const string CT_SalesOrderBuffDataTable = Broadleaf.Application.UIData.DCHNB02014EA.CT_SalesOrderAgentBuffDataTable;
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region �R���X�g���N�^�[

        /// <summary>
        /// �󒍑ݏo�m�F�\�A�N�Z�X�N���X�R���X�g���N�^�[
        /// </summary>
        public SaleConfAcs()
        {
            this.SettingDataTable();

            // ����pDataSet
            this._printDataSet = new DataSet();
            DataSetColumnConstruction(ref this._printDataSet);
            // �o�b�t�@�e�[�u���f�[�^�Z�b�g
            if (_printBuffDataSet == null)
            {
                _printBuffDataSet = new DataSet();
                DataSetColumnConstruction(ref _printBuffDataSet);
            }

            // ���_���擾
            this.CreateSecInfoAcs();

        }

        #endregion

        // ===================================================================================== //
        // �ÓI�R���X�g���N�^
        // ===================================================================================== //
        #region �ÓI�R���X�g���N�^�[

        /// <summary>
        /// �󒍑ݏo�m�F�\�A�N�Z�X�N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        static SaleConfAcs()
        {
            // ���[�o�͐ݒ�A�N�Z�X�N���X�C���X�^���X��
            prtOutSetAcs = new PrtOutSetAcs();

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                mySectionCode = loginEmployee.BelongSectionCode;
            }
        }

        #endregion

        // ===================================================================================== //
        // �O���񋟊֐�
        // ===================================================================================== //
        #region public method

        /// <summary>
        /// ���[�o�͐ݒ�Ǎ�
        /// </summary>
        /// <param name="prtOutSet">���[�o�͐ݒ�f�[�^�N���X</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        /// <remarks>
        /// <br>Note       : �����_�̒��[�o�͐ݒ�̓Ǎ����s���܂��B</br>
        /// <br>UpdateNote : public int ReadPrtOutSet �� public static int ReadPrtOutSet �ɂ��܂����B</br>
        /// <br>Programmer : 30191 A.Mabuchi</br>
        /// <br>Date       : 2008.03.05</br>
        /// </remarks>
        public static int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            try
            {
                // �f�[�^�͓Ǎ��ς݂��H
                if (prtOutSetData != null)
                {
                    prtOutSet = prtOutSetData.Clone();
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            prtOutSet = prtOutSetData.Clone();
                            break;
                        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                        case (int)ConstantManagement.DB_Status.ctDB_EOF:
                            prtOutSet = new PrtOutSet();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        default:
                            prtOutSet = new PrtOutSet();
                            message = "���[�o�͐ݒ�̓Ǎ��Ɏ��s���܂����B";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        /// <summary>
        /// �󒍑ݏo�m�F�\�f�[�^����������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///  Static�������������܂��B
        /// </remarks>
        public void InitializeCustomerLedger()
        {
            // --�e�[�u���s������-----------------------
            // ���o���ʃf�[�^�e�[�u�����N���A
            if (this._printDataSet.Tables[_SalesConfDataTable] != null)
            {
                this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();
            }
            // ���o���ʃo�b�t�@�f�[�^�e�[�u�����N���A
            if (_printBuffDataSet.Tables[_SalesConfDataTable] != null)
            {
                _printBuffDataSet.Tables[_SalesConfDataTable].Rows.Clear();
            }
        }
        /// <summary>
        /// �󒍑ݏo�m�F�\�f�[�^�擾����
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="mode">�T�[�`���[�h(0:remote only,1:static��remote,2:static only)</param>
        /// <returns></returns>
        public int Search(ExtrInfo_DCHNB02013E saleConfListCndtn, out string message, int mode)
        {
            int status = 0;
            message = "";

            switch (mode)
            {
                case 0:
                    {
                        status = this.Search(saleConfListCndtn, out message);
                        break;
                    }
                case 1:
                    {
                        status = this.SearchStatic(out message);
                        if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                        {
                            status = this.Search(saleConfListCndtn, out message);
                        }
                        break;
                    }
                case 2:
                    {
                        // static only �̏ꍇ�̓����[�e�B���O�ɍs���Ȃ�
                        status = this.SearchStatic(out message);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return status;
        }


        /// <summary>
        /// �󒍑ݏo�m�F�\�X�^�e�B�b�N�f�[�^�擾����
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchStatic(out string message)
        {
            int status = 0;
            message = "";

            DataRow dr;
            DataRow buffDr;

            this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();

            if (_printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < _printBuffDataSet.Tables[_SalesConfDataTable].Rows.Count; i++)
                    {
                        dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();
                        buffDr = _printBuffDataSet.Tables[_SalesConfDataTable].Rows[i];

                        this.SetTebleRowFromDataRow(ref dr, buffDr);

                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);
                    }
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.Message;
                }
            }
            else
            {
                status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            return status;
        }
        /// <summary>
        /// �󒍑ݏo�m�F�\�f�[�^�擾����
        /// </summary>
        /// <param name="saleConfListCndtn"></param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>�Ώ۔͈͂̎󒍏o�׊m�F�\�f�[�^���擾���܂��B</br>
        /// <br>UpdateNote :2011/09/30 yangyi�@Redmine#25724�Ή�</br>
        /// <br>UpdateNote :2011/10/09 ���N�n���@Redmine#25724�Ή�</br>
        /// <br>UpdateNote :2011/10/10 ���N�n���@Redmine#25724�Ή�</br>
        /// <br>UpdateNote :2011/12/02 �����@Redmine#8316�Ή�</br>
        /// </remarks>
        private int Search(ExtrInfo_DCHNB02013E saleConfListCndtn, out string message)
        {
            object retObj;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            message = "";
            int printDiv = saleConfListCndtn.PrintDiv;	//SearchByMode�ɓn���A�`�[�`���敪�̔���p�ϐ�
            this._publicationType = saleConfListCndtn.PublicationType;	//���s�^�C�v�̔���p�ϐ� // ADD caohh 2011/08/11
            Dictionary<string, DataRow> _dicSalesNum = new Dictionary<string, DataRow>();        // ADD yangyi 2011/09/30  

            try
            {
                // StaticMemory�@������
                InitializeCustomerLedger();

                // �����[�g����f�[�^�̎擾
                OrderConfShWork orderConfShWork = new OrderConfShWork();
                // ���o�����p�����[�^�Z�b�g
                this.SearchParaSet(saleConfListCndtn, ref orderConfShWork);

                status = this.SearchByMode(out retObj, orderConfShWork, printDiv);

                this._printDiv = printDiv;      //ADD 2008/10/31  SetTebleRowFromRetList���Ŏg�p�����

                ArrayList retList = (ArrayList)retObj;
                // ----- ADD K2011/09/28 --------------------------->>>>>
                List<DataRow> drList = new List<DataRow>();
                List<DataRow> drListRet = new List<DataRow>();
                if (printDiv == 1 || printDiv == 3)
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);
                        drList.Add(dr);
                    }
                    foreach (DataRow dr in drList)
                    {
                        if (!_dicSalesNum.ContainsKey(dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()))
                        {
                            _dicSalesNum.Add(dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString(), dr);
                        }
                        else
                        {
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF].ToString())
                                                + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF].ToString())).ToString();
                            //---DEL 2011/10/09 --------------------------------------------------->>>>>
                            //_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_Tax] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_Tax].ToString())
                            //                    + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_Tax].ToString())).ToString();
                            //_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax].ToString())
                            //                    + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax].ToString())).ToString();
                            //---DEL 2011/10/09 ---------------------------------------------------<<<<<
                            //---ADD 2011/10/09 --------------------------------------------------->>>>>
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesMoney] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_SalesMoney].ToString())
                                                + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesMoney].ToString())).ToString();
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt].ToString())
                                                + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt].ToString())).ToString();
                            //---ADD 2011/10/10 --------------------------------------------------->>>>>
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt] = (Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt].ToString())
                                                + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt].ToString())).ToString();
                            //---ADD 2011/10/10 ---------------------------------------------------<<<<<
                            //---ADD 2011/10/09 ---------------------------------------------------<<<<<
                            //add 2011/12/02 ���� Redmine #8316----->>>>>
                            _dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_TotalCostRF] = Convert.ToInt64(_dicSalesNum[dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString()][DCHNB02014EA.CT_OrderConf_TotalCostRF])
                                               + Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_TotalCostRF]);
                            //add 2011/12/02 ���� Redmine #8316-----<<<<<
                        }

                    }
                    foreach (string numKey in _dicSalesNum.Keys)
                    {
                        drListRet.Add(_dicSalesNum[numKey]);
                    }
                    foreach (DataRow dr in drListRet)
                    {
                        //add 2011/12/02 ���� Redmine #8316----->>>>>
                        //����
                        dr[DCHNB02014EA.CT_OrderConf_TotalCostSl] = dr[DCHNB02014EA.CT_OrderConf_TotalCostRF];
                        //add 2011/12/18 ���� Redmine #8316----->>>>>
                        if (Convert.ToInt32(dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF])==0)//����
                        {
                        //add 2011/12/18 ���� Redmine #8316-----<<<<<   
                            //�e���F���z�]����
                            dr[DCHNB02014EA.CT_OrderConf_GrossProfit] =
                                Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesMoney]) -
                                Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_TotalCostRF]);
                            //�e����(���v)
                            //���z 0 �̏ꍇ�A�e������0�Ƃ��ăZ�b�g����
                            if (Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesMoney]) == 0)
                            {
                                dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] = 0;
                            }
                            else
                            {
                                dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] =
                                    Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossProfit]) * 100 /
                                    Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_SalesMoney]);
                            }
                            //�e���F���z�]����
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfit] =
                                Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_SalesMoney]) -
                                Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_TotalCostSl]);
                        //add 2011/12/18 ���� Redmine #8316----->>>>>
                        }
                        else if (Convert.ToInt32(dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF]) == 1)//�ԕi
                        {
                            //�e���F���z�]����
                            dr[DCHNB02014EA.CT_OrderConf_GrossProfit] = dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfit];

                            //�e����(���v)
                            //���z 0 �̏ꍇ�A�e������0�Ƃ��ăZ�b�g����
                            if (Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney]) == 0)
                            {
                                dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] = 0;
                            }
                            else
                            {
                                dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] =
                                    Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossProfit]) * 100 /
                                    Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney]);
                            }
                            //�e���F���z�]����
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfit] = dr[DCHNB02014EA.CT_OrderConf_GrossProfit];
                            //���z
                            dr[DCHNB02014EA.CT_OrderConf_SalesMoney] = dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney];
                            //�����
                            dr[DCHNB02014EA.CT_OrderConf_SalesTax] = dr[DCHNB02014EA.CT_OrderConf_ReturnTax];
                            //���v���z
                            dr[DCHNB02014EA.CT_OrderConf_SalesTotalAll] = dr[DCHNB02014EA.CT_OrderConf_ReturnTotalAll];
                            //����
                            dr[DCHNB02014EA.CT_OrderConf_TotalCostSl] = dr[DCHNB02014EA.CT_OrderConf_TotalCostRtn];
                                
                        }
                        //add 2011/12/18 ���� Redmine #8316-----<<<<<
                        //�e���`�F�b�N�}�[�N(���v)
                        if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate]) < orderConfShWork.GrsProfitCheckLower)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfShWork.GrossMargin1Mark;
                        }
                        else if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate]) < orderConfShWork.GrsProfitCheckBest)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfShWork.GrossMargin2Mark;
                        }
                        else if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate]) < orderConfShWork.GrsProfitCheckUpper)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfShWork.GrossMargin3Mark;
                        }
                        else 
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfShWork.GrossMargin4Mark;
                        }
                        //add 2011/12/02 ���� Redmine #8316-----<<<<<
                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                else
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        DataRow dr = this._printDataSet.Tables[_SalesConfDataTable].NewRow();

                        SetTebleRowFromRetList(ref dr, retList, i);
                        //add 2011/12/02 ���� Redmine #8316----->>>>>
                        //�e����(����)
                        //���z 0 �̏ꍇ�A�e������0�Ƃ��ăZ�b�g����
                        if (Convert.ToInt64(dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF]) == 0)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl] = 0;
                        }
                        else
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl] =
                                Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossProfitDtl])*100 /
                                                 Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF]);
                        }
                        //add 2011/12/18 ���� Redmine #8316----->>>>>
                        if (Convert.ToInt32(dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF]) == 1)//�ԕi
                        {
                            //�e���F���z�]����
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfitDtl] = dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfitDtl];
                            //���z
                            dr[DCHNB02014EA.CT_OrderConf_SalesMoneyDtl] = dr[DCHNB02014EA.CT_OrderConf_SalesMoneyRtnDtl];
                            //�����
                            dr[DCHNB02014EA.CT_OrderConf_SalesDtlTax] = dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnDtl];
                            //����
                            dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = dr[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl];
                        }
                        //add 2011/12/18 ���� Redmine #8316-----<<<<<
                        //�e���`�F�b�N�}�[�N(����)
                        if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl]) < orderConfShWork.GrsProfitCheckLower)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfShWork.GrossMargin1Mark;
                        }
                        else if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl]) < orderConfShWork.GrsProfitCheckBest)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfShWork.GrossMargin2Mark;
                        }
                        else if (Convert.ToDouble(dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl]) < orderConfShWork.GrsProfitCheckUpper)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfShWork.GrossMargin3Mark;
                        }
                        else
                        {
                            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfShWork.GrossMargin4Mark;
                        }
                        //add 2011/12/02 ���� Redmine #8316-----<<<<<
                        this._printDataSet.Tables[_SalesConfDataTable].Rows.Add(dr);

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                // ----- ADD K2011/09/01 ---------------------------<<<<<

                // --- ADD 2009/01/30 -------------------------------->>>>>
                // �󒍎c���ɂ��t�B���^����
                FilterByAcptAnOdrRemainCnt(saleConfListCndtn);

                if (this._printDataSet.Tables[_SalesConfDataTable].Rows.Count == 0)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                // --- ADD 2009/01/30 -------------------------------->>>>>

                // �o�b�t�@�e�[�u���ւ̊i�[
                _printBuffDataSet = this._printDataSet.Copy();
            }

            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.Message;
            }
            return status;
        }

        #endregion

        // ===================================================================================== //
        // �����g�p�֐�
        // ===================================================================================== //
        #region private method

        /// <summary>
        /// �����p�����[�^�ݒ菈��
        /// </summary>
        private void SearchParaSet(ExtrInfo_DCHNB02013E saleConfListCndtn, ref OrderConfShWork orderConfShWork)
        {
            orderConfShWork.EnterpriseCode = saleConfListCndtn.EnterpriseCode;				// ��ƃR�[�h

            // ���_
            if (saleConfListCndtn.ResultsAddUpSecList.Length != 0)
            {
                if (saleConfListCndtn.ResultsAddUpSecList[0] == "0")
                {
                    // �S�Ђ̎�
                    orderConfShWork.ResultsAddUpSecList = new string[0];						// ���_�R�[�h
                    // 2008.07.25 30413 ���� �s�v�v���p�e�B�̍폜 >>>>>>START
                    //orderConfShWork.IsOutputAllSecRec = true;
                    //orderConfShWork.IsSelectAllSection = true;
                    // 2008.07.25 30413 ���� �s�v�v���p�e�B�̍폜 <<<<<<END
                }
                else
                {
                    orderConfShWork.ResultsAddUpSecList = saleConfListCndtn.ResultsAddUpSecList;// ���_�R�[�h
                    // 2008.07.25 30413 ���� �s�v�v���p�e�B�̍폜 >>>>>>START
                    //orderConfShWork.IsSelectAllSection = false;
                    //// �S���_�Ƀ`�F�b�N�������Ă��邩�ǂ����̃`�F�b�N
                    //if (_secInfoAcs.SecInfoSetList.Length == saleConfListCndtn.ResultsAddUpSecList.Length)
                    //{
                    //    orderConfShWork.IsOutputAllSecRec = true;
                    //}
                    //else
                    //{
                    //    orderConfShWork.IsOutputAllSecRec = false;
                    //}
                    // 2008.07.25 30413 ���� �s�v�v���p�e�B�̍폜 <<<<<<END
                }
            }
            else
            {
                orderConfShWork.ResultsAddUpSecList = new string[0];    // ���_�R�[�h
                // 2008.07.25 30413 ���� �s�v�v���p�e�B�̍폜 >>>>>>START
                //orderConfShWork.IsOutputAllSecRec = true;               // �S���_�W�v���R�[�h�ł̏o��
                //orderConfShWork.IsSelectAllSection = false;
                // 2008.07.25 30413 ���� �s�v�v���p�e�B�̍폜 <<<<<<END
            }

            //�����[�g�փf�[�^��n��
            orderConfShWork.AcptAnOdrStatus = saleConfListCndtn.AcptAnOdrStatus;			//�󒍏o�ה���

            orderConfShWork.SearchSlipDateSt = saleConfListCndtn.SearchSlipDateSt;			// �J�n���͓��i�`�[�������t�j
            orderConfShWork.SearchSlipDateEd = saleConfListCndtn.SearchSlipDateEd;			// �I�����͓��i�`�[�������t�j

            orderConfShWork.SalesDateSt = saleConfListCndtn.SalesDateSt;                    // �J�n�����
            orderConfShWork.SalesDateEd = saleConfListCndtn.SalesDateEd;                    // �I�������
            orderConfShWork.ShipmentDaySt = saleConfListCndtn.ShipmentDaySt;                // �J�n�o�ד�
            orderConfShWork.ShipmentDayEd = saleConfListCndtn.ShipmentDayEd;                // �I���o�ד�

            orderConfShWork.CustomerCodeSt = saleConfListCndtn.CustomerCodeSt;              // �J�n���Ӑ�R�[�h
            orderConfShWork.CustomerCodeEd = saleConfListCndtn.CustomerCodeEd;              // �I�����Ӑ�R�[�h
            orderConfShWork.SalesEmployeeCdSt = saleConfListCndtn.SalesEmployeeCdSt;        // �J�n�S���R�[�h
            orderConfShWork.SalesEmployeeCdEd = saleConfListCndtn.SalesEmployeeCdEd;        // �I���S���R�[�h

            orderConfShWork.GrsProfitCheckLower = saleConfListCndtn.GrsProfitCheckLower;	// �e����(����)
            orderConfShWork.GrsProfitCheckBest = saleConfListCndtn.GrsProfitCheckBest;		// �e����(�K��)
            orderConfShWork.GrsProfitCheckUpper = saleConfListCndtn.GrsProfitCheckUpper;	// �e����(���)

            orderConfShWork.GrossMargin1Mark = saleConfListCndtn.GrossMargin1Mark;			//�e���`�F�b�N�}�[�N1
            orderConfShWork.GrossMargin2Mark = saleConfListCndtn.GrossMargin2Mark;			//�e���`�F�b�N�}�[�N2
            orderConfShWork.GrossMargin3Mark = saleConfListCndtn.GrossMargin3Mark;			//�e���`�F�b�N�}�[�N3
            orderConfShWork.GrossMargin4Mark = saleConfListCndtn.GrossMargin4Mark;			//�e���`�F�b�N�}�[�N4

            orderConfShWork.SalesSlipCd = -1;					// ����`�[�敪[�`�[]�i���o�����j
            // 2008.07.25 30413 ���� ���œ����������s���Ă���̂ō폜 >>>>>>START
            //orderConfShWork.SalesSlipCd = -1;              // ����`�[�敪[����]�i���o�����j
            // 2008.07.25 30413 ���� ���œ����������s���Ă���̂ō폜 <<<<<<END

            // 2008.07.25 30413 ���� ���s�^�C�v�̒ǉ� >>>>>>START
            orderConfShWork.PrintDiv = saleConfListCndtn.PublicationType;                   // ���s�^�C�v
            // 2008.07.25 30413 ���� ���s�^�C�v�̒ǉ� <<<<<<END

            //orderConfShWork.DebitNoteDiv = saleConfListCndtn.DebitNoteDiv;                  // �ԓ`�敪�i���o�����j

        }

        /// <summary>
        /// �f�[�^�X�L�[�}�\������
        /// </summary>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            // ���o��{�f�[�^�Z�b�g�X�L�[�}�ݒ�
            Broadleaf.Application.UIData.DCHNB02014EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// Search�ďo����
        /// </summary>
        /// <object name="retObj">�擾�f�[�^�I�u�W�F�N�g</object>
        /// <object name="salesConfShWork">�����[�g���������N���X</object>
        /// <returns>�X�e�[�^�X</returns>

        private int SearchByMode(out object retObj, OrderConfShWork orderConfShWork, int printDiv)
        {
            int status = 0;

            retObj = null;

            IOrderConfDB _iOrderConfDB = (IOrderConfDB)MediationOrderConfDB.GetOrderConfDB();	//G:A��O�𒇉�

            switch (printDiv)
            {
                case 1:		//�`�[�`��
                case 3:
                    status = _iOrderConfDB.SearchSlip(out retObj, orderConfShWork);
                    break;

                case 2:		//���׌`��
                case 4:
                    status = _iOrderConfDB.SearchDetail(out retObj, orderConfShWork);
                    break;
            }

            return status;
        }
        ///// <param name="retObj">�擾�f�[�^�I�u�W�F�N�g</param>
        ///// <param name="salesConfShWork">�����[�g���������N���X</param>
        /// <summary>
        /// �󎚏��N�G���쐬����
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        ///  DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B
        /// </remarks>
        private string GetPrintOderQuerry(ExtrInfo_DCHNB02013E saleConfListCndtn)
        {
            string orderQuerry = "";

            // �\�[�g���ݒ�
            switch (saleConfListCndtn.SortOrder)
            {
                case 0:
                    {
                        if (saleConfListCndtn.AcptAnOdrStatus == 20)
                        {
                            orderQuerry = CT_Sort1_Odr01;
                        }
                        else
                        {
                            orderQuerry = CT_Sort1_Odr02;
                        }
                        break;
                    }
                case 1:
                    {

                        orderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 2:
                    {

                        orderQuerry = CT_Sort3_Odr;
                        break;
                    }
                case 3:
                    {

                        orderQuerry = CT_Sort4_Odr;
                        break;
                    }

            }

            // �����Œ�
            orderQuerry += CT_UpperOrder;

            return orderQuerry;
        }



        /// <summary>
        /// �f�[�^�e�[�u���ݒ�
        /// </summary>
        private void SettingDataTable()
        {
            this._SalesConfDataTable = Broadleaf.Application.UIData.DCHNB02014EA.CT_OrderConfDataTable;
        }

        /// <summary>
        /// �f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="retList">�f�[�^�擾�����X�g</param>
        /// <param name="setCnt">���X�g�̃f�[�^�擾Index</param>
        private void SetTebleRowFromRetList(ref DataRow dr, ArrayList retList, int setCnt)
        {
            OrderConfWork orderConfWork = (OrderConfWork)retList[setCnt];

            //[����]
            dr[DCHNB02014EA.CT_OrderConf_SectionCode] = orderConfWork.SectionCode;					// ���_�R�[�h					(string)
            dr[DCHNB02014EA.CT_OrderConf_SectionGuideNm] = orderConfWork.SectionGuideNm;			// ���_�K�C�h���́i���_���́j	(string)
            //dr[DCHNB02014EA.CT_OrderConf_SalesDateRF] = orderConfWork.SalesDate;					// ����i�󒍁j���t			�@	(Int32)
            //dr[DCHNB02014EA.CT_OrderConf_ShipmentDayRF] = orderConfWork.ShipmentDay;				// �o�ד��t						(DateTime)
            // 2008.09.24 30413 ���� �󒍓��Ƒݏo���̐ݒ�ύX >>>>>>START
            //dr[DCHNB02014EA.CT_OrderConf_SalesDateRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.SalesDate);   // ����i�󒍁j���t			�@	(Int32)
            //dr[DCHNB02014EA.CT_OrderConf_ShipmentDayRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.ShipmentDay); // �o�ד��t						(DateTime)
            if (orderConfWork.SalesDate != DateTime.MinValue)
            {
                // �󒍓����ݒ肳��Ă���
                dr[DCHNB02014EA.CT_OrderConf_SalesDateRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.SalesDate);   // ����i�󒍁j���t			�@	(DateTime)
            }
            if (orderConfWork.ShipmentDay != DateTime.MinValue)
            {
                // �ݏo�����ݒ肳��Ă���
                dr[DCHNB02014EA.CT_OrderConf_ShipmentDayRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.ShipmentDay); // �ݏo���t						(DateTime)
            }
            dr[DCHNB02014EA.CT_OrderConf_CustomerCodeRF] = orderConfWork.CustomerCode;				// ���Ӑ�R�[�h					(Int32)
            dr[DCHNB02014EA.CT_OrderConf_CustomerSnmRF] = orderConfWork.CustomerSnm;				// ���Ӑ旪�� 				�@	(string)
            //dr[DCHNB02014EA.CT_OrderConf_SearchSlipDateRF] = orderConfWork.SearchSlipDate;			// �i�`�[�������t�j���͓��t[����](DateTime)
            dr[DCHNB02014EA.CT_OrderConf_SearchSlipDateRF] = TDateTime.DateTimeToString(ExtrInfo_DCHNB02013E.ct_DateFomat, orderConfWork.SearchSlipDate);   // �i�`�[�������t�j���͓��t[����](DateTime)
            dr[DCHNB02014EA.CT_OrderConf_PartySaleSlipNumRF] = orderConfWork.PartySaleSlipNum;      // �����`�[�ԍ��i���Ӑ撍���ԍ��j[����](string)
            dr[DCHNB02014EA.CT_OrderConf_SalesEmployeeNmRF] = orderConfWork.SalesEmployeeNm;		// �̔��]�ƈ��i�S���ҁj����[����](string)
            dr[DCHNB02014EA.CT_OrderConf_SalesEmployeeCdRF] = orderConfWork.SalesEmployeeCd;
            dr[DCHNB02014EA.CT_OrderConf_SalesInputNameRF] = orderConfWork.SalesInputName;			// ������͎Җ���[����]		(string)
            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� >>>>>>START
            dr[DCHNB02014EA.CT_OrderConf_FrontEmployeeCd] = orderConfWork.FrontEmployeeCd;          // ��t�]�ƈ��R�[�h[����](string)
            dr[DCHNB02014EA.CT_OrderConf_FrontEmployeeNm] = orderConfWork.FrontEmployeeNm;          // ��t�]�ƈ�����[����](string)
            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� <<<<<<END
            // --- ADD 2009/01/30 -------------------------------->>>>>
            dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] = orderConfWork.AcptAnOdrRemainCnt; // �󒍎c��
            dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCnt] = orderConfWork.AcceptAnOrderCnt; // �󒍐���
            dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrAdjustCnt] = orderConfWork.AcptAnOdrAdjustCnt; // �󒍒�����
            dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt] = orderConfWork.AcceptAnOrderCnt + orderConfWork.AcptAnOdrAdjustCnt; // �󒍐�
            // --- ADD 2009/01/30 --------------------------------<<<<<

            //[�`�[]
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF] = orderConfWork.SalesSlipNum;				// ����`�[�ԍ�					(string)
            //dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] = orderConfWork.GrossMarginRate;			// �e����[�`�[]					(Double)//del 2011/12/02 ���� Redmine #8316
            //dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = orderConfWork.GrossMarginMarkSlip;	// �e���`�F�b�N�}�[�N[�`�[]		(string)//del 2011/12/02 ���� Redmine #8316
            dr[DCHNB02014EA.CT_OrderConf_TransactionNameRF] = orderConfWork.TransactionName;		// ����敪��[�`�[]			�@	(string)
            //dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF] = orderConfWork.SalesTotalTaxExc;		// ����i�󒍁j�`�[���v(�Ŕ�)[�`�[](Int64) // DEL caohh 2011/08/11
            // ------ ADD caohh 2011/08/11 ------>>>>>
            // ����
            double cnt = 0;
            // ���z = ����*����P��
            double salesTotalTaxExc = 0;
            // �󒍁A�ݏo
            if (this._publicationType == 0 || this._publicationType == 2)
            {
                //��/�ݏo�c��
                cnt = orderConfWork.AcptAnOdrRemainCnt;
            }
            // �󒍌v��ρA�ݏo�v���
            else
            {
                //��/�ݏo���|�c��
                cnt = orderConfWork.AcceptAnOrderCnt + orderConfWork.AcptAnOdrAdjustCnt - orderConfWork.AcptAnOdrRemainCnt;
            }
            salesTotalTaxExc = cnt * orderConfWork.SalesUnPrcTaxExcFl;
            dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF] = salesTotalTaxExc;		//����i�󒍁j�`�[���v(�Ŕ�)[�`�[](Int64)
            // ------ ADD caohh 2011/08/11 ------<<<<<
            dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxIncRF] = orderConfWork.SalesTotalTaxInc;		// ����i�󒍁j�`�[���v(�ō�)[�`�[](Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF] = orderConfWork.SalesDisTtlTaxExc;	// ����i�󒍁j�l�����z�v(�Ŕ�)[�`�[]
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxIncluRF] = orderConfWork.SalesDisTtlTaxInclu;// ����i�󒍁j�l�����z�v(�ō�)[�`�[]
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF] = orderConfWork.SalesSlipCd;				// ����`�[�敪[�`�[]
            dr[DCHNB02014EA.CT_OrderConf_AccRecDivCd] = orderConfWork.AccRecDivCd;					// ���|�`�[�敪[�`�[]
            //����Łi�ō��ݔ���l�����z-�Ŕ�������l�����z�j[�`�[]
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlip] = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc;
            //����Łi�l�����j�i�ō��ݔ���l�����z-�Ŕ�������l�����z�j[�`�[]
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxDisSlip] = orderConfWork.SalesDisTtlTaxInclu - orderConfWork.SalesDisTtlTaxExc;
            //�������z�v[�`�[]�@�i������j
            //dr[DCHNB02014EA.CT_OrderConf_TotalCostRF] = orderConfWork.TotalCost; //del 2011/12/02 ���� Redmine #8316
            //add 2011/12/02 ���� Redmine #8316----->>>>>
            //�������������ݏo�c��(�ݏo���v��)
            if ((this._printDiv == 1 && this._publicationType == 0) || (this._publicationType == 2 && this._printDiv == 3))
            {
                dr[DCHNB02014EA.CT_OrderConf_TotalCostRF] = orderConfWork.SalesUnitCost * orderConfWork.AcptAnOdrRemainCnt;
            }
            //�������������i���ʁ]�ݏo�c���j(�ݏo�v��)
            else if ((this._printDiv == 1 && this._publicationType == 1) || (this._publicationType == 3 && this._printDiv == 3))
            {
                dr[DCHNB02014EA.CT_OrderConf_TotalCostRF] = orderConfWork.SalesUnitCost * (orderConfWork.AcceptAnOrderCnt + orderConfWork.AcptAnOdrAdjustCnt - orderConfWork.AcptAnOdrRemainCnt);
            }
            //add 2011/12/02 ���� Redmine #8316-----<<<<<
            // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
            // �`�[�^�C�v
            long salesTax = 0;          // ����^�ԕi�̏����
            long salesTotalAll = 0;     // ����^�ԕi�̍��v���z
            long distTax = 0;           // �l���̏����
            long distTotalAll = 0;      // �l���̍��v���z
            // ���׃^�C�v
            long salesDtlTax = 0;       // ����^�ԕi�̏����
            long distDtlTax = 0;        // �l���̏����
            // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END

            // 2009.01.27 30413 ���� ����ł̌v�Z�ʒu��ύX >>>>>>START
            // ����ł̐ݒ�
            if ((this._printDiv == 1) || (this._printDiv == 3))
            {
                // �`�[�P�ʂɏo�͎�

                // ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
                if ((orderConfWork.ConsTaxLayMethod == 2) ||
                    (orderConfWork.ConsTaxLayMethod == 3) ||
                    (orderConfWork.ConsTaxLayMethod == 9))
                {
                    // �����
                    dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalAmntConsTaxInclu + orderConfWork.SalesDisTtlTaxInclu);
                    // ���v���z
                    //add 2011/12/02 ���� Redmine #8316----->>>>>
                    //���v���z�F����ł̋��z������
                    dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc;
                    //add 2011/12/02 ���� Redmine #8316-----<<<<<
                    //del 2011/12/02 ���� Redmine #8316----->>>>>
                    //dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc
                    //                                                             + (orderConfWork.SalAmntConsTaxInclu + orderConfWork.SalesDisTtlTaxInclu);
                    //del 2011/12/02 ���� Redmine #8316-----<<<<<
                    // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
                    // �`�[�^�C�v�̏���łƍ��v���z���Z�o
                    salesTax = orderConfWork.SalAmntConsTaxInclu;
                    salesTotalAll = orderConfWork.SalesTotalTaxExc + orderConfWork.SalAmntConsTaxInclu - orderConfWork.SalesDisTtlTaxExc - salesTax;//add 2011/12/02 ���� Redmine #8316
                    //salesTotalAll = orderConfWork.SalesTotalTaxExc + orderConfWork.SalAmntConsTaxInclu - orderConfWork.SalesDisTtlTaxExc;//del 2011/12/02 ���� Redmine #8316
                    distTax = orderConfWork.SalesDisTtlTaxInclu;
                    distTotalAll = orderConfWork.SalesDisTtlTaxExc + orderConfWork.SalesDisTtlTaxInclu;
                    // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END
                }
                // ����œ]�ŕ����@0�F�`�[�P�ʁA1�F���גP��
                else
                {
                    // �����
                    dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);
                    // ���v���z
                    //add 2011/12/02 ���� Redmine #8316----->>>>>
                    //���v���z�F����ł̋��z������
                    dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc;
                    //add 2011/12/02 ���� Redmine #8316-----<<<<<
                    //del 2011/12/02 ���� Redmine #8316----->>>>>
                    //dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc
                    //                                                        + (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);
                    //del 2011/12/02 ���� Redmine #8316-----<<<<<
                    // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
                    // �`�[�^�C�v�̏���łƍ��v���z���Z�o
                    salesTax = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisOutTax;
                    //add 2011/12/02 ���� Redmine #8316----->>>>>
                    salesTotalAll = orderConfWork.SalesTotalTaxExc + orderConfWork.SalesTotalTaxInc -
                                    orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc -
                                    orderConfWork.SalesDisOutTax - salesTax;
                    //add 2011/12/02 ���� Redmine #8316-----<<<<<
                    //salesTotalAll = orderConfWork.SalesTotalTaxExc + orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc - orderConfWork.SalesDisOutTax;//del 2011/12/02 ���� Redmine #8316
                    distTax = orderConfWork.SalesDisOutTax;
                    distTotalAll = orderConfWork.SalesDisTtlTaxExc + orderConfWork.SalesDisOutTax;
                    // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END
                }
            }
            else
            {
                // ���גP�ʂɏo�͎�

                // ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
                if ((orderConfWork.ConsTaxLayMethod == 2) ||
                    (orderConfWork.ConsTaxLayMethod == 3) ||
                    (orderConfWork.ConsTaxLayMethod == 9))
                {
                    // �ېŋ敪�@2�F����
                    if (orderConfWork.TaxationDivCd == 2)
                    {
                        // �����
                        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
                    }
                    // �ېŋ敪�@0�F�ېŁA1�F��ې�
                    else
                    {
                        // �����
                        dr[DCHNB02014EA.CT_OrderConf_Tax] = DBNull.Value;
                    }
                }
                // ����œ]�ŕ����@0�F�`�[�P�ʁA1�F���גP��
                else
                {
                    // 2009.01.27 30413 ���� ���׃^�C�v�̒��[�œ`�[�]�ł̏ꍇ�A����s�ԍ���1�s�ڂ݂̂ɏ���ł�ݒ� >>>>>>START                        
                    // �����
                    //dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
                    if (orderConfWork.ConsTaxLayMethod == 0)
                    {
                        // ����œ]�ŕ����@0�F�`�[�P��
                        if (orderConfWork.SalesRowNo == 1)
                        {
                            // ����s�ԍ���1�s��
                            // �����
                            dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);

                            // 2009.01.27 30413 ���� ���v���̏���ł�ǉ� >>>>>>START
                            // ���׃^�C�v�̏���ł��Z�o
                            salesDtlTax = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisOutTax;
                            distDtlTax = orderConfWork.SalesDisOutTax;
                            // 2009.01.27 30413 ���� ���v���̏���ł�ǉ� <<<<<<END
                        }
                        else
                        {
                            // ��L�ȊO
                            // �����
                            dr[DCHNB02014EA.CT_OrderConf_Tax] = 0;
                        }
                    }
                    else
                    {
                        // ����œ]�ŕ����@1�F���גP��
                        // �����
                        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
                    }
                    // 2009.01.27 30413 ���� ���׃^�C�v�̒��[�œ`�[�]�ł̏ꍇ�A����s�ԍ���1�s�ڂ݂̂ɏ���ł�ݒ� <<<<<<END                        
                }
            }
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxLayMethod] = orderConfWork.ConsTaxLayMethod;        // ����œ]�ŕ���
            dr[DCHNB02014EA.CT_OrderConf_TaxationDivCd] = orderConfWork.TaxationDivCd;              // �ېŋ敪
            // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END

            // �i���v�j�F�w����x/�w�ԕi�x���f�B
            //�J�E���g�A����z�E�ԕi�z�A�������z�A����ł̌v�Z�B���[�̃v���p�e�B�ō��v������B
            switch (orderConfWork.SalesSlipCd)
            {
                case 0:	//����
                    {
                        //������z�i����`�[���v[�Ŕ���]-����l�������z�v[�Ŕ���]�j[�`�[]
                        //dr[DCHNB02014EA.CT_OrderConf_SalesMoney] = orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc; // DEL caohh 2011/08/11
                        dr[DCHNB02014EA.CT_OrderConf_SalesMoney] = salesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc; // ADD caohh 2011/08/11
                        //�w����x��[�`�[]�J�E���g
                        dr[DCHNB02014EA.CT_OrderConf_CntSales] = 1;

                        //�w����x��[����]�J�E���g
                        //�i���ׁj�̒��ł��Ɩ��׍s1�s�Â��J�E���g���Ă��܂��B[�`�[]�̐��𐔂������̂ł�����ŏ����B
                        if (orderConfWork.SalesRowNo == 1)	//���׍sNo��1�̎������J�E���g��2�s��3�s�ڂ͐����Ȃ�
                        {
                            dr[DCHNB02014EA.CT_OrderConf_CntSalesDtl] = 1;
                        }

                        // �������z�v�i����j[�`�[]			
                        //dr[DCHNB02014EA.CT_OrderConf_TotalCostSl] = orderConfWork.TotalCost;//del 2011/12/02 ���� Redmine #8316

                        //����Łi����`�[���v(�ō�)-����l�����z�v(�ō�)-����`�[���v(�ō�)+�j[�`�[]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlSlip]
                                                                    = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesDisTtlTaxInclu
                                                                                                - orderConfWork.SalesTotalTaxExc + orderConfWork.SalesDisTtlTaxExc;

                        // 2009.01.23 30413 ���� �l���̑e���v�Z��ύX >>>>>>START
                        // 2008.07.28 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
                        // ���㍇�v�e��
                        //dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfit] = orderConfWork.SalesTotalTaxExc - orderConfWork.TotalCost;
                        dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfit] = orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc - orderConfWork.TotalCost;
                        // 2008.07.28 30413 ���� [�`�[]�̍��ڒǉ� <<<<<<END
                        // 2009.01.23 30413 ���� �l���̑e���v�Z��ύX <<<<<<END

                        // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
                        // ���㍇�v�����(�`�[)
                        dr[DCHNB02014EA.CT_OrderConf_SalesTax] = salesTax;

                        // ����̏���ō����v���z(�`�[)
                        dr[DCHNB02014EA.CT_OrderConf_SalesTotalAll] = salesTotalAll;
                        // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END

                        break;
                    }

                case 1:	//�ԕi
                    {
                        //�ԕi���z�i����`�[���v[�Ŕ���]-����l�������z�v[�Ŕ���]�j[�`�[]
                        dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney] = orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc;

                        //�w�ԕi�x��[�`�[]�J�E���g
                        //dr[DCHNB02014EA.CT_OrderConf_CntReturn] = 1;//del 2011/12/18 ���� Redmine #8316
                        dr[DCHNB02014EA.CT_OrderConf_CntSales] = 1;//add 2011/12/18 ���� Redmine #8316

                        //�w�ԕi�x��[����]�J�E���g
                        if (orderConfWork.SalesRowNo == 1)
                        {
                            //dr[DCHNB02014EA.CT_OrderConf_CntReturnDtl] = 1;//del 2011/12/18 ���� Redmine #8316
                            dr[DCHNB02014EA.CT_OrderConf_CntSalesDtl] = 1;//add 2011/12/18 ���� Redmine #8316
                        }

                        // �������z�v�i�ԕi�j[�`�[]				
                        dr[DCHNB02014EA.CT_OrderConf_TotalCostRtn] = orderConfWork.TotalCost;

                        //����Łi�ԕi�j�i�w�ԕi���z�x*0.05�j[�`�[]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnSlip]
                                                                    = orderConfWork.SalesTotalTaxInc - orderConfWork.SalesDisTtlTaxInclu
                                                                                                - orderConfWork.SalesTotalTaxExc + orderConfWork.SalesDisTtlTaxExc;
                        // 2009.01.23 30413 ���� �l���̑e���v�Z��ύX >>>>>>START
                        // 2008.07.28 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
                        // �ԕi���v�e��
                        //dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfit] = orderConfWork.SalesTotalTaxExc - orderConfWork.TotalCost;
                        dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfit] = orderConfWork.SalesTotalTaxExc - orderConfWork.SalesDisTtlTaxExc - orderConfWork.TotalCost;
                        // 2008.07.28 30413 ���� [�`�[]�̍��ڒǉ� <<<<<<END
                        // 2009.01.23 30413 ���� �l���̑e���v�Z��ύX <<<<<<END

                        // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
                        // �ԕi���v�����(�`�[)
                        dr[DCHNB02014EA.CT_OrderConf_ReturnTax] = salesTax;

                        // ����̏���ō����v���z(�`�[)
                        //dr[DCHNB02014EA.CT_OrderConf_ReturnTotalAll] = salesTotalAll;//del 2011/12/18 ���� Redmine #8316
                        //dr[DCHNB02014EA.CT_OrderConf_ReturnTotalAll] = salesTotalAll - salesTax;//add 2011/12/18 ���� Redmine #8316 //del 2011/12/19 ���� Redmine #8316
                        dr[DCHNB02014EA.CT_OrderConf_ReturnTotalAll] = salesTotalAll;//add 2011/12/19 ���� Redmine #8316
                        // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END

                        break;
                    }
            }

            // 2009.01.23 30413 ���� �l���̑e���v�Z��ύX >>>>>>START
            //// 2008.07.28 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
            //// �l�����̐ݒ�

            //// �l�������v�������z(�`�[)
            //dr[DCHNB02014EA.CT_OrderConf_DistCost] = (orderConfWork.TotalCost);
            dr[DCHNB02014EA.CT_OrderConf_DistCost] = orderConfWork.DisCost;

            //// �l�������v�e��(�`�[)
            //dr[DCHNB02014EA.CT_OrderConf_DistGrossProfit] = (orderConfWork.SalesDisTtlTaxExc - orderConfWork.Cost);
            dr[DCHNB02014EA.CT_OrderConf_DistGrossProfit] = orderConfWork.SalesDisTtlTaxExc - orderConfWork.DisCost;
            //// 2008.07.28 30413 ���� [�`�[]�̍��ڒǉ� <<<<<<END
            // 2009.01.23 30413 ���� �l���̑e���v�Z��ύX <<<<<<END

            // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� >>>>>>START
            // �l�������v�����(�`�[)
            dr[DCHNB02014EA.CT_OrderConf_DistTax] = distTax;

            // �l�����̏���ō����v���z(�`�[)
            dr[DCHNB02014EA.CT_OrderConf_DistTotalAll] = distTotalAll;
            // 2009.01.27 30413 ���� ���v���̏���łƍ��v���z��ǉ� <<<<<<END

            // 2008.07.25 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
            dr[DCHNB02014EA.CT_OrderConf_SlipNote] = orderConfWork.SlipNote; // �`�[���l[�`�[](string)
            // 2008.07.25 30413 ���� [�`�[]�̍��ڒǉ� <<<<<<END


            //[����]
            dr[DCHNB02014EA.CT_OrderConf_GoodsNoRF] = orderConfWork.GoodsNo;						// ���i�R�[�h					(string)
            dr[DCHNB02014EA.CT_OrderConf_GoodsNameRF] = orderConfWork.GoodsName;					// ���i����						(string)
            dr[DCHNB02014EA.CT_OrderConf_MakerNameRF] = orderConfWork.MakerName;					// ���[�J�[��					(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesRowNoRF] = orderConfWork.SalesRowNo;					// ����s�ԍ�[����]				(Int32)
            dr[DCHNB02014EA.CT_OrderConf_ShipmentCntRF] = orderConfWork.ShipmentCnt;				// �o�א��i���ʁj[����]			(double)
            dr[DCHNB02014EA.CT_OrderConf_SalesUnPrcTaxExcFlRF] = orderConfWork.SalesUnPrcTaxExcFl;	// ����P���i�Ŕ����j[����]		(Int64)
            //dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxIncRF] = orderConfWork.SalesMoneyTaxInc;	// ������z�i�ō��݁j[����]		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF] = orderConfWork.SalesMoneyTaxExc;		// ������z�i�Ŕ����j[����]		(Int64)
            //dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl] = orderConfWork.GrossMarginRateDtl;	// �e����[����]					(Double)//del 2011/12/02 ���� Redmine #8316
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = orderConfWork.GrossMarginMarkDtl;	// �e���`�F�b�N�}�[�N[����]		(string)
            //dr[DCHNB02014EA.CT_OrderConf_PartySlipNumDtlRF] = orderConfWork.PartySlipNumDtl;		// �����`�[�ԍ��i���Ӑ撍���ԍ��j[����](string)
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdDtlRF] = orderConfWork.SalesSlipCdDtl;			//����`�[�敪[����]
            //dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF] = orderConfWork.SalesMoneyTaxExc;		//������z�i�Ŕ����j[����] // DEL caohh 2011/08/11
            // ------ ADD caohh 2011/08/11 ------>>>>>
            // ���z = ����*����P��
            dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF] = cnt * orderConfWork.SalesUnPrcTaxExcFl;		//������z�i�Ŕ����j[����]
            // ------ ADD caohh 2011/08/11 ------<<<<<
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl] = orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc;//�����
            dr[DCHNB02014EA.CT_OrderConf_SalesUnitCostRF] = orderConfWork.SalesUnitCost;			//�����P��           
            //add 2011/12/02 ���� Redmine #8316----->>>>>>
            //���v�� �������������ݏo�c��
            //�v�� �������������i���ʁ]�ݏo�c���j
            if (this._printDiv == 4 || this._printDiv == 2)
            {
                dr[DCHNB02014EA.CT_OrderConf_CostRF] = cnt * orderConfWork.SalesUnitCost;							//�������z
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_CostRF] = orderConfWork.Cost;								//�������z
            }
            //add 2011/12/02 ���� Redmine #8316-----<<<<<<
            //dr[DCHNB02014EA.CT_OrderConf_CostRF] = orderConfWork.Cost;								//�������z//del 2011/12/02 ���� Redmine #8316
            // 2008.07.25 30413 ���� �s�v�J�����̍폜 >>>>>>START
            //dr[DCHNB02014EA.CT_OrderConf_UnitNameRF] = orderConfWork.UnitName;						//�P�ʖ���
            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� <<<<<<END
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipNmDtl] = this.GetSalesSlipNmDtl(orderConfWork.SalesSlipCdDtl);//����`�[�敪��

            // 2008.11.27 30413 ���� ������ڂ̒ǉ� >>>>>>START
            dr[DCHNB02014EA.CT_OrderConf_ListPriceTaxExcFl] = orderConfWork.ListPriceTaxExcFl;
            // 2008.11.27 30413 ���� ������ڂ̒ǉ� <<<<<<END

            // �i���ׁj�F�w����x/�w�ԕi�x���f�B
            //�J�E���g�A����z�E�ԕi�z�A�������z�A����ł̌v�Z�B���[�̃v���p�e�B�ō��v������B
            switch (orderConfWork.SalesSlipCdDtl)
            {
                case 0:	//����
                    {
                        //�w����x������z�i�Ŕ����j[����]
                        //dr[DCHNB02014EA.CT_OrderConf_SalesMoneyDtl] = orderConfWork.SalesMoneyTaxExc;// DEL caohh 2011/08/11
                        dr[DCHNB02014EA.CT_OrderConf_SalesMoneyDtl] = cnt * orderConfWork.SalesUnPrcTaxExcFl; // ADD 2011/08/11

                        // �������z�v�i����j[����]			
                        //dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = orderConfWork.Cost;//del 2011/12/02 ���� Redmine #8316

                        //add 2011/12/02 ���� Redmine #8316----->>>>>>
                        //���v�� �������������ݏo�c��
                        //�v�� �������������i���ʁ]�ݏo�c���j
                        if (this._printDiv == 4 || this._printDiv == 2)
                        {
                            // �������z�v�i����j[����]			
                            dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = Convert.ToInt32(dr[DCHNB02014EA.CT_OrderConf_CostRF]);
                        }
                        else
                        {
                            // �������z�v�i����j[����]			
                            dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = orderConfWork.Cost;
                        }
                        //add 2011/12/02 ���� Redmine #8316-----<<<<<<

                        //����Łi�j[����]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlDtl] = dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl];

                        // 2008.07.28 30413 ���� [����]�̍��ڒǉ� >>>>>>START
                        // ���㍇�v�e��(����)
                        //dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);//del 2011/12/02 ���� Redmine #8316
                        //add 2011/12/02 ���� Redmine #8316----->>>>>>
                        ////�e���F���z�@�]�@����
                        if (this._printDiv == 4 || this._printDiv == 2)
                        {
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfitDtl] = (cnt * orderConfWork.SalesUnPrcTaxExcFl - cnt * orderConfWork.SalesUnitCost);
                        }
                        else
                        {
                            dr[DCHNB02014EA.CT_OrderConf_SalesGrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);
                        }
                        //add 2011/12/02 ���� Redmine #8316-----<<<<<<
                        // 2008.07.28 30413 ���� [����]�̍��ڒǉ� <<<<<<END

                        // 2009.01.27 30413 ���� ���v���̏���ł�ǉ� >>>>>>START
                        // ���㍇�v�����(����)
                        if ((orderConfWork.ConsTaxLayMethod == 0) && (orderConfWork.SalesRowNo == 1))
                        {
                            // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                            dr[DCHNB02014EA.CT_OrderConf_SalesDtlTax] = salesDtlTax;
                            // �l�������v�����(����)
                            dr[DCHNB02014EA.CT_OrderConf_DistDtlTax] = distDtlTax;
                        }
                        else
                        {
                            // ��L�ȊO
                            dr[DCHNB02014EA.CT_OrderConf_SalesDtlTax] = dr[DCHNB02014EA.CT_OrderConf_Tax];
                        }
                        // 2009.01.27 30413 ���� ���v���̏���ł�ǉ� <<<<<<END

                        break;
                    }

                case 1:	//�ԕi
                    {
                        //�ԕi���z�i����`�[���v[�Ŕ���]-����l�������z�v[�Ŕ���]�j[�`�[]
                        dr[DCHNB02014EA.CT_OrderConf_SalesMoneyRtnDtl] = orderConfWork.SalesMoneyTaxExc;

                        // �������z�v�i�ԕi�j[����]				
                        //dr[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl] = orderConfWork.TotalCost;//del 2011/12/18 ���� Redmine #8316
                        dr[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl] = orderConfWork.Cost;//add 2011/12/18 ���� Redmine #8316
                        //����Łi�ԕi�j[����]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnDtl] = dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl];

                        // 2008.07.28 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
                        // �ԕi���v�e��(����)
                        dr[DCHNB02014EA.CT_OrderConf_ReturnGrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);
                        // 2008.07.28 30413 ���� [����]�̍��ڒǉ� <<<<<<END

                        // 2009.01.27 30413 ���� ���v���̏���ł�ǉ� >>>>>>START
                        // �ԕi���v�����(����)
                        if ((orderConfWork.ConsTaxLayMethod == 0) && (orderConfWork.SalesRowNo == 1))
                        {
                            // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                            dr[DCHNB02014EA.CT_OrderConf_ReturnDtlTax] = salesDtlTax;
                            // �l�������v�����(����)
                            dr[DCHNB02014EA.CT_OrderConf_DistDtlTax] = distDtlTax;
                        }
                        else
                        {
                            // ��L�ȊO
                            dr[DCHNB02014EA.CT_OrderConf_ReturnDtlTax] = dr[DCHNB02014EA.CT_OrderConf_Tax];
                        }
                        // 2009.01.27 30413 ���� ���v���̏���ł�ǉ� <<<<<<END

                        break;
                    }
                case 2:	//�l��
                    {
                        //�w�l���x���z[����]
                        dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcDtl] = orderConfWork.SalesDisTtlTaxExc;

                        //// �w�l���x�������z[����]				
                        //dr[DCHNB02014EA.CT_OrderConf_TotalDisCostRtnDtl] = orderConfWork.TotalCost;

                        //�w�l���x�����[����]
                        dr[DCHNB02014EA.CT_OrderConf_ConsTaxDisDtl] = dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl];

                        // 2008.07.28 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
                        // �l�������v�������z(�Ŕ���)(����)
                        dr[DCHNB02014EA.CT_OrderConf_DistDtlCost] = (orderConfWork.Cost);

                        // �l�������v�e��(����)
                        dr[DCHNB02014EA.CT_OrderConf_DistGrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);
                        // 2008.07.28 30413 ���� [����]�̍��ڒǉ� <<<<<<END

                        // 2009.01.27 30413 ���� ���v���̏���ł�ǉ� >>>>>>START
                        // �l�������v�����(����)
                        if ((orderConfWork.ConsTaxLayMethod == 0) && (orderConfWork.SalesRowNo == 1))
                        {
                            // ����œ]�ŕ�����"0:�`�["�����׍s��1�s��
                            dr[DCHNB02014EA.CT_OrderConf_DistDtlTax] = distDtlTax;
                            if (orderConfWork.SalesSlipCd == 0)
                            {
                                // ����`�[�敪��"0:����"
                                dr[DCHNB02014EA.CT_OrderConf_SalesDtlTax] = salesDtlTax;
                            }
                            else if (orderConfWork.SalesSlipCd == 1)
                            {
                                // ����`�[�敪��"1:�ԕi"
                                dr[DCHNB02014EA.CT_OrderConf_ReturnDtlTax] = salesDtlTax;
                            }
                        }
                        else
                        {
                            // ��L�ȊO
                            dr[DCHNB02014EA.CT_OrderConf_DistDtlTax] = dr[DCHNB02014EA.CT_OrderConf_Tax];
                        }
                        // 2009.01.27 30413 ���� ���v���̏���ł�ǉ� <<<<<<END

                        // 2009.01.23 30413 ���� �l���̑e���v�Z��ύX >>>>>>START
                        //// 2008.12.09 30413 ���� [�`�[]�̍��ڒǉ� >>>>>>START
                        //// �l�����̐ݒ�

                        //// �l�������v�������z(�`�[)
                        //dr[DCHNB02014EA.CT_OrderConf_DistCost] = (orderConfWork.TotalCost);

                        //// �l�������v�e��(�`�[)
                        //dr[DCHNB02014EA.CT_OrderConf_DistGrossProfit] = (orderConfWork.SalesDisTtlTaxExc - orderConfWork.Cost);
                        //// 2008.12.09 30413 ���� [�`�[]�̍��ڒǉ� <<<<<<END
                        // 2009.01.23 30413 ���� �l���̑e���v�Z��ύX <<<<<<END

                        break;
                    }
            }

            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� >>>>>>START
            //dr[DCHNB02014EA.CT_OrderConf_SupplierCd] = orderConfWork.SupplierCd;                        // �d����R�[�h[����](Int32)
            if (orderConfWork.SupplierCd == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_SupplierCd] = "";
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_SupplierCd] = orderConfWork.SupplierCd.ToString("d06");                       // �d����R�[�h[����](Int32)
            }
            dr[DCHNB02014EA.CT_OrderConf_SupplierSnm] = orderConfWork.SupplierSnm;                      // �d���旪��[����](string)
            //dr[DCHNB02014EA.CT_OrderConf_SupplierSlipNo] = orderConfWork.SupplierSlipNo;                // �d���`�[�ԍ�[����] (Int32)
            if (orderConfWork.SupplierSlipNo == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_SupplierSlipNo] = "";
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_SupplierSlipNo] = orderConfWork.SupplierSlipNo.ToString();               // �d���`�[�ԍ�[����] (Int32)
            }
            dr[DCHNB02014EA.CT_OrderConf_WarehouseCode] = orderConfWork.WarehouseCode;                  // �q�ɃR�[�h[����](string)
            dr[DCHNB02014EA.CT_OrderConf_WarehouseName] = orderConfWork.WarehouseName;                  // �q�ɖ���[����](string)
            dr[DCHNB02014EA.CT_OrderConf_BusinessTypeCode] = orderConfWork.BusinessTypeCode;            // �Ǝ�R�[�h[����](Int32)
            dr[DCHNB02014EA.CT_OrderConf_BusinessTypeName] = orderConfWork.BusinessTypeName;            // �Ǝ햼��[����](string)
            //dr[DCHNB02014EA.CT_OrderConf_SalesCode] = orderConfWork.SalesCode;                          // �̔��敪�R�[�h[����](Int32)
            if (orderConfWork.SalesCode == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_SalesCode] = "";
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_SalesCode] = orderConfWork.SalesCode.ToString("d04");                         // �̔��敪�R�[�h (Int32)
            }
            dr[DCHNB02014EA.CT_OrderConf_SalesCdNm] = orderConfWork.SalesCdNm;                          // �̔��敪����[����](string)
            dr[DCHNB02014EA.CT_OrderConf_ModelFullName] = orderConfWork.ModelFullName;                  // �Ԏ�S�p����[����](string)
            dr[DCHNB02014EA.CT_OrderConf_FullModel] = orderConfWork.FullModel;                          // �^���i�t���^�j[����](string)
            dr[DCHNB02014EA.CT_OrderConf_ModelDesignationNo] = orderConfWork.ModelDesignationNo;        // �^���w��ԍ�[����](string)
            dr[DCHNB02014EA.CT_OrderConf_CategoryNo] = orderConfWork.CategoryNo;                        // �ޕʔԍ�[����](Int32)
            // 2008.11.27 30413 ���� �ԗ��Ǘ��R�[�h�Ə��N�x�̈󎚐ݒ�𔄏�m�F�\�Ɠ��l�ɕύX >>>>>>START
            //if (orderConfWork.CarMngCode != "")
            //{
            //    // �ԗ��Ǘ��R�[�h���ݒ肳��Ă���
            //    dr[DCHNB02014EA.CT_OrderConf_CarMngCode] = orderConfWork.CarMngCode;                    // ���q�Ǘ��R�[�h[����](string)
            //    dr[DCHNB02014EA.CT_OrderConf_FirstEntryDate] = TDateTime.DateTimeToString("YYYY/MM", orderConfWork.FirstEntryDate);     // ���N�x[����](String)
            //}
            //else
            //{
            //    //�@�ԗ��Ǘ��R�[�h�����ݒ�
            //    dr[DCHNB02014EA.CT_OrderConf_CarMngCode] = "";                                          // ���q�Ǘ��R�[�h[����](string)
            //    dr[DCHNB02014EA.CT_OrderConf_FirstEntryDate] = "";                                      // ���N�x[����](String)
            //}
            dr[DCHNB02014EA.CT_OrderConf_CarMngCode] = orderConfWork.CarMngCode;                        // ���q�Ǘ��R�[�h[����](string)
            dr[DCHNB02014EA.CT_OrderConf_FirstEntryDate] = TDateTime.DateTimeToString("YYYY/MM", orderConfWork.FirstEntryDate);     // ���N�x[����](String)
            // 2008.11.27 30413 ���� �ԗ��Ǘ��R�[�h�Ə��N�x�̈󎚐ݒ�𔄏�m�F�\�Ɠ��l�ɕύX <<<<<<END
            dr[DCHNB02014EA.CT_OrderConf_SlipNote2] = orderConfWork.SlipNote2;                          // �`�[���l�Q[����](string)

            // 2008.12.08 30413 ���� ���l�R��ǉ� >>>>>>START
            dr[DCHNB02014EA.CT_OrderConf_SlipNote3] = orderConfWork.SlipNote3;                          // �`�[���l�R[����](string)
            // 2008.12.08 30413 ���� ���l�R��ǉ� <<<<<<END

            //dr[DCHNB02014EA.CT_OrderConf_BLGoodsCode] = orderConfWork.BLGoodsCode;                      // BL���i�R�[�h[����](Int32)
            if (orderConfWork.BLGoodsCode == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_BLGoodsCode] = "";
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_BLGoodsCode] = orderConfWork.BLGoodsCode.ToString("d05");                     // BL���i�R�[�h[����](Int32)
            }
            dr[DCHNB02014EA.CT_OrderConf_SalesOrderDivCd] = orderConfWork.SalesOrderDivCd;              // ����݌Ɏ�񂹋敪(Int32)
            // 2008.07.25 30413 ���� [����]�̍��ڒǉ� <<<<<<END

            // ����`�[�敪���̂̐ݒ�
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipName] = orderConfWork.TransactionName;       // ����敪��[�`�[]��OK�H

            // �ޕ�(����)�̐ݒ�
            if ((orderConfWork.ModelDesignationNo != 0) || (orderConfWork.CategoryNo != 0))
            {
                // �^���w��ԍ��Ɨޕʔԍ����[���ȊO�̏ꍇ
                dr[DCHNB02014EA.CT_OrderConf_CategoryDtl] = orderConfWork.ModelDesignationNo.ToString("d05") + "-" + orderConfWork.CategoryNo.ToString("d04");
            }
            else
            {
                dr[DCHNB02014EA.CT_OrderConf_CategoryDtl] = "";
            }

            // ����݌Ɏ�񂹋敪���̂̐ݒ�
            if (orderConfWork.SalesOrderDivCd == 0)
            {
                dr[DCHNB02014EA.CT_OrderConf_SalesOrderDivName] = "���";
            }
            else if (orderConfWork.SalesOrderDivCd == 1)
            {
                dr[DCHNB02014EA.CT_OrderConf_SalesOrderDivName] = "�݌�";
            }

            // 2009.01.27 30413 ���� ����ł̌v�Z�ʒu��ύX >>>>>>START
            //// ����ł̐ݒ�
            ////dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);        //DEL 2008/10/31 �����ɂ���ĕω������
            //// --- ADD 2008/10/31 ---------------------------------------------------------------------->>>>>
            //if ((this._printDiv == 1) || (this._printDiv == 3))
            //{
            //    // �`�[�P�ʂɏo�͎�

            //    // ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
            //    if ((orderConfWork.ConsTaxLayMethod == 2) ||
            //        (orderConfWork.ConsTaxLayMethod == 3) ||
            //        (orderConfWork.ConsTaxLayMethod == 9))
            //    {
            //        // �����
            //        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalAmntConsTaxInclu + orderConfWork.SalesDisTtlTaxInclu);
            //        // ���v���z
            //        dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc
            //                                                                + (orderConfWork.SalAmntConsTaxInclu + orderConfWork.SalesDisTtlTaxInclu);
            //    }
            //    // ����œ]�ŕ����@0�F�`�[�P�ʁA1�F���גP��
            //    else
            //    {
            //        // �����
            //        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);
            //        // ���v���z
            //        dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcPlusTax] = orderConfWork.SalesTotalTaxExc
            //                                                                + (orderConfWork.SalesTotalTaxInc - orderConfWork.SalesTotalTaxExc);
            //    }
            //}
            //else
            //{
            //    // ���גP�ʂɏo�͎�

            //    // ����œ]�ŕ����@2�F�����e�A3�F�����q�A9�F��ې�
            //    if ((orderConfWork.ConsTaxLayMethod == 2) ||
            //        (orderConfWork.ConsTaxLayMethod == 3) ||
            //        (orderConfWork.ConsTaxLayMethod == 9))
            //    {
            //        // �ېŋ敪�@2�F����
            //        if (orderConfWork.TaxationDivCd == 2)
            //        {
            //            // �����
            //            dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
            //        }
            //        // �ېŋ敪�@0�F�ېŁA1�F��ې�
            //        else
            //        {
            //            // �����
            //            dr[DCHNB02014EA.CT_OrderConf_Tax] = DBNull.Value;
            //        }
            //    }
            //    // ����œ]�ŕ����@0�F�`�[�P�ʁA1�F���גP��
            //    else
            //    {
            //        // �����
            //        dr[DCHNB02014EA.CT_OrderConf_Tax] = (orderConfWork.SalesMoneyTaxInc - orderConfWork.SalesMoneyTaxExc);
            //    }
            //}
            //dr[DCHNB02014EA.CT_OrderConf_ConsTaxLayMethod] = orderConfWork.ConsTaxLayMethod;        // ����œ]�ŕ���
            //dr[DCHNB02014EA.CT_OrderConf_TaxationDivCd] = orderConfWork.TaxationDivCd;              // �ېŋ敪
            //// --- ADD 2008/10/31 ----------------------------------------------------------------------<<<<<
            // 2009.01.27 30413 ���� ����ł̌v�Z�ʒu��ύX <<<<<<END

            // �e��(�Ŕ���)(�`�[)�̐ݒ�
            //dr[DCHNB02014EA.CT_OrderConf_GrossProfit] = (orderConfWork.SalesTotalTaxExc - orderConfWork.TotalCost);//del 2011/12/02 ���� Redmine #8316

            // �e��(�Ŕ���)(����)�̐ݒ�
            //dr[DCHNB02014EA.CT_OrderConf_GrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);//del 2011/12/02 ���� Redmine #8316

            //add 2011/12/02 ���� Redmine #8316----->>>>>>
            //�e���F���z�@�]�@����
            if (this._printDiv == 4 || this._printDiv == 2)
            {
                // �e��(�Ŕ���)(����)�̐ݒ�
                dr[DCHNB02014EA.CT_OrderConf_GrossProfitDtl] = (cnt * orderConfWork.SalesUnPrcTaxExcFl - cnt * orderConfWork.SalesUnitCost);
            }
            else
            {
                // �e��(�Ŕ���)(����)�̐ݒ�
                dr[DCHNB02014EA.CT_OrderConf_GrossProfitDtl] = (orderConfWork.SalesMoneyTaxExc - orderConfWork.Cost);
            }
            //add 2011/12/02 ���� Redmine #8316-----<<<<<
        }

        /// <summary>
        /// �f�[�^Row�쐬
        /// </summary>
        /// <param name="dr">�Z�b�g�Ώ�DataRow</param>
        /// <param name="sourceDataRow">�Z�b�g��DataRow</param>
        private void SetTebleRowFromDataRow(ref DataRow dr, DataRow sourceDataRow)
        {
            //[����]
            dr[DCHNB02014EA.CT_OrderConf_SectionCode] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SectionCode];			// ���_�R�[�h				(string)
            dr[DCHNB02014EA.CT_OrderConf_SectionGuideNm] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SectionGuideNm];			// ���_�K�C�h����			(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesDateRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesDateRF];            // ������t					(Int32)
            dr[DCHNB02014EA.CT_OrderConf_ShipmentDayRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ShipmentDayRF];          // �o�ד��t					(Int32)
            dr[DCHNB02014EA.CT_OrderConf_CustomerCodeRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CustomerCodeRF];         // ���Ӑ�R�[�h				(Int32)
            dr[DCHNB02014EA.CT_OrderConf_CustomerSnmRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CustomerSnmRF];			// ���Ӑ於��				(string)
            dr[DCHNB02014EA.CT_OrderConf_PartySaleSlipNumRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_PartySaleSlipNumRF];			// �����`�[�ԍ�[����]		(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesEmployeeCdRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesEmployeeCdRF];			// �̔��]�ƈ��R�[�h			(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesEmployeeNmRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesEmployeeNmRF];			// �̔��]�ƈ�����			(string)
            dr[DCHNB02014EA.CT_OrderConf_SearchSlipDateRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SearchSlipDateRF];				// ���͓��t[����]			(DateTime)
            dr[DCHNB02014EA.CT_OrderConf_SalesInputNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesInputNameRF];				//������͎Җ���[����]		(string)
            //[�`�[]
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF];					// ����`�[�ԍ�				(string)
            dr[DCHNB02014EA.CT_OrderConf_TotalCostSl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostSl];						// �������z�v�i������j[�`�[]			(Int64)
            dr[DCHNB02014EA.CT_OrderConf_TotalCostRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostRF];						// �������z�v�i����j[�`�[]			(Int64)
            dr[DCHNB02014EA.CT_OrderConf_TotalCostRtn] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostRtn];						// �������z�v�i�ԕi�j[�`�[]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginRate] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GrossMarginRate];				// �e����[�`�[]				(Double)
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GrossMarginMarkSlip];		// �e���`�F�b�N�}�[�N[�`�[]	(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF];		//����`�[���v(�Ŕ�)[�`�[]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesTotalTaxExcRF];			//����`�[���v(�Ŕ�)[�`�[]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesTotalTaxIncRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesTotalTaxIncRF];			//����`�[���v(�ō�)[�`�[]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlip] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxSlip];						//����Łi����j[�`�[]				(Int64)
            dr[DCHNB02014EA.CT_OrderConf_TransactionNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TransactionNameRF];			// ����敪��[�`�[]			(string)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlSlip] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxSlSlip];					//����Łi����j[�`�[]				(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnSlip] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxRtnSlip];					//����Łi�ԕi�j[�`�[]		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ReturnSalesMoney];				//�ԕi�z[�`�[](Int64)		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesSlipCdRF];					//����`�[�敪[�`�[]		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxExcRF];		// ����l�����z�v(�Ŕ�)[�`�[](Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxIncluRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesDisTtlTaxIncluRF];	// ����l�����z�v(�ō�)[�`�[](Int64)
            dr[DCHNB02014EA.CT_OrderConf_CntSales] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CntSales];								//���㐔[�`�[]
            dr[DCHNB02014EA.CT_OrderConf_CntReturn] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CntReturn];							//�ԕi��[�`�[]
            //[����]
            dr[DCHNB02014EA.CT_OrderConf_GoodsNoRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GoodsNoRF];				// ���i�ԍ�					(string)
            dr[DCHNB02014EA.CT_OrderConf_GoodsNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GoodsNameRF];            // ���i����					(string)
            dr[DCHNB02014EA.CT_OrderConf_MakerNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_MakerNameRF];            // ���[�J�[��				(string)
            dr[DCHNB02014EA.CT_OrderConf_SalesRowNoRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesRowNoRF];           // ����s�ԍ�				(Int32)
            dr[DCHNB02014EA.CT_OrderConf_ShipmentCntRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ShipmentCntRF];          // �o�א��i���ʁj[����]		(double)
            dr[DCHNB02014EA.CT_OrderConf_SalesUnPrcTaxExcFlRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesUnPrcTaxExcFlRF];	// ����P��(�Ŕ�)[����]		(Int64)
            //dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxIncRF]	 = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxIncRF];		// ������z�i�ō��݁j		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesMoneyTaxExcRF];     // ������z�i�Ŕ��j		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GrossMarginRateDtl];		// �e����[����]				(Double)
            dr[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_GrossMarginMarkDtl];		// �e���`�F�b�N�}�[�N[����]	(string)
            //dr[DCHNB02014EA.CT_OrderConf_PartySlipNumDtlRF]		 = sourceDataRow[DCHNB02014EA.CT_OrderConf_PartySlipNumDtlRF];		// �����`�[�ԍ�[����]		(string)
            //dr[DCHNB02014EA.CT_OrderConf_ConsTaxDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxDtl];						//����Łi����j[����]				(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxSlDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxSlDtl];						//����Łi����j[����]				(Int64)
            dr[DCHNB02014EA.CT_OrderConf_ConsTaxRtnDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_ConsTaxRtnDtl];			//����Łi�ԕi�j[����]		(Int64)
            dr[DCHNB02014EA.CT_OrderConf_CostRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_CostRF];									// �������z[����]			(Int64)			
            dr[DCHNB02014EA.CT_OrderConf_TotalCostDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostDtl];						// �������z�v�i����j[����]			(Int64)
            dr[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_TotalCostRtnDtl];				// �������z�v�i�ԕi�j[����]	(Int64)
            dr[DCHNB02014EA.CT_OrderConf_UnitNameRF] = sourceDataRow[DCHNB02014EA.CT_OrderConf_UnitNameRF];							//�P�ʖ���
            dr[DCHNB02014EA.CT_OrderConf_SalesSlipNmDtl] = sourceDataRow[DCHNB02014EA.CT_OrderConf_SalesSlipNmDtl];					//����`�[�敪��
        }

        /// <summary>
        /// �w�s�敪�x�i����`�[�敪[����]�j���̉�����
        /// </summary>
        private string GetSalesSlipNmDtl(int salesSlipCdDtl)
        {
            string wkStr = "";

            switch (salesSlipCdDtl)
            {
                case 0:
                    {
                        wkStr = "";		//"����"�̏ꍇ�͕\�������Ȃ�
                        break;
                    }
                case 1:
                    {
                        wkStr = "�ԕi";
                        break;
                    }
                case 2:
                    {
                        wkStr = "�l��";
                        break;
                    }
                case 9:
                    {
                        wkStr = "�ꎮ";
                        break;
                    }
            }

            return wkStr;
        }


        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        // --- ADD 2009/01/30 -------------------------------->>>>>
        /// <summary>
        /// �󒍎c���t�B���^����
        /// </summary>
        /// <remarks>
        /// <br>�󒍎c����0���̃f�[�^���폜����</br>
        /// </remarks>
        private void FilterByAcptAnOdrRemainCnt(ExtrInfo_DCHNB02013E saleConfListCndtn)
        {
            // �`�[�ԍ����Ƀ\�[�g
            DataTable copyTable = this._printDataSet.Tables[_SalesConfDataTable].Copy();

            DataRow[] drList = copyTable.Select("", DCHNB02014EA.CT_OrderConf_SalesSlipNumRF);

            this._printDataSet.Tables[_SalesConfDataTable].Rows.Clear();

            foreach (DataRow sortedRow in drList)
            {
                this._printDataSet.Tables[_SalesConfDataTable].ImportRow(sortedRow);
            }
            // --- DEL 2011/08/11 ----->>>>>
            //// --- ADD 2011/07/21 ----->>>>>
            //// �󒍁A�ݏo
            //if (saleConfListCndtn.PublicationType == 0
            //    || saleConfListCndtn.PublicationType == 2)
            //{
            //    bool isOK = false; // �󎚑Ώۃt���O
            //    bool falseflag = false;
            //    DataRow dr;
            //    List<int> sameSlipRowIndex = new List<int>();
            //    // �O�񏈗��`�[�ԍ�
            //    string beforeSalesSlip = string.Empty;
            //    for (int i = this._printDataSet.Tables[_SalesConfDataTable].Rows.Count - 1; i >= 0; i--)
            //    {
            //        dr = this._printDataSet.Tables[_SalesConfDataTable].Rows[i];

            //        if (dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString() == beforeSalesSlip)
            //        {
            //            // �����`�[�ԍ����ɂ́A�S���f�[�^�`���b�N���s��
            //            // �`�F�b�N
            //            isOK = this.CheckByAcptAnOdrRemainCnt(dr, saleConfListCndtn);

            //            // �����`�[�ԍ����ɂ́A��f�[�^�̃`���b�N���ʂ�False�Ȃ��
            //            // �S�������`�[�ԍ��f�[�^���ʃ��X�g����폜
            //            if (!isOK)
            //            {
            //                falseflag = true;
            //            }
            //            sameSlipRowIndex.Add(i);
            //        }
            //        else
            //        {
            //            if (beforeSalesSlip != string.Empty
            //                && falseflag)
            //            {
            //                // �폜�������s
            //                foreach (int delIndex in sameSlipRowIndex)
            //                {
            //                    this._printDataSet.Tables[_SalesConfDataTable].Rows.RemoveAt(delIndex);
            //                }
            //                falseflag = false;
            //            }

            //            // ������
            //            isOK = false;
            //            sameSlipRowIndex.Clear();
            //            beforeSalesSlip = dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString();

            //            // �`�F�b�N
            //            isOK = this.CheckByAcptAnOdrRemainCnt(dr, saleConfListCndtn);
            //            if (!isOK)
            //            {
            //                falseflag = true;
            //            }

            //            sameSlipRowIndex.Add(i);
            //        }

            //        if (i == 0)
            //        {
            //            if (falseflag)
            //            {
            //                // �폜�������s
            //                foreach (int delIndex in sameSlipRowIndex)
            //                {
            //                    this._printDataSet.Tables[_SalesConfDataTable].Rows.RemoveAt(delIndex);
            //                }
            //                falseflag = false;
            //            }
            //        }
            //    }
            //}
            //// --- ADD 2011/07/21 -----<<<<<

            //// �󒍌v��ρA�ݏo�v���
            //else
            //{
            // --- DEL 2011/08/11 -----<<<<<

            bool isOK = false; // �󎚑Ώۃt���O
            DataRow dr;
            List<int> sameSlipRowIndex = new List<int>();
            // �O�񏈗��`�[�ԍ�
            string beforeSalesSlip = string.Empty;
            for (int i = this._printDataSet.Tables[_SalesConfDataTable].Rows.Count - 1; i >= 0; i--)
            {
                dr = this._printDataSet.Tables[_SalesConfDataTable].Rows[i];

                if (dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString() == beforeSalesSlip)
                {
                    if (!isOK)
                    {
                        // �`�F�b�N
                        isOK = this.CheckByAcptAnOdrRemainCnt(dr, saleConfListCndtn);
                    }

                    sameSlipRowIndex.Add(i);
                }
                else
                {
                    if (beforeSalesSlip != string.Empty
                        && !isOK)
                    {
                        // �폜�������s
                        foreach (int delIndex in sameSlipRowIndex)
                        {
                            this._printDataSet.Tables[_SalesConfDataTable].Rows.RemoveAt(delIndex);
                        }
                    }

                    // ������
                    isOK = false;
                    sameSlipRowIndex.Clear();
                    beforeSalesSlip = dr[DCHNB02014EA.CT_OrderConf_SalesSlipNumRF].ToString();

                    // �`�F�b�N
                    isOK = this.CheckByAcptAnOdrRemainCnt(dr, saleConfListCndtn);

                    sameSlipRowIndex.Add(i);
                }

                if (i == 0)
                {
                    if (!isOK)
                    {
                        // �폜�������s
                        foreach (int delIndex in sameSlipRowIndex)
                        {
                            this._printDataSet.Tables[_SalesConfDataTable].Rows.RemoveAt(delIndex);
                        }
                    }
                }
            }
            //}// DEL 2011/08/11
        }

        /// <summary>
        /// 1���ׂ̎󒍎c���`�F�b�N
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="saleConfListCndtn"></param>
        /// <returns></returns>
        private bool CheckByAcptAnOdrRemainCnt(DataRow dr, ExtrInfo_DCHNB02013E saleConfListCndtn)
        {
            if (saleConfListCndtn.PublicationType == 0
                || saleConfListCndtn.PublicationType == 2)
            {
                // �󒍁A�ݏo
                // �󒍎c����0�łȂ�
                if (((double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] != 0))// ADD 2011/08/11
                //if (((double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] != 0)) // DEL 2011/07/21
                // --- DEL 2011/08/11 ----->>>>>
                //// --- ADD 2011/07/21 ----->>>>>
                //if (((double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt] != 0)
                //    && ((double)dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt]
                //    == (double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt]))
                //// --- ADD 2011/07/21 -----<<<<<
                // --- DEL 2011/08/11 -----<<<<<
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // �󒍌v��ρA�ݏo�v���
                // �󒍐�(�󒍐���+�󒍒�����)�Ǝ󒍎c�����قȂ�
                if ((double)dr[DCHNB02014EA.CT_OrderConf_AcceptAnOrderCntPlusAdjustCnt]
                    != (double)dr[DCHNB02014EA.CT_OrderConf_AcptAnOdrRemainCnt])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // --- ADD 2009/01/30 -------------------------------->>>>>

        #endregion

    }
}