//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�m�F�\�A�N�Z�X�N���X
// �v���O�����T�v   : ��`�m�F�\�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/05/05  �C�����e : �V�K�쐬
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
    /// ��`�m�F�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�m�F�\�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010.05.05</br>
    /// </remarks>
    public class TegataConfirmReportAcs
    {
        #region �� Constructor
		/// <summary>
		/// ��`�m�F�\�A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ��`�m�F�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public TegataConfirmReportAcs()
		{
            this._iTegataConfirmReportResultDB = (ITegataConfirmReportResultDB)MediationTegataConfirmReportResultDB.GetTegataConfirmReportResultDB();
            //���t�擾���i
            this._dateGet = DateGetAcs.GetInstance();
            // ��`��ʖ��̂̐ݒ�
            _draftKindCdsHt = new Hashtable();
            _draftKindCdsHt.Add(0, "�莝��`");
            _draftKindCdsHt.Add(1, "�旧��`");
            _draftKindCdsHt.Add(2, "������`");
            _draftKindCdsHt.Add(3, "���n��`");
            _draftKindCdsHt.Add(4, "�S�ێ�`");
            _draftKindCdsHt.Add(5, "�s�n��`");
            _draftKindCdsHt.Add(6, "�x����`");
            _draftKindCdsHt.Add(7, "��t��`");
            _draftKindCdsHt.Add(9, "���ώ�`");
		}

        #endregion �� Constructor

        #region �� Private Member
        // ��`�m�F�\�����C���^�t�F�[�X
        ITegataConfirmReportResultDB _iTegataConfirmReportResultDB;

        // DataSet�I�u�W�F�N�g
        private DataSet _dataSet;

        // ��`��ʖ���
        private Hashtable _draftKindCdsHt;

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
        #region �� ��`�m�F�\�f�[�^�擾
        /// <summary>
        /// ��`�m�F�\�f�[�^�擾
        /// </summary>
        /// <param name="tegataConfirmReport">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`�m�F�\�f�[�^���擾����B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        public int SearchTegataConfirmReportProcMain(TegataConfirmReport tegataConfirmReport, out string errMsg)
        {
            return this.SearchTegataConfirmReportProc(tegataConfirmReport, out errMsg);
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
        /// <param name="tegataConfirmReport"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ��������`�m�F�\�f�[�^���擾����B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SearchTegataConfirmReportProc(TegataConfirmReport tegataConfirmReport, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMTEG02005EA.CreateDataTable(ref _dataSet);

                // ���o�����W�J  --------------------------------------------------------------
                TegataConfirmReportParaWork tegataConfirmReportparaWork = new TegataConfirmReportParaWork();
                // ��ʌ������->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo(ref tegataConfirmReport, out tegataConfirmReportparaWork, out errMsg);

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = tegataConfirmReportparaWork;
                status = _iTegataConfirmReportResultDB.Search(out retList, paraWorkRef);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ConverToDataSetForPdf(_dataSet.Tables[PMTEG02005EA.ct_Tbl_TegataConfirmReportData], (ArrayList)retList, tegataConfirmReportparaWork);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if (this._dataSet.Tables[PMTEG02005EA.ct_Tbl_TegataConfirmReportData].Rows.Count < 1)
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
                        errMsg = "��`�m�F�\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
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
        /// <param name="tegataConfirmReport">UI���o�����N���X</param>
        /// <param name="tegataConfirmReportParaWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s��</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date	   : 2010.05.05</br>
        /// </remarks>
        private int SetCondInfo(ref TegataConfirmReport tegataConfirmReport, out TegataConfirmReportParaWork tegataConfirmReportParaWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            tegataConfirmReportParaWork = new TegataConfirmReportParaWork();
            try
            {  
                // ��ƃR�[�h
                tegataConfirmReportParaWork.EnterpriseCode = tegataConfirmReport.EnterpriseCode;

                // �������i�J�n�j
                tegataConfirmReportParaWork.DepositDateSt = tegataConfirmReport.DepositDateSt;

                // �������i�I���j
                tegataConfirmReportParaWork.DepositDateEd = tegataConfirmReport.DepositDateEd;

                // ��`�敪
                tegataConfirmReportParaWork.DraftDivide = tegataConfirmReport.DraftDivide;

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
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010.05.05</br>
        /// </remarks>
        private void ConverToDataSetForPdf(DataTable dataTable, ArrayList retList, TegataConfirmReportParaWork paraWork)
        {

            DataRow dr = null;
            TegataConfirmReportResultWork rsltInfo = null;
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
                rsltInfo = (TegataConfirmReportResultWork)retList[i];
                customerCode = rsltInfo.CustomerCode.ToString(formatStr);
                bankAndBranchCd = rsltInfo.BankAndBranchCd.ToString("D7");

                dr = dataTable.NewRow();

                // ��`���
                dr[PMTEG02005EA.ct_Col_DraftKindCd] = rsltInfo.DraftKindCd;
                dr[PMTEG02005EA.ct_Col_DraftKindName] = (string)this._draftKindCdsHt[rsltInfo.DraftKindCd];
                // ��s�x�X
                dr[PMTEG02005EA.ct_Col_BankAndBranchCd] = bankAndBranchCd;
                dr[PMTEG02005EA.ct_Col_BankAndBranchNm] = bankAndBranchCd.Substring(0, 4)
                    + "-" + bankAndBranchCd.Substring(4, 3) + " " + rsltInfo.BankAndBranchNm;

                // �x����
                if (DateTime.MinValue != rsltInfo.Date)
                {
                    dr[PMTEG02005EA.ct_Col_DepositDate] = rsltInfo.Date.ToString("yyyy/MM/dd");
                }
                // �U�o��
                if (DateTime.MinValue != rsltInfo.DraftDrawingDate)
                { 
                    dr[PMTEG02005EA.ct_Col_DraftDrawingDate] = rsltInfo.DraftDrawingDate.ToString("yyyy/MM/dd");
                }
                
                // ������
                if (0 != rsltInfo.ValidityTerm)
                {
                    DateTime dateTime = new DateTime(
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(0, 4)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(4, 2)),
                        Convert.ToInt16(rsltInfo.ValidityTerm.ToString().Substring(6, 2)));
                    dr[PMTEG02005EA.ct_Col_ValidityTerm] = dateTime.ToString("yyyy/MM/dd");
                }

                // ������ 0=���U�A1=���U
                dr[PMTEG02005EA.ct_Col_DraftDivide] = rsltInfo.DraftDivide == 0 ? "���U" : "���U";

                // ��`�ԍ�
                dr[PMTEG02005EA.ct_Col_RcvDraftNo] = rsltInfo.DraftNo;

                // ����於�� �x����`�f�[�^�̌v�㋒�_�R�[�h�A�d����R�[�h�A�d���旪��
                dr[PMTEG02005EA.ct_Col_CustomerSnm] = rsltInfo.AddUpSecCode.Trim().PadLeft(2, '0')
                    + "-" + customerCode
                    + " " + rsltInfo.CustomerSnm;

                // ���z
                dr[PMTEG02005EA.ct_Col_Deposit] = rsltInfo.DepositOrPayment;
                // �E�v�P
                dr[PMTEG02005EA.ct_Col_Outline1] = rsltInfo.Outline1;
                // �E�v2
                dr[PMTEG02005EA.ct_Col_Outline2] = rsltInfo.Outline2;
                // �`�[�ԍ�
                dr[PMTEG02005EA.ct_Col_SlipNo] = rsltInfo.SlipNo.ToString();

                dataTable.Rows.Add(dr);
            }
        }
        #endregion

        #endregion �� �f�[�^�W�J����

        #endregion �� Private Method
    }
}
