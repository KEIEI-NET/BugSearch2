//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������ꗗ�\�A�N�Z�X�N���X
// �v���O�����T�v   : �������ꗗ�\�Ŏg�p����f�[�^���擾����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �� �� ��  2010/07/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : liyp
// �� �� ��  2010/12/20  �C�����e : ���[���C�A�E�g��̓��t���ڂ𔄏�����ڂƓ��͓����ڂɕ�����
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �������ꗗ�\�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ꗗ�\�Ŏg�p����f�[�^���擾����</br>
    /// <br>Programmer : 22018 ��ؐ��b</br>
    /// <br>Date       : 2010/07/01</br>
    /// </remarks>
    public class NoDepSalListAcs
    {
        #region �� Constructor
        /// <summary>
        /// �������ꗗ�\�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������ꗗ�\�A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public NoDepSalListAcs()
        {
            this._iClaimSalesReadDB = (IClaimSalesReadDB)MediationClaimSalesReadDB.GetClaimSalesReadDB();
        }

        #endregion �� Constructor

        #region �� Private Member
        // �������ꗗ�\�����C���^�t�F�[�X
        IClaimSalesReadDB _iClaimSalesReadDB;

        // DataSet�I�u�W�F�N�g
        private DataSet _dataSet;

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
        #region �� �������ꗗ�\�f�[�^�擾
        /// <summary>
        /// �������ꗗ�\�f�[�^�擾
        /// </summary>
        /// <param name="noDepSalListCdtn">���o����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������関�����ꗗ�\�f�[�^���擾����B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public int SearchNoDepSalListProcMain( NoDepSalListCdtn noDepSalListCdtn, out string errMsg )
        {
            return this.SearchNoDepSalListProc( noDepSalListCdtn, out errMsg );
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
        /// <param name="noDepSalListCdtn"></param>
        /// <param name="errMsg"></param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ������関�����ꗗ�\�f�[�^���擾����B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private int SearchNoDepSalListProc( NoDepSalListCdtn noDepSalListCdtn, out string errMsg )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = "";
            try
            {
                // DataTable Create ----------------------------------------------------------
                PMKAU02005EA.CreateDataTable( ref _dataSet );

                // ���o�����W�J  --------------------------------------------------------------
                SearchParaClaimSalesRead paraWork = new SearchParaClaimSalesRead();
                // ��ʌ������->remoteDean>  --------------------------------------------------------------
                status = this.SetCondInfo( ref noDepSalListCdtn, out paraWork, out errMsg );

                if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    return status;
                }

                // �f�[�^�擾  ----------------------------------------------------------------
                object retList = null;
                object paraWorkRef = paraWork;
                status = _iClaimSalesReadDB.Search( out retList, paraWorkRef, 0, ConstantManagement.LogicalMode.GetData0 );

                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ConverToDataSetForPdf( _dataSet.Tables[PMKAU02005EA.ct_Tbl_NoDepSalListData], (ArrayList)retList, noDepSalListCdtn );
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                        if ( this._dataSet.Tables[PMKAU02005EA.ct_Tbl_NoDepSalListData].Rows.Count < 1 )
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
                        errMsg = "�������ꗗ�\�̒��[�o�̓f�[�^�̎擾�Ɏ��s���܂����B";
                        break;
                }
            }
            catch ( Exception ex )
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
        /// <param name="noDepSalListCdtn">UI���o�����N���X</param>
        /// <param name="paraWork">�����[�g���o�����N���X</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���o�����W�J�������s��</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        private int SetCondInfo( ref NoDepSalListCdtn noDepSalListCdtn, out SearchParaClaimSalesRead paraWork, out string errMsg )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            paraWork = new SearchParaClaimSalesRead();
            try
            {
                // ��ƃR�[�h
                paraWork.EnterpriseCode = noDepSalListCdtn.EnterpriseCode;

                // ���t�i�����or���͓��j
                if ( noDepSalListCdtn.TargetDateDiv == 0 )
                {
                    // ������i�J�n�j
                    paraWork.SearchSlipDateStart = noDepSalListCdtn.DateSt;
                    // ������i�I���j
                    paraWork.SearchSlipDateEnd = noDepSalListCdtn.DateEd;
                }
                else
                {
                    // ���͓��i�J�n�j
                    paraWork.InputDateStart = noDepSalListCdtn.DateSt;
                    // ���͓��i�I���j
                    paraWork.InputDateEnd = noDepSalListCdtn.DateEd;
                }

                // �������_�R�[�h�i�J�n�j
                paraWork.DemandAddUpSecCdStart = noDepSalListCdtn.DemandAddUpSecCdSt;
                // �������_�R�[�h�i�I���j
                paraWork.DemandAddUpSecCdEnd = noDepSalListCdtn.DemandAddUpSecCdEd;
                // �������Ӑ�R�[�h�i�J�n�j
                paraWork.ClaimCodeStart = noDepSalListCdtn.ClaimCodeSt;
                // �������Ӑ�R�[�h�i�I���j
                paraWork.ClaimCodeEnd = noDepSalListCdtn.ClaimCodeEd;


                // ���|�敪�������Ɋ܂߂Ȃ�
                paraWork.AccRecDivCd = -1;

                // ���������������Ɋ܂߂Ȃ�
                paraWork.AutoDepositCd = -1;

                // ������(���������ς݊܂�)�̂�
                paraWork.AlwcSalesSlipCall = 1;

                // �󒍃X�e�[�^�X��30:����̂�
                paraWork.AcptAnOdrStatus = new int[] { 30 };
            }
            catch ( Exception ex )
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
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2010/07/01</br>
        /// <br>Update Note: 2010/12/20 liyp</br>
        /// <br>            ���[���C�A�E�g��̓��t���ڂ𔄏�����ڂƓ��͓����ڂɕ�����</br>
        /// </remarks>
        private void ConverToDataSetForPdf( DataTable dataTable, ArrayList retList, NoDepSalListCdtn paraWork )
        {

            DataRow row = null;

            foreach ( SearchClaimSalesWork retWork in retList )
            {
                row = dataTable.NewRow();

                # region [row��retWork]
                row[PMKAU02005EA.ct_Col_DemandAddUpSecCd] = retWork.DemandAddUpSecCd.Trim();
                row[PMKAU02005EA.ct_Col_DemandAddUpSecNm] = retWork.DemandAddUpSecNm;
                row[PMKAU02005EA.ct_Col_ClaimCode] = retWork.ClaimCode;
                row[PMKAU02005EA.ct_Col_ClaimSnm] = retWork.ClaimSnm;
                //row[PMKAU02005EA.ct_Col_SalesDate] = this.GetTargetDate( retWork, paraWork ).ToString( "yyyy/MM/dd" );// DEL 2010/12/17
                row[PMKAU02005EA.ct_Col_SalesDate] = retWork.SalesDate.ToString("yyyy/MM/dd");// ADD 2010/12/17
                row[PMKAU02005EA.ct_Col_SearchSlipDate] = retWork.SearchSlipDate.ToString( "yyyy/MM/dd" );// ADD 2010/12/17
                row[PMKAU02005EA.ct_Col_SalesSlipNum] = retWork.SalesSlipNum;
                row[PMKAU02005EA.ct_Col_SalesSlipCd] = retWork.SalesSlipCd;
                row[PMKAU02005EA.ct_Col_SalesSlipCdNm] = this.GetSalesSlipCdNm( retWork );
                row[PMKAU02005EA.ct_Col_CustomerSnm] = retWork.CustomerSnm;
                row[PMKAU02005EA.ct_Col_SalesTotal] = this.GetSalesTotal( retWork );
                row[PMKAU02005EA.ct_Col_DepositAlwcBlnce] = retWork.DepositAlwcBlnce;
                row[PMKAU02005EA.ct_Col_SalesEmployeeCd] = retWork.SalesEmployeeCd;
                row[PMKAU02005EA.ct_Col_SalesEmployeeNm] = retWork.SalesEmployeeNm;
                row[PMKAU02005EA.ct_Col_FrontEmployeeCd] = retWork.FrontEmployeeCd;
                row[PMKAU02005EA.ct_Col_FrontEmployeeNm] = retWork.FrontEmployeeNm;
                row[PMKAU02005EA.ct_Col_SlipNote] = retWork.SlipNote;
                # endregion

                dataTable.Rows.Add( row );
            }
        }

        /// <summary>
        /// ������z�擾�����i�]�ŕ����ŐŔ�or�ō��𔻒f����j
        /// </summary>
        /// <param name="retWork"></param>
        /// <returns></returns>
        private Int64 GetSalesTotal( SearchClaimSalesWork retWork )
        {
            switch ( retWork.ConsTaxLayMethod )
            {
                default:
                // �`�[�]��
                case 0:
                // ���ד]��
                case 1:
                    {
                        // �ō�
                        return retWork.SalesTotalTaxInc;
                    }
                // �����e
                case 2:
                // �����q
                case 3:
                // ��ې�
                case 9:
                    {
                        // �Ŕ�
                        return retWork.SalesTotalTaxExc;
                    }
            }
        }

        /// <summary>
        /// �Ώۓ��t�擾
        /// </summary>
        /// <param name="retWork"></param>
        /// <param name="paraWork"></param>
        /// <returns></returns>
        private DateTime GetTargetDate( SearchClaimSalesWork retWork, NoDepSalListCdtn paraWork )
        {
            if ( paraWork.TargetDateDiv == 0 )
            {
                // �����
                return retWork.SalesDate;
            }
            else
            {
                // ���͓�
                return retWork.SearchSlipDate;
            }
        }
        /// <summary>
        /// �`�[�敪�擾
        /// </summary>
        /// <param name="retWork"></param>
        /// <returns></returns>
        private string GetSalesSlipCdNm( SearchClaimSalesWork retWork )
        {
            // 0:����,1:�ԕi
            switch ( retWork.SalesSlipCd )
            {
                default:
                case 0: return "����";
                case 1: return "�ԕi";
            }
        }
        #endregion

        #endregion �� �f�[�^�W�J����

        #endregion �� Private Method
    }
}
