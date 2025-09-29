//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���`�F�b�N���X�g
// �v���O�����T�v   : �d���`�F�b�N���X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/07/17  �C�����e : �������`�F�b�N�����̎d�l��ǋL
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2009/08/07  �C�����e :�@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j 
//                                 �A�d���f�[�^�`�F�b�N�̏ꍇ�A������̎d�l�C���i��{�d�l���̉���No15�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170129-00 �쐬�S�� : wujun
// �C �� ��  2015/08/17  �C�����e : Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�                                
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11170129-00 �쐬�S�� : mamd
// �C �� ��  2015/09/21  �C�����e : Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
//                                : �`�[�ԍ����ڂɃX�y�[�X���Z�b�g����Ă���ꍇ�̕s��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Windows.Forms;
using System.Text.RegularExpressions;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d���`�F�b�N���X�g �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �d���`�F�b�N���X�g�Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2009.05.10</br>
    /// <br>Update Note : 2015/08/17 wujun</br>
    /// <br>�Ǘ��ԍ�    : 11170129-00</br>
    /// <br>            : Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�</br> 
    /// </remarks>
    public class StockSlipAcs
    {
        #region �� Constructor
		/// <summary>
		/// �d���`�F�b�N���X�g�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d���`�F�b�N���X�g�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
		/// </remarks>
		public StockSlipAcs()
		{
            this._iStockSlipWorkDB = (IStockSlipResultDB)MediationStockSlipResultDB.GetStockSlipWorkDB();
		}

		/// <summary>
		/// �d���`�F�b�N���X�g�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d���`�F�b�N���X�g�A�N�Z�X�N���X�̏��������s���B</br>
	    /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
		/// </remarks>
        static StockSlipAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// ���[�o�͐ݒ�f�[�^�N���X	
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// ���[�o�͐ݒ�A�N�Z�X�N���X

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
        private static PrtOutSet stc_PrtOutSet;			            // ���[�o�͐ݒ�f�[�^�N���X
        private static PrtOutSetAcs stc_PrtOutSetAcs;	            // ���[�o�͐ݒ�A�N�Z�X�N���X

        #endregion �� Static Member

        #region �� Private Member
        IStockSlipResultDB _iStockSlipWorkDB;

        private SectionCdInputConstructionAcs _sectionCdInputConstructionAcs = null;
        private ArrayList codeList = new ArrayList();
        private ArrayList dataList = new ArrayList();
        private Hashtable _sectionCdTable = new Hashtable();

        private DataTable _stockSlipDt;			// ���DataTable
        private DataView _stockSlipView;	        // ���DataView

        private ArrayList codeListCSV = new ArrayList();
        private ArrayList codeListPM = new ArrayList();

        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// ����f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataView StockSlipView
        {
            get { return this._stockSlipView; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� �����f�[�^�擾
        /// <summary>
        /// �d���f�[�^�擾
        /// </summary>
        /// <param name="stockSlip">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d���f�[�^���擾����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public int SearchStockSlipProcMain(StockSlipCndtn stockSlip, out string errMsg)
        {
            return this.SearchStockSlipProc(stockSlip, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// �d���f�[�^�擾
        /// </summary>
        /// <param name="stockSlip"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �������d���f�[�^���擾����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private int SearchStockSlipProc(StockSlipCndtn stockSlip, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            errMsg = "";

            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKOU02055EA.CreateDataTable(ref this._stockSlipDt);

                // ���o�����W�J  --------------------------------------------------------------
                StockSlipCndtnWork stockSlipCndtnWork = new StockSlipCndtnWork();
                status = this.DevStockSlip(stockSlip, out stockSlipCndtnWork, out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object stockSlipResultWork = null;
                status = _iStockSlipWorkDB.Search(out stockSlipResultWork, (object)stockSlipCndtnWork);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                      
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        // �f�[�^check����
                        if (stockSlip.CheckSectionDiv.ToString().Equals("PMSupplier"))
                        {
                            
                            ArrayList csvDataList = stockSlip.CsvData;
                            ArrayList stockSlipResultList = stockSlipResultWork as ArrayList;
                            // PM�f�[�^�W�v����
                            PMDataGroup(stockSlip, ref stockSlipResultList, csvDataList);
                            // CSV�f�[�^�W�v����
                            CSVDataGroup(stockSlip, ref csvDataList);

                            // CSV�f�[�^ ArrayList ==> List
                            List<StockSlipTextData> csvList = new List<StockSlipTextData>();
                            foreach (StockSlipTextData tmp in csvDataList) 
                            {
                                csvList.Add(tmp);
                            }
                            ArrayList newCsvDate = new ArrayList();
                            if (csvDataList != null && csvDataList.Count>0)
                            {
                                // �\�[�g��
                                CsvDatatoComparer csvData = new CsvDatatoComparer();
                                csvList.Sort(csvData);
                                // List ==> ArrayList
                                foreach (StockSlipTextData tmp in csvList) 
                                {
                                    newCsvDate.Add(tmp);
                                }
                            }

                            // PM�f�[�^ ArrayList ==> List
                            List<StockSlipResultWork> pmList = new List<StockSlipResultWork>();
                            foreach (StockSlipResultWork tmp in stockSlipResultList)
                            {
                                pmList.Add(tmp);
                            }
                            ArrayList newPmDate = new ArrayList();
                            if (stockSlipResultList != null && stockSlipResultList.Count > 0)
                            {
                                // �\�[�g��
                                PMDatatoComparer pmData = new PMDatatoComparer();
                                pmList.Sort(pmData);
                                // List ==> ArrayList
                                foreach (StockSlipResultWork tmp in pmList)
                                {
                                    newPmDate.Add(tmp);
                                }
                            }

                            // PM/�d����̏ꍇ�̃`�F�b�N
                            CheckStockSlipPMData(stockSlip, newPmDate, newCsvDate);

                        }
                        else
                        {
                            // �d���f�[�^�d���̏ꍇ�̃`�F�b�N
                            CheckStockSlipRepData(stockSlip, (ArrayList)stockSlipResultWork);
                            if (this._stockSlipView.Count == 0)
                            {
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "�d���f�[�^�̎擾�Ɏ��s���܂����B";
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
        #endregion �� ���[�f�[�^�擾

        #region �� �f�[�^�W�J����
        #region �� �擾�f�[�^�W�J����
        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="stockSlipCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾PM�f�[�^</param>
        /// <param name="csvDataList">csvDataList</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void PMDataGroup(StockSlipCndtn stockSlipCndtn, ref ArrayList resultWork, ArrayList csvDataList)
        {
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check"))
            {
                // ���_�ϊ��ݒ��ʂ̋��_�R�[�h��ϊ�����
                this._sectionCdInputConstructionAcs = new SectionCdInputConstructionAcs();
                codeList = _sectionCdInputConstructionAcs.InputSecCdCSV;
                dataList = _sectionCdInputConstructionAcs.InputSecCdPM;

                //---ADD 20090717 �d�l�ύX �������`�F�b�N�����̎d�l��ǋL----->>>>>
                bool cdSameFlg = false;
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    string sectionCsvCode = stockSlipTextData.StockSectionCd;
                    cdSameFlg = false;
                    for (int codeCount = 0; codeCount < codeList.Count; codeCount++ )
                    {
                        if (sectionCsvCode.Equals(codeList[codeCount]))
                        {
                            cdSameFlg = true;
                            break;
                        }
                    }
                    if (cdSameFlg)
                    {
                        continue;
                    }
                    else
                    {
                        ArrayList newList = new ArrayList();
                        codeList.Add(sectionCsvCode);
                        newList.Add(sectionCsvCode.Substring(8, 2));
                        dataList.Add(newList);
                    }
                }
                //---ADD 20090717 �d�l�ύX �������`�F�b�N�����̎d�l��ǋL-----<<<<<


                //�@ADD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j----->>>>>
                for (int ii = 0; ii < codeList.Count; ii++)
                {
                    ArrayList listA = new ArrayList();
                    listA = (ArrayList)dataList[ii];
                    for (int jj = 0; jj < listA.Count; jj++)
                    {
                        codeListCSV.Add(codeList[ii]);
                        codeListPM.Add(listA[jj]);
                    }
                }
                //�@ADD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<

                /*�@DEL 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                bool sameFlg = false;
                //�@���_�ϊ��ݒ肵���̏ꍇ
                if (codeList != null && codeList.Count > 0)
                {
                    for (int i = 0; i < codeList.Count; i++)
                    {
                        _sectionCdTable.Add(codeList[i].ToString().PadLeft(10,'0'), dataList[i]);
                    }

                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        string secCd = stockSlipResultWork.StockAddUpSectionCd.Trim();
                        for (int i = 0; i < dataList.Count; i++)
                        {
                            ArrayList secList = (ArrayList)dataList[i];
                            for (int j = 0; j < secList.Count; j++)
                            {
                                // �����̏ꍇ�A�ϊ�����
                                if (secCd.Equals(secList[j]))
                                {
                                    stockSlipResultWork.StockAddUpSectionCd = codeList[i].ToString();
                                    sameFlg = true;
                                    break;
                                }
                            }
                            if (sameFlg)
                            {
                                sameFlg = false;
                                break;
                            }
                        }
                    }
                }
                */
            }
            
            Hashtable pmDataTable = new Hashtable();

            // �d�����`�F�b�N�́u�Ȃ��v�A���_�`�F�b�N�́u�Ȃ��v�̏ꍇ,�u�`�[�ԍ��v�u�d����R�[�h�v���ɏW�v
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    stockSlipResultWork.PartySaleSlipNum = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    string slipNoSupplierCd = stockSlipResultWork.PartySaleSlipNum + "_" + stockSlipResultWork.PayeeCode.ToString();
                    //�@�`�[�ԍ��v�u�d����R�[�h�v�����̏ꍇ�A�W�v����
                    if (pmDataTable.Contains(slipNoSupplierCd))
                    {
                        StockSlipResultWork stockSlipResultInTable = (StockSlipResultWork)pmDataTable[slipNoSupplierCd];

                        //�@�d�����͈Ⴂ�̏ꍇ�A�ŐV�̓���ݒ肷��
                        if (stockSlipResultInTable.StockDate > stockSlipResultWork.StockDate)
                        {
                            stockSlipResultWork.StockDate = stockSlipResultInTable.StockDate;
                        }
                        //�@���_�͈Ⴂ�̏ꍇ�A�ő�̋��_�R�[�h��ݒ肷��
                        if (Convert.ToInt32( stockSlipResultInTable.StockAddUpSectionCd )> Convert.ToInt32( stockSlipResultWork.StockAddUpSectionCd))
                        {
                            stockSlipResultWork.StockAddUpSectionCd = stockSlipResultInTable.StockAddUpSectionCd;
                        }
                        if (Convert.ToInt32(stockSlipResultInTable.StockAddUpSectionCdPm) > Convert.ToInt32(stockSlipResultWork.StockAddUpSectionCdPm))
                        {
                            stockSlipResultWork.StockAddUpSectionCdPm = stockSlipResultInTable.StockAddUpSectionCdPm;
                        }
                        if (stockSlipResultInTable.SupplierSlipNo > stockSlipResultWork.SupplierSlipNo)
                        {
                            stockSlipResultWork.SupplierSlipNo = stockSlipResultInTable.SupplierSlipNo;
                        }
                        //�@���z���W�v����
                        stockSlipResultWork.StockTotalPrice += stockSlipResultInTable.StockTotalPrice;
                        pmDataTable.Remove(slipNoSupplierCd);
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                    else
                    {
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                }

            }

            // �d�����`�F�b�N�́u����v�A���_�`�F�b�N�́u�Ȃ��v�̏ꍇ,�u�`�[�ԍ��v�u�d����R�[�h�v�u�d�����v���ɏW�v
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    string slipNoSupplierCd = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum) + "_" 
                                            + stockSlipResultWork.StockDate.ToString() +"_" 
                                               + stockSlipResultWork.PayeeCode.ToString();
                    //�@�u�`�[�ԍ��v�u�d����R�[�h�v�u�d�����v�����̏ꍇ�A�W�v����
                    if (pmDataTable.Contains(slipNoSupplierCd))
                    {
                        StockSlipResultWork stockSlipResultInTable = (StockSlipResultWork)pmDataTable[slipNoSupplierCd];
                        //�@���_�͈Ⴂ�̏ꍇ�A�ő�̋��_�R�[�h��ݒ肷��
                        if (Convert.ToInt32( stockSlipResultInTable.StockAddUpSectionCd) > Convert.ToInt32( stockSlipResultWork.StockAddUpSectionCd))
                        {
                            stockSlipResultWork.StockAddUpSectionCd = stockSlipResultInTable.StockAddUpSectionCd;
                        }
                        if (Convert.ToInt32(stockSlipResultInTable.StockAddUpSectionCdPm) > Convert.ToInt32(stockSlipResultWork.StockAddUpSectionCdPm))
                        {
                            stockSlipResultWork.StockAddUpSectionCdPm = stockSlipResultInTable.StockAddUpSectionCdPm;
                        }
                        if (stockSlipResultInTable.SupplierSlipNo > stockSlipResultWork.SupplierSlipNo)
                        {
                            stockSlipResultWork.SupplierSlipNo = stockSlipResultInTable.SupplierSlipNo;
                        }

                        //�@���z���W�v����
                        stockSlipResultWork.StockTotalPrice += stockSlipResultInTable.StockTotalPrice;
                        pmDataTable.Remove(slipNoSupplierCd);
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                    else
                    {
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                }
            }

            // �d�����`�F�b�N�́u�Ȃ��v�A���_�`�F�b�N�́u����v�̏ꍇ,�u�`�[�ԍ��v�u�d����R�[�h�v�u���_�R�[�h�v���ɏW�v
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    string slipNoSupplierCd =  SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum) + "_"
                                          + stockSlipResultWork .StockAddUpSectionCd + "_" 
                                              + stockSlipResultWork.PayeeCode.ToString();
                    //�@�`�[�ԍ��v�u�d����R�[�h�v�u���_�R�[�h�v�����̏ꍇ�A�W�v����
                    if (pmDataTable.Contains(slipNoSupplierCd))
                    {
                        StockSlipResultWork stockSlipResultInTable = (StockSlipResultWork)pmDataTable[slipNoSupplierCd];
                        //�@�d�����͈Ⴂ�̏ꍇ�A�ŐV�̓���ݒ肷��
                        if (stockSlipResultInTable.StockDate > stockSlipResultWork.StockDate)
                        {
                            stockSlipResultWork.StockDate = stockSlipResultInTable.StockDate;
                        }
                        if (Convert.ToInt32(stockSlipResultInTable.StockAddUpSectionCdPm) > Convert.ToInt32(stockSlipResultWork.StockAddUpSectionCdPm))
                        {
                            stockSlipResultWork.StockAddUpSectionCdPm = stockSlipResultInTable.StockAddUpSectionCdPm;
                        }
                        if (stockSlipResultInTable.SupplierSlipNo > stockSlipResultWork.SupplierSlipNo)
                        {
                            stockSlipResultWork.SupplierSlipNo = stockSlipResultInTable.SupplierSlipNo;
                        }
                        //�@���z���W�v����
                        stockSlipResultWork.StockTotalPrice += stockSlipResultInTable.StockTotalPrice;
                        pmDataTable.Remove(slipNoSupplierCd);
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                    else
                    {
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                }

            }

            // �d�����`�F�b�N�́u����v�A���_�`�F�b�N�́u����v�̏ꍇ,�u�`�[�ԍ��v�u�d����R�[�h�v�u���_�R�[�h�v�u�d�����v���ɏW�v
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    string slipNoSupplierCd = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum) + "_"
                                            + stockSlipResultWork.StockAddUpSectionCd + "_"
                                               + stockSlipResultWork.StockDate.ToString() + "_" 
                                                 + stockSlipResultWork.PayeeCode.ToString();
                    // �u�`�[�ԍ��v�u�d����R�[�h�v�u���_�R�[�h�v�u�d�����v�����̏ꍇ
                    if (pmDataTable.Contains(slipNoSupplierCd))
                    {
                        StockSlipResultWork stockSlipResultInTable = (StockSlipResultWork)pmDataTable[slipNoSupplierCd];
                        if (Convert.ToInt32(stockSlipResultInTable.StockAddUpSectionCdPm) > Convert.ToInt32(stockSlipResultWork.StockAddUpSectionCdPm))
                        {
                            stockSlipResultWork.StockAddUpSectionCdPm = stockSlipResultInTable.StockAddUpSectionCdPm;
                        }
                        if (stockSlipResultInTable.SupplierSlipNo > stockSlipResultWork.SupplierSlipNo)
                        {
                            stockSlipResultWork.SupplierSlipNo = stockSlipResultInTable.SupplierSlipNo;
                        }
                        //�@���z���W�v����
                        stockSlipResultWork.StockTotalPrice += stockSlipResultInTable.StockTotalPrice;
                        pmDataTable.Remove(slipNoSupplierCd);
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                    else
                    {
                        pmDataTable.Add(slipNoSupplierCd, stockSlipResultWork);
                    }
                }
            }

            resultWork = new ArrayList(pmDataTable.Values);
        }


        /// <summary>
        /// �擾�f�[�^�W�J����
        /// </summary>
        /// <param name="stockSlipCndtn">UI���o�����N���X</param>
        /// <param name="csvDataList">�擾CSV�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void CSVDataGroup(StockSlipCndtn stockSlipCndtn, ref ArrayList csvDataList)
        {
            Hashtable csvDataTable = new Hashtable();

            // �d�����`�F�b�N�́u�Ȃ��v�A���_�`�F�b�N�́u�Ȃ��v�̏ꍇ,�u�`�[�ԍ��v���ɏW�v
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    stockSlipTextData.SupplierSlipNo = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    string slipNo = stockSlipTextData.SupplierSlipNo;
                    DateTime textDate = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                    // �u�`�[�ԍ��v�����̏ꍇ
                    if (csvDataTable.Contains(slipNo))
                    {
                        StockSlipTextData stockSlipInTable = (StockSlipTextData)csvDataTable[slipNo];
                        DateTime tableDate = DateTime.ParseExact(stockSlipInTable.StockDate, "yyyyMMdd", null);
                        //�@�d�����͈Ⴂ�̏ꍇ�A�ŐV�̓���ݒ肷��
                        if (tableDate > textDate)
                        {
                            stockSlipTextData.StockDate = stockSlipInTable.StockDate;
                        }
                        //�@���z���W�v����
                        stockSlipTextData.StockPrice += stockSlipInTable.StockPrice;
                        csvDataTable.Remove(slipNo);
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                    else
                    {
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                }

                csvDataList = new ArrayList(csvDataTable.Values);
            }

            // �d�����`�F�b�N�́u����v�A���_�`�F�b�N�́u�Ȃ��v�̏ꍇ,�u�`�[�ԍ��v�u�d�����v���ɏW�v
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    stockSlipTextData.SupplierSlipNo = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    DateTime textDate = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                    string slipNo = stockSlipTextData.SupplierSlipNo + "_" + textDate;
                    int sectionCd = Convert.ToInt32(stockSlipTextData.StockSectionCd);
                    // �u�`�[�ԍ��v�u�d�����v�����̏ꍇ
                    if (csvDataTable.Contains(slipNo))
                    {
                        StockSlipTextData stockSlipInTable = (StockSlipTextData)csvDataTable[slipNo];
                        int sectionCdIn = Convert.ToInt32(stockSlipInTable.StockSectionCd);

                        //�@���_�͈Ⴂ�̏ꍇ�A�ő勒�_��ݒ肷��
                        if (sectionCdIn > sectionCd)
                        {
                            stockSlipTextData.StockSectionCd = stockSlipInTable.StockSectionCd;
                        }
                        //�@���z���W�v����
                        stockSlipTextData.StockPrice += stockSlipInTable.StockPrice;
                        csvDataTable.Remove(slipNo);
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                    else
                    {
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                }

                csvDataList = new ArrayList(csvDataTable.Values);
            }

            // �d�����`�F�b�N�́u�Ȃ��v�A���_�`�F�b�N�́u����v�̏ꍇ,�u�`�[�ԍ��v�u���_�R�[�h�v���ɏW�v
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    stockSlipTextData.SupplierSlipNo = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    string slipNo = stockSlipTextData.SupplierSlipNo + "_" + stockSlipTextData.StockSectionCd;
                    DateTime textDate = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                    // �u�`�[�ԍ��v�����̏ꍇ
                    if (csvDataTable.Contains(slipNo))
                    {
                        StockSlipTextData stockSlipInTable = (StockSlipTextData)csvDataTable[slipNo];
                        DateTime tableDate = DateTime.ParseExact(stockSlipInTable.StockDate, "yyyyMMdd", null);
                        //�@�d�����͈Ⴂ�̏ꍇ�A�ŐV�̓���ݒ肷��
                        if (tableDate > textDate)
                        {
                            stockSlipTextData.StockDate = stockSlipInTable.StockDate;
                        }
                        //�@���z���W�v����
                        stockSlipTextData.StockPrice += stockSlipInTable.StockPrice;
                        csvDataTable.Remove(slipNo);
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                    else
                    {
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                }

                csvDataList = new ArrayList(csvDataTable.Values);
            }

            // �d�����`�F�b�N�́u����v�A���_�`�F�b�N�́u����v�̏ꍇ,�u�`�[�ԍ��v�u���_�R�[�h�v�u�d�����v���ɏW�v
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipTextData stockSlipTextData in csvDataList)
                {
                    stockSlipTextData.SupplierSlipNo = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    DateTime textDate = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null);
                    string slipNo = stockSlipTextData.SupplierSlipNo + "_" + stockSlipTextData.StockSectionCd + "_" + textDate;

                    // �u�`�[�ԍ��v�u���_�R�[�h�v�u�d�����v�����̏ꍇ
                    if (csvDataTable.Contains(slipNo))
                    {
                        StockSlipTextData stockSlipInTable = (StockSlipTextData)csvDataTable[slipNo];

                        //�@���z���W�v����
                        stockSlipTextData.StockPrice += stockSlipInTable.StockPrice;
                        csvDataTable.Remove(slipNo);
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                    else
                    {
                        csvDataTable.Add(slipNo, stockSlipTextData);
                    }
                }

                csvDataList = new ArrayList(csvDataTable.Values);
            }
        }
        #endregion

        #region �� ���o�����W�J����
        /// <summary>
		/// ���o�����W�J����
		/// </summary>
        /// <param name="stockSlip">UI���o�����N���X</param>
        /// <param name="stockSlipCndtnWork">�����[�g���o�����N���X</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevStockSlip(StockSlipCndtn stockSlip, out StockSlipCndtnWork stockSlipCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            stockSlipCndtnWork = new StockSlipCndtnWork();
            try
            {
                // ��ƃR�[�h 
                stockSlipCndtnWork.EnterpriseCode = stockSlip.EnterpriseCode;
                // ���_�R�[�h���X�g
                stockSlipCndtnWork.SectionCodeList = stockSlip.SectionCodeList;
                // �x�������̊J�n��
                stockSlipCndtnWork.St_csvDate = stockSlip.St_addUpDate;
                // �x�������̏I����
                stockSlipCndtnWork.Ed_csvDate = stockSlip.Ed_addUpDate;
                // �d����R�[�h
                stockSlipCndtnWork.SupplierCd = stockSlip.SupplierCd;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }


        #endregion �� ���o�����W�J����
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
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

        /// <summary>
        /// �擾�f�[�^Check����
        /// </summary>
        /// <param name="stockSlipCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private void CheckStockSlipRepData(StockSlipCndtn stockSlipCndtn, ArrayList resultWork)
        {
            string strSlipNoA = null;
            string strSlipNoB = null;
            // �d�����`�F�b�N�́u�Ȃ��v�A���_�`�F�b�N�́u�Ȃ��v�̏ꍇ,
            // ��`�[�ԍ����PM���ް����ɓ���̓`�[�����݂����ꍇ
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipResultWork stockSlipResultWorkA in resultWork)
                {
                    strSlipNoA = stockSlipResultWorkA.PartySaleSlipNum;

                    foreach (StockSlipResultWork stockSlipResultWorkB in resultWork)
                    {
                        strSlipNoB = stockSlipResultWorkB.PartySaleSlipNum;

                        // DEL 20090807 ���仁@
                        // �o�O�C���F�d���f�[�^�d���`�F�b�N�����ŁA�d���f�[�^���ɓ���`�[�ԍ��̃��R�[�h��3���R�[�h�ȏ゠�����ꍇ�ɏd���`�F�b�N�������s��
                        //if (stockSlipResultWorkA.UoeRemark2.Equals("checked"))
                        //{
                        //    break;
                        //}
                        // ���̃f�[�^�̓`�F�b�N���ꂽ
                        if (stockSlipResultWorkA.Equals(stockSlipResultWorkB) ||
                               stockSlipResultWorkB.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        else
                        {
                            //�@��`�[�ԍ�������̏ꍇ
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                DataRow dr;
                                if (stockSlipResultWorkA.UoeRemark2.Equals("unchecked"))
                                {
                                    stockSlipResultWorkA.UoeRemark2 = "checked";
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkA.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = strSlipNoA;
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkA.StockAddUpSectionCd;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkA.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkA.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkA.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkA.SupplierSlipNote1;
                                    if (stockSlipResultWorkA.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }
                                    
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[���d��";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                                stockSlipResultWorkB.UoeRemark2 = "checked";
                                dr = _stockSlipDt.NewRow();
                                dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkB.StockDate.ToString("yyyy/MM/dd");
                                dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = strSlipNoB;
                                dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkB.StockAddUpSectionCd;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkB.SupplierSlipNo;
                                dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkB.StockDate;
                                dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkB.StockTotalPrice;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkB.SupplierSlipNote1;
                                if (stockSlipResultWorkB.WayToOrder == 2)
                                {
                                    dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                }
                                dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[���d��";
                                dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                this._stockSlipDt.Rows.Add(dr);
                            }
                        }
                    }
                }

                //�@�o�l�`�[���d���Ȃ��̃f�[�^�̏���
                foreach (StockSlipResultWork stockSlipResultWorkC in resultWork)
                {
                   if (stockSlipResultWorkC.UoeRemark2.Equals("unchecked"))
                    {
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkC.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkC.PartySaleSlipNum;
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkC.StockAddUpSectionCd;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkC.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkC.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkC.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkC.SupplierSlipNote1;
                        if (stockSlipResultWorkC.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�@";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // �d�����`�F�b�N�́u����v�A���_�`�F�b�N�́u�Ȃ��v�̏ꍇ,
            // ����t+�`�[�ԍ����PM���ް����ɓ���̓`�[�����݂����ꍇ
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWorkA in resultWork)
                {
                    strSlipNoA = stockSlipResultWorkA.StockDate.ToString() + stockSlipResultWorkA.PartySaleSlipNum;

                    foreach (StockSlipResultWork stockSlipResultWorkB in resultWork)
                    {
                        strSlipNoB = stockSlipResultWorkB.StockDate.ToString() + stockSlipResultWorkB.PartySaleSlipNum;
                        // DEL 20090807 ���仁@
                        // �o�O�C���F�d���f�[�^�d���`�F�b�N�����ŁA�d���f�[�^���ɓ���`�[�ԍ��̃��R�[�h��3���R�[�h�ȏ゠�����ꍇ�ɏd���`�F�b�N�������s��
                        //if (stockSlipResultWorkA.UoeRemark2.Equals("checked"))
                        //{
                        //    break;
                        //}
                        if (stockSlipResultWorkA.Equals(stockSlipResultWorkB) ||
                               stockSlipResultWorkB.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        else
                        {
                            // ����t+�`�[�ԍ����PM���ް����ɓ���̓`�[�����݂����ꍇ
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                DataRow dr;
                                if (stockSlipResultWorkA.UoeRemark2.Equals("unchecked"))
                                {
                                    stockSlipResultWorkA.UoeRemark2 = "checked";
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkA.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkA.PartySaleSlipNum;
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkA.StockAddUpSectionCd;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkA.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkA.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkA.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkA.SupplierSlipNote1;
                                    if (stockSlipResultWorkA.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[���d��";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                                stockSlipResultWorkB.UoeRemark2 = "checked";
                                dr = _stockSlipDt.NewRow();
                                dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkB.StockDate.ToString("yyyy/MM/dd");
                                dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkB.PartySaleSlipNum;
                                dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkB.StockAddUpSectionCd;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkB.SupplierSlipNo;
                                dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkB.StockDate;
                                dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkB.StockTotalPrice;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkB.SupplierSlipNote1;
                                if (stockSlipResultWorkB.WayToOrder == 2)
                                {
                                    dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                }
                                dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[���d��";
                                dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                this._stockSlipDt.Rows.Add(dr);
                            }
                        }
                    }
                }

                //�@�o�l�`�[���d���Ȃ��̃f�[�^�̏���
                foreach (StockSlipResultWork stockSlipResultWorkC in resultWork)
                {
                    if (stockSlipResultWorkC.UoeRemark2.Equals("unchecked"))
                    {
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkC.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkC.PartySaleSlipNum;
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkC.StockAddUpSectionCd;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkC.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkC.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkC.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkC.SupplierSlipNote1;
                        if (stockSlipResultWorkC.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = " ";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // �d�����`�F�b�N�́u�Ȃ��v�A���_�`�F�b�N�́u����v�̏ꍇ,
            // ����_����+�`�[�ԍ����PM���ް����ɓ���̓`�[�����݂����ꍇ
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                foreach (StockSlipResultWork stockSlipResultWorkA in resultWork)
                {
                    strSlipNoA = stockSlipResultWorkA.PartySaleSlipNum + stockSlipResultWorkA.StockAddUpSectionCd;

                    foreach (StockSlipResultWork stockSlipResultWorkB in resultWork)
                    {
                        strSlipNoB =stockSlipResultWorkB.PartySaleSlipNum + stockSlipResultWorkB.StockAddUpSectionCd;
                        // DEL 20090807 ���仁@
                        // �o�O�C���F�d���f�[�^�d���`�F�b�N�����ŁA�d���f�[�^���ɓ���`�[�ԍ��̃��R�[�h��3���R�[�h�ȏ゠�����ꍇ�ɏd���`�F�b�N�������s��
                        //if (stockSlipResultWorkA.UoeRemark2.Equals("checked"))
                        //{
                        //    break;
                        //}
                        //�@�f�[�^�`�F�b�N���ꂽ�̏ꍇ�A�����Ȃ�
                        if (stockSlipResultWorkA.Equals(stockSlipResultWorkB) ||
                               stockSlipResultWorkB.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        else
                        {
                            // ����_����+�`�[�ԍ����PM���ް����ɓ���̓`�[�����݂����ꍇ
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                DataRow dr;
                                if (stockSlipResultWorkA.UoeRemark2.Equals("unchecked"))
                                {
                                    stockSlipResultWorkA.UoeRemark2 = "checked";
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkA.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] =stockSlipResultWorkA.PartySaleSlipNum;
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkA.StockAddUpSectionCd;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkA.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkA.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkA.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkA.SupplierSlipNote1;
                                    if (stockSlipResultWorkA.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[���d��";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                                stockSlipResultWorkB.UoeRemark2 = "checked";
                                dr = _stockSlipDt.NewRow();
                                dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkB.StockDate.ToString("yyyy/MM/dd");
                                dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] =  stockSlipResultWorkB.PartySaleSlipNum;
                                dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkB.StockAddUpSectionCd;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkB.SupplierSlipNo;
                                dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkB.StockDate;
                                dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkB.StockTotalPrice;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkB.SupplierSlipNote1;
                                if (stockSlipResultWorkB.WayToOrder == 2)
                                {
                                    dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                }
                                dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[���d��";
                                dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                this._stockSlipDt.Rows.Add(dr);
                            }
                        }
                    }
                }
                //�@�o�l�`�[���d���Ȃ��̃f�[�^�̏���
                foreach (StockSlipResultWork stockSlipResultWorkC in resultWork)
                {
                    if (stockSlipResultWorkC.UoeRemark2.Equals("unchecked"))
                    {
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkC.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkC.PartySaleSlipNum;
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkC.StockAddUpSectionCd;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkC.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkC.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkC.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkC.SupplierSlipNote1;
                        if (stockSlipResultWorkC.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = " ";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // �d�����`�F�b�N�́u����v�A���_�`�F�b�N�́u����v�̏ꍇ,
            // ����_����+�d����+�`�[�ԍ����PM���ް����ɓ���̓`�[�����݂����ꍇ
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {

                foreach (StockSlipResultWork stockSlipResultWorkA in resultWork)
                {
                    strSlipNoA = stockSlipResultWorkA.StockDate.ToString() + stockSlipResultWorkA.PartySaleSlipNum
                                      + stockSlipResultWorkA.StockAddUpSectionCd;

                    foreach (StockSlipResultWork stockSlipResultWorkB in resultWork)
                    {
                        strSlipNoB = stockSlipResultWorkB.StockDate.ToString() + stockSlipResultWorkB.PartySaleSlipNum
                                          + stockSlipResultWorkB.StockAddUpSectionCd;

                        // DEL 20090807 ���仁@
                        // �o�O�C���F�d���f�[�^�d���`�F�b�N�����ŁA�d���f�[�^���ɓ���`�[�ԍ��̃��R�[�h��3���R�[�h�ȏ゠�����ꍇ�ɏd���`�F�b�N�������s��
                        //if (stockSlipResultWorkA.UoeRemark2.Equals("checked"))
                        //{
                        //    break;
                        //}
                        //�@�f�[�^�`�F�b�N���ꂽ�̏ꍇ�A�����Ȃ�
                        if (stockSlipResultWorkA.Equals(stockSlipResultWorkB) ||
                               stockSlipResultWorkB.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        else
                        {
                            // ����_����+�d����+�`�[�ԍ����PM���ް����ɓ���̓`�[�����݂����ꍇ
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                DataRow dr;
                                if (stockSlipResultWorkA.UoeRemark2.Equals("unchecked"))
                                {
                                    stockSlipResultWorkA.UoeRemark2 = "checked";
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkA.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkA.PartySaleSlipNum;
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkA.StockAddUpSectionCd;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkA.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkA.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkA.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkA.SupplierSlipNote1;
                                    if (stockSlipResultWorkA.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[���d��";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                                stockSlipResultWorkB.UoeRemark2 = "checked";
                                dr = _stockSlipDt.NewRow();
                                dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkB.StockDate.ToString("yyyy/MM/dd");
                                dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkB.PartySaleSlipNum;
                                dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkB.StockAddUpSectionCd;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkB.SupplierSlipNo;
                                dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkB.StockDate;
                                dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkB.StockTotalPrice;
                                dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkB.SupplierSlipNote1;
                                if (stockSlipResultWorkB.WayToOrder == 2)
                                {
                                    dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                }
                                dr[PMKOU02055EA.ct_Col_errDiv] = 6;
                                dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[���d��";
                                dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                                this._stockSlipDt.Rows.Add(dr);
                            }
                        }
                    }
                }
                //�@�o�l�`�[���d���Ȃ��̃f�[�^�̏���
                foreach (StockSlipResultWork stockSlipResultWorkC in resultWork)
                {
                    if (stockSlipResultWorkC.UoeRemark2.Equals("unchecked"))
                    {
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWorkC.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = stockSlipResultWorkC.PartySaleSlipNum;
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWorkC.StockAddUpSectionCd;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWorkC.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWorkC.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWorkC.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWorkC.SupplierSlipNote1;
                        if (stockSlipResultWorkC.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = " ";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // �s��v��PM�f�[�^�̋��z���v
            long diffPricePM = 0;
            // PM�f�[�^�̋��z�����v
            long totalPricePM = 0;

            // �s��v��CSV�f�[�^�̋��z���v
            long diffPriceCSV = 0;
            // CSV�f�[�^�̋��z�����v
            long totalPriceCSV = 0;
            for (int i = 0; i < _stockSlipDt.Rows.Count; i++)
            {
                if (_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_printDiv].Equals("Different"))
                {
                    diffPricePM += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_StockTotalPrice];
                    diffPriceCSV += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_Csv_StockTotalPrice];
                }
            }
            totalPricePM = diffPricePM;
            totalPriceCSV = diffPriceCSV;
            stockSlipCndtn.DiffPmPrice = diffPricePM;
            stockSlipCndtn.DiffCsvPrice = diffPriceCSV;
            stockSlipCndtn.TotalPmPrice = totalPricePM;
            stockSlipCndtn.TotalCsvPrice = totalPriceCSV;

            // �t�B���^����
            string myFilter = string.Format("{0} = '{1}'", PMKOU02055EA.ct_Col_printDiv, "Different");

            DataView myView = new DataView(this._stockSlipDt, myFilter, "", DataViewRowState.CurrentRows);

            // DataView�쐬
            this._stockSlipView = new DataView(this._stockSlipDt, myFilter, GetSortOrder(stockSlipCndtn), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// �擾�f�[�^Check����
        /// </summary>
        /// <param name="stockSlipCndtn">UI���o�����N���X</param>
        /// <param name="resultWork">�擾PM�f�[�^</param>
        /// <param name="csvDataWork">�擾CSV�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �擾�f�[�^��W�J����B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// <br>Update Note: 2015/08/17 wujun</br>
        /// <br>�Ǘ��ԍ�   : 11170129-00</br>
        /// <br>           : Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�</br> 
        /// </remarks>
        private void CheckStockSlipPMData(StockSlipCndtn stockSlipCndtn, ArrayList resultWork, ArrayList csvDataWork)
        {
            string strSlipNoA = null;
            string strSlipNoB = null;
            string strSceCdA = null;
            string strSceCdB = null;
            long strPriceA;
            long strPriceB;
            string strDateA = null;
            string strDateB = null;

            bool sameFlg;
            // �d�����`�F�b�N�́u�Ȃ��v�A���_�`�F�b�N�́u�Ȃ��v�̏ꍇ
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                // PM�̢�`�[�ԍ���Ŏd������ް��ɑ��݂��Ȃ��ꍇ
                
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    sameFlg = false;
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        // PM�̢�`�[�ԍ���Ŏd������ް��ɑ��݂���̏ꍇ
                        if (strSlipNoA.Equals(strSlipNoB))
                        {
                            sameFlg = true;
                            break;
                        }
                    }
                    // PM�̢�`�[�ԍ���Ŏd������ް��ɑ��݂��Ȃ��ꍇ
                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        //dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = strSlipNoA; //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // �d����̢�`�[�ԍ����PM���ް��ɑ��݂��Ȃ��ꍇ
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (stockSlipTextData.IsChecked)
                    {
                        continue;
                    }
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    sameFlg = false;
                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        if (stockSlipTextData.IsChecked)
                        {
                            break;
                        }
                        //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        if (strSlipNoA.Equals(strSlipNoB))
                        {
                            sameFlg = true;
                            break;
                        }
                    }
                    // �d����̢�`�[�ԍ����PM���ް��ɑ��݂��Ȃ��ꍇ
                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
               
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");

                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // PM�Ǝd����̢�`�[�ԍ���͈�v���Ă��邪�`�[���z����v�̏ꍇ
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    else
                    {
                        //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strPriceA = stockSlipResultWork.StockTotalPrice;

                        foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                        {
                            if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                            {
                                break;
                            }

                            if (stockSlipTextData.IsChecked)
                            {
                                continue;
                            }
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strPriceB = stockSlipTextData.StockPrice;
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    // DEL 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j------->>>>>>>>>
                                //if (!strPriceA.Equals(strPriceB))
                                //{
                                //    stockSlipTextData.IsChecked = true;
                                //    stockSlipResultWork.UoeRemark2 = "checked";
                                //    DataRow dr;
                                //    dr = _stockSlipDt.NewRow();
                                //    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //    if (stockSlipResultWork.WayToOrder == 2)
                                //    {
                                //        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //    }

                                //    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //    dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                //    dr[PMKOU02055EA.ct_Col_CheckContent] = "�`�[���z�s��v";
                                //    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //    this._stockSlipDt.Rows.Add(dr);

                                //}
                                //else
                                //{
                                    // DEL 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<<<<<<<<
                                    stockSlipTextData.IsChecked = true;
                                    stockSlipResultWork.UoeRemark2 = "checked";
                                    DataRow dr;
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    if (stockSlipResultWork.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }

                                    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[�Ƃo�l�`�[������A��v����";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                                    this._stockSlipDt.Rows.Add(dr);
                                }
                            }
                        }
                    }
                }

                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j----->>>>>>>>>
                // PM�Ǝd����̢�`�[�ԍ���͈�v���Ă��邪�`�[���z���s��v�̏ꍇ
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    else
                    {
                        //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strPriceA = stockSlipResultWork.StockTotalPrice;

                        foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                        {
                            if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                            {
                                break;
                            }

                            if (stockSlipTextData.IsChecked)
                            {
                                continue;
                            }
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strPriceB = stockSlipTextData.StockPrice;
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (!strPriceA.Equals(strPriceB))
                                {
                                    stockSlipTextData.IsChecked = true;
                                    stockSlipResultWork.UoeRemark2 = "checked";
                                    DataRow dr;
                                    dr = _stockSlipDt.NewRow();
                                    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    if (stockSlipResultWork.WayToOrder == 2)
                                    {
                                        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    }

                                    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                    dr[PMKOU02055EA.ct_Col_CheckContent] = "�`�[���z�s��v";
                                    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    this._stockSlipDt.Rows.Add(dr);

                                }
                              
                            }
                        }
                    }
                }
                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<<<<<<<<

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("unchecked"))
                    {
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (!stockSlipTextData.IsChecked)
                    {
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
                
            }

            // �d�����`�F�b�N�́u����v�A���_�`�F�b�N�́u�Ȃ��v�̏ꍇ
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    //  PM�Ǝd����̢�`�[�ԍ�+���t+�`�[���z��͈�v
                                    if (strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[�Ƃo�l�`�[������A��v����";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                    // DEL 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j----->>>>>>>>>
                                    // PM�Ǝd����̢�`�[�ԍ�+�`�[���z��͈�v���Ă��邪���t���s��v�̏ꍇ
                                    //else
                                    //{
                                    //    stockSlipTextData.IsChecked = true;
                                    //    stockSlipResultWork.UoeRemark2 = "checked";
                                    //    DataRow dr;
                                    //    dr = _stockSlipDt.NewRow();
                                    //    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    //    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    //    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    //    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    //    if (stockSlipResultWork.WayToOrder == 2)
                                    //    {
                                    //        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    //    }

                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    //    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    //    dr[PMKOU02055EA.ct_Col_errDiv] = 4;
                                    //    dr[PMKOU02055EA.ct_Col_CheckContent] = "���t�s��v";
                                    //    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    //    this._stockSlipDt.Rows.Add(dr);
                                    //}
                                }
                                //else
                                //{
                                //    // PM�Ǝd����̢���t+�`�[�ԍ���͈�v���Ă��邪�`�[���z���s��v�̏ꍇ
                                //    if (strDateA.Equals(strDateB))
                                //    {
                                //        stockSlipTextData.IsChecked = true;
                                //        stockSlipResultWork.UoeRemark2 = "checked";
                                //        DataRow dr;
                                //        dr = _stockSlipDt.NewRow();
                                //        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //        if (stockSlipResultWork.WayToOrder == 2)
                                //        {
                                //            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //        }

                                //        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                //        dr[PMKOU02055EA.ct_Col_CheckContent] = "�`�[���z�s��v";
                                //        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //        this._stockSlipDt.Rows.Add(dr);
                                //    }
                                //    // PM�Ǝd����̢�`�[�ԍ���͈�v���Ă��邪�`�[���z�Ɠ��t���s��v�̏ꍇ
                                //    else
                                //    {
                                //        stockSlipTextData.IsChecked = true;
                                //        stockSlipResultWork.UoeRemark2 = "checked";
                                //        DataRow dr;
                                //        dr = _stockSlipDt.NewRow();
                                //        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //        if (stockSlipResultWork.WayToOrder == 2)
                                //        {
                                //            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //        }

                                //        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //        dr[PMKOU02055EA.ct_Col_errDiv] = 5;
                                //        dr[PMKOU02055EA.ct_Col_CheckContent] = "���z����t�s��v";
                                //        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //        this._stockSlipDt.Rows.Add(dr);
                                //    }
                                //}
                                // DEL 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<<
                            }
                        }
                    }
                }

                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j----->>>>>>>>>
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (!strPriceA.Equals(strPriceB))
                                {
                                    // PM�Ǝd����̢�`�[�ԍ���͈�v���Ă��邪�`�[���z�Ɠ��t���s��v�̏ꍇ
                                    if (!strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 5;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "���z����t�s��v";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    // PM�Ǝd����̢�`�[�ԍ�+�`�[���z��͈�v���Ă��邪���t���s��v�̏ꍇ
                                    if (!strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 4;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "���t�s��v";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);  //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                if (strDateA.Equals(strDateB))
                                {
                                    // PM�Ǝd����̢���t+�`�[�ԍ���͈�v���Ă��邪�`�[���z���s��v�̏ꍇ
                                    if (!strPriceA.Equals(strPriceB)) 
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�`�[���z�s��v";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    } 
                                }
                            }
                        }
                    }
                }

                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<<<<<<

                // PM�̢���t+�`�[�ԍ���Ŏd������ް��ɑ��݂��Ȃ��ꍇ
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    //strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    sameFlg = false;
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        strSlipNoB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd")
                            //+ SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                                 + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�

                        if (strSlipNoA.Equals(strSlipNoB))
                        {
                            sameFlg = true;
                            break;
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // �d����̢���t+�`�[�ԍ����PM���ް��ɑ��݂��Ȃ��ꍇ
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (stockSlipTextData.IsChecked)
                    {
                        continue;
                    }
                    strSlipNoA = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd")
                        //+ SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�

                    sameFlg = false;
                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        if (stockSlipTextData.IsChecked)
                        {
                            break;
                        }
                        else
                        {
                            //strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            if (strSlipNoA.Equals(strSlipNoB))
                            {
                                sameFlg = true;
                                break;
                            }
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("unchecked"))
                    {
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (!stockSlipTextData.IsChecked)
                    {
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // �d�����`�F�b�N�́u�Ȃ��v�A���_�`�F�b�N�́u����v�̏ꍇ
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("None"))
            {
                // PM�̢���_����+�`�[�ԍ���Ŏd������ް��ɑ��݂��Ȃ��ꍇ
                
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    sameFlg = false;
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                        //strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSceCdB = stockSlipTextData.StockSectionCd.Trim();
                        
                        if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                        {
                            sameFlg = true;
                            break;
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // �d����̢���_����+�`�[�ԍ����PM���ް��ɑ��݂��Ȃ��ꍇ
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (stockSlipTextData.IsChecked)
                    {
                        continue;
                    }
                    //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                    //strSlipNoA = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSceCdA = stockSlipTextData.StockSectionCd.Trim();

                    sameFlg = false;
                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        if (stockSlipTextData.IsChecked)
                        {
                            break;
                        }
                        else
                        {
                            //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                            //strSlipNoB = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSceCdB = stockSlipResultWork.StockAddUpSectionCd.Trim();

                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdA, strSceCdB))
                            {
                                sameFlg = true;
                                break;
                            }
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // PM�Ǝd����̢���_����+�`�[�ԍ���͈�v���Ă��邪�`�[���z����v�̏ꍇ
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    else
                    {
                        //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                        //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);  //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();
                        strPriceA = stockSlipResultWork.StockTotalPrice;

                        foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                        {
                            if (stockSlipTextData.IsChecked)
                            {
                                continue;
                            }
                            if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                            {
                                break;
                            }
                            else
                            {
                                //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                                //strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                                //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                                strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                                strSceCdB = stockSlipTextData.StockSectionCd.Trim();
                                strPriceB = stockSlipTextData.StockPrice;
                                if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                                {
                                    if (strPriceA.Equals(strPriceB))
                                    {
                                        // DEL 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j----->>>>>>>>>
                                    //if (!strPriceA.Equals(strPriceB))
                                    //{
                                    //    stockSlipTextData.IsChecked = true;
                                    //    stockSlipResultWork.UoeRemark2 = "checked";
                                    //    DataRow dr;
                                    //    dr = _stockSlipDt.NewRow();
                                    //    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    //    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    //    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    //    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    //    if (stockSlipResultWork.WayToOrder == 2)
                                    //    {
                                    //        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    //    }

                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    //    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    //    dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                    //    dr[PMKOU02055EA.ct_Col_CheckContent] = "�`�[���z�s��v";
                                    //    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    //    this._stockSlipDt.Rows.Add(dr);

                                    //}
                                    //else
                                    //{
                                        // DEL 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<<<<<<<
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[�Ƃo�l�`�[������A��v����";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }

                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j----->>>>>>>>>
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    else
                    {
                        //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                        //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();
                        strPriceA = stockSlipResultWork.StockTotalPrice;

                        foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                        {
                            if (stockSlipTextData.IsChecked)
                            {
                                continue;
                            }
                            if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                            {
                                break;
                            }
                            else
                            {
                                //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                                //strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                                //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                                strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                                strSceCdB = stockSlipTextData.StockSectionCd.Trim();
                                strPriceB = stockSlipTextData.StockPrice;
                                if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                                {
                                    if (!strPriceA.Equals(strPriceB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�`�[���z�s��v";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);

                                    }
                                   
                                }
                            }
                        }
                    }
                }
                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<<<<


                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("unchecked"))
                    {
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (!stockSlipTextData.IsChecked)
                    {
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

            }

            // �d�����`�F�b�N�́u����v�A���_�`�F�b�N�́u����v�̏ꍇ
            if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check")
                     && stockSlipCndtn.SupDayCheckDiv.ToString().Equals("Check"))
            {
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                            // strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSceCdB = stockSlipTextData.StockSectionCd.Trim();

                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    //  PM�Ǝd����̢�`�[�ԍ�+���_����+���t+�`�[���z��͈�v
                                    if (strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 0;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[�Ƃo�l�`�[������A��v����";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Same";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                    // DEL 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j----->>>>>>>>>
                                    // PM�Ǝd����̢�`�[�ԍ�+���_����+�`�[���z��͈�v���Ă��邪���t���s��v�̏ꍇ
                                    //else
                                    //{
                                    //    stockSlipTextData.IsChecked = true;
                                    //    stockSlipResultWork.UoeRemark2 = "checked";
                                    //    DataRow dr;
                                    //    dr = _stockSlipDt.NewRow();
                                    //    dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                    //    dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                    //    dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                    //    dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                    //    dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                    //    if (stockSlipResultWork.WayToOrder == 2)
                                    //    {
                                    //        dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                    //    }

                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                    //    dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                    //    dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                    //    dr[PMKOU02055EA.ct_Col_errDiv] = 4;
                                    //    dr[PMKOU02055EA.ct_Col_CheckContent] = "���t�s��v";
                                    //    dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                    //    this._stockSlipDt.Rows.Add(dr);
                                    //}
                                }
                                //else
                                //{
                                //    // PM�Ǝd����̢���t+���_����+�`�[�ԍ���͈�v���Ă��邪�`�[���z���s��v�̏ꍇ
                                //    if (strDateA.Equals(strDateB))
                                //    {
                                //        stockSlipTextData.IsChecked = true;
                                //        stockSlipResultWork.UoeRemark2 = "checked";
                                //        DataRow dr;
                                //        dr = _stockSlipDt.NewRow();
                                //        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //        if (stockSlipResultWork.WayToOrder == 2)
                                //        {
                                //            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //        }

                                //        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                //        dr[PMKOU02055EA.ct_Col_CheckContent] = "�`�[���z�s��v";
                                //        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //        this._stockSlipDt.Rows.Add(dr);
                                //    }
                                //    // PM�Ǝd����̢�`�[�ԍ�+���_���ޣ�͈�v���Ă��邪�`�[���z�Ɠ��t���s��v�̏ꍇ
                                //    else
                                //    {
                                //        stockSlipTextData.IsChecked = true;
                                //        stockSlipResultWork.UoeRemark2 = "checked";
                                //        DataRow dr;
                                //        dr = _stockSlipDt.NewRow();
                                //        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                //        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                //        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                //        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                //        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                //        if (stockSlipResultWork.WayToOrder == 2)
                                //        {
                                //            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                //        }

                                //        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                //        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                //        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                //        dr[PMKOU02055EA.ct_Col_errDiv] = 5;
                                //        dr[PMKOU02055EA.ct_Col_CheckContent] = "���z����t�s��v";
                                //        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                //        this._stockSlipDt.Rows.Add(dr);
                                //    }
                                //}
                                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<<<<<
                            }
                        }
                    }
                }


                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j----->>>>>>>>>
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                            // strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSceCdB = stockSlipTextData.StockSectionCd.Trim();

                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                            {
                                if (!strPriceA.Equals(strPriceB))
                                {
                                    //  PM�Ǝd����̢�`�[�ԍ�+���_����+���t+�`�[���z��͈�v
                                    if (!strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 5;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "���z����t�s��v";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                            // strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSceCdB = stockSlipTextData.StockSectionCd.Trim();

                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                            {
                                if (strPriceA.Equals(strPriceB))
                                {
                                    // // PM�Ǝd����̢�`�[�ԍ�+���_����+�`�[���z��͈�v���Ă��邪���t���s��v�̏ꍇ
                                    if (!strDateA.Equals(strDateB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 4;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "���t�s��v";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                    
                                }
                            }
                        }
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                    //strSlipNoA = stockSlipResultWork.StockAddUpSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    strPriceA = stockSlipResultWork.StockTotalPrice;
                    strDateA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        else
                        {
                            //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                            // strSlipNoB = stockSlipTextData.StockSectionCd + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                            //strSlipNoB = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSceCdB = stockSlipTextData.StockSectionCd.Trim();

                            strPriceB = stockSlipTextData.StockPrice;
                            strDateB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                            {
                                if (strDateA.Equals(strDateB))
                                {
                                    // PM�Ǝd����̢���t+���_����+�`�[�ԍ���͈�v���Ă��邪�`�[���z���s��v�̏ꍇ
                                    if (!strPriceA.Equals(strPriceB))
                                    {
                                        stockSlipTextData.IsChecked = true;
                                        stockSlipResultWork.UoeRemark2 = "checked";
                                        DataRow dr;
                                        dr = _stockSlipDt.NewRow();
                                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                                        if (stockSlipResultWork.WayToOrder == 2)
                                        {
                                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                                        }

                                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                                        dr[PMKOU02055EA.ct_Col_errDiv] = 3;
                                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�`�[���z�s��v";
                                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                                        this._stockSlipDt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                    }
                }
                // ADD 20090807 ���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j-----<<<<<<<<<<

                // PM�̢���t+���_����+�`�[�ԍ���Ŏd������ް��ɑ��݂��Ȃ��ꍇ
                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                    {
                        continue;
                    }
                    //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                    //strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") +stockSlipResultWork.StockAddUpSectionCd 
                    //              + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                    //strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSceCdA = stockSlipResultWork.StockAddUpSectionCd.Trim();

                    sameFlg = false;
                    foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                    {
                        if (stockSlipTextData.IsChecked)
                        {
                            continue;
                        }
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            break;
                        }
                        //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                        //strSlipNoB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") +SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSlipNoB = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                        strSceCdB = stockSlipTextData.StockSectionCd.Trim();
                        if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdB, strSceCdA))
                        {
                            sameFlg = true;
                            break;
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                // �d����̢���t+���_����+�`�[�ԍ����PM���ް��ɑ��݂��Ȃ��ꍇ
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (stockSlipTextData.IsChecked)
                    {
                        continue;
                    }
                    //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                    //strSlipNoA = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") +stockSlipTextData.StockSectionCd 
                    //    + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                    //strSlipNoA = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSlipNoA = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipTextData.SupplierSlipNo); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                    strSceCdA = stockSlipTextData.StockSectionCd.Trim();
                    sameFlg = false;
                    foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                    {
                        if (stockSlipResultWork.UoeRemark2.Equals("checked"))
                        {
                            continue;
                        }
                        if (stockSlipTextData.IsChecked)
                        {
                            break;
                        }
                        else
                        {
                            //�@UPD�@20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
                            //strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") +stockSlipResultWork.StockAddUpSectionCd 
                            //      + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                            //strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //DEL BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSlipNoB = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd") + SuppSlipNoSubStrForCheck(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum); //ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�
                            strSceCdB = stockSlipResultWork.StockAddUpSectionCd.Trim();
                            if (strSlipNoA.Equals(strSlipNoB) && CheckSectionCd(strSceCdA, strSceCdB))
                            {
                                sameFlg = true;
                                break;
                            }
                        }
                    }

                    if (!sameFlg)
                    {
                        sameFlg = false;
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }

                foreach (StockSlipResultWork stockSlipResultWork in resultWork)
                {
                    if (stockSlipResultWork.UoeRemark2.Equals("unchecked"))
                    {
                        stockSlipResultWork.UoeRemark2 = "checked";
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = stockSlipResultWork.StockDate.ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipResultWork.PartySaleSlipNum);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipResultWork.StockAddUpSectionCdPm;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNo] = stockSlipResultWork.SupplierSlipNo;
                        dr[PMKOU02055EA.ct_Col_StockDate] = stockSlipResultWork.StockDate;
                        dr[PMKOU02055EA.ct_Col_StockTotalPrice] = stockSlipResultWork.StockTotalPrice;
                        dr[PMKOU02055EA.ct_Col_SupplierSlipNote1] = stockSlipResultWork.SupplierSlipNote1;
                        if (stockSlipResultWork.WayToOrder == 2)
                        {
                            dr[PMKOU02055EA.ct_Col_UoeRemark1] = "*";
                        }
                        dr[PMKOU02055EA.ct_Col_errDiv] = 1;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�d����`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "CSV";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
                foreach (StockSlipTextData stockSlipTextData in csvDataWork)
                {
                    if (!stockSlipTextData.IsChecked)
                    {
                        stockSlipTextData.IsChecked = true;
                        DataRow dr;
                        dr = _stockSlipDt.NewRow();
                        dr[PMKOU02055EA.ct_Col_ArrivalGoodsDay] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_PartySaleSlipNum] = SuppSlipNoSubStr(stockSlipCndtn, stockSlipTextData.SupplierSlipNo);
                        dr[PMKOU02055EA.ct_Col_SectionCode] = stockSlipTextData.StockSectionCd;

                        dr[PMKOU02055EA.ct_Col_Csv_StockDate] = DateTime.ParseExact(stockSlipTextData.StockDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
                        dr[PMKOU02055EA.ct_Col_Csv_StockTotalPrice] = stockSlipTextData.StockPrice;
                        dr[PMKOU02055EA.ct_Col_Csv_SupplierSlipNote] = stockSlipTextData.Note;
                        dr[PMKOU02055EA.ct_Col_errDiv] = 2;
                        dr[PMKOU02055EA.ct_Col_CheckContent] = "�o�l�`�[����";
                        dr[PMKOU02055EA.ct_Col_printDiv] = "Different";
                        dr[PMKOU02055EA.ct_Col_isNotShow] = "PM";
                        this._stockSlipDt.Rows.Add(dr);
                    }
                }
            }

            // ��v��PM�f�[�^�̋��z���v
            long samePricePM = 0;
            // �s��v��PM�f�[�^�̋��z���v
            long diffPricePM = 0;
            // PM�f�[�^�̋��z�����v
            long totalPricePM = 0;
            // ��v��CSV�f�[�^�̋��z�����v
            long samePriceCSV = 0;
            // �s��v��CSV�f�[�^�̋��z���v
            long diffPriceCSV = 0;
            // CSV�f�[�^�̋��z�����v
            long totalPriceCSV = 0;
            for (int i = 0; i < _stockSlipDt.Rows.Count;i++ )
            {
                if (_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_printDiv].Equals("Same"))
                {
                    samePricePM += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_StockTotalPrice];
                    samePriceCSV += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_Csv_StockTotalPrice];
                }
                if (_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_printDiv].Equals("Different"))
                {
                    diffPricePM += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_StockTotalPrice];
                    diffPriceCSV += (long)_stockSlipDt.Rows[i][PMKOU02055EA.ct_Col_Csv_StockTotalPrice];
                }
            }
            totalPricePM = samePricePM + diffPricePM;
            totalPriceCSV = samePriceCSV + diffPriceCSV;
            stockSlipCndtn.SamePmPrice = samePricePM;
            stockSlipCndtn.SameCsvPrice = samePriceCSV;
            stockSlipCndtn.DiffPmPrice = diffPricePM;
            stockSlipCndtn.DiffCsvPrice = diffPriceCSV;
            stockSlipCndtn.TotalPmPrice = totalPricePM;
            stockSlipCndtn.TotalCsvPrice = totalPriceCSV;


            // �t�B���^����
            string filter = "";
            if (stockSlipCndtn.PrintDiv.ToString().Equals("Different"))
            {
                filter = string.Format("{0} = '{1}'", PMKOU02055EA.ct_Col_printDiv, "Different");
            }
            else if (stockSlipCndtn.PrintDiv.ToString().Equals("Same"))
            {
                filter = string.Format("{0} = '{1}'", PMKOU02055EA.ct_Col_printDiv, "Same");
            }
            string myFilter = string.Format("{0} = '{1}'", PMKOU02055EA.ct_Col_printDiv, "Same");


            DataView myView = new DataView(this._stockSlipDt, myFilter, "", DataViewRowState.CurrentRows);

            if(myView.Count == 0)
            {
                stockSlipCndtn.SameFlg = true;
            }
            if(myView.Count == _stockSlipDt.Rows.Count)
            {
                stockSlipCndtn.DiffFlg = true;
            }
            
            // DataView�쐬
            this._stockSlipView = new DataView(this._stockSlipDt, filter, GetSortOrder(stockSlipCndtn), DataViewRowState.CurrentRows);
        }

        /// <summary>
        /// �`�[�ԍ��̎擾����
        /// </summary>
        /// <param name="stockSlipCndtn">���o����</param>
        /// <param name="suppSlipNo">�`�[�ԍ�</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��̎擾�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string SuppSlipNoSubStr(StockSlipCndtn stockSlipCndtn,string suppSlipNo)
        {
            string slipNum = suppSlipNo;
            // ��U���̂݁F�����`�[�ԍ��̏ォ��U���݂̂��擾
            if (stockSlipCndtn.SlipNumCheckDiv.ToString().Equals("First6"))
            {
                if (suppSlipNo.Length > 6)
                {
                    slipNum = suppSlipNo.Substring(0,6);
                }
            }
            // ���U���̂݁@�F�����`�[�ԍ��̉�����U���݂̂��擾
            if (stockSlipCndtn.SlipNumCheckDiv.ToString().Equals("Last6"))
            {
                if (suppSlipNo.Length > 6)
                {
                    slipNum = suppSlipNo.Substring((suppSlipNo.Length-6), 6);
                }
            }

            return slipNum;
        }

        // ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή� ---->>>>
        /// <summary>
        /// �`�F�b�N��p�̓`�[�ԍ��擾����
        /// </summary>
        /// <param name="stockSlipCndtn">���o����</param>
        /// <param name="suppSlipNo">�`�[�ԍ�</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �`�F�b�N�p�`�[�ԍ��̎擾�������s���܂��B</br>
        /// <br>Programmer : wujun</br>
        /// <br>Date       : 2015/08/17</br>
        /// <br>Update Note: 2015/09/21 mamd</br>
        /// <br>�Ǘ��ԍ�   : 11170129-00</br>
        /// <br>           : Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�</br>
        /// <br>           : �`�[�ԍ����ڂɃX�y�[�X���Z�b�g����Ă���ꍇ�̕s��Ή�</br>
        /// </remarks>
        private string SuppSlipNoSubStrForCheck(StockSlipCndtn stockSlipCndtn, string suppSlipNo)
        {
            string slipNum = suppSlipNo;
            // ��U���̂݁F�����`�[�ԍ��̏ォ��U���݂̂��擾
            if (stockSlipCndtn.SlipNumCheckDiv.ToString().Equals("First6"))
            {
                if (suppSlipNo.Length > 6)
                {
                    slipNum = suppSlipNo.Substring(0, 6);
                }
            }
            // ���U���̂݁@�F�����`�[�ԍ��̉�����U���݂̂��擾
            if (stockSlipCndtn.SlipNumCheckDiv.ToString().Equals("Last6"))
            {
                if (suppSlipNo.Length > 6)
                {
                    slipNum = suppSlipNo.Substring((suppSlipNo.Length - 6), 6);
                }
            }
            //DEL BY mamd 2015/09/21 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�----->>>>
            //if (IsDigitAddZero(slipNum))
            //{
            //    slipNum = Convert.ToInt32(slipNum).ToString();
            //}
            //DEL BY mamd 2015/09/21 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�----->>>>
            //ADD BY mamd 2015/09/21 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�----->>>>
            if (IsDigitAddZero(slipNum.Trim()))
            {
                slipNum = Convert.ToInt64(slipNum.Trim()).ToString();
            }
            else if (string.IsNullOrEmpty(slipNum.Trim()))
            {
                slipNum = "0";
            }
            //ADD BY mamd 2015/09/21 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή�----->>>>
            return slipNum;
        }

        /// <summary>
        /// ������+0���f
        /// </summary>
        /// <param name="val">�l</param>
        /// <returns>True:����; False:�񐔎�</returns>
        /// <remarks>
        /// <br>Note       : ������+0���f�������s���܂��B</br>
        /// <br>Programmer : wujun </br>
        /// <br>Date       : 2015/08/17</br>
        /// </remarks>
        private bool IsDigitAddZero(string val)
        {
            string regex1 = "^\\d+$";
            Regex objRegex = new Regex(regex1);
            if (!objRegex.IsMatch(val))
            {
                return false;
            }
            return true;
        }
        // ADD BY wujun 2015/08/17 FOR Redmine47047 �y��845�zUOE�d���`�F�b�N�̏�Q�Ή� ----<<<<



        /// <summary>
        /// ���_�f�[�^�̃`�F�b�N����
        /// </summary>
        /// <param name="sectionCdCSV">�e�L�X�g�̋��_�R�[�h</param>
        /// <param name="SectionCdPM">PM�̋��_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���_�f�[�^�̃`�F�b�N</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.08.07</br>
        /// </remarks>
        private bool CheckSectionCd(string sectionCdCSV , string SectionCdPM)
        {
            //ADD 20090807�@���仁@�������`�F�b�N�����̎d�l��ǋL�i��{�d�l���̉���No14�j
            bool status = false;
            for (int i = 0; i < codeListPM.Count;i++ )
            {
                if (SectionCdPM.Equals(codeListPM[i].ToString().Trim()))
                {
                    if (sectionCdCSV.Equals(codeListCSV[i].ToString().Trim()))
                    {
                        status = true;
                        break;
                    }
                }
            }

            return status;
        }

         #region �� �\�[�g���쐬
        /// <summary>
        /// �\�[�g���쐬
        /// </summary>
        /// <param name="stockSlipCndtn">���o����</param>
        /// <returns>�\�[�g������</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��̎擾�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private string GetSortOrder(StockSlipCndtn stockSlipCndtn)
        {
            StringBuilder strSortOrder = new StringBuilder();
            if (stockSlipCndtn.CheckSectionDiv.ToString().Equals("PMSupplier"))
            {
                // ���_�`�F�b�N�u����v�FPM�d�����A�G���[�敪�APM�`�[�ԍ��A���_��
                if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("Check"))
                {
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_printDiv));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_ArrivalGoodsDay));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_errDiv));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_PartySaleSlipNum));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_SectionCode));
                    strSortOrder.Append(string.Format("{0} ASC ", PMKOU02055EA.ct_Col_SupplierSlipNo));
                }
                // ���_�`�F�b�N�u�Ȃ��v�FPM�d�����A�G���[�敪�APM�`�[�ԍ���
                else if (stockSlipCndtn.SectionCdCheckDiv.ToString().Equals("None"))
                {
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_printDiv));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_ArrivalGoodsDay));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_errDiv));
                    strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_PartySaleSlipNum));
                    strSortOrder.Append(string.Format("{0} ASC ", PMKOU02055EA.ct_Col_SupplierSlipNo));
                }
            }
            else
            {
                // ADD 20090807 ���仁@�d���f�[�^�`�F�b�N�̏ꍇ�A������̏C���i��{�d�l���̉���No15�j
                // PM�`�[�ԍ��APM�d�����A���_��
                strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_printDiv));
                strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_PartySaleSlipNum));
                strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_ArrivalGoodsDay));
                strSortOrder.Append(string.Format("{0} ASC,", PMKOU02055EA.ct_Col_SectionCode));
                strSortOrder.Append(string.Format("{0} ASC ", PMKOU02055EA.ct_Col_SupplierSlipNo));
            }
            

            return strSortOrder.ToString();
        }

        /// <summary>
        /// PM�f�[�^�\�[�g������
        /// </summary>
        /// <remarks>
        /// <br>Note       : CSV�f�[�^�\�[�g���������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private class PMDatatoComparer : IComparer<StockSlipResultWork>
        {
            public int Compare(StockSlipResultWork x, StockSlipResultWork y)
            {
                int ret = ComparerHelper.CompareObject(x.StockDate, y.StockDate);
                if (ret == 0)
                {
                    ret = ComparerHelper.CompareObject(x.PartySaleSlipNum, y.PartySaleSlipNum);

                    if (ret == 0)
                    {
                        ret = ComparerHelper.CompareObject(x.StockAddUpSectionCdPm, y.StockAddUpSectionCdPm);

                        if (ret == 0)
                        {
                            ret = ComparerHelper.CompareObject(x.SupplierSlipNo, y.SupplierSlipNo);
                        }
                    }
                }
                return ret;
            }
        }

        /// <summary>
        /// CSV�f�[�^�\�[�g������
        /// </summary>
        /// <remarks>
        /// <br>Note       : CSV�f�[�^�\�[�g���������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private class CsvDatatoComparer : IComparer<StockSlipTextData>
        {
            public int Compare(StockSlipTextData x, StockSlipTextData y)
            {
                int ret = ComparerHelper.CompareObject(x.StockDate, y.StockDate);
                if (ret == 0)
                {
                    ret = ComparerHelper.CompareObject(x.SupplierSlipNo, y.SupplierSlipNo);

                    if (ret == 0)
                    {
                        ret = ComparerHelper.CompareObject(x.StockSectionCd, y.StockSectionCd);
                    }
                }
                return ret;
            }
        }
        /// <summary>
        /// Comparer����
        /// </summary>
        /// <remarks>
        /// <br>Note       : Comparer�������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        private class ComparerHelper
        {
            public static int CompareObject(object val1, object val2)
            {
                if (val1 == null && val2 == null)
                {
                    return 0;
                }
                else if (val1 != null && val2 != null)
                {
                    return val1.ToString().CompareTo(val2.ToString());
                }
                else if (val1 != null && val2 == null)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        #endregion

        #endregion �� Private Method


    }
}
