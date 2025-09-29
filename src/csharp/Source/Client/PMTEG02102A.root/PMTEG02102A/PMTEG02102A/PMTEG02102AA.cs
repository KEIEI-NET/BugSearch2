//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ו\�A�N�Z�X�N���X
// �v���O�����T�v   : ��`���ו\�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/04/28  �C�����e : �V�K�쐬
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
    /// ��`���ו\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`���ו\�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010.04.28</br>
    /// </remarks>
    public class TegataMeisaiListReportAcs
    {
        #region �� Constructor
		/// <summary>
		/// ��`���ו\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��`���ו\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        public TegataMeisaiListReportAcs()
		{
            this._iTegataMeisaiListReportResultDB = (ITegataMeisaiListReportResultDB)MediationTegataMeisaiListReportResultDB.GetTegataMeisaiListReportResultDB();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
		}
        #endregion �� Constructor

        #region �� Private Member
        // ��`���ו\�����C���^�t�F�[�X
        ITegataMeisaiListReportResultDB _iTegataMeisaiListReportResultDB;

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
        #region �� ��`���ו\�f�[�^�擾
        /// <summary>
        /// ��`���ו\�f�[�^�擾
        /// </summary>
        /// <param name="tegataMeisaiListReport">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`���ו\�f�[�^���擾����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        public int SearchTegataMeisaiListReportProcMain(TegataMeisaiListReport tegataMeisaiListReport, out string errMsg)
        {
            return this.SearchTegataMeisaiListReportProc(tegataMeisaiListReport, out errMsg);
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
        /// <param name="tegataMeisaiListReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`���ו\�f�[�^���擾����B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        private int SearchTegataMeisaiListReportProc(TegataMeisaiListReport tegataMeisaiListReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02105EA.CreateDataTable(ref _dataSet);

                // ���o�����W�J  --------------------------------------------------------------
                TegataMeisaiListReportParaWork tegataMeisaiListReportparaWork = new TegataMeisaiListReportParaWork();
                // ��ʌ������->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataMeisaiListReport, out tegataMeisaiListReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataMeisaiListReportparaWork;
                status = _iTegataMeisaiListReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02105EA.ct_Tbl_TegataMeisaiListReportData], (ArrayList)retList, tegataMeisaiListReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02105EA.ct_Tbl_TegataMeisaiListReportData].Rows.Count < 1)
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
                        errMsg = "��`���ו\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <param name="tegataMeisaiListReport">UI���o�����N���X</param>
        /// <param name="tegataMeisaiListReportParaWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s��</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date	   : 2010.04.28</br>
        /// </remarks>
        private int SetCondInfo(ref TegataMeisaiListReport tegataMeisaiListReport, out TegataMeisaiListReportParaWork tegataMeisaiListReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataMeisaiListReportParaWork = new TegataMeisaiListReportParaWork();
            try
            {  
                // ��ƃR�[�h
                tegataMeisaiListReportParaWork.EnterpriseCode = tegataMeisaiListReport.EnterpriseCode;

                // �������i�J�n�j
                tegataMeisaiListReportParaWork.DepositDateSt = tegataMeisaiListReport.DepositDateSt;

                // �������i�I���j
                tegataMeisaiListReportParaWork.DepositDateEd = tegataMeisaiListReport.DepositDateEd;

                // �������i�J�n�j
                tegataMeisaiListReportParaWork.MaturityDateSt = tegataMeisaiListReport.MaturityDateSt;

                // �������i�I���j
                tegataMeisaiListReportParaWork.MaturityDateEd = tegataMeisaiListReport.MaturityDateEd;

                // ��`�敪
                tegataMeisaiListReportParaWork.DraftDivide = tegataMeisaiListReport.DraftDivide;

                // ����
                tegataMeisaiListReportParaWork.ChangePageDiv = tegataMeisaiListReport.ChangePageDiv;

                // �\�[�g��
                tegataMeisaiListReportParaWork.SortOrder = tegataMeisaiListReport.SortOrder;

                // ��s/�x�X�J�n
                tegataMeisaiListReportParaWork.BankAndBranchCdSt = tegataMeisaiListReport.BankAndBranchCdSt;

                // ��s/�x�X�I��
                tegataMeisaiListReportParaWork.BankAndBranchCdEd = tegataMeisaiListReport.BankAndBranchCdEd;

                // ��`���
                if (tegataMeisaiListReport.DraftKindCds.Length != 0)
                {
                    tegataMeisaiListReportParaWork.DraftKindCds = tegataMeisaiListReport.DraftKindCds;
                }
                else
                {
                    tegataMeisaiListReportParaWork.DraftKindCds = null;
                }

                // ��`��ʖ���
                tegataMeisaiListReportParaWork.DraftKindCdsHt = tegataMeisaiListReport.DraftKindCdsHt;

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
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataMeisaiListReportParaWork paraWork)
        {

            DataRow dr = null;
            TegataMeisaiListReportResultWork rsltInfo = null;
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
                rsltInfo = (TegataMeisaiListReportResultWork)retList[i];
                customerCode = rsltInfo.CustomerCode.ToString(formatStr);
                bankAndBranchCd = rsltInfo.BankAndBranchCd.ToString("D7");

                dr = dataTable.NewRow();

                // ��`���
                dr[PMTEG02105EA.ct_Col_DraftKindCd] = rsltInfo.DraftKindCd;
                dr[PMTEG02105EA.ct_Col_DraftKindName] = (string)paraWork.DraftKindCdsHt[rsltInfo.DraftKindCd];
                // ��s�x�X
                dr[PMTEG02105EA.ct_Col_BankAndBranchCd] = bankAndBranchCd;
                dr[PMTEG02105EA.ct_Col_BankAndBranchNm] = bankAndBranchCd.Substring(0, 4)
                    + "-" + bankAndBranchCd.Substring(4, 3) + " " + rsltInfo.BankAndBranchNm;

                // �x����
                if (DateTime.MinValue != rsltInfo.DepositDate)
                {
                    dr[PMTEG02105EA.ct_Col_DepositDate] = rsltInfo.DepositDate.ToString("yyyy/MM/dd");
                }
                // �U�o��
                if (DateTime.MinValue != rsltInfo.DraftDrawingDate)
                { 
                    dr[PMTEG02105EA.ct_Col_DraftDrawingDate] = rsltInfo.DraftDrawingDate.ToString("yyyy/MM/dd");
                }
                
                // ������
                if (0 != rsltInfo.ValidityTerm)
                {
                    DateTime dateTime = new DateTime(
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(0, 4)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(4, 2)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(6, 2)));
                    dr[PMTEG02105EA.ct_Col_ValidityTerm] = dateTime.ToString("yyyy/MM/dd");
                    dr[PMTEG02105EA.ct_Col_ValidityTermForGroup] = dateTime.ToString("yyyy/MM/dd");
                    // �T�C�g �T�C�g�� �U�o�����疞�����܂ł̓������󎚂���B
                    if (DateTime.MinValue != rsltInfo.DraftDrawingDate)
                    {
                        dr[PMTEG02105EA.ct_Col_Site] = dateTime.Subtract(rsltInfo.DraftDrawingDate).Days;
                        
                    }
                }

                // ������ 0=���U�A1=���U
                dr[PMTEG02105EA.ct_Col_DraftDivide] = rsltInfo.DraftDivide == 0 ? "���U" : "���U";

                // ��`�ԍ�
                dr[PMTEG02105EA.ct_Col_RcvDraftNo] = rsltInfo.RcvDraftNo;

                // ����於�� �x����`�f�[�^�̌v�㋒�_�R�[�h�A�d����R�[�h�A�d���旪��
                dr[PMTEG02105EA.ct_Col_CustomerSnm] = rsltInfo.AddUpSecCode.Trim().PadLeft(2, '0')
                    + "-" + customerCode
                    + " " + rsltInfo.CustomerSnm;

                // ���z
                dr[PMTEG02105EA.ct_Col_Deposit] = rsltInfo.Deposit;
                // �E�v�P
                dr[PMTEG02105EA.ct_Col_Outline1] = rsltInfo.Outline1;
                // �E�v2
                dr[PMTEG02105EA.ct_Col_Outline2] = rsltInfo.Outline2;

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion �� �f�[�^�W�J����

        #endregion �� Private Method
    }
}
