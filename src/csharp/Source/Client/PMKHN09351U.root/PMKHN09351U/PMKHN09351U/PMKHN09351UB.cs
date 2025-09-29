//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�ꊇ�C��
// �v���O�����T�v   �F���Ӑ�̕ύX���ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/11/27     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/07     �C�����e�FMantis�y13030�z�̎����o�͋敪�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/13     �C�����e�FMantis�y9494�z���Ӑ�ϓ����̎擾�������C��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/01/29     �C�����e�FMantis�y14950�z�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/02/09     �C�����e�FMantis�y14976�z�O���b�h����̊g��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/02/17     �C�����e�F���v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̋敪���̂�ύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/02/24     �C�����e�FMantis�y15033�z�`�[����敪�~5��ǉ�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/02/24     �C�����e�FMantis�y15032�z�������o�͋敪���\������Ă��܂�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30434 �H��
// �C����    2010/03/02     �C�����e�FMantis�y14976�z�O���b�h����̊g��(�}�E�X����ŗ�ړ����ł��Ȃ�)
// ---------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �O���b�h�����ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O���b�h�����ݒ���s���܂��B</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2008/11/20</br>
    /// </remarks>
    internal class GridInitialSetting
    {
        #region �� Constants

        // �O���b�h��
        public const string column_No = "No";
        public const string column_CustomerCode = "CutomerCode";
        public const string column_CustomerSubCode = "CustomerSubCode";
        public const string column_CustomerName = "CustomerName";
        public const string column_CustomerName2 = "CustomerName2";
        public const string column_CustomerSnm = "CustomerSnm";
        public const string column_CustomerKana = "CustomerKana";
        public const string column_HonorificTitle = "HonorificTitle";
        public const string column_OutputName = "OutputName";
        public const string column_MngSectionName = "MngSectionName";
        public const string column_MngSectionGuide = "MngSectionGuide";
        public const string column_CustomerAgentName = "CustomerAgentName";
        public const string column_CustomerAgentGuide = "CustomerAgentGuide";
        public const string column_OldCustomerAgentName = "OldCustomerAgentName";
        public const string column_OldCustomerAgentGuide = "OldCustomerAgentGuide";
        public const string column_CustAgentChgDate = "CustAgentChgDate";
        public const string column_TransStopDate = "TransStopDate";
        public const string column_CarMngDivCd = "CarMngDivCd";
        public const string column_CorporateDivCode = "CorporateDivCode";
        public const string column_AcceptWholeSale = "AcceptWholeSale";
        public const string column_CustomerAttributeDiv = "CustomerAttributeDiv";
        public const string column_CustWarehouseName = "CustWarehouseName";
        public const string column_CustWarehouseGuide = "CustWarehouseGuide";
        public const string column_BusinessTypeName = "BusinessTypeName";
        public const string column_JobTypeName = "JobTypeName";
        public const string column_SalesAreaName = "SalesAreaName";
        public const string column_CustAnalysCode1 = "CustAnalysCode1";
        public const string column_CustAnalysCode2 = "CustAnalysCode2";
        public const string column_CustAnalysCode3 = "CustAnalysCode3";
        public const string column_CustAnalysCode4 = "CustAnalysCode4";
        public const string column_CustAnalysCode5 = "CustAnalysCode5";
        public const string column_CustAnalysCode6 = "CustAnalysCode6";
        public const string column_ClaimSectionSnm = "ClaimSectionSnm";
        public const string column_ClaimSectionGuide = "ClaimSectionGuide";
        public const string column_ClaimSnm = "ClaimSnm";
        public const string column_ClaimGuide = "ClaimGuide";
        public const string column_TotalDay = "TotalDay";
        public const string column_CollectMoneyName = "CollectMoneyName";
        public const string column_CollectMoneyDay = "CollectMoneyDay";
        public const string column_CollectCond = "CollectCond";
        public const string column_CollectSight = "CollectSight";
        public const string column_NTimeCalcStDate = "NTimeCalcStDate";
        public const string column_BillCollecterName = "BillCollecterName";
        public const string column_BillCollecterGuide = "BillCollecterGuide";
        public const string column_CustCTaXLayRefCd = "CustCTaXLayRefCd";
        public const string column_ConsTaxLayMethod = "ConsTaxLayMethod";
        public const string column_CreditMngCode = "CreditMngCode";
        public const string column_CreditMoney = "CreditMoney";     // ADD 2009/04/13
        public const string column_WarningCreditMoney = "WarningCreditMoney";
        public const string column_DepoDelCode = "DepoDelCode";
        public const string column_AccRecDivCd = "AccRecDivCd";
        public const string column_SalesUnPrcFrcProcCd = "SalesUnPrcFrcProcCd";
        public const string column_SalesUnPrcFrcProcGuide = "SalesUnPrcFrcProcGuide";
        public const string column_SalesMoneyFrcProcCd = "SalesMoneyFrcProcCd";
        public const string column_SalesMoneyFrcProcGuide = "SalesMoneyFrcProcGuide";
        public const string column_SalesCnsTaxFrcProcCd = "SalesCnsTaxFrcProcCd";
        public const string column_SalesCnsTaxFrcProcGuide = "SalesCnsTaxFrcProcGuide";
        public const string column_PostNo = "PostNo";
        public const string column_PostNoGuide = "PostNoGuide";
        public const string column_Address1 = "Address1";
        public const string column_Address3 = "Address3";
        public const string column_Address4 = "Address4";
        public const string column_HomeTelNo = "HomeTelNo";
        public const string column_HomeFaxNo = "HomeFaxNo";
        public const string column_OfficeTelNo = "OfficeTelNo";
        public const string column_PortableTelNo = "PortableTelNo";
        public const string column_OfficeFaxNo = "OfficeFaxNo";
        public const string column_OthersTelNo = "OthersTelNo";
        public const string column_SearchTelNo = "SearchTelNo";
        public const string column_MainContactCode = "MainContactCode";
        public const string column_CustomerAgent = "CustomerAgent";
        public const string column_MainSendMailAddrCd = "MainSendMailAddrCd";
        public const string column_MailAddress1 = "MailAddress1";
        public const string column_MailSendCode1 = "MailSendCode1";
        public const string column_MailAddrKindCode1 = "MailAddrKindCode1";
        public const string column_MailAddress2 = "MailAddress2";
        public const string column_MailSendCode2 = "MailSendCode2";
        public const string column_MailAddrKindCode2 = "MailAddrKindCode2";
        public const string column_ReceiptOutputCode = "ReceiptOutputCode";     // ADD 2009/04/07
        public const string column_BillOutputCode = "BillOutputCode";   // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h

        // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
        public const string column_SalesSlipPrtDiv  = "SalesSlipPrtDiv";    // �[�i���o�́i����`�[���s�敪�j
        public const string column_AcpOdrrSlipPrtDiv= "AcpOdrrSlipPrtDiv";  // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
        public const string column_ShipmSlipPrtDiv  = "ShipmSlipPrtDiv";    // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
        public const string column_EstimatePrtDiv   = "EstimatePrtDiv";     // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
        public const string column_UOESlipPrtDiv    = "UOESlipPrtDiv";      // UOE�`�[�o�́iUOE�`�[���s�敪�j
        // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

        // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
        public const string column_TotalBillOutputDiv   = "TotalBillOutputDiv";     // ���v�������o��
        public const string column_DetailBillOutputCode = "DetailBillOutputCode";   // ���א������o��
        public const string column_SlipTtlBillOutputDiv = "SlipTtlBillOutputDiv";   // �`�[���v�������o��
        // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

        public const string column_DmOutCode = "DmOutCode";
        public const string column_CustSlipNoMngCd = "CustSlipNoMngCd";
        public const string column_CustomerSlipNoDiv = "CustomerSlipNoDiv";
        public const string column_QrcodePrtCd = "QrcodePrtCd";

        public int depositStKindCd1 = 0;

        #endregion �� Constants


        #region �� Private Members

        private UserGuideAcs _userGuideAcs;
        private AlItmDspNmAcs _alItmDspNmAcs;
        private DepositStAcs _depositStAcs;
        private MoneyKindAcs _moneyKindAcs;

        private AlItmDspNm _alItmDspNm;
        private DepositSt _depositSt;
        private Dictionary<int, string> _jobTypeDic;
        private Dictionary<int, string> _businessTypeDic;
        private Dictionary<int, string> _salesAreaDic;
        private Dictionary<int, MoneyKind> _moneyKindDic;

        #endregion �� Private Members


        #region �� Constructor

        /// <summary>
        /// �O���b�h�����ݒ�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�����ݒ�N���X�̃C���X�^���X���쐬���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public GridInitialSetting()
        {
            this._userGuideAcs = new UserGuideAcs();
            this._alItmDspNmAcs = new AlItmDspNmAcs();
            this._depositStAcs = new DepositStAcs();
            this._moneyKindAcs = new MoneyKindAcs();

            // �}�X�^�Ǎ�
            ReadAlItmDspNm();
            ReadJobTypeCode();
            ReadBusinessTypeCode();
            ReadSalesAreaCode();
            ReadDepositSt();
            ReadMoneyKind();
        }

        #endregion �� Constructor


        #region �� Properties

        public AlItmDspNm AlItmDspNm
        {
            get { return this._alItmDspNm; }
        }

        public Dictionary<int, string> JobTypeDic
        {
            get { return this._jobTypeDic; }
        }

        public Dictionary<int, string> BusinessTypeDic
        {
            get { return this._businessTypeDic; }
        }

        public Dictionary<int, string> SalesAreaDic
        {
            get { return this._salesAreaDic; }
        }

        #endregion �� Properties


        #region �� Public Methods

        /// <summary>
        /// �O���b�h��쐬����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h����쐬���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public DataTable CreateColumn()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(column_No, typeof(int));
            dataTable.Columns.Add(column_CustomerCode, typeof(string));
            dataTable.Columns.Add(column_CustomerSubCode, typeof(string));
            dataTable.Columns.Add(column_CustomerName, typeof(string));
            dataTable.Columns.Add(column_CustomerName2, typeof(string));
            dataTable.Columns.Add(column_CustomerSnm, typeof(string));
            dataTable.Columns.Add(column_CustomerKana, typeof(string));
            dataTable.Columns.Add(column_HonorificTitle, typeof(string));
            dataTable.Columns.Add(column_OutputName, typeof(int));
            dataTable.Columns.Add(column_MngSectionName, typeof(string));
            dataTable.Columns.Add(column_MngSectionGuide, typeof(string));
            dataTable.Columns.Add(column_CustomerAgentName, typeof(string));
            dataTable.Columns.Add(column_CustomerAgentGuide, typeof(string));
            dataTable.Columns.Add(column_OldCustomerAgentName, typeof(string));
            dataTable.Columns.Add(column_OldCustomerAgentGuide, typeof(string));
            dataTable.Columns.Add(column_CustAgentChgDate, typeof(DateTime));
            dataTable.Columns.Add(column_TransStopDate, typeof(DateTime));
            dataTable.Columns.Add(column_CarMngDivCd, typeof(int));
            dataTable.Columns.Add(column_CorporateDivCode, typeof(int));
            dataTable.Columns.Add(column_AcceptWholeSale, typeof(int));
            dataTable.Columns.Add(column_CustomerAttributeDiv, typeof(int));
            dataTable.Columns.Add(column_CustWarehouseName, typeof(string));
            dataTable.Columns.Add(column_CustWarehouseGuide, typeof(string));
            dataTable.Columns.Add(column_BusinessTypeName, typeof(int));
            dataTable.Columns.Add(column_JobTypeName, typeof(int));
            dataTable.Columns.Add(column_SalesAreaName, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode1, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode2, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode3, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode4, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode5, typeof(int));
            dataTable.Columns.Add(column_CustAnalysCode6, typeof(int));
            dataTable.Columns.Add(column_ClaimSectionSnm, typeof(string));
            dataTable.Columns.Add(column_ClaimSectionGuide, typeof(string));
            dataTable.Columns.Add(column_ClaimSnm, typeof(string));
            dataTable.Columns.Add(column_ClaimGuide, typeof(string));
            dataTable.Columns.Add(column_TotalDay, typeof(int));
            dataTable.Columns.Add(column_CollectMoneyName, typeof(int));
            dataTable.Columns.Add(column_CollectMoneyDay, typeof(int));
            dataTable.Columns.Add(column_CollectCond, typeof(int));
            dataTable.Columns.Add(column_CollectSight, typeof(int));
            dataTable.Columns.Add(column_NTimeCalcStDate, typeof(int));
            dataTable.Columns.Add(column_BillCollecterName, typeof(string));
            dataTable.Columns.Add(column_BillCollecterGuide, typeof(string));
            dataTable.Columns.Add(column_CustCTaXLayRefCd, typeof(int));
            dataTable.Columns.Add(column_ConsTaxLayMethod, typeof(int));
            dataTable.Columns.Add(column_CreditMngCode, typeof(int));
            dataTable.Columns.Add(column_CreditMoney, typeof(string));      // ADD 2009/04/13
            dataTable.Columns.Add(column_WarningCreditMoney, typeof(string));
            dataTable.Columns.Add(column_DepoDelCode, typeof(int));
            dataTable.Columns.Add(column_AccRecDivCd, typeof(int));
            dataTable.Columns.Add(column_SalesUnPrcFrcProcCd, typeof(int));
            dataTable.Columns.Add(column_SalesUnPrcFrcProcGuide, typeof(string));
            dataTable.Columns.Add(column_SalesMoneyFrcProcCd, typeof(int));
            dataTable.Columns.Add(column_SalesMoneyFrcProcGuide, typeof(string));
            dataTable.Columns.Add(column_SalesCnsTaxFrcProcCd, typeof(int));
            dataTable.Columns.Add(column_SalesCnsTaxFrcProcGuide, typeof(string));
            dataTable.Columns.Add(column_PostNo, typeof(string));
            dataTable.Columns.Add(column_PostNoGuide, typeof(string));
            dataTable.Columns.Add(column_Address1, typeof(string));
            dataTable.Columns.Add(column_Address3, typeof(string));
            dataTable.Columns.Add(column_Address4, typeof(string));
            dataTable.Columns.Add(column_HomeTelNo, typeof(string));
            dataTable.Columns.Add(column_HomeFaxNo, typeof(string));
            dataTable.Columns.Add(column_OfficeTelNo, typeof(string));
            dataTable.Columns.Add(column_PortableTelNo, typeof(string));
            dataTable.Columns.Add(column_OfficeFaxNo, typeof(string));
            dataTable.Columns.Add(column_OthersTelNo, typeof(string));
            dataTable.Columns.Add(column_SearchTelNo, typeof(string));
            dataTable.Columns.Add(column_MainContactCode, typeof(int));
            dataTable.Columns.Add(column_CustomerAgent, typeof(string));
            dataTable.Columns.Add(column_MainSendMailAddrCd, typeof(int));
            dataTable.Columns.Add(column_MailAddress1, typeof(string));
            dataTable.Columns.Add(column_MailSendCode1, typeof(int));
            dataTable.Columns.Add(column_MailAddrKindCode1, typeof(int));
            dataTable.Columns.Add(column_MailAddress2, typeof(string));
            dataTable.Columns.Add(column_MailSendCode2, typeof(int));
            dataTable.Columns.Add(column_MailAddrKindCode2, typeof(int));
            dataTable.Columns.Add(column_ReceiptOutputCode, typeof(int));   // ADD 2009/04/07
            dataTable.Columns.Add(column_BillOutputCode, typeof(int));  // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            dataTable.Columns.Add(column_SalesSlipPrtDiv, typeof(int));     // �[�i���o�́i����`�[���s�敪�j
            dataTable.Columns.Add(column_AcpOdrrSlipPrtDiv, typeof(int));   // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            dataTable.Columns.Add(column_ShipmSlipPrtDiv, typeof(int));     // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            dataTable.Columns.Add(column_EstimatePrtDiv, typeof(int));      // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            dataTable.Columns.Add(column_UOESlipPrtDiv, typeof(int));       // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            dataTable.Columns.Add(column_TotalBillOutputDiv, typeof(int));  // ���v�������o��
            dataTable.Columns.Add(column_DetailBillOutputCode, typeof(int));// ���א������o��
            dataTable.Columns.Add(column_SlipTtlBillOutputDiv, typeof(int));// �`�[���v�������o��
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            dataTable.Columns.Add(column_DmOutCode, typeof(int));
            dataTable.Columns.Add(column_CustSlipNoMngCd, typeof(int));
            dataTable.Columns.Add(column_CustomerSlipNoDiv, typeof(int));
            dataTable.Columns.Add(column_QrcodePrtCd, typeof(int));

            return dataTable;
        }

        /// <summary>
        /// TODO:�O���b�h�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�����ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public void SetGridInitialLayout(ref UltraGrid uGrid)
        {
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c������A��Œ�A�s�t�B���^���\�ɂ��� ---------->>>>>
            // ��������\�ɂ���
            uGrid.DisplayLayout.Override.AllowColMoving = AllowColMoving.Default;   // ADD 2010/03/02 Mantis�y14976�z�O���b�h����̊g��(�}�E�X����ŗ�ړ����ł��Ȃ�)
            uGrid.DisplayLayout.Override.AllowColSwapping = AllowColSwapping.WithinGroup;
            // ��Œ���\�ɂ���
            uGrid.DisplayLayout.Override.FixedHeaderIndicator = FixedHeaderIndicator.Button;
            // �s�t�B���^���\�ɂ���
            uGrid.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c������A��Œ�A�s�t�B���^���\�ɂ��� ----------<<<<<

            if (uGrid.DisplayLayout.Bands[0].Columns.Count == 0)
            {
                uGrid.DataSource = CreateColumn();
            }

            ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

            //--------------------------------------
            // �Œ�w�b�_�[
            //--------------------------------------
            columns[column_No].Header.Fixed = true;
            columns[column_CustomerCode].Header.Fixed = true;

            //--------------------------------------
            // ���͕s��
            //--------------------------------------
            columns[column_No].CellActivation = Activation.Disabled;
            columns[column_CustomerCode].CellActivation = Activation.Disabled;

            //--------------------------------------
            // �Z���J���[
            //--------------------------------------
            columns[column_No].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            columns[column_No].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            columns[column_No].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            columns[column_No].CellAppearance.ForeColor = Color.White;
            columns[column_No].CellAppearance.ForeColorDisabled = Color.White;

            for (int index = 2; index < columns.Count; index++)
            {
                columns[index].CellAppearance.BackColorDisabled = Color.Gainsboro;
            }

            //--------------------------------------
            // �L���v�V����
            //--------------------------------------
            columns[column_No].Header.Caption = "No.";
            columns[column_CustomerCode].Header.Caption = "���Ӑ溰��";
            columns[column_CustomerSubCode].Header.Caption = "��޺���";
            columns[column_CustomerName].Header.Caption = "���Ӑ於1";
            columns[column_CustomerName2].Header.Caption = "���Ӑ於2";
            columns[column_CustomerSnm].Header.Caption = "���Ӑ旪��";
            columns[column_CustomerKana].Header.Caption = "���Ӑ於(��)";
            columns[column_HonorificTitle].Header.Caption = "�h��";
            columns[column_OutputName].Header.Caption = "����";
            columns[column_MngSectionName].Header.Caption = "�Ǘ����_";
            columns[column_MngSectionGuide].Header.Caption = "";
            columns[column_CustomerAgentName].Header.Caption = "���Ӑ�S��";
            columns[column_CustomerAgentGuide].Header.Caption = "";
            columns[column_OldCustomerAgentName].Header.Caption = "���S��";
            columns[column_OldCustomerAgentGuide].Header.Caption = "";
            columns[column_CustAgentChgDate].Header.Caption = "�S���ҕύX��";
            columns[column_TransStopDate].Header.Caption = "������~��";
            columns[column_CarMngDivCd].Header.Caption = "���q�Ǘ�";
            columns[column_CorporateDivCode].Header.Caption = "�l�E�@�l";
            columns[column_AcceptWholeSale].Header.Caption = "���Ӑ���";
            columns[column_CustomerAttributeDiv].Header.Caption = "���Ӑ摮��";
            columns[column_CustWarehouseName].Header.Caption = "�D��q��";
            columns[column_CustWarehouseGuide].Header.Caption = "";
            columns[column_BusinessTypeName].Header.Caption = "�Ǝ�";
            columns[column_JobTypeName].Header.Caption = "�E��";
            columns[column_SalesAreaName].Header.Caption = "�n��";
            columns[column_CustAnalysCode1].Header.Caption = "���ͺ���1";
            columns[column_CustAnalysCode2].Header.Caption = "���ͺ���2";
            columns[column_CustAnalysCode3].Header.Caption = "���ͺ���3";
            columns[column_CustAnalysCode4].Header.Caption = "���ͺ���4";
            columns[column_CustAnalysCode5].Header.Caption = "���ͺ���5";
            columns[column_CustAnalysCode6].Header.Caption = "���ͺ���6";
            columns[column_ClaimSectionSnm].Header.Caption = "�������_";
            columns[column_ClaimSectionGuide].Header.Caption = "";
            columns[column_ClaimSnm].Header.Caption = "�����溰��";
            columns[column_ClaimGuide].Header.Caption = "";
            columns[column_TotalDay].Header.Caption = "����";
            columns[column_CollectMoneyName].Header.Caption = "�W����";
            columns[column_CollectMoneyDay].Header.Caption = "�W����";
            columns[column_CollectCond].Header.Caption = "�������";
            columns[column_CollectSight].Header.Caption = "������";
            columns[column_NTimeCalcStDate].Header.Caption = "���񊨒�";
            columns[column_BillCollecterName].Header.Caption = "�W���S��";
            columns[column_BillCollecterGuide].Header.Caption = "";
            columns[column_CustCTaXLayRefCd].Header.Caption = "�]�ŕ����Q��";
            columns[column_ConsTaxLayMethod].Header.Caption = "����œ]�ŕ���";
            columns[column_CreditMngCode].Header.Caption = "�^�M�Ǘ�";
            columns[column_CreditMoney].Header.Caption = "�^�M�z";      // ADD 2009/04/13
            columns[column_WarningCreditMoney].Header.Caption = "�x���^�M�z";
            columns[column_DepoDelCode].Header.Caption = "��������";
            columns[column_AccRecDivCd].Header.Caption = "���|�敪";
            columns[column_SalesUnPrcFrcProcCd].Header.Caption = "�P���[��";
            columns[column_SalesUnPrcFrcProcGuide].Header.Caption = "";
            columns[column_SalesMoneyFrcProcCd].Header.Caption = "���z�[��";
            columns[column_SalesMoneyFrcProcGuide].Header.Caption = "";
            columns[column_SalesCnsTaxFrcProcCd].Header.Caption = "�Œ[��";
            columns[column_SalesCnsTaxFrcProcGuide].Header.Caption = "";
            columns[column_PostNo].Header.Caption = "�X�֔ԍ�";
            columns[column_PostNoGuide].Header.Caption = "";
            columns[column_Address1].Header.Caption = "�Z��1";
            columns[column_Address3].Header.Caption = "�Z��2";
            columns[column_Address4].Header.Caption = "�Z��3";
            columns[column_HomeTelNo].Header.Caption = this._alItmDspNm.HomeTelNoDspName.Trim();
            columns[column_HomeFaxNo].Header.Caption = this._alItmDspNm.HomeFaxNoDspName.Trim();
            columns[column_OfficeTelNo].Header.Caption = this._alItmDspNm.OfficeTelNoDspName.Trim();
            columns[column_PortableTelNo].Header.Caption = this._alItmDspNm.MobileTelNoDspName.Trim();
            columns[column_OfficeFaxNo].Header.Caption = this._alItmDspNm.OfficeFaxNoDspName.Trim();
            columns[column_OthersTelNo].Header.Caption = this._alItmDspNm.OtherTelNoDspName.Trim();
            columns[column_SearchTelNo].Header.Caption = "�����ԍ�";
            columns[column_MainContactCode].Header.Caption = "��A����";
            columns[column_CustomerAgent].Header.Caption = "���Ӑ�S����";
            columns[column_MainSendMailAddrCd].Header.Caption = "�呗�M��";
            columns[column_MailAddress1].Header.Caption = "Ұٱ��ڽ1";
            columns[column_MailSendCode1].Header.Caption = "Ұً敪1";
            columns[column_MailAddrKindCode1].Header.Caption = "Ұَ��1";
            columns[column_MailAddress2].Header.Caption = "Ұٱ��ڽ2";
            columns[column_MailSendCode2].Header.Caption = "Ұً敪2";
            columns[column_MailAddrKindCode2].Header.Caption = "Ұَ��2";
            columns[column_ReceiptOutputCode].Header.Caption = "�̎����o��";    // ADD 2009/04/07
            columns[column_BillOutputCode].Header.Caption = "�������o��";   // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            columns[column_SalesSlipPrtDiv].Header.Caption  = "�[�i���o��";     // �[�i���o�́i����`�[���s�敪�j
            columns[column_AcpOdrrSlipPrtDiv].Header.Caption= "�󒍓`�[�o��";   // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            columns[column_ShipmSlipPrtDiv].Header.Caption  = "�ݏo�`�[�o��";   // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            columns[column_EstimatePrtDiv].Header.Caption   = "���ϓ`�[�o��";   // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            columns[column_UOESlipPrtDiv].Header.Caption    = "UOE�`�[�o��";    // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            columns[column_TotalBillOutputDiv].Header.Caption   = "���v�������o��";
            columns[column_DetailBillOutputCode].Header.Caption = "���א������o��";
            columns[column_SlipTtlBillOutputDiv].Header.Caption = "�`�[���v�������o��";
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

//            columns[column_DmOutCode].Header.Caption = "DM�o��"; // DEL 2022/03/04 �c������ �d�q����A�g�Ή�
            columns[column_DmOutCode].Header.Caption = "�d�q����o��"; // ADD 2022/03/04 �c������ �d�q����A�g�Ή�
            columns[column_CustSlipNoMngCd].Header.Caption = "����`�ԊǗ�";
            columns[column_CustomerSlipNoDiv].Header.Caption = "�`�ԋ敪";
            columns[column_QrcodePrtCd].Header.Caption = "QR���ވ��";

            //--------------------------------------
            // ��
            //--------------------------------------
            columns[column_No].Width = 45;
            columns[column_CustomerCode].Width = 90;
            columns[column_CustomerSubCode].Width = 170;
            columns[column_CustomerName].Width = 490;
            columns[column_CustomerName2].Width = 490;
            columns[column_CustomerSnm].Width = 330;
            columns[column_CustomerKana].Width = 250;
            columns[column_HonorificTitle].Width = 80;
            columns[column_OutputName].Width = 140;
            columns[column_MngSectionName].Width = 110;
            columns[column_MngSectionGuide].Width = 24;
            columns[column_CustomerAgentName].Width = 140;
            columns[column_CustomerAgentGuide].Width = 24;
            columns[column_OldCustomerAgentName].Width = 140;
            columns[column_OldCustomerAgentGuide].Width = 24;
            columns[column_CustAgentChgDate].Width = 130;
            columns[column_TransStopDate].Width = 130;
            columns[column_CarMngDivCd].Width = 105;
            columns[column_CorporateDivCode].Width = 90;
            columns[column_AcceptWholeSale].Width = 95;
            columns[column_CustomerAttributeDiv].Width = 105;
            columns[column_CustWarehouseName].Width = 140;
            columns[column_CustWarehouseGuide].Width = 24;
            columns[column_BusinessTypeName].Width = 140;
            columns[column_JobTypeName].Width = 140;
            columns[column_SalesAreaName].Width = 140;
            columns[column_CustAnalysCode1].Width = 85;
            columns[column_CustAnalysCode2].Width = 85;
            columns[column_CustAnalysCode3].Width = 85;
            columns[column_CustAnalysCode4].Width = 85;
            columns[column_CustAnalysCode5].Width = 85;
            columns[column_CustAnalysCode6].Width = 85;
            columns[column_ClaimSectionSnm].Width = 110;
            columns[column_ClaimSectionGuide].Width = 24;
            columns[column_ClaimSnm].Width = 140;
            columns[column_ClaimGuide].Width = 24;
            columns[column_TotalDay].Width = 50;
            columns[column_CollectMoneyName].Width = 90;
            columns[column_CollectMoneyDay].Width = 60;
            columns[column_CollectCond].Width = 80;
            columns[column_CollectSight].Width = 75;
            columns[column_NTimeCalcStDate].Width = 70;
            columns[column_BillCollecterName].Width = 140;
            columns[column_BillCollecterGuide].Width = 24;
            columns[column_CustCTaXLayRefCd].Width = 120;
            columns[column_ConsTaxLayMethod].Width = 120;
            columns[column_CreditMngCode].Width = 80;
            columns[column_CreditMoney].Width = 110;        // ADD 2009/04/13
            columns[column_WarningCreditMoney].Width = 110;
            columns[column_DepoDelCode].Width = 80;
            columns[column_AccRecDivCd].Width = 90;
            columns[column_SalesUnPrcFrcProcCd].Width = 80;
            columns[column_SalesUnPrcFrcProcGuide].Width = 24;
            columns[column_SalesMoneyFrcProcCd].Width = 80;
            columns[column_SalesMoneyFrcProcGuide].Width = 24;
            columns[column_SalesCnsTaxFrcProcCd].Width = 80;
            columns[column_SalesCnsTaxFrcProcGuide].Width = 24;
            columns[column_PostNo].Width = 90;
            columns[column_PostNoGuide].Width = 24;
            columns[column_Address1].Width = 490;
            columns[column_Address3].Width = 360;
            columns[column_Address4].Width = 490;
            columns[column_HomeTelNo].Width = 135;
            columns[column_HomeFaxNo].Width = 135;
            columns[column_OfficeTelNo].Width = 135;
            columns[column_PortableTelNo].Width = 135;
            columns[column_OfficeFaxNo].Width = 135;
            columns[column_OthersTelNo].Width = 135;
            columns[column_SearchTelNo].Width = 75;
            columns[column_MainContactCode].Width = 135;
            columns[column_CustomerAgent].Width = 330;
            columns[column_MainSendMailAddrCd].Width = 100;
            columns[column_MailAddress1].Width = 520;
            columns[column_MailSendCode1].Width = 110;
            columns[column_MailAddrKindCode1].Width = 90;
            columns[column_MailAddress2].Width = 520;
            columns[column_MailSendCode2].Width = 110;
            columns[column_MailAddrKindCode2].Width = 90;
            columns[column_ReceiptOutputCode].Width = 95;   // ADD 2009/04/07
            columns[column_BillOutputCode].Width = 95;  // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            columns[column_SalesSlipPrtDiv].Width   = 150;  // �[�i���o�́i����`�[���s�敪�j
            columns[column_AcpOdrrSlipPrtDiv].Width = 150;  // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            columns[column_ShipmSlipPrtDiv].Width   = 150;  // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            columns[column_EstimatePrtDiv].Width    = 150;  // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            columns[column_UOESlipPrtDiv].Width     = 150;  // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            columns[column_TotalBillOutputDiv].Width    = 150;  // ���v�������o��
            columns[column_DetailBillOutputCode].Width  = 150;  // ���א������o��
            columns[column_SlipTtlBillOutputDiv].Width  = 150;  // �`�[���v�������o��
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            columns[column_DmOutCode].Width = 80;
            columns[column_CustSlipNoMngCd].Width = 120;
            columns[column_CustomerSlipNoDiv].Width = 110;
            columns[column_QrcodePrtCd].Width = 110;

            //--------------------------------------
            // ���͌���
            //--------------------------------------
            columns[column_No].MaxLength = 4;
            columns[column_CustomerCode].MaxLength = 8;
            columns[column_CustomerSubCode].MaxLength = 20;
            columns[column_CustomerName].MaxLength = 30;
            columns[column_CustomerName2].MaxLength = 30;
            columns[column_CustomerSnm].MaxLength = 20;
            columns[column_CustomerKana].MaxLength = 30;
            columns[column_HonorificTitle].MaxLength = 4;
            columns[column_MngSectionName].MaxLength = 2;
            columns[column_CustomerAgentName].MaxLength = 4;
            columns[column_OldCustomerAgentName].MaxLength = 4;
            columns[column_CustWarehouseName].MaxLength = 4;
            columns[column_CustAnalysCode1].MaxLength = 3;
            columns[column_CustAnalysCode2].MaxLength = 3;
            columns[column_CustAnalysCode3].MaxLength = 3;
            columns[column_CustAnalysCode4].MaxLength = 3;
            columns[column_CustAnalysCode5].MaxLength = 3;
            columns[column_CustAnalysCode6].MaxLength = 3;
            columns[column_ClaimSectionSnm].MaxLength = 2;
            columns[column_ClaimSnm].MaxLength = 8;
            columns[column_TotalDay].MaxLength = 2;
            columns[column_CollectMoneyDay].MaxLength = 2;
            columns[column_CollectSight].MaxLength = 3;
            columns[column_NTimeCalcStDate].MaxLength = 2;
            columns[column_BillCollecterName].MaxLength = 4;
            columns[column_CreditMoney].MaxLength = 10;     // ADD 2009/04/13
            columns[column_WarningCreditMoney].MaxLength = 10;
            columns[column_SalesUnPrcFrcProcCd].MaxLength = 8;
            columns[column_SalesMoneyFrcProcCd].MaxLength = 8;
            columns[column_SalesCnsTaxFrcProcCd].MaxLength = 8;
            columns[column_PostNo].MaxLength = 10;
            columns[column_Address1].MaxLength = 30;
            columns[column_Address3].MaxLength = 22;
            columns[column_Address4].MaxLength = 30;
            columns[column_HomeTelNo].MaxLength = 16;
            columns[column_HomeFaxNo].MaxLength = 16;
            columns[column_OfficeTelNo].MaxLength = 16;
            columns[column_PortableTelNo].MaxLength = 16;
            columns[column_OfficeFaxNo].MaxLength = 16;
            columns[column_OthersTelNo].MaxLength = 16;
            columns[column_SearchTelNo].MaxLength = 4;
            columns[column_CustomerAgent].MaxLength = 20;
            columns[column_MailAddress1].MaxLength = 64;
            columns[column_MailAddress2].MaxLength = 64;

            //--------------------------------------
            // �e�L�X�g�ʒu(HAlign)
            //--------------------------------------
            columns[column_No].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustomerCode].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustomerSubCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerName2].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerSnm].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerKana].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_HonorificTitle].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OutputName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MngSectionName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MngSectionGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_CustomerAgentName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerAgentGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_OldCustomerAgentName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OldCustomerAgentGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_CustAgentChgDate].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_TransStopDate].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CarMngDivCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CorporateDivCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_AcceptWholeSale].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerAttributeDiv].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustWarehouseName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustWarehouseGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_BusinessTypeName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_JobTypeName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_SalesAreaName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustAnalysCode1].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode2].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode3].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode4].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode5].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CustAnalysCode6].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_ClaimSectionSnm].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_ClaimSectionGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_ClaimSnm].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_ClaimGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_TotalDay].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CollectMoneyName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CollectMoneyDay].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_CollectCond].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CollectSight].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_NTimeCalcStDate].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_BillCollecterName].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_BillCollecterGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_CustCTaXLayRefCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_ConsTaxLayMethod].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CreditMngCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CreditMoney].CellAppearance.TextHAlign = HAlign.Right;       // ADD 2009/04/13
            columns[column_WarningCreditMoney].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_DepoDelCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_AccRecDivCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_SalesUnPrcFrcProcCd].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_SalesUnPrcFrcProcGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_SalesMoneyFrcProcCd].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_SalesMoneyFrcProcGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_SalesCnsTaxFrcProcCd].CellAppearance.TextHAlign = HAlign.Right;
            columns[column_SalesCnsTaxFrcProcGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_PostNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_PostNoGuide].CellAppearance.TextHAlign = HAlign.Center;
            columns[column_Address1].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_Address3].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_Address4].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_HomeTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_HomeFaxNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OfficeTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_PortableTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OfficeFaxNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_OthersTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_SearchTelNo].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MainContactCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerAgent].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MainSendMailAddrCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailAddress1].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailSendCode1].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailAddrKindCode1].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailAddress2].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailSendCode2].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_MailAddrKindCode2].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_ReceiptOutputCode].CellAppearance.TextHAlign = HAlign.Left;      // ADD 2009/04/07
            columns[column_BillOutputCode].CellAppearance.TextHAlign = HAlign.Left; // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            columns[column_SalesSlipPrtDiv].CellAppearance.TextHAlign   = HAlign.Left;  // �[�i���o�́i����`�[���s�敪�j
            columns[column_AcpOdrrSlipPrtDiv].CellAppearance.TextHAlign = HAlign.Left;  // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            columns[column_ShipmSlipPrtDiv].CellAppearance.TextHAlign   = HAlign.Left;  // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            columns[column_EstimatePrtDiv].CellAppearance.TextHAlign    = HAlign.Left;  // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            columns[column_UOESlipPrtDiv].CellAppearance.TextHAlign     = HAlign.Left;  // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            columns[column_TotalBillOutputDiv].CellAppearance.TextHAlign    = HAlign.Left;  // ���v�������o��
            columns[column_DetailBillOutputCode].CellAppearance.TextHAlign  = HAlign.Left;  // ���א������o��
            columns[column_SlipTtlBillOutputDiv].CellAppearance.TextHAlign  = HAlign.Left;  // �`�[���v�������o��
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            columns[column_DmOutCode].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustSlipNoMngCd].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_CustomerSlipNoDiv].CellAppearance.TextHAlign = HAlign.Left;
            columns[column_QrcodePrtCd].CellAppearance.TextHAlign = HAlign.Left;

            //--------------------------------------
            // �e�L�X�g�ʒu(VAlign)
            //--------------------------------------
            for (int index = 0; index < columns.Count; index++)
            {
                columns[index].CellAppearance.TextVAlign = VAlign.Middle;
            }

            //--------------------------------------
            // ���t�R���g���[���ݒ�
            //--------------------------------------
            columns[column_CustAgentChgDate].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            columns[column_TransStopDate].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;

            columns[column_CustAgentChgDate].CellDisplayStyle = CellDisplayStyle.FormattedText;
            columns[column_TransStopDate].CellDisplayStyle = CellDisplayStyle.FormattedText;

            columns[column_CustAgentChgDate].Format = "yyyy�NMM��dd��";
            columns[column_TransStopDate].Format = "yyyy�NMM��dd��";

            //--------------------------------------
            // �K�C�h�{�^���ݒ�
            //--------------------------------------
            Image guideButtonImage = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            columns[column_MngSectionGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_CustomerAgentGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_OldCustomerAgentGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_CustWarehouseGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_ClaimSectionGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_ClaimGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_BillCollecterGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_SalesUnPrcFrcProcGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_SalesMoneyFrcProcGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_SalesCnsTaxFrcProcGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
            columns[column_PostNoGuide].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

            columns[column_MngSectionGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_CustomerAgentGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_OldCustomerAgentGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_CustWarehouseGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_ClaimSectionGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_ClaimGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_BillCollecterGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_SalesUnPrcFrcProcGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_SalesMoneyFrcProcGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_SalesCnsTaxFrcProcGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            columns[column_PostNoGuide].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;

            columns[column_MngSectionGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_CustomerAgentGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_OldCustomerAgentGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_CustWarehouseGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_ClaimSectionGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_ClaimGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_BillCollecterGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_SalesUnPrcFrcProcGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_SalesMoneyFrcProcGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_SalesCnsTaxFrcProcGuide].CellButtonAppearance.Image = guideButtonImage;
            columns[column_PostNoGuide].CellButtonAppearance.Image = guideButtonImage;

            columns[column_MngSectionGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_CustomerAgentGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_OldCustomerAgentGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_CustWarehouseGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_ClaimSectionGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_ClaimGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_BillCollecterGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_SalesUnPrcFrcProcGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_SalesMoneyFrcProcGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_SalesCnsTaxFrcProcGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;
            columns[column_PostNoGuide].CellButtonAppearance.ImageHAlign = HAlign.Center;

            columns[column_MngSectionGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_CustomerAgentGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_OldCustomerAgentGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_CustWarehouseGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_ClaimSectionGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_ClaimGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_BillCollecterGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_SalesUnPrcFrcProcGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_SalesMoneyFrcProcGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_SalesCnsTaxFrcProcGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;
            columns[column_PostNoGuide].CellButtonAppearance.ImageVAlign = VAlign.Middle;

            columns[column_MngSectionGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_CustomerAgentGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_OldCustomerAgentGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_CustWarehouseGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_ClaimSectionGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_ClaimGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_BillCollecterGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_SalesUnPrcFrcProcGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_SalesMoneyFrcProcGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_SalesCnsTaxFrcProcGuide].CellAppearance.Cursor = Cursors.Hand;
            columns[column_PostNoGuide].CellAppearance.Cursor = Cursors.Hand;

            //--------------------------------------
            // �R���{�{�b�N�X�ݒ�
            //--------------------------------------
            ValueList valueList = new ValueList();
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

            // FIXME:016.����
            #region ����

            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "���Ӑ於��1�E2");
            //valueList.ValueListItems.Add(1, "���Ӑ於��1");
            //valueList.ValueListItems.Add(2, "���Ӑ於��2");
            //valueList.ValueListItems.Add(3, "��������");
            // columns[column_OutputName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:���Ӑ於��1�E2");
            valueList.ValueListItems.Add(1, "1:���Ӑ於��1");
            valueList.ValueListItems.Add(2, "2:���Ӑ於��2");
            valueList.ValueListItems.Add(3, "3:��������");
            columns[column_OutputName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_OutputName].ValueList = valueList.Clone();
            
            #endregion // ����

            // FIXME:090.���q�Ǘ�
            #region ���q�Ǘ�

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "���Ȃ�");
            //valueList.ValueListItems.Add(1, "�o�^(�m�F)");
            //valueList.ValueListItems.Add(2, "�o�^(����)");
            //valueList.ValueListItems.Add(3, "�o�^��");
            //columns[column_CarMngDivCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:���Ȃ�");
            valueList.ValueListItems.Add(1, "1:�o�^(�m�F)");
            valueList.ValueListItems.Add(2, "2:�o�^(����)");
            valueList.ValueListItems.Add(3, "3:�o�^��");
            columns[column_CarMngDivCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CarMngDivCd].ValueList = valueList.Clone();

            #endregion // ���q�Ǘ�

            // FIXME:018.�l�E�@�l
            #region �l�E�@�l

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "�l");
            //valueList.ValueListItems.Add(1, "�@�l");
            //valueList.ValueListItems.Add(2, "����@�l");
            //valueList.ValueListItems.Add(3, "�Ǝ�");
            //valueList.ValueListItems.Add(4, "�Ј�");
            //columns[column_CorporateDivCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:�l");
            valueList.ValueListItems.Add(1, "1:�@�l");
            valueList.ValueListItems.Add(2, "2:����@�l");
            valueList.ValueListItems.Add(3, "3:�Ǝ�");
            valueList.ValueListItems.Add(4, "4:�Ј�");
            columns[column_CorporateDivCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CorporateDivCode].ValueList = valueList.Clone();

            #endregion // �l�E�@�l

            // FIXME:070.���Ӑ��ʁ@���Ɣ̐�敪
            #region ���Ӑ���

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(1, "���Ӑ�");
            //valueList.ValueListItems.Add(2, "�[����");
            //columns[column_AcceptWholeSale].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(1, "1:���Ӑ�");
            valueList.ValueListItems.Add(2, "2:�[����");
            columns[column_AcceptWholeSale].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_AcceptWholeSale].ValueList = valueList.Clone();

            #endregion // ���Ӑ���

            // FIXME:019.���Ӑ摮��
            #region ���Ӑ摮��

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "���������");
            //valueList.ValueListItems.Add(8, "�Г������");
            //valueList.ValueListItems.Add(9, "��������");
            //columns[column_CustomerAttributeDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:���������");
            valueList.ValueListItems.Add(8, "8:�Г������");
            valueList.ValueListItems.Add(9, "9:��������");
            columns[column_CustomerAttributeDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CustomerAttributeDiv].ValueList = valueList.Clone();

            #endregion // ���Ӑ摮��

            // FIXME:021.�Ǝ�
            #region �Ǝ�

            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, " ");
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //foreach (int code in this._businessTypeDic.Keys)
            //{
            //    valueList.ValueListItems.Add(code, this._businessTypeDic[code]);
            //}
            //columns[column_BusinessTypeName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            const string VALUE_NAME_FORMAT = "{0}:{1}";
            const string USER_GUIDE_CODE_FORMAT = "d4";

            foreach (int code in this._businessTypeDic.Keys)
            {
                valueList.ValueListItems.Add(code, string.Format(VALUE_NAME_FORMAT, code.ToString(USER_GUIDE_CODE_FORMAT), this._businessTypeDic[code]));
            }
            columns[column_BusinessTypeName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_BusinessTypeName].ValueList = valueList.Clone();

            #endregion // �Ǝ�

            // FIXME:020.�E��
            #region �E��

            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, " ");
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //foreach (int code in this._jobTypeDic.Keys)
            //{
            //    valueList.ValueListItems.Add(code, this._jobTypeDic[code]);
            //}
            //columns[column_JobTypeName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            foreach (int code in this._jobTypeDic.Keys)
            {
                valueList.ValueListItems.Add(code, string.Format(VALUE_NAME_FORMAT, code.ToString(USER_GUIDE_CODE_FORMAT), this._jobTypeDic[code]));
            }
            columns[column_JobTypeName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_JobTypeName].ValueList = valueList.Clone();

            #endregion // �E��

            // FIXME:022.�n��
            #region �n��

            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, " ");
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //foreach (int code in this._salesAreaDic.Keys)
            //{
            //    valueList.ValueListItems.Add(code, this._salesAreaDic[code]);
            //}
            //columns[column_SalesAreaName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            foreach (int code in this._salesAreaDic.Keys)
            {
                valueList.ValueListItems.Add(code, string.Format(VALUE_NAME_FORMAT, code.ToString(USER_GUIDE_CODE_FORMAT), this._salesAreaDic[code]));
            }
            columns[column_SalesAreaName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_SalesAreaName].ValueList = valueList.Clone();

            #endregion // �n��

            // FIXME:046.�W����
            #region �W����

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "����");
            //valueList.ValueListItems.Add(1, "����");
            //valueList.ValueListItems.Add(2, "���X��");
            //valueList.ValueListItems.Add(3, "���X�X��");
            //columns[column_CollectMoneyName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:����");
            valueList.ValueListItems.Add(1, "1:����");
            valueList.ValueListItems.Add(2, "2:���X��");
            valueList.ValueListItems.Add(3, "3:���X�X��");
            columns[column_CollectMoneyName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CollectMoneyName].ValueList = valueList.Clone();

            #endregion // �W����

            // FIXME:049.�������
            #region �������

            valueList.ValueListItems.Clear();
            // ����������X�g�擾
            Dictionary<int, string> collectCondDic = GetCollectCondDic();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //foreach (int key in collectCondDic.Keys)
            //{
            //    valueList.ValueListItems.Add(key, collectCondDic[key]);
            //}
            //columns[column_CollectCond].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            foreach (int key in collectCondDic.Keys)
            {
                valueList.ValueListItems.Add(key, string.Format(VALUE_NAME_FORMAT, key.ToString("d2"), collectCondDic[key]));
            }
            columns[column_CollectCond].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CollectCond].ValueList = valueList.Clone();

            #endregion // �������

            // FIXME:076.�]�ŕ����Q��
            #region �]�ŕ����Q��

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "�ŗ��ݒ�Q��");
            //valueList.ValueListItems.Add(1, "���Ӑ�Q��");
            //columns[column_CustCTaXLayRefCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:�ŗ��ݒ�Q��");
            valueList.ValueListItems.Add(1, "1:���Ӑ�Q��");
            columns[column_CustCTaXLayRefCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CustCTaXLayRefCd].ValueList = valueList.Clone();

            #endregion // �]�ŕ����Q��

            // FIXME:077.����œ]�ŕ���
            #region ����œ]�ŕ���

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "�`�[�]��");
            //valueList.ValueListItems.Add(1, "���ד]��");
            //valueList.ValueListItems.Add(2, "�����e");
            //valueList.ValueListItems.Add(3, "�����q");
            //valueList.ValueListItems.Add(9, "��ې�");
            //columns[column_ConsTaxLayMethod].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:�`�[�]��");
            valueList.ValueListItems.Add(1, "1:���ד]��");
            valueList.ValueListItems.Add(2, "2:�����e");
            valueList.ValueListItems.Add(3, "3:�����q");
            valueList.ValueListItems.Add(9, "9:��ې�");
            columns[column_ConsTaxLayMethod].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_ConsTaxLayMethod].ValueList = valueList.Clone();

            #endregion // ����œ]�ŕ���

            // FIXME:071.�^�M�Ǘ�
            #region �^�M�Ǘ�

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "���Ȃ�");
            //valueList.ValueListItems.Add(1, "����");
            //columns[column_CreditMngCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:���Ȃ�");
            valueList.ValueListItems.Add(1, "1:����");
            columns[column_CreditMngCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CreditMngCode].ValueList = valueList.Clone();

            #endregion // �^�M�Ǘ�

            // FIXME:072.��������
            #region ��������

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "���Ȃ�");
            //valueList.ValueListItems.Add(1, "����");
            //columns[column_DepoDelCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:���Ȃ�");
            valueList.ValueListItems.Add(1, "1:����");
            columns[column_DepoDelCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_DepoDelCode].ValueList = valueList.Clone();

            #endregion // ��������

            // FIXME:073.���|�敪
            #region ���|�敪

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "���|�Ȃ�");
            //valueList.ValueListItems.Add(1, "���|");
            //columns[column_AccRecDivCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:���|�Ȃ�");
            valueList.ValueListItems.Add(1, "1:���|");
            columns[column_AccRecDivCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_AccRecDivCd].ValueList = valueList.Clone();

            #endregion // ���|�敪

            // FIXME:033.��A����
            #region ��A����

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, this._alItmDspNm.HomeTelNoDspName.Trim());
            //valueList.ValueListItems.Add(1, this._alItmDspNm.HomeFaxNoDspName.Trim());
            //valueList.ValueListItems.Add(2, this._alItmDspNm.OfficeTelNoDspName.Trim());
            //valueList.ValueListItems.Add(3, this._alItmDspNm.MobileTelNoDspName.Trim());
            //valueList.ValueListItems.Add(4, this._alItmDspNm.OfficeFaxNoDspName.Trim());
            //valueList.ValueListItems.Add(5, this._alItmDspNm.OtherTelNoDspName.Trim());
            //columns[column_MainContactCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, string.Format(VALUE_NAME_FORMAT, 0, this._alItmDspNm.HomeTelNoDspName.Trim()));
            valueList.ValueListItems.Add(1, string.Format(VALUE_NAME_FORMAT, 1, this._alItmDspNm.HomeFaxNoDspName.Trim()));
            valueList.ValueListItems.Add(2, string.Format(VALUE_NAME_FORMAT, 2, this._alItmDspNm.OfficeTelNoDspName.Trim()));
            valueList.ValueListItems.Add(3, string.Format(VALUE_NAME_FORMAT, 3, this._alItmDspNm.MobileTelNoDspName.Trim()));
            valueList.ValueListItems.Add(4, string.Format(VALUE_NAME_FORMAT, 4, this._alItmDspNm.OfficeFaxNoDspName.Trim()));
            valueList.ValueListItems.Add(5, string.Format(VALUE_NAME_FORMAT, 5, this._alItmDspNm.OtherTelNoDspName.Trim()));
            columns[column_MainContactCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_MainContactCode].ValueList = valueList.Clone();

            #endregion // ��A����

            // FIXME:055.�呗�M��
            #region �呗�M��

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "Ұٱ��ڽ1");
            //valueList.ValueListItems.Add(1, "Ұٱ��ڽ2");
            //columns[column_MainSendMailAddrCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:Ұٱ��ڽ1");
            valueList.ValueListItems.Add(1, "1:Ұٱ��ڽ2");
            columns[column_MainSendMailAddrCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_MainSendMailAddrCd].ValueList = valueList.Clone();

            #endregion // �呗�M��

            // FIXME:059.���[���敪1
            #region ���[���敪1

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "���M���Ȃ�");
            //valueList.ValueListItems.Add(1, "���M����");
            //columns[column_MailSendCode1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:���M���Ȃ�");
            valueList.ValueListItems.Add(1, "1:���M����");
            columns[column_MailSendCode1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_MailSendCode1].ValueList = valueList.Clone();

            #endregion // ���[���敪1

            // FIXME:056.���[�����1
            #region ���[�����1

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "����");
            //valueList.ValueListItems.Add(1, "���");
            //valueList.ValueListItems.Add(2, "�g�ђ[��");
            //valueList.ValueListItems.Add(3, "�{�l�ȊO");
            //valueList.ValueListItems.Add(99, "���̑�");
            //columns[column_MailAddrKindCode1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:����");
            valueList.ValueListItems.Add(1, "1:���");
            valueList.ValueListItems.Add(2, "2:�g�ђ[��");
            valueList.ValueListItems.Add(3, "3:�{�l�ȊO");
            valueList.ValueListItems.Add(99, "99:���̑�");
            columns[column_MailAddrKindCode1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_MailAddrKindCode1].ValueList = valueList.Clone();

            #endregion // ���[�����1

            // FIXME:064.���[���敪2
            #region ���[���敪2

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "���M���Ȃ�");
            //valueList.ValueListItems.Add(1, "���M����");
            //columns[column_MailSendCode2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:���M���Ȃ�");
            valueList.ValueListItems.Add(1, "1:���M����");
            columns[column_MailSendCode2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_MailSendCode2].ValueList = valueList.Clone();

            #endregion // ���[���敪2

            // FIXME:061.���[�����2
            #region ���[�����2

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "����");
            //valueList.ValueListItems.Add(1, "���");
            //valueList.ValueListItems.Add(2, "�g�ђ[��");
            //valueList.ValueListItems.Add(3, "�{�l�ȊO");
            //valueList.ValueListItems.Add(99, "���̑�");
            //columns[column_MailAddrKindCode2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:����");
            valueList.ValueListItems.Add(1, "1:���");
            valueList.ValueListItems.Add(2, "2:�g�ђ[��");
            valueList.ValueListItems.Add(3, "3:�{�l�ȊO");
            valueList.ValueListItems.Add(99, "99:���̑�");
            columns[column_MailAddrKindCode2].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_MailAddrKindCode2].ValueList = valueList.Clone();

            #endregion // ���[�����2

            // FIXME:122.�̎����o��
            #region �̎����o��

            // ADD 2009/04/07 ------>>>
            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "����");
            //valueList.ValueListItems.Add(1, "���Ȃ�");
            //columns[column_ReceiptOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:����");
            valueList.ValueListItems.Add(1, "1:���Ȃ�");
            columns[column_ReceiptOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_ReceiptOutputCode].ValueList = valueList.Clone();
            // ADD 2009/04/07 ------<<<

            #endregion // �̎����o��

            // FIXME:043.�������o�͋敪�R�[�h�c�g�p���Ȃ�
            #region �������o��

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "����");
            //valueList.ValueListItems.Add(1, "���Ȃ�");
            //columns[column_BillOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:����");
            valueList.ValueListItems.Add(1, "1:���Ȃ�");
            columns[column_BillOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_BillOutputCode].ValueList = valueList.Clone();

            #endregion // �������o��

            // FIXME:117.�[�i���o�́i����`�[���s�敪�j, 118.�󒍓`�[�o�́i�󒍓`�[���s�敪�j, 119.�ݏo�`�[�o�́i�o�ד`�[���s�敪�j, 120.���ϓ`�[�o�́i���ϓ`�[���s�敪�j, 121.UOE�`�[�o�́iUOE�`�[���s�敪�j
            #region �[�i���o�́A�󒍓`�[�o�́A�ݏo�`�[�o�́A���ϓ`�[�o�́AUOE�`�[�o��
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "0:�W��");
            valueList.ValueListItems.Add(1, "1:���g�p");
            valueList.ValueListItems.Add(2, "2:�g�p");
            // �[�i���o��
            columns[column_SalesSlipPrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_SalesSlipPrtDiv].ValueList = valueList.Clone();
            // �󒍓`�[�o��
            columns[column_AcpOdrrSlipPrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_AcpOdrrSlipPrtDiv].ValueList = valueList.Clone();
            // �ݏo�`�[�o��
            columns[column_ShipmSlipPrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_ShipmSlipPrtDiv].ValueList = valueList.Clone();
            // ���ϓ`�[�o��
            columns[column_EstimatePrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_EstimatePrtDiv].ValueList = valueList.Clone();
            // UOE�`�[�o��
            columns[column_UOESlipPrtDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_UOESlipPrtDiv].ValueList = valueList.Clone();
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<
            #endregion // �[�i���o�́A�󒍓`�[�o�́A�ݏo�`�[�o�́A���ϓ`�[�o�́AUOE�`�[�o��

            // FIXME:126.���v�������o��, 127.���א������o��, 128.�`�[���v�������o��
            #region ���v�������o�́A���א������o�́A�`�[���v�������o��

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            #region �폜�R�[�h
            //valueList.ValueListItems.Clear();
            //valueList.ValueListItems.Add(0, "�W��");
            //valueList.ValueListItems.Add(1, "�g�p����");
            //valueList.ValueListItems.Add(2, "�g�p���Ȃ�");
            //// ���v�������o��
            //columns[column_TotalBillOutputDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //columns[column_TotalBillOutputDiv].ValueList = valueList.Clone();
            //// ���א������o��
            //columns[column_DetailBillOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //columns[column_DetailBillOutputCode].ValueList = valueList.Clone();
            //// �`�[���v�������o��
            //columns[column_SlipTtlBillOutputDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            //columns[column_SlipTtlBillOutputDiv].ValueList = valueList.Clone();
            #endregion
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Clear();
            valueList.ValueListItems.Add(0, "0:�W��");
            valueList.ValueListItems.Add(1, "1:�g�p");  // MOD 2010/02/17 �敪���̂̕ύX "�g�p����"��"�g�p"
            valueList.ValueListItems.Add(2, "2:���g�p");// MOD 2010/02/17 �敪���̂̕ύX "�g�p���Ȃ�"��"���g�p"
            // ���v�������o��
            columns[column_TotalBillOutputDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_TotalBillOutputDiv].ValueList = valueList.Clone();
            // ���א������o��
            columns[column_DetailBillOutputCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_DetailBillOutputCode].ValueList = valueList.Clone();
            // �`�[���v�������o��
            columns[column_SlipTtlBillOutputDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            columns[column_SlipTtlBillOutputDiv].ValueList = valueList.Clone();
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            #endregion // ���v�������o�́A���א������o�́A�`�[���v�������o��

            // FIXME:053.DM�o��
            #region DM�o��

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "����");
            //valueList.ValueListItems.Add(1, "���Ȃ�");
            //columns[column_DmOutCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:����");
            valueList.ValueListItems.Add(1, "1:���Ȃ�");
            columns[column_DmOutCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_DmOutCode].ValueList = valueList.Clone();

            #endregion // DM�o��

            // FIXME:074.����`�ԊǗ�
            #region ����`�ԊǗ�

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "�S�̐ݒ�Q��");
            //valueList.ValueListItems.Add(1, "���Ȃ�");
            //valueList.ValueListItems.Add(2, "����");
            //columns[column_CustSlipNoMngCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:�S�̐ݒ�Q��");
            valueList.ValueListItems.Add(1, "1:���Ȃ�");
            valueList.ValueListItems.Add(2, "2:����");
            columns[column_CustSlipNoMngCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CustSlipNoMngCd].ValueList = valueList.Clone();

            #endregion // ����`�ԊǗ�

            // FIXME:086.�`�ԋ敪
            #region �`�ԋ敪

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "�g�p���Ȃ�");
            //valueList.ValueListItems.Add(1, "�A��");
            //valueList.ValueListItems.Add(2, "����");
            //valueList.ValueListItems.Add(3, "����");
            //columns[column_CustomerSlipNoDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:�g�p���Ȃ�");
            valueList.ValueListItems.Add(1, "1:�A��");
            valueList.ValueListItems.Add(2, "2:����");
            valueList.ValueListItems.Add(3, "3:����");
            columns[column_CustomerSlipNoDiv].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_CustomerSlipNoDiv].ValueList = valueList.Clone();

            #endregion // �`�ԋ敪

            // FIXME:098.QR�R�[�h���
            #region QR�R�[�h���

            valueList.ValueListItems.Clear();
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            //valueList.ValueListItems.Add(0, "�W��");
            //valueList.ValueListItems.Add(1, "�󎚂��Ȃ�");
            //valueList.ValueListItems.Add(2, "�󎚂���");
            //valueList.ValueListItems.Add(3, "�ԕi�܂�");
            //columns[column_QrcodePrtCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            // DEL 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ---------->>>>>
            valueList.ValueListItems.Add(0, "0:�W��");
            valueList.ValueListItems.Add(1, "1:�󎚂��Ȃ�");
            valueList.ValueListItems.Add(2, "2:�󎚂���");
            valueList.ValueListItems.Add(3, "3:�ԕi�܂�");
            columns[column_QrcodePrtCd].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate;
            // ADD 2010/02/09 MANTIS�Ή�[14976]�F�O���b�h����̊g���c�\�����u�敪�l�F�敪���v�Ƃ��A�O���b�h�Z���ɋ敪�l�̓��͂��\�Ƃ��� ----------<<<<<
            columns[column_QrcodePrtCd].ValueList = valueList.Clone();

            #endregion // QR�R�[�h���

            // ADD 2010/02/24 MANTIS�Ή�[15032]�F�������o�͋敪���\������Ă��܂� ---------->>>>>
            //--------------------------------------
            // �f�t�H���g��\���ʒu�@�����L���v�V������ݒ肵�Ă���������A�����W
            //--------------------------------------
            #region �f�t�H���g��\���ʒu

            int visiblePosition = 0;

            columns[column_No].Header.VisiblePosition = ++visiblePosition; // "No.";
            columns[column_CustomerCode].Header.VisiblePosition = ++visiblePosition; // "���Ӑ溰��";
            columns[column_CustomerSubCode].Header.VisiblePosition = ++visiblePosition; // "��޺���";
            columns[column_CustomerName].Header.VisiblePosition = ++visiblePosition; // "���Ӑ於1";
            columns[column_CustomerName2].Header.VisiblePosition = ++visiblePosition; // "���Ӑ於2";
            columns[column_CustomerSnm].Header.VisiblePosition = ++visiblePosition; // "���Ӑ旪��";
            columns[column_CustomerKana].Header.VisiblePosition = ++visiblePosition; // "���Ӑ於(��)";
            columns[column_HonorificTitle].Header.VisiblePosition = ++visiblePosition; // "�h��";
            columns[column_OutputName].Header.VisiblePosition = ++visiblePosition; // "����";
            columns[column_MngSectionName].Header.VisiblePosition = ++visiblePosition; // "�Ǘ����_";
            columns[column_MngSectionGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_CustomerAgentName].Header.VisiblePosition = ++visiblePosition; // "���Ӑ�S��";
            columns[column_CustomerAgentGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_OldCustomerAgentName].Header.VisiblePosition = ++visiblePosition; // "���S��";
            columns[column_OldCustomerAgentGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_CustAgentChgDate].Header.VisiblePosition = ++visiblePosition; // "�S���ҕύX��";
            columns[column_TransStopDate].Header.VisiblePosition = ++visiblePosition; // "������~��";
            columns[column_CarMngDivCd].Header.VisiblePosition = ++visiblePosition; // "���q�Ǘ�";
            columns[column_CorporateDivCode].Header.VisiblePosition = ++visiblePosition; // "�l�E�@�l";
            columns[column_AcceptWholeSale].Header.VisiblePosition = ++visiblePosition; // "���Ӑ���";
            columns[column_CustomerAttributeDiv].Header.VisiblePosition = ++visiblePosition; // "���Ӑ摮��";
            columns[column_CustWarehouseName].Header.VisiblePosition = ++visiblePosition; // "�D��q��";
            columns[column_CustWarehouseGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_BusinessTypeName].Header.VisiblePosition = ++visiblePosition; // "�Ǝ�";
            columns[column_JobTypeName].Header.VisiblePosition = ++visiblePosition; // "�E��";
            columns[column_SalesAreaName].Header.VisiblePosition = ++visiblePosition; // "�n��";
            columns[column_CustAnalysCode1].Header.VisiblePosition = ++visiblePosition; // "���ͺ���1";
            columns[column_CustAnalysCode2].Header.VisiblePosition = ++visiblePosition; // "���ͺ���2";
            columns[column_CustAnalysCode3].Header.VisiblePosition = ++visiblePosition; // "���ͺ���3";
            columns[column_CustAnalysCode4].Header.VisiblePosition = ++visiblePosition; // "���ͺ���4";
            columns[column_CustAnalysCode5].Header.VisiblePosition = ++visiblePosition; // "���ͺ���5";
            columns[column_CustAnalysCode6].Header.VisiblePosition = ++visiblePosition; // "���ͺ���6";
            columns[column_ClaimSectionSnm].Header.VisiblePosition = ++visiblePosition; // "�������_";
            columns[column_ClaimSectionGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_ClaimSnm].Header.VisiblePosition = ++visiblePosition; // "�����溰��";
            columns[column_ClaimGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_TotalDay].Header.VisiblePosition = ++visiblePosition; // "����";
            columns[column_CollectMoneyName].Header.VisiblePosition = ++visiblePosition; // "�W����";
            columns[column_CollectMoneyDay].Header.VisiblePosition = ++visiblePosition; // "�W����";
            columns[column_CollectCond].Header.VisiblePosition = ++visiblePosition; // "�������";
            columns[column_CollectSight].Header.VisiblePosition = ++visiblePosition; // "������";
            columns[column_NTimeCalcStDate].Header.VisiblePosition = ++visiblePosition; // "���񊨒�";
            columns[column_BillCollecterName].Header.VisiblePosition = ++visiblePosition; // "�W���S��";
            columns[column_BillCollecterGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_CustCTaXLayRefCd].Header.VisiblePosition = ++visiblePosition; // "�]�ŕ����Q��";
            columns[column_ConsTaxLayMethod].Header.VisiblePosition = ++visiblePosition; // "����œ]�ŕ���";
            columns[column_CreditMngCode].Header.VisiblePosition = ++visiblePosition; // "�^�M�Ǘ�";
            columns[column_CreditMoney].Header.VisiblePosition = ++visiblePosition; // "�^�M�z";
            columns[column_WarningCreditMoney].Header.VisiblePosition = ++visiblePosition; // "�x���^�M�z";
            columns[column_DepoDelCode].Header.VisiblePosition = ++visiblePosition; // "��������";
            columns[column_AccRecDivCd].Header.VisiblePosition = ++visiblePosition; // "���|�敪";
            columns[column_SalesUnPrcFrcProcCd].Header.VisiblePosition = ++visiblePosition; // "�P���[��";
            columns[column_SalesUnPrcFrcProcGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_SalesMoneyFrcProcCd].Header.VisiblePosition = ++visiblePosition; // "���z�[��";
            columns[column_SalesMoneyFrcProcGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_SalesCnsTaxFrcProcCd].Header.VisiblePosition = ++visiblePosition; // "�Œ[��";
            columns[column_SalesCnsTaxFrcProcGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_PostNo].Header.VisiblePosition = ++visiblePosition; // "�X�֔ԍ�";
            columns[column_PostNoGuide].Header.VisiblePosition = ++visiblePosition; // "";
            columns[column_Address1].Header.VisiblePosition = ++visiblePosition; // "�Z��1";
            columns[column_Address3].Header.VisiblePosition = ++visiblePosition; // "�Z��2";
            columns[column_Address4].Header.VisiblePosition = ++visiblePosition; // "�Z��3";
            columns[column_HomeTelNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.HomeTelNoDspName.Trim();
            columns[column_HomeFaxNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.HomeFaxNoDspName.Trim();
            columns[column_OfficeTelNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.OfficeTelNoDspName.Trim();
            columns[column_PortableTelNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.MobileTelNoDspName.Trim();
            columns[column_OfficeFaxNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.OfficeFaxNoDspName.Trim();
            columns[column_OthersTelNo].Header.VisiblePosition = ++visiblePosition; // this._alItmDspNm.OtherTelNoDspName.Trim();
            columns[column_SearchTelNo].Header.VisiblePosition = ++visiblePosition; // "�����ԍ�";
            columns[column_MainContactCode].Header.VisiblePosition = ++visiblePosition; // "��A����";
            columns[column_CustomerAgent].Header.VisiblePosition = ++visiblePosition; // "���Ӑ�S����";
            columns[column_MainSendMailAddrCd].Header.VisiblePosition = ++visiblePosition; // "�呗�M��";
            columns[column_MailAddress1].Header.VisiblePosition = ++visiblePosition; // "Ұٱ��ڽ1";
            columns[column_MailSendCode1].Header.VisiblePosition = ++visiblePosition; // "Ұً敪1";
            columns[column_MailAddrKindCode1].Header.VisiblePosition = ++visiblePosition; // "Ұَ��1";
            columns[column_MailAddress2].Header.VisiblePosition = ++visiblePosition; // "Ұٱ��ڽ2";
            columns[column_MailSendCode2].Header.VisiblePosition = ++visiblePosition; // "Ұً敪2";
            columns[column_MailAddrKindCode2].Header.VisiblePosition = ++visiblePosition; // "Ұَ��2";
            columns[column_ReceiptOutputCode].Header.VisiblePosition = ++visiblePosition; // "�̎����o��";

            // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h
            columns[column_BillOutputCode].Header.VisiblePosition = ++visiblePosition; // "�������o��";

            columns[column_SalesSlipPrtDiv].Header.VisiblePosition = ++visiblePosition; // "�[�i���o��";     // �[�i���o�́i����`�[���s�敪�j
            columns[column_AcpOdrrSlipPrtDiv].Header.VisiblePosition = ++visiblePosition; // "�󒍓`�[�o��";   // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            columns[column_ShipmSlipPrtDiv].Header.VisiblePosition = ++visiblePosition; // "�ݏo�`�[�o��";   // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            columns[column_EstimatePrtDiv].Header.VisiblePosition = ++visiblePosition; // "���ϓ`�[�o��";   // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            columns[column_UOESlipPrtDiv].Header.VisiblePosition = ++visiblePosition; // "UOE�`�[�o��";    // UOE�`�[�o�́iUOE�`�[���s�敪�j

            columns[column_TotalBillOutputDiv].Header.VisiblePosition = ++visiblePosition; // "���v�������o��";
            columns[column_DetailBillOutputCode].Header.VisiblePosition = ++visiblePosition; // "���א������o��";
            columns[column_SlipTtlBillOutputDiv].Header.VisiblePosition = ++visiblePosition; // "�`�[���v�������o��";

            columns[column_DmOutCode].Header.VisiblePosition = ++visiblePosition; // "DM�o��";
            columns[column_CustSlipNoMngCd].Header.VisiblePosition = ++visiblePosition; // "����`�ԊǗ�";
            columns[column_CustomerSlipNoDiv].Header.VisiblePosition = ++visiblePosition; // "�`�ԋ敪";
            columns[column_QrcodePrtCd].Header.VisiblePosition = ++visiblePosition; // "QR���ވ��";

            #endregion // �f�t�H���g��\���ʒu
            // ADD 2010/02/24 MANTIS�Ή�[15032]�F�������o�͋敪���\������Ă��܂� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h
            columns[column_BillOutputCode].Hidden = true;
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<
        }

        /// <summary>
        /// �����\���ݒ菈��
        /// </summary>
        /// <param name="cells">�Z���R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̑Ώۍs�ɏ����\�����s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public void SetInitialDisp(ref CellsCollection cells, string belongSectionName)
        {
            cells[GridInitialSetting.column_CustomerSubCode].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustomerSnm].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustomerKana].Value = DBNull.Value;
            cells[GridInitialSetting.column_HonorificTitle].Value = "�l";
            cells[GridInitialSetting.column_OutputName].Value = 0;
            cells[GridInitialSetting.column_MngSectionName].Value = belongSectionName;
            cells[GridInitialSetting.column_CustomerAgentName].Value = LoginInfoAcquisition.Employee.Name.Trim();
            cells[GridInitialSetting.column_OldCustomerAgentName].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAgentChgDate].Value = DBNull.Value;
            cells[GridInitialSetting.column_TransStopDate].Value = DBNull.Value;
            cells[GridInitialSetting.column_CarMngDivCd].Value = 0;
            cells[GridInitialSetting.column_CorporateDivCode].Value = 0;
            cells[GridInitialSetting.column_AcceptWholeSale].Value = 1;
            cells[GridInitialSetting.column_CustomerAttributeDiv].Value = 0;
            cells[GridInitialSetting.column_CustWarehouseName].Value = DBNull.Value;
            cells[GridInitialSetting.column_BusinessTypeName].Value = 0;
            cells[GridInitialSetting.column_JobTypeName].Value = 0;
            cells[GridInitialSetting.column_SalesAreaName].Value = 0;
            cells[GridInitialSetting.column_CustAnalysCode1].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode2].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode3].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode4].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode5].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustAnalysCode6].Value = DBNull.Value;
            cells[GridInitialSetting.column_ClaimSectionSnm].Value = belongSectionName;
            cells[GridInitialSetting.column_ClaimSnm].Value = cells[GridInitialSetting.column_CustomerSnm].Value;
            cells[GridInitialSetting.column_TotalDay].Value = DBNull.Value;
            cells[GridInitialSetting.column_CollectMoneyName].Value = 0;
            cells[GridInitialSetting.column_CollectMoneyDay].Value = DBNull.Value;
            cells[GridInitialSetting.column_CollectCond].Value = this._depositSt.DepositStKindCd1;
            cells[GridInitialSetting.column_CollectSight].Value = DBNull.Value;
            cells[GridInitialSetting.column_NTimeCalcStDate].Value = DBNull.Value;
            cells[GridInitialSetting.column_BillCollecterName].Value = DBNull.Value;
            cells[GridInitialSetting.column_CustCTaXLayRefCd].Value = 0;
            cells[GridInitialSetting.column_CreditMngCode].Value = 0;
            cells[GridInitialSetting.column_CreditMoney].Value = DBNull.Value;      // ADD 2009/04/13
            cells[GridInitialSetting.column_WarningCreditMoney].Value = DBNull.Value;
            cells[GridInitialSetting.column_DepoDelCode].Value = 0;
            cells[GridInitialSetting.column_AccRecDivCd].Value = 1;
            cells[GridInitialSetting.column_SalesUnPrcFrcProcCd].Value = 0;
            cells[GridInitialSetting.column_SalesMoneyFrcProcCd].Value = 0;
            cells[GridInitialSetting.column_SalesCnsTaxFrcProcCd].Value = 0;
            cells[GridInitialSetting.column_HomeTelNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_HomeFaxNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_PortableTelNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_OthersTelNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_SearchTelNo].Value = DBNull.Value;
            cells[GridInitialSetting.column_MainContactCode].Value = 0;
            cells[GridInitialSetting.column_CustomerAgent].Value = DBNull.Value;
            cells[GridInitialSetting.column_MainSendMailAddrCd].Value = 0;
            cells[GridInitialSetting.column_MailAddress1].Value = DBNull.Value;
            cells[GridInitialSetting.column_MailSendCode1].Value = 0;
            cells[GridInitialSetting.column_MailAddrKindCode1].Value = 0;
            cells[GridInitialSetting.column_MailAddress2].Value = DBNull.Value;
            cells[GridInitialSetting.column_MailSendCode2].Value = 0;
            cells[GridInitialSetting.column_MailAddrKindCode2].Value = 0;
            cells[GridInitialSetting.column_ReceiptOutputCode].Value = 0;       // ADD 2009/04/07
            cells[GridInitialSetting.column_BillOutputCode].Value = 0;  // TODO:�g�p���Ȃ��c�������o�͋敪�R�[�h

            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ---------->>>>>
            cells[GridInitialSetting.column_SalesSlipPrtDiv].Value  = 0;    // �[�i���o�́i����`�[���s�敪�j
            cells[GridInitialSetting.column_AcpOdrrSlipPrtDiv].Value= 0;    // �󒍓`�[�o�́i�󒍓`�[���s�敪�j
            cells[GridInitialSetting.column_ShipmSlipPrtDiv].Value  = 0;    // �ݏo�`�[�o�́i�o�ד`�[���s�敪�j
            cells[GridInitialSetting.column_EstimatePrtDiv].Value   = 0;    // ���ϓ`�[�o�́i���ϓ`�[���s�敪�j
            cells[GridInitialSetting.column_UOESlipPrtDiv].Value    = 0;    // UOE�`�[�o�́iUOE�`�[���s�敪�j
            // ADD 2010/02/24 MANTIS�Ή�[15033]�F�`�[����敪�~5��ǉ� ----------<<<<<

            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ---------->>>>>
            cells[GridInitialSetting.column_TotalBillOutputDiv].Value   = 0;    // ���v�������o��
            cells[GridInitialSetting.column_DetailBillOutputCode].Value = 0;    // ���א������o��
            cells[GridInitialSetting.column_SlipTtlBillOutputDiv].Value = 0;    // �`�[���v�������o��
            // ADD 2010/01/29 MANTIS�Ή�[14950]�F�������o�͋敪�̍폜�ƍ��v�������o�͋敪�A���א������o�͋敪�A�`�[���v�������o�͋敪�̒ǉ� ----------<<<<<

            cells[GridInitialSetting.column_DmOutCode].Value = 1;
            cells[GridInitialSetting.column_CustSlipNoMngCd].Value = 0;
            cells[GridInitialSetting.column_CustomerSlipNoDiv].Value = 0;
            cells[GridInitialSetting.column_QrcodePrtCd].Value = 0;
        }

        #endregion �� Public Methods


        #region �� Private Methods

        /// <summary>
        /// �����ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ݒ�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadDepositSt()
        {
            try
            {
                int status = this._depositStAcs.Read(out this._depositSt, LoginInfoAcquisition.EnterpriseCode, 0);
                if (status != 0)
                {
                    this._depositSt = new DepositSt();
                }
            }
            catch
            {
                this._depositSt = new DepositSt();
            }
        }

        /// <summary>
        /// ���z��ʐݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���z��ʐݒ�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadMoneyKind()
        {
            this._moneyKindDic = new Dictionary<int, MoneyKind>();

            try
            {
                ArrayList retList;

                int status = this._moneyKindAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (MoneyKind moneyKind in retList)
                    {
                        // ���z�ݒ�敪���u0:�����v���g�p
                        if ((moneyKind.LogicalDeleteCode == 0) && (moneyKind.PriceStCode == 0))
                        {
                            this._moneyKindDic.Add(moneyKind.MoneyKindCode, moneyKind);
                        }
                    }
                }
            }
            catch
            {
                this._moneyKindDic = new Dictionary<int, MoneyKind>();
            }
        }

        /// <summary>
        /// �S�̍��ڕ\�����̐ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �S�̍��ڕ\�����̐ݒ�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadAlItmDspNm()
        {
            try
            {
                int status = this._alItmDspNmAcs.Read(out this._alItmDspNm, LoginInfoAcquisition.EnterpriseCode);
                if (status != 0)
                {
                    this._alItmDspNm = new AlItmDspNm();
                }
            }
            catch
            {
                this._alItmDspNm = new AlItmDspNm();
            }
        }

        /// <summary>
        /// �E��f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadJobTypeCode()
        {
            this._jobTypeDic = new Dictionary<int, string>();

            ReadUserGdBd(34, ref this._jobTypeDic);
        }

        /// <summary>
        /// �Ǝ�f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadBusinessTypeCode()
        {
            this._businessTypeDic = new Dictionary<int, string>();

            ReadUserGdBd(33, ref this._businessTypeDic);
        }

        /// <summary>
        /// �n��f�[�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private void ReadSalesAreaCode()
        {
            this._salesAreaDic = new Dictionary<int, string>();

            ReadUserGdBd(21, ref this._salesAreaDic);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�Ǎ�����
        /// </summary>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <param name="targetDic">�Ώ�Dictionary</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private int ReadUserGdBd(int userGuideDivCd, ref Dictionary<int, string> targetDic)
        {
            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, LoginInfoAcquisition.EnterpriseCode,
                                                                     userGuideDivCd, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            targetDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                targetDic = new Dictionary<int, string>();
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// ����������X�g�擾����
        /// </summary>
        /// <returns>����������X�g</returns>
        /// <remarks>
        /// <br>Note       : �����ݒ�}�X�^�A���z��ʐݒ�}�X�^������������X�g���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public Dictionary<int, string> GetCollectCondDic()
        {
            Dictionary<int, string> collctCondDic = new Dictionary<int, string>();

            // �����ݒ����R�[�h1
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd1))
            {
                depositStKindCd1 = this._depositSt.DepositStKindCd1;    // 2010/07/14 Add
                collctCondDic.Add(this._depositSt.DepositStKindCd1, this._moneyKindDic[this._depositSt.DepositStKindCd1].MoneyKindName);
            }
            // �����ݒ����R�[�h2
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd2))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd2, this._moneyKindDic[this._depositSt.DepositStKindCd2].MoneyKindName);
            }
            // �����ݒ����R�[�h3
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd3))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd3, this._moneyKindDic[this._depositSt.DepositStKindCd3].MoneyKindName);
            }
            // �����ݒ����R�[�h4
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd4))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd4, this._moneyKindDic[this._depositSt.DepositStKindCd4].MoneyKindName);
            }
            // �����ݒ����R�[�h5
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd5))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd5, this._moneyKindDic[this._depositSt.DepositStKindCd5].MoneyKindName);
            }
            // �����ݒ����R�[�h6
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd6))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd6, this._moneyKindDic[this._depositSt.DepositStKindCd6].MoneyKindName);
            }
            // �����ݒ����R�[�h7
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd7))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd7, this._moneyKindDic[this._depositSt.DepositStKindCd7].MoneyKindName);
            }
            // �����ݒ����R�[�h8
            if (this._moneyKindDic.ContainsKey(this._depositSt.DepositStKindCd8))
            {
                collctCondDic.Add(this._depositSt.DepositStKindCd8, this._moneyKindDic[this._depositSt.DepositStKindCd8].MoneyKindName);
            }

            return collctCondDic;
        }

        #endregion �� Private Methods
    }
}
