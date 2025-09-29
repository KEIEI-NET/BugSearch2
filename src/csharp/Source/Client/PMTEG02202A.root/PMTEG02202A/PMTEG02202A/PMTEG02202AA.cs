//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ψꗗ�\�A�N�Z�X�N���X
// �v���O�����T�v   : ��`���ψꗗ�\�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ��`���ψꗗ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ψꗗ�\�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class TegataKessaiReportAcs
    {
        #region �� Constructor
		/// <summary>
		/// ��`���ψꗗ�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��`���ψꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public TegataKessaiReportAcs()
		{
            this._iTegataKessaiReportResultDB = (ITegataKessaiReportResultDB)MediationTegataKessaiReportResultDB.GetTegataKessaiReportResultDB();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
		}
        #endregion �� Constructor

        #region �� Private Member
        // ��`���ψꗗ�\�����C���^�t�F�[�X
        ITegataKessaiReportResultDB _iTegataKessaiReportResultDB;

        // DataSet�I�u�W�F�N�g
        private DataSet _dataSet;

        //���t�擾���i
        private DateGetAcs _dateGet;

        #endregion �� Private Member

        #region �� Public Property
        /// <summary>
        /// �f�[�^�Z�b�g(�ǂݎ���p)
        /// </summary>
        public DataSet DataSet
        {
            get { return this._dataSet; }
        }
        #endregion �� Public Property

        #region �� Public Method
        #region �� �o�̓f�[�^�擾
        #region �� ��`���ψꗗ�\�f�[�^�擾
        /// <summary>
        /// ��`���ψꗗ�\�f�[�^�擾
        /// </summary>
        /// <param name="tegataKessaiReport">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`���ψꗗ�\�f�[�^���擾����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public int SearchTegataKessaiReportProcMain(TegataKessaiReport tegataKessaiReport, out string errMsg)
        {
            return this.SearchTegataKessaiReportProc(tegataKessaiReport, out errMsg);
        }
        #endregion
        #endregion �� �o�̓f�[�^�擾
        #endregion �� Public Method

        #region �� Private Method
        #region �� ���[�f�[�^�擾
        #region �� �f�[�^�擾
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <param name="tegataKessaiReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`���ψꗗ�\�f�[�^���擾����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SearchTegataKessaiReportProc(TegataKessaiReport tegataKessaiReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02205EA.CreateDataTable(ref _dataSet);

                // ���o�����W�J  --------------------------------------------------------------
                TegataKessaiReportParaWork tegataKessaiReportparaWork = new TegataKessaiReportParaWork();
                // ��ʌ������->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataKessaiReport, out tegataKessaiReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataKessaiReportparaWork;
                status = _iTegataKessaiReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02205EA.ct_Tbl_TegataKessaiReportData], (ArrayList)retList, tegataKessaiReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02205EA.ct_Tbl_TegataKessaiReportData].Rows.Count < 1)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        errMsg = "��`���ψꗗ�\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
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
        #region �� ���o�����W�J����
        /// <summary>
        /// ���o�����W�J����
        /// </summary>
        /// <param name="tegataKessaiReport">UI���o�����N���X</param>
        /// <param name="tegataKessaiReportParaWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s��</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SetCondInfo(ref TegataKessaiReport tegataKessaiReport, out TegataKessaiReportParaWork tegataKessaiReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataKessaiReportParaWork = new TegataKessaiReportParaWork();
            try
            {  
                // ��ƃR�[�h
                tegataKessaiReportParaWork.EnterpriseCode = tegataKessaiReport.EnterpriseCode;

                // ����/�x�����i�J�n�j
                tegataKessaiReportParaWork.DepositDateSt = tegataKessaiReport.DateSt;

                // ����/�x�����i�I���j
                tegataKessaiReportParaWork.DepositDateEd = tegataKessaiReport.DateEd;

                // �������i�J�n�j
                tegataKessaiReportParaWork.MaturityDateSt = tegataKessaiReport.MaturityDateSt;

                // �������i�I���j
                tegataKessaiReportParaWork.MaturityDateEd = tegataKessaiReport.MaturityDateEd;

                // ��`�敪
                tegataKessaiReportParaWork.DraftDivide = tegataKessaiReport.DraftDivide;

                // �\�[�g��
                tegataKessaiReportParaWork.SortOrder = tegataKessaiReport.SortOrder;

                // ��s/�x�X�J�n
                tegataKessaiReportParaWork.BankAndBranchCdSt = tegataKessaiReport.BankAndBranchCdSt;

                // ��s/�x�X�I��
                tegataKessaiReportParaWork.BankAndBranchCdEd = tegataKessaiReport.BankAndBranchCdEd;

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region �� �擾�f�[�^�W�J����
        /// <summary>
        /// DataTable�Ƀf�[�^��ݒ菈��
        /// </summary>
        /// <param name="dataTable">���[�pDataTable</param>
        /// <param name="retList">������񃊃X�g</param>
        /// <param name="paraWork">paraWork</param>
        /// <remarks>
        /// <br>Note       : DataTable�Ƀf�[�^��ݒ菈�����s��</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataKessaiReportParaWork paraWork)
        {

            DataRow dr = null;
            TegataKessaiReportResultWork rsltInfo = null;
            // �����R�[�h
            string customerCode = null;
            string bankAndBranchCd = null;
            string formatStr = null;
            // ����`
            if (paraWork.DraftDivide == 0)
            {
                formatStr = "D8";
            }
            // �x����`
            else
            {
                formatStr = "D6";
            }

            for (int i = 0; i < retList.Count; i++)
            {
                rsltInfo = (TegataKessaiReportResultWork)retList[i];
                customerCode = rsltInfo.CustomerCode.ToString(formatStr);
                bankAndBranchCd = rsltInfo.BankAndBranchCd.ToString("D7");

                dr = dataTable.NewRow();

                // ��`���
                dr[PMTEG02205EA.ct_Col_DraftKindCd] = rsltInfo.DraftKindCd;
                if (rsltInfo.DraftKindCd == 0)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "�莝��`";
                } 
                else if (rsltInfo.DraftKindCd == 1)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "�旧��`";
                } 
                else if (rsltInfo.DraftKindCd == 2)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "������`";
                }
                else if (rsltInfo.DraftKindCd == 3)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "���n��`";
                }
                else if (rsltInfo.DraftKindCd == 4)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "�S�ێ�`";
                }
                else if (rsltInfo.DraftKindCd == 5)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "�s�n��`";
                }
                else if (rsltInfo.DraftKindCd == 6)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "�x����`";
                }
                else if (rsltInfo.DraftKindCd == 7)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "��t��`";
                }
                else if (rsltInfo.DraftKindCd == 9)
                {
                    dr[PMTEG02205EA.ct_Col_DraftKindName] = "���ώ�`";
                }
             
                // ��s�x�X
                dr[PMTEG02205EA.ct_Col_BankAndBranchCd] = bankAndBranchCd;
                dr[PMTEG02205EA.ct_Col_BankAndBranchNm] = bankAndBranchCd.Substring(0, 4)
                    + "-" + bankAndBranchCd.Substring(4, 3) + " " + rsltInfo.BankAndBranchNm;

                // ����/�x����
                if (DateTime.MinValue != rsltInfo.DepositDate)
                {
                    dr[PMTEG02205EA.ct_Col_Date] = rsltInfo.DepositDate.ToString("yyyy/MM/dd");
                }
                // �U�o��
                if (DateTime.MinValue != rsltInfo.DraftDrawingDate)
                { 
                    dr[PMTEG02205EA.ct_Col_DraftDrawingDate] = rsltInfo.DraftDrawingDate.ToString("yyyy/MM/dd");
                }
                
                // ������
                if (0 != rsltInfo.ValidityTerm)
                {
                    DateTime dateTime = new DateTime(
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(0, 4)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(4, 2)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(6, 2)));
                    dr[PMTEG02205EA.ct_Col_ValidityTerm] = dateTime.ToString("yyyy/MM/dd");
                    dr[PMTEG02205EA.ct_Col_ValidityTermForGroup] = dateTime.ToString("yyyy/MM/dd");
                }

                // ������ 0=���U�A1=���U
                dr[PMTEG02205EA.ct_Col_DraftDivide] = rsltInfo.DraftDivide == 0 ? "���U" : "���U";

                // ��`�ԍ�
                dr[PMTEG02205EA.ct_Col_DraftNo] = rsltInfo.RcvDraftNo;

                // ����於��
                dr[PMTEG02205EA.ct_Col_CustomerSnm] = rsltInfo.CustomerSnm;

                // �����R�[�h
                dr[PMTEG02205EA.ct_Col_CustomerCode] = rsltInfo.AddUpSecCode.Trim().PadLeft(2, '0')
                    + "-" + customerCode;
                // ���z
                dr[PMTEG02205EA.ct_Col_Amount] = rsltInfo.Deposit;
                // �E�v�P
                dr[PMTEG02205EA.ct_Col_Outline1] = rsltInfo.Outline1;
                // �E�v2
                dr[PMTEG02205EA.ct_Col_Outline2] = rsltInfo.Outline2;

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion �� �f�[�^�W�J����

        #endregion �� Private Method
    }
}
