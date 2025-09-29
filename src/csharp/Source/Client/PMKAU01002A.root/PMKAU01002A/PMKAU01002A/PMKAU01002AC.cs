//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R���[(������)����f�[�^����N���X
// �v���O�����T�v   : ���R���[(������)����f�[�^����N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570183-00   �쐬�S�� : ���O
// �� �� ��  2022/03/07    �C�����e : ���������s(�d�q����A�g)�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870080-00   �쐬�S�� : ���O
// �� �� ��  2022/04/21    �C�����e : �d�q����2���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11870141-00   �쐬�S�� : �c������
// �� �� ��  2022/10/18    �C�����e : �C���{�C�X�c�Ή��i�y���ŗ��Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11970040-00   �쐬�S�� : 3H ����
// �� �� ��  2023/04/14    �C�����e : ���R���[���ڒǉ��Ή�
//                                    �@����`�[�v���z(�ō���)
//                                    �A�����(�`�[�]��)/����`�[�v���z(�ō���)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11900025-00   �쐬�S�� : �c������
// �� �� ��  2023/06/16    �C�����e : �y���ŗ��s��Ή�
//                                    �u�L���X�g���L���ł͂���܂���v��O�����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11900025-00   �쐬�S�� : 3H ����
// �� �� ��  2023/06/23    �C�����e : ����œ]�Łu�����q�v�̐ŗ��ʐŊz�s��Ή�
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
//using System.Windows.Forms;
//using System.Drawing.Printing;
using System.Collections.Generic;
using System.Diagnostics;
//using ar=DataDynamics.ActiveReports;
//using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
//using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���R���[(������)����f�[�^����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : ��������ɓn���e�[�u���̐������s���܂��B�i�P�������P�ʂ̈�����䏈���j</br>
    /// <br>               static�t�B�[���h�^���\�b�h�����̃N���X�Ɏ������܂��B</br>
    /// <br>               �y���(P)����call���܂��z</br>
    /// <br>               </br>
    /// <br>Programmer   : ���O</br>
    /// <br>Date         : 2022/03/07</br>
    /// <br>Update Note  : 2022/04/21 ���O</br>
    /// <br>�Ǘ��ԍ�     : 11870080-00 �d�q����2���Ή�</br>  
    /// <br>Update Note  : 2022/10/18 �c������</br>
    /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br> 
    /// <br>Update Note  : 2023/04/14 3H ����</br>
    /// <br>�Ǘ��ԍ�     : 11970040-00 ���R���[���ڒǉ��Ή�</br>
    /// <br>               �@����`�[�v���z(�ō���)</br>
    /// <br>               �A�����(�`�[�]��)/����`�[�v���z(�ō���)</br>
    /// <br>Update Note  : 2023/06/23 3H ����</br>
    /// <br>�Ǘ��ԍ�     : 11900025-00 ����œ]�Łu�����q�v�̐ŗ��ʐŊz�s��Ή�</br>
    /// </remarks>
    public class PMKAU01002AC
    {
        # region [private const]
        // ����������
        private const string ct_LastDayString = "��";

        private static int _slipNote2PrtCnt = 0;

        private static bool _modelHalfNameDtl3PrtFlg = false;
        private static string _modelHalfNameDtl1 = "";
        private static bool _carMngNo2PrtFlg = false;
        private static string _carMngNo2Dtl1 = "";

        private static int _pageCount = 0;
        # endregion

        # region [public static readonly]
        /// <summary>����������f�[�^�e�[�u��</summary>
        public static readonly string CT_Tbl_PrintData = "PrintData";
        /// <summary>����y�[�W�����ʃJ�E���g�@�J����</summary>
        public static readonly string ct_col_InpageCount = "PMKAU01002AC.InpageCount";
        /// <summary>�y�[�W��</summary>
        public static readonly string ct_col_PageCount = "PAGE.PAGECOUNTRF";
        /// <summary>����Ń^�C�g��</summary>
        public static readonly string ct_col_TaxTitle = "PMKAU01002AC.TAXTITLE";
        /// <summary>���E�㔄�㍇�v���z(�ō�)�^�C�g�� </summary>
        public static readonly string ct_col_OfsThisSalesTaxIncTtl = "PMKAU08002C.OFSTHISSALESTAXINCTTL";

        /// <summary>�v��N����(����)</summary>
        public static readonly string ct_col_Last_AddUpDate = "LAST.ADDUPDATERF";
        /// <summary>�����X�V�J�n�N����(����)</summary>
        public static readonly string ct_col_Last_StartCAddUpUpdDate = "LAST.STARTCADDUPUPDDATERF";
        /// <summary>���������s��(����)</summary>
        public static readonly string ct_col_Last_BillPrintDate = "LAST.BILLPRINTDATERF";
        /// <summary>�����\���(����)</summary>
        public static readonly string ct_col_Last_ExpectedDepositDate = "LAST.EXPECTEDDEPOSITDATERF";
        /// <summary>���͔��s���t(����)</summary>
        public static readonly string ct_col_Last_IssueDay = "LAST.ISSUEDAYRF";
        /// <summary>�W����(����)</summary>
        public static readonly string ct_col_Last_CollectMoneyDay = "LAST.COLLECTMONEYDAYRF";

        /// <summary>(�\�[�g�p)���Ӑ�R�[�h</summary>
        public static readonly string ct_col_Sort_CustomerCode = "SORT.CUSTOMERCODE";
        /// <summary>(�\�[�g�p)���t</summary>
        public static readonly string ct_col_Sort_Date = "SORT.DATE";
        /// <summary>(�\�[�g�p)���R�[�h�敪</summary>
        public static readonly string ct_col_Sort_RecordDiv = "SORT.RECORDDIV";
        /// <summary>(�\�[�g�p)����`�[�ԍ�</summary>
        public static readonly string ct_col_Sort_SalesSlipNo = "SORT.SALESSLIPNO";
        /// <summary>(�\�[�g�p)�����`�[�ԍ�</summary>
        public static readonly string ct_col_Sort_DepositSlipNo = "SORT.DEPOSITSLIPNO";
        /// <summary>(�\�[�g�p)���׋敪</summary>
        public static readonly string ct_col_Sort_DetailDiv = "SORT.DETAILDIV";
        /// <summary>(�\�[�g�p)���׍s�ԍ�</summary>
        public static readonly string ct_col_Sort_DetailRowNo = "SORT.DETAILROWNO";
        /// <summary>(�\�[�g�p)���R�[�h�敪(��s�Ō�)</summary>
        public static readonly string ct_col_Sort_RecordDiv_EmptyDetail = "SORT.RECORDDIV_EMPTYDETAIL";
        /// <summary>(����p)�����t�b�^�`�[�E�v</summary>
        public static readonly string ct_col_DDep_DepFtOutLine = "DDEP.DEPFTOUTLINERF";
        /// <summary>(����p)�O�񐿋����z(�O��̂�)</summary>
        public static readonly string ct_col_HDmd_LastTimeDemandOrg = "HDMD.LASTTIMEDEMANDORGRF";

        /// <summary>(����p)�������דE�v(�艿)</summary>
        public static readonly string ct_col_DAdd_DmdDtlOutLineRF_ListPrice = "DADD.DMDDTLOUTLINERF_LISTPRICE";
      
        /// <summary>����ԕi�l���z�i����ԕi�{����l���j</summary>
        public static readonly string ct_col_ThisTimeRetDis = "HADD.THISTIMERETDISRF";

        /// <summary>�����\���(�N���� ����4��)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx1 = "HADD.EXPECTEDDEPOSITDATEEX1RF";
        /// <summary>�����\���(�N���� ����2��)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx2 = "HADD.EXPECTEDDEPOSITDATEEX2RF";
        /// <summary>�����\���(/ ����4��)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx3 = "HADD.EXPECTEDDEPOSITDATEEX3RF";
        /// <summary>�����\���(/ ����2��)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx4 = "HADD.EXPECTEDDEPOSITDATEEX4RF";
        /// <summary>�����\���(. ����4��)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx5 = "HADD.EXPECTEDDEPOSITDATEEX5RF";
        /// <summary>�����\���(. ����2��)</summary>
        public static readonly string ct_col_ExpectedDepositDateEx6 = "HADD.EXPECTEDDEPOSITDATEEX6RF";

        /// <summary>�v��N����(�N���� ����4��)</summary>
        public static readonly string ct_col_AddUpDateEx1 = "HADD.ADDUPDATEEX1RF";
        /// <summary>�v��N����(�N���� ����2��)</summary>
        public static readonly string ct_col_AddUpDateEx2 = "HADD.ADDUPDATEEX2RF";
        /// <summary>�v��N����(/ ����4��)</summary>
        public static readonly string ct_col_AddUpDateEx3 = "HADD.ADDUPDATEEX3RF";
        /// <summary>�v��N����(/ ����2��)</summary>
        public static readonly string ct_col_AddUpDateEx4 = "HADD.ADDUPDATEEX4RF";
        /// <summary>�v��N����(. ����4��)</summary>
        public static readonly string ct_col_AddUpDateEx5 = "HADD.ADDUPDATEEX5RF";
        /// <summary>�v��N����(. ����2��)</summary>
        public static readonly string ct_col_AddUpDateEx6 = "HADD.ADDUPDATEEX6RF";

        /// <summary>�����X�V�J�n�N����(�N���� ����4��)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx1 = "HADD.STARTCADDUPUPDDATEEX1RF";
        /// <summary>�����X�V�J�n�N����(�N���� ����2��)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx2 = "HADD.STARTCADDUPUPDDATEEX2RF";
        /// <summary>�����X�V�J�n�N����(/ ����4��)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx3 = "HADD.STARTCADDUPUPDDATEEX3RF";
        /// <summary>�����X�V�J�n�N����(/ ����2��)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx4 = "HADD.STARTCADDUPUPDDATEEX4RF";
        /// <summary>�����X�V�J�n�N����(. ����4��)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx5 = "HADD.STARTCADDUPUPDDATEEX5RF";
        /// <summary>�����X�V�J�n�N����(. ����2��)</summary>
        public static readonly string ct_col_StartCAddUpUpdDateEx6 = "HADD.STARTCADDUPUPDDATEEX6RF";

        /// <summary>���������s��(�N���� ����4��)</summary>
        public static readonly string ct_col_BillPrintDateEx1 = "HADD.BILLPRINTDATEEX1RF";
        /// <summary>���������s��(�N���� ����2��)</summary>
        public static readonly string ct_col_BillPrintDateEx2 = "HADD.BILLPRINTDATEEX2RF";
        /// <summary>���������s��(/ ����4��)</summary>
        public static readonly string ct_col_BillPrintDateEx3 = "HADD.BILLPRINTDATEEX3RF";
        /// <summary>���������s��(/ ����2��)</summary>
        public static readonly string ct_col_BillPrintDateEx4 = "HADD.BILLPRINTDATEEX4RF";
        /// <summary>���������s��(. ����4��)</summary>
        public static readonly string ct_col_BillPrintDateEx5 = "HADD.BILLPRINTDATEEX5RF";
        /// <summary>���������s��(. ����2��)</summary>
        public static readonly string ct_col_BillPrintDateEx6 = "HADD.BILLPRINTDATEEX6RF";

        /// <summary>���͔��s���t(�N���� ����4��)</summary>
        public static readonly string ct_col_IssueDayEx1 = "HADD.ISSUEDAYEX1RF";
        /// <summary>���͔��s���t(�N���� ����2��)</summary>
        public static readonly string ct_col_IssueDayEx2 = "HADD.ISSUEDAYEX2RF";
        /// <summary>���͔��s���t(/ ����4��)</summary>
        public static readonly string ct_col_IssueDayEx3 = "HADD.ISSUEDAYEX3RF";
        /// <summary>���͔��s���t(/ ����2��)</summary>
        public static readonly string ct_col_IssueDayEx4 = "HADD.ISSUEDAYEX4RF";
        /// <summary>���͔��s���t(. ����4��)</summary>
        public static readonly string ct_col_IssueDayEx5 = "HADD.ISSUEDAYEX5RF";
        /// <summary>���͔��s���t(. ����2��)</summary>
        public static readonly string ct_col_IssueDayEx6 = "HADD.ISSUEDAYEX6RF";

        /// <summary>���햼��(��߰�����)</summary>
        public static readonly string ct_col_DDep_MoneyKindNameSp = "DDEP.MONEYKINDNAMESPRF";

        // --- ADD START �c������ 2022/10/18 ----->>>>>
        private static PriceTaxCalculator stc_priceTaxCalculator;
        // --- ADD END   �c������ 2022/10/18 -----<<<<<

        # endregion

        private static Dictionary<string, string> stc_reportItemDic;

        /// <summary>
        /// ReportItemDic
        /// </summary>
        public static Dictionary<string, string> ReportItemDic
        {
            get
            {
                if (stc_reportItemDic == null)
                {
                    stc_reportItemDic = new Dictionary<string, string>();
                }
                return stc_reportItemDic;
            }
            set { stc_reportItemDic = value; }
        }

        # region [�f�[�^�e�[�u����������]
        /// <summary>
        /// �f�[�^�e�[�u�����������i����e�[�u���X�L�[�}��`�j
        /// </summary>
        /// <returns>�f�[�^�e�[�u��</returns>
        /// <remarks>
        /// <br>Note        : �f�[�^�e�[�u�����������i����e�[�u���X�L�[�}��`�j</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note    :  2022/10/18  �c������</br>
        /// <br>�Ǘ��ԍ�   :  11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Update Note  : 2023/04/14 3H ����</br>
        /// <br>�Ǘ��ԍ�     : 11970040-00 ���R���[���ڒǉ��Ή�</br>
        /// <br>               �@����`�[�v���z(�ō���)</br>
        /// <br>               �A�����(�`�[�]��)/����`�[�v���z(�ō���)</br>
        /// </remarks>
        public static DataTable CreatePrintDataTable()
        {
            DataTable table = new DataTable( CT_Tbl_PrintData );

            # region [�X�L�[�}��`�i�w�b�_���j]
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ADDUPSECCODERF", typeof( String ) ) ); // �v�㋒�_�R�[�h
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CLAIMCODERF", typeof( Int32 ) ) ); // ������R�[�h
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CLAIMNAMERF", typeof( String ) ) ); // �����於��
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CLAIMNAME2RF", typeof( String ) ) ); // �����於��2
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CLAIMSNMRF", typeof( String ) ) ); // �����旪��
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CUSTOMERCODERF", typeof( Int32 ) ) ); // ���Ӑ�R�[�h
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CUSTOMERNAMERF", typeof( String ) ) ); // ���Ӑ於��
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CUSTOMERNAME2RF", typeof( String ) ) ); // ���Ӑ於��2
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CUSTOMERSNMRF", typeof( String ) ) ); // ���Ӑ旪��
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ADDUPDATERF", typeof( Int32 ) ) ); // �v��N����
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ADDUPYEARMONTHRF", typeof( Int32 ) ) ); // �v��N��
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.LASTTIMEDEMANDRF", typeof( Int64 ) ) ); // �O�񐿋����z
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF", typeof( Int64 ) ) ); // ����萔���z�i�ʏ�����j
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF", typeof( Int64 ) ) ); // ����l���z�i�ʏ�����j
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMEDMDNRMLRF", typeof( Int64 ) ) ); // ����������z�i�ʏ�����j
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMETTLBLCDMDRF", typeof( Int64 ) ) ); // ����J�z�c���i�����v�j
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.OFSTHISTIMESALESRF", typeof( Int64 ) ) ); // ���E�㍡�񔄏���z
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.OFSTHISSALESTAXRF", typeof( Int64 ) ) ); // ���E�㍡�񔄏�����
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF", typeof( Int64 ) ) ); // ���E��O�őΏۊz
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDOFFSETINTAXRF", typeof( Int64 ) ) ); // ���E����őΏۊz
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF", typeof( Int64 ) ) ); // ���E���ېőΏۊz
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.OFFSETOUTTAXRF", typeof( Int64 ) ) ); // ���E��O�ŏ����
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.OFFSETINTAXRF", typeof( Int64 ) ) ); // ���E����ŏ����
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISTIMESALESRF", typeof( Int64 ) ) ); // ���񔄏���z
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESTAXRF", typeof( Int64 ) ) ); // ���񔄏�����
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDSALESOUTTAXRF", typeof( Int64 ) ) ); // ����O�őΏۊz
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDSALESINTAXRF", typeof( Int64 ) ) ); // ������őΏۊz
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ITDEDSALESTAXFREERF", typeof( Int64 ) ) ); // �����ېőΏۊz
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.SALESOUTTAXRF", typeof( Int64 ) ) ); // ����O�Ŋz
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.SALESINTAXRF", typeof( Int64 ) ) ); // ������Ŋz
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESPRICRGDSRF", typeof( Int64 ) ) ); // ���񔄏�ԕi���z
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF", typeof( Int64 ) ) ); // ���񔄏�ԕi�����
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDRETOUTTAXRF", typeof( Int64 ) ) ); // �ԕi�O�őΏۊz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDRETINTAXRF", typeof( Int64 ) ) ); // �ԕi���őΏۊz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDRETTAXFREERF", typeof( Int64 ) ) ); // �ԕi��ېőΏۊz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLRETOUTERTAXRF", typeof( Int64 ) ) ); // �ԕi�O�Ŋz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLRETINNERTAXRF", typeof( Int64 ) ) ); // �ԕi���Ŋz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESPRICDISRF", typeof( Int64 ) ) ); // ���񔄏�l�����z
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.THISSALESPRCTAXDISRF", typeof( Int64 ) ) ); // ���񔄏�l�������
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDDISOUTTAXRF", typeof( Int64 ) ) ); // �l���O�őΏۊz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDDISINTAXRF", typeof( Int64 ) ) ); // �l�����őΏۊz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLITDEDDISTAXFREERF", typeof( Int64 ) ) ); // �l����ېőΏۊz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLDISOUTERTAXRF", typeof( Int64 ) ) ); // �l���O�Ŋz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TTLDISINNERTAXRF", typeof( Int64 ) ) ); // �l�����Ŋz���v
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.TAXADJUSTRF", typeof( Int64 ) ) ); // ����Œ����z
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.BALANCEADJUSTRF", typeof( Int64 ) ) ); // �c�������z
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.AFCALDEMANDPRICERF", typeof( Int64 ) ) ); // �v�Z�㐿�����z
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF", typeof( Int64 ) ) ); // ��2��O�c���i�����v�j
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF", typeof( Int64 ) ) ); // ��3��O�c���i�����v�j
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.STARTCADDUPUPDDATERF", typeof( Int32 ) ) ); // �����X�V�J�n�N����
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.SALESSLIPCOUNTRF", typeof( Int32 ) ) ); // ����`�[����
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.BILLPRINTDATERF", typeof( Int32 ) ) ); // ���������s��
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.EXPECTEDDEPOSITDATERF", typeof( Int32 ) ) ); // �����\���
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.COLLECTCONDRF", typeof( Int32 ) ) ); // �������
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CONSTAXLAYMETHODRF", typeof( Int32 ) ) ); // ����œ]�ŕ���
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.CONSTAXRATERF", typeof( Double ) ) ); // ����ŗ�
            table.Columns.Add( new DataColumn( "SECHED.SECTIONGUIDENMRF", typeof( String ) ) ); // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "SECHED.SECTIONGUIDESNMRF", typeof( String ) ) ); // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "SECHED.COMPANYNAMECD1RF", typeof( Int32 ) ) ); // ���Ж��̃R�[�h1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRRF", typeof( String ) ) ); // ����PR��
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME1RF", typeof( String ) ) ); // ���Ж���1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME2RF", typeof( String ) ) ); // ���Ж���2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.POSTNORF", typeof( String ) ) ); // �X�֔ԍ�
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS1RF", typeof( String ) ) ); // �Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS3RF", typeof( String ) ) ); // �Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS4RF", typeof( String ) ) ); // �Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO1RF", typeof( String ) ) ); // ���Гd�b�ԍ�1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO2RF", typeof( String ) ) ); // ���Гd�b�ԍ�2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO3RF", typeof( String ) ) ); // ���Гd�b�ԍ�3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE1RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE2RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE3RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.TRANSFERGUIDANCERF", typeof( String ) ) ); // ��s�U���ē���
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO1RF", typeof( String ) ) ); // ��s����1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO2RF", typeof( String ) ) ); // ��s����2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO3RF", typeof( String ) ) ); // ��s����3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE1RF", typeof( String ) ) ); // ���Аݒ�E�v1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE2RF", typeof( String ) ) ); // ���Аݒ�E�v2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGEINFOCODERF", typeof( Int32 ) ) ); // �摜���R�[�h
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYURLRF", typeof( String ) ) ); // ����URL
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRSENTENCE2RF", typeof( String ) ) ); // ����PR��2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT1RF", typeof( String ) ) ); // �摜�󎚗p�R�����g1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT2RF", typeof( String ) ) ); // �摜�󎚗p�R�����g2
            table.Columns.Add( new DataColumn( "IMAGEINFORF.IMAGEINFODATARF", typeof( Byte[] ) ) ); // �摜���f�[�^
            table.Columns.Add( new DataColumn( "CSTCST.CUSTOMERSUBCODERF", typeof( String ) ) ); // ���Ӑ�T�u�R�[�h
            table.Columns.Add( new DataColumn( "CSTCST.NAMERF", typeof( String ) ) ); // ���Ӑ於��
            table.Columns.Add( new DataColumn( "CSTCST.NAME2RF", typeof( String ) ) ); // ���Ӑ於��2
            table.Columns.Add( new DataColumn( "CSTCST.HONORIFICTITLERF", typeof( String ) ) ); // ���Ӑ�h��
            table.Columns.Add( new DataColumn( "CSTCST.KANARF", typeof( String ) ) ); // ���Ӑ�J�i
            table.Columns.Add( new DataColumn( "CSTCST.CUSTOMERSNMRF", typeof( String ) ) ); // ���Ӑ旪��
            table.Columns.Add( new DataColumn( "CSTCST.OUTPUTNAMECODERF", typeof( Int32 ) ) ); // ���Ӑ揔���R�[�h
            table.Columns.Add( new DataColumn( "CSTCST.POSTNORF", typeof( String ) ) ); // ���Ӑ�X�֔ԍ�
            table.Columns.Add( new DataColumn( "CSTCST.ADDRESS1RF", typeof( String ) ) ); // ���Ӑ�Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "CSTCST.ADDRESS3RF", typeof( String ) ) ); // ���Ӑ�Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "CSTCST.ADDRESS4RF", typeof( String ) ) ); // ���Ӑ�Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE1RF", typeof( Int32 ) ) ); // ���Ӑ敪�̓R�[�h1
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE2RF", typeof( Int32 ) ) ); // ���Ӑ敪�̓R�[�h2
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE3RF", typeof( Int32 ) ) ); // ���Ӑ敪�̓R�[�h3
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE4RF", typeof( Int32 ) ) ); // ���Ӑ敪�̓R�[�h4
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE5RF", typeof( Int32 ) ) ); // ���Ӑ敪�̓R�[�h5
            table.Columns.Add( new DataColumn( "CSTCST.CUSTANALYSCODE6RF", typeof( Int32 ) ) ); // ���Ӑ敪�̓R�[�h6
            table.Columns.Add( new DataColumn( "CSTCST.NOTE1RF", typeof( String ) ) ); // ���Ӑ���l1
            table.Columns.Add( new DataColumn( "CSTCST.NOTE2RF", typeof( String ) ) ); // ���Ӑ���l2
            table.Columns.Add( new DataColumn( "CSTCST.NOTE3RF", typeof( String ) ) ); // ���Ӑ���l3
            table.Columns.Add( new DataColumn( "CSTCST.NOTE4RF", typeof( String ) ) ); // ���Ӑ���l4
            table.Columns.Add( new DataColumn( "CSTCST.NOTE5RF", typeof( String ) ) ); // ���Ӑ���l5
            table.Columns.Add( new DataColumn( "CSTCST.NOTE6RF", typeof( String ) ) ); // ���Ӑ���l6
            table.Columns.Add( new DataColumn( "CSTCST.NOTE7RF", typeof( String ) ) ); // ���Ӑ���l7
            table.Columns.Add( new DataColumn( "CSTCST.NOTE8RF", typeof( String ) ) ); // ���Ӑ���l8
            table.Columns.Add( new DataColumn( "CSTCST.NOTE9RF", typeof( String ) ) ); // ���Ӑ���l9
            table.Columns.Add( new DataColumn( "CSTCST.NOTE10RF", typeof( String ) ) ); // ���Ӑ���l10
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTOMERSUBCODERF", typeof( String ) ) ); // ������T�u�R�[�h
            table.Columns.Add( new DataColumn( "CSTCLM.NAMERF", typeof( String ) ) ); // �����於��
            table.Columns.Add( new DataColumn( "CSTCLM.NAME2RF", typeof( String ) ) ); // �����於��2
            table.Columns.Add( new DataColumn( "CSTCLM.HONORIFICTITLERF", typeof( String ) ) ); // ������h��
            table.Columns.Add( new DataColumn( "CSTCLM.KANARF", typeof( String ) ) ); // ������J�i
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTOMERSNMRF", typeof( String ) ) ); // �����旪��
            table.Columns.Add( new DataColumn( "CSTCLM.OUTPUTNAMECODERF", typeof( Int32 ) ) ); // �����揔���R�[�h
            table.Columns.Add( new DataColumn( "CSTCLM.POSTNORF", typeof( String ) ) ); // ������X�֔ԍ�
            table.Columns.Add( new DataColumn( "CSTCLM.ADDRESS1RF", typeof( String ) ) ); // ������Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "CSTCLM.ADDRESS3RF", typeof( String ) ) ); // ������Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "CSTCLM.ADDRESS4RF", typeof( String ) ) ); // ������Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE1RF", typeof( Int32 ) ) ); // �����敪�̓R�[�h1
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE2RF", typeof( Int32 ) ) ); // �����敪�̓R�[�h2
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE3RF", typeof( Int32 ) ) ); // �����敪�̓R�[�h3
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE4RF", typeof( Int32 ) ) ); // �����敪�̓R�[�h4
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE5RF", typeof( Int32 ) ) ); // �����敪�̓R�[�h5
            table.Columns.Add( new DataColumn( "CSTCLM.CUSTANALYSCODE6RF", typeof( Int32 ) ) ); // �����敪�̓R�[�h6
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE1RF", typeof( String ) ) ); // ��������l1
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE2RF", typeof( String ) ) ); // ��������l2
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE3RF", typeof( String ) ) ); // ��������l3
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE4RF", typeof( String ) ) ); // ��������l4
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE5RF", typeof( String ) ) ); // ��������l5
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE6RF", typeof( String ) ) ); // ��������l6
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE7RF", typeof( String ) ) ); // ��������l7
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE8RF", typeof( String ) ) ); // ��������l8
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE9RF", typeof( String ) ) ); // ��������l9
            table.Columns.Add( new DataColumn( "CSTCLM.NOTE10RF", typeof( String ) ) ); // ��������l10
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME1RF", typeof( String ) ) ); // ���Ж���1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME2RF", typeof( String ) ) ); // ���Ж���2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.POSTNORF", typeof( String ) ) ); // �X�֔ԍ�
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS1RF", typeof( String ) ) ); // �Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS3RF", typeof( String ) ) ); // �Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS4RF", typeof( String ) ) ); // �Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO1RF", typeof( String ) ) ); // ���Гd�b�ԍ�1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO2RF", typeof( String ) ) ); // ���Гd�b�ԍ�2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO3RF", typeof( String ) ) ); // ���Гd�b�ԍ�3
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE1RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE2RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE3RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��3
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD1RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h1
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD2RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h2
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD3RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h3
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD4RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h4
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD5RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h5
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD6RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h6
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD7RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h7
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD8RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h8
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD9RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h9
            table.Columns.Add( new DataColumn( "DEPOSITSTRF.DEPOSITSTKINDCD10RF", typeof( Int32 ) ) ); // �����ݒ����R�[�h10
            table.Columns.Add( new DataColumn( "DEPT01.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��1
            table.Columns.Add( new DataColumn( "DEPT01.DEPOSITRF", typeof( Int64 ) ) ); // �������z1
            table.Columns.Add( new DataColumn( "DEPT02.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��2
            table.Columns.Add( new DataColumn( "DEPT02.DEPOSITRF", typeof( Int64 ) ) ); // �������z2
            table.Columns.Add( new DataColumn( "DEPT03.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��3
            table.Columns.Add( new DataColumn( "DEPT03.DEPOSITRF", typeof( Int64 ) ) ); // �������z3
            table.Columns.Add( new DataColumn( "DEPT04.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��4
            table.Columns.Add( new DataColumn( "DEPT04.DEPOSITRF", typeof( Int64 ) ) ); // �������z4
            table.Columns.Add( new DataColumn( "DEPT05.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��5
            table.Columns.Add( new DataColumn( "DEPT05.DEPOSITRF", typeof( Int64 ) ) ); // �������z5
            table.Columns.Add( new DataColumn( "DEPT06.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��6
            table.Columns.Add( new DataColumn( "DEPT06.DEPOSITRF", typeof( Int64 ) ) ); // �������z6
            table.Columns.Add( new DataColumn( "DEPT07.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��7
            table.Columns.Add( new DataColumn( "DEPT07.DEPOSITRF", typeof( Int64 ) ) ); // �������z7
            table.Columns.Add( new DataColumn( "DEPT08.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��8
            table.Columns.Add( new DataColumn( "DEPT08.DEPOSITRF", typeof( Int64 ) ) ); // �������z8
            table.Columns.Add( new DataColumn( "DEPT09.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��9
            table.Columns.Add( new DataColumn( "DEPT09.DEPOSITRF", typeof( Int64 ) ) ); // �������z9
            table.Columns.Add( new DataColumn( "DEPT10.MONEYKINDNAMERF", typeof( String ) ) ); // �������햼��10
            table.Columns.Add( new DataColumn( "DEPT10.DEPOSITRF", typeof( Int64 ) ) ); // �������z10
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFYRF", typeof( Int32 ) ) ); // �v��N��������N
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFSRF", typeof( Int32 ) ) ); // �v��N��������N��
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFWRF", typeof( Int32 ) ) ); // �v��N�����a��N
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFMRF", typeof( Int32 ) ) ); // �v��N������
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFDRF", typeof( Int32 ) ) ); // �v��N������
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFGRF", typeof( String ) ) ); // �v��N��������
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFRRF", typeof( String ) ) ); // �v��N��������
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLSRF", typeof( String ) ) ); // �v��N�������e����(/)
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLPRF", typeof( String ) ) ); // �v��N�������e����(.)
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLYRF", typeof( String ) ) ); // �v��N�������e����(�N)
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLMRF", typeof( String ) ) ); // �v��N�������e����(��)
            table.Columns.Add( new DataColumn( "HADD.ADDUPDATEFLDRF", typeof( String ) ) ); // �v��N�������e����(��)
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFYRF", typeof( Int32 ) ) ); // �v��N������N
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFSRF", typeof( Int32 ) ) ); // �v��N������N��
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFWRF", typeof( Int32 ) ) ); // �v��N���a��N
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFMRF", typeof( Int32 ) ) ); // �v��N����
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFGRF", typeof( String ) ) ); // �v��N������
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFRRF", typeof( String ) ) ); // �v��N������
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFLSRF", typeof( String ) ) ); // �v��N�����e����(/)
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFLPRF", typeof( String ) ) ); // �v��N�����e����(.)
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFLYRF", typeof( String ) ) ); // �v��N�����e����(�N)
            table.Columns.Add( new DataColumn( "HADD.ADDUPYEARMONTHFLMRF", typeof( String ) ) ); // �v��N�����e����(��)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFYRF", typeof( Int32 ) ) ); // �����X�V�J�n�N��������N
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFSRF", typeof( Int32 ) ) ); // �����X�V�J�n�N��������N��
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFWRF", typeof( Int32 ) ) ); // �����X�V�J�n�N�����a��N
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFMRF", typeof( Int32 ) ) ); // �����X�V�J�n�N������
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFDRF", typeof( Int32 ) ) ); // �����X�V�J�n�N������
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFGRF", typeof( String ) ) ); // �����X�V�J�n�N��������
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFRRF", typeof( String ) ) ); // �����X�V�J�n�N��������
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLSRF", typeof( String ) ) ); // �����X�V�J�n�N�������e����(/)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLPRF", typeof( String ) ) ); // �����X�V�J�n�N�������e����(.)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLYRF", typeof( String ) ) ); // �����X�V�J�n�N�������e����(�N)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLMRF", typeof( String ) ) ); // �����X�V�J�n�N�������e����(��)
            table.Columns.Add( new DataColumn( "HADD.STARTCADDUPUPDDATEFLDRF", typeof( String ) ) ); // �����X�V�J�n�N�������e����(��)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFYRF", typeof( Int32 ) ) ); // ���������s������N
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFSRF", typeof( Int32 ) ) ); // ���������s������N��
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFWRF", typeof( Int32 ) ) ); // ���������s���a��N
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFMRF", typeof( Int32 ) ) ); // ���������s����
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFDRF", typeof( Int32 ) ) ); // ���������s����
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFGRF", typeof( String ) ) ); // ���������s������
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFRRF", typeof( String ) ) ); // ���������s������
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLSRF", typeof( String ) ) ); // ���������s�����e����(/)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLPRF", typeof( String ) ) ); // ���������s�����e����(.)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLYRF", typeof( String ) ) ); // ���������s�����e����(�N)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLMRF", typeof( String ) ) ); // ���������s�����e����(��)
            table.Columns.Add( new DataColumn( "HADD.BILLPRINTDATEFLDRF", typeof( String ) ) ); // ���������s�����e����(��)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFYRF", typeof( Int32 ) ) ); // �����\�������N
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFSRF", typeof( Int32 ) ) ); // �����\�������N��
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFWRF", typeof( Int32 ) ) ); // �����\����a��N
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFMRF", typeof( Int32 ) ) ); // �����\�����
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFDRF", typeof( Int32 ) ) ); // �����\�����
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFGRF", typeof( String ) ) ); // �����\�������
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFRRF", typeof( String ) ) ); // �����\�������
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLSRF", typeof( String ) ) ); // �����\������e����(/)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLPRF", typeof( String ) ) ); // �����\������e����(.)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLYRF", typeof( String ) ) ); // �����\������e����(�N)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLMRF", typeof( String ) ) ); // �����\������e����(��)
            table.Columns.Add( new DataColumn( "HADD.EXPECTEDDEPOSITDATEFLDRF", typeof( String ) ) ); // �����\������e����(��)
            table.Columns.Add( new DataColumn( "HADD.COLLECTCONDNMRF", typeof( String ) ) ); // �����������
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE1RF", typeof( String ) ) ); // ���� �Ӄ^�C�g���P
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE2RF", typeof( String ) ) ); // ���� �Ӄ^�C�g���Q
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE3RF", typeof( String ) ) ); // ���� �Ӄ^�C�g���R
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE4RF", typeof( String ) ) ); // ���� �Ӄ^�C�g���S
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE5RF", typeof( String ) ) ); // ���� �Ӄ^�C�g���T
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE6RF", typeof( String ) ) ); // ���� �Ӄ^�C�g���U
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE7RF", typeof( String ) ) ); // ���� �Ӄ^�C�g���V
            table.Columns.Add( new DataColumn( "HADD.DMDTTLFORMTITLE8RF", typeof( String ) ) ); // ���� �Ӄ^�C�g���W
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM1RF", typeof( Int64 ) ) ); // ���� �Ӌ��z���ڂP
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM2RF", typeof( Int64 ) ) ); // ���� �Ӌ��z���ڂQ
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM3RF", typeof( Int64 ) ) ); // ���� �Ӌ��z���ڂR
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM4RF", typeof( Int64 ) ) ); // ���� �Ӌ��z���ڂS
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM5RF", typeof( Int64 ) ) ); // ���� �Ӌ��z���ڂT
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM6RF", typeof( Int64 ) ) ); // ���� �Ӌ��z���ڂU
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM7RF", typeof( Int64 ) ) ); // ���� �Ӌ��z���ڂV
            table.Columns.Add( new DataColumn( "HADD.DMDTTLSETITEM8RF", typeof( Int64 ) ) ); // ���� �Ӌ��z���ڂW
            table.Columns.Add( new DataColumn( "HADD.DMDFORMTITLERF", typeof( String ) ) ); // �������^�C�g��
            table.Columns.Add( new DataColumn( "HADD.DMDFORMTITLE2RF", typeof( String ) ) ); // �������^�C�g���Q
            table.Columns.Add( new DataColumn( "HADD.DMDFORMCOMENT1RF", typeof( String ) ) ); // �������R�����g�P
            table.Columns.Add( new DataColumn( "HADD.DMDFORMCOMENT2RF", typeof( String ) ) ); // �������R�����g�Q
            table.Columns.Add( new DataColumn( "HADD.DMDFORMCOMENT3RF", typeof( String ) ) ); // �������R�����g�R
            table.Columns.Add( new DataColumn( "HADD.DMDNRMLEXDISRF", typeof( Int64 ) ) ); // �������z(�l������)
            table.Columns.Add( new DataColumn( "HADD.DMDNRMLEXFEERF", typeof( Int64 ) ) ); // �������z(�萔������)
            table.Columns.Add( new DataColumn( "HADD.DMDNRMLEXDISFEERF", typeof( Int64 ) ) ); // �������z(�l���E�萔������)
            table.Columns.Add( new DataColumn( "HADD.DMDNRMLSAMDISFEERF", typeof( Int64 ) ) ); // �������z(�l���{�萔���̂�)
            table.Columns.Add( new DataColumn( "HADD.THISSALESANDADJUSTRF", typeof( Int64 ) ) ); // ���񔄏�z(�c�������܂�)
            table.Columns.Add( new DataColumn( "HADD.THISTAXANDADJUSTRF", typeof( Int64 ) ) ); // ��������(����Œ����܂�)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYRF", typeof( Int32 ) ) ); // ���͔��s���t
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFYRF", typeof( Int32 ) ) ); // ���͔��s���t����N
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFSRF", typeof( Int32 ) ) ); // ���͔��s���t����N��
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFWRF", typeof( Int32 ) ) ); // ���͔��s���t�a��N
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFMRF", typeof( Int32 ) ) ); // ���͔��s���t��
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFDRF", typeof( Int32 ) ) ); // ���͔��s���t��
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFGRF", typeof( String ) ) ); // ���͔��s���t����
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFRRF", typeof( String ) ) ); // ���͔��s���t����
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLSRF", typeof( String ) ) ); // ���͔��s���t���e����(/)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLPRF", typeof( String ) ) ); // ���͔��s���t���e����(.)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLYRF", typeof( String ) ) ); // ���͔��s���t���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLMRF", typeof( String ) ) ); // ���͔��s���t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.ISSUEDAYFLDRF", typeof( String ) ) ); // ���͔��s���t���e����(��)
            table.Columns.Add( new DataColumn( "CADD.CUSTOMERSUBCODERF", typeof( String ) ) ); // ������Ӑ�T�u�R�[�h
            table.Columns.Add( new DataColumn( "CADD.NAMERF", typeof( String ) ) ); // ������Ӑ於��
            table.Columns.Add( new DataColumn( "CADD.NAME2RF", typeof( String ) ) ); // ������Ӑ於��2
            table.Columns.Add( new DataColumn( "CADD.HONORIFICTITLERF", typeof( String ) ) ); // ������Ӑ�h��
            table.Columns.Add(new DataColumn("CADD.HONORIFICTITLE2RF", typeof(String))); // ������Ӑ�h�́i�󎚈ʒu�ύX�p�j
            table.Columns.Add( new DataColumn( "CADD.KANARF", typeof( String ) ) ); // ������Ӑ�J�i
            table.Columns.Add( new DataColumn( "CADD.CUSTOMERSNMRF", typeof( String ) ) ); // ������Ӑ旪��
            table.Columns.Add( new DataColumn( "CADD.OUTPUTNAMECODERF", typeof( Int32 ) ) ); // ������Ӑ揔���R�[�h
            table.Columns.Add( new DataColumn( "CADD.POSTNORF", typeof( String ) ) ); // ������Ӑ�X�֔ԍ�
            table.Columns.Add( new DataColumn( "CADD.ADDRESS1RF", typeof( String ) ) ); // ������Ӑ�Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "CADD.ADDRESS3RF", typeof( String ) ) ); // ������Ӑ�Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "CADD.ADDRESS4RF", typeof( String ) ) ); // ������Ӑ�Z��4�i�A�p�[�g���́j
            table.Columns.Add(new DataColumn("CADD.ADDRESS123RF", typeof(String))); // ������Ӑ�Z��1+2+3
            table.Columns.Add(new DataColumn("CADD.POSTNOLRF", typeof(String))); // ������Ӑ�X�֔ԍ��i�������p�j
            table.Columns.Add(new DataColumn("CADD.POSTNOBRF", typeof(String))); // ������Ӑ�X�֔ԍ��i�啶���p�j
            table.Columns.Add(new DataColumn("CADD.ADDRESS1LRF", typeof(String))); // ������Ӑ�Z��1�i�������p�j
            table.Columns.Add(new DataColumn("CADD.ADDRESS1BRF", typeof(String))); // ������Ӑ�Z��1�i�啶���p�j
            table.Columns.Add(new DataColumn("CADD.ADDRESS3LRF", typeof(String))); // ������Ӑ�Z��3�i�������p�j
            table.Columns.Add(new DataColumn("CADD.ADDRESS3BRF", typeof(String))); // ������Ӑ�Z��3�i�啶���p�j
            table.Columns.Add(new DataColumn("CADD.ADDRESS4LRF", typeof(String))); // ������Ӑ�Z��4�i�������p�j
            table.Columns.Add(new DataColumn("CADD.ADDRESS4BRF", typeof(String))); // ������Ӑ�Z��4�i�啶���p�j
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE1RF", typeof( Int32 ) ) ); // ������Ӑ敪�̓R�[�h1
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE2RF", typeof( Int32 ) ) ); // ������Ӑ敪�̓R�[�h2
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE3RF", typeof( Int32 ) ) ); // ������Ӑ敪�̓R�[�h3
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE4RF", typeof( Int32 ) ) ); // ������Ӑ敪�̓R�[�h4
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE5RF", typeof( Int32 ) ) ); // ������Ӑ敪�̓R�[�h5
            table.Columns.Add( new DataColumn( "CADD.CUSTANALYSCODE6RF", typeof( Int32 ) ) ); // ������Ӑ敪�̓R�[�h6
            table.Columns.Add( new DataColumn( "CADD.NOTE1RF", typeof( String ) ) ); // ������Ӑ���l1
            table.Columns.Add( new DataColumn( "CADD.NOTE2RF", typeof( String ) ) ); // ������Ӑ���l2
            table.Columns.Add( new DataColumn( "CADD.NOTE3RF", typeof( String ) ) ); // ������Ӑ���l3
            table.Columns.Add( new DataColumn( "CADD.NOTE4RF", typeof( String ) ) ); // ������Ӑ���l4
            table.Columns.Add( new DataColumn( "CADD.NOTE5RF", typeof( String ) ) ); // ������Ӑ���l5
            table.Columns.Add( new DataColumn( "CADD.NOTE6RF", typeof( String ) ) ); // ������Ӑ���l6
            table.Columns.Add( new DataColumn( "CADD.NOTE7RF", typeof( String ) ) ); // ������Ӑ���l7
            table.Columns.Add( new DataColumn( "CADD.NOTE8RF", typeof( String ) ) ); // ������Ӑ���l8
            table.Columns.Add( new DataColumn( "CADD.NOTE9RF", typeof( String ) ) ); // ������Ӑ���l9
            table.Columns.Add( new DataColumn( "CADD.NOTE10RF", typeof( String ) ) ); // ������Ӑ���l10
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAME1RF", typeof( String ) ) ); // ����p���Ӑ於�́i��i�j
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAME2RF", typeof( String ) ) ); // ����p���Ӑ於�́i���i�j
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAME2HNRF", typeof( String ) ) ); // ����p���Ӑ於�́i���i�j�{�h��
            table.Columns.Add( new DataColumn( "CSTCST.COLLECTMONEYNAMERF", typeof( String ) ) ); // �W�����敪����
            table.Columns.Add( new DataColumn( "CSTCST.COLLECTMONEYDAYRF", typeof( Int32 ) ) ); // �W����
            table.Columns.Add( new DataColumn( "CADD.CUSTOMERCODERF", typeof( Int32 ) ) ); // ������Ӑ�R�[�h
            table.Columns.Add( new DataColumn( "CADD.HOMETELNORF", typeof( String ) ) ); // ������Ӑ�d�b�ԍ��i����j
            table.Columns.Add( new DataColumn( "CADD.OFFICETELNORF", typeof( String ) ) ); // ������Ӑ�d�b�ԍ��i�Ζ���j
            table.Columns.Add( new DataColumn( "CADD.PORTABLETELNORF", typeof( String ) ) ); // ������Ӑ�d�b�ԍ��i�g�сj
            table.Columns.Add( new DataColumn( "CADD.HOMEFAXNORF", typeof( String ) ) ); // ������Ӑ�FAX�ԍ��i����j
            table.Columns.Add( new DataColumn( "CADD.OFFICEFAXNORF", typeof( String ) ) ); // ������Ӑ�FAX�ԍ��i�Ζ���j
            table.Columns.Add( new DataColumn( "CADD.OTHERSTELNORF", typeof( String ) ) ); // ������Ӑ�d�b�ԍ��i���̑��j
            table.Columns.Add( new DataColumn( "CSTCST.HOMETELNORF", typeof( String ) ) ); // ���Ӑ�d�b�ԍ��i����j
            table.Columns.Add( new DataColumn( "CSTCST.OFFICETELNORF", typeof( String ) ) ); // ���Ӑ�d�b�ԍ��i�Ζ���j
            table.Columns.Add( new DataColumn( "CSTCST.PORTABLETELNORF", typeof( String ) ) ); // ���Ӑ�d�b�ԍ��i�g�сj
            table.Columns.Add( new DataColumn( "CSTCST.HOMEFAXNORF", typeof( String ) ) ); // ���Ӑ�FAX�ԍ��i����j
            table.Columns.Add( new DataColumn( "CSTCST.OFFICEFAXNORF", typeof( String ) ) ); // ���Ӑ�FAX�ԍ��i�Ζ���j
            table.Columns.Add( new DataColumn( "CSTCST.OTHERSTELNORF", typeof( String ) ) ); // ���Ӑ�d�b�ԍ��i���̑��j
            table.Columns.Add( new DataColumn( "CSTCLM.HOMETELNORF", typeof( String ) ) ); // ������d�b�ԍ��i����j
            table.Columns.Add( new DataColumn( "CSTCLM.OFFICETELNORF", typeof( String ) ) ); // ������d�b�ԍ��i�Ζ���j
            table.Columns.Add( new DataColumn( "CSTCLM.PORTABLETELNORF", typeof( String ) ) ); // ������d�b�ԍ��i�g�сj
            table.Columns.Add( new DataColumn( "CSTCLM.HOMEFAXNORF", typeof( String ) ) ); // ������FAX�ԍ��i����j
            table.Columns.Add( new DataColumn( "CSTCLM.OFFICEFAXNORF", typeof( String ) ) ); // ������FAX�ԍ��i�Ζ���j
            table.Columns.Add( new DataColumn( "CSTCLM.OTHERSTELNORF", typeof( String ) ) ); // ������d�b�ԍ��i���̑��j
            table.Columns.Add( new DataColumn( "HADD.THISSALESANDADJUSTTAXINCRF", typeof( Int64 ) ) ); // ���񔄏�z(�ō�)
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAMEJOIN12RF", typeof( String ) ) ); // ���Ӑ於�P�{���Ӑ於�Q
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNAMEJOIN12HNRF", typeof( String ) ) ); // ���Ӑ於�P�{���Ӑ於�Q�{�h��
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12LRF", typeof(String))); // ���Ӑ於�P�{���Ӑ於�Q�i�������p�j
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12BRF", typeof(String))); // ���Ӑ於�P�{���Ӑ於�Q�i�啶���p�j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1FHRF", typeof( String ) ) ); // ���Ж��P�i�O���j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1LHRF", typeof( String ) ) ); // ���Ж��P�i�㔼�j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2FHRF", typeof( String ) ) ); // ���Ж��Q�i�O���j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2LHRF", typeof( String ) ) ); // ���Ж��Q�i�㔼�j
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.HOMETELNODSPNAMERF", typeof( String ) ) ); // ����TEL�\������
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.OFFICETELNODSPNAMERF", typeof( String ) ) ); // �Ζ���TEL�\������
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.MOBILETELNODSPNAMERF", typeof( String ) ) ); // �g��TEL�\������
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.HOMEFAXNODSPNAMERF", typeof( String ) ) ); // ����FAX�\������
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.OFFICEFAXNODSPNAMERF", typeof( String ) ) ); // �Ζ���FAX�\������
            table.Columns.Add( new DataColumn( "ALITMDSPNMRF.OTHERTELNODSPNAMERF", typeof( String ) ) ); // ���̑�TEL�\������
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAMEEX1RF", typeof( String ) ) ); // ����p���Ж��i��i�j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAMEEX2RF", typeof( String ) ) ); // ����p���Ж��i���i�j
            table.Columns.Add( new DataColumn( "HADD.OFSTHISSALESTAXINCRF", typeof( Int64 ) ) );//���E�㔄�㍇�v���z(�ō�)
            table.Columns.Add( new DataColumn( "CADD.Name2HNRF", typeof( String ) ) );// ������Ӑ於�̂Q�{�h��
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAMEJOIN12UPRF", typeof( String ) ) ); //����p���Ӑ於�̂P�{�Q(��i)
            table.Columns.Add( new DataColumn( "CADD.PRINTCUSTOMERNAMEJOIN12LOWRF", typeof( String ) ) ); //����p���Ӑ於�̂P�{�Q(���i)
            table.Columns.Add(new DataColumn("HADD.OFSTHISSALESTAXINC2RF", typeof(Int64)));//���E�㔄�㍇�v���z(�ō�)(��ېŁE�q���󎚁j
            // ���t�֘A�o���G�[�V����
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx1, typeof( string ) ) ); // �����\���(�N���� ����4��)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx2, typeof( string ) ) ); // �����\���(�N���� ����2��)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx3, typeof( string ) ) ); // �����\���(/ ����4��)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx4, typeof( string ) ) ); // �����\���(/ ����2��)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx5, typeof( string ) ) ); // �����\���(. ����4��)
            table.Columns.Add( new DataColumn( ct_col_ExpectedDepositDateEx6, typeof( string ) ) ); // �����\���(. ����2��)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx1, typeof( string ) ) ); // �v��N����(�N���� ����4��)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx2, typeof( string ) ) ); // �v��N����(�N���� ����2��)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx3, typeof( string ) ) ); // �v��N����(/ ����4��)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx4, typeof( string ) ) ); // �v��N����(/ ����2��)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx5, typeof( string ) ) ); // �v��N����(. ����4��)
            table.Columns.Add( new DataColumn( ct_col_AddUpDateEx6, typeof( string ) ) ); // �v��N����(. ����2��)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx1, typeof( string ) ) ); // �����X�V�J�n�N����(�N���� ����4��)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx2, typeof( string ) ) ); // �����X�V�J�n�N����(�N���� ����2��)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx3, typeof( string ) ) ); // �����X�V�J�n�N����(/ ����4��)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx4, typeof( string ) ) ); // �����X�V�J�n�N����(/ ����2��)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx5, typeof( string ) ) ); // �����X�V�J�n�N����(. ����4��)
            table.Columns.Add( new DataColumn( ct_col_StartCAddUpUpdDateEx6, typeof( string ) ) ); // �����X�V�J�n�N����(. ����2��)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx1, typeof( string ) ) ); // ���������s��(�N���� ����4��)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx2, typeof( string ) ) ); // ���������s��(�N���� ����2��)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx3, typeof( string ) ) ); // ���������s��(/ ����4��)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx4, typeof( string ) ) ); // ���������s��(/ ����2��)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx5, typeof( string ) ) ); // ���������s��(. ����4��)
            table.Columns.Add( new DataColumn( ct_col_BillPrintDateEx6, typeof( string ) ) ); // ���������s��(. ����2��)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx1, typeof( string ) ) ); // ���͔��s���t(�N���� ����4��)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx2, typeof( string ) ) ); // ���͔��s���t(�N���� ����2��)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx3, typeof( string ) ) ); // ���͔��s���t(/ ����4��)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx4, typeof( string ) ) ); // ���͔��s���t(/ ����2��)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx5, typeof( string ) ) ); // ���͔��s���t(. ����4��)
            table.Columns.Add( new DataColumn( ct_col_IssueDayEx6, typeof( string ) ) ); // ���͔��s���t(. ����2��)
            // �Ӎ���(����p)
            table.Columns.Add( new DataColumn( ct_col_ThisTimeRetDis, typeof( Int64 ) ) ); // ����ԕi�l���z�i����ԕi�{����l���j
            table.Columns.Add( new DataColumn( "CUSTDMDPRCRF.BILLNORF", typeof( Int32 ) ) ); // �������ԍ�
            // ���㍇�v
            table.Columns.Add( new DataColumn( "HADD.SALESANDRGDSRF", typeof( Int64 ) ) ); // ���񔄏�i����|�ԕi�j
            table.Columns.Add( new DataColumn( "HADD.SALESANDDISRF", typeof( Int64 ) ) ); // ���񔄏�i����|�l���j
            // �������v
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALCASHRF", typeof( Int64 ) ) ); // �������v�i�����j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALTRANSFERRF", typeof( Int64 ) ) ); // �������v�i�U���j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALCHECKRF", typeof( Int64 ) ) ); // �������v�i���؎�j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALDRAFTRF", typeof( Int64 ) ) ); // �������v�i��`�j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALOFFSETRF", typeof( Int64 ) ) ); // �������v�i���E�j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALOTHERSRF", typeof( Int64 ) ) ); // �������v�i���̑��j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALACCOUNTRF", typeof( Int64 ) ) ); // �������v�i�����U���j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALFACTORINGRF", typeof( Int64 ) ) ); // �������v�i�t�@�N�^�����O�j
            // �������v�i���Z�j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM1RF", typeof( Int64 ) ) ); // �������v�i�萔���{���̑��j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM2RF", typeof( Int64 ) ) ); // �������v�i�l���{���̑��j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM3RF", typeof( Int64 ) ) ); // �������v�i���E�{���̑��j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM4RF", typeof( Int64 ) ) ); // �������v�i�萔���{���E�{���̑��j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM5RF", typeof( Int64 ) ) ); // �������v�i�l���{�萔���{���̑��j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM6RF", typeof( Int64 ) ) ); // �������v�i�l���{���E�{���̑��j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALSUM7RF", typeof( Int64 ) ) ); // �������v�i�萔���{���E�{�l���{���̑��j
            table.Columns.Add(new DataColumn("HADD.DEPTTOTALSUM8RF", typeof(Int64))); // �������v�i�����{�U���{���؎�{��`�j
            // �������v�i���Z�������j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC1RF", typeof( Int64 ) ) ); // �������v�i�萔���E���̑������j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC2RF", typeof( Int64 ) ) ); // �������v�i�l���E���̑������j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC3RF", typeof( Int64 ) ) ); // �������v�i���E�E���̑������j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC4RF", typeof( Int64 ) ) ); // �������v�i�萔���E���E�E���̑������j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC5RF", typeof( Int64 ) ) ); // �������v�i�l���E�萔���E���̑������j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC6RF", typeof( Int64 ) ) ); // �������v�i�l���E���E�E���̑������j
            table.Columns.Add( new DataColumn( "HADD.DEPTTOTALEXC7RF", typeof( Int64 ) ) ); // �������v�i�萔���E���E�E�l���E���̑������j
            table.Columns.Add(new DataColumn("HADD.DEPTTOTALEXC8RF", typeof(Int64))); // �������v�i�����E�U���E���؎�E��`�����j
            table.Columns.Add(new DataColumn("HADD.SALESEMPLOYEECDRF", typeof(string)));  // ���Ӑ�S���҃R�[�h
            table.Columns.Add(new DataColumn("HADD.EXPECTEDDEPOSITMONEYRF", typeof(Int64)));    // �����\��z
            table.Columns.Add(new DataColumn("HADD.LASTPAGECOMMENTRF", typeof(string)));    // �ŏI�ŃR�����g
            table.Columns.Add(new DataColumn("HADD.TOTALTAXINCTITLERF", typeof(string)));    // �Ӑō��v�^�C�g��
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12UP2RF", typeof(String))); // ������Ӑ於�̂P�{�Q�i10-15�F��i�j
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12LOW2RF", typeof(String))); // ������Ӑ於�̂P�{�Q�i10-15�F���i�j
            table.Columns.Add(new DataColumn("HADD.CALCEXPECTEDDEPOSITDATEFDRF", typeof(Int32))); // �v�Z�����\�����
            table.Columns.Add(new DataColumn("LAST.CALCEXPECTEDDEPOSITDATERF", typeof(string))); // �v�Z�����\������i���j
            table.Columns.Add(new DataColumn("HADD.CALCEXPECTEDDEPOSITDATEFMRF", typeof(Int32))); // �v�Z�����\�����
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12UP3RF", typeof(String))); // ������Ӑ於�̂P�{�Q�i15-15�F��i�j
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12LOW3RF", typeof(String))); // ������Ӑ於�̂P�{�Q�i15-15�F���i�j
            table.Columns.Add(new DataColumn("HADD.ADDRESS12UPRF", typeof(String))); // ������Ӑ�Z���P�{�Q�i��i�j
            table.Columns.Add(new DataColumn("HADD.ADDRESS12LOWRF", typeof(String))); // ������Ӑ�Z���P�{�Q�i���i�j
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12UP4RF", typeof(String))); // ������Ӑ於�̂P�{�Q�i15-15�F��i�j
            table.Columns.Add(new DataColumn("HADD.PRINTCUSTOMERNAMEJOIN12LOW4RF", typeof(String))); // ������Ӑ於�̂P�{�Q�i15-15�F���i�j
            table.Columns.Add(new DataColumn("HADD.SALESMONEYPAGETTLRF", typeof(Int64))); // ������z�Ōv
            table.Columns.Add(new DataColumn("HADD.OFSTHISTIMESALESLASTPAGERF", typeof(Int64))); // ���E�㍡�񔄏���z�i�ŏI�Łj
            # endregion

            # region [�X�L�[�}��`�i���׏��j]
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ACPTANODRSTATUSRF", typeof( Int32 ) ) ); // �󒍃X�e�[�^�X
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPNUMRF", typeof( String ) ) ); // ����`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SECTIONCODERF", typeof( String ) ) ); // ���_�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SUBSECTIONCODERF", typeof( Int32 ) ) ); // ����R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEBITNOTEDIVRF", typeof( Int32 ) ) ); // �ԓ`�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPCDRF", typeof( Int32 ) ) ); // ����`�[�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESGOODSCDRF", typeof( Int32 ) ) ); // ���㏤�i�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ACCRECDIVCDRF", typeof( Int32 ) ) ); // ���|�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEMANDADDUPSECCDRF", typeof( String ) ) ); // �����v�㋒�_�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESDATERF", typeof( Int32 ) ) ); // ������t
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDUPADATERF", typeof( Int32 ) ) ); // �v����t
            table.Columns.Add( new DataColumn( "SALESSLIPRF.INPUTAGENCDRF", typeof( String ) ) ); // ���͒S���҃R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.INPUTAGENNMRF", typeof( String ) ) ); // ���͒S���Җ���
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTCODERF", typeof( String ) ) ); // ������͎҃R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTNAMERF", typeof( String ) ) ); // ������͎Җ���
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEECDRF", typeof( String ) ) ); // ��t�]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEENMRF", typeof( String ) ) ); // ��t�]�ƈ�����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEECDRF", typeof( String ) ) ); // �̔��]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEENMRF", typeof( String ) ) ); // �̔��]�ƈ�����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESTOTALTAXINCRF", typeof( Int64 ) ) ); // ����`�[���v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESTOTALTAXEXCRF", typeof( Int64 ) ) ); // ����`�[���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESPRTTOTALTAXINCRF", typeof( Int64 ) ) ); // ���㕔�i���v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESPRTTOTALTAXEXCRF", typeof( Int64 ) ) ); // ���㕔�i���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESWORKTOTALTAXINCRF", typeof( Int64 ) ) ); // �����ƍ��v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESWORKTOTALTAXEXCRF", typeof( Int64 ) ) ); // �����ƍ��v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXINCRF", typeof( Int64 ) ) ); // ���㏬�v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXEXCRF", typeof( Int64 ) ) ); // ���㏬�v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESPRTSUBTTLINCRF", typeof( Int64 ) ) ); // ���㕔�i���v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESPRTSUBTTLEXCRF", typeof( Int64 ) ) ); // ���㕔�i���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESWORKSUBTTLINCRF", typeof( Int64 ) ) ); // �����Ə��v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESWORKSUBTTLEXCRF", typeof( Int64 ) ) ); // �����Ə��v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSUBTOTALTAXRF", typeof( Int64 ) ) ); // ���㏬�v�i�Łj
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDPARTSDISOUTTAXRF", typeof( Int64 ) ) ); // ���i�l���Ώۊz���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDPARTSDISINTAXRF", typeof( Int64 ) ) ); // ���i�l���Ώۊz���v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDWORKDISOUTTAXRF", typeof( Int64 ) ) ); // ��ƒl���Ώۊz���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ITDEDWORKDISINTAXRF", typeof( Int64 ) ) ); // ��ƒl���Ώۊz���v�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.PARTSDISCOUNTRATERF", typeof( Double ) ) ); // ���i�l����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RAVORDISCOUNTRATERF", typeof( Double ) ) ); // �H���l����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.TOTALCOSTRF", typeof( Int64 ) ) ); // �������z�v
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CONSTAXRATERF", typeof( Double ) ) ); // ����Őŗ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.AUTODEPOSITCDRF", typeof( Int32 ) ) ); // ���������敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.AUTODEPOSITSLIPNORF", typeof( Int32 ) ) ); // ���������`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEPOSITALLOWANCETTLRF", typeof( Int64 ) ) ); // �����������v�z
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DEPOSITALWCBLNCERF", typeof( Int64 ) ) ); // ���������c��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CLAIMCODERF", typeof( Int32 ) ) ); // ������R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERCODERF", typeof( Int32 ) ) ); // ���Ӑ�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAMERF", typeof( String ) ) ); // ���Ӑ於��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAME2RF", typeof( String ) ) ); // ���Ӑ於�̂Q
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERSNMRF", typeof( String ) ) ); // ���Ӑ旪��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.HONORIFICTITLERF", typeof( String ) ) ); // ���Ӑ�h��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEECODERF", typeof( Int32 ) ) ); // �[�i��R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEENAMERF", typeof( String ) ) ); // �[�i�於��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ADDRESSEENAME2RF", typeof( String ) ) ); // �[�i�於��2
            table.Columns.Add( new DataColumn( "SALESSLIPRF.PARTYSALESLIPNUMRF", typeof( String ) ) ); // �����`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTERF", typeof( String ) ) ); // �`�[���l
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTE2RF", typeof( String ) ) ); // �`�[���l�Q
            table.Columns.Add(new DataColumn("SALESSLIPRF.SLIPNOTE2_2RF", typeof(String))); // �`�[���l�Q�|�Q
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SLIPNOTE3RF", typeof( String ) ) ); // �`�[���l�R
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RETGOODSREASONDIVRF", typeof( Int32 ) ) ); // �ԕi���R�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.RETGOODSREASONRF", typeof( String ) ) ); // �ԕi���R
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DETAILROWCOUNTRF", typeof( Int32 ) ) ); // ���׍s��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.UOEREMARK1RF", typeof( String ) ) ); // �t�n�d���}�[�N�P
            table.Columns.Add( new DataColumn( "SALESSLIPRF.UOEREMARK2RF", typeof( String ) ) ); // �t�n�d���}�[�N�Q
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DELIVEREDGOODSDIVRF", typeof( Int32 ) ) ); // �[�i�敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.DELIVEREDGOODSDIVNMRF", typeof( String ) ) ); // �[�i�敪����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.STOCKGOODSTTLTAXEXCRF", typeof( Int64 ) ) ); // �݌ɏ��i���v���z�i�Ŕ��j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.PUREGOODSTTLTAXEXCRF", typeof( Int64 ) ) ); // �������i���v���z�i�Ŕ��j
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FOOTNOTES1RF", typeof( String ) ) ); // �r���P
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FOOTNOTES2RF", typeof( String ) ) ); // �r���Q
            table.Columns.Add( new DataColumn( "SECDTL.SECTIONGUIDENMRF", typeof( String ) ) ); // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "SECDTL.SECTIONGUIDESNMRF", typeof( String ) ) ); // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "SECDTL.COMPANYNAMECD1RF", typeof( Int32 ) ) ); // ���Ж��̃R�[�h1
            table.Columns.Add( new DataColumn( "SUBSAL.SUBSECTIONNAMERF", typeof( String ) ) ); // ���㕔�喼��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ACCEPTANORDERNORF", typeof( Int32 ) ) ); // �󒍔ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESROWNORF", typeof( Int32 ) ) ); // ����s�ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.DELIGDSCMPLTDUEDATERF", typeof( Int32 ) ) ); // �[�i�����\���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSKINDCODERF", typeof( Int32 ) ) ); // ���i����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMAKERCDRF", typeof( Int32 ) ) ); // ���i���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.MAKERNAMERF", typeof( String ) ) ); // ���[�J�[����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNORF", typeof( String ) ) ); // ���i�ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNAMERF", typeof( String ) ) ); // ���i����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSSHORTNAMERF", typeof( String ) ) ); // ���i������
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSLGROUPRF", typeof( Int32 ) ) ); // ���i�啪�ރR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSLGROUPNAMERF", typeof( String ) ) ); // ���i�啪�ޖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMGROUPRF", typeof( Int32 ) ) ); // ���i�����ރR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSMGROUPNAMERF", typeof( String ) ) ); // ���i�����ޖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGROUPCODERF", typeof( Int32 ) ) ); // BL�O���[�v�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGROUPNAMERF", typeof( String ) ) ); // BL�O���[�v�R�[�h����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGOODSCODERF", typeof( Int32 ) ) ); // BL���i�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BLGOODSFULLNAMERF", typeof( String ) ) ); // BL���i�R�[�h���́i�S�p�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ENTERPRISEGANRECODERF", typeof( Int32 ) ) ); // ���Е��ރR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.ENTERPRISEGANRENAMERF", typeof( String ) ) ); // ���Е��ޖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSECODERF", typeof( String ) ) ); // �q�ɃR�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSENAMERF", typeof( String ) ) ); // �q�ɖ���
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WAREHOUSESHELFNORF", typeof( String ) ) ); // �q�ɒI��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESORDERDIVCDRF", typeof( Int32 ) ) ); // ����݌Ɏ�񂹋敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.OPENPRICEDIVRF", typeof( Int32 ) ) ); // �I�[�v�����i�敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSRATERANKRF", typeof( String ) ) ); // ���i�|�������N
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICERATERF", typeof( Double ) ) ); // �艿��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICETAXINCFLRF", typeof( Double ) ) ); // �艿�i�ō��C�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.LISTPRICETAXEXCFLRF", typeof( Double ) ) ); // �艿�i�Ŕ��C�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESRATERF", typeof( Double ) ) ); // ������
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNPRCTAXINCFLRF", typeof( Double ) ) ); // ����P���i�ō��C�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNPRCTAXEXCFLRF", typeof( Double ) ) ); // ����P���i�Ŕ��C�����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.COSTRATERF", typeof( Double ) ) ); // ������
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESUNITCOSTRF", typeof( Double ) ) ); // �����P��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTBLGOODSCODERF", typeof( Int32 ) ) ); // BL���i�R�[�h�i����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTBLGOODSNAMERF", typeof( String ) ) ); // BL���i�R�[�h���́i����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.WORKMANHOURRF", typeof( Double ) ) ); // ��ƍH��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SHIPMENTCNTRF", typeof( Double ) ) ); // �o�א�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESMONEYTAXINCRF", typeof( Int64 ) ) ); // ������z�i�ō��݁j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESMONEYTAXEXCRF", typeof( Int64 ) ) ); // ������z�i�Ŕ����j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.COSTRF", typeof( Int64 ) ) ); // ����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // �ېŋ敪
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PARTYSLIPNUMDTLRF", typeof( String ) ) ); // �����`�[�ԍ��i���ׁj
            table.Columns.Add( new DataColumn( "SALESDETAILRF.DTLNOTERF", typeof( String ) ) ); // ���ה��l
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SUPPLIERCDRF", typeof( Int32 ) ) ); // �d����R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SUPPLIERSNMRF", typeof( String ) ) ); // �d���旪��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO1RF", typeof( String ) ) ); // �`�[�����P
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO2RF", typeof( String ) ) ); // �`�[�����Q
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SLIPMEMO3RF", typeof( String ) ) ); // �`�[�����R
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO1RF", typeof( String ) ) ); // �Г������P
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO2RF", typeof( String ) ) ); // �Г������Q
            table.Columns.Add( new DataColumn( "SALESDETAILRF.INSIDEMEMO3RF", typeof( String ) ) ); // �Г������R
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFLISTPRICERF", typeof( Double ) ) ); // �ύX�O�艿
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFSALESUNITPRICERF", typeof( Double ) ) ); // �ύX�O����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.BFUNITCOSTRF", typeof( Double ) ) ); // �ύX�O����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESROWNORF", typeof( Int32 ) ) ); // �ꎮ���הԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTGOODSMAKERCDRF", typeof( Int32 ) ) ); // ���[�J�[�R�[�h�i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTMAKERNAMERF", typeof( String ) ) ); // ���[�J�[���́i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTGOODSNAMERF", typeof( String ) ) ); // ���i���́i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSHIPMENTCNTRF", typeof( Double ) ) ); // ���ʁi�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESUNPRCFLRF", typeof( Double ) ) ); // ����P���i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESMONEYRF", typeof( Int64 ) ) ); // ������z�i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTSALESUNITCOSTRF", typeof( Double ) ) ); // �����P���i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTCOSTRF", typeof( Int64 ) ) ); // �������z�i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTPARTYSALSLNUMRF", typeof( String ) ) ); // �����`�[�ԍ��i�ꎮ�j
            table.Columns.Add( new DataColumn( "SALESDETAILRF.CMPLTNOTERF", typeof( String ) ) ); // �ꎮ���l
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CARMNGNORF", typeof( Int32 ) ) ); // �ԗ��Ǘ��ԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CARMNGCODERF", typeof( String ) ) ); // ���q�Ǘ��R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE1CODERF", typeof( Int32 ) ) ); // ���^�������ԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE1NAMERF", typeof( String ) ) ); // ���^�����ǖ���
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE2RF", typeof( String ) ) ); // �ԗ��o�^�ԍ��i��ʁj
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE3RF", typeof( String ) ) ); // �ԗ��o�^�ԍ��i�J�i�j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.NUMBERPLATE4RF", typeof( Int32 ) ) ); // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FIRSTENTRYDATERF", typeof( Int32 ) ) ); // ���N�x
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MAKERCODERF", typeof( Int32 ) ) ); // ���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MAKERFULLNAMERF", typeof( String ) ) ); // ���[�J�[�S�p����
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELCODERF", typeof( Int32 ) ) ); // �Ԏ�R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELSUBCODERF", typeof( Int32 ) ) ); // �Ԏ�T�u�R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELFULLNAMERF", typeof( String ) ) ); // �Ԏ�S�p����
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.EXHAUSTGASSIGNRF", typeof( String ) ) ); // �r�K�X�L��
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SERIESMODELRF", typeof( String ) ) ); // �V���[�Y�^��
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CATEGORYSIGNMODELRF", typeof( String ) ) ); // �^���i�ޕʋL���j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FULLMODELRF", typeof( String ) ) ); // �^���i�t���^�j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELDESIGNATIONNORF", typeof( Int32 ) ) ); // �^���w��ԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.CATEGORYNORF", typeof( Int32 ) ) ); // �ޕʔԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FRAMEMODELRF", typeof( String ) ) ); // �ԑ�^��
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.FRAMENORF", typeof( String ) ) ); // �ԑ�ԍ�
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SEARCHFRAMENORF", typeof( Int32 ) ) ); // �ԑ�ԍ��i�����p�j
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.ENGINEMODELNMRF", typeof( String ) ) ); // �G���W���^������
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.RELEVANCEMODELRF", typeof( String ) ) ); // �֘A�^��
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.SUBCARNMCDRF", typeof( Int32 ) ) ); // �T�u�Ԗ��R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELGRADESNAMERF", typeof( String ) ) ); // �^���O���[�h����
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.COLORCODERF", typeof( String ) ) ); // �J���[�R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.COLORNAME1RF", typeof( String ) ) ); // �J���[����1
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.TRIMCODERF", typeof( String ) ) ); // �g�����R�[�h
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.TRIMNAMERF", typeof( String ) ) ); // �g��������
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MILEAGERF", typeof( Int32 ) ) ); // �ԗ����s����
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.ACPTANODRSTATUSRF", typeof( Int32 ) ) ); // �󒍃X�e�[�^�X
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DEPOSITSLIPNORF", typeof( Int32 ) ) ); // �����`�[�ԍ�
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.SALESSLIPNUMRF", typeof( String ) ) ); // ����`�[�ԍ�
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.ADDUPSECCODERF", typeof( String ) ) ); // �v�㋒�_�R�[�h
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.SUBSECTIONCODERF", typeof( Int32 ) ) ); // ����R�[�h
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DEPOSITDATERF", typeof( Int32 ) ) ); // �������t
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.ADDUPADATERF", typeof( Int32 ) ) ); // �v����t
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DEPOSITRF", typeof( Int64 ) ) ); // �������z
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.FEEDEPOSITRF", typeof( Int64 ) ) ); // �萔�������z
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DISCOUNTDEPOSITRF", typeof( Int64 ) ) ); // �l�������z
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.AUTODEPOSITCDRF", typeof( Int32 ) ) ); // ���������敪
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DEPOSITCDRF", typeof( Int32 ) ) ); // �a����敪
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTDRAWINGDATERF", typeof( Int32 ) ) ); // ��`�U�o��
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTKINDRF", typeof( Int32 ) ) ); // ��`���
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTKINDNAMERF", typeof( String ) ) ); // ��`��ޖ���
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTDIVIDENAMERF", typeof( String ) ) ); // ��`�敪����
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.DRAFTNORF", typeof( String ) ) ); // ��`�ԍ�
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.CUSTOMERCODERF", typeof( Int32 ) ) ); // ���Ӑ�R�[�h
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.CLAIMCODERF", typeof( Int32 ) ) ); // ������R�[�h
            table.Columns.Add( new DataColumn( "DEPSITMAINRF.OUTLINERF", typeof( String ) ) ); // �`�[�E�v
            table.Columns.Add( new DataColumn( "SUBDEP.SUBSECTIONNAMERF", typeof( String ) ) ); // �����������喼��
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.DEPOSITSLIPNORF", typeof( Int32 ) ) ); // �����`�[�ԍ�
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.DEPOSITROWNORF", typeof( Int32 ) ) ); // �����s�ԍ�
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.MONEYKINDCODERF", typeof( Int32 ) ) ); // ����R�[�h
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.MONEYKINDNAMERF", typeof( String ) ) ); // ���햼��
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.MONEYKINDDIVRF", typeof( Int32 ) ) ); // ����敪
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.DEPOSITRF", typeof( Int64 ) ) ); // �������z
            table.Columns.Add( new DataColumn( "DEPSITDTLRF.VALIDITYTERMRF", typeof( Int32 ) ) ); // �L������
            table.Columns.Add( new DataColumn( "DADD.ACPTANODRSTATUSRF", typeof( Int32 ) ) ); // �󒍃X�e�[�^�X����
            table.Columns.Add( new DataColumn( "DADD.DEBITNOTEDIVRF", typeof( Int32 ) ) ); // �ԓ`�敪����
            table.Columns.Add( new DataColumn( "DADD.SALESSLIPCDRF", typeof( Int32 ) ) ); // ����`�[�敪����
            table.Columns.Add( new DataColumn( "DADD.SALESDATERF", typeof( Int32 ) ) ); // ������t
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFYRF", typeof( Int32 ) ) ); // ������t����N
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFSRF", typeof( Int32 ) ) ); // ������t����N��
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFWRF", typeof( Int32 ) ) ); // ������t�a��N
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFMRF", typeof( Int32 ) ) ); // ������t��
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFDRF", typeof( Int32 ) ) ); // ������t��
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFGRF", typeof( String ) ) ); // ������t����
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFRRF", typeof( String ) ) ); // ������t����
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLSRF", typeof( String ) ) ); // ������t���e����(/)
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLPRF", typeof( String ) ) ); // ������t���e����(.)
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLYRF", typeof( String ) ) ); // ������t���e����(�N)
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLMRF", typeof( String ) ) ); // ������t���e����(��)
            table.Columns.Add( new DataColumn( "DADD.SALESDATEFLDRF", typeof( String ) ) ); // ������t���e����(��)
            table.Columns.Add( new DataColumn( "DADD.STOCKGOODSTTLTAXEXCRF", typeof( Int64 ) ) ); // ��񏤕i���v���z�i�Ŕ��j
            table.Columns.Add( new DataColumn( "DADD.PUREGOODSTTLTAXEXCRF", typeof( Int64 ) ) ); // �D�Ǐ��i���v���z�i�Ŕ��j
            table.Columns.Add( new DataColumn( "DADD.GOODSKINDCODERF", typeof( Int32 ) ) ); // ���i��������
            table.Columns.Add( new DataColumn( "DADD.SALESORDERDIVCDRF", typeof( Int32 ) ) ); // ����݌Ɏ�񂹋敪����
            table.Columns.Add( new DataColumn( "DADD.OPENPRICEDIVRF", typeof( Int32 ) ) ); // �I�[�v�����i�敪����
            table.Columns.Add( new DataColumn( "DADD.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // �ېŋ敪����
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFYRF", typeof( Int32 ) ) ); // ���N�x����N
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFSRF", typeof( Int32 ) ) ); // ���N�x����N��
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFWRF", typeof( Int32 ) ) ); // ���N�x�a��N
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFMRF", typeof( Int32 ) ) ); // ���N�x��
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFGRF", typeof( String ) ) ); // ���N�x����
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFRRF", typeof( String ) ) ); // ���N�x����
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFLSRF", typeof( String ) ) ); // ���N�x���e����(/)
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFLPRF", typeof( String ) ) ); // ���N�x���e����(.)
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFLYRF", typeof( String ) ) ); // ���N�x���e����(�N)
            table.Columns.Add( new DataColumn( "DADD.FIRSTENTRYDATEFLMRF", typeof( String ) ) ); // ���N�x���e����(��)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFYRF", typeof( Int32 ) ) ); // �������t����N
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFSRF", typeof( Int32 ) ) ); // �������t����N��
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFWRF", typeof( Int32 ) ) ); // �������t�a��N
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFMRF", typeof( Int32 ) ) ); // �������t��
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFDRF", typeof( Int32 ) ) ); // �������t��
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFGRF", typeof( String ) ) ); // �������t����
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFRRF", typeof( String ) ) ); // �������t����
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLSRF", typeof( String ) ) ); // �������t���e����(/)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLPRF", typeof( String ) ) ); // �������t���e����(.)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLYRF", typeof( String ) ) ); // �������t���e����(�N)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLMRF", typeof( String ) ) ); // �������t���e����(��)
            table.Columns.Add( new DataColumn( "DADD.DEPOSITDATEFLDRF", typeof( String ) ) ); // �������t���e����(��)
            table.Columns.Add( new DataColumn( "DADD.AUTODEPOSITCDRF", typeof( Int32 ) ) ); // ���������敪����
            table.Columns.Add( new DataColumn( "DADD.DEPOSITCDRF", typeof( Int32 ) ) ); // �a����敪����
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFYRF", typeof( Int32 ) ) ); // ��`�U�o������N
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFSRF", typeof( Int32 ) ) ); // ��`�U�o������N��
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFWRF", typeof( Int32 ) ) ); // ��`�U�o���a��N
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFMRF", typeof( Int32 ) ) ); // ��`�U�o����
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFDRF", typeof( Int32 ) ) ); // ��`�U�o����
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFGRF", typeof( String ) ) ); // ��`�U�o������
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFRRF", typeof( String ) ) ); // ��`�U�o������
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLSRF", typeof( String ) ) ); // ��`�U�o�����e����(/)
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLPRF", typeof( String ) ) ); // ��`�U�o�����e����(.)
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLYRF", typeof( String ) ) ); // ��`�U�o�����e����(�N)
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLMRF", typeof( String ) ) ); // ��`�U�o�����e����(��)
            table.Columns.Add( new DataColumn( "DADD.DRAFTDRAWINGDATEFLDRF", typeof( String ) ) ); // ��`�U�o�����e����(��)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFYRF", typeof( Int32 ) ) ); // ��`�x����������N
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFSRF", typeof( Int32 ) ) ); // ��`�x����������N��
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFWRF", typeof( Int32 ) ) ); // ��`�x�������a��N
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFMRF", typeof( Int32 ) ) ); // ��`�x��������
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFDRF", typeof( Int32 ) ) ); // ��`�x��������
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFGRF", typeof( String ) ) ); // ��`�x����������
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFRRF", typeof( String ) ) ); // ��`�x����������
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLSRF", typeof( String ) ) ); // ��`�x���������e����(/)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLPRF", typeof( String ) ) ); // ��`�x���������e����(.)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLYRF", typeof( String ) ) ); // ��`�x���������e����(�N)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLMRF", typeof( String ) ) ); // ��`�x���������e����(��)
            table.Columns.Add( new DataColumn( "DADD.DRAFTPAYTIMELIMITFLDRF", typeof( String ) ) ); // ��`�x���������e����(��)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFYRF", typeof( Int32 ) ) ); // �L����������N
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFSRF", typeof( Int32 ) ) ); // �L����������N��
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFWRF", typeof( Int32 ) ) ); // �L�������a��N
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFMRF", typeof( Int32 ) ) ); // �L��������
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFDRF", typeof( Int32 ) ) ); // �L��������
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFGRF", typeof( String ) ) ); // �L����������
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFRRF", typeof( String ) ) ); // �L����������
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLSRF", typeof( String ) ) ); // �L���������e����(/)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLPRF", typeof( String ) ) ); // �L���������e����(.)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLYRF", typeof( String ) ) ); // �L���������e����(�N)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLMRF", typeof( String ) ) ); // �L���������e����(��)
            table.Columns.Add( new DataColumn( "DADD.VALIDITYTERMFLDRF", typeof( String ) ) ); // �L���������e����(��)
            table.Columns.Add( new DataColumn( "DADD.DMDDTLOUTLINERF", typeof( String ) ) ); // �������דE�v
            table.Columns.Add( new DataColumn( "DADD.SALESFTTITLERF", typeof( String ) ) ); // ����`�[�v�^�C�g��
            table.Columns.Add( new DataColumn( "DADD.SALESFTPRICERF", typeof( Int64 ) ) ); // ����`�[�v���z
            table.Columns.Add( new DataColumn( "DADD.SALESFTNOTE1RF", typeof( String ) ) ); // ����`�[�v���l�P
            table.Columns.Add( new DataColumn( "DADD.SALESFTNOTE2RF", typeof( String ) ) ); // ����`�[�v���l�Q
            table.Columns.Add( new DataColumn( "DADD.SALESFTNOTE3RF", typeof( String ) ) ); // ����`�[�v���l�R
            table.Columns.Add( new DataColumn( "DSAL.DETAILTITLERF", typeof( String ) ) ); // ���ד`�[�^�C�g��(����/�ԕi)
            table.Columns.Add( new DataColumn( "DSAL.DETAILSUMTITLERF", typeof( String ) ) ); // ����W�v�^�C�g��
            table.Columns.Add( new DataColumn( "DSAL.DETAILSUMPRICERF", typeof( Int64 ) ) ); // ����W�v���z
            table.Columns.Add( new DataColumn( "DDEP.DETAILTITLERF", typeof( String ) ) ); // ���ד`�[�^�C�g��(����)
            table.Columns.Add( new DataColumn( "DDEP.DETAILSUMTITLERF", typeof( String ) ) ); // �����W�v�^�C�g��
            table.Columns.Add( new DataColumn( "DDEP.DETAILSUMPRICERF", typeof( Int64 ) ) ); // �����W�v���z
            table.Columns.Add( new DataColumn( "SALESDETAILRF.GOODSNAMEKANARF", typeof( String ) ) ); // ���i���̃J�i
            table.Columns.Add( new DataColumn( "SALESDETAILRF.MAKERKANANAMERF", typeof( String ) ) ); // ���[�J�[�J�i����
            table.Columns.Add( new DataColumn( "ACCEPTODRCARRF.MODELHALFNAMERF", typeof( String ) ) ); // �Ԏ피�p����
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTGOODSNORF", typeof( String ) ) ); // ����p�i��
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTMAKERCODERF", typeof( Int32 ) ) ); // ����p���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "SALESDETAILRF.PRTMAKERNAMERF", typeof( String ) ) ); // ����p���[�J�[����
            table.Columns.Add( new DataColumn( "DADD.PARTYSALESLIPNUMRF", typeof( String ) ) ); // �����`�[�ԍ��i�w�b�_�p�j
            table.Columns.Add( new DataColumn( ct_col_DDep_MoneyKindNameSp, typeof( String ) ) ); // ���햼��(��߰�����)
            table.Columns.Add(new DataColumn("DADD.CARMNGCODETITLERF", typeof(String))); //�v���[�g�ԍ��^�C�g��

            table.Columns.Add(new DataColumn("DADD.SLIPTTLTAXRF", typeof(Int64))); // �`�[���v�����
            table.Columns.Add(new DataColumn("DADD.SLIPTTLTAXTITLERF", typeof(String))); // �`�[���v����Ń��e����

            table.Columns.Add(new DataColumn("DADD.FULLMODELRF", typeof(String)));//(�擪)�^��(�t���^)
            table.Columns.Add(new DataColumn("DADD.MODELHALFNAMEDTL2RF", typeof(String))); // (�擪)�Ԏ햼(�Q�s��)
            table.Columns.Add(new DataColumn("DADD.SALESFT2NOTERF", typeof(String))); // ����`�[�v���l(����t�b�^�Q)
            table.Columns.Add(new DataColumn("DADD.SALESFT2TITLERF", typeof(String))); // ����`�[�v�^�C�g��(����t�b�^�Q)
            table.Columns.Add(new DataColumn("DADD.SALESFT2PRICERF", typeof(String))); // ����`�[�v���z(����t�b�^�Q)

            table.Columns.Add(new DataColumn("DADD.SALESFT3NOTERF", typeof(String))); //����`�[�v���l(����t�b�^�R)
            table.Columns.Add(new DataColumn("DADD.SALESFT3TITLERF", typeof(String))); //����`�[�v(����t�b�^�R)
            table.Columns.Add(new DataColumn("DADD.SALESFT3PRICERF", typeof(Int64))); //����`�[�v���z(����t�b�^�R)
            table.Columns.Add(new DataColumn("DADD.FULLMODELHD2RF",typeof(string))); //�^��(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.MODELHALFNAMEHD2RF",typeof(String))); //�Ԏ햼(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESSLIPCDCHANGERF",typeof(Int32))); //����`�[�敪(�ϊ��p.����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.MONEYKINDCODEOTHERRF", typeof(Int32))); //�����R�[�h(���̑��Ɋ܂�)
            table.Columns.Add(new DataColumn("DADD.DEPOSITOTHERRF", typeof(Int32))); //�������z(���̑��Ɋ܂�)
            table.Columns.Add(new DataColumn("DADD.SALESSLIPNUMHD2RF", typeof(Int32))); //����`�[�ԍ�(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FMRF", typeof(Int32))); //������t��(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FDRF", typeof(Int32))); //������t��(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLPRF", typeof(String))); //������t���e����(.)(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2RF", typeof(Int32))); //������t(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FYRF", typeof(Int32))); //������t����N(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FSRF", typeof(Int32))); //������t����N��(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FWRF", typeof(Int32))); //������t�a��N(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FGRF", typeof(String))); // ������t����(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FRRF", typeof(String))); // ������t����(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLSRF", typeof(String))); // ������t���e����(/)(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLYRF", typeof(String))); // ������t���e����(�N)(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLMRF", typeof(String))); // ������t���e����(��)(����w�b�_�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2FLDRF", typeof(String))); // ������t���e����(��)(����w�b�_�Q)
            //�����p
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFMRF", typeof(object))); //������t��(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFDRF", typeof(object))); //������t��(���㌟���p�Q)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLPRF", typeof(object))); //������t���e����(.)(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHRF", typeof(object))); //������t(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFYRF", typeof(object))); //������t����N(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFSRF", typeof(object))); //������t����N��(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFWRF", typeof(object))); //������t�a��N(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFGRF", typeof(object))); // ������t����(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFRRF", typeof(object))); // ������t����(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLSRF", typeof(object))); // ������t���e����(/)(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLYRF", typeof(object))); // ������t���e����(�N)(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLMRF", typeof(object))); // ������t���e����(��)(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESDATEHD2SEARCHFLDRF", typeof(object))); // ������t���e����(��)(�����p)
            table.Columns.Add(new DataColumn("DADD.FULLMODELHD2SEARCHRF", typeof(object))); // �^��(�����p)
            table.Columns.Add(new DataColumn("DADD.MODELHALFNAMEHD2SEARCHRF", typeof(object))); // �Ԏ�(�����p)
            table.Columns.Add(new DataColumn("DADD.SALESSLIPCDCHANGESEARCHRF", typeof(object))); // ����`�[�敪(�ϊ��p.�����p)
            table.Columns.Add(new DataColumn("DADD.FOOTER3PRINTRF", typeof(Int32))); //����t�b�^�i���׍s����p�j
            table.Columns.Add(new DataColumn("DADD.FULLMODELORMODELHALFNAMERF", typeof(object))); // �^�������Ԏ햼

            table.Columns.Add(new DataColumn("DADD.MODELHALFNAMEDTL3RF", typeof(String))); // (�擪)�Ԏ햼(�Q�s��)�Q
            table.Columns.Add(new DataColumn("DADD.SALESFT2TITLE2RF", typeof(String))); // ����`�[�v�^�C�g��(����t�b�^�Q)�Q
            table.Columns.Add(new DataColumn("DADD.SALESFT2PRICE2RF", typeof(String))); // ����`�[�v���z(����t�b�^�Q)�Q
            table.Columns.Add(new DataColumn("DADD.DEPOSITFTTITLERF", typeof(String))); // �����v�^�C�g��
            table.Columns.Add(new DataColumn("DADD.DTLTITLERF", typeof(String))); // ���l�^�C�g��
            table.Columns.Add(new DataColumn("DADD.CARMNGNO2RF", typeof(String))); // ���l�^�C�g��
            table.Columns.Add(new DataColumn("DADD.CARMNGCODETITLE2RF", typeof(String))); // ���l�^�C�g��
            table.Columns.Add(new DataColumn("HADD.COMPANYNAMEJOIN12RF", typeof(String))); // ���Ж��P�{���Ж��Q
            table.Columns.Add(new DataColumn("DADD.DETAILBLANKLINERF", typeof(String))); // ���׃t�b�^��s
            table.Columns.Add(new DataColumn("DADD.ADDTAXLINERF", typeof(String))); // ����ōs�ǉ�
            table.Columns.Add(new DataColumn("DADD.HEADFULLMODEL2RF", typeof(String))); // �i�擪�j�^���i����t�b�^�Q�j
            table.Columns.Add(new DataColumn("DADD.MODELHALFNAME2RF", typeof(String))); // �i�擪�j�Ԏ피�p���̂Q
            table.Columns.Add(new DataColumn("DADD.SALESMONEYALLDETAILTTLRF", typeof(Int64))); // ������z���׍��v
            # endregion

            # region [�X�L�[�}��`�i������j]
            table.Columns.Add( new DataColumn( ct_col_InpageCount, typeof( Int32 ) ) ); // ����y�[�W���R�s�[�J�E���g
            table.Columns.Add( new DataColumn( ct_col_PageCount, typeof( Int32 ) ) ); // �Ő�
            table.Columns.Add( new DataColumn( ct_col_TaxTitle, typeof( string ) ) ); // ����Ń^�C�g��
            table.Columns.Add(new DataColumn(ct_col_OfsThisSalesTaxIncTtl, typeof( string ) ) ); // ���E�㔄�㍇�v���z(�ō�)�^�C�g��
            // �����Ή�
            table.Columns.Add( new DataColumn( ct_col_Last_AddUpDate, typeof( string ) ) ); // �v��N����(����)
            table.Columns.Add( new DataColumn( ct_col_Last_StartCAddUpUpdDate, typeof( string ) ) ); // �����X�V�J�n�N����(����)
            table.Columns.Add( new DataColumn( ct_col_Last_BillPrintDate, typeof( string ) ) ); // ���������s��(����)
            table.Columns.Add( new DataColumn( ct_col_Last_ExpectedDepositDate, typeof( string ) ) ); // �����\���(����)
            table.Columns.Add( new DataColumn( ct_col_Last_IssueDay, typeof( string ) ) ); // ���͔��s���t(����)
            table.Columns.Add( new DataColumn( ct_col_Last_CollectMoneyDay, typeof( string ) ) ); // �W����(����)
            // �\�[�g/���v�Ή�
            table.Columns.Add( new DataColumn( ct_col_Sort_CustomerCode, typeof( Int32 ) ) ); // (�\�[�g�p)���Ӑ�R�[�h
            table.Columns.Add( new DataColumn( ct_col_Sort_Date, typeof( Int32 ) ) ); // (�\�[�g�p)���t
            table.Columns.Add( new DataColumn( ct_col_Sort_RecordDiv, typeof( Int32 ) ) ); // (�\�[�g�p)���R�[�h�敪
            table.Columns.Add( new DataColumn( ct_col_Sort_SalesSlipNo, typeof( string ) ) ); // (�\�[�g�p)����`�[�ԍ�
            table.Columns.Add( new DataColumn( ct_col_Sort_DepositSlipNo, typeof( Int32 ) ) ); // (�\�[�g�p)�����`�[�ԍ�
            table.Columns.Add( new DataColumn( ct_col_Sort_DetailDiv, typeof( Int32 ) ) ); // (�\�[�g�p)���׋敪
            table.Columns.Add( new DataColumn( ct_col_Sort_DetailRowNo, typeof( Int32 ) ) ); // (�\�[�g�p)���׍s�ԍ�
            table.Columns.Add( new DataColumn( ct_col_Sort_RecordDiv_EmptyDetail, typeof( Int32 ) ) );// (�\�[�g�p)���R�[�h�敪(��s�Ō�)
            // ���̑�
            table.Columns.Add( new DataColumn( ct_col_DDep_DepFtOutLine, typeof( string ) ) ); // (����p)�����W�v�t�b�^�`�[�E�v
            table.Columns.Add( new DataColumn( ct_col_HDmd_LastTimeDemandOrg, typeof( string ) ) ); // (����p)�O�񐿋����z(�O��̂�)
            table.Columns.Add( new DataColumn( ct_col_DAdd_DmdDtlOutLineRF_ListPrice, typeof( Double ) ) ); // (����p)�������דE�v(�艿)
            # endregion
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            # region [�y���ŗ��Ή�]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATERF", typeof(String)));                    // ����Őŗ�(����)[����]

            table.Columns.Add(new DataColumn("TAX.DTLTOTALCONSTAXRATETITLERF", typeof(String)));      // �ŗ��ʍ��v�^�C�g��[����]
            table.Columns.Add(new DataColumn("TAX.DTLTOTALSALESMONEYTAXEXCRF", typeof(String)));      // �ŗ��ʍ��v���z[����]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE1RF", typeof(String)));                   // �ŗ��P[����]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE1SALESTAXEXCRF", typeof(String)));        // �ŗ��P(�Ŕ���)[����]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE1SALESTAXRF", typeof(String)));           // �ŗ��P�����[����]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE2RF", typeof(String)));                   // �ŗ��Q[����]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE2SALESTAXEXCRF", typeof(String)));        // �ŗ��Q(�Ŕ���)[����]
            table.Columns.Add(new DataColumn("TAX.DTLTAXRATE2SALESTAXRF", typeof(String)));           // �ŗ��Q�����[����]
            table.Columns.Add(new DataColumn("TAX.DTLOTHERTAXRATERF", typeof(String)));               // ���̑��ŗ�[����]
            table.Columns.Add(new DataColumn("TAX.DTLOTHERTAXRATESALESTAXEXCRF", typeof(String)));    // ���̑��ŗ�(�Ŕ���)[����]
            table.Columns.Add(new DataColumn("TAX.DTLOTHERTAXRATESALESTAXRF", typeof(String)));       // ���̑��ŗ������[����]
            table.Columns.Add(new DataColumn("TAX.DTLTAXTITLERF", typeof(String)));                   // �ŗ��ʐŗ��^�C�g��[����]

            table.Columns.Add(new DataColumn("TAX.HFTOTALCONSTAXRATETITLERF", typeof(String)));       // �ŗ��ʍ��v�^�C�g��[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTOTALSALESMONEYTAXEXCRF", typeof(String)));       // �ŗ��ʍ��v���z[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE1RF", typeof(String)));                    // �ŗ��P[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE1SALESTAXEXCRF", typeof(String)));         // �ŗ��P(�Ŕ���)[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE1SALESTAXRF", typeof(String)));            // �ŗ��P�����[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE2RF", typeof(String)));                    // �ŗ��Q[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE2SALESTAXEXCRF", typeof(String)));         // �ŗ��Q(�Ŕ���)[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTAXRATE2SALESTAXRF", typeof(String)));            // �ŗ��Q�����[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFOTHERTAXRATERF", typeof(String)));                // ���̑��ŗ�[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFOTHERTAXRATESALESTAXEXCRF", typeof(String)));     // ���̑��ŗ�(�Ŕ���)[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFOTHERTAXRATESALESTAXRF", typeof(String)));        // ���̑��ŗ������[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTAXTITLERF", typeof(String)));                    // �ŗ��ʐŗ��^�C�g��[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.DTLTAXOUTITLERF", typeof(String)));                 // ��ېŃ^�C�g��[����]
            table.Columns.Add(new DataColumn("TAX.DTLTAXOUTSALESTAXEXCRF", typeof(String)));          // ��ېŔ�����z(�Ŕ���)[����]

            table.Columns.Add(new DataColumn("TAX.HFTAXOUTITLERF", typeof(String)));                  // ��ېŃ^�C�g��[�w�b�_�A�t�b�^]
            table.Columns.Add(new DataColumn("TAX.HFTAXOUTSALESTAXEXCRF", typeof(String)));           // ��ېŋ��z������z(�Ŕ���)[�w�b�_�A�t�b�^]
            #endregion
            // --- ADD END   �c������ 2022/10/18 -----<<<<<
            // --- ADD START 3H ���� 2023/04/14 ----------------------------------->>>>>
            #region [�@����`�[�v���z(�ō���) �A�����(�`�[�]��)/����`�[�v���z(�ō���) �ǉ�]
            table.Columns.Add(new DataColumn("DADD.SALESMONEYTAXINCRF", typeof(string)));          // ����`�[�v���z(�ō���)
            table.Columns.Add(new DataColumn("DADD.TAXRFANDSALESMONEYTAXINCRF", typeof(string))); // �����(�`�[�]��)/����`�[�v���z(�ō���)
            #endregion
            // --- ADD END 3H ���� 2023/04/14  -------------------------------------<<<<<
            return table;
        }
        # endregion

        # region [�f�[�^�ڍs�i����f�[�^�j]
        /// <summary>
        /// �f�[�^�ڍs�i����f�[�^�@�P�������P�ʁj
        /// </summary>
        /// <param name="targetTable">�f�[�^�e�[�u��</param>
        /// <param name="jyoken">������</param>
        /// <param name="sourceRow">�f�[�^Row</param>
        /// <param name="billDmdPrintParameter">�������</param>
        /// <remarks>
        /// <br>Note        : �f�[�^�ڍs�i����f�[�^�@�P�������P�ʁj</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note :  2022/10/18  �c������</br>                               // 
        /// <br>�Ǘ��ԍ�    :  11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>       //
        /// </remarks>
        public static void CopyToPrintDataTable( ref DataTable targetTable, object jyoken, DataRow sourceRow, BillDmdPrintParameter billDmdPrintParameter )
        {

            EBooksFrePBillHeadWork headWork;
            List<EBooksFrePBillDetailWork> salesList;
            List<EBooksFrePBillDetailWork> depositList;
            DmdPrtPtnWork dmdPrtPtnWork;
            FrePrtPSetWork frePrtPSetWork;
            BillAllStWork billAllStWork;
            BillPrtStWork billPrtStWork;
            AllDefSetWork allDefSetWork;
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            // ������z�����敪�ݒ�
            List<SalesProcMoneyWork> salesProcMoneyWorkList;

            // ������z�����敪�ݒ�
            if (sourceRow[PMKAU01002AB.CT_BillList_SalesProcMoneyWork] != DBNull.Value)
            {
                salesProcMoneyWorkList = (List<SalesProcMoneyWork>)sourceRow[PMKAU01002AB.CT_BillList_SalesProcMoneyWork];
            }
            else
            {
                salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
            }
            // --- ADD END   �c������ 2022/10/18 -----<<<<<

            // �������w�b�_
            if ( sourceRow[PMKAU01002AB.CT_BillList_FrePBillHead] != DBNull.Value )
            {
                headWork = (EBooksFrePBillHeadWork)sourceRow[PMKAU01002AB.CT_BillList_FrePBillHead];
            }
            else
            {
                headWork = new EBooksFrePBillHeadWork();
            }

            // ���㖾�׃��X�g
            if ( sourceRow[PMKAU01002AB.CT_BillList_FrePBillSalesList] != DBNull.Value )
            {
                salesList = (List<EBooksFrePBillDetailWork>)sourceRow[PMKAU01002AB.CT_BillList_FrePBillSalesList];
            }
            else
            {
                salesList = new List<EBooksFrePBillDetailWork>();
            }

            // �������׃��X�g
            if ( sourceRow[PMKAU01002AB.CT_BillList_FrePBillDepositList] != DBNull.Value )
            {
                depositList = (List<EBooksFrePBillDetailWork>)sourceRow[PMKAU01002AB.CT_BillList_FrePBillDepositList];
            }
            else
            {
                depositList = new List<EBooksFrePBillDetailWork>();
            }

            // ����������p�^�[��
            if ( sourceRow[PMKAU01002AB.CT_BillList_DmdPrtPtn] != DBNull.Value )
            {
                dmdPrtPtnWork = (DmdPrtPtnWork)sourceRow[PMKAU01002AB.CT_BillList_DmdPrtPtn];
            }
            else
            {
                dmdPrtPtnWork = new DmdPrtPtnWork();
            }

            // ���R���[����ݒ�
            if ( sourceRow[PMKAU01002AB.CT_BillList_FrePrtPSet] != DBNull.Value )
            {
                frePrtPSetWork = (FrePrtPSetWork)sourceRow[PMKAU01002AB.CT_BillList_FrePrtPSet];
            }
            else
            {
                frePrtPSetWork = new FrePrtPSetWork();
            }

            // �����S�̐ݒ�
            if ( sourceRow[PMKAU01002AB.CT_BillList_BillAllSt] != DBNull.Value )
            {
                billAllStWork = (BillAllStWork)sourceRow[PMKAU01002AB.CT_BillList_BillAllSt];
            }
            else
            {
                billAllStWork = new BillAllStWork();
            }

            // ��������ݒ�
            if ( sourceRow[PMKAU01002AB.CT_BillList_BillPrtSt] != DBNull.Value )
            {
                billPrtStWork = (BillPrtStWork)sourceRow[PMKAU01002AB.CT_BillList_BillPrtSt];
            }
            else
            {
                billPrtStWork = new BillPrtStWork();
            }

            // �S�̏����\���ݒ�
            if ( sourceRow[PMKAU01002AB.CT_BillList_AllDefSet] != DBNull.Value)
            {
                allDefSetWork = (AllDefSetWork)sourceRow[PMKAU01002AB.CT_BillList_AllDefSet];
            }
            else
            {
                allDefSetWork = new AllDefSetWork();
            }


            // �t�h���͏����̎擾
            if ( jyoken is ExtrInfo_EBooksDemandTotal )
            {
                if ( headWork != null )
                {
                    // ���s�����Z�b�g
                    headWork.HADD_ISSUEDAYRF = GetLongDate( (jyoken as ExtrInfo_EBooksDemandTotal).IssueDay );
                }
            }

            // �R�s�[����
            // --- DEL START �c������ 2022/10/18 ----->>>>>                        
            //CopyToPrintDataTable( ref targetTable, headWork, salesList, depositList, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, billDmdPrintParameter, allDefSetWork );
            // --- DEL END �c������ 2022/10/18 -----<<<<<
            // --- ADD START �c������ 2022/10/18 ----->>>>>            
            CopyToPrintDataTable(ref targetTable, headWork, salesList, depositList, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, billDmdPrintParameter, allDefSetWork, salesProcMoneyWorkList);
            // --- ADD END   �c������ 2022/10/18 -----<<<<<
        }
        /// <summary>
        /// ���t�����l�ϊ�
        /// </summary>
        /// <param name="dateTime">���t</param>
        /// <returns>���l���t</returns>
        /// <remarks>
        /// <br>Note        : ���t�����l�ϊ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetLongDate( DateTime dateTime )
        {
            if ( dateTime != DateTime.MinValue )
            {
                return (dateTime.Year * 10000) + (dateTime.Month * 100) + dateTime.Day;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// �f�[�^�ڍs�i����f�[�^�@�P�������P�ʁj
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <param name="headWork">�w�b�_���[�N</param>
        /// <param name="salesList">���ナ�X�g</param>
        /// <param name="depositList">�������X�g</param>
        /// <param name="dmdPrtPtnWork">����������p�^�[���ݒ�</param>
        /// <param name="frePrtPSetWork">���R���[�󎚈ʒu�ݒ�</param>
        /// <param name="billAllStWork">�����S�̐ݒ�</param>
        /// <param name="billPrtStWork">��������ݒ�</param>
        /// <param name="billDmdPrintParameter">�������</param>
        /// <param name="allDefSet">�S�̏����\���ݒ�</param>
        /// /// <param name="salesProcMoneyWorkList">������z�����敪�ݒ�</param>
        /// <remarks>
        /// <br>Note        : �f�[�^�ڍs�i����f�[�^�@�P�������P�ʁj</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�    : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Update Note : 2023/06/16 �c������</br>
        /// <br>�Ǘ��ԍ�    : 11900025-00 �y���ŗ��s��Ή�</br>
        /// </remarks>
        //public static void CopyToPrintDataTable( ref DataTable table, EBooksFrePBillHeadWork headWork, List<EBooksFrePBillDetailWork> salesList, List<EBooksFrePBillDetailWork> depositList, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, BillDmdPrintParameter billDmdPrintParameter, AllDefSetWork allDefSet ) // --- DEL �c������ 2022/10/18
        public static void CopyToPrintDataTable(ref DataTable table, EBooksFrePBillHeadWork headWork, List<EBooksFrePBillDetailWork> salesList, List<EBooksFrePBillDetailWork> depositList, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, BillDmdPrintParameter billDmdPrintParameter, AllDefSetWork allDefSet, List<SalesProcMoneyWork> salesProcMoneyWorkList) // --- ADD �c������ 2022/10/18
        {

            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS"); 

            bool printPrice = true;

            // �w�b�_���ǉ����ړK�p����
            ReflectBillHeaderAddtionSet( ref headWork, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, allDefSet );

            // �N���A
            table.Rows.Clear();
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            // �ŗ��ʍ��v���
            TaxRateSalesMoney TotalTaxRateSalesMoney = new TaxRateSalesMoney();
            // ����œ]�ŕ����u�����q�v�̏����
            Dictionary<Int32, TaxRateSalesMoney> dicCustomerCode = new Dictionary<Int32, TaxRateSalesMoney>();
            // �[�����������擾
            if (stc_priceTaxCalculator == null)
            {
                stc_priceTaxCalculator = new PriceTaxCalculator();
            }
            stc_priceTaxCalculator.SalesProcMoneyWorkList = salesProcMoneyWorkList;

            Boolean bChgFlg;                        // �`�[�ԍ��ύX�L���t���O
            Double lTaxRate1SalesMoneyEx      = 0;  // �ŗ��P  ���v���z
            Double lTaxRate1SalesPriceConsTax = 0;  // �ŗ��P  ����ō��v
            Double lTaxRate2SalesMoneyEx      = 0;  // �ŗ��Q  ���v���z
            Double lTaxRate2SalesPriceConsTax = 0;  // �ŗ��Q  ����ō��v
            Double lOtherSalesMoneyEx         = 0;  // ���̑�  ���v���z
            Double lOtherSalesPriceConsTax    = 0;  // ���̑�  ����ō��v
            Double lTaxRate1MeisaiTotalTax    = 0;  // �ŗ��P  ����œ]�ŕ����F�u���ד]�Łv�̏���ŋ��z���v
            Double lTaxRate2MeisaiTotalTax    = 0;  // �ŗ��Q  ����œ]�ŕ����F�u���ד]�Łv�̏���ŋ��z���v
            Double lOtherMeisaiTotalTax       = 0;  // ���̑�  ����œ]�ŕ����F�u���ד]�Łv�̏���ŋ��z���v
            Double lSalesMoneyEx              = 0;  // ������z�i�Ŕ����j�W�v (���i�ېŋ敪�u��ېňȊO�v)
            Double lSalesMoneyExTaxOut = 0;  // ������z�i�Ŕ����j�W�v (���i�ېŋ敪�u��ېŁv)// ADD 2022/04/21 ������ PMKOBETSU-4208 ��ېŕi�Ԃ̋��z�s��Ή�

            
            // XML�ݒ�t�@�C�������擾
            PMKAU01002AB.TaxRatePrintInfo taxRatePrintInfo = null;
            string errMsg = string.Empty;
            PMKAU01002AB.Deserialize(out taxRatePrintInfo, out errMsg);
            // �ŗ��ݒ���t�@�C���̈���p�ŗ�
            double dTaxRate1 = 0;                   // �ŗ�1
            double dTaxRate2 = 0;                   // �ŗ�2
            double.TryParse(taxRatePrintInfo.TaxRate1,out dTaxRate1);
            double.TryParse(taxRatePrintInfo.TaxRate2,out dTaxRate2);            
            // --- ADD END   �c������ 2022/10/18 -----<<<<<


                //********************************************************
                // ���ׂ���
                //********************************************************

# if DEBUG
                //salesList = new List<EBooksFrePBillDetailWork>();

                //EBooksFrePBillDetailWork dt;

                //for ( int count = 0; count < 50; count++ )
                //{
                //    dt = new EBooksFrePBillDetailWork();

                //    # region [�e�X�g�f�[�^]
                //    dt.SALESDETAILRF_GOODSNORF = "22018a";
                //    dt.SALESDETAILRF_GOODSNAMERF = "�Ђ�߂�";
                //    dt.SALESSLIPRF_SALESDATERF = 20081001;
                //    dt.SALESDETAILRF_SALESMONEYTAXEXCRF = 1000;
                //    dt.SALESDETAILRF_SALESMONEYTAXINCRF = 1050;
                //    dt.SALESDETAILRF_SALESROWNORF = (count % 5) + 1;
                //    dt.SALESSLIPRF_SALESSLIPNUMRF = ((count / 5) + 1).ToString("000000000");
                //    dt.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = 5000;
                //    dt.SALESSLIPRF_SLIPNOTERF = "���l���l";
                //    # endregion

                //    salesList.Add( dt );
                //}
# endif
                //--------------------------------------------------------
                // ���z�[������ �폜
                //--------------------------------------------------------
                # region [���z�[�����׍폜]
                List<EBooksFrePBillDetailWork> deleteList;
                // ���㖾�׍폜(�}�X�^�ݒ�ɏ]��)
                if (dmdPrtPtnWork.DtlPrcZeroPrtDiv == 1)
                {
                    deleteList = new List<EBooksFrePBillDetailWork>();
                    foreach (EBooksFrePBillDetailWork detail in salesList)
                    {
                        //���ߍs�ȊO
                        if (frePrtPSetWork.FreePrtPprSpPrpseCd == 60 && detail.SALESDETAILRF_SALESMONEYTAXEXCRF == 0 && detail.SALESDETAILRF_SALESSLIPCDDTLRF != 3)
                        {
                            // ���א������͖��גP�ʂŋ��z�[������
                            deleteList.Add(detail);
                        }
                        else if (frePrtPSetWork.FreePrtPprSpPrpseCd == 70 && detail.SALESSLIPRF_SALESSUBTOTALTAXINCRF == 0)
                        {
                            // �`�[���v�������͓`�[�P�ʂŋ��z�[������
                            deleteList.Add(detail);
                        }
                    }
                    foreach (EBooksFrePBillDetailWork deleteItem in deleteList)
                    {
                        salesList.Remove(deleteItem);
                    }
                }
                //�������׍폜(�}�X�^�ݒ�ɏ]��)
                if (dmdPrtPtnWork.DtlPrcZeroPrtDiv == 1)
                {
                    deleteList = new List<EBooksFrePBillDetailWork>();
                    foreach (EBooksFrePBillDetailWork detail in depositList)
                    {
                        //�������v���[���̎��͈󎚂��Ȃ�
                        if (GetDepositTotal(detail) == 0)
                        {
                            deleteList.Add(detail);
                        }
                    }
                    foreach (EBooksFrePBillDetailWork deleteItem in deleteList)
                    {
                        depositList.Remove(deleteItem);
                    }
                }

                #region[�R������Ή�]
                //����w�b�_�Q�̗L���ŏ������s��������
                if (billDmdPrintParameter.ExistsSalesHeader2)
                {
                    // ���̑��Ɋ܂܂Ȃ����\���Ă���ꍇ�͏������s��Ȃ�
                    if (!ReportItemDic.ContainsKey("DADD.NOINCOTHERRF"))
                    {
                        //��`����
                        List<EBooksFrePBillDetailWork> deleteRowList = new List<EBooksFrePBillDetailWork>();
                        List<EBooksFrePBillDetailWork> depositList2 = new List<EBooksFrePBillDetailWork>();
                        EBooksFrePBillDetailWork otherDepositRowWork = null;
                        Int64 otherDepositPrice = 0;
                        bool otherRow = false;
                        bool printOther = false;
                        Int64 feeDeposit = 0;

                        //for�ŏ������s��
                        for (int index = 0; index < depositList.Count; index++)
                        {
                            //�`�[�ԍ����ς���Ă���ꍇ
                            # region [�`�[�ԍ����ς���Ă���ꍇ]
                            if (index > 0 && depositList[index - 1].DEPSITMAINRF_DEPOSITSLIPNORF != depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF)
                            {
                                //���̑����������ꍇ
                                if (depositList.Count > 0 && otherRow)
                                {
                                    //�t�@�N�^�����O�{�����U�ց{�萔���̋��z��ǉ�
                                    otherDepositRowWork.DEPSITDTLRF_DEPOSITRF += otherDepositPrice + feeDeposit;
                                    depositList2.Add(otherDepositRowWork);
                                }
                                else if (depositList.Count > 0 && printOther)
                                {
                                    //���̑����Ȃ��ꍇ�͒ǉ�����
                                    depositList2.Add( AddOtherDeposit( depositList[index - 1], otherDepositPrice + feeDeposit ) );
                                }

                                // ������
                                otherDepositRowWork = null;
                                otherDepositPrice = 0;
                                feeDeposit = 0;
                                otherRow = false;
                                printOther = false;
                            }
                            # endregion

                            # region ["���̑�"�����s�̑ޔ�]
                            //���̑��̍s�����邩�m�F
                            if (depositList[index].DEPSITDTLRF_MONEYKINDCODERF == 58)
                            {
                                //���̑��̍s��������true
                                otherRow = true;
                                //���݂̍s��ޔ�
                                otherDepositRowWork = depositList[index];
                            }
                            //�t�@�N�^�����O�E�����U�ւ̏ꍇ
                            else if ( depositList[index].DEPSITDTLRF_MONEYKINDCODERF == 59 || depositList[index].DEPSITDTLRF_MONEYKINDCODERF == 60 )
                            {
                                //���̑��̋��z�ɒǉ�����
                                otherDepositPrice += depositList[index].DEPSITDTLRF_DEPOSITRF;
                                printOther = true;
                            }
                            // �萔���݂̂̏ꍇ
                            else if ( depositList[index].DEPSITDTLRF_DEPOSITRF == 0 && depositList[index].DEPSITMAINRF_FEEDEPOSITRF != 0 )
                            {
                                printOther = true;
                            }
                            # endregion

                            //�萔�����O�ɂ���
                            feeDeposit = depositList[index].DEPSITMAINRF_FEEDEPOSITRF;
                            depositList[index].DEPSITMAINRF_FEEDEPOSITRF = 0;

                            //���̑��E�t�@�N�^�����O�E�����U�ֈȊO ���� �萔���݈̂ȊO
                            if (depositList[index].DEPSITDTLRF_MONEYKINDCODERF != 59 && 
                                depositList[index].DEPSITDTLRF_MONEYKINDCODERF != 60 && 
                                depositList[index].DEPSITDTLRF_MONEYKINDCODERF != 58 &&
                                (depositList[index].DEPSITDTLRF_DEPOSITRF != 0 || feeDeposit == 0))
                            {
                                depositList2.Add( depositList[index] );
                            }
                        }

                        //�ŏI�̓`�[�̂��̑��̏������s��
                        # region [�ŏI�̓`�[�̂��̑�]
                        if (depositList.Count > 0 && otherRow)
                        {
                            //�t�@�N�^�����O�{�����U�ց{�萔���̋��z��ǉ�
                            otherDepositRowWork.DEPSITDTLRF_DEPOSITRF += otherDepositPrice + feeDeposit;
                            depositList2.Add(otherDepositRowWork);
                        }
                        else if (depositList.Count > 0 && printOther)
                        {
                            //���̑����Ȃ��ꍇ�͒ǉ�����
                            depositList2.Add( AddOtherDeposit( depositList[depositList.Count - 1], otherDepositPrice + feeDeposit ) );
                        }
                        # endregion

                        //���X�g�������ւ���
                        depositList = depositList2;
                    }
                }
                #endregion
                # endregion

                //--------------------------------------------------------
                // ���ߖ��� �폜
                //--------------------------------------------------------
                #region [���ߖ��׍s�@�폜]
                //List<EBooksFrePBillDetailWork> deleteList;
                //����p�^�[���ݒ�}�X�^�u���߈󎚋敪�@1�F�󎚂��Ȃ��v
                if (dmdPrtPtnWork.AnnotationPrtCd == 1)
                {
                    //���ߖ��׍s�͈󎚂��Ȃ�
                    deleteList = new List<EBooksFrePBillDetailWork>();
                    foreach (EBooksFrePBillDetailWork detail in salesList)
                    {
                        if (detail.SALESDETAILRF_SALESSLIPCDDTLRF == 3)
                        {
                            deleteList.Add(detail);
                        }
                    }
                    foreach (EBooksFrePBillDetailWork deleteItem in deleteList)
                    {
                        salesList.Remove(deleteItem);
                    }
                }
                #endregion

                //--------------------------------------------------------
                // ���㖾�׃R�s�[
                //--------------------------------------------------------
                if (salesList != null && salesList.Count > 0)
                {
                    int detailRowCount = 0;
                    # region [���㖾��]
                    for (int index = 0; index < salesList.Count; index++)
                    {
                        //�V�����`�[���ǂ������f����t���O(�R�������)
                        bool newSlip = false;

                        # region [���㖾��(�`�[�v)]
                        if (frePrtPSetWork.FreePrtPprSpPrpseCd == 60)
                        {
                            detailRowCount += 1;
                            
                            // --- ADD START �c������ 2022/10/18 ----->>>>>
                            if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                                ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                                  ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                                    ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                                      ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                                        ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                                          ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                            ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                            {
                                if (index > 0)
                                {
                                    if (salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                    {
                                        bChgFlg = true;
                                    }
                                    else
                                    {
                                        bChgFlg = false;
                                    }

                                    EBooksFrePBillDetailWork salesData = salesList[index - 1];
                                    // �ŗ��ʏ��W�v
                                    SalesMeisaiTaxMoneyDiffCalc(index, headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, salesData, bChgFlg,
                                                       ref lTaxRate1SalesMoneyEx, ref lTaxRate1SalesPriceConsTax,
                                                         ref lTaxRate2SalesMoneyEx, ref lTaxRate2SalesPriceConsTax,
                                                           ref lOtherSalesMoneyEx, ref lOtherSalesPriceConsTax,
                                                             ref lTaxRate1MeisaiTotalTax, ref lTaxRate2MeisaiTotalTax, ref lOtherMeisaiTotalTax,
                                                               ref lSalesMoneyEx, ref lSalesMoneyExTaxOut,
                                                                 ref dicCustomerCode,
                                                                   dTaxRate1, dTaxRate2);
                                }
                            }
                            // --- ADD END   �c������ 2022/10/18 -----<<<<<
                            // 60:���א�����
                            if (index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                            {
                                // (�擪)�Ԏ햼(�Q�s�ڂ݈̂�)�@�����ڂ����鎞�̂ݏ������s��
                                if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL2RF"))
                                {
                                    if (detailRowCount == 2)
                                    {
                                        ReflectModelNameDetailExtra(ref table, salesList[index - 1], dmdPrtPtnWork);
                                    }
                                }
                                if (billDmdPrintParameter.ExistsSalesFooter)
                                {
                                    //����t�b�^
                                    ReflectSalesFooter(ref table, salesList[index - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                                }
                                if (billDmdPrintParameter.ExistsSalesFooter2)
                                {
                                    //����t�b�^�Q
                                    ReflectSalesFooter2(ref table, salesList[index - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                                }
                                if (billDmdPrintParameter.ExistsSalesFooter3)
                                {
                                    //����t�b�^�R
                                    ReflectSalesFooter3(ref table, salesList[index - 1], dmdPrtPtnWork, billDmdPrintParameter,headWork);
                                }

                                if (billDmdPrintParameter.ExistsSalesTotalFooter)
                                {
                                    // �W�v�s
                                    ReflectSummalyFooters(ref table, salesList[index - 1], dmdPrtPtnWork, SortRecordDivState.Sales, billDmdPrintParameter);
                                }

                                //���׍s
                                detailRowCount = 1;
                                //�`�[���ς�����̂�true
                                newSlip = true;
                            }


                        }
                        else
                        {
                            // 70:�`�[���v������

                            if (index > 0)
                            {
                                // --- ADD START �c������ 2022/10/18 ----->>>>>
                                if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                                    ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                                      ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                                        ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                                          ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                                            ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                                              ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                                ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                                {

                                    if (salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                    {
                                        bChgFlg = true;
                                    }
                                    else
                                    {
                                        bChgFlg = false;
                                    }

                                    EBooksFrePBillDetailWork salesData = salesList[index - 1];
                                    // �ŗ��ʏ��W�v
                                    SalesMeisaiTaxMoneyDiffCalc(index, headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, salesData, bChgFlg,
                                                       ref lTaxRate1SalesMoneyEx, ref lTaxRate1SalesPriceConsTax,
                                                         ref lTaxRate2SalesMoneyEx, ref lTaxRate2SalesPriceConsTax,
                                                           ref lOtherSalesMoneyEx, ref lOtherSalesPriceConsTax,
                                                             ref lTaxRate1MeisaiTotalTax, ref lTaxRate2MeisaiTotalTax, ref lOtherMeisaiTotalTax,
                                                               ref lSalesMoneyEx, ref lSalesMoneyExTaxOut,
                                                                 ref dicCustomerCode,
                                                                   dTaxRate1, dTaxRate2);
                                }
                                // --- ADD END   �c������ 2022/10/18 -----<<<<<

                                // �Q�s�ڈȍ~�͔�΂�
                                if (salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF == salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                {
                                    continue;
                                }
                                if (billDmdPrintParameter.ExistsSalesTotalFooter)
                                {
                                    // �W�v�s
                                    ReflectSummalyFooters(ref table, salesList[index - 1], dmdPrtPtnWork, SortRecordDivState.Sales, billDmdPrintParameter);
                                }
                            }
                        }
                        # endregion

                        #region[�R������ʓ��e]
                        if (billDmdPrintParameter.ExistsSalesHeader2)
                        {
                            DataRow headerRow = table.NewRow();

                            //���ׂ̓r���Ńw�b�_�[�s�����邩���f
                            bool sortDetail = false;
                            if (index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF == salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                            {
                                //�����`�[���ŁA�^���A�N���A�Ԏ햼���ς������
                                if (salesList[index - 1].ACCEPTODRCARRF_FULLMODELRF != salesList[index].ACCEPTODRCARRF_FULLMODELRF)
                                {
                                    sortDetail = true;
                                }
                            }
                            //�`�[���ς����or�ԗ���񂪕ς�����̂Ŕ���w�b�_�����
                            if (newSlip || sortDetail || index == 0)
                            {
                            	
                            }
                        }
                        #endregion

                        DataRow row = table.NewRow();

                        // "����p"���ڂ̓K�p
                        # region ["����p"���ڂ̓K�p]
                        // ��"����p"�ƕt�����ڂň󎚓��e�������ւ��܂��B
                        // �i�� �� ����p�i��
                        salesList[index].SALESDETAILRF_GOODSNORF = salesList[index].SALESDETAILRF_PRTGOODSNORF;
                        // ���[�J�[�R�[�h �� ����p���[�J�[�R�[�h
                        salesList[index].SALESDETAILRF_GOODSMAKERCDRF = salesList[index].SALESDETAILRF_PRTMAKERCODERF;
                        // ���[�J�[���� �� ����p���[�J�[����
                        salesList[index].SALESDETAILRF_MAKERNAMERF = salesList[index].SALESDETAILRF_PRTMAKERNAMERF;
                        # endregion

                        # region [���㖾��]
                        row["SALESSLIPRF.ACPTANODRSTATUSRF"] = salesList[index].SALESSLIPRF_ACPTANODRSTATUSRF;
                        row["SALESSLIPRF.SALESSLIPNUMRF"] = salesList[index].SALESSLIPRF_SALESSLIPNUMRF;
                        row["SALESSLIPRF.SECTIONCODERF"] = salesList[index].SALESSLIPRF_SECTIONCODERF;
                        row["SALESSLIPRF.SUBSECTIONCODERF"] = salesList[index].SALESSLIPRF_SUBSECTIONCODERF;
                        row["SALESSLIPRF.DEBITNOTEDIVRF"] = salesList[index].SALESSLIPRF_DEBITNOTEDIVRF;
                        row["SALESSLIPRF.SALESSLIPCDRF"] = salesList[index].SALESSLIPRF_SALESSLIPCDRF;
                        row["SALESSLIPRF.SALESGOODSCDRF"] = salesList[index].SALESSLIPRF_SALESGOODSCDRF;
                        row["SALESSLIPRF.ACCRECDIVCDRF"] = salesList[index].SALESSLIPRF_ACCRECDIVCDRF;
                        row["SALESSLIPRF.DEMANDADDUPSECCDRF"] = salesList[index].SALESSLIPRF_DEMANDADDUPSECCDRF;
                        row["SALESSLIPRF.SALESDATERF"] = salesList[index].SALESSLIPRF_SALESDATERF;
                        row["SALESSLIPRF.ADDUPADATERF"] = salesList[index].SALESSLIPRF_ADDUPADATERF;
                        row["SALESSLIPRF.INPUTAGENCDRF"] = salesList[index].SALESSLIPRF_INPUTAGENCDRF;
                        row["SALESSLIPRF.INPUTAGENNMRF"] = salesList[index].SALESSLIPRF_INPUTAGENNMRF;
                        row["SALESSLIPRF.SALESINPUTCODERF"] = salesList[index].SALESSLIPRF_SALESINPUTCODERF;
                        row["SALESSLIPRF.SALESINPUTNAMERF"] = salesList[index].SALESSLIPRF_SALESINPUTNAMERF;
                        row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = salesList[index].SALESSLIPRF_FRONTEMPLOYEECDRF;
                        row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = salesList[index].SALESSLIPRF_FRONTEMPLOYEENMRF;
                        row["SALESSLIPRF.SALESEMPLOYEECDRF"] = salesList[index].SALESSLIPRF_SALESEMPLOYEECDRF;
                        row["SALESSLIPRF.SALESEMPLOYEENMRF"] = salesList[index].SALESSLIPRF_SALESEMPLOYEENMRF;
                        row["SALESSLIPRF.SALESTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESTOTALTAXINCRF;
                        row["SALESSLIPRF.SALESTOTALTAXEXCRF"] = salesList[index].SALESSLIPRF_SALESTOTALTAXEXCRF;
                        row["SALESSLIPRF.SALESPRTTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESPRTTOTALTAXINCRF;
                        row["SALESSLIPRF.SALESPRTTOTALTAXEXCRF"] = salesList[index].SALESSLIPRF_SALESPRTTOTALTAXEXCRF;
                        row["SALESSLIPRF.SALESWORKTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESWORKTOTALTAXINCRF;
                        row["SALESSLIPRF.SALESWORKTOTALTAXEXCRF"] = salesList[index].SALESSLIPRF_SALESWORKTOTALTAXEXCRF;
                        row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESSUBTOTALTAXINCRF;
                        row["SALESSLIPRF.SALESPRTSUBTTLINCRF"] = salesList[index].SALESSLIPRF_SALESPRTSUBTTLINCRF;
                        row["SALESSLIPRF.SALESPRTSUBTTLEXCRF"] = salesList[index].SALESSLIPRF_SALESPRTSUBTTLEXCRF;
                        row["SALESSLIPRF.SALESWORKSUBTTLINCRF"] = salesList[index].SALESSLIPRF_SALESWORKSUBTTLINCRF;
                        row["SALESSLIPRF.SALESWORKSUBTTLEXCRF"] = salesList[index].SALESSLIPRF_SALESWORKSUBTTLEXCRF;
                        row["SALESSLIPRF.SALESSUBTOTALTAXRF"] = salesList[index].SALESSLIPRF_SALESSUBTOTALTAXRF;
                        row["SALESSLIPRF.ITDEDPARTSDISOUTTAXRF"] = salesList[index].SALESSLIPRF_ITDEDPARTSDISOUTTAXRF;
                        row["SALESSLIPRF.ITDEDPARTSDISINTAXRF"] = salesList[index].SALESSLIPRF_ITDEDPARTSDISINTAXRF;
                        row["SALESSLIPRF.ITDEDWORKDISOUTTAXRF"] = salesList[index].SALESSLIPRF_ITDEDWORKDISOUTTAXRF;
                        row["SALESSLIPRF.ITDEDWORKDISINTAXRF"] = salesList[index].SALESSLIPRF_ITDEDWORKDISINTAXRF;
                        row["SALESSLIPRF.PARTSDISCOUNTRATERF"] = salesList[index].SALESSLIPRF_PARTSDISCOUNTRATERF;
                        row["SALESSLIPRF.RAVORDISCOUNTRATERF"] = salesList[index].SALESSLIPRF_RAVORDISCOUNTRATERF;
                        row["SALESSLIPRF.TOTALCOSTRF"] = salesList[index].SALESSLIPRF_TOTALCOSTRF;
                        // --- ADD START �c������ 2022/10/18 ----->>>>>
                        row["SALESSLIPRF.CONSTAXRATERF"] = 0;
                        if (ReportItemDic.ContainsKey("SALESSLIPRF.CONSTAXRATERF"))
                        {
                            if ((salesList[index].SALESSLIPRF_CONSTAXLAYMETHODRF != 9) && (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF != 3))
                            {
                                if (salesList[index].SALESDETAILRF_TAXATIONDIVCDRF != 1)
                                {
                                    // ����Őŗ��u���ׁv
                                    row["SALESSLIPRF.CONSTAXRATERF"] = salesList[index].SALESSLIPRF_CONSTAXRATERF;
                                }
                            }
                        }
                        // --- ADD END   �c������ 2022/10/18 -----<<<<<
                        row["SALESSLIPRF.AUTODEPOSITCDRF"] = salesList[index].SALESSLIPRF_AUTODEPOSITCDRF;
                        row["SALESSLIPRF.AUTODEPOSITSLIPNORF"] = salesList[index].SALESSLIPRF_AUTODEPOSITSLIPNORF;
                        row["SALESSLIPRF.DEPOSITALLOWANCETTLRF"] = salesList[index].SALESSLIPRF_DEPOSITALLOWANCETTLRF;
                        row["SALESSLIPRF.DEPOSITALWCBLNCERF"] = salesList[index].SALESSLIPRF_DEPOSITALWCBLNCERF;
                        row["SALESSLIPRF.CLAIMCODERF"] = salesList[index].SALESSLIPRF_CLAIMCODERF;
                        row["SALESSLIPRF.CUSTOMERCODERF"] = salesList[index].SALESSLIPRF_CUSTOMERCODERF;
                        row["SALESSLIPRF.CUSTOMERNAMERF"] = salesList[index].SALESSLIPRF_CUSTOMERNAMERF;
                        row["SALESSLIPRF.CUSTOMERNAME2RF"] = salesList[index].SALESSLIPRF_CUSTOMERNAME2RF;
                        row["SALESSLIPRF.CUSTOMERSNMRF"] = salesList[index].SALESSLIPRF_CUSTOMERSNMRF;
                        row["SALESSLIPRF.HONORIFICTITLERF"] = salesList[index].SALESSLIPRF_HONORIFICTITLERF;
                        row["SALESSLIPRF.ADDRESSEECODERF"] = salesList[index].SALESSLIPRF_ADDRESSEECODERF;
                        row["SALESSLIPRF.ADDRESSEENAMERF"] = salesList[index].SALESSLIPRF_ADDRESSEENAMERF;
                        row["SALESSLIPRF.ADDRESSEENAME2RF"] = salesList[index].SALESSLIPRF_ADDRESSEENAME2RF;
                        row["SALESSLIPRF.SLIPNOTERF"] = salesList[index].SALESSLIPRF_SLIPNOTERF;
                        row["SALESSLIPRF.SLIPNOTE2RF"] = salesList[index].SALESSLIPRF_SLIPNOTE2RF;
                        row["SALESSLIPRF.SLIPNOTE3RF"] = salesList[index].SALESSLIPRF_SLIPNOTE3RF;
                        row["SALESSLIPRF.RETGOODSREASONDIVRF"] = salesList[index].SALESSLIPRF_RETGOODSREASONDIVRF;
                        row["SALESSLIPRF.RETGOODSREASONRF"] = salesList[index].SALESSLIPRF_RETGOODSREASONRF;
                        row["SALESSLIPRF.DETAILROWCOUNTRF"] = salesList[index].SALESSLIPRF_DETAILROWCOUNTRF;
                        row["SALESSLIPRF.UOEREMARK1RF"] = salesList[index].SALESSLIPRF_UOEREMARK1RF;
                        row["SALESSLIPRF.UOEREMARK2RF"] = salesList[index].SALESSLIPRF_UOEREMARK2RF;
                        row["SALESSLIPRF.DELIVEREDGOODSDIVRF"] = salesList[index].SALESSLIPRF_DELIVEREDGOODSDIVRF;
                        row["SALESSLIPRF.DELIVEREDGOODSDIVNMRF"] = salesList[index].SALESSLIPRF_DELIVEREDGOODSDIVNMRF;
                        row["SALESSLIPRF.STOCKGOODSTTLTAXEXCRF"] = salesList[index].SALESSLIPRF_STOCKGOODSTTLTAXEXCRF;
                        row["SALESSLIPRF.PUREGOODSTTLTAXEXCRF"] = salesList[index].SALESSLIPRF_PUREGOODSTTLTAXEXCRF;
                        row["SALESSLIPRF.FOOTNOTES1RF"] = salesList[index].SALESSLIPRF_FOOTNOTES1RF;
                        row["SALESSLIPRF.FOOTNOTES2RF"] = salesList[index].SALESSLIPRF_FOOTNOTES2RF;
                        row["SECDTL.SECTIONGUIDENMRF"] = salesList[index].SECDTL_SECTIONGUIDENMRF;
                        row["SECDTL.SECTIONGUIDESNMRF"] = salesList[index].SECDTL_SECTIONGUIDESNMRF;
                        row["SECDTL.COMPANYNAMECD1RF"] = salesList[index].SECDTL_COMPANYNAMECD1RF;
                        row["SUBSAL.SUBSECTIONNAMERF"] = salesList[index].SUBSAL_SUBSECTIONNAMERF;
                        row["SALESDETAILRF.ACCEPTANORDERNORF"] = salesList[index].SALESDETAILRF_ACCEPTANORDERNORF;
                        row["SALESDETAILRF.SALESROWNORF"] = salesList[index].SALESDETAILRF_SALESROWNORF;
                        row["SALESDETAILRF.DELIGDSCMPLTDUEDATERF"] = salesList[index].SALESDETAILRF_DELIGDSCMPLTDUEDATERF;
                        row["SALESDETAILRF.GOODSKINDCODERF"] = salesList[index].SALESDETAILRF_GOODSKINDCODERF;
                        row["SALESDETAILRF.GOODSMAKERCDRF"] = salesList[index].SALESDETAILRF_GOODSMAKERCDRF;
                        row["SALESDETAILRF.MAKERNAMERF"] = salesList[index].SALESDETAILRF_MAKERNAMERF;
                        row["SALESDETAILRF.GOODSNORF"] = salesList[index].SALESDETAILRF_GOODSNORF;
                        row["SALESDETAILRF.GOODSNAMERF"] = salesList[index].SALESDETAILRF_GOODSNAMERF;
                        row["SALESDETAILRF.GOODSSHORTNAMERF"] = salesList[index].SALESDETAILRF_GOODSSHORTNAMERF;
                        row["SALESDETAILRF.GOODSLGROUPRF"] = salesList[index].SALESDETAILRF_GOODSLGROUPRF;
                        row["SALESDETAILRF.GOODSLGROUPNAMERF"] = salesList[index].SALESDETAILRF_GOODSLGROUPNAMERF;
                        row["SALESDETAILRF.GOODSMGROUPRF"] = salesList[index].SALESDETAILRF_GOODSMGROUPRF;
                        row["SALESDETAILRF.GOODSMGROUPNAMERF"] = salesList[index].SALESDETAILRF_GOODSMGROUPNAMERF;
                        row["SALESDETAILRF.BLGROUPCODERF"] = salesList[index].SALESDETAILRF_BLGROUPCODERF;
                        row["SALESDETAILRF.BLGROUPNAMERF"] = salesList[index].SALESDETAILRF_BLGROUPNAMERF;
                        row["SALESDETAILRF.BLGOODSCODERF"] = salesList[index].SALESDETAILRF_BLGOODSCODERF;
                        row["SALESDETAILRF.BLGOODSFULLNAMERF"] = salesList[index].SALESDETAILRF_BLGOODSFULLNAMERF;
                        row["SALESDETAILRF.ENTERPRISEGANRECODERF"] = salesList[index].SALESDETAILRF_ENTERPRISEGANRECODERF;
                        row["SALESDETAILRF.ENTERPRISEGANRENAMERF"] = salesList[index].SALESDETAILRF_ENTERPRISEGANRENAMERF;
                        row["SALESDETAILRF.WAREHOUSECODERF"] = salesList[index].SALESDETAILRF_WAREHOUSECODERF;
                        row["SALESDETAILRF.WAREHOUSENAMERF"] = salesList[index].SALESDETAILRF_WAREHOUSENAMERF;
                        row["SALESDETAILRF.WAREHOUSESHELFNORF"] = salesList[index].SALESDETAILRF_WAREHOUSESHELFNORF;
                        row["SALESDETAILRF.SALESORDERDIVCDRF"] = salesList[index].SALESDETAILRF_SALESORDERDIVCDRF;
                        row["SALESDETAILRF.OPENPRICEDIVRF"] = salesList[index].SALESDETAILRF_OPENPRICEDIVRF;
                        row["SALESDETAILRF.GOODSRATERANKRF"] = salesList[index].SALESDETAILRF_GOODSRATERANKRF;
                        row["SALESDETAILRF.LISTPRICERATERF"] = salesList[index].SALESDETAILRF_LISTPRICERATERF;
                        row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = salesList[index].SALESDETAILRF_LISTPRICETAXINCFLRF;
                        row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = salesList[index].SALESDETAILRF_LISTPRICETAXEXCFLRF;
                        row["SALESDETAILRF.SALESRATERF"] = salesList[index].SALESDETAILRF_SALESRATERF;
                        row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = salesList[index].SALESDETAILRF_SALESUNPRCTAXINCFLRF;
                        row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = salesList[index].SALESDETAILRF_SALESUNPRCTAXEXCFLRF;
                        row["SALESDETAILRF.COSTRATERF"] = salesList[index].SALESDETAILRF_COSTRATERF;
                        row["SALESDETAILRF.SALESUNITCOSTRF"] = salesList[index].SALESDETAILRF_SALESUNITCOSTRF;
                        row["SALESDETAILRF.PRTBLGOODSCODERF"] = salesList[index].SALESDETAILRF_PRTBLGOODSCODERF;
                        row["SALESDETAILRF.PRTBLGOODSNAMERF"] = salesList[index].SALESDETAILRF_PRTBLGOODSNAMERF;
                        row["SALESDETAILRF.WORKMANHOURRF"] = salesList[index].SALESDETAILRF_WORKMANHOURRF;
                        row["SALESDETAILRF.SHIPMENTCNTRF"] = salesList[index].SALESDETAILRF_SHIPMENTCNTRF;
                        row["SALESDETAILRF.SALESMONEYTAXINCRF"] = salesList[index].SALESDETAILRF_SALESMONEYTAXINCRF;
                        row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = salesList[index].SALESDETAILRF_SALESMONEYTAXEXCRF;
                        row["SALESDETAILRF.COSTRF"] = salesList[index].SALESDETAILRF_COSTRF;
                        row["SALESDETAILRF.TAXATIONDIVCDRF"] = salesList[index].SALESDETAILRF_TAXATIONDIVCDRF;
                        row["SALESDETAILRF.PARTYSLIPNUMDTLRF"] = salesList[index].SALESDETAILRF_PARTYSLIPNUMDTLRF;
                        row["SALESDETAILRF.DTLNOTERF"] = salesList[index].SALESDETAILRF_DTLNOTERF;
                        row["SALESDETAILRF.SUPPLIERCDRF"] = salesList[index].SALESDETAILRF_SUPPLIERCDRF;
                        row["SALESDETAILRF.SUPPLIERSNMRF"] = salesList[index].SALESDETAILRF_SUPPLIERSNMRF;
                        row["SALESDETAILRF.SLIPMEMO1RF"] = salesList[index].SALESDETAILRF_SLIPMEMO1RF;
                        row["SALESDETAILRF.SLIPMEMO2RF"] = salesList[index].SALESDETAILRF_SLIPMEMO2RF;
                        row["SALESDETAILRF.SLIPMEMO3RF"] = salesList[index].SALESDETAILRF_SLIPMEMO3RF;
                        row["SALESDETAILRF.INSIDEMEMO1RF"] = salesList[index].SALESDETAILRF_INSIDEMEMO1RF;
                        row["SALESDETAILRF.INSIDEMEMO2RF"] = salesList[index].SALESDETAILRF_INSIDEMEMO2RF;
                        row["SALESDETAILRF.INSIDEMEMO3RF"] = salesList[index].SALESDETAILRF_INSIDEMEMO3RF;
                        row["SALESDETAILRF.BFLISTPRICERF"] = salesList[index].SALESDETAILRF_BFLISTPRICERF;
                        row["SALESDETAILRF.BFSALESUNITPRICERF"] = salesList[index].SALESDETAILRF_BFSALESUNITPRICERF;
                        row["SALESDETAILRF.BFUNITCOSTRF"] = salesList[index].SALESDETAILRF_BFUNITCOSTRF;
                        row["SALESDETAILRF.CMPLTSALESROWNORF"] = salesList[index].SALESDETAILRF_CMPLTSALESROWNORF;
                        row["SALESDETAILRF.CMPLTGOODSMAKERCDRF"] = salesList[index].SALESDETAILRF_CMPLTGOODSMAKERCDRF;
                        row["SALESDETAILRF.CMPLTMAKERNAMERF"] = salesList[index].SALESDETAILRF_CMPLTMAKERNAMERF;
                        row["SALESDETAILRF.CMPLTGOODSNAMERF"] = salesList[index].SALESDETAILRF_CMPLTGOODSNAMERF;
                        row["SALESDETAILRF.CMPLTSHIPMENTCNTRF"] = salesList[index].SALESDETAILRF_CMPLTSHIPMENTCNTRF;
                        row["SALESDETAILRF.CMPLTSALESUNPRCFLRF"] = salesList[index].SALESDETAILRF_CMPLTSALESUNPRCFLRF;
                        row["SALESDETAILRF.CMPLTSALESMONEYRF"] = salesList[index].SALESDETAILRF_CMPLTSALESMONEYRF;
                        row["SALESDETAILRF.CMPLTSALESUNITCOSTRF"] = salesList[index].SALESDETAILRF_CMPLTSALESUNITCOSTRF;
                        row["SALESDETAILRF.CMPLTCOSTRF"] = salesList[index].SALESDETAILRF_CMPLTCOSTRF;
                        row["SALESDETAILRF.CMPLTPARTYSALSLNUMRF"] = salesList[index].SALESDETAILRF_CMPLTPARTYSALSLNUMRF;
                        row["SALESDETAILRF.CMPLTNOTERF"] = salesList[index].SALESDETAILRF_CMPLTNOTERF;
                        row["ACCEPTODRCARRF.CARMNGNORF"] = salesList[index].ACCEPTODRCARRF_CARMNGNORF;
                        row["ACCEPTODRCARRF.CARMNGCODERF"] = salesList[index].ACCEPTODRCARRF_CARMNGCODERF;
                        row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE1CODERF;
                        row["ACCEPTODRCARRF.NUMBERPLATE1NAMERF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE1NAMERF;
                        row["ACCEPTODRCARRF.NUMBERPLATE2RF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE2RF;
                        row["ACCEPTODRCARRF.NUMBERPLATE3RF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE3RF;
                        row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = salesList[index].ACCEPTODRCARRF_NUMBERPLATE4RF;
                        row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = salesList[index].ACCEPTODRCARRF_FIRSTENTRYDATERF;
                        row["ACCEPTODRCARRF.MAKERCODERF"] = salesList[index].ACCEPTODRCARRF_MAKERCODERF;
                        row["ACCEPTODRCARRF.MAKERFULLNAMERF"] = salesList[index].ACCEPTODRCARRF_MAKERFULLNAMERF;
                        row["ACCEPTODRCARRF.MODELCODERF"] = salesList[index].ACCEPTODRCARRF_MODELCODERF;
                        row["ACCEPTODRCARRF.MODELSUBCODERF"] = salesList[index].ACCEPTODRCARRF_MODELSUBCODERF;
                        row["ACCEPTODRCARRF.MODELFULLNAMERF"] = salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF;
                        row["ACCEPTODRCARRF.EXHAUSTGASSIGNRF"] = salesList[index].ACCEPTODRCARRF_EXHAUSTGASSIGNRF;
                        row["ACCEPTODRCARRF.SERIESMODELRF"] = salesList[index].ACCEPTODRCARRF_SERIESMODELRF;
                        row["ACCEPTODRCARRF.CATEGORYSIGNMODELRF"] = salesList[index].ACCEPTODRCARRF_CATEGORYSIGNMODELRF;
                        row["ACCEPTODRCARRF.FULLMODELRF"] = salesList[index].ACCEPTODRCARRF_FULLMODELRF;
                        row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = salesList[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF;
                        row["ACCEPTODRCARRF.CATEGORYNORF"] = salesList[index].ACCEPTODRCARRF_CATEGORYNORF;
                        row["ACCEPTODRCARRF.FRAMEMODELRF"] = salesList[index].ACCEPTODRCARRF_FRAMEMODELRF;
                        row["ACCEPTODRCARRF.FRAMENORF"] = salesList[index].ACCEPTODRCARRF_FRAMENORF;
                        row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = salesList[index].ACCEPTODRCARRF_SEARCHFRAMENORF;
                        row["ACCEPTODRCARRF.ENGINEMODELNMRF"] = salesList[index].ACCEPTODRCARRF_ENGINEMODELNMRF;
                        row["ACCEPTODRCARRF.RELEVANCEMODELRF"] = salesList[index].ACCEPTODRCARRF_RELEVANCEMODELRF;
                        row["ACCEPTODRCARRF.SUBCARNMCDRF"] = salesList[index].ACCEPTODRCARRF_SUBCARNMCDRF;
                        row["ACCEPTODRCARRF.MODELGRADESNAMERF"] = salesList[index].ACCEPTODRCARRF_MODELGRADESNAMERF;
                        row["ACCEPTODRCARRF.COLORCODERF"] = salesList[index].ACCEPTODRCARRF_COLORCODERF;
                        row["ACCEPTODRCARRF.COLORNAME1RF"] = salesList[index].ACCEPTODRCARRF_COLORNAME1RF;
                        row["ACCEPTODRCARRF.TRIMCODERF"] = salesList[index].ACCEPTODRCARRF_TRIMCODERF;
                        row["ACCEPTODRCARRF.TRIMNAMERF"] = salesList[index].ACCEPTODRCARRF_TRIMNAMERF;
                        row["ACCEPTODRCARRF.MILEAGERF"] = salesList[index].ACCEPTODRCARRF_MILEAGERF;
                        row["SALESDETAILRF.GOODSNAMEKANARF"] = salesList[index].SALESDETAILRF_GOODSNAMEKANARF; // ���i���̃J�i
                        row["SALESDETAILRF.MAKERKANANAMERF"] = salesList[index].SALESDETAILRF_MAKERKANANAMERF; // ���[�J�[�J�i����
                        row["ACCEPTODRCARRF.MODELHALFNAMERF"] = salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF; // �Ԏ피�p����
                        row["SALESDETAILRF.PRTGOODSNORF"] = salesList[index].SALESDETAILRF_PRTGOODSNORF; // ����p�i��
                        row["SALESDETAILRF.PRTMAKERCODERF"] = salesList[index].SALESDETAILRF_PRTMAKERCODERF; // ����p���[�J�[�R�[�h
                        row["SALESDETAILRF.PRTMAKERNAMERF"] = salesList[index].SALESDETAILRF_PRTMAKERNAMERF; // ����p���[�J�[����
                        row["DADD.FULLMODELHD2SEARCHRF"] = GetFullModel(salesList[index]);
                        row["DADD.MODELHALFNAMEHD2SEARCHRF"] = salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF;
                        row["DADD.FOOTER3PRINTRF"] = 1;
                        // --- ADD START �c������ 2022/10/18 ----->>>>>
                        // ����œ]�ŕ����u��ېŁA�s�l���ȊO�̏ꍇ�A�󎚂���v
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXRATERF"))
                        {
                            if ((salesList[index].SALESSLIPRF_CONSTAXLAYMETHODRF != 9) && (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF != 3))
                            {
                                if (salesList[index].SALESDETAILRF_TAXATIONDIVCDRF != 1)
                                {
                                    // ����Őŗ�(����)�u���ׁv
                                    row["TAX.DTLTAXRATERF"] = Convert.ToString(Convert.ToInt32(salesList[index].SALESSLIPRF_CONSTAXRATERF * 100)) + "%";
                                }
                            }
                        }
                        // --- ADD END   �c������ 2022/10/18 -----<<<<<
                        //����Őŗ��u���ׁv
                        row["SALESSLIPRF.CONSTAXRATERF"] = 0;
                        if (ReportItemDic.ContainsKey("SALESSLIPRF.CONSTAXRATERF"))
                        {
                            if ((salesList[index].SALESSLIPRF_CONSTAXLAYMETHODRF != 9) && (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF != 3))
                            {
                                if (salesList[index].SALESDETAILRF_TAXATIONDIVCDRF != 1)
                                {
                                    // ����Őŗ��u���ׁv
                                    row["SALESSLIPRF.CONSTAXRATERF"] = salesList[index].SALESSLIPRF_CONSTAXRATERF;
                                }
                            }
                        }
                        # endregion

                        # region [���㖾��(�����ȊO)]

                        // ���z���ڕ␳
                        # region [���z���ڕ␳]
                        // ����Ďg�p����ƈӐ}�������ʂɂȂ�Ȃ����z���ڂ̕␳
                        row["SALESSLIPRF.SALESSUBTOTALTAXEXCRF"] = salesList[index].SALESSLIPRF_SALESTOTALTAXEXCRF;
                        row["SALESSLIPRF.SALESSUBTOTALTAXINCRF"] = salesList[index].SALESSLIPRF_SALESTOTALTAXINCRF;
                        # endregion

                        // ���דE�v
                        # region [���דE�v]
                        // DmdDtlOutlineCodeRF = 0:�󎚂��Ȃ� 1:�i�� 2:�艿
                        switch (dmdPrtPtnWork.DmdDtlOutlineCode)
                        {
                            case 1:
                                {
                                    // �i��
                                    row["DADD.DMDDTLOUTLINERF"] = salesList[index].SALESDETAILRF_GOODSNORF;
                                    row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value;
                                }
                                break;
                            case 2:
                                {
                                    // �艿
                                    row["DADD.DMDDTLOUTLINERF"] = DBNull.Value;
                                    row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = salesList[index].SALESDETAILRF_LISTPRICETAXEXCFLRF;
                                }
                                break;
                            case 0:
                            default:
                                {
                                    // �󎚂��Ȃ�
                                    row["DADD.DMDDTLOUTLINERF"] = DBNull.Value;
                                    row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value;
                                }
                                break;
                        }
                        # endregion

                        // ���t�W�J
                        # region [���t�W�J]
                        // (�ʏ�)
                        ExtractDate(ref row, allDefSet.EraNameDispCd2, salesList[index].SALESSLIPRF_SALESDATERF, "DADD.SALESDATE", false); // yyyymmdd
                        // (�N��)
                        ExtractDate(ref row, allDefSet.EraNameDispCd1, salesList[index].ACCEPTODRCARRF_FIRSTENTRYDATERF, "DADD.FIRSTENTRYDATE", true); // yyyymm
                        //�i�ʏ�j�����p
                        ExtractDate(ref row, allDefSet.EraNameDispCd1, salesList[index].SALESSLIPRF_SALESDATERF, "DADD.SALESDATEHD2SEARCH", false); //yyyymmdd
                        # endregion

                        // �����`�[�ԍ��i�w�b�_�p�j
                        # region [�����`�[�ԍ��i�w�b�_�p�j]
                        row["DADD.PARTYSALESLIPNUMRF"] = salesList[index].SALESSLIPRF_PARTYSALESLIPNUMRF; // �����e�̓t�b�^�p�Ɠ���
                        # endregion

                        // ���p���Ή�
                        # region [���p���Ή�]
                        // �i���J�i
                        if (string.IsNullOrEmpty(salesList[index].SALESDETAILRF_GOODSNAMEKANARF))
                        {
                            row["SALESDETAILRF.GOODSNAMEKANARF"] = salesList[index].SALESDETAILRF_GOODSNAMERF; // ���󔒂Ȃ�i�����Z�b�g
                        }
                        // ���[�J�[���J�i
                        if (string.IsNullOrEmpty(salesList[index].SALESDETAILRF_MAKERKANANAMERF))
                        {
                            row["SALESDETAILRF.MAKERKANANAMERF"] = salesList[index].SALESDETAILRF_MAKERNAMERF; // ���󔒂Ȃ烁�[�J�[�����Z�b�g
                        }
                        // �Ԏ피�p��
                        if (string.IsNullOrEmpty(salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF))
                        {
                            row["ACCEPTODRCARRF.MODELHALFNAMERF"] = GetKanaString(salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                            row["DADD.MODELHALFNAMEHD2SEARCHRF"] = GetKanaString(salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                        }

                        // �i�擪�j�Ԏ피�p���̂����鎞�̂ݏ������s��
                        if (ReportItemDic.ContainsKey("DADD.MODELHALFNAME2RF"))
                        {
                            if (index == 0 || index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                            {
                                //���ׂP�s�ڂ̎Ԏ햼���󎚂���
                                if (string.IsNullOrEmpty(salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF))
                                {
                                    row["DADD.MODELHALFNAME2RF"] = GetKanaString(salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                                }
                                else
                                {
                                    row["DADD.MODELHALFNAME2RF"] = salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF;
                                }
                            }
                        }
                        # endregion

                        //(�擪)�^���@�����ڂ����鎞�̂ݏ������s��
                        if (ReportItemDic.ContainsKey("DADD.FULLMODELRF"))
                        {
                            if (index == 0 || index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                            {
                                //���ׂP�s�ڂ̌^�����󎚂���
                                row["DADD.FULLMODELRF"] = salesList[index].ACCEPTODRCARRF_FULLMODELRF;
                            }
                        }

                        //(�擪)�Ԏ햼(�Q�s�ڈ�)  �����ڂ����鎞�̂ݏ������s��
                        if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL2RF"))
                        {
                                //���׍s����2�s�ȏ�̎��A2�s�ڂɎԎ햼����
                                if (detailRowCount == 2)
                                {
                                    //1�s�ڂ̎Ԏ햼���󎚂���
                                    row["DADD.MODELHALFNAMEDTL2RF"] = salesList[index - 1].ACCEPTODRCARRF_MODELHALFNAMERF;

                                    if (string.IsNullOrEmpty(salesList[index - 1].ACCEPTODRCARRF_MODELHALFNAMERF))
                                    {
                                        row["DADD.MODELHALFNAMEDTL2RF"] = GetKanaString(salesList[index - 1].ACCEPTODRCARRF_MODELFULLNAMERF);
                                    }
                                }
                            }

                        //(�擪)�Ԏ햼(�Q�s�ڈ�)�Q  �����ڂ����鎞�̂ݏ������s��
                        if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL3RF"))
                        {
                            if (detailRowCount == 1)
                            {
                                if (index == 0 || index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                {
                                    //���ׂP�s�ڂ̎Ԏ햼���擾����
                                    _modelHalfNameDtl1 = salesList[index].ACCEPTODRCARRF_MODELHALFNAMERF;
                                    if (string.IsNullOrEmpty(_modelHalfNameDtl1))
                                    {
                                        _modelHalfNameDtl1 = GetKanaString(salesList[index].ACCEPTODRCARRF_MODELFULLNAMERF);
                                    }
                                }
                            }
                            if (detailRowCount == 2)
                            {
                                //1�s�ڂ̎Ԏ햼���󎚂���
                                row["DADD.MODELHALFNAMEDTL3RF"] = _modelHalfNameDtl1;
                                _modelHalfNameDtl3PrtFlg = true;
                            }
                        }
                        // �i�擪�j�ԗ��Ǘ��ԍ��i�Q�s�ڈ󎚁j�@�����ڂ����鎞�̂ݏ������s��
                        if (ReportItemDic.ContainsKey("DADD.CARMNGNO2RF"))
                        {
                            if (detailRowCount == 1)
                            {
                                if (index == 0 || index > 0 && salesList[index - 1].SALESSLIPRF_SALESSLIPNUMRF != salesList[index].SALESSLIPRF_SALESSLIPNUMRF)
                                {
                                    //���ׂP�s�ڂ̎ԗ��Ǘ��ԍ����擾����
                                    _carMngNo2Dtl1 = salesList[index].ACCEPTODRCARRF_CARMNGCODERF;
                                }
                            }
                            if (detailRowCount == 2)
                            {
                                //1�s�ڂ̎Ԏ햼���󎚂���
                                row["DADD.CARMNGNO2RF"] = _carMngNo2Dtl1;
                                if (!string.IsNullOrEmpty(_carMngNo2Dtl1))
                                {
                                    row["DADD.CARMNGCODETITLE2RF"] = "�y��ڰāz";
                                }
                                _carMngNo2PrtFlg = true;
                            }
                        }

                        if (ReportItemDic.ContainsKey("SALESSLIPRF.SLIPNOTE2_2RF"))
                        {
                            string salesSlipNote2 = salesList[index].SALESSLIPRF_SLIPNOTE2RF;
                            string prtSalesSlipNote2 = "";
                            string targetStr = "";
                            int maxNum = sjisEnc.GetByteCount(salesSlipNote2);
                            int prtCnt = 16;    // ��s�Ɉ󎚂���o�C�g��
                            int cutPoint = 0;
                            int nowNum = 0;
                            if (detailRowCount == 2)
                            {
                                // �Q�s�ڂȂ���l�Q�̓�����16�o�C�g��
                                if (maxNum > prtCnt)
                                {
                                    while (nowNum < prtCnt)
                                    {
                                        targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                        if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                        {
                                            break;
                                        }
                                        cutPoint++;
                                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                    }
                                    prtSalesSlipNote2 = salesSlipNote2.Substring(0, cutPoint);
                                }
                                else
                                {
                                    prtSalesSlipNote2 = salesSlipNote2;
                                }
                                if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                    row["SALESSLIPRF.SLIPNOTE2_2RF"] = DBNull.Value;
                                else
                                    row["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;
                                _slipNote2PrtCnt++;
                            }
                            else if (detailRowCount == 3)
                            {
                                // �R�s�ڂȂ���l�Q��17�o�C�g�ڂ���16�o�C�g��
                                if (maxNum > prtCnt)
                                {
                                    while (nowNum < prtCnt)
                                    {
                                        targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                        if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                        {
                                            break;
                                        }
                                        cutPoint++;
                                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                    }
                                    salesSlipNote2 = salesSlipNote2.Substring(cutPoint, salesSlipNote2.Length - cutPoint);

                                    if (maxNum > prtCnt * 2)
                                    {
                                        maxNum = sjisEnc.GetByteCount(salesSlipNote2);
                                        nowNum = 0;
                                        cutPoint = 0;
                                        while (nowNum < prtCnt)
                                        {
                                            targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                            if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                            {
                                                break;
                                            }
                                            cutPoint++;
                                            nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                        }
                                        prtSalesSlipNote2 = salesSlipNote2.Substring(0, cutPoint);
                                    }
                                    else
                                    {
                                        prtSalesSlipNote2 = salesSlipNote2;
                                    }
                                }
                                else
                                {
                                    prtSalesSlipNote2 = "";
                                }
                                if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                    row["SALESSLIPRF.SLIPNOTE2_2RF"] = DBNull.Value;
                                else
                                    row["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;
                                _slipNote2PrtCnt++;
                            }
                        }
                        if (ReportItemDic.ContainsKey("DADD.FULLMODELORMODELHALFNAMERF"))
                        {
                            string fllModel = row["ACCEPTODRCARRF.FULLMODELRF"].ToString();
                            string modelHalfName = row["ACCEPTODRCARRF.MODELHALFNAMERF"].ToString();
                            if (string.IsNullOrEmpty(fllModel))
                            {
                                // �^�����󔒂Ȃ�Ԏ피�p���̂���
                                row["DADD.FULLMODELORMODELHALFNAMERF"] = modelHalfName;
                            }
                            else
                            {
                                // �^�����Z�b�g����Ă���Ȃ�^������
                                row["DADD.FULLMODELORMODELHALFNAMERF"] = fllModel;
                            }
                        }
                        if (billDmdPrintParameter.ExistsSalesHeader2)
                        {
                            //����`�[�敪�R�[�h(�����p)
                            if (salesList[index].SALESSLIPRF_SALESSLIPCDRF == 0)
                            {
                                //����
                                row["DADD.SALESSLIPCDCHANGESEARCHRF"] = 01;
                            }
                            else
                            {
                                //�ԕi
                                row["DADD.SALESSLIPCDCHANGESEARCHRF"] = 02;
                            }
                        }

                        // �\�[�g�E���v�Ή�
                        # region [�\�[�g�E���v�Ή�]
                        row[ct_col_Sort_CustomerCode] = salesList[index].SALESSLIPRF_CUSTOMERCODERF;
                        row[ct_col_Sort_Date] = salesList[index].SALESSLIPRF_SALESDATERF;
                        row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                        row[ct_col_Sort_SalesSlipNo] = salesList[index].SALESSLIPRF_SALESSLIPNUMRF;
                        row[ct_col_Sort_DepositSlipNo] = 0;
                        row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                        row[ct_col_Sort_DetailRowNo] = salesList[index].SALESDETAILRF_SALESROWNORF * 10;
                        row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                        # endregion

                        // �`�[���v�������p ���׃^�C�g��
                        # region [�`�[���v�������p ���׃^�C�g��]
                        switch (salesList[index].SALESSLIPRF_SALESSLIPCDRF)
                        {
                            case 0:
                                row["DSAL.DETAILTITLERF"] = "����";
                                break;
                            case 1:
                                row["DSAL.DETAILTITLERF"] = "�ԕi";
                                break;
                        }

                        # endregion

                        // �v���[�g�ԍ��^�C�g��
                        row["DADD.CARMNGCODETITLERF"] = billDmdPrintParameter.CarmngCodeTitle;

                        // ���ݒ莞 ��󎚃R�[�h
                        # region [���ݒ�]
                        if (IsZero(salesList[index].SALESSLIPRF_SECTIONCODERF)) row["SALESSLIPRF.SECTIONCODERF"] = DBNull.Value; // ���_�R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_SUBSECTIONCODERF)) row["SALESSLIPRF.SUBSECTIONCODERF"] = DBNull.Value; // ����R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_DEMANDADDUPSECCDRF)) row["SALESSLIPRF.DEMANDADDUPSECCDRF"] = DBNull.Value; // �����v�㋒�_�R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_INPUTAGENCDRF)) row["SALESSLIPRF.INPUTAGENCDRF"] = DBNull.Value; // ���͒S���҃R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_SALESINPUTCODERF)) row["SALESSLIPRF.SALESINPUTCODERF"] = DBNull.Value; // ������͎҃R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_FRONTEMPLOYEECDRF)) row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = DBNull.Value; // ��t�]�ƈ��R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_SALESEMPLOYEECDRF)) row["SALESSLIPRF.SALESEMPLOYEECDRF"] = DBNull.Value; // �̔��]�ƈ��R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_CLAIMCODERF)) row["SALESSLIPRF.CLAIMCODERF"] = DBNull.Value; // ������R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_CUSTOMERCODERF)) row["SALESSLIPRF.CUSTOMERCODERF"] = DBNull.Value; // ���Ӑ�R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_ADDRESSEECODERF)) row["SALESSLIPRF.ADDRESSEECODERF"] = DBNull.Value; // �[�i��R�[�h
                        if (IsZero(salesList[index].SALESSLIPRF_RETGOODSREASONDIVRF)) row["SALESSLIPRF.RETGOODSREASONDIVRF"] = DBNull.Value; // �ԕi���R�R�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_GOODSMAKERCDRF)) row["SALESDETAILRF.GOODSMAKERCDRF"] = DBNull.Value; // ���i���[�J�[�R�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_GOODSLGROUPRF)) row["SALESDETAILRF.GOODSLGROUPRF"] = DBNull.Value; // ���i�啪�ރR�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_GOODSMGROUPRF)) row["SALESDETAILRF.GOODSMGROUPRF"] = DBNull.Value; // ���i�����ރR�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_BLGROUPCODERF)) row["SALESDETAILRF.BLGROUPCODERF"] = DBNull.Value; // BL�O���[�v�R�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_BLGOODSCODERF)) row["SALESDETAILRF.BLGOODSCODERF"] = DBNull.Value; // BL���i�R�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_ENTERPRISEGANRECODERF)) row["SALESDETAILRF.ENTERPRISEGANRECODERF"] = DBNull.Value; // ���Е��ރR�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_WAREHOUSECODERF)) row["SALESDETAILRF.WAREHOUSECODERF"] = DBNull.Value; // �q�ɃR�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_PRTBLGOODSCODERF)) row["SALESDETAILRF.PRTBLGOODSCODERF"] = DBNull.Value; // BL���i�R�[�h�i����j
                        if (IsZero(salesList[index].SALESDETAILRF_SUPPLIERCDRF)) row["SALESDETAILRF.SUPPLIERCDRF"] = DBNull.Value; // �d����R�[�h
                        if (IsZero(salesList[index].SALESDETAILRF_CMPLTGOODSMAKERCDRF)) row["SALESDETAILRF.CMPLTGOODSMAKERCDRF"] = DBNull.Value; // ���[�J�[�R�[�h�i�ꎮ�j
                        if (IsZero(salesList[index].ACCEPTODRCARRF_MAKERCODERF)) row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value; // ���[�J�[�R�[�h
                        if (IsZero(salesList[index].ACCEPTODRCARRF_MODELCODERF)) row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value; // �Ԏ�R�[�h
                        if (IsZero(salesList[index].ACCEPTODRCARRF_MODELSUBCODERF)) row["ACCEPTODRCARRF.MODELSUBCODERF"] = DBNull.Value; // �Ԏ�T�u�R�[�h
                        if (IsZero(salesList[index].ACCEPTODRCARRF_MODELDESIGNATIONNORF)) row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = DBNull.Value; // �^���w��ԍ�
                        if (IsZero(salesList[index].ACCEPTODRCARRF_CATEGORYNORF)) row["ACCEPTODRCARRF.CATEGORYNORF"] = DBNull.Value; // �ޕʔԍ�
                        # endregion

                        // ���א������̍s�l��
                        # region [���א������̍s�l��]
                        // 60:���א�����
                        if (frePrtPSetWork.FreePrtPprSpPrpseCd == 60)
                        {
                            // �s�l��
                            if (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF == 2 &&
                                 salesList[index].SALESDETAILRF_SHIPMENTCNTRF == 0)
                            {
                                // �󎚍��ڃN���A
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // �艿�i�ō��C�����j
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �艿�i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // ����P���i�ō��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // ����P���i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // �����P��
                                row["SALESDETAILRF.SHIPMENTCNTRF"] = DBNull.Value; // �o�א�

                                // �E�v�N���A
                                row["DADD.DMDDTLOUTLINERF"] = DBNull.Value;
                                row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value;
                            }
                            // ���ߍs
                            else if (salesList[index].SALESDETAILRF_SALESSLIPCDDTLRF == 3)
                            {
                                // �󎚍��ڃN���A
                                row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // �艿�i�ō��C�����j
                                row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �艿�i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // ����P���i�ō��C�����j
                                row["SALESDETAILRF.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // ����P���i�Ŕ��C�����j
                                row["SALESDETAILRF.SALESUNITCOSTRF"] = DBNull.Value; // �����P��
                                row["SALESDETAILRF.SHIPMENTCNTRF"] = DBNull.Value; // �o�א�

                                // ���z�N���A 
                                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = DBNull.Value;
                                row["SALESDETAILRF.SALESMONEYTAXEXCRF"] = DBNull.Value;

                                // �E�v�N���A
                                row["DADD.DMDDTLOUTLINERF"] = DBNull.Value;
                                row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value;
                            }
                        }
                        # endregion

                        // ����������p�^�[���ݒ�
                        # region [����������p�^�[���ݒ�]
                        // �i�Ԉ󎚗L��(0:�󎚂��Ȃ�,1:�󎚂���)
                        if (dmdPrtPtnWork.PartsNoPrtCd == 0)
                        {
                            // �󎚂��Ȃ�
                            row["DADD.DMDDTLOUTLINERF"] = DBNull.Value; // ���דE�v(�i��)
                            row["SALESDETAILRF.GOODSNORF"] = DBNull.Value; // �i��
                            row["SALESDETAILRF.PRTGOODSNORF"] = DBNull.Value; // ����p�i��
                        }

                        // �W�����i�󎚗L��(0:�󎚂��Ȃ� 1:�󎚂��� 2:�|�����P)
                        if (!CheckListPricePrint(salesList[index], dmdPrtPtnWork))
                        {
                            // �󎚂��Ȃ�
                            row[ct_col_DAdd_DmdDtlOutLineRF_ListPrice] = DBNull.Value; // ���דE�v(�W�����i)
                            row["SALESDETAILRF.LISTPRICERATERF"] = DBNull.Value; // �艿��
                            row["SALESDETAILRF.LISTPRICETAXINCFLRF"] = DBNull.Value; // �艿(�ō�)
                            row["SALESDETAILRF.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �艿(�Ŕ�) 
                            row["SALESDETAILRF.BFLISTPRICERF"] = DBNull.Value; // �ύX�O�艿
                        }
                        # endregion

                        # endregion

                        table.Rows.Add(row);
                    }

                    //�Ō�̔���w�b�_�����

                    // 60:���א�����
                    if (frePrtPSetWork.FreePrtPprSpPrpseCd == 60)
                    {
                        // (�擪)�Ԏ햼(�Q�s�ڈ�)�@�����ڂ����鎞�̂ݏ������s��
                        if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL2RF"))
                        {
                            if (salesList[salesList.Count - 1].SALESSLIPRF_DETAILROWCOUNTRF == 1)
                            {
                                ReflectModelNameDetailExtra(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork);
                            }
                        }

                        if (billDmdPrintParameter.ExistsSalesFooter)
                        {
                            //�Ō�̔���t�b�^
                            ReflectSalesFooter(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                        }

                        if (billDmdPrintParameter.ExistsSalesFooter2)
                        {
                            //�Ō�̔���t�b�^�Q
                            ReflectSalesFooter2(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                        }
                        if (billDmdPrintParameter.ExistsSalesFooter3)
                        {
                            //�Ō�̔���t�b�^�R
                            ReflectSalesFooter3(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, billDmdPrintParameter, headWork);
                        }
                        if (billDmdPrintParameter.ExistsSalesTotalFooter)
                        {
                            // �Ō�̓`�[�v����̏W�v�s
                            ReflectSummalyFooters(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, SortRecordDivState.Sales, billDmdPrintParameter);
                        }
                        // --- ADD START �c������ 2022/10/18 ----->>>>>
                        // �ŗ��ʍ��v�^�C�g��
                        if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                            ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                              ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                                ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                                  ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                                    ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                                      ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                        ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                        {
                            bChgFlg = true;
                            EBooksFrePBillDetailWork salesData = salesList[salesList.Count - 1];
                            // �ŗ��ʏ��W�v
                            SalesMeisaiTaxMoneyDiffCalc(1, headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, salesData, bChgFlg,
                                               ref lTaxRate1SalesMoneyEx, ref lTaxRate1SalesPriceConsTax,
                                                 ref lTaxRate2SalesMoneyEx, ref lTaxRate2SalesPriceConsTax,
                                                   ref lOtherSalesMoneyEx, ref lOtherSalesPriceConsTax,
                                                     ref lTaxRate1MeisaiTotalTax, ref lTaxRate2MeisaiTotalTax, ref lOtherMeisaiTotalTax,
                                                       ref lSalesMoneyEx, ref lSalesMoneyExTaxOut,
                                                         ref dicCustomerCode,
                                                           dTaxRate1, dTaxRate2);
                        }
                        // --- ADD END   �c������ 2022/10/18 -----<<<<<
                    }
                    else
                    {
                        if (billDmdPrintParameter.ExistsSalesTotalFooter)
                        {
                            // �Ō�̓`�[�v����̏W�v�s
                            ReflectSummalyFooters(ref table, salesList[salesList.Count - 1], dmdPrtPtnWork, SortRecordDivState.Sales, billDmdPrintParameter);
                        }
                        // --- ADD START �c������ 2022/10/18 ----->>>>>
                        // �ŗ��ʍ��v�^�C�g��
                        if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                            ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                              ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                                ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                                  ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                                    ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                                      ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                        ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                        {
                            bChgFlg = true;
                            EBooksFrePBillDetailWork salesData = salesList[salesList.Count - 1];
                            // �ŗ��ʏ��W�v
                            SalesMeisaiTaxMoneyDiffCalc(1, headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, salesData, bChgFlg,
                                               ref lTaxRate1SalesMoneyEx, ref lTaxRate1SalesPriceConsTax,
                                                 ref lTaxRate2SalesMoneyEx, ref lTaxRate2SalesPriceConsTax,
                                                   ref lOtherSalesMoneyEx, ref lOtherSalesPriceConsTax,
                                                     ref lTaxRate1MeisaiTotalTax, ref lTaxRate2MeisaiTotalTax, ref lOtherMeisaiTotalTax,
                                                       ref lSalesMoneyEx, ref lSalesMoneyExTaxOut,
                                                         ref dicCustomerCode,
                                                           dTaxRate1, dTaxRate2);
                        }
                        // --- ADD END   �c������ 2022/10/18 -----<<<<<
                    }
                    # endregion
                }

                //--------------------------------------------------------
                // �������׃R�s�[
                //--------------------------------------------------------
                if (depositList != null && depositList.Count > 0)
                {
                    # region [��������]
                    switch (dmdPrtPtnWork.DepoDtlPrcPrtDiv)
                    {
                        case 1:
                            {
                                // �󎚂���i���v�j
                                for (int index = 0; index < depositList.Count; index++)
                                {
                                    if (index > 0 && depositList[index - 1].DEPSITMAINRF_DEPOSITSLIPNORF == depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF)
                                    {
                                        // �P�O�Ɠ���̓����`�[�Ȃ�ΉI��
                                        continue;
                                    }

                                    DataRow row = table.NewRow();

                                    # region [��������(���v)]
                                    row["DEPSITMAINRF.ACPTANODRSTATUSRF"] = depositList[index].DEPSITMAINRF_ACPTANODRSTATUSRF;
                                    row["DEPSITMAINRF.DEPOSITSLIPNORF"] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row["DEPSITMAINRF.SALESSLIPNUMRF"] = depositList[index].DEPSITMAINRF_SALESSLIPNUMRF;
                                    row["DEPSITMAINRF.ADDUPSECCODERF"] = depositList[index].DEPSITMAINRF_ADDUPSECCODERF;
                                    row["DEPSITMAINRF.SUBSECTIONCODERF"] = depositList[index].DEPSITMAINRF_SUBSECTIONCODERF;
                                    row["DEPSITMAINRF.DEPOSITDATERF"] = depositList[index].DEPSITMAINRF_DEPOSITDATERF;
                                    row["DEPSITMAINRF.ADDUPADATERF"] = depositList[index].DEPSITMAINRF_ADDUPADATERF;
                                    row["DEPSITMAINRF.DEPOSITRF"] = GetDepositTotal(depositList[index]);//depositList[index].DEPSITMAINRF_DEPOSITRF;
                                    row["DEPSITMAINRF.FEEDEPOSITRF"] = depositList[index].DEPSITMAINRF_FEEDEPOSITRF;
                                    row["DEPSITMAINRF.DISCOUNTDEPOSITRF"] = depositList[index].DEPSITMAINRF_DISCOUNTDEPOSITRF;
                                    row["DEPSITMAINRF.AUTODEPOSITCDRF"] = depositList[index].DEPSITMAINRF_AUTODEPOSITCDRF;
                                    row["DEPSITMAINRF.DEPOSITCDRF"] = depositList[index].DEPSITMAINRF_DEPOSITCDRF;
                                    row["DEPSITMAINRF.DRAFTDRAWINGDATERF"] = depositList[index].DEPSITMAINRF_DRAFTDRAWINGDATERF;
                                    row["DEPSITMAINRF.DRAFTKINDRF"] = depositList[index].DEPSITMAINRF_DRAFTKINDRF;
                                    row["DEPSITMAINRF.DRAFTKINDNAMERF"] = depositList[index].DEPSITMAINRF_DRAFTKINDNAMERF;
                                    row["DEPSITMAINRF.DRAFTDIVIDENAMERF"] = depositList[index].DEPSITMAINRF_DRAFTDIVIDENAMERF;
                                    row["DEPSITMAINRF.DRAFTNORF"] = depositList[index].DEPSITMAINRF_DRAFTNORF;
                                    row["DEPSITMAINRF.CUSTOMERCODERF"] = depositList[index].DEPSITMAINRF_CUSTOMERCODERF;
                                    row["DEPSITMAINRF.CLAIMCODERF"] = depositList[index].DEPSITMAINRF_CLAIMCODERF;
                                    row["DEPSITMAINRF.OUTLINERF"] = depositList[index].DEPSITMAINRF_OUTLINERF;
                                    row["SUBDEP.SUBSECTIONNAMERF"] = depositList[index].SUBDEP_SUBSECTIONNAMERF;
                                    row["DEPSITDTLRF.DEPOSITSLIPNORF"] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row["DEPSITDTLRF.DEPOSITROWNORF"] = DBNull.Value;
                                    row["DEPSITDTLRF.MONEYKINDCODERF"] = DBNull.Value;
                                    row["DEPSITDTLRF.MONEYKINDNAMERF"] = "����";
                                    row["DEPSITDTLRF.MONEYKINDDIVRF"] = DBNull.Value;
                                    row["DEPSITDTLRF.DEPOSITRF"] = row["DEPSITMAINRF.DEPOSITRF"];
                                    row["DEPSITDTLRF.VALIDITYTERMRF"] = DBNull.Value;
                                    row[ct_col_DDep_MoneyKindNameSp] = "���@��";
                                    # endregion

                                    # region [��������(���v)(�����ȊO)]
                                    // ���t�W�J
                                    # region [���t�W�J]
                                    // (�ʏ�)
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false); // yyyymmdd
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITMAINRF_DRAFTDRAWINGDATERF, "DADD.DRAFTDRAWINGDATE", false); // yyyymmdd
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITDTLRF_VALIDITYTERMRF, "DADD.VALIDITYTERM", false); // yyyymmdd
                                    # endregion

                                    // �\�[�g�E���v�Ή�
                                    # region [�\�[�g�E���v�Ή�]
                                    row[ct_col_Sort_CustomerCode] = depositList[index].DEPSITMAINRF_CUSTOMERCODERF;
                                    row[ct_col_Sort_Date] = depositList[index].DEPSITMAINRF_DEPOSITDATERF;
                                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                                    row[ct_col_Sort_DepositSlipNo] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                                    row[ct_col_Sort_DetailRowNo] = GetDepositRowNoForSort( depositList[index] );
                                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                                    # endregion

                                    // �`�[���v�������p ���׃^�C�g��
                                    # region [�`�[���v�������p ���׃^�C�g��]
                                    row["DDEP.DETAILTITLERF"] = "��  ��";
                                    # endregion

                                    // ���ݒ莞 ��󎚃R�[�h
                                    # region [���ݒ�]
                                    if (IsZero(depositList[index].DEPSITMAINRF_ADDUPSECCODERF)) row["DEPSITMAINRF.ADDUPSECCODERF"] = DBNull.Value; // �v�㋒�_�R�[�h
                                    if (IsZero(depositList[index].DEPSITMAINRF_SUBSECTIONCODERF)) row["DEPSITMAINRF.SUBSECTIONCODERF"] = DBNull.Value; // ����R�[�h
                                    if (IsZero(depositList[index].DEPSITMAINRF_CUSTOMERCODERF)) row["DEPSITMAINRF.CUSTOMERCODERF"] = DBNull.Value; // ���Ӑ�R�[�h
                                    if (IsZero(depositList[index].DEPSITMAINRF_CLAIMCODERF)) row["DEPSITMAINRF.CLAIMCODERF"] = DBNull.Value; // ������R�[�h
                                    # endregion
                                    # endregion

                                    table.Rows.Add(row);
                                }
                            }
                            break;
                        case 2:
                            {
                                // �󎚂���i���ׁj
                                for (int index = 0; index < depositList.Count; index++)
                                {
                                    # region [�������׏W�v�s]
                                    if (index > 0 && depositList[index - 1].DEPSITMAINRF_DEPOSITSLIPNORF != depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF)
                                    {
                                        ReflectDepositDetailExtra(ref table, depositList[index - 1], allDefSet);
                                        if (billDmdPrintParameter.ExistsDepositTotalFooter)
                                        {
                                            ReflectDepositSummalyFooters(ref table, depositList[index - 1], dmdPrtPtnWork, SortRecordDivState.Deposit, billDmdPrintParameter, allDefSet);
                                        }
                                    }
                                    # endregion

                                    if (depositList[index].DEPSITDTLRF_DEPOSITRF == 0 && depositList[index].DEPSITMAINRF_FEEDEPOSITRF != 0 ||
                                         depositList[index].DEPSITMAINRF_DEPOSITRF == 0 && depositList[index].DEPSITMAINRF_DISCOUNTDEPOSITRF != 0)
                                    {
                                        // �󎚂���(����)�̏ꍇ�͖��גP�ʂŋ��z�[������    
                                        continue;
                                    }
                                    DataRow row = table.NewRow();

                                    # region [��������(����)]
                                    row["DEPSITMAINRF.ACPTANODRSTATUSRF"] = depositList[index].DEPSITMAINRF_ACPTANODRSTATUSRF;
                                    row["DEPSITMAINRF.DEPOSITSLIPNORF"] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row["DEPSITMAINRF.SALESSLIPNUMRF"] = depositList[index].DEPSITMAINRF_SALESSLIPNUMRF;
                                    row["DEPSITMAINRF.ADDUPSECCODERF"] = depositList[index].DEPSITMAINRF_ADDUPSECCODERF;
                                    row["DEPSITMAINRF.SUBSECTIONCODERF"] = depositList[index].DEPSITMAINRF_SUBSECTIONCODERF;
                                    row["DEPSITMAINRF.DEPOSITDATERF"] = depositList[index].DEPSITMAINRF_DEPOSITDATERF;
                                    row["DEPSITMAINRF.ADDUPADATERF"] = depositList[index].DEPSITMAINRF_ADDUPADATERF;
                                    row["DEPSITMAINRF.DEPOSITRF"] = GetDepositTotal(depositList[index]);//depositList[index].DEPSITMAINRF_DEPOSITRF;
                                    row["DEPSITMAINRF.FEEDEPOSITRF"] = depositList[index].DEPSITMAINRF_FEEDEPOSITRF;
                                    row["DEPSITMAINRF.DISCOUNTDEPOSITRF"] = depositList[index].DEPSITMAINRF_DISCOUNTDEPOSITRF;
                                    row["DEPSITMAINRF.AUTODEPOSITCDRF"] = depositList[index].DEPSITMAINRF_AUTODEPOSITCDRF;
                                    row["DEPSITMAINRF.DEPOSITCDRF"] = depositList[index].DEPSITMAINRF_DEPOSITCDRF;
                                    row["DEPSITMAINRF.DRAFTDRAWINGDATERF"] = depositList[index].DEPSITMAINRF_DRAFTDRAWINGDATERF;
                                    row["DEPSITMAINRF.DRAFTKINDRF"] = depositList[index].DEPSITMAINRF_DRAFTKINDRF;
                                    row["DEPSITMAINRF.DRAFTKINDNAMERF"] = depositList[index].DEPSITMAINRF_DRAFTKINDNAMERF;
                                    row["DEPSITMAINRF.DRAFTDIVIDENAMERF"] = depositList[index].DEPSITMAINRF_DRAFTDIVIDENAMERF;
                                    row["DEPSITMAINRF.DRAFTNORF"] = depositList[index].DEPSITMAINRF_DRAFTNORF;
                                    row["DEPSITMAINRF.CUSTOMERCODERF"] = depositList[index].DEPSITMAINRF_CUSTOMERCODERF;
                                    row["DEPSITMAINRF.CLAIMCODERF"] = depositList[index].DEPSITMAINRF_CLAIMCODERF;
                                    row["DEPSITMAINRF.OUTLINERF"] = DBNull.Value;
                                    row["SUBDEP.SUBSECTIONNAMERF"] = depositList[index].SUBDEP_SUBSECTIONNAMERF;
                                    row["DEPSITDTLRF.DEPOSITSLIPNORF"] = depositList[index].DEPSITDTLRF_DEPOSITSLIPNORF;
                                    row["DEPSITDTLRF.DEPOSITROWNORF"] = depositList[index].DEPSITDTLRF_DEPOSITROWNORF;
                                    row["DEPSITDTLRF.MONEYKINDCODERF"] = depositList[index].DEPSITDTLRF_MONEYKINDCODERF;
                                    row["DEPSITDTLRF.MONEYKINDNAMERF"] = depositList[index].DEPSITDTLRF_MONEYKINDNAMERF;
                                    row["DEPSITDTLRF.MONEYKINDDIVRF"] = depositList[index].DEPSITDTLRF_MONEYKINDDIVRF;
                                    row["DEPSITDTLRF.DEPOSITRF"] = depositList[index].DEPSITDTLRF_DEPOSITRF;
                                    row["DEPSITDTLRF.VALIDITYTERMRF"] = depositList[index].DEPSITDTLRF_VALIDITYTERMRF;
                                    row["DADD.FOOTER3PRINTRF"] = 0;
                                    # endregion
     
                                    # region [��������(����)(�����ȊO)]
                                    // ���t�W�J
                                    # region [���t�W�J]
                                    // (�ʏ�)
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false); // yyyymmdd
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITMAINRF_DRAFTDRAWINGDATERF, "DADD.DRAFTDRAWINGDATE", false); // yyyymmdd
                                    ExtractDate(ref row, allDefSet.EraNameDispCd2, depositList[index].DEPSITDTLRF_VALIDITYTERMRF, "DADD.VALIDITYTERM", false); // yyyymmdd
                                    # region [�L����������`����]
                                    row["DADD.DRAFTPAYTIMELIMITFYRF"] = row["DADD.VALIDITYTERMFYRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFSRF"] = row["DADD.VALIDITYTERMFSRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFWRF"] = row["DADD.VALIDITYTERMFWRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFMRF"] = row["DADD.VALIDITYTERMFMRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFDRF"] = row["DADD.VALIDITYTERMFDRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFGRF"] = row["DADD.VALIDITYTERMFGRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFRRF"] = row["DADD.VALIDITYTERMFRRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLSRF"] = row["DADD.VALIDITYTERMFLSRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLPRF"] = row["DADD.VALIDITYTERMFLPRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLYRF"] = row["DADD.VALIDITYTERMFLYRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLMRF"] = row["DADD.VALIDITYTERMFLMRF"];
                                    row["DADD.DRAFTPAYTIMELIMITFLDRF"] = row["DADD.VALIDITYTERMFLDRF"];
                                    # endregion

                                    // ����敪��(�󔒐��䂠��E���e�Œ�)
                                    row[ct_col_DDep_MoneyKindNameSp] = GetDepMoneyKindNameSp(depositList[index]);
                                    //�����R�[�h(���̑��Ɋ܂�)<�R������Ή�>
                                    row["DADD.MONEYKINDCODEOTHERRF"] = GetDepMoneyKindCdSp(depositList[index]);
                                    # endregion

                                    // �\�[�g�E���v�Ή�
                                    # region [�\�[�g�E���v�Ή�]
                                    row[ct_col_Sort_CustomerCode] = depositList[index].DEPSITMAINRF_CUSTOMERCODERF;
                                    row[ct_col_Sort_Date] = depositList[index].DEPSITMAINRF_DEPOSITDATERF;
                                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                                    row[ct_col_Sort_DepositSlipNo] = depositList[index].DEPSITMAINRF_DEPOSITSLIPNORF;
                                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                                    row[ct_col_Sort_DetailRowNo] = GetDepositRowNoForSort( depositList[index] );
                                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                                    # endregion

                                    // �`�[���v�������p ���׃^�C�g��
                                    # region [�`�[���v�������p ���׃^�C�g��]
                                    row["DDEP.DETAILTITLERF"] = depositList[index].DEPSITDTLRF_MONEYKINDNAMERF;
                                    # endregion

                                    // ���ݒ莞 ��󎚃R�[�h
                                    # region [���ݒ�]
                                    if (IsZero(depositList[index].DEPSITMAINRF_ADDUPSECCODERF)) row["DEPSITMAINRF.ADDUPSECCODERF"] = DBNull.Value; // �v�㋒�_�R�[�h
                                    if (IsZero(depositList[index].DEPSITMAINRF_SUBSECTIONCODERF)) row["DEPSITMAINRF.SUBSECTIONCODERF"] = DBNull.Value; // ����R�[�h
                                    if (IsZero(depositList[index].DEPSITMAINRF_CUSTOMERCODERF)) row["DEPSITMAINRF.CUSTOMERCODERF"] = DBNull.Value; // ���Ӑ�R�[�h
                                    if (IsZero(depositList[index].DEPSITMAINRF_CLAIMCODERF)) row["DEPSITMAINRF.CLAIMCODERF"] = DBNull.Value; // ������R�[�h
                                    # endregion
                                    # endregion

                                    table.Rows.Add(row);
                                }
                                // �ŏI���ׂ̏W�v�s
                                # region [�ŏI���ׂ̏W�v�s]
                                // �������ׁi�����l���E�����萔���j�ǉ�����
                                ReflectDepositDetailExtra(ref table, depositList[depositList.Count - 1], allDefSet);
                                if (billDmdPrintParameter.ExistsDepositTotalFooter)
                                {
                                    ReflectDepositSummalyFooters(ref table, depositList[depositList.Count - 1], dmdPrtPtnWork, SortRecordDivState.Deposit, billDmdPrintParameter, allDefSet);
                                }
                                # endregion
                            }
                            break;
                        case 0:
                        default:
                            {
                                // �󎚂��Ȃ�
                            }
                            break;
                    }
                    # endregion
                }

                //--------------------------------------------------------
                // ���ёւ�
                //--------------------------------------------------------
                # region [SortOrder]
                switch (dmdPrtPtnWork.DmdDtlPtnOdrDiv)
                {
                    case 0:
                        {
                            // 0:�v���+�`�[�ԍ�
                            table.DefaultView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                           ct_col_Sort_Date,
                                                           ct_col_Sort_RecordDiv,
                                                           ct_col_Sort_SalesSlipNo,
                                                           ct_col_Sort_DepositSlipNo,
                                                           ct_col_Sort_DetailDiv,
                                                           ct_col_Sort_DetailRowNo);
                        }
                        break;
                    case 1:
                        {
                            // 1:���Ӑ�+�v���+�`�[�ԍ�
                            table.DefaultView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                                                          ct_col_Sort_CustomerCode,
                                                          ct_col_Sort_Date,
                                                          ct_col_Sort_RecordDiv,
                                                          ct_col_Sort_SalesSlipNo,
                                                          ct_col_Sort_DepositSlipNo,
                                                          ct_col_Sort_DetailDiv,
                                                          ct_col_Sort_DetailRowNo);
                        }
                        break;
                    case 2:
                        {
                            // 2:����/����+�v���+�`�[�ԍ�
                            table.DefaultView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                                          ct_col_Sort_RecordDiv_EmptyDetail,
                                                          ct_col_Sort_Date,
                                                          ct_col_Sort_SalesSlipNo,
                                                          ct_col_Sort_DepositSlipNo,
                                                          ct_col_Sort_DetailDiv,
                                                          ct_col_Sort_DetailRowNo
                                                         );
                        }
                        break;
                    case 3:
                        {
                            // 3:����/����+���Ӑ�+�v���+�`�[�ԍ�
                            table.DefaultView.Sort = string.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}",
                                                          ct_col_Sort_RecordDiv_EmptyDetail,
                                                          ct_col_Sort_CustomerCode,
                                                          ct_col_Sort_Date,
                                                          ct_col_Sort_SalesSlipNo,
                                                          ct_col_Sort_DepositSlipNo,
                                                          ct_col_Sort_DetailDiv,
                                                          ct_col_Sort_DetailRowNo);
                        }
                        break;
                }
                # endregion


                ////--------------------------------------------------------
                //// ��s����
                ////--------------------------------------------------------
                // ���C�A�E�g�s��
                int feedCount = frePrtPSetWork.FormFeedLineCount;
                if (feedCount == 0) feedCount = 1;

                //--------------------------------------------------------
                // �T�v���X����
                //--------------------------------------------------------
                // �w�b�_���R�s�[����s
                List<int> headCopyRowIndexList = new List<int>();
                // �ŏ��ƍŌ�͊m���ɃZ�b�g�K�v
                headCopyRowIndexList.Add(0);

                List<DataRow> addRowList = new List<DataRow>();
                List<DataRow> delRowList = new List<DataRow>();
                int head2RowCount = 0;
                int page = 1;
                int head2RowDelCount = 0;
                int pageCount = 1;
                int prevPageCount = 0;

                // ���R�[�h�敪�ԋ󔒍s�ǉ��������Ă��鎞�����������s��
                if (ReportItemDic.ContainsKey("DADD.RECORDDIVSPACERF"))
                {
                    // �f�[�^�̃\�[�g
                    DataTable table2 = table.Clone();
                    DataView dv = new DataView(table);
                    dv.Sort = table.DefaultView.Sort;
                    foreach (DataRowView drv in dv)
                    {
                        table2.ImportRow(drv.Row);
                    }

                    // �\�[�g��̃e�[�u���ɏ�����
                    table.Clear();
                    table = table2.Copy();

                    // �󔒍s��}������Index�̎擾
                    List<int> insIndexList = new List<int>();
                    SortRecordDivState prevSortRecordDivState = SortRecordDivState.Sales;
                    foreach (DataRow dr in table.Rows)
                    {
                        int index = table.Rows.IndexOf(dr);
                        if (index != 0)
                        {
                            if ((SortRecordDivState)dr[ct_col_Sort_RecordDiv] != prevSortRecordDivState)
                            {
                                insIndexList.Add(index + insIndexList.Count);
                                prevSortRecordDivState = (SortRecordDivState)dr[ct_col_Sort_RecordDiv];
                            }
                        }
                        else
                        {
                            prevSortRecordDivState = (SortRecordDivState)table.DefaultView[index].Row[ct_col_Sort_RecordDiv];
                        }
                    }

                    // �󔒍s�̑}��
                    foreach (int insIndex in insIndexList)
                    {
                        DataRow row = table.NewRow();
                        # region [�\�[�g�E���v�Ή�]
                        row[ct_col_Sort_CustomerCode] = table.Rows[insIndex][ct_col_Sort_CustomerCode];
                        row[ct_col_Sort_Date] = table.Rows[insIndex][ct_col_Sort_Date];
                        row[ct_col_Sort_RecordDiv] = prevSortRecordDivState;
                        row[ct_col_Sort_SalesSlipNo] = table.Rows[insIndex][ct_col_Sort_SalesSlipNo];
                        row[ct_col_Sort_DepositSlipNo] = 0;
                        row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                        row[ct_col_Sort_DetailRowNo] = 0;
                        row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                        row["DADD.FOOTER3PRINTRF"] = 97;

                        table.Rows.InsertAt(row, insIndex);
                        # endregion
                    }

                    // �Ő��Ď擾
                    // �w�b�_���R�s�[����s
                    headCopyRowIndexList = new List<int>();
                    // �ŏ��ƍŌ�͊m���ɃZ�b�g�K�v
                    headCopyRowIndexList.Add(0);
                    for (int index = 0; index < table.DefaultView.Count; index++)
                    {
                        DataRow row = table.DefaultView[index].Row;

                        int indexCount = index + head2RowCount - head2RowDelCount;
                        if (indexCount + 1 <= feedCount)
                        {
                            pageCount = 1;
                        }
                        else
                        {
                            pageCount = (int)((indexCount - feedCount) / (feedCount + billDmdPrintParameter.OtherFeedAddCount)) + 2;
                        }
                        if (pageCount != prevPageCount && indexCount > 0)
                        {
                            headCopyRowIndexList.Add(indexCount - 1);
                            headCopyRowIndexList.Add(indexCount);
                        }
                        row[ct_col_PageCount] = pageCount;
                        prevPageCount = pageCount;
                    }
                }
                if (ReportItemDic.ContainsKey("DADD.SALESMONEYALLDETAILTTLRF"))
                {
                    DataRow row = table.NewRow();
                    Int64 allDetailTtl = 0;
                    foreach (DataRow dr in table.Rows)
                    {
                        if ((SortDetailDivState)dr[ct_col_Sort_DetailDiv] == SortDetailDivState.Detail)
                        {
                            if (dr["SALESDETAILRF.SALESMONEYTAXEXCRF"] != DBNull.Value)
                            {
                                allDetailTtl = allDetailTtl + Convert.ToInt64(dr["SALESDETAILRF.SALESMONEYTAXEXCRF"]); // ������z�i�Ŕ����j
                            }
                        }
                    }
                    row["DADD.SALESMONEYALLDETAILTTLRF"] = allDetailTtl;
                    row["DADD.SALESFTTITLERF"] = "���׍��v";
                    # region [�\�[�g�E���v�Ή�]
                    row[ct_col_Sort_CustomerCode] = 999999999;
                    row[ct_col_Sort_Date] = 99999999;
                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                    row[ct_col_Sort_DepositSlipNo] = 0;
                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                    row[ct_col_Sort_DetailRowNo] = 0;
                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                    row[ct_col_PageCount] = pageCount;
                    # endregion
                    table.Rows.Add(row);
                }

                # region [�T�v���X]
                GroupSuppressKey keyOfDate;
                GroupSuppressKey keyOfSlipNo;
                GroupSuppressKey keyOfCar;
                GroupSuppressKey prevKeyOfDate = GroupSuppressKey.Create();
                GroupSuppressKey prevKeyOfSlipNo = GroupSuppressKey.Create();
                GroupSuppressKey prevKeyOfCar = GroupSuppressKey.Create();

                GroupSuppressKey keyOfDate2;
                GroupSuppressKey keyOfSlipNo2;
                GroupSuppressKey prevKeyOfDate2 = GroupSuppressKey.Create(); ;
                GroupSuppressKey prevKeyOfSlipNo2 = GroupSuppressKey.Create(); ;

                string note2temp = string.Empty;

                for (int index = 0; index < table.DefaultView.Count; index++)
                {
                    DataRow row = table.DefaultView[index].Row;

                    int indexCount = index + head2RowCount - head2RowDelCount;
                    if (indexCount + 1 <= feedCount)
                    {
                        pageCount = 1;
                    }
                    else
                    {
                        pageCount = (int)((indexCount - feedCount) / (feedCount + billDmdPrintParameter.OtherFeedAddCount)) + 2;
                    }
                    if ( pageCount != prevPageCount && indexCount > 0 )
                    {
                        headCopyRowIndexList.Add(indexCount - 1);
                        headCopyRowIndexList.Add(indexCount);
                    }
                    row[ct_col_PageCount] = pageCount;
                    prevPageCount = pageCount;
                    // �ŏI�y�[�W���擾
                    _pageCount = pageCount;


                    #region[�R������Ή�]
                    if (billDmdPrintParameter.ExistsSalesHeader2)
                    {
                        DataRow header2Row = table.NewRow();

                        //���̃y�[�W���Ɣ�r
                        if (page != 0 && page != pageCount)
                        {
                            //�y�[�W�̂P�s�ڂ��w�b�_�s or �����s 
                            if ((SortDetailDivState)row[ct_col_Sort_DetailDiv] != SortDetailDivState.Header && (SortRecordDivState)row[ct_col_Sort_RecordDiv] != SortRecordDivState.Deposit)
                            {
                                if ((SortDetailDivState)row[ct_col_Sort_DetailDiv] == SortDetailDivState.Detail)
                                {
                                    int rowCount;

                                   //���ׂ̓r���Œǉ������w�b�_
                                   if ((int)row["DADD.FOOTER3PRINTRF"] == 0)
                                   {
                                   }
                                   //���׍s
                                   else if((int)row["DADD.FOOTER3PRINTRF"] == 1)
                                   {
                                       rowCount = (int)row[ct_col_Sort_DetailRowNo] - 5;
                                       ReflectSalesHeader2NewPage(ref header2Row, row, allDefSet, pageCount, rowCount);
                                       //�w�b�_�s��ǉ�������{1
                                       head2RowCount += 1;
                                       addRowList.Add(header2Row);
                                   }
                                    //�`�[���l�s�̏ꍇ
                                    else if ((int)row["DADD.FOOTER3PRINTRF"] == 96)
                                    {
                                        DataRow prevRow = table.DefaultView[index - 1].Row;
                                        rowCount = (int)prevRow[ct_col_Sort_DetailRowNo] + 5;

                                        //ReflectSalesHeader2NewPage(ref header2Row, prevRow, allDefSet, pageCount, detailRowNo);
                                        ReflectSalesHeader2NewPage(ref header2Row, prevRow, allDefSet, pageCount, rowCount);
                                        //�w�b�_�s��ǉ�������{1
                                        head2RowCount += 1;
                                        addRowList.Add(header2Row);
                                    }
                                    //�`�[�v�s�̏ꍇ
                                    else if ((int)row["DADD.FOOTER3PRINTRF"] == 97)
                                    {
                                        DataRow prevRowofSlip = table.DefaultView[index - 2].Row;
                                        rowCount = (int)prevRowofSlip[ct_col_Sort_DetailRowNo] + 15;
                                        ReflectSalesHeader2NewPage(ref header2Row, prevRowofSlip, allDefSet, pageCount, rowCount);
                                        //�w�b�_�s��ǉ�������{1
                                        head2RowCount += 1;
                                        addRowList.Add(header2Row);
                                    }
                                    //����ōs�̏ꍇ
                                    else if ((int)row["DADD.FOOTER3PRINTRF"] == 98)
                                    {
                                        DataRow prevRowofTax = table.DefaultView[index - 3].Row;
                                        rowCount = (int)prevRowofTax[ct_col_Sort_DetailRowNo] + 25;
                                        ReflectSalesHeader2NewPage(ref header2Row, prevRowofTax, allDefSet, pageCount, rowCount);
                                        //�w�b�_�s��ǉ�������{1
                                        head2RowCount += 1;
                                        addRowList.Add(header2Row);
                                    }
                                    //�󔒍s�̏ꍇ
                                    else if ((int)row["DADD.FOOTER3PRINTRF"] == 99)
                                    {
                                        DataRow prevRowofDel = table.DefaultView[index - 4].Row;
                                        rowCount = (int)prevRowofDel[ct_col_Sort_DetailRowNo] + 35;
                                        ReflectSalesHeader2NewPage(ref header2Row, prevRowofDel, allDefSet, pageCount, rowCount);
                                        delRowList.Add(row);
                                        head2RowDelCount += 1;
                                    }
                                }
                            }                            
                        }
                        //�ЂƂO�̃y�[�W�����Ƃ��Ă���
                        page = pageCount;
                    }
                    #endregion

                    //---------------------------------------
                    // ����L�[�擾
                    //---------------------------------------
                    // ���t
                    keyOfDate = GroupSuppressKey.CreateKeyOfDate(row);
                    // �`�[�ԍ�
                    keyOfSlipNo = GroupSuppressKey.CreateKeyOfSlipNo(row);
                    // �^���E�Ԏ햼�E�N��
                    keyOfCar = GroupSuppressKey.CreateKeyOfCar(row);
                    // ���t�Q
                    keyOfDate2 = GroupSuppressKey.CreateKeyOfDate2(row);
                    // �`�[�ԍ��Q
                    keyOfSlipNo2 = GroupSuppressKey.CreateKeyOfSlipNo2(row);

                    //---------------------------------------
                    // �T�v���X����E�T�v���X����
                    //---------------------------------------
                    if (prevKeyOfDate.CompareTo(keyOfDate) == 0) SuppressOfDate(ref row);
                    if (prevKeyOfSlipNo.CompareTo(keyOfSlipNo) == 0) SuppressOfSlipNo(ref row);
                    if (prevKeyOfCar.CompareTo(keyOfCar) == 0) SuppressOfCar(ref row);
                    if (ReportItemDic.ContainsKey("DADD.CARMNGNO2RF"))
                    {
                        // �i�擪�j���q�Ǘ��ԍ��i���ׂQ�s�ڈ󎚁j�����݂���ꍇ�͓��t�Ɠ`�[�ԍ��ɂ����ăy�[�W�����L�[����O��
                        if (prevKeyOfDate2.CompareTo(keyOfDate2) == 0) SuppressOfDate(ref row);
                        if (prevKeyOfSlipNo2.CompareTo(keyOfSlipNo2) == 0) SuppressOfSlipNo(ref row);
                    }
                    // ���v�s�ɓ��t�E�`�[�ԍ����󎚂��Ȃ�
                    if ((SortDetailDivState)row[ct_col_Sort_DetailDiv] == SortDetailDivState.Footer)
                    {
                        // ����
                        row["SALESSLIPRF.SALESSLIPNUMRF"] = DBNull.Value;
                        row["SALESSLIPRF.SALESDATERF"] = DBNull.Value;
                        row["SALESSLIPRF.PARTYSALESLIPNUMRF"] = DBNull.Value;
                        // ����
                        row["DEPSITMAINRF.DEPOSITDATERF"] = DBNull.Value;
                        ExtractDate(ref row, allDefSet.EraNameDispCd2, DateTime.MinValue, "DADD.DEPOSITDATE", false); // yyyymmdd
                        row["DEPSITMAINRF.DEPOSITSLIPNORF"] = DBNull.Value;
                    }

                    //---------------------------------------
                    // �O����ޔ�
                    //---------------------------------------
                    prevKeyOfDate = keyOfDate;
                    prevKeyOfSlipNo = keyOfSlipNo;
                    prevKeyOfCar = keyOfCar;
                    prevKeyOfDate2 = keyOfDate2;
                    prevKeyOfSlipNo2 = keyOfSlipNo2;
                }

                //����Ă������s��ǉ�table�ɏ��Ԃɒǉ�
                #region[�R�������]
                if (billDmdPrintParameter.ExistsSalesHeader2)
                {
                    //foreach��datarow�̃��X�g��add����
                    foreach (DataRow headerRow in addRowList)
                    {
                        table.Rows.Add(headerRow);
                    }
                    //�󔒍s������ꍇ�͍폜
                    foreach (DataRow headerDelRow in delRowList)
                    {
                        table.Rows.Remove(headerDelRow);
                    }
                }

                #endregion

                # endregion
                // --- ADD START �c������ 2022/10/18 ----->>>>>
                if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                    ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                      ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                        ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                          ReportItemDic.ContainsKey("TAX.DTLTOTALCONSTAXRATETITLERF") ||
                            ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                              ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                                ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
                {
                    // ����f�[�^���݂̏ꍇ
                    if (salesList.Count != 0)
                    {
                        bool isParent = (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0);
                      
                        SalesTotalTaxMoneyDiffCalc(headWork.CSTCLM_SALESCNSTAXFRCPROCCDRF, headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF,
                                                    lTaxRate1SalesMoneyEx, lTaxRate1SalesPriceConsTax,
                                                      lTaxRate2SalesMoneyEx, lTaxRate2SalesPriceConsTax,
                                                        lSalesMoneyExTaxOut,
                                                          lOtherSalesMoneyEx, lOtherSalesPriceConsTax,
                                                            dicCustomerCode,
                                                              dTaxRate1, dTaxRate2,
                                                                out TotalTaxRateSalesMoney);
                        #region [�ŗ��ʍ��v�s��ǉ�]
                        DataRow row = table.NewRow();
                        if (ReportItemDic.ContainsKey("TAX.DTLTOTALCONSTAXRATETITLERF") ||                        // �ŗ��ʍ��v�^�C�g��[����]
                             ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF"))                         // �ŗ��ʍ��v���z[����]
                        {
                            row["TAX.DTLTOTALCONSTAXRATETITLERF"] = "*�� �v*";
                            // ���v���z=�ŗ��P���z + �ŗ��Q���z + ��ېŋ��z + ���̑����z
                            row["TAX.DTLTOTALSALESMONEYTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate1SalesMoney + TotalTaxRateSalesMoney.TaxRate2SalesMoney + TotalTaxRateSalesMoney.TaxOutSalesMoney + TotalTaxRateSalesMoney.OtherSalesMoney;
                            # region [�\�[�g�E���v�Ή�]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion

                        #region [�ŗ��ʁu�ŗ��P�v�s��ǉ�]
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXTITLERF") ||                                    // �ŗ��ʐŗ��^�C�g��[����]
                             ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||                                   // �ŗ��P[����]
                               ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF") ||                      // �ŗ��P(�Ŕ���)[����]
                                 ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXRF"))                         // �ŗ��P�����[����]
                        {
                            row = table.NewRow();
                            row["TAX.DTLTAXRATE1RF"] = Convert.ToString(dTaxRate1 * 100) + "%";
                            row["TAX.DTLTAXRATE1SALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate1SalesMoney;
                            if (isParent)
                            {
                                row["TAX.DTLTAXTITLERF"] = "��";
                                row["TAX.DTLTAXRATE1SALESTAXRF"] = TotalTaxRateSalesMoney.TaxRate1SalesPriceConsTax;
                            }
                            # region [�\�[�g�E���v�Ή�]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion

                        #region [�ŗ��ʁu�ŗ��Q�v�s��ǉ�]
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXTITLERF") ||                                    // �ŗ��ʐŗ��^�C�g��[����]
                              ReportItemDic.ContainsKey("TAX.DTLTAXRATE2RF") ||                                  // �ŗ��Q[����]
                                ReportItemDic.ContainsKey("TAX.DTLTAXRATE2SALESTAXEXCRF") ||                     // �ŗ��Q(�Ŕ���)[����]
                                  ReportItemDic.ContainsKey("TAX.DTLTAXRATE2SALESTAXRF"))                        // �ŗ��Q�����[����]
                        {
                            row = table.NewRow();
                            row["TAX.DTLTAXRATE2RF"] = Convert.ToString(dTaxRate2 * 100) + "%";
                            row["TAX.DTLTAXRATE2SALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate2SalesMoney;
                            if (isParent)
                            {
                                row["TAX.DTLTAXTITLERF"] = "��";
                                row["TAX.DTLTAXRATE2SALESTAXRF"] = TotalTaxRateSalesMoney.TaxRate2SalesPriceConsTax; ;
                            }
                            # region [�\�[�g�E���v�Ή�]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion
                        #region [�ŗ��ʁu��ېŁv�s��ǉ�]
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXOUTITLERF") ||                                     // ��ېŃ^�C�g��[����]
                              ReportItemDic.ContainsKey("TAX.DTLTAXOUTSALESTAXEXCRF"))                              // ��ېŔ�����z(�Ŕ���)
                        {
                            row = table.NewRow();
                            row["TAX.DTLTAXOUTITLERF"] = "��ې�";
                            row["TAX.DTLTAXOUTSALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxOutSalesMoney;
                            # region [�\�[�g�E���v�Ή�]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion

                        #region [�ŗ��ʁu���̑��v�s��ǉ�]
                        if (ReportItemDic.ContainsKey("TAX.DTLTAXTITLERF") ||                                     // �ŗ��ʐŗ��^�C�g��[����]
                              ReportItemDic.ContainsKey("TAX.DTLOTHERTAXRATERF") ||                               // ���̑��ŗ�[����]            
                                ReportItemDic.ContainsKey("TAX.DTLOTHERTAXRATESALESTAXEXCRF") ||                  // ���̑��ŗ�(�Ŕ���)[����]
                                  ReportItemDic.ContainsKey("TAX.DTLOTHERTAXRATESALESTAXRF"))                     // ���̑��ŗ������[����]
                        {
                            row = table.NewRow();
                            row["TAX.DTLOTHERTAXRATERF"] = "���̑�";
                            row["TAX.DTLOTHERTAXRATESALESTAXEXCRF"] = TotalTaxRateSalesMoney.OtherSalesMoney;
                            if (isParent)
                            {
                                row["TAX.DTLTAXTITLERF"] = "��";
                                row["TAX.DTLOTHERTAXRATESALESTAXRF"] = TotalTaxRateSalesMoney.OtherSalesPriceConsTax;
                            }
                            # region [�\�[�g�E���v�Ή�]
                            row[ct_col_Sort_CustomerCode] = 999999999;
                            row[ct_col_Sort_Date] = 99999999;
                            row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            row[ct_col_Sort_SalesSlipNo] = string.Empty;
                            row[ct_col_Sort_DepositSlipNo] = 0;
                            row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                            row[ct_col_Sort_DetailRowNo] = 0;
                            row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                            row[ct_col_PageCount] = pageCount;
                            # endregion
                            table.Rows.Add(row);
                        }
                        #endregion

                        for (int index = 0; index < table.DefaultView.Count; index++)
                        {
                            row = table.DefaultView[index].Row;
                            List<string> emptyItemList = new List<string>();
                            //int indexCount = index + head2RowCount - head2RowDelCount;// --- DEL  �c������  2023/06/16
                            int indexCount = index;// --- ADD  �c������  2023/06/16
                            if (indexCount + 1 <= feedCount)
                            {
                                pageCount = 1;
                            }
                            else
                            {
                                pageCount = (int)((indexCount - feedCount) / (feedCount + billDmdPrintParameter.OtherFeedAddCount)) + 2;
                            }
                            if (pageCount != prevPageCount && indexCount > 0)
                            {
                                headCopyRowIndexList.Add(indexCount - 1);
                                headCopyRowIndexList.Add(indexCount);
                            }
                            row[ct_col_PageCount] = pageCount;
                            prevPageCount = pageCount;
                            // �ŏI�y�[�W���擾
                            _pageCount = pageCount;

                        }

                    }
                }
                // --- ADD END   �c������ 2022/10/18 -----<<<<<

                //--------------------------------------------------------
                // ��s����
                //--------------------------------------------------------
                // �S�ő��s��
                int billMaxCount = GetAllDetailCount(table.Rows.Count, feedCount, billDmdPrintParameter.OtherFeedAddCount);
                if (billMaxCount <= 0)
                {
                    billMaxCount = feedCount;
                }
                for (int index = table.Rows.Count; index < billMaxCount; index++)
                {
                    DataRow row = table.NewRow();
                    # region [�\�[�g�E���v�Ή�]
                    row[ct_col_Sort_CustomerCode] = 999999999;
                    row[ct_col_Sort_Date] = 99999999;
                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                    row[ct_col_Sort_DepositSlipNo] = 0;
                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                    row[ct_col_Sort_DetailRowNo] = 0;
                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.EmptyDetail;
                    row[ct_col_PageCount] = pageCount;
                    # endregion
                    table.Rows.Add(row);
                }

                //�Ō�̍s��ǉ�
                headCopyRowIndexList.Add(table.DefaultView.Count - 1);

                Int64 pageTtl = 0;
                Dictionary<int, Int64> pageTtlList = new Dictionary<int, Int64>();
                // ������z�Ōv�������Ă��鎞�����������s��
                if (ReportItemDic.ContainsKey("HADD.SALESMONEYPAGETTLRF"))
                {
                    for (int index = 1; index <= _pageCount; index++)
                    {
                        DataRow[] drs = table.Select(ct_col_PageCount + "=" + index.ToString());
                        pageTtl = 0;
                        foreach (DataRow dr in drs)
                        {
                            if ((SortDetailDivState)dr[ct_col_Sort_DetailDiv] == SortDetailDivState.Detail)
                            {
                                if (dr["SALESDETAILRF.SALESMONEYTAXEXCRF"] != DBNull.Value)
                                {
                                    pageTtl = pageTtl + Convert.ToInt64(dr["SALESDETAILRF.SALESMONEYTAXEXCRF"]); // ������z�i�Ŕ����j
                                }
                            }
                        }
                        pageTtlList.Add(index, pageTtl);
                    }
                }

                //--------------------------------------------------------
                // ���y�[�W�O��ɐ������w�b�_�����Z�b�g
                //--------------------------------------------------------
                // �Ώ�Row���X�g���̑S�Ă̍s�ɑ΂��ăw�b�_����K�p����
                foreach (int headCopyIndex in headCopyRowIndexList)
                {
                    DataRow row;
                    if ( headCopyIndex <= table.DefaultView.Count - 1 )
                    {
                        row = table.DefaultView[headCopyIndex].Row;
                    }
                    else
                    {
                        row = table.DefaultView[table.DefaultView.Count - 1].Row;
                    }

                    printPrice = (headCopyIndex == 0 || headCopyIndex == feedCount - 1);
                    //ReflectBillHeader(ref row, headWork, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, allDefSet, printPrice, billDmdPrintParameter.TaxTitle, billDmdPrintParameter.OfsThisSalesTaxIncTtl, pageTtlList); // DEL    �c������ 2022/10/18
                    ReflectBillHeader(ref row, headWork, dmdPrtPtnWork, frePrtPSetWork, billAllStWork, billPrtStWork, allDefSet, printPrice, billDmdPrintParameter.TaxTitle, billDmdPrintParameter.OfsThisSalesTaxIncTtl, pageTtlList, TotalTaxRateSalesMoney,dTaxRate1,dTaxRate2); // ADD    �c������ 2022/10/18
                }
            }

        /// <summary>
        /// ���ʃ^�C�g���Z�b�g�����i���ʂQ���ڂ̎��R�[������j
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note        : ���ʃ^�C�g���Z�b�g�����i���ʂQ���ڂ̎��R�[������j</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static void SetCopyTitle( ref DataTable table )
        {
            if ( table != null && table.Rows.Count > 0 )
            {
                string dmdFormTitle2;
                try
                {
                    // �^�C�g��2��ޔ�
                    dmdFormTitle2 = (string)table.Rows[0]["HADD.DMDFORMTITLE2RF"];
                }
                catch
                {
                    dmdFormTitle2 = string.Empty;
                }

                // �^�C�g��2���Z�b�g����Ă���ꍇ�̂ݍ����ւ���
                if ( !string.IsNullOrEmpty( dmdFormTitle2 ) )
                {
                    foreach ( DataRow row in table.Rows )
                    {
                        // �������^�C�g��(1) �� �������^�C�g���Q���Z�b�g
                        row["HADD.DMDFORMTITLERF"] = dmdFormTitle2;
                    }
                }
            }
        }

        /// <summary>
        /// �\�[�g�p�s�ԍ��擾����
        /// </summary>
        /// <param name="deposit">�����f�[�^</param>
        /// <returns>���׍s�ԍ�</returns>
        /// <remarks>
        /// <br>Note        : �\�[�g�p�s�ԍ��擾����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetDepositRowNoForSort( EBooksFrePBillDetailWork deposit )
        {
            if ( ReportItemDic != null && ReportItemDic.ContainsKey( "DADD.MONEYKINDCODEOTHERRF" ) )
            {
                // �u����R�[�h(���̑��Ɋ܂�)�v�����݂���ꍇ�́A���̃R�[�h�l��Ԃ�
                try
                {
                    return Int32.Parse( GetDepMoneyKindCdSp( deposit ) );
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                // �ʏ�͖��׍s�ԍ���Ԃ�
                return deposit.DEPSITDTLRF_DEPOSITROWNORF;
            }
        }
        /// <summary>
        /// �\�[�g�p�s�ԍ��擾����
        /// </summary>
        /// <param name="detailRowNo">�s�ԍ�</param>
        /// <param name="moneyKindCodeOtherIndex">����R�[�h</param>
        /// <returns>���׍s�ԍ�</returns>
        /// <remarks>
        /// <br>Note        : �\�[�g�p�s�ԍ��擾����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetDepositRowNoForSort( int detailRowNo, int moneyKindCodeOtherIndex )
        {
            if ( ReportItemDic != null && ReportItemDic.ContainsKey( "DADD.MONEYKINDCODEOTHERRF" ) )
            {
                // �u����R�[�h(���̑��Ɋ܂�)�v�����݂���ꍇ�́A���̃R�[�h�l��Ԃ�
                return moneyKindCodeOtherIndex;
            }
            else
            {
                // �ʏ�͖��׍s�ԍ���Ԃ�
                return detailRowNo;
            }
        }

        /// <summary>
        /// ���z��ʖ��̎擾(�󔒐��䂠��E���e�Œ�EPM7������ްĂ����ꍇ�ȂǂɎg�p)
        /// </summary>
        /// <param name="frePBillDetailWork">���R���[������</param>
        /// <returns>���z��ʖ���</returns>
        /// <remarks>
        /// <br>Note        : ���z��ʖ��̎擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetDepMoneyKindNameSp( EBooksFrePBillDetailWork frePBillDetailWork )
        {
            switch ( frePBillDetailWork.DEPSITDTLRF_MONEYKINDCODERF )
            {
                case 51: return "���@��";
                case 52: return "�U�@��";
                case 53: return "���؎�";
                case 54: return "��@�`";
                case 55: return "�萔��";
                case 56: return "���@�E";
                case 57: return "�l�@��";
                case 58: return "���̑�";
                case 59: return "�����U��";
                case 60: return "̧���ݸ�";
                default: return frePBillDetailWork.DEPSITDTLRF_MONEYKINDNAMERF;
            }
        }

        /// <summary>
        /// ���z��ʃR�[�h�擾(�R������Ή�)
        /// </summary>
        /// <param name="frepBillDetailWork">���R���[������</param>
        /// <returns>���z��ʃR�[�h</returns>
        /// <remarks>
        /// <br>Note        : ���z��ʃR�[�h�擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetDepMoneyKindCdSp(EBooksFrePBillDetailWork frepBillDetailWork)
        {
            switch (frepBillDetailWork.DEPSITDTLRF_MONEYKINDCODERF)
            {
                case 51: return "01"; //����
                case 52: return "06"; //�U�荞��
                case 53: return "02"; //���؎�
                case 54: return "03"; //��`
                case 55: return "07"; //���̑�(�萔��)
                case 56: return "04"; //���E
                case 57: return "05"; //�l����
                case 58: return "07"; //���̑�
                case 59: return "07"; //���̑�(�����U��)
                case 60: return "07"; //���̑�(�t�@�N�^�����O) 
                default: return "07";
            }
        }

        /// <summary>
        /// �艿�󎚃`�F�b�N�����i���ז��ɔ���j
        /// </summary>
        /// <param name="detail">���׃f�[�^</param>
        /// <param name="dmdPrtPtnWork">����������p�^�[���ݒ�</param>
        /// <returns>true:�󎚂���/false:�󎚂��Ȃ�</returns>
        /// <remarks>
        /// <br>Note        : �艿�󎚃`�F�b�N����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool CheckListPricePrint( EBooksFrePBillDetailWork detail, DmdPrtPtnWork dmdPrtPtnWork )
        {
            bool result = false;

            switch ( dmdPrtPtnWork.ListPricePrtCd )
            {
                // 0:�󎚂��Ȃ�
                case 0:
                    {
                        result = false;
                    }
                    break;
                // 1:�󎚂���
                default:
                case 1:
                    {
                        result = true;
                    }
                    break;
                // 2:�|�����P
                case 2:
                    {
                        // �W�����i(�Ŕ�)������P��(�Ŕ�)�@���@true
                        // �W�����i(�Ŕ�)������P��(�Ŕ�)�@���@false
                        result = (detail.SALESDETAILRF_LISTPRICETAXEXCFLRF > detail.SALESDETAILRF_SALESUNPRCTAXEXCFLRF);
                    }
                    break;
            }
            return result;
        }
        /// <summary>
        /// �������ׁi�����萔���E�����l���j�ǉ�����
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <param name="frePBillDetailWork">���R���[������</param>
        /// <param name="allDefSet">�S�̏����\���ݒ�</param>
        /// <remarks>
        /// <br>Note        : �����萔���Ɠ����l���͖��ׂɃf�[�^�������Ȃ��ׁA�����}�X�^(�w�b�_)��񂩂疾�ׂ𐶐�����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectDepositDetailExtra( ref DataTable table, EBooksFrePBillDetailWork frePBillDetailWork, AllDefSetWork allDefSet )
        {
            int detailRowNo = frePBillDetailWork.DEPSITDTLRF_DEPOSITROWNORF;
            DataRow row;

            if ( frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF != 0 )
            {
                # region [�����萔��]
                row = table.NewRow();
                detailRowNo++;
                row["DEPSITMAINRF.ACPTANODRSTATUSRF"] = frePBillDetailWork.DEPSITMAINRF_ACPTANODRSTATUSRF;
                row["DEPSITMAINRF.DEPOSITSLIPNORF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row["DEPSITMAINRF.SALESSLIPNUMRF"] = frePBillDetailWork.DEPSITMAINRF_SALESSLIPNUMRF;
                row["DEPSITMAINRF.ADDUPSECCODERF"] = frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF;
                row["DEPSITMAINRF.SUBSECTIONCODERF"] = frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF;
                row["DEPSITMAINRF.DEPOSITDATERF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF;
                row["DEPSITMAINRF.ADDUPADATERF"] = frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF;
                row["DEPSITMAINRF.DEPOSITRF"] = GetDepositTotal( frePBillDetailWork );//frePBillDetailWork.DEPSITMAINRF_DEPOSITRF;
                row["DEPSITMAINRF.FEEDEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF;
                row["DEPSITMAINRF.DISCOUNTDEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
                row["DEPSITMAINRF.AUTODEPOSITCDRF"] = frePBillDetailWork.DEPSITMAINRF_AUTODEPOSITCDRF;
                row["DEPSITMAINRF.DEPOSITCDRF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITCDRF;
                row["DEPSITMAINRF.DRAFTDRAWINGDATERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF;
                row["DEPSITMAINRF.DRAFTKINDRF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTKINDRF;
                row["DEPSITMAINRF.DRAFTKINDNAMERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTKINDNAMERF;
                row["DEPSITMAINRF.DRAFTDIVIDENAMERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTDIVIDENAMERF;
                row["DEPSITMAINRF.DRAFTNORF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTNORF;
                row["DEPSITMAINRF.CUSTOMERCODERF"] = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row["DEPSITMAINRF.CLAIMCODERF"] = frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF;
                row["SUBDEP.SUBSECTIONNAMERF"] = frePBillDetailWork.SUBDEP_SUBSECTIONNAMERF;
                row["DEPSITDTLRF.DEPOSITSLIPNORF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row["DEPSITDTLRF.DEPOSITROWNORF"] = detailRowNo; // ���s�ԍ�
                row["DEPSITDTLRF.MONEYKINDCODERF"] = 0;
                row["DEPSITDTLRF.MONEYKINDNAMERF"] = "�萔��";
                row["DEPSITDTLRF.MONEYKINDDIVRF"] = 0;
                row["DEPSITDTLRF.DEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF; // �������z���萔���������z
                row["DEPSITDTLRF.VALIDITYTERMRF"] = DBNull.Value;
                // ���t�W�J
                // (�ʏ�)
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false ); // yyyymmdd
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF, "DADD.DRAFTDRAWINGDATE", false ); // yyyymmdd
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITDTLRF_VALIDITYTERMRF, "DADD.VALIDITYTERM", false ); // yyyymmdd
                // �\�[�g�E���v�p����
                row[ct_col_Sort_CustomerCode] = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                row[ct_col_Sort_SalesSlipNo] = string.Empty;
                row[ct_col_Sort_DepositSlipNo] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                row[ct_col_Sort_DetailRowNo] = GetDepositRowNoForSort( detailRowNo, 7 );
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                // �`�[���v�������p ���׃^�C�g��
                row["DDEP.DETAILTITLERF"] = "�萔��";
                // ���ݒ莞 ���
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF ) ) row["DEPSITMAINRF.ADDUPSECCODERF"] = DBNull.Value; // �v�㋒�_�R�[�h
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF ) ) row["DEPSITMAINRF.SUBSECTIONCODERF"] = DBNull.Value; // ����R�[�h
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF ) ) row["DEPSITMAINRF.CUSTOMERCODERF"] = DBNull.Value; // ���Ӑ�R�[�h
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF ) ) row["DEPSITMAINRF.CLAIMCODERF"] = DBNull.Value; // ������R�[�h
                row[ct_col_DDep_MoneyKindNameSp] = "�萔��";
                row["DADD.MONEYKINDCODEOTHERRF"] = "07";
                row["DADD.FOOTER3PRINTRF"] = 0;
                // �ǉ�
                table.Rows.Add( row );
                # endregion
            }

            if ( frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF != 0 )
            {
                # region [�����l��]
                // �R�s�[����
                row = table.NewRow();
                detailRowNo++;
                row["DEPSITMAINRF.ACPTANODRSTATUSRF"] = frePBillDetailWork.DEPSITMAINRF_ACPTANODRSTATUSRF;
                row["DEPSITMAINRF.DEPOSITSLIPNORF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row["DEPSITMAINRF.SALESSLIPNUMRF"] = frePBillDetailWork.DEPSITMAINRF_SALESSLIPNUMRF;
                row["DEPSITMAINRF.ADDUPSECCODERF"] = frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF;
                row["DEPSITMAINRF.SUBSECTIONCODERF"] = frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF;
                row["DEPSITMAINRF.DEPOSITDATERF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF;
                row["DEPSITMAINRF.ADDUPADATERF"] = frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF;
                row["DEPSITMAINRF.DEPOSITRF"] = GetDepositTotal( frePBillDetailWork );//frePBillDetailWork.DEPSITMAINRF_DEPOSITRF;
                row["DEPSITMAINRF.FEEDEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF;
                row["DEPSITMAINRF.DISCOUNTDEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
                row["DEPSITMAINRF.AUTODEPOSITCDRF"] = frePBillDetailWork.DEPSITMAINRF_AUTODEPOSITCDRF;
                row["DEPSITMAINRF.DEPOSITCDRF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITCDRF;
                row["DEPSITMAINRF.DRAFTDRAWINGDATERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF;
                row["DEPSITMAINRF.DRAFTKINDRF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTKINDRF;
                row["DEPSITMAINRF.DRAFTKINDNAMERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTKINDNAMERF;
                row["DEPSITMAINRF.DRAFTDIVIDENAMERF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTDIVIDENAMERF;
                row["DEPSITMAINRF.DRAFTNORF"] = frePBillDetailWork.DEPSITMAINRF_DRAFTNORF;
                row["DEPSITMAINRF.CUSTOMERCODERF"] = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row["DEPSITMAINRF.CLAIMCODERF"] = frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF;
                row["SUBDEP.SUBSECTIONNAMERF"] = frePBillDetailWork.SUBDEP_SUBSECTIONNAMERF;
                row["DEPSITDTLRF.DEPOSITSLIPNORF"] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row["DEPSITDTLRF.DEPOSITROWNORF"] = detailRowNo; // ���s�ԍ�
                row["DEPSITDTLRF.MONEYKINDCODERF"] = 0;
                row["DEPSITDTLRF.MONEYKINDNAMERF"] = "�l����";
                row["DEPSITDTLRF.MONEYKINDDIVRF"] = 0;
                row["DEPSITDTLRF.DEPOSITRF"] = frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF; // �������z���l�����������z
                row["DEPSITDTLRF.VALIDITYTERMRF"] = DBNull.Value;
                // ���t�W�J
                // (�ʏ�)
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false ); // yyyymmdd
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF, "DADD.DRAFTDRAWINGDATE", false ); // yyyymmdd
                ExtractDate( ref row, allDefSet.EraNameDispCd2, frePBillDetailWork.DEPSITDTLRF_VALIDITYTERMRF, "DADD.VALIDITYTERM", false ); // yyyymmdd
                // �\�[�g�E���v�p����
                row[ct_col_Sort_CustomerCode] = frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                row[ct_col_Sort_SalesSlipNo] = string.Empty;
                row[ct_col_Sort_DepositSlipNo] = frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                row[ct_col_Sort_DetailRowNo] = GetDepositRowNoForSort( detailRowNo, 5 );
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                // �`�[���v�������p ���׃^�C�g��
                row["DDEP.DETAILTITLERF"] = "�l����";
                // ���ݒ莞 ���
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF ) ) row["DEPSITMAINRF.ADDUPSECCODERF"] = DBNull.Value; // �v�㋒�_�R�[�h
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF ) ) row["DEPSITMAINRF.SUBSECTIONCODERF"] = DBNull.Value; // ����R�[�h
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF ) ) row["DEPSITMAINRF.CUSTOMERCODERF"] = DBNull.Value; // ���Ӑ�R�[�h
                if ( IsZero( frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF ) ) row["DEPSITMAINRF.CLAIMCODERF"] = DBNull.Value; // ������R�[�h
                row[ct_col_DDep_MoneyKindNameSp] = "�l�@��";
                row["DADD.MONEYKINDCODEOTHERRF"] = "05";
                row["DADD.FOOTER3PRINTRF"] = 0;
                // �ǉ�
                table.Rows.Add( row );
                # endregion
            }
        }

        /// <summary>
        /// �������v�擾����
        /// </summary>
        /// <param name="frePBillDetailWork">���R���[������</param>
        /// <returns>�������v</returns>
        /// <remarks>
        /// <br>Note        : �������v�擾����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static Int64 GetDepositTotal( EBooksFrePBillDetailWork frePBillDetailWork )
        {
            // �������z�{�萔�������z�{�l�������z
            return frePBillDetailWork.DEPSITMAINRF_DEPOSITRF + frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF + frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
        }

        /// <summary>
        /// �W�v�t�b�^�ݒ菈��
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <param name="detailWork">���׃f�[�^</param>
        /// <param name="dmdPrtPtnWork">����������p�^�[���ݒ�</param>
        /// <param name="sortRecordDivState">�\�[�g�p���R�[�h�敪</param>
        /// <param name="parameter">������������C�A�E�g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �W�v�t�b�^�ݒ菈��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSummalyFooters( ref DataTable table, EBooksFrePBillDetailWork detailWork, DmdPrtPtnWork dmdPrtPtnWork, SortRecordDivState sortRecordDivState, BillDmdPrintParameter parameter )
        {
            DataRow row;

            //CustomerTtlPrtDiv 0:�󎚂��� 1:�󎚂��Ȃ�
            //DmdDtlPtnOdrDiv 0:�v���+�`�[�ԍ� 1:���Ӑ�+�v���+�`�[�ԍ�
            if ( dmdPrtPtnWork.CustomerTtlPrtDiv == 0 && dmdPrtPtnWork.DmdDtlPtnOdrDiv == 1 )
            {
                # region [���v�i���Ӑ�ʁj]
                //AddDayTtlPrtDiv 0:�󎚂��� 1:�󎚂��Ȃ�
                if ( dmdPrtPtnWork.AddDayTtlPrtDiv == 0 )
                {
                    row = FindSummalyRow( table, detailWork.SALESSLIPRF_CUSTOMERCODERF, detailWork.SALESSLIPRF_SALESDATERF );

                    if ( row == null )
                    {
                        row = table.NewRow();
                        # region [(�ǉ�)]
                        // �\�[�g�L�[
                        row[ct_col_Sort_CustomerCode] = detailWork.SALESSLIPRF_CUSTOMERCODERF;
                        row[ct_col_Sort_Date] = detailWork.SALESSLIPRF_SALESDATERF;
                        row[ct_col_Sort_RecordDiv] = SortRecordDivState.Daily;
                        row[ct_col_Sort_SalesSlipNo] = string.Empty;
                        row[ct_col_Sort_DepositSlipNo] = 0;
                        row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                        row[ct_col_Sort_DetailRowNo] = 0;
                        row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Daily;

                        // ���z
                        row["DSAL.DETAILSUMTITLERF"] = parameter.FooterTitleOfDaily;//*���v*
                        row["DSAL.DETAILSUMPRICERF"] = detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                        # endregion
                        table.Rows.Add( row );
                    }
                    else
                    {
                        # region [(�X�V)]
                        // ���Z����
                        row["DSAL.DETAILSUMPRICERF"] = (Int64)row["DSAL.DETAILSUMPRICERF"] + detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                        # endregion
                    }
                }
                # endregion

                # region [���Ӑ�v]
                row = FindSummalyRow( table, detailWork.SALESSLIPRF_CUSTOMERCODERF, 99999999 );

                if ( row == null )
                {
                    row = table.NewRow();
                    # region [(�ǉ�)]
                    // �\�[�g�L�[
                    row[ct_col_Sort_CustomerCode] = detailWork.SALESSLIPRF_CUSTOMERCODERF;
                    row[ct_col_Sort_Date] = 99999999;
                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Daily;
                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                    row[ct_col_Sort_DepositSlipNo] = 0;
                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                    row[ct_col_Sort_DetailRowNo] = 0;
                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Daily;
                    // ���z
                    row["DSAL.DETAILSUMTITLERF"] = parameter.FooterTitleOfCustomer;//*���Ӑ�v*
                    row["DSAL.DETAILSUMPRICERF"] = detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                    # endregion
                    table.Rows.Add( row );
                }
                else
                {
                    # region [(�X�V)]
                    // ���Z����
                    row["DSAL.DETAILSUMPRICERF"] = (Int64)row["DSAL.DETAILSUMPRICERF"] + detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                    # endregion
                }
                # endregion
            }
            else
            {
                # region [���v]
                //AddDayTtlPrtDiv 0:�󎚂��� 1:�󎚂��Ȃ�
                if ( dmdPrtPtnWork.AddDayTtlPrtDiv == 0 )
                {
                    if ( dmdPrtPtnWork.DmdDtlPtnOdrDiv == 1 )
                    {
                        // �\�[�g���ɓ��Ӑ悪�L��̂ŁA���Ӑ�ʓ��t�ʂɏW�v
                        row = FindSummalyRow( table, detailWork.SALESSLIPRF_CUSTOMERCODERF, detailWork.SALESSLIPRF_SALESDATERF );
                    }
                    else
                    {
                        // �\�[�g���ɓ��Ӑ悪�����̂ŁA(���Ӑ�ʂɂ���)���t�ʂɏW�v
                        row = FindSummalyRow( table, 0, detailWork.SALESSLIPRF_SALESDATERF );
                    }

                    if ( row == null )
                    {
                        row = table.NewRow();
                        # region [(�ǉ�)]
                        // �\�[�g�L�[
                        row[ct_col_Sort_CustomerCode] = detailWork.SALESSLIPRF_CUSTOMERCODERF;
                        row[ct_col_Sort_Date] = detailWork.SALESSLIPRF_SALESDATERF;
                        row[ct_col_Sort_RecordDiv] = SortRecordDivState.Daily;
                        row[ct_col_Sort_SalesSlipNo] = string.Empty;
                        row[ct_col_Sort_DepositSlipNo] = 0;
                        row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                        row[ct_col_Sort_DetailRowNo] = 0;
                        row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Daily;
                        // ���z
                        row["DSAL.DETAILSUMTITLERF"] = parameter.FooterTitleOfDaily;//*���v*
                        row["DSAL.DETAILSUMPRICERF"] = detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                        # endregion
                        table.Rows.Add( row );
                    }
                    else
                    {
                        # region [(�X�V)]
                        // ���Z����
                        row["DSAL.DETAILSUMPRICERF"] = (Int64)row["DSAL.DETAILSUMPRICERF"] + detailWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                        # endregion
                    }
                }
                # endregion
            }
        }
        /// <summary>
        /// �W�v�s�擾����
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <param name="customerCode">���Ӑ�</param>
        /// <param name="date">���t</param>
        /// <returns>�W�v�s</returns>
        /// <remarks>
        /// <br>Note        : �W�v�s�擾����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static DataRow FindSummalyRow( DataTable table, int customerCode, int date )
        {
            DataView view = new DataView( table );
            if ( customerCode == 0 )
            {
                // ���Ӑ斢�w��
                view.RowFilter = string.Format( "{0}='{1}' AND {2}='{3}'",
                                                ct_col_Sort_Date, date,
                                                ct_col_Sort_RecordDiv, (int)SortRecordDivState.Daily );
            }
            else
            {
                // ���Ӑ�w�肠��
                view.RowFilter = string.Format( "{0}='{1}' AND {2}='{3}' AND {4}='{5}'",
                                                ct_col_Sort_CustomerCode, customerCode,
                                                ct_col_Sort_Date, date,
                                                ct_col_Sort_RecordDiv, (int)SortRecordDivState.Daily );
            }
            if (view.Count > 0)
            {
                return view[0].Row;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// �W�v�t�b�^�ݒ菈��(�����p)
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <param name="detailWork">���׃f�[�^</param>
        /// <param name="dmdPrtPtnWork">����������p�^�[���ݒ�</param>
        /// <param name="sortRecordDivState">�\�[�g�p���R�[�h�敪</param>
        /// <param name="allDefSet">�S�̏����\���ݒ�</param>
        /// <param name="parameter">������������C�A�E�g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : �W�v�t�b�^�ݒ菈��(�����p)</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectDepositSummalyFooters( ref DataTable table, EBooksFrePBillDetailWork detailWork, DmdPrtPtnWork dmdPrtPtnWork, SortRecordDivState sortRecordDivState, BillDmdPrintParameter parameter, AllDefSetWork allDefSet )
        {
            // 0:�󎚂��� 1:�󎚂��Ȃ�
            if (dmdPrtPtnWork.SlipTtlPrtDiv == 0)
            {
                DataRow row = table.NewRow();

                # region [(�ǉ�)]
                // �\�[�g�L�[
                row[ct_col_Sort_CustomerCode] = detailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = detailWork.DEPSITMAINRF_DEPOSITDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                row[ct_col_Sort_SalesSlipNo] = string.Empty;
                row[ct_col_Sort_DepositSlipNo] = detailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                row[ct_col_Sort_DetailRowNo] = 0;
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;

                // ����
                row["DEPSITMAINRF.DEPOSITDATERF"] = detailWork.DEPSITMAINRF_DEPOSITDATERF;
                ExtractDate(ref row, allDefSet.EraNameDispCd2, detailWork.DEPSITMAINRF_DEPOSITDATERF, "DADD.DEPOSITDATE", false); // yyyymmdd
                row["DEPSITMAINRF.DEPOSITSLIPNORF"] = detailWork.DEPSITMAINRF_DEPOSITSLIPNORF;

                // �v
                row[ct_col_DDep_DepFtOutLine] = detailWork.DEPSITMAINRF_OUTLINERF;
                row["DDEP.DETAILSUMTITLERF"] = parameter.FooterTitleOfSlip; // *�`�[�v*
                row["DDEP.DETAILSUMPRICERF"] = GetDepositTotal(detailWork); //detailWork.DEPSITMAINRF_DEPOSITRF;
                # endregion

                if (dmdPrtPtnWork.DepoDtlPrcPrtDiv != 2 || string.IsNullOrEmpty(detailWork.DEPSITMAINRF_OUTLINERF))
                {
                    row["DADD.DTLTITLERF"] = DBNull.Value;
                }
                else
                {
                    row["DADD.DTLTITLERF"] = "<���l>";
                }
                row["DADD.DEPOSITFTTITLERF"] = parameter.DepositFooterTitleOfSlip;

                if (ReportItemDic.ContainsKey("SALESSLIPRF.SLIPNOTE2_2RF"))
                {
                    table.Rows.Add(row);
                    row = table.NewRow();
                    row[ct_col_Sort_CustomerCode] = detailWork.DEPSITMAINRF_CUSTOMERCODERF;
                    row[ct_col_Sort_Date] = detailWork.DEPSITMAINRF_DEPOSITDATERF;
                    row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                    row[ct_col_Sort_SalesSlipNo] = string.Empty;
                    row[ct_col_Sort_DepositSlipNo] = detailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                    row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                    row[ct_col_Sort_DetailRowNo] = 0;
                    row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                }

                table.Rows.Add(row);
            }

            if (ReportItemDic.ContainsKey("DADD.DETAILBLANKLINERF"))
            {
                DataRow row = table.NewRow();
                // ���׃t�b�^��s������Ȃ��s�ǉ�
                row = table.NewRow();
                row[ct_col_Sort_CustomerCode] = detailWork.DEPSITMAINRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = detailWork.DEPSITMAINRF_DEPOSITDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Deposit;
                row[ct_col_Sort_SalesSlipNo] = string.Empty;
                row[ct_col_Sort_DepositSlipNo] = detailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                row[ct_col_Sort_DetailRowNo] = 0;
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Deposit;
                table.Rows.Add(row);
            }
        }

        /// <summary>
        /// (�擪)�Ԏ햼(�Q�s�ڂ݈̂�)�@���גǉ�����
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <param name="frePBillDetailWork">���R���[������</param>
        /// <param name="dmdPrtPtnWork">����������p�^�[���ݒ�</param>
        /// <remarks>
        /// <br>Note        : (�擪)�Ԏ햼(�Q�s�ڂ݈̂�)�@���גǉ�����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectModelNameDetailExtra(ref DataTable table, EBooksFrePBillDetailWork frePBillDetailWork, DmdPrtPtnWork dmdPrtPtnWork)
        {
            int detailRowNo = frePBillDetailWork.SALESDETAILRF_SALESROWNORF;
            DataRow row;

                row = table.NewRow();
                detailRowNo++;
                row["SALESSLIPRF.SALESDATERF"] = frePBillDetailWork.SALESSLIPRF_SALESDATERF;
                row["SALESSLIPRF.SALESSLIPNUMRF"] = frePBillDetailWork.SALESSLIPRF_SALESSLIPNUMRF;
                row["SALESSLIPRF.SALESSLIPCDRF"] = frePBillDetailWork.SALESSLIPRF_SALESSLIPCDRF;
                row["SALESDETAILRF.SALESMONEYTAXINCRF"] = frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF;
                row["SALESDETAILRF.SALESROWNORF"] = detailRowNo;//���s�ԍ�
                row["ACCEPTODRCARRF.FULLMODELRF"] = frePBillDetailWork.ACCEPTODRCARRF_FULLMODELRF;
                row["DADD.MODELHALFNAMEDTL2RF"] = frePBillDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF;

                if (string.IsNullOrEmpty(frePBillDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF))
                   {
                       row["DADD.MODELHALFNAMEDTL2RF"] = GetKanaString(frePBillDetailWork.ACCEPTODRCARRF_MODELFULLNAMERF);
                   }

                # region [�\�[�g�E���v�Ή�]
                row[ct_col_Sort_CustomerCode] = frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF;
                row[ct_col_Sort_Date] = frePBillDetailWork.SALESSLIPRF_SALESDATERF;
                row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                row[ct_col_Sort_SalesSlipNo] = frePBillDetailWork.SALESSLIPRF_SALESSLIPNUMRF;
                row[ct_col_Sort_DepositSlipNo] = 0;
                row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                row[ct_col_Sort_DetailRowNo] = 0;
                row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                # endregion

                table.Rows.Add(row);
        }

        /// <summary>
        /// ���^���擾���� (�R������Ή�)
        /// </summary>
        /// <param name="fullModel">�^��</param>
        /// <returns>�^��</returns>
        /// <remarks>
        /// <br>Note        : ���^���擾���� (�R������Ή�)</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetFullModel(string fullModel)
        {
            string[] fullModels = fullModel.Split('-');
            string secondModel = string.Empty;

            if (fullModels.Length > 1)
            {
                if ( fullModels[0].Length >= 3 )
                {
                    secondModel = fullModels[0];
                }
                else
                {
                    secondModel = fullModels[1];
                }
            }
            else
            {
                secondModel = fullModel;
            }
            return secondModel;

        }
        /// <summary>
        /// �^���擾
        /// </summary>
        /// <param name="detailWork">���׃f�[�^</param>
        /// <returns>�^��</returns>
        /// <remarks>
        /// <br>Note        : �^���擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetFullModel(EBooksFrePBillDetailWork detailWork)
        {
            string fullModel = null;
            fullModel = GetFullModel(detailWork.ACCEPTODRCARRF_FULLMODELRF);
            return fullModel;
        }

        /// <summary>
        /// ����f�[�^�W�J����
        /// </summary>
        /// <param name="source">�f�[�^�f�[�u��</param>
        /// <returns>����f�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note        : ����f�[�^���P�y�[�W�ڂƂQ�y�[�W�ڈȍ~�ɕ����ăe�[�u���̃��X�g�𐶐����܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<DataTable> DevelopPrintDataList( ref DataTable source )
        {
            List<DataTable> printDataList = new List<DataTable>();

            for ( int sourceIndex = 0; sourceIndex < source.DefaultView.Count; sourceIndex++ )
            {
                DataRow row = source.DefaultView[sourceIndex].Row;

                int index;
                if ( row[ct_col_PageCount] != DBNull.Value )
                {
                    if ((int)row[ct_col_PageCount] == 1)
                    {
                        index = 0;
                    }
                    else
                    {
                        index = 1;
                    }
                }
                else
                {
                    index = 0;
                }

                if ( printDataList.Count - 1 < index )
                {
                    printDataList.Add( CreatePrintDataTable() );
                    printDataList[index].DefaultView.Sort = source.DefaultView.Sort;
                }
                printDataList[index].ImportRow( row );
            }

            return printDataList;
        }

        /// <summary>
        /// ���ב��s���̎Z�o
        /// </summary>
        /// <param name="dataCount">�f�[�^��</param>
        /// <param name="feedCount">�P�y�[�W�s��</param>
        /// <param name="otherFeedAddCount">�Q�y�[�W�ڈȍ~�̍s��</param>
        /// <returns>���ב��s��</returns>
        /// <remarks>
        /// <br>Note        : ���ב��s���̎Z�o</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetAllDetailCount( int dataCount, int feedCount, int otherFeedAddCount )
        {
            if ( dataCount <= feedCount )
            {
                //--------------------------
                // �P�y�[�W�Ɏ��܂�
                //--------------------------
                return feedCount;
            }
            else
            {
                //--------------------------
                // �Q�y�[�W�ȏ゠��
                //--------------------------

                // �P�y�[�W�ڂ̍s��������
                dataCount -= feedCount;
                // �Q�y�[�W�ڈȍ~�̍s�����Z�o����,�P�y�[�W�ڂ̍s����������
                return GetAllDetailCountSub( dataCount, (feedCount + otherFeedAddCount) ) + feedCount;
            }

        }
        /// <summary>
        /// ���ב��s���̎Z�oSub
        /// </summary>
        /// <param name="dataCount">�f�[�^��</param>
        /// <param name="feedCount">�P�y�[�W�s��</param>
        /// <returns>���ב��s��</returns>
        /// <remarks>
        /// <br>Note        : ���ב��s���̎Z�o</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetAllDetailCountSub( int dataCount, int feedCount )
        {
            if ( dataCount % feedCount == 0 )
            {
                // ����؂�� �� �f�[�^�s���Ɩ��ב��s���̓C�R�[���łn�j
                return dataCount;
            }
            else
            {
                // ����؂�Ȃ� �� �K�v�ȗ]�����܂߂����׍s����Ԃ�
                return (dataCount + (feedCount - (dataCount % feedCount)));
            }
        }

        # region [�O���[�v�T�v���X]
        /// <summary>
        /// ���t�T�v���X
        /// </summary>
        /// <param name="row">�f�[�^�s</param>
        /// <remarks>
        /// <br>Note        : ���t�T�v���X</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void SuppressOfDate( ref DataRow row )
        {
            // ����
            ExtractDate( ref row, 0, 0, "DADD.SALESDATE", false ); // yyyymmdd
            ExtractDate( ref row, 0, 0, "DADD.FIRSTENTRYDATE", true ); // yyyymm
            // ����
            ExtractDate( ref row, 0, 0, "DADD.DEPOSITDATE", false ); // yyyymmdd
            ExtractDate( ref row, 0, 0, "DADD.DRAFTDRAWINGDATE", false ); // yyyymmdd
            ExtractDate( ref row, 0, 0, "DADD.VALIDITYTERM", false ); // yyyymmdd
        }
        /// <summary>
        /// �`�[�ԍ��T�v���X
        /// </summary>
        /// <param name="row">�f�[�^�s</param>
        /// <remarks>
        /// <br>Note        : �`�[�ԍ��T�v���X</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void SuppressOfSlipNo( ref DataRow row )
        {
            // ����
            row["SALESSLIPRF.SALESSLIPNUMRF"] = DBNull.Value;
            // ����
            row["DEPSITMAINRF.DEPOSITSLIPNORF"] = DBNull.Value;
            row["DEPSITDTLRF.DEPOSITSLIPNORF"] = DBNull.Value;
        }
        /// <summary>
        /// ���q���T�v���X
        /// </summary>
        /// <param name="row">�f�[�^�s</param>
        /// <remarks>
        /// <br>Note        : ���q���T�v���X</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void SuppressOfCar( ref DataRow row )
        {
            row["ACCEPTODRCARRF.CARMNGNORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.CARMNGCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE1CODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE1NAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE2RF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE3RF"] = DBNull.Value;
            row["ACCEPTODRCARRF.NUMBERPLATE4RF"] = DBNull.Value;
            row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MAKERCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MAKERFULLNAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELSUBCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELFULLNAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.EXHAUSTGASSIGNRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.SERIESMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.CATEGORYSIGNMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.FULLMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELDESIGNATIONNORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.CATEGORYNORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.FRAMEMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.FRAMENORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.SEARCHFRAMENORF"] = DBNull.Value;
            row["ACCEPTODRCARRF.ENGINEMODELNMRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.RELEVANCEMODELRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.SUBCARNMCDRF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELGRADESNAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.COLORCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.COLORNAME1RF"] = DBNull.Value;
            row["ACCEPTODRCARRF.TRIMCODERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.TRIMNAMERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MILEAGERF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFYRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFSRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFWRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFMRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFGRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFRRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFLSRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFLPRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFLYRF"] = DBNull.Value;
            row["DADD.FIRSTENTRYDATEFLMRF"] = DBNull.Value;
            row["DADD.CARMNGCODETITLERF"] = DBNull.Value;
            row["ACCEPTODRCARRF.MODELHALFNAMERF"] = DBNull.Value;
            row["DADD.FULLMODELORMODELHALFNAMERF"] = DBNull.Value;
        }
        # endregion

        /// <summary>
        /// ������ ���㖾�� �K�p����
        /// </summary>
        /// <param name="table">�e�[�u��</param>
        /// <param name="salesWork">����f�[�^</param>
        /// <param name="dmdPrtPtnWork">�������</param>
        /// <param name="parameter">������C�A�E�g�p�����[�^</param>
        /// <param name="headWork">�w�b�_�[���</param>
        /// <remarks>
        /// <br>Note        : ������ ���㖾�� �K�p����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2023/04/14 3H ����</br>
        /// <br>�Ǘ��ԍ�     : 11970040-00 ���R���[���ڒǉ��Ή�</br>
        /// <br>             : �@����`�[�v���z(�ō���)</br>
        /// <br>             : �A�����(�`�[�]��)/����`�[�v���z(�ō���)</br>
        /// </remarks>
        private static void ReflectSalesFooter(ref DataTable table, EBooksFrePBillDetailWork salesWork, DmdPrtPtnWork dmdPrtPtnWork, BillDmdPrintParameter parameter, EBooksFrePBillHeadWork headWork)
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS"); 
            // 0:�󎚂��� 1:�󎚂��Ȃ�
            if (dmdPrtPtnWork.SlipTtlPrtDiv == 0)
            {
                // �`�[�ԍ����ς�����獇�v�s��ǉ�
                DataRow footerRow = table.NewRow();
                bool isParent = (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0);
                if (ReportItemDic.ContainsKey("DADD.ADDTAXLINERF"))
                {
                    // ����ōs��ǉ�
                    if (isParent && (headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 0 || headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 1))
                    {
                        footerRow["DADD.SALESFTTITLERF"] = parameter.SlipTtlTaxTitle; // �����
                        footerRow["DADD.SALESFTPRICERF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;
                        footerRow["SALESSLIPRF.SALESSLIPNUMRF"] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                        footerRow["SALESSLIPRF.SALESDATERF"] = salesWork.SALESSLIPRF_SALESDATERF;
                        footerRow["SALESSLIPRF.PARTYSALESLIPNUMRF"] = salesWork.SALESSLIPRF_PARTYSALESLIPNUMRF;
                        # region [�\�[�g�E���v�Ή�]
                        footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                        footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                        footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                        footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                        footerRow[ct_col_Sort_DepositSlipNo] = 0;
                        footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                        footerRow[ct_col_Sort_DetailRowNo] = 0;
                        footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                        # endregion
                        table.Rows.Add(footerRow);
                        footerRow = table.NewRow();
                    }
                }

                footerRow["DADD.SALESFTTITLERF"] = parameter.FooterTitleOfSlip;//*�`�[�v*
                // ����ōs�ǉ����\���Ă��鎞�̂ݏ���
                // ����ōs��ǉ������ꍇ�͐ō����z���󎚂���B
                if (ReportItemDic.ContainsKey("DADD.ADDTAXLINERF"))
                {
                    if (isParent && (headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 0 || headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 1))
                    {
                        footerRow["DADD.SALESFTPRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXINCRF;
                    }
                    else
                    {
                        footerRow["DADD.SALESFTPRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                    }
                }
                else
                {
                    footerRow["DADD.SALESFTPRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF;
                } 
                footerRow["DADD.SALESFTNOTE1RF"] = salesWork.SALESSLIPRF_SLIPNOTERF;
                footerRow["DADD.SALESFTNOTE2RF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;
                footerRow["DADD.SALESFTNOTE3RF"] = salesWork.SALESSLIPRF_SLIPNOTE3RF;

                footerRow["SALESSLIPRF.SALESSLIPNUMRF"] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow["SALESSLIPRF.SALESDATERF"] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow["SALESSLIPRF.PARTYSALESLIPNUMRF"] = salesWork.SALESSLIPRF_PARTYSALESLIPNUMRF;
                // �`�[���v�����
                // ������e���]�ŕ������`�[�P�ʁE���גP�ʂ̎��݈̂�
                if (isParent && (headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 0 || headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 1))
                {
                    footerRow["DADD.SLIPTTLTAXTITLERF"] = parameter.SlipTtlTaxTitle; // �����
                    footerRow["DADD.SLIPTTLTAXRF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;
                }
                else
                {
                    footerRow["DADD.SLIPTTLTAXTITLERF"] = DBNull.Value; // �����
                    footerRow["DADD.SLIPTTLTAXRF"] = DBNull.Value;
                }

                // --- ADD START 3H ���� 2023/04/14 ----------------------------------->>>>>
                #region [�@����`�[�v���z(�ō���) �A�����(�`�[�]��)/����`�[�v���z(�ō���) �ǉ�]
                // �]�ŕ������`�[�P�� ���� �`�[���v���z(�Ŕ�) <>0 �݈̂� 
                if ((salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 0) && (salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF != 0))
                {
                    // �ő�󎚌���:12
                    const int iMaxLength = 12;
                    string lSalesMoneyTaxInc = SetFormat(salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF + salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF, iMaxLength);
                    footerRow["DADD.SALESMONEYTAXINCRF"] = lSalesMoneyTaxInc;
                    footerRow["DADD.TAXRFANDSALESMONEYTAXINCRF"] = SetFormat(salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF, iMaxLength) + "/" + lSalesMoneyTaxInc;
                }
                #endregion
                // --- ADD END 3H ���� 2023/04/14 -------------------------------------<<<<<

                # region [�\�[�g�E���v�Ή�]
                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                footerRow[ct_col_Sort_DetailRowNo] = 0;
                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                # endregion

                if (ReportItemDic.ContainsKey("DADD.MODELHALFNAMEDTL3RF"))
                {
                    if (!_modelHalfNameDtl3PrtFlg)
                    {
                        // 1�s�ڂ̎Ԏ햼���󎚂���
                        footerRow["DADD.MODELHALFNAMEDTL3RF"] = _modelHalfNameDtl1;
                    }
                    _modelHalfNameDtl3PrtFlg = false;
                }

                if (ReportItemDic.ContainsKey("DADD.CARMNGNO2RF"))
                {
                    if (!_carMngNo2PrtFlg)
                    {
                        // �P�s�ڂ̎��q�Ǘ��ԍ����󎚂���
                        footerRow["DADD.CARMNGNO2RF"] = _carMngNo2Dtl1;
                        if (!string.IsNullOrEmpty(_carMngNo2Dtl1))
                        {
                            footerRow["DADD.CARMNGCODETITLE2RF"] = "�y��ڰāz";
                        }
                    }
                    _carMngNo2PrtFlg = false;
                }

                if (string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF))
                {
                    footerRow["DADD.DTLTITLERF"] = DBNull.Value;
                }
                else
                {
                    footerRow["DADD.DTLTITLERF"] = "<���l>";
                }

                // ����t�b�^�œ`�[���l�Q�i���ׂQ�s�ڈ󎚁j�����󎚂�������1�s�݈̂󎚂������ꍇ�͈󎚂���
                if (ReportItemDic.ContainsKey("SALESSLIPRF.SLIPNOTE2_2RF"))
                {
                    footerRow["DADD.FOOTER3PRINTRF"] = 97;
                    if (_slipNote2PrtCnt < 2)
                    {
                        bool emptyLineFlg = false;
                        if (_slipNote2PrtCnt == 1)
                            emptyLineFlg = true;
                        string salesSlipNote2 = salesWork.SALESSLIPRF_SLIPNOTE2RF;
                        string prtSalesSlipNote2 = "";
                        string targetStr = "";
                        int maxNum = sjisEnc.GetByteCount(salesSlipNote2);
                        int prtCnt = 16;    // ��s�Ɉ󎚂���o�C�g��
                        int nowNum = 0;
                        int cutPoint = 0;
                        if (_slipNote2PrtCnt == 0)
                        {
                            // �Q�s�ڂȂ���l�Q�̓�����16�o�C�g��
                            if (maxNum > prtCnt)
                            {
                                if (maxNum > prtCnt)
                                {
                                    while (nowNum < prtCnt)
                                    {
                                        targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                        if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                        {
                                            break;
                                        }
                                        cutPoint++;
                                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                    }
                                    prtSalesSlipNote2 = salesSlipNote2.Substring(0, cutPoint);
                                }
                                else
                                {
                                    prtSalesSlipNote2 = salesSlipNote2;
                                }
                                if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                    footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = string.Empty;
                                else
                                    footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;
                            }
                            else
                            {
                                prtSalesSlipNote2 = salesSlipNote2;
                            }
                            if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = string.Empty;
                            else
                            {
                                footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;
                            }
                            _slipNote2PrtCnt++;
                            table.Rows.Add(footerRow);

                            footerRow = table.NewRow();
                            # region [�\�[�g�E���v�Ή�]
                            footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                            footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                            footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                            footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                            footerRow[ct_col_Sort_DepositSlipNo] = 0;
                            footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                            footerRow[ct_col_Sort_DetailRowNo] = 0;
                            footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                            footerRow["DADD.FOOTER3PRINTRF"] = 97;
                            # endregion
                        }
                        if (_slipNote2PrtCnt == 1)
                        {
                            // �R�s�ڂȂ���l�Q��17�o�C�g�ڂ���16�o�C�g��
                            if (maxNum > prtCnt)
                            {
                                while (nowNum < prtCnt)
                                {
                                    targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                    if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                    {
                                        break;
                                    }
                                    cutPoint++;
                                    nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                }
                                salesSlipNote2 = salesSlipNote2.Substring(cutPoint, salesSlipNote2.Length - cutPoint);

                                if (maxNum > prtCnt * 2)
                                {
                                    maxNum = sjisEnc.GetByteCount(salesSlipNote2);
                                    nowNum = 0;
                                    cutPoint = 0;
                                    while (nowNum < prtCnt)
                                    {
                                        targetStr = salesSlipNote2.Substring(cutPoint, 1);
                                        if (nowNum + sjisEnc.GetByteCount(targetStr) > prtCnt)
                                        {
                                            break;
                                        }
                                        cutPoint++;
                                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                                    }
                                    prtSalesSlipNote2 = salesSlipNote2.Substring(0, cutPoint);
                                }
                                else
                                {
                                    prtSalesSlipNote2 = salesSlipNote2;
                                }
                            }
                            else
                            {
                                prtSalesSlipNote2 = "";
                            }
                            if (string.IsNullOrEmpty(prtSalesSlipNote2))
                                footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = string.Empty;
                            else
                                footerRow["SALESSLIPRF.SLIPNOTE2_2RF"] = prtSalesSlipNote2;

                            if (emptyLineFlg)
                            {
                                table.Rows.Add(footerRow);

                                footerRow = table.NewRow();
                                # region [�\�[�g�E���v�Ή�]
                                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                                footerRow[ct_col_Sort_DetailRowNo] = 0;
                                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                                footerRow["DADD.FOOTER3PRINTRF"] = 97;
                                #endregion
                            }
                        }
                    }
                    else
                    {
                        // ��s�̂ݒǉ�
                        table.Rows.Add(footerRow);

                        footerRow = table.NewRow();
                        # region [�\�[�g�E���v�Ή�]
                        footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                        footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                        footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                        footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                        footerRow[ct_col_Sort_DepositSlipNo] = 0;
                        footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                        footerRow[ct_col_Sort_DetailRowNo] = 0;
                        footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                        footerRow["DADD.FOOTER3PRINTRF"] = 97;
                        # endregion
                    }
                }
                _slipNote2PrtCnt = 0;

                table.Rows.Add(footerRow);
            }
            if (ReportItemDic.ContainsKey("DADD.DETAILBLANKLINERF"))
            {
                DataRow footerRow = table.NewRow();
                // ���׃t�b�^��s������Ȃ��s�ǉ�
                footerRow = table.NewRow();
                # region [�\�[�g�E���v�Ή�]
                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                footerRow[ct_col_Sort_DetailRowNo] = 0;
                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                footerRow["DADD.FOOTER3PRINTRF"] = 97;
                # endregion
                table.Rows.Add(footerRow);
            }
        }
        /// <summary>
        /// ����t�b�^�Q�@���㖾�ׁ@�K�p����(�|�c����ʑΉ�)
        /// </summary>
        /// <param name="table">�e�[�u��</param>
        /// <param name="salesWork">����f�[�^</param>
        /// <param name="dmdPrtPtnWork">�������</param>
        /// <param name="headWork">�w�b�_�[���</param>
        /// <param name="parameter">������C�A�E�g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : ����t�b�^�Q�@���㖾�ׁ@�K�p����(�|�c����ʑΉ�)</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSalesFooter2(ref DataTable table, EBooksFrePBillDetailWork salesWork, DmdPrtPtnWork dmdPrtPtnWork, BillDmdPrintParameter parameter, EBooksFrePBillHeadWork headWork)
        {
            //����ň󎚗L���t���O
            bool _salesSubTtlTax = false;
            bool isParent = (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0);
            // ����`�[�v���z�Q�������Ă���ꍇ�A���ד]�łƓ`�[�]�ňȊO�͔���t�b�^�Q���󎚂��Ȃ�
            if (ReportItemDic.ContainsKey("DADD.SALESFT2PRICE2RF"))
            {
                if (salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF != 0 && salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF != 1)
                {
                    return;
                }
            }

            //�󎚂���
            if (dmdPrtPtnWork.SlipTtlPrtDiv == 0)
            {
                DataRow footerRow = table.NewRow();
                //���ד]�ŁE�`�[�]�ł̏ꍇ�͍��v����ł��󎚂���
                if(salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 0 || salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 1)
                {
                    footerRow["DADD.SALESFT2PRICERF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;//�����
                    _salesSubTtlTax = true;

                    footerRow["DADD.SALESFT2TITLERF"] = parameter.FooterTitleOfTax;//����Ń^�C�g��
                    footerRow["DADD.SALESFT2PRICE2RF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;//�����
                    footerRow["DADD.SALESFT2TITLE2RF"] = parameter.FooterTitleOfTax2;//����Ń^�C�g���Q

                    if (string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF))
                    {
                        //���l�P���Ȃ��ꍇ�͔��l�Q����
                        footerRow["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;//�`�[���l�Q
                    }
                    else
                    {
                        footerRow["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTERF;//�`�[���l�P
                    }
                }
                else
                {
                    //�����]�ŁE��ېł̏ꍇ�͓`�[���v���z(�Ŕ�)���󎚂���
                    footerRow["DADD.SALESFT2PRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXEXCRF;//�`�[���v���z(�Ŕ�)
                    footerRow["DADD.SALESFT2TITLERF"] = parameter.FooterTitleOfSlip;//�`�[�v�^�C�g��

                    if (string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF))
                    {
                        //���l�P���Ȃ��ꍇ�͔��l�Q����
                        footerRow["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;//�`�[���l�Q
                    }
                    else
                    {
                        footerRow["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTERF;//�`�[���l�P
                    }

                }

                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                footerRow[ct_col_Sort_DetailRowNo] = 0;
                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;

                table.Rows.Add(footerRow);


                DataRow footer2Row = table.NewRow();

                if (_salesSubTtlTax)
                {
                    // ����ł��󎚂���ꍇ�́A�`�[���v���z(�ō�)�����̍s�Ɉ󎚂���
                    footer2Row["DADD.SALESFT2PRICERF"] = salesWork.SALESSLIPRF_SALESTOTALTAXINCRF;//�`�[���v���z(�ō�)
                    footer2Row["DADD.SALESFT2TITLERF"] = parameter.FooterTitleOfSlipTaxInc;//�ېō��v�^�C�g��
                    footer2Row["DADD.SALESFT2PRICE2RF"] = salesWork.SALESSLIPRF_SALESTOTALTAXINCRF;//�`�[���v���z(�ō�)
                    footer2Row["DADD.SALESFT2TITLE2RF"] = parameter.FooterTitleOfSlipTaxInc2;//�ېō��v�^�C�g���Q
                    if (string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF))
                    {
                        footer2Row["DADD.SALESFT2NOTERF"] = DBNull.Value;
                    }
                    else
                    {
                        footer2Row["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;//�`�[���l�Q
                    }


                    footer2Row[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                    footer2Row[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                    footer2Row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                    footer2Row[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                    footer2Row[ct_col_Sort_DepositSlipNo] = 0;
                    footer2Row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                    footer2Row[ct_col_Sort_DetailRowNo] = 0;
                    footer2Row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;

                    table.Rows.Add(footer2Row);
                }
                else
                {
                    // ����ł��Ȃ��ꍇ�́A�`�[���l�P�E�`�[���l�Q������Ƃ��̂݁A�`�[���l�Q�̍s��ǉ�����
                    if (!string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTERF) && !string.IsNullOrEmpty(salesWork.SALESSLIPRF_SLIPNOTE2RF))
                    {
                        footer2Row["DADD.SALESFT2NOTERF"] = salesWork.SALESSLIPRF_SLIPNOTE2RF;//�`�[���l�Q

                        footer2Row[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                        footer2Row[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                        footer2Row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                        footer2Row[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                        footer2Row[ct_col_Sort_DepositSlipNo] = 0;
                        footer2Row[ct_col_Sort_DetailDiv] = SortDetailDivState.Footer;
                        footer2Row[ct_col_Sort_DetailRowNo] = 0;
                        footer2Row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;

                        table.Rows.Add(footer2Row);
                    }   
                }
            }
        }
        #region
        /// <summary>
        /// ����t�b�^�R�@���㖾�ׁ@�E�v����(�R������ʑΉ�)
        /// </summary>
        /// <param name="table">�e�[�u��</param>
        /// <param name="salesWork">����f�[�^</param>
        /// <param name="dmdPrtPtnWork">�������</param>
        /// <param name="parameter">������C�A�E�g�p�����[�^</param>
        /// <param name="headWork">�w�b�_�[���</param>
        /// <remarks>
        /// <br>Note        : ����t�b�^�R�@���㖾�ׁ@�E�v����(�R������ʑΉ�)</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSalesFooter3(ref DataTable table, EBooksFrePBillDetailWork salesWork, DmdPrtPtnWork dmdPrtPtnWork, BillDmdPrintParameter parameter, EBooksFrePBillHeadWork headWork)
        {
            int RowCount = salesWork.SALESDETAILRF_SALESROWNORF * 10;

            //�󎚂���
            if (dmdPrtPtnWork.SlipTtlPrtDiv == 0)
            {
                //�`�[���l�s��ǉ�
                DataRow footerNoteRow = table.NewRow();
                footerNoteRow["DADD.SALESFT3NOTERF"] = "�i�E�v�j" + salesWork.SALESSLIPRF_SLIPNOTERF; //�`�[���l
                footerNoteRow["DADD.FOOTER3PRINTRF"] = 96; //����t�b�^�R�i���׍s����p�j
                RowCount = RowCount + 10;

                #region [�\�[�g�E���v�Ή�]
                footerNoteRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerNoteRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerNoteRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerNoteRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerNoteRow[ct_col_Sort_DepositSlipNo] = 0;
                footerNoteRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                footerNoteRow[ct_col_Sort_DetailRowNo] = RowCount.ToString();
                footerNoteRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                #endregion

                table.Rows.Add(footerNoteRow);


                DataRow footerRow = table.NewRow();
                //�`�[�]�ŁE���ד]�ŁE�����]�ł̏ꍇ
                footerRow["DADD.SALESFT3PRICERF"] = salesWork.SALESSLIPRF_SALESPRTTOTALTAXEXCRF;//�`�[���v���z(�Ŕ�)
                footerRow["DADD.SALESFT3TITLERF"] = parameter.FooterTitleOfSlip;//�`�[�v�^�C�g��
                footerRow["DADD.SALESFT3NOTERF"] = DBNull.Value;
                footerRow["DADD.FOOTER3PRINTRF"] = 97; //����t�b�^�R�i���׍s����p�j
                RowCount = RowCount + 10;

                #region [�\�[�g�E���v�Ή�]
                footerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                footerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                footerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                footerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                footerRow[ct_col_Sort_DepositSlipNo] = 0;
                footerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                footerRow[ct_col_Sort_DetailRowNo] = RowCount.ToString();
                footerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                #endregion

                table.Rows.Add(footerRow);

                DataRow footer2Row = table.NewRow();
                if ( (salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 0 || salesWork.SALESSLIPRF_CONSTAXLAYMETHODRF == 1) &&
                     (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0))
                {
                    //// ��ېňȊO�̏ꍇ�́A����ł����̍s�Ɉ󎚂���
                    // �`�[�]��or���ד]�łŁA���e�̏ꍇ�́A����ł����̍s�Ɉ󎚂���
                    footer2Row["DADD.SALESFT3PRICERF"] = salesWork.SALESSLIPRF_SALESSUBTOTALTAXRF;//����ŋ��z
                    footer2Row["DADD.SALESFT3TITLERF"] = parameter.FooterTitleOfTax;//����Ń^�C�g��
                    footer2Row["DADD.SALESFT3NOTERF"] = DBNull.Value;
                    footer2Row["DADD.FOOTER3PRINTRF"] = 98; //����t�b�^�R�i���׍s����p�j
                    RowCount = RowCount + 10;

                    # region [�\�[�g�E���v�Ή�]
                    footer2Row[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                    footer2Row[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                    footer2Row[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                    footer2Row[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                    footer2Row[ct_col_Sort_DepositSlipNo] = 0;
                    footer2Row[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                    footer2Row[ct_col_Sort_DetailRowNo] = RowCount.ToString();
                    footer2Row[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                    #endregion

                    table.Rows.Add(footer2Row);
                }
            }

            int detailRowNo = salesWork.SALESDETAILRF_SALESROWNORF;
            DataRow spacefooter = table.NewRow();
            detailRowNo++;

            spacefooter["SALESSLIPRF.SALESDATERF"] = salesWork.SALESSLIPRF_SALESDATERF;
            spacefooter["SALESSLIPRF.SALESSLIPCDRF"] = salesWork.SALESSLIPRF_SALESSLIPCDRF;
            spacefooter["SALESDETAILRF.SALESMONEYTAXINCRF"] = salesWork.SALESDETAILRF_SALESMONEYTAXINCRF;
            spacefooter["SALESDETAILRF.SALESROWNORF"] = detailRowNo;//���s�ԍ�
            spacefooter["DADD.FOOTER3PRINTRF"] = 99; //����t�b�^�R�i���׍s����p�j
            RowCount = RowCount + 10;

            # region [�\�[�g�E���v�Ή�]
            spacefooter[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
            spacefooter[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
            spacefooter[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
            spacefooter[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
            spacefooter[ct_col_Sort_DepositSlipNo] = 0;
            spacefooter[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
            spacefooter[ct_col_Sort_DetailRowNo] = RowCount.ToString();
            spacefooter[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
            # endregion

            table.Rows.Add(spacefooter);
        }

        /// <summary>
        /// ����w�b�_�Q  ���㖾�ׁ@�E�v����(�R������ʑΉ�)
        /// </summary>
        /// <param name="table">�e�[�u��</param>
        /// <param name="salesWork">����f�[�^</param>
        /// <param name="allDefSet">���|�[�g���</param>
        /// <param name="headWork">�w�b�_�[���</param>
        /// <param name="detailRowCount">���א�</param>
        /// <param name="row">�s�f�[�^</param>
        /// <param name="sortDetail">�\�[�g�t���O</param>
        /// <remarks>
        /// <br>Note        : ����w�b�_�Q  ���㖾�ׁ@�E�v����(�R������ʑΉ�)</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSalesHeader2(ref DataTable table, EBooksFrePBillDetailWork salesWork, EBooksFrePBillHeadWork headWork, bool sortDetail, DataRow row, AllDefSetWork allDefSet, int detailRowCount)
        {

            DataRow headerRow = table.NewRow();

            //���t�W�J�i�ʏ�j(����w�b�_�p)
            ExtractDate(ref headerRow, allDefSet.EraNameDispCd1, salesWork.SALESSLIPRF_SALESDATERF, "DADD.SALESDATEHD2", false);// yyyymmdd

            headerRow["DADD.FULLMODELHD2RF"] = "�i�^���j" + GetFullModel(salesWork); //�^��(����w�b�_�Q)
            headerRow["DADD.MODELHALFNAMEHD2RF"] = "�i�Ԗ��j" + salesWork.ACCEPTODRCARRF_MODELHALFNAMERF;//�Ԏ햼(����w�b�_�Q)
            if (string.IsNullOrEmpty(salesWork.ACCEPTODRCARRF_MODELHALFNAMERF))
            {
                headerRow["DADD.MODELHALFNAMEHD2RF"] = "�i�Ԗ��j" + GetKanaString(salesWork.ACCEPTODRCARRF_MODELFULLNAMERF);
            }
            headerRow["DADD.SALESSLIPNUMHD2RF"] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;//����`�[�ԍ�

            if (ReportItemDic.ContainsKey("DADD.HEADFULLMODEL2RF"))
            {
                if (detailRowCount == 1)
                {
                    headerRow["DADD.HEADFULLMODEL2RF"] = salesWork.ACCEPTODRCARRF_FULLMODELRF;
                }
                else
                {
                    headerRow["DADD.HEADFULLMODEL2RF"] = DBNull.Value;
                    return;
                }
            }

            //����`�[�敪�R�[�h
            switch (salesWork.SALESSLIPRF_SALESSLIPCDRF)
            {
                case 0:
                    //����
                    headerRow["DADD.SALESSLIPCDCHANGERF"] = 01;
                    break;
                case 1:
                    //�ԕi
                    headerRow["DADD.SALESSLIPCDCHANGERF"] = 02;
                    break;
            }
            headerRow["CUSTDMDPRCRF.CUSTOMERCODERF"] = headWork.CUSTDMDPRCRF_CUSTOMERCODERF;


            if (sortDetail)
            {
                //���ׂ̓r���ň󎚂���̂ō폜
                headerRow["DADD.SALESSLIPNUMHD2RF"] = DBNull.Value;
                headerRow["DADD.SALESSLIPCDCHANGERF"] = DBNull.Value;
                headerRow["DADD.SALESDATEHD2FMRF"] = DBNull.Value;
                headerRow["DADD.SALESDATEHD2FDRF"] = DBNull.Value;
                headerRow["DADD.SALESDATEHD2FLPRF"] = DBNull.Value;
                headerRow["DADD.FOOTER3PRINTRF"] = 0;

                headerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                headerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                headerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                headerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                headerRow[ct_col_Sort_DepositSlipNo] = 0;
                headerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                headerRow[ct_col_Sort_DetailRowNo] = salesWork.SALESDETAILRF_SALESROWNORF * 10 - 5;
                headerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
            }
            else
            {
                headerRow["DADD.FOOTER3PRINTRF"] = 0;

                headerRow[ct_col_Sort_CustomerCode] = salesWork.SALESSLIPRF_CUSTOMERCODERF;
                headerRow[ct_col_Sort_Date] = salesWork.SALESSLIPRF_SALESDATERF;
                headerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                headerRow[ct_col_Sort_SalesSlipNo] = salesWork.SALESSLIPRF_SALESSLIPNUMRF;
                headerRow[ct_col_Sort_DepositSlipNo] = 0;
                headerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Header;
                //headerRow[ct_col_Sort_DetailRowNo] = 0;
                headerRow[ct_col_Sort_DetailRowNo] = 0;
                headerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
            }

            table.Rows.Add(headerRow);
        }

        /// <summary>
        /// ����w�b�_�R�@���㖾�ׁ@�E�v�����E�y�[�W�ύX��P�s�ڗp(�R������ʑΉ�)
        /// </summary>
        /// <param name="headerRow">�w�b�_�[�s</param>
        /// <param name="row">�s�f�[�^</param>
        /// <param name="allDefSet">���|�[�g���</param>
        /// <param name="pageCount">�Ő�</param>
        /// <param name="rowCount">���א�</param>
        /// <remarks>
        /// <br>Note        : ����w�b�_�R�@���㖾�ׁ@�E�v�����E�y�[�W�ύX��P�s�ڗp(�R������ʑΉ�)</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectSalesHeader2NewPage(ref DataRow headerRow, DataRow row, AllDefSetWork allDefSet, Int32 pageCount, Int32 rowCount)
        {
            headerRow["DADD.FULLMODELHD2RF"] = "�i�^���j" + row["DADD.FULLMODELHD2SEARCHRF"];
            headerRow["DADD.MODELHALFNAMEHD2RF"] = "�i�Ԗ��j" + row["DADD.MODELHALFNAMEHD2SEARCHRF"];
            headerRow["DADD.SALESSLIPNUMHD2RF"] = row[ct_col_Sort_SalesSlipNo];
            headerRow["CUSTDMDPRCRF.CUSTOMERCODERF"] = row[ct_col_Sort_CustomerCode];
            headerRow["DADD.SALESDATEHD2FMRF"] = row["DADD.SALESDATEHD2SEARCHFMRF"];
            headerRow["DADD.SALESDATEHD2FDRF"] = row["DADD.SALESDATEHD2SEARCHFDRF"];
            headerRow["DADD.SALESDATEHD2FLPRF"] = row["DADD.SALESDATEHD2SEARCHFLPRF"];
            headerRow["DADD.SALESSLIPCDCHANGERF"] = row["DADD.SALESSLIPCDCHANGESEARCHRF"];

                headerRow[ct_col_Sort_CustomerCode] = row[ct_col_Sort_CustomerCode];
                headerRow[ct_col_Sort_Date] = row[ct_col_Sort_Date];
                headerRow[ct_col_Sort_RecordDiv] = SortRecordDivState.Sales;
                headerRow[ct_col_Sort_SalesSlipNo] = row[ct_col_Sort_SalesSlipNo];
                headerRow[ct_col_Sort_DepositSlipNo] = 0;
                headerRow[ct_col_Sort_DetailDiv] = SortDetailDivState.Detail;
                headerRow[ct_col_Sort_DetailRowNo] = rowCount.ToString();
                headerRow[ct_col_Sort_RecordDiv_EmptyDetail] = SortRecordDiv_EmptyDetailState.Sales;
                headerRow[ct_col_PageCount] = pageCount;
        }

        /// <summary>
        /// ����F���̑��̍s�@�ǉ�����
        /// </summary>
        /// <param name="prevDetailWork">�X�V�����׃f�[�^</param>
        /// <param name="otherDepositPrice">����</param>
        /// <returns>�������׃��[�N</returns>
        /// <remarks>
        /// <br>Note        : ����F���̑��̍s�@�ǉ�����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static EBooksFrePBillDetailWork AddOtherDeposit(EBooksFrePBillDetailWork prevDetailWork, Int64 otherDepositPrice)
        {
            EBooksFrePBillDetailWork addWork = new EBooksFrePBillDetailWork();

            addWork.DEPSITMAINRF_ACPTANODRSTATUSRF = prevDetailWork.DEPSITMAINRF_ACPTANODRSTATUSRF;
            addWork.DEPSITMAINRF_ACPTANODRSTATUSRF = prevDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
            addWork.DEPSITMAINRF_SALESSLIPNUMRF = prevDetailWork.DEPSITMAINRF_SALESSLIPNUMRF;
            addWork.DEPSITMAINRF_ADDUPSECCODERF = prevDetailWork.DEPSITMAINRF_ADDUPSECCODERF;
            addWork.DEPSITMAINRF_SUBSECTIONCODERF = prevDetailWork.DEPSITMAINRF_SUBSECTIONCODERF;
            addWork.DEPSITMAINRF_DEPOSITDATERF = prevDetailWork.DEPSITMAINRF_DEPOSITDATERF;
            addWork.DEPSITMAINRF_ADDUPADATERF = prevDetailWork.DEPSITMAINRF_ADDUPADATERF;
            addWork.DEPSITMAINRF_DEPOSITRF = prevDetailWork.DEPSITMAINRF_DEPOSITRF;
            addWork.DEPSITMAINRF_FEEDEPOSITRF = 0;
            addWork.DEPSITMAINRF_DISCOUNTDEPOSITRF = prevDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
            addWork.DEPSITMAINRF_AUTODEPOSITCDRF = prevDetailWork.DEPSITMAINRF_AUTODEPOSITCDRF;
            addWork.DEPSITMAINRF_DEPOSITCDRF = prevDetailWork.DEPSITMAINRF_DEPOSITCDRF;
            addWork.DEPSITMAINRF_DRAFTDRAWINGDATERF = prevDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF;
            addWork.DEPSITMAINRF_DRAFTKINDRF = prevDetailWork.DEPSITMAINRF_DRAFTKINDRF;
            addWork.DEPSITMAINRF_DRAFTKINDNAMERF = prevDetailWork.DEPSITMAINRF_DRAFTKINDNAMERF;
            addWork.DEPSITMAINRF_DRAFTDIVIDENAMERF = prevDetailWork.DEPSITMAINRF_DRAFTDIVIDENAMERF;
            addWork.DEPSITMAINRF_DRAFTNORF = prevDetailWork.DEPSITMAINRF_DRAFTNORF;
            addWork.DEPSITMAINRF_CUSTOMERCODERF = prevDetailWork.DEPSITMAINRF_CUSTOMERCODERF;
            addWork.DEPSITMAINRF_CLAIMCODERF = prevDetailWork.DEPSITMAINRF_CLAIMCODERF;
            addWork.DEPSITMAINRF_OUTLINERF = prevDetailWork.DEPSITMAINRF_OUTLINERF;
            addWork.SUBDEP_SUBSECTIONNAMERF = prevDetailWork.SUBDEP_SUBSECTIONNAMERF;
            addWork.DEPSITMAINRF_DEPOSITSLIPNORF = prevDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF;
            addWork.DEPSITDTLRF_MONEYKINDNAMERF = "���̑�";
            addWork.DEPSITDTLRF_MONEYKINDDIVRF = prevDetailWork.DEPSITDTLRF_MONEYKINDDIVRF;
            addWork.DEPSITDTLRF_VALIDITYTERMRF = prevDetailWork.DEPSITDTLRF_VALIDITYTERMRF;
            addWork.DEPSITDTLRF_DEPOSITRF = otherDepositPrice;
            addWork.DEPSITDTLRF_DEPOSITROWNORF = 7;
            addWork.DEPSITDTLRF_MONEYKINDCODERF = 58;
            addWork.DEPSITMAINRF_CUSTOMERCODERF = prevDetailWork.DEPSITMAINRF_CUSTOMERCODERF;

            return addWork;
        }
        #endregion
        /// <summary>
        /// �������w�b�_�R�s�[�K�p����
        /// </summary>
        /// <param name="row">�Ώۍs</param>
        /// <param name="headWork">�w�b�_�[���</param>
        /// <param name="dmdPrtPtnWork">�������</param>
        /// <param name="frePrtPSetWork">���|�[�g���</param>
        /// <param name="billAllStWork">�S�̐ݒ�</param>
        /// <param name="billPrtStWork">����ݒ�</param>
        /// <param name="allDefSet">�S�̏����\���ݒ�</param>
        /// <param name="printPrice">���i����敪</param>
        /// <param name="taxTitle">�ŗ��^�C�g��</param>
        /// <param name="ofsThisSalesTaxIncTtl">���v���z(�ō�)�^�C�g��</param>
        /// <param name="pageTtlList">�y�[�W�^�C�g��</param>
        /// <param name="TotalTaxRateSalesMoney">�ŗ��ʍ��v���z</param>
        /// <param name="dTaxRate1">�ŗ�1</param>
        /// <param name="dTaxRate2">��2</param>
        /// <remarks>
        /// <br>Note        : �������w�b�_�R�s�[�K�p����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// </remarks>
        //private static void ReflectBillHeader(ref DataRow row, EBooksFrePBillHeadWork headWork, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, AllDefSetWork allDefSet, bool printPrice, string taxTitle, string ofsThisSalesTaxIncTtl, Dictionary<int, Int64> pageTtlList) // DEL �c������ 2022/10/18
        private static void ReflectBillHeader(ref DataRow row, EBooksFrePBillHeadWork headWork, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, AllDefSetWork allDefSet, bool printPrice, string taxTitle, string ofsThisSalesTaxIncTtl, Dictionary<int, Int64> pageTtlList, TaxRateSalesMoney TotalTaxRateSalesMoney, Double dTaxRate1, Double dTaxRate2) // ADD �c������ 2022/10/18
        {
            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");   // 2010/10/05 Add
            // �e�q����
            bool isParent = (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0);

            # region [�������w�b�_]
            row["CUSTDMDPRCRF.ADDUPSECCODERF"] = headWork.CUSTDMDPRCRF_ADDUPSECCODERF;
            row["CUSTDMDPRCRF.CLAIMCODERF"] = headWork.CUSTDMDPRCRF_CLAIMCODERF;
            row["CUSTDMDPRCRF.CLAIMNAMERF"] = headWork.CUSTDMDPRCRF_CLAIMNAMERF;
            row["CUSTDMDPRCRF.CLAIMNAME2RF"] = headWork.CUSTDMDPRCRF_CLAIMNAME2RF;
            row["CUSTDMDPRCRF.CLAIMSNMRF"] = headWork.CUSTDMDPRCRF_CLAIMSNMRF;
            row["CUSTDMDPRCRF.CUSTOMERCODERF"] = headWork.CUSTDMDPRCRF_CUSTOMERCODERF;
            row["CUSTDMDPRCRF.CUSTOMERNAMERF"] = headWork.CUSTDMDPRCRF_CUSTOMERNAMERF;
            row["CUSTDMDPRCRF.CUSTOMERNAME2RF"] = headWork.CUSTDMDPRCRF_CUSTOMERNAME2RF;
            row["CUSTDMDPRCRF.CUSTOMERSNMRF"] = headWork.CUSTDMDPRCRF_CUSTOMERSNMRF;
            row["CUSTDMDPRCRF.ADDUPDATERF"] = headWork.CUSTDMDPRCRF_ADDUPDATERF;
            row["CUSTDMDPRCRF.ADDUPYEARMONTHRF"] = headWork.CUSTDMDPRCRF_ADDUPYEARMONTHRF;
            row["CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF"] = headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;
            row["CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF"] = headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF;
            row["CUSTDMDPRCRF.THISTIMEDMDNRMLRF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
            row["CUSTDMDPRCRF.THISTIMETTLBLCDMDRF"] = headWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF;
            row["CUSTDMDPRCRF.OFSTHISTIMESALESRF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;
            row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF;
            row["CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF"] = headWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF;
            row["CUSTDMDPRCRF.ITDEDOFFSETINTAXRF"] = headWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF;
            row["CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF"] = headWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF;
            row["CUSTDMDPRCRF.OFFSETOUTTAXRF"] = headWork.CUSTDMDPRCRF_OFFSETOUTTAXRF;
            row["CUSTDMDPRCRF.OFFSETINTAXRF"] = headWork.CUSTDMDPRCRF_OFFSETINTAXRF;
            row["CUSTDMDPRCRF.THISTIMESALESRF"] = headWork.CUSTDMDPRCRF_THISTIMESALESRF;
            row["CUSTDMDPRCRF.THISSALESTAXRF"] = headWork.CUSTDMDPRCRF_THISSALESTAXRF;
            row["CUSTDMDPRCRF.ITDEDSALESOUTTAXRF"] = headWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF;
            row["CUSTDMDPRCRF.ITDEDSALESINTAXRF"] = headWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF;
            row["CUSTDMDPRCRF.ITDEDSALESTAXFREERF"] = headWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF;
            row["CUSTDMDPRCRF.SALESOUTTAXRF"] = headWork.CUSTDMDPRCRF_SALESOUTTAXRF;
            row["CUSTDMDPRCRF.SALESINTAXRF"] = headWork.CUSTDMDPRCRF_SALESINTAXRF;
            row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = headWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF;
            row["CUSTDMDPRCRF.TTLITDEDRETOUTTAXRF"] = headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF;
            row["CUSTDMDPRCRF.TTLITDEDRETINTAXRF"] = headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF;
            row["CUSTDMDPRCRF.TTLITDEDRETTAXFREERF"] = headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF;
            row["CUSTDMDPRCRF.TTLRETOUTERTAXRF"] = headWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF;
            row["CUSTDMDPRCRF.TTLRETINNERTAXRF"] = headWork.CUSTDMDPRCRF_TTLRETINNERTAXRF;
            row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = headWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF;
            row["CUSTDMDPRCRF.TTLITDEDDISOUTTAXRF"] = headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF;
            row["CUSTDMDPRCRF.TTLITDEDDISINTAXRF"] = headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF;
            row["CUSTDMDPRCRF.TTLITDEDDISTAXFREERF"] = headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF;
            row["CUSTDMDPRCRF.TTLDISOUTERTAXRF"] = headWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF;
            row["CUSTDMDPRCRF.TTLDISINNERTAXRF"] = headWork.CUSTDMDPRCRF_TTLDISINNERTAXRF;
            row["CUSTDMDPRCRF.TAXADJUSTRF"] = headWork.CUSTDMDPRCRF_TAXADJUSTRF;
            row["CUSTDMDPRCRF.BALANCEADJUSTRF"] = headWork.CUSTDMDPRCRF_BALANCEADJUSTRF;
            row["CUSTDMDPRCRF.AFCALDEMANDPRICERF"] = headWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF;
            row["CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF"] = headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF;
            row["CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF"] = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF;
            row["CUSTDMDPRCRF.STARTCADDUPUPDDATERF"] = headWork.CUSTDMDPRCRF_STARTCADDUPUPDDATERF;
            row["CUSTDMDPRCRF.SALESSLIPCOUNTRF"] = headWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF;
            row["CUSTDMDPRCRF.BILLPRINTDATERF"] = headWork.CUSTDMDPRCRF_BILLPRINTDATERF;
            row["CUSTDMDPRCRF.EXPECTEDDEPOSITDATERF"] = headWork.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF;
            row["CUSTDMDPRCRF.COLLECTCONDRF"] = headWork.CUSTDMDPRCRF_COLLECTCONDRF;
            row["CUSTDMDPRCRF.CONSTAXLAYMETHODRF"] = headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF;
            row["CUSTDMDPRCRF.CONSTAXRATERF"] = headWork.CUSTDMDPRCRF_CONSTAXRATERF;
            row["SECHED.SECTIONGUIDENMRF"] = headWork.SECHED_SECTIONGUIDENMRF;
            row["SECHED.SECTIONGUIDESNMRF"] = headWork.SECHED_SECTIONGUIDESNMRF;
            row["SECHED.COMPANYNAMECD1RF"] = headWork.SECHED_COMPANYNAMECD1RF;
            row["COMPANYNMRF.COMPANYPRRF"] = headWork.COMPANYNMRF_COMPANYPRRF;
            row["COMPANYNMRF.COMPANYNAME1RF"] = headWork.COMPANYNMRF_COMPANYNAME1RF;
            row["COMPANYNMRF.COMPANYNAME2RF"] = headWork.COMPANYNMRF_COMPANYNAME2RF;
            row["COMPANYNMRF.POSTNORF"] = headWork.COMPANYNMRF_POSTNORF;
            row["COMPANYNMRF.ADDRESS1RF"] = headWork.COMPANYNMRF_ADDRESS1RF;
            row["COMPANYNMRF.ADDRESS3RF"] = headWork.COMPANYNMRF_ADDRESS3RF;
            row["COMPANYNMRF.ADDRESS4RF"] = headWork.COMPANYNMRF_ADDRESS4RF;
            row["COMPANYNMRF.COMPANYTELNO1RF"] = headWork.COMPANYNMRF_COMPANYTELNO1RF;
            row["COMPANYNMRF.COMPANYTELNO2RF"] = headWork.COMPANYNMRF_COMPANYTELNO2RF;
            row["COMPANYNMRF.COMPANYTELNO3RF"] = headWork.COMPANYNMRF_COMPANYTELNO3RF;
            row["COMPANYNMRF.COMPANYTELTITLE1RF"] = headWork.COMPANYNMRF_COMPANYTELTITLE1RF;
            row["COMPANYNMRF.COMPANYTELTITLE2RF"] = headWork.COMPANYNMRF_COMPANYTELTITLE2RF;
            row["COMPANYNMRF.COMPANYTELTITLE3RF"] = headWork.COMPANYNMRF_COMPANYTELTITLE3RF;
            row["COMPANYNMRF.TRANSFERGUIDANCERF"] = headWork.COMPANYNMRF_TRANSFERGUIDANCERF;
            row["COMPANYNMRF.ACCOUNTNOINFO1RF"] = headWork.COMPANYNMRF_ACCOUNTNOINFO1RF;
            row["COMPANYNMRF.ACCOUNTNOINFO2RF"] = headWork.COMPANYNMRF_ACCOUNTNOINFO2RF;
            row["COMPANYNMRF.ACCOUNTNOINFO3RF"] = headWork.COMPANYNMRF_ACCOUNTNOINFO3RF;
            row["COMPANYNMRF.COMPANYSETNOTE1RF"] = headWork.COMPANYNMRF_COMPANYSETNOTE1RF;
            row["COMPANYNMRF.COMPANYSETNOTE2RF"] = headWork.COMPANYNMRF_COMPANYSETNOTE2RF;
            row["COMPANYNMRF.IMAGEINFOCODERF"] = headWork.COMPANYNMRF_IMAGEINFOCODERF;
            row["COMPANYNMRF.COMPANYURLRF"] = headWork.COMPANYNMRF_COMPANYURLRF;
            row["COMPANYNMRF.COMPANYPRSENTENCE2RF"] = headWork.COMPANYNMRF_COMPANYPRSENTENCE2RF;
            row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF;
            row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF;
            row["IMAGEINFORF.IMAGEINFODATARF"] = headWork.IMAGEINFORF_IMAGEINFODATARF;
            row["CSTCST.CUSTOMERSUBCODERF"] = headWork.CSTCST_CUSTOMERSUBCODERF;
            row["CSTCST.NAMERF"] = headWork.CSTCST_NAMERF;
            row["CSTCST.NAME2RF"] = headWork.CSTCST_NAME2RF;
            row["CSTCST.HONORIFICTITLERF"] = headWork.CSTCST_HONORIFICTITLERF;
            row["CSTCST.KANARF"] = headWork.CSTCST_KANARF;
            row["CSTCST.CUSTOMERSNMRF"] = headWork.CSTCST_CUSTOMERSNMRF;
            row["CSTCST.OUTPUTNAMECODERF"] = headWork.CSTCST_OUTPUTNAMECODERF;
            row["CSTCST.POSTNORF"] = headWork.CSTCST_POSTNORF;
            row["CSTCST.ADDRESS1RF"] = headWork.CSTCST_ADDRESS1RF;
            row["CSTCST.ADDRESS3RF"] = headWork.CSTCST_ADDRESS3RF;
            row["CSTCST.ADDRESS4RF"] = headWork.CSTCST_ADDRESS4RF;
            row["CSTCST.CUSTANALYSCODE1RF"] = headWork.CSTCST_CUSTANALYSCODE1RF;
            row["CSTCST.CUSTANALYSCODE2RF"] = headWork.CSTCST_CUSTANALYSCODE2RF;
            row["CSTCST.CUSTANALYSCODE3RF"] = headWork.CSTCST_CUSTANALYSCODE3RF;
            row["CSTCST.CUSTANALYSCODE4RF"] = headWork.CSTCST_CUSTANALYSCODE4RF;
            row["CSTCST.CUSTANALYSCODE5RF"] = headWork.CSTCST_CUSTANALYSCODE5RF;
            row["CSTCST.CUSTANALYSCODE6RF"] = headWork.CSTCST_CUSTANALYSCODE6RF;
            row["CSTCST.NOTE1RF"] = headWork.CSTCST_NOTE1RF;
            row["CSTCST.NOTE2RF"] = headWork.CSTCST_NOTE2RF;
            row["CSTCST.NOTE3RF"] = headWork.CSTCST_NOTE3RF;
            row["CSTCST.NOTE4RF"] = headWork.CSTCST_NOTE4RF;
            row["CSTCST.NOTE5RF"] = headWork.CSTCST_NOTE5RF;
            row["CSTCST.NOTE6RF"] = headWork.CSTCST_NOTE6RF;
            row["CSTCST.NOTE7RF"] = headWork.CSTCST_NOTE7RF;
            row["CSTCST.NOTE8RF"] = headWork.CSTCST_NOTE8RF;
            row["CSTCST.NOTE9RF"] = headWork.CSTCST_NOTE9RF;
            row["CSTCST.NOTE10RF"] = headWork.CSTCST_NOTE10RF;
            row["CSTCLM.CUSTOMERSUBCODERF"] = headWork.CSTCLM_CUSTOMERSUBCODERF;
            row["CSTCLM.NAMERF"] = headWork.CSTCLM_NAMERF;
            row["CSTCLM.NAME2RF"] = headWork.CSTCLM_NAME2RF;
            row["CSTCLM.HONORIFICTITLERF"] = headWork.CSTCLM_HONORIFICTITLERF;
            row["CSTCLM.KANARF"] = headWork.CSTCLM_KANARF;
            row["CSTCLM.CUSTOMERSNMRF"] = headWork.CSTCLM_CUSTOMERSNMRF;
            row["CSTCLM.OUTPUTNAMECODERF"] = headWork.CSTCLM_OUTPUTNAMECODERF;
            row["CSTCLM.POSTNORF"] = headWork.CSTCLM_POSTNORF;
            row["CSTCLM.ADDRESS1RF"] = headWork.CSTCLM_ADDRESS1RF;
            row["CSTCLM.ADDRESS3RF"] = headWork.CSTCLM_ADDRESS3RF;
            row["CSTCLM.ADDRESS4RF"] = headWork.CSTCLM_ADDRESS4RF;
            row["CSTCLM.CUSTANALYSCODE1RF"] = headWork.CSTCLM_CUSTANALYSCODE1RF;
            row["CSTCLM.CUSTANALYSCODE2RF"] = headWork.CSTCLM_CUSTANALYSCODE2RF;
            row["CSTCLM.CUSTANALYSCODE3RF"] = headWork.CSTCLM_CUSTANALYSCODE3RF;
            row["CSTCLM.CUSTANALYSCODE4RF"] = headWork.CSTCLM_CUSTANALYSCODE4RF;
            row["CSTCLM.CUSTANALYSCODE5RF"] = headWork.CSTCLM_CUSTANALYSCODE5RF;
            row["CSTCLM.CUSTANALYSCODE6RF"] = headWork.CSTCLM_CUSTANALYSCODE6RF;
            row["CSTCLM.NOTE1RF"] = headWork.CSTCLM_NOTE1RF;
            row["CSTCLM.NOTE2RF"] = headWork.CSTCLM_NOTE2RF;
            row["CSTCLM.NOTE3RF"] = headWork.CSTCLM_NOTE3RF;
            row["CSTCLM.NOTE4RF"] = headWork.CSTCLM_NOTE4RF;
            row["CSTCLM.NOTE5RF"] = headWork.CSTCLM_NOTE5RF;
            row["CSTCLM.NOTE6RF"] = headWork.CSTCLM_NOTE6RF;
            row["CSTCLM.NOTE7RF"] = headWork.CSTCLM_NOTE7RF;
            row["CSTCLM.NOTE8RF"] = headWork.CSTCLM_NOTE8RF;
            row["CSTCLM.NOTE9RF"] = headWork.CSTCLM_NOTE9RF;
            row["CSTCLM.NOTE10RF"] = headWork.CSTCLM_NOTE10RF;
# if DEBUG
            row["COMPANYINFRF.COMPANYNAME1RF"] = "��������������������";
            row["COMPANYINFRF.COMPANYNAME2RF"] = "��������������������";
            row["COMPANYINFRF.POSTNORF"] = "��������������������";
            row["COMPANYINFRF.ADDRESS1RF"] = "��������������������";
            row["COMPANYINFRF.ADDRESS3RF"] = "��������������������";
            row["COMPANYINFRF.ADDRESS4RF"] = "��������������������";
            row["COMPANYINFRF.COMPANYTELNO1RF"] = "��������������������";
            row["COMPANYINFRF.COMPANYTELNO2RF"] = "��������������������";
            row["COMPANYINFRF.COMPANYTELNO3RF"] = "��������������������";
            row["COMPANYINFRF.COMPANYTELTITLE1RF"] = "��������������������";
            row["COMPANYINFRF.COMPANYTELTITLE2RF"] = "��������������������";
            row["COMPANYINFRF.COMPANYTELTITLE3RF"] = "��������������������";
# endif
            row["DEPOSITSTRF.DEPOSITSTKINDCD1RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD1RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD2RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD2RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD3RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD3RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD4RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD4RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD5RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD5RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD6RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD6RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD7RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD7RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD8RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD8RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD9RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD9RF;
            row["DEPOSITSTRF.DEPOSITSTKINDCD10RF"] = headWork.DEPOSITSTRF_DEPOSITSTKINDCD10RF;
            row["DEPT01.MONEYKINDNAMERF"] = headWork.DEPT01_MONEYKINDNAMERF;
            row["DEPT01.DEPOSITRF"] = headWork.DEPT01_DEPOSITRF;
            row["DEPT02.MONEYKINDNAMERF"] = headWork.DEPT02_MONEYKINDNAMERF;
            row["DEPT02.DEPOSITRF"] = headWork.DEPT02_DEPOSITRF;
            row["DEPT03.MONEYKINDNAMERF"] = headWork.DEPT03_MONEYKINDNAMERF;
            row["DEPT03.DEPOSITRF"] = headWork.DEPT03_DEPOSITRF;
            row["DEPT04.MONEYKINDNAMERF"] = headWork.DEPT04_MONEYKINDNAMERF;
            row["DEPT04.DEPOSITRF"] = headWork.DEPT04_DEPOSITRF;
            row["DEPT05.MONEYKINDNAMERF"] = headWork.DEPT05_MONEYKINDNAMERF;
            row["DEPT05.DEPOSITRF"] = headWork.DEPT05_DEPOSITRF;
            row["DEPT06.MONEYKINDNAMERF"] = headWork.DEPT06_MONEYKINDNAMERF;
            row["DEPT06.DEPOSITRF"] = headWork.DEPT06_DEPOSITRF;
            row["DEPT07.MONEYKINDNAMERF"] = headWork.DEPT07_MONEYKINDNAMERF;
            row["DEPT07.DEPOSITRF"] = headWork.DEPT07_DEPOSITRF;
            row["DEPT08.MONEYKINDNAMERF"] = headWork.DEPT08_MONEYKINDNAMERF;
            row["DEPT08.DEPOSITRF"] = headWork.DEPT08_DEPOSITRF;
            row["DEPT09.MONEYKINDNAMERF"] = headWork.DEPT09_MONEYKINDNAMERF;
            row["DEPT09.DEPOSITRF"] = headWork.DEPT09_DEPOSITRF;
            row["DEPT10.MONEYKINDNAMERF"] = headWork.DEPT10_MONEYKINDNAMERF;
            row["DEPT10.DEPOSITRF"] = headWork.DEPT10_DEPOSITRF;
            row["HADD.ADDUPDATEFYRF"] = headWork.HADD_ADDUPDATEFYRF;
            row["HADD.ADDUPDATEFSRF"] = headWork.HADD_ADDUPDATEFSRF;
            row["HADD.ADDUPDATEFWRF"] = headWork.HADD_ADDUPDATEFWRF;
            row["HADD.ADDUPDATEFMRF"] = headWork.HADD_ADDUPDATEFMRF;
            row["HADD.ADDUPDATEFDRF"] = headWork.HADD_ADDUPDATEFDRF;
            row["HADD.ADDUPDATEFGRF"] = headWork.HADD_ADDUPDATEFGRF;
            row["HADD.ADDUPDATEFRRF"] = headWork.HADD_ADDUPDATEFRRF;
            row["HADD.ADDUPDATEFLSRF"] = headWork.HADD_ADDUPDATEFLSRF;
            row["HADD.ADDUPDATEFLPRF"] = headWork.HADD_ADDUPDATEFLPRF;
            row["HADD.ADDUPDATEFLYRF"] = headWork.HADD_ADDUPDATEFLYRF;
            row["HADD.ADDUPDATEFLMRF"] = headWork.HADD_ADDUPDATEFLMRF;
            row["HADD.ADDUPDATEFLDRF"] = headWork.HADD_ADDUPDATEFLDRF;
            row["HADD.ADDUPYEARMONTHFYRF"] = headWork.HADD_ADDUPYEARMONTHFYRF;
            row["HADD.ADDUPYEARMONTHFSRF"] = headWork.HADD_ADDUPYEARMONTHFSRF;
            row["HADD.ADDUPYEARMONTHFWRF"] = headWork.HADD_ADDUPYEARMONTHFWRF;
            row["HADD.ADDUPYEARMONTHFMRF"] = headWork.HADD_ADDUPYEARMONTHFMRF;
            row["HADD.ADDUPYEARMONTHFGRF"] = headWork.HADD_ADDUPYEARMONTHFGRF;
            row["HADD.ADDUPYEARMONTHFRRF"] = headWork.HADD_ADDUPYEARMONTHFRRF;
            row["HADD.ADDUPYEARMONTHFLSRF"] = headWork.HADD_ADDUPYEARMONTHFLSRF;
            row["HADD.ADDUPYEARMONTHFLPRF"] = headWork.HADD_ADDUPYEARMONTHFLPRF;
            row["HADD.ADDUPYEARMONTHFLYRF"] = headWork.HADD_ADDUPYEARMONTHFLYRF;
            row["HADD.ADDUPYEARMONTHFLMRF"] = headWork.HADD_ADDUPYEARMONTHFLMRF;
            row["HADD.STARTCADDUPUPDDATEFYRF"] = headWork.HADD_STARTCADDUPUPDDATEFYRF;
            row["HADD.STARTCADDUPUPDDATEFSRF"] = headWork.HADD_STARTCADDUPUPDDATEFSRF;
            row["HADD.STARTCADDUPUPDDATEFWRF"] = headWork.HADD_STARTCADDUPUPDDATEFWRF;
            row["HADD.STARTCADDUPUPDDATEFMRF"] = headWork.HADD_STARTCADDUPUPDDATEFMRF;
            row["HADD.STARTCADDUPUPDDATEFDRF"] = headWork.HADD_STARTCADDUPUPDDATEFDRF;
            row["HADD.STARTCADDUPUPDDATEFGRF"] = headWork.HADD_STARTCADDUPUPDDATEFGRF;
            row["HADD.STARTCADDUPUPDDATEFRRF"] = headWork.HADD_STARTCADDUPUPDDATEFRRF;
            row["HADD.STARTCADDUPUPDDATEFLSRF"] = headWork.HADD_STARTCADDUPUPDDATEFLSRF;
            row["HADD.STARTCADDUPUPDDATEFLPRF"] = headWork.HADD_STARTCADDUPUPDDATEFLPRF;
            row["HADD.STARTCADDUPUPDDATEFLYRF"] = headWork.HADD_STARTCADDUPUPDDATEFLYRF;
            row["HADD.STARTCADDUPUPDDATEFLMRF"] = headWork.HADD_STARTCADDUPUPDDATEFLMRF;
            row["HADD.STARTCADDUPUPDDATEFLDRF"] = headWork.HADD_STARTCADDUPUPDDATEFLDRF;
            row["HADD.BILLPRINTDATEFYRF"] = headWork.HADD_BILLPRINTDATEFYRF;
            row["HADD.BILLPRINTDATEFSRF"] = headWork.HADD_BILLPRINTDATEFSRF;
            row["HADD.BILLPRINTDATEFWRF"] = headWork.HADD_BILLPRINTDATEFWRF;
            row["HADD.BILLPRINTDATEFMRF"] = headWork.HADD_BILLPRINTDATEFMRF;
            row["HADD.BILLPRINTDATEFDRF"] = headWork.HADD_BILLPRINTDATEFDRF;
            row["HADD.BILLPRINTDATEFGRF"] = headWork.HADD_BILLPRINTDATEFGRF;
            row["HADD.BILLPRINTDATEFRRF"] = headWork.HADD_BILLPRINTDATEFRRF;
            row["HADD.BILLPRINTDATEFLSRF"] = headWork.HADD_BILLPRINTDATEFLSRF;
            row["HADD.BILLPRINTDATEFLPRF"] = headWork.HADD_BILLPRINTDATEFLPRF;
            row["HADD.BILLPRINTDATEFLYRF"] = headWork.HADD_BILLPRINTDATEFLYRF;
            row["HADD.BILLPRINTDATEFLMRF"] = headWork.HADD_BILLPRINTDATEFLMRF;
            row["HADD.BILLPRINTDATEFLDRF"] = headWork.HADD_BILLPRINTDATEFLDRF;
            row["HADD.EXPECTEDDEPOSITDATEFYRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFYRF;
            row["HADD.EXPECTEDDEPOSITDATEFSRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFSRF;
            row["HADD.EXPECTEDDEPOSITDATEFWRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFWRF;
            row["HADD.EXPECTEDDEPOSITDATEFMRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFMRF;
            row["HADD.EXPECTEDDEPOSITDATEFDRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFDRF;
            row["HADD.EXPECTEDDEPOSITDATEFGRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFGRF;
            row["HADD.EXPECTEDDEPOSITDATEFRRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFRRF;
            row["HADD.EXPECTEDDEPOSITDATEFLSRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLSRF;
            row["HADD.EXPECTEDDEPOSITDATEFLPRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLPRF;
            row["HADD.EXPECTEDDEPOSITDATEFLYRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLYRF;
            row["HADD.EXPECTEDDEPOSITDATEFLMRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLMRF;
            row["HADD.EXPECTEDDEPOSITDATEFLDRF"] = headWork.HADD_EXPECTEDDEPOSITDATEFLDRF;
            row["HADD.COLLECTCONDNMRF"] = headWork.HADD_COLLECTCONDNMRF;
            row["HADD.DMDFORMTITLERF"] = headWork.HADD_DMDFORMTITLERF;
            row["HADD.DMDFORMTITLE2RF"] = headWork.HADD_DMDFORMTITLE2RF;
            row["HADD.DMDFORMCOMENT1RF"] = headWork.HADD_DMDFORMCOMENT1RF;
            row["HADD.DMDFORMCOMENT2RF"] = headWork.HADD_DMDFORMCOMENT2RF;
            row["HADD.DMDFORMCOMENT3RF"] = headWork.HADD_DMDFORMCOMENT3RF;
            row["HADD.DMDNRMLEXDISRF"] = headWork.HADD_DMDNRMLEXDISRF;
            row["HADD.DMDNRMLEXFEERF"] = headWork.HADD_DMDNRMLEXFEERF;
            row["HADD.DMDNRMLEXDISFEERF"] = headWork.HADD_DMDNRMLEXDISFEERF;
            row["HADD.DMDNRMLSAMDISFEERF"] = headWork.HADD_DMDNRMLSAMDISFEERF;
            row["HADD.THISSALESANDADJUSTRF"] = headWork.HADD_THISSALESANDADJUSTRF;
            row["HADD.THISTAXANDADJUSTRF"] = headWork.HADD_THISTAXANDADJUSTRF;
            row["HADD.ISSUEDAYRF"] = headWork.HADD_ISSUEDAYRF; // ���͔��s���t
            row["HADD.ISSUEDAYFYRF"] = headWork.HADD_ISSUEDAYFYRF; // ���͔��s���t����N
            row["HADD.ISSUEDAYFSRF"] = headWork.HADD_ISSUEDAYFSRF; // ���͔��s���t����N��
            row["HADD.ISSUEDAYFWRF"] = headWork.HADD_ISSUEDAYFWRF; // ���͔��s���t�a��N
            row["HADD.ISSUEDAYFMRF"] = headWork.HADD_ISSUEDAYFMRF; // ���͔��s���t��
            row["HADD.ISSUEDAYFDRF"] = headWork.HADD_ISSUEDAYFDRF; // ���͔��s���t��
            row["HADD.ISSUEDAYFGRF"] = headWork.HADD_ISSUEDAYFGRF; // ���͔��s���t����
            row["HADD.ISSUEDAYFRRF"] = headWork.HADD_ISSUEDAYFRRF; // ���͔��s���t����
            row["HADD.ISSUEDAYFLSRF"] = headWork.HADD_ISSUEDAYFLSRF; // ���͔��s���t���e����(/)
            row["HADD.ISSUEDAYFLPRF"] = headWork.HADD_ISSUEDAYFLPRF; // ���͔��s���t���e����(.)
            row["HADD.ISSUEDAYFLYRF"] = headWork.HADD_ISSUEDAYFLYRF; // ���͔��s���t���e����(�N)
            row["HADD.ISSUEDAYFLMRF"] = headWork.HADD_ISSUEDAYFLMRF; // ���͔��s���t���e����(��)
            row["HADD.ISSUEDAYFLDRF"] = headWork.HADD_ISSUEDAYFLDRF; // ���͔��s���t���e����(��)
            row["CSTCST.HOMETELNORF"] = headWork.CSTCST_HOMETELNORF; // ���Ӑ�d�b�ԍ��i����j
            row["CSTCST.OFFICETELNORF"] = headWork.CSTCST_OFFICETELNORF; // ���Ӑ�d�b�ԍ��i�Ζ���j
            row["CSTCST.PORTABLETELNORF"] = headWork.CSTCST_PORTABLETELNORF; // ���Ӑ�d�b�ԍ��i�g�сj
            row["CSTCST.HOMEFAXNORF"] = headWork.CSTCST_HOMEFAXNORF; // ���Ӑ�FAX�ԍ��i����j
            row["CSTCST.OFFICEFAXNORF"] = headWork.CSTCST_OFFICEFAXNORF; // ���Ӑ�FAX�ԍ��i�Ζ���j
            row["CSTCST.OTHERSTELNORF"] = headWork.CSTCST_OTHERSTELNORF; // ���Ӑ�d�b�ԍ��i���̑��j
            row["CSTCLM.HOMETELNORF"] = headWork.CSTCLM_HOMETELNORF; // ������d�b�ԍ��i����j
            row["CSTCLM.OFFICETELNORF"] = headWork.CSTCLM_OFFICETELNORF; // ������d�b�ԍ��i�Ζ���j
            row["CSTCLM.PORTABLETELNORF"] = headWork.CSTCLM_PORTABLETELNORF; // ������d�b�ԍ��i�g�сj
            row["CSTCLM.HOMEFAXNORF"] = headWork.CSTCLM_HOMEFAXNORF; // ������FAX�ԍ��i����j
            row["CSTCLM.OFFICEFAXNORF"] = headWork.CSTCLM_OFFICEFAXNORF; // ������FAX�ԍ��i�Ζ���j
            row["CSTCLM.OTHERSTELNORF"] = headWork.CSTCLM_OTHERSTELNORF; // ������d�b�ԍ��i���̑��j
            row["ALITMDSPNMRF.HOMETELNODSPNAMERF"] = headWork.ALITMDSPNMRF_HOMETELNODSPNAMERF; // ����TEL�\������
            row["ALITMDSPNMRF.OFFICETELNODSPNAMERF"] = headWork.ALITMDSPNMRF_OFFICETELNODSPNAMERF; // �Ζ���TEL�\������
            row["ALITMDSPNMRF.MOBILETELNODSPNAMERF"] = headWork.ALITMDSPNMRF_MOBILETELNODSPNAMERF; // �g��TEL�\������
            row["ALITMDSPNMRF.HOMEFAXNODSPNAMERF"] = headWork.ALITMDSPNMRF_HOMEFAXNODSPNAMERF; // ����FAX�\������
            row["ALITMDSPNMRF.OFFICEFAXNODSPNAMERF"] = headWork.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF; // �Ζ���FAX�\������
            row["ALITMDSPNMRF.OTHERTELNODSPNAMERF"] = headWork.ALITMDSPNMRF_OTHERTELNODSPNAMERF; // ���̑�TEL�\������
            if (Convert.ToInt32(row["HADD.ISSUEDAYRF"]) < headWork.CSTCLM_CUSTAGENTCHGDATERF)
            {
                row["HADD.SALESEMPLOYEECDRF"] = headWork.CSTCLM_OLDCUSTOMERAGENTCDRF;    // �����Ӑ�S���҃R�[�h
            }
            else
            {
                row["HADD.SALESEMPLOYEECDRF"] = headWork.CSTCLM_CUSTOMERAGENTCDRF;    // ���Ӑ�S���҃R�[�h
            }

            if (ReportItemDic.ContainsKey("HADD.EXPECTEDDEPOSITMONEYRF"))
            {
                // �����\��z�̍��ڂ�����ꍇ�̂݌v�Z����B
                row["HADD.EXPECTEDDEPOSITMONEYRF"] = GetExpectedDepositMoney(headWork, billAllStWork);  // �����\��z
            }
            else
            {
                row["HADD.EXPECTEDDEPOSITMONEYRF"] = DBNull.Value;
            }
            DateTime calcCollectDay;
            calcCollectDay = CalcCollectDate(headWork);
            row["HADD.CALCEXPECTEDDEPOSITDATEFDRF"] = calcCollectDay.Day;
            row["HADD.CALCEXPECTEDDEPOSITDATEFMRF"] = calcCollectDay.Month;
            row["HADD.LASTPAGECOMMENTRF"] = "�ŏI��";
            row["HADD.TOTALTAXINCTITLERF"] = "�ō��v";    // �Ӑō��v�^�C�g��
            row["HADD.OFSTHISTIMESALESLASTPAGERF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;
            # endregion

            # region [�W����]
            // �W�����i����ɐ�����̏W�����Œu��������j
            row["CSTCST.COLLECTMONEYNAMERF"] = headWork.CSTCLM_COLLECTMONEYNAMERF; // ������W�����敪����
            row["CSTCST.COLLECTMONEYDAYRF"] = headWork.CSTCLM_COLLECTMONEYDAYRF; // ������W����
            if ( IsZero( headWork.CSTCLM_COLLECTMONEYDAYRF ) ) row["CSTCST.COLLECTMONEYDAYRF"] = DBNull.Value;
            # endregion

            # region [�Ӎ���(�����ȊO)]
            // �O�񐿋����z�i�ʏ�j���O��{�Q��O�{�R��O
            row["CUSTDMDPRCRF.LASTTIMEDEMANDRF"] = headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF
                                                   + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF
                                                   + headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF;
            // �O�񐿋����z�i�O��̂݁j���O��̂�
            row[ct_col_HDmd_LastTimeDemandOrg] = headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF;
            // ���񔄏�z(�ō�)
            row["HADD.THISSALESANDADJUSTTAXINCRF"] = headWork.HADD_THISSALESANDADJUSTRF 
                                                     + headWork.HADD_THISTAXANDADJUSTRF;
            
            // ���E�㔄����z(�ō�)
            row["HADD.OFSTHISSALESTAXINCRF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF 
                                             + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF;
            row["HADD.OFSTHISSALESTAXINC2RF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF
                                             + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF;
            // �]�ŕ�����9:��ې�
            if ( headWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF == 9 )
            {
                // ����ŁE�ō����z���󎚂��Ȃ�
                row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = DBNull.Value; // ���E�㍡�񔄏�����
                row["CUSTDMDPRCRF.THISSALESTAXRF"] = DBNull.Value; // ���񔄏�����
                row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = DBNull.Value; // ���񔄏�ԕi�����
                row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = DBNull.Value; // ���񔄏�l�������
                row["HADD.THISTAXANDADJUSTRF"] = DBNull.Value; // ���񔄏㒲������� 
                row["HADD.THISSALESANDADJUSTTAXINCRF"] = DBNull.Value; // ���񔄏�z(�ō�)
                row["HADD.OFSTHISSALESTAXINCRF"] = DBNull.Value;// ���E�㔄����z(�ō�)
                // ��ېł͏���ł��܂܂Ȃ�
                row["HADD.OFSTHISSALESTAXINC2RF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;
                row["HADD.TOTALTAXINCTITLERF"] = DBNull.Value;
            }

            // ����ԕi�l���z�i����ԕi�{����l���j��-1���|���ăv���X�ɂ���
            row[ct_col_ThisTimeRetDis] = -1 * (
                                                headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF // �ԕi�O�őΏ�
                                                + headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF // �ԕi���őΏ�
                                                + headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF // �ԕi��ېőΏ�
                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF // �l���O�őΏ�
                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF // �l�����őΏ�
                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF // �l����ېőΏ�
                                              );
            // �ԕi�̂݁i-1�����ăv���X�ɂ���j
            row["CUSTDMDPRCRF.THISSALESPRICRGDSRF"] = -1 * (
                                                                headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF // �ԕi�O�őΏ�
                                                                + headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF // �ԕi���őΏ�
                                                                + headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF // �ԕi��ېőΏ�
                                                            );
            // �l���̂݁i-1�����ăv���X�ɂ���j
            row["CUSTDMDPRCRF.THISSALESPRICDISRF"] = -1 * (
                                                                headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF // �l���O�őΏ�
                                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF // �l�����őΏ�
                                                                + headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF // �l����ېőΏ�
                                                            );
            // ����|�ԕi
            row["HADD.SALESANDRGDSRF"] = headWork.HADD_THISSALESANDADJUSTRF - (Int64)row["CUSTDMDPRCRF.THISSALESPRICRGDSRF"];
            // ����|�l��
            row["HADD.SALESANDDISRF"] = headWork.HADD_THISSALESANDADJUSTRF - (Int64)row["CUSTDMDPRCRF.THISSALESPRICDISRF"];

            // (�������v�f�B�N�V���i������)
            Dictionary<int, Int64> deptTotalDic = new Dictionary<int, long>();
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD1RF, headWork.DEPT01_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD2RF, headWork.DEPT02_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD3RF, headWork.DEPT03_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD4RF, headWork.DEPT04_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD5RF, headWork.DEPT05_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD6RF, headWork.DEPT06_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD7RF, headWork.DEPT07_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD8RF, headWork.DEPT08_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD9RF, headWork.DEPT09_DEPOSITRF );
            AddToDeptTotalDic( ref deptTotalDic, headWork.DEPOSITSTRF_DEPOSITSTKINDCD10RF, headWork.DEPT10_DEPOSITRF );

            // �f�B�N�V���i������̃Z�b�g����
            Int64 dept51 = GetFromDeptTotalDic( deptTotalDic, 51 ); // �������v�i�����j
            Int64 dept52 = GetFromDeptTotalDic( deptTotalDic, 52 ); // �������v�i�U���j
            Int64 dept53 = GetFromDeptTotalDic( deptTotalDic, 53 ); // �������v�i���؎�j
            Int64 dept54 = GetFromDeptTotalDic( deptTotalDic, 54 ); // �������v�i��`�j
            Int64 dept55 = headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF; // �������v�i�萔���j
            Int64 dept56 = GetFromDeptTotalDic( deptTotalDic, 56 ); // �������v�i���E�j
            Int64 dept57 = headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF; // �������v�i�l���j
            Int64 dept58 = GetFromDeptTotalDic( deptTotalDic, 58 ); // �������v�i���̑��j
            Int64 dept59 = GetFromDeptTotalDic( deptTotalDic, 59 ); // �������v�i�����U���j
            Int64 dept60 = GetFromDeptTotalDic( deptTotalDic, 60 ); // �������v�i�t�@�N�^�����O�j

            row["HADD.DEPTTOTALCASHRF"] = dept51; // �������v�i�����j
            row["HADD.DEPTTOTALTRANSFERRF"] = dept52; // �������v�i�U���j
            row["HADD.DEPTTOTALCHECKRF"] = dept53; // �������v�i���؎�j
            row["HADD.DEPTTOTALDRAFTRF"] = dept54; // �������v�i��`�j
            row["HADD.DEPTTOTALOFFSETRF"] = dept56; // �������v�i���E�j
            row["HADD.DEPTTOTALOTHERSRF"] = dept58; // �������v�i���̑��j
            row["HADD.DEPTTOTALACCOUNTRF"] = dept59; // �������v�i�����U���j
            row["HADD.DEPTTOTALFACTORINGRF"] = dept60; // �������v�i�t�@�N�^�����O�j

            // (���Z����)
            row["HADD.DEPTTOTALSUM1RF"] = dept55 + dept58; // �������v�i�萔���{���̑��j
            row["HADD.DEPTTOTALSUM2RF"] = dept57 + dept58; // �������v�i�l���{���̑��j
            row["HADD.DEPTTOTALSUM3RF"] = dept56 + dept58; // �������v�i���E�{���̑��j
            row["HADD.DEPTTOTALSUM4RF"] = dept55 + dept56 + dept58; // �������v�i�萔���{���E�{���̑��j
            row["HADD.DEPTTOTALSUM5RF"] = dept57 + dept55 + dept58; // �������v�i�l���{�萔���{���̑��j
            row["HADD.DEPTTOTALSUM6RF"] = dept57 + dept56 + dept58; // �������v�i�l���{���E�{���̑��j
            row["HADD.DEPTTOTALSUM7RF"] = dept55 + dept56 + dept57 + dept58; // �������v�i�萔���{���E�{�l���{���̑��j
            row["HADD.DEPTTOTALSUM8RF"] = dept51 + dept52 + dept53 + dept54; // �������v�i�����{�U���{���؎�{��`�j
            // (���Z���ڕ����������v)
            row["HADD.DEPTTOTALEXC1RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept55 + dept58); // �������v�i�萔���E���̑������j
            row["HADD.DEPTTOTALEXC2RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept57 + dept58); // �������v�i�l���E���̑������j
            row["HADD.DEPTTOTALEXC3RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept56 + dept58); // �������v�i���E�E���̑������j
            row["HADD.DEPTTOTALEXC4RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept55 + dept56 + dept58); // �������v�i�萔���E���E�E���̑������j
            row["HADD.DEPTTOTALEXC5RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept57 + dept55 + dept58); // �������v�i�l���E�萔���E���̑������j
            row["HADD.DEPTTOTALEXC6RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept57 + dept56 + dept58); // �������v�i�l���E���E�E���̑������j
            row["HADD.DEPTTOTALEXC7RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept55 + dept56 + dept57 + dept58); // �������v�i�萔���E���E�E�l���E���̑������j
            row["HADD.DEPTTOTALEXC8RF"] = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - (dept51 + dept52 + dept53 + dept54); // �������v�i�����E�U���E���؎�E��`�����j
            # endregion
            // --- ADD START �c������ 2022/10/18 ----->>>>>
            if ((ReportItemDic.ContainsKey("TAX.HFTOTALCONSTAXRATETITLERF") ||
                 ReportItemDic.ContainsKey("TAX.HFTOTALSALESMONEYTAXEXCRF") ||
                   ReportItemDic.ContainsKey("TAX.HFTAXRATE1RF") ||
                     ReportItemDic.ContainsKey("TAX.HFTAXRATE1SALESTAXEXCRF") ||
                       ReportItemDic.ContainsKey("TAX.DTLRTOTALCONSTAXRATETITLERF") ||
                         ReportItemDic.ContainsKey("TAX.DTLTOTALSALESMONEYTAXEXCRF") ||
                           ReportItemDic.ContainsKey("TAX.DTLTAXRATE1RF") ||
                             ReportItemDic.ContainsKey("TAX.DTLTAXRATE1SALESTAXEXCRF")))
            {
                if (TotalTaxRateSalesMoney != null)
                {
                    row["TAX.HFTOTALCONSTAXRATETITLERF"] = "*�� �v*";
                    // ���v���z=�ŗ��P���z + �ŗ��Q���z + ��ېŋ��z + ���̑����z
                    row["TAX.HFTOTALSALESMONEYTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate1SalesMoney + TotalTaxRateSalesMoney.TaxRate2SalesMoney + TotalTaxRateSalesMoney.TaxOutSalesMoney + TotalTaxRateSalesMoney.OtherSalesMoney;
                    // �ŗ��P
                    row["TAX.HFTAXRATE1RF"] = Convert.ToString(dTaxRate1 * 100) + "%";
                    row["TAX.HFTAXRATE1SALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate1SalesMoney;

                    // �ŗ��Q
                    row["TAX.HFTAXRATE2RF"] = Convert.ToString(dTaxRate2 * 100) + "%";
                    row["TAX.HFTAXRATE2SALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxRate2SalesMoney;

                    // ��ې�
                    row["TAX.HFTAXOUTITLERF"] = "��ې�";
                    row["TAX.HFTAXOUTSALESTAXEXCRF"] = TotalTaxRateSalesMoney.TaxOutSalesMoney;

                    // ���̑�
                    row["TAX.HFOTHERTAXRATERF"] = "���̑�";
                    row["TAX.HFOTHERTAXRATESALESTAXEXCRF"] = TotalTaxRateSalesMoney.OtherSalesMoney;

                    if (isParent)
                    {
                        row["TAX.HFTAXTITLERF"] = "��";
                        row["TAX.HFTAXRATE1SALESTAXRF"] = TotalTaxRateSalesMoney.TaxRate1SalesPriceConsTax;     // �ŗ��P�@�@�@����ŋ��z
                        row["TAX.HFTAXRATE2SALESTAXRF"] = TotalTaxRateSalesMoney.TaxRate2SalesPriceConsTax;     // �ŗ��Q�@�@�@����ŋ��z
                        row["TAX.HFOTHERTAXRATESALESTAXRF"] = TotalTaxRateSalesMoney.OtherSalesPriceConsTax;    // ���̑��ŗ��@����ŋ��z
                    }
                }
            }
            // --- ADD END   �c������ 2022/10/18 -----<<<<<

            // ����p���Ӑ���
            # region [����p���Ӑ���]
            if ( isParent )
            {
                // �W�v���R�[�h������������Z�b�g
                # region [�����斈�W�v]
                row["CADD.CUSTOMERCODERF"] = headWork.CUSTDMDPRCRF_CLAIMCODERF; // ������Ӑ�R�[�h
                row["CADD.CUSTOMERSUBCODERF"] = headWork.CSTCLM_CUSTOMERSUBCODERF; // ������Ӑ�T�u�R�[�h
                row["CADD.NAMERF"] = headWork.CSTCLM_NAMERF; // ������Ӑ於��
                row["CADD.NAME2RF"] = headWork.CSTCLM_NAME2RF; // ������Ӑ於��2
                row["CADD.HONORIFICTITLERF"] = headWork.CSTCLM_HONORIFICTITLERF; // ������Ӑ�h��
                row["CADD.HONORIFICTITLE2RF"] = headWork.CSTCLM_HONORIFICTITLERF; // ������Ӑ�h�́i�󎚈ʒu�ύX�p�j
                row["CADD.KANARF"] = headWork.CSTCLM_KANARF; // ������Ӑ�J�i
                row["CADD.CUSTOMERSNMRF"] = headWork.CSTCLM_CUSTOMERSNMRF; // ������Ӑ旪��
                row["CADD.OUTPUTNAMECODERF"] = headWork.CSTCLM_OUTPUTNAMECODERF; // ������Ӑ揔���R�[�h
                row["CADD.POSTNORF"] = headWork.CSTCLM_POSTNORF; // ������Ӑ�X�֔ԍ�
                row["CADD.ADDRESS1RF"] = headWork.CSTCLM_ADDRESS1RF; // ������Ӑ�Z��1�i�s���{���s��S�E�����E���j
                row["CADD.ADDRESS3RF"] = headWork.CSTCLM_ADDRESS3RF; // ������Ӑ�Z��3�i�Ԓn�j
                row["CADD.ADDRESS4RF"] = headWork.CSTCLM_ADDRESS4RF; // ������Ӑ�Z��4�i�A�p�[�g���́j
                row["CADD.ADDRESS123RF"] = headWork.CSTCLM_ADDRESS1RF + headWork.CSTCLM_ADDRESS3RF + headWork.CSTCLM_ADDRESS4RF; // ������Ӑ�Z��1+2+3
                row["CADD.CUSTANALYSCODE1RF"] = headWork.CSTCLM_CUSTANALYSCODE1RF; // ������Ӑ敪�̓R�[�h1
                row["CADD.CUSTANALYSCODE2RF"] = headWork.CSTCLM_CUSTANALYSCODE2RF; // ������Ӑ敪�̓R�[�h2
                row["CADD.CUSTANALYSCODE3RF"] = headWork.CSTCLM_CUSTANALYSCODE3RF; // ������Ӑ敪�̓R�[�h3
                row["CADD.CUSTANALYSCODE4RF"] = headWork.CSTCLM_CUSTANALYSCODE4RF; // ������Ӑ敪�̓R�[�h4
                row["CADD.CUSTANALYSCODE5RF"] = headWork.CSTCLM_CUSTANALYSCODE5RF; // ������Ӑ敪�̓R�[�h5
                row["CADD.CUSTANALYSCODE6RF"] = headWork.CSTCLM_CUSTANALYSCODE6RF; // ������Ӑ敪�̓R�[�h6
                row["CADD.NOTE1RF"] = headWork.CSTCLM_NOTE1RF; // ������Ӑ���l1
                row["CADD.NOTE2RF"] = headWork.CSTCLM_NOTE2RF; // ������Ӑ���l2
                row["CADD.NOTE3RF"] = headWork.CSTCLM_NOTE3RF; // ������Ӑ���l3
                row["CADD.NOTE4RF"] = headWork.CSTCLM_NOTE4RF; // ������Ӑ���l4
                row["CADD.NOTE5RF"] = headWork.CSTCLM_NOTE5RF; // ������Ӑ���l5
                row["CADD.NOTE6RF"] = headWork.CSTCLM_NOTE6RF; // ������Ӑ���l6
                row["CADD.NOTE7RF"] = headWork.CSTCLM_NOTE7RF; // ������Ӑ���l7
                row["CADD.NOTE8RF"] = headWork.CSTCLM_NOTE8RF; // ������Ӑ���l8
                row["CADD.NOTE9RF"] = headWork.CSTCLM_NOTE9RF; // ������Ӑ���l9
                row["CADD.NOTE10RF"] = headWork.CSTCLM_NOTE10RF; // ������Ӑ���l10

                // ����p���̏��
                if ( !string.IsNullOrEmpty( headWork.CSTCLM_NAME2RF ) )
                {
                    row["CADD.PRINTCUSTOMERNAME1RF"] = headWork.CSTCLM_NAMERF; // ����p���Ӑ於�́i��i�j
                    row["CADD.PRINTCUSTOMERNAME2RF"] = headWork.CSTCLM_NAME2RF; // ����p���Ӑ於�́i���i�j
                }
                else
                {
                    row["CADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value; // ����p���Ӑ於�́i��i�j
                    row["CADD.PRINTCUSTOMERNAME2RF"] = headWork.CSTCLM_NAMERF; // ����p���Ӑ於�́i���i�j
                }
                row["CADD.HOMETELNORF"] = headWork.CSTCLM_HOMETELNORF; // ������Ӑ�d�b�ԍ��i����j
                row["CADD.OFFICETELNORF"] = headWork.CSTCLM_OFFICETELNORF; // ������Ӑ�d�b�ԍ��i�Ζ���j
                row["CADD.PORTABLETELNORF"] = headWork.CSTCLM_PORTABLETELNORF; // ������Ӑ�d�b�ԍ��i�g�сj
                row["CADD.HOMEFAXNORF"] = headWork.CSTCLM_HOMEFAXNORF; // ������Ӑ�FAX�ԍ��i����j
                row["CADD.OFFICEFAXNORF"] = headWork.CSTCLM_OFFICEFAXNORF; // ������Ӑ�FAX�ԍ��i�Ζ���j
                row["CADD.OTHERSTELNORF"] = headWork.CSTCLM_OTHERSTELNORF; // ������Ӑ�d�b�ԍ��i���̑��j

                // ���Ӑ於�P�{���Ӑ於�Q
                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = headWork.CSTCLM_NAMERF + headWork.CSTCLM_NAME2RF;
                // ���Ӑ於�P�{���Ӑ於�Q�{�h��
                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = headWork.CSTCLM_NAMERF + headWork.CSTCLM_NAME2RF + "�@" + headWork.CSTCLM_HONORIFICTITLERF;

                //����p���Ӑ於�́i���i�j��10���܂Ŏ擾
                string printCustomerName2 = (string)row["CADD.PRINTCUSTOMERNAME2RF"];
                printCustomerName2 = printCustomerName2.PadRight(10, ' ');
                printCustomerName2 = printCustomerName2.Substring(0, 10).TrimEnd();

                //����p���Ӑ於�́i���i�j�{�󔒁{�h��
                row["CADD.PRINTCUSTOMERNAME2HNRF"] = printCustomerName2 + "  " + (string)row["CSTCST.HONORIFICTITLERF"];

                //����p���Ӑ於�̂Q��10���܂Ŏ擾
                string name2 = (string)row["CADD.NAME2RF"];
                name2 = name2.PadLeft(10, ' ');
                name2 = name2.Substring(0, 10).TrimEnd();

                //����p���Ӑ於�̂Q�{�󔒁{�h��
                row["CADD.NAME2HNRF"] = name2 + "  " + (string)row["CADD.HONORIFICTITLERF"];

                // ���Ӑ於�P�{���Ӑ於�Q�̌����ɂ���Čh�̂ƌh�̂P�̂ǂ�����󎚂��邩���䂷��
                // �h�̂P�����鎞�̂ݏ������s��
                if (ReportItemDic.ContainsKey("CADD.HONORIFICTITLE2RF"))
                {
                    int custNameNum = sjisEnc.GetByteCount(headWork.CSTCLM_NAMERF + headWork.CSTCLM_NAME2RF);
                    if (custNameNum > 20)
                    {
                        // �h�̂P����
                        row["CADD.HONORIFICTITLERF"] = DBNull.Value; // ������Ӑ�h��
                    }
                    else
                    {
                        // �h�̂���
                        row["CADD.HONORIFICTITLE2RF"] = DBNull.Value; // ������Ӑ�h�́i�󎚈ʒu�ύX�p�j
                    }
                }

                # endregion
            }
            else
            {
                // ���Ӑ斈�̃��R�[�h�����Ӑ�����Z�b�g
                # region [���Ӑ斈]
                row["CADD.CUSTOMERCODERF"] = headWork.CUSTDMDPRCRF_CUSTOMERCODERF; // ������Ӑ�R�[�h
                row["CADD.CUSTOMERSUBCODERF"] = headWork.CSTCST_CUSTOMERSUBCODERF; // ������Ӑ�T�u�R�[�h
                row["CADD.NAMERF"] = headWork.CSTCST_NAMERF; // ������Ӑ於��
                row["CADD.NAME2RF"] = headWork.CSTCST_NAME2RF; // ������Ӑ於��2
                row["CADD.HONORIFICTITLERF"] = headWork.CSTCST_HONORIFICTITLERF; // ������Ӑ�h��
                row["CADD.KANARF"] = headWork.CSTCST_KANARF; // ������Ӑ�J�i
                row["CADD.CUSTOMERSNMRF"] = headWork.CSTCST_CUSTOMERSNMRF; // ������Ӑ旪��
                row["CADD.OUTPUTNAMECODERF"] = headWork.CSTCST_OUTPUTNAMECODERF; // ������Ӑ揔���R�[�h
                row["CADD.POSTNORF"] = headWork.CSTCST_POSTNORF; // ������Ӑ�X�֔ԍ�
                row["CADD.ADDRESS1RF"] = headWork.CSTCST_ADDRESS1RF; // ������Ӑ�Z��1�i�s���{���s��S�E�����E���j
                row["CADD.ADDRESS3RF"] = headWork.CSTCST_ADDRESS3RF; // ������Ӑ�Z��3�i�Ԓn�j
                row["CADD.ADDRESS4RF"] = headWork.CSTCST_ADDRESS4RF; // ������Ӑ�Z��4�i�A�p�[�g���́j
                row["CADD.ADDRESS123RF"] = headWork.CSTCST_ADDRESS1RF + headWork.CSTCST_ADDRESS3RF + headWork.CSTCST_ADDRESS4RF; // ������Ӑ�Z��1+2+3
                row["CADD.CUSTANALYSCODE1RF"] = headWork.CSTCST_CUSTANALYSCODE1RF; // ������Ӑ敪�̓R�[�h1
                row["CADD.CUSTANALYSCODE2RF"] = headWork.CSTCST_CUSTANALYSCODE2RF; // ������Ӑ敪�̓R�[�h2
                row["CADD.CUSTANALYSCODE3RF"] = headWork.CSTCST_CUSTANALYSCODE3RF; // ������Ӑ敪�̓R�[�h3
                row["CADD.CUSTANALYSCODE4RF"] = headWork.CSTCST_CUSTANALYSCODE4RF; // ������Ӑ敪�̓R�[�h4
                row["CADD.CUSTANALYSCODE5RF"] = headWork.CSTCST_CUSTANALYSCODE5RF; // ������Ӑ敪�̓R�[�h5
                row["CADD.CUSTANALYSCODE6RF"] = headWork.CSTCST_CUSTANALYSCODE6RF; // ������Ӑ敪�̓R�[�h6
                row["CADD.NOTE1RF"] = headWork.CSTCST_NOTE1RF; // ������Ӑ���l1
                row["CADD.NOTE2RF"] = headWork.CSTCST_NOTE2RF; // ������Ӑ���l2
                row["CADD.NOTE3RF"] = headWork.CSTCST_NOTE3RF; // ������Ӑ���l3
                row["CADD.NOTE4RF"] = headWork.CSTCST_NOTE4RF; // ������Ӑ���l4
                row["CADD.NOTE5RF"] = headWork.CSTCST_NOTE5RF; // ������Ӑ���l5
                row["CADD.NOTE6RF"] = headWork.CSTCST_NOTE6RF; // ������Ӑ���l6
                row["CADD.NOTE7RF"] = headWork.CSTCST_NOTE7RF; // ������Ӑ���l7
                row["CADD.NOTE8RF"] = headWork.CSTCST_NOTE8RF; // ������Ӑ���l8
                row["CADD.NOTE9RF"] = headWork.CSTCST_NOTE9RF; // ������Ӑ���l9
                row["CADD.NOTE10RF"] = headWork.CSTCST_NOTE10RF; // ������Ӑ���l10

                // ����p���̏��
                if ( !string.IsNullOrEmpty( headWork.CSTCST_NAME2RF ) )
                {
                    row["CADD.PRINTCUSTOMERNAME1RF"] = headWork.CSTCST_NAMERF; // ����p���Ӑ於�́i��i�j
                    row["CADD.PRINTCUSTOMERNAME2RF"] = headWork.CSTCST_NAME2RF; // ����p���Ӑ於�́i���i�j
                }
                else
                {
                    row["CADD.PRINTCUSTOMERNAME1RF"] = DBNull.Value; // ����p���Ӑ於�́i��i�j
                    row["CADD.PRINTCUSTOMERNAME2RF"] = headWork.CSTCST_NAMERF; // ����p���Ӑ於�́i���i�j
                }
                row["CADD.HOMETELNORF"] = headWork.CSTCST_HOMETELNORF; // ������Ӑ�d�b�ԍ��i����j
                row["CADD.OFFICETELNORF"] = headWork.CSTCST_OFFICETELNORF; // ������Ӑ�d�b�ԍ��i�Ζ���j
                row["CADD.PORTABLETELNORF"] = headWork.CSTCST_PORTABLETELNORF; // ������Ӑ�d�b�ԍ��i�g�сj
                row["CADD.HOMEFAXNORF"] = headWork.CSTCST_HOMEFAXNORF; // ������Ӑ�FAX�ԍ��i����j
                row["CADD.OFFICEFAXNORF"] = headWork.CSTCST_OFFICEFAXNORF; // ������Ӑ�FAX�ԍ��i�Ζ���j
                row["CADD.OTHERSTELNORF"] = headWork.CSTCST_OTHERSTELNORF; // ������Ӑ�d�b�ԍ��i���̑��j

                // ���Ӑ於�P�{���Ӑ於�Q
                row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = headWork.CSTCST_NAMERF + headWork.CSTCST_NAME2RF;
                // ���Ӑ於�P�{���Ӑ於�Q�{�h��
                row["HADD.PRINTCUSTOMERNAMEJOIN12HNRF"] = headWork.CSTCST_NAMERF + headWork.CSTCST_NAME2RF + "�@" + headWork.CSTCST_HONORIFICTITLERF;
               
                //����p���Ӑ於�́i���i�j��10���܂Ŏ擾
                string printCustomerName2 = (string)row["CADD.PRINTCUSTOMERNAME2RF"];
                printCustomerName2 = printCustomerName2.PadRight(10, ' ');
                printCustomerName2 = printCustomerName2.Substring(0, 10).TrimEnd();

                //����p���Ӑ於�́i���i�j�{�󔒁{�h��
                row["CADD.PRINTCUSTOMERNAME2HNRF"] = printCustomerName2 + "  " + (string)row["CSTCST.HONORIFICTITLERF"];

                //����p���Ӑ於�̂Q��10���܂Ŏ擾
                string name2 = (string)row["CADD.NAME2RF"];
                name2 = name2.PadLeft(10, ' ');
                name2 = name2.Substring(0, 10).TrimEnd();

                //����p���Ӑ於�̂Q�{�󔒁{�h��
                row["CADD.NAME2HNRF"] = name2 + "  " + (string)row["CADD.HONORIFICTITLERF"];

                # endregion

                // �q�̂Ƃ���󎚂̌Œ�Ӎ���
                # region [�q�̂Ƃ���󎚂̊Ӎ���]
                row["CUSTDMDPRCRF.LASTTIMEDEMANDRF"] = DBNull.Value; // �O�񐿋����z
                row["CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF"] = DBNull.Value; // ����萔���z�i�ʏ�����j
                row["CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF"] = DBNull.Value; // ����l���z�i�ʏ�����j
                row["CUSTDMDPRCRF.THISTIMEDMDNRMLRF"] = DBNull.Value; // ����������z�i�ʏ�����j
                row["CUSTDMDPRCRF.THISTIMETTLBLCDMDRF"] = DBNull.Value; // ����J�z�c���i�����v�j
                row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = DBNull.Value; // ���E�㍡�񔄏�����
                row["CUSTDMDPRCRF.THISSALESTAXRF"] = DBNull.Value; // ���񔄏�����
                row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = DBNull.Value; // ���񔄏�ԕi�����
                row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = DBNull.Value; // ���񔄏�l�������
                row["CUSTDMDPRCRF.BALANCEADJUSTRF"] = DBNull.Value; // �c�������z
                row["CUSTDMDPRCRF.AFCALDEMANDPRICERF"] = DBNull.Value; // �v�Z�㐿�����z
                row["CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF"] = DBNull.Value; // ��2��O�c���i�����v�j
                row["CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF"] = DBNull.Value; // ��3��O�c���i�����v�j
                row["DEPT01.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��1
                row["DEPT01.DEPOSITRF"] = DBNull.Value; // �������z1
                row["DEPT02.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��2
                row["DEPT02.DEPOSITRF"] = DBNull.Value; // �������z2
                row["DEPT03.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��3
                row["DEPT03.DEPOSITRF"] = DBNull.Value; // �������z3
                row["DEPT04.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��4
                row["DEPT04.DEPOSITRF"] = DBNull.Value; // �������z4
                row["DEPT05.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��5
                row["DEPT05.DEPOSITRF"] = DBNull.Value; // �������z5
                row["DEPT06.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��6
                row["DEPT06.DEPOSITRF"] = DBNull.Value; // �������z6
                row["DEPT07.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��7
                row["DEPT07.DEPOSITRF"] = DBNull.Value; // �������z7
                row["DEPT08.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��8
                row["DEPT08.DEPOSITRF"] = DBNull.Value; // �������z8
                row["DEPT09.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��9
                row["DEPT09.DEPOSITRF"] = DBNull.Value; // �������z9
                row["DEPT10.MONEYKINDNAMERF"] = DBNull.Value; // �������햼��10
                row["DEPT10.DEPOSITRF"] = DBNull.Value; // �������z10
                row["HADD.DMDNRMLEXDISRF"] = DBNull.Value; // �������z(�l������)
                row["HADD.DMDNRMLEXFEERF"] = DBNull.Value; // �������z(�萔������)
                row["HADD.DMDNRMLEXDISFEERF"] = DBNull.Value; // �������z(�l���E�萔������)
                row["HADD.DMDNRMLSAMDISFEERF"] = DBNull.Value; // �������z(�l���{�萔��)
                row["HADD.THISTAXANDADJUSTRF"] = DBNull.Value; // ���񔄏�����
                row["HADD.THISSALESANDADJUSTTAXINCRF"] = DBNull.Value; // ���񔄏�z(�ō�)
                row["HADD.DEPTTOTALCASHRF"] = DBNull.Value; // �������v�i�����j
                row["HADD.DEPTTOTALTRANSFERRF"] = DBNull.Value; // �������v�i�U���j
                row["HADD.DEPTTOTALCHECKRF"] = DBNull.Value; // �������v�i���؎�j
                row["HADD.DEPTTOTALDRAFTRF"] = DBNull.Value; // �������v�i��`�j
                row["HADD.DEPTTOTALOFFSETRF"] = DBNull.Value; // �������v�i���E�j
                row["HADD.DEPTTOTALOTHERSRF"] = DBNull.Value; // �������v�i���̑��j
                row["HADD.DEPTTOTALACCOUNTRF"] = DBNull.Value; // �������v�i�����U���j
                row["HADD.DEPTTOTALFACTORINGRF"] = DBNull.Value; // �������v�i�t�@�N�^�����O�j
                row["HADD.DEPTTOTALSUM1RF"] = DBNull.Value; // �������v�i�萔���{���̑��j
                row["HADD.DEPTTOTALSUM2RF"] = DBNull.Value; // �������v�i�l���{���̑��j
                row["HADD.DEPTTOTALSUM3RF"] = DBNull.Value; // �������v�i���E�{���̑��j
                row["HADD.DEPTTOTALSUM4RF"] = DBNull.Value; // �������v�i�萔���{���E�{���̑��j
                row["HADD.DEPTTOTALSUM5RF"] = DBNull.Value; // �������v�i�l���{�萔���{���̑��j
                row["HADD.DEPTTOTALSUM6RF"] = DBNull.Value; // �������v�i�l���{���E�{���̑��j
                row["HADD.DEPTTOTALSUM7RF"] = DBNull.Value; // �������v�i�萔���{���E�{�l���{���̑��j
                row["HADD.DEPTTOTALSUM8RF"] = DBNull.Value; // �������v�i�����{�U���{���؎�{��`�j
                row["HADD.DEPTTOTALEXC1RF"] = DBNull.Value; // �������v�i�萔���E���̑������j
                row["HADD.DEPTTOTALEXC2RF"] = DBNull.Value; // �������v�i�l���E���̑������j
                row["HADD.DEPTTOTALEXC3RF"] = DBNull.Value; // �������v�i���E�E���̑������j
                row["HADD.DEPTTOTALEXC4RF"] = DBNull.Value; // �������v�i�萔���E���E�E���̑������j
                row["HADD.DEPTTOTALEXC5RF"] = DBNull.Value; // �������v�i�l���E�萔���E���̑������j
                row["HADD.DEPTTOTALEXC6RF"] = DBNull.Value; // �������v�i�l���E���E�E���̑������j
                row["HADD.DEPTTOTALEXC7RF"] = DBNull.Value; // �������v�i�萔���E���E�E�l���E���̑������j
                row["HADD.DEPTTOTALEXC8RF"] = DBNull.Value; // �������v�i�����E�U���E���؎�E��`�����j
                row["HADD.OFSTHISSALESTAXINCRF"] = DBNull.Value; // ���E�㔄����z(�ō�)
                // �q�͏���ł��܂܂Ȃ�
                row["HADD.OFSTHISSALESTAXINC2RF"] = headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;
                row["HADD.TOTALTAXINCTITLERF"] = DBNull.Value;
                # endregion
            }

            // ������Ӑ�Z��1+2+3���s����
            string ADDRESSEEADDR134RF = row["CADD.ADDRESS123RF"].ToString();
            string prtADDRESSEEADDR134RF = "";
            sjisEnc = Encoding.GetEncoding("Shift_JIS");
            int maxNum = sjisEnc.GetByteCount(ADDRESSEEADDR134RF);
            int nowNum = 0;
            int cutPoint = 0;
            string targetStr = "";
            if (maxNum > 40)
            {
                while (nowNum < 40)
                {
                    targetStr = ADDRESSEEADDR134RF.Substring(cutPoint, 1);
                    if (nowNum + sjisEnc.GetByteCount(targetStr) > 40)
                    {
                        break;
                    }
                    cutPoint++;
                    nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                }
                prtADDRESSEEADDR134RF = ADDRESSEEADDR134RF.Substring(0, cutPoint);
                if (sjisEnc.GetByteCount(prtADDRESSEEADDR134RF) < 40)
                {
                    prtADDRESSEEADDR134RF = prtADDRESSEEADDR134RF + " ";
                }
                ADDRESSEEADDR134RF = ADDRESSEEADDR134RF.Substring(cutPoint, ADDRESSEEADDR134RF.Length - cutPoint);

                maxNum = sjisEnc.GetByteCount(ADDRESSEEADDR134RF);
                if (maxNum > 40)
                {
                    nowNum = 0;
                    cutPoint = 0;
                    while (nowNum < 40)
                    {
                        targetStr = ADDRESSEEADDR134RF.Substring(cutPoint, 1);
                        if (nowNum + sjisEnc.GetByteCount(targetStr) > 40)
                        {
                            break;
                        }
                        cutPoint++;
                        nowNum = nowNum + sjisEnc.GetByteCount(targetStr);
                    }
                    prtADDRESSEEADDR134RF = prtADDRESSEEADDR134RF + ADDRESSEEADDR134RF.Substring(0, cutPoint);
                    if (sjisEnc.GetByteCount(prtADDRESSEEADDR134RF) < 80)
                    {
                        prtADDRESSEEADDR134RF = prtADDRESSEEADDR134RF + " ";
                    }
                }
                else
                {
                    prtADDRESSEEADDR134RF = prtADDRESSEEADDR134RF + ADDRESSEEADDR134RF;
                }
            }
            else
            {
                prtADDRESSEEADDR134RF = ADDRESSEEADDR134RF;
            }
            row["CADD.ADDRESS123RF"] = prtADDRESSEEADDR134RF;

            // ���Ӑ�P�{�Q�啶���p�������p�Ή�
            // �啶���p�E�������p���������Ă��鎞��������
            if (ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12LRF") && ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12BRF"))
            {
                sjisEnc = Encoding.GetEncoding("Shift_JIS");
                string custName = row["HADD.PrintCustomerNameJoin12RF"].ToString();
                int custNameCnt = sjisEnc.GetByteCount(custName);
                string postNo = row["CADD.POSTNORF"].ToString();
                string address1 = row["CADD.ADDRESS1RF"].ToString();
                string address3 = row["CADD.ADDRESS3RF"].ToString();
                string address4 = row["CADD.ADDRESS4RF"].ToString();
                if (custNameCnt <= 20)
                {
                    // 10�����ȉ��Ȃ�啶���p�ň�
                    row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value;   // ���Ӑ於�P�{���Ӑ於�Q
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LRF"] = DBNull.Value;  // ���Ӑ於�P�{���Ӑ於�Q�i�������p�j
                    row["HADD.PRINTCUSTOMERNAMEJOIN12BRF"] = custName;      // ���Ӑ於�P�{���Ӑ於�Q�i�啶���p�j
                    if (ReportItemDic.ContainsKey("CADD.POSTNOLRF") && ReportItemDic.ContainsKey("CADD.POSTNOBRF"))
                    {
                        // �X�֔ԍ��啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ėX�֔ԍ���啶���p�ň�
                        row["CADD.POSTNORF"] = DBNull.Value;   // ������Ӑ�X�֔ԍ�
                        row["CADD.POSTNOLRF"] = DBNull.Value;  // ������Ӑ�X�֔ԍ��i�������p�j
                        row["CADD.POSTNOBRF"] = postNo;        // ������Ӑ�X�֔ԍ��i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS1LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS1BRF"))
                    {
                        // ���Ӑ�Z���P�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���P��啶���p�ň�
                        row["CADD.ADDRESS1RF"] = DBNull.Value;   // ������Ӑ�Z��1�i�s���{���s��S�E�����E���j
                        row["CADD.ADDRESS1LRF"] = DBNull.Value;  // ������Ӑ�Z��1�i�������p�j
                        row["CADD.ADDRESS1BRF"] = address1;      // ������Ӑ�Z��1�i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS3LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS3BRF"))
                    {
                        // ���Ӑ�Z���R�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���R��啶���p�ň�
                        row["CADD.ADDRESS3RF"] = DBNull.Value;   // ������Ӑ�Z��3�i�Ԓn�j
                        row["CADD.ADDRESS3LRF"] = DBNull.Value;  // ������Ӑ�Z��3�i�������p�j
                        row["CADD.ADDRESS3BRF"] = address3;      // ������Ӑ�Z��3�i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS4LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS4BRF"))
                    {
                        // ���Ӑ�Z���S�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���S��啶���p�ň�
                        row["CADD.ADDRESS4RF"] = DBNull.Value;   // ������Ӑ�Z��4�i�A�p�[�g���́j
                        row["CADD.ADDRESS4LRF"] = DBNull.Value;  // ������Ӑ�Z��4�i�������p�j
                        row["CADD.ADDRESS4BRF"] = address4;      // ������Ӑ�Z��4�i�啶���p�j
                    }
                }
                else if (custNameCnt <= 30)
                {
                    // 15�����ȉ��Ȃ璆�����p�ň�
                    row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value;   // ���Ӑ於�P�{���Ӑ於�Q
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LRF"] = custName;      // ���Ӑ於�P�{���Ӑ於�Q�i�������p�j
                    row["HADD.PRINTCUSTOMERNAMEJOIN12BRF"] = DBNull.Value;  // ���Ӑ於�P�{���Ӑ於�Q�i�啶���p�j
                    if (ReportItemDic.ContainsKey("CADD.POSTNOLRF") && ReportItemDic.ContainsKey("CADD.POSTNOBRF"))
                    {
                        // �X�֔ԍ��啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ėX�֔ԍ��𒆕����p�ň�
                        row["CADD.POSTNORF"] = DBNull.Value;  // ������Ӑ�X�֔ԍ�
                        row["CADD.POSTNOLRF"] = postNo;       // ������Ӑ�X�֔ԍ��i�������p�j
                        row["CADD.POSTNOBRF"] = DBNull.Value; // ������Ӑ�X�֔ԍ��i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS1LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS1BRF"))
                    {
                        // ���Ӑ�Z���P�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���P�𒆕����p�ň�
                        row["CADD.ADDRESS1RF"] = DBNull.Value;   // ������Ӑ�Z��1�i�s���{���s��S�E�����E���j
                        row["CADD.ADDRESS1LRF"] = address1;      // ������Ӑ�Z��1�i�������p�j
                        row["CADD.ADDRESS1BRF"] = DBNull.Value;  // ������Ӑ�Z��1�i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS3LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS3BRF"))
                    {
                        // ���Ӑ�Z���R�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���P�𒆕����p�ň�
                        row["CADD.ADDRESS3RF"] = DBNull.Value;  // ������Ӑ�Z��3�i�Ԓn�j
                        row["CADD.ADDRESS3LRF"] = address3;     // ������Ӑ�Z��3�i�������p�j
                        row["CADD.ADDRESS3BRF"] = DBNull.Value; // ������Ӑ�Z��3�i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS4LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS4BRF"))
                    {
                        // ���Ӑ�Z���S�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���S�𒆕����p�ň�
                        row["CADD.ADDRESS4RF"] = DBNull.Value;  // ������Ӑ�Z��4�i�A�p�[�g���́j
                        row["CADD.ADDRESS4LRF"] = address4;     // ������Ӑ�Z��4�i�������p�j
                        row["CADD.ADDRESS4BRF"] = DBNull.Value; // ������Ӑ�Z��4�i�啶���p�j
                    }
                }
                else
                {
                    // 16�����ȏ�Ȃ�ʏ�T�C�Y�ň�
                    row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] = custName;       // ���Ӑ於�P�{���Ӑ於�Q
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LRF"] = DBNull.Value;  // ���Ӑ於�P�{���Ӑ於�Q�i�������p�j
                    row["HADD.PRINTCUSTOMERNAMEJOIN12BRF"] = DBNull.Value;  // ���Ӑ於�P�{���Ӑ於�Q�i�啶���p�j
                    if (ReportItemDic.ContainsKey("CADD.POSTNOLRF") && ReportItemDic.ContainsKey("CADD.POSTNOBRF"))
                    {
                        // �X�֔ԍ��啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ėX�֔ԍ���ʏ�T�C�Y�ň�
                        row["CADD.POSTNORF"] = postNo;         // ������Ӑ�X�֔ԍ�
                        row["CADD.POSTNOLRF"] = DBNull.Value;  // ������Ӑ�X�֔ԍ��i�������p�j
                        row["CADD.POSTNOBRF"] = DBNull.Value;  // ������Ӑ�X�֔ԍ��i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS1LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS1BRF"))
                    {
                        // ���Ӑ�Z���P�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���P��ʏ�T�C�Y�ň�
                        row["CADD.ADDRESS1RF"] = address1;      // ������Ӑ�Z��1�i�s���{���s��S�E�����E���j
                        row["CADD.ADDRESS1LRF"] = DBNull.Value; // ������Ӑ�Z��1�i�������p�j
                        row["CADD.ADDRESS1BRF"] = DBNull.Value; // ������Ӑ�Z��1�i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS3LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS3BRF"))
                    {
                        // ���Ӑ�Z���R�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���P��ʏ�T�C�Y�ň�
                        row["CADD.ADDRESS3RF"] = address3;      // ������Ӑ�Z��3�i�Ԓn�j
                        row["CADD.ADDRESS3LRF"] = DBNull.Value; // ������Ӑ�Z��3�i�������p�j
                        row["CADD.ADDRESS3BRF"] = DBNull.Value; // ������Ӑ�Z��3�i�啶���p�j
                    }
                    if (ReportItemDic.ContainsKey("CADD.ADDRESS4LRF") && ReportItemDic.ContainsKey("CADD.ADDRESS4BRF"))
                    {
                        // ���Ӑ�Z���S�啶���p�E�������p�������Ă���Ȃ�A���̂ɍ��킹�ē��Ӑ�Z���S��ʏ�T�C�Y�ň�
                        row["CADD.ADDRESS4RF"] = address4;      // ������Ӑ�Z��4�i�A�p�[�g���́j
                        row["CADD.ADDRESS4LRF"] = DBNull.Value; // ������Ӑ�Z��4�i�������p�j
                        row["CADD.ADDRESS4BRF"] = DBNull.Value; // ������Ӑ�Z��4�i�啶���p�j
                    }
                }
            }

            if (ReportItemDic.ContainsKey("HADD.ADDRESS12UPRF") || ReportItemDic.ContainsKey("HADD.ADDRESS12LOWRF"))
            {
                string prtAddress12 = (string)row["CADD.ADDRESS1RF"] + (string)row["CADD.ADDRESS3RF"];
                Encoding encording = Encoding.GetEncoding("Shift_JIS");
                //���Ӑ�Z���P�{�Q�̃o�C�g�����擾
                int count = encording.GetByteCount(prtAddress12);

                string prtAddressUp = SubStringOfByte(prtAddress12, 30);
                string prtAddressLow = string.Empty;

                if (count >= 31)
                {
                    //���Ӑ於�̂P�{�Q�ɒl������ꍇ
                    if (!string.IsNullOrEmpty(prtAddress12))
                    {
                        prtAddressLow = prtAddress12.Substring(prtAddressUp.Length, prtAddress12.Length - prtAddressUp.Length);
                        prtAddressLow = SubStringOfByte(prtAddressLow, 30);
                    }

                    row["HADD.ADDRESS12UPRF"] = prtAddressUp;
                    row["HADD.ADDRESS12LOWRF"] = prtAddressLow;
                }
                else
                {
                    row["HADD.ADDRESS12UPRF"] = DBNull.Value;
                    row["HADD.ADDRESS12LOWRF"] = prtAddressUp;
                }
            }

            # region [����p���Ӑ於�̂P�{�Q(��i�E���i)]
            //����p���Ӑ於�̂P�{�Q(��i�E���i)
            if ( ReportItemDic.ContainsKey( "CADD.PRINTCUSTOMERNAMEJOIN12UPRF" ) || ReportItemDic.ContainsKey( "CADD.PRINTCUSTOMERNAMEJOIN12LOWRF" ) )
            {
                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                Encoding encording = Encoding.GetEncoding( "Shift_JIS" );
                //���Ӑ於�̂P�{�Q�̃o�C�g�����擾
                int count = encording.GetByteCount( printCustomerNameJoin12 );

                //���Ӑ於�̂P�{�Q��40�o�C�g���擾
                string printCustomerNameUpper = SubStringOfByte( printCustomerNameJoin12, 40 );
                string printCustomerNameLower = string.Empty;

                if ( count >= 41 )
                {
                    //���Ӑ於�̂P�{�Q�ɒl������ꍇ
                    if ( !string.IsNullOrEmpty( (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"] ) )
                    {
                        printCustomerNameLower = printCustomerNameJoin12.Substring( printCustomerNameUpper.Length, printCustomerNameJoin12.Length - printCustomerNameUpper.Length );
                        printCustomerNameLower = SubStringOfByte( printCustomerNameLower, 20 );
                    }

                    row["CADD.PRINTCUSTOMERNAMEJOIN12UPRF"] = printCustomerNameUpper;
                    row["CADD.PRINTCUSTOMERNAMEJOIN12LOWRF"] = printCustomerNameLower;
                }
                else
                {
                    row["CADD.PRINTCUSTOMERNAMEJOIN12UPRF"] = DBNull.Value;
                    row["CADD.PRINTCUSTOMERNAMEJOIN12LOWRF"] = printCustomerNameUpper;
                }
            }
            // ���Ӑ於�P�{�Q��15�����ȉ��Ȃ�P�s�ň�
            // 15�������z����Ȃ�㉺10��������
            if (ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12UP2RF") || ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12LOW2RF"))
            {
                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                Encoding encording = Encoding.GetEncoding("Shift_JIS");
                //���Ӑ於�̂P�{�Q�̃o�C�g�����擾
                int count = encording.GetByteCount(printCustomerNameJoin12);
                string printCustomerNameUpper = string.Empty;
                string printCustomerNameLower = string.Empty;

                if (count >= 31)
                {
                    //���Ӑ於�̂P�{�Q�ɒl������ꍇ
                    if (!string.IsNullOrEmpty((string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"]))
                    {
                        printCustomerNameUpper = SubStringOfByte(printCustomerNameJoin12, 20);
                        printCustomerNameLower = printCustomerNameJoin12.Substring(printCustomerNameUpper.Length, printCustomerNameJoin12.Length - printCustomerNameUpper.Length);
                        printCustomerNameLower = SubStringOfByte(printCustomerNameLower, 20);
                    }

                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP2RF"] = printCustomerNameUpper;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW2RF"] = printCustomerNameLower;
                }
                else
                {
                    printCustomerNameUpper = SubStringOfByte(printCustomerNameJoin12, 30);
                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP2RF"] = DBNull.Value;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW2RF"] = printCustomerNameUpper;
                }
            }

            // ���Ӑ於�P�{�Q��15�����ȉ��Ȃ�P�s�ň�
            // 15�������z����Ȃ�㉺15��������
            if (ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12UP3RF") || ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12LOW3RF"))
            {
                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                Encoding encording = Encoding.GetEncoding("Shift_JIS");
                //���Ӑ於�̂P�{�Q�̃o�C�g�����擾
                int count = encording.GetByteCount(printCustomerNameJoin12);

                //���Ӑ於�̂P�{�Q��30�o�C�g���擾
                string printCustomerNameUpper = SubStringOfByte(printCustomerNameJoin12, 30);
                string printCustomerNameLower = string.Empty;

                if (count >= 31)
                {
                    //���Ӑ於�̂P�{�Q�ɒl������ꍇ
                    if (!string.IsNullOrEmpty((string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"]))
                    {
                        printCustomerNameLower = printCustomerNameJoin12.Substring(printCustomerNameUpper.Length, printCustomerNameJoin12.Length - printCustomerNameUpper.Length);
                        printCustomerNameLower = SubStringOfByte(printCustomerNameLower, 30);
                    }

                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP3RF"] = printCustomerNameUpper;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW3RF"] = printCustomerNameLower;
                }
                else
                {
                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP3RF"] = DBNull.Value;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW3RF"] = printCustomerNameUpper;
                }
            }

            // ���Ӑ於�P�{�Q��20�����ȉ��Ȃ�P�s�ň�
            // 20�������z����Ȃ�㉺20��������
            if (ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12UP4RF") || ReportItemDic.ContainsKey("HADD.PRINTCUSTOMERNAMEJOIN12LOW4RF"))
            {
                string printCustomerNameJoin12 = (string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"];
                Encoding encording = Encoding.GetEncoding("Shift_JIS");
                //���Ӑ於�̂P�{�Q�̃o�C�g�����擾
                int count = encording.GetByteCount(printCustomerNameJoin12);

                //���Ӑ於�̂P�{�Q��40�o�C�g���擾
                string printCustomerNameUpper = SubStringOfByte(printCustomerNameJoin12, 40);
                string printCustomerNameLower = string.Empty;

                if (count >= 41)
                {
                    //���Ӑ於�̂P�{�Q�ɒl������ꍇ
                    if (!string.IsNullOrEmpty((string)row["HADD.PRINTCUSTOMERNAMEJOIN12RF"]))
                    {
                        printCustomerNameLower = printCustomerNameJoin12.Substring(printCustomerNameUpper.Length, printCustomerNameJoin12.Length - printCustomerNameUpper.Length);
                        printCustomerNameLower = SubStringOfByte(printCustomerNameLower, 40);
                    }

                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP4RF"] = printCustomerNameUpper;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW4RF"] = printCustomerNameLower;
                }
                else
                {
                    row["HADD.PRINTCUSTOMERNAMEJOIN12UP4RF"] = DBNull.Value;
                    row["HADD.PRINTCUSTOMERNAMEJOIN12LOW4RF"] = printCustomerNameUpper;
                }
            }
            # endregion
            # endregion

            // ���Ӑ�TEL
            # region [���Ӑ�TEL]
            // 0:�󎚂��Ȃ�,1:�󎚂���
            if ( billPrtStWork.CustTelNoPrtDivCd == 0 )
            {
                // �d�b�ԍ�
                row["CADD.HOMETELNORF"] = DBNull.Value; // ������Ӑ�d�b�ԍ��i����j
                row["CADD.OFFICETELNORF"] = DBNull.Value; // ������Ӑ�d�b�ԍ��i�Ζ���j
                row["CADD.PORTABLETELNORF"] = DBNull.Value; // ������Ӑ�d�b�ԍ��i�g�сj
                row["CADD.HOMEFAXNORF"] = DBNull.Value; // ������Ӑ�FAX�ԍ��i����j
                row["CADD.OFFICEFAXNORF"] = DBNull.Value; // ������Ӑ�FAX�ԍ��i�Ζ���j
                row["CADD.OTHERSTELNORF"] = DBNull.Value; // ������Ӑ�d�b�ԍ��i���̑��j
                row["CSTCST.HOMETELNORF"] = DBNull.Value; // ���Ӑ�d�b�ԍ��i����j
                row["CSTCST.OFFICETELNORF"] = DBNull.Value; // ���Ӑ�d�b�ԍ��i�Ζ���j
                row["CSTCST.PORTABLETELNORF"] = DBNull.Value; // ���Ӑ�d�b�ԍ��i�g�сj
                row["CSTCST.HOMEFAXNORF"] = DBNull.Value; // ���Ӑ�FAX�ԍ��i����j
                row["CSTCST.OFFICEFAXNORF"] = DBNull.Value; // ���Ӑ�FAX�ԍ��i�Ζ���j
                row["CSTCST.OTHERSTELNORF"] = DBNull.Value; // ���Ӑ�d�b�ԍ��i���̑��j
                row["CSTCLM.HOMETELNORF"] = DBNull.Value; // ������d�b�ԍ��i����j
                row["CSTCLM.OFFICETELNORF"] = DBNull.Value; // ������d�b�ԍ��i�Ζ���j
                row["CSTCLM.PORTABLETELNORF"] = DBNull.Value; // ������d�b�ԍ��i�g�сj
                row["CSTCLM.HOMEFAXNORF"] = DBNull.Value; // ������FAX�ԍ��i����j
                row["CSTCLM.OFFICEFAXNORF"] = DBNull.Value; // ������FAX�ԍ��i�Ζ���j
                row["CSTCLM.OTHERSTELNORF"] = DBNull.Value; // ������d�b�ԍ��i���̑��j

                // �^�C�g��
                row["ALITMDSPNMRF.HOMETELNODSPNAMERF"] = DBNull.Value; // ����TEL�\������
                row["ALITMDSPNMRF.OFFICETELNODSPNAMERF"] = DBNull.Value; // �Ζ���TEL�\������
                row["ALITMDSPNMRF.MOBILETELNODSPNAMERF"] = DBNull.Value; // �g��TEL�\������
                row["ALITMDSPNMRF.HOMEFAXNODSPNAMERF"] = DBNull.Value; // ����FAX�\������
                row["ALITMDSPNMRF.OFFICEFAXNODSPNAMERF"] = DBNull.Value; // �Ζ���FAX�\������
                row["ALITMDSPNMRF.OTHERTELNODSPNAMERF"] = DBNull.Value; // ���̑�TEL�\������
            }
            else
            {
                // �^�C�g��
                if ( IsNullTextCell( row["CADD.HOMETELNORF"] ) ) row["ALITMDSPNMRF.HOMETELNODSPNAMERF"] = DBNull.Value; // ����TEL�\������
                if ( IsNullTextCell( row["CADD.OFFICETELNORF"] ) ) row["ALITMDSPNMRF.OFFICETELNODSPNAMERF"] = DBNull.Value; // �Ζ���TEL�\������
                if ( IsNullTextCell( row["CADD.PORTABLETELNORF"] ) ) row["ALITMDSPNMRF.MOBILETELNODSPNAMERF"] = DBNull.Value; // �g��TEL�\������
                if ( IsNullTextCell( row["CADD.HOMEFAXNORF"] ) ) row["ALITMDSPNMRF.HOMEFAXNODSPNAMERF"] = DBNull.Value; // ����FAX�\������
                if ( IsNullTextCell( row["CADD.OFFICEFAXNORF"] ) ) row["ALITMDSPNMRF.OFFICEFAXNODSPNAMERF"] = DBNull.Value; // �Ζ���FAX�\������
                if ( IsNullTextCell( row["CADD.OTHERSTELNORF"] ) ) row["ALITMDSPNMRF.OTHERTELNODSPNAMERF"] = DBNull.Value; // ���̑�TEL�\������
            }
            # endregion

            // ���Џ��(�ǉ���)
            # region [���Џ��(�ǉ���)]
            // �i�g�p�s���ڂ̑Ή��j
            row["COMPANYINFRF.COMPANYNAME1RF"] = row["COMPANYNMRF.COMPANYNAME1RF"];
            row["COMPANYINFRF.COMPANYNAME2RF"] = row["COMPANYNMRF.COMPANYNAME2RF"];
            row["COMPANYINFRF.POSTNORF"] = row["COMPANYNMRF.POSTNORF"];
            row["COMPANYINFRF.ADDRESS1RF"] = row["COMPANYNMRF.ADDRESS1RF"];
            row["COMPANYINFRF.ADDRESS3RF"] = row["COMPANYNMRF.ADDRESS3RF"];
            row["COMPANYINFRF.ADDRESS4RF"] = row["COMPANYNMRF.ADDRESS4RF"];
            row["COMPANYINFRF.COMPANYTELNO1RF"] = row["COMPANYNMRF.COMPANYTELNO1RF"];
            row["COMPANYINFRF.COMPANYTELNO2RF"] = row["COMPANYNMRF.COMPANYTELNO2RF"];
            row["COMPANYINFRF.COMPANYTELNO3RF"] = row["COMPANYNMRF.COMPANYTELNO3RF"];
            row["COMPANYINFRF.COMPANYTELTITLE1RF"] = row["COMPANYNMRF.COMPANYTELTITLE1RF"];
            row["COMPANYINFRF.COMPANYTELTITLE2RF"] = row["COMPANYNMRF.COMPANYTELTITLE2RF"];
            row["COMPANYINFRF.COMPANYTELTITLE3RF"] = row["COMPANYNMRF.COMPANYTELTITLE3RF"];

            // ���Ж��P����
            if ( !string.IsNullOrEmpty( headWork.COMPANYNMRF_COMPANYNAME1RF ) )
            {
                string firstHalf;
                string lastHalf;
                DivideEnterpriseName( headWork.COMPANYNMRF_COMPANYNAME1RF, out firstHalf, out lastHalf );
                row["HADD.PRINTENTERPRISENAME1FHRF"] = firstHalf;
                row["HADD.PRINTENTERPRISENAME1LHRF"] = lastHalf;
            }
            else
            {
                row["HADD.PRINTENTERPRISENAME1FHRF"] = DBNull.Value;
                row["HADD.PRINTENTERPRISENAME1LHRF"] = DBNull.Value;
            }
            // ���Ж��Q����
            if ( !string.IsNullOrEmpty( headWork.COMPANYNMRF_COMPANYNAME2RF ) )
            {
                string firstHalf;
                string lastHalf;
                DivideEnterpriseName( headWork.COMPANYNMRF_COMPANYNAME1RF, out firstHalf, out lastHalf );
                row["HADD.PRINTENTERPRISENAME2FHRF"] = firstHalf;
                row["HADD.PRINTENTERPRISENAME2LHRF"] = lastHalf;
            }
            else
            {
                row["HADD.PRINTENTERPRISENAME2FHRF"] = DBNull.Value;
                row["HADD.PRINTENTERPRISENAME2LHRF"] = DBNull.Value;
            }
            // ����p���Ж��i��i/���i�j
            if ( !string.IsNullOrEmpty( headWork.COMPANYNMRF_COMPANYNAME2RF ) )
            {
                // ��i�F���Ж��P
                row["HADD.PRINTENTERPRISENAMEEX1RF"] = headWork.COMPANYNMRF_COMPANYNAME1RF; // ����p���Ж��i��i�j
                // ���i�F���Ж��Q
                row["HADD.PRINTENTERPRISENAMEEX2RF"] = headWork.COMPANYNMRF_COMPANYNAME2RF; // ����p���Ж��i���i�j
            }
            else
            {
                // ��i�F��
                row["HADD.PRINTENTERPRISENAMEEX1RF"] = DBNull.Value; // ����p���Ж��i��i�j
                // ���i�F���Ж��P
                row["HADD.PRINTENTERPRISENAMEEX2RF"] = headWork.COMPANYNMRF_COMPANYNAME1RF; // ����p���Ж��i���i�j
            }

            row["HADD.COMPANYNAMEJOIN12RF"] = headWork.COMPANYNMRF_COMPANYNAME1RF + "�@" + headWork.COMPANYNMRF_COMPANYNAME2RF;  // ���Ж��P�{���Ж��Q
            # endregion

            // ��s����
            # region [��s����]
            // 0:�󎚂���,1:�󎚂��Ȃ�
            if ( billPrtStWork.BillBankNmPrintOut != 0 )
            {
                row["COMPANYNMRF.TRANSFERGUIDANCERF"] = DBNull.Value;
                row["COMPANYNMRF.ACCOUNTNOINFO1RF"] = DBNull.Value;
                row["COMPANYNMRF.ACCOUNTNOINFO2RF"] = DBNull.Value;
                row["COMPANYNMRF.ACCOUNTNOINFO3RF"] = DBNull.Value;
            }
            # endregion

            // ���t�W�J
            # region [���t�֘A �W�J����]
            // �ʏ�
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_ADDUPDATERF, "HADD.ADDUPDATE", false ); // yyyymmdd
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_ADDUPYEARMONTHRF, "HADD.ADDUPYEARMONTH", true ); // yyyymm
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_STARTCADDUPUPDDATERF, "HADD.STARTCADDUPUPDDATE", false ); // yyyymmdd
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_BILLPRINTDATERF, "HADD.BILLPRINTDATE", false ); // yyyymmdd
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF, "HADD.EXPECTEDDEPOSITDATE", false ); // yyyymmdd
            ExtractDate( ref row, allDefSet.EraNameDispCd2, headWork.HADD_ISSUEDAYRF, "HADD.ISSUEDAY", false ); // yyyymmdd
            # endregion

            // ��������
            # region [��������]
            // (0:���l��,1:28�`31���͖����ƈ�)
            if ( billPrtStWork.BillLastDayPrtDiv == 1 )
            {
                // �v��N����
                if ( IsLast( row, "HADD.ADDUPDATEFDRF" ) ) 
                {
                    row["HADD.ADDUPDATEFDRF"] = DBNull.Value;
                    row[ct_col_Last_AddUpDate] = ct_LastDayString; // ��
                }
                // �����X�V�J�n�N����
                if ( IsLast( row, "HADD.STARTCADDUPUPDDATEFDRF" ) )
                {
                    row["HADD.STARTCADDUPUPDDATEFDRF"] = DBNull.Value;
                    row[ct_col_Last_StartCAddUpUpdDate] = ct_LastDayString; // ��
                }
                // ���������s��
                if ( IsLast( row, "HADD.BILLPRINTDATEFDRF" ) )
                {
                    row["HADD.BILLPRINTDATEFDRF"] = DBNull.Value;
                    row[ct_col_Last_BillPrintDate] = ct_LastDayString; // ��
                }
                // �����\���
                if ( IsLast( row, "HADD.EXPECTEDDEPOSITDATEFDRF" ) )
                {
                    row["HADD.EXPECTEDDEPOSITDATEFDRF"] = DBNull.Value;
                    row[ct_col_Last_ExpectedDepositDate] = ct_LastDayString; // ��
                }
                // ���͔��s���t
                if ( IsLast( row, "HADD.ISSUEDAYFDRF" ) )
                {
                    row["HADD.ISSUEDAYFDRF"] = DBNull.Value;
                    row[ct_col_Last_IssueDay] = ct_LastDayString; // ��
                }
                // �W����
                if ( IsLast( row, "CSTCST.COLLECTMONEYDAYRF" ) )
                {
                    row["CSTCST.COLLECTMONEYDAYRF"] = DBNull.Value;
                    row[ct_col_Last_CollectMoneyDay] = ct_LastDayString; // ��
                }
                // �v�Z�����\���
                if (IsLast(row, "HADD.CALCEXPECTEDDEPOSITDATEFDRF"))
                {
                    row["HADD.CALCEXPECTEDDEPOSITDATEFDRF"] = DBNull.Value;
                    row["LAST.CALCEXPECTEDDEPOSITDATERF"] = ct_LastDayString; // ��
                }
            }
            # endregion

            # region [���t�֘A �W�J����(�p�^�[���ǉ�)]
            // �ʏ�(���tExtra�p�^�[��)
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.EXPECTEDDEPOSITDATE", false ); // yyyymmdd
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.ADDUPDATE", false ); // yyyymmdd
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.STARTCADDUPUPDDATE", false ); // yyyymmdd
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.BILLPRINTDATE", false ); // yyyymmdd
            ExtractDateOfExtraFormat( ref row, allDefSet.EraNameDispCd2, "HADD.ISSUEDAY", false ); // yyyymmdd
            # endregion
            // �������ԍ�
            # region [�������ԍ�]
            if ( headWork.CUSTDMDPRCRF_BILLNORF != 0 )
            {
                row["CUSTDMDPRCRF.BILLNORF"] = headWork.CUSTDMDPRCRF_BILLNORF; // �������ԍ�
            }
            else
            {
                row["CUSTDMDPRCRF.BILLNORF"] = DBNull.Value;
            }
            # endregion

            // �Ӌ��z���󎚂��Ȃ��ꍇ�̐���
            # region [�Ӌ��z���󎚂��Ȃ��ꍇ�̐���]
            if ( !printPrice )
            {
                row["CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISTIMEDMDNRMLRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISTIMETTLBLCDMDRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.OFSTHISTIMESALESRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDOFFSETINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.OFFSETOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.OFFSETINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISTIMESALESRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDSALESOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDSALESINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ITDEDSALESTAXFREERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.SALESOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.SALESINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESPRICRGDSRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDRETOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDRETINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDRETTAXFREERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLRETOUTERTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLRETINNERTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESPRICDISRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDDISOUTTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDDISINTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLITDEDDISTAXFREERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLDISOUTERTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TTLDISINNERTAXRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.TAXADJUSTRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.BALANCEADJUSTRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.AFCALDEMANDPRICERF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF"] = DBNull.Value;
                row["CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF"] = DBNull.Value;

                row["CUSTDMDPRCRF.LASTTIMEDEMANDRF"] = DBNull.Value;// �O�񐿋����z�i�ʏ�j���O��{�Q��O�{�R��O
                row[ct_col_HDmd_LastTimeDemandOrg] = DBNull.Value;// �O�񐿋����z�i�O��̂݁j���O��̂�
                row["HADD.THISSALESANDADJUSTTAXINCRF"] = DBNull.Value;// ���񔄏�z(�ō�)
                row["CUSTDMDPRCRF.OFSTHISSALESTAXRF"] = DBNull.Value; // ���E�㍡�񔄏�����
                row["CUSTDMDPRCRF.THISSALESTAXRF"] = DBNull.Value; // ���񔄏�����
                row["CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF"] = DBNull.Value; // ���񔄏�ԕi�����
                row["CUSTDMDPRCRF.THISSALESPRCTAXDISRF"] = DBNull.Value; // ���񔄏�l�������
                row["HADD.THISTAXANDADJUSTRF"] = DBNull.Value; // ���񔄏㒲������� 
                row["HADD.THISSALESANDADJUSTTAXINCRF"] = DBNull.Value; // ���񔄏�z(�ō�)

                row[ct_col_TaxTitle] = DBNull.Value; // ����Ń^�C�g��
                row[ct_col_OfsThisSalesTaxIncTtl] = DBNull.Value; //���E�㔄�㍇�v���z(�ō�)�^�C�g��
                row[ct_col_ThisTimeRetDis] = DBNull.Value; // ����ԕi�l���z�i����ԕi�{����l���j
                row["HADD.SALESANDRGDSRF"] = DBNull.Value; // ����|�ԕi
                row["HADD.SALESANDDISRF"] = DBNull.Value; // ����|�l��
                row["HADD.DEPTTOTALCASHRF"] = DBNull.Value; // �������v�i�����j
                row["HADD.DEPTTOTALTRANSFERRF"] = DBNull.Value; // �������v�i�U���j
                row["HADD.DEPTTOTALCHECKRF"] = DBNull.Value; // �������v�i���؎�j
                row["HADD.DEPTTOTALDRAFTRF"] = DBNull.Value; // �������v�i��`�j
                row["HADD.DEPTTOTALOFFSETRF"] = DBNull.Value; // �������v�i���E�j
                row["HADD.DEPTTOTALOTHERSRF"] = DBNull.Value; // �������v�i���̑��j
                row["HADD.DEPTTOTALACCOUNTRF"] = DBNull.Value; // �������v�i�����U���j
                row["HADD.DEPTTOTALFACTORINGRF"] = DBNull.Value; // �������v�i�t�@�N�^�����O�j
                row["HADD.DEPTTOTALSUM1RF"] = DBNull.Value; // �������v�i�萔���{���̑��j
                row["HADD.DEPTTOTALSUM2RF"] = DBNull.Value; // �������v�i�l���{���̑��j
                row["HADD.DEPTTOTALSUM3RF"] = DBNull.Value; // �������v�i���E�{���̑��j
                row["HADD.DEPTTOTALSUM4RF"] = DBNull.Value; // �������v�i�萔���{���E�{���̑��j
                row["HADD.DEPTTOTALSUM5RF"] = DBNull.Value; // �������v�i�l���{�萔���{���̑��j
                row["HADD.DEPTTOTALSUM6RF"] = DBNull.Value; // �������v�i�l���{���E�{���̑��j
                row["HADD.DEPTTOTALSUM7RF"] = DBNull.Value; // �������v�i�萔���{���E�{�l���{���̑��j
                row["HADD.DEPTTOTALSUM8RF"] = DBNull.Value; // �������v�i�����{�U���{���؎�{��`�j
                row["HADD.DEPTTOTALEXC1RF"] = DBNull.Value; // �������v�i�萔���E���̑������j
                row["HADD.DEPTTOTALEXC2RF"] = DBNull.Value; // �������v�i�l���E���̑������j
                row["HADD.DEPTTOTALEXC3RF"] = DBNull.Value; // �������v�i���E�E���̑������j
                row["HADD.DEPTTOTALEXC4RF"] = DBNull.Value; // �������v�i�萔���E���E�E���̑������j
                row["HADD.DEPTTOTALEXC5RF"] = DBNull.Value; // �������v�i�l���E�萔���E���̑������j
                row["HADD.DEPTTOTALEXC6RF"] = DBNull.Value; // �������v�i�l���E���E�E���̑������j
                row["HADD.DEPTTOTALEXC7RF"] = DBNull.Value; // �������v�i�萔���E���E�E�l���E���̑������j
                row["HADD.DEPTTOTALEXC8RF"] = DBNull.Value; // �������v�i�����E�U���E���؎�E��`�����j
                row["DEPT01.DEPOSITRF"] = DBNull.Value; // �������햼��1
                row["DEPT01.MONEYKINDNAMERF"] = DBNull.Value; // �������z1
                row["DEPT02.DEPOSITRF"] = DBNull.Value; // �������햼��2
                row["DEPT02.MONEYKINDNAMERF"] = DBNull.Value; // �������z2
                row["DEPT03.DEPOSITRF"] = DBNull.Value; // �������햼��3
                row["DEPT03.MONEYKINDNAMERF"] = DBNull.Value; // �������z3
                row["DEPT04.DEPOSITRF"] = DBNull.Value; // �������햼��4
                row["DEPT04.MONEYKINDNAMERF"] = DBNull.Value; // �������z4
                row["DEPT05.DEPOSITRF"] = DBNull.Value; // �������햼��5
                row["DEPT05.MONEYKINDNAMERF"] = DBNull.Value; // �������z5
                row["DEPT06.DEPOSITRF"] = DBNull.Value; // �������햼��6
                row["DEPT06.MONEYKINDNAMERF"] = DBNull.Value; // �������z6
                row["DEPT07.DEPOSITRF"] = DBNull.Value; // �������햼��7
                row["DEPT07.MONEYKINDNAMERF"] = DBNull.Value; // �������z7
                row["DEPT08.DEPOSITRF"] = DBNull.Value; // �������햼��8
                row["DEPT08.MONEYKINDNAMERF"] = DBNull.Value; // �������z8
                row["DEPT09.DEPOSITRF"] = DBNull.Value; // �������햼��9
                row["DEPT09.MONEYKINDNAMERF"] = DBNull.Value; // �������z9
                row["DEPT10.DEPOSITRF"] = DBNull.Value; // �������햼��10
                row["DEPT10.MONEYKINDNAMERF"] = DBNull.Value; // �������z10
                row["HADD.DMDNRMLEXDISFEERF"] = DBNull.Value; // �������z(�l���E�萔������)
                row["HADD.DMDNRMLEXDISRF"] = DBNull.Value; // �������z(�l������)
                row["HADD.DMDNRMLEXFEERF"] = DBNull.Value; // �������z(�萔������)
                row["HADD.DMDNRMLSAMDISFEERF"] = DBNull.Value; // �������z(�l���{�萔��)
                row["HADD.OFSTHISSALESTAXINCRF"] = DBNull.Value; // ���E�㔄����z(�ō�)
                row["HADD.OFSTHISSALESTAXINC2RF"] = DBNull.Value; // ���E�㔄�㍇�v���z(�ō�)(��ېŁE�q���󎚁j
            }
            else
            {
                row[ct_col_TaxTitle] = taxTitle; // ����Ń^�C�g��
                row[ct_col_OfsThisSalesTaxIncTtl] = ofsThisSalesTaxIncTtl; //���㍇�v���z(�ō�)�^�C�g��
            }
            # endregion

            // ����Ōv
            // �Ōv���\���Ă��鎞�����������s��
            if (ReportItemDic.ContainsKey("HADD.SALESMONEYPAGETTLRF"))
            {
                // �Ōv���X�g��NULL�ł͂Ȃ�
                if (pageTtlList != null)
                {
                    // �Ő���NULL�ł͂Ȃ�
                    if (row[ct_col_PageCount] != DBNull.Value)
                    {
                        row["HADD.SALESMONEYPAGETTLRF"] = pageTtlList[(int)row[ct_col_PageCount]];
                    }
                }
            }

            // �ŏI�y�[�W�݈̂������
            if (row[ct_col_PageCount] != DBNull.Value)
            {
                if ((int)row[ct_col_PageCount] != _pageCount)
                {
                    row["HADD.LASTPAGECOMMENTRF"] = DBNull.Value;
                    row["HADD.OFSTHISTIMESALESLASTPAGERF"] = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// �������v�f�B�N�V���i���ǉ�����
        /// </summary>
        /// <param name="deptTotalDic">�Ώۂ̃f�B�N�V���i��</param>
        /// <param name="kindCd">����R�[�h(key)</param>
        /// <param name="deptTotal">���z(value)</param>
        /// <remarks>
        /// <br>Note        : �������v�f�B�N�V���i���ǉ�����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void AddToDeptTotalDic( ref Dictionary<int, long> deptTotalDic, int kindCd, long deptTotal )
        {
            if ( kindCd != 0 && deptTotalDic.ContainsKey( kindCd ) == false )
            {
                deptTotalDic.Add( kindCd, deptTotal );
            }
        }
        /// <summary>
        /// �������v�f�B�N�V���i������̎擾
        /// </summary>
        /// <param name="deptTotalDic">�������v�f�B�N�V���i��</param>
        /// <param name="kindCd">����R�[�h</param>
        /// <returns>��������z</returns>
        /// <remarks>
        /// <br>Note        : �������v�f�B�N�V���i������̎擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static Int64 GetFromDeptTotalDic( Dictionary<int, long> deptTotalDic, int kindCd )
        {
            if ( deptTotalDic.ContainsKey( kindCd ) )
            {
                return deptTotalDic[kindCd];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ������m�t�k�k����iDataRow�Z���p�j
        /// </summary>
        /// <param name="textObject">����Ώ�</param>
        /// <returns>������m�t�k�k���茋��</returns>
        /// <remarks>
        /// <br>Note        : ������m�t�k�k����iDataRow�Z���p�j</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsNullTextCell( object textObject )
        {
            return (textObject == DBNull.Value || string.IsNullOrEmpty( (string)textObject ));
        }

        /// <summary>
        /// �S�p�˔��p�ϊ�
        /// </summary>
        /// <param name="orgString">�Ώ�</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note        : �S�p�˔��p�ϊ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetKanaString(string orgString)
        {
            // �S�p�˔��p�ϊ��i�r���Ɋ܂܂��ϊ��ł��Ȃ������͂��̂܂܁j
            return Microsoft.VisualBasic.Strings.StrConv(orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0);
        }

        /// <summary>
        /// ����\��z�i����\��\�̑Ώۊz�j���v�Z���܂�
        /// </summary>
        /// <param name="headWork">�w�b�_�[���</param>
        /// <param name="billAllStWork">�������S�̐ݒ�</param>
        /// <returns>����\��z</returns>
        /// <remarks>
        /// <br>Note        : ����\��z�i����\��\�̑Ώۊz�j���v�Z���܂�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static Int64 GetExpectedDepositMoney(EBooksFrePBillHeadWork headWork, BillAllStWork billAllStWork)
        {
            Int64 expectedDepositMoney = 0;

            if (billAllStWork.CollectPlnDiv == 0)
            {
                // ����\��敪���敪
                // �␳��W�����̎擾
                int correctCollectMoneyCode = CorrectCollectMoneyCode(headWork);

                if (correctCollectMoneyCode == 0)
                {
                    // ����(��3��O�c��+��2��O�c��+�O�񐿋��c��+���E�㍡�񔄏�z+���E�㍡�񔄏�����-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF +
                                  headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (correctCollectMoneyCode == 1)
                {
                    // ����(��3��O�c��+��2��O�c��+�O�񐿋��c��-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF -
                                  headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (correctCollectMoneyCode == 2)
                {
                    // ���X��(��3��O�c��+��2��O�c��-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (correctCollectMoneyCode == 3)
                {
                    // ���X�X��(��3��O�c��-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
            }
            else
            {
                // ����\��敪�����t
                // ���������̎Z��
                DateTime calcDate = CalcDate(headWork);
                // �o�ߊ��Ԃ̎Z�o
                int yyyy, mm, dd;
                yyyy = headWork.CUSTDMDPRCRF_ADDUPDATERF / 10000;
                mm = headWork.CUSTDMDPRCRF_ADDUPDATERF % 10000 / 100;
                dd = headWork.CUSTDMDPRCRF_ADDUPDATERF % 100;
                DateTime progreTerm = new DateTime(yyyy, mm, dd);  // ����

                // �W�����̔���
                if (calcDate < progreTerm)
                {
                    // ����(��3��O�c��+��2��O�c��+�O�񐿋��c��+���E�㍡�񔄏�z+���E�㍡�񔄏�����-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF +
                                  headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (calcDate < progreTerm.AddMonths(1))
                {
                    // ����(��3��O�c��+��2��O�c��+�O�񐿋��c��+���E�㍡�񔄏�z+���E�㍡�񔄏�����-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF +
                                  headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF + headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (calcDate < progreTerm.AddMonths(2))
                {
                    // ����(��3��O�c��+��2��O�c��+�O�񐿋��c��-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF + headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF -
                                  headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else if (calcDate < progreTerm.AddMonths(3))
                {
                    // ���X��(��3��O�c��+��2��O�c��-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF + headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
                else
                {
                    // ���X�X��(��3��O�c��-��������z)
                    expectedDepositMoney = headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF - headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;
                }
            }
            return expectedDepositMoney;
        }

        /// <summary>
        /// ���������̎Z��
        /// </summary>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note        : ���������̎Z��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static DateTime CalcDate(EBooksFrePBillHeadWork headWork)
        {
            int yyyy, mm, dd;
            yyyy = headWork.CUSTDMDPRCRF_ADDUPDATERF / 10000;
            mm = headWork.CUSTDMDPRCRF_ADDUPDATERF % 10000 / 100;
            dd = headWork.CUSTDMDPRCRF_ADDUPDATERF % 100;
            DateTime custDmdPrcRF_AddUpDateRF = new DateTime(yyyy, mm, dd);
            DateTime calcDate = custDmdPrcRF_AddUpDateRF.AddMonths(headWork.CSTCLM_COLLECTMONEYCODERF);
            double setDays = 0.0;
            int endDays = DateTime.DaysInMonth(calcDate.Year, calcDate.Month);
            if (endDays < headWork.CSTCLM_COLLECTMONEYDAYRF)
            {
                // �W���������������̌����𒴂��Ă���
                setDays = endDays - (double)calcDate.Day;
            }
            else
            {
                // �W���������������̌����𒴂��Ă��Ȃ�
                setDays = headWork.CSTCLM_COLLECTMONEYDAYRF - (double)calcDate.Day;
            }
            return calcDate.AddDays(setDays);
        }

        /// <summary>
        /// �W�����̕␳
        /// </summary>
        /// <returns>�␳��W����</returns>
        /// <remarks>
        /// <br>Note        : �W�����̕␳</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int CorrectCollectMoneyCode(EBooksFrePBillHeadWork headWork)
        {
            // �W����
            int collectMoneyCode = headWork.CSTCLM_COLLECTMONEYCODERF;

            if (collectMoneyCode >= 1)
            {
                // �W�����������ȍ~
                if (headWork.CSTCLM_TOTALDAYRF >= headWork.CSTCLM_COLLECTMONEYDAYRF)
                {
                    // ���Ӑ�}�X�^�̒������W�����̏ꍇ�́A�W������␳
                    collectMoneyCode -= 1;
                }
            }

            return collectMoneyCode;
        }

        /// <summary>
        /// ������E������̎Z�o
        /// </summary>
        /// <param name="headWork">�w�b�_�[���</param>
        /// <returns>������E�����</returns>
        /// <remarks>
        /// <br>Note        : ������E������̎Z�o</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static DateTime CalcCollectDate(EBooksFrePBillHeadWork headWork)
        {
            // ������敪�������Œ���������������̏ꍇ�A������𗈌��Ƃ���B
            int yyyy, mm, dd, collectDay, lastDay, bCollectDay;
            bool isLastDay = false;
            yyyy = headWork.CUSTDMDPRCRF_ADDUPDATERF / 10000;
            mm = headWork.CUSTDMDPRCRF_ADDUPDATERF % 10000 / 100;
            dd = headWork.CUSTDMDPRCRF_ADDUPDATERF % 100;
            collectDay = headWork.CSTCLM_COLLECTMONEYDAYRF;
            bCollectDay = collectDay;
            lastDay = DateTime.DaysInMonth(yyyy, mm);
            if (collectDay > lastDay)
            {
                // ������������̌������傫�������ꍇ�́A�����̌������Z�b�g
                collectDay = lastDay;
                isLastDay = true;
            }
            DateTime collectYYMMDD = new DateTime(yyyy, mm, collectDay);
            collectYYMMDD = collectYYMMDD.AddMonths(headWork.CSTCLM_COLLECTMONEYCODERF);
            if (headWork.CSTCLM_COLLECTMONEYCODERF == 0)
            {
                if (dd >= collectDay)
                {
                    collectYYMMDD = collectYYMMDD.AddMonths(1);
                }
            }
            if (isLastDay)
            {
                // �����̌������Z�b�g���Ă���ꍇ�͌��̉�������Z�b�g
                collectDay = bCollectDay;
                lastDay = DateTime.DaysInMonth(collectYYMMDD.Year, collectYYMMDD.Month);
                if (collectDay > lastDay)
                {
                    // ���̉������������̌������傫�������ꍇ�́A������̌������Z�b�g
                    collectDay = lastDay;
                }
                collectYYMMDD = new DateTime(collectYYMMDD.Year, collectYYMMDD.Month, collectDay);
            }
            return collectYYMMDD;
        }

        # region [���Ж��̕�������]
        /// <summary>
        /// ���Ж��̕�������
        /// </summary>
        /// <param name="originName">�����Ж�</param>
        /// <param name="firstHalf">���Ж��O��</param>
        /// <param name="lastHalf">���Ж��㔼</param>
        /// <remarks>
        /// <br>Note        : ���Ж��̕�������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void DivideEnterpriseName( string originName, out string firstHalf, out string lastHalf )
        {
            // �m�r�̓}�X�^�ݒ�ł̓��͉\���������p�E�S�p��ʂ��Ȃ��d�l�Ȃ̂�
            // �o�C�g���ł͂Ȃ��������ŕ�������B

            const int fullLength = 20;
            const int divideLength = 10;

            // �X�y�[�X�ŋl�߂�
            originName = originName.PadRight( fullLength, ' ' );
            // ����
            firstHalf = originName.Substring( 0, divideLength ).TrimEnd();
            lastHalf = originName.Substring( divideLength, divideLength ).TrimEnd();
        }
        # endregion

        #region[������@�o�C�g���w��؂蔲��]
        /// <summary>
        /// ������@�o�C�g���w��؂蔲��
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <remarks>
        /// <br>Note        : �w��o�C�g���Ő؂蔲����������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        protected static string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // �u�������v�����炷
                resultString = orgString.Substring(0, i);

                // �o�C�g�����擾���Ĕ���
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // �I�[�̋󔒂͍폜
            return resultString;

        }
        #endregion

        # region [��������]
        /// <summary>
        /// �������菈��
        /// </summary>
        /// <param name="row">�s</param>
        /// <param name="columnName">��</param>
        /// <returns>���茋��</returns>
        /// <remarks>
        /// <br>Note        : �������菈��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsLast( DataRow row, string columnName )
        {
            if ( row[columnName] == DBNull.Value )
            {
                return false;
            }
            else
            {
                return IsLast( (int)row[columnName] );
            }
        }

        /// <summary>
        /// �������菈���i28�`31���͖����j
        /// </summary>
        /// <param name="date">���t</param>
        /// <returns>�������茋��</returns>
        /// <remarks>
        /// <br>Note        : �������菈��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsLast( int date )
        {
            return (28 <= date);
        }
        # endregion

        # region [�f�[�^�[������]
        /// <summary>
        /// ������R�[�h�̃[������
        /// </summary>
        /// <param name="textValue">����Ώ�</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note        : ������R�[�h�̃[������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsZero( string textValue )
        {
            if ( textValue == null || textValue.Trim() == string.Empty ) return true;

            try
            {
                return (Int32.Parse( textValue ) == 0);
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// ���l�R�[�h�̃[������
        /// </summary>
        /// <param name="intValue">����Ώ�</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note        : ���l�R�[�h�̃[������</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static bool IsZero( int intValue )
        {
            return (intValue == 0);
        }
        # endregion

        // --- ADD START 3H ���� 2023/04/14 ----------------------------------->>>>>
        #region [�@����`�[�v���z(�ō���) �A�����(�`�[�]��)/����`�[�v���z(�ō���) �ǉ��Ή�]
        /// <summary>
        /// �t�H�[�}�b�g����B
        /// </summary>
        /// <param name="number">���l</param>
        /// <param name="iMaxLength">�ő�󎚌���</param>
        /// <returns>��������</returns>
        private static string SetFormat(Int64 number, Int32 iMaxLength)
        {
            string tempSales = number.ToString();

            // �t�H�[�}�b�g�ՊE�l��ݒ�
            Int32 iCriticalValue = 10;

            // �t�H�[�}�b�g:�u####,###,##0�v
            // �ő包���𒴂���̏ꍇ�A�u************�v��ݒ�
            if (tempSales.Length < iCriticalValue)
            {
                tempSales = number.ToString("###,##0");
            }
            //  �t�H�[�}�b�g:�u####,###,##0�v
            else if (tempSales.Length == iCriticalValue)
            {
                tempSales = number.ToString("#####+###+##0").Replace("+", ",");
            }
            //  �t�H�[�}�b�g:�u************�v
            else if (tempSales.Length > iCriticalValue)
            {
                tempSales = new string('*', iMaxLength);
            }

            return tempSales;
        }
        #endregion
        // --- ADD END 3H ���� 2023/04/14 -------------------------------------<<<<<

        /// <summary>
        /// �������w�b�_���ǉ����ړK�p����
        /// </summary>
        /// <param name="headWork">�w�b�_�[���</param>
        /// <param name="dmdPrtPtnWork">�������</param>
        /// <param name="frePrtPSetWork">���|�[�g���</param>
        /// <param name="allDefSet">�S�̏����\���ݒ�</param>
        /// <param name="billAllStWork">�������S�̐ݒ�</param>
        /// <param name="billPrtStWork">����������ݒ�</param>
        /// <remarks>
        /// <br>Note        : �������w�b�_���ǉ����ړK�p����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ReflectBillHeaderAddtionSet( ref EBooksFrePBillHeadWork headWork, DmdPrtPtnWork dmdPrtPtnWork, FrePrtPSetWork frePrtPSetWork, BillAllStWork billAllStWork, BillPrtStWork billPrtStWork, AllDefSetWork allDefSet )
        {
            //---------------------------------------------------
            // �������p�^�[���ݒ���R�s�[
            //---------------------------------------------------
            headWork.HADD_DMDFORMTITLERF = dmdPrtPtnWork.DmdFormTitle;
            headWork.HADD_DMDFORMTITLE2RF = dmdPrtPtnWork.DmdFormTitle2;
            headWork.HADD_DMDFORMCOMENT1RF = dmdPrtPtnWork.DmdFormComent1;
            headWork.HADD_DMDFORMCOMENT2RF = dmdPrtPtnWork.DmdFormComent2;
            headWork.HADD_DMDFORMCOMENT3RF = dmdPrtPtnWork.DmdFormComent3;

            //---------------------------------------------------
            // �h��
            //---------------------------------------------------
            // ���Ӑ�}�X�^�Ɍh�̂����ݒ�Ȃ�΁A����������p�^�[���ݒ�̌h�̂ŏ���������
            if ( string.IsNullOrEmpty( headWork.CSTCLM_HONORIFICTITLERF ) ) headWork.CSTCLM_HONORIFICTITLERF = dmdPrtPtnWork.BillHonorificTtl;
            if ( string.IsNullOrEmpty( headWork.CSTCST_HONORIFICTITLERF ) ) headWork.CSTCST_HONORIFICTITLERF = dmdPrtPtnWork.BillHonorificTtl;

            //---------------------------------------------------
            // �Œ薼�̎擾
            //---------------------------------------------------
            headWork.HADD_COLLECTCONDNMRF = GetHADD_COLLECTCONDNM( headWork.CUSTDMDPRCRF_COLLECTCONDRF );

            //---------------------------------------------------
            // �Ӌ��z�Z�o�l
            //---------------------------------------------------
            # region [�Ӌ��z�Z�o�l]
            // �������z(�l������)
            headWork.HADD_DMDNRMLEXDISRF = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF;
            // �������z(�萔������)
            headWork.HADD_DMDNRMLEXFEERF = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;
            // �������z(�l���E�萔������)
            headWork.HADD_DMDNRMLEXDISFEERF = headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF - headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF - headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;
            // �������z(�l���{�萔��)
            headWork.HADD_DMDNRMLSAMDISFEERF = headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF + headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF;
            // ���񔄏�z(�Ŕ�)
            headWork.HADD_THISSALESANDADJUSTRF = headWork.CUSTDMDPRCRF_THISTIMESALESRF + headWork.CUSTDMDPRCRF_BALANCEADJUSTRF;
            // ���񔄏�����
            headWork.HADD_THISTAXANDADJUSTRF = headWork.CUSTDMDPRCRF_THISSALESTAXRF + headWork.CUSTDMDPRCRF_TAXADJUSTRF;
            # endregion

            //---------------------------------------------------
            // ���Џ��̐ݒ�
            //---------------------------------------------------
            # region [���Џ��]
            // 0:���Ж��󎚁@1:���_���󎚁@2:�r�b�g�}�b�v���󎚁@3:�󎚂��Ȃ�
            switch (dmdPrtPtnWork.CoNmPrintOutCd)
            {
                case 0:
                    {
                        switch (billPrtStWork.BillCoNmPrintOutCd)
                        {
                            // ���Ж�
                            case 0:
                                {
                                    // ���Џ��}�X�^�̓��e�ɍ����ւ���
                                    headWork.COMPANYNMRF_COMPANYNAME1RF = headWork.COMPANYINFRF_COMPANYNAME1RF;// ���Ж���1
                                    headWork.COMPANYNMRF_COMPANYNAME2RF = headWork.COMPANYINFRF_COMPANYNAME2RF;// ���Ж���2
                                    headWork.COMPANYNMRF_POSTNORF = headWork.COMPANYINFRF_POSTNORF;// �X�֔ԍ�
                                    headWork.COMPANYNMRF_ADDRESS1RF = headWork.COMPANYINFRF_ADDRESS1RF;// �Z��1�i�s���{���s��S�E�����E���j
                                    headWork.COMPANYNMRF_ADDRESS3RF = headWork.COMPANYINFRF_ADDRESS3RF;// �Z��3�i�Ԓn�j
                                    headWork.COMPANYNMRF_ADDRESS4RF = headWork.COMPANYINFRF_ADDRESS4RF;// �Z��4�i�A�p�[�g���́j
                                    headWork.COMPANYNMRF_COMPANYTELNO1RF = headWork.COMPANYINFRF_COMPANYTELNO1RF;// ���Гd�b�ԍ�1
                                    headWork.COMPANYNMRF_COMPANYTELNO2RF = headWork.COMPANYINFRF_COMPANYTELNO2RF;// ���Гd�b�ԍ�2
                                    headWork.COMPANYNMRF_COMPANYTELNO3RF = headWork.COMPANYINFRF_COMPANYTELNO3RF;// ���Гd�b�ԍ�3
                                    headWork.COMPANYNMRF_COMPANYTELTITLE1RF = headWork.COMPANYINFRF_COMPANYTELTITLE1RF;// ���Гd�b�ԍ��^�C�g��1
                                    headWork.COMPANYNMRF_COMPANYTELTITLE2RF = headWork.COMPANYINFRF_COMPANYTELTITLE2RF;// ���Гd�b�ԍ��^�C�g��2
                                    headWork.COMPANYNMRF_COMPANYTELTITLE3RF = headWork.COMPANYINFRF_COMPANYTELTITLE3RF;// ���Гd�b�ԍ��^�C�g��3
                                    // bitmap�Ȃ�
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// �摜�󎚗p�R�����g1
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// �摜�󎚗p�R�����g2
                                    headWork.IMAGEINFORF_IMAGEINFODATARF = null;// �摜���f�[�^
                                }
                                break;
                            // ���_��
                            case 1:
                                {
                                    // bitmap�Ȃ�
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// �摜�󎚗p�R�����g1
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// �摜�󎚗p�R�����g2
                                    headWork.IMAGEINFORF_IMAGEINFODATARF = null;// �摜���f�[�^   
                                }
                                break;
                            case 2:
                                {
                                    // ���Џ�񕶎�����󎚂��Ȃ�
                                    headWork.COMPANYNMRF_COMPANYNAME1RF = string.Empty;// ���Ж���1
                                    headWork.COMPANYNMRF_COMPANYNAME2RF = string.Empty;// ���Ж���2
                                    headWork.COMPANYNMRF_POSTNORF = string.Empty;// �X�֔ԍ�
                                    headWork.COMPANYNMRF_ADDRESS1RF = string.Empty;// �Z��1�i�s���{���s��S�E�����E���j
                                    headWork.COMPANYNMRF_ADDRESS3RF = string.Empty;// �Z��3�i�Ԓn�j
                                    headWork.COMPANYNMRF_ADDRESS4RF = string.Empty;// �Z��4�i�A�p�[�g���́j
                                    headWork.COMPANYNMRF_COMPANYTELNO1RF = string.Empty;// ���Гd�b�ԍ�1
                                    headWork.COMPANYNMRF_COMPANYTELNO2RF = string.Empty;// ���Гd�b�ԍ�2
                                    headWork.COMPANYNMRF_COMPANYTELNO3RF = string.Empty;// ���Гd�b�ԍ�3
                                    headWork.COMPANYNMRF_COMPANYTELTITLE1RF = string.Empty;// ���Гd�b�ԍ��^�C�g��1
                                    headWork.COMPANYNMRF_COMPANYTELTITLE2RF = string.Empty;// ���Гd�b�ԍ��^�C�g��2
                                    headWork.COMPANYNMRF_COMPANYTELTITLE3RF = string.Empty;// ���Гd�b�ԍ��^�C�g��3
                                }
                                break;
                            case 3:
                            default:
                                {
                                    // ���Џ�񕶎�����󎚂��Ȃ�
                                    headWork.COMPANYNMRF_COMPANYNAME1RF = string.Empty;// ���Ж���1
                                    headWork.COMPANYNMRF_COMPANYNAME2RF = string.Empty;// ���Ж���2
                                    headWork.COMPANYNMRF_POSTNORF = string.Empty;// �X�֔ԍ�
                                    headWork.COMPANYNMRF_ADDRESS1RF = string.Empty;// �Z��1�i�s���{���s��S�E�����E���j
                                    headWork.COMPANYNMRF_ADDRESS3RF = string.Empty;// �Z��3�i�Ԓn�j
                                    headWork.COMPANYNMRF_ADDRESS4RF = string.Empty;// �Z��4�i�A�p�[�g���́j
                                    headWork.COMPANYNMRF_COMPANYTELNO1RF = string.Empty;// ���Гd�b�ԍ�1
                                    headWork.COMPANYNMRF_COMPANYTELNO2RF = string.Empty;// ���Гd�b�ԍ�2
                                    headWork.COMPANYNMRF_COMPANYTELNO3RF = string.Empty;// ���Гd�b�ԍ�3
                                    headWork.COMPANYNMRF_COMPANYTELTITLE1RF = string.Empty;// ���Гd�b�ԍ��^�C�g��1
                                    headWork.COMPANYNMRF_COMPANYTELTITLE2RF = string.Empty;// ���Гd�b�ԍ��^�C�g��2
                                    headWork.COMPANYNMRF_COMPANYTELTITLE3RF = string.Empty;// ���Гd�b�ԍ��^�C�g��3
                                    // bitmap�Ȃ�
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// �摜�󎚗p�R�����g1
                                    headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// �摜�󎚗p�R�����g2
                                    headWork.IMAGEINFORF_IMAGEINFODATARF = null;// �摜���f�[�^
                                }
                                break;
                        }
                    }
                    break;
                // ���Ж�
                case 1:
                    {
                        // ���Џ��}�X�^�̓��e�ɍ����ւ���
                        headWork.COMPANYNMRF_COMPANYNAME1RF = headWork.COMPANYINFRF_COMPANYNAME1RF;// ���Ж���1
                        headWork.COMPANYNMRF_COMPANYNAME2RF = headWork.COMPANYINFRF_COMPANYNAME2RF;// ���Ж���2
                        headWork.COMPANYNMRF_POSTNORF = headWork.COMPANYINFRF_POSTNORF;// �X�֔ԍ�
                        headWork.COMPANYNMRF_ADDRESS1RF = headWork.COMPANYINFRF_ADDRESS1RF;// �Z��1�i�s���{���s��S�E�����E���j
                        headWork.COMPANYNMRF_ADDRESS3RF = headWork.COMPANYINFRF_ADDRESS3RF;// �Z��3�i�Ԓn�j
                        headWork.COMPANYNMRF_ADDRESS4RF = headWork.COMPANYINFRF_ADDRESS4RF;// �Z��4�i�A�p�[�g���́j
                        headWork.COMPANYNMRF_COMPANYTELNO1RF = headWork.COMPANYINFRF_COMPANYTELNO1RF;// ���Гd�b�ԍ�1
                        headWork.COMPANYNMRF_COMPANYTELNO2RF = headWork.COMPANYINFRF_COMPANYTELNO2RF;// ���Гd�b�ԍ�2
                        headWork.COMPANYNMRF_COMPANYTELNO3RF = headWork.COMPANYINFRF_COMPANYTELNO3RF;// ���Гd�b�ԍ�3
                        headWork.COMPANYNMRF_COMPANYTELTITLE1RF = headWork.COMPANYINFRF_COMPANYTELTITLE1RF;// ���Гd�b�ԍ��^�C�g��1
                        headWork.COMPANYNMRF_COMPANYTELTITLE2RF = headWork.COMPANYINFRF_COMPANYTELTITLE2RF;// ���Гd�b�ԍ��^�C�g��2
                        headWork.COMPANYNMRF_COMPANYTELTITLE3RF = headWork.COMPANYINFRF_COMPANYTELTITLE3RF;// ���Гd�b�ԍ��^�C�g��3
                        // bitmap�Ȃ�
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// �摜�󎚗p�R�����g1
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// �摜�󎚗p�R�����g2
                        headWork.IMAGEINFORF_IMAGEINFODATARF = null;// �摜���f�[�^
                    }
                    break;
                // ���_��

                case 2:
                    {
                        // bitmap�Ȃ�
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// �摜�󎚗p�R�����g1
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// �摜�󎚗p�R�����g2
                        headWork.IMAGEINFORF_IMAGEINFODATARF = null;// �摜���f�[�^
                    }
                    break;
                // �r�b�g�}�b�v
                case 3:
                    {
                        // ���Џ�񕶎�����󎚂��Ȃ�
                        headWork.COMPANYNMRF_COMPANYNAME1RF = string.Empty;// ���Ж���1
                        headWork.COMPANYNMRF_COMPANYNAME2RF = string.Empty;// ���Ж���2
                        headWork.COMPANYNMRF_POSTNORF = string.Empty;// �X�֔ԍ�
                        headWork.COMPANYNMRF_ADDRESS1RF = string.Empty;// �Z��1�i�s���{���s��S�E�����E���j
                        headWork.COMPANYNMRF_ADDRESS3RF = string.Empty;// �Z��3�i�Ԓn�j
                        headWork.COMPANYNMRF_ADDRESS4RF = string.Empty;// �Z��4�i�A�p�[�g���́j
                        headWork.COMPANYNMRF_COMPANYTELNO1RF = string.Empty;// ���Гd�b�ԍ�1
                        headWork.COMPANYNMRF_COMPANYTELNO2RF = string.Empty;// ���Гd�b�ԍ�2
                        headWork.COMPANYNMRF_COMPANYTELNO3RF = string.Empty;// ���Гd�b�ԍ�3
                        headWork.COMPANYNMRF_COMPANYTELTITLE1RF = string.Empty;// ���Гd�b�ԍ��^�C�g��1
                        headWork.COMPANYNMRF_COMPANYTELTITLE2RF = string.Empty;// ���Гd�b�ԍ��^�C�g��2
                        headWork.COMPANYNMRF_COMPANYTELTITLE3RF = string.Empty;// ���Гd�b�ԍ��^�C�g��3
                    }
                    break;
                // �󎚂��Ȃ�
                case 4:
                default:
                    {
                        // ���Џ�񕶎�����󎚂��Ȃ�
                        headWork.COMPANYNMRF_COMPANYNAME1RF = string.Empty;// ���Ж���1
                        headWork.COMPANYNMRF_COMPANYNAME2RF = string.Empty;// ���Ж���2
                        headWork.COMPANYNMRF_POSTNORF = string.Empty;// �X�֔ԍ�
                        headWork.COMPANYNMRF_ADDRESS1RF = string.Empty;// �Z��1�i�s���{���s��S�E�����E���j
                        headWork.COMPANYNMRF_ADDRESS3RF = string.Empty;// �Z��3�i�Ԓn�j
                        headWork.COMPANYNMRF_ADDRESS4RF = string.Empty;// �Z��4�i�A�p�[�g���́j
                        headWork.COMPANYNMRF_COMPANYTELNO1RF = string.Empty;// ���Гd�b�ԍ�1
                        headWork.COMPANYNMRF_COMPANYTELNO2RF = string.Empty;// ���Гd�b�ԍ�2
                        headWork.COMPANYNMRF_COMPANYTELNO3RF = string.Empty;// ���Гd�b�ԍ�3
                        headWork.COMPANYNMRF_COMPANYTELTITLE1RF = string.Empty;// ���Гd�b�ԍ��^�C�g��1
                        headWork.COMPANYNMRF_COMPANYTELTITLE2RF = string.Empty;// ���Гd�b�ԍ��^�C�g��2
                        headWork.COMPANYNMRF_COMPANYTELTITLE3RF = string.Empty;// ���Гd�b�ԍ��^�C�g��3
                        // bitmap�Ȃ�
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = string.Empty;// �摜�󎚗p�R�����g1
                        headWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = string.Empty;// �摜�󎚗p�R�����g2
                        headWork.IMAGEINFORF_IMAGEINFODATARF = null;// �摜���f�[�^
                    }
                    break;
            }
            # endregion
        }

        # region [���t�֘A���� �W�J����]
        /// <summary>
        /// ���t�֘A���ځ@�W�J
        /// </summary>
        /// <param name="targetRow">�f�[�^���[</param>
        /// <param name="eraNameDispCd">0:����@1:�a��</param>
        /// <param name="date">���t</param>
        /// <param name="dateColumnName">���t�R���g���[��</param>
        /// <param name="isMonth">���t�t�H�[�}�b�g�t���O</param>
        /// <remarks>
        /// <br>Note        : ���t�֘A���ځ@�W�J</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, DateTime date, string dateColumnName, bool isMonth )
        {
            // DateTime��Ή�����Int�l�ɕϊ�
            int dateInt = 0;
            if ( date != DateTime.MinValue )
            {
                if ( !isMonth )
                {
                    dateInt = (date.Year * 10000) + (date.Month * 100) + (date.Day);
                }
                else
                {
                    dateInt = (date.Year * 100) + (date.Month);
                }
            }

            // ���t�W�J���\�b�h�ɓn��
            ExtractDate( ref targetRow, eraNameDispCd, dateInt, dateColumnName, isMonth );
        }

        /// <summary>
        /// ���t�֘A���ځ@�W�J
        /// </summary>
        /// <param name="targetRow">�f�[�^���[</param>
        /// <param name="eraNameDispCd">0:����@1:�a��</param>
        /// <param name="date">���t</param>
        /// <param name="dateColumnName">���t�R���g���[��</param>
        /// <param name="isMonth">���t�t�H�[�}�b�g�t���O</param>
        /// <remarks>
        /// <br>Note        : ���t�֘A���ځ@�W�J</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, int date, string dateColumnName, bool isMonth )
        {
            //-------------------------------------------------------------------
            // �y���ڂ̈󎚗L���z
            //         YMD YM Y
            // 2009    ���@���@��
            // 01      ���@���@�~
            // 31      ���@�~�@�~
            // �N      ���@���@��
            // ��      ���@���@�~
            // ��      ���@�~�@�~
            // /       ���@���@�~
            // .       ���@���@�~
            // ����    ���@���@��
            // H       ���@���@��
            // 21      ���@���@��
            //-------------------------------------------------------------------

            // �a��t���O
            bool jpEra = (eraNameDispCd == 1);
            // �N�̂ݔ���t���O
            bool isYear = false;

            bool emptyYear = false;
            if (isMonth)//yyyymm
            {
                if ((date / 100) == 0 && (date % 100) != 0)
                    emptyYear = true;
            }

            if (date != 0 && !emptyYear) 
            {
                // �N�����ڂ̏ꍇ�́A�a��ϊ��ɔ����Ďw��N���̍ŏI���ɕϊ�����
                if ( isMonth )
                {
                    // �N�̂ݔ���("200900"��2009�N)
                    isYear = (date % 100 == 0);

                    if ( isYear )
                    {
                        //-----------------------------------------------
                        // �N�̂�
                        //-----------------------------------------------

                        // �w��N���̓��������߂�(=���̔N�̍ŏI��)��12/31�ł����O�̂��߁c
                        int dd = DateTime.DaysInMonth( date / 100, 12 );

                        // YYYYMMDD�ɂ���
                        date = ((int)(date / 100) * 10000) + (12*100) + dd;
                    }
                    else
                    {
                        //-----------------------------------------------
                        // �N���̂�
                        //-----------------------------------------------

                        // �w��N���̓��������߂�(=���̌��̍ŏI��)
                        int dd = DateTime.DaysInMonth( date / 100, date % 100 );

                        // YYYYMMDD�ɂ���
                        date = (date * 100) + dd;
                    }
                }

                // �N�i�a��or����j
                if ( jpEra )
                {
                    // �a��
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = GetDateFW( date ); // �a��N
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = TDateTime.LongDateToString( "GG", date ); // �a���
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = TDateTime.LongDateToString( "gg", date ); // �a�������
                    // �N���A
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
                }
                else
                {
                    // ����
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = (date / 10000); // ����N
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = (date / 10000) % 100; // ����N(��)
                    // �N���A
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
                }

                // �N���e����
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = "�N";

                if ( !isYear )
                {
                    // ��
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = (date / 100) % 100; // ��

                    // ���e�����n
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = "/";
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = ".";
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = "��";

                    if ( !isMonth )
                    {
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = (date % 100); // ��
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = "��";
                    }
                }
            }
            else
            {
                // �����ȓ��t�Ȃ�΋�
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = DBNull.Value;

                if ( !isMonth )
                {
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// �a��N�擾�����iH20��"20"�݂̂��擾����j
        /// </summary>
        /// <param name="date">���t</param>
        /// <returns>�a��N</returns>
        /// <remarks>
        /// <br>Note        : �a��N�擾����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int GetDateFW( int date )
        {
            // �a������擾
            string date_gg = TDateTime.LongDateToString( "gg", date );  // H
            string date_exggyy = TDateTime.LongDateToString( "exggyy", date );  // H20

            // "H20" ���� "H" ����菜���� "20" ���擾����
            return ToInt( date_exggyy.Substring( date_gg.Length, date_exggyy.Length - date_gg.Length ) );

        }

        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text">�ϊ��O������</param>
        /// <returns>�ϊ��㐔�l</returns>
        /// <remarks>
        /// <br>Note        : ���l�ϊ�����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ���tExtra�t�H�[�}�b�g(����p)
        /// </summary>
        /// <param name="targetRow">�f�[�^���[</param>
        /// <param name="eraNameDispCd">0:����@1:�a��</param>
        /// <param name="dateColumnName">���t�R���g���[��</param>
        /// <param name="isMonth">���t�t�H�[�}�b�g�t���O</param>
        /// <remarks>
        /// <br>Note        : ���tExtra�t�H�[�}�b�g(����p)</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static void ExtractDateOfExtraFormat( ref DataRow targetRow, int eraNameDispCd, string dateColumnName, bool isMonth )
        {
            try
            {
                // �Z�b�g�ςݔ���(�N�͐���/�a��̍����ւ�������̂ŁA�����ڂŔ��f����)
                if ( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] != DBNull.Value )
                {
                    // �a��t���O
                    bool jpEra = (eraNameDispCd == 1);

                    int dtFY = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] ); // ����N
                    int dtFS = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] ); // ����N(��)
                    int dtFW = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] ); // �a��N
                    int dtFM = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] ); // ��
                    int dtFD = CellToInt( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] ); // ��

                    // ���t(�����Ή��̈�)
                    string wkFD;
                    if ( dtFD != 0 )
                    {
                        wkFD = string.Format( "{0:D2}", dtFD );
                    }
                    else
                    {
                        wkFD = ct_LastDayString; // ����
                    }

                    if ( jpEra )
                    {
                        string dtFG = CellToString( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] ); // �a���
                        string dtFR = CellToString( targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] ); // �a���

                        //------------------------------------------------
                        // �a��
                        //------------------------------------------------
                        // Ex1 (�N���� ����4��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX1" )] = string.Format( "{0}{1:D2}�N{2:D2}��{3}��", dtFG, dtFW, dtFM, wkFD );
                        // Ex2 (�N���� ����2��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX2" )] = string.Format( "{0}{1:D2}�N{2:D2}��{3}��", dtFG, dtFW, dtFM, wkFD );
                        // Ex3 (/ ����4��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX3" )] = string.Format( "{0}{1:D2}/{2:D2}/{3}", dtFR, dtFW, dtFM, wkFD );
                        // Ex4 (/ ����2��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX4" )] = string.Format( "{0}{1:D2}/{2:D2}/{3}", dtFR, dtFW, dtFM, wkFD );
                        // Ex5 (. ����4��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX5" )] = string.Format( "{0}{1:D2}.{2:D2}.{3}", dtFR, dtFW, dtFM, wkFD );
                        // Ex6 (. ����2��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX6" )] = string.Format( "{0}{1:D2}.{2:D2}.{3}", dtFR, dtFW, dtFM, wkFD );
                    }
                    else
                    {
                        //------------------------------------------------
                        // ����
                        //------------------------------------------------
                        // Ex1 (�N���� ����4��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX1" )] = string.Format( "{0}{1:D4}�N{2:D2}��{3}��", string.Empty, dtFY, dtFM, wkFD );
                        // Ex2 (�N���� ����2��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX2" )] = string.Format( "{0}{1:D2}�N{2:D2}��{3}��", string.Empty, dtFS, dtFM, wkFD );
                        // Ex3 (/ ����4��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX3" )] = string.Format( "{0}{1:D4}/{2:D2}/{3}", string.Empty, dtFY, dtFM, wkFD );
                        // Ex4 (/ ����2��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX4" )] = string.Format( "{0}{1:D2}/{2:D2}/{3}", string.Empty, dtFS, dtFM, wkFD );
                        // Ex5 (. ����4��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX5" )] = string.Format( "{0}{1:D4}.{2:D2}.{3}", string.Empty, dtFY, dtFM, wkFD );
                        // Ex6 (. ����2��)
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX6" )] = string.Format( "{0}{1:D2}.{2:D2}.{3}", string.Empty, dtFS, dtFM, wkFD );
                    }
                }
                else
                {
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX1" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX2" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX3" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX4" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX5" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "EX6" )] = DBNull.Value;
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// ���l����
        /// </summary>
        /// <param name="cell">�Z���Ώ�</param>
        /// <returns>�Z�����l</returns>
        /// <remarks>
        /// <br>Note        : ���l����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static int CellToInt( object cell )
        {
            if ( cell != DBNull.Value )
            {
                try
                {
                    return (int)cell;
                }
                catch
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ϊ�
        /// </summary>
        /// <param name="cell">�Z���Ώ�</param>
        /// <returns>�Z��������</returns>
        /// <remarks>
        /// <br>Note        : ������ϊ�</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string CellToString( object cell )
        {
            if ( cell != DBNull.Value )
            {
                try
                {
                    return (string)cell;
                }
                catch
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        # endregion

        # region [�Œ薼�̎擾]
        /// <summary>
        /// ����������� �擾����
        /// </summary>
        /// <param name="code">��������R�[�h</param>
        /// <returns>�����������</returns>
        /// <remarks>
        /// <br>Note        : ����������� �擾����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private static string GetHADD_COLLECTCONDNM( int code )
        {
            // 10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�
            switch ( code )
            {
                case 10:
                    return "����";
                case 20:
                    return "�U��";
                case 30:
                    return "���؎�";
                case 40:
                    return "��`";
                case 50:
                    return "�萔��";
                case 60:
                    return "���E";
                case 70:
                    return "�l��";
                case 80:
                    return "���̑�";
                default:
                    return string.Empty;
            }
        }
        # endregion

        # region [���׃f�U�C���Ή� �Ώۃf�[�^�t�B�[���h���X�g�擾����]
        /// <summary>
        /// ���׃f�U�C���Ή��@����w�b�_���ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>����w�b�_���ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή��@����w�b�_���ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// </remarks>
        public static List<string> GetDesignSalesHeaderList()
        {
            return new List<string>( new string[] 
            { 
                # region [����w�b�_����]
                "SALESSLIPRF.ACPTANODRSTATUSRF",
                "SALESSLIPRF.SALESSLIPNUMRF",
                "SALESSLIPRF.SECTIONCODERF",
                "SALESSLIPRF.SUBSECTIONCODERF",
                "SALESSLIPRF.DEBITNOTEDIVRF",
                "SALESSLIPRF.SALESSLIPCDRF",
                "SALESSLIPRF.SALESGOODSCDRF",
                "SALESSLIPRF.ACCRECDIVCDRF",
                "SALESSLIPRF.DEMANDADDUPSECCDRF",
                "SALESSLIPRF.SALESDATERF",
                "SALESSLIPRF.ADDUPADATERF",
                "SALESSLIPRF.INPUTAGENCDRF",
                "SALESSLIPRF.INPUTAGENNMRF",
                "SALESSLIPRF.SALESINPUTCODERF",
                "SALESSLIPRF.SALESINPUTNAMERF",
                "SALESSLIPRF.FRONTEMPLOYEECDRF",
                "SALESSLIPRF.FRONTEMPLOYEENMRF",
                "SALESSLIPRF.SALESEMPLOYEECDRF",
                "SALESSLIPRF.SALESEMPLOYEENMRF",
                "SALESSLIPRF.SALESTOTALTAXINCRF",
                "SALESSLIPRF.SALESTOTALTAXEXCRF",
                "SALESSLIPRF.SALESPRTTOTALTAXINCRF",
                "SALESSLIPRF.SALESPRTTOTALTAXEXCRF",
                "SALESSLIPRF.SALESWORKTOTALTAXINCRF",
                "SALESSLIPRF.SALESWORKTOTALTAXEXCRF",
                "SALESSLIPRF.SALESSUBTOTALTAXINCRF",
                "SALESSLIPRF.SALESSUBTOTALTAXEXCRF",
                "SALESSLIPRF.SALESPRTSUBTTLINCRF",
                "SALESSLIPRF.SALESPRTSUBTTLEXCRF",
                "SALESSLIPRF.SALESWORKSUBTTLINCRF",
                "SALESSLIPRF.SALESWORKSUBTTLEXCRF",
                "SALESSLIPRF.SALESSUBTOTALTAXRF",
                "SALESSLIPRF.ITDEDPARTSDISOUTTAXRF",
                "SALESSLIPRF.ITDEDPARTSDISINTAXRF",
                "SALESSLIPRF.ITDEDWORKDISOUTTAXRF",
                "SALESSLIPRF.ITDEDWORKDISINTAXRF",
                "SALESSLIPRF.PARTSDISCOUNTRATERF",
                "SALESSLIPRF.RAVORDISCOUNTRATERF",
                "SALESSLIPRF.TOTALCOSTRF",
                "SALESSLIPRF.CONSTAXRATERF",
                "SALESSLIPRF.AUTODEPOSITCDRF",
                "SALESSLIPRF.AUTODEPOSITSLIPNORF",
                "SALESSLIPRF.DEPOSITALLOWANCETTLRF",
                "SALESSLIPRF.DEPOSITALWCBLNCERF",
                "SALESSLIPRF.CLAIMCODERF",
                "SALESSLIPRF.CUSTOMERCODERF",
                "SALESSLIPRF.CUSTOMERNAMERF",
                "SALESSLIPRF.CUSTOMERNAME2RF",
                "SALESSLIPRF.CUSTOMERSNMRF",
                "SALESSLIPRF.HONORIFICTITLERF",
                "SALESSLIPRF.ADDRESSEECODERF",
                "SALESSLIPRF.ADDRESSEENAMERF",
                "SALESSLIPRF.ADDRESSEENAME2RF",
                "SALESSLIPRF.SLIPNOTERF",
                "SALESSLIPRF.SLIPNOTE2RF",
                "SALESSLIPRF.SLIPNOTE3RF",
                "SALESSLIPRF.RETGOODSREASONDIVRF",
                "SALESSLIPRF.RETGOODSREASONRF",
                "SALESSLIPRF.DETAILROWCOUNTRF",
                "SALESSLIPRF.UOEREMARK1RF",
                "SALESSLIPRF.UOEREMARK2RF",
                "SALESSLIPRF.DELIVEREDGOODSDIVRF",
                "SALESSLIPRF.DELIVEREDGOODSDIVNMRF",
                "SALESSLIPRF.STOCKGOODSTTLTAXEXCRF",
                "SALESSLIPRF.PUREGOODSTTLTAXEXCRF",
                "SALESSLIPRF.FOOTNOTES1RF",
                "SALESSLIPRF.FOOTNOTES2RF",
                "SECDTL.SECTIONGUIDENMRF",
                "SECDTL.SECTIONGUIDESNMRF",
                "SECDTL.COMPANYNAMECD1RF",
                "SUBSAL.SUBSECTIONNAMERF",
                "DADD.ACPTANODRSTATUSRF",
                "DADD.DEBITNOTEDIVRF",
                "DADD.SALESSLIPCDRF",
                "DADD.SALESDATERF",
                // --- ADD START �c������ 2022/10/18 ----->>>>>
                "TAX.HFTOTALCONSTAXRATETITLERF",
                "TAX.HFTOTALSALESMONEYTAXEXCRF",
                "TAX.HFTAXRATE1RF",
                "TAX.HFTAXRATE1SALESTAXEXCRF",
                "TAX.HFTAXRATE1SALESTAXRF",
                "TAX.HFTAXRATE2RF",
                "TAX.HFTAXRATE2SALESTAXEXCRF",
                "TAX.HFTAXRATE2SALESTAXRF",
                "TAX.HFTAXOUTITLERF",
                "TAX.HFTAXOUTSALESTAXEXCRF",
                "TAX.HFOTHERTAXRATERF",
                "TAX.HFOTHERTAXRATESALESTAXEXCRF",
                "TAX.HFOTHERTAXRATESALESTAXRF",
                "TAX.HFTAXTITLERF",
                // --- ADD END   �c������ 2022/10/18 -----<<<<<
                "DADD.SALESDATEFYRF",
                "DADD.SALESDATEFSRF",
                "DADD.SALESDATEFWRF",
                "DADD.SALESDATEFMRF",
                "DADD.SALESDATEFDRF",
                "DADD.SALESDATEFGRF",
                "DADD.SALESDATEFRRF",
                "DADD.SALESDATEFLSRF",
                "DADD.SALESDATEFLPRF",
                "DADD.SALESDATEFLYRF",
                "DADD.SALESDATEFLMRF",
                "DADD.SALESDATEFLDRF"    // ���Ō�̍��ڂ̓J���}�Ȃ�
                # endregion
            } );
        }
        /// <summary>
        /// ���׃f�U�C���Ή��@���㖾�׍��ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>���㖾�׍��ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή��@���㖾�׍��ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// </remarks>
        public static List<string> GetDesignSalesDetailList()
        {
            return new List<string>( new string[] 
            { 
                # region [���㖾�׍���]
                "SALESDETAILRF.ACCEPTANORDERNORF",
                "SALESDETAILRF.SALESROWNORF",
                "SALESDETAILRF.DELIGDSCMPLTDUEDATERF",
                "SALESDETAILRF.GOODSKINDCODERF",
                "SALESDETAILRF.GOODSMAKERCDRF",
                "SALESDETAILRF.MAKERNAMERF",
                "SALESDETAILRF.GOODSNORF",
                "SALESDETAILRF.GOODSNAMERF",
                "SALESDETAILRF.GOODSSHORTNAMERF",
                "SALESDETAILRF.GOODSLGROUPRF",
                "SALESDETAILRF.GOODSLGROUPNAMERF",
                "SALESDETAILRF.GOODSMGROUPRF",
                "SALESDETAILRF.GOODSMGROUPNAMERF",
                "SALESDETAILRF.BLGROUPCODERF",
                "SALESDETAILRF.BLGROUPNAMERF",
                "SALESDETAILRF.BLGOODSCODERF",
                "SALESDETAILRF.BLGOODSFULLNAMERF",
                "SALESDETAILRF.ENTERPRISEGANRECODERF",
                "SALESDETAILRF.ENTERPRISEGANRENAMERF",
                "SALESDETAILRF.WAREHOUSECODERF",
                "SALESDETAILRF.WAREHOUSENAMERF",
                "SALESDETAILRF.WAREHOUSESHELFNORF",
                "SALESDETAILRF.SALESORDERDIVCDRF",
                "SALESDETAILRF.OPENPRICEDIVRF",
                "SALESDETAILRF.GOODSRATERANKRF",
                "SALESDETAILRF.LISTPRICERATERF",
                "SALESDETAILRF.LISTPRICETAXINCFLRF",
                "SALESDETAILRF.LISTPRICETAXEXCFLRF",
                "SALESDETAILRF.SALESRATERF",
                "SALESDETAILRF.SALESUNPRCTAXINCFLRF",
                "SALESDETAILRF.SALESUNPRCTAXEXCFLRF",
                "SALESDETAILRF.COSTRATERF",
                "SALESDETAILRF.SALESUNITCOSTRF",
                "SALESDETAILRF.PRTBLGOODSCODERF",
                "SALESDETAILRF.PRTBLGOODSNAMERF",
                "SALESDETAILRF.WORKMANHOURRF",
                "SALESDETAILRF.SHIPMENTCNTRF",
                "SALESDETAILRF.SALESMONEYTAXINCRF",
                "SALESDETAILRF.SALESMONEYTAXEXCRF",
                "SALESDETAILRF.COSTRF",
                "SALESDETAILRF.TAXATIONDIVCDRF",
                "SALESDETAILRF.PARTYSLIPNUMDTLRF",
                "SALESDETAILRF.DTLNOTERF",
                "SALESDETAILRF.SUPPLIERCDRF",
                "SALESDETAILRF.SUPPLIERSNMRF",
                "SALESDETAILRF.SLIPMEMO1RF",
                "SALESDETAILRF.SLIPMEMO2RF",
                "SALESDETAILRF.SLIPMEMO3RF",
                "SALESDETAILRF.INSIDEMEMO1RF",
                "SALESDETAILRF.INSIDEMEMO2RF",
                "SALESDETAILRF.INSIDEMEMO3RF",
                "SALESDETAILRF.BFLISTPRICERF",
                "SALESDETAILRF.BFSALESUNITPRICERF",
                "SALESDETAILRF.BFUNITCOSTRF",
                "SALESDETAILRF.CMPLTSALESROWNORF",
                "SALESDETAILRF.CMPLTGOODSMAKERCDRF",
                "SALESDETAILRF.CMPLTMAKERNAMERF",
                "SALESDETAILRF.CMPLTGOODSNAMERF",
                "SALESDETAILRF.CMPLTSHIPMENTCNTRF",
                "SALESDETAILRF.CMPLTSALESUNPRCFLRF",
                "SALESDETAILRF.CMPLTSALESMONEYRF",
                "SALESDETAILRF.CMPLTSALESUNITCOSTRF",
                "SALESDETAILRF.CMPLTCOSTRF",
                "SALESDETAILRF.CMPLTPARTYSALSLNUMRF",
                "SALESDETAILRF.CMPLTNOTERF",
                "ACCEPTODRCARRF.CARMNGNORF",
                "ACCEPTODRCARRF.CARMNGCODERF",
                "ACCEPTODRCARRF.NUMBERPLATE1CODERF",
                "ACCEPTODRCARRF.NUMBERPLATE1NAMERF",
                "ACCEPTODRCARRF.NUMBERPLATE2RF",
                "ACCEPTODRCARRF.NUMBERPLATE3RF",
                "ACCEPTODRCARRF.NUMBERPLATE4RF",
                "ACCEPTODRCARRF.FIRSTENTRYDATERF",
                "ACCEPTODRCARRF.MAKERCODERF",
                "ACCEPTODRCARRF.MAKERFULLNAMERF",
                "ACCEPTODRCARRF.MODELCODERF",
                "ACCEPTODRCARRF.MODELSUBCODERF",
                "ACCEPTODRCARRF.MODELFULLNAMERF",
                "ACCEPTODRCARRF.EXHAUSTGASSIGNRF",
                "ACCEPTODRCARRF.SERIESMODELRF",
                "ACCEPTODRCARRF.CATEGORYSIGNMODELRF",
                "ACCEPTODRCARRF.FULLMODELRF",
                "ACCEPTODRCARRF.MODELDESIGNATIONNORF",
                "ACCEPTODRCARRF.CATEGORYNORF",
                "ACCEPTODRCARRF.FRAMEMODELRF",
                "ACCEPTODRCARRF.FRAMENORF",
                "ACCEPTODRCARRF.SEARCHFRAMENORF",
                "ACCEPTODRCARRF.ENGINEMODELNMRF",
                "ACCEPTODRCARRF.RELEVANCEMODELRF",
                "ACCEPTODRCARRF.SUBCARNMCDRF",
                "ACCEPTODRCARRF.MODELGRADESNAMERF",
                "ACCEPTODRCARRF.COLORCODERF",
                "ACCEPTODRCARRF.COLORNAME1RF",
                "ACCEPTODRCARRF.TRIMCODERF",
                "ACCEPTODRCARRF.TRIMNAMERF",
                "ACCEPTODRCARRF.MILEAGERF",
                "DADD.STOCKGOODSTTLTAXEXCRF",
                "DADD.PUREGOODSTTLTAXEXCRF",
                "DADD.GOODSKINDCODERF",
                "DADD.SALESORDERDIVCDRF",
                "DADD.OPENPRICEDIVRF",
                "DADD.TAXATIONDIVCDRF",
                "DADD.FIRSTENTRYDATEFYRF",
                "DADD.FIRSTENTRYDATEFSRF",
                "DADD.FIRSTENTRYDATEFWRF",
                "DADD.FIRSTENTRYDATEFMRF",
                "DADD.FIRSTENTRYDATEFGRF",
                "DADD.FIRSTENTRYDATEFRRF",
                "DADD.FIRSTENTRYDATEFLSRF",
                "DADD.FIRSTENTRYDATEFLPRF",
                "DADD.FIRSTENTRYDATEFLYRF",
                "DADD.FIRSTENTRYDATEFLMRF",
                "DADD.DMDDTLOUTLINERF",
                "DADD.MODELHALFNAME2RF",
                // --- ADD START �c������ 2022/10/18 ----->>>>>
                "TAX.DTLTAXRATERF",
                "TAX.DTLTOTALCONSTAXRATETITLERF",
                "TAX.DTLTOTALSALESMONEYTAXEXCRF",
                "TAX.DTLTAXRATE1RF",
                "TAX.DTLTAXRATE1SALESTAXEXCRF",
                "TAX.DTLTAXRATE1SALESTAXRF",
                "TAX.DTLTAXRATE2RF",
                "TAX.DTLTAXRATE2SALESTAXEXCRF",
                "TAX.DTLTAXRATE2SALESTAXRF",
                "TAX.DTLTAXOUTITLERF",
                "TAX.DTLTAXOUTSALESTAXEXCRF",
                "TAX.DTLOTHERTAXRATERF",
                "TAX.DTLOTHERTAXRATESALESTAXEXCRF",
                "TAX.DTLOTHERTAXRATESALESTAXRF",
                "TAX.DTLTAXTITLERF",
                // --- ADD END   �c������ 2022/10/18 -----<<<<<
                "DSAL.DETAILTITLERF",
                "DADD.MODELHALFNAMEDTL2RF",
                "DADD.FULLMODELRF"
                # endregion
            } );
        }
        /// <summary>
        /// ���׃f�U�C���Ή��@����t�b�^���ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>����t�b�^���ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή��@����t�b�^���ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note : 2023/04/14 3H ����</br>
        /// <br>�Ǘ��ԍ�    : 11970040-00 ���R���[���ڒǉ��Ή�</br>
        /// <br>              �@����`�[�v���z(�ō���)</br>
        /// <br>              �A�����(�`�[�]��)/����`�[�v���z(�ō���)</br>
        /// </remarks>
        public static List<string> GetDesignSalesFooterList()
        {
            return new List<string>( new string[]
            { 
                # region [����t�b�^����]
                "DADD.DETAILBLANKLINERF", 
                "DADD.SALESMONEYALLDETAILTTLRF", 
                "SALESSLIPRF.PARTYSALESLIPNUMRF",
                "DADD.SALESFTTITLERF",
                "DADD.SALESFTPRICERF",
                "DADD.SALESFTNOTE1RF",
                "DADD.SALESFTNOTE2RF",
                "DADD.SALESFTNOTE3RF",
                "DADD.SLIPTTLTAXTITLERF",
                "DADD.SLIPTTLTAXRF",
                "DADD.ADDTAXLINERF",
                // --- ADD START 3H ���� 2023/04/14 >>>>>
                "DADD.SALESMONEYTAXINCRF",               // ����`�[�v���z(�ō���)
                "DADD.TAXRFANDSALESMONEYTAXINCRF",       // �����(�`�[�]��)/����`�[�v���z(�ō���)
                // --- ADD END 3H ���� 2023/04/14  <<<<<
                "DADD.DTLTITLERF"         // ���Ō�̍��ڂ̓J���}�Ȃ�
                #endregion
            } );
        }
        /// <summary>
        /// ���׃f�U�C���Ή��@����t�b�^�Q���ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>����t�b�^�Q���ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή��@����t�b�^�Q���ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignSalesFooter2List()
        {
            return new List<string>(new string[]
            {
                #region[����t�b�^�Q����]
                "DADD.SALESFT2NOTERF",
                "DADD.SALESFT2TITLERF",
                "DADD.SALESFT2PRICERF",
                "DADD.SALESFT2TITLE2RF",
                "DADD.SALESFT2PRICE2RF"      // ���Ō�̍��ڂ̓J���}�Ȃ�
                #endregion
            });
        }
        /// <summary>
        /// ���׃f�U�C���Ή��@����t�b�^�R���ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>����t�b�^�R���ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή��@����t�b�^�R���ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignSalesFooter3List()
        {
            return new List<string>(new string[]
            {
                #region[����t�b�^�R ����]
                "DADD.SALESFT3NOTERF",
                "DADD.SALESFT3TITLERF",
                "DADD.SALESFT3PRICERF"      // ���Ō�̍��ڂ̓J���}�Ȃ�
                #endregion
            });
        }
        /// <summary>
        /// ���׃f�U�C���Ή��@����w�b�_�Q���ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>����w�b�_�Q���ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή��@����w�b�_�Q���ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignSalesHeader2List()
        {
            return new List<string>(new string[]
                {
                    #region[����w�b�_�Q ����]
                    "DADD.FULLMODELHD2RF",
                    "DADD.MODELHALFNAMEHD2RF",
                    "DADD.SALESSLIPCDCHANGERF",
                    "DADD.SALESSLIPNUMHD2RF",
                    "DADD.SALESDATEHD2FMRF",
                    "DADD.SALESDATEHD2FDRF",
                    "DADD.SALESDATEHD2FLPRF",
                    "DADD.SALESDATEHD2RF",
                    "DADD.SALESDATEHD2FYRF",
                    "DADD.SALESDATEHD2FSRF",
                    "DADD.SALESDATEHD2FWRF",
                    "DADD.SALESDATEHD2FGRF",
                    "DADD.SALESDATEHD2FRRF",
                    "DADD.SALESDATEHD2FLSRF",
                    "DADD.SALESDATEHD2FLYRF",
                    "DADD.SALESDATEHD2FLMRF",
                    "DADD.HEADFULLMODEL2RF",
                    "DADD.SALESDATEHD2FLDRF"   // ���Ō�̍��ڂ̓J���}�Ȃ�
                    #endregion
                });
        }
        /// <summary>
        /// ���׃f�U�C���Ή��@����W�v���ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>����W�v���ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        :  ���׃f�U�C���Ή��@����W�v���ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignSalesTotalList()
        {
            return new List<string>( new string[]
            { 
                # region [����W�v����]
                "DSAL.DETAILSUMTITLERF",
                "DSAL.DETAILSUMPRICERF"    // ���Ō�̍��ڂ̓J���}�Ȃ�
                #endregion
            } );
        }
        /// <summary>
        /// ���׃f�U�C���Ή��@�������׍��ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>�������׍��ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή��@�������׍��ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignDepositDetailList()
        {
            return new List<string>( new string[]
            { 
                # region [�������׍���]
                ct_col_DDep_MoneyKindNameSp,
                "DEPSITMAINRF.ACPTANODRSTATUSRF",
                "DEPSITMAINRF.DEPOSITSLIPNORF",
                "DEPSITMAINRF.SALESSLIPNUMRF",
                "DEPSITMAINRF.ADDUPSECCODERF",
                "DEPSITMAINRF.SUBSECTIONCODERF",
                "DEPSITMAINRF.DEPOSITDATERF",
                "DEPSITMAINRF.ADDUPADATERF",
                "DEPSITMAINRF.DEPOSITRF",
                "DEPSITMAINRF.FEEDEPOSITRF",
                "DEPSITMAINRF.DISCOUNTDEPOSITRF",
                "DEPSITMAINRF.AUTODEPOSITCDRF",
                "DEPSITMAINRF.DEPOSITCDRF",
                "DEPSITMAINRF.DRAFTDRAWINGDATERF",
                "DEPSITMAINRF.DRAFTKINDRF",
                "DEPSITMAINRF.DRAFTKINDNAMERF",
                "DEPSITMAINRF.DRAFTDIVIDENAMERF",
                "DEPSITMAINRF.DRAFTNORF",
                "DEPSITMAINRF.CUSTOMERCODERF",
                "DEPSITMAINRF.CLAIMCODERF",
                "DEPSITMAINRF.OUTLINERF",
                "SUBDEP.SUBSECTIONNAMERF",
                "DEPSITDTLRF.DEPOSITSLIPNORF",
                "DEPSITDTLRF.DEPOSITROWNORF",
                "DEPSITDTLRF.MONEYKINDCODERF",
                "DEPSITDTLRF.MONEYKINDNAMERF",
                "DEPSITDTLRF.MONEYKINDDIVRF",
                "DEPSITDTLRF.DEPOSITRF",
                "DEPSITDTLRF.VALIDITYTERMRF",
                "DADD.DEPOSITDATEFYRF",
                "DADD.DEPOSITDATEFSRF",
                "DADD.DEPOSITDATEFWRF",
                "DADD.DEPOSITDATEFMRF",
                "DADD.DEPOSITDATEFDRF",
                "DADD.DEPOSITDATEFGRF",
                "DADD.DEPOSITDATEFRRF",
                "DADD.DEPOSITDATEFLSRF",
                "DADD.DEPOSITDATEFLPRF",
                "DADD.DEPOSITDATEFLYRF",
                "DADD.DEPOSITDATEFLMRF",
                "DADD.DEPOSITDATEFLDRF",
                "DADD.AUTODEPOSITCDRF",
                "DADD.DEPOSITCDRF",
                "DADD.DRAFTDRAWINGDATEFYRF",
                "DADD.DRAFTDRAWINGDATEFSRF",
                "DADD.DRAFTDRAWINGDATEFWRF",
                "DADD.DRAFTDRAWINGDATEFMRF",
                "DADD.DRAFTDRAWINGDATEFDRF",
                "DADD.DRAFTDRAWINGDATEFGRF",
                "DADD.DRAFTDRAWINGDATEFRRF",
                "DADD.DRAFTDRAWINGDATEFLSRF",
                "DADD.DRAFTDRAWINGDATEFLPRF",
                "DADD.DRAFTDRAWINGDATEFLYRF",
                "DADD.DRAFTDRAWINGDATEFLMRF",
                "DADD.DRAFTDRAWINGDATEFLDRF",
                "DADD.DRAFTPAYTIMELIMITFYRF",
                "DADD.DRAFTPAYTIMELIMITFSRF",
                "DADD.DRAFTPAYTIMELIMITFWRF",
                "DADD.DRAFTPAYTIMELIMITFMRF",
                "DADD.DRAFTPAYTIMELIMITFDRF",
                "DADD.DRAFTPAYTIMELIMITFGRF",
                "DADD.DRAFTPAYTIMELIMITFRRF",
                "DADD.DRAFTPAYTIMELIMITFLSRF",
                "DADD.DRAFTPAYTIMELIMITFLPRF",
                "DADD.DRAFTPAYTIMELIMITFLYRF",
                "DADD.DRAFTPAYTIMELIMITFLMRF",
                "DADD.DRAFTPAYTIMELIMITFLDRF",
                "DADD.VALIDITYTERMFYRF",
                "DADD.VALIDITYTERMFSRF",
                "DADD.VALIDITYTERMFWRF",
                "DADD.VALIDITYTERMFMRF",
                "DADD.VALIDITYTERMFDRF",
                "DADD.VALIDITYTERMFGRF",
                "DADD.VALIDITYTERMFRRF",
                "DADD.VALIDITYTERMFLSRF",
                "DADD.VALIDITYTERMFLPRF",
                "DADD.VALIDITYTERMFLYRF",
                "DADD.VALIDITYTERMFLMRF",
                "DADD.VALIDITYTERMFLDRF",
                "DDEP.DETAILTITLERF",    
                "DADD.MONEYKINDCODEOTHERRF"// ���Ō�̍��ڂ̓J���}�Ȃ�
                #endregion
            } );
        }
        /// <summary>
        /// ���׃f�U�C���Ή��@�����W�v���ڃt�B�[���h���X�g
        /// </summary>
        /// <returns>�����W�v���ڃt�B�[���h���X�g</returns>
        /// <remarks>
        /// <br>Note        : ���׃f�U�C���Ή��@�����W�v���ڃt�B�[���h���X�g</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static List<string> GetDesignDepositTotalList()
        {
            return new List<string>( new string[]
            { 
                # region [�����W�v����]
                ct_col_DDep_DepFtOutLine,
                "DDEP.DETAILSUMTITLERF",
                "DDEP.DETAILSUMPRICERF",
                "DADD.DEPOSITFTTITLERF",
                "DADD.DTLTITLERF"
                #endregion
            } );
        }

        # endregion

        # region [�f�[�^�e�[�u������̏��擾]
        /// <summary>
        /// �e�q���菈��
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <returns>�e�q���茋��</returns>
        /// <remarks>
        /// <br>Note        : �e�q���菈��</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static bool IsParent( DataTable table )
        {
            try
            {
                if (table != null && table.Rows.Count > 0)
                {
                    // �����斈�̏W�v���R�[�h�Ȃ��true
                    return ((int)table.Rows[0]["CUSTDMDPRCRF.CUSTOMERCODERF"] == 0);
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return true;
            }
        }

        /// <summary>
        /// �]�ŕ����擾����
        /// </summary>
        /// <param name="table">�f�[�^�e�[�u��</param>
        /// <returns>�]�ŕ����R�[�h</returns>
        /// <remarks>
        /// <br>Note        : �]�ŕ����擾����</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static int GetConsTaxLayMethod( DataTable table )
        {
            if ( table != null && table.Rows.Count > 0 )
            {
                // �]�ŕ���
                return (int)table.Rows[0]["CUSTDMDPRCRF.CONSTAXLAYMETHODRF"];
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// �h�L�������g�}�Ԏ擾
        /// </summary>
        /// <param name="targetRow">�f�[�^���[</param>
        /// <returns>�h�L�������g�}��</returns>
        /// <remarks>
        /// <br>Note        : �h�L�������g�}�Ԏ擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static string GetDocumentDerivedNo( DataRow targetRow )
        {
            string derivedNo = string.Empty;

            // �������w�b�_
            if ( targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] != DBNull.Value )
            {
                EBooksFrePBillHeadWork headWork = (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] as EBooksFrePBillHeadWork);

                if (headWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0)
                {
                    // �W�v���R�[�h
                    derivedNo = string.Format( "{0}_{1}_{2}",
                                                headWork.CUSTDMDPRCRF_ADDUPDATERF.ToString( "00000000" ),
                                                headWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                                headWork.CUSTDMDPRCRF_CLAIMCODERF.ToString( "00000000" ) );
                }
                else
                {
                    // �e�^�q���R�[�h
                    derivedNo = string.Format( "{0}_{1}_{2}_{3}_{4}",
                                                headWork.CUSTDMDPRCRF_ADDUPDATERF.ToString( "00000000" ),
                                                headWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                                headWork.CUSTDMDPRCRF_CLAIMCODERF.ToString("00000000"),
                                                headWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                                                headWork.CUSTDMDPRCRF_CUSTOMERCODERF.ToString("00000000") );
                }
            }

            return derivedNo;
        }

        /// <summary>
        /// �h�L�������g�}�Ԏ擾
        /// </summary>
        /// <param name="targetRow">�f�[�^���[</param>
        /// <returns>�h�L�������g�}��</returns>
        /// <remarks>
        /// <br>Note        : �h�L�������g�}�Ԏ擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public static string GetDocumentDerivedNoForBatch(DataRow targetRow)
        {
            string derivedNo = string.Empty;

            // �������w�b�_
            if (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] != DBNull.Value)
            {
                EBooksFrePBillHeadWork headWork = (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] as EBooksFrePBillHeadWork);

                // �e�^�q���R�[�h
                derivedNo = string.Format("{0}#{1}",
                                            headWork.CUSTDMDPRCRF_CLAIMCODERF.ToString("00000000"),
                                            headWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim());
            }

            return derivedNo;
        }
        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ---->>>>>
        /// <summary>
        /// �h�L�������g�}�Ԏ擾
        /// </summary>
        /// <param name="targetRow">�f�[�^���[</param>
        /// <returns>�h�L�������g�}��</returns>
        /// <remarks>
        /// <br>Note        : �h�L�������g�}�Ԏ擾</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/04/21</br>
        /// </remarks>
        public static string GetDocumentDerivedNoForPattern3(DataRow targetRow)
        {
            string derivedNo = string.Empty;

            // �������w�b�_
            if (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] != DBNull.Value)
            {
                EBooksFrePBillHeadWork headWork = (targetRow[PMKAU01002AB.CT_BillList_FrePBillHead] as EBooksFrePBillHeadWork);
                char[] badChars = new char[] { '\\', '/', ':', '*', '?', '\"', '<', '>', '|' };
                string claimSnm = headWork.CUSTDMDPRCRF_CLAIMSNMRF.Trim();
                StringBuilder claimSnmStr = new StringBuilder();
                string[] result = claimSnm.Split(badChars, StringSplitOptions.RemoveEmptyEntries);
                foreach(string str in result)
                {
                    claimSnmStr.Append(str);
                }
                // �e�^�q���R�[�h
                derivedNo = string.Format("_{0}_{1}_{2}",
                                            headWork.CUSTDMDPRCRF_ADDUPDATERF.ToString("00000000"),
                                            headWork.CUSTDMDPRCRF_CLAIMCODERF.ToString("00000000"),
                                            claimSnmStr.ToString());
            }

            return derivedNo;
        }
        //---ADD 2022/04/21 ���O PMKOBETSU-4208 �d�q����2���Ή� ----<<<<<
        # endregion

        # endregion

        # region [�O���[�v�T�v���X�L�[]
        /// <summary>
        /// �O���[�v�T�v���X�L�[
        /// </summary>
        /// <remarks>
        /// <br>Note        : �O���[�v�T�v���X�L�[</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private struct GroupSuppressKey : IComparable<GroupSuppressKey>
        {
            /// <summary>�y�[�W��</summary>
            private int _page;
            /// <summary>���t</summary>
            private int _date;
            /// <summary>����E����</summary>
            private int _salesDepoDiv;
            /// <summary>����`�[�ԍ�</summary>
            private string _salesSlipNo;
            /// <summary>�����`�[�ԍ�</summary>
            private int _depositSlipNo;
            /// <summary>�^��</summary>
            private string _fullModel;
            /// <summary>�Ԏ�</summary>
            private string _modelFullName;
            /// <summary>�N��</summary>
            private int _firstEntryDate;
            /// <summary>
            /// �y�[�W��
            /// </summary>
            public int Page
            {
                get { return _page; }
                set { _page = value; }
            }
            /// <summary>
            /// ���t
            /// </summary>
            public int Date
            {
                get { return _date; }
                set { _date = value; }
            }
            /// <summary>
            /// ����E����
            /// </summary>
            /// <remarks>0:����,1:����</remarks>
            public int SalesDepoDiv
            {
                get { return _salesDepoDiv; }
                set { _salesDepoDiv = value; }
            }
            /// <summary>
            /// ����`�[�ԍ�
            /// </summary>
            public string SalesSlipNo
            {
                get { return _salesSlipNo; }
                set { _salesSlipNo = value; }
            }
            /// <summary>
            /// �����`�[�ԍ�
            /// </summary>
            public int DepositSlipNo
            {
                get { return _depositSlipNo; }
                set { _depositSlipNo = value; }
            }
            /// <summary>
            /// �^��
            /// </summary>
            /// <remarks>�^���E�Ԏ�E�N���ŃL�[�Ƃ���</remarks>
            public string FullModel
            {
                get { return _fullModel; }
                set { _fullModel = value; }
            }
            /// <summary>
            /// �Ԏ�
            /// </summary>
            /// <remarks>�^���E�Ԏ�E�N���ŃL�[�Ƃ���</remarks>
            public string ModelFullName
            {
                get { return _modelFullName; }
                set { _modelFullName = value; }
            }
            /// <summary>
            /// �N��
            /// </summary>
            /// <remarks>�^���E�Ԏ�E�N���ŃL�[�Ƃ���</remarks>
            public int FirstEntryDate
            {
                get { return _firstEntryDate; }
                set { _firstEntryDate = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="page">�y�[�W��</param>
            /// <param name="date">���t</param>
            /// <param name="salesDepoDiv">����E����</param>
            /// <param name="salesSlipNo">����`�[�ԍ�</param>
            /// <param name="slipNo">�����`�[�ԍ�</param>
            /// <param name="fullModel">�^��</param>
            /// <param name="modelFullName">�Ԏ�</param>
            /// <param name="firstEntryDate">�N��</param>
            /// <remarks>
            /// <br>Note        : �R���X�g���N�^</br>
            /// <br>Programmer  : ���O</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public GroupSuppressKey( int page, int date, int salesDepoDiv, string salesSlipNo, int slipNo, string fullModel, string modelFullName, int firstEntryDate )
            {
                _page = page;
                _date = date;
                _salesDepoDiv = salesDepoDiv;
                _salesSlipNo = salesSlipNo;
                _depositSlipNo = slipNo;
                _fullModel = fullModel;
                _modelFullName = modelFullName;
                _firstEntryDate = firstEntryDate;
            }
            /// <summary>
            /// �������ς݃C���X�^���X�擾
            /// </summary>
            /// <returns>�������ς݃C���X�^���X</returns>
            /// <remarks>
            /// <br>Note        : �������ς݃C���X�^���X�擾</br>
            /// <br>Programmer  : ���O</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey Create()
            {
                GroupSuppressKey key = new GroupSuppressKey();
                key.Page = 0;
                key.Date = 0;
                key.SalesDepoDiv = 0;
                key.SalesSlipNo = string.Empty;
                key.DepositSlipNo = 0;
                key.FullModel = string.Empty;
                key.ModelFullName = string.Empty;
                key.FirstEntryDate = 0;
                return key;
            }

            /// <summary>
            /// ���t�L�[
            /// </summary>
            /// <param name="row">�f�[�^���[</param>
            /// <returns>���t�L�[</returns>
            /// <remarks>
            /// <br>Note        : ���t�L�[</br>
            /// <br>Programmer  : ���O</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfDate( DataRow row )
            {
                GroupSuppressKey key = Create();

                key.Page = (int)row[ct_col_PageCount];
                if ( row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value )
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];

                    // �`�[�ԍ��Ⴂ�Ńu���C�N
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                }
                else if ( row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value )
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];

                    // �`�[�ԍ��Ⴂ�Ńu���C�N
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                }
                return key;
            }

            /// <summary>
            /// �`�[�ԍ��L�[
            /// </summary>
            /// <param name="row">�f�[�^���[</param>
            /// <returns>�`�[�ԍ��L�[</returns>
            /// <remarks>
            /// <br>Note        : �`�[�ԍ��L�[</br>
            /// <br>Programmer  : ���O</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfSlipNo( DataRow row )
            {
                GroupSuppressKey key = Create();
                key.Page = (int)row[ct_col_PageCount];
                if ( row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value )
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                    key.SalesDepoDiv = 0;
                }
                else if ( row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value )
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                    key.SalesDepoDiv = 1;
                }
                return key;
            }

            /// <summary>
            /// ���q���L�[
            /// </summary>
            /// <param name="row">�f�[�^���[</param>
            /// <returns>���q���L�[</returns>
            /// <remarks>
            /// <br>Note        : ���q���L�[</br>
            /// <br>Programmer  : ���O</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfCar( DataRow row )
            {
                GroupSuppressKey key = Create();
                key.Page = (int)row[ct_col_PageCount];
                if ( row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value )
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                    key.SalesDepoDiv = 0;
                    if ( row["ACCEPTODRCARRF.FULLMODELRF"] != DBNull.Value )
                    {
                        key.FullModel = (string)row["ACCEPTODRCARRF.FULLMODELRF"];
                    }
                    if ( row["ACCEPTODRCARRF.MODELFULLNAMERF"] != DBNull.Value )
                    {
                        key.ModelFullName = (string)row["ACCEPTODRCARRF.MODELFULLNAMERF"];
                    }
                    if ( row["ACCEPTODRCARRF.FIRSTENTRYDATERF"] != DBNull.Value )
                    {
                        key.FirstEntryDate = (int)row["ACCEPTODRCARRF.FIRSTENTRYDATERF"];
                    }
                }
                else if ( row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value )
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                    key.SalesDepoDiv = 1;
                }
                return key;
            }

            /// <summary>
            /// ���t�L�[�Q�i�y�[�W���Ȃ��j
            /// </summary>
            /// <param name="row">�f�[�^���[</param>
            /// <returns>���t�L�[�Q�i�y�[�W���Ȃ��j</returns>
            /// <remarks>
            /// <br>Note        : ���t�L�[�Q�i�y�[�W���Ȃ��j</br>
            /// <br>Programmer  : ���O</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfDate2(DataRow row)
            {
                GroupSuppressKey key = Create();

                if (row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value)
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];

                    // �`�[�ԍ��Ⴂ�Ńu���C�N
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                }
                else if (row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value)
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];

                    // �`�[�ԍ��Ⴂ�Ńu���C�N
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                }
                return key;
            }

            /// <summary>
            /// �`�[�ԍ��L�[�Q�i�y�[�W���Ȃ��j
            /// </summary>
            /// <param name="row">�f�[�^���[</param>
            /// <returns>�`�[�ԍ��L�[�Q�i�y�[�W���Ȃ��j</returns>
            /// <remarks>
            /// <br>Note        : �`�[�ԍ��L�[�Q�i�y�[�W���Ȃ��j</br>
            /// <br>Programmer  : ���O</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public static GroupSuppressKey CreateKeyOfSlipNo2(DataRow row)
            {
                GroupSuppressKey key = Create();
                if (row["SALESSLIPRF.SALESSLIPNUMRF"] != DBNull.Value)
                {
                    key.Date = (int)row["SALESSLIPRF.SALESDATERF"];
                    key.SalesSlipNo = (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
                    key.DepositSlipNo = 0;
                    key.SalesDepoDiv = 0;
                }
                else if (row["DEPSITMAINRF.DEPOSITSLIPNORF"] != DBNull.Value)
                {
                    key.Date = (int)row["DEPSITMAINRF.DEPOSITDATERF"];
                    key.SalesSlipNo = string.Empty;
                    key.DepositSlipNo = (int)row["DEPSITMAINRF.DEPOSITSLIPNORF"];
                    key.SalesDepoDiv = 1;
                }
                return key;
            }

            /// <summary>
            /// ��r����
            /// </summary>
            /// <param name="other">��r�p�L�[</param>
            /// <returns>��r����</returns>
            /// <remarks>
            /// <br>Note        : ��r����</br>
            /// <br>Programmer  : ���O</br>
            /// <br>Date        : 2022/03/07</br>
            /// </remarks>
            public int CompareTo( GroupSuppressKey other )
            {
                int result;

                result = this.Page.CompareTo( other.Page );
                if ( result != 0 ) return result;

                result = this.Date.CompareTo( other.Date );
                if ( result != 0 ) return result;

                result = this.SalesSlipNo.CompareTo( other.SalesSlipNo );
                if ( result != 0 ) return result;

                result = this.DepositSlipNo.CompareTo( other.DepositSlipNo );
                if ( result != 0 ) return result;

                result = this.SalesDepoDiv.CompareTo( other.SalesDepoDiv );
                if ( result != 0 ) return result;

                result = this.FullModel.CompareTo( other.FullModel );
                if ( result != 0 ) return result;

                result = this.ModelFullName.CompareTo( other.ModelFullName );
                if ( result != 0 ) return result;

                result = this.FirstEntryDate.CompareTo( other.FirstEntryDate );
                
                return result;
            }
        }
        # endregion

        # region [�\�[�g�penum]
        /// <summary>
        /// �\�[�g�p���R�[�h�敪
        /// </summary>
        internal enum SortRecordDivState
        {
            /// <summary>
            /// ����
            /// </summary>
            Sales = 0,
            /// <summary>
            /// ����
            /// </summary>
            Deposit = 1,
            /// <summary>
            /// ���v
            /// </summary>
            Daily = 2,
        }
        /// <summary>
        /// �\�[�g�p���R�[�h�敪(��s�Ō�)
        /// </summary>
        internal enum SortRecordDiv_EmptyDetailState
        {
            /// <summary>
            /// ����
            /// </summary>
            Sales = 0,
            /// <summary>
            /// ���v
            /// </summary>
            Daily = 1,
            /// <summary>
            /// ����
            /// </summary>
            Deposit = 2,
            /// <summary>
            /// ��s
            /// </summary>
            EmptyDetail = 99,    
        }
        /// <summary>
        /// �\�[�g�p���׋敪���
        /// </summary>
        internal enum SortDetailDivState
        {
            /// <summary>
            /// �w�b�_
            /// </summary>
            Header = 0,
            /// <summary>
            /// ���ׁi�ʏ�j
            /// </summary>
            Detail = 1,
            /// <summary>
            /// �t�b�^
            /// </summary>
            Footer = 2,
            /// <summary>
            /// �t�b�^�Q
            /// </summary>
            Footer2 = 3,
            /// <summary>
            /// �t�b�^�R
            /// </summary>
            Footer3 = 4,
            /// <summary>
            /// �t�b�^�S
            /// </summary>
            Footer4 = 5,
        }
        # endregion

        # region [������������C�A�E�g�p�����[�^]
        /// <summary>
        /// ������������C�A�E�g�p�����[�^
        /// </summary>
        public struct BillDmdPrintParameter
        {
            /// <summary>�Q�Ŗڈȍ~���Z�s��</summary>
            private int _otherFeedAddCount;
            /// <summary>����W�v�s�L���t���O</summary>
            private bool _existsSalesTotalFooter;
            /// <summary>�����W�v�s�L���t���O</summary>
            private bool _existsDepositTotalFooter;
            /// <summary>�`�[�v�^�C�g��</summary>
            private string _footerTitleOfSlip;
            /// <summary>���v�^�C�g��</summary>
            private string _footerTitleOfDaily;
            /// <summary>���Ӑ�v�^�C�g��</summary>
            private string _footerTitleOfCustomer;
            /// <summary>����Ń^�C�g��</summary>
            private string _taxTitle;
            /// <summary>���E�㔄�㍇�v���z(�ō�)�^�C�g�� </summary>
            private string _OfsThisSalesTaxIncTtl;
            /// <summary>�v���[�g�ԍ��^�C�g��</summary>
            private string _carmngCodeTitle;
            /// <summary>�`�[���v����Ń^�C�g��</summary>
            private string _slipTtlTaxTitle;
            /// <summary>����`�[�v(�����)</summary>
            private string _footerTitleOfTax;
            /// <summary>����`�[�v(�ېō��v)</summary>
            private string _footerTitleOfSlipTaxInc;
            /// <summary>����t�b�^�s�L���t���O </summary>
            private bool _existsSalesFooter;
            /// <summary>����t�b�^�Q�s�L���t���O </summary>
            private bool _existsSalesFooter2;
            /// <summary>����t�b�^�R �s�L���t���O </summary>
            private bool _existsSalesFooter3;
            /// <summary>����w�b�_�Q �s�L���t���O </summary>
            private bool _existsSalesHeader2;
            /// <summary>�����v�^�C�g��</summary>
            private string _depositFooterTitleOfSlip;
            /// <summary>����`�[�v(�����)�Q</summary>
            private string _footerTitleOfTax2;
            /// <summary>����`�[�v(�ېō��v)�Q</summary>
            private string _footerTitleOfSlipTaxInc2;
            /// <summary>
            /// �Q�Ŗڈȍ~���Z�s��
            /// </summary>
            public int OtherFeedAddCount
            {
                get { return _otherFeedAddCount; }
                set { _otherFeedAddCount = value; }
            }
            /// <summary>
            /// ����W�v�s�L���t���O
            /// </summary>
            public bool ExistsSalesTotalFooter
            {
                get { return _existsSalesTotalFooter; }
                set { _existsSalesTotalFooter = value; }
            }
            /// <summary>
            /// �����W�v�s�L���t���O
            /// </summary>
            public bool ExistsDepositTotalFooter
            {
                get { return _existsDepositTotalFooter; }
                set { _existsDepositTotalFooter = value; }
            }
            /// <summary>
            /// �`�[�v�^�C�g��
            /// </summary>
            public string FooterTitleOfSlip
            {
                get { return _footerTitleOfSlip; }
                set { _footerTitleOfSlip = value; }
            }
            /// <summary>
            /// ���v�^�C�g��
            /// </summary>
            public string FooterTitleOfDaily
            {
                get { return _footerTitleOfDaily; }
                set { _footerTitleOfDaily = value; }
            }
            /// <summary>
            /// ���Ӑ�v�^�C�g��
            /// </summary>
            public string FooterTitleOfCustomer
            {
                get { return _footerTitleOfCustomer; }
                set { _footerTitleOfCustomer = value; }
            }
            /// <summary>
            /// ����Ń^�C�g��
            /// </summary>
            public string TaxTitle
            {
                get { return _taxTitle; }
                set { _taxTitle = value; }
            }
            /// <summary>
            /// ���E�㔄�㍇�v���z(�ō�)�^�C�g��
            /// </summary>
            public string OfsThisSalesTaxIncTtl
            {
                get { return _OfsThisSalesTaxIncTtl; }
                set { _OfsThisSalesTaxIncTtl = value; }
            }
            /// <summary>
            /// �v���[�g�ԍ��^�C�g��
            /// </summary>
            public string CarmngCodeTitle
            {
                get { return _carmngCodeTitle; }
                set { _carmngCodeTitle = value; }
            }

            /// <summary>
            /// �`�[���v����Ń^�C�g��
            /// </summary>
            public string SlipTtlTaxTitle
            {
                get { return _slipTtlTaxTitle; }
                set { _slipTtlTaxTitle = value; }
            }
            /// <summary>
            /// �`�[�v�^�C�g��(�����) 
            /// </summary>
            public string FooterTitleOfTax
            {
                get { return _footerTitleOfTax; }
                set { _footerTitleOfTax = value; }
            }
            /// <summary>
            /// �`�[�v�^�C�g��(�ېō��v)
            /// </summary>
            public string FooterTitleOfSlipTaxInc
            {
                get { return _footerTitleOfSlipTaxInc; }
                set { _footerTitleOfSlipTaxInc = value; }
            }
            /// <summary>
            /// ����t�b�^�L���t���O
            /// </summary>
            public bool ExistsSalesFooter
            {
                get { return _existsSalesFooter; }
                set { _existsSalesFooter = value; }
            }
            /// <summary>
            /// ����t�b�^�Q�L���t���O
            /// </summary>
            public bool ExistsSalesFooter2
            {
                get { return _existsSalesFooter2; }
                set { _existsSalesFooter2 = value; }
            }
            /// <summary>
            /// ����t�b�^�R �L���t���O
            /// </summary>
            public bool ExistsSalesFooter3
            {
                get { return _existsSalesFooter3; }
                set { _existsSalesFooter3 = value; }
            }
            /// <summary>
            /// ����w�b�_�Q�@�L���t���O
            /// </summary>
            public bool ExistsSalesHeader2
            {
                get { return _existsSalesHeader2; }
                set { _existsSalesHeader2 = value; }
            }
            /// <summary>
            /// �����v�^�C�g��
            /// </summary>
            public string DepositFooterTitleOfSlip
            {
                get { return _depositFooterTitleOfSlip; }
                set { _depositFooterTitleOfSlip = value; }
            }
            /// <summary>
            /// ����`�[�v(�����)�Q
            /// </summary>
            public string FooterTitleOfTax2
            {
                get { return _footerTitleOfTax2; }
                set { _footerTitleOfTax2 = value; }
            }
            /// <summary>
            /// �`�[�v�^�C�g��(�ېō��v)�Q
            /// </summary>
            public string FooterTitleOfSlipTaxInc2
            {
                get { return _footerTitleOfSlipTaxInc2; }
                set { _footerTitleOfSlipTaxInc2 = value; }
            }
        }
        # endregion

        // --- ADD START �c������ 2022/10/18 ----->>>>>
        #region[�ŗ��ʏ�񍇌v]
        /// <summary>
        /// �ŗ��ʏ�񍇌v
        /// </summary>
        /// <param name="lSalesCnsTaxFrcProcd">�������Œ[�������R�[�h</param>
        /// <param name="lConstaxLaymethod">����œ]�ŕ���</param>
        /// <param name="lTaxRate1SalesMoneyEx">�ŗ��P ���v���z</param>
        /// <param name="lTaxRate1SalesPriceConsTax">�ŗ��P �����</param>
        /// <param name="lTaxRate2SalesMoneyEx">�ŗ��Q  ���v���z</param>
        /// <param name="lTaxRate2SalesPriceConsTax">�ŗ��Q  �����</param>
        /// <param name="lTaxOutSalesMoneyEx">��ې� ���v���z</param>
        /// <param name="lOtherSalesMoneyEx">���̑� ���v���z</param>
        /// <param name="lOtherSalesPriceConsTax">���̑� �����</param>
        /// <param name="dicCustomerCode">����œ]�ŕ����u�����q�v����ŋ��z�W�v</param>
        /// <param name="dTaxRate1">�ŗ��P(XML�ݒ�)</param>
        /// <param name="dTaxRate2">�ŗ��Q(XML�ݒ�)</param>
        /// <param name="TotalTaxRateSalesMoney">�ŕʏ�񍇌v</param>
        /// <remarks>
        /// <br>Update Note  : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// <br>Update Note  : 2023/06/23 3H ����</br>
        /// <br>�Ǘ��ԍ�     : 11900025-00 ����œ]�Łu�����q�v�̐ŗ��ʐŊz�s��Ή�</br>
        /// </remarks> 
        private static void SalesTotalTaxMoneyDiffCalc(Int32 lSalesCnsTaxFrcProcd, Int32 lConstaxLaymethod,
                                       Double lTaxRate1SalesMoneyEx, Double lTaxRate1SalesPriceConsTax,
                                        Double lTaxRate2SalesMoneyEx, Double lTaxRate2SalesPriceConsTax,
                                          Double lTaxOutSalesMoneyEx,
                                            Double lOtherSalesMoneyEx, Double lOtherSalesPriceConsTax,                                            
                                              Dictionary<Int32, TaxRateSalesMoney> dicCustomerCode,
                                                Double dTaxRate1, Double dTaxRate2,
                                                  out TaxRateSalesMoney TotalTaxRateSalesMoney)
        {
            #region �u�ϐ��������v
            TotalTaxRateSalesMoney = new TaxRateSalesMoney();
            Int64  ltax                  = 0;     // �����(�[��������)
            Double listPriceFrocProcUnit = 0;     // �[�������P��
            Double lSalesPriceConsTax    = 0;     // �[���������z
            Int32  listPriceFrocProcCd   = 0;     // �[�������R�[�h
            #endregion

            #region �u����œ]�ŕ����F�����q����Ŋz�W�v�v
            // --- DEL START 3H ���� 2023/06/23 ----------------------------------->>>>>
            //if (lConstaxLaymethod == 3)
            //{
            //    lTaxRate1SalesPriceConsTax = 0;
            //    lTaxRate2SalesPriceConsTax = 0;
            //    lOtherSalesPriceConsTax = 0;
            // --- DEL END 3H ���� 2023/06/23 -------------------------------------<<<<<
            // --- ADD START 3H ���� 2023/06/23 ----------------------------------->>>>>
            // [����œ]�Łu�����q�v�̐ŗ��ʐŊz�s��Ή�]
            if (dicCustomerCode.Count > 0)
            {
            // --- ADD END 3H ���� 2023/06/23 -------------------------------------<<<<<
                Double tempOtherTaxRateMoney = 0;
                Double tempOtherTaxRateMoneyTotal = 0;
                TaxRateSalesMoney tempTaxRateSalesMoney;
                foreach (Int32 iCustomerCode in dicCustomerCode.Keys)
                {
                    tempTaxRateSalesMoney = new TaxRateSalesMoney();
                    tempOtherTaxRateMoneyTotal = 0;
                    dicCustomerCode.TryGetValue(iCustomerCode, out tempTaxRateSalesMoney);

                    ltax = 0;
                    lSalesPriceConsTax = tempTaxRateSalesMoney.TaxRate1SalesMoney * dTaxRate1;
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                    lTaxRate1SalesPriceConsTax = lTaxRate1SalesPriceConsTax + ltax;

                    ltax = 0;
                    lSalesPriceConsTax = tempTaxRateSalesMoney.TaxRate2SalesMoney * dTaxRate2;
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                    lTaxRate2SalesPriceConsTax = lTaxRate2SalesPriceConsTax + ltax;

                    foreach (Double dTaxRateKey in tempTaxRateSalesMoney.DicOtherTaxRateSalesMoney.Keys)
                    {
                        tempOtherTaxRateMoney = 0;
                        tempTaxRateSalesMoney.DicOtherTaxRateSalesMoney.TryGetValue(dTaxRateKey, out tempOtherTaxRateMoney);
                        tempOtherTaxRateMoneyTotal = tempOtherTaxRateMoneyTotal + tempOtherTaxRateMoney * dTaxRateKey;
                    }

                    ltax = 0;
                    lSalesPriceConsTax = tempOtherTaxRateMoneyTotal;
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                    lOtherSalesPriceConsTax = lOtherSalesPriceConsTax + ltax;
                }
            }
            #endregion

            #region �u�ŗ��P�v
            // ���z
            TotalTaxRateSalesMoney.TaxRate1SalesMoney = lTaxRate1SalesMoneyEx;
            // �����
            ltax = 0;
            lSalesPriceConsTax = lTaxRate1SalesPriceConsTax;
            stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
            TotalTaxRateSalesMoney.TaxRate1SalesPriceConsTax = ltax;
            #endregion

            #region �u�ŗ��Q�v
            // ���z
            TotalTaxRateSalesMoney.TaxRate2SalesMoney = lTaxRate2SalesMoneyEx;
            // �����
            ltax = 0;
            lSalesPriceConsTax = lTaxRate2SalesPriceConsTax;
            stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
            TotalTaxRateSalesMoney.TaxRate2SalesPriceConsTax = ltax;
            #endregion

            #region�u��ېŁv
            // ���z
            TotalTaxRateSalesMoney.TaxOutSalesMoney = lTaxOutSalesMoneyEx;
            #endregion

            #region�u���̑��v
            // ���z
            TotalTaxRateSalesMoney.OtherSalesMoney = lOtherSalesMoneyEx;
            // �����
            ltax = 0;
            lSalesPriceConsTax = lOtherSalesPriceConsTax;
            stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
            TotalTaxRateSalesMoney.OtherSalesPriceConsTax = ltax;
            #endregion
        }
        #endregion

        #region[���אŗ��ʏ��W�v]
        /// <summary>
        /// �ŗ��ʏ��W�v
        /// </summary>
        /// <param name="index">���㖾�׃f�[�^�C���f�b�N�X</param>
        /// <param name="lSalesCnsTaxFrcProcd">�������Œ[�������R�[�h</param>
        /// <param name="salesData">����f�[�^</param>
        /// <param name="bChgFlg">�`�[�ԍ��ύX�L���t���O</param>
        /// <param name="lTaxRate1SalesMoneyEx">�ŗ��P ���v���z</param>
        /// <param name="lTaxRate1SalesPriceConsTax">�ŗ��P ����ō��v</param>
        /// <param name="lTaxRate2SalesMoneyEx">�ŗ��Q  ���v���z</param>
        /// <param name="lTaxRate2SalesPriceConsTax">�ŗ��Q  ����ō��v</param>
        /// <param name="lOtherSalesMoneyEx">���̑� ���v���z</param>
        /// <param name="lOtherSalesPriceConsTax">���̑� ����ō��v</param>
        /// <param name="lTaxRate1MeisaiTotalTax">�ŗ��P ����œ]�ŕ����F�u���ד]�Łv�̏���ŋ��z���v</param>
        /// <param name="lTaxRate2MeisaiTotalTax">�ŗ��Q ����œ]�ŕ����F�u���ד]�Łv�̏���ŋ��z���v</param>
        /// <param name="lOtherMeisaiTotalTax">���̑� ����œ]�ŕ����F�u���ד]�Łv�̏���ŋ��z���v</param>
        /// <param name="lSalesMoneyEx">�ېŋ敪(1:��ې�)�ȊO�̏��i�@������z���v</param>
        /// <param name="lSalesMoneyExTaxOut">�ېŋ敪(1:��ې�)�̏��i�@������z���v</param>
        /// <param name="dicCustomerCode">����œ]�ŕ����u�����q�v����ŋ��z�W�v</param>
        /// <param name="dTaxRate1">�ŗ��P(XML�ݒ�)</param>
        /// <param name="dTaxRate2">�ŗ��Q(XML�ݒ�)</param>
        /// <remarks>
        /// <br>Update Note  : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// </remarks>
        private static void SalesMeisaiTaxMoneyDiffCalc(Int64 index, Int32 lSalesCnsTaxFrcProcd , EBooksFrePBillDetailWork salesData, bool bChgFlg,
                                              ref Double lTaxRate1SalesMoneyEx, ref Double lTaxRate1SalesPriceConsTax,
                                                ref Double lTaxRate2SalesMoneyEx, ref Double lTaxRate2SalesPriceConsTax,
                                                  ref Double lOtherSalesMoneyEx, ref Double lOtherSalesPriceConsTax,
                                                    ref Double lTaxRate1MeisaiTotalTax, ref Double lTaxRate2MeisaiTotalTax, ref Double lOtherMeisaiTotalTax,
                                                      ref Double lSalesMoneyEx, ref double lSalesMoneyExTaxOut,
                                                        ref Dictionary<Int32, TaxRateSalesMoney> dicCustomerCode,
                                                          Double dTaxRate1, Double dTaxRate2)
        {
            if (index > 0)
            {
                Int64  ltax                  = 0;                                         // �����(�[��������)
                Double listPriceFrocProcUnit = 0;                                         // �[�������P��                
                Double lSalesPriceConsTax    = 0;                                         // �[���������z                
                Int32  listPriceFrocProcCd   = 0;                                         // �[�������R�[�h
                Double dTaxRate              = salesData.SALESSLIPRF_CONSTAXRATERF;       // ����Őŗ�
                Int32  iConsTaxlaymethod     = salesData.SALESSLIPRF_CONSTAXLAYMETHODRF;  // ����œ]�ŕ���
                Int32  iTaxAtionDivCd        = salesData.SALESDETAILRF_TAXATIONDIVCDRF;   // �ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)

                #region �u����œ]�ŕ����u���ד]�Łv���@�ېŋ敪(1:��ې�)�ȊO����Ŋz�W�v�A�v
                if ((iConsTaxlaymethod == 1) && (iTaxAtionDivCd != 1))
                {
                    lSalesPriceConsTax = (salesData.SALESDETAILRF_SALESMONEYTAXEXCRF * salesData.SALESSLIPRF_CONSTAXRATERF);
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);

                    // �ŗ��u�ŗ��Q�v������œ]�ŕ����u��ېŁv�ȊO�̔���f�[�^���W�v
                    if ((dTaxRate == dTaxRate2) && (iConsTaxlaymethod != 9))
                    {
                        lTaxRate2MeisaiTotalTax = lTaxRate2MeisaiTotalTax + ltax;
                    }
                    // �ŗ��u�ŗ��P�v������œ]�ŕ����u��ېŁv�ȊO�̔���f�[�^���W�v
                    else if ((dTaxRate == dTaxRate1) && (iConsTaxlaymethod != 9))
                    {
                        lTaxRate1MeisaiTotalTax = lTaxRate1MeisaiTotalTax + ltax;
                    }
                    // �ŗ��u�ŗ��Q�v�u�ŗ��P�v�ȊO �̔���f�[�^�W�v
                    else if ((dTaxRate != dTaxRate1) && (dTaxRate != dTaxRate2))
                    {
                        lOtherMeisaiTotalTax = lOtherMeisaiTotalTax + ltax;
                    }
                }
                #endregion
                // �ېŋ敪(1:��ې�)�ȊO ���@����œ]�ŕ���(9:��ې�)�ȊO�@������z���W�v
                if ((iTaxAtionDivCd != 1) && (iConsTaxlaymethod != 9))
                {
                    lSalesMoneyEx = lSalesMoneyEx + salesData.SALESDETAILRF_SALESMONEYTAXEXCRF;
                }

                // ��ېŔ�����z���W�v �ېŋ敪(1:��ې�) ���� ����œ]�ŕ���(9:��ې�)�@������z���W�v
                if (iTaxAtionDivCd == 1 || iConsTaxlaymethod == 9)
                {
                    lSalesMoneyExTaxOut = lSalesMoneyExTaxOut + salesData.SALESDETAILRF_SALESMONEYTAXEXCRF;
                }

                // �`�[�ԍ��ύX���͍Ō�̔���w�b�_�̏ꍇ�A
                if (bChgFlg)
                {
                    // ����������
                    ltax                  = 0;    // �����(�[��������)
                    listPriceFrocProcUnit = 0;    // �[�������P��
                    listPriceFrocProcCd   = 0;    // �[�������R�[�h
                    lSalesPriceConsTax    = lSalesMoneyEx * salesData.SALESSLIPRF_CONSTAXRATERF;
                    stc_priceTaxCalculator.GetSalesFractionProcInfo(1, lSalesCnsTaxFrcProcd, (double)lSalesPriceConsTax, out listPriceFrocProcUnit, out listPriceFrocProcCd);
                    #region �u�ŗ��Q�v�Z�v
                    // �ŗ��u�ŗ��Q�v������œ]�ŕ����u��ېŁv�ȊO�̔���f�[�^���W�v
                    if ((dTaxRate == dTaxRate2) && (iConsTaxlaymethod != 9))
                    {
                        // �ŗ��Q  ���v���z(���㏬�v�i�Ŕ����j)
                        lTaxRate2SalesMoneyEx = lTaxRate2SalesMoneyEx + lSalesMoneyEx;

                        // ����œ]�ŕ����u�`�[�]�Łv�̏ꍇ
                        if (iConsTaxlaymethod == 0)
                        {
                            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                            lTaxRate2SalesPriceConsTax = lTaxRate2SalesPriceConsTax + ltax;
                        }
                        // ����œ]�ŕ����u���ׁv�̏ꍇ
                        else if (iConsTaxlaymethod == 1)
                        {
                            // �ŗ��Q  ����ō��v
                            lTaxRate2SalesPriceConsTax = lTaxRate2SalesPriceConsTax + lTaxRate2MeisaiTotalTax;
                        }
                        // ����œ]�ŕ����u�����e�v�̏ꍇ
                        else if (iConsTaxlaymethod == 2)
                        {
                            lTaxRate2SalesPriceConsTax = lTaxRate2SalesPriceConsTax + lSalesPriceConsTax;
                        }
                        // ����œ]�ŕ����u�����q�v�̏ꍇ
                        else if (iConsTaxlaymethod == 3)
                        {
                            TaxRateSalesMoney temptaxRateSale = new TaxRateSalesMoney();
                            temptaxRateSale.DicOtherTaxRateSalesMoney = new Dictionary<Double, Double>();
                            // �ŗ��Q  ����ō��v
                            if (!dicCustomerCode.ContainsKey(salesData.SALESSLIPRF_CUSTOMERCODERF))
                            {
                                dicCustomerCode.Add(salesData.SALESSLIPRF_CUSTOMERCODERF, temptaxRateSale);
                            }

                            dicCustomerCode.TryGetValue(salesData.SALESSLIPRF_CUSTOMERCODERF, out temptaxRateSale);

                            temptaxRateSale.TaxRate2SalesMoney = temptaxRateSale.TaxRate2SalesMoney + lSalesMoneyEx;

                            dicCustomerCode[salesData.SALESSLIPRF_CUSTOMERCODERF] = temptaxRateSale;

                        }

                    }
                    #endregion

                    #region �u�ŗ��P�v�Z�v
                    // �ŗ��u�ŗ��P�v������œ]�ŕ����u��ېŁv�ȊO�̔���f�[�^���W�v
                    else if ((dTaxRate == dTaxRate1) && (iConsTaxlaymethod != 9))
                    {
                        // �ŗ��P  ���v���z(���㏬�v�i�Ŕ����j)
                        lTaxRate1SalesMoneyEx = lTaxRate1SalesMoneyEx + lSalesMoneyEx;

                        // ����œ]�ŕ����u�`�[�]�Łv�̏ꍇ
                        if ((iConsTaxlaymethod == 0))
                        {
                            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                            lTaxRate1SalesPriceConsTax = lTaxRate1SalesPriceConsTax + ltax;
                        }
                        // ����œ]�ŕ����u���ׁv�̏ꍇ
                        else if (iConsTaxlaymethod == 1)
                        {
                            // �ŗ��P  ����ō��v
                            lTaxRate1SalesPriceConsTax = lTaxRate1SalesPriceConsTax + lTaxRate1MeisaiTotalTax;
                        }

                        // ����œ]�ŕ����u�����e�v�̏ꍇ
                        else if (iConsTaxlaymethod == 2)
                        {
                            lTaxRate1SalesPriceConsTax = lTaxRate1SalesPriceConsTax + lSalesPriceConsTax;
                        }
                        // ����œ]�ŕ����u�����q�v�̏ꍇ
                        else if (iConsTaxlaymethod == 3)
                        {
                            TaxRateSalesMoney temptaxRateSale = new TaxRateSalesMoney();
                            temptaxRateSale.DicOtherTaxRateSalesMoney = new Dictionary<Double, Double>();

                            // �ŗ��P  ����ō��v
                            if (!dicCustomerCode.ContainsKey(salesData.SALESSLIPRF_CUSTOMERCODERF))
                            {
                                dicCustomerCode.Add(salesData.SALESSLIPRF_CUSTOMERCODERF, temptaxRateSale);
                            }

                            dicCustomerCode.TryGetValue(salesData.SALESSLIPRF_CUSTOMERCODERF, out temptaxRateSale);

                            temptaxRateSale.TaxRate1SalesMoney = temptaxRateSale.TaxRate1SalesMoney + lSalesMoneyEx;

                            dicCustomerCode[salesData.SALESSLIPRF_CUSTOMERCODERF] = temptaxRateSale;
                        }

                    }
                    #endregion

                    #region �u���̑��v�Z�v
                    // �ŗ��u�ŗ��Q�v�u�ŗ��P�v�ȊO���͏���œ]�ŕ����u��ېŁv�̔���f�[�^�W�v
                    if ((dTaxRate != dTaxRate1) && (dTaxRate != dTaxRate2) && (iConsTaxlaymethod != 9))
                    {
                        // ���̑�  ���v���z(���㏬�v�i�Ŕ����j) 
                        lOtherSalesMoneyEx = lOtherSalesMoneyEx + lSalesMoneyEx;

                        // ����œ]�ŕ����u�`�[�A�����q�v�̏ꍇ
                        if (iConsTaxlaymethod == 0)
                        {
                            FractionCalculate.FracCalcMoney(lSalesPriceConsTax, listPriceFrocProcUnit, listPriceFrocProcCd, out ltax);
                            lOtherSalesPriceConsTax = lOtherSalesPriceConsTax + ltax;
                        }
                        // ����œ]�ŕ����u���ׁv�̏ꍇ
                        else if (iConsTaxlaymethod == 1)
                        {
                            // ���̂�  ����ō��v
                            lOtherSalesPriceConsTax = lOtherSalesPriceConsTax + lOtherMeisaiTotalTax;
                        }
                        // ����œ]�ŕ����u�����e�v�̏ꍇ
                        else if (iConsTaxlaymethod == 2)
                        {
                            lOtherSalesPriceConsTax = lOtherSalesPriceConsTax + lSalesPriceConsTax;
                        }
                        // ����œ]�ŕ����u�����q�v�̏ꍇ
                        else if (iConsTaxlaymethod == 3)
                        {
                            TaxRateSalesMoney temptaxRateSale = new TaxRateSalesMoney();
                            temptaxRateSale.DicOtherTaxRateSalesMoney = new Dictionary<Double, Double>();
                            Double dicOtherRate = 0;
                            // ���̑��@�ŗ�  ����ō��v
                            if (!dicCustomerCode.ContainsKey(salesData.SALESSLIPRF_CUSTOMERCODERF))
                            {
                                dicCustomerCode.Add(salesData.SALESSLIPRF_CUSTOMERCODERF, temptaxRateSale);
                            }

                            dicCustomerCode.TryGetValue(salesData.SALESSLIPRF_CUSTOMERCODERF, out temptaxRateSale);

                            // �����ŗ��@�ŗ��P��
                            if (!temptaxRateSale.DicOtherTaxRateSalesMoney.ContainsKey(dTaxRate))
                            {
                                temptaxRateSale.DicOtherTaxRateSalesMoney.Add(dTaxRate, 0);
                            }

                            // �����ŗ��@���v���z(���㏬�v�i�Ŕ����j)
                            temptaxRateSale.DicOtherTaxRateSalesMoney.TryGetValue(dTaxRate, out dicOtherRate);

                            dicOtherRate = dicOtherRate + lSalesMoneyEx;

                            temptaxRateSale.DicOtherTaxRateSalesMoney[dTaxRate] = dicOtherRate;

                            // ���Ӑ�R�[�h�P��
                            dicCustomerCode[salesData.SALESSLIPRF_CUSTOMERCODERF] = temptaxRateSale;
                        }
                    }
                    #endregion
                    // �`�[�P�ʌv�Z���߂ɁA���Z�b�g
                    // ����œ]�ŕ����F�u���ד]�Łv
                    lTaxRate1MeisaiTotalTax = 0; // �ŗ��P ����Ŋz
                    lTaxRate2MeisaiTotalTax = 0; // �ŗ��Q ����Ŋz
                    lOtherMeisaiTotalTax = 0; // ���̑� ����Ŋz
                    lSalesMoneyEx = 0;
                }
            }
        }
        #endregion

        /// <summary>
        /// �ŗ��ʍ��v���z
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : 2022/10/18 �c������</br>
        /// <br>�Ǘ��ԍ�     : 11870141-00 �C���{�C�X�c�Ή��i�y���ŗ��Ή��j</br>
        /// </remarks>
        public class TaxRateSalesMoney 
        {
            /// <summary>�ŗ��P ���v���z</summary>
            private Double _TaxRate1SalesMoney;

            /// <summary>�ŗ��P ����Ŋz</summary>
            private Double _TaxRate1SalesPriceConsTax;

            /// <summary>�ŗ��Q���v���z</summary>
            private Double _TaxRate2SalesMoney;

            /// <summary>�ŗ��Q ����Ŋz</summary>
            private Double _TaxRate2SalesPriceConsTax;

            /// <summary>���̑� ���v���z</summary>
            private Double _OtherSalesMoney;

            /// <summary>���̑� ����Ŋz</summary>
            private Double _OtherSalesPriceConsTax;

            /// <summary>���̑��ŗ��ʋ��z</summary>
            private Dictionary<Double, Double> _dicOtherTaxRateSalesMoney;

            /// <summary>��ېŁ@���v���z</summary>
            private Double _TaxOutSalesMoney;
            /// public propaty name  :  TaxOutSalesMoney
            /// <summary>��ېŁ@���v���z</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ��ېŁ@���v���z�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double TaxOutSalesMoney
            {
                get { return _TaxOutSalesMoney; }
                set { _TaxOutSalesMoney = value; }
            }

            /// public propaty name  :  TaxRate1SalesMoney
            /// <summary>�ŗ��P���v���z</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �ŗ��P���v���z�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double TaxRate1SalesMoney
            {
                get { return _TaxRate1SalesMoney; }
                set { _TaxRate1SalesMoney = value; }
            }

            /// public propaty name  :  TaxRate1SalesPriceConsTax
            /// <summary>�ŗ��P����Ŋz</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �ŗ��P����Ŋz�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double TaxRate1SalesPriceConsTax
            {
                get { return _TaxRate1SalesPriceConsTax; }
                set { _TaxRate1SalesPriceConsTax = value; }
            }

            /// public propaty name  :  TaxRate2SalesMoney
            /// <summary>�ŗ��Q���v���z</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �ŗ��Q���v���z�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double TaxRate2SalesMoney
            {
                get { return _TaxRate2SalesMoney; }
                set { _TaxRate2SalesMoney = value; }
            }

            /// public propaty name  :  TaxRate2SalesPriceConsTax
            /// <summary>�ŗ��Q ����Ŋz</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �ŗ��Q����Ŋz�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double TaxRate2SalesPriceConsTax
            {
                get { return _TaxRate2SalesPriceConsTax; }
                set { _TaxRate2SalesPriceConsTax = value; }
            }

            /// public propaty name  :  OtherSalesMoney
            /// <summary>���̑����v���z</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���̑����v���z�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double OtherSalesMoney
            {
                get { return _OtherSalesMoney; }
                set { _OtherSalesMoney = value; }
            }

            /// public propaty name  :  OtherSalesPriceConsTax
            /// <summary>���̑� ����Ŋz</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   �ŗ��P����Ŋz�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Double OtherSalesPriceConsTax
            {
                get { return _OtherSalesPriceConsTax; }
                set { _OtherSalesPriceConsTax = value; }
            }

            /// public propaty name  :  DicOtherTaxRateSalesMoney
            /// <summary>���̑��ŗ��ʋ��z</summary>
            /// ----------------------------------------------------------------------
            /// <remarks>
            /// <br>note             :   ���̑��ŗ��ʋ��z�v���p�e�B</br>
            /// <br>Programer        :   ��������</br>
            /// </remarks>
            public Dictionary<Double, Double> DicOtherTaxRateSalesMoney
            {
                get { return _dicOtherTaxRateSalesMoney; }
                set { _dicOtherTaxRateSalesMoney = value; }
            }

        }
        #region[���z�E����ł��v�Z]
        /// <summary>
        /// ���z�Ə���ł��v�Z
        /// </summary>
        internal class PriceTaxCalculator
        {
            internal const int ctFracProcMoneyDiv_SalesMoney = 0;
            /// <summary>�[�������Ώۋ��z�敪�i����Łj</summary>
            internal const int ctFracProcMoneyDiv_Tax = 1;

            private List<SalesProcMoneyWork> _salesProcMoneyWorkList;

            /// <summary>
            /// ������z�����敪
            /// </summary>
            public List<SalesProcMoneyWork> SalesProcMoneyWorkList
            {
                get { return _salesProcMoneyWorkList; }
                set { _salesProcMoneyWorkList = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public PriceTaxCalculator()
            {
                _salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
            }

            /// <summary>
            /// �[�������P�ʁA�[�������敪�擾����
            /// </summary>
            /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
            /// <param name="fractionProcCode">�[�������R�[�h</param>
            /// <param name="targetPrice">�Ώۋ��z</param>
            /// <param name="fractionProcUnit">�[�������P��</param>
            /// <param name="fractionProcCd">�[�������敪</param>
            public void GetSalesFractionProcInfo(int fracProcMoneyDiv, int fractionProcCode, double targetPrice, out double fractionProcUnit, out int fractionProcCd)
            {
                //-----------------------------------------------------------------------------
                // �����l
                //-----------------------------------------------------------------------------

                switch (fracProcMoneyDiv)
                {
                    // �[�������Ώۋ��z�敪�i����P���j
                    case 2: // �P����0.01�~�P��
                        fractionProcUnit = 0.01;
                        break;
                    default:
                        fractionProcUnit = 1;               // �P���ȊO��1�~�P��
                        break;
                }

                fractionProcCd = 1;     // �؎̂�

                //-----------------------------------------------------------------------------
                // �R�[�h�Y�����R�[�h�擾
                //-----------------------------------------------------------------------------
                List<SalesProcMoneyWork> salesProcMoneyList = this._salesProcMoneyWorkList.FindAll(
                    delegate(SalesProcMoneyWork sProcMoney)
                    {
                        if ((sProcMoney.FracProcMoneyDiv == fracProcMoneyDiv) &&
                            (sProcMoney.FractionProcCode == fractionProcCode))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                //-----------------------------------------------------------------------------
                // �\�[�g�i������z�i�����j�j
                //-----------------------------------------------------------------------------
                salesProcMoneyList.Sort(new SalesProcMoneyComparer());

                //-----------------------------------------------------------------------------
                // ������z�Y�����R�[�h�擾
                //-----------------------------------------------------------------------------
                SalesProcMoneyWork salesProcMoney = salesProcMoneyList.Find(
                    delegate(SalesProcMoneyWork spm)
                    {
                        if (spm.UpperLimitPrice >= targetPrice)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                );

                //-----------------------------------------------------------------------------
                // �߂�l�ݒ�
                //-----------------------------------------------------------------------------
                if (salesProcMoney != null)
                {
                    fractionProcUnit = salesProcMoney.FractionProcUnit;
                    fractionProcCd = salesProcMoney.FractionProcCd;
                }
            }
            /// <summary>
            /// ������z�����敪�}�X�^��r�N���X(������z(����))
            /// </summary>
            private class SalesProcMoneyComparer : Comparer<SalesProcMoneyWork>
            {
                public override int Compare(SalesProcMoneyWork x, SalesProcMoneyWork y)
                {
                    int result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                    return result;
                }
            }

        }
        #endregion
        // --- ADD END   �c������ 2022/10/18 -----<<<<<
    }
}
